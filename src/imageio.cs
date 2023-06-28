//
// ImageIO.cs : Constants
//
// Authors:
//	Sebastien Pouliot  <sebastien@xamarin.com>
//
// Copyright 2012-2014, Xamarin, Inc.
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

using ObjCRuntime;
using Foundation;
using CoreFoundation;
using CoreGraphics;
using System;

namespace ImageIO {

	[Static]
	// Bad name should end with Keys
	interface CGImageProperties {
		// Format-Specific Dictionaries
		[Field ("kCGImagePropertyTIFFDictionary")]
		NSString TIFFDictionary { get; }
		[Field ("kCGImagePropertyGIFDictionary")]
		NSString GIFDictionary { get; }
		[Field ("kCGImagePropertyJFIFDictionary")]
		NSString JFIFDictionary { get; }
		[Field ("kCGImagePropertyExifDictionary")]
		NSString ExifDictionary { get; }
		[Field ("kCGImagePropertyPNGDictionary")]
		NSString PNGDictionary { get; }
		[Field ("kCGImagePropertyIPTCDictionary")]
		NSString IPTCDictionary { get; }
		[Field ("kCGImagePropertyGPSDictionary")]
		NSString GPSDictionary { get; }
		[Field ("kCGImagePropertyRawDictionary")]
		NSString RawDictionary { get; }
		[Field ("kCGImagePropertyCIFFDictionary")]
		NSString CIFFDictionary { get; }
		[Field ("kCGImageProperty8BIMDictionary")]
		NSString EightBIMDictionary { get; }
		[Field ("kCGImagePropertyDNGDictionary")]
		NSString DNGDictionary { get; }
		[Field ("kCGImagePropertyExifAuxDictionary")]
		NSString ExifAuxDictionary { get; }

