#if IOS

using Foundation;
using Intents;
using ObjCRuntime;

namespace Intents {

	public partial class INRideOption {

		// if/when we update the generator to allow this pattern we can move this back
		// into bindings and making them virtual (not a breaking change)

		public bool? UsesMeteredFare {
			get { return _UsesMeteredFare is null ? null : (bool?) _UsesMeteredFare.BoolValue; }
		}
	}
}

#endif
