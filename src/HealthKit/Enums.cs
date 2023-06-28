using CoreFoundation;
using ObjCRuntime;
using Foundation;
using System;

namespace HealthKit {
	// NSInteger -> HKDefines.h
	[iOS (8, 0)]
	[Mac (13, 0)]
	[MacCatalyst (13, 1)]
	[Native]
	public enum HKUpdateFrequency : long {
		Immediate = 1,
		Hourly,
		Daily,
		Weekly
	}

	// NSInteger -> HKDefines.h
	[iOS (8, 0)]
	[Mac (13, 0)]
	[MacCatalyst (13, 1)]
	[Native]
	public enum HKAuthorizationStatus : long {
		NotDetermined = 0,
		SharingDenied,
		SharingAuthorized
	}

	// NSInteger -> HKDefines.h
	[iOS (8, 0)]
	[Mac (13, 0)]
	[MacCatalyst (13, 1)]
	[Native]
	public enum HKBiologicalSex : long {
		NotSet = 0,
		Female,
		Male,
		[iOS (8, 2)]
		[MacCatalyst (13, 1)]
		Other
	}

	// NSInteger -> HKDefines.h
	[iOS (8, 0)]
	[Mac (13, 0)]
	[MacCatalyst (13, 1)]
	[Native]
	public enum HKBloodType : long {
		NotSet = 0,
		APositive,
		ANegative,
		BPositive,
		BNegative,
		ABPositive,
		ABNegative,
		OPositive,
		ONegative
	}

	// NSInteger -> HKMetadata.h
	[iOS (8, 0)]
	[Mac (13, 0)]
	[MacCatalyst (13, 1)]
	[Native]
	public enum HKBodyTemperatureSensorLocation : long {
		Other = 0,
		Armpit,
		Body,
		Ear,
		Finger,
		GastroIntestinal,
		Mouth,
		Rectum,
		Toe,
		EarDrum,
		TemporalArtery,
		Forehead
	}

	// NSInteger -> HKMetadata.h
	[iOS (8, 0)]
	[Mac (13, 0)]
	[MacCatalyst (13, 1)]
	[Native]
	public enum HKHeartRateSensorLocation : long {
		Other = 0,
		Chest,
		Wrist,
		Finger,
		Hand,
		EarLobe,
		Foot
	}

	// NSInteger -> HKObjectType.h
	[iOS (8, 0)]
	[Mac (13, 0)]
	[MacCatalyst (13, 1)]
	[Native]
	public enum HKQuantityAggregationStyle : long {
		Cumulative = 0,
		[iOS (13, 0), Watch (6, 0)]
		[MacCatalyst (13, 1)]
		DiscreteArithmetic,
		[Deprecated (PlatformName.WatchOS, 6, 0, message: "Use 'HKQuantityAggregationStyle.DiscreteArithmetic'.")]
		[Deprecated (PlatformName.iOS, 13, 0, message: "Use 'HKQuantityAggregationStyle.DiscreteArithmetic'.")]
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use 'HKQuantityAggregationStyle.DiscreteArithmetic'.")]
		Discrete = DiscreteArithmetic,
		[iOS (13, 0), Watch (6, 0)]
		[MacCatalyst (13, 1)]
		DiscreteTemporallyWeighted,
		[iOS (13, 0), Watch (6, 0)]
		[MacCatalyst (13, 1)]
		DiscreteEquivalentContinuousLevel,
	}

	// NSInteger -> HKObjectType.h
	[iOS (8, 0)]
	[Mac (13, 0)]
	[MacCatalyst (13, 1)]
	[Native]
	public enum HKCategoryValueSleepAnalysis : long {
		InBed,
		Asleep,
		[Watch (3, 0), iOS (10, 0)]
		[MacCatalyst (13, 1)]
		Awake,
		[Watch (9, 0), MacCatalyst (16, 0), Mac (13, 0), iOS (16, 0), NoTV]
		AsleepCore = 3,
		[Watch (9, 0), MacCatalyst (16, 0), Mac (13, 0), iOS (16, 0), NoTV]
		AsleepDeep = 4,
		[Watch (9, 0), MacCatalyst (16, 0), Mac (13, 0), iOS (16, 0), NoTV]
		AsleepREM = 5,
	}

