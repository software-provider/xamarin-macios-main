#nullable enable

using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

using Mono.Cecil;

using Xamarin.MacDev;
using Xamarin.Tests;

namespace Xamarin.Tests {
	[TestFixture]
	public abstract class TestBaseClass {
		protected Dictionary<string, string> verbosity = new Dictionary<string, string> {
			{ "_BundlerVerbosity", "1" },
		};

		protected Dictionary<string, string> GetDefaultProperties (string? runtimeIdentifiers = null)
		{
			var rv = new Dictionary<string, string> (verbosity);
			if (!string.IsNullOrEmpty (runtimeIdentifiers))
				SetRuntimeIdentifiers (rv, runtimeIdentifiers);
			return rv;
		}

		protected void SetRuntimeIdentifiers (Dictionary<string, string> properties, string runtimeIdentifiers)
		{
			var multiRid = runtimeIdentifiers.IndexOf (';') >= 0 ? "RuntimeIdentifiers" : "RuntimeIdentifier";
			properties [multiRid] = runtimeIdentifiers;
		}

		protected string GetProjectPath (string project, string runtimeIdentifiers, ApplePlatform platform, out string appPath, string? subdir = null, string configuration = "Debug", string? netVersion = null)
		{
			return GetProjectPath (project, null, runtimeIdentifiers, platform, out appPath, configuration, netVersion);
		}

		protected string GetProjectPath (string project, string? subdir, string runtimeIdentifiers, ApplePlatform platform, out string appPath, string configuration = "Debug", string? netVersion = null)
		{
			var rv = GetProjectPath (project, subdir, platform);
			appPath = Path.Combine (GetOutputPath (project, subdir, runtimeIdentifiers, platform, configuration, netVersion), project + ".app");
			return rv;
		}

		protected string GetAppPath (string projectPath, ApplePlatform platform, string runtimeIdentifiers, string configuration = "Debug")
		{
			return Path.Combine (GetBinDir (projectPath, platform, runtimeIdentifiers, configuration), Path.GetFileNameWithoutExtension (projectPath) + ".app");
		}

		protected string GetBinDir (string projectPath, ApplePlatform platform, string runtimeIdentifiers, string configuration = "Debug")
		{
			return GetBinOrObjDir ("bin", projectPath, platform, runtimeIdentifiers, configuration);
		}

		protected string GetObjDir (string projectPath, ApplePlatform platform, string runtimeIdentifiers, string configuration = "Debug")
		{
			return GetBinOrObjDir ("obj", projectPath, platform, runtimeIdentifiers, configuration);
		}

		protected string GetBinOrObjDir (string binOrObj, string projectPath, ApplePlatform platform, string runtimeIdentifiers, string configuration = "Debug")
		{
			var appPathRuntimeIdentifier = runtimeIdentifiers.IndexOf (';') >= 0 ? "" : runtimeIdentifiers;
			return Path.Combine (Path.GetDirectoryName (projectPath)!, binOrObj, configuration, platform.ToFramework (), appPathRuntimeIdentifier);
		}

		protected string GetOutputPath (string project, string? subdir, string runtimeIdentifiers, ApplePlatform platform, string configuration = "Debug", string? netVersion = null)
		{
			var rv = GetProjectPath (project, subdir, platform);
			if (string.IsNullOrEmpty (runtimeIdentifiers))
				runtimeIdentifiers = GetDefaultRuntimeIdentifier (platform, configuration);
			var appPathRuntimeIdentifier = runtimeIdentifiers.IndexOf (';') >= 0 ? "" : runtimeIdentifiers;
			return Path.Combine (Path.GetDirectoryName (rv)!, "bin", configuration, platform.ToFramework (netVersion), appPathRuntimeIdentifier);
		}

		protected string GetDefaultRuntimeIdentifier (ApplePlatform platform, string configuration = "Debug")
		{
			switch (platform) {
			case ApplePlatform.iOS:
				return "iossimulator-x64";
			case ApplePlatform.TVOS:
				return "tvossimulator-x64";
			case ApplePlatform.MacOSX:
				return "Release".Equals (configuration, StringComparison.OrdinalIgnoreCase) ? "osx-x64;osx-arm64" : "osx-x64";
			case ApplePlatform.MacCatalyst:
				return "Release".Equals (configuration, StringComparison.OrdinalIgnoreCase) ? "maccatalyst-x64;maccatalyst-arm64" : "maccatalyst-x64";
			default:
				throw new ArgumentOutOfRangeException ($"Unknown platform: {platform}");
			}
		}

