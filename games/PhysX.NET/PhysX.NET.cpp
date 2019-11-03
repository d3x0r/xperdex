/*
Copyright (c) 2007-2008
Available under the terms of the
Eclipse Public License with GPL exception
See enclosed license file for more information
*/
#include "PhysX.NET.h"


            void DoxyBindObject::setPointers(void** pointers, int length)
            {
                functionPointers = new void*[length];
                for(int i=0; i<length; i++)
                    functionPointers[i] = pointers[i];
            }

void * NxUserAllocator_doxybind::mallocDEBUG(size_t size, const char * fileName, int line) 
{
    void * (*func)(size_t size, const char * fileName, int line) = (void * (*)(size_t size, const char * fileName, int line))(functionPointers[NxUserAllocator_doxybind::getPointerStart() + 0]);
    return func(size, fileName, line);
}

void * NxUserAllocator_doxybind::mallocDEBUG(size_t size, const char * fileName, int line, const char * className, NxMemoryType type) 
{
    void * (*func)(size_t size, const char * fileName, int line, const char * className, NxMemoryType type) = (void * (*)(size_t size, const char * fileName, int line, const char * className, NxMemoryType type))(functionPointers[NxUserAllocator_doxybind::getPointerStart() + 1]);
    return func(size, fileName, line, className, type);
}

void * NxUserAllocator_doxybind::malloc(size_t size) 
{
    void * (*func)(size_t size) = (void * (*)(size_t size))(functionPointers[NxUserAllocator_doxybind::getPointerStart() + 2]);
    return func(size);
}

void * NxUserAllocator_doxybind::malloc(size_t size, NxMemoryType type) 
{
    void * (*func)(size_t size, NxMemoryType type) = (void * (*)(size_t size, NxMemoryType type))(functionPointers[NxUserAllocator_doxybind::getPointerStart() + 3]);
    return func(size, type);
}

void * NxUserAllocator_doxybind::realloc(void * memory, size_t size) 
{
    void * (*func)(void * memory, size_t size) = (void * (*)(void * memory, size_t size))(functionPointers[NxUserAllocator_doxybind::getPointerStart() + 4]);
    return func(memory, size);
}

void NxUserAllocator_doxybind::free(void * memory) 
{
    void (*func)(void * memory) = (void (*)(void * memory))(functionPointers[NxUserAllocator_doxybind::getPointerStart() + 5]);
     func(memory);
}

void NxUserAllocator_doxybind::checkDEBUG() 
{
    void (*func)() = (void (*)())(functionPointers[NxUserAllocator_doxybind::getPointerStart() + 6]);
     func();
}

void * ControllerManagerAllocator_doxybind::mallocDEBUG(size_t size, const char * fileName, int line) 
{
    void * (*func)(size_t size, const char * fileName, int line) = (void * (*)(size_t size, const char * fileName, int line))(functionPointers[ControllerManagerAllocator_doxybind::getPointerStart() + 0]);
    return func(size, fileName, line);
}

void * ControllerManagerAllocator_doxybind::malloc(size_t size) 
{
    void * (*func)(size_t size) = (void * (*)(size_t size))(functionPointers[ControllerManagerAllocator_doxybind::getPointerStart() + 1]);
    return func(size);
}

void * ControllerManagerAllocator_doxybind::realloc(void * memory, size_t size) 
{
    void * (*func)(void * memory, size_t size) = (void * (*)(void * memory, size_t size))(functionPointers[ControllerManagerAllocator_doxybind::getPointerStart() + 2]);
    return func(memory, size);
}

void ControllerManagerAllocator_doxybind::free(void * memory) 
{
    void (*func)(void * memory) = (void (*)(void * memory))(functionPointers[ControllerManagerAllocator_doxybind::getPointerStart() + 3]);
     func(memory);
}

void * ControllerManagerAllocator_doxybind::mallocDEBUG(size_t size, const char * fileName, int line, const char * className, NxMemoryType type) 
{
    void * (*func)(size_t size, const char * fileName, int line, const char * className, NxMemoryType type) = (void * (*)(size_t size, const char * fileName, int line, const char * className, NxMemoryType type))(functionPointers[NxUserAllocator_doxybind::getPointerStart() + 1]);
    return func(size, fileName, line, className, type);
}

void * ControllerManagerAllocator_doxybind::malloc(size_t size, NxMemoryType type) 
{
    void * (*func)(size_t size, NxMemoryType type) = (void * (*)(size_t size, NxMemoryType type))(functionPointers[NxUserAllocator_doxybind::getPointerStart() + 3]);
    return func(size, type);
}

void ControllerManagerAllocator_doxybind::checkDEBUG() 
{
    void (*func)() = (void (*)())(functionPointers[NxUserAllocator_doxybind::getPointerStart() + 6]);
     func();
}

void NxActor_doxybind::setGlobalPose(const NxMat34 & mat) 
{
    void (*func)(const NxMat34 & mat) = (void (*)(const NxMat34 & mat))(functionPointers[NxActor_doxybind::getPointerStart() + 0]);
     func(mat);
}

void NxActor_doxybind::setGlobalPosition(const NxVec3 & vec) 
{
    void (*func)(const NxVec3 & vec) = (void (*)(const NxVec3 & vec))(functionPointers[NxActor_doxybind::getPointerStart() + 1]);
     func(vec);
}

void NxActor_doxybind::setGlobalOrientation(const NxMat33 & mat) 
{
    void (*func)(const NxMat33 & mat) = (void (*)(const NxMat33 & mat))(functionPointers[NxActor_doxybind::getPointerStart() + 2]);
     func(mat);
}

void NxActor_doxybind::setGlobalOrientationQuat(const NxQuat & mat) 
{
    void (*func)(const NxQuat & mat) = (void (*)(const NxQuat & mat))(functionPointers[NxActor_doxybind::getPointerStart() + 3]);
     func(mat);
}

NxMat34 NxActor_doxybind::getGlobalPose() const
{
    NxMat34 (*func)() = (NxMat34 (*)())(functionPointers[NxActor_doxybind::getPointerStart() + 4]);
    return func();
}

NxVec3 NxActor_doxybind::getGlobalPosition() const
{
    NxVec3 (*func)() = (NxVec3 (*)())(functionPointers[NxActor_doxybind::getPointerStart() + 5]);
    return func();
}

NxMat33 NxActor_doxybind::getGlobalOrientation() const
{
    NxMat33 (*func)() = (NxMat33 (*)())(functionPointers[NxActor_doxybind::getPointerStart() + 6]);
    return func();
}

NxQuat NxActor_doxybind::getGlobalOrientationQuat() const
{
    NxQuat (*func)() = (NxQuat (*)())(functionPointers[NxActor_doxybind::getPointerStart() + 7]);
    return func();
}

void NxActor_doxybind::moveGlobalPose(const NxMat34 & mat) 
{
    void (*func)(const NxMat34 & mat) = (void (*)(const NxMat34 & mat))(functionPointers[NxActor_doxybind::getPointerStart() + 8]);
     func(mat);
}

void NxActor_doxybind::moveGlobalPosition(const NxVec3 & vec) 
{
    void (*func)(const NxVec3 & vec) = (void (*)(const NxVec3 & vec))(functionPointers[NxActor_doxybind::getPointerStart() + 9]);
     func(vec);
}

void NxActor_doxybind::moveGlobalOrientation(const NxMat33 & mat) 
{
    void (*func)(const NxMat33 & mat) = (void (*)(const NxMat33 & mat))(functionPointers[NxActor_doxybind::getPointerStart() + 10]);
     func(mat);
}

void NxActor_doxybind::moveGlobalOrientationQuat(const NxQuat & quat) 
{
    void (*func)(const NxQuat & quat) = (void (*)(const NxQuat & quat))(functionPointers[NxActor_doxybind::getPointerStart() + 11]);
     func(quat);
}

NxShape * NxActor_doxybind::createShape(const NxShapeDesc & desc) 
{
    NxShape * (*func)(const NxShapeDesc & desc) = (NxShape * (*)(const NxShapeDesc & desc))(functionPointers[NxActor_doxybind::getPointerStart() + 12]);
    return func(desc);
}

void NxActor_doxybind::releaseShape(NxShape & shape) 
{
    void (*func)(NxShape & shape) = (void (*)(NxShape & shape))(functionPointers[NxActor_doxybind::getPointerStart() + 13]);
     func(shape);
}

NxU32 NxActor_doxybind::getNbShapes() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxActor_doxybind::getPointerStart() + 14]);
    return func();
}

NxShape *const * NxActor_doxybind::getShapes() const
{
    NxShape *const * (*func)() = (NxShape *const * (*)())(functionPointers[NxActor_doxybind::getPointerStart() + 15]);
    return func();
}

void NxActor_doxybind::setCMassOffsetLocalPose(const NxMat34 & mat) 
{
    void (*func)(const NxMat34 & mat) = (void (*)(const NxMat34 & mat))(functionPointers[NxActor_doxybind::getPointerStart() + 16]);
     func(mat);
}

void NxActor_doxybind::setCMassOffsetLocalPosition(const NxVec3 & vec) 
{
    void (*func)(const NxVec3 & vec) = (void (*)(const NxVec3 & vec))(functionPointers[NxActor_doxybind::getPointerStart() + 17]);
     func(vec);
}

void NxActor_doxybind::setCMassOffsetLocalOrientation(const NxMat33 & mat) 
{
    void (*func)(const NxMat33 & mat) = (void (*)(const NxMat33 & mat))(functionPointers[NxActor_doxybind::getPointerStart() + 18]);
     func(mat);
}

void NxActor_doxybind::setCMassOffsetGlobalPose(const NxMat34 & mat) 
{
    void (*func)(const NxMat34 & mat) = (void (*)(const NxMat34 & mat))(functionPointers[NxActor_doxybind::getPointerStart() + 19]);
     func(mat);
}

void NxActor_doxybind::setCMassOffsetGlobalPosition(const NxVec3 & vec) 
{
    void (*func)(const NxVec3 & vec) = (void (*)(const NxVec3 & vec))(functionPointers[NxActor_doxybind::getPointerStart() + 20]);
     func(vec);
}

void NxActor_doxybind::setCMassOffsetGlobalOrientation(const NxMat33 & mat) 
{
    void (*func)(const NxMat33 & mat) = (void (*)(const NxMat33 & mat))(functionPointers[NxActor_doxybind::getPointerStart() + 21]);
     func(mat);
}

void NxActor_doxybind::setCMassGlobalPose(const NxMat34 & mat) 
{
    void (*func)(const NxMat34 & mat) = (void (*)(const NxMat34 & mat))(functionPointers[NxActor_doxybind::getPointerStart() + 22]);
     func(mat);
}

void NxActor_doxybind::setCMassGlobalPosition(const NxVec3 & vec) 
{
    void (*func)(const NxVec3 & vec) = (void (*)(const NxVec3 & vec))(functionPointers[NxActor_doxybind::getPointerStart() + 23]);
     func(vec);
}

void NxActor_doxybind::setCMassGlobalOrientation(const NxMat33 & mat) 
{
    void (*func)(const NxMat33 & mat) = (void (*)(const NxMat33 & mat))(functionPointers[NxActor_doxybind::getPointerStart() + 24]);
     func(mat);
}

NxMat34 NxActor_doxybind::getCMassLocalPose() const
{
    NxMat34 (*func)() = (NxMat34 (*)())(functionPointers[NxActor_doxybind::getPointerStart() + 25]);
    return func();
}

NxVec3 NxActor_doxybind::getCMassLocalPosition() const
{
    NxVec3 (*func)() = (NxVec3 (*)())(functionPointers[NxActor_doxybind::getPointerStart() + 26]);
    return func();
}

NxMat33 NxActor_doxybind::getCMassLocalOrientation() const
{
    NxMat33 (*func)() = (NxMat33 (*)())(functionPointers[NxActor_doxybind::getPointerStart() + 27]);
    return func();
}

NxMat34 NxActor_doxybind::getCMassGlobalPose() const
{
    NxMat34 (*func)() = (NxMat34 (*)())(functionPointers[NxActor_doxybind::getPointerStart() + 28]);
    return func();
}

NxVec3 NxActor_doxybind::getCMassGlobalPosition() const
{
    NxVec3 (*func)() = (NxVec3 (*)())(functionPointers[NxActor_doxybind::getPointerStart() + 29]);
    return func();
}

NxMat33 NxActor_doxybind::getCMassGlobalOrientation() const
{
    NxMat33 (*func)() = (NxMat33 (*)())(functionPointers[NxActor_doxybind::getPointerStart() + 30]);
    return func();
}

void NxActor_doxybind::setMass(NxReal mass) 
{
    void (*func)(NxReal mass) = (void (*)(NxReal mass))(functionPointers[NxActor_doxybind::getPointerStart() + 31]);
     func(mass);
}

NxReal NxActor_doxybind::getMass() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxActor_doxybind::getPointerStart() + 32]);
    return func();
}

void NxActor_doxybind::setMassSpaceInertiaTensor(const NxVec3 & m) 
{
    void (*func)(const NxVec3 & m) = (void (*)(const NxVec3 & m))(functionPointers[NxActor_doxybind::getPointerStart() + 33]);
     func(m);
}

NxVec3 NxActor_doxybind::getMassSpaceInertiaTensor() const
{
    NxVec3 (*func)() = (NxVec3 (*)())(functionPointers[NxActor_doxybind::getPointerStart() + 34]);
    return func();
}

NxMat33 NxActor_doxybind::getGlobalInertiaTensor() const
{
    NxMat33 (*func)() = (NxMat33 (*)())(functionPointers[NxActor_doxybind::getPointerStart() + 35]);
    return func();
}

NxMat33 NxActor_doxybind::getGlobalInertiaTensorInverse() const
{
    NxMat33 (*func)() = (NxMat33 (*)())(functionPointers[NxActor_doxybind::getPointerStart() + 36]);
    return func();
}

bool NxActor_doxybind::updateMassFromShapes(NxReal density, NxReal totalMass) 
{
    bool (*func)(NxReal density, NxReal totalMass) = (bool (*)(NxReal density, NxReal totalMass))(functionPointers[NxActor_doxybind::getPointerStart() + 37]);
    return func(density, totalMass);
}

void NxActor_doxybind::setLinearDamping(NxReal linDamp) 
{
    void (*func)(NxReal linDamp) = (void (*)(NxReal linDamp))(functionPointers[NxActor_doxybind::getPointerStart() + 38]);
     func(linDamp);
}

NxReal NxActor_doxybind::getLinearDamping() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxActor_doxybind::getPointerStart() + 39]);
    return func();
}

void NxActor_doxybind::setAngularDamping(NxReal angDamp) 
{
    void (*func)(NxReal angDamp) = (void (*)(NxReal angDamp))(functionPointers[NxActor_doxybind::getPointerStart() + 40]);
     func(angDamp);
}

NxReal NxActor_doxybind::getAngularDamping() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxActor_doxybind::getPointerStart() + 41]);
    return func();
}

void NxActor_doxybind::setLinearVelocity(const NxVec3 & linVel) 
{
    void (*func)(const NxVec3 & linVel) = (void (*)(const NxVec3 & linVel))(functionPointers[NxActor_doxybind::getPointerStart() + 42]);
     func(linVel);
}

void NxActor_doxybind::setAngularVelocity(const NxVec3 & angVel) 
{
    void (*func)(const NxVec3 & angVel) = (void (*)(const NxVec3 & angVel))(functionPointers[NxActor_doxybind::getPointerStart() + 43]);
     func(angVel);
}

NxVec3 NxActor_doxybind::getLinearVelocity() const
{
    NxVec3 (*func)() = (NxVec3 (*)())(functionPointers[NxActor_doxybind::getPointerStart() + 44]);
    return func();
}

NxVec3 NxActor_doxybind::getAngularVelocity() const
{
    NxVec3 (*func)() = (NxVec3 (*)())(functionPointers[NxActor_doxybind::getPointerStart() + 45]);
    return func();
}

void NxActor_doxybind::setMaxAngularVelocity(NxReal maxAngVel) 
{
    void (*func)(NxReal maxAngVel) = (void (*)(NxReal maxAngVel))(functionPointers[NxActor_doxybind::getPointerStart() + 46]);
     func(maxAngVel);
}

NxReal NxActor_doxybind::getMaxAngularVelocity() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxActor_doxybind::getPointerStart() + 47]);
    return func();
}

void NxActor_doxybind::setCCDMotionThreshold(NxReal thresh) 
{
    void (*func)(NxReal thresh) = (void (*)(NxReal thresh))(functionPointers[NxActor_doxybind::getPointerStart() + 48]);
     func(thresh);
}

NxReal NxActor_doxybind::getCCDMotionThreshold() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxActor_doxybind::getPointerStart() + 49]);
    return func();
}

void NxActor_doxybind::setLinearMomentum(const NxVec3 & linMoment) 
{
    void (*func)(const NxVec3 & linMoment) = (void (*)(const NxVec3 & linMoment))(functionPointers[NxActor_doxybind::getPointerStart() + 50]);
     func(linMoment);
}

void NxActor_doxybind::setAngularMomentum(const NxVec3 & angMoment) 
{
    void (*func)(const NxVec3 & angMoment) = (void (*)(const NxVec3 & angMoment))(functionPointers[NxActor_doxybind::getPointerStart() + 51]);
     func(angMoment);
}

NxVec3 NxActor_doxybind::getLinearMomentum() const
{
    NxVec3 (*func)() = (NxVec3 (*)())(functionPointers[NxActor_doxybind::getPointerStart() + 52]);
    return func();
}

NxVec3 NxActor_doxybind::getAngularMomentum() const
{
    NxVec3 (*func)() = (NxVec3 (*)())(functionPointers[NxActor_doxybind::getPointerStart() + 53]);
    return func();
}

void NxActor_doxybind::addForceAtPos(const NxVec3 & force, const NxVec3 & pos, NxForceMode mode, bool wakeup) 
{
    void (*func)(const NxVec3 & force, const NxVec3 & pos, NxForceMode mode, bool wakeup) = (void (*)(const NxVec3 & force, const NxVec3 & pos, NxForceMode mode, bool wakeup))(functionPointers[NxActor_doxybind::getPointerStart() + 54]);
     func(force, pos, mode, wakeup);
}

void NxActor_doxybind::addForceAtPos(const NxVec3 & force, const NxVec3 & pos, NxForceMode mode) 
{
    void (*func)(const NxVec3 & force, const NxVec3 & pos, NxForceMode mode) = (void (*)(const NxVec3 & force, const NxVec3 & pos, NxForceMode mode))(functionPointers[NxActor_doxybind::getPointerStart() + 55]);
     func(force, pos, mode);
}

void NxActor_doxybind::addForceAtPos(const NxVec3 & force, const NxVec3 & pos) 
{
    void (*func)(const NxVec3 & force, const NxVec3 & pos) = (void (*)(const NxVec3 & force, const NxVec3 & pos))(functionPointers[NxActor_doxybind::getPointerStart() + 56]);
     func(force, pos);
}

void NxActor_doxybind::addForceAtLocalPos(const NxVec3 & force, const NxVec3 & pos, NxForceMode mode, bool wakeup) 
{
    void (*func)(const NxVec3 & force, const NxVec3 & pos, NxForceMode mode, bool wakeup) = (void (*)(const NxVec3 & force, const NxVec3 & pos, NxForceMode mode, bool wakeup))(functionPointers[NxActor_doxybind::getPointerStart() + 57]);
     func(force, pos, mode, wakeup);
}

void NxActor_doxybind::addForceAtLocalPos(const NxVec3 & force, const NxVec3 & pos, NxForceMode mode) 
{
    void (*func)(const NxVec3 & force, const NxVec3 & pos, NxForceMode mode) = (void (*)(const NxVec3 & force, const NxVec3 & pos, NxForceMode mode))(functionPointers[NxActor_doxybind::getPointerStart() + 58]);
     func(force, pos, mode);
}

void NxActor_doxybind::addForceAtLocalPos(const NxVec3 & force, const NxVec3 & pos) 
{
    void (*func)(const NxVec3 & force, const NxVec3 & pos) = (void (*)(const NxVec3 & force, const NxVec3 & pos))(functionPointers[NxActor_doxybind::getPointerStart() + 59]);
     func(force, pos);
}

void NxActor_doxybind::addLocalForceAtPos(const NxVec3 & force, const NxVec3 & pos, NxForceMode mode, bool wakeup) 
{
    void (*func)(const NxVec3 & force, const NxVec3 & pos, NxForceMode mode, bool wakeup) = (void (*)(const NxVec3 & force, const NxVec3 & pos, NxForceMode mode, bool wakeup))(functionPointers[NxActor_doxybind::getPointerStart() + 60]);
     func(force, pos, mode, wakeup);
}

void NxActor_doxybind::addLocalForceAtPos(const NxVec3 & force, const NxVec3 & pos, NxForceMode mode) 
{
    void (*func)(const NxVec3 & force, const NxVec3 & pos, NxForceMode mode) = (void (*)(const NxVec3 & force, const NxVec3 & pos, NxForceMode mode))(functionPointers[NxActor_doxybind::getPointerStart() + 61]);
     func(force, pos, mode);
}

void NxActor_doxybind::addLocalForceAtPos(const NxVec3 & force, const NxVec3 & pos) 
{
    void (*func)(const NxVec3 & force, const NxVec3 & pos) = (void (*)(const NxVec3 & force, const NxVec3 & pos))(functionPointers[NxActor_doxybind::getPointerStart() + 62]);
     func(force, pos);
}

void NxActor_doxybind::addLocalForceAtLocalPos(const NxVec3 & force, const NxVec3 & pos, NxForceMode mode, bool wakeup) 
{
    void (*func)(const NxVec3 & force, const NxVec3 & pos, NxForceMode mode, bool wakeup) = (void (*)(const NxVec3 & force, const NxVec3 & pos, NxForceMode mode, bool wakeup))(functionPointers[NxActor_doxybind::getPointerStart() + 63]);
     func(force, pos, mode, wakeup);
}

void NxActor_doxybind::addLocalForceAtLocalPos(const NxVec3 & force, const NxVec3 & pos, NxForceMode mode) 
{
    void (*func)(const NxVec3 & force, const NxVec3 & pos, NxForceMode mode) = (void (*)(const NxVec3 & force, const NxVec3 & pos, NxForceMode mode))(functionPointers[NxActor_doxybind::getPointerStart() + 64]);
     func(force, pos, mode);
}

void NxActor_doxybind::addLocalForceAtLocalPos(const NxVec3 & force, const NxVec3 & pos) 
{
    void (*func)(const NxVec3 & force, const NxVec3 & pos) = (void (*)(const NxVec3 & force, const NxVec3 & pos))(functionPointers[NxActor_doxybind::getPointerStart() + 65]);
     func(force, pos);
}

void NxActor_doxybind::addForce(const NxVec3 & force, NxForceMode mode, bool wakeup) 
{
    void (*func)(const NxVec3 & force, NxForceMode mode, bool wakeup) = (void (*)(const NxVec3 & force, NxForceMode mode, bool wakeup))(functionPointers[NxActor_doxybind::getPointerStart() + 66]);
     func(force, mode, wakeup);
}

void NxActor_doxybind::addForce(const NxVec3 & force, NxForceMode mode) 
{
    void (*func)(const NxVec3 & force, NxForceMode mode) = (void (*)(const NxVec3 & force, NxForceMode mode))(functionPointers[NxActor_doxybind::getPointerStart() + 67]);
     func(force, mode);
}

void NxActor_doxybind::addForce(const NxVec3 & force) 
{
    void (*func)(const NxVec3 & force) = (void (*)(const NxVec3 & force))(functionPointers[NxActor_doxybind::getPointerStart() + 68]);
     func(force);
}

void NxActor_doxybind::addLocalForce(const NxVec3 & force, NxForceMode mode, bool wakeup) 
{
    void (*func)(const NxVec3 & force, NxForceMode mode, bool wakeup) = (void (*)(const NxVec3 & force, NxForceMode mode, bool wakeup))(functionPointers[NxActor_doxybind::getPointerStart() + 69]);
     func(force, mode, wakeup);
}

void NxActor_doxybind::addLocalForce(const NxVec3 & force, NxForceMode mode) 
{
    void (*func)(const NxVec3 & force, NxForceMode mode) = (void (*)(const NxVec3 & force, NxForceMode mode))(functionPointers[NxActor_doxybind::getPointerStart() + 70]);
     func(force, mode);
}

void NxActor_doxybind::addLocalForce(const NxVec3 & force) 
{
    void (*func)(const NxVec3 & force) = (void (*)(const NxVec3 & force))(functionPointers[NxActor_doxybind::getPointerStart() + 71]);
     func(force);
}

void NxActor_doxybind::addTorque(const NxVec3 & torque, NxForceMode mode, bool wakeup) 
{
    void (*func)(const NxVec3 & torque, NxForceMode mode, bool wakeup) = (void (*)(const NxVec3 & torque, NxForceMode mode, bool wakeup))(functionPointers[NxActor_doxybind::getPointerStart() + 72]);
     func(torque, mode, wakeup);
}

void NxActor_doxybind::addTorque(const NxVec3 & torque, NxForceMode mode) 
{
    void (*func)(const NxVec3 & torque, NxForceMode mode) = (void (*)(const NxVec3 & torque, NxForceMode mode))(functionPointers[NxActor_doxybind::getPointerStart() + 73]);
     func(torque, mode);
}

void NxActor_doxybind::addTorque(const NxVec3 & torque) 
{
    void (*func)(const NxVec3 & torque) = (void (*)(const NxVec3 & torque))(functionPointers[NxActor_doxybind::getPointerStart() + 74]);
     func(torque);
}

void NxActor_doxybind::addLocalTorque(const NxVec3 & torque, NxForceMode mode, bool wakeup) 
{
    void (*func)(const NxVec3 & torque, NxForceMode mode, bool wakeup) = (void (*)(const NxVec3 & torque, NxForceMode mode, bool wakeup))(functionPointers[NxActor_doxybind::getPointerStart() + 75]);
     func(torque, mode, wakeup);
}

void NxActor_doxybind::addLocalTorque(const NxVec3 & torque, NxForceMode mode) 
{
    void (*func)(const NxVec3 & torque, NxForceMode mode) = (void (*)(const NxVec3 & torque, NxForceMode mode))(functionPointers[NxActor_doxybind::getPointerStart() + 76]);
     func(torque, mode);
}

void NxActor_doxybind::addLocalTorque(const NxVec3 & torque) 
{
    void (*func)(const NxVec3 & torque) = (void (*)(const NxVec3 & torque))(functionPointers[NxActor_doxybind::getPointerStart() + 77]);
     func(torque);
}

NxVec3 NxActor_doxybind::getPointVelocity(const NxVec3 & point) const
{
    NxVec3 (*func)(const NxVec3 & point) = (NxVec3 (*)(const NxVec3 & point))(functionPointers[NxActor_doxybind::getPointerStart() + 78]);
    return func(point);
}

NxVec3 NxActor_doxybind::getLocalPointVelocity(const NxVec3 & point) const
{
    NxVec3 (*func)(const NxVec3 & point) = (NxVec3 (*)(const NxVec3 & point))(functionPointers[NxActor_doxybind::getPointerStart() + 79]);
    return func(point);
}

bool NxActor_doxybind::isGroupSleeping() const
{
    bool (*func)() = (bool (*)())(functionPointers[NxActor_doxybind::getPointerStart() + 80]);
    return func();
}

bool NxActor_doxybind::isSleeping() const
{
    bool (*func)() = (bool (*)())(functionPointers[NxActor_doxybind::getPointerStart() + 81]);
    return func();
}

NxReal NxActor_doxybind::getSleepLinearVelocity() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxActor_doxybind::getPointerStart() + 82]);
    return func();
}

void NxActor_doxybind::setSleepLinearVelocity(NxReal threshold) 
{
    void (*func)(NxReal threshold) = (void (*)(NxReal threshold))(functionPointers[NxActor_doxybind::getPointerStart() + 83]);
     func(threshold);
}

NxReal NxActor_doxybind::getSleepAngularVelocity() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxActor_doxybind::getPointerStart() + 84]);
    return func();
}

void NxActor_doxybind::setSleepAngularVelocity(NxReal threshold) 
{
    void (*func)(NxReal threshold) = (void (*)(NxReal threshold))(functionPointers[NxActor_doxybind::getPointerStart() + 85]);
     func(threshold);
}

NxReal NxActor_doxybind::getSleepEnergyThreshold() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxActor_doxybind::getPointerStart() + 86]);
    return func();
}

void NxActor_doxybind::setSleepEnergyThreshold(NxReal threshold) 
{
    void (*func)(NxReal threshold) = (void (*)(NxReal threshold))(functionPointers[NxActor_doxybind::getPointerStart() + 87]);
     func(threshold);
}

void NxActor_doxybind::wakeUp(NxReal wakeCounterValue) 
{
    void (*func)(NxReal wakeCounterValue) = (void (*)(NxReal wakeCounterValue))(functionPointers[NxActor_doxybind::getPointerStart() + 88]);
     func(wakeCounterValue);
}

void NxActor_doxybind::putToSleep() 
{
    void (*func)() = (void (*)())(functionPointers[NxActor_doxybind::getPointerStart() + 89]);
     func();
}

NxActor_doxybind::NxActor_doxybind() : NxActor()
{
}

NxScene & NxActor_doxybind::getScene() const
{
    NxScene & (*func)() = (NxScene & (*)())(functionPointers[NxActor_doxybind::getPointerStart() + 90]);
    return func();
}

void NxActor_doxybind::saveToDesc(NxActorDescBase & desc) 
{
    void (*func)(NxActorDescBase & desc) = (void (*)(NxActorDescBase & desc))(functionPointers[NxActor_doxybind::getPointerStart() + 91]);
     func(desc);
}

void NxActor_doxybind::setName(const char * name) 
{
    void (*func)(const char * name) = (void (*)(const char * name))(functionPointers[NxActor_doxybind::getPointerStart() + 92]);
     func(name);
}

const char * NxActor_doxybind::getName() const
{
    const char * (*func)() = (const char * (*)())(functionPointers[NxActor_doxybind::getPointerStart() + 93]);
    return func();
}

void NxActor_doxybind::setGroup(NxActorGroup actorGroup) 
{
    void (*func)(NxActorGroup actorGroup) = (void (*)(NxActorGroup actorGroup))(functionPointers[NxActor_doxybind::getPointerStart() + 94]);
     func(actorGroup);
}

NxActorGroup NxActor_doxybind::getGroup() const
{
    NxActorGroup (*func)() = (NxActorGroup (*)())(functionPointers[NxActor_doxybind::getPointerStart() + 95]);
    return func();
}

void NxActor_doxybind::setDominanceGroup(NxDominanceGroup dominanceGroup) 
{
    void (*func)(NxDominanceGroup dominanceGroup) = (void (*)(NxDominanceGroup dominanceGroup))(functionPointers[NxActor_doxybind::getPointerStart() + 96]);
     func(dominanceGroup);
}

NxDominanceGroup NxActor_doxybind::getDominanceGroup() const
{
    NxDominanceGroup (*func)() = (NxDominanceGroup (*)())(functionPointers[NxActor_doxybind::getPointerStart() + 97]);
    return func();
}

void NxActor_doxybind::raiseActorFlag(NxActorFlag actorFlag) 
{
    void (*func)(NxActorFlag actorFlag) = (void (*)(NxActorFlag actorFlag))(functionPointers[NxActor_doxybind::getPointerStart() + 98]);
     func(actorFlag);
}

void NxActor_doxybind::clearActorFlag(NxActorFlag actorFlag) 
{
    void (*func)(NxActorFlag actorFlag) = (void (*)(NxActorFlag actorFlag))(functionPointers[NxActor_doxybind::getPointerStart() + 99]);
     func(actorFlag);
}

bool NxActor_doxybind::readActorFlag(NxActorFlag actorFlag) const
{
    bool (*func)(NxActorFlag actorFlag) = (bool (*)(NxActorFlag actorFlag))(functionPointers[NxActor_doxybind::getPointerStart() + 100]);
    return func(actorFlag);
}

void NxActor_doxybind::resetUserActorPairFiltering() 
{
    void (*func)() = (void (*)())(functionPointers[NxActor_doxybind::getPointerStart() + 101]);
     func();
}

bool NxActor_doxybind::isDynamic() const
{
    bool (*func)() = (bool (*)())(functionPointers[NxActor_doxybind::getPointerStart() + 102]);
    return func();
}

NxReal NxActor_doxybind::computeKineticEnergy() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxActor_doxybind::getPointerStart() + 103]);
    return func();
}

void NxActor_doxybind::raiseBodyFlag(NxBodyFlag bodyFlag) 
{
    void (*func)(NxBodyFlag bodyFlag) = (void (*)(NxBodyFlag bodyFlag))(functionPointers[NxActor_doxybind::getPointerStart() + 104]);
     func(bodyFlag);
}

void NxActor_doxybind::clearBodyFlag(NxBodyFlag bodyFlag) 
{
    void (*func)(NxBodyFlag bodyFlag) = (void (*)(NxBodyFlag bodyFlag))(functionPointers[NxActor_doxybind::getPointerStart() + 105]);
     func(bodyFlag);
}

bool NxActor_doxybind::readBodyFlag(NxBodyFlag bodyFlag) const
{
    bool (*func)(NxBodyFlag bodyFlag) = (bool (*)(NxBodyFlag bodyFlag))(functionPointers[NxActor_doxybind::getPointerStart() + 106]);
    return func(bodyFlag);
}

bool NxActor_doxybind::saveBodyToDesc(NxBodyDesc & bodyDesc) 
{
    bool (*func)(NxBodyDesc & bodyDesc) = (bool (*)(NxBodyDesc & bodyDesc))(functionPointers[NxActor_doxybind::getPointerStart() + 107]);
    return func(bodyDesc);
}

void NxActor_doxybind::setSolverIterationCount(NxU32 iterCount) 
{
    void (*func)(NxU32 iterCount) = (void (*)(NxU32 iterCount))(functionPointers[NxActor_doxybind::getPointerStart() + 108]);
     func(iterCount);
}

NxU32 NxActor_doxybind::getSolverIterationCount() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxActor_doxybind::getPointerStart() + 109]);
    return func();
}

NxReal NxActor_doxybind::getContactReportThreshold() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxActor_doxybind::getPointerStart() + 110]);
    return func();
}

void NxActor_doxybind::setContactReportThreshold(NxReal threshold) 
{
    void (*func)(NxReal threshold) = (void (*)(NxReal threshold))(functionPointers[NxActor_doxybind::getPointerStart() + 111]);
     func(threshold);
}

NxU32 NxActor_doxybind::getContactReportFlags() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxActor_doxybind::getPointerStart() + 112]);
    return func();
}

void NxActor_doxybind::setContactReportFlags(NxU32 flags) 
{
    void (*func)(NxU32 flags) = (void (*)(NxU32 flags))(functionPointers[NxActor_doxybind::getPointerStart() + 113]);
     func(flags);
}

NxU32 NxActor_doxybind::linearSweep(const NxVec3 & motion, NxU32 flags, void * userData, NxU32 nbShapes, NxSweepQueryHit * shapes, NxUserEntityReport< NxSweepQueryHit > * callback, const NxSweepCache * sweepCache) 
{
    NxU32 (*func)(const NxVec3 & motion, NxU32 flags, void * userData, NxU32 nbShapes, NxSweepQueryHit * shapes, NxUserEntityReport< NxSweepQueryHit > * callback, const NxSweepCache * sweepCache) = (NxU32 (*)(const NxVec3 & motion, NxU32 flags, void * userData, NxU32 nbShapes, NxSweepQueryHit * shapes, NxUserEntityReport< NxSweepQueryHit > * callback, const NxSweepCache * sweepCache))(functionPointers[NxActor_doxybind::getPointerStart() + 114]);
    return func(motion, flags, userData, nbShapes, shapes, callback, sweepCache);
}

NxU32 NxActor_doxybind::linearSweep(const NxVec3 & motion, NxU32 flags, void * userData, NxU32 nbShapes, NxSweepQueryHit * shapes, NxUserEntityReport< NxSweepQueryHit > * callback) 
{
    NxU32 (*func)(const NxVec3 & motion, NxU32 flags, void * userData, NxU32 nbShapes, NxSweepQueryHit * shapes, NxUserEntityReport< NxSweepQueryHit > * callback) = (NxU32 (*)(const NxVec3 & motion, NxU32 flags, void * userData, NxU32 nbShapes, NxSweepQueryHit * shapes, NxUserEntityReport< NxSweepQueryHit > * callback))(functionPointers[NxActor_doxybind::getPointerStart() + 115]);
    return func(motion, flags, userData, nbShapes, shapes, callback);
}

NxCompartment * NxActor_doxybind::getCompartment() const
{
    NxCompartment * (*func)() = (NxCompartment * (*)())(functionPointers[NxActor_doxybind::getPointerStart() + 116]);
    return func();
}

NxForceFieldMaterial NxActor_doxybind::getForceFieldMaterial() const
{
    NxForceFieldMaterial (*func)() = (NxForceFieldMaterial (*)())(functionPointers[NxActor_doxybind::getPointerStart() + 117]);
    return func();
}

void NxActor_doxybind::setForceFieldMaterial(NxForceFieldMaterial unknown2) 
{
    void (*func)(NxForceFieldMaterial unknown2) = (void (*)(NxForceFieldMaterial unknown2))(functionPointers[NxActor_doxybind::getPointerStart() + 118]);
     func(unknown2);
}

NxController_doxybind::NxController_doxybind() : NxController()
{
}

void NxController_doxybind::move(const NxVec3 & disp, NxU32 activeGroups, NxF32 minDist, NxU32 & collisionFlags, NxF32 sharpness, const NxGroupsMask * groupsMask) 
{
    void (*func)(const NxVec3 & disp, NxU32 activeGroups, NxF32 minDist, NxU32 & collisionFlags, NxF32 sharpness, const NxGroupsMask * groupsMask) = (void (*)(const NxVec3 & disp, NxU32 activeGroups, NxF32 minDist, NxU32 & collisionFlags, NxF32 sharpness, const NxGroupsMask * groupsMask))(functionPointers[NxController_doxybind::getPointerStart() + 0]);
     func(disp, activeGroups, minDist, collisionFlags, sharpness, groupsMask);
}

void NxController_doxybind::move(const NxVec3 & disp, NxU32 activeGroups, NxF32 minDist, NxU32 & collisionFlags, NxF32 sharpness) 
{
    void (*func)(const NxVec3 & disp, NxU32 activeGroups, NxF32 minDist, NxU32 & collisionFlags, NxF32 sharpness) = (void (*)(const NxVec3 & disp, NxU32 activeGroups, NxF32 minDist, NxU32 & collisionFlags, NxF32 sharpness))(functionPointers[NxController_doxybind::getPointerStart() + 1]);
     func(disp, activeGroups, minDist, collisionFlags, sharpness);
}

void NxController_doxybind::move(const NxVec3 & disp, NxU32 activeGroups, NxF32 minDist, NxU32 & collisionFlags) 
{
    void (*func)(const NxVec3 & disp, NxU32 activeGroups, NxF32 minDist, NxU32 & collisionFlags) = (void (*)(const NxVec3 & disp, NxU32 activeGroups, NxF32 minDist, NxU32 & collisionFlags))(functionPointers[NxController_doxybind::getPointerStart() + 2]);
     func(disp, activeGroups, minDist, collisionFlags);
}

bool NxController_doxybind::setPosition(const NxExtendedVec3 & position) 
{
    bool (*func)(const NxExtendedVec3 & position) = (bool (*)(const NxExtendedVec3 & position))(functionPointers[NxController_doxybind::getPointerStart() + 3]);
    return func(position);
}

const NxExtendedVec3 & NxController_doxybind::getPosition() const
{
    const NxExtendedVec3 & (*func)() = (const NxExtendedVec3 & (*)())(functionPointers[NxController_doxybind::getPointerStart() + 4]);
    return func();
}

const NxExtendedVec3 & NxController_doxybind::getFilteredPosition() const
{
    const NxExtendedVec3 & (*func)() = (const NxExtendedVec3 & (*)())(functionPointers[NxController_doxybind::getPointerStart() + 5]);
    return func();
}

const NxExtendedVec3 & NxController_doxybind::getDebugPosition() const
{
    const NxExtendedVec3 & (*func)() = (const NxExtendedVec3 & (*)())(functionPointers[NxController_doxybind::getPointerStart() + 6]);
    return func();
}

NxActor * NxController_doxybind::getActor() const
{
    NxActor * (*func)() = (NxActor * (*)())(functionPointers[NxController_doxybind::getPointerStart() + 7]);
    return func();
}

void NxController_doxybind::setStepOffset(const float offset) 
{
    void (*func)(const float offset) = (void (*)(const float offset))(functionPointers[NxController_doxybind::getPointerStart() + 8]);
     func(offset);
}

void NxController_doxybind::setCollision(bool enabled) 
{
    void (*func)(bool enabled) = (void (*)(bool enabled))(functionPointers[NxController_doxybind::getPointerStart() + 9]);
     func(enabled);
}

void NxController_doxybind::setInteraction(NxCCTInteractionFlag flag) 
{
    void (*func)(NxCCTInteractionFlag flag) = (void (*)(NxCCTInteractionFlag flag))(functionPointers[NxController_doxybind::getPointerStart() + 10]);
     func(flag);
}

NxCCTInteractionFlag NxController_doxybind::getInteraction() const
{
    NxCCTInteractionFlag (*func)() = (NxCCTInteractionFlag (*)())(functionPointers[NxController_doxybind::getPointerStart() + 11]);
    return func();
}

void NxController_doxybind::reportSceneChanged() 
{
    void (*func)() = (void (*)())(functionPointers[NxController_doxybind::getPointerStart() + 12]);
     func();
}

void * NxController_doxybind::getUserData() const
{
    void * (*func)() = (void * (*)())(functionPointers[NxController_doxybind::getPointerStart() + 13]);
    return func();
}

NxControllerType NxController_doxybind::getType() 
{
    NxControllerType (*func)() = (NxControllerType (*)())(functionPointers[NxController_doxybind::getPointerStart() + 14]);
    return func();
}

NxBoxController_doxybind::NxBoxController_doxybind() : NxBoxController()
{
}

const NxVec3 & NxBoxController_doxybind::getExtents() const
{
    const NxVec3 & (*func)() = (const NxVec3 & (*)())(functionPointers[NxBoxController_doxybind::getPointerStart() + 0]);
    return func();
}

bool NxBoxController_doxybind::setExtents(const NxVec3 & extents) 
{
    bool (*func)(const NxVec3 & extents) = (bool (*)(const NxVec3 & extents))(functionPointers[NxBoxController_doxybind::getPointerStart() + 1]);
    return func(extents);
}

void NxBoxController_doxybind::setStepOffset(const float offset) 
{
    void (*func)(const float offset) = (void (*)(const float offset))(functionPointers[NxBoxController_doxybind::getPointerStart() + 2]);
     func(offset);
}

void NxBoxController_doxybind::reportSceneChanged() 
{
    void (*func)() = (void (*)())(functionPointers[NxBoxController_doxybind::getPointerStart() + 3]);
     func();
}

void NxBoxController_doxybind::move(const NxVec3 & disp, NxU32 activeGroups, NxF32 minDist, NxU32 & collisionFlags, NxF32 sharpness, const NxGroupsMask * groupsMask) 
{
    void (*func)(const NxVec3 & disp, NxU32 activeGroups, NxF32 minDist, NxU32 & collisionFlags, NxF32 sharpness, const NxGroupsMask * groupsMask) = (void (*)(const NxVec3 & disp, NxU32 activeGroups, NxF32 minDist, NxU32 & collisionFlags, NxF32 sharpness, const NxGroupsMask * groupsMask))(functionPointers[NxController_doxybind::getPointerStart() + 0]);
     func(disp, activeGroups, minDist, collisionFlags, sharpness, groupsMask);
}

void NxBoxController_doxybind::move(const NxVec3 & disp, NxU32 activeGroups, NxF32 minDist, NxU32 & collisionFlags, NxF32 sharpness) 
{
    void (*func)(const NxVec3 & disp, NxU32 activeGroups, NxF32 minDist, NxU32 & collisionFlags, NxF32 sharpness) = (void (*)(const NxVec3 & disp, NxU32 activeGroups, NxF32 minDist, NxU32 & collisionFlags, NxF32 sharpness))(functionPointers[NxController_doxybind::getPointerStart() + 1]);
     func(disp, activeGroups, minDist, collisionFlags, sharpness);
}

void NxBoxController_doxybind::move(const NxVec3 & disp, NxU32 activeGroups, NxF32 minDist, NxU32 & collisionFlags) 
{
    void (*func)(const NxVec3 & disp, NxU32 activeGroups, NxF32 minDist, NxU32 & collisionFlags) = (void (*)(const NxVec3 & disp, NxU32 activeGroups, NxF32 minDist, NxU32 & collisionFlags))(functionPointers[NxController_doxybind::getPointerStart() + 2]);
     func(disp, activeGroups, minDist, collisionFlags);
}

bool NxBoxController_doxybind::setPosition(const NxExtendedVec3 & position) 
{
    bool (*func)(const NxExtendedVec3 & position) = (bool (*)(const NxExtendedVec3 & position))(functionPointers[NxController_doxybind::getPointerStart() + 3]);
    return func(position);
}

const NxExtendedVec3 & NxBoxController_doxybind::getPosition() const
{
    const NxExtendedVec3 & (*func)() = (const NxExtendedVec3 & (*)())(functionPointers[NxController_doxybind::getPointerStart() + 4]);
    return func();
}

const NxExtendedVec3 & NxBoxController_doxybind::getFilteredPosition() const
{
    const NxExtendedVec3 & (*func)() = (const NxExtendedVec3 & (*)())(functionPointers[NxController_doxybind::getPointerStart() + 5]);
    return func();
}

const NxExtendedVec3 & NxBoxController_doxybind::getDebugPosition() const
{
    const NxExtendedVec3 & (*func)() = (const NxExtendedVec3 & (*)())(functionPointers[NxController_doxybind::getPointerStart() + 6]);
    return func();
}

NxActor * NxBoxController_doxybind::getActor() const
{
    NxActor * (*func)() = (NxActor * (*)())(functionPointers[NxController_doxybind::getPointerStart() + 7]);
    return func();
}

void NxBoxController_doxybind::setCollision(bool enabled) 
{
    void (*func)(bool enabled) = (void (*)(bool enabled))(functionPointers[NxController_doxybind::getPointerStart() + 9]);
     func(enabled);
}

void NxBoxController_doxybind::setInteraction(NxCCTInteractionFlag flag) 
{
    void (*func)(NxCCTInteractionFlag flag) = (void (*)(NxCCTInteractionFlag flag))(functionPointers[NxController_doxybind::getPointerStart() + 10]);
     func(flag);
}

NxCCTInteractionFlag NxBoxController_doxybind::getInteraction() const
{
    NxCCTInteractionFlag (*func)() = (NxCCTInteractionFlag (*)())(functionPointers[NxController_doxybind::getPointerStart() + 11]);
    return func();
}

void * NxBoxController_doxybind::getUserData() const
{
    void * (*func)() = (void * (*)())(functionPointers[NxController_doxybind::getPointerStart() + 13]);
    return func();
}

NxControllerType NxBoxController_doxybind::getType() 
{
    NxControllerType (*func)() = (NxControllerType (*)())(functionPointers[NxController_doxybind::getPointerStart() + 14]);
    return func();
}

NxControllerDesc_doxybind::NxControllerDesc_doxybind(NxControllerType unknown5) : NxControllerDesc(unknown5)
{
}

void NxControllerDesc_doxybind::setToDefault() 
{
    void (*func)() = (void (*)())(functionPointers[NxControllerDesc_doxybind::getPointerStart() + 0]);
     func();
}

bool NxControllerDesc_doxybind::isValid() const
{
    bool (*func)() = (bool (*)())(functionPointers[NxControllerDesc_doxybind::getPointerStart() + 1]);
    return func();
}

NxBoxControllerDesc_doxybind::NxBoxControllerDesc_doxybind() : NxBoxControllerDesc()
{
}

void NxBoxControllerDesc_doxybind::setToDefault() 
{
    void (*func)() = (void (*)())(functionPointers[NxBoxControllerDesc_doxybind::getPointerStart() + 0]);
     func();
}

bool NxBoxControllerDesc_doxybind::isValid() const
{
    bool (*func)() = (bool (*)())(functionPointers[NxBoxControllerDesc_doxybind::getPointerStart() + 1]);
    return func();
}

NxForceFieldShape_doxybind::NxForceFieldShape_doxybind() : NxForceFieldShape()
{
}

NxMat34 NxForceFieldShape_doxybind::getPose() const
{
    NxMat34 (*func)() = (NxMat34 (*)())(functionPointers[NxForceFieldShape_doxybind::getPointerStart() + 0]);
    return func();
}

void NxForceFieldShape_doxybind::setPose(const NxMat34 & unknown6) 
{
    void (*func)(const NxMat34 & unknown6) = (void (*)(const NxMat34 & unknown6))(functionPointers[NxForceFieldShape_doxybind::getPointerStart() + 1]);
     func(unknown6);
}

NxForceField * NxForceFieldShape_doxybind::getForceField() const
{
    NxForceField * (*func)() = (NxForceField * (*)())(functionPointers[NxForceFieldShape_doxybind::getPointerStart() + 2]);
    return func();
}

NxForceFieldShapeGroup & NxForceFieldShape_doxybind::getShapeGroup() const
{
    NxForceFieldShapeGroup & (*func)() = (NxForceFieldShapeGroup & (*)())(functionPointers[NxForceFieldShape_doxybind::getPointerStart() + 3]);
    return func();
}

void NxForceFieldShape_doxybind::setName(const char * name) 
{
    void (*func)(const char * name) = (void (*)(const char * name))(functionPointers[NxForceFieldShape_doxybind::getPointerStart() + 4]);
     func(name);
}

const char * NxForceFieldShape_doxybind::getName() const
{
    const char * (*func)() = (const char * (*)())(functionPointers[NxForceFieldShape_doxybind::getPointerStart() + 5]);
    return func();
}

NxShapeType NxForceFieldShape_doxybind::getType() const
{
    NxShapeType (*func)() = (NxShapeType (*)())(functionPointers[NxForceFieldShape_doxybind::getPointerStart() + 6]);
    return func();
}

void NxBoxForceFieldShape_doxybind::setDimensions(const NxVec3 & vec) 
{
    void (*func)(const NxVec3 & vec) = (void (*)(const NxVec3 & vec))(functionPointers[NxBoxForceFieldShape_doxybind::getPointerStart() + 0]);
     func(vec);
}

NxVec3 NxBoxForceFieldShape_doxybind::getDimensions() const
{
    NxVec3 (*func)() = (NxVec3 (*)())(functionPointers[NxBoxForceFieldShape_doxybind::getPointerStart() + 1]);
    return func();
}

void NxBoxForceFieldShape_doxybind::saveToDesc(NxBoxForceFieldShapeDesc & desc) const
{
    void (*func)(NxBoxForceFieldShapeDesc & desc) = (void (*)(NxBoxForceFieldShapeDesc & desc))(functionPointers[NxBoxForceFieldShape_doxybind::getPointerStart() + 2]);
     func(desc);
}

NxMat34 NxBoxForceFieldShape_doxybind::getPose() const
{
    NxMat34 (*func)() = (NxMat34 (*)())(functionPointers[NxForceFieldShape_doxybind::getPointerStart() + 0]);
    return func();
}

void NxBoxForceFieldShape_doxybind::setPose(const NxMat34 & unknown6) 
{
    void (*func)(const NxMat34 & unknown6) = (void (*)(const NxMat34 & unknown6))(functionPointers[NxForceFieldShape_doxybind::getPointerStart() + 1]);
     func(unknown6);
}

NxForceField * NxBoxForceFieldShape_doxybind::getForceField() const
{
    NxForceField * (*func)() = (NxForceField * (*)())(functionPointers[NxForceFieldShape_doxybind::getPointerStart() + 2]);
    return func();
}

NxForceFieldShapeGroup & NxBoxForceFieldShape_doxybind::getShapeGroup() const
{
    NxForceFieldShapeGroup & (*func)() = (NxForceFieldShapeGroup & (*)())(functionPointers[NxForceFieldShape_doxybind::getPointerStart() + 3]);
    return func();
}

void NxBoxForceFieldShape_doxybind::setName(const char * name) 
{
    void (*func)(const char * name) = (void (*)(const char * name))(functionPointers[NxForceFieldShape_doxybind::getPointerStart() + 4]);
     func(name);
}

const char * NxBoxForceFieldShape_doxybind::getName() const
{
    const char * (*func)() = (const char * (*)())(functionPointers[NxForceFieldShape_doxybind::getPointerStart() + 5]);
    return func();
}

NxShapeType NxBoxForceFieldShape_doxybind::getType() const
{
    NxShapeType (*func)() = (NxShapeType (*)())(functionPointers[NxForceFieldShape_doxybind::getPointerStart() + 6]);
    return func();
}

void NxForceFieldShapeDesc_doxybind::setToDefault() 
{
    void (*func)() = (void (*)())(functionPointers[NxForceFieldShapeDesc_doxybind::getPointerStart() + 0]);
     func();
}

bool NxForceFieldShapeDesc_doxybind::isValid() const
{
    bool (*func)() = (bool (*)())(functionPointers[NxForceFieldShapeDesc_doxybind::getPointerStart() + 1]);
    return func();
}

NxForceFieldShapeDesc_doxybind::NxForceFieldShapeDesc_doxybind(NxShapeType type) : NxForceFieldShapeDesc(type)
{
}

NxBoxForceFieldShapeDesc_doxybind::NxBoxForceFieldShapeDesc_doxybind() : NxBoxForceFieldShapeDesc()
{
}

void NxBoxForceFieldShapeDesc_doxybind::setToDefault() 
{
    void (*func)() = (void (*)())(functionPointers[NxBoxForceFieldShapeDesc_doxybind::getPointerStart() + 0]);
     func();
}

bool NxBoxForceFieldShapeDesc_doxybind::isValid() const
{
    bool (*func)() = (bool (*)())(functionPointers[NxBoxForceFieldShapeDesc_doxybind::getPointerStart() + 1]);
    return func();
}

void NxShape_doxybind::setLocalPose(const NxMat34 & mat) 
{
    void (*func)(const NxMat34 & mat) = (void (*)(const NxMat34 & mat))(functionPointers[NxShape_doxybind::getPointerStart() + 0]);
     func(mat);
}

void NxShape_doxybind::setLocalPosition(const NxVec3 & vec) 
{
    void (*func)(const NxVec3 & vec) = (void (*)(const NxVec3 & vec))(functionPointers[NxShape_doxybind::getPointerStart() + 1]);
     func(vec);
}

void NxShape_doxybind::setLocalOrientation(const NxMat33 & mat) 
{
    void (*func)(const NxMat33 & mat) = (void (*)(const NxMat33 & mat))(functionPointers[NxShape_doxybind::getPointerStart() + 2]);
     func(mat);
}

NxMat34 NxShape_doxybind::getLocalPose() const
{
    NxMat34 (*func)() = (NxMat34 (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 3]);
    return func();
}

NxVec3 NxShape_doxybind::getLocalPosition() const
{
    NxVec3 (*func)() = (NxVec3 (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 4]);
    return func();
}

NxMat33 NxShape_doxybind::getLocalOrientation() const
{
    NxMat33 (*func)() = (NxMat33 (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 5]);
    return func();
}

void NxShape_doxybind::setGlobalPose(const NxMat34 & mat) 
{
    void (*func)(const NxMat34 & mat) = (void (*)(const NxMat34 & mat))(functionPointers[NxShape_doxybind::getPointerStart() + 6]);
     func(mat);
}

void NxShape_doxybind::setGlobalPosition(const NxVec3 & vec) 
{
    void (*func)(const NxVec3 & vec) = (void (*)(const NxVec3 & vec))(functionPointers[NxShape_doxybind::getPointerStart() + 7]);
     func(vec);
}

void NxShape_doxybind::setGlobalOrientation(const NxMat33 & mat) 
{
    void (*func)(const NxMat33 & mat) = (void (*)(const NxMat33 & mat))(functionPointers[NxShape_doxybind::getPointerStart() + 8]);
     func(mat);
}

NxMat34 NxShape_doxybind::getGlobalPose() const
{
    NxMat34 (*func)() = (NxMat34 (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 9]);
    return func();
}

NxVec3 NxShape_doxybind::getGlobalPosition() const
{
    NxVec3 (*func)() = (NxVec3 (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 10]);
    return func();
}

NxMat33 NxShape_doxybind::getGlobalOrientation() const
{
    NxMat33 (*func)() = (NxMat33 (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 11]);
    return func();
}

void * NxShape_doxybind::is(NxShapeType type) 
{
    void * (*func)(NxShapeType type) = (void * (*)(NxShapeType type))(functionPointers[NxShape_doxybind::getPointerStart() + 12]);
    return func(type);
}

const void * NxShape_doxybind::is(NxShapeType type) const
{
    const void * (*func)(NxShapeType type) = (const void * (*)(NxShapeType type))(functionPointers[NxShape_doxybind::getPointerStart() + 13]);
    return func(type);
}

bool NxShape_doxybind::raycast(const NxRay & worldRay, NxReal maxDist, NxU32 hintFlags, NxRaycastHit & hit, bool firstHit) const
{
    bool (*func)(const NxRay & worldRay, NxReal maxDist, NxU32 hintFlags, NxRaycastHit & hit, bool firstHit) = (bool (*)(const NxRay & worldRay, NxReal maxDist, NxU32 hintFlags, NxRaycastHit & hit, bool firstHit))(functionPointers[NxShape_doxybind::getPointerStart() + 14]);
    return func(worldRay, maxDist, hintFlags, hit, firstHit);
}

bool NxShape_doxybind::checkOverlapSphere(const NxSphere & worldSphere) const
{
    bool (*func)(const NxSphere & worldSphere) = (bool (*)(const NxSphere & worldSphere))(functionPointers[NxShape_doxybind::getPointerStart() + 15]);
    return func(worldSphere);
}

bool NxShape_doxybind::checkOverlapOBB(const NxBox & worldBox) const
{
    bool (*func)(const NxBox & worldBox) = (bool (*)(const NxBox & worldBox))(functionPointers[NxShape_doxybind::getPointerStart() + 16]);
    return func(worldBox);
}

bool NxShape_doxybind::checkOverlapAABB(const NxBounds3 & worldBounds) const
{
    bool (*func)(const NxBounds3 & worldBounds) = (bool (*)(const NxBounds3 & worldBounds))(functionPointers[NxShape_doxybind::getPointerStart() + 17]);
    return func(worldBounds);
}

bool NxShape_doxybind::checkOverlapCapsule(const NxCapsule & worldCapsule) const
{
    bool (*func)(const NxCapsule & worldCapsule) = (bool (*)(const NxCapsule & worldCapsule))(functionPointers[NxShape_doxybind::getPointerStart() + 18]);
    return func(worldCapsule);
}

NxShape_doxybind::NxShape_doxybind() : NxShape()
{
}

NxActor & NxShape_doxybind::getActor() const
{
    NxActor & (*func)() = (NxActor & (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 19]);
    return func();
}

void NxShape_doxybind::setGroup(NxCollisionGroup collisionGroup) 
{
    void (*func)(NxCollisionGroup collisionGroup) = (void (*)(NxCollisionGroup collisionGroup))(functionPointers[NxShape_doxybind::getPointerStart() + 20]);
     func(collisionGroup);
}

NxCollisionGroup NxShape_doxybind::getGroup() const
{
    NxCollisionGroup (*func)() = (NxCollisionGroup (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 21]);
    return func();
}

void NxShape_doxybind::getWorldBounds(NxBounds3 & dest) const
{
    void (*func)(NxBounds3 & dest) = (void (*)(NxBounds3 & dest))(functionPointers[NxShape_doxybind::getPointerStart() + 22]);
     func(dest);
}

void NxShape_doxybind::setFlag(NxShapeFlag flag, bool value) 
{
    void (*func)(NxShapeFlag flag, bool value) = (void (*)(NxShapeFlag flag, bool value))(functionPointers[NxShape_doxybind::getPointerStart() + 23]);
     func(flag, value);
}

NX_BOOL NxShape_doxybind::getFlag(NxShapeFlag flag) const
{
    NX_BOOL (*func)(NxShapeFlag flag) = (NX_BOOL (*)(NxShapeFlag flag))(functionPointers[NxShape_doxybind::getPointerStart() + 24]);
    return func(flag);
}

void NxShape_doxybind::setMaterial(NxMaterialIndex matIndex) 
{
    void (*func)(NxMaterialIndex matIndex) = (void (*)(NxMaterialIndex matIndex))(functionPointers[NxShape_doxybind::getPointerStart() + 25]);
     func(matIndex);
}

NxMaterialIndex NxShape_doxybind::getMaterial() const
{
    NxMaterialIndex (*func)() = (NxMaterialIndex (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 26]);
    return func();
}

void NxShape_doxybind::setSkinWidth(NxReal skinWidth) 
{
    void (*func)(NxReal skinWidth) = (void (*)(NxReal skinWidth))(functionPointers[NxShape_doxybind::getPointerStart() + 27]);
     func(skinWidth);
}

NxReal NxShape_doxybind::getSkinWidth() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 28]);
    return func();
}

NxShapeType NxShape_doxybind::getType() const
{
    NxShapeType (*func)() = (NxShapeType (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 29]);
    return func();
}

void NxShape_doxybind::setCCDSkeleton(NxCCDSkeleton * ccdSkel) 
{
    void (*func)(NxCCDSkeleton * ccdSkel) = (void (*)(NxCCDSkeleton * ccdSkel))(functionPointers[NxShape_doxybind::getPointerStart() + 30]);
     func(ccdSkel);
}

NxCCDSkeleton * NxShape_doxybind::getCCDSkeleton() const
{
    NxCCDSkeleton * (*func)() = (NxCCDSkeleton * (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 31]);
    return func();
}

void NxShape_doxybind::setName(const char * name) 
{
    void (*func)(const char * name) = (void (*)(const char * name))(functionPointers[NxShape_doxybind::getPointerStart() + 32]);
     func(name);
}

const char * NxShape_doxybind::getName() const
{
    const char * (*func)() = (const char * (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 33]);
    return func();
}

void NxShape_doxybind::setGroupsMask(const NxGroupsMask & mask) 
{
    void (*func)(const NxGroupsMask & mask) = (void (*)(const NxGroupsMask & mask))(functionPointers[NxShape_doxybind::getPointerStart() + 34]);
     func(mask);
}

const NxGroupsMask NxShape_doxybind::getGroupsMask() const
{
    const NxGroupsMask (*func)() = (const NxGroupsMask (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 35]);
    return func();
}

NxU32 NxShape_doxybind::getNonInteractingCompartmentTypes() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 36]);
    return func();
}

void NxShape_doxybind::setNonInteractingCompartmentTypes(NxU32 compartmentTypes) 
{
    void (*func)(NxU32 compartmentTypes) = (void (*)(NxU32 compartmentTypes))(functionPointers[NxShape_doxybind::getPointerStart() + 37]);
     func(compartmentTypes);
}

void NxBoxShape_doxybind::setDimensions(const NxVec3 & vec) 
{
    void (*func)(const NxVec3 & vec) = (void (*)(const NxVec3 & vec))(functionPointers[NxBoxShape_doxybind::getPointerStart() + 0]);
     func(vec);
}

NxVec3 NxBoxShape_doxybind::getDimensions() const
{
    NxVec3 (*func)() = (NxVec3 (*)())(functionPointers[NxBoxShape_doxybind::getPointerStart() + 1]);
    return func();
}

void NxBoxShape_doxybind::getWorldOBB(NxBox & obb) const
{
    void (*func)(NxBox & obb) = (void (*)(NxBox & obb))(functionPointers[NxBoxShape_doxybind::getPointerStart() + 2]);
     func(obb);
}

void NxBoxShape_doxybind::saveToDesc(NxBoxShapeDesc & desc) const
{
    void (*func)(NxBoxShapeDesc & desc) = (void (*)(NxBoxShapeDesc & desc))(functionPointers[NxBoxShape_doxybind::getPointerStart() + 3]);
     func(desc);
}

void NxBoxShape_doxybind::setLocalPose(const NxMat34 & mat) 
{
    void (*func)(const NxMat34 & mat) = (void (*)(const NxMat34 & mat))(functionPointers[NxShape_doxybind::getPointerStart() + 0]);
     func(mat);
}

void NxBoxShape_doxybind::setLocalPosition(const NxVec3 & vec) 
{
    void (*func)(const NxVec3 & vec) = (void (*)(const NxVec3 & vec))(functionPointers[NxShape_doxybind::getPointerStart() + 1]);
     func(vec);
}

void NxBoxShape_doxybind::setLocalOrientation(const NxMat33 & mat) 
{
    void (*func)(const NxMat33 & mat) = (void (*)(const NxMat33 & mat))(functionPointers[NxShape_doxybind::getPointerStart() + 2]);
     func(mat);
}

NxMat34 NxBoxShape_doxybind::getLocalPose() const
{
    NxMat34 (*func)() = (NxMat34 (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 3]);
    return func();
}

NxVec3 NxBoxShape_doxybind::getLocalPosition() const
{
    NxVec3 (*func)() = (NxVec3 (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 4]);
    return func();
}

NxMat33 NxBoxShape_doxybind::getLocalOrientation() const
{
    NxMat33 (*func)() = (NxMat33 (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 5]);
    return func();
}

void NxBoxShape_doxybind::setGlobalPose(const NxMat34 & mat) 
{
    void (*func)(const NxMat34 & mat) = (void (*)(const NxMat34 & mat))(functionPointers[NxShape_doxybind::getPointerStart() + 6]);
     func(mat);
}

void NxBoxShape_doxybind::setGlobalPosition(const NxVec3 & vec) 
{
    void (*func)(const NxVec3 & vec) = (void (*)(const NxVec3 & vec))(functionPointers[NxShape_doxybind::getPointerStart() + 7]);
     func(vec);
}

void NxBoxShape_doxybind::setGlobalOrientation(const NxMat33 & mat) 
{
    void (*func)(const NxMat33 & mat) = (void (*)(const NxMat33 & mat))(functionPointers[NxShape_doxybind::getPointerStart() + 8]);
     func(mat);
}

NxMat34 NxBoxShape_doxybind::getGlobalPose() const
{
    NxMat34 (*func)() = (NxMat34 (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 9]);
    return func();
}

NxVec3 NxBoxShape_doxybind::getGlobalPosition() const
{
    NxVec3 (*func)() = (NxVec3 (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 10]);
    return func();
}

NxMat33 NxBoxShape_doxybind::getGlobalOrientation() const
{
    NxMat33 (*func)() = (NxMat33 (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 11]);
    return func();
}

void * NxBoxShape_doxybind::is(NxShapeType type) 
{
    void * (*func)(NxShapeType type) = (void * (*)(NxShapeType type))(functionPointers[NxShape_doxybind::getPointerStart() + 12]);
    return func(type);
}

const void * NxBoxShape_doxybind::is(NxShapeType type) const
{
    const void * (*func)(NxShapeType type) = (const void * (*)(NxShapeType type))(functionPointers[NxShape_doxybind::getPointerStart() + 13]);
    return func(type);
}

bool NxBoxShape_doxybind::raycast(const NxRay & worldRay, NxReal maxDist, NxU32 hintFlags, NxRaycastHit & hit, bool firstHit) const
{
    bool (*func)(const NxRay & worldRay, NxReal maxDist, NxU32 hintFlags, NxRaycastHit & hit, bool firstHit) = (bool (*)(const NxRay & worldRay, NxReal maxDist, NxU32 hintFlags, NxRaycastHit & hit, bool firstHit))(functionPointers[NxShape_doxybind::getPointerStart() + 14]);
    return func(worldRay, maxDist, hintFlags, hit, firstHit);
}

bool NxBoxShape_doxybind::checkOverlapSphere(const NxSphere & worldSphere) const
{
    bool (*func)(const NxSphere & worldSphere) = (bool (*)(const NxSphere & worldSphere))(functionPointers[NxShape_doxybind::getPointerStart() + 15]);
    return func(worldSphere);
}

bool NxBoxShape_doxybind::checkOverlapOBB(const NxBox & worldBox) const
{
    bool (*func)(const NxBox & worldBox) = (bool (*)(const NxBox & worldBox))(functionPointers[NxShape_doxybind::getPointerStart() + 16]);
    return func(worldBox);
}

bool NxBoxShape_doxybind::checkOverlapAABB(const NxBounds3 & worldBounds) const
{
    bool (*func)(const NxBounds3 & worldBounds) = (bool (*)(const NxBounds3 & worldBounds))(functionPointers[NxShape_doxybind::getPointerStart() + 17]);
    return func(worldBounds);
}

bool NxBoxShape_doxybind::checkOverlapCapsule(const NxCapsule & worldCapsule) const
{
    bool (*func)(const NxCapsule & worldCapsule) = (bool (*)(const NxCapsule & worldCapsule))(functionPointers[NxShape_doxybind::getPointerStart() + 18]);
    return func(worldCapsule);
}

NxActor & NxBoxShape_doxybind::getActor() const
{
    NxActor & (*func)() = (NxActor & (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 19]);
    return func();
}

void NxBoxShape_doxybind::setGroup(NxCollisionGroup collisionGroup) 
{
    void (*func)(NxCollisionGroup collisionGroup) = (void (*)(NxCollisionGroup collisionGroup))(functionPointers[NxShape_doxybind::getPointerStart() + 20]);
     func(collisionGroup);
}

NxCollisionGroup NxBoxShape_doxybind::getGroup() const
{
    NxCollisionGroup (*func)() = (NxCollisionGroup (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 21]);
    return func();
}

void NxBoxShape_doxybind::getWorldBounds(NxBounds3 & dest) const
{
    void (*func)(NxBounds3 & dest) = (void (*)(NxBounds3 & dest))(functionPointers[NxShape_doxybind::getPointerStart() + 22]);
     func(dest);
}

void NxBoxShape_doxybind::setFlag(NxShapeFlag flag, bool value) 
{
    void (*func)(NxShapeFlag flag, bool value) = (void (*)(NxShapeFlag flag, bool value))(functionPointers[NxShape_doxybind::getPointerStart() + 23]);
     func(flag, value);
}

NX_BOOL NxBoxShape_doxybind::getFlag(NxShapeFlag flag) const
{
    NX_BOOL (*func)(NxShapeFlag flag) = (NX_BOOL (*)(NxShapeFlag flag))(functionPointers[NxShape_doxybind::getPointerStart() + 24]);
    return func(flag);
}

void NxBoxShape_doxybind::setMaterial(NxMaterialIndex matIndex) 
{
    void (*func)(NxMaterialIndex matIndex) = (void (*)(NxMaterialIndex matIndex))(functionPointers[NxShape_doxybind::getPointerStart() + 25]);
     func(matIndex);
}

NxMaterialIndex NxBoxShape_doxybind::getMaterial() const
{
    NxMaterialIndex (*func)() = (NxMaterialIndex (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 26]);
    return func();
}

void NxBoxShape_doxybind::setSkinWidth(NxReal skinWidth) 
{
    void (*func)(NxReal skinWidth) = (void (*)(NxReal skinWidth))(functionPointers[NxShape_doxybind::getPointerStart() + 27]);
     func(skinWidth);
}

NxReal NxBoxShape_doxybind::getSkinWidth() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 28]);
    return func();
}

NxShapeType NxBoxShape_doxybind::getType() const
{
    NxShapeType (*func)() = (NxShapeType (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 29]);
    return func();
}

void NxBoxShape_doxybind::setCCDSkeleton(NxCCDSkeleton * ccdSkel) 
{
    void (*func)(NxCCDSkeleton * ccdSkel) = (void (*)(NxCCDSkeleton * ccdSkel))(functionPointers[NxShape_doxybind::getPointerStart() + 30]);
     func(ccdSkel);
}

NxCCDSkeleton * NxBoxShape_doxybind::getCCDSkeleton() const
{
    NxCCDSkeleton * (*func)() = (NxCCDSkeleton * (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 31]);
    return func();
}

void NxBoxShape_doxybind::setName(const char * name) 
{
    void (*func)(const char * name) = (void (*)(const char * name))(functionPointers[NxShape_doxybind::getPointerStart() + 32]);
     func(name);
}

const char * NxBoxShape_doxybind::getName() const
{
    const char * (*func)() = (const char * (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 33]);
    return func();
}

void NxBoxShape_doxybind::setGroupsMask(const NxGroupsMask & mask) 
{
    void (*func)(const NxGroupsMask & mask) = (void (*)(const NxGroupsMask & mask))(functionPointers[NxShape_doxybind::getPointerStart() + 34]);
     func(mask);
}

const NxGroupsMask NxBoxShape_doxybind::getGroupsMask() const
{
    const NxGroupsMask (*func)() = (const NxGroupsMask (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 35]);
    return func();
}

NxU32 NxBoxShape_doxybind::getNonInteractingCompartmentTypes() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 36]);
    return func();
}

void NxBoxShape_doxybind::setNonInteractingCompartmentTypes(NxU32 compartmentTypes) 
{
    void (*func)(NxU32 compartmentTypes) = (void (*)(NxU32 compartmentTypes))(functionPointers[NxShape_doxybind::getPointerStart() + 37]);
     func(compartmentTypes);
}

void NxShapeDesc_doxybind::setToDefault() 
{
    void (*func)() = (void (*)())(functionPointers[NxShapeDesc_doxybind::getPointerStart() + 0]);
     func();
}

bool NxShapeDesc_doxybind::isValid() const
{
    bool (*func)() = (bool (*)())(functionPointers[NxShapeDesc_doxybind::getPointerStart() + 1]);
    return func();
}

NxShapeDesc_doxybind::NxShapeDesc_doxybind(NxShapeType shapeType) : NxShapeDesc(shapeType)
{
}

NxBoxShapeDesc_doxybind::NxBoxShapeDesc_doxybind() : NxBoxShapeDesc()
{
}

void NxBoxShapeDesc_doxybind::setToDefault() 
{
    void (*func)() = (void (*)())(functionPointers[NxBoxShapeDesc_doxybind::getPointerStart() + 0]);
     func();
}

bool NxBoxShapeDesc_doxybind::isValid() const
{
    bool (*func)() = (bool (*)())(functionPointers[NxBoxShapeDesc_doxybind::getPointerStart() + 1]);
    return func();
}

NxCapsuleController_doxybind::NxCapsuleController_doxybind() : NxCapsuleController()
{
}

NxF32 NxCapsuleController_doxybind::getRadius() const
{
    NxF32 (*func)() = (NxF32 (*)())(functionPointers[NxCapsuleController_doxybind::getPointerStart() + 0]);
    return func();
}

bool NxCapsuleController_doxybind::setRadius(NxF32 radius) 
{
    bool (*func)(NxF32 radius) = (bool (*)(NxF32 radius))(functionPointers[NxCapsuleController_doxybind::getPointerStart() + 1]);
    return func(radius);
}

NxF32 NxCapsuleController_doxybind::getHeight() const
{
    NxF32 (*func)() = (NxF32 (*)())(functionPointers[NxCapsuleController_doxybind::getPointerStart() + 2]);
    return func();
}

NxCapsuleClimbingMode NxCapsuleController_doxybind::getClimbingMode() const
{
    NxCapsuleClimbingMode (*func)() = (NxCapsuleClimbingMode (*)())(functionPointers[NxCapsuleController_doxybind::getPointerStart() + 3]);
    return func();
}

bool NxCapsuleController_doxybind::setHeight(NxF32 height) 
{
    bool (*func)(NxF32 height) = (bool (*)(NxF32 height))(functionPointers[NxCapsuleController_doxybind::getPointerStart() + 4]);
    return func(height);
}

void NxCapsuleController_doxybind::setStepOffset(const float offset) 
{
    void (*func)(const float offset) = (void (*)(const float offset))(functionPointers[NxCapsuleController_doxybind::getPointerStart() + 5]);
     func(offset);
}

bool NxCapsuleController_doxybind::setClimbingMode(NxCapsuleClimbingMode mode) 
{
    bool (*func)(NxCapsuleClimbingMode mode) = (bool (*)(NxCapsuleClimbingMode mode))(functionPointers[NxCapsuleController_doxybind::getPointerStart() + 6]);
    return func(mode);
}

void NxCapsuleController_doxybind::reportSceneChanged() 
{
    void (*func)() = (void (*)())(functionPointers[NxCapsuleController_doxybind::getPointerStart() + 7]);
     func();
}

void NxCapsuleController_doxybind::move(const NxVec3 & disp, NxU32 activeGroups, NxF32 minDist, NxU32 & collisionFlags, NxF32 sharpness, const NxGroupsMask * groupsMask) 
{
    void (*func)(const NxVec3 & disp, NxU32 activeGroups, NxF32 minDist, NxU32 & collisionFlags, NxF32 sharpness, const NxGroupsMask * groupsMask) = (void (*)(const NxVec3 & disp, NxU32 activeGroups, NxF32 minDist, NxU32 & collisionFlags, NxF32 sharpness, const NxGroupsMask * groupsMask))(functionPointers[NxController_doxybind::getPointerStart() + 0]);
     func(disp, activeGroups, minDist, collisionFlags, sharpness, groupsMask);
}

void NxCapsuleController_doxybind::move(const NxVec3 & disp, NxU32 activeGroups, NxF32 minDist, NxU32 & collisionFlags, NxF32 sharpness) 
{
    void (*func)(const NxVec3 & disp, NxU32 activeGroups, NxF32 minDist, NxU32 & collisionFlags, NxF32 sharpness) = (void (*)(const NxVec3 & disp, NxU32 activeGroups, NxF32 minDist, NxU32 & collisionFlags, NxF32 sharpness))(functionPointers[NxController_doxybind::getPointerStart() + 1]);
     func(disp, activeGroups, minDist, collisionFlags, sharpness);
}

void NxCapsuleController_doxybind::move(const NxVec3 & disp, NxU32 activeGroups, NxF32 minDist, NxU32 & collisionFlags) 
{
    void (*func)(const NxVec3 & disp, NxU32 activeGroups, NxF32 minDist, NxU32 & collisionFlags) = (void (*)(const NxVec3 & disp, NxU32 activeGroups, NxF32 minDist, NxU32 & collisionFlags))(functionPointers[NxController_doxybind::getPointerStart() + 2]);
     func(disp, activeGroups, minDist, collisionFlags);
}

bool NxCapsuleController_doxybind::setPosition(const NxExtendedVec3 & position) 
{
    bool (*func)(const NxExtendedVec3 & position) = (bool (*)(const NxExtendedVec3 & position))(functionPointers[NxController_doxybind::getPointerStart() + 3]);
    return func(position);
}

const NxExtendedVec3 & NxCapsuleController_doxybind::getPosition() const
{
    const NxExtendedVec3 & (*func)() = (const NxExtendedVec3 & (*)())(functionPointers[NxController_doxybind::getPointerStart() + 4]);
    return func();
}

const NxExtendedVec3 & NxCapsuleController_doxybind::getFilteredPosition() const
{
    const NxExtendedVec3 & (*func)() = (const NxExtendedVec3 & (*)())(functionPointers[NxController_doxybind::getPointerStart() + 5]);
    return func();
}

const NxExtendedVec3 & NxCapsuleController_doxybind::getDebugPosition() const
{
    const NxExtendedVec3 & (*func)() = (const NxExtendedVec3 & (*)())(functionPointers[NxController_doxybind::getPointerStart() + 6]);
    return func();
}

NxActor * NxCapsuleController_doxybind::getActor() const
{
    NxActor * (*func)() = (NxActor * (*)())(functionPointers[NxController_doxybind::getPointerStart() + 7]);
    return func();
}

void NxCapsuleController_doxybind::setCollision(bool enabled) 
{
    void (*func)(bool enabled) = (void (*)(bool enabled))(functionPointers[NxController_doxybind::getPointerStart() + 9]);
     func(enabled);
}

void NxCapsuleController_doxybind::setInteraction(NxCCTInteractionFlag flag) 
{
    void (*func)(NxCCTInteractionFlag flag) = (void (*)(NxCCTInteractionFlag flag))(functionPointers[NxController_doxybind::getPointerStart() + 10]);
     func(flag);
}

NxCCTInteractionFlag NxCapsuleController_doxybind::getInteraction() const
{
    NxCCTInteractionFlag (*func)() = (NxCCTInteractionFlag (*)())(functionPointers[NxController_doxybind::getPointerStart() + 11]);
    return func();
}

void * NxCapsuleController_doxybind::getUserData() const
{
    void * (*func)() = (void * (*)())(functionPointers[NxController_doxybind::getPointerStart() + 13]);
    return func();
}

NxControllerType NxCapsuleController_doxybind::getType() 
{
    NxControllerType (*func)() = (NxControllerType (*)())(functionPointers[NxController_doxybind::getPointerStart() + 14]);
    return func();
}

NxCapsuleControllerDesc_doxybind::NxCapsuleControllerDesc_doxybind() : NxCapsuleControllerDesc()
{
}

void NxCapsuleControllerDesc_doxybind::setToDefault() 
{
    void (*func)() = (void (*)())(functionPointers[NxCapsuleControllerDesc_doxybind::getPointerStart() + 0]);
     func();
}

bool NxCapsuleControllerDesc_doxybind::isValid() const
{
    bool (*func)() = (bool (*)())(functionPointers[NxCapsuleControllerDesc_doxybind::getPointerStart() + 1]);
    return func();
}

void NxCapsuleForceFieldShape_doxybind::setDimensions(NxReal radius, NxReal height) 
{
    void (*func)(NxReal radius, NxReal height) = (void (*)(NxReal radius, NxReal height))(functionPointers[NxCapsuleForceFieldShape_doxybind::getPointerStart() + 0]);
     func(radius, height);
}

void NxCapsuleForceFieldShape_doxybind::setRadius(NxReal radius) 
{
    void (*func)(NxReal radius) = (void (*)(NxReal radius))(functionPointers[NxCapsuleForceFieldShape_doxybind::getPointerStart() + 1]);
     func(radius);
}

NxReal NxCapsuleForceFieldShape_doxybind::getRadius() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxCapsuleForceFieldShape_doxybind::getPointerStart() + 2]);
    return func();
}

void NxCapsuleForceFieldShape_doxybind::setHeight(NxReal height) 
{
    void (*func)(NxReal height) = (void (*)(NxReal height))(functionPointers[NxCapsuleForceFieldShape_doxybind::getPointerStart() + 3]);
     func(height);
}

NxReal NxCapsuleForceFieldShape_doxybind::getHeight() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxCapsuleForceFieldShape_doxybind::getPointerStart() + 4]);
    return func();
}

void NxCapsuleForceFieldShape_doxybind::saveToDesc(NxCapsuleForceFieldShapeDesc & desc) const
{
    void (*func)(NxCapsuleForceFieldShapeDesc & desc) = (void (*)(NxCapsuleForceFieldShapeDesc & desc))(functionPointers[NxCapsuleForceFieldShape_doxybind::getPointerStart() + 5]);
     func(desc);
}

NxMat34 NxCapsuleForceFieldShape_doxybind::getPose() const
{
    NxMat34 (*func)() = (NxMat34 (*)())(functionPointers[NxForceFieldShape_doxybind::getPointerStart() + 0]);
    return func();
}

void NxCapsuleForceFieldShape_doxybind::setPose(const NxMat34 & unknown6) 
{
    void (*func)(const NxMat34 & unknown6) = (void (*)(const NxMat34 & unknown6))(functionPointers[NxForceFieldShape_doxybind::getPointerStart() + 1]);
     func(unknown6);
}

NxForceField * NxCapsuleForceFieldShape_doxybind::getForceField() const
{
    NxForceField * (*func)() = (NxForceField * (*)())(functionPointers[NxForceFieldShape_doxybind::getPointerStart() + 2]);
    return func();
}

NxForceFieldShapeGroup & NxCapsuleForceFieldShape_doxybind::getShapeGroup() const
{
    NxForceFieldShapeGroup & (*func)() = (NxForceFieldShapeGroup & (*)())(functionPointers[NxForceFieldShape_doxybind::getPointerStart() + 3]);
    return func();
}

void NxCapsuleForceFieldShape_doxybind::setName(const char * name) 
{
    void (*func)(const char * name) = (void (*)(const char * name))(functionPointers[NxForceFieldShape_doxybind::getPointerStart() + 4]);
     func(name);
}

const char * NxCapsuleForceFieldShape_doxybind::getName() const
{
    const char * (*func)() = (const char * (*)())(functionPointers[NxForceFieldShape_doxybind::getPointerStart() + 5]);
    return func();
}

NxShapeType NxCapsuleForceFieldShape_doxybind::getType() const
{
    NxShapeType (*func)() = (NxShapeType (*)())(functionPointers[NxForceFieldShape_doxybind::getPointerStart() + 6]);
    return func();
}

NxCapsuleForceFieldShapeDesc_doxybind::NxCapsuleForceFieldShapeDesc_doxybind() : NxCapsuleForceFieldShapeDesc()
{
}

void NxCapsuleForceFieldShapeDesc_doxybind::setToDefault() 
{
    void (*func)() = (void (*)())(functionPointers[NxCapsuleForceFieldShapeDesc_doxybind::getPointerStart() + 0]);
     func();
}

bool NxCapsuleForceFieldShapeDesc_doxybind::isValid() const
{
    bool (*func)() = (bool (*)())(functionPointers[NxCapsuleForceFieldShapeDesc_doxybind::getPointerStart() + 1]);
    return func();
}

void NxCapsuleShape_doxybind::setDimensions(NxReal radius, NxReal height) 
{
    void (*func)(NxReal radius, NxReal height) = (void (*)(NxReal radius, NxReal height))(functionPointers[NxCapsuleShape_doxybind::getPointerStart() + 0]);
     func(radius, height);
}

void NxCapsuleShape_doxybind::setRadius(NxReal radius) 
{
    void (*func)(NxReal radius) = (void (*)(NxReal radius))(functionPointers[NxCapsuleShape_doxybind::getPointerStart() + 1]);
     func(radius);
}

NxReal NxCapsuleShape_doxybind::getRadius() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxCapsuleShape_doxybind::getPointerStart() + 2]);
    return func();
}

void NxCapsuleShape_doxybind::setHeight(NxReal height) 
{
    void (*func)(NxReal height) = (void (*)(NxReal height))(functionPointers[NxCapsuleShape_doxybind::getPointerStart() + 3]);
     func(height);
}

NxReal NxCapsuleShape_doxybind::getHeight() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxCapsuleShape_doxybind::getPointerStart() + 4]);
    return func();
}

void NxCapsuleShape_doxybind::getWorldCapsule(NxCapsule & worldCapsule) const
{
    void (*func)(NxCapsule & worldCapsule) = (void (*)(NxCapsule & worldCapsule))(functionPointers[NxCapsuleShape_doxybind::getPointerStart() + 5]);
     func(worldCapsule);
}

void NxCapsuleShape_doxybind::saveToDesc(NxCapsuleShapeDesc & desc) const
{
    void (*func)(NxCapsuleShapeDesc & desc) = (void (*)(NxCapsuleShapeDesc & desc))(functionPointers[NxCapsuleShape_doxybind::getPointerStart() + 6]);
     func(desc);
}

void NxCapsuleShape_doxybind::setLocalPose(const NxMat34 & mat) 
{
    void (*func)(const NxMat34 & mat) = (void (*)(const NxMat34 & mat))(functionPointers[NxShape_doxybind::getPointerStart() + 0]);
     func(mat);
}

void NxCapsuleShape_doxybind::setLocalPosition(const NxVec3 & vec) 
{
    void (*func)(const NxVec3 & vec) = (void (*)(const NxVec3 & vec))(functionPointers[NxShape_doxybind::getPointerStart() + 1]);
     func(vec);
}

void NxCapsuleShape_doxybind::setLocalOrientation(const NxMat33 & mat) 
{
    void (*func)(const NxMat33 & mat) = (void (*)(const NxMat33 & mat))(functionPointers[NxShape_doxybind::getPointerStart() + 2]);
     func(mat);
}

NxMat34 NxCapsuleShape_doxybind::getLocalPose() const
{
    NxMat34 (*func)() = (NxMat34 (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 3]);
    return func();
}

NxVec3 NxCapsuleShape_doxybind::getLocalPosition() const
{
    NxVec3 (*func)() = (NxVec3 (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 4]);
    return func();
}

NxMat33 NxCapsuleShape_doxybind::getLocalOrientation() const
{
    NxMat33 (*func)() = (NxMat33 (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 5]);
    return func();
}

void NxCapsuleShape_doxybind::setGlobalPose(const NxMat34 & mat) 
{
    void (*func)(const NxMat34 & mat) = (void (*)(const NxMat34 & mat))(functionPointers[NxShape_doxybind::getPointerStart() + 6]);
     func(mat);
}

void NxCapsuleShape_doxybind::setGlobalPosition(const NxVec3 & vec) 
{
    void (*func)(const NxVec3 & vec) = (void (*)(const NxVec3 & vec))(functionPointers[NxShape_doxybind::getPointerStart() + 7]);
     func(vec);
}

void NxCapsuleShape_doxybind::setGlobalOrientation(const NxMat33 & mat) 
{
    void (*func)(const NxMat33 & mat) = (void (*)(const NxMat33 & mat))(functionPointers[NxShape_doxybind::getPointerStart() + 8]);
     func(mat);
}

NxMat34 NxCapsuleShape_doxybind::getGlobalPose() const
{
    NxMat34 (*func)() = (NxMat34 (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 9]);
    return func();
}

NxVec3 NxCapsuleShape_doxybind::getGlobalPosition() const
{
    NxVec3 (*func)() = (NxVec3 (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 10]);
    return func();
}

NxMat33 NxCapsuleShape_doxybind::getGlobalOrientation() const
{
    NxMat33 (*func)() = (NxMat33 (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 11]);
    return func();
}

void * NxCapsuleShape_doxybind::is(NxShapeType type) 
{
    void * (*func)(NxShapeType type) = (void * (*)(NxShapeType type))(functionPointers[NxShape_doxybind::getPointerStart() + 12]);
    return func(type);
}

const void * NxCapsuleShape_doxybind::is(NxShapeType type) const
{
    const void * (*func)(NxShapeType type) = (const void * (*)(NxShapeType type))(functionPointers[NxShape_doxybind::getPointerStart() + 13]);
    return func(type);
}

bool NxCapsuleShape_doxybind::raycast(const NxRay & worldRay, NxReal maxDist, NxU32 hintFlags, NxRaycastHit & hit, bool firstHit) const
{
    bool (*func)(const NxRay & worldRay, NxReal maxDist, NxU32 hintFlags, NxRaycastHit & hit, bool firstHit) = (bool (*)(const NxRay & worldRay, NxReal maxDist, NxU32 hintFlags, NxRaycastHit & hit, bool firstHit))(functionPointers[NxShape_doxybind::getPointerStart() + 14]);
    return func(worldRay, maxDist, hintFlags, hit, firstHit);
}

bool NxCapsuleShape_doxybind::checkOverlapSphere(const NxSphere & worldSphere) const
{
    bool (*func)(const NxSphere & worldSphere) = (bool (*)(const NxSphere & worldSphere))(functionPointers[NxShape_doxybind::getPointerStart() + 15]);
    return func(worldSphere);
}

bool NxCapsuleShape_doxybind::checkOverlapOBB(const NxBox & worldBox) const
{
    bool (*func)(const NxBox & worldBox) = (bool (*)(const NxBox & worldBox))(functionPointers[NxShape_doxybind::getPointerStart() + 16]);
    return func(worldBox);
}

bool NxCapsuleShape_doxybind::checkOverlapAABB(const NxBounds3 & worldBounds) const
{
    bool (*func)(const NxBounds3 & worldBounds) = (bool (*)(const NxBounds3 & worldBounds))(functionPointers[NxShape_doxybind::getPointerStart() + 17]);
    return func(worldBounds);
}

bool NxCapsuleShape_doxybind::checkOverlapCapsule(const NxCapsule & worldCapsule) const
{
    bool (*func)(const NxCapsule & worldCapsule) = (bool (*)(const NxCapsule & worldCapsule))(functionPointers[NxShape_doxybind::getPointerStart() + 18]);
    return func(worldCapsule);
}

NxActor & NxCapsuleShape_doxybind::getActor() const
{
    NxActor & (*func)() = (NxActor & (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 19]);
    return func();
}

void NxCapsuleShape_doxybind::setGroup(NxCollisionGroup collisionGroup) 
{
    void (*func)(NxCollisionGroup collisionGroup) = (void (*)(NxCollisionGroup collisionGroup))(functionPointers[NxShape_doxybind::getPointerStart() + 20]);
     func(collisionGroup);
}

NxCollisionGroup NxCapsuleShape_doxybind::getGroup() const
{
    NxCollisionGroup (*func)() = (NxCollisionGroup (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 21]);
    return func();
}

void NxCapsuleShape_doxybind::getWorldBounds(NxBounds3 & dest) const
{
    void (*func)(NxBounds3 & dest) = (void (*)(NxBounds3 & dest))(functionPointers[NxShape_doxybind::getPointerStart() + 22]);
     func(dest);
}

void NxCapsuleShape_doxybind::setFlag(NxShapeFlag flag, bool value) 
{
    void (*func)(NxShapeFlag flag, bool value) = (void (*)(NxShapeFlag flag, bool value))(functionPointers[NxShape_doxybind::getPointerStart() + 23]);
     func(flag, value);
}

NX_BOOL NxCapsuleShape_doxybind::getFlag(NxShapeFlag flag) const
{
    NX_BOOL (*func)(NxShapeFlag flag) = (NX_BOOL (*)(NxShapeFlag flag))(functionPointers[NxShape_doxybind::getPointerStart() + 24]);
    return func(flag);
}

void NxCapsuleShape_doxybind::setMaterial(NxMaterialIndex matIndex) 
{
    void (*func)(NxMaterialIndex matIndex) = (void (*)(NxMaterialIndex matIndex))(functionPointers[NxShape_doxybind::getPointerStart() + 25]);
     func(matIndex);
}

NxMaterialIndex NxCapsuleShape_doxybind::getMaterial() const
{
    NxMaterialIndex (*func)() = (NxMaterialIndex (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 26]);
    return func();
}

void NxCapsuleShape_doxybind::setSkinWidth(NxReal skinWidth) 
{
    void (*func)(NxReal skinWidth) = (void (*)(NxReal skinWidth))(functionPointers[NxShape_doxybind::getPointerStart() + 27]);
     func(skinWidth);
}

NxReal NxCapsuleShape_doxybind::getSkinWidth() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 28]);
    return func();
}

NxShapeType NxCapsuleShape_doxybind::getType() const
{
    NxShapeType (*func)() = (NxShapeType (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 29]);
    return func();
}

void NxCapsuleShape_doxybind::setCCDSkeleton(NxCCDSkeleton * ccdSkel) 
{
    void (*func)(NxCCDSkeleton * ccdSkel) = (void (*)(NxCCDSkeleton * ccdSkel))(functionPointers[NxShape_doxybind::getPointerStart() + 30]);
     func(ccdSkel);
}

NxCCDSkeleton * NxCapsuleShape_doxybind::getCCDSkeleton() const
{
    NxCCDSkeleton * (*func)() = (NxCCDSkeleton * (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 31]);
    return func();
}

void NxCapsuleShape_doxybind::setName(const char * name) 
{
    void (*func)(const char * name) = (void (*)(const char * name))(functionPointers[NxShape_doxybind::getPointerStart() + 32]);
     func(name);
}

const char * NxCapsuleShape_doxybind::getName() const
{
    const char * (*func)() = (const char * (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 33]);
    return func();
}

void NxCapsuleShape_doxybind::setGroupsMask(const NxGroupsMask & mask) 
{
    void (*func)(const NxGroupsMask & mask) = (void (*)(const NxGroupsMask & mask))(functionPointers[NxShape_doxybind::getPointerStart() + 34]);
     func(mask);
}

const NxGroupsMask NxCapsuleShape_doxybind::getGroupsMask() const
{
    const NxGroupsMask (*func)() = (const NxGroupsMask (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 35]);
    return func();
}

NxU32 NxCapsuleShape_doxybind::getNonInteractingCompartmentTypes() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 36]);
    return func();
}

void NxCapsuleShape_doxybind::setNonInteractingCompartmentTypes(NxU32 compartmentTypes) 
{
    void (*func)(NxU32 compartmentTypes) = (void (*)(NxU32 compartmentTypes))(functionPointers[NxShape_doxybind::getPointerStart() + 37]);
     func(compartmentTypes);
}

NxCapsuleShapeDesc_doxybind::NxCapsuleShapeDesc_doxybind() : NxCapsuleShapeDesc()
{
}

void NxCapsuleShapeDesc_doxybind::setToDefault() 
{
    void (*func)() = (void (*)())(functionPointers[NxCapsuleShapeDesc_doxybind::getPointerStart() + 0]);
     func();
}

bool NxCapsuleShapeDesc_doxybind::isValid() const
{
    bool (*func)() = (bool (*)())(functionPointers[NxCapsuleShapeDesc_doxybind::getPointerStart() + 1]);
    return func();
}

NxU32 NxCCDSkeleton_doxybind::save(void * destBuffer, NxU32 bufferSize) 
{
    NxU32 (*func)(void * destBuffer, NxU32 bufferSize) = (NxU32 (*)(void * destBuffer, NxU32 bufferSize))(functionPointers[NxCCDSkeleton_doxybind::getPointerStart() + 0]);
    return func(destBuffer, bufferSize);
}

NxU32 NxCCDSkeleton_doxybind::getDataSize() 
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxCCDSkeleton_doxybind::getPointerStart() + 1]);
    return func();
}

NxU32 NxCCDSkeleton_doxybind::getReferenceCount() 
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxCCDSkeleton_doxybind::getPointerStart() + 2]);
    return func();
}

NxU32 NxCCDSkeleton_doxybind::saveToDesc(NxSimpleTriangleMesh & desc) 
{
    NxU32 (*func)(NxSimpleTriangleMesh & desc) = (NxU32 (*)(NxSimpleTriangleMesh & desc))(functionPointers[NxCCDSkeleton_doxybind::getPointerStart() + 3]);
    return func(desc);
}

NxCloth_doxybind::NxCloth_doxybind() : NxCloth()
{
}

bool NxCloth_doxybind::saveToDesc(NxClothDesc & desc) const
{
    bool (*func)(NxClothDesc & desc) = (bool (*)(NxClothDesc & desc))(functionPointers[NxCloth_doxybind::getPointerStart() + 0]);
    return func(desc);
}

NxClothMesh * NxCloth_doxybind::getClothMesh() const
{
    NxClothMesh * (*func)() = (NxClothMesh * (*)())(functionPointers[NxCloth_doxybind::getPointerStart() + 1]);
    return func();
}

void NxCloth_doxybind::setBendingStiffness(NxReal stiffness) 
{
    void (*func)(NxReal stiffness) = (void (*)(NxReal stiffness))(functionPointers[NxCloth_doxybind::getPointerStart() + 2]);
     func(stiffness);
}

NxReal NxCloth_doxybind::getBendingStiffness() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxCloth_doxybind::getPointerStart() + 3]);
    return func();
}

void NxCloth_doxybind::setStretchingStiffness(NxReal stiffness) 
{
    void (*func)(NxReal stiffness) = (void (*)(NxReal stiffness))(functionPointers[NxCloth_doxybind::getPointerStart() + 4]);
     func(stiffness);
}

NxReal NxCloth_doxybind::getStretchingStiffness() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxCloth_doxybind::getPointerStart() + 5]);
    return func();
}

void NxCloth_doxybind::setDampingCoefficient(NxReal dampingCoefficient) 
{
    void (*func)(NxReal dampingCoefficient) = (void (*)(NxReal dampingCoefficient))(functionPointers[NxCloth_doxybind::getPointerStart() + 6]);
     func(dampingCoefficient);
}

NxReal NxCloth_doxybind::getDampingCoefficient() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxCloth_doxybind::getPointerStart() + 7]);
    return func();
}

void NxCloth_doxybind::setFriction(NxReal friction) 
{
    void (*func)(NxReal friction) = (void (*)(NxReal friction))(functionPointers[NxCloth_doxybind::getPointerStart() + 8]);
     func(friction);
}

NxReal NxCloth_doxybind::getFriction() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxCloth_doxybind::getPointerStart() + 9]);
    return func();
}

void NxCloth_doxybind::setPressure(NxReal pressure) 
{
    void (*func)(NxReal pressure) = (void (*)(NxReal pressure))(functionPointers[NxCloth_doxybind::getPointerStart() + 10]);
     func(pressure);
}

NxReal NxCloth_doxybind::getPressure() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxCloth_doxybind::getPointerStart() + 11]);
    return func();
}

void NxCloth_doxybind::setTearFactor(NxReal factor) 
{
    void (*func)(NxReal factor) = (void (*)(NxReal factor))(functionPointers[NxCloth_doxybind::getPointerStart() + 12]);
     func(factor);
}

NxReal NxCloth_doxybind::getTearFactor() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxCloth_doxybind::getPointerStart() + 13]);
    return func();
}

void NxCloth_doxybind::setAttachmentTearFactor(NxReal factor) 
{
    void (*func)(NxReal factor) = (void (*)(NxReal factor))(functionPointers[NxCloth_doxybind::getPointerStart() + 14]);
     func(factor);
}

NxReal NxCloth_doxybind::getAttachmentTearFactor() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxCloth_doxybind::getPointerStart() + 15]);
    return func();
}

void NxCloth_doxybind::setThickness(NxReal thickness) 
{
    void (*func)(NxReal thickness) = (void (*)(NxReal thickness))(functionPointers[NxCloth_doxybind::getPointerStart() + 16]);
     func(thickness);
}

NxReal NxCloth_doxybind::getThickness() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxCloth_doxybind::getPointerStart() + 17]);
    return func();
}

NxReal NxCloth_doxybind::getDensity() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxCloth_doxybind::getPointerStart() + 18]);
    return func();
}

NxReal NxCloth_doxybind::getRelativeGridSpacing() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxCloth_doxybind::getPointerStart() + 19]);
    return func();
}

NxU32 NxCloth_doxybind::getSolverIterations() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxCloth_doxybind::getPointerStart() + 20]);
    return func();
}

void NxCloth_doxybind::setSolverIterations(NxU32 iterations) 
{
    void (*func)(NxU32 iterations) = (void (*)(NxU32 iterations))(functionPointers[NxCloth_doxybind::getPointerStart() + 21]);
     func(iterations);
}

void NxCloth_doxybind::getWorldBounds(NxBounds3 & bounds) const
{
    void (*func)(NxBounds3 & bounds) = (void (*)(NxBounds3 & bounds))(functionPointers[NxCloth_doxybind::getPointerStart() + 22]);
     func(bounds);
}

void NxCloth_doxybind::attachToShape(const NxShape * shape, NxU32 attachmentFlags) 
{
    void (*func)(const NxShape * shape, NxU32 attachmentFlags) = (void (*)(const NxShape * shape, NxU32 attachmentFlags))(functionPointers[NxCloth_doxybind::getPointerStart() + 23]);
     func(shape, attachmentFlags);
}

void NxCloth_doxybind::attachToCollidingShapes(NxU32 attachmentFlags) 
{
    void (*func)(NxU32 attachmentFlags) = (void (*)(NxU32 attachmentFlags))(functionPointers[NxCloth_doxybind::getPointerStart() + 24]);
     func(attachmentFlags);
}

void NxCloth_doxybind::detachFromShape(const NxShape * shape) 
{
    void (*func)(const NxShape * shape) = (void (*)(const NxShape * shape))(functionPointers[NxCloth_doxybind::getPointerStart() + 25]);
     func(shape);
}

void NxCloth_doxybind::attachVertexToShape(NxU32 vertexId, const NxShape * shape, const NxVec3 & localPos, NxU32 attachmentFlags) 
{
    void (*func)(NxU32 vertexId, const NxShape * shape, const NxVec3 & localPos, NxU32 attachmentFlags) = (void (*)(NxU32 vertexId, const NxShape * shape, const NxVec3 & localPos, NxU32 attachmentFlags))(functionPointers[NxCloth_doxybind::getPointerStart() + 26]);
     func(vertexId, shape, localPos, attachmentFlags);
}

void NxCloth_doxybind::attachVertexToGlobalPosition(const NxU32 vertexId, const NxVec3 & pos) 
{
    void (*func)(const NxU32 vertexId, const NxVec3 & pos) = (void (*)(const NxU32 vertexId, const NxVec3 & pos))(functionPointers[NxCloth_doxybind::getPointerStart() + 27]);
     func(vertexId, pos);
}

void NxCloth_doxybind::freeVertex(const NxU32 vertexId) 
{
    void (*func)(const NxU32 vertexId) = (void (*)(const NxU32 vertexId))(functionPointers[NxCloth_doxybind::getPointerStart() + 28]);
     func(vertexId);
}

void NxCloth_doxybind::dominateVertex(NxU32 vertexId, NxReal expirationTime, NxReal dominanceWeight) 
{
    void (*func)(NxU32 vertexId, NxReal expirationTime, NxReal dominanceWeight) = (void (*)(NxU32 vertexId, NxReal expirationTime, NxReal dominanceWeight))(functionPointers[NxCloth_doxybind::getPointerStart() + 29]);
     func(vertexId, expirationTime, dominanceWeight);
}

NxClothVertexAttachmentStatus NxCloth_doxybind::getVertexAttachmentStatus(NxU32 vertexId) const
{
    NxClothVertexAttachmentStatus (*func)(NxU32 vertexId) = (NxClothVertexAttachmentStatus (*)(NxU32 vertexId))(functionPointers[NxCloth_doxybind::getPointerStart() + 30]);
    return func(vertexId);
}

NxShape * NxCloth_doxybind::getVertexAttachmentShape(NxU32 vertexId) const
{
    NxShape * (*func)(NxU32 vertexId) = (NxShape * (*)(NxU32 vertexId))(functionPointers[NxCloth_doxybind::getPointerStart() + 31]);
    return func(vertexId);
}

NxVec3 NxCloth_doxybind::getVertexAttachmentPosition(NxU32 vertexId) const
{
    NxVec3 (*func)(NxU32 vertexId) = (NxVec3 (*)(NxU32 vertexId))(functionPointers[NxCloth_doxybind::getPointerStart() + 32]);
    return func(vertexId);
}

void NxCloth_doxybind::attachToCore(NxActor * actor, NxReal impulseThreshold, NxReal penetrationDepth, NxReal maxDeformationDistance) 
{
    void (*func)(NxActor * actor, NxReal impulseThreshold, NxReal penetrationDepth, NxReal maxDeformationDistance) = (void (*)(NxActor * actor, NxReal impulseThreshold, NxReal penetrationDepth, NxReal maxDeformationDistance))(functionPointers[NxCloth_doxybind::getPointerStart() + 33]);
     func(actor, impulseThreshold, penetrationDepth, maxDeformationDistance);
}

void NxCloth_doxybind::attachToCore(NxActor * actor, NxReal impulseThreshold, NxReal penetrationDepth) 
{
    void (*func)(NxActor * actor, NxReal impulseThreshold, NxReal penetrationDepth) = (void (*)(NxActor * actor, NxReal impulseThreshold, NxReal penetrationDepth))(functionPointers[NxCloth_doxybind::getPointerStart() + 34]);
     func(actor, impulseThreshold, penetrationDepth);
}

void NxCloth_doxybind::attachToCore(NxActor * actor, NxReal impulseThreshold) 
{
    void (*func)(NxActor * actor, NxReal impulseThreshold) = (void (*)(NxActor * actor, NxReal impulseThreshold))(functionPointers[NxCloth_doxybind::getPointerStart() + 35]);
     func(actor, impulseThreshold);
}

bool NxCloth_doxybind::tearVertex(const NxU32 vertexId, const NxVec3 & normal) 
{
    bool (*func)(const NxU32 vertexId, const NxVec3 & normal) = (bool (*)(const NxU32 vertexId, const NxVec3 & normal))(functionPointers[NxCloth_doxybind::getPointerStart() + 36]);
    return func(vertexId, normal);
}

bool NxCloth_doxybind::raycast(const NxRay & worldRay, NxVec3 & hit, NxU32 & vertexId) 
{
    bool (*func)(const NxRay & worldRay, NxVec3 & hit, NxU32 & vertexId) = (bool (*)(const NxRay & worldRay, NxVec3 & hit, NxU32 & vertexId))(functionPointers[NxCloth_doxybind::getPointerStart() + 37]);
    return func(worldRay, hit, vertexId);
}

void NxCloth_doxybind::setGroup(NxCollisionGroup collisionGroup) 
{
    void (*func)(NxCollisionGroup collisionGroup) = (void (*)(NxCollisionGroup collisionGroup))(functionPointers[NxCloth_doxybind::getPointerStart() + 38]);
     func(collisionGroup);
}

NxCollisionGroup NxCloth_doxybind::getGroup() const
{
    NxCollisionGroup (*func)() = (NxCollisionGroup (*)())(functionPointers[NxCloth_doxybind::getPointerStart() + 39]);
    return func();
}

void NxCloth_doxybind::setGroupsMask(const NxGroupsMask & groupsMask) 
{
    void (*func)(const NxGroupsMask & groupsMask) = (void (*)(const NxGroupsMask & groupsMask))(functionPointers[NxCloth_doxybind::getPointerStart() + 40]);
     func(groupsMask);
}

const NxGroupsMask NxCloth_doxybind::getGroupsMask() const
{
    const NxGroupsMask (*func)() = (const NxGroupsMask (*)())(functionPointers[NxCloth_doxybind::getPointerStart() + 41]);
    return func();
}

void NxCloth_doxybind::setMeshData(NxMeshData & meshData) 
{
    void (*func)(NxMeshData & meshData) = (void (*)(NxMeshData & meshData))(functionPointers[NxCloth_doxybind::getPointerStart() + 42]);
     func(meshData);
}

NxMeshData NxCloth_doxybind::getMeshData() 
{
    NxMeshData (*func)() = (NxMeshData (*)())(functionPointers[NxCloth_doxybind::getPointerStart() + 43]);
    return func();
}

void NxCloth_doxybind::setValidBounds(const NxBounds3 & validBounds) 
{
    void (*func)(const NxBounds3 & validBounds) = (void (*)(const NxBounds3 & validBounds))(functionPointers[NxCloth_doxybind::getPointerStart() + 44]);
     func(validBounds);
}

void NxCloth_doxybind::getValidBounds(NxBounds3 & validBounds) const
{
    void (*func)(NxBounds3 & validBounds) = (void (*)(NxBounds3 & validBounds))(functionPointers[NxCloth_doxybind::getPointerStart() + 45]);
     func(validBounds);
}

void NxCloth_doxybind::setPosition(const NxVec3 & position, NxU32 vertexId) 
{
    void (*func)(const NxVec3 & position, NxU32 vertexId) = (void (*)(const NxVec3 & position, NxU32 vertexId))(functionPointers[NxCloth_doxybind::getPointerStart() + 46]);
     func(position, vertexId);
}

void NxCloth_doxybind::setPositions(void * buffer, NxU32 byteStride) 
{
    void (*func)(void * buffer, NxU32 byteStride) = (void (*)(void * buffer, NxU32 byteStride))(functionPointers[NxCloth_doxybind::getPointerStart() + 47]);
     func(buffer, byteStride);
}

void NxCloth_doxybind::setPositions(void * buffer) 
{
    void (*func)(void * buffer) = (void (*)(void * buffer))(functionPointers[NxCloth_doxybind::getPointerStart() + 48]);
     func(buffer);
}

NxVec3 NxCloth_doxybind::getPosition(NxU32 vertexId) const
{
    NxVec3 (*func)(NxU32 vertexId) = (NxVec3 (*)(NxU32 vertexId))(functionPointers[NxCloth_doxybind::getPointerStart() + 49]);
    return func(vertexId);
}

void NxCloth_doxybind::getPositions(void * buffer, NxU32 byteStride) 
{
    void (*func)(void * buffer, NxU32 byteStride) = (void (*)(void * buffer, NxU32 byteStride))(functionPointers[NxCloth_doxybind::getPointerStart() + 50]);
     func(buffer, byteStride);
}

void NxCloth_doxybind::getPositions(void * buffer) 
{
    void (*func)(void * buffer) = (void (*)(void * buffer))(functionPointers[NxCloth_doxybind::getPointerStart() + 51]);
     func(buffer);
}

void NxCloth_doxybind::setVelocity(const NxVec3 & velocity, NxU32 vertexId) 
{
    void (*func)(const NxVec3 & velocity, NxU32 vertexId) = (void (*)(const NxVec3 & velocity, NxU32 vertexId))(functionPointers[NxCloth_doxybind::getPointerStart() + 52]);
     func(velocity, vertexId);
}

void NxCloth_doxybind::setVelocities(void * buffer, NxU32 byteStride) 
{
    void (*func)(void * buffer, NxU32 byteStride) = (void (*)(void * buffer, NxU32 byteStride))(functionPointers[NxCloth_doxybind::getPointerStart() + 53]);
     func(buffer, byteStride);
}

void NxCloth_doxybind::setVelocities(void * buffer) 
{
    void (*func)(void * buffer) = (void (*)(void * buffer))(functionPointers[NxCloth_doxybind::getPointerStart() + 54]);
     func(buffer);
}

NxVec3 NxCloth_doxybind::getVelocity(NxU32 vertexId) const
{
    NxVec3 (*func)(NxU32 vertexId) = (NxVec3 (*)(NxU32 vertexId))(functionPointers[NxCloth_doxybind::getPointerStart() + 55]);
    return func(vertexId);
}

void NxCloth_doxybind::getVelocities(void * buffer, NxU32 byteStride) 
{
    void (*func)(void * buffer, NxU32 byteStride) = (void (*)(void * buffer, NxU32 byteStride))(functionPointers[NxCloth_doxybind::getPointerStart() + 56]);
     func(buffer, byteStride);
}

void NxCloth_doxybind::getVelocities(void * buffer) 
{
    void (*func)(void * buffer) = (void (*)(void * buffer))(functionPointers[NxCloth_doxybind::getPointerStart() + 57]);
     func(buffer);
}

NxU32 NxCloth_doxybind::getNumberOfParticles() 
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxCloth_doxybind::getPointerStart() + 58]);
    return func();
}

NxU32 NxCloth_doxybind::queryShapePointers() 
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxCloth_doxybind::getPointerStart() + 59]);
    return func();
}

NxU32 NxCloth_doxybind::getStateByteSize() 
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxCloth_doxybind::getPointerStart() + 60]);
    return func();
}

void NxCloth_doxybind::getShapePointers(NxShape ** shapePointers, NxU32 * flags) 
{
    void (*func)(NxShape ** shapePointers, NxU32 * flags) = (void (*)(NxShape ** shapePointers, NxU32 * flags))(functionPointers[NxCloth_doxybind::getPointerStart() + 61]);
     func(shapePointers, flags);
}

void NxCloth_doxybind::getShapePointers(NxShape ** shapePointers) 
{
    void (*func)(NxShape ** shapePointers) = (void (*)(NxShape ** shapePointers))(functionPointers[NxCloth_doxybind::getPointerStart() + 62]);
     func(shapePointers);
}

void NxCloth_doxybind::setShapePointers(NxShape ** shapePointers, unsigned int numShapes) 
{
    void (*func)(NxShape ** shapePointers, unsigned int numShapes) = (void (*)(NxShape ** shapePointers, unsigned int numShapes))(functionPointers[NxCloth_doxybind::getPointerStart() + 63]);
     func(shapePointers, numShapes);
}

void NxCloth_doxybind::saveStateToStream(NxStream & stream, bool permute) 
{
    void (*func)(NxStream & stream, bool permute) = (void (*)(NxStream & stream, bool permute))(functionPointers[NxCloth_doxybind::getPointerStart() + 64]);
     func(stream, permute);
}

void NxCloth_doxybind::saveStateToStream(NxStream & stream) 
{
    void (*func)(NxStream & stream) = (void (*)(NxStream & stream))(functionPointers[NxCloth_doxybind::getPointerStart() + 65]);
     func(stream);
}

void NxCloth_doxybind::loadStateFromStream(NxStream & stream) 
{
    void (*func)(NxStream & stream) = (void (*)(NxStream & stream))(functionPointers[NxCloth_doxybind::getPointerStart() + 66]);
     func(stream);
}

void NxCloth_doxybind::setCollisionResponseCoefficient(NxReal coefficient) 
{
    void (*func)(NxReal coefficient) = (void (*)(NxReal coefficient))(functionPointers[NxCloth_doxybind::getPointerStart() + 67]);
     func(coefficient);
}

NxReal NxCloth_doxybind::getCollisionResponseCoefficient() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxCloth_doxybind::getPointerStart() + 68]);
    return func();
}

void NxCloth_doxybind::setAttachmentResponseCoefficient(NxReal coefficient) 
{
    void (*func)(NxReal coefficient) = (void (*)(NxReal coefficient))(functionPointers[NxCloth_doxybind::getPointerStart() + 69]);
     func(coefficient);
}

NxReal NxCloth_doxybind::getAttachmentResponseCoefficient() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxCloth_doxybind::getPointerStart() + 70]);
    return func();
}

void NxCloth_doxybind::setFromFluidResponseCoefficient(NxReal coefficient) 
{
    void (*func)(NxReal coefficient) = (void (*)(NxReal coefficient))(functionPointers[NxCloth_doxybind::getPointerStart() + 71]);
     func(coefficient);
}

NxReal NxCloth_doxybind::getFromFluidResponseCoefficient() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxCloth_doxybind::getPointerStart() + 72]);
    return func();
}

void NxCloth_doxybind::setToFluidResponseCoefficient(NxReal coefficient) 
{
    void (*func)(NxReal coefficient) = (void (*)(NxReal coefficient))(functionPointers[NxCloth_doxybind::getPointerStart() + 73]);
     func(coefficient);
}

NxReal NxCloth_doxybind::getToFluidResponseCoefficient() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxCloth_doxybind::getPointerStart() + 74]);
    return func();
}

void NxCloth_doxybind::setExternalAcceleration(NxVec3 acceleration) 
{
    void (*func)(NxVec3 acceleration) = (void (*)(NxVec3 acceleration))(functionPointers[NxCloth_doxybind::getPointerStart() + 75]);
     func(acceleration);
}

NxVec3 NxCloth_doxybind::getExternalAcceleration() const
{
    NxVec3 (*func)() = (NxVec3 (*)())(functionPointers[NxCloth_doxybind::getPointerStart() + 76]);
    return func();
}

void NxCloth_doxybind::setMinAdhereVelocity(NxReal velocity) 
{
    void (*func)(NxReal velocity) = (void (*)(NxReal velocity))(functionPointers[NxCloth_doxybind::getPointerStart() + 77]);
     func(velocity);
}

NxReal NxCloth_doxybind::getMinAdhereVelocity() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxCloth_doxybind::getPointerStart() + 78]);
    return func();
}

void NxCloth_doxybind::setWindAcceleration(NxVec3 acceleration) 
{
    void (*func)(NxVec3 acceleration) = (void (*)(NxVec3 acceleration))(functionPointers[NxCloth_doxybind::getPointerStart() + 79]);
     func(acceleration);
}

NxVec3 NxCloth_doxybind::getWindAcceleration() const
{
    NxVec3 (*func)() = (NxVec3 (*)())(functionPointers[NxCloth_doxybind::getPointerStart() + 80]);
    return func();
}

bool NxCloth_doxybind::isSleeping() const
{
    bool (*func)() = (bool (*)())(functionPointers[NxCloth_doxybind::getPointerStart() + 81]);
    return func();
}

NxReal NxCloth_doxybind::getSleepLinearVelocity() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxCloth_doxybind::getPointerStart() + 82]);
    return func();
}

void NxCloth_doxybind::setSleepLinearVelocity(NxReal threshold) 
{
    void (*func)(NxReal threshold) = (void (*)(NxReal threshold))(functionPointers[NxCloth_doxybind::getPointerStart() + 83]);
     func(threshold);
}

void NxCloth_doxybind::wakeUp(NxReal wakeCounterValue) 
{
    void (*func)(NxReal wakeCounterValue) = (void (*)(NxReal wakeCounterValue))(functionPointers[NxCloth_doxybind::getPointerStart() + 84]);
     func(wakeCounterValue);
}

void NxCloth_doxybind::putToSleep() 
{
    void (*func)() = (void (*)())(functionPointers[NxCloth_doxybind::getPointerStart() + 85]);
     func();
}

void NxCloth_doxybind::setFlags(NxU32 flags) 
{
    void (*func)(NxU32 flags) = (void (*)(NxU32 flags))(functionPointers[NxCloth_doxybind::getPointerStart() + 86]);
     func(flags);
}

NxU32 NxCloth_doxybind::getFlags() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxCloth_doxybind::getPointerStart() + 87]);
    return func();
}

void NxCloth_doxybind::setName(const char * name) 
{
    void (*func)(const char * name) = (void (*)(const char * name))(functionPointers[NxCloth_doxybind::getPointerStart() + 88]);
     func(name);
}

void NxCloth_doxybind::addForceAtVertex(const NxVec3 & force, NxU32 vertexId, NxForceMode mode) 
{
    void (*func)(const NxVec3 & force, NxU32 vertexId, NxForceMode mode) = (void (*)(const NxVec3 & force, NxU32 vertexId, NxForceMode mode))(functionPointers[NxCloth_doxybind::getPointerStart() + 89]);
     func(force, vertexId, mode);
}

void NxCloth_doxybind::addForceAtVertex(const NxVec3 & force, NxU32 vertexId) 
{
    void (*func)(const NxVec3 & force, NxU32 vertexId) = (void (*)(const NxVec3 & force, NxU32 vertexId))(functionPointers[NxCloth_doxybind::getPointerStart() + 90]);
     func(force, vertexId);
}

void NxCloth_doxybind::addForceAtPos(const NxVec3 & position, NxReal magnitude, NxReal radius, NxForceMode mode) 
{
    void (*func)(const NxVec3 & position, NxReal magnitude, NxReal radius, NxForceMode mode) = (void (*)(const NxVec3 & position, NxReal magnitude, NxReal radius, NxForceMode mode))(functionPointers[NxCloth_doxybind::getPointerStart() + 91]);
     func(position, magnitude, radius, mode);
}

void NxCloth_doxybind::addForceAtPos(const NxVec3 & position, NxReal magnitude, NxReal radius) 
{
    void (*func)(const NxVec3 & position, NxReal magnitude, NxReal radius) = (void (*)(const NxVec3 & position, NxReal magnitude, NxReal radius))(functionPointers[NxCloth_doxybind::getPointerStart() + 92]);
     func(position, magnitude, radius);
}

void NxCloth_doxybind::addDirectedForceAtPos(const NxVec3 & position, const NxVec3 & force, NxReal radius, NxForceMode mode) 
{
    void (*func)(const NxVec3 & position, const NxVec3 & force, NxReal radius, NxForceMode mode) = (void (*)(const NxVec3 & position, const NxVec3 & force, NxReal radius, NxForceMode mode))(functionPointers[NxCloth_doxybind::getPointerStart() + 93]);
     func(position, force, radius, mode);
}

void NxCloth_doxybind::addDirectedForceAtPos(const NxVec3 & position, const NxVec3 & force, NxReal radius) 
{
    void (*func)(const NxVec3 & position, const NxVec3 & force, NxReal radius) = (void (*)(const NxVec3 & position, const NxVec3 & force, NxReal radius))(functionPointers[NxCloth_doxybind::getPointerStart() + 94]);
     func(position, force, radius);
}

bool NxCloth_doxybind::overlapAABBTriangles(const NxBounds3 & bounds, NxU32 & nb, const NxU32 *& indices) const
{
    bool (*func)(const NxBounds3 & bounds, NxU32 & nb, const NxU32 *& indices) = (bool (*)(const NxBounds3 & bounds, NxU32 & nb, const NxU32 *& indices))(functionPointers[NxCloth_doxybind::getPointerStart() + 95]);
    return func(bounds, nb, indices);
}

NxScene & NxCloth_doxybind::getScene() const
{
    NxScene & (*func)() = (NxScene & (*)())(functionPointers[NxCloth_doxybind::getPointerStart() + 96]);
    return func();
}

const char * NxCloth_doxybind::getName() const
{
    const char * (*func)() = (const char * (*)())(functionPointers[NxCloth_doxybind::getPointerStart() + 97]);
    return func();
}

NxCompartment * NxCloth_doxybind::getCompartment() const
{
    NxCompartment * (*func)() = (NxCompartment * (*)())(functionPointers[NxCloth_doxybind::getPointerStart() + 98]);
    return func();
}

NxU32 NxCloth_doxybind::getPPUTime() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxCloth_doxybind::getPointerStart() + 99]);
    return func();
}

NxForceFieldMaterial NxCloth_doxybind::getForceFieldMaterial() const
{
    NxForceFieldMaterial (*func)() = (NxForceFieldMaterial (*)())(functionPointers[NxCloth_doxybind::getPointerStart() + 100]);
    return func();
}

void NxCloth_doxybind::setForceFieldMaterial(NxForceFieldMaterial unknown7) 
{
    void (*func)(NxForceFieldMaterial unknown7) = (void (*)(NxForceFieldMaterial unknown7))(functionPointers[NxCloth_doxybind::getPointerStart() + 101]);
     func(unknown7);
}

NxClothMesh_doxybind::NxClothMesh_doxybind() : NxClothMesh()
{
}

bool NxClothMesh_doxybind::saveToDesc(NxClothMeshDesc & desc) const
{
    bool (*func)(NxClothMeshDesc & desc) = (bool (*)(NxClothMeshDesc & desc))(functionPointers[NxClothMesh_doxybind::getPointerStart() + 0]);
    return func(desc);
}

NxU32 NxClothMesh_doxybind::getReferenceCount() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxClothMesh_doxybind::getPointerStart() + 1]);
    return func();
}

NxCompartmentType NxCompartment_doxybind::getType() const
{
    NxCompartmentType (*func)() = (NxCompartmentType (*)())(functionPointers[NxCompartment_doxybind::getPointerStart() + 0]);
    return func();
}

NxU32 NxCompartment_doxybind::getDeviceCode() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxCompartment_doxybind::getPointerStart() + 1]);
    return func();
}

NxReal NxCompartment_doxybind::getGridHashCellSize() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxCompartment_doxybind::getPointerStart() + 2]);
    return func();
}

NxU32 NxCompartment_doxybind::gridHashTablePower() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxCompartment_doxybind::getPointerStart() + 3]);
    return func();
}

void NxCompartment_doxybind::setTimeScale(NxReal unknown8) 
{
    void (*func)(NxReal unknown8) = (void (*)(NxReal unknown8))(functionPointers[NxCompartment_doxybind::getPointerStart() + 4]);
     func(unknown8);
}

NxReal NxCompartment_doxybind::getTimeScale() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxCompartment_doxybind::getPointerStart() + 5]);
    return func();
}

void NxCompartment_doxybind::setTiming(NxReal maxTimestep, NxU32 maxIter, NxTimeStepMethod method) 
{
    void (*func)(NxReal maxTimestep, NxU32 maxIter, NxTimeStepMethod method) = (void (*)(NxReal maxTimestep, NxU32 maxIter, NxTimeStepMethod method))(functionPointers[NxCompartment_doxybind::getPointerStart() + 6]);
     func(maxTimestep, maxIter, method);
}

void NxCompartment_doxybind::setTiming(NxReal maxTimestep, NxU32 maxIter) 
{
    void (*func)(NxReal maxTimestep, NxU32 maxIter) = (void (*)(NxReal maxTimestep, NxU32 maxIter))(functionPointers[NxCompartment_doxybind::getPointerStart() + 7]);
     func(maxTimestep, maxIter);
}

void NxCompartment_doxybind::setTiming(NxReal maxTimestep) 
{
    void (*func)(NxReal maxTimestep) = (void (*)(NxReal maxTimestep))(functionPointers[NxCompartment_doxybind::getPointerStart() + 8]);
     func(maxTimestep);
}

void NxCompartment_doxybind::getTiming(NxReal & maxTimestep, NxU32 & maxIter, NxTimeStepMethod & method, NxU32 * numSubSteps) const
{
    void (*func)(NxReal & maxTimestep, NxU32 & maxIter, NxTimeStepMethod & method, NxU32 * numSubSteps) = (void (*)(NxReal & maxTimestep, NxU32 & maxIter, NxTimeStepMethod & method, NxU32 * numSubSteps))(functionPointers[NxCompartment_doxybind::getPointerStart() + 9]);
     func(maxTimestep, maxIter, method, numSubSteps);
}

void NxCompartment_doxybind::getTiming(NxReal & maxTimestep, NxU32 & maxIter, NxTimeStepMethod & method) const
{
    void (*func)(NxReal & maxTimestep, NxU32 & maxIter, NxTimeStepMethod & method) = (void (*)(NxReal & maxTimestep, NxU32 & maxIter, NxTimeStepMethod & method))(functionPointers[NxCompartment_doxybind::getPointerStart() + 10]);
     func(maxTimestep, maxIter, method);
}

bool NxCompartment_doxybind::checkResults(bool block) 
{
    bool (*func)(bool block) = (bool (*)(bool block))(functionPointers[NxCompartment_doxybind::getPointerStart() + 11]);
    return func(block);
}

bool NxCompartment_doxybind::fetchResults(bool block) 
{
    bool (*func)(bool block) = (bool (*)(bool block))(functionPointers[NxCompartment_doxybind::getPointerStart() + 12]);
    return func(block);
}

bool NxCompartment_doxybind::saveToDesc(NxCompartmentDesc & desc) const
{
    bool (*func)(NxCompartmentDesc & desc) = (bool (*)(NxCompartmentDesc & desc))(functionPointers[NxCompartment_doxybind::getPointerStart() + 13]);
    return func(desc);
}

void NxCompartment_doxybind::setFlags(NxU32 flags) 
{
    void (*func)(NxU32 flags) = (void (*)(NxU32 flags))(functionPointers[NxCompartment_doxybind::getPointerStart() + 14]);
     func(flags);
}

NxU32 NxCompartment_doxybind::getFlags() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxCompartment_doxybind::getPointerStart() + 15]);
    return func();
}

NxU32 NxControllerManager_doxybind::getNbControllers() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxControllerManager_doxybind::getPointerStart() + 0]);
    return func();
}

NxController * NxControllerManager_doxybind::getController(NxU32 index) 
{
    NxController * (*func)(NxU32 index) = (NxController * (*)(NxU32 index))(functionPointers[NxControllerManager_doxybind::getPointerStart() + 1]);
    return func(index);
}

NxController * NxControllerManager_doxybind::createController(NxScene * scene, const NxControllerDesc & desc) 
{
    NxController * (*func)(NxScene * scene, const NxControllerDesc & desc) = (NxController * (*)(NxScene * scene, const NxControllerDesc & desc))(functionPointers[NxControllerManager_doxybind::getPointerStart() + 2]);
    return func(scene, desc);
}

void NxControllerManager_doxybind::releaseController(NxController & controller) 
{
    void (*func)(NxController & controller) = (void (*)(NxController & controller))(functionPointers[NxControllerManager_doxybind::getPointerStart() + 3]);
     func(controller);
}

void NxControllerManager_doxybind::purgeControllers() 
{
    void (*func)() = (void (*)())(functionPointers[NxControllerManager_doxybind::getPointerStart() + 4]);
     func();
}

void NxControllerManager_doxybind::updateControllers() 
{
    void (*func)() = (void (*)())(functionPointers[NxControllerManager_doxybind::getPointerStart() + 5]);
     func();
}

NxDebugRenderable NxControllerManager_doxybind::getDebugData() 
{
    NxDebugRenderable (*func)() = (NxDebugRenderable (*)())(functionPointers[NxControllerManager_doxybind::getPointerStart() + 6]);
    return func();
}

void NxControllerManager_doxybind::resetDebugData() 
{
    void (*func)() = (void (*)())(functionPointers[NxControllerManager_doxybind::getPointerStart() + 7]);
     func();
}

NxControllerManager_doxybind::NxControllerManager_doxybind() : NxControllerManager()
{
}

void NxControllerManager_doxybind::release() 
{
    void (*func)() = (void (*)())(functionPointers[NxControllerManager_doxybind::getPointerStart() + 8]);
     func();
}

void NxConvexForceFieldShape_doxybind::saveToDesc(NxConvexForceFieldShapeDesc & desc) const
{
    void (*func)(NxConvexForceFieldShapeDesc & desc) = (void (*)(NxConvexForceFieldShapeDesc & desc))(functionPointers[NxConvexForceFieldShape_doxybind::getPointerStart() + 0]);
     func(desc);
}

NxMat34 NxConvexForceFieldShape_doxybind::getPose() const
{
    NxMat34 (*func)() = (NxMat34 (*)())(functionPointers[NxForceFieldShape_doxybind::getPointerStart() + 0]);
    return func();
}

void NxConvexForceFieldShape_doxybind::setPose(const NxMat34 & unknown6) 
{
    void (*func)(const NxMat34 & unknown6) = (void (*)(const NxMat34 & unknown6))(functionPointers[NxForceFieldShape_doxybind::getPointerStart() + 1]);
     func(unknown6);
}

NxForceField * NxConvexForceFieldShape_doxybind::getForceField() const
{
    NxForceField * (*func)() = (NxForceField * (*)())(functionPointers[NxForceFieldShape_doxybind::getPointerStart() + 2]);
    return func();
}

NxForceFieldShapeGroup & NxConvexForceFieldShape_doxybind::getShapeGroup() const
{
    NxForceFieldShapeGroup & (*func)() = (NxForceFieldShapeGroup & (*)())(functionPointers[NxForceFieldShape_doxybind::getPointerStart() + 3]);
    return func();
}

void NxConvexForceFieldShape_doxybind::setName(const char * name) 
{
    void (*func)(const char * name) = (void (*)(const char * name))(functionPointers[NxForceFieldShape_doxybind::getPointerStart() + 4]);
     func(name);
}

const char * NxConvexForceFieldShape_doxybind::getName() const
{
    const char * (*func)() = (const char * (*)())(functionPointers[NxForceFieldShape_doxybind::getPointerStart() + 5]);
    return func();
}

NxShapeType NxConvexForceFieldShape_doxybind::getType() const
{
    NxShapeType (*func)() = (NxShapeType (*)())(functionPointers[NxForceFieldShape_doxybind::getPointerStart() + 6]);
    return func();
}

NxConvexForceFieldShapeDesc_doxybind::NxConvexForceFieldShapeDesc_doxybind() : NxConvexForceFieldShapeDesc()
{
}

void NxConvexForceFieldShapeDesc_doxybind::setToDefault() 
{
    void (*func)() = (void (*)())(functionPointers[NxConvexForceFieldShapeDesc_doxybind::getPointerStart() + 0]);
     func();
}

bool NxConvexForceFieldShapeDesc_doxybind::isValid() const
{
    bool (*func)() = (bool (*)())(functionPointers[NxConvexForceFieldShapeDesc_doxybind::getPointerStart() + 1]);
    return func();
}

bool NxConvexMesh_doxybind::saveToDesc(NxConvexMeshDesc & desc) const
{
    bool (*func)(NxConvexMeshDesc & desc) = (bool (*)(NxConvexMeshDesc & desc))(functionPointers[NxConvexMesh_doxybind::getPointerStart() + 0]);
    return func(desc);
}

NxU32 NxConvexMesh_doxybind::getSubmeshCount() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxConvexMesh_doxybind::getPointerStart() + 1]);
    return func();
}

NxU32 NxConvexMesh_doxybind::getCount(NxSubmeshIndex submeshIndex, NxInternalArray intArray) const
{
    NxU32 (*func)(NxSubmeshIndex submeshIndex, NxInternalArray intArray) = (NxU32 (*)(NxSubmeshIndex submeshIndex, NxInternalArray intArray))(functionPointers[NxConvexMesh_doxybind::getPointerStart() + 2]);
    return func(submeshIndex, intArray);
}

NxInternalFormat NxConvexMesh_doxybind::getFormat(NxSubmeshIndex submeshIndex, NxInternalArray intArray) const
{
    NxInternalFormat (*func)(NxSubmeshIndex submeshIndex, NxInternalArray intArray) = (NxInternalFormat (*)(NxSubmeshIndex submeshIndex, NxInternalArray intArray))(functionPointers[NxConvexMesh_doxybind::getPointerStart() + 3]);
    return func(submeshIndex, intArray);
}

const void * NxConvexMesh_doxybind::getBase(NxSubmeshIndex submeshIndex, NxInternalArray intArray) const
{
    const void * (*func)(NxSubmeshIndex submeshIndex, NxInternalArray intArray) = (const void * (*)(NxSubmeshIndex submeshIndex, NxInternalArray intArray))(functionPointers[NxConvexMesh_doxybind::getPointerStart() + 4]);
    return func(submeshIndex, intArray);
}

NxU32 NxConvexMesh_doxybind::getStride(NxSubmeshIndex submeshIndex, NxInternalArray intArray) const
{
    NxU32 (*func)(NxSubmeshIndex submeshIndex, NxInternalArray intArray) = (NxU32 (*)(NxSubmeshIndex submeshIndex, NxInternalArray intArray))(functionPointers[NxConvexMesh_doxybind::getPointerStart() + 5]);
    return func(submeshIndex, intArray);
}

bool NxConvexMesh_doxybind::load(const NxStream & stream) 
{
    bool (*func)(const NxStream & stream) = (bool (*)(const NxStream & stream))(functionPointers[NxConvexMesh_doxybind::getPointerStart() + 6]);
    return func(stream);
}

NxU32 NxConvexMesh_doxybind::getReferenceCount() 
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxConvexMesh_doxybind::getPointerStart() + 7]);
    return func();
}

void NxConvexMesh_doxybind::getMassInformation(NxReal & mass, NxMat33 & localInertia, NxVec3 & localCenterOfMass) const
{
    void (*func)(NxReal & mass, NxMat33 & localInertia, NxVec3 & localCenterOfMass) = (void (*)(NxReal & mass, NxMat33 & localInertia, NxVec3 & localCenterOfMass))(functionPointers[NxConvexMesh_doxybind::getPointerStart() + 8]);
     func(mass, localInertia, localCenterOfMass);
}

void * NxConvexMesh_doxybind::getInternal() 
{
    void * (*func)() = (void * (*)())(functionPointers[NxConvexMesh_doxybind::getPointerStart() + 9]);
    return func();
}

void NxConvexShape_doxybind::saveToDesc(NxConvexShapeDesc & desc) const
{
    void (*func)(NxConvexShapeDesc & desc) = (void (*)(NxConvexShapeDesc & desc))(functionPointers[NxConvexShape_doxybind::getPointerStart() + 0]);
     func(desc);
}

NxConvexMesh & NxConvexShape_doxybind::getConvexMesh() 
{
    NxConvexMesh & (*func)() = (NxConvexMesh & (*)())(functionPointers[NxConvexShape_doxybind::getPointerStart() + 1]);
    return func();
}

const NxConvexMesh & NxConvexShape_doxybind::getConvexMesh() const
{
    const NxConvexMesh & (*func)() = (const NxConvexMesh & (*)())(functionPointers[NxConvexShape_doxybind::getPointerStart() + 2]);
    return func();
}

void NxConvexShape_doxybind::setLocalPose(const NxMat34 & mat) 
{
    void (*func)(const NxMat34 & mat) = (void (*)(const NxMat34 & mat))(functionPointers[NxShape_doxybind::getPointerStart() + 0]);
     func(mat);
}

void NxConvexShape_doxybind::setLocalPosition(const NxVec3 & vec) 
{
    void (*func)(const NxVec3 & vec) = (void (*)(const NxVec3 & vec))(functionPointers[NxShape_doxybind::getPointerStart() + 1]);
     func(vec);
}

void NxConvexShape_doxybind::setLocalOrientation(const NxMat33 & mat) 
{
    void (*func)(const NxMat33 & mat) = (void (*)(const NxMat33 & mat))(functionPointers[NxShape_doxybind::getPointerStart() + 2]);
     func(mat);
}

NxMat34 NxConvexShape_doxybind::getLocalPose() const
{
    NxMat34 (*func)() = (NxMat34 (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 3]);
    return func();
}

NxVec3 NxConvexShape_doxybind::getLocalPosition() const
{
    NxVec3 (*func)() = (NxVec3 (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 4]);
    return func();
}

NxMat33 NxConvexShape_doxybind::getLocalOrientation() const
{
    NxMat33 (*func)() = (NxMat33 (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 5]);
    return func();
}

void NxConvexShape_doxybind::setGlobalPose(const NxMat34 & mat) 
{
    void (*func)(const NxMat34 & mat) = (void (*)(const NxMat34 & mat))(functionPointers[NxShape_doxybind::getPointerStart() + 6]);
     func(mat);
}

void NxConvexShape_doxybind::setGlobalPosition(const NxVec3 & vec) 
{
    void (*func)(const NxVec3 & vec) = (void (*)(const NxVec3 & vec))(functionPointers[NxShape_doxybind::getPointerStart() + 7]);
     func(vec);
}

void NxConvexShape_doxybind::setGlobalOrientation(const NxMat33 & mat) 
{
    void (*func)(const NxMat33 & mat) = (void (*)(const NxMat33 & mat))(functionPointers[NxShape_doxybind::getPointerStart() + 8]);
     func(mat);
}

NxMat34 NxConvexShape_doxybind::getGlobalPose() const
{
    NxMat34 (*func)() = (NxMat34 (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 9]);
    return func();
}

NxVec3 NxConvexShape_doxybind::getGlobalPosition() const
{
    NxVec3 (*func)() = (NxVec3 (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 10]);
    return func();
}

NxMat33 NxConvexShape_doxybind::getGlobalOrientation() const
{
    NxMat33 (*func)() = (NxMat33 (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 11]);
    return func();
}

void * NxConvexShape_doxybind::is(NxShapeType type) 
{
    void * (*func)(NxShapeType type) = (void * (*)(NxShapeType type))(functionPointers[NxShape_doxybind::getPointerStart() + 12]);
    return func(type);
}

const void * NxConvexShape_doxybind::is(NxShapeType type) const
{
    const void * (*func)(NxShapeType type) = (const void * (*)(NxShapeType type))(functionPointers[NxShape_doxybind::getPointerStart() + 13]);
    return func(type);
}

bool NxConvexShape_doxybind::raycast(const NxRay & worldRay, NxReal maxDist, NxU32 hintFlags, NxRaycastHit & hit, bool firstHit) const
{
    bool (*func)(const NxRay & worldRay, NxReal maxDist, NxU32 hintFlags, NxRaycastHit & hit, bool firstHit) = (bool (*)(const NxRay & worldRay, NxReal maxDist, NxU32 hintFlags, NxRaycastHit & hit, bool firstHit))(functionPointers[NxShape_doxybind::getPointerStart() + 14]);
    return func(worldRay, maxDist, hintFlags, hit, firstHit);
}

bool NxConvexShape_doxybind::checkOverlapSphere(const NxSphere & worldSphere) const
{
    bool (*func)(const NxSphere & worldSphere) = (bool (*)(const NxSphere & worldSphere))(functionPointers[NxShape_doxybind::getPointerStart() + 15]);
    return func(worldSphere);
}

bool NxConvexShape_doxybind::checkOverlapOBB(const NxBox & worldBox) const
{
    bool (*func)(const NxBox & worldBox) = (bool (*)(const NxBox & worldBox))(functionPointers[NxShape_doxybind::getPointerStart() + 16]);
    return func(worldBox);
}

bool NxConvexShape_doxybind::checkOverlapAABB(const NxBounds3 & worldBounds) const
{
    bool (*func)(const NxBounds3 & worldBounds) = (bool (*)(const NxBounds3 & worldBounds))(functionPointers[NxShape_doxybind::getPointerStart() + 17]);
    return func(worldBounds);
}

bool NxConvexShape_doxybind::checkOverlapCapsule(const NxCapsule & worldCapsule) const
{
    bool (*func)(const NxCapsule & worldCapsule) = (bool (*)(const NxCapsule & worldCapsule))(functionPointers[NxShape_doxybind::getPointerStart() + 18]);
    return func(worldCapsule);
}

NxActor & NxConvexShape_doxybind::getActor() const
{
    NxActor & (*func)() = (NxActor & (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 19]);
    return func();
}

void NxConvexShape_doxybind::setGroup(NxCollisionGroup collisionGroup) 
{
    void (*func)(NxCollisionGroup collisionGroup) = (void (*)(NxCollisionGroup collisionGroup))(functionPointers[NxShape_doxybind::getPointerStart() + 20]);
     func(collisionGroup);
}

NxCollisionGroup NxConvexShape_doxybind::getGroup() const
{
    NxCollisionGroup (*func)() = (NxCollisionGroup (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 21]);
    return func();
}

void NxConvexShape_doxybind::getWorldBounds(NxBounds3 & dest) const
{
    void (*func)(NxBounds3 & dest) = (void (*)(NxBounds3 & dest))(functionPointers[NxShape_doxybind::getPointerStart() + 22]);
     func(dest);
}

void NxConvexShape_doxybind::setFlag(NxShapeFlag flag, bool value) 
{
    void (*func)(NxShapeFlag flag, bool value) = (void (*)(NxShapeFlag flag, bool value))(functionPointers[NxShape_doxybind::getPointerStart() + 23]);
     func(flag, value);
}

NX_BOOL NxConvexShape_doxybind::getFlag(NxShapeFlag flag) const
{
    NX_BOOL (*func)(NxShapeFlag flag) = (NX_BOOL (*)(NxShapeFlag flag))(functionPointers[NxShape_doxybind::getPointerStart() + 24]);
    return func(flag);
}

void NxConvexShape_doxybind::setMaterial(NxMaterialIndex matIndex) 
{
    void (*func)(NxMaterialIndex matIndex) = (void (*)(NxMaterialIndex matIndex))(functionPointers[NxShape_doxybind::getPointerStart() + 25]);
     func(matIndex);
}

NxMaterialIndex NxConvexShape_doxybind::getMaterial() const
{
    NxMaterialIndex (*func)() = (NxMaterialIndex (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 26]);
    return func();
}

void NxConvexShape_doxybind::setSkinWidth(NxReal skinWidth) 
{
    void (*func)(NxReal skinWidth) = (void (*)(NxReal skinWidth))(functionPointers[NxShape_doxybind::getPointerStart() + 27]);
     func(skinWidth);
}

NxReal NxConvexShape_doxybind::getSkinWidth() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 28]);
    return func();
}

NxShapeType NxConvexShape_doxybind::getType() const
{
    NxShapeType (*func)() = (NxShapeType (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 29]);
    return func();
}

void NxConvexShape_doxybind::setCCDSkeleton(NxCCDSkeleton * ccdSkel) 
{
    void (*func)(NxCCDSkeleton * ccdSkel) = (void (*)(NxCCDSkeleton * ccdSkel))(functionPointers[NxShape_doxybind::getPointerStart() + 30]);
     func(ccdSkel);
}

NxCCDSkeleton * NxConvexShape_doxybind::getCCDSkeleton() const
{
    NxCCDSkeleton * (*func)() = (NxCCDSkeleton * (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 31]);
    return func();
}

void NxConvexShape_doxybind::setName(const char * name) 
{
    void (*func)(const char * name) = (void (*)(const char * name))(functionPointers[NxShape_doxybind::getPointerStart() + 32]);
     func(name);
}

const char * NxConvexShape_doxybind::getName() const
{
    const char * (*func)() = (const char * (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 33]);
    return func();
}

void NxConvexShape_doxybind::setGroupsMask(const NxGroupsMask & mask) 
{
    void (*func)(const NxGroupsMask & mask) = (void (*)(const NxGroupsMask & mask))(functionPointers[NxShape_doxybind::getPointerStart() + 34]);
     func(mask);
}

const NxGroupsMask NxConvexShape_doxybind::getGroupsMask() const
{
    const NxGroupsMask (*func)() = (const NxGroupsMask (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 35]);
    return func();
}

NxU32 NxConvexShape_doxybind::getNonInteractingCompartmentTypes() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 36]);
    return func();
}

void NxConvexShape_doxybind::setNonInteractingCompartmentTypes(NxU32 compartmentTypes) 
{
    void (*func)(NxU32 compartmentTypes) = (void (*)(NxU32 compartmentTypes))(functionPointers[NxShape_doxybind::getPointerStart() + 37]);
     func(compartmentTypes);
}

NxConvexShapeDesc_doxybind::NxConvexShapeDesc_doxybind() : NxConvexShapeDesc()
{
}

void NxConvexShapeDesc_doxybind::setToDefault() 
{
    void (*func)() = (void (*)())(functionPointers[NxConvexShapeDesc_doxybind::getPointerStart() + 0]);
     func();
}

bool NxConvexShapeDesc_doxybind::isValid() const
{
    bool (*func)() = (bool (*)())(functionPointers[NxConvexShapeDesc_doxybind::getPointerStart() + 1]);
    return func();
}

bool NxCookingInterface_doxybind::NxSetCookingParams(const NxCookingParams & params) 
{
    bool (*func)(const NxCookingParams & params) = (bool (*)(const NxCookingParams & params))(functionPointers[NxCookingInterface_doxybind::getPointerStart() + 0]);
    return func(params);
}

const NxCookingParams & NxCookingInterface_doxybind::NxGetCookingParams() 
{
    const NxCookingParams & (*func)() = (const NxCookingParams & (*)())(functionPointers[NxCookingInterface_doxybind::getPointerStart() + 1]);
    return func();
}

bool NxCookingInterface_doxybind::NxPlatformMismatch() 
{
    bool (*func)() = (bool (*)())(functionPointers[NxCookingInterface_doxybind::getPointerStart() + 2]);
    return func();
}

bool NxCookingInterface_doxybind::NxInitCooking(NxUserAllocator * allocator, NxUserOutputStream * outputStream) 
{
    bool (*func)(NxUserAllocator * allocator, NxUserOutputStream * outputStream) = (bool (*)(NxUserAllocator * allocator, NxUserOutputStream * outputStream))(functionPointers[NxCookingInterface_doxybind::getPointerStart() + 3]);
    return func(allocator, outputStream);
}

bool NxCookingInterface_doxybind::NxInitCooking(NxUserAllocator * allocator) 
{
    bool (*func)(NxUserAllocator * allocator) = (bool (*)(NxUserAllocator * allocator))(functionPointers[NxCookingInterface_doxybind::getPointerStart() + 4]);
    return func(allocator);
}

void NxCookingInterface_doxybind::NxCloseCooking() 
{
    void (*func)() = (void (*)())(functionPointers[NxCookingInterface_doxybind::getPointerStart() + 5]);
     func();
}

bool NxCookingInterface_doxybind::NxCookTriangleMesh(const NxTriangleMeshDesc & desc, NxStream & stream) 
{
    bool (*func)(const NxTriangleMeshDesc & desc, NxStream & stream) = (bool (*)(const NxTriangleMeshDesc & desc, NxStream & stream))(functionPointers[NxCookingInterface_doxybind::getPointerStart() + 6]);
    return func(desc, stream);
}

bool NxCookingInterface_doxybind::NxCookConvexMesh(const NxConvexMeshDesc & desc, NxStream & stream) 
{
    bool (*func)(const NxConvexMeshDesc & desc, NxStream & stream) = (bool (*)(const NxConvexMeshDesc & desc, NxStream & stream))(functionPointers[NxCookingInterface_doxybind::getPointerStart() + 7]);
    return func(desc, stream);
}

bool NxCookingInterface_doxybind::NxCookClothMesh(const NxClothMeshDesc & desc, NxStream & stream) 
{
    bool (*func)(const NxClothMeshDesc & desc, NxStream & stream) = (bool (*)(const NxClothMeshDesc & desc, NxStream & stream))(functionPointers[NxCookingInterface_doxybind::getPointerStart() + 8]);
    return func(desc, stream);
}

bool NxCookingInterface_doxybind::NxCookSoftBodyMesh(const NxSoftBodyMeshDesc & desc, NxStream & stream) 
{
    bool (*func)(const NxSoftBodyMeshDesc & desc, NxStream & stream) = (bool (*)(const NxSoftBodyMeshDesc & desc, NxStream & stream))(functionPointers[NxCookingInterface_doxybind::getPointerStart() + 9]);
    return func(desc, stream);
}

bool NxCookingInterface_doxybind::NxCreatePMap(NxPMap & pmap, const NxTriangleMesh & mesh, NxU32 density, NxUserOutputStream * outputStream) 
{
    bool (*func)(NxPMap & pmap, const NxTriangleMesh & mesh, NxU32 density, NxUserOutputStream * outputStream) = (bool (*)(NxPMap & pmap, const NxTriangleMesh & mesh, NxU32 density, NxUserOutputStream * outputStream))(functionPointers[NxCookingInterface_doxybind::getPointerStart() + 10]);
    return func(pmap, mesh, density, outputStream);
}

bool NxCookingInterface_doxybind::NxCreatePMap(NxPMap & pmap, const NxTriangleMesh & mesh, NxU32 density) 
{
    bool (*func)(NxPMap & pmap, const NxTriangleMesh & mesh, NxU32 density) = (bool (*)(NxPMap & pmap, const NxTriangleMesh & mesh, NxU32 density))(functionPointers[NxCookingInterface_doxybind::getPointerStart() + 11]);
    return func(pmap, mesh, density);
}

bool NxCookingInterface_doxybind::NxReleasePMap(NxPMap & pmap) 
{
    bool (*func)(NxPMap & pmap) = (bool (*)(NxPMap & pmap))(functionPointers[NxCookingInterface_doxybind::getPointerStart() + 12]);
    return func(pmap);
}

bool NxCookingInterface_doxybind::NxScaleCookedConvexMesh(const NxStream & source, NxReal scale, NxStream & dest) 
{
    bool (*func)(const NxStream & source, NxReal scale, NxStream & dest) = (bool (*)(const NxStream & source, NxReal scale, NxStream & dest))(functionPointers[NxCookingInterface_doxybind::getPointerStart() + 13]);
    return func(source, scale, dest);
}

void NxCookingInterface_doxybind::NxReportCooking() 
{
    void (*func)() = (void (*)())(functionPointers[NxCookingInterface_doxybind::getPointerStart() + 14]);
     func();
}

void NxJoint_doxybind::setLimitPoint(const NxVec3 & point, bool pointIsOnActor2) 
{
    void (*func)(const NxVec3 & point, bool pointIsOnActor2) = (void (*)(const NxVec3 & point, bool pointIsOnActor2))(functionPointers[NxJoint_doxybind::getPointerStart() + 0]);
     func(point, pointIsOnActor2);
}

void NxJoint_doxybind::setLimitPoint(const NxVec3 & point) 
{
    void (*func)(const NxVec3 & point) = (void (*)(const NxVec3 & point))(functionPointers[NxJoint_doxybind::getPointerStart() + 1]);
     func(point);
}

bool NxJoint_doxybind::getLimitPoint(NxVec3 & worldLimitPoint) 
{
    bool (*func)(NxVec3 & worldLimitPoint) = (bool (*)(NxVec3 & worldLimitPoint))(functionPointers[NxJoint_doxybind::getPointerStart() + 2]);
    return func(worldLimitPoint);
}

bool NxJoint_doxybind::addLimitPlane(const NxVec3 & normal, const NxVec3 & pointInPlane, NxReal restitution) 
{
    bool (*func)(const NxVec3 & normal, const NxVec3 & pointInPlane, NxReal restitution) = (bool (*)(const NxVec3 & normal, const NxVec3 & pointInPlane, NxReal restitution))(functionPointers[NxJoint_doxybind::getPointerStart() + 3]);
    return func(normal, pointInPlane, restitution);
}

bool NxJoint_doxybind::addLimitPlane(const NxVec3 & normal, const NxVec3 & pointInPlane) 
{
    bool (*func)(const NxVec3 & normal, const NxVec3 & pointInPlane) = (bool (*)(const NxVec3 & normal, const NxVec3 & pointInPlane))(functionPointers[NxJoint_doxybind::getPointerStart() + 4]);
    return func(normal, pointInPlane);
}

void NxJoint_doxybind::purgeLimitPlanes() 
{
    void (*func)() = (void (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 5]);
     func();
}

void NxJoint_doxybind::resetLimitPlaneIterator() 
{
    void (*func)() = (void (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 6]);
     func();
}

bool NxJoint_doxybind::hasMoreLimitPlanes() 
{
    bool (*func)() = (bool (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 7]);
    return func();
}

bool NxJoint_doxybind::getNextLimitPlane(NxVec3 & planeNormal, NxReal & planeD, NxReal * restitution) 
{
    bool (*func)(NxVec3 & planeNormal, NxReal & planeD, NxReal * restitution) = (bool (*)(NxVec3 & planeNormal, NxReal & planeD, NxReal * restitution))(functionPointers[NxJoint_doxybind::getPointerStart() + 8]);
    return func(planeNormal, planeD, restitution);
}

bool NxJoint_doxybind::getNextLimitPlane(NxVec3 & planeNormal, NxReal & planeD) 
{
    bool (*func)(NxVec3 & planeNormal, NxReal & planeD) = (bool (*)(NxVec3 & planeNormal, NxReal & planeD))(functionPointers[NxJoint_doxybind::getPointerStart() + 9]);
    return func(planeNormal, planeD);
}

void * NxJoint_doxybind::is(NxJointType type) 
{
    void * (*func)(NxJointType type) = (void * (*)(NxJointType type))(functionPointers[NxJoint_doxybind::getPointerStart() + 10]);
    return func(type);
}

NxJoint_doxybind::NxJoint_doxybind() : NxJoint()
{
}

void NxJoint_doxybind::getActors(NxActor ** actor1, NxActor ** actor2) 
{
    void (*func)(NxActor ** actor1, NxActor ** actor2) = (void (*)(NxActor ** actor1, NxActor ** actor2))(functionPointers[NxJoint_doxybind::getPointerStart() + 11]);
     func(actor1, actor2);
}

void NxJoint_doxybind::setGlobalAnchor(const NxVec3 & vec) 
{
    void (*func)(const NxVec3 & vec) = (void (*)(const NxVec3 & vec))(functionPointers[NxJoint_doxybind::getPointerStart() + 12]);
     func(vec);
}

void NxJoint_doxybind::setGlobalAxis(const NxVec3 & vec) 
{
    void (*func)(const NxVec3 & vec) = (void (*)(const NxVec3 & vec))(functionPointers[NxJoint_doxybind::getPointerStart() + 13]);
     func(vec);
}

NxVec3 NxJoint_doxybind::getGlobalAnchor() const
{
    NxVec3 (*func)() = (NxVec3 (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 14]);
    return func();
}

NxVec3 NxJoint_doxybind::getGlobalAxis() const
{
    NxVec3 (*func)() = (NxVec3 (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 15]);
    return func();
}

NxJointState NxJoint_doxybind::getState() 
{
    NxJointState (*func)() = (NxJointState (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 16]);
    return func();
}

void NxJoint_doxybind::setBreakable(NxReal maxForce, NxReal maxTorque) 
{
    void (*func)(NxReal maxForce, NxReal maxTorque) = (void (*)(NxReal maxForce, NxReal maxTorque))(functionPointers[NxJoint_doxybind::getPointerStart() + 17]);
     func(maxForce, maxTorque);
}

void NxJoint_doxybind::getBreakable(NxReal & maxForce, NxReal & maxTorque) 
{
    void (*func)(NxReal & maxForce, NxReal & maxTorque) = (void (*)(NxReal & maxForce, NxReal & maxTorque))(functionPointers[NxJoint_doxybind::getPointerStart() + 18]);
     func(maxForce, maxTorque);
}

void NxJoint_doxybind::setSolverExtrapolationFactor(NxReal solverExtrapolationFactor) 
{
    void (*func)(NxReal solverExtrapolationFactor) = (void (*)(NxReal solverExtrapolationFactor))(functionPointers[NxJoint_doxybind::getPointerStart() + 19]);
     func(solverExtrapolationFactor);
}

NxReal NxJoint_doxybind::getSolverExtrapolationFactor() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 20]);
    return func();
}

void NxJoint_doxybind::setUseAccelerationSpring(bool b) 
{
    void (*func)(bool b) = (void (*)(bool b))(functionPointers[NxJoint_doxybind::getPointerStart() + 21]);
     func(b);
}

bool NxJoint_doxybind::getUseAccelerationSpring() const
{
    bool (*func)() = (bool (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 22]);
    return func();
}

NxJointType NxJoint_doxybind::getType() const
{
    NxJointType (*func)() = (NxJointType (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 23]);
    return func();
}

void NxJoint_doxybind::setName(const char * name) 
{
    void (*func)(const char * name) = (void (*)(const char * name))(functionPointers[NxJoint_doxybind::getPointerStart() + 24]);
     func(name);
}

const char * NxJoint_doxybind::getName() const
{
    const char * (*func)() = (const char * (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 25]);
    return func();
}

NxScene & NxJoint_doxybind::getScene() const
{
    NxScene & (*func)() = (NxScene & (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 26]);
    return func();
}

void NxCylindricalJoint_doxybind::loadFromDesc(const NxCylindricalJointDesc & desc) 
{
    void (*func)(const NxCylindricalJointDesc & desc) = (void (*)(const NxCylindricalJointDesc & desc))(functionPointers[NxCylindricalJoint_doxybind::getPointerStart() + 0]);
     func(desc);
}

void NxCylindricalJoint_doxybind::saveToDesc(NxCylindricalJointDesc & desc) 
{
    void (*func)(NxCylindricalJointDesc & desc) = (void (*)(NxCylindricalJointDesc & desc))(functionPointers[NxCylindricalJoint_doxybind::getPointerStart() + 1]);
     func(desc);
}

void NxCylindricalJoint_doxybind::setLimitPoint(const NxVec3 & point, bool pointIsOnActor2) 
{
    void (*func)(const NxVec3 & point, bool pointIsOnActor2) = (void (*)(const NxVec3 & point, bool pointIsOnActor2))(functionPointers[NxJoint_doxybind::getPointerStart() + 0]);
     func(point, pointIsOnActor2);
}

void NxCylindricalJoint_doxybind::setLimitPoint(const NxVec3 & point) 
{
    void (*func)(const NxVec3 & point) = (void (*)(const NxVec3 & point))(functionPointers[NxJoint_doxybind::getPointerStart() + 1]);
     func(point);
}

bool NxCylindricalJoint_doxybind::getLimitPoint(NxVec3 & worldLimitPoint) 
{
    bool (*func)(NxVec3 & worldLimitPoint) = (bool (*)(NxVec3 & worldLimitPoint))(functionPointers[NxJoint_doxybind::getPointerStart() + 2]);
    return func(worldLimitPoint);
}

bool NxCylindricalJoint_doxybind::addLimitPlane(const NxVec3 & normal, const NxVec3 & pointInPlane, NxReal restitution) 
{
    bool (*func)(const NxVec3 & normal, const NxVec3 & pointInPlane, NxReal restitution) = (bool (*)(const NxVec3 & normal, const NxVec3 & pointInPlane, NxReal restitution))(functionPointers[NxJoint_doxybind::getPointerStart() + 3]);
    return func(normal, pointInPlane, restitution);
}

bool NxCylindricalJoint_doxybind::addLimitPlane(const NxVec3 & normal, const NxVec3 & pointInPlane) 
{
    bool (*func)(const NxVec3 & normal, const NxVec3 & pointInPlane) = (bool (*)(const NxVec3 & normal, const NxVec3 & pointInPlane))(functionPointers[NxJoint_doxybind::getPointerStart() + 4]);
    return func(normal, pointInPlane);
}

void NxCylindricalJoint_doxybind::purgeLimitPlanes() 
{
    void (*func)() = (void (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 5]);
     func();
}

void NxCylindricalJoint_doxybind::resetLimitPlaneIterator() 
{
    void (*func)() = (void (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 6]);
     func();
}

bool NxCylindricalJoint_doxybind::hasMoreLimitPlanes() 
{
    bool (*func)() = (bool (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 7]);
    return func();
}

bool NxCylindricalJoint_doxybind::getNextLimitPlane(NxVec3 & planeNormal, NxReal & planeD, NxReal * restitution) 
{
    bool (*func)(NxVec3 & planeNormal, NxReal & planeD, NxReal * restitution) = (bool (*)(NxVec3 & planeNormal, NxReal & planeD, NxReal * restitution))(functionPointers[NxJoint_doxybind::getPointerStart() + 8]);
    return func(planeNormal, planeD, restitution);
}

bool NxCylindricalJoint_doxybind::getNextLimitPlane(NxVec3 & planeNormal, NxReal & planeD) 
{
    bool (*func)(NxVec3 & planeNormal, NxReal & planeD) = (bool (*)(NxVec3 & planeNormal, NxReal & planeD))(functionPointers[NxJoint_doxybind::getPointerStart() + 9]);
    return func(planeNormal, planeD);
}

void * NxCylindricalJoint_doxybind::is(NxJointType type) 
{
    void * (*func)(NxJointType type) = (void * (*)(NxJointType type))(functionPointers[NxJoint_doxybind::getPointerStart() + 10]);
    return func(type);
}

void NxCylindricalJoint_doxybind::getActors(NxActor ** actor1, NxActor ** actor2) 
{
    void (*func)(NxActor ** actor1, NxActor ** actor2) = (void (*)(NxActor ** actor1, NxActor ** actor2))(functionPointers[NxJoint_doxybind::getPointerStart() + 11]);
     func(actor1, actor2);
}

void NxCylindricalJoint_doxybind::setGlobalAnchor(const NxVec3 & vec) 
{
    void (*func)(const NxVec3 & vec) = (void (*)(const NxVec3 & vec))(functionPointers[NxJoint_doxybind::getPointerStart() + 12]);
     func(vec);
}

void NxCylindricalJoint_doxybind::setGlobalAxis(const NxVec3 & vec) 
{
    void (*func)(const NxVec3 & vec) = (void (*)(const NxVec3 & vec))(functionPointers[NxJoint_doxybind::getPointerStart() + 13]);
     func(vec);
}

NxVec3 NxCylindricalJoint_doxybind::getGlobalAnchor() const
{
    NxVec3 (*func)() = (NxVec3 (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 14]);
    return func();
}

NxVec3 NxCylindricalJoint_doxybind::getGlobalAxis() const
{
    NxVec3 (*func)() = (NxVec3 (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 15]);
    return func();
}

NxJointState NxCylindricalJoint_doxybind::getState() 
{
    NxJointState (*func)() = (NxJointState (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 16]);
    return func();
}

void NxCylindricalJoint_doxybind::setBreakable(NxReal maxForce, NxReal maxTorque) 
{
    void (*func)(NxReal maxForce, NxReal maxTorque) = (void (*)(NxReal maxForce, NxReal maxTorque))(functionPointers[NxJoint_doxybind::getPointerStart() + 17]);
     func(maxForce, maxTorque);
}

void NxCylindricalJoint_doxybind::getBreakable(NxReal & maxForce, NxReal & maxTorque) 
{
    void (*func)(NxReal & maxForce, NxReal & maxTorque) = (void (*)(NxReal & maxForce, NxReal & maxTorque))(functionPointers[NxJoint_doxybind::getPointerStart() + 18]);
     func(maxForce, maxTorque);
}

void NxCylindricalJoint_doxybind::setSolverExtrapolationFactor(NxReal solverExtrapolationFactor) 
{
    void (*func)(NxReal solverExtrapolationFactor) = (void (*)(NxReal solverExtrapolationFactor))(functionPointers[NxJoint_doxybind::getPointerStart() + 19]);
     func(solverExtrapolationFactor);
}

NxReal NxCylindricalJoint_doxybind::getSolverExtrapolationFactor() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 20]);
    return func();
}

void NxCylindricalJoint_doxybind::setUseAccelerationSpring(bool b) 
{
    void (*func)(bool b) = (void (*)(bool b))(functionPointers[NxJoint_doxybind::getPointerStart() + 21]);
     func(b);
}

bool NxCylindricalJoint_doxybind::getUseAccelerationSpring() const
{
    bool (*func)() = (bool (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 22]);
    return func();
}

NxJointType NxCylindricalJoint_doxybind::getType() const
{
    NxJointType (*func)() = (NxJointType (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 23]);
    return func();
}

void NxCylindricalJoint_doxybind::setName(const char * name) 
{
    void (*func)(const char * name) = (void (*)(const char * name))(functionPointers[NxJoint_doxybind::getPointerStart() + 24]);
     func(name);
}

const char * NxCylindricalJoint_doxybind::getName() const
{
    const char * (*func)() = (const char * (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 25]);
    return func();
}

NxScene & NxCylindricalJoint_doxybind::getScene() const
{
    NxScene & (*func)() = (NxScene & (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 26]);
    return func();
}

void NxJointDesc_doxybind::setToDefault() 
{
    void (*func)() = (void (*)())(functionPointers[NxJointDesc_doxybind::getPointerStart() + 0]);
     func();
}

bool NxJointDesc_doxybind::isValid() const
{
    bool (*func)() = (bool (*)())(functionPointers[NxJointDesc_doxybind::getPointerStart() + 1]);
    return func();
}

NxJointDesc_doxybind::NxJointDesc_doxybind(NxJointType t) : NxJointDesc(t)
{
}

NxCylindricalJointDesc_doxybind::NxCylindricalJointDesc_doxybind() : NxCylindricalJointDesc()
{
}

void NxCylindricalJointDesc_doxybind::setToDefault() 
{
    void (*func)() = (void (*)())(functionPointers[NxCylindricalJointDesc_doxybind::getPointerStart() + 0]);
     func();
}

bool NxCylindricalJointDesc_doxybind::isValid() const
{
    bool (*func)() = (bool (*)())(functionPointers[NxCylindricalJointDesc_doxybind::getPointerStart() + 1]);
    return func();
}

void NxD6Joint_doxybind::loadFromDesc(const NxD6JointDesc & desc) 
{
    void (*func)(const NxD6JointDesc & desc) = (void (*)(const NxD6JointDesc & desc))(functionPointers[NxD6Joint_doxybind::getPointerStart() + 0]);
     func(desc);
}

void NxD6Joint_doxybind::saveToDesc(NxD6JointDesc & desc) 
{
    void (*func)(NxD6JointDesc & desc) = (void (*)(NxD6JointDesc & desc))(functionPointers[NxD6Joint_doxybind::getPointerStart() + 1]);
     func(desc);
}

void NxD6Joint_doxybind::setDrivePosition(const NxVec3 & position) 
{
    void (*func)(const NxVec3 & position) = (void (*)(const NxVec3 & position))(functionPointers[NxD6Joint_doxybind::getPointerStart() + 2]);
     func(position);
}

void NxD6Joint_doxybind::setDriveOrientation(const NxQuat & orientation) 
{
    void (*func)(const NxQuat & orientation) = (void (*)(const NxQuat & orientation))(functionPointers[NxD6Joint_doxybind::getPointerStart() + 3]);
     func(orientation);
}

void NxD6Joint_doxybind::setDriveLinearVelocity(const NxVec3 & linVel) 
{
    void (*func)(const NxVec3 & linVel) = (void (*)(const NxVec3 & linVel))(functionPointers[NxD6Joint_doxybind::getPointerStart() + 4]);
     func(linVel);
}

void NxD6Joint_doxybind::setDriveAngularVelocity(const NxVec3 & angVel) 
{
    void (*func)(const NxVec3 & angVel) = (void (*)(const NxVec3 & angVel))(functionPointers[NxD6Joint_doxybind::getPointerStart() + 5]);
     func(angVel);
}

void NxD6Joint_doxybind::setLimitPoint(const NxVec3 & point, bool pointIsOnActor2) 
{
    void (*func)(const NxVec3 & point, bool pointIsOnActor2) = (void (*)(const NxVec3 & point, bool pointIsOnActor2))(functionPointers[NxJoint_doxybind::getPointerStart() + 0]);
     func(point, pointIsOnActor2);
}

void NxD6Joint_doxybind::setLimitPoint(const NxVec3 & point) 
{
    void (*func)(const NxVec3 & point) = (void (*)(const NxVec3 & point))(functionPointers[NxJoint_doxybind::getPointerStart() + 1]);
     func(point);
}

bool NxD6Joint_doxybind::getLimitPoint(NxVec3 & worldLimitPoint) 
{
    bool (*func)(NxVec3 & worldLimitPoint) = (bool (*)(NxVec3 & worldLimitPoint))(functionPointers[NxJoint_doxybind::getPointerStart() + 2]);
    return func(worldLimitPoint);
}

bool NxD6Joint_doxybind::addLimitPlane(const NxVec3 & normal, const NxVec3 & pointInPlane, NxReal restitution) 
{
    bool (*func)(const NxVec3 & normal, const NxVec3 & pointInPlane, NxReal restitution) = (bool (*)(const NxVec3 & normal, const NxVec3 & pointInPlane, NxReal restitution))(functionPointers[NxJoint_doxybind::getPointerStart() + 3]);
    return func(normal, pointInPlane, restitution);
}

bool NxD6Joint_doxybind::addLimitPlane(const NxVec3 & normal, const NxVec3 & pointInPlane) 
{
    bool (*func)(const NxVec3 & normal, const NxVec3 & pointInPlane) = (bool (*)(const NxVec3 & normal, const NxVec3 & pointInPlane))(functionPointers[NxJoint_doxybind::getPointerStart() + 4]);
    return func(normal, pointInPlane);
}

void NxD6Joint_doxybind::purgeLimitPlanes() 
{
    void (*func)() = (void (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 5]);
     func();
}

void NxD6Joint_doxybind::resetLimitPlaneIterator() 
{
    void (*func)() = (void (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 6]);
     func();
}

bool NxD6Joint_doxybind::hasMoreLimitPlanes() 
{
    bool (*func)() = (bool (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 7]);
    return func();
}

bool NxD6Joint_doxybind::getNextLimitPlane(NxVec3 & planeNormal, NxReal & planeD, NxReal * restitution) 
{
    bool (*func)(NxVec3 & planeNormal, NxReal & planeD, NxReal * restitution) = (bool (*)(NxVec3 & planeNormal, NxReal & planeD, NxReal * restitution))(functionPointers[NxJoint_doxybind::getPointerStart() + 8]);
    return func(planeNormal, planeD, restitution);
}

bool NxD6Joint_doxybind::getNextLimitPlane(NxVec3 & planeNormal, NxReal & planeD) 
{
    bool (*func)(NxVec3 & planeNormal, NxReal & planeD) = (bool (*)(NxVec3 & planeNormal, NxReal & planeD))(functionPointers[NxJoint_doxybind::getPointerStart() + 9]);
    return func(planeNormal, planeD);
}

void * NxD6Joint_doxybind::is(NxJointType type) 
{
    void * (*func)(NxJointType type) = (void * (*)(NxJointType type))(functionPointers[NxJoint_doxybind::getPointerStart() + 10]);
    return func(type);
}

void NxD6Joint_doxybind::getActors(NxActor ** actor1, NxActor ** actor2) 
{
    void (*func)(NxActor ** actor1, NxActor ** actor2) = (void (*)(NxActor ** actor1, NxActor ** actor2))(functionPointers[NxJoint_doxybind::getPointerStart() + 11]);
     func(actor1, actor2);
}

void NxD6Joint_doxybind::setGlobalAnchor(const NxVec3 & vec) 
{
    void (*func)(const NxVec3 & vec) = (void (*)(const NxVec3 & vec))(functionPointers[NxJoint_doxybind::getPointerStart() + 12]);
     func(vec);
}

void NxD6Joint_doxybind::setGlobalAxis(const NxVec3 & vec) 
{
    void (*func)(const NxVec3 & vec) = (void (*)(const NxVec3 & vec))(functionPointers[NxJoint_doxybind::getPointerStart() + 13]);
     func(vec);
}

NxVec3 NxD6Joint_doxybind::getGlobalAnchor() const
{
    NxVec3 (*func)() = (NxVec3 (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 14]);
    return func();
}

NxVec3 NxD6Joint_doxybind::getGlobalAxis() const
{
    NxVec3 (*func)() = (NxVec3 (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 15]);
    return func();
}

NxJointState NxD6Joint_doxybind::getState() 
{
    NxJointState (*func)() = (NxJointState (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 16]);
    return func();
}

void NxD6Joint_doxybind::setBreakable(NxReal maxForce, NxReal maxTorque) 
{
    void (*func)(NxReal maxForce, NxReal maxTorque) = (void (*)(NxReal maxForce, NxReal maxTorque))(functionPointers[NxJoint_doxybind::getPointerStart() + 17]);
     func(maxForce, maxTorque);
}

void NxD6Joint_doxybind::getBreakable(NxReal & maxForce, NxReal & maxTorque) 
{
    void (*func)(NxReal & maxForce, NxReal & maxTorque) = (void (*)(NxReal & maxForce, NxReal & maxTorque))(functionPointers[NxJoint_doxybind::getPointerStart() + 18]);
     func(maxForce, maxTorque);
}

void NxD6Joint_doxybind::setSolverExtrapolationFactor(NxReal solverExtrapolationFactor) 
{
    void (*func)(NxReal solverExtrapolationFactor) = (void (*)(NxReal solverExtrapolationFactor))(functionPointers[NxJoint_doxybind::getPointerStart() + 19]);
     func(solverExtrapolationFactor);
}

NxReal NxD6Joint_doxybind::getSolverExtrapolationFactor() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 20]);
    return func();
}

void NxD6Joint_doxybind::setUseAccelerationSpring(bool b) 
{
    void (*func)(bool b) = (void (*)(bool b))(functionPointers[NxJoint_doxybind::getPointerStart() + 21]);
     func(b);
}

bool NxD6Joint_doxybind::getUseAccelerationSpring() const
{
    bool (*func)() = (bool (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 22]);
    return func();
}

NxJointType NxD6Joint_doxybind::getType() const
{
    NxJointType (*func)() = (NxJointType (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 23]);
    return func();
}

void NxD6Joint_doxybind::setName(const char * name) 
{
    void (*func)(const char * name) = (void (*)(const char * name))(functionPointers[NxJoint_doxybind::getPointerStart() + 24]);
     func(name);
}

const char * NxD6Joint_doxybind::getName() const
{
    const char * (*func)() = (const char * (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 25]);
    return func();
}

NxScene & NxD6Joint_doxybind::getScene() const
{
    NxScene & (*func)() = (NxScene & (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 26]);
    return func();
}

NxD6JointDesc_doxybind::NxD6JointDesc_doxybind() : NxD6JointDesc()
{
}

void NxD6JointDesc_doxybind::setToDefault() 
{
    void (*func)() = (void (*)())(functionPointers[NxD6JointDesc_doxybind::getPointerStart() + 0]);
     func();
}

bool NxD6JointDesc_doxybind::isValid() const
{
    bool (*func)() = (bool (*)())(functionPointers[NxD6JointDesc_doxybind::getPointerStart() + 1]);
    return func();
}

void NxDistanceJoint_doxybind::loadFromDesc(const NxDistanceJointDesc & desc) 
{
    void (*func)(const NxDistanceJointDesc & desc) = (void (*)(const NxDistanceJointDesc & desc))(functionPointers[NxDistanceJoint_doxybind::getPointerStart() + 0]);
     func(desc);
}

void NxDistanceJoint_doxybind::saveToDesc(NxDistanceJointDesc & desc) 
{
    void (*func)(NxDistanceJointDesc & desc) = (void (*)(NxDistanceJointDesc & desc))(functionPointers[NxDistanceJoint_doxybind::getPointerStart() + 1]);
     func(desc);
}

void NxDistanceJoint_doxybind::setLimitPoint(const NxVec3 & point, bool pointIsOnActor2) 
{
    void (*func)(const NxVec3 & point, bool pointIsOnActor2) = (void (*)(const NxVec3 & point, bool pointIsOnActor2))(functionPointers[NxJoint_doxybind::getPointerStart() + 0]);
     func(point, pointIsOnActor2);
}

void NxDistanceJoint_doxybind::setLimitPoint(const NxVec3 & point) 
{
    void (*func)(const NxVec3 & point) = (void (*)(const NxVec3 & point))(functionPointers[NxJoint_doxybind::getPointerStart() + 1]);
     func(point);
}

bool NxDistanceJoint_doxybind::getLimitPoint(NxVec3 & worldLimitPoint) 
{
    bool (*func)(NxVec3 & worldLimitPoint) = (bool (*)(NxVec3 & worldLimitPoint))(functionPointers[NxJoint_doxybind::getPointerStart() + 2]);
    return func(worldLimitPoint);
}

bool NxDistanceJoint_doxybind::addLimitPlane(const NxVec3 & normal, const NxVec3 & pointInPlane, NxReal restitution) 
{
    bool (*func)(const NxVec3 & normal, const NxVec3 & pointInPlane, NxReal restitution) = (bool (*)(const NxVec3 & normal, const NxVec3 & pointInPlane, NxReal restitution))(functionPointers[NxJoint_doxybind::getPointerStart() + 3]);
    return func(normal, pointInPlane, restitution);
}

bool NxDistanceJoint_doxybind::addLimitPlane(const NxVec3 & normal, const NxVec3 & pointInPlane) 
{
    bool (*func)(const NxVec3 & normal, const NxVec3 & pointInPlane) = (bool (*)(const NxVec3 & normal, const NxVec3 & pointInPlane))(functionPointers[NxJoint_doxybind::getPointerStart() + 4]);
    return func(normal, pointInPlane);
}

void NxDistanceJoint_doxybind::purgeLimitPlanes() 
{
    void (*func)() = (void (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 5]);
     func();
}

void NxDistanceJoint_doxybind::resetLimitPlaneIterator() 
{
    void (*func)() = (void (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 6]);
     func();
}

bool NxDistanceJoint_doxybind::hasMoreLimitPlanes() 
{
    bool (*func)() = (bool (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 7]);
    return func();
}

bool NxDistanceJoint_doxybind::getNextLimitPlane(NxVec3 & planeNormal, NxReal & planeD, NxReal * restitution) 
{
    bool (*func)(NxVec3 & planeNormal, NxReal & planeD, NxReal * restitution) = (bool (*)(NxVec3 & planeNormal, NxReal & planeD, NxReal * restitution))(functionPointers[NxJoint_doxybind::getPointerStart() + 8]);
    return func(planeNormal, planeD, restitution);
}

bool NxDistanceJoint_doxybind::getNextLimitPlane(NxVec3 & planeNormal, NxReal & planeD) 
{
    bool (*func)(NxVec3 & planeNormal, NxReal & planeD) = (bool (*)(NxVec3 & planeNormal, NxReal & planeD))(functionPointers[NxJoint_doxybind::getPointerStart() + 9]);
    return func(planeNormal, planeD);
}

void * NxDistanceJoint_doxybind::is(NxJointType type) 
{
    void * (*func)(NxJointType type) = (void * (*)(NxJointType type))(functionPointers[NxJoint_doxybind::getPointerStart() + 10]);
    return func(type);
}

void NxDistanceJoint_doxybind::getActors(NxActor ** actor1, NxActor ** actor2) 
{
    void (*func)(NxActor ** actor1, NxActor ** actor2) = (void (*)(NxActor ** actor1, NxActor ** actor2))(functionPointers[NxJoint_doxybind::getPointerStart() + 11]);
     func(actor1, actor2);
}

void NxDistanceJoint_doxybind::setGlobalAnchor(const NxVec3 & vec) 
{
    void (*func)(const NxVec3 & vec) = (void (*)(const NxVec3 & vec))(functionPointers[NxJoint_doxybind::getPointerStart() + 12]);
     func(vec);
}

void NxDistanceJoint_doxybind::setGlobalAxis(const NxVec3 & vec) 
{
    void (*func)(const NxVec3 & vec) = (void (*)(const NxVec3 & vec))(functionPointers[NxJoint_doxybind::getPointerStart() + 13]);
     func(vec);
}

NxVec3 NxDistanceJoint_doxybind::getGlobalAnchor() const
{
    NxVec3 (*func)() = (NxVec3 (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 14]);
    return func();
}

NxVec3 NxDistanceJoint_doxybind::getGlobalAxis() const
{
    NxVec3 (*func)() = (NxVec3 (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 15]);
    return func();
}

NxJointState NxDistanceJoint_doxybind::getState() 
{
    NxJointState (*func)() = (NxJointState (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 16]);
    return func();
}

void NxDistanceJoint_doxybind::setBreakable(NxReal maxForce, NxReal maxTorque) 
{
    void (*func)(NxReal maxForce, NxReal maxTorque) = (void (*)(NxReal maxForce, NxReal maxTorque))(functionPointers[NxJoint_doxybind::getPointerStart() + 17]);
     func(maxForce, maxTorque);
}

void NxDistanceJoint_doxybind::getBreakable(NxReal & maxForce, NxReal & maxTorque) 
{
    void (*func)(NxReal & maxForce, NxReal & maxTorque) = (void (*)(NxReal & maxForce, NxReal & maxTorque))(functionPointers[NxJoint_doxybind::getPointerStart() + 18]);
     func(maxForce, maxTorque);
}

void NxDistanceJoint_doxybind::setSolverExtrapolationFactor(NxReal solverExtrapolationFactor) 
{
    void (*func)(NxReal solverExtrapolationFactor) = (void (*)(NxReal solverExtrapolationFactor))(functionPointers[NxJoint_doxybind::getPointerStart() + 19]);
     func(solverExtrapolationFactor);
}

NxReal NxDistanceJoint_doxybind::getSolverExtrapolationFactor() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 20]);
    return func();
}

void NxDistanceJoint_doxybind::setUseAccelerationSpring(bool b) 
{
    void (*func)(bool b) = (void (*)(bool b))(functionPointers[NxJoint_doxybind::getPointerStart() + 21]);
     func(b);
}

bool NxDistanceJoint_doxybind::getUseAccelerationSpring() const
{
    bool (*func)() = (bool (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 22]);
    return func();
}

NxJointType NxDistanceJoint_doxybind::getType() const
{
    NxJointType (*func)() = (NxJointType (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 23]);
    return func();
}

void NxDistanceJoint_doxybind::setName(const char * name) 
{
    void (*func)(const char * name) = (void (*)(const char * name))(functionPointers[NxJoint_doxybind::getPointerStart() + 24]);
     func(name);
}

const char * NxDistanceJoint_doxybind::getName() const
{
    const char * (*func)() = (const char * (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 25]);
    return func();
}

NxScene & NxDistanceJoint_doxybind::getScene() const
{
    NxScene & (*func)() = (NxScene & (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 26]);
    return func();
}

NxDistanceJointDesc_doxybind::NxDistanceJointDesc_doxybind() : NxDistanceJointDesc()
{
}

bool NxDistanceJointDesc_doxybind::isValid() const
{
    bool (*func)() = (bool (*)())(functionPointers[NxDistanceJointDesc_doxybind::getPointerStart() + 0]);
    return func();
}

void NxDistanceJointDesc_doxybind::setToDefault() 
{
    void (*func)() = (void (*)())(functionPointers[NxJointDesc_doxybind::getPointerStart() + 0]);
     func();
}

NxEffectorType NxEffector_doxybind::getType() const
{
    NxEffectorType (*func)() = (NxEffectorType (*)())(functionPointers[NxEffector_doxybind::getPointerStart() + 0]);
    return func();
}

void NxEffector_doxybind::setName(const char * name) 
{
    void (*func)(const char * name) = (void (*)(const char * name))(functionPointers[NxEffector_doxybind::getPointerStart() + 1]);
     func(name);
}

const char * NxEffector_doxybind::getName() const
{
    const char * (*func)() = (const char * (*)())(functionPointers[NxEffector_doxybind::getPointerStart() + 2]);
    return func();
}

NxScene & NxEffector_doxybind::getScene() const
{
    NxScene & (*func)() = (NxScene & (*)())(functionPointers[NxEffector_doxybind::getPointerStart() + 3]);
    return func();
}

NxEffector_doxybind::NxEffector_doxybind() : NxEffector()
{
}

void NxEffectorDesc_doxybind::setToDefault() 
{
    void (*func)() = (void (*)())(functionPointers[NxEffectorDesc_doxybind::getPointerStart() + 0]);
     func();
}

bool NxEffectorDesc_doxybind::isValid() const
{
    bool (*func)() = (bool (*)())(functionPointers[NxEffectorDesc_doxybind::getPointerStart() + 1]);
    return func();
}

NxEffectorDesc_doxybind::NxEffectorDesc_doxybind(NxEffectorType type) : NxEffectorDesc(type)
{
}

NxErrorCode NxException_doxybind::getErrorCode() 
{
    NxErrorCode (*func)() = (NxErrorCode (*)())(functionPointers[NxException_doxybind::getPointerStart() + 0]);
    return func();
}

const char * NxException_doxybind::getFile() 
{
    const char * (*func)() = (const char * (*)())(functionPointers[NxException_doxybind::getPointerStart() + 1]);
    return func();
}

int NxException_doxybind::getLine() 
{
    int (*func)() = (int (*)())(functionPointers[NxException_doxybind::getPointerStart() + 2]);
    return func();
}

void NxFixedJoint_doxybind::loadFromDesc(const NxFixedJointDesc & desc) 
{
    void (*func)(const NxFixedJointDesc & desc) = (void (*)(const NxFixedJointDesc & desc))(functionPointers[NxFixedJoint_doxybind::getPointerStart() + 0]);
     func(desc);
}

void NxFixedJoint_doxybind::saveToDesc(NxFixedJointDesc & desc) 
{
    void (*func)(NxFixedJointDesc & desc) = (void (*)(NxFixedJointDesc & desc))(functionPointers[NxFixedJoint_doxybind::getPointerStart() + 1]);
     func(desc);
}

void NxFixedJoint_doxybind::setLimitPoint(const NxVec3 & point, bool pointIsOnActor2) 
{
    void (*func)(const NxVec3 & point, bool pointIsOnActor2) = (void (*)(const NxVec3 & point, bool pointIsOnActor2))(functionPointers[NxJoint_doxybind::getPointerStart() + 0]);
     func(point, pointIsOnActor2);
}

void NxFixedJoint_doxybind::setLimitPoint(const NxVec3 & point) 
{
    void (*func)(const NxVec3 & point) = (void (*)(const NxVec3 & point))(functionPointers[NxJoint_doxybind::getPointerStart() + 1]);
     func(point);
}

bool NxFixedJoint_doxybind::getLimitPoint(NxVec3 & worldLimitPoint) 
{
    bool (*func)(NxVec3 & worldLimitPoint) = (bool (*)(NxVec3 & worldLimitPoint))(functionPointers[NxJoint_doxybind::getPointerStart() + 2]);
    return func(worldLimitPoint);
}

bool NxFixedJoint_doxybind::addLimitPlane(const NxVec3 & normal, const NxVec3 & pointInPlane, NxReal restitution) 
{
    bool (*func)(const NxVec3 & normal, const NxVec3 & pointInPlane, NxReal restitution) = (bool (*)(const NxVec3 & normal, const NxVec3 & pointInPlane, NxReal restitution))(functionPointers[NxJoint_doxybind::getPointerStart() + 3]);
    return func(normal, pointInPlane, restitution);
}

bool NxFixedJoint_doxybind::addLimitPlane(const NxVec3 & normal, const NxVec3 & pointInPlane) 
{
    bool (*func)(const NxVec3 & normal, const NxVec3 & pointInPlane) = (bool (*)(const NxVec3 & normal, const NxVec3 & pointInPlane))(functionPointers[NxJoint_doxybind::getPointerStart() + 4]);
    return func(normal, pointInPlane);
}

void NxFixedJoint_doxybind::purgeLimitPlanes() 
{
    void (*func)() = (void (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 5]);
     func();
}

void NxFixedJoint_doxybind::resetLimitPlaneIterator() 
{
    void (*func)() = (void (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 6]);
     func();
}

bool NxFixedJoint_doxybind::hasMoreLimitPlanes() 
{
    bool (*func)() = (bool (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 7]);
    return func();
}

bool NxFixedJoint_doxybind::getNextLimitPlane(NxVec3 & planeNormal, NxReal & planeD, NxReal * restitution) 
{
    bool (*func)(NxVec3 & planeNormal, NxReal & planeD, NxReal * restitution) = (bool (*)(NxVec3 & planeNormal, NxReal & planeD, NxReal * restitution))(functionPointers[NxJoint_doxybind::getPointerStart() + 8]);
    return func(planeNormal, planeD, restitution);
}

bool NxFixedJoint_doxybind::getNextLimitPlane(NxVec3 & planeNormal, NxReal & planeD) 
{
    bool (*func)(NxVec3 & planeNormal, NxReal & planeD) = (bool (*)(NxVec3 & planeNormal, NxReal & planeD))(functionPointers[NxJoint_doxybind::getPointerStart() + 9]);
    return func(planeNormal, planeD);
}

void * NxFixedJoint_doxybind::is(NxJointType type) 
{
    void * (*func)(NxJointType type) = (void * (*)(NxJointType type))(functionPointers[NxJoint_doxybind::getPointerStart() + 10]);
    return func(type);
}

void NxFixedJoint_doxybind::getActors(NxActor ** actor1, NxActor ** actor2) 
{
    void (*func)(NxActor ** actor1, NxActor ** actor2) = (void (*)(NxActor ** actor1, NxActor ** actor2))(functionPointers[NxJoint_doxybind::getPointerStart() + 11]);
     func(actor1, actor2);
}

void NxFixedJoint_doxybind::setGlobalAnchor(const NxVec3 & vec) 
{
    void (*func)(const NxVec3 & vec) = (void (*)(const NxVec3 & vec))(functionPointers[NxJoint_doxybind::getPointerStart() + 12]);
     func(vec);
}

void NxFixedJoint_doxybind::setGlobalAxis(const NxVec3 & vec) 
{
    void (*func)(const NxVec3 & vec) = (void (*)(const NxVec3 & vec))(functionPointers[NxJoint_doxybind::getPointerStart() + 13]);
     func(vec);
}

NxVec3 NxFixedJoint_doxybind::getGlobalAnchor() const
{
    NxVec3 (*func)() = (NxVec3 (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 14]);
    return func();
}

NxVec3 NxFixedJoint_doxybind::getGlobalAxis() const
{
    NxVec3 (*func)() = (NxVec3 (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 15]);
    return func();
}

NxJointState NxFixedJoint_doxybind::getState() 
{
    NxJointState (*func)() = (NxJointState (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 16]);
    return func();
}

void NxFixedJoint_doxybind::setBreakable(NxReal maxForce, NxReal maxTorque) 
{
    void (*func)(NxReal maxForce, NxReal maxTorque) = (void (*)(NxReal maxForce, NxReal maxTorque))(functionPointers[NxJoint_doxybind::getPointerStart() + 17]);
     func(maxForce, maxTorque);
}

void NxFixedJoint_doxybind::getBreakable(NxReal & maxForce, NxReal & maxTorque) 
{
    void (*func)(NxReal & maxForce, NxReal & maxTorque) = (void (*)(NxReal & maxForce, NxReal & maxTorque))(functionPointers[NxJoint_doxybind::getPointerStart() + 18]);
     func(maxForce, maxTorque);
}

void NxFixedJoint_doxybind::setSolverExtrapolationFactor(NxReal solverExtrapolationFactor) 
{
    void (*func)(NxReal solverExtrapolationFactor) = (void (*)(NxReal solverExtrapolationFactor))(functionPointers[NxJoint_doxybind::getPointerStart() + 19]);
     func(solverExtrapolationFactor);
}

NxReal NxFixedJoint_doxybind::getSolverExtrapolationFactor() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 20]);
    return func();
}

void NxFixedJoint_doxybind::setUseAccelerationSpring(bool b) 
{
    void (*func)(bool b) = (void (*)(bool b))(functionPointers[NxJoint_doxybind::getPointerStart() + 21]);
     func(b);
}

bool NxFixedJoint_doxybind::getUseAccelerationSpring() const
{
    bool (*func)() = (bool (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 22]);
    return func();
}

NxJointType NxFixedJoint_doxybind::getType() const
{
    NxJointType (*func)() = (NxJointType (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 23]);
    return func();
}

void NxFixedJoint_doxybind::setName(const char * name) 
{
    void (*func)(const char * name) = (void (*)(const char * name))(functionPointers[NxJoint_doxybind::getPointerStart() + 24]);
     func(name);
}

const char * NxFixedJoint_doxybind::getName() const
{
    const char * (*func)() = (const char * (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 25]);
    return func();
}

NxScene & NxFixedJoint_doxybind::getScene() const
{
    NxScene & (*func)() = (NxScene & (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 26]);
    return func();
}

NxFixedJointDesc_doxybind::NxFixedJointDesc_doxybind() : NxFixedJointDesc()
{
}

void NxFixedJointDesc_doxybind::setToDefault() 
{
    void (*func)() = (void (*)())(functionPointers[NxFixedJointDesc_doxybind::getPointerStart() + 0]);
     func();
}

bool NxFixedJointDesc_doxybind::isValid() const
{
    bool (*func)() = (bool (*)())(functionPointers[NxFixedJointDesc_doxybind::getPointerStart() + 1]);
    return func();
}

bool NxFluidEmitter_doxybind::loadFromDesc(const NxFluidEmitterDesc & desc) 
{
    bool (*func)(const NxFluidEmitterDesc & desc) = (bool (*)(const NxFluidEmitterDesc & desc))(functionPointers[NxFluidEmitter_doxybind::getPointerStart() + 0]);
    return func(desc);
}

bool NxFluidEmitter_doxybind::saveToDesc(NxFluidEmitterDesc & desc) const
{
    bool (*func)(NxFluidEmitterDesc & desc) = (bool (*)(NxFluidEmitterDesc & desc))(functionPointers[NxFluidEmitter_doxybind::getPointerStart() + 1]);
    return func(desc);
}

NxFluidEmitter_doxybind::NxFluidEmitter_doxybind() : NxFluidEmitter()
{
}

NxFluid & NxFluidEmitter_doxybind::getFluid() const
{
    NxFluid & (*func)() = (NxFluid & (*)())(functionPointers[NxFluidEmitter_doxybind::getPointerStart() + 2]);
    return func();
}

void NxFluidEmitter_doxybind::setGlobalPose(const NxMat34 & mat) 
{
    void (*func)(const NxMat34 & mat) = (void (*)(const NxMat34 & mat))(functionPointers[NxFluidEmitter_doxybind::getPointerStart() + 3]);
     func(mat);
}

void NxFluidEmitter_doxybind::setGlobalPosition(const NxVec3 & vec) 
{
    void (*func)(const NxVec3 & vec) = (void (*)(const NxVec3 & vec))(functionPointers[NxFluidEmitter_doxybind::getPointerStart() + 4]);
     func(vec);
}

void NxFluidEmitter_doxybind::setGlobalOrientation(const NxMat33 & mat) 
{
    void (*func)(const NxMat33 & mat) = (void (*)(const NxMat33 & mat))(functionPointers[NxFluidEmitter_doxybind::getPointerStart() + 5]);
     func(mat);
}

void NxFluidEmitter_doxybind::setLocalPose(const NxMat34 & mat) 
{
    void (*func)(const NxMat34 & mat) = (void (*)(const NxMat34 & mat))(functionPointers[NxFluidEmitter_doxybind::getPointerStart() + 6]);
     func(mat);
}

void NxFluidEmitter_doxybind::setLocalPosition(const NxVec3 & vec) 
{
    void (*func)(const NxVec3 & vec) = (void (*)(const NxVec3 & vec))(functionPointers[NxFluidEmitter_doxybind::getPointerStart() + 7]);
     func(vec);
}

void NxFluidEmitter_doxybind::setLocalOrientation(const NxMat33 & mat) 
{
    void (*func)(const NxMat33 & mat) = (void (*)(const NxMat33 & mat))(functionPointers[NxFluidEmitter_doxybind::getPointerStart() + 8]);
     func(mat);
}

void NxFluidEmitter_doxybind::setFrameShape(NxShape * shape) 
{
    void (*func)(NxShape * shape) = (void (*)(NxShape * shape))(functionPointers[NxFluidEmitter_doxybind::getPointerStart() + 9]);
     func(shape);
}

NxShape * NxFluidEmitter_doxybind::getFrameShape() const
{
    NxShape * (*func)() = (NxShape * (*)())(functionPointers[NxFluidEmitter_doxybind::getPointerStart() + 10]);
    return func();
}

NxReal NxFluidEmitter_doxybind::getDimensionX() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxFluidEmitter_doxybind::getPointerStart() + 11]);
    return func();
}

NxReal NxFluidEmitter_doxybind::getDimensionY() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxFluidEmitter_doxybind::getPointerStart() + 12]);
    return func();
}

void NxFluidEmitter_doxybind::setRandomPos(NxVec3 disp) 
{
    void (*func)(NxVec3 disp) = (void (*)(NxVec3 disp))(functionPointers[NxFluidEmitter_doxybind::getPointerStart() + 13]);
     func(disp);
}

NxVec3 NxFluidEmitter_doxybind::getRandomPos() const
{
    NxVec3 (*func)() = (NxVec3 (*)())(functionPointers[NxFluidEmitter_doxybind::getPointerStart() + 14]);
    return func();
}

void NxFluidEmitter_doxybind::setRandomAngle(NxReal angle) 
{
    void (*func)(NxReal angle) = (void (*)(NxReal angle))(functionPointers[NxFluidEmitter_doxybind::getPointerStart() + 15]);
     func(angle);
}

NxReal NxFluidEmitter_doxybind::getRandomAngle() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxFluidEmitter_doxybind::getPointerStart() + 16]);
    return func();
}

void NxFluidEmitter_doxybind::setFluidVelocityMagnitude(NxReal vel) 
{
    void (*func)(NxReal vel) = (void (*)(NxReal vel))(functionPointers[NxFluidEmitter_doxybind::getPointerStart() + 17]);
     func(vel);
}

NxReal NxFluidEmitter_doxybind::getFluidVelocityMagnitude() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxFluidEmitter_doxybind::getPointerStart() + 18]);
    return func();
}

void NxFluidEmitter_doxybind::setRate(NxReal rate) 
{
    void (*func)(NxReal rate) = (void (*)(NxReal rate))(functionPointers[NxFluidEmitter_doxybind::getPointerStart() + 19]);
     func(rate);
}

NxReal NxFluidEmitter_doxybind::getRate() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxFluidEmitter_doxybind::getPointerStart() + 20]);
    return func();
}

void NxFluidEmitter_doxybind::setParticleLifetime(NxReal life) 
{
    void (*func)(NxReal life) = (void (*)(NxReal life))(functionPointers[NxFluidEmitter_doxybind::getPointerStart() + 21]);
     func(life);
}

NxReal NxFluidEmitter_doxybind::getParticleLifetime() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxFluidEmitter_doxybind::getPointerStart() + 22]);
    return func();
}

void NxFluidEmitter_doxybind::setRepulsionCoefficient(NxReal coefficient) 
{
    void (*func)(NxReal coefficient) = (void (*)(NxReal coefficient))(functionPointers[NxFluidEmitter_doxybind::getPointerStart() + 23]);
     func(coefficient);
}

NxReal NxFluidEmitter_doxybind::getRepulsionCoefficient() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxFluidEmitter_doxybind::getPointerStart() + 24]);
    return func();
}

void NxFluidEmitter_doxybind::resetEmission(NxU32 maxParticles) 
{
    void (*func)(NxU32 maxParticles) = (void (*)(NxU32 maxParticles))(functionPointers[NxFluidEmitter_doxybind::getPointerStart() + 25]);
     func(maxParticles);
}

NxU32 NxFluidEmitter_doxybind::getMaxParticles() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxFluidEmitter_doxybind::getPointerStart() + 26]);
    return func();
}

NxU32 NxFluidEmitter_doxybind::getNbParticlesEmitted() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxFluidEmitter_doxybind::getPointerStart() + 27]);
    return func();
}

void NxFluidEmitter_doxybind::setFlag(NxFluidEmitterFlag flag, bool val) 
{
    void (*func)(NxFluidEmitterFlag flag, bool val) = (void (*)(NxFluidEmitterFlag flag, bool val))(functionPointers[NxFluidEmitter_doxybind::getPointerStart() + 28]);
     func(flag, val);
}

NX_BOOL NxFluidEmitter_doxybind::getFlag(NxFluidEmitterFlag flag) const
{
    NX_BOOL (*func)(NxFluidEmitterFlag flag) = (NX_BOOL (*)(NxFluidEmitterFlag flag))(functionPointers[NxFluidEmitter_doxybind::getPointerStart() + 29]);
    return func(flag);
}

NX_BOOL NxFluidEmitter_doxybind::getShape(NxEmitterShape shape) const
{
    NX_BOOL (*func)(NxEmitterShape shape) = (NX_BOOL (*)(NxEmitterShape shape))(functionPointers[NxFluidEmitter_doxybind::getPointerStart() + 30]);
    return func(shape);
}

NX_BOOL NxFluidEmitter_doxybind::getType(NxEmitterType type) const
{
    NX_BOOL (*func)(NxEmitterType type) = (NX_BOOL (*)(NxEmitterType type))(functionPointers[NxFluidEmitter_doxybind::getPointerStart() + 31]);
    return func(type);
}

void NxFluidEmitter_doxybind::setName(const char * name) 
{
    void (*func)(const char * name) = (void (*)(const char * name))(functionPointers[NxFluidEmitter_doxybind::getPointerStart() + 32]);
     func(name);
}

const char * NxFluidEmitter_doxybind::getName() const
{
    const char * (*func)() = (const char * (*)())(functionPointers[NxFluidEmitter_doxybind::getPointerStart() + 33]);
    return func();
}

bool NxFluidUserNotify_doxybind::onEmitterEvent(NxFluidEmitter & emitter, NxFluidEmitterEventType eventType) 
{
    bool (*func)(NxFluidEmitter & emitter, NxFluidEmitterEventType eventType) = (bool (*)(NxFluidEmitter & emitter, NxFluidEmitterEventType eventType))(functionPointers[NxFluidUserNotify_doxybind::getPointerStart() + 0]);
    return func(emitter, eventType);
}

bool NxFluidUserNotify_doxybind::onEvent(NxFluid & fluid, NxFluidEventType eventType) 
{
    bool (*func)(NxFluid & fluid, NxFluidEventType eventType) = (bool (*)(NxFluid & fluid, NxFluidEventType eventType))(functionPointers[NxFluidUserNotify_doxybind::getPointerStart() + 1]);
    return func(fluid, eventType);
}

NxForceField_doxybind::NxForceField_doxybind() : NxForceField()
{
}

void NxForceField_doxybind::saveToDesc(NxForceFieldDesc & desc) 
{
    void (*func)(NxForceFieldDesc & desc) = (void (*)(NxForceFieldDesc & desc))(functionPointers[NxForceField_doxybind::getPointerStart() + 0]);
     func(desc);
}

NxMat34 NxForceField_doxybind::getPose() const
{
    NxMat34 (*func)() = (NxMat34 (*)())(functionPointers[NxForceField_doxybind::getPointerStart() + 1]);
    return func();
}

void NxForceField_doxybind::setPose(const NxMat34 & pose) 
{
    void (*func)(const NxMat34 & pose) = (void (*)(const NxMat34 & pose))(functionPointers[NxForceField_doxybind::getPointerStart() + 2]);
     func(pose);
}

NxActor * NxForceField_doxybind::getActor() const
{
    NxActor * (*func)() = (NxActor * (*)())(functionPointers[NxForceField_doxybind::getPointerStart() + 3]);
    return func();
}

void NxForceField_doxybind::setActor(NxActor * actor) 
{
    void (*func)(NxActor * actor) = (void (*)(NxActor * actor))(functionPointers[NxForceField_doxybind::getPointerStart() + 4]);
     func(actor);
}

void NxForceField_doxybind::setForceFieldKernel(NxForceFieldKernel * kernel) 
{
    void (*func)(NxForceFieldKernel * kernel) = (void (*)(NxForceFieldKernel * kernel))(functionPointers[NxForceField_doxybind::getPointerStart() + 5]);
     func(kernel);
}

NxForceFieldKernel * NxForceField_doxybind::getForceFieldKernel() 
{
    NxForceFieldKernel * (*func)() = (NxForceFieldKernel * (*)())(functionPointers[NxForceField_doxybind::getPointerStart() + 6]);
    return func();
}

NxForceFieldShapeGroup & NxForceField_doxybind::getIncludeShapeGroup() 
{
    NxForceFieldShapeGroup & (*func)() = (NxForceFieldShapeGroup & (*)())(functionPointers[NxForceField_doxybind::getPointerStart() + 7]);
    return func();
}

void NxForceField_doxybind::addShapeGroup(NxForceFieldShapeGroup & group) 
{
    void (*func)(NxForceFieldShapeGroup & group) = (void (*)(NxForceFieldShapeGroup & group))(functionPointers[NxForceField_doxybind::getPointerStart() + 8]);
     func(group);
}

void NxForceField_doxybind::removeShapeGroup(NxForceFieldShapeGroup & unknown9) 
{
    void (*func)(NxForceFieldShapeGroup & unknown9) = (void (*)(NxForceFieldShapeGroup & unknown9))(functionPointers[NxForceField_doxybind::getPointerStart() + 9]);
     func(unknown9);
}

NxU32 NxForceField_doxybind::getNbShapeGroups() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxForceField_doxybind::getPointerStart() + 10]);
    return func();
}

void NxForceField_doxybind::resetShapeGroupsIterator() 
{
    void (*func)() = (void (*)())(functionPointers[NxForceField_doxybind::getPointerStart() + 11]);
     func();
}

NxForceFieldShapeGroup * NxForceField_doxybind::getNextShapeGroup() 
{
    NxForceFieldShapeGroup * (*func)() = (NxForceFieldShapeGroup * (*)())(functionPointers[NxForceField_doxybind::getPointerStart() + 12]);
    return func();
}

NxCollisionGroup NxForceField_doxybind::getGroup() const
{
    NxCollisionGroup (*func)() = (NxCollisionGroup (*)())(functionPointers[NxForceField_doxybind::getPointerStart() + 13]);
    return func();
}

void NxForceField_doxybind::setGroup(NxCollisionGroup collisionGroup) 
{
    void (*func)(NxCollisionGroup collisionGroup) = (void (*)(NxCollisionGroup collisionGroup))(functionPointers[NxForceField_doxybind::getPointerStart() + 14]);
     func(collisionGroup);
}

NxGroupsMask NxForceField_doxybind::getGroupsMask() const
{
    NxGroupsMask (*func)() = (NxGroupsMask (*)())(functionPointers[NxForceField_doxybind::getPointerStart() + 15]);
    return func();
}

void NxForceField_doxybind::setGroupsMask(NxGroupsMask mask) 
{
    void (*func)(NxGroupsMask mask) = (void (*)(NxGroupsMask mask))(functionPointers[NxForceField_doxybind::getPointerStart() + 16]);
     func(mask);
}

NxForceFieldCoordinates NxForceField_doxybind::getCoordinates() const
{
    NxForceFieldCoordinates (*func)() = (NxForceFieldCoordinates (*)())(functionPointers[NxForceField_doxybind::getPointerStart() + 17]);
    return func();
}

void NxForceField_doxybind::setCoordinates(NxForceFieldCoordinates coordinates) 
{
    void (*func)(NxForceFieldCoordinates coordinates) = (void (*)(NxForceFieldCoordinates coordinates))(functionPointers[NxForceField_doxybind::getPointerStart() + 18]);
     func(coordinates);
}

void NxForceField_doxybind::setName(const char * name) 
{
    void (*func)(const char * name) = (void (*)(const char * name))(functionPointers[NxForceField_doxybind::getPointerStart() + 19]);
     func(name);
}

const char * NxForceField_doxybind::getName() const
{
    const char * (*func)() = (const char * (*)())(functionPointers[NxForceField_doxybind::getPointerStart() + 20]);
    return func();
}

NxForceFieldType NxForceField_doxybind::getFluidType() const
{
    NxForceFieldType (*func)() = (NxForceFieldType (*)())(functionPointers[NxForceField_doxybind::getPointerStart() + 21]);
    return func();
}

void NxForceField_doxybind::setFluidType(NxForceFieldType t) 
{
    void (*func)(NxForceFieldType t) = (void (*)(NxForceFieldType t))(functionPointers[NxForceField_doxybind::getPointerStart() + 22]);
     func(t);
}

NxForceFieldType NxForceField_doxybind::getClothType() const
{
    NxForceFieldType (*func)() = (NxForceFieldType (*)())(functionPointers[NxForceField_doxybind::getPointerStart() + 23]);
    return func();
}

void NxForceField_doxybind::setClothType(NxForceFieldType t) 
{
    void (*func)(NxForceFieldType t) = (void (*)(NxForceFieldType t))(functionPointers[NxForceField_doxybind::getPointerStart() + 24]);
     func(t);
}

NxForceFieldType NxForceField_doxybind::getSoftBodyType() const
{
    NxForceFieldType (*func)() = (NxForceFieldType (*)())(functionPointers[NxForceField_doxybind::getPointerStart() + 25]);
    return func();
}

void NxForceField_doxybind::setSoftBodyType(NxForceFieldType t) 
{
    void (*func)(NxForceFieldType t) = (void (*)(NxForceFieldType t))(functionPointers[NxForceField_doxybind::getPointerStart() + 26]);
     func(t);
}

NxForceFieldType NxForceField_doxybind::getRigidBodyType() const
{
    NxForceFieldType (*func)() = (NxForceFieldType (*)())(functionPointers[NxForceField_doxybind::getPointerStart() + 27]);
    return func();
}

void NxForceField_doxybind::setRigidBodyType(NxForceFieldType t) 
{
    void (*func)(NxForceFieldType t) = (void (*)(NxForceFieldType t))(functionPointers[NxForceField_doxybind::getPointerStart() + 28]);
     func(t);
}

NxU32 NxForceField_doxybind::getFlags() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxForceField_doxybind::getPointerStart() + 29]);
    return func();
}

void NxForceField_doxybind::setFlags(NxU32 f) 
{
    void (*func)(NxU32 f) = (void (*)(NxU32 f))(functionPointers[NxForceField_doxybind::getPointerStart() + 30]);
     func(f);
}

void NxForceField_doxybind::samplePoints(NxU32 numPoints, const NxVec3 * points, const NxVec3 * velocities, NxVec3 * outForces, NxVec3 * outTorques) const
{
    void (*func)(NxU32 numPoints, const NxVec3 * points, const NxVec3 * velocities, NxVec3 * outForces, NxVec3 * outTorques) = (void (*)(NxU32 numPoints, const NxVec3 * points, const NxVec3 * velocities, NxVec3 * outForces, NxVec3 * outTorques))(functionPointers[NxForceField_doxybind::getPointerStart() + 31]);
     func(numPoints, points, velocities, outForces, outTorques);
}

NxScene & NxForceField_doxybind::getScene() const
{
    NxScene & (*func)() = (NxScene & (*)())(functionPointers[NxForceField_doxybind::getPointerStart() + 32]);
    return func();
}

NxForceFieldVariety NxForceField_doxybind::getForceFieldVariety() const
{
    NxForceFieldVariety (*func)() = (NxForceFieldVariety (*)())(functionPointers[NxForceField_doxybind::getPointerStart() + 33]);
    return func();
}

void NxForceField_doxybind::setForceFieldVariety(NxForceFieldVariety unknown10) 
{
    void (*func)(NxForceFieldVariety unknown10) = (void (*)(NxForceFieldVariety unknown10))(functionPointers[NxForceField_doxybind::getPointerStart() + 34]);
     func(unknown10);
}

void NxForceFieldKernel_doxybind::parse() const
{
    void (*func)() = (void (*)())(functionPointers[NxForceFieldKernel_doxybind::getPointerStart() + 0]);
     func();
}

bool NxForceFieldKernel_doxybind::evaluate(NxVec3 & force, NxVec3 & torque, const NxVec3 & position, const NxVec3 & velocity) const
{
    bool (*func)(NxVec3 & force, NxVec3 & torque, const NxVec3 & position, const NxVec3 & velocity) = (bool (*)(NxVec3 & force, NxVec3 & torque, const NxVec3 & position, const NxVec3 & velocity))(functionPointers[NxForceFieldKernel_doxybind::getPointerStart() + 1]);
    return func(force, torque, position, velocity);
}

NxU32 NxForceFieldKernel_doxybind::getType() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxForceFieldKernel_doxybind::getPointerStart() + 2]);
    return func();
}

NxForceFieldKernel * NxForceFieldKernel_doxybind::clone() const
{
    NxForceFieldKernel * (*func)() = (NxForceFieldKernel * (*)())(functionPointers[NxForceFieldKernel_doxybind::getPointerStart() + 3]);
    return func();
}

void NxForceFieldKernel_doxybind::update(NxForceFieldKernel & in) const
{
    void (*func)(NxForceFieldKernel & in) = (void (*)(NxForceFieldKernel & in))(functionPointers[NxForceFieldKernel_doxybind::getPointerStart() + 4]);
     func(in);
}

void NxForceFieldKernel_doxybind::setEpsilon(NxReal eps) 
{
    void (*func)(NxReal eps) = (void (*)(NxReal eps))(functionPointers[NxForceFieldKernel_doxybind::getPointerStart() + 5]);
     func(eps);
}

NxForceFieldLinearKernel_doxybind::NxForceFieldLinearKernel_doxybind() : NxForceFieldLinearKernel()
{
}

NxVec3 NxForceFieldLinearKernel_doxybind::getConstant() const
{
    NxVec3 (*func)() = (NxVec3 (*)())(functionPointers[NxForceFieldLinearKernel_doxybind::getPointerStart() + 0]);
    return func();
}

void NxForceFieldLinearKernel_doxybind::setConstant(const NxVec3 & unknown11) 
{
    void (*func)(const NxVec3 & unknown11) = (void (*)(const NxVec3 & unknown11))(functionPointers[NxForceFieldLinearKernel_doxybind::getPointerStart() + 1]);
     func(unknown11);
}

NxMat33 NxForceFieldLinearKernel_doxybind::getPositionMultiplier() const
{
    NxMat33 (*func)() = (NxMat33 (*)())(functionPointers[NxForceFieldLinearKernel_doxybind::getPointerStart() + 2]);
    return func();
}

void NxForceFieldLinearKernel_doxybind::setPositionMultiplier(const NxMat33 & unknown12) 
{
    void (*func)(const NxMat33 & unknown12) = (void (*)(const NxMat33 & unknown12))(functionPointers[NxForceFieldLinearKernel_doxybind::getPointerStart() + 3]);
     func(unknown12);
}

NxMat33 NxForceFieldLinearKernel_doxybind::getVelocityMultiplier() const
{
    NxMat33 (*func)() = (NxMat33 (*)())(functionPointers[NxForceFieldLinearKernel_doxybind::getPointerStart() + 4]);
    return func();
}

void NxForceFieldLinearKernel_doxybind::setVelocityMultiplier(const NxMat33 & unknown13) 
{
    void (*func)(const NxMat33 & unknown13) = (void (*)(const NxMat33 & unknown13))(functionPointers[NxForceFieldLinearKernel_doxybind::getPointerStart() + 5]);
     func(unknown13);
}

NxVec3 NxForceFieldLinearKernel_doxybind::getPositionTarget() const
{
    NxVec3 (*func)() = (NxVec3 (*)())(functionPointers[NxForceFieldLinearKernel_doxybind::getPointerStart() + 6]);
    return func();
}

void NxForceFieldLinearKernel_doxybind::setPositionTarget(const NxVec3 & unknown14) 
{
    void (*func)(const NxVec3 & unknown14) = (void (*)(const NxVec3 & unknown14))(functionPointers[NxForceFieldLinearKernel_doxybind::getPointerStart() + 7]);
     func(unknown14);
}

NxVec3 NxForceFieldLinearKernel_doxybind::getVelocityTarget() const
{
    NxVec3 (*func)() = (NxVec3 (*)())(functionPointers[NxForceFieldLinearKernel_doxybind::getPointerStart() + 8]);
    return func();
}

void NxForceFieldLinearKernel_doxybind::setVelocityTarget(const NxVec3 & unknown15) 
{
    void (*func)(const NxVec3 & unknown15) = (void (*)(const NxVec3 & unknown15))(functionPointers[NxForceFieldLinearKernel_doxybind::getPointerStart() + 9]);
     func(unknown15);
}

NxVec3 NxForceFieldLinearKernel_doxybind::getFalloffLinear() const
{
    NxVec3 (*func)() = (NxVec3 (*)())(functionPointers[NxForceFieldLinearKernel_doxybind::getPointerStart() + 10]);
    return func();
}

void NxForceFieldLinearKernel_doxybind::setFalloffLinear(const NxVec3 & unknown16) 
{
    void (*func)(const NxVec3 & unknown16) = (void (*)(const NxVec3 & unknown16))(functionPointers[NxForceFieldLinearKernel_doxybind::getPointerStart() + 11]);
     func(unknown16);
}

NxVec3 NxForceFieldLinearKernel_doxybind::getFalloffQuadratic() const
{
    NxVec3 (*func)() = (NxVec3 (*)())(functionPointers[NxForceFieldLinearKernel_doxybind::getPointerStart() + 12]);
    return func();
}

void NxForceFieldLinearKernel_doxybind::setFalloffQuadratic(const NxVec3 & unknown17) 
{
    void (*func)(const NxVec3 & unknown17) = (void (*)(const NxVec3 & unknown17))(functionPointers[NxForceFieldLinearKernel_doxybind::getPointerStart() + 13]);
     func(unknown17);
}

NxVec3 NxForceFieldLinearKernel_doxybind::getNoise() const
{
    NxVec3 (*func)() = (NxVec3 (*)())(functionPointers[NxForceFieldLinearKernel_doxybind::getPointerStart() + 14]);
    return func();
}

void NxForceFieldLinearKernel_doxybind::setNoise(const NxVec3 & unknown18) 
{
    void (*func)(const NxVec3 & unknown18) = (void (*)(const NxVec3 & unknown18))(functionPointers[NxForceFieldLinearKernel_doxybind::getPointerStart() + 15]);
     func(unknown18);
}

NxReal NxForceFieldLinearKernel_doxybind::getTorusRadius() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxForceFieldLinearKernel_doxybind::getPointerStart() + 16]);
    return func();
}

void NxForceFieldLinearKernel_doxybind::setTorusRadius(NxReal unknown19) 
{
    void (*func)(NxReal unknown19) = (void (*)(NxReal unknown19))(functionPointers[NxForceFieldLinearKernel_doxybind::getPointerStart() + 17]);
     func(unknown19);
}

NxScene & NxForceFieldLinearKernel_doxybind::getScene() const
{
    NxScene & (*func)() = (NxScene & (*)())(functionPointers[NxForceFieldLinearKernel_doxybind::getPointerStart() + 18]);
    return func();
}

void NxForceFieldLinearKernel_doxybind::saveToDesc(NxForceFieldLinearKernelDesc & desc) 
{
    void (*func)(NxForceFieldLinearKernelDesc & desc) = (void (*)(NxForceFieldLinearKernelDesc & desc))(functionPointers[NxForceFieldLinearKernel_doxybind::getPointerStart() + 19]);
     func(desc);
}

void NxForceFieldLinearKernel_doxybind::setName(const char * name) 
{
    void (*func)(const char * name) = (void (*)(const char * name))(functionPointers[NxForceFieldLinearKernel_doxybind::getPointerStart() + 20]);
     func(name);
}

const char * NxForceFieldLinearKernel_doxybind::getName() const
{
    const char * (*func)() = (const char * (*)())(functionPointers[NxForceFieldLinearKernel_doxybind::getPointerStart() + 21]);
    return func();
}

void NxForceFieldLinearKernel_doxybind::parse() const
{
    void (*func)() = (void (*)())(functionPointers[NxForceFieldKernel_doxybind::getPointerStart() + 0]);
     func();
}

bool NxForceFieldLinearKernel_doxybind::evaluate(NxVec3 & force, NxVec3 & torque, const NxVec3 & position, const NxVec3 & velocity) const
{
    bool (*func)(NxVec3 & force, NxVec3 & torque, const NxVec3 & position, const NxVec3 & velocity) = (bool (*)(NxVec3 & force, NxVec3 & torque, const NxVec3 & position, const NxVec3 & velocity))(functionPointers[NxForceFieldKernel_doxybind::getPointerStart() + 1]);
    return func(force, torque, position, velocity);
}

NxU32 NxForceFieldLinearKernel_doxybind::getType() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxForceFieldKernel_doxybind::getPointerStart() + 2]);
    return func();
}

NxForceFieldKernel * NxForceFieldLinearKernel_doxybind::clone() const
{
    NxForceFieldKernel * (*func)() = (NxForceFieldKernel * (*)())(functionPointers[NxForceFieldKernel_doxybind::getPointerStart() + 3]);
    return func();
}

void NxForceFieldLinearKernel_doxybind::update(NxForceFieldKernel & in) const
{
    void (*func)(NxForceFieldKernel & in) = (void (*)(NxForceFieldKernel & in))(functionPointers[NxForceFieldKernel_doxybind::getPointerStart() + 4]);
     func(in);
}

void NxForceFieldLinearKernel_doxybind::setEpsilon(NxReal eps) 
{
    void (*func)(NxReal eps) = (void (*)(NxReal eps))(functionPointers[NxForceFieldKernel_doxybind::getPointerStart() + 5]);
     func(eps);
}

NxForceFieldShapeGroup_doxybind::NxForceFieldShapeGroup_doxybind() : NxForceFieldShapeGroup()
{
}

NxForceFieldShape * NxForceFieldShapeGroup_doxybind::createShape(const NxForceFieldShapeDesc & unknown20) 
{
    NxForceFieldShape * (*func)(const NxForceFieldShapeDesc & unknown20) = (NxForceFieldShape * (*)(const NxForceFieldShapeDesc & unknown20))(functionPointers[NxForceFieldShapeGroup_doxybind::getPointerStart() + 0]);
    return func(unknown20);
}

void NxForceFieldShapeGroup_doxybind::releaseShape(const NxForceFieldShape & unknown21) 
{
    void (*func)(const NxForceFieldShape & unknown21) = (void (*)(const NxForceFieldShape & unknown21))(functionPointers[NxForceFieldShapeGroup_doxybind::getPointerStart() + 1]);
     func(unknown21);
}

NxU32 NxForceFieldShapeGroup_doxybind::getNbShapes() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxForceFieldShapeGroup_doxybind::getPointerStart() + 2]);
    return func();
}

void NxForceFieldShapeGroup_doxybind::resetShapesIterator() 
{
    void (*func)() = (void (*)())(functionPointers[NxForceFieldShapeGroup_doxybind::getPointerStart() + 3]);
     func();
}

NxForceFieldShape * NxForceFieldShapeGroup_doxybind::getNextShape() 
{
    NxForceFieldShape * (*func)() = (NxForceFieldShape * (*)())(functionPointers[NxForceFieldShapeGroup_doxybind::getPointerStart() + 4]);
    return func();
}

NxForceField * NxForceFieldShapeGroup_doxybind::getForceField() const
{
    NxForceField * (*func)() = (NxForceField * (*)())(functionPointers[NxForceFieldShapeGroup_doxybind::getPointerStart() + 5]);
    return func();
}

NxU32 NxForceFieldShapeGroup_doxybind::getFlags() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxForceFieldShapeGroup_doxybind::getPointerStart() + 6]);
    return func();
}

void NxForceFieldShapeGroup_doxybind::saveToDesc(NxForceFieldShapeGroupDesc & desc) 
{
    void (*func)(NxForceFieldShapeGroupDesc & desc) = (void (*)(NxForceFieldShapeGroupDesc & desc))(functionPointers[NxForceFieldShapeGroup_doxybind::getPointerStart() + 7]);
     func(desc);
}

NxScene & NxForceFieldShapeGroup_doxybind::getScene() const
{
    NxScene & (*func)() = (NxScene & (*)())(functionPointers[NxForceFieldShapeGroup_doxybind::getPointerStart() + 8]);
    return func();
}

void NxForceFieldShapeGroup_doxybind::setName(const char * name) 
{
    void (*func)(const char * name) = (void (*)(const char * name))(functionPointers[NxForceFieldShapeGroup_doxybind::getPointerStart() + 9]);
     func(name);
}

const char * NxForceFieldShapeGroup_doxybind::getName() const
{
    const char * (*func)() = (const char * (*)())(functionPointers[NxForceFieldShapeGroup_doxybind::getPointerStart() + 10]);
    return func();
}

void NxFoundationSDK_doxybind::release() 
{
    void (*func)() = (void (*)())(functionPointers[NxFoundationSDK_doxybind::getPointerStart() + 0]);
     func();
}

void NxFoundationSDK_doxybind::setErrorStream(NxUserOutputStream * stream) 
{
    void (*func)(NxUserOutputStream * stream) = (void (*)(NxUserOutputStream * stream))(functionPointers[NxFoundationSDK_doxybind::getPointerStart() + 1]);
     func(stream);
}

NxUserOutputStream * NxFoundationSDK_doxybind::getErrorStream() 
{
    NxUserOutputStream * (*func)() = (NxUserOutputStream * (*)())(functionPointers[NxFoundationSDK_doxybind::getPointerStart() + 2]);
    return func();
}

NxErrorCode NxFoundationSDK_doxybind::getLastError() 
{
    NxErrorCode (*func)() = (NxErrorCode (*)())(functionPointers[NxFoundationSDK_doxybind::getPointerStart() + 3]);
    return func();
}

NxErrorCode NxFoundationSDK_doxybind::getFirstError() 
{
    NxErrorCode (*func)() = (NxErrorCode (*)())(functionPointers[NxFoundationSDK_doxybind::getPointerStart() + 4]);
    return func();
}

NxUserAllocator & NxFoundationSDK_doxybind::getAllocator() 
{
    NxUserAllocator & (*func)() = (NxUserAllocator & (*)())(functionPointers[NxFoundationSDK_doxybind::getPointerStart() + 5]);
    return func();
}

NxRemoteDebugger * NxFoundationSDK_doxybind::getRemoteDebugger() 
{
    NxRemoteDebugger * (*func)() = (NxRemoteDebugger * (*)())(functionPointers[NxFoundationSDK_doxybind::getPointerStart() + 6]);
    return func();
}

void NxFoundationSDK_doxybind::setAllocaThreshold(NxU32 threshold) 
{
    void (*func)(NxU32 threshold) = (void (*)(NxU32 threshold))(functionPointers[NxFoundationSDK_doxybind::getPointerStart() + 7]);
     func(threshold);
}

bool NxHeightField_doxybind::saveToDesc(NxHeightFieldDesc & desc) const
{
    bool (*func)(NxHeightFieldDesc & desc) = (bool (*)(NxHeightFieldDesc & desc))(functionPointers[NxHeightField_doxybind::getPointerStart() + 0]);
    return func(desc);
}

bool NxHeightField_doxybind::loadFromDesc(const NxHeightFieldDesc & desc) 
{
    bool (*func)(const NxHeightFieldDesc & desc) = (bool (*)(const NxHeightFieldDesc & desc))(functionPointers[NxHeightField_doxybind::getPointerStart() + 1]);
    return func(desc);
}

NxU32 NxHeightField_doxybind::saveCells(void * destBuffer, NxU32 destBufferSize) const
{
    NxU32 (*func)(void * destBuffer, NxU32 destBufferSize) = (NxU32 (*)(void * destBuffer, NxU32 destBufferSize))(functionPointers[NxHeightField_doxybind::getPointerStart() + 2]);
    return func(destBuffer, destBufferSize);
}

NxU32 NxHeightField_doxybind::getNbRows() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxHeightField_doxybind::getPointerStart() + 3]);
    return func();
}

NxU32 NxHeightField_doxybind::getNbColumns() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxHeightField_doxybind::getPointerStart() + 4]);
    return func();
}

NxHeightFieldFormat NxHeightField_doxybind::getFormat() const
{
    NxHeightFieldFormat (*func)() = (NxHeightFieldFormat (*)())(functionPointers[NxHeightField_doxybind::getPointerStart() + 5]);
    return func();
}

NxU32 NxHeightField_doxybind::getSampleStride() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxHeightField_doxybind::getPointerStart() + 6]);
    return func();
}

NxReal NxHeightField_doxybind::getVerticalExtent() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxHeightField_doxybind::getPointerStart() + 7]);
    return func();
}

NxReal NxHeightField_doxybind::getThickness() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxHeightField_doxybind::getPointerStart() + 8]);
    return func();
}

NxReal NxHeightField_doxybind::getConvexEdgeThreshold() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxHeightField_doxybind::getPointerStart() + 9]);
    return func();
}

NxU32 NxHeightField_doxybind::getFlags() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxHeightField_doxybind::getPointerStart() + 10]);
    return func();
}

NxReal NxHeightField_doxybind::getHeight(NxReal x, NxReal z) const
{
    NxReal (*func)(NxReal x, NxReal z) = (NxReal (*)(NxReal x, NxReal z))(functionPointers[NxHeightField_doxybind::getPointerStart() + 11]);
    return func(x, z);
}

const void * NxHeightField_doxybind::getCells() const
{
    const void * (*func)() = (const void * (*)())(functionPointers[NxHeightField_doxybind::getPointerStart() + 12]);
    return func();
}

NxU32 NxHeightField_doxybind::getReferenceCount() 
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxHeightField_doxybind::getPointerStart() + 13]);
    return func();
}

void NxHeightFieldShape_doxybind::saveToDesc(NxHeightFieldShapeDesc & desc) const
{
    void (*func)(NxHeightFieldShapeDesc & desc) = (void (*)(NxHeightFieldShapeDesc & desc))(functionPointers[NxHeightFieldShape_doxybind::getPointerStart() + 0]);
     func(desc);
}

NxHeightField & NxHeightFieldShape_doxybind::getHeightField() const
{
    NxHeightField & (*func)() = (NxHeightField & (*)())(functionPointers[NxHeightFieldShape_doxybind::getPointerStart() + 1]);
    return func();
}

NxReal NxHeightFieldShape_doxybind::getHeightScale() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxHeightFieldShape_doxybind::getPointerStart() + 2]);
    return func();
}

NxReal NxHeightFieldShape_doxybind::getRowScale() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxHeightFieldShape_doxybind::getPointerStart() + 3]);
    return func();
}

NxReal NxHeightFieldShape_doxybind::getColumnScale() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxHeightFieldShape_doxybind::getPointerStart() + 4]);
    return func();
}

void NxHeightFieldShape_doxybind::setHeightScale(NxReal scale) 
{
    void (*func)(NxReal scale) = (void (*)(NxReal scale))(functionPointers[NxHeightFieldShape_doxybind::getPointerStart() + 5]);
     func(scale);
}

void NxHeightFieldShape_doxybind::setRowScale(NxReal scale) 
{
    void (*func)(NxReal scale) = (void (*)(NxReal scale))(functionPointers[NxHeightFieldShape_doxybind::getPointerStart() + 6]);
     func(scale);
}

void NxHeightFieldShape_doxybind::setColumnScale(NxReal scale) 
{
    void (*func)(NxReal scale) = (void (*)(NxReal scale))(functionPointers[NxHeightFieldShape_doxybind::getPointerStart() + 7]);
     func(scale);
}

NxU32 NxHeightFieldShape_doxybind::getTriangle(NxTriangle & worldTri, NxTriangle * edgeTri, NxU32 * flags, NxTriangleID triangleIndex, bool worldSpaceTranslation, bool worldSpaceRotation) const
{
    NxU32 (*func)(NxTriangle & worldTri, NxTriangle * edgeTri, NxU32 * flags, NxTriangleID triangleIndex, bool worldSpaceTranslation, bool worldSpaceRotation) = (NxU32 (*)(NxTriangle & worldTri, NxTriangle * edgeTri, NxU32 * flags, NxTriangleID triangleIndex, bool worldSpaceTranslation, bool worldSpaceRotation))(functionPointers[NxHeightFieldShape_doxybind::getPointerStart() + 8]);
    return func(worldTri, edgeTri, flags, triangleIndex, worldSpaceTranslation, worldSpaceRotation);
}

NxU32 NxHeightFieldShape_doxybind::getTriangle(NxTriangle & worldTri, NxTriangle * edgeTri, NxU32 * flags, NxTriangleID triangleIndex, bool worldSpaceTranslation) const
{
    NxU32 (*func)(NxTriangle & worldTri, NxTriangle * edgeTri, NxU32 * flags, NxTriangleID triangleIndex, bool worldSpaceTranslation) = (NxU32 (*)(NxTriangle & worldTri, NxTriangle * edgeTri, NxU32 * flags, NxTriangleID triangleIndex, bool worldSpaceTranslation))(functionPointers[NxHeightFieldShape_doxybind::getPointerStart() + 9]);
    return func(worldTri, edgeTri, flags, triangleIndex, worldSpaceTranslation);
}

NxU32 NxHeightFieldShape_doxybind::getTriangle(NxTriangle & worldTri, NxTriangle * edgeTri, NxU32 * flags, NxTriangleID triangleIndex) const
{
    NxU32 (*func)(NxTriangle & worldTri, NxTriangle * edgeTri, NxU32 * flags, NxTriangleID triangleIndex) = (NxU32 (*)(NxTriangle & worldTri, NxTriangle * edgeTri, NxU32 * flags, NxTriangleID triangleIndex))(functionPointers[NxHeightFieldShape_doxybind::getPointerStart() + 10]);
    return func(worldTri, edgeTri, flags, triangleIndex);
}

bool NxHeightFieldShape_doxybind::overlapAABBTrianglesDeprecated(const NxBounds3 & bounds, NxU32 flags, NxU32 & nb, const NxU32 *& indices) const
{
    bool (*func)(const NxBounds3 & bounds, NxU32 flags, NxU32 & nb, const NxU32 *& indices) = (bool (*)(const NxBounds3 & bounds, NxU32 flags, NxU32 & nb, const NxU32 *& indices))(functionPointers[NxHeightFieldShape_doxybind::getPointerStart() + 11]);
    return func(bounds, flags, nb, indices);
}

bool NxHeightFieldShape_doxybind::overlapAABBTriangles(const NxBounds3 & bounds, NxU32 flags, NxUserEntityReport< NxU32 > * callback) const
{
    bool (*func)(const NxBounds3 & bounds, NxU32 flags, NxUserEntityReport< NxU32 > * callback) = (bool (*)(const NxBounds3 & bounds, NxU32 flags, NxUserEntityReport< NxU32 > * callback))(functionPointers[NxHeightFieldShape_doxybind::getPointerStart() + 12]);
    return func(bounds, flags, callback);
}

bool NxHeightFieldShape_doxybind::isShapePointOnHeightField(NxReal x, NxReal z) const
{
    bool (*func)(NxReal x, NxReal z) = (bool (*)(NxReal x, NxReal z))(functionPointers[NxHeightFieldShape_doxybind::getPointerStart() + 13]);
    return func(x, z);
}

NxReal NxHeightFieldShape_doxybind::getHeightAtShapePoint(NxReal x, NxReal z) const
{
    NxReal (*func)(NxReal x, NxReal z) = (NxReal (*)(NxReal x, NxReal z))(functionPointers[NxHeightFieldShape_doxybind::getPointerStart() + 14]);
    return func(x, z);
}

NxMaterialIndex NxHeightFieldShape_doxybind::getMaterialAtShapePoint(NxReal x, NxReal z) const
{
    NxMaterialIndex (*func)(NxReal x, NxReal z) = (NxMaterialIndex (*)(NxReal x, NxReal z))(functionPointers[NxHeightFieldShape_doxybind::getPointerStart() + 15]);
    return func(x, z);
}

NxVec3 NxHeightFieldShape_doxybind::getNormalAtShapePoint(NxReal x, NxReal z) const
{
    NxVec3 (*func)(NxReal x, NxReal z) = (NxVec3 (*)(NxReal x, NxReal z))(functionPointers[NxHeightFieldShape_doxybind::getPointerStart() + 16]);
    return func(x, z);
}

NxVec3 NxHeightFieldShape_doxybind::getSmoothNormalAtShapePoint(NxReal x, NxReal z) const
{
    NxVec3 (*func)(NxReal x, NxReal z) = (NxVec3 (*)(NxReal x, NxReal z))(functionPointers[NxHeightFieldShape_doxybind::getPointerStart() + 17]);
    return func(x, z);
}

void NxHeightFieldShape_doxybind::setLocalPose(const NxMat34 & mat) 
{
    void (*func)(const NxMat34 & mat) = (void (*)(const NxMat34 & mat))(functionPointers[NxShape_doxybind::getPointerStart() + 0]);
     func(mat);
}

void NxHeightFieldShape_doxybind::setLocalPosition(const NxVec3 & vec) 
{
    void (*func)(const NxVec3 & vec) = (void (*)(const NxVec3 & vec))(functionPointers[NxShape_doxybind::getPointerStart() + 1]);
     func(vec);
}

void NxHeightFieldShape_doxybind::setLocalOrientation(const NxMat33 & mat) 
{
    void (*func)(const NxMat33 & mat) = (void (*)(const NxMat33 & mat))(functionPointers[NxShape_doxybind::getPointerStart() + 2]);
     func(mat);
}

NxMat34 NxHeightFieldShape_doxybind::getLocalPose() const
{
    NxMat34 (*func)() = (NxMat34 (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 3]);
    return func();
}

NxVec3 NxHeightFieldShape_doxybind::getLocalPosition() const
{
    NxVec3 (*func)() = (NxVec3 (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 4]);
    return func();
}

NxMat33 NxHeightFieldShape_doxybind::getLocalOrientation() const
{
    NxMat33 (*func)() = (NxMat33 (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 5]);
    return func();
}

void NxHeightFieldShape_doxybind::setGlobalPose(const NxMat34 & mat) 
{
    void (*func)(const NxMat34 & mat) = (void (*)(const NxMat34 & mat))(functionPointers[NxShape_doxybind::getPointerStart() + 6]);
     func(mat);
}

void NxHeightFieldShape_doxybind::setGlobalPosition(const NxVec3 & vec) 
{
    void (*func)(const NxVec3 & vec) = (void (*)(const NxVec3 & vec))(functionPointers[NxShape_doxybind::getPointerStart() + 7]);
     func(vec);
}

void NxHeightFieldShape_doxybind::setGlobalOrientation(const NxMat33 & mat) 
{
    void (*func)(const NxMat33 & mat) = (void (*)(const NxMat33 & mat))(functionPointers[NxShape_doxybind::getPointerStart() + 8]);
     func(mat);
}

NxMat34 NxHeightFieldShape_doxybind::getGlobalPose() const
{
    NxMat34 (*func)() = (NxMat34 (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 9]);
    return func();
}

NxVec3 NxHeightFieldShape_doxybind::getGlobalPosition() const
{
    NxVec3 (*func)() = (NxVec3 (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 10]);
    return func();
}

NxMat33 NxHeightFieldShape_doxybind::getGlobalOrientation() const
{
    NxMat33 (*func)() = (NxMat33 (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 11]);
    return func();
}

void * NxHeightFieldShape_doxybind::is(NxShapeType type) 
{
    void * (*func)(NxShapeType type) = (void * (*)(NxShapeType type))(functionPointers[NxShape_doxybind::getPointerStart() + 12]);
    return func(type);
}

const void * NxHeightFieldShape_doxybind::is(NxShapeType type) const
{
    const void * (*func)(NxShapeType type) = (const void * (*)(NxShapeType type))(functionPointers[NxShape_doxybind::getPointerStart() + 13]);
    return func(type);
}

bool NxHeightFieldShape_doxybind::raycast(const NxRay & worldRay, NxReal maxDist, NxU32 hintFlags, NxRaycastHit & hit, bool firstHit) const
{
    bool (*func)(const NxRay & worldRay, NxReal maxDist, NxU32 hintFlags, NxRaycastHit & hit, bool firstHit) = (bool (*)(const NxRay & worldRay, NxReal maxDist, NxU32 hintFlags, NxRaycastHit & hit, bool firstHit))(functionPointers[NxShape_doxybind::getPointerStart() + 14]);
    return func(worldRay, maxDist, hintFlags, hit, firstHit);
}

bool NxHeightFieldShape_doxybind::checkOverlapSphere(const NxSphere & worldSphere) const
{
    bool (*func)(const NxSphere & worldSphere) = (bool (*)(const NxSphere & worldSphere))(functionPointers[NxShape_doxybind::getPointerStart() + 15]);
    return func(worldSphere);
}

bool NxHeightFieldShape_doxybind::checkOverlapOBB(const NxBox & worldBox) const
{
    bool (*func)(const NxBox & worldBox) = (bool (*)(const NxBox & worldBox))(functionPointers[NxShape_doxybind::getPointerStart() + 16]);
    return func(worldBox);
}

bool NxHeightFieldShape_doxybind::checkOverlapAABB(const NxBounds3 & worldBounds) const
{
    bool (*func)(const NxBounds3 & worldBounds) = (bool (*)(const NxBounds3 & worldBounds))(functionPointers[NxShape_doxybind::getPointerStart() + 17]);
    return func(worldBounds);
}

bool NxHeightFieldShape_doxybind::checkOverlapCapsule(const NxCapsule & worldCapsule) const
{
    bool (*func)(const NxCapsule & worldCapsule) = (bool (*)(const NxCapsule & worldCapsule))(functionPointers[NxShape_doxybind::getPointerStart() + 18]);
    return func(worldCapsule);
}

NxActor & NxHeightFieldShape_doxybind::getActor() const
{
    NxActor & (*func)() = (NxActor & (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 19]);
    return func();
}

void NxHeightFieldShape_doxybind::setGroup(NxCollisionGroup collisionGroup) 
{
    void (*func)(NxCollisionGroup collisionGroup) = (void (*)(NxCollisionGroup collisionGroup))(functionPointers[NxShape_doxybind::getPointerStart() + 20]);
     func(collisionGroup);
}

NxCollisionGroup NxHeightFieldShape_doxybind::getGroup() const
{
    NxCollisionGroup (*func)() = (NxCollisionGroup (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 21]);
    return func();
}

void NxHeightFieldShape_doxybind::getWorldBounds(NxBounds3 & dest) const
{
    void (*func)(NxBounds3 & dest) = (void (*)(NxBounds3 & dest))(functionPointers[NxShape_doxybind::getPointerStart() + 22]);
     func(dest);
}

void NxHeightFieldShape_doxybind::setFlag(NxShapeFlag flag, bool value) 
{
    void (*func)(NxShapeFlag flag, bool value) = (void (*)(NxShapeFlag flag, bool value))(functionPointers[NxShape_doxybind::getPointerStart() + 23]);
     func(flag, value);
}

NX_BOOL NxHeightFieldShape_doxybind::getFlag(NxShapeFlag flag) const
{
    NX_BOOL (*func)(NxShapeFlag flag) = (NX_BOOL (*)(NxShapeFlag flag))(functionPointers[NxShape_doxybind::getPointerStart() + 24]);
    return func(flag);
}

void NxHeightFieldShape_doxybind::setMaterial(NxMaterialIndex matIndex) 
{
    void (*func)(NxMaterialIndex matIndex) = (void (*)(NxMaterialIndex matIndex))(functionPointers[NxShape_doxybind::getPointerStart() + 25]);
     func(matIndex);
}

NxMaterialIndex NxHeightFieldShape_doxybind::getMaterial() const
{
    NxMaterialIndex (*func)() = (NxMaterialIndex (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 26]);
    return func();
}

void NxHeightFieldShape_doxybind::setSkinWidth(NxReal skinWidth) 
{
    void (*func)(NxReal skinWidth) = (void (*)(NxReal skinWidth))(functionPointers[NxShape_doxybind::getPointerStart() + 27]);
     func(skinWidth);
}

NxReal NxHeightFieldShape_doxybind::getSkinWidth() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 28]);
    return func();
}

NxShapeType NxHeightFieldShape_doxybind::getType() const
{
    NxShapeType (*func)() = (NxShapeType (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 29]);
    return func();
}

void NxHeightFieldShape_doxybind::setCCDSkeleton(NxCCDSkeleton * ccdSkel) 
{
    void (*func)(NxCCDSkeleton * ccdSkel) = (void (*)(NxCCDSkeleton * ccdSkel))(functionPointers[NxShape_doxybind::getPointerStart() + 30]);
     func(ccdSkel);
}

NxCCDSkeleton * NxHeightFieldShape_doxybind::getCCDSkeleton() const
{
    NxCCDSkeleton * (*func)() = (NxCCDSkeleton * (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 31]);
    return func();
}

void NxHeightFieldShape_doxybind::setName(const char * name) 
{
    void (*func)(const char * name) = (void (*)(const char * name))(functionPointers[NxShape_doxybind::getPointerStart() + 32]);
     func(name);
}

const char * NxHeightFieldShape_doxybind::getName() const
{
    const char * (*func)() = (const char * (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 33]);
    return func();
}

void NxHeightFieldShape_doxybind::setGroupsMask(const NxGroupsMask & mask) 
{
    void (*func)(const NxGroupsMask & mask) = (void (*)(const NxGroupsMask & mask))(functionPointers[NxShape_doxybind::getPointerStart() + 34]);
     func(mask);
}

const NxGroupsMask NxHeightFieldShape_doxybind::getGroupsMask() const
{
    const NxGroupsMask (*func)() = (const NxGroupsMask (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 35]);
    return func();
}

NxU32 NxHeightFieldShape_doxybind::getNonInteractingCompartmentTypes() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 36]);
    return func();
}

void NxHeightFieldShape_doxybind::setNonInteractingCompartmentTypes(NxU32 compartmentTypes) 
{
    void (*func)(NxU32 compartmentTypes) = (void (*)(NxU32 compartmentTypes))(functionPointers[NxShape_doxybind::getPointerStart() + 37]);
     func(compartmentTypes);
}

NxHeightFieldShapeDesc_doxybind::NxHeightFieldShapeDesc_doxybind() : NxHeightFieldShapeDesc()
{
}

void NxHeightFieldShapeDesc_doxybind::setToDefault() 
{
    void (*func)() = (void (*)())(functionPointers[NxHeightFieldShapeDesc_doxybind::getPointerStart() + 0]);
     func();
}

bool NxHeightFieldShapeDesc_doxybind::isValid() const
{
    bool (*func)() = (bool (*)())(functionPointers[NxHeightFieldShapeDesc_doxybind::getPointerStart() + 1]);
    return func();
}

int NxInterface_doxybind::getVersionNumber() const
{
    int (*func)() = (int (*)())(functionPointers[NxInterface_doxybind::getPointerStart() + 0]);
    return func();
}

NxInterfaceType NxInterface_doxybind::getInterfaceType() const
{
    NxInterfaceType (*func)() = (NxInterfaceType (*)())(functionPointers[NxInterface_doxybind::getPointerStart() + 1]);
    return func();
}

int NxInterfaceStats_doxybind::getVersionNumber() const
{
    int (*func)() = (int (*)())(functionPointers[NxInterfaceStats_doxybind::getPointerStart() + 0]);
    return func();
}

NxInterfaceType NxInterfaceStats_doxybind::getInterfaceType() const
{
    NxInterfaceType (*func)() = (NxInterfaceType (*)())(functionPointers[NxInterfaceStats_doxybind::getPointerStart() + 1]);
    return func();
}

bool NxInterfaceStats_doxybind::getHeapSize(int & used, int & unused) 
{
    bool (*func)(int & used, int & unused) = (bool (*)(int & used, int & unused))(functionPointers[NxInterfaceStats_doxybind::getPointerStart() + 2]);
    return func(used, unused);
}

NxMaterial_doxybind::NxMaterial_doxybind() : NxMaterial()
{
}

NxMaterialIndex NxMaterial_doxybind::getMaterialIndex() 
{
    NxMaterialIndex (*func)() = (NxMaterialIndex (*)())(functionPointers[NxMaterial_doxybind::getPointerStart() + 0]);
    return func();
}

void NxMaterial_doxybind::loadFromDesc(const NxMaterialDesc & desc) 
{
    void (*func)(const NxMaterialDesc & desc) = (void (*)(const NxMaterialDesc & desc))(functionPointers[NxMaterial_doxybind::getPointerStart() + 1]);
     func(desc);
}

void NxMaterial_doxybind::saveToDesc(NxMaterialDesc & desc) const
{
    void (*func)(NxMaterialDesc & desc) = (void (*)(NxMaterialDesc & desc))(functionPointers[NxMaterial_doxybind::getPointerStart() + 2]);
     func(desc);
}

NxScene & NxMaterial_doxybind::getScene() const
{
    NxScene & (*func)() = (NxScene & (*)())(functionPointers[NxMaterial_doxybind::getPointerStart() + 3]);
    return func();
}

void NxMaterial_doxybind::setDynamicFriction(NxReal coef) 
{
    void (*func)(NxReal coef) = (void (*)(NxReal coef))(functionPointers[NxMaterial_doxybind::getPointerStart() + 4]);
     func(coef);
}

NxReal NxMaterial_doxybind::getDynamicFriction() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxMaterial_doxybind::getPointerStart() + 5]);
    return func();
}

void NxMaterial_doxybind::setStaticFriction(NxReal coef) 
{
    void (*func)(NxReal coef) = (void (*)(NxReal coef))(functionPointers[NxMaterial_doxybind::getPointerStart() + 6]);
     func(coef);
}

NxReal NxMaterial_doxybind::getStaticFriction() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxMaterial_doxybind::getPointerStart() + 7]);
    return func();
}

void NxMaterial_doxybind::setRestitution(NxReal rest) 
{
    void (*func)(NxReal rest) = (void (*)(NxReal rest))(functionPointers[NxMaterial_doxybind::getPointerStart() + 8]);
     func(rest);
}

NxReal NxMaterial_doxybind::getRestitution() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxMaterial_doxybind::getPointerStart() + 9]);
    return func();
}

void NxMaterial_doxybind::setDynamicFrictionV(NxReal coef) 
{
    void (*func)(NxReal coef) = (void (*)(NxReal coef))(functionPointers[NxMaterial_doxybind::getPointerStart() + 10]);
     func(coef);
}

NxReal NxMaterial_doxybind::getDynamicFrictionV() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxMaterial_doxybind::getPointerStart() + 11]);
    return func();
}

void NxMaterial_doxybind::setStaticFrictionV(NxReal coef) 
{
    void (*func)(NxReal coef) = (void (*)(NxReal coef))(functionPointers[NxMaterial_doxybind::getPointerStart() + 12]);
     func(coef);
}

NxReal NxMaterial_doxybind::getStaticFrictionV() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxMaterial_doxybind::getPointerStart() + 13]);
    return func();
}

void NxMaterial_doxybind::setDirOfAnisotropy(const NxVec3 & vec) 
{
    void (*func)(const NxVec3 & vec) = (void (*)(const NxVec3 & vec))(functionPointers[NxMaterial_doxybind::getPointerStart() + 14]);
     func(vec);
}

NxVec3 NxMaterial_doxybind::getDirOfAnisotropy() const
{
    NxVec3 (*func)() = (NxVec3 (*)())(functionPointers[NxMaterial_doxybind::getPointerStart() + 15]);
    return func();
}

void NxMaterial_doxybind::setFlags(NxU32 flags) 
{
    void (*func)(NxU32 flags) = (void (*)(NxU32 flags))(functionPointers[NxMaterial_doxybind::getPointerStart() + 16]);
     func(flags);
}

NxU32 NxMaterial_doxybind::getFlags() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxMaterial_doxybind::getPointerStart() + 17]);
    return func();
}

void NxMaterial_doxybind::setFrictionCombineMode(NxCombineMode combMode) 
{
    void (*func)(NxCombineMode combMode) = (void (*)(NxCombineMode combMode))(functionPointers[NxMaterial_doxybind::getPointerStart() + 18]);
     func(combMode);
}

NxCombineMode NxMaterial_doxybind::getFrictionCombineMode() const
{
    NxCombineMode (*func)() = (NxCombineMode (*)())(functionPointers[NxMaterial_doxybind::getPointerStart() + 19]);
    return func();
}

void NxMaterial_doxybind::setRestitutionCombineMode(NxCombineMode combMode) 
{
    void (*func)(NxCombineMode combMode) = (void (*)(NxCombineMode combMode))(functionPointers[NxMaterial_doxybind::getPointerStart() + 20]);
     func(combMode);
}

NxCombineMode NxMaterial_doxybind::getRestitutionCombineMode() const
{
    NxCombineMode (*func)() = (NxCombineMode (*)())(functionPointers[NxMaterial_doxybind::getPointerStart() + 21]);
    return func();
}

NxPhysicsSDK_doxybind::NxPhysicsSDK_doxybind() : NxPhysicsSDK()
{
}

void NxPhysicsSDK_doxybind::release() 
{
    void (*func)() = (void (*)())(functionPointers[NxPhysicsSDK_doxybind::getPointerStart() + 0]);
     func();
}

bool NxPhysicsSDK_doxybind::setParameter(NxParameter paramEnum, NxReal paramValue) 
{
    bool (*func)(NxParameter paramEnum, NxReal paramValue) = (bool (*)(NxParameter paramEnum, NxReal paramValue))(functionPointers[NxPhysicsSDK_doxybind::getPointerStart() + 1]);
    return func(paramEnum, paramValue);
}

NxReal NxPhysicsSDK_doxybind::getParameter(NxParameter paramEnum) const
{
    NxReal (*func)(NxParameter paramEnum) = (NxReal (*)(NxParameter paramEnum))(functionPointers[NxPhysicsSDK_doxybind::getPointerStart() + 2]);
    return func(paramEnum);
}

NxScene * NxPhysicsSDK_doxybind::createScene(const NxSceneDesc & sceneDesc) 
{
    NxScene * (*func)(const NxSceneDesc & sceneDesc) = (NxScene * (*)(const NxSceneDesc & sceneDesc))(functionPointers[NxPhysicsSDK_doxybind::getPointerStart() + 3]);
    return func(sceneDesc);
}

void NxPhysicsSDK_doxybind::releaseScene(NxScene & scene) 
{
    void (*func)(NxScene & scene) = (void (*)(NxScene & scene))(functionPointers[NxPhysicsSDK_doxybind::getPointerStart() + 4]);
     func(scene);
}

NxU32 NxPhysicsSDK_doxybind::getNbScenes() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxPhysicsSDK_doxybind::getPointerStart() + 5]);
    return func();
}

NxScene * NxPhysicsSDK_doxybind::getScene(NxU32 i) 
{
    NxScene * (*func)(NxU32 i) = (NxScene * (*)(NxU32 i))(functionPointers[NxPhysicsSDK_doxybind::getPointerStart() + 6]);
    return func(i);
}

NxTriangleMesh * NxPhysicsSDK_doxybind::createTriangleMesh(const NxStream & stream) 
{
    NxTriangleMesh * (*func)(const NxStream & stream) = (NxTriangleMesh * (*)(const NxStream & stream))(functionPointers[NxPhysicsSDK_doxybind::getPointerStart() + 7]);
    return func(stream);
}

void NxPhysicsSDK_doxybind::releaseTriangleMesh(NxTriangleMesh & mesh) 
{
    void (*func)(NxTriangleMesh & mesh) = (void (*)(NxTriangleMesh & mesh))(functionPointers[NxPhysicsSDK_doxybind::getPointerStart() + 8]);
     func(mesh);
}

NxU32 NxPhysicsSDK_doxybind::getNbTriangleMeshes() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxPhysicsSDK_doxybind::getPointerStart() + 9]);
    return func();
}

NxHeightField * NxPhysicsSDK_doxybind::createHeightField(const NxHeightFieldDesc & desc) 
{
    NxHeightField * (*func)(const NxHeightFieldDesc & desc) = (NxHeightField * (*)(const NxHeightFieldDesc & desc))(functionPointers[NxPhysicsSDK_doxybind::getPointerStart() + 10]);
    return func(desc);
}

void NxPhysicsSDK_doxybind::releaseHeightField(NxHeightField & heightField) 
{
    void (*func)(NxHeightField & heightField) = (void (*)(NxHeightField & heightField))(functionPointers[NxPhysicsSDK_doxybind::getPointerStart() + 11]);
     func(heightField);
}

NxU32 NxPhysicsSDK_doxybind::getNbHeightFields() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxPhysicsSDK_doxybind::getPointerStart() + 12]);
    return func();
}

NxCCDSkeleton * NxPhysicsSDK_doxybind::createCCDSkeleton(const NxSimpleTriangleMesh & mesh) 
{
    NxCCDSkeleton * (*func)(const NxSimpleTriangleMesh & mesh) = (NxCCDSkeleton * (*)(const NxSimpleTriangleMesh & mesh))(functionPointers[NxPhysicsSDK_doxybind::getPointerStart() + 13]);
    return func(mesh);
}

NxCCDSkeleton * NxPhysicsSDK_doxybind::createCCDSkeleton(const void * memoryBuffer, NxU32 bufferSize) 
{
    NxCCDSkeleton * (*func)(const void * memoryBuffer, NxU32 bufferSize) = (NxCCDSkeleton * (*)(const void * memoryBuffer, NxU32 bufferSize))(functionPointers[NxPhysicsSDK_doxybind::getPointerStart() + 14]);
    return func(memoryBuffer, bufferSize);
}

void NxPhysicsSDK_doxybind::releaseCCDSkeleton(NxCCDSkeleton & skel) 
{
    void (*func)(NxCCDSkeleton & skel) = (void (*)(NxCCDSkeleton & skel))(functionPointers[NxPhysicsSDK_doxybind::getPointerStart() + 15]);
     func(skel);
}

NxU32 NxPhysicsSDK_doxybind::getNbCCDSkeletons() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxPhysicsSDK_doxybind::getPointerStart() + 16]);
    return func();
}

NxConvexMesh * NxPhysicsSDK_doxybind::createConvexMesh(const NxStream & mesh) 
{
    NxConvexMesh * (*func)(const NxStream & mesh) = (NxConvexMesh * (*)(const NxStream & mesh))(functionPointers[NxPhysicsSDK_doxybind::getPointerStart() + 17]);
    return func(mesh);
}

void NxPhysicsSDK_doxybind::releaseConvexMesh(NxConvexMesh & mesh) 
{
    void (*func)(NxConvexMesh & mesh) = (void (*)(NxConvexMesh & mesh))(functionPointers[NxPhysicsSDK_doxybind::getPointerStart() + 18]);
     func(mesh);
}

NxU32 NxPhysicsSDK_doxybind::getNbConvexMeshes() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxPhysicsSDK_doxybind::getPointerStart() + 19]);
    return func();
}

NxClothMesh * NxPhysicsSDK_doxybind::createClothMesh(NxStream & stream) 
{
    NxClothMesh * (*func)(NxStream & stream) = (NxClothMesh * (*)(NxStream & stream))(functionPointers[NxPhysicsSDK_doxybind::getPointerStart() + 20]);
    return func(stream);
}

void NxPhysicsSDK_doxybind::releaseClothMesh(NxClothMesh & cloth) 
{
    void (*func)(NxClothMesh & cloth) = (void (*)(NxClothMesh & cloth))(functionPointers[NxPhysicsSDK_doxybind::getPointerStart() + 21]);
     func(cloth);
}

NxU32 NxPhysicsSDK_doxybind::getNbClothMeshes() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxPhysicsSDK_doxybind::getPointerStart() + 22]);
    return func();
}

NxClothMesh ** NxPhysicsSDK_doxybind::getClothMeshes() 
{
    NxClothMesh ** (*func)() = (NxClothMesh ** (*)())(functionPointers[NxPhysicsSDK_doxybind::getPointerStart() + 23]);
    return func();
}

NxSoftBodyMesh * NxPhysicsSDK_doxybind::createSoftBodyMesh(NxStream & stream) 
{
    NxSoftBodyMesh * (*func)(NxStream & stream) = (NxSoftBodyMesh * (*)(NxStream & stream))(functionPointers[NxPhysicsSDK_doxybind::getPointerStart() + 24]);
    return func(stream);
}

void NxPhysicsSDK_doxybind::releaseSoftBodyMesh(NxSoftBodyMesh & softBodyMesh) 
{
    void (*func)(NxSoftBodyMesh & softBodyMesh) = (void (*)(NxSoftBodyMesh & softBodyMesh))(functionPointers[NxPhysicsSDK_doxybind::getPointerStart() + 25]);
     func(softBodyMesh);
}

NxU32 NxPhysicsSDK_doxybind::getNbSoftBodyMeshes() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxPhysicsSDK_doxybind::getPointerStart() + 26]);
    return func();
}

NxSoftBodyMesh ** NxPhysicsSDK_doxybind::getSoftBodyMeshes() 
{
    NxSoftBodyMesh ** (*func)() = (NxSoftBodyMesh ** (*)())(functionPointers[NxPhysicsSDK_doxybind::getPointerStart() + 27]);
    return func();
}

NxU32 NxPhysicsSDK_doxybind::getInternalVersion(NxU32 & apiRev, NxU32 & descRev, NxU32 & branchId) const
{
    NxU32 (*func)(NxU32 & apiRev, NxU32 & descRev, NxU32 & branchId) = (NxU32 (*)(NxU32 & apiRev, NxU32 & descRev, NxU32 & branchId))(functionPointers[NxPhysicsSDK_doxybind::getPointerStart() + 28]);
    return func(apiRev, descRev, branchId);
}

NxInterface * NxPhysicsSDK_doxybind::getInterface(NxInterfaceType type, int versionNumber) 
{
    NxInterface * (*func)(NxInterfaceType type, int versionNumber) = (NxInterface * (*)(NxInterfaceType type, int versionNumber))(functionPointers[NxPhysicsSDK_doxybind::getPointerStart() + 29]);
    return func(type, versionNumber);
}

NxHWVersion NxPhysicsSDK_doxybind::getHWVersion() const
{
    NxHWVersion (*func)() = (NxHWVersion (*)())(functionPointers[NxPhysicsSDK_doxybind::getPointerStart() + 30]);
    return func();
}

NxU32 NxPhysicsSDK_doxybind::getNbPPUs() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxPhysicsSDK_doxybind::getPointerStart() + 31]);
    return func();
}

NxFoundationSDK & NxPhysicsSDK_doxybind::getFoundationSDK() const
{
    NxFoundationSDK & (*func)() = (NxFoundationSDK & (*)())(functionPointers[NxPhysicsSDK_doxybind::getPointerStart() + 32]);
    return func();
}

void NxPlaneShape_doxybind::setPlane(const NxVec3 & normal, NxReal d) 
{
    void (*func)(const NxVec3 & normal, NxReal d) = (void (*)(const NxVec3 & normal, NxReal d))(functionPointers[NxPlaneShape_doxybind::getPointerStart() + 0]);
     func(normal, d);
}

void NxPlaneShape_doxybind::saveToDesc(NxPlaneShapeDesc & desc) const
{
    void (*func)(NxPlaneShapeDesc & desc) = (void (*)(NxPlaneShapeDesc & desc))(functionPointers[NxPlaneShape_doxybind::getPointerStart() + 1]);
     func(desc);
}

NxPlane NxPlaneShape_doxybind::getPlane() const
{
    NxPlane (*func)() = (NxPlane (*)())(functionPointers[NxPlaneShape_doxybind::getPointerStart() + 2]);
    return func();
}

void NxPlaneShape_doxybind::setLocalPose(const NxMat34 & mat) 
{
    void (*func)(const NxMat34 & mat) = (void (*)(const NxMat34 & mat))(functionPointers[NxShape_doxybind::getPointerStart() + 0]);
     func(mat);
}

void NxPlaneShape_doxybind::setLocalPosition(const NxVec3 & vec) 
{
    void (*func)(const NxVec3 & vec) = (void (*)(const NxVec3 & vec))(functionPointers[NxShape_doxybind::getPointerStart() + 1]);
     func(vec);
}

void NxPlaneShape_doxybind::setLocalOrientation(const NxMat33 & mat) 
{
    void (*func)(const NxMat33 & mat) = (void (*)(const NxMat33 & mat))(functionPointers[NxShape_doxybind::getPointerStart() + 2]);
     func(mat);
}

NxMat34 NxPlaneShape_doxybind::getLocalPose() const
{
    NxMat34 (*func)() = (NxMat34 (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 3]);
    return func();
}

NxVec3 NxPlaneShape_doxybind::getLocalPosition() const
{
    NxVec3 (*func)() = (NxVec3 (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 4]);
    return func();
}

NxMat33 NxPlaneShape_doxybind::getLocalOrientation() const
{
    NxMat33 (*func)() = (NxMat33 (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 5]);
    return func();
}

void NxPlaneShape_doxybind::setGlobalPose(const NxMat34 & mat) 
{
    void (*func)(const NxMat34 & mat) = (void (*)(const NxMat34 & mat))(functionPointers[NxShape_doxybind::getPointerStart() + 6]);
     func(mat);
}

void NxPlaneShape_doxybind::setGlobalPosition(const NxVec3 & vec) 
{
    void (*func)(const NxVec3 & vec) = (void (*)(const NxVec3 & vec))(functionPointers[NxShape_doxybind::getPointerStart() + 7]);
     func(vec);
}

void NxPlaneShape_doxybind::setGlobalOrientation(const NxMat33 & mat) 
{
    void (*func)(const NxMat33 & mat) = (void (*)(const NxMat33 & mat))(functionPointers[NxShape_doxybind::getPointerStart() + 8]);
     func(mat);
}

NxMat34 NxPlaneShape_doxybind::getGlobalPose() const
{
    NxMat34 (*func)() = (NxMat34 (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 9]);
    return func();
}

NxVec3 NxPlaneShape_doxybind::getGlobalPosition() const
{
    NxVec3 (*func)() = (NxVec3 (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 10]);
    return func();
}

NxMat33 NxPlaneShape_doxybind::getGlobalOrientation() const
{
    NxMat33 (*func)() = (NxMat33 (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 11]);
    return func();
}

void * NxPlaneShape_doxybind::is(NxShapeType type) 
{
    void * (*func)(NxShapeType type) = (void * (*)(NxShapeType type))(functionPointers[NxShape_doxybind::getPointerStart() + 12]);
    return func(type);
}

const void * NxPlaneShape_doxybind::is(NxShapeType type) const
{
    const void * (*func)(NxShapeType type) = (const void * (*)(NxShapeType type))(functionPointers[NxShape_doxybind::getPointerStart() + 13]);
    return func(type);
}

bool NxPlaneShape_doxybind::raycast(const NxRay & worldRay, NxReal maxDist, NxU32 hintFlags, NxRaycastHit & hit, bool firstHit) const
{
    bool (*func)(const NxRay & worldRay, NxReal maxDist, NxU32 hintFlags, NxRaycastHit & hit, bool firstHit) = (bool (*)(const NxRay & worldRay, NxReal maxDist, NxU32 hintFlags, NxRaycastHit & hit, bool firstHit))(functionPointers[NxShape_doxybind::getPointerStart() + 14]);
    return func(worldRay, maxDist, hintFlags, hit, firstHit);
}

bool NxPlaneShape_doxybind::checkOverlapSphere(const NxSphere & worldSphere) const
{
    bool (*func)(const NxSphere & worldSphere) = (bool (*)(const NxSphere & worldSphere))(functionPointers[NxShape_doxybind::getPointerStart() + 15]);
    return func(worldSphere);
}

bool NxPlaneShape_doxybind::checkOverlapOBB(const NxBox & worldBox) const
{
    bool (*func)(const NxBox & worldBox) = (bool (*)(const NxBox & worldBox))(functionPointers[NxShape_doxybind::getPointerStart() + 16]);
    return func(worldBox);
}

bool NxPlaneShape_doxybind::checkOverlapAABB(const NxBounds3 & worldBounds) const
{
    bool (*func)(const NxBounds3 & worldBounds) = (bool (*)(const NxBounds3 & worldBounds))(functionPointers[NxShape_doxybind::getPointerStart() + 17]);
    return func(worldBounds);
}

bool NxPlaneShape_doxybind::checkOverlapCapsule(const NxCapsule & worldCapsule) const
{
    bool (*func)(const NxCapsule & worldCapsule) = (bool (*)(const NxCapsule & worldCapsule))(functionPointers[NxShape_doxybind::getPointerStart() + 18]);
    return func(worldCapsule);
}

NxActor & NxPlaneShape_doxybind::getActor() const
{
    NxActor & (*func)() = (NxActor & (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 19]);
    return func();
}

void NxPlaneShape_doxybind::setGroup(NxCollisionGroup collisionGroup) 
{
    void (*func)(NxCollisionGroup collisionGroup) = (void (*)(NxCollisionGroup collisionGroup))(functionPointers[NxShape_doxybind::getPointerStart() + 20]);
     func(collisionGroup);
}

NxCollisionGroup NxPlaneShape_doxybind::getGroup() const
{
    NxCollisionGroup (*func)() = (NxCollisionGroup (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 21]);
    return func();
}

void NxPlaneShape_doxybind::getWorldBounds(NxBounds3 & dest) const
{
    void (*func)(NxBounds3 & dest) = (void (*)(NxBounds3 & dest))(functionPointers[NxShape_doxybind::getPointerStart() + 22]);
     func(dest);
}

void NxPlaneShape_doxybind::setFlag(NxShapeFlag flag, bool value) 
{
    void (*func)(NxShapeFlag flag, bool value) = (void (*)(NxShapeFlag flag, bool value))(functionPointers[NxShape_doxybind::getPointerStart() + 23]);
     func(flag, value);
}

NX_BOOL NxPlaneShape_doxybind::getFlag(NxShapeFlag flag) const
{
    NX_BOOL (*func)(NxShapeFlag flag) = (NX_BOOL (*)(NxShapeFlag flag))(functionPointers[NxShape_doxybind::getPointerStart() + 24]);
    return func(flag);
}

void NxPlaneShape_doxybind::setMaterial(NxMaterialIndex matIndex) 
{
    void (*func)(NxMaterialIndex matIndex) = (void (*)(NxMaterialIndex matIndex))(functionPointers[NxShape_doxybind::getPointerStart() + 25]);
     func(matIndex);
}

NxMaterialIndex NxPlaneShape_doxybind::getMaterial() const
{
    NxMaterialIndex (*func)() = (NxMaterialIndex (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 26]);
    return func();
}

void NxPlaneShape_doxybind::setSkinWidth(NxReal skinWidth) 
{
    void (*func)(NxReal skinWidth) = (void (*)(NxReal skinWidth))(functionPointers[NxShape_doxybind::getPointerStart() + 27]);
     func(skinWidth);
}

NxReal NxPlaneShape_doxybind::getSkinWidth() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 28]);
    return func();
}

NxShapeType NxPlaneShape_doxybind::getType() const
{
    NxShapeType (*func)() = (NxShapeType (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 29]);
    return func();
}

void NxPlaneShape_doxybind::setCCDSkeleton(NxCCDSkeleton * ccdSkel) 
{
    void (*func)(NxCCDSkeleton * ccdSkel) = (void (*)(NxCCDSkeleton * ccdSkel))(functionPointers[NxShape_doxybind::getPointerStart() + 30]);
     func(ccdSkel);
}

NxCCDSkeleton * NxPlaneShape_doxybind::getCCDSkeleton() const
{
    NxCCDSkeleton * (*func)() = (NxCCDSkeleton * (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 31]);
    return func();
}

void NxPlaneShape_doxybind::setName(const char * name) 
{
    void (*func)(const char * name) = (void (*)(const char * name))(functionPointers[NxShape_doxybind::getPointerStart() + 32]);
     func(name);
}

const char * NxPlaneShape_doxybind::getName() const
{
    const char * (*func)() = (const char * (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 33]);
    return func();
}

void NxPlaneShape_doxybind::setGroupsMask(const NxGroupsMask & mask) 
{
    void (*func)(const NxGroupsMask & mask) = (void (*)(const NxGroupsMask & mask))(functionPointers[NxShape_doxybind::getPointerStart() + 34]);
     func(mask);
}

const NxGroupsMask NxPlaneShape_doxybind::getGroupsMask() const
{
    const NxGroupsMask (*func)() = (const NxGroupsMask (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 35]);
    return func();
}

NxU32 NxPlaneShape_doxybind::getNonInteractingCompartmentTypes() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 36]);
    return func();
}

void NxPlaneShape_doxybind::setNonInteractingCompartmentTypes(NxU32 compartmentTypes) 
{
    void (*func)(NxU32 compartmentTypes) = (void (*)(NxU32 compartmentTypes))(functionPointers[NxShape_doxybind::getPointerStart() + 37]);
     func(compartmentTypes);
}

NxPlaneShapeDesc_doxybind::NxPlaneShapeDesc_doxybind() : NxPlaneShapeDesc()
{
}

void NxPlaneShapeDesc_doxybind::setToDefault() 
{
    void (*func)() = (void (*)())(functionPointers[NxPlaneShapeDesc_doxybind::getPointerStart() + 0]);
     func();
}

bool NxPlaneShapeDesc_doxybind::isValid() const
{
    bool (*func)() = (bool (*)())(functionPointers[NxPlaneShapeDesc_doxybind::getPointerStart() + 1]);
    return func();
}

void NxPointInPlaneJoint_doxybind::loadFromDesc(const NxPointInPlaneJointDesc & desc) 
{
    void (*func)(const NxPointInPlaneJointDesc & desc) = (void (*)(const NxPointInPlaneJointDesc & desc))(functionPointers[NxPointInPlaneJoint_doxybind::getPointerStart() + 0]);
     func(desc);
}

void NxPointInPlaneJoint_doxybind::saveToDesc(NxPointInPlaneJointDesc & desc) 
{
    void (*func)(NxPointInPlaneJointDesc & desc) = (void (*)(NxPointInPlaneJointDesc & desc))(functionPointers[NxPointInPlaneJoint_doxybind::getPointerStart() + 1]);
     func(desc);
}

void NxPointInPlaneJoint_doxybind::setLimitPoint(const NxVec3 & point, bool pointIsOnActor2) 
{
    void (*func)(const NxVec3 & point, bool pointIsOnActor2) = (void (*)(const NxVec3 & point, bool pointIsOnActor2))(functionPointers[NxJoint_doxybind::getPointerStart() + 0]);
     func(point, pointIsOnActor2);
}

void NxPointInPlaneJoint_doxybind::setLimitPoint(const NxVec3 & point) 
{
    void (*func)(const NxVec3 & point) = (void (*)(const NxVec3 & point))(functionPointers[NxJoint_doxybind::getPointerStart() + 1]);
     func(point);
}

bool NxPointInPlaneJoint_doxybind::getLimitPoint(NxVec3 & worldLimitPoint) 
{
    bool (*func)(NxVec3 & worldLimitPoint) = (bool (*)(NxVec3 & worldLimitPoint))(functionPointers[NxJoint_doxybind::getPointerStart() + 2]);
    return func(worldLimitPoint);
}

bool NxPointInPlaneJoint_doxybind::addLimitPlane(const NxVec3 & normal, const NxVec3 & pointInPlane, NxReal restitution) 
{
    bool (*func)(const NxVec3 & normal, const NxVec3 & pointInPlane, NxReal restitution) = (bool (*)(const NxVec3 & normal, const NxVec3 & pointInPlane, NxReal restitution))(functionPointers[NxJoint_doxybind::getPointerStart() + 3]);
    return func(normal, pointInPlane, restitution);
}

bool NxPointInPlaneJoint_doxybind::addLimitPlane(const NxVec3 & normal, const NxVec3 & pointInPlane) 
{
    bool (*func)(const NxVec3 & normal, const NxVec3 & pointInPlane) = (bool (*)(const NxVec3 & normal, const NxVec3 & pointInPlane))(functionPointers[NxJoint_doxybind::getPointerStart() + 4]);
    return func(normal, pointInPlane);
}

void NxPointInPlaneJoint_doxybind::purgeLimitPlanes() 
{
    void (*func)() = (void (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 5]);
     func();
}

void NxPointInPlaneJoint_doxybind::resetLimitPlaneIterator() 
{
    void (*func)() = (void (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 6]);
     func();
}

bool NxPointInPlaneJoint_doxybind::hasMoreLimitPlanes() 
{
    bool (*func)() = (bool (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 7]);
    return func();
}

bool NxPointInPlaneJoint_doxybind::getNextLimitPlane(NxVec3 & planeNormal, NxReal & planeD, NxReal * restitution) 
{
    bool (*func)(NxVec3 & planeNormal, NxReal & planeD, NxReal * restitution) = (bool (*)(NxVec3 & planeNormal, NxReal & planeD, NxReal * restitution))(functionPointers[NxJoint_doxybind::getPointerStart() + 8]);
    return func(planeNormal, planeD, restitution);
}

bool NxPointInPlaneJoint_doxybind::getNextLimitPlane(NxVec3 & planeNormal, NxReal & planeD) 
{
    bool (*func)(NxVec3 & planeNormal, NxReal & planeD) = (bool (*)(NxVec3 & planeNormal, NxReal & planeD))(functionPointers[NxJoint_doxybind::getPointerStart() + 9]);
    return func(planeNormal, planeD);
}

void * NxPointInPlaneJoint_doxybind::is(NxJointType type) 
{
    void * (*func)(NxJointType type) = (void * (*)(NxJointType type))(functionPointers[NxJoint_doxybind::getPointerStart() + 10]);
    return func(type);
}

void NxPointInPlaneJoint_doxybind::getActors(NxActor ** actor1, NxActor ** actor2) 
{
    void (*func)(NxActor ** actor1, NxActor ** actor2) = (void (*)(NxActor ** actor1, NxActor ** actor2))(functionPointers[NxJoint_doxybind::getPointerStart() + 11]);
     func(actor1, actor2);
}

void NxPointInPlaneJoint_doxybind::setGlobalAnchor(const NxVec3 & vec) 
{
    void (*func)(const NxVec3 & vec) = (void (*)(const NxVec3 & vec))(functionPointers[NxJoint_doxybind::getPointerStart() + 12]);
     func(vec);
}

void NxPointInPlaneJoint_doxybind::setGlobalAxis(const NxVec3 & vec) 
{
    void (*func)(const NxVec3 & vec) = (void (*)(const NxVec3 & vec))(functionPointers[NxJoint_doxybind::getPointerStart() + 13]);
     func(vec);
}

NxVec3 NxPointInPlaneJoint_doxybind::getGlobalAnchor() const
{
    NxVec3 (*func)() = (NxVec3 (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 14]);
    return func();
}

NxVec3 NxPointInPlaneJoint_doxybind::getGlobalAxis() const
{
    NxVec3 (*func)() = (NxVec3 (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 15]);
    return func();
}

NxJointState NxPointInPlaneJoint_doxybind::getState() 
{
    NxJointState (*func)() = (NxJointState (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 16]);
    return func();
}

void NxPointInPlaneJoint_doxybind::setBreakable(NxReal maxForce, NxReal maxTorque) 
{
    void (*func)(NxReal maxForce, NxReal maxTorque) = (void (*)(NxReal maxForce, NxReal maxTorque))(functionPointers[NxJoint_doxybind::getPointerStart() + 17]);
     func(maxForce, maxTorque);
}

void NxPointInPlaneJoint_doxybind::getBreakable(NxReal & maxForce, NxReal & maxTorque) 
{
    void (*func)(NxReal & maxForce, NxReal & maxTorque) = (void (*)(NxReal & maxForce, NxReal & maxTorque))(functionPointers[NxJoint_doxybind::getPointerStart() + 18]);
     func(maxForce, maxTorque);
}

void NxPointInPlaneJoint_doxybind::setSolverExtrapolationFactor(NxReal solverExtrapolationFactor) 
{
    void (*func)(NxReal solverExtrapolationFactor) = (void (*)(NxReal solverExtrapolationFactor))(functionPointers[NxJoint_doxybind::getPointerStart() + 19]);
     func(solverExtrapolationFactor);
}

NxReal NxPointInPlaneJoint_doxybind::getSolverExtrapolationFactor() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 20]);
    return func();
}

void NxPointInPlaneJoint_doxybind::setUseAccelerationSpring(bool b) 
{
    void (*func)(bool b) = (void (*)(bool b))(functionPointers[NxJoint_doxybind::getPointerStart() + 21]);
     func(b);
}

bool NxPointInPlaneJoint_doxybind::getUseAccelerationSpring() const
{
    bool (*func)() = (bool (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 22]);
    return func();
}

NxJointType NxPointInPlaneJoint_doxybind::getType() const
{
    NxJointType (*func)() = (NxJointType (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 23]);
    return func();
}

void NxPointInPlaneJoint_doxybind::setName(const char * name) 
{
    void (*func)(const char * name) = (void (*)(const char * name))(functionPointers[NxJoint_doxybind::getPointerStart() + 24]);
     func(name);
}

const char * NxPointInPlaneJoint_doxybind::getName() const
{
    const char * (*func)() = (const char * (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 25]);
    return func();
}

NxScene & NxPointInPlaneJoint_doxybind::getScene() const
{
    NxScene & (*func)() = (NxScene & (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 26]);
    return func();
}

NxPointInPlaneJointDesc_doxybind::NxPointInPlaneJointDesc_doxybind() : NxPointInPlaneJointDesc()
{
}

void NxPointInPlaneJointDesc_doxybind::setToDefault() 
{
    void (*func)() = (void (*)())(functionPointers[NxPointInPlaneJointDesc_doxybind::getPointerStart() + 0]);
     func();
}

bool NxPointInPlaneJointDesc_doxybind::isValid() const
{
    bool (*func)() = (bool (*)())(functionPointers[NxPointInPlaneJointDesc_doxybind::getPointerStart() + 1]);
    return func();
}

void NxPointOnLineJoint_doxybind::loadFromDesc(const NxPointOnLineJointDesc & desc) 
{
    void (*func)(const NxPointOnLineJointDesc & desc) = (void (*)(const NxPointOnLineJointDesc & desc))(functionPointers[NxPointOnLineJoint_doxybind::getPointerStart() + 0]);
     func(desc);
}

void NxPointOnLineJoint_doxybind::saveToDesc(NxPointOnLineJointDesc & desc) 
{
    void (*func)(NxPointOnLineJointDesc & desc) = (void (*)(NxPointOnLineJointDesc & desc))(functionPointers[NxPointOnLineJoint_doxybind::getPointerStart() + 1]);
     func(desc);
}

void NxPointOnLineJoint_doxybind::setLimitPoint(const NxVec3 & point, bool pointIsOnActor2) 
{
    void (*func)(const NxVec3 & point, bool pointIsOnActor2) = (void (*)(const NxVec3 & point, bool pointIsOnActor2))(functionPointers[NxJoint_doxybind::getPointerStart() + 0]);
     func(point, pointIsOnActor2);
}

void NxPointOnLineJoint_doxybind::setLimitPoint(const NxVec3 & point) 
{
    void (*func)(const NxVec3 & point) = (void (*)(const NxVec3 & point))(functionPointers[NxJoint_doxybind::getPointerStart() + 1]);
     func(point);
}

bool NxPointOnLineJoint_doxybind::getLimitPoint(NxVec3 & worldLimitPoint) 
{
    bool (*func)(NxVec3 & worldLimitPoint) = (bool (*)(NxVec3 & worldLimitPoint))(functionPointers[NxJoint_doxybind::getPointerStart() + 2]);
    return func(worldLimitPoint);
}

bool NxPointOnLineJoint_doxybind::addLimitPlane(const NxVec3 & normal, const NxVec3 & pointInPlane, NxReal restitution) 
{
    bool (*func)(const NxVec3 & normal, const NxVec3 & pointInPlane, NxReal restitution) = (bool (*)(const NxVec3 & normal, const NxVec3 & pointInPlane, NxReal restitution))(functionPointers[NxJoint_doxybind::getPointerStart() + 3]);
    return func(normal, pointInPlane, restitution);
}

bool NxPointOnLineJoint_doxybind::addLimitPlane(const NxVec3 & normal, const NxVec3 & pointInPlane) 
{
    bool (*func)(const NxVec3 & normal, const NxVec3 & pointInPlane) = (bool (*)(const NxVec3 & normal, const NxVec3 & pointInPlane))(functionPointers[NxJoint_doxybind::getPointerStart() + 4]);
    return func(normal, pointInPlane);
}

void NxPointOnLineJoint_doxybind::purgeLimitPlanes() 
{
    void (*func)() = (void (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 5]);
     func();
}

void NxPointOnLineJoint_doxybind::resetLimitPlaneIterator() 
{
    void (*func)() = (void (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 6]);
     func();
}

bool NxPointOnLineJoint_doxybind::hasMoreLimitPlanes() 
{
    bool (*func)() = (bool (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 7]);
    return func();
}

bool NxPointOnLineJoint_doxybind::getNextLimitPlane(NxVec3 & planeNormal, NxReal & planeD, NxReal * restitution) 
{
    bool (*func)(NxVec3 & planeNormal, NxReal & planeD, NxReal * restitution) = (bool (*)(NxVec3 & planeNormal, NxReal & planeD, NxReal * restitution))(functionPointers[NxJoint_doxybind::getPointerStart() + 8]);
    return func(planeNormal, planeD, restitution);
}

bool NxPointOnLineJoint_doxybind::getNextLimitPlane(NxVec3 & planeNormal, NxReal & planeD) 
{
    bool (*func)(NxVec3 & planeNormal, NxReal & planeD) = (bool (*)(NxVec3 & planeNormal, NxReal & planeD))(functionPointers[NxJoint_doxybind::getPointerStart() + 9]);
    return func(planeNormal, planeD);
}

void * NxPointOnLineJoint_doxybind::is(NxJointType type) 
{
    void * (*func)(NxJointType type) = (void * (*)(NxJointType type))(functionPointers[NxJoint_doxybind::getPointerStart() + 10]);
    return func(type);
}

void NxPointOnLineJoint_doxybind::getActors(NxActor ** actor1, NxActor ** actor2) 
{
    void (*func)(NxActor ** actor1, NxActor ** actor2) = (void (*)(NxActor ** actor1, NxActor ** actor2))(functionPointers[NxJoint_doxybind::getPointerStart() + 11]);
     func(actor1, actor2);
}

void NxPointOnLineJoint_doxybind::setGlobalAnchor(const NxVec3 & vec) 
{
    void (*func)(const NxVec3 & vec) = (void (*)(const NxVec3 & vec))(functionPointers[NxJoint_doxybind::getPointerStart() + 12]);
     func(vec);
}

void NxPointOnLineJoint_doxybind::setGlobalAxis(const NxVec3 & vec) 
{
    void (*func)(const NxVec3 & vec) = (void (*)(const NxVec3 & vec))(functionPointers[NxJoint_doxybind::getPointerStart() + 13]);
     func(vec);
}

NxVec3 NxPointOnLineJoint_doxybind::getGlobalAnchor() const
{
    NxVec3 (*func)() = (NxVec3 (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 14]);
    return func();
}

NxVec3 NxPointOnLineJoint_doxybind::getGlobalAxis() const
{
    NxVec3 (*func)() = (NxVec3 (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 15]);
    return func();
}

NxJointState NxPointOnLineJoint_doxybind::getState() 
{
    NxJointState (*func)() = (NxJointState (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 16]);
    return func();
}

void NxPointOnLineJoint_doxybind::setBreakable(NxReal maxForce, NxReal maxTorque) 
{
    void (*func)(NxReal maxForce, NxReal maxTorque) = (void (*)(NxReal maxForce, NxReal maxTorque))(functionPointers[NxJoint_doxybind::getPointerStart() + 17]);
     func(maxForce, maxTorque);
}

void NxPointOnLineJoint_doxybind::getBreakable(NxReal & maxForce, NxReal & maxTorque) 
{
    void (*func)(NxReal & maxForce, NxReal & maxTorque) = (void (*)(NxReal & maxForce, NxReal & maxTorque))(functionPointers[NxJoint_doxybind::getPointerStart() + 18]);
     func(maxForce, maxTorque);
}

void NxPointOnLineJoint_doxybind::setSolverExtrapolationFactor(NxReal solverExtrapolationFactor) 
{
    void (*func)(NxReal solverExtrapolationFactor) = (void (*)(NxReal solverExtrapolationFactor))(functionPointers[NxJoint_doxybind::getPointerStart() + 19]);
     func(solverExtrapolationFactor);
}

NxReal NxPointOnLineJoint_doxybind::getSolverExtrapolationFactor() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 20]);
    return func();
}

void NxPointOnLineJoint_doxybind::setUseAccelerationSpring(bool b) 
{
    void (*func)(bool b) = (void (*)(bool b))(functionPointers[NxJoint_doxybind::getPointerStart() + 21]);
     func(b);
}

bool NxPointOnLineJoint_doxybind::getUseAccelerationSpring() const
{
    bool (*func)() = (bool (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 22]);
    return func();
}

NxJointType NxPointOnLineJoint_doxybind::getType() const
{
    NxJointType (*func)() = (NxJointType (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 23]);
    return func();
}

void NxPointOnLineJoint_doxybind::setName(const char * name) 
{
    void (*func)(const char * name) = (void (*)(const char * name))(functionPointers[NxJoint_doxybind::getPointerStart() + 24]);
     func(name);
}

const char * NxPointOnLineJoint_doxybind::getName() const
{
    const char * (*func)() = (const char * (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 25]);
    return func();
}

NxScene & NxPointOnLineJoint_doxybind::getScene() const
{
    NxScene & (*func)() = (NxScene & (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 26]);
    return func();
}

NxPointOnLineJointDesc_doxybind::NxPointOnLineJointDesc_doxybind() : NxPointOnLineJointDesc()
{
}

void NxPointOnLineJointDesc_doxybind::setToDefault() 
{
    void (*func)() = (void (*)())(functionPointers[NxPointOnLineJointDesc_doxybind::getPointerStart() + 0]);
     func();
}

bool NxPointOnLineJointDesc_doxybind::isValid() const
{
    bool (*func)() = (bool (*)())(functionPointers[NxPointOnLineJointDesc_doxybind::getPointerStart() + 1]);
    return func();
}

void NxPrismaticJoint_doxybind::loadFromDesc(const NxPrismaticJointDesc & desc) 
{
    void (*func)(const NxPrismaticJointDesc & desc) = (void (*)(const NxPrismaticJointDesc & desc))(functionPointers[NxPrismaticJoint_doxybind::getPointerStart() + 0]);
     func(desc);
}

void NxPrismaticJoint_doxybind::saveToDesc(NxPrismaticJointDesc & desc) 
{
    void (*func)(NxPrismaticJointDesc & desc) = (void (*)(NxPrismaticJointDesc & desc))(functionPointers[NxPrismaticJoint_doxybind::getPointerStart() + 1]);
     func(desc);
}

void NxPrismaticJoint_doxybind::setLimitPoint(const NxVec3 & point, bool pointIsOnActor2) 
{
    void (*func)(const NxVec3 & point, bool pointIsOnActor2) = (void (*)(const NxVec3 & point, bool pointIsOnActor2))(functionPointers[NxJoint_doxybind::getPointerStart() + 0]);
     func(point, pointIsOnActor2);
}

void NxPrismaticJoint_doxybind::setLimitPoint(const NxVec3 & point) 
{
    void (*func)(const NxVec3 & point) = (void (*)(const NxVec3 & point))(functionPointers[NxJoint_doxybind::getPointerStart() + 1]);
     func(point);
}

bool NxPrismaticJoint_doxybind::getLimitPoint(NxVec3 & worldLimitPoint) 
{
    bool (*func)(NxVec3 & worldLimitPoint) = (bool (*)(NxVec3 & worldLimitPoint))(functionPointers[NxJoint_doxybind::getPointerStart() + 2]);
    return func(worldLimitPoint);
}

bool NxPrismaticJoint_doxybind::addLimitPlane(const NxVec3 & normal, const NxVec3 & pointInPlane, NxReal restitution) 
{
    bool (*func)(const NxVec3 & normal, const NxVec3 & pointInPlane, NxReal restitution) = (bool (*)(const NxVec3 & normal, const NxVec3 & pointInPlane, NxReal restitution))(functionPointers[NxJoint_doxybind::getPointerStart() + 3]);
    return func(normal, pointInPlane, restitution);
}

bool NxPrismaticJoint_doxybind::addLimitPlane(const NxVec3 & normal, const NxVec3 & pointInPlane) 
{
    bool (*func)(const NxVec3 & normal, const NxVec3 & pointInPlane) = (bool (*)(const NxVec3 & normal, const NxVec3 & pointInPlane))(functionPointers[NxJoint_doxybind::getPointerStart() + 4]);
    return func(normal, pointInPlane);
}

void NxPrismaticJoint_doxybind::purgeLimitPlanes() 
{
    void (*func)() = (void (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 5]);
     func();
}

void NxPrismaticJoint_doxybind::resetLimitPlaneIterator() 
{
    void (*func)() = (void (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 6]);
     func();
}

bool NxPrismaticJoint_doxybind::hasMoreLimitPlanes() 
{
    bool (*func)() = (bool (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 7]);
    return func();
}

bool NxPrismaticJoint_doxybind::getNextLimitPlane(NxVec3 & planeNormal, NxReal & planeD, NxReal * restitution) 
{
    bool (*func)(NxVec3 & planeNormal, NxReal & planeD, NxReal * restitution) = (bool (*)(NxVec3 & planeNormal, NxReal & planeD, NxReal * restitution))(functionPointers[NxJoint_doxybind::getPointerStart() + 8]);
    return func(planeNormal, planeD, restitution);
}

bool NxPrismaticJoint_doxybind::getNextLimitPlane(NxVec3 & planeNormal, NxReal & planeD) 
{
    bool (*func)(NxVec3 & planeNormal, NxReal & planeD) = (bool (*)(NxVec3 & planeNormal, NxReal & planeD))(functionPointers[NxJoint_doxybind::getPointerStart() + 9]);
    return func(planeNormal, planeD);
}

void * NxPrismaticJoint_doxybind::is(NxJointType type) 
{
    void * (*func)(NxJointType type) = (void * (*)(NxJointType type))(functionPointers[NxJoint_doxybind::getPointerStart() + 10]);
    return func(type);
}

void NxPrismaticJoint_doxybind::getActors(NxActor ** actor1, NxActor ** actor2) 
{
    void (*func)(NxActor ** actor1, NxActor ** actor2) = (void (*)(NxActor ** actor1, NxActor ** actor2))(functionPointers[NxJoint_doxybind::getPointerStart() + 11]);
     func(actor1, actor2);
}

void NxPrismaticJoint_doxybind::setGlobalAnchor(const NxVec3 & vec) 
{
    void (*func)(const NxVec3 & vec) = (void (*)(const NxVec3 & vec))(functionPointers[NxJoint_doxybind::getPointerStart() + 12]);
     func(vec);
}

void NxPrismaticJoint_doxybind::setGlobalAxis(const NxVec3 & vec) 
{
    void (*func)(const NxVec3 & vec) = (void (*)(const NxVec3 & vec))(functionPointers[NxJoint_doxybind::getPointerStart() + 13]);
     func(vec);
}

NxVec3 NxPrismaticJoint_doxybind::getGlobalAnchor() const
{
    NxVec3 (*func)() = (NxVec3 (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 14]);
    return func();
}

NxVec3 NxPrismaticJoint_doxybind::getGlobalAxis() const
{
    NxVec3 (*func)() = (NxVec3 (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 15]);
    return func();
}

NxJointState NxPrismaticJoint_doxybind::getState() 
{
    NxJointState (*func)() = (NxJointState (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 16]);
    return func();
}

void NxPrismaticJoint_doxybind::setBreakable(NxReal maxForce, NxReal maxTorque) 
{
    void (*func)(NxReal maxForce, NxReal maxTorque) = (void (*)(NxReal maxForce, NxReal maxTorque))(functionPointers[NxJoint_doxybind::getPointerStart() + 17]);
     func(maxForce, maxTorque);
}

void NxPrismaticJoint_doxybind::getBreakable(NxReal & maxForce, NxReal & maxTorque) 
{
    void (*func)(NxReal & maxForce, NxReal & maxTorque) = (void (*)(NxReal & maxForce, NxReal & maxTorque))(functionPointers[NxJoint_doxybind::getPointerStart() + 18]);
     func(maxForce, maxTorque);
}

void NxPrismaticJoint_doxybind::setSolverExtrapolationFactor(NxReal solverExtrapolationFactor) 
{
    void (*func)(NxReal solverExtrapolationFactor) = (void (*)(NxReal solverExtrapolationFactor))(functionPointers[NxJoint_doxybind::getPointerStart() + 19]);
     func(solverExtrapolationFactor);
}

NxReal NxPrismaticJoint_doxybind::getSolverExtrapolationFactor() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 20]);
    return func();
}

void NxPrismaticJoint_doxybind::setUseAccelerationSpring(bool b) 
{
    void (*func)(bool b) = (void (*)(bool b))(functionPointers[NxJoint_doxybind::getPointerStart() + 21]);
     func(b);
}

bool NxPrismaticJoint_doxybind::getUseAccelerationSpring() const
{
    bool (*func)() = (bool (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 22]);
    return func();
}

NxJointType NxPrismaticJoint_doxybind::getType() const
{
    NxJointType (*func)() = (NxJointType (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 23]);
    return func();
}

void NxPrismaticJoint_doxybind::setName(const char * name) 
{
    void (*func)(const char * name) = (void (*)(const char * name))(functionPointers[NxJoint_doxybind::getPointerStart() + 24]);
     func(name);
}

const char * NxPrismaticJoint_doxybind::getName() const
{
    const char * (*func)() = (const char * (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 25]);
    return func();
}

NxScene & NxPrismaticJoint_doxybind::getScene() const
{
    NxScene & (*func)() = (NxScene & (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 26]);
    return func();
}

NxPrismaticJointDesc_doxybind::NxPrismaticJointDesc_doxybind() : NxPrismaticJointDesc()
{
}

void NxPrismaticJointDesc_doxybind::setToDefault() 
{
    void (*func)() = (void (*)())(functionPointers[NxPrismaticJointDesc_doxybind::getPointerStart() + 0]);
     func();
}

bool NxPrismaticJointDesc_doxybind::isValid() const
{
    bool (*func)() = (bool (*)())(functionPointers[NxPrismaticJointDesc_doxybind::getPointerStart() + 1]);
    return func();
}

NxProfileData_doxybind::NxProfileData_doxybind() : NxProfileData()
{
}

const NxProfileZone * NxProfileData_doxybind::getNamedZone(NxProfileZoneName unknown93) const
{
    const NxProfileZone * (*func)(NxProfileZoneName unknown93) = (const NxProfileZone * (*)(NxProfileZoneName unknown93))(functionPointers[NxProfileData_doxybind::getPointerStart() + 0]);
    return func(unknown93);
}

void NxPulleyJoint_doxybind::loadFromDesc(const NxPulleyJointDesc & desc) 
{
    void (*func)(const NxPulleyJointDesc & desc) = (void (*)(const NxPulleyJointDesc & desc))(functionPointers[NxPulleyJoint_doxybind::getPointerStart() + 0]);
     func(desc);
}

void NxPulleyJoint_doxybind::saveToDesc(NxPulleyJointDesc & desc) 
{
    void (*func)(NxPulleyJointDesc & desc) = (void (*)(NxPulleyJointDesc & desc))(functionPointers[NxPulleyJoint_doxybind::getPointerStart() + 1]);
     func(desc);
}

void NxPulleyJoint_doxybind::setMotor(const NxMotorDesc & motorDesc) 
{
    void (*func)(const NxMotorDesc & motorDesc) = (void (*)(const NxMotorDesc & motorDesc))(functionPointers[NxPulleyJoint_doxybind::getPointerStart() + 2]);
     func(motorDesc);
}

bool NxPulleyJoint_doxybind::getMotor(NxMotorDesc & motorDesc) 
{
    bool (*func)(NxMotorDesc & motorDesc) = (bool (*)(NxMotorDesc & motorDesc))(functionPointers[NxPulleyJoint_doxybind::getPointerStart() + 3]);
    return func(motorDesc);
}

void NxPulleyJoint_doxybind::setFlags(NxU32 flags) 
{
    void (*func)(NxU32 flags) = (void (*)(NxU32 flags))(functionPointers[NxPulleyJoint_doxybind::getPointerStart() + 4]);
     func(flags);
}

NxU32 NxPulleyJoint_doxybind::getFlags() 
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxPulleyJoint_doxybind::getPointerStart() + 5]);
    return func();
}

void NxPulleyJoint_doxybind::setLimitPoint(const NxVec3 & point, bool pointIsOnActor2) 
{
    void (*func)(const NxVec3 & point, bool pointIsOnActor2) = (void (*)(const NxVec3 & point, bool pointIsOnActor2))(functionPointers[NxJoint_doxybind::getPointerStart() + 0]);
     func(point, pointIsOnActor2);
}

void NxPulleyJoint_doxybind::setLimitPoint(const NxVec3 & point) 
{
    void (*func)(const NxVec3 & point) = (void (*)(const NxVec3 & point))(functionPointers[NxJoint_doxybind::getPointerStart() + 1]);
     func(point);
}

bool NxPulleyJoint_doxybind::getLimitPoint(NxVec3 & worldLimitPoint) 
{
    bool (*func)(NxVec3 & worldLimitPoint) = (bool (*)(NxVec3 & worldLimitPoint))(functionPointers[NxJoint_doxybind::getPointerStart() + 2]);
    return func(worldLimitPoint);
}

bool NxPulleyJoint_doxybind::addLimitPlane(const NxVec3 & normal, const NxVec3 & pointInPlane, NxReal restitution) 
{
    bool (*func)(const NxVec3 & normal, const NxVec3 & pointInPlane, NxReal restitution) = (bool (*)(const NxVec3 & normal, const NxVec3 & pointInPlane, NxReal restitution))(functionPointers[NxJoint_doxybind::getPointerStart() + 3]);
    return func(normal, pointInPlane, restitution);
}

bool NxPulleyJoint_doxybind::addLimitPlane(const NxVec3 & normal, const NxVec3 & pointInPlane) 
{
    bool (*func)(const NxVec3 & normal, const NxVec3 & pointInPlane) = (bool (*)(const NxVec3 & normal, const NxVec3 & pointInPlane))(functionPointers[NxJoint_doxybind::getPointerStart() + 4]);
    return func(normal, pointInPlane);
}

void NxPulleyJoint_doxybind::purgeLimitPlanes() 
{
    void (*func)() = (void (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 5]);
     func();
}

void NxPulleyJoint_doxybind::resetLimitPlaneIterator() 
{
    void (*func)() = (void (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 6]);
     func();
}

bool NxPulleyJoint_doxybind::hasMoreLimitPlanes() 
{
    bool (*func)() = (bool (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 7]);
    return func();
}

bool NxPulleyJoint_doxybind::getNextLimitPlane(NxVec3 & planeNormal, NxReal & planeD, NxReal * restitution) 
{
    bool (*func)(NxVec3 & planeNormal, NxReal & planeD, NxReal * restitution) = (bool (*)(NxVec3 & planeNormal, NxReal & planeD, NxReal * restitution))(functionPointers[NxJoint_doxybind::getPointerStart() + 8]);
    return func(planeNormal, planeD, restitution);
}

bool NxPulleyJoint_doxybind::getNextLimitPlane(NxVec3 & planeNormal, NxReal & planeD) 
{
    bool (*func)(NxVec3 & planeNormal, NxReal & planeD) = (bool (*)(NxVec3 & planeNormal, NxReal & planeD))(functionPointers[NxJoint_doxybind::getPointerStart() + 9]);
    return func(planeNormal, planeD);
}

void * NxPulleyJoint_doxybind::is(NxJointType type) 
{
    void * (*func)(NxJointType type) = (void * (*)(NxJointType type))(functionPointers[NxJoint_doxybind::getPointerStart() + 10]);
    return func(type);
}

void NxPulleyJoint_doxybind::getActors(NxActor ** actor1, NxActor ** actor2) 
{
    void (*func)(NxActor ** actor1, NxActor ** actor2) = (void (*)(NxActor ** actor1, NxActor ** actor2))(functionPointers[NxJoint_doxybind::getPointerStart() + 11]);
     func(actor1, actor2);
}

void NxPulleyJoint_doxybind::setGlobalAnchor(const NxVec3 & vec) 
{
    void (*func)(const NxVec3 & vec) = (void (*)(const NxVec3 & vec))(functionPointers[NxJoint_doxybind::getPointerStart() + 12]);
     func(vec);
}

void NxPulleyJoint_doxybind::setGlobalAxis(const NxVec3 & vec) 
{
    void (*func)(const NxVec3 & vec) = (void (*)(const NxVec3 & vec))(functionPointers[NxJoint_doxybind::getPointerStart() + 13]);
     func(vec);
}

NxVec3 NxPulleyJoint_doxybind::getGlobalAnchor() const
{
    NxVec3 (*func)() = (NxVec3 (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 14]);
    return func();
}

NxVec3 NxPulleyJoint_doxybind::getGlobalAxis() const
{
    NxVec3 (*func)() = (NxVec3 (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 15]);
    return func();
}

NxJointState NxPulleyJoint_doxybind::getState() 
{
    NxJointState (*func)() = (NxJointState (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 16]);
    return func();
}

void NxPulleyJoint_doxybind::setBreakable(NxReal maxForce, NxReal maxTorque) 
{
    void (*func)(NxReal maxForce, NxReal maxTorque) = (void (*)(NxReal maxForce, NxReal maxTorque))(functionPointers[NxJoint_doxybind::getPointerStart() + 17]);
     func(maxForce, maxTorque);
}

void NxPulleyJoint_doxybind::getBreakable(NxReal & maxForce, NxReal & maxTorque) 
{
    void (*func)(NxReal & maxForce, NxReal & maxTorque) = (void (*)(NxReal & maxForce, NxReal & maxTorque))(functionPointers[NxJoint_doxybind::getPointerStart() + 18]);
     func(maxForce, maxTorque);
}

void NxPulleyJoint_doxybind::setSolverExtrapolationFactor(NxReal solverExtrapolationFactor) 
{
    void (*func)(NxReal solverExtrapolationFactor) = (void (*)(NxReal solverExtrapolationFactor))(functionPointers[NxJoint_doxybind::getPointerStart() + 19]);
     func(solverExtrapolationFactor);
}

NxReal NxPulleyJoint_doxybind::getSolverExtrapolationFactor() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 20]);
    return func();
}

void NxPulleyJoint_doxybind::setUseAccelerationSpring(bool b) 
{
    void (*func)(bool b) = (void (*)(bool b))(functionPointers[NxJoint_doxybind::getPointerStart() + 21]);
     func(b);
}

bool NxPulleyJoint_doxybind::getUseAccelerationSpring() const
{
    bool (*func)() = (bool (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 22]);
    return func();
}

NxJointType NxPulleyJoint_doxybind::getType() const
{
    NxJointType (*func)() = (NxJointType (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 23]);
    return func();
}

void NxPulleyJoint_doxybind::setName(const char * name) 
{
    void (*func)(const char * name) = (void (*)(const char * name))(functionPointers[NxJoint_doxybind::getPointerStart() + 24]);
     func(name);
}

const char * NxPulleyJoint_doxybind::getName() const
{
    const char * (*func)() = (const char * (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 25]);
    return func();
}

NxScene & NxPulleyJoint_doxybind::getScene() const
{
    NxScene & (*func)() = (NxScene & (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 26]);
    return func();
}

NxPulleyJointDesc_doxybind::NxPulleyJointDesc_doxybind() : NxPulleyJointDesc()
{
}

void NxPulleyJointDesc_doxybind::setToDefault() 
{
    void (*func)() = (void (*)())(functionPointers[NxPulleyJointDesc_doxybind::getPointerStart() + 0]);
     func();
}

bool NxPulleyJointDesc_doxybind::isValid() const
{
    bool (*func)() = (bool (*)())(functionPointers[NxPulleyJointDesc_doxybind::getPointerStart() + 1]);
    return func();
}

void NxRemoteDebugger_doxybind::connect(const char * host, unsigned int port, NxU32 eventMask) 
{
    void (*func)(const char * host, unsigned int port, NxU32 eventMask) = (void (*)(const char * host, unsigned int port, NxU32 eventMask))(functionPointers[NxRemoteDebugger_doxybind::getPointerStart() + 0]);
     func(host, port, eventMask);
}

void NxRemoteDebugger_doxybind::connect(const char * host, unsigned int port) 
{
    void (*func)(const char * host, unsigned int port) = (void (*)(const char * host, unsigned int port))(functionPointers[NxRemoteDebugger_doxybind::getPointerStart() + 1]);
     func(host, port);
}

void NxRemoteDebugger_doxybind::connect(const char * host) 
{
    void (*func)(const char * host) = (void (*)(const char * host))(functionPointers[NxRemoteDebugger_doxybind::getPointerStart() + 2]);
     func(host);
}

void NxRemoteDebugger_doxybind::disconnect() 
{
    void (*func)() = (void (*)())(functionPointers[NxRemoteDebugger_doxybind::getPointerStart() + 3]);
     func();
}

void NxRemoteDebugger_doxybind::flush() 
{
    void (*func)() = (void (*)())(functionPointers[NxRemoteDebugger_doxybind::getPointerStart() + 4]);
     func();
}

bool NxRemoteDebugger_doxybind::isConnected() 
{
    bool (*func)() = (bool (*)())(functionPointers[NxRemoteDebugger_doxybind::getPointerStart() + 5]);
    return func();
}

void NxRemoteDebugger_doxybind::frameBreak() 
{
    void (*func)() = (void (*)())(functionPointers[NxRemoteDebugger_doxybind::getPointerStart() + 6]);
     func();
}

void NxRemoteDebugger_doxybind::createObject(void * _object, NxRemoteDebuggerObjectType type, const char * className, NxU32 mask) 
{
    void (*func)(void * _object, NxRemoteDebuggerObjectType type, const char * className, NxU32 mask) = (void (*)(void * _object, NxRemoteDebuggerObjectType type, const char * className, NxU32 mask))(functionPointers[NxRemoteDebugger_doxybind::getPointerStart() + 7]);
     func(_object, type, className, mask);
}

void NxRemoteDebugger_doxybind::removeObject(void * _object, NxU32 mask) 
{
    void (*func)(void * _object, NxU32 mask) = (void (*)(void * _object, NxU32 mask))(functionPointers[NxRemoteDebugger_doxybind::getPointerStart() + 8]);
     func(_object, mask);
}

void NxRemoteDebugger_doxybind::addChild(void * _object, void * child, NxU32 mask) 
{
    void (*func)(void * _object, void * child, NxU32 mask) = (void (*)(void * _object, void * child, NxU32 mask))(functionPointers[NxRemoteDebugger_doxybind::getPointerStart() + 9]);
     func(_object, child, mask);
}

void NxRemoteDebugger_doxybind::removeChild(void * _object, void * child, NxU32 mask) 
{
    void (*func)(void * _object, void * child, NxU32 mask) = (void (*)(void * _object, void * child, NxU32 mask))(functionPointers[NxRemoteDebugger_doxybind::getPointerStart() + 10]);
     func(_object, child, mask);
}

void NxRemoteDebugger_doxybind::writeParameter(const NxReal & parameter, void * _object, bool create, const char * name, NxU32 mask) 
{
    void (*func)(const NxReal & parameter, void * _object, bool create, const char * name, NxU32 mask) = (void (*)(const NxReal & parameter, void * _object, bool create, const char * name, NxU32 mask))(functionPointers[NxRemoteDebugger_doxybind::getPointerStart() + 11]);
     func(parameter, _object, create, name, mask);
}

void NxRemoteDebugger_doxybind::writeParameter(const NxU32 & parameter, void * _object, bool create, const char * name, NxU32 mask) 
{
    void (*func)(const NxU32 & parameter, void * _object, bool create, const char * name, NxU32 mask) = (void (*)(const NxU32 & parameter, void * _object, bool create, const char * name, NxU32 mask))(functionPointers[NxRemoteDebugger_doxybind::getPointerStart() + 12]);
     func(parameter, _object, create, name, mask);
}

void NxRemoteDebugger_doxybind::writeParameter(const NxVec3 & parameter, void * _object, bool create, const char * name, NxU32 mask) 
{
    void (*func)(const NxVec3 & parameter, void * _object, bool create, const char * name, NxU32 mask) = (void (*)(const NxVec3 & parameter, void * _object, bool create, const char * name, NxU32 mask))(functionPointers[NxRemoteDebugger_doxybind::getPointerStart() + 13]);
     func(parameter, _object, create, name, mask);
}

void NxRemoteDebugger_doxybind::writeParameter(const NxPlane & parameter, void * _object, bool create, const char * name, NxU32 mask) 
{
    void (*func)(const NxPlane & parameter, void * _object, bool create, const char * name, NxU32 mask) = (void (*)(const NxPlane & parameter, void * _object, bool create, const char * name, NxU32 mask))(functionPointers[NxRemoteDebugger_doxybind::getPointerStart() + 14]);
     func(parameter, _object, create, name, mask);
}

void NxRemoteDebugger_doxybind::writeParameter(const NxMat34 & parameter, void * _object, bool create, const char * name, NxU32 mask) 
{
    void (*func)(const NxMat34 & parameter, void * _object, bool create, const char * name, NxU32 mask) = (void (*)(const NxMat34 & parameter, void * _object, bool create, const char * name, NxU32 mask))(functionPointers[NxRemoteDebugger_doxybind::getPointerStart() + 15]);
     func(parameter, _object, create, name, mask);
}

void NxRemoteDebugger_doxybind::writeParameter(const NxMat33 & parameter, void * _object, bool create, const char * name, NxU32 mask) 
{
    void (*func)(const NxMat33 & parameter, void * _object, bool create, const char * name, NxU32 mask) = (void (*)(const NxMat33 & parameter, void * _object, bool create, const char * name, NxU32 mask))(functionPointers[NxRemoteDebugger_doxybind::getPointerStart() + 16]);
     func(parameter, _object, create, name, mask);
}

void NxRemoteDebugger_doxybind::writeParameter(const NxU8 * parameter, void * _object, bool create, const char * name, NxU32 mask) 
{
    void (*func)(const NxU8 * parameter, void * _object, bool create, const char * name, NxU32 mask) = (void (*)(const NxU8 * parameter, void * _object, bool create, const char * name, NxU32 mask))(functionPointers[NxRemoteDebugger_doxybind::getPointerStart() + 17]);
     func(parameter, _object, create, name, mask);
}

void NxRemoteDebugger_doxybind::writeParameter(const char * parameter, void * _object, bool create, const char * name, NxU32 mask) 
{
    void (*func)(const char * parameter, void * _object, bool create, const char * name, NxU32 mask) = (void (*)(const char * parameter, void * _object, bool create, const char * name, NxU32 mask))(functionPointers[NxRemoteDebugger_doxybind::getPointerStart() + 18]);
     func(parameter, _object, create, name, mask);
}

void NxRemoteDebugger_doxybind::writeParameter(const bool & parameter, void * _object, bool create, const char * name, NxU32 mask) 
{
    void (*func)(const bool & parameter, void * _object, bool create, const char * name, NxU32 mask) = (void (*)(const bool & parameter, void * _object, bool create, const char * name, NxU32 mask))(functionPointers[NxRemoteDebugger_doxybind::getPointerStart() + 19]);
     func(parameter, _object, create, name, mask);
}

void NxRemoteDebugger_doxybind::writeParameter(const void * parameter, void * _object, bool create, const char * name, NxU32 mask) 
{
    void (*func)(const void * parameter, void * _object, bool create, const char * name, NxU32 mask) = (void (*)(const void * parameter, void * _object, bool create, const char * name, NxU32 mask))(functionPointers[NxRemoteDebugger_doxybind::getPointerStart() + 20]);
     func(parameter, _object, create, name, mask);
}

void NxRemoteDebugger_doxybind::setMask(NxU32 mask) 
{
    void (*func)(NxU32 mask) = (void (*)(NxU32 mask))(functionPointers[NxRemoteDebugger_doxybind::getPointerStart() + 21]);
     func(mask);
}

NxU32 NxRemoteDebugger_doxybind::getMask() 
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxRemoteDebugger_doxybind::getPointerStart() + 22]);
    return func();
}

void * NxRemoteDebugger_doxybind::getPickedObject() 
{
    void * (*func)() = (void * (*)())(functionPointers[NxRemoteDebugger_doxybind::getPointerStart() + 23]);
    return func();
}

NxVec3 NxRemoteDebugger_doxybind::getPickPoint() 
{
    NxVec3 (*func)() = (NxVec3 (*)())(functionPointers[NxRemoteDebugger_doxybind::getPointerStart() + 24]);
    return func();
}

void NxRemoteDebugger_doxybind::registerEventListener(NxRemoteDebuggerEventListener * eventListener) 
{
    void (*func)(NxRemoteDebuggerEventListener * eventListener) = (void (*)(NxRemoteDebuggerEventListener * eventListener))(functionPointers[NxRemoteDebugger_doxybind::getPointerStart() + 25]);
     func(eventListener);
}

void NxRemoteDebugger_doxybind::unregisterEventListener(NxRemoteDebuggerEventListener * eventListener) 
{
    void (*func)(NxRemoteDebuggerEventListener * eventListener) = (void (*)(NxRemoteDebuggerEventListener * eventListener))(functionPointers[NxRemoteDebugger_doxybind::getPointerStart() + 26]);
     func(eventListener);
}

void NxRemoteDebuggerEventListener_doxybind::onConnect() 
{
    void (*func)() = (void (*)())(functionPointers[NxRemoteDebuggerEventListener_doxybind::getPointerStart() + 0]);
     func();
}

void NxRemoteDebuggerEventListener_doxybind::onDisconnect() 
{
    void (*func)() = (void (*)())(functionPointers[NxRemoteDebuggerEventListener_doxybind::getPointerStart() + 1]);
     func();
}

void NxRemoteDebuggerEventListener_doxybind::beforeMaskChange(NxU32 oldMask, NxU32 newMask) 
{
    void (*func)(NxU32 oldMask, NxU32 newMask) = (void (*)(NxU32 oldMask, NxU32 newMask))(functionPointers[NxRemoteDebuggerEventListener_doxybind::getPointerStart() + 2]);
     func(oldMask, newMask);
}

void NxRemoteDebuggerEventListener_doxybind::afterMaskChange(NxU32 oldMask, NxU32 newMask) 
{
    void (*func)(NxU32 oldMask, NxU32 newMask) = (void (*)(NxU32 oldMask, NxU32 newMask))(functionPointers[NxRemoteDebuggerEventListener_doxybind::getPointerStart() + 3]);
     func(oldMask, newMask);
}

void NxRevoluteJoint_doxybind::loadFromDesc(const NxRevoluteJointDesc & desc) 
{
    void (*func)(const NxRevoluteJointDesc & desc) = (void (*)(const NxRevoluteJointDesc & desc))(functionPointers[NxRevoluteJoint_doxybind::getPointerStart() + 0]);
     func(desc);
}

void NxRevoluteJoint_doxybind::saveToDesc(NxRevoluteJointDesc & desc) 
{
    void (*func)(NxRevoluteJointDesc & desc) = (void (*)(NxRevoluteJointDesc & desc))(functionPointers[NxRevoluteJoint_doxybind::getPointerStart() + 1]);
     func(desc);
}

void NxRevoluteJoint_doxybind::setLimits(const NxJointLimitPairDesc & pair) 
{
    void (*func)(const NxJointLimitPairDesc & pair) = (void (*)(const NxJointLimitPairDesc & pair))(functionPointers[NxRevoluteJoint_doxybind::getPointerStart() + 2]);
     func(pair);
}

bool NxRevoluteJoint_doxybind::getLimits(NxJointLimitPairDesc & pair) 
{
    bool (*func)(NxJointLimitPairDesc & pair) = (bool (*)(NxJointLimitPairDesc & pair))(functionPointers[NxRevoluteJoint_doxybind::getPointerStart() + 3]);
    return func(pair);
}

void NxRevoluteJoint_doxybind::setMotor(const NxMotorDesc & motorDesc) 
{
    void (*func)(const NxMotorDesc & motorDesc) = (void (*)(const NxMotorDesc & motorDesc))(functionPointers[NxRevoluteJoint_doxybind::getPointerStart() + 4]);
     func(motorDesc);
}

bool NxRevoluteJoint_doxybind::getMotor(NxMotorDesc & motorDesc) 
{
    bool (*func)(NxMotorDesc & motorDesc) = (bool (*)(NxMotorDesc & motorDesc))(functionPointers[NxRevoluteJoint_doxybind::getPointerStart() + 5]);
    return func(motorDesc);
}

void NxRevoluteJoint_doxybind::setSpring(const NxSpringDesc & springDesc) 
{
    void (*func)(const NxSpringDesc & springDesc) = (void (*)(const NxSpringDesc & springDesc))(functionPointers[NxRevoluteJoint_doxybind::getPointerStart() + 6]);
     func(springDesc);
}

bool NxRevoluteJoint_doxybind::getSpring(NxSpringDesc & springDesc) 
{
    bool (*func)(NxSpringDesc & springDesc) = (bool (*)(NxSpringDesc & springDesc))(functionPointers[NxRevoluteJoint_doxybind::getPointerStart() + 7]);
    return func(springDesc);
}

NxReal NxRevoluteJoint_doxybind::getAngle() 
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxRevoluteJoint_doxybind::getPointerStart() + 8]);
    return func();
}

NxReal NxRevoluteJoint_doxybind::getVelocity() 
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxRevoluteJoint_doxybind::getPointerStart() + 9]);
    return func();
}

void NxRevoluteJoint_doxybind::setFlags(NxU32 flags) 
{
    void (*func)(NxU32 flags) = (void (*)(NxU32 flags))(functionPointers[NxRevoluteJoint_doxybind::getPointerStart() + 10]);
     func(flags);
}

NxU32 NxRevoluteJoint_doxybind::getFlags() 
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxRevoluteJoint_doxybind::getPointerStart() + 11]);
    return func();
}

void NxRevoluteJoint_doxybind::setProjectionMode(NxJointProjectionMode projectionMode) 
{
    void (*func)(NxJointProjectionMode projectionMode) = (void (*)(NxJointProjectionMode projectionMode))(functionPointers[NxRevoluteJoint_doxybind::getPointerStart() + 12]);
     func(projectionMode);
}

NxJointProjectionMode NxRevoluteJoint_doxybind::getProjectionMode() 
{
    NxJointProjectionMode (*func)() = (NxJointProjectionMode (*)())(functionPointers[NxRevoluteJoint_doxybind::getPointerStart() + 13]);
    return func();
}

void NxRevoluteJoint_doxybind::setLimitPoint(const NxVec3 & point, bool pointIsOnActor2) 
{
    void (*func)(const NxVec3 & point, bool pointIsOnActor2) = (void (*)(const NxVec3 & point, bool pointIsOnActor2))(functionPointers[NxJoint_doxybind::getPointerStart() + 0]);
     func(point, pointIsOnActor2);
}

void NxRevoluteJoint_doxybind::setLimitPoint(const NxVec3 & point) 
{
    void (*func)(const NxVec3 & point) = (void (*)(const NxVec3 & point))(functionPointers[NxJoint_doxybind::getPointerStart() + 1]);
     func(point);
}

bool NxRevoluteJoint_doxybind::getLimitPoint(NxVec3 & worldLimitPoint) 
{
    bool (*func)(NxVec3 & worldLimitPoint) = (bool (*)(NxVec3 & worldLimitPoint))(functionPointers[NxJoint_doxybind::getPointerStart() + 2]);
    return func(worldLimitPoint);
}

bool NxRevoluteJoint_doxybind::addLimitPlane(const NxVec3 & normal, const NxVec3 & pointInPlane, NxReal restitution) 
{
    bool (*func)(const NxVec3 & normal, const NxVec3 & pointInPlane, NxReal restitution) = (bool (*)(const NxVec3 & normal, const NxVec3 & pointInPlane, NxReal restitution))(functionPointers[NxJoint_doxybind::getPointerStart() + 3]);
    return func(normal, pointInPlane, restitution);
}

bool NxRevoluteJoint_doxybind::addLimitPlane(const NxVec3 & normal, const NxVec3 & pointInPlane) 
{
    bool (*func)(const NxVec3 & normal, const NxVec3 & pointInPlane) = (bool (*)(const NxVec3 & normal, const NxVec3 & pointInPlane))(functionPointers[NxJoint_doxybind::getPointerStart() + 4]);
    return func(normal, pointInPlane);
}

void NxRevoluteJoint_doxybind::purgeLimitPlanes() 
{
    void (*func)() = (void (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 5]);
     func();
}

void NxRevoluteJoint_doxybind::resetLimitPlaneIterator() 
{
    void (*func)() = (void (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 6]);
     func();
}

bool NxRevoluteJoint_doxybind::hasMoreLimitPlanes() 
{
    bool (*func)() = (bool (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 7]);
    return func();
}

bool NxRevoluteJoint_doxybind::getNextLimitPlane(NxVec3 & planeNormal, NxReal & planeD, NxReal * restitution) 
{
    bool (*func)(NxVec3 & planeNormal, NxReal & planeD, NxReal * restitution) = (bool (*)(NxVec3 & planeNormal, NxReal & planeD, NxReal * restitution))(functionPointers[NxJoint_doxybind::getPointerStart() + 8]);
    return func(planeNormal, planeD, restitution);
}

bool NxRevoluteJoint_doxybind::getNextLimitPlane(NxVec3 & planeNormal, NxReal & planeD) 
{
    bool (*func)(NxVec3 & planeNormal, NxReal & planeD) = (bool (*)(NxVec3 & planeNormal, NxReal & planeD))(functionPointers[NxJoint_doxybind::getPointerStart() + 9]);
    return func(planeNormal, planeD);
}

void * NxRevoluteJoint_doxybind::is(NxJointType type) 
{
    void * (*func)(NxJointType type) = (void * (*)(NxJointType type))(functionPointers[NxJoint_doxybind::getPointerStart() + 10]);
    return func(type);
}

void NxRevoluteJoint_doxybind::getActors(NxActor ** actor1, NxActor ** actor2) 
{
    void (*func)(NxActor ** actor1, NxActor ** actor2) = (void (*)(NxActor ** actor1, NxActor ** actor2))(functionPointers[NxJoint_doxybind::getPointerStart() + 11]);
     func(actor1, actor2);
}

void NxRevoluteJoint_doxybind::setGlobalAnchor(const NxVec3 & vec) 
{
    void (*func)(const NxVec3 & vec) = (void (*)(const NxVec3 & vec))(functionPointers[NxJoint_doxybind::getPointerStart() + 12]);
     func(vec);
}

void NxRevoluteJoint_doxybind::setGlobalAxis(const NxVec3 & vec) 
{
    void (*func)(const NxVec3 & vec) = (void (*)(const NxVec3 & vec))(functionPointers[NxJoint_doxybind::getPointerStart() + 13]);
     func(vec);
}

NxVec3 NxRevoluteJoint_doxybind::getGlobalAnchor() const
{
    NxVec3 (*func)() = (NxVec3 (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 14]);
    return func();
}

NxVec3 NxRevoluteJoint_doxybind::getGlobalAxis() const
{
    NxVec3 (*func)() = (NxVec3 (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 15]);
    return func();
}

NxJointState NxRevoluteJoint_doxybind::getState() 
{
    NxJointState (*func)() = (NxJointState (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 16]);
    return func();
}

void NxRevoluteJoint_doxybind::setBreakable(NxReal maxForce, NxReal maxTorque) 
{
    void (*func)(NxReal maxForce, NxReal maxTorque) = (void (*)(NxReal maxForce, NxReal maxTorque))(functionPointers[NxJoint_doxybind::getPointerStart() + 17]);
     func(maxForce, maxTorque);
}

void NxRevoluteJoint_doxybind::getBreakable(NxReal & maxForce, NxReal & maxTorque) 
{
    void (*func)(NxReal & maxForce, NxReal & maxTorque) = (void (*)(NxReal & maxForce, NxReal & maxTorque))(functionPointers[NxJoint_doxybind::getPointerStart() + 18]);
     func(maxForce, maxTorque);
}

void NxRevoluteJoint_doxybind::setSolverExtrapolationFactor(NxReal solverExtrapolationFactor) 
{
    void (*func)(NxReal solverExtrapolationFactor) = (void (*)(NxReal solverExtrapolationFactor))(functionPointers[NxJoint_doxybind::getPointerStart() + 19]);
     func(solverExtrapolationFactor);
}

NxReal NxRevoluteJoint_doxybind::getSolverExtrapolationFactor() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 20]);
    return func();
}

void NxRevoluteJoint_doxybind::setUseAccelerationSpring(bool b) 
{
    void (*func)(bool b) = (void (*)(bool b))(functionPointers[NxJoint_doxybind::getPointerStart() + 21]);
     func(b);
}

bool NxRevoluteJoint_doxybind::getUseAccelerationSpring() const
{
    bool (*func)() = (bool (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 22]);
    return func();
}

NxJointType NxRevoluteJoint_doxybind::getType() const
{
    NxJointType (*func)() = (NxJointType (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 23]);
    return func();
}

void NxRevoluteJoint_doxybind::setName(const char * name) 
{
    void (*func)(const char * name) = (void (*)(const char * name))(functionPointers[NxJoint_doxybind::getPointerStart() + 24]);
     func(name);
}

const char * NxRevoluteJoint_doxybind::getName() const
{
    const char * (*func)() = (const char * (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 25]);
    return func();
}

NxScene & NxRevoluteJoint_doxybind::getScene() const
{
    NxScene & (*func)() = (NxScene & (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 26]);
    return func();
}

NxRevoluteJointDesc_doxybind::NxRevoluteJointDesc_doxybind() : NxRevoluteJointDesc()
{
}

bool NxRevoluteJointDesc_doxybind::isValid() const
{
    bool (*func)() = (bool (*)())(functionPointers[NxRevoluteJointDesc_doxybind::getPointerStart() + 0]);
    return func();
}

void NxRevoluteJointDesc_doxybind::setToDefault() 
{
    void (*func)() = (void (*)())(functionPointers[NxJointDesc_doxybind::getPointerStart() + 0]);
     func();
}

NxActor * NxScene_doxybind::createActor(const NxActorDescBase & desc) 
{
    NxActor * (*func)(const NxActorDescBase & desc) = (NxActor * (*)(const NxActorDescBase & desc))(functionPointers[NxScene_doxybind::getPointerStart() + 0]);
    return func(desc);
}

void NxScene_doxybind::releaseActor(NxActor & actor) 
{
    void (*func)(NxActor & actor) = (void (*)(NxActor & actor))(functionPointers[NxScene_doxybind::getPointerStart() + 1]);
     func(actor);
}

NxJoint * NxScene_doxybind::createJoint(const NxJointDesc & jointDesc) 
{
    NxJoint * (*func)(const NxJointDesc & jointDesc) = (NxJoint * (*)(const NxJointDesc & jointDesc))(functionPointers[NxScene_doxybind::getPointerStart() + 2]);
    return func(jointDesc);
}

void NxScene_doxybind::releaseJoint(NxJoint & joint) 
{
    void (*func)(NxJoint & joint) = (void (*)(NxJoint & joint))(functionPointers[NxScene_doxybind::getPointerStart() + 3]);
     func(joint);
}

NxSpringAndDamperEffector * NxScene_doxybind::createSpringAndDamperEffector(const NxSpringAndDamperEffectorDesc & springDesc) 
{
    NxSpringAndDamperEffector * (*func)(const NxSpringAndDamperEffectorDesc & springDesc) = (NxSpringAndDamperEffector * (*)(const NxSpringAndDamperEffectorDesc & springDesc))(functionPointers[NxScene_doxybind::getPointerStart() + 4]);
    return func(springDesc);
}

NxEffector * NxScene_doxybind::createEffector(const NxEffectorDesc & desc) 
{
    NxEffector * (*func)(const NxEffectorDesc & desc) = (NxEffector * (*)(const NxEffectorDesc & desc))(functionPointers[NxScene_doxybind::getPointerStart() + 5]);
    return func(desc);
}

void NxScene_doxybind::releaseEffector(NxEffector & effector) 
{
    void (*func)(NxEffector & effector) = (void (*)(NxEffector & effector))(functionPointers[NxScene_doxybind::getPointerStart() + 6]);
     func(effector);
}

NxForceField * NxScene_doxybind::createForceField(const NxForceFieldDesc & forceFieldDesc) 
{
    NxForceField * (*func)(const NxForceFieldDesc & forceFieldDesc) = (NxForceField * (*)(const NxForceFieldDesc & forceFieldDesc))(functionPointers[NxScene_doxybind::getPointerStart() + 7]);
    return func(forceFieldDesc);
}

void NxScene_doxybind::releaseForceField(NxForceField & forceField) 
{
    void (*func)(NxForceField & forceField) = (void (*)(NxForceField & forceField))(functionPointers[NxScene_doxybind::getPointerStart() + 8]);
     func(forceField);
}

NxU32 NxScene_doxybind::getNbForceFields() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxScene_doxybind::getPointerStart() + 9]);
    return func();
}

NxForceField ** NxScene_doxybind::getForceFields() 
{
    NxForceField ** (*func)() = (NxForceField ** (*)())(functionPointers[NxScene_doxybind::getPointerStart() + 10]);
    return func();
}

NxForceFieldLinearKernel * NxScene_doxybind::createForceFieldLinearKernel(const NxForceFieldLinearKernelDesc & kernelDesc) 
{
    NxForceFieldLinearKernel * (*func)(const NxForceFieldLinearKernelDesc & kernelDesc) = (NxForceFieldLinearKernel * (*)(const NxForceFieldLinearKernelDesc & kernelDesc))(functionPointers[NxScene_doxybind::getPointerStart() + 11]);
    return func(kernelDesc);
}

void NxScene_doxybind::releaseForceFieldLinearKernel(NxForceFieldLinearKernel & kernel) 
{
    void (*func)(NxForceFieldLinearKernel & kernel) = (void (*)(NxForceFieldLinearKernel & kernel))(functionPointers[NxScene_doxybind::getPointerStart() + 12]);
     func(kernel);
}

NxU32 NxScene_doxybind::getNbForceFieldLinearKernels() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxScene_doxybind::getPointerStart() + 13]);
    return func();
}

void NxScene_doxybind::resetForceFieldLinearKernelsIterator() 
{
    void (*func)() = (void (*)())(functionPointers[NxScene_doxybind::getPointerStart() + 14]);
     func();
}

NxForceFieldLinearKernel * NxScene_doxybind::getNextForceFieldLinearKernel() 
{
    NxForceFieldLinearKernel * (*func)() = (NxForceFieldLinearKernel * (*)())(functionPointers[NxScene_doxybind::getPointerStart() + 15]);
    return func();
}

NxForceFieldShapeGroup * NxScene_doxybind::createForceFieldShapeGroup(const NxForceFieldShapeGroupDesc & desc) 
{
    NxForceFieldShapeGroup * (*func)(const NxForceFieldShapeGroupDesc & desc) = (NxForceFieldShapeGroup * (*)(const NxForceFieldShapeGroupDesc & desc))(functionPointers[NxScene_doxybind::getPointerStart() + 16]);
    return func(desc);
}

void NxScene_doxybind::releaseForceFieldShapeGroup(NxForceFieldShapeGroup & group) 
{
    void (*func)(NxForceFieldShapeGroup & group) = (void (*)(NxForceFieldShapeGroup & group))(functionPointers[NxScene_doxybind::getPointerStart() + 17]);
     func(group);
}

NxU32 NxScene_doxybind::getNbForceFieldShapeGroups() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxScene_doxybind::getPointerStart() + 18]);
    return func();
}

void NxScene_doxybind::resetForceFieldShapeGroupsIterator() 
{
    void (*func)() = (void (*)())(functionPointers[NxScene_doxybind::getPointerStart() + 19]);
     func();
}

NxForceFieldShapeGroup * NxScene_doxybind::getNextForceFieldShapeGroup() 
{
    NxForceFieldShapeGroup * (*func)() = (NxForceFieldShapeGroup * (*)())(functionPointers[NxScene_doxybind::getPointerStart() + 20]);
    return func();
}

NxForceFieldVariety NxScene_doxybind::createForceFieldVariety() 
{
    NxForceFieldVariety (*func)() = (NxForceFieldVariety (*)())(functionPointers[NxScene_doxybind::getPointerStart() + 21]);
    return func();
}

NxForceFieldVariety NxScene_doxybind::getHighestForceFieldVariety() const
{
    NxForceFieldVariety (*func)() = (NxForceFieldVariety (*)())(functionPointers[NxScene_doxybind::getPointerStart() + 22]);
    return func();
}

void NxScene_doxybind::releaseForceFieldVariety(NxForceFieldVariety var) 
{
    void (*func)(NxForceFieldVariety var) = (void (*)(NxForceFieldVariety var))(functionPointers[NxScene_doxybind::getPointerStart() + 23]);
     func(var);
}

NxForceFieldMaterial NxScene_doxybind::createForceFieldMaterial() 
{
    NxForceFieldMaterial (*func)() = (NxForceFieldMaterial (*)())(functionPointers[NxScene_doxybind::getPointerStart() + 24]);
    return func();
}

NxForceFieldMaterial NxScene_doxybind::getHighestForceFieldMaterial() const
{
    NxForceFieldMaterial (*func)() = (NxForceFieldMaterial (*)())(functionPointers[NxScene_doxybind::getPointerStart() + 25]);
    return func();
}

void NxScene_doxybind::releaseForceFieldMaterial(NxForceFieldMaterial mat) 
{
    void (*func)(NxForceFieldMaterial mat) = (void (*)(NxForceFieldMaterial mat))(functionPointers[NxScene_doxybind::getPointerStart() + 26]);
     func(mat);
}

NxReal NxScene_doxybind::getForceFieldScale(NxForceFieldVariety var, NxForceFieldMaterial mat) 
{
    NxReal (*func)(NxForceFieldVariety var, NxForceFieldMaterial mat) = (NxReal (*)(NxForceFieldVariety var, NxForceFieldMaterial mat))(functionPointers[NxScene_doxybind::getPointerStart() + 27]);
    return func(var, mat);
}

void NxScene_doxybind::setForceFieldScale(NxForceFieldVariety var, NxForceFieldMaterial mat, NxReal val) 
{
    void (*func)(NxForceFieldVariety var, NxForceFieldMaterial mat, NxReal val) = (void (*)(NxForceFieldVariety var, NxForceFieldMaterial mat, NxReal val))(functionPointers[NxScene_doxybind::getPointerStart() + 28]);
     func(var, mat, val);
}

NxMaterial * NxScene_doxybind::createMaterial(const NxMaterialDesc & matDesc) 
{
    NxMaterial * (*func)(const NxMaterialDesc & matDesc) = (NxMaterial * (*)(const NxMaterialDesc & matDesc))(functionPointers[NxScene_doxybind::getPointerStart() + 29]);
    return func(matDesc);
}

void NxScene_doxybind::releaseMaterial(NxMaterial & material) 
{
    void (*func)(NxMaterial & material) = (void (*)(NxMaterial & material))(functionPointers[NxScene_doxybind::getPointerStart() + 30]);
     func(material);
}

NxCompartment * NxScene_doxybind::createCompartment(const NxCompartmentDesc & compDesc) 
{
    NxCompartment * (*func)(const NxCompartmentDesc & compDesc) = (NxCompartment * (*)(const NxCompartmentDesc & compDesc))(functionPointers[NxScene_doxybind::getPointerStart() + 31]);
    return func(compDesc);
}

NxU32 NxScene_doxybind::getNbCompartments() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxScene_doxybind::getPointerStart() + 32]);
    return func();
}

NxU32 NxScene_doxybind::getCompartmentArray(NxCompartment ** userBuffer, NxU32 bufferSize, NxU32 & usersIterator) const
{
    NxU32 (*func)(NxCompartment ** userBuffer, NxU32 bufferSize, NxU32 & usersIterator) = (NxU32 (*)(NxCompartment ** userBuffer, NxU32 bufferSize, NxU32 & usersIterator))(functionPointers[NxScene_doxybind::getPointerStart() + 33]);
    return func(userBuffer, bufferSize, usersIterator);
}

void NxScene_doxybind::setActorPairFlags(NxActor & actorA, NxActor & actorB, NxU32 nxContactPairFlag) 
{
    void (*func)(NxActor & actorA, NxActor & actorB, NxU32 nxContactPairFlag) = (void (*)(NxActor & actorA, NxActor & actorB, NxU32 nxContactPairFlag))(functionPointers[NxScene_doxybind::getPointerStart() + 34]);
     func(actorA, actorB, nxContactPairFlag);
}

NxU32 NxScene_doxybind::getActorPairFlags(NxActor & actorA, NxActor & actorB) const
{
    NxU32 (*func)(NxActor & actorA, NxActor & actorB) = (NxU32 (*)(NxActor & actorA, NxActor & actorB))(functionPointers[NxScene_doxybind::getPointerStart() + 35]);
    return func(actorA, actorB);
}

void NxScene_doxybind::setShapePairFlags(NxShape & shapeA, NxShape & shapeB, NxU32 nxContactPairFlag) 
{
    void (*func)(NxShape & shapeA, NxShape & shapeB, NxU32 nxContactPairFlag) = (void (*)(NxShape & shapeA, NxShape & shapeB, NxU32 nxContactPairFlag))(functionPointers[NxScene_doxybind::getPointerStart() + 36]);
     func(shapeA, shapeB, nxContactPairFlag);
}

NxU32 NxScene_doxybind::getShapePairFlags(NxShape & shapeA, NxShape & shapeB) const
{
    NxU32 (*func)(NxShape & shapeA, NxShape & shapeB) = (NxU32 (*)(NxShape & shapeA, NxShape & shapeB))(functionPointers[NxScene_doxybind::getPointerStart() + 37]);
    return func(shapeA, shapeB);
}

NxU32 NxScene_doxybind::getNbPairs() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxScene_doxybind::getPointerStart() + 38]);
    return func();
}

NxU32 NxScene_doxybind::getPairFlagArray(NxPairFlag * userArray, NxU32 numPairs) const
{
    NxU32 (*func)(NxPairFlag * userArray, NxU32 numPairs) = (NxU32 (*)(NxPairFlag * userArray, NxU32 numPairs))(functionPointers[NxScene_doxybind::getPointerStart() + 39]);
    return func(userArray, numPairs);
}

void NxScene_doxybind::setGroupCollisionFlag(NxCollisionGroup group1, NxCollisionGroup group2, bool enable) 
{
    void (*func)(NxCollisionGroup group1, NxCollisionGroup group2, bool enable) = (void (*)(NxCollisionGroup group1, NxCollisionGroup group2, bool enable))(functionPointers[NxScene_doxybind::getPointerStart() + 40]);
     func(group1, group2, enable);
}

bool NxScene_doxybind::getGroupCollisionFlag(NxCollisionGroup group1, NxCollisionGroup group2) const
{
    bool (*func)(NxCollisionGroup group1, NxCollisionGroup group2) = (bool (*)(NxCollisionGroup group1, NxCollisionGroup group2))(functionPointers[NxScene_doxybind::getPointerStart() + 41]);
    return func(group1, group2);
}

void NxScene_doxybind::setDominanceGroupPair(NxDominanceGroup group1, NxDominanceGroup group2, NxConstraintDominance & dominance) 
{
    void (*func)(NxDominanceGroup group1, NxDominanceGroup group2, NxConstraintDominance & dominance) = (void (*)(NxDominanceGroup group1, NxDominanceGroup group2, NxConstraintDominance & dominance))(functionPointers[NxScene_doxybind::getPointerStart() + 42]);
     func(group1, group2, dominance);
}

NxConstraintDominance NxScene_doxybind::getDominanceGroupPair(NxDominanceGroup group1, NxDominanceGroup group2) const
{
    NxConstraintDominance (*func)(NxDominanceGroup group1, NxDominanceGroup group2) = (NxConstraintDominance (*)(NxDominanceGroup group1, NxDominanceGroup group2))(functionPointers[NxScene_doxybind::getPointerStart() + 43]);
    return func(group1, group2);
}

void NxScene_doxybind::setActorGroupPairFlags(NxActorGroup group1, NxActorGroup group2, NxU32 flags) 
{
    void (*func)(NxActorGroup group1, NxActorGroup group2, NxU32 flags) = (void (*)(NxActorGroup group1, NxActorGroup group2, NxU32 flags))(functionPointers[NxScene_doxybind::getPointerStart() + 44]);
     func(group1, group2, flags);
}

NxU32 NxScene_doxybind::getActorGroupPairFlags(NxActorGroup group1, NxActorGroup group2) const
{
    NxU32 (*func)(NxActorGroup group1, NxActorGroup group2) = (NxU32 (*)(NxActorGroup group1, NxActorGroup group2))(functionPointers[NxScene_doxybind::getPointerStart() + 45]);
    return func(group1, group2);
}

NxU32 NxScene_doxybind::getNbActorGroupPairs() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxScene_doxybind::getPointerStart() + 46]);
    return func();
}

NxU32 NxScene_doxybind::getActorGroupPairArray(NxActorGroupPair * userBuffer, NxU32 bufferSize, NxU32 & userIterator) const
{
    NxU32 (*func)(NxActorGroupPair * userBuffer, NxU32 bufferSize, NxU32 & userIterator) = (NxU32 (*)(NxActorGroupPair * userBuffer, NxU32 bufferSize, NxU32 & userIterator))(functionPointers[NxScene_doxybind::getPointerStart() + 47]);
    return func(userBuffer, bufferSize, userIterator);
}

void NxScene_doxybind::setFilterOps(NxFilterOp op0, NxFilterOp op1, NxFilterOp op2) 
{
    void (*func)(NxFilterOp op0, NxFilterOp op1, NxFilterOp op2) = (void (*)(NxFilterOp op0, NxFilterOp op1, NxFilterOp op2))(functionPointers[NxScene_doxybind::getPointerStart() + 48]);
     func(op0, op1, op2);
}

void NxScene_doxybind::setFilterBool(bool flag) 
{
    void (*func)(bool flag) = (void (*)(bool flag))(functionPointers[NxScene_doxybind::getPointerStart() + 49]);
     func(flag);
}

void NxScene_doxybind::setFilterConstant0(const NxGroupsMask & mask) 
{
    void (*func)(const NxGroupsMask & mask) = (void (*)(const NxGroupsMask & mask))(functionPointers[NxScene_doxybind::getPointerStart() + 50]);
     func(mask);
}

void NxScene_doxybind::setFilterConstant1(const NxGroupsMask & mask) 
{
    void (*func)(const NxGroupsMask & mask) = (void (*)(const NxGroupsMask & mask))(functionPointers[NxScene_doxybind::getPointerStart() + 51]);
     func(mask);
}

void NxScene_doxybind::getFilterOps(NxFilterOp & op0, NxFilterOp & op1, NxFilterOp & op2) const
{
    void (*func)(NxFilterOp & op0, NxFilterOp & op1, NxFilterOp & op2) = (void (*)(NxFilterOp & op0, NxFilterOp & op1, NxFilterOp & op2))(functionPointers[NxScene_doxybind::getPointerStart() + 52]);
     func(op0, op1, op2);
}

bool NxScene_doxybind::getFilterBool() const
{
    bool (*func)() = (bool (*)())(functionPointers[NxScene_doxybind::getPointerStart() + 53]);
    return func();
}

NxGroupsMask NxScene_doxybind::getFilterConstant0() const
{
    NxGroupsMask (*func)() = (NxGroupsMask (*)())(functionPointers[NxScene_doxybind::getPointerStart() + 54]);
    return func();
}

NxGroupsMask NxScene_doxybind::getFilterConstant1() const
{
    NxGroupsMask (*func)() = (NxGroupsMask (*)())(functionPointers[NxScene_doxybind::getPointerStart() + 55]);
    return func();
}

NxU32 NxScene_doxybind::getNbActors() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxScene_doxybind::getPointerStart() + 56]);
    return func();
}

NxActor ** NxScene_doxybind::getActors() 
{
    NxActor ** (*func)() = (NxActor ** (*)())(functionPointers[NxScene_doxybind::getPointerStart() + 57]);
    return func();
}

NxActiveTransform * NxScene_doxybind::getActiveTransforms(NxU32 & nbTransformsOut) 
{
    NxActiveTransform * (*func)(NxU32 & nbTransformsOut) = (NxActiveTransform * (*)(NxU32 & nbTransformsOut))(functionPointers[NxScene_doxybind::getPointerStart() + 58]);
    return func(nbTransformsOut);
}

NxU32 NxScene_doxybind::getNbStaticShapes() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxScene_doxybind::getPointerStart() + 59]);
    return func();
}

NxU32 NxScene_doxybind::getNbDynamicShapes() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxScene_doxybind::getPointerStart() + 60]);
    return func();
}

NxU32 NxScene_doxybind::getTotalNbShapes() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxScene_doxybind::getPointerStart() + 61]);
    return func();
}

NxU32 NxScene_doxybind::getNbJoints() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxScene_doxybind::getPointerStart() + 62]);
    return func();
}

void NxScene_doxybind::resetJointIterator() 
{
    void (*func)() = (void (*)())(functionPointers[NxScene_doxybind::getPointerStart() + 63]);
     func();
}

NxJoint * NxScene_doxybind::getNextJoint() 
{
    NxJoint * (*func)() = (NxJoint * (*)())(functionPointers[NxScene_doxybind::getPointerStart() + 64]);
    return func();
}

NxU32 NxScene_doxybind::getNbEffectors() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxScene_doxybind::getPointerStart() + 65]);
    return func();
}

void NxScene_doxybind::resetEffectorIterator() 
{
    void (*func)() = (void (*)())(functionPointers[NxScene_doxybind::getPointerStart() + 66]);
     func();
}

NxEffector * NxScene_doxybind::getNextEffector() 
{
    NxEffector * (*func)() = (NxEffector * (*)())(functionPointers[NxScene_doxybind::getPointerStart() + 67]);
    return func();
}

NxU32 NxScene_doxybind::getBoundForIslandSize(NxActor & actor) 
{
    NxU32 (*func)(NxActor & actor) = (NxU32 (*)(NxActor & actor))(functionPointers[NxScene_doxybind::getPointerStart() + 68]);
    return func(actor);
}

NxU32 NxScene_doxybind::getIslandArrayFromActor(NxActor & actor, NxActor ** userBuffer, NxU32 bufferSize, NxU32 & userIterator) 
{
    NxU32 (*func)(NxActor & actor, NxActor ** userBuffer, NxU32 bufferSize, NxU32 & userIterator) = (NxU32 (*)(NxActor & actor, NxActor ** userBuffer, NxU32 bufferSize, NxU32 & userIterator))(functionPointers[NxScene_doxybind::getPointerStart() + 69]);
    return func(actor, userBuffer, bufferSize, userIterator);
}

NxU32 NxScene_doxybind::getNbMaterials() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxScene_doxybind::getPointerStart() + 70]);
    return func();
}

NxU32 NxScene_doxybind::getMaterialArray(NxMaterial ** userBuffer, NxU32 bufferSize, NxU32 & usersIterator) 
{
    NxU32 (*func)(NxMaterial ** userBuffer, NxU32 bufferSize, NxU32 & usersIterator) = (NxU32 (*)(NxMaterial ** userBuffer, NxU32 bufferSize, NxU32 & usersIterator))(functionPointers[NxScene_doxybind::getPointerStart() + 71]);
    return func(userBuffer, bufferSize, usersIterator);
}

NxMaterialIndex NxScene_doxybind::getHighestMaterialIndex() const
{
    NxMaterialIndex (*func)() = (NxMaterialIndex (*)())(functionPointers[NxScene_doxybind::getPointerStart() + 72]);
    return func();
}

NxMaterial * NxScene_doxybind::getMaterialFromIndex(NxMaterialIndex matIndex) 
{
    NxMaterial * (*func)(NxMaterialIndex matIndex) = (NxMaterial * (*)(NxMaterialIndex matIndex))(functionPointers[NxScene_doxybind::getPointerStart() + 73]);
    return func(matIndex);
}

void NxScene_doxybind::setUserNotify(NxUserNotify * callback) 
{
    void (*func)(NxUserNotify * callback) = (void (*)(NxUserNotify * callback))(functionPointers[NxScene_doxybind::getPointerStart() + 74]);
     func(callback);
}

NxUserNotify * NxScene_doxybind::getUserNotify() const
{
    NxUserNotify * (*func)() = (NxUserNotify * (*)())(functionPointers[NxScene_doxybind::getPointerStart() + 75]);
    return func();
}

void NxScene_doxybind::setFluidUserNotify(NxFluidUserNotify * callback) 
{
    void (*func)(NxFluidUserNotify * callback) = (void (*)(NxFluidUserNotify * callback))(functionPointers[NxScene_doxybind::getPointerStart() + 76]);
     func(callback);
}

NxFluidUserNotify * NxScene_doxybind::getFluidUserNotify() const
{
    NxFluidUserNotify * (*func)() = (NxFluidUserNotify * (*)())(functionPointers[NxScene_doxybind::getPointerStart() + 77]);
    return func();
}

void NxScene_doxybind::setClothUserNotify(NxClothUserNotify * callback) 
{
    void (*func)(NxClothUserNotify * callback) = (void (*)(NxClothUserNotify * callback))(functionPointers[NxScene_doxybind::getPointerStart() + 78]);
     func(callback);
}

NxClothUserNotify * NxScene_doxybind::getClothUserNotify() const
{
    NxClothUserNotify * (*func)() = (NxClothUserNotify * (*)())(functionPointers[NxScene_doxybind::getPointerStart() + 79]);
    return func();
}

void NxScene_doxybind::setSoftBodyUserNotify(NxSoftBodyUserNotify * callback) 
{
    void (*func)(NxSoftBodyUserNotify * callback) = (void (*)(NxSoftBodyUserNotify * callback))(functionPointers[NxScene_doxybind::getPointerStart() + 80]);
     func(callback);
}

NxSoftBodyUserNotify * NxScene_doxybind::getSoftBodyUserNotify() const
{
    NxSoftBodyUserNotify * (*func)() = (NxSoftBodyUserNotify * (*)())(functionPointers[NxScene_doxybind::getPointerStart() + 81]);
    return func();
}

void NxScene_doxybind::setUserContactModify(NxUserContactModify * callback) 
{
    void (*func)(NxUserContactModify * callback) = (void (*)(NxUserContactModify * callback))(functionPointers[NxScene_doxybind::getPointerStart() + 82]);
     func(callback);
}

NxUserContactModify * NxScene_doxybind::getUserContactModify() const
{
    NxUserContactModify * (*func)() = (NxUserContactModify * (*)())(functionPointers[NxScene_doxybind::getPointerStart() + 83]);
    return func();
}

void NxScene_doxybind::setUserTriggerReport(NxUserTriggerReport * callback) 
{
    void (*func)(NxUserTriggerReport * callback) = (void (*)(NxUserTriggerReport * callback))(functionPointers[NxScene_doxybind::getPointerStart() + 84]);
     func(callback);
}

NxUserTriggerReport * NxScene_doxybind::getUserTriggerReport() const
{
    NxUserTriggerReport * (*func)() = (NxUserTriggerReport * (*)())(functionPointers[NxScene_doxybind::getPointerStart() + 85]);
    return func();
}

void NxScene_doxybind::setUserContactReport(NxUserContactReport * callback) 
{
    void (*func)(NxUserContactReport * callback) = (void (*)(NxUserContactReport * callback))(functionPointers[NxScene_doxybind::getPointerStart() + 86]);
     func(callback);
}

NxUserContactReport * NxScene_doxybind::getUserContactReport() const
{
    NxUserContactReport * (*func)() = (NxUserContactReport * (*)())(functionPointers[NxScene_doxybind::getPointerStart() + 87]);
    return func();
}

void NxScene_doxybind::setUserActorPairFiltering(NxUserActorPairFiltering * callback) 
{
    void (*func)(NxUserActorPairFiltering * callback) = (void (*)(NxUserActorPairFiltering * callback))(functionPointers[NxScene_doxybind::getPointerStart() + 88]);
     func(callback);
}

NxUserActorPairFiltering * NxScene_doxybind::getUserActorPairFiltering() const
{
    NxUserActorPairFiltering * (*func)() = (NxUserActorPairFiltering * (*)())(functionPointers[NxScene_doxybind::getPointerStart() + 89]);
    return func();
}

bool NxScene_doxybind::raycastAnyBounds(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups, NxReal maxDist, const NxGroupsMask * groupsMask) const
{
    bool (*func)(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups, NxReal maxDist, const NxGroupsMask * groupsMask) = (bool (*)(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups, NxReal maxDist, const NxGroupsMask * groupsMask))(functionPointers[NxScene_doxybind::getPointerStart() + 90]);
    return func(worldRay, shapesType, groups, maxDist, groupsMask);
}

bool NxScene_doxybind::raycastAnyBounds(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups, NxReal maxDist) const
{
    bool (*func)(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups, NxReal maxDist) = (bool (*)(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups, NxReal maxDist))(functionPointers[NxScene_doxybind::getPointerStart() + 91]);
    return func(worldRay, shapesType, groups, maxDist);
}

bool NxScene_doxybind::raycastAnyBounds(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups) const
{
    bool (*func)(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups) = (bool (*)(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups))(functionPointers[NxScene_doxybind::getPointerStart() + 92]);
    return func(worldRay, shapesType, groups);
}

bool NxScene_doxybind::raycastAnyBounds(const NxRay & worldRay, NxShapesType shapesType) const
{
    bool (*func)(const NxRay & worldRay, NxShapesType shapesType) = (bool (*)(const NxRay & worldRay, NxShapesType shapesType))(functionPointers[NxScene_doxybind::getPointerStart() + 93]);
    return func(worldRay, shapesType);
}

bool NxScene_doxybind::raycastAnyShape(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups, NxReal maxDist, const NxGroupsMask * groupsMask, NxShape ** cache) const
{
    bool (*func)(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups, NxReal maxDist, const NxGroupsMask * groupsMask, NxShape ** cache) = (bool (*)(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups, NxReal maxDist, const NxGroupsMask * groupsMask, NxShape ** cache))(functionPointers[NxScene_doxybind::getPointerStart() + 94]);
    return func(worldRay, shapesType, groups, maxDist, groupsMask, cache);
}

bool NxScene_doxybind::raycastAnyShape(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups, NxReal maxDist, const NxGroupsMask * groupsMask) const
{
    bool (*func)(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups, NxReal maxDist, const NxGroupsMask * groupsMask) = (bool (*)(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups, NxReal maxDist, const NxGroupsMask * groupsMask))(functionPointers[NxScene_doxybind::getPointerStart() + 95]);
    return func(worldRay, shapesType, groups, maxDist, groupsMask);
}

bool NxScene_doxybind::raycastAnyShape(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups, NxReal maxDist) const
{
    bool (*func)(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups, NxReal maxDist) = (bool (*)(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups, NxReal maxDist))(functionPointers[NxScene_doxybind::getPointerStart() + 96]);
    return func(worldRay, shapesType, groups, maxDist);
}

bool NxScene_doxybind::raycastAnyShape(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups) const
{
    bool (*func)(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups) = (bool (*)(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups))(functionPointers[NxScene_doxybind::getPointerStart() + 97]);
    return func(worldRay, shapesType, groups);
}

bool NxScene_doxybind::raycastAnyShape(const NxRay & worldRay, NxShapesType shapesType) const
{
    bool (*func)(const NxRay & worldRay, NxShapesType shapesType) = (bool (*)(const NxRay & worldRay, NxShapesType shapesType))(functionPointers[NxScene_doxybind::getPointerStart() + 98]);
    return func(worldRay, shapesType);
}

NxU32 NxScene_doxybind::raycastAllBounds(const NxRay & worldRay, NxUserRaycastReport & report, NxShapesType shapesType, NxU32 groups, NxReal maxDist, NxU32 hintFlags, const NxGroupsMask * groupsMask) const
{
    NxU32 (*func)(const NxRay & worldRay, NxUserRaycastReport & report, NxShapesType shapesType, NxU32 groups, NxReal maxDist, NxU32 hintFlags, const NxGroupsMask * groupsMask) = (NxU32 (*)(const NxRay & worldRay, NxUserRaycastReport & report, NxShapesType shapesType, NxU32 groups, NxReal maxDist, NxU32 hintFlags, const NxGroupsMask * groupsMask))(functionPointers[NxScene_doxybind::getPointerStart() + 99]);
    return func(worldRay, report, shapesType, groups, maxDist, hintFlags, groupsMask);
}

NxU32 NxScene_doxybind::raycastAllBounds(const NxRay & worldRay, NxUserRaycastReport & report, NxShapesType shapesType, NxU32 groups, NxReal maxDist, NxU32 hintFlags) const
{
    NxU32 (*func)(const NxRay & worldRay, NxUserRaycastReport & report, NxShapesType shapesType, NxU32 groups, NxReal maxDist, NxU32 hintFlags) = (NxU32 (*)(const NxRay & worldRay, NxUserRaycastReport & report, NxShapesType shapesType, NxU32 groups, NxReal maxDist, NxU32 hintFlags))(functionPointers[NxScene_doxybind::getPointerStart() + 100]);
    return func(worldRay, report, shapesType, groups, maxDist, hintFlags);
}

NxU32 NxScene_doxybind::raycastAllBounds(const NxRay & worldRay, NxUserRaycastReport & report, NxShapesType shapesType, NxU32 groups, NxReal maxDist) const
{
    NxU32 (*func)(const NxRay & worldRay, NxUserRaycastReport & report, NxShapesType shapesType, NxU32 groups, NxReal maxDist) = (NxU32 (*)(const NxRay & worldRay, NxUserRaycastReport & report, NxShapesType shapesType, NxU32 groups, NxReal maxDist))(functionPointers[NxScene_doxybind::getPointerStart() + 101]);
    return func(worldRay, report, shapesType, groups, maxDist);
}

NxU32 NxScene_doxybind::raycastAllBounds(const NxRay & worldRay, NxUserRaycastReport & report, NxShapesType shapesType, NxU32 groups) const
{
    NxU32 (*func)(const NxRay & worldRay, NxUserRaycastReport & report, NxShapesType shapesType, NxU32 groups) = (NxU32 (*)(const NxRay & worldRay, NxUserRaycastReport & report, NxShapesType shapesType, NxU32 groups))(functionPointers[NxScene_doxybind::getPointerStart() + 102]);
    return func(worldRay, report, shapesType, groups);
}

NxU32 NxScene_doxybind::raycastAllBounds(const NxRay & worldRay, NxUserRaycastReport & report, NxShapesType shapesType) const
{
    NxU32 (*func)(const NxRay & worldRay, NxUserRaycastReport & report, NxShapesType shapesType) = (NxU32 (*)(const NxRay & worldRay, NxUserRaycastReport & report, NxShapesType shapesType))(functionPointers[NxScene_doxybind::getPointerStart() + 103]);
    return func(worldRay, report, shapesType);
}

NxU32 NxScene_doxybind::raycastAllShapes(const NxRay & worldRay, NxUserRaycastReport & report, NxShapesType shapesType, NxU32 groups, NxReal maxDist, NxU32 hintFlags, const NxGroupsMask * groupsMask) const
{
    NxU32 (*func)(const NxRay & worldRay, NxUserRaycastReport & report, NxShapesType shapesType, NxU32 groups, NxReal maxDist, NxU32 hintFlags, const NxGroupsMask * groupsMask) = (NxU32 (*)(const NxRay & worldRay, NxUserRaycastReport & report, NxShapesType shapesType, NxU32 groups, NxReal maxDist, NxU32 hintFlags, const NxGroupsMask * groupsMask))(functionPointers[NxScene_doxybind::getPointerStart() + 104]);
    return func(worldRay, report, shapesType, groups, maxDist, hintFlags, groupsMask);
}

NxU32 NxScene_doxybind::raycastAllShapes(const NxRay & worldRay, NxUserRaycastReport & report, NxShapesType shapesType, NxU32 groups, NxReal maxDist, NxU32 hintFlags) const
{
    NxU32 (*func)(const NxRay & worldRay, NxUserRaycastReport & report, NxShapesType shapesType, NxU32 groups, NxReal maxDist, NxU32 hintFlags) = (NxU32 (*)(const NxRay & worldRay, NxUserRaycastReport & report, NxShapesType shapesType, NxU32 groups, NxReal maxDist, NxU32 hintFlags))(functionPointers[NxScene_doxybind::getPointerStart() + 105]);
    return func(worldRay, report, shapesType, groups, maxDist, hintFlags);
}

NxU32 NxScene_doxybind::raycastAllShapes(const NxRay & worldRay, NxUserRaycastReport & report, NxShapesType shapesType, NxU32 groups, NxReal maxDist) const
{
    NxU32 (*func)(const NxRay & worldRay, NxUserRaycastReport & report, NxShapesType shapesType, NxU32 groups, NxReal maxDist) = (NxU32 (*)(const NxRay & worldRay, NxUserRaycastReport & report, NxShapesType shapesType, NxU32 groups, NxReal maxDist))(functionPointers[NxScene_doxybind::getPointerStart() + 106]);
    return func(worldRay, report, shapesType, groups, maxDist);
}

NxU32 NxScene_doxybind::raycastAllShapes(const NxRay & worldRay, NxUserRaycastReport & report, NxShapesType shapesType, NxU32 groups) const
{
    NxU32 (*func)(const NxRay & worldRay, NxUserRaycastReport & report, NxShapesType shapesType, NxU32 groups) = (NxU32 (*)(const NxRay & worldRay, NxUserRaycastReport & report, NxShapesType shapesType, NxU32 groups))(functionPointers[NxScene_doxybind::getPointerStart() + 107]);
    return func(worldRay, report, shapesType, groups);
}

NxU32 NxScene_doxybind::raycastAllShapes(const NxRay & worldRay, NxUserRaycastReport & report, NxShapesType shapesType) const
{
    NxU32 (*func)(const NxRay & worldRay, NxUserRaycastReport & report, NxShapesType shapesType) = (NxU32 (*)(const NxRay & worldRay, NxUserRaycastReport & report, NxShapesType shapesType))(functionPointers[NxScene_doxybind::getPointerStart() + 108]);
    return func(worldRay, report, shapesType);
}

NxShape * NxScene_doxybind::raycastClosestBounds(const NxRay & worldRay, NxShapesType shapeType, NxRaycastHit & hit, NxU32 groups, NxReal maxDist, NxU32 hintFlags, const NxGroupsMask * groupsMask) const
{
    NxShape * (*func)(const NxRay & worldRay, NxShapesType shapeType, NxRaycastHit & hit, NxU32 groups, NxReal maxDist, NxU32 hintFlags, const NxGroupsMask * groupsMask) = (NxShape * (*)(const NxRay & worldRay, NxShapesType shapeType, NxRaycastHit & hit, NxU32 groups, NxReal maxDist, NxU32 hintFlags, const NxGroupsMask * groupsMask))(functionPointers[NxScene_doxybind::getPointerStart() + 109]);
    return func(worldRay, shapeType, hit, groups, maxDist, hintFlags, groupsMask);
}

NxShape * NxScene_doxybind::raycastClosestBounds(const NxRay & worldRay, NxShapesType shapeType, NxRaycastHit & hit, NxU32 groups, NxReal maxDist, NxU32 hintFlags) const
{
    NxShape * (*func)(const NxRay & worldRay, NxShapesType shapeType, NxRaycastHit & hit, NxU32 groups, NxReal maxDist, NxU32 hintFlags) = (NxShape * (*)(const NxRay & worldRay, NxShapesType shapeType, NxRaycastHit & hit, NxU32 groups, NxReal maxDist, NxU32 hintFlags))(functionPointers[NxScene_doxybind::getPointerStart() + 110]);
    return func(worldRay, shapeType, hit, groups, maxDist, hintFlags);
}

NxShape * NxScene_doxybind::raycastClosestBounds(const NxRay & worldRay, NxShapesType shapeType, NxRaycastHit & hit, NxU32 groups, NxReal maxDist) const
{
    NxShape * (*func)(const NxRay & worldRay, NxShapesType shapeType, NxRaycastHit & hit, NxU32 groups, NxReal maxDist) = (NxShape * (*)(const NxRay & worldRay, NxShapesType shapeType, NxRaycastHit & hit, NxU32 groups, NxReal maxDist))(functionPointers[NxScene_doxybind::getPointerStart() + 111]);
    return func(worldRay, shapeType, hit, groups, maxDist);
}

NxShape * NxScene_doxybind::raycastClosestBounds(const NxRay & worldRay, NxShapesType shapeType, NxRaycastHit & hit, NxU32 groups) const
{
    NxShape * (*func)(const NxRay & worldRay, NxShapesType shapeType, NxRaycastHit & hit, NxU32 groups) = (NxShape * (*)(const NxRay & worldRay, NxShapesType shapeType, NxRaycastHit & hit, NxU32 groups))(functionPointers[NxScene_doxybind::getPointerStart() + 112]);
    return func(worldRay, shapeType, hit, groups);
}

NxShape * NxScene_doxybind::raycastClosestBounds(const NxRay & worldRay, NxShapesType shapeType, NxRaycastHit & hit) const
{
    NxShape * (*func)(const NxRay & worldRay, NxShapesType shapeType, NxRaycastHit & hit) = (NxShape * (*)(const NxRay & worldRay, NxShapesType shapeType, NxRaycastHit & hit))(functionPointers[NxScene_doxybind::getPointerStart() + 113]);
    return func(worldRay, shapeType, hit);
}

NxShape * NxScene_doxybind::raycastClosestShape(const NxRay & worldRay, NxShapesType shapeType, NxRaycastHit & hit, NxU32 groups, NxReal maxDist, NxU32 hintFlags, const NxGroupsMask * groupsMask, NxShape ** cache) const
{
    NxShape * (*func)(const NxRay & worldRay, NxShapesType shapeType, NxRaycastHit & hit, NxU32 groups, NxReal maxDist, NxU32 hintFlags, const NxGroupsMask * groupsMask, NxShape ** cache) = (NxShape * (*)(const NxRay & worldRay, NxShapesType shapeType, NxRaycastHit & hit, NxU32 groups, NxReal maxDist, NxU32 hintFlags, const NxGroupsMask * groupsMask, NxShape ** cache))(functionPointers[NxScene_doxybind::getPointerStart() + 114]);
    return func(worldRay, shapeType, hit, groups, maxDist, hintFlags, groupsMask, cache);
}

NxShape * NxScene_doxybind::raycastClosestShape(const NxRay & worldRay, NxShapesType shapeType, NxRaycastHit & hit, NxU32 groups, NxReal maxDist, NxU32 hintFlags, const NxGroupsMask * groupsMask) const
{
    NxShape * (*func)(const NxRay & worldRay, NxShapesType shapeType, NxRaycastHit & hit, NxU32 groups, NxReal maxDist, NxU32 hintFlags, const NxGroupsMask * groupsMask) = (NxShape * (*)(const NxRay & worldRay, NxShapesType shapeType, NxRaycastHit & hit, NxU32 groups, NxReal maxDist, NxU32 hintFlags, const NxGroupsMask * groupsMask))(functionPointers[NxScene_doxybind::getPointerStart() + 115]);
    return func(worldRay, shapeType, hit, groups, maxDist, hintFlags, groupsMask);
}

NxShape * NxScene_doxybind::raycastClosestShape(const NxRay & worldRay, NxShapesType shapeType, NxRaycastHit & hit, NxU32 groups, NxReal maxDist, NxU32 hintFlags) const
{
    NxShape * (*func)(const NxRay & worldRay, NxShapesType shapeType, NxRaycastHit & hit, NxU32 groups, NxReal maxDist, NxU32 hintFlags) = (NxShape * (*)(const NxRay & worldRay, NxShapesType shapeType, NxRaycastHit & hit, NxU32 groups, NxReal maxDist, NxU32 hintFlags))(functionPointers[NxScene_doxybind::getPointerStart() + 116]);
    return func(worldRay, shapeType, hit, groups, maxDist, hintFlags);
}

NxShape * NxScene_doxybind::raycastClosestShape(const NxRay & worldRay, NxShapesType shapeType, NxRaycastHit & hit, NxU32 groups, NxReal maxDist) const
{
    NxShape * (*func)(const NxRay & worldRay, NxShapesType shapeType, NxRaycastHit & hit, NxU32 groups, NxReal maxDist) = (NxShape * (*)(const NxRay & worldRay, NxShapesType shapeType, NxRaycastHit & hit, NxU32 groups, NxReal maxDist))(functionPointers[NxScene_doxybind::getPointerStart() + 117]);
    return func(worldRay, shapeType, hit, groups, maxDist);
}

NxShape * NxScene_doxybind::raycastClosestShape(const NxRay & worldRay, NxShapesType shapeType, NxRaycastHit & hit, NxU32 groups) const
{
    NxShape * (*func)(const NxRay & worldRay, NxShapesType shapeType, NxRaycastHit & hit, NxU32 groups) = (NxShape * (*)(const NxRay & worldRay, NxShapesType shapeType, NxRaycastHit & hit, NxU32 groups))(functionPointers[NxScene_doxybind::getPointerStart() + 118]);
    return func(worldRay, shapeType, hit, groups);
}

NxShape * NxScene_doxybind::raycastClosestShape(const NxRay & worldRay, NxShapesType shapeType, NxRaycastHit & hit) const
{
    NxShape * (*func)(const NxRay & worldRay, NxShapesType shapeType, NxRaycastHit & hit) = (NxShape * (*)(const NxRay & worldRay, NxShapesType shapeType, NxRaycastHit & hit))(functionPointers[NxScene_doxybind::getPointerStart() + 119]);
    return func(worldRay, shapeType, hit);
}

NxU32 NxScene_doxybind::overlapSphereShapes(const NxSphere & worldSphere, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback, NxU32 activeGroups, const NxGroupsMask * groupsMask, bool accurateCollision) 
{
    NxU32 (*func)(const NxSphere & worldSphere, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback, NxU32 activeGroups, const NxGroupsMask * groupsMask, bool accurateCollision) = (NxU32 (*)(const NxSphere & worldSphere, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback, NxU32 activeGroups, const NxGroupsMask * groupsMask, bool accurateCollision))(functionPointers[NxScene_doxybind::getPointerStart() + 120]);
    return func(worldSphere, shapeType, nbShapes, shapes, callback, activeGroups, groupsMask, accurateCollision);
}

NxU32 NxScene_doxybind::overlapSphereShapes(const NxSphere & worldSphere, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback, NxU32 activeGroups, const NxGroupsMask * groupsMask) 
{
    NxU32 (*func)(const NxSphere & worldSphere, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback, NxU32 activeGroups, const NxGroupsMask * groupsMask) = (NxU32 (*)(const NxSphere & worldSphere, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback, NxU32 activeGroups, const NxGroupsMask * groupsMask))(functionPointers[NxScene_doxybind::getPointerStart() + 121]);
    return func(worldSphere, shapeType, nbShapes, shapes, callback, activeGroups, groupsMask);
}

NxU32 NxScene_doxybind::overlapSphereShapes(const NxSphere & worldSphere, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback, NxU32 activeGroups) 
{
    NxU32 (*func)(const NxSphere & worldSphere, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback, NxU32 activeGroups) = (NxU32 (*)(const NxSphere & worldSphere, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback, NxU32 activeGroups))(functionPointers[NxScene_doxybind::getPointerStart() + 122]);
    return func(worldSphere, shapeType, nbShapes, shapes, callback, activeGroups);
}

NxU32 NxScene_doxybind::overlapSphereShapes(const NxSphere & worldSphere, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback) 
{
    NxU32 (*func)(const NxSphere & worldSphere, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback) = (NxU32 (*)(const NxSphere & worldSphere, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback))(functionPointers[NxScene_doxybind::getPointerStart() + 123]);
    return func(worldSphere, shapeType, nbShapes, shapes, callback);
}

NxU32 NxScene_doxybind::overlapAABBShapes(const NxBounds3 & worldBounds, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback, NxU32 activeGroups, const NxGroupsMask * groupsMask, bool accurateCollision) 
{
    NxU32 (*func)(const NxBounds3 & worldBounds, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback, NxU32 activeGroups, const NxGroupsMask * groupsMask, bool accurateCollision) = (NxU32 (*)(const NxBounds3 & worldBounds, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback, NxU32 activeGroups, const NxGroupsMask * groupsMask, bool accurateCollision))(functionPointers[NxScene_doxybind::getPointerStart() + 124]);
    return func(worldBounds, shapeType, nbShapes, shapes, callback, activeGroups, groupsMask, accurateCollision);
}

NxU32 NxScene_doxybind::overlapAABBShapes(const NxBounds3 & worldBounds, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback, NxU32 activeGroups, const NxGroupsMask * groupsMask) 
{
    NxU32 (*func)(const NxBounds3 & worldBounds, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback, NxU32 activeGroups, const NxGroupsMask * groupsMask) = (NxU32 (*)(const NxBounds3 & worldBounds, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback, NxU32 activeGroups, const NxGroupsMask * groupsMask))(functionPointers[NxScene_doxybind::getPointerStart() + 125]);
    return func(worldBounds, shapeType, nbShapes, shapes, callback, activeGroups, groupsMask);
}

NxU32 NxScene_doxybind::overlapAABBShapes(const NxBounds3 & worldBounds, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback, NxU32 activeGroups) 
{
    NxU32 (*func)(const NxBounds3 & worldBounds, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback, NxU32 activeGroups) = (NxU32 (*)(const NxBounds3 & worldBounds, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback, NxU32 activeGroups))(functionPointers[NxScene_doxybind::getPointerStart() + 126]);
    return func(worldBounds, shapeType, nbShapes, shapes, callback, activeGroups);
}

NxU32 NxScene_doxybind::overlapAABBShapes(const NxBounds3 & worldBounds, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback) 
{
    NxU32 (*func)(const NxBounds3 & worldBounds, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback) = (NxU32 (*)(const NxBounds3 & worldBounds, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback))(functionPointers[NxScene_doxybind::getPointerStart() + 127]);
    return func(worldBounds, shapeType, nbShapes, shapes, callback);
}

NxU32 NxScene_doxybind::overlapOBBShapes(const NxBox & worldBox, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback, NxU32 activeGroups, const NxGroupsMask * groupsMask, bool accurateCollision) 
{
    NxU32 (*func)(const NxBox & worldBox, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback, NxU32 activeGroups, const NxGroupsMask * groupsMask, bool accurateCollision) = (NxU32 (*)(const NxBox & worldBox, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback, NxU32 activeGroups, const NxGroupsMask * groupsMask, bool accurateCollision))(functionPointers[NxScene_doxybind::getPointerStart() + 128]);
    return func(worldBox, shapeType, nbShapes, shapes, callback, activeGroups, groupsMask, accurateCollision);
}

NxU32 NxScene_doxybind::overlapOBBShapes(const NxBox & worldBox, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback, NxU32 activeGroups, const NxGroupsMask * groupsMask) 
{
    NxU32 (*func)(const NxBox & worldBox, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback, NxU32 activeGroups, const NxGroupsMask * groupsMask) = (NxU32 (*)(const NxBox & worldBox, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback, NxU32 activeGroups, const NxGroupsMask * groupsMask))(functionPointers[NxScene_doxybind::getPointerStart() + 129]);
    return func(worldBox, shapeType, nbShapes, shapes, callback, activeGroups, groupsMask);
}

NxU32 NxScene_doxybind::overlapOBBShapes(const NxBox & worldBox, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback, NxU32 activeGroups) 
{
    NxU32 (*func)(const NxBox & worldBox, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback, NxU32 activeGroups) = (NxU32 (*)(const NxBox & worldBox, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback, NxU32 activeGroups))(functionPointers[NxScene_doxybind::getPointerStart() + 130]);
    return func(worldBox, shapeType, nbShapes, shapes, callback, activeGroups);
}

NxU32 NxScene_doxybind::overlapOBBShapes(const NxBox & worldBox, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback) 
{
    NxU32 (*func)(const NxBox & worldBox, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback) = (NxU32 (*)(const NxBox & worldBox, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback))(functionPointers[NxScene_doxybind::getPointerStart() + 131]);
    return func(worldBox, shapeType, nbShapes, shapes, callback);
}

NxU32 NxScene_doxybind::overlapCapsuleShapes(const NxCapsule & worldCapsule, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback, NxU32 activeGroups, const NxGroupsMask * groupsMask, bool accurateCollision) 
{
    NxU32 (*func)(const NxCapsule & worldCapsule, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback, NxU32 activeGroups, const NxGroupsMask * groupsMask, bool accurateCollision) = (NxU32 (*)(const NxCapsule & worldCapsule, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback, NxU32 activeGroups, const NxGroupsMask * groupsMask, bool accurateCollision))(functionPointers[NxScene_doxybind::getPointerStart() + 132]);
    return func(worldCapsule, shapeType, nbShapes, shapes, callback, activeGroups, groupsMask, accurateCollision);
}

NxU32 NxScene_doxybind::overlapCapsuleShapes(const NxCapsule & worldCapsule, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback, NxU32 activeGroups, const NxGroupsMask * groupsMask) 
{
    NxU32 (*func)(const NxCapsule & worldCapsule, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback, NxU32 activeGroups, const NxGroupsMask * groupsMask) = (NxU32 (*)(const NxCapsule & worldCapsule, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback, NxU32 activeGroups, const NxGroupsMask * groupsMask))(functionPointers[NxScene_doxybind::getPointerStart() + 133]);
    return func(worldCapsule, shapeType, nbShapes, shapes, callback, activeGroups, groupsMask);
}

NxU32 NxScene_doxybind::overlapCapsuleShapes(const NxCapsule & worldCapsule, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback, NxU32 activeGroups) 
{
    NxU32 (*func)(const NxCapsule & worldCapsule, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback, NxU32 activeGroups) = (NxU32 (*)(const NxCapsule & worldCapsule, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback, NxU32 activeGroups))(functionPointers[NxScene_doxybind::getPointerStart() + 134]);
    return func(worldCapsule, shapeType, nbShapes, shapes, callback, activeGroups);
}

NxU32 NxScene_doxybind::overlapCapsuleShapes(const NxCapsule & worldCapsule, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback) 
{
    NxU32 (*func)(const NxCapsule & worldCapsule, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback) = (NxU32 (*)(const NxCapsule & worldCapsule, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback))(functionPointers[NxScene_doxybind::getPointerStart() + 135]);
    return func(worldCapsule, shapeType, nbShapes, shapes, callback);
}

NxSweepCache * NxScene_doxybind::createSweepCache() 
{
    NxSweepCache * (*func)() = (NxSweepCache * (*)())(functionPointers[NxScene_doxybind::getPointerStart() + 136]);
    return func();
}

void NxScene_doxybind::releaseSweepCache(NxSweepCache * cache) 
{
    void (*func)(NxSweepCache * cache) = (void (*)(NxSweepCache * cache))(functionPointers[NxScene_doxybind::getPointerStart() + 137]);
     func(cache);
}

NxU32 NxScene_doxybind::linearOBBSweep(const NxBox & worldBox, const NxVec3 & motion, NxU32 flags, void * userData, NxU32 nbShapes, NxSweepQueryHit * shapes, NxUserEntityReport< NxSweepQueryHit > * callback, NxU32 activeGroups, const NxGroupsMask * groupsMask) 
{
    NxU32 (*func)(const NxBox & worldBox, const NxVec3 & motion, NxU32 flags, void * userData, NxU32 nbShapes, NxSweepQueryHit * shapes, NxUserEntityReport< NxSweepQueryHit > * callback, NxU32 activeGroups, const NxGroupsMask * groupsMask) = (NxU32 (*)(const NxBox & worldBox, const NxVec3 & motion, NxU32 flags, void * userData, NxU32 nbShapes, NxSweepQueryHit * shapes, NxUserEntityReport< NxSweepQueryHit > * callback, NxU32 activeGroups, const NxGroupsMask * groupsMask))(functionPointers[NxScene_doxybind::getPointerStart() + 138]);
    return func(worldBox, motion, flags, userData, nbShapes, shapes, callback, activeGroups, groupsMask);
}

NxU32 NxScene_doxybind::linearOBBSweep(const NxBox & worldBox, const NxVec3 & motion, NxU32 flags, void * userData, NxU32 nbShapes, NxSweepQueryHit * shapes, NxUserEntityReport< NxSweepQueryHit > * callback, NxU32 activeGroups) 
{
    NxU32 (*func)(const NxBox & worldBox, const NxVec3 & motion, NxU32 flags, void * userData, NxU32 nbShapes, NxSweepQueryHit * shapes, NxUserEntityReport< NxSweepQueryHit > * callback, NxU32 activeGroups) = (NxU32 (*)(const NxBox & worldBox, const NxVec3 & motion, NxU32 flags, void * userData, NxU32 nbShapes, NxSweepQueryHit * shapes, NxUserEntityReport< NxSweepQueryHit > * callback, NxU32 activeGroups))(functionPointers[NxScene_doxybind::getPointerStart() + 139]);
    return func(worldBox, motion, flags, userData, nbShapes, shapes, callback, activeGroups);
}

NxU32 NxScene_doxybind::linearOBBSweep(const NxBox & worldBox, const NxVec3 & motion, NxU32 flags, void * userData, NxU32 nbShapes, NxSweepQueryHit * shapes, NxUserEntityReport< NxSweepQueryHit > * callback) 
{
    NxU32 (*func)(const NxBox & worldBox, const NxVec3 & motion, NxU32 flags, void * userData, NxU32 nbShapes, NxSweepQueryHit * shapes, NxUserEntityReport< NxSweepQueryHit > * callback) = (NxU32 (*)(const NxBox & worldBox, const NxVec3 & motion, NxU32 flags, void * userData, NxU32 nbShapes, NxSweepQueryHit * shapes, NxUserEntityReport< NxSweepQueryHit > * callback))(functionPointers[NxScene_doxybind::getPointerStart() + 140]);
    return func(worldBox, motion, flags, userData, nbShapes, shapes, callback);
}

NxU32 NxScene_doxybind::linearCapsuleSweep(const NxCapsule & worldCapsule, const NxVec3 & motion, NxU32 flags, void * userData, NxU32 nbShapes, NxSweepQueryHit * shapes, NxUserEntityReport< NxSweepQueryHit > * callback, NxU32 activeGroups, const NxGroupsMask * groupsMask) 
{
    NxU32 (*func)(const NxCapsule & worldCapsule, const NxVec3 & motion, NxU32 flags, void * userData, NxU32 nbShapes, NxSweepQueryHit * shapes, NxUserEntityReport< NxSweepQueryHit > * callback, NxU32 activeGroups, const NxGroupsMask * groupsMask) = (NxU32 (*)(const NxCapsule & worldCapsule, const NxVec3 & motion, NxU32 flags, void * userData, NxU32 nbShapes, NxSweepQueryHit * shapes, NxUserEntityReport< NxSweepQueryHit > * callback, NxU32 activeGroups, const NxGroupsMask * groupsMask))(functionPointers[NxScene_doxybind::getPointerStart() + 141]);
    return func(worldCapsule, motion, flags, userData, nbShapes, shapes, callback, activeGroups, groupsMask);
}

NxU32 NxScene_doxybind::linearCapsuleSweep(const NxCapsule & worldCapsule, const NxVec3 & motion, NxU32 flags, void * userData, NxU32 nbShapes, NxSweepQueryHit * shapes, NxUserEntityReport< NxSweepQueryHit > * callback, NxU32 activeGroups) 
{
    NxU32 (*func)(const NxCapsule & worldCapsule, const NxVec3 & motion, NxU32 flags, void * userData, NxU32 nbShapes, NxSweepQueryHit * shapes, NxUserEntityReport< NxSweepQueryHit > * callback, NxU32 activeGroups) = (NxU32 (*)(const NxCapsule & worldCapsule, const NxVec3 & motion, NxU32 flags, void * userData, NxU32 nbShapes, NxSweepQueryHit * shapes, NxUserEntityReport< NxSweepQueryHit > * callback, NxU32 activeGroups))(functionPointers[NxScene_doxybind::getPointerStart() + 142]);
    return func(worldCapsule, motion, flags, userData, nbShapes, shapes, callback, activeGroups);
}

NxU32 NxScene_doxybind::linearCapsuleSweep(const NxCapsule & worldCapsule, const NxVec3 & motion, NxU32 flags, void * userData, NxU32 nbShapes, NxSweepQueryHit * shapes, NxUserEntityReport< NxSweepQueryHit > * callback) 
{
    NxU32 (*func)(const NxCapsule & worldCapsule, const NxVec3 & motion, NxU32 flags, void * userData, NxU32 nbShapes, NxSweepQueryHit * shapes, NxUserEntityReport< NxSweepQueryHit > * callback) = (NxU32 (*)(const NxCapsule & worldCapsule, const NxVec3 & motion, NxU32 flags, void * userData, NxU32 nbShapes, NxSweepQueryHit * shapes, NxUserEntityReport< NxSweepQueryHit > * callback))(functionPointers[NxScene_doxybind::getPointerStart() + 143]);
    return func(worldCapsule, motion, flags, userData, nbShapes, shapes, callback);
}

NxU32 NxScene_doxybind::cullShapes(NxU32 nbPlanes, const NxPlane * worldPlanes, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback, NxU32 activeGroups, const NxGroupsMask * groupsMask) 
{
    NxU32 (*func)(NxU32 nbPlanes, const NxPlane * worldPlanes, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback, NxU32 activeGroups, const NxGroupsMask * groupsMask) = (NxU32 (*)(NxU32 nbPlanes, const NxPlane * worldPlanes, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback, NxU32 activeGroups, const NxGroupsMask * groupsMask))(functionPointers[NxScene_doxybind::getPointerStart() + 144]);
    return func(nbPlanes, worldPlanes, shapeType, nbShapes, shapes, callback, activeGroups, groupsMask);
}

NxU32 NxScene_doxybind::cullShapes(NxU32 nbPlanes, const NxPlane * worldPlanes, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback, NxU32 activeGroups) 
{
    NxU32 (*func)(NxU32 nbPlanes, const NxPlane * worldPlanes, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback, NxU32 activeGroups) = (NxU32 (*)(NxU32 nbPlanes, const NxPlane * worldPlanes, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback, NxU32 activeGroups))(functionPointers[NxScene_doxybind::getPointerStart() + 145]);
    return func(nbPlanes, worldPlanes, shapeType, nbShapes, shapes, callback, activeGroups);
}

NxU32 NxScene_doxybind::cullShapes(NxU32 nbPlanes, const NxPlane * worldPlanes, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback) 
{
    NxU32 (*func)(NxU32 nbPlanes, const NxPlane * worldPlanes, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback) = (NxU32 (*)(NxU32 nbPlanes, const NxPlane * worldPlanes, NxShapesType shapeType, NxU32 nbShapes, NxShape ** shapes, NxUserEntityReport< NxShape * > * callback))(functionPointers[NxScene_doxybind::getPointerStart() + 146]);
    return func(nbPlanes, worldPlanes, shapeType, nbShapes, shapes, callback);
}

bool NxScene_doxybind::checkOverlapSphere(const NxSphere & worldSphere, NxShapesType shapeType, NxU32 activeGroups, const NxGroupsMask * groupsMask) 
{
    bool (*func)(const NxSphere & worldSphere, NxShapesType shapeType, NxU32 activeGroups, const NxGroupsMask * groupsMask) = (bool (*)(const NxSphere & worldSphere, NxShapesType shapeType, NxU32 activeGroups, const NxGroupsMask * groupsMask))(functionPointers[NxScene_doxybind::getPointerStart() + 147]);
    return func(worldSphere, shapeType, activeGroups, groupsMask);
}

bool NxScene_doxybind::checkOverlapSphere(const NxSphere & worldSphere, NxShapesType shapeType, NxU32 activeGroups) 
{
    bool (*func)(const NxSphere & worldSphere, NxShapesType shapeType, NxU32 activeGroups) = (bool (*)(const NxSphere & worldSphere, NxShapesType shapeType, NxU32 activeGroups))(functionPointers[NxScene_doxybind::getPointerStart() + 148]);
    return func(worldSphere, shapeType, activeGroups);
}

bool NxScene_doxybind::checkOverlapSphere(const NxSphere & worldSphere, NxShapesType shapeType) 
{
    bool (*func)(const NxSphere & worldSphere, NxShapesType shapeType) = (bool (*)(const NxSphere & worldSphere, NxShapesType shapeType))(functionPointers[NxScene_doxybind::getPointerStart() + 149]);
    return func(worldSphere, shapeType);
}

bool NxScene_doxybind::checkOverlapSphere(const NxSphere & worldSphere) 
{
    bool (*func)(const NxSphere & worldSphere) = (bool (*)(const NxSphere & worldSphere))(functionPointers[NxScene_doxybind::getPointerStart() + 150]);
    return func(worldSphere);
}

bool NxScene_doxybind::checkOverlapAABB(const NxBounds3 & worldBounds, NxShapesType shapeType, NxU32 activeGroups, const NxGroupsMask * groupsMask) 
{
    bool (*func)(const NxBounds3 & worldBounds, NxShapesType shapeType, NxU32 activeGroups, const NxGroupsMask * groupsMask) = (bool (*)(const NxBounds3 & worldBounds, NxShapesType shapeType, NxU32 activeGroups, const NxGroupsMask * groupsMask))(functionPointers[NxScene_doxybind::getPointerStart() + 151]);
    return func(worldBounds, shapeType, activeGroups, groupsMask);
}

bool NxScene_doxybind::checkOverlapAABB(const NxBounds3 & worldBounds, NxShapesType shapeType, NxU32 activeGroups) 
{
    bool (*func)(const NxBounds3 & worldBounds, NxShapesType shapeType, NxU32 activeGroups) = (bool (*)(const NxBounds3 & worldBounds, NxShapesType shapeType, NxU32 activeGroups))(functionPointers[NxScene_doxybind::getPointerStart() + 152]);
    return func(worldBounds, shapeType, activeGroups);
}

bool NxScene_doxybind::checkOverlapAABB(const NxBounds3 & worldBounds, NxShapesType shapeType) 
{
    bool (*func)(const NxBounds3 & worldBounds, NxShapesType shapeType) = (bool (*)(const NxBounds3 & worldBounds, NxShapesType shapeType))(functionPointers[NxScene_doxybind::getPointerStart() + 153]);
    return func(worldBounds, shapeType);
}

bool NxScene_doxybind::checkOverlapAABB(const NxBounds3 & worldBounds) 
{
    bool (*func)(const NxBounds3 & worldBounds) = (bool (*)(const NxBounds3 & worldBounds))(functionPointers[NxScene_doxybind::getPointerStart() + 154]);
    return func(worldBounds);
}

bool NxScene_doxybind::checkOverlapOBB(const NxBox & worldBox, NxShapesType shapeType, NxU32 activeGroups, const NxGroupsMask * groupsMask) 
{
    bool (*func)(const NxBox & worldBox, NxShapesType shapeType, NxU32 activeGroups, const NxGroupsMask * groupsMask) = (bool (*)(const NxBox & worldBox, NxShapesType shapeType, NxU32 activeGroups, const NxGroupsMask * groupsMask))(functionPointers[NxScene_doxybind::getPointerStart() + 155]);
    return func(worldBox, shapeType, activeGroups, groupsMask);
}

bool NxScene_doxybind::checkOverlapOBB(const NxBox & worldBox, NxShapesType shapeType, NxU32 activeGroups) 
{
    bool (*func)(const NxBox & worldBox, NxShapesType shapeType, NxU32 activeGroups) = (bool (*)(const NxBox & worldBox, NxShapesType shapeType, NxU32 activeGroups))(functionPointers[NxScene_doxybind::getPointerStart() + 156]);
    return func(worldBox, shapeType, activeGroups);
}

bool NxScene_doxybind::checkOverlapOBB(const NxBox & worldBox, NxShapesType shapeType) 
{
    bool (*func)(const NxBox & worldBox, NxShapesType shapeType) = (bool (*)(const NxBox & worldBox, NxShapesType shapeType))(functionPointers[NxScene_doxybind::getPointerStart() + 157]);
    return func(worldBox, shapeType);
}

bool NxScene_doxybind::checkOverlapOBB(const NxBox & worldBox) 
{
    bool (*func)(const NxBox & worldBox) = (bool (*)(const NxBox & worldBox))(functionPointers[NxScene_doxybind::getPointerStart() + 158]);
    return func(worldBox);
}

bool NxScene_doxybind::checkOverlapCapsule(const NxCapsule & worldCapsule, NxShapesType shapeType, NxU32 activeGroups, const NxGroupsMask * groupsMask) 
{
    bool (*func)(const NxCapsule & worldCapsule, NxShapesType shapeType, NxU32 activeGroups, const NxGroupsMask * groupsMask) = (bool (*)(const NxCapsule & worldCapsule, NxShapesType shapeType, NxU32 activeGroups, const NxGroupsMask * groupsMask))(functionPointers[NxScene_doxybind::getPointerStart() + 159]);
    return func(worldCapsule, shapeType, activeGroups, groupsMask);
}

bool NxScene_doxybind::checkOverlapCapsule(const NxCapsule & worldCapsule, NxShapesType shapeType, NxU32 activeGroups) 
{
    bool (*func)(const NxCapsule & worldCapsule, NxShapesType shapeType, NxU32 activeGroups) = (bool (*)(const NxCapsule & worldCapsule, NxShapesType shapeType, NxU32 activeGroups))(functionPointers[NxScene_doxybind::getPointerStart() + 160]);
    return func(worldCapsule, shapeType, activeGroups);
}

bool NxScene_doxybind::checkOverlapCapsule(const NxCapsule & worldCapsule, NxShapesType shapeType) 
{
    bool (*func)(const NxCapsule & worldCapsule, NxShapesType shapeType) = (bool (*)(const NxCapsule & worldCapsule, NxShapesType shapeType))(functionPointers[NxScene_doxybind::getPointerStart() + 161]);
    return func(worldCapsule, shapeType);
}

bool NxScene_doxybind::checkOverlapCapsule(const NxCapsule & worldCapsule) 
{
    bool (*func)(const NxCapsule & worldCapsule) = (bool (*)(const NxCapsule & worldCapsule))(functionPointers[NxScene_doxybind::getPointerStart() + 162]);
    return func(worldCapsule);
}

NxFluid * NxScene_doxybind::createFluid(const NxFluidDescBase & fluidDesc) 
{
    NxFluid * (*func)(const NxFluidDescBase & fluidDesc) = (NxFluid * (*)(const NxFluidDescBase & fluidDesc))(functionPointers[NxScene_doxybind::getPointerStart() + 163]);
    return func(fluidDesc);
}

void NxScene_doxybind::releaseFluid(NxFluid & fluid) 
{
    void (*func)(NxFluid & fluid) = (void (*)(NxFluid & fluid))(functionPointers[NxScene_doxybind::getPointerStart() + 164]);
     func(fluid);
}

NxU32 NxScene_doxybind::getNbFluids() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxScene_doxybind::getPointerStart() + 165]);
    return func();
}

NxFluid ** NxScene_doxybind::getFluids() 
{
    NxFluid ** (*func)() = (NxFluid ** (*)())(functionPointers[NxScene_doxybind::getPointerStart() + 166]);
    return func();
}

bool NxScene_doxybind::cookFluidMeshHotspot(const NxBounds3 & bounds, NxU32 packetSizeMultiplier, NxReal restParticlesPerMeter, NxReal kernelRadiusMultiplier, NxReal motionLimitMultiplier, NxReal collisionDistanceMultiplier, NxCompartment * compartment, bool forceStrictCookingFormat) 
{
    bool (*func)(const NxBounds3 & bounds, NxU32 packetSizeMultiplier, NxReal restParticlesPerMeter, NxReal kernelRadiusMultiplier, NxReal motionLimitMultiplier, NxReal collisionDistanceMultiplier, NxCompartment * compartment, bool forceStrictCookingFormat) = (bool (*)(const NxBounds3 & bounds, NxU32 packetSizeMultiplier, NxReal restParticlesPerMeter, NxReal kernelRadiusMultiplier, NxReal motionLimitMultiplier, NxReal collisionDistanceMultiplier, NxCompartment * compartment, bool forceStrictCookingFormat))(functionPointers[NxScene_doxybind::getPointerStart() + 167]);
    return func(bounds, packetSizeMultiplier, restParticlesPerMeter, kernelRadiusMultiplier, motionLimitMultiplier, collisionDistanceMultiplier, compartment, forceStrictCookingFormat);
}

bool NxScene_doxybind::cookFluidMeshHotspot(const NxBounds3 & bounds, NxU32 packetSizeMultiplier, NxReal restParticlesPerMeter, NxReal kernelRadiusMultiplier, NxReal motionLimitMultiplier, NxReal collisionDistanceMultiplier, NxCompartment * compartment) 
{
    bool (*func)(const NxBounds3 & bounds, NxU32 packetSizeMultiplier, NxReal restParticlesPerMeter, NxReal kernelRadiusMultiplier, NxReal motionLimitMultiplier, NxReal collisionDistanceMultiplier, NxCompartment * compartment) = (bool (*)(const NxBounds3 & bounds, NxU32 packetSizeMultiplier, NxReal restParticlesPerMeter, NxReal kernelRadiusMultiplier, NxReal motionLimitMultiplier, NxReal collisionDistanceMultiplier, NxCompartment * compartment))(functionPointers[NxScene_doxybind::getPointerStart() + 168]);
    return func(bounds, packetSizeMultiplier, restParticlesPerMeter, kernelRadiusMultiplier, motionLimitMultiplier, collisionDistanceMultiplier, compartment);
}

bool NxScene_doxybind::cookFluidMeshHotspot(const NxBounds3 & bounds, NxU32 packetSizeMultiplier, NxReal restParticlesPerMeter, NxReal kernelRadiusMultiplier, NxReal motionLimitMultiplier, NxReal collisionDistanceMultiplier) 
{
    bool (*func)(const NxBounds3 & bounds, NxU32 packetSizeMultiplier, NxReal restParticlesPerMeter, NxReal kernelRadiusMultiplier, NxReal motionLimitMultiplier, NxReal collisionDistanceMultiplier) = (bool (*)(const NxBounds3 & bounds, NxU32 packetSizeMultiplier, NxReal restParticlesPerMeter, NxReal kernelRadiusMultiplier, NxReal motionLimitMultiplier, NxReal collisionDistanceMultiplier))(functionPointers[NxScene_doxybind::getPointerStart() + 169]);
    return func(bounds, packetSizeMultiplier, restParticlesPerMeter, kernelRadiusMultiplier, motionLimitMultiplier, collisionDistanceMultiplier);
}

NxCloth * NxScene_doxybind::createCloth(const NxClothDesc & clothDesc) 
{
    NxCloth * (*func)(const NxClothDesc & clothDesc) = (NxCloth * (*)(const NxClothDesc & clothDesc))(functionPointers[NxScene_doxybind::getPointerStart() + 170]);
    return func(clothDesc);
}

void NxScene_doxybind::releaseCloth(NxCloth & cloth) 
{
    void (*func)(NxCloth & cloth) = (void (*)(NxCloth & cloth))(functionPointers[NxScene_doxybind::getPointerStart() + 171]);
     func(cloth);
}

NxU32 NxScene_doxybind::getNbCloths() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxScene_doxybind::getPointerStart() + 172]);
    return func();
}

NxCloth ** NxScene_doxybind::getCloths() 
{
    NxCloth ** (*func)() = (NxCloth ** (*)())(functionPointers[NxScene_doxybind::getPointerStart() + 173]);
    return func();
}

NxSoftBody * NxScene_doxybind::createSoftBody(const NxSoftBodyDesc & softBodyDesc) 
{
    NxSoftBody * (*func)(const NxSoftBodyDesc & softBodyDesc) = (NxSoftBody * (*)(const NxSoftBodyDesc & softBodyDesc))(functionPointers[NxScene_doxybind::getPointerStart() + 174]);
    return func(softBodyDesc);
}

void NxScene_doxybind::releaseSoftBody(NxSoftBody & softBody) 
{
    void (*func)(NxSoftBody & softBody) = (void (*)(NxSoftBody & softBody))(functionPointers[NxScene_doxybind::getPointerStart() + 175]);
     func(softBody);
}

NxU32 NxScene_doxybind::getNbSoftBodies() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxScene_doxybind::getPointerStart() + 176]);
    return func();
}

NxSoftBody ** NxScene_doxybind::getSoftBodies() 
{
    NxSoftBody ** (*func)() = (NxSoftBody ** (*)())(functionPointers[NxScene_doxybind::getPointerStart() + 177]);
    return func();
}

NxScene_doxybind::NxScene_doxybind() : NxScene()
{
}

bool NxScene_doxybind::saveToDesc(NxSceneDesc & desc) const
{
    bool (*func)(NxSceneDesc & desc) = (bool (*)(NxSceneDesc & desc))(functionPointers[NxScene_doxybind::getPointerStart() + 178]);
    return func(desc);
}

NxU32 NxScene_doxybind::getFlags() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxScene_doxybind::getPointerStart() + 179]);
    return func();
}

NxSimulationType NxScene_doxybind::getSimType() const
{
    NxSimulationType (*func)() = (NxSimulationType (*)())(functionPointers[NxScene_doxybind::getPointerStart() + 180]);
    return func();
}

void * NxScene_doxybind::getInternal() 
{
    void * (*func)() = (void * (*)())(functionPointers[NxScene_doxybind::getPointerStart() + 181]);
    return func();
}

void NxScene_doxybind::setGravity(const NxVec3 & vec) 
{
    void (*func)(const NxVec3 & vec) = (void (*)(const NxVec3 & vec))(functionPointers[NxScene_doxybind::getPointerStart() + 182]);
     func(vec);
}

void NxScene_doxybind::getGravity(NxVec3 & vec) 
{
    void (*func)(NxVec3 & vec) = (void (*)(NxVec3 & vec))(functionPointers[NxScene_doxybind::getPointerStart() + 183]);
     func(vec);
}

void NxScene_doxybind::flushStream() 
{
    void (*func)() = (void (*)())(functionPointers[NxScene_doxybind::getPointerStart() + 184]);
     func();
}

void NxScene_doxybind::setTiming(NxReal maxTimestep, NxU32 maxIter, NxTimeStepMethod method) 
{
    void (*func)(NxReal maxTimestep, NxU32 maxIter, NxTimeStepMethod method) = (void (*)(NxReal maxTimestep, NxU32 maxIter, NxTimeStepMethod method))(functionPointers[NxScene_doxybind::getPointerStart() + 185]);
     func(maxTimestep, maxIter, method);
}

void NxScene_doxybind::setTiming(NxReal maxTimestep, NxU32 maxIter) 
{
    void (*func)(NxReal maxTimestep, NxU32 maxIter) = (void (*)(NxReal maxTimestep, NxU32 maxIter))(functionPointers[NxScene_doxybind::getPointerStart() + 186]);
     func(maxTimestep, maxIter);
}

void NxScene_doxybind::setTiming(NxReal maxTimestep) 
{
    void (*func)(NxReal maxTimestep) = (void (*)(NxReal maxTimestep))(functionPointers[NxScene_doxybind::getPointerStart() + 187]);
     func(maxTimestep);
}

void NxScene_doxybind::getTiming(NxReal & maxTimestep, NxU32 & maxIter, NxTimeStepMethod & method, NxU32 * numSubSteps) const
{
    void (*func)(NxReal & maxTimestep, NxU32 & maxIter, NxTimeStepMethod & method, NxU32 * numSubSteps) = (void (*)(NxReal & maxTimestep, NxU32 & maxIter, NxTimeStepMethod & method, NxU32 * numSubSteps))(functionPointers[NxScene_doxybind::getPointerStart() + 188]);
     func(maxTimestep, maxIter, method, numSubSteps);
}

void NxScene_doxybind::getTiming(NxReal & maxTimestep, NxU32 & maxIter, NxTimeStepMethod & method) const
{
    void (*func)(NxReal & maxTimestep, NxU32 & maxIter, NxTimeStepMethod & method) = (void (*)(NxReal & maxTimestep, NxU32 & maxIter, NxTimeStepMethod & method))(functionPointers[NxScene_doxybind::getPointerStart() + 189]);
     func(maxTimestep, maxIter, method);
}

const NxDebugRenderable * NxScene_doxybind::getDebugRenderable() 
{
    const NxDebugRenderable * (*func)() = (const NxDebugRenderable * (*)())(functionPointers[NxScene_doxybind::getPointerStart() + 190]);
    return func();
}

NxPhysicsSDK & NxScene_doxybind::getPhysicsSDK() 
{
    NxPhysicsSDK & (*func)() = (NxPhysicsSDK & (*)())(functionPointers[NxScene_doxybind::getPointerStart() + 191]);
    return func();
}

void NxScene_doxybind::getStats(NxSceneStats & stats) const
{
    void (*func)(NxSceneStats & stats) = (void (*)(NxSceneStats & stats))(functionPointers[NxScene_doxybind::getPointerStart() + 192]);
     func(stats);
}

const NxSceneStats2 * NxScene_doxybind::getStats2() const
{
    const NxSceneStats2 * (*func)() = (const NxSceneStats2 * (*)())(functionPointers[NxScene_doxybind::getPointerStart() + 193]);
    return func();
}

void NxScene_doxybind::getLimits(NxSceneLimits & limits) const
{
    void (*func)(NxSceneLimits & limits) = (void (*)(NxSceneLimits & limits))(functionPointers[NxScene_doxybind::getPointerStart() + 194]);
     func(limits);
}

void NxScene_doxybind::setMaxCPUForLoadBalancing(NxReal cpuFraction) 
{
    void (*func)(NxReal cpuFraction) = (void (*)(NxReal cpuFraction))(functionPointers[NxScene_doxybind::getPointerStart() + 195]);
     func(cpuFraction);
}

NxReal NxScene_doxybind::getMaxCPUForLoadBalancing() 
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxScene_doxybind::getPointerStart() + 196]);
    return func();
}

bool NxScene_doxybind::isWritable() 
{
    bool (*func)() = (bool (*)())(functionPointers[NxScene_doxybind::getPointerStart() + 197]);
    return func();
}

void NxScene_doxybind::simulate(NxReal elapsedTime) 
{
    void (*func)(NxReal elapsedTime) = (void (*)(NxReal elapsedTime))(functionPointers[NxScene_doxybind::getPointerStart() + 198]);
     func(elapsedTime);
}

bool NxScene_doxybind::checkResults(NxSimulationStatus status, bool block) 
{
    bool (*func)(NxSimulationStatus status, bool block) = (bool (*)(NxSimulationStatus status, bool block))(functionPointers[NxScene_doxybind::getPointerStart() + 199]);
    return func(status, block);
}

bool NxScene_doxybind::checkResults(NxSimulationStatus status) 
{
    bool (*func)(NxSimulationStatus status) = (bool (*)(NxSimulationStatus status))(functionPointers[NxScene_doxybind::getPointerStart() + 200]);
    return func(status);
}

bool NxScene_doxybind::fetchResults(NxSimulationStatus status, bool block, NxU32 * errorState) 
{
    bool (*func)(NxSimulationStatus status, bool block, NxU32 * errorState) = (bool (*)(NxSimulationStatus status, bool block, NxU32 * errorState))(functionPointers[NxScene_doxybind::getPointerStart() + 201]);
    return func(status, block, errorState);
}

bool NxScene_doxybind::fetchResults(NxSimulationStatus status, bool block) 
{
    bool (*func)(NxSimulationStatus status, bool block) = (bool (*)(NxSimulationStatus status, bool block))(functionPointers[NxScene_doxybind::getPointerStart() + 202]);
    return func(status, block);
}

bool NxScene_doxybind::fetchResults(NxSimulationStatus status) 
{
    bool (*func)(NxSimulationStatus status) = (bool (*)(NxSimulationStatus status))(functionPointers[NxScene_doxybind::getPointerStart() + 203]);
    return func(status);
}

void NxScene_doxybind::flushCaches() 
{
    void (*func)() = (void (*)())(functionPointers[NxScene_doxybind::getPointerStart() + 204]);
     func();
}

const NxProfileData * NxScene_doxybind::readProfileData(bool clearData) 
{
    const NxProfileData * (*func)(bool clearData) = (const NxProfileData * (*)(bool clearData))(functionPointers[NxScene_doxybind::getPointerStart() + 205]);
    return func(clearData);
}

NxThreadPollResult NxScene_doxybind::pollForWork(NxThreadWait waitType) 
{
    NxThreadPollResult (*func)(NxThreadWait waitType) = (NxThreadPollResult (*)(NxThreadWait waitType))(functionPointers[NxScene_doxybind::getPointerStart() + 206]);
    return func(waitType);
}

void NxScene_doxybind::resetPollForWork() 
{
    void (*func)() = (void (*)())(functionPointers[NxScene_doxybind::getPointerStart() + 207]);
     func();
}

NxThreadPollResult NxScene_doxybind::pollForBackgroundWork(NxThreadWait waitType) 
{
    NxThreadPollResult (*func)(NxThreadWait waitType) = (NxThreadPollResult (*)(NxThreadWait waitType))(functionPointers[NxScene_doxybind::getPointerStart() + 208]);
    return func(waitType);
}

void NxScene_doxybind::shutdownWorkerThreads() 
{
    void (*func)() = (void (*)())(functionPointers[NxScene_doxybind::getPointerStart() + 209]);
     func();
}

void NxScene_doxybind::lockQueries() 
{
    void (*func)() = (void (*)())(functionPointers[NxScene_doxybind::getPointerStart() + 210]);
     func();
}

void NxScene_doxybind::unlockQueries() 
{
    void (*func)() = (void (*)())(functionPointers[NxScene_doxybind::getPointerStart() + 211]);
     func();
}

NxSceneQuery * NxScene_doxybind::createSceneQuery(const NxSceneQueryDesc & desc) 
{
    NxSceneQuery * (*func)(const NxSceneQueryDesc & desc) = (NxSceneQuery * (*)(const NxSceneQueryDesc & desc))(functionPointers[NxScene_doxybind::getPointerStart() + 212]);
    return func(desc);
}

bool NxScene_doxybind::releaseSceneQuery(NxSceneQuery & query) 
{
    bool (*func)(NxSceneQuery & query) = (bool (*)(NxSceneQuery & query))(functionPointers[NxScene_doxybind::getPointerStart() + 213]);
    return func(query);
}

void NxScene_doxybind::setDynamicTreeRebuildRateHint(NxU32 dynamicTreeRebuildRateHint) 
{
    void (*func)(NxU32 dynamicTreeRebuildRateHint) = (void (*)(NxU32 dynamicTreeRebuildRateHint))(functionPointers[NxScene_doxybind::getPointerStart() + 214]);
     func(dynamicTreeRebuildRateHint);
}

NxU32 NxScene_doxybind::getDynamicTreeRebuildRateHint() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxScene_doxybind::getPointerStart() + 215]);
    return func();
}

void NxScene_doxybind::setSolverBatchSize(NxU32 solverBatchSize) 
{
    void (*func)(NxU32 solverBatchSize) = (void (*)(NxU32 solverBatchSize))(functionPointers[NxScene_doxybind::getPointerStart() + 216]);
     func(solverBatchSize);
}

NxU32 NxScene_doxybind::getSolverBatchSize() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxScene_doxybind::getPointerStart() + 217]);
    return func();
}

NxSceneQueryReport * NxSceneQuery_doxybind::getQueryReport() 
{
    NxSceneQueryReport * (*func)() = (NxSceneQueryReport * (*)())(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 0]);
    return func();
}

NxSceneQueryExecuteMode NxSceneQuery_doxybind::getExecuteMode() 
{
    NxSceneQueryExecuteMode (*func)() = (NxSceneQueryExecuteMode (*)())(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 1]);
    return func();
}

void NxSceneQuery_doxybind::execute() 
{
    void (*func)() = (void (*)())(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 2]);
     func();
}

bool NxSceneQuery_doxybind::finish(bool block) 
{
    bool (*func)(bool block) = (bool (*)(bool block))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 3]);
    return func(block);
}

bool NxSceneQuery_doxybind::raycastAnyShape(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups, NxReal maxDist, const NxGroupsMask * groupsMask, NxShape ** cache, void * userData) const
{
    bool (*func)(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups, NxReal maxDist, const NxGroupsMask * groupsMask, NxShape ** cache, void * userData) = (bool (*)(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups, NxReal maxDist, const NxGroupsMask * groupsMask, NxShape ** cache, void * userData))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 4]);
    return func(worldRay, shapesType, groups, maxDist, groupsMask, cache, userData);
}

bool NxSceneQuery_doxybind::raycastAnyShape(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups, NxReal maxDist, const NxGroupsMask * groupsMask, NxShape ** cache) const
{
    bool (*func)(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups, NxReal maxDist, const NxGroupsMask * groupsMask, NxShape ** cache) = (bool (*)(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups, NxReal maxDist, const NxGroupsMask * groupsMask, NxShape ** cache))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 5]);
    return func(worldRay, shapesType, groups, maxDist, groupsMask, cache);
}

bool NxSceneQuery_doxybind::raycastAnyShape(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups, NxReal maxDist, const NxGroupsMask * groupsMask) const
{
    bool (*func)(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups, NxReal maxDist, const NxGroupsMask * groupsMask) = (bool (*)(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups, NxReal maxDist, const NxGroupsMask * groupsMask))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 6]);
    return func(worldRay, shapesType, groups, maxDist, groupsMask);
}

bool NxSceneQuery_doxybind::raycastAnyShape(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups, NxReal maxDist) const
{
    bool (*func)(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups, NxReal maxDist) = (bool (*)(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups, NxReal maxDist))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 7]);
    return func(worldRay, shapesType, groups, maxDist);
}

bool NxSceneQuery_doxybind::raycastAnyShape(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups) const
{
    bool (*func)(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups) = (bool (*)(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 8]);
    return func(worldRay, shapesType, groups);
}

bool NxSceneQuery_doxybind::raycastAnyShape(const NxRay & worldRay, NxShapesType shapesType) const
{
    bool (*func)(const NxRay & worldRay, NxShapesType shapesType) = (bool (*)(const NxRay & worldRay, NxShapesType shapesType))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 9]);
    return func(worldRay, shapesType);
}

bool NxSceneQuery_doxybind::checkOverlapSphere(const NxSphere & worldSphere, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask, void * userData) const
{
    bool (*func)(const NxSphere & worldSphere, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask, void * userData) = (bool (*)(const NxSphere & worldSphere, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask, void * userData))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 10]);
    return func(worldSphere, shapesType, activeGroups, groupsMask, userData);
}

bool NxSceneQuery_doxybind::checkOverlapSphere(const NxSphere & worldSphere, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask) const
{
    bool (*func)(const NxSphere & worldSphere, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask) = (bool (*)(const NxSphere & worldSphere, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 11]);
    return func(worldSphere, shapesType, activeGroups, groupsMask);
}

bool NxSceneQuery_doxybind::checkOverlapSphere(const NxSphere & worldSphere, NxShapesType shapesType, NxU32 activeGroups) const
{
    bool (*func)(const NxSphere & worldSphere, NxShapesType shapesType, NxU32 activeGroups) = (bool (*)(const NxSphere & worldSphere, NxShapesType shapesType, NxU32 activeGroups))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 12]);
    return func(worldSphere, shapesType, activeGroups);
}

bool NxSceneQuery_doxybind::checkOverlapSphere(const NxSphere & worldSphere, NxShapesType shapesType) const
{
    bool (*func)(const NxSphere & worldSphere, NxShapesType shapesType) = (bool (*)(const NxSphere & worldSphere, NxShapesType shapesType))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 13]);
    return func(worldSphere, shapesType);
}

bool NxSceneQuery_doxybind::checkOverlapSphere(const NxSphere & worldSphere) const
{
    bool (*func)(const NxSphere & worldSphere) = (bool (*)(const NxSphere & worldSphere))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 14]);
    return func(worldSphere);
}

bool NxSceneQuery_doxybind::checkOverlapAABB(const NxBounds3 & worldBounds, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask, void * userData) const
{
    bool (*func)(const NxBounds3 & worldBounds, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask, void * userData) = (bool (*)(const NxBounds3 & worldBounds, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask, void * userData))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 15]);
    return func(worldBounds, shapesType, activeGroups, groupsMask, userData);
}

bool NxSceneQuery_doxybind::checkOverlapAABB(const NxBounds3 & worldBounds, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask) const
{
    bool (*func)(const NxBounds3 & worldBounds, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask) = (bool (*)(const NxBounds3 & worldBounds, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 16]);
    return func(worldBounds, shapesType, activeGroups, groupsMask);
}

bool NxSceneQuery_doxybind::checkOverlapAABB(const NxBounds3 & worldBounds, NxShapesType shapesType, NxU32 activeGroups) const
{
    bool (*func)(const NxBounds3 & worldBounds, NxShapesType shapesType, NxU32 activeGroups) = (bool (*)(const NxBounds3 & worldBounds, NxShapesType shapesType, NxU32 activeGroups))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 17]);
    return func(worldBounds, shapesType, activeGroups);
}

bool NxSceneQuery_doxybind::checkOverlapAABB(const NxBounds3 & worldBounds, NxShapesType shapesType) const
{
    bool (*func)(const NxBounds3 & worldBounds, NxShapesType shapesType) = (bool (*)(const NxBounds3 & worldBounds, NxShapesType shapesType))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 18]);
    return func(worldBounds, shapesType);
}

bool NxSceneQuery_doxybind::checkOverlapAABB(const NxBounds3 & worldBounds) const
{
    bool (*func)(const NxBounds3 & worldBounds) = (bool (*)(const NxBounds3 & worldBounds))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 19]);
    return func(worldBounds);
}

bool NxSceneQuery_doxybind::checkOverlapOBB(const NxBox & worldBox, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask, void * userData) const
{
    bool (*func)(const NxBox & worldBox, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask, void * userData) = (bool (*)(const NxBox & worldBox, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask, void * userData))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 20]);
    return func(worldBox, shapesType, activeGroups, groupsMask, userData);
}

bool NxSceneQuery_doxybind::checkOverlapOBB(const NxBox & worldBox, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask) const
{
    bool (*func)(const NxBox & worldBox, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask) = (bool (*)(const NxBox & worldBox, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 21]);
    return func(worldBox, shapesType, activeGroups, groupsMask);
}

bool NxSceneQuery_doxybind::checkOverlapOBB(const NxBox & worldBox, NxShapesType shapesType, NxU32 activeGroups) const
{
    bool (*func)(const NxBox & worldBox, NxShapesType shapesType, NxU32 activeGroups) = (bool (*)(const NxBox & worldBox, NxShapesType shapesType, NxU32 activeGroups))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 22]);
    return func(worldBox, shapesType, activeGroups);
}

bool NxSceneQuery_doxybind::checkOverlapOBB(const NxBox & worldBox, NxShapesType shapesType) const
{
    bool (*func)(const NxBox & worldBox, NxShapesType shapesType) = (bool (*)(const NxBox & worldBox, NxShapesType shapesType))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 23]);
    return func(worldBox, shapesType);
}

bool NxSceneQuery_doxybind::checkOverlapOBB(const NxBox & worldBox) const
{
    bool (*func)(const NxBox & worldBox) = (bool (*)(const NxBox & worldBox))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 24]);
    return func(worldBox);
}

bool NxSceneQuery_doxybind::checkOverlapCapsule(const NxCapsule & worldCapsule, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask, void * userData) const
{
    bool (*func)(const NxCapsule & worldCapsule, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask, void * userData) = (bool (*)(const NxCapsule & worldCapsule, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask, void * userData))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 25]);
    return func(worldCapsule, shapesType, activeGroups, groupsMask, userData);
}

bool NxSceneQuery_doxybind::checkOverlapCapsule(const NxCapsule & worldCapsule, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask) const
{
    bool (*func)(const NxCapsule & worldCapsule, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask) = (bool (*)(const NxCapsule & worldCapsule, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 26]);
    return func(worldCapsule, shapesType, activeGroups, groupsMask);
}

bool NxSceneQuery_doxybind::checkOverlapCapsule(const NxCapsule & worldCapsule, NxShapesType shapesType, NxU32 activeGroups) const
{
    bool (*func)(const NxCapsule & worldCapsule, NxShapesType shapesType, NxU32 activeGroups) = (bool (*)(const NxCapsule & worldCapsule, NxShapesType shapesType, NxU32 activeGroups))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 27]);
    return func(worldCapsule, shapesType, activeGroups);
}

bool NxSceneQuery_doxybind::checkOverlapCapsule(const NxCapsule & worldCapsule, NxShapesType shapesType) const
{
    bool (*func)(const NxCapsule & worldCapsule, NxShapesType shapesType) = (bool (*)(const NxCapsule & worldCapsule, NxShapesType shapesType))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 28]);
    return func(worldCapsule, shapesType);
}

bool NxSceneQuery_doxybind::checkOverlapCapsule(const NxCapsule & worldCapsule) const
{
    bool (*func)(const NxCapsule & worldCapsule) = (bool (*)(const NxCapsule & worldCapsule))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 29]);
    return func(worldCapsule);
}

NxShape * NxSceneQuery_doxybind::raycastClosestShape(const NxRay & worldRay, NxShapesType shapesType, NxRaycastHit & hit, NxU32 groups, NxReal maxDist, NxU32 hintFlags, const NxGroupsMask * groupsMask, NxShape ** cache, void * userData) const
{
    NxShape * (*func)(const NxRay & worldRay, NxShapesType shapesType, NxRaycastHit & hit, NxU32 groups, NxReal maxDist, NxU32 hintFlags, const NxGroupsMask * groupsMask, NxShape ** cache, void * userData) = (NxShape * (*)(const NxRay & worldRay, NxShapesType shapesType, NxRaycastHit & hit, NxU32 groups, NxReal maxDist, NxU32 hintFlags, const NxGroupsMask * groupsMask, NxShape ** cache, void * userData))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 30]);
    return func(worldRay, shapesType, hit, groups, maxDist, hintFlags, groupsMask, cache, userData);
}

NxShape * NxSceneQuery_doxybind::raycastClosestShape(const NxRay & worldRay, NxShapesType shapesType, NxRaycastHit & hit, NxU32 groups, NxReal maxDist, NxU32 hintFlags, const NxGroupsMask * groupsMask, NxShape ** cache) const
{
    NxShape * (*func)(const NxRay & worldRay, NxShapesType shapesType, NxRaycastHit & hit, NxU32 groups, NxReal maxDist, NxU32 hintFlags, const NxGroupsMask * groupsMask, NxShape ** cache) = (NxShape * (*)(const NxRay & worldRay, NxShapesType shapesType, NxRaycastHit & hit, NxU32 groups, NxReal maxDist, NxU32 hintFlags, const NxGroupsMask * groupsMask, NxShape ** cache))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 31]);
    return func(worldRay, shapesType, hit, groups, maxDist, hintFlags, groupsMask, cache);
}

NxShape * NxSceneQuery_doxybind::raycastClosestShape(const NxRay & worldRay, NxShapesType shapesType, NxRaycastHit & hit, NxU32 groups, NxReal maxDist, NxU32 hintFlags, const NxGroupsMask * groupsMask) const
{
    NxShape * (*func)(const NxRay & worldRay, NxShapesType shapesType, NxRaycastHit & hit, NxU32 groups, NxReal maxDist, NxU32 hintFlags, const NxGroupsMask * groupsMask) = (NxShape * (*)(const NxRay & worldRay, NxShapesType shapesType, NxRaycastHit & hit, NxU32 groups, NxReal maxDist, NxU32 hintFlags, const NxGroupsMask * groupsMask))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 32]);
    return func(worldRay, shapesType, hit, groups, maxDist, hintFlags, groupsMask);
}

NxShape * NxSceneQuery_doxybind::raycastClosestShape(const NxRay & worldRay, NxShapesType shapesType, NxRaycastHit & hit, NxU32 groups, NxReal maxDist, NxU32 hintFlags) const
{
    NxShape * (*func)(const NxRay & worldRay, NxShapesType shapesType, NxRaycastHit & hit, NxU32 groups, NxReal maxDist, NxU32 hintFlags) = (NxShape * (*)(const NxRay & worldRay, NxShapesType shapesType, NxRaycastHit & hit, NxU32 groups, NxReal maxDist, NxU32 hintFlags))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 33]);
    return func(worldRay, shapesType, hit, groups, maxDist, hintFlags);
}

NxShape * NxSceneQuery_doxybind::raycastClosestShape(const NxRay & worldRay, NxShapesType shapesType, NxRaycastHit & hit, NxU32 groups, NxReal maxDist) const
{
    NxShape * (*func)(const NxRay & worldRay, NxShapesType shapesType, NxRaycastHit & hit, NxU32 groups, NxReal maxDist) = (NxShape * (*)(const NxRay & worldRay, NxShapesType shapesType, NxRaycastHit & hit, NxU32 groups, NxReal maxDist))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 34]);
    return func(worldRay, shapesType, hit, groups, maxDist);
}

NxShape * NxSceneQuery_doxybind::raycastClosestShape(const NxRay & worldRay, NxShapesType shapesType, NxRaycastHit & hit, NxU32 groups) const
{
    NxShape * (*func)(const NxRay & worldRay, NxShapesType shapesType, NxRaycastHit & hit, NxU32 groups) = (NxShape * (*)(const NxRay & worldRay, NxShapesType shapesType, NxRaycastHit & hit, NxU32 groups))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 35]);
    return func(worldRay, shapesType, hit, groups);
}

NxShape * NxSceneQuery_doxybind::raycastClosestShape(const NxRay & worldRay, NxShapesType shapesType, NxRaycastHit & hit) const
{
    NxShape * (*func)(const NxRay & worldRay, NxShapesType shapesType, NxRaycastHit & hit) = (NxShape * (*)(const NxRay & worldRay, NxShapesType shapesType, NxRaycastHit & hit))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 36]);
    return func(worldRay, shapesType, hit);
}

NxU32 NxSceneQuery_doxybind::raycastAllShapes(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups, NxReal maxDist, NxU32 hintFlags, const NxGroupsMask * groupsMask, void * userData) const
{
    NxU32 (*func)(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups, NxReal maxDist, NxU32 hintFlags, const NxGroupsMask * groupsMask, void * userData) = (NxU32 (*)(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups, NxReal maxDist, NxU32 hintFlags, const NxGroupsMask * groupsMask, void * userData))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 37]);
    return func(worldRay, shapesType, groups, maxDist, hintFlags, groupsMask, userData);
}

NxU32 NxSceneQuery_doxybind::raycastAllShapes(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups, NxReal maxDist, NxU32 hintFlags, const NxGroupsMask * groupsMask) const
{
    NxU32 (*func)(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups, NxReal maxDist, NxU32 hintFlags, const NxGroupsMask * groupsMask) = (NxU32 (*)(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups, NxReal maxDist, NxU32 hintFlags, const NxGroupsMask * groupsMask))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 38]);
    return func(worldRay, shapesType, groups, maxDist, hintFlags, groupsMask);
}

NxU32 NxSceneQuery_doxybind::raycastAllShapes(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups, NxReal maxDist, NxU32 hintFlags) const
{
    NxU32 (*func)(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups, NxReal maxDist, NxU32 hintFlags) = (NxU32 (*)(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups, NxReal maxDist, NxU32 hintFlags))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 39]);
    return func(worldRay, shapesType, groups, maxDist, hintFlags);
}

NxU32 NxSceneQuery_doxybind::raycastAllShapes(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups, NxReal maxDist) const
{
    NxU32 (*func)(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups, NxReal maxDist) = (NxU32 (*)(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups, NxReal maxDist))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 40]);
    return func(worldRay, shapesType, groups, maxDist);
}

NxU32 NxSceneQuery_doxybind::raycastAllShapes(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups) const
{
    NxU32 (*func)(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups) = (NxU32 (*)(const NxRay & worldRay, NxShapesType shapesType, NxU32 groups))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 41]);
    return func(worldRay, shapesType, groups);
}

NxU32 NxSceneQuery_doxybind::raycastAllShapes(const NxRay & worldRay, NxShapesType shapesType) const
{
    NxU32 (*func)(const NxRay & worldRay, NxShapesType shapesType) = (NxU32 (*)(const NxRay & worldRay, NxShapesType shapesType))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 42]);
    return func(worldRay, shapesType);
}

NxU32 NxSceneQuery_doxybind::overlapSphereShapes(const NxSphere & worldSphere, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask, void * userData) const
{
    NxU32 (*func)(const NxSphere & worldSphere, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask, void * userData) = (NxU32 (*)(const NxSphere & worldSphere, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask, void * userData))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 43]);
    return func(worldSphere, shapesType, activeGroups, groupsMask, userData);
}

NxU32 NxSceneQuery_doxybind::overlapSphereShapes(const NxSphere & worldSphere, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask) const
{
    NxU32 (*func)(const NxSphere & worldSphere, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask) = (NxU32 (*)(const NxSphere & worldSphere, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 44]);
    return func(worldSphere, shapesType, activeGroups, groupsMask);
}

NxU32 NxSceneQuery_doxybind::overlapSphereShapes(const NxSphere & worldSphere, NxShapesType shapesType, NxU32 activeGroups) const
{
    NxU32 (*func)(const NxSphere & worldSphere, NxShapesType shapesType, NxU32 activeGroups) = (NxU32 (*)(const NxSphere & worldSphere, NxShapesType shapesType, NxU32 activeGroups))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 45]);
    return func(worldSphere, shapesType, activeGroups);
}

NxU32 NxSceneQuery_doxybind::overlapSphereShapes(const NxSphere & worldSphere, NxShapesType shapesType) const
{
    NxU32 (*func)(const NxSphere & worldSphere, NxShapesType shapesType) = (NxU32 (*)(const NxSphere & worldSphere, NxShapesType shapesType))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 46]);
    return func(worldSphere, shapesType);
}

NxU32 NxSceneQuery_doxybind::overlapAABBShapes(const NxBounds3 & worldBounds, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask, void * userData) const
{
    NxU32 (*func)(const NxBounds3 & worldBounds, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask, void * userData) = (NxU32 (*)(const NxBounds3 & worldBounds, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask, void * userData))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 47]);
    return func(worldBounds, shapesType, activeGroups, groupsMask, userData);
}

NxU32 NxSceneQuery_doxybind::overlapAABBShapes(const NxBounds3 & worldBounds, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask) const
{
    NxU32 (*func)(const NxBounds3 & worldBounds, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask) = (NxU32 (*)(const NxBounds3 & worldBounds, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 48]);
    return func(worldBounds, shapesType, activeGroups, groupsMask);
}

NxU32 NxSceneQuery_doxybind::overlapAABBShapes(const NxBounds3 & worldBounds, NxShapesType shapesType, NxU32 activeGroups) const
{
    NxU32 (*func)(const NxBounds3 & worldBounds, NxShapesType shapesType, NxU32 activeGroups) = (NxU32 (*)(const NxBounds3 & worldBounds, NxShapesType shapesType, NxU32 activeGroups))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 49]);
    return func(worldBounds, shapesType, activeGroups);
}

NxU32 NxSceneQuery_doxybind::overlapAABBShapes(const NxBounds3 & worldBounds, NxShapesType shapesType) const
{
    NxU32 (*func)(const NxBounds3 & worldBounds, NxShapesType shapesType) = (NxU32 (*)(const NxBounds3 & worldBounds, NxShapesType shapesType))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 50]);
    return func(worldBounds, shapesType);
}

NxU32 NxSceneQuery_doxybind::overlapOBBShapes(const NxBox & worldBox, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask, void * userData) const
{
    NxU32 (*func)(const NxBox & worldBox, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask, void * userData) = (NxU32 (*)(const NxBox & worldBox, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask, void * userData))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 51]);
    return func(worldBox, shapesType, activeGroups, groupsMask, userData);
}

NxU32 NxSceneQuery_doxybind::overlapOBBShapes(const NxBox & worldBox, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask) const
{
    NxU32 (*func)(const NxBox & worldBox, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask) = (NxU32 (*)(const NxBox & worldBox, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 52]);
    return func(worldBox, shapesType, activeGroups, groupsMask);
}

NxU32 NxSceneQuery_doxybind::overlapOBBShapes(const NxBox & worldBox, NxShapesType shapesType, NxU32 activeGroups) const
{
    NxU32 (*func)(const NxBox & worldBox, NxShapesType shapesType, NxU32 activeGroups) = (NxU32 (*)(const NxBox & worldBox, NxShapesType shapesType, NxU32 activeGroups))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 53]);
    return func(worldBox, shapesType, activeGroups);
}

NxU32 NxSceneQuery_doxybind::overlapOBBShapes(const NxBox & worldBox, NxShapesType shapesType) const
{
    NxU32 (*func)(const NxBox & worldBox, NxShapesType shapesType) = (NxU32 (*)(const NxBox & worldBox, NxShapesType shapesType))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 54]);
    return func(worldBox, shapesType);
}

NxU32 NxSceneQuery_doxybind::overlapCapsuleShapes(const NxCapsule & worldCapsule, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask, void * userData) const
{
    NxU32 (*func)(const NxCapsule & worldCapsule, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask, void * userData) = (NxU32 (*)(const NxCapsule & worldCapsule, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask, void * userData))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 55]);
    return func(worldCapsule, shapesType, activeGroups, groupsMask, userData);
}

NxU32 NxSceneQuery_doxybind::overlapCapsuleShapes(const NxCapsule & worldCapsule, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask) const
{
    NxU32 (*func)(const NxCapsule & worldCapsule, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask) = (NxU32 (*)(const NxCapsule & worldCapsule, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 56]);
    return func(worldCapsule, shapesType, activeGroups, groupsMask);
}

NxU32 NxSceneQuery_doxybind::overlapCapsuleShapes(const NxCapsule & worldCapsule, NxShapesType shapesType, NxU32 activeGroups) const
{
    NxU32 (*func)(const NxCapsule & worldCapsule, NxShapesType shapesType, NxU32 activeGroups) = (NxU32 (*)(const NxCapsule & worldCapsule, NxShapesType shapesType, NxU32 activeGroups))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 57]);
    return func(worldCapsule, shapesType, activeGroups);
}

NxU32 NxSceneQuery_doxybind::overlapCapsuleShapes(const NxCapsule & worldCapsule, NxShapesType shapesType) const
{
    NxU32 (*func)(const NxCapsule & worldCapsule, NxShapesType shapesType) = (NxU32 (*)(const NxCapsule & worldCapsule, NxShapesType shapesType))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 58]);
    return func(worldCapsule, shapesType);
}

NxU32 NxSceneQuery_doxybind::cullShapes(NxU32 nbPlanes, const NxPlane * worldPlanes, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask, void * userData) const
{
    NxU32 (*func)(NxU32 nbPlanes, const NxPlane * worldPlanes, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask, void * userData) = (NxU32 (*)(NxU32 nbPlanes, const NxPlane * worldPlanes, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask, void * userData))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 59]);
    return func(nbPlanes, worldPlanes, shapesType, activeGroups, groupsMask, userData);
}

NxU32 NxSceneQuery_doxybind::cullShapes(NxU32 nbPlanes, const NxPlane * worldPlanes, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask) const
{
    NxU32 (*func)(NxU32 nbPlanes, const NxPlane * worldPlanes, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask) = (NxU32 (*)(NxU32 nbPlanes, const NxPlane * worldPlanes, NxShapesType shapesType, NxU32 activeGroups, const NxGroupsMask * groupsMask))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 60]);
    return func(nbPlanes, worldPlanes, shapesType, activeGroups, groupsMask);
}

NxU32 NxSceneQuery_doxybind::cullShapes(NxU32 nbPlanes, const NxPlane * worldPlanes, NxShapesType shapesType, NxU32 activeGroups) const
{
    NxU32 (*func)(NxU32 nbPlanes, const NxPlane * worldPlanes, NxShapesType shapesType, NxU32 activeGroups) = (NxU32 (*)(NxU32 nbPlanes, const NxPlane * worldPlanes, NxShapesType shapesType, NxU32 activeGroups))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 61]);
    return func(nbPlanes, worldPlanes, shapesType, activeGroups);
}

NxU32 NxSceneQuery_doxybind::cullShapes(NxU32 nbPlanes, const NxPlane * worldPlanes, NxShapesType shapesType) const
{
    NxU32 (*func)(NxU32 nbPlanes, const NxPlane * worldPlanes, NxShapesType shapesType) = (NxU32 (*)(NxU32 nbPlanes, const NxPlane * worldPlanes, NxShapesType shapesType))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 62]);
    return func(nbPlanes, worldPlanes, shapesType);
}

NxU32 NxSceneQuery_doxybind::linearOBBSweep(const NxBox & worldBox, const NxVec3 & motion, NxU32 flags, NxU32 activeGroups, const NxGroupsMask * groupsMask, void * userData) const
{
    NxU32 (*func)(const NxBox & worldBox, const NxVec3 & motion, NxU32 flags, NxU32 activeGroups, const NxGroupsMask * groupsMask, void * userData) = (NxU32 (*)(const NxBox & worldBox, const NxVec3 & motion, NxU32 flags, NxU32 activeGroups, const NxGroupsMask * groupsMask, void * userData))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 63]);
    return func(worldBox, motion, flags, activeGroups, groupsMask, userData);
}

NxU32 NxSceneQuery_doxybind::linearOBBSweep(const NxBox & worldBox, const NxVec3 & motion, NxU32 flags, NxU32 activeGroups, const NxGroupsMask * groupsMask) const
{
    NxU32 (*func)(const NxBox & worldBox, const NxVec3 & motion, NxU32 flags, NxU32 activeGroups, const NxGroupsMask * groupsMask) = (NxU32 (*)(const NxBox & worldBox, const NxVec3 & motion, NxU32 flags, NxU32 activeGroups, const NxGroupsMask * groupsMask))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 64]);
    return func(worldBox, motion, flags, activeGroups, groupsMask);
}

NxU32 NxSceneQuery_doxybind::linearOBBSweep(const NxBox & worldBox, const NxVec3 & motion, NxU32 flags, NxU32 activeGroups) const
{
    NxU32 (*func)(const NxBox & worldBox, const NxVec3 & motion, NxU32 flags, NxU32 activeGroups) = (NxU32 (*)(const NxBox & worldBox, const NxVec3 & motion, NxU32 flags, NxU32 activeGroups))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 65]);
    return func(worldBox, motion, flags, activeGroups);
}

NxU32 NxSceneQuery_doxybind::linearOBBSweep(const NxBox & worldBox, const NxVec3 & motion, NxU32 flags) const
{
    NxU32 (*func)(const NxBox & worldBox, const NxVec3 & motion, NxU32 flags) = (NxU32 (*)(const NxBox & worldBox, const NxVec3 & motion, NxU32 flags))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 66]);
    return func(worldBox, motion, flags);
}

NxU32 NxSceneQuery_doxybind::linearCapsuleSweep(const NxCapsule & worldCapsule, const NxVec3 & motion, NxU32 flags, NxU32 activeGroups, const NxGroupsMask * groupsMask, void * userData) const
{
    NxU32 (*func)(const NxCapsule & worldCapsule, const NxVec3 & motion, NxU32 flags, NxU32 activeGroups, const NxGroupsMask * groupsMask, void * userData) = (NxU32 (*)(const NxCapsule & worldCapsule, const NxVec3 & motion, NxU32 flags, NxU32 activeGroups, const NxGroupsMask * groupsMask, void * userData))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 67]);
    return func(worldCapsule, motion, flags, activeGroups, groupsMask, userData);
}

NxU32 NxSceneQuery_doxybind::linearCapsuleSweep(const NxCapsule & worldCapsule, const NxVec3 & motion, NxU32 flags, NxU32 activeGroups, const NxGroupsMask * groupsMask) const
{
    NxU32 (*func)(const NxCapsule & worldCapsule, const NxVec3 & motion, NxU32 flags, NxU32 activeGroups, const NxGroupsMask * groupsMask) = (NxU32 (*)(const NxCapsule & worldCapsule, const NxVec3 & motion, NxU32 flags, NxU32 activeGroups, const NxGroupsMask * groupsMask))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 68]);
    return func(worldCapsule, motion, flags, activeGroups, groupsMask);
}

NxU32 NxSceneQuery_doxybind::linearCapsuleSweep(const NxCapsule & worldCapsule, const NxVec3 & motion, NxU32 flags, NxU32 activeGroups) const
{
    NxU32 (*func)(const NxCapsule & worldCapsule, const NxVec3 & motion, NxU32 flags, NxU32 activeGroups) = (NxU32 (*)(const NxCapsule & worldCapsule, const NxVec3 & motion, NxU32 flags, NxU32 activeGroups))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 69]);
    return func(worldCapsule, motion, flags, activeGroups);
}

NxU32 NxSceneQuery_doxybind::linearCapsuleSweep(const NxCapsule & worldCapsule, const NxVec3 & motion, NxU32 flags) const
{
    NxU32 (*func)(const NxCapsule & worldCapsule, const NxVec3 & motion, NxU32 flags) = (NxU32 (*)(const NxCapsule & worldCapsule, const NxVec3 & motion, NxU32 flags))(functionPointers[NxSceneQuery_doxybind::getPointerStart() + 70]);
    return func(worldCapsule, motion, flags);
}

NxQueryReportResult NxSceneQueryReport_doxybind::onBooleanQuery(void * userData, bool result) 
{
    NxQueryReportResult (*func)(void * userData, bool result) = (NxQueryReportResult (*)(void * userData, bool result))(functionPointers[NxSceneQueryReport_doxybind::getPointerStart() + 0]);
    return func(userData, result);
}

NxQueryReportResult NxSceneQueryReport_doxybind::onRaycastQuery(void * userData, NxU32 nbHits, const NxRaycastHit * hits) 
{
    NxQueryReportResult (*func)(void * userData, NxU32 nbHits, const NxRaycastHit * hits) = (NxQueryReportResult (*)(void * userData, NxU32 nbHits, const NxRaycastHit * hits))(functionPointers[NxSceneQueryReport_doxybind::getPointerStart() + 1]);
    return func(userData, nbHits, hits);
}

NxQueryReportResult NxSceneQueryReport_doxybind::onShapeQuery(void * userData, NxU32 nbHits, NxShape ** hits) 
{
    NxQueryReportResult (*func)(void * userData, NxU32 nbHits, NxShape ** hits) = (NxQueryReportResult (*)(void * userData, NxU32 nbHits, NxShape ** hits))(functionPointers[NxSceneQueryReport_doxybind::getPointerStart() + 2]);
    return func(userData, nbHits, hits);
}

NxQueryReportResult NxSceneQueryReport_doxybind::onSweepQuery(void * userData, NxU32 nbHits, NxSweepQueryHit * hits) 
{
    NxQueryReportResult (*func)(void * userData, NxU32 nbHits, NxSweepQueryHit * hits) = (NxQueryReportResult (*)(void * userData, NxU32 nbHits, NxSweepQueryHit * hits))(functionPointers[NxSceneQueryReport_doxybind::getPointerStart() + 3]);
    return func(userData, nbHits, hits);
}

NxSoftBody_doxybind::NxSoftBody_doxybind() : NxSoftBody()
{
}

bool NxSoftBody_doxybind::saveToDesc(NxSoftBodyDesc & desc) const
{
    bool (*func)(NxSoftBodyDesc & desc) = (bool (*)(NxSoftBodyDesc & desc))(functionPointers[NxSoftBody_doxybind::getPointerStart() + 0]);
    return func(desc);
}

NxSoftBodyMesh * NxSoftBody_doxybind::getSoftBodyMesh() const
{
    NxSoftBodyMesh * (*func)() = (NxSoftBodyMesh * (*)())(functionPointers[NxSoftBody_doxybind::getPointerStart() + 1]);
    return func();
}

void NxSoftBody_doxybind::setVolumeStiffness(NxReal stiffness) 
{
    void (*func)(NxReal stiffness) = (void (*)(NxReal stiffness))(functionPointers[NxSoftBody_doxybind::getPointerStart() + 2]);
     func(stiffness);
}

NxReal NxSoftBody_doxybind::getVolumeStiffness() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxSoftBody_doxybind::getPointerStart() + 3]);
    return func();
}

void NxSoftBody_doxybind::setStretchingStiffness(NxReal stiffness) 
{
    void (*func)(NxReal stiffness) = (void (*)(NxReal stiffness))(functionPointers[NxSoftBody_doxybind::getPointerStart() + 4]);
     func(stiffness);
}

NxReal NxSoftBody_doxybind::getStretchingStiffness() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxSoftBody_doxybind::getPointerStart() + 5]);
    return func();
}

void NxSoftBody_doxybind::setDampingCoefficient(NxReal dampingCoefficient) 
{
    void (*func)(NxReal dampingCoefficient) = (void (*)(NxReal dampingCoefficient))(functionPointers[NxSoftBody_doxybind::getPointerStart() + 6]);
     func(dampingCoefficient);
}

NxReal NxSoftBody_doxybind::getDampingCoefficient() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxSoftBody_doxybind::getPointerStart() + 7]);
    return func();
}

void NxSoftBody_doxybind::setFriction(NxReal friction) 
{
    void (*func)(NxReal friction) = (void (*)(NxReal friction))(functionPointers[NxSoftBody_doxybind::getPointerStart() + 8]);
     func(friction);
}

NxReal NxSoftBody_doxybind::getFriction() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxSoftBody_doxybind::getPointerStart() + 9]);
    return func();
}

void NxSoftBody_doxybind::setTearFactor(NxReal factor) 
{
    void (*func)(NxReal factor) = (void (*)(NxReal factor))(functionPointers[NxSoftBody_doxybind::getPointerStart() + 10]);
     func(factor);
}

NxReal NxSoftBody_doxybind::getTearFactor() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxSoftBody_doxybind::getPointerStart() + 11]);
    return func();
}

void NxSoftBody_doxybind::setAttachmentTearFactor(NxReal factor) 
{
    void (*func)(NxReal factor) = (void (*)(NxReal factor))(functionPointers[NxSoftBody_doxybind::getPointerStart() + 12]);
     func(factor);
}

NxReal NxSoftBody_doxybind::getAttachmentTearFactor() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxSoftBody_doxybind::getPointerStart() + 13]);
    return func();
}

void NxSoftBody_doxybind::setParticleRadius(NxReal particleRadius) 
{
    void (*func)(NxReal particleRadius) = (void (*)(NxReal particleRadius))(functionPointers[NxSoftBody_doxybind::getPointerStart() + 14]);
     func(particleRadius);
}

NxReal NxSoftBody_doxybind::getParticleRadius() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxSoftBody_doxybind::getPointerStart() + 15]);
    return func();
}

NxReal NxSoftBody_doxybind::getDensity() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxSoftBody_doxybind::getPointerStart() + 16]);
    return func();
}

NxReal NxSoftBody_doxybind::getRelativeGridSpacing() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxSoftBody_doxybind::getPointerStart() + 17]);
    return func();
}

NxU32 NxSoftBody_doxybind::getSolverIterations() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxSoftBody_doxybind::getPointerStart() + 18]);
    return func();
}

void NxSoftBody_doxybind::setSolverIterations(NxU32 iterations) 
{
    void (*func)(NxU32 iterations) = (void (*)(NxU32 iterations))(functionPointers[NxSoftBody_doxybind::getPointerStart() + 19]);
     func(iterations);
}

void NxSoftBody_doxybind::getWorldBounds(NxBounds3 & bounds) const
{
    void (*func)(NxBounds3 & bounds) = (void (*)(NxBounds3 & bounds))(functionPointers[NxSoftBody_doxybind::getPointerStart() + 20]);
     func(bounds);
}

void NxSoftBody_doxybind::attachToShape(const NxShape * shape, NxU32 attachmentFlags) 
{
    void (*func)(const NxShape * shape, NxU32 attachmentFlags) = (void (*)(const NxShape * shape, NxU32 attachmentFlags))(functionPointers[NxSoftBody_doxybind::getPointerStart() + 21]);
     func(shape, attachmentFlags);
}

void NxSoftBody_doxybind::attachToCollidingShapes(NxU32 attachmentFlags) 
{
    void (*func)(NxU32 attachmentFlags) = (void (*)(NxU32 attachmentFlags))(functionPointers[NxSoftBody_doxybind::getPointerStart() + 22]);
     func(attachmentFlags);
}

void NxSoftBody_doxybind::detachFromShape(const NxShape * shape) 
{
    void (*func)(const NxShape * shape) = (void (*)(const NxShape * shape))(functionPointers[NxSoftBody_doxybind::getPointerStart() + 23]);
     func(shape);
}

void NxSoftBody_doxybind::attachVertexToShape(NxU32 vertexId, const NxShape * shape, const NxVec3 & localPos, NxU32 attachmentFlags) 
{
    void (*func)(NxU32 vertexId, const NxShape * shape, const NxVec3 & localPos, NxU32 attachmentFlags) = (void (*)(NxU32 vertexId, const NxShape * shape, const NxVec3 & localPos, NxU32 attachmentFlags))(functionPointers[NxSoftBody_doxybind::getPointerStart() + 24]);
     func(vertexId, shape, localPos, attachmentFlags);
}

void NxSoftBody_doxybind::attachVertexToGlobalPosition(const NxU32 vertexId, const NxVec3 & pos) 
{
    void (*func)(const NxU32 vertexId, const NxVec3 & pos) = (void (*)(const NxU32 vertexId, const NxVec3 & pos))(functionPointers[NxSoftBody_doxybind::getPointerStart() + 25]);
     func(vertexId, pos);
}

void NxSoftBody_doxybind::freeVertex(const NxU32 vertexId) 
{
    void (*func)(const NxU32 vertexId) = (void (*)(const NxU32 vertexId))(functionPointers[NxSoftBody_doxybind::getPointerStart() + 26]);
     func(vertexId);
}

bool NxSoftBody_doxybind::tearVertex(const NxU32 vertexId, const NxVec3 & normal) 
{
    bool (*func)(const NxU32 vertexId, const NxVec3 & normal) = (bool (*)(const NxU32 vertexId, const NxVec3 & normal))(functionPointers[NxSoftBody_doxybind::getPointerStart() + 27]);
    return func(vertexId, normal);
}

bool NxSoftBody_doxybind::raycast(const NxRay & worldRay, NxVec3 & hit, NxU32 & vertexId) 
{
    bool (*func)(const NxRay & worldRay, NxVec3 & hit, NxU32 & vertexId) = (bool (*)(const NxRay & worldRay, NxVec3 & hit, NxU32 & vertexId))(functionPointers[NxSoftBody_doxybind::getPointerStart() + 28]);
    return func(worldRay, hit, vertexId);
}

void NxSoftBody_doxybind::setGroup(NxCollisionGroup collisionGroup) 
{
    void (*func)(NxCollisionGroup collisionGroup) = (void (*)(NxCollisionGroup collisionGroup))(functionPointers[NxSoftBody_doxybind::getPointerStart() + 29]);
     func(collisionGroup);
}

NxCollisionGroup NxSoftBody_doxybind::getGroup() const
{
    NxCollisionGroup (*func)() = (NxCollisionGroup (*)())(functionPointers[NxSoftBody_doxybind::getPointerStart() + 30]);
    return func();
}

void NxSoftBody_doxybind::setGroupsMask(const NxGroupsMask & groupsMask) 
{
    void (*func)(const NxGroupsMask & groupsMask) = (void (*)(const NxGroupsMask & groupsMask))(functionPointers[NxSoftBody_doxybind::getPointerStart() + 31]);
     func(groupsMask);
}

const NxGroupsMask NxSoftBody_doxybind::getGroupsMask() const
{
    const NxGroupsMask (*func)() = (const NxGroupsMask (*)())(functionPointers[NxSoftBody_doxybind::getPointerStart() + 32]);
    return func();
}

void NxSoftBody_doxybind::setMeshData(NxMeshData & meshData) 
{
    void (*func)(NxMeshData & meshData) = (void (*)(NxMeshData & meshData))(functionPointers[NxSoftBody_doxybind::getPointerStart() + 33]);
     func(meshData);
}

NxMeshData NxSoftBody_doxybind::getMeshData() 
{
    NxMeshData (*func)() = (NxMeshData (*)())(functionPointers[NxSoftBody_doxybind::getPointerStart() + 34]);
    return func();
}

void NxSoftBody_doxybind::setSplitPairData(NxSoftBodySplitPairData & splitPairData) 
{
    void (*func)(NxSoftBodySplitPairData & splitPairData) = (void (*)(NxSoftBodySplitPairData & splitPairData))(functionPointers[NxSoftBody_doxybind::getPointerStart() + 35]);
     func(splitPairData);
}

NxSoftBodySplitPairData NxSoftBody_doxybind::getSplitPairData() 
{
    NxSoftBodySplitPairData (*func)() = (NxSoftBodySplitPairData (*)())(functionPointers[NxSoftBody_doxybind::getPointerStart() + 36]);
    return func();
}

void NxSoftBody_doxybind::setValidBounds(const NxBounds3 & validBounds) 
{
    void (*func)(const NxBounds3 & validBounds) = (void (*)(const NxBounds3 & validBounds))(functionPointers[NxSoftBody_doxybind::getPointerStart() + 37]);
     func(validBounds);
}

void NxSoftBody_doxybind::getValidBounds(NxBounds3 & validBounds) const
{
    void (*func)(NxBounds3 & validBounds) = (void (*)(NxBounds3 & validBounds))(functionPointers[NxSoftBody_doxybind::getPointerStart() + 38]);
     func(validBounds);
}

void NxSoftBody_doxybind::setPosition(const NxVec3 & position, NxU32 vertexId) 
{
    void (*func)(const NxVec3 & position, NxU32 vertexId) = (void (*)(const NxVec3 & position, NxU32 vertexId))(functionPointers[NxSoftBody_doxybind::getPointerStart() + 39]);
     func(position, vertexId);
}

void NxSoftBody_doxybind::setPositions(void * buffer, NxU32 byteStride) 
{
    void (*func)(void * buffer, NxU32 byteStride) = (void (*)(void * buffer, NxU32 byteStride))(functionPointers[NxSoftBody_doxybind::getPointerStart() + 40]);
     func(buffer, byteStride);
}

void NxSoftBody_doxybind::setPositions(void * buffer) 
{
    void (*func)(void * buffer) = (void (*)(void * buffer))(functionPointers[NxSoftBody_doxybind::getPointerStart() + 41]);
     func(buffer);
}

NxVec3 NxSoftBody_doxybind::getPosition(NxU32 vertexId) const
{
    NxVec3 (*func)(NxU32 vertexId) = (NxVec3 (*)(NxU32 vertexId))(functionPointers[NxSoftBody_doxybind::getPointerStart() + 42]);
    return func(vertexId);
}

void NxSoftBody_doxybind::getPositions(void * buffer, NxU32 byteStride) 
{
    void (*func)(void * buffer, NxU32 byteStride) = (void (*)(void * buffer, NxU32 byteStride))(functionPointers[NxSoftBody_doxybind::getPointerStart() + 43]);
     func(buffer, byteStride);
}

void NxSoftBody_doxybind::getPositions(void * buffer) 
{
    void (*func)(void * buffer) = (void (*)(void * buffer))(functionPointers[NxSoftBody_doxybind::getPointerStart() + 44]);
     func(buffer);
}

void NxSoftBody_doxybind::setVelocity(const NxVec3 & velocity, NxU32 vertexId) 
{
    void (*func)(const NxVec3 & velocity, NxU32 vertexId) = (void (*)(const NxVec3 & velocity, NxU32 vertexId))(functionPointers[NxSoftBody_doxybind::getPointerStart() + 45]);
     func(velocity, vertexId);
}

void NxSoftBody_doxybind::setVelocities(void * buffer, NxU32 byteStride) 
{
    void (*func)(void * buffer, NxU32 byteStride) = (void (*)(void * buffer, NxU32 byteStride))(functionPointers[NxSoftBody_doxybind::getPointerStart() + 46]);
     func(buffer, byteStride);
}

void NxSoftBody_doxybind::setVelocities(void * buffer) 
{
    void (*func)(void * buffer) = (void (*)(void * buffer))(functionPointers[NxSoftBody_doxybind::getPointerStart() + 47]);
     func(buffer);
}

NxVec3 NxSoftBody_doxybind::getVelocity(NxU32 vertexId) const
{
    NxVec3 (*func)(NxU32 vertexId) = (NxVec3 (*)(NxU32 vertexId))(functionPointers[NxSoftBody_doxybind::getPointerStart() + 48]);
    return func(vertexId);
}

void NxSoftBody_doxybind::getVelocities(void * buffer, NxU32 byteStride) 
{
    void (*func)(void * buffer, NxU32 byteStride) = (void (*)(void * buffer, NxU32 byteStride))(functionPointers[NxSoftBody_doxybind::getPointerStart() + 49]);
     func(buffer, byteStride);
}

void NxSoftBody_doxybind::getVelocities(void * buffer) 
{
    void (*func)(void * buffer) = (void (*)(void * buffer))(functionPointers[NxSoftBody_doxybind::getPointerStart() + 50]);
     func(buffer);
}

NxU32 NxSoftBody_doxybind::getNumberOfParticles() 
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxSoftBody_doxybind::getPointerStart() + 51]);
    return func();
}

NxU32 NxSoftBody_doxybind::queryShapePointers() 
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxSoftBody_doxybind::getPointerStart() + 52]);
    return func();
}

NxU32 NxSoftBody_doxybind::getStateByteSize() 
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxSoftBody_doxybind::getPointerStart() + 53]);
    return func();
}

void NxSoftBody_doxybind::getShapePointers(NxShape ** shapePointers, NxU32 * flags) 
{
    void (*func)(NxShape ** shapePointers, NxU32 * flags) = (void (*)(NxShape ** shapePointers, NxU32 * flags))(functionPointers[NxSoftBody_doxybind::getPointerStart() + 54]);
     func(shapePointers, flags);
}

void NxSoftBody_doxybind::setShapePointers(NxShape ** shapePointers, unsigned int numShapes) 
{
    void (*func)(NxShape ** shapePointers, unsigned int numShapes) = (void (*)(NxShape ** shapePointers, unsigned int numShapes))(functionPointers[NxSoftBody_doxybind::getPointerStart() + 55]);
     func(shapePointers, numShapes);
}

void NxSoftBody_doxybind::saveStateToStream(NxStream & stream, bool permute) 
{
    void (*func)(NxStream & stream, bool permute) = (void (*)(NxStream & stream, bool permute))(functionPointers[NxSoftBody_doxybind::getPointerStart() + 56]);
     func(stream, permute);
}

void NxSoftBody_doxybind::saveStateToStream(NxStream & stream) 
{
    void (*func)(NxStream & stream) = (void (*)(NxStream & stream))(functionPointers[NxSoftBody_doxybind::getPointerStart() + 57]);
     func(stream);
}

void NxSoftBody_doxybind::loadStateFromStream(NxStream & stream) 
{
    void (*func)(NxStream & stream) = (void (*)(NxStream & stream))(functionPointers[NxSoftBody_doxybind::getPointerStart() + 58]);
     func(stream);
}

void NxSoftBody_doxybind::setCollisionResponseCoefficient(NxReal coefficient) 
{
    void (*func)(NxReal coefficient) = (void (*)(NxReal coefficient))(functionPointers[NxSoftBody_doxybind::getPointerStart() + 59]);
     func(coefficient);
}

NxReal NxSoftBody_doxybind::getCollisionResponseCoefficient() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxSoftBody_doxybind::getPointerStart() + 60]);
    return func();
}

void NxSoftBody_doxybind::setAttachmentResponseCoefficient(NxReal coefficient) 
{
    void (*func)(NxReal coefficient) = (void (*)(NxReal coefficient))(functionPointers[NxSoftBody_doxybind::getPointerStart() + 61]);
     func(coefficient);
}

NxReal NxSoftBody_doxybind::getAttachmentResponseCoefficient() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxSoftBody_doxybind::getPointerStart() + 62]);
    return func();
}

void NxSoftBody_doxybind::setFromFluidResponseCoefficient(NxReal coefficient) 
{
    void (*func)(NxReal coefficient) = (void (*)(NxReal coefficient))(functionPointers[NxSoftBody_doxybind::getPointerStart() + 63]);
     func(coefficient);
}

NxReal NxSoftBody_doxybind::getFromFluidResponseCoefficient() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxSoftBody_doxybind::getPointerStart() + 64]);
    return func();
}

void NxSoftBody_doxybind::setToFluidResponseCoefficient(NxReal coefficient) 
{
    void (*func)(NxReal coefficient) = (void (*)(NxReal coefficient))(functionPointers[NxSoftBody_doxybind::getPointerStart() + 65]);
     func(coefficient);
}

NxReal NxSoftBody_doxybind::getToFluidResponseCoefficient() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxSoftBody_doxybind::getPointerStart() + 66]);
    return func();
}

void NxSoftBody_doxybind::setExternalAcceleration(NxVec3 acceleration) 
{
    void (*func)(NxVec3 acceleration) = (void (*)(NxVec3 acceleration))(functionPointers[NxSoftBody_doxybind::getPointerStart() + 67]);
     func(acceleration);
}

NxVec3 NxSoftBody_doxybind::getExternalAcceleration() const
{
    NxVec3 (*func)() = (NxVec3 (*)())(functionPointers[NxSoftBody_doxybind::getPointerStart() + 68]);
    return func();
}

void NxSoftBody_doxybind::setMinAdhereVelocity(NxReal velocity) 
{
    void (*func)(NxReal velocity) = (void (*)(NxReal velocity))(functionPointers[NxSoftBody_doxybind::getPointerStart() + 69]);
     func(velocity);
}

NxReal NxSoftBody_doxybind::getMinAdhereVelocity() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxSoftBody_doxybind::getPointerStart() + 70]);
    return func();
}

bool NxSoftBody_doxybind::isSleeping() const
{
    bool (*func)() = (bool (*)())(functionPointers[NxSoftBody_doxybind::getPointerStart() + 71]);
    return func();
}

NxReal NxSoftBody_doxybind::getSleepLinearVelocity() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxSoftBody_doxybind::getPointerStart() + 72]);
    return func();
}

void NxSoftBody_doxybind::setSleepLinearVelocity(NxReal threshold) 
{
    void (*func)(NxReal threshold) = (void (*)(NxReal threshold))(functionPointers[NxSoftBody_doxybind::getPointerStart() + 73]);
     func(threshold);
}

void NxSoftBody_doxybind::wakeUp(NxReal wakeCounterValue) 
{
    void (*func)(NxReal wakeCounterValue) = (void (*)(NxReal wakeCounterValue))(functionPointers[NxSoftBody_doxybind::getPointerStart() + 74]);
     func(wakeCounterValue);
}

void NxSoftBody_doxybind::putToSleep() 
{
    void (*func)() = (void (*)())(functionPointers[NxSoftBody_doxybind::getPointerStart() + 75]);
     func();
}

void NxSoftBody_doxybind::setFlags(NxU32 flags) 
{
    void (*func)(NxU32 flags) = (void (*)(NxU32 flags))(functionPointers[NxSoftBody_doxybind::getPointerStart() + 76]);
     func(flags);
}

NxU32 NxSoftBody_doxybind::getFlags() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxSoftBody_doxybind::getPointerStart() + 77]);
    return func();
}

void NxSoftBody_doxybind::setName(const char * name) 
{
    void (*func)(const char * name) = (void (*)(const char * name))(functionPointers[NxSoftBody_doxybind::getPointerStart() + 78]);
     func(name);
}

void NxSoftBody_doxybind::addForceAtVertex(const NxVec3 & force, NxU32 vertexId, NxForceMode mode) 
{
    void (*func)(const NxVec3 & force, NxU32 vertexId, NxForceMode mode) = (void (*)(const NxVec3 & force, NxU32 vertexId, NxForceMode mode))(functionPointers[NxSoftBody_doxybind::getPointerStart() + 79]);
     func(force, vertexId, mode);
}

void NxSoftBody_doxybind::addForceAtVertex(const NxVec3 & force, NxU32 vertexId) 
{
    void (*func)(const NxVec3 & force, NxU32 vertexId) = (void (*)(const NxVec3 & force, NxU32 vertexId))(functionPointers[NxSoftBody_doxybind::getPointerStart() + 80]);
     func(force, vertexId);
}

void NxSoftBody_doxybind::addForceAtPos(const NxVec3 & position, NxReal magnitude, NxReal radius, NxForceMode mode) 
{
    void (*func)(const NxVec3 & position, NxReal magnitude, NxReal radius, NxForceMode mode) = (void (*)(const NxVec3 & position, NxReal magnitude, NxReal radius, NxForceMode mode))(functionPointers[NxSoftBody_doxybind::getPointerStart() + 81]);
     func(position, magnitude, radius, mode);
}

void NxSoftBody_doxybind::addForceAtPos(const NxVec3 & position, NxReal magnitude, NxReal radius) 
{
    void (*func)(const NxVec3 & position, NxReal magnitude, NxReal radius) = (void (*)(const NxVec3 & position, NxReal magnitude, NxReal radius))(functionPointers[NxSoftBody_doxybind::getPointerStart() + 82]);
     func(position, magnitude, radius);
}

bool NxSoftBody_doxybind::overlapAABBTetrahedra(const NxBounds3 & bounds, NxU32 & nb, const NxU32 *& indices) const
{
    bool (*func)(const NxBounds3 & bounds, NxU32 & nb, const NxU32 *& indices) = (bool (*)(const NxBounds3 & bounds, NxU32 & nb, const NxU32 *& indices))(functionPointers[NxSoftBody_doxybind::getPointerStart() + 83]);
    return func(bounds, nb, indices);
}

NxScene & NxSoftBody_doxybind::getScene() const
{
    NxScene & (*func)() = (NxScene & (*)())(functionPointers[NxSoftBody_doxybind::getPointerStart() + 84]);
    return func();
}

const char * NxSoftBody_doxybind::getName() const
{
    const char * (*func)() = (const char * (*)())(functionPointers[NxSoftBody_doxybind::getPointerStart() + 85]);
    return func();
}

NxCompartment * NxSoftBody_doxybind::getCompartment() const
{
    NxCompartment * (*func)() = (NxCompartment * (*)())(functionPointers[NxSoftBody_doxybind::getPointerStart() + 86]);
    return func();
}

NxForceFieldMaterial NxSoftBody_doxybind::getForceFieldMaterial() const
{
    NxForceFieldMaterial (*func)() = (NxForceFieldMaterial (*)())(functionPointers[NxSoftBody_doxybind::getPointerStart() + 87]);
    return func();
}

void NxSoftBody_doxybind::setForceFieldMaterial(NxForceFieldMaterial unknown95) 
{
    void (*func)(NxForceFieldMaterial unknown95) = (void (*)(NxForceFieldMaterial unknown95))(functionPointers[NxSoftBody_doxybind::getPointerStart() + 88]);
     func(unknown95);
}

NxSoftBodyMesh_doxybind::NxSoftBodyMesh_doxybind() : NxSoftBodyMesh()
{
}

bool NxSoftBodyMesh_doxybind::saveToDesc(NxSoftBodyMeshDesc & desc) const
{
    bool (*func)(NxSoftBodyMeshDesc & desc) = (bool (*)(NxSoftBodyMeshDesc & desc))(functionPointers[NxSoftBodyMesh_doxybind::getPointerStart() + 0]);
    return func(desc);
}

NxU32 NxSoftBodyMesh_doxybind::getReferenceCount() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxSoftBodyMesh_doxybind::getPointerStart() + 1]);
    return func();
}

void NxSphereForceFieldShape_doxybind::setRadius(NxReal radius) 
{
    void (*func)(NxReal radius) = (void (*)(NxReal radius))(functionPointers[NxSphereForceFieldShape_doxybind::getPointerStart() + 0]);
     func(radius);
}

NxReal NxSphereForceFieldShape_doxybind::getRadius() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxSphereForceFieldShape_doxybind::getPointerStart() + 1]);
    return func();
}

void NxSphereForceFieldShape_doxybind::saveToDesc(NxSphereForceFieldShapeDesc & desc) const
{
    void (*func)(NxSphereForceFieldShapeDesc & desc) = (void (*)(NxSphereForceFieldShapeDesc & desc))(functionPointers[NxSphereForceFieldShape_doxybind::getPointerStart() + 2]);
     func(desc);
}

NxMat34 NxSphereForceFieldShape_doxybind::getPose() const
{
    NxMat34 (*func)() = (NxMat34 (*)())(functionPointers[NxForceFieldShape_doxybind::getPointerStart() + 0]);
    return func();
}

void NxSphereForceFieldShape_doxybind::setPose(const NxMat34 & unknown6) 
{
    void (*func)(const NxMat34 & unknown6) = (void (*)(const NxMat34 & unknown6))(functionPointers[NxForceFieldShape_doxybind::getPointerStart() + 1]);
     func(unknown6);
}

NxForceField * NxSphereForceFieldShape_doxybind::getForceField() const
{
    NxForceField * (*func)() = (NxForceField * (*)())(functionPointers[NxForceFieldShape_doxybind::getPointerStart() + 2]);
    return func();
}

NxForceFieldShapeGroup & NxSphereForceFieldShape_doxybind::getShapeGroup() const
{
    NxForceFieldShapeGroup & (*func)() = (NxForceFieldShapeGroup & (*)())(functionPointers[NxForceFieldShape_doxybind::getPointerStart() + 3]);
    return func();
}

void NxSphereForceFieldShape_doxybind::setName(const char * name) 
{
    void (*func)(const char * name) = (void (*)(const char * name))(functionPointers[NxForceFieldShape_doxybind::getPointerStart() + 4]);
     func(name);
}

const char * NxSphereForceFieldShape_doxybind::getName() const
{
    const char * (*func)() = (const char * (*)())(functionPointers[NxForceFieldShape_doxybind::getPointerStart() + 5]);
    return func();
}

NxShapeType NxSphereForceFieldShape_doxybind::getType() const
{
    NxShapeType (*func)() = (NxShapeType (*)())(functionPointers[NxForceFieldShape_doxybind::getPointerStart() + 6]);
    return func();
}

NxSphereForceFieldShapeDesc_doxybind::NxSphereForceFieldShapeDesc_doxybind() : NxSphereForceFieldShapeDesc()
{
}

void NxSphereForceFieldShapeDesc_doxybind::setToDefault() 
{
    void (*func)() = (void (*)())(functionPointers[NxSphereForceFieldShapeDesc_doxybind::getPointerStart() + 0]);
     func();
}

bool NxSphereForceFieldShapeDesc_doxybind::isValid() const
{
    bool (*func)() = (bool (*)())(functionPointers[NxSphereForceFieldShapeDesc_doxybind::getPointerStart() + 1]);
    return func();
}

void NxSphereShape_doxybind::setRadius(NxReal radius) 
{
    void (*func)(NxReal radius) = (void (*)(NxReal radius))(functionPointers[NxSphereShape_doxybind::getPointerStart() + 0]);
     func(radius);
}

NxReal NxSphereShape_doxybind::getRadius() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxSphereShape_doxybind::getPointerStart() + 1]);
    return func();
}

void NxSphereShape_doxybind::getWorldSphere(NxSphere & worldSphere) const
{
    void (*func)(NxSphere & worldSphere) = (void (*)(NxSphere & worldSphere))(functionPointers[NxSphereShape_doxybind::getPointerStart() + 2]);
     func(worldSphere);
}

void NxSphereShape_doxybind::saveToDesc(NxSphereShapeDesc & desc) const
{
    void (*func)(NxSphereShapeDesc & desc) = (void (*)(NxSphereShapeDesc & desc))(functionPointers[NxSphereShape_doxybind::getPointerStart() + 3]);
     func(desc);
}

void NxSphereShape_doxybind::setLocalPose(const NxMat34 & mat) 
{
    void (*func)(const NxMat34 & mat) = (void (*)(const NxMat34 & mat))(functionPointers[NxShape_doxybind::getPointerStart() + 0]);
     func(mat);
}

void NxSphereShape_doxybind::setLocalPosition(const NxVec3 & vec) 
{
    void (*func)(const NxVec3 & vec) = (void (*)(const NxVec3 & vec))(functionPointers[NxShape_doxybind::getPointerStart() + 1]);
     func(vec);
}

void NxSphereShape_doxybind::setLocalOrientation(const NxMat33 & mat) 
{
    void (*func)(const NxMat33 & mat) = (void (*)(const NxMat33 & mat))(functionPointers[NxShape_doxybind::getPointerStart() + 2]);
     func(mat);
}

NxMat34 NxSphereShape_doxybind::getLocalPose() const
{
    NxMat34 (*func)() = (NxMat34 (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 3]);
    return func();
}

NxVec3 NxSphereShape_doxybind::getLocalPosition() const
{
    NxVec3 (*func)() = (NxVec3 (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 4]);
    return func();
}

NxMat33 NxSphereShape_doxybind::getLocalOrientation() const
{
    NxMat33 (*func)() = (NxMat33 (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 5]);
    return func();
}

void NxSphereShape_doxybind::setGlobalPose(const NxMat34 & mat) 
{
    void (*func)(const NxMat34 & mat) = (void (*)(const NxMat34 & mat))(functionPointers[NxShape_doxybind::getPointerStart() + 6]);
     func(mat);
}

void NxSphereShape_doxybind::setGlobalPosition(const NxVec3 & vec) 
{
    void (*func)(const NxVec3 & vec) = (void (*)(const NxVec3 & vec))(functionPointers[NxShape_doxybind::getPointerStart() + 7]);
     func(vec);
}

void NxSphereShape_doxybind::setGlobalOrientation(const NxMat33 & mat) 
{
    void (*func)(const NxMat33 & mat) = (void (*)(const NxMat33 & mat))(functionPointers[NxShape_doxybind::getPointerStart() + 8]);
     func(mat);
}

NxMat34 NxSphereShape_doxybind::getGlobalPose() const
{
    NxMat34 (*func)() = (NxMat34 (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 9]);
    return func();
}

NxVec3 NxSphereShape_doxybind::getGlobalPosition() const
{
    NxVec3 (*func)() = (NxVec3 (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 10]);
    return func();
}

NxMat33 NxSphereShape_doxybind::getGlobalOrientation() const
{
    NxMat33 (*func)() = (NxMat33 (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 11]);
    return func();
}

void * NxSphereShape_doxybind::is(NxShapeType type) 
{
    void * (*func)(NxShapeType type) = (void * (*)(NxShapeType type))(functionPointers[NxShape_doxybind::getPointerStart() + 12]);
    return func(type);
}

const void * NxSphereShape_doxybind::is(NxShapeType type) const
{
    const void * (*func)(NxShapeType type) = (const void * (*)(NxShapeType type))(functionPointers[NxShape_doxybind::getPointerStart() + 13]);
    return func(type);
}

bool NxSphereShape_doxybind::raycast(const NxRay & worldRay, NxReal maxDist, NxU32 hintFlags, NxRaycastHit & hit, bool firstHit) const
{
    bool (*func)(const NxRay & worldRay, NxReal maxDist, NxU32 hintFlags, NxRaycastHit & hit, bool firstHit) = (bool (*)(const NxRay & worldRay, NxReal maxDist, NxU32 hintFlags, NxRaycastHit & hit, bool firstHit))(functionPointers[NxShape_doxybind::getPointerStart() + 14]);
    return func(worldRay, maxDist, hintFlags, hit, firstHit);
}

bool NxSphereShape_doxybind::checkOverlapSphere(const NxSphere & worldSphere) const
{
    bool (*func)(const NxSphere & worldSphere) = (bool (*)(const NxSphere & worldSphere))(functionPointers[NxShape_doxybind::getPointerStart() + 15]);
    return func(worldSphere);
}

bool NxSphereShape_doxybind::checkOverlapOBB(const NxBox & worldBox) const
{
    bool (*func)(const NxBox & worldBox) = (bool (*)(const NxBox & worldBox))(functionPointers[NxShape_doxybind::getPointerStart() + 16]);
    return func(worldBox);
}

bool NxSphereShape_doxybind::checkOverlapAABB(const NxBounds3 & worldBounds) const
{
    bool (*func)(const NxBounds3 & worldBounds) = (bool (*)(const NxBounds3 & worldBounds))(functionPointers[NxShape_doxybind::getPointerStart() + 17]);
    return func(worldBounds);
}

bool NxSphereShape_doxybind::checkOverlapCapsule(const NxCapsule & worldCapsule) const
{
    bool (*func)(const NxCapsule & worldCapsule) = (bool (*)(const NxCapsule & worldCapsule))(functionPointers[NxShape_doxybind::getPointerStart() + 18]);
    return func(worldCapsule);
}

NxActor & NxSphereShape_doxybind::getActor() const
{
    NxActor & (*func)() = (NxActor & (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 19]);
    return func();
}

void NxSphereShape_doxybind::setGroup(NxCollisionGroup collisionGroup) 
{
    void (*func)(NxCollisionGroup collisionGroup) = (void (*)(NxCollisionGroup collisionGroup))(functionPointers[NxShape_doxybind::getPointerStart() + 20]);
     func(collisionGroup);
}

NxCollisionGroup NxSphereShape_doxybind::getGroup() const
{
    NxCollisionGroup (*func)() = (NxCollisionGroup (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 21]);
    return func();
}

void NxSphereShape_doxybind::getWorldBounds(NxBounds3 & dest) const
{
    void (*func)(NxBounds3 & dest) = (void (*)(NxBounds3 & dest))(functionPointers[NxShape_doxybind::getPointerStart() + 22]);
     func(dest);
}

void NxSphereShape_doxybind::setFlag(NxShapeFlag flag, bool value) 
{
    void (*func)(NxShapeFlag flag, bool value) = (void (*)(NxShapeFlag flag, bool value))(functionPointers[NxShape_doxybind::getPointerStart() + 23]);
     func(flag, value);
}

NX_BOOL NxSphereShape_doxybind::getFlag(NxShapeFlag flag) const
{
    NX_BOOL (*func)(NxShapeFlag flag) = (NX_BOOL (*)(NxShapeFlag flag))(functionPointers[NxShape_doxybind::getPointerStart() + 24]);
    return func(flag);
}

void NxSphereShape_doxybind::setMaterial(NxMaterialIndex matIndex) 
{
    void (*func)(NxMaterialIndex matIndex) = (void (*)(NxMaterialIndex matIndex))(functionPointers[NxShape_doxybind::getPointerStart() + 25]);
     func(matIndex);
}

NxMaterialIndex NxSphereShape_doxybind::getMaterial() const
{
    NxMaterialIndex (*func)() = (NxMaterialIndex (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 26]);
    return func();
}

void NxSphereShape_doxybind::setSkinWidth(NxReal skinWidth) 
{
    void (*func)(NxReal skinWidth) = (void (*)(NxReal skinWidth))(functionPointers[NxShape_doxybind::getPointerStart() + 27]);
     func(skinWidth);
}

NxReal NxSphereShape_doxybind::getSkinWidth() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 28]);
    return func();
}

NxShapeType NxSphereShape_doxybind::getType() const
{
    NxShapeType (*func)() = (NxShapeType (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 29]);
    return func();
}

void NxSphereShape_doxybind::setCCDSkeleton(NxCCDSkeleton * ccdSkel) 
{
    void (*func)(NxCCDSkeleton * ccdSkel) = (void (*)(NxCCDSkeleton * ccdSkel))(functionPointers[NxShape_doxybind::getPointerStart() + 30]);
     func(ccdSkel);
}

NxCCDSkeleton * NxSphereShape_doxybind::getCCDSkeleton() const
{
    NxCCDSkeleton * (*func)() = (NxCCDSkeleton * (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 31]);
    return func();
}

void NxSphereShape_doxybind::setName(const char * name) 
{
    void (*func)(const char * name) = (void (*)(const char * name))(functionPointers[NxShape_doxybind::getPointerStart() + 32]);
     func(name);
}

const char * NxSphereShape_doxybind::getName() const
{
    const char * (*func)() = (const char * (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 33]);
    return func();
}

void NxSphereShape_doxybind::setGroupsMask(const NxGroupsMask & mask) 
{
    void (*func)(const NxGroupsMask & mask) = (void (*)(const NxGroupsMask & mask))(functionPointers[NxShape_doxybind::getPointerStart() + 34]);
     func(mask);
}

const NxGroupsMask NxSphereShape_doxybind::getGroupsMask() const
{
    const NxGroupsMask (*func)() = (const NxGroupsMask (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 35]);
    return func();
}

NxU32 NxSphereShape_doxybind::getNonInteractingCompartmentTypes() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 36]);
    return func();
}

void NxSphereShape_doxybind::setNonInteractingCompartmentTypes(NxU32 compartmentTypes) 
{
    void (*func)(NxU32 compartmentTypes) = (void (*)(NxU32 compartmentTypes))(functionPointers[NxShape_doxybind::getPointerStart() + 37]);
     func(compartmentTypes);
}

NxSphereShapeDesc_doxybind::NxSphereShapeDesc_doxybind() : NxSphereShapeDesc()
{
}

void NxSphereShapeDesc_doxybind::setToDefault() 
{
    void (*func)() = (void (*)())(functionPointers[NxSphereShapeDesc_doxybind::getPointerStart() + 0]);
     func();
}

bool NxSphereShapeDesc_doxybind::isValid() const
{
    bool (*func)() = (bool (*)())(functionPointers[NxSphereShapeDesc_doxybind::getPointerStart() + 1]);
    return func();
}

void NxSphericalJoint_doxybind::loadFromDesc(const NxSphericalJointDesc & desc) 
{
    void (*func)(const NxSphericalJointDesc & desc) = (void (*)(const NxSphericalJointDesc & desc))(functionPointers[NxSphericalJoint_doxybind::getPointerStart() + 0]);
     func(desc);
}

void NxSphericalJoint_doxybind::saveToDesc(NxSphericalJointDesc & desc) 
{
    void (*func)(NxSphericalJointDesc & desc) = (void (*)(NxSphericalJointDesc & desc))(functionPointers[NxSphericalJoint_doxybind::getPointerStart() + 1]);
     func(desc);
}

void NxSphericalJoint_doxybind::setFlags(NxU32 flags) 
{
    void (*func)(NxU32 flags) = (void (*)(NxU32 flags))(functionPointers[NxSphericalJoint_doxybind::getPointerStart() + 2]);
     func(flags);
}

NxU32 NxSphericalJoint_doxybind::getFlags() 
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxSphericalJoint_doxybind::getPointerStart() + 3]);
    return func();
}

void NxSphericalJoint_doxybind::setProjectionMode(NxJointProjectionMode projectionMode) 
{
    void (*func)(NxJointProjectionMode projectionMode) = (void (*)(NxJointProjectionMode projectionMode))(functionPointers[NxSphericalJoint_doxybind::getPointerStart() + 4]);
     func(projectionMode);
}

NxJointProjectionMode NxSphericalJoint_doxybind::getProjectionMode() 
{
    NxJointProjectionMode (*func)() = (NxJointProjectionMode (*)())(functionPointers[NxSphericalJoint_doxybind::getPointerStart() + 5]);
    return func();
}

void NxSphericalJoint_doxybind::setLimitPoint(const NxVec3 & point, bool pointIsOnActor2) 
{
    void (*func)(const NxVec3 & point, bool pointIsOnActor2) = (void (*)(const NxVec3 & point, bool pointIsOnActor2))(functionPointers[NxJoint_doxybind::getPointerStart() + 0]);
     func(point, pointIsOnActor2);
}

void NxSphericalJoint_doxybind::setLimitPoint(const NxVec3 & point) 
{
    void (*func)(const NxVec3 & point) = (void (*)(const NxVec3 & point))(functionPointers[NxJoint_doxybind::getPointerStart() + 1]);
     func(point);
}

bool NxSphericalJoint_doxybind::getLimitPoint(NxVec3 & worldLimitPoint) 
{
    bool (*func)(NxVec3 & worldLimitPoint) = (bool (*)(NxVec3 & worldLimitPoint))(functionPointers[NxJoint_doxybind::getPointerStart() + 2]);
    return func(worldLimitPoint);
}

bool NxSphericalJoint_doxybind::addLimitPlane(const NxVec3 & normal, const NxVec3 & pointInPlane, NxReal restitution) 
{
    bool (*func)(const NxVec3 & normal, const NxVec3 & pointInPlane, NxReal restitution) = (bool (*)(const NxVec3 & normal, const NxVec3 & pointInPlane, NxReal restitution))(functionPointers[NxJoint_doxybind::getPointerStart() + 3]);
    return func(normal, pointInPlane, restitution);
}

bool NxSphericalJoint_doxybind::addLimitPlane(const NxVec3 & normal, const NxVec3 & pointInPlane) 
{
    bool (*func)(const NxVec3 & normal, const NxVec3 & pointInPlane) = (bool (*)(const NxVec3 & normal, const NxVec3 & pointInPlane))(functionPointers[NxJoint_doxybind::getPointerStart() + 4]);
    return func(normal, pointInPlane);
}

void NxSphericalJoint_doxybind::purgeLimitPlanes() 
{
    void (*func)() = (void (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 5]);
     func();
}

void NxSphericalJoint_doxybind::resetLimitPlaneIterator() 
{
    void (*func)() = (void (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 6]);
     func();
}

bool NxSphericalJoint_doxybind::hasMoreLimitPlanes() 
{
    bool (*func)() = (bool (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 7]);
    return func();
}

bool NxSphericalJoint_doxybind::getNextLimitPlane(NxVec3 & planeNormal, NxReal & planeD, NxReal * restitution) 
{
    bool (*func)(NxVec3 & planeNormal, NxReal & planeD, NxReal * restitution) = (bool (*)(NxVec3 & planeNormal, NxReal & planeD, NxReal * restitution))(functionPointers[NxJoint_doxybind::getPointerStart() + 8]);
    return func(planeNormal, planeD, restitution);
}

bool NxSphericalJoint_doxybind::getNextLimitPlane(NxVec3 & planeNormal, NxReal & planeD) 
{
    bool (*func)(NxVec3 & planeNormal, NxReal & planeD) = (bool (*)(NxVec3 & planeNormal, NxReal & planeD))(functionPointers[NxJoint_doxybind::getPointerStart() + 9]);
    return func(planeNormal, planeD);
}

void * NxSphericalJoint_doxybind::is(NxJointType type) 
{
    void * (*func)(NxJointType type) = (void * (*)(NxJointType type))(functionPointers[NxJoint_doxybind::getPointerStart() + 10]);
    return func(type);
}

void NxSphericalJoint_doxybind::getActors(NxActor ** actor1, NxActor ** actor2) 
{
    void (*func)(NxActor ** actor1, NxActor ** actor2) = (void (*)(NxActor ** actor1, NxActor ** actor2))(functionPointers[NxJoint_doxybind::getPointerStart() + 11]);
     func(actor1, actor2);
}

void NxSphericalJoint_doxybind::setGlobalAnchor(const NxVec3 & vec) 
{
    void (*func)(const NxVec3 & vec) = (void (*)(const NxVec3 & vec))(functionPointers[NxJoint_doxybind::getPointerStart() + 12]);
     func(vec);
}

void NxSphericalJoint_doxybind::setGlobalAxis(const NxVec3 & vec) 
{
    void (*func)(const NxVec3 & vec) = (void (*)(const NxVec3 & vec))(functionPointers[NxJoint_doxybind::getPointerStart() + 13]);
     func(vec);
}

NxVec3 NxSphericalJoint_doxybind::getGlobalAnchor() const
{
    NxVec3 (*func)() = (NxVec3 (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 14]);
    return func();
}

NxVec3 NxSphericalJoint_doxybind::getGlobalAxis() const
{
    NxVec3 (*func)() = (NxVec3 (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 15]);
    return func();
}

NxJointState NxSphericalJoint_doxybind::getState() 
{
    NxJointState (*func)() = (NxJointState (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 16]);
    return func();
}

void NxSphericalJoint_doxybind::setBreakable(NxReal maxForce, NxReal maxTorque) 
{
    void (*func)(NxReal maxForce, NxReal maxTorque) = (void (*)(NxReal maxForce, NxReal maxTorque))(functionPointers[NxJoint_doxybind::getPointerStart() + 17]);
     func(maxForce, maxTorque);
}

void NxSphericalJoint_doxybind::getBreakable(NxReal & maxForce, NxReal & maxTorque) 
{
    void (*func)(NxReal & maxForce, NxReal & maxTorque) = (void (*)(NxReal & maxForce, NxReal & maxTorque))(functionPointers[NxJoint_doxybind::getPointerStart() + 18]);
     func(maxForce, maxTorque);
}

void NxSphericalJoint_doxybind::setSolverExtrapolationFactor(NxReal solverExtrapolationFactor) 
{
    void (*func)(NxReal solverExtrapolationFactor) = (void (*)(NxReal solverExtrapolationFactor))(functionPointers[NxJoint_doxybind::getPointerStart() + 19]);
     func(solverExtrapolationFactor);
}

NxReal NxSphericalJoint_doxybind::getSolverExtrapolationFactor() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 20]);
    return func();
}

void NxSphericalJoint_doxybind::setUseAccelerationSpring(bool b) 
{
    void (*func)(bool b) = (void (*)(bool b))(functionPointers[NxJoint_doxybind::getPointerStart() + 21]);
     func(b);
}

bool NxSphericalJoint_doxybind::getUseAccelerationSpring() const
{
    bool (*func)() = (bool (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 22]);
    return func();
}

NxJointType NxSphericalJoint_doxybind::getType() const
{
    NxJointType (*func)() = (NxJointType (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 23]);
    return func();
}

void NxSphericalJoint_doxybind::setName(const char * name) 
{
    void (*func)(const char * name) = (void (*)(const char * name))(functionPointers[NxJoint_doxybind::getPointerStart() + 24]);
     func(name);
}

const char * NxSphericalJoint_doxybind::getName() const
{
    const char * (*func)() = (const char * (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 25]);
    return func();
}

NxScene & NxSphericalJoint_doxybind::getScene() const
{
    NxScene & (*func)() = (NxScene & (*)())(functionPointers[NxJoint_doxybind::getPointerStart() + 26]);
    return func();
}

NxSphericalJointDesc_doxybind::NxSphericalJointDesc_doxybind() : NxSphericalJointDesc()
{
}

void NxSphericalJointDesc_doxybind::setToDefault() 
{
    void (*func)() = (void (*)())(functionPointers[NxSphericalJointDesc_doxybind::getPointerStart() + 0]);
     func();
}

bool NxSphericalJointDesc_doxybind::isValid() const
{
    bool (*func)() = (bool (*)())(functionPointers[NxSphericalJointDesc_doxybind::getPointerStart() + 1]);
    return func();
}

void NxSpringAndDamperEffector_doxybind::saveToDesc(NxSpringAndDamperEffectorDesc & desc) 
{
    void (*func)(NxSpringAndDamperEffectorDesc & desc) = (void (*)(NxSpringAndDamperEffectorDesc & desc))(functionPointers[NxSpringAndDamperEffector_doxybind::getPointerStart() + 0]);
     func(desc);
}

void NxSpringAndDamperEffector_doxybind::setBodies(NxActor * body1, const NxVec3 & global1, NxActor * body2, const NxVec3 & global2) 
{
    void (*func)(NxActor * body1, const NxVec3 & global1, NxActor * body2, const NxVec3 & global2) = (void (*)(NxActor * body1, const NxVec3 & global1, NxActor * body2, const NxVec3 & global2))(functionPointers[NxSpringAndDamperEffector_doxybind::getPointerStart() + 1]);
     func(body1, global1, body2, global2);
}

void NxSpringAndDamperEffector_doxybind::setLinearSpring(NxReal distCompressSaturate, NxReal distRelaxed, NxReal distStretchSaturate, NxReal maxCompressForce, NxReal maxStretchForce) 
{
    void (*func)(NxReal distCompressSaturate, NxReal distRelaxed, NxReal distStretchSaturate, NxReal maxCompressForce, NxReal maxStretchForce) = (void (*)(NxReal distCompressSaturate, NxReal distRelaxed, NxReal distStretchSaturate, NxReal maxCompressForce, NxReal maxStretchForce))(functionPointers[NxSpringAndDamperEffector_doxybind::getPointerStart() + 2]);
     func(distCompressSaturate, distRelaxed, distStretchSaturate, maxCompressForce, maxStretchForce);
}

void NxSpringAndDamperEffector_doxybind::getLinearSpring(NxReal & distCompressSaturate, NxReal & distRelaxed, NxReal & distStretchSaturate, NxReal & maxCompressForce, NxReal & maxStretchForce) 
{
    void (*func)(NxReal & distCompressSaturate, NxReal & distRelaxed, NxReal & distStretchSaturate, NxReal & maxCompressForce, NxReal & maxStretchForce) = (void (*)(NxReal & distCompressSaturate, NxReal & distRelaxed, NxReal & distStretchSaturate, NxReal & maxCompressForce, NxReal & maxStretchForce))(functionPointers[NxSpringAndDamperEffector_doxybind::getPointerStart() + 3]);
     func(distCompressSaturate, distRelaxed, distStretchSaturate, maxCompressForce, maxStretchForce);
}

void NxSpringAndDamperEffector_doxybind::setLinearDamper(NxReal velCompressSaturate, NxReal velStretchSaturate, NxReal maxCompressForce, NxReal maxStretchForce) 
{
    void (*func)(NxReal velCompressSaturate, NxReal velStretchSaturate, NxReal maxCompressForce, NxReal maxStretchForce) = (void (*)(NxReal velCompressSaturate, NxReal velStretchSaturate, NxReal maxCompressForce, NxReal maxStretchForce))(functionPointers[NxSpringAndDamperEffector_doxybind::getPointerStart() + 4]);
     func(velCompressSaturate, velStretchSaturate, maxCompressForce, maxStretchForce);
}

void NxSpringAndDamperEffector_doxybind::getLinearDamper(NxReal & velCompressSaturate, NxReal & velStretchSaturate, NxReal & maxCompressForce, NxReal & maxStretchForce) 
{
    void (*func)(NxReal & velCompressSaturate, NxReal & velStretchSaturate, NxReal & maxCompressForce, NxReal & maxStretchForce) = (void (*)(NxReal & velCompressSaturate, NxReal & velStretchSaturate, NxReal & maxCompressForce, NxReal & maxStretchForce))(functionPointers[NxSpringAndDamperEffector_doxybind::getPointerStart() + 5]);
     func(velCompressSaturate, velStretchSaturate, maxCompressForce, maxStretchForce);
}

NxEffectorType NxSpringAndDamperEffector_doxybind::getType() const
{
    NxEffectorType (*func)() = (NxEffectorType (*)())(functionPointers[NxEffector_doxybind::getPointerStart() + 0]);
    return func();
}

void NxSpringAndDamperEffector_doxybind::setName(const char * name) 
{
    void (*func)(const char * name) = (void (*)(const char * name))(functionPointers[NxEffector_doxybind::getPointerStart() + 1]);
     func(name);
}

const char * NxSpringAndDamperEffector_doxybind::getName() const
{
    const char * (*func)() = (const char * (*)())(functionPointers[NxEffector_doxybind::getPointerStart() + 2]);
    return func();
}

NxScene & NxSpringAndDamperEffector_doxybind::getScene() const
{
    NxScene & (*func)() = (NxScene & (*)())(functionPointers[NxEffector_doxybind::getPointerStart() + 3]);
    return func();
}

NxSpringAndDamperEffectorDesc_doxybind::NxSpringAndDamperEffectorDesc_doxybind() : NxSpringAndDamperEffectorDesc()
{
}

void NxSpringAndDamperEffectorDesc_doxybind::setToDefault() 
{
    void (*func)() = (void (*)())(functionPointers[NxSpringAndDamperEffectorDesc_doxybind::getPointerStart() + 0]);
     func();
}

bool NxSpringAndDamperEffectorDesc_doxybind::isValid() const
{
    bool (*func)() = (bool (*)())(functionPointers[NxSpringAndDamperEffectorDesc_doxybind::getPointerStart() + 1]);
    return func();
}

NxStream_doxybind::NxStream_doxybind() : NxStream()
{
}

NxU8 NxStream_doxybind::readByte() const
{
    NxU8 (*func)() = (NxU8 (*)())(functionPointers[NxStream_doxybind::getPointerStart() + 0]);
    return func();
}

NxU16 NxStream_doxybind::readWord() const
{
    NxU16 (*func)() = (NxU16 (*)())(functionPointers[NxStream_doxybind::getPointerStart() + 1]);
    return func();
}

NxU32 NxStream_doxybind::readDword() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxStream_doxybind::getPointerStart() + 2]);
    return func();
}

NxF32 NxStream_doxybind::readFloat() const
{
    NxF32 (*func)() = (NxF32 (*)())(functionPointers[NxStream_doxybind::getPointerStart() + 3]);
    return func();
}

NxF64 NxStream_doxybind::readDouble() const
{
    NxF64 (*func)() = (NxF64 (*)())(functionPointers[NxStream_doxybind::getPointerStart() + 4]);
    return func();
}

void NxStream_doxybind::readBuffer(void * buffer, NxU32 size) const
{
    void (*func)(void * buffer, NxU32 size) = (void (*)(void * buffer, NxU32 size))(functionPointers[NxStream_doxybind::getPointerStart() + 5]);
     func(buffer, size);
}

NxStream & NxStream_doxybind::storeByte(NxU8 b) 
{
    NxStream & (*func)(NxU8 b) = (NxStream & (*)(NxU8 b))(functionPointers[NxStream_doxybind::getPointerStart() + 6]);
    return func(b);
}

NxStream & NxStream_doxybind::storeWord(NxU16 w) 
{
    NxStream & (*func)(NxU16 w) = (NxStream & (*)(NxU16 w))(functionPointers[NxStream_doxybind::getPointerStart() + 7]);
    return func(w);
}

NxStream & NxStream_doxybind::storeDword(NxU32 d) 
{
    NxStream & (*func)(NxU32 d) = (NxStream & (*)(NxU32 d))(functionPointers[NxStream_doxybind::getPointerStart() + 8]);
    return func(d);
}

NxStream & NxStream_doxybind::storeFloat(NxF32 f) 
{
    NxStream & (*func)(NxF32 f) = (NxStream & (*)(NxF32 f))(functionPointers[NxStream_doxybind::getPointerStart() + 9]);
    return func(f);
}

NxStream & NxStream_doxybind::storeDouble(NxF64 f) 
{
    NxStream & (*func)(NxF64 f) = (NxStream & (*)(NxF64 f))(functionPointers[NxStream_doxybind::getPointerStart() + 10]);
    return func(f);
}

NxStream & NxStream_doxybind::storeBuffer(const void * buffer, NxU32 size) 
{
    NxStream & (*func)(const void * buffer, NxU32 size) = (NxStream & (*)(const void * buffer, NxU32 size))(functionPointers[NxStream_doxybind::getPointerStart() + 11]);
    return func(buffer, size);
}

NxSweepCache_doxybind::NxSweepCache_doxybind() : NxSweepCache()
{
}

void NxSweepCache_doxybind::setVolume(const NxBox & box) 
{
    void (*func)(const NxBox & box) = (void (*)(const NxBox & box))(functionPointers[NxSweepCache_doxybind::getPointerStart() + 0]);
     func(box);
}

void NxTask_doxybind::execute() 
{
    void (*func)() = (void (*)())(functionPointers[NxTask_doxybind::getPointerStart() + 0]);
     func();
}

NxTireFunctionDesc_doxybind::NxTireFunctionDesc_doxybind() : NxTireFunctionDesc()
{
}

void NxTireFunctionDesc_doxybind::setToDefault() 
{
    void (*func)() = (void (*)())(functionPointers[NxTireFunctionDesc_doxybind::getPointerStart() + 0]);
     func();
}

bool NxTireFunctionDesc_doxybind::isValid() const
{
    bool (*func)() = (bool (*)())(functionPointers[NxTireFunctionDesc_doxybind::getPointerStart() + 1]);
    return func();
}

bool NxTriangleMesh_doxybind::saveToDesc(NxTriangleMeshDesc & desc) const
{
    bool (*func)(NxTriangleMeshDesc & desc) = (bool (*)(NxTriangleMeshDesc & desc))(functionPointers[NxTriangleMesh_doxybind::getPointerStart() + 0]);
    return func(desc);
}

NxU32 NxTriangleMesh_doxybind::getSubmeshCount() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxTriangleMesh_doxybind::getPointerStart() + 1]);
    return func();
}

NxU32 NxTriangleMesh_doxybind::getCount(NxSubmeshIndex submeshIndex, NxInternalArray intArray) const
{
    NxU32 (*func)(NxSubmeshIndex submeshIndex, NxInternalArray intArray) = (NxU32 (*)(NxSubmeshIndex submeshIndex, NxInternalArray intArray))(functionPointers[NxTriangleMesh_doxybind::getPointerStart() + 2]);
    return func(submeshIndex, intArray);
}

NxInternalFormat NxTriangleMesh_doxybind::getFormat(NxSubmeshIndex submeshIndex, NxInternalArray intArray) const
{
    NxInternalFormat (*func)(NxSubmeshIndex submeshIndex, NxInternalArray intArray) = (NxInternalFormat (*)(NxSubmeshIndex submeshIndex, NxInternalArray intArray))(functionPointers[NxTriangleMesh_doxybind::getPointerStart() + 3]);
    return func(submeshIndex, intArray);
}

const void * NxTriangleMesh_doxybind::getBase(NxSubmeshIndex submeshIndex, NxInternalArray intArray) const
{
    const void * (*func)(NxSubmeshIndex submeshIndex, NxInternalArray intArray) = (const void * (*)(NxSubmeshIndex submeshIndex, NxInternalArray intArray))(functionPointers[NxTriangleMesh_doxybind::getPointerStart() + 4]);
    return func(submeshIndex, intArray);
}

NxU32 NxTriangleMesh_doxybind::getStride(NxSubmeshIndex submeshIndex, NxInternalArray intArray) const
{
    NxU32 (*func)(NxSubmeshIndex submeshIndex, NxInternalArray intArray) = (NxU32 (*)(NxSubmeshIndex submeshIndex, NxInternalArray intArray))(functionPointers[NxTriangleMesh_doxybind::getPointerStart() + 5]);
    return func(submeshIndex, intArray);
}

NxU32 NxTriangleMesh_doxybind::getPageCount() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxTriangleMesh_doxybind::getPointerStart() + 6]);
    return func();
}

NxBounds3 NxTriangleMesh_doxybind::getPageBBox(NxU32 pageIndex) const
{
    NxBounds3 (*func)(NxU32 pageIndex) = (NxBounds3 (*)(NxU32 pageIndex))(functionPointers[NxTriangleMesh_doxybind::getPointerStart() + 7]);
    return func(pageIndex);
}

bool NxTriangleMesh_doxybind::loadPMap(const NxPMap & pmap) 
{
    bool (*func)(const NxPMap & pmap) = (bool (*)(const NxPMap & pmap))(functionPointers[NxTriangleMesh_doxybind::getPointerStart() + 8]);
    return func(pmap);
}

bool NxTriangleMesh_doxybind::hasPMap() const
{
    bool (*func)() = (bool (*)())(functionPointers[NxTriangleMesh_doxybind::getPointerStart() + 9]);
    return func();
}

NxU32 NxTriangleMesh_doxybind::getPMapSize() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxTriangleMesh_doxybind::getPointerStart() + 10]);
    return func();
}

bool NxTriangleMesh_doxybind::getPMapData(NxPMap & pmap) const
{
    bool (*func)(NxPMap & pmap) = (bool (*)(NxPMap & pmap))(functionPointers[NxTriangleMesh_doxybind::getPointerStart() + 11]);
    return func(pmap);
}

NxU32 NxTriangleMesh_doxybind::getPMapDensity() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxTriangleMesh_doxybind::getPointerStart() + 12]);
    return func();
}

bool NxTriangleMesh_doxybind::load(const NxStream & stream) 
{
    bool (*func)(const NxStream & stream) = (bool (*)(const NxStream & stream))(functionPointers[NxTriangleMesh_doxybind::getPointerStart() + 13]);
    return func(stream);
}

NxMaterialIndex NxTriangleMesh_doxybind::getTriangleMaterial(NxTriangleID triangleIndex) const
{
    NxMaterialIndex (*func)(NxTriangleID triangleIndex) = (NxMaterialIndex (*)(NxTriangleID triangleIndex))(functionPointers[NxTriangleMesh_doxybind::getPointerStart() + 14]);
    return func(triangleIndex);
}

NxU32 NxTriangleMesh_doxybind::getReferenceCount() 
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxTriangleMesh_doxybind::getPointerStart() + 15]);
    return func();
}

void NxTriangleMesh_doxybind::getMassInformation(NxReal & mass, NxMat33 & localInertia, NxVec3 & localCenterOfMass) const
{
    void (*func)(NxReal & mass, NxMat33 & localInertia, NxVec3 & localCenterOfMass) = (void (*)(NxReal & mass, NxMat33 & localInertia, NxVec3 & localCenterOfMass))(functionPointers[NxTriangleMesh_doxybind::getPointerStart() + 16]);
     func(mass, localInertia, localCenterOfMass);
}

void NxTriangleMeshShape_doxybind::saveToDesc(NxTriangleMeshShapeDesc & desc) const
{
    void (*func)(NxTriangleMeshShapeDesc & desc) = (void (*)(NxTriangleMeshShapeDesc & desc))(functionPointers[NxTriangleMeshShape_doxybind::getPointerStart() + 0]);
     func(desc);
}

NxTriangleMesh & NxTriangleMeshShape_doxybind::getTriangleMesh() 
{
    NxTriangleMesh & (*func)() = (NxTriangleMesh & (*)())(functionPointers[NxTriangleMeshShape_doxybind::getPointerStart() + 1]);
    return func();
}

const NxTriangleMesh & NxTriangleMeshShape_doxybind::getTriangleMesh() const
{
    const NxTriangleMesh & (*func)() = (const NxTriangleMesh & (*)())(functionPointers[NxTriangleMeshShape_doxybind::getPointerStart() + 2]);
    return func();
}

NxU32 NxTriangleMeshShape_doxybind::getTriangle(NxTriangle & triangle, NxTriangle * edgeTri, NxU32 * flags, NxTriangleID triangleIndex, bool worldSpaceTranslation, bool worldSpaceRotation) const
{
    NxU32 (*func)(NxTriangle & triangle, NxTriangle * edgeTri, NxU32 * flags, NxTriangleID triangleIndex, bool worldSpaceTranslation, bool worldSpaceRotation) = (NxU32 (*)(NxTriangle & triangle, NxTriangle * edgeTri, NxU32 * flags, NxTriangleID triangleIndex, bool worldSpaceTranslation, bool worldSpaceRotation))(functionPointers[NxTriangleMeshShape_doxybind::getPointerStart() + 3]);
    return func(triangle, edgeTri, flags, triangleIndex, worldSpaceTranslation, worldSpaceRotation);
}

NxU32 NxTriangleMeshShape_doxybind::getTriangle(NxTriangle & triangle, NxTriangle * edgeTri, NxU32 * flags, NxTriangleID triangleIndex, bool worldSpaceTranslation) const
{
    NxU32 (*func)(NxTriangle & triangle, NxTriangle * edgeTri, NxU32 * flags, NxTriangleID triangleIndex, bool worldSpaceTranslation) = (NxU32 (*)(NxTriangle & triangle, NxTriangle * edgeTri, NxU32 * flags, NxTriangleID triangleIndex, bool worldSpaceTranslation))(functionPointers[NxTriangleMeshShape_doxybind::getPointerStart() + 4]);
    return func(triangle, edgeTri, flags, triangleIndex, worldSpaceTranslation);
}

NxU32 NxTriangleMeshShape_doxybind::getTriangle(NxTriangle & triangle, NxTriangle * edgeTri, NxU32 * flags, NxTriangleID triangleIndex) const
{
    NxU32 (*func)(NxTriangle & triangle, NxTriangle * edgeTri, NxU32 * flags, NxTriangleID triangleIndex) = (NxU32 (*)(NxTriangle & triangle, NxTriangle * edgeTri, NxU32 * flags, NxTriangleID triangleIndex))(functionPointers[NxTriangleMeshShape_doxybind::getPointerStart() + 5]);
    return func(triangle, edgeTri, flags, triangleIndex);
}

bool NxTriangleMeshShape_doxybind::overlapAABBTrianglesDeprecated(const NxBounds3 & bounds, NxU32 flags, NxU32 & nb, const NxU32 *& indices) const
{
    bool (*func)(const NxBounds3 & bounds, NxU32 flags, NxU32 & nb, const NxU32 *& indices) = (bool (*)(const NxBounds3 & bounds, NxU32 flags, NxU32 & nb, const NxU32 *& indices))(functionPointers[NxTriangleMeshShape_doxybind::getPointerStart() + 6]);
    return func(bounds, flags, nb, indices);
}

bool NxTriangleMeshShape_doxybind::overlapAABBTriangles(const NxBounds3 & bounds, NxU32 flags, NxUserEntityReport< NxU32 > * callback) const
{
    bool (*func)(const NxBounds3 & bounds, NxU32 flags, NxUserEntityReport< NxU32 > * callback) = (bool (*)(const NxBounds3 & bounds, NxU32 flags, NxUserEntityReport< NxU32 > * callback))(functionPointers[NxTriangleMeshShape_doxybind::getPointerStart() + 7]);
    return func(bounds, flags, callback);
}

bool NxTriangleMeshShape_doxybind::mapPageInstance(NxU32 pageIndex) 
{
    bool (*func)(NxU32 pageIndex) = (bool (*)(NxU32 pageIndex))(functionPointers[NxTriangleMeshShape_doxybind::getPointerStart() + 8]);
    return func(pageIndex);
}

void NxTriangleMeshShape_doxybind::unmapPageInstance(NxU32 pageIndex) 
{
    void (*func)(NxU32 pageIndex) = (void (*)(NxU32 pageIndex))(functionPointers[NxTriangleMeshShape_doxybind::getPointerStart() + 9]);
     func(pageIndex);
}

bool NxTriangleMeshShape_doxybind::isPageInstanceMapped(NxU32 pageIndex) const
{
    bool (*func)(NxU32 pageIndex) = (bool (*)(NxU32 pageIndex))(functionPointers[NxTriangleMeshShape_doxybind::getPointerStart() + 10]);
    return func(pageIndex);
}

void NxTriangleMeshShape_doxybind::setLocalPose(const NxMat34 & mat) 
{
    void (*func)(const NxMat34 & mat) = (void (*)(const NxMat34 & mat))(functionPointers[NxShape_doxybind::getPointerStart() + 0]);
     func(mat);
}

void NxTriangleMeshShape_doxybind::setLocalPosition(const NxVec3 & vec) 
{
    void (*func)(const NxVec3 & vec) = (void (*)(const NxVec3 & vec))(functionPointers[NxShape_doxybind::getPointerStart() + 1]);
     func(vec);
}

void NxTriangleMeshShape_doxybind::setLocalOrientation(const NxMat33 & mat) 
{
    void (*func)(const NxMat33 & mat) = (void (*)(const NxMat33 & mat))(functionPointers[NxShape_doxybind::getPointerStart() + 2]);
     func(mat);
}

NxMat34 NxTriangleMeshShape_doxybind::getLocalPose() const
{
    NxMat34 (*func)() = (NxMat34 (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 3]);
    return func();
}

NxVec3 NxTriangleMeshShape_doxybind::getLocalPosition() const
{
    NxVec3 (*func)() = (NxVec3 (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 4]);
    return func();
}

NxMat33 NxTriangleMeshShape_doxybind::getLocalOrientation() const
{
    NxMat33 (*func)() = (NxMat33 (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 5]);
    return func();
}

void NxTriangleMeshShape_doxybind::setGlobalPose(const NxMat34 & mat) 
{
    void (*func)(const NxMat34 & mat) = (void (*)(const NxMat34 & mat))(functionPointers[NxShape_doxybind::getPointerStart() + 6]);
     func(mat);
}

void NxTriangleMeshShape_doxybind::setGlobalPosition(const NxVec3 & vec) 
{
    void (*func)(const NxVec3 & vec) = (void (*)(const NxVec3 & vec))(functionPointers[NxShape_doxybind::getPointerStart() + 7]);
     func(vec);
}

void NxTriangleMeshShape_doxybind::setGlobalOrientation(const NxMat33 & mat) 
{
    void (*func)(const NxMat33 & mat) = (void (*)(const NxMat33 & mat))(functionPointers[NxShape_doxybind::getPointerStart() + 8]);
     func(mat);
}

NxMat34 NxTriangleMeshShape_doxybind::getGlobalPose() const
{
    NxMat34 (*func)() = (NxMat34 (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 9]);
    return func();
}

NxVec3 NxTriangleMeshShape_doxybind::getGlobalPosition() const
{
    NxVec3 (*func)() = (NxVec3 (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 10]);
    return func();
}

NxMat33 NxTriangleMeshShape_doxybind::getGlobalOrientation() const
{
    NxMat33 (*func)() = (NxMat33 (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 11]);
    return func();
}

void * NxTriangleMeshShape_doxybind::is(NxShapeType type) 
{
    void * (*func)(NxShapeType type) = (void * (*)(NxShapeType type))(functionPointers[NxShape_doxybind::getPointerStart() + 12]);
    return func(type);
}

const void * NxTriangleMeshShape_doxybind::is(NxShapeType type) const
{
    const void * (*func)(NxShapeType type) = (const void * (*)(NxShapeType type))(functionPointers[NxShape_doxybind::getPointerStart() + 13]);
    return func(type);
}

bool NxTriangleMeshShape_doxybind::raycast(const NxRay & worldRay, NxReal maxDist, NxU32 hintFlags, NxRaycastHit & hit, bool firstHit) const
{
    bool (*func)(const NxRay & worldRay, NxReal maxDist, NxU32 hintFlags, NxRaycastHit & hit, bool firstHit) = (bool (*)(const NxRay & worldRay, NxReal maxDist, NxU32 hintFlags, NxRaycastHit & hit, bool firstHit))(functionPointers[NxShape_doxybind::getPointerStart() + 14]);
    return func(worldRay, maxDist, hintFlags, hit, firstHit);
}

bool NxTriangleMeshShape_doxybind::checkOverlapSphere(const NxSphere & worldSphere) const
{
    bool (*func)(const NxSphere & worldSphere) = (bool (*)(const NxSphere & worldSphere))(functionPointers[NxShape_doxybind::getPointerStart() + 15]);
    return func(worldSphere);
}

bool NxTriangleMeshShape_doxybind::checkOverlapOBB(const NxBox & worldBox) const
{
    bool (*func)(const NxBox & worldBox) = (bool (*)(const NxBox & worldBox))(functionPointers[NxShape_doxybind::getPointerStart() + 16]);
    return func(worldBox);
}

bool NxTriangleMeshShape_doxybind::checkOverlapAABB(const NxBounds3 & worldBounds) const
{
    bool (*func)(const NxBounds3 & worldBounds) = (bool (*)(const NxBounds3 & worldBounds))(functionPointers[NxShape_doxybind::getPointerStart() + 17]);
    return func(worldBounds);
}

bool NxTriangleMeshShape_doxybind::checkOverlapCapsule(const NxCapsule & worldCapsule) const
{
    bool (*func)(const NxCapsule & worldCapsule) = (bool (*)(const NxCapsule & worldCapsule))(functionPointers[NxShape_doxybind::getPointerStart() + 18]);
    return func(worldCapsule);
}

NxActor & NxTriangleMeshShape_doxybind::getActor() const
{
    NxActor & (*func)() = (NxActor & (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 19]);
    return func();
}

void NxTriangleMeshShape_doxybind::setGroup(NxCollisionGroup collisionGroup) 
{
    void (*func)(NxCollisionGroup collisionGroup) = (void (*)(NxCollisionGroup collisionGroup))(functionPointers[NxShape_doxybind::getPointerStart() + 20]);
     func(collisionGroup);
}

NxCollisionGroup NxTriangleMeshShape_doxybind::getGroup() const
{
    NxCollisionGroup (*func)() = (NxCollisionGroup (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 21]);
    return func();
}

void NxTriangleMeshShape_doxybind::getWorldBounds(NxBounds3 & dest) const
{
    void (*func)(NxBounds3 & dest) = (void (*)(NxBounds3 & dest))(functionPointers[NxShape_doxybind::getPointerStart() + 22]);
     func(dest);
}

void NxTriangleMeshShape_doxybind::setFlag(NxShapeFlag flag, bool value) 
{
    void (*func)(NxShapeFlag flag, bool value) = (void (*)(NxShapeFlag flag, bool value))(functionPointers[NxShape_doxybind::getPointerStart() + 23]);
     func(flag, value);
}

NX_BOOL NxTriangleMeshShape_doxybind::getFlag(NxShapeFlag flag) const
{
    NX_BOOL (*func)(NxShapeFlag flag) = (NX_BOOL (*)(NxShapeFlag flag))(functionPointers[NxShape_doxybind::getPointerStart() + 24]);
    return func(flag);
}

void NxTriangleMeshShape_doxybind::setMaterial(NxMaterialIndex matIndex) 
{
    void (*func)(NxMaterialIndex matIndex) = (void (*)(NxMaterialIndex matIndex))(functionPointers[NxShape_doxybind::getPointerStart() + 25]);
     func(matIndex);
}

NxMaterialIndex NxTriangleMeshShape_doxybind::getMaterial() const
{
    NxMaterialIndex (*func)() = (NxMaterialIndex (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 26]);
    return func();
}

void NxTriangleMeshShape_doxybind::setSkinWidth(NxReal skinWidth) 
{
    void (*func)(NxReal skinWidth) = (void (*)(NxReal skinWidth))(functionPointers[NxShape_doxybind::getPointerStart() + 27]);
     func(skinWidth);
}

NxReal NxTriangleMeshShape_doxybind::getSkinWidth() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 28]);
    return func();
}

NxShapeType NxTriangleMeshShape_doxybind::getType() const
{
    NxShapeType (*func)() = (NxShapeType (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 29]);
    return func();
}

void NxTriangleMeshShape_doxybind::setCCDSkeleton(NxCCDSkeleton * ccdSkel) 
{
    void (*func)(NxCCDSkeleton * ccdSkel) = (void (*)(NxCCDSkeleton * ccdSkel))(functionPointers[NxShape_doxybind::getPointerStart() + 30]);
     func(ccdSkel);
}

NxCCDSkeleton * NxTriangleMeshShape_doxybind::getCCDSkeleton() const
{
    NxCCDSkeleton * (*func)() = (NxCCDSkeleton * (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 31]);
    return func();
}

void NxTriangleMeshShape_doxybind::setName(const char * name) 
{
    void (*func)(const char * name) = (void (*)(const char * name))(functionPointers[NxShape_doxybind::getPointerStart() + 32]);
     func(name);
}

const char * NxTriangleMeshShape_doxybind::getName() const
{
    const char * (*func)() = (const char * (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 33]);
    return func();
}

void NxTriangleMeshShape_doxybind::setGroupsMask(const NxGroupsMask & mask) 
{
    void (*func)(const NxGroupsMask & mask) = (void (*)(const NxGroupsMask & mask))(functionPointers[NxShape_doxybind::getPointerStart() + 34]);
     func(mask);
}

const NxGroupsMask NxTriangleMeshShape_doxybind::getGroupsMask() const
{
    const NxGroupsMask (*func)() = (const NxGroupsMask (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 35]);
    return func();
}

NxU32 NxTriangleMeshShape_doxybind::getNonInteractingCompartmentTypes() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 36]);
    return func();
}

void NxTriangleMeshShape_doxybind::setNonInteractingCompartmentTypes(NxU32 compartmentTypes) 
{
    void (*func)(NxU32 compartmentTypes) = (void (*)(NxU32 compartmentTypes))(functionPointers[NxShape_doxybind::getPointerStart() + 37]);
     func(compartmentTypes);
}

NxTriangleMeshShapeDesc_doxybind::NxTriangleMeshShapeDesc_doxybind() : NxTriangleMeshShapeDesc()
{
}

void NxTriangleMeshShapeDesc_doxybind::setToDefault() 
{
    void (*func)() = (void (*)())(functionPointers[NxTriangleMeshShapeDesc_doxybind::getPointerStart() + 0]);
     func();
}

bool NxTriangleMeshShapeDesc_doxybind::isValid() const
{
    bool (*func)() = (bool (*)())(functionPointers[NxTriangleMeshShapeDesc_doxybind::getPointerStart() + 1]);
    return func();
}

void NxUserActorPairFiltering_doxybind::onActorPairs(NxActorPairFilter * filterArray, NxU32 arraySize) 
{
    void (*func)(NxActorPairFilter * filterArray, NxU32 arraySize) = (void (*)(NxActorPairFilter * filterArray, NxU32 arraySize))(functionPointers[NxUserActorPairFiltering_doxybind::getPointerStart() + 0]);
     func(filterArray, arraySize);
}

void * NxUserAllocatorDefault_doxybind::malloc(size_t size, NxMemoryType type) 
{
    void * (*func)(size_t size, NxMemoryType type) = (void * (*)(size_t size, NxMemoryType type))(functionPointers[NxUserAllocatorDefault_doxybind::getPointerStart() + 0]);
    return func(size, type);
}

void * NxUserAllocatorDefault_doxybind::malloc(size_t size) 
{
    void * (*func)(size_t size) = (void * (*)(size_t size))(functionPointers[NxUserAllocatorDefault_doxybind::getPointerStart() + 1]);
    return func(size);
}

void * NxUserAllocatorDefault_doxybind::mallocDEBUG(size_t size, const char * fileName, int line, const char * className, NxMemoryType type) 
{
    void * (*func)(size_t size, const char * fileName, int line, const char * className, NxMemoryType type) = (void * (*)(size_t size, const char * fileName, int line, const char * className, NxMemoryType type))(functionPointers[NxUserAllocatorDefault_doxybind::getPointerStart() + 2]);
    return func(size, fileName, line, className, type);
}

void * NxUserAllocatorDefault_doxybind::mallocDEBUG(size_t size, const char * fileName, int line) 
{
    void * (*func)(size_t size, const char * fileName, int line) = (void * (*)(size_t size, const char * fileName, int line))(functionPointers[NxUserAllocatorDefault_doxybind::getPointerStart() + 3]);
    return func(size, fileName, line);
}

void * NxUserAllocatorDefault_doxybind::realloc(void * memory, size_t size) 
{
    void * (*func)(void * memory, size_t size) = (void * (*)(void * memory, size_t size))(functionPointers[NxUserAllocatorDefault_doxybind::getPointerStart() + 4]);
    return func(memory, size);
}

void NxUserAllocatorDefault_doxybind::free(void * memory) 
{
    void (*func)(void * memory) = (void (*)(void * memory))(functionPointers[NxUserAllocatorDefault_doxybind::getPointerStart() + 5]);
     func(memory);
}

void NxUserAllocatorDefault_doxybind::checkDEBUG() 
{
    void (*func)() = (void (*)())(functionPointers[NxUserAllocator_doxybind::getPointerStart() + 6]);
     func();
}

bool NxUserContactModify_doxybind::onContactConstraint(NxU32 & changeFlags, const NxShape * shape0, const NxShape * shape1, const NxU32 featureIndex0, const NxU32 featureIndex1, NxContactCallbackData & data) 
{
    bool (*func)(NxU32 & changeFlags, const NxShape * shape0, const NxShape * shape1, const NxU32 featureIndex0, const NxU32 featureIndex1, NxContactCallbackData & data) = (bool (*)(NxU32 & changeFlags, const NxShape * shape0, const NxShape * shape1, const NxU32 featureIndex0, const NxU32 featureIndex1, NxContactCallbackData & data))(functionPointers[NxUserContactModify_doxybind::getPointerStart() + 0]);
    return func(changeFlags, shape0, shape1, featureIndex0, featureIndex1, data);
}

void NxUserContactReport_doxybind::onContactNotify(NxContactPair & pair, NxU32 events) 
{
    void (*func)(NxContactPair & pair, NxU32 events) = (void (*)(NxContactPair & pair, NxU32 events))(functionPointers[NxUserContactReport_doxybind::getPointerStart() + 0]);
     func(pair, events);
}

NxControllerAction NxUserControllerHitReport_doxybind::onShapeHit(const NxControllerShapeHit & hit) 
{
    NxControllerAction (*func)(const NxControllerShapeHit & hit) = (NxControllerAction (*)(const NxControllerShapeHit & hit))(functionPointers[NxUserControllerHitReport_doxybind::getPointerStart() + 0]);
    return func(hit);
}

NxControllerAction NxUserControllerHitReport_doxybind::onControllerHit(const NxControllersHit & hit) 
{
    NxControllerAction (*func)(const NxControllersHit & hit) = (NxControllerAction (*)(const NxControllersHit & hit))(functionPointers[NxUserControllerHitReport_doxybind::getPointerStart() + 1]);
    return func(hit);
}

bool NxUserNotify_doxybind::onJointBreak(NxReal breakingImpulse, NxJoint & brokenJoint) 
{
    bool (*func)(NxReal breakingImpulse, NxJoint & brokenJoint) = (bool (*)(NxReal breakingImpulse, NxJoint & brokenJoint))(functionPointers[NxUserNotify_doxybind::getPointerStart() + 0]);
    return func(breakingImpulse, brokenJoint);
}

void NxUserNotify_doxybind::onWake(NxActor ** actors, NxU32 count) 
{
    void (*func)(NxActor ** actors, NxU32 count) = (void (*)(NxActor ** actors, NxU32 count))(functionPointers[NxUserNotify_doxybind::getPointerStart() + 1]);
     func(actors, count);
}

void NxUserNotify_doxybind::onSleep(NxActor ** actors, NxU32 count) 
{
    void (*func)(NxActor ** actors, NxU32 count) = (void (*)(NxActor ** actors, NxU32 count))(functionPointers[NxUserNotify_doxybind::getPointerStart() + 2]);
     func(actors, count);
}

void NxUserOutputStream_doxybind::reportError(NxErrorCode code, const char * message, const char * file, int line) 
{
    void (*func)(NxErrorCode code, const char * message, const char * file, int line) = (void (*)(NxErrorCode code, const char * message, const char * file, int line))(functionPointers[NxUserOutputStream_doxybind::getPointerStart() + 0]);
     func(code, message, file, line);
}

NxAssertResponse NxUserOutputStream_doxybind::reportAssertViolation(const char * message, const char * file, int line) 
{
    NxAssertResponse (*func)(const char * message, const char * file, int line) = (NxAssertResponse (*)(const char * message, const char * file, int line))(functionPointers[NxUserOutputStream_doxybind::getPointerStart() + 1]);
    return func(message, file, line);
}

void NxUserOutputStream_doxybind::print(const char * message) 
{
    void (*func)(const char * message) = (void (*)(const char * message))(functionPointers[NxUserOutputStream_doxybind::getPointerStart() + 2]);
     func(message);
}

bool NxUserRaycastReport_doxybind::onHit(const NxRaycastHit & hits) 
{
    bool (*func)(const NxRaycastHit & hits) = (bool (*)(const NxRaycastHit & hits))(functionPointers[NxUserRaycastReport_doxybind::getPointerStart() + 0]);
    return func(hits);
}

void NxUserScheduler_doxybind::addTask(NxTask * task) 
{
    void (*func)(NxTask * task) = (void (*)(NxTask * task))(functionPointers[NxUserScheduler_doxybind::getPointerStart() + 0]);
     func(task);
}

void NxUserScheduler_doxybind::addBackgroundTask(NxTask * task) 
{
    void (*func)(NxTask * task) = (void (*)(NxTask * task))(functionPointers[NxUserScheduler_doxybind::getPointerStart() + 1]);
     func(task);
}

void NxUserScheduler_doxybind::waitTasksComplete() 
{
    void (*func)() = (void (*)())(functionPointers[NxUserScheduler_doxybind::getPointerStart() + 2]);
     func();
}

void NxUserTriggerReport_doxybind::onTrigger(NxShape & triggerShape, NxShape & otherShape, NxTriggerFlag status) 
{
    void (*func)(NxShape & triggerShape, NxShape & otherShape, NxTriggerFlag status) = (void (*)(NxShape & triggerShape, NxShape & otherShape, NxTriggerFlag status))(functionPointers[NxUserTriggerReport_doxybind::getPointerStart() + 0]);
     func(triggerShape, otherShape, status);
}

bool NxUserWheelContactModify_doxybind::onWheelContact(NxWheelShape * wheelShape, NxVec3 & contactPoint, NxVec3 & contactNormal, NxReal & contactPosition, NxReal & normalForce, NxShape * otherShape, NxMaterialIndex & otherShapeMaterialIndex, NxU32 otherShapeFeatureIndex) 
{
    bool (*func)(NxWheelShape * wheelShape, NxVec3 & contactPoint, NxVec3 & contactNormal, NxReal & contactPosition, NxReal & normalForce, NxShape * otherShape, NxMaterialIndex & otherShapeMaterialIndex, NxU32 otherShapeFeatureIndex) = (bool (*)(NxWheelShape * wheelShape, NxVec3 & contactPoint, NxVec3 & contactNormal, NxReal & contactPosition, NxReal & normalForce, NxShape * otherShape, NxMaterialIndex & otherShapeMaterialIndex, NxU32 otherShapeFeatureIndex))(functionPointers[NxUserWheelContactModify_doxybind::getPointerStart() + 0]);
    return func(wheelShape, contactPoint, contactNormal, contactPosition, normalForce, otherShape, otherShapeMaterialIndex, otherShapeFeatureIndex);
}

bool NxUtilLib_doxybind::NxBoxContainsPoint(const NxBox & box, const NxVec3 & p) 
{
    bool (*func)(const NxBox & box, const NxVec3 & p) = (bool (*)(const NxBox & box, const NxVec3 & p))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 0]);
    return func(box, p);
}

void NxUtilLib_doxybind::NxCreateBox(NxBox & box, const NxBounds3 & aabb, const NxMat34 & mat) 
{
    void (*func)(NxBox & box, const NxBounds3 & aabb, const NxMat34 & mat) = (void (*)(NxBox & box, const NxBounds3 & aabb, const NxMat34 & mat))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 1]);
     func(box, aabb, mat);
}

bool NxUtilLib_doxybind::NxComputeBoxPlanes(const NxBox & box, NxPlane * planes) 
{
    bool (*func)(const NxBox & box, NxPlane * planes) = (bool (*)(const NxBox & box, NxPlane * planes))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 2]);
    return func(box, planes);
}

bool NxUtilLib_doxybind::NxComputeBoxPoints(const NxBox & box, NxVec3 * pts) 
{
    bool (*func)(const NxBox & box, NxVec3 * pts) = (bool (*)(const NxBox & box, NxVec3 * pts))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 3]);
    return func(box, pts);
}

bool NxUtilLib_doxybind::NxComputeBoxVertexNormals(const NxBox & box, NxVec3 * pts) 
{
    bool (*func)(const NxBox & box, NxVec3 * pts) = (bool (*)(const NxBox & box, NxVec3 * pts))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 4]);
    return func(box, pts);
}

const NxU32 * NxUtilLib_doxybind::NxGetBoxEdges() 
{
    const NxU32 * (*func)() = (const NxU32 * (*)())(functionPointers[NxUtilLib_doxybind::getPointerStart() + 5]);
    return func();
}

const NxI32 * NxUtilLib_doxybind::NxGetBoxEdgesAxes() 
{
    const NxI32 * (*func)() = (const NxI32 * (*)())(functionPointers[NxUtilLib_doxybind::getPointerStart() + 6]);
    return func();
}

const NxU32 * NxUtilLib_doxybind::NxGetBoxTriangles() 
{
    const NxU32 * (*func)() = (const NxU32 * (*)())(functionPointers[NxUtilLib_doxybind::getPointerStart() + 7]);
    return func();
}

const NxVec3 * NxUtilLib_doxybind::NxGetBoxLocalEdgeNormals() 
{
    const NxVec3 * (*func)() = (const NxVec3 * (*)())(functionPointers[NxUtilLib_doxybind::getPointerStart() + 8]);
    return func();
}

void NxUtilLib_doxybind::NxComputeBoxWorldEdgeNormal(const NxBox & box, NxU32 edge_index, NxVec3 & world_normal) 
{
    void (*func)(const NxBox & box, NxU32 edge_index, NxVec3 & world_normal) = (void (*)(const NxBox & box, NxU32 edge_index, NxVec3 & world_normal))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 9]);
     func(box, edge_index, world_normal);
}

void NxUtilLib_doxybind::NxComputeCapsuleAroundBox(const NxBox & box, NxCapsule & capsule) 
{
    void (*func)(const NxBox & box, NxCapsule & capsule) = (void (*)(const NxBox & box, NxCapsule & capsule))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 10]);
     func(box, capsule);
}

bool NxUtilLib_doxybind::NxIsBoxAInsideBoxB(const NxBox & a, const NxBox & b) 
{
    bool (*func)(const NxBox & a, const NxBox & b) = (bool (*)(const NxBox & a, const NxBox & b))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 11]);
    return func(a, b);
}

const NxU32 * NxUtilLib_doxybind::NxGetBoxQuads() 
{
    const NxU32 * (*func)() = (const NxU32 * (*)())(functionPointers[NxUtilLib_doxybind::getPointerStart() + 12]);
    return func();
}

const NxU32 * NxUtilLib_doxybind::NxBoxVertexToQuad(NxU32 vertexIndex) 
{
    const NxU32 * (*func)(NxU32 vertexIndex) = (const NxU32 * (*)(NxU32 vertexIndex))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 13]);
    return func(vertexIndex);
}

void NxUtilLib_doxybind::NxComputeBoxAroundCapsule(const NxCapsule & capsule, NxBox & box) 
{
    void (*func)(const NxCapsule & capsule, NxBox & box) = (void (*)(const NxCapsule & capsule, NxBox & box))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 14]);
     func(capsule, box);
}

void NxUtilLib_doxybind::NxSetFPUPrecision24() 
{
    void (*func)() = (void (*)())(functionPointers[NxUtilLib_doxybind::getPointerStart() + 15]);
     func();
}

void NxUtilLib_doxybind::NxSetFPUPrecision53() 
{
    void (*func)() = (void (*)())(functionPointers[NxUtilLib_doxybind::getPointerStart() + 16]);
     func();
}

void NxUtilLib_doxybind::NxSetFPUPrecision64() 
{
    void (*func)() = (void (*)())(functionPointers[NxUtilLib_doxybind::getPointerStart() + 17]);
     func();
}

void NxUtilLib_doxybind::NxSetFPURoundingChop() 
{
    void (*func)() = (void (*)())(functionPointers[NxUtilLib_doxybind::getPointerStart() + 18]);
     func();
}

void NxUtilLib_doxybind::NxSetFPURoundingUp() 
{
    void (*func)() = (void (*)())(functionPointers[NxUtilLib_doxybind::getPointerStart() + 19]);
     func();
}

void NxUtilLib_doxybind::NxSetFPURoundingDown() 
{
    void (*func)() = (void (*)())(functionPointers[NxUtilLib_doxybind::getPointerStart() + 20]);
     func();
}

void NxUtilLib_doxybind::NxSetFPURoundingNear() 
{
    void (*func)() = (void (*)())(functionPointers[NxUtilLib_doxybind::getPointerStart() + 21]);
     func();
}

void NxUtilLib_doxybind::NxSetFPUExceptions(bool b) 
{
    void (*func)(bool b) = (void (*)(bool b))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 22]);
     func(b);
}

int NxUtilLib_doxybind::NxIntChop(const NxF32 & f) 
{
    int (*func)(const NxF32 & f) = (int (*)(const NxF32 & f))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 23]);
    return func(f);
}

int NxUtilLib_doxybind::NxIntFloor(const NxF32 & f) 
{
    int (*func)(const NxF32 & f) = (int (*)(const NxF32 & f))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 24]);
    return func(f);
}

int NxUtilLib_doxybind::NxIntCeil(const NxF32 & f) 
{
    int (*func)(const NxF32 & f) = (int (*)(const NxF32 & f))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 25]);
    return func(f);
}

NxF32 NxUtilLib_doxybind::NxComputeDistanceSquared(const NxRay & ray, const NxVec3 & point, NxF32 * t) 
{
    NxF32 (*func)(const NxRay & ray, const NxVec3 & point, NxF32 * t) = (NxF32 (*)(const NxRay & ray, const NxVec3 & point, NxF32 * t))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 26]);
    return func(ray, point, t);
}

NxF32 NxUtilLib_doxybind::NxComputeSquareDistance(const NxSegment & seg, const NxVec3 & point, NxF32 * t) 
{
    NxF32 (*func)(const NxSegment & seg, const NxVec3 & point, NxF32 * t) = (NxF32 (*)(const NxSegment & seg, const NxVec3 & point, NxF32 * t))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 27]);
    return func(seg, point, t);
}

NxBSphereMethod NxUtilLib_doxybind::NxComputeSphere(NxSphere & sphere, unsigned nb_verts, const NxVec3 * verts) 
{
    NxBSphereMethod (*func)(NxSphere & sphere, unsigned nb_verts, const NxVec3 * verts) = (NxBSphereMethod (*)(NxSphere & sphere, unsigned nb_verts, const NxVec3 * verts))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 28]);
    return func(sphere, nb_verts, verts);
}

bool NxUtilLib_doxybind::NxFastComputeSphere(NxSphere & sphere, unsigned nb_verts, const NxVec3 * verts) 
{
    bool (*func)(NxSphere & sphere, unsigned nb_verts, const NxVec3 * verts) = (bool (*)(NxSphere & sphere, unsigned nb_verts, const NxVec3 * verts))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 29]);
    return func(sphere, nb_verts, verts);
}

void NxUtilLib_doxybind::NxMergeSpheres(NxSphere & merged, const NxSphere & sphere0, const NxSphere & sphere1) 
{
    void (*func)(NxSphere & merged, const NxSphere & sphere0, const NxSphere & sphere1) = (void (*)(NxSphere & merged, const NxSphere & sphere0, const NxSphere & sphere1))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 30]);
     func(merged, sphere0, sphere1);
}

void NxUtilLib_doxybind::NxNormalToTangents(const NxVec3 & n, NxVec3 & t1, NxVec3 & t2) 
{
    void (*func)(const NxVec3 & n, NxVec3 & t1, NxVec3 & t2) = (void (*)(const NxVec3 & n, NxVec3 & t1, NxVec3 & t2))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 31]);
     func(n, t1, t2);
}

bool NxUtilLib_doxybind::NxDiagonalizeInertiaTensor(const NxMat33 & denseInertia, NxVec3 & diagonalInertia, NxMat33 & rotation) 
{
    bool (*func)(const NxMat33 & denseInertia, NxVec3 & diagonalInertia, NxMat33 & rotation) = (bool (*)(const NxMat33 & denseInertia, NxVec3 & diagonalInertia, NxMat33 & rotation))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 32]);
    return func(denseInertia, diagonalInertia, rotation);
}

void NxUtilLib_doxybind::NxFindRotationMatrix(const NxVec3 & x, const NxVec3 & b, NxMat33 & M) 
{
    void (*func)(const NxVec3 & x, const NxVec3 & b, NxMat33 & M) = (void (*)(const NxVec3 & x, const NxVec3 & b, NxMat33 & M))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 33]);
     func(x, b, M);
}

void NxUtilLib_doxybind::NxComputeBounds(NxVec3 & min, NxVec3 & max, NxU32 nbVerts, const NxVec3 * verts) 
{
    void (*func)(NxVec3 & min, NxVec3 & max, NxU32 nbVerts, const NxVec3 * verts) = (void (*)(NxVec3 & min, NxVec3 & max, NxU32 nbVerts, const NxVec3 * verts))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 34]);
     func(min, max, nbVerts, verts);
}

NxU32 NxUtilLib_doxybind::NxCrc32(const void * buffer, NxU32 nbBytes) 
{
    NxU32 (*func)(const void * buffer, NxU32 nbBytes) = (NxU32 (*)(const void * buffer, NxU32 nbBytes))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 35]);
    return func(buffer, nbBytes);
}

NxReal NxUtilLib_doxybind::NxComputeSphereMass(NxReal radius, NxReal density) 
{
    NxReal (*func)(NxReal radius, NxReal density) = (NxReal (*)(NxReal radius, NxReal density))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 36]);
    return func(radius, density);
}

NxReal NxUtilLib_doxybind::NxComputeSphereDensity(NxReal radius, NxReal mass) 
{
    NxReal (*func)(NxReal radius, NxReal mass) = (NxReal (*)(NxReal radius, NxReal mass))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 37]);
    return func(radius, mass);
}

NxReal NxUtilLib_doxybind::NxComputeBoxMass(const NxVec3 & extents, NxReal density) 
{
    NxReal (*func)(const NxVec3 & extents, NxReal density) = (NxReal (*)(const NxVec3 & extents, NxReal density))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 38]);
    return func(extents, density);
}

NxReal NxUtilLib_doxybind::NxComputeBoxDensity(const NxVec3 & extents, NxReal mass) 
{
    NxReal (*func)(const NxVec3 & extents, NxReal mass) = (NxReal (*)(const NxVec3 & extents, NxReal mass))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 39]);
    return func(extents, mass);
}

NxReal NxUtilLib_doxybind::NxComputeEllipsoidMass(const NxVec3 & extents, NxReal density) 
{
    NxReal (*func)(const NxVec3 & extents, NxReal density) = (NxReal (*)(const NxVec3 & extents, NxReal density))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 40]);
    return func(extents, density);
}

NxReal NxUtilLib_doxybind::NxComputeEllipsoidDensity(const NxVec3 & extents, NxReal mass) 
{
    NxReal (*func)(const NxVec3 & extents, NxReal mass) = (NxReal (*)(const NxVec3 & extents, NxReal mass))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 41]);
    return func(extents, mass);
}

NxReal NxUtilLib_doxybind::NxComputeCylinderMass(NxReal radius, NxReal length, NxReal density) 
{
    NxReal (*func)(NxReal radius, NxReal length, NxReal density) = (NxReal (*)(NxReal radius, NxReal length, NxReal density))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 42]);
    return func(radius, length, density);
}

NxReal NxUtilLib_doxybind::NxComputeCylinderDensity(NxReal radius, NxReal length, NxReal mass) 
{
    NxReal (*func)(NxReal radius, NxReal length, NxReal mass) = (NxReal (*)(NxReal radius, NxReal length, NxReal mass))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 43]);
    return func(radius, length, mass);
}

NxReal NxUtilLib_doxybind::NxComputeConeMass(NxReal radius, NxReal length, NxReal density) 
{
    NxReal (*func)(NxReal radius, NxReal length, NxReal density) = (NxReal (*)(NxReal radius, NxReal length, NxReal density))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 44]);
    return func(radius, length, density);
}

NxReal NxUtilLib_doxybind::NxComputeConeDensity(NxReal radius, NxReal length, NxReal mass) 
{
    NxReal (*func)(NxReal radius, NxReal length, NxReal mass) = (NxReal (*)(NxReal radius, NxReal length, NxReal mass))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 45]);
    return func(radius, length, mass);
}

void NxUtilLib_doxybind::NxComputeBoxInertiaTensor(NxVec3 & diagInertia, NxReal mass, NxReal xlength, NxReal ylength, NxReal zlength) 
{
    void (*func)(NxVec3 & diagInertia, NxReal mass, NxReal xlength, NxReal ylength, NxReal zlength) = (void (*)(NxVec3 & diagInertia, NxReal mass, NxReal xlength, NxReal ylength, NxReal zlength))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 46]);
     func(diagInertia, mass, xlength, ylength, zlength);
}

void NxUtilLib_doxybind::NxComputeSphereInertiaTensor(NxVec3 & diagInertia, NxReal mass, NxReal radius, bool hollow) 
{
    void (*func)(NxVec3 & diagInertia, NxReal mass, NxReal radius, bool hollow) = (void (*)(NxVec3 & diagInertia, NxReal mass, NxReal radius, bool hollow))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 47]);
     func(diagInertia, mass, radius, hollow);
}

void NxUtilLib_doxybind::NxJointDesc_SetGlobalAnchor(NxJointDesc & dis, const NxVec3 & wsAnchor) 
{
    void (*func)(NxJointDesc & dis, const NxVec3 & wsAnchor) = (void (*)(NxJointDesc & dis, const NxVec3 & wsAnchor))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 48]);
     func(dis, wsAnchor);
}

void NxUtilLib_doxybind::NxJointDesc_SetGlobalAxis(NxJointDesc & dis, const NxVec3 & wsAxis) 
{
    void (*func)(NxJointDesc & dis, const NxVec3 & wsAxis) = (void (*)(NxJointDesc & dis, const NxVec3 & wsAxis))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 49]);
     func(dis, wsAxis);
}

bool NxUtilLib_doxybind::NxBoxBoxIntersect(const NxVec3 & extents0, const NxVec3 & center0, const NxMat33 & rotation0, const NxVec3 & extents1, const NxVec3 & center1, const NxMat33 & rotation1, bool fullTest) 
{
    bool (*func)(const NxVec3 & extents0, const NxVec3 & center0, const NxMat33 & rotation0, const NxVec3 & extents1, const NxVec3 & center1, const NxMat33 & rotation1, bool fullTest) = (bool (*)(const NxVec3 & extents0, const NxVec3 & center0, const NxMat33 & rotation0, const NxVec3 & extents1, const NxVec3 & center1, const NxMat33 & rotation1, bool fullTest))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 50]);
    return func(extents0, center0, rotation0, extents1, center1, rotation1, fullTest);
}

bool NxUtilLib_doxybind::NxTriBoxIntersect(const NxVec3 & vertex0, const NxVec3 & vertex1, const NxVec3 & vertex2, const NxVec3 & center, const NxVec3 & extents) 
{
    bool (*func)(const NxVec3 & vertex0, const NxVec3 & vertex1, const NxVec3 & vertex2, const NxVec3 & center, const NxVec3 & extents) = (bool (*)(const NxVec3 & vertex0, const NxVec3 & vertex1, const NxVec3 & vertex2, const NxVec3 & center, const NxVec3 & extents))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 51]);
    return func(vertex0, vertex1, vertex2, center, extents);
}

NxSepAxis NxUtilLib_doxybind::NxSeparatingAxis(const NxVec3 & extents0, const NxVec3 & center0, const NxMat33 & rotation0, const NxVec3 & extents1, const NxVec3 & center1, const NxMat33 & rotation1, bool fullTest) 
{
    NxSepAxis (*func)(const NxVec3 & extents0, const NxVec3 & center0, const NxMat33 & rotation0, const NxVec3 & extents1, const NxVec3 & center1, const NxMat33 & rotation1, bool fullTest) = (NxSepAxis (*)(const NxVec3 & extents0, const NxVec3 & center0, const NxMat33 & rotation0, const NxVec3 & extents1, const NxVec3 & center1, const NxMat33 & rotation1, bool fullTest))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 52]);
    return func(extents0, center0, rotation0, extents1, center1, rotation1, fullTest);
}

NxSepAxis NxUtilLib_doxybind::NxSeparatingAxis(const NxVec3 & extents0, const NxVec3 & center0, const NxMat33 & rotation0, const NxVec3 & extents1, const NxVec3 & center1, const NxMat33 & rotation1) 
{
    NxSepAxis (*func)(const NxVec3 & extents0, const NxVec3 & center0, const NxMat33 & rotation0, const NxVec3 & extents1, const NxVec3 & center1, const NxMat33 & rotation1) = (NxSepAxis (*)(const NxVec3 & extents0, const NxVec3 & center0, const NxMat33 & rotation0, const NxVec3 & extents1, const NxVec3 & center1, const NxMat33 & rotation1))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 53]);
    return func(extents0, center0, rotation0, extents1, center1, rotation1);
}

void NxUtilLib_doxybind::NxSegmentPlaneIntersect(const NxVec3 & v1, const NxVec3 & v2, const NxPlane & plane, NxReal & dist, NxVec3 & pointOnPlane) 
{
    void (*func)(const NxVec3 & v1, const NxVec3 & v2, const NxPlane & plane, NxReal & dist, NxVec3 & pointOnPlane) = (void (*)(const NxVec3 & v1, const NxVec3 & v2, const NxPlane & plane, NxReal & dist, NxVec3 & pointOnPlane))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 54]);
     func(v1, v2, plane, dist, pointOnPlane);
}

bool NxUtilLib_doxybind::NxRayPlaneIntersect(const NxRay & ray, const NxPlane & plane, NxReal & dist, NxVec3 & pointOnPlane) 
{
    bool (*func)(const NxRay & ray, const NxPlane & plane, NxReal & dist, NxVec3 & pointOnPlane) = (bool (*)(const NxRay & ray, const NxPlane & plane, NxReal & dist, NxVec3 & pointOnPlane))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 55]);
    return func(ray, plane, dist, pointOnPlane);
}

bool NxUtilLib_doxybind::NxRaySphereIntersect(const NxVec3 & origin, const NxVec3 & dir, NxReal length, const NxVec3 & center, NxReal radius, NxReal & hit_time, NxVec3 & hit_pos) 
{
    bool (*func)(const NxVec3 & origin, const NxVec3 & dir, NxReal length, const NxVec3 & center, NxReal radius, NxReal & hit_time, NxVec3 & hit_pos) = (bool (*)(const NxVec3 & origin, const NxVec3 & dir, NxReal length, const NxVec3 & center, NxReal radius, NxReal & hit_time, NxVec3 & hit_pos))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 56]);
    return func(origin, dir, length, center, radius, hit_time, hit_pos);
}

bool NxUtilLib_doxybind::NxSegmentBoxIntersect(const NxVec3 & p1, const NxVec3 & p2, const NxVec3 & bbox_min, const NxVec3 & bbox_max, NxVec3 & intercept) 
{
    bool (*func)(const NxVec3 & p1, const NxVec3 & p2, const NxVec3 & bbox_min, const NxVec3 & bbox_max, NxVec3 & intercept) = (bool (*)(const NxVec3 & p1, const NxVec3 & p2, const NxVec3 & bbox_min, const NxVec3 & bbox_max, NxVec3 & intercept))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 57]);
    return func(p1, p2, bbox_min, bbox_max, intercept);
}

bool NxUtilLib_doxybind::NxRayAABBIntersect(const NxVec3 & min, const NxVec3 & max, const NxVec3 & origin, const NxVec3 & dir, NxVec3 & coord) 
{
    bool (*func)(const NxVec3 & min, const NxVec3 & max, const NxVec3 & origin, const NxVec3 & dir, NxVec3 & coord) = (bool (*)(const NxVec3 & min, const NxVec3 & max, const NxVec3 & origin, const NxVec3 & dir, NxVec3 & coord))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 58]);
    return func(min, max, origin, dir, coord);
}

NxU32 NxUtilLib_doxybind::NxRayAABBIntersect2(const NxVec3 & min, const NxVec3 & max, const NxVec3 & origin, const NxVec3 & dir, NxVec3 & coord, NxReal & t) 
{
    NxU32 (*func)(const NxVec3 & min, const NxVec3 & max, const NxVec3 & origin, const NxVec3 & dir, NxVec3 & coord, NxReal & t) = (NxU32 (*)(const NxVec3 & min, const NxVec3 & max, const NxVec3 & origin, const NxVec3 & dir, NxVec3 & coord, NxReal & t))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 59]);
    return func(min, max, origin, dir, coord, t);
}

bool NxUtilLib_doxybind::NxSegmentOBBIntersect(const NxVec3 & p0, const NxVec3 & p1, const NxVec3 & center, const NxVec3 & extents, const NxMat33 & rot) 
{
    bool (*func)(const NxVec3 & p0, const NxVec3 & p1, const NxVec3 & center, const NxVec3 & extents, const NxMat33 & rot) = (bool (*)(const NxVec3 & p0, const NxVec3 & p1, const NxVec3 & center, const NxVec3 & extents, const NxMat33 & rot))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 60]);
    return func(p0, p1, center, extents, rot);
}

bool NxUtilLib_doxybind::NxSegmentAABBIntersect(const NxVec3 & p0, const NxVec3 & p1, const NxVec3 & min, const NxVec3 & max) 
{
    bool (*func)(const NxVec3 & p0, const NxVec3 & p1, const NxVec3 & min, const NxVec3 & max) = (bool (*)(const NxVec3 & p0, const NxVec3 & p1, const NxVec3 & min, const NxVec3 & max))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 61]);
    return func(p0, p1, min, max);
}

bool NxUtilLib_doxybind::NxRayOBBIntersect(const NxRay & ray, const NxVec3 & center, const NxVec3 & extents, const NxMat33 & rot) 
{
    bool (*func)(const NxRay & ray, const NxVec3 & center, const NxVec3 & extents, const NxMat33 & rot) = (bool (*)(const NxRay & ray, const NxVec3 & center, const NxVec3 & extents, const NxMat33 & rot))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 62]);
    return func(ray, center, extents, rot);
}

NxU32 NxUtilLib_doxybind::NxRayCapsuleIntersect(const NxVec3 & origin, const NxVec3 & dir, const NxCapsule & capsule, NxReal t[2]) 
{
    NxU32 (*func)(const NxVec3 & origin, const NxVec3 & dir, const NxCapsule & capsule, NxReal t[2]) = (NxU32 (*)(const NxVec3 & origin, const NxVec3 & dir, const NxCapsule & capsule, NxReal t[2]))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 63]);
    return func(origin, dir, capsule, t);
}

bool NxUtilLib_doxybind::NxSweptSpheresIntersect(const NxSphere & sphere0, const NxVec3 & velocity0, const NxSphere & sphere1, const NxVec3 & velocity1) 
{
    bool (*func)(const NxSphere & sphere0, const NxVec3 & velocity0, const NxSphere & sphere1, const NxVec3 & velocity1) = (bool (*)(const NxSphere & sphere0, const NxVec3 & velocity0, const NxSphere & sphere1, const NxVec3 & velocity1))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 64]);
    return func(sphere0, velocity0, sphere1, velocity1);
}

bool NxUtilLib_doxybind::NxRayTriIntersect(const NxVec3 & orig, const NxVec3 & dir, const NxVec3 & vert0, const NxVec3 & vert1, const NxVec3 & vert2, float & t, float & u, float & v, bool cull) 
{
    bool (*func)(const NxVec3 & orig, const NxVec3 & dir, const NxVec3 & vert0, const NxVec3 & vert1, const NxVec3 & vert2, float & t, float & u, float & v, bool cull) = (bool (*)(const NxVec3 & orig, const NxVec3 & dir, const NxVec3 & vert0, const NxVec3 & vert1, const NxVec3 & vert2, float & t, float & u, float & v, bool cull))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 65]);
    return func(orig, dir, vert0, vert1, vert2, t, u, v, cull);
}

bool NxUtilLib_doxybind::NxBuildSmoothNormals(NxU32 nbTris, NxU32 nbVerts, const NxVec3 * verts, const NxU32 * dFaces, const NxU16 * wFaces, NxVec3 * normals, bool flip) 
{
    bool (*func)(NxU32 nbTris, NxU32 nbVerts, const NxVec3 * verts, const NxU32 * dFaces, const NxU16 * wFaces, NxVec3 * normals, bool flip) = (bool (*)(NxU32 nbTris, NxU32 nbVerts, const NxVec3 * verts, const NxU32 * dFaces, const NxU16 * wFaces, NxVec3 * normals, bool flip))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 66]);
    return func(nbTris, nbVerts, verts, dFaces, wFaces, normals, flip);
}

bool NxUtilLib_doxybind::NxBuildSmoothNormals(NxU32 nbTris, NxU32 nbVerts, const NxVec3 * verts, const NxU32 * dFaces, const NxU16 * wFaces, NxVec3 * normals) 
{
    bool (*func)(NxU32 nbTris, NxU32 nbVerts, const NxVec3 * verts, const NxU32 * dFaces, const NxU16 * wFaces, NxVec3 * normals) = (bool (*)(NxU32 nbTris, NxU32 nbVerts, const NxVec3 * verts, const NxU32 * dFaces, const NxU16 * wFaces, NxVec3 * normals))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 67]);
    return func(nbTris, nbVerts, verts, dFaces, wFaces, normals);
}

bool NxUtilLib_doxybind::NxSweepBoxCapsule(const NxBox & box, const NxCapsule & lss, const NxVec3 & dir, float length, float & min_dist, NxVec3 & normal) 
{
    bool (*func)(const NxBox & box, const NxCapsule & lss, const NxVec3 & dir, float length, float & min_dist, NxVec3 & normal) = (bool (*)(const NxBox & box, const NxCapsule & lss, const NxVec3 & dir, float length, float & min_dist, NxVec3 & normal))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 68]);
    return func(box, lss, dir, length, min_dist, normal);
}

bool NxUtilLib_doxybind::NxSweepBoxSphere(const NxBox & box, const NxSphere & sphere, const NxVec3 & dir, float length, float & min_dist, NxVec3 & normal) 
{
    bool (*func)(const NxBox & box, const NxSphere & sphere, const NxVec3 & dir, float length, float & min_dist, NxVec3 & normal) = (bool (*)(const NxBox & box, const NxSphere & sphere, const NxVec3 & dir, float length, float & min_dist, NxVec3 & normal))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 69]);
    return func(box, sphere, dir, length, min_dist, normal);
}

bool NxUtilLib_doxybind::NxSweepCapsuleCapsule(const NxCapsule & lss0, const NxCapsule & lss1, const NxVec3 & dir, float length, float & min_dist, NxVec3 & ip, NxVec3 & normal) 
{
    bool (*func)(const NxCapsule & lss0, const NxCapsule & lss1, const NxVec3 & dir, float length, float & min_dist, NxVec3 & ip, NxVec3 & normal) = (bool (*)(const NxCapsule & lss0, const NxCapsule & lss1, const NxVec3 & dir, float length, float & min_dist, NxVec3 & ip, NxVec3 & normal))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 70]);
    return func(lss0, lss1, dir, length, min_dist, ip, normal);
}

bool NxUtilLib_doxybind::NxSweepSphereCapsule(const NxSphere & sphere, const NxCapsule & lss, const NxVec3 & dir, float length, float & min_dist, NxVec3 & ip, NxVec3 & normal) 
{
    bool (*func)(const NxSphere & sphere, const NxCapsule & lss, const NxVec3 & dir, float length, float & min_dist, NxVec3 & ip, NxVec3 & normal) = (bool (*)(const NxSphere & sphere, const NxCapsule & lss, const NxVec3 & dir, float length, float & min_dist, NxVec3 & ip, NxVec3 & normal))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 71]);
    return func(sphere, lss, dir, length, min_dist, ip, normal);
}

bool NxUtilLib_doxybind::NxSweepBoxBox(const NxBox & box0, const NxBox & box1, const NxVec3 & dir, float length, NxVec3 & ip, NxVec3 & normal, float & min_dist) 
{
    bool (*func)(const NxBox & box0, const NxBox & box1, const NxVec3 & dir, float length, NxVec3 & ip, NxVec3 & normal, float & min_dist) = (bool (*)(const NxBox & box0, const NxBox & box1, const NxVec3 & dir, float length, NxVec3 & ip, NxVec3 & normal, float & min_dist))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 72]);
    return func(box0, box1, dir, length, ip, normal, min_dist);
}

bool NxUtilLib_doxybind::NxSweepBoxTriangles(NxU32 nb_tris, const NxTriangle * triangles, const NxTriangle * edge_triangles, const NxU32 * edge_flags, const NxBounds3 & box, const NxVec3 & dir, float length, NxVec3 & hit, NxVec3 & normal, float & d, NxU32 & index, NxU32 * cachedIndex) 
{
    bool (*func)(NxU32 nb_tris, const NxTriangle * triangles, const NxTriangle * edge_triangles, const NxU32 * edge_flags, const NxBounds3 & box, const NxVec3 & dir, float length, NxVec3 & hit, NxVec3 & normal, float & d, NxU32 & index, NxU32 * cachedIndex) = (bool (*)(NxU32 nb_tris, const NxTriangle * triangles, const NxTriangle * edge_triangles, const NxU32 * edge_flags, const NxBounds3 & box, const NxVec3 & dir, float length, NxVec3 & hit, NxVec3 & normal, float & d, NxU32 & index, NxU32 * cachedIndex))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 73]);
    return func(nb_tris, triangles, edge_triangles, edge_flags, box, dir, length, hit, normal, d, index, cachedIndex);
}

bool NxUtilLib_doxybind::NxSweepBoxTriangles(NxU32 nb_tris, const NxTriangle * triangles, const NxTriangle * edge_triangles, const NxU32 * edge_flags, const NxBounds3 & box, const NxVec3 & dir, float length, NxVec3 & hit, NxVec3 & normal, float & d, NxU32 & index) 
{
    bool (*func)(NxU32 nb_tris, const NxTriangle * triangles, const NxTriangle * edge_triangles, const NxU32 * edge_flags, const NxBounds3 & box, const NxVec3 & dir, float length, NxVec3 & hit, NxVec3 & normal, float & d, NxU32 & index) = (bool (*)(NxU32 nb_tris, const NxTriangle * triangles, const NxTriangle * edge_triangles, const NxU32 * edge_flags, const NxBounds3 & box, const NxVec3 & dir, float length, NxVec3 & hit, NxVec3 & normal, float & d, NxU32 & index))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 74]);
    return func(nb_tris, triangles, edge_triangles, edge_flags, box, dir, length, hit, normal, d, index);
}

bool NxUtilLib_doxybind::NxSweepCapsuleTriangles(NxU32 up_direction, NxU32 nb_tris, const NxTriangle * triangles, const NxU32 * edge_flags, const NxVec3 & center, const float radius, const float height, const NxVec3 & dir, float length, NxVec3 & hit, NxVec3 & normal, float & d, NxU32 & index, NxU32 * cachedIndex) 
{
    bool (*func)(NxU32 up_direction, NxU32 nb_tris, const NxTriangle * triangles, const NxU32 * edge_flags, const NxVec3 & center, const float radius, const float height, const NxVec3 & dir, float length, NxVec3 & hit, NxVec3 & normal, float & d, NxU32 & index, NxU32 * cachedIndex) = (bool (*)(NxU32 up_direction, NxU32 nb_tris, const NxTriangle * triangles, const NxU32 * edge_flags, const NxVec3 & center, const float radius, const float height, const NxVec3 & dir, float length, NxVec3 & hit, NxVec3 & normal, float & d, NxU32 & index, NxU32 * cachedIndex))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 75]);
    return func(up_direction, nb_tris, triangles, edge_flags, center, radius, height, dir, length, hit, normal, d, index, cachedIndex);
}

bool NxUtilLib_doxybind::NxSweepCapsuleTriangles(NxU32 up_direction, NxU32 nb_tris, const NxTriangle * triangles, const NxU32 * edge_flags, const NxVec3 & center, const float radius, const float height, const NxVec3 & dir, float length, NxVec3 & hit, NxVec3 & normal, float & d, NxU32 & index) 
{
    bool (*func)(NxU32 up_direction, NxU32 nb_tris, const NxTriangle * triangles, const NxU32 * edge_flags, const NxVec3 & center, const float radius, const float height, const NxVec3 & dir, float length, NxVec3 & hit, NxVec3 & normal, float & d, NxU32 & index) = (bool (*)(NxU32 up_direction, NxU32 nb_tris, const NxTriangle * triangles, const NxU32 * edge_flags, const NxVec3 & center, const float radius, const float height, const NxVec3 & dir, float length, NxVec3 & hit, NxVec3 & normal, float & d, NxU32 & index))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 76]);
    return func(up_direction, nb_tris, triangles, edge_flags, center, radius, height, dir, length, hit, normal, d, index);
}

float NxUtilLib_doxybind::NxPointOBBSqrDist(const NxVec3 & point, const NxVec3 & center, const NxVec3 & extents, const NxMat33 & rot, NxVec3 * params) 
{
    float (*func)(const NxVec3 & point, const NxVec3 & center, const NxVec3 & extents, const NxMat33 & rot, NxVec3 * params) = (float (*)(const NxVec3 & point, const NxVec3 & center, const NxVec3 & extents, const NxMat33 & rot, NxVec3 * params))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 77]);
    return func(point, center, extents, rot, params);
}

float NxUtilLib_doxybind::NxSegmentOBBSqrDist(const NxSegment & segment, const NxVec3 & c0, const NxVec3 & e0, const NxMat33 & r0, float * t, NxVec3 * p) 
{
    float (*func)(const NxSegment & segment, const NxVec3 & c0, const NxVec3 & e0, const NxMat33 & r0, float * t, NxVec3 * p) = (float (*)(const NxSegment & segment, const NxVec3 & c0, const NxVec3 & e0, const NxMat33 & r0, float * t, NxVec3 * p))(functionPointers[NxUtilLib_doxybind::getPointerStart() + 78]);
    return func(segment, c0, e0, r0, t, p);
}

void NxWheelShape_doxybind::saveToDesc(NxWheelShapeDesc & desc) const
{
    void (*func)(NxWheelShapeDesc & desc) = (void (*)(NxWheelShapeDesc & desc))(functionPointers[NxWheelShape_doxybind::getPointerStart() + 0]);
     func(desc);
}

void NxWheelShape_doxybind::setRadius(NxReal radius) 
{
    void (*func)(NxReal radius) = (void (*)(NxReal radius))(functionPointers[NxWheelShape_doxybind::getPointerStart() + 1]);
     func(radius);
}

void NxWheelShape_doxybind::setSuspensionTravel(NxReal travel) 
{
    void (*func)(NxReal travel) = (void (*)(NxReal travel))(functionPointers[NxWheelShape_doxybind::getPointerStart() + 2]);
     func(travel);
}

NxReal NxWheelShape_doxybind::getRadius() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxWheelShape_doxybind::getPointerStart() + 3]);
    return func();
}

NxReal NxWheelShape_doxybind::getSuspensionTravel() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxWheelShape_doxybind::getPointerStart() + 4]);
    return func();
}

void NxWheelShape_doxybind::setSuspension(NxSpringDesc spring) 
{
    void (*func)(NxSpringDesc spring) = (void (*)(NxSpringDesc spring))(functionPointers[NxWheelShape_doxybind::getPointerStart() + 5]);
     func(spring);
}

void NxWheelShape_doxybind::setLongitudalTireForceFunction(NxTireFunctionDesc tireFunc) 
{
    void (*func)(NxTireFunctionDesc tireFunc) = (void (*)(NxTireFunctionDesc tireFunc))(functionPointers[NxWheelShape_doxybind::getPointerStart() + 6]);
     func(tireFunc);
}

void NxWheelShape_doxybind::setLateralTireForceFunction(NxTireFunctionDesc tireFunc) 
{
    void (*func)(NxTireFunctionDesc tireFunc) = (void (*)(NxTireFunctionDesc tireFunc))(functionPointers[NxWheelShape_doxybind::getPointerStart() + 7]);
     func(tireFunc);
}

void NxWheelShape_doxybind::setInverseWheelMass(NxReal invMass) 
{
    void (*func)(NxReal invMass) = (void (*)(NxReal invMass))(functionPointers[NxWheelShape_doxybind::getPointerStart() + 8]);
     func(invMass);
}

void NxWheelShape_doxybind::setWheelFlags(NxU32 flags) 
{
    void (*func)(NxU32 flags) = (void (*)(NxU32 flags))(functionPointers[NxWheelShape_doxybind::getPointerStart() + 9]);
     func(flags);
}

NxSpringDesc NxWheelShape_doxybind::getSuspension() const
{
    NxSpringDesc (*func)() = (NxSpringDesc (*)())(functionPointers[NxWheelShape_doxybind::getPointerStart() + 10]);
    return func();
}

NxTireFunctionDesc NxWheelShape_doxybind::getLongitudalTireForceFunction() const
{
    NxTireFunctionDesc (*func)() = (NxTireFunctionDesc (*)())(functionPointers[NxWheelShape_doxybind::getPointerStart() + 11]);
    return func();
}

NxTireFunctionDesc NxWheelShape_doxybind::getLateralTireForceFunction() const
{
    NxTireFunctionDesc (*func)() = (NxTireFunctionDesc (*)())(functionPointers[NxWheelShape_doxybind::getPointerStart() + 12]);
    return func();
}

NxReal NxWheelShape_doxybind::getInverseWheelMass() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxWheelShape_doxybind::getPointerStart() + 13]);
    return func();
}

NxU32 NxWheelShape_doxybind::getWheelFlags() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxWheelShape_doxybind::getPointerStart() + 14]);
    return func();
}

void NxWheelShape_doxybind::setMotorTorque(NxReal torque) 
{
    void (*func)(NxReal torque) = (void (*)(NxReal torque))(functionPointers[NxWheelShape_doxybind::getPointerStart() + 15]);
     func(torque);
}

void NxWheelShape_doxybind::setBrakeTorque(NxReal torque) 
{
    void (*func)(NxReal torque) = (void (*)(NxReal torque))(functionPointers[NxWheelShape_doxybind::getPointerStart() + 16]);
     func(torque);
}

void NxWheelShape_doxybind::setSteerAngle(NxReal angle) 
{
    void (*func)(NxReal angle) = (void (*)(NxReal angle))(functionPointers[NxWheelShape_doxybind::getPointerStart() + 17]);
     func(angle);
}

NxReal NxWheelShape_doxybind::getMotorTorque() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxWheelShape_doxybind::getPointerStart() + 18]);
    return func();
}

NxReal NxWheelShape_doxybind::getBrakeTorque() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxWheelShape_doxybind::getPointerStart() + 19]);
    return func();
}

NxReal NxWheelShape_doxybind::getSteerAngle() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxWheelShape_doxybind::getPointerStart() + 20]);
    return func();
}

void NxWheelShape_doxybind::setAxleSpeed(NxReal speed) 
{
    void (*func)(NxReal speed) = (void (*)(NxReal speed))(functionPointers[NxWheelShape_doxybind::getPointerStart() + 21]);
     func(speed);
}

NxReal NxWheelShape_doxybind::getAxleSpeed() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxWheelShape_doxybind::getPointerStart() + 22]);
    return func();
}

NxShape * NxWheelShape_doxybind::getContact(NxWheelContactData & dest) const
{
    NxShape * (*func)(NxWheelContactData & dest) = (NxShape * (*)(NxWheelContactData & dest))(functionPointers[NxWheelShape_doxybind::getPointerStart() + 23]);
    return func(dest);
}

void NxWheelShape_doxybind::setUserWheelContactModify(NxUserWheelContactModify * callback) 
{
    void (*func)(NxUserWheelContactModify * callback) = (void (*)(NxUserWheelContactModify * callback))(functionPointers[NxWheelShape_doxybind::getPointerStart() + 24]);
     func(callback);
}

NxUserWheelContactModify * NxWheelShape_doxybind::getUserWheelContactModify() 
{
    NxUserWheelContactModify * (*func)() = (NxUserWheelContactModify * (*)())(functionPointers[NxWheelShape_doxybind::getPointerStart() + 25]);
    return func();
}

void NxWheelShape_doxybind::setLocalPose(const NxMat34 & mat) 
{
    void (*func)(const NxMat34 & mat) = (void (*)(const NxMat34 & mat))(functionPointers[NxShape_doxybind::getPointerStart() + 0]);
     func(mat);
}

void NxWheelShape_doxybind::setLocalPosition(const NxVec3 & vec) 
{
    void (*func)(const NxVec3 & vec) = (void (*)(const NxVec3 & vec))(functionPointers[NxShape_doxybind::getPointerStart() + 1]);
     func(vec);
}

void NxWheelShape_doxybind::setLocalOrientation(const NxMat33 & mat) 
{
    void (*func)(const NxMat33 & mat) = (void (*)(const NxMat33 & mat))(functionPointers[NxShape_doxybind::getPointerStart() + 2]);
     func(mat);
}

NxMat34 NxWheelShape_doxybind::getLocalPose() const
{
    NxMat34 (*func)() = (NxMat34 (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 3]);
    return func();
}

NxVec3 NxWheelShape_doxybind::getLocalPosition() const
{
    NxVec3 (*func)() = (NxVec3 (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 4]);
    return func();
}

NxMat33 NxWheelShape_doxybind::getLocalOrientation() const
{
    NxMat33 (*func)() = (NxMat33 (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 5]);
    return func();
}

void NxWheelShape_doxybind::setGlobalPose(const NxMat34 & mat) 
{
    void (*func)(const NxMat34 & mat) = (void (*)(const NxMat34 & mat))(functionPointers[NxShape_doxybind::getPointerStart() + 6]);
     func(mat);
}

void NxWheelShape_doxybind::setGlobalPosition(const NxVec3 & vec) 
{
    void (*func)(const NxVec3 & vec) = (void (*)(const NxVec3 & vec))(functionPointers[NxShape_doxybind::getPointerStart() + 7]);
     func(vec);
}

void NxWheelShape_doxybind::setGlobalOrientation(const NxMat33 & mat) 
{
    void (*func)(const NxMat33 & mat) = (void (*)(const NxMat33 & mat))(functionPointers[NxShape_doxybind::getPointerStart() + 8]);
     func(mat);
}

NxMat34 NxWheelShape_doxybind::getGlobalPose() const
{
    NxMat34 (*func)() = (NxMat34 (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 9]);
    return func();
}

NxVec3 NxWheelShape_doxybind::getGlobalPosition() const
{
    NxVec3 (*func)() = (NxVec3 (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 10]);
    return func();
}

NxMat33 NxWheelShape_doxybind::getGlobalOrientation() const
{
    NxMat33 (*func)() = (NxMat33 (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 11]);
    return func();
}

void * NxWheelShape_doxybind::is(NxShapeType type) 
{
    void * (*func)(NxShapeType type) = (void * (*)(NxShapeType type))(functionPointers[NxShape_doxybind::getPointerStart() + 12]);
    return func(type);
}

const void * NxWheelShape_doxybind::is(NxShapeType type) const
{
    const void * (*func)(NxShapeType type) = (const void * (*)(NxShapeType type))(functionPointers[NxShape_doxybind::getPointerStart() + 13]);
    return func(type);
}

bool NxWheelShape_doxybind::raycast(const NxRay & worldRay, NxReal maxDist, NxU32 hintFlags, NxRaycastHit & hit, bool firstHit) const
{
    bool (*func)(const NxRay & worldRay, NxReal maxDist, NxU32 hintFlags, NxRaycastHit & hit, bool firstHit) = (bool (*)(const NxRay & worldRay, NxReal maxDist, NxU32 hintFlags, NxRaycastHit & hit, bool firstHit))(functionPointers[NxShape_doxybind::getPointerStart() + 14]);
    return func(worldRay, maxDist, hintFlags, hit, firstHit);
}

bool NxWheelShape_doxybind::checkOverlapSphere(const NxSphere & worldSphere) const
{
    bool (*func)(const NxSphere & worldSphere) = (bool (*)(const NxSphere & worldSphere))(functionPointers[NxShape_doxybind::getPointerStart() + 15]);
    return func(worldSphere);
}

bool NxWheelShape_doxybind::checkOverlapOBB(const NxBox & worldBox) const
{
    bool (*func)(const NxBox & worldBox) = (bool (*)(const NxBox & worldBox))(functionPointers[NxShape_doxybind::getPointerStart() + 16]);
    return func(worldBox);
}

bool NxWheelShape_doxybind::checkOverlapAABB(const NxBounds3 & worldBounds) const
{
    bool (*func)(const NxBounds3 & worldBounds) = (bool (*)(const NxBounds3 & worldBounds))(functionPointers[NxShape_doxybind::getPointerStart() + 17]);
    return func(worldBounds);
}

bool NxWheelShape_doxybind::checkOverlapCapsule(const NxCapsule & worldCapsule) const
{
    bool (*func)(const NxCapsule & worldCapsule) = (bool (*)(const NxCapsule & worldCapsule))(functionPointers[NxShape_doxybind::getPointerStart() + 18]);
    return func(worldCapsule);
}

NxActor & NxWheelShape_doxybind::getActor() const
{
    NxActor & (*func)() = (NxActor & (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 19]);
    return func();
}

void NxWheelShape_doxybind::setGroup(NxCollisionGroup collisionGroup) 
{
    void (*func)(NxCollisionGroup collisionGroup) = (void (*)(NxCollisionGroup collisionGroup))(functionPointers[NxShape_doxybind::getPointerStart() + 20]);
     func(collisionGroup);
}

NxCollisionGroup NxWheelShape_doxybind::getGroup() const
{
    NxCollisionGroup (*func)() = (NxCollisionGroup (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 21]);
    return func();
}

void NxWheelShape_doxybind::getWorldBounds(NxBounds3 & dest) const
{
    void (*func)(NxBounds3 & dest) = (void (*)(NxBounds3 & dest))(functionPointers[NxShape_doxybind::getPointerStart() + 22]);
     func(dest);
}

void NxWheelShape_doxybind::setFlag(NxShapeFlag flag, bool value) 
{
    void (*func)(NxShapeFlag flag, bool value) = (void (*)(NxShapeFlag flag, bool value))(functionPointers[NxShape_doxybind::getPointerStart() + 23]);
     func(flag, value);
}

NX_BOOL NxWheelShape_doxybind::getFlag(NxShapeFlag flag) const
{
    NX_BOOL (*func)(NxShapeFlag flag) = (NX_BOOL (*)(NxShapeFlag flag))(functionPointers[NxShape_doxybind::getPointerStart() + 24]);
    return func(flag);
}

void NxWheelShape_doxybind::setMaterial(NxMaterialIndex matIndex) 
{
    void (*func)(NxMaterialIndex matIndex) = (void (*)(NxMaterialIndex matIndex))(functionPointers[NxShape_doxybind::getPointerStart() + 25]);
     func(matIndex);
}

NxMaterialIndex NxWheelShape_doxybind::getMaterial() const
{
    NxMaterialIndex (*func)() = (NxMaterialIndex (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 26]);
    return func();
}

void NxWheelShape_doxybind::setSkinWidth(NxReal skinWidth) 
{
    void (*func)(NxReal skinWidth) = (void (*)(NxReal skinWidth))(functionPointers[NxShape_doxybind::getPointerStart() + 27]);
     func(skinWidth);
}

NxReal NxWheelShape_doxybind::getSkinWidth() const
{
    NxReal (*func)() = (NxReal (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 28]);
    return func();
}

NxShapeType NxWheelShape_doxybind::getType() const
{
    NxShapeType (*func)() = (NxShapeType (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 29]);
    return func();
}

void NxWheelShape_doxybind::setCCDSkeleton(NxCCDSkeleton * ccdSkel) 
{
    void (*func)(NxCCDSkeleton * ccdSkel) = (void (*)(NxCCDSkeleton * ccdSkel))(functionPointers[NxShape_doxybind::getPointerStart() + 30]);
     func(ccdSkel);
}

NxCCDSkeleton * NxWheelShape_doxybind::getCCDSkeleton() const
{
    NxCCDSkeleton * (*func)() = (NxCCDSkeleton * (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 31]);
    return func();
}

void NxWheelShape_doxybind::setName(const char * name) 
{
    void (*func)(const char * name) = (void (*)(const char * name))(functionPointers[NxShape_doxybind::getPointerStart() + 32]);
     func(name);
}

const char * NxWheelShape_doxybind::getName() const
{
    const char * (*func)() = (const char * (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 33]);
    return func();
}

void NxWheelShape_doxybind::setGroupsMask(const NxGroupsMask & mask) 
{
    void (*func)(const NxGroupsMask & mask) = (void (*)(const NxGroupsMask & mask))(functionPointers[NxShape_doxybind::getPointerStart() + 34]);
     func(mask);
}

const NxGroupsMask NxWheelShape_doxybind::getGroupsMask() const
{
    const NxGroupsMask (*func)() = (const NxGroupsMask (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 35]);
    return func();
}

NxU32 NxWheelShape_doxybind::getNonInteractingCompartmentTypes() const
{
    NxU32 (*func)() = (NxU32 (*)())(functionPointers[NxShape_doxybind::getPointerStart() + 36]);
    return func();
}

void NxWheelShape_doxybind::setNonInteractingCompartmentTypes(NxU32 compartmentTypes) 
{
    void (*func)(NxU32 compartmentTypes) = (void (*)(NxU32 compartmentTypes))(functionPointers[NxShape_doxybind::getPointerStart() + 37]);
     func(compartmentTypes);
}

NxWheelShapeDesc_doxybind::NxWheelShapeDesc_doxybind() : NxWheelShapeDesc()
{
}

void NxWheelShapeDesc_doxybind::setToDefault(bool fromCtor) 
{
    void (*func)(bool fromCtor) = (void (*)(bool fromCtor))(functionPointers[NxWheelShapeDesc_doxybind::getPointerStart() + 0]);
     func(fromCtor);
}

bool NxWheelShapeDesc_doxybind::isValid() const
{
    bool (*func)() = (bool (*)())(functionPointers[NxWheelShapeDesc_doxybind::getPointerStart() + 1]);
    return func();
}

void NxWheelShapeDesc_doxybind::setToDefault() 
{
    void (*func)() = (void (*)())(functionPointers[NxShapeDesc_doxybind::getPointerStart() + 0]);
     func();
}

