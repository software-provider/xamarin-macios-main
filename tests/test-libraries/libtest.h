#import <Foundation/Foundation.h>
#include <simd/simd.h>
#include <libkern/OSAtomic.h>

#include "rename.h"

#if !TARGET_OS_WATCH
#import <ModelIO/ModelIO.h>
#endif

#import <SceneKit/SceneKit.h>

#ifdef __cplusplus
extern "C" {
#endif

int theUltimateAnswer ();
void useZLib ();

typedef void (^x_block_callback)();
void x_call_block (x_block_callback block);
void* x_call_func_3 (void* (*fptr)(void*, void*, void*), void* p1, void* p2, void* p3);

void x_get_matrix_float2x2 (id self, const char *sel, float* r0c0, float* r0c1, float* r1c0, float* r1c1);
void x_get_matrix_float3x3 (id self, const char *sel, float* r0c0, float* r0c1, float* r0c2, float* r1c0, float* r1c1, float* r1c2, float* r2c0, float* r2c1, float* r2c2);
void x_get_matrix_float4x4 (id self, const char *sel, float* r0c0, float* r0c1, float* r0c2, float* r0c3, float* r1c0, float* r1c1, float* r1c2, float* r1c3, float* r2c0, float* r2c1, float* r2c2, float* r2c3, float* r3c0, float* r3c1, float* r3c2, float* r3c3);
void x_get_matrix_float4x3 (id self, const char *sel, float* r0c0, float* r0c1, float* r0c2, float* r0c3, float* r1c0, float* r1c1, float* r1c2, float* r1c3, float* r2c0, float* r2c1, float* r2c2, float* r2c3);

#if !TARGET_OS_WATCH
void x_mdltransformcomponent_get_local_transform (id<MDLTransformComponent> self, NSTimeInterval time, float* r0c0, float* r0c1, float* r0c2, float* r0c3, float* r1c0, float* r1c1, float* r1c2, float* r1c3, float* r2c0, float* r2c1, float* r2c2, float* r2c3, float* r3c0, float* r3c1, float* r3c2, float* r3c3);
void x_mdltransform_create_global_transform (MDLObject *object, NSTimeInterval time, float* r0c0, float* r0c1, float* r0c2, float* r0c3, float* r1c0, float* r1c1, float* r1c2, float* r1c3, float* r2c0, float* r2c1, float* r2c2, float* r2c3, float* r3c0, float* r3c1, float* r3c2, float* r3c3);
void x_mdltransform_get_rotation_matrix (MDLTransform *self, NSTimeInterval time, float* r0c0, float* r0c1, float* r0c2, float* r0c3, float* r1c0, float* r1c1, float* r1c2, float* r1c3, float* r2c0, float* r2c1, float* r2c2, float* r2c3, float* r3c0, float* r3c1, float* r3c2, float* r3c3);
#endif

#if TARGET_OS_OSX
#define pfloat CGFloat
#else
#define pfloat float
#endif

SCNMatrix4 x_SCNMatrix4MakeTranslation (pfloat tx, pfloat ty, pfloat tz);
SCNMatrix4 x_SCNMatrix4MakeScale (pfloat tx, pfloat ty, pfloat tz);
SCNMatrix4 x_SCNMatrix4Translate (SCNMatrix4 m, pfloat tx, pfloat ty, pfloat tz);

/*
 * Various structs used in ObjCRegistrarTest
 */

#include "libtest.structs.h"

typedef unsigned int (^RegistrarTestBlock) (unsigned int magic);

/*
 * ObjC test class used for registrar tests.
 */
@interface ObjCRegistrarTest : NSObject {
}
	@property int Pi1;
	@property int Pi2;
	@property int Pi3;
	@property int Pi4;
	@property int Pi5;
	@property int Pi6;
	@property int Pi7;
	@property int Pi8;
	@property int Pi9;
	@property float Pf1;
	@property float Pf2;
	@property float Pf3;
	@property float Pf4;
	@property float Pf5;
	@property float Pf6;
	@property float Pf7;
	@property float Pf8;
	@property float Pf9;
	@property double Pd1;
	@property double Pd2;
	@property double Pd3;
	@property double Pd4;
	@property double Pd5;
	@property double Pd6;
	@property double Pd7;
	@property double Pd8;
	@property double Pd9;
	@property char Pc1;
	@property char Pc2;
	@property char Pc3;
	@property char Pc4;
	@property char Pc5;

	@property (nonatomic, retain) NSObject* someObject;
	@property (nonatomic, retain) NSArray* someArray;
#include "libtest.properties.h"

	-(void) V;
	+(void) staticV;

	-(float) F;
	-(double) D;
	-(struct Sd) Sd;
	-(struct Sf) Sf;

	-(void) V:(int)i1 i:(int)i2 i:(int)i3 i:(int)i4 i:(int)i5 i:(int)i6 i:(int)i7; // 6 in regs, 7th in mem.
	-(void) V:(float)f1 f:(float)f2 f:(float)f3 f:(float)f4 f:(float)f5 f:(float)f6 f:(float)f7 f:(float)f8 f:(float)f9; // 8 in regs, 9th in mem.
	-(void) V:(int)i1 i:(int)i2 i:(int)i3 i:(int)i4 i:(int)i5 i:(int)i6 i:(int)i7 f:(float)f1 f:(float)f2 f:(float)f3 f:(float)f4 f:(float)f5 f:(float)f6 f:(float)f7 f:(float)f8 f:(float)f9; // 6 ints in regs, 8 floats in in regs, 1 int in mem, 1 float in mem.
	-(void) V:(double)d1 d:(double)d2 d:(double)d3 d:(double)d4 d:(double)d5 d:(double)d6 d:(double)d7 d:(double)d8 d:(double)d9; // 8 in regs, 9th in mem.
	-(void) V:(int)i1 i:(int)i2 Siid:(struct Siid)Siid1 i:(int)i3 i:(int)i4 d:(double)d1 d:(double)d2 d:(double)d3 i:(int)i5 i:(int)i6 i:(int)i7; 
	-(void) V:(int)i1 i:(int)i2 f:(float)f1 Siid:(struct Siid)Siid1 i:(int)i3 i:(int)i4 d:(double)d1 d:(double)d2 d:(double)d3 i:(int)i5 i:(int)i6 i:(int)i7;
	-(void) V:(char)c1 c:(char)c2 c:(char)c3 c:(char)c4 c:(char)c5 i:(int)i1 d:(double)d1;



	-(void) invoke_V;
	-(float) invoke_F;
	-(double) invoke_D;

	-(struct Sf) Sf_invoke;

	-(RegistrarTestBlock) methodReturningBlock;
	@property (nonatomic, readonly) RegistrarTestBlock propertyReturningBlock;
	-(bool) testBlocks;

	-(void) idAsIntPtr: (id)p1;

#include "libtest.methods.h"

	-(void) outNSErrorOnStack:(int)i1 i:(int)i2 i:(int)i3 i:(int)i4 i:(int)i5 i:(int)i6 err:(NSError **)err; // 6 in regs, 7th (out) in mem (on all architectures)
	-(void) outNSErrorOnStack:(id)obj1 obj:(id)obj2 obj:(id)obj3 int64:(long long)l4 i:(int)i5 err:(NSError **)err; // 5 in regs, 6th (out) in mem (on at least x86-64)

	@property (nonatomic, retain) NSArray *stringArrayProperty;
	-(void) setStringArrayMethod:(NSArray *) array;
	-(NSArray *) getStringArrayMethod;

	@property (nonatomic, retain) NSArray *nsobjectArrayProperty;
	-(void) setNSObjectArrayMethod: (NSArray *) array;
	-(NSArray *) getNSObjectArrayMethod;

	@property (nonatomic, retain) NSArray *INSCodingArrayProperty;
	-(void) setINSCodingArrayMethod: (NSArray *) array;
	-(NSArray *) getINSCodingArrayMethod;

@end

@protocol ProtocolAssignerProtocol
@end

@interface ProtocolAssigner : NSObject {
}
-(void) setProtocol;
-(void) completedSetProtocol: (id<ProtocolAssignerProtocol>) value;
@end

@interface ObjCProtocolTestImpl : NSObject <ProtocolAssignerProtocol>
@end

/*
 * ObjC test class used for exception tests.
 */
@interface ObjCExceptionTest : NSObject {
}
	-(void) throwObjCException;
	-(void) throwManagedException;
	-(void) invokeManagedExceptionThrower;
	-(void) invokeManagedExceptionThrowerAndRethrow;
	-(void) invokeManagedExceptionThrowerAndCatch;
@end

@protocol ObjCProtocolTest
@required
	-(void) idAsIntPtr: (id)p1;

@optional
	-(void) methodEncodings:
		(inout NSObject **) obj1P
		obj2: (in NSObject **) obj2P
		obj3: (out NSObject **) obj3P
		obj4: (const NSObject **) obj4P
		obj5: (bycopy NSObject **) obj5P
		obj6: (byref NSObject **) obj6P
		obj7: (oneway NSObject **) obj7P
		;
@end

// We need this class so that the ObjCProtocolTest protocol
// actually ends up in the library.
@interface ObjCProtocolClassTest : NSObject<ObjCProtocolTest> {
}
-(void) idAsIntPtr: (id)p1;
@end

typedef void (^int_callback)(int32_t magic_number);
@protocol ObjCProtocolBlockTest
@required
	-(void) requiredCallback: (int_callback)completionHandler;
	+(void) requiredStaticCallback: (int_callback)completionHandler;
	-(int_callback) requiredReturnValue;
	+(int_callback) requiredStaticReturnValue;
@optional
	-(void) optionalCallback: (int_callback)completionHandler;
	+(void) optionalStaticCallback: (int_callback)completionHandler;
	-(int_callback) optionalReturnValue;
	+(int_callback) optionalStaticReturnValue;
@end

typedef void (^simple_callback)();
@protocol ProtocolWithBlockProperties
@required
	@property simple_callback myRequiredProperty;
	@property (class) simple_callback myRequiredStaticProperty;
@optional
	@property simple_callback myOptionalProperty;
	@property (class) simple_callback myOptionalStaticProperty;
@end
@interface ObjCBlockTester : NSObject {
}
@property (retain) NSObject<ObjCProtocolBlockTest>* TestObject;
@property (class, retain) Class TestClass;
-(void) classCallback: (void (^)(int32_t magic_number))completionHandler;
-(void) callClassCallback;
-(void) callRequiredCallback;
+(void) callRequiredStaticCallback;
-(void) callOptionalCallback;
+(void) callOptionalStaticCallback;
typedef void (^innerBlock) (int magic_number);
typedef void (^outerBlock) (innerBlock callback);
+(void) callAssertMainThreadBlockRelease: (outerBlock) completionHandler;
+(void) callAssertMainThreadBlockReleaseQOS: (outerBlock) completionHandler;
-(void) callAssertMainThreadBlockReleaseCallback;
-(void) callAssertMainThreadBlockReleaseCallbackQOS;
-(void) assertMainThreadBlockReleaseCallback: (innerBlock) completionHandler;

-(void) testFreedBlocks;
+(int) freedBlockCount;

+(void) callProtocolWithBlockProperties: (id<ProtocolWithBlockProperties>) obj required: (bool) required instance: (bool) instance;
+(void) callProtocolWithBlockReturnValue: (id<ObjCProtocolBlockTest>) obj required: (bool) required instance: (bool) instance;

+(void) setProtocolWithBlockProperties: (id<ProtocolWithBlockProperties>) obj required: (bool) required instance: (bool) instance;
+(int) calledBlockCount;
@end

@interface FreedNotifier : NSObject {
}
-(void) dealloc;
@end

@interface EvilDeallocator : NSObject {
}
@property (copy) void (^evilCallback)(int32_t magic_number);
-(void) dealloc;
@end

// This object asserts that its dealloc function is called on the main thread
@interface MainThreadDeallocator : NSObject {
}
-(void) dealloc;
@end

@interface RefOutParameters : NSObject {
}
	-(void) testCFBundle:      (int) action a:(CFBundleRef *) refValue b:(CFBundleRef *) outValue;
	-(void) testINSCoding:     (int) action a:(id<NSCoding>*) refValue b:(id<NSCoding>*) outValue;
	-(void) testNSObject:      (int) action a:(id *)          refValue b:(id *)          outValue;
	-(void) testNSValue:       (int) action a:(NSValue **)    refValue b:(NSValue **)    outValue;
	-(void) testString:        (int) action a:(NSString **)   refValue b:(NSString **)   outValue;
	-(void) testInt:           (int) action a:(int32_t *)     refValue b:(int32_t *)     outValue c:(int32_t *) pointerValue;
	-(void) testSelector:      (int) action a:(SEL *)         refValue b:(SEL *)         outValue;
	-(void) testClass:         (int) action a:(Class *)       refValue b:(Class *)       outValue;

	-(void) testINSCodingArray:     (int) action a:(NSArray **) refValue b:(NSArray **) outValue;
	-(void) testNSObjectArray:      (int) action a:(NSArray **) refValue b:(NSArray **) outValue;
	-(void) testNSValueArray:       (int) action a:(NSArray **) refValue b:(NSArray **) outValue;
	-(void) testStringArray:        (int) action a:(NSArray **) refValue b:(NSArray **) outValue;
	// SEL can't be put into an NSArray, since it's not an NSObject.
	-(void) testClassArray:         (int) action a:(NSArray **) refValue b:(NSArray **) outValue;
	// Class isn't an NSObject either, but it quacks like one, so it's possible to put them in NSArrays.
	// And Apple does (see UIAppearance appearanceWhenContainedInInstancesOfClasses for an example).
@end

#ifdef __cplusplus
} /* extern "C" */
#endif

