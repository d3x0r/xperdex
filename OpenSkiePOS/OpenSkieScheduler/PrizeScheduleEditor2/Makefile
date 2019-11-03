
OUT=../../out
OUTNAME=$(subst ./,,$(notdir $(CURDIR)).exe)
NAMESPACE=

nullstring:=
SPACE:=$(nullstring) #end of line

#DsnConnection_2.cs 
MORELIBS=System.Data.dll System.Windows.Forms.dll System.Drawing.dll \
	
MORELIBS+=$(OUT)/xperdex.classes.dll $(OUT)/OpenSkieScheduler.dll

SRCS=$(shell find . -name \*.cs | sed 's/\.\///g')

RSRCS=$(shell find . -name \*.resx | sed 's/\.\///g')

ROUT=$(dir $1)$(NAMESPACE).$(subst .resx,.resources,$(notdir $1))
RSRCS_OUT=$(foreach rsrc,$(RSRCS),$(call ROUT,$(rsrc)))

all: $(OUT)/$(OUTNAME)

compile=gmcs $(MOREOPTS) -out:$1 -target:exe $(SRCS) \
	$(foreach lib,$(MORELIBS),-r:$(lib)) \
	$(foreach res,$(RSRCS),-res:$(subst ?, ,$(call ROUT,$(res))))

$(OUT)/$(OUTNAME): $(SRCS) $(RSRCS_OUT) Makefile                          
	$(call compile,$@)

$(foreach res,$(RSRCS), $(eval $(subst .resx,.resources,$(dir $(res))$(NAMESPACE).$(notdir $(res))): $(res); resgen2 $$< $$@ \
	) \
)

$(SRCS): ;



