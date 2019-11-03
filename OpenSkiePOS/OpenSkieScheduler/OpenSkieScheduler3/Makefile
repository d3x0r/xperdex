


OUT=../../out
OUTNAME=OpenSkieScheduler.dll
NAMESPACE=

nullstring:=
SPACE:=$(nullstring) #end of line

#DsnConnection_2.cs 
MORELIBS=System.Data.dll System.Windows.Forms.dll System.Drawing.dll \
	
MORELIBS+=$(OUT)/xperdex.classes.dll

SRCS=Relations/GamePackPrize.cs  \
Relations/SessionDayMacroSessionTable.cs  \
Relations/CurentGameGroupPacks.cs  \
Relations/CurrentSessionPacks.cs  \
Relations/SessionGameSessionPackRelation.cs  \
Relations/SessionPrizeTable.cs  \
Relations/SessionGameGroupTable.cs  \
Relations/SessionCalendarTable.cs  \
Relations/CurrentSessionGameGroups.cs  \
Relations/GamePatternTable.cs  \
Relations/GameGroupPackRelation.cs  \
Relations/SessionGameTable.cs  \
Relations/SessionPrizeLevelRelation.cs  \
Relations/SessionPackRelation.cs  \
Relations/GameGroupGameRelation.cs \
Relations/SessionGameGroupGameOrder.cs \
Relations/CurrentGameGroupGames.cs \
Relations/CurrentSessionGameGroupGameOrder.cs \
Properties/Settings.Designer.cs  \
Properties/Resources.Designer.cs  \
Properties/AssemblyInfo.cs  \
BingoGameDefs/CardsetRange.cs  \
BingoGameDefs/CurrentCardsetRanges.cs \
BingoGameDefs/PaperCardverCheckfirst.cs  \
BingoGameDefs/SessionCardsetRange.cs  \
BingoGameDefs/CardsetInfo.cs  \
BingoGameDefs/CardsetRangePayoutLevel.cs  \
BingoGameDefs/Dealer.cs  \
EditGame.cs  \
PrizeInfo.cs  \
BaseTables/SesssionTable.cs  \
BaseTables/GameTable.cs  \
BaseTables/HallTable.cs  \
BaseTables/CharityTable.cs  \
BaseTables/GameGroupTable.cs  \
BaseTables/PatternDescriptionTable.cs  \
BaseTables/SessionInfo.cs  \
BaseTables/SessionDayMacroTable.cs  \
BaseTables/PackTable.cs  \
BaseTables/PrizeLevelNames.cs  \
QueryNewName.cs  \
Local.cs  \
Names.cs  \
EventCalendarTable.cs  \
SchedulerSessionEditor.Designer.cs  \
ScheduleDataSet.cs  \
EventCalendarSpanTable.cs  \
BaseClasses/HallCharityOrgTable.cs  \
EditGame.Designer.cs  \
QueryNewName.Designer.cs  \
EventPeriodicTable.cs  \
SchedulerSessionEditor.cs

#ItemPackageTable.cs  \
#SessionScheduleTable.cs  \
#ItemTable.cs  \


#BaseClasses/RelatedTableEditor.Designer.cs  \
#SchedulerSessionMacroEditor.Designer.cs  \
#SchedulerSessionMacroEditor.cs  \
#Program.cs  \


RSRCS=Properties/Resources.resx \
SchedulerSessionMacroEditor.resx \
EditGame.resx \
QueryNewName.resx \
SchedulerSessionEditor.resx \
BaseClasses/RelatedTableEditor.resx


ROUT=$(dir $1)$(NAMESPACE).$(subst .resx,.resources,$(notdir $1))
RSRCS_OUT=$(foreach rsrc,$(RSRCS),$(call ROUT,$(rsrc)))

all:  BaseClasses BaseTables $(OUT)/$(OUTNAME)


BaseClasses:
	ln -fs 'Base Classes' BaseClasses

BaseTables:
	ln -fs 'Base Tables' BaseTables

compile=gmcs $(MOREOPTS) -out:$1 -target:library $(SRCS) \
	$(foreach lib,$(MORELIBS),-r:$(lib)) \
	$(foreach res,$(RSRCS),-res:$(subst ?, ,$(call ROUT,$(res))))

$(OUT)/$(OUTNAME): $(SRCS) $(RSRCS_OUT) Makefile |  BaseClasses BaseTables
	$(call compile,$@)

$(foreach res,$(RSRCS), $(eval $(subst .resx,.resources,$(dir $(res))$(NAMESPACE).$(notdir $(res))): $(res); resgen2 $$< $$@ \
	) \
)

$(SRCS): ;


