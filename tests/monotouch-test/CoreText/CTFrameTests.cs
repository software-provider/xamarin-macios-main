//
// Unit tests for CTFrame
//
// Authors:
//	Rolf Bjarne Kvinge <rolf@xamarin.com>
//
// Copyright 2012 Xamarin Inc. All rights reserved.
//

using System;
using Foundation;
using CoreText;
using CoreGraphics;
using ObjCRuntime;
using NUnit.Framework;

namespace MonoTouchFixtures.CoreText {

	[TestFixture]
	[Preserve (AllMembers = true)]
	public class CTFrameTests {

		[Test] // #4677
		public void GetPathTest ()
		{
			using (var framesetter = new CTFramesetter (new NSAttributedString ("Testing, testing, 1, 2, 3..."))) {
				using (var frame = framesetter.GetFrame (new NSRange (0, 0), new CGPath (), null)) {
					using (var f = frame.GetPath ()) {
					}
					using (var f = frame.GetPath ()) {
						Console.WriteLine (f.BoundingBox);
					}
				}
			}
		}

		[Test]
		public void CTTypesetterCreateTest ()
		{
			TestRuntime.AssertXcodeVersion (10, 0);
			using (var framesetter = new CTFramesetter (new NSAttributedString ("Testing, testing, 1, 2, 3...")))
			using (var type = framesetter.GetTypesetter ())
			using (var newFrame = CTFramesetter.Create (type)) {
				Assert.NotNull (type, "Create");
				var type2 = newFrame.GetTypesetter ();
				Assert.NotNull (type, "type2");
				Assert.AreEqual (type.Handle, type2.Handle, "Same typesetter");
			}
		}
	}
}
