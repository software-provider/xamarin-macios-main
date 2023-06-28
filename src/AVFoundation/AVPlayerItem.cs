#if !WATCH

using System;

using Foundation;
using ObjCRuntime;

#nullable enable

namespace AVFoundation {
	public partial class AVPlayerItem {

#if NET
		[SupportedOSPlatform ("tvos11.0")]
		[SupportedOSPlatform ("macos")]
		[SupportedOSPlatform ("ios11.0")]
		[SupportedOSPlatform ("maccatalyst")]
#else
		[TV (11, 0)]
		[NoWatch]
		[Mac (10, 13)]
		[iOS (11, 0)]
#endif
		public AVVideoApertureMode VideoApertureMode {
			get { return AVVideoApertureModeExtensions.GetValue (_VideoApertureMode); }
			set {
				var val = value.GetConstant ();
				if (val is not null)
					_VideoApertureMode = val;
			}
		}
	}
}

#endif
