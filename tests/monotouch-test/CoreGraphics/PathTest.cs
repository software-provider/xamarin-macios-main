//
// Unit tests for CGPath
//
// Authors:
//	Sebastien Pouliot <sebastien@xamarin.com>
//
// Copyright 2013-2014 Xamarin Inc. All rights reserved.
//

using System;
using System.Runtime.InteropServices;
using Foundation;
using CoreGraphics;
using ObjCRuntime;
using NUnit.Framework;

namespace MonoTouchFixtures.CoreGraphics {

	[TestFixture]
	[Preserve (AllMembers = true)]
	public class PathTest {

		[DllImport (Constants.CoreFoundationLibrary)]
		extern static nint CFGetRetainCount (IntPtr handle);

		[Test]
		public void EllipseFromRect ()
		{
			var rect = new CGRect (0, 0, 15, 15);
			var matrix = CGAffineTransform.MakeIdentity ();
			using (CGPath p = CGPath.EllipseFromRect (rect, matrix)) {
				Assert.IsNotNull (p, "non-null");
			}
		}

		[Test]
		public void CopyByDashingPath_18764 ()
		{
			var identity = CGAffineTransform.MakeIdentity ();
			using (var path = CGPath.EllipseFromRect (CGRect.Empty, identity)) {
				var lengths = new nfloat [] { 10, 10 };
				var phase = 2;
				using (var d1 = path.CopyByDashingPath (lengths)) {
					Assert.That (d1.Handle, Is.Not.EqualTo (IntPtr.Zero), "d1");
				}
				using (var d2 = path.CopyByDashingPath (lengths, phase)) {
					Assert.That (d2.Handle, Is.Not.EqualTo (IntPtr.Zero), "d2");
				}
				using (var d3 = path.CopyByDashingPath (identity, lengths)) {
					Assert.That (d3.Handle, Is.Not.EqualTo (IntPtr.Zero), "d3");
				}
				using (var d4 = path.CopyByDashingPath (identity, lengths, phase)) {
					Assert.That (d4.Handle, Is.Not.EqualTo (IntPtr.Zero), "d4");
				}
			}
		}

		[Test]
		public void MoveToPoint ()
		{
			var matrix = CGAffineTransform.MakeIdentity ();
			using (CGPath p1 = new CGPath ())
			using (CGPath p2 = new CGPath ()) {
				Assert.IsTrue (p1.IsEmpty, "IsEmpty-1");
				p1.MoveToPoint (0, 0);
				p2.MoveToPoint (matrix, 0, 0);
				Assert.IsFalse (p1.IsEmpty, "IsEmpty-2");
				Assert.That (p1, Is.EqualTo (p2), "CGPathEqualToPath");
			}
		}

		[Test]
		public void AddLineToPoint ()
		{
			var matrix = CGAffineTransform.MakeIdentity ();
			using (CGPath p1 = new CGPath ())
			using (CGPath p2 = new CGPath ()) {
				Assert.IsTrue (p1.IsEmpty, "IsEmpty-1");
				p1.MoveToPoint (0, 0);
				p1.AddLineToPoint (1, 1);
				p2.MoveToPoint (matrix, 0, 0);
				p2.AddLineToPoint (matrix, 1, 1);
				Assert.IsFalse (p1.IsEmpty, "IsEmpty-2");
				Assert.That (p1, Is.EqualTo (p2), "CGPathEqualToPath");
			}
		}

		[Test]
		public void AddCurveToPoint ()
		{
			var matrix = CGAffineTransform.MakeIdentity ();
			using (CGPath p1 = new CGPath ())
			using (CGPath p2 = new CGPath ()) {
				Assert.IsTrue (p1.IsEmpty, "IsEmpty-1");
				p1.MoveToPoint (0, 0);
				p1.AddCurveToPoint (1, 2, 3, 4, 5, 6);
				p2.MoveToPoint (0, 0);
				p2.AddCurveToPoint (matrix, 1, 2, 3, 4, 5, 6);
				Assert.IsFalse (p1.IsEmpty, "IsEmpty-2");
				Assert.That (p1, Is.EqualTo (p2), "CGPathEqualToPath");
			}
		}