		protected string GetProjectPath (string project, string? subdir = null, ApplePlatform? platform = null)
		{
			var project_dir = Path.Combine (Configuration.SourceRoot, "tests", "dotnet", project);
			if (!string.IsNullOrEmpty (subdir))
				project_dir = Path.Combine (project_dir, subdir);

			var project_path = Path.Combine (project_dir, project + ".csproj");
			if (File.Exists (project_path))
				return project_path;

			if (platform.HasValue)
				project_dir = Path.Combine (project_dir, platform.Value.AsString ());

			project_path = Path.Combine (project_dir, project + ".csproj");
			if (!File.Exists (project_path))
				project_path = Path.ChangeExtension (project_path, "sln");

			if (!File.Exists (project_path))
				throw new FileNotFoundException ($"Could not find the project or solution {project} - {project_path} does not exist.");

			return project_path;
		}

		protected string GetPlugInsRelativePath (ApplePlatform platform)
		{
			switch (platform) {
			case ApplePlatform.iOS:
			case ApplePlatform.TVOS:
				return "PlugIns";
			case ApplePlatform.MacCatalyst:
			case ApplePlatform.MacOSX:
				return Path.Combine ("Contents", "PlugIns");
			default:
				throw new ArgumentOutOfRangeException ($"Unknown platform: {platform}");
			}
		}

		protected void Clean (string project_path)
		{
			var dirs = Directory.GetDirectories (Path.GetDirectoryName (project_path)!, "*", SearchOption.AllDirectories);
			dirs = dirs.OrderBy (v => v.Length).Reverse ().ToArray (); // If we have nested directories, make sure to delete the nested one first
			foreach (var dir in dirs) {
				var name = Path.GetFileName (dir);
				if (name != "bin" && name != "obj")
					continue;
				Directory.Delete (dir, true);
			}
		}

		protected static bool CanExecute (ApplePlatform platform, string runtimeIdentifiers)
		{
			switch (platform) {
			case ApplePlatform.iOS:
			case ApplePlatform.TVOS:
			case ApplePlatform.WatchOS:
				return false;
			case ApplePlatform.MacOSX:
			case ApplePlatform.MacCatalyst:
				// If we're targetting x64, then we can execute everywhere
				if (runtimeIdentifiers.Contains ("-x64", StringComparison.Ordinal))
					return true;

				// If we're not targeting x64, and we're executing on x64, then we're out of luck
				if (RuntimeInformation.ProcessArchitecture == Architecture.X64)
					return false;

				// Otherwise we can still execute.
				return true;
			default:
				throw new ArgumentOutOfRangeException ($"Unknown platform: {platform}");
			}
		}

		protected string GetRelativeResourcesDirectory (ApplePlatform platform)
		{
			switch (platform) {
			case ApplePlatform.iOS:
			case ApplePlatform.TVOS:
			case ApplePlatform.WatchOS:
				return "Resources";
			case ApplePlatform.MacOSX:
			case ApplePlatform.MacCatalyst:
				return Path.Combine ("Contents", "Resources");
			default:
				throw new ArgumentOutOfRangeException ($"Unknown platform: {platform}");
			}
		}

		protected string GetRelativeAssemblyDirectory (ApplePlatform platform)
		{
			switch (platform) {
			case ApplePlatform.iOS:
			case ApplePlatform.TVOS:
			case ApplePlatform.WatchOS:
				return string.Empty;
			case ApplePlatform.MacOSX:
			case ApplePlatform.MacCatalyst:
				return Path.Combine ("Contents", "MonoBundle");
			default:
				throw new NotImplementedException ($"Unknown platform: {platform}");
			}
		}

		protected string GetRelativeDylibDirectory (ApplePlatform platform)
		{
			return GetRelativeAssemblyDirectory (platform);
		}

		protected string GetInfoPListPath (ApplePlatform platform, string app_directory)
		{
			switch (platform) {
			case ApplePlatform.iOS:
			case ApplePlatform.TVOS:
			case ApplePlatform.WatchOS:
				return Path.Combine (app_directory, "Info.plist");
			case ApplePlatform.MacOSX:
			case ApplePlatform.MacCatalyst:
				return Path.Combine (app_directory, "Contents", "Info.plist");
			default:
				throw new NotImplementedException ($"Unknown platform: {platform}");
			}
		}

