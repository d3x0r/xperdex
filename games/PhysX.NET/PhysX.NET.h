/*
Copyright (c) 2007-2008
Available under the terms of the
Eclipse Public License with GPL exception
See enclosed license file for more information
*/
#include "ControllerManager.h"
#include "NxUserAllocator.h"
#include "NxScene.h"
#include "NxActor.h"
#include "NxActorDesc.h"
#include "Nxp.h"
#include "NxUserContactReport.h"
#include "NxAllocateable.h"
#include "NxAllocatorDefault.h"
#include "NxBitField.h"
#include "NxBodyDesc.h"
#include "NxBounds3.h"
#include "NxBox.h"
#include "NxBoxController.h"
#include "NxController.h"
#include "NxForceFieldShape.h"
#include "NxForceFieldShapeDesc.h"
#include "NxBoxForceFieldShape.h"
#include "NxBoxForceFieldShapeDesc.h"
#include "NxBoxShape.h"
#include "NxShape.h"
#include "NxBoxShapeDesc.h"
#include "NxShapeDesc.h"
#include "NxCapsule.h"
#include "NxSegment.h"
#include "NxCapsuleController.h"
#include "NxCapsuleForceFieldShape.h"
#include "NxCapsuleForceFieldShapeDesc.h"
#include "NxCapsuleShape.h"
#include "NxCapsuleShapeDesc.h"
#include "NxCCDSkeleton.h"
#include "NxCloth.h"
#include "NxClothDesc.h"
#include "NxClothMesh.h"
#include "NxClothMeshDesc.h"
#include "NxSimpleTriangleMesh.h"
#include "NxClothUserNotify.h"
#include "NxCompartment.h"
#include "NxCompartmentDesc.h"
#include "NxContactStreamIterator.h"
#include "NxControllerManager.h"
#include "NxConvexForceFieldShape.h"
#include "NxConvexForceFieldShapeDesc.h"
#include "NxConvexMesh.h"
#include "NxConvexMeshDesc.h"
#include "NxConvexShape.h"
#include "NxConvexShapeDesc.h"
#include "NxCooking.h"
#include "NxCylindricalJoint.h"
#include "NxJoint.h"
#include "NxCylindricalJointDesc.h"
#include "NxJointDesc.h"
#include "NxD6Joint.h"
#include "NxD6JointDesc.h"
#include "NxDebugRenderable.h"
#include "NxDistanceJoint.h"
#include "NxDistanceJointDesc.h"
#include "NxEffector.h"
#include "NxEffectorDesc.h"
#include "NxException.h"
#include "NxExtended.h"
#include "NxFixedJoint.h"
#include "NxFixedJointDesc.h"
#include "NxFluid.h"
#include "NxFluidDesc.h"
#include "NxFluidEmitter.h"
#include "NxFluidEmitterDesc.h"
#include "NxFluidPacketData.h"
#include "NxFluidUserNotify.h"
#include "NxForceField.h"
#include "NxForceFieldDesc.h"
#include "NxForceFieldKernel.h"
#include "NxForceFieldLinearKernel.h"
#include "NxForceFieldLinearKernelDesc.h"
#include "NxForceFieldShapeGroup.h"
#include "NxForceFieldShapeGroupDesc.h"
#include "NxFoundationSDK.h"
#include "NxHeightField.h"
#include "NxHeightFieldDesc.h"
#include "NxHeightFieldSample.h"
#include "NxHeightFieldShape.h"
#include "NxHeightFieldShapeDesc.h"
#include "NxVolumeIntegration.h"
#include "NxInterface.h"
#include "NxInterfaceStats.h"
#include "NxMotorDesc.h"
#include "NxJointLimitDesc.h"
#include "NxJointLimitPairDesc.h"
#include "NxJointLimitSoftDesc.h"
#include "NxJointLimitSoftPairDesc.h"
#include "NxMaterial.h"
#include "NxMaterialDesc.h"
#include "NxMath.h"
#include "NxMeshData.h"
#include "NxParticleData.h"
#include "NxParticleIdData.h"
#include "NxParticleUpdateData.h"
#include "NxPhysicsSDK.h"
#include "NxPlane.h"
#include "NxPlaneShape.h"
#include "NxPlaneShapeDesc.h"
#include "NxPMap.h"
#include "NxPointInPlaneJoint.h"
#include "NxPointInPlaneJointDesc.h"
#include "NxPointOnLineJoint.h"
#include "NxPointOnLineJointDesc.h"
//#include "NxPool.h"
#include "NxPrismaticJoint.h"
#include "NxPrismaticJointDesc.h"
#include "NxProfiler.h"
#include "NxPulleyJoint.h"
#include "NxPulleyJointDesc.h"
#include "NxRay.h"
#include "NxUserRaycastReport.h"
#include "NxRemoteDebugger.h"
#include "NxRevoluteJoint.h"
#include "NxRevoluteJointDesc.h"
#include "NxSceneDesc.h"
#include "NxSceneQuery.h"
#include "NxSceneStats2.h"
#include "NxSceneStats.h"
#include "NxSoftBody.h"
#include "NxSoftBodyDesc.h"
#include "NxSoftBodyMesh.h"
#include "NxSoftBodyMeshDesc.h"
#include "NxSoftBodyUserNotify.h"
#include "NxSphere.h"
#include "NxSphereForceFieldShape.h"
#include "NxSphereForceFieldShapeDesc.h"
#include "NxSphereShape.h"
#include "NxSphereShapeDesc.h"
#include "NxSphericalJoint.h"
#include "NxSphericalJointDesc.h"
#include "NxSpringAndDamperEffector.h"
#include "NxSpringAndDamperEffectorDesc.h"
#include "NxSpringDesc.h"
#include "NxStream.h"
#include "NxScheduler.h"
#include "NxWheelShapeDesc.h"
#include "NxTriangle.h"
#include "NxTriangleMesh.h"
#include "NxTriangleMeshDesc.h"
#include "NxTriangleMeshShape.h"
#include "NxTriangleMeshShapeDesc.h"
#include "NxUserAllocatorDefault.h"
#include "NxUserEntityReport.h"
#include "NxUserNotify.h"
#include "NxUserOutputStream.h"
#include "NxUtilLib.h"
#include "NxWheelShape.h"

#ifdef WIN32
                #define API_EXPORT extern "C" __declspec( dllexport )
            #else
                #define API_EXPORT extern "C"    
            #endif

            class DoxyBindObject {
            public:
                void setPointers(void** pointers, int length);
            protected:
                void** functionPointers;
                ~DoxyBindObject() { if(functionPointers) delete [] functionPointers; }
                static inline int getPointerEnd() { return 0; }
            };
            

class NxUserAllocator_doxybind : public NxUserAllocator, public  DoxyBindObject 
{
public:
    virtual void * mallocDEBUG(size_t size, const char * fileName, int line) ;
    virtual void * mallocDEBUG(size_t size, const char * fileName, int line, const char * className, NxMemoryType type) ;
    virtual void * malloc(size_t size) ;
    virtual void * malloc(size_t size, NxMemoryType type) ;
    virtual void * realloc(void * memory, size_t size) ;
    virtual void free(void * memory) ;
    virtual void checkDEBUG() ;
    static inline int getPointerStart() { return DoxyBindObject::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 7; }
};

class ControllerManagerAllocator_doxybind : public ControllerManagerAllocator, public  DoxyBindObject 
{
public:
    virtual void * mallocDEBUG(size_t size, const char * fileName, int line) ;
    virtual void * malloc(size_t size) ;
    virtual void * realloc(void * memory, size_t size) ;
    virtual void free(void * memory) ;
    virtual void * mallocDEBUG(size_t size, const char * fileName, int line, const char * className, NxMemoryType type) ;
    virtual void * malloc(size_t size, NxMemoryType type) ;
    virtual void checkDEBUG() ;
    static inline int getPointerStart() { return NxUserAllocator_doxybind::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 4; }
};

class NxActor_doxybind : public NxActor, public  DoxyBindObject 
{
public:
    virtual void setGlobalPose(const NxMat34 & mat) ;
    virtual void setGlobalPosition(const NxVec3 & vec) ;
    virtual void setGlobalOrientation(const NxMat33 & mat) ;
    virtual void setGlobalOrientationQuat(const NxQuat & mat) ;
    virtual NxMat34 getGlobalPose() const;
    virtual NxVec3 getGlobalPosition() const;
    virtual NxMat33 getGlobalOrientation() const;
    virtual NxQuat getGlobalOrientationQuat() const;
    virtual void moveGlobalPose(const NxMat34 & mat) ;
    virtual void moveGlobalPosition(const NxVec3 & vec) ;
    virtual void moveGlobalOrientation(const NxMat33 & mat) ;
    virtual void moveGlobalOrientationQuat(const NxQuat & quat) ;
    virtual NxShape * createShape(const NxShapeDesc & desc) ;
    virtual void releaseShape(NxShape & shape) ;
    virtual NxU32 getNbShapes() const;
    virtual NxShape *const * getShapes() const;
    virtual void setCMassOffsetLocalPose(const NxMat34 & mat) ;
    virtual void setCMassOffsetLocalPosition(const NxVec3 & vec) ;
    virtual void setCMassOffsetLocalOrientation(const NxMat33 & mat) ;
    virtual void setCMassOffsetGlobalPose(const NxMat34 & mat) ;
    virtual void setCMassOffsetGlobalPosition(const NxVec3 & vec) ;
    virtual void setCMassOffsetGlobalOrientation(const NxMat33 & mat) ;
    virtual void setCMassGlobalPose(const NxMat34 & mat) ;
    virtual void setCMassGlobalPosition(const NxVec3 & vec) ;
    virtual void setCMassGlobalOrientation(const NxMat33 & mat) ;
    virtual NxMat34 getCMassLocalPose() const;
    virtual NxVec3 getCMassLocalPosition() const;
    virtual NxMat33 getCMassLocalOrientation() const;
    virtual NxMat34 getCMassGlobalPose() const;
    virtual NxVec3 getCMassGlobalPosition() const;
    virtual NxMat33 getCMassGlobalOrientation() const;
    virtual void setMass(NxReal mass) ;
    virtual NxReal getMass() const;
    virtual void setMassSpaceInertiaTensor(const NxVec3 & m) ;
    virtual NxVec3 getMassSpaceInertiaTensor() const;
    virtual NxMat33 getGlobalInertiaTensor() const;
    virtual NxMat33 getGlobalInertiaTensorInverse() const;
    virtual bool updateMassFromShapes(NxReal density, NxReal totalMass) ;
    virtual void setLinearDamping(NxReal linDamp) ;
    virtual NxReal getLinearDamping() const;
    virtual void setAngularDamping(NxReal angDamp) ;
    virtual NxReal getAngularDamping() const;
    virtual void setLinearVelocity(const NxVec3 & linVel) ;
    virtual void setAngularVelocity(const NxVec3 & angVel) ;
    virtual NxVec3 getLinearVelocity() const;
    virtual NxVec3 getAngularVelocity() const;
    virtual void setMaxAngularVelocity(NxReal maxAngVel) ;
    virtual NxReal getMaxAngularVelocity() const;
    virtual void setCCDMotionThreshold(NxReal thresh) ;
    virtual NxReal getCCDMotionThreshold() const;
    virtual void setLinearMomentum(const NxVec3 & linMoment) ;
    virtual void setAngularMomentum(const NxVec3 & angMoment) ;
    virtual NxVec3 getLinearMomentum() const;
    virtual NxVec3 getAngularMomentum() const;
    virtual void addForceAtPos(const NxVec3 & force, const NxVec3 & pos, NxForceMode mode, bool wakeup) ;
    virtual void addForceAtPos(const NxVec3 & force, const NxVec3 & pos, NxForceMode mode) ;
    virtual void addForceAtPos(const NxVec3 & force, const NxVec3 & pos) ;
    virtual void addForceAtLocalPos(const NxVec3 & force, const NxVec3 & pos, NxForceMode mode, bool wakeup) ;
    virtual void addForceAtLocalPos(const NxVec3 & force, const NxVec3 & pos, NxForceMode mode) ;
    virtual void addForceAtLocalPos(const NxVec3 & force, const NxVec3 & pos) ;
    virtual void addLocalForceAtPos(const NxVec3 & force, const NxVec3 & pos, NxForceMode mode, bool wakeup) ;
    virtual void addLocalForceAtPos(const NxVec3 & force, const NxVec3 & pos, NxForceMode mode) ;
    virtual void addLocalForceAtPos(const NxVec3 & force, const NxVec3 & pos) ;
    virtual void addLocalForceAtLocalPos(const NxVec3 & force, const NxVec3 & pos, NxForceMode mode, bool wakeup) ;
    virtual void addLocalForceAtLocalPos(const NxVec3 & force, const NxVec3 & pos, NxForceMode mode) ;
    virtual void addLocalForceAtLocalPos(const NxVec3 & force, const NxVec3 & pos) ;
    virtual void addForce(const NxVec3 & force, NxForceMode mode, bool wakeup) ;
    virtual void addForce(const NxVec3 & force, NxForceMode mode) ;
    virtual void addForce(const NxVec3 & force) ;
    virtual void addLocalForce(const NxVec3 & force, NxForceMode mode, bool wakeup) ;
    virtual void addLocalForce(const NxVec3 & force, NxForceMode mode) ;
    virtual void addLocalForce(const NxVec3 & force) ;
    virtual void addTorque(const NxVec3 & torque, NxForceMode mode, bool wakeup) ;
    virtual void addTorque(const NxVec3 & torque, NxForceMode mode) ;
    virtual void addTorque(const NxVec3 & torque) ;
    virtual void addLocalTorque(const NxVec3 & torque, NxForceMode mode, bool wakeup) ;
    virtual void addLocalTorque(const NxVec3 & torque, NxForceMode mode) ;
    virtual void addLocalTorque(const NxVec3 & torque) ;
    virtual NxVec3 getPointVelocity(const NxVec3 & point) const;
    virtual NxVec3 getLocalPointVelocity(const NxVec3 & point) const;
    virtual bool isGroupSleeping() const;
    virtual bool isSleeping() const;
    virtual NxReal getSleepLinearVelocity() const;
    virtual void setSleepLinearVelocity(NxReal threshold) ;
    virtual NxReal getSleepAngularVelocity() const;
    virtual void setSleepAngularVelocity(NxReal threshold) ;
    virtual NxReal getSleepEnergyThreshold() const;
    virtual void setSleepEnergyThreshold(NxReal threshold) ;
    virtual void wakeUp(NxReal wakeCounterValue) ;
    virtual void putToSleep() ;
    NxActor_doxybind();
    virtual NxScene & getScene() const;
    virtual void saveToDesc(NxActorDescBase & desc) ;
    virtual void setName(const char * name) ;
    virtual const char * getName() const;
    virtual void setGroup(NxActorGroup actorGroup) ;
    virtual NxActorGroup getGroup() const;
    virtual void setDominanceGroup(NxDominanceGroup dominanceGroup) ;
    virtual NxDominanceGroup getDominanceGroup() const;
    virtual void raiseActorFlag(NxActorFlag actorFlag) ;
    virtual void clearActorFlag(NxActorFlag actorFlag) ;
    virtual bool readActorFlag(NxActorFlag actorFlag) const;
    virtual void resetUserActorPairFiltering() ;
    virtual bool isDynamic() const;
    virtual NxReal computeKineticEnergy() const;
    virtual void raiseBodyFlag(NxBodyFlag bodyFlag) ;
    virtual void clearBodyFlag(NxBodyFlag bodyFlag) ;
    virtual bool readBodyFlag(NxBodyFlag bodyFlag) const;
    virtual bool saveBodyToDesc(NxBodyDesc & bodyDesc) ;
    virtual void setSolverIterationCount(NxU32 iterCount) ;
    virtual NxU32 getSolverIterationCount() const;
    virtual NxReal getContactReportThreshold() const;
    virtual void setContactReportThreshold(NxReal threshold) ;
    virtual NxU32 getContactReportFlags() const;
    virtual void setContactReportFlags(NxU32 flags) ;
    virtual NxU32 linearSweep(const NxVec3 & motion, NxU32 flags, void * userData, NxU32 nbShapes, NxSweepQueryHit * shapes, NxUserEntityReport< NxSweepQueryHit > * callback, const NxSweepCache * sweepCache) ;
    virtual NxU32 linearSweep(const NxVec3 & motion, NxU32 flags, void * userData, NxU32 nbShapes, NxSweepQueryHit * shapes, NxUserEntityReport< NxSweepQueryHit > * callback) ;
    virtual NxCompartment * getCompartment() const;
    virtual NxForceFieldMaterial getForceFieldMaterial() const;
    virtual void setForceFieldMaterial(NxForceFieldMaterial unknown2) ;
    static inline int getPointerStart() { return DoxyBindObject::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 119; }
};

class NxController_doxybind : public NxController, public  DoxyBindObject 
{
public:
    NxController_doxybind();
    virtual void move(const NxVec3 & disp, NxU32 activeGroups, NxF32 minDist, NxU32 & collisionFlags, NxF32 sharpness, const NxGroupsMask * groupsMask) ;
    virtual void move(const NxVec3 & disp, NxU32 activeGroups, NxF32 minDist, NxU32 & collisionFlags, NxF32 sharpness) ;
    virtual void move(const NxVec3 & disp, NxU32 activeGroups, NxF32 minDist, NxU32 & collisionFlags) ;
    virtual bool setPosition(const NxExtendedVec3 & position) ;
    virtual const NxExtendedVec3 & getPosition() const;
    virtual const NxExtendedVec3 & getFilteredPosition() const;
    virtual const NxExtendedVec3 & getDebugPosition() const;
    virtual NxActor * getActor() const;
    virtual void setStepOffset(const float offset) ;
    virtual void setCollision(bool enabled) ;
    virtual void setInteraction(NxCCTInteractionFlag flag) ;
    virtual NxCCTInteractionFlag getInteraction() const;
    virtual void reportSceneChanged() ;
    virtual void * getUserData() const;
    virtual NxControllerType getType() ;
    static inline int getPointerStart() { return DoxyBindObject::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 15; }
};

class NxBoxController_doxybind : public NxBoxController, public  DoxyBindObject 
{
public:
    NxBoxController_doxybind();
    virtual const NxVec3 & getExtents() const;
    virtual bool setExtents(const NxVec3 & extents) ;
    virtual void setStepOffset(const float offset) ;
    virtual void reportSceneChanged() ;
    virtual void move(const NxVec3 & disp, NxU32 activeGroups, NxF32 minDist, NxU32 & collisionFlags, NxF32 sharpness, const NxGroupsMask * groupsMask) ;
    virtual void move(const NxVec3 & disp, NxU32 activeGroups, NxF32 minDist, NxU32 & collisionFlags, NxF32 sharpness) ;
    virtual void move(const NxVec3 & disp, NxU32 activeGroups, NxF32 minDist, NxU32 & collisionFlags) ;
    virtual bool setPosition(const NxExtendedVec3 & position) ;
    virtual const NxExtendedVec3 & getPosition() const;
    virtual const NxExtendedVec3 & getFilteredPosition() const;
    virtual const NxExtendedVec3 & getDebugPosition() const;
    virtual NxActor * getActor() const;
    virtual void setCollision(bool enabled) ;
    virtual void setInteraction(NxCCTInteractionFlag flag) ;
    virtual NxCCTInteractionFlag getInteraction() const;
    virtual void * getUserData() const;
    virtual NxControllerType getType() ;
    static inline int getPointerStart() { return NxController_doxybind::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 4; }
};

class NxControllerDesc_doxybind : public NxControllerDesc, public  DoxyBindObject 
{
public:
    NxControllerDesc_doxybind(NxControllerType unknown5);
    virtual void setToDefault() ;
    virtual bool isValid() const;
    static inline int getPointerStart() { return DoxyBindObject::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 2; }
};

class NxBoxControllerDesc_doxybind : public NxBoxControllerDesc, public  DoxyBindObject 
{
public:
    NxBoxControllerDesc_doxybind();
    virtual void setToDefault() ;
    virtual bool isValid() const;
    static inline int getPointerStart() { return NxControllerDesc_doxybind::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 2; }
};

class NxForceFieldShape_doxybind : public NxForceFieldShape, public  DoxyBindObject 
{
public:
    NxForceFieldShape_doxybind();
    virtual NxMat34 getPose() const;
    virtual void setPose(const NxMat34 & unknown6) ;
    virtual NxForceField * getForceField() const;
    virtual NxForceFieldShapeGroup & getShapeGroup() const;
    virtual void setName(const char * name) ;
    virtual const char * getName() const;
    virtual NxShapeType getType() const;
    static inline int getPointerStart() { return DoxyBindObject::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 7; }
};

class NxBoxForceFieldShape_doxybind : public NxBoxForceFieldShape, public  DoxyBindObject 
{
public:
    virtual void setDimensions(const NxVec3 & vec) ;
    virtual NxVec3 getDimensions() const;
    virtual void saveToDesc(NxBoxForceFieldShapeDesc & desc) const;
    virtual NxMat34 getPose() const;
    virtual void setPose(const NxMat34 & unknown6) ;
    virtual NxForceField * getForceField() const;
    virtual NxForceFieldShapeGroup & getShapeGroup() const;
    virtual void setName(const char * name) ;
    virtual const char * getName() const;
    virtual NxShapeType getType() const;
    static inline int getPointerStart() { return NxForceFieldShape_doxybind::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 3; }
};

class NxForceFieldShapeDesc_doxybind : public NxForceFieldShapeDesc, public  DoxyBindObject 
{
public:
    virtual void setToDefault() ;
    virtual bool isValid() const;
    NxForceFieldShapeDesc_doxybind(NxShapeType type);
    static inline int getPointerStart() { return DoxyBindObject::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 2; }
};

class NxBoxForceFieldShapeDesc_doxybind : public NxBoxForceFieldShapeDesc, public  DoxyBindObject 
{
public:
    NxBoxForceFieldShapeDesc_doxybind();
    virtual void setToDefault() ;
    virtual bool isValid() const;
    static inline int getPointerStart() { return NxForceFieldShapeDesc_doxybind::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 2; }
};

