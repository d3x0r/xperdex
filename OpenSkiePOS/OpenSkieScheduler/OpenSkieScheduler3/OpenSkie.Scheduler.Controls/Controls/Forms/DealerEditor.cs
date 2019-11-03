using System;
using System.Data;
using System.Windows.Forms;
using OpenSkieScheduler3.BingoGameDefs;
using OpenSkieScheduler3.Controls.Buttons;

namespace OpenSkieScheduler3.Controls.Forms
{
	public partial class DealerEditor : Form
	{
		Dealer _dealer;
		ScheduleDataSet schedule;
		DataSet ds;
		public DealerEditor( Dealer dealer )
		{
			_dealer = dealer;
			schedule = dealer.DataSet as ScheduleDataSet;
			InitializeComponent();
		}

		private void DealerEditor_Load( object sender, EventArgs e )
		{
            listBox1.DataSource = ControlList.schedule.cardset_info;
			listBox1.DisplayMember = "friendly_name";
			listBox1.ValueMember = "cardset_id";

			dataGridView1.DataSource = _dealer.DataSet.Tables["dealer"];
			dataGridView1.Columns["dealer_id"].Visible = false;
			//dataGridView1.RowHeadersVisible = false;

		}

		DataRow current_cardset;

		void UpdateCurrentCardsetRanges( object cardset_id )
		{

            DataRow[] rows = ControlList.schedule.cardset_ranges.Select(
				 "cardset_id='" + cardset_id + "'" );
			dataGridView3.Columns.Clear();
			if( rows.Length > 0 )
			{
				DataTable table = new DataTable( "current_cardset_ranges" );
				table.Columns.Add( "Name", typeof( string ) );
				table.Columns.Add( "Start", typeof( int ) );
				table.Columns.Add( "End", typeof( int ) );
				table.Columns.Add( "Base", typeof( int ) );
				table.Columns.Add( "Offset", typeof( int ) );
                table.Columns.Add( "dealer_id", ControlList.schedule.dealer.Columns[Dealer.PrimaryKey].DataType );
                table.Columns.Add( "prize_level_id", ControlList.schedule.prize_level_names.Columns[PrizeLevelNames.PrimaryKey].DataType );

				table.Columns.Add( "cardset_range_row", typeof( DataRow ) );
				foreach( DataRow row in rows )
				{
					DataRow newrow = table.NewRow();
					newrow["Name"] = row[OpenSkieScheduler3.BingoGameDefs.CardsetRange.NameColumn];
					newrow["Start"] = row["start"];
					newrow["End"] = row["end"];
					newrow["dealer_id"] = row["dealer_id"];
					newrow["prize_level_id"] = row[PrizeLevelNames.PrimaryKey];
					newrow["cardset_range_row"] = row;
					table.Rows.Add( newrow );
				}
				table.AcceptChanges(); // set rows from Added to Unchanged
				dataGridView3.DataSource = table;
				dataGridView3.Columns["Start"].Width = 80;
				dataGridView3.Columns["End"].Width = 80;
				dataGridView3.Columns["Base"].Width = 80;
				dataGridView3.Columns["Offset"].Width = 80;
				

				DataGridViewComboBoxColumn dgvcbc;
				{
					dgvcbc = new DataGridViewComboBoxColumn();
                    dgvcbc.DataSource = ControlList.schedule.dealer;
					dgvcbc.DisplayMember = Dealer.NameColumn;
					dgvcbc.ValueMember = Dealer.PrimaryKey;
					dgvcbc.HeaderText = "Dealer";
					dgvcbc.DataPropertyName = Dealer.PrimaryKey;
					dgvcbc.Name = "dealer_choice";
					dataGridView3.Columns.Add( dgvcbc );
				}
				{
					dgvcbc = new DataGridViewComboBoxColumn();
                    dgvcbc.DataSource = ControlList.schedule.prize_level_names;
					dgvcbc.DisplayMember = PrizeLevelNames.NameColumn;
					dgvcbc.ValueMember = PrizeLevelNames.PrimaryKey;
					dgvcbc.HeaderText = "Prize\nLevel";
					dgvcbc.DataPropertyName = PrizeLevelNames.PrimaryKey;
					dgvcbc.Name = "prize_level_choice";
					dataGridView3.Columns.Add( dgvcbc );
				}

				dataGridView3.DataError += new DataGridViewDataErrorEventHandler( dataGridView3_DataError );

				//dataGridView3.Columns["cardset_range_id"].Visible = false;
				dataGridView3.Columns["base"].Visible = false;
				dataGridView3.Columns["offset"].Visible = false;
				//dataGridView3.Columns["Level"].Visible = false;
				dataGridView3.Columns["dealer_id"].Visible = false;
				dataGridView3.Columns["prize_level_id"].Visible = false;
				dataGridView3.Columns["cardset_range_row"].Visible = false;
				dataGridView3.CellValueChanged += new DataGridViewCellEventHandler( dataGridView3_CellValueChanged );
				table.RowChanged += new DataRowChangeEventHandler( table_RowChanged );
				table.RowDeleting += new DataRowChangeEventHandler( table_RowDeleted );
			}
		}

