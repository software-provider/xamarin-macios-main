//
// CAEnums.cs: definitions used for CoreAnimation
// 
// Authors:
//   Geoff Norton
//   Miguel de Icaza
//
// Copyright 2009-2010, Novell, Inc.
// Copyright 2014 Xamarin Inc.
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
using System;
using Foundation;
using System.Runtime.InteropServices;
using CoreGraphics;
using ObjCRuntime;

#nullable enable

namespace CoreAnimation {

	// untyped enum -> CALayer.h
	// note: edgeAntialiasingMask is an `unsigned int` @property
	[Flags]
	public enum CAEdgeAntialiasingMask : uint {
		LeftEdge = 1 << 0,
		RightEdge = 1 << 1,
		BottomEdge = 1 << 2,
		TopEdge = 1 << 3,
		All = LeftEdge | RightEdge | BottomEdge | TopEdge,
		LeftRightEdges = LeftEdge | RightEdge,
		TopBottomEdges = TopEdge | BottomEdge
	}

	[NoWatch] // headers not updated
	[iOS (11, 0)]
	[TV (11, 0)]
	[Mac (10, 13)]
	[MacCatalyst (13, 1)]
	[Native]
	[Flags]
	public enum CACornerMask : ulong {
		MinXMinYCorner = 1 << 0,
		MaxXMinYCorner = 1 << 1,
		MinXMaxYCorner = 1 << 2,
		MaxXMaxYCorner = 1 << 3,
	}

	// untyped enum -> CALayer.h (only on OSX headers)
	// note: autoresizingMask is an `unsigned int` @property
	[Flags]
	[NoiOS]
	[NoTV]
	[NoWatch]
	[MacCatalyst (13, 1)]
	public enum CAAutoresizingMask : uint {
		NotSizable = 0,
		MinXMargin = 1 << 0,
		WidthSizable = 1 << 1,
		MaxXMargin = 1 << 2,
		MinYMargin = 1 << 3,
		HeightSizable = 1 << 4,
		MaxYMargin = 1 << 5
	}

	// typedef int -> CAConstraintLayoutManager.h
	[NoiOS]
	[NoTV]
	[NoWatch]
	[MacCatalyst (13, 1)]
	public enum CAConstraintAttribute {
		MinX,
		MidX,
		MaxX,
		Width,
		MinY,
		MidY,
		MaxY,
		Height,
	};
}