class NxShape_doxybind : public NxShape, public  DoxyBindObject 
{
public:
    virtual void setLocalPose(const NxMat34 & mat) ;
    virtual void setLocalPosition(const NxVec3 & vec) ;
    virtual void setLocalOrientation(const NxMat33 & mat) ;
    virtual NxMat34 getLocalPose() const;
    virtual NxVec3 getLocalPosition() const;
    virtual NxMat33 getLocalOrientation() const;
    virtual void setGlobalPose(const NxMat34 & mat) ;
    virtual void setGlobalPosition(const NxVec3 & vec) ;
    virtual void setGlobalOrientation(const NxMat33 & mat) ;
    virtual NxMat34 getGlobalPose() const;
    virtual NxVec3 getGlobalPosition() const;
    virtual NxMat33 getGlobalOrientation() const;
    virtual void * is(NxShapeType type) ;
    virtual const void * is(NxShapeType type) const;
    virtual bool raycast(const NxRay & worldRay, NxReal maxDist, NxU32 hintFlags, NxRaycastHit & hit, bool firstHit) const;
    virtual bool checkOverlapSphere(const NxSphere & worldSphere) const;
    virtual bool checkOverlapOBB(const NxBox & worldBox) const;
    virtual bool checkOverlapAABB(const NxBounds3 & worldBounds) const;
    virtual bool checkOverlapCapsule(const NxCapsule & worldCapsule) const;
    NxShape_doxybind();
    virtual NxActor & getActor() const;
    virtual void setGroup(NxCollisionGroup collisionGroup) ;
    virtual NxCollisionGroup getGroup() const;
    virtual void getWorldBounds(NxBounds3 & dest) const;
    virtual void setFlag(NxShapeFlag flag, bool value) ;
    virtual NX_BOOL getFlag(NxShapeFlag flag) const;
    virtual void setMaterial(NxMaterialIndex matIndex) ;
    virtual NxMaterialIndex getMaterial() const;
    virtual void setSkinWidth(NxReal skinWidth) ;
    virtual NxReal getSkinWidth() const;
    virtual NxShapeType getType() const;
    virtual void setCCDSkeleton(NxCCDSkeleton * ccdSkel) ;
    virtual NxCCDSkeleton * getCCDSkeleton() const;
    virtual void setName(const char * name) ;
    virtual const char * getName() const;
    virtual void setGroupsMask(const NxGroupsMask & mask) ;
    virtual const NxGroupsMask getGroupsMask() const;
    virtual NxU32 getNonInteractingCompartmentTypes() const;
    virtual void setNonInteractingCompartmentTypes(NxU32 compartmentTypes) ;
    static inline int getPointerStart() { return DoxyBindObject::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 38; }
};

class NxBoxShape_doxybind : public NxBoxShape, public  DoxyBindObject 
{
public:
    virtual void setDimensions(const NxVec3 & vec) ;
    virtual NxVec3 getDimensions() const;
    virtual void getWorldOBB(NxBox & obb) const;
    virtual void saveToDesc(NxBoxShapeDesc & desc) const;
    virtual void setLocalPose(const NxMat34 & mat) ;
    virtual void setLocalPosition(const NxVec3 & vec) ;
    virtual void setLocalOrientation(const NxMat33 & mat) ;
    virtual NxMat34 getLocalPose() const;
    virtual NxVec3 getLocalPosition() const;
    virtual NxMat33 getLocalOrientation() const;
    virtual void setGlobalPose(const NxMat34 & mat) ;
    virtual void setGlobalPosition(const NxVec3 & vec) ;
    virtual void setGlobalOrientation(const NxMat33 & mat) ;
    virtual NxMat34 getGlobalPose() const;
    virtual NxVec3 getGlobalPosition() const;
    virtual NxMat33 getGlobalOrientation() const;
    virtual void * is(NxShapeType type) ;
    virtual const void * is(NxShapeType type) const;
    virtual bool raycast(const NxRay & worldRay, NxReal maxDist, NxU32 hintFlags, NxRaycastHit & hit, bool firstHit) const;
    virtual bool checkOverlapSphere(const NxSphere & worldSphere) const;
    virtual bool checkOverlapOBB(const NxBox & worldBox) const;
    virtual bool checkOverlapAABB(const NxBounds3 & worldBounds) const;
    virtual bool checkOverlapCapsule(const NxCapsule & worldCapsule) const;
    virtual NxActor & getActor() const;
    virtual void setGroup(NxCollisionGroup collisionGroup) ;
    virtual NxCollisionGroup getGroup() const;
    virtual void getWorldBounds(NxBounds3 & dest) const;
    virtual void setFlag(NxShapeFlag flag, bool value) ;
    virtual NX_BOOL getFlag(NxShapeFlag flag) const;
    virtual void setMaterial(NxMaterialIndex matIndex) ;
    virtual NxMaterialIndex getMaterial() const;
    virtual void setSkinWidth(NxReal skinWidth) ;
    virtual NxReal getSkinWidth() const;
    virtual NxShapeType getType() const;
    virtual void setCCDSkeleton(NxCCDSkeleton * ccdSkel) ;
    virtual NxCCDSkeleton * getCCDSkeleton() const;
    virtual void setName(const char * name) ;
    virtual const char * getName() const;
    virtual void setGroupsMask(const NxGroupsMask & mask) ;
    virtual const NxGroupsMask getGroupsMask() const;
    virtual NxU32 getNonInteractingCompartmentTypes() const;
    virtual void setNonInteractingCompartmentTypes(NxU32 compartmentTypes) ;
    static inline int getPointerStart() { return NxShape_doxybind::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 4; }
};

class NxShapeDesc_doxybind : public NxShapeDesc, public  DoxyBindObject 
{
public:
    virtual void setToDefault() ;
    virtual bool isValid() const;
    NxShapeDesc_doxybind(NxShapeType shapeType);
    static inline int getPointerStart() { return DoxyBindObject::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 2; }
};

class NxBoxShapeDesc_doxybind : public NxBoxShapeDesc, public  DoxyBindObject 
{
public:
    NxBoxShapeDesc_doxybind();
    virtual void setToDefault() ;
    virtual bool isValid() const;
    static inline int getPointerStart() { return NxShapeDesc_doxybind::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 2; }
};

class NxCapsuleController_doxybind : public NxCapsuleController, public  DoxyBindObject 
{
public:
    NxCapsuleController_doxybind();
    virtual NxF32 getRadius() const;
    virtual bool setRadius(NxF32 radius) ;
    virtual NxF32 getHeight() const;
    virtual NxCapsuleClimbingMode getClimbingMode() const;
    virtual bool setHeight(NxF32 height) ;
    virtual void setStepOffset(const float offset) ;
    virtual bool setClimbingMode(NxCapsuleClimbingMode mode) ;
    virtual void reportSceneChanged() ;
    virtual void move(const NxVec3 & disp, NxU32 activeGroups, NxF32 minDist, NxU32 & collisionFlags, NxF32 sharpness, const NxGroupsMask * groupsMask) ;
    virtual void move(const NxVec3 & disp, NxU32 activeGroups, NxF32 minDist, NxU32 & collisionFlags, NxF32 sharpness) ;
    virtual void move(const NxVec3 & disp, NxU32 activeGroups, NxF32 minDist, NxU32 & collisionFlags) ;
    virtual bool setPosition(const NxExtendedVec3 & position) ;
    virtual const NxExtendedVec3 & getPosition() const;
    virtual const NxExtendedVec3 & getFilteredPosition() const;
    virtual const NxExtendedVec3 & getDebugPosition() const;
    virtual NxActor * getActor() const;
    virtual void setCollision(bool enabled) ;
    virtual void setInteraction(NxCCTInteractionFlag flag) ;
    virtual NxCCTInteractionFlag getInteraction() const;
    virtual void * getUserData() const;
    virtual NxControllerType getType() ;
    static inline int getPointerStart() { return NxController_doxybind::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 8; }
};

class NxCapsuleControllerDesc_doxybind : public NxCapsuleControllerDesc, public  DoxyBindObject 
{
public:
    NxCapsuleControllerDesc_doxybind();
    virtual void setToDefault() ;
    virtual bool isValid() const;
    static inline int getPointerStart() { return NxControllerDesc_doxybind::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 2; }
};

class NxCapsuleForceFieldShape_doxybind : public NxCapsuleForceFieldShape, public  DoxyBindObject 
{
public:
    virtual void setDimensions(NxReal radius, NxReal height) ;
    virtual void setRadius(NxReal radius) ;
    virtual NxReal getRadius() const;
    virtual void setHeight(NxReal height) ;
    virtual NxReal getHeight() const;
    virtual void saveToDesc(NxCapsuleForceFieldShapeDesc & desc) const;
    virtual NxMat34 getPose() const;
    virtual void setPose(const NxMat34 & unknown6) ;
    virtual NxForceField * getForceField() const;
    virtual NxForceFieldShapeGroup & getShapeGroup() const;
    virtual void setName(const char * name) ;
    virtual const char * getName() const;
    virtual NxShapeType getType() const;
    static inline int getPointerStart() { return NxForceFieldShape_doxybind::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 6; }
};

class NxCapsuleForceFieldShapeDesc_doxybind : public NxCapsuleForceFieldShapeDesc, public  DoxyBindObject 
{
public:
    NxCapsuleForceFieldShapeDesc_doxybind();
    virtual void setToDefault() ;
    virtual bool isValid() const;
    static inline int getPointerStart() { return NxForceFieldShapeDesc_doxybind::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 2; }
};

class NxCapsuleShape_doxybind : public NxCapsuleShape, public  DoxyBindObject 
{
public:
    virtual void setDimensions(NxReal radius, NxReal height) ;
    virtual void setRadius(NxReal radius) ;
    virtual NxReal getRadius() const;
    virtual void setHeight(NxReal height) ;
    virtual NxReal getHeight() const;
    virtual void getWorldCapsule(NxCapsule & worldCapsule) const;
    virtual void saveToDesc(NxCapsuleShapeDesc & desc) const;
    virtual void setLocalPose(const NxMat34 & mat) ;
    virtual void setLocalPosition(const NxVec3 & vec) ;
    virtual void setLocalOrientation(const NxMat33 & mat) ;
    virtual NxMat34 getLocalPose() const;
    virtual NxVec3 getLocalPosition() const;
    virtual NxMat33 getLocalOrientation() const;
    virtual void setGlobalPose(const NxMat34 & mat) ;
    virtual void setGlobalPosition(const NxVec3 & vec) ;
    virtual void setGlobalOrientation(const NxMat33 & mat) ;
    virtual NxMat34 getGlobalPose() const;
    virtual NxVec3 getGlobalPosition() const;
    virtual NxMat33 getGlobalOrientation() const;
    virtual void * is(NxShapeType type) ;
    virtual const void * is(NxShapeType type) const;
    virtual bool raycast(const NxRay & worldRay, NxReal maxDist, NxU32 hintFlags, NxRaycastHit & hit, bool firstHit) const;
    virtual bool checkOverlapSphere(const NxSphere & worldSphere) const;
    virtual bool checkOverlapOBB(const NxBox & worldBox) const;
    virtual bool checkOverlapAABB(const NxBounds3 & worldBounds) const;
    virtual bool checkOverlapCapsule(const NxCapsule & worldCapsule) const;
    virtual NxActor & getActor() const;
    virtual void setGroup(NxCollisionGroup collisionGroup) ;
    virtual NxCollisionGroup getGroup() const;
    virtual void getWorldBounds(NxBounds3 & dest) const;
    virtual void setFlag(NxShapeFlag flag, bool value) ;
    virtual NX_BOOL getFlag(NxShapeFlag flag) const;
    virtual void setMaterial(NxMaterialIndex matIndex) ;
    virtual NxMaterialIndex getMaterial() const;
    virtual void setSkinWidth(NxReal skinWidth) ;
    virtual NxReal getSkinWidth() const;
    virtual NxShapeType getType() const;
    virtual void setCCDSkeleton(NxCCDSkeleton * ccdSkel) ;
    virtual NxCCDSkeleton * getCCDSkeleton() const;
    virtual void setName(const char * name) ;
    virtual const char * getName() const;
    virtual void setGroupsMask(const NxGroupsMask & mask) ;
    virtual const NxGroupsMask getGroupsMask() const;
    virtual NxU32 getNonInteractingCompartmentTypes() const;
    virtual void setNonInteractingCompartmentTypes(NxU32 compartmentTypes) ;
    static inline int getPointerStart() { return NxShape_doxybind::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 7; }
};

class NxCapsuleShapeDesc_doxybind : public NxCapsuleShapeDesc, public  DoxyBindObject 
{
public:
    NxCapsuleShapeDesc_doxybind();
    virtual void setToDefault() ;
    virtual bool isValid() const;
    static inline int getPointerStart() { return NxShapeDesc_doxybind::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 2; }
};

class NxCCDSkeleton_doxybind : public NxCCDSkeleton, public  DoxyBindObject 
{
public:
    virtual NxU32 save(void * destBuffer, NxU32 bufferSize) ;
    virtual NxU32 getDataSize() ;
    virtual NxU32 getReferenceCount() ;
    virtual NxU32 saveToDesc(NxSimpleTriangleMesh & desc) ;
    static inline int getPointerStart() { return DoxyBindObject::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 4; }
};

class NxCloth_doxybind : public NxCloth, public  DoxyBindObject 
{
public:
    NxCloth_doxybind();
    virtual bool saveToDesc(NxClothDesc & desc) const;
    virtual NxClothMesh * getClothMesh() const;
    virtual void setBendingStiffness(NxReal stiffness) ;
    virtual NxReal getBendingStiffness() const;
    virtual void setStretchingStiffness(NxReal stiffness) ;
    virtual NxReal getStretchingStiffness() const;
    virtual void setDampingCoefficient(NxReal dampingCoefficient) ;
    virtual NxReal getDampingCoefficient() const;
    virtual void setFriction(NxReal friction) ;
    virtual NxReal getFriction() const;
    virtual void setPressure(NxReal pressure) ;
    virtual NxReal getPressure() const;
    virtual void setTearFactor(NxReal factor) ;
    virtual NxReal getTearFactor() const;
    virtual void setAttachmentTearFactor(NxReal factor) ;
    virtual NxReal getAttachmentTearFactor() const;
    virtual void setThickness(NxReal thickness) ;
    virtual NxReal getThickness() const;
    virtual NxReal getDensity() const;
    virtual NxReal getRelativeGridSpacing() const;
    virtual NxU32 getSolverIterations() const;
    virtual void setSolverIterations(NxU32 iterations) ;
    virtual void getWorldBounds(NxBounds3 & bounds) const;
    virtual void attachToShape(const NxShape * shape, NxU32 attachmentFlags) ;
    virtual void attachToCollidingShapes(NxU32 attachmentFlags) ;
    virtual void detachFromShape(const NxShape * shape) ;
    virtual void attachVertexToShape(NxU32 vertexId, const NxShape * shape, const NxVec3 & localPos, NxU32 attachmentFlags) ;
    virtual void attachVertexToGlobalPosition(const NxU32 vertexId, const NxVec3 & pos) ;
    virtual void freeVertex(const NxU32 vertexId) ;
    virtual void dominateVertex(NxU32 vertexId, NxReal expirationTime, NxReal dominanceWeight) ;
    virtual NxClothVertexAttachmentStatus getVertexAttachmentStatus(NxU32 vertexId) const;
    virtual NxShape * getVertexAttachmentShape(NxU32 vertexId) const;
    virtual NxVec3 getVertexAttachmentPosition(NxU32 vertexId) const;
    virtual void attachToCore(NxActor * actor, NxReal impulseThreshold, NxReal penetrationDepth, NxReal maxDeformationDistance) ;
    virtual void attachToCore(NxActor * actor, NxReal impulseThreshold, NxReal penetrationDepth) ;
    virtual void attachToCore(NxActor * actor, NxReal impulseThreshold) ;
    virtual bool tearVertex(const NxU32 vertexId, const NxVec3 & normal) ;
    virtual bool raycast(const NxRay & worldRay, NxVec3 & hit, NxU32 & vertexId) ;
    virtual void setGroup(NxCollisionGroup collisionGroup) ;
    virtual NxCollisionGroup getGroup() const;
    virtual void setGroupsMask(const NxGroupsMask & groupsMask) ;
    virtual const NxGroupsMask getGroupsMask() const;
    virtual void setMeshData(NxMeshData & meshData) ;
    virtual NxMeshData getMeshData() ;
    virtual void setValidBounds(const NxBounds3 & validBounds) ;
    virtual void getValidBounds(NxBounds3 & validBounds) const;
    virtual void setPosition(const NxVec3 & position, NxU32 vertexId) ;
    virtual void setPositions(void * buffer, NxU32 byteStride) ;
    virtual void setPositions(void * buffer) ;
    virtual NxVec3 getPosition(NxU32 vertexId) const;
    virtual void getPositions(void * buffer, NxU32 byteStride) ;
    virtual void getPositions(void * buffer) ;
    virtual void setVelocity(const NxVec3 & velocity, NxU32 vertexId) ;
    virtual void setVelocities(void * buffer, NxU32 byteStride) ;
    virtual void setVelocities(void * buffer) ;
    virtual NxVec3 getVelocity(NxU32 vertexId) const;
    virtual void getVelocities(void * buffer, NxU32 byteStride) ;
    virtual void getVelocities(void * buffer) ;
    virtual NxU32 getNumberOfParticles() ;
    virtual NxU32 queryShapePointers() ;
    virtual NxU32 getStateByteSize() ;
    virtual void getShapePointers(NxShape ** shapePointers, NxU32 * flags) ;
    virtual void getShapePointers(NxShape ** shapePointers) ;
    virtual void setShapePointers(NxShape ** shapePointers, unsigned int numShapes) ;
    virtual void saveStateToStream(NxStream & stream, bool permute) ;
    virtual void saveStateToStream(NxStream & stream) ;
    virtual void loadStateFromStream(NxStream & stream) ;
    virtual void setCollisionResponseCoefficient(NxReal coefficient) ;
    virtual NxReal getCollisionResponseCoefficient() const;
    virtual void setAttachmentResponseCoefficient(NxReal coefficient) ;
    virtual NxReal getAttachmentResponseCoefficient() const;
    virtual void setFromFluidResponseCoefficient(NxReal coefficient) ;
    virtual NxReal getFromFluidResponseCoefficient() const;
    virtual void setToFluidResponseCoefficient(NxReal coefficient) ;
    virtual NxReal getToFluidResponseCoefficient() const;
    virtual void setExternalAcceleration(NxVec3 acceleration) ;
    virtual NxVec3 getExternalAcceleration() const;
    virtual void setMinAdhereVelocity(NxReal velocity) ;
    virtual NxReal getMinAdhereVelocity() const;
    virtual void setWindAcceleration(NxVec3 acceleration) ;
    virtual NxVec3 getWindAcceleration() const;
    virtual bool isSleeping() const;
    virtual NxReal getSleepLinearVelocity() const;
    virtual void setSleepLinearVelocity(NxReal threshold) ;
    virtual void wakeUp(NxReal wakeCounterValue) ;
    virtual void putToSleep() ;
    virtual void setFlags(NxU32 flags) ;
    virtual NxU32 getFlags() const;
    virtual void setName(const char * name) ;
    virtual void addForceAtVertex(const NxVec3 & force, NxU32 vertexId, NxForceMode mode) ;
    virtual void addForceAtVertex(const NxVec3 & force, NxU32 vertexId) ;
    virtual void addForceAtPos(const NxVec3 & position, NxReal magnitude, NxReal radius, NxForceMode mode) ;
    virtual void addForceAtPos(const NxVec3 & position, NxReal magnitude, NxReal radius) ;
    virtual void addDirectedForceAtPos(const NxVec3 & position, const NxVec3 & force, NxReal radius, NxForceMode mode) ;
    virtual void addDirectedForceAtPos(const NxVec3 & position, const NxVec3 & force, NxReal radius) ;
    virtual bool overlapAABBTriangles(const NxBounds3 & bounds, NxU32 & nb, const NxU32 *& indices) const;
    virtual NxScene & getScene() const;
    virtual const char * getName() const;
    virtual NxCompartment * getCompartment() const;
    virtual NxU32 getPPUTime() const;
    virtual NxForceFieldMaterial getForceFieldMaterial() const;
    virtual void setForceFieldMaterial(NxForceFieldMaterial unknown7) ;
    static inline int getPointerStart() { return DoxyBindObject::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 102; }
};

class NxClothMesh_doxybind : public NxClothMesh, public  DoxyBindObject 
{
public:
    NxClothMesh_doxybind();
    virtual bool saveToDesc(NxClothMeshDesc & desc) const;
    virtual NxU32 getReferenceCount() const;
    static inline int getPointerStart() { return DoxyBindObject::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 2; }
};

class NxCompartment_doxybind : public NxCompartment, public  DoxyBindObject 
{
public:
    virtual NxCompartmentType getType() const;
    virtual NxU32 getDeviceCode() const;
    virtual NxReal getGridHashCellSize() const;
    virtual NxU32 gridHashTablePower() const;
    virtual void setTimeScale(NxReal unknown8) ;
    virtual NxReal getTimeScale() const;
    virtual void setTiming(NxReal maxTimestep, NxU32 maxIter, NxTimeStepMethod method) ;
    virtual void setTiming(NxReal maxTimestep, NxU32 maxIter) ;
    virtual void setTiming(NxReal maxTimestep) ;
    virtual void getTiming(NxReal & maxTimestep, NxU32 & maxIter, NxTimeStepMethod & method, NxU32 * numSubSteps) const;
    virtual void getTiming(NxReal & maxTimestep, NxU32 & maxIter, NxTimeStepMethod & method) const;
    virtual bool checkResults(bool block) ;
    virtual bool fetchResults(bool block) ;
    virtual bool saveToDesc(NxCompartmentDesc & desc) const;
    virtual void setFlags(NxU32 flags) ;
    virtual NxU32 getFlags() const;
    static inline int getPointerStart() { return DoxyBindObject::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 16; }
};

class NxControllerManager_doxybind : public NxControllerManager, public  DoxyBindObject 
{
public:
    virtual NxU32 getNbControllers() const;
    virtual NxController * getController(NxU32 index) ;
    virtual NxController * createController(NxScene * scene, const NxControllerDesc & desc) ;
    virtual void releaseController(NxController & controller) ;
    virtual void purgeControllers() ;
    virtual void updateControllers() ;
    virtual NxDebugRenderable getDebugData() ;
    virtual void resetDebugData() ;
    NxControllerManager_doxybind();
    static inline int getPointerStart() { return DoxyBindObject::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 9; }
protected:
    virtual void release() ;
};