		void dataGridView3_DataError( object sender, DataGridViewDataErrorEventArgs e )
		{
			if( e.ColumnIndex == dataGridView3.Columns["dealer_choice"].Index )
			{
				DataGridView dgv = sender as DataGridView;
				try
				{
					dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = _dealer.DefaultDealer;
					e.Cancel = false;
				}
				catch
				{
					e.Cancel = true;
				}
			}
			else
				if( e.ColumnIndex == dataGridView3.Columns["prize_level_choice"].Index )
				{
					DataGridView dgv = sender as DataGridView;
					//dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = ;
					e.Cancel = true;
				}
				else
					throw new Exception( "Unhandled DataError exception" );
		}

		void dataGridView3_CellValueChanged( object sender, DataGridViewCellEventArgs e )
		{
			if( e.ColumnIndex == dataGridView3.Columns["dealer_choice"].Index )
			{
				
			}
			//throw new Exception( "The method or operation is not implemented." );
		}

		private void listBox1_SelectedIndexChanged( object sender, EventArgs e )
		{
			ListControl si = (ListControl)sender;
			DataRowView drv = (DataRowView)listBox1.SelectedItem;
			if( drv == null )
				return;
			checkBox1.Checked = false;
			UpdateCurrentCardsetRanges( drv.Row[0] );

#if asdfasdf
			DataRow[] rows = _dealer.config.Tables["dealer"].Select( "cardset_id=" + drv.Row[0] );
			{
				DataTable table = new DataTable( "current_cardset_dealers" );
				table.Columns.Add( "Name", typeof( String ) );
				table.Columns.Add( "Card Skip", typeof( int ) );
				table.Columns.Add( "Page Skip", typeof( int ) );
				table.Columns.Add( "dealer_row", typeof( DataRow ) );
				foreach( DataRow row in rows )
				{
					DataRow newrow = table.NewRow();
					newrow["Name"] = row["name"];
					newrow["Card Skip"] = row["card_skip"];
					newrow["Page Skip"] = row["page_skip"];
					newrow["dealer_row"] = row;
					table.Rows.Add( newrow );
				}
				table.AcceptChanges(); // set rows from Added to Unchanged
				dataGridView5.DataSource = table;
				dataGridView5.Columns[0].Width = 120;
				dataGridView5.Columns[1].Width = 80;
				dataGridView5.Columns[2].Width = 80;
				dataGridView5.Columns[3].Visible = false;
				table.RowChanged += new DataRowChangeEventHandler( table_RowChanged2 );
				table.RowDeleting += new DataRowChangeEventHandler( table_RowDeleted2 );
			}
#endif

		}
		void table_RowDeleted2( object sender, DataRowChangeEventArgs e )
		{
			DataRow[] rows = _dealer.DataSet.Tables["dealer"].Select( "dealer_id='" + e.Row[0] + "' and cardset_id=" + current_cardset[0] );
			if( rows.Length > 0 )
				rows[0].Delete();
		}

