

#include "board.hpp"

#if !defined(__STATIC__) && !defined( __UNIX__ )
#ifdef TOOLBIN_SOURCE 
#define TOOLBIN_PROC(type,name) __declspec(dllexport) type CPROC name
#else
#define TOOLBIN_PROC(type,name) __declspec(dllimport) type CPROC name
#endif
#else
#ifdef TOOLBIN_SOURCE
#define TOOLBIN_PROC(type,name) type CPROC name
#else
#define TOOLBIN_PROC(type,name) extern type CPROC name
#endif
#endif


extern "C"
{
	TOOLBIN_PROC( void, CreateToolbin )( PIBOARD board );
};


