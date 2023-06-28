//
// Unit tests for SSReadingList
//
// Authors:
//	Sebastien Pouliot <sebastien@xamarin.com>
//
// Copyright 2013 Xamarin Inc. All rights reserved.
//

#if !__TVOS__ && !__WATCHOS__ && !MONOMAC

using System;
using System.IO;
using Foundation;
using SafariServices;
using UIKit;
using ObjCRuntime;
using NUnit.Framework;
using Xamarin.Utils;

namespace MonoTouchFixtures.SafariServices {

	[TestFixture]
	[Preserve (AllMembers = true)]
	public class ReadingListTest {

		string local_file = Path.Combine (NSBundle.MainBundle.ResourcePath, "Hand.wav");

		[Test]
		[Ignore ("This test adds two entries every time it's executed to the global reading list in Safari. For people who use their reading lists this becomes slightly annoying.")]
		public void DefaultReadingList ()
		{
			TestRuntime.AssertSystemVersion (ApplePlatform.iOS, 7, 0, throwIfOtherPlatform: false);

			NSError error;
			using (var http = new NSUrl ("http://www.xamarin.com"))
			using (var local = new NSUrl (local_file, false))
			using (var rl = SSReadingList.DefaultReadingList) {
				Assert.True (rl.Add (http, "title", "preview text", out error), "Add-1");
				Assert.Null (error, "error-1");

				Assert.True (rl.Add (http, null, null, out error), "Add-2");
				Assert.Null (error, "error-2");

				Assert.False (rl.Add (local, null, null, out error), "Add-3");
#if NET
				Assert.That (error.Domain, Is.EqualTo ((string) SSReadingListError.UrlSchemeNotAllowed.GetDomain ()), "Domain");
#else
				Assert.That (error.Domain, Is.EqualTo ((string) SSReadingList.ErrorDomain), "Domain");
#endif
				Assert.That (error.Code, Is.EqualTo ((nint) (int) SSReadingListError.UrlSchemeNotAllowed), "Code");

				try {
					throw new NSErrorException (error);
				} catch (NSErrorException ns) {
					Assert.That (ns.Error.Code, Is.EqualTo (error.Code), "Code");
					Assert.That (ns.Error.Domain, Is.EqualTo (error.Domain), "Domain");
					Assert.That (ns.Message, Is.EqualTo (error.Description), "Message");
				} catch (Exception e) {
					Assert.Fail (e.ToString ());
				}
			}
		}

		[Test]
		public void SupportsUrl ()
		{
			TestRuntime.AssertSystemVersion (ApplePlatform.iOS, 7, 0, throwIfOtherPlatform: false);

			Assert.False (SSReadingList.SupportsUrl (null), "null");

			using (var http = new NSUrl ("http://www.xamarin.com"))
				Assert.True (SSReadingList.SupportsUrl (http), "http");

			using (var local = new NSUrl (local_file, false))
				Assert.False (SSReadingList.SupportsUrl (local), "local");
		}
	}
}

#endif // !__TVOS__ && !__WATCHOS__
