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

    public class GameOrderMoveDown2 : OrderMoveDown<CurrentSessionGameList>
    {
        internal override void do_movedown( DataRow row )
        {
            ControlList.schedule.session_games.updating_number = true;
			ControlList.schedule.session_games.MoveRowDown( row );
            ControlList.schedule.session_games.updating_number = false;
        }
    }
    
	public class SessionOrderMoveDown : OrderMoveDown< CurrrentSessionMacroSessionList >
	{
		internal override void do_movedown( DataRow row )
		{
			ControlList.schedule.session_macro_sessions.MoveRowDown( row );
		}
	}

	public class SessionBundleOrderMoveDown : OrderMoveDown<CurrentSessionBundleList>
	{
		internal override void do_movedown( DataRow row )
		{
			ControlList.schedule.session_bundles.MoveRowDown( row );
		}
	}

	public class GameGroupPrizeLevelOrderMoveDown : OrderMoveDown<CurrentGameGroupPrizeList>
	{
		internal override void do_movedown( DataRow row )
		{
			ControlList.data.current_game_group_prizes.MoveRowDown( row );			
		}
	}

#if need_to_define_prize_level_order_table
	public class SessionPrizeLevelOrderMoveDown : OrderMoveDown<CurrentSessionPrizeOrderList>
	{
		internal override void do_movedown( DataRow row )
		{
			ControlList.schedule.session_prize_level_order.MoveRowDown( row );
		}
	}
#endif
	public class SessionPackOrderMoveDown : OrderMoveDown<CurrentSessionPackOrderList>
	{
		internal override void do_movedown( DataRow row )
		{
			ControlList.schedule.session_packs.MoveRowDown( row );
		}
	}

	public class SessionPackGroupMoveDown : OrderMoveDown<CurrentSessionPackGroup>
	{
		internal override void do_movedown( DataRow row )
		{
			ControlList.schedule.session_pack_groups.MoveRowDown( row );
		}
	}

	public class OrderMoveDown<thing> : MyButton
	{
		internal virtual void do_movedown( DataRow row )
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
					do_movedown( ( list.SelectedItem as DataRowView ).Row );
					break;
				}

				if( list != null )
				{
					if( list.DataSource.GetType() == typeof( thing ) )
					{
						index = list.SelectedIndex;
						CurrentObjectDataView codv = list.DataSource as CurrentObjectDataView;
						do_movedown( codv.Current );
						break;
					}
				}
				list = null; // make sure we don't get a false handling if the last thing happened to be a listbox
			}
			if( list != null )
			{
				if( index < ( list.Items.Count - 1 ) )
				{
					list.SelectedIndex = index + 1;
				}
			}

		}

		public OrderMoveDown()
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

	public class MoveItemDown : MyButton
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
			int index = -1;
			Control c = Parent.Controls[_target_list];
			if( c != null )
			{
				list = c as ListBox;

				if( list != null )
				{
					index = list.SelectedIndex;
					CurrentObjectDataView codv = list.DataSource as CurrentObjectDataView;
					if( codv != null )
					{
						IMySQLRelationTableBase relation_table = codv.Table as IMySQLRelationTableBase;
						relation_table.MoveRowDown( codv.Current );
					}
					CurrentObjectTableView cotv = list.DataSource as CurrentObjectTableView;
					if( cotv != null )
					{
						IMySQLRelationTableBase relation_table = cotv.relation_data_table as IMySQLRelationTableBase;
						relation_table.MoveRowDown( cotv.Current );
					}
				}
			}
			if( index != -1 && list != null && list.SelectedItem != null )
			{
				if( index < ( list.Items.Count - 1 ) )
				{
					list.SelectedIndex = index;
					list.SelectedIndex = index + 1;
				}
			}

		}

		public MoveItemDown()
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
