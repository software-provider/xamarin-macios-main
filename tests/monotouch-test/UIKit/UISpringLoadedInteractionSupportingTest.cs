//
// Unit tests for UISpringLoadedInteractionSupportingTest
//
// Authors:
//	Vincent Dondain <vidondai@microsoft.com>
//
//
// Copyright 2017 Microsoft.
//

#if !__TVOS__ && !__WATCHOS__ && !MONOMAC

using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
#if HAS_INTENTUI
using IntentsUI;
#endif
using NUnit.Framework;

namespace MonoTouchFixtures.UIKit {
	[TestFixture]
	[Preserve (AllMembers = true)]
	public class UISpringLoadedInteractionSupportingTest {

		[SetUp]
		public void Setup ()
		{
			TestRuntime.AssertXcodeVersion (9, 0);
		}

		[Test]
		public void UIAlertControllerSpringLoadTest ()
		{
			var alertController = new UIAlertController ();
			alertController.SpringLoaded = true;
			Assert.IsTrue (alertController.SpringLoaded);
		}

		[Test]
		public void UIBarButtonItemSpringLoadTest ()
		{
			var barButtonItem = new UIBarButtonItem ();
			barButtonItem.SpringLoaded = true;
			Assert.IsTrue (barButtonItem.SpringLoaded);
		}

		[Test]
		public void UIButtonSpringLoadTest ()
		{
			var button = new UIButton ();
			button.SpringLoaded = true;
			Assert.IsTrue (button.SpringLoaded);
		}

		[Test]
		public void UICollectionViewSpringLoadTest ()
		{
			var collectionView = new UICollectionView (new CGRect (0, 0, 100, 100), new UICollectionViewLayout ());
			collectionView.SpringLoaded = true;
			Assert.IsTrue (collectionView.SpringLoaded);
		}

		[Test]
		public void UISegmentedControlSpringLoadTest ()
		{
			var segmentedControl = new UISegmentedControl ();
			segmentedControl.SpringLoaded = true;
			Assert.IsTrue (segmentedControl.SpringLoaded);
		}

		[Test]
		public void UITabBarItemSpringLoadTest ()
		{
			var tabBarItem = new UITabBarItem ();
			tabBarItem.SpringLoaded = true;
			Assert.IsTrue (tabBarItem.SpringLoaded);
		}

		[Test]
		public void UITabBarSpringLoadTest ()
		{
			var tabBar = new UITabBar ();
			tabBar.SpringLoaded = true;
			Assert.IsTrue (tabBar.SpringLoaded);
		}

		[Test]
		public void UITableViewSpringLoadTest ()
		{
			var tableView = new UITableView ();
			tableView.SpringLoaded = true;
			Assert.IsTrue (tableView.SpringLoaded);
		}

#if HAS_INTENTUI
		[Test]
		public void INUIAddVoiceShortcutButtonTest ()
		{
			TestRuntime.AssertXcodeVersion (10, 0);
			TestRuntime.AssertDevice ();
			var shortcutButton = new INUIAddVoiceShortcutButton (INUIAddVoiceShortcutButtonStyle.Black);
			shortcutButton.SpringLoaded = true;
			Assert.IsTrue (shortcutButton.SpringLoaded);
		}
#endif
	}
}

#endif // !__TVOS__ && !__WATCHOS__
