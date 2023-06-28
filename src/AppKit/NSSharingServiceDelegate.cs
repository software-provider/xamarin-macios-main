#if !__MACCATALYST__
using System;
using System.Runtime.InteropServices;

using CoreGraphics;
using Foundation;
using ObjCRuntime;

#nullable enable

namespace AppKit {
#if !NET
	public partial class NSSharingServiceDelegate {
		CGRect SourceFrameOnScreenForShareItem (NSSharingService sharingService, NSPasteboardWriting item)
		{
			return SourceFrameOnScreenForShareItem (sharingService, (INSPasteboardWriting) item);
		}

		NSImage TransitionImageForShareItem (NSSharingService sharingService, NSPasteboardWriting item, CGRect contentRect)
		{
			return TransitionImageForShareItem (sharingService, (INSPasteboardWriting) item, contentRect);
		}
	}
#endif
}
#endif // !__MACCATALYST__
