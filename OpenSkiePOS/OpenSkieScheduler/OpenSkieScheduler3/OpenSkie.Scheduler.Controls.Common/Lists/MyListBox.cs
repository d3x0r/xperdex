using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using OpenSkieScheduler3.Relations;
using xperdex.classes;
using xperdex.gui;

namespace OpenSkieScheduler3.Controls.Lists
{
	/// <summary>
	/// TargetList - the relation list to receive additions/modifications
	/// AddSelected() : Adds selected item to a target list.  Set target_list to the list to put the relation in.  That will provide the parent to relate under

	/// </summary>
	public class MyListBox	: XListbox
	{
		public bool allow_edit = true;
		public delegate void SetCurrentMethod( DataRow dataRow );
		public delegate DataRow GetCurrentMethod( DataRow dataRow );
        public delegate DataRow AddCurrentMethod( DataRow dataRow );
        public event SetCurrentMethod SetCurrent;
		public event AddCurrentMethod AddCurrent;
		public event GetCurrentMethod GetCurrentRow;

		//DataView default_view;
#if NOT_Xlistbox
		private const int LB_SETTABSTOPS = 0x192;
		// Declaration of external function
		[System.Runtime.InteropServices.DllImport( "user32.dll" )]
		private static extern int SendMessage( int hWnd, int wMsg, int wParam, ref int lParam );
		int[] tab_stops;
		public int[] TabStops
		{
			get
			{
				return tab_stops;
			}
			set
			{
				tab_stops = value;
				if( tab_stops != null )
				{
					int result;
					// Send LB_SETTABSTOPS message to ListBox
					result = SendMessage( this.Handle.ToInt32(), LB_SETTABSTOPS, tab_stops.Length, ref tab_stops[0] );

					// Refresh the ListBox control.
					//this.Refresh();
				}
			}
		}
#endif

		protected bool block_double_click = true;
		public bool BlockDoubleClick
		{
			get
			{
				return block_double_click;
			}
			set
			{
				block_double_click = value;
			}
		}

		public void EnableEdit( bool enable )
		{
			allow_edit = enable;
		}
		
		public MyListBox()
		{
			ControlList.controls.Add( this );
			this.DoubleClick += new EventHandler( MyListBox_DoubleClick );
			this.SelectedValueChanged += new EventHandler( MyListBox_SelectedIndexChanged );
			this.DisplayMemberChanged += new EventHandler( MyListBox_DisplayMemberChanged );
		}

		/// <summary>
		/// Listbox behaves with add/delete relation double click.
		/// </summary>
		/// <param name="reference_table">specifies the datasource table</param>
		/// <param name="delete_from_current">if true, sets up delete instead of add</param>
		public MyListBox( DataTable reference_table, bool delete_from_current )
		{
			Init( null, reference_table );
			if( delete_from_current )
				this.DoubleClick += new EventHandler( MyListBox_DoubleClick_Delete );
			else
				this.DoubleClick += new EventHandler( MyListBox_DoubleClick );
			//SetCurrent += setCurrentMethod;
		}

		/// <summary>
		/// Listbox only calls the set current method.
		/// </summary>
		/// <param name="reference_table"></param>
		public MyListBox( DataTable reference_table )
		{
			Init( null, reference_table );
		}

		/// <summary>
		/// Listbox only calls the set current method.
		/// </summary>
		/// <param name="reference_table"></param>
		public MyListBox( DataView reference_table )
		{
			Init( reference_table, null );
		}


        /// <summary>
        /// Due to versions changing, and the habit of the designer to record what the display member name is
        /// had to generate a timer that would update the display member name appropriately one time - after
        /// the form finishes load.  (on construct, it's set, designer code runs, and resets it back to what 
        /// what was at design time; have to check to see if it's right)
        /// </summary>
        
		delegate void DoReSetDIsplayMember();
		void ReSetDisplayMember()
		{
			DisplayMember = real_display_member;
		}

		String real_display_member;
		Timer t_repair_display_member;
		void MyListBox_DisplayMemberChanged( object sender, EventArgs e )
		{
			if( real_display_member == null )
				real_display_member = DisplayMember;
			else
			{
				if( DisplayMember != real_display_member )
				{
					if( t_repair_display_member == null )
					{
						t_repair_display_member = new Timer();
						t_repair_display_member.Tick += new EventHandler( t_Tick );
						t_repair_display_member.Interval = 250;
						t_repair_display_member.Start();
					}
				}
			}
		}

		void t_Tick( object sender, EventArgs e )
		{
			ReSetDisplayMember();
			if( t_repair_display_member != null )
			{
				t_repair_display_member.Stop();
				t_repair_display_member.Dispose();
				t_repair_display_member = null;
			}
		}

