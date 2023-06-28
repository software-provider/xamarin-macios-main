using System;
using System.IO;

using Microsoft.Build.Utilities;
using Microsoft.Build.Framework;

namespace Xamarin.MacDev.Tasks {
	public abstract class OptimizeImageTaskBase : XamarinToolTask {
		ITaskItem inputImage;
		ITaskItem outputImage;

		#region Inputs

		[Required]
		public ITaskItem [] InputImages { get; set; }

		[Required]
		[Output]
		public ITaskItem [] OutputImages { get; set; }

		[Required]
		public string SdkDevPath { get; set; }

		#endregion

		string DevicePlatformBinDir {
			get { return Path.Combine (SdkDevPath, "Platforms", "iPhoneOS.platform", "Developer", "usr", "bin"); }
		}

		protected override string ToolName {
			get { return "pngcrush"; }
		}

		protected override string GenerateFullPathToTool ()
		{
			if (!string.IsNullOrEmpty (ToolPath))
				return Path.Combine (ToolPath, ToolExe);

			var path = Path.Combine (DevicePlatformBinDir, ToolExe);

			return File.Exists (path) ? path : ToolExe;
		}

		protected override string GenerateCommandLineCommands ()
		{
			var args = new CommandLineBuilder ();

			args.AppendSwitch ("-q");
			args.AppendSwitch ("-iphone");
			args.AppendSwitch ("-f");
			args.AppendSwitch ("0");
			args.AppendFileNameIfNotNull (inputImage.ItemSpec);
			args.AppendFileNameIfNotNull (outputImage.ItemSpec);

			return args.ToString ();
		}

		protected override void LogEventsFromTextOutput (string singleLine, MessageImportance messageImportance)
		{
			var tokens = singleLine.Split (new [] { ':' }, 2);

			if (tokens.Length == 2 && tokens [0].StartsWith ("libpng ", StringComparison.Ordinal)) {
				var type = tokens [0].Substring ("libpng ".Length).Trim ();

				switch (type) {
				case "warning":
					Log.LogWarning (null, null, null, inputImage.ItemSpec, 0, 0, 0, 0, "{0}", tokens [1].Trim ());
					break;
				case "error":
					Log.LogError (null, null, null, inputImage.ItemSpec, 0, 0, 0, 0, "{0}", tokens [1].Trim ());
					break;
				default:
					Log.LogError (null, null, null, inputImage.ItemSpec, 0, 0, 0, 0, "{0}", singleLine);
					break;
				}
			} else {
				Log.LogMessage (messageImportance, "{0}", singleLine);
			}
		}

		public override bool Execute ()
		{
			var result = true;

			for (var index = 0; index < this.InputImages.Length && index < this.OutputImages.Length; index++) {
				this.inputImage = this.InputImages [index];
				this.outputImage = this.OutputImages [index];

				Directory.CreateDirectory (Path.GetDirectoryName (outputImage.ItemSpec));

				result = result && base.Execute ();

				// Wait for the process to be disposed and avoid the error:
				// System.IO.IOException: Error creating standard error pipe
				// when optimizing many png images (>100)
				System.GC.Collect ();
			}

			return result;
		}
	}
}
