/*
Copyright (c) 2007-2008
Available under the terms of the
Eclipse Public License with GPL exception
See enclosed license file for more information
*/
#include "PhysX.NET.h"


            API_EXPORT void delete_object( void* ptr ) { delete ptr; }
            API_EXPORT void set_pointers( DoxyBindObject* ptr, void** pointers, int length ) { ptr->setPointers(pointers, length); }

API_EXPORT ControllerManager* new_ControllerManager(bool do_override)
{
    return new ControllerManager();
}

API_EXPORT NxU32 ControllerManager_getNbControllers(ControllerManager* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->ControllerManager::getNbControllers() : classPointer->getNbControllers();
}

API_EXPORT NxController* ControllerManager_getController(ControllerManager* classPointer, bool call_explicit, NxU32 index)
{
    return (call_explicit) ? classPointer->ControllerManager::getController(index) : classPointer->getController(index);
}

API_EXPORT NxController* ControllerManager_createController(ControllerManager* classPointer, bool call_explicit, NxScene* scene, NxControllerDesc* desc)
{
    return (call_explicit) ? classPointer->ControllerManager::createController(scene, *desc) : classPointer->createController(scene, *desc);
}

API_EXPORT void ControllerManager_releaseController(ControllerManager* classPointer, bool call_explicit, NxController* controller)
{
    (call_explicit) ? classPointer->ControllerManager::releaseController(*controller) : classPointer->releaseController(*controller);
}

API_EXPORT void ControllerManager_purgeControllers(ControllerManager* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->ControllerManager::purgeControllers() : classPointer->purgeControllers();
}

API_EXPORT void ControllerManager_updateControllers(ControllerManager* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->ControllerManager::updateControllers() : classPointer->updateControllers();
}

API_EXPORT NxController** ControllerManager_getControllers(ControllerManager* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->ControllerManager::getControllers() : classPointer->getControllers();
}

API_EXPORT NxDebugRenderable* ControllerManager_getDebugData(ControllerManager* classPointer, bool call_explicit)
{
    return (call_explicit) ? &classPointer->ControllerManager::getDebugData() : &classPointer->getDebugData();
}

API_EXPORT void ControllerManager_resetDebugData(ControllerManager* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->ControllerManager::resetDebugData() : classPointer->resetDebugData();
}

API_EXPORT void* NxUserAllocator_mallocDEBUG(NxUserAllocator* classPointer, bool call_explicit, size_t size, char* fileName, int line)
{
    return classPointer->mallocDEBUG(size, fileName, line);
}

API_EXPORT void* NxUserAllocator_mallocDEBUG_1(NxUserAllocator* classPointer, bool call_explicit, size_t size, char* fileName, int line, char* className, NxMemoryType type)
{
    return (call_explicit) ? classPointer->NxUserAllocator::mallocDEBUG(size, fileName, line, className, type) : classPointer->mallocDEBUG(size, fileName, line, className, type);
}

API_EXPORT void* NxUserAllocator_malloc(NxUserAllocator* classPointer, bool call_explicit, size_t size)
{
    return classPointer->malloc(size);
}

API_EXPORT void* NxUserAllocator_malloc_1(NxUserAllocator* classPointer, bool call_explicit, size_t size, NxMemoryType type)
{
    return (call_explicit) ? classPointer->NxUserAllocator::malloc(size, type) : classPointer->malloc(size, type);
}

API_EXPORT void* NxUserAllocator_realloc(NxUserAllocator* classPointer, bool call_explicit, void* memory, size_t size)
{
    return classPointer->realloc(memory, size);
}

API_EXPORT void NxUserAllocator_free(NxUserAllocator* classPointer, bool call_explicit, void* memory)
{
    classPointer->free(memory);
}

API_EXPORT void NxUserAllocator_checkDEBUG(NxUserAllocator* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxUserAllocator::checkDEBUG() : classPointer->checkDEBUG();
}

API_EXPORT void* ControllerManagerAllocator_mallocDEBUG(ControllerManagerAllocator* classPointer, bool call_explicit, size_t size, char* fileName, int line)
{
    return (call_explicit) ? classPointer->ControllerManagerAllocator::mallocDEBUG(size, fileName, line) : classPointer->mallocDEBUG(size, fileName, line);
}

API_EXPORT void* ControllerManagerAllocator_malloc(ControllerManagerAllocator* classPointer, bool call_explicit, size_t size)
{
    return (call_explicit) ? classPointer->ControllerManagerAllocator::malloc(size) : classPointer->malloc(size);
}

API_EXPORT void* ControllerManagerAllocator_realloc(ControllerManagerAllocator* classPointer, bool call_explicit, void* memory, size_t size)
{
    return (call_explicit) ? classPointer->ControllerManagerAllocator::realloc(memory, size) : classPointer->realloc(memory, size);
}

API_EXPORT void ControllerManagerAllocator_free(ControllerManagerAllocator* classPointer, bool call_explicit, void* memory)
{
    (call_explicit) ? classPointer->ControllerManagerAllocator::free(memory) : classPointer->free(memory);
}

API_EXPORT void set_NxActiveTransform_actor(NxActiveTransform* classPointer, NxActor* newvalue)
{
    classPointer->actor = newvalue;
}

API_EXPORT NxActor* get_NxActiveTransform_actor(NxActiveTransform* classPointer)
{
    return classPointer->actor;
}

API_EXPORT void set_NxActiveTransform_userData(NxActiveTransform* classPointer, void* newvalue)
{
    classPointer->userData = newvalue;
}

API_EXPORT void* get_NxActiveTransform_userData(NxActiveTransform* classPointer)
{
    return classPointer->userData;
}

API_EXPORT void set_NxActiveTransform_actor2World(NxActiveTransform* classPointer, NxMat34 newvalue)
{
    classPointer->actor2World = newvalue;
}

API_EXPORT NxMat34 get_NxActiveTransform_actor2World(NxActiveTransform* classPointer)
{
    return classPointer->actor2World;
}

API_EXPORT void NxActor_setGlobalPose(NxActor* classPointer, bool call_explicit, NxMat34& mat)
{
    classPointer->setGlobalPose(mat);
}

API_EXPORT void NxActor_setGlobalPosition(NxActor* classPointer, bool call_explicit, NxVec3& vec)
{
    classPointer->setGlobalPosition(vec);
}

API_EXPORT void NxActor_setGlobalOrientation(NxActor* classPointer, bool call_explicit, NxMat33& mat)
{
    classPointer->setGlobalOrientation(mat);
}

API_EXPORT void NxActor_setGlobalOrientationQuat(NxActor* classPointer, bool call_explicit, NxQuat& mat)
{
    classPointer->setGlobalOrientationQuat(mat);
}

API_EXPORT NxMat34 NxActor_getGlobalPose(NxActor* classPointer, bool call_explicit)
{
    return classPointer->getGlobalPose();
}

API_EXPORT NxVec3 NxActor_getGlobalPosition(NxActor* classPointer, bool call_explicit)
{
    return classPointer->getGlobalPosition();
}

API_EXPORT NxMat33 NxActor_getGlobalOrientation(NxActor* classPointer, bool call_explicit)
{
    return classPointer->getGlobalOrientation();
}

API_EXPORT NxQuat NxActor_getGlobalOrientationQuat(NxActor* classPointer, bool call_explicit)
{
    return classPointer->getGlobalOrientationQuat();
}

API_EXPORT void NxActor_moveGlobalPose(NxActor* classPointer, bool call_explicit, NxMat34& mat)
{
    classPointer->moveGlobalPose(mat);
}

API_EXPORT void NxActor_moveGlobalPosition(NxActor* classPointer, bool call_explicit, NxVec3& vec)
{
    classPointer->moveGlobalPosition(vec);
}

API_EXPORT void NxActor_moveGlobalOrientation(NxActor* classPointer, bool call_explicit, NxMat33& mat)
{
    classPointer->moveGlobalOrientation(mat);
}

API_EXPORT void NxActor_moveGlobalOrientationQuat(NxActor* classPointer, bool call_explicit, NxQuat& quat)
{
    classPointer->moveGlobalOrientationQuat(quat);
}

API_EXPORT NxShape* NxActor_createShape(NxActor* classPointer, bool call_explicit, NxShapeDesc* desc)
{
    return classPointer->createShape(*desc);
}

API_EXPORT void NxActor_releaseShape(NxActor* classPointer, bool call_explicit, NxShape* shape)
{
    classPointer->releaseShape(*shape);
}

API_EXPORT NxU32 NxActor_getNbShapes(NxActor* classPointer, bool call_explicit)
{
    return classPointer->getNbShapes();
}

API_EXPORT NxShape*const* NxActor_getShapes(NxActor* classPointer, bool call_explicit)
{
    return classPointer->getShapes();
}

API_EXPORT void NxActor_setCMassOffsetLocalPose(NxActor* classPointer, bool call_explicit, NxMat34& mat)
{
    classPointer->setCMassOffsetLocalPose(mat);
}

API_EXPORT void NxActor_setCMassOffsetLocalPosition(NxActor* classPointer, bool call_explicit, NxVec3& vec)
{
    classPointer->setCMassOffsetLocalPosition(vec);
}

API_EXPORT void NxActor_setCMassOffsetLocalOrientation(NxActor* classPointer, bool call_explicit, NxMat33& mat)
{
    classPointer->setCMassOffsetLocalOrientation(mat);
}

API_EXPORT void NxActor_setCMassOffsetGlobalPose(NxActor* classPointer, bool call_explicit, NxMat34& mat)
{
    classPointer->setCMassOffsetGlobalPose(mat);
}

API_EXPORT void NxActor_setCMassOffsetGlobalPosition(NxActor* classPointer, bool call_explicit, NxVec3& vec)
{
    classPointer->setCMassOffsetGlobalPosition(vec);
}

API_EXPORT void NxActor_setCMassOffsetGlobalOrientation(NxActor* classPointer, bool call_explicit, NxMat33& mat)
{
    classPointer->setCMassOffsetGlobalOrientation(mat);
}

API_EXPORT void NxActor_setCMassGlobalPose(NxActor* classPointer, bool call_explicit, NxMat34& mat)
{
    classPointer->setCMassGlobalPose(mat);
}

API_EXPORT void NxActor_setCMassGlobalPosition(NxActor* classPointer, bool call_explicit, NxVec3& vec)
{
    classPointer->setCMassGlobalPosition(vec);
}

API_EXPORT void NxActor_setCMassGlobalOrientation(NxActor* classPointer, bool call_explicit, NxMat33& mat)
{
    classPointer->setCMassGlobalOrientation(mat);
}

API_EXPORT NxMat34 NxActor_getCMassLocalPose(NxActor* classPointer, bool call_explicit)
{
    return classPointer->getCMassLocalPose();
}

API_EXPORT NxVec3 NxActor_getCMassLocalPosition(NxActor* classPointer, bool call_explicit)
{
    return classPointer->getCMassLocalPosition();
}

API_EXPORT NxMat33 NxActor_getCMassLocalOrientation(NxActor* classPointer, bool call_explicit)
{
    return classPointer->getCMassLocalOrientation();
}

API_EXPORT NxMat34 NxActor_getCMassGlobalPose(NxActor* classPointer, bool call_explicit)
{
    return classPointer->getCMassGlobalPose();
}

API_EXPORT NxVec3 NxActor_getCMassGlobalPosition(NxActor* classPointer, bool call_explicit)
{
    return classPointer->getCMassGlobalPosition();
}

API_EXPORT NxMat33 NxActor_getCMassGlobalOrientation(NxActor* classPointer, bool call_explicit)
{
    return classPointer->getCMassGlobalOrientation();
}

API_EXPORT void NxActor_setMass(NxActor* classPointer, bool call_explicit, NxReal mass)
{
    classPointer->setMass(mass);
}

API_EXPORT NxReal NxActor_getMass(NxActor* classPointer, bool call_explicit)
{
    return classPointer->getMass();
}

API_EXPORT void NxActor_setMassSpaceInertiaTensor(NxActor* classPointer, bool call_explicit, NxVec3& m)
{
    classPointer->setMassSpaceInertiaTensor(m);
}

API_EXPORT NxVec3 NxActor_getMassSpaceInertiaTensor(NxActor* classPointer, bool call_explicit)
{
    return classPointer->getMassSpaceInertiaTensor();
}

API_EXPORT NxMat33 NxActor_getGlobalInertiaTensor(NxActor* classPointer, bool call_explicit)
{
    return classPointer->getGlobalInertiaTensor();
}

API_EXPORT NxMat33 NxActor_getGlobalInertiaTensorInverse(NxActor* classPointer, bool call_explicit)
{
    return classPointer->getGlobalInertiaTensorInverse();
}

API_EXPORT bool NxActor_updateMassFromShapes(NxActor* classPointer, bool call_explicit, NxReal density, NxReal totalMass)
{
    return classPointer->updateMassFromShapes(density, totalMass);
}

API_EXPORT void NxActor_setLinearDamping(NxActor* classPointer, bool call_explicit, NxReal linDamp)
{
    classPointer->setLinearDamping(linDamp);
}

API_EXPORT NxReal NxActor_getLinearDamping(NxActor* classPointer, bool call_explicit)
{
    return classPointer->getLinearDamping();
}

API_EXPORT void NxActor_setAngularDamping(NxActor* classPointer, bool call_explicit, NxReal angDamp)
{
    classPointer->setAngularDamping(angDamp);
}

API_EXPORT NxReal NxActor_getAngularDamping(NxActor* classPointer, bool call_explicit)
{
    return classPointer->getAngularDamping();
}

API_EXPORT void NxActor_setLinearVelocity(NxActor* classPointer, bool call_explicit, NxVec3& linVel)
{
    classPointer->setLinearVelocity(linVel);
}

API_EXPORT void NxActor_setAngularVelocity(NxActor* classPointer, bool call_explicit, NxVec3& angVel)
{
    classPointer->setAngularVelocity(angVel);
}

API_EXPORT NxVec3 NxActor_getLinearVelocity(NxActor* classPointer, bool call_explicit)
{
    return classPointer->getLinearVelocity();
}

API_EXPORT NxVec3 NxActor_getAngularVelocity(NxActor* classPointer, bool call_explicit)
{
    return classPointer->getAngularVelocity();
}

API_EXPORT void NxActor_setMaxAngularVelocity(NxActor* classPointer, bool call_explicit, NxReal maxAngVel)
{
    classPointer->setMaxAngularVelocity(maxAngVel);
}

API_EXPORT NxReal NxActor_getMaxAngularVelocity(NxActor* classPointer, bool call_explicit)
{
    return classPointer->getMaxAngularVelocity();
}

API_EXPORT void NxActor_setCCDMotionThreshold(NxActor* classPointer, bool call_explicit, NxReal thresh)
{
    classPointer->setCCDMotionThreshold(thresh);
}

API_EXPORT NxReal NxActor_getCCDMotionThreshold(NxActor* classPointer, bool call_explicit)
{
    return classPointer->getCCDMotionThreshold();
}

API_EXPORT void NxActor_setLinearMomentum(NxActor* classPointer, bool call_explicit, NxVec3& linMoment)
{
    classPointer->setLinearMomentum(linMoment);
}

API_EXPORT void NxActor_setAngularMomentum(NxActor* classPointer, bool call_explicit, NxVec3& angMoment)
{
    classPointer->setAngularMomentum(angMoment);
}

API_EXPORT NxVec3 NxActor_getLinearMomentum(NxActor* classPointer, bool call_explicit)
{
    return classPointer->getLinearMomentum();
}

API_EXPORT NxVec3 NxActor_getAngularMomentum(NxActor* classPointer, bool call_explicit)
{
    return classPointer->getAngularMomentum();
}

API_EXPORT void NxActor_addForceAtPos(NxActor* classPointer, bool call_explicit, NxVec3& force, NxVec3& pos, NxForceMode mode, bool wakeup)
{
    classPointer->addForceAtPos(force, pos, mode, wakeup);
}

API_EXPORT void NxActor_addForceAtPos_1(NxActor* classPointer, bool call_explicit, NxVec3& force, NxVec3& pos, NxForceMode mode)
{
    classPointer->addForceAtPos(force, pos, mode);
}

API_EXPORT void NxActor_addForceAtPos_2(NxActor* classPointer, bool call_explicit, NxVec3& force, NxVec3& pos)
{
    classPointer->addForceAtPos(force, pos);
}

API_EXPORT void NxActor_addForceAtLocalPos(NxActor* classPointer, bool call_explicit, NxVec3& force, NxVec3& pos, NxForceMode mode, bool wakeup)
{
    classPointer->addForceAtLocalPos(force, pos, mode, wakeup);
}

API_EXPORT void NxActor_addForceAtLocalPos_1(NxActor* classPointer, bool call_explicit, NxVec3& force, NxVec3& pos, NxForceMode mode)
{
    classPointer->addForceAtLocalPos(force, pos, mode);
}

API_EXPORT void NxActor_addForceAtLocalPos_2(NxActor* classPointer, bool call_explicit, NxVec3& force, NxVec3& pos)
{
    classPointer->addForceAtLocalPos(force, pos);
}

API_EXPORT void NxActor_addLocalForceAtPos(NxActor* classPointer, bool call_explicit, NxVec3& force, NxVec3& pos, NxForceMode mode, bool wakeup)
{
    classPointer->addLocalForceAtPos(force, pos, mode, wakeup);
}

API_EXPORT void NxActor_addLocalForceAtPos_1(NxActor* classPointer, bool call_explicit, NxVec3& force, NxVec3& pos, NxForceMode mode)
{
    classPointer->addLocalForceAtPos(force, pos, mode);
}

API_EXPORT void NxActor_addLocalForceAtPos_2(NxActor* classPointer, bool call_explicit, NxVec3& force, NxVec3& pos)
{
    classPointer->addLocalForceAtPos(force, pos);
}

API_EXPORT void NxActor_addLocalForceAtLocalPos(NxActor* classPointer, bool call_explicit, NxVec3& force, NxVec3& pos, NxForceMode mode, bool wakeup)
{
    classPointer->addLocalForceAtLocalPos(force, pos, mode, wakeup);
}

API_EXPORT void NxActor_addLocalForceAtLocalPos_1(NxActor* classPointer, bool call_explicit, NxVec3& force, NxVec3& pos, NxForceMode mode)
{
    classPointer->addLocalForceAtLocalPos(force, pos, mode);
}

API_EXPORT void NxActor_addLocalForceAtLocalPos_2(NxActor* classPointer, bool call_explicit, NxVec3& force, NxVec3& pos)
{
    classPointer->addLocalForceAtLocalPos(force, pos);
}

API_EXPORT void NxActor_addForce(NxActor* classPointer, bool call_explicit, NxVec3& force, NxForceMode mode, bool wakeup)
{
    classPointer->addForce(force, mode, wakeup);
}

API_EXPORT void NxActor_addForce_1(NxActor* classPointer, bool call_explicit, NxVec3& force, NxForceMode mode)
{
    classPointer->addForce(force, mode);
}

API_EXPORT void NxActor_addForce_2(NxActor* classPointer, bool call_explicit, NxVec3& force)
{
    classPointer->addForce(force);
}

API_EXPORT void NxActor_addLocalForce(NxActor* classPointer, bool call_explicit, NxVec3& force, NxForceMode mode, bool wakeup)
{
    classPointer->addLocalForce(force, mode, wakeup);
}

API_EXPORT void NxActor_addLocalForce_1(NxActor* classPointer, bool call_explicit, NxVec3& force, NxForceMode mode)
{
    classPointer->addLocalForce(force, mode);
}

API_EXPORT void NxActor_addLocalForce_2(NxActor* classPointer, bool call_explicit, NxVec3& force)
{
    classPointer->addLocalForce(force);
}

API_EXPORT void NxActor_addTorque(NxActor* classPointer, bool call_explicit, NxVec3& torque, NxForceMode mode, bool wakeup)
{
    classPointer->addTorque(torque, mode, wakeup);
}

API_EXPORT void NxActor_addTorque_1(NxActor* classPointer, bool call_explicit, NxVec3& torque, NxForceMode mode)
{
    classPointer->addTorque(torque, mode);
}

API_EXPORT void NxActor_addTorque_2(NxActor* classPointer, bool call_explicit, NxVec3& torque)
{
    classPointer->addTorque(torque);
}

API_EXPORT void NxActor_addLocalTorque(NxActor* classPointer, bool call_explicit, NxVec3& torque, NxForceMode mode, bool wakeup)
{
    classPointer->addLocalTorque(torque, mode, wakeup);
}

API_EXPORT void NxActor_addLocalTorque_1(NxActor* classPointer, bool call_explicit, NxVec3& torque, NxForceMode mode)
{
    classPointer->addLocalTorque(torque, mode);
}

API_EXPORT void NxActor_addLocalTorque_2(NxActor* classPointer, bool call_explicit, NxVec3& torque)
{
    classPointer->addLocalTorque(torque);
}

API_EXPORT NxVec3 NxActor_getPointVelocity(NxActor* classPointer, bool call_explicit, NxVec3& point)
{
    return classPointer->getPointVelocity(point);
}

API_EXPORT NxVec3 NxActor_getLocalPointVelocity(NxActor* classPointer, bool call_explicit, NxVec3& point)
{
    return classPointer->getLocalPointVelocity(point);
}

API_EXPORT bool NxActor_isGroupSleeping(NxActor* classPointer, bool call_explicit)
{
    return classPointer->isGroupSleeping();
}

API_EXPORT bool NxActor_isSleeping(NxActor* classPointer, bool call_explicit)
{
    return classPointer->isSleeping();
}

API_EXPORT NxReal NxActor_getSleepLinearVelocity(NxActor* classPointer, bool call_explicit)
{
    return classPointer->getSleepLinearVelocity();
}

API_EXPORT void NxActor_setSleepLinearVelocity(NxActor* classPointer, bool call_explicit, NxReal threshold)
{
    classPointer->setSleepLinearVelocity(threshold);
}

API_EXPORT NxReal NxActor_getSleepAngularVelocity(NxActor* classPointer, bool call_explicit)
{
    return classPointer->getSleepAngularVelocity();
}

API_EXPORT void NxActor_setSleepAngularVelocity(NxActor* classPointer, bool call_explicit, NxReal threshold)
{
    classPointer->setSleepAngularVelocity(threshold);
}

API_EXPORT NxReal NxActor_getSleepEnergyThreshold(NxActor* classPointer, bool call_explicit)
{
    return classPointer->getSleepEnergyThreshold();
}

API_EXPORT void NxActor_setSleepEnergyThreshold(NxActor* classPointer, bool call_explicit, NxReal threshold)
{
    classPointer->setSleepEnergyThreshold(threshold);
}

API_EXPORT void NxActor_wakeUp(NxActor* classPointer, bool call_explicit, NxReal wakeCounterValue)
{
    classPointer->wakeUp(wakeCounterValue);
}

API_EXPORT void NxActor_putToSleep(NxActor* classPointer, bool call_explicit)
{
    classPointer->putToSleep();
}

API_EXPORT void set_NxActor_userData(NxActor* classPointer, void* newvalue)
{
    classPointer->userData = newvalue;
}

API_EXPORT void* get_NxActor_userData(NxActor* classPointer)
{
    return classPointer->userData;
}

API_EXPORT NxActor* new_NxActor(bool do_override)
{
    return (do_override) ? new NxActor_doxybind() : NULL;
}

API_EXPORT NxScene* NxActor_getScene(NxActor* classPointer, bool call_explicit)
{
    return &classPointer->getScene();
}

API_EXPORT void NxActor_saveToDesc(NxActor* classPointer, bool call_explicit, NxActorDescBase* desc)
{
    classPointer->saveToDesc(*desc);
}

API_EXPORT void NxActor_setName(NxActor* classPointer, bool call_explicit, char* name)
{
    classPointer->setName(name);
}

API_EXPORT const char* NxActor_getName(NxActor* classPointer, bool call_explicit)
{
    return classPointer->getName();
}

API_EXPORT void NxActor_setGroup(NxActor* classPointer, bool call_explicit, NxActorGroup actorGroup)
{
    classPointer->setGroup(actorGroup);
}

API_EXPORT NxActorGroup NxActor_getGroup(NxActor* classPointer, bool call_explicit)
{
    return classPointer->getGroup();
}

API_EXPORT void NxActor_setDominanceGroup(NxActor* classPointer, bool call_explicit, NxDominanceGroup dominanceGroup)
{
    classPointer->setDominanceGroup(dominanceGroup);
}

API_EXPORT NxDominanceGroup NxActor_getDominanceGroup(NxActor* classPointer, bool call_explicit)
{
    return classPointer->getDominanceGroup();
}

API_EXPORT void NxActor_raiseActorFlag(NxActor* classPointer, bool call_explicit, NxActorFlag actorFlag)
{
    classPointer->raiseActorFlag(actorFlag);
}

API_EXPORT void NxActor_clearActorFlag(NxActor* classPointer, bool call_explicit, NxActorFlag actorFlag)
{
    classPointer->clearActorFlag(actorFlag);
}

API_EXPORT bool NxActor_readActorFlag(NxActor* classPointer, bool call_explicit, NxActorFlag actorFlag)
{
    return classPointer->readActorFlag(actorFlag);
}

API_EXPORT void NxActor_resetUserActorPairFiltering(NxActor* classPointer, bool call_explicit)
{
    classPointer->resetUserActorPairFiltering();
}

API_EXPORT bool NxActor_isDynamic(NxActor* classPointer, bool call_explicit)
{
    return classPointer->isDynamic();
}

API_EXPORT NxReal NxActor_computeKineticEnergy(NxActor* classPointer, bool call_explicit)
{
    return classPointer->computeKineticEnergy();
}

API_EXPORT void NxActor_raiseBodyFlag(NxActor* classPointer, bool call_explicit, NxBodyFlag bodyFlag)
{
    classPointer->raiseBodyFlag(bodyFlag);
}

API_EXPORT void NxActor_clearBodyFlag(NxActor* classPointer, bool call_explicit, NxBodyFlag bodyFlag)
{
    classPointer->clearBodyFlag(bodyFlag);
}

API_EXPORT bool NxActor_readBodyFlag(NxActor* classPointer, bool call_explicit, NxBodyFlag bodyFlag)
{
    return classPointer->readBodyFlag(bodyFlag);
}

API_EXPORT bool NxActor_saveBodyToDesc(NxActor* classPointer, bool call_explicit, NxBodyDesc* bodyDesc)
{
    return classPointer->saveBodyToDesc(*bodyDesc);
}

API_EXPORT void NxActor_setSolverIterationCount(NxActor* classPointer, bool call_explicit, NxU32 iterCount)
{
    classPointer->setSolverIterationCount(iterCount);
}

API_EXPORT NxU32 NxActor_getSolverIterationCount(NxActor* classPointer, bool call_explicit)
{
    return classPointer->getSolverIterationCount();
}

API_EXPORT NxReal NxActor_getContactReportThreshold(NxActor* classPointer, bool call_explicit)
{
    return classPointer->getContactReportThreshold();
}

API_EXPORT void NxActor_setContactReportThreshold(NxActor* classPointer, bool call_explicit, NxReal threshold)
{
    classPointer->setContactReportThreshold(threshold);
}

API_EXPORT NxU32 NxActor_getContactReportFlags(NxActor* classPointer, bool call_explicit)
{
    return classPointer->getContactReportFlags();
}

API_EXPORT void NxActor_setContactReportFlags(NxActor* classPointer, bool call_explicit, NxU32 flags)
{
    classPointer->setContactReportFlags(flags);
}

API_EXPORT NxU32 NxActor_linearSweep(NxActor* classPointer, bool call_explicit, NxVec3& motion, NxU32 flags, void* userData, NxU32 nbShapes, NxSweepQueryHit* shapes, NxUserEntityReport< NxSweepQueryHit >* callback, NxSweepCache* sweepCache)
{
    return classPointer->linearSweep(motion, flags, userData, nbShapes, shapes, callback, sweepCache);
}

API_EXPORT NxU32 NxActor_linearSweep_1(NxActor* classPointer, bool call_explicit, NxVec3& motion, NxU32 flags, void* userData, NxU32 nbShapes, NxSweepQueryHit* shapes, NxUserEntityReport< NxSweepQueryHit >* callback)
{
    return classPointer->linearSweep(motion, flags, userData, nbShapes, shapes, callback);
}

API_EXPORT NxCompartment* NxActor_getCompartment(NxActor* classPointer, bool call_explicit)
{
    return classPointer->getCompartment();
}

API_EXPORT NxForceFieldMaterial NxActor_getForceFieldMaterial(NxActor* classPointer, bool call_explicit)
{
    return classPointer->getForceFieldMaterial();
}

API_EXPORT void NxActor_setForceFieldMaterial(NxActor* classPointer, bool call_explicit, NxForceFieldMaterial unknown2)
{
    classPointer->setForceFieldMaterial(unknown2);
}

API_EXPORT void set_NxActorDescBase_globalPose(NxActorDescBase* classPointer, NxMat34 newvalue)
{
    classPointer->globalPose = newvalue;
}

API_EXPORT NxMat34 get_NxActorDescBase_globalPose(NxActorDescBase* classPointer)
{
    return classPointer->globalPose;
}

API_EXPORT void set_NxActorDescBase_body(NxActorDescBase* classPointer, const NxBodyDesc* newvalue)
{
    classPointer->body = newvalue;
}

API_EXPORT const NxBodyDesc* get_NxActorDescBase_body(NxActorDescBase* classPointer)
{
    return classPointer->body;
}

API_EXPORT void set_NxActorDescBase_density(NxActorDescBase* classPointer, NxReal newvalue)
{
    classPointer->density = newvalue;
}

API_EXPORT NxReal get_NxActorDescBase_density(NxActorDescBase* classPointer)
{
    return classPointer->density;
}

API_EXPORT void set_NxActorDescBase_flags(NxActorDescBase* classPointer, NxU32 newvalue)
{
    classPointer->flags = newvalue;
}

API_EXPORT NxU32 get_NxActorDescBase_flags(NxActorDescBase* classPointer)
{
    return classPointer->flags;
}

API_EXPORT void set_NxActorDescBase_group(NxActorDescBase* classPointer, NxActorGroup newvalue)
{
    classPointer->group = newvalue;
}

API_EXPORT NxActorGroup get_NxActorDescBase_group(NxActorDescBase* classPointer)
{
    return classPointer->group;
}

API_EXPORT void set_NxActorDescBase_dominanceGroup(NxActorDescBase* classPointer, NxDominanceGroup newvalue)
{
    classPointer->dominanceGroup = newvalue;
}

API_EXPORT NxDominanceGroup get_NxActorDescBase_dominanceGroup(NxActorDescBase* classPointer)
{
    return classPointer->dominanceGroup;
}

API_EXPORT void set_NxActorDescBase_contactReportFlags(NxActorDescBase* classPointer, NxU32 newvalue)
{
    classPointer->contactReportFlags = newvalue;
}

API_EXPORT NxU32 get_NxActorDescBase_contactReportFlags(NxActorDescBase* classPointer)
{
    return classPointer->contactReportFlags;
}

API_EXPORT void set_NxActorDescBase_forceFieldMaterial(NxActorDescBase* classPointer, NxU16 newvalue)
{
    classPointer->forceFieldMaterial = newvalue;
}

API_EXPORT NxU16 get_NxActorDescBase_forceFieldMaterial(NxActorDescBase* classPointer)
{
    return classPointer->forceFieldMaterial;
}

API_EXPORT void set_NxActorDescBase_userData(NxActorDescBase* classPointer, void* newvalue)
{
    classPointer->userData = newvalue;
}

API_EXPORT void* get_NxActorDescBase_userData(NxActorDescBase* classPointer)
{
    return classPointer->userData;
}

API_EXPORT void set_NxActorDescBase_name(NxActorDescBase* classPointer, const char* newvalue)
{
    classPointer->name = newvalue;
}

API_EXPORT const char* get_NxActorDescBase_name(NxActorDescBase* classPointer)
{
    return classPointer->name;
}

API_EXPORT void set_NxActorDescBase_compartment(NxActorDescBase* classPointer, NxCompartment* newvalue)
{
    classPointer->compartment = newvalue;
}

API_EXPORT NxCompartment* get_NxActorDescBase_compartment(NxActorDescBase* classPointer)
{
    return classPointer->compartment;
}

API_EXPORT void NxActorDescBase_setToDefault(NxActorDescBase* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxActorDescBase::setToDefault() : classPointer->setToDefault();
}

API_EXPORT bool NxActorDescBase_isValid(NxActorDescBase* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxActorDescBase::isValid() : classPointer->isValid();
}

API_EXPORT NxActorDescType NxActorDescBase_getType(NxActorDescBase* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxActorDescBase::getType() : classPointer->getType();
}

API_EXPORT NxActorDescBase* new_NxActorDescBase(bool do_override)
{
    return NULL;
}

API_EXPORT void set_NxActorDesc_shapes(NxActorDesc* classPointer, NxArray< NxShapeDesc*, NxAllocatorDefault >* newvalue)
{
    classPointer->shapes = *newvalue;
}

API_EXPORT NxArray< NxShapeDesc*, NxAllocatorDefault >* get_NxActorDesc_shapes(NxActorDesc* classPointer)
{
    return &classPointer->shapes;
}

API_EXPORT NxActorDesc* new_NxActorDesc(bool do_override)
{
    return new NxActorDesc();
}

API_EXPORT void NxActorDesc_setToDefault(NxActorDesc* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxActorDesc::setToDefault() : classPointer->setToDefault();
}

API_EXPORT bool NxActorDesc_isValid(NxActorDesc* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxActorDesc::isValid() : classPointer->isValid();
}

API_EXPORT void set_NxActorGroupPair_group0(NxActorGroupPair* classPointer, NxActorGroup newvalue)
{
    classPointer->group0 = newvalue;
}

API_EXPORT NxActorGroup get_NxActorGroupPair_group0(NxActorGroupPair* classPointer)
{
    return classPointer->group0;
}

API_EXPORT void set_NxActorGroupPair_group1(NxActorGroupPair* classPointer, NxActorGroup newvalue)
{
    classPointer->group1 = newvalue;
}

API_EXPORT NxActorGroup get_NxActorGroupPair_group1(NxActorGroupPair* classPointer)
{
    return classPointer->group1;
}

API_EXPORT void set_NxActorGroupPair_flags(NxActorGroupPair* classPointer, NxU32 newvalue)
{
    classPointer->flags = newvalue;
}

API_EXPORT NxU32 get_NxActorGroupPair_flags(NxActorGroupPair* classPointer)
{
    return classPointer->flags;
}

API_EXPORT void set_NxActorPairFilter_actor(NxActorPairFilter* classPointer, NxActor* newvalue[2])
{
    memcpy(&classPointer->actor[0], &newvalue[0], sizeof(NxActor*) * 2);
}

API_EXPORT void get_NxActorPairFilter_actor(NxActorPairFilter* classPointer, NxActor* newvalue[2])
{
    memcpy(&newvalue[0], &classPointer->actor[0], sizeof(NxActor*) * 2);
}

API_EXPORT void set_NxActorPairFilter_filtered(NxActorPairFilter* classPointer, bool newvalue)
{
    classPointer->filtered = newvalue;
}

API_EXPORT bool get_NxActorPairFilter_filtered(NxActorPairFilter* classPointer)
{
    return classPointer->filtered;
}

API_EXPORT void* NxAllocatorDefault_malloc(NxAllocatorDefault* classPointer, bool call_explicit, size_t size, NxMemoryType type)
{
    return (call_explicit) ? classPointer->NxAllocatorDefault::malloc(size, type) : classPointer->malloc(size, type);
}

API_EXPORT void* NxAllocatorDefault_mallocDEBUG(NxAllocatorDefault* classPointer, bool call_explicit, size_t size, char* fileName, int line, char* className, NxMemoryType type)
{
    return (call_explicit) ? classPointer->NxAllocatorDefault::mallocDEBUG(size, fileName, line, className, type) : classPointer->mallocDEBUG(size, fileName, line, className, type);
}

API_EXPORT void* NxAllocatorDefault_realloc(NxAllocatorDefault* classPointer, bool call_explicit, void* memory, size_t size)
{
    return (call_explicit) ? classPointer->NxAllocatorDefault::realloc(memory, size) : classPointer->realloc(memory, size);
}

API_EXPORT void NxAllocatorDefault_free(NxAllocatorDefault* classPointer, bool call_explicit, void* memory)
{
    (call_explicit) ? classPointer->NxAllocatorDefault::free(memory) : classPointer->free(memory);
}

API_EXPORT void NxAllocatorDefault_check(NxAllocatorDefault* classPointer, bool call_explicit, void* memory)
{
    (call_explicit) ? classPointer->NxAllocatorDefault::check(memory) : classPointer->check(memory);
}

API_EXPORT void set_NxBitField_bitField(NxBitField* classPointer, NxBitField::IntType newvalue)
{
    classPointer->bitField = newvalue;
}

API_EXPORT NxBitField::IntType get_NxBitField_bitField(NxBitField* classPointer)
{
    return classPointer->bitField;
}

API_EXPORT NxBitField* new_NxBitField(bool do_override)
{
    return new NxBitField();
}

API_EXPORT NxBitField* new_NxBitField_1(bool do_override, NxBitField::IntType unknown3)
{
    return new NxBitField(unknown3);
}

API_EXPORT NxBitField* new_NxBitField_2(bool do_override, NxBitField* unknown4)
{
    return new NxBitField(*unknown4);
}

API_EXPORT void NxBitField_setFlag(NxBitField* classPointer, bool call_explicit, NxU32 bitIndex, NxBitField::Flag value)
{
    (call_explicit) ? classPointer->NxBitField::setFlag(bitIndex, value) : classPointer->setFlag(bitIndex, value);
}

API_EXPORT void NxBitField_raiseFlag(NxBitField* classPointer, bool call_explicit, NxU32 bitIndex)
{
    (call_explicit) ? classPointer->NxBitField::raiseFlag(bitIndex) : classPointer->raiseFlag(bitIndex);
}

API_EXPORT void NxBitField_lowerFlag(NxBitField* classPointer, bool call_explicit, NxU32 bitIndex)
{
    (call_explicit) ? classPointer->NxBitField::lowerFlag(bitIndex) : classPointer->lowerFlag(bitIndex);
}

API_EXPORT NxBitField::Flag NxBitField_getFlag(NxBitField* classPointer, bool call_explicit, NxU32 bitIndex)
{
    return (call_explicit) ? classPointer->NxBitField::getFlag(bitIndex) : classPointer->getFlag(bitIndex);
}

API_EXPORT void NxBitField_setFlagMask(NxBitField* classPointer, bool call_explicit, NxBitField::Mask mask, NxBitField::Flag value)
{
    (call_explicit) ? classPointer->NxBitField::setFlagMask(mask, value) : classPointer->setFlagMask(mask, value);
}

API_EXPORT void NxBitField_raiseFlagMask(NxBitField* classPointer, bool call_explicit, NxBitField::Mask mask)
{
    (call_explicit) ? classPointer->NxBitField::raiseFlagMask(mask) : classPointer->raiseFlagMask(mask);
}

API_EXPORT void NxBitField_lowerFlagMask(NxBitField* classPointer, bool call_explicit, NxBitField::Mask mask)
{
    (call_explicit) ? classPointer->NxBitField::lowerFlagMask(mask) : classPointer->lowerFlagMask(mask);
}

API_EXPORT bool NxBitField_getFlagMask(NxBitField* classPointer, bool call_explicit, NxBitField::Mask mask)
{
    return (call_explicit) ? classPointer->NxBitField::getFlagMask(mask) : classPointer->getFlagMask(mask);
}

API_EXPORT NxBitField::Field NxBitField_getField(NxBitField* classPointer, bool call_explicit, NxBitField::Shift shift, NxBitField::Mask mask)
{
    return (call_explicit) ? classPointer->NxBitField::getField(shift, mask) : classPointer->getField(shift, mask);
}

API_EXPORT void NxBitField_setField(NxBitField* classPointer, bool call_explicit, NxBitField::Shift shift, NxBitField::Mask mask, NxBitField::Field field)
{
    (call_explicit) ? classPointer->NxBitField::setField(shift, mask, field) : classPointer->setField(shift, mask, field);
}

API_EXPORT void NxBitField_clearField(NxBitField* classPointer, bool call_explicit, NxBitField::Mask mask)
{
    (call_explicit) ? classPointer->NxBitField::clearField(mask) : classPointer->clearField(mask);
}

/*API_EXPORT NxBitField::Mask NxBitField_rangeToDenseMask(NxBitField* classPointer, bool call_explicit, NxU32 lowIndex, NxU32 highIndex)
{
    return (call_explicit) ? classPointer->NxBitField::rangeToDenseMask(lowIndex, highIndex) : classPointer->rangeToDenseMask(lowIndex, highIndex);
}

API_EXPORT NxBitField::Shift NxBitField_maskToShift(NxBitField* classPointer, bool call_explicit, NxBitField::Mask mask)
{
    return (call_explicit) ? classPointer->NxBitField::maskToShift(mask) : classPointer->maskToShift(mask);
}*/

API_EXPORT NxBitField::FlagRef* new_FlagRef(bool do_override, NxBitField* x, NxU32 index)
{
    return new NxBitField::FlagRef(*x, index);
}

API_EXPORT void set_NxBodyDesc_massLocalPose(NxBodyDesc* classPointer, NxMat34 newvalue)
{
    classPointer->massLocalPose = newvalue;
}

API_EXPORT NxMat34 get_NxBodyDesc_massLocalPose(NxBodyDesc* classPointer)
{
    return classPointer->massLocalPose;
}

API_EXPORT void set_NxBodyDesc_massSpaceInertia(NxBodyDesc* classPointer, NxVec3 newvalue)
{
    classPointer->massSpaceInertia = newvalue;
}

API_EXPORT NxVec3 get_NxBodyDesc_massSpaceInertia(NxBodyDesc* classPointer)
{
    return classPointer->massSpaceInertia;
}

API_EXPORT void set_NxBodyDesc_mass(NxBodyDesc* classPointer, NxReal newvalue)
{
    classPointer->mass = newvalue;
}

API_EXPORT NxReal get_NxBodyDesc_mass(NxBodyDesc* classPointer)
{
    return classPointer->mass;
}

API_EXPORT void set_NxBodyDesc_linearVelocity(NxBodyDesc* classPointer, NxVec3 newvalue)
{
    classPointer->linearVelocity = newvalue;
}

API_EXPORT NxVec3 get_NxBodyDesc_linearVelocity(NxBodyDesc* classPointer)
{
    return classPointer->linearVelocity;
}

API_EXPORT void set_NxBodyDesc_angularVelocity(NxBodyDesc* classPointer, NxVec3 newvalue)
{
    classPointer->angularVelocity = newvalue;
}

API_EXPORT NxVec3 get_NxBodyDesc_angularVelocity(NxBodyDesc* classPointer)
{
    return classPointer->angularVelocity;
}

API_EXPORT void set_NxBodyDesc_wakeUpCounter(NxBodyDesc* classPointer, NxReal newvalue)
{
    classPointer->wakeUpCounter = newvalue;
}

API_EXPORT NxReal get_NxBodyDesc_wakeUpCounter(NxBodyDesc* classPointer)
{
    return classPointer->wakeUpCounter;
}

API_EXPORT void set_NxBodyDesc_linearDamping(NxBodyDesc* classPointer, NxReal newvalue)
{
    classPointer->linearDamping = newvalue;
}

API_EXPORT NxReal get_NxBodyDesc_linearDamping(NxBodyDesc* classPointer)
{
    return classPointer->linearDamping;
}

API_EXPORT void set_NxBodyDesc_angularDamping(NxBodyDesc* classPointer, NxReal newvalue)
{
    classPointer->angularDamping = newvalue;
}

API_EXPORT NxReal get_NxBodyDesc_angularDamping(NxBodyDesc* classPointer)
{
    return classPointer->angularDamping;
}

API_EXPORT void set_NxBodyDesc_maxAngularVelocity(NxBodyDesc* classPointer, NxReal newvalue)
{
    classPointer->maxAngularVelocity = newvalue;
}

API_EXPORT NxReal get_NxBodyDesc_maxAngularVelocity(NxBodyDesc* classPointer)
{
    return classPointer->maxAngularVelocity;
}

API_EXPORT void set_NxBodyDesc_CCDMotionThreshold(NxBodyDesc* classPointer, NxReal newvalue)
{
    classPointer->CCDMotionThreshold = newvalue;
}

API_EXPORT NxReal get_NxBodyDesc_CCDMotionThreshold(NxBodyDesc* classPointer)
{
    return classPointer->CCDMotionThreshold;
}

API_EXPORT void set_NxBodyDesc_flags(NxBodyDesc* classPointer, NxU32 newvalue)
{
    classPointer->flags = newvalue;
}

API_EXPORT NxU32 get_NxBodyDesc_flags(NxBodyDesc* classPointer)
{
    return classPointer->flags;
}

API_EXPORT void set_NxBodyDesc_sleepLinearVelocity(NxBodyDesc* classPointer, NxReal newvalue)
{
    classPointer->sleepLinearVelocity = newvalue;
}

API_EXPORT NxReal get_NxBodyDesc_sleepLinearVelocity(NxBodyDesc* classPointer)
{
    return classPointer->sleepLinearVelocity;
}

API_EXPORT void set_NxBodyDesc_sleepAngularVelocity(NxBodyDesc* classPointer, NxReal newvalue)
{
    classPointer->sleepAngularVelocity = newvalue;
}

API_EXPORT NxReal get_NxBodyDesc_sleepAngularVelocity(NxBodyDesc* classPointer)
{
    return classPointer->sleepAngularVelocity;
}

API_EXPORT void set_NxBodyDesc_solverIterationCount(NxBodyDesc* classPointer, NxU32 newvalue)
{
    classPointer->solverIterationCount = newvalue;
}

API_EXPORT NxU32 get_NxBodyDesc_solverIterationCount(NxBodyDesc* classPointer)
{
    return classPointer->solverIterationCount;
}

API_EXPORT void set_NxBodyDesc_sleepEnergyThreshold(NxBodyDesc* classPointer, NxReal newvalue)
{
    classPointer->sleepEnergyThreshold = newvalue;
}

API_EXPORT NxReal get_NxBodyDesc_sleepEnergyThreshold(NxBodyDesc* classPointer)
{
    return classPointer->sleepEnergyThreshold;
}

API_EXPORT void set_NxBodyDesc_sleepDamping(NxBodyDesc* classPointer, NxReal newvalue)
{
    classPointer->sleepDamping = newvalue;
}

API_EXPORT NxReal get_NxBodyDesc_sleepDamping(NxBodyDesc* classPointer)
{
    return classPointer->sleepDamping;
}

API_EXPORT void set_NxBodyDesc_contactReportThreshold(NxBodyDesc* classPointer, NxReal newvalue)
{
    classPointer->contactReportThreshold = newvalue;
}

API_EXPORT NxReal get_NxBodyDesc_contactReportThreshold(NxBodyDesc* classPointer)
{
    return classPointer->contactReportThreshold;
}

API_EXPORT NxBodyDesc* new_NxBodyDesc(bool do_override)
{
    return new NxBodyDesc();
}

API_EXPORT void NxBodyDesc_setToDefault(NxBodyDesc* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxBodyDesc::setToDefault() : classPointer->setToDefault();
}

API_EXPORT bool NxBodyDesc_isValid(NxBodyDesc* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxBodyDesc::isValid() : classPointer->isValid();
}

API_EXPORT void set_NxBounds3_min(NxBounds3* classPointer, NxVec3 newvalue)
{
    classPointer->min = newvalue;
}

API_EXPORT NxVec3 get_NxBounds3_min(NxBounds3* classPointer)
{
    return classPointer->min;
}

API_EXPORT void set_NxBounds3_max(NxBounds3* classPointer, NxVec3 newvalue)
{
    classPointer->max = newvalue;
}

API_EXPORT NxVec3 get_NxBounds3_max(NxBounds3* classPointer)
{
    return classPointer->max;
}

API_EXPORT NxBounds3* new_NxBounds3(bool do_override)
{
    return new NxBounds3();
}

API_EXPORT void NxBounds3_setEmpty(NxBounds3* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxBounds3::setEmpty() : classPointer->setEmpty();
}

API_EXPORT void NxBounds3_setInfinite(NxBounds3* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxBounds3::setInfinite() : classPointer->setInfinite();
}

API_EXPORT void NxBounds3_set(NxBounds3* classPointer, bool call_explicit, NxReal minx, NxReal miny, NxReal minz, NxReal maxx, NxReal maxy, NxReal maxz)
{
    (call_explicit) ? classPointer->NxBounds3::set(minx, miny, minz, maxx, maxy, maxz) : classPointer->set(minx, miny, minz, maxx, maxy, maxz);
}

API_EXPORT void NxBounds3_set_1(NxBounds3* classPointer, bool call_explicit, NxVec3& min, NxVec3& max)
{
    (call_explicit) ? classPointer->NxBounds3::set(min, max) : classPointer->set(min, max);
}

API_EXPORT void NxBounds3_include(NxBounds3* classPointer, bool call_explicit, NxVec3& v)
{
    (call_explicit) ? classPointer->NxBounds3::include(v) : classPointer->include(v);
}

API_EXPORT void NxBounds3_combine(NxBounds3* classPointer, bool call_explicit, NxBounds3* b2)
{
    (call_explicit) ? classPointer->NxBounds3::combine(*b2) : classPointer->combine(*b2);
}

API_EXPORT void NxBounds3_boundsOfOBB(NxBounds3* classPointer, bool call_explicit, NxMat33& orientation, NxVec3& translation, NxVec3& halfDims)
{
    (call_explicit) ? classPointer->NxBounds3::boundsOfOBB(orientation, translation, halfDims) : classPointer->boundsOfOBB(orientation, translation, halfDims);
}

API_EXPORT void NxBounds3_transform(NxBounds3* classPointer, bool call_explicit, NxMat33& orientation, NxVec3& translation)
{
    (call_explicit) ? classPointer->NxBounds3::transform(orientation, translation) : classPointer->transform(orientation, translation);
}

API_EXPORT bool NxBounds3_isEmpty(NxBounds3* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxBounds3::isEmpty() : classPointer->isEmpty();
}

API_EXPORT bool NxBounds3_intersects(NxBounds3* classPointer, bool call_explicit, NxBounds3* b)
{
    return (call_explicit) ? classPointer->NxBounds3::intersects(*b) : classPointer->intersects(*b);
}

API_EXPORT bool NxBounds3_intersects2D(NxBounds3* classPointer, bool call_explicit, NxBounds3* b, unsigned axisToIgnore)
{
    return (call_explicit) ? classPointer->NxBounds3::intersects2D(*b, axisToIgnore) : classPointer->intersects2D(*b, axisToIgnore);
}

API_EXPORT bool NxBounds3_contain(NxBounds3* classPointer, bool call_explicit, NxVec3& v)
{
    return (call_explicit) ? classPointer->NxBounds3::contain(v) : classPointer->contain(v);
}

API_EXPORT void NxBounds3_getCenter(NxBounds3* classPointer, bool call_explicit, NxVec3& center)
{
    (call_explicit) ? classPointer->NxBounds3::getCenter(center) : classPointer->getCenter(center);
}

API_EXPORT void NxBounds3_getDimensions(NxBounds3* classPointer, bool call_explicit, NxVec3& dims)
{
    (call_explicit) ? classPointer->NxBounds3::getDimensions(dims) : classPointer->getDimensions(dims);
}

API_EXPORT void NxBounds3_getExtents(NxBounds3* classPointer, bool call_explicit, NxVec3& extents)
{
    (call_explicit) ? classPointer->NxBounds3::getExtents(extents) : classPointer->getExtents(extents);
}

API_EXPORT void NxBounds3_setCenterExtents(NxBounds3* classPointer, bool call_explicit, NxVec3& c, NxVec3& e)
{
    (call_explicit) ? classPointer->NxBounds3::setCenterExtents(c, e) : classPointer->setCenterExtents(c, e);
}

API_EXPORT void NxBounds3_scale(NxBounds3* classPointer, bool call_explicit, NxF32 scale)
{
    (call_explicit) ? classPointer->NxBounds3::scale(scale) : classPointer->scale(scale);
}

API_EXPORT void NxBounds3_fatten(NxBounds3* classPointer, bool call_explicit, NxReal distance)
{
    (call_explicit) ? classPointer->NxBounds3::fatten(distance) : classPointer->fatten(distance);
}

API_EXPORT void set_NxBox_center(NxBox* classPointer, NxVec3 newvalue)
{
    classPointer->center = newvalue;
}

API_EXPORT NxVec3 get_NxBox_center(NxBox* classPointer)
{
    return classPointer->center;
}

API_EXPORT void set_NxBox_extents(NxBox* classPointer, NxVec3 newvalue)
{
    classPointer->extents = newvalue;
}

API_EXPORT NxVec3 get_NxBox_extents(NxBox* classPointer)
{
    return classPointer->extents;
}

API_EXPORT void set_NxBox_rot(NxBox* classPointer, NxMat33 newvalue)
{
    classPointer->rot = newvalue;
}

API_EXPORT NxMat33 get_NxBox_rot(NxBox* classPointer)
{
    return classPointer->rot;
}

API_EXPORT NxBox* new_NxBox(bool do_override)
{
    return new NxBox();
}

API_EXPORT NxBox* new_NxBox_1(bool do_override, NxVec3& _center, NxVec3& _extents, NxMat33& _rot)
{
    return new NxBox(_center, _extents, _rot);
}

API_EXPORT void NxBox_setEmpty(NxBox* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxBox::setEmpty() : classPointer->setEmpty();
}

API_EXPORT void NxBox_rotate(NxBox* classPointer, bool call_explicit, NxMat34& mtx, NxBox* obb)
{
    (call_explicit) ? classPointer->NxBox::rotate(mtx, *obb) : classPointer->rotate(mtx, *obb);
}

API_EXPORT bool NxBox_isValid(NxBox* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxBox::isValid() : classPointer->isValid();
}

API_EXPORT const NxVec3* NxBox_GetCenter(NxBox* classPointer, bool call_explicit)
{
    return (call_explicit) ? &classPointer->NxBox::GetCenter() : &classPointer->GetCenter();
}

API_EXPORT const NxVec3* NxBox_GetExtents(NxBox* classPointer, bool call_explicit)
{
    return (call_explicit) ? &classPointer->NxBox::GetExtents() : &classPointer->GetExtents();
}

API_EXPORT const NxMat33* NxBox_GetRot(NxBox* classPointer, bool call_explicit)
{
    return (call_explicit) ? &classPointer->NxBox::GetRot() : &classPointer->GetRot();
}

API_EXPORT NxController* new_NxController(bool do_override)
{
    return (do_override) ? new NxController_doxybind() : NULL;
}

API_EXPORT void NxController_move(NxController* classPointer, bool call_explicit, NxVec3& disp, NxU32 activeGroups, NxF32 minDist, NxU32& collisionFlags, NxF32 sharpness, NxGroupsMask* groupsMask)
{
    classPointer->move(disp, activeGroups, minDist, collisionFlags, sharpness, groupsMask);
}

API_EXPORT void NxController_move_1(NxController* classPointer, bool call_explicit, NxVec3& disp, NxU32 activeGroups, NxF32 minDist, NxU32& collisionFlags, NxF32 sharpness)
{
    classPointer->move(disp, activeGroups, minDist, collisionFlags, sharpness);
}

API_EXPORT void NxController_move_2(NxController* classPointer, bool call_explicit, NxVec3& disp, NxU32 activeGroups, NxF32 minDist, NxU32& collisionFlags)
{
    classPointer->move(disp, activeGroups, minDist, collisionFlags);
}

API_EXPORT bool NxController_setPosition(NxController* classPointer, bool call_explicit, NxExtendedVec3& position)
{
    return classPointer->setPosition(position);
}

API_EXPORT const NxExtendedVec3* NxController_getPosition(NxController* classPointer, bool call_explicit)
{
    return &classPointer->getPosition();
}

API_EXPORT const NxExtendedVec3* NxController_getFilteredPosition(NxController* classPointer, bool call_explicit)
{
    return &classPointer->getFilteredPosition();
}

API_EXPORT const NxExtendedVec3* NxController_getDebugPosition(NxController* classPointer, bool call_explicit)
{
    return &classPointer->getDebugPosition();
}

API_EXPORT NxActor* NxController_getActor(NxController* classPointer, bool call_explicit)
{
    return classPointer->getActor();
}

API_EXPORT void NxController_setStepOffset(NxController* classPointer, bool call_explicit, float offset)
{
    classPointer->setStepOffset(offset);
}

API_EXPORT void NxController_setCollision(NxController* classPointer, bool call_explicit, bool enabled)
{
    classPointer->setCollision(enabled);
}

API_EXPORT void NxController_setInteraction(NxController* classPointer, bool call_explicit, NxCCTInteractionFlag flag)
{
    classPointer->setInteraction(flag);
}

API_EXPORT NxCCTInteractionFlag NxController_getInteraction(NxController* classPointer, bool call_explicit)
{
    return classPointer->getInteraction();
}

API_EXPORT void NxController_reportSceneChanged(NxController* classPointer, bool call_explicit)
{
    classPointer->reportSceneChanged();
}

API_EXPORT void* NxController_getUserData(NxController* classPointer, bool call_explicit)
{
    return classPointer->getUserData();
}

API_EXPORT NxControllerType NxController_getType(NxController* classPointer, bool call_explicit)
{
    return classPointer->getType();
}

API_EXPORT NxBoxController* new_NxBoxController(bool do_override)
{
    return (do_override) ? new NxBoxController_doxybind() : NULL;
}

API_EXPORT const NxVec3* NxBoxController_getExtents(NxBoxController* classPointer, bool call_explicit)
{
    return &classPointer->getExtents();
}

API_EXPORT bool NxBoxController_setExtents(NxBoxController* classPointer, bool call_explicit, NxVec3& extents)
{
    return classPointer->setExtents(extents);
}

API_EXPORT void NxBoxController_setStepOffset(NxBoxController* classPointer, bool call_explicit, float offset)
{
    classPointer->setStepOffset(offset);
}

API_EXPORT void NxBoxController_reportSceneChanged(NxBoxController* classPointer, bool call_explicit)
{
    classPointer->reportSceneChanged();
}

API_EXPORT void set_NxControllerDesc_position(NxControllerDesc* classPointer, NxExtendedVec3 newvalue)
{
    classPointer->position = newvalue;
}

API_EXPORT NxExtendedVec3 get_NxControllerDesc_position(NxControllerDesc* classPointer)
{
    return classPointer->position;
}

API_EXPORT void set_NxControllerDesc_upDirection(NxControllerDesc* classPointer, NxHeightFieldAxis newvalue)
{
    classPointer->upDirection = newvalue;
}

API_EXPORT NxHeightFieldAxis get_NxControllerDesc_upDirection(NxControllerDesc* classPointer)
{
    return classPointer->upDirection;
}

API_EXPORT void set_NxControllerDesc_slopeLimit(NxControllerDesc* classPointer, NxF32 newvalue)
{
    classPointer->slopeLimit = newvalue;
}

API_EXPORT NxF32 get_NxControllerDesc_slopeLimit(NxControllerDesc* classPointer)
{
    return classPointer->slopeLimit;
}

API_EXPORT void set_NxControllerDesc_skinWidth(NxControllerDesc* classPointer, NxF32 newvalue)
{
    classPointer->skinWidth = newvalue;
}

API_EXPORT NxF32 get_NxControllerDesc_skinWidth(NxControllerDesc* classPointer)
{
    return classPointer->skinWidth;
}

API_EXPORT void set_NxControllerDesc_stepOffset(NxControllerDesc* classPointer, NxF32 newvalue)
{
    classPointer->stepOffset = newvalue;
}

API_EXPORT NxF32 get_NxControllerDesc_stepOffset(NxControllerDesc* classPointer)
{
    return classPointer->stepOffset;
}

API_EXPORT void set_NxControllerDesc_callback(NxControllerDesc* classPointer, NxUserControllerHitReport* newvalue)
{
    classPointer->callback = newvalue;
}

API_EXPORT NxUserControllerHitReport* get_NxControllerDesc_callback(NxControllerDesc* classPointer)
{
    return classPointer->callback;
}

API_EXPORT void set_NxControllerDesc_interactionFlag(NxControllerDesc* classPointer, NxCCTInteractionFlag newvalue)
{
    classPointer->interactionFlag = newvalue;
}

API_EXPORT NxCCTInteractionFlag get_NxControllerDesc_interactionFlag(NxControllerDesc* classPointer)
{
    return classPointer->interactionFlag;
}

API_EXPORT void set_NxControllerDesc_userData(NxControllerDesc* classPointer, void* newvalue)
{
    classPointer->userData = newvalue;
}

API_EXPORT void* get_NxControllerDesc_userData(NxControllerDesc* classPointer)
{
    return classPointer->userData;
}

API_EXPORT NxControllerDesc* new_NxControllerDesc(bool do_override, NxControllerType unknown5)
{
    return (do_override) ? new NxControllerDesc_doxybind(unknown5) : NULL;
}

API_EXPORT void NxControllerDesc_setToDefault(NxControllerDesc* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxControllerDesc::setToDefault() : classPointer->setToDefault();
}

API_EXPORT bool NxControllerDesc_isValid(NxControllerDesc* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxControllerDesc::isValid() : classPointer->isValid();
}

API_EXPORT NxU32 NxControllerDesc_getVersion(NxControllerDesc* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxControllerDesc::getVersion() : classPointer->getVersion();
}

API_EXPORT NxControllerType NxControllerDesc_getType(NxControllerDesc* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxControllerDesc::getType() : classPointer->getType();
}

API_EXPORT void set_NxBoxControllerDesc_extents(NxBoxControllerDesc* classPointer, NxVec3 newvalue)
{
    classPointer->extents = newvalue;
}

API_EXPORT NxVec3 get_NxBoxControllerDesc_extents(NxBoxControllerDesc* classPointer)
{
    return classPointer->extents;
}

API_EXPORT NxBoxControllerDesc* new_NxBoxControllerDesc(bool do_override)
{
    return (do_override) ? new NxBoxControllerDesc_doxybind() : new NxBoxControllerDesc();
}

API_EXPORT void NxBoxControllerDesc_setToDefault(NxBoxControllerDesc* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxBoxControllerDesc::setToDefault() : classPointer->setToDefault();
}

API_EXPORT bool NxBoxControllerDesc_isValid(NxBoxControllerDesc* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxBoxControllerDesc::isValid() : classPointer->isValid();
}

API_EXPORT void set_NxForceFieldShape_userData(NxForceFieldShape* classPointer, void* newvalue)
{
    classPointer->userData = newvalue;
}

API_EXPORT void* get_NxForceFieldShape_userData(NxForceFieldShape* classPointer)
{
    return classPointer->userData;
}

API_EXPORT void set_NxForceFieldShape_appData(NxForceFieldShape* classPointer, void* newvalue)
{
    classPointer->appData = newvalue;
}

API_EXPORT void* get_NxForceFieldShape_appData(NxForceFieldShape* classPointer)
{
    return classPointer->appData;
}

API_EXPORT NxForceFieldShape* new_NxForceFieldShape(bool do_override)
{
    return (do_override) ? new NxForceFieldShape_doxybind() : NULL;
}

API_EXPORT NxMat34 NxForceFieldShape_getPose(NxForceFieldShape* classPointer, bool call_explicit)
{
    return classPointer->getPose();
}

API_EXPORT void NxForceFieldShape_setPose(NxForceFieldShape* classPointer, bool call_explicit, NxMat34& unknown6)
{
    classPointer->setPose(unknown6);
}

API_EXPORT NxForceField* NxForceFieldShape_getForceField(NxForceFieldShape* classPointer, bool call_explicit)
{
    return classPointer->getForceField();
}

API_EXPORT NxForceFieldShapeGroup* NxForceFieldShape_getShapeGroup(NxForceFieldShape* classPointer, bool call_explicit)
{
    return &classPointer->getShapeGroup();
}

API_EXPORT void NxForceFieldShape_setName(NxForceFieldShape* classPointer, bool call_explicit, char* name)
{
    classPointer->setName(name);
}

API_EXPORT const char* NxForceFieldShape_getName(NxForceFieldShape* classPointer, bool call_explicit)
{
    return classPointer->getName();
}

API_EXPORT NxShapeType NxForceFieldShape_getType(NxForceFieldShape* classPointer, bool call_explicit)
{
    return classPointer->getType();
}

API_EXPORT void* NxForceFieldShape_is(NxForceFieldShape* classPointer, bool call_explicit, NxShapeType type)
{
    return (call_explicit) ? classPointer->NxForceFieldShape::is(type) : classPointer->is(type);
}

API_EXPORT const void* NxForceFieldShape_is_1(NxForceFieldShape* classPointer, bool call_explicit, NxShapeType type)
{
    return (call_explicit) ? classPointer->NxForceFieldShape::is(type) : classPointer->is(type);
}

API_EXPORT NxSphereForceFieldShape* NxForceFieldShape_isSphere(NxForceFieldShape* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxForceFieldShape::isSphere() : classPointer->isSphere();
}

API_EXPORT const NxSphereForceFieldShape* NxForceFieldShape_isSphere_1(NxForceFieldShape* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxForceFieldShape::isSphere() : classPointer->isSphere();
}

API_EXPORT NxBoxForceFieldShape* NxForceFieldShape_isBox(NxForceFieldShape* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxForceFieldShape::isBox() : classPointer->isBox();
}

API_EXPORT const NxBoxForceFieldShape* NxForceFieldShape_isBox_1(NxForceFieldShape* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxForceFieldShape::isBox() : classPointer->isBox();
}

API_EXPORT NxCapsuleForceFieldShape* NxForceFieldShape_isCapsule(NxForceFieldShape* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxForceFieldShape::isCapsule() : classPointer->isCapsule();
}

API_EXPORT const NxCapsuleForceFieldShape* NxForceFieldShape_isCapsule_1(NxForceFieldShape* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxForceFieldShape::isCapsule() : classPointer->isCapsule();
}

API_EXPORT NxConvexForceFieldShape* NxForceFieldShape_isConvex(NxForceFieldShape* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxForceFieldShape::isConvex() : classPointer->isConvex();
}

API_EXPORT const NxConvexForceFieldShape* NxForceFieldShape_isConvex_1(NxForceFieldShape* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxForceFieldShape::isConvex() : classPointer->isConvex();
}

API_EXPORT void NxBoxForceFieldShape_setDimensions(NxBoxForceFieldShape* classPointer, bool call_explicit, NxVec3& vec)
{
    classPointer->setDimensions(vec);
}

API_EXPORT NxVec3 NxBoxForceFieldShape_getDimensions(NxBoxForceFieldShape* classPointer, bool call_explicit)
{
    return classPointer->getDimensions();
}

API_EXPORT void NxBoxForceFieldShape_saveToDesc(NxBoxForceFieldShape* classPointer, bool call_explicit, NxBoxForceFieldShapeDesc* desc)
{
    classPointer->saveToDesc(*desc);
}

API_EXPORT void set_NxForceFieldShapeDesc_pose(NxForceFieldShapeDesc* classPointer, NxMat34 newvalue)
{
    classPointer->pose = newvalue;
}

API_EXPORT NxMat34 get_NxForceFieldShapeDesc_pose(NxForceFieldShapeDesc* classPointer)
{
    return classPointer->pose;
}

API_EXPORT void set_NxForceFieldShapeDesc_userData(NxForceFieldShapeDesc* classPointer, void* newvalue)
{
    classPointer->userData = newvalue;
}

API_EXPORT void* get_NxForceFieldShapeDesc_userData(NxForceFieldShapeDesc* classPointer)
{
    return classPointer->userData;
}

API_EXPORT void set_NxForceFieldShapeDesc_name(NxForceFieldShapeDesc* classPointer, const char* newvalue)
{
    classPointer->name = newvalue;
}

API_EXPORT const char* get_NxForceFieldShapeDesc_name(NxForceFieldShapeDesc* classPointer)
{
    return classPointer->name;
}

API_EXPORT void NxForceFieldShapeDesc_setToDefault(NxForceFieldShapeDesc* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxForceFieldShapeDesc::setToDefault() : classPointer->setToDefault();
}

API_EXPORT bool NxForceFieldShapeDesc_isValid(NxForceFieldShapeDesc* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxForceFieldShapeDesc::isValid() : classPointer->isValid();
}

API_EXPORT NxShapeType NxForceFieldShapeDesc_getType(NxForceFieldShapeDesc* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxForceFieldShapeDesc::getType() : classPointer->getType();
}

API_EXPORT NxForceFieldShapeDesc* new_NxForceFieldShapeDesc(bool do_override, NxShapeType type)
{
    return (do_override) ? new NxForceFieldShapeDesc_doxybind(type) : NULL;
}

API_EXPORT void set_NxBoxForceFieldShapeDesc_dimensions(NxBoxForceFieldShapeDesc* classPointer, NxVec3 newvalue)
{
    classPointer->dimensions = newvalue;
}

API_EXPORT NxVec3 get_NxBoxForceFieldShapeDesc_dimensions(NxBoxForceFieldShapeDesc* classPointer)
{
    return classPointer->dimensions;
}

API_EXPORT NxBoxForceFieldShapeDesc* new_NxBoxForceFieldShapeDesc(bool do_override)
{
    return (do_override) ? new NxBoxForceFieldShapeDesc_doxybind() : new NxBoxForceFieldShapeDesc();
}

API_EXPORT void NxBoxForceFieldShapeDesc_setToDefault(NxBoxForceFieldShapeDesc* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxBoxForceFieldShapeDesc::setToDefault() : classPointer->setToDefault();
}

API_EXPORT bool NxBoxForceFieldShapeDesc_isValid(NxBoxForceFieldShapeDesc* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxBoxForceFieldShapeDesc::isValid() : classPointer->isValid();
}

API_EXPORT void NxShape_setLocalPose(NxShape* classPointer, bool call_explicit, NxMat34& mat)
{
    classPointer->setLocalPose(mat);
}

API_EXPORT void NxShape_setLocalPosition(NxShape* classPointer, bool call_explicit, NxVec3& vec)
{
    classPointer->setLocalPosition(vec);
}

API_EXPORT void NxShape_setLocalOrientation(NxShape* classPointer, bool call_explicit, NxMat33& mat)
{
    classPointer->setLocalOrientation(mat);
}

API_EXPORT NxMat34 NxShape_getLocalPose(NxShape* classPointer, bool call_explicit)
{
    return classPointer->getLocalPose();
}

API_EXPORT NxVec3 NxShape_getLocalPosition(NxShape* classPointer, bool call_explicit)
{
    return classPointer->getLocalPosition();
}

API_EXPORT NxMat33 NxShape_getLocalOrientation(NxShape* classPointer, bool call_explicit)
{
    return classPointer->getLocalOrientation();
}

API_EXPORT void NxShape_setGlobalPose(NxShape* classPointer, bool call_explicit, NxMat34& mat)
{
    classPointer->setGlobalPose(mat);
}

API_EXPORT void NxShape_setGlobalPosition(NxShape* classPointer, bool call_explicit, NxVec3& vec)
{
    classPointer->setGlobalPosition(vec);
}

API_EXPORT void NxShape_setGlobalOrientation(NxShape* classPointer, bool call_explicit, NxMat33& mat)
{
    classPointer->setGlobalOrientation(mat);
}

API_EXPORT NxMat34 NxShape_getGlobalPose(NxShape* classPointer, bool call_explicit)
{
    return classPointer->getGlobalPose();
}

API_EXPORT NxVec3 NxShape_getGlobalPosition(NxShape* classPointer, bool call_explicit)
{
    return classPointer->getGlobalPosition();
}

API_EXPORT NxMat33 NxShape_getGlobalOrientation(NxShape* classPointer, bool call_explicit)
{
    return classPointer->getGlobalOrientation();
}

API_EXPORT void* NxShape_is(NxShape* classPointer, bool call_explicit, NxShapeType type)
{
    return classPointer->is(type);
}

API_EXPORT const void* NxShape_is_1(NxShape* classPointer, bool call_explicit, NxShapeType type)
{
    return classPointer->is(type);
}

API_EXPORT NxPlaneShape* NxShape_isPlane(NxShape* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxShape::isPlane() : classPointer->isPlane();
}

API_EXPORT const NxPlaneShape* NxShape_isPlane_1(NxShape* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxShape::isPlane() : classPointer->isPlane();
}

API_EXPORT NxSphereShape* NxShape_isSphere(NxShape* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxShape::isSphere() : classPointer->isSphere();
}

API_EXPORT const NxSphereShape* NxShape_isSphere_1(NxShape* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxShape::isSphere() : classPointer->isSphere();
}

API_EXPORT NxBoxShape* NxShape_isBox(NxShape* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxShape::isBox() : classPointer->isBox();
}

API_EXPORT const NxBoxShape* NxShape_isBox_1(NxShape* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxShape::isBox() : classPointer->isBox();
}

API_EXPORT NxCapsuleShape* NxShape_isCapsule(NxShape* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxShape::isCapsule() : classPointer->isCapsule();
}

API_EXPORT const NxCapsuleShape* NxShape_isCapsule_1(NxShape* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxShape::isCapsule() : classPointer->isCapsule();
}

API_EXPORT NxWheelShape* NxShape_isWheel(NxShape* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxShape::isWheel() : classPointer->isWheel();
}

API_EXPORT const NxWheelShape* NxShape_isWheel_1(NxShape* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxShape::isWheel() : classPointer->isWheel();
}

API_EXPORT NxConvexShape* NxShape_isConvexMesh(NxShape* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxShape::isConvexMesh() : classPointer->isConvexMesh();
}

API_EXPORT const NxConvexShape* NxShape_isConvexMesh_1(NxShape* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxShape::isConvexMesh() : classPointer->isConvexMesh();
}

API_EXPORT NxTriangleMeshShape* NxShape_isTriangleMesh(NxShape* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxShape::isTriangleMesh() : classPointer->isTriangleMesh();
}

API_EXPORT const NxTriangleMeshShape* NxShape_isTriangleMesh_1(NxShape* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxShape::isTriangleMesh() : classPointer->isTriangleMesh();
}

API_EXPORT NxHeightFieldShape* NxShape_isHeightField(NxShape* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxShape::isHeightField() : classPointer->isHeightField();
}

API_EXPORT const NxHeightFieldShape* NxShape_isHeightField_1(NxShape* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxShape::isHeightField() : classPointer->isHeightField();
}

API_EXPORT bool NxShape_raycast(NxShape* classPointer, bool call_explicit, NxRay* worldRay, NxReal maxDist, NxU32 hintFlags, NxRaycastHit* hit, bool firstHit)
{
    return classPointer->raycast(*worldRay, maxDist, hintFlags, *hit, firstHit);
}

API_EXPORT bool NxShape_checkOverlapSphere(NxShape* classPointer, bool call_explicit, NxSphere* worldSphere)
{
    return classPointer->checkOverlapSphere(*worldSphere);
}

API_EXPORT bool NxShape_checkOverlapOBB(NxShape* classPointer, bool call_explicit, NxBox* worldBox)
{
    return classPointer->checkOverlapOBB(*worldBox);
}

API_EXPORT bool NxShape_checkOverlapAABB(NxShape* classPointer, bool call_explicit, NxBounds3* worldBounds)
{
    return classPointer->checkOverlapAABB(*worldBounds);
}

API_EXPORT bool NxShape_checkOverlapCapsule(NxShape* classPointer, bool call_explicit, NxCapsule* worldCapsule)
{
    return classPointer->checkOverlapCapsule(*worldCapsule);
}

API_EXPORT void set_NxShape_userData(NxShape* classPointer, void* newvalue)
{
    classPointer->userData = newvalue;
}

API_EXPORT void* get_NxShape_userData(NxShape* classPointer)
{
    return classPointer->userData;
}

API_EXPORT void set_NxShape_appData(NxShape* classPointer, void* newvalue)
{
    classPointer->appData = newvalue;
}

API_EXPORT void* get_NxShape_appData(NxShape* classPointer)
{
    return classPointer->appData;
}

API_EXPORT NxShape* new_NxShape(bool do_override)
{
    return (do_override) ? new NxShape_doxybind() : NULL;
}

API_EXPORT NxActor* NxShape_getActor(NxShape* classPointer, bool call_explicit)
{
    return &classPointer->getActor();
}

API_EXPORT void NxShape_setGroup(NxShape* classPointer, bool call_explicit, NxCollisionGroup collisionGroup)
{
    classPointer->setGroup(collisionGroup);
}

API_EXPORT NxCollisionGroup NxShape_getGroup(NxShape* classPointer, bool call_explicit)
{
    return classPointer->getGroup();
}

API_EXPORT void NxShape_getWorldBounds(NxShape* classPointer, bool call_explicit, NxBounds3* dest)
{
    classPointer->getWorldBounds(*dest);
}

API_EXPORT void NxShape_setFlag(NxShape* classPointer, bool call_explicit, NxShapeFlag flag, bool value)
{
    classPointer->setFlag(flag, value);
}

API_EXPORT NX_BOOL NxShape_getFlag(NxShape* classPointer, bool call_explicit, NxShapeFlag flag)
{
    return classPointer->getFlag(flag);
}

API_EXPORT void NxShape_setMaterial(NxShape* classPointer, bool call_explicit, NxMaterialIndex matIndex)
{
    classPointer->setMaterial(matIndex);
}

API_EXPORT NxMaterialIndex NxShape_getMaterial(NxShape* classPointer, bool call_explicit)
{
    return classPointer->getMaterial();
}

API_EXPORT void NxShape_setSkinWidth(NxShape* classPointer, bool call_explicit, NxReal skinWidth)
{
    classPointer->setSkinWidth(skinWidth);
}

API_EXPORT NxReal NxShape_getSkinWidth(NxShape* classPointer, bool call_explicit)
{
    return classPointer->getSkinWidth();
}

API_EXPORT NxShapeType NxShape_getType(NxShape* classPointer, bool call_explicit)
{
    return classPointer->getType();
}

API_EXPORT void NxShape_setCCDSkeleton(NxShape* classPointer, bool call_explicit, NxCCDSkeleton* ccdSkel)
{
    classPointer->setCCDSkeleton(ccdSkel);
}

API_EXPORT NxCCDSkeleton* NxShape_getCCDSkeleton(NxShape* classPointer, bool call_explicit)
{
    return classPointer->getCCDSkeleton();
}

API_EXPORT void NxShape_setName(NxShape* classPointer, bool call_explicit, char* name)
{
    classPointer->setName(name);
}

API_EXPORT const char* NxShape_getName(NxShape* classPointer, bool call_explicit)
{
    return classPointer->getName();
}

API_EXPORT void NxShape_setGroupsMask(NxShape* classPointer, bool call_explicit, NxGroupsMask* mask)
{
    classPointer->setGroupsMask(*mask);
}

API_EXPORT const NxGroupsMask* NxShape_getGroupsMask(NxShape* classPointer, bool call_explicit)
{
    return &classPointer->getGroupsMask();
}

API_EXPORT NxU32 NxShape_getNonInteractingCompartmentTypes(NxShape* classPointer, bool call_explicit)
{
    return classPointer->getNonInteractingCompartmentTypes();
}

API_EXPORT void NxShape_setNonInteractingCompartmentTypes(NxShape* classPointer, bool call_explicit, NxU32 compartmentTypes)
{
    classPointer->setNonInteractingCompartmentTypes(compartmentTypes);
}

API_EXPORT void NxBoxShape_setDimensions(NxBoxShape* classPointer, bool call_explicit, NxVec3& vec)
{
    classPointer->setDimensions(vec);
}

API_EXPORT NxVec3 NxBoxShape_getDimensions(NxBoxShape* classPointer, bool call_explicit)
{
    return classPointer->getDimensions();
}

API_EXPORT void NxBoxShape_getWorldOBB(NxBoxShape* classPointer, bool call_explicit, NxBox* obb)
{
    classPointer->getWorldOBB(*obb);
}

API_EXPORT void NxBoxShape_saveToDesc(NxBoxShape* classPointer, bool call_explicit, NxBoxShapeDesc* desc)
{
    classPointer->saveToDesc(*desc);
}

API_EXPORT void set_NxShapeDesc_localPose(NxShapeDesc* classPointer, NxMat34 newvalue)
{
    classPointer->localPose = newvalue;
}

API_EXPORT NxMat34 get_NxShapeDesc_localPose(NxShapeDesc* classPointer)
{
    return classPointer->localPose;
}

API_EXPORT void set_NxShapeDesc_shapeFlags(NxShapeDesc* classPointer, NxU32 newvalue)
{
    classPointer->shapeFlags = newvalue;
}

API_EXPORT NxU32 get_NxShapeDesc_shapeFlags(NxShapeDesc* classPointer)
{
    return classPointer->shapeFlags;
}

API_EXPORT void set_NxShapeDesc_group(NxShapeDesc* classPointer, NxCollisionGroup newvalue)
{
    classPointer->group = newvalue;
}

API_EXPORT NxCollisionGroup get_NxShapeDesc_group(NxShapeDesc* classPointer)
{
    return classPointer->group;
}

API_EXPORT void set_NxShapeDesc_materialIndex(NxShapeDesc* classPointer, NxMaterialIndex newvalue)
{
    classPointer->materialIndex = newvalue;
}

API_EXPORT NxMaterialIndex get_NxShapeDesc_materialIndex(NxShapeDesc* classPointer)
{
    return classPointer->materialIndex;
}

API_EXPORT void set_NxShapeDesc_ccdSkeleton(NxShapeDesc* classPointer, NxCCDSkeleton* newvalue)
{
    classPointer->ccdSkeleton = newvalue;
}

API_EXPORT NxCCDSkeleton* get_NxShapeDesc_ccdSkeleton(NxShapeDesc* classPointer)
{
    return classPointer->ccdSkeleton;
}

API_EXPORT void set_NxShapeDesc_density(NxShapeDesc* classPointer, NxReal newvalue)
{
    classPointer->density = newvalue;
}

API_EXPORT NxReal get_NxShapeDesc_density(NxShapeDesc* classPointer)
{
    return classPointer->density;
}

API_EXPORT void set_NxShapeDesc_mass(NxShapeDesc* classPointer, NxReal newvalue)
{
    classPointer->mass = newvalue;
}

API_EXPORT NxReal get_NxShapeDesc_mass(NxShapeDesc* classPointer)
{
    return classPointer->mass;
}

API_EXPORT void set_NxShapeDesc_skinWidth(NxShapeDesc* classPointer, NxReal newvalue)
{
    classPointer->skinWidth = newvalue;
}

API_EXPORT NxReal get_NxShapeDesc_skinWidth(NxShapeDesc* classPointer)
{
    return classPointer->skinWidth;
}

API_EXPORT void set_NxShapeDesc_userData(NxShapeDesc* classPointer, void* newvalue)
{
    classPointer->userData = newvalue;
}

API_EXPORT void* get_NxShapeDesc_userData(NxShapeDesc* classPointer)
{
    return classPointer->userData;
}

API_EXPORT void set_NxShapeDesc_name(NxShapeDesc* classPointer, const char* newvalue)
{
    classPointer->name = newvalue;
}

API_EXPORT const char* get_NxShapeDesc_name(NxShapeDesc* classPointer)
{
    return classPointer->name;
}

API_EXPORT void set_NxShapeDesc_groupsMask(NxShapeDesc* classPointer, NxGroupsMask* newvalue)
{
    classPointer->groupsMask = *newvalue;
}

API_EXPORT NxGroupsMask* get_NxShapeDesc_groupsMask(NxShapeDesc* classPointer)
{
    return &classPointer->groupsMask;
}

API_EXPORT void set_NxShapeDesc_nonInteractingCompartmentTypes(NxShapeDesc* classPointer, NxU32 newvalue)
{
    classPointer->nonInteractingCompartmentTypes = newvalue;
}

API_EXPORT NxU32 get_NxShapeDesc_nonInteractingCompartmentTypes(NxShapeDesc* classPointer)
{
    return classPointer->nonInteractingCompartmentTypes;
}

API_EXPORT void NxShapeDesc_setToDefault(NxShapeDesc* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxShapeDesc::setToDefault() : classPointer->setToDefault();
}

API_EXPORT bool NxShapeDesc_isValid(NxShapeDesc* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxShapeDesc::isValid() : classPointer->isValid();
}

API_EXPORT NxShapeType NxShapeDesc_getType(NxShapeDesc* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxShapeDesc::getType() : classPointer->getType();
}

API_EXPORT NxShapeDesc* new_NxShapeDesc(bool do_override, NxShapeType shapeType)
{
    return (do_override) ? new NxShapeDesc_doxybind(shapeType) : NULL;
}

API_EXPORT void set_NxBoxShapeDesc_dimensions(NxBoxShapeDesc* classPointer, NxVec3 newvalue)
{
    classPointer->dimensions = newvalue;
}

API_EXPORT NxVec3 get_NxBoxShapeDesc_dimensions(NxBoxShapeDesc* classPointer)
{
    return classPointer->dimensions;
}

API_EXPORT NxBoxShapeDesc* new_NxBoxShapeDesc(bool do_override)
{
    return (do_override) ? new NxBoxShapeDesc_doxybind() : new NxBoxShapeDesc();
}

API_EXPORT void NxBoxShapeDesc_setToDefault(NxBoxShapeDesc* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxBoxShapeDesc::setToDefault() : classPointer->setToDefault();
}

API_EXPORT bool NxBoxShapeDesc_isValid(NxBoxShapeDesc* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxBoxShapeDesc::isValid() : classPointer->isValid();
}

API_EXPORT void set_NxSegment_p0(NxSegment* classPointer, NxVec3 newvalue)
{
    classPointer->p0 = newvalue;
}

API_EXPORT NxVec3 get_NxSegment_p0(NxSegment* classPointer)
{
    return classPointer->p0;
}

API_EXPORT void set_NxSegment_p1(NxSegment* classPointer, NxVec3 newvalue)
{
    classPointer->p1 = newvalue;
}

API_EXPORT NxVec3 get_NxSegment_p1(NxSegment* classPointer)
{
    return classPointer->p1;
}

API_EXPORT NxSegment* new_NxSegment(bool do_override)
{
    return new NxSegment();
}

API_EXPORT NxSegment* new_NxSegment_1(bool do_override, NxVec3& _p0, NxVec3& _p1)
{
    return new NxSegment(_p0, _p1);
}

API_EXPORT NxSegment* new_NxSegment_2(bool do_override, NxSegment* seg)
{
    return new NxSegment(*seg);
}

API_EXPORT const NxVec3* NxSegment_getOrigin(NxSegment* classPointer, bool call_explicit)
{
    return (call_explicit) ? &classPointer->NxSegment::getOrigin() : &classPointer->getOrigin();
}

API_EXPORT NxVec3 NxSegment_computeDirection(NxSegment* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxSegment::computeDirection() : classPointer->computeDirection();
}

API_EXPORT void NxSegment_computeDirection_1(NxSegment* classPointer, bool call_explicit, NxVec3& dir)
{
    (call_explicit) ? classPointer->NxSegment::computeDirection(dir) : classPointer->computeDirection(dir);
}

API_EXPORT NxF32 NxSegment_computeLength(NxSegment* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxSegment::computeLength() : classPointer->computeLength();
}

API_EXPORT NxF32 NxSegment_computeSquareLength(NxSegment* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxSegment::computeSquareLength() : classPointer->computeSquareLength();
}

API_EXPORT void NxSegment_setOriginDirection(NxSegment* classPointer, bool call_explicit, NxVec3& origin, NxVec3& direction)
{
    (call_explicit) ? classPointer->NxSegment::setOriginDirection(origin, direction) : classPointer->setOriginDirection(origin, direction);
}

API_EXPORT void NxSegment_computePoint(NxSegment* classPointer, bool call_explicit, NxVec3& pt, NxF32 t)
{
    (call_explicit) ? classPointer->NxSegment::computePoint(pt, t) : classPointer->computePoint(pt, t);
}

API_EXPORT void set_NxCapsule_radius(NxCapsule* classPointer, NxF32 newvalue)
{
    classPointer->radius = newvalue;
}

API_EXPORT NxF32 get_NxCapsule_radius(NxCapsule* classPointer)
{
    return classPointer->radius;
}

API_EXPORT NxCapsule* new_NxCapsule(bool do_override)
{
    return new NxCapsule();
}

API_EXPORT NxCapsule* new_NxCapsule_1(bool do_override, NxSegment* seg, NxF32 _radius)
{
    return new NxCapsule(*seg, _radius);
}

API_EXPORT NxCapsuleController* new_NxCapsuleController(bool do_override)
{
    return (do_override) ? new NxCapsuleController_doxybind() : NULL;
}

API_EXPORT NxF32 NxCapsuleController_getRadius(NxCapsuleController* classPointer, bool call_explicit)
{
    return classPointer->getRadius();
}

API_EXPORT bool NxCapsuleController_setRadius(NxCapsuleController* classPointer, bool call_explicit, NxF32 radius)
{
    return classPointer->setRadius(radius);
}

API_EXPORT NxF32 NxCapsuleController_getHeight(NxCapsuleController* classPointer, bool call_explicit)
{
    return classPointer->getHeight();
}

API_EXPORT NxCapsuleClimbingMode NxCapsuleController_getClimbingMode(NxCapsuleController* classPointer, bool call_explicit)
{
    return classPointer->getClimbingMode();
}

API_EXPORT bool NxCapsuleController_setHeight(NxCapsuleController* classPointer, bool call_explicit, NxF32 height)
{
    return classPointer->setHeight(height);
}

API_EXPORT void NxCapsuleController_setStepOffset(NxCapsuleController* classPointer, bool call_explicit, float offset)
{
    classPointer->setStepOffset(offset);
}

API_EXPORT bool NxCapsuleController_setClimbingMode(NxCapsuleController* classPointer, bool call_explicit, NxCapsuleClimbingMode mode)
{
    return classPointer->setClimbingMode(mode);
}

API_EXPORT void NxCapsuleController_reportSceneChanged(NxCapsuleController* classPointer, bool call_explicit)
{
    classPointer->reportSceneChanged();
}

API_EXPORT void set_NxCapsuleControllerDesc_radius(NxCapsuleControllerDesc* classPointer, NxF32 newvalue)
{
    classPointer->radius = newvalue;
}

API_EXPORT NxF32 get_NxCapsuleControllerDesc_radius(NxCapsuleControllerDesc* classPointer)
{
    return classPointer->radius;
}

API_EXPORT void set_NxCapsuleControllerDesc_height(NxCapsuleControllerDesc* classPointer, NxF32 newvalue)
{
    classPointer->height = newvalue;
}

API_EXPORT NxF32 get_NxCapsuleControllerDesc_height(NxCapsuleControllerDesc* classPointer)
{
    return classPointer->height;
}

API_EXPORT void set_NxCapsuleControllerDesc_climbingMode(NxCapsuleControllerDesc* classPointer, NxCapsuleClimbingMode newvalue)
{
    classPointer->climbingMode = newvalue;
}

API_EXPORT NxCapsuleClimbingMode get_NxCapsuleControllerDesc_climbingMode(NxCapsuleControllerDesc* classPointer)
{
    return classPointer->climbingMode;
}

API_EXPORT NxCapsuleControllerDesc* new_NxCapsuleControllerDesc(bool do_override)
{
    return (do_override) ? new NxCapsuleControllerDesc_doxybind() : new NxCapsuleControllerDesc();
}

API_EXPORT void NxCapsuleControllerDesc_setToDefault(NxCapsuleControllerDesc* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxCapsuleControllerDesc::setToDefault() : classPointer->setToDefault();
}

API_EXPORT bool NxCapsuleControllerDesc_isValid(NxCapsuleControllerDesc* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxCapsuleControllerDesc::isValid() : classPointer->isValid();
}

API_EXPORT void NxCapsuleForceFieldShape_setDimensions(NxCapsuleForceFieldShape* classPointer, bool call_explicit, NxReal radius, NxReal height)
{
    classPointer->setDimensions(radius, height);
}

API_EXPORT void NxCapsuleForceFieldShape_setRadius(NxCapsuleForceFieldShape* classPointer, bool call_explicit, NxReal radius)
{
    classPointer->setRadius(radius);
}

API_EXPORT NxReal NxCapsuleForceFieldShape_getRadius(NxCapsuleForceFieldShape* classPointer, bool call_explicit)
{
    return classPointer->getRadius();
}

API_EXPORT void NxCapsuleForceFieldShape_setHeight(NxCapsuleForceFieldShape* classPointer, bool call_explicit, NxReal height)
{
    classPointer->setHeight(height);
}

API_EXPORT NxReal NxCapsuleForceFieldShape_getHeight(NxCapsuleForceFieldShape* classPointer, bool call_explicit)
{
    return classPointer->getHeight();
}

API_EXPORT void NxCapsuleForceFieldShape_saveToDesc(NxCapsuleForceFieldShape* classPointer, bool call_explicit, NxCapsuleForceFieldShapeDesc* desc)
{
    classPointer->saveToDesc(*desc);
}

API_EXPORT void set_NxCapsuleForceFieldShapeDesc_radius(NxCapsuleForceFieldShapeDesc* classPointer, NxReal newvalue)
{
    classPointer->radius = newvalue;
}

API_EXPORT NxReal get_NxCapsuleForceFieldShapeDesc_radius(NxCapsuleForceFieldShapeDesc* classPointer)
{
    return classPointer->radius;
}

API_EXPORT void set_NxCapsuleForceFieldShapeDesc_height(NxCapsuleForceFieldShapeDesc* classPointer, NxReal newvalue)
{
    classPointer->height = newvalue;
}

API_EXPORT NxReal get_NxCapsuleForceFieldShapeDesc_height(NxCapsuleForceFieldShapeDesc* classPointer)
{
    return classPointer->height;
}

API_EXPORT NxCapsuleForceFieldShapeDesc* new_NxCapsuleForceFieldShapeDesc(bool do_override)
{
    return (do_override) ? new NxCapsuleForceFieldShapeDesc_doxybind() : new NxCapsuleForceFieldShapeDesc();
}

API_EXPORT void NxCapsuleForceFieldShapeDesc_setToDefault(NxCapsuleForceFieldShapeDesc* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxCapsuleForceFieldShapeDesc::setToDefault() : classPointer->setToDefault();
}

API_EXPORT bool NxCapsuleForceFieldShapeDesc_isValid(NxCapsuleForceFieldShapeDesc* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxCapsuleForceFieldShapeDesc::isValid() : classPointer->isValid();
}

API_EXPORT void NxCapsuleShape_setDimensions(NxCapsuleShape* classPointer, bool call_explicit, NxReal radius, NxReal height)
{
    classPointer->setDimensions(radius, height);
}

API_EXPORT void NxCapsuleShape_setRadius(NxCapsuleShape* classPointer, bool call_explicit, NxReal radius)
{
    classPointer->setRadius(radius);
}

API_EXPORT NxReal NxCapsuleShape_getRadius(NxCapsuleShape* classPointer, bool call_explicit)
{
    return classPointer->getRadius();
}

API_EXPORT void NxCapsuleShape_setHeight(NxCapsuleShape* classPointer, bool call_explicit, NxReal height)
{
    classPointer->setHeight(height);
}

API_EXPORT NxReal NxCapsuleShape_getHeight(NxCapsuleShape* classPointer, bool call_explicit)
{
    return classPointer->getHeight();
}

API_EXPORT void NxCapsuleShape_getWorldCapsule(NxCapsuleShape* classPointer, bool call_explicit, NxCapsule* worldCapsule)
{
    classPointer->getWorldCapsule(*worldCapsule);
}

API_EXPORT void NxCapsuleShape_saveToDesc(NxCapsuleShape* classPointer, bool call_explicit, NxCapsuleShapeDesc* desc)
{
    classPointer->saveToDesc(*desc);
}

API_EXPORT void set_NxCapsuleShapeDesc_radius(NxCapsuleShapeDesc* classPointer, NxReal newvalue)
{
    classPointer->radius = newvalue;
}

API_EXPORT NxReal get_NxCapsuleShapeDesc_radius(NxCapsuleShapeDesc* classPointer)
{
    return classPointer->radius;
}

API_EXPORT void set_NxCapsuleShapeDesc_height(NxCapsuleShapeDesc* classPointer, NxReal newvalue)
{
    classPointer->height = newvalue;
}

API_EXPORT NxReal get_NxCapsuleShapeDesc_height(NxCapsuleShapeDesc* classPointer)
{
    return classPointer->height;
}

API_EXPORT void set_NxCapsuleShapeDesc_flags(NxCapsuleShapeDesc* classPointer, NxU32 newvalue)
{
    classPointer->flags = newvalue;
}

API_EXPORT NxU32 get_NxCapsuleShapeDesc_flags(NxCapsuleShapeDesc* classPointer)
{
    return classPointer->flags;
}

API_EXPORT NxCapsuleShapeDesc* new_NxCapsuleShapeDesc(bool do_override)
{
    return (do_override) ? new NxCapsuleShapeDesc_doxybind() : new NxCapsuleShapeDesc();
}

API_EXPORT void NxCapsuleShapeDesc_setToDefault(NxCapsuleShapeDesc* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxCapsuleShapeDesc::setToDefault() : classPointer->setToDefault();
}

API_EXPORT bool NxCapsuleShapeDesc_isValid(NxCapsuleShapeDesc* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxCapsuleShapeDesc::isValid() : classPointer->isValid();
}

API_EXPORT NxU32 NxCCDSkeleton_save(NxCCDSkeleton* classPointer, bool call_explicit, void* destBuffer, NxU32 bufferSize)
{
    return classPointer->save(destBuffer, bufferSize);
}

API_EXPORT NxU32 NxCCDSkeleton_getDataSize(NxCCDSkeleton* classPointer, bool call_explicit)
{
    return classPointer->getDataSize();
}

API_EXPORT NxU32 NxCCDSkeleton_getReferenceCount(NxCCDSkeleton* classPointer, bool call_explicit)
{
    return classPointer->getReferenceCount();
}

API_EXPORT NxU32 NxCCDSkeleton_saveToDesc(NxCCDSkeleton* classPointer, bool call_explicit, NxSimpleTriangleMesh* desc)
{
    return classPointer->saveToDesc(*desc);
}

API_EXPORT void set_NxCloth_userData(NxCloth* classPointer, void* newvalue)
{
    classPointer->userData = newvalue;
}

API_EXPORT void* get_NxCloth_userData(NxCloth* classPointer)
{
    return classPointer->userData;
}

API_EXPORT NxCloth* new_NxCloth(bool do_override)
{
    return (do_override) ? new NxCloth_doxybind() : NULL;
}

API_EXPORT bool NxCloth_saveToDesc(NxCloth* classPointer, bool call_explicit, NxClothDesc* desc)
{
    return classPointer->saveToDesc(*desc);
}

API_EXPORT NxClothMesh* NxCloth_getClothMesh(NxCloth* classPointer, bool call_explicit)
{
    return classPointer->getClothMesh();
}

API_EXPORT void NxCloth_setBendingStiffness(NxCloth* classPointer, bool call_explicit, NxReal stiffness)
{
    classPointer->setBendingStiffness(stiffness);
}

API_EXPORT NxReal NxCloth_getBendingStiffness(NxCloth* classPointer, bool call_explicit)
{
    return classPointer->getBendingStiffness();
}

API_EXPORT void NxCloth_setStretchingStiffness(NxCloth* classPointer, bool call_explicit, NxReal stiffness)
{
    classPointer->setStretchingStiffness(stiffness);
}

API_EXPORT NxReal NxCloth_getStretchingStiffness(NxCloth* classPointer, bool call_explicit)
{
    return classPointer->getStretchingStiffness();
}

API_EXPORT void NxCloth_setDampingCoefficient(NxCloth* classPointer, bool call_explicit, NxReal dampingCoefficient)
{
    classPointer->setDampingCoefficient(dampingCoefficient);
}

API_EXPORT NxReal NxCloth_getDampingCoefficient(NxCloth* classPointer, bool call_explicit)
{
    return classPointer->getDampingCoefficient();
}

API_EXPORT void NxCloth_setFriction(NxCloth* classPointer, bool call_explicit, NxReal friction)
{
    classPointer->setFriction(friction);
}

API_EXPORT NxReal NxCloth_getFriction(NxCloth* classPointer, bool call_explicit)
{
    return classPointer->getFriction();
}

API_EXPORT void NxCloth_setPressure(NxCloth* classPointer, bool call_explicit, NxReal pressure)
{
    classPointer->setPressure(pressure);
}

API_EXPORT NxReal NxCloth_getPressure(NxCloth* classPointer, bool call_explicit)
{
    return classPointer->getPressure();
}

API_EXPORT void NxCloth_setTearFactor(NxCloth* classPointer, bool call_explicit, NxReal factor)
{
    classPointer->setTearFactor(factor);
}

API_EXPORT NxReal NxCloth_getTearFactor(NxCloth* classPointer, bool call_explicit)
{
    return classPointer->getTearFactor();
}

API_EXPORT void NxCloth_setAttachmentTearFactor(NxCloth* classPointer, bool call_explicit, NxReal factor)
{
    classPointer->setAttachmentTearFactor(factor);
}

API_EXPORT NxReal NxCloth_getAttachmentTearFactor(NxCloth* classPointer, bool call_explicit)
{
    return classPointer->getAttachmentTearFactor();
}

API_EXPORT void NxCloth_setThickness(NxCloth* classPointer, bool call_explicit, NxReal thickness)
{
    classPointer->setThickness(thickness);
}

API_EXPORT NxReal NxCloth_getThickness(NxCloth* classPointer, bool call_explicit)
{
    return classPointer->getThickness();
}

API_EXPORT NxReal NxCloth_getDensity(NxCloth* classPointer, bool call_explicit)
{
    return classPointer->getDensity();
}

API_EXPORT NxReal NxCloth_getRelativeGridSpacing(NxCloth* classPointer, bool call_explicit)
{
    return classPointer->getRelativeGridSpacing();
}

API_EXPORT NxU32 NxCloth_getSolverIterations(NxCloth* classPointer, bool call_explicit)
{
    return classPointer->getSolverIterations();
}

API_EXPORT void NxCloth_setSolverIterations(NxCloth* classPointer, bool call_explicit, NxU32 iterations)
{
    classPointer->setSolverIterations(iterations);
}

API_EXPORT void NxCloth_getWorldBounds(NxCloth* classPointer, bool call_explicit, NxBounds3* bounds)
{
    classPointer->getWorldBounds(*bounds);
}

API_EXPORT void NxCloth_attachToShape(NxCloth* classPointer, bool call_explicit, NxShape* shape, NxU32 attachmentFlags)
{
    classPointer->attachToShape(shape, attachmentFlags);
}

API_EXPORT void NxCloth_attachToCollidingShapes(NxCloth* classPointer, bool call_explicit, NxU32 attachmentFlags)
{
    classPointer->attachToCollidingShapes(attachmentFlags);
}

API_EXPORT void NxCloth_detachFromShape(NxCloth* classPointer, bool call_explicit, NxShape* shape)
{
    classPointer->detachFromShape(shape);
}

API_EXPORT void NxCloth_attachVertexToShape(NxCloth* classPointer, bool call_explicit, NxU32 vertexId, NxShape* shape, NxVec3& localPos, NxU32 attachmentFlags)
{
    classPointer->attachVertexToShape(vertexId, shape, localPos, attachmentFlags);
}

API_EXPORT void NxCloth_attachVertexToGlobalPosition(NxCloth* classPointer, bool call_explicit, NxU32 vertexId, NxVec3& pos)
{
    classPointer->attachVertexToGlobalPosition(vertexId, pos);
}

API_EXPORT void NxCloth_freeVertex(NxCloth* classPointer, bool call_explicit, NxU32 vertexId)
{
    classPointer->freeVertex(vertexId);
}

API_EXPORT void NxCloth_dominateVertex(NxCloth* classPointer, bool call_explicit, NxU32 vertexId, NxReal expirationTime, NxReal dominanceWeight)
{
    classPointer->dominateVertex(vertexId, expirationTime, dominanceWeight);
}

API_EXPORT NxClothVertexAttachmentStatus NxCloth_getVertexAttachmentStatus(NxCloth* classPointer, bool call_explicit, NxU32 vertexId)
{
    return classPointer->getVertexAttachmentStatus(vertexId);
}

API_EXPORT NxShape* NxCloth_getVertexAttachmentShape(NxCloth* classPointer, bool call_explicit, NxU32 vertexId)
{
    return classPointer->getVertexAttachmentShape(vertexId);
}

API_EXPORT NxVec3 NxCloth_getVertexAttachmentPosition(NxCloth* classPointer, bool call_explicit, NxU32 vertexId)
{
    return classPointer->getVertexAttachmentPosition(vertexId);
}

API_EXPORT void NxCloth_attachToCore(NxCloth* classPointer, bool call_explicit, NxActor* actor, NxReal impulseThreshold, NxReal penetrationDepth, NxReal maxDeformationDistance)
{
    classPointer->attachToCore(actor, impulseThreshold, penetrationDepth, maxDeformationDistance);
}

API_EXPORT void NxCloth_attachToCore_1(NxCloth* classPointer, bool call_explicit, NxActor* actor, NxReal impulseThreshold, NxReal penetrationDepth)
{
    classPointer->attachToCore(actor, impulseThreshold, penetrationDepth);
}

API_EXPORT void NxCloth_attachToCore_2(NxCloth* classPointer, bool call_explicit, NxActor* actor, NxReal impulseThreshold)
{
    classPointer->attachToCore(actor, impulseThreshold);
}

API_EXPORT bool NxCloth_tearVertex(NxCloth* classPointer, bool call_explicit, NxU32 vertexId, NxVec3& normal)
{
    return classPointer->tearVertex(vertexId, normal);
}

API_EXPORT bool NxCloth_raycast(NxCloth* classPointer, bool call_explicit, NxRay* worldRay, NxVec3& hit, NxU32& vertexId)
{
    return classPointer->raycast(*worldRay, hit, vertexId);
}

API_EXPORT void NxCloth_setGroup(NxCloth* classPointer, bool call_explicit, NxCollisionGroup collisionGroup)
{
    classPointer->setGroup(collisionGroup);
}

API_EXPORT NxCollisionGroup NxCloth_getGroup(NxCloth* classPointer, bool call_explicit)
{
    return classPointer->getGroup();
}

API_EXPORT void NxCloth_setGroupsMask(NxCloth* classPointer, bool call_explicit, NxGroupsMask* groupsMask)
{
    classPointer->setGroupsMask(*groupsMask);
}

API_EXPORT const NxGroupsMask* NxCloth_getGroupsMask(NxCloth* classPointer, bool call_explicit)
{
    return &classPointer->getGroupsMask();
}

API_EXPORT void NxCloth_setMeshData(NxCloth* classPointer, bool call_explicit, NxMeshData* meshData)
{
    classPointer->setMeshData(*meshData);
}

API_EXPORT NxMeshData* NxCloth_getMeshData(NxCloth* classPointer, bool call_explicit)
{
    return &classPointer->getMeshData();
}

API_EXPORT void NxCloth_setValidBounds(NxCloth* classPointer, bool call_explicit, NxBounds3* validBounds)
{
    classPointer->setValidBounds(*validBounds);
}

API_EXPORT void NxCloth_getValidBounds(NxCloth* classPointer, bool call_explicit, NxBounds3* validBounds)
{
    classPointer->getValidBounds(*validBounds);
}

API_EXPORT void NxCloth_setPosition(NxCloth* classPointer, bool call_explicit, NxVec3& position, NxU32 vertexId)
{
    classPointer->setPosition(position, vertexId);
}

API_EXPORT void NxCloth_setPositions(NxCloth* classPointer, bool call_explicit, void* buffer, NxU32 byteStride)
{
    classPointer->setPositions(buffer, byteStride);
}

API_EXPORT void NxCloth_setPositions_1(NxCloth* classPointer, bool call_explicit, void* buffer)
{
    classPointer->setPositions(buffer);
}

API_EXPORT NxVec3 NxCloth_getPosition(NxCloth* classPointer, bool call_explicit, NxU32 vertexId)
{
    return classPointer->getPosition(vertexId);
}

API_EXPORT void NxCloth_getPositions(NxCloth* classPointer, bool call_explicit, void* buffer, NxU32 byteStride)
{
    classPointer->getPositions(buffer, byteStride);
}

API_EXPORT void NxCloth_getPositions_1(NxCloth* classPointer, bool call_explicit, void* buffer)
{
    classPointer->getPositions(buffer);
}

API_EXPORT void NxCloth_setVelocity(NxCloth* classPointer, bool call_explicit, NxVec3& velocity, NxU32 vertexId)
{
    classPointer->setVelocity(velocity, vertexId);
}

API_EXPORT void NxCloth_setVelocities(NxCloth* classPointer, bool call_explicit, void* buffer, NxU32 byteStride)
{
    classPointer->setVelocities(buffer, byteStride);
}

API_EXPORT void NxCloth_setVelocities_1(NxCloth* classPointer, bool call_explicit, void* buffer)
{
    classPointer->setVelocities(buffer);
}

API_EXPORT NxVec3 NxCloth_getVelocity(NxCloth* classPointer, bool call_explicit, NxU32 vertexId)
{
    return classPointer->getVelocity(vertexId);
}

API_EXPORT void NxCloth_getVelocities(NxCloth* classPointer, bool call_explicit, void* buffer, NxU32 byteStride)
{
    classPointer->getVelocities(buffer, byteStride);
}

API_EXPORT void NxCloth_getVelocities_1(NxCloth* classPointer, bool call_explicit, void* buffer)
{
    classPointer->getVelocities(buffer);
}

API_EXPORT NxU32 NxCloth_getNumberOfParticles(NxCloth* classPointer, bool call_explicit)
{
    return classPointer->getNumberOfParticles();
}

API_EXPORT NxU32 NxCloth_queryShapePointers(NxCloth* classPointer, bool call_explicit)
{
    return classPointer->queryShapePointers();
}

API_EXPORT NxU32 NxCloth_getStateByteSize(NxCloth* classPointer, bool call_explicit)
{
    return classPointer->getStateByteSize();
}

API_EXPORT void NxCloth_getShapePointers(NxCloth* classPointer, bool call_explicit, NxShape** shapePointers, NxU32* flags)
{
    classPointer->getShapePointers(shapePointers, flags);
}

API_EXPORT void NxCloth_getShapePointers_1(NxCloth* classPointer, bool call_explicit, NxShape** shapePointers)
{
    classPointer->getShapePointers(shapePointers);
}

API_EXPORT void NxCloth_setShapePointers(NxCloth* classPointer, bool call_explicit, NxShape** shapePointers, unsigned int numShapes)
{
    classPointer->setShapePointers(shapePointers, numShapes);
}

API_EXPORT void NxCloth_saveStateToStream(NxCloth* classPointer, bool call_explicit, NxStream* stream, bool permute)
{
    classPointer->saveStateToStream(*stream, permute);
}

API_EXPORT void NxCloth_saveStateToStream_1(NxCloth* classPointer, bool call_explicit, NxStream* stream)
{
    classPointer->saveStateToStream(*stream);
}

API_EXPORT void NxCloth_loadStateFromStream(NxCloth* classPointer, bool call_explicit, NxStream* stream)
{
    classPointer->loadStateFromStream(*stream);
}

API_EXPORT void NxCloth_setCollisionResponseCoefficient(NxCloth* classPointer, bool call_explicit, NxReal coefficient)
{
    classPointer->setCollisionResponseCoefficient(coefficient);
}

API_EXPORT NxReal NxCloth_getCollisionResponseCoefficient(NxCloth* classPointer, bool call_explicit)
{
    return classPointer->getCollisionResponseCoefficient();
}

API_EXPORT void NxCloth_setAttachmentResponseCoefficient(NxCloth* classPointer, bool call_explicit, NxReal coefficient)
{
    classPointer->setAttachmentResponseCoefficient(coefficient);
}

API_EXPORT NxReal NxCloth_getAttachmentResponseCoefficient(NxCloth* classPointer, bool call_explicit)
{
    return classPointer->getAttachmentResponseCoefficient();
}

API_EXPORT void NxCloth_setFromFluidResponseCoefficient(NxCloth* classPointer, bool call_explicit, NxReal coefficient)
{
    classPointer->setFromFluidResponseCoefficient(coefficient);
}

API_EXPORT NxReal NxCloth_getFromFluidResponseCoefficient(NxCloth* classPointer, bool call_explicit)
{
    return classPointer->getFromFluidResponseCoefficient();
}

API_EXPORT void NxCloth_setToFluidResponseCoefficient(NxCloth* classPointer, bool call_explicit, NxReal coefficient)
{
    classPointer->setToFluidResponseCoefficient(coefficient);
}

API_EXPORT NxReal NxCloth_getToFluidResponseCoefficient(NxCloth* classPointer, bool call_explicit)
{
    return classPointer->getToFluidResponseCoefficient();
}

API_EXPORT void NxCloth_setExternalAcceleration(NxCloth* classPointer, bool call_explicit, NxVec3 acceleration)
{
    classPointer->setExternalAcceleration(acceleration);
}

API_EXPORT NxVec3 NxCloth_getExternalAcceleration(NxCloth* classPointer, bool call_explicit)
{
    return classPointer->getExternalAcceleration();
}

API_EXPORT void NxCloth_setMinAdhereVelocity(NxCloth* classPointer, bool call_explicit, NxReal velocity)
{
    classPointer->setMinAdhereVelocity(velocity);
}

API_EXPORT NxReal NxCloth_getMinAdhereVelocity(NxCloth* classPointer, bool call_explicit)
{
    return classPointer->getMinAdhereVelocity();
}

API_EXPORT void NxCloth_setWindAcceleration(NxCloth* classPointer, bool call_explicit, NxVec3 acceleration)
{
    classPointer->setWindAcceleration(acceleration);
}

API_EXPORT NxVec3 NxCloth_getWindAcceleration(NxCloth* classPointer, bool call_explicit)
{
    return classPointer->getWindAcceleration();
}

API_EXPORT bool NxCloth_isSleeping(NxCloth* classPointer, bool call_explicit)
{
    return classPointer->isSleeping();
}

API_EXPORT NxReal NxCloth_getSleepLinearVelocity(NxCloth* classPointer, bool call_explicit)
{
    return classPointer->getSleepLinearVelocity();
}

API_EXPORT void NxCloth_setSleepLinearVelocity(NxCloth* classPointer, bool call_explicit, NxReal threshold)
{
    classPointer->setSleepLinearVelocity(threshold);
}

API_EXPORT void NxCloth_wakeUp(NxCloth* classPointer, bool call_explicit, NxReal wakeCounterValue)
{
    classPointer->wakeUp(wakeCounterValue);
}

API_EXPORT void NxCloth_putToSleep(NxCloth* classPointer, bool call_explicit)
{
    classPointer->putToSleep();
}

API_EXPORT void NxCloth_setFlags(NxCloth* classPointer, bool call_explicit, NxU32 flags)
{
    classPointer->setFlags(flags);
}

API_EXPORT NxU32 NxCloth_getFlags(NxCloth* classPointer, bool call_explicit)
{
    return classPointer->getFlags();
}

API_EXPORT void NxCloth_setName(NxCloth* classPointer, bool call_explicit, char* name)
{
    classPointer->setName(name);
}

API_EXPORT void NxCloth_addForceAtVertex(NxCloth* classPointer, bool call_explicit, NxVec3& force, NxU32 vertexId, NxForceMode mode)
{
    classPointer->addForceAtVertex(force, vertexId, mode);
}

API_EXPORT void NxCloth_addForceAtVertex_1(NxCloth* classPointer, bool call_explicit, NxVec3& force, NxU32 vertexId)
{
    classPointer->addForceAtVertex(force, vertexId);
}

API_EXPORT void NxCloth_addForceAtPos(NxCloth* classPointer, bool call_explicit, NxVec3& position, NxReal magnitude, NxReal radius, NxForceMode mode)
{
    classPointer->addForceAtPos(position, magnitude, radius, mode);
}

API_EXPORT void NxCloth_addForceAtPos_1(NxCloth* classPointer, bool call_explicit, NxVec3& position, NxReal magnitude, NxReal radius)
{
    classPointer->addForceAtPos(position, magnitude, radius);
}

API_EXPORT void NxCloth_addDirectedForceAtPos(NxCloth* classPointer, bool call_explicit, NxVec3& position, NxVec3& force, NxReal radius, NxForceMode mode)
{
    classPointer->addDirectedForceAtPos(position, force, radius, mode);
}

API_EXPORT void NxCloth_addDirectedForceAtPos_1(NxCloth* classPointer, bool call_explicit, NxVec3& position, NxVec3& force, NxReal radius)
{
    classPointer->addDirectedForceAtPos(position, force, radius);
}

API_EXPORT bool NxCloth_overlapAABBTriangles(NxCloth* classPointer, bool call_explicit, NxBounds3* bounds, NxU32& nb, const NxU32*& indices)
{
    return classPointer->overlapAABBTriangles(*bounds, nb, indices);
}

API_EXPORT NxScene* NxCloth_getScene(NxCloth* classPointer, bool call_explicit)
{
    return &classPointer->getScene();
}

API_EXPORT const char* NxCloth_getName(NxCloth* classPointer, bool call_explicit)
{
    return classPointer->getName();
}

API_EXPORT NxCompartment* NxCloth_getCompartment(NxCloth* classPointer, bool call_explicit)
{
    return classPointer->getCompartment();
}

API_EXPORT NxU32 NxCloth_getPPUTime(NxCloth* classPointer, bool call_explicit)
{
    return classPointer->getPPUTime();
}

API_EXPORT NxForceFieldMaterial NxCloth_getForceFieldMaterial(NxCloth* classPointer, bool call_explicit)
{
    return classPointer->getForceFieldMaterial();
}

API_EXPORT void NxCloth_setForceFieldMaterial(NxCloth* classPointer, bool call_explicit, NxForceFieldMaterial unknown7)
{
    classPointer->setForceFieldMaterial(unknown7);
}

API_EXPORT void set_NxClothDesc_clothMesh(NxClothDesc* classPointer, NxClothMesh* newvalue)
{
    classPointer->clothMesh = newvalue;
}

API_EXPORT NxClothMesh* get_NxClothDesc_clothMesh(NxClothDesc* classPointer)
{
    return classPointer->clothMesh;
}

API_EXPORT void set_NxClothDesc_globalPose(NxClothDesc* classPointer, NxMat34 newvalue)
{
    classPointer->globalPose = newvalue;
}

API_EXPORT NxMat34 get_NxClothDesc_globalPose(NxClothDesc* classPointer)
{
    return classPointer->globalPose;
}

API_EXPORT void set_NxClothDesc_thickness(NxClothDesc* classPointer, NxReal newvalue)
{
    classPointer->thickness = newvalue;
}

API_EXPORT NxReal get_NxClothDesc_thickness(NxClothDesc* classPointer)
{
    return classPointer->thickness;
}

API_EXPORT void set_NxClothDesc_density(NxClothDesc* classPointer, NxReal newvalue)
{
    classPointer->density = newvalue;
}

API_EXPORT NxReal get_NxClothDesc_density(NxClothDesc* classPointer)
{
    return classPointer->density;
}

API_EXPORT void set_NxClothDesc_bendingStiffness(NxClothDesc* classPointer, NxReal newvalue)
{
    classPointer->bendingStiffness = newvalue;
}

API_EXPORT NxReal get_NxClothDesc_bendingStiffness(NxClothDesc* classPointer)
{
    return classPointer->bendingStiffness;
}

API_EXPORT void set_NxClothDesc_stretchingStiffness(NxClothDesc* classPointer, NxReal newvalue)
{
    classPointer->stretchingStiffness = newvalue;
}

API_EXPORT NxReal get_NxClothDesc_stretchingStiffness(NxClothDesc* classPointer)
{
    return classPointer->stretchingStiffness;
}

API_EXPORT void set_NxClothDesc_dampingCoefficient(NxClothDesc* classPointer, NxReal newvalue)
{
    classPointer->dampingCoefficient = newvalue;
}

API_EXPORT NxReal get_NxClothDesc_dampingCoefficient(NxClothDesc* classPointer)
{
    return classPointer->dampingCoefficient;
}

API_EXPORT void set_NxClothDesc_friction(NxClothDesc* classPointer, NxReal newvalue)
{
    classPointer->friction = newvalue;
}

API_EXPORT NxReal get_NxClothDesc_friction(NxClothDesc* classPointer)
{
    return classPointer->friction;
}

API_EXPORT void set_NxClothDesc_pressure(NxClothDesc* classPointer, NxReal newvalue)
{
    classPointer->pressure = newvalue;
}

API_EXPORT NxReal get_NxClothDesc_pressure(NxClothDesc* classPointer)
{
    return classPointer->pressure;
}

API_EXPORT void set_NxClothDesc_tearFactor(NxClothDesc* classPointer, NxReal newvalue)
{
    classPointer->tearFactor = newvalue;
}

API_EXPORT NxReal get_NxClothDesc_tearFactor(NxClothDesc* classPointer)
{
    return classPointer->tearFactor;
}

API_EXPORT void set_NxClothDesc_collisionResponseCoefficient(NxClothDesc* classPointer, NxReal newvalue)
{
    classPointer->collisionResponseCoefficient = newvalue;
}

API_EXPORT NxReal get_NxClothDesc_collisionResponseCoefficient(NxClothDesc* classPointer)
{
    return classPointer->collisionResponseCoefficient;
}

API_EXPORT void set_NxClothDesc_attachmentResponseCoefficient(NxClothDesc* classPointer, NxReal newvalue)
{
    classPointer->attachmentResponseCoefficient = newvalue;
}

API_EXPORT NxReal get_NxClothDesc_attachmentResponseCoefficient(NxClothDesc* classPointer)
{
    return classPointer->attachmentResponseCoefficient;
}

API_EXPORT void set_NxClothDesc_attachmentTearFactor(NxClothDesc* classPointer, NxReal newvalue)
{
    classPointer->attachmentTearFactor = newvalue;
}

API_EXPORT NxReal get_NxClothDesc_attachmentTearFactor(NxClothDesc* classPointer)
{
    return classPointer->attachmentTearFactor;
}

API_EXPORT void set_NxClothDesc_toFluidResponseCoefficient(NxClothDesc* classPointer, NxReal newvalue)
{
    classPointer->toFluidResponseCoefficient = newvalue;
}

API_EXPORT NxReal get_NxClothDesc_toFluidResponseCoefficient(NxClothDesc* classPointer)
{
    return classPointer->toFluidResponseCoefficient;
}

API_EXPORT void set_NxClothDesc_fromFluidResponseCoefficient(NxClothDesc* classPointer, NxReal newvalue)
{
    classPointer->fromFluidResponseCoefficient = newvalue;
}

API_EXPORT NxReal get_NxClothDesc_fromFluidResponseCoefficient(NxClothDesc* classPointer)
{
    return classPointer->fromFluidResponseCoefficient;
}

API_EXPORT void set_NxClothDesc_minAdhereVelocity(NxClothDesc* classPointer, NxReal newvalue)
{
    classPointer->minAdhereVelocity = newvalue;
}

API_EXPORT NxReal get_NxClothDesc_minAdhereVelocity(NxClothDesc* classPointer)
{
    return classPointer->minAdhereVelocity;
}

API_EXPORT void set_NxClothDesc_solverIterations(NxClothDesc* classPointer, NxU32 newvalue)
{
    classPointer->solverIterations = newvalue;
}

API_EXPORT NxU32 get_NxClothDesc_solverIterations(NxClothDesc* classPointer)
{
    return classPointer->solverIterations;
}

API_EXPORT void set_NxClothDesc_externalAcceleration(NxClothDesc* classPointer, NxVec3 newvalue)
{
    classPointer->externalAcceleration = newvalue;
}

API_EXPORT NxVec3 get_NxClothDesc_externalAcceleration(NxClothDesc* classPointer)
{
    return classPointer->externalAcceleration;
}

API_EXPORT void set_NxClothDesc_windAcceleration(NxClothDesc* classPointer, NxVec3 newvalue)
{
    classPointer->windAcceleration = newvalue;
}

API_EXPORT NxVec3 get_NxClothDesc_windAcceleration(NxClothDesc* classPointer)
{
    return classPointer->windAcceleration;
}

API_EXPORT void set_NxClothDesc_wakeUpCounter(NxClothDesc* classPointer, NxReal newvalue)
{
    classPointer->wakeUpCounter = newvalue;
}

API_EXPORT NxReal get_NxClothDesc_wakeUpCounter(NxClothDesc* classPointer)
{
    return classPointer->wakeUpCounter;
}

API_EXPORT void set_NxClothDesc_sleepLinearVelocity(NxClothDesc* classPointer, NxReal newvalue)
{
    classPointer->sleepLinearVelocity = newvalue;
}

API_EXPORT NxReal get_NxClothDesc_sleepLinearVelocity(NxClothDesc* classPointer)
{
    return classPointer->sleepLinearVelocity;
}

API_EXPORT void set_NxClothDesc_meshData(NxClothDesc* classPointer, NxMeshData* newvalue)
{
    classPointer->meshData = *newvalue;
}

API_EXPORT NxMeshData* get_NxClothDesc_meshData(NxClothDesc* classPointer)
{
    return &classPointer->meshData;
}

API_EXPORT void set_NxClothDesc_collisionGroup(NxClothDesc* classPointer, NxCollisionGroup newvalue)
{
    classPointer->collisionGroup = newvalue;
}

API_EXPORT NxCollisionGroup get_NxClothDesc_collisionGroup(NxClothDesc* classPointer)
{
    return classPointer->collisionGroup;
}

API_EXPORT void set_NxClothDesc_groupsMask(NxClothDesc* classPointer, NxGroupsMask* newvalue)
{
    classPointer->groupsMask = *newvalue;
}

API_EXPORT NxGroupsMask* get_NxClothDesc_groupsMask(NxClothDesc* classPointer)
{
    return &classPointer->groupsMask;
}

API_EXPORT void set_NxClothDesc_forceFieldMaterial(NxClothDesc* classPointer, NxU16 newvalue)
{
    classPointer->forceFieldMaterial = newvalue;
}

API_EXPORT NxU16 get_NxClothDesc_forceFieldMaterial(NxClothDesc* classPointer)
{
    return classPointer->forceFieldMaterial;
}

API_EXPORT void set_NxClothDesc_validBounds(NxClothDesc* classPointer, NxBounds3* newvalue)
{
    classPointer->validBounds = *newvalue;
}

API_EXPORT NxBounds3* get_NxClothDesc_validBounds(NxClothDesc* classPointer)
{
    return &classPointer->validBounds;
}

API_EXPORT void set_NxClothDesc_relativeGridSpacing(NxClothDesc* classPointer, NxReal newvalue)
{
    classPointer->relativeGridSpacing = newvalue;
}

API_EXPORT NxReal get_NxClothDesc_relativeGridSpacing(NxClothDesc* classPointer)
{
    return classPointer->relativeGridSpacing;
}

API_EXPORT void set_NxClothDesc_flags(NxClothDesc* classPointer, NxU32 newvalue)
{
    classPointer->flags = newvalue;
}

API_EXPORT NxU32 get_NxClothDesc_flags(NxClothDesc* classPointer)
{
    return classPointer->flags;
}

API_EXPORT void set_NxClothDesc_userData(NxClothDesc* classPointer, void* newvalue)
{
    classPointer->userData = newvalue;
}

API_EXPORT void* get_NxClothDesc_userData(NxClothDesc* classPointer)
{
    return classPointer->userData;
}

API_EXPORT void set_NxClothDesc_name(NxClothDesc* classPointer, const char* newvalue)
{
    classPointer->name = newvalue;
}

API_EXPORT const char* get_NxClothDesc_name(NxClothDesc* classPointer)
{
    return classPointer->name;
}

API_EXPORT void set_NxClothDesc_compartment(NxClothDesc* classPointer, NxCompartment* newvalue)
{
    classPointer->compartment = newvalue;
}

API_EXPORT NxCompartment* get_NxClothDesc_compartment(NxClothDesc* classPointer)
{
    return classPointer->compartment;
}

API_EXPORT NxClothDesc* new_NxClothDesc(bool do_override)
{
    return new NxClothDesc();
}

API_EXPORT void NxClothDesc_setToDefault(NxClothDesc* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxClothDesc::setToDefault() : classPointer->setToDefault();
}

API_EXPORT bool NxClothDesc_isValid(NxClothDesc* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxClothDesc::isValid() : classPointer->isValid();
}

API_EXPORT NxClothMesh* new_NxClothMesh(bool do_override)
{
    return (do_override) ? new NxClothMesh_doxybind() : NULL;
}

API_EXPORT bool NxClothMesh_saveToDesc(NxClothMesh* classPointer, bool call_explicit, NxClothMeshDesc* desc)
{
    return classPointer->saveToDesc(*desc);
}

API_EXPORT NxU32 NxClothMesh_getReferenceCount(NxClothMesh* classPointer, bool call_explicit)
{
    return classPointer->getReferenceCount();
}

API_EXPORT void set_NxSimpleTriangleMesh_numVertices(NxSimpleTriangleMesh* classPointer, NxU32 newvalue)
{
    classPointer->numVertices = newvalue;
}

API_EXPORT NxU32 get_NxSimpleTriangleMesh_numVertices(NxSimpleTriangleMesh* classPointer)
{
    return classPointer->numVertices;
}

API_EXPORT void set_NxSimpleTriangleMesh_numTriangles(NxSimpleTriangleMesh* classPointer, NxU32 newvalue)
{
    classPointer->numTriangles = newvalue;
}

API_EXPORT NxU32 get_NxSimpleTriangleMesh_numTriangles(NxSimpleTriangleMesh* classPointer)
{
    return classPointer->numTriangles;
}

API_EXPORT void set_NxSimpleTriangleMesh_pointStrideBytes(NxSimpleTriangleMesh* classPointer, NxU32 newvalue)
{
    classPointer->pointStrideBytes = newvalue;
}

API_EXPORT NxU32 get_NxSimpleTriangleMesh_pointStrideBytes(NxSimpleTriangleMesh* classPointer)
{
    return classPointer->pointStrideBytes;
}

API_EXPORT void set_NxSimpleTriangleMesh_triangleStrideBytes(NxSimpleTriangleMesh* classPointer, NxU32 newvalue)
{
    classPointer->triangleStrideBytes = newvalue;
}

API_EXPORT NxU32 get_NxSimpleTriangleMesh_triangleStrideBytes(NxSimpleTriangleMesh* classPointer)
{
    return classPointer->triangleStrideBytes;
}

API_EXPORT void set_NxSimpleTriangleMesh_points(NxSimpleTriangleMesh* classPointer, const void* newvalue)
{
    classPointer->points = newvalue;
}

API_EXPORT const void* get_NxSimpleTriangleMesh_points(NxSimpleTriangleMesh* classPointer)
{
    return classPointer->points;
}

API_EXPORT void set_NxSimpleTriangleMesh_triangles(NxSimpleTriangleMesh* classPointer, const void* newvalue)
{
    classPointer->triangles = newvalue;
}

API_EXPORT const void* get_NxSimpleTriangleMesh_triangles(NxSimpleTriangleMesh* classPointer)
{
    return classPointer->triangles;
}

API_EXPORT void set_NxSimpleTriangleMesh_flags(NxSimpleTriangleMesh* classPointer, NxU32 newvalue)
{
    classPointer->flags = newvalue;
}

API_EXPORT NxU32 get_NxSimpleTriangleMesh_flags(NxSimpleTriangleMesh* classPointer)
{
    return classPointer->flags;
}

API_EXPORT NxSimpleTriangleMesh* new_NxSimpleTriangleMesh(bool do_override)
{
    return new NxSimpleTriangleMesh();
}

API_EXPORT void NxSimpleTriangleMesh_setToDefault(NxSimpleTriangleMesh* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxSimpleTriangleMesh::setToDefault() : classPointer->setToDefault();
}

API_EXPORT bool NxSimpleTriangleMesh_isValid(NxSimpleTriangleMesh* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxSimpleTriangleMesh::isValid() : classPointer->isValid();
}

API_EXPORT void set_NxClothMeshDesc_vertexMassStrideBytes(NxClothMeshDesc* classPointer, NxU32 newvalue)
{
    classPointer->vertexMassStrideBytes = newvalue;
}

API_EXPORT NxU32 get_NxClothMeshDesc_vertexMassStrideBytes(NxClothMeshDesc* classPointer)
{
    return classPointer->vertexMassStrideBytes;
}

API_EXPORT void set_NxClothMeshDesc_vertexFlagStrideBytes(NxClothMeshDesc* classPointer, NxU32 newvalue)
{
    classPointer->vertexFlagStrideBytes = newvalue;
}

API_EXPORT NxU32 get_NxClothMeshDesc_vertexFlagStrideBytes(NxClothMeshDesc* classPointer)
{
    return classPointer->vertexFlagStrideBytes;
}

API_EXPORT void set_NxClothMeshDesc_vertexMasses(NxClothMeshDesc* classPointer, const void* newvalue)
{
    classPointer->vertexMasses = newvalue;
}

API_EXPORT const void* get_NxClothMeshDesc_vertexMasses(NxClothMeshDesc* classPointer)
{
    return classPointer->vertexMasses;
}

API_EXPORT void set_NxClothMeshDesc_vertexFlags(NxClothMeshDesc* classPointer, const void* newvalue)
{
    classPointer->vertexFlags = newvalue;
}

API_EXPORT const void* get_NxClothMeshDesc_vertexFlags(NxClothMeshDesc* classPointer)
{
    return classPointer->vertexFlags;
}

API_EXPORT void set_NxClothMeshDesc_weldingDistance(NxClothMeshDesc* classPointer, NxReal newvalue)
{
    classPointer->weldingDistance = newvalue;
}

API_EXPORT NxReal get_NxClothMeshDesc_weldingDistance(NxClothMeshDesc* classPointer)
{
    return classPointer->weldingDistance;
}

API_EXPORT NxClothMeshDesc* new_NxClothMeshDesc(bool do_override)
{
    return new NxClothMeshDesc();
}

API_EXPORT void NxClothMeshDesc_setToDefault(NxClothMeshDesc* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxClothMeshDesc::setToDefault() : classPointer->setToDefault();
}

API_EXPORT bool NxClothMeshDesc_isValid(NxClothMeshDesc* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxClothMeshDesc::isValid() : classPointer->isValid();
}

API_EXPORT NxCompartmentType NxCompartment_getType(NxCompartment* classPointer, bool call_explicit)
{
    return classPointer->getType();
}

API_EXPORT NxU32 NxCompartment_getDeviceCode(NxCompartment* classPointer, bool call_explicit)
{
    return classPointer->getDeviceCode();
}

API_EXPORT NxReal NxCompartment_getGridHashCellSize(NxCompartment* classPointer, bool call_explicit)
{
    return classPointer->getGridHashCellSize();
}

API_EXPORT NxU32 NxCompartment_gridHashTablePower(NxCompartment* classPointer, bool call_explicit)
{
    return classPointer->gridHashTablePower();
}

API_EXPORT void NxCompartment_setTimeScale(NxCompartment* classPointer, bool call_explicit, NxReal unknown8)
{
    classPointer->setTimeScale(unknown8);
}

API_EXPORT NxReal NxCompartment_getTimeScale(NxCompartment* classPointer, bool call_explicit)
{
    return classPointer->getTimeScale();
}

API_EXPORT void NxCompartment_setTiming(NxCompartment* classPointer, bool call_explicit, NxReal maxTimestep, NxU32 maxIter, NxTimeStepMethod method)
{
    classPointer->setTiming(maxTimestep, maxIter, method);
}

API_EXPORT void NxCompartment_setTiming_1(NxCompartment* classPointer, bool call_explicit, NxReal maxTimestep, NxU32 maxIter)
{
    classPointer->setTiming(maxTimestep, maxIter);
}

API_EXPORT void NxCompartment_setTiming_2(NxCompartment* classPointer, bool call_explicit, NxReal maxTimestep)
{
    classPointer->setTiming(maxTimestep);
}

API_EXPORT void NxCompartment_getTiming(NxCompartment* classPointer, bool call_explicit, NxReal& maxTimestep, NxU32& maxIter, NxTimeStepMethod& method, NxU32* numSubSteps)
{
    classPointer->getTiming(maxTimestep, maxIter, method, numSubSteps);
}

API_EXPORT void NxCompartment_getTiming_1(NxCompartment* classPointer, bool call_explicit, NxReal& maxTimestep, NxU32& maxIter, NxTimeStepMethod& method)
{
    classPointer->getTiming(maxTimestep, maxIter, method);
}

API_EXPORT bool NxCompartment_checkResults(NxCompartment* classPointer, bool call_explicit, bool block)
{
    return classPointer->checkResults(block);
}

API_EXPORT bool NxCompartment_fetchResults(NxCompartment* classPointer, bool call_explicit, bool block)
{
    return classPointer->fetchResults(block);
}

API_EXPORT bool NxCompartment_saveToDesc(NxCompartment* classPointer, bool call_explicit, NxCompartmentDesc* desc)
{
    return classPointer->saveToDesc(*desc);
}

API_EXPORT void NxCompartment_setFlags(NxCompartment* classPointer, bool call_explicit, NxU32 flags)
{
    classPointer->setFlags(flags);
}

API_EXPORT NxU32 NxCompartment_getFlags(NxCompartment* classPointer, bool call_explicit)
{
    return classPointer->getFlags();
}

API_EXPORT void set_NxCompartmentDesc_type(NxCompartmentDesc* classPointer, NxCompartmentType newvalue)
{
    classPointer->type = newvalue;
}

API_EXPORT NxCompartmentType get_NxCompartmentDesc_type(NxCompartmentDesc* classPointer)
{
    return classPointer->type;
}

API_EXPORT void set_NxCompartmentDesc_deviceCode(NxCompartmentDesc* classPointer, NxU32 newvalue)
{
    classPointer->deviceCode = newvalue;
}

API_EXPORT NxU32 get_NxCompartmentDesc_deviceCode(NxCompartmentDesc* classPointer)
{
    return classPointer->deviceCode;
}

API_EXPORT void set_NxCompartmentDesc_gridHashCellSize(NxCompartmentDesc* classPointer, NxReal newvalue)
{
    classPointer->gridHashCellSize = newvalue;
}

API_EXPORT NxReal get_NxCompartmentDesc_gridHashCellSize(NxCompartmentDesc* classPointer)
{
    return classPointer->gridHashCellSize;
}

API_EXPORT void set_NxCompartmentDesc_gridHashTablePower(NxCompartmentDesc* classPointer, NxU32 newvalue)
{
    classPointer->gridHashTablePower = newvalue;
}

API_EXPORT NxU32 get_NxCompartmentDesc_gridHashTablePower(NxCompartmentDesc* classPointer)
{
    return classPointer->gridHashTablePower;
}

API_EXPORT void set_NxCompartmentDesc_flags(NxCompartmentDesc* classPointer, NxU32 newvalue)
{
    classPointer->flags = newvalue;
}

API_EXPORT NxU32 get_NxCompartmentDesc_flags(NxCompartmentDesc* classPointer)
{
    return classPointer->flags;
}

API_EXPORT void set_NxCompartmentDesc_threadMask(NxCompartmentDesc* classPointer, NxU32 newvalue)
{
    classPointer->threadMask = newvalue;
}

API_EXPORT NxU32 get_NxCompartmentDesc_threadMask(NxCompartmentDesc* classPointer)
{
    return classPointer->threadMask;
}

API_EXPORT void set_NxCompartmentDesc_timeScale(NxCompartmentDesc* classPointer, NxReal newvalue)
{
    classPointer->timeScale = newvalue;
}

API_EXPORT NxReal get_NxCompartmentDesc_timeScale(NxCompartmentDesc* classPointer)
{
    return classPointer->timeScale;
}

API_EXPORT void NxCompartmentDesc_setToDefault(NxCompartmentDesc* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxCompartmentDesc::setToDefault() : classPointer->setToDefault();
}

API_EXPORT bool NxCompartmentDesc_isValid(NxCompartmentDesc* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxCompartmentDesc::isValid() : classPointer->isValid();
}

API_EXPORT NxCompartmentDesc* new_NxCompartmentDesc(bool do_override)
{
    return new NxCompartmentDesc();
}

API_EXPORT void set_NxConstraintDominance_dominance0(NxConstraintDominance* classPointer, NxReal newvalue)
{
    classPointer->dominance0 = newvalue;
}

API_EXPORT NxReal get_NxConstraintDominance_dominance0(NxConstraintDominance* classPointer)
{
    return classPointer->dominance0;
}

API_EXPORT void set_NxConstraintDominance_dominance1(NxConstraintDominance* classPointer, NxReal newvalue)
{
    classPointer->dominance1 = newvalue;
}

API_EXPORT NxReal get_NxConstraintDominance_dominance1(NxConstraintDominance* classPointer)
{
    return classPointer->dominance1;
}

API_EXPORT NxConstraintDominance* new_NxConstraintDominance(bool do_override, NxReal a, NxReal b)
{
    return new NxConstraintDominance(a, b);
}

API_EXPORT void set_NxContactPair_actors(NxContactPair* classPointer, NxActor* newvalue[2])
{
    memcpy(&classPointer->actors[0], &newvalue[0], sizeof(NxActor*) * 2);
}

API_EXPORT void get_NxContactPair_actors(NxContactPair* classPointer, NxActor* newvalue[2])
{
    memcpy(&newvalue[0], &classPointer->actors[0], sizeof(NxActor*) * 2);
}

API_EXPORT void set_NxContactPair_stream(NxContactPair* classPointer, NxConstContactStream newvalue)
{
    classPointer->stream = newvalue;
}

API_EXPORT NxConstContactStream get_NxContactPair_stream(NxContactPair* classPointer)
{
    return classPointer->stream;
}

API_EXPORT void set_NxContactPair_sumNormalForce(NxContactPair* classPointer, NxVec3 newvalue)
{
    classPointer->sumNormalForce = newvalue;
}

API_EXPORT NxVec3 get_NxContactPair_sumNormalForce(NxContactPair* classPointer)
{
    return classPointer->sumNormalForce;
}

API_EXPORT void set_NxContactPair_sumFrictionForce(NxContactPair* classPointer, NxVec3 newvalue)
{
    classPointer->sumFrictionForce = newvalue;
}

API_EXPORT NxVec3 get_NxContactPair_sumFrictionForce(NxContactPair* classPointer)
{
    return classPointer->sumFrictionForce;
}

API_EXPORT void set_NxContactPair_isDeletedActor(NxContactPair* classPointer, bool newvalue[2])
{
    memcpy(&classPointer->isDeletedActor[0], &newvalue[0], sizeof(bool) * 2);
}

API_EXPORT void get_NxContactPair_isDeletedActor(NxContactPair* classPointer, bool newvalue[2])
{
    memcpy(&newvalue[0], &classPointer->isDeletedActor[0], sizeof(bool) * 2);
}

API_EXPORT NxContactPair* new_NxContactPair(bool do_override)
{
    return new NxContactPair();
}

API_EXPORT NxContactStreamIterator* new_NxContactStreamIterator(bool do_override, NxConstContactStream stream)
{
    return new NxContactStreamIterator(stream);
}

API_EXPORT bool NxContactStreamIterator_goNextPair(NxContactStreamIterator* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxContactStreamIterator::goNextPair() : classPointer->goNextPair();
}

API_EXPORT bool NxContactStreamIterator_goNextPatch(NxContactStreamIterator* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxContactStreamIterator::goNextPatch() : classPointer->goNextPatch();
}

API_EXPORT bool NxContactStreamIterator_goNextPoint(NxContactStreamIterator* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxContactStreamIterator::goNextPoint() : classPointer->goNextPoint();
}

API_EXPORT NxU32 NxContactStreamIterator_getNumPairs(NxContactStreamIterator* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxContactStreamIterator::getNumPairs() : classPointer->getNumPairs();
}

API_EXPORT NxShape* NxContactStreamIterator_getShape(NxContactStreamIterator* classPointer, bool call_explicit, NxU32 shapeIndex)
{
    return (call_explicit) ? classPointer->NxContactStreamIterator::getShape(shapeIndex) : classPointer->getShape(shapeIndex);
}

API_EXPORT NxU16 NxContactStreamIterator_getShapeFlags(NxContactStreamIterator* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxContactStreamIterator::getShapeFlags() : classPointer->getShapeFlags();
}

API_EXPORT NxU32 NxContactStreamIterator_getNumPatches(NxContactStreamIterator* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxContactStreamIterator::getNumPatches() : classPointer->getNumPatches();
}

API_EXPORT NxU32 NxContactStreamIterator_getNumPatchesRemaining(NxContactStreamIterator* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxContactStreamIterator::getNumPatchesRemaining() : classPointer->getNumPatchesRemaining();
}

API_EXPORT const NxVec3* NxContactStreamIterator_getPatchNormal(NxContactStreamIterator* classPointer, bool call_explicit)
{
    return (call_explicit) ? &classPointer->NxContactStreamIterator::getPatchNormal() : &classPointer->getPatchNormal();
}

API_EXPORT NxU32 NxContactStreamIterator_getNumPoints(NxContactStreamIterator* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxContactStreamIterator::getNumPoints() : classPointer->getNumPoints();
}

API_EXPORT NxU32 NxContactStreamIterator_getNumPointsRemaining(NxContactStreamIterator* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxContactStreamIterator::getNumPointsRemaining() : classPointer->getNumPointsRemaining();
}

API_EXPORT const NxVec3* NxContactStreamIterator_getPoint(NxContactStreamIterator* classPointer, bool call_explicit)
{
    return (call_explicit) ? &classPointer->NxContactStreamIterator::getPoint() : &classPointer->getPoint();
}

API_EXPORT NxReal NxContactStreamIterator_getSeparation(NxContactStreamIterator* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxContactStreamIterator::getSeparation() : classPointer->getSeparation();
}

API_EXPORT NxU32 NxContactStreamIterator_getFeatureIndex0(NxContactStreamIterator* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxContactStreamIterator::getFeatureIndex0() : classPointer->getFeatureIndex0();
}

API_EXPORT NxU32 NxContactStreamIterator_getFeatureIndex1(NxContactStreamIterator* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxContactStreamIterator::getFeatureIndex1() : classPointer->getFeatureIndex1();
}

API_EXPORT NxReal NxContactStreamIterator_getPointNormalForce(NxContactStreamIterator* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxContactStreamIterator::getPointNormalForce() : classPointer->getPointNormalForce();
}

API_EXPORT NxU32 NxControllerManager_getNbControllers(NxControllerManager* classPointer, bool call_explicit)
{
    return classPointer->getNbControllers();
}

API_EXPORT NxController* NxControllerManager_getController(NxControllerManager* classPointer, bool call_explicit, NxU32 index)
{
    return classPointer->getController(index);
}

API_EXPORT NxController* NxControllerManager_createController(NxControllerManager* classPointer, bool call_explicit, NxScene* scene, NxControllerDesc* desc)
{
    return classPointer->createController(scene, *desc);
}

API_EXPORT void NxControllerManager_releaseController(NxControllerManager* classPointer, bool call_explicit, NxController* controller)
{
    classPointer->releaseController(*controller);
}

API_EXPORT void NxControllerManager_purgeControllers(NxControllerManager* classPointer, bool call_explicit)
{
    classPointer->purgeControllers();
}

API_EXPORT void NxControllerManager_updateControllers(NxControllerManager* classPointer, bool call_explicit)
{
    classPointer->updateControllers();
}

API_EXPORT NxDebugRenderable* NxControllerManager_getDebugData(NxControllerManager* classPointer, bool call_explicit)
{
    return &classPointer->getDebugData();
}

API_EXPORT void NxControllerManager_resetDebugData(NxControllerManager* classPointer, bool call_explicit)
{
    classPointer->resetDebugData();
}

API_EXPORT NxControllerManager* new_NxControllerManager(bool do_override)
{
    return (do_override) ? new NxControllerManager_doxybind() : NULL;
}

API_EXPORT void set_NxControllerShapeHit_controller(NxControllerShapeHit* classPointer, NxController* newvalue)
{
    classPointer->controller = newvalue;
}

API_EXPORT NxController* get_NxControllerShapeHit_controller(NxControllerShapeHit* classPointer)
{
    return classPointer->controller;
}

API_EXPORT void set_NxControllerShapeHit_shape(NxControllerShapeHit* classPointer, NxShape* newvalue)
{
    classPointer->shape = newvalue;
}

API_EXPORT NxShape* get_NxControllerShapeHit_shape(NxControllerShapeHit* classPointer)
{
    return classPointer->shape;
}

API_EXPORT void set_NxControllerShapeHit_worldPos(NxControllerShapeHit* classPointer, NxExtendedVec3 newvalue)
{
    classPointer->worldPos = newvalue;
}

API_EXPORT NxExtendedVec3 get_NxControllerShapeHit_worldPos(NxControllerShapeHit* classPointer)
{
    return classPointer->worldPos;
}

API_EXPORT void set_NxControllerShapeHit_worldNormal(NxControllerShapeHit* classPointer, NxVec3 newvalue)
{
    classPointer->worldNormal = newvalue;
}

API_EXPORT NxVec3 get_NxControllerShapeHit_worldNormal(NxControllerShapeHit* classPointer)
{
    return classPointer->worldNormal;
}

API_EXPORT void set_NxControllerShapeHit_id(NxControllerShapeHit* classPointer, NxU32 newvalue)
{
    classPointer->id = newvalue;
}

API_EXPORT NxU32 get_NxControllerShapeHit_id(NxControllerShapeHit* classPointer)
{
    return classPointer->id;
}

API_EXPORT void set_NxControllerShapeHit_dir(NxControllerShapeHit* classPointer, NxVec3 newvalue)
{
    classPointer->dir = newvalue;
}

API_EXPORT NxVec3 get_NxControllerShapeHit_dir(NxControllerShapeHit* classPointer)
{
    return classPointer->dir;
}

API_EXPORT void set_NxControllerShapeHit_length(NxControllerShapeHit* classPointer, NxF32 newvalue)
{
    classPointer->length = newvalue;
}

API_EXPORT NxF32 get_NxControllerShapeHit_length(NxControllerShapeHit* classPointer)
{
    return classPointer->length;
}

API_EXPORT void set_NxControllersHit_controller(NxControllersHit* classPointer, NxController* newvalue)
{
    classPointer->controller = newvalue;
}

API_EXPORT NxController* get_NxControllersHit_controller(NxControllersHit* classPointer)
{
    return classPointer->controller;
}

API_EXPORT void set_NxControllersHit_other(NxControllersHit* classPointer, NxController* newvalue)
{
    classPointer->other = newvalue;
}

API_EXPORT NxController* get_NxControllersHit_other(NxControllersHit* classPointer)
{
    return classPointer->other;
}

API_EXPORT void NxConvexForceFieldShape_saveToDesc(NxConvexForceFieldShape* classPointer, bool call_explicit, NxConvexForceFieldShapeDesc* desc)
{
    classPointer->saveToDesc(*desc);
}

API_EXPORT void set_NxConvexForceFieldShapeDesc_meshData(NxConvexForceFieldShapeDesc* classPointer, NxConvexMesh* newvalue)
{
    classPointer->meshData = newvalue;
}

API_EXPORT NxConvexMesh* get_NxConvexForceFieldShapeDesc_meshData(NxConvexForceFieldShapeDesc* classPointer)
{
    return classPointer->meshData;
}

API_EXPORT NxConvexForceFieldShapeDesc* new_NxConvexForceFieldShapeDesc(bool do_override)
{
    return (do_override) ? new NxConvexForceFieldShapeDesc_doxybind() : new NxConvexForceFieldShapeDesc();
}

API_EXPORT void NxConvexForceFieldShapeDesc_setToDefault(NxConvexForceFieldShapeDesc* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxConvexForceFieldShapeDesc::setToDefault() : classPointer->setToDefault();
}

API_EXPORT bool NxConvexForceFieldShapeDesc_isValid(NxConvexForceFieldShapeDesc* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxConvexForceFieldShapeDesc::isValid() : classPointer->isValid();
}

API_EXPORT bool NxConvexMesh_saveToDesc(NxConvexMesh* classPointer, bool call_explicit, NxConvexMeshDesc* desc)
{
    return classPointer->saveToDesc(*desc);
}

API_EXPORT NxU32 NxConvexMesh_getSubmeshCount(NxConvexMesh* classPointer, bool call_explicit)
{
    return classPointer->getSubmeshCount();
}

API_EXPORT NxU32 NxConvexMesh_getCount(NxConvexMesh* classPointer, bool call_explicit, NxSubmeshIndex submeshIndex, NxInternalArray intArray)
{
    return classPointer->getCount(submeshIndex, intArray);
}

API_EXPORT NxInternalFormat NxConvexMesh_getFormat(NxConvexMesh* classPointer, bool call_explicit, NxSubmeshIndex submeshIndex, NxInternalArray intArray)
{
    return classPointer->getFormat(submeshIndex, intArray);
}

API_EXPORT const void* NxConvexMesh_getBase(NxConvexMesh* classPointer, bool call_explicit, NxSubmeshIndex submeshIndex, NxInternalArray intArray)
{
    return classPointer->getBase(submeshIndex, intArray);
}

API_EXPORT NxU32 NxConvexMesh_getStride(NxConvexMesh* classPointer, bool call_explicit, NxSubmeshIndex submeshIndex, NxInternalArray intArray)
{
    return classPointer->getStride(submeshIndex, intArray);
}

API_EXPORT bool NxConvexMesh_load(NxConvexMesh* classPointer, bool call_explicit, NxStream* stream)
{
    return classPointer->load(*stream);
}

API_EXPORT NxU32 NxConvexMesh_getReferenceCount(NxConvexMesh* classPointer, bool call_explicit)
{
    return classPointer->getReferenceCount();
}

API_EXPORT void NxConvexMesh_getMassInformation(NxConvexMesh* classPointer, bool call_explicit, NxReal& mass, NxMat33& localInertia, NxVec3& localCenterOfMass)
{
    classPointer->getMassInformation(mass, localInertia, localCenterOfMass);
}

API_EXPORT void* NxConvexMesh_getInternal(NxConvexMesh* classPointer, bool call_explicit)
{
    return classPointer->getInternal();
}

API_EXPORT void set_NxConvexMeshDesc_numVertices(NxConvexMeshDesc* classPointer, NxU32 newvalue)
{
    classPointer->numVertices = newvalue;
}

API_EXPORT NxU32 get_NxConvexMeshDesc_numVertices(NxConvexMeshDesc* classPointer)
{
    return classPointer->numVertices;
}

API_EXPORT void set_NxConvexMeshDesc_numTriangles(NxConvexMeshDesc* classPointer, NxU32 newvalue)
{
    classPointer->numTriangles = newvalue;
}

API_EXPORT NxU32 get_NxConvexMeshDesc_numTriangles(NxConvexMeshDesc* classPointer)
{
    return classPointer->numTriangles;
}

API_EXPORT void set_NxConvexMeshDesc_pointStrideBytes(NxConvexMeshDesc* classPointer, NxU32 newvalue)
{
    classPointer->pointStrideBytes = newvalue;
}

API_EXPORT NxU32 get_NxConvexMeshDesc_pointStrideBytes(NxConvexMeshDesc* classPointer)
{
    return classPointer->pointStrideBytes;
}

API_EXPORT void set_NxConvexMeshDesc_triangleStrideBytes(NxConvexMeshDesc* classPointer, NxU32 newvalue)
{
    classPointer->triangleStrideBytes = newvalue;
}

API_EXPORT NxU32 get_NxConvexMeshDesc_triangleStrideBytes(NxConvexMeshDesc* classPointer)
{
    return classPointer->triangleStrideBytes;
}

API_EXPORT void set_NxConvexMeshDesc_points(NxConvexMeshDesc* classPointer, const void* newvalue)
{
    classPointer->points = newvalue;
}

API_EXPORT const void* get_NxConvexMeshDesc_points(NxConvexMeshDesc* classPointer)
{
    return classPointer->points;
}

API_EXPORT void set_NxConvexMeshDesc_triangles(NxConvexMeshDesc* classPointer, const void* newvalue)
{
    classPointer->triangles = newvalue;
}

API_EXPORT const void* get_NxConvexMeshDesc_triangles(NxConvexMeshDesc* classPointer)
{
    return classPointer->triangles;
}

API_EXPORT void set_NxConvexMeshDesc_flags(NxConvexMeshDesc* classPointer, NxU32 newvalue)
{
    classPointer->flags = newvalue;
}

API_EXPORT NxU32 get_NxConvexMeshDesc_flags(NxConvexMeshDesc* classPointer)
{
    return classPointer->flags;
}

API_EXPORT NxConvexMeshDesc* new_NxConvexMeshDesc(bool do_override)
{
    return new NxConvexMeshDesc();
}

API_EXPORT void NxConvexMeshDesc_setToDefault(NxConvexMeshDesc* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxConvexMeshDesc::setToDefault() : classPointer->setToDefault();
}

API_EXPORT bool NxConvexMeshDesc_isValid(NxConvexMeshDesc* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxConvexMeshDesc::isValid() : classPointer->isValid();
}

API_EXPORT void NxConvexShape_saveToDesc(NxConvexShape* classPointer, bool call_explicit, NxConvexShapeDesc* desc)
{
    classPointer->saveToDesc(*desc);
}

API_EXPORT NxConvexMesh* NxConvexShape_getConvexMesh(NxConvexShape* classPointer, bool call_explicit)
{
    return &classPointer->getConvexMesh();
}

API_EXPORT const NxConvexMesh* NxConvexShape_getConvexMesh_1(NxConvexShape* classPointer, bool call_explicit)
{
    return &classPointer->getConvexMesh();
}

API_EXPORT void set_NxConvexShapeDesc_meshData(NxConvexShapeDesc* classPointer, NxConvexMesh* newvalue)
{
    classPointer->meshData = newvalue;
}

API_EXPORT NxConvexMesh* get_NxConvexShapeDesc_meshData(NxConvexShapeDesc* classPointer)
{
    return classPointer->meshData;
}

API_EXPORT void set_NxConvexShapeDesc_meshFlags(NxConvexShapeDesc* classPointer, NxU32 newvalue)
{
    classPointer->meshFlags = newvalue;
}

API_EXPORT NxU32 get_NxConvexShapeDesc_meshFlags(NxConvexShapeDesc* classPointer)
{
    return classPointer->meshFlags;
}

API_EXPORT NxConvexShapeDesc* new_NxConvexShapeDesc(bool do_override)
{
    return (do_override) ? new NxConvexShapeDesc_doxybind() : new NxConvexShapeDesc();
}

API_EXPORT void NxConvexShapeDesc_setToDefault(NxConvexShapeDesc* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxConvexShapeDesc::setToDefault() : classPointer->setToDefault();
}

API_EXPORT bool NxConvexShapeDesc_isValid(NxConvexShapeDesc* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxConvexShapeDesc::isValid() : classPointer->isValid();
}

API_EXPORT bool NxCookingInterface_NxSetCookingParams(NxCookingInterface* classPointer, bool call_explicit, NxCookingParams* params)
{
    return classPointer->NxSetCookingParams(*params);
}

API_EXPORT const NxCookingParams* NxCookingInterface_NxGetCookingParams(NxCookingInterface* classPointer, bool call_explicit)
{
    return &classPointer->NxGetCookingParams();
}

API_EXPORT bool NxCookingInterface_NxPlatformMismatch(NxCookingInterface* classPointer, bool call_explicit)
{
    return classPointer->NxPlatformMismatch();
}

API_EXPORT bool NxCookingInterface_NxInitCooking(NxCookingInterface* classPointer, bool call_explicit, NxUserAllocator* allocator, NxUserOutputStream* outputStream)
{
    return classPointer->NxInitCooking(allocator, outputStream);
}

API_EXPORT bool NxCookingInterface_NxInitCooking_1(NxCookingInterface* classPointer, bool call_explicit, NxUserAllocator* allocator)
{
    return classPointer->NxInitCooking(allocator);
}

API_EXPORT void NxCookingInterface_NxCloseCooking(NxCookingInterface* classPointer, bool call_explicit)
{
    classPointer->NxCloseCooking();
}

API_EXPORT bool NxCookingInterface_NxCookTriangleMesh(NxCookingInterface* classPointer, bool call_explicit, NxTriangleMeshDesc* desc, NxStream* stream)
{
    return classPointer->NxCookTriangleMesh(*desc, *stream);
}

API_EXPORT bool NxCookingInterface_NxCookConvexMesh(NxCookingInterface* classPointer, bool call_explicit, NxConvexMeshDesc* desc, NxStream* stream)
{
    return classPointer->NxCookConvexMesh(*desc, *stream);
}

API_EXPORT bool NxCookingInterface_NxCookClothMesh(NxCookingInterface* classPointer, bool call_explicit, NxClothMeshDesc* desc, NxStream* stream)
{
    return classPointer->NxCookClothMesh(*desc, *stream);
}

API_EXPORT bool NxCookingInterface_NxCookSoftBodyMesh(NxCookingInterface* classPointer, bool call_explicit, NxSoftBodyMeshDesc* desc, NxStream* stream)
{
    return classPointer->NxCookSoftBodyMesh(*desc, *stream);
}

API_EXPORT bool NxCookingInterface_NxCreatePMap(NxCookingInterface* classPointer, bool call_explicit, NxPMap* pmap, NxTriangleMesh* mesh, NxU32 density, NxUserOutputStream* outputStream)
{
    return classPointer->NxCreatePMap(*pmap, *mesh, density, outputStream);
}

API_EXPORT bool NxCookingInterface_NxCreatePMap_1(NxCookingInterface* classPointer, bool call_explicit, NxPMap* pmap, NxTriangleMesh* mesh, NxU32 density)
{
    return classPointer->NxCreatePMap(*pmap, *mesh, density);
}

API_EXPORT bool NxCookingInterface_NxReleasePMap(NxCookingInterface* classPointer, bool call_explicit, NxPMap* pmap)
{
    return classPointer->NxReleasePMap(*pmap);
}

API_EXPORT bool NxCookingInterface_NxScaleCookedConvexMesh(NxCookingInterface* classPointer, bool call_explicit, NxStream* source, NxReal scale, NxStream* dest)
{
    return classPointer->NxScaleCookedConvexMesh(*source, scale, *dest);
}

API_EXPORT void NxCookingInterface_NxReportCooking(NxCookingInterface* classPointer, bool call_explicit)
{
    classPointer->NxReportCooking();
}

API_EXPORT void set_NxCookingParams_targetPlatform(NxCookingParams* classPointer, NxPlatform newvalue)
{
    classPointer->targetPlatform = newvalue;
}

API_EXPORT NxPlatform get_NxCookingParams_targetPlatform(NxCookingParams* classPointer)
{
    return classPointer->targetPlatform;
}

API_EXPORT void set_NxCookingParams_skinWidth(NxCookingParams* classPointer, float newvalue)
{
    classPointer->skinWidth = newvalue;
}

API_EXPORT float get_NxCookingParams_skinWidth(NxCookingParams* classPointer)
{
    return classPointer->skinWidth;
}

API_EXPORT void set_NxCookingParams_hintCollisionSpeed(NxCookingParams* classPointer, bool newvalue)
{
    classPointer->hintCollisionSpeed = newvalue;
}

API_EXPORT bool get_NxCookingParams_hintCollisionSpeed(NxCookingParams* classPointer)
{
    return classPointer->hintCollisionSpeed;
}

API_EXPORT void NxJoint_setLimitPoint(NxJoint* classPointer, bool call_explicit, NxVec3& point, bool pointIsOnActor2)
{
    classPointer->setLimitPoint(point, pointIsOnActor2);
}

API_EXPORT void NxJoint_setLimitPoint_1(NxJoint* classPointer, bool call_explicit, NxVec3& point)
{
    classPointer->setLimitPoint(point);
}

API_EXPORT bool NxJoint_getLimitPoint(NxJoint* classPointer, bool call_explicit, NxVec3& worldLimitPoint)
{
    return classPointer->getLimitPoint(worldLimitPoint);
}

API_EXPORT bool NxJoint_addLimitPlane(NxJoint* classPointer, bool call_explicit, NxVec3& normal, NxVec3& pointInPlane, NxReal restitution)
{
    return classPointer->addLimitPlane(normal, pointInPlane, restitution);
}

API_EXPORT bool NxJoint_addLimitPlane_1(NxJoint* classPointer, bool call_explicit, NxVec3& normal, NxVec3& pointInPlane)
{
    return classPointer->addLimitPlane(normal, pointInPlane);
}

API_EXPORT void NxJoint_purgeLimitPlanes(NxJoint* classPointer, bool call_explicit)
{
    classPointer->purgeLimitPlanes();
}

API_EXPORT void NxJoint_resetLimitPlaneIterator(NxJoint* classPointer, bool call_explicit)
{
    classPointer->resetLimitPlaneIterator();
}

API_EXPORT bool NxJoint_hasMoreLimitPlanes(NxJoint* classPointer, bool call_explicit)
{
    return classPointer->hasMoreLimitPlanes();
}

API_EXPORT bool NxJoint_getNextLimitPlane(NxJoint* classPointer, bool call_explicit, NxVec3& planeNormal, NxReal& planeD, NxReal* restitution)
{
    return classPointer->getNextLimitPlane(planeNormal, planeD, restitution);
}

API_EXPORT bool NxJoint_getNextLimitPlane_1(NxJoint* classPointer, bool call_explicit, NxVec3& planeNormal, NxReal& planeD)
{
    return classPointer->getNextLimitPlane(planeNormal, planeD);
}

API_EXPORT void* NxJoint_is(NxJoint* classPointer, bool call_explicit, NxJointType type)
{
    return classPointer->is(type);
}

API_EXPORT NxRevoluteJoint* NxJoint_isRevoluteJoint(NxJoint* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxJoint::isRevoluteJoint() : classPointer->isRevoluteJoint();
}

API_EXPORT NxPointInPlaneJoint* NxJoint_isPointInPlaneJoint(NxJoint* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxJoint::isPointInPlaneJoint() : classPointer->isPointInPlaneJoint();
}

API_EXPORT NxPointOnLineJoint* NxJoint_isPointOnLineJoint(NxJoint* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxJoint::isPointOnLineJoint() : classPointer->isPointOnLineJoint();
}

API_EXPORT NxD6Joint* NxJoint_isD6Joint(NxJoint* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxJoint::isD6Joint() : classPointer->isD6Joint();
}

API_EXPORT NxPrismaticJoint* NxJoint_isPrismaticJoint(NxJoint* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxJoint::isPrismaticJoint() : classPointer->isPrismaticJoint();
}

API_EXPORT NxCylindricalJoint* NxJoint_isCylindricalJoint(NxJoint* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxJoint::isCylindricalJoint() : classPointer->isCylindricalJoint();
}

API_EXPORT NxSphericalJoint* NxJoint_isSphericalJoint(NxJoint* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxJoint::isSphericalJoint() : classPointer->isSphericalJoint();
}

API_EXPORT NxFixedJoint* NxJoint_isFixedJoint(NxJoint* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxJoint::isFixedJoint() : classPointer->isFixedJoint();
}

API_EXPORT NxDistanceJoint* NxJoint_isDistanceJoint(NxJoint* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxJoint::isDistanceJoint() : classPointer->isDistanceJoint();
}

API_EXPORT NxPulleyJoint* NxJoint_isPulleyJoint(NxJoint* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxJoint::isPulleyJoint() : classPointer->isPulleyJoint();
}

API_EXPORT void set_NxJoint_userData(NxJoint* classPointer, void* newvalue)
{
    classPointer->userData = newvalue;
}

API_EXPORT void* get_NxJoint_userData(NxJoint* classPointer)
{
    return classPointer->userData;
}

API_EXPORT void set_NxJoint_appData(NxJoint* classPointer, void* newvalue)
{
    classPointer->appData = newvalue;
}

API_EXPORT void* get_NxJoint_appData(NxJoint* classPointer)
{
    return classPointer->appData;
}

API_EXPORT NxJoint* new_NxJoint(bool do_override)
{
    return (do_override) ? new NxJoint_doxybind() : NULL;
}

API_EXPORT void NxJoint_getActors(NxJoint* classPointer, bool call_explicit, NxActor** actor1, NxActor** actor2)
{
    classPointer->getActors(actor1, actor2);
}

API_EXPORT void NxJoint_setGlobalAnchor(NxJoint* classPointer, bool call_explicit, NxVec3& vec)
{
    classPointer->setGlobalAnchor(vec);
}

API_EXPORT void NxJoint_setGlobalAxis(NxJoint* classPointer, bool call_explicit, NxVec3& vec)
{
    classPointer->setGlobalAxis(vec);
}

API_EXPORT NxVec3 NxJoint_getGlobalAnchor(NxJoint* classPointer, bool call_explicit)
{
    return classPointer->getGlobalAnchor();
}

API_EXPORT NxVec3 NxJoint_getGlobalAxis(NxJoint* classPointer, bool call_explicit)
{
    return classPointer->getGlobalAxis();
}

API_EXPORT NxJointState NxJoint_getState(NxJoint* classPointer, bool call_explicit)
{
    return classPointer->getState();
}

API_EXPORT void NxJoint_setBreakable(NxJoint* classPointer, bool call_explicit, NxReal maxForce, NxReal maxTorque)
{
    classPointer->setBreakable(maxForce, maxTorque);
}

API_EXPORT void NxJoint_getBreakable(NxJoint* classPointer, bool call_explicit, NxReal& maxForce, NxReal& maxTorque)
{
    classPointer->getBreakable(maxForce, maxTorque);
}

API_EXPORT void NxJoint_setSolverExtrapolationFactor(NxJoint* classPointer, bool call_explicit, NxReal solverExtrapolationFactor)
{
    classPointer->setSolverExtrapolationFactor(solverExtrapolationFactor);
}

API_EXPORT NxReal NxJoint_getSolverExtrapolationFactor(NxJoint* classPointer, bool call_explicit)
{
    return classPointer->getSolverExtrapolationFactor();
}

API_EXPORT void NxJoint_setUseAccelerationSpring(NxJoint* classPointer, bool call_explicit, bool b)
{
    classPointer->setUseAccelerationSpring(b);
}

API_EXPORT bool NxJoint_getUseAccelerationSpring(NxJoint* classPointer, bool call_explicit)
{
    return classPointer->getUseAccelerationSpring();
}

API_EXPORT NxJointType NxJoint_getType(NxJoint* classPointer, bool call_explicit)
{
    return classPointer->getType();
}

API_EXPORT void NxJoint_setName(NxJoint* classPointer, bool call_explicit, char* name)
{
    classPointer->setName(name);
}

API_EXPORT const char* NxJoint_getName(NxJoint* classPointer, bool call_explicit)
{
    return classPointer->getName();
}

API_EXPORT NxScene* NxJoint_getScene(NxJoint* classPointer, bool call_explicit)
{
    return &classPointer->getScene();
}

API_EXPORT void NxCylindricalJoint_loadFromDesc(NxCylindricalJoint* classPointer, bool call_explicit, NxCylindricalJointDesc* desc)
{
    classPointer->loadFromDesc(*desc);
}

API_EXPORT void NxCylindricalJoint_saveToDesc(NxCylindricalJoint* classPointer, bool call_explicit, NxCylindricalJointDesc* desc)
{
    classPointer->saveToDesc(*desc);
}

API_EXPORT void set_NxJointDesc_actor(NxJointDesc* classPointer, NxActor* newvalue[2])
{
    memcpy(&classPointer->actor[0], &newvalue[0], sizeof(NxActor*) * 2);
}

API_EXPORT void get_NxJointDesc_actor(NxJointDesc* classPointer, NxActor* newvalue[2])
{
    memcpy(&newvalue[0], &classPointer->actor[0], sizeof(NxActor*) * 2);
}

API_EXPORT void set_NxJointDesc_localNormal(NxJointDesc* classPointer, NxVec3 newvalue[2])
{
    memcpy(&classPointer->localNormal[0], &newvalue[0], sizeof(NxVec3) * 2);
}

API_EXPORT void get_NxJointDesc_localNormal(NxJointDesc* classPointer, NxVec3 newvalue[2])
{
    memcpy(&newvalue[0], &classPointer->localNormal[0], sizeof(NxVec3) * 2);
}

API_EXPORT void set_NxJointDesc_localAxis(NxJointDesc* classPointer, NxVec3 newvalue[2])
{
    memcpy(&classPointer->localAxis[0], &newvalue[0], sizeof(NxVec3) * 2);
}

API_EXPORT void get_NxJointDesc_localAxis(NxJointDesc* classPointer, NxVec3 newvalue[2])
{
    memcpy(&newvalue[0], &classPointer->localAxis[0], sizeof(NxVec3) * 2);
}

API_EXPORT void set_NxJointDesc_localAnchor(NxJointDesc* classPointer, NxVec3 newvalue[2])
{
    memcpy(&classPointer->localAnchor[0], &newvalue[0], sizeof(NxVec3) * 2);
}

API_EXPORT void get_NxJointDesc_localAnchor(NxJointDesc* classPointer, NxVec3 newvalue[2])
{
    memcpy(&newvalue[0], &classPointer->localAnchor[0], sizeof(NxVec3) * 2);
}

API_EXPORT void set_NxJointDesc_maxForce(NxJointDesc* classPointer, NxReal newvalue)
{
    classPointer->maxForce = newvalue;
}

API_EXPORT NxReal get_NxJointDesc_maxForce(NxJointDesc* classPointer)
{
    return classPointer->maxForce;
}

API_EXPORT void set_NxJointDesc_maxTorque(NxJointDesc* classPointer, NxReal newvalue)
{
    classPointer->maxTorque = newvalue;
}

API_EXPORT NxReal get_NxJointDesc_maxTorque(NxJointDesc* classPointer)
{
    return classPointer->maxTorque;
}

API_EXPORT void set_NxJointDesc_solverExtrapolationFactor(NxJointDesc* classPointer, NxReal newvalue)
{
    classPointer->solverExtrapolationFactor = newvalue;
}

API_EXPORT NxReal get_NxJointDesc_solverExtrapolationFactor(NxJointDesc* classPointer)
{
    return classPointer->solverExtrapolationFactor;
}

API_EXPORT void set_NxJointDesc_useAccelerationSpring(NxJointDesc* classPointer, NxU32 newvalue)
{
    classPointer->useAccelerationSpring = newvalue;
}

API_EXPORT NxU32 get_NxJointDesc_useAccelerationSpring(NxJointDesc* classPointer)
{
    return classPointer->useAccelerationSpring;
}

API_EXPORT void set_NxJointDesc_userData(NxJointDesc* classPointer, void* newvalue)
{
    classPointer->userData = newvalue;
}

API_EXPORT void* get_NxJointDesc_userData(NxJointDesc* classPointer)
{
    return classPointer->userData;
}

API_EXPORT void set_NxJointDesc_name(NxJointDesc* classPointer, const char* newvalue)
{
    classPointer->name = newvalue;
}

API_EXPORT const char* get_NxJointDesc_name(NxJointDesc* classPointer)
{
    return classPointer->name;
}

API_EXPORT void set_NxJointDesc_jointFlags(NxJointDesc* classPointer, NxU32 newvalue)
{
    classPointer->jointFlags = newvalue;
}

API_EXPORT NxU32 get_NxJointDesc_jointFlags(NxJointDesc* classPointer)
{
    return classPointer->jointFlags;
}

API_EXPORT void NxJointDesc_setToDefault(NxJointDesc* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxJointDesc::setToDefault() : classPointer->setToDefault();
}

API_EXPORT bool NxJointDesc_isValid(NxJointDesc* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxJointDesc::isValid() : classPointer->isValid();
}

API_EXPORT void NxJointDesc_setGlobalAnchor(NxJointDesc* classPointer, bool call_explicit, NxVec3& wsAnchor)
{
    (call_explicit) ? classPointer->NxJointDesc::setGlobalAnchor(wsAnchor) : classPointer->setGlobalAnchor(wsAnchor);
}

API_EXPORT void NxJointDesc_setGlobalAxis(NxJointDesc* classPointer, bool call_explicit, NxVec3& wsAxis)
{
    (call_explicit) ? classPointer->NxJointDesc::setGlobalAxis(wsAxis) : classPointer->setGlobalAxis(wsAxis);
}

API_EXPORT NxJointType NxJointDesc_getType(NxJointDesc* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxJointDesc::getType() : classPointer->getType();
}

API_EXPORT NxJointDesc* new_NxJointDesc(bool do_override, NxJointType t)
{
    return (do_override) ? new NxJointDesc_doxybind(t) : NULL;
}

API_EXPORT NxCylindricalJointDesc* new_NxCylindricalJointDesc(bool do_override)
{
    return (do_override) ? new NxCylindricalJointDesc_doxybind() : new NxCylindricalJointDesc();
}

API_EXPORT void NxCylindricalJointDesc_setToDefault(NxCylindricalJointDesc* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxCylindricalJointDesc::setToDefault() : classPointer->setToDefault();
}

API_EXPORT bool NxCylindricalJointDesc_isValid(NxCylindricalJointDesc* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxCylindricalJointDesc::isValid() : classPointer->isValid();
}

API_EXPORT void NxD6Joint_loadFromDesc(NxD6Joint* classPointer, bool call_explicit, NxD6JointDesc* desc)
{
    classPointer->loadFromDesc(*desc);
}

API_EXPORT void NxD6Joint_saveToDesc(NxD6Joint* classPointer, bool call_explicit, NxD6JointDesc* desc)
{
    classPointer->saveToDesc(*desc);
}

API_EXPORT void NxD6Joint_setDrivePosition(NxD6Joint* classPointer, bool call_explicit, NxVec3& position)
{
    classPointer->setDrivePosition(position);
}

API_EXPORT void NxD6Joint_setDriveOrientation(NxD6Joint* classPointer, bool call_explicit, NxQuat& orientation)
{
    classPointer->setDriveOrientation(orientation);
}

API_EXPORT void NxD6Joint_setDriveLinearVelocity(NxD6Joint* classPointer, bool call_explicit, NxVec3& linVel)
{
    classPointer->setDriveLinearVelocity(linVel);
}

API_EXPORT void NxD6Joint_setDriveAngularVelocity(NxD6Joint* classPointer, bool call_explicit, NxVec3& angVel)
{
    classPointer->setDriveAngularVelocity(angVel);
}

API_EXPORT void set_NxD6JointDesc_xMotion(NxD6JointDesc* classPointer, NxD6JointMotion newvalue)
{
    classPointer->xMotion = newvalue;
}

API_EXPORT NxD6JointMotion get_NxD6JointDesc_xMotion(NxD6JointDesc* classPointer)
{
    return classPointer->xMotion;
}

API_EXPORT void set_NxD6JointDesc_yMotion(NxD6JointDesc* classPointer, NxD6JointMotion newvalue)
{
    classPointer->yMotion = newvalue;
}

API_EXPORT NxD6JointMotion get_NxD6JointDesc_yMotion(NxD6JointDesc* classPointer)
{
    return classPointer->yMotion;
}

API_EXPORT void set_NxD6JointDesc_zMotion(NxD6JointDesc* classPointer, NxD6JointMotion newvalue)
{
    classPointer->zMotion = newvalue;
}

API_EXPORT NxD6JointMotion get_NxD6JointDesc_zMotion(NxD6JointDesc* classPointer)
{
    return classPointer->zMotion;
}

API_EXPORT void set_NxD6JointDesc_swing1Motion(NxD6JointDesc* classPointer, NxD6JointMotion newvalue)
{
    classPointer->swing1Motion = newvalue;
}

API_EXPORT NxD6JointMotion get_NxD6JointDesc_swing1Motion(NxD6JointDesc* classPointer)
{
    return classPointer->swing1Motion;
}

API_EXPORT void set_NxD6JointDesc_swing2Motion(NxD6JointDesc* classPointer, NxD6JointMotion newvalue)
{
    classPointer->swing2Motion = newvalue;
}

API_EXPORT NxD6JointMotion get_NxD6JointDesc_swing2Motion(NxD6JointDesc* classPointer)
{
    return classPointer->swing2Motion;
}

API_EXPORT void set_NxD6JointDesc_twistMotion(NxD6JointDesc* classPointer, NxD6JointMotion newvalue)
{
    classPointer->twistMotion = newvalue;
}

API_EXPORT NxD6JointMotion get_NxD6JointDesc_twistMotion(NxD6JointDesc* classPointer)
{
    return classPointer->twistMotion;
}

API_EXPORT void set_NxD6JointDesc_linearLimit(NxD6JointDesc* classPointer, NxJointLimitSoftDesc* newvalue)
{
    classPointer->linearLimit = *newvalue;
}

API_EXPORT NxJointLimitSoftDesc* get_NxD6JointDesc_linearLimit(NxD6JointDesc* classPointer)
{
    return &classPointer->linearLimit;
}

API_EXPORT void set_NxD6JointDesc_swing1Limit(NxD6JointDesc* classPointer, NxJointLimitSoftDesc* newvalue)
{
    classPointer->swing1Limit = *newvalue;
}

API_EXPORT NxJointLimitSoftDesc* get_NxD6JointDesc_swing1Limit(NxD6JointDesc* classPointer)
{
    return &classPointer->swing1Limit;
}

API_EXPORT void set_NxD6JointDesc_swing2Limit(NxD6JointDesc* classPointer, NxJointLimitSoftDesc* newvalue)
{
    classPointer->swing2Limit = *newvalue;
}

API_EXPORT NxJointLimitSoftDesc* get_NxD6JointDesc_swing2Limit(NxD6JointDesc* classPointer)
{
    return &classPointer->swing2Limit;
}

API_EXPORT void set_NxD6JointDesc_twistLimit(NxD6JointDesc* classPointer, NxJointLimitSoftPairDesc* newvalue)
{
    classPointer->twistLimit = *newvalue;
}

API_EXPORT NxJointLimitSoftPairDesc* get_NxD6JointDesc_twistLimit(NxD6JointDesc* classPointer)
{
    return &classPointer->twistLimit;
}

API_EXPORT void set_NxD6JointDesc_xDrive(NxD6JointDesc* classPointer, NxJointDriveDesc* newvalue)
{
    classPointer->xDrive = *newvalue;
}

API_EXPORT NxJointDriveDesc* get_NxD6JointDesc_xDrive(NxD6JointDesc* classPointer)
{
    return &classPointer->xDrive;
}

API_EXPORT void set_NxD6JointDesc_yDrive(NxD6JointDesc* classPointer, NxJointDriveDesc* newvalue)
{
    classPointer->yDrive = *newvalue;
}

API_EXPORT NxJointDriveDesc* get_NxD6JointDesc_yDrive(NxD6JointDesc* classPointer)
{
    return &classPointer->yDrive;
}

API_EXPORT void set_NxD6JointDesc_zDrive(NxD6JointDesc* classPointer, NxJointDriveDesc* newvalue)
{
    classPointer->zDrive = *newvalue;
}

API_EXPORT NxJointDriveDesc* get_NxD6JointDesc_zDrive(NxD6JointDesc* classPointer)
{
    return &classPointer->zDrive;
}

API_EXPORT void set_NxD6JointDesc_swingDrive(NxD6JointDesc* classPointer, NxJointDriveDesc* newvalue)
{
    classPointer->swingDrive = *newvalue;
}

API_EXPORT NxJointDriveDesc* get_NxD6JointDesc_swingDrive(NxD6JointDesc* classPointer)
{
    return &classPointer->swingDrive;
}

API_EXPORT void set_NxD6JointDesc_twistDrive(NxD6JointDesc* classPointer, NxJointDriveDesc* newvalue)
{
    classPointer->twistDrive = *newvalue;
}

API_EXPORT NxJointDriveDesc* get_NxD6JointDesc_twistDrive(NxD6JointDesc* classPointer)
{
    return &classPointer->twistDrive;
}

API_EXPORT void set_NxD6JointDesc_slerpDrive(NxD6JointDesc* classPointer, NxJointDriveDesc* newvalue)
{
    classPointer->slerpDrive = *newvalue;
}

API_EXPORT NxJointDriveDesc* get_NxD6JointDesc_slerpDrive(NxD6JointDesc* classPointer)
{
    return &classPointer->slerpDrive;
}

API_EXPORT void set_NxD6JointDesc_drivePosition(NxD6JointDesc* classPointer, NxVec3 newvalue)
{
    classPointer->drivePosition = newvalue;
}

API_EXPORT NxVec3 get_NxD6JointDesc_drivePosition(NxD6JointDesc* classPointer)
{
    return classPointer->drivePosition;
}

API_EXPORT void set_NxD6JointDesc_driveOrientation(NxD6JointDesc* classPointer, NxQuat newvalue)
{
    classPointer->driveOrientation = newvalue;
}

API_EXPORT NxQuat get_NxD6JointDesc_driveOrientation(NxD6JointDesc* classPointer)
{
    return classPointer->driveOrientation;
}

API_EXPORT void set_NxD6JointDesc_driveLinearVelocity(NxD6JointDesc* classPointer, NxVec3 newvalue)
{
    classPointer->driveLinearVelocity = newvalue;
}

API_EXPORT NxVec3 get_NxD6JointDesc_driveLinearVelocity(NxD6JointDesc* classPointer)
{
    return classPointer->driveLinearVelocity;
}

API_EXPORT void set_NxD6JointDesc_driveAngularVelocity(NxD6JointDesc* classPointer, NxVec3 newvalue)
{
    classPointer->driveAngularVelocity = newvalue;
}

API_EXPORT NxVec3 get_NxD6JointDesc_driveAngularVelocity(NxD6JointDesc* classPointer)
{
    return classPointer->driveAngularVelocity;
}

API_EXPORT void set_NxD6JointDesc_projectionMode(NxD6JointDesc* classPointer, NxJointProjectionMode newvalue)
{
    classPointer->projectionMode = newvalue;
}

API_EXPORT NxJointProjectionMode get_NxD6JointDesc_projectionMode(NxD6JointDesc* classPointer)
{
    return classPointer->projectionMode;
}

API_EXPORT void set_NxD6JointDesc_projectionDistance(NxD6JointDesc* classPointer, NxReal newvalue)
{
    classPointer->projectionDistance = newvalue;
}

API_EXPORT NxReal get_NxD6JointDesc_projectionDistance(NxD6JointDesc* classPointer)
{
    return classPointer->projectionDistance;
}

API_EXPORT void set_NxD6JointDesc_projectionAngle(NxD6JointDesc* classPointer, NxReal newvalue)
{
    classPointer->projectionAngle = newvalue;
}

API_EXPORT NxReal get_NxD6JointDesc_projectionAngle(NxD6JointDesc* classPointer)
{
    return classPointer->projectionAngle;
}

API_EXPORT void set_NxD6JointDesc_gearRatio(NxD6JointDesc* classPointer, NxReal newvalue)
{
    classPointer->gearRatio = newvalue;
}

API_EXPORT NxReal get_NxD6JointDesc_gearRatio(NxD6JointDesc* classPointer)
{
    return classPointer->gearRatio;
}

API_EXPORT void set_NxD6JointDesc_flags(NxD6JointDesc* classPointer, NxU32 newvalue)
{
    classPointer->flags = newvalue;
}

API_EXPORT NxU32 get_NxD6JointDesc_flags(NxD6JointDesc* classPointer)
{
    return classPointer->flags;
}

API_EXPORT NxD6JointDesc* new_NxD6JointDesc(bool do_override)
{
    return (do_override) ? new NxD6JointDesc_doxybind() : new NxD6JointDesc();
}

API_EXPORT void NxD6JointDesc_setToDefault(NxD6JointDesc* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxD6JointDesc::setToDefault() : classPointer->setToDefault();
}

API_EXPORT bool NxD6JointDesc_isValid(NxD6JointDesc* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxD6JointDesc::isValid() : classPointer->isValid();
}

API_EXPORT void set_NxDebugLine_p0(NxDebugLine* classPointer, NxVec3 newvalue)
{
    classPointer->p0 = newvalue;
}

API_EXPORT NxVec3 get_NxDebugLine_p0(NxDebugLine* classPointer)
{
    return classPointer->p0;
}

API_EXPORT void set_NxDebugLine_p1(NxDebugLine* classPointer, NxVec3 newvalue)
{
    classPointer->p1 = newvalue;
}

API_EXPORT NxVec3 get_NxDebugLine_p1(NxDebugLine* classPointer)
{
    return classPointer->p1;
}

API_EXPORT void set_NxDebugLine_color(NxDebugLine* classPointer, NxU32 newvalue)
{
    classPointer->color = newvalue;
}

API_EXPORT NxU32 get_NxDebugLine_color(NxDebugLine* classPointer)
{
    return classPointer->color;
}

API_EXPORT void set_NxDebugPoint_p(NxDebugPoint* classPointer, NxVec3 newvalue)
{
    classPointer->p = newvalue;
}

API_EXPORT NxVec3 get_NxDebugPoint_p(NxDebugPoint* classPointer)
{
    return classPointer->p;
}

API_EXPORT void set_NxDebugPoint_color(NxDebugPoint* classPointer, NxU32 newvalue)
{
    classPointer->color = newvalue;
}

API_EXPORT NxU32 get_NxDebugPoint_color(NxDebugPoint* classPointer)
{
    return classPointer->color;
}

API_EXPORT NxDebugRenderable* new_NxDebugRenderable(bool do_override, NxU32 np, NxDebugPoint* p, NxU32 nl, NxDebugLine* l, NxU32 nt, NxDebugTriangle* t)
{
    return new NxDebugRenderable(np, p, nl, l, nt, t);
}

API_EXPORT NxU32 NxDebugRenderable_getNbPoints(NxDebugRenderable* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxDebugRenderable::getNbPoints() : classPointer->getNbPoints();
}

API_EXPORT const NxDebugPoint* NxDebugRenderable_getPoints(NxDebugRenderable* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxDebugRenderable::getPoints() : classPointer->getPoints();
}

API_EXPORT NxU32 NxDebugRenderable_getNbLines(NxDebugRenderable* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxDebugRenderable::getNbLines() : classPointer->getNbLines();
}

API_EXPORT const NxDebugLine* NxDebugRenderable_getLines(NxDebugRenderable* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxDebugRenderable::getLines() : classPointer->getLines();
}

API_EXPORT NxU32 NxDebugRenderable_getNbTriangles(NxDebugRenderable* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxDebugRenderable::getNbTriangles() : classPointer->getNbTriangles();
}

API_EXPORT const NxDebugTriangle* NxDebugRenderable_getTriangles(NxDebugRenderable* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxDebugRenderable::getTriangles() : classPointer->getTriangles();
}

API_EXPORT void set_NxDebugTriangle_p0(NxDebugTriangle* classPointer, NxVec3 newvalue)
{
    classPointer->p0 = newvalue;
}

API_EXPORT NxVec3 get_NxDebugTriangle_p0(NxDebugTriangle* classPointer)
{
    return classPointer->p0;
}

API_EXPORT void set_NxDebugTriangle_p1(NxDebugTriangle* classPointer, NxVec3 newvalue)
{
    classPointer->p1 = newvalue;
}

API_EXPORT NxVec3 get_NxDebugTriangle_p1(NxDebugTriangle* classPointer)
{
    return classPointer->p1;
}

API_EXPORT void set_NxDebugTriangle_p2(NxDebugTriangle* classPointer, NxVec3 newvalue)
{
    classPointer->p2 = newvalue;
}

API_EXPORT NxVec3 get_NxDebugTriangle_p2(NxDebugTriangle* classPointer)
{
    return classPointer->p2;
}

API_EXPORT void set_NxDebugTriangle_color(NxDebugTriangle* classPointer, NxU32 newvalue)
{
    classPointer->color = newvalue;
}

API_EXPORT NxU32 get_NxDebugTriangle_color(NxDebugTriangle* classPointer)
{
    return classPointer->color;
}

API_EXPORT void NxDistanceJoint_loadFromDesc(NxDistanceJoint* classPointer, bool call_explicit, NxDistanceJointDesc* desc)
{
    classPointer->loadFromDesc(*desc);
}

API_EXPORT void NxDistanceJoint_saveToDesc(NxDistanceJoint* classPointer, bool call_explicit, NxDistanceJointDesc* desc)
{
    classPointer->saveToDesc(*desc);
}

API_EXPORT void set_NxDistanceJointDesc_maxDistance(NxDistanceJointDesc* classPointer, NxReal newvalue)
{
    classPointer->maxDistance = newvalue;
}

API_EXPORT NxReal get_NxDistanceJointDesc_maxDistance(NxDistanceJointDesc* classPointer)
{
    return classPointer->maxDistance;
}

API_EXPORT void set_NxDistanceJointDesc_minDistance(NxDistanceJointDesc* classPointer, NxReal newvalue)
{
    classPointer->minDistance = newvalue;
}

API_EXPORT NxReal get_NxDistanceJointDesc_minDistance(NxDistanceJointDesc* classPointer)
{
    return classPointer->minDistance;
}

API_EXPORT void set_NxDistanceJointDesc_spring(NxDistanceJointDesc* classPointer, NxSpringDesc* newvalue)
{
    classPointer->spring = *newvalue;
}

API_EXPORT NxSpringDesc* get_NxDistanceJointDesc_spring(NxDistanceJointDesc* classPointer)
{
    return &classPointer->spring;
}

API_EXPORT void set_NxDistanceJointDesc_flags(NxDistanceJointDesc* classPointer, NxU32 newvalue)
{
    classPointer->flags = newvalue;
}

API_EXPORT NxU32 get_NxDistanceJointDesc_flags(NxDistanceJointDesc* classPointer)
{
    return classPointer->flags;
}

API_EXPORT NxDistanceJointDesc* new_NxDistanceJointDesc(bool do_override)
{
    return (do_override) ? new NxDistanceJointDesc_doxybind() : new NxDistanceJointDesc();
}

API_EXPORT void NxDistanceJointDesc_setToDefault(NxDistanceJointDesc* classPointer, bool call_explicit, bool fromCtor)
{
    (call_explicit) ? classPointer->NxDistanceJointDesc::setToDefault(fromCtor) : classPointer->setToDefault(fromCtor);
}

API_EXPORT bool NxDistanceJointDesc_isValid(NxDistanceJointDesc* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxDistanceJointDesc::isValid() : classPointer->isValid();
}

API_EXPORT void set_NxEffector_userData(NxEffector* classPointer, void* newvalue)
{
    classPointer->userData = newvalue;
}

API_EXPORT void* get_NxEffector_userData(NxEffector* classPointer)
{
    return classPointer->userData;
}

API_EXPORT void set_NxEffector_appData(NxEffector* classPointer, void* newvalue)
{
    classPointer->appData = newvalue;
}

API_EXPORT void* get_NxEffector_appData(NxEffector* classPointer)
{
    return classPointer->appData;
}

API_EXPORT NxEffectorType NxEffector_getType(NxEffector* classPointer, bool call_explicit)
{
    return classPointer->getType();
}

API_EXPORT void* NxEffector_is(NxEffector* classPointer, bool call_explicit, NxEffectorType type)
{
    return (call_explicit) ? classPointer->NxEffector::is(type) : classPointer->is(type);
}

API_EXPORT const void* NxEffector_is_1(NxEffector* classPointer, bool call_explicit, NxEffectorType type)
{
    return (call_explicit) ? classPointer->NxEffector::is(type) : classPointer->is(type);
}

API_EXPORT NxSpringAndDamperEffector* NxEffector_isSpringAndDamperEffector(NxEffector* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxEffector::isSpringAndDamperEffector() : classPointer->isSpringAndDamperEffector();
}

API_EXPORT const NxSpringAndDamperEffector* NxEffector_isSpringAndDamperEffector_1(NxEffector* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxEffector::isSpringAndDamperEffector() : classPointer->isSpringAndDamperEffector();
}

API_EXPORT void NxEffector_setName(NxEffector* classPointer, bool call_explicit, char* name)
{
    classPointer->setName(name);
}

API_EXPORT const char* NxEffector_getName(NxEffector* classPointer, bool call_explicit)
{
    return classPointer->getName();
}

API_EXPORT NxScene* NxEffector_getScene(NxEffector* classPointer, bool call_explicit)
{
    return &classPointer->getScene();
}

API_EXPORT NxEffector* new_NxEffector(bool do_override)
{
    return (do_override) ? new NxEffector_doxybind() : NULL;
}

API_EXPORT void set_NxEffectorDesc_userData(NxEffectorDesc* classPointer, void* newvalue)
{
    classPointer->userData = newvalue;
}

API_EXPORT void* get_NxEffectorDesc_userData(NxEffectorDesc* classPointer)
{
    return classPointer->userData;
}

API_EXPORT void set_NxEffectorDesc_name(NxEffectorDesc* classPointer, const char* newvalue)
{
    classPointer->name = newvalue;
}

API_EXPORT const char* get_NxEffectorDesc_name(NxEffectorDesc* classPointer)
{
    return classPointer->name;
}

API_EXPORT void NxEffectorDesc_setToDefault(NxEffectorDesc* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxEffectorDesc::setToDefault() : classPointer->setToDefault();
}

API_EXPORT bool NxEffectorDesc_isValid(NxEffectorDesc* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxEffectorDesc::isValid() : classPointer->isValid();
}

API_EXPORT NxEffectorType NxEffectorDesc_getType(NxEffectorDesc* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxEffectorDesc::getType() : classPointer->getType();
}

API_EXPORT NxEffectorDesc* new_NxEffectorDesc(bool do_override, NxEffectorType type)
{
    return (do_override) ? new NxEffectorDesc_doxybind(type) : NULL;
}

API_EXPORT NxErrorCode NxException_getErrorCode(NxException* classPointer, bool call_explicit)
{
    return classPointer->getErrorCode();
}

API_EXPORT const char* NxException_getFile(NxException* classPointer, bool call_explicit)
{
    return classPointer->getFile();
}

API_EXPORT int NxException_getLine(NxException* classPointer, bool call_explicit)
{
    return classPointer->getLine();
}

API_EXPORT void set_NxExtendedBounds3_min(NxExtendedBounds3* classPointer, NxExtendedVec3 newvalue)
{
    classPointer->min = newvalue;
}

API_EXPORT NxExtendedVec3 get_NxExtendedBounds3_min(NxExtendedBounds3* classPointer)
{
    return classPointer->min;
}

API_EXPORT void set_NxExtendedBounds3_max(NxExtendedBounds3* classPointer, NxExtendedVec3 newvalue)
{
    classPointer->max = newvalue;
}

API_EXPORT NxExtendedVec3 get_NxExtendedBounds3_max(NxExtendedBounds3* classPointer)
{
    return classPointer->max;
}

API_EXPORT NxExtendedBounds3* new_NxExtendedBounds3(bool do_override)
{
    return new NxExtendedBounds3();
}

API_EXPORT void NxExtendedBounds3_setEmpty(NxExtendedBounds3* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxExtendedBounds3::setEmpty() : classPointer->setEmpty();
}

API_EXPORT void NxExtendedBounds3_set(NxExtendedBounds3* classPointer, bool call_explicit, Extended minx, Extended miny, Extended minz, Extended maxx, Extended maxy, Extended maxz)
{
    (call_explicit) ? classPointer->NxExtendedBounds3::set(minx, miny, minz, maxx, maxy, maxz) : classPointer->set(minx, miny, minz, maxx, maxy, maxz);
}

API_EXPORT void NxExtendedBounds3_set_1(NxExtendedBounds3* classPointer, bool call_explicit, NxExtendedVec3& _min, NxExtendedVec3& _max)
{
    (call_explicit) ? classPointer->NxExtendedBounds3::set(_min, _max) : classPointer->set(_min, _max);
}

API_EXPORT void NxExtendedBounds3_setCenterExtents(NxExtendedBounds3* classPointer, bool call_explicit, NxExtendedVec3& c, NxVec3& e)
{
    (call_explicit) ? classPointer->NxExtendedBounds3::setCenterExtents(c, e) : classPointer->setCenterExtents(c, e);
}

API_EXPORT void NxExtendedBounds3_getCenter(NxExtendedBounds3* classPointer, bool call_explicit, NxExtendedVec3& center)
{
    (call_explicit) ? classPointer->NxExtendedBounds3::getCenter(center) : classPointer->getCenter(center);
}

API_EXPORT Extended NxExtendedBounds3_getCenter_1(NxExtendedBounds3* classPointer, bool call_explicit, NxU32 axis)
{
    return (call_explicit) ? classPointer->NxExtendedBounds3::getCenter(axis) : classPointer->getCenter(axis);
}

API_EXPORT void NxExtendedBounds3_getExtents(NxExtendedBounds3* classPointer, bool call_explicit, NxVec3& extents)
{
    (call_explicit) ? classPointer->NxExtendedBounds3::getExtents(extents) : classPointer->getExtents(extents);
}

API_EXPORT Extended NxExtendedBounds3_getExtents_1(NxExtendedBounds3* classPointer, bool call_explicit, NxU32 axis)
{
    return (call_explicit) ? classPointer->NxExtendedBounds3::getExtents(axis) : classPointer->getExtents(axis);
}

API_EXPORT bool NxExtendedBounds3_intersect(NxExtendedBounds3* classPointer, bool call_explicit, NxExtendedBounds3* b)
{
    return (call_explicit) ? classPointer->NxExtendedBounds3::intersect(*b) : classPointer->intersect(*b);
}

API_EXPORT void NxExtendedBounds3_boundsOfOBB(NxExtendedBounds3* classPointer, bool call_explicit, NxMat33& orientation, NxExtendedVec3& translation, NxVec3& halfDims)
{
    (call_explicit) ? classPointer->NxExtendedBounds3::boundsOfOBB(orientation, translation, halfDims) : classPointer->boundsOfOBB(orientation, translation, halfDims);
}

API_EXPORT void NxExtendedBounds3_transform(NxExtendedBounds3* classPointer, bool call_explicit, NxMat33& orientation, NxExtendedVec3& translation)
{
    (call_explicit) ? classPointer->NxExtendedBounds3::transform(orientation, translation) : classPointer->transform(orientation, translation);
}

API_EXPORT void NxExtendedBounds3_add(NxExtendedBounds3* classPointer, bool call_explicit, NxExtendedBounds3* b2)
{
    (call_explicit) ? classPointer->NxExtendedBounds3::add(*b2) : classPointer->add(*b2);
}

API_EXPORT bool NxExtendedBounds3_isInside(NxExtendedBounds3* classPointer, bool call_explicit, NxExtendedBounds3* box)
{
    return (call_explicit) ? classPointer->NxExtendedBounds3::isInside(*box) : classPointer->isInside(*box);
}

API_EXPORT void NxExtendedBounds3_scale(NxExtendedBounds3* classPointer, bool call_explicit, NxF32 scale)
{
    (call_explicit) ? classPointer->NxExtendedBounds3::scale(scale) : classPointer->scale(scale);
}

API_EXPORT void set_NxExtendedBox_center(NxExtendedBox* classPointer, NxExtendedVec3 newvalue)
{
    classPointer->center = newvalue;
}

API_EXPORT NxExtendedVec3 get_NxExtendedBox_center(NxExtendedBox* classPointer)
{
    return classPointer->center;
}

API_EXPORT void set_NxExtendedBox_extents(NxExtendedBox* classPointer, NxVec3 newvalue)
{
    classPointer->extents = newvalue;
}

API_EXPORT NxVec3 get_NxExtendedBox_extents(NxExtendedBox* classPointer)
{
    return classPointer->extents;
}

API_EXPORT void set_NxExtendedBox_rot(NxExtendedBox* classPointer, NxMat33 newvalue)
{
    classPointer->rot = newvalue;
}

API_EXPORT NxMat33 get_NxExtendedBox_rot(NxExtendedBox* classPointer)
{
    return classPointer->rot;
}

API_EXPORT NxExtendedBox* new_NxExtendedBox(bool do_override)
{
    return new NxExtendedBox();
}

API_EXPORT NxExtendedBox* new_NxExtendedBox_1(bool do_override, NxExtendedVec3& _center, NxVec3& _extents, NxMat33& _rot)
{
    return new NxExtendedBox(_center, _extents, _rot);
}

API_EXPORT void set_NxExtendedSegment_p0(NxExtendedSegment* classPointer, NxExtendedVec3 newvalue)
{
    classPointer->p0 = newvalue;
}

API_EXPORT NxExtendedVec3 get_NxExtendedSegment_p0(NxExtendedSegment* classPointer)
{
    return classPointer->p0;
}

API_EXPORT void set_NxExtendedSegment_p1(NxExtendedSegment* classPointer, NxExtendedVec3 newvalue)
{
    classPointer->p1 = newvalue;
}

API_EXPORT NxExtendedVec3 get_NxExtendedSegment_p1(NxExtendedSegment* classPointer)
{
    return classPointer->p1;
}

API_EXPORT const NxExtendedVec3* NxExtendedSegment_getOrigin(NxExtendedSegment* classPointer, bool call_explicit)
{
    return (call_explicit) ? &classPointer->NxExtendedSegment::getOrigin() : &classPointer->getOrigin();
}

API_EXPORT void NxExtendedSegment_computeDirection(NxExtendedSegment* classPointer, bool call_explicit, NxVec3& dir)
{
    (call_explicit) ? classPointer->NxExtendedSegment::computeDirection(dir) : classPointer->computeDirection(dir);
}

API_EXPORT void NxExtendedSegment_computePoint(NxExtendedSegment* classPointer, bool call_explicit, NxExtendedVec3& pt, Extended t)
{
    (call_explicit) ? classPointer->NxExtendedSegment::computePoint(pt, t) : classPointer->computePoint(pt, t);
}

API_EXPORT void set_NxExtendedCapsule_radius(NxExtendedCapsule* classPointer, NxReal newvalue)
{
    classPointer->radius = newvalue;
}

API_EXPORT NxReal get_NxExtendedCapsule_radius(NxExtendedCapsule* classPointer)
{
    return classPointer->radius;
}

API_EXPORT void set_NxExtendedMat34_M(NxExtendedMat34* classPointer, NxMat33 newvalue)
{
    classPointer->M = newvalue;
}

API_EXPORT NxMat33 get_NxExtendedMat34_M(NxExtendedMat34* classPointer)
{
    return classPointer->M;
}

API_EXPORT void set_NxExtendedMat34_t(NxExtendedMat34* classPointer, NxExtendedVec3 newvalue)
{
    classPointer->t = newvalue;
}

API_EXPORT NxExtendedVec3 get_NxExtendedMat34_t(NxExtendedMat34* classPointer)
{
    return classPointer->t;
}

API_EXPORT NxExtendedMat34* new_NxExtendedMat34(bool do_override)
{
    return new NxExtendedMat34();
}

API_EXPORT NxExtendedMat34* new_NxExtendedMat34_1(bool do_override, NxMat33& M_, NxExtendedVec3& t_)
{
    return new NxExtendedMat34(M_, t_);
}

API_EXPORT NxExtendedMat34* new_NxExtendedMat34_2(bool do_override, bool init)
{
    return new NxExtendedMat34(init);
}

API_EXPORT bool NxExtendedMat34_isFinite(NxExtendedMat34* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxExtendedMat34::isFinite() : classPointer->isFinite();
}

API_EXPORT void NxExtendedMat34_multiply(NxExtendedMat34* classPointer, bool call_explicit, NxVec3& src, NxExtendedVec3& dst)
{
    (call_explicit) ? classPointer->NxExtendedMat34::multiply(src, dst) : classPointer->multiply(src, dst);
}

API_EXPORT void NxExtendedMat34_multiply_1(NxExtendedMat34* classPointer, bool call_explicit, NxExtendedVec3& src, NxExtendedVec3& dst)
{
    (call_explicit) ? classPointer->NxExtendedMat34::multiply(src, dst) : classPointer->multiply(src, dst);
}

API_EXPORT void NxExtendedMat34_multiply_2(NxExtendedMat34* classPointer, bool call_explicit, NxExtendedMat34* left, NxExtendedMat34* right)
{
    (call_explicit) ? classPointer->NxExtendedMat34::multiply(*left, *right) : classPointer->multiply(*left, *right);
}

API_EXPORT void NxExtendedMat34_multiply_3(NxExtendedMat34* classPointer, bool call_explicit, NxExtendedMat34* left, NxMat34& right)
{
    (call_explicit) ? classPointer->NxExtendedMat34::multiply(*left, right) : classPointer->multiply(*left, right);
}

API_EXPORT void NxExtendedMat34_multiplyByInverseRT(NxExtendedMat34* classPointer, bool call_explicit, NxExtendedVec3& src, NxVec3& dst)
{
    (call_explicit) ? classPointer->NxExtendedMat34::multiplyByInverseRT(src, dst) : classPointer->multiplyByInverseRT(src, dst);
}

API_EXPORT void NxExtendedMat34_multiplyByInverseRT_1(NxExtendedMat34* classPointer, bool call_explicit, NxExtendedVec3& src, NxExtendedVec3& dst)
{
    (call_explicit) ? classPointer->NxExtendedMat34::multiplyByInverseRT(src, dst) : classPointer->multiplyByInverseRT(src, dst);
}

API_EXPORT void NxExtendedMat34_multiplyInverseRTRight(NxExtendedMat34* classPointer, bool call_explicit, NxExtendedMat34* left, NxMat34& right)
{
    (call_explicit) ? classPointer->NxExtendedMat34::multiplyInverseRTRight(*left, right) : classPointer->multiplyInverseRTRight(*left, right);
}

API_EXPORT void NxExtendedMat34_multiplyInverseRTLeft(NxExtendedMat34* classPointer, bool call_explicit, NxExtendedMat34* left, NxExtendedMat34* right)
{
    (call_explicit) ? classPointer->NxExtendedMat34::multiplyInverseRTLeft(*left, *right) : classPointer->multiplyInverseRTLeft(*left, *right);
}

API_EXPORT void NxExtendedMat34_id(NxExtendedMat34* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxExtendedMat34::id() : classPointer->id();
}

API_EXPORT void set_NxExtendedPlane_normal(NxExtendedPlane* classPointer, NxVec3 newvalue)
{
    classPointer->normal = newvalue;
}

API_EXPORT NxVec3 get_NxExtendedPlane_normal(NxExtendedPlane* classPointer)
{
    return classPointer->normal;
}

API_EXPORT void set_NxExtendedPlane_d(NxExtendedPlane* classPointer, Extended newvalue)
{
    classPointer->d = newvalue;
}

API_EXPORT Extended get_NxExtendedPlane_d(NxExtendedPlane* classPointer)
{
    return classPointer->d;
}

API_EXPORT NxExtendedPlane* new_NxExtendedPlane(bool do_override)
{
    return new NxExtendedPlane();
}

API_EXPORT Extended NxExtendedPlane_distance(NxExtendedPlane* classPointer, bool call_explicit, NxExtendedVec3& p)
{
    return (call_explicit) ? classPointer->NxExtendedPlane::distance(p) : classPointer->distance(p);
}

API_EXPORT NxExtendedVec3 NxExtendedPlane_pointInPlane(NxExtendedPlane* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxExtendedPlane::pointInPlane() : classPointer->pointInPlane();
}

API_EXPORT void set_NxExtendedRay_orig(NxExtendedRay* classPointer, NxExtendedVec3 newvalue)
{
    classPointer->orig = newvalue;
}

API_EXPORT NxExtendedVec3 get_NxExtendedRay_orig(NxExtendedRay* classPointer)
{
    return classPointer->orig;
}

API_EXPORT void set_NxExtendedRay_dir(NxExtendedRay* classPointer, NxVec3 newvalue)
{
    classPointer->dir = newvalue;
}

API_EXPORT NxVec3 get_NxExtendedRay_dir(NxExtendedRay* classPointer)
{
    return classPointer->dir;
}

API_EXPORT void set_NxExtendedSphere_center(NxExtendedSphere* classPointer, NxExtendedVec3 newvalue)
{
    classPointer->center = newvalue;
}

API_EXPORT NxExtendedVec3 get_NxExtendedSphere_center(NxExtendedSphere* classPointer)
{
    return classPointer->center;
}

API_EXPORT void set_NxExtendedSphere_radius(NxExtendedSphere* classPointer, NxF32 newvalue)
{
    classPointer->radius = newvalue;
}

API_EXPORT NxF32 get_NxExtendedSphere_radius(NxExtendedSphere* classPointer)
{
    return classPointer->radius;
}

API_EXPORT NxExtendedSphere* new_NxExtendedSphere(bool do_override)
{
    return new NxExtendedSphere();
}

API_EXPORT NxExtendedSphere* new_NxExtendedSphere_1(bool do_override, NxExtendedVec3& _center, NxF32 _radius)
{
    return new NxExtendedSphere(_center, _radius);
}

API_EXPORT NxExtendedSphere* new_NxExtendedSphere_2(bool do_override, NxExtendedSphere* sphere)
{
    return new NxExtendedSphere(*sphere);
}

API_EXPORT void NxFixedJoint_loadFromDesc(NxFixedJoint* classPointer, bool call_explicit, NxFixedJointDesc* desc)
{
    classPointer->loadFromDesc(*desc);
}

API_EXPORT void NxFixedJoint_saveToDesc(NxFixedJoint* classPointer, bool call_explicit, NxFixedJointDesc* desc)
{
    classPointer->saveToDesc(*desc);
}

API_EXPORT NxFixedJointDesc* new_NxFixedJointDesc(bool do_override)
{
    return (do_override) ? new NxFixedJointDesc_doxybind() : new NxFixedJointDesc();
}

API_EXPORT void NxFixedJointDesc_setToDefault(NxFixedJointDesc* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxFixedJointDesc::setToDefault() : classPointer->setToDefault();
}

API_EXPORT bool NxFixedJointDesc_isValid(NxFixedJointDesc* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxFixedJointDesc::isValid() : classPointer->isValid();
}

API_EXPORT void set_NxFluidDescBase_initialParticleData(NxFluidDescBase* classPointer, NxParticleData* newvalue)
{
    classPointer->initialParticleData = *newvalue;
}

API_EXPORT NxParticleData* get_NxFluidDescBase_initialParticleData(NxFluidDescBase* classPointer)
{
    return &classPointer->initialParticleData;
}

API_EXPORT void set_NxFluidDescBase_maxParticles(NxFluidDescBase* classPointer, NxU32 newvalue)
{
    classPointer->maxParticles = newvalue;
}

API_EXPORT NxU32 get_NxFluidDescBase_maxParticles(NxFluidDescBase* classPointer)
{
    return classPointer->maxParticles;
}

API_EXPORT void set_NxFluidDescBase_numReserveParticles(NxFluidDescBase* classPointer, NxU32 newvalue)
{
    classPointer->numReserveParticles = newvalue;
}

API_EXPORT NxU32 get_NxFluidDescBase_numReserveParticles(NxFluidDescBase* classPointer)
{
    return classPointer->numReserveParticles;
}

API_EXPORT void set_NxFluidDescBase_restParticlesPerMeter(NxFluidDescBase* classPointer, NxReal newvalue)
{
    classPointer->restParticlesPerMeter = newvalue;
}

API_EXPORT NxReal get_NxFluidDescBase_restParticlesPerMeter(NxFluidDescBase* classPointer)
{
    return classPointer->restParticlesPerMeter;
}

API_EXPORT void set_NxFluidDescBase_restDensity(NxFluidDescBase* classPointer, NxReal newvalue)
{
    classPointer->restDensity = newvalue;
}

API_EXPORT NxReal get_NxFluidDescBase_restDensity(NxFluidDescBase* classPointer)
{
    return classPointer->restDensity;
}

API_EXPORT void set_NxFluidDescBase_kernelRadiusMultiplier(NxFluidDescBase* classPointer, NxReal newvalue)
{
    classPointer->kernelRadiusMultiplier = newvalue;
}

API_EXPORT NxReal get_NxFluidDescBase_kernelRadiusMultiplier(NxFluidDescBase* classPointer)
{
    return classPointer->kernelRadiusMultiplier;
}

API_EXPORT void set_NxFluidDescBase_motionLimitMultiplier(NxFluidDescBase* classPointer, NxReal newvalue)
{
    classPointer->motionLimitMultiplier = newvalue;
}

API_EXPORT NxReal get_NxFluidDescBase_motionLimitMultiplier(NxFluidDescBase* classPointer)
{
    return classPointer->motionLimitMultiplier;
}

API_EXPORT void set_NxFluidDescBase_collisionDistanceMultiplier(NxFluidDescBase* classPointer, NxReal newvalue)
{
    classPointer->collisionDistanceMultiplier = newvalue;
}

API_EXPORT NxReal get_NxFluidDescBase_collisionDistanceMultiplier(NxFluidDescBase* classPointer)
{
    return classPointer->collisionDistanceMultiplier;
}

API_EXPORT void set_NxFluidDescBase_packetSizeMultiplier(NxFluidDescBase* classPointer, NxU32 newvalue)
{
    classPointer->packetSizeMultiplier = newvalue;
}

API_EXPORT NxU32 get_NxFluidDescBase_packetSizeMultiplier(NxFluidDescBase* classPointer)
{
    return classPointer->packetSizeMultiplier;
}

API_EXPORT void set_NxFluidDescBase_stiffness(NxFluidDescBase* classPointer, NxReal newvalue)
{
    classPointer->stiffness = newvalue;
}

API_EXPORT NxReal get_NxFluidDescBase_stiffness(NxFluidDescBase* classPointer)
{
    return classPointer->stiffness;
}

API_EXPORT void set_NxFluidDescBase_viscosity(NxFluidDescBase* classPointer, NxReal newvalue)
{
    classPointer->viscosity = newvalue;
}

API_EXPORT NxReal get_NxFluidDescBase_viscosity(NxFluidDescBase* classPointer)
{
    return classPointer->viscosity;
}

API_EXPORT void set_NxFluidDescBase_surfaceTension(NxFluidDescBase* classPointer, NxReal newvalue)
{
    classPointer->surfaceTension = newvalue;
}

API_EXPORT NxReal get_NxFluidDescBase_surfaceTension(NxFluidDescBase* classPointer)
{
    return classPointer->surfaceTension;
}

API_EXPORT void set_NxFluidDescBase_damping(NxFluidDescBase* classPointer, NxReal newvalue)
{
    classPointer->damping = newvalue;
}

API_EXPORT NxReal get_NxFluidDescBase_damping(NxFluidDescBase* classPointer)
{
    return classPointer->damping;
}

API_EXPORT void set_NxFluidDescBase_fadeInTime(NxFluidDescBase* classPointer, NxReal newvalue)
{
    classPointer->fadeInTime = newvalue;
}

API_EXPORT NxReal get_NxFluidDescBase_fadeInTime(NxFluidDescBase* classPointer)
{
    return classPointer->fadeInTime;
}

API_EXPORT void set_NxFluidDescBase_externalAcceleration(NxFluidDescBase* classPointer, NxVec3 newvalue)
{
    classPointer->externalAcceleration = newvalue;
}

API_EXPORT NxVec3 get_NxFluidDescBase_externalAcceleration(NxFluidDescBase* classPointer)
{
    return classPointer->externalAcceleration;
}

API_EXPORT void set_NxFluidDescBase_projectionPlane(NxFluidDescBase* classPointer, NxPlane* newvalue)
{
    classPointer->projectionPlane = *newvalue;
}

API_EXPORT NxPlane* get_NxFluidDescBase_projectionPlane(NxFluidDescBase* classPointer)
{
    return &classPointer->projectionPlane;
}

API_EXPORT void set_NxFluidDescBase_restitutionForStaticShapes(NxFluidDescBase* classPointer, NxReal newvalue)
{
    classPointer->restitutionForStaticShapes = newvalue;
}

API_EXPORT NxReal get_NxFluidDescBase_restitutionForStaticShapes(NxFluidDescBase* classPointer)
{
    return classPointer->restitutionForStaticShapes;
}

API_EXPORT void set_NxFluidDescBase_dynamicFrictionForStaticShapes(NxFluidDescBase* classPointer, NxReal newvalue)
{
    classPointer->dynamicFrictionForStaticShapes = newvalue;
}

API_EXPORT NxReal get_NxFluidDescBase_dynamicFrictionForStaticShapes(NxFluidDescBase* classPointer)
{
    return classPointer->dynamicFrictionForStaticShapes;
}

API_EXPORT void set_NxFluidDescBase_staticFrictionForStaticShapes(NxFluidDescBase* classPointer, NxReal newvalue)
{
    classPointer->staticFrictionForStaticShapes = newvalue;
}

API_EXPORT NxReal get_NxFluidDescBase_staticFrictionForStaticShapes(NxFluidDescBase* classPointer)
{
    return classPointer->staticFrictionForStaticShapes;
}

API_EXPORT void set_NxFluidDescBase_attractionForStaticShapes(NxFluidDescBase* classPointer, NxReal newvalue)
{
    classPointer->attractionForStaticShapes = newvalue;
}

API_EXPORT NxReal get_NxFluidDescBase_attractionForStaticShapes(NxFluidDescBase* classPointer)
{
    return classPointer->attractionForStaticShapes;
}

API_EXPORT void set_NxFluidDescBase_restitutionForDynamicShapes(NxFluidDescBase* classPointer, NxReal newvalue)
{
    classPointer->restitutionForDynamicShapes = newvalue;
}

API_EXPORT NxReal get_NxFluidDescBase_restitutionForDynamicShapes(NxFluidDescBase* classPointer)
{
    return classPointer->restitutionForDynamicShapes;
}

API_EXPORT void set_NxFluidDescBase_dynamicFrictionForDynamicShapes(NxFluidDescBase* classPointer, NxReal newvalue)
{
    classPointer->dynamicFrictionForDynamicShapes = newvalue;
}

API_EXPORT NxReal get_NxFluidDescBase_dynamicFrictionForDynamicShapes(NxFluidDescBase* classPointer)
{
    return classPointer->dynamicFrictionForDynamicShapes;
}

API_EXPORT void set_NxFluidDescBase_staticFrictionForDynamicShapes(NxFluidDescBase* classPointer, NxReal newvalue)
{
    classPointer->staticFrictionForDynamicShapes = newvalue;
}

API_EXPORT NxReal get_NxFluidDescBase_staticFrictionForDynamicShapes(NxFluidDescBase* classPointer)
{
    return classPointer->staticFrictionForDynamicShapes;
}

API_EXPORT void set_NxFluidDescBase_attractionForDynamicShapes(NxFluidDescBase* classPointer, NxReal newvalue)
{
    classPointer->attractionForDynamicShapes = newvalue;
}

API_EXPORT NxReal get_NxFluidDescBase_attractionForDynamicShapes(NxFluidDescBase* classPointer)
{
    return classPointer->attractionForDynamicShapes;
}

API_EXPORT void set_NxFluidDescBase_collisionResponseCoefficient(NxFluidDescBase* classPointer, NxReal newvalue)
{
    classPointer->collisionResponseCoefficient = newvalue;
}

API_EXPORT NxReal get_NxFluidDescBase_collisionResponseCoefficient(NxFluidDescBase* classPointer)
{
    return classPointer->collisionResponseCoefficient;
}

API_EXPORT void set_NxFluidDescBase_simulationMethod(NxFluidDescBase* classPointer, NxU32 newvalue)
{
    classPointer->simulationMethod = newvalue;
}

API_EXPORT NxU32 get_NxFluidDescBase_simulationMethod(NxFluidDescBase* classPointer)
{
    return classPointer->simulationMethod;
}

API_EXPORT void set_NxFluidDescBase_collisionMethod(NxFluidDescBase* classPointer, NxU32 newvalue)
{
    classPointer->collisionMethod = newvalue;
}

API_EXPORT NxU32 get_NxFluidDescBase_collisionMethod(NxFluidDescBase* classPointer)
{
    return classPointer->collisionMethod;
}

API_EXPORT void set_NxFluidDescBase_collisionGroup(NxFluidDescBase* classPointer, NxCollisionGroup newvalue)
{
    classPointer->collisionGroup = newvalue;
}

API_EXPORT NxCollisionGroup get_NxFluidDescBase_collisionGroup(NxFluidDescBase* classPointer)
{
    return classPointer->collisionGroup;
}

API_EXPORT void set_NxFluidDescBase_groupsMask(NxFluidDescBase* classPointer, NxGroupsMask* newvalue)
{
    classPointer->groupsMask = *newvalue;
}

API_EXPORT NxGroupsMask* get_NxFluidDescBase_groupsMask(NxFluidDescBase* classPointer)
{
    return &classPointer->groupsMask;
}

API_EXPORT void set_NxFluidDescBase_forceFieldMaterial(NxFluidDescBase* classPointer, NxForceFieldMaterial newvalue)
{
    classPointer->forceFieldMaterial = newvalue;
}

API_EXPORT NxForceFieldMaterial get_NxFluidDescBase_forceFieldMaterial(NxFluidDescBase* classPointer)
{
    return classPointer->forceFieldMaterial;
}

API_EXPORT void set_NxFluidDescBase_particlesWriteData(NxFluidDescBase* classPointer, NxParticleData* newvalue)
{
    classPointer->particlesWriteData = *newvalue;
}

API_EXPORT NxParticleData* get_NxFluidDescBase_particlesWriteData(NxFluidDescBase* classPointer)
{
    return &classPointer->particlesWriteData;
}

API_EXPORT void set_NxFluidDescBase_particleDeletionIdWriteData(NxFluidDescBase* classPointer, NxParticleIdData* newvalue)
{
    classPointer->particleDeletionIdWriteData = *newvalue;
}

API_EXPORT NxParticleIdData* get_NxFluidDescBase_particleDeletionIdWriteData(NxFluidDescBase* classPointer)
{
    return &classPointer->particleDeletionIdWriteData;
}

API_EXPORT void set_NxFluidDescBase_particleCreationIdWriteData(NxFluidDescBase* classPointer, NxParticleIdData* newvalue)
{
    classPointer->particleCreationIdWriteData = *newvalue;
}

API_EXPORT NxParticleIdData* get_NxFluidDescBase_particleCreationIdWriteData(NxFluidDescBase* classPointer)
{
    return &classPointer->particleCreationIdWriteData;
}

API_EXPORT void set_NxFluidDescBase_fluidPacketData(NxFluidDescBase* classPointer, NxFluidPacketData* newvalue)
{
    classPointer->fluidPacketData = *newvalue;
}

API_EXPORT NxFluidPacketData* get_NxFluidDescBase_fluidPacketData(NxFluidDescBase* classPointer)
{
    return &classPointer->fluidPacketData;
}

API_EXPORT void set_NxFluidDescBase_flags(NxFluidDescBase* classPointer, NxU32 newvalue)
{
    classPointer->flags = newvalue;
}

API_EXPORT NxU32 get_NxFluidDescBase_flags(NxFluidDescBase* classPointer)
{
    return classPointer->flags;
}

API_EXPORT void set_NxFluidDescBase_userData(NxFluidDescBase* classPointer, void* newvalue)
{
    classPointer->userData = newvalue;
}

API_EXPORT void* get_NxFluidDescBase_userData(NxFluidDescBase* classPointer)
{
    return classPointer->userData;
}

API_EXPORT void set_NxFluidDescBase_name(NxFluidDescBase* classPointer, const char* newvalue)
{
    classPointer->name = newvalue;
}

API_EXPORT const char* get_NxFluidDescBase_name(NxFluidDescBase* classPointer)
{
    return classPointer->name;
}

API_EXPORT void set_NxFluidDescBase_compartment(NxFluidDescBase* classPointer, NxCompartment* newvalue)
{
    classPointer->compartment = newvalue;
}

API_EXPORT NxCompartment* get_NxFluidDescBase_compartment(NxFluidDescBase* classPointer)
{
    return classPointer->compartment;
}

API_EXPORT NxFluidDescBase* new_NxFluidDescBase(bool do_override)
{
    return new NxFluidDescBase();
}

API_EXPORT void NxFluidDescBase_setToDefault(NxFluidDescBase* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxFluidDescBase::setToDefault() : classPointer->setToDefault();
}

API_EXPORT bool NxFluidDescBase_isValid(NxFluidDescBase* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxFluidDescBase::isValid() : classPointer->isValid();
}

API_EXPORT NxFluidDescType NxFluidDescBase_getType(NxFluidDescBase* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxFluidDescBase::getType() : classPointer->getType();
}

API_EXPORT void set_NxFluidDesc_emitters(NxFluidDesc* classPointer, NxArray< NxFluidEmitterDesc, NxAllocatorDefault >* newvalue)
{
    classPointer->emitters = *newvalue;
}

API_EXPORT NxArray< NxFluidEmitterDesc, NxAllocatorDefault >* get_NxFluidDesc_emitters(NxFluidDesc* classPointer)
{
    return &classPointer->emitters;
}

API_EXPORT NxFluidDesc* new_NxFluidDesc(bool do_override)
{
    return new NxFluidDesc();
}

API_EXPORT void NxFluidDesc_setToDefault(NxFluidDesc* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxFluidDesc::setToDefault() : classPointer->setToDefault();
}

API_EXPORT bool NxFluidDesc_isValid(NxFluidDesc* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxFluidDesc::isValid() : classPointer->isValid();
}

API_EXPORT bool NxFluidEmitter_loadFromDesc(NxFluidEmitter* classPointer, bool call_explicit, NxFluidEmitterDesc* desc)
{
    return classPointer->loadFromDesc(*desc);
}

API_EXPORT bool NxFluidEmitter_saveToDesc(NxFluidEmitter* classPointer, bool call_explicit, NxFluidEmitterDesc* desc)
{
    return classPointer->saveToDesc(*desc);
}

API_EXPORT void set_NxFluidEmitter_userData(NxFluidEmitter* classPointer, void* newvalue)
{
    classPointer->userData = newvalue;
}

API_EXPORT void* get_NxFluidEmitter_userData(NxFluidEmitter* classPointer)
{
    return classPointer->userData;
}

API_EXPORT NxFluidEmitter* new_NxFluidEmitter(bool do_override)
{
    return NULL;
}

API_EXPORT NxFluid* NxFluidEmitter_getFluid(NxFluidEmitter* classPointer, bool call_explicit)
{
    return &classPointer->getFluid();
}

API_EXPORT void NxFluidEmitter_setGlobalPose(NxFluidEmitter* classPointer, bool call_explicit, NxMat34& mat)
{
    classPointer->setGlobalPose(mat);
}

API_EXPORT void NxFluidEmitter_setGlobalPosition(NxFluidEmitter* classPointer, bool call_explicit, NxVec3& vec)
{
    classPointer->setGlobalPosition(vec);
}

API_EXPORT void NxFluidEmitter_setGlobalOrientation(NxFluidEmitter* classPointer, bool call_explicit, NxMat33& mat)
{
    classPointer->setGlobalOrientation(mat);
}

API_EXPORT NxMat34 NxFluidEmitter_getGlobalPose(NxFluidEmitter* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxFluidEmitter::getGlobalPose() : classPointer->getGlobalPose();
}

API_EXPORT NxVec3 NxFluidEmitter_getGlobalPosition(NxFluidEmitter* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxFluidEmitter::getGlobalPosition() : classPointer->getGlobalPosition();
}

API_EXPORT NxMat33 NxFluidEmitter_getGlobalOrientation(NxFluidEmitter* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxFluidEmitter::getGlobalOrientation() : classPointer->getGlobalOrientation();
}

API_EXPORT void NxFluidEmitter_setLocalPose(NxFluidEmitter* classPointer, bool call_explicit, NxMat34& mat)
{
    classPointer->setLocalPose(mat);
}

API_EXPORT void NxFluidEmitter_setLocalPosition(NxFluidEmitter* classPointer, bool call_explicit, NxVec3& vec)
{
    classPointer->setLocalPosition(vec);
}

API_EXPORT void NxFluidEmitter_setLocalOrientation(NxFluidEmitter* classPointer, bool call_explicit, NxMat33& mat)
{
    classPointer->setLocalOrientation(mat);
}

API_EXPORT NxMat34 NxFluidEmitter_getLocalPose(NxFluidEmitter* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxFluidEmitter::getLocalPose() : classPointer->getLocalPose();
}

API_EXPORT NxVec3 NxFluidEmitter_getLocalPosition(NxFluidEmitter* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxFluidEmitter::getLocalPosition() : classPointer->getLocalPosition();
}

API_EXPORT NxMat33 NxFluidEmitter_getLocalOrientation(NxFluidEmitter* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxFluidEmitter::getLocalOrientation() : classPointer->getLocalOrientation();
}

API_EXPORT void NxFluidEmitter_setFrameShape(NxFluidEmitter* classPointer, bool call_explicit, NxShape* shape)
{
    classPointer->setFrameShape(shape);
}

API_EXPORT NxShape* NxFluidEmitter_getFrameShape(NxFluidEmitter* classPointer, bool call_explicit)
{
    return classPointer->getFrameShape();
}

API_EXPORT NxReal NxFluidEmitter_getDimensionX(NxFluidEmitter* classPointer, bool call_explicit)
{
    return classPointer->getDimensionX();
}

API_EXPORT NxReal NxFluidEmitter_getDimensionY(NxFluidEmitter* classPointer, bool call_explicit)
{
    return classPointer->getDimensionY();
}

API_EXPORT void NxFluidEmitter_setRandomPos(NxFluidEmitter* classPointer, bool call_explicit, NxVec3 disp)
{
    classPointer->setRandomPos(disp);
}

API_EXPORT NxVec3 NxFluidEmitter_getRandomPos(NxFluidEmitter* classPointer, bool call_explicit)
{
    return classPointer->getRandomPos();
}

API_EXPORT void NxFluidEmitter_setRandomAngle(NxFluidEmitter* classPointer, bool call_explicit, NxReal angle)
{
    classPointer->setRandomAngle(angle);
}

API_EXPORT NxReal NxFluidEmitter_getRandomAngle(NxFluidEmitter* classPointer, bool call_explicit)
{
    return classPointer->getRandomAngle();
}

API_EXPORT void NxFluidEmitter_setFluidVelocityMagnitude(NxFluidEmitter* classPointer, bool call_explicit, NxReal vel)
{
    classPointer->setFluidVelocityMagnitude(vel);
}

API_EXPORT NxReal NxFluidEmitter_getFluidVelocityMagnitude(NxFluidEmitter* classPointer, bool call_explicit)
{
    return classPointer->getFluidVelocityMagnitude();
}

API_EXPORT void NxFluidEmitter_setRate(NxFluidEmitter* classPointer, bool call_explicit, NxReal rate)
{
    classPointer->setRate(rate);
}

API_EXPORT NxReal NxFluidEmitter_getRate(NxFluidEmitter* classPointer, bool call_explicit)
{
    return classPointer->getRate();
}

API_EXPORT void NxFluidEmitter_setParticleLifetime(NxFluidEmitter* classPointer, bool call_explicit, NxReal life)
{
    classPointer->setParticleLifetime(life);
}

API_EXPORT NxReal NxFluidEmitter_getParticleLifetime(NxFluidEmitter* classPointer, bool call_explicit)
{
    return classPointer->getParticleLifetime();
}

API_EXPORT void NxFluidEmitter_setRepulsionCoefficient(NxFluidEmitter* classPointer, bool call_explicit, NxReal coefficient)
{
    classPointer->setRepulsionCoefficient(coefficient);
}

API_EXPORT NxReal NxFluidEmitter_getRepulsionCoefficient(NxFluidEmitter* classPointer, bool call_explicit)
{
    return classPointer->getRepulsionCoefficient();
}

API_EXPORT void NxFluidEmitter_resetEmission(NxFluidEmitter* classPointer, bool call_explicit, NxU32 maxParticles)
{
    classPointer->resetEmission(maxParticles);
}

API_EXPORT NxU32 NxFluidEmitter_getMaxParticles(NxFluidEmitter* classPointer, bool call_explicit)
{
    return classPointer->getMaxParticles();
}

API_EXPORT NxU32 NxFluidEmitter_getNbParticlesEmitted(NxFluidEmitter* classPointer, bool call_explicit)
{
    return classPointer->getNbParticlesEmitted();
}

API_EXPORT void NxFluidEmitter_setFlag(NxFluidEmitter* classPointer, bool call_explicit, NxFluidEmitterFlag flag, bool val)
{
    classPointer->setFlag(flag, val);
}

API_EXPORT NX_BOOL NxFluidEmitter_getFlag(NxFluidEmitter* classPointer, bool call_explicit, NxFluidEmitterFlag flag)
{
    return classPointer->getFlag(flag);
}

API_EXPORT NX_BOOL NxFluidEmitter_getShape(NxFluidEmitter* classPointer, bool call_explicit, NxEmitterShape shape)
{
    return classPointer->getShape(shape);
}

API_EXPORT NX_BOOL NxFluidEmitter_getType(NxFluidEmitter* classPointer, bool call_explicit, NxEmitterType type)
{
    return classPointer->getType(type);
}

API_EXPORT void NxFluidEmitter_setName(NxFluidEmitter* classPointer, bool call_explicit, char* name)
{
    classPointer->setName(name);
}

API_EXPORT const char* NxFluidEmitter_getName(NxFluidEmitter* classPointer, bool call_explicit)
{
    return classPointer->getName();
}

API_EXPORT void set_NxFluidEmitterDesc_relPose(NxFluidEmitterDesc* classPointer, NxMat34 newvalue)
{
    classPointer->relPose = newvalue;
}

API_EXPORT NxMat34 get_NxFluidEmitterDesc_relPose(NxFluidEmitterDesc* classPointer)
{
    return classPointer->relPose;
}

API_EXPORT void set_NxFluidEmitterDesc_frameShape(NxFluidEmitterDesc* classPointer, NxShape* newvalue)
{
    classPointer->frameShape = newvalue;
}

API_EXPORT NxShape* get_NxFluidEmitterDesc_frameShape(NxFluidEmitterDesc* classPointer)
{
    return classPointer->frameShape;
}

API_EXPORT void set_NxFluidEmitterDesc_type(NxFluidEmitterDesc* classPointer, NxU32 newvalue)
{
    classPointer->type = newvalue;
}

API_EXPORT NxU32 get_NxFluidEmitterDesc_type(NxFluidEmitterDesc* classPointer)
{
    return classPointer->type;
}

API_EXPORT void set_NxFluidEmitterDesc_maxParticles(NxFluidEmitterDesc* classPointer, NxU32 newvalue)
{
    classPointer->maxParticles = newvalue;
}

API_EXPORT NxU32 get_NxFluidEmitterDesc_maxParticles(NxFluidEmitterDesc* classPointer)
{
    return classPointer->maxParticles;
}

API_EXPORT void set_NxFluidEmitterDesc_shape(NxFluidEmitterDesc* classPointer, NxU32 newvalue)
{
    classPointer->shape = newvalue;
}

API_EXPORT NxU32 get_NxFluidEmitterDesc_shape(NxFluidEmitterDesc* classPointer)
{
    return classPointer->shape;
}

API_EXPORT void set_NxFluidEmitterDesc_dimensionX(NxFluidEmitterDesc* classPointer, NxReal newvalue)
{
    classPointer->dimensionX = newvalue;
}

API_EXPORT NxReal get_NxFluidEmitterDesc_dimensionX(NxFluidEmitterDesc* classPointer)
{
    return classPointer->dimensionX;
}

API_EXPORT void set_NxFluidEmitterDesc_dimensionY(NxFluidEmitterDesc* classPointer, NxReal newvalue)
{
    classPointer->dimensionY = newvalue;
}

API_EXPORT NxReal get_NxFluidEmitterDesc_dimensionY(NxFluidEmitterDesc* classPointer)
{
    return classPointer->dimensionY;
}

API_EXPORT void set_NxFluidEmitterDesc_randomPos(NxFluidEmitterDesc* classPointer, NxVec3 newvalue)
{
    classPointer->randomPos = newvalue;
}

API_EXPORT NxVec3 get_NxFluidEmitterDesc_randomPos(NxFluidEmitterDesc* classPointer)
{
    return classPointer->randomPos;
}

API_EXPORT void set_NxFluidEmitterDesc_randomAngle(NxFluidEmitterDesc* classPointer, NxReal newvalue)
{
    classPointer->randomAngle = newvalue;
}

API_EXPORT NxReal get_NxFluidEmitterDesc_randomAngle(NxFluidEmitterDesc* classPointer)
{
    return classPointer->randomAngle;
}

API_EXPORT void set_NxFluidEmitterDesc_fluidVelocityMagnitude(NxFluidEmitterDesc* classPointer, NxReal newvalue)
{
    classPointer->fluidVelocityMagnitude = newvalue;
}

API_EXPORT NxReal get_NxFluidEmitterDesc_fluidVelocityMagnitude(NxFluidEmitterDesc* classPointer)
{
    return classPointer->fluidVelocityMagnitude;
}

API_EXPORT void set_NxFluidEmitterDesc_rate(NxFluidEmitterDesc* classPointer, NxReal newvalue)
{
    classPointer->rate = newvalue;
}

API_EXPORT NxReal get_NxFluidEmitterDesc_rate(NxFluidEmitterDesc* classPointer)
{
    return classPointer->rate;
}

API_EXPORT void set_NxFluidEmitterDesc_particleLifetime(NxFluidEmitterDesc* classPointer, NxReal newvalue)
{
    classPointer->particleLifetime = newvalue;
}

API_EXPORT NxReal get_NxFluidEmitterDesc_particleLifetime(NxFluidEmitterDesc* classPointer)
{
    return classPointer->particleLifetime;
}

API_EXPORT void set_NxFluidEmitterDesc_repulsionCoefficient(NxFluidEmitterDesc* classPointer, NxReal newvalue)
{
    classPointer->repulsionCoefficient = newvalue;
}

API_EXPORT NxReal get_NxFluidEmitterDesc_repulsionCoefficient(NxFluidEmitterDesc* classPointer)
{
    return classPointer->repulsionCoefficient;
}

API_EXPORT void set_NxFluidEmitterDesc_flags(NxFluidEmitterDesc* classPointer, NxU32 newvalue)
{
    classPointer->flags = newvalue;
}

API_EXPORT NxU32 get_NxFluidEmitterDesc_flags(NxFluidEmitterDesc* classPointer)
{
    return classPointer->flags;
}

API_EXPORT void set_NxFluidEmitterDesc_userData(NxFluidEmitterDesc* classPointer, void* newvalue)
{
    classPointer->userData = newvalue;
}

API_EXPORT void* get_NxFluidEmitterDesc_userData(NxFluidEmitterDesc* classPointer)
{
    return classPointer->userData;
}

API_EXPORT void set_NxFluidEmitterDesc_name(NxFluidEmitterDesc* classPointer, const char* newvalue)
{
    classPointer->name = newvalue;
}

API_EXPORT const char* get_NxFluidEmitterDesc_name(NxFluidEmitterDesc* classPointer)
{
    return classPointer->name;
}

API_EXPORT void NxFluidEmitterDesc_setToDefault(NxFluidEmitterDesc* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxFluidEmitterDesc::setToDefault() : classPointer->setToDefault();
}

API_EXPORT bool NxFluidEmitterDesc_isValid(NxFluidEmitterDesc* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxFluidEmitterDesc::isValid() : classPointer->isValid();
}

API_EXPORT NxFluidEmitterDesc* new_NxFluidEmitterDesc(bool do_override)
{
    return new NxFluidEmitterDesc();
}

API_EXPORT void set_NxFluidPacket_aabb(NxFluidPacket* classPointer, NxBounds3* newvalue)
{
    classPointer->aabb = *newvalue;
}

API_EXPORT NxBounds3* get_NxFluidPacket_aabb(NxFluidPacket* classPointer)
{
    return &classPointer->aabb;
}

API_EXPORT void set_NxFluidPacket_firstParticleIndex(NxFluidPacket* classPointer, NxU32 newvalue)
{
    classPointer->firstParticleIndex = newvalue;
}

API_EXPORT NxU32 get_NxFluidPacket_firstParticleIndex(NxFluidPacket* classPointer)
{
    return classPointer->firstParticleIndex;
}

API_EXPORT void set_NxFluidPacket_numParticles(NxFluidPacket* classPointer, NxU32 newvalue)
{
    classPointer->numParticles = newvalue;
}

API_EXPORT NxU32 get_NxFluidPacket_numParticles(NxFluidPacket* classPointer)
{
    return classPointer->numParticles;
}

API_EXPORT void set_NxFluidPacket_packetID(NxFluidPacket* classPointer, NxU32 newvalue)
{
    classPointer->packetID = newvalue;
}

API_EXPORT NxU32 get_NxFluidPacket_packetID(NxFluidPacket* classPointer)
{
    return classPointer->packetID;
}

API_EXPORT void set_NxFluidPacketData_bufferFluidPackets(NxFluidPacketData* classPointer, NxFluidPacket* newvalue)
{
    classPointer->bufferFluidPackets = newvalue;
}

API_EXPORT NxFluidPacket* get_NxFluidPacketData_bufferFluidPackets(NxFluidPacketData* classPointer)
{
    return classPointer->bufferFluidPackets;
}

API_EXPORT void set_NxFluidPacketData_numFluidPacketsPtr(NxFluidPacketData* classPointer, NxU32* newvalue)
{
    classPointer->numFluidPacketsPtr = newvalue;
}

API_EXPORT NxU32* get_NxFluidPacketData_numFluidPacketsPtr(NxFluidPacketData* classPointer)
{
    return classPointer->numFluidPacketsPtr;
}

API_EXPORT void NxFluidPacketData_setToDefault(NxFluidPacketData* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxFluidPacketData::setToDefault() : classPointer->setToDefault();
}

API_EXPORT bool NxFluidPacketData_isValid(NxFluidPacketData* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxFluidPacketData::isValid() : classPointer->isValid();
}

API_EXPORT NxFluidPacketData* new_NxFluidPacketData(bool do_override)
{
    return new NxFluidPacketData();
}

API_EXPORT bool NxFluidUserNotify_onEmitterEvent(NxFluidUserNotify* classPointer, bool call_explicit, NxFluidEmitter* emitter, NxFluidEmitterEventType eventType)
{
    return classPointer->onEmitterEvent(*emitter, eventType);
}

API_EXPORT bool NxFluidUserNotify_onEvent(NxFluidUserNotify* classPointer, bool call_explicit, NxFluid* fluid, NxFluidEventType eventType)
{
    return classPointer->onEvent(*fluid, eventType);
}

API_EXPORT void set_NxForceField_userData(NxForceField* classPointer, void* newvalue)
{
    classPointer->userData = newvalue;
}

API_EXPORT void* get_NxForceField_userData(NxForceField* classPointer)
{
    return classPointer->userData;
}

API_EXPORT NxForceField* new_NxForceField(bool do_override)
{
    return (do_override) ? new NxForceField_doxybind() : NULL;
}

API_EXPORT void NxForceField_saveToDesc(NxForceField* classPointer, bool call_explicit, NxForceFieldDesc* desc)
{
    classPointer->saveToDesc(*desc);
}

API_EXPORT NxMat34 NxForceField_getPose(NxForceField* classPointer, bool call_explicit)
{
    return classPointer->getPose();
}

API_EXPORT void NxForceField_setPose(NxForceField* classPointer, bool call_explicit, NxMat34& pose)
{
    classPointer->setPose(pose);
}

API_EXPORT NxActor* NxForceField_getActor(NxForceField* classPointer, bool call_explicit)
{
    return classPointer->getActor();
}

API_EXPORT void NxForceField_setActor(NxForceField* classPointer, bool call_explicit, NxActor* actor)
{
    classPointer->setActor(actor);
}

API_EXPORT void NxForceField_setForceFieldKernel(NxForceField* classPointer, bool call_explicit, NxForceFieldKernel* kernel)
{
    classPointer->setForceFieldKernel(kernel);
}

API_EXPORT NxForceFieldKernel* NxForceField_getForceFieldKernel(NxForceField* classPointer, bool call_explicit)
{
    return classPointer->getForceFieldKernel();
}

API_EXPORT NxForceFieldShapeGroup* NxForceField_getIncludeShapeGroup(NxForceField* classPointer, bool call_explicit)
{
    return &classPointer->getIncludeShapeGroup();
}

API_EXPORT void NxForceField_addShapeGroup(NxForceField* classPointer, bool call_explicit, NxForceFieldShapeGroup* group)
{
    classPointer->addShapeGroup(*group);
}

API_EXPORT void NxForceField_removeShapeGroup(NxForceField* classPointer, bool call_explicit, NxForceFieldShapeGroup* unknown9)
{
    classPointer->removeShapeGroup(*unknown9);
}

API_EXPORT NxU32 NxForceField_getNbShapeGroups(NxForceField* classPointer, bool call_explicit)
{
    return classPointer->getNbShapeGroups();
}

API_EXPORT void NxForceField_resetShapeGroupsIterator(NxForceField* classPointer, bool call_explicit)
{
    classPointer->resetShapeGroupsIterator();
}

API_EXPORT NxForceFieldShapeGroup* NxForceField_getNextShapeGroup(NxForceField* classPointer, bool call_explicit)
{
    return classPointer->getNextShapeGroup();
}

API_EXPORT NxCollisionGroup NxForceField_getGroup(NxForceField* classPointer, bool call_explicit)
{
    return classPointer->getGroup();
}

API_EXPORT void NxForceField_setGroup(NxForceField* classPointer, bool call_explicit, NxCollisionGroup collisionGroup)
{
    classPointer->setGroup(collisionGroup);
}

API_EXPORT NxGroupsMask* NxForceField_getGroupsMask(NxForceField* classPointer, bool call_explicit)
{
    return &classPointer->getGroupsMask();
}

API_EXPORT void NxForceField_setGroupsMask(NxForceField* classPointer, bool call_explicit, NxGroupsMask* mask)
{
    classPointer->setGroupsMask(*mask);
}

API_EXPORT NxForceFieldCoordinates NxForceField_getCoordinates(NxForceField* classPointer, bool call_explicit)
{
    return classPointer->getCoordinates();
}

API_EXPORT void NxForceField_setCoordinates(NxForceField* classPointer, bool call_explicit, NxForceFieldCoordinates coordinates)
{
    classPointer->setCoordinates(coordinates);
}

API_EXPORT void NxForceField_setName(NxForceField* classPointer, bool call_explicit, char* name)
{
    classPointer->setName(name);
}

API_EXPORT const char* NxForceField_getName(NxForceField* classPointer, bool call_explicit)
{
    return classPointer->getName();
}

API_EXPORT NxForceFieldType NxForceField_getFluidType(NxForceField* classPointer, bool call_explicit)
{
    return classPointer->getFluidType();
}

API_EXPORT void NxForceField_setFluidType(NxForceField* classPointer, bool call_explicit, NxForceFieldType t)
{
    classPointer->setFluidType(t);
}

API_EXPORT NxForceFieldType NxForceField_getClothType(NxForceField* classPointer, bool call_explicit)
{
    return classPointer->getClothType();
}

API_EXPORT void NxForceField_setClothType(NxForceField* classPointer, bool call_explicit, NxForceFieldType t)
{
    classPointer->setClothType(t);
}

API_EXPORT NxForceFieldType NxForceField_getSoftBodyType(NxForceField* classPointer, bool call_explicit)
{
    return classPointer->getSoftBodyType();
}

API_EXPORT void NxForceField_setSoftBodyType(NxForceField* classPointer, bool call_explicit, NxForceFieldType t)
{
    classPointer->setSoftBodyType(t);
}

API_EXPORT NxForceFieldType NxForceField_getRigidBodyType(NxForceField* classPointer, bool call_explicit)
{
    return classPointer->getRigidBodyType();
}

API_EXPORT void NxForceField_setRigidBodyType(NxForceField* classPointer, bool call_explicit, NxForceFieldType t)
{
    classPointer->setRigidBodyType(t);
}

API_EXPORT NxU32 NxForceField_getFlags(NxForceField* classPointer, bool call_explicit)
{
    return classPointer->getFlags();
}

API_EXPORT void NxForceField_setFlags(NxForceField* classPointer, bool call_explicit, NxU32 f)
{
    classPointer->setFlags(f);
}

API_EXPORT void NxForceField_samplePoints(NxForceField* classPointer, bool call_explicit, NxU32 numPoints, NxVec3* points, NxVec3* velocities, NxVec3* outForces, NxVec3* outTorques)
{
    classPointer->samplePoints(numPoints, points, velocities, outForces, outTorques);
}

API_EXPORT NxScene* NxForceField_getScene(NxForceField* classPointer, bool call_explicit)
{
    return &classPointer->getScene();
}

API_EXPORT NxForceFieldVariety NxForceField_getForceFieldVariety(NxForceField* classPointer, bool call_explicit)
{
    return classPointer->getForceFieldVariety();
}

API_EXPORT void NxForceField_setForceFieldVariety(NxForceField* classPointer, bool call_explicit, NxForceFieldVariety unknown10)
{
    classPointer->setForceFieldVariety(unknown10);
}

API_EXPORT void set_NxForceFieldDesc_pose(NxForceFieldDesc* classPointer, NxMat34 newvalue)
{
    classPointer->pose = newvalue;
}

API_EXPORT NxMat34 get_NxForceFieldDesc_pose(NxForceFieldDesc* classPointer)
{
    return classPointer->pose;
}

API_EXPORT void set_NxForceFieldDesc_actor(NxForceFieldDesc* classPointer, NxActor* newvalue)
{
    classPointer->actor = newvalue;
}

API_EXPORT NxActor* get_NxForceFieldDesc_actor(NxForceFieldDesc* classPointer)
{
    return classPointer->actor;
}

API_EXPORT void set_NxForceFieldDesc_coordinates(NxForceFieldDesc* classPointer, NxForceFieldCoordinates newvalue)
{
    classPointer->coordinates = newvalue;
}

API_EXPORT NxForceFieldCoordinates get_NxForceFieldDesc_coordinates(NxForceFieldDesc* classPointer)
{
    return classPointer->coordinates;
}

API_EXPORT void set_NxForceFieldDesc_includeGroupShapes(NxForceFieldDesc* classPointer, NxArray< NxForceFieldShapeDesc* >* newvalue)
{
    classPointer->includeGroupShapes = *newvalue;
}

API_EXPORT NxArray< NxForceFieldShapeDesc* >* get_NxForceFieldDesc_includeGroupShapes(NxForceFieldDesc* classPointer)
{
    return &classPointer->includeGroupShapes;
}

API_EXPORT void set_NxForceFieldDesc_shapeGroups(NxForceFieldDesc* classPointer, NxArray< NxForceFieldShapeGroup* >* newvalue)
{
    classPointer->shapeGroups = *newvalue;
}

API_EXPORT NxArray< NxForceFieldShapeGroup* >* get_NxForceFieldDesc_shapeGroups(NxForceFieldDesc* classPointer)
{
    return &classPointer->shapeGroups;
}

API_EXPORT void set_NxForceFieldDesc_group(NxForceFieldDesc* classPointer, NxCollisionGroup newvalue)
{
    classPointer->group = newvalue;
}

API_EXPORT NxCollisionGroup get_NxForceFieldDesc_group(NxForceFieldDesc* classPointer)
{
    return classPointer->group;
}

API_EXPORT void set_NxForceFieldDesc_groupsMask(NxForceFieldDesc* classPointer, NxGroupsMask* newvalue)
{
    classPointer->groupsMask = *newvalue;
}

API_EXPORT NxGroupsMask* get_NxForceFieldDesc_groupsMask(NxForceFieldDesc* classPointer)
{
    return &classPointer->groupsMask;
}

API_EXPORT void set_NxForceFieldDesc_kernel(NxForceFieldDesc* classPointer, NxForceFieldKernel* newvalue)
{
    classPointer->kernel = newvalue;
}

API_EXPORT NxForceFieldKernel* get_NxForceFieldDesc_kernel(NxForceFieldDesc* classPointer)
{
    return classPointer->kernel;
}

API_EXPORT void set_NxForceFieldDesc_forceFieldVariety(NxForceFieldDesc* classPointer, NxForceFieldVariety newvalue)
{
    classPointer->forceFieldVariety = newvalue;
}

API_EXPORT NxForceFieldVariety get_NxForceFieldDesc_forceFieldVariety(NxForceFieldDesc* classPointer)
{
    return classPointer->forceFieldVariety;
}

API_EXPORT void set_NxForceFieldDesc_fluidType(NxForceFieldDesc* classPointer, NxForceFieldType newvalue)
{
    classPointer->fluidType = newvalue;
}

API_EXPORT NxForceFieldType get_NxForceFieldDesc_fluidType(NxForceFieldDesc* classPointer)
{
    return classPointer->fluidType;
}

API_EXPORT void set_NxForceFieldDesc_clothType(NxForceFieldDesc* classPointer, NxForceFieldType newvalue)
{
    classPointer->clothType = newvalue;
}

API_EXPORT NxForceFieldType get_NxForceFieldDesc_clothType(NxForceFieldDesc* classPointer)
{
    return classPointer->clothType;
}

API_EXPORT void set_NxForceFieldDesc_softBodyType(NxForceFieldDesc* classPointer, NxForceFieldType newvalue)
{
    classPointer->softBodyType = newvalue;
}

API_EXPORT NxForceFieldType get_NxForceFieldDesc_softBodyType(NxForceFieldDesc* classPointer)
{
    return classPointer->softBodyType;
}

API_EXPORT void set_NxForceFieldDesc_rigidBodyType(NxForceFieldDesc* classPointer, NxForceFieldType newvalue)
{
    classPointer->rigidBodyType = newvalue;
}

API_EXPORT NxForceFieldType get_NxForceFieldDesc_rigidBodyType(NxForceFieldDesc* classPointer)
{
    return classPointer->rigidBodyType;
}

API_EXPORT void set_NxForceFieldDesc_flags(NxForceFieldDesc* classPointer, NxU32 newvalue)
{
    classPointer->flags = newvalue;
}

API_EXPORT NxU32 get_NxForceFieldDesc_flags(NxForceFieldDesc* classPointer)
{
    return classPointer->flags;
}

API_EXPORT void set_NxForceFieldDesc_name(NxForceFieldDesc* classPointer, const char* newvalue)
{
    classPointer->name = newvalue;
}

API_EXPORT const char* get_NxForceFieldDesc_name(NxForceFieldDesc* classPointer)
{
    return classPointer->name;
}

API_EXPORT void set_NxForceFieldDesc_userData(NxForceFieldDesc* classPointer, void* newvalue)
{
    classPointer->userData = newvalue;
}

API_EXPORT void* get_NxForceFieldDesc_userData(NxForceFieldDesc* classPointer)
{
    return classPointer->userData;
}

API_EXPORT NxForceFieldDesc* new_NxForceFieldDesc(bool do_override)
{
    return new NxForceFieldDesc();
}

API_EXPORT void NxForceFieldDesc_setToDefault(NxForceFieldDesc* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxForceFieldDesc::setToDefault() : classPointer->setToDefault();
}

API_EXPORT bool NxForceFieldDesc_isValid(NxForceFieldDesc* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxForceFieldDesc::isValid() : classPointer->isValid();
}

API_EXPORT void set_NxForceFieldKernel_userData(NxForceFieldKernel* classPointer, void* newvalue)
{
    classPointer->userData = newvalue;
}

API_EXPORT void* get_NxForceFieldKernel_userData(NxForceFieldKernel* classPointer)
{
    return classPointer->userData;
}

API_EXPORT void NxForceFieldKernel_parse(NxForceFieldKernel* classPointer, bool call_explicit)
{
    classPointer->parse();
}

API_EXPORT bool NxForceFieldKernel_evaluate(NxForceFieldKernel* classPointer, bool call_explicit, NxVec3& force, NxVec3& torque, NxVec3& position, NxVec3& velocity)
{
    return classPointer->evaluate(force, torque, position, velocity);
}

API_EXPORT NxU32 NxForceFieldKernel_getType(NxForceFieldKernel* classPointer, bool call_explicit)
{
    return classPointer->getType();
}

API_EXPORT NxForceFieldKernel* NxForceFieldKernel_clone(NxForceFieldKernel* classPointer, bool call_explicit)
{
    return classPointer->clone();
}

API_EXPORT void NxForceFieldKernel_update(NxForceFieldKernel* classPointer, bool call_explicit, NxForceFieldKernel* in)
{
    classPointer->update(*in);
}

API_EXPORT void NxForceFieldKernel_setEpsilon(NxForceFieldKernel* classPointer, bool call_explicit, NxReal eps)
{
    classPointer->setEpsilon(eps);
}

API_EXPORT NxForceFieldLinearKernel* new_NxForceFieldLinearKernel(bool do_override)
{
    return (do_override) ? new NxForceFieldLinearKernel_doxybind() : NULL;
}

API_EXPORT NxVec3 NxForceFieldLinearKernel_getConstant(NxForceFieldLinearKernel* classPointer, bool call_explicit)
{
    return classPointer->getConstant();
}

API_EXPORT void NxForceFieldLinearKernel_setConstant(NxForceFieldLinearKernel* classPointer, bool call_explicit, NxVec3& unknown11)
{
    classPointer->setConstant(unknown11);
}

API_EXPORT NxMat33 NxForceFieldLinearKernel_getPositionMultiplier(NxForceFieldLinearKernel* classPointer, bool call_explicit)
{
    return classPointer->getPositionMultiplier();
}

API_EXPORT void NxForceFieldLinearKernel_setPositionMultiplier(NxForceFieldLinearKernel* classPointer, bool call_explicit, NxMat33& unknown12)
{
    classPointer->setPositionMultiplier(unknown12);
}

API_EXPORT NxMat33 NxForceFieldLinearKernel_getVelocityMultiplier(NxForceFieldLinearKernel* classPointer, bool call_explicit)
{
    return classPointer->getVelocityMultiplier();
}

API_EXPORT void NxForceFieldLinearKernel_setVelocityMultiplier(NxForceFieldLinearKernel* classPointer, bool call_explicit, NxMat33& unknown13)
{
    classPointer->setVelocityMultiplier(unknown13);
}

API_EXPORT NxVec3 NxForceFieldLinearKernel_getPositionTarget(NxForceFieldLinearKernel* classPointer, bool call_explicit)
{
    return classPointer->getPositionTarget();
}

API_EXPORT void NxForceFieldLinearKernel_setPositionTarget(NxForceFieldLinearKernel* classPointer, bool call_explicit, NxVec3& unknown14)
{
    classPointer->setPositionTarget(unknown14);
}

API_EXPORT NxVec3 NxForceFieldLinearKernel_getVelocityTarget(NxForceFieldLinearKernel* classPointer, bool call_explicit)
{
    return classPointer->getVelocityTarget();
}

API_EXPORT void NxForceFieldLinearKernel_setVelocityTarget(NxForceFieldLinearKernel* classPointer, bool call_explicit, NxVec3& unknown15)
{
    classPointer->setVelocityTarget(unknown15);
}

API_EXPORT NxVec3 NxForceFieldLinearKernel_getFalloffLinear(NxForceFieldLinearKernel* classPointer, bool call_explicit)
{
    return classPointer->getFalloffLinear();
}

API_EXPORT void NxForceFieldLinearKernel_setFalloffLinear(NxForceFieldLinearKernel* classPointer, bool call_explicit, NxVec3& unknown16)
{
    classPointer->setFalloffLinear(unknown16);
}

API_EXPORT NxVec3 NxForceFieldLinearKernel_getFalloffQuadratic(NxForceFieldLinearKernel* classPointer, bool call_explicit)
{
    return classPointer->getFalloffQuadratic();
}

API_EXPORT void NxForceFieldLinearKernel_setFalloffQuadratic(NxForceFieldLinearKernel* classPointer, bool call_explicit, NxVec3& unknown17)
{
    classPointer->setFalloffQuadratic(unknown17);
}

API_EXPORT NxVec3 NxForceFieldLinearKernel_getNoise(NxForceFieldLinearKernel* classPointer, bool call_explicit)
{
    return classPointer->getNoise();
}

API_EXPORT void NxForceFieldLinearKernel_setNoise(NxForceFieldLinearKernel* classPointer, bool call_explicit, NxVec3& unknown18)
{
    classPointer->setNoise(unknown18);
}

API_EXPORT NxReal NxForceFieldLinearKernel_getTorusRadius(NxForceFieldLinearKernel* classPointer, bool call_explicit)
{
    return classPointer->getTorusRadius();
}

API_EXPORT void NxForceFieldLinearKernel_setTorusRadius(NxForceFieldLinearKernel* classPointer, bool call_explicit, NxReal unknown19)
{
    classPointer->setTorusRadius(unknown19);
}

API_EXPORT NxScene* NxForceFieldLinearKernel_getScene(NxForceFieldLinearKernel* classPointer, bool call_explicit)
{
    return &classPointer->getScene();
}

API_EXPORT void NxForceFieldLinearKernel_saveToDesc(NxForceFieldLinearKernel* classPointer, bool call_explicit, NxForceFieldLinearKernelDesc* desc)
{
    classPointer->saveToDesc(*desc);
}

API_EXPORT void NxForceFieldLinearKernel_setName(NxForceFieldLinearKernel* classPointer, bool call_explicit, char* name)
{
    classPointer->setName(name);
}

API_EXPORT const char* NxForceFieldLinearKernel_getName(NxForceFieldLinearKernel* classPointer, bool call_explicit)
{
    return classPointer->getName();
}

API_EXPORT void set_NxForceFieldLinearKernelDesc_constant(NxForceFieldLinearKernelDesc* classPointer, NxVec3 newvalue)
{
    classPointer->constant = newvalue;
}

API_EXPORT NxVec3 get_NxForceFieldLinearKernelDesc_constant(NxForceFieldLinearKernelDesc* classPointer)
{
    return classPointer->constant;
}

API_EXPORT void set_NxForceFieldLinearKernelDesc_positionMultiplier(NxForceFieldLinearKernelDesc* classPointer, NxMat33 newvalue)
{
    classPointer->positionMultiplier = newvalue;
}

API_EXPORT NxMat33 get_NxForceFieldLinearKernelDesc_positionMultiplier(NxForceFieldLinearKernelDesc* classPointer)
{
    return classPointer->positionMultiplier;
}

API_EXPORT void set_NxForceFieldLinearKernelDesc_positionTarget(NxForceFieldLinearKernelDesc* classPointer, NxVec3 newvalue)
{
    classPointer->positionTarget = newvalue;
}

API_EXPORT NxVec3 get_NxForceFieldLinearKernelDesc_positionTarget(NxForceFieldLinearKernelDesc* classPointer)
{
    return classPointer->positionTarget;
}

API_EXPORT void set_NxForceFieldLinearKernelDesc_velocityMultiplier(NxForceFieldLinearKernelDesc* classPointer, NxMat33 newvalue)
{
    classPointer->velocityMultiplier = newvalue;
}

API_EXPORT NxMat33 get_NxForceFieldLinearKernelDesc_velocityMultiplier(NxForceFieldLinearKernelDesc* classPointer)
{
    return classPointer->velocityMultiplier;
}

API_EXPORT void set_NxForceFieldLinearKernelDesc_velocityTarget(NxForceFieldLinearKernelDesc* classPointer, NxVec3 newvalue)
{
    classPointer->velocityTarget = newvalue;
}

API_EXPORT NxVec3 get_NxForceFieldLinearKernelDesc_velocityTarget(NxForceFieldLinearKernelDesc* classPointer)
{
    return classPointer->velocityTarget;
}

API_EXPORT void set_NxForceFieldLinearKernelDesc_torusRadius(NxForceFieldLinearKernelDesc* classPointer, NxReal newvalue)
{
    classPointer->torusRadius = newvalue;
}

API_EXPORT NxReal get_NxForceFieldLinearKernelDesc_torusRadius(NxForceFieldLinearKernelDesc* classPointer)
{
    return classPointer->torusRadius;
}

API_EXPORT void set_NxForceFieldLinearKernelDesc_falloffLinear(NxForceFieldLinearKernelDesc* classPointer, NxVec3 newvalue)
{
    classPointer->falloffLinear = newvalue;
}

API_EXPORT NxVec3 get_NxForceFieldLinearKernelDesc_falloffLinear(NxForceFieldLinearKernelDesc* classPointer)
{
    return classPointer->falloffLinear;
}

API_EXPORT void set_NxForceFieldLinearKernelDesc_falloffQuadratic(NxForceFieldLinearKernelDesc* classPointer, NxVec3 newvalue)
{
    classPointer->falloffQuadratic = newvalue;
}

API_EXPORT NxVec3 get_NxForceFieldLinearKernelDesc_falloffQuadratic(NxForceFieldLinearKernelDesc* classPointer)
{
    return classPointer->falloffQuadratic;
}

API_EXPORT void set_NxForceFieldLinearKernelDesc_noise(NxForceFieldLinearKernelDesc* classPointer, NxVec3 newvalue)
{
    classPointer->noise = newvalue;
}

API_EXPORT NxVec3 get_NxForceFieldLinearKernelDesc_noise(NxForceFieldLinearKernelDesc* classPointer)
{
    return classPointer->noise;
}

API_EXPORT void set_NxForceFieldLinearKernelDesc_name(NxForceFieldLinearKernelDesc* classPointer, const char* newvalue)
{
    classPointer->name = newvalue;
}

API_EXPORT const char* get_NxForceFieldLinearKernelDesc_name(NxForceFieldLinearKernelDesc* classPointer)
{
    return classPointer->name;
}

API_EXPORT void set_NxForceFieldLinearKernelDesc_userData(NxForceFieldLinearKernelDesc* classPointer, void* newvalue)
{
    classPointer->userData = newvalue;
}

API_EXPORT void* get_NxForceFieldLinearKernelDesc_userData(NxForceFieldLinearKernelDesc* classPointer)
{
    return classPointer->userData;
}

API_EXPORT NxForceFieldLinearKernelDesc* new_NxForceFieldLinearKernelDesc(bool do_override)
{
    return new NxForceFieldLinearKernelDesc();
}

API_EXPORT void NxForceFieldLinearKernelDesc_setToDefault(NxForceFieldLinearKernelDesc* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxForceFieldLinearKernelDesc::setToDefault() : classPointer->setToDefault();
}

API_EXPORT bool NxForceFieldLinearKernelDesc_isValid(NxForceFieldLinearKernelDesc* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxForceFieldLinearKernelDesc::isValid() : classPointer->isValid();
}

API_EXPORT void set_NxForceFieldShapeGroup_userData(NxForceFieldShapeGroup* classPointer, void* newvalue)
{
    classPointer->userData = newvalue;
}

API_EXPORT void* get_NxForceFieldShapeGroup_userData(NxForceFieldShapeGroup* classPointer)
{
    return classPointer->userData;
}

API_EXPORT NxForceFieldShapeGroup* new_NxForceFieldShapeGroup(bool do_override)
{
    return (do_override) ? new NxForceFieldShapeGroup_doxybind() : NULL;
}

API_EXPORT NxForceFieldShape* NxForceFieldShapeGroup_createShape(NxForceFieldShapeGroup* classPointer, bool call_explicit, NxForceFieldShapeDesc* unknown20)
{
    return classPointer->createShape(*unknown20);
}

API_EXPORT void NxForceFieldShapeGroup_releaseShape(NxForceFieldShapeGroup* classPointer, bool call_explicit, NxForceFieldShape* unknown21)
{
    classPointer->releaseShape(*unknown21);
}

API_EXPORT NxU32 NxForceFieldShapeGroup_getNbShapes(NxForceFieldShapeGroup* classPointer, bool call_explicit)
{
    return classPointer->getNbShapes();
}

API_EXPORT void NxForceFieldShapeGroup_resetShapesIterator(NxForceFieldShapeGroup* classPointer, bool call_explicit)
{
    classPointer->resetShapesIterator();
}

API_EXPORT NxForceFieldShape* NxForceFieldShapeGroup_getNextShape(NxForceFieldShapeGroup* classPointer, bool call_explicit)
{
    return classPointer->getNextShape();
}

API_EXPORT NxForceField* NxForceFieldShapeGroup_getForceField(NxForceFieldShapeGroup* classPointer, bool call_explicit)
{
    return classPointer->getForceField();
}

API_EXPORT NxU32 NxForceFieldShapeGroup_getFlags(NxForceFieldShapeGroup* classPointer, bool call_explicit)
{
    return classPointer->getFlags();
}

API_EXPORT void NxForceFieldShapeGroup_saveToDesc(NxForceFieldShapeGroup* classPointer, bool call_explicit, NxForceFieldShapeGroupDesc* desc)
{
    classPointer->saveToDesc(*desc);
}

API_EXPORT NxScene* NxForceFieldShapeGroup_getScene(NxForceFieldShapeGroup* classPointer, bool call_explicit)
{
    return &classPointer->getScene();
}

API_EXPORT void NxForceFieldShapeGroup_setName(NxForceFieldShapeGroup* classPointer, bool call_explicit, char* name)
{
    classPointer->setName(name);
}

API_EXPORT const char* NxForceFieldShapeGroup_getName(NxForceFieldShapeGroup* classPointer, bool call_explicit)
{
    return classPointer->getName();
}

API_EXPORT void set_NxForceFieldShapeGroupDesc_flags(NxForceFieldShapeGroupDesc* classPointer, NxU32 newvalue)
{
    classPointer->flags = newvalue;
}

API_EXPORT NxU32 get_NxForceFieldShapeGroupDesc_flags(NxForceFieldShapeGroupDesc* classPointer)
{
    return classPointer->flags;
}

API_EXPORT void set_NxForceFieldShapeGroupDesc_shapes(NxForceFieldShapeGroupDesc* classPointer, NxArray< NxForceFieldShapeDesc* >* newvalue)
{
    classPointer->shapes = *newvalue;
}

API_EXPORT NxArray< NxForceFieldShapeDesc* >* get_NxForceFieldShapeGroupDesc_shapes(NxForceFieldShapeGroupDesc* classPointer)
{
    return &classPointer->shapes;
}

API_EXPORT void set_NxForceFieldShapeGroupDesc_name(NxForceFieldShapeGroupDesc* classPointer, const char* newvalue)
{
    classPointer->name = newvalue;
}

API_EXPORT const char* get_NxForceFieldShapeGroupDesc_name(NxForceFieldShapeGroupDesc* classPointer)
{
    return classPointer->name;
}

API_EXPORT void set_NxForceFieldShapeGroupDesc_userData(NxForceFieldShapeGroupDesc* classPointer, void* newvalue)
{
    classPointer->userData = newvalue;
}

API_EXPORT void* get_NxForceFieldShapeGroupDesc_userData(NxForceFieldShapeGroupDesc* classPointer)
{
    return classPointer->userData;
}

API_EXPORT NxForceFieldShapeGroupDesc* new_NxForceFieldShapeGroupDesc(bool do_override)
{
    return new NxForceFieldShapeGroupDesc();
}

API_EXPORT void NxForceFieldShapeGroupDesc_setToDefault(NxForceFieldShapeGroupDesc* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxForceFieldShapeGroupDesc::setToDefault() : classPointer->setToDefault();
}

API_EXPORT bool NxForceFieldShapeGroupDesc_isValid(NxForceFieldShapeGroupDesc* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxForceFieldShapeGroupDesc::isValid() : classPointer->isValid();
}

API_EXPORT void NxFoundationSDK_release(NxFoundationSDK* classPointer, bool call_explicit)
{
    classPointer->release();
}

API_EXPORT void NxFoundationSDK_setErrorStream(NxFoundationSDK* classPointer, bool call_explicit, NxUserOutputStream* stream)
{
    classPointer->setErrorStream(stream);
}

API_EXPORT NxUserOutputStream* NxFoundationSDK_getErrorStream(NxFoundationSDK* classPointer, bool call_explicit)
{
    return classPointer->getErrorStream();
}

API_EXPORT NxErrorCode NxFoundationSDK_getLastError(NxFoundationSDK* classPointer, bool call_explicit)
{
    return classPointer->getLastError();
}

API_EXPORT NxErrorCode NxFoundationSDK_getFirstError(NxFoundationSDK* classPointer, bool call_explicit)
{
    return classPointer->getFirstError();
}

API_EXPORT NxUserAllocator* NxFoundationSDK_getAllocator(NxFoundationSDK* classPointer, bool call_explicit)
{
    return &classPointer->getAllocator();
}

API_EXPORT NxRemoteDebugger* NxFoundationSDK_getRemoteDebugger(NxFoundationSDK* classPointer, bool call_explicit)
{
    return classPointer->getRemoteDebugger();
}

API_EXPORT void NxFoundationSDK_setAllocaThreshold(NxFoundationSDK* classPointer, bool call_explicit, NxU32 threshold)
{
    classPointer->setAllocaThreshold(threshold);
}

API_EXPORT void set_NxGroupsMask_bits0(NxGroupsMask* classPointer, NxU32 newvalue)
{
    classPointer->bits0 = newvalue;
}

API_EXPORT NxU32 get_NxGroupsMask_bits0(NxGroupsMask* classPointer)
{
    return classPointer->bits0;
}

API_EXPORT void set_NxGroupsMask_bits1(NxGroupsMask* classPointer, NxU32 newvalue)
{
    classPointer->bits1 = newvalue;
}

API_EXPORT NxU32 get_NxGroupsMask_bits1(NxGroupsMask* classPointer)
{
    return classPointer->bits1;
}

API_EXPORT void set_NxGroupsMask_bits2(NxGroupsMask* classPointer, NxU32 newvalue)
{
    classPointer->bits2 = newvalue;
}

API_EXPORT NxU32 get_NxGroupsMask_bits2(NxGroupsMask* classPointer)
{
    return classPointer->bits2;
}

API_EXPORT void set_NxGroupsMask_bits3(NxGroupsMask* classPointer, NxU32 newvalue)
{
    classPointer->bits3 = newvalue;
}

API_EXPORT NxU32 get_NxGroupsMask_bits3(NxGroupsMask* classPointer)
{
    return classPointer->bits3;
}

API_EXPORT NxGroupsMask* new_NxGroupsMask(bool do_override)
{
    return new NxGroupsMask();
}

API_EXPORT bool NxHeightField_saveToDesc(NxHeightField* classPointer, bool call_explicit, NxHeightFieldDesc* desc)
{
    return classPointer->saveToDesc(*desc);
}

API_EXPORT bool NxHeightField_loadFromDesc(NxHeightField* classPointer, bool call_explicit, NxHeightFieldDesc* desc)
{
    return classPointer->loadFromDesc(*desc);
}

API_EXPORT NxU32 NxHeightField_saveCells(NxHeightField* classPointer, bool call_explicit, void* destBuffer, NxU32 destBufferSize)
{
    return classPointer->saveCells(destBuffer, destBufferSize);
}

API_EXPORT NxU32 NxHeightField_getNbRows(NxHeightField* classPointer, bool call_explicit)
{
    return classPointer->getNbRows();
}

API_EXPORT NxU32 NxHeightField_getNbColumns(NxHeightField* classPointer, bool call_explicit)
{
    return classPointer->getNbColumns();
}

API_EXPORT NxHeightFieldFormat NxHeightField_getFormat(NxHeightField* classPointer, bool call_explicit)
{
    return classPointer->getFormat();
}

API_EXPORT NxU32 NxHeightField_getSampleStride(NxHeightField* classPointer, bool call_explicit)
{
    return classPointer->getSampleStride();
}

API_EXPORT NxReal NxHeightField_getVerticalExtent(NxHeightField* classPointer, bool call_explicit)
{
    return classPointer->getVerticalExtent();
}

API_EXPORT NxReal NxHeightField_getThickness(NxHeightField* classPointer, bool call_explicit)
{
    return classPointer->getThickness();
}

API_EXPORT NxReal NxHeightField_getConvexEdgeThreshold(NxHeightField* classPointer, bool call_explicit)
{
    return classPointer->getConvexEdgeThreshold();
}

API_EXPORT NxU32 NxHeightField_getFlags(NxHeightField* classPointer, bool call_explicit)
{
    return classPointer->getFlags();
}

API_EXPORT NxReal NxHeightField_getHeight(NxHeightField* classPointer, bool call_explicit, NxReal x, NxReal z)
{
    return classPointer->getHeight(x, z);
}

API_EXPORT const void* NxHeightField_getCells(NxHeightField* classPointer, bool call_explicit)
{
    return classPointer->getCells();
}

API_EXPORT NxU32 NxHeightField_getReferenceCount(NxHeightField* classPointer, bool call_explicit)
{
    return classPointer->getReferenceCount();
}

API_EXPORT void set_NxHeightFieldDesc_nbRows(NxHeightFieldDesc* classPointer, NxU32 newvalue)
{
    classPointer->nbRows = newvalue;
}

API_EXPORT NxU32 get_NxHeightFieldDesc_nbRows(NxHeightFieldDesc* classPointer)
{
    return classPointer->nbRows;
}

API_EXPORT void set_NxHeightFieldDesc_nbColumns(NxHeightFieldDesc* classPointer, NxU32 newvalue)
{
    classPointer->nbColumns = newvalue;
}

API_EXPORT NxU32 get_NxHeightFieldDesc_nbColumns(NxHeightFieldDesc* classPointer)
{
    return classPointer->nbColumns;
}

API_EXPORT void set_NxHeightFieldDesc_format(NxHeightFieldDesc* classPointer, NxHeightFieldFormat newvalue)
{
    classPointer->format = newvalue;
}

API_EXPORT NxHeightFieldFormat get_NxHeightFieldDesc_format(NxHeightFieldDesc* classPointer)
{
    return classPointer->format;
}

API_EXPORT void set_NxHeightFieldDesc_sampleStride(NxHeightFieldDesc* classPointer, NxU32 newvalue)
{
    classPointer->sampleStride = newvalue;
}

API_EXPORT NxU32 get_NxHeightFieldDesc_sampleStride(NxHeightFieldDesc* classPointer)
{
    return classPointer->sampleStride;
}

API_EXPORT void set_NxHeightFieldDesc_samples(NxHeightFieldDesc* classPointer, void* newvalue)
{
    classPointer->samples = newvalue;
}

API_EXPORT void* get_NxHeightFieldDesc_samples(NxHeightFieldDesc* classPointer)
{
    return classPointer->samples;
}

API_EXPORT void set_NxHeightFieldDesc_verticalExtent(NxHeightFieldDesc* classPointer, NxReal newvalue)
{
    classPointer->verticalExtent = newvalue;
}

API_EXPORT NxReal get_NxHeightFieldDesc_verticalExtent(NxHeightFieldDesc* classPointer)
{
    return classPointer->verticalExtent;
}

API_EXPORT void set_NxHeightFieldDesc_thickness(NxHeightFieldDesc* classPointer, NxReal newvalue)
{
    classPointer->thickness = newvalue;
}

API_EXPORT NxReal get_NxHeightFieldDesc_thickness(NxHeightFieldDesc* classPointer)
{
    return classPointer->thickness;
}

API_EXPORT void set_NxHeightFieldDesc_convexEdgeThreshold(NxHeightFieldDesc* classPointer, NxReal newvalue)
{
    classPointer->convexEdgeThreshold = newvalue;
}

API_EXPORT NxReal get_NxHeightFieldDesc_convexEdgeThreshold(NxHeightFieldDesc* classPointer)
{
    return classPointer->convexEdgeThreshold;
}

API_EXPORT void set_NxHeightFieldDesc_flags(NxHeightFieldDesc* classPointer, NxU32 newvalue)
{
    classPointer->flags = newvalue;
}

API_EXPORT NxU32 get_NxHeightFieldDesc_flags(NxHeightFieldDesc* classPointer)
{
    return classPointer->flags;
}

API_EXPORT NxHeightFieldDesc* new_NxHeightFieldDesc(bool do_override)
{
    return new NxHeightFieldDesc();
}

API_EXPORT void NxHeightFieldDesc_setToDefault(NxHeightFieldDesc* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxHeightFieldDesc::setToDefault() : classPointer->setToDefault();
}

API_EXPORT bool NxHeightFieldDesc_isValid(NxHeightFieldDesc* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxHeightFieldDesc::isValid() : classPointer->isValid();
}

API_EXPORT void set_NxHeightFieldSample_height(NxHeightFieldSample* classPointer, NxI16 newvalue)
{
    classPointer->height = newvalue;
}

API_EXPORT NxI16 get_NxHeightFieldSample_height(NxHeightFieldSample* classPointer)
{
    return classPointer->height;
}

API_EXPORT void set_NxHeightFieldSample_materialIndex0(NxHeightFieldSample* classPointer, NxU8 newvalue)
{
    classPointer->materialIndex0 = newvalue;
}

API_EXPORT NxU8 get_NxHeightFieldSample_materialIndex0(NxHeightFieldSample* classPointer)
{
    return classPointer->materialIndex0;
}

API_EXPORT void set_NxHeightFieldSample_tessFlag(NxHeightFieldSample* classPointer, NxU8 newvalue)
{
    classPointer->tessFlag = newvalue;
}

API_EXPORT NxU8 get_NxHeightFieldSample_tessFlag(NxHeightFieldSample* classPointer)
{
    return classPointer->tessFlag;
}

API_EXPORT void set_NxHeightFieldSample_materialIndex1(NxHeightFieldSample* classPointer, NxU8 newvalue)
{
    classPointer->materialIndex1 = newvalue;
}

API_EXPORT NxU8 get_NxHeightFieldSample_materialIndex1(NxHeightFieldSample* classPointer)
{
    return classPointer->materialIndex1;
}

API_EXPORT void set_NxHeightFieldSample_unused(NxHeightFieldSample* classPointer, NxU8 newvalue)
{
    classPointer->unused = newvalue;
}

API_EXPORT NxU8 get_NxHeightFieldSample_unused(NxHeightFieldSample* classPointer)
{
    return classPointer->unused;
}

API_EXPORT void NxHeightFieldShape_saveToDesc(NxHeightFieldShape* classPointer, bool call_explicit, NxHeightFieldShapeDesc* desc)
{
    classPointer->saveToDesc(*desc);
}

API_EXPORT NxHeightField* NxHeightFieldShape_getHeightField(NxHeightFieldShape* classPointer, bool call_explicit)
{
    return &classPointer->getHeightField();
}

API_EXPORT NxReal NxHeightFieldShape_getHeightScale(NxHeightFieldShape* classPointer, bool call_explicit)
{
    return classPointer->getHeightScale();
}

API_EXPORT NxReal NxHeightFieldShape_getRowScale(NxHeightFieldShape* classPointer, bool call_explicit)
{
    return classPointer->getRowScale();
}

API_EXPORT NxReal NxHeightFieldShape_getColumnScale(NxHeightFieldShape* classPointer, bool call_explicit)
{
    return classPointer->getColumnScale();
}

API_EXPORT void NxHeightFieldShape_setHeightScale(NxHeightFieldShape* classPointer, bool call_explicit, NxReal scale)
{
    classPointer->setHeightScale(scale);
}

API_EXPORT void NxHeightFieldShape_setRowScale(NxHeightFieldShape* classPointer, bool call_explicit, NxReal scale)
{
    classPointer->setRowScale(scale);
}

API_EXPORT void NxHeightFieldShape_setColumnScale(NxHeightFieldShape* classPointer, bool call_explicit, NxReal scale)
{
    classPointer->setColumnScale(scale);
}

API_EXPORT NxU32 NxHeightFieldShape_getTriangle(NxHeightFieldShape* classPointer, bool call_explicit, NxTriangle* worldTri, NxTriangle* edgeTri, NxU32* flags, NxTriangleID triangleIndex, bool worldSpaceTranslation, bool worldSpaceRotation)
{
    return classPointer->getTriangle(*worldTri, edgeTri, flags, triangleIndex, worldSpaceTranslation, worldSpaceRotation);
}

API_EXPORT NxU32 NxHeightFieldShape_getTriangle_1(NxHeightFieldShape* classPointer, bool call_explicit, NxTriangle* worldTri, NxTriangle* edgeTri, NxU32* flags, NxTriangleID triangleIndex, bool worldSpaceTranslation)
{
    return classPointer->getTriangle(*worldTri, edgeTri, flags, triangleIndex, worldSpaceTranslation);
}

API_EXPORT NxU32 NxHeightFieldShape_getTriangle_2(NxHeightFieldShape* classPointer, bool call_explicit, NxTriangle* worldTri, NxTriangle* edgeTri, NxU32* flags, NxTriangleID triangleIndex)
{
    return classPointer->getTriangle(*worldTri, edgeTri, flags, triangleIndex);
}

API_EXPORT bool NxHeightFieldShape_overlapAABBTriangles(NxHeightFieldShape* classPointer, bool call_explicit, NxBounds3* bounds, NxU32 flags, NxU32& nb, const NxU32*& indices)
{
    return (call_explicit) ? classPointer->NxHeightFieldShape::overlapAABBTriangles(*bounds, flags, nb, indices) : classPointer->overlapAABBTriangles(*bounds, flags, nb, indices);
}

API_EXPORT bool NxHeightFieldShape_overlapAABBTrianglesDeprecated(NxHeightFieldShape* classPointer, bool call_explicit, NxBounds3* bounds, NxU32 flags, NxU32& nb, const NxU32*& indices)
{
    return classPointer->overlapAABBTrianglesDeprecated(*bounds, flags, nb, indices);
}

API_EXPORT bool NxHeightFieldShape_overlapAABBTriangles_1(NxHeightFieldShape* classPointer, bool call_explicit, NxBounds3* bounds, NxU32 flags, NxUserEntityReport< NxU32 >* callback)
{
    return classPointer->overlapAABBTriangles(*bounds, flags, callback);
}

API_EXPORT bool NxHeightFieldShape_isShapePointOnHeightField(NxHeightFieldShape* classPointer, bool call_explicit, NxReal x, NxReal z)
{
    return classPointer->isShapePointOnHeightField(x, z);
}

API_EXPORT NxReal NxHeightFieldShape_getHeightAtShapePoint(NxHeightFieldShape* classPointer, bool call_explicit, NxReal x, NxReal z)
{
    return classPointer->getHeightAtShapePoint(x, z);
}

API_EXPORT NxMaterialIndex NxHeightFieldShape_getMaterialAtShapePoint(NxHeightFieldShape* classPointer, bool call_explicit, NxReal x, NxReal z)
{
    return classPointer->getMaterialAtShapePoint(x, z);
}

API_EXPORT NxVec3 NxHeightFieldShape_getNormalAtShapePoint(NxHeightFieldShape* classPointer, bool call_explicit, NxReal x, NxReal z)
{
    return classPointer->getNormalAtShapePoint(x, z);
}

API_EXPORT NxVec3 NxHeightFieldShape_getSmoothNormalAtShapePoint(NxHeightFieldShape* classPointer, bool call_explicit, NxReal x, NxReal z)
{
    return classPointer->getSmoothNormalAtShapePoint(x, z);
}

API_EXPORT void set_NxHeightFieldShapeDesc_heightField(NxHeightFieldShapeDesc* classPointer, NxHeightField* newvalue)
{
    classPointer->heightField = newvalue;
}

API_EXPORT NxHeightField* get_NxHeightFieldShapeDesc_heightField(NxHeightFieldShapeDesc* classPointer)
{
    return classPointer->heightField;
}

API_EXPORT void set_NxHeightFieldShapeDesc_heightScale(NxHeightFieldShapeDesc* classPointer, NxReal newvalue)
{
    classPointer->heightScale = newvalue;
}

API_EXPORT NxReal get_NxHeightFieldShapeDesc_heightScale(NxHeightFieldShapeDesc* classPointer)
{
    return classPointer->heightScale;
}

API_EXPORT void set_NxHeightFieldShapeDesc_rowScale(NxHeightFieldShapeDesc* classPointer, NxReal newvalue)
{
    classPointer->rowScale = newvalue;
}

API_EXPORT NxReal get_NxHeightFieldShapeDesc_rowScale(NxHeightFieldShapeDesc* classPointer)
{
    return classPointer->rowScale;
}

API_EXPORT void set_NxHeightFieldShapeDesc_columnScale(NxHeightFieldShapeDesc* classPointer, NxReal newvalue)
{
    classPointer->columnScale = newvalue;
}

API_EXPORT NxReal get_NxHeightFieldShapeDesc_columnScale(NxHeightFieldShapeDesc* classPointer)
{
    return classPointer->columnScale;
}

API_EXPORT void set_NxHeightFieldShapeDesc_materialIndexHighBits(NxHeightFieldShapeDesc* classPointer, NxMaterialIndex newvalue)
{
    classPointer->materialIndexHighBits = newvalue;
}

API_EXPORT NxMaterialIndex get_NxHeightFieldShapeDesc_materialIndexHighBits(NxHeightFieldShapeDesc* classPointer)
{
    return classPointer->materialIndexHighBits;
}

API_EXPORT void set_NxHeightFieldShapeDesc_holeMaterial(NxHeightFieldShapeDesc* classPointer, NxMaterialIndex newvalue)
{
    classPointer->holeMaterial = newvalue;
}

API_EXPORT NxMaterialIndex get_NxHeightFieldShapeDesc_holeMaterial(NxHeightFieldShapeDesc* classPointer)
{
    return classPointer->holeMaterial;
}

API_EXPORT void set_NxHeightFieldShapeDesc_meshFlags(NxHeightFieldShapeDesc* classPointer, NxU32 newvalue)
{
    classPointer->meshFlags = newvalue;
}

API_EXPORT NxU32 get_NxHeightFieldShapeDesc_meshFlags(NxHeightFieldShapeDesc* classPointer)
{
    return classPointer->meshFlags;
}

API_EXPORT NxHeightFieldShapeDesc* new_NxHeightFieldShapeDesc(bool do_override)
{
    return (do_override) ? new NxHeightFieldShapeDesc_doxybind() : new NxHeightFieldShapeDesc();
}

API_EXPORT void NxHeightFieldShapeDesc_setToDefault(NxHeightFieldShapeDesc* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxHeightFieldShapeDesc::setToDefault() : classPointer->setToDefault();
}

API_EXPORT bool NxHeightFieldShapeDesc_isValid(NxHeightFieldShapeDesc* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxHeightFieldShapeDesc::isValid() : classPointer->isValid();
}

API_EXPORT void set_NxIntegrals_COM(NxIntegrals* classPointer, NxVec3 newvalue)
{
    classPointer->COM = newvalue;
}

API_EXPORT NxVec3 get_NxIntegrals_COM(NxIntegrals* classPointer)
{
    return classPointer->COM;
}

API_EXPORT void set_NxIntegrals_mass(NxIntegrals* classPointer, NxF64 newvalue)
{
    classPointer->mass = newvalue;
}

API_EXPORT NxF64 get_NxIntegrals_mass(NxIntegrals* classPointer)
{
    return classPointer->mass;
}

API_EXPORT void set_NxIntegrals_inertiaTensor(NxIntegrals* classPointer, NxF64 newvalue[3][3])
{
    memcpy(&classPointer->inertiaTensor[0], &newvalue[0], sizeof(NxF64) * 9);
}

API_EXPORT void get_NxIntegrals_inertiaTensor(NxIntegrals* classPointer, NxF64 newvalue[3][3])
{
    memcpy(&newvalue[0], &classPointer->inertiaTensor[0], sizeof(NxF64) * 9);
}

API_EXPORT void set_NxIntegrals_COMInertiaTensor(NxIntegrals* classPointer, NxF64 newvalue[3][3])
{
    memcpy(&classPointer->COMInertiaTensor[0], &newvalue[0], sizeof(NxF64) * 9);
}

API_EXPORT void get_NxIntegrals_COMInertiaTensor(NxIntegrals* classPointer, NxF64 newvalue[3][3])
{
    memcpy(&newvalue[0], &classPointer->COMInertiaTensor[0], sizeof(NxF64) * 9);
}

API_EXPORT void NxIntegrals_getInertia(NxIntegrals* classPointer, bool call_explicit, NxMat33& inertia)
{
    (call_explicit) ? classPointer->NxIntegrals::getInertia(inertia) : classPointer->getInertia(inertia);
}

API_EXPORT void NxIntegrals_getOriginInertia(NxIntegrals* classPointer, bool call_explicit, NxMat33& inertia)
{
    (call_explicit) ? classPointer->NxIntegrals::getOriginInertia(inertia) : classPointer->getOriginInertia(inertia);
}

API_EXPORT int NxInterface_getVersionNumber(NxInterface* classPointer, bool call_explicit)
{
    return classPointer->getVersionNumber();
}

API_EXPORT NxInterfaceType NxInterface_getInterfaceType(NxInterface* classPointer, bool call_explicit)
{
    return classPointer->getInterfaceType();
}

API_EXPORT int NxInterfaceStats_getVersionNumber(NxInterfaceStats* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxInterfaceStats::getVersionNumber() : classPointer->getVersionNumber();
}

API_EXPORT NxInterfaceType NxInterfaceStats_getInterfaceType(NxInterfaceStats* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxInterfaceStats::getInterfaceType() : classPointer->getInterfaceType();
}

API_EXPORT bool NxInterfaceStats_getHeapSize(NxInterfaceStats* classPointer, bool call_explicit, int& used, int& unused)
{
    return classPointer->getHeapSize(used, unused);
}

API_EXPORT void set_NxJointDriveDesc_driveType(NxJointDriveDesc* classPointer, NxBitField* newvalue)
{
    classPointer->driveType = *newvalue;
}

API_EXPORT NxBitField* get_NxJointDriveDesc_driveType(NxJointDriveDesc* classPointer)
{
    return &classPointer->driveType;
}

API_EXPORT void set_NxJointDriveDesc_spring(NxJointDriveDesc* classPointer, NxReal newvalue)
{
    classPointer->spring = newvalue;
}

API_EXPORT NxReal get_NxJointDriveDesc_spring(NxJointDriveDesc* classPointer)
{
    return classPointer->spring;
}

API_EXPORT void set_NxJointDriveDesc_damping(NxJointDriveDesc* classPointer, NxReal newvalue)
{
    classPointer->damping = newvalue;
}

API_EXPORT NxReal get_NxJointDriveDesc_damping(NxJointDriveDesc* classPointer)
{
    return classPointer->damping;
}

API_EXPORT void set_NxJointDriveDesc_forceLimit(NxJointDriveDesc* classPointer, NxReal newvalue)
{
    classPointer->forceLimit = newvalue;
}

API_EXPORT NxReal get_NxJointDriveDesc_forceLimit(NxJointDriveDesc* classPointer)
{
    return classPointer->forceLimit;
}

API_EXPORT NxJointDriveDesc* new_NxJointDriveDesc(bool do_override)
{
    return new NxJointDriveDesc();
}

API_EXPORT void set_NxJointLimitDesc_value(NxJointLimitDesc* classPointer, NxReal newvalue)
{
    classPointer->value = newvalue;
}

API_EXPORT NxReal get_NxJointLimitDesc_value(NxJointLimitDesc* classPointer)
{
    return classPointer->value;
}

API_EXPORT void set_NxJointLimitDesc_restitution(NxJointLimitDesc* classPointer, NxReal newvalue)
{
    classPointer->restitution = newvalue;
}

API_EXPORT NxReal get_NxJointLimitDesc_restitution(NxJointLimitDesc* classPointer)
{
    return classPointer->restitution;
}

API_EXPORT void set_NxJointLimitDesc_hardness(NxJointLimitDesc* classPointer, NxReal newvalue)
{
    classPointer->hardness = newvalue;
}

API_EXPORT NxReal get_NxJointLimitDesc_hardness(NxJointLimitDesc* classPointer)
{
    return classPointer->hardness;
}

API_EXPORT NxJointLimitDesc* new_NxJointLimitDesc(bool do_override)
{
    return new NxJointLimitDesc();
}

API_EXPORT void NxJointLimitDesc_setToDefault(NxJointLimitDesc* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxJointLimitDesc::setToDefault() : classPointer->setToDefault();
}

API_EXPORT bool NxJointLimitDesc_isValid(NxJointLimitDesc* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxJointLimitDesc::isValid() : classPointer->isValid();
}

API_EXPORT void set_NxJointLimitPairDesc_low(NxJointLimitPairDesc* classPointer, NxJointLimitDesc* newvalue)
{
    classPointer->low = *newvalue;
}

API_EXPORT NxJointLimitDesc* get_NxJointLimitPairDesc_low(NxJointLimitPairDesc* classPointer)
{
    return &classPointer->low;
}

API_EXPORT void set_NxJointLimitPairDesc_high(NxJointLimitPairDesc* classPointer, NxJointLimitDesc* newvalue)
{
    classPointer->high = *newvalue;
}

API_EXPORT NxJointLimitDesc* get_NxJointLimitPairDesc_high(NxJointLimitPairDesc* classPointer)
{
    return &classPointer->high;
}

API_EXPORT NxJointLimitPairDesc* new_NxJointLimitPairDesc(bool do_override)
{
    return new NxJointLimitPairDesc();
}

API_EXPORT void NxJointLimitPairDesc_setToDefault(NxJointLimitPairDesc* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxJointLimitPairDesc::setToDefault() : classPointer->setToDefault();
}

API_EXPORT bool NxJointLimitPairDesc_isValid(NxJointLimitPairDesc* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxJointLimitPairDesc::isValid() : classPointer->isValid();
}

API_EXPORT void set_NxJointLimitSoftDesc_value(NxJointLimitSoftDesc* classPointer, NxReal newvalue)
{
    classPointer->value = newvalue;
}

API_EXPORT NxReal get_NxJointLimitSoftDesc_value(NxJointLimitSoftDesc* classPointer)
{
    return classPointer->value;
}

API_EXPORT void set_NxJointLimitSoftDesc_restitution(NxJointLimitSoftDesc* classPointer, NxReal newvalue)
{
    classPointer->restitution = newvalue;
}

API_EXPORT NxReal get_NxJointLimitSoftDesc_restitution(NxJointLimitSoftDesc* classPointer)
{
    return classPointer->restitution;
}

API_EXPORT void set_NxJointLimitSoftDesc_spring(NxJointLimitSoftDesc* classPointer, NxReal newvalue)
{
    classPointer->spring = newvalue;
}

API_EXPORT NxReal get_NxJointLimitSoftDesc_spring(NxJointLimitSoftDesc* classPointer)
{
    return classPointer->spring;
}

API_EXPORT void set_NxJointLimitSoftDesc_damping(NxJointLimitSoftDesc* classPointer, NxReal newvalue)
{
    classPointer->damping = newvalue;
}

API_EXPORT NxReal get_NxJointLimitSoftDesc_damping(NxJointLimitSoftDesc* classPointer)
{
    return classPointer->damping;
}

API_EXPORT NxJointLimitSoftDesc* new_NxJointLimitSoftDesc(bool do_override)
{
    return new NxJointLimitSoftDesc();
}

API_EXPORT void NxJointLimitSoftDesc_setToDefault(NxJointLimitSoftDesc* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxJointLimitSoftDesc::setToDefault() : classPointer->setToDefault();
}

API_EXPORT bool NxJointLimitSoftDesc_isValid(NxJointLimitSoftDesc* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxJointLimitSoftDesc::isValid() : classPointer->isValid();
}

API_EXPORT void set_NxJointLimitSoftPairDesc_low(NxJointLimitSoftPairDesc* classPointer, NxJointLimitSoftDesc* newvalue)
{
    classPointer->low = *newvalue;
}

API_EXPORT NxJointLimitSoftDesc* get_NxJointLimitSoftPairDesc_low(NxJointLimitSoftPairDesc* classPointer)
{
    return &classPointer->low;
}

API_EXPORT void set_NxJointLimitSoftPairDesc_high(NxJointLimitSoftPairDesc* classPointer, NxJointLimitSoftDesc* newvalue)
{
    classPointer->high = *newvalue;
}

API_EXPORT NxJointLimitSoftDesc* get_NxJointLimitSoftPairDesc_high(NxJointLimitSoftPairDesc* classPointer)
{
    return &classPointer->high;
}

API_EXPORT NxJointLimitSoftPairDesc* new_NxJointLimitSoftPairDesc(bool do_override)
{
    return new NxJointLimitSoftPairDesc();
}

API_EXPORT void NxJointLimitSoftPairDesc_setToDefault(NxJointLimitSoftPairDesc* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxJointLimitSoftPairDesc::setToDefault() : classPointer->setToDefault();
}

API_EXPORT bool NxJointLimitSoftPairDesc_isValid(NxJointLimitSoftPairDesc* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxJointLimitSoftPairDesc::isValid() : classPointer->isValid();
}

API_EXPORT void set_NxMat33Shadow_data(NxMat33Shadow* classPointer, Mat33DataType newvalue)
{
    classPointer->data = newvalue;
}

API_EXPORT Mat33DataType get_NxMat33Shadow_data(NxMat33Shadow* classPointer)
{
    return classPointer->data;
}

API_EXPORT void set_NxMaterial_userData(NxMaterial* classPointer, void* newvalue)
{
    classPointer->userData = newvalue;
}

API_EXPORT void* get_NxMaterial_userData(NxMaterial* classPointer)
{
    return classPointer->userData;
}

API_EXPORT NxMaterial* new_NxMaterial(bool do_override)
{
    return (do_override) ? new NxMaterial_doxybind() : NULL;
}

API_EXPORT NxMaterialIndex NxMaterial_getMaterialIndex(NxMaterial* classPointer, bool call_explicit)
{
    return classPointer->getMaterialIndex();
}

API_EXPORT void NxMaterial_loadFromDesc(NxMaterial* classPointer, bool call_explicit, NxMaterialDesc* desc)
{
    classPointer->loadFromDesc(*desc);
}

API_EXPORT void NxMaterial_saveToDesc(NxMaterial* classPointer, bool call_explicit, NxMaterialDesc* desc)
{
    classPointer->saveToDesc(*desc);
}

API_EXPORT NxScene* NxMaterial_getScene(NxMaterial* classPointer, bool call_explicit)
{
    return &classPointer->getScene();
}

API_EXPORT void NxMaterial_setDynamicFriction(NxMaterial* classPointer, bool call_explicit, NxReal coef)
{
    classPointer->setDynamicFriction(coef);
}

API_EXPORT NxReal NxMaterial_getDynamicFriction(NxMaterial* classPointer, bool call_explicit)
{
    return classPointer->getDynamicFriction();
}

API_EXPORT void NxMaterial_setStaticFriction(NxMaterial* classPointer, bool call_explicit, NxReal coef)
{
    classPointer->setStaticFriction(coef);
}

API_EXPORT NxReal NxMaterial_getStaticFriction(NxMaterial* classPointer, bool call_explicit)
{
    return classPointer->getStaticFriction();
}

API_EXPORT void NxMaterial_setRestitution(NxMaterial* classPointer, bool call_explicit, NxReal rest)
{
    classPointer->setRestitution(rest);
}

API_EXPORT NxReal NxMaterial_getRestitution(NxMaterial* classPointer, bool call_explicit)
{
    return classPointer->getRestitution();
}

API_EXPORT void NxMaterial_setDynamicFrictionV(NxMaterial* classPointer, bool call_explicit, NxReal coef)
{
    classPointer->setDynamicFrictionV(coef);
}

API_EXPORT NxReal NxMaterial_getDynamicFrictionV(NxMaterial* classPointer, bool call_explicit)
{
    return classPointer->getDynamicFrictionV();
}

API_EXPORT void NxMaterial_setStaticFrictionV(NxMaterial* classPointer, bool call_explicit, NxReal coef)
{
    classPointer->setStaticFrictionV(coef);
}

API_EXPORT NxReal NxMaterial_getStaticFrictionV(NxMaterial* classPointer, bool call_explicit)
{
    return classPointer->getStaticFrictionV();
}

API_EXPORT void NxMaterial_setDirOfAnisotropy(NxMaterial* classPointer, bool call_explicit, NxVec3& vec)
{
    classPointer->setDirOfAnisotropy(vec);
}

API_EXPORT NxVec3 NxMaterial_getDirOfAnisotropy(NxMaterial* classPointer, bool call_explicit)
{
    return classPointer->getDirOfAnisotropy();
}

API_EXPORT void NxMaterial_setFlags(NxMaterial* classPointer, bool call_explicit, NxU32 flags)
{
    classPointer->setFlags(flags);
}

API_EXPORT NxU32 NxMaterial_getFlags(NxMaterial* classPointer, bool call_explicit)
{
    return classPointer->getFlags();
}

API_EXPORT void NxMaterial_setFrictionCombineMode(NxMaterial* classPointer, bool call_explicit, NxCombineMode combMode)
{
    classPointer->setFrictionCombineMode(combMode);
}

API_EXPORT NxCombineMode NxMaterial_getFrictionCombineMode(NxMaterial* classPointer, bool call_explicit)
{
    return classPointer->getFrictionCombineMode();
}

API_EXPORT void NxMaterial_setRestitutionCombineMode(NxMaterial* classPointer, bool call_explicit, NxCombineMode combMode)
{
    classPointer->setRestitutionCombineMode(combMode);
}

API_EXPORT NxCombineMode NxMaterial_getRestitutionCombineMode(NxMaterial* classPointer, bool call_explicit)
{
    return classPointer->getRestitutionCombineMode();
}

API_EXPORT void set_NxMaterialDesc_dynamicFriction(NxMaterialDesc* classPointer, NxReal newvalue)
{
    classPointer->dynamicFriction = newvalue;
}

API_EXPORT NxReal get_NxMaterialDesc_dynamicFriction(NxMaterialDesc* classPointer)
{
    return classPointer->dynamicFriction;
}

API_EXPORT void set_NxMaterialDesc_staticFriction(NxMaterialDesc* classPointer, NxReal newvalue)
{
    classPointer->staticFriction = newvalue;
}

API_EXPORT NxReal get_NxMaterialDesc_staticFriction(NxMaterialDesc* classPointer)
{
    return classPointer->staticFriction;
}

API_EXPORT void set_NxMaterialDesc_restitution(NxMaterialDesc* classPointer, NxReal newvalue)
{
    classPointer->restitution = newvalue;
}

API_EXPORT NxReal get_NxMaterialDesc_restitution(NxMaterialDesc* classPointer)
{
    return classPointer->restitution;
}

API_EXPORT void set_NxMaterialDesc_dynamicFrictionV(NxMaterialDesc* classPointer, NxReal newvalue)
{
    classPointer->dynamicFrictionV = newvalue;
}

API_EXPORT NxReal get_NxMaterialDesc_dynamicFrictionV(NxMaterialDesc* classPointer)
{
    return classPointer->dynamicFrictionV;
}

API_EXPORT void set_NxMaterialDesc_staticFrictionV(NxMaterialDesc* classPointer, NxReal newvalue)
{
    classPointer->staticFrictionV = newvalue;
}

API_EXPORT NxReal get_NxMaterialDesc_staticFrictionV(NxMaterialDesc* classPointer)
{
    return classPointer->staticFrictionV;
}

API_EXPORT void set_NxMaterialDesc_dirOfAnisotropy(NxMaterialDesc* classPointer, NxVec3 newvalue)
{
    classPointer->dirOfAnisotropy = newvalue;
}

API_EXPORT NxVec3 get_NxMaterialDesc_dirOfAnisotropy(NxMaterialDesc* classPointer)
{
    return classPointer->dirOfAnisotropy;
}

API_EXPORT void set_NxMaterialDesc_flags(NxMaterialDesc* classPointer, NxU32 newvalue)
{
    classPointer->flags = newvalue;
}

API_EXPORT NxU32 get_NxMaterialDesc_flags(NxMaterialDesc* classPointer)
{
    return classPointer->flags;
}

API_EXPORT void set_NxMaterialDesc_frictionCombineMode(NxMaterialDesc* classPointer, NxCombineMode newvalue)
{
    classPointer->frictionCombineMode = newvalue;
}

API_EXPORT NxCombineMode get_NxMaterialDesc_frictionCombineMode(NxMaterialDesc* classPointer)
{
    return classPointer->frictionCombineMode;
}

API_EXPORT void set_NxMaterialDesc_restitutionCombineMode(NxMaterialDesc* classPointer, NxCombineMode newvalue)
{
    classPointer->restitutionCombineMode = newvalue;
}

API_EXPORT NxCombineMode get_NxMaterialDesc_restitutionCombineMode(NxMaterialDesc* classPointer)
{
    return classPointer->restitutionCombineMode;
}

API_EXPORT void set_NxMaterialDesc_spring(NxMaterialDesc* classPointer, NxSpringDesc* newvalue)
{
    classPointer->spring = newvalue;
}

API_EXPORT NxSpringDesc* get_NxMaterialDesc_spring(NxMaterialDesc* classPointer)
{
    return classPointer->spring;
}

API_EXPORT NxMaterialDesc* new_NxMaterialDesc(bool do_override)
{
    return new NxMaterialDesc();
}

API_EXPORT void NxMaterialDesc_setToDefault(NxMaterialDesc* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxMaterialDesc::setToDefault() : classPointer->setToDefault();
}

API_EXPORT bool NxMaterialDesc_isValid(NxMaterialDesc* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxMaterialDesc::isValid() : classPointer->isValid();
}

API_EXPORT bool NxMath_equals(NxMath* classPointer, bool call_explicit, NxF32 unknown26, NxF32 unknown27, NxF32 eps)
{
    return (call_explicit) ? classPointer->NxMath::equals(unknown26, unknown27, eps) : classPointer->equals(unknown26, unknown27, eps);
}

API_EXPORT bool NxMath_equals_1(NxMath* classPointer, bool call_explicit, NxF64 unknown28, NxF64 unknown29, NxF64 eps)
{
    return (call_explicit) ? classPointer->NxMath::equals(unknown28, unknown29, eps) : classPointer->equals(unknown28, unknown29, eps);
}

API_EXPORT NxF32 NxMath_floor(NxMath* classPointer, bool call_explicit, NxF32 unknown30)
{
    return (call_explicit) ? classPointer->NxMath::floor(unknown30) : classPointer->floor(unknown30);
}

API_EXPORT NxF64 NxMath_floor_1(NxMath* classPointer, bool call_explicit, NxF64 unknown31)
{
    return (call_explicit) ? classPointer->NxMath::floor(unknown31) : classPointer->floor(unknown31);
}

API_EXPORT NxF32 NxMath_ceil(NxMath* classPointer, bool call_explicit, NxF32 unknown32)
{
    return (call_explicit) ? classPointer->NxMath::ceil(unknown32) : classPointer->ceil(unknown32);
}

API_EXPORT NxF64 NxMath_ceil_1(NxMath* classPointer, bool call_explicit, NxF64 unknown33)
{
    return (call_explicit) ? classPointer->NxMath::ceil(unknown33) : classPointer->ceil(unknown33);
}

API_EXPORT NxI32 NxMath_trunc(NxMath* classPointer, bool call_explicit, NxF32 unknown34)
{
    return (call_explicit) ? classPointer->NxMath::trunc(unknown34) : classPointer->trunc(unknown34);
}

API_EXPORT NxI32 NxMath_trunc_1(NxMath* classPointer, bool call_explicit, NxF64 unknown35)
{
    return (call_explicit) ? classPointer->NxMath::trunc(unknown35) : classPointer->trunc(unknown35);
}

API_EXPORT NxF32 NxMath_abs(NxMath* classPointer, bool call_explicit, NxF32 unknown36)
{
    return (call_explicit) ? classPointer->NxMath::abs(unknown36) : classPointer->abs(unknown36);
}

API_EXPORT NxF64 NxMath_abs_1(NxMath* classPointer, bool call_explicit, NxF64 unknown37)
{
    return (call_explicit) ? classPointer->NxMath::abs(unknown37) : classPointer->abs(unknown37);
}

API_EXPORT NxI32 NxMath_abs_2(NxMath* classPointer, bool call_explicit, NxI32 unknown38)
{
    return (call_explicit) ? classPointer->NxMath::abs(unknown38) : classPointer->abs(unknown38);
}

API_EXPORT NxF32 NxMath_sign(NxMath* classPointer, bool call_explicit, NxF32 unknown39)
{
    return (call_explicit) ? classPointer->NxMath::sign(unknown39) : classPointer->sign(unknown39);
}

API_EXPORT NxF64 NxMath_sign_1(NxMath* classPointer, bool call_explicit, NxF64 unknown40)
{
    return (call_explicit) ? classPointer->NxMath::sign(unknown40) : classPointer->sign(unknown40);
}

API_EXPORT NxI32 NxMath_sign_2(NxMath* classPointer, bool call_explicit, NxI32 unknown41)
{
    return (call_explicit) ? classPointer->NxMath::sign(unknown41) : classPointer->sign(unknown41);
}

API_EXPORT NxF32 NxMath_max(NxMath* classPointer, bool call_explicit, NxF32 unknown42, NxF32 unknown43)
{
    return (call_explicit) ? classPointer->NxMath::max(unknown42, unknown43) : classPointer->max(unknown42, unknown43);
}

API_EXPORT NxF64 NxMath_max_1(NxMath* classPointer, bool call_explicit, NxF64 unknown44, NxF64 unknown45)
{
    return (call_explicit) ? classPointer->NxMath::max(unknown44, unknown45) : classPointer->max(unknown44, unknown45);
}

API_EXPORT NxI32 NxMath_max_2(NxMath* classPointer, bool call_explicit, NxI32 unknown46, NxI32 unknown47)
{
    return (call_explicit) ? classPointer->NxMath::max(unknown46, unknown47) : classPointer->max(unknown46, unknown47);
}

API_EXPORT NxU32 NxMath_max_3(NxMath* classPointer, bool call_explicit, NxU32 unknown48, NxU32 unknown49)
{
    return (call_explicit) ? classPointer->NxMath::max(unknown48, unknown49) : classPointer->max(unknown48, unknown49);
}

API_EXPORT NxU16 NxMath_max_4(NxMath* classPointer, bool call_explicit, NxU16 unknown50, NxU16 unknown51)
{
    return (call_explicit) ? classPointer->NxMath::max(unknown50, unknown51) : classPointer->max(unknown50, unknown51);
}

API_EXPORT NxF32 NxMath_min(NxMath* classPointer, bool call_explicit, NxF32 unknown52, NxF32 unknown53)
{
    return (call_explicit) ? classPointer->NxMath::min(unknown52, unknown53) : classPointer->min(unknown52, unknown53);
}

API_EXPORT NxF64 NxMath_min_1(NxMath* classPointer, bool call_explicit, NxF64 unknown54, NxF64 unknown55)
{
    return (call_explicit) ? classPointer->NxMath::min(unknown54, unknown55) : classPointer->min(unknown54, unknown55);
}

API_EXPORT NxI32 NxMath_min_2(NxMath* classPointer, bool call_explicit, NxI32 unknown56, NxI32 unknown57)
{
    return (call_explicit) ? classPointer->NxMath::min(unknown56, unknown57) : classPointer->min(unknown56, unknown57);
}

API_EXPORT NxU32 NxMath_min_3(NxMath* classPointer, bool call_explicit, NxU32 unknown58, NxU32 unknown59)
{
    return (call_explicit) ? classPointer->NxMath::min(unknown58, unknown59) : classPointer->min(unknown58, unknown59);
}

API_EXPORT NxU16 NxMath_min_4(NxMath* classPointer, bool call_explicit, NxU16 unknown60, NxU16 unknown61)
{
    return (call_explicit) ? classPointer->NxMath::min(unknown60, unknown61) : classPointer->min(unknown60, unknown61);
}

API_EXPORT NxF32 NxMath_mod(NxMath* classPointer, bool call_explicit, NxF32 x, NxF32 y)
{
    return (call_explicit) ? classPointer->NxMath::mod(x, y) : classPointer->mod(x, y);
}

API_EXPORT NxF64 NxMath_mod_1(NxMath* classPointer, bool call_explicit, NxF64 x, NxF64 y)
{
    return (call_explicit) ? classPointer->NxMath::mod(x, y) : classPointer->mod(x, y);
}

API_EXPORT NxF32 NxMath_clamp(NxMath* classPointer, bool call_explicit, NxF32 v, NxF32 hi, NxF32 low)
{
    return (call_explicit) ? classPointer->NxMath::clamp(v, hi, low) : classPointer->clamp(v, hi, low);
}

API_EXPORT NxF64 NxMath_clamp_1(NxMath* classPointer, bool call_explicit, NxF64 v, NxF64 hi, NxF64 low)
{
    return (call_explicit) ? classPointer->NxMath::clamp(v, hi, low) : classPointer->clamp(v, hi, low);
}

API_EXPORT NxU32 NxMath_clamp_2(NxMath* classPointer, bool call_explicit, NxU32 v, NxU32 hi, NxU32 low)
{
    return (call_explicit) ? classPointer->NxMath::clamp(v, hi, low) : classPointer->clamp(v, hi, low);
}

API_EXPORT NxI32 NxMath_clamp_3(NxMath* classPointer, bool call_explicit, NxI32 v, NxI32 hi, NxI32 low)
{
    return (call_explicit) ? classPointer->NxMath::clamp(v, hi, low) : classPointer->clamp(v, hi, low);
}

API_EXPORT NxF32 NxMath_sqrt(NxMath* classPointer, bool call_explicit, NxF32 unknown62)
{
    return (call_explicit) ? classPointer->NxMath::sqrt(unknown62) : classPointer->sqrt(unknown62);
}

API_EXPORT NxF64 NxMath_sqrt_1(NxMath* classPointer, bool call_explicit, NxF64 unknown63)
{
    return (call_explicit) ? classPointer->NxMath::sqrt(unknown63) : classPointer->sqrt(unknown63);
}

API_EXPORT NxF32 NxMath_recipSqrt(NxMath* classPointer, bool call_explicit, NxF32 unknown64)
{
    return (call_explicit) ? classPointer->NxMath::recipSqrt(unknown64) : classPointer->recipSqrt(unknown64);
}

API_EXPORT NxF64 NxMath_recipSqrt_1(NxMath* classPointer, bool call_explicit, NxF64 unknown65)
{
    return (call_explicit) ? classPointer->NxMath::recipSqrt(unknown65) : classPointer->recipSqrt(unknown65);
}

API_EXPORT NxF32 NxMath_pow(NxMath* classPointer, bool call_explicit, NxF32 x, NxF32 y)
{
    return (call_explicit) ? classPointer->NxMath::pow(x, y) : classPointer->pow(x, y);
}

API_EXPORT NxF64 NxMath_pow_1(NxMath* classPointer, bool call_explicit, NxF64 x, NxF64 y)
{
    return (call_explicit) ? classPointer->NxMath::pow(x, y) : classPointer->pow(x, y);
}

API_EXPORT NxF32 NxMath_exp(NxMath* classPointer, bool call_explicit, NxF32 unknown66)
{
    return (call_explicit) ? classPointer->NxMath::exp(unknown66) : classPointer->exp(unknown66);
}

API_EXPORT NxF64 NxMath_exp_1(NxMath* classPointer, bool call_explicit, NxF64 unknown67)
{
    return (call_explicit) ? classPointer->NxMath::exp(unknown67) : classPointer->exp(unknown67);
}

API_EXPORT NxF32 NxMath_logE(NxMath* classPointer, bool call_explicit, NxF32 unknown68)
{
    return (call_explicit) ? classPointer->NxMath::logE(unknown68) : classPointer->logE(unknown68);
}

API_EXPORT NxF64 NxMath_logE_1(NxMath* classPointer, bool call_explicit, NxF64 unknown69)
{
    return (call_explicit) ? classPointer->NxMath::logE(unknown69) : classPointer->logE(unknown69);
}

API_EXPORT NxF32 NxMath_log2(NxMath* classPointer, bool call_explicit, NxF32 unknown70)
{
    return (call_explicit) ? classPointer->NxMath::log2(unknown70) : classPointer->log2(unknown70);
}

API_EXPORT NxF64 NxMath_log2_1(NxMath* classPointer, bool call_explicit, NxF64 unknown71)
{
    return (call_explicit) ? classPointer->NxMath::log2(unknown71) : classPointer->log2(unknown71);
}

API_EXPORT NxF32 NxMath_log10(NxMath* classPointer, bool call_explicit, NxF32 unknown72)
{
    return (call_explicit) ? classPointer->NxMath::log10(unknown72) : classPointer->log10(unknown72);
}

API_EXPORT NxF64 NxMath_log10_1(NxMath* classPointer, bool call_explicit, NxF64 unknown73)
{
    return (call_explicit) ? classPointer->NxMath::log10(unknown73) : classPointer->log10(unknown73);
}

API_EXPORT NxF32 NxMath_degToRad(NxMath* classPointer, bool call_explicit, NxF32 unknown74)
{
    return (call_explicit) ? classPointer->NxMath::degToRad(unknown74) : classPointer->degToRad(unknown74);
}

API_EXPORT NxF64 NxMath_degToRad_1(NxMath* classPointer, bool call_explicit, NxF64 unknown75)
{
    return (call_explicit) ? classPointer->NxMath::degToRad(unknown75) : classPointer->degToRad(unknown75);
}

API_EXPORT NxF32 NxMath_radToDeg(NxMath* classPointer, bool call_explicit, NxF32 unknown76)
{
    return (call_explicit) ? classPointer->NxMath::radToDeg(unknown76) : classPointer->radToDeg(unknown76);
}

API_EXPORT NxF64 NxMath_radToDeg_1(NxMath* classPointer, bool call_explicit, NxF64 unknown77)
{
    return (call_explicit) ? classPointer->NxMath::radToDeg(unknown77) : classPointer->radToDeg(unknown77);
}

API_EXPORT NxF32 NxMath_sin(NxMath* classPointer, bool call_explicit, NxF32 unknown78)
{
    return (call_explicit) ? classPointer->NxMath::sin(unknown78) : classPointer->sin(unknown78);
}

API_EXPORT NxF64 NxMath_sin_1(NxMath* classPointer, bool call_explicit, NxF64 unknown79)
{
    return (call_explicit) ? classPointer->NxMath::sin(unknown79) : classPointer->sin(unknown79);
}

API_EXPORT NxF32 NxMath_cos(NxMath* classPointer, bool call_explicit, NxF32 unknown80)
{
    return (call_explicit) ? classPointer->NxMath::cos(unknown80) : classPointer->cos(unknown80);
}

API_EXPORT NxF64 NxMath_cos_1(NxMath* classPointer, bool call_explicit, NxF64 unknown81)
{
    return (call_explicit) ? classPointer->NxMath::cos(unknown81) : classPointer->cos(unknown81);
}

API_EXPORT void NxMath_sinCos(NxMath* classPointer, bool call_explicit, NxF32 unknown82, NxF32& sin, NxF32& cos)
{
    (call_explicit) ? classPointer->NxMath::sinCos(unknown82, sin, cos) : classPointer->sinCos(unknown82, sin, cos);
}

API_EXPORT void NxMath_sinCos_1(NxMath* classPointer, bool call_explicit, NxF64 unknown83, NxF64& sin, NxF64& cos)
{
    (call_explicit) ? classPointer->NxMath::sinCos(unknown83, sin, cos) : classPointer->sinCos(unknown83, sin, cos);
}

API_EXPORT NxF32 NxMath_tan(NxMath* classPointer, bool call_explicit, NxF32 unknown84)
{
    return (call_explicit) ? classPointer->NxMath::tan(unknown84) : classPointer->tan(unknown84);
}

API_EXPORT NxF64 NxMath_tan_1(NxMath* classPointer, bool call_explicit, NxF64 unknown85)
{
    return (call_explicit) ? classPointer->NxMath::tan(unknown85) : classPointer->tan(unknown85);
}

API_EXPORT NxF32 NxMath_asin(NxMath* classPointer, bool call_explicit, NxF32 unknown86)
{
    return (call_explicit) ? classPointer->NxMath::asin(unknown86) : classPointer->asin(unknown86);
}

API_EXPORT NxF64 NxMath_asin_1(NxMath* classPointer, bool call_explicit, NxF64 unknown87)
{
    return (call_explicit) ? classPointer->NxMath::asin(unknown87) : classPointer->asin(unknown87);
}

API_EXPORT NxF32 NxMath_acos(NxMath* classPointer, bool call_explicit, NxF32 unknown88)
{
    return (call_explicit) ? classPointer->NxMath::acos(unknown88) : classPointer->acos(unknown88);
}

API_EXPORT NxF64 NxMath_acos_1(NxMath* classPointer, bool call_explicit, NxF64 unknown89)
{
    return (call_explicit) ? classPointer->NxMath::acos(unknown89) : classPointer->acos(unknown89);
}

API_EXPORT NxF32 NxMath_atan(NxMath* classPointer, bool call_explicit, NxF32 unknown90)
{
    return (call_explicit) ? classPointer->NxMath::atan(unknown90) : classPointer->atan(unknown90);
}

API_EXPORT NxF64 NxMath_atan_1(NxMath* classPointer, bool call_explicit, NxF64 unknown91)
{
    return (call_explicit) ? classPointer->NxMath::atan(unknown91) : classPointer->atan(unknown91);
}

API_EXPORT NxF32 NxMath_atan2(NxMath* classPointer, bool call_explicit, NxF32 x, NxF32 y)
{
    return (call_explicit) ? classPointer->NxMath::atan2(x, y) : classPointer->atan2(x, y);
}

API_EXPORT NxF64 NxMath_atan2_1(NxMath* classPointer, bool call_explicit, NxF64 x, NxF64 y)
{
    return (call_explicit) ? classPointer->NxMath::atan2(x, y) : classPointer->atan2(x, y);
}

API_EXPORT NxF32 NxMath_rand(NxMath* classPointer, bool call_explicit, NxF32 a, NxF32 b)
{
    return (call_explicit) ? classPointer->NxMath::rand(a, b) : classPointer->rand(a, b);
}

API_EXPORT NxI32 NxMath_rand_1(NxMath* classPointer, bool call_explicit, NxI32 a, NxI32 b)
{
    return (call_explicit) ? classPointer->NxMath::rand(a, b) : classPointer->rand(a, b);
}

API_EXPORT NxU32 NxMath_hash(NxMath* classPointer, bool call_explicit, NxU32* array, NxU32 n)
{
    return (call_explicit) ? classPointer->NxMath::hash(array, n) : classPointer->hash(array, n);
}

API_EXPORT int NxMath_hash32(NxMath* classPointer, bool call_explicit, int unknown92)
{
    return (call_explicit) ? classPointer->NxMath::hash32(unknown92) : classPointer->hash32(unknown92);
}

API_EXPORT bool NxMath_isFinite(NxMath* classPointer, bool call_explicit, NxF32 x)
{
    return (call_explicit) ? classPointer->NxMath::isFinite(x) : classPointer->isFinite(x);
}

API_EXPORT bool NxMath_isFinite_1(NxMath* classPointer, bool call_explicit, NxF64 x)
{
    return (call_explicit) ? classPointer->NxMath::isFinite(x) : classPointer->isFinite(x);
}

API_EXPORT void set_NxMeshData_verticesPosBegin(NxMeshData* classPointer, void* newvalue)
{
    classPointer->verticesPosBegin = newvalue;
}

API_EXPORT void* get_NxMeshData_verticesPosBegin(NxMeshData* classPointer)
{
    return classPointer->verticesPosBegin;
}

API_EXPORT void set_NxMeshData_verticesNormalBegin(NxMeshData* classPointer, void* newvalue)
{
    classPointer->verticesNormalBegin = newvalue;
}

API_EXPORT void* get_NxMeshData_verticesNormalBegin(NxMeshData* classPointer)
{
    return classPointer->verticesNormalBegin;
}

API_EXPORT void set_NxMeshData_verticesPosByteStride(NxMeshData* classPointer, NxI32 newvalue)
{
    classPointer->verticesPosByteStride = newvalue;
}

API_EXPORT NxI32 get_NxMeshData_verticesPosByteStride(NxMeshData* classPointer)
{
    return classPointer->verticesPosByteStride;
}

API_EXPORT void set_NxMeshData_verticesNormalByteStride(NxMeshData* classPointer, NxI32 newvalue)
{
    classPointer->verticesNormalByteStride = newvalue;
}

API_EXPORT NxI32 get_NxMeshData_verticesNormalByteStride(NxMeshData* classPointer)
{
    return classPointer->verticesNormalByteStride;
}

API_EXPORT void set_NxMeshData_maxVertices(NxMeshData* classPointer, NxU32 newvalue)
{
    classPointer->maxVertices = newvalue;
}

API_EXPORT NxU32 get_NxMeshData_maxVertices(NxMeshData* classPointer)
{
    return classPointer->maxVertices;
}

API_EXPORT void set_NxMeshData_numVerticesPtr(NxMeshData* classPointer, NxU32* newvalue)
{
    classPointer->numVerticesPtr = newvalue;
}

API_EXPORT NxU32* get_NxMeshData_numVerticesPtr(NxMeshData* classPointer)
{
    return classPointer->numVerticesPtr;
}

API_EXPORT void set_NxMeshData_indicesBegin(NxMeshData* classPointer, void* newvalue)
{
    classPointer->indicesBegin = newvalue;
}

API_EXPORT void* get_NxMeshData_indicesBegin(NxMeshData* classPointer)
{
    return classPointer->indicesBegin;
}

API_EXPORT void set_NxMeshData_indicesByteStride(NxMeshData* classPointer, NxI32 newvalue)
{
    classPointer->indicesByteStride = newvalue;
}

API_EXPORT NxI32 get_NxMeshData_indicesByteStride(NxMeshData* classPointer)
{
    return classPointer->indicesByteStride;
}

API_EXPORT void set_NxMeshData_maxIndices(NxMeshData* classPointer, NxU32 newvalue)
{
    classPointer->maxIndices = newvalue;
}

API_EXPORT NxU32 get_NxMeshData_maxIndices(NxMeshData* classPointer)
{
    return classPointer->maxIndices;
}

API_EXPORT void set_NxMeshData_numIndicesPtr(NxMeshData* classPointer, NxU32* newvalue)
{
    classPointer->numIndicesPtr = newvalue;
}

API_EXPORT NxU32* get_NxMeshData_numIndicesPtr(NxMeshData* classPointer)
{
    return classPointer->numIndicesPtr;
}

API_EXPORT void set_NxMeshData_parentIndicesBegin(NxMeshData* classPointer, void* newvalue)
{
    classPointer->parentIndicesBegin = newvalue;
}

API_EXPORT void* get_NxMeshData_parentIndicesBegin(NxMeshData* classPointer)
{
    return classPointer->parentIndicesBegin;
}

API_EXPORT void set_NxMeshData_parentIndicesByteStride(NxMeshData* classPointer, NxI32 newvalue)
{
    classPointer->parentIndicesByteStride = newvalue;
}

API_EXPORT NxI32 get_NxMeshData_parentIndicesByteStride(NxMeshData* classPointer)
{
    return classPointer->parentIndicesByteStride;
}

API_EXPORT void set_NxMeshData_maxParentIndices(NxMeshData* classPointer, NxU32 newvalue)
{
    classPointer->maxParentIndices = newvalue;
}

API_EXPORT NxU32 get_NxMeshData_maxParentIndices(NxMeshData* classPointer)
{
    return classPointer->maxParentIndices;
}

API_EXPORT void set_NxMeshData_numParentIndicesPtr(NxMeshData* classPointer, NxU32* newvalue)
{
    classPointer->numParentIndicesPtr = newvalue;
}

API_EXPORT NxU32* get_NxMeshData_numParentIndicesPtr(NxMeshData* classPointer)
{
    return classPointer->numParentIndicesPtr;
}

API_EXPORT void set_NxMeshData_dirtyBufferFlagsPtr(NxMeshData* classPointer, NxU32* newvalue)
{
    classPointer->dirtyBufferFlagsPtr = newvalue;
}

API_EXPORT NxU32* get_NxMeshData_dirtyBufferFlagsPtr(NxMeshData* classPointer)
{
    return classPointer->dirtyBufferFlagsPtr;
}

API_EXPORT void set_NxMeshData_flags(NxMeshData* classPointer, NxU32 newvalue)
{
    classPointer->flags = newvalue;
}

API_EXPORT NxU32 get_NxMeshData_flags(NxMeshData* classPointer)
{
    return classPointer->flags;
}

API_EXPORT void set_NxMeshData_name(NxMeshData* classPointer, const char* newvalue)
{
    classPointer->name = newvalue;
}

API_EXPORT const char* get_NxMeshData_name(NxMeshData* classPointer)
{
    return classPointer->name;
}

API_EXPORT void NxMeshData_setToDefault(NxMeshData* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxMeshData::setToDefault() : classPointer->setToDefault();
}

API_EXPORT bool NxMeshData_isValid(NxMeshData* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxMeshData::isValid() : classPointer->isValid();
}

API_EXPORT NxMeshData* new_NxMeshData(bool do_override)
{
    return new NxMeshData();
}

API_EXPORT void set_NxMotorDesc_velTarget(NxMotorDesc* classPointer, NxReal newvalue)
{
    classPointer->velTarget = newvalue;
}

API_EXPORT NxReal get_NxMotorDesc_velTarget(NxMotorDesc* classPointer)
{
    return classPointer->velTarget;
}

API_EXPORT void set_NxMotorDesc_maxForce(NxMotorDesc* classPointer, NxReal newvalue)
{
    classPointer->maxForce = newvalue;
}

API_EXPORT NxReal get_NxMotorDesc_maxForce(NxMotorDesc* classPointer)
{
    return classPointer->maxForce;
}

API_EXPORT void set_NxMotorDesc_freeSpin(NxMotorDesc* classPointer, NX_BOOL newvalue)
{
    classPointer->freeSpin = newvalue;
}

API_EXPORT NX_BOOL get_NxMotorDesc_freeSpin(NxMotorDesc* classPointer)
{
    return classPointer->freeSpin;
}

API_EXPORT NxMotorDesc* new_NxMotorDesc(bool do_override)
{
    return new NxMotorDesc();
}

API_EXPORT NxMotorDesc* new_NxMotorDesc_1(bool do_override, NxReal velTarget, NxReal maxForce, NX_BOOL freeSpin)
{
    return new NxMotorDesc(velTarget, maxForce, freeSpin);
}

API_EXPORT NxMotorDesc* new_NxMotorDesc_2(bool do_override, NxReal velTarget, NxReal maxForce)
{
    return new NxMotorDesc(velTarget, maxForce);
}

API_EXPORT NxMotorDesc* new_NxMotorDesc_3(bool do_override, NxReal velTarget)
{
    return new NxMotorDesc(velTarget);
}

API_EXPORT void NxMotorDesc_setToDefault(NxMotorDesc* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxMotorDesc::setToDefault() : classPointer->setToDefault();
}

API_EXPORT bool NxMotorDesc_isValid(NxMotorDesc* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxMotorDesc::isValid() : classPointer->isValid();
}

API_EXPORT void set_NxPairFlag_objects(NxPairFlag* classPointer, void* newvalue[2])
{
    memcpy(&classPointer->objects[0], &newvalue[0], sizeof(void*) * 2);
}

API_EXPORT void get_NxPairFlag_objects(NxPairFlag* classPointer, void* newvalue[2])
{
    memcpy(&newvalue[0], &classPointer->objects[0], sizeof(void*) * 2);
}

API_EXPORT void set_NxPairFlag_flags(NxPairFlag* classPointer, NxU32 newvalue)
{
    classPointer->flags = newvalue;
}

API_EXPORT NxU32 get_NxPairFlag_flags(NxPairFlag* classPointer)
{
    return classPointer->flags;
}

API_EXPORT NxU32 NxPairFlag_isActorPair(NxPairFlag* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxPairFlag::isActorPair() : classPointer->isActorPair();
}

API_EXPORT void set_NxParticleData_numParticlesPtr(NxParticleData* classPointer, NxU32* newvalue)
{
    classPointer->numParticlesPtr = newvalue;
}

API_EXPORT NxU32* get_NxParticleData_numParticlesPtr(NxParticleData* classPointer)
{
    return classPointer->numParticlesPtr;
}

API_EXPORT void set_NxParticleData_bufferPos(NxParticleData* classPointer, NxF32* newvalue)
{
    classPointer->bufferPos = newvalue;
}

API_EXPORT NxF32* get_NxParticleData_bufferPos(NxParticleData* classPointer)
{
    return classPointer->bufferPos;
}

API_EXPORT void set_NxParticleData_bufferVel(NxParticleData* classPointer, NxF32* newvalue)
{
    classPointer->bufferVel = newvalue;
}

API_EXPORT NxF32* get_NxParticleData_bufferVel(NxParticleData* classPointer)
{
    return classPointer->bufferVel;
}

API_EXPORT void set_NxParticleData_bufferLife(NxParticleData* classPointer, NxF32* newvalue)
{
    classPointer->bufferLife = newvalue;
}

API_EXPORT NxF32* get_NxParticleData_bufferLife(NxParticleData* classPointer)
{
    return classPointer->bufferLife;
}

API_EXPORT void set_NxParticleData_bufferDensity(NxParticleData* classPointer, NxF32* newvalue)
{
    classPointer->bufferDensity = newvalue;
}

API_EXPORT NxF32* get_NxParticleData_bufferDensity(NxParticleData* classPointer)
{
    return classPointer->bufferDensity;
}

API_EXPORT void set_NxParticleData_bufferId(NxParticleData* classPointer, NxU32* newvalue)
{
    classPointer->bufferId = newvalue;
}

API_EXPORT NxU32* get_NxParticleData_bufferId(NxParticleData* classPointer)
{
    return classPointer->bufferId;
}

API_EXPORT void set_NxParticleData_bufferFlag(NxParticleData* classPointer, NxU32* newvalue)
{
    classPointer->bufferFlag = newvalue;
}

API_EXPORT NxU32* get_NxParticleData_bufferFlag(NxParticleData* classPointer)
{
    return classPointer->bufferFlag;
}

API_EXPORT void set_NxParticleData_bufferCollisionNormal(NxParticleData* classPointer, NxF32* newvalue)
{
    classPointer->bufferCollisionNormal = newvalue;
}

API_EXPORT NxF32* get_NxParticleData_bufferCollisionNormal(NxParticleData* classPointer)
{
    return classPointer->bufferCollisionNormal;
}

API_EXPORT void set_NxParticleData_bufferPosByteStride(NxParticleData* classPointer, NxU32 newvalue)
{
    classPointer->bufferPosByteStride = newvalue;
}

API_EXPORT NxU32 get_NxParticleData_bufferPosByteStride(NxParticleData* classPointer)
{
    return classPointer->bufferPosByteStride;
}

API_EXPORT void set_NxParticleData_bufferVelByteStride(NxParticleData* classPointer, NxU32 newvalue)
{
    classPointer->bufferVelByteStride = newvalue;
}

API_EXPORT NxU32 get_NxParticleData_bufferVelByteStride(NxParticleData* classPointer)
{
    return classPointer->bufferVelByteStride;
}

API_EXPORT void set_NxParticleData_bufferLifeByteStride(NxParticleData* classPointer, NxU32 newvalue)
{
    classPointer->bufferLifeByteStride = newvalue;
}

API_EXPORT NxU32 get_NxParticleData_bufferLifeByteStride(NxParticleData* classPointer)
{
    return classPointer->bufferLifeByteStride;
}

API_EXPORT void set_NxParticleData_bufferDensityByteStride(NxParticleData* classPointer, NxU32 newvalue)
{
    classPointer->bufferDensityByteStride = newvalue;
}

API_EXPORT NxU32 get_NxParticleData_bufferDensityByteStride(NxParticleData* classPointer)
{
    return classPointer->bufferDensityByteStride;
}

API_EXPORT void set_NxParticleData_bufferIdByteStride(NxParticleData* classPointer, NxU32 newvalue)
{
    classPointer->bufferIdByteStride = newvalue;
}

API_EXPORT NxU32 get_NxParticleData_bufferIdByteStride(NxParticleData* classPointer)
{
    return classPointer->bufferIdByteStride;
}

API_EXPORT void set_NxParticleData_bufferFlagByteStride(NxParticleData* classPointer, NxU32 newvalue)
{
    classPointer->bufferFlagByteStride = newvalue;
}

API_EXPORT NxU32 get_NxParticleData_bufferFlagByteStride(NxParticleData* classPointer)
{
    return classPointer->bufferFlagByteStride;
}

API_EXPORT void set_NxParticleData_bufferCollisionNormalByteStride(NxParticleData* classPointer, NxU32 newvalue)
{
    classPointer->bufferCollisionNormalByteStride = newvalue;
}

API_EXPORT NxU32 get_NxParticleData_bufferCollisionNormalByteStride(NxParticleData* classPointer)
{
    return classPointer->bufferCollisionNormalByteStride;
}

API_EXPORT void set_NxParticleData_name(NxParticleData* classPointer, const char* newvalue)
{
    classPointer->name = newvalue;
}

API_EXPORT const char* get_NxParticleData_name(NxParticleData* classPointer)
{
    return classPointer->name;
}

API_EXPORT void NxParticleData_setToDefault(NxParticleData* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxParticleData::setToDefault() : classPointer->setToDefault();
}

API_EXPORT bool NxParticleData_isValid(NxParticleData* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxParticleData::isValid() : classPointer->isValid();
}

API_EXPORT NxParticleData* new_NxParticleData(bool do_override)
{
    return new NxParticleData();
}

API_EXPORT void set_NxParticleIdData_numIdsPtr(NxParticleIdData* classPointer, NxU32* newvalue)
{
    classPointer->numIdsPtr = newvalue;
}

API_EXPORT NxU32* get_NxParticleIdData_numIdsPtr(NxParticleIdData* classPointer)
{
    return classPointer->numIdsPtr;
}

API_EXPORT void set_NxParticleIdData_bufferId(NxParticleIdData* classPointer, NxU32* newvalue)
{
    classPointer->bufferId = newvalue;
}

API_EXPORT NxU32* get_NxParticleIdData_bufferId(NxParticleIdData* classPointer)
{
    return classPointer->bufferId;
}

API_EXPORT void set_NxParticleIdData_bufferIdByteStride(NxParticleIdData* classPointer, NxU32 newvalue)
{
    classPointer->bufferIdByteStride = newvalue;
}

API_EXPORT NxU32 get_NxParticleIdData_bufferIdByteStride(NxParticleIdData* classPointer)
{
    return classPointer->bufferIdByteStride;
}

API_EXPORT void set_NxParticleIdData_name(NxParticleIdData* classPointer, const char* newvalue)
{
    classPointer->name = newvalue;
}

API_EXPORT const char* get_NxParticleIdData_name(NxParticleIdData* classPointer)
{
    return classPointer->name;
}

API_EXPORT void NxParticleIdData_setToDefault(NxParticleIdData* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxParticleIdData::setToDefault() : classPointer->setToDefault();
}

API_EXPORT bool NxParticleIdData_isValid(NxParticleIdData* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxParticleIdData::isValid() : classPointer->isValid();
}

API_EXPORT NxParticleIdData* new_NxParticleIdData(bool do_override)
{
    return new NxParticleIdData();
}

API_EXPORT void set_NxParticleUpdateData_forceMode(NxParticleUpdateData* classPointer, NxForceMode newvalue)
{
    classPointer->forceMode = newvalue;
}

API_EXPORT NxForceMode get_NxParticleUpdateData_forceMode(NxParticleUpdateData* classPointer)
{
    return classPointer->forceMode;
}

API_EXPORT void set_NxParticleUpdateData_numUpdates(NxParticleUpdateData* classPointer, NxU32 newvalue)
{
    classPointer->numUpdates = newvalue;
}

API_EXPORT NxU32 get_NxParticleUpdateData_numUpdates(NxParticleUpdateData* classPointer)
{
    return classPointer->numUpdates;
}

API_EXPORT void set_NxParticleUpdateData_bufferForce(NxParticleUpdateData* classPointer, NxF32* newvalue)
{
    classPointer->bufferForce = newvalue;
}

API_EXPORT NxF32* get_NxParticleUpdateData_bufferForce(NxParticleUpdateData* classPointer)
{
    return classPointer->bufferForce;
}

API_EXPORT void set_NxParticleUpdateData_bufferFlag(NxParticleUpdateData* classPointer, NxU32* newvalue)
{
    classPointer->bufferFlag = newvalue;
}

API_EXPORT NxU32* get_NxParticleUpdateData_bufferFlag(NxParticleUpdateData* classPointer)
{
    return classPointer->bufferFlag;
}

API_EXPORT void set_NxParticleUpdateData_bufferId(NxParticleUpdateData* classPointer, NxU32* newvalue)
{
    classPointer->bufferId = newvalue;
}

API_EXPORT NxU32* get_NxParticleUpdateData_bufferId(NxParticleUpdateData* classPointer)
{
    return classPointer->bufferId;
}

API_EXPORT void set_NxParticleUpdateData_bufferForceByteStride(NxParticleUpdateData* classPointer, NxU32 newvalue)
{
    classPointer->bufferForceByteStride = newvalue;
}

API_EXPORT NxU32 get_NxParticleUpdateData_bufferForceByteStride(NxParticleUpdateData* classPointer)
{
    return classPointer->bufferForceByteStride;
}

API_EXPORT void set_NxParticleUpdateData_bufferFlagByteStride(NxParticleUpdateData* classPointer, NxU32 newvalue)
{
    classPointer->bufferFlagByteStride = newvalue;
}

API_EXPORT NxU32 get_NxParticleUpdateData_bufferFlagByteStride(NxParticleUpdateData* classPointer)
{
    return classPointer->bufferFlagByteStride;
}

API_EXPORT void set_NxParticleUpdateData_bufferIdByteStride(NxParticleUpdateData* classPointer, NxU32 newvalue)
{
    classPointer->bufferIdByteStride = newvalue;
}

API_EXPORT NxU32 get_NxParticleUpdateData_bufferIdByteStride(NxParticleUpdateData* classPointer)
{
    return classPointer->bufferIdByteStride;
}

API_EXPORT void NxParticleUpdateData_setToDefault(NxParticleUpdateData* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxParticleUpdateData::setToDefault() : classPointer->setToDefault();
}

API_EXPORT bool NxParticleUpdateData_isValid(NxParticleUpdateData* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxParticleUpdateData::isValid() : classPointer->isValid();
}

API_EXPORT NxParticleUpdateData* new_NxParticleUpdateData(bool do_override)
{
    return new NxParticleUpdateData();
}

API_EXPORT NxPhysicsSDK* new_NxPhysicsSDK(bool do_override)
{
    return (do_override) ? new NxPhysicsSDK_doxybind() : NULL;
}

API_EXPORT void NxPhysicsSDK_release(NxPhysicsSDK* classPointer, bool call_explicit)
{
    classPointer->release();
}

API_EXPORT bool NxPhysicsSDK_setParameter(NxPhysicsSDK* classPointer, bool call_explicit, NxParameter paramEnum, NxReal paramValue)
{
    return classPointer->setParameter(paramEnum, paramValue);
}

API_EXPORT NxReal NxPhysicsSDK_getParameter(NxPhysicsSDK* classPointer, bool call_explicit, NxParameter paramEnum)
{
    return classPointer->getParameter(paramEnum);
}

API_EXPORT NxScene* NxPhysicsSDK_createScene(NxPhysicsSDK* classPointer, bool call_explicit, NxSceneDesc* sceneDesc)
{
    return classPointer->createScene(*sceneDesc);
}

API_EXPORT void NxPhysicsSDK_releaseScene(NxPhysicsSDK* classPointer, bool call_explicit, NxScene* scene)
{
    classPointer->releaseScene(*scene);
}

API_EXPORT NxU32 NxPhysicsSDK_getNbScenes(NxPhysicsSDK* classPointer, bool call_explicit)
{
    return classPointer->getNbScenes();
}

API_EXPORT NxScene* NxPhysicsSDK_getScene(NxPhysicsSDK* classPointer, bool call_explicit, NxU32 i)
{
    return classPointer->getScene(i);
}

API_EXPORT NxTriangleMesh* NxPhysicsSDK_createTriangleMesh(NxPhysicsSDK* classPointer, bool call_explicit, NxStream* stream)
{
    return classPointer->createTriangleMesh(*stream);
}

API_EXPORT void NxPhysicsSDK_releaseTriangleMesh(NxPhysicsSDK* classPointer, bool call_explicit, NxTriangleMesh* mesh)
{
    classPointer->releaseTriangleMesh(*mesh);
}

API_EXPORT NxU32 NxPhysicsSDK_getNbTriangleMeshes(NxPhysicsSDK* classPointer, bool call_explicit)
{
    return classPointer->getNbTriangleMeshes();
}

API_EXPORT NxHeightField* NxPhysicsSDK_createHeightField(NxPhysicsSDK* classPointer, bool call_explicit, NxHeightFieldDesc* desc)
{
    return classPointer->createHeightField(*desc);
}

API_EXPORT void NxPhysicsSDK_releaseHeightField(NxPhysicsSDK* classPointer, bool call_explicit, NxHeightField* heightField)
{
    classPointer->releaseHeightField(*heightField);
}

API_EXPORT NxU32 NxPhysicsSDK_getNbHeightFields(NxPhysicsSDK* classPointer, bool call_explicit)
{
    return classPointer->getNbHeightFields();
}

API_EXPORT NxCCDSkeleton* NxPhysicsSDK_createCCDSkeleton(NxPhysicsSDK* classPointer, bool call_explicit, NxSimpleTriangleMesh* mesh)
{
    return classPointer->createCCDSkeleton(*mesh);
}

API_EXPORT NxCCDSkeleton* NxPhysicsSDK_createCCDSkeleton_1(NxPhysicsSDK* classPointer, bool call_explicit, void* memoryBuffer, NxU32 bufferSize)
{
    return classPointer->createCCDSkeleton(memoryBuffer, bufferSize);
}

API_EXPORT void NxPhysicsSDK_releaseCCDSkeleton(NxPhysicsSDK* classPointer, bool call_explicit, NxCCDSkeleton* skel)
{
    classPointer->releaseCCDSkeleton(*skel);
}

API_EXPORT NxU32 NxPhysicsSDK_getNbCCDSkeletons(NxPhysicsSDK* classPointer, bool call_explicit)
{
    return classPointer->getNbCCDSkeletons();
}

API_EXPORT NxConvexMesh* NxPhysicsSDK_createConvexMesh(NxPhysicsSDK* classPointer, bool call_explicit, NxStream* mesh)
{
    return classPointer->createConvexMesh(*mesh);
}

API_EXPORT void NxPhysicsSDK_releaseConvexMesh(NxPhysicsSDK* classPointer, bool call_explicit, NxConvexMesh* mesh)
{
    classPointer->releaseConvexMesh(*mesh);
}

API_EXPORT NxU32 NxPhysicsSDK_getNbConvexMeshes(NxPhysicsSDK* classPointer, bool call_explicit)
{
    return classPointer->getNbConvexMeshes();
}

API_EXPORT NxClothMesh* NxPhysicsSDK_createClothMesh(NxPhysicsSDK* classPointer, bool call_explicit, NxStream* stream)
{
    return classPointer->createClothMesh(*stream);
}

API_EXPORT void NxPhysicsSDK_releaseClothMesh(NxPhysicsSDK* classPointer, bool call_explicit, NxClothMesh* cloth)
{
    classPointer->releaseClothMesh(*cloth);
}

API_EXPORT NxU32 NxPhysicsSDK_getNbClothMeshes(NxPhysicsSDK* classPointer, bool call_explicit)
{
    return classPointer->getNbClothMeshes();
}

API_EXPORT NxClothMesh** NxPhysicsSDK_getClothMeshes(NxPhysicsSDK* classPointer, bool call_explicit)
{
    return classPointer->getClothMeshes();
}

API_EXPORT NxSoftBodyMesh* NxPhysicsSDK_createSoftBodyMesh(NxPhysicsSDK* classPointer, bool call_explicit, NxStream* stream)
{
    return classPointer->createSoftBodyMesh(*stream);
}

API_EXPORT void NxPhysicsSDK_releaseSoftBodyMesh(NxPhysicsSDK* classPointer, bool call_explicit, NxSoftBodyMesh* softBodyMesh)
{
    classPointer->releaseSoftBodyMesh(*softBodyMesh);
}

API_EXPORT NxU32 NxPhysicsSDK_getNbSoftBodyMeshes(NxPhysicsSDK* classPointer, bool call_explicit)
{
    return classPointer->getNbSoftBodyMeshes();
}

API_EXPORT NxSoftBodyMesh** NxPhysicsSDK_getSoftBodyMeshes(NxPhysicsSDK* classPointer, bool call_explicit)
{
    return classPointer->getSoftBodyMeshes();
}

API_EXPORT NxU32 NxPhysicsSDK_getInternalVersion(NxPhysicsSDK* classPointer, bool call_explicit, NxU32& apiRev, NxU32& descRev, NxU32& branchId)
{
    return classPointer->getInternalVersion(apiRev, descRev, branchId);
}

API_EXPORT NxInterface* NxPhysicsSDK_getInterface(NxPhysicsSDK* classPointer, bool call_explicit, NxInterfaceType type, int versionNumber)
{
    return classPointer->getInterface(type, versionNumber);
}

API_EXPORT NxHWVersion NxPhysicsSDK_getHWVersion(NxPhysicsSDK* classPointer, bool call_explicit)
{
    return classPointer->getHWVersion();
}

API_EXPORT NxU32 NxPhysicsSDK_getNbPPUs(NxPhysicsSDK* classPointer, bool call_explicit)
{
    return classPointer->getNbPPUs();
}

API_EXPORT NxFoundationSDK* NxPhysicsSDK_getFoundationSDK(NxPhysicsSDK* classPointer, bool call_explicit)
{
    return &classPointer->getFoundationSDK();
}

API_EXPORT void set_NxPhysicsSDKDesc_hwPageSize(NxPhysicsSDKDesc* classPointer, NxU32 newvalue)
{
    classPointer->hwPageSize = newvalue;
}

API_EXPORT NxU32 get_NxPhysicsSDKDesc_hwPageSize(NxPhysicsSDKDesc* classPointer)
{
    return classPointer->hwPageSize;
}

API_EXPORT void set_NxPhysicsSDKDesc_hwPageMax(NxPhysicsSDKDesc* classPointer, NxU32 newvalue)
{
    classPointer->hwPageMax = newvalue;
}

API_EXPORT NxU32 get_NxPhysicsSDKDesc_hwPageMax(NxPhysicsSDKDesc* classPointer)
{
    return classPointer->hwPageMax;
}

API_EXPORT void set_NxPhysicsSDKDesc_hwConvexMax(NxPhysicsSDKDesc* classPointer, NxU32 newvalue)
{
    classPointer->hwConvexMax = newvalue;
}

API_EXPORT NxU32 get_NxPhysicsSDKDesc_hwConvexMax(NxPhysicsSDKDesc* classPointer)
{
    return classPointer->hwConvexMax;
}

API_EXPORT void set_NxPhysicsSDKDesc_cookerThreadMask(NxPhysicsSDKDesc* classPointer, NxU32 newvalue)
{
    classPointer->cookerThreadMask = newvalue;
}

API_EXPORT NxU32 get_NxPhysicsSDKDesc_cookerThreadMask(NxPhysicsSDKDesc* classPointer)
{
    return classPointer->cookerThreadMask;
}

API_EXPORT void set_NxPhysicsSDKDesc_flags(NxPhysicsSDKDesc* classPointer, NxU32 newvalue)
{
    classPointer->flags = newvalue;
}

API_EXPORT NxU32 get_NxPhysicsSDKDesc_flags(NxPhysicsSDKDesc* classPointer)
{
    return classPointer->flags;
}

API_EXPORT void NxPhysicsSDKDesc_setToDefault(NxPhysicsSDKDesc* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxPhysicsSDKDesc::setToDefault() : classPointer->setToDefault();
}

API_EXPORT bool NxPhysicsSDKDesc_isValid(NxPhysicsSDKDesc* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxPhysicsSDKDesc::isValid() : classPointer->isValid();
}

API_EXPORT NxPhysicsSDKDesc* new_NxPhysicsSDKDesc(bool do_override)
{
    return new NxPhysicsSDKDesc();
}

API_EXPORT void set_NxPlane_normal(NxPlane* classPointer, NxVec3 newvalue)
{
    classPointer->normal = newvalue;
}

API_EXPORT NxVec3 get_NxPlane_normal(NxPlane* classPointer)
{
    return classPointer->normal;
}

API_EXPORT void set_NxPlane_d(NxPlane* classPointer, NxF32 newvalue)
{
    classPointer->d = newvalue;
}

API_EXPORT NxF32 get_NxPlane_d(NxPlane* classPointer)
{
    return classPointer->d;
}

API_EXPORT NxPlane* new_NxPlane(bool do_override)
{
    return new NxPlane();
}

API_EXPORT NxPlane* new_NxPlane_1(bool do_override, NxF32 nx, NxF32 ny, NxF32 nz, NxF32 _d)
{
    return new NxPlane(nx, ny, nz, _d);
}

API_EXPORT NxPlane* new_NxPlane_2(bool do_override, NxVec3& p, NxVec3& n)
{
    return new NxPlane(p, n);
}

API_EXPORT NxPlane* new_NxPlane_3(bool do_override, NxVec3& p0, NxVec3& p1, NxVec3& p2)
{
    return new NxPlane(p0, p1, p2);
}

API_EXPORT NxPlane* new_NxPlane_4(bool do_override, NxVec3& _n, NxF32 _d)
{
    return new NxPlane(_n, _d);
}

API_EXPORT NxPlane* new_NxPlane_5(bool do_override, NxPlane* plane)
{
    return new NxPlane(*plane);
}

API_EXPORT NxPlane* NxPlane_zero(NxPlane* classPointer, bool call_explicit)
{
    return (call_explicit) ? &classPointer->NxPlane::zero() : &classPointer->zero();
}

API_EXPORT NxPlane* NxPlane_set(NxPlane* classPointer, bool call_explicit, NxF32 nx, NxF32 ny, NxF32 nz, NxF32 _d)
{
    return (call_explicit) ? &classPointer->NxPlane::set(nx, ny, nz, _d) : &classPointer->set(nx, ny, nz, _d);
}

API_EXPORT NxPlane* NxPlane_set_1(NxPlane* classPointer, bool call_explicit, NxVec3& _normal, NxF32 _d)
{
    return (call_explicit) ? &classPointer->NxPlane::set(_normal, _d) : &classPointer->set(_normal, _d);
}

API_EXPORT NxPlane* NxPlane_set_2(NxPlane* classPointer, bool call_explicit, NxVec3& p, NxVec3& _n)
{
    return (call_explicit) ? &classPointer->NxPlane::set(p, _n) : &classPointer->set(p, _n);
}

API_EXPORT NxPlane* NxPlane_set_3(NxPlane* classPointer, bool call_explicit, NxVec3& p0, NxVec3& p1, NxVec3& p2)
{
    return (call_explicit) ? &classPointer->NxPlane::set(p0, p1, p2) : &classPointer->set(p0, p1, p2);
}

API_EXPORT NxF32 NxPlane_distance(NxPlane* classPointer, bool call_explicit, NxVec3& p)
{
    return (call_explicit) ? classPointer->NxPlane::distance(p) : classPointer->distance(p);
}

API_EXPORT bool NxPlane_belongs(NxPlane* classPointer, bool call_explicit, NxVec3& p)
{
    return (call_explicit) ? classPointer->NxPlane::belongs(p) : classPointer->belongs(p);
}

API_EXPORT NxVec3 NxPlane_project(NxPlane* classPointer, bool call_explicit, NxVec3& p)
{
    return (call_explicit) ? classPointer->NxPlane::project(p) : classPointer->project(p);
}

API_EXPORT NxVec3 NxPlane_pointInPlane(NxPlane* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxPlane::pointInPlane() : classPointer->pointInPlane();
}

API_EXPORT void NxPlane_normalize(NxPlane* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxPlane::normalize() : classPointer->normalize();
}

API_EXPORT void NxPlane_transform(NxPlane* classPointer, bool call_explicit, NxMat34& transform, NxPlane* transformed)
{
    (call_explicit) ? classPointer->NxPlane::transform(transform, *transformed) : classPointer->transform(transform, *transformed);
}

API_EXPORT void NxPlane_inverseTransform(NxPlane* classPointer, bool call_explicit, NxMat34& transform, NxPlane* transformed)
{
    (call_explicit) ? classPointer->NxPlane::inverseTransform(transform, *transformed) : classPointer->inverseTransform(transform, *transformed);
}

API_EXPORT void NxPlaneShape_setPlane(NxPlaneShape* classPointer, bool call_explicit, NxVec3& normal, NxReal d)
{
    classPointer->setPlane(normal, d);
}

API_EXPORT void NxPlaneShape_saveToDesc(NxPlaneShape* classPointer, bool call_explicit, NxPlaneShapeDesc* desc)
{
    classPointer->saveToDesc(*desc);
}

API_EXPORT NxPlane* NxPlaneShape_getPlane(NxPlaneShape* classPointer, bool call_explicit)
{
    return &classPointer->getPlane();
}

API_EXPORT void set_NxPlaneShapeDesc_normal(NxPlaneShapeDesc* classPointer, NxVec3 newvalue)
{
    classPointer->normal = newvalue;
}

API_EXPORT NxVec3 get_NxPlaneShapeDesc_normal(NxPlaneShapeDesc* classPointer)
{
    return classPointer->normal;
}

API_EXPORT void set_NxPlaneShapeDesc_d(NxPlaneShapeDesc* classPointer, NxReal newvalue)
{
    classPointer->d = newvalue;
}

API_EXPORT NxReal get_NxPlaneShapeDesc_d(NxPlaneShapeDesc* classPointer)
{
    return classPointer->d;
}

API_EXPORT NxPlaneShapeDesc* new_NxPlaneShapeDesc(bool do_override)
{
    return (do_override) ? new NxPlaneShapeDesc_doxybind() : new NxPlaneShapeDesc();
}

API_EXPORT void NxPlaneShapeDesc_setToDefault(NxPlaneShapeDesc* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxPlaneShapeDesc::setToDefault() : classPointer->setToDefault();
}

API_EXPORT bool NxPlaneShapeDesc_isValid(NxPlaneShapeDesc* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxPlaneShapeDesc::isValid() : classPointer->isValid();
}

API_EXPORT void set_NxPMap_dataSize(NxPMap* classPointer, NxU32 newvalue)
{
    classPointer->dataSize = newvalue;
}

API_EXPORT NxU32 get_NxPMap_dataSize(NxPMap* classPointer)
{
    return classPointer->dataSize;
}

API_EXPORT void set_NxPMap_data(NxPMap* classPointer, void* newvalue)
{
    classPointer->data = newvalue;
}

API_EXPORT void* get_NxPMap_data(NxPMap* classPointer)
{
    return classPointer->data;
}

API_EXPORT void NxPointInPlaneJoint_loadFromDesc(NxPointInPlaneJoint* classPointer, bool call_explicit, NxPointInPlaneJointDesc* desc)
{
    classPointer->loadFromDesc(*desc);
}

API_EXPORT void NxPointInPlaneJoint_saveToDesc(NxPointInPlaneJoint* classPointer, bool call_explicit, NxPointInPlaneJointDesc* desc)
{
    classPointer->saveToDesc(*desc);
}

API_EXPORT NxPointInPlaneJointDesc* new_NxPointInPlaneJointDesc(bool do_override)
{
    return (do_override) ? new NxPointInPlaneJointDesc_doxybind() : new NxPointInPlaneJointDesc();
}

API_EXPORT void NxPointInPlaneJointDesc_setToDefault(NxPointInPlaneJointDesc* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxPointInPlaneJointDesc::setToDefault() : classPointer->setToDefault();
}

API_EXPORT bool NxPointInPlaneJointDesc_isValid(NxPointInPlaneJointDesc* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxPointInPlaneJointDesc::isValid() : classPointer->isValid();
}

API_EXPORT void NxPointOnLineJoint_loadFromDesc(NxPointOnLineJoint* classPointer, bool call_explicit, NxPointOnLineJointDesc* desc)
{
    classPointer->loadFromDesc(*desc);
}

API_EXPORT void NxPointOnLineJoint_saveToDesc(NxPointOnLineJoint* classPointer, bool call_explicit, NxPointOnLineJointDesc* desc)
{
    classPointer->saveToDesc(*desc);
}

API_EXPORT NxPointOnLineJointDesc* new_NxPointOnLineJointDesc(bool do_override)
{
    return (do_override) ? new NxPointOnLineJointDesc_doxybind() : new NxPointOnLineJointDesc();
}

API_EXPORT void NxPointOnLineJointDesc_setToDefault(NxPointOnLineJointDesc* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxPointOnLineJointDesc::setToDefault() : classPointer->setToDefault();
}

API_EXPORT bool NxPointOnLineJointDesc_isValid(NxPointOnLineJointDesc* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxPointOnLineJointDesc::isValid() : classPointer->isValid();
}

API_EXPORT void NxPrismaticJoint_loadFromDesc(NxPrismaticJoint* classPointer, bool call_explicit, NxPrismaticJointDesc* desc)
{
    classPointer->loadFromDesc(*desc);
}

API_EXPORT void NxPrismaticJoint_saveToDesc(NxPrismaticJoint* classPointer, bool call_explicit, NxPrismaticJointDesc* desc)
{
    classPointer->saveToDesc(*desc);
}

API_EXPORT NxPrismaticJointDesc* new_NxPrismaticJointDesc(bool do_override)
{
    return (do_override) ? new NxPrismaticJointDesc_doxybind() : new NxPrismaticJointDesc();
}

API_EXPORT void NxPrismaticJointDesc_setToDefault(NxPrismaticJointDesc* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxPrismaticJointDesc::setToDefault() : classPointer->setToDefault();
}

API_EXPORT bool NxPrismaticJointDesc_isValid(NxPrismaticJointDesc* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxPrismaticJointDesc::isValid() : classPointer->isValid();
}

API_EXPORT void set_NxProfilerData_numZones(NxProfilerData* classPointer, NxU32 newvalue)
{
    classPointer->numZones = newvalue;
}

API_EXPORT NxU32 get_NxProfilerData_numZones(NxProfilerData* classPointer)
{
    return classPointer->numZones;
}

API_EXPORT void set_NxProfilerData_profileZones(NxProfilerData* classPointer, NxProfileZone* newvalue)
{
    classPointer->profileZones = newvalue;
}

API_EXPORT NxProfileZone* get_NxProfilerData_profileZones(NxProfilerData* classPointer)
{
    return classPointer->profileZones;
}

API_EXPORT NxProfileData* new_NxProfileData(bool do_override)
{
    return (do_override) ? new NxProfileData_doxybind() : NULL;
}

API_EXPORT const NxProfileZone* NxProfileData_getNamedZone(NxProfileData* classPointer, bool call_explicit, NxProfileZoneName unknown93)
{
    return classPointer->getNamedZone(unknown93);
}

API_EXPORT void set_NxProfileZone_name(NxProfileZone* classPointer, const char* newvalue)
{
    classPointer->name = newvalue;
}

API_EXPORT const char* get_NxProfileZone_name(NxProfileZone* classPointer)
{
    return classPointer->name;
}

API_EXPORT void set_NxProfileZone_callCount(NxProfileZone* classPointer, NxU32 newvalue)
{
    classPointer->callCount = newvalue;
}

API_EXPORT NxU32 get_NxProfileZone_callCount(NxProfileZone* classPointer)
{
    return classPointer->callCount;
}

API_EXPORT void set_NxProfileZone_hierTime(NxProfileZone* classPointer, NxU32 newvalue)
{
    classPointer->hierTime = newvalue;
}

API_EXPORT NxU32 get_NxProfileZone_hierTime(NxProfileZone* classPointer)
{
    return classPointer->hierTime;
}

API_EXPORT void set_NxProfileZone_selfTime(NxProfileZone* classPointer, NxU32 newvalue)
{
    classPointer->selfTime = newvalue;
}

API_EXPORT NxU32 get_NxProfileZone_selfTime(NxProfileZone* classPointer)
{
    return classPointer->selfTime;
}

API_EXPORT void set_NxProfileZone_recursionLevel(NxProfileZone* classPointer, NxU32 newvalue)
{
    classPointer->recursionLevel = newvalue;
}

API_EXPORT NxU32 get_NxProfileZone_recursionLevel(NxProfileZone* classPointer)
{
    return classPointer->recursionLevel;
}

API_EXPORT void set_NxProfileZone_percent(NxProfileZone* classPointer, NxReal newvalue)
{
    classPointer->percent = newvalue;
}

API_EXPORT NxReal get_NxProfileZone_percent(NxProfileZone* classPointer)
{
    return classPointer->percent;
}

API_EXPORT void NxPulleyJoint_loadFromDesc(NxPulleyJoint* classPointer, bool call_explicit, NxPulleyJointDesc* desc)
{
    classPointer->loadFromDesc(*desc);
}

API_EXPORT void NxPulleyJoint_saveToDesc(NxPulleyJoint* classPointer, bool call_explicit, NxPulleyJointDesc* desc)
{
    classPointer->saveToDesc(*desc);
}

API_EXPORT void NxPulleyJoint_setMotor(NxPulleyJoint* classPointer, bool call_explicit, NxMotorDesc* motorDesc)
{
    classPointer->setMotor(*motorDesc);
}

API_EXPORT bool NxPulleyJoint_getMotor(NxPulleyJoint* classPointer, bool call_explicit, NxMotorDesc* motorDesc)
{
    return classPointer->getMotor(*motorDesc);
}

API_EXPORT void NxPulleyJoint_setFlags(NxPulleyJoint* classPointer, bool call_explicit, NxU32 flags)
{
    classPointer->setFlags(flags);
}

API_EXPORT NxU32 NxPulleyJoint_getFlags(NxPulleyJoint* classPointer, bool call_explicit)
{
    return classPointer->getFlags();
}

API_EXPORT void set_NxPulleyJointDesc_pulley(NxPulleyJointDesc* classPointer, NxVec3 newvalue[2])
{
    memcpy(&classPointer->pulley[0], &newvalue[0], sizeof(NxVec3) * 2);
}

API_EXPORT void get_NxPulleyJointDesc_pulley(NxPulleyJointDesc* classPointer, NxVec3 newvalue[2])
{
    memcpy(&newvalue[0], &classPointer->pulley[0], sizeof(NxVec3) * 2);
}

API_EXPORT void set_NxPulleyJointDesc_distance(NxPulleyJointDesc* classPointer, NxReal newvalue)
{
    classPointer->distance = newvalue;
}

API_EXPORT NxReal get_NxPulleyJointDesc_distance(NxPulleyJointDesc* classPointer)
{
    return classPointer->distance;
}

API_EXPORT void set_NxPulleyJointDesc_stiffness(NxPulleyJointDesc* classPointer, NxReal newvalue)
{
    classPointer->stiffness = newvalue;
}

API_EXPORT NxReal get_NxPulleyJointDesc_stiffness(NxPulleyJointDesc* classPointer)
{
    return classPointer->stiffness;
}

API_EXPORT void set_NxPulleyJointDesc_ratio(NxPulleyJointDesc* classPointer, NxReal newvalue)
{
    classPointer->ratio = newvalue;
}

API_EXPORT NxReal get_NxPulleyJointDesc_ratio(NxPulleyJointDesc* classPointer)
{
    return classPointer->ratio;
}

API_EXPORT void set_NxPulleyJointDesc_flags(NxPulleyJointDesc* classPointer, NxU32 newvalue)
{
    classPointer->flags = newvalue;
}

API_EXPORT NxU32 get_NxPulleyJointDesc_flags(NxPulleyJointDesc* classPointer)
{
    return classPointer->flags;
}

API_EXPORT void set_NxPulleyJointDesc_motor(NxPulleyJointDesc* classPointer, NxMotorDesc* newvalue)
{
    classPointer->motor = *newvalue;
}

API_EXPORT NxMotorDesc* get_NxPulleyJointDesc_motor(NxPulleyJointDesc* classPointer)
{
    return &classPointer->motor;
}

API_EXPORT NxPulleyJointDesc* new_NxPulleyJointDesc(bool do_override)
{
    return (do_override) ? new NxPulleyJointDesc_doxybind() : new NxPulleyJointDesc();
}

API_EXPORT void NxPulleyJointDesc_setToDefault(NxPulleyJointDesc* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxPulleyJointDesc::setToDefault() : classPointer->setToDefault();
}

API_EXPORT bool NxPulleyJointDesc_isValid(NxPulleyJointDesc* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxPulleyJointDesc::isValid() : classPointer->isValid();
}

API_EXPORT void set_NxRay_orig(NxRay* classPointer, NxVec3 newvalue)
{
    classPointer->orig = newvalue;
}

API_EXPORT NxVec3 get_NxRay_orig(NxRay* classPointer)
{
    return classPointer->orig;
}

API_EXPORT void set_NxRay_dir(NxRay* classPointer, NxVec3 newvalue)
{
    classPointer->dir = newvalue;
}

API_EXPORT NxVec3 get_NxRay_dir(NxRay* classPointer)
{
    return classPointer->dir;
}

API_EXPORT NxRay* new_NxRay(bool do_override)
{
    return new NxRay();
}

API_EXPORT NxRay* new_NxRay_1(bool do_override, NxVec3& _orig, NxVec3& _dir)
{
    return new NxRay(_orig, _dir);
}

API_EXPORT void set_NxRaycastHit_shape(NxRaycastHit* classPointer, NxShape* newvalue)
{
    classPointer->shape = newvalue;
}

API_EXPORT NxShape* get_NxRaycastHit_shape(NxRaycastHit* classPointer)
{
    return classPointer->shape;
}

API_EXPORT void set_NxRaycastHit_worldImpact(NxRaycastHit* classPointer, NxVec3 newvalue)
{
    classPointer->worldImpact = newvalue;
}

API_EXPORT NxVec3 get_NxRaycastHit_worldImpact(NxRaycastHit* classPointer)
{
    return classPointer->worldImpact;
}

API_EXPORT void set_NxRaycastHit_worldNormal(NxRaycastHit* classPointer, NxVec3 newvalue)
{
    classPointer->worldNormal = newvalue;
}

API_EXPORT NxVec3 get_NxRaycastHit_worldNormal(NxRaycastHit* classPointer)
{
    return classPointer->worldNormal;
}

API_EXPORT void set_NxRaycastHit_faceID(NxRaycastHit* classPointer, NxU32 newvalue)
{
    classPointer->faceID = newvalue;
}

API_EXPORT NxU32 get_NxRaycastHit_faceID(NxRaycastHit* classPointer)
{
    return classPointer->faceID;
}

API_EXPORT void set_NxRaycastHit_internalFaceID(NxRaycastHit* classPointer, NxTriangleID newvalue)
{
    classPointer->internalFaceID = newvalue;
}

API_EXPORT NxTriangleID get_NxRaycastHit_internalFaceID(NxRaycastHit* classPointer)
{
    return classPointer->internalFaceID;
}

API_EXPORT void set_NxRaycastHit_distance(NxRaycastHit* classPointer, NxReal newvalue)
{
    classPointer->distance = newvalue;
}

API_EXPORT NxReal get_NxRaycastHit_distance(NxRaycastHit* classPointer)
{
    return classPointer->distance;
}

API_EXPORT void set_NxRaycastHit_u(NxRaycastHit* classPointer, NxReal newvalue)
{
    classPointer->u = newvalue;
}

API_EXPORT NxReal get_NxRaycastHit_u(NxRaycastHit* classPointer)
{
    return classPointer->u;
}

API_EXPORT void set_NxRaycastHit_v(NxRaycastHit* classPointer, NxReal newvalue)
{
    classPointer->v = newvalue;
}

API_EXPORT NxReal get_NxRaycastHit_v(NxRaycastHit* classPointer)
{
    return classPointer->v;
}

API_EXPORT void set_NxRaycastHit_materialIndex(NxRaycastHit* classPointer, NxMaterialIndex newvalue)
{
    classPointer->materialIndex = newvalue;
}

API_EXPORT NxMaterialIndex get_NxRaycastHit_materialIndex(NxRaycastHit* classPointer)
{
    return classPointer->materialIndex;
}

API_EXPORT void set_NxRaycastHit_flags(NxRaycastHit* classPointer, NxU32 newvalue)
{
    classPointer->flags = newvalue;
}

API_EXPORT NxU32 get_NxRaycastHit_flags(NxRaycastHit* classPointer)
{
    return classPointer->flags;
}

API_EXPORT void NxRemoteDebugger_connect(NxRemoteDebugger* classPointer, bool call_explicit, char* host, unsigned int port, NxU32 eventMask)
{
    classPointer->connect(host, port, eventMask);
}

API_EXPORT void NxRemoteDebugger_connect_1(NxRemoteDebugger* classPointer, bool call_explicit, char* host, unsigned int port)
{
    classPointer->connect(host, port);
}

API_EXPORT void NxRemoteDebugger_connect_2(NxRemoteDebugger* classPointer, bool call_explicit, char* host)
{
    classPointer->connect(host);
}

API_EXPORT void NxRemoteDebugger_disconnect(NxRemoteDebugger* classPointer, bool call_explicit)
{
    classPointer->disconnect();
}

API_EXPORT void NxRemoteDebugger_flush(NxRemoteDebugger* classPointer, bool call_explicit)
{
    classPointer->flush();
}

API_EXPORT bool NxRemoteDebugger_isConnected(NxRemoteDebugger* classPointer, bool call_explicit)
{
    return classPointer->isConnected();
}

API_EXPORT void NxRemoteDebugger_frameBreak(NxRemoteDebugger* classPointer, bool call_explicit)
{
    classPointer->frameBreak();
}

API_EXPORT void NxRemoteDebugger_createObject(NxRemoteDebugger* classPointer, bool call_explicit, void* _object, NxRemoteDebuggerObjectType type, char* className, NxU32 mask)
{
    classPointer->createObject(_object, type, className, mask);
}

API_EXPORT void NxRemoteDebugger_removeObject(NxRemoteDebugger* classPointer, bool call_explicit, void* _object, NxU32 mask)
{
    classPointer->removeObject(_object, mask);
}

API_EXPORT void NxRemoteDebugger_addChild(NxRemoteDebugger* classPointer, bool call_explicit, void* _object, void* child, NxU32 mask)
{
    classPointer->addChild(_object, child, mask);
}

API_EXPORT void NxRemoteDebugger_removeChild(NxRemoteDebugger* classPointer, bool call_explicit, void* _object, void* child, NxU32 mask)
{
    classPointer->removeChild(_object, child, mask);
}

API_EXPORT void NxRemoteDebugger_writeParameter(NxRemoteDebugger* classPointer, bool call_explicit, NxReal& parameter, void* _object, bool create, char* name, NxU32 mask)
{
    classPointer->writeParameter(parameter, _object, create, name, mask);
}

API_EXPORT void NxRemoteDebugger_writeParameter_1(NxRemoteDebugger* classPointer, bool call_explicit, NxU32& parameter, void* _object, bool create, char* name, NxU32 mask)
{
    classPointer->writeParameter(parameter, _object, create, name, mask);
}

API_EXPORT void NxRemoteDebugger_writeParameter_2(NxRemoteDebugger* classPointer, bool call_explicit, NxVec3& parameter, void* _object, bool create, char* name, NxU32 mask)
{
    classPointer->writeParameter(parameter, _object, create, name, mask);
}

API_EXPORT void NxRemoteDebugger_writeParameter_3(NxRemoteDebugger* classPointer, bool call_explicit, NxPlane* parameter, void* _object, bool create, char* name, NxU32 mask)
{
    classPointer->writeParameter(*parameter, _object, create, name, mask);
}

API_EXPORT void NxRemoteDebugger_writeParameter_4(NxRemoteDebugger* classPointer, bool call_explicit, NxMat34& parameter, void* _object, bool create, char* name, NxU32 mask)
{
    classPointer->writeParameter(parameter, _object, create, name, mask);
}

API_EXPORT void NxRemoteDebugger_writeParameter_5(NxRemoteDebugger* classPointer, bool call_explicit, NxMat33& parameter, void* _object, bool create, char* name, NxU32 mask)
{
    classPointer->writeParameter(parameter, _object, create, name, mask);
}

API_EXPORT void NxRemoteDebugger_writeParameter_6(NxRemoteDebugger* classPointer, bool call_explicit, NxU8* parameter, void* _object, bool create, char* name, NxU32 mask)
{
    classPointer->writeParameter(parameter, _object, create, name, mask);
}

API_EXPORT void NxRemoteDebugger_writeParameter_7(NxRemoteDebugger* classPointer, bool call_explicit, char* parameter, void* _object, bool create, char* name, NxU32 mask)
{
    classPointer->writeParameter(parameter, _object, create, name, mask);
}

API_EXPORT void NxRemoteDebugger_writeParameter_8(NxRemoteDebugger* classPointer, bool call_explicit, bool& parameter, void* _object, bool create, char* name, NxU32 mask)
{
    classPointer->writeParameter(parameter, _object, create, name, mask);
}

API_EXPORT void NxRemoteDebugger_writeParameter_9(NxRemoteDebugger* classPointer, bool call_explicit, void* parameter, void* _object, bool create, char* name, NxU32 mask)
{
    classPointer->writeParameter(parameter, _object, create, name, mask);
}

API_EXPORT void NxRemoteDebugger_setMask(NxRemoteDebugger* classPointer, bool call_explicit, NxU32 mask)
{
    classPointer->setMask(mask);
}

API_EXPORT NxU32 NxRemoteDebugger_getMask(NxRemoteDebugger* classPointer, bool call_explicit)
{
    return classPointer->getMask();
}

API_EXPORT void* NxRemoteDebugger_getPickedObject(NxRemoteDebugger* classPointer, bool call_explicit)
{
    return classPointer->getPickedObject();
}

API_EXPORT NxVec3 NxRemoteDebugger_getPickPoint(NxRemoteDebugger* classPointer, bool call_explicit)
{
    return classPointer->getPickPoint();
}

API_EXPORT void NxRemoteDebugger_registerEventListener(NxRemoteDebugger* classPointer, bool call_explicit, NxRemoteDebuggerEventListener* eventListener)
{
    classPointer->registerEventListener(eventListener);
}

API_EXPORT void NxRemoteDebugger_unregisterEventListener(NxRemoteDebugger* classPointer, bool call_explicit, NxRemoteDebuggerEventListener* eventListener)
{
    classPointer->unregisterEventListener(eventListener);
}

API_EXPORT void NxRemoteDebuggerEventListener_onConnect(NxRemoteDebuggerEventListener* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxRemoteDebuggerEventListener::onConnect() : classPointer->onConnect();
}

API_EXPORT void NxRemoteDebuggerEventListener_onDisconnect(NxRemoteDebuggerEventListener* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxRemoteDebuggerEventListener::onDisconnect() : classPointer->onDisconnect();
}

API_EXPORT void NxRemoteDebuggerEventListener_beforeMaskChange(NxRemoteDebuggerEventListener* classPointer, bool call_explicit, NxU32 oldMask, NxU32 newMask)
{
    (call_explicit) ? classPointer->NxRemoteDebuggerEventListener::beforeMaskChange(oldMask, newMask) : classPointer->beforeMaskChange(oldMask, newMask);
}

API_EXPORT void NxRemoteDebuggerEventListener_afterMaskChange(NxRemoteDebuggerEventListener* classPointer, bool call_explicit, NxU32 oldMask, NxU32 newMask)
{
    (call_explicit) ? classPointer->NxRemoteDebuggerEventListener::afterMaskChange(oldMask, newMask) : classPointer->afterMaskChange(oldMask, newMask);
}

API_EXPORT void NxRevoluteJoint_loadFromDesc(NxRevoluteJoint* classPointer, bool call_explicit, NxRevoluteJointDesc* desc)
{
    classPointer->loadFromDesc(*desc);
}

API_EXPORT void NxRevoluteJoint_saveToDesc(NxRevoluteJoint* classPointer, bool call_explicit, NxRevoluteJointDesc* desc)
{
    classPointer->saveToDesc(*desc);
}

API_EXPORT void NxRevoluteJoint_setLimits(NxRevoluteJoint* classPointer, bool call_explicit, NxJointLimitPairDesc* pair)
{
    classPointer->setLimits(*pair);
}

API_EXPORT bool NxRevoluteJoint_getLimits(NxRevoluteJoint* classPointer, bool call_explicit, NxJointLimitPairDesc* pair)
{
    return classPointer->getLimits(*pair);
}

API_EXPORT void NxRevoluteJoint_setMotor(NxRevoluteJoint* classPointer, bool call_explicit, NxMotorDesc* motorDesc)
{
    classPointer->setMotor(*motorDesc);
}

API_EXPORT bool NxRevoluteJoint_getMotor(NxRevoluteJoint* classPointer, bool call_explicit, NxMotorDesc* motorDesc)
{
    return classPointer->getMotor(*motorDesc);
}

API_EXPORT void NxRevoluteJoint_setSpring(NxRevoluteJoint* classPointer, bool call_explicit, NxSpringDesc* springDesc)
{
    classPointer->setSpring(*springDesc);
}

API_EXPORT bool NxRevoluteJoint_getSpring(NxRevoluteJoint* classPointer, bool call_explicit, NxSpringDesc* springDesc)
{
    return classPointer->getSpring(*springDesc);
}

API_EXPORT NxReal NxRevoluteJoint_getAngle(NxRevoluteJoint* classPointer, bool call_explicit)
{
    return classPointer->getAngle();
}

API_EXPORT NxReal NxRevoluteJoint_getVelocity(NxRevoluteJoint* classPointer, bool call_explicit)
{
    return classPointer->getVelocity();
}

API_EXPORT void NxRevoluteJoint_setFlags(NxRevoluteJoint* classPointer, bool call_explicit, NxU32 flags)
{
    classPointer->setFlags(flags);
}

API_EXPORT NxU32 NxRevoluteJoint_getFlags(NxRevoluteJoint* classPointer, bool call_explicit)
{
    return classPointer->getFlags();
}

API_EXPORT void NxRevoluteJoint_setProjectionMode(NxRevoluteJoint* classPointer, bool call_explicit, NxJointProjectionMode projectionMode)
{
    classPointer->setProjectionMode(projectionMode);
}

API_EXPORT NxJointProjectionMode NxRevoluteJoint_getProjectionMode(NxRevoluteJoint* classPointer, bool call_explicit)
{
    return classPointer->getProjectionMode();
}

API_EXPORT void set_NxRevoluteJointDesc_limit(NxRevoluteJointDesc* classPointer, NxJointLimitPairDesc* newvalue)
{
    classPointer->limit = *newvalue;
}

API_EXPORT NxJointLimitPairDesc* get_NxRevoluteJointDesc_limit(NxRevoluteJointDesc* classPointer)
{
    return &classPointer->limit;
}

API_EXPORT void set_NxRevoluteJointDesc_motor(NxRevoluteJointDesc* classPointer, NxMotorDesc* newvalue)
{
    classPointer->motor = *newvalue;
}

API_EXPORT NxMotorDesc* get_NxRevoluteJointDesc_motor(NxRevoluteJointDesc* classPointer)
{
    return &classPointer->motor;
}

API_EXPORT void set_NxRevoluteJointDesc_spring(NxRevoluteJointDesc* classPointer, NxSpringDesc* newvalue)
{
    classPointer->spring = *newvalue;
}

API_EXPORT NxSpringDesc* get_NxRevoluteJointDesc_spring(NxRevoluteJointDesc* classPointer)
{
    return &classPointer->spring;
}

API_EXPORT void set_NxRevoluteJointDesc_projectionDistance(NxRevoluteJointDesc* classPointer, NxReal newvalue)
{
    classPointer->projectionDistance = newvalue;
}

API_EXPORT NxReal get_NxRevoluteJointDesc_projectionDistance(NxRevoluteJointDesc* classPointer)
{
    return classPointer->projectionDistance;
}

API_EXPORT void set_NxRevoluteJointDesc_projectionAngle(NxRevoluteJointDesc* classPointer, NxReal newvalue)
{
    classPointer->projectionAngle = newvalue;
}

API_EXPORT NxReal get_NxRevoluteJointDesc_projectionAngle(NxRevoluteJointDesc* classPointer)
{
    return classPointer->projectionAngle;
}

API_EXPORT void set_NxRevoluteJointDesc_flags(NxRevoluteJointDesc* classPointer, NxU32 newvalue)
{
    classPointer->flags = newvalue;
}

API_EXPORT NxU32 get_NxRevoluteJointDesc_flags(NxRevoluteJointDesc* classPointer)
{
    return classPointer->flags;
}

API_EXPORT void set_NxRevoluteJointDesc_projectionMode(NxRevoluteJointDesc* classPointer, NxJointProjectionMode newvalue)
{
    classPointer->projectionMode = newvalue;
}

API_EXPORT NxJointProjectionMode get_NxRevoluteJointDesc_projectionMode(NxRevoluteJointDesc* classPointer)
{
    return classPointer->projectionMode;
}

API_EXPORT NxRevoluteJointDesc* new_NxRevoluteJointDesc(bool do_override)
{
    return (do_override) ? new NxRevoluteJointDesc_doxybind() : new NxRevoluteJointDesc();
}

API_EXPORT void NxRevoluteJointDesc_setToDefault(NxRevoluteJointDesc* classPointer, bool call_explicit, bool fromCtor)
{
    (call_explicit) ? classPointer->NxRevoluteJointDesc::setToDefault(fromCtor) : classPointer->setToDefault(fromCtor);
}

API_EXPORT bool NxRevoluteJointDesc_isValid(NxRevoluteJointDesc* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxRevoluteJointDesc::isValid() : classPointer->isValid();
}

API_EXPORT NxActor* NxScene_createActor(NxScene* classPointer, bool call_explicit, NxActorDescBase* desc)
{
    return classPointer->createActor(*desc);
}

API_EXPORT void NxScene_releaseActor(NxScene* classPointer, bool call_explicit, NxActor* actor)
{
    classPointer->releaseActor(*actor);
}

API_EXPORT NxJoint* NxScene_createJoint(NxScene* classPointer, bool call_explicit, NxJointDesc* jointDesc)
{
    return classPointer->createJoint(*jointDesc);
}

API_EXPORT void NxScene_releaseJoint(NxScene* classPointer, bool call_explicit, NxJoint* joint)
{
    classPointer->releaseJoint(*joint);
}

API_EXPORT NxSpringAndDamperEffector* NxScene_createSpringAndDamperEffector(NxScene* classPointer, bool call_explicit, NxSpringAndDamperEffectorDesc* springDesc)
{
    return classPointer->createSpringAndDamperEffector(*springDesc);
}

API_EXPORT NxEffector* NxScene_createEffector(NxScene* classPointer, bool call_explicit, NxEffectorDesc* desc)
{
    return classPointer->createEffector(*desc);
}

API_EXPORT void NxScene_releaseEffector(NxScene* classPointer, bool call_explicit, NxEffector* effector)
{
    classPointer->releaseEffector(*effector);
}

API_EXPORT NxForceField* NxScene_createForceField(NxScene* classPointer, bool call_explicit, NxForceFieldDesc* forceFieldDesc)
{
    return classPointer->createForceField(*forceFieldDesc);
}

API_EXPORT void NxScene_releaseForceField(NxScene* classPointer, bool call_explicit, NxForceField* forceField)
{
    classPointer->releaseForceField(*forceField);
}

API_EXPORT NxU32 NxScene_getNbForceFields(NxScene* classPointer, bool call_explicit)
{
    return classPointer->getNbForceFields();
}

API_EXPORT NxForceField** NxScene_getForceFields(NxScene* classPointer, bool call_explicit)
{
    return classPointer->getForceFields();
}

API_EXPORT NxForceFieldLinearKernel* NxScene_createForceFieldLinearKernel(NxScene* classPointer, bool call_explicit, NxForceFieldLinearKernelDesc* kernelDesc)
{
    return classPointer->createForceFieldLinearKernel(*kernelDesc);
}

API_EXPORT void NxScene_releaseForceFieldLinearKernel(NxScene* classPointer, bool call_explicit, NxForceFieldLinearKernel* kernel)
{
    classPointer->releaseForceFieldLinearKernel(*kernel);
}

API_EXPORT NxU32 NxScene_getNbForceFieldLinearKernels(NxScene* classPointer, bool call_explicit)
{
    return classPointer->getNbForceFieldLinearKernels();
}

API_EXPORT void NxScene_resetForceFieldLinearKernelsIterator(NxScene* classPointer, bool call_explicit)
{
    classPointer->resetForceFieldLinearKernelsIterator();
}

API_EXPORT NxForceFieldLinearKernel* NxScene_getNextForceFieldLinearKernel(NxScene* classPointer, bool call_explicit)
{
    return classPointer->getNextForceFieldLinearKernel();
}

API_EXPORT NxForceFieldShapeGroup* NxScene_createForceFieldShapeGroup(NxScene* classPointer, bool call_explicit, NxForceFieldShapeGroupDesc* desc)
{
    return classPointer->createForceFieldShapeGroup(*desc);
}

API_EXPORT void NxScene_releaseForceFieldShapeGroup(NxScene* classPointer, bool call_explicit, NxForceFieldShapeGroup* group)
{
    classPointer->releaseForceFieldShapeGroup(*group);
}

API_EXPORT NxU32 NxScene_getNbForceFieldShapeGroups(NxScene* classPointer, bool call_explicit)
{
    return classPointer->getNbForceFieldShapeGroups();
}

API_EXPORT void NxScene_resetForceFieldShapeGroupsIterator(NxScene* classPointer, bool call_explicit)
{
    classPointer->resetForceFieldShapeGroupsIterator();
}

API_EXPORT NxForceFieldShapeGroup* NxScene_getNextForceFieldShapeGroup(NxScene* classPointer, bool call_explicit)
{
    return classPointer->getNextForceFieldShapeGroup();
}

API_EXPORT NxForceFieldVariety NxScene_createForceFieldVariety(NxScene* classPointer, bool call_explicit)
{
    return classPointer->createForceFieldVariety();
}

API_EXPORT NxForceFieldVariety NxScene_getHighestForceFieldVariety(NxScene* classPointer, bool call_explicit)
{
    return classPointer->getHighestForceFieldVariety();
}

API_EXPORT void NxScene_releaseForceFieldVariety(NxScene* classPointer, bool call_explicit, NxForceFieldVariety var)
{
    classPointer->releaseForceFieldVariety(var);
}

API_EXPORT NxForceFieldMaterial NxScene_createForceFieldMaterial(NxScene* classPointer, bool call_explicit)
{
    return classPointer->createForceFieldMaterial();
}

API_EXPORT NxForceFieldMaterial NxScene_getHighestForceFieldMaterial(NxScene* classPointer, bool call_explicit)
{
    return classPointer->getHighestForceFieldMaterial();
}

API_EXPORT void NxScene_releaseForceFieldMaterial(NxScene* classPointer, bool call_explicit, NxForceFieldMaterial mat)
{
    classPointer->releaseForceFieldMaterial(mat);
}

API_EXPORT NxReal NxScene_getForceFieldScale(NxScene* classPointer, bool call_explicit, NxForceFieldVariety var, NxForceFieldMaterial mat)
{
    return classPointer->getForceFieldScale(var, mat);
}

API_EXPORT void NxScene_setForceFieldScale(NxScene* classPointer, bool call_explicit, NxForceFieldVariety var, NxForceFieldMaterial mat, NxReal val)
{
    classPointer->setForceFieldScale(var, mat, val);
}

API_EXPORT NxMaterial* NxScene_createMaterial(NxScene* classPointer, bool call_explicit, NxMaterialDesc* matDesc)
{
    return classPointer->createMaterial(*matDesc);
}

API_EXPORT void NxScene_releaseMaterial(NxScene* classPointer, bool call_explicit, NxMaterial* material)
{
    classPointer->releaseMaterial(*material);
}

API_EXPORT NxCompartment* NxScene_createCompartment(NxScene* classPointer, bool call_explicit, NxCompartmentDesc* compDesc)
{
    return classPointer->createCompartment(*compDesc);
}

API_EXPORT NxU32 NxScene_getNbCompartments(NxScene* classPointer, bool call_explicit)
{
    return classPointer->getNbCompartments();
}

API_EXPORT NxU32 NxScene_getCompartmentArray(NxScene* classPointer, bool call_explicit, NxCompartment** userBuffer, NxU32 bufferSize, NxU32& usersIterator)
{
    return classPointer->getCompartmentArray(userBuffer, bufferSize, usersIterator);
}

API_EXPORT void NxScene_setActorPairFlags(NxScene* classPointer, bool call_explicit, NxActor* actorA, NxActor* actorB, NxU32 nxContactPairFlag)
{
    classPointer->setActorPairFlags(*actorA, *actorB, nxContactPairFlag);
}

API_EXPORT NxU32 NxScene_getActorPairFlags(NxScene* classPointer, bool call_explicit, NxActor* actorA, NxActor* actorB)
{
    return classPointer->getActorPairFlags(*actorA, *actorB);
}

API_EXPORT void NxScene_setShapePairFlags(NxScene* classPointer, bool call_explicit, NxShape* shapeA, NxShape* shapeB, NxU32 nxContactPairFlag)
{
    classPointer->setShapePairFlags(*shapeA, *shapeB, nxContactPairFlag);
}

API_EXPORT NxU32 NxScene_getShapePairFlags(NxScene* classPointer, bool call_explicit, NxShape* shapeA, NxShape* shapeB)
{
    return classPointer->getShapePairFlags(*shapeA, *shapeB);
}

API_EXPORT NxU32 NxScene_getNbPairs(NxScene* classPointer, bool call_explicit)
{
    return classPointer->getNbPairs();
}

API_EXPORT NxU32 NxScene_getPairFlagArray(NxScene* classPointer, bool call_explicit, NxPairFlag* userArray, NxU32 numPairs)
{
    return classPointer->getPairFlagArray(userArray, numPairs);
}

API_EXPORT void NxScene_setGroupCollisionFlag(NxScene* classPointer, bool call_explicit, NxCollisionGroup group1, NxCollisionGroup group2, bool enable)
{
    classPointer->setGroupCollisionFlag(group1, group2, enable);
}

API_EXPORT bool NxScene_getGroupCollisionFlag(NxScene* classPointer, bool call_explicit, NxCollisionGroup group1, NxCollisionGroup group2)
{
    return classPointer->getGroupCollisionFlag(group1, group2);
}

API_EXPORT void NxScene_setDominanceGroupPair(NxScene* classPointer, bool call_explicit, NxDominanceGroup group1, NxDominanceGroup group2, NxConstraintDominance* dominance)
{
    classPointer->setDominanceGroupPair(group1, group2, *dominance);
}

API_EXPORT NxConstraintDominance* NxScene_getDominanceGroupPair(NxScene* classPointer, bool call_explicit, NxDominanceGroup group1, NxDominanceGroup group2)
{
    return &classPointer->getDominanceGroupPair(group1, group2);
}

API_EXPORT void NxScene_setActorGroupPairFlags(NxScene* classPointer, bool call_explicit, NxActorGroup group1, NxActorGroup group2, NxU32 flags)
{
    classPointer->setActorGroupPairFlags(group1, group2, flags);
}

API_EXPORT NxU32 NxScene_getActorGroupPairFlags(NxScene* classPointer, bool call_explicit, NxActorGroup group1, NxActorGroup group2)
{
    return classPointer->getActorGroupPairFlags(group1, group2);
}

API_EXPORT NxU32 NxScene_getNbActorGroupPairs(NxScene* classPointer, bool call_explicit)
{
    return classPointer->getNbActorGroupPairs();
}

API_EXPORT NxU32 NxScene_getActorGroupPairArray(NxScene* classPointer, bool call_explicit, NxActorGroupPair* userBuffer, NxU32 bufferSize, NxU32& userIterator)
{
    return classPointer->getActorGroupPairArray(userBuffer, bufferSize, userIterator);
}

API_EXPORT void NxScene_setFilterOps(NxScene* classPointer, bool call_explicit, NxFilterOp op0, NxFilterOp op1, NxFilterOp op2)
{
    classPointer->setFilterOps(op0, op1, op2);
}

API_EXPORT void NxScene_setFilterBool(NxScene* classPointer, bool call_explicit, bool flag)
{
    classPointer->setFilterBool(flag);
}

API_EXPORT void NxScene_setFilterConstant0(NxScene* classPointer, bool call_explicit, NxGroupsMask* mask)
{
    classPointer->setFilterConstant0(*mask);
}

API_EXPORT void NxScene_setFilterConstant1(NxScene* classPointer, bool call_explicit, NxGroupsMask* mask)
{
    classPointer->setFilterConstant1(*mask);
}

API_EXPORT void NxScene_getFilterOps(NxScene* classPointer, bool call_explicit, NxFilterOp& op0, NxFilterOp& op1, NxFilterOp& op2)
{
    classPointer->getFilterOps(op0, op1, op2);
}

API_EXPORT bool NxScene_getFilterBool(NxScene* classPointer, bool call_explicit)
{
    return classPointer->getFilterBool();
}

API_EXPORT NxGroupsMask* NxScene_getFilterConstant0(NxScene* classPointer, bool call_explicit)
{
    return &classPointer->getFilterConstant0();
}

API_EXPORT NxGroupsMask* NxScene_getFilterConstant1(NxScene* classPointer, bool call_explicit)
{
    return &classPointer->getFilterConstant1();
}

API_EXPORT NxU32 NxScene_getNbActors(NxScene* classPointer, bool call_explicit)
{
    return classPointer->getNbActors();
}

API_EXPORT NxActor** NxScene_getActors(NxScene* classPointer, bool call_explicit)
{
    return classPointer->getActors();
}

API_EXPORT NxActiveTransform* NxScene_getActiveTransforms(NxScene* classPointer, bool call_explicit, NxU32& nbTransformsOut)
{
    return classPointer->getActiveTransforms(nbTransformsOut);
}

API_EXPORT NxU32 NxScene_getNbStaticShapes(NxScene* classPointer, bool call_explicit)
{
    return classPointer->getNbStaticShapes();
}

API_EXPORT NxU32 NxScene_getNbDynamicShapes(NxScene* classPointer, bool call_explicit)
{
    return classPointer->getNbDynamicShapes();
}

API_EXPORT NxU32 NxScene_getTotalNbShapes(NxScene* classPointer, bool call_explicit)
{
    return classPointer->getTotalNbShapes();
}

API_EXPORT NxU32 NxScene_getNbJoints(NxScene* classPointer, bool call_explicit)
{
    return classPointer->getNbJoints();
}

API_EXPORT void NxScene_resetJointIterator(NxScene* classPointer, bool call_explicit)
{
    classPointer->resetJointIterator();
}

API_EXPORT NxJoint* NxScene_getNextJoint(NxScene* classPointer, bool call_explicit)
{
    return classPointer->getNextJoint();
}

API_EXPORT NxU32 NxScene_getNbEffectors(NxScene* classPointer, bool call_explicit)
{
    return classPointer->getNbEffectors();
}

API_EXPORT void NxScene_resetEffectorIterator(NxScene* classPointer, bool call_explicit)
{
    classPointer->resetEffectorIterator();
}

API_EXPORT NxEffector* NxScene_getNextEffector(NxScene* classPointer, bool call_explicit)
{
    return classPointer->getNextEffector();
}

API_EXPORT NxU32 NxScene_getBoundForIslandSize(NxScene* classPointer, bool call_explicit, NxActor* actor)
{
    return classPointer->getBoundForIslandSize(*actor);
}

API_EXPORT NxU32 NxScene_getIslandArrayFromActor(NxScene* classPointer, bool call_explicit, NxActor* actor, NxActor** userBuffer, NxU32 bufferSize, NxU32& userIterator)
{
    return classPointer->getIslandArrayFromActor(*actor, userBuffer, bufferSize, userIterator);
}

API_EXPORT NxU32 NxScene_getNbMaterials(NxScene* classPointer, bool call_explicit)
{
    return classPointer->getNbMaterials();
}

API_EXPORT NxU32 NxScene_getMaterialArray(NxScene* classPointer, bool call_explicit, NxMaterial** userBuffer, NxU32 bufferSize, NxU32& usersIterator)
{
    return classPointer->getMaterialArray(userBuffer, bufferSize, usersIterator);
}

API_EXPORT NxMaterialIndex NxScene_getHighestMaterialIndex(NxScene* classPointer, bool call_explicit)
{
    return classPointer->getHighestMaterialIndex();
}

API_EXPORT NxMaterial* NxScene_getMaterialFromIndex(NxScene* classPointer, bool call_explicit, NxMaterialIndex matIndex)
{
    return classPointer->getMaterialFromIndex(matIndex);
}

API_EXPORT void NxScene_setUserNotify(NxScene* classPointer, bool call_explicit, NxUserNotify* callback)
{
    classPointer->setUserNotify(callback);
}

API_EXPORT NxUserNotify* NxScene_getUserNotify(NxScene* classPointer, bool call_explicit)
{
    return classPointer->getUserNotify();
}

API_EXPORT void NxScene_setFluidUserNotify(NxScene* classPointer, bool call_explicit, NxFluidUserNotify* callback)
{
    classPointer->setFluidUserNotify(callback);
}

API_EXPORT NxFluidUserNotify* NxScene_getFluidUserNotify(NxScene* classPointer, bool call_explicit)
{
    return classPointer->getFluidUserNotify();
}

API_EXPORT void NxScene_setClothUserNotify(NxScene* classPointer, bool call_explicit, NxClothUserNotify* callback)
{
    classPointer->setClothUserNotify(callback);
}

API_EXPORT NxClothUserNotify* NxScene_getClothUserNotify(NxScene* classPointer, bool call_explicit)
{
    return classPointer->getClothUserNotify();
}

API_EXPORT void NxScene_setSoftBodyUserNotify(NxScene* classPointer, bool call_explicit, NxSoftBodyUserNotify* callback)
{
    classPointer->setSoftBodyUserNotify(callback);
}

API_EXPORT NxSoftBodyUserNotify* NxScene_getSoftBodyUserNotify(NxScene* classPointer, bool call_explicit)
{
    return classPointer->getSoftBodyUserNotify();
}

API_EXPORT void NxScene_setUserContactModify(NxScene* classPointer, bool call_explicit, NxUserContactModify* callback)
{
    classPointer->setUserContactModify(callback);
}

API_EXPORT NxUserContactModify* NxScene_getUserContactModify(NxScene* classPointer, bool call_explicit)
{
    return classPointer->getUserContactModify();
}

API_EXPORT void NxScene_setUserTriggerReport(NxScene* classPointer, bool call_explicit, NxUserTriggerReport* callback)
{
    classPointer->setUserTriggerReport(callback);
}

API_EXPORT NxUserTriggerReport* NxScene_getUserTriggerReport(NxScene* classPointer, bool call_explicit)
{
    return classPointer->getUserTriggerReport();
}

API_EXPORT void NxScene_setUserContactReport(NxScene* classPointer, bool call_explicit, NxUserContactReport* callback)
{
    classPointer->setUserContactReport(callback);
}

API_EXPORT NxUserContactReport* NxScene_getUserContactReport(NxScene* classPointer, bool call_explicit)
{
    return classPointer->getUserContactReport();
}

API_EXPORT void NxScene_setUserActorPairFiltering(NxScene* classPointer, bool call_explicit, NxUserActorPairFiltering* callback)
{
    classPointer->setUserActorPairFiltering(callback);
}

API_EXPORT NxUserActorPairFiltering* NxScene_getUserActorPairFiltering(NxScene* classPointer, bool call_explicit)
{
    return classPointer->getUserActorPairFiltering();
}

API_EXPORT bool NxScene_raycastAnyBounds(NxScene* classPointer, bool call_explicit, NxRay* worldRay, NxShapesType shapesType, NxU32 groups, NxReal maxDist, NxGroupsMask* groupsMask)
{
    return classPointer->raycastAnyBounds(*worldRay, shapesType, groups, maxDist, groupsMask);
}

API_EXPORT bool NxScene_raycastAnyBounds_1(NxScene* classPointer, bool call_explicit, NxRay* worldRay, NxShapesType shapesType, NxU32 groups, NxReal maxDist)
{
    return classPointer->raycastAnyBounds(*worldRay, shapesType, groups, maxDist);
}

API_EXPORT bool NxScene_raycastAnyBounds_2(NxScene* classPointer, bool call_explicit, NxRay* worldRay, NxShapesType shapesType, NxU32 groups)
{
    return classPointer->raycastAnyBounds(*worldRay, shapesType, groups);
}

API_EXPORT bool NxScene_raycastAnyBounds_3(NxScene* classPointer, bool call_explicit, NxRay* worldRay, NxShapesType shapesType)
{
    return classPointer->raycastAnyBounds(*worldRay, shapesType);
}

API_EXPORT bool NxScene_raycastAnyShape(NxScene* classPointer, bool call_explicit, NxRay* worldRay, NxShapesType shapesType, NxU32 groups, NxReal maxDist, NxGroupsMask* groupsMask, NxShape** cache)
{
    return classPointer->raycastAnyShape(*worldRay, shapesType, groups, maxDist, groupsMask, cache);
}

API_EXPORT bool NxScene_raycastAnyShape_1(NxScene* classPointer, bool call_explicit, NxRay* worldRay, NxShapesType shapesType, NxU32 groups, NxReal maxDist, NxGroupsMask* groupsMask)
{
    return classPointer->raycastAnyShape(*worldRay, shapesType, groups, maxDist, groupsMask);
}

API_EXPORT bool NxScene_raycastAnyShape_2(NxScene* classPointer, bool call_explicit, NxRay* worldRay, NxShapesType shapesType, NxU32 groups, NxReal maxDist)
{
    return classPointer->raycastAnyShape(*worldRay, shapesType, groups, maxDist);
}

API_EXPORT bool NxScene_raycastAnyShape_3(NxScene* classPointer, bool call_explicit, NxRay* worldRay, NxShapesType shapesType, NxU32 groups)
{
    return classPointer->raycastAnyShape(*worldRay, shapesType, groups);
}

API_EXPORT bool NxScene_raycastAnyShape_4(NxScene* classPointer, bool call_explicit, NxRay* worldRay, NxShapesType shapesType)
{
    return classPointer->raycastAnyShape(*worldRay, shapesType);
}

API_EXPORT NxU32 NxScene_raycastAllBounds(NxScene* classPointer, bool call_explicit, NxRay* worldRay, NxUserRaycastReport* report, NxShapesType shapesType, NxU32 groups, NxReal maxDist, NxU32 hintFlags, NxGroupsMask* groupsMask)
{
    return classPointer->raycastAllBounds(*worldRay, *report, shapesType, groups, maxDist, hintFlags, groupsMask);
}

API_EXPORT NxU32 NxScene_raycastAllBounds_1(NxScene* classPointer, bool call_explicit, NxRay* worldRay, NxUserRaycastReport* report, NxShapesType shapesType, NxU32 groups, NxReal maxDist, NxU32 hintFlags)
{
    return classPointer->raycastAllBounds(*worldRay, *report, shapesType, groups, maxDist, hintFlags);
}

API_EXPORT NxU32 NxScene_raycastAllBounds_2(NxScene* classPointer, bool call_explicit, NxRay* worldRay, NxUserRaycastReport* report, NxShapesType shapesType, NxU32 groups, NxReal maxDist)
{
    return classPointer->raycastAllBounds(*worldRay, *report, shapesType, groups, maxDist);
}

API_EXPORT NxU32 NxScene_raycastAllBounds_3(NxScene* classPointer, bool call_explicit, NxRay* worldRay, NxUserRaycastReport* report, NxShapesType shapesType, NxU32 groups)
{
    return classPointer->raycastAllBounds(*worldRay, *report, shapesType, groups);
}

API_EXPORT NxU32 NxScene_raycastAllBounds_4(NxScene* classPointer, bool call_explicit, NxRay* worldRay, NxUserRaycastReport* report, NxShapesType shapesType)
{
    return classPointer->raycastAllBounds(*worldRay, *report, shapesType);
}

API_EXPORT NxU32 NxScene_raycastAllShapes(NxScene* classPointer, bool call_explicit, NxRay* worldRay, NxUserRaycastReport* report, NxShapesType shapesType, NxU32 groups, NxReal maxDist, NxU32 hintFlags, NxGroupsMask* groupsMask)
{
    return classPointer->raycastAllShapes(*worldRay, *report, shapesType, groups, maxDist, hintFlags, groupsMask);
}

API_EXPORT NxU32 NxScene_raycastAllShapes_1(NxScene* classPointer, bool call_explicit, NxRay* worldRay, NxUserRaycastReport* report, NxShapesType shapesType, NxU32 groups, NxReal maxDist, NxU32 hintFlags)
{
    return classPointer->raycastAllShapes(*worldRay, *report, shapesType, groups, maxDist, hintFlags);
}

API_EXPORT NxU32 NxScene_raycastAllShapes_2(NxScene* classPointer, bool call_explicit, NxRay* worldRay, NxUserRaycastReport* report, NxShapesType shapesType, NxU32 groups, NxReal maxDist)
{
    return classPointer->raycastAllShapes(*worldRay, *report, shapesType, groups, maxDist);
}

API_EXPORT NxU32 NxScene_raycastAllShapes_3(NxScene* classPointer, bool call_explicit, NxRay* worldRay, NxUserRaycastReport* report, NxShapesType shapesType, NxU32 groups)
{
    return classPointer->raycastAllShapes(*worldRay, *report, shapesType, groups);
}

API_EXPORT NxU32 NxScene_raycastAllShapes_4(NxScene* classPointer, bool call_explicit, NxRay* worldRay, NxUserRaycastReport* report, NxShapesType shapesType)
{
    return classPointer->raycastAllShapes(*worldRay, *report, shapesType);
}

API_EXPORT NxShape* NxScene_raycastClosestBounds(NxScene* classPointer, bool call_explicit, NxRay* worldRay, NxShapesType shapeType, NxRaycastHit* hit, NxU32 groups, NxReal maxDist, NxU32 hintFlags, NxGroupsMask* groupsMask)
{
    return classPointer->raycastClosestBounds(*worldRay, shapeType, *hit, groups, maxDist, hintFlags, groupsMask);
}

API_EXPORT NxShape* NxScene_raycastClosestBounds_1(NxScene* classPointer, bool call_explicit, NxRay* worldRay, NxShapesType shapeType, NxRaycastHit* hit, NxU32 groups, NxReal maxDist, NxU32 hintFlags)
{
    return classPointer->raycastClosestBounds(*worldRay, shapeType, *hit, groups, maxDist, hintFlags);
}

API_EXPORT NxShape* NxScene_raycastClosestBounds_2(NxScene* classPointer, bool call_explicit, NxRay* worldRay, NxShapesType shapeType, NxRaycastHit* hit, NxU32 groups, NxReal maxDist)
{
    return classPointer->raycastClosestBounds(*worldRay, shapeType, *hit, groups, maxDist);
}

API_EXPORT NxShape* NxScene_raycastClosestBounds_3(NxScene* classPointer, bool call_explicit, NxRay* worldRay, NxShapesType shapeType, NxRaycastHit* hit, NxU32 groups)
{
    return classPointer->raycastClosestBounds(*worldRay, shapeType, *hit, groups);
}

API_EXPORT NxShape* NxScene_raycastClosestBounds_4(NxScene* classPointer, bool call_explicit, NxRay* worldRay, NxShapesType shapeType, NxRaycastHit* hit)
{
    return classPointer->raycastClosestBounds(*worldRay, shapeType, *hit);
}

API_EXPORT NxShape* NxScene_raycastClosestShape(NxScene* classPointer, bool call_explicit, NxRay* worldRay, NxShapesType shapeType, NxRaycastHit* hit, NxU32 groups, NxReal maxDist, NxU32 hintFlags, NxGroupsMask* groupsMask, NxShape** cache)
{
    return classPointer->raycastClosestShape(*worldRay, shapeType, *hit, groups, maxDist, hintFlags, groupsMask, cache);
}

API_EXPORT NxShape* NxScene_raycastClosestShape_1(NxScene* classPointer, bool call_explicit, NxRay* worldRay, NxShapesType shapeType, NxRaycastHit* hit, NxU32 groups, NxReal maxDist, NxU32 hintFlags, NxGroupsMask* groupsMask)
{
    return classPointer->raycastClosestShape(*worldRay, shapeType, *hit, groups, maxDist, hintFlags, groupsMask);
}

API_EXPORT NxShape* NxScene_raycastClosestShape_2(NxScene* classPointer, bool call_explicit, NxRay* worldRay, NxShapesType shapeType, NxRaycastHit* hit, NxU32 groups, NxReal maxDist, NxU32 hintFlags)
{
    return classPointer->raycastClosestShape(*worldRay, shapeType, *hit, groups, maxDist, hintFlags);
}

API_EXPORT NxShape* NxScene_raycastClosestShape_3(NxScene* classPointer, bool call_explicit, NxRay* worldRay, NxShapesType shapeType, NxRaycastHit* hit, NxU32 groups, NxReal maxDist)
{
    return classPointer->raycastClosestShape(*worldRay, shapeType, *hit, groups, maxDist);
}

API_EXPORT NxShape* NxScene_raycastClosestShape_4(NxScene* classPointer, bool call_explicit, NxRay* worldRay, NxShapesType shapeType, NxRaycastHit* hit, NxU32 groups)
{
    return classPointer->raycastClosestShape(*worldRay, shapeType, *hit, groups);
}

API_EXPORT NxShape* NxScene_raycastClosestShape_5(NxScene* classPointer, bool call_explicit, NxRay* worldRay, NxShapesType shapeType, NxRaycastHit* hit)
{
    return classPointer->raycastClosestShape(*worldRay, shapeType, *hit);
}

API_EXPORT NxU32 NxScene_overlapSphereShapes(NxScene* classPointer, bool call_explicit, NxSphere* worldSphere, NxShapesType shapeType, NxU32 nbShapes, NxShape** shapes, NxUserEntityReport< NxShape* >* callback, NxU32 activeGroups, NxGroupsMask* groupsMask, bool accurateCollision)
{
    return classPointer->overlapSphereShapes(*worldSphere, shapeType, nbShapes, shapes, callback, activeGroups, groupsMask, accurateCollision);
}

API_EXPORT NxU32 NxScene_overlapSphereShapes_1(NxScene* classPointer, bool call_explicit, NxSphere* worldSphere, NxShapesType shapeType, NxU32 nbShapes, NxShape** shapes, NxUserEntityReport< NxShape* >* callback, NxU32 activeGroups, NxGroupsMask* groupsMask)
{
    return classPointer->overlapSphereShapes(*worldSphere, shapeType, nbShapes, shapes, callback, activeGroups, groupsMask);
}

API_EXPORT NxU32 NxScene_overlapSphereShapes_2(NxScene* classPointer, bool call_explicit, NxSphere* worldSphere, NxShapesType shapeType, NxU32 nbShapes, NxShape** shapes, NxUserEntityReport< NxShape* >* callback, NxU32 activeGroups)
{
    return classPointer->overlapSphereShapes(*worldSphere, shapeType, nbShapes, shapes, callback, activeGroups);
}

API_EXPORT NxU32 NxScene_overlapSphereShapes_3(NxScene* classPointer, bool call_explicit, NxSphere* worldSphere, NxShapesType shapeType, NxU32 nbShapes, NxShape** shapes, NxUserEntityReport< NxShape* >* callback)
{
    return classPointer->overlapSphereShapes(*worldSphere, shapeType, nbShapes, shapes, callback);
}

API_EXPORT NxU32 NxScene_overlapAABBShapes(NxScene* classPointer, bool call_explicit, NxBounds3* worldBounds, NxShapesType shapeType, NxU32 nbShapes, NxShape** shapes, NxUserEntityReport< NxShape* >* callback, NxU32 activeGroups, NxGroupsMask* groupsMask, bool accurateCollision)
{
    return classPointer->overlapAABBShapes(*worldBounds, shapeType, nbShapes, shapes, callback, activeGroups, groupsMask, accurateCollision);
}

API_EXPORT NxU32 NxScene_overlapAABBShapes_1(NxScene* classPointer, bool call_explicit, NxBounds3* worldBounds, NxShapesType shapeType, NxU32 nbShapes, NxShape** shapes, NxUserEntityReport< NxShape* >* callback, NxU32 activeGroups, NxGroupsMask* groupsMask)
{
    return classPointer->overlapAABBShapes(*worldBounds, shapeType, nbShapes, shapes, callback, activeGroups, groupsMask);
}

API_EXPORT NxU32 NxScene_overlapAABBShapes_2(NxScene* classPointer, bool call_explicit, NxBounds3* worldBounds, NxShapesType shapeType, NxU32 nbShapes, NxShape** shapes, NxUserEntityReport< NxShape* >* callback, NxU32 activeGroups)
{
    return classPointer->overlapAABBShapes(*worldBounds, shapeType, nbShapes, shapes, callback, activeGroups);
}

API_EXPORT NxU32 NxScene_overlapAABBShapes_3(NxScene* classPointer, bool call_explicit, NxBounds3* worldBounds, NxShapesType shapeType, NxU32 nbShapes, NxShape** shapes, NxUserEntityReport< NxShape* >* callback)
{
    return classPointer->overlapAABBShapes(*worldBounds, shapeType, nbShapes, shapes, callback);
}

API_EXPORT NxU32 NxScene_overlapOBBShapes(NxScene* classPointer, bool call_explicit, NxBox* worldBox, NxShapesType shapeType, NxU32 nbShapes, NxShape** shapes, NxUserEntityReport< NxShape* >* callback, NxU32 activeGroups, NxGroupsMask* groupsMask, bool accurateCollision)
{
    return classPointer->overlapOBBShapes(*worldBox, shapeType, nbShapes, shapes, callback, activeGroups, groupsMask, accurateCollision);
}

API_EXPORT NxU32 NxScene_overlapOBBShapes_1(NxScene* classPointer, bool call_explicit, NxBox* worldBox, NxShapesType shapeType, NxU32 nbShapes, NxShape** shapes, NxUserEntityReport< NxShape* >* callback, NxU32 activeGroups, NxGroupsMask* groupsMask)
{
    return classPointer->overlapOBBShapes(*worldBox, shapeType, nbShapes, shapes, callback, activeGroups, groupsMask);
}

API_EXPORT NxU32 NxScene_overlapOBBShapes_2(NxScene* classPointer, bool call_explicit, NxBox* worldBox, NxShapesType shapeType, NxU32 nbShapes, NxShape** shapes, NxUserEntityReport< NxShape* >* callback, NxU32 activeGroups)
{
    return classPointer->overlapOBBShapes(*worldBox, shapeType, nbShapes, shapes, callback, activeGroups);
}

API_EXPORT NxU32 NxScene_overlapOBBShapes_3(NxScene* classPointer, bool call_explicit, NxBox* worldBox, NxShapesType shapeType, NxU32 nbShapes, NxShape** shapes, NxUserEntityReport< NxShape* >* callback)
{
    return classPointer->overlapOBBShapes(*worldBox, shapeType, nbShapes, shapes, callback);
}

API_EXPORT NxU32 NxScene_overlapCapsuleShapes(NxScene* classPointer, bool call_explicit, NxCapsule* worldCapsule, NxShapesType shapeType, NxU32 nbShapes, NxShape** shapes, NxUserEntityReport< NxShape* >* callback, NxU32 activeGroups, NxGroupsMask* groupsMask, bool accurateCollision)
{
    return classPointer->overlapCapsuleShapes(*worldCapsule, shapeType, nbShapes, shapes, callback, activeGroups, groupsMask, accurateCollision);
}

API_EXPORT NxU32 NxScene_overlapCapsuleShapes_1(NxScene* classPointer, bool call_explicit, NxCapsule* worldCapsule, NxShapesType shapeType, NxU32 nbShapes, NxShape** shapes, NxUserEntityReport< NxShape* >* callback, NxU32 activeGroups, NxGroupsMask* groupsMask)
{
    return classPointer->overlapCapsuleShapes(*worldCapsule, shapeType, nbShapes, shapes, callback, activeGroups, groupsMask);
}

API_EXPORT NxU32 NxScene_overlapCapsuleShapes_2(NxScene* classPointer, bool call_explicit, NxCapsule* worldCapsule, NxShapesType shapeType, NxU32 nbShapes, NxShape** shapes, NxUserEntityReport< NxShape* >* callback, NxU32 activeGroups)
{
    return classPointer->overlapCapsuleShapes(*worldCapsule, shapeType, nbShapes, shapes, callback, activeGroups);
}

API_EXPORT NxU32 NxScene_overlapCapsuleShapes_3(NxScene* classPointer, bool call_explicit, NxCapsule* worldCapsule, NxShapesType shapeType, NxU32 nbShapes, NxShape** shapes, NxUserEntityReport< NxShape* >* callback)
{
    return classPointer->overlapCapsuleShapes(*worldCapsule, shapeType, nbShapes, shapes, callback);
}

API_EXPORT NxSweepCache* NxScene_createSweepCache(NxScene* classPointer, bool call_explicit)
{
    return classPointer->createSweepCache();
}

API_EXPORT void NxScene_releaseSweepCache(NxScene* classPointer, bool call_explicit, NxSweepCache* cache)
{
    classPointer->releaseSweepCache(cache);
}

API_EXPORT NxU32 NxScene_linearOBBSweep(NxScene* classPointer, bool call_explicit, NxBox* worldBox, NxVec3& motion, NxU32 flags, void* userData, NxU32 nbShapes, NxSweepQueryHit* shapes, NxUserEntityReport< NxSweepQueryHit >* callback, NxU32 activeGroups, NxGroupsMask* groupsMask)
{
    return classPointer->linearOBBSweep(*worldBox, motion, flags, userData, nbShapes, shapes, callback, activeGroups, groupsMask);
}

API_EXPORT NxU32 NxScene_linearOBBSweep_1(NxScene* classPointer, bool call_explicit, NxBox* worldBox, NxVec3& motion, NxU32 flags, void* userData, NxU32 nbShapes, NxSweepQueryHit* shapes, NxUserEntityReport< NxSweepQueryHit >* callback, NxU32 activeGroups)
{
    return classPointer->linearOBBSweep(*worldBox, motion, flags, userData, nbShapes, shapes, callback, activeGroups);
}

API_EXPORT NxU32 NxScene_linearOBBSweep_2(NxScene* classPointer, bool call_explicit, NxBox* worldBox, NxVec3& motion, NxU32 flags, void* userData, NxU32 nbShapes, NxSweepQueryHit* shapes, NxUserEntityReport< NxSweepQueryHit >* callback)
{
    return classPointer->linearOBBSweep(*worldBox, motion, flags, userData, nbShapes, shapes, callback);
}

API_EXPORT NxU32 NxScene_linearCapsuleSweep(NxScene* classPointer, bool call_explicit, NxCapsule* worldCapsule, NxVec3& motion, NxU32 flags, void* userData, NxU32 nbShapes, NxSweepQueryHit* shapes, NxUserEntityReport< NxSweepQueryHit >* callback, NxU32 activeGroups, NxGroupsMask* groupsMask)
{
    return classPointer->linearCapsuleSweep(*worldCapsule, motion, flags, userData, nbShapes, shapes, callback, activeGroups, groupsMask);
}

API_EXPORT NxU32 NxScene_linearCapsuleSweep_1(NxScene* classPointer, bool call_explicit, NxCapsule* worldCapsule, NxVec3& motion, NxU32 flags, void* userData, NxU32 nbShapes, NxSweepQueryHit* shapes, NxUserEntityReport< NxSweepQueryHit >* callback, NxU32 activeGroups)
{
    return classPointer->linearCapsuleSweep(*worldCapsule, motion, flags, userData, nbShapes, shapes, callback, activeGroups);
}

API_EXPORT NxU32 NxScene_linearCapsuleSweep_2(NxScene* classPointer, bool call_explicit, NxCapsule* worldCapsule, NxVec3& motion, NxU32 flags, void* userData, NxU32 nbShapes, NxSweepQueryHit* shapes, NxUserEntityReport< NxSweepQueryHit >* callback)
{
    return classPointer->linearCapsuleSweep(*worldCapsule, motion, flags, userData, nbShapes, shapes, callback);
}

API_EXPORT NxU32 NxScene_cullShapes(NxScene* classPointer, bool call_explicit, NxU32 nbPlanes, NxPlane* worldPlanes, NxShapesType shapeType, NxU32 nbShapes, NxShape** shapes, NxUserEntityReport< NxShape* >* callback, NxU32 activeGroups, NxGroupsMask* groupsMask)
{
    return classPointer->cullShapes(nbPlanes, worldPlanes, shapeType, nbShapes, shapes, callback, activeGroups, groupsMask);
}

API_EXPORT NxU32 NxScene_cullShapes_1(NxScene* classPointer, bool call_explicit, NxU32 nbPlanes, NxPlane* worldPlanes, NxShapesType shapeType, NxU32 nbShapes, NxShape** shapes, NxUserEntityReport< NxShape* >* callback, NxU32 activeGroups)
{
    return classPointer->cullShapes(nbPlanes, worldPlanes, shapeType, nbShapes, shapes, callback, activeGroups);
}

API_EXPORT NxU32 NxScene_cullShapes_2(NxScene* classPointer, bool call_explicit, NxU32 nbPlanes, NxPlane* worldPlanes, NxShapesType shapeType, NxU32 nbShapes, NxShape** shapes, NxUserEntityReport< NxShape* >* callback)
{
    return classPointer->cullShapes(nbPlanes, worldPlanes, shapeType, nbShapes, shapes, callback);
}

API_EXPORT bool NxScene_checkOverlapSphere(NxScene* classPointer, bool call_explicit, NxSphere* worldSphere, NxShapesType shapeType, NxU32 activeGroups, NxGroupsMask* groupsMask)
{
    return classPointer->checkOverlapSphere(*worldSphere, shapeType, activeGroups, groupsMask);
}

API_EXPORT bool NxScene_checkOverlapSphere_1(NxScene* classPointer, bool call_explicit, NxSphere* worldSphere, NxShapesType shapeType, NxU32 activeGroups)
{
    return classPointer->checkOverlapSphere(*worldSphere, shapeType, activeGroups);
}

API_EXPORT bool NxScene_checkOverlapSphere_2(NxScene* classPointer, bool call_explicit, NxSphere* worldSphere, NxShapesType shapeType)
{
    return classPointer->checkOverlapSphere(*worldSphere, shapeType);
}

API_EXPORT bool NxScene_checkOverlapSphere_3(NxScene* classPointer, bool call_explicit, NxSphere* worldSphere)
{
    return classPointer->checkOverlapSphere(*worldSphere);
}

API_EXPORT bool NxScene_checkOverlapAABB(NxScene* classPointer, bool call_explicit, NxBounds3* worldBounds, NxShapesType shapeType, NxU32 activeGroups, NxGroupsMask* groupsMask)
{
    return classPointer->checkOverlapAABB(*worldBounds, shapeType, activeGroups, groupsMask);
}

API_EXPORT bool NxScene_checkOverlapAABB_1(NxScene* classPointer, bool call_explicit, NxBounds3* worldBounds, NxShapesType shapeType, NxU32 activeGroups)
{
    return classPointer->checkOverlapAABB(*worldBounds, shapeType, activeGroups);
}

API_EXPORT bool NxScene_checkOverlapAABB_2(NxScene* classPointer, bool call_explicit, NxBounds3* worldBounds, NxShapesType shapeType)
{
    return classPointer->checkOverlapAABB(*worldBounds, shapeType);
}

API_EXPORT bool NxScene_checkOverlapAABB_3(NxScene* classPointer, bool call_explicit, NxBounds3* worldBounds)
{
    return classPointer->checkOverlapAABB(*worldBounds);
}

API_EXPORT bool NxScene_checkOverlapOBB(NxScene* classPointer, bool call_explicit, NxBox* worldBox, NxShapesType shapeType, NxU32 activeGroups, NxGroupsMask* groupsMask)
{
    return classPointer->checkOverlapOBB(*worldBox, shapeType, activeGroups, groupsMask);
}

API_EXPORT bool NxScene_checkOverlapOBB_1(NxScene* classPointer, bool call_explicit, NxBox* worldBox, NxShapesType shapeType, NxU32 activeGroups)
{
    return classPointer->checkOverlapOBB(*worldBox, shapeType, activeGroups);
}

API_EXPORT bool NxScene_checkOverlapOBB_2(NxScene* classPointer, bool call_explicit, NxBox* worldBox, NxShapesType shapeType)
{
    return classPointer->checkOverlapOBB(*worldBox, shapeType);
}

API_EXPORT bool NxScene_checkOverlapOBB_3(NxScene* classPointer, bool call_explicit, NxBox* worldBox)
{
    return classPointer->checkOverlapOBB(*worldBox);
}

API_EXPORT bool NxScene_checkOverlapCapsule(NxScene* classPointer, bool call_explicit, NxCapsule* worldCapsule, NxShapesType shapeType, NxU32 activeGroups, NxGroupsMask* groupsMask)
{
    return classPointer->checkOverlapCapsule(*worldCapsule, shapeType, activeGroups, groupsMask);
}

API_EXPORT bool NxScene_checkOverlapCapsule_1(NxScene* classPointer, bool call_explicit, NxCapsule* worldCapsule, NxShapesType shapeType, NxU32 activeGroups)
{
    return classPointer->checkOverlapCapsule(*worldCapsule, shapeType, activeGroups);
}

API_EXPORT bool NxScene_checkOverlapCapsule_2(NxScene* classPointer, bool call_explicit, NxCapsule* worldCapsule, NxShapesType shapeType)
{
    return classPointer->checkOverlapCapsule(*worldCapsule, shapeType);
}

API_EXPORT bool NxScene_checkOverlapCapsule_3(NxScene* classPointer, bool call_explicit, NxCapsule* worldCapsule)
{
    return classPointer->checkOverlapCapsule(*worldCapsule);
}

API_EXPORT NxFluid* NxScene_createFluid(NxScene* classPointer, bool call_explicit, NxFluidDescBase* fluidDesc)
{
    return classPointer->createFluid(*fluidDesc);
}

API_EXPORT void NxScene_releaseFluid(NxScene* classPointer, bool call_explicit, NxFluid* fluid)
{
    classPointer->releaseFluid(*fluid);
}

API_EXPORT NxU32 NxScene_getNbFluids(NxScene* classPointer, bool call_explicit)
{
    return classPointer->getNbFluids();
}

API_EXPORT NxFluid** NxScene_getFluids(NxScene* classPointer, bool call_explicit)
{
    return classPointer->getFluids();
}

API_EXPORT bool NxScene_cookFluidMeshHotspot(NxScene* classPointer, bool call_explicit, NxBounds3* bounds, NxU32 packetSizeMultiplier, NxReal restParticlesPerMeter, NxReal kernelRadiusMultiplier, NxReal motionLimitMultiplier, NxReal collisionDistanceMultiplier, NxCompartment* compartment, bool forceStrictCookingFormat)
{
    return classPointer->cookFluidMeshHotspot(*bounds, packetSizeMultiplier, restParticlesPerMeter, kernelRadiusMultiplier, motionLimitMultiplier, collisionDistanceMultiplier, compartment, forceStrictCookingFormat);
}

API_EXPORT bool NxScene_cookFluidMeshHotspot_1(NxScene* classPointer, bool call_explicit, NxBounds3* bounds, NxU32 packetSizeMultiplier, NxReal restParticlesPerMeter, NxReal kernelRadiusMultiplier, NxReal motionLimitMultiplier, NxReal collisionDistanceMultiplier, NxCompartment* compartment)
{
    return classPointer->cookFluidMeshHotspot(*bounds, packetSizeMultiplier, restParticlesPerMeter, kernelRadiusMultiplier, motionLimitMultiplier, collisionDistanceMultiplier, compartment);
}

API_EXPORT bool NxScene_cookFluidMeshHotspot_2(NxScene* classPointer, bool call_explicit, NxBounds3* bounds, NxU32 packetSizeMultiplier, NxReal restParticlesPerMeter, NxReal kernelRadiusMultiplier, NxReal motionLimitMultiplier, NxReal collisionDistanceMultiplier)
{
    return classPointer->cookFluidMeshHotspot(*bounds, packetSizeMultiplier, restParticlesPerMeter, kernelRadiusMultiplier, motionLimitMultiplier, collisionDistanceMultiplier);
}

API_EXPORT NxCloth* NxScene_createCloth(NxScene* classPointer, bool call_explicit, NxClothDesc* clothDesc)
{
    return classPointer->createCloth(*clothDesc);
}

API_EXPORT void NxScene_releaseCloth(NxScene* classPointer, bool call_explicit, NxCloth* cloth)
{
    classPointer->releaseCloth(*cloth);
}

API_EXPORT NxU32 NxScene_getNbCloths(NxScene* classPointer, bool call_explicit)
{
    return classPointer->getNbCloths();
}

API_EXPORT NxCloth** NxScene_getCloths(NxScene* classPointer, bool call_explicit)
{
    return classPointer->getCloths();
}

API_EXPORT NxSoftBody* NxScene_createSoftBody(NxScene* classPointer, bool call_explicit, NxSoftBodyDesc* softBodyDesc)
{
    return classPointer->createSoftBody(*softBodyDesc);
}

API_EXPORT void NxScene_releaseSoftBody(NxScene* classPointer, bool call_explicit, NxSoftBody* softBody)
{
    classPointer->releaseSoftBody(*softBody);
}

API_EXPORT NxU32 NxScene_getNbSoftBodies(NxScene* classPointer, bool call_explicit)
{
    return classPointer->getNbSoftBodies();
}

API_EXPORT NxSoftBody** NxScene_getSoftBodies(NxScene* classPointer, bool call_explicit)
{
    return classPointer->getSoftBodies();
}

API_EXPORT void set_NxScene_userData(NxScene* classPointer, void* newvalue)
{
    classPointer->userData = newvalue;
}

API_EXPORT void* get_NxScene_userData(NxScene* classPointer)
{
    return classPointer->userData;
}

API_EXPORT void set_NxScene_extLink(NxScene* classPointer, void* newvalue)
{
    classPointer->extLink = newvalue;
}

API_EXPORT void* get_NxScene_extLink(NxScene* classPointer)
{
    return classPointer->extLink;
}

API_EXPORT NxScene* new_NxScene(bool do_override)
{
    return (do_override) ? new NxScene_doxybind() : NULL;
}

API_EXPORT bool NxScene_saveToDesc(NxScene* classPointer, bool call_explicit, NxSceneDesc* desc)
{
    return classPointer->saveToDesc(*desc);
}

API_EXPORT NxU32 NxScene_getFlags(NxScene* classPointer, bool call_explicit)
{
    return classPointer->getFlags();
}

API_EXPORT NxSimulationType NxScene_getSimType(NxScene* classPointer, bool call_explicit)
{
    return classPointer->getSimType();
}

API_EXPORT void* NxScene_getInternal(NxScene* classPointer, bool call_explicit)
{
    return classPointer->getInternal();
}

API_EXPORT void NxScene_setGravity(NxScene* classPointer, bool call_explicit, NxVec3& vec)
{
    classPointer->setGravity(vec);
}

API_EXPORT void NxScene_getGravity(NxScene* classPointer, bool call_explicit, NxVec3& vec)
{
    classPointer->getGravity(vec);
}

API_EXPORT void NxScene_flushStream(NxScene* classPointer, bool call_explicit)
{
    classPointer->flushStream();
}

API_EXPORT void NxScene_setTiming(NxScene* classPointer, bool call_explicit, NxReal maxTimestep, NxU32 maxIter, NxTimeStepMethod method)
{
    classPointer->setTiming(maxTimestep, maxIter, method);
}

API_EXPORT void NxScene_setTiming_1(NxScene* classPointer, bool call_explicit, NxReal maxTimestep, NxU32 maxIter)
{
    classPointer->setTiming(maxTimestep, maxIter);
}

API_EXPORT void NxScene_setTiming_2(NxScene* classPointer, bool call_explicit, NxReal maxTimestep)
{
    classPointer->setTiming(maxTimestep);
}

API_EXPORT void NxScene_getTiming(NxScene* classPointer, bool call_explicit, NxReal& maxTimestep, NxU32& maxIter, NxTimeStepMethod& method, NxU32* numSubSteps)
{
    classPointer->getTiming(maxTimestep, maxIter, method, numSubSteps);
}

API_EXPORT void NxScene_getTiming_1(NxScene* classPointer, bool call_explicit, NxReal& maxTimestep, NxU32& maxIter, NxTimeStepMethod& method)
{
    classPointer->getTiming(maxTimestep, maxIter, method);
}

API_EXPORT const NxDebugRenderable* NxScene_getDebugRenderable(NxScene* classPointer, bool call_explicit)
{
    return classPointer->getDebugRenderable();
}

API_EXPORT NxPhysicsSDK* NxScene_getPhysicsSDK(NxScene* classPointer, bool call_explicit)
{
    return &classPointer->getPhysicsSDK();
}

API_EXPORT void NxScene_getStats(NxScene* classPointer, bool call_explicit, NxSceneStats* stats)
{
    classPointer->getStats(*stats);
}

API_EXPORT const NxSceneStats2* NxScene_getStats2(NxScene* classPointer, bool call_explicit)
{
    return classPointer->getStats2();
}

API_EXPORT void NxScene_getLimits(NxScene* classPointer, bool call_explicit, NxSceneLimits* limits)
{
    classPointer->getLimits(*limits);
}

API_EXPORT void NxScene_setMaxCPUForLoadBalancing(NxScene* classPointer, bool call_explicit, NxReal cpuFraction)
{
    classPointer->setMaxCPUForLoadBalancing(cpuFraction);
}

API_EXPORT NxReal NxScene_getMaxCPUForLoadBalancing(NxScene* classPointer, bool call_explicit)
{
    return classPointer->getMaxCPUForLoadBalancing();
}

API_EXPORT bool NxScene_isWritable(NxScene* classPointer, bool call_explicit)
{
    return classPointer->isWritable();
}

API_EXPORT void NxScene_simulate(NxScene* classPointer, bool call_explicit, NxReal elapsedTime)
{
    classPointer->simulate(elapsedTime);
}

API_EXPORT bool NxScene_checkResults(NxScene* classPointer, bool call_explicit, NxSimulationStatus status, bool block)
{
    return classPointer->checkResults(status, block);
}

API_EXPORT bool NxScene_checkResults_1(NxScene* classPointer, bool call_explicit, NxSimulationStatus status)
{
    return classPointer->checkResults(status);
}

API_EXPORT bool NxScene_fetchResults(NxScene* classPointer, bool call_explicit, NxSimulationStatus status, bool block, NxU32* errorState)
{
    return classPointer->fetchResults(status, block, errorState);
}

API_EXPORT bool NxScene_fetchResults_1(NxScene* classPointer, bool call_explicit, NxSimulationStatus status, bool block)
{
    return classPointer->fetchResults(status, block);
}

API_EXPORT bool NxScene_fetchResults_2(NxScene* classPointer, bool call_explicit, NxSimulationStatus status)
{
    return classPointer->fetchResults(status);
}

API_EXPORT void NxScene_flushCaches(NxScene* classPointer, bool call_explicit)
{
    classPointer->flushCaches();
}

API_EXPORT const NxProfileData* NxScene_readProfileData(NxScene* classPointer, bool call_explicit, bool clearData)
{
    return classPointer->readProfileData(clearData);
}

API_EXPORT NxThreadPollResult NxScene_pollForWork(NxScene* classPointer, bool call_explicit, NxThreadWait waitType)
{
    return classPointer->pollForWork(waitType);
}

API_EXPORT void NxScene_resetPollForWork(NxScene* classPointer, bool call_explicit)
{
    classPointer->resetPollForWork();
}

API_EXPORT NxThreadPollResult NxScene_pollForBackgroundWork(NxScene* classPointer, bool call_explicit, NxThreadWait waitType)
{
    return classPointer->pollForBackgroundWork(waitType);
}

API_EXPORT void NxScene_shutdownWorkerThreads(NxScene* classPointer, bool call_explicit)
{
    classPointer->shutdownWorkerThreads();
}

API_EXPORT void NxScene_lockQueries(NxScene* classPointer, bool call_explicit)
{
    classPointer->lockQueries();
}

API_EXPORT void NxScene_unlockQueries(NxScene* classPointer, bool call_explicit)
{
    classPointer->unlockQueries();
}

API_EXPORT NxSceneQuery* NxScene_createSceneQuery(NxScene* classPointer, bool call_explicit, NxSceneQueryDesc* desc)
{
    return classPointer->createSceneQuery(*desc);
}

API_EXPORT bool NxScene_releaseSceneQuery(NxScene* classPointer, bool call_explicit, NxSceneQuery* query)
{
    return classPointer->releaseSceneQuery(*query);
}

API_EXPORT void NxScene_setDynamicTreeRebuildRateHint(NxScene* classPointer, bool call_explicit, NxU32 dynamicTreeRebuildRateHint)
{
    classPointer->setDynamicTreeRebuildRateHint(dynamicTreeRebuildRateHint);
}

API_EXPORT NxU32 NxScene_getDynamicTreeRebuildRateHint(NxScene* classPointer, bool call_explicit)
{
    return classPointer->getDynamicTreeRebuildRateHint();
}

API_EXPORT void NxScene_setSolverBatchSize(NxScene* classPointer, bool call_explicit, NxU32 solverBatchSize)
{
    classPointer->setSolverBatchSize(solverBatchSize);
}

API_EXPORT NxU32 NxScene_getSolverBatchSize(NxScene* classPointer, bool call_explicit)
{
    return classPointer->getSolverBatchSize();
}

API_EXPORT void set_NxSceneDesc_gravity(NxSceneDesc* classPointer, NxVec3 newvalue)
{
    classPointer->gravity = newvalue;
}

API_EXPORT NxVec3 get_NxSceneDesc_gravity(NxSceneDesc* classPointer)
{
    return classPointer->gravity;
}

API_EXPORT void set_NxSceneDesc_userNotify(NxSceneDesc* classPointer, NxUserNotify* newvalue)
{
    classPointer->userNotify = newvalue;
}

API_EXPORT NxUserNotify* get_NxSceneDesc_userNotify(NxSceneDesc* classPointer)
{
    return classPointer->userNotify;
}

API_EXPORT void set_NxSceneDesc_fluidUserNotify(NxSceneDesc* classPointer, NxFluidUserNotify* newvalue)
{
    classPointer->fluidUserNotify = newvalue;
}

API_EXPORT NxFluidUserNotify* get_NxSceneDesc_fluidUserNotify(NxSceneDesc* classPointer)
{
    return classPointer->fluidUserNotify;
}

API_EXPORT void set_NxSceneDesc_clothUserNotify(NxSceneDesc* classPointer, NxClothUserNotify* newvalue)
{
    classPointer->clothUserNotify = newvalue;
}

API_EXPORT NxClothUserNotify* get_NxSceneDesc_clothUserNotify(NxSceneDesc* classPointer)
{
    return classPointer->clothUserNotify;
}

API_EXPORT void set_NxSceneDesc_softBodyUserNotify(NxSceneDesc* classPointer, NxSoftBodyUserNotify* newvalue)
{
    classPointer->softBodyUserNotify = newvalue;
}

API_EXPORT NxSoftBodyUserNotify* get_NxSceneDesc_softBodyUserNotify(NxSceneDesc* classPointer)
{
    return classPointer->softBodyUserNotify;
}

API_EXPORT void set_NxSceneDesc_userContactModify(NxSceneDesc* classPointer, NxUserContactModify* newvalue)
{
    classPointer->userContactModify = newvalue;
}

API_EXPORT NxUserContactModify* get_NxSceneDesc_userContactModify(NxSceneDesc* classPointer)
{
    return classPointer->userContactModify;
}

API_EXPORT void set_NxSceneDesc_userTriggerReport(NxSceneDesc* classPointer, NxUserTriggerReport* newvalue)
{
    classPointer->userTriggerReport = newvalue;
}

API_EXPORT NxUserTriggerReport* get_NxSceneDesc_userTriggerReport(NxSceneDesc* classPointer)
{
    return classPointer->userTriggerReport;
}

API_EXPORT void set_NxSceneDesc_userContactReport(NxSceneDesc* classPointer, NxUserContactReport* newvalue)
{
    classPointer->userContactReport = newvalue;
}

API_EXPORT NxUserContactReport* get_NxSceneDesc_userContactReport(NxSceneDesc* classPointer)
{
    return classPointer->userContactReport;
}

API_EXPORT void set_NxSceneDesc_userActorPairFiltering(NxSceneDesc* classPointer, NxUserActorPairFiltering* newvalue)
{
    classPointer->userActorPairFiltering = newvalue;
}

API_EXPORT NxUserActorPairFiltering* get_NxSceneDesc_userActorPairFiltering(NxSceneDesc* classPointer)
{
    return classPointer->userActorPairFiltering;
}

API_EXPORT void set_NxSceneDesc_maxTimestep(NxSceneDesc* classPointer, NxReal newvalue)
{
    classPointer->maxTimestep = newvalue;
}

API_EXPORT NxReal get_NxSceneDesc_maxTimestep(NxSceneDesc* classPointer)
{
    return classPointer->maxTimestep;
}

API_EXPORT void set_NxSceneDesc_maxIter(NxSceneDesc* classPointer, NxU32 newvalue)
{
    classPointer->maxIter = newvalue;
}

API_EXPORT NxU32 get_NxSceneDesc_maxIter(NxSceneDesc* classPointer)
{
    return classPointer->maxIter;
}

API_EXPORT void set_NxSceneDesc_timeStepMethod(NxSceneDesc* classPointer, NxTimeStepMethod newvalue)
{
    classPointer->timeStepMethod = newvalue;
}

API_EXPORT NxTimeStepMethod get_NxSceneDesc_timeStepMethod(NxSceneDesc* classPointer)
{
    return classPointer->timeStepMethod;
}

API_EXPORT void set_NxSceneDesc_maxBounds(NxSceneDesc* classPointer, NxBounds3* newvalue)
{
    classPointer->maxBounds = newvalue;
}

API_EXPORT NxBounds3* get_NxSceneDesc_maxBounds(NxSceneDesc* classPointer)
{
    return classPointer->maxBounds;
}

API_EXPORT void set_NxSceneDesc_limits(NxSceneDesc* classPointer, NxSceneLimits* newvalue)
{
    classPointer->limits = newvalue;
}

API_EXPORT NxSceneLimits* get_NxSceneDesc_limits(NxSceneDesc* classPointer)
{
    return classPointer->limits;
}

API_EXPORT void set_NxSceneDesc_simType(NxSceneDesc* classPointer, NxSimulationType newvalue)
{
    classPointer->simType = newvalue;
}

API_EXPORT NxSimulationType get_NxSceneDesc_simType(NxSceneDesc* classPointer)
{
    return classPointer->simType;
}

API_EXPORT void set_NxSceneDesc_groundPlane(NxSceneDesc* classPointer, NX_BOOL newvalue)
{
    classPointer->groundPlane = newvalue;
}

API_EXPORT NX_BOOL get_NxSceneDesc_groundPlane(NxSceneDesc* classPointer)
{
    return classPointer->groundPlane;
}

API_EXPORT void set_NxSceneDesc_boundsPlanes(NxSceneDesc* classPointer, NX_BOOL newvalue)
{
    classPointer->boundsPlanes = newvalue;
}

API_EXPORT NX_BOOL get_NxSceneDesc_boundsPlanes(NxSceneDesc* classPointer)
{
    return classPointer->boundsPlanes;
}

API_EXPORT void set_NxSceneDesc_flags(NxSceneDesc* classPointer, NxU32 newvalue)
{
    classPointer->flags = newvalue;
}

API_EXPORT NxU32 get_NxSceneDesc_flags(NxSceneDesc* classPointer)
{
    return classPointer->flags;
}

API_EXPORT void set_NxSceneDesc_customScheduler(NxSceneDesc* classPointer, NxUserScheduler* newvalue)
{
    classPointer->customScheduler = newvalue;
}

API_EXPORT NxUserScheduler* get_NxSceneDesc_customScheduler(NxSceneDesc* classPointer)
{
    return classPointer->customScheduler;
}

API_EXPORT void set_NxSceneDesc_simThreadStackSize(NxSceneDesc* classPointer, NxU32 newvalue)
{
    classPointer->simThreadStackSize = newvalue;
}

API_EXPORT NxU32 get_NxSceneDesc_simThreadStackSize(NxSceneDesc* classPointer)
{
    return classPointer->simThreadStackSize;
}

API_EXPORT void set_NxSceneDesc_simThreadPriority(NxSceneDesc* classPointer, NxThreadPriority newvalue)
{
    classPointer->simThreadPriority = newvalue;
}

API_EXPORT NxThreadPriority get_NxSceneDesc_simThreadPriority(NxSceneDesc* classPointer)
{
    return classPointer->simThreadPriority;
}

API_EXPORT void set_NxSceneDesc_simThreadMask(NxSceneDesc* classPointer, NxU32 newvalue)
{
    classPointer->simThreadMask = newvalue;
}

API_EXPORT NxU32 get_NxSceneDesc_simThreadMask(NxSceneDesc* classPointer)
{
    return classPointer->simThreadMask;
}

API_EXPORT void set_NxSceneDesc_internalThreadCount(NxSceneDesc* classPointer, NxU32 newvalue)
{
    classPointer->internalThreadCount = newvalue;
}

API_EXPORT NxU32 get_NxSceneDesc_internalThreadCount(NxSceneDesc* classPointer)
{
    return classPointer->internalThreadCount;
}

API_EXPORT void set_NxSceneDesc_workerThreadStackSize(NxSceneDesc* classPointer, NxU32 newvalue)
{
    classPointer->workerThreadStackSize = newvalue;
}

API_EXPORT NxU32 get_NxSceneDesc_workerThreadStackSize(NxSceneDesc* classPointer)
{
    return classPointer->workerThreadStackSize;
}

API_EXPORT void set_NxSceneDesc_workerThreadPriority(NxSceneDesc* classPointer, NxThreadPriority newvalue)
{
    classPointer->workerThreadPriority = newvalue;
}

API_EXPORT NxThreadPriority get_NxSceneDesc_workerThreadPriority(NxSceneDesc* classPointer)
{
    return classPointer->workerThreadPriority;
}

API_EXPORT void set_NxSceneDesc_threadMask(NxSceneDesc* classPointer, NxU32 newvalue)
{
    classPointer->threadMask = newvalue;
}

API_EXPORT NxU32 get_NxSceneDesc_threadMask(NxSceneDesc* classPointer)
{
    return classPointer->threadMask;
}

API_EXPORT void set_NxSceneDesc_backgroundThreadCount(NxSceneDesc* classPointer, NxU32 newvalue)
{
    classPointer->backgroundThreadCount = newvalue;
}

API_EXPORT NxU32 get_NxSceneDesc_backgroundThreadCount(NxSceneDesc* classPointer)
{
    return classPointer->backgroundThreadCount;
}

API_EXPORT void set_NxSceneDesc_backgroundThreadPriority(NxSceneDesc* classPointer, NxThreadPriority newvalue)
{
    classPointer->backgroundThreadPriority = newvalue;
}

API_EXPORT NxThreadPriority get_NxSceneDesc_backgroundThreadPriority(NxSceneDesc* classPointer)
{
    return classPointer->backgroundThreadPriority;
}

API_EXPORT void set_NxSceneDesc_backgroundThreadMask(NxSceneDesc* classPointer, NxU32 newvalue)
{
    classPointer->backgroundThreadMask = newvalue;
}

API_EXPORT NxU32 get_NxSceneDesc_backgroundThreadMask(NxSceneDesc* classPointer)
{
    return classPointer->backgroundThreadMask;
}

API_EXPORT void set_NxSceneDesc_upAxis(NxSceneDesc* classPointer, NxU32 newvalue)
{
    classPointer->upAxis = newvalue;
}

API_EXPORT NxU32 get_NxSceneDesc_upAxis(NxSceneDesc* classPointer)
{
    return classPointer->upAxis;
}

API_EXPORT void set_NxSceneDesc_subdivisionLevel(NxSceneDesc* classPointer, NxU32 newvalue)
{
    classPointer->subdivisionLevel = newvalue;
}

API_EXPORT NxU32 get_NxSceneDesc_subdivisionLevel(NxSceneDesc* classPointer)
{
    return classPointer->subdivisionLevel;
}

API_EXPORT void set_NxSceneDesc_staticStructure(NxSceneDesc* classPointer, NxPruningStructure newvalue)
{
    classPointer->staticStructure = newvalue;
}

API_EXPORT NxPruningStructure get_NxSceneDesc_staticStructure(NxSceneDesc* classPointer)
{
    return classPointer->staticStructure;
}

API_EXPORT void set_NxSceneDesc_dynamicStructure(NxSceneDesc* classPointer, NxPruningStructure newvalue)
{
    classPointer->dynamicStructure = newvalue;
}

API_EXPORT NxPruningStructure get_NxSceneDesc_dynamicStructure(NxSceneDesc* classPointer)
{
    return classPointer->dynamicStructure;
}

API_EXPORT void set_NxSceneDesc_dynamicTreeRebuildRateHint(NxSceneDesc* classPointer, NxU32 newvalue)
{
    classPointer->dynamicTreeRebuildRateHint = newvalue;
}

API_EXPORT NxU32 get_NxSceneDesc_dynamicTreeRebuildRateHint(NxSceneDesc* classPointer)
{
    return classPointer->dynamicTreeRebuildRateHint;
}

API_EXPORT void set_NxSceneDesc_userData(NxSceneDesc* classPointer, void* newvalue)
{
    classPointer->userData = newvalue;
}

API_EXPORT void* get_NxSceneDesc_userData(NxSceneDesc* classPointer)
{
    return classPointer->userData;
}

API_EXPORT void set_NxSceneDesc_bpType(NxSceneDesc* classPointer, NxBroadPhaseType newvalue)
{
    classPointer->bpType = newvalue;
}

API_EXPORT NxBroadPhaseType get_NxSceneDesc_bpType(NxSceneDesc* classPointer)
{
    return classPointer->bpType;
}

API_EXPORT void set_NxSceneDesc_nbGridCellsX(NxSceneDesc* classPointer, NxU32 newvalue)
{
    classPointer->nbGridCellsX = newvalue;
}

API_EXPORT NxU32 get_NxSceneDesc_nbGridCellsX(NxSceneDesc* classPointer)
{
    return classPointer->nbGridCellsX;
}

API_EXPORT void set_NxSceneDesc_nbGridCellsY(NxSceneDesc* classPointer, NxU32 newvalue)
{
    classPointer->nbGridCellsY = newvalue;
}

API_EXPORT NxU32 get_NxSceneDesc_nbGridCellsY(NxSceneDesc* classPointer)
{
    return classPointer->nbGridCellsY;
}

API_EXPORT void set_NxSceneDesc_solverBatchSize(NxSceneDesc* classPointer, NxU32 newvalue)
{
    classPointer->solverBatchSize = newvalue;
}

API_EXPORT NxU32 get_NxSceneDesc_solverBatchSize(NxSceneDesc* classPointer)
{
    return classPointer->solverBatchSize;
}

API_EXPORT NxSceneDesc* new_NxSceneDesc(bool do_override)
{
    return new NxSceneDesc();
}

API_EXPORT void NxSceneDesc_setToDefault(NxSceneDesc* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxSceneDesc::setToDefault() : classPointer->setToDefault();
}

API_EXPORT bool NxSceneDesc_isValid(NxSceneDesc* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxSceneDesc::isValid() : classPointer->isValid();
}

API_EXPORT void set_NxSceneLimits_maxNbActors(NxSceneLimits* classPointer, NxU32 newvalue)
{
    classPointer->maxNbActors = newvalue;
}

API_EXPORT NxU32 get_NxSceneLimits_maxNbActors(NxSceneLimits* classPointer)
{
    return classPointer->maxNbActors;
}

API_EXPORT void set_NxSceneLimits_maxNbBodies(NxSceneLimits* classPointer, NxU32 newvalue)
{
    classPointer->maxNbBodies = newvalue;
}

API_EXPORT NxU32 get_NxSceneLimits_maxNbBodies(NxSceneLimits* classPointer)
{
    return classPointer->maxNbBodies;
}

API_EXPORT void set_NxSceneLimits_maxNbStaticShapes(NxSceneLimits* classPointer, NxU32 newvalue)
{
    classPointer->maxNbStaticShapes = newvalue;
}

API_EXPORT NxU32 get_NxSceneLimits_maxNbStaticShapes(NxSceneLimits* classPointer)
{
    return classPointer->maxNbStaticShapes;
}

API_EXPORT void set_NxSceneLimits_maxNbDynamicShapes(NxSceneLimits* classPointer, NxU32 newvalue)
{
    classPointer->maxNbDynamicShapes = newvalue;
}

API_EXPORT NxU32 get_NxSceneLimits_maxNbDynamicShapes(NxSceneLimits* classPointer)
{
    return classPointer->maxNbDynamicShapes;
}

API_EXPORT void set_NxSceneLimits_maxNbJoints(NxSceneLimits* classPointer, NxU32 newvalue)
{
    classPointer->maxNbJoints = newvalue;
}

API_EXPORT NxU32 get_NxSceneLimits_maxNbJoints(NxSceneLimits* classPointer)
{
    return classPointer->maxNbJoints;
}

API_EXPORT NxSceneLimits* new_NxSceneLimits(bool do_override)
{
    return new NxSceneLimits();
}

API_EXPORT NxSceneQueryReport* NxSceneQuery_getQueryReport(NxSceneQuery* classPointer, bool call_explicit)
{
    return classPointer->getQueryReport();
}

API_EXPORT NxSceneQueryExecuteMode NxSceneQuery_getExecuteMode(NxSceneQuery* classPointer, bool call_explicit)
{
    return classPointer->getExecuteMode();
}

API_EXPORT void NxSceneQuery_execute(NxSceneQuery* classPointer, bool call_explicit)
{
    classPointer->execute();
}

API_EXPORT bool NxSceneQuery_finish(NxSceneQuery* classPointer, bool call_explicit, bool block)
{
    return classPointer->finish(block);
}

API_EXPORT bool NxSceneQuery_raycastAnyShape(NxSceneQuery* classPointer, bool call_explicit, NxRay* worldRay, NxShapesType shapesType, NxU32 groups, NxReal maxDist, NxGroupsMask* groupsMask, NxShape** cache, void* userData)
{
    return classPointer->raycastAnyShape(*worldRay, shapesType, groups, maxDist, groupsMask, cache, userData);
}

API_EXPORT bool NxSceneQuery_raycastAnyShape_1(NxSceneQuery* classPointer, bool call_explicit, NxRay* worldRay, NxShapesType shapesType, NxU32 groups, NxReal maxDist, NxGroupsMask* groupsMask, NxShape** cache)
{
    return classPointer->raycastAnyShape(*worldRay, shapesType, groups, maxDist, groupsMask, cache);
}

API_EXPORT bool NxSceneQuery_raycastAnyShape_2(NxSceneQuery* classPointer, bool call_explicit, NxRay* worldRay, NxShapesType shapesType, NxU32 groups, NxReal maxDist, NxGroupsMask* groupsMask)
{
    return classPointer->raycastAnyShape(*worldRay, shapesType, groups, maxDist, groupsMask);
}

API_EXPORT bool NxSceneQuery_raycastAnyShape_3(NxSceneQuery* classPointer, bool call_explicit, NxRay* worldRay, NxShapesType shapesType, NxU32 groups, NxReal maxDist)
{
    return classPointer->raycastAnyShape(*worldRay, shapesType, groups, maxDist);
}

API_EXPORT bool NxSceneQuery_raycastAnyShape_4(NxSceneQuery* classPointer, bool call_explicit, NxRay* worldRay, NxShapesType shapesType, NxU32 groups)
{
    return classPointer->raycastAnyShape(*worldRay, shapesType, groups);
}

API_EXPORT bool NxSceneQuery_raycastAnyShape_5(NxSceneQuery* classPointer, bool call_explicit, NxRay* worldRay, NxShapesType shapesType)
{
    return classPointer->raycastAnyShape(*worldRay, shapesType);
}

API_EXPORT bool NxSceneQuery_checkOverlapSphere(NxSceneQuery* classPointer, bool call_explicit, NxSphere* worldSphere, NxShapesType shapesType, NxU32 activeGroups, NxGroupsMask* groupsMask, void* userData)
{
    return classPointer->checkOverlapSphere(*worldSphere, shapesType, activeGroups, groupsMask, userData);
}

API_EXPORT bool NxSceneQuery_checkOverlapSphere_1(NxSceneQuery* classPointer, bool call_explicit, NxSphere* worldSphere, NxShapesType shapesType, NxU32 activeGroups, NxGroupsMask* groupsMask)
{
    return classPointer->checkOverlapSphere(*worldSphere, shapesType, activeGroups, groupsMask);
}

API_EXPORT bool NxSceneQuery_checkOverlapSphere_2(NxSceneQuery* classPointer, bool call_explicit, NxSphere* worldSphere, NxShapesType shapesType, NxU32 activeGroups)
{
    return classPointer->checkOverlapSphere(*worldSphere, shapesType, activeGroups);
}

API_EXPORT bool NxSceneQuery_checkOverlapSphere_3(NxSceneQuery* classPointer, bool call_explicit, NxSphere* worldSphere, NxShapesType shapesType)
{
    return classPointer->checkOverlapSphere(*worldSphere, shapesType);
}

API_EXPORT bool NxSceneQuery_checkOverlapSphere_4(NxSceneQuery* classPointer, bool call_explicit, NxSphere* worldSphere)
{
    return classPointer->checkOverlapSphere(*worldSphere);
}

API_EXPORT bool NxSceneQuery_checkOverlapAABB(NxSceneQuery* classPointer, bool call_explicit, NxBounds3* worldBounds, NxShapesType shapesType, NxU32 activeGroups, NxGroupsMask* groupsMask, void* userData)
{
    return classPointer->checkOverlapAABB(*worldBounds, shapesType, activeGroups, groupsMask, userData);
}

API_EXPORT bool NxSceneQuery_checkOverlapAABB_1(NxSceneQuery* classPointer, bool call_explicit, NxBounds3* worldBounds, NxShapesType shapesType, NxU32 activeGroups, NxGroupsMask* groupsMask)
{
    return classPointer->checkOverlapAABB(*worldBounds, shapesType, activeGroups, groupsMask);
}

API_EXPORT bool NxSceneQuery_checkOverlapAABB_2(NxSceneQuery* classPointer, bool call_explicit, NxBounds3* worldBounds, NxShapesType shapesType, NxU32 activeGroups)
{
    return classPointer->checkOverlapAABB(*worldBounds, shapesType, activeGroups);
}

API_EXPORT bool NxSceneQuery_checkOverlapAABB_3(NxSceneQuery* classPointer, bool call_explicit, NxBounds3* worldBounds, NxShapesType shapesType)
{
    return classPointer->checkOverlapAABB(*worldBounds, shapesType);
}

API_EXPORT bool NxSceneQuery_checkOverlapAABB_4(NxSceneQuery* classPointer, bool call_explicit, NxBounds3* worldBounds)
{
    return classPointer->checkOverlapAABB(*worldBounds);
}

API_EXPORT bool NxSceneQuery_checkOverlapOBB(NxSceneQuery* classPointer, bool call_explicit, NxBox* worldBox, NxShapesType shapesType, NxU32 activeGroups, NxGroupsMask* groupsMask, void* userData)
{
    return classPointer->checkOverlapOBB(*worldBox, shapesType, activeGroups, groupsMask, userData);
}

API_EXPORT bool NxSceneQuery_checkOverlapOBB_1(NxSceneQuery* classPointer, bool call_explicit, NxBox* worldBox, NxShapesType shapesType, NxU32 activeGroups, NxGroupsMask* groupsMask)
{
    return classPointer->checkOverlapOBB(*worldBox, shapesType, activeGroups, groupsMask);
}

API_EXPORT bool NxSceneQuery_checkOverlapOBB_2(NxSceneQuery* classPointer, bool call_explicit, NxBox* worldBox, NxShapesType shapesType, NxU32 activeGroups)
{
    return classPointer->checkOverlapOBB(*worldBox, shapesType, activeGroups);
}

API_EXPORT bool NxSceneQuery_checkOverlapOBB_3(NxSceneQuery* classPointer, bool call_explicit, NxBox* worldBox, NxShapesType shapesType)
{
    return classPointer->checkOverlapOBB(*worldBox, shapesType);
}

API_EXPORT bool NxSceneQuery_checkOverlapOBB_4(NxSceneQuery* classPointer, bool call_explicit, NxBox* worldBox)
{
    return classPointer->checkOverlapOBB(*worldBox);
}

API_EXPORT bool NxSceneQuery_checkOverlapCapsule(NxSceneQuery* classPointer, bool call_explicit, NxCapsule* worldCapsule, NxShapesType shapesType, NxU32 activeGroups, NxGroupsMask* groupsMask, void* userData)
{
    return classPointer->checkOverlapCapsule(*worldCapsule, shapesType, activeGroups, groupsMask, userData);
}

API_EXPORT bool NxSceneQuery_checkOverlapCapsule_1(NxSceneQuery* classPointer, bool call_explicit, NxCapsule* worldCapsule, NxShapesType shapesType, NxU32 activeGroups, NxGroupsMask* groupsMask)
{
    return classPointer->checkOverlapCapsule(*worldCapsule, shapesType, activeGroups, groupsMask);
}

API_EXPORT bool NxSceneQuery_checkOverlapCapsule_2(NxSceneQuery* classPointer, bool call_explicit, NxCapsule* worldCapsule, NxShapesType shapesType, NxU32 activeGroups)
{
    return classPointer->checkOverlapCapsule(*worldCapsule, shapesType, activeGroups);
}

API_EXPORT bool NxSceneQuery_checkOverlapCapsule_3(NxSceneQuery* classPointer, bool call_explicit, NxCapsule* worldCapsule, NxShapesType shapesType)
{
    return classPointer->checkOverlapCapsule(*worldCapsule, shapesType);
}

API_EXPORT bool NxSceneQuery_checkOverlapCapsule_4(NxSceneQuery* classPointer, bool call_explicit, NxCapsule* worldCapsule)
{
    return classPointer->checkOverlapCapsule(*worldCapsule);
}

API_EXPORT NxShape* NxSceneQuery_raycastClosestShape(NxSceneQuery* classPointer, bool call_explicit, NxRay* worldRay, NxShapesType shapesType, NxRaycastHit* hit, NxU32 groups, NxReal maxDist, NxU32 hintFlags, NxGroupsMask* groupsMask, NxShape** cache, void* userData)
{
    return classPointer->raycastClosestShape(*worldRay, shapesType, *hit, groups, maxDist, hintFlags, groupsMask, cache, userData);
}

API_EXPORT NxShape* NxSceneQuery_raycastClosestShape_1(NxSceneQuery* classPointer, bool call_explicit, NxRay* worldRay, NxShapesType shapesType, NxRaycastHit* hit, NxU32 groups, NxReal maxDist, NxU32 hintFlags, NxGroupsMask* groupsMask, NxShape** cache)
{
    return classPointer->raycastClosestShape(*worldRay, shapesType, *hit, groups, maxDist, hintFlags, groupsMask, cache);
}

API_EXPORT NxShape* NxSceneQuery_raycastClosestShape_2(NxSceneQuery* classPointer, bool call_explicit, NxRay* worldRay, NxShapesType shapesType, NxRaycastHit* hit, NxU32 groups, NxReal maxDist, NxU32 hintFlags, NxGroupsMask* groupsMask)
{
    return classPointer->raycastClosestShape(*worldRay, shapesType, *hit, groups, maxDist, hintFlags, groupsMask);
}

API_EXPORT NxShape* NxSceneQuery_raycastClosestShape_3(NxSceneQuery* classPointer, bool call_explicit, NxRay* worldRay, NxShapesType shapesType, NxRaycastHit* hit, NxU32 groups, NxReal maxDist, NxU32 hintFlags)
{
    return classPointer->raycastClosestShape(*worldRay, shapesType, *hit, groups, maxDist, hintFlags);
}

API_EXPORT NxShape* NxSceneQuery_raycastClosestShape_4(NxSceneQuery* classPointer, bool call_explicit, NxRay* worldRay, NxShapesType shapesType, NxRaycastHit* hit, NxU32 groups, NxReal maxDist)
{
    return classPointer->raycastClosestShape(*worldRay, shapesType, *hit, groups, maxDist);
}

API_EXPORT NxShape* NxSceneQuery_raycastClosestShape_5(NxSceneQuery* classPointer, bool call_explicit, NxRay* worldRay, NxShapesType shapesType, NxRaycastHit* hit, NxU32 groups)
{
    return classPointer->raycastClosestShape(*worldRay, shapesType, *hit, groups);
}

API_EXPORT NxShape* NxSceneQuery_raycastClosestShape_6(NxSceneQuery* classPointer, bool call_explicit, NxRay* worldRay, NxShapesType shapesType, NxRaycastHit* hit)
{
    return classPointer->raycastClosestShape(*worldRay, shapesType, *hit);
}

API_EXPORT NxU32 NxSceneQuery_raycastAllShapes(NxSceneQuery* classPointer, bool call_explicit, NxRay* worldRay, NxShapesType shapesType, NxU32 groups, NxReal maxDist, NxU32 hintFlags, NxGroupsMask* groupsMask, void* userData)
{
    return classPointer->raycastAllShapes(*worldRay, shapesType, groups, maxDist, hintFlags, groupsMask, userData);
}

API_EXPORT NxU32 NxSceneQuery_raycastAllShapes_1(NxSceneQuery* classPointer, bool call_explicit, NxRay* worldRay, NxShapesType shapesType, NxU32 groups, NxReal maxDist, NxU32 hintFlags, NxGroupsMask* groupsMask)
{
    return classPointer->raycastAllShapes(*worldRay, shapesType, groups, maxDist, hintFlags, groupsMask);
}

API_EXPORT NxU32 NxSceneQuery_raycastAllShapes_2(NxSceneQuery* classPointer, bool call_explicit, NxRay* worldRay, NxShapesType shapesType, NxU32 groups, NxReal maxDist, NxU32 hintFlags)
{
    return classPointer->raycastAllShapes(*worldRay, shapesType, groups, maxDist, hintFlags);
}

API_EXPORT NxU32 NxSceneQuery_raycastAllShapes_3(NxSceneQuery* classPointer, bool call_explicit, NxRay* worldRay, NxShapesType shapesType, NxU32 groups, NxReal maxDist)
{
    return classPointer->raycastAllShapes(*worldRay, shapesType, groups, maxDist);
}

API_EXPORT NxU32 NxSceneQuery_raycastAllShapes_4(NxSceneQuery* classPointer, bool call_explicit, NxRay* worldRay, NxShapesType shapesType, NxU32 groups)
{
    return classPointer->raycastAllShapes(*worldRay, shapesType, groups);
}

API_EXPORT NxU32 NxSceneQuery_raycastAllShapes_5(NxSceneQuery* classPointer, bool call_explicit, NxRay* worldRay, NxShapesType shapesType)
{
    return classPointer->raycastAllShapes(*worldRay, shapesType);
}

API_EXPORT NxU32 NxSceneQuery_overlapSphereShapes(NxSceneQuery* classPointer, bool call_explicit, NxSphere* worldSphere, NxShapesType shapesType, NxU32 activeGroups, NxGroupsMask* groupsMask, void* userData)
{
    return classPointer->overlapSphereShapes(*worldSphere, shapesType, activeGroups, groupsMask, userData);
}

API_EXPORT NxU32 NxSceneQuery_overlapSphereShapes_1(NxSceneQuery* classPointer, bool call_explicit, NxSphere* worldSphere, NxShapesType shapesType, NxU32 activeGroups, NxGroupsMask* groupsMask)
{
    return classPointer->overlapSphereShapes(*worldSphere, shapesType, activeGroups, groupsMask);
}

API_EXPORT NxU32 NxSceneQuery_overlapSphereShapes_2(NxSceneQuery* classPointer, bool call_explicit, NxSphere* worldSphere, NxShapesType shapesType, NxU32 activeGroups)
{
    return classPointer->overlapSphereShapes(*worldSphere, shapesType, activeGroups);
}

API_EXPORT NxU32 NxSceneQuery_overlapSphereShapes_3(NxSceneQuery* classPointer, bool call_explicit, NxSphere* worldSphere, NxShapesType shapesType)
{
    return classPointer->overlapSphereShapes(*worldSphere, shapesType);
}

API_EXPORT NxU32 NxSceneQuery_overlapAABBShapes(NxSceneQuery* classPointer, bool call_explicit, NxBounds3* worldBounds, NxShapesType shapesType, NxU32 activeGroups, NxGroupsMask* groupsMask, void* userData)
{
    return classPointer->overlapAABBShapes(*worldBounds, shapesType, activeGroups, groupsMask, userData);
}

API_EXPORT NxU32 NxSceneQuery_overlapAABBShapes_1(NxSceneQuery* classPointer, bool call_explicit, NxBounds3* worldBounds, NxShapesType shapesType, NxU32 activeGroups, NxGroupsMask* groupsMask)
{
    return classPointer->overlapAABBShapes(*worldBounds, shapesType, activeGroups, groupsMask);
}

API_EXPORT NxU32 NxSceneQuery_overlapAABBShapes_2(NxSceneQuery* classPointer, bool call_explicit, NxBounds3* worldBounds, NxShapesType shapesType, NxU32 activeGroups)
{
    return classPointer->overlapAABBShapes(*worldBounds, shapesType, activeGroups);
}

API_EXPORT NxU32 NxSceneQuery_overlapAABBShapes_3(NxSceneQuery* classPointer, bool call_explicit, NxBounds3* worldBounds, NxShapesType shapesType)
{
    return classPointer->overlapAABBShapes(*worldBounds, shapesType);
}

API_EXPORT NxU32 NxSceneQuery_overlapOBBShapes(NxSceneQuery* classPointer, bool call_explicit, NxBox* worldBox, NxShapesType shapesType, NxU32 activeGroups, NxGroupsMask* groupsMask, void* userData)
{
    return classPointer->overlapOBBShapes(*worldBox, shapesType, activeGroups, groupsMask, userData);
}

API_EXPORT NxU32 NxSceneQuery_overlapOBBShapes_1(NxSceneQuery* classPointer, bool call_explicit, NxBox* worldBox, NxShapesType shapesType, NxU32 activeGroups, NxGroupsMask* groupsMask)
{
    return classPointer->overlapOBBShapes(*worldBox, shapesType, activeGroups, groupsMask);
}

API_EXPORT NxU32 NxSceneQuery_overlapOBBShapes_2(NxSceneQuery* classPointer, bool call_explicit, NxBox* worldBox, NxShapesType shapesType, NxU32 activeGroups)
{
    return classPointer->overlapOBBShapes(*worldBox, shapesType, activeGroups);
}

API_EXPORT NxU32 NxSceneQuery_overlapOBBShapes_3(NxSceneQuery* classPointer, bool call_explicit, NxBox* worldBox, NxShapesType shapesType)
{
    return classPointer->overlapOBBShapes(*worldBox, shapesType);
}

API_EXPORT NxU32 NxSceneQuery_overlapCapsuleShapes(NxSceneQuery* classPointer, bool call_explicit, NxCapsule* worldCapsule, NxShapesType shapesType, NxU32 activeGroups, NxGroupsMask* groupsMask, void* userData)
{
    return classPointer->overlapCapsuleShapes(*worldCapsule, shapesType, activeGroups, groupsMask, userData);
}

API_EXPORT NxU32 NxSceneQuery_overlapCapsuleShapes_1(NxSceneQuery* classPointer, bool call_explicit, NxCapsule* worldCapsule, NxShapesType shapesType, NxU32 activeGroups, NxGroupsMask* groupsMask)
{
    return classPointer->overlapCapsuleShapes(*worldCapsule, shapesType, activeGroups, groupsMask);
}

API_EXPORT NxU32 NxSceneQuery_overlapCapsuleShapes_2(NxSceneQuery* classPointer, bool call_explicit, NxCapsule* worldCapsule, NxShapesType shapesType, NxU32 activeGroups)
{
    return classPointer->overlapCapsuleShapes(*worldCapsule, shapesType, activeGroups);
}

API_EXPORT NxU32 NxSceneQuery_overlapCapsuleShapes_3(NxSceneQuery* classPointer, bool call_explicit, NxCapsule* worldCapsule, NxShapesType shapesType)
{
    return classPointer->overlapCapsuleShapes(*worldCapsule, shapesType);
}

API_EXPORT NxU32 NxSceneQuery_cullShapes(NxSceneQuery* classPointer, bool call_explicit, NxU32 nbPlanes, NxPlane* worldPlanes, NxShapesType shapesType, NxU32 activeGroups, NxGroupsMask* groupsMask, void* userData)
{
    return classPointer->cullShapes(nbPlanes, worldPlanes, shapesType, activeGroups, groupsMask, userData);
}

API_EXPORT NxU32 NxSceneQuery_cullShapes_1(NxSceneQuery* classPointer, bool call_explicit, NxU32 nbPlanes, NxPlane* worldPlanes, NxShapesType shapesType, NxU32 activeGroups, NxGroupsMask* groupsMask)
{
    return classPointer->cullShapes(nbPlanes, worldPlanes, shapesType, activeGroups, groupsMask);
}

API_EXPORT NxU32 NxSceneQuery_cullShapes_2(NxSceneQuery* classPointer, bool call_explicit, NxU32 nbPlanes, NxPlane* worldPlanes, NxShapesType shapesType, NxU32 activeGroups)
{
    return classPointer->cullShapes(nbPlanes, worldPlanes, shapesType, activeGroups);
}

API_EXPORT NxU32 NxSceneQuery_cullShapes_3(NxSceneQuery* classPointer, bool call_explicit, NxU32 nbPlanes, NxPlane* worldPlanes, NxShapesType shapesType)
{
    return classPointer->cullShapes(nbPlanes, worldPlanes, shapesType);
}

API_EXPORT NxU32 NxSceneQuery_linearOBBSweep(NxSceneQuery* classPointer, bool call_explicit, NxBox* worldBox, NxVec3& motion, NxU32 flags, NxU32 activeGroups, NxGroupsMask* groupsMask, void* userData)
{
    return classPointer->linearOBBSweep(*worldBox, motion, flags, activeGroups, groupsMask, userData);
}

API_EXPORT NxU32 NxSceneQuery_linearOBBSweep_1(NxSceneQuery* classPointer, bool call_explicit, NxBox* worldBox, NxVec3& motion, NxU32 flags, NxU32 activeGroups, NxGroupsMask* groupsMask)
{
    return classPointer->linearOBBSweep(*worldBox, motion, flags, activeGroups, groupsMask);
}

API_EXPORT NxU32 NxSceneQuery_linearOBBSweep_2(NxSceneQuery* classPointer, bool call_explicit, NxBox* worldBox, NxVec3& motion, NxU32 flags, NxU32 activeGroups)
{
    return classPointer->linearOBBSweep(*worldBox, motion, flags, activeGroups);
}

API_EXPORT NxU32 NxSceneQuery_linearOBBSweep_3(NxSceneQuery* classPointer, bool call_explicit, NxBox* worldBox, NxVec3& motion, NxU32 flags)
{
    return classPointer->linearOBBSweep(*worldBox, motion, flags);
}

API_EXPORT NxU32 NxSceneQuery_linearCapsuleSweep(NxSceneQuery* classPointer, bool call_explicit, NxCapsule* worldCapsule, NxVec3& motion, NxU32 flags, NxU32 activeGroups, NxGroupsMask* groupsMask, void* userData)
{
    return classPointer->linearCapsuleSweep(*worldCapsule, motion, flags, activeGroups, groupsMask, userData);
}

API_EXPORT NxU32 NxSceneQuery_linearCapsuleSweep_1(NxSceneQuery* classPointer, bool call_explicit, NxCapsule* worldCapsule, NxVec3& motion, NxU32 flags, NxU32 activeGroups, NxGroupsMask* groupsMask)
{
    return classPointer->linearCapsuleSweep(*worldCapsule, motion, flags, activeGroups, groupsMask);
}

API_EXPORT NxU32 NxSceneQuery_linearCapsuleSweep_2(NxSceneQuery* classPointer, bool call_explicit, NxCapsule* worldCapsule, NxVec3& motion, NxU32 flags, NxU32 activeGroups)
{
    return classPointer->linearCapsuleSweep(*worldCapsule, motion, flags, activeGroups);
}

API_EXPORT NxU32 NxSceneQuery_linearCapsuleSweep_3(NxSceneQuery* classPointer, bool call_explicit, NxCapsule* worldCapsule, NxVec3& motion, NxU32 flags)
{
    return classPointer->linearCapsuleSweep(*worldCapsule, motion, flags);
}

API_EXPORT void set_NxSceneQueryDesc_report(NxSceneQueryDesc* classPointer, NxSceneQueryReport* newvalue)
{
    classPointer->report = newvalue;
}

API_EXPORT NxSceneQueryReport* get_NxSceneQueryDesc_report(NxSceneQueryDesc* classPointer)
{
    return classPointer->report;
}

API_EXPORT void set_NxSceneQueryDesc_executeMode(NxSceneQueryDesc* classPointer, NxSceneQueryExecuteMode newvalue)
{
    classPointer->executeMode = newvalue;
}

API_EXPORT NxSceneQueryExecuteMode get_NxSceneQueryDesc_executeMode(NxSceneQueryDesc* classPointer)
{
    return classPointer->executeMode;
}

API_EXPORT NxSceneQueryDesc* new_NxSceneQueryDesc(bool do_override)
{
    return new NxSceneQueryDesc();
}

API_EXPORT void NxSceneQueryDesc_setToDefault(NxSceneQueryDesc* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxSceneQueryDesc::setToDefault() : classPointer->setToDefault();
}

API_EXPORT bool NxSceneQueryDesc_isValid(NxSceneQueryDesc* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxSceneQueryDesc::isValid() : classPointer->isValid();
}

API_EXPORT NxQueryReportResult NxSceneQueryReport_onBooleanQuery(NxSceneQueryReport* classPointer, bool call_explicit, void* userData, bool result)
{
    return classPointer->onBooleanQuery(userData, result);
}

API_EXPORT NxQueryReportResult NxSceneQueryReport_onRaycastQuery(NxSceneQueryReport* classPointer, bool call_explicit, void* userData, NxU32 nbHits, NxRaycastHit* hits)
{
    return classPointer->onRaycastQuery(userData, nbHits, hits);
}

API_EXPORT NxQueryReportResult NxSceneQueryReport_onShapeQuery(NxSceneQueryReport* classPointer, bool call_explicit, void* userData, NxU32 nbHits, NxShape** hits)
{
    return classPointer->onShapeQuery(userData, nbHits, hits);
}

API_EXPORT NxQueryReportResult NxSceneQueryReport_onSweepQuery(NxSceneQueryReport* classPointer, bool call_explicit, void* userData, NxU32 nbHits, NxSweepQueryHit* hits)
{
    return classPointer->onSweepQuery(userData, nbHits, hits);
}

API_EXPORT void set_NxSceneStatistic_curValue(NxSceneStatistic* classPointer, NxI32 newvalue)
{
    classPointer->curValue = newvalue;
}

API_EXPORT NxI32 get_NxSceneStatistic_curValue(NxSceneStatistic* classPointer)
{
    return classPointer->curValue;
}

API_EXPORT void set_NxSceneStatistic_maxValue(NxSceneStatistic* classPointer, NxI32 newvalue)
{
    classPointer->maxValue = newvalue;
}

API_EXPORT NxI32 get_NxSceneStatistic_maxValue(NxSceneStatistic* classPointer)
{
    return classPointer->maxValue;
}

API_EXPORT void set_NxSceneStatistic_name(NxSceneStatistic* classPointer, const char* newvalue)
{
    classPointer->name = newvalue;
}

API_EXPORT const char* get_NxSceneStatistic_name(NxSceneStatistic* classPointer)
{
    return classPointer->name;
}

API_EXPORT void set_NxSceneStatistic_parent(NxSceneStatistic* classPointer, NxU32 newvalue)
{
    classPointer->parent = newvalue;
}

API_EXPORT NxU32 get_NxSceneStatistic_parent(NxSceneStatistic* classPointer)
{
    return classPointer->parent;
}

API_EXPORT void set_NxSceneStats_numContacts(NxSceneStats* classPointer, NxU32 newvalue)
{
    classPointer->numContacts = newvalue;
}

API_EXPORT NxU32 get_NxSceneStats_numContacts(NxSceneStats* classPointer)
{
    return classPointer->numContacts;
}

API_EXPORT void set_NxSceneStats_maxContacts(NxSceneStats* classPointer, NxU32 newvalue)
{
    classPointer->maxContacts = newvalue;
}

API_EXPORT NxU32 get_NxSceneStats_maxContacts(NxSceneStats* classPointer)
{
    return classPointer->maxContacts;
}

API_EXPORT void set_NxSceneStats_numPairs(NxSceneStats* classPointer, NxU32 newvalue)
{
    classPointer->numPairs = newvalue;
}

API_EXPORT NxU32 get_NxSceneStats_numPairs(NxSceneStats* classPointer)
{
    return classPointer->numPairs;
}

API_EXPORT void set_NxSceneStats_maxPairs(NxSceneStats* classPointer, NxU32 newvalue)
{
    classPointer->maxPairs = newvalue;
}

API_EXPORT NxU32 get_NxSceneStats_maxPairs(NxSceneStats* classPointer)
{
    return classPointer->maxPairs;
}

API_EXPORT void set_NxSceneStats_numDynamicActorsInAwakeGroups(NxSceneStats* classPointer, NxU32 newvalue)
{
    classPointer->numDynamicActorsInAwakeGroups = newvalue;
}

API_EXPORT NxU32 get_NxSceneStats_numDynamicActorsInAwakeGroups(NxSceneStats* classPointer)
{
    return classPointer->numDynamicActorsInAwakeGroups;
}

API_EXPORT void set_NxSceneStats_maxDynamicActorsInAwakeGroups(NxSceneStats* classPointer, NxU32 newvalue)
{
    classPointer->maxDynamicActorsInAwakeGroups = newvalue;
}

API_EXPORT NxU32 get_NxSceneStats_maxDynamicActorsInAwakeGroups(NxSceneStats* classPointer)
{
    return classPointer->maxDynamicActorsInAwakeGroups;
}

API_EXPORT void set_NxSceneStats_numAxisConstraints(NxSceneStats* classPointer, NxU32 newvalue)
{
    classPointer->numAxisConstraints = newvalue;
}

API_EXPORT NxU32 get_NxSceneStats_numAxisConstraints(NxSceneStats* classPointer)
{
    return classPointer->numAxisConstraints;
}

API_EXPORT void set_NxSceneStats_maxAxisConstraints(NxSceneStats* classPointer, NxU32 newvalue)
{
    classPointer->maxAxisConstraints = newvalue;
}

API_EXPORT NxU32 get_NxSceneStats_maxAxisConstraints(NxSceneStats* classPointer)
{
    return classPointer->maxAxisConstraints;
}

API_EXPORT void set_NxSceneStats_numSolverBodies(NxSceneStats* classPointer, NxU32 newvalue)
{
    classPointer->numSolverBodies = newvalue;
}

API_EXPORT NxU32 get_NxSceneStats_numSolverBodies(NxSceneStats* classPointer)
{
    return classPointer->numSolverBodies;
}

API_EXPORT void set_NxSceneStats_maxSolverBodies(NxSceneStats* classPointer, NxU32 newvalue)
{
    classPointer->maxSolverBodies = newvalue;
}

API_EXPORT NxU32 get_NxSceneStats_maxSolverBodies(NxSceneStats* classPointer)
{
    return classPointer->maxSolverBodies;
}

API_EXPORT void set_NxSceneStats_numActors(NxSceneStats* classPointer, NxU32 newvalue)
{
    classPointer->numActors = newvalue;
}

API_EXPORT NxU32 get_NxSceneStats_numActors(NxSceneStats* classPointer)
{
    return classPointer->numActors;
}

API_EXPORT void set_NxSceneStats_maxActors(NxSceneStats* classPointer, NxU32 newvalue)
{
    classPointer->maxActors = newvalue;
}

API_EXPORT NxU32 get_NxSceneStats_maxActors(NxSceneStats* classPointer)
{
    return classPointer->maxActors;
}

API_EXPORT void set_NxSceneStats_numDynamicActors(NxSceneStats* classPointer, NxU32 newvalue)
{
    classPointer->numDynamicActors = newvalue;
}

API_EXPORT NxU32 get_NxSceneStats_numDynamicActors(NxSceneStats* classPointer)
{
    return classPointer->numDynamicActors;
}

API_EXPORT void set_NxSceneStats_maxDynamicActors(NxSceneStats* classPointer, NxU32 newvalue)
{
    classPointer->maxDynamicActors = newvalue;
}

API_EXPORT NxU32 get_NxSceneStats_maxDynamicActors(NxSceneStats* classPointer)
{
    return classPointer->maxDynamicActors;
}

API_EXPORT void set_NxSceneStats_numStaticShapes(NxSceneStats* classPointer, NxU32 newvalue)
{
    classPointer->numStaticShapes = newvalue;
}

API_EXPORT NxU32 get_NxSceneStats_numStaticShapes(NxSceneStats* classPointer)
{
    return classPointer->numStaticShapes;
}

API_EXPORT void set_NxSceneStats_maxStaticShapes(NxSceneStats* classPointer, NxU32 newvalue)
{
    classPointer->maxStaticShapes = newvalue;
}

API_EXPORT NxU32 get_NxSceneStats_maxStaticShapes(NxSceneStats* classPointer)
{
    return classPointer->maxStaticShapes;
}

API_EXPORT void set_NxSceneStats_numDynamicShapes(NxSceneStats* classPointer, NxU32 newvalue)
{
    classPointer->numDynamicShapes = newvalue;
}

API_EXPORT NxU32 get_NxSceneStats_numDynamicShapes(NxSceneStats* classPointer)
{
    return classPointer->numDynamicShapes;
}

API_EXPORT void set_NxSceneStats_maxDynamicShapes(NxSceneStats* classPointer, NxU32 newvalue)
{
    classPointer->maxDynamicShapes = newvalue;
}

API_EXPORT NxU32 get_NxSceneStats_maxDynamicShapes(NxSceneStats* classPointer)
{
    return classPointer->maxDynamicShapes;
}

API_EXPORT void set_NxSceneStats_numJoints(NxSceneStats* classPointer, NxU32 newvalue)
{
    classPointer->numJoints = newvalue;
}

API_EXPORT NxU32 get_NxSceneStats_numJoints(NxSceneStats* classPointer)
{
    return classPointer->numJoints;
}

API_EXPORT void set_NxSceneStats_maxJoints(NxSceneStats* classPointer, NxU32 newvalue)
{
    classPointer->maxJoints = newvalue;
}

API_EXPORT NxU32 get_NxSceneStats_maxJoints(NxSceneStats* classPointer)
{
    return classPointer->maxJoints;
}

API_EXPORT NxSceneStats* new_NxSceneStats(bool do_override)
{
    return new NxSceneStats();
}

API_EXPORT void NxSceneStats_reset(NxSceneStats* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxSceneStats::reset() : classPointer->reset();
}

API_EXPORT void set_NxSceneStats2_numStats(NxSceneStats2* classPointer, NxU32 newvalue)
{
    classPointer->numStats = newvalue;
}

API_EXPORT NxU32 get_NxSceneStats2_numStats(NxSceneStats2* classPointer)
{
    return classPointer->numStats;
}

API_EXPORT void set_NxSceneStats2_stats(NxSceneStats2* classPointer, NxSceneStatistic* newvalue)
{
    classPointer->stats = newvalue;
}

API_EXPORT NxSceneStatistic* get_NxSceneStats2_stats(NxSceneStats2* classPointer)
{
    return classPointer->stats;
}

API_EXPORT void set_NxSoftBody_userData(NxSoftBody* classPointer, void* newvalue)
{
    classPointer->userData = newvalue;
}

API_EXPORT void* get_NxSoftBody_userData(NxSoftBody* classPointer)
{
    return classPointer->userData;
}

API_EXPORT NxSoftBody* new_NxSoftBody(bool do_override)
{
    return (do_override) ? new NxSoftBody_doxybind() : NULL;
}

API_EXPORT bool NxSoftBody_saveToDesc(NxSoftBody* classPointer, bool call_explicit, NxSoftBodyDesc* desc)
{
    return classPointer->saveToDesc(*desc);
}

API_EXPORT NxSoftBodyMesh* NxSoftBody_getSoftBodyMesh(NxSoftBody* classPointer, bool call_explicit)
{
    return classPointer->getSoftBodyMesh();
}

API_EXPORT void NxSoftBody_setVolumeStiffness(NxSoftBody* classPointer, bool call_explicit, NxReal stiffness)
{
    classPointer->setVolumeStiffness(stiffness);
}

API_EXPORT NxReal NxSoftBody_getVolumeStiffness(NxSoftBody* classPointer, bool call_explicit)
{
    return classPointer->getVolumeStiffness();
}

API_EXPORT void NxSoftBody_setStretchingStiffness(NxSoftBody* classPointer, bool call_explicit, NxReal stiffness)
{
    classPointer->setStretchingStiffness(stiffness);
}

API_EXPORT NxReal NxSoftBody_getStretchingStiffness(NxSoftBody* classPointer, bool call_explicit)
{
    return classPointer->getStretchingStiffness();
}

API_EXPORT void NxSoftBody_setDampingCoefficient(NxSoftBody* classPointer, bool call_explicit, NxReal dampingCoefficient)
{
    classPointer->setDampingCoefficient(dampingCoefficient);
}

API_EXPORT NxReal NxSoftBody_getDampingCoefficient(NxSoftBody* classPointer, bool call_explicit)
{
    return classPointer->getDampingCoefficient();
}

API_EXPORT void NxSoftBody_setFriction(NxSoftBody* classPointer, bool call_explicit, NxReal friction)
{
    classPointer->setFriction(friction);
}

API_EXPORT NxReal NxSoftBody_getFriction(NxSoftBody* classPointer, bool call_explicit)
{
    return classPointer->getFriction();
}

API_EXPORT void NxSoftBody_setTearFactor(NxSoftBody* classPointer, bool call_explicit, NxReal factor)
{
    classPointer->setTearFactor(factor);
}

API_EXPORT NxReal NxSoftBody_getTearFactor(NxSoftBody* classPointer, bool call_explicit)
{
    return classPointer->getTearFactor();
}

API_EXPORT void NxSoftBody_setAttachmentTearFactor(NxSoftBody* classPointer, bool call_explicit, NxReal factor)
{
    classPointer->setAttachmentTearFactor(factor);
}

API_EXPORT NxReal NxSoftBody_getAttachmentTearFactor(NxSoftBody* classPointer, bool call_explicit)
{
    return classPointer->getAttachmentTearFactor();
}

API_EXPORT void NxSoftBody_setParticleRadius(NxSoftBody* classPointer, bool call_explicit, NxReal particleRadius)
{
    classPointer->setParticleRadius(particleRadius);
}

API_EXPORT NxReal NxSoftBody_getParticleRadius(NxSoftBody* classPointer, bool call_explicit)
{
    return classPointer->getParticleRadius();
}

API_EXPORT NxReal NxSoftBody_getDensity(NxSoftBody* classPointer, bool call_explicit)
{
    return classPointer->getDensity();
}

API_EXPORT NxReal NxSoftBody_getRelativeGridSpacing(NxSoftBody* classPointer, bool call_explicit)
{
    return classPointer->getRelativeGridSpacing();
}

API_EXPORT NxU32 NxSoftBody_getSolverIterations(NxSoftBody* classPointer, bool call_explicit)
{
    return classPointer->getSolverIterations();
}

API_EXPORT void NxSoftBody_setSolverIterations(NxSoftBody* classPointer, bool call_explicit, NxU32 iterations)
{
    classPointer->setSolverIterations(iterations);
}

API_EXPORT void NxSoftBody_getWorldBounds(NxSoftBody* classPointer, bool call_explicit, NxBounds3* bounds)
{
    classPointer->getWorldBounds(*bounds);
}

API_EXPORT void NxSoftBody_attachToShape(NxSoftBody* classPointer, bool call_explicit, NxShape* shape, NxU32 attachmentFlags)
{
    classPointer->attachToShape(shape, attachmentFlags);
}

API_EXPORT void NxSoftBody_attachToCollidingShapes(NxSoftBody* classPointer, bool call_explicit, NxU32 attachmentFlags)
{
    classPointer->attachToCollidingShapes(attachmentFlags);
}

API_EXPORT void NxSoftBody_detachFromShape(NxSoftBody* classPointer, bool call_explicit, NxShape* shape)
{
    classPointer->detachFromShape(shape);
}

API_EXPORT void NxSoftBody_attachVertexToShape(NxSoftBody* classPointer, bool call_explicit, NxU32 vertexId, NxShape* shape, NxVec3& localPos, NxU32 attachmentFlags)
{
    classPointer->attachVertexToShape(vertexId, shape, localPos, attachmentFlags);
}

API_EXPORT void NxSoftBody_attachVertexToGlobalPosition(NxSoftBody* classPointer, bool call_explicit, NxU32 vertexId, NxVec3& pos)
{
    classPointer->attachVertexToGlobalPosition(vertexId, pos);
}

API_EXPORT void NxSoftBody_freeVertex(NxSoftBody* classPointer, bool call_explicit, NxU32 vertexId)
{
    classPointer->freeVertex(vertexId);
}

API_EXPORT bool NxSoftBody_tearVertex(NxSoftBody* classPointer, bool call_explicit, NxU32 vertexId, NxVec3& normal)
{
    return classPointer->tearVertex(vertexId, normal);
}

API_EXPORT bool NxSoftBody_raycast(NxSoftBody* classPointer, bool call_explicit, NxRay* worldRay, NxVec3& hit, NxU32& vertexId)
{
    return classPointer->raycast(*worldRay, hit, vertexId);
}

API_EXPORT void NxSoftBody_setGroup(NxSoftBody* classPointer, bool call_explicit, NxCollisionGroup collisionGroup)
{
    classPointer->setGroup(collisionGroup);
}

API_EXPORT NxCollisionGroup NxSoftBody_getGroup(NxSoftBody* classPointer, bool call_explicit)
{
    return classPointer->getGroup();
}

API_EXPORT void NxSoftBody_setGroupsMask(NxSoftBody* classPointer, bool call_explicit, NxGroupsMask* groupsMask)
{
    classPointer->setGroupsMask(*groupsMask);
}

API_EXPORT const NxGroupsMask* NxSoftBody_getGroupsMask(NxSoftBody* classPointer, bool call_explicit)
{
    return &classPointer->getGroupsMask();
}

API_EXPORT void NxSoftBody_setMeshData(NxSoftBody* classPointer, bool call_explicit, NxMeshData* meshData)
{
    classPointer->setMeshData(*meshData);
}

API_EXPORT NxMeshData* NxSoftBody_getMeshData(NxSoftBody* classPointer, bool call_explicit)
{
    return &classPointer->getMeshData();
}

API_EXPORT void NxSoftBody_setSplitPairData(NxSoftBody* classPointer, bool call_explicit, NxSoftBodySplitPairData* splitPairData)
{
    classPointer->setSplitPairData(*splitPairData);
}

API_EXPORT NxSoftBodySplitPairData* NxSoftBody_getSplitPairData(NxSoftBody* classPointer, bool call_explicit)
{
    return &classPointer->getSplitPairData();
}

API_EXPORT void NxSoftBody_setValidBounds(NxSoftBody* classPointer, bool call_explicit, NxBounds3* validBounds)
{
    classPointer->setValidBounds(*validBounds);
}

API_EXPORT void NxSoftBody_getValidBounds(NxSoftBody* classPointer, bool call_explicit, NxBounds3* validBounds)
{
    classPointer->getValidBounds(*validBounds);
}

API_EXPORT void NxSoftBody_setPosition(NxSoftBody* classPointer, bool call_explicit, NxVec3& position, NxU32 vertexId)
{
    classPointer->setPosition(position, vertexId);
}

API_EXPORT void NxSoftBody_setPositions(NxSoftBody* classPointer, bool call_explicit, void* buffer, NxU32 byteStride)
{
    classPointer->setPositions(buffer, byteStride);
}

API_EXPORT void NxSoftBody_setPositions_1(NxSoftBody* classPointer, bool call_explicit, void* buffer)
{
    classPointer->setPositions(buffer);
}

API_EXPORT NxVec3 NxSoftBody_getPosition(NxSoftBody* classPointer, bool call_explicit, NxU32 vertexId)
{
    return classPointer->getPosition(vertexId);
}

API_EXPORT void NxSoftBody_getPositions(NxSoftBody* classPointer, bool call_explicit, void* buffer, NxU32 byteStride)
{
    classPointer->getPositions(buffer, byteStride);
}

API_EXPORT void NxSoftBody_getPositions_1(NxSoftBody* classPointer, bool call_explicit, void* buffer)
{
    classPointer->getPositions(buffer);
}

API_EXPORT void NxSoftBody_setVelocity(NxSoftBody* classPointer, bool call_explicit, NxVec3& velocity, NxU32 vertexId)
{
    classPointer->setVelocity(velocity, vertexId);
}

API_EXPORT void NxSoftBody_setVelocities(NxSoftBody* classPointer, bool call_explicit, void* buffer, NxU32 byteStride)
{
    classPointer->setVelocities(buffer, byteStride);
}

API_EXPORT void NxSoftBody_setVelocities_1(NxSoftBody* classPointer, bool call_explicit, void* buffer)
{
    classPointer->setVelocities(buffer);
}

API_EXPORT NxVec3 NxSoftBody_getVelocity(NxSoftBody* classPointer, bool call_explicit, NxU32 vertexId)
{
    return classPointer->getVelocity(vertexId);
}

API_EXPORT void NxSoftBody_getVelocities(NxSoftBody* classPointer, bool call_explicit, void* buffer, NxU32 byteStride)
{
    classPointer->getVelocities(buffer, byteStride);
}

API_EXPORT void NxSoftBody_getVelocities_1(NxSoftBody* classPointer, bool call_explicit, void* buffer)
{
    classPointer->getVelocities(buffer);
}

API_EXPORT NxU32 NxSoftBody_getNumberOfParticles(NxSoftBody* classPointer, bool call_explicit)
{
    return classPointer->getNumberOfParticles();
}

API_EXPORT NxU32 NxSoftBody_queryShapePointers(NxSoftBody* classPointer, bool call_explicit)
{
    return classPointer->queryShapePointers();
}

API_EXPORT NxU32 NxSoftBody_getStateByteSize(NxSoftBody* classPointer, bool call_explicit)
{
    return classPointer->getStateByteSize();
}

API_EXPORT void NxSoftBody_getShapePointers(NxSoftBody* classPointer, bool call_explicit, NxShape** shapePointers, NxU32* flags)
{
    classPointer->getShapePointers(shapePointers, flags);
}

API_EXPORT void NxSoftBody_setShapePointers(NxSoftBody* classPointer, bool call_explicit, NxShape** shapePointers, unsigned int numShapes)
{
    classPointer->setShapePointers(shapePointers, numShapes);
}

API_EXPORT void NxSoftBody_saveStateToStream(NxSoftBody* classPointer, bool call_explicit, NxStream* stream, bool permute)
{
    classPointer->saveStateToStream(*stream, permute);
}

API_EXPORT void NxSoftBody_saveStateToStream_1(NxSoftBody* classPointer, bool call_explicit, NxStream* stream)
{
    classPointer->saveStateToStream(*stream);
}

API_EXPORT void NxSoftBody_loadStateFromStream(NxSoftBody* classPointer, bool call_explicit, NxStream* stream)
{
    classPointer->loadStateFromStream(*stream);
}

API_EXPORT void NxSoftBody_setCollisionResponseCoefficient(NxSoftBody* classPointer, bool call_explicit, NxReal coefficient)
{
    classPointer->setCollisionResponseCoefficient(coefficient);
}

API_EXPORT NxReal NxSoftBody_getCollisionResponseCoefficient(NxSoftBody* classPointer, bool call_explicit)
{
    return classPointer->getCollisionResponseCoefficient();
}

API_EXPORT void NxSoftBody_setAttachmentResponseCoefficient(NxSoftBody* classPointer, bool call_explicit, NxReal coefficient)
{
    classPointer->setAttachmentResponseCoefficient(coefficient);
}

API_EXPORT NxReal NxSoftBody_getAttachmentResponseCoefficient(NxSoftBody* classPointer, bool call_explicit)
{
    return classPointer->getAttachmentResponseCoefficient();
}

API_EXPORT void NxSoftBody_setFromFluidResponseCoefficient(NxSoftBody* classPointer, bool call_explicit, NxReal coefficient)
{
    classPointer->setFromFluidResponseCoefficient(coefficient);
}

API_EXPORT NxReal NxSoftBody_getFromFluidResponseCoefficient(NxSoftBody* classPointer, bool call_explicit)
{
    return classPointer->getFromFluidResponseCoefficient();
}

API_EXPORT void NxSoftBody_setToFluidResponseCoefficient(NxSoftBody* classPointer, bool call_explicit, NxReal coefficient)
{
    classPointer->setToFluidResponseCoefficient(coefficient);
}

API_EXPORT NxReal NxSoftBody_getToFluidResponseCoefficient(NxSoftBody* classPointer, bool call_explicit)
{
    return classPointer->getToFluidResponseCoefficient();
}

API_EXPORT void NxSoftBody_setExternalAcceleration(NxSoftBody* classPointer, bool call_explicit, NxVec3 acceleration)
{
    classPointer->setExternalAcceleration(acceleration);
}

API_EXPORT NxVec3 NxSoftBody_getExternalAcceleration(NxSoftBody* classPointer, bool call_explicit)
{
    return classPointer->getExternalAcceleration();
}

API_EXPORT void NxSoftBody_setMinAdhereVelocity(NxSoftBody* classPointer, bool call_explicit, NxReal velocity)
{
    classPointer->setMinAdhereVelocity(velocity);
}

API_EXPORT NxReal NxSoftBody_getMinAdhereVelocity(NxSoftBody* classPointer, bool call_explicit)
{
    return classPointer->getMinAdhereVelocity();
}

API_EXPORT bool NxSoftBody_isSleeping(NxSoftBody* classPointer, bool call_explicit)
{
    return classPointer->isSleeping();
}

API_EXPORT NxReal NxSoftBody_getSleepLinearVelocity(NxSoftBody* classPointer, bool call_explicit)
{
    return classPointer->getSleepLinearVelocity();
}

API_EXPORT void NxSoftBody_setSleepLinearVelocity(NxSoftBody* classPointer, bool call_explicit, NxReal threshold)
{
    classPointer->setSleepLinearVelocity(threshold);
}

API_EXPORT void NxSoftBody_wakeUp(NxSoftBody* classPointer, bool call_explicit, NxReal wakeCounterValue)
{
    classPointer->wakeUp(wakeCounterValue);
}

API_EXPORT void NxSoftBody_putToSleep(NxSoftBody* classPointer, bool call_explicit)
{
    classPointer->putToSleep();
}

API_EXPORT void NxSoftBody_setFlags(NxSoftBody* classPointer, bool call_explicit, NxU32 flags)
{
    classPointer->setFlags(flags);
}

API_EXPORT NxU32 NxSoftBody_getFlags(NxSoftBody* classPointer, bool call_explicit)
{
    return classPointer->getFlags();
}

API_EXPORT void NxSoftBody_setName(NxSoftBody* classPointer, bool call_explicit, char* name)
{
    classPointer->setName(name);
}

API_EXPORT void NxSoftBody_addForceAtVertex(NxSoftBody* classPointer, bool call_explicit, NxVec3& force, NxU32 vertexId, NxForceMode mode)
{
    classPointer->addForceAtVertex(force, vertexId, mode);
}

API_EXPORT void NxSoftBody_addForceAtVertex_1(NxSoftBody* classPointer, bool call_explicit, NxVec3& force, NxU32 vertexId)
{
    classPointer->addForceAtVertex(force, vertexId);
}

API_EXPORT void NxSoftBody_addForceAtPos(NxSoftBody* classPointer, bool call_explicit, NxVec3& position, NxReal magnitude, NxReal radius, NxForceMode mode)
{
    classPointer->addForceAtPos(position, magnitude, radius, mode);
}

API_EXPORT void NxSoftBody_addForceAtPos_1(NxSoftBody* classPointer, bool call_explicit, NxVec3& position, NxReal magnitude, NxReal radius)
{
    classPointer->addForceAtPos(position, magnitude, radius);
}

API_EXPORT bool NxSoftBody_overlapAABBTetrahedra(NxSoftBody* classPointer, bool call_explicit, NxBounds3* bounds, NxU32& nb, const NxU32*& indices)
{
    return classPointer->overlapAABBTetrahedra(*bounds, nb, indices);
}

API_EXPORT NxScene* NxSoftBody_getScene(NxSoftBody* classPointer, bool call_explicit)
{
    return &classPointer->getScene();
}

API_EXPORT const char* NxSoftBody_getName(NxSoftBody* classPointer, bool call_explicit)
{
    return classPointer->getName();
}

API_EXPORT NxCompartment* NxSoftBody_getCompartment(NxSoftBody* classPointer, bool call_explicit)
{
    return classPointer->getCompartment();
}

API_EXPORT NxForceFieldMaterial NxSoftBody_getForceFieldMaterial(NxSoftBody* classPointer, bool call_explicit)
{
    return classPointer->getForceFieldMaterial();
}

API_EXPORT void NxSoftBody_setForceFieldMaterial(NxSoftBody* classPointer, bool call_explicit, NxForceFieldMaterial unknown95)
{
    classPointer->setForceFieldMaterial(unknown95);
}

API_EXPORT void set_NxSoftBodyDesc_softBodyMesh(NxSoftBodyDesc* classPointer, NxSoftBodyMesh* newvalue)
{
    classPointer->softBodyMesh = newvalue;
}

API_EXPORT NxSoftBodyMesh* get_NxSoftBodyDesc_softBodyMesh(NxSoftBodyDesc* classPointer)
{
    return classPointer->softBodyMesh;
}

API_EXPORT void set_NxSoftBodyDesc_globalPose(NxSoftBodyDesc* classPointer, NxMat34 newvalue)
{
    classPointer->globalPose = newvalue;
}

API_EXPORT NxMat34 get_NxSoftBodyDesc_globalPose(NxSoftBodyDesc* classPointer)
{
    return classPointer->globalPose;
}

API_EXPORT void set_NxSoftBodyDesc_particleRadius(NxSoftBodyDesc* classPointer, NxReal newvalue)
{
    classPointer->particleRadius = newvalue;
}

API_EXPORT NxReal get_NxSoftBodyDesc_particleRadius(NxSoftBodyDesc* classPointer)
{
    return classPointer->particleRadius;
}

API_EXPORT void set_NxSoftBodyDesc_density(NxSoftBodyDesc* classPointer, NxReal newvalue)
{
    classPointer->density = newvalue;
}

API_EXPORT NxReal get_NxSoftBodyDesc_density(NxSoftBodyDesc* classPointer)
{
    return classPointer->density;
}

API_EXPORT void set_NxSoftBodyDesc_volumeStiffness(NxSoftBodyDesc* classPointer, NxReal newvalue)
{
    classPointer->volumeStiffness = newvalue;
}

API_EXPORT NxReal get_NxSoftBodyDesc_volumeStiffness(NxSoftBodyDesc* classPointer)
{
    return classPointer->volumeStiffness;
}

API_EXPORT void set_NxSoftBodyDesc_stretchingStiffness(NxSoftBodyDesc* classPointer, NxReal newvalue)
{
    classPointer->stretchingStiffness = newvalue;
}

API_EXPORT NxReal get_NxSoftBodyDesc_stretchingStiffness(NxSoftBodyDesc* classPointer)
{
    return classPointer->stretchingStiffness;
}

API_EXPORT void set_NxSoftBodyDesc_dampingCoefficient(NxSoftBodyDesc* classPointer, NxReal newvalue)
{
    classPointer->dampingCoefficient = newvalue;
}

API_EXPORT NxReal get_NxSoftBodyDesc_dampingCoefficient(NxSoftBodyDesc* classPointer)
{
    return classPointer->dampingCoefficient;
}

API_EXPORT void set_NxSoftBodyDesc_friction(NxSoftBodyDesc* classPointer, NxReal newvalue)
{
    classPointer->friction = newvalue;
}

API_EXPORT NxReal get_NxSoftBodyDesc_friction(NxSoftBodyDesc* classPointer)
{
    return classPointer->friction;
}

API_EXPORT void set_NxSoftBodyDesc_tearFactor(NxSoftBodyDesc* classPointer, NxReal newvalue)
{
    classPointer->tearFactor = newvalue;
}

API_EXPORT NxReal get_NxSoftBodyDesc_tearFactor(NxSoftBodyDesc* classPointer)
{
    return classPointer->tearFactor;
}

API_EXPORT void set_NxSoftBodyDesc_collisionResponseCoefficient(NxSoftBodyDesc* classPointer, NxReal newvalue)
{
    classPointer->collisionResponseCoefficient = newvalue;
}

API_EXPORT NxReal get_NxSoftBodyDesc_collisionResponseCoefficient(NxSoftBodyDesc* classPointer)
{
    return classPointer->collisionResponseCoefficient;
}

API_EXPORT void set_NxSoftBodyDesc_attachmentResponseCoefficient(NxSoftBodyDesc* classPointer, NxReal newvalue)
{
    classPointer->attachmentResponseCoefficient = newvalue;
}

API_EXPORT NxReal get_NxSoftBodyDesc_attachmentResponseCoefficient(NxSoftBodyDesc* classPointer)
{
    return classPointer->attachmentResponseCoefficient;
}

API_EXPORT void set_NxSoftBodyDesc_attachmentTearFactor(NxSoftBodyDesc* classPointer, NxReal newvalue)
{
    classPointer->attachmentTearFactor = newvalue;
}

API_EXPORT NxReal get_NxSoftBodyDesc_attachmentTearFactor(NxSoftBodyDesc* classPointer)
{
    return classPointer->attachmentTearFactor;
}

API_EXPORT void set_NxSoftBodyDesc_toFluidResponseCoefficient(NxSoftBodyDesc* classPointer, NxReal newvalue)
{
    classPointer->toFluidResponseCoefficient = newvalue;
}

API_EXPORT NxReal get_NxSoftBodyDesc_toFluidResponseCoefficient(NxSoftBodyDesc* classPointer)
{
    return classPointer->toFluidResponseCoefficient;
}

API_EXPORT void set_NxSoftBodyDesc_fromFluidResponseCoefficient(NxSoftBodyDesc* classPointer, NxReal newvalue)
{
    classPointer->fromFluidResponseCoefficient = newvalue;
}

API_EXPORT NxReal get_NxSoftBodyDesc_fromFluidResponseCoefficient(NxSoftBodyDesc* classPointer)
{
    return classPointer->fromFluidResponseCoefficient;
}

API_EXPORT void set_NxSoftBodyDesc_minAdhereVelocity(NxSoftBodyDesc* classPointer, NxReal newvalue)
{
    classPointer->minAdhereVelocity = newvalue;
}

API_EXPORT NxReal get_NxSoftBodyDesc_minAdhereVelocity(NxSoftBodyDesc* classPointer)
{
    return classPointer->minAdhereVelocity;
}

API_EXPORT void set_NxSoftBodyDesc_solverIterations(NxSoftBodyDesc* classPointer, NxU32 newvalue)
{
    classPointer->solverIterations = newvalue;
}

API_EXPORT NxU32 get_NxSoftBodyDesc_solverIterations(NxSoftBodyDesc* classPointer)
{
    return classPointer->solverIterations;
}

API_EXPORT void set_NxSoftBodyDesc_externalAcceleration(NxSoftBodyDesc* classPointer, NxVec3 newvalue)
{
    classPointer->externalAcceleration = newvalue;
}

API_EXPORT NxVec3 get_NxSoftBodyDesc_externalAcceleration(NxSoftBodyDesc* classPointer)
{
    return classPointer->externalAcceleration;
}

API_EXPORT void set_NxSoftBodyDesc_wakeUpCounter(NxSoftBodyDesc* classPointer, NxReal newvalue)
{
    classPointer->wakeUpCounter = newvalue;
}

API_EXPORT NxReal get_NxSoftBodyDesc_wakeUpCounter(NxSoftBodyDesc* classPointer)
{
    return classPointer->wakeUpCounter;
}

API_EXPORT void set_NxSoftBodyDesc_sleepLinearVelocity(NxSoftBodyDesc* classPointer, NxReal newvalue)
{
    classPointer->sleepLinearVelocity = newvalue;
}

API_EXPORT NxReal get_NxSoftBodyDesc_sleepLinearVelocity(NxSoftBodyDesc* classPointer)
{
    return classPointer->sleepLinearVelocity;
}

API_EXPORT void set_NxSoftBodyDesc_meshData(NxSoftBodyDesc* classPointer, NxMeshData* newvalue)
{
    classPointer->meshData = *newvalue;
}

API_EXPORT NxMeshData* get_NxSoftBodyDesc_meshData(NxSoftBodyDesc* classPointer)
{
    return &classPointer->meshData;
}

API_EXPORT void set_NxSoftBodyDesc_splitPairData(NxSoftBodyDesc* classPointer, NxSoftBodySplitPairData* newvalue)
{
    classPointer->splitPairData = *newvalue;
}

API_EXPORT NxSoftBodySplitPairData* get_NxSoftBodyDesc_splitPairData(NxSoftBodyDesc* classPointer)
{
    return &classPointer->splitPairData;
}

API_EXPORT void set_NxSoftBodyDesc_collisionGroup(NxSoftBodyDesc* classPointer, NxCollisionGroup newvalue)
{
    classPointer->collisionGroup = newvalue;
}

API_EXPORT NxCollisionGroup get_NxSoftBodyDesc_collisionGroup(NxSoftBodyDesc* classPointer)
{
    return classPointer->collisionGroup;
}

API_EXPORT void set_NxSoftBodyDesc_groupsMask(NxSoftBodyDesc* classPointer, NxGroupsMask* newvalue)
{
    classPointer->groupsMask = *newvalue;
}

API_EXPORT NxGroupsMask* get_NxSoftBodyDesc_groupsMask(NxSoftBodyDesc* classPointer)
{
    return &classPointer->groupsMask;
}

API_EXPORT void set_NxSoftBodyDesc_forceFieldMaterial(NxSoftBodyDesc* classPointer, NxU16 newvalue)
{
    classPointer->forceFieldMaterial = newvalue;
}

API_EXPORT NxU16 get_NxSoftBodyDesc_forceFieldMaterial(NxSoftBodyDesc* classPointer)
{
    return classPointer->forceFieldMaterial;
}

API_EXPORT void set_NxSoftBodyDesc_validBounds(NxSoftBodyDesc* classPointer, NxBounds3* newvalue)
{
    classPointer->validBounds = *newvalue;
}

API_EXPORT NxBounds3* get_NxSoftBodyDesc_validBounds(NxSoftBodyDesc* classPointer)
{
    return &classPointer->validBounds;
}

API_EXPORT void set_NxSoftBodyDesc_relativeGridSpacing(NxSoftBodyDesc* classPointer, NxReal newvalue)
{
    classPointer->relativeGridSpacing = newvalue;
}

API_EXPORT NxReal get_NxSoftBodyDesc_relativeGridSpacing(NxSoftBodyDesc* classPointer)
{
    return classPointer->relativeGridSpacing;
}

API_EXPORT void set_NxSoftBodyDesc_flags(NxSoftBodyDesc* classPointer, NxU32 newvalue)
{
    classPointer->flags = newvalue;
}

API_EXPORT NxU32 get_NxSoftBodyDesc_flags(NxSoftBodyDesc* classPointer)
{
    return classPointer->flags;
}

API_EXPORT void set_NxSoftBodyDesc_userData(NxSoftBodyDesc* classPointer, void* newvalue)
{
    classPointer->userData = newvalue;
}

API_EXPORT void* get_NxSoftBodyDesc_userData(NxSoftBodyDesc* classPointer)
{
    return classPointer->userData;
}

API_EXPORT void set_NxSoftBodyDesc_name(NxSoftBodyDesc* classPointer, const char* newvalue)
{
    classPointer->name = newvalue;
}

API_EXPORT const char* get_NxSoftBodyDesc_name(NxSoftBodyDesc* classPointer)
{
    return classPointer->name;
}

API_EXPORT void set_NxSoftBodyDesc_compartment(NxSoftBodyDesc* classPointer, NxCompartment* newvalue)
{
    classPointer->compartment = newvalue;
}

API_EXPORT NxCompartment* get_NxSoftBodyDesc_compartment(NxSoftBodyDesc* classPointer)
{
    return classPointer->compartment;
}

API_EXPORT NxSoftBodyDesc* new_NxSoftBodyDesc(bool do_override)
{
    return new NxSoftBodyDesc();
}

API_EXPORT void NxSoftBodyDesc_setToDefault(NxSoftBodyDesc* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxSoftBodyDesc::setToDefault() : classPointer->setToDefault();
}

API_EXPORT bool NxSoftBodyDesc_isValid(NxSoftBodyDesc* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxSoftBodyDesc::isValid() : classPointer->isValid();
}

API_EXPORT NxSoftBodyMesh* new_NxSoftBodyMesh(bool do_override)
{
    return (do_override) ? new NxSoftBodyMesh_doxybind() : NULL;
}

API_EXPORT bool NxSoftBodyMesh_saveToDesc(NxSoftBodyMesh* classPointer, bool call_explicit, NxSoftBodyMeshDesc* desc)
{
    return classPointer->saveToDesc(*desc);
}

API_EXPORT NxU32 NxSoftBodyMesh_getReferenceCount(NxSoftBodyMesh* classPointer, bool call_explicit)
{
    return classPointer->getReferenceCount();
}

API_EXPORT void set_NxSoftBodyMeshDesc_numVertices(NxSoftBodyMeshDesc* classPointer, NxU32 newvalue)
{
    classPointer->numVertices = newvalue;
}

API_EXPORT NxU32 get_NxSoftBodyMeshDesc_numVertices(NxSoftBodyMeshDesc* classPointer)
{
    return classPointer->numVertices;
}

API_EXPORT void set_NxSoftBodyMeshDesc_numTetrahedra(NxSoftBodyMeshDesc* classPointer, NxU32 newvalue)
{
    classPointer->numTetrahedra = newvalue;
}

API_EXPORT NxU32 get_NxSoftBodyMeshDesc_numTetrahedra(NxSoftBodyMeshDesc* classPointer)
{
    return classPointer->numTetrahedra;
}

API_EXPORT void set_NxSoftBodyMeshDesc_vertexStrideBytes(NxSoftBodyMeshDesc* classPointer, NxU32 newvalue)
{
    classPointer->vertexStrideBytes = newvalue;
}

API_EXPORT NxU32 get_NxSoftBodyMeshDesc_vertexStrideBytes(NxSoftBodyMeshDesc* classPointer)
{
    return classPointer->vertexStrideBytes;
}

API_EXPORT void set_NxSoftBodyMeshDesc_tetrahedronStrideBytes(NxSoftBodyMeshDesc* classPointer, NxU32 newvalue)
{
    classPointer->tetrahedronStrideBytes = newvalue;
}

API_EXPORT NxU32 get_NxSoftBodyMeshDesc_tetrahedronStrideBytes(NxSoftBodyMeshDesc* classPointer)
{
    return classPointer->tetrahedronStrideBytes;
}

API_EXPORT void set_NxSoftBodyMeshDesc_vertices(NxSoftBodyMeshDesc* classPointer, const void* newvalue)
{
    classPointer->vertices = newvalue;
}

API_EXPORT const void* get_NxSoftBodyMeshDesc_vertices(NxSoftBodyMeshDesc* classPointer)
{
    return classPointer->vertices;
}

API_EXPORT void set_NxSoftBodyMeshDesc_tetrahedra(NxSoftBodyMeshDesc* classPointer, const void* newvalue)
{
    classPointer->tetrahedra = newvalue;
}

API_EXPORT const void* get_NxSoftBodyMeshDesc_tetrahedra(NxSoftBodyMeshDesc* classPointer)
{
    return classPointer->tetrahedra;
}

API_EXPORT void set_NxSoftBodyMeshDesc_flags(NxSoftBodyMeshDesc* classPointer, NxU32 newvalue)
{
    classPointer->flags = newvalue;
}

API_EXPORT NxU32 get_NxSoftBodyMeshDesc_flags(NxSoftBodyMeshDesc* classPointer)
{
    return classPointer->flags;
}

API_EXPORT void set_NxSoftBodyMeshDesc_vertexMassStrideBytes(NxSoftBodyMeshDesc* classPointer, NxU32 newvalue)
{
    classPointer->vertexMassStrideBytes = newvalue;
}

API_EXPORT NxU32 get_NxSoftBodyMeshDesc_vertexMassStrideBytes(NxSoftBodyMeshDesc* classPointer)
{
    return classPointer->vertexMassStrideBytes;
}

API_EXPORT void set_NxSoftBodyMeshDesc_vertexFlagStrideBytes(NxSoftBodyMeshDesc* classPointer, NxU32 newvalue)
{
    classPointer->vertexFlagStrideBytes = newvalue;
}

API_EXPORT NxU32 get_NxSoftBodyMeshDesc_vertexFlagStrideBytes(NxSoftBodyMeshDesc* classPointer)
{
    return classPointer->vertexFlagStrideBytes;
}

API_EXPORT void set_NxSoftBodyMeshDesc_vertexMasses(NxSoftBodyMeshDesc* classPointer, const void* newvalue)
{
    classPointer->vertexMasses = newvalue;
}

API_EXPORT const void* get_NxSoftBodyMeshDesc_vertexMasses(NxSoftBodyMeshDesc* classPointer)
{
    return classPointer->vertexMasses;
}

API_EXPORT void set_NxSoftBodyMeshDesc_vertexFlags(NxSoftBodyMeshDesc* classPointer, const void* newvalue)
{
    classPointer->vertexFlags = newvalue;
}

API_EXPORT const void* get_NxSoftBodyMeshDesc_vertexFlags(NxSoftBodyMeshDesc* classPointer)
{
    return classPointer->vertexFlags;
}

API_EXPORT NxSoftBodyMeshDesc* new_NxSoftBodyMeshDesc(bool do_override)
{
    return new NxSoftBodyMeshDesc();
}

API_EXPORT void NxSoftBodyMeshDesc_setToDefault(NxSoftBodyMeshDesc* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxSoftBodyMeshDesc::setToDefault() : classPointer->setToDefault();
}

API_EXPORT bool NxSoftBodyMeshDesc_isValid(NxSoftBodyMeshDesc* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxSoftBodyMeshDesc::isValid() : classPointer->isValid();
}

API_EXPORT void set_NxSoftBodySplitPair_tetrahedronIndex0(NxSoftBodySplitPair* classPointer, NxU32 newvalue)
{
    classPointer->tetrahedronIndex0 = newvalue;
}

API_EXPORT NxU32 get_NxSoftBodySplitPair_tetrahedronIndex0(NxSoftBodySplitPair* classPointer)
{
    return classPointer->tetrahedronIndex0;
}

API_EXPORT void set_NxSoftBodySplitPair_tetrahedronIndex1(NxSoftBodySplitPair* classPointer, NxU32 newvalue)
{
    classPointer->tetrahedronIndex1 = newvalue;
}

API_EXPORT NxU32 get_NxSoftBodySplitPair_tetrahedronIndex1(NxSoftBodySplitPair* classPointer)
{
    return classPointer->tetrahedronIndex1;
}

API_EXPORT void set_NxSoftBodySplitPair_faceIndex0(NxSoftBodySplitPair* classPointer, NxU8 newvalue)
{
    classPointer->faceIndex0 = newvalue;
}

API_EXPORT NxU8 get_NxSoftBodySplitPair_faceIndex0(NxSoftBodySplitPair* classPointer)
{
    return classPointer->faceIndex0;
}

API_EXPORT void set_NxSoftBodySplitPair_faceIndex1(NxSoftBodySplitPair* classPointer, NxU8 newvalue)
{
    classPointer->faceIndex1 = newvalue;
}

API_EXPORT NxU8 get_NxSoftBodySplitPair_faceIndex1(NxSoftBodySplitPair* classPointer)
{
    return classPointer->faceIndex1;
}

API_EXPORT void set_NxSoftBodySplitPairData_maxSplitPairs(NxSoftBodySplitPairData* classPointer, NxU32 newvalue)
{
    classPointer->maxSplitPairs = newvalue;
}

API_EXPORT NxU32 get_NxSoftBodySplitPairData_maxSplitPairs(NxSoftBodySplitPairData* classPointer)
{
    return classPointer->maxSplitPairs;
}

API_EXPORT void set_NxSoftBodySplitPairData_numSplitPairsPtr(NxSoftBodySplitPairData* classPointer, NxU32* newvalue)
{
    classPointer->numSplitPairsPtr = newvalue;
}

API_EXPORT NxU32* get_NxSoftBodySplitPairData_numSplitPairsPtr(NxSoftBodySplitPairData* classPointer)
{
    return classPointer->numSplitPairsPtr;
}

API_EXPORT void set_NxSoftBodySplitPairData_splitPairsBegin(NxSoftBodySplitPairData* classPointer, NxSoftBodySplitPair* newvalue)
{
    classPointer->splitPairsBegin = newvalue;
}

API_EXPORT NxSoftBodySplitPair* get_NxSoftBodySplitPairData_splitPairsBegin(NxSoftBodySplitPairData* classPointer)
{
    return classPointer->splitPairsBegin;
}

API_EXPORT void set_NxSoftBodySplitPairData_splitPairsByteStride(NxSoftBodySplitPairData* classPointer, NxU32 newvalue)
{
    classPointer->splitPairsByteStride = newvalue;
}

API_EXPORT NxU32 get_NxSoftBodySplitPairData_splitPairsByteStride(NxSoftBodySplitPairData* classPointer)
{
    return classPointer->splitPairsByteStride;
}

API_EXPORT void NxSoftBodySplitPairData_setToDefault(NxSoftBodySplitPairData* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxSoftBodySplitPairData::setToDefault() : classPointer->setToDefault();
}

API_EXPORT bool NxSoftBodySplitPairData_isValid(NxSoftBodySplitPairData* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxSoftBodySplitPairData::isValid() : classPointer->isValid();
}

API_EXPORT NxSoftBodySplitPairData* new_NxSoftBodySplitPairData(bool do_override)
{
    return new NxSoftBodySplitPairData();
}

API_EXPORT void set_NxSphere_center(NxSphere* classPointer, NxVec3 newvalue)
{
    classPointer->center = newvalue;
}

API_EXPORT NxVec3 get_NxSphere_center(NxSphere* classPointer)
{
    return classPointer->center;
}

API_EXPORT void set_NxSphere_radius(NxSphere* classPointer, NxF32 newvalue)
{
    classPointer->radius = newvalue;
}

API_EXPORT NxF32 get_NxSphere_radius(NxSphere* classPointer)
{
    return classPointer->radius;
}

API_EXPORT NxSphere* new_NxSphere(bool do_override)
{
    return new NxSphere();
}

API_EXPORT NxSphere* new_NxSphere_1(bool do_override, NxVec3& _center, NxF32 _radius)
{
    return new NxSphere(_center, _radius);
}

API_EXPORT NxSphere* new_NxSphere_2(bool do_override, NxSphere* sphere)
{
    return new NxSphere(*sphere);
}

API_EXPORT bool NxSphere_IsValid(NxSphere* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxSphere::IsValid() : classPointer->IsValid();
}

API_EXPORT bool NxSphere_Contains(NxSphere* classPointer, bool call_explicit, NxVec3& p)
{
    return (call_explicit) ? classPointer->NxSphere::Contains(p) : classPointer->Contains(p);
}

API_EXPORT bool NxSphere_Contains_1(NxSphere* classPointer, bool call_explicit, NxSphere* sphere)
{
    return (call_explicit) ? classPointer->NxSphere::Contains(*sphere) : classPointer->Contains(*sphere);
}

API_EXPORT bool NxSphere_Contains_2(NxSphere* classPointer, bool call_explicit, NxVec3& min, NxVec3& max)
{
    return (call_explicit) ? classPointer->NxSphere::Contains(min, max) : classPointer->Contains(min, max);
}

API_EXPORT bool NxSphere_Intersect(NxSphere* classPointer, bool call_explicit, NxSphere* sphere)
{
    return (call_explicit) ? classPointer->NxSphere::Intersect(*sphere) : classPointer->Intersect(*sphere);
}

API_EXPORT void NxSphereForceFieldShape_setRadius(NxSphereForceFieldShape* classPointer, bool call_explicit, NxReal radius)
{
    classPointer->setRadius(radius);
}

API_EXPORT NxReal NxSphereForceFieldShape_getRadius(NxSphereForceFieldShape* classPointer, bool call_explicit)
{
    return classPointer->getRadius();
}

API_EXPORT void NxSphereForceFieldShape_saveToDesc(NxSphereForceFieldShape* classPointer, bool call_explicit, NxSphereForceFieldShapeDesc* desc)
{
    classPointer->saveToDesc(*desc);
}

API_EXPORT void set_NxSphereForceFieldShapeDesc_radius(NxSphereForceFieldShapeDesc* classPointer, NxReal newvalue)
{
    classPointer->radius = newvalue;
}

API_EXPORT NxReal get_NxSphereForceFieldShapeDesc_radius(NxSphereForceFieldShapeDesc* classPointer)
{
    return classPointer->radius;
}

API_EXPORT NxSphereForceFieldShapeDesc* new_NxSphereForceFieldShapeDesc(bool do_override)
{
    return (do_override) ? new NxSphereForceFieldShapeDesc_doxybind() : new NxSphereForceFieldShapeDesc();
}

API_EXPORT void NxSphereForceFieldShapeDesc_setToDefault(NxSphereForceFieldShapeDesc* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxSphereForceFieldShapeDesc::setToDefault() : classPointer->setToDefault();
}

API_EXPORT bool NxSphereForceFieldShapeDesc_isValid(NxSphereForceFieldShapeDesc* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxSphereForceFieldShapeDesc::isValid() : classPointer->isValid();
}

API_EXPORT void NxSphereShape_setRadius(NxSphereShape* classPointer, bool call_explicit, NxReal radius)
{
    classPointer->setRadius(radius);
}

API_EXPORT NxReal NxSphereShape_getRadius(NxSphereShape* classPointer, bool call_explicit)
{
    return classPointer->getRadius();
}

API_EXPORT void NxSphereShape_getWorldSphere(NxSphereShape* classPointer, bool call_explicit, NxSphere* worldSphere)
{
    classPointer->getWorldSphere(*worldSphere);
}

API_EXPORT void NxSphereShape_saveToDesc(NxSphereShape* classPointer, bool call_explicit, NxSphereShapeDesc* desc)
{
    classPointer->saveToDesc(*desc);
}

API_EXPORT void set_NxSphereShapeDesc_radius(NxSphereShapeDesc* classPointer, NxReal newvalue)
{
    classPointer->radius = newvalue;
}

API_EXPORT NxReal get_NxSphereShapeDesc_radius(NxSphereShapeDesc* classPointer)
{
    return classPointer->radius;
}

API_EXPORT NxSphereShapeDesc* new_NxSphereShapeDesc(bool do_override)
{
    return (do_override) ? new NxSphereShapeDesc_doxybind() : new NxSphereShapeDesc();
}

API_EXPORT void NxSphereShapeDesc_setToDefault(NxSphereShapeDesc* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxSphereShapeDesc::setToDefault() : classPointer->setToDefault();
}

API_EXPORT bool NxSphereShapeDesc_isValid(NxSphereShapeDesc* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxSphereShapeDesc::isValid() : classPointer->isValid();
}

API_EXPORT void NxSphericalJoint_loadFromDesc(NxSphericalJoint* classPointer, bool call_explicit, NxSphericalJointDesc* desc)
{
    classPointer->loadFromDesc(*desc);
}

API_EXPORT void NxSphericalJoint_saveToDesc(NxSphericalJoint* classPointer, bool call_explicit, NxSphericalJointDesc* desc)
{
    classPointer->saveToDesc(*desc);
}

API_EXPORT void NxSphericalJoint_setFlags(NxSphericalJoint* classPointer, bool call_explicit, NxU32 flags)
{
    classPointer->setFlags(flags);
}

API_EXPORT NxU32 NxSphericalJoint_getFlags(NxSphericalJoint* classPointer, bool call_explicit)
{
    return classPointer->getFlags();
}

API_EXPORT void NxSphericalJoint_setProjectionMode(NxSphericalJoint* classPointer, bool call_explicit, NxJointProjectionMode projectionMode)
{
    classPointer->setProjectionMode(projectionMode);
}

API_EXPORT NxJointProjectionMode NxSphericalJoint_getProjectionMode(NxSphericalJoint* classPointer, bool call_explicit)
{
    return classPointer->getProjectionMode();
}

API_EXPORT void set_NxSphericalJointDesc_swingAxis(NxSphericalJointDesc* classPointer, NxVec3 newvalue)
{
    classPointer->swingAxis = newvalue;
}

API_EXPORT NxVec3 get_NxSphericalJointDesc_swingAxis(NxSphericalJointDesc* classPointer)
{
    return classPointer->swingAxis;
}

API_EXPORT void set_NxSphericalJointDesc_projectionDistance(NxSphericalJointDesc* classPointer, NxReal newvalue)
{
    classPointer->projectionDistance = newvalue;
}

API_EXPORT NxReal get_NxSphericalJointDesc_projectionDistance(NxSphericalJointDesc* classPointer)
{
    return classPointer->projectionDistance;
}

API_EXPORT void set_NxSphericalJointDesc_twistLimit(NxSphericalJointDesc* classPointer, NxJointLimitPairDesc* newvalue)
{
    classPointer->twistLimit = *newvalue;
}

API_EXPORT NxJointLimitPairDesc* get_NxSphericalJointDesc_twistLimit(NxSphericalJointDesc* classPointer)
{
    return &classPointer->twistLimit;
}

API_EXPORT void set_NxSphericalJointDesc_swingLimit(NxSphericalJointDesc* classPointer, NxJointLimitDesc* newvalue)
{
    classPointer->swingLimit = *newvalue;
}

API_EXPORT NxJointLimitDesc* get_NxSphericalJointDesc_swingLimit(NxSphericalJointDesc* classPointer)
{
    return &classPointer->swingLimit;
}

API_EXPORT void set_NxSphericalJointDesc_twistSpring(NxSphericalJointDesc* classPointer, NxSpringDesc* newvalue)
{
    classPointer->twistSpring = *newvalue;
}

API_EXPORT NxSpringDesc* get_NxSphericalJointDesc_twistSpring(NxSphericalJointDesc* classPointer)
{
    return &classPointer->twistSpring;
}

API_EXPORT void set_NxSphericalJointDesc_swingSpring(NxSphericalJointDesc* classPointer, NxSpringDesc* newvalue)
{
    classPointer->swingSpring = *newvalue;
}

API_EXPORT NxSpringDesc* get_NxSphericalJointDesc_swingSpring(NxSphericalJointDesc* classPointer)
{
    return &classPointer->swingSpring;
}

API_EXPORT void set_NxSphericalJointDesc_jointSpring(NxSphericalJointDesc* classPointer, NxSpringDesc* newvalue)
{
    classPointer->jointSpring = *newvalue;
}

API_EXPORT NxSpringDesc* get_NxSphericalJointDesc_jointSpring(NxSphericalJointDesc* classPointer)
{
    return &classPointer->jointSpring;
}

API_EXPORT void set_NxSphericalJointDesc_flags(NxSphericalJointDesc* classPointer, NxU32 newvalue)
{
    classPointer->flags = newvalue;
}

API_EXPORT NxU32 get_NxSphericalJointDesc_flags(NxSphericalJointDesc* classPointer)
{
    return classPointer->flags;
}

API_EXPORT void set_NxSphericalJointDesc_projectionMode(NxSphericalJointDesc* classPointer, NxJointProjectionMode newvalue)
{
    classPointer->projectionMode = newvalue;
}

API_EXPORT NxJointProjectionMode get_NxSphericalJointDesc_projectionMode(NxSphericalJointDesc* classPointer)
{
    return classPointer->projectionMode;
}

API_EXPORT NxSphericalJointDesc* new_NxSphericalJointDesc(bool do_override)
{
    return (do_override) ? new NxSphericalJointDesc_doxybind() : new NxSphericalJointDesc();
}

API_EXPORT void NxSphericalJointDesc_setToDefault(NxSphericalJointDesc* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxSphericalJointDesc::setToDefault() : classPointer->setToDefault();
}

API_EXPORT bool NxSphericalJointDesc_isValid(NxSphericalJointDesc* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxSphericalJointDesc::isValid() : classPointer->isValid();
}

API_EXPORT void NxSpringAndDamperEffector_saveToDesc(NxSpringAndDamperEffector* classPointer, bool call_explicit, NxSpringAndDamperEffectorDesc* desc)
{
    classPointer->saveToDesc(*desc);
}

API_EXPORT void NxSpringAndDamperEffector_setBodies(NxSpringAndDamperEffector* classPointer, bool call_explicit, NxActor* body1, NxVec3& global1, NxActor* body2, NxVec3& global2)
{
    classPointer->setBodies(body1, global1, body2, global2);
}

API_EXPORT void NxSpringAndDamperEffector_setLinearSpring(NxSpringAndDamperEffector* classPointer, bool call_explicit, NxReal distCompressSaturate, NxReal distRelaxed, NxReal distStretchSaturate, NxReal maxCompressForce, NxReal maxStretchForce)
{
    classPointer->setLinearSpring(distCompressSaturate, distRelaxed, distStretchSaturate, maxCompressForce, maxStretchForce);
}

API_EXPORT void NxSpringAndDamperEffector_getLinearSpring(NxSpringAndDamperEffector* classPointer, bool call_explicit, NxReal& distCompressSaturate, NxReal& distRelaxed, NxReal& distStretchSaturate, NxReal& maxCompressForce, NxReal& maxStretchForce)
{
    classPointer->getLinearSpring(distCompressSaturate, distRelaxed, distStretchSaturate, maxCompressForce, maxStretchForce);
}

API_EXPORT void NxSpringAndDamperEffector_setLinearDamper(NxSpringAndDamperEffector* classPointer, bool call_explicit, NxReal velCompressSaturate, NxReal velStretchSaturate, NxReal maxCompressForce, NxReal maxStretchForce)
{
    classPointer->setLinearDamper(velCompressSaturate, velStretchSaturate, maxCompressForce, maxStretchForce);
}

API_EXPORT void NxSpringAndDamperEffector_getLinearDamper(NxSpringAndDamperEffector* classPointer, bool call_explicit, NxReal& velCompressSaturate, NxReal& velStretchSaturate, NxReal& maxCompressForce, NxReal& maxStretchForce)
{
    classPointer->getLinearDamper(velCompressSaturate, velStretchSaturate, maxCompressForce, maxStretchForce);
}

API_EXPORT void set_NxSpringAndDamperEffectorDesc_body1(NxSpringAndDamperEffectorDesc* classPointer, NxActor* newvalue)
{
    classPointer->body1 = newvalue;
}

API_EXPORT NxActor* get_NxSpringAndDamperEffectorDesc_body1(NxSpringAndDamperEffectorDesc* classPointer)
{
    return classPointer->body1;
}

API_EXPORT void set_NxSpringAndDamperEffectorDesc_body2(NxSpringAndDamperEffectorDesc* classPointer, NxActor* newvalue)
{
    classPointer->body2 = newvalue;
}

API_EXPORT NxActor* get_NxSpringAndDamperEffectorDesc_body2(NxSpringAndDamperEffectorDesc* classPointer)
{
    return classPointer->body2;
}

API_EXPORT void set_NxSpringAndDamperEffectorDesc_pos1(NxSpringAndDamperEffectorDesc* classPointer, NxVec3 newvalue)
{
    classPointer->pos1 = newvalue;
}

API_EXPORT NxVec3 get_NxSpringAndDamperEffectorDesc_pos1(NxSpringAndDamperEffectorDesc* classPointer)
{
    return classPointer->pos1;
}

API_EXPORT void set_NxSpringAndDamperEffectorDesc_pos2(NxSpringAndDamperEffectorDesc* classPointer, NxVec3 newvalue)
{
    classPointer->pos2 = newvalue;
}

API_EXPORT NxVec3 get_NxSpringAndDamperEffectorDesc_pos2(NxSpringAndDamperEffectorDesc* classPointer)
{
    return classPointer->pos2;
}

API_EXPORT void set_NxSpringAndDamperEffectorDesc_springDistCompressSaturate(NxSpringAndDamperEffectorDesc* classPointer, NxReal newvalue)
{
    classPointer->springDistCompressSaturate = newvalue;
}

API_EXPORT NxReal get_NxSpringAndDamperEffectorDesc_springDistCompressSaturate(NxSpringAndDamperEffectorDesc* classPointer)
{
    return classPointer->springDistCompressSaturate;
}

API_EXPORT void set_NxSpringAndDamperEffectorDesc_springDistRelaxed(NxSpringAndDamperEffectorDesc* classPointer, NxReal newvalue)
{
    classPointer->springDistRelaxed = newvalue;
}

API_EXPORT NxReal get_NxSpringAndDamperEffectorDesc_springDistRelaxed(NxSpringAndDamperEffectorDesc* classPointer)
{
    return classPointer->springDistRelaxed;
}

API_EXPORT void set_NxSpringAndDamperEffectorDesc_springDistStretchSaturate(NxSpringAndDamperEffectorDesc* classPointer, NxReal newvalue)
{
    classPointer->springDistStretchSaturate = newvalue;
}

API_EXPORT NxReal get_NxSpringAndDamperEffectorDesc_springDistStretchSaturate(NxSpringAndDamperEffectorDesc* classPointer)
{
    return classPointer->springDistStretchSaturate;
}

API_EXPORT void set_NxSpringAndDamperEffectorDesc_springMaxCompressForce(NxSpringAndDamperEffectorDesc* classPointer, NxReal newvalue)
{
    classPointer->springMaxCompressForce = newvalue;
}

API_EXPORT NxReal get_NxSpringAndDamperEffectorDesc_springMaxCompressForce(NxSpringAndDamperEffectorDesc* classPointer)
{
    return classPointer->springMaxCompressForce;
}

API_EXPORT void set_NxSpringAndDamperEffectorDesc_springMaxStretchForce(NxSpringAndDamperEffectorDesc* classPointer, NxReal newvalue)
{
    classPointer->springMaxStretchForce = newvalue;
}

API_EXPORT NxReal get_NxSpringAndDamperEffectorDesc_springMaxStretchForce(NxSpringAndDamperEffectorDesc* classPointer)
{
    return classPointer->springMaxStretchForce;
}

API_EXPORT void set_NxSpringAndDamperEffectorDesc_damperVelCompressSaturate(NxSpringAndDamperEffectorDesc* classPointer, NxReal newvalue)
{
    classPointer->damperVelCompressSaturate = newvalue;
}

API_EXPORT NxReal get_NxSpringAndDamperEffectorDesc_damperVelCompressSaturate(NxSpringAndDamperEffectorDesc* classPointer)
{
    return classPointer->damperVelCompressSaturate;
}

API_EXPORT void set_NxSpringAndDamperEffectorDesc_damperVelStretchSaturate(NxSpringAndDamperEffectorDesc* classPointer, NxReal newvalue)
{
    classPointer->damperVelStretchSaturate = newvalue;
}

API_EXPORT NxReal get_NxSpringAndDamperEffectorDesc_damperVelStretchSaturate(NxSpringAndDamperEffectorDesc* classPointer)
{
    return classPointer->damperVelStretchSaturate;
}

API_EXPORT void set_NxSpringAndDamperEffectorDesc_damperMaxCompressForce(NxSpringAndDamperEffectorDesc* classPointer, NxReal newvalue)
{
    classPointer->damperMaxCompressForce = newvalue;
}

API_EXPORT NxReal get_NxSpringAndDamperEffectorDesc_damperMaxCompressForce(NxSpringAndDamperEffectorDesc* classPointer)
{
    return classPointer->damperMaxCompressForce;
}

API_EXPORT void set_NxSpringAndDamperEffectorDesc_damperMaxStretchForce(NxSpringAndDamperEffectorDesc* classPointer, NxReal newvalue)
{
    classPointer->damperMaxStretchForce = newvalue;
}

API_EXPORT NxReal get_NxSpringAndDamperEffectorDesc_damperMaxStretchForce(NxSpringAndDamperEffectorDesc* classPointer)
{
    return classPointer->damperMaxStretchForce;
}

API_EXPORT NxSpringAndDamperEffectorDesc* new_NxSpringAndDamperEffectorDesc(bool do_override)
{
    return (do_override) ? new NxSpringAndDamperEffectorDesc_doxybind() : new NxSpringAndDamperEffectorDesc();
}

API_EXPORT void NxSpringAndDamperEffectorDesc_setToDefault(NxSpringAndDamperEffectorDesc* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxSpringAndDamperEffectorDesc::setToDefault() : classPointer->setToDefault();
}

API_EXPORT bool NxSpringAndDamperEffectorDesc_isValid(NxSpringAndDamperEffectorDesc* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxSpringAndDamperEffectorDesc::isValid() : classPointer->isValid();
}

API_EXPORT void set_NxSpringDesc_spring(NxSpringDesc* classPointer, NxReal newvalue)
{
    classPointer->spring = newvalue;
}

API_EXPORT NxReal get_NxSpringDesc_spring(NxSpringDesc* classPointer)
{
    return classPointer->spring;
}

API_EXPORT void set_NxSpringDesc_damper(NxSpringDesc* classPointer, NxReal newvalue)
{
    classPointer->damper = newvalue;
}

API_EXPORT NxReal get_NxSpringDesc_damper(NxSpringDesc* classPointer)
{
    return classPointer->damper;
}

API_EXPORT void set_NxSpringDesc_targetValue(NxSpringDesc* classPointer, NxReal newvalue)
{
    classPointer->targetValue = newvalue;
}

API_EXPORT NxReal get_NxSpringDesc_targetValue(NxSpringDesc* classPointer)
{
    return classPointer->targetValue;
}

API_EXPORT NxSpringDesc* new_NxSpringDesc(bool do_override)
{
    return new NxSpringDesc();
}

API_EXPORT NxSpringDesc* new_NxSpringDesc_1(bool do_override, NxReal spring, NxReal damper, NxReal targetValue)
{
    return new NxSpringDesc(spring, damper, targetValue);
}

API_EXPORT NxSpringDesc* new_NxSpringDesc_2(bool do_override, NxReal spring, NxReal damper)
{
    return new NxSpringDesc(spring, damper);
}

API_EXPORT NxSpringDesc* new_NxSpringDesc_3(bool do_override, NxReal spring)
{
    return new NxSpringDesc(spring);
}

API_EXPORT void NxSpringDesc_setToDefault(NxSpringDesc* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxSpringDesc::setToDefault() : classPointer->setToDefault();
}

API_EXPORT bool NxSpringDesc_isValid(NxSpringDesc* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxSpringDesc::isValid() : classPointer->isValid();
}

API_EXPORT NxStream* new_NxStream(bool do_override)
{
    return (do_override) ? new NxStream_doxybind() : NULL;
}

API_EXPORT NxU8 NxStream_readByte(NxStream* classPointer, bool call_explicit)
{
    return classPointer->readByte();
}

API_EXPORT NxU16 NxStream_readWord(NxStream* classPointer, bool call_explicit)
{
    return classPointer->readWord();
}

API_EXPORT NxU32 NxStream_readDword(NxStream* classPointer, bool call_explicit)
{
    return classPointer->readDword();
}

API_EXPORT NxF32 NxStream_readFloat(NxStream* classPointer, bool call_explicit)
{
    return classPointer->readFloat();
}

API_EXPORT NxF64 NxStream_readDouble(NxStream* classPointer, bool call_explicit)
{
    return classPointer->readDouble();
}

API_EXPORT void NxStream_readBuffer(NxStream* classPointer, bool call_explicit, void* buffer, NxU32 size)
{
    classPointer->readBuffer(buffer, size);
}

API_EXPORT NxStream* NxStream_storeByte(NxStream* classPointer, bool call_explicit, NxU8 b)
{
    return &classPointer->storeByte(b);
}

API_EXPORT NxStream* NxStream_storeWord(NxStream* classPointer, bool call_explicit, NxU16 w)
{
    return &classPointer->storeWord(w);
}

API_EXPORT NxStream* NxStream_storeDword(NxStream* classPointer, bool call_explicit, NxU32 d)
{
    return &classPointer->storeDword(d);
}

API_EXPORT NxStream* NxStream_storeFloat(NxStream* classPointer, bool call_explicit, NxF32 f)
{
    return &classPointer->storeFloat(f);
}

API_EXPORT NxStream* NxStream_storeDouble(NxStream* classPointer, bool call_explicit, NxF64 f)
{
    return &classPointer->storeDouble(f);
}

API_EXPORT NxStream* NxStream_storeBuffer(NxStream* classPointer, bool call_explicit, void* buffer, NxU32 size)
{
    return &classPointer->storeBuffer(buffer, size);
}

API_EXPORT NxStream* NxStream_storeByte_1(NxStream* classPointer, bool call_explicit, NxI8 b)
{
    return (call_explicit) ? &classPointer->NxStream::storeByte(b) : &classPointer->storeByte(b);
}

API_EXPORT NxStream* NxStream_storeWord_1(NxStream* classPointer, bool call_explicit, NxI16 w)
{
    return (call_explicit) ? &classPointer->NxStream::storeWord(w) : &classPointer->storeWord(w);
}

API_EXPORT NxStream* NxStream_storeDword_1(NxStream* classPointer, bool call_explicit, NxI32 d)
{
    return (call_explicit) ? &classPointer->NxStream::storeDword(d) : &classPointer->storeDword(d);
}

API_EXPORT NxSweepCache* new_NxSweepCache(bool do_override)
{
    return (do_override) ? new NxSweepCache_doxybind() : NULL;
}

API_EXPORT void NxSweepCache_setVolume(NxSweepCache* classPointer, bool call_explicit, NxBox* box)
{
    classPointer->setVolume(*box);
}

API_EXPORT void set_NxSweepQueryHit_t(NxSweepQueryHit* classPointer, NxF32 newvalue)
{
    classPointer->t = newvalue;
}

API_EXPORT NxF32 get_NxSweepQueryHit_t(NxSweepQueryHit* classPointer)
{
    return classPointer->t;
}

API_EXPORT void set_NxSweepQueryHit_hitShape(NxSweepQueryHit* classPointer, NxShape* newvalue)
{
    classPointer->hitShape = newvalue;
}

API_EXPORT NxShape* get_NxSweepQueryHit_hitShape(NxSweepQueryHit* classPointer)
{
    return classPointer->hitShape;
}

API_EXPORT void set_NxSweepQueryHit_sweepShape(NxSweepQueryHit* classPointer, NxShape* newvalue)
{
    classPointer->sweepShape = newvalue;
}

API_EXPORT NxShape* get_NxSweepQueryHit_sweepShape(NxSweepQueryHit* classPointer)
{
    return classPointer->sweepShape;
}

API_EXPORT void set_NxSweepQueryHit_userData(NxSweepQueryHit* classPointer, void* newvalue)
{
    classPointer->userData = newvalue;
}

API_EXPORT void* get_NxSweepQueryHit_userData(NxSweepQueryHit* classPointer)
{
    return classPointer->userData;
}

API_EXPORT void set_NxSweepQueryHit_internalFaceID(NxSweepQueryHit* classPointer, NxU32 newvalue)
{
    classPointer->internalFaceID = newvalue;
}

API_EXPORT NxU32 get_NxSweepQueryHit_internalFaceID(NxSweepQueryHit* classPointer)
{
    return classPointer->internalFaceID;
}

API_EXPORT void set_NxSweepQueryHit_faceID(NxSweepQueryHit* classPointer, NxU32 newvalue)
{
    classPointer->faceID = newvalue;
}

API_EXPORT NxU32 get_NxSweepQueryHit_faceID(NxSweepQueryHit* classPointer)
{
    return classPointer->faceID;
}

API_EXPORT void set_NxSweepQueryHit_point(NxSweepQueryHit* classPointer, NxVec3 newvalue)
{
    classPointer->point = newvalue;
}

API_EXPORT NxVec3 get_NxSweepQueryHit_point(NxSweepQueryHit* classPointer)
{
    return classPointer->point;
}

API_EXPORT void set_NxSweepQueryHit_normal(NxSweepQueryHit* classPointer, NxVec3 newvalue)
{
    classPointer->normal = newvalue;
}

API_EXPORT NxVec3 get_NxSweepQueryHit_normal(NxSweepQueryHit* classPointer)
{
    return classPointer->normal;
}

API_EXPORT void NxTask_execute(NxTask* classPointer, bool call_explicit)
{
    classPointer->execute();
}

API_EXPORT void set_NxTireFunctionDesc_extremumSlip(NxTireFunctionDesc* classPointer, NxReal newvalue)
{
    classPointer->extremumSlip = newvalue;
}

API_EXPORT NxReal get_NxTireFunctionDesc_extremumSlip(NxTireFunctionDesc* classPointer)
{
    return classPointer->extremumSlip;
}

API_EXPORT void set_NxTireFunctionDesc_extremumValue(NxTireFunctionDesc* classPointer, NxReal newvalue)
{
    classPointer->extremumValue = newvalue;
}

API_EXPORT NxReal get_NxTireFunctionDesc_extremumValue(NxTireFunctionDesc* classPointer)
{
    return classPointer->extremumValue;
}

API_EXPORT void set_NxTireFunctionDesc_asymptoteSlip(NxTireFunctionDesc* classPointer, NxReal newvalue)
{
    classPointer->asymptoteSlip = newvalue;
}

API_EXPORT NxReal get_NxTireFunctionDesc_asymptoteSlip(NxTireFunctionDesc* classPointer)
{
    return classPointer->asymptoteSlip;
}

API_EXPORT void set_NxTireFunctionDesc_asymptoteValue(NxTireFunctionDesc* classPointer, NxReal newvalue)
{
    classPointer->asymptoteValue = newvalue;
}

API_EXPORT NxReal get_NxTireFunctionDesc_asymptoteValue(NxTireFunctionDesc* classPointer)
{
    return classPointer->asymptoteValue;
}

API_EXPORT void set_NxTireFunctionDesc_stiffnessFactor(NxTireFunctionDesc* classPointer, NxReal newvalue)
{
    classPointer->stiffnessFactor = newvalue;
}

API_EXPORT NxReal get_NxTireFunctionDesc_stiffnessFactor(NxTireFunctionDesc* classPointer)
{
    return classPointer->stiffnessFactor;
}

API_EXPORT NxTireFunctionDesc* new_NxTireFunctionDesc(bool do_override)
{
    return (do_override) ? new NxTireFunctionDesc_doxybind() : new NxTireFunctionDesc();
}

API_EXPORT void NxTireFunctionDesc_setToDefault(NxTireFunctionDesc* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxTireFunctionDesc::setToDefault() : classPointer->setToDefault();
}

API_EXPORT bool NxTireFunctionDesc_isValid(NxTireFunctionDesc* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxTireFunctionDesc::isValid() : classPointer->isValid();
}

API_EXPORT NxReal NxTireFunctionDesc_hermiteEval(NxTireFunctionDesc* classPointer, bool call_explicit, NxReal t)
{
    return (call_explicit) ? classPointer->NxTireFunctionDesc::hermiteEval(t) : classPointer->hermiteEval(t);
}

API_EXPORT void set_NxTriangle_verts(NxTriangle* classPointer, NxVec3 newvalue[3])
{
    memcpy(&classPointer->verts[0], &newvalue[0], sizeof(NxVec3) * 3);
}

API_EXPORT void get_NxTriangle_verts(NxTriangle* classPointer, NxVec3 newvalue[3])
{
    memcpy(&newvalue[0], &classPointer->verts[0], sizeof(NxVec3) * 3);
}

API_EXPORT NxTriangle* new_NxTriangle(bool do_override)
{
    return new NxTriangle();
}

API_EXPORT NxTriangle* new_NxTriangle_1(bool do_override, NxVec3& p0, NxVec3& p1, NxVec3& p2)
{
    return new NxTriangle(p0, p1, p2);
}

API_EXPORT NxTriangle* new_NxTriangle_2(bool do_override, NxTriangle* triangle)
{
    return new NxTriangle(*triangle);
}

API_EXPORT void NxTriangle_center(NxTriangle* classPointer, bool call_explicit, NxVec3& center)
{
    (call_explicit) ? classPointer->NxTriangle::center(center) : classPointer->center(center);
}

API_EXPORT void NxTriangle_normal(NxTriangle* classPointer, bool call_explicit, NxVec3& _normal)
{
    (call_explicit) ? classPointer->NxTriangle::normal(_normal) : classPointer->normal(_normal);
}

API_EXPORT void NxTriangle_inflate(NxTriangle* classPointer, bool call_explicit, float fatCoeff, bool constantBorder)
{
    (call_explicit) ? classPointer->NxTriangle::inflate(fatCoeff, constantBorder) : classPointer->inflate(fatCoeff, constantBorder);
}

API_EXPORT void set_NxTriangle32_v(NxTriangle32* classPointer, NxU32 newvalue[3])
{
    memcpy(&classPointer->v[0], &newvalue[0], sizeof(NxU32) * 3);
}

API_EXPORT void get_NxTriangle32_v(NxTriangle32* classPointer, NxU32 newvalue[3])
{
    memcpy(&newvalue[0], &classPointer->v[0], sizeof(NxU32) * 3);
}

API_EXPORT NxTriangle32* new_NxTriangle32(bool do_override)
{
    return new NxTriangle32();
}

API_EXPORT NxTriangle32* new_NxTriangle32_1(bool do_override, NxU32 a, NxU32 b, NxU32 c)
{
    return new NxTriangle32(a, b, c);
}

API_EXPORT bool NxTriangleMesh_saveToDesc(NxTriangleMesh* classPointer, bool call_explicit, NxTriangleMeshDesc* desc)
{
    return classPointer->saveToDesc(*desc);
}

API_EXPORT NxU32 NxTriangleMesh_getSubmeshCount(NxTriangleMesh* classPointer, bool call_explicit)
{
    return classPointer->getSubmeshCount();
}

API_EXPORT NxU32 NxTriangleMesh_getCount(NxTriangleMesh* classPointer, bool call_explicit, NxSubmeshIndex submeshIndex, NxInternalArray intArray)
{
    return classPointer->getCount(submeshIndex, intArray);
}

API_EXPORT NxInternalFormat NxTriangleMesh_getFormat(NxTriangleMesh* classPointer, bool call_explicit, NxSubmeshIndex submeshIndex, NxInternalArray intArray)
{
    return classPointer->getFormat(submeshIndex, intArray);
}

API_EXPORT const void* NxTriangleMesh_getBase(NxTriangleMesh* classPointer, bool call_explicit, NxSubmeshIndex submeshIndex, NxInternalArray intArray)
{
    return classPointer->getBase(submeshIndex, intArray);
}

API_EXPORT NxU32 NxTriangleMesh_getStride(NxTriangleMesh* classPointer, bool call_explicit, NxSubmeshIndex submeshIndex, NxInternalArray intArray)
{
    return classPointer->getStride(submeshIndex, intArray);
}

API_EXPORT NxU32 NxTriangleMesh_getPageCount(NxTriangleMesh* classPointer, bool call_explicit)
{
    return classPointer->getPageCount();
}

API_EXPORT NxBounds3* NxTriangleMesh_getPageBBox(NxTriangleMesh* classPointer, bool call_explicit, NxU32 pageIndex)
{
    return &classPointer->getPageBBox(pageIndex);
}

API_EXPORT bool NxTriangleMesh_loadPMap(NxTriangleMesh* classPointer, bool call_explicit, NxPMap* pmap)
{
    return classPointer->loadPMap(*pmap);
}

API_EXPORT bool NxTriangleMesh_hasPMap(NxTriangleMesh* classPointer, bool call_explicit)
{
    return classPointer->hasPMap();
}

API_EXPORT NxU32 NxTriangleMesh_getPMapSize(NxTriangleMesh* classPointer, bool call_explicit)
{
    return classPointer->getPMapSize();
}

API_EXPORT bool NxTriangleMesh_getPMapData(NxTriangleMesh* classPointer, bool call_explicit, NxPMap* pmap)
{
    return classPointer->getPMapData(*pmap);
}

API_EXPORT NxU32 NxTriangleMesh_getPMapDensity(NxTriangleMesh* classPointer, bool call_explicit)
{
    return classPointer->getPMapDensity();
}

API_EXPORT bool NxTriangleMesh_load(NxTriangleMesh* classPointer, bool call_explicit, NxStream* stream)
{
    return classPointer->load(*stream);
}

API_EXPORT NxMaterialIndex NxTriangleMesh_getTriangleMaterial(NxTriangleMesh* classPointer, bool call_explicit, NxTriangleID triangleIndex)
{
    return classPointer->getTriangleMaterial(triangleIndex);
}

API_EXPORT NxU32 NxTriangleMesh_getReferenceCount(NxTriangleMesh* classPointer, bool call_explicit)
{
    return classPointer->getReferenceCount();
}

API_EXPORT void NxTriangleMesh_getMassInformation(NxTriangleMesh* classPointer, bool call_explicit, NxReal& mass, NxMat33& localInertia, NxVec3& localCenterOfMass)
{
    classPointer->getMassInformation(mass, localInertia, localCenterOfMass);
}

API_EXPORT void set_NxTriangleMeshDesc_materialIndexStride(NxTriangleMeshDesc* classPointer, NxU32 newvalue)
{
    classPointer->materialIndexStride = newvalue;
}

API_EXPORT NxU32 get_NxTriangleMeshDesc_materialIndexStride(NxTriangleMeshDesc* classPointer)
{
    return classPointer->materialIndexStride;
}

API_EXPORT void set_NxTriangleMeshDesc_materialIndices(NxTriangleMeshDesc* classPointer, const void* newvalue)
{
    classPointer->materialIndices = newvalue;
}

API_EXPORT const void* get_NxTriangleMeshDesc_materialIndices(NxTriangleMeshDesc* classPointer)
{
    return classPointer->materialIndices;
}

API_EXPORT void set_NxTriangleMeshDesc_heightFieldVerticalAxis(NxTriangleMeshDesc* classPointer, NxHeightFieldAxis newvalue)
{
    classPointer->heightFieldVerticalAxis = newvalue;
}

API_EXPORT NxHeightFieldAxis get_NxTriangleMeshDesc_heightFieldVerticalAxis(NxTriangleMeshDesc* classPointer)
{
    return classPointer->heightFieldVerticalAxis;
}

API_EXPORT void set_NxTriangleMeshDesc_heightFieldVerticalExtent(NxTriangleMeshDesc* classPointer, NxReal newvalue)
{
    classPointer->heightFieldVerticalExtent = newvalue;
}

API_EXPORT NxReal get_NxTriangleMeshDesc_heightFieldVerticalExtent(NxTriangleMeshDesc* classPointer)
{
    return classPointer->heightFieldVerticalExtent;
}

API_EXPORT void set_NxTriangleMeshDesc_pmap(NxTriangleMeshDesc* classPointer, NxPMap* newvalue)
{
    classPointer->pmap = newvalue;
}

API_EXPORT NxPMap* get_NxTriangleMeshDesc_pmap(NxTriangleMeshDesc* classPointer)
{
    return classPointer->pmap;
}

API_EXPORT void set_NxTriangleMeshDesc_convexEdgeThreshold(NxTriangleMeshDesc* classPointer, NxReal newvalue)
{
    classPointer->convexEdgeThreshold = newvalue;
}

API_EXPORT NxReal get_NxTriangleMeshDesc_convexEdgeThreshold(NxTriangleMeshDesc* classPointer)
{
    return classPointer->convexEdgeThreshold;
}

API_EXPORT NxTriangleMeshDesc* new_NxTriangleMeshDesc(bool do_override)
{
    return new NxTriangleMeshDesc();
}

API_EXPORT void NxTriangleMeshDesc_setToDefault(NxTriangleMeshDesc* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxTriangleMeshDesc::setToDefault() : classPointer->setToDefault();
}

API_EXPORT bool NxTriangleMeshDesc_isValid(NxTriangleMeshDesc* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxTriangleMeshDesc::isValid() : classPointer->isValid();
}

API_EXPORT void NxTriangleMeshShape_saveToDesc(NxTriangleMeshShape* classPointer, bool call_explicit, NxTriangleMeshShapeDesc* desc)
{
    classPointer->saveToDesc(*desc);
}

API_EXPORT NxTriangleMesh* NxTriangleMeshShape_getTriangleMesh(NxTriangleMeshShape* classPointer, bool call_explicit)
{
    return &classPointer->getTriangleMesh();
}

API_EXPORT const NxTriangleMesh* NxTriangleMeshShape_getTriangleMesh_1(NxTriangleMeshShape* classPointer, bool call_explicit)
{
    return &classPointer->getTriangleMesh();
}

API_EXPORT NxU32 NxTriangleMeshShape_getTriangle(NxTriangleMeshShape* classPointer, bool call_explicit, NxTriangle* triangle, NxTriangle* edgeTri, NxU32* flags, NxTriangleID triangleIndex, bool worldSpaceTranslation, bool worldSpaceRotation)
{
    return classPointer->getTriangle(*triangle, edgeTri, flags, triangleIndex, worldSpaceTranslation, worldSpaceRotation);
}

API_EXPORT NxU32 NxTriangleMeshShape_getTriangle_1(NxTriangleMeshShape* classPointer, bool call_explicit, NxTriangle* triangle, NxTriangle* edgeTri, NxU32* flags, NxTriangleID triangleIndex, bool worldSpaceTranslation)
{
    return classPointer->getTriangle(*triangle, edgeTri, flags, triangleIndex, worldSpaceTranslation);
}

API_EXPORT NxU32 NxTriangleMeshShape_getTriangle_2(NxTriangleMeshShape* classPointer, bool call_explicit, NxTriangle* triangle, NxTriangle* edgeTri, NxU32* flags, NxTriangleID triangleIndex)
{
    return classPointer->getTriangle(*triangle, edgeTri, flags, triangleIndex);
}

API_EXPORT bool NxTriangleMeshShape_overlapAABBTriangles(NxTriangleMeshShape* classPointer, bool call_explicit, NxBounds3* bounds, NxU32 flags, NxU32& nb, const NxU32*& indices)
{
    return (call_explicit) ? classPointer->NxTriangleMeshShape::overlapAABBTriangles(*bounds, flags, nb, indices) : classPointer->overlapAABBTriangles(*bounds, flags, nb, indices);
}

API_EXPORT bool NxTriangleMeshShape_overlapAABBTrianglesDeprecated(NxTriangleMeshShape* classPointer, bool call_explicit, NxBounds3* bounds, NxU32 flags, NxU32& nb, const NxU32*& indices)
{
    return classPointer->overlapAABBTrianglesDeprecated(*bounds, flags, nb, indices);
}

API_EXPORT bool NxTriangleMeshShape_overlapAABBTriangles_1(NxTriangleMeshShape* classPointer, bool call_explicit, NxBounds3* bounds, NxU32 flags, NxUserEntityReport< NxU32 >* callback)
{
    return classPointer->overlapAABBTriangles(*bounds, flags, callback);
}

API_EXPORT bool NxTriangleMeshShape_mapPageInstance(NxTriangleMeshShape* classPointer, bool call_explicit, NxU32 pageIndex)
{
    return classPointer->mapPageInstance(pageIndex);
}

API_EXPORT void NxTriangleMeshShape_unmapPageInstance(NxTriangleMeshShape* classPointer, bool call_explicit, NxU32 pageIndex)
{
    classPointer->unmapPageInstance(pageIndex);
}

API_EXPORT bool NxTriangleMeshShape_isPageInstanceMapped(NxTriangleMeshShape* classPointer, bool call_explicit, NxU32 pageIndex)
{
    return classPointer->isPageInstanceMapped(pageIndex);
}

API_EXPORT void set_NxTriangleMeshShapeDesc_meshData(NxTriangleMeshShapeDesc* classPointer, NxTriangleMesh* newvalue)
{
    classPointer->meshData = newvalue;
}

API_EXPORT NxTriangleMesh* get_NxTriangleMeshShapeDesc_meshData(NxTriangleMeshShapeDesc* classPointer)
{
    return classPointer->meshData;
}

API_EXPORT void set_NxTriangleMeshShapeDesc_meshFlags(NxTriangleMeshShapeDesc* classPointer, NxU32 newvalue)
{
    classPointer->meshFlags = newvalue;
}

API_EXPORT NxU32 get_NxTriangleMeshShapeDesc_meshFlags(NxTriangleMeshShapeDesc* classPointer)
{
    return classPointer->meshFlags;
}

API_EXPORT void set_NxTriangleMeshShapeDesc_meshPagingMode(NxTriangleMeshShapeDesc* classPointer, NxMeshPagingMode newvalue)
{
    classPointer->meshPagingMode = newvalue;
}

API_EXPORT NxMeshPagingMode get_NxTriangleMeshShapeDesc_meshPagingMode(NxTriangleMeshShapeDesc* classPointer)
{
    return classPointer->meshPagingMode;
}

API_EXPORT NxTriangleMeshShapeDesc* new_NxTriangleMeshShapeDesc(bool do_override)
{
    return (do_override) ? new NxTriangleMeshShapeDesc_doxybind() : new NxTriangleMeshShapeDesc();
}

API_EXPORT void NxTriangleMeshShapeDesc_setToDefault(NxTriangleMeshShapeDesc* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxTriangleMeshShapeDesc::setToDefault() : classPointer->setToDefault();
}

API_EXPORT bool NxTriangleMeshShapeDesc_isValid(NxTriangleMeshShapeDesc* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxTriangleMeshShapeDesc::isValid() : classPointer->isValid();
}

API_EXPORT void NxUserActorPairFiltering_onActorPairs(NxUserActorPairFiltering* classPointer, bool call_explicit, NxActorPairFilter* filterArray, NxU32 arraySize)
{
    classPointer->onActorPairs(filterArray, arraySize);
}

API_EXPORT void* NxUserAllocatorDefault_malloc(NxUserAllocatorDefault* classPointer, bool call_explicit, size_t size, NxMemoryType type)
{
    return (call_explicit) ? classPointer->NxUserAllocatorDefault::malloc(size, type) : classPointer->malloc(size, type);
}

API_EXPORT void* NxUserAllocatorDefault_malloc_1(NxUserAllocatorDefault* classPointer, bool call_explicit, size_t size)
{
    return (call_explicit) ? classPointer->NxUserAllocatorDefault::malloc(size) : classPointer->malloc(size);
}

API_EXPORT void* NxUserAllocatorDefault_mallocDEBUG(NxUserAllocatorDefault* classPointer, bool call_explicit, size_t size, char* fileName, int line, char* className, NxMemoryType type)
{
    return (call_explicit) ? classPointer->NxUserAllocatorDefault::mallocDEBUG(size, fileName, line, className, type) : classPointer->mallocDEBUG(size, fileName, line, className, type);
}

API_EXPORT void* NxUserAllocatorDefault_mallocDEBUG_1(NxUserAllocatorDefault* classPointer, bool call_explicit, size_t size, char* fileName, int line)
{
    return (call_explicit) ? classPointer->NxUserAllocatorDefault::mallocDEBUG(size, fileName, line) : classPointer->mallocDEBUG(size, fileName, line);
}

API_EXPORT void* NxUserAllocatorDefault_realloc(NxUserAllocatorDefault* classPointer, bool call_explicit, void* memory, size_t size)
{
    return (call_explicit) ? classPointer->NxUserAllocatorDefault::realloc(memory, size) : classPointer->realloc(memory, size);
}

API_EXPORT void NxUserAllocatorDefault_free(NxUserAllocatorDefault* classPointer, bool call_explicit, void* memory)
{
    (call_explicit) ? classPointer->NxUserAllocatorDefault::free(memory) : classPointer->free(memory);
}

API_EXPORT void NxUserAllocatorDefault_check(NxUserAllocatorDefault* classPointer, bool call_explicit)
{
    (call_explicit) ? classPointer->NxUserAllocatorDefault::check() : classPointer->check();
}

API_EXPORT bool NxUserContactModify_onContactConstraint(NxUserContactModify* classPointer, bool call_explicit, NxU32& changeFlags, NxShape* shape0, NxShape* shape1, NxU32 featureIndex0, NxU32 featureIndex1, NxUserContactModify::NxContactCallbackData* data)
{
    return classPointer->onContactConstraint(changeFlags, shape0, shape1, featureIndex0, featureIndex1, *data);
}

API_EXPORT void set_NxContactCallbackData_minImpulse(NxUserContactModify::NxContactCallbackData* classPointer, NxReal newvalue)
{
    classPointer->minImpulse = newvalue;
}

API_EXPORT NxReal get_NxContactCallbackData_minImpulse(NxUserContactModify::NxContactCallbackData* classPointer)
{
    return classPointer->minImpulse;
}

API_EXPORT void set_NxContactCallbackData_maxImpulse(NxUserContactModify::NxContactCallbackData* classPointer, NxReal newvalue)
{
    classPointer->maxImpulse = newvalue;
}

API_EXPORT NxReal get_NxContactCallbackData_maxImpulse(NxUserContactModify::NxContactCallbackData* classPointer)
{
    return classPointer->maxImpulse;
}

API_EXPORT void set_NxContactCallbackData_error(NxUserContactModify::NxContactCallbackData* classPointer, NxVec3 newvalue)
{
    classPointer->error = newvalue;
}

API_EXPORT NxVec3 get_NxContactCallbackData_error(NxUserContactModify::NxContactCallbackData* classPointer)
{
    return classPointer->error;
}

API_EXPORT void set_NxContactCallbackData_target(NxUserContactModify::NxContactCallbackData* classPointer, NxVec3 newvalue)
{
    classPointer->target = newvalue;
}

API_EXPORT NxVec3 get_NxContactCallbackData_target(NxUserContactModify::NxContactCallbackData* classPointer)
{
    return classPointer->target;
}

API_EXPORT void set_NxContactCallbackData_localpos0(NxUserContactModify::NxContactCallbackData* classPointer, NxVec3 newvalue)
{
    classPointer->localpos0 = newvalue;
}

API_EXPORT NxVec3 get_NxContactCallbackData_localpos0(NxUserContactModify::NxContactCallbackData* classPointer)
{
    return classPointer->localpos0;
}

API_EXPORT void set_NxContactCallbackData_localpos1(NxUserContactModify::NxContactCallbackData* classPointer, NxVec3 newvalue)
{
    classPointer->localpos1 = newvalue;
}

API_EXPORT NxVec3 get_NxContactCallbackData_localpos1(NxUserContactModify::NxContactCallbackData* classPointer)
{
    return classPointer->localpos1;
}

API_EXPORT void set_NxContactCallbackData_localorientation0(NxUserContactModify::NxContactCallbackData* classPointer, NxQuat newvalue)
{
    classPointer->localorientation0 = newvalue;
}

API_EXPORT NxQuat get_NxContactCallbackData_localorientation0(NxUserContactModify::NxContactCallbackData* classPointer)
{
    return classPointer->localorientation0;
}

API_EXPORT void set_NxContactCallbackData_localorientation1(NxUserContactModify::NxContactCallbackData* classPointer, NxQuat newvalue)
{
    classPointer->localorientation1 = newvalue;
}

API_EXPORT NxQuat get_NxContactCallbackData_localorientation1(NxUserContactModify::NxContactCallbackData* classPointer)
{
    return classPointer->localorientation1;
}

API_EXPORT void set_NxContactCallbackData_staticFriction0(NxUserContactModify::NxContactCallbackData* classPointer, NxReal newvalue)
{
    classPointer->staticFriction0 = newvalue;
}

API_EXPORT NxReal get_NxContactCallbackData_staticFriction0(NxUserContactModify::NxContactCallbackData* classPointer)
{
    return classPointer->staticFriction0;
}

API_EXPORT void set_NxContactCallbackData_staticFriction1(NxUserContactModify::NxContactCallbackData* classPointer, NxReal newvalue)
{
    classPointer->staticFriction1 = newvalue;
}

API_EXPORT NxReal get_NxContactCallbackData_staticFriction1(NxUserContactModify::NxContactCallbackData* classPointer)
{
    return classPointer->staticFriction1;
}

API_EXPORT void set_NxContactCallbackData_dynamicFriction0(NxUserContactModify::NxContactCallbackData* classPointer, NxReal newvalue)
{
    classPointer->dynamicFriction0 = newvalue;
}

API_EXPORT NxReal get_NxContactCallbackData_dynamicFriction0(NxUserContactModify::NxContactCallbackData* classPointer)
{
    return classPointer->dynamicFriction0;
}

API_EXPORT void set_NxContactCallbackData_dynamicFriction1(NxUserContactModify::NxContactCallbackData* classPointer, NxReal newvalue)
{
    classPointer->dynamicFriction1 = newvalue;
}

API_EXPORT NxReal get_NxContactCallbackData_dynamicFriction1(NxUserContactModify::NxContactCallbackData* classPointer)
{
    return classPointer->dynamicFriction1;
}

API_EXPORT void set_NxContactCallbackData_restitution(NxUserContactModify::NxContactCallbackData* classPointer, NxReal newvalue)
{
    classPointer->restitution = newvalue;
}

API_EXPORT NxReal get_NxContactCallbackData_restitution(NxUserContactModify::NxContactCallbackData* classPointer)
{
    return classPointer->restitution;
}

API_EXPORT void NxUserContactReport_onContactNotify(NxUserContactReport* classPointer, bool call_explicit, NxContactPair* pair, NxU32 events)
{
    classPointer->onContactNotify(*pair, events);
}

API_EXPORT NxControllerAction NxUserControllerHitReport_onShapeHit(NxUserControllerHitReport* classPointer, bool call_explicit, NxControllerShapeHit* hit)
{
    return classPointer->onShapeHit(*hit);
}

API_EXPORT NxControllerAction NxUserControllerHitReport_onControllerHit(NxUserControllerHitReport* classPointer, bool call_explicit, NxControllersHit* hit)
{
    return classPointer->onControllerHit(*hit);
}

API_EXPORT bool NxUserNotify_onJointBreak(NxUserNotify* classPointer, bool call_explicit, NxReal breakingImpulse, NxJoint* brokenJoint)
{
    return classPointer->onJointBreak(breakingImpulse, *brokenJoint);
}

API_EXPORT void NxUserNotify_onWake(NxUserNotify* classPointer, bool call_explicit, NxActor** actors, NxU32 count)
{
    classPointer->onWake(actors, count);
}

API_EXPORT void NxUserNotify_onSleep(NxUserNotify* classPointer, bool call_explicit, NxActor** actors, NxU32 count)
{
    classPointer->onSleep(actors, count);
}

API_EXPORT void NxUserOutputStream_reportError(NxUserOutputStream* classPointer, bool call_explicit, NxErrorCode code, char* message, char* file, int line)
{
    classPointer->reportError(code, message, file, line);
}

API_EXPORT NxAssertResponse NxUserOutputStream_reportAssertViolation(NxUserOutputStream* classPointer, bool call_explicit, char* message, char* file, int line)
{
    return classPointer->reportAssertViolation(message, file, line);
}

API_EXPORT void NxUserOutputStream_print(NxUserOutputStream* classPointer, bool call_explicit, char* message)
{
    classPointer->print(message);
}

API_EXPORT bool NxUserRaycastReport_onHit(NxUserRaycastReport* classPointer, bool call_explicit, NxRaycastHit* hits)
{
    return classPointer->onHit(*hits);
}

API_EXPORT void NxUserScheduler_addTask(NxUserScheduler* classPointer, bool call_explicit, NxTask* task)
{
    classPointer->addTask(task);
}

API_EXPORT void NxUserScheduler_addBackgroundTask(NxUserScheduler* classPointer, bool call_explicit, NxTask* task)
{
    classPointer->addBackgroundTask(task);
}

API_EXPORT void NxUserScheduler_waitTasksComplete(NxUserScheduler* classPointer, bool call_explicit)
{
    classPointer->waitTasksComplete();
}

API_EXPORT void NxUserTriggerReport_onTrigger(NxUserTriggerReport* classPointer, bool call_explicit, NxShape* triggerShape, NxShape* otherShape, NxTriggerFlag status)
{
    classPointer->onTrigger(*triggerShape, *otherShape, status);
}

API_EXPORT bool NxUserWheelContactModify_onWheelContact(NxUserWheelContactModify* classPointer, bool call_explicit, NxWheelShape* wheelShape, NxVec3& contactPoint, NxVec3& contactNormal, NxReal& contactPosition, NxReal& normalForce, NxShape* otherShape, NxMaterialIndex& otherShapeMaterialIndex, NxU32 otherShapeFeatureIndex)
{
    return classPointer->onWheelContact(wheelShape, contactPoint, contactNormal, contactPosition, normalForce, otherShape, otherShapeMaterialIndex, otherShapeFeatureIndex);
}

API_EXPORT bool NxUtilLib_NxBoxContainsPoint(NxUtilLib* classPointer, bool call_explicit, NxBox* box, NxVec3& p)
{
    return classPointer->NxBoxContainsPoint(*box, p);
}

API_EXPORT void NxUtilLib_NxCreateBox(NxUtilLib* classPointer, bool call_explicit, NxBox* box, NxBounds3* aabb, NxMat34& mat)
{
    classPointer->NxCreateBox(*box, *aabb, mat);
}

API_EXPORT bool NxUtilLib_NxComputeBoxPlanes(NxUtilLib* classPointer, bool call_explicit, NxBox* box, NxPlane* planes)
{
    return classPointer->NxComputeBoxPlanes(*box, planes);
}

API_EXPORT bool NxUtilLib_NxComputeBoxPoints(NxUtilLib* classPointer, bool call_explicit, NxBox* box, NxVec3* pts)
{
    return classPointer->NxComputeBoxPoints(*box, pts);
}

API_EXPORT bool NxUtilLib_NxComputeBoxVertexNormals(NxUtilLib* classPointer, bool call_explicit, NxBox* box, NxVec3* pts)
{
    return classPointer->NxComputeBoxVertexNormals(*box, pts);
}

API_EXPORT const NxU32* NxUtilLib_NxGetBoxEdges(NxUtilLib* classPointer, bool call_explicit)
{
    return classPointer->NxGetBoxEdges();
}

API_EXPORT const NxI32* NxUtilLib_NxGetBoxEdgesAxes(NxUtilLib* classPointer, bool call_explicit)
{
    return classPointer->NxGetBoxEdgesAxes();
}

API_EXPORT const NxU32* NxUtilLib_NxGetBoxTriangles(NxUtilLib* classPointer, bool call_explicit)
{
    return classPointer->NxGetBoxTriangles();
}

API_EXPORT const NxVec3* NxUtilLib_NxGetBoxLocalEdgeNormals(NxUtilLib* classPointer, bool call_explicit)
{
    return classPointer->NxGetBoxLocalEdgeNormals();
}

API_EXPORT void NxUtilLib_NxComputeBoxWorldEdgeNormal(NxUtilLib* classPointer, bool call_explicit, NxBox* box, NxU32 edge_index, NxVec3& world_normal)
{
    classPointer->NxComputeBoxWorldEdgeNormal(*box, edge_index, world_normal);
}

API_EXPORT void NxUtilLib_NxComputeCapsuleAroundBox(NxUtilLib* classPointer, bool call_explicit, NxBox* box, NxCapsule* capsule)
{
    classPointer->NxComputeCapsuleAroundBox(*box, *capsule);
}

API_EXPORT bool NxUtilLib_NxIsBoxAInsideBoxB(NxUtilLib* classPointer, bool call_explicit, NxBox* a, NxBox* b)
{
    return classPointer->NxIsBoxAInsideBoxB(*a, *b);
}

API_EXPORT const NxU32* NxUtilLib_NxGetBoxQuads(NxUtilLib* classPointer, bool call_explicit)
{
    return classPointer->NxGetBoxQuads();
}

API_EXPORT const NxU32* NxUtilLib_NxBoxVertexToQuad(NxUtilLib* classPointer, bool call_explicit, NxU32 vertexIndex)
{
    return classPointer->NxBoxVertexToQuad(vertexIndex);
}

API_EXPORT void NxUtilLib_NxComputeBoxAroundCapsule(NxUtilLib* classPointer, bool call_explicit, NxCapsule* capsule, NxBox* box)
{
    classPointer->NxComputeBoxAroundCapsule(*capsule, *box);
}

API_EXPORT void NxUtilLib_NxSetFPUPrecision24(NxUtilLib* classPointer, bool call_explicit)
{
    classPointer->NxSetFPUPrecision24();
}

API_EXPORT void NxUtilLib_NxSetFPUPrecision53(NxUtilLib* classPointer, bool call_explicit)
{
    classPointer->NxSetFPUPrecision53();
}

API_EXPORT void NxUtilLib_NxSetFPUPrecision64(NxUtilLib* classPointer, bool call_explicit)
{
    classPointer->NxSetFPUPrecision64();
}

API_EXPORT void NxUtilLib_NxSetFPURoundingChop(NxUtilLib* classPointer, bool call_explicit)
{
    classPointer->NxSetFPURoundingChop();
}

API_EXPORT void NxUtilLib_NxSetFPURoundingUp(NxUtilLib* classPointer, bool call_explicit)
{
    classPointer->NxSetFPURoundingUp();
}

API_EXPORT void NxUtilLib_NxSetFPURoundingDown(NxUtilLib* classPointer, bool call_explicit)
{
    classPointer->NxSetFPURoundingDown();
}

API_EXPORT void NxUtilLib_NxSetFPURoundingNear(NxUtilLib* classPointer, bool call_explicit)
{
    classPointer->NxSetFPURoundingNear();
}

API_EXPORT void NxUtilLib_NxSetFPUExceptions(NxUtilLib* classPointer, bool call_explicit, bool b)
{
    classPointer->NxSetFPUExceptions(b);
}

API_EXPORT int NxUtilLib_NxIntChop(NxUtilLib* classPointer, bool call_explicit, NxF32& f)
{
    return classPointer->NxIntChop(f);
}

API_EXPORT int NxUtilLib_NxIntFloor(NxUtilLib* classPointer, bool call_explicit, NxF32& f)
{
    return classPointer->NxIntFloor(f);
}

API_EXPORT int NxUtilLib_NxIntCeil(NxUtilLib* classPointer, bool call_explicit, NxF32& f)
{
    return classPointer->NxIntCeil(f);
}

API_EXPORT NxF32 NxUtilLib_NxComputeDistanceSquared(NxUtilLib* classPointer, bool call_explicit, NxRay* ray, NxVec3& point, NxF32* t)
{
    return classPointer->NxComputeDistanceSquared(*ray, point, t);
}

API_EXPORT NxF32 NxUtilLib_NxComputeSquareDistance(NxUtilLib* classPointer, bool call_explicit, NxSegment* seg, NxVec3& point, NxF32* t)
{
    return classPointer->NxComputeSquareDistance(*seg, point, t);
}

API_EXPORT NxBSphereMethod NxUtilLib_NxComputeSphere(NxUtilLib* classPointer, bool call_explicit, NxSphere* sphere, unsigned nb_verts, NxVec3* verts)
{
    return classPointer->NxComputeSphere(*sphere, nb_verts, verts);
}

API_EXPORT bool NxUtilLib_NxFastComputeSphere(NxUtilLib* classPointer, bool call_explicit, NxSphere* sphere, unsigned nb_verts, NxVec3* verts)
{
    return classPointer->NxFastComputeSphere(*sphere, nb_verts, verts);
}

API_EXPORT void NxUtilLib_NxMergeSpheres(NxUtilLib* classPointer, bool call_explicit, NxSphere* merged, NxSphere* sphere0, NxSphere* sphere1)
{
    classPointer->NxMergeSpheres(*merged, *sphere0, *sphere1);
}

API_EXPORT void NxUtilLib_NxNormalToTangents(NxUtilLib* classPointer, bool call_explicit, NxVec3& n, NxVec3& t1, NxVec3& t2)
{
    classPointer->NxNormalToTangents(n, t1, t2);
}

API_EXPORT bool NxUtilLib_NxDiagonalizeInertiaTensor(NxUtilLib* classPointer, bool call_explicit, NxMat33& denseInertia, NxVec3& diagonalInertia, NxMat33& rotation)
{
    return classPointer->NxDiagonalizeInertiaTensor(denseInertia, diagonalInertia, rotation);
}

API_EXPORT void NxUtilLib_NxFindRotationMatrix(NxUtilLib* classPointer, bool call_explicit, NxVec3& x, NxVec3& b, NxMat33& M)
{
    classPointer->NxFindRotationMatrix(x, b, M);
}

API_EXPORT void NxUtilLib_NxComputeBounds(NxUtilLib* classPointer, bool call_explicit, NxVec3& min, NxVec3& max, NxU32 nbVerts, NxVec3* verts)
{
    classPointer->NxComputeBounds(min, max, nbVerts, verts);
}

API_EXPORT NxU32 NxUtilLib_NxCrc32(NxUtilLib* classPointer, bool call_explicit, void* buffer, NxU32 nbBytes)
{
    return classPointer->NxCrc32(buffer, nbBytes);
}

API_EXPORT NxReal NxUtilLib_NxComputeSphereMass(NxUtilLib* classPointer, bool call_explicit, NxReal radius, NxReal density)
{
    return classPointer->NxComputeSphereMass(radius, density);
}

API_EXPORT NxReal NxUtilLib_NxComputeSphereDensity(NxUtilLib* classPointer, bool call_explicit, NxReal radius, NxReal mass)
{
    return classPointer->NxComputeSphereDensity(radius, mass);
}

API_EXPORT NxReal NxUtilLib_NxComputeBoxMass(NxUtilLib* classPointer, bool call_explicit, NxVec3& extents, NxReal density)
{
    return classPointer->NxComputeBoxMass(extents, density);
}

API_EXPORT NxReal NxUtilLib_NxComputeBoxDensity(NxUtilLib* classPointer, bool call_explicit, NxVec3& extents, NxReal mass)
{
    return classPointer->NxComputeBoxDensity(extents, mass);
}

API_EXPORT NxReal NxUtilLib_NxComputeEllipsoidMass(NxUtilLib* classPointer, bool call_explicit, NxVec3& extents, NxReal density)
{
    return classPointer->NxComputeEllipsoidMass(extents, density);
}

API_EXPORT NxReal NxUtilLib_NxComputeEllipsoidDensity(NxUtilLib* classPointer, bool call_explicit, NxVec3& extents, NxReal mass)
{
    return classPointer->NxComputeEllipsoidDensity(extents, mass);
}

API_EXPORT NxReal NxUtilLib_NxComputeCylinderMass(NxUtilLib* classPointer, bool call_explicit, NxReal radius, NxReal length, NxReal density)
{
    return classPointer->NxComputeCylinderMass(radius, length, density);
}

API_EXPORT NxReal NxUtilLib_NxComputeCylinderDensity(NxUtilLib* classPointer, bool call_explicit, NxReal radius, NxReal length, NxReal mass)
{
    return classPointer->NxComputeCylinderDensity(radius, length, mass);
}

API_EXPORT NxReal NxUtilLib_NxComputeConeMass(NxUtilLib* classPointer, bool call_explicit, NxReal radius, NxReal length, NxReal density)
{
    return classPointer->NxComputeConeMass(radius, length, density);
}

API_EXPORT NxReal NxUtilLib_NxComputeConeDensity(NxUtilLib* classPointer, bool call_explicit, NxReal radius, NxReal length, NxReal mass)
{
    return classPointer->NxComputeConeDensity(radius, length, mass);
}

API_EXPORT void NxUtilLib_NxComputeBoxInertiaTensor(NxUtilLib* classPointer, bool call_explicit, NxVec3& diagInertia, NxReal mass, NxReal xlength, NxReal ylength, NxReal zlength)
{
    classPointer->NxComputeBoxInertiaTensor(diagInertia, mass, xlength, ylength, zlength);
}

API_EXPORT void NxUtilLib_NxComputeSphereInertiaTensor(NxUtilLib* classPointer, bool call_explicit, NxVec3& diagInertia, NxReal mass, NxReal radius, bool hollow)
{
    classPointer->NxComputeSphereInertiaTensor(diagInertia, mass, radius, hollow);
}

API_EXPORT void NxUtilLib_NxJointDesc_SetGlobalAnchor(NxUtilLib* classPointer, bool call_explicit, NxJointDesc* dis, NxVec3& wsAnchor)
{
    classPointer->NxJointDesc_SetGlobalAnchor(*dis, wsAnchor);
}

API_EXPORT void NxUtilLib_NxJointDesc_SetGlobalAxis(NxUtilLib* classPointer, bool call_explicit, NxJointDesc* dis, NxVec3& wsAxis)
{
    classPointer->NxJointDesc_SetGlobalAxis(*dis, wsAxis);
}

API_EXPORT bool NxUtilLib_NxBoxBoxIntersect(NxUtilLib* classPointer, bool call_explicit, NxVec3& extents0, NxVec3& center0, NxMat33& rotation0, NxVec3& extents1, NxVec3& center1, NxMat33& rotation1, bool fullTest)
{
    return classPointer->NxBoxBoxIntersect(extents0, center0, rotation0, extents1, center1, rotation1, fullTest);
}

API_EXPORT bool NxUtilLib_NxTriBoxIntersect(NxUtilLib* classPointer, bool call_explicit, NxVec3& vertex0, NxVec3& vertex1, NxVec3& vertex2, NxVec3& center, NxVec3& extents)
{
    return classPointer->NxTriBoxIntersect(vertex0, vertex1, vertex2, center, extents);
}

API_EXPORT NxSepAxis NxUtilLib_NxSeparatingAxis(NxUtilLib* classPointer, bool call_explicit, NxVec3& extents0, NxVec3& center0, NxMat33& rotation0, NxVec3& extents1, NxVec3& center1, NxMat33& rotation1, bool fullTest)
{
    return classPointer->NxSeparatingAxis(extents0, center0, rotation0, extents1, center1, rotation1, fullTest);
}

API_EXPORT NxSepAxis NxUtilLib_NxSeparatingAxis_1(NxUtilLib* classPointer, bool call_explicit, NxVec3& extents0, NxVec3& center0, NxMat33& rotation0, NxVec3& extents1, NxVec3& center1, NxMat33& rotation1)
{
    return classPointer->NxSeparatingAxis(extents0, center0, rotation0, extents1, center1, rotation1);
}

API_EXPORT void NxUtilLib_NxSegmentPlaneIntersect(NxUtilLib* classPointer, bool call_explicit, NxVec3& v1, NxVec3& v2, NxPlane* plane, NxReal& dist, NxVec3& pointOnPlane)
{
    classPointer->NxSegmentPlaneIntersect(v1, v2, *plane, dist, pointOnPlane);
}

API_EXPORT bool NxUtilLib_NxRayPlaneIntersect(NxUtilLib* classPointer, bool call_explicit, NxRay* ray, NxPlane* plane, NxReal& dist, NxVec3& pointOnPlane)
{
    return classPointer->NxRayPlaneIntersect(*ray, *plane, dist, pointOnPlane);
}

API_EXPORT bool NxUtilLib_NxRaySphereIntersect(NxUtilLib* classPointer, bool call_explicit, NxVec3& origin, NxVec3& dir, NxReal length, NxVec3& center, NxReal radius, NxReal& hit_time, NxVec3& hit_pos)
{
    return classPointer->NxRaySphereIntersect(origin, dir, length, center, radius, hit_time, hit_pos);
}

API_EXPORT bool NxUtilLib_NxSegmentBoxIntersect(NxUtilLib* classPointer, bool call_explicit, NxVec3& p1, NxVec3& p2, NxVec3& bbox_min, NxVec3& bbox_max, NxVec3& intercept)
{
    return classPointer->NxSegmentBoxIntersect(p1, p2, bbox_min, bbox_max, intercept);
}

API_EXPORT bool NxUtilLib_NxRayAABBIntersect(NxUtilLib* classPointer, bool call_explicit, NxVec3& min, NxVec3& max, NxVec3& origin, NxVec3& dir, NxVec3& coord)
{
    return classPointer->NxRayAABBIntersect(min, max, origin, dir, coord);
}

API_EXPORT NxU32 NxUtilLib_NxRayAABBIntersect2(NxUtilLib* classPointer, bool call_explicit, NxVec3& min, NxVec3& max, NxVec3& origin, NxVec3& dir, NxVec3& coord, NxReal& t)
{
    return classPointer->NxRayAABBIntersect2(min, max, origin, dir, coord, t);
}

API_EXPORT bool NxUtilLib_NxSegmentOBBIntersect(NxUtilLib* classPointer, bool call_explicit, NxVec3& p0, NxVec3& p1, NxVec3& center, NxVec3& extents, NxMat33& rot)
{
    return classPointer->NxSegmentOBBIntersect(p0, p1, center, extents, rot);
}

API_EXPORT bool NxUtilLib_NxSegmentAABBIntersect(NxUtilLib* classPointer, bool call_explicit, NxVec3& p0, NxVec3& p1, NxVec3& min, NxVec3& max)
{
    return classPointer->NxSegmentAABBIntersect(p0, p1, min, max);
}

API_EXPORT bool NxUtilLib_NxRayOBBIntersect(NxUtilLib* classPointer, bool call_explicit, NxRay* ray, NxVec3& center, NxVec3& extents, NxMat33& rot)
{
    return classPointer->NxRayOBBIntersect(*ray, center, extents, rot);
}

API_EXPORT NxU32 NxUtilLib_NxRayCapsuleIntersect(NxUtilLib* classPointer, bool call_explicit, NxVec3& origin, NxVec3& dir, NxCapsule* capsule, NxReal t[2])
{
    return classPointer->NxRayCapsuleIntersect(origin, dir, *capsule, t);
}

API_EXPORT bool NxUtilLib_NxSweptSpheresIntersect(NxUtilLib* classPointer, bool call_explicit, NxSphere* sphere0, NxVec3& velocity0, NxSphere* sphere1, NxVec3& velocity1)
{
    return classPointer->NxSweptSpheresIntersect(*sphere0, velocity0, *sphere1, velocity1);
}

API_EXPORT bool NxUtilLib_NxRayTriIntersect(NxUtilLib* classPointer, bool call_explicit, NxVec3& orig, NxVec3& dir, NxVec3& vert0, NxVec3& vert1, NxVec3& vert2, float& t, float& u, float& v, bool cull)
{
    return classPointer->NxRayTriIntersect(orig, dir, vert0, vert1, vert2, t, u, v, cull);
}

API_EXPORT bool NxUtilLib_NxBuildSmoothNormals(NxUtilLib* classPointer, bool call_explicit, NxU32 nbTris, NxU32 nbVerts, NxVec3* verts, NxU32* dFaces, NxU16* wFaces, NxVec3* normals, bool flip)
{
    return classPointer->NxBuildSmoothNormals(nbTris, nbVerts, verts, dFaces, wFaces, normals, flip);
}

API_EXPORT bool NxUtilLib_NxBuildSmoothNormals_1(NxUtilLib* classPointer, bool call_explicit, NxU32 nbTris, NxU32 nbVerts, NxVec3* verts, NxU32* dFaces, NxU16* wFaces, NxVec3* normals)
{
    return classPointer->NxBuildSmoothNormals(nbTris, nbVerts, verts, dFaces, wFaces, normals);
}

API_EXPORT bool NxUtilLib_NxSweepBoxCapsule(NxUtilLib* classPointer, bool call_explicit, NxBox* box, NxCapsule* lss, NxVec3& dir, float length, float& min_dist, NxVec3& normal)
{
    return classPointer->NxSweepBoxCapsule(*box, *lss, dir, length, min_dist, normal);
}

API_EXPORT bool NxUtilLib_NxSweepBoxSphere(NxUtilLib* classPointer, bool call_explicit, NxBox* box, NxSphere* sphere, NxVec3& dir, float length, float& min_dist, NxVec3& normal)
{
    return classPointer->NxSweepBoxSphere(*box, *sphere, dir, length, min_dist, normal);
}

API_EXPORT bool NxUtilLib_NxSweepCapsuleCapsule(NxUtilLib* classPointer, bool call_explicit, NxCapsule* lss0, NxCapsule* lss1, NxVec3& dir, float length, float& min_dist, NxVec3& ip, NxVec3& normal)
{
    return classPointer->NxSweepCapsuleCapsule(*lss0, *lss1, dir, length, min_dist, ip, normal);
}

API_EXPORT bool NxUtilLib_NxSweepSphereCapsule(NxUtilLib* classPointer, bool call_explicit, NxSphere* sphere, NxCapsule* lss, NxVec3& dir, float length, float& min_dist, NxVec3& ip, NxVec3& normal)
{
    return classPointer->NxSweepSphereCapsule(*sphere, *lss, dir, length, min_dist, ip, normal);
}

API_EXPORT bool NxUtilLib_NxSweepBoxBox(NxUtilLib* classPointer, bool call_explicit, NxBox* box0, NxBox* box1, NxVec3& dir, float length, NxVec3& ip, NxVec3& normal, float& min_dist)
{
    return classPointer->NxSweepBoxBox(*box0, *box1, dir, length, ip, normal, min_dist);
}

API_EXPORT bool NxUtilLib_NxSweepBoxTriangles(NxUtilLib* classPointer, bool call_explicit, NxU32 nb_tris, NxTriangle* triangles, NxTriangle* edge_triangles, NxU32* edge_flags, NxBounds3* box, NxVec3& dir, float length, NxVec3& hit, NxVec3& normal, float& d, NxU32& index, NxU32* cachedIndex)
{
    return classPointer->NxSweepBoxTriangles(nb_tris, triangles, edge_triangles, edge_flags, *box, dir, length, hit, normal, d, index, cachedIndex);
}

API_EXPORT bool NxUtilLib_NxSweepBoxTriangles_1(NxUtilLib* classPointer, bool call_explicit, NxU32 nb_tris, NxTriangle* triangles, NxTriangle* edge_triangles, NxU32* edge_flags, NxBounds3* box, NxVec3& dir, float length, NxVec3& hit, NxVec3& normal, float& d, NxU32& index)
{
    return classPointer->NxSweepBoxTriangles(nb_tris, triangles, edge_triangles, edge_flags, *box, dir, length, hit, normal, d, index);
}

API_EXPORT bool NxUtilLib_NxSweepCapsuleTriangles(NxUtilLib* classPointer, bool call_explicit, NxU32 up_direction, NxU32 nb_tris, NxTriangle* triangles, NxU32* edge_flags, NxVec3& center, float radius, float height, NxVec3& dir, float length, NxVec3& hit, NxVec3& normal, float& d, NxU32& index, NxU32* cachedIndex)
{
    return classPointer->NxSweepCapsuleTriangles(up_direction, nb_tris, triangles, edge_flags, center, radius, height, dir, length, hit, normal, d, index, cachedIndex);
}

API_EXPORT bool NxUtilLib_NxSweepCapsuleTriangles_1(NxUtilLib* classPointer, bool call_explicit, NxU32 up_direction, NxU32 nb_tris, NxTriangle* triangles, NxU32* edge_flags, NxVec3& center, float radius, float height, NxVec3& dir, float length, NxVec3& hit, NxVec3& normal, float& d, NxU32& index)
{
    return classPointer->NxSweepCapsuleTriangles(up_direction, nb_tris, triangles, edge_flags, center, radius, height, dir, length, hit, normal, d, index);
}

API_EXPORT float NxUtilLib_NxPointOBBSqrDist(NxUtilLib* classPointer, bool call_explicit, NxVec3& point, NxVec3& center, NxVec3& extents, NxMat33& rot, NxVec3* params)
{
    return classPointer->NxPointOBBSqrDist(point, center, extents, rot, params);
}

API_EXPORT float NxUtilLib_NxSegmentOBBSqrDist(NxUtilLib* classPointer, bool call_explicit, NxSegment* segment, NxVec3& c0, NxVec3& e0, NxMat33& r0, float* t, NxVec3* p)
{
    return classPointer->NxSegmentOBBSqrDist(*segment, c0, e0, r0, t, p);
}

API_EXPORT void set_NxWheelContactData_contactPoint(NxWheelContactData* classPointer, NxVec3 newvalue)
{
    classPointer->contactPoint = newvalue;
}

API_EXPORT NxVec3 get_NxWheelContactData_contactPoint(NxWheelContactData* classPointer)
{
    return classPointer->contactPoint;
}

API_EXPORT void set_NxWheelContactData_contactNormal(NxWheelContactData* classPointer, NxVec3 newvalue)
{
    classPointer->contactNormal = newvalue;
}

API_EXPORT NxVec3 get_NxWheelContactData_contactNormal(NxWheelContactData* classPointer)
{
    return classPointer->contactNormal;
}

API_EXPORT void set_NxWheelContactData_longitudalDirection(NxWheelContactData* classPointer, NxVec3 newvalue)
{
    classPointer->longitudalDirection = newvalue;
}

API_EXPORT NxVec3 get_NxWheelContactData_longitudalDirection(NxWheelContactData* classPointer)
{
    return classPointer->longitudalDirection;
}

API_EXPORT void set_NxWheelContactData_lateralDirection(NxWheelContactData* classPointer, NxVec3 newvalue)
{
    classPointer->lateralDirection = newvalue;
}

API_EXPORT NxVec3 get_NxWheelContactData_lateralDirection(NxWheelContactData* classPointer)
{
    return classPointer->lateralDirection;
}

API_EXPORT void set_NxWheelContactData_contactForce(NxWheelContactData* classPointer, NxReal newvalue)
{
    classPointer->contactForce = newvalue;
}

API_EXPORT NxReal get_NxWheelContactData_contactForce(NxWheelContactData* classPointer)
{
    return classPointer->contactForce;
}

API_EXPORT void set_NxWheelContactData_longitudalSlip(NxWheelContactData* classPointer, NxReal newvalue)
{
    classPointer->longitudalSlip = newvalue;
}

API_EXPORT NxReal get_NxWheelContactData_longitudalSlip(NxWheelContactData* classPointer)
{
    return classPointer->longitudalSlip;
}

API_EXPORT void set_NxWheelContactData_lateralSlip(NxWheelContactData* classPointer, NxReal newvalue)
{
    classPointer->lateralSlip = newvalue;
}

API_EXPORT NxReal get_NxWheelContactData_lateralSlip(NxWheelContactData* classPointer)
{
    return classPointer->lateralSlip;
}

API_EXPORT void set_NxWheelContactData_longitudalImpulse(NxWheelContactData* classPointer, NxReal newvalue)
{
    classPointer->longitudalImpulse = newvalue;
}

API_EXPORT NxReal get_NxWheelContactData_longitudalImpulse(NxWheelContactData* classPointer)
{
    return classPointer->longitudalImpulse;
}

API_EXPORT void set_NxWheelContactData_lateralImpulse(NxWheelContactData* classPointer, NxReal newvalue)
{
    classPointer->lateralImpulse = newvalue;
}

API_EXPORT NxReal get_NxWheelContactData_lateralImpulse(NxWheelContactData* classPointer)
{
    return classPointer->lateralImpulse;
}

API_EXPORT void set_NxWheelContactData_otherShapeMaterialIndex(NxWheelContactData* classPointer, NxMaterialIndex newvalue)
{
    classPointer->otherShapeMaterialIndex = newvalue;
}

API_EXPORT NxMaterialIndex get_NxWheelContactData_otherShapeMaterialIndex(NxWheelContactData* classPointer)
{
    return classPointer->otherShapeMaterialIndex;
}

API_EXPORT void set_NxWheelContactData_contactPosition(NxWheelContactData* classPointer, NxReal newvalue)
{
    classPointer->contactPosition = newvalue;
}

API_EXPORT NxReal get_NxWheelContactData_contactPosition(NxWheelContactData* classPointer)
{
    return classPointer->contactPosition;
}

API_EXPORT void NxWheelShape_saveToDesc(NxWheelShape* classPointer, bool call_explicit, NxWheelShapeDesc* desc)
{
    classPointer->saveToDesc(*desc);
}

API_EXPORT void NxWheelShape_setRadius(NxWheelShape* classPointer, bool call_explicit, NxReal radius)
{
    classPointer->setRadius(radius);
}

API_EXPORT void NxWheelShape_setSuspensionTravel(NxWheelShape* classPointer, bool call_explicit, NxReal travel)
{
    classPointer->setSuspensionTravel(travel);
}

API_EXPORT NxReal NxWheelShape_getRadius(NxWheelShape* classPointer, bool call_explicit)
{
    return classPointer->getRadius();
}

API_EXPORT NxReal NxWheelShape_getSuspensionTravel(NxWheelShape* classPointer, bool call_explicit)
{
    return classPointer->getSuspensionTravel();
}

API_EXPORT void NxWheelShape_setSuspension(NxWheelShape* classPointer, bool call_explicit, NxSpringDesc* spring)
{
    classPointer->setSuspension(*spring);
}

API_EXPORT void NxWheelShape_setLongitudalTireForceFunction(NxWheelShape* classPointer, bool call_explicit, NxTireFunctionDesc* tireFunc)
{
    classPointer->setLongitudalTireForceFunction(*tireFunc);
}

API_EXPORT void NxWheelShape_setLateralTireForceFunction(NxWheelShape* classPointer, bool call_explicit, NxTireFunctionDesc* tireFunc)
{
    classPointer->setLateralTireForceFunction(*tireFunc);
}

API_EXPORT void NxWheelShape_setInverseWheelMass(NxWheelShape* classPointer, bool call_explicit, NxReal invMass)
{
    classPointer->setInverseWheelMass(invMass);
}

API_EXPORT void NxWheelShape_setWheelFlags(NxWheelShape* classPointer, bool call_explicit, NxU32 flags)
{
    classPointer->setWheelFlags(flags);
}

API_EXPORT NxSpringDesc* NxWheelShape_getSuspension(NxWheelShape* classPointer, bool call_explicit)
{
    return &classPointer->getSuspension();
}

API_EXPORT NxTireFunctionDesc* NxWheelShape_getLongitudalTireForceFunction(NxWheelShape* classPointer, bool call_explicit)
{
    return &classPointer->getLongitudalTireForceFunction();
}

API_EXPORT NxTireFunctionDesc* NxWheelShape_getLateralTireForceFunction(NxWheelShape* classPointer, bool call_explicit)
{
    return &classPointer->getLateralTireForceFunction();
}

API_EXPORT NxReal NxWheelShape_getInverseWheelMass(NxWheelShape* classPointer, bool call_explicit)
{
    return classPointer->getInverseWheelMass();
}

API_EXPORT NxU32 NxWheelShape_getWheelFlags(NxWheelShape* classPointer, bool call_explicit)
{
    return classPointer->getWheelFlags();
}

API_EXPORT void NxWheelShape_setMotorTorque(NxWheelShape* classPointer, bool call_explicit, NxReal torque)
{
    classPointer->setMotorTorque(torque);
}

API_EXPORT void NxWheelShape_setBrakeTorque(NxWheelShape* classPointer, bool call_explicit, NxReal torque)
{
    classPointer->setBrakeTorque(torque);
}

API_EXPORT void NxWheelShape_setSteerAngle(NxWheelShape* classPointer, bool call_explicit, NxReal angle)
{
    classPointer->setSteerAngle(angle);
}

API_EXPORT NxReal NxWheelShape_getMotorTorque(NxWheelShape* classPointer, bool call_explicit)
{
    return classPointer->getMotorTorque();
}

API_EXPORT NxReal NxWheelShape_getBrakeTorque(NxWheelShape* classPointer, bool call_explicit)
{
    return classPointer->getBrakeTorque();
}

API_EXPORT NxReal NxWheelShape_getSteerAngle(NxWheelShape* classPointer, bool call_explicit)
{
    return classPointer->getSteerAngle();
}

API_EXPORT void NxWheelShape_setAxleSpeed(NxWheelShape* classPointer, bool call_explicit, NxReal speed)
{
    classPointer->setAxleSpeed(speed);
}

API_EXPORT NxReal NxWheelShape_getAxleSpeed(NxWheelShape* classPointer, bool call_explicit)
{
    return classPointer->getAxleSpeed();
}

API_EXPORT NxShape* NxWheelShape_getContact(NxWheelShape* classPointer, bool call_explicit, NxWheelContactData* dest)
{
    return classPointer->getContact(*dest);
}

API_EXPORT void NxWheelShape_setUserWheelContactModify(NxWheelShape* classPointer, bool call_explicit, NxUserWheelContactModify* callback)
{
    classPointer->setUserWheelContactModify(callback);
}

API_EXPORT NxUserWheelContactModify* NxWheelShape_getUserWheelContactModify(NxWheelShape* classPointer, bool call_explicit)
{
    return classPointer->getUserWheelContactModify();
}

API_EXPORT void set_NxWheelShapeDesc_radius(NxWheelShapeDesc* classPointer, NxReal newvalue)
{
    classPointer->radius = newvalue;
}

API_EXPORT NxReal get_NxWheelShapeDesc_radius(NxWheelShapeDesc* classPointer)
{
    return classPointer->radius;
}

API_EXPORT void set_NxWheelShapeDesc_suspensionTravel(NxWheelShapeDesc* classPointer, NxReal newvalue)
{
    classPointer->suspensionTravel = newvalue;
}

API_EXPORT NxReal get_NxWheelShapeDesc_suspensionTravel(NxWheelShapeDesc* classPointer)
{
    return classPointer->suspensionTravel;
}

API_EXPORT void set_NxWheelShapeDesc_suspension(NxWheelShapeDesc* classPointer, NxSpringDesc* newvalue)
{
    classPointer->suspension = *newvalue;
}

API_EXPORT NxSpringDesc* get_NxWheelShapeDesc_suspension(NxWheelShapeDesc* classPointer)
{
    return &classPointer->suspension;
}

API_EXPORT void set_NxWheelShapeDesc_longitudalTireForceFunction(NxWheelShapeDesc* classPointer, NxTireFunctionDesc* newvalue)
{
    classPointer->longitudalTireForceFunction = *newvalue;
}

API_EXPORT NxTireFunctionDesc* get_NxWheelShapeDesc_longitudalTireForceFunction(NxWheelShapeDesc* classPointer)
{
    return &classPointer->longitudalTireForceFunction;
}

API_EXPORT void set_NxWheelShapeDesc_lateralTireForceFunction(NxWheelShapeDesc* classPointer, NxTireFunctionDesc* newvalue)
{
    classPointer->lateralTireForceFunction = *newvalue;
}

API_EXPORT NxTireFunctionDesc* get_NxWheelShapeDesc_lateralTireForceFunction(NxWheelShapeDesc* classPointer)
{
    return &classPointer->lateralTireForceFunction;
}

API_EXPORT void set_NxWheelShapeDesc_inverseWheelMass(NxWheelShapeDesc* classPointer, NxReal newvalue)
{
    classPointer->inverseWheelMass = newvalue;
}

API_EXPORT NxReal get_NxWheelShapeDesc_inverseWheelMass(NxWheelShapeDesc* classPointer)
{
    return classPointer->inverseWheelMass;
}

API_EXPORT void set_NxWheelShapeDesc_wheelFlags(NxWheelShapeDesc* classPointer, NxU32 newvalue)
{
    classPointer->wheelFlags = newvalue;
}

API_EXPORT NxU32 get_NxWheelShapeDesc_wheelFlags(NxWheelShapeDesc* classPointer)
{
    return classPointer->wheelFlags;
}

API_EXPORT void set_NxWheelShapeDesc_motorTorque(NxWheelShapeDesc* classPointer, NxReal newvalue)
{
    classPointer->motorTorque = newvalue;
}

API_EXPORT NxReal get_NxWheelShapeDesc_motorTorque(NxWheelShapeDesc* classPointer)
{
    return classPointer->motorTorque;
}

API_EXPORT void set_NxWheelShapeDesc_brakeTorque(NxWheelShapeDesc* classPointer, NxReal newvalue)
{
    classPointer->brakeTorque = newvalue;
}

API_EXPORT NxReal get_NxWheelShapeDesc_brakeTorque(NxWheelShapeDesc* classPointer)
{
    return classPointer->brakeTorque;
}

API_EXPORT void set_NxWheelShapeDesc_steerAngle(NxWheelShapeDesc* classPointer, NxReal newvalue)
{
    classPointer->steerAngle = newvalue;
}

API_EXPORT NxReal get_NxWheelShapeDesc_steerAngle(NxWheelShapeDesc* classPointer)
{
    return classPointer->steerAngle;
}

API_EXPORT void set_NxWheelShapeDesc_wheelContactModify(NxWheelShapeDesc* classPointer, NxUserWheelContactModify* newvalue)
{
    classPointer->wheelContactModify = newvalue;
}

API_EXPORT NxUserWheelContactModify* get_NxWheelShapeDesc_wheelContactModify(NxWheelShapeDesc* classPointer)
{
    return classPointer->wheelContactModify;
}

API_EXPORT NxWheelShapeDesc* new_NxWheelShapeDesc(bool do_override)
{
    return (do_override) ? new NxWheelShapeDesc_doxybind() : new NxWheelShapeDesc();
}

API_EXPORT void NxWheelShapeDesc_setToDefault(NxWheelShapeDesc* classPointer, bool call_explicit, bool fromCtor)
{
    (call_explicit) ? classPointer->NxWheelShapeDesc::setToDefault(fromCtor) : classPointer->setToDefault(fromCtor);
}

API_EXPORT bool NxWheelShapeDesc_isValid(NxWheelShapeDesc* classPointer, bool call_explicit)
{
    return (call_explicit) ? classPointer->NxWheelShapeDesc::isValid() : classPointer->isValid();
}

API_EXPORT NxUserAllocator* new_NxUserAllocator(bool do_override)
{
    return new NxUserAllocator_doxybind();
}

API_EXPORT ControllerManagerAllocator* new_ControllerManagerAllocator(bool do_override)
{
    return (do_override) ? new ControllerManagerAllocator_doxybind() : NULL;
}

API_EXPORT NxActiveTransform* new_NxActiveTransform(bool do_override)
{
    return new NxActiveTransform();
}

API_EXPORT NxActorDesc_Template<NxAllocatorDefault>* new_NxActorDesc_Template(bool do_override)
{
    return NULL;
}

API_EXPORT NxActorGroupPair* new_NxActorGroupPair(bool do_override)
{
    return new NxActorGroupPair();
}

API_EXPORT NxActorPairFilter* new_NxActorPairFilter(bool do_override)
{
    return new NxActorPairFilter();
}

API_EXPORT NxAllocateable* new_NxAllocateable(bool do_override)
{
    return NULL;
}

API_EXPORT NxAllocatorDefault* new_NxAllocatorDefault(bool do_override)
{
    return new NxAllocatorDefault();
}

API_EXPORT NxBoxForceFieldShape* new_NxBoxForceFieldShape(bool do_override)
{
    return new NxBoxForceFieldShape_doxybind();
}

API_EXPORT NxBoxShape* new_NxBoxShape(bool do_override)
{
    return new NxBoxShape_doxybind();
}

API_EXPORT NxCapsuleForceFieldShape* new_NxCapsuleForceFieldShape(bool do_override)
{
    return new NxCapsuleForceFieldShape_doxybind();
}

API_EXPORT NxCapsuleShape* new_NxCapsuleShape(bool do_override)
{
    return new NxCapsuleShape_doxybind();
}

API_EXPORT NxCCDSkeleton* new_NxCCDSkeleton(bool do_override)
{
    return new NxCCDSkeleton_doxybind();
}

API_EXPORT NxClothUserNotify* new_NxClothUserNotify(bool do_override)
{
    return new NxClothUserNotify();
}

API_EXPORT NxCompartment* new_NxCompartment(bool do_override)
{
    return new NxCompartment_doxybind();
}

API_EXPORT NxControllerShapeHit* new_NxControllerShapeHit(bool do_override)
{
    return new NxControllerShapeHit();
}

API_EXPORT NxControllersHit* new_NxControllersHit(bool do_override)
{
    return new NxControllersHit();
}

API_EXPORT NxConvexForceFieldShape* new_NxConvexForceFieldShape(bool do_override)
{
    return new NxConvexForceFieldShape_doxybind();
}

API_EXPORT NxConvexMesh* new_NxConvexMesh(bool do_override)
{
    return new NxConvexMesh_doxybind();
}

API_EXPORT NxConvexShape* new_NxConvexShape(bool do_override)
{
    return new NxConvexShape_doxybind();
}

API_EXPORT NxCookingInterface* new_NxCookingInterface(bool do_override)
{
    return new NxCookingInterface_doxybind();
}

API_EXPORT NxCookingParams* new_NxCookingParams(bool do_override)
{
    return new NxCookingParams();
}

API_EXPORT NxCylindricalJoint* new_NxCylindricalJoint(bool do_override)
{
    return new NxCylindricalJoint_doxybind();
}

API_EXPORT NxD6Joint* new_NxD6Joint(bool do_override)
{
    return new NxD6Joint_doxybind();
}

API_EXPORT NxDebugLine* new_NxDebugLine(bool do_override)
{
    return new NxDebugLine();
}

API_EXPORT NxDebugPoint* new_NxDebugPoint(bool do_override)
{
    return new NxDebugPoint();
}

API_EXPORT NxDebugTriangle* new_NxDebugTriangle(bool do_override)
{
    return new NxDebugTriangle();
}

API_EXPORT NxDistanceJoint* new_NxDistanceJoint(bool do_override)
{
    return new NxDistanceJoint_doxybind();
}

API_EXPORT NxException* new_NxException(bool do_override)
{
    return new NxException_doxybind();
}

API_EXPORT NxExtendedSegment* new_NxExtendedSegment(bool do_override)
{
    return new NxExtendedSegment();
}

API_EXPORT NxExtendedCapsule* new_NxExtendedCapsule(bool do_override)
{
    return new NxExtendedCapsule();
}

API_EXPORT NxExtendedRay* new_NxExtendedRay(bool do_override)
{
    return new NxExtendedRay();
}

API_EXPORT NxFixedJoint* new_NxFixedJoint(bool do_override)
{
    return new NxFixedJoint_doxybind();
}

API_EXPORT NxFluid* new_NxFluid(bool do_override)
{
    return NULL;
}

API_EXPORT NxFluidDesc_Template<NxAllocatorDefault>* new_NxFluidDesc_Template(bool do_override)
{
    return NULL;
}

API_EXPORT NxFluidPacket* new_NxFluidPacket(bool do_override)
{
    return new NxFluidPacket();
}

API_EXPORT NxFluidUserNotify* new_NxFluidUserNotify(bool do_override)
{
    return new NxFluidUserNotify_doxybind();
}

API_EXPORT NxForceFieldKernel* new_NxForceFieldKernel(bool do_override)
{
    return new NxForceFieldKernel_doxybind();
}

API_EXPORT NxFoundationSDK* new_NxFoundationSDK(bool do_override)
{
    return new NxFoundationSDK_doxybind();
}

API_EXPORT NxHeightField* new_NxHeightField(bool do_override)
{
    return new NxHeightField_doxybind();
}

API_EXPORT NxHeightFieldSample* new_NxHeightFieldSample(bool do_override)
{
    return new NxHeightFieldSample();
}

API_EXPORT NxHeightFieldShape* new_NxHeightFieldShape(bool do_override)
{
    return new NxHeightFieldShape_doxybind();
}

API_EXPORT NxIntegrals* new_NxIntegrals(bool do_override)
{
    return new NxIntegrals();
}

API_EXPORT NxInterface* new_NxInterface(bool do_override)
{
    return new NxInterface_doxybind();
}

API_EXPORT NxInterfaceStats* new_NxInterfaceStats(bool do_override)
{
    return new NxInterfaceStats_doxybind();
}

API_EXPORT NxMat33Shadow* new_NxMat33Shadow(bool do_override)
{
    return new NxMat33Shadow();
}

API_EXPORT NxMath* new_NxMath(bool do_override)
{
    return new NxMath();
}

API_EXPORT NxPairFlag* new_NxPairFlag(bool do_override)
{
    return new NxPairFlag();
}

API_EXPORT NxPlaneShape* new_NxPlaneShape(bool do_override)
{
    return new NxPlaneShape_doxybind();
}

API_EXPORT NxPMap* new_NxPMap(bool do_override)
{
    return new NxPMap();
}

API_EXPORT NxPointInPlaneJoint* new_NxPointInPlaneJoint(bool do_override)
{
    return new NxPointInPlaneJoint_doxybind();
}

API_EXPORT NxPointOnLineJoint* new_NxPointOnLineJoint(bool do_override)
{
    return new NxPointOnLineJoint_doxybind();
}

/*API_EXPORT NxPool* new_NxPool(bool do_override)
{
    return new NxPool();
}*/

API_EXPORT NxPrismaticJoint* new_NxPrismaticJoint(bool do_override)
{
    return new NxPrismaticJoint_doxybind();
}

API_EXPORT NxProfilerData* new_NxProfilerData(bool do_override)
{
    return new NxProfilerData();
}

API_EXPORT NxProfileZone* new_NxProfileZone(bool do_override)
{
    return new NxProfileZone();
}

API_EXPORT NxPulleyJoint* new_NxPulleyJoint(bool do_override)
{
    return new NxPulleyJoint_doxybind();
}

API_EXPORT NxRaycastHit* new_NxRaycastHit(bool do_override)
{
    return new NxRaycastHit();
}

API_EXPORT NxRemoteDebugger* new_NxRemoteDebugger(bool do_override)
{
    return new NxRemoteDebugger_doxybind();
}

API_EXPORT NxRemoteDebuggerEventListener* new_NxRemoteDebuggerEventListener(bool do_override)
{
    return (do_override) ? new NxRemoteDebuggerEventListener_doxybind() : NULL;
}

API_EXPORT NxRevoluteJoint* new_NxRevoluteJoint(bool do_override)
{
    return new NxRevoluteJoint_doxybind();
}

API_EXPORT NxSceneQuery* new_NxSceneQuery(bool do_override)
{
    return new NxSceneQuery_doxybind();
}

API_EXPORT NxSceneQueryReport* new_NxSceneQueryReport(bool do_override)
{
    return new NxSceneQueryReport_doxybind();
}

API_EXPORT NxSceneStatistic* new_NxSceneStatistic(bool do_override)
{
    return new NxSceneStatistic();
}

API_EXPORT NxSceneStats2* new_NxSceneStats2(bool do_override)
{
    return new NxSceneStats2();
}

API_EXPORT NxSoftBodySplitPair* new_NxSoftBodySplitPair(bool do_override)
{
    return new NxSoftBodySplitPair();
}

API_EXPORT NxSoftBodyUserNotify* new_NxSoftBodyUserNotify(bool do_override)
{
    return new NxSoftBodyUserNotify();
}

API_EXPORT NxSphereForceFieldShape* new_NxSphereForceFieldShape(bool do_override)
{
    return new NxSphereForceFieldShape_doxybind();
}

API_EXPORT NxSphereShape* new_NxSphereShape(bool do_override)
{
    return new NxSphereShape_doxybind();
}

API_EXPORT NxSphericalJoint* new_NxSphericalJoint(bool do_override)
{
    return new NxSphericalJoint_doxybind();
}

API_EXPORT NxSpringAndDamperEffector* new_NxSpringAndDamperEffector(bool do_override)
{
    return new NxSpringAndDamperEffector_doxybind();
}

API_EXPORT NxSweepQueryHit* new_NxSweepQueryHit(bool do_override)
{
    return new NxSweepQueryHit();
}

API_EXPORT NxTask* new_NxTask(bool do_override)
{
    return new NxTask_doxybind();
}

API_EXPORT NxTriangleMesh* new_NxTriangleMesh(bool do_override)
{
    return new NxTriangleMesh_doxybind();
}

API_EXPORT NxTriangleMeshShape* new_NxTriangleMeshShape(bool do_override)
{
    return new NxTriangleMeshShape_doxybind();
}

API_EXPORT NxUserActorPairFiltering* new_NxUserActorPairFiltering(bool do_override)
{
    return new NxUserActorPairFiltering_doxybind();
}

API_EXPORT NxUserAllocatorDefault* new_NxUserAllocatorDefault(bool do_override)
{
    return (do_override) ? new NxUserAllocatorDefault_doxybind() : NULL;
}

API_EXPORT NxUserContactModify* new_NxUserContactModify(bool do_override)
{
    return new NxUserContactModify_doxybind();
}

API_EXPORT NxUserContactModify::NxContactCallbackData* new_NxContactCallbackData(bool do_override)
{
	return new NxUserContactModify::NxContactCallbackData();
}

API_EXPORT NxUserContactReport* new_NxUserContactReport(bool do_override)
{
    return new NxUserContactReport_doxybind();
}

API_EXPORT NxUserControllerHitReport* new_NxUserControllerHitReport(bool do_override)
{
    return new NxUserControllerHitReport_doxybind();
}

/*API_EXPORT NxUserEntityReport* new_NxUserEntityReport(bool do_override)
{
    return NULL;
}*/

API_EXPORT NxUserNotify* new_NxUserNotify(bool do_override)
{
    return new NxUserNotify_doxybind();
}

API_EXPORT NxUserOutputStream* new_NxUserOutputStream(bool do_override)
{
    return new NxUserOutputStream_doxybind();
}

API_EXPORT NxUserRaycastReport* new_NxUserRaycastReport(bool do_override)
{
    return new NxUserRaycastReport_doxybind();
}

API_EXPORT NxUserScheduler* new_NxUserScheduler(bool do_override)
{
    return new NxUserScheduler_doxybind();
}

API_EXPORT NxUserTriggerReport* new_NxUserTriggerReport(bool do_override)
{
    return new NxUserTriggerReport_doxybind();
}

API_EXPORT NxUserWheelContactModify* new_NxUserWheelContactModify(bool do_override)
{
    return new NxUserWheelContactModify_doxybind();
}

API_EXPORT NxUtilLib* new_NxUtilLib(bool do_override)
{
    return new NxUtilLib_doxybind();
}

API_EXPORT NxWheelContactData* new_NxWheelContactData(bool do_override)
{
    return new NxWheelContactData();
}

API_EXPORT NxWheelShape* new_NxWheelShape(bool do_override)
{
    return new NxWheelShape_doxybind();
}

