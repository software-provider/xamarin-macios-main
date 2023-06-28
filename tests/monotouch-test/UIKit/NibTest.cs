//
// UINib Unit Tests
//
// Authors:
//	Sebastien Pouliot  <sebastien@xamarin.com>
//
// Copyright 2012 Xamarin Inc. All rights reserved.
//

#if !__WATCHOS__ && !MONOMAC

using System;

using Foundation;
using UIKit;
using ObjCRuntime;

using NUnit.Framework;

namespace MonoTouchFixtures.UIKit {

	[TestFixture]
	[Preserve (AllMembers = true)]
	public class NibTest {

		[Test]
		public void FromName_DoesNotExists ()
		{
			using (UINib n = UINib.FromName ("does-not-exists", null)) {
				// note: it's not really loaded until `instantiateWithOwner:options:` is called
				// so the result is not null
				Assert.NotNull (n, "created with null options");
			}
		}

#if false // Disabling for now due to Xcode 9 does not support nibs if deployment target == 6.0
		[Test]
		public void FromName ()
		{
			using (UINib n = UINib.FromName ("EmptyNib", null)) {
				Assert.NotNull (n, "created with null options");
				// newer version (same selector)
				var result2 = n.Instantiate (null, null);
				Assert.That (result2.Length, Is.EqualTo (0), "Instantiate");
			}
		}

		[Test]
		public void FromData ()
		{
			using (NSData data = NSData.FromFile ("EmptyNib.nib"))
			using (UINib n = UINib.FromData (data, null)) {
				Assert.NotNull (n, "created with null options");
				// newer version (same selector)
				var result2 = n.Instantiate (null, null);
				Assert.That (result2.Length, Is.EqualTo (0), "Instantiate");
			}
		}
#endif
	}
}

#endif // !__WATCHOS__
