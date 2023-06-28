using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Reflection;

namespace Xamarin.MMP.Tests {
	[TestFixture]
	public class LinkerTests {
		int GetNumberOfTypesInLibrary (string path)
		{
			string output = TI.RunAndAssert ("/Library/Frameworks/Mono.framework/Versions/Current/Commands/monop", new [] { "-r:" + path }, "GetNumberOfTypesInLibrary");
			string [] splitBuildOutput = output.Split (new string [] { Environment.NewLine }, StringSplitOptions.None);
			string outputLine = splitBuildOutput.First (x => x.StartsWith ("Total:"));
			string numberSize = outputLine.Split (':') [1];
			string number = numberSize.Split (' ') [1];
			return int.Parse (number);
		}

		string GetAppName (bool modern) => modern ? "UnifiedExample.app" : "XM45Example.app";
		string GetOutputBundlePath (string tmpDir, string name, bool modern) => Path.Combine (tmpDir, "bin/Debug/" + GetAppName (modern) + "/Contents/MonoBundle", name + ".dll");

		string GetFrameworkName (bool modern) => modern ? "Xamarin.Mac" : "4.5";
		string GetBaseAssemblyPath (string name, bool modern) => Path.Combine (TI.FindRootDirectory (), "Library/Frameworks/Xamarin.Mac.framework/Versions/Current/lib/mono/" + GetFrameworkName (modern) + "/", name + ".dll");

		const string PlatformProjectConfig = "<LinkMode>Platform</LinkMode>";

		[Test]
		public void ModernLinkingSDK_WithAllNonProductSkipped_BuildsWithSameNumberOfTypes ()
		{
			MMPTests.RunMMPTest (tmpDir => {
				string [] dependencies = { "mscorlib", "System.Core", "System" };
				string config = "<LinkMode>SdkOnly</LinkMode><MonoBundlingExtraArgs>--linkskip=" + dependencies.Aggregate ((arg1, arg2) => arg1 + " --linkskip=" + arg2) + "</MonoBundlingExtraArgs>";
				TI.UnifiedTestConfig test = new TI.UnifiedTestConfig (tmpDir) { CSProjConfig = config };
				TI.TestUnifiedExecutable (test);
				foreach (string dep in dependencies) {
					int typesInBaseLib = GetNumberOfTypesInLibrary (GetBaseAssemblyPath (dep, true));
					int typesInOutput = GetNumberOfTypesInLibrary (GetOutputBundlePath (tmpDir, dep, true));
					Assert.AreEqual (typesInBaseLib, typesInOutput, $"We linked a linkskip - {dep} with config ({typesInBaseLib} vs {typesInOutput}:\n {config}");
				}
			});
		}

		[Test]
		public void FullLinkingSdk_BuildsWithFewerPlatformTypesOnly ()
		{
			MMPTests.RunMMPTest (tmpDir => {
				string [] nonPlatformDependencies = { "mscorlib", "System.Core", "System" };
				TI.UnifiedTestConfig test = new TI.UnifiedTestConfig (tmpDir) { CSProjConfig = PlatformProjectConfig, XM45 = true };
				TI.TestUnifiedExecutable (test);
				foreach (string dep in nonPlatformDependencies) {
					int typesInBaseLib = GetNumberOfTypesInLibrary (GetBaseAssemblyPath (dep, false));
					int typesInOutput = GetNumberOfTypesInLibrary (GetOutputBundlePath (tmpDir, dep, false));
					Assert.AreEqual (typesInBaseLib, typesInOutput, $"We linked a linkskip - {dep} with config ({typesInBaseLib} vs {typesInOutput}):\n {PlatformProjectConfig}");
				}

				int typesInBasePlatform = GetNumberOfTypesInLibrary (GetBaseAssemblyPath ("Xamarin.Mac", false));
				int typesInOutputPlatform = GetNumberOfTypesInLibrary (GetOutputBundlePath (tmpDir, "Xamarin.Mac", false));
				Assert.AreNotEqual (typesInBasePlatform, typesInOutputPlatform, $"We linked a linkskip - Xamarin.Mac with config ({typesInBasePlatform} vs {typesInOutputPlatform}):\n {PlatformProjectConfig}");

			});
		}