	// NSUInteger -> HKQuery.h
	[iOS (8, 0)]
	[Mac (13, 0)]
	[MacCatalyst (13, 1)]
	[Native]
	[Flags]
	public enum HKQueryOptions : ulong {
		None = 0,
		StrictStartDate = 1 << 0,
		StrictEndDate = 1 << 1
	}

	// NSUInteger -> HKStatistics.h
	[iOS (8, 0)]
	[Mac (13, 0)]
	[MacCatalyst (13, 1)]
	[Native]
	[Flags]
	public enum HKStatisticsOptions : ulong {
		None = 0,
		SeparateBySource = 1 << 0,
		DiscreteAverage = 1 << 1,
		DiscreteMin = 1 << 2,
		DiscreteMax = 1 << 3,
		CumulativeSum = 1 << 4,
		[iOS (13, 0), Watch (6, 0)]
		[MacCatalyst (13, 1)]
		MostRecent = 1 << 5,
		[iOS (13, 0), Watch (6, 0)]
		[MacCatalyst (13, 1)]
		Duration = 1 << 6,
	}

	// NSInteger -> HKUnit.h
	[iOS (8, 0)]
	[Mac (13, 0)]
	[MacCatalyst (13, 1)]
	[Native]
	public enum HKMetricPrefix : long {
		None = 0,
		Pico,
		Nano,
		Micro,
		Milli,
		Centi,
		Deci,
		Deca,
		Hecto,
		Kilo,
		Mega,
		Giga,
		Tera,
		[iOS (13, 0), Watch (6, 0)]
		[MacCatalyst (13, 1)]
		Femto,
	}