class NxConvexForceFieldShape_doxybind : public NxConvexForceFieldShape, public  DoxyBindObject 
{
public:
    virtual void saveToDesc(NxConvexForceFieldShapeDesc & desc) const;
    virtual NxMat34 getPose() const;
    virtual void setPose(const NxMat34 & unknown6) ;
    virtual NxForceField * getForceField() const;
    virtual NxForceFieldShapeGroup & getShapeGroup() const;
    virtual void setName(const char * name) ;
    virtual const char * getName() const;
    virtual NxShapeType getType() const;
    static inline int getPointerStart() { return NxForceFieldShape_doxybind::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 1; }
};

class NxConvexForceFieldShapeDesc_doxybind : public NxConvexForceFieldShapeDesc, public  DoxyBindObject 
{
public:
    NxConvexForceFieldShapeDesc_doxybind();
    virtual void setToDefault() ;
    virtual bool isValid() const;
    static inline int getPointerStart() { return NxForceFieldShapeDesc_doxybind::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 2; }
};

class NxConvexMesh_doxybind : public NxConvexMesh, public  DoxyBindObject 
{
public:
    virtual bool saveToDesc(NxConvexMeshDesc & desc) const;
    virtual NxU32 getSubmeshCount() const;
    virtual NxU32 getCount(NxSubmeshIndex submeshIndex, NxInternalArray intArray) const;
    virtual NxInternalFormat getFormat(NxSubmeshIndex submeshIndex, NxInternalArray intArray) const;
    virtual const void * getBase(NxSubmeshIndex submeshIndex, NxInternalArray intArray) const;
    virtual NxU32 getStride(NxSubmeshIndex submeshIndex, NxInternalArray intArray) const;
    virtual bool load(const NxStream & stream) ;
    virtual NxU32 getReferenceCount() ;
    virtual void getMassInformation(NxReal & mass, NxMat33 & localInertia, NxVec3 & localCenterOfMass) const;
    virtual void * getInternal() ;
    static inline int getPointerStart() { return DoxyBindObject::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 10; }
};

class NxConvexShape_doxybind : public NxConvexShape, public  DoxyBindObject 
{
public:
    virtual void saveToDesc(NxConvexShapeDesc & desc) const;
    virtual NxConvexMesh & getConvexMesh() ;
    virtual const NxConvexMesh & getConvexMesh() const;
    virtual void setLocalPose(const NxMat34 & mat) ;
    virtual void setLocalPosition(const NxVec3 & vec) ;
    virtual void setLocalOrientation(const NxMat33 & mat) ;
    virtual NxMat34 getLocalPose() const;
    virtual NxVec3 getLocalPosition() const;
    virtual NxMat33 getLocalOrientation() const;
    virtual void setGlobalPose(const NxMat34 & mat) ;
    virtual void setGlobalPosition(const NxVec3 & vec) ;
    virtual void setGlobalOrientation(const NxMat33 & mat) ;
    virtual NxMat34 getGlobalPose() const;
    virtual NxVec3 getGlobalPosition() const;
    virtual NxMat33 getGlobalOrientation() const;
    virtual void * is(NxShapeType type) ;
    virtual const void * is(NxShapeType type) const;
    virtual bool raycast(const NxRay & worldRay, NxReal maxDist, NxU32 hintFlags, NxRaycastHit & hit, bool firstHit) const;
    virtual bool checkOverlapSphere(const NxSphere & worldSphere) const;
    virtual bool checkOverlapOBB(const NxBox & worldBox) const;
    virtual bool checkOverlapAABB(const NxBounds3 & worldBounds) const;
    virtual bool checkOverlapCapsule(const NxCapsule & worldCapsule) const;
    virtual NxActor & getActor() const;
    virtual void setGroup(NxCollisionGroup collisionGroup) ;
    virtual NxCollisionGroup getGroup() const;
    virtual void getWorldBounds(NxBounds3 & dest) const;
    virtual void setFlag(NxShapeFlag flag, bool value) ;
    virtual NX_BOOL getFlag(NxShapeFlag flag) const;
    virtual void setMaterial(NxMaterialIndex matIndex) ;
    virtual NxMaterialIndex getMaterial() const;
    virtual void setSkinWidth(NxReal skinWidth) ;
    virtual NxReal getSkinWidth() const;
    virtual NxShapeType getType() const;
    virtual void setCCDSkeleton(NxCCDSkeleton * ccdSkel) ;
    virtual NxCCDSkeleton * getCCDSkeleton() const;
    virtual void setName(const char * name) ;
    virtual const char * getName() const;
    virtual void setGroupsMask(const NxGroupsMask & mask) ;
    virtual const NxGroupsMask getGroupsMask() const;
    virtual NxU32 getNonInteractingCompartmentTypes() const;
    virtual void setNonInteractingCompartmentTypes(NxU32 compartmentTypes) ;
    static inline int getPointerStart() { return NxShape_doxybind::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 3; }
};

class NxConvexShapeDesc_doxybind : public NxConvexShapeDesc, public  DoxyBindObject 
{
public:
    NxConvexShapeDesc_doxybind();
    virtual void setToDefault() ;
    virtual bool isValid() const;
    static inline int getPointerStart() { return NxShapeDesc_doxybind::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 2; }
};

class NxCookingInterface_doxybind : public NxCookingInterface, public  DoxyBindObject 
{
public:
    virtual bool NxSetCookingParams(const NxCookingParams & params) ;
    virtual const NxCookingParams & NxGetCookingParams() ;
    virtual bool NxPlatformMismatch() ;
    virtual bool NxInitCooking(NxUserAllocator * allocator, NxUserOutputStream * outputStream) ;
    virtual bool NxInitCooking(NxUserAllocator * allocator) ;
    virtual void NxCloseCooking() ;
    virtual bool NxCookTriangleMesh(const NxTriangleMeshDesc & desc, NxStream & stream) ;
    virtual bool NxCookConvexMesh(const NxConvexMeshDesc & desc, NxStream & stream) ;
    virtual bool NxCookClothMesh(const NxClothMeshDesc & desc, NxStream & stream) ;
    virtual bool NxCookSoftBodyMesh(const NxSoftBodyMeshDesc & desc, NxStream & stream) ;
    virtual bool NxCreatePMap(NxPMap & pmap, const NxTriangleMesh & mesh, NxU32 density, NxUserOutputStream * outputStream) ;
    virtual bool NxCreatePMap(NxPMap & pmap, const NxTriangleMesh & mesh, NxU32 density) ;
    virtual bool NxReleasePMap(NxPMap & pmap) ;
    virtual bool NxScaleCookedConvexMesh(const NxStream & source, NxReal scale, NxStream & dest) ;
    virtual void NxReportCooking() ;
    static inline int getPointerStart() { return DoxyBindObject::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 15; }
};

class NxJoint_doxybind : public NxJoint, public  DoxyBindObject 
{
public:
    virtual void setLimitPoint(const NxVec3 & point, bool pointIsOnActor2) ;
    virtual void setLimitPoint(const NxVec3 & point) ;
    virtual bool getLimitPoint(NxVec3 & worldLimitPoint) ;
    virtual bool addLimitPlane(const NxVec3 & normal, const NxVec3 & pointInPlane, NxReal restitution) ;
    virtual bool addLimitPlane(const NxVec3 & normal, const NxVec3 & pointInPlane) ;
    virtual void purgeLimitPlanes() ;
    virtual void resetLimitPlaneIterator() ;
    virtual bool hasMoreLimitPlanes() ;
    virtual bool getNextLimitPlane(NxVec3 & planeNormal, NxReal & planeD, NxReal * restitution) ;
    virtual bool getNextLimitPlane(NxVec3 & planeNormal, NxReal & planeD) ;
    virtual void * is(NxJointType type) ;
    NxJoint_doxybind();
    virtual void getActors(NxActor ** actor1, NxActor ** actor2) ;
    virtual void setGlobalAnchor(const NxVec3 & vec) ;
    virtual void setGlobalAxis(const NxVec3 & vec) ;
    virtual NxVec3 getGlobalAnchor() const;
    virtual NxVec3 getGlobalAxis() const;
    virtual NxJointState getState() ;
    virtual void setBreakable(NxReal maxForce, NxReal maxTorque) ;
    virtual void getBreakable(NxReal & maxForce, NxReal & maxTorque) ;
    virtual void setSolverExtrapolationFactor(NxReal solverExtrapolationFactor) ;
    virtual NxReal getSolverExtrapolationFactor() const;
    virtual void setUseAccelerationSpring(bool b) ;
    virtual bool getUseAccelerationSpring() const;
    virtual NxJointType getType() const;
    virtual void setName(const char * name) ;
    virtual const char * getName() const;
    virtual NxScene & getScene() const;
    static inline int getPointerStart() { return DoxyBindObject::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 27; }
};

class NxCylindricalJoint_doxybind : public NxCylindricalJoint, public  DoxyBindObject 
{
public:
    virtual void loadFromDesc(const NxCylindricalJointDesc & desc) ;
    virtual void saveToDesc(NxCylindricalJointDesc & desc) ;
    virtual void setLimitPoint(const NxVec3 & point, bool pointIsOnActor2) ;
    virtual void setLimitPoint(const NxVec3 & point) ;
    virtual bool getLimitPoint(NxVec3 & worldLimitPoint) ;
    virtual bool addLimitPlane(const NxVec3 & normal, const NxVec3 & pointInPlane, NxReal restitution) ;
    virtual bool addLimitPlane(const NxVec3 & normal, const NxVec3 & pointInPlane) ;
    virtual void purgeLimitPlanes() ;
    virtual void resetLimitPlaneIterator() ;
    virtual bool hasMoreLimitPlanes() ;
    virtual bool getNextLimitPlane(NxVec3 & planeNormal, NxReal & planeD, NxReal * restitution) ;
    virtual bool getNextLimitPlane(NxVec3 & planeNormal, NxReal & planeD) ;
    virtual void * is(NxJointType type) ;
    virtual void getActors(NxActor ** actor1, NxActor ** actor2) ;
    virtual void setGlobalAnchor(const NxVec3 & vec) ;
    virtual void setGlobalAxis(const NxVec3 & vec) ;
    virtual NxVec3 getGlobalAnchor() const;
    virtual NxVec3 getGlobalAxis() const;
    virtual NxJointState getState() ;
    virtual void setBreakable(NxReal maxForce, NxReal maxTorque) ;
    virtual void getBreakable(NxReal & maxForce, NxReal & maxTorque) ;
    virtual void setSolverExtrapolationFactor(NxReal solverExtrapolationFactor) ;
    virtual NxReal getSolverExtrapolationFactor() const;
    virtual void setUseAccelerationSpring(bool b) ;
    virtual bool getUseAccelerationSpring() const;
    virtual NxJointType getType() const;
    virtual void setName(const char * name) ;
    virtual const char * getName() const;
    virtual NxScene & getScene() const;
    static inline int getPointerStart() { return NxJoint_doxybind::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 2; }
};

class NxJointDesc_doxybind : public NxJointDesc, public  DoxyBindObject 
{
public:
    virtual void setToDefault() ;
    virtual bool isValid() const;
    NxJointDesc_doxybind(NxJointType t);
    static inline int getPointerStart() { return DoxyBindObject::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 2; }
};

class NxCylindricalJointDesc_doxybind : public NxCylindricalJointDesc, public  DoxyBindObject 
{
public:
    NxCylindricalJointDesc_doxybind();
    virtual void setToDefault() ;
    virtual bool isValid() const;
    static inline int getPointerStart() { return NxJointDesc_doxybind::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 2; }
};

class NxD6Joint_doxybind : public NxD6Joint, public  DoxyBindObject 
{
public:
    virtual void loadFromDesc(const NxD6JointDesc & desc) ;
    virtual void saveToDesc(NxD6JointDesc & desc) ;
    virtual void setDrivePosition(const NxVec3 & position) ;
    virtual void setDriveOrientation(const NxQuat & orientation) ;
    virtual void setDriveLinearVelocity(const NxVec3 & linVel) ;
    virtual void setDriveAngularVelocity(const NxVec3 & angVel) ;
    virtual void setLimitPoint(const NxVec3 & point, bool pointIsOnActor2) ;
    virtual void setLimitPoint(const NxVec3 & point) ;
    virtual bool getLimitPoint(NxVec3 & worldLimitPoint) ;
    virtual bool addLimitPlane(const NxVec3 & normal, const NxVec3 & pointInPlane, NxReal restitution) ;
    virtual bool addLimitPlane(const NxVec3 & normal, const NxVec3 & pointInPlane) ;
    virtual void purgeLimitPlanes() ;
    virtual void resetLimitPlaneIterator() ;
    virtual bool hasMoreLimitPlanes() ;
    virtual bool getNextLimitPlane(NxVec3 & planeNormal, NxReal & planeD, NxReal * restitution) ;
    virtual bool getNextLimitPlane(NxVec3 & planeNormal, NxReal & planeD) ;
    virtual void * is(NxJointType type) ;
    virtual void getActors(NxActor ** actor1, NxActor ** actor2) ;
    virtual void setGlobalAnchor(const NxVec3 & vec) ;
    virtual void setGlobalAxis(const NxVec3 & vec) ;
    virtual NxVec3 getGlobalAnchor() const;
    virtual NxVec3 getGlobalAxis() const;
    virtual NxJointState getState() ;
    virtual void setBreakable(NxReal maxForce, NxReal maxTorque) ;
    virtual void getBreakable(NxReal & maxForce, NxReal & maxTorque) ;
    virtual void setSolverExtrapolationFactor(NxReal solverExtrapolationFactor) ;
    virtual NxReal getSolverExtrapolationFactor() const;
    virtual void setUseAccelerationSpring(bool b) ;
    virtual bool getUseAccelerationSpring() const;
    virtual NxJointType getType() const;
    virtual void setName(const char * name) ;
    virtual const char * getName() const;
    virtual NxScene & getScene() const;
    static inline int getPointerStart() { return NxJoint_doxybind::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 6; }
};

class NxD6JointDesc_doxybind : public NxD6JointDesc, public  DoxyBindObject 
{
public:
    NxD6JointDesc_doxybind();
    virtual void setToDefault() ;
    virtual bool isValid() const;
    static inline int getPointerStart() { return NxJointDesc_doxybind::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 2; }
};

class NxDistanceJoint_doxybind : public NxDistanceJoint, public  DoxyBindObject 
{
public:
    virtual void loadFromDesc(const NxDistanceJointDesc & desc) ;
    virtual void saveToDesc(NxDistanceJointDesc & desc) ;
    virtual void setLimitPoint(const NxVec3 & point, bool pointIsOnActor2) ;
    virtual void setLimitPoint(const NxVec3 & point) ;
    virtual bool getLimitPoint(NxVec3 & worldLimitPoint) ;
    virtual bool addLimitPlane(const NxVec3 & normal, const NxVec3 & pointInPlane, NxReal restitution) ;
    virtual bool addLimitPlane(const NxVec3 & normal, const NxVec3 & pointInPlane) ;
    virtual void purgeLimitPlanes() ;
    virtual void resetLimitPlaneIterator() ;
    virtual bool hasMoreLimitPlanes() ;
    virtual bool getNextLimitPlane(NxVec3 & planeNormal, NxReal & planeD, NxReal * restitution) ;
    virtual bool getNextLimitPlane(NxVec3 & planeNormal, NxReal & planeD) ;
    virtual void * is(NxJointType type) ;
    virtual void getActors(NxActor ** actor1, NxActor ** actor2) ;
    virtual void setGlobalAnchor(const NxVec3 & vec) ;
    virtual void setGlobalAxis(const NxVec3 & vec) ;
    virtual NxVec3 getGlobalAnchor() const;
    virtual NxVec3 getGlobalAxis() const;
    virtual NxJointState getState() ;
    virtual void setBreakable(NxReal maxForce, NxReal maxTorque) ;
    virtual void getBreakable(NxReal & maxForce, NxReal & maxTorque) ;
    virtual void setSolverExtrapolationFactor(NxReal solverExtrapolationFactor) ;
    virtual NxReal getSolverExtrapolationFactor() const;
    virtual void setUseAccelerationSpring(bool b) ;
    virtual bool getUseAccelerationSpring() const;
    virtual NxJointType getType() const;
    virtual void setName(const char * name) ;
    virtual const char * getName() const;
    virtual NxScene & getScene() const;
    static inline int getPointerStart() { return NxJoint_doxybind::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 2; }
};

class NxDistanceJointDesc_doxybind : public NxDistanceJointDesc, public  DoxyBindObject 
{
public:
    NxDistanceJointDesc_doxybind();
    virtual bool isValid() const;
    virtual void setToDefault() ;
    static inline int getPointerStart() { return NxJointDesc_doxybind::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 1; }
};

class NxEffector_doxybind : public NxEffector, public  DoxyBindObject 
{
public:
    virtual NxEffectorType getType() const;
    virtual void setName(const char * name) ;
    virtual const char * getName() const;
    virtual NxScene & getScene() const;
    NxEffector_doxybind();
    static inline int getPointerStart() { return DoxyBindObject::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 4; }
};

class NxEffectorDesc_doxybind : public NxEffectorDesc, public  DoxyBindObject 
{
public:
    virtual void setToDefault() ;
    virtual bool isValid() const;
    NxEffectorDesc_doxybind(NxEffectorType type);
    static inline int getPointerStart() { return DoxyBindObject::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 2; }
};

class NxException_doxybind : public NxException, public  DoxyBindObject 
{
public:
    virtual NxErrorCode getErrorCode() ;
    virtual const char * getFile() ;
    virtual int getLine() ;
    static inline int getPointerStart() { return DoxyBindObject::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 3; }
};

class NxFixedJoint_doxybind : public NxFixedJoint, public  DoxyBindObject 
{
public:
    virtual void loadFromDesc(const NxFixedJointDesc & desc) ;
    virtual void saveToDesc(NxFixedJointDesc & desc) ;
    virtual void setLimitPoint(const NxVec3 & point, bool pointIsOnActor2) ;
    virtual void setLimitPoint(const NxVec3 & point) ;
    virtual bool getLimitPoint(NxVec3 & worldLimitPoint) ;
    virtual bool addLimitPlane(const NxVec3 & normal, const NxVec3 & pointInPlane, NxReal restitution) ;
    virtual bool addLimitPlane(const NxVec3 & normal, const NxVec3 & pointInPlane) ;
    virtual void purgeLimitPlanes() ;
    virtual void resetLimitPlaneIterator() ;
    virtual bool hasMoreLimitPlanes() ;
    virtual bool getNextLimitPlane(NxVec3 & planeNormal, NxReal & planeD, NxReal * restitution) ;
    virtual bool getNextLimitPlane(NxVec3 & planeNormal, NxReal & planeD) ;
    virtual void * is(NxJointType type) ;
    virtual void getActors(NxActor ** actor1, NxActor ** actor2) ;
    virtual void setGlobalAnchor(const NxVec3 & vec) ;
    virtual void setGlobalAxis(const NxVec3 & vec) ;
    virtual NxVec3 getGlobalAnchor() const;
    virtual NxVec3 getGlobalAxis() const;
    virtual NxJointState getState() ;
    virtual void setBreakable(NxReal maxForce, NxReal maxTorque) ;
    virtual void getBreakable(NxReal & maxForce, NxReal & maxTorque) ;
    virtual void setSolverExtrapolationFactor(NxReal solverExtrapolationFactor) ;
    virtual NxReal getSolverExtrapolationFactor() const;
    virtual void setUseAccelerationSpring(bool b) ;
    virtual bool getUseAccelerationSpring() const;
    virtual NxJointType getType() const;
    virtual void setName(const char * name) ;
    virtual const char * getName() const;
    virtual NxScene & getScene() const;
    static inline int getPointerStart() { return NxJoint_doxybind::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 2; }
};

class NxFixedJointDesc_doxybind : public NxFixedJointDesc, public  DoxyBindObject 
{
public:
    NxFixedJointDesc_doxybind();
    virtual void setToDefault() ;
    virtual bool isValid() const;
    static inline int getPointerStart() { return NxJointDesc_doxybind::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 2; }
};

class NxFluidEmitter_doxybind : public NxFluidEmitter, public  DoxyBindObject 
{
public:
    virtual bool loadFromDesc(const NxFluidEmitterDesc & desc) ;
    virtual bool saveToDesc(NxFluidEmitterDesc & desc) const;
    NxFluidEmitter_doxybind();
    virtual NxFluid & getFluid() const;
    virtual void setGlobalPose(const NxMat34 & mat) ;
    virtual void setGlobalPosition(const NxVec3 & vec) ;
    virtual void setGlobalOrientation(const NxMat33 & mat) ;
    virtual void setLocalPose(const NxMat34 & mat) ;
    virtual void setLocalPosition(const NxVec3 & vec) ;
    virtual void setLocalOrientation(const NxMat33 & mat) ;
    virtual void setFrameShape(NxShape * shape) ;
    virtual NxShape * getFrameShape() const;
    virtual NxReal getDimensionX() const;
    virtual NxReal getDimensionY() const;
    virtual void setRandomPos(NxVec3 disp) ;
    virtual NxVec3 getRandomPos() const;
    virtual void setRandomAngle(NxReal angle) ;
    virtual NxReal getRandomAngle() const;
    virtual void setFluidVelocityMagnitude(NxReal vel) ;
    virtual NxReal getFluidVelocityMagnitude() const;
    virtual void setRate(NxReal rate) ;
    virtual NxReal getRate() const;
    virtual void setParticleLifetime(NxReal life) ;
    virtual NxReal getParticleLifetime() const;
    virtual void setRepulsionCoefficient(NxReal coefficient) ;
    virtual NxReal getRepulsionCoefficient() const;
    virtual void resetEmission(NxU32 maxParticles) ;
    virtual NxU32 getMaxParticles() const;
    virtual NxU32 getNbParticlesEmitted() const;
    virtual void setFlag(NxFluidEmitterFlag flag, bool val) ;
    virtual NX_BOOL getFlag(NxFluidEmitterFlag flag) const;
    virtual NX_BOOL getShape(NxEmitterShape shape) const;
    virtual NX_BOOL getType(NxEmitterType type) const;
    virtual void setName(const char * name) ;
    virtual const char * getName() const;
    static inline int getPointerStart() { return DoxyBindObject::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 34; }
};

