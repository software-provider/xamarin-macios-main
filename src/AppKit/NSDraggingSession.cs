#if !__MACCATALYST__
using System;
using System.Runtime.InteropServices;

using CoreGraphics;
using Foundation;
using ObjCRuntime;

#nullable enable

namespace AppKit {
	public partial class NSDraggingSession {
#if NET
		public void EnumerateDraggingItems (NSDraggingItemEnumerationOptions enumOpts, NSView view, INSPasteboardReading [] classArray, NSDictionary searchOptions, NSDraggingEnumerator enumerator)
#else
		public void EnumerateDraggingItems (NSDraggingItemEnumerationOptions enumOpts, NSView view, NSPasteboardReading [] classArray, NSDictionary searchOptions, NSDraggingEnumerator enumerator)
#endif
		{
			var nsa_classArray = NSArray.FromNSObjects (classArray);
			EnumerateDraggingItems (enumOpts, view, nsa_classArray.Handle, searchOptions, enumerator);
			nsa_classArray.Dispose ();
		}

		public void EnumerateDraggingItems (NSDraggingItemEnumerationOptions enumOpts, NSView view, NSArray classArray, NSDictionary searchOptions, NSDraggingEnumerator enumerator)
		{
			EnumerateDraggingItems (enumOpts, view, classArray.Handle, searchOptions, enumerator);
		}
	}
}
#endif // !__MACCATALYST__
