// Copyright 2016 Xamarin Inc. All rights reserved

#if !__TVOS__ && !__WATCHOS__ && !MONOMAC

using System;
using System.Drawing;
using System.IO;
using Foundation;
using MediaPlayer;
using ObjCRuntime;
using UIKit;
using NUnit.Framework;
using Xamarin.Utils;

namespace MonoTouchFixtures.MediaPlayer {

	[TestFixture]
	[Preserve (AllMembers = true)]
	public class NowPlayingInfoCenterTest {
		MPNowPlayingInfo NowPlayingInfo;

		bool v8_0 = TestRuntime.CheckSystemVersion (ApplePlatform.iOS, 8, 0);
		bool v9_0 = TestRuntime.CheckSystemVersion (ApplePlatform.iOS, 9, 0);
		bool v10_0 = TestRuntime.CheckSystemVersion (ApplePlatform.iOS, 10, 0);
		bool v10_3 = TestRuntime.CheckSystemVersion (ApplePlatform.iOS, 10, 3);

		[SetUp]
		public void SetUp ()
		{
			MPNowPlayingInfoLanguageOption languageOption = null;
			MPNowPlayingInfoLanguageOptionGroup languageOptionGroup = null;
			if (v9_0) {
				languageOption = new MPNowPlayingInfoLanguageOption (MPNowPlayingInfoLanguageOptionType.Audible, "en", null, "English", "en");
				languageOptionGroup = new MPNowPlayingInfoLanguageOptionGroup (new MPNowPlayingInfoLanguageOption [] { languageOption }, languageOption, false);
			}
			string file = Path.Combine (NSBundle.MainBundle.ResourcePath, "basn3p08.png");
			using (var img = UIImage.FromFile (file)) {
				NowPlayingInfo = new MPNowPlayingInfo {
					//MPNowPlayingInfoCenter
					ElapsedPlaybackTime = 1.0,
					PlaybackRate = 1.0,
					DefaultPlaybackRate = 1.0,
					PlaybackQueueIndex = 0,
					PlaybackQueueCount = 10,
					ChapterNumber = 1,
					ChapterCount = 10,
					AvailableLanguageOptions = v9_0 ? new MPNowPlayingInfoLanguageOptionGroup [] { languageOptionGroup } : null,
					CurrentLanguageOptions = v9_0 ? new MPNowPlayingInfoLanguageOption [] { new MPNowPlayingInfoLanguageOption (MPNowPlayingInfoLanguageOptionType.Audible, "en", null, "English", "en") } : null,
					CollectionIdentifier = "Collection",
					ExternalContentIdentifier = "ExternalContent",
					ExternalUserProfileIdentifier = "ExternalUserProfile",
					PlaybackProgress = 0.5f,
					MediaType = MPNowPlayingInfoMediaType.Audio,
					IsLiveStream = false,
					AssetUrl = new NSUrl ("https://developer.xamarin.com"),

					//MPMediaItem
					AlbumTitle = "AlbumTitle",
					AlbumTrackCount = 13,
					AlbumTrackNumber = 1,
					Artist = "Artist",
					Artwork = new MPMediaItemArtwork (img),
					Composer = "Composer",
					DiscCount = 1,
					DiscNumber = 1,
					Genre = "Genre",
					PersistentID = 1,
					PlaybackDuration = 100.0,
					Title = "Title",
				};
			}
		}

		[Test]
		public void NowPlaying ()
		{
			using (var dc = MPNowPlayingInfoCenter.DefaultCenter) {
				dc.NowPlaying = NowPlayingInfo; // internal NSDictionary ToDictionary ()
				var np = dc.NowPlaying; // internal MPNowPlayingInfo (NSDictionary source)

				Assert.IsInstanceOf (typeof (double), np.ElapsedPlaybackTime, "#1");
				Assert.IsInstanceOf (typeof (double), np.PlaybackRate, "#2");
				if (v8_0)
					Assert.IsInstanceOf (typeof (double), np.DefaultPlaybackRate, "#3");
				Assert.IsInstanceOf (typeof (int), np.PlaybackQueueIndex, "#4");
				Assert.IsInstanceOf (typeof (int), np.PlaybackQueueCount, "#5");
				Assert.IsInstanceOf (typeof (int), np.ChapterNumber, "#6");
				Assert.IsInstanceOf (typeof (int), np.ChapterCount, "#7");

				if (v9_0) {
					Assert.IsInstanceOf (typeof (MPNowPlayingInfoLanguageOptionGroup []), np.AvailableLanguageOptions, "#8");
					Assert.IsInstanceOf (typeof (MPNowPlayingInfoLanguageOption []), np.CurrentLanguageOptions, "#9");
				}
				if (v10_0) {
					Assert.IsInstanceOf (typeof (string), (object) np.CollectionIdentifier, "#10");
					Assert.IsInstanceOf (typeof (string), (object) np.ExternalContentIdentifier, "#11");
					Assert.IsInstanceOf (typeof (string), (object) np.ExternalUserProfileIdentifier, "#12");
					Assert.IsInstanceOf (typeof (float), np.PlaybackProgress, "#13");
					Assert.IsInstanceOf (typeof (MPNowPlayingInfoMediaType), np.MediaType, "#14");
					Assert.IsInstanceOf (typeof (bool), np.IsLiveStream, "#15");
				}

				Assert.IsInstanceOf (typeof (string), (object) np.AlbumTitle, "#16");
				Assert.IsInstanceOf (typeof (int), np.AlbumTrackCount, "#17");
				Assert.IsInstanceOf (typeof (int), np.AlbumTrackNumber, "#18");
				Assert.IsInstanceOf (typeof (string), (object) np.Artist, "#19");
				Assert.IsInstanceOf (typeof (MPMediaItemArtwork), np.Artwork, "#20");
				Assert.IsInstanceOf (typeof (string), (object) np.Composer, "#21");
				Assert.IsInstanceOf (typeof (int), np.DiscCount, "#22");
				Assert.IsInstanceOf (typeof (int), np.DiscNumber, "#23");
				Assert.IsInstanceOf (typeof (string), (object) np.Genre, "#24");
				Assert.IsInstanceOf (typeof (ulong), np.PersistentID, "#25");
				Assert.IsInstanceOf (typeof (double), np.PlaybackDuration, "#26");
				Assert.IsInstanceOf (typeof (string), (object) np.Title, "#27");

				if (v10_3)
					Assert.IsInstanceOf (typeof (NSUrl), np.AssetUrl, "#28");
			}
		}
	}
}

#endif // !__TVOS__ && !__WATCHOS__
