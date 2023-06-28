using System;
using System.Net.Http;
using System.Threading.Tasks;
using Foundation;
using NUnit.Framework;
using MonoTests.System.Net.Http;


namespace LinkSdk.Net.Http {

	[TestFixture]
	[Preserve (AllMembers = true)]
	public class HttpClientTest {

		async Task<string> Get (HttpClient client)
		{
			return await client.GetStringAsync (NetworkResources.XamarinUrl);
		}

		string Get (HttpMessageHandler handler)
		{
			using (var client = new HttpClient (handler)) {
				var get = Get (client);
				get.Wait ();
				return get.Result;
			}
		}

		[Test]
		public void ManagedSimple ()
		{
			Assert.NotNull (Get (new HttpClientHandler ()), "HttpClientHandler");
		}

		[Test]
		public void NSSimple ()
		{
			Assert.NotNull (Get (new NSUrlSessionHandler ()), "NSUrlSessionHandler");
		}

		// same HttpClient and handler doing two simultaneous calls
		void DualGet (HttpMessageHandler handler)
		{
			using (var client = new HttpClient (handler)) {
				var get1 = Get (client);
				var get2 = Get (client);
				get1.Wait ();
				get2.Wait ();
			}
		}

		[Test]
		public void ManagedDual ()
		{
			DualGet (new HttpClientHandler ());
		}

		[Test]
		public void NSDual ()
		{
			DualGet (new NSUrlSessionHandler ());
		}

		[Test]
		public void CFDual ()
		{
			DualGet (new CFNetworkHandler ());
		}

		Task<string> Get302 (HttpClient client)
		{
			return Task.Run (async () => await client.GetStringAsync (NetworkResources.Httpbin.GetRedirectUrl (1)));
		}

		void Get302 (HttpClient client, bool allowRedirect)
		{
			var result = Get302 (client);
			try {
				result.Wait ();
				if (!allowRedirect)
					Assert.Fail ("Redirection *dis*allowed - assert should not be reached");
				Assert.That (result.Result, Contains.Substring ("You have reached the target"), "true");
			} catch (AggregateException ae) {
				if (allowRedirect)
					Assert.Fail ("Redirection allowed - assert should not be reached {0}", ae);
				var inner = ae.InnerException;
				Assert.That (inner is HttpRequestException, "HttpRequestException");
				Assert.That (inner.Message, Contains.Substring ("302 (Found)"), "302");
			}
		}

		[Test]
		public void Managed302_Allowed ()
		{
			var handler = new HttpClientHandler ();
			handler.AllowAutoRedirect = true;
			var client = new HttpClient (handler);
			Get302 (client, allowRedirect: handler.AllowAutoRedirect);
		}

		[Test]
		public void Managed302_Disallowed ()
		{
			var handler = new HttpClientHandler ();
			handler.AllowAutoRedirect = false;
			var client = new HttpClient (handler);
			Get302 (client, allowRedirect: handler.AllowAutoRedirect);
		}

		[Test]
		public void NS302_Allowed ()
		{
			var handler = new NSUrlSessionHandler ();
			handler.AllowAutoRedirect = true;
			var client = new HttpClient (handler);
			Get302 (client, allowRedirect: handler.AllowAutoRedirect);
		}

		[Test]
		public void NS302_Disallowed ()
		{
			var handler = new NSUrlSessionHandler ();
			handler.AllowAutoRedirect = false;
			var client = new HttpClient (handler);
			Get302 (client, allowRedirect: handler.AllowAutoRedirect);
		}

#if !__WATCHOS__
		//[Test]
		public void CFSimple ()
		{
			Assert.NotNull (Get (new CFNetworkHandler ()), "CFNetworkHandler");
		}

		[Test]
		public void CF302_Allowed ()
		{
			var handler = new CFNetworkHandler ();
			handler.AllowAutoRedirect = true;
			var client = new HttpClient (handler);
			Get302 (client, allowRedirect: handler.AllowAutoRedirect);
		}

		[Test]
		public void CF302_Disallowed ()
		{
			var handler = new CFNetworkHandler ();
			handler.AllowAutoRedirect = false;
			var client = new HttpClient (handler);
			Get302 (client, allowRedirect: handler.AllowAutoRedirect);
		}
#endif
	}
}