		[Test]
		[TestCase ("linker")]
		[TestCase ("code")]
		[TestCase ("ignore")]
		[TestCase ("default")]
		public void DynamicSymbolMode (string mode)
		{
			MMPTests.RunMMPTest (tmpDir => {
				TI.UnifiedTestConfig config = new TI.UnifiedTestConfig (tmpDir) {
					CSProjConfig = $"<MonoBundlingExtraArgs>--dynamic-symbol-mode={mode}</MonoBundlingExtraArgs>\n",
				};
				var output = TI.TestUnifiedExecutable (config);
				var build_output = output.BuildResult.BuildOutput;
				switch (mode) {
				case "linker":
				case "default":
					Assert.That (build_output, Does.Contain ("-u "), "reference.m");
					Assert.That (build_output, Does.Not.Contain ("reference.m"), "reference.m");
					break;
				case "code":
					Assert.That (build_output, Does.Not.Contain ("-u "), "reference.m");
					Assert.That (build_output, Does.Contain ("reference.m"), "reference.m");
					break;
				case "ignore":
					Assert.That (build_output, Does.Not.Contain ("-u "), "reference.m");
					Assert.That (build_output, Does.Not.Contain ("reference.m"), "reference.m");
					break;
				default:
					throw new NotImplementedException ();
				}
			});
		}

		[TestCase ("None", false)]
		[TestCase ("full", true)]
		[TestCase ("platform", true)]
		[TestCase ("sdkonly", true)]
		public void Linking_ShouldHandleMixedModeAssemblies (string linker, bool builds_successfully)
		{
			MMPTests.RunMMPTest (tmpDir => {
				string libraryPath = Path.Combine (TI.FindSourceDirectory (), "../MixedClassLibrary.dll");

				TI.UnifiedTestConfig test = new TI.UnifiedTestConfig (tmpDir) {
					References = $"<Reference Include=\"MixedClassLibrary\"><HintPath>{libraryPath}</HintPath></Reference>",
					CSProjConfig = $"<LinkMode>{linker}</LinkMode>",
					TestCode = "System.Console.WriteLine (typeof (MixedClassLibrary.Class1));",
				};

				var buildOutput = TI.TestUnifiedExecutable (test, shouldFail: builds_successfully).BuildResult;
				Assert.True (buildOutput.HasMessage (2014) == builds_successfully, $"Building with {linker} did not give 2014 status {builds_successfully} as expected.");
			});
		}

		[Test]
		public void LinkingAdditionalArguments_ShouldBeUsed ()
		{
			MMPTests.RunMMPTest (tmpDir => {
				TI.UnifiedTestConfig test = new TI.UnifiedTestConfig (tmpDir) { CSProjConfig = "<MonoBundlingExtraArgs>-v -v --linkplatform</MonoBundlingExtraArgs>" };
				var testResult = TI.TestUnifiedExecutable (test);
				Assert.IsTrue (testResult.BuildResult.BuildOutput.Contains ("Selected Linking: 'Platform'"), $"Build Output did not contain expected selected linking line: {testResult}");
			});
		}

		[Test]
		public void LinkingWithPartialStatic_ShouldFail ()
		{
			MMPTests.RunMMPTest (tmpDir => {
				TI.UnifiedTestConfig test = new TI.UnifiedTestConfig (tmpDir) { CSProjConfig = "<MonoBundlingExtraArgs>--registrar:partial --linkplatform</MonoBundlingExtraArgs>" };
				var testResult = TI.TestUnifiedExecutable (test, shouldFail: true);
				testResult.BuildResult.Messages.AssertError (2110, "Xamarin.Mac 'Partial Static' registrar does not support linking. Disable linking or use another registrar mode.");
			});
		}
	}
}
