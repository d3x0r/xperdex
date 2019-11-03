OUT=../out
OUTNAME=xperdex.core.exe
OUTNAME2=xperdex.core.dll

SYSLIBS=System.Data.dll System.Windows.Forms.dll System.Drawing.dll
MORELIBS+=$(OUT)/xperdex.classes.dll

SRCS=EditPlugins.Designer.cs \
Variables.cs \
Canvas.cs \
TextPlacementEditor.Designer.cs \
GlareSet.cs \
XmlBookmarkReader.cs \
PSI_Keypad.Designer.cs \
page.cs \
GlareSetEditor.cs \
EditPlugins.cs \
Program.cs \
osalot.cs \
Plugins.cs \
PSI_Button.Designer.cs \
PSI_Button.cs \
Form1.cs \
Macro.cs \
LabelEditor.cs \
Canvas.Designer.cs \
Macro_Properties.Designer.cs \
PSI_ButtonProperties.Designer.cs \
ImageAcceptor.cs \
GlareSetEditor.Designer.cs \
TextPlacement.cs \
PSI_ButtonProperties.cs \
PSI_Keypad.cs \
loadsave.cs \
Macro_Properties.cs \
Label.cs \
Properties/AssemblyInfo.cs \
Properties/Settings.Designer.cs \
Properties/Resources.Designer.cs \
EditFonts.cs \
Macro.Designer.cs \
LabelEditor.Designer.cs \
CommonControls/PageListbox.Designer.cs \
CommonControls/PageListbox.cs \
CommonControls/GlareListbox.Designer.cs \
CommonControls/GlareListbox.cs \
PageProperties.cs \
TextPlacementEditor.cs \
local.cs \
TypeMenuItem.cs \
PageProperties.Designer.cs \
Form1.Designer.cs


RSRCS=Form1.resx \
GlareSetEditor.resx \
Macro_Properties.resx \
PSI_ButtonProperties.resx \
PSI_Keypad.resx \
LabelEditor.resx \
EditPlugins.resx \
TextPlacementEditor.resx \
PSI_Button.resx \
Properties/Resources.resx \
PageProperties.resx \
CommonControls/GlareListbox.resx \
Canvas.resx

IMAGES=$(foreach img,$(shell ls Images),Images/$(img))
IMAGE_OUT=$(OUT)/etc/Images
IMAGES_OUT=$(foreach img,$(IMAGES),$(IMAGE_OUT)/$(notdir $(img)))

RSRCS_OUT=$(foreach rsrc,$(RSRCS),$(subst .resx,.resources,$(rsrc)))


all: $(OUT)/$(OUTNAME) $(OUT)/$(OUTNAME2) $(IMAGES_OUT)

$(OUT)/$(OUTNAME): $(SRCS) $(RSRCS_OUT) Makefile $(MORELIBS)
	gmcs -out:$@ -target:exe $(SRCS) \
	$(foreach lib,$(SYSLIBS) $(MORELIBS),-r:$(lib)) \
	$(foreach res,$(RSRCS),-resource:$(subst ?, ,$(subst .resx,.resources,$(res))))

$(OUT)/$(OUTNAME2): $(SRCS) $(RSRCS_OUT) Makefile $(MORELIBS)
	gmcs -out:$@ -target:library $(SRCS) \
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

