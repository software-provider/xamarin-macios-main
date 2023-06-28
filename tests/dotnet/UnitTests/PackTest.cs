#nullable enable

using System.IO.Compression;

namespace Xamarin.Tests {
	public class PackTest : TestBaseClass {


		[Test]
		[TestCase (ApplePlatform.iOS)]
		[TestCase (ApplePlatform.MacCatalyst)]
		[TestCase (ApplePlatform.TVOS)]
		[TestCase (ApplePlatform.MacOSX)]
		public void BindingOldStyle (ApplePlatform platform)
		{
			var project = "BindingOldStyle";
			Configuration.IgnoreIfIgnoredPlatform (platform);

			var project_path = GetProjectPath (project, platform: platform);
			Clean (project_path);

			var tmpdir = Cache.CreateTemporaryDirectory ();
			var outputPath = Path.Combine (tmpdir, "OutputPath");
			var intermediateOutputPath = Path.Combine (tmpdir, "IntermediateOutputPath");
			var properties = GetDefaultProperties ();
			properties ["OutputPath"] = outputPath + Path.DirectorySeparatorChar;
			properties ["IntermediateOutputPath"] = intermediateOutputPath + Path.DirectorySeparatorChar;

			var rv = DotNet.AssertPackFailure (project_path, properties);
			var errors = BinLog.GetBuildLogErrors (rv.BinLogPath).ToArray ();
			Assert.AreEqual (1, errors.Length, "Error count");
			Assert.AreEqual ($"Creating a NuGet package is not supported for projects that have ObjcBindingNativeLibrary items. Migrate to use NativeReference items instead.", errors [0].Message, "Error message");
		}

		[Test]
		[TestCase (ApplePlatform.iOS, true)]
		[TestCase (ApplePlatform.iOS, false)]
		[TestCase (ApplePlatform.MacCatalyst, true)]
		[TestCase (ApplePlatform.MacCatalyst, false)]
		[TestCase (ApplePlatform.TVOS, true)]
		[TestCase (ApplePlatform.TVOS, false)]
		[TestCase (ApplePlatform.MacOSX, true)]
		[TestCase (ApplePlatform.MacOSX, false)]
		public void BindingFrameworksProject (ApplePlatform platform, bool noBindingEmbedding)
		{
			var project = "bindings-framework-test";
			Configuration.IgnoreIfIgnoredPlatform (platform);

			var project_path = Path.Combine (Configuration.RootPath, "tests", project, "dotnet", platform.AsString (), $"{project}.csproj");
			Clean (project_path);

			var tmpdir = Cache.CreateTemporaryDirectory ();
			var outputPath = Path.Combine (tmpdir, "OutputPath");
			var intermediateOutputPath = Path.Combine (tmpdir, "IntermediateOutputPath");
			var properties = GetDefaultProperties ();
			properties ["OutputPath"] = outputPath + Path.DirectorySeparatorChar;
			properties ["IntermediateOutputPath"] = intermediateOutputPath + Path.DirectorySeparatorChar;
			properties ["NoBindingEmbedding"] = noBindingEmbedding ? "true" : "false";

			DotNet.AssertPack (project_path, properties);

			var nupkg = Path.Combine (outputPath, project + ".1.0.0.nupkg");
			Assert.That (nupkg, Does.Exist, "nupkg existence");

			var archive = ZipFile.OpenRead (nupkg);
			var files = archive.Entries.Select (v => v.FullName).ToHashSet ();
			var hasSymlinks = noBindingEmbedding && (platform == ApplePlatform.MacCatalyst || platform == ApplePlatform.MacOSX);
			if (noBindingEmbedding) {
				Assert.That (archive.Entries.Count, Is.EqualTo (hasSymlinks ? 6 : 10), $"nupkg file count - {nupkg}");
			} else {
				Assert.That (archive.Entries.Count, Is.EqualTo (5), $"nupkg file count - {nupkg}");
			}
			Assert.That (files, Does.Contain (project + ".nuspec"), "nuspec");
			Assert.That (files, Does.Contain ("_rels/.rels"), ".rels");
			Assert.That (files, Does.Contain ("[Content_Types].xml"), "[Content_Types].xml");
			Assert.That (files, Does.Contain ($"lib/{platform.ToFrameworkWithDefaultVersion ()}/{project}.dll"), $"{project}.dll");
			Assert.That (files, Has.Some.Matches<string> (v => v.StartsWith ("package/services/metadata/core-properties/", StringComparison.Ordinal) && v.EndsWith (".psmdcp", StringComparison.Ordinal)), "psmdcp");
			if (noBindingEmbedding) {
				if (hasSymlinks) {
					Assert.That (files, Does.Contain ($"lib/{platform.ToFrameworkWithDefaultVersion ()}/{project}.resources.zip"), $"{project}.resources.zip");
				} else {
					Assert.That (files, Does.Contain ($"lib/{platform.ToFrameworkWithDefaultVersion ()}/{project}.resources/XStaticArTest.framework/XStaticArTest"), $"XStaticArTest.framework/XStaticArTest");
					Assert.That (files, Does.Contain ($"lib/{platform.ToFrameworkWithDefaultVersion ()}/{project}.resources/XStaticObjectTest.framework/XStaticObjectTest"), $"XStaticObjectTest.framework/XStaticObjectTest");
					Assert.That (files, Does.Contain ($"lib/{platform.ToFrameworkWithDefaultVersion ()}/{project}.resources/XTest.framework/XTest"), $"XTest.framework/XTest");
					Assert.That (files, Does.Contain ($"lib/{platform.ToFrameworkWithDefaultVersion ()}/{project}.resources/XTest.framework/Info.plist"), $"XTest.framework/Info.plist");
					Assert.That (files, Does.Contain ($"lib/{platform.ToFrameworkWithDefaultVersion ()}/{project}.resources/manifest"), $"manifest");
				}
			}
		}

