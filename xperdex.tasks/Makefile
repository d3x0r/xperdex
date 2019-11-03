OUT=../out
OUTNAME=xperdex.tasks.dll

SYSLIBS=System.Data.dll System.Windows.Forms.dll System.Drawing.dll \
System.Management.dll
MORELIBS+=$(OUT)/xperdex.classes.dll $(OUT)/xperdex.core.dll

SRCS=InternalTaskProperties.Designer.cs  Task.cs \
InternalTaskProperties.cs           TaskDropAcceptor.cs \
LaunchCommandPost.cs                TaskItem.cs \
LaunchPad.cs                        TaskProperties.Designer.cs \
Local.cs                            TaskProperties.cs \
RemoteConnectivity.cs

RSRCS=InternalTaskProperties.resx TaskProperties.resx


RSRCS_OUT=$(foreach rsrc,$(RSRCS),$(subst .resx,.resources,$(rsrc)))


all: $(OUT)/$(OUTNAME)

$(OUT)/$(OUTNAME): $(SRCS) $(RSRCS_OUT) Makefile $(MORELIBS)
	gmcs $(MOREOPTS) -out:$@ -target:library $(SRCS) \
	$(foreach lib,$(SYSLIBS) $(MORELIBS),-r:$(lib)) \
	$(foreach res,$(RSRCS),-resource:$(subst ?, ,$(subst .resx,.resources,$(res))))

$(foreach res,$(RSRCS), $(eval $(subst .resx,.resources,$(res)): $(res); resgen2 $(res) \
        ) \
)

$(SRCS): ;