		protected void AssertBundleAssembliesStripStatus (string appPath, bool shouldStrip)
		{
			var assemblies = Directory.GetFiles (appPath, "*.dll", SearchOption.AllDirectories);
			var assembliesWithOnlyEmptyMethods = new List<String> ();
			foreach (var assembly in assemblies) {
				ModuleDefinition definition = ModuleDefinition.ReadModule (assembly, new ReaderParameters { ReadingMode = ReadingMode.Deferred });

				bool onlyHasEmptyMethods = definition.Assembly.MainModule.Types.All (t =>
					t.Methods.Where (m => m.HasBody).All (m => m.Body.Instructions.Count == 1));
				if (onlyHasEmptyMethods) {
					assembliesWithOnlyEmptyMethods.Add (assembly);
				}
			}

			// Some assemblies, such as Facades, will be completely empty even when not stripped
			Assert.That (assemblies.Length == assembliesWithOnlyEmptyMethods.Count, Is.EqualTo (shouldStrip), $"Unexpected stripping status: of {assemblies.Length} assemblies {assembliesWithOnlyEmptyMethods.Count} were empty.");
		}

		protected void AssertDSymDirectory (string appPath)
		{
			var dSYMDirectory = appPath + ".dSYM";
			Assert.That (dSYMDirectory, Does.Exist, "dsym directory");
		}

		protected static string GetNativeExecutable (ApplePlatform platform, string app_directory)
		{
			var executableName = Path.GetFileNameWithoutExtension (app_directory);
			return Path.Combine (app_directory, GetRelativeExecutableDirectory (platform), executableName);
		}

		protected static string GetRelativeExecutableDirectory (ApplePlatform platform)
		{
			switch (platform) {
			case ApplePlatform.iOS:
			case ApplePlatform.TVOS:
			case ApplePlatform.WatchOS:
				return string.Empty;
			case ApplePlatform.MacOSX:
			case ApplePlatform.MacCatalyst:
				return Path.Combine ("Contents", "MacOS");
			default:
				throw new NotImplementedException ($"Unknown platform: {platform}");
			}
		}

		protected string GetRelativeCodesignDirectory (ApplePlatform platform)
		{
			switch (platform) {
			case ApplePlatform.iOS:
			case ApplePlatform.TVOS:
			case ApplePlatform.WatchOS:
				return string.Empty;
			case ApplePlatform.MacOSX:
			case ApplePlatform.MacCatalyst:
				return "Contents";
			default:
				throw new NotImplementedException ($"Unknown platform: {platform}");
			}
		}

		protected string GetResourcesDirectory (ApplePlatform platform, string app_directory)
		{
			switch (platform) {
			case ApplePlatform.iOS:
			case ApplePlatform.TVOS:
			case ApplePlatform.WatchOS:
				return app_directory;
			case ApplePlatform.MacOSX:
			case ApplePlatform.MacCatalyst:
				return Path.Combine (app_directory, "Contents", "Resources");
			default:
				throw new NotImplementedException ($"Unknown platform: {platform}");
			}
		}

		protected string GenerateProject (ApplePlatform platform, string name, string runtimeIdentifiers, out string? appPath)
		{
			var dir = Cache.CreateTemporaryDirectory (name);
			var csproj = Path.Combine (dir, $"{name}.csproj");
			var sb = new StringBuilder ();
			sb.AppendLine ($"<?xml version=\"1.0\" encoding=\"utf-8\"?>");
			sb.AppendLine ($"<Project Sdk=\"Microsoft.NET.Sdk\">");
			sb.AppendLine ($"	<PropertyGroup>");
			sb.AppendLine ($"		<TargetFramework>{platform.ToFramework ()}</TargetFramework>");
			sb.AppendLine ($"		<OutputType>Exe</OutputType>");
			sb.AppendLine ($"		<ApplicationTitle>{name}</ApplicationTitle>");
			sb.AppendLine ($"		<ApplicationId>com.xamarin.testproject.{name}</ApplicationId>");
			sb.AppendLine ($"	</PropertyGroup>");
			sb.AppendLine ($"</Project>");

			File.WriteAllText (csproj, sb.ToString ());

			var appPathRuntimeIdentifier = runtimeIdentifiers.IndexOf (';') >= 0 ? "" : runtimeIdentifiers;
			appPath = Path.Combine (dir, "bin", "Debug", platform.ToFramework (), appPathRuntimeIdentifier, name + ".app");

			return csproj;
		}

