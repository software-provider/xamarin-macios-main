using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Build.Framework;
using Xamarin.Localization.MSBuild;
using Threading = System.Threading.Tasks;

namespace Xamarin.MacDev.Tasks {
	public abstract class XamarinBuildTask : XamarinTask {
		public bool KeepTemporaryOutput { get; set; }

		[Required]
		public string RuntimeIdentifier { get; set; }

		/// <summary>
		/// Runs the target passed in computeValueTarget and returns its result.
		/// The target must write the result into a text file using $(OutputFilePath) as path.
		/// </summary>
		/// <returns></returns>
		protected string ComputeValueUsingTarget (string computeValueTarget, string targetName)
		{
			var projectDirectory = Path.GetTempFileName ();
			File.Delete (projectDirectory);
			Directory.CreateDirectory (projectDirectory);
			var projectPath = Path.Combine (projectDirectory, targetName + ".csproj");

			var csproj = $@"<?xml version=""1.0"" encoding=""utf-8""?>
<Project Sdk=""Microsoft.NET.Sdk"">
	<PropertyGroup>
		<TargetFramework>net{TargetFramework.Version}-{PlatformName}</TargetFramework>
	</PropertyGroup>
	{computeValueTarget}
</Project>
";
			File.WriteAllText (projectPath, csproj);

			var dotnetPath = Environment.GetEnvironmentVariable ("DOTNET_HOST_PATH");

			if (string.IsNullOrEmpty (dotnetPath)) {
				dotnetPath = "dotnet";
			}

			var environment = default (Dictionary<string, string>);
			var customHome = Environment.GetEnvironmentVariable ("DOTNET_CUSTOM_HOME");

			if (!string.IsNullOrEmpty (customHome)) {
				environment = new Dictionary<string, string> { { "HOME", customHome } };
			}

			try {
				ExecuteRestoreAsync (dotnetPath, projectPath, targetName, environment).Wait ();

				return ExecuteBuildAsync (dotnetPath, projectPath, targetName, environment).Result;
			} finally {
				if (KeepTemporaryOutput) {
					Log.LogMessage (MessageImportance.Normal, $"Temporary project directory for the {targetName} task: {projectDirectory}");
				} else {
					Directory.Delete (projectDirectory, true);
				}
			}
		}

		async Threading.Task ExecuteRestoreAsync (string dotnetPath, string projectPath, string targetName, Dictionary<string, string> environment)
		{
			var projectDirectory = Path.GetDirectoryName (projectPath);
			var binlog = Path.Combine (projectDirectory, targetName + ".binlog");
			var arguments = new List<string> ();

			arguments.Add ("restore");

			var dotnetDir = Path.GetDirectoryName (dotnetPath);
			var configFile = Path.Combine (dotnetDir, "NuGet.config");

			if (File.Exists (configFile)) {
				arguments.Add ("/p:RestoreConfigFile=" + configFile);
			}

			arguments.Add ("/bl:" + binlog);
			arguments.Add (projectPath);

			try {
				await ExecuteAsync (dotnetPath, arguments, environment: environment);
			} finally {
				if (KeepTemporaryOutput) {
					Log.LogMessage (MessageImportance.Normal, $"Temporary restore log for the {targetName} task: {binlog}");
				} else {
					File.Delete (binlog);
				}
			}
		}

		async Threading.Task<string> ExecuteBuildAsync (string dotnetPath, string projectPath, string targetName, Dictionary<string, string> environment)
		{
			var projectDirectory = Path.GetDirectoryName (projectPath);
			var outputFile = Path.Combine (projectDirectory, "Output.txt");
			var binlog = Path.Combine (projectDirectory, targetName + ".binlog");
			var arguments = new List<string> ();

			arguments.Add ("build");
			arguments.Add ("/p:OutputFilePath=" + outputFile);
			arguments.Add ("/p:RuntimeIdentifier=" + RuntimeIdentifier);
			arguments.Add ($"/t:{targetName}");
			arguments.Add ("/bl:" + binlog);
			arguments.Add (projectPath);

			await ExecuteAsync (dotnetPath, arguments, environment: environment);

			return File.ReadAllText (outputFile).Trim ();
		}
	}
}