	[Native]
	[iOS (8, 0)]
	[Mac (13, 0)]
	[MacCatalyst (13, 1)]
	public enum HKWorkoutActivityType : ulong {
		AmericanFootball = 1,
		Archery,
		AustralianFootball,
		Badminton,
		Baseball,
		Basketball,
		Bowling,
		Boxing,
		Climbing,
		Cricket,
		CrossTraining,
		Curling,
		Cycling,
		Dance,
		[Deprecated (PlatformName.WatchOS, 3, 0, message: "Use 'HKWorkoutActivityType.Dance', 'HKWorkoutActivityType.Barre', or 'HKWorkoutActivityType.Pilates'.")]
		[Deprecated (PlatformName.iOS, 10, 0, message: "Use 'HKWorkoutActivityType.Dance', 'HKWorkoutActivityType.Barre', or 'HKWorkoutActivityType.Pilates'.")]
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use 'HKWorkoutActivityType.Dance', 'HKWorkoutActivityType.Barre', or 'HKWorkoutActivityType.Pilates'.")]
		DanceInspiredTraining,
		Elliptical,
		EquestrianSports,
		Fencing,
		Fishing,
		FunctionalStrengthTraining,
		Golf,
		Gymnastics,
		Handball,
		Hiking,
		Hockey,
		Hunting,
		Lacrosse,
		MartialArts,
		MindAndBody,
		[Deprecated (PlatformName.iOS, 11, 0, message: "Use 'MixedCardio' or 'HighIntensityIntervalTraining' instead.")]
		[Deprecated (PlatformName.WatchOS, 4, 0, message: "Use 'MixedCardio' or 'HighIntensityIntervalTraining' instead.")]
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use 'MixedCardio' or 'HighIntensityIntervalTraining' instead.")]
		MixedMetabolicCardioTraining,
		PaddleSports,
		Play,
		PreparationAndRecovery,
		Racquetball,
		Rowing,
		Rugby,
		Running,
		Sailing,
		SkatingSports,
		SnowSports,
		Soccer,
		Softball,
		Squash,
		StairClimbing,
		SurfingSports,
		Swimming,
		TableTennis,
		Tennis,
		TrackAndField,
		TraditionalStrengthTraining,
		Volleyball,
		Walking,
		WaterFitness,
		WaterPolo,
		WaterSports,
		Wrestling,
		Yoga,
		[iOS (10, 0), Watch (3, 0)]
		[MacCatalyst (13, 1)]
		Barre,
		[iOS (10, 0), Watch (3, 0)]
		[MacCatalyst (13, 1)]
		CoreTraining,
		[iOS (10, 0), Watch (3, 0)]
		[MacCatalyst (13, 1)]
		CrossCountrySkiing,
		[iOS (10, 0), Watch (3, 0)]
		[MacCatalyst (13, 1)]
		DownhillSkiing,
		[iOS (10, 0), Watch (3, 0)]
		[MacCatalyst (13, 1)]
		Flexibility,
		[iOS (10, 0), Watch (3, 0)]
		[MacCatalyst (13, 1)]
		HighIntensityIntervalTraining,
		[iOS (10, 0), Watch (3, 0)]
		[MacCatalyst (13, 1)]
		JumpRope,
		[iOS (10, 0), Watch (3, 0)]
		[MacCatalyst (13, 1)]
		Kickboxing,
		[iOS (10, 0), Watch (3, 0)]
		[MacCatalyst (13, 1)]
		Pilates,
		[iOS (10, 0), Watch (3, 0)]
		[MacCatalyst (13, 1)]
		Snowboarding,
		[iOS (10, 0), Watch (3, 0)]
		[MacCatalyst (13, 1)]
		Stairs,
		[iOS (10, 0), Watch (3, 0)]
		[MacCatalyst (13, 1)]
		StepTraining,
		[iOS (10, 0), Watch (3, 0)]
		[MacCatalyst (13, 1)]
		WheelchairWalkPace,
		[iOS (10, 0), Watch (3, 0)]
		[MacCatalyst (13, 1)]
		WheelchairRunPace,
		[iOS (11, 0), Watch (4, 0)]
		[MacCatalyst (13, 1)]
		TaiChi,
		[iOS (11, 0), Watch (4, 0)]
		[MacCatalyst (13, 1)]
		MixedCardio,
		[iOS (11, 0), Watch (4, 0)]
		[MacCatalyst (13, 1)]
		HandCycling,
		[iOS (13, 0), Watch (6, 0)]
		[MacCatalyst (13, 1)]
		DiscSports,
		[iOS (13, 0), Watch (6, 0)]
		[MacCatalyst (13, 1)]
		FitnessGaming,
		[iOS (14, 0)]
		[Watch (7, 0)]
		[MacCatalyst (14, 0)]
		CardioDance = 77,
		[iOS (14, 0)]
		[Watch (7, 0)]
		[MacCatalyst (14, 0)]
		SocialDance = 78,
		[iOS (14, 0)]
		[Watch (7, 0)]
		[MacCatalyst (14, 0)]
		Pickleball = 79,
		[iOS (14, 0)]
		[Watch (7, 0)]
		[MacCatalyst (14, 0)]
		Cooldown = 80,
		[Watch (9, 0), MacCatalyst (16, 0), Mac (13, 0), iOS (16, 0), NoTV]
		SwimBikeRun = 82,
		[Watch (9, 0), MacCatalyst (16, 0), Mac (13, 0), iOS (16, 0), NoTV]
		Transition = 83,
		[iOS (8, 2)]
		[MacCatalyst (13, 1)]
		Other = 3000
	}

	[Native]
	[iOS (8, 0)]
	[Mac (13, 0)]
	[MacCatalyst (13, 1)]
	public enum HKWorkoutEventType : long {
		Pause = 1,
		Resume,
		[iOS (10, 0), Watch (3, 0)]
		[MacCatalyst (13, 1)]
		Lap,
		[iOS (10, 0), Watch (3, 0)]
		[MacCatalyst (13, 1)]
		Marker,
		[iOS (10, 0), Watch (3, 0)]
		[MacCatalyst (13, 1)]
		MotionPaused,
		[iOS (10, 0), Watch (3, 0)]
		[MacCatalyst (13, 1)]
		MotionResumed,
		[iOS (11, 0), Watch (4, 0)]
		[MacCatalyst (13, 1)]
		Segment,
		[iOS (11, 0), Watch (4, 0)]
		[MacCatalyst (13, 1)]
		PauseOrResumeRequest,
	}

	[iOS (9, 0)]
	[Mac (13, 0)]
	[MacCatalyst (13, 1)]
	[Native]
	public enum HKCategoryValue : long {
		NotApplicable = 0
	}

