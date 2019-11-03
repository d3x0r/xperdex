#define method1

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using xperdex.classes;
using Pabo.Calendar;
using OpenSkieScheduler3.Relations;
using OpenSkie.Scheduler;
using OpenSkie.Scheduler.CurrentTables;
using OpenSkieScheduler3.BingoGameDefs;

namespace OpenSkieScheduler3.Controls.Forms
{
	public partial class PriceEditor2 : Form
	{
		DsnConnection dsn;

		List<DataRow> session_items = new List<DataRow>();
		List<DataRow> session_packs = new List<DataRow>();
		List<DataRow> value_added_prices = new List<DataRow>();

		//List<DataRow> price_data = new List<DataRow>();

		// so price data needs to contain the merged result of real price_data and price exceptions, 
		// with appropriate price exctpion data
		SessionPriceData price_data;
		CurrentPriceData current_price_data;

		DataRow session
		{
			get
			{
				return data.current_session;
			}
		}
		DataRow session_exception_set
		{
			get
			{
				return data.current_price_data.Current;
			}
		}

		int price_col_start;

		ScheduleDataSet schedule;
        ScheduleCurrents data;

		public PriceEditor2()
		{
			schedule = ControlList.schedule;
			price_data = schedule.session_price_data;
			current_price_data = schedule.Tables[CurrentPriceData.TableName] as CurrentPriceData;
            data = ControlList.data;
			data.SetSessionPriceExceptionSetCurrent += new ScheduleCurrents.OnSetCurrent( UpdatedCurrent );
			data.SetSessionCurrent += new ScheduleCurrents.OnSetCurrent( data_SetSessionCurrent );
            dsn = ControlList.schedule.schedule_dsn;
			InitializeComponent();
			Disposed += new EventHandler( PriceEditor2_Disposed );
		}

		void PriceEditor2_Disposed( object sender, EventArgs e )
		{
			data.SetSessionCurrent -= data_SetSessionCurrent;
			data.SetSessionPriceExceptionSetCurrent -= UpdatedCurrent;
		}

	

		void data_SetSessionCurrent( DataRow current )
		{
		}

		void UpdatedCurrent( DataRow row )
		{
			InitGridPrices();
		}

		private void PriceEditor_Load( object sender, EventArgs e )
		{
			// select default...
			//sessionPriceExceptionList1.SelectedIndex = 0;

		}

		void dataGridView1_PreviewKeyDown( object sender, PreviewKeyDownEventArgs e )
		{
			if( e.KeyCode == Keys.Delete )
			{
				DataGridViewSelectedCellCollection cells =
					dataGridView1.SelectedCells;
				foreach( DataGridViewCell cell in cells )
				{
					if( cell.ColumnIndex >= price_col_start )
						cell.Value = 0;// new Money( 0 );
				}
			}
		}

		void dataGridView1_KeyPress( object sender, KeyPressEventArgs e )
		{
			//throw new NotImplementedException();
		}

		DateTime current_date;


		
		void InitGridPrices( )
		{
			 DataRow session = data.current_price_data.current_session;
			 DataRow PriceExceptionSet = data.current_price_data.current_exception_set;
			// need both a session and the price set we're using.
			 if( session == null || PriceExceptionSet == null )
				return;

			dataGridView1.Columns.Clear();
			int n;

			//current_price_data.FillPrices( session );

			session_items.Clear();
			session_packs.Clear();
			value_added_prices.Clear();

			n = dataGridView1.Columns.Add( "session_item_row", "Session Pack DataRow" );
			dataGridView1.Columns[n].ReadOnly = true;
			dataGridView1.Columns[n].Visible = false;

			n = dataGridView1.Columns.Add( "session_number", "Session Number" );
			dataGridView1.Columns[n].ReadOnly = true;
			dataGridView1.Columns[n].Visible = false;

			n = dataGridView1.Columns.Add( "session", "Session" );
			dataGridView1.Columns[n].ReadOnly = true;
			n = dataGridView1.Columns.Add( "Pack", "Pack" );
			dataGridView1.Columns[n].ReadOnly = true;
			n = dataGridView1.Columns.Add( "Base Price", "Base Price" );
			dataGridView1.Columns[n].ReadOnly = false;
			dataGridView1.Columns[n].ValueType = typeof( Money );

			price_col_start = n;

			DataRow[] tmp_session_items = session.GetChildRows( schedule.session_bundles.ChildrenOfParent );

			foreach( DataRow session_item in tmp_session_items )
			{
				DataRow[] item_packs = session_item.GetChildRows( schedule.session_bundle_packs.ChildrenOfParent );

				session_items.Add( session_item );

				foreach( DataRow session_pack in item_packs )
				{
					DataRow pack = session_pack.GetParentRow( schedule.session_bundle_packs.ParentOfChild );
					if( !session_packs.Contains( session_pack ) )
						session_packs.Add( session_pack );
					else
						continue;
					if( pack == null ) 
						continue;
					DataRow[] pack_prize_levels = pack.GetChildRows( schedule.pack_prize_level.ChildrenOfParent );
					foreach( DataRow pack_prize_level in pack_prize_levels )
					{
						DataRow prize_level = pack_prize_level.GetParentRow( schedule.pack_prize_level.ParentOfChild );
						if( Convert.ToBoolean( prize_level["value_added"] ) )
							if( !value_added_prices.Contains( prize_level ) )
								value_added_prices.Add( prize_level );
					}

				}
			}

			// add valud added columns.
			foreach( DataRow value_added_price in value_added_prices )
			{
				DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
				col.Name = value_added_price[PrizeLevelNames.NameColumn].ToString() + " (addon)";
				//col.Name = real_row[PriceLevelNames.NameColumn].ToString();
				col.ValueType = typeof( Money );
				col.HeaderText = col.Name;

				int n_col = dataGridView1.Columns.Add( col );
			}


			FillPriceGrid( );

		}

