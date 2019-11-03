#include "PhysX.NET.h"

API_EXPORT void NxArray_NxShapeDesc_NxAllocatorDefault_pushBack( NxArray<NxShapeDesc*>* ptr, NxShapeDesc* item )
{ ptr->pushBack(item); }

API_EXPORT NxShapeDesc* NxArray_NxShapeDesc_NxAllocatorDefault_getItem( NxArray<NxShapeDesc*>* ptr, int index )
{ return (*ptr)[index]; }
