using System.Collections.Generic;
using Foundation;
using ObjCRuntime;
using NUnit.Framework;
using Xamarin.Utils;

namespace monotouchtest {
	[TestFixture]
	[Preserve (AllMembers = true)]
	public class NSLinguisticAnalysisTest {
		List<NSString> words;

		[SetUp]
		public void SetUp ()
		{
			words = new List<NSString> ();
		}

		public bool Enumerator (NSString tag, NSRange tokenRange, NSRange sentenceRange, ref bool stop)
		{
			words.Add (tag);
			stop = false;
			return true;
		}

		public bool StopEnumerator (NSString tag, NSRange tokenRange, NSRange sentenceRange, ref bool stop)
		{
			words.Add (tag);
			stop = true;
			return true;
		}

		[Test]
		public void EnumerateSubstringsInRangeTest ()
		{
			var testString = new NSString ("Hello Hola Bonjour!");
			var range = new NSRange (0, testString.Length - 1);
			testString.EnumerateLinguisticTags (range, NSLinguisticTagScheme.Token, NSLinguisticTaggerOptions.OmitWhitespace, null, Enumerator);
			var expectedWordCount = 3;
#if __MACOS__
			if (!TestRuntime.CheckSystemVersion (ApplePlatform.MacOSX, 10, 9))
				expectedWordCount = 4;
#endif
			Assert.AreEqual (expectedWordCount, words.Count, "Word count: " + string.Join (", ", words));
#if NET
			Assert.True (words.Contains (NSLinguisticTag.Word.GetConstant ()), "Token type.");
#else
			Assert.True (words.Contains (NSLinguisticTagUnit.Word.GetConstant ()), "Token type.");
#endif
		}

		[Test]
		public void StopEnumerateSubstringsInRangeTest ()
		{
			var testString = new NSString ("Hello Hola Bonjour!");
			var range = new NSRange (0, testString.Length - 1);
			testString.EnumerateLinguisticTags (range, NSLinguisticTagScheme.Token, NSLinguisticTaggerOptions.OmitWhitespace, null, StopEnumerator);
			Assert.AreEqual (1, words.Count, "Word count");
#if NET
			Assert.True (words.Contains (NSLinguisticTag.Word.GetConstant ()), "Token type.");
#else
			Assert.True (words.Contains (NSLinguisticTagUnit.Word.GetConstant ()), "Token type.");
#endif
		}

		[Test]
		public void GetLinguisticTagsTest ()
		{
			var testString = new NSString ("Hello Hola Bonjour!");
			var range = new NSRange (0, testString.Length - 1);
			NSValue [] tokenRanges;
			var tags = testString.GetLinguisticTags (range, NSLinguisticTagScheme.NameOrLexicalClass, NSLinguisticTaggerOptions.OmitWhitespace, null, out tokenRanges);
			var expectedWordCount = 3;
#if __MACOS__
			if (!TestRuntime.CheckSystemVersion (ApplePlatform.MacOSX, 10, 9))
				expectedWordCount = 4;
#endif
			Assert.AreEqual (expectedWordCount, tags.Length, "Tags Length");
		}
	}
}