		void FillPriceGrid(  )
		{
			DataRow[] tmp_session_items = session.GetChildRows( schedule.session_bundles.ChildrenOfParent );
			object[] newrow = new object[price_col_start + 1 + value_added_prices.Count];

			bool[] pack_prizes = new bool[value_added_prices.Count];

			dataGridView1.Rows.Clear();

			foreach( DataRow session_item in tmp_session_items )
			{
				for( int p = 0; p < pack_prizes.Length; p++ )
					pack_prizes[p] = false;

				newrow[0] = session_item;
				newrow[1] = 0;
				object name = session[SessionTable.NameColumn];
				newrow[2] = name;
				DataRow item = session_item.GetParentRow( schedule.session_bundles.ParentOfChild );
				newrow[3] = item[BundleTable.NameColumn];

				newrow[4] = price_data.GetPrice( session_item, session_exception_set, null );
				for( int c = 0; c < value_added_prices.Count; c++ )
				{
					newrow[price_col_start + 1 + c] = null;
				}
				DataRow[] packs = session_item.GetChildRows( schedule.session_bundle_packs.ChildrenOfParent );
				foreach( DataRow pack in packs )
				{
					DataRow pack_info = pack.GetParentRow( schedule.session_bundle_packs.ParentOfChild );
					DataRow[] tmp_pack_prizes = pack_info.GetChildRows( schedule.pack_prize_level.ChildrenOfParent );

					foreach( DataRow pack_prize in tmp_pack_prizes )
					{
						DataRow prize = pack_prize.GetParentRow( schedule.pack_prize_level.ParentOfChild );
						int index = value_added_prices.IndexOf( prize );
						if( index >= 0 )
						{
							pack_prizes[index] = true;
							newrow[price_col_start + 1 + index] = price_data.GetPrice( session_item, session_exception_set, value_added_prices[index] );
						}
					}
				}

				int new_row_id = dataGridView1.Rows.Add( newrow );

				for( int c = 0; c < value_added_prices.Count; c++ )
				{
					DataGridViewCell dgvc = dataGridView1[price_col_start + 1 + c, new_row_id];
					dgvc.Style.BackColor = Color.DarkGray;
					dgvc.ReadOnly = true;
				}
				for( int c = 0; c < value_added_prices.Count; c++ )
				{
					if( pack_prizes[c] )
					{
						DataGridViewCell dgvc = dataGridView1[price_col_start + 1 + c, new_row_id];
						dgvc.ReadOnly = false;
						dgvc.Style.BackColor = Form.DefaultBackColor;
					}
				}
			}
		}

		void UpdatePriceGrid()
		{

			if( session == null )
				return;
			//if( game_group == null )
		//		return;


			DataRow original = null;// this.game_group["original_row"] as DataRow;
			DataRow this_game_group = original;


			DataRow[] rows;
            rows = schedule.session_packs
                .Select( SessionTable.PrimaryKey + "='" + session[SessionTable.PrimaryKey] + "'", SessionPack.NumberColumn );
			dataGridView1.Rows.Clear();
			FillPriceGrid( );
		}