class NxFluidUserNotify_doxybind : public NxFluidUserNotify, public  DoxyBindObject 
{
public:
    virtual bool onEmitterEvent(NxFluidEmitter & emitter, NxFluidEmitterEventType eventType) ;
    virtual bool onEvent(NxFluid & fluid, NxFluidEventType eventType) ;
    static inline int getPointerStart() { return DoxyBindObject::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 2; }
};

class NxForceField_doxybind : public NxForceField, public  DoxyBindObject 
{
public:
    NxForceField_doxybind();
    virtual void saveToDesc(NxForceFieldDesc & desc) ;
    virtual NxMat34 getPose() const;
    virtual void setPose(const NxMat34 & pose) ;
    virtual NxActor * getActor() const;
    virtual void setActor(NxActor * actor) ;
    virtual void setForceFieldKernel(NxForceFieldKernel * kernel) ;
    virtual NxForceFieldKernel * getForceFieldKernel() ;
    virtual NxForceFieldShapeGroup & getIncludeShapeGroup() ;
    virtual void addShapeGroup(NxForceFieldShapeGroup & group) ;
    virtual void removeShapeGroup(NxForceFieldShapeGroup & unknown9) ;
    virtual NxU32 getNbShapeGroups() const;
    virtual void resetShapeGroupsIterator() ;
    virtual NxForceFieldShapeGroup * getNextShapeGroup() ;
    virtual NxCollisionGroup getGroup() const;
    virtual void setGroup(NxCollisionGroup collisionGroup) ;
    virtual NxGroupsMask getGroupsMask() const;
    virtual void setGroupsMask(NxGroupsMask mask) ;
    virtual NxForceFieldCoordinates getCoordinates() const;
    virtual void setCoordinates(NxForceFieldCoordinates coordinates) ;
    virtual void setName(const char * name) ;
    virtual const char * getName() const;
    virtual NxForceFieldType getFluidType() const;
    virtual void setFluidType(NxForceFieldType t) ;
    virtual NxForceFieldType getClothType() const;
    virtual void setClothType(NxForceFieldType t) ;
    virtual NxForceFieldType getSoftBodyType() const;
    virtual void setSoftBodyType(NxForceFieldType t) ;
    virtual NxForceFieldType getRigidBodyType() const;
    virtual void setRigidBodyType(NxForceFieldType t) ;
    virtual NxU32 getFlags() const;
    virtual void setFlags(NxU32 f) ;
    virtual void samplePoints(NxU32 numPoints, const NxVec3 * points, const NxVec3 * velocities, NxVec3 * outForces, NxVec3 * outTorques) const;
    virtual NxScene & getScene() const;
    virtual NxForceFieldVariety getForceFieldVariety() const;
    virtual void setForceFieldVariety(NxForceFieldVariety unknown10) ;
    static inline int getPointerStart() { return DoxyBindObject::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 35; }
};

class NxForceFieldKernel_doxybind : public NxForceFieldKernel, public  DoxyBindObject 
{
public:
    virtual void parse() const;
    virtual bool evaluate(NxVec3 & force, NxVec3 & torque, const NxVec3 & position, const NxVec3 & velocity) const;
    virtual NxU32 getType() const;
    virtual NxForceFieldKernel * clone() const;
    virtual void update(NxForceFieldKernel & in) const;
    virtual void setEpsilon(NxReal eps) ;
    static inline int getPointerStart() { return DoxyBindObject::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 6; }
};

class NxForceFieldLinearKernel_doxybind : public NxForceFieldLinearKernel, public  DoxyBindObject 
{
public:
    NxForceFieldLinearKernel_doxybind();
    virtual NxVec3 getConstant() const;
    virtual void setConstant(const NxVec3 & unknown11) ;
    virtual NxMat33 getPositionMultiplier() const;
    virtual void setPositionMultiplier(const NxMat33 & unknown12) ;
    virtual NxMat33 getVelocityMultiplier() const;
    virtual void setVelocityMultiplier(const NxMat33 & unknown13) ;
    virtual NxVec3 getPositionTarget() const;
    virtual void setPositionTarget(const NxVec3 & unknown14) ;
    virtual NxVec3 getVelocityTarget() const;
    virtual void setVelocityTarget(const NxVec3 & unknown15) ;
    virtual NxVec3 getFalloffLinear() const;
    virtual void setFalloffLinear(const NxVec3 & unknown16) ;
    virtual NxVec3 getFalloffQuadratic() const;
    virtual void setFalloffQuadratic(const NxVec3 & unknown17) ;
    virtual NxVec3 getNoise() const;
    virtual void setNoise(const NxVec3 & unknown18) ;
    virtual NxReal getTorusRadius() const;
    virtual void setTorusRadius(NxReal unknown19) ;
    virtual NxScene & getScene() const;
    virtual void saveToDesc(NxForceFieldLinearKernelDesc & desc) ;
    virtual void setName(const char * name) ;
    virtual const char * getName() const;
    virtual void parse() const;
    virtual bool evaluate(NxVec3 & force, NxVec3 & torque, const NxVec3 & position, const NxVec3 & velocity) const;
    virtual NxU32 getType() const;
    virtual NxForceFieldKernel * clone() const;
    virtual void update(NxForceFieldKernel & in) const;
    virtual void setEpsilon(NxReal eps) ;
    static inline int getPointerStart() { return NxForceFieldKernel_doxybind::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 22; }
};

class NxForceFieldShapeGroup_doxybind : public NxForceFieldShapeGroup, public  DoxyBindObject 
{
public:
    NxForceFieldShapeGroup_doxybind();
    virtual NxForceFieldShape * createShape(const NxForceFieldShapeDesc & unknown20) ;
    virtual void releaseShape(const NxForceFieldShape & unknown21) ;
    virtual NxU32 getNbShapes() const;
    virtual void resetShapesIterator() ;
    virtual NxForceFieldShape * getNextShape() ;
    virtual NxForceField * getForceField() const;
    virtual NxU32 getFlags() const;
    virtual void saveToDesc(NxForceFieldShapeGroupDesc & desc) ;
    virtual NxScene & getScene() const;
    virtual void setName(const char * name) ;
    virtual const char * getName() const;
    static inline int getPointerStart() { return DoxyBindObject::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 11; }
};

class NxFoundationSDK_doxybind : public NxFoundationSDK, public  DoxyBindObject 
{
public:
    virtual void release() ;
    virtual void setErrorStream(NxUserOutputStream * stream) ;
    virtual NxUserOutputStream * getErrorStream() ;
    virtual NxErrorCode getLastError() ;
    virtual NxErrorCode getFirstError() ;
    virtual NxUserAllocator & getAllocator() ;
    virtual NxRemoteDebugger * getRemoteDebugger() ;
    virtual void setAllocaThreshold(NxU32 threshold) ;
    static inline int getPointerStart() { return DoxyBindObject::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 8; }
};

class NxHeightField_doxybind : public NxHeightField, public  DoxyBindObject 
{
public:
    virtual bool saveToDesc(NxHeightFieldDesc & desc) const;
    virtual bool loadFromDesc(const NxHeightFieldDesc & desc) ;
    virtual NxU32 saveCells(void * destBuffer, NxU32 destBufferSize) const;
    virtual NxU32 getNbRows() const;
    virtual NxU32 getNbColumns() const;
    virtual NxHeightFieldFormat getFormat() const;
    virtual NxU32 getSampleStride() const;
    virtual NxReal getVerticalExtent() const;
    virtual NxReal getThickness() const;
    virtual NxReal getConvexEdgeThreshold() const;
    virtual NxU32 getFlags() const;
    virtual NxReal getHeight(NxReal x, NxReal z) const;
    virtual const void * getCells() const;
    virtual NxU32 getReferenceCount() ;
    static inline int getPointerStart() { return DoxyBindObject::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 14; }
};

class NxHeightFieldShape_doxybind : public NxHeightFieldShape, public  DoxyBindObject 
{
public:
    virtual void saveToDesc(NxHeightFieldShapeDesc & desc) const;
    virtual NxHeightField & getHeightField() const;
    virtual NxReal getHeightScale() const;
    virtual NxReal getRowScale() const;
    virtual NxReal getColumnScale() const;
    virtual void setHeightScale(NxReal scale) ;
    virtual void setRowScale(NxReal scale) ;
    virtual void setColumnScale(NxReal scale) ;
    virtual NxU32 getTriangle(NxTriangle & worldTri, NxTriangle * edgeTri, NxU32 * flags, NxTriangleID triangleIndex, bool worldSpaceTranslation, bool worldSpaceRotation) const;
    virtual NxU32 getTriangle(NxTriangle & worldTri, NxTriangle * edgeTri, NxU32 * flags, NxTriangleID triangleIndex, bool worldSpaceTranslation) const;
    virtual NxU32 getTriangle(NxTriangle & worldTri, NxTriangle * edgeTri, NxU32 * flags, NxTriangleID triangleIndex) const;
    virtual bool overlapAABBTrianglesDeprecated(const NxBounds3 & bounds, NxU32 flags, NxU32 & nb, const NxU32 *& indices) const;
    virtual bool overlapAABBTriangles(const NxBounds3 & bounds, NxU32 flags, NxUserEntityReport< NxU32 > * callback) const;
    virtual bool isShapePointOnHeightField(NxReal x, NxReal z) const;
    virtual NxReal getHeightAtShapePoint(NxReal x, NxReal z) const;
    virtual NxMaterialIndex getMaterialAtShapePoint(NxReal x, NxReal z) const;
    virtual NxVec3 getNormalAtShapePoint(NxReal x, NxReal z) const;
    virtual NxVec3 getSmoothNormalAtShapePoint(NxReal x, NxReal z) const;
    virtual void setLocalPose(const NxMat34 & mat) ;
    virtual void setLocalPosition(const NxVec3 & vec) ;
    virtual void setLocalOrientation(const NxMat33 & mat) ;
    virtual NxMat34 getLocalPose() const;
    virtual NxVec3 getLocalPosition() const;
    virtual NxMat33 getLocalOrientation() const;
    virtual void setGlobalPose(const NxMat34 & mat) ;
    virtual void setGlobalPosition(const NxVec3 & vec) ;
    virtual void setGlobalOrientation(const NxMat33 & mat) ;
    virtual NxMat34 getGlobalPose() const;
    virtual NxVec3 getGlobalPosition() const;
    virtual NxMat33 getGlobalOrientation() const;
    virtual void * is(NxShapeType type) ;
    virtual const void * is(NxShapeType type) const;
    virtual bool raycast(const NxRay & worldRay, NxReal maxDist, NxU32 hintFlags, NxRaycastHit & hit, bool firstHit) const;
    virtual bool checkOverlapSphere(const NxSphere & worldSphere) const;
    virtual bool checkOverlapOBB(const NxBox & worldBox) const;
    virtual bool checkOverlapAABB(const NxBounds3 & worldBounds) const;
    virtual bool checkOverlapCapsule(const NxCapsule & worldCapsule) const;
    virtual NxActor & getActor() const;
    virtual void setGroup(NxCollisionGroup collisionGroup) ;
    virtual NxCollisionGroup getGroup() const;
    virtual void getWorldBounds(NxBounds3 & dest) const;
    virtual void setFlag(NxShapeFlag flag, bool value) ;
    virtual NX_BOOL getFlag(NxShapeFlag flag) const;
    virtual void setMaterial(NxMaterialIndex matIndex) ;
    virtual NxMaterialIndex getMaterial() const;
    virtual void setSkinWidth(NxReal skinWidth) ;
    virtual NxReal getSkinWidth() const;
    virtual NxShapeType getType() const;
    virtual void setCCDSkeleton(NxCCDSkeleton * ccdSkel) ;
    virtual NxCCDSkeleton * getCCDSkeleton() const;
    virtual void setName(const char * name) ;
    virtual const char * getName() const;
    virtual void setGroupsMask(const NxGroupsMask & mask) ;
    virtual const NxGroupsMask getGroupsMask() const;
    virtual NxU32 getNonInteractingCompartmentTypes() const;
    virtual void setNonInteractingCompartmentTypes(NxU32 compartmentTypes) ;
    static inline int getPointerStart() { return NxShape_doxybind::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 18; }
};

class NxHeightFieldShapeDesc_doxybind : public NxHeightFieldShapeDesc, public  DoxyBindObject 
{
public:
    NxHeightFieldShapeDesc_doxybind();
    virtual void setToDefault() ;
    virtual bool isValid() const;
    static inline int getPointerStart() { return NxShapeDesc_doxybind::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 2; }
};

class NxInterface_doxybind : public NxInterface, public  DoxyBindObject 
{
public:
    virtual int getVersionNumber() const;
    virtual NxInterfaceType getInterfaceType() const;
    static inline int getPointerStart() { return DoxyBindObject::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 2; }
};

class NxInterfaceStats_doxybind : public NxInterfaceStats, public  DoxyBindObject 
{
public:
    virtual int getVersionNumber() const;
    virtual NxInterfaceType getInterfaceType() const;
    virtual bool getHeapSize(int & used, int & unused) ;
    static inline int getPointerStart() { return NxInterface_doxybind::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 3; }
};

class NxMaterial_doxybind : public NxMaterial, public  DoxyBindObject 
{
public:
    NxMaterial_doxybind();
    virtual NxMaterialIndex getMaterialIndex() ;
    virtual void loadFromDesc(const NxMaterialDesc & desc) ;
    virtual void saveToDesc(NxMaterialDesc & desc) const;
    virtual NxScene & getScene() const;
    virtual void setDynamicFriction(NxReal coef) ;
    virtual NxReal getDynamicFriction() const;
    virtual void setStaticFriction(NxReal coef) ;
    virtual NxReal getStaticFriction() const;
    virtual void setRestitution(NxReal rest) ;
    virtual NxReal getRestitution() const;
    virtual void setDynamicFrictionV(NxReal coef) ;
    virtual NxReal getDynamicFrictionV() const;
    virtual void setStaticFrictionV(NxReal coef) ;
    virtual NxReal getStaticFrictionV() const;
    virtual void setDirOfAnisotropy(const NxVec3 & vec) ;
    virtual NxVec3 getDirOfAnisotropy() const;
    virtual void setFlags(NxU32 flags) ;
    virtual NxU32 getFlags() const;
    virtual void setFrictionCombineMode(NxCombineMode combMode) ;
    virtual NxCombineMode getFrictionCombineMode() const;
    virtual void setRestitutionCombineMode(NxCombineMode combMode) ;
    virtual NxCombineMode getRestitutionCombineMode() const;
    static inline int getPointerStart() { return DoxyBindObject::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 22; }
};

class NxPhysicsSDK_doxybind : public NxPhysicsSDK, public  DoxyBindObject 
{
public:
    NxPhysicsSDK_doxybind();
    virtual void release() ;
    virtual bool setParameter(NxParameter paramEnum, NxReal paramValue) ;
    virtual NxReal getParameter(NxParameter paramEnum) const;
    virtual NxScene * createScene(const NxSceneDesc & sceneDesc) ;
    virtual void releaseScene(NxScene & scene) ;
    virtual NxU32 getNbScenes() const;
    virtual NxScene * getScene(NxU32 i) ;
    virtual NxTriangleMesh * createTriangleMesh(const NxStream & stream) ;
    virtual void releaseTriangleMesh(NxTriangleMesh & mesh) ;
    virtual NxU32 getNbTriangleMeshes() const;
    virtual NxHeightField * createHeightField(const NxHeightFieldDesc & desc) ;
    virtual void releaseHeightField(NxHeightField & heightField) ;
    virtual NxU32 getNbHeightFields() const;
    virtual NxCCDSkeleton * createCCDSkeleton(const NxSimpleTriangleMesh & mesh) ;
    virtual NxCCDSkeleton * createCCDSkeleton(const void * memoryBuffer, NxU32 bufferSize) ;
    virtual void releaseCCDSkeleton(NxCCDSkeleton & skel) ;
    virtual NxU32 getNbCCDSkeletons() const;
    virtual NxConvexMesh * createConvexMesh(const NxStream & mesh) ;
    virtual void releaseConvexMesh(NxConvexMesh & mesh) ;
    virtual NxU32 getNbConvexMeshes() const;
    virtual NxClothMesh * createClothMesh(NxStream & stream) ;
    virtual void releaseClothMesh(NxClothMesh & cloth) ;
    virtual NxU32 getNbClothMeshes() const;
    virtual NxClothMesh ** getClothMeshes() ;
    virtual NxSoftBodyMesh * createSoftBodyMesh(NxStream & stream) ;
    virtual void releaseSoftBodyMesh(NxSoftBodyMesh & softBodyMesh) ;
    virtual NxU32 getNbSoftBodyMeshes() const;
    virtual NxSoftBodyMesh ** getSoftBodyMeshes() ;
    virtual NxU32 getInternalVersion(NxU32 & apiRev, NxU32 & descRev, NxU32 & branchId) const;
    virtual NxInterface * getInterface(NxInterfaceType type, int versionNumber) ;
    virtual NxHWVersion getHWVersion() const;
    virtual NxU32 getNbPPUs() const;
    virtual NxFoundationSDK & getFoundationSDK() const;
    static inline int getPointerStart() { return DoxyBindObject::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 33; }
};

class NxPlaneShape_doxybind : public NxPlaneShape, public  DoxyBindObject 
{
public:
    virtual void setPlane(const NxVec3 & normal, NxReal d) ;
    virtual void saveToDesc(NxPlaneShapeDesc & desc) const;
    virtual NxPlane getPlane() const;
    virtual void setLocalPose(const NxMat34 & mat) ;
    virtual void setLocalPosition(const NxVec3 & vec) ;
    virtual void setLocalOrientation(const NxMat33 & mat) ;
    virtual NxMat34 getLocalPose() const;
    virtual NxVec3 getLocalPosition() const;
    virtual NxMat33 getLocalOrientation() const;
    virtual void setGlobalPose(const NxMat34 & mat) ;
    virtual void setGlobalPosition(const NxVec3 & vec) ;
    virtual void setGlobalOrientation(const NxMat33 & mat) ;
    virtual NxMat34 getGlobalPose() const;
    virtual NxVec3 getGlobalPosition() const;
    virtual NxMat33 getGlobalOrientation() const;
    virtual void * is(NxShapeType type) ;
    virtual const void * is(NxShapeType type) const;
    virtual bool raycast(const NxRay & worldRay, NxReal maxDist, NxU32 hintFlags, NxRaycastHit & hit, bool firstHit) const;
    virtual bool checkOverlapSphere(const NxSphere & worldSphere) const;
    virtual bool checkOverlapOBB(const NxBox & worldBox) const;
    virtual bool checkOverlapAABB(const NxBounds3 & worldBounds) const;
    virtual bool checkOverlapCapsule(const NxCapsule & worldCapsule) const;
    virtual NxActor & getActor() const;
    virtual void setGroup(NxCollisionGroup collisionGroup) ;
    virtual NxCollisionGroup getGroup() const;
    virtual void getWorldBounds(NxBounds3 & dest) const;
    virtual void setFlag(NxShapeFlag flag, bool value) ;
    virtual NX_BOOL getFlag(NxShapeFlag flag) const;
    virtual void setMaterial(NxMaterialIndex matIndex) ;
    virtual NxMaterialIndex getMaterial() const;
    virtual void setSkinWidth(NxReal skinWidth) ;
    virtual NxReal getSkinWidth() const;
    virtual NxShapeType getType() const;
    virtual void setCCDSkeleton(NxCCDSkeleton * ccdSkel) ;
    virtual NxCCDSkeleton * getCCDSkeleton() const;
    virtual void setName(const char * name) ;
    virtual const char * getName() const;
    virtual void setGroupsMask(const NxGroupsMask & mask) ;
    virtual const NxGroupsMask getGroupsMask() const;
    virtual NxU32 getNonInteractingCompartmentTypes() const;
    virtual void setNonInteractingCompartmentTypes(NxU32 compartmentTypes) ;
    static inline int getPointerStart() { return NxShape_doxybind::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 3; }
};

class NxPlaneShapeDesc_doxybind : public NxPlaneShapeDesc, public  DoxyBindObject 
{
public:
    NxPlaneShapeDesc_doxybind();
    virtual void setToDefault() ;
    virtual bool isValid() const;
    static inline int getPointerStart() { return NxShapeDesc_doxybind::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 2; }
};

class NxPointInPlaneJoint_doxybind : public NxPointInPlaneJoint, public  DoxyBindObject 
{
public:
    virtual void loadFromDesc(const NxPointInPlaneJointDesc & desc) ;
    virtual void saveToDesc(NxPointInPlaneJointDesc & desc) ;
    virtual void setLimitPoint(const NxVec3 & point, bool pointIsOnActor2) ;
    virtual void setLimitPoint(const NxVec3 & point) ;
    virtual bool getLimitPoint(NxVec3 & worldLimitPoint) ;
    virtual bool addLimitPlane(const NxVec3 & normal, const NxVec3 & pointInPlane, NxReal restitution) ;
    virtual bool addLimitPlane(const NxVec3 & normal, const NxVec3 & pointInPlane) ;
    virtual void purgeLimitPlanes() ;
    virtual void resetLimitPlaneIterator() ;
    virtual bool hasMoreLimitPlanes() ;
    virtual bool getNextLimitPlane(NxVec3 & planeNormal, NxReal & planeD, NxReal * restitution) ;
    virtual bool getNextLimitPlane(NxVec3 & planeNormal, NxReal & planeD) ;
    virtual void * is(NxJointType type) ;
    virtual void getActors(NxActor ** actor1, NxActor ** actor2) ;
    virtual void setGlobalAnchor(const NxVec3 & vec) ;
    virtual void setGlobalAxis(const NxVec3 & vec) ;
    virtual NxVec3 getGlobalAnchor() const;
    virtual NxVec3 getGlobalAxis() const;
    virtual NxJointState getState() ;
    virtual void setBreakable(NxReal maxForce, NxReal maxTorque) ;
    virtual void getBreakable(NxReal & maxForce, NxReal & maxTorque) ;
    virtual void setSolverExtrapolationFactor(NxReal solverExtrapolationFactor) ;
    virtual NxReal getSolverExtrapolationFactor() const;
    virtual void setUseAccelerationSpring(bool b) ;
    virtual bool getUseAccelerationSpring() const;
    virtual NxJointType getType() const;
    virtual void setName(const char * name) ;
    virtual const char * getName() const;
    virtual NxScene & getScene() const;
    static inline int getPointerStart() { return NxJoint_doxybind::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 2; }
};

