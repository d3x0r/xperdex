OUT=../../../out
OUTNAME=oolite_tracker.exe

SYSLIBS=System.Data.dll System.Windows.Forms.dll System.Drawing.dll
MORELIBS+=$(OUT)/xperdex.classes.dll

SRCS=$(shell ls *.cs)


RSRCS=$(shell ls *.resx)

IMAGES=$(foreach img,$(shell ls Images),Images/$(img))
IMAGE_OUT=$(OUT)/etc/Images
IMAGES_OUT=$(foreach img,$(IMAGES),$(IMAGE_OUT)/$(notdir $(img)))

RSRCS_OUT=$(foreach rsrc,$(RSRCS),$(subst .resx,.resources,$(rsrc)))


all: $(OUT)/$(OUTNAME) $(IMAGES_OUT)

$(OUT)/$(OUTNAME): $(SRCS) $(RSRCS_OUT) Makefile $(MORELIBS)
	gmcs -out:$@ -target:exe $(SRCS) \
	$(foreach lib,$(SYSLIBS) $(MORELIBS),-r:$(lib)) \
	$(foreach res,$(RSRCS),-resource:$(subst ?, ,$(subst .resx,.resources,$(res))))

$(foreach res,$(RSRCS), $(eval $(subst .resx,.resources,$(res)): $(res); resgen2 $(res) \
        ) \
)

$(SRCS): ;

$(foreach img,$(IMAGES),$(eval $(IMAGE_OUT)/$(notdir $(img)): $(img); cp $(img) $(IMAGE_OUT)/$(notdir $(img)) ))

$(IMAGES_OUT): | $(IMAGE_OUT)

$(IMAGE_OUT): 
	mkdir -p $@

