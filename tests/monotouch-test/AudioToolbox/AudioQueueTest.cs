//
// Unit tests for AudioQueue
//
// Authors:
//	Marek Safar (marek.safar@gmail.com)
//
// Copyright 2012 Xamarin Inc. All rights reserved.
//

#if !__WATCHOS__

using System.Collections.Generic;
using Foundation;
using AudioToolbox;
using NUnit.Framework;

namespace MonoTouchFixtures.AudioToolbox {

	[TestFixture]
	[Preserve (AllMembers = true)]
	public class AudioQueueTest {
#if !MONOMAC && !__MACCATALYST__ // HardwareCodecPolicy and SetChannelAssignments are iOS only
		[Test]
		public void Properties ()
		{
			TestRuntime.RequestMicrophonePermission ();

			var b = new InputAudioQueue (AudioStreamBasicDescription.CreateLinearPCM ());

			b.HardwareCodecPolicy = AudioQueueHardwareCodecPolicy.UseSoftwareOnly;

			Assert.That (b.HardwareCodecPolicy, Is.EqualTo (AudioQueueHardwareCodecPolicy.UseSoftwareOnly), "#1");
		}

		[Test]
		public void ChannelAssignments ()
		{
			var aq = new OutputAudioQueue (AudioStreamBasicDescription.CreateLinearPCM ());

			var route = global::AVFoundation.AVAudioSession.SharedInstance ().CurrentRoute;
			var outputs = route.Outputs;
			if (outputs.Length > 0) {
				var port = outputs [0];
				var assignments = new List<AudioQueueChannelAssignment> ();
				var id = port.UID;
				for (int i = 0; i < aq.AudioStreamDescription.ChannelsPerFrame; i++) {
					assignments.Add (new AudioQueueChannelAssignment (id, (uint) i));
				}
				Assert.AreEqual (AudioQueueStatus.Ok, aq.SetChannelAssignments (assignments.ToArray ()));
			} else {
				Assert.Ignore ("No outputs in the current route ({0})", route.Description);
			}

		}
#endif

		[Test]
		[Ignore ("Fails on some machines with undefined error code 5")]
		public void ProcessingTap ()
		{
			var aq = new InputAudioQueue (AudioStreamBasicDescription.CreateLinearPCM ());
			AudioQueueStatus ret;
			bool called = false;

			using (var tap = aq.CreateProcessingTap (
				delegate (AudioQueueProcessingTap audioQueueTap, uint numberOfFrames, ref AudioTimeStamp timeStamp, ref AudioQueueProcessingTapFlags flags, AudioBuffers data)
				{
					called = true;
					return 33;
				}, AudioQueueProcessingTapFlags.PreEffects, out ret)) {
				Assert.AreEqual (AudioQueueStatus.Ok, ret, "#1");

				unsafe {
					AudioQueueBuffer* buffer;
					Assert.AreEqual (AudioQueueStatus.Ok, aq.AllocateBuffer (5000, out buffer), "#2");
					Assert.AreEqual (AudioQueueStatus.Ok, aq.EnqueueBuffer (buffer), "#3");
					//Assert.AreEqual (AudioQueueStatus.Ok, aq.Start (), "#4");
				}
			}

			//Assert.That (called, Is.True, "#10");
		}

		[Test]
		public void InvalidAudioBasicDescription ()
		{
			TestRuntime.RequestMicrophonePermission ();
			Assert.Throws<AudioQueueException> (() => new InputAudioQueue (new AudioStreamBasicDescription ()), "A");
		}
	}
}

#endif // !__WATCHOS__