		[iOS (13, 0)]
		[TV (13, 0)]
		[Watch (6, 0)]
		[Mac (10, 15)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyHEICSDictionary")]
		NSString HeicsDictionary { get; }

		[Mac (11, 0), iOS (14, 0), TV (14, 0), Watch (7, 0)]
		[MacCatalyst (14, 0)]
		[Field ("kCGImagePropertyWebPDictionary")]
		NSString WebPDictionary { get; }

		[Mac (11, 0), iOS (14, 1), TV (14, 2), Watch (7, 1)]
		[MacCatalyst (14, 1)]
		[Field ("kCGImagePropertyTGADictionary")]
		NSString TgaDictionary { get; }

		// Camera-Maker Dictionaries
		[Field ("kCGImagePropertyMakerCanonDictionary")]
		NSString MakerCanonDictionary { get; }
		[Field ("kCGImagePropertyMakerNikonDictionary")]
		NSString MakerNikonDictionary { get; }

		[iOS (8, 3)]
		[Mac (10, 10)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyMakerMinoltaDictionary")]
		NSString MakerMinoltaDictionary { get; }

		[iOS (8, 3)]
		[Mac (10, 10)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyMakerFujiDictionary")]
		NSString MakerFujiDictionary { get; }

		[iOS (8, 3)]
		[Mac (10, 10)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyMakerOlympusDictionary")]
		NSString MakerOlympusDictionary { get; }

		[iOS (8, 3)]
		[Mac (10, 10)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyMakerPentaxDictionary")]
		NSString MakerPentaxDictionary { get; }

		// Image Source Container Properties
		[Field ("kCGImagePropertyFileSize")]
		NSString FileSize { get; }

		// Individual Image Properties
		[Field ("kCGImagePropertyDPIHeight")]
		NSString DPIHeight { get; }
		[Field ("kCGImagePropertyDPIWidth")]
		NSString DPIWidth { get; }
		[Field ("kCGImagePropertyPixelWidth")]
		NSString PixelWidth { get; }
		[Field ("kCGImagePropertyPixelHeight")]
		NSString PixelHeight { get; }
		[Field ("kCGImagePropertyDepth")]
		NSString Depth { get; }
		[Field ("kCGImagePropertyOrientation")]
		NSString Orientation { get; }
		[Field ("kCGImagePropertyIsFloat")]
		NSString IsFloat { get; }
		[Field ("kCGImagePropertyIsIndexed")]
		NSString IsIndexed { get; }
		[Field ("kCGImagePropertyHasAlpha")]
		NSString HasAlpha { get; }
		[Field ("kCGImagePropertyColorModel")]
		NSString ColorModel { get; }
		[Field ("kCGImagePropertyProfileName")]
		NSString ProfileName { get; }

		// Color Model Values

		[Field ("kCGImagePropertyColorModelRGB")]
		NSString ColorModelRGB { get; }
		[Field ("kCGImagePropertyColorModelGray")]
		NSString ColorModelGray { get; }
		[Field ("kCGImagePropertyColorModelCMYK")]
		NSString ColorModelCMYK { get; }
		[Field ("kCGImagePropertyColorModelLab")]
		NSString ColorModelLab { get; }

		// EXIF Dictionary Keys

		[Field ("kCGImagePropertyExifExposureTime")]
		NSString ExifExposureTime { get; }
		[Field ("kCGImagePropertyExifFNumber")]
		NSString ExifFNumber { get; }
		[Field ("kCGImagePropertyExifExposureProgram")]
		NSString ExifExposureProgram { get; }
		[Field ("kCGImagePropertyExifSpectralSensitivity")]
		NSString ExifSpectralSensitivity { get; }
		[Field ("kCGImagePropertyExifISOSpeedRatings")]
		NSString ExifISOSpeedRatings { get; }
		[Field ("kCGImagePropertyExifOECF")]
		NSString ExifOECF { get; }
		[Field ("kCGImagePropertyExifVersion")]
		NSString ExifVersion { get; }
		[Field ("kCGImagePropertyExifDateTimeOriginal")]
		NSString ExifDateTimeOriginal { get; }
		[Field ("kCGImagePropertyExifDateTimeDigitized")]
		NSString ExifDateTimeDigitized { get; }
		[Field ("kCGImagePropertyExifComponentsConfiguration")]
		NSString ExifComponentsConfiguration { get; }
		[Field ("kCGImagePropertyExifCompressedBitsPerPixel")]
		NSString ExifCompressedBitsPerPixel { get; }
		[Field ("kCGImagePropertyExifShutterSpeedValue")]
		NSString ExifShutterSpeedValue { get; }
		[Field ("kCGImagePropertyExifApertureValue")]
		NSString ExifApertureValue { get; }
		[Field ("kCGImagePropertyExifBrightnessValue")]
		NSString ExifBrightnessValue { get; }
		[Field ("kCGImagePropertyExifExposureBiasValue")]
		NSString ExifExposureBiasValue { get; }
		[Field ("kCGImagePropertyExifMaxApertureValue")]
		NSString ExifMaxApertureValue { get; }
		[Field ("kCGImagePropertyExifSubjectDistance")]
		NSString ExifSubjectDistance { get; }
		[Field ("kCGImagePropertyExifMeteringMode")]
		NSString ExifMeteringMode { get; }
		[Field ("kCGImagePropertyExifLightSource")]
		NSString ExifLightSource { get; }
		[Field ("kCGImagePropertyExifFlash")]
		NSString ExifFlash { get; }
		[Field ("kCGImagePropertyExifFocalLength")]
		NSString ExifFocalLength { get; }
		[Field ("kCGImagePropertyExifSubjectArea")]
		NSString ExifSubjectArea { get; }
		[Field ("kCGImagePropertyExifMakerNote")]
		NSString ExifMakerNote { get; }
		[Field ("kCGImagePropertyExifUserComment")]
		NSString ExifUserComment { get; }
		[Field ("kCGImagePropertyExifSubsecTime")]
		NSString ExifSubsecTime { get; }
		[Field ("kCGImagePropertyExifSubsecTimeOrginal")]
		NSString ExifSubsecTimeOrginal { get; }
		[iOS (10, 0)]
		[Mac (10, 11)]
		[TV (10, 0)]
		[Watch (3, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyExifSubsecTimeOriginal")]
		NSString ExifSubsecTimeOriginal { get; }
		[Field ("kCGImagePropertyExifSubsecTimeDigitized")]
		NSString ExifSubsecTimeDigitized { get; }
		[Field ("kCGImagePropertyExifFlashPixVersion")]
		NSString ExifFlashPixVersion { get; }
		[Field ("kCGImagePropertyExifColorSpace")]
		NSString ExifColorSpace { get; }
		[Field ("kCGImagePropertyExifPixelXDimension")]
		NSString ExifPixelXDimension { get; }
		[Field ("kCGImagePropertyExifPixelYDimension")]
		NSString ExifPixelYDimension { get; }
		[Field ("kCGImagePropertyExifRelatedSoundFile")]
		NSString ExifRelatedSoundFile { get; }
		[Field ("kCGImagePropertyExifFlashEnergy")]
		NSString ExifFlashEnergy { get; }
		[Field ("kCGImagePropertyExifSpatialFrequencyResponse")]
		NSString ExifSpatialFrequencyResponse { get; }
		[Field ("kCGImagePropertyExifFocalPlaneXResolution")]
		NSString ExifFocalPlaneXResolution { get; }
		[Field ("kCGImagePropertyExifFocalPlaneYResolution")]
		NSString ExifFocalPlaneYResolution { get; }
		[Field ("kCGImagePropertyExifFocalPlaneResolutionUnit")]
		NSString ExifFocalPlaneResolutionUnit { get; }
		[Field ("kCGImagePropertyExifSubjectLocation")]
		NSString ExifSubjectLocation { get; }
		[Field ("kCGImagePropertyExifExposureIndex")]
		NSString ExifExposureIndex { get; }
		[Field ("kCGImagePropertyExifSensingMethod")]
		NSString ExifSensingMethod { get; }
		[Field ("kCGImagePropertyExifFileSource")]
		NSString ExifFileSource { get; }
		[Field ("kCGImagePropertyExifSceneType")]
		NSString ExifSceneType { get; }
		[Field ("kCGImagePropertyExifCFAPattern")]
		NSString ExifCFAPattern { get; }
		[Field ("kCGImagePropertyExifCustomRendered")]
		NSString ExifCustomRendered { get; }
		[Field ("kCGImagePropertyExifExposureMode")]
		NSString ExifExposureMode { get; }
		[Field ("kCGImagePropertyExifWhiteBalance")]
		NSString ExifWhiteBalance { get; }
		[Field ("kCGImagePropertyExifDigitalZoomRatio")]
		NSString ExifDigitalZoomRatio { get; }
		[Field ("kCGImagePropertyExifFocalLenIn35mmFilm")]
		NSString ExifFocalLenIn35mmFilm { get; }
		[Field ("kCGImagePropertyExifSceneCaptureType")]
		NSString ExifSceneCaptureType { get; }
		[Field ("kCGImagePropertyExifGainControl")]
		NSString ExifGainControl { get; }
		[Field ("kCGImagePropertyExifContrast")]
		NSString ExifContrast { get; }
		[Field ("kCGImagePropertyExifSaturation")]
		NSString ExifSaturation { get; }
		[Field ("kCGImagePropertyExifSharpness")]
		NSString ExifSharpness { get; }
		[Field ("kCGImagePropertyExifDeviceSettingDescription")]
		NSString ExifDeviceSettingDescription { get; }
		[Field ("kCGImagePropertyExifSubjectDistRange")]
		NSString ExifSubjectDistRange { get; }
		[Field ("kCGImagePropertyExifImageUniqueID")]
		NSString ExifImageUniqueID { get; }
		[Field ("kCGImagePropertyExifGamma")]
		NSString ExifGamma { get; }

		[Mac (10, 15, 1), iOS (13, 1), TV (13, 1), Watch (6, 1)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyExifCompositeImage")]
		NSString ExifCompositeImage { get; }

		[Mac (10, 15, 1), iOS (13, 1), TV (13, 1), Watch (6, 1)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyExifSourceImageNumberOfCompositeImage")]
		NSString ExifSourceImageNumberOfCompositeImage { get; }

		[Mac (10, 15, 1), iOS (13, 1), TV (13, 1), Watch (6, 1)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyExifSourceExposureTimesOfCompositeImage")]
		NSString ExifSourceExposureTimesOfCompositeImage { get; }

		// misdocumented (first 4.3, then 5.0) but the constants were not present until 6.x

		[Field ("kCGImagePropertyExifCameraOwnerName")]
		[Mac (10, 9)] // Really introduced in 10.8 (according to header), but as a private symbol in the framework (nm shows it as 's'), so we can't access it.
		[MacCatalyst (13, 1)]
		NSString ExifCameraOwnerName { get; }

		[Field ("kCGImagePropertyExifBodySerialNumber")]
		[Mac (10, 9)] // Really introduced in 10.8 (according to header), but as a private symbol in the framework (nm shows it as 's'), so we can't access it.
		[MacCatalyst (13, 1)]
		NSString ExifBodySerialNumber { get; }

		[Field ("kCGImagePropertyExifLensSpecification")]
		[Mac (10, 9)] // Really introduced in 10.8 (according to header), but as a private symbol in the framework (nm shows it as 's'), so we can't access it.
		[MacCatalyst (13, 1)]
		NSString ExifLensSpecification { get; }

		[Field ("kCGImagePropertyExifLensMake")]
		[Mac (10, 9)] // Really introduced in 10.8 (according to header), but as a private symbol in the framework (nm shows it as 's'), so we can't access it.
		[MacCatalyst (13, 1)]
		NSString ExifLensMake { get; }

		[Field ("kCGImagePropertyExifLensModel")]
		[Mac (10, 9)] // Really introduced in 10.8 (according to header), but as a private symbol in the framework (nm shows it as 's'), so we can't access it.
		[MacCatalyst (13, 1)]
		NSString ExifLensModel { get; }

		[Field ("kCGImagePropertyExifLensSerialNumber")]
		[Mac (10, 9)] // Really introduced in 10.8 (according to header), but as a private symbol in the framework (nm shows it as 's'), so we can't access it.
		[MacCatalyst (13, 1)]
		NSString ExifLensSerialNumber { get; }

		// EXIF Auxiliary Dictionary Keys

		[Field ("kCGImagePropertyExifAuxLensInfo")]
		NSString ExifAuxLensInfo { get; }
		[Field ("kCGImagePropertyExifAuxLensModel")]
		NSString ExifAuxLensModel { get; }
		[Field ("kCGImagePropertyExifAuxSerialNumber")]
		NSString ExifAuxSerialNumber { get; }
		[Field ("kCGImagePropertyExifAuxLensID")]
		NSString ExifAuxLensID { get; }
		[Field ("kCGImagePropertyExifAuxLensSerialNumber")]
		NSString ExifAuxLensSerialNumber { get; }
		[Field ("kCGImagePropertyExifAuxImageNumber")]
		NSString ExifAuxImageNumber { get; }
		[Field ("kCGImagePropertyExifAuxFlashCompensation")]
		NSString ExifAuxFlashCompensation { get; }
		[Field ("kCGImagePropertyExifAuxOwnerName")]
		NSString ExifAuxOwnerName { get; }
		[Field ("kCGImagePropertyExifAuxFirmware")]
		NSString ExifAuxFirmware { get; }

		// GIF Dictionary Keys

		[Field ("kCGImagePropertyGIFLoopCount")]
		NSString GIFLoopCount { get; }
		[Field ("kCGImagePropertyGIFDelayTime")]
		NSString GIFDelayTime { get; }
		[Field ("kCGImagePropertyGIFImageColorMap")]
		NSString GIFImageColorMap { get; }
		[Field ("kCGImagePropertyGIFHasGlobalColorMap")]
		NSString GIFHasGlobalColorMap { get; }
		[Field ("kCGImagePropertyGIFUnclampedDelayTime")]
		NSString GIFUnclampedDelayTime { get; }

		[iOS (13, 0)]
		[TV (13, 0)]
		[Watch (6, 0)]
		[Mac (10, 15)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyGIFCanvasPixelWidth")]
		NSString GifCanvasPixelWidth { get; }

		[iOS (13, 0)]
		[TV (13, 0)]
		[Watch (6, 0)]
		[Mac (10, 15)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyGIFCanvasPixelHeight")]
		NSString GifCanvasPixelHeight { get; }

		[iOS (13, 0)]
		[TV (13, 0)]
		[Watch (6, 0)]
		[Mac (10, 15)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyGIFFrameInfoArray")]
		NSString GifFrameInfoArray { get; }

		// GPS Dictionary Keys

		[Field ("kCGImagePropertyGPSVersion")]
		NSString GPSVersion { get; }
		[Field ("kCGImagePropertyGPSLatitudeRef")]
		NSString GPSLatitudeRef { get; }
		[Field ("kCGImagePropertyGPSLatitude")]
		NSString GPSLatitude { get; }
		[Field ("kCGImagePropertyGPSLongitudeRef")]
		NSString GPSLongitudeRef { get; }
		[Field ("kCGImagePropertyGPSLongitude")]
		NSString GPSLongitude { get; }
		[Field ("kCGImagePropertyGPSAltitudeRef")]
		NSString GPSAltitudeRef { get; }
		[Field ("kCGImagePropertyGPSAltitude")]
		NSString GPSAltitude { get; }
		[Field ("kCGImagePropertyGPSTimeStamp")]
		NSString GPSTimeStamp { get; }
		[Field ("kCGImagePropertyGPSSatellites")]
		NSString GPSSatellites { get; }
		[Field ("kCGImagePropertyGPSStatus")]
		NSString GPSStatus { get; }
		[Field ("kCGImagePropertyGPSMeasureMode")]
		NSString GPSMeasureMode { get; }
		[Field ("kCGImagePropertyGPSDOP")]
		NSString GPSDOP { get; }
		[Field ("kCGImagePropertyGPSSpeedRef")]
		NSString GPSSpeedRef { get; }
		[Field ("kCGImagePropertyGPSSpeed")]
		NSString GPSSpeed { get; }
		[Field ("kCGImagePropertyGPSTrackRef")]
		NSString GPSTrackRef { get; }
		[Field ("kCGImagePropertyGPSTrack")]
		NSString GPSTrack { get; }
		[Field ("kCGImagePropertyGPSImgDirectionRef")]
		NSString GPSImgDirectionRef { get; }
		[Field ("kCGImagePropertyGPSImgDirection")]
		NSString GPSImgDirection { get; }
		[Field ("kCGImagePropertyGPSMapDatum")]
		NSString GPSMapDatum { get; }
		[Field ("kCGImagePropertyGPSDestLatitudeRef")]
		NSString GPSDestLatitudeRef { get; }
		[Field ("kCGImagePropertyGPSDestLatitude")]
		NSString GPSDestLatitude { get; }
		[Field ("kCGImagePropertyGPSDestLongitudeRef")]
		NSString GPSDestLongitudeRef { get; }
		[Field ("kCGImagePropertyGPSDestLongitude")]
		NSString GPSDestLongitude { get; }
		[Field ("kCGImagePropertyGPSDestBearingRef")]
		NSString GPSDestBearingRef { get; }
		[Field ("kCGImagePropertyGPSDestBearing")]
		NSString GPSDestBearing { get; }
		[Field ("kCGImagePropertyGPSDestDistanceRef")]
		NSString GPSDestDistanceRef { get; }
		[Field ("kCGImagePropertyGPSDestDistance")]
		NSString GPSDestDistance { get; }
		[Field ("kCGImagePropertyGPSAreaInformation")]
		NSString GPSAreaInformation { get; }
		[Field ("kCGImagePropertyGPSDateStamp")]
		NSString GPSDateStamp { get; }
		[Field ("kCGImagePropertyGPSDifferental")]
		NSString GPSDifferental { get; }

		[iOS (8, 0), Mac (10, 10)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyGPSHPositioningError")]
		NSString GPSHPositioningError { get; }

		// IPTC Dictionary Keys

		[Field ("kCGImagePropertyIPTCObjectTypeReference")]
		NSString IPTCObjectTypeReference { get; }
		[Field ("kCGImagePropertyIPTCObjectAttributeReference")]
		NSString IPTCObjectAttributeReference { get; }
		[Field ("kCGImagePropertyIPTCObjectName")]
		NSString IPTCObjectName { get; }
		[Field ("kCGImagePropertyIPTCEditStatus")]
		NSString IPTCEditStatus { get; }
		[Field ("kCGImagePropertyIPTCEditorialUpdate")]
		NSString IPTCEditorialUpdate { get; }
		[Field ("kCGImagePropertyIPTCUrgency")]
		NSString IPTCUrgency { get; }
		[Field ("kCGImagePropertyIPTCSubjectReference")]
		NSString IPTCSubjectReference { get; }
		[Field ("kCGImagePropertyIPTCCategory")]
		NSString IPTCCategory { get; }
		[Field ("kCGImagePropertyIPTCSupplementalCategory")]
		NSString IPTCSupplementalCategory { get; }
		[Field ("kCGImagePropertyIPTCFixtureIdentifier")]
		NSString IPTCFixtureIdentifier { get; }
		[Field ("kCGImagePropertyIPTCKeywords")]
		NSString IPTCKeywords { get; }
		[Field ("kCGImagePropertyIPTCContentLocationCode")]
		NSString IPTCContentLocationCode { get; }
		[Field ("kCGImagePropertyIPTCContentLocationName")]
		NSString IPTCContentLocationName { get; }
		[Field ("kCGImagePropertyIPTCReleaseDate")]
		NSString IPTCReleaseDate { get; }
		[Field ("kCGImagePropertyIPTCReleaseTime")]
		NSString IPTCReleaseTime { get; }
		[Field ("kCGImagePropertyIPTCExpirationDate")]
		NSString IPTCExpirationDate { get; }
		[Field ("kCGImagePropertyIPTCExpirationTime")]
		NSString IPTCExpirationTime { get; }
		[Field ("kCGImagePropertyIPTCSpecialInstructions")]
		NSString IPTCSpecialInstructions { get; }
		[Field ("kCGImagePropertyIPTCActionAdvised")]
		NSString IPTCActionAdvised { get; }
		[Field ("kCGImagePropertyIPTCReferenceService")]
		NSString IPTCReferenceService { get; }
		[Field ("kCGImagePropertyIPTCReferenceDate")]
		NSString IPTCReferenceDate { get; }
		[Field ("kCGImagePropertyIPTCReferenceNumber")]
		NSString IPTCReferenceNumber { get; }
		[Field ("kCGImagePropertyIPTCDateCreated")]
		NSString IPTCDateCreated { get; }
		[Field ("kCGImagePropertyIPTCTimeCreated")]
		NSString IPTCTimeCreated { get; }
		[Field ("kCGImagePropertyIPTCDigitalCreationDate")]
		NSString IPTCDigitalCreationDate { get; }
		[Field ("kCGImagePropertyIPTCDigitalCreationTime")]
		NSString IPTCDigitalCreationTime { get; }
		[Field ("kCGImagePropertyIPTCOriginatingProgram")]
		NSString IPTCOriginatingProgram { get; }
		[Field ("kCGImagePropertyIPTCProgramVersion")]
		NSString IPTCProgramVersion { get; }
		[Field ("kCGImagePropertyIPTCObjectCycle")]
		NSString IPTCObjectCycle { get; }
		[Field ("kCGImagePropertyIPTCByline")]
		NSString IPTCByline { get; }
		[Field ("kCGImagePropertyIPTCBylineTitle")]
		NSString IPTCBylineTitle { get; }
		[Field ("kCGImagePropertyIPTCCity")]
		NSString IPTCCity { get; }
		[Field ("kCGImagePropertyIPTCSubLocation")]
		NSString IPTCSubLocation { get; }
		[Field ("kCGImagePropertyIPTCProvinceState")]
		NSString IPTCProvinceState { get; }
		[Field ("kCGImagePropertyIPTCCountryPrimaryLocationCode")]
		NSString IPTCCountryPrimaryLocationCode { get; }
		[Field ("kCGImagePropertyIPTCCountryPrimaryLocationName")]
		NSString IPTCCountryPrimaryLocationName { get; }
		[Field ("kCGImagePropertyIPTCOriginalTransmissionReference")]
		NSString IPTCOriginalTransmissionReference { get; }
		[Field ("kCGImagePropertyIPTCHeadline")]
		NSString IPTCHeadline { get; }
		[Field ("kCGImagePropertyIPTCCredit")]
		NSString IPTCCredit { get; }
		[Field ("kCGImagePropertyIPTCSource")]
		NSString IPTCSource { get; }
		[Field ("kCGImagePropertyIPTCCopyrightNotice")]
		NSString IPTCCopyrightNotice { get; }
		[Field ("kCGImagePropertyIPTCContact")]
		NSString IPTCContact { get; }
		[Field ("kCGImagePropertyIPTCCaptionAbstract")]
		NSString IPTCCaptionAbstract { get; }
		[Field ("kCGImagePropertyIPTCWriterEditor")]
		NSString IPTCWriterEditor { get; }
		[Field ("kCGImagePropertyIPTCImageType")]
		NSString IPTCImageType { get; }
		[Field ("kCGImagePropertyIPTCImageOrientation")]
		NSString IPTCImageOrientation { get; }
		[Field ("kCGImagePropertyIPTCLanguageIdentifier")]
		NSString IPTCLanguageIdentifier { get; }
		[Field ("kCGImagePropertyIPTCStarRating")]
		NSString IPTCStarRating { get; }
		[Field ("kCGImagePropertyIPTCCreatorContactInfo")]
		NSString IPTCCreatorContactInfo { get; }
		[Field ("kCGImagePropertyIPTCRightsUsageTerms")]
		NSString IPTCRightsUsageTerms { get; }
		[Field ("kCGImagePropertyIPTCScene")]
		NSString IPTCScene { get; }

		// IPTC Creator Contact Info Dictionary Keys

		[Field ("kCGImagePropertyIPTCContactInfoCity")]
		NSString IPTCContactInfoCity { get; }
		[Field ("kCGImagePropertyIPTCContactInfoCountry")]
		NSString IPTCContactInfoCountry { get; }
		[Field ("kCGImagePropertyIPTCContactInfoAddress")]
		NSString IPTCContactInfoAddress { get; }
		[Field ("kCGImagePropertyIPTCContactInfoPostalCode")]
		NSString IPTCContactInfoPostalCode { get; }
		[Field ("kCGImagePropertyIPTCContactInfoStateProvince")]
		NSString IPTCContactInfoStateProvince { get; }
		[Field ("kCGImagePropertyIPTCContactInfoEmails")]
		NSString IPTCContactInfoEmails { get; }
		[Field ("kCGImagePropertyIPTCContactInfoPhones")]
		NSString IPTCContactInfoPhones { get; }
		[Field ("kCGImagePropertyIPTCContactInfoWebURLs")]
		NSString IPTCContactInfoWebURLs { get; }

		// JFIF Dictionary Keys

		[Field ("kCGImagePropertyJFIFVersion")]
		NSString JFIFVersion { get; }
		[Field ("kCGImagePropertyJFIFXDensity")]
		NSString JFIFXDensity { get; }
		[Field ("kCGImagePropertyJFIFYDensity")]
		NSString JFIFYDensity { get; }
		[Field ("kCGImagePropertyJFIFDensityUnit")]
		NSString JFIFDensityUnit { get; }
		[Field ("kCGImagePropertyJFIFIsProgressive")]
		NSString JFIFIsProgressive { get; }

		// PNG Dictionary Keys

		[Field ("kCGImagePropertyPNGGamma")]
		NSString PNGGamma { get; }
		[Field ("kCGImagePropertyPNGInterlaceType")]
		NSString PNGInterlaceType { get; }
		[Field ("kCGImagePropertyPNGXPixelsPerMeter")]
		NSString PNGXPixelsPerMeter { get; }
		[Field ("kCGImagePropertyPNGYPixelsPerMeter")]
		NSString PNGYPixelsPerMeter { get; }
		[Field ("kCGImagePropertyPNGsRGBIntent")]
		NSString PNGsRGBIntent { get; }
		[Field ("kCGImagePropertyPNGChromaticities")]
		NSString PNGChromaticities { get; }
		[Field ("kCGImagePropertyPNGAuthor")]
		NSString PNGAuthor { get; }
		[Field ("kCGImagePropertyPNGCopyright")]
		NSString PNGCopyright { get; }
		[Field ("kCGImagePropertyPNGCreationTime")]
		NSString PNGCreationTime { get; }
		[Field ("kCGImagePropertyPNGDescription")]
		NSString PNGDescription { get; }
		[Field ("kCGImagePropertyPNGModificationTime")]
		NSString PNGModificationTime { get; }
		[Field ("kCGImagePropertyPNGSoftware")]
		NSString PNGSoftware { get; }
		[Field ("kCGImagePropertyPNGTitle")]
		NSString PNGTitle { get; }
		[Mac (12, 0), iOS (15, 0), TV (15, 0), MacCatalyst (15, 0), Watch (8, 0)]
		[Field ("kCGImagePropertyPNGPixelsAspectRatio")]
		NSString PNGPixelsAspectRatio { get; }

		[iOS (9, 0)]
		[Mac (10, 11)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyPNGCompressionFilter")]
		NSString PNGCompressionFilter { get; }

		[iOS (8, 0)]
		[Mac (10, 10)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyAPNGLoopCount")]
		NSString PNGLoopCount { get; }

		[iOS (8, 0)]
		[Mac (10, 10)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyAPNGDelayTime")]
		NSString PNGDelayTime { get; }

		[iOS (8, 0)]
		[Mac (10, 10)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyAPNGUnclampedDelayTime")]
		NSString PNGUnclampedDelayTime { get; }

		[iOS (13, 0)]
		[TV (13, 0)]
		[Watch (6, 0)]
		[Mac (10, 15)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyAPNGFrameInfoArray")]
		NSString ApngFrameInfoArray { get; }

		[iOS (13, 0)]
		[TV (13, 0)]
		[Watch (6, 0)]
		[Mac (10, 15)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyAPNGCanvasPixelWidth")]
		NSString ApngCanvasPixelWidth { get; }

		[iOS (13, 0)]
		[TV (13, 0)]
		[Watch (6, 0)]
		[Mac (10, 15)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyAPNGCanvasPixelHeight")]
		NSString ApngCanvasPixelHeight { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyPNGComment")]
		NSString PNGComment { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyPNGDisclaimer")]
		NSString PNGDisclaimer { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyPNGSource")]
		NSString PNGSource { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyPNGWarning")]
		NSString PNGWarning { get; }

		[Watch (7, 4), TV (14, 5), Mac (11, 3), iOS (14, 5)]
		[MacCatalyst (14, 5)]
		[Field ("kCGImagePropertyPNGTransparency")]
		NSString PNGTransparency { get; }

		// TIFF Dictionary Keys

		[Field ("kCGImagePropertyTIFFCompression")]
		NSString TIFFCompression { get; }
		[Field ("kCGImagePropertyTIFFPhotometricInterpretation")]
		NSString TIFFPhotometricInterpretation { get; }
		[Field ("kCGImagePropertyTIFFDocumentName")]
		NSString TIFFDocumentName { get; }
		[Field ("kCGImagePropertyTIFFImageDescription")]
		NSString TIFFImageDescription { get; }
		[Field ("kCGImagePropertyTIFFMake")]
		NSString TIFFMake { get; }
		[Field ("kCGImagePropertyTIFFModel")]
		NSString TIFFModel { get; }
		[Field ("kCGImagePropertyTIFFOrientation")]
		NSString TIFFOrientation { get; }
		[Field ("kCGImagePropertyTIFFXResolution")]
		NSString TIFFXResolution { get; }
		[Field ("kCGImagePropertyTIFFYResolution")]
		NSString TIFFYResolution { get; }
		[Field ("kCGImagePropertyTIFFResolutionUnit")]
		NSString TIFFResolutionUnit { get; }
		[Field ("kCGImagePropertyTIFFSoftware")]
		NSString TIFFSoftware { get; }
		[Field ("kCGImagePropertyTIFFTransferFunction")]
		NSString TIFFTransferFunction { get; }
		[Field ("kCGImagePropertyTIFFDateTime")]
		NSString TIFFDateTime { get; }
		[Field ("kCGImagePropertyTIFFArtist")]
		NSString TIFFArtist { get; }
		[Field ("kCGImagePropertyTIFFHostComputer")]
		NSString TIFFHostComputer { get; }
		[Field ("kCGImagePropertyTIFFWhitePoint")]
		NSString TIFFWhitePoint { get; }
		[Field ("kCGImagePropertyTIFFPrimaryChromaticities")]
		NSString TIFFPrimaryChromaticities { get; }

		[iOS (9, 0)]
		[Mac (10, 11)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyTIFFTileLength")]
		NSString TIFFTileLength { get; }
		[iOS (9, 0)]
		[Mac (10, 11)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyTIFFTileWidth")]
		NSString TIFFTileWidth { get; }

		// DNG Dictionary Keys

		[Field ("kCGImagePropertyDNGVersion")]
		NSString DNGVersion { get; }
		[Field ("kCGImagePropertyDNGBackwardVersion")]
		NSString DNGBackwardVersion { get; }
		[Field ("kCGImagePropertyDNGUniqueCameraModel")]
		NSString DNGUniqueCameraModel { get; }
		[Field ("kCGImagePropertyDNGLocalizedCameraModel")]
		NSString DNGLocalizedCameraModel { get; }
		[Field ("kCGImagePropertyDNGCameraSerialNumber")]
		NSString DNGCameraSerialNumber { get; }
		[Field ("kCGImagePropertyDNGLensInfo")]
		NSString DNGLensInfo { get; }

		[iOS (10, 0)]
		[Mac (10, 12)]
		[Watch (3, 0)]
		[TV (10, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGBlackLevel")]
		NSString DNGBlackLevel { get; }

		[iOS (10, 0)]
		[Mac (10, 12)]
		[Watch (3, 0)]
		[TV (10, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGWhiteLevel")]
		NSString DNGWhiteLevel { get; }

		[iOS (10, 0)]
		[Mac (10, 12)]
		[Watch (3, 0)]
		[TV (10, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGCalibrationIlluminant1")]
		NSString DNGCalibrationIlluminant1 { get; }

		[iOS (10, 0)]
		[Mac (10, 12)]
		[Watch (3, 0)]
		[TV (10, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGCalibrationIlluminant2")]
		NSString DNGCalibrationIlluminant2 { get; }

		[iOS (10, 0)]
		[Mac (10, 12)]
		[Watch (3, 0)]
		[TV (10, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGColorMatrix1")]
		NSString DNGColorMatrix1 { get; }

		[iOS (10, 0)]
		[Mac (10, 12)]
		[Watch (3, 0)]
		[TV (10, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGColorMatrix2")]
		NSString DNGColorMatrix2 { get; }

		[iOS (10, 0)]
		[Mac (10, 12)]
		[Watch (3, 0)]
		[TV (10, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGCameraCalibration1")]
		NSString DNGCameraCalibration1 { get; }

		[iOS (10, 0)]
		[Mac (10, 12)]
		[Watch (3, 0)]
		[TV (10, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGCameraCalibration2")]
		NSString DNGCameraCalibration2 { get; }

		[iOS (10, 0)]
		[Mac (10, 12)]
		[Watch (3, 0)]
		[TV (10, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGAsShotNeutral")]
		NSString DNGAsShotNeutral { get; }

		[iOS (10, 0)]
		[Mac (10, 12)]
		[Watch (3, 0)]
		[TV (10, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGAsShotWhiteXY")]
		NSString DNGAsShotWhiteXY { get; }

		[iOS (10, 0)]
		[Mac (10, 12)]
		[Watch (3, 0)]
		[TV (10, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGBaselineExposure")]
		NSString DNGBaselineExposure { get; }

		[iOS (10, 0)]
		[Mac (10, 12)]
		[Watch (3, 0)]
		[TV (10, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGBaselineNoise")]
		NSString DNGBaselineNoise { get; }

		[iOS (10, 0)]
		[Mac (10, 12)]
		[Watch (3, 0)]
		[TV (10, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGBaselineSharpness")]
		NSString DNGBaselineSharpness { get; }

		[iOS (10, 0)]
		[Mac (10, 12)]
		[Watch (3, 0)]
		[TV (10, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGPrivateData")]
		NSString DNGPrivateData { get; }

		[iOS (10, 0)]
		[Mac (10, 12)]
		[Watch (3, 0)]
		[TV (10, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGCameraCalibrationSignature")]
		NSString DNGCameraCalibrationSignature { get; }

		[iOS (10, 0)]
		[Mac (10, 12)]
		[Watch (3, 0)]
		[TV (10, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGProfileCalibrationSignature")]
		NSString DNGProfileCalibrationSignature { get; }

		[iOS (10, 0)]
		[Mac (10, 12)]
		[Watch (3, 0)]
		[TV (10, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGNoiseProfile")]
		NSString DNGNoiseProfile { get; }

		[iOS (10, 0)]
		[Mac (10, 12)]
		[Watch (3, 0)]
		[TV (10, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGWarpRectilinear")]
		NSString DNGWarpRectilinear { get; }

		[iOS (10, 0)]
		[Mac (10, 12)]
		[Watch (3, 0)]
		[TV (10, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGWarpFisheye")]
		NSString DNGWarpFisheye { get; }

		[iOS (10, 0)]
		[Mac (10, 12)]
		[Watch (3, 0)]
		[TV (10, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGFixVignetteRadial")]
		NSString DNGFixVignetteRadial { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGActiveArea")]
		NSString DNGActiveArea { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGAnalogBalance")]
		NSString DNGAnalogBalance { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGAntiAliasStrength")]
		NSString DNGAntiAliasStrength { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGAsShotICCProfile")]
		NSString DNGAsShotICCProfile { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGAsShotPreProfileMatrix")]
		NSString DNGAsShotPreProfileMatrix { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGAsShotProfileName")]
		NSString DNGAsShotProfileName { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGBaselineExposureOffset")]
		NSString DNGBaselineExposureOffset { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGBayerGreenSplit")]
		NSString DNGBayerGreenSplit { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGBestQualityScale")]
		NSString DNGBestQualityScale { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGBlackLevelDeltaH")]
		NSString DNGBlackLevelDeltaHorizontal { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGBlackLevelDeltaV")]
		NSString DNGBlackLevelDeltaVertical { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGBlackLevelRepeatDim")]
		NSString DNGBlackLevelRepeatDim { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGCFALayout")]
		NSString DNGCfaLayout { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGCFAPlaneColor")]
		NSString DNGCfaPlaneColor { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGChromaBlurRadius")]
		NSString DNGChromaBlurRadius { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGColorimetricReference")]
		NSString DNGColorimetricReference { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGCurrentICCProfile")]
		NSString DNGCurrentICCProfile { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGCurrentPreProfileMatrix")]
		NSString DNGCurrentPreProfileMatrix { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGDefaultBlackRender")]
		NSString DNGDefaultBlackRender { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGDefaultCropOrigin")]
		NSString DNGDefaultCropOrigin { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGDefaultCropSize")]
		NSString DNGDefaultCropSize { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGDefaultScale")]
		NSString DNGDefaultScale { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGDefaultUserCrop")]
		NSString DNGDefaultUserCrop { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGExtraCameraProfiles")]
		NSString DNGExtraCameraProfiles { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGForwardMatrix1")]
		NSString DNGForwardMatrix1 { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGForwardMatrix2")]
		NSString DNGForwardMatrix2 { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGLinearizationTable")]
		NSString DNGLinearizationTable { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGLinearResponseLimit")]
		NSString DNGLinearResponseLimit { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGMakerNoteSafety")]
		NSString DNGMakerNoteSafety { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGMaskedAreas")]
		NSString DNGMaskedAreas { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGNewRawImageDigest")]
		NSString DNGNewRawImageDigest { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGNoiseReductionApplied")]
		NSString DNGNoiseReductionApplied { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGOpcodeList1")]
		NSString DNGOpcodeList1 { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGOpcodeList2")]
		NSString DNGOpcodeList2 { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGOpcodeList3")]
		NSString DNGOpcodeList3 { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGOriginalBestQualityFinalSize")]
		NSString DNGOriginalBestQualityFinalSize { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGOriginalDefaultCropSize")]
		NSString DNGOriginalDefaultCropSize { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGOriginalDefaultFinalSize")]
		NSString DNGOriginalDefaultFinalSize { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGOriginalRawFileData")]
		NSString DNGOriginalRawFileData { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGOriginalRawFileDigest")]
		NSString DNGOriginalRawFileDigest { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGOriginalRawFileName")]
		NSString DNGOriginalRawFileName { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGPreviewApplicationName")]
		NSString DNGPreviewApplicationName { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGPreviewApplicationVersion")]
		NSString DNGPreviewApplicationVersion { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGPreviewColorSpace")]
		NSString DNGPreviewColorSpace { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGPreviewDateTime")]
		NSString DNGPreviewDateTime { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGPreviewSettingsDigest")]
		NSString DNGPreviewSettingsDigest { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGPreviewSettingsName")]
		NSString DNGPreviewSettingsName { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGProfileCopyright")]
		NSString DNGProfileCopyright { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGProfileEmbedPolicy")]
		NSString DNGProfileEmbedPolicy { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGProfileHueSatMapData1")]
		NSString DNGProfileHueSatMapData1 { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGProfileHueSatMapData2")]
		NSString DNGProfileHueSatMapData2 { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGProfileHueSatMapDims")]
		NSString DNGProfileHueSatMapDims { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGProfileHueSatMapEncoding")]
		NSString DNGProfileHueSatMapEncoding { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGProfileLookTableData")]
		NSString DNGProfileLookTableData { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGProfileLookTableDims")]
		NSString DNGProfileLookTableDims { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGProfileLookTableEncoding")]
		NSString DNGProfileLookTableEncoding { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGProfileName")]
		NSString DNGProfileName { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGProfileToneCurve")]
		NSString DNGProfileToneCurve { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGRawDataUniqueID")]
		NSString DNGRawDataUniqueId { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGRawImageDigest")]
		NSString DNGRawImageDigest { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGRawToPreviewGain")]
		NSString DNGRawToPreviewGain { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGReductionMatrix1")]
		NSString DNGReductionMatrix1 { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGReductionMatrix2")]
		NSString DNGReductionMatrix2 { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGRowInterleaveFactor")]
		NSString DNGRowInterleaveFactor { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGShadowScale")]
		NSString DNGShadowScale { get; }

		[Watch (5, 0), TV (12, 0), Mac (10, 14), iOS (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyDNGSubTileBlockSize")]
		NSString DNGSubTileBlockSize { get; }

		// 8BIM Dictionary Keys

		[Field ("kCGImageProperty8BIMLayerNames")]
		NSString EightBIMLayerNames { get; }

		// CIFF Dictionary Keys

		[Field ("kCGImagePropertyCIFFDescription")]
		NSString CIFFDescription { get; }
		[Field ("kCGImagePropertyCIFFFirmware")]
		NSString CIFFFirmware { get; }
		[Field ("kCGImagePropertyCIFFOwnerName")]
		NSString CIFFOwnerName { get; }
		[Field ("kCGImagePropertyCIFFImageName")]
		NSString CIFFImageName { get; }
		[Field ("kCGImagePropertyCIFFImageFileName")]
		NSString CIFFImageFileName { get; }
		[Field ("kCGImagePropertyCIFFReleaseMethod")]
		NSString CIFFReleaseMethod { get; }
		[Field ("kCGImagePropertyCIFFReleaseTiming")]
		NSString CIFFReleaseTiming { get; }
		[Field ("kCGImagePropertyCIFFRecordID")]
		NSString CIFFRecordID { get; }
		[Field ("kCGImagePropertyCIFFSelfTimingTime")]
		NSString CIFFSelfTimingTime { get; }
		[Field ("kCGImagePropertyCIFFCameraSerialNumber")]
		NSString CIFFCameraSerialNumber { get; }
		[Field ("kCGImagePropertyCIFFImageSerialNumber")]
		NSString CIFFImageSerialNumber { get; }
		[Field ("kCGImagePropertyCIFFContinuousDrive")]
		NSString CIFFContinuousDrive { get; }
		[Field ("kCGImagePropertyCIFFFocusMode")]
		NSString CIFFFocusMode { get; }
		[Field ("kCGImagePropertyCIFFMeteringMode")]
		NSString CIFFMeteringMode { get; }
		[Field ("kCGImagePropertyCIFFShootingMode")]
		NSString CIFFShootingMode { get; }
		[Field ("kCGImagePropertyCIFFLensMaxMM")]
		NSString CIFFLensMaxMM { get; }
		[Field ("kCGImagePropertyCIFFLensMinMM")]
		NSString CIFFLensMinMM { get; }
		[Field ("kCGImagePropertyCIFFLensModel")]
		NSString CIFFLensModel { get; }
		[Field ("kCGImagePropertyCIFFWhiteBalanceIndex")]
		NSString CIFFWhiteBalanceIndex { get; }
		[Field ("kCGImagePropertyCIFFFlashExposureComp")]
		NSString CIFFFlashExposureComp { get; }
		[Field ("kCGImagePropertyCIFFMeasuredEV")]
		NSString CIFFMeasuredEV { get; }

		// HEICS

		[iOS (13, 0)]
		[TV (13, 0)]
		[Watch (6, 0)]
		[Mac (10, 15)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyHEICSLoopCount")]
		NSString HeicsLoopCount { get; }

		[iOS (13, 0)]
		[TV (13, 0)]
		[Watch (6, 0)]
		[Mac (10, 15)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyHEICSDelayTime")]
		NSString HeicsDelayTime { get; }

		[iOS (13, 0)]
		[TV (13, 0)]
		[Watch (6, 0)]
		[Mac (10, 15)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyHEICSUnclampedDelayTime")]
		NSString HeicsSUnclampedDelayTime { get; }

		[iOS (13, 0)]
		[TV (13, 0)]
		[Watch (6, 0)]
		[Mac (10, 15)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyHEICSCanvasPixelWidth")]
		NSString HeicsCanvasPixelWidth { get; }

		[iOS (13, 0)]
		[TV (13, 0)]
		[Watch (6, 0)]
		[Mac (10, 15)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyHEICSCanvasPixelHeight")]
		NSString HeicsCanvasPixelHeight { get; }

		[iOS (13, 0)]
		[TV (13, 0)]
		[Watch (6, 0)]
		[Mac (10, 15)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyHEICSFrameInfoArray")]
		NSString HeicsFrameInfoArray { get; }

		// Nikon Camera Dictionary Keys

		[Field ("kCGImagePropertyMakerNikonISOSetting")]
		NSString MakerNikonISOSetting { get; }
		[Field ("kCGImagePropertyMakerNikonColorMode")]
		NSString MakerNikonColorMode { get; }
		[Field ("kCGImagePropertyMakerNikonQuality")]
		NSString MakerNikonQuality { get; }
		[Field ("kCGImagePropertyMakerNikonWhiteBalanceMode")]
		NSString MakerNikonWhiteBalanceMode { get; }
		[Field ("kCGImagePropertyMakerNikonSharpenMode")]
		NSString MakerNikonSharpenMode { get; }
		[Field ("kCGImagePropertyMakerNikonFocusMode")]
		NSString MakerNikonFocusMode { get; }
		[Field ("kCGImagePropertyMakerNikonFlashSetting")]
		NSString MakerNikonFlashSetting { get; }
		[Field ("kCGImagePropertyMakerNikonISOSelection")]
		NSString MakerNikonISOSelection { get; }
		[Field ("kCGImagePropertyMakerNikonFlashExposureComp")]
		NSString MakerNikonFlashExposureComp { get; }
		[Field ("kCGImagePropertyMakerNikonImageAdjustment")]
		NSString MakerNikonImageAdjustment { get; }
		[Field ("kCGImagePropertyMakerNikonLensAdapter")]
		NSString MakerNikonLensAdapter { get; }
		[Field ("kCGImagePropertyMakerNikonLensType")]
		NSString MakerNikonLensType { get; }
		[Field ("kCGImagePropertyMakerNikonLensInfo")]
		NSString MakerNikonLensInfo { get; }
		[Field ("kCGImagePropertyMakerNikonFocusDistance")]
		NSString MakerNikonFocusDistance { get; }
		[Field ("kCGImagePropertyMakerNikonDigitalZoom")]
		NSString MakerNikonDigitalZoom { get; }
		[Field ("kCGImagePropertyMakerNikonShootingMode")]
		NSString MakerNikonShootingMode { get; }
		[Field ("kCGImagePropertyMakerNikonShutterCount")]
		NSString MakerNikonShutterCount { get; }
		[Field ("kCGImagePropertyMakerNikonCameraSerialNumber")]
		NSString MakerNikonCameraSerialNumber { get; }

		// Canon Camera Dictionary Keys

		[Field ("kCGImagePropertyMakerCanonOwnerName")]
		NSString MakerCanonOwnerName { get; }
		[Field ("kCGImagePropertyMakerCanonCameraSerialNumber")]
		NSString MakerCanonCameraSerialNumber { get; }
		[Field ("kCGImagePropertyMakerCanonImageSerialNumber")]
		NSString MakerCanonImageSerialNumber { get; }
		[Field ("kCGImagePropertyMakerCanonFlashExposureComp")]
		NSString MakerCanonFlashExposureComp { get; }
		[Field ("kCGImagePropertyMakerCanonContinuousDrive")]
		NSString MakerCanonContinuousDrive { get; }
		[Field ("kCGImagePropertyMakerCanonLensModel")]
		NSString MakerCanonLensModel { get; }
		[Field ("kCGImagePropertyMakerCanonFirmware")]
		NSString MakerCanonFirmware { get; }
		[Field ("kCGImagePropertyMakerCanonAspectRatioInfo")]
		NSString MakerCanonAspectRatioInfo { get; }

		[Mac (10, 9)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyExifISOSpeed")]
		NSString ExifISOSpeed { get; }
		[Mac (10, 9)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyExifISOSpeedLatitudeyyy")]
		NSString ExifISOSpeedLatitudeYyy { get; }
		[Mac (10, 9)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyExifISOSpeedLatitudezzz")]
		NSString ExifISOSpeedLatitudeZzz { get; }
		[Mac (10, 9)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyExifRecommendedExposureIndex")]
		NSString ExifRecommendedExposureIndex { get; }
		[Mac (10, 9)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyExifSensitivityType")]
		NSString ExifSensitivityType { get; }
		[Mac (10, 9)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyExifStandardOutputSensitivity")]
		NSString ExifStandardOutputSensitivity { get; }

		[iOS (13, 0)]
		[TV (13, 0)]
		[Watch (6, 0)]
		[Mac (10, 15)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyExifOffsetTime")]
		NSString ExifOffsetTime { get; }

		[iOS (13, 0)]
		[TV (13, 0)]
		[Watch (6, 0)]
		[Mac (10, 15)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyExifOffsetTimeOriginal")]
		NSString ExifOffsetTimeOriginal { get; }

		[iOS (13, 0)]
		[TV (13, 0)]
		[Watch (6, 0)]
		[Mac (10, 15)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyExifOffsetTimeDigitized")]
		NSString ExifOffsetTimeDigitized { get; }

		[NoMac]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyMakerAppleDictionary")]
		NSString MakerAppleDictionary { get; }

		[Mac (10, 13), iOS (11, 0), TV (11, 0), Watch (4, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyImageCount")]
		NSString ImageCount { get; }

		[Mac (12, 0), iOS (15, 0), TV (15, 0), MacCatalyst (15, 0), Watch (8, 0)]
		[Field ("kCGImagePropertyImageIndex")]
		NSString ImageIndex { get; }

		[Mac (10, 13), iOS (11, 0), TV (11, 0), Watch (4, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyWidth")]
		NSString Width { get; }

		[Mac (10, 13), iOS (11, 0), TV (11, 0), Watch (4, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyHeight")]
		NSString Height { get; }

		[Mac (10, 13), iOS (11, 0), TV (11, 0), Watch (4, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyBytesPerRow")]
		NSString BytesPerRow { get; }

		[Mac (10, 13), iOS (11, 0), TV (11, 0), Watch (4, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyNamedColorSpace")]
		NSString NamedColorSpace { get; }

		[Mac (10, 13), iOS (11, 0), TV (11, 0), Watch (4, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyPixelFormat")]
		NSString PixelFormat { get; }

		[Mac (10, 13), iOS (11, 0), TV (11, 0), Watch (4, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyImages")]
		NSString Images { get; }

		[Mac (10, 13), iOS (11, 0), TV (11, 0), Watch (4, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyThumbnailImages")]
		NSString ThumbnailImages { get; }

		[Mac (10, 13), iOS (11, 0), TV (11, 0), Watch (4, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyAuxiliaryData")]
		NSString AuxiliaryData { get; }

		[Mac (10, 13), iOS (11, 0), TV (11, 0), Watch (4, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyAuxiliaryDataType")]
		NSString AuxiliaryDataType { get; }

		[Mac (10, 13), iOS (11, 0), TV (11, 0), Watch (4, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyFileContentsDictionary")]
		NSString FileContentsDictionary { get; }

		[Mac (10, 9)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyOpenEXRDictionary")]
		NSString OpenExrDictionary { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtAboutCvTerm")]
		NSString IPTCExtAboutCvTerm { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtAboutCvTermCvId")]
		NSString IPTCExtAboutCvTermCvId { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtAboutCvTermId")]
		NSString IPTCExtAboutCvTermId { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtAboutCvTermName")]
		NSString IPTCExtAboutCvTermName { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtAboutCvTermRefinedAbout")]
		NSString IPTCExtAboutCvTermRefinedAbout { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtAddlModelInfo")]
		NSString IPTCExtAddlModelInfo { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtArtworkOrObject")]
		NSString IPTCExtArtworkOrObject { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtArtworkCircaDateCreated")]
		NSString IPTCExtArtworkCircaDateCreated { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtArtworkContentDescription")]
		NSString IPTCExtArtworkContentDescription { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtArtworkContributionDescription")]
		NSString IPTCExtArtworkContributionDescription { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtArtworkCopyrightNotice")]
		NSString IPTCExtArtworkCopyrightNotice { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtArtworkCreator")]
		NSString IPTCExtArtworkCreator { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtArtworkCreatorID")]
		NSString IPTCExtArtworkCreatorId { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtArtworkCopyrightOwnerID")]
		NSString IPTCExtArtworkCopyrightOwnerId { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtArtworkCopyrightOwnerName")]
		NSString IPTCExtArtworkCopyrightOwnerName { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtArtworkLicensorID")]
		NSString IPTCExtArtworkLicensorId { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtArtworkLicensorName")]
		NSString IPTCExtArtworkLicensorName { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtArtworkDateCreated")]
		NSString IPTCExtArtworkDateCreated { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtArtworkPhysicalDescription")]
		NSString IPTCExtArtworkPhysicalDescription { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtArtworkSource")]
		NSString IPTCExtArtworkSource { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtArtworkSourceInventoryNo")]
		NSString IPTCExtArtworkSourceInventoryNo { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtArtworkSourceInvURL")]
		NSString IPTCExtArtworkSourceInvUrl { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtArtworkStylePeriod")]
		NSString IPTCExtArtworkStylePeriod { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtArtworkTitle")]
		NSString IPTCExtArtworkTitle { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtAudioBitrate")]
		NSString IPTCExtAudioBitrate { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtAudioBitrateMode")]
		NSString IPTCExtAudioBitrateMode { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtAudioChannelCount")]
		NSString IPTCExtAudioChannelCount { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtCircaDateCreated")]
		NSString IPTCExtCircaDateCreated { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtContainerFormat")]
		NSString IPTCExtContainerFormat { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtContainerFormatIdentifier")]
		NSString IPTCExtContainerFormatIdentifier { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtContainerFormatName")]
		NSString IPTCExtContainerFormatName { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtContributor")]
		NSString IPTCExtContributor { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtContributorIdentifier")]
		NSString IPTCExtContributorIdentifier { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtContributorName")]
		NSString IPTCExtContributorName { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtContributorRole")]
		NSString IPTCExtContributorRole { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtCopyrightYear")]
		NSString IPTCExtCopyrightYear { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtCreator")]
		NSString IPTCExtCreator { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtCreatorIdentifier")]
		NSString IPTCExtCreatorIdentifier { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtCreatorName")]
		NSString IPTCExtCreatorName { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtCreatorRole")]
		NSString IPTCExtCreatorRole { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtControlledVocabularyTerm")]
		NSString IPTCExtControlledVocabularyTerm { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtDataOnScreen")]
		NSString IPTCExtDataOnScreen { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtDataOnScreenRegion")]
		NSString IPTCExtDataOnScreenRegion { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtDataOnScreenRegionD")]
		NSString IPTCExtDataOnScreenRegionD { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtDataOnScreenRegionH")]
		NSString IPTCExtDataOnScreenRegionH { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtDataOnScreenRegionText")]
		NSString IPTCExtDataOnScreenRegionText { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtDataOnScreenRegionUnit")]
		NSString IPTCExtDataOnScreenRegionUnit { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtDataOnScreenRegionW")]
		NSString IPTCExtDataOnScreenRegionW { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtDataOnScreenRegionX")]
		NSString IPTCExtDataOnScreenRegionX { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtDataOnScreenRegionY")]
		NSString IPTCExtDataOnScreenRegionY { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtDigitalImageGUID")]
		NSString IPTCExtDigitalImageGuid { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtDigitalSourceFileType")]
		NSString IPTCExtDigitalSourceFileType { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtDigitalSourceType")]
		NSString IPTCExtDigitalSourceType { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtDopesheet")]
		NSString IPTCExtDopesheet { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtDopesheetLink")]
		NSString IPTCExtDopesheetLink { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtDopesheetLinkLink")]
		NSString IPTCExtDopesheetLinkLink { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtDopesheetLinkLinkQualifier")]
		NSString IPTCExtDopesheetLinkLinkQualifier { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtEmbdEncRightsExpr")]
		NSString IPTCExtEmbdEncRightsExpr { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtEmbeddedEncodedRightsExpr")]
		NSString IPTCExtEmbeddedEncodedRightsExpr { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtEmbeddedEncodedRightsExprType")]
		NSString IPTCExtEmbeddedEncodedRightsExprType { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtEmbeddedEncodedRightsExprLangID")]
		NSString IPTCExtEmbeddedEncodedRightsExprLangId { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtEpisode")]
		NSString IPTCExtEpisode { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtEpisodeIdentifier")]
		NSString IPTCExtEpisodeIdentifier { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtEpisodeName")]
		NSString IPTCExtEpisodeName { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtEpisodeNumber")]
		NSString IPTCExtEpisodeNumber { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtEvent")]
		NSString IPTCExtEvent { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtShownEvent")]
		NSString IPTCExtShownEvent { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtShownEventIdentifier")]
		NSString IPTCExtShownEventIdentifier { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtShownEventName")]
		NSString IPTCExtShownEventName { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtExternalMetadataLink")]
		NSString IPTCExtExternalMetadataLink { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtFeedIdentifier")]
		NSString IPTCExtFeedIdentifier { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtGenre")]
		NSString IPTCExtGenre { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtGenreCvId")]
		NSString IPTCExtGenreCvId { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtGenreCvTermId")]
		NSString IPTCExtGenreCvTermId { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtGenreCvTermName")]
		NSString IPTCExtGenreCvTermName { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtGenreCvTermRefinedAbout")]
		NSString IPTCExtGenreCvTermRefinedAbout { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtHeadline")]
		NSString IPTCExtHeadline { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtIPTCLastEdited")]
		NSString IPTCExtIPTCLastEdited { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtLinkedEncRightsExpr")]
		NSString IPTCExtLinkedEncRightsExpr { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtLinkedEncodedRightsExpr")]
		NSString IPTCExtLinkedEncodedRightsExpr { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtLinkedEncodedRightsExprType")]
		NSString IPTCExtLinkedEncodedRightsExprType { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtLinkedEncodedRightsExprLangID")]
		NSString IPTCExtLinkedEncodedRightsExprLangId { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtLocationCreated")]
		NSString IPTCExtLocationCreated { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtLocationCity")]
		NSString IPTCExtLocationCity { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtLocationCountryCode")]
		NSString IPTCExtLocationCountryCode { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtLocationCountryName")]
		NSString IPTCExtLocationCountryName { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtLocationGPSAltitude")]
		NSString IPTCExtLocationGpsAltitude { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtLocationGPSLatitude")]
		NSString IPTCExtLocationGpsLatitude { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtLocationGPSLongitude")]
		NSString IPTCExtLocationGpsLongitude { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtLocationIdentifier")]
		NSString IPTCExtLocationIdentifier { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtLocationLocationId")]
		NSString IPTCExtLocationLocationId { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtLocationLocationName")]
		NSString IPTCExtLocationLocationName { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtLocationProvinceState")]
		NSString IPTCExtLocationProvinceState { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtLocationSublocation")]
		NSString IPTCExtLocationSublocation { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtLocationWorldRegion")]
		NSString IPTCExtLocationWorldRegion { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtLocationShown")]
		NSString IPTCExtLocationShown { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtMaxAvailHeight")]
		NSString IPTCExtMaxAvailHeight { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtMaxAvailWidth")]
		NSString IPTCExtMaxAvailWidth { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtModelAge")]
		NSString IPTCExtModelAge { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtOrganisationInImageCode")]
		NSString IPTCExtOrganisationInImageCode { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtOrganisationInImageName")]
		NSString IPTCExtOrganisationInImageName { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtPersonHeard")]
		NSString IPTCExtPersonHeard { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtPersonHeardIdentifier")]
		NSString IPTCExtPersonHeardIdentifier { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtPersonHeardName")]
		NSString IPTCExtPersonHeardName { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtPersonInImage")]
		NSString IPTCExtPersonInImage { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtPersonInImageWDetails")]
		NSString IPTCExtPersonInImageWDetails { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtPersonInImageCharacteristic")]
		NSString IPTCExtPersonInImageCharacteristic { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtPersonInImageCvTermCvId")]
		NSString IPTCExtPersonInImageCvTermCvId { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtPersonInImageCvTermId")]
		NSString IPTCExtPersonInImageCvTermId { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtPersonInImageCvTermName")]
		NSString IPTCExtPersonInImageCvTermName { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtPersonInImageCvTermRefinedAbout")]
		NSString IPTCExtPersonInImageCvTermRefinedAbout { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtPersonInImageDescription")]
		NSString IPTCExtPersonInImageDescription { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtPersonInImageId")]
		NSString IPTCExtPersonInImageId { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtPersonInImageName")]
		NSString IPTCExtPersonInImageName { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtProductInImage")]
		NSString IPTCExtProductInImage { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtProductInImageDescription")]
		NSString IPTCExtProductInImageDescription { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtProductInImageGTIN")]
		NSString IPTCExtProductInImageGtin { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtProductInImageName")]
		NSString IPTCExtProductInImageName { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtPublicationEvent")]
		NSString IPTCExtPublicationEvent { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtPublicationEventDate")]
		NSString IPTCExtPublicationEventDate { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtPublicationEventIdentifier")]
		NSString IPTCExtPublicationEventIdentifier { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtPublicationEventName")]
		NSString IPTCExtPublicationEventName { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtRating")]
		NSString IPTCExtRating { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtRatingRatingRegion")]
		NSString IPTCExtRatingRatingRegion { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtRatingRegionCity")]
		NSString IPTCExtRatingRegionCity { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtRatingRegionCountryCode")]
		NSString IPTCExtRatingRegionCountryCode { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtRatingRegionCountryName")]
		NSString IPTCExtRatingRegionCountryName { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtRatingRegionGPSAltitude")]
		NSString IPTCExtRatingRegionGpsAltitude { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtRatingRegionGPSLatitude")]
		NSString IPTCExtRatingRegionGpsLatitude { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtRatingRegionGPSLongitude")]
		NSString IPTCExtRatingRegionGpsLongitude { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtRatingRegionIdentifier")]
		NSString IPTCExtRatingRegionIdentifier { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtRatingRegionLocationId")]
		NSString IPTCExtRatingRegionLocationId { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtRatingRegionLocationName")]
		NSString IPTCExtRatingRegionLocationName { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtRatingRegionProvinceState")]
		NSString IPTCExtRatingRegionProvinceState { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtRatingRegionSublocation")]
		NSString IPTCExtRatingRegionSublocation { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtRatingRegionWorldRegion")]
		NSString IPTCExtRatingRegionWorldRegion { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtRatingScaleMaxValue")]
		NSString IPTCExtRatingScaleMaxValue { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtRatingScaleMinValue")]
		NSString IPTCExtRatingScaleMinValue { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtRatingSourceLink")]
		NSString IPTCExtRatingSourceLink { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtRatingValue")]
		NSString IPTCExtRatingValue { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtRatingValueLogoLink")]
		NSString IPTCExtRatingValueLogoLink { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtRegistryID")]
		NSString IPTCExtRegistryId { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtRegistryEntryRole")]
		NSString IPTCExtRegistryEntryRole { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtRegistryItemID")]
		NSString IPTCExtRegistryItemId { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtRegistryOrganisationID")]
		NSString IPTCExtRegistryOrganisationId { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtReleaseReady")]
		NSString IPTCExtReleaseReady { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtSeason")]
		NSString IPTCExtSeason { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtSeasonIdentifier")]
		NSString IPTCExtSeasonIdentifier { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtSeasonName")]
		NSString IPTCExtSeasonName { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtSeasonNumber")]
		NSString IPTCExtSeasonNumber { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtSeries")]
		NSString IPTCExtSeries { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtSeriesIdentifier")]
		NSString IPTCExtSeriesIdentifier { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtSeriesName")]
		NSString IPTCExtSeriesName { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtStorylineIdentifier")]
		NSString IPTCExtStorylineIdentifier { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtStreamReady")]
		NSString IPTCExtStreamReady { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtStylePeriod")]
		NSString IPTCExtStylePeriod { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtSupplyChainSource")]
		NSString IPTCExtSupplyChainSource { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtSupplyChainSourceIdentifier")]
		NSString IPTCExtSupplyChainSourceIdentifier { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtSupplyChainSourceName")]
		NSString IPTCExtSupplyChainSourceName { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtTemporalCoverage")]
		NSString IPTCExtTemporalCoverage { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtTemporalCoverageFrom")]
		NSString IPTCExtTemporalCoverageFrom { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtTemporalCoverageTo")]
		NSString IPTCExtTemporalCoverageTo { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtTranscript")]
		NSString IPTCExtTranscript { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtTranscriptLink")]
		NSString IPTCExtTranscriptLink { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtTranscriptLinkLink")]
		NSString IPTCExtTranscriptLinkLink { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtTranscriptLinkLinkQualifier")]
		NSString IPTCExtTranscriptLinkLinkQualifier { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtVideoBitrate")]
		NSString IPTCExtVideoBitrate { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtVideoBitrateMode")]
		NSString IPTCExtVideoBitrateMode { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtVideoDisplayAspectRatio")]
		NSString IPTCExtVideoDisplayAspectRatio { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtVideoEncodingProfile")]
		NSString IPTCExtVideoEncodingProfile { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtVideoShotType")]
		NSString IPTCExtVideoShotType { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtVideoShotTypeIdentifier")]
		NSString IPTCExtVideoShotTypeIdentifier { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtVideoShotTypeName")]
		NSString IPTCExtVideoShotTypeName { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtVideoStreamsCount")]
		NSString IPTCExtVideoStreamsCount { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtVisualColor")]
		NSString IPTCExtVisualColor { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtWorkflowTag")]
		NSString IPTCExtWorkflowTag { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtWorkflowTagCvId")]
		NSString IPTCExtWorkflowTagCvId { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtWorkflowTagCvTermId")]
		NSString IPTCExtWorkflowTagCvTermId { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtWorkflowTagCvTermName")]
		NSString IPTCExtWorkflowTagCvTermName { get; }

		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyIPTCExtWorkflowTagCvTermRefinedAbout")]
		NSString IPTCExtWorkflowTagCvTermRefinedAbout { get; }

		[Mac (10, 9)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyOpenEXRAspectRatio")]
		NSString OpenExrAspectRatio { get; }

		[Watch (4, 0), Mac (10, 13), iOS (11, 0), TV (11, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImagePropertyPrimaryImage")]
		NSString PrimaryImage { get; }

		// WebP Dictionary Keys

		[Mac (11, 0)]
		[iOS (14, 0)]
		[TV (14, 0)]
		[Watch (7, 0)]
		[MacCatalyst (14, 0)]
		[Field ("kCGImagePropertyWebPLoopCount")]
		NSString WebPLoopCount { get; }

		[Mac (11, 0)]
		[iOS (14, 0)]
		[TV (14, 0)]
		[Watch (7, 0)]
		[MacCatalyst (14, 0)]
		[Field ("kCGImagePropertyWebPDelayTime")]
		NSString WebPDelayTime { get; }

		[Mac (11, 0)]
		[iOS (14, 0)]
		[TV (14, 0)]
		[Watch (7, 0)]
		[MacCatalyst (14, 0)]
		[Field ("kCGImagePropertyWebPUnclampedDelayTime")]
		NSString WebPUnclampedDelayTime { get; }

		[Mac (11, 0)]
		[iOS (14, 0)]
		[TV (14, 0)]
		[Watch (7, 0)]
		[MacCatalyst (14, 0)]
		[Field ("kCGImagePropertyWebPFrameInfoArray")]
		NSString WebPFrameInfoArray { get; }

		[Mac (11, 0)]
		[iOS (14, 0)]
		[TV (14, 0)]
		[Watch (7, 0)]
		[MacCatalyst (14, 0)]
		[Field ("kCGImagePropertyWebPCanvasPixelWidth")]
		NSString WebPCanvasPixelWidth { get; }

		[Mac (11, 0)]
		[iOS (14, 0)]
		[TV (14, 0)]
		[Watch (7, 0)]
		[MacCatalyst (14, 0)]
		[Field ("kCGImagePropertyWebPCanvasPixelHeight")]
		NSString WebPCanvasPixelHeight { get; }

		[Mac (11, 0), iOS (14, 1), TV (14, 2), Watch (7, 1)]
		[MacCatalyst (14, 1)]
		[Field ("kCGImagePropertyTGACompression")]
		NSString TgaCompression { get; }

		[Mac (12, 0), iOS (15, 0), TV (15, 0), MacCatalyst (15, 0), Watch (8, 0)]
		[Field ("kCGImagePropertyGroupImageIndexLeft")]
		NSString GroupImageIndexLeft { get; }

		[Mac (12, 0), iOS (15, 0), TV (15, 0), MacCatalyst (15, 0), Watch (8, 0)]
		[Field ("kCGImagePropertyGroupImageIndexRight")]
		NSString GroupImageIndexRight { get; }

		[Mac (12, 0), iOS (15, 0), TV (15, 0), MacCatalyst (15, 0), Watch (8, 0)]
		[Field ("kCGImagePropertyGroupImageIsAlternateImage")]
		NSString GroupImageIsAlternateImage { get; }

		[Mac (12, 0), iOS (15, 0), TV (15, 0), MacCatalyst (15, 0), Watch (8, 0)]
		[Field ("kCGImagePropertyGroupImageIsLeftImage")]
		NSString GroupImageIsLeftImage { get; }

		[Mac (12, 0), iOS (15, 0), TV (15, 0), MacCatalyst (15, 0), Watch (8, 0)]
		[Field ("kCGImagePropertyGroupImageIsRightImage")]
		NSString GroupImageIsRightImage { get; }

		[Mac (12, 0), iOS (15, 0), TV (15, 0), MacCatalyst (15, 0), Watch (8, 0)]
		[Field ("kCGImagePropertyGroupImagesAlternate")]
		NSString GroupImagesAlternate { get; }

		[Mac (12, 0), iOS (15, 0), TV (15, 0), MacCatalyst (15, 0), Watch (8, 0)]
		[Field ("kCGImagePropertyGroupIndex")]
		NSString GroupIndex { get; }

		[Mac (12, 0), iOS (15, 0), TV (15, 0), MacCatalyst (15, 0), Watch (8, 0)]
		[Field ("kCGImagePropertyGroups")]
		NSString Groups { get; }

		[Mac (12, 0), iOS (15, 0), TV (15, 0), MacCatalyst (15, 0), Watch (8, 0)]
		[Field ("kCGImagePropertyGroupType")]
		NSString GroupType { get; }

		[Mac (12, 0), iOS (15, 0), TV (15, 0), MacCatalyst (15, 0), Watch (8, 0)]
		[Field ("kCGImagePropertyGroupTypeStereoPair")]
		NSString GroupTypeStereoPair { get; }

		[Mac (12, 0), iOS (15, 0), TV (15, 0), MacCatalyst (15, 0), Watch (8, 0)]
		[Field ("kCGImagePropertyGroupTypeAlternate")]
		NSString GroupTypeAlternate { get; }

		[iOS (16, 0), Mac (13, 0), Watch (9, 0), TV (16, 0), MacCatalyst (16, 0)]
		[Field ("kCGImagePropertyGroupImageBaseline")]
		NSString GroupImageBaseline { get; }

		[iOS (16, 0), Mac (13, 0), Watch (9, 0), TV (16, 0), MacCatalyst (16, 0)]
		[Field ("kCGImagePropertyGroupImageDisparityAdjustment")]
		NSString GroupImageDisparityAdjustment { get; }

		[iOS (16, 0), Mac (13, 0), Watch (9, 0), TV (16, 0), MacCatalyst (16, 0)]
		[Field ("kCGImagePropertyHEIFDictionary")]
		NSString HeifDictionary { get; }

		[iOS (16, 4), Mac (13, 3), Watch (9, 4), TV (16, 4), MacCatalyst (16, 4)]
		[Field ("kCGImagePropertyOpenEXRCompression")]
		NSString OpenExrCompression { get; }
	}

	[Static]
	interface CGImageMetadataTagNamespaces {
		[Field ("kCGImageMetadataNamespaceExif")]
		NSString Exif { get; }
		[Field ("kCGImageMetadataNamespaceExifAux")]
		NSString ExifAux { get; }
		[Mac (10, 9), Field ("kCGImageMetadataNamespaceExifEX")]
		[MacCatalyst (13, 1)]
		NSString ExifEx { get; }
		[Field ("kCGImageMetadataNamespaceDublinCore")]
		NSString DublinCore { get; }
		[Field ("kCGImageMetadataNamespaceIPTCCore")]
		NSString IPTCCore { get; }
		[Field ("kCGImageMetadataNamespacePhotoshop")]
		NSString Photoshop { get; }
		[Field ("kCGImageMetadataNamespaceTIFF")]
		NSString TIFF { get; }
		[Field ("kCGImageMetadataNamespaceXMPBasic")]
		NSString XMPBasic { get; }
		[Field ("kCGImageMetadataNamespaceXMPRights")]
		NSString XMPRights { get; }
		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImageMetadataNamespaceIPTCExtension")]
		NSString IPTCExtension { get; }
	}

	[Static]
	interface CGImageMetadataTagPrefixes {
		[Field ("kCGImageMetadataPrefixExif")]
		NSString Exif { get; }
		[Field ("kCGImageMetadataPrefixExifAux")]
		NSString ExifAux { get; }
		[Mac (10, 9), Field ("kCGImageMetadataPrefixExifEX")]
		[MacCatalyst (13, 1)]
		NSString ExifEx { get; }
		[Field ("kCGImageMetadataPrefixDublinCore")]
		NSString DublinCore { get; }
		[Field ("kCGImageMetadataPrefixIPTCCore")]
		NSString IPTCCore { get; }
		[Field ("kCGImageMetadataPrefixPhotoshop")]
		NSString Photoshop { get; }
		[Field ("kCGImageMetadataPrefixTIFF")]
		NSString TIFF { get; }
		[Field ("kCGImageMetadataPrefixXMPBasic")]
		NSString XMPBasic { get; }
		[Field ("kCGImageMetadataPrefixXMPRights")]
		NSString XMPRights { get; }
		[Mac (10, 13, 4)]
		[iOS (11, 3)]
		[TV (11, 3)]
		[Watch (4, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImageMetadataPrefixIPTCExtension")]
		NSString IPTCExtension { get; }
	}

	interface CGImageMetadata {
		[Field ("kCFErrorDomainCGImageMetadata")]
		NSString ErrorDomain { get; }
	}

	[Partial]
	interface CGImageOptions {
		[Internal]
		[Field ("kCGImageSourceTypeIdentifierHint")]
		IntPtr kTypeIdentifierHint { get; }

		[Internal]
		[Field ("kCGImageSourceShouldCache")]
		IntPtr kShouldCache { get; }

		[Mac (10, 9)]
		[MacCatalyst (13, 1)]
		[Internal]
		[Field ("kCGImageSourceShouldCacheImmediately")]
		IntPtr kShouldCacheImmediately { get; }

		[Internal]
		[Field ("kCGImageSourceShouldAllowFloat")]
		IntPtr kShouldAllowFloat { get; }
	}

	[Partial]
	interface CGImageThumbnailOptions {
		[Internal]
		[Field ("kCGImageSourceCreateThumbnailFromImageIfAbsent")]
		IntPtr kCreateThumbnailFromImageIfAbsent { get; }

		[Internal]
		[Field ("kCGImageSourceCreateThumbnailFromImageAlways")]
		IntPtr kCreateThumbnailFromImageAlways { get; }

		[Internal]
		[Field ("kCGImageSourceThumbnailMaxPixelSize")]
		IntPtr kThumbnailMaxPixelSize { get; }

		[Internal]
		[Field ("kCGImageSourceCreateThumbnailWithTransform")]
		IntPtr kCreateThumbnailWithTransform { get; }

		[iOS (9, 0)]
		[Mac (10, 11)]
		[MacCatalyst (13, 1)]
		[Internal]
		[Field ("kCGImageSourceSubsampleFactor")]
		IntPtr kCGImageSourceSubsampleFactor { get; }
	}

	[Partial]
	interface CGImageMetadataEnumerateOptions {
		[Internal]
		[Field ("kCGImageMetadataEnumerateRecursively")]
		IntPtr kCGImageMetadataEnumerateRecursively { get; }
	}

	// Defined in CGImageProperties.cs in CoreGraphics
	interface CGImagePropertiesTiff { }
	interface CGImagePropertiesExif { }
	interface CGImagePropertiesJfif { }
	interface CGImagePropertiesPng { }
	interface CGImagePropertiesGps { }
	interface CGImagePropertiesIptc { }

	[StrongDictionary ("CGImageDestinationOptionsKeys")]
	interface CGImageDestinationOptions {

		[Export ("LossyCompressionQuality")]
		float LossyCompressionQuality { get; set; }

		[iOS (8, 0)]
		[Mac (10, 10)]
		[MacCatalyst (13, 1)]
		[Export ("ImageMaxPixelSize")]
		int ImageMaxPixelSize { get; set; }

		[iOS (8, 0)]
		[Mac (10, 10)]
		[MacCatalyst (13, 1)]
		[Export ("EmbedThumbnail")]
		bool EmbedThumbnail { get; set; }

		[iOS (9, 3)]
		[Mac (10, 12)]
		[Watch (2, 3)]
		[MacCatalyst (13, 1)]
		[Export ("OptimizeColorForSharing")]
		bool OptimizeColorForSharing { get; set; }

		[StrongDictionary]
		[Export ("TIFFDictionary")]
		CGImagePropertiesTiff TiffDictionary { get; set; }

		[Export ("GIFDictionary")]
		NSDictionary GifDictionary { get; set; }

		[StrongDictionary]
		[Export ("JFIFDictionary")]
		CGImagePropertiesJfif JfifDictionary { get; set; }

		[StrongDictionary]
		[Export ("ExifDictionary")]
		CGImagePropertiesExif ExifDictionary { get; set; }

		[StrongDictionary]
		[Export ("PNGDictionary")]
		CGImagePropertiesPng PngDictionary { get; set; }

		[StrongDictionary]
		[Export ("IPTCDictionary")]
		CGImagePropertiesIptc IptcDictionary { get; set; }

		[StrongDictionary]
		[Export ("GPSDictionary")]
		CGImagePropertiesGps GpsDictionary { get; set; }

		[Export ("RawDictionary")]
		NSDictionary RawDictionary { get; set; }

		[Export ("CIFFDictionary")]
		NSDictionary CiffDictionary { get; set; }

		[Export ("EightBIMDictionary")]
		NSDictionary EightBimDictionary { get; set; }

		[Export ("DNGDictionary")]
		NSDictionary DngDictionary { get; set; }

		[Export ("ExifAuxDictionary")]
		NSDictionary ExifAuxDictionary { get; set; }

		[Mac (11, 0), iOS (14, 0), TV (14, 0), Watch (7, 0)]
		[MacCatalyst (14, 0)]
		[Export ("WebPDictionary")]
		NSDictionary WebPDictionary { get; set; }

		[Mac (11, 0), iOS (14, 1), TV (14, 2), Watch (7, 1)]
		[MacCatalyst (14, 1)]
		[Export ("TgaDictionary")]
		NSDictionary TgaDictionary { get; set; }

		[iOS (14, 1)]
		[TV (14, 2)]
		[Watch (7, 1)]
		[Mac (11, 0)]
		[MacCatalyst (14, 1)]
		bool PreserveGainMap { get; set; }
	}

	[Static]
	interface CGImageDestinationOptionsKeys {

		[Field ("kCGImageDestinationLossyCompressionQuality")]
		NSString LossyCompressionQuality { get; }

		[Field ("kCGImageDestinationBackgroundColor")]
		NSString BackgroundColor { get; }

		[iOS (8, 0)]
		[Mac (10, 10)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImageDestinationImageMaxPixelSize")]
		NSString ImageMaxPixelSize { get; }

		[iOS (8, 0)]
		[Mac (10, 10)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImageDestinationEmbedThumbnail")]
		NSString EmbedThumbnail { get; }

		[iOS (9, 3)]
		[Mac (10, 12)]
		[TV (9, 2)]
		[Watch (2, 3)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImageDestinationOptimizeColorForSharing")]
		NSString OptimizeColorForSharing { get; }

		// [Field ("kCGImagePropertyTIFFDictionary")]
		[Static]
		[Wrap ("CGImageProperties.TIFFDictionary")]
		NSString TIFFDictionary { get; }

		// [Field ("kCGImagePropertyGIFDictionary")]
		[Static]
		[Wrap ("CGImageProperties.GIFDictionary")]
		NSString GIFDictionary { get; }

		// [Field ("kCGImagePropertyJFIFDictionary")]
		[Static]
		[Wrap ("CGImageProperties.JFIFDictionary")]
		NSString JFIFDictionary { get; }

		// [Field ("kCGImagePropertyExifDictionary")]
		[Static]
		[Wrap ("CGImageProperties.ExifDictionary")]
		NSString ExifDictionary { get; }

		// [Field ("kCGImagePropertyPNGDictionary")]
		[Static]
		[Wrap ("CGImageProperties.PNGDictionary")]
		NSString PNGDictionary { get; }

		// [Field ("kCGImagePropertyIPTCDictionary")]
		[Static]
		[Wrap ("CGImageProperties.IPTCDictionary")]
		NSString IPTCDictionary { get; }

		// [Field ("kCGImagePropertyGPSDictionary")]
		[Static]
		[Wrap ("CGImageProperties.GPSDictionary")]
		NSString GPSDictionary { get; }

		// [Field ("kCGImagePropertyRawDictionary")]
		[Static]
		[Wrap ("CGImageProperties.RawDictionary")]
		NSString RawDictionary { get; }

		// [Field ("kCGImagePropertyCIFFDictionary")]
		[Static]
		[Wrap ("CGImageProperties.CIFFDictionary")]
		NSString CIFFDictionary { get; }

		// [Field ("kCGImageProperty8BIMDictionary")]
		[Static]
		[Wrap ("CGImageProperties.EightBIMDictionary")]
		NSString EightBIMDictionary { get; }

		// [Field ("kCGImagePropertyDNGDictionary")]
		[Static]
		[Wrap ("CGImageProperties.DNGDictionary")]
		NSString DNGDictionary { get; }

		// [Field ("kCGImagePropertyExifAuxDictionary")]
		[Static]
		[Wrap ("CGImageProperties.ExifAuxDictionary")]
		NSString ExifAuxDictionary { get; }

		[Mac (11, 0), iOS (14, 0), TV (14, 0), Watch (7, 0)]
		[MacCatalyst (14, 0)]
		[Static]
		[Wrap ("CGImageProperties.WebPDictionary")]
		NSString WebPDictionary { get; }

		[Mac (11, 0), iOS (14, 1), TV (14, 2), Watch (7, 1)]
		[MacCatalyst (14, 1)]
		[Static]
		[Wrap ("CGImageProperties.TgaDictionary")]
		NSString TgaDictionary { get; }

		[iOS (14, 1)]
		[TV (14, 2)]
		[Watch (7, 1)]
		[Mac (11, 0)]
		[MacCatalyst (14, 1)]
		[Field ("kCGImageDestinationPreserveGainMap")]
		NSString PreserveGainMapKey { get; }
	}

	[Partial]
	interface CGCopyImageSourceOptions {

		[Internal]
		[Field ("kCGImageDestinationMetadata")]
		IntPtr kMetadata { get; }

		[Internal]
		[Field ("kCGImageDestinationMergeMetadata")]
		IntPtr kMergeMetadata { get; }

		[Internal]
		[Field ("kCGImageMetadataShouldExcludeXMP")]
		IntPtr kShouldExcludeXMP { get; }

		[iOS (8, 0)]
		[Mac (10, 10)]
		[MacCatalyst (13, 1)]
		[Internal]
		[Field ("kCGImageMetadataShouldExcludeGPS")]
		IntPtr kShouldExcludeGPS { get; }

		[Internal]
		[Field ("kCGImageDestinationDateTime")]
		IntPtr kDateTime { get; }

		[Internal]
		[Field ("kCGImageDestinationOrientation")]
		IntPtr kOrientation { get; }
	}

	[Mac (10, 13), iOS (11, 0), TV (11, 0), Watch (4, 0)]
	[MacCatalyst (13, 1)]
	enum CGImageAuxiliaryDataType {
		[Field ("kCGImageAuxiliaryDataTypeDepth")]
		Depth,

		[Field ("kCGImageAuxiliaryDataTypeDisparity")]
		Disparity,

		[Watch (5, 0), Mac (10, 14), iOS (12, 0), TV (12, 0)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImageAuxiliaryDataTypePortraitEffectsMatte")]
		PortraitEffectsMatte,

		[iOS (13, 0)]
		[TV (13, 0)]
		[Watch (6, 0)]
		[Mac (10, 15)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImageAuxiliaryDataTypeSemanticSegmentationHairMatte")]
		SemanticSegmentationHairMatte,

		[iOS (13, 0)]
		[TV (13, 0)]
		[Watch (6, 0)]
		[Mac (10, 15)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImageAuxiliaryDataTypeSemanticSegmentationSkinMatte")]
		SemanticSegmentationSkinMatte,

		[iOS (13, 0)]
		[TV (13, 0)]
		[Watch (6, 0)]
		[Mac (10, 15)]
		[MacCatalyst (13, 1)]
		[Field ("kCGImageAuxiliaryDataTypeSemanticSegmentationTeethMatte")]
		SemanticSegmentationTeethMatte,

		[iOS (14, 1)]
		[TV (14, 2)]
		[Watch (7, 1)]
		[Mac (11, 0)]
		[MacCatalyst (14, 1)]
		[Field ("kCGImageAuxiliaryDataTypeSemanticSegmentationGlassesMatte")]
		SemanticSegmentationGlassesMatte,

		[iOS (14, 1)]
		[TV (14, 2)]
		[Watch (7, 1)]
		[Mac (11, 0)]
		[MacCatalyst (14, 1)]
		[Field ("kCGImageAuxiliaryDataTypeHDRGainMap")]
		TypeHdrGainMap,

		[iOS (14, 3)]
		[TV (14, 3)]
		[Watch (7, 2)]
		[Mac (11, 1)]
		[MacCatalyst (14, 3)]
		[Field ("kCGImageAuxiliaryDataTypeSemanticSegmentationSkyMatte")]
		SemanticSegmentationSkyMatte,
	}

	[Mac (10, 13), iOS (11, 0), TV (11, 0), Watch (4, 0)]
	[MacCatalyst (13, 1)]
	[Static]
	[Internal]
	interface CGImageAuxiliaryDataInfoKeys {
		[Field ("kCGImageAuxiliaryDataInfoData")]
		NSString DataKey { get; }

		[Field ("kCGImageAuxiliaryDataInfoDataDescription")]
		NSString DataDescriptionKey { get; }

		[Field ("kCGImageAuxiliaryDataInfoMetadata")]
		NSString MetadataKey { get; }
	}

	[Mac (10, 13), iOS (11, 0), TV (11, 0), Watch (4, 0)]
	[MacCatalyst (13, 1)]
	[StrongDictionary ("CGImageAuxiliaryDataInfoKeys")]
	interface CGImageAuxiliaryDataInfo {

		NSData Data { get; set; }
		NSDictionary DataDescription { get; set; }
	}

	[Mac (10, 15), iOS (13, 0), TV (13, 0), Watch (6, 0)]
	[MacCatalyst (13, 1)]
	[Static]
	[Internal]
	interface CGImageAnimationOptionsKeys {
		[Field ("kCGImageAnimationDelayTime")]
		NSString DelayTimeKey { get; }

		[Field ("kCGImageAnimationLoopCount")]
		NSString LoopCountKey { get; }

		[Field ("kCGImageAnimationStartIndex")]
		NSString StartIndexKey { get; }
	}

	[Mac (10, 15), iOS (13, 0), TV (13, 0), Watch (6, 0)]
	[MacCatalyst (13, 1)]
	[StrongDictionary ("CGImageAnimationOptionsKeys")]
	interface CGImageAnimationOptions {
		double DelayTime { get; set; }

		nuint LoopCount { get; set; }

		nuint StartIndex { get; set; }
	}

	[Static]
	[iOS (16, 0), Mac (13, 0), Watch (9, 0), TV (16, 0), MacCatalyst (16, 0)]
	interface IOCameraExtrinsics {
		[Field ("kIIOCameraExtrinsics_CoordinateSystemID")]
		NSString CoordinateSystemId { get; }

		[Field ("kIIOCameraExtrinsics_Position")]
		NSString Position { get; }

		[Field ("kIIOCameraExtrinsics_Rotation")]
		NSString Rotation { get; }
	}

	[Static]
	[iOS (16, 0), Mac (13, 0), Watch (9, 0), TV (16, 0), MacCatalyst (16, 0)]
	interface IOCameraModel {
		[Field ("kIIOCameraModel_Intrinsics")]
		NSString Intrinsics { get; }

		[Mac (13, 0), iOS (16, 0)]
		[MacCatalyst (16, 0)]
		[Field ("kIIOCameraModel_ModelType")]
		NSString ModelType { get; }
	}

	[Static]
	[iOS (16, 0), Mac (13, 0), Watch (9, 0), TV (16, 0), MacCatalyst (16, 0)]
	interface IOCameraModelType {
		[Field ("kIIOCameraModelType_SimplifiedPinhole")]
		NSString SimplifiedPinhole { get; }

		[Field ("kIIOCameraModelType_GenericPinhole")]
		NSString GenericPinhole { get; }
	}

	[Static]
	[iOS (16, 0), Mac (13, 0), Watch (9, 0), TV (16, 0), MacCatalyst (16, 0)]
	interface IOMetadata {
		[Field ("kIIOMetadata_CameraExtrinsicsKey")]
		NSString CameraExtrinsicsKey { get; }

		[Field ("kIIOMetadata_CameraModelKey")]
		NSString CameraModelKey { get; }
	}
}