class NxPointInPlaneJointDesc_doxybind : public NxPointInPlaneJointDesc, public  DoxyBindObject 
{
public:
    NxPointInPlaneJointDesc_doxybind();
    virtual void setToDefault() ;
    virtual bool isValid() const;
    static inline int getPointerStart() { return NxJointDesc_doxybind::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 2; }
};

class NxPointOnLineJoint_doxybind : public NxPointOnLineJoint, public  DoxyBindObject 
{
public:
    virtual void loadFromDesc(const NxPointOnLineJointDesc & desc) ;
    virtual void saveToDesc(NxPointOnLineJointDesc & desc) ;
    virtual void setLimitPoint(const NxVec3 & point, bool pointIsOnActor2) ;
    virtual void setLimitPoint(const NxVec3 & point) ;
    virtual bool getLimitPoint(NxVec3 & worldLimitPoint) ;
    virtual bool addLimitPlane(const NxVec3 & normal, const NxVec3 & pointInPlane, NxReal restitution) ;
    virtual bool addLimitPlane(const NxVec3 & normal, const NxVec3 & pointInPlane) ;
    virtual void purgeLimitPlanes() ;
    virtual void resetLimitPlaneIterator() ;
    virtual bool hasMoreLimitPlanes() ;
    virtual bool getNextLimitPlane(NxVec3 & planeNormal, NxReal & planeD, NxReal * restitution) ;
    virtual bool getNextLimitPlane(NxVec3 & planeNormal, NxReal & planeD) ;
    virtual void * is(NxJointType type) ;
    virtual void getActors(NxActor ** actor1, NxActor ** actor2) ;
    virtual void setGlobalAnchor(const NxVec3 & vec) ;
    virtual void setGlobalAxis(const NxVec3 & vec) ;
    virtual NxVec3 getGlobalAnchor() const;
    virtual NxVec3 getGlobalAxis() const;
    virtual NxJointState getState() ;
    virtual void setBreakable(NxReal maxForce, NxReal maxTorque) ;
    virtual void getBreakable(NxReal & maxForce, NxReal & maxTorque) ;
    virtual void setSolverExtrapolationFactor(NxReal solverExtrapolationFactor) ;
    virtual NxReal getSolverExtrapolationFactor() const;
    virtual void setUseAccelerationSpring(bool b) ;
    virtual bool getUseAccelerationSpring() const;
    virtual NxJointType getType() const;
    virtual void setName(const char * name) ;
    virtual const char * getName() const;
    virtual NxScene & getScene() const;
    static inline int getPointerStart() { return NxJoint_doxybind::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 2; }
};

class NxPointOnLineJointDesc_doxybind : public NxPointOnLineJointDesc, public  DoxyBindObject 
{
public:
    NxPointOnLineJointDesc_doxybind();
    virtual void setToDefault() ;
    virtual bool isValid() const;
    static inline int getPointerStart() { return NxJointDesc_doxybind::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 2; }
};

class NxPrismaticJoint_doxybind : public NxPrismaticJoint, public  DoxyBindObject 
{
public:
    virtual void loadFromDesc(const NxPrismaticJointDesc & desc) ;
    virtual void saveToDesc(NxPrismaticJointDesc & desc) ;
    virtual void setLimitPoint(const NxVec3 & point, bool pointIsOnActor2) ;
    virtual void setLimitPoint(const NxVec3 & point) ;
    virtual bool getLimitPoint(NxVec3 & worldLimitPoint) ;
    virtual bool addLimitPlane(const NxVec3 & normal, const NxVec3 & pointInPlane, NxReal restitution) ;
    virtual bool addLimitPlane(const NxVec3 & normal, const NxVec3 & pointInPlane) ;
    virtual void purgeLimitPlanes() ;
    virtual void resetLimitPlaneIterator() ;
    virtual bool hasMoreLimitPlanes() ;
    virtual bool getNextLimitPlane(NxVec3 & planeNormal, NxReal & planeD, NxReal * restitution) ;
    virtual bool getNextLimitPlane(NxVec3 & planeNormal, NxReal & planeD) ;
    virtual void * is(NxJointType type) ;
    virtual void getActors(NxActor ** actor1, NxActor ** actor2) ;
    virtual void setGlobalAnchor(const NxVec3 & vec) ;
    virtual void setGlobalAxis(const NxVec3 & vec) ;
    virtual NxVec3 getGlobalAnchor() const;
    virtual NxVec3 getGlobalAxis() const;
    virtual NxJointState getState() ;
    virtual void setBreakable(NxReal maxForce, NxReal maxTorque) ;
    virtual void getBreakable(NxReal & maxForce, NxReal & maxTorque) ;
    virtual void setSolverExtrapolationFactor(NxReal solverExtrapolationFactor) ;
    virtual NxReal getSolverExtrapolationFactor() const;
    virtual void setUseAccelerationSpring(bool b) ;
    virtual bool getUseAccelerationSpring() const;
    virtual NxJointType getType() const;
    virtual void setName(const char * name) ;
    virtual const char * getName() const;
    virtual NxScene & getScene() const;
    static inline int getPointerStart() { return NxJoint_doxybind::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 2; }
};

class NxPrismaticJointDesc_doxybind : public NxPrismaticJointDesc, public  DoxyBindObject 
{
public:
    NxPrismaticJointDesc_doxybind();
    virtual void setToDefault() ;
    virtual bool isValid() const;
    static inline int getPointerStart() { return NxJointDesc_doxybind::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 2; }
};

class NxProfileData_doxybind : public NxProfileData, public  DoxyBindObject 
{
public:
    NxProfileData_doxybind();
    virtual const NxProfileZone * getNamedZone(NxProfileZoneName unknown93) const;
    static inline int getPointerStart() { return 0; }
    static inline int getPointerEnd() { return getPointerStart() + 1; }
};

class NxPulleyJoint_doxybind : public NxPulleyJoint, public  DoxyBindObject 
{
public:
    virtual void loadFromDesc(const NxPulleyJointDesc & desc) ;
    virtual void saveToDesc(NxPulleyJointDesc & desc) ;
    virtual void setMotor(const NxMotorDesc & motorDesc) ;
    virtual bool getMotor(NxMotorDesc & motorDesc) ;
    virtual void setFlags(NxU32 flags) ;
    virtual NxU32 getFlags() ;
    virtual void setLimitPoint(const NxVec3 & point, bool pointIsOnActor2) ;
    virtual void setLimitPoint(const NxVec3 & point) ;
    virtual bool getLimitPoint(NxVec3 & worldLimitPoint) ;
    virtual bool addLimitPlane(const NxVec3 & normal, const NxVec3 & pointInPlane, NxReal restitution) ;
    virtual bool addLimitPlane(const NxVec3 & normal, const NxVec3 & pointInPlane) ;
    virtual void purgeLimitPlanes() ;
    virtual void resetLimitPlaneIterator() ;
    virtual bool hasMoreLimitPlanes() ;
    virtual bool getNextLimitPlane(NxVec3 & planeNormal, NxReal & planeD, NxReal * restitution) ;
    virtual bool getNextLimitPlane(NxVec3 & planeNormal, NxReal & planeD) ;
    virtual void * is(NxJointType type) ;
    virtual void getActors(NxActor ** actor1, NxActor ** actor2) ;
    virtual void setGlobalAnchor(const NxVec3 & vec) ;
    virtual void setGlobalAxis(const NxVec3 & vec) ;
    virtual NxVec3 getGlobalAnchor() const;
    virtual NxVec3 getGlobalAxis() const;
    virtual NxJointState getState() ;
    virtual void setBreakable(NxReal maxForce, NxReal maxTorque) ;
    virtual void getBreakable(NxReal & maxForce, NxReal & maxTorque) ;
    virtual void setSolverExtrapolationFactor(NxReal solverExtrapolationFactor) ;
    virtual NxReal getSolverExtrapolationFactor() const;
    virtual void setUseAccelerationSpring(bool b) ;
    virtual bool getUseAccelerationSpring() const;
    virtual NxJointType getType() const;
    virtual void setName(const char * name) ;
    virtual const char * getName() const;
    virtual NxScene & getScene() const;
    static inline int getPointerStart() { return NxJoint_doxybind::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 6; }
};

class NxPulleyJointDesc_doxybind : public NxPulleyJointDesc, public  DoxyBindObject 
{
public:
    NxPulleyJointDesc_doxybind();
    virtual void setToDefault() ;
    virtual bool isValid() const;
    static inline int getPointerStart() { return NxJointDesc_doxybind::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 2; }
};

class NxRemoteDebugger_doxybind : public NxRemoteDebugger, public  DoxyBindObject 
{
public:
    virtual void connect(const char * host, unsigned int port, NxU32 eventMask) ;
    virtual void connect(const char * host, unsigned int port) ;
    virtual void connect(const char * host) ;
    virtual void disconnect() ;
    virtual void flush() ;
    virtual bool isConnected() ;
    virtual void frameBreak() ;
    virtual void createObject(void * _object, NxRemoteDebuggerObjectType type, const char * className, NxU32 mask) ;
    virtual void removeObject(void * _object, NxU32 mask) ;
    virtual void addChild(void * _object, void * child, NxU32 mask) ;
    virtual void removeChild(void * _object, void * child, NxU32 mask) ;
    virtual void writeParameter(const NxReal & parameter, void * _object, bool create, const char * name, NxU32 mask) ;
    virtual void writeParameter(const NxU32 & parameter, void * _object, bool create, const char * name, NxU32 mask) ;
    virtual void writeParameter(const NxVec3 & parameter, void * _object, bool create, const char * name, NxU32 mask) ;
    virtual void writeParameter(const NxPlane & parameter, void * _object, bool create, const char * name, NxU32 mask) ;
    virtual void writeParameter(const NxMat34 & parameter, void * _object, bool create, const char * name, NxU32 mask) ;
    virtual void writeParameter(const NxMat33 & parameter, void * _object, bool create, const char * name, NxU32 mask) ;
    virtual void writeParameter(const NxU8 * parameter, void * _object, bool create, const char * name, NxU32 mask) ;
    virtual void writeParameter(const char * parameter, void * _object, bool create, const char * name, NxU32 mask) ;
    virtual void writeParameter(const bool & parameter, void * _object, bool create, const char * name, NxU32 mask) ;
    virtual void writeParameter(const void * parameter, void * _object, bool create, const char * name, NxU32 mask) ;
    virtual void setMask(NxU32 mask) ;
    virtual NxU32 getMask() ;
    virtual void * getPickedObject() ;
    virtual NxVec3 getPickPoint() ;
    virtual void registerEventListener(NxRemoteDebuggerEventListener * eventListener) ;
    virtual void unregisterEventListener(NxRemoteDebuggerEventListener * eventListener) ;
    static inline int getPointerStart() { return DoxyBindObject::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 27; }
};

class NxRemoteDebuggerEventListener_doxybind : public NxRemoteDebuggerEventListener, public  DoxyBindObject 
{
public:
    virtual void onConnect() ;
    virtual void onDisconnect() ;
    virtual void beforeMaskChange(NxU32 oldMask, NxU32 newMask) ;
    virtual void afterMaskChange(NxU32 oldMask, NxU32 newMask) ;
    static inline int getPointerStart() { return DoxyBindObject::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 4; }
};

class NxRevoluteJoint_doxybind : public NxRevoluteJoint, public  DoxyBindObject 
{
public:
    virtual void loadFromDesc(const NxRevoluteJointDesc & desc) ;
    virtual void saveToDesc(NxRevoluteJointDesc & desc) ;
    virtual void setLimits(const NxJointLimitPairDesc & pair) ;
    virtual bool getLimits(NxJointLimitPairDesc & pair) ;
    virtual void setMotor(const NxMotorDesc & motorDesc) ;
    virtual bool getMotor(NxMotorDesc & motorDesc) ;
    virtual void setSpring(const NxSpringDesc & springDesc) ;
    virtual bool getSpring(NxSpringDesc & springDesc) ;
    virtual NxReal getAngle() ;
    virtual NxReal getVelocity() ;
    virtual void setFlags(NxU32 flags) ;
    virtual NxU32 getFlags() ;
    virtual void setProjectionMode(NxJointProjectionMode projectionMode) ;
    virtual NxJointProjectionMode getProjectionMode() ;
    virtual void setLimitPoint(const NxVec3 & point, bool pointIsOnActor2) ;
    virtual void setLimitPoint(const NxVec3 & point) ;
    virtual bool getLimitPoint(NxVec3 & worldLimitPoint) ;
    virtual bool addLimitPlane(const NxVec3 & normal, const NxVec3 & pointInPlane, NxReal restitution) ;
    virtual bool addLimitPlane(const NxVec3 & normal, const NxVec3 & pointInPlane) ;
    virtual void purgeLimitPlanes() ;
    virtual void resetLimitPlaneIterator() ;
    virtual bool hasMoreLimitPlanes() ;
    virtual bool getNextLimitPlane(NxVec3 & planeNormal, NxReal & planeD, NxReal * restitution) ;
    virtual bool getNextLimitPlane(NxVec3 & planeNormal, NxReal & planeD) ;
    virtual void * is(NxJointType type) ;
    virtual void getActors(NxActor ** actor1, NxActor ** actor2) ;
    virtual void setGlobalAnchor(const NxVec3 & vec) ;
    virtual void setGlobalAxis(const NxVec3 & vec) ;
    virtual NxVec3 getGlobalAnchor() const;
    virtual NxVec3 getGlobalAxis() const;
    virtual NxJointState getState() ;
    virtual void setBreakable(NxReal maxForce, NxReal maxTorque) ;
    virtual void getBreakable(NxReal & maxForce, NxReal & maxTorque) ;
    virtual void setSolverExtrapolationFactor(NxReal solverExtrapolationFactor) ;
    virtual NxReal getSolverExtrapolationFactor() const;
    virtual void setUseAccelerationSpring(bool b) ;
    virtual bool getUseAccelerationSpring() const;
    virtual NxJointType getType() const;
    virtual void setName(const char * name) ;
    virtual const char * getName() const;
    virtual NxScene & getScene() const;
    static inline int getPointerStart() { return NxJoint_doxybind::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 14; }
};

class NxRevoluteJointDesc_doxybind : public NxRevoluteJointDesc, public  DoxyBindObject 
{
public:
    NxRevoluteJointDesc_doxybind();
    virtual bool isValid() const;
    virtual void setToDefault() ;
    static inline int getPointerStart() { return NxJointDesc_doxybind::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 1; }
};

