using System;
using System.IO;
using System.Linq;
using Microsoft.Build.Framework;
using Xamarin.Localization.MSBuild;

namespace Xamarin.MacDev.Tasks {
	public abstract class FindAotCompilerTaskBase : XamarinBuildTask {
		[Required]
		public ITaskItem [] MonoAotCrossCompiler { get; set; }

		[Output]
		public string AotCompiler { get; set; }

		public override bool Execute ()
		{
			// If we can't find the AOT compiler path in MonoAotCrossCompiler, evaluate a project file that does know how to find it.
			// This happens when executing remotely from Windows, because the MonoAotCrossCompiler item group will be empty in that case.
			var targetName = "ComputeAotCompilerPath";
			var target = $@"<Target Name=""{targetName}"">
	<PropertyGroup>
		<_XamarinAOTCompiler>@(MonoAotCrossCompiler->WithMetadataValue(""RuntimeIdentifier"", ""$(RuntimeIdentifier)""))</_XamarinAOTCompiler>
	</PropertyGroup>
	<WriteLinesToFile File=""$(OutputFilePath)"" Lines=""$(_XamarinAOTCompiler)"" />
</Target>";

			if (MonoAotCrossCompiler?.Length > 0 && string.IsNullOrEmpty (Environment.GetEnvironmentVariable ("XAMARIN_FORCE_AOT_COMPILER_PATH_COMPUTATION"))) {
				var aotCompilerItem = MonoAotCrossCompiler.SingleOrDefault (v => v.GetMetadata ("RuntimeIdentifier") == RuntimeIdentifier);

				if (aotCompilerItem is null) {
					Log.LogMessage (MessageImportance.Low, "Unable to find the AOT compiler for the RuntimeIdentifier '{0}' in the MonoAotCrossCompiler item group", RuntimeIdentifier);
					AotCompiler = ComputeValueUsingTarget (target, targetName);
				} else {
					AotCompiler = aotCompilerItem.ItemSpec;
				}
			} else {
				AotCompiler = ComputeValueUsingTarget (target, targetName);
			}

			if (!File.Exists (AotCompiler))
				Log.LogError (MSBStrings.E7081 /*"The AOT compiler '{0}' does not exist." */, AotCompiler);

			return !Log.HasLoggedErrors;
		}
	}
}

