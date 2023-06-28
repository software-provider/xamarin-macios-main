#nullable enable

using ObjCRuntime;

namespace CoreMedia {

	// empty interface used as a marker to state which CM objects DO support the API
#if !NET
	[Watch (6, 0)]
#endif
	public interface ICMAttachmentBearer : INativeObject { }

}