	[iOS (9, 0)]
	[Mac (13, 0)]
	[MacCatalyst (13, 1)]
	[Native]
	public enum HKCategoryValueCervicalMucusQuality : long {
		NotApplicable = 0,
		Dry = 1,
		Sticky,
		Creamy,
		Watery,
		EggWhite
	}

	[iOS (9, 0)]
	[Mac (13, 0)]
	[MacCatalyst (13, 1)]
	[Native]
	public enum HKCategoryValueMenstrualFlow : long {
		NotApplicable = 0,
		Unspecified = 1,
		Light,
		Medium,
		Heavy,
		[iOS (12, 0)]
		[Watch (5, 0)]
		[MacCatalyst (13, 1)]
		None,
	}

	[iOS (9, 0)]
	[Mac (13, 0)]
	[MacCatalyst (13, 1)]
	[Native]
	public enum HKCategoryValueOvulationTestResult : long {
		NotApplicable = 0,
		Negative = 1,
		[iOS (13, 0), Watch (6, 0)]
		[MacCatalyst (13, 1)]
		LuteinizingHormoneSurge = 2,
		[Deprecated (PlatformName.iOS, 13, 0, message: "Use 'HKCategoryValueOvulationTestResult.LuteinizingHormoneSurge' instead.")]
		[Deprecated (PlatformName.WatchOS, 6, 0, message: "Use 'HKCategoryValueOvulationTestResult.LuteinizingHormoneSurge' instead.")]
		[Deprecated (PlatformName.MacCatalyst, 13, 1, message: "Use 'HKCategoryValueOvulationTestResult.LuteinizingHormoneSurge' instead.")]
		Positive = LuteinizingHormoneSurge,
		Indeterminate = 3,
		[iOS (13, 0), Watch (6, 0)]
		[MacCatalyst (13, 1)]
		EstrogenSurge = 4,
	}

	[iOS (9, 0)]
	[Mac (13, 0)]
	[MacCatalyst (13, 1)]
	[Native]
	public enum HKCategoryValueAppleStandHour : long {
		Stood = 0,
		Idle
	}

	[iOS (13, 0)]
	[Watch (6, 0)]
	[Mac (13, 0)]
	[MacCatalyst (13, 1)]
	[Native]
	public enum HKCategoryValueAudioExposureEvent : long {
		LoudEnvironment = 1,
	}

	[iOS (9, 0)]
	[Mac (13, 0)]
	[MacCatalyst (13, 1)]
	[Native]
	public enum HKFitzpatrickSkinType : long {
		NotSet = 0,
		I,
		II,
		III,
		IV,
		V,
		VI
	}

	[Watch (3, 0), iOS (10, 0), Mac (13, 0)]
	[MacCatalyst (13, 1)]
	[Native]
	public enum HKWheelchairUse : long {
		NotSet = 0,
		No,
		Yes,
	}

	[Watch (3, 0), iOS (10, 0), Mac (13, 0)]
	[MacCatalyst (13, 1)]
	[Native]
	public enum HKWeatherCondition : long {
		None = 0,
		Clear,
		Fair,
		PartlyCloudy,
		MostlyCloudy,
		Cloudy,
		Foggy,
		Haze,
		Windy,
		Blustery,
		Smoky,
		Dust,
		Snow,
		Hail,
		Sleet,
		FreezingDrizzle,
		FreezingRain,
		MixedRainAndHail,
		MixedRainAndSnow,
		MixedRainAndSleet,
		MixedSnowAndSleet,
		Drizzle,
		ScatteredShowers,
		Showers,
		Thunderstorms,
		TropicalStorm,
		Hurricane,
		Tornado,
	}

	[Watch (3, 0), iOS (10, 0), Mac (13, 0)]
	[MacCatalyst (13, 1)]
	[Native]
	public enum HKWorkoutSwimmingLocationType : long {
		Unknown = 0,
		Pool,
		OpenWater,
	}

	[Watch (3, 0), iOS (10, 0), Mac (13, 0)]
	[MacCatalyst (13, 1)]
	[Native]
	public enum HKSwimmingStrokeStyle : long {
		Unknown = 0,
		Mixed,
		Freestyle,
		Backstroke,
		Breaststroke,
		Butterfly,
		[Watch (9, 0), MacCatalyst (16, 0), Mac (13, 0), iOS (16, 0), NoTV]
		Kickboard = 6,
	}

