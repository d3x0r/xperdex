using System;
using System.Data;
using System.Windows.Forms;
using xperdex.classes;

namespace OpenSkieScheduler3.BingoGameDefs
{
	[SchedulePersistantTable]
	public class CardsetRange: MySQLDataTable
	{
		new public static readonly String TableName = "cardset_ranges";
		public static readonly String NameColumn = XDataTable.Name( TableName );
		new public static readonly String PrimaryKey = XDataTable.ID( TableName );
		public static String[] DataColumns = {
			//Columns.Add( CardsetInfo.PrimaryKey, XDataTable.DefaultAutoKeyType );
			"start", 
			"end", 
			"base", 
			"offset", 
			"electronic", 
			"barcode_paper", 
			"sales_database",
			"multi_level_payout",
			"double_action"
										 };
		public static String CardsetInfoRelationName;
		public static String DealerRelationName;

        void AddColumns()
        {
			AddDefaultColumns( true, true, true );

			Columns.Add( CardsetInfo.PrimaryKey, XDataTable.DefaultAutoKeyType );
			Columns.Add( PrizeLevelNames.PrimaryKey, XDataTable.DefaultAutoKeyType );
			Columns.Add( "start", typeof( int ) );
			Columns.Add( "end", typeof( int ) );
			Columns.Add( "base", typeof( int ) );
			Columns.Add( "offset", typeof( int ) );
			Columns.Add( "electronic", typeof( bool ) );
			Columns.Add( "barcode_paper", typeof( bool ) );
			Columns.Add( "double_action", typeof( bool ) );
			Columns.Add( Dealer.PrimaryKey, XDataTable.DefaultAutoKeyType );
            DataColumn dc = Columns.Add( "sales_database", typeof(String));
            dc.MaxLength = 64;
			Columns.Add("multi_level_payout", typeof(bool));
			

        }

		public CardsetRange()
		{
			base.TableName = "(tmp)" + TableName;
		}

		[SchedulePersistantTable]
		public CardsetRange( DataSet dataSet )
			: base( Names.schedule_prefix, TableName, false, false )
		{
            AddColumns();

			dataSet.Tables.Add( this );
			dataSet.Relations.Add( CardsetRange.CardsetInfoRelationName = MySQLDataTable.StripPlural( MySQLDataTable.StripInfo( CardsetInfo.TableName ) ) + "_has_" + MySQLDataTable.StripPlural( MySQLDataTable.StripInfo( CardsetRange.TableName ) )
				, dataSet.Tables[CardsetInfo.TableName].Columns[CardsetInfo.PrimaryKey]
				, dataSet.Tables[CardsetRange.TableName].Columns[CardsetInfo.PrimaryKey]
			);
			try
			{
				dataSet.Relations.Add( CardsetRange.DealerRelationName = MySQLDataTable.StripPlural( MySQLDataTable.StripInfo( CardsetRange.TableName ) ) + "_has_" + MySQLDataTable.StripPlural( MySQLDataTable.StripInfo( Dealer.TableName ) )
					, dataSet.Tables[Dealer.TableName].Columns[Dealer.PrimaryKey]
					, dataSet.Tables[CardsetRange.TableName].Columns[Dealer.PrimaryKey]
				);
			}
			catch
			{
				// probably a constraint exception... ranges used to be able to be created without a link to dealer.. NULL if you will
				// this translates between saves badly.
				Log.log( "Deleting rows which reference dealer 0." );
				restart:
				foreach( DataRow row in Rows )
				{
					if( row.RowState == DataRowState.Deleted )
						continue;
					if( Convert.ToInt32( GetSQLValue( row[Dealer.PrimaryKey].GetType(), row[Dealer.PrimaryKey] ) ) == 0 )
					{
						row.Delete();
						goto restart;
					}
				}
				CommitChanges();
				dataSet.EnforceConstraints = true;
			}

		}

		public DataRow NewCardsetRange( string name )
		{
			DataRow[] old_rows = Select( NameColumn + "='" + name + "'" );
			if( old_rows.Length > 0 )
			{
				MessageBox.Show( "Cardset Range'" + name + "' already exists.\nCardset Range names are required to be unique." );
				return null;
			}
			DataRow new_row = NewRow();
			new_row[NameColumn] = name;
			Rows.Add( new_row );
			return new_row;
		}

		public DataRow AddClonedRow( DataRow cardset_range, DataRow updated_cardset, DataRow updated_dealer )
		{
			DataRow row = NewRow();
			foreach( DataColumn dc in Columns )
			{
				try
				{
					// leave this NULL and auto-increment
					if( dc.AutoIncrement )
						continue;
					if( dc.ColumnName == CardsetInfo.PrimaryKey )
						row[dc.ColumnName] = updated_cardset[CardsetInfo.PrimaryKey];
					else if( updated_dealer != null && dc.ColumnName == Dealer.PrimaryKey )
						row[dc.ColumnName] = updated_dealer[Dealer.PrimaryKey];
					else
						row[dc.ColumnName] = cardset_range[dc.ColumnName];
				}
				catch
				{
					// the column night not exist in the source table...
				}
			}
			this.Rows.Add( row );
			return row;
		}
	}
}
