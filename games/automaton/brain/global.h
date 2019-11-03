#ifndef GLOBAL_DEFINED
#define GLOBAL_DEFINED

#ifdef __WINDOWS__
#ifdef BRAIN_SOURCE
#define IMPORT __declspec( dllexport )
#else
#define IMPORT __declspec( dllimport )
#endif
#else
#ifdef BRAIN_SOURCE
#define IMPORT
#else
#define IMPORT
#endif
#endif

//typedef class BRAIN_STEM *PBRAIN_STEM;
//typedef class BRAIN *PBRAIN;


#endif
