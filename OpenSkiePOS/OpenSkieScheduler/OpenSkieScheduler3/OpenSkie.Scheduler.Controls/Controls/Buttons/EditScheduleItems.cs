using System;
using System.Data;
using System.Windows.Forms;
using OpenSkieScheduler3.Controls.Forms;
using xperdex.classes;

namespace OpenSkieScheduler3.Controls.Buttons
{
	public class EditSessionGroup : MyButton
	{

		protected override void OnClick( EventArgs e )
		{
			base.OnClick( e );
		}
	}
	public class EditSession : MyButton
	{
	}
	public class EditGameGroup : MyButton
	{
	}
	public class EditGame : MyButton
	{
		protected override void OnClick( EventArgs e )
		{
			if( ControlList.data.current_game == null )
				MessageBox.Show( "Please Select a Game" );
			else
			{
				GameEditor ge = new GameEditor( ControlList.data.current_game );
				ge.ShowDialog();
				ge.Dispose();
			}
		}
	}

	public class EditSessionGroupSessionName : MyButton
	{
		protected override void OnClick( EventArgs e )
		{
            if (ControlList.data.current_session_macro_session != null)
			{
                DataRow current_session_macro_session = ControlList.data.current_session_macro_session;
				DataRow session = current_session_macro_session.GetParentRow( "session_in_session_macro" );
				DataRow group = current_session_macro_session.GetParentRow( "session_macro_has_session" );
				String NewName = QueryNewName.Show( "Enter name for session " + session[SessionTable.NameColumn] + " in group " + group[SessionMacroTable.NameColumn]
					, current_session_macro_session[SessionDayMacroSessionTable.NameColumn] as string );

				current_session_macro_session[SessionDayMacroSessionTable.NameColumn] = NewName;
				//dataRow[SessionDayMacroSessionTable.NameColumn] = NewName;
                //current_session_macro_session.Table.AcceptChanges();
				//MySQLDataTable dt = current_session_macro_session.Table as MySQLDataTable;
				//if( dt != null )
			//		dt.CommitChanges();
			}
		}
	}
	public class EditPatterns : MyButton
	{
		protected override void OnClick( EventArgs e )
		{
            new BingoGameCore4.Controls.PatternEditor( ControlList.schedule ).ShowDialog();
		}
	}
	public class EditSessionMacroSchedule : MyButton
	{
		protected override void OnClick( EventArgs e )
		{
			new OpenSkieScheduler3.Controls.Forms.SessionMacroScheduler().ShowDialog();
		}
	}
	public class EditDealers : MyButton
	{
		protected override void OnClick( EventArgs e )
		{
            new DealerEditor( ControlList.schedule.dealer ).ShowDialog();
		}
	}
	public class EditPack : MyButton
	{
		protected override void OnClick( EventArgs e )
		{
			if (ControlList.data.current_pack == null)
				MessageBox.Show("Please Select a Pack");
			else
			{
				PackEditor pe = new PackEditor(ControlList.data.current_pack); 
				pe.ShowDialog();
				pe.Dispose();
			}
		}
	}
	public class EditCardsets : MyButton
	{
		protected override void OnClick( EventArgs e )
		{
			CardsetEditor ce = new CardsetEditor();
			ce.ShowDialog();
			ce.Dispose();
		}
	}
	public class EditCardsetRanges : MyButton
	{
		protected override void OnClick( EventArgs e )
		{
			CardsetRangeEditor ce = new CardsetRangeEditor();
			ce.ShowDialog();
			ce.Dispose();
		}
	}

	public class EditPrizes : MyButton
	{
		protected override void OnClick( EventArgs e )
		{
			PayoutEditor2 ce = new PayoutEditor2();
			ce.ShowDialog();
			ce.Dispose();
		}
	}
	/*
	public class EditPackPayouts : MyButton
	{
		protected override void OnClick( EventArgs e )
		{
			PackPrizeLevelEditor ce = new PackPrizeLevelEditor();
			ce.ShowDialog();
			ce.Dispose();
		}
	}
	 */
}