		[Test]
		public void AddQuadCurveToPoint ()
		{
			var matrix = CGAffineTransform.MakeIdentity ();
			using (CGPath p1 = new CGPath ())
			using (CGPath p2 = new CGPath ()) {
				Assert.IsTrue (p1.IsEmpty, "IsEmpty-1");
				p1.MoveToPoint (0, 0);
				p1.AddQuadCurveToPoint (1, 2, 3, 4);
				p1.CloseSubpath ();
				p2.MoveToPoint (0, 0);
				p2.AddQuadCurveToPoint (matrix, 1, 2, 3, 4);
				Assert.IsFalse (p1.IsEmpty, "IsEmpty-2");
				Assert.That (p1, Is.Not.EqualTo (p2), "CGPathEqualToPath-2");
				p2.CloseSubpath ();
				Assert.That (p1, Is.EqualTo (p2), "CGPathEqualToPath");
			}
		}

		[Test]
		public void AddRect ()
		{
			var rect = new CGRect (0, 0, 15, 15);
			var matrix = CGAffineTransform.MakeIdentity ();
			using (CGPath p1 = new CGPath ())
			using (CGPath p2 = new CGPath ()) {
				Assert.IsTrue (p1.IsEmpty, "IsEmpty-1");
				p1.AddRect (rect);
				p2.AddRect (matrix, rect);
				Assert.IsFalse (p1.IsEmpty, "IsEmpty-2");
				Assert.That (p1, Is.EqualTo (p2), "CGPathEqualToPath");
			}
		}

		[Test]
		public void AddRects ()
		{
			var rect = new CGRect (0, 0, 15, 15);
			var matrix = CGAffineTransform.MakeIdentity ();
			using (CGPath p1 = new CGPath ())
			using (CGPath p2 = new CGPath ()) {
				Assert.IsTrue (p1.IsEmpty, "IsEmpty-1");
				p1.AddRects (new [] { rect, rect }, 1);
				p2.AddRects (matrix, new [] { rect }, 1);
				Assert.IsFalse (p1.IsEmpty, "IsEmpty-2");
				Assert.That (p1, Is.EqualTo (p2), "CGPathEqualToPath");
			}
		}

		[Test]
		public void AddLines ()
		{
			var matrix = CGAffineTransform.MakeIdentity ();
			using (CGPath p1 = new CGPath ())
			using (CGPath p2 = new CGPath ()) {
				Assert.IsTrue (p1.IsEmpty, "IsEmpty-1");
				p1.AddLines (new [] { CGPoint.Empty });
				p2.AddLines (matrix, new [] { CGPoint.Empty });
				Assert.IsFalse (p1.IsEmpty, "IsEmpty-2");
				Assert.That (p1, Is.EqualTo (p2), "CGPathEqualToPath");
			}
		}

		[Test]
		public void AddEllipseInRect ()
		{
			var rect = new CGRect (0, 0, 15, 15);
			var matrix = CGAffineTransform.MakeIdentity ();
			using (CGPath p1 = new CGPath ())
			using (CGPath p2 = new CGPath ()) {
				Assert.IsTrue (p1.IsEmpty, "IsEmpty-1");
				p1.AddEllipseInRect (rect);
				p2.AddEllipseInRect (matrix, rect);
				Assert.IsFalse (p1.IsEmpty, "IsEmpty-2");
				Assert.That (p1, Is.EqualTo (p2), "CGPathEqualToPath");
			}
		}

		[Test]
		public void AddArc ()
		{
			var matrix = CGAffineTransform.MakeIdentity ();
			using (CGPath p1 = new CGPath ())
			using (CGPath p2 = new CGPath ()) {
				Assert.IsTrue (p1.IsEmpty, "IsEmpty-1");
				p1.AddArc (0, 0, 10, 0, 90, true);
				p2.AddArc (matrix, 0, 0, 10, 0, 90, true);
				Assert.IsFalse (p1.IsEmpty, "IsEmpty-2");
				Assert.That (p1, Is.EqualTo (p2), "CGPathEqualToPath");
			}
		}

