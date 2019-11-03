OUT=../../out
OUTNAME=monosh.exe

SYSLIBS=System.Data.dll System.Windows.Forms.dll System.Drawing.dll
MORELIBS+=$(OUT)/xperdex.classes.dll $(OUT)/xperdex.tasks.dll

SRCS=Program.cs Form1.cs Form1.Designer.cs

RSRCS=Form1.resx

RSRCS_OUT=$(foreach rsrc,$(RSRCS),$(subst .resx,.resources,$(rsrc)))


all: $(OUT)/$(OUTNAME)

$(OUT)/$(OUTNAME): $(SRCS) $(RSRCS_OUT) Makefile $(MORELIBS)
	gmcs $(MOREOPTS) -out:$@ -target:exe $(SRCS) \
	$(foreach lib,$(SYSLIBS) $(MORELIBS),-r:$(lib)) \
	$(foreach res,$(RSRCS),-resource:$(subst ?, ,$(subst .resx,.resources,$(res))))

$(foreach res,$(RSRCS), $(eval $(subst .resx,.resources,$(res)): $(res); resgen2 $(res) \
        ) \
)

$(SRCS): ;

