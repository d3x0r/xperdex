
# this definatly need to not be a := since, we will need to resolve at later time
APP_DEFAULT_DATA1=images/background.gif images/neuron.png images/output.gif images/input.gif images/AlphaNerves.png
DESTDATA1=$(FINALDEST)/images
MYIMAGES=images/background.gif images/neuron.png images/output.gif images/input.gif images/AlphaNerves.png
LIBNAME1=bboard
SRCS1=peice layer board toolbin board_db
CXFLAGS1=-DPEICE_SOURCE -DTOOLBIN_SOURCE
MORELIBS1=brain bag.psi
ifdef __WINDOWS__
MORE_LITERAL_LIBS1+=bag.video.plugin bag.image.plugin
else
MORELIBS1+=bag.display
endif

PROGNAME2=brainshell
SRCS2=brainshell bs_dialog
CXFLAGS2=-DBUILD_TEST_SHELL
MORELIBS2=bboard brain variant  bag.psi
ifdef __WINDOWS__
MORE_LITERAL_LIBS2+=bag.image.plugin bag.video.plugin
else
MORELIBS2+=bag.display
endif
APP_DEFAULT_DATA2=brain.peices.txt frames/PickBoardName.frame 

LIBNAME3=brainshell_lib
SRCS3=brainshell bs_dialog
CXFLAGS3=-DBRAINSHELL_SOURCE
MORELIBS3=$(MORELIBS2)

include $(SACK_BASE)/makefiles/makefile.many

#$(foreach image,$(MYIMAGES),$(FINALDEST)/$(image)):
#	cp $(MYIMAGES) $(DESTDATA1)

$(DESTDATA1):
	mkdir $(call SYSCMDPATH,$@)
