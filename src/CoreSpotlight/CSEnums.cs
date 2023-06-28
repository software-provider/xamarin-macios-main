//
// CoreSpotlight enums
//
// Authors:
//	Alex Soto  <alex.soto@xamarin.com>
//
// Copyright 2015, 2016 Xamarin Inc. All rights reserved.
//

using System;
using ObjCRuntime;
using Foundation;

#nullable enable

namespace CoreSpotlight {
	// NSInteger -> CNContact.h
	[NoTV] // CS_TVOS_UNAVAILABLE
	[iOS (9, 0), Mac (10, 11)]
	[MacCatalyst (13, 1)]
	[Native]
	[ErrorDomain ("CSIndexErrorDomain")]
	public enum CSIndexErrorCode : long {
		UnknownError = -1,
		IndexUnavailableError = -1000,
		InvalidItemError = -1001,
		InvalidClientStateError = -1002,
		RemoteConnectionError = -1003,
		QuotaExceeded = -1004,
		IndexingUnsupported = -1005,
	}

	[NoTV]
	[iOS (10, 0)]
	[Mac (10, 13)]
	[MacCatalyst (13, 1)]
	[ErrorDomain ("CSSearchQueryErrorDomain")]
	[Native]
	public enum CSSearchQueryErrorCode : long {
		Unknown = -2000,
		IndexUnreachable = -2001,
		InvalidQuery = -2002,
		Cancelled = -2003
	}

	[iOS (9, 0)]
	[NoTV]
	[NoMac]
	[MacCatalyst (13, 1)]
	public enum CSFileProtection {
		None,
		Complete,
		CompleteUnlessOpen,
		CompleteUntilFirstUserAuthentication,
	}
}
