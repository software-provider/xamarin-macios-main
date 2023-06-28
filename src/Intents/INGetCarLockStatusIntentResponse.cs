// INGetCarLockStatusIntentResponse.cs
//
// Authors:
//	Alex Soto  <alexsoto@microsoft.com>
//
// Copyright 2017 Xamarin Inc. All rights reserved.
//

#if IOS

using Foundation;
using Intents;
using ObjCRuntime;

namespace Intents {

	public partial class INGetCarLockStatusIntentResponse {

		// if/when we update the generator to allow this pattern we can move this back
		// into bindings and making them virtual (not a breaking change)

		public bool? Locked {
			get { return _Locked is null ? null : (bool?) _Locked.BoolValue; }
		}
	}
}

#endif