		public delegate void DeleteSelectionEvent( DataRow row );
		public event DeleteSelectionEvent DeleteSelection;

		public void RemoveSelected()
		{
			MyListBox.RemoveSelected( this );
		}

		public static void RemoveSelected( ListBox listbox )
		{
			MyListBox myListbox = listbox as MyListBox;
			bool table_view = ( listbox.DataSource as CurrentObjectTableView != null );
			if( myListbox == null || myListbox.allow_edit )
			{
				if( listbox.SelectionMode == System.Windows.Forms.SelectionMode.MultiSimple ||
					listbox.SelectionMode == System.Windows.Forms.SelectionMode.MultiExtended )
				{
					if( listbox.SelectedItems.Count == 0 )
					{
						MessageBox.Show( "No Selection" );
						return;
					}
					List<DataRow> rows_to_delete = new List<DataRow>();
					foreach( object item in listbox.SelectedItems )
					{
						DataRowView tmp_item = item as DataRowView;
						if( table_view )
							rows_to_delete.Add( tmp_item.Row.GetParentRow( tmp_item.Row.Table.ParentRelations[0] ) );
						else
							rows_to_delete.Add( tmp_item.Row );
					}

					foreach( DataRow item in rows_to_delete )
					{
						if( myListbox != null && myListbox.DeleteSelection != null )
						{
							// foreach selected item?
							myListbox.DeleteSelection( item );
						}
						item.Delete();
					}
				}
				else
				{
					if( listbox.SelectedItem == null )
					{
						MessageBox.Show( "No Selection" );
						return;
					}
					int here = listbox.SelectedIndex;
					if( myListbox != null && myListbox.DeleteSelection != null )
					{
						// foreach selected item?
						myListbox.DeleteSelection( ( listbox.SelectedItem as DataRowView ).Row );
					}
					DataRow row = ( listbox.SelectedItem as DataRowView ).Row;
					// track this back the real row.
					if( table_view )
					{
						DataRow real_row = row.GetParentRow( ( row.Table as CurrentObjectTableView ).ChildRelationName );
						real_row.Delete();
					}
					else
						row.Delete();

					if( here >= listbox.Items.Count )
					{
						if( here > 0 )
							listbox.SelectedIndex = here - 1;
						else
							;
					}
					else
					{
						// probably this is a NO change, so we don't get a selected item changed even
						// though the item selected is different. 
						listbox.SelectedIndex = here;

						DataRow tmp_row = ( listbox.SelectedItem as DataRowView ).Row;
						if( myListbox != null && myListbox.GetCurrentRow != null )
							tmp_row = myListbox.GetCurrentRow( tmp_row );
						if( myListbox != null && myListbox.SetCurrent != null )
							myListbox.SetCurrent( tmp_row );
					}
				}

			}
			else
				MessageBox.Show( "Editing is not enabled." );
		}

		void MyListBox_DoubleClick_Delete( object sender, EventArgs e )
		{
			if( !block_double_click )
				RemoveSelected();
		}

		void Init( DataView reference_view, DataTable reference_table )
		{
			ControlList.controls.Add( this );
			if( reference_view != null )
			{
				this.DataSource = reference_view;
			}
			if( reference_table != null )
			{
				CurrentObjectTableView IReferenceTable = reference_table as CurrentObjectTableView;
				//default_view = new DataView( reference_table );
				//Type TableType = reference_table.GetType();
				this.DataSource = reference_table;
				real_display_member = this.DisplayMember = ( IReferenceTable == null ) ? XDataTable.Name( reference_table ) : XDataTable.Name( IReferenceTable.relation_data_table );
			}
            this.SelectedValueChanged += new EventHandler(MyListBox_SelectedIndexChanged);
			this.DisplayMemberChanged += new EventHandler( MyListBox_DisplayMemberChanged );
		}

		string _target_list;

		/// <summary>
		/// This is the listbox that is the target of added relations.
		/// </summary>
		public string TargetList
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

				/// <summary>
		/// Adds selected item to a list.  Set target_list to the list to put the relation in.  That will provide the parent to relate under
		/// </summary>
		/// <returns></returns>
		public DataRow AddSelected()
		{
			return MyListBox.AddSelected( this );
		}