class NxScene_doxybind : public NxScene, public  DoxyBindObject 
{
public:
    virtual NxActor * createActor(const NxActorDescBase & desc) ;
    virtual void releaseActor(NxActor & actor) ;
    virtual NxJoint * createJoint(const NxJointDesc & jointDesc) ;
    virtual void releaseJoint(NxJoint & joint) ;
    virtual NxSpringAndDamperEffector * createSpringAndDamperEffector(const NxSpringAndDamperEffectorDesc & springDesc) ;
    virtual NxEffector * createEffector(const NxEffectorDesc & desc) ;
    virtual void releaseEffector(NxEffector & effector) ;
    virtual NxForceField * createForceField(const NxForceFieldDesc & forceFieldDesc) ;
    virtual void releaseForceField(NxForceField & forceField) ;
    virtual NxU32 getNbForceFields() const;
    virtual NxForceField ** getForceFields() ;
    virtual NxForceFieldLinearKernel * createForceFieldLinearKernel(const NxForceFieldLinearKernelDesc & kernelDesc) ;
    virtual void releaseForceFieldLinearKernel(NxForceFieldLinearKernel & kernel) ;
    virtual NxU32 getNbForceFieldLinearKernels() const;
    virtual void resetForceFieldLinearKernelsIterator() ;
    virtual NxForceFieldLinearKernel * getNextForceFieldLinearKernel() ;
    virtual NxForceFieldShapeGroup * createForceFieldShapeGroup(const NxForceFieldShapeGroupDesc & desc) ;
    virtual void releaseForceFieldShapeGroup(NxForceFieldShapeGroup & group) ;
    virtual NxU32 getNbForceFieldShapeGroups() const;
    virtual void resetForceFieldShapeGroupsIterator() ;
    virtual NxForceFieldShapeGroup * getNextForceFieldShapeGroup() ;
    virtual NxForceFieldVariety createForceFieldVariety() ;
    virtual NxForceFieldVariety getHighestForceFieldVariety() const;
    virtual void releaseForceFieldVariety(NxForceFieldVariety var) ;
    virtual NxForceFieldMaterial createForceFieldMaterial() ;
    virtual NxForceFieldMaterial getHighestForceFieldMaterial() const;
    virtual void releaseForceFieldMaterial(NxForceFieldMaterial mat) ;
    virtual NxReal getForceFieldScale(NxForceFieldVariety var, NxForceFieldMaterial mat) ;
    virtual void setForceFieldScale(NxForceFieldVariety var, NxForceFieldMaterial mat, NxReal val) ;
    virtual NxMaterial * createMaterial(const NxMaterialDesc & matDesc) ;
    virtual void releaseMaterial(NxMaterial & material) ;
    virtual NxCompartment * createCompartment(const NxCompartmentDesc & compDesc) ;
    virtual NxU32 getNbCompartments() const;
    virtual NxU32 getCompartmentArray(NxCompartment ** userBuffer, NxU32 bufferSize, NxU32 & usersIterator) const;
    virtual void setActorPairFlags(NxActor & actorA, NxActor & actorB, NxU32 nxContactPairFlag) ;
    virtual NxU32 getActorPairFlags(NxActor & actorA, NxActor & actorB) const;
    virtual void setShapePairFlags(NxShape & shapeA, NxShape & shapeB, NxU32 nxContactPairFlag) ;
    virtual NxU32 getShapePairFlags(NxShape & shapeA, NxShape & shapeB) const;
    virtual NxU32 getNbPairs() const;
    virtual NxU32 getPairFlagArray(NxPairFlag * userArray, NxU32 numPairs) const;
    virtual void setGroupCollisionFlag(NxCollisionGroup group1, NxCollisionGroup group2, bool enable) ;
    virtual bool getGroupCollisionFlag(NxCollisionGroup group1, NxCollisionGroup group2) const;
    virtual void setDominanceGroupPair(NxDominanceGroup group1, NxDominanceGroup group2, NxConstraintDominance & dominance) ;
    virtual NxConstraintDominance getDominanceGroupPair(NxDominanceGroup group1, NxDominanceGroup group2) const;
    virtual void setActorGroupPairFlags(NxActorGroup group1, NxActorGroup group2, NxU32 flags) ;
    virtual NxU32 getActorGroupPairFlags(NxActorGroup group1, NxActorGroup group2) const;
    virtual NxU32 getNbActorGroupPairs() const;
    virtual NxU32 getActorGroupPairArray(NxActorGroupPair * userBuffer, NxU32 bufferSize, NxU32 & userIterator) const;
    virtual void setFilterOps(NxFilterOp op0, NxFilterOp op1, NxFilterOp op2) ;
    virtual void setFilterBool(bool flag) ;
    virtual void setFilterConstant0(const NxGroupsMask & mask) ;
    virtual void setFilterConstant1(const NxGroupsMask & mask) ;
    virtual void getFilterOps(NxFilterOp & op0, NxFilterOp & op1, NxFilterOp & op2) const;
    virtual bool getFilterBool() const;
    virtual NxGroupsMask getFilterConstant0() const;
    virtual NxGroupsMask getFilterConstant1() const;
    virtual NxU32 getNbActors() const;
    virtual NxActor ** getActors() ;
    virtual NxActiveTransform * getActiveTransforms(NxU32 & nbTransformsOut) ;
    virtual NxU32 getNbStaticShapes() const;
    virtual NxU32 getNbDynamicShapes() const;
    virtual NxU32 getTotalNbShapes() const;
    virtual NxU32 getNbJoints() const;
    virtual void resetJointIterator() ;
    virtual NxJoint * getNextJoint() ;
    virtual NxU32 getNbEffectors() const;
    virtual void resetEffectorIterator() ;
    virtual NxEffector * getNextEffector() ;
    virtual NxU32 getBoundForIslandSize(NxActor & actor) ;
    virtual NxU32 getIslandArrayFromActor(NxActor & actor, NxActor ** userBuffer, NxU32 bufferSize, NxU32 & userIterator) ;
    virtual NxU32 getNbMaterials() const;
    virtual NxU32 getMaterialArray(NxMaterial ** userBuffer, NxU32 bufferSize, NxU32 & usersIterator) ;
    virtual NxMaterialIndex getHighestMaterialIndex() const;
    virtual NxMaterial * getMaterialFromIndex(NxMaterialIndex matIndex) ;
    virtual void setUserNotify(NxUserNotify * callback) ;
    virtual NxUserNotify * getUserNotify() const;
    virtual void setFluidUserNotify(NxFluidUserNotify * callback) ;
    virtual NxFluidUserNotify * getFluidUserNotify() const;
    virtual void setClothUserNotify(NxClothUserNotify * callback) ;
    virtual NxClothUserNotify * getClothUserNotify() const;
    virtual void setSoftBodyUserNotify(NxSoftBodyUserNotify * callback) ;
    virtual NxSoftBodyUserNotify * getSoftBodyUserNotify() const;
    virtual void setUserContactModify(NxUserContactModify * callback) ;
    virtual NxUserContactModify * getUserContactModify() const;
    virtual void setUserTriggerReport(NxUserTriggerReport * callback) ;
    virtual NxUserTriggerReport * getUserTriggerReport() const;
    virtual void setUserContactReport(NxUserContactReport * callback) ;
    virtual NxUserContactReport * getUserContactReport() const;
    virtual void setUserActorPairFiltering(NxUserActorPairFiltering * callback) ;
    virtual NxUserActorPairFiltering * getUserActorPairFiltering() const;
    virtual bool raycastAnyBounds(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups, NxReal maxDist, const NxGroupsMask * groupsMask) const;
    virtual bool raycastAnyBounds(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups, NxReal maxDist) const;
    virtual bool raycastAnyBounds(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups) const;
    virtual bool raycastAnyBounds(const NxRay & worldRay, NxShapesType shapesType) const;
    virtual bool raycastAnyShape(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups, NxReal maxDist, const NxGroupsMask * groupsMask, NxShape ** cache) const;
    virtual bool raycastAnyShape(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups, NxReal maxDist, const NxGroupsMask * groupsMask) const;
    virtual bool raycastAnyShape(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups, NxReal maxDist) const;
    virtual bool raycastAnyShape(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups) const;
    virtual bool raycastAnyShape(const NxRay & worldRay, NxShapesType shapesType) const;
    virtual NxU32 raycastAllBounds(const NxRay & worldRay, NxUserRaycastReport & report, NxShapesType shapesType, NxU32 groups, NxReal maxDist, NxU32 hintFlags, const NxGroupsMask * groupsMask) const;
    virtual NxU32 raycastAllBounds(const NxRay & worldRay, NxUserRaycastReport & report, NxShapesType shapesType, NxU32 groups, NxReal maxDist, NxU32 hintFlags) const;
    virtual NxU32 raycastAllBounds(const NxRay & worldRay, NxUserRaycastReport & report, NxShapesType shapesType, NxU32 groups, NxReal maxDist) const;
    virtual NxU32 raycastAllBounds(const NxRay & worldRay, NxUserRaycastReport & report, NxShapesType shapesType, NxU32 groups) const;
    virtual NxU32 raycastAllBounds(const NxRay & worldRay, NxUserRaycastReport & report, NxShapesType shapesType) const;
    virtual NxU32 raycastAllShapes(const NxRay & worldRay, NxUserRaycastReport & report, NxShapesType shapesType, NxU32 groups, NxReal maxDist, NxU32 hintFlags, const NxGroupsMask * groupsMask) const;
    virtual NxU32 raycastAllShapes(const NxRay & worldRay, NxUserRaycastReport & report, NxShapesType shapesType, NxU32 groups, NxReal maxDist, NxU32 hintFlags) const;
    virtual NxU32 raycastAllShapes(const NxRay & worldRay, NxUserRaycastReport & report, NxShapesType shapesType, NxU32 groups, NxReal maxDist) const;
    virtual NxU32 raycastAllShapes(const NxRay & worldRay, NxUserRaycastReport & report, NxShapesType shapesType, NxU32 groups) const;
    virtual NxU32 raycastAllShapes(const NxRay & worldRay, NxUserRaycastReport & report, NxShapesType shapesType) const;
    virtual NxShape * raycastClosestBounds(const NxRay & worldRay, NxShapesType shapeType, NxRaycastHit & hit, NxU32 groups, NxReal maxDist, NxU32 hintFlags, const NxGroupsMask * groupsMask) const;
    virtual NxShape * raycastClosestBounds(const NxRay & worldRay, NxShapesType shapeType, NxRaycastHit & hit, NxU32 groups, NxReal maxDist, NxU32 hintFlags) const;
    virtual NxShape * raycastClosestBounds(const NxRay & worldRay, NxShapesType shapeType, NxRaycastHit & hit, NxU32 groups, NxReal maxDist) const;
    virtual NxShape * raycastClosestBounds(const NxRay & worldRay, NxShapesType shapeType, NxRaycastHit & hit, NxU32 groups) const;
    virtual NxShape * raycastClosestBounds(const NxRay & worldRay, NxShapesType shapeType, NxRaycastHit & hit) const;
    virtual NxShape * raycastClosestShape(const NxRay & worldRay, NxShapesType shapeType, NxRaycastHit & hit, NxU32 groups, NxReal maxDist, NxU32 hintFlags, const NxGroupsMask * groupsMask, NxShape ** cache) const;
    virtual NxShape * raycastClosestShape(const NxRay & worldRay, NxShapesType shapeType, NxRaycastHit & hit, NxU32 groups, NxReal maxDist, NxU32 hintFlags, const NxGroupsMask * groupsMask) const;
    virtual NxShape * raycastClosestShape(const NxRay & worldRay, NxShapesType shapeType, NxRaycastHit & hit, NxU32 groups, NxReal maxDist, NxU32 hintFlags) const;
    virtual NxShape * raycastClosestShape(const NxRay & worldRay, NxShapesType shapeType, NxRaycastHit & hit, NxU32 groups, NxReal maxDist) const;
    virtual NxShape * raycastClosestShape(const NxRay & worldRay, NxShapesType shapeType, NxRaycastHit & hit, NxU32 groups) const;
    virtual NxShape * raycastClosestShape(const NxRay & worldRay, NxShapesType shapeType, NxRaycastHit & hit) const;
    virtual NxU32 overlapSphereShapes(const NxSphere & worldSphere, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback, NxU32 activeGroups, const NxGroupsMask * groupsMask, bool accurateCollision) ;
    virtual NxU32 overlapSphereShapes(const NxSphere & worldSphere, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback, NxU32 activeGroups, const NxGroupsMask * groupsMask) ;
    virtual NxU32 overlapSphereShapes(const NxSphere & worldSphere, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback, NxU32 activeGroups) ;
    virtual NxU32 overlapSphereShapes(const NxSphere & worldSphere, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback) ;
    virtual NxU32 overlapAABBShapes(const NxBounds3 & worldBounds, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback, NxU32 activeGroups, const NxGroupsMask * groupsMask, bool accurateCollision) ;
    virtual NxU32 overlapAABBShapes(const NxBounds3 & worldBounds, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback, NxU32 activeGroups, const NxGroupsMask * groupsMask) ;
    virtual NxU32 overlapAABBShapes(const NxBounds3 & worldBounds, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback, NxU32 activeGroups) ;
    virtual NxU32 overlapAABBShapes(const NxBounds3 & worldBounds, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback) ;
    virtual NxU32 overlapOBBShapes(const NxBox & worldBox, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback, NxU32 activeGroups, const NxGroupsMask * groupsMask, bool accurateCollision) ;
    virtual NxU32 overlapOBBShapes(const NxBox & worldBox, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback, NxU32 activeGroups, const NxGroupsMask * groupsMask) ;
    virtual NxU32 overlapOBBShapes(const NxBox & worldBox, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback, NxU32 activeGroups) ;
    virtual NxU32 overlapOBBShapes(const NxBox & worldBox, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback) ;
    virtual NxU32 overlapCapsuleShapes(const NxCapsule & worldCapsule, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback, NxU32 activeGroups, const NxGroupsMask * groupsMask, bool accurateCollision) ;
    virtual NxU32 overlapCapsuleShapes(const NxCapsule & worldCapsule, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback, NxU32 activeGroups, const NxGroupsMask * groupsMask) ;
    virtual NxU32 overlapCapsuleShapes(const NxCapsule & worldCapsule, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback, NxU32 activeGroups) ;
    virtual NxU32 overlapCapsuleShapes(const NxCapsule & worldCapsule, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback) ;
    virtual NxSweepCache * createSweepCache() ;
    virtual void releaseSweepCache(NxSweepCache * cache) ;
    virtual NxU32 linearOBBSweep(const NxBox & worldBox, const NxVec3 & motion, NxU32 flags, void * userData, NxU32 nbShapes, NxSweepQueryHit * shapes, NxUserEntityReport< NxSweepQueryHit > * callback, NxU32 activeGroups, const NxGroupsMask * groupsMask) ;
    virtual NxU32 linearOBBSweep(const NxBox & worldBox, const NxVec3 & motion, NxU32 flags, void * userData, NxU32 nbShapes, NxSweepQueryHit * shapes, NxUserEntityReport< NxSweepQueryHit > * callback, NxU32 activeGroups) ;
    virtual NxU32 linearOBBSweep(const NxBox & worldBox, const NxVec3 & motion, NxU32 flags, void * userData, NxU32 nbShapes, NxSweepQueryHit * shapes, NxUserEntityReport< NxSweepQueryHit > * callback) ;
    virtual NxU32 linearCapsuleSweep(const NxCapsule & worldCapsule, const NxVec3 & motion, NxU32 flags, void * userData, NxU32 nbShapes, NxSweepQueryHit * shapes, NxUserEntityReport< NxSweepQueryHit > * callback, NxU32 activeGroups, const NxGroupsMask * groupsMask) ;
    virtual NxU32 linearCapsuleSweep(const NxCapsule & worldCapsule, const NxVec3 & motion, NxU32 flags, void * userData, NxU32 nbShapes, NxSweepQueryHit * shapes, NxUserEntityReport< NxSweepQueryHit > * callback, NxU32 activeGroups) ;
    virtual NxU32 linearCapsuleSweep(const NxCapsule & worldCapsule, const NxVec3 & motion, NxU32 flags, void * userData, NxU32 nbShapes, NxSweepQueryHit * shapes, NxUserEntityReport< NxSweepQueryHit > * callback) ;
    virtual NxU32 cullShapes(NxU32 nbPlanes, const NxPlane * worldPlanes, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback, NxU32 activeGroups, const NxGroupsMask * groupsMask) ;
    virtual NxU32 cullShapes(NxU32 nbPlanes, const NxPlane * worldPlanes, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback, NxU32 activeGroups) ;
    virtual NxU32 cullShapes(NxU32 nbPlanes, const NxPlane * worldPlanes, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback) ;
    virtual bool checkOverlapSphere(const NxSphere & worldSphere, NxShapesType shapeType, NxU32 activeGroups, const NxGroupsMask * groupsMask) ;
    virtual bool checkOverlapSphere(const NxSphere & worldSphere, NxShapesType shapeType, NxU32 activeGroups) ;
    virtual bool checkOverlapSphere(const NxSphere & worldSphere, NxShapesType shapeType) ;
    virtual bool checkOverlapSphere(const NxSphere & worldSphere) ;
    virtual bool checkOverlapAABB(const NxBounds3 & worldBounds, NxShapesType shapeType, NxU32 activeGroups, const NxGroupsMask * groupsMask) ;
    virtual bool checkOverlapAABB(const NxBounds3 & worldBounds, NxShapesType shapeType, NxU32 activeGroups) ;
    virtual bool checkOverlapAABB(const NxBounds3 & worldBounds, NxShapesType shapeType) ;
    virtual bool checkOverlapAABB(const NxBounds3 & worldBounds) ;
    virtual bool checkOverlapOBB(const NxBox & worldBox, NxShapesType shapeType, NxU32 activeGroups, const NxGroupsMask * groupsMask) ;
    virtual bool checkOverlapOBB(const NxBox & worldBox, NxShapesType shapeType, NxU32 activeGroups) ;
    virtual bool checkOverlapOBB(const NxBox & worldBox, NxShapesType shapeType) ;
    virtual bool checkOverlapOBB(const NxBox & worldBox) ;
    virtual bool checkOverlapCapsule(const NxCapsule & worldCapsule, NxShapesType shapeType, NxU32 activeGroups, const NxGroupsMask * groupsMask) ;
    virtual bool checkOverlapCapsule(const NxCapsule & worldCapsule, NxShapesType shapeType, NxU32 activeGroups) ;
    virtual bool checkOverlapCapsule(const NxCapsule & worldCapsule, NxShapesType shapeType) ;
    virtual bool checkOverlapCapsule(const NxCapsule & worldCapsule) ;
    virtual NxFluid * createFluid(const NxFluidDescBase & fluidDesc) ;
    virtual void releaseFluid(NxFluid & fluid) ;
    virtual NxU32 getNbFluids() const;
    virtual NxFluid ** getFluids() ;
    virtual bool cookFluidMeshHotspot(const NxBounds3 & bounds, NxU32 packetSizeMultiplier, NxReal restParticlesPerMeter, NxReal kernelRadiusMultiplier, NxReal motionLimitMultiplier, NxReal collisionDistanceMultiplier, NxCompartment * compartment, bool forceStrictCookingFormat) ;
    virtual bool cookFluidMeshHotspot(const NxBounds3 & bounds, NxU32 packetSizeMultiplier, NxReal restParticlesPerMeter, NxReal kernelRadiusMultiplier, NxReal motionLimitMultiplier, NxReal collisionDistanceMultiplier, NxCompartment * compartment) ;
    virtual bool cookFluidMeshHotspot(const NxBounds3 & bounds, NxU32 packetSizeMultiplier, NxReal restParticlesPerMeter, NxReal kernelRadiusMultiplier, NxReal motionLimitMultiplier, NxReal collisionDistanceMultiplier) ;
    virtual NxCloth * createCloth(const NxClothDesc & clothDesc) ;
    virtual void releaseCloth(NxCloth & cloth) ;
    virtual NxU32 getNbCloths() const;
    virtual NxCloth ** getCloths() ;
    virtual NxSoftBody * createSoftBody(const NxSoftBodyDesc & softBodyDesc) ;
    virtual void releaseSoftBody(NxSoftBody & softBody) ;
    virtual NxU32 getNbSoftBodies() const;
    virtual NxSoftBody ** getSoftBodies() ;
    NxScene_doxybind();
    virtual bool saveToDesc(NxSceneDesc & desc) const;
    virtual NxU32 getFlags() const;
    virtual NxSimulationType getSimType() const;
    virtual void * getInternal() ;
    virtual void setGravity(const NxVec3 & vec) ;
    virtual void getGravity(NxVec3 & vec) ;
    virtual void flushStream() ;
    virtual void setTiming(NxReal maxTimestep, NxU32 maxIter, NxTimeStepMethod method) ;
    virtual void setTiming(NxReal maxTimestep, NxU32 maxIter) ;
    virtual void setTiming(NxReal maxTimestep) ;
    virtual void getTiming(NxReal & maxTimestep, NxU32 & maxIter, NxTimeStepMethod & method, NxU32 * numSubSteps) const;
    virtual void getTiming(NxReal & maxTimestep, NxU32 & maxIter, NxTimeStepMethod & method) const;
    virtual const NxDebugRenderable * getDebugRenderable() ;
    virtual NxPhysicsSDK & getPhysicsSDK() ;
    virtual void getStats(NxSceneStats & stats) const;
    virtual const NxSceneStats2 * getStats2() const;
    virtual void getLimits(NxSceneLimits & limits) const;
    virtual void setMaxCPUForLoadBalancing(NxReal cpuFraction) ;
    virtual NxReal getMaxCPUForLoadBalancing() ;
    virtual bool isWritable() ;
    virtual void simulate(NxReal elapsedTime) ;
    virtual bool checkResults(NxSimulationStatus status, bool block) ;
    virtual bool checkResults(NxSimulationStatus status) ;
    virtual bool fetchResults(NxSimulationStatus status, bool block, NxU32 * errorState) ;
    virtual bool fetchResults(NxSimulationStatus status, bool block) ;
    virtual bool fetchResults(NxSimulationStatus status) ;
    virtual void flushCaches() ;
    virtual const NxProfileData * readProfileData(bool clearData) ;
    virtual NxThreadPollResult pollForWork(NxThreadWait waitType) ;
    virtual void resetPollForWork() ;
    virtual NxThreadPollResult pollForBackgroundWork(NxThreadWait waitType) ;
    virtual void shutdownWorkerThreads() ;
    virtual void lockQueries() ;
    virtual void unlockQueries() ;
    virtual NxSceneQuery * createSceneQuery(const NxSceneQueryDesc & desc) ;
    virtual bool releaseSceneQuery(NxSceneQuery & query) ;
    virtual void setDynamicTreeRebuildRateHint(NxU32 dynamicTreeRebuildRateHint) ;
    virtual NxU32 getDynamicTreeRebuildRateHint() const;
    virtual void setSolverBatchSize(NxU32 solverBatchSize) ;
    virtual NxU32 getSolverBatchSize() const;
    static inline int getPointerStart() { return DoxyBindObject::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 218; }
};

class NxSceneQuery_doxybind : public NxSceneQuery, public  DoxyBindObject 
{
public:
    virtual NxSceneQueryReport * getQueryReport() ;
    virtual NxSceneQueryExecuteMode getExecuteMode() ;
    virtual void execute() ;
    virtual bool finish(bool block) ;
    virtual bool raycastAnyShape(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups, NxReal maxDist, const NxGroupsMask * groupsMask, NxShape ** cache, void * userData) const;
    virtual bool raycastAnyShape(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups, NxReal maxDist, const NxGroupsMask * groupsMask, NxShape ** cache) const;
    virtual bool raycastAnyShape(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups, NxReal maxDist, const NxGroupsMask * groupsMask) const;
    virtual bool raycastAnyShape(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups, NxReal maxDist) const;
    virtual bool raycastAnyShape(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups) const;
    virtual bool raycastAnyShape(const NxRay & worldRay, NxShapesType shapesType) const;
    virtual bool checkOverlapSphere(const NxSphere & worldSphere, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask, void * userData) const;
    virtual bool checkOverlapSphere(const NxSphere & worldSphere, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask) const;
    virtual bool checkOverlapSphere(const NxSphere & worldSphere, NxShapesType shapesType, NxU32 activeGroups) const;
    virtual bool checkOverlapSphere(const NxSphere & worldSphere, NxShapesType shapesType) const;
    virtual bool checkOverlapSphere(const NxSphere & worldSphere) const;
    virtual bool checkOverlapAABB(const NxBounds3 & worldBounds, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask, void * userData) const;
    virtual bool checkOverlapAABB(const NxBounds3 & worldBounds, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask) const;
    virtual bool checkOverlapAABB(const NxBounds3 & worldBounds, NxShapesType shapesType, NxU32 activeGroups) const;
    virtual bool checkOverlapAABB(const NxBounds3 & worldBounds, NxShapesType shapesType) const;
    virtual bool checkOverlapAABB(const NxBounds3 & worldBounds) const;
    virtual bool checkOverlapOBB(const NxBox & worldBox, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask, void * userData) const;
    virtual bool checkOverlapOBB(const NxBox & worldBox, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask) const;
    virtual bool checkOverlapOBB(const NxBox & worldBox, NxShapesType shapesType, NxU32 activeGroups) const;
    virtual bool checkOverlapOBB(const NxBox & worldBox, NxShapesType shapesType) const;
    virtual bool checkOverlapOBB(const NxBox & worldBox) const;
    virtual bool checkOverlapCapsule(const NxCapsule & worldCapsule, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask, void * userData) const;
    virtual bool checkOverlapCapsule(const NxCapsule & worldCapsule, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask) const;
    virtual bool checkOverlapCapsule(const NxCapsule & worldCapsule, NxShapesType shapesType, NxU32 activeGroups) const;
    virtual bool checkOverlapCapsule(const NxCapsule & worldCapsule, NxShapesType shapesType) const;
    virtual bool checkOverlapCapsule(const NxCapsule & worldCapsule) const;
    virtual NxShape * raycastClosestShape(const NxRay & worldRay, NxShapesType shapesType, NxRaycastHit & hit, NxU32 groups, NxReal maxDist, NxU32 hintFlags, const NxGroupsMask * groupsMask, NxShape ** cache, void * userData) const;
    virtual NxShape * raycastClosestShape(const NxRay & worldRay, NxShapesType shapesType, NxRaycastHit & hit, NxU32 groups, NxReal maxDist, NxU32 hintFlags, const NxGroupsMask * groupsMask, NxShape ** cache) const;
    virtual NxShape * raycastClosestShape(const NxRay & worldRay, NxShapesType shapesType, NxRaycastHit & hit, NxU32 groups, NxReal maxDist, NxU32 hintFlags, const NxGroupsMask * groupsMask) const;
    virtual NxShape * raycastClosestShape(const NxRay & worldRay, NxShapesType shapesType, NxRaycastHit & hit, NxU32 groups, NxReal maxDist, NxU32 hintFlags) const;
    virtual NxShape * raycastClosestShape(const NxRay & worldRay, NxShapesType shapesType, NxRaycastHit & hit, NxU32 groups, NxReal maxDist) const;
    virtual NxShape * raycastClosestShape(const NxRay & worldRay, NxShapesType shapesType, NxRaycastHit & hit, NxU32 groups) const;
    virtual NxShape * raycastClosestShape(const NxRay & worldRay, NxShapesType shapesType, NxRaycastHit & hit) const;
    virtual NxU32 raycastAllShapes(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups, NxReal maxDist, NxU32 hintFlags, const NxGroupsMask * groupsMask, void * userData) const;
    virtual NxU32 raycastAllShapes(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups, NxReal maxDist, NxU32 hintFlags, const NxGroupsMask * groupsMask) const;
    virtual NxU32 raycastAllShapes(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups, NxReal maxDist, NxU32 hintFlags) const;
    virtual NxU32 raycastAllShapes(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups, NxReal maxDist) const;
    virtual NxU32 raycastAllShapes(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups) const;
    virtual NxU32 raycastAllShapes(const NxRay & worldRay, NxShapesType shapesType) const;
    virtual NxU32 overlapSphereShapes(const NxSphere & worldSphere, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask, void * userData) const;
    virtual NxU32 overlapSphereShapes(const NxSphere & worldSphere, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask) const;
    virtual NxU32 overlapSphereShapes(const NxSphere & worldSphere, NxShapesType shapesType, NxU32 activeGroups) const;
    virtual NxU32 overlapSphereShapes(const NxSphere & worldSphere, NxShapesType shapesType) const;
    virtual NxU32 overlapAABBShapes(const NxBounds3 & worldBounds, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask, void * userData) const;
    virtual NxU32 overlapAABBShapes(const NxBounds3 & worldBounds, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask) const;
    virtual NxU32 overlapAABBShapes(const NxBounds3 & worldBounds, NxShapesType shapesType, NxU32 activeGroups) const;
    virtual NxU32 overlapAABBShapes(const NxBounds3 & worldBounds, NxShapesType shapesType) const;
    virtual NxU32 overlapOBBShapes(const NxBox & worldBox, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask, void * userData) const;
    virtual NxU32 overlapOBBShapes(const NxBox & worldBox, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask) const;
    virtual NxU32 overlapOBBShapes(const NxBox & worldBox, NxShapesType shapesType, NxU32 activeGroups) const;
    virtual NxU32 overlapOBBShapes(const NxBox & worldBox, NxShapesType shapesType) const;
    virtual NxU32 overlapCapsuleShapes(const NxCapsule & worldCapsule, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask, void * userData) const;
    virtual NxU32 overlapCapsuleShapes(const NxCapsule & worldCapsule, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask) const;
    virtual NxU32 overlapCapsuleShapes(const NxCapsule & worldCapsule, NxShapesType shapesType, NxU32 activeGroups) const;
    virtual NxU32 overlapCapsuleShapes(const NxCapsule & worldCapsule, NxShapesType shapesType) const;
    virtual NxU32 cullShapes(NxU32 nbPlanes, const NxPlane * worldPlanes, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask, void * userData) const;
    virtual NxU32 cullShapes(NxU32 nbPlanes, const NxPlane * worldPlanes, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask) const;
    virtual NxU32 cullShapes(NxU32 nbPlanes, const NxPlane * worldPlanes, NxShapesType shapesType, NxU32 activeGroups) const;
    virtual NxU32 cullShapes(NxU32 nbPlanes, const NxPlane * worldPlanes, NxShapesType shapesType) const;
    virtual NxU32 linearOBBSweep(const NxBox & worldBox, const NxVec3 & motion, NxU32 flags, NxU32 activeGroups, const NxGroupsMask * groupsMask, void * userData) const;
    virtual NxU32 linearOBBSweep(const NxBox & worldBox, const NxVec3 & motion, NxU32 flags, NxU32 activeGroups, const NxGroupsMask * groupsMask) const;
    virtual NxU32 linearOBBSweep(const NxBox & worldBox, const NxVec3 & motion, NxU32 flags, NxU32 activeGroups) const;
    virtual NxU32 linearOBBSweep(const NxBox & worldBox, const NxVec3 & motion, NxU32 flags) const;
    virtual NxU32 linearCapsuleSweep(const NxCapsule & worldCapsule, const NxVec3 & motion, NxU32 flags, NxU32 activeGroups, const NxGroupsMask * groupsMask, void * userData) const;
    virtual NxU32 linearCapsuleSweep(const NxCapsule & worldCapsule, const NxVec3 & motion, NxU32 flags, NxU32 activeGroups, const NxGroupsMask * groupsMask) const;
    virtual NxU32 linearCapsuleSweep(const NxCapsule & worldCapsule, const NxVec3 & motion, NxU32 flags, NxU32 activeGroups) const;
    virtual NxU32 linearCapsuleSweep(const NxCapsule & worldCapsule, const NxVec3 & motion, NxU32 flags) const;
    static inline int getPointerStart() { return DoxyBindObject::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 71; }
};

