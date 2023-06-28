using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Messaging.Build.Client;

namespace Xamarin.iOS.Tasks {
	public class PrepareObjCBindingNativeFrameworks : Task, ITaskCallback, ICancelableTask {
		public string SessionId { get; set; }

		public ITaskItem [] ObjCBindingNativeFrameworks { get; set; }

		public override bool Execute ()
		{
			try {
				//This task runs locally, and its purpose is just to copy the ObjCBindingNativeFrameworks to the build server
				new TaskRunner (SessionId, BuildEngine4).CopyInputsAsync (this).Wait ();
			} catch (Exception ex) {
				Log.LogErrorFromException (ex);

				return false;
			}

			return true;
		}

		public bool ShouldCopyToBuildServer (ITaskItem item) => true;

		public bool ShouldCreateOutputFile (ITaskItem item) => false;

		public IEnumerable<ITaskItem> GetAdditionalItemsToBeCopied ()
		{
			if (ObjCBindingNativeFrameworks is null)
				yield break;

			foreach (var nativeRef in ObjCBindingNativeFrameworks
				.Where (x => Directory.Exists (x.ItemSpec))
				.Select (x => x.ItemSpec))
				foreach (var item in GetItemsFromNativeReference (nativeRef))
					yield return item;
		}

		public void Cancel () => BuildConnection.CancelAsync (BuildEngine4).Wait ();

		IEnumerable<TaskItem> GetItemsFromNativeReference (string folderPath)
		{
			foreach (var file in Directory.EnumerateFiles (folderPath, "*", SearchOption.AllDirectories)
				.Select (x => new TaskItem (x)))
				yield return file;
		}
	}
}