		protected void ExecuteWithMagicWordAndAssert (ApplePlatform platform, string runtimeIdentifiers, string executable)
		{
			if (!CanExecute (platform, runtimeIdentifiers))
				return;

			ExecuteWithMagicWordAndAssert (executable);
		}

		protected void ExecuteWithMagicWordAndAssert (string executable)
		{
			var rv = Execute (executable, out var output, out string magicWord);
			Assert.That (output.ToString (), Does.Contain (magicWord), "Contains magic word");
			Assert.AreEqual (0, rv.ExitCode, "ExitCode");
		}

		protected Execution Execute (string executable, out StringBuilder output, out string magicWord)
		{
			if (!File.Exists (executable))
				throw new FileNotFoundException ($"The executable '{executable}' does not exists.");

			magicWord = Guid.NewGuid ().ToString ();
			var env = new Dictionary<string, string?> {
				{ "MAGIC_WORD", magicWord },
				{ "DYLD_FALLBACK_LIBRARY_PATH", null }, // VSMac might set this, which may cause tests to crash.
			};

			output = new StringBuilder ();
			return Execution.RunWithStringBuildersAsync (executable, Array.Empty<string> (), environment: env, standardOutput: output, standardError: output, timeout: TimeSpan.FromSeconds (15)).Result;
		}

		public static StringBuilder AssertExecute (string executable, params string [] arguments)
		{
			return AssertExecute (executable, arguments, out _);
		}

		public static StringBuilder AssertExecute (string executable, string [] arguments, out StringBuilder output)
		{
			var rv = ExecutionHelper.Execute (executable, arguments, out output);
			if (rv != 0) {
				Console.WriteLine ($"'{executable} {StringUtils.FormatArguments (arguments)}' exited with exit code {rv}:");
				Console.WriteLine ("\t" + output.ToString ().Replace ("\n", "\n\t").TrimEnd (new char [] { '\n', '\t' }));
			}
			Assert.AreEqual (0, rv, $"Unable to execute '{executable} {StringUtils.FormatArguments (arguments)}': exit code {rv}");
			return output;
		}

		protected void ExecuteProjectWithMagicWordAndAssert (string csproj, ApplePlatform platform, string? runtimeIdentifiers = null)
		{
			if (runtimeIdentifiers is null)
				runtimeIdentifiers = GetDefaultRuntimeIdentifier (platform);

			var appPath = GetAppPath (csproj, platform, runtimeIdentifiers);
			var appExecutable = GetNativeExecutable (platform, appPath);
			ExecuteWithMagicWordAndAssert (appExecutable);
		}

		protected bool IsRuntimeIdentifierSigned (string runtimeIdentifiers)
		{
			foreach (var rid in runtimeIdentifiers.Split (';', StringSplitOptions.RemoveEmptyEntries)) {
				if (rid.StartsWith ("ios-", StringComparison.OrdinalIgnoreCase))
					return true;
				if (rid.StartsWith ("tvos-", StringComparison.OrdinalIgnoreCase))
					return true;
			}
			return false;
		}

		protected bool TryGetEntitlements (string nativeExecutable, [NotNullWhen (true)] out PDictionary? entitlements)
		{
			var entitlementsPath = Path.Combine (Cache.CreateTemporaryDirectory (), "EntitlementsInBinary.plist");
			var args = new string [] {
				"--display",
				"--entitlements",
				entitlementsPath,
				"--xml",
				nativeExecutable
			};
			var rv = ExecutionHelper.Execute ("codesign", args, out var codesignOutput, TimeSpan.FromSeconds (15));
			Assert.AreEqual (0, rv, $"'codesign {string.Join (" ", args)}' failed:\n{codesignOutput}");
			if (File.Exists (entitlementsPath)) {
				entitlements = PDictionary.FromFile (entitlementsPath);
				return entitlements is not null;
			}
			entitlements = null;
			return false;
		}
	}
}