		void table_RowDeleted( object sender, DataRowChangeEventArgs e )
		{
            DataRow[] rows = ControlList.schedule.cardset_ranges.Select( "cardset_ranges_name='" + e.Row[0] + "' and cardset_id=" + current_cardset[0] );
			if( rows.Length > 0 )
				rows[0].Delete();
		}

		bool adding;

		public class NewDealer : MyButton
		{
			protected override void OnClick( EventArgs e )
			{
				//_dealer.config.Tables["dealer"].NewRow()
				base.OnClick( e );
			}
		}

		void table_RowChanged2( object sender, DataRowChangeEventArgs e )
		{
			switch( e.Action )
			{
			case DataRowAction.Change:
				if( adding )
					return;
				DataRow oldrow = (DataRow)e.Row["dealer_row"];
				oldrow[Dealer.NameColumn] = e.Row["Name"];
				oldrow["card_skip"] = e.Row["Card Skip"];
				oldrow["page_skip"] = e.Row["Page Skip"];
				oldrow["row_skip"] = e.Row["Row Skip"];
				oldrow["column_skip"] = e.Row["Column Skip"];
				break;
			case DataRowAction.Add:
				adding = true;
				DataTable table = _dealer.DataSet.Tables["dealer"];
				DataRow newrow = table.NewRow();
				e.Row["dealer_row"] = newrow; // back-equate this row...
				newrow[Dealer.NameColumn] = e.Row["Name"];	// name
				newrow["card_skip"] = e.Row["Card Skip"];
				newrow["page_skip"] = e.Row["Page Skip"];
				newrow["row_skip"] = e.Row["Row Skip"];
				newrow["column_skip"] = e.Row["Column Skip"];
				//newrow["cardset_id"] = //current_cardset["cardset_id"];
				table.Rows.Add( newrow );
				e.Row.AcceptChanges();
				adding = false;
				break;
			}
		}

		void table_RowChanged( object sender, DataRowChangeEventArgs e )
		{
			switch( e.Action )
			{
			case DataRowAction.Change:
				if( adding )
					return;
				DataRow oldrow = (DataRow)e.Row["cardset_range_row"];
				oldrow["start"] = e.Row["Start"];
				oldrow["end"] = e.Row["End"];
				//oldrow["cardset_id"] = e.Row["cardset_id"];
				oldrow["dealer_id"] = e.Row["dealer_id"];
				oldrow["prize_level_id"] = e.Row["prize_level_id"];
				//( (MySQLDataTable)oldrow.Table ).CommitChanges();
				break;
			case DataRowAction.Add:
				adding = true;
                DataRow newrow = ControlList.schedule.cardset_ranges.NewRow();
				e.Row["cardset_range_row"] = newrow; // back-equate this row...
				newrow[CardsetRange.NameColumn] = e.Row[0];	// name
				newrow["start"] = e.Row["Start"];
				newrow["end"] = e.Row["End"];
				//newrow["cardset_id"] = current_cardset["cardset_id"];
				newrow["payout_level"] = e.Row["Level"];
                ControlList.schedule.cardset_ranges.Rows.Add( newrow );
				e.Row.AcceptChanges();
				adding = false;
				break;
			}
		}

		private void checkBox1_CheckedChanged( object sender, EventArgs e )
		{
			CheckBox cb = sender as CheckBox;
			if( cb != null )
			{
				if( dataGridView3.Columns.Count == 0 )
					return;
				if( cb.Checked )
				{
					dataGridView3.Columns["base"].Visible = true;
					dataGridView3.Columns["offset"].Visible = true;
				}
				else
				{
					dataGridView3.Columns["base"].Visible = false;
					dataGridView3.Columns["offset"].Visible = false;
				}
			}
		}

		private void button2_Click( object sender, EventArgs e )
		{
			//_dealer.CommitChanges();
		}

		private void button3_Click( object sender, EventArgs e )
		{
			//_dealer.RejectChanges();
		}

	}
}