class NxSceneQueryReport_doxybind : public NxSceneQueryReport, public  DoxyBindObject 
{
public:
    virtual NxQueryReportResult onBooleanQuery(void * userData, bool result) ;
    virtual NxQueryReportResult onRaycastQuery(void * userData, NxU32 nbHits, const NxRaycastHit * hits) ;
    virtual NxQueryReportResult onShapeQuery(void * userData, NxU32 nbHits, NxShape ** hits) ;
    virtual NxQueryReportResult onSweepQuery(void * userData, NxU32 nbHits, NxSweepQueryHit * hits) ;
    static inline int getPointerStart() { return DoxyBindObject::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 4; }
};

class NxSoftBody_doxybind : public NxSoftBody, public  DoxyBindObject 
{
public:
    NxSoftBody_doxybind();
    virtual bool saveToDesc(NxSoftBodyDesc & desc) const;
    virtual NxSoftBodyMesh * getSoftBodyMesh() const;
    virtual void setVolumeStiffness(NxReal stiffness) ;
    virtual NxReal getVolumeStiffness() const;
    virtual void setStretchingStiffness(NxReal stiffness) ;
    virtual NxReal getStretchingStiffness() const;
    virtual void setDampingCoefficient(NxReal dampingCoefficient) ;
    virtual NxReal getDampingCoefficient() const;
    virtual void setFriction(NxReal friction) ;
    virtual NxReal getFriction() const;
    virtual void setTearFactor(NxReal factor) ;
    virtual NxReal getTearFactor() const;
    virtual void setAttachmentTearFactor(NxReal factor) ;
    virtual NxReal getAttachmentTearFactor() const;
    virtual void setParticleRadius(NxReal particleRadius) ;
    virtual NxReal getParticleRadius() const;
    virtual NxReal getDensity() const;
    virtual NxReal getRelativeGridSpacing() const;
    virtual NxU32 getSolverIterations() const;
    virtual void setSolverIterations(NxU32 iterations) ;
    virtual void getWorldBounds(NxBounds3 & bounds) const;
    virtual void attachToShape(const NxShape * shape, NxU32 attachmentFlags) ;
    virtual void attachToCollidingShapes(NxU32 attachmentFlags) ;
    virtual void detachFromShape(const NxShape * shape) ;
    virtual void attachVertexToShape(NxU32 vertexId, const NxShape * shape, const NxVec3 & localPos, NxU32 attachmentFlags) ;
    virtual void attachVertexToGlobalPosition(const NxU32 vertexId, const NxVec3 & pos) ;
    virtual void freeVertex(const NxU32 vertexId) ;
    virtual bool tearVertex(const NxU32 vertexId, const NxVec3 & normal) ;
    virtual bool raycast(const NxRay & worldRay, NxVec3 & hit, NxU32 & vertexId) ;
    virtual void setGroup(NxCollisionGroup collisionGroup) ;
    virtual NxCollisionGroup getGroup() const;
    virtual void setGroupsMask(const NxGroupsMask & groupsMask) ;
    virtual const NxGroupsMask getGroupsMask() const;
    virtual void setMeshData(NxMeshData & meshData) ;
    virtual NxMeshData getMeshData() ;
    virtual void setSplitPairData(NxSoftBodySplitPairData & splitPairData) ;
    virtual NxSoftBodySplitPairData getSplitPairData() ;
    virtual void setValidBounds(const NxBounds3 & validBounds) ;
    virtual void getValidBounds(NxBounds3 & validBounds) const;
    virtual void setPosition(const NxVec3 & position, NxU32 vertexId) ;
    virtual void setPositions(void * buffer, NxU32 byteStride) ;
    virtual void setPositions(void * buffer) ;
    virtual NxVec3 getPosition(NxU32 vertexId) const;
    virtual void getPositions(void * buffer, NxU32 byteStride) ;
    virtual void getPositions(void * buffer) ;
    virtual void setVelocity(const NxVec3 & velocity, NxU32 vertexId) ;
    virtual void setVelocities(void * buffer, NxU32 byteStride) ;
    virtual void setVelocities(void * buffer) ;
    virtual NxVec3 getVelocity(NxU32 vertexId) const;
    virtual void getVelocities(void * buffer, NxU32 byteStride) ;
    virtual void getVelocities(void * buffer) ;
    virtual NxU32 getNumberOfParticles() ;
    virtual NxU32 queryShapePointers() ;
    virtual NxU32 getStateByteSize() ;
    virtual void getShapePointers(NxShape ** shapePointers, NxU32 * flags) ;
    virtual void setShapePointers(NxShape ** shapePointers, unsigned int numShapes) ;
    virtual void saveStateToStream(NxStream & stream, bool permute) ;
    virtual void saveStateToStream(NxStream & stream) ;
    virtual void loadStateFromStream(NxStream & stream) ;
    virtual void setCollisionResponseCoefficient(NxReal coefficient) ;
    virtual NxReal getCollisionResponseCoefficient() const;
    virtual void setAttachmentResponseCoefficient(NxReal coefficient) ;
    virtual NxReal getAttachmentResponseCoefficient() const;
    virtual void setFromFluidResponseCoefficient(NxReal coefficient) ;
    virtual NxReal getFromFluidResponseCoefficient() const;
    virtual void setToFluidResponseCoefficient(NxReal coefficient) ;
    virtual NxReal getToFluidResponseCoefficient() const;
    virtual void setExternalAcceleration(NxVec3 acceleration) ;
    virtual NxVec3 getExternalAcceleration() const;
    virtual void setMinAdhereVelocity(NxReal velocity) ;
    virtual NxReal getMinAdhereVelocity() const;
    virtual bool isSleeping() const;
    virtual NxReal getSleepLinearVelocity() const;
    virtual void setSleepLinearVelocity(NxReal threshold) ;
    virtual void wakeUp(NxReal wakeCounterValue) ;
    virtual void putToSleep() ;
    virtual void setFlags(NxU32 flags) ;
    virtual NxU32 getFlags() const;
    virtual void setName(const char * name) ;
    virtual void addForceAtVertex(const NxVec3 & force, NxU32 vertexId, NxForceMode mode) ;
    virtual void addForceAtVertex(const NxVec3 & force, NxU32 vertexId) ;
    virtual void addForceAtPos(const NxVec3 & position, NxReal magnitude, NxReal radius, NxForceMode mode) ;
    virtual void addForceAtPos(const NxVec3 & position, NxReal magnitude, NxReal radius) ;
    virtual bool overlapAABBTetrahedra(const NxBounds3 & bounds, NxU32 & nb, const NxU32 *& indices) const;
    virtual NxScene & getScene() const;
    virtual const char * getName() const;
    virtual NxCompartment * getCompartment() const;
    virtual NxForceFieldMaterial getForceFieldMaterial() const;
    virtual void setForceFieldMaterial(NxForceFieldMaterial unknown95) ;
    static inline int getPointerStart() { return DoxyBindObject::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 89; }
};

class NxSoftBodyMesh_doxybind : public NxSoftBodyMesh, public  DoxyBindObject 
{
public:
    NxSoftBodyMesh_doxybind();
    virtual bool saveToDesc(NxSoftBodyMeshDesc & desc) const;
    virtual NxU32 getReferenceCount() const;
    static inline int getPointerStart() { return DoxyBindObject::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 2; }
};

class NxSphereForceFieldShape_doxybind : public NxSphereForceFieldShape, public  DoxyBindObject 
{
public:
    virtual void setRadius(NxReal radius) ;
    virtual NxReal getRadius() const;
    virtual void saveToDesc(NxSphereForceFieldShapeDesc & desc) const;
    virtual NxMat34 getPose() const;
    virtual void setPose(const NxMat34 & unknown6) ;
    virtual NxForceField * getForceField() const;
    virtual NxForceFieldShapeGroup & getShapeGroup() const;
    virtual void setName(const char * name) ;
    virtual const char * getName() const;
    virtual NxShapeType getType() const;
    static inline int getPointerStart() { return NxForceFieldShape_doxybind::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 3; }
};

class NxSphereForceFieldShapeDesc_doxybind : public NxSphereForceFieldShapeDesc, public  DoxyBindObject 
{
public:
    NxSphereForceFieldShapeDesc_doxybind();
    virtual void setToDefault() ;
    virtual bool isValid() const;
    static inline int getPointerStart() { return NxForceFieldShapeDesc_doxybind::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 2; }
};

class NxSphereShape_doxybind : public NxSphereShape, public  DoxyBindObject 
{
public:
    virtual void setRadius(NxReal radius) ;
    virtual NxReal getRadius() const;
    virtual void getWorldSphere(NxSphere & worldSphere) const;
    virtual void saveToDesc(NxSphereShapeDesc & desc) const;
    virtual void setLocalPose(const NxMat34 & mat) ;
    virtual void setLocalPosition(const NxVec3 & vec) ;
    virtual void setLocalOrientation(const NxMat33 & mat) ;
    virtual NxMat34 getLocalPose() const;
    virtual NxVec3 getLocalPosition() const;
    virtual NxMat33 getLocalOrientation() const;
    virtual void setGlobalPose(const NxMat34 & mat) ;
    virtual void setGlobalPosition(const NxVec3 & vec) ;
    virtual void setGlobalOrientation(const NxMat33 & mat) ;
    virtual NxMat34 getGlobalPose() const;
    virtual NxVec3 getGlobalPosition() const;
    virtual NxMat33 getGlobalOrientation() const;
    virtual void * is(NxShapeType type) ;
    virtual const void * is(NxShapeType type) const;
    virtual bool raycast(const NxRay & worldRay, NxReal maxDist, NxU32 hintFlags, NxRaycastHit & hit, bool firstHit) const;
    virtual bool checkOverlapSphere(const NxSphere & worldSphere) const;
    virtual bool checkOverlapOBB(const NxBox & worldBox) const;
    virtual bool checkOverlapAABB(const NxBounds3 & worldBounds) const;
    virtual bool checkOverlapCapsule(const NxCapsule & worldCapsule) const;
    virtual NxActor & getActor() const;
    virtual void setGroup(NxCollisionGroup collisionGroup) ;
    virtual NxCollisionGroup getGroup() const;
    virtual void getWorldBounds(NxBounds3 & dest) const;
    virtual void setFlag(NxShapeFlag flag, bool value) ;
    virtual NX_BOOL getFlag(NxShapeFlag flag) const;
    virtual void setMaterial(NxMaterialIndex matIndex) ;
    virtual NxMaterialIndex getMaterial() const;
    virtual void setSkinWidth(NxReal skinWidth) ;
    virtual NxReal getSkinWidth() const;
    virtual NxShapeType getType() const;
    virtual void setCCDSkeleton(NxCCDSkeleton * ccdSkel) ;
    virtual NxCCDSkeleton * getCCDSkeleton() const;
    virtual void setName(const char * name) ;
    virtual const char * getName() const;
    virtual void setGroupsMask(const NxGroupsMask & mask) ;
    virtual const NxGroupsMask getGroupsMask() const;
    virtual NxU32 getNonInteractingCompartmentTypes() const;
    virtual void setNonInteractingCompartmentTypes(NxU32 compartmentTypes) ;
    static inline int getPointerStart() { return NxShape_doxybind::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 4; }
};

class NxSphereShapeDesc_doxybind : public NxSphereShapeDesc, public  DoxyBindObject 
{
public:
    NxSphereShapeDesc_doxybind();
    virtual void setToDefault() ;
    virtual bool isValid() const;
    static inline int getPointerStart() { return NxShapeDesc_doxybind::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 2; }
};

class NxSphericalJoint_doxybind : public NxSphericalJoint, public  DoxyBindObject 
{
public:
    virtual void loadFromDesc(const NxSphericalJointDesc & desc) ;
    virtual void saveToDesc(NxSphericalJointDesc & desc) ;
    virtual void setFlags(NxU32 flags) ;
    virtual NxU32 getFlags() ;
    virtual void setProjectionMode(NxJointProjectionMode projectionMode) ;
    virtual NxJointProjectionMode getProjectionMode() ;
    virtual void setLimitPoint(const NxVec3 & point, bool pointIsOnActor2) ;
    virtual void setLimitPoint(const NxVec3 & point) ;
    virtual bool getLimitPoint(NxVec3 & worldLimitPoint) ;
    virtual bool addLimitPlane(const NxVec3 & normal, const NxVec3 & pointInPlane, NxReal restitution) ;
    virtual bool addLimitPlane(const NxVec3 & normal, const NxVec3 & pointInPlane) ;
    virtual void purgeLimitPlanes() ;
    virtual void resetLimitPlaneIterator() ;
    virtual bool hasMoreLimitPlanes() ;
    virtual bool getNextLimitPlane(NxVec3 & planeNormal, NxReal & planeD, NxReal * restitution) ;
    virtual bool getNextLimitPlane(NxVec3 & planeNormal, NxReal & planeD) ;
    virtual void * is(NxJointType type) ;
    virtual void getActors(NxActor ** actor1, NxActor ** actor2) ;
    virtual void setGlobalAnchor(const NxVec3 & vec) ;
    virtual void setGlobalAxis(const NxVec3 & vec) ;
    virtual NxVec3 getGlobalAnchor() const;
    virtual NxVec3 getGlobalAxis() const;
    virtual NxJointState getState() ;
    virtual void setBreakable(NxReal maxForce, NxReal maxTorque) ;
    virtual void getBreakable(NxReal & maxForce, NxReal & maxTorque) ;
    virtual void setSolverExtrapolationFactor(NxReal solverExtrapolationFactor) ;
    virtual NxReal getSolverExtrapolationFactor() const;
    virtual void setUseAccelerationSpring(bool b) ;
    virtual bool getUseAccelerationSpring() const;
    virtual NxJointType getType() const;
    virtual void setName(const char * name) ;
    virtual const char * getName() const;
    virtual NxScene & getScene() const;
    static inline int getPointerStart() { return NxJoint_doxybind::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 6; }
};

class NxSphericalJointDesc_doxybind : public NxSphericalJointDesc, public  DoxyBindObject 
{
public:
    NxSphericalJointDesc_doxybind();
    virtual void setToDefault() ;
    virtual bool isValid() const;
    static inline int getPointerStart() { return NxJointDesc_doxybind::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 2; }
};

class NxSpringAndDamperEffector_doxybind : public NxSpringAndDamperEffector, public  DoxyBindObject 
{
public:
    virtual void saveToDesc(NxSpringAndDamperEffectorDesc & desc) ;
    virtual void setBodies(NxActor * body1, const NxVec3 & global1, NxActor * body2, const NxVec3 & global2) ;
    virtual void setLinearSpring(NxReal distCompressSaturate, NxReal distRelaxed, NxReal distStretchSaturate, NxReal maxCompressForce, NxReal maxStretchForce) ;
    virtual void getLinearSpring(NxReal & distCompressSaturate, NxReal & distRelaxed, NxReal & distStretchSaturate, NxReal & maxCompressForce, NxReal & maxStretchForce) ;
    virtual void setLinearDamper(NxReal velCompressSaturate, NxReal velStretchSaturate, NxReal maxCompressForce, NxReal maxStretchForce) ;
    virtual void getLinearDamper(NxReal & velCompressSaturate, NxReal & velStretchSaturate, NxReal & maxCompressForce, NxReal & maxStretchForce) ;
    virtual NxEffectorType getType() const;
    virtual void setName(const char * name) ;
    virtual const char * getName() const;
    virtual NxScene & getScene() const;
    static inline int getPointerStart() { return NxEffector_doxybind::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 6; }
};

class NxSpringAndDamperEffectorDesc_doxybind : public NxSpringAndDamperEffectorDesc, public  DoxyBindObject 
{
public:
    NxSpringAndDamperEffectorDesc_doxybind();
    virtual void setToDefault() ;
    virtual bool isValid() const;
    static inline int getPointerStart() { return NxEffectorDesc_doxybind::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 2; }
};

class NxStream_doxybind : public NxStream, public  DoxyBindObject 
{
public:
    NxStream_doxybind();
    virtual NxU8 readByte() const;
    virtual NxU16 readWord() const;
    virtual NxU32 readDword() const;
    virtual NxF32 readFloat() const;
    virtual NxF64 readDouble() const;
    virtual void readBuffer(void * buffer, NxU32 size) const;
    virtual NxStream & storeByte(NxU8 b) ;
    virtual NxStream & storeWord(NxU16 w) ;
    virtual NxStream & storeDword(NxU32 d) ;
    virtual NxStream & storeFloat(NxF32 f) ;
    virtual NxStream & storeDouble(NxF64 f) ;
    virtual NxStream & storeBuffer(const void * buffer, NxU32 size) ;
    static inline int getPointerStart() { return DoxyBindObject::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 12; }
};

class NxSweepCache_doxybind : public NxSweepCache, public  DoxyBindObject 
{
public:
    NxSweepCache_doxybind();
    virtual void setVolume(const NxBox & box) ;
    static inline int getPointerStart() { return DoxyBindObject::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 1; }
};

class NxTask_doxybind : public NxTask, public  DoxyBindObject 
{
public:
    virtual void execute() ;
    static inline int getPointerStart() { return DoxyBindObject::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 1; }
};

class NxTireFunctionDesc_doxybind : public NxTireFunctionDesc, public  DoxyBindObject 
{
public:
    NxTireFunctionDesc_doxybind();
    virtual void setToDefault() ;
    virtual bool isValid() const;
    static inline int getPointerStart() { return DoxyBindObject::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 2; }
};

class NxTriangleMesh_doxybind : public NxTriangleMesh, public  DoxyBindObject 
{
public:
    virtual bool saveToDesc(NxTriangleMeshDesc & desc) const;
    virtual NxU32 getSubmeshCount() const;
    virtual NxU32 getCount(NxSubmeshIndex submeshIndex, NxInternalArray intArray) const;
    virtual NxInternalFormat getFormat(NxSubmeshIndex submeshIndex, NxInternalArray intArray) const;
    virtual const void * getBase(NxSubmeshIndex submeshIndex, NxInternalArray intArray) const;
    virtual NxU32 getStride(NxSubmeshIndex submeshIndex, NxInternalArray intArray) const;
    virtual NxU32 getPageCount() const;
    virtual NxBounds3 getPageBBox(NxU32 pageIndex) const;
    virtual bool loadPMap(const NxPMap & pmap) ;
    virtual bool hasPMap() const;
    virtual NxU32 getPMapSize() const;
    virtual bool getPMapData(NxPMap & pmap) const;
    virtual NxU32 getPMapDensity() const;
    virtual bool load(const NxStream & stream) ;
    virtual NxMaterialIndex getTriangleMaterial(NxTriangleID triangleIndex) const;
    virtual NxU32 getReferenceCount() ;
    virtual void getMassInformation(NxReal & mass, NxMat33 & localInertia, NxVec3 & localCenterOfMass) const;
    static inline int getPointerStart() { return DoxyBindObject::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 17; }
};