		[Test]
		public void AddArcToPoint ()
		{
			var matrix = CGAffineTransform.MakeIdentity ();
			using (CGPath p1 = new CGPath ())
			using (CGPath p2 = new CGPath ()) {
				Assert.IsTrue (p1.IsEmpty, "IsEmpty-1");
				p1.MoveToPoint (0, 0);
				p1.AddArcToPoint (0, 0, 10, 0, 90);
				p2.MoveToPoint (0, 0);
				p2.AddArcToPoint (matrix, 0, 0, 10, 0, 90);
				Assert.IsFalse (p1.IsEmpty, "IsEmpty-2");
				Assert.That (p1, Is.EqualTo (p2), "CGPathEqualToPath");
			}
		}

		[Test]
		public void AddRelativeArc ()
		{
			var matrix = CGAffineTransform.MakeIdentity ();
			using (CGPath p1 = new CGPath ())
			using (CGPath p2 = new CGPath ()) {
				Assert.IsTrue (p1.IsEmpty, "IsEmpty-1");
				p1.MoveToPoint (0, 0);
				p1.AddRelativeArc (0, 0, 10, 0, 90);
				p2.MoveToPoint (0, 0);
				p2.AddRelativeArc (matrix, 0, 0, 10, 0, 90);
				Assert.IsFalse (p1.IsEmpty, "IsEmpty-2");
				Assert.That (p1, Is.EqualTo (p2), "CGPathEqualToPath");
			}
		}

		[Test]
		public void AddPath ()
		{
			using (CGPath p1 = new CGPath ())
			using (CGPath p2 = new CGPath ()) {
				p1.MoveToPoint (0, 0);
				p2.AddPath (p1);
				Assert.IsFalse (p2.IsEmpty, "IsEmpty");
			}
		}

		[Test]
		public void Normalizing ()
		{
			TestRuntime.AssertXcodeVersion (14, 0);
			using (CGPath p1 = new CGPath ()) {
				p1.MoveToPoint (0, 0);
				p1.AddLineToPoint (1, 1);
				Assert.IsNotNull (p1.CreateByNormalizing (false));
				Assert.IsNotNull (p1.CreateByNormalizing (true));
			}
		}

		[Test]
		public void Union ()
		{
			TestRuntime.AssertXcodeVersion (14, 0);
			using (CGPath p1 = new CGPath ()) {
				p1.MoveToPoint (0, 0);
				p1.AddLineToPoint (1, 1);
				using (CGPath p2 = new CGPath ()) {
					p2.MoveToPoint (2, 2);
					p2.AddLineToPoint (0, 0);
					Assert.IsNotNull (p1.CreateByUnioningPath (p2, false));
					Assert.IsNotNull (p1.CreateByUnioningPath (p2, true));
				}
			}
		}

		[Test]
		public void Intersecting ()
		{
			TestRuntime.AssertXcodeVersion (14, 0);
			using (CGPath p1 = new CGPath ()) {
				p1.MoveToPoint (0, 0);
				p1.AddLineToPoint (1, 1);
				using (CGPath p2 = new CGPath ()) {
					p2.MoveToPoint (2, 2);
					p2.AddLineToPoint (0, 0);
					Assert.IsNotNull (p1.CreateByIntersectingPath (p2, false));
					Assert.IsNotNull (p1.CreateByIntersectingPath (p2, true));
				}
			}
		}

		[Test]
		public void Subtracting ()
		{
			TestRuntime.AssertXcodeVersion (14, 0);
			using (CGPath p1 = new CGPath ()) {
				p1.MoveToPoint (0, 0);
				p1.AddLineToPoint (1, 1);
				using (CGPath p2 = new CGPath ()) {
					p2.MoveToPoint (2, 2);
					p2.AddLineToPoint (0, 0);
					Assert.IsNotNull (p1.CreateBySubtractingPath (p2, false));
					Assert.IsNotNull (p1.CreateBySubtractingPath (p2, true));
				}
			}
		}

		[Test]
		public void SymmetricDifference ()
		{
			TestRuntime.AssertXcodeVersion (14, 0);
			using (CGPath p1 = new CGPath ()) {
				p1.MoveToPoint (0, 0);
				p1.AddLineToPoint (1, 1);
				using (CGPath p2 = new CGPath ()) {
					p2.MoveToPoint (2, 2);
					p2.AddLineToPoint (0, 0);
					Assert.IsNotNull (p1.CreateBySymmetricDifferenceOfPath (p2, false));
					Assert.IsNotNull (p1.CreateBySymmetricDifferenceOfPath (p2, true));
				}
			}
		}