		bool IsPriceSame( DataRow session_item
			, DataRow  value_added_info
			, long price )
		{
				DataRow[] rows;
				if( value_added_info != null )
					rows = price_data.Select( PrizeLevelNames.PrimaryKey + "='" + value_added_info[PrizeLevelNames.PrimaryKey]
						+ "' and " + SessionBundleRelation.PrimaryKey + "='" + session_item[SessionBundleRelation.PrimaryKey] + "'" 
					);
				else
					rows = price_data.Select( PrizeLevelNames.PrimaryKey + " is NULL and " + SessionBundleRelation.PrimaryKey + "='" + session_item[SessionBundleRelation.PrimaryKey] + "'" 
					);
				if( rows.Length > 0 )
				{
					if( rows.Length > 1 )
						Log.log( "damnit." );
					if( Convert.ToInt64( rows[0][SessionPriceData.ValueColumn] ) == price )
						return true;
				}
			return false;
		}

		bool IsPriceBlank( DataRow session_item
			, DataRow value_added_info )
		{
			// price_data is a reflection of what the current values being displayed are.
			DataRow[] rows;
			if( value_added_info != null )
				rows = price_data.Select( PrizeLevelNames.PrimaryKey + "='" + value_added_info[PrizeLevelNames.PrimaryKey]
					+ "' and " + SessionBundleRelation.PrimaryKey + "='" + session_item[SessionBundleRelation.PrimaryKey] + "'"
				);
			else
				rows = price_data.Select( PrizeLevelNames.PrimaryKey + " is NULL and " + SessionBundleRelation.PrimaryKey + "='" + session_item[SessionBundleRelation.PrimaryKey] + "'"
				);
			if( rows.Length > 0 )
			{
				if( rows.Length > 1 )
					Log.log( "damnit." );
				if( Convert.ToInt64( rows[0][SessionPriceData.ValueColumn] ) == 0 )
					return true;
				return false;
			}
			return true;
		}

        void UpdatePrice( int session_pack_group_pack_id, int price_id, Money price )
        {
        }

		void UpdatePricesFromGrid()
		{
			//if( day_of_week_type == -1 )
			{
				foreach( DataGridViewRow row in dataGridView1.Rows )
				{
					bool new_row = false;
					DataRow session_item = row.Cells["session_item_row"].Value as DataRow;
					int level;
					for( level = 0; level < value_added_prices.Count + 1; level++ )
					{

						Object _price = row.Cells[level + price_col_start].Value;
						Money price;
						if( _price == null )
							continue;
						if( _price.GetType() == typeof( Money ) )
							price = _price as Money;
						else
							price = new Money( Convert.ToInt64( _price ) );

						price_data.WritePrice( session_item, session_exception_set, ( level == 0 ) ? null : value_added_prices[level - 1], price );
					}
				}
				//DsnSQLUtil.CommitChanges( dsn, price_data );

			}
			// if these aren't commited, then changes would be lost on next stage reload.
			// reload with current values from database.
			FillPriceGrid();
		}

		private void button1_Click( object sender, EventArgs e )
		{
			UpdatePricesFromGrid();
		}

		private void button2_Click( object sender, EventArgs e )
		{
			UpdatePriceGrid();
		}

		private void button3_Click( object sender, EventArgs e )
		{
            String result = xperdex.classes.QueryNewName.Show("Enter new price schedule name");
			if( result.Length > 0 )
			{
				DataRow new_set = schedule.price_exception_sets.NewPriceException( result );
				schedule.session_price_exception_sets.AddGroupMember( session, new_set );
				foreach( DataRow current_price in data.current_price_data.Rows )
				{
					DataRow newrow = schedule.session_price_data.NewRow();
					DataRow price = current_price.GetParentRow( SessionPriceData.TableName );
					newrow[SessionPriceData.ValueColumn] = price[SessionPriceData.ValueColumn];
					newrow[SessionTable.PrimaryKey] = price[SessionTable.PrimaryKey];
					newrow[SessionBundleRelation.PrimaryKey] = price[SessionBundleRelation.PrimaryKey];
					newrow[PrizeLevelNames.PrimaryKey] = price[PrizeLevelNames.PrimaryKey];
					newrow[PriceExceptionSet.PrimaryKey] = new_set[PriceExceptionSet.PrimaryKey];
					schedule.session_price_data.Rows.Add( newrow );
				}
				sessionPriceExceptionList1.SelectedItem = new_set;
			}
		}

		private void sessionList1_SelectedIndexChanged( object sender, EventArgs e )
		{
			this.sessionPriceExceptionList1.SelectedIndex = -1;
			this.sessionPriceExceptionList1.SelectedIndex = 0;
		}

	}
}