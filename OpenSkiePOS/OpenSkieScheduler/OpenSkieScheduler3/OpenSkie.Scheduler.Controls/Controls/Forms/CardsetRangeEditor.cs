using System;
using System.Data;
using System.Windows.Forms;
using OpenSkieScheduler3.BingoGameDefs;

namespace OpenSkieScheduler3.Controls.Forms
{
	public partial class CardsetRangeEditor : Form
	{
		DataRow current_session;
		int session_number;
		DataRow current_game;
		int game_number;
		DataRow current_cardset;
		//SessionInfo session_info;
		DataTable cardset_payout_view;

		public CardsetRangeEditor()
		{
			InitializeComponent();
		}

		void cardset_payout_view_RowDeleted( object sender, DataRowChangeEventArgs e )
		{
			DataRow delete = (DataRow)e.Row[1];
			delete.Delete();
		}

		private void CardsetList_SelectedIndexChanged( object sender, EventArgs e )
		{
			ListControl si = (ListControl)sender;
			DataRowView drv = (DataRowView)CardsetList.SelectedItem;
			if( drv == null )
				return;
            DataRow[] rows = ControlList.schedule.cardset_ranges.Select( 
				drv.Row.Table.Columns[0].ColumnName 
				+ "='" + drv.Row[0] + "'" );
			current_cardset = drv.Row;
			ControlList.data.current_cardset_ranges.Cardset = current_cardset;
		}

#if asdfasdf
		void table_RowDeleted( object sender, DataRowChangeEventArgs e )
		{
			DataRow[] rows = ControlList.data.cardset_ranges.Select( "cardset_ranges_name='" + e.Row[0] + "' and cardset_id=" + current_cardset[0] );
			if( rows.Length > 0 )
			{
				foreach( DataRow row in rows )
				{
					row.Delete();
				}
				ControlList.data.cardset_ranges.AcceptChanges();
			}
		}

		bool adding;
		void table_RowChanged( object sender, DataRowChangeEventArgs e )
		{
			switch( e.Action )
			{
			case DataRowAction.Change:
				if( adding )
					return;
				DataRow oldrow = (DataRow)e.Row[3];
				oldrow["start"] = e.Row["Start"];
				oldrow["end"] = e.Row["End"];
				oldrow["base"] = e.Row["Base"];
				oldrow["offset"] = e.Row["Offset"];
				oldrow[1] = e.Row[0];
				oldrow["payout_level"] = e.Row["Level"];
				ControlList.data.cardset_ranges.AcceptChanges();
				break;
			case DataRowAction.Add:
				adding = true;
				DataRow newrow = ControlList.data.cardset_ranges.NewRow();
				e.Row[3] = newrow; // back-equate this row...
				newrow[XDataTable.Name(newrow.Table)] = e.Row[0];	// name
				newrow["start"] = e.Row["Start"];
				newrow["end"] = e.Row["End"];
				newrow["cardset_id"] = current_cardset["cardset_id"];
				newrow["payout_level"] = e.Row["Level"];
				ControlList.data.cardset_ranges.Rows.Add( newrow );
				ControlList.data.cardset_ranges.AcceptChanges();
				e.Row.AcceptChanges();
				adding = false;
				break;
			}
		}
#endif

		private void button1_Click( object sender, EventArgs e )
		{
			CardsetEditor cse = new CardsetEditor();
			cse.ShowDialog();
			CardsetList.DataSource = null;
            CardsetList.DataSource = ControlList.schedule.cardset_info;
			CardsetList.DisplayMember = CardsetInfo.DisplayMemberName;
		}

		private void CardsetRangeEditor_Load( object sender, EventArgs e )
		{
			listBoxPacksInRange.DataSource = ControlList.data.current_cardset_range_packs;
			listBoxPacksInRange.DisplayMember = ControlList.data.current_cardset_range_packs.NameColumn;

            CardsetList.DataSource = ControlList.schedule.cardset_info;
			CardsetList.DisplayMember = CardsetInfo.DisplayMemberName;

			CardsetRanges.DataSource = ControlList.data.current_cardset_ranges;
			CardsetRanges.SelectionChanged += new EventHandler( CardsetRanges_SelectionChanged );
			CardsetRanges.Columns[1].Width = 80;
			CardsetRanges.Columns[2].Width = 80;
			CardsetRanges.Columns["Electronic"].Width = 60;
			CardsetRanges.Columns["Barcode Paper"].Width = 60;
			CardsetRanges.Columns["Double Action"].Width = 60;

			CardsetRanges.Columns[OpenSkieScheduler3.PrizeLevelNames.PrimaryKey].Visible = false;
			CardsetRanges.Columns["cardset_range_id"].Visible = false;
			CardsetRanges.Columns[OpenSkieScheduler3.BingoGameDefs.CardsetRange.PrimaryKey].Visible = false;

			CardsetRanges.Columns["dealer_id"].Visible = false;
			


			//GameList.Co
			//CarsetRangePayout;
			cardset_payout_view = new DataTable( "current_session_game_cardsets" );
			cardset_payout_view.Columns.Add( "Name", typeof( string ) );
			cardset_payout_view.Columns.Add( "Cardset_row", typeof( DataRow ) );

		}

		void CardsetRanges_SelectionChanged( object sender, EventArgs e )
		{
			if( CardsetRanges.SelectedCells.Count < 2 )
				foreach( DataGridViewCell drvc in CardsetRanges.SelectedCells )
				{
					if( drvc.RowIndex < ControlList.data.current_cardset_ranges.Rows.Count )
					{
						DataRow row = ControlList.data.current_cardset_ranges.Rows[drvc.RowIndex];
						ControlList.data.current_cardset_range_packs.Current = row.GetParentRow( CardsetRange.TableName );
					}
				}
		}

	}
}