		[Test]
		public void LineBySubtracting ()
		{
			TestRuntime.AssertXcodeVersion (14, 0);
			using (CGPath p1 = new CGPath ()) {
				p1.MoveToPoint (0, 0);
				p1.AddLineToPoint (1, 1);
				using (CGPath p2 = new CGPath ()) {
					p2.MoveToPoint (2, 2);
					p2.AddLineToPoint (0, 0);
					Assert.IsNotNull (p1.CreateLineBySubtractingPath (p2, false));
					Assert.IsNotNull (p1.CreateLineBySubtractingPath (p2, true));
				}
			}
		}

		[Test]
		public void LineByIntersecting ()
		{
			TestRuntime.AssertXcodeVersion (14, 0);
			using (CGPath p1 = new CGPath ()) {
				p1.MoveToPoint (0, 0);
				p1.AddLineToPoint (1, 1);
				using (CGPath p2 = new CGPath ()) {
					p2.MoveToPoint (2, 2);
					p2.AddLineToPoint (0, 0);
					Assert.IsNotNull (p1.CreateLineByIntersectingPath (p2, false));
					Assert.IsNotNull (p1.CreateLineByIntersectingPath (p2, true));
				}
			}
		}

		[Test]
		public void GetSeparateComponents ()
		{
			TestRuntime.AssertXcodeVersion (14, 0);
			using (CGPath p1 = new CGPath ()) {
				p1.MoveToPoint (0, 0);
				p1.AddLineToPoint (1, 1);
				Assert.AreEqual (0, p1.GetSeparateComponents (true).Length);
				Assert.AreEqual (0, p1.GetSeparateComponents (false).Length);
			}
		}

		[Test]
		public void CreateByFlattening ()
		{
			TestRuntime.AssertXcodeVersion (14, 0);
			using (CGPath p1 = new CGPath ()) {
				p1.MoveToPoint (0, 0);
				p1.AddLineToPoint (1, 1);
				Assert.IsNotNull (p1.CreateByFlattening (new nfloat (0.5)));
			}
		}

		[Test]
		public void DoesIntersect ()
		{
			TestRuntime.AssertXcodeVersion (14, 0);
			using (CGPath p1 = new CGPath ()) {
				p1.MoveToPoint (0, 0);
				p1.AddLineToPoint (2, 2);
				using (CGPath p2 = new CGPath ()) {
					p2.MoveToPoint (0, 2);
					p2.AddLineToPoint (2, 0);
					Assert.IsFalse (p1.DoesIntersect (p2, false));
					Assert.IsFalse (p1.DoesIntersect (p2, false));
				}
			}
		}

		[Test]
		public void Bug40230 ()
		{
			var rect = new CGRect (1, 1, 25, 25);
			// Assertion failed: (corner_width >= 0 && 2 * corner_width <= CGRectGetWidth(rect)), function CGPathCreateWithRoundedRect
			Assert.Throws<ArgumentException> (() => CGPath.FromRoundedRect (rect, 13.5f, 1), "width");
			// Assertion failed: (corner_height >= 0 && 2 * corner_height <= CGRectGetHeight(rect)), function CGPathRef CGPathCreateWithRoundedRect
			Assert.Throws<ArgumentException> (() => CGPath.FromRoundedRect (rect, 1, 13.5f), "height");
			using (var path = CGPath.FromRoundedRect (rect, 1, 1)) {
				Assert.IsNotNull (path, "path");
			}
		}

		[Test]
		public void IncreaseRetainCountMakeMutable ()
		{
			// ensure that we do not crash and that the retain count is changed.
			using (CGPath p1 = new CGPath ()) {
				var count = CFGetRetainCount (p1.Handle);
				using (var copy = p1.Copy ()) {
					var newRetainCount = CFGetRetainCount (copy.Handle);
					Assert.AreEqual (count, newRetainCount, "Ref count should not have changed.");
					Assert.AreEqual ((nint) 1, count, "Original count.");
					Assert.AreEqual ((nint) 1, newRetainCount, "New count");
				}
			}
		}
	}
}