	[Watch (4, 0), iOS (11, 0), Mac (13, 0)]
	[MacCatalyst (13, 1)]
	[Native]
	public enum HKInsulinDeliveryReason : long {
		Basal = 1,
		Bolus,
#if !NET
		[Obsolete ("Use 'Basal' instead.")]
		Asal = Basal,
		[Obsolete ("Use 'Bolus' instead.")]
		Olus = Bolus,
#endif
	}

	[Watch (4, 0), iOS (11, 0), Mac (13, 0)]
	[MacCatalyst (13, 1)]
	[Native]
	public enum HKBloodGlucoseMealTime : long {
		Preprandial = 1,
		Postprandial,
#if !NET
		[Obsolete ("Use 'Preprandial' instead.")]
		Reprandial = Preprandial,
		[Obsolete ("Use 'Postprandial' instead.")]
		Ostprandial = Postprandial,
#endif
	}

	[Watch (4, 0), iOS (11, 0), Mac (13, 0)]
	[MacCatalyst (13, 1)]
	[Native]
	public enum HKVO2MaxTestType : long {
		MaxExercise = 1,
		PredictionSubMaxExercise,
		PredictionNonExercise,
	}

	[NoWatch, iOS (12, 0), Mac (13, 0)]
	[MacCatalyst (13, 1)]
	public enum HKFhirResourceType {
		[Field ("HKFHIRResourceTypeAllergyIntolerance")]
		AllergyIntolerance,
		[Field ("HKFHIRResourceTypeCondition")]
		Condition,
		[Field ("HKFHIRResourceTypeImmunization")]
		Immunization,
		[Field ("HKFHIRResourceTypeMedicationDispense")]
		MedicationDispense,
		[Field ("HKFHIRResourceTypeMedicationOrder")]
		MedicationOrder,
		[Field ("HKFHIRResourceTypeMedicationStatement")]
		MedicationStatement,
		[Field ("HKFHIRResourceTypeObservation")]
		Observation,
		[Field ("HKFHIRResourceTypeProcedure")]
		Procedure,
		[iOS (14, 0)]
		[MacCatalyst (14, 0)]
		[Field ("HKFHIRResourceTypeMedicationRequest")]
		MedicationRequest,
		[iOS (14, 0)]
		[MacCatalyst (14, 0)]
		[Field ("HKFHIRResourceTypeCoverage")]
		Coverage,
		[iOS (16, 4), MacCatalyst (16, 4), Mac (13, 3)]
		[Field ("HKFHIRResourceTypeDiagnosticReport")]
		DiagnosticReport,
		[iOS (16, 4), MacCatalyst (16, 4), Mac (13, 3)]
		[Field ("HKFHIRResourceTypeDocumentReference")]
		DocumentReference,
	}

	[Watch (5, 0), iOS (12, 0), Mac (13, 0)]
	[MacCatalyst (13, 1)]
	public enum HKClinicalTypeIdentifier {

		[Field ("HKClinicalTypeIdentifierAllergyRecord")]
		AllergyRecord,
		[Field ("HKClinicalTypeIdentifierConditionRecord")]
		ConditionRecord,
		[Field ("HKClinicalTypeIdentifierImmunizationRecord")]
		ImmunizationRecord,
		[Field ("HKClinicalTypeIdentifierLabResultRecord")]
		LabResultRecord,
		[Field ("HKClinicalTypeIdentifierMedicationRecord")]
		MedicationRecord,
		[Field ("HKClinicalTypeIdentifierProcedureRecord")]
		ProcedureRecord,
		[Field ("HKClinicalTypeIdentifierVitalSignRecord")]
		VitalSignRecord,
		[Watch (7, 0), iOS (14, 0)]
		[MacCatalyst (14, 0)]
		[Field ("HKClinicalTypeIdentifierCoverageRecord")]
		CoverageRecord,
		[Watch (9, 4), iOS (16, 4), Mac (13, 3)]
		[MacCatalyst (16, 4)]
		[Field ("HKClinicalTypeIdentifierClinicalNoteRecord")]
		ClinicalNoteRecord,
	}

	[Watch (5, 0), iOS (12, 0), Mac (13, 0)]
	[MacCatalyst (13, 1)]
	[Native]
	public enum HKAuthorizationRequestStatus : long {
		Unknown = 0,
		ShouldRequest,
		Unnecessary,
	}

