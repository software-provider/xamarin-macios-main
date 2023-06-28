using System.IO;
using System.Linq;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;

using Xamarin.Tests;
using Xamarin.Utils;

using NUnit.Framework;

namespace Xamarin.MacDev.Tasks {
	[TestFixture ("iPhone")]
	[TestFixture ("iPhoneSimulator")]
	public class CoreMLCompiler : ProjectTest {
		public CoreMLCompiler (string platform) : base (platform)
		{
		}

		void AssertCompiledModelExists (string modelName)
		{
			var expected = new string [] { "coremldata.bin", "model.espresso.net", "model.espresso.shape", "model.espresso.weights", "model/coremldata.bin", "neural_network_optionals/coremldata.bin" };
			var mlmodelc = Path.Combine (AppBundlePath, modelName + ".mlmodelc");

			Assert.IsTrue (Directory.Exists (mlmodelc));

			var files = new HashSet<string> (Directory.EnumerateFiles (mlmodelc, "*.*", SearchOption.AllDirectories));

			foreach (var name in expected)
				Assert.IsTrue (files.Contains (Path.Combine (mlmodelc, name)), "{0} not found", name);

			var expected_length = expected.Length;
			if (Configuration.XcodeVersion.Major >= 12) {
				Assert.IsTrue (files.Contains (Path.Combine (mlmodelc, "metadata.json")), " metadata.json not found");
				expected_length++;
				Assert.IsTrue (files.Contains (Path.Combine (mlmodelc, "analytics", "coremldata.bin")), "analytics/coremldata.bin not found");
				expected_length++;
			}
			Assert.AreEqual (expected_length, files.Count, "File count");
		}

		[Test]
		public void RebuildTest ()
		{
			Configuration.IgnoreIfIgnoredPlatform (ApplePlatform.iOS);
			Configuration.AssertLegacyXamarinAvailable (); // Investigate whether this test should be ported to .NET

			BuildProject ("MyCoreMLApp");

			AssertCompiledModelExists ("SqueezeNet");

			EnsureFilestampChange ();

			// Rebuild w/ no changes
			BuildProject ("MyCoreMLApp", clean: false);

			AssertCompiledModelExists ("SqueezeNet");
		}
	}
}
