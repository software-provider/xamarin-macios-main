//
// NSGradient: Extensions to the API for NSGradient
//
// Author:
//   Regan Sarwas (find me on gmail as rsarwas)
//

#if !__MACCATALYST__

using System;
using Foundation;
using ObjCRuntime;
using System.Runtime.InteropServices;

#nullable enable

namespace AppKit {
	public partial class NSGradient : NSObject {
		static IntPtr selInitWithColorsAtLocationsColorSpace = Selector.GetHandle ("initWithColors:atLocations:colorSpace:");

		// The signature of this ObjC method is
		// - (id)initWithColorsAndLocations:(NSColor *)firstColor, ... NS_REQUIRES_NIL_TERMINATION;
		// where colors and locations (as CGFloats between 0.0 and 1.0) alternate until nil
		// ObjC example: 
		//    NSGradient *gradient = [[NSGradient alloc] initWithColorsAndLocations: [NSColor blackColor], 0.0,
		//                                                                           [NSColor blueColor], 0.33,
		//                                                                           [NSColor redColor], 1.0, nil];
		// which is a very un-C# thing to do.  The best correlation would be
		//   NSGradient (NSColor[] colors, float[] locations)
		// C# example:
		//    NSGradient gradient = new NSGradient(new[] {NSColor.Black, NSColor.Blue, NSColor.Red},
		//                                         new[] { 0.0f, 0.33f, 1.0f});
		// Per NSGradient.h, this initializer calls the designated initializer (below) with a
		// color space of NSColorSpace.GenericRGBColorSpace, so we will do the same.

		public NSGradient (NSColor [] colors, float [] locations) :
			this (colors, locations, NSColorSpace.GenericRGBColorSpace)
		{
		}

		public NSGradient (NSColor [] colors, double [] locations) :
			this (colors, locations, NSColorSpace.GenericRGBColorSpace)
		{
		}

		public NSGradient (NSColor [] colors, float [] locations, NSColorSpace colorSpace)
		{
			unsafe {
				double [] converted = Array.ConvertAll<float, double> (locations, new Converter<float, double> (a => (double) a));
				fixed (void* locationPtr = converted) {
					Initialize (colors, locationPtr, colorSpace);
				}
			}
		}

		public NSGradient (NSColor [] colors, double [] locations, NSColorSpace colorSpace) : base (NSObjectFlag.Empty)
		{
			unsafe {
				fixed (void* locationPtr = locations) {
					Initialize (colors, locationPtr, colorSpace);
				}
			}
		}

		unsafe void Initialize (NSColor [] colors, void* locationPtr, NSColorSpace colorSpace)
		{
			if (colors is null)
				throw new ArgumentNullException ("colors");
			if (locationPtr is null)
				throw new ArgumentNullException ("locationPtr");
			if (colorSpace is null)
				throw new ArgumentNullException ("colorSpace");

			var nsa_colorArray = NSArray.FromNSObjects (colors);

			IntPtr locations = new IntPtr (locationPtr);
#if NET
			if (IsDirectBinding) {
				Handle = ObjCRuntime.Messaging.NativeHandle_objc_msgSend_NativeHandle_NativeHandle_NativeHandle (this.Handle, selInitWithColorsAtLocationsColorSpace, nsa_colorArray.Handle, locations, colorSpace.Handle);
			} else {
				Handle = ObjCRuntime.Messaging.NativeHandle_objc_msgSendSuper_NativeHandle_NativeHandle_NativeHandle (this.SuperHandle, selInitWithColorsAtLocationsColorSpace, nsa_colorArray.Handle, locations, colorSpace.Handle);
			}
#else
			if (IsDirectBinding) {
				Handle = ObjCRuntime.Messaging.IntPtr_objc_msgSend_IntPtr_IntPtr_IntPtr (this.Handle, selInitWithColorsAtLocationsColorSpace, nsa_colorArray.Handle, locations, colorSpace.Handle);
			} else {
				Handle = ObjCRuntime.Messaging.IntPtr_objc_msgSendSuper_IntPtr_IntPtr_IntPtr (this.SuperHandle, selInitWithColorsAtLocationsColorSpace, nsa_colorArray.Handle, locations, colorSpace.Handle);
			}
#endif
			nsa_colorArray.Dispose ();
		}
	}
}
#endif // !__MACCATALYST__
