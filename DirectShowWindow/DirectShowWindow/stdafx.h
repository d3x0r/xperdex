// stdafx.h : include file for standard system include files,
// or project specific include files that are used frequently, but
// are changed infrequently
//

#pragma once

#include "targetver.h"

#define WIN32_LEAN_AND_MEAN             // Exclude rarely-used stuff from Windows headers

#if defined(USE_VMR7)
    #define USE_DIRECTSHOW
#elif defined(USE_VMR9)
    #define USE_DIRECTSHOW
#elif defined(USE_EVR)
    #define USE_DIRECTSHOW
#elif !defined(USE_MF)
    static_assert(false, "One of the following must be defined (USE_VMR7, USE_VMR9, USE_EVR, USE_MF)");
#endif