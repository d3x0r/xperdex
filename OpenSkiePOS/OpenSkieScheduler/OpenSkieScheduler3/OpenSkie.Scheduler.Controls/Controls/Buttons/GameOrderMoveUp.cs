using System;
using System.Collections.Generic;
using System.Text;
using xperdex.classes;
using System.Windows.Forms;
using OpenSkieScheduler3.Controls.Lists;
using System.Data;
using OpenSkieScheduler3.Relations;

namespace OpenSkieScheduler3.Controls.Buttons
{



    public class GameOrderMoveUp2 : OrderMoveUp<CurrentSessionGameList>
    {
        internal override void do_moveup( DataRow row )
        {
            ControlList.schedule.session_games.updating_number = true;
            ControlList.schedule.session_games.MoveRowUp( row );
            ControlList.schedule.session_games.updating_number = false;
        }
    }

	public class SessionBundleMoveUp : OrderMoveUp<CurrentSessionBundleList>
	{
		internal override void do_moveup( DataRow row )
		{
			ControlList.schedule.session_bundles.MoveRowUp( row );
		}
	}

	public class SessionPackOrderMoveUp : OrderMoveUp<CurrentSessionPackOrderList>
	{
		internal override void do_moveup( DataRow row )
		{
			ControlList.schedule.session_packs.MoveRowUp( row );
		}
	}

	public class SessionPackGroupMoveUp : OrderMoveUp<CurrentSessionPackGroup>
	{
		internal override void do_moveup( DataRow row )
		{
			ControlList.schedule.session_pack_groups.MoveRowUp( row );
		}
	}

	public class SessionOrderMoveUp : OrderMoveUp<CurrrentSessionMacroSessionList> 
	{
		internal override void  do_moveup(DataRow row)
{
	ControlList.schedule.session_macro_sessions.MoveRowUp( row );
	
}
	}

#if asdfasdf
	public class SessionPrizeLevelOrderMoveUp : OrderMoveUp<CurrentSessionPrizeOrderList>
	{
		internal override void do_moveup( DataRow row )
		{
			ControlList.schedule.session_prize_level_order.MoveRowUp( row );
		}
	}
#endif

	public class GameGroupPrizeLevelOrderMoveUp : OrderMoveUp<CurrentGameGroupPrizeList>
	{
		internal override void do_moveup( DataRow row )
		{
			ControlList.data.current_game_group_prizes.MoveRowUp( row );
		}
	}


	public class OrderMoveUp<thing> : MyButton
	{
		internal virtual void do_moveup( DataRow row )
		{
		}

		void DoClick()
		{
			if( !allow_edit )
			{
				MessageBox.Show( "Edit is not enabled." );
				return;
			}
			int index = -1;
			ListBox list = null;
			foreach( Control c in Parent.Controls )
			{
				list = c as ListBox;
				if( c.GetType() == typeof( thing ) )
				{
					if( list != null )
						index = list.SelectedIndex;
					do_moveup( ( list.SelectedItem as DataRowView ).Row );
					break;
				}
				if( list != null )
				{
					if( list.DataSource.GetType() == typeof( thing ) )
					{
						index = list.SelectedIndex;
						CurrentObjectDataView codv = list.DataSource as CurrentObjectDataView;
						do_moveup( codv.Current );
						break;
					}
				}
				list = null; // make sure we don't get a false handling if the last thing happened to be a listbox
			}
			if( list != null  )
			{
				if( index > 0 )
				{
					list.SelectedIndex = index - 1;
				}
			}
			 

		}

		public OrderMoveUp()
		{
			this.Click += new EventHandler( OrderMoveUp_Click );
		}

		void OrderMoveUp_Click( object sender, EventArgs e )
		{
			DoClick();
		}

		#region IReflectorButton Members

		public bool OnClick()
		{
			DoClick();
			return true;
			//throw new Exception( "The method or operation is not implemented." );
		}

		#endregion
	}

	public class MoveItemUp : MyButton
	{
		string _target_list;
		public String TargetList
		{
			get
			{
				return _target_list;
			}
			set
			{
				_target_list = value;
			}
		}

		void DoClick()
		{
			if( !allow_edit )
			{
				MessageBox.Show( "Edit is not enabled." );
				return;
			}
			ListBox list = null;
			Control c = Parent.Controls[_target_list];
			int index = -1;
			if( c != null )
			{
				list = c as ListBox;

				if( list != null )
				{
					CurrentObjectDataView codv = list.DataSource as CurrentObjectDataView;
					index = list.SelectedIndex;
					if( codv != null )
					{
						IMySQLRelationTableBase relation_table = codv.Table as IMySQLRelationTableBase;
						if( relation_table != null )
							relation_table.MoveRowUp( codv.Current );
					}
					CurrentObjectTableView cotv = list.DataSource as CurrentObjectTableView;
					if( cotv != null )
					{
						IMySQLRelationTableBase relation_table = cotv.relation_data_table as IMySQLRelationTableBase;
						if( relation_table != null )
							relation_table.MoveRowUp( cotv.Current );
					}
				}
			}
			if( list != null && list.SelectedItem != null )
			{
				if( index > 0 )
				{
					list.SelectedIndex = index;
					list.SelectedIndex = index - 1;
				}
			}

		}

		public MoveItemUp()
		{
			this.Click += new EventHandler( PrizeLevelOrderMoveUp_Click );
		}

		void PrizeLevelOrderMoveUp_Click( object sender, EventArgs e )
		{
			DoClick();
		}

		#region IReflectorButton Members

		public bool OnClick()
		{
			DoClick();
			return true;
			//throw new Exception( "The method or operation is not implemented." );
		}

		#endregion
	}


}
