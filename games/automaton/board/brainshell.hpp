
#include "../brain/brain.hpp"
//#include "BRAINSHELL.hpp"
#include "board.hpp"

#if !defined(__STATIC__) && !defined( __UNIX__ )
#ifdef BRAINSHELL_SOURCE 
//#define BRAINSHELL_PROC(type,name) __declspec(dllexport) type CPROC name
#define BRAINSHELL_PROC(type,name) __declspec(dllexport) type name
#define BRAINSHELL_EXTERN(type,name) __declspec(dllexport) type name
#else
//#define BRAINSHELL_PROC(type,name) __declspec(dllimport) type CPROC name
#define BRAINSHELL_PROC(type,name) __declspec(dllimport) type name
#define BRAINSHELL_EXTERN(type,name) __declspec(dllimport) type name
#endif
#else
#ifdef BRAINSHELL_SOURCE
#define BRAINSHELL_PROC(type,name) type CPROC name
#define BRAINSHELL_EXTERN(type,name) type CPROC name
#else
#define BRAINSHELL_PROC(type,name) type CPROC name
#define BRAINSHELL_EXTERN(type,name) type CPROC name
#endif
#endif
typedef class BRAINBOARD *PBRAINBOARD;
BRAINSHELL_PROC( class BRAINBOARD *, CreateBrainBoard )( PBRAIN brain );
BRAINSHELL_PROC( class IBOARD *, GetBoard )( PBRAINBOARD brain_board );