class NxTriangleMeshShape_doxybind : public NxTriangleMeshShape, public  DoxyBindObject 
{
public:
    virtual void saveToDesc(NxTriangleMeshShapeDesc & desc) const;
    virtual NxTriangleMesh & getTriangleMesh() ;
    virtual const NxTriangleMesh & getTriangleMesh() const;
    virtual NxU32 getTriangle(NxTriangle & triangle, NxTriangle * edgeTri, NxU32 * flags, NxTriangleID triangleIndex, bool worldSpaceTranslation, bool worldSpaceRotation) const;
    virtual NxU32 getTriangle(NxTriangle & triangle, NxTriangle * edgeTri, NxU32 * flags, NxTriangleID triangleIndex, bool worldSpaceTranslation) const;
    virtual NxU32 getTriangle(NxTriangle & triangle, NxTriangle * edgeTri, NxU32 * flags, NxTriangleID triangleIndex) const;
    virtual bool overlapAABBTrianglesDeprecated(const NxBounds3 & bounds, NxU32 flags, NxU32 & nb, const NxU32 *& indices) const;
    virtual bool overlapAABBTriangles(const NxBounds3 & bounds, NxU32 flags, NxUserEntityReport< NxU32 > * callback) const;
    virtual bool mapPageInstance(NxU32 pageIndex) ;
    virtual void unmapPageInstance(NxU32 pageIndex) ;
    virtual bool isPageInstanceMapped(NxU32 pageIndex) const;
    virtual void setLocalPose(const NxMat34 & mat) ;
    virtual void setLocalPosition(const NxVec3 & vec) ;
    virtual void setLocalOrientation(const NxMat33 & mat) ;
    virtual NxMat34 getLocalPose() const;
    virtual NxVec3 getLocalPosition() const;
    virtual NxMat33 getLocalOrientation() const;
    virtual void setGlobalPose(const NxMat34 & mat) ;
    virtual void setGlobalPosition(const NxVec3 & vec) ;
    virtual void setGlobalOrientation(const NxMat33 & mat) ;
    virtual NxMat34 getGlobalPose() const;
    virtual NxVec3 getGlobalPosition() const;
    virtual NxMat33 getGlobalOrientation() const;
    virtual void * is(NxShapeType type) ;
    virtual const void * is(NxShapeType type) const;
    virtual bool raycast(const NxRay & worldRay, NxReal maxDist, NxU32 hintFlags, NxRaycastHit & hit, bool firstHit) const;
    virtual bool checkOverlapSphere(const NxSphere & worldSphere) const;
    virtual bool checkOverlapOBB(const NxBox & worldBox) const;
    virtual bool checkOverlapAABB(const NxBounds3 & worldBounds) const;
    virtual bool checkOverlapCapsule(const NxCapsule & worldCapsule) const;
    virtual NxActor & getActor() const;
    virtual void setGroup(NxCollisionGroup collisionGroup) ;
    virtual NxCollisionGroup getGroup() const;
    virtual void getWorldBounds(NxBounds3 & dest) const;
    virtual void setFlag(NxShapeFlag flag, bool value) ;
    virtual NX_BOOL getFlag(NxShapeFlag flag) const;
    virtual void setMaterial(NxMaterialIndex matIndex) ;
    virtual NxMaterialIndex getMaterial() const;
    virtual void setSkinWidth(NxReal skinWidth) ;
    virtual NxReal getSkinWidth() const;
    virtual NxShapeType getType() const;
    virtual void setCCDSkeleton(NxCCDSkeleton * ccdSkel) ;
    virtual NxCCDSkeleton * getCCDSkeleton() const;
    virtual void setName(const char * name) ;
    virtual const char * getName() const;
    virtual void setGroupsMask(const NxGroupsMask & mask) ;
    virtual const NxGroupsMask getGroupsMask() const;
    virtual NxU32 getNonInteractingCompartmentTypes() const;
    virtual void setNonInteractingCompartmentTypes(NxU32 compartmentTypes) ;
    static inline int getPointerStart() { return NxShape_doxybind::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 11; }
};

class NxTriangleMeshShapeDesc_doxybind : public NxTriangleMeshShapeDesc, public  DoxyBindObject 
{
public:
    NxTriangleMeshShapeDesc_doxybind();
    virtual void setToDefault() ;
    virtual bool isValid() const;
    static inline int getPointerStart() { return NxShapeDesc_doxybind::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 2; }
};

class NxUserActorPairFiltering_doxybind : public NxUserActorPairFiltering, public  DoxyBindObject 
{
public:
    virtual void onActorPairs(NxActorPairFilter * filterArray, NxU32 arraySize) ;
    static inline int getPointerStart() { return DoxyBindObject::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 1; }
};

class NxUserAllocatorDefault_doxybind : public NxUserAllocatorDefault, public  DoxyBindObject 
{
public:
    virtual void * malloc(size_t size, NxMemoryType type) ;
    virtual void * malloc(size_t size) ;
    virtual void * mallocDEBUG(size_t size, const char * fileName, int line, const char * className, NxMemoryType type) ;
    virtual void * mallocDEBUG(size_t size, const char * fileName, int line) ;
    virtual void * realloc(void * memory, size_t size) ;
    virtual void free(void * memory) ;
    virtual void checkDEBUG() ;
    static inline int getPointerStart() { return NxUserAllocator_doxybind::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 6; }
};

class NxUserContactModify_doxybind : public NxUserContactModify, public  DoxyBindObject 
{
public:
    virtual bool onContactConstraint(NxU32 & changeFlags, const NxShape * shape0, const NxShape * shape1, const NxU32 featureIndex0, const NxU32 featureIndex1, NxContactCallbackData & data) ;
    static inline int getPointerStart() { return DoxyBindObject::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 1; }
};

class NxUserContactReport_doxybind : public NxUserContactReport, public  DoxyBindObject 
{
public:
    virtual void onContactNotify(NxContactPair & pair, NxU32 events) ;
    static inline int getPointerStart() { return DoxyBindObject::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 1; }
};

class NxUserControllerHitReport_doxybind : public NxUserControllerHitReport, public  DoxyBindObject 
{
public:
    virtual NxControllerAction onShapeHit(const NxControllerShapeHit & hit) ;
    virtual NxControllerAction onControllerHit(const NxControllersHit & hit) ;
    static inline int getPointerStart() { return DoxyBindObject::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 2; }
};

class NxUserNotify_doxybind : public NxUserNotify, public  DoxyBindObject 
{
public:
    virtual bool onJointBreak(NxReal breakingImpulse, NxJoint & brokenJoint) ;
    virtual void onWake(NxActor ** actors, NxU32 count) ;
    virtual void onSleep(NxActor ** actors, NxU32 count) ;
    static inline int getPointerStart() { return DoxyBindObject::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 3; }
};

class NxUserOutputStream_doxybind : public NxUserOutputStream, public  DoxyBindObject 
{
public:
    virtual void reportError(NxErrorCode code, const char * message, const char * file, int line) ;
    virtual NxAssertResponse reportAssertViolation(const char * message, const char * file, int line) ;
    virtual void print(const char * message) ;
    static inline int getPointerStart() { return DoxyBindObject::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 3; }
};

class NxUserRaycastReport_doxybind : public NxUserRaycastReport, public  DoxyBindObject 
{
public:
    virtual bool onHit(const NxRaycastHit & hits) ;
    static inline int getPointerStart() { return DoxyBindObject::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 1; }
};

class NxUserScheduler_doxybind : public NxUserScheduler, public  DoxyBindObject 
{
public:
    virtual void addTask(NxTask * task) ;
    virtual void addBackgroundTask(NxTask * task) ;
    virtual void waitTasksComplete() ;
    static inline int getPointerStart() { return DoxyBindObject::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 3; }
};

class NxUserTriggerReport_doxybind : public NxUserTriggerReport, public  DoxyBindObject 
{
public:
    virtual void onTrigger(NxShape & triggerShape, NxShape & otherShape, NxTriggerFlag status) ;
    static inline int getPointerStart() { return DoxyBindObject::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 1; }
};

class NxUserWheelContactModify_doxybind : public NxUserWheelContactModify, public  DoxyBindObject 
{
public:
    virtual bool onWheelContact(NxWheelShape * wheelShape, NxVec3 & contactPoint, NxVec3 & contactNormal, NxReal & contactPosition, NxReal & normalForce, NxShape * otherShape, NxMaterialIndex & otherShapeMaterialIndex, NxU32 otherShapeFeatureIndex) ;
    static inline int getPointerStart() { return DoxyBindObject::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 1; }
};

class NxUtilLib_doxybind : public NxUtilLib, public  DoxyBindObject 
{
public:
    virtual bool NxBoxContainsPoint(const NxBox & box, const NxVec3 & p) ;
    virtual void NxCreateBox(NxBox & box, const NxBounds3 & aabb, const NxMat34 & mat) ;
    virtual bool NxComputeBoxPlanes(const NxBox & box, NxPlane * planes) ;
    virtual bool NxComputeBoxPoints(const NxBox & box, NxVec3 * pts) ;
    virtual bool NxComputeBoxVertexNormals(const NxBox & box, NxVec3 * pts) ;
    virtual const NxU32 * NxGetBoxEdges() ;
    virtual const NxI32 * NxGetBoxEdgesAxes() ;
    virtual const NxU32 * NxGetBoxTriangles() ;
    virtual const NxVec3 * NxGetBoxLocalEdgeNormals() ;
    virtual void NxComputeBoxWorldEdgeNormal(const NxBox & box, NxU32 edge_index, NxVec3 & world_normal) ;
    virtual void NxComputeCapsuleAroundBox(const NxBox & box, NxCapsule & capsule) ;
    virtual bool NxIsBoxAInsideBoxB(const NxBox & a, const NxBox & b) ;
    virtual const NxU32 * NxGetBoxQuads() ;
    virtual const NxU32 * NxBoxVertexToQuad(NxU32 vertexIndex) ;
    virtual void NxComputeBoxAroundCapsule(const NxCapsule & capsule, NxBox & box) ;
    virtual void NxSetFPUPrecision24() ;
    virtual void NxSetFPUPrecision53() ;
    virtual void NxSetFPUPrecision64() ;
    virtual void NxSetFPURoundingChop() ;
    virtual void NxSetFPURoundingUp() ;
    virtual void NxSetFPURoundingDown() ;
    virtual void NxSetFPURoundingNear() ;
    virtual void NxSetFPUExceptions(bool b) ;
    virtual int NxIntChop(const NxF32 & f) ;
    virtual int NxIntFloor(const NxF32 & f) ;
    virtual int NxIntCeil(const NxF32 & f) ;
    virtual NxF32 NxComputeDistanceSquared(const NxRay & ray, const NxVec3 & point, NxF32 * t) ;
    virtual NxF32 NxComputeSquareDistance(const NxSegment & seg, const NxVec3 & point, NxF32 * t) ;
    virtual NxBSphereMethod NxComputeSphere(NxSphere & sphere, unsigned nb_verts, const NxVec3 * verts) ;
    virtual bool NxFastComputeSphere(NxSphere & sphere, unsigned nb_verts, const NxVec3 * verts) ;
    virtual void NxMergeSpheres(NxSphere & merged, const NxSphere & sphere0, const NxSphere & sphere1) ;
    virtual void NxNormalToTangents(const NxVec3 & n, NxVec3 & t1, NxVec3 & t2) ;
    virtual bool NxDiagonalizeInertiaTensor(const NxMat33 & denseInertia, NxVec3 & diagonalInertia, NxMat33 & rotation) ;
    virtual void NxFindRotationMatrix(const NxVec3 & x, const NxVec3 & b, NxMat33 & M) ;
    virtual void NxComputeBounds(NxVec3 & min, NxVec3 & max, NxU32 nbVerts, const NxVec3 * verts) ;
    virtual NxU32 NxCrc32(const void * buffer, NxU32 nbBytes) ;
    virtual NxReal NxComputeSphereMass(NxReal radius, NxReal density) ;
    virtual NxReal NxComputeSphereDensity(NxReal radius, NxReal mass) ;
    virtual NxReal NxComputeBoxMass(const NxVec3 & extents, NxReal density) ;
    virtual NxReal NxComputeBoxDensity(const NxVec3 & extents, NxReal mass) ;
    virtual NxReal NxComputeEllipsoidMass(const NxVec3 & extents, NxReal density) ;
    virtual NxReal NxComputeEllipsoidDensity(const NxVec3 & extents, NxReal mass) ;
    virtual NxReal NxComputeCylinderMass(NxReal radius, NxReal length, NxReal density) ;
    virtual NxReal NxComputeCylinderDensity(NxReal radius, NxReal length, NxReal mass) ;
    virtual NxReal NxComputeConeMass(NxReal radius, NxReal length, NxReal density) ;
    virtual NxReal NxComputeConeDensity(NxReal radius, NxReal length, NxReal mass) ;
    virtual void NxComputeBoxInertiaTensor(NxVec3 & diagInertia, NxReal mass, NxReal xlength, NxReal ylength, NxReal zlength) ;
    virtual void NxComputeSphereInertiaTensor(NxVec3 & diagInertia, NxReal mass, NxReal radius, bool hollow) ;
    virtual void NxJointDesc_SetGlobalAnchor(NxJointDesc & dis, const NxVec3 & wsAnchor) ;
    virtual void NxJointDesc_SetGlobalAxis(NxJointDesc & dis, const NxVec3 & wsAxis) ;
    virtual bool NxBoxBoxIntersect(const NxVec3 & extents0, const NxVec3 & center0, const NxMat33 & rotation0, const NxVec3 & extents1, const NxVec3 & center1, const NxMat33 & rotation1, bool fullTest) ;
    virtual bool NxTriBoxIntersect(const NxVec3 & vertex0, const NxVec3 & vertex1, const NxVec3 & vertex2, const NxVec3 & center, const NxVec3 & extents) ;
    virtual NxSepAxis NxSeparatingAxis(const NxVec3 & extents0, const NxVec3 & center0, const NxMat33 & rotation0, const NxVec3 & extents1, const NxVec3 & center1, const NxMat33 & rotation1, bool fullTest) ;
    virtual NxSepAxis NxSeparatingAxis(const NxVec3 & extents0, const NxVec3 & center0, const NxMat33 & rotation0, const NxVec3 & extents1, const NxVec3 & center1, const NxMat33 & rotation1) ;
    virtual void NxSegmentPlaneIntersect(const NxVec3 & v1, const NxVec3 & v2, const NxPlane & plane, NxReal & dist, NxVec3 & pointOnPlane) ;
    virtual bool NxRayPlaneIntersect(const NxRay & ray, const NxPlane & plane, NxReal & dist, NxVec3 & pointOnPlane) ;
    virtual bool NxRaySphereIntersect(const NxVec3 & origin, const NxVec3 & dir, NxReal length, const NxVec3 & center, NxReal radius, NxReal & hit_time, NxVec3 & hit_pos) ;
    virtual bool NxSegmentBoxIntersect(const NxVec3 & p1, const NxVec3 & p2, const NxVec3 & bbox_min, const NxVec3 & bbox_max, NxVec3 & intercept) ;
    virtual bool NxRayAABBIntersect(const NxVec3 & min, const NxVec3 & max, const NxVec3 & origin, const NxVec3 & dir, NxVec3 & coord) ;
    virtual NxU32 NxRayAABBIntersect2(const NxVec3 & min, const NxVec3 & max, const NxVec3 & origin, const NxVec3 & dir, NxVec3 & coord, NxReal & t) ;
    virtual bool NxSegmentOBBIntersect(const NxVec3 & p0, const NxVec3 & p1, const NxVec3 & center, const NxVec3 & extents, const NxMat33 & rot) ;
    virtual bool NxSegmentAABBIntersect(const NxVec3 & p0, const NxVec3 & p1, const NxVec3 & min, const NxVec3 & max) ;
    virtual bool NxRayOBBIntersect(const NxRay & ray, const NxVec3 & center, const NxVec3 & extents, const NxMat33 & rot) ;
    virtual NxU32 NxRayCapsuleIntersect(const NxVec3 & origin, const NxVec3 & dir, const NxCapsule & capsule, NxReal t[2]) ;
    virtual bool NxSweptSpheresIntersect(const NxSphere & sphere0, const NxVec3 & velocity0, const NxSphere & sphere1, const NxVec3 & velocity1) ;
    virtual bool NxRayTriIntersect(const NxVec3 & orig, const NxVec3 & dir, const NxVec3 & vert0, const NxVec3 & vert1, const NxVec3 & vert2, float & t, float & u, float & v, bool cull) ;
    virtual bool NxBuildSmoothNormals(NxU32 nbTris, NxU32 nbVerts, const NxVec3 * verts, const NxU32 * dFaces, const NxU16 * wFaces, NxVec3 * normals, bool flip) ;
    virtual bool NxBuildSmoothNormals(NxU32 nbTris, NxU32 nbVerts, const NxVec3 * verts, const NxU32 * dFaces, const NxU16 * wFaces, NxVec3 * normals) ;
    virtual bool NxSweepBoxCapsule(const NxBox & box, const NxCapsule & lss, const NxVec3 & dir, float length, float & min_dist, NxVec3 & normal) ;
    virtual bool NxSweepBoxSphere(const NxBox & box, const NxSphere & sphere, const NxVec3 & dir, float length, float & min_dist, NxVec3 & normal) ;
    virtual bool NxSweepCapsuleCapsule(const NxCapsule & lss0, const NxCapsule & lss1, const NxVec3 & dir, float length, float & min_dist, NxVec3 & ip, NxVec3 & normal) ;
    virtual bool NxSweepSphereCapsule(const NxSphere & sphere, const NxCapsule & lss, const NxVec3 & dir, float length, float & min_dist, NxVec3 & ip, NxVec3 & normal) ;
    virtual bool NxSweepBoxBox(const NxBox & box0, const NxBox & box1, const NxVec3 & dir, float length, NxVec3 & ip, NxVec3 & normal, float & min_dist) ;
    virtual bool NxSweepBoxTriangles(NxU32 nb_tris, const NxTriangle * triangles, const NxTriangle * edge_triangles, const NxU32 * edge_flags, const NxBounds3 & box, const NxVec3 & dir, float length, NxVec3 & hit, NxVec3 & normal, float & d, NxU32 & index, NxU32 * cachedIndex) ;
    virtual bool NxSweepBoxTriangles(NxU32 nb_tris, const NxTriangle * triangles, const NxTriangle * edge_triangles, const NxU32 * edge_flags, const NxBounds3 & box, const NxVec3 & dir, float length, NxVec3 & hit, NxVec3 & normal, float & d, NxU32 & index) ;
    virtual bool NxSweepCapsuleTriangles(NxU32 up_direction, NxU32 nb_tris, const NxTriangle * triangles, const NxU32 * edge_flags, const NxVec3 & center, const float radius, const float height, const NxVec3 & dir, float length, NxVec3 & hit, NxVec3 & normal, float & d, NxU32 & index, NxU32 * cachedIndex) ;
    virtual bool NxSweepCapsuleTriangles(NxU32 up_direction, NxU32 nb_tris, const NxTriangle * triangles, const NxU32 * edge_flags, const NxVec3 & center, const float radius, const float height, const NxVec3 & dir, float length, NxVec3 & hit, NxVec3 & normal, float & d, NxU32 & index) ;
    virtual float NxPointOBBSqrDist(const NxVec3 & point, const NxVec3 & center, const NxVec3 & extents, const NxMat33 & rot, NxVec3 * params) ;
    virtual float NxSegmentOBBSqrDist(const NxSegment & segment, const NxVec3 & c0, const NxVec3 & e0, const NxMat33 & r0, float * t, NxVec3 * p) ;
    static inline int getPointerStart() { return DoxyBindObject::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 79; }
};

class NxWheelShape_doxybind : public NxWheelShape, public  DoxyBindObject 
{
public:
    virtual void saveToDesc(NxWheelShapeDesc & desc) const;
    virtual void setRadius(NxReal radius) ;
    virtual void setSuspensionTravel(NxReal travel) ;
    virtual NxReal getRadius() const;
    virtual NxReal getSuspensionTravel() const;
    virtual void setSuspension(NxSpringDesc spring) ;
    virtual void setLongitudalTireForceFunction(NxTireFunctionDesc tireFunc) ;
    virtual void setLateralTireForceFunction(NxTireFunctionDesc tireFunc) ;
    virtual void setInverseWheelMass(NxReal invMass) ;
    virtual void setWheelFlags(NxU32 flags) ;
    virtual NxSpringDesc getSuspension() const;
    virtual NxTireFunctionDesc getLongitudalTireForceFunction() const;
    virtual NxTireFunctionDesc getLateralTireForceFunction() const;
    virtual NxReal getInverseWheelMass() const;
    virtual NxU32 getWheelFlags() const;
    virtual void setMotorTorque(NxReal torque) ;
    virtual void setBrakeTorque(NxReal torque) ;
    virtual void setSteerAngle(NxReal angle) ;
    virtual NxReal getMotorTorque() const;
    virtual NxReal getBrakeTorque() const;
    virtual NxReal getSteerAngle() const;
    virtual void setAxleSpeed(NxReal speed) ;
    virtual NxReal getAxleSpeed() const;
    virtual NxShape * getContact(NxWheelContactData & dest) const;
    virtual void setUserWheelContactModify(NxUserWheelContactModify * callback) ;
    virtual NxUserWheelContactModify * getUserWheelContactModify() ;
    virtual void setLocalPose(const NxMat34 & mat) ;
    virtual void setLocalPosition(const NxVec3 & vec) ;
    virtual void setLocalOrientation(const NxMat33 & mat) ;
    virtual NxMat34 getLocalPose() const;
    virtual NxVec3 getLocalPosition() const;
    virtual NxMat33 getLocalOrientation() const;
    virtual void setGlobalPose(const NxMat34 & mat) ;
    virtual void setGlobalPosition(const NxVec3 & vec) ;
    virtual void setGlobalOrientation(const NxMat33 & mat) ;
    virtual NxMat34 getGlobalPose() const;
    virtual NxVec3 getGlobalPosition() const;
    virtual NxMat33 getGlobalOrientation() const;
    virtual void * is(NxShapeType type) ;
    virtual const void * is(NxShapeType type) const;
    virtual bool raycast(const NxRay & worldRay, NxReal maxDist, NxU32 hintFlags, NxRaycastHit & hit, bool firstHit) const;
    virtual bool checkOverlapSphere(const NxSphere & worldSphere) const;
    virtual bool checkOverlapOBB(const NxBox & worldBox) const;
    virtual bool checkOverlapAABB(const NxBounds3 & worldBounds) const;
    virtual bool checkOverlapCapsule(const NxCapsule & worldCapsule) const;
    virtual NxActor & getActor() const;
    virtual void setGroup(NxCollisionGroup collisionGroup) ;
    virtual NxCollisionGroup getGroup() const;
    virtual void getWorldBounds(NxBounds3 & dest) const;
    virtual void setFlag(NxShapeFlag flag, bool value) ;
    virtual NX_BOOL getFlag(NxShapeFlag flag) const;
    virtual void setMaterial(NxMaterialIndex matIndex) ;
    virtual NxMaterialIndex getMaterial() const;
    virtual void setSkinWidth(NxReal skinWidth) ;
    virtual NxReal getSkinWidth() const;
    virtual NxShapeType getType() const;
    virtual void setCCDSkeleton(NxCCDSkeleton * ccdSkel) ;
    virtual NxCCDSkeleton * getCCDSkeleton() const;
    virtual void setName(const char * name) ;
    virtual const char * getName() const;
    virtual void setGroupsMask(const NxGroupsMask & mask) ;
    virtual const NxGroupsMask getGroupsMask() const;
    virtual NxU32 getNonInteractingCompartmentTypes() const;
    virtual void setNonInteractingCompartmentTypes(NxU32 compartmentTypes) ;
    static inline int getPointerStart() { return NxShape_doxybind::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 26; }
};

class NxWheelShapeDesc_doxybind : public NxWheelShapeDesc, public  DoxyBindObject 
{
public:
    NxWheelShapeDesc_doxybind();
    virtual void setToDefault(bool fromCtor) ;
    virtual bool isValid() const;
    virtual void setToDefault() ;
    static inline int getPointerStart() { return NxShapeDesc_doxybind::getPointerEnd(); }
    static inline int getPointerEnd() { return getPointerStart() + 2; }
};