		/// <summary>
		/// Adds selected item to a list.  Set target_list to the list to put the relation in.  That will provide the parent to relate under
		/// </summary>
		/// <returns></returns>
		public static DataRow AddSelected( ListBox listbox )
		{
			MyListBox myListbox = listbox as MyListBox;
			if( myListbox != null && myListbox._target_list != null )
			{
				CurrentObjectDataView codv = null;
				CurrentObjectTableView cotv = ControlList.schedule.Tables[myListbox._target_list] as CurrentObjectTableView;
                if( cotv == null )
                {
					ListBox target_listbox = listbox.Parent.Controls[myListbox._target_list] as ListBox;
					if( target_listbox != null )
						cotv = target_listbox.DataSource as CurrentObjectTableView;
					if( cotv == null )
						codv = target_listbox.DataSource as CurrentObjectDataView;
                }
				if( cotv != null || codv != null )
				{
					if( listbox.SelectionMode == System.Windows.Forms.SelectionMode.MultiExtended
						|| listbox.SelectionMode == System.Windows.Forms.SelectionMode.MultiSimple )
					{
						foreach( object item in listbox.SelectedItems )
						{
							if( cotv != null )
								cotv.AddChildMember( ( item as DataRowView ).Row );
							else
								codv.AddChildMember( ( item as DataRowView ).Row );
						}
						return null;
					}
					else if( listbox.SelectedItem != null )
					{
						DataRowView drv = listbox.SelectedItem as DataRowView;
						if( cotv != null )
							return cotv.AddChildMember( drv.Row );
						else
							return codv.AddChildMember( drv.Row );
					}
				}
			}
			if( myListbox != null )
				if( myListbox.AddCurrent != null )
					if( listbox.SelectedItem != null )
						if( myListbox.allow_edit )
						{
							DataRowView drv = listbox.SelectedItem as DataRowView;
							return myListbox.AddCurrent( drv.Row );
						}
						else
							MessageBox.Show( "Editing is not enabled." );
            return null;
		}

		void MyListBox_DoubleClick( object sender, EventArgs e )
		{
			if( !block_double_click )
				AddSelected();
		}


		object prior_selection;
		void MyListBox_SelectedIndexChanged( object sender, EventArgs e )
		{
			
			//if( sender.GetType() == typeof( CurrentGamePatternList ) )
			{
				int a = 3;
			}
			//Log.log( "Set Selection : " + this.GetType().ToString() + ":" + this.Name );
			if( SetCurrent != null )
			{
				if( this.SelectedItem != null )
				{
					if( this.SelectedItem != prior_selection )
					{
						prior_selection = this.SelectedItem;
						DataRow row = ( this.SelectedItem as DataRowView ).Row;
						if( GetCurrentRow != null )
							row = GetCurrentRow( row );
						SetCurrent( row );
					}
				}
			}
			else
			{
				int a = 3;
			}
		}

		public DataRow ReplaceSelected()
        {
            if( _target_list != null )
            {
                CurrentObjectTableView cotv = ControlList.schedule.Tables[_target_list] as CurrentObjectTableView;
                if( cotv == null )
                {
                    MyListBox target_list = this.Parent.Controls[_target_list] as MyListBox;
                    if( target_list != null )
                        cotv = target_list.DataSource as CurrentObjectTableView;
                }
                if( cotv != null )
                {
                    if( this.SelectedItem != null )
                    {
                        DataRowView drv = this.SelectedItem as DataRowView;
                        return cotv.ReplaceChildMember( drv.Row, cotv.Current );
                    }
                }
            }
            return null;
        }

		public DataRow InsertSelected()
        {
			CurrentObjectDataView codv = null;
			CurrentObjectTableView cotv = ControlList.schedule.Tables[_target_list] as CurrentObjectTableView;
			if( _target_list != null )
            {
                if( cotv == null )
                {
					codv = DataSource as CurrentObjectDataView;
					if( codv == null )
					{
						ListBox target_list = this.Parent.Controls[_target_list] as ListBox;
						if( target_list != null )
						{
							cotv = target_list.DataSource as CurrentObjectTableView;
							if( cotv == null )
								codv = target_list.DataSource as CurrentObjectDataView;
						}
					}
                }
                if( cotv != null || codv != null )
                {
                    if( this.SelectedItem != null )
                    {
                        DataRowView drv = this.SelectedItem as DataRowView;
						if( cotv != null )
							return cotv.InsertChildMember( drv.Row, cotv.Current );
						else
							return codv.InsertChildMember( drv.Row, codv.Current );
                    }
                }
            }
            else if( AddCurrent != null )
                if( this.SelectedItem != null )
                    if( allow_edit )
                    {
                        DataRowView drv = this.SelectedItem as DataRowView;
						if( cotv != null )
							cotv.AddChildMember( drv.Row );
						else
							codv.AddChildMember( drv.Row );
                    }
                    else
                        MessageBox.Show( "Editing is not enabled." );
            return null;
        }
    }
}