	[Watch (7, 0), iOS (13, 6), Mac (13, 0)]
	[MacCatalyst (13, 1)]
	[Native]
	public enum HKCategoryValueAppetiteChanges : long {
		Unspecified = 0,
		NoChange,
		Decreased,
		Increased,
	}

	[Watch (7, 0), iOS (14, 0), Mac (13, 0)]
	[MacCatalyst (14, 0)]
	[Native]
	public enum HKAppleEcgAlgorithmVersion : long {
		Version1 = 1,
		Version2 = 2,
	}

	[Watch (7, 0), iOS (14, 0), Mac (13, 0)]
	[MacCatalyst (14, 0)]
	[Native]
	public enum HKCategoryValueEnvironmentalAudioExposureEvent : long {
		MomentaryLimit = 1,
	}

	[Watch (7, 0), iOS (13, 6), Mac (13, 0)]
	[MacCatalyst (13, 1)]
	[Native]
	public enum HKCategoryValuePresence : long {
		Present = 0,
		NotPresent,
	}

	[Watch (7, 0), iOS (13, 6), Mac (13, 0)]
	[MacCatalyst (13, 1)]
	[Native]
	public enum HKCategoryValueSeverity : long {
		Unspecified = 0,
		NotPresent,
		Mild,
		Moderate,
		Severe,
	}

	[Watch (7, 0), iOS (14, 0), Mac (13, 0)]
	[MacCatalyst (14, 0)]
	[Native]
	public enum HKDevicePlacementSide : long {
		Unknown = 0,
		Left,
		Right,
		Central,
	}

	[Watch (7, 0), iOS (14, 0), Mac (13, 0)]
	[MacCatalyst (14, 0)]
	[Native]
	public enum HKElectrocardiogramClassification : long {
		NotSet = 0,
		SinusRhythm,
		AtrialFibrillation,
		InconclusiveLowHeartRate,
		InconclusiveHighHeartRate,
		InconclusivePoorReading,
		InconclusiveOther,
		Unrecognized = 100,
	}

	[Watch (7, 0), iOS (14, 0), Mac (13, 0)]
	[MacCatalyst (14, 0)]
	[Native]
	public enum HKElectrocardiogramLead : long {
		AppleWatchSimilarToLeadI = 1,
	}

	[Watch (7, 0), iOS (14, 0), Mac (13, 0)]
	[MacCatalyst (14, 0)]
	[Native]
	public enum HKElectrocardiogramSymptomsStatus : long {
		NotSet = 0,
		None = 1,
		Present = 2,
	}

	[NoWatch, iOS (14, 0), Mac (13, 0)]
	[MacCatalyst (14, 0)]
	public enum HKFhirRelease {
		[Field ("HKFHIRReleaseDSTU2")]
		Dstu2,
		[Field ("HKFHIRReleaseR4")]
		R4,
		[Field ("HKFHIRReleaseUnknown")]
		Unknown,
	}

	[Watch (9, 0), MacCatalyst (16, 0), Mac (13, 0), iOS (16, 0), NoTV]
	[Native]
	public enum HKHeartRateRecoveryTestType : long {
		MaxExercise = 1,
		PredictionSubMaxExercise,
		PredictionNonExercise,
	}

	[Watch (9, 0), MacCatalyst (16, 0), Mac (13, 0), iOS (16, 0), NoTV]
	[Native]
	public enum HKPrismBase : long {
		None = 0,
		Up,
		Down,
		In,
		Out,
	}

	[Watch (9, 0), MacCatalyst (16, 0), Mac (13, 0), iOS (16, 0), NoTV]
	[Native]
	public enum HKUserMotionContext : long {
		NotSet = 0,
		Stationary,
		Active,
	}

	[Watch (9, 0), MacCatalyst (16, 0), Mac (13, 0), iOS (16, 0), NoTV]
	[Native]
	public enum HKVisionEye : long {
		Left = 1,
		Right,
	}

	[Watch (9, 0), MacCatalyst (16, 0), Mac (13, 0), iOS (16, 0), NoTV]
	[Native]
	public enum HKVisionPrescriptionType : ulong {
		Glasses = 1,
		Contacts,
	}
}