		[Test]
		[TestCase (ApplePlatform.iOS, true)]
		[TestCase (ApplePlatform.iOS, false)]
		[TestCase (ApplePlatform.MacCatalyst, true)]
		[TestCase (ApplePlatform.MacCatalyst, false)]
		[TestCase (ApplePlatform.TVOS, true)]
		[TestCase (ApplePlatform.TVOS, false)]
		[TestCase (ApplePlatform.MacOSX, true)]
		[TestCase (ApplePlatform.MacOSX, false)]
		public void BindingXcFrameworksProject (ApplePlatform platform, bool noBindingEmbedding)
		{
			var project = "bindings-xcframework-test";
			var assemblyName = "bindings-framework-test";

			// This tests gets really complicated if not all platforms are included,
			// because the (number of) files included in the nupkg depends not only
			// on the current platform, but on the other included platforms as well.
			// For example: if either macOS or Mac Catalyst is included, then some
			// parts of the .xcframework will be zipped differently (due to symlinks
			// in the xcframework).
			Configuration.IgnoreIfAnyIgnoredPlatforms ();

			var project_path = Path.Combine (Configuration.RootPath, "tests", project, "dotnet", platform.AsString (), $"{project}.csproj");
			Clean (project_path);

			var tmpdir = Cache.CreateTemporaryDirectory ();
			var outputPath = Path.Combine (tmpdir, "OutputPath");
			var intermediateOutputPath = Path.Combine (tmpdir, "IntermediateOutputPath");
			var properties = GetDefaultProperties ();
			properties ["OutputPath"] = outputPath + Path.DirectorySeparatorChar;
			properties ["IntermediateOutputPath"] = intermediateOutputPath + Path.DirectorySeparatorChar;
			properties ["NoBindingEmbedding"] = noBindingEmbedding ? "true" : "false";

			DotNet.AssertPack (project_path, properties);

			var nupkg = Path.Combine (outputPath, assemblyName + ".1.0.0.nupkg");
			Assert.That (nupkg, Does.Exist, "nupkg existence");

			var archive = ZipFile.OpenRead (nupkg);
			var files = archive.Entries.Select (v => v.FullName).ToHashSet ();
			Assert.That (archive.Entries.Count, Is.EqualTo (noBindingEmbedding ? 6 : 5), $"nupkg file count - {nupkg}");
			Assert.That (files, Does.Contain (assemblyName + ".nuspec"), "nuspec");
			Assert.That (files, Does.Contain ("_rels/.rels"), ".rels");
			Assert.That (files, Does.Contain ("[Content_Types].xml"), "[Content_Types].xml");
			Assert.That (files, Does.Contain ($"lib/{platform.ToFrameworkWithDefaultVersion ()}/{assemblyName}.dll"), $"{assemblyName}.dll");
			Assert.That (files, Has.Some.Matches<string> (v => v.StartsWith ("package/services/metadata/core-properties/", StringComparison.Ordinal) && v.EndsWith (".psmdcp", StringComparison.Ordinal)), "psmdcp");
			if (noBindingEmbedding) {
				Assert.That (files, Does.Contain ($"lib/{platform.ToFrameworkWithDefaultVersion ()}/{assemblyName}.resources.zip"), $"{assemblyName}.resources.zip");
			}
		}

		[Test]
		[TestCase (ApplePlatform.iOS)]
		[TestCase (ApplePlatform.MacCatalyst)]
		[TestCase (ApplePlatform.TVOS)]
		[TestCase (ApplePlatform.MacOSX)]
		public void LibraryProject (ApplePlatform platform)
		{
			var project = "MyClassLibrary";
			Configuration.IgnoreIfIgnoredPlatform (platform);

			var project_path = GetProjectPath (project, runtimeIdentifiers: string.Empty, platform: platform, out var appPath);
			Clean (project_path);
			var properties = GetDefaultProperties ();

			DotNet.AssertPack (project_path, properties);

			var nupkg = Path.Combine (Path.GetDirectoryName (project_path)!, "bin", "Debug", project + ".1.0.0.nupkg");
			Assert.That (nupkg, Does.Exist, "nupkg existence");

			var archive = ZipFile.OpenRead (nupkg);
			var files = archive.Entries.Select (v => v.FullName).ToHashSet ();
			Assert.That (archive.Entries.Count, Is.EqualTo (5), "nupkg file count");
			Assert.That (files, Does.Contain (project + ".nuspec"), "nuspec");
			Assert.That (files, Does.Contain ("_rels/.rels"), ".rels");
			Assert.That (files, Does.Contain ("[Content_Types].xml"), "[Content_Types].xml");
			Assert.That (files, Does.Contain ($"lib/{platform.ToFrameworkWithDefaultVersion ()}/{project}.dll"), $"{project}.dll");
			Assert.That (files, Has.Some.Matches<string> (v => v.StartsWith ("package/services/metadata/core-properties/", StringComparison.Ordinal) && v.EndsWith (".psmdcp", StringComparison.Ordinal)), "psmdcp");
		}
	}
}
