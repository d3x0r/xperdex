
LIBNAME1=variant
SRCS1=convert
CXFLAGS1=-DBRAIN_SOURCE
MORELIBS1=bag


#MAKELEVEL=1
LIBNAME2=brain
SRCS2=brain neuron synapse
CXFLAGS2=-DBRAIN_SOURCE -DINTERFACE_USED
MORELIBS2=variant 
#DEFAULT_APP_DATA1=pieces.txt


PROGNAME3=braintst
SRCS3=braintst
CXFLAGS3=-DINTERFACE_USED
MORELIBS3=variant brain
ifndef __WINDOWS__
SYSLIBS3=stdc++ 
endif

#LIBNAME2=bboard
#SRCS2=layer bboard braindlg
#CXFLAGS2=-DBOARD_SOURCE
#RSRCS2=boardres
#MORELIBS2=image video psi timers shmem brain containers syslog

include $(SACK_BASE)/makefiles/makefile.many
