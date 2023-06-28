//
// NSButton.cs: Support for the NSButton class
//
// Author:
//   Michael Hutchinson (mhutchinson@novell.com)
//
// Copyright 2010, Novell, Inc.
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

#if !__MACCATALYST__

using System;
using ObjCRuntime;
using Foundation;

#nullable enable

namespace AppKit {

	public partial class NSButton {
		NSObject? dispatcher;

		NSObject? Dispatcher {
			set {
				dispatcher = value;
				MarkDirty ();
			}
		}

		public new NSButtonCell Cell {
			get { return (NSButtonCell) base.Cell; }
			set { base.Cell = value; }
		}

#if NET
		[SupportedOSPlatform ("macos")]
		[UnsupportedOSPlatform ("maccatalyst")]
#else
		[Mac (10, 12)]
#endif
		public static NSButton CreateButton (string title, NSImage image, Action action)
		{
			var dispatcher = new NSActionDispatcher (action);
			var control = _CreateButton (title, image, dispatcher, NSActionDispatcher.Selector);
			control.Dispatcher = dispatcher;
			return control;
		}

#if NET
		[SupportedOSPlatform ("macos")]
		[UnsupportedOSPlatform ("maccatalyst")]
#else
		[Mac (10, 12)]
#endif
		public static NSButton CreateButton (string title, Action action)
		{
			var dispatcher = new NSActionDispatcher (action);
			var control = _CreateButton (title, dispatcher, NSActionDispatcher.Selector);
			control.Dispatcher = dispatcher;
			return control;
		}

#if NET
		[SupportedOSPlatform ("macos")]
		[UnsupportedOSPlatform ("maccatalyst")]
#else
		[Mac (10, 12)]
#endif
		public static NSButton CreateButton (NSImage image, Action action)
		{
			var dispatcher = new NSActionDispatcher (action);
			var control = _CreateButton (image, dispatcher, NSActionDispatcher.Selector);
			control.Dispatcher = dispatcher;
			return control;
		}

#if NET
		[SupportedOSPlatform ("macos")]
		[UnsupportedOSPlatform ("maccatalyst")]
#else
		[Mac (10, 12)]
#endif
		public static NSButton CreateCheckbox (string title, Action action)
		{
			var dispatcher = new NSActionDispatcher (action);
			var control = _CreateCheckbox (title, dispatcher, NSActionDispatcher.Selector);
			control.Dispatcher = dispatcher;
			return control;
		}

#if NET
		[SupportedOSPlatform ("macos")]
		[UnsupportedOSPlatform ("maccatalyst")]
#else
		[Mac (10, 12)]
#endif
		public static NSButton CreateRadioButton (string title, Action action)
		{
			var dispatcher = new NSActionDispatcher (action);
			var control = _CreateRadioButton (title, dispatcher, NSActionDispatcher.Selector);
			control.Dispatcher = dispatcher;
			return control;
		}
	}
}
#endif // !__MACCATALYST__
