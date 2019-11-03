using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Data;
using xperdex.classes;
using OpenSkie.Scheduler;
using OpenSkieScheduler3.Relations;
using OpenSkie.Scheduler.Controls.Common.Textboxes;
using OpenSkieScheduler3.BingoGameDefs;

namespace OpenSkieScheduler3.Controls.TextBoxes
{

	public class TextBoxGameGroupName: MyTextBox
	{
		public TextBoxGameGroupName()
			: base( "pack_groups", PackGroupTable.NameColumn )
		{
			ControlList.data.SetGameGroupCurrent += new ScheduleCurrents.OnSetCurrent( data_SetPackGroupCurrent );
		}

		void data_SetPackGroupCurrent( DataRow current )
		{
			UpdateBindings();
		}
	}
	public class TextBoxSessionTypeName : MyTextBox
	{
		public TextBoxSessionTypeName()
			: base( "session_types", SessionTypeTable.NameColumn )
		{
			ControlList.data.SetSessionTypeCurrent += new ScheduleCurrents.OnSetCurrent( data_SetGameGroupCurrent );
		}

		void data_SetGameGroupCurrent( DataRow current )
		{
			UpdateBindings();
		}
	}
	public class TextBoxSessionName : MyTextBox
	{
		public TextBoxSessionName()
			: base( "sessions", SessionTable.NameColumn )
		{
			ControlList.data.SetSessionCurrent += new ScheduleCurrents.OnSetCurrent( data_SetSessionCurrent );
		}

		void data_SetSessionCurrent( DataRow current )
		{
			UpdateBindings();
		}
	}
	public class TextBoxSessionGroupName : MyTextBox
	{
		public TextBoxSessionGroupName()
			: base( "session_macros", SessionMacroTable.NameColumn )
		{
			ControlList.data.SetSessionMacroCurrent += new ScheduleCurrents.OnSetCurrent( data_SetSessionMacroCurrent );
		}

		void data_SetSessionMacroCurrent( DataRow current )
		{
			UpdateBindings();
		}
	}
	public class TextBoxPackName : MyTextBox
	{
		public TextBoxPackName()
			: base( "packs", PackTable.NameColumn )
		{
			ControlList.data.SetPackCurrent += new ScheduleCurrents.OnSetCurrent( data_SetPackCurrent );
		}

		void data_SetPackCurrent( DataRow current )
		{
			UpdateBindings();
		}
	}
	public class TextBoxGameName : MyTextBox
	{
		public TextBoxGameName()
			: base( "games", GameTable.NameColumn )
		{
			ControlList.data.SetGameCurrent += new ScheduleCurrents.OnSetCurrent( data_SetGameCurrent );
		}

		void data_SetGameCurrent( DataRow current )
		{
			UpdateBindings();
		}
	}
	public class TextBoxPrizeLevelName : MyTextBox
	{
		public TextBoxPrizeLevelName()
			: base( "prizes", PrizeLevelNames.NameColumn )
		{
			ControlList.data.SetPrizeLevelCurrent += new ScheduleCurrents.OnSetCurrent( data_SetPrizeLevelCurrent );
		}

		void data_SetPrizeLevelCurrent( DataRow current )
		{
			UpdateBindings();
		}
	}
	public class TextBoxBundleName : MyTextBox
	{
		public TextBoxBundleName()
			: base( "bundles", BundleTable.NameColumn )
		{
			ControlList.data.SetBundleCurrent += new ScheduleCurrents.OnSetCurrent( data_SetBundleCurrent );
		}

		void data_SetBundleCurrent( DataRow current )
		{
			UpdateBindings();
		}
	}

	public class TextBoxBundlePackCount : MyTextBox
	{
		public TextBoxBundlePackCount()
			: base( "session_bundle_pack", SessionBundlePackRelation.CountColumn)
		{
			NumberField = true;
			NumberColumnName = "quantity";
			ControlList.data.SetSessionBundlePackCurrent += new ScheduleCurrents.OnSetCurrent( data_SetBundleCurrent );
			ConfirmChanges = false;
		}

		void data_SetBundleCurrent( DataRow current )
		{
			UpdateBindings();
		}
	}
}
