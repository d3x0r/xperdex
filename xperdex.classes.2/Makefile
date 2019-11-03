
OUT=../out
OUTNAME=xperdex.classes.dll
NAMESPACE=xperdex.classes

nullstring:=
SPACE:=$(nullstring) #end of line

#DsnConnection_2.cs 
MORELIBS=System.Data.dll System.Windows.Forms.dll System.Drawing.dll

#Ini.cs 
#RegSQLDataTable.cs 
#RegOdbcSQLDataTable.cs 
#RegSQLDataTableExample.cs 
#RegDataTable.cs 
#StaticRegDsnConnection.cs 
#DsnOdbcConnection.cs 

#Ini.cs \

SRCS=ReflectorPlugin.cs \
xperdex.cs \
PSI_Frame.Designer.cs \
Log.cs \
ReflectorVariable.cs \
IniFile.cs \
INIForm.cs \
INIForm.Designer.cs \
StaticDsnConnection.cs \
ReflectorEdit.cs \
ReflectorSecurity.cs \
QueryNewName.Designer.cs \
Money.cs \
ReflectorCanvas.cs \
XSprite.cs \
Vector.cs \
ReflectorPersistance.cs \
MySQLDataTable.cs \
ReflectorDirectionShow.cs \
PSI_Control.Designer.cs \
LockTester.cs \
PSI_Control.cs \
PSI_Palette/ColorMatrix.Designer.cs \
PSI_Palette/Palette.Designer.cs \
PSI_Palette/ColorWell.Designer.cs \
PSI_Palette/Gradient.Designer.cs \
PSI_Palette/ColorWell.cs \
PSI_Palette/PalettePreset.Designer.cs \
PSI_Palette/Gradient.cs \
PSI_Palette/ColorMatrix.cs \
PSI_Palette/Palette.cs \
PSI_Palette/PalettePreset.cs \
DataConnection.cs \
ReflectorName.cs \
QueryNewName.cs \
StaticStringConnection.cs \
MySQLNameTable.cs \
DsnConnection.cs \
Fraction.cs \
ReflectorCopyPaste.cs \
ReflectorWidget.cs \
ReflectorDropTarget.cs \
ReflectorButton.cs \
Properties/AssemblyInfo.cs \
Properties/Resources.Designer.cs \
PSI_Frame.cs \
ReflectorCreate.cs \
MySQLRelationTable.cs \
Text_Layout/FontEditor.Designer.cs \
Text_Layout/TextLayoutInstance.cs \
Text_Layout/TextLabelContent.cs \
Text_Layout/TextPlacementLayoutEditor.cs \
Text_Layout/TextPlacementLayoutEditor.Designer.cs \
Text_Layout/FontEditor.cs \
Text_Layout/TextLabel.cs \
Text_Layout/Font.cs \
Text_Layout/TextLayout.cs \
SQL_Utilities.cs \
Types/XString.cs \
XDataTable.cs \
TypeMap.cs \
network_client.cs

RSRCS=PSI_Control.resx \
PSI_Palette/Palette.resx \
PSI_Palette/ColorMatrix.resx \
PSI_Palette/ColorWell.resx \
PSI_Palette/PalettePreset.resx \
PSI_Palette/Gradient.resx \
Properties/Resources.resx \
Text_Layout/FontEditor.resx \
PSI_Frame.resx \
QueryNewName.resx \
INIForm.resx

ROUT=$(dir $1)$(NAMESPACE).$(subst .resx,.resources,$(notdir $1))
RSRCS_OUT=$(foreach rsrc,$(RSRCS),$(call ROUT,$(rsrc)))

all: $(OUT)/$(OUTNAME)

compile=gmcs $(MOREOPTS) -out:$1 -target:library $(SRCS) \
	$(foreach lib,$(MORELIBS),-r:$(lib)) \
	$(foreach res,$(RSRCS),-res:$(subst ?, ,$(call ROUT,$(res))))

$(OUT)/$(OUTNAME): $(SRCS) $(RSRCS_OUT) Makefile
	$(call compile,$@)

$(foreach res,$(RSRCS), $(eval $(subst .resx,.resources,$(dir $(res))$(NAMESPACE).$(notdir $(res))): $(res); resgen2 $$< $$@ \
	) \
)

$(SRCS): ;

