using System;
using System.Data;
using xperdex.classes;

namespace OpenSkieScheduler3.BingoGameDefs
{
	public class CurrentCardsetRanges : DataTable
	{
		new public static readonly String TableName = "current_cardset_ranges";
		public static readonly String DisplayName = "Name";
		
		static String cardset_range_id = CardsetRange.PrimaryKey;
		ScheduleDataSet schedule;

        public CurrentCardsetRanges()
        {
			base.TableName = "(tmp)" + TableName;
        }

		public CurrentCardsetRanges(DataSet dataSet)
		{
			schedule = dataSet as ScheduleDataSet;
			base.Prefix = Names.schedule_prefix;
			base.TableName = TableName;

			Columns.Add( DisplayName, typeof( string ) );
			Columns.Add( "Start", typeof( int ) );
			Columns.Add( "End", typeof( int ) );
			Columns.Add( "Base", typeof( int ) );
			Columns.Add( "Offset", typeof( int ) );
			Columns.Add( "Double Action", typeof( bool ) );
			Columns.Add( "Electronic", typeof( bool ) );
			Columns.Add( "Barcode Paper", typeof( bool ) );
            Columns.Add( "multi level payout", typeof(bool));
			Columns.Add( "Sales Database", typeof(string)).MaxLength = 64;

			DataColumn range_bind = Columns.Add( CardsetRange.PrimaryKey, XDataTable.DefaultAutoKeyType );
			Columns.Add( Dealer.PrimaryKey, XDataTable.DefaultAutoKeyType );
			Columns.Add( PrizeLevelNames.PrimaryKey, XDataTable.DefaultAutoKeyType );

			if( dataSet.Tables.Contains( this.ToString() ) == false )
			{
				dataSet.Tables.Add( this );
				dataSet.Relations.Add( new DataRelation( CardsetRange.TableName
					, dataSet.Tables[ CardsetRange.TableName ].Columns[ CardsetRange.PrimaryKey ]
					, range_bind ) );

				//dataSet.Relations.Add( new DataRelation( CardsetRange.TableName
				//	, dataSet.Tables[CardsetRange.TableName].Columns[CardsetRange.PrimaryKey]
				//	, range_bind ) );
			}
		}
		bool updating;

		protected override void OnRowDeleting( DataRowChangeEventArgs e )
		{
            if( e.Row.GetParentRow( CardsetRange.TableName ) != null )
			    e.Row.GetParentRow( CardsetRange.TableName ).Delete();

			//(e.Row["cardset_range_row"]as DataRow).Delete();
		}

		bool adding;
		protected override void OnRowChanged( DataRowChangeEventArgs e )
		{
			switch( e.Action )
			{
			case DataRowAction.Change:
				if( adding )
					return;
				DataRow oldrow = e.Row.GetParentRow( CardsetRange.TableName );// (DataRow)e.Row["cardset_range_row"];
				oldrow["start"] = e.Row["Start"];
				oldrow["end"] = e.Row["End"];
				oldrow["dealer_id"] = e.Row["dealer_id"];
				oldrow["base"] = e.Row["Base"];
				oldrow["electronic"] = e.Row["Electronic"];
				oldrow["barcode_paper"] = e.Row["Barcode Paper"];
				oldrow["offset"] = e.Row["Offset"];
                oldrow["sales_database"] = e.Row["Sales Database"];
				oldrow["multi_level_payout"] = e.Row["multi level payout"];
				oldrow["double_action"] = e.Row["Double Action"];
				oldrow[PrizeLevelNames.PrimaryKey] = e.Row[PrizeLevelNames.PrimaryKey];
				try
				{
					oldrow[CardsetRange.NameColumn] = e.Row[DisplayName];
				}
				catch( ConstraintException )
				{
					e.Row[DisplayName] = oldrow[CardsetRange.NameColumn];
				}
				//schedule.cardset_ranges.CommitChanges();
				break;
			case DataRowAction.Add:
				if( schedule == null )
					return;
				if( updating )
					return;
				adding = true;
				DataRow newrow = schedule.cardset_ranges.NewRow();
				//e.Row["cardset_range_row"] = newrow; // back-equate this row...
				newrow[XDataTable.Name( newrow.Table )] = e.Row[DisplayName];	// name
				newrow["start"] = e.Row["Start"];
				newrow["end"] = e.Row["End"];
				newrow["base"] = e.Row["Base"];
				newrow["offset"] = e.Row["Offset"];
				newrow["electronic"] = e.Row["Electronic"];
				newrow["barcode_paper"] = e.Row["Barcode Paper"];
                newrow["sales_database"] = e.Row["Sales Database"];
				newrow[Dealer.PrimaryKey] = e.Row[Dealer.PrimaryKey];
				newrow["multi_level_payout"] = e.Row["multi level payout"];
				newrow["double_action"] = e.Row["Double Action"];
				
				if( cardset == null || cardset.RowState == DataRowState.Detached )
					newrow[CardsetInfo.PrimaryKey] = DBNull.Value;
				else
					newrow[CardsetInfo.PrimaryKey] = cardset[CardsetInfo.PrimaryKey];
				newrow[PrizeLevelNames.PrimaryKey] = e.Row[PrizeLevelNames.PrimaryKey];
				//e.Row["cardset_range_id"] = newrow;
				try
				{
					schedule.cardset_ranges.Rows.Add( newrow );
					//schedule.cardset_ranges.CommitChanges();
					e.Row[cardset_range_id] = newrow[cardset_range_id];
				}
				catch
				{
					//System.Windows.Forms.MessageBox.Show( "Name Already exists.  Removing new item." );
					e.Row.Delete();
					//throw;
				}
				//schedule.cardset_ranges.CommitChanges();
				adding = false;
				break;
			}
			base.OnRowChanged( e );
		}

		DataRow cardset;
		public DataRow Cardset
		{
			set
			{
				if( cardset != value )
				{
					cardset = value;
					Clear();
					if( cardset != null )
					{
						updating = true;
						DataRow[] rows = schedule.cardset_ranges.Select(
							XDataTable.ID( cardset.Table )
							+ "='" + cardset[XDataTable.ID( cardset.Table )] + "'" );
						foreach( DataRow row in rows )
						{
							DataRow newrow = NewRow();
							newrow["Name"] = row["cardset_range_name"];
							newrow["Start"] = row["start"];
							newrow["End"] = row["end"];
							newrow["Offset"] = row["offset"];
							newrow["Electronic"] = row["electronic"];
							newrow["Barcode Paper"] = row["barcode_paper"];
							newrow["dealer_id"] = row["dealer_id"];
							newrow["Base"] = row["base"];
                            newrow["Sales Database"] = row["sales_database"];
							newrow[PrizeLevelNames.PrimaryKey] = row[PrizeLevelNames.PrimaryKey];
							newrow["cardset_range_id"] = row["cardset_range_id"];
							newrow["multi level payout"] = row["multi_level_payout"];
							newrow["Double Action"] = row["double_action"];
							Rows.Add( newrow );
						}
						AcceptChanges(); // set rows from Added to Unchanged
					}
					updating = false;
				}
			}
		}
	}
}
