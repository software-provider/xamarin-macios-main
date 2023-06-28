using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Reflection;

using Xamarin.Tests;

namespace Xamarin.MMP.Tests {
	[TestFixture]
	public class AOTTests {
		void ValidateAOTStatus (string tmpDir, Func<FileInfo, bool> shouldAOT)
		{
			foreach (var file in GetOutputDirInfo (tmpDir).EnumerateFiles ()) {
				bool shouldBeAOT = shouldAOT (file);
				Assert.AreEqual (shouldBeAOT, File.Exists (file.FullName + ".dylib"), "{0} should {1}be AOT.", file.FullName, shouldBeAOT ? "" : "not ");

			}
		}

		enum TestType { Base, Hybrid }

		string GetTestConfig (TestType type, bool useProjectTags)
		{
			if (useProjectTags) {
				switch (type) {
				case TestType.Base:
					return "<AOTMode>Core</AOTMode>";
				case TestType.Hybrid:
					return "<AOTMode>All</AOTMode><HybridAOT>true</HybridAOT>";
				}
			} else {
				switch (type) {
				case TestType.Base:
					return "<MonoBundlingExtraArgs>--aot=core</MonoBundlingExtraArgs>";
				case TestType.Hybrid:
					return "<MonoBundlingExtraArgs>--aot=all|hybrid</MonoBundlingExtraArgs>";
				}
			}
			throw new NotImplementedException ();
		}

		DirectoryInfo GetOutputDirInfo (string tmpDir) => new DirectoryInfo (Path.Combine (tmpDir, GetOutputBundlePath (tmpDir)));
		string GetOutputAppPath (string tmpDir) => Path.Combine (tmpDir, "bin/Debug/UnifiedExample.app/Contents/MacOS/UnifiedExample");
		string GetOutputBundlePath (string tmpDir) => Path.Combine (tmpDir, "bin/Debug/UnifiedExample.app/Contents/MonoBundle");

		bool IsFileManagedCode (FileInfo file) => file.Extension.ToLowerInvariant () == ".exe" || file.Extension.ToLowerInvariant () == ".dll";
		bool ShouldBaseFilesBeAOT (FileInfo file) => file.Name == "Xamarin.Mac.dll" || file.Name == "System.dll" || file.Name == "mscorlib.dll";

		[TestCase (false)]
		[TestCase (true)]
		public void AOT_SmokeTest (bool useProjectTags)
		{
			MMPTests.RunMMPTest (tmpDir => {
				TI.UnifiedTestConfig test = new TI.UnifiedTestConfig (tmpDir) {
					CSProjConfig = GetTestConfig (TestType.Base, useProjectTags)
				};
				TI.TestUnifiedExecutable (test);
				ValidateAOTStatus (tmpDir, f => ShouldBaseFilesBeAOT (f));
			});
		}

		[TestCase (false)]
		[TestCase (true)]
		public void HybridAOT_WithManualStrippingOfAllLibs_SmokeTest (bool useProjectTags)
		{
			MMPTests.RunMMPTest (tmpDir => {
				TI.UnifiedTestConfig test = new TI.UnifiedTestConfig (tmpDir) {
					CSProjConfig = GetTestConfig (TestType.Hybrid, useProjectTags)
				};
				TI.TestUnifiedExecutable (test);

				foreach (var file in GetOutputDirInfo (tmpDir).EnumerateFiles ()) {
					if (IsFileManagedCode (file))
						TI.RunAndAssert ("/Library/Frameworks/Mono.framework/Commands/mono-cil-strip", new [] { file.ToString () }, "Manually strip IL");
				}

				ValidateAOTStatus (tmpDir, IsFileManagedCode);

				TI.RunEXEAndVerifyGUID (tmpDir, test.guid, GetOutputAppPath (tmpDir));
			});
		}

		[TestCase (false)]
		[TestCase (true)]
		public void HybridAOT_WithManualStrippingOfJustMainExe (bool useProjectTags)
		{
			MMPTests.RunMMPTest (tmpDir => {
				TI.UnifiedTestConfig test = new TI.UnifiedTestConfig (tmpDir) {
					CSProjConfig = GetTestConfig (TestType.Hybrid, useProjectTags)
				};
				TI.TestUnifiedExecutable (test);

				TI.RunAndAssert ("/Library/Frameworks/Mono.framework/Commands/mono-cil-strip", new [] { Path.Combine (GetOutputBundlePath (tmpDir), "UnifiedExample.exe") }, "Manually strip IL");

				ValidateAOTStatus (tmpDir, IsFileManagedCode);

				TI.RunEXEAndVerifyGUID (tmpDir, test.guid, GetOutputAppPath (tmpDir));
			});
		}
	}
}
