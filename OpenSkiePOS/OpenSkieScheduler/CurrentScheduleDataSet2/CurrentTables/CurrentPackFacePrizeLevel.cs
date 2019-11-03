using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using xperdex.classes;
using OpenSkieScheduler3.BingoGameDefs;

namespace OpenSkieScheduler3.Relations
{
	/// <summary>
	/// Represents the currently selected Cardset's Cardset Ranges.
	/// </summary>
	public class CurrentPackFacePrizeLevel: CurrentObjectTableView
	{
		new public static readonly String TableName = CurrentObjectTableView.TableName( PackFacePrizeLevel.TableName );

		public CurrentPackFacePrizeLevel()
			: base( null, PackFacePrizeLevel.TableName )
		{

		}
        public CurrentPackFacePrizeLevel( DataSet set )
            : base( set, PackFacePrizeLevel.TableName )
        {

        }
        public override string GetDisplayMember( DataRow row )
		{
            DataRow row_level = row.GetParentRow("prize_level_in_pack_face_prize_level");
            return row_level["prize_level_name"].ToString(); ;
		}
#if asdfasdf

		DataTable cardset_ranges;
		String cardset_keyname;
		DataTable packs;
		String pack_keyname;
		DataTable pack_cardsets;
		DataRow pack;
		bool filling;

		public CurrentPackCardsetRanges( DataSet set )
		{
			cardset_ranges = set.Tables[CardsetRange.TableName];
			packs = set.Tables[PackTable.TableName];
			pack_cardsets = set.Tables[PackCardsetRange.TableName];

			TableName = "current_pack_cardsets";
			Columns.Add( cardset_keyname = XDataTable.ID( cardset_ranges ), typeof( int ) );
			Columns.Add( XDataTable.Name( this ), typeof( String ) );
			Columns.Add( pack_keyname = PackTable.PrimaryKey, typeof( int ) );
			Columns.Add( "name", typeof( String ) );
			set.Tables.Add( this );
			RowDeleting += new DataRowChangeEventHandler( CurrentPackCardsetRanges_RowDeleting );
			cardset_ranges.ColumnChanging += new DataColumnChangeEventHandler( cardset_ranges_ColumnChanging );
			set.Tables[CardsetInfo.TableName].ColumnChanging += new DataColumnChangeEventHandler( CurrentPackCardsetRanges_ColumnChanging );
		}

		void cardset_ranges_ColumnChanging( object sender, DataColumnChangeEventArgs e )
		{
			if( e.Column.ColumnName == CardsetRange.NameColumn )
			{
				DataRow cardset = e.Row.GetParentRow( "cardset_has_cardset_range" );
				{
					DataRow[] currents = Select( cardset_keyname + "=" + e.Row[cardset_keyname] );
					foreach( DataRow current in currents )
					{
						current["name"] = cardset[CardsetInfo.NameColumn] + "(" + e.ProposedValue + ")";
					}
				}
			}
		}

		void CurrentPackCardsetRanges_ColumnChanging( object sender, DataColumnChangeEventArgs e )
		{
			if( e.Column.ColumnName == CardsetInfo.NameColumn )
			{
				DataRow[] ranges = e.Row.GetChildRows( "cardset_has_cardset_range" );
				foreach( DataRow range in ranges )
				{
					DataRow[] currents = Select( cardset_keyname + "=" + range[cardset_keyname] );
					foreach( DataRow current in currents )
					{
						current["name"] = e.ProposedValue + "(" + range[CardsetRange.NameColumn]+ ")";
					}
				}
			}
		}

		void CurrentPackCardsetRanges_RowChanging( object sender, DataRowChangeEventArgs e )
		{

		}

		void cardsets_RowChanging( object sender, DataRowChangeEventArgs e )
		{
					
		}

		void CurrentPackCardsetRanges_RowDeleting( object sender, DataRowChangeEventArgs e )
		{
			{
				DataRow[] rows;
				rows = pack_cardsets.Select( cardset_keyname + "=" + e.Row[cardset_keyname] + " and " + pack_keyname + "=" + e.Row[pack_keyname] );
				foreach( DataRow row in rows )
				{
					row.Delete();
				}
				//pack_cardsets
			}
		}

		protected override void OnRowChanging( DataRowChangeEventArgs e )
		{
			if( filling )
			{
				base.OnRowChanging( e );
				return;
			}
			switch( e.Action )
			{
			case DataRowAction.Add:
				DataRow[] check = null;
				if( e.Row[cardset_keyname].GetType() != typeof( DBNull ) )
					check = pack_cardsets.Select( cardset_keyname + "=" + e.Row[cardset_keyname] + " and " + pack_keyname + "=" + e.Row[pack_keyname] );
				if( check == null || check.Length == 0 )
				{
					DataRow x = pack_cardsets.NewRow();
					x[cardset_keyname] = e.Row[cardset_keyname];
					x[pack_keyname] = e.Row[pack_keyname];
					pack_cardsets.Rows.Add( x );
					pack_cardsets.AcceptChanges();
					//e.Row[cardset_keyname] = x[cardset_keyname];
				}
				else
				{
					MessageBox.Show( "Cardset Range is already part of this pack.\nNot adding again." );
					throw new Exception( "Range already exists in pack." );
				}
				break;
			}

			//base.OnRowChanging( e );
		}

		void Relate( DataSet dataset )
		{

		}

		public void AddCardsetRange( DataRow cardset_range )
		{
			if( pack == null )
			{
				MessageBox.Show( "Pack was not selected." );
				return;
			}
			DataRow cardset_range_row = cardset_range["cardset_range_row"] as DataRow;
			DataRow cardset_info = cardset_range_row.GetParentRow( "cardset_has_cardset_range" );
			DataRow row = NewRow();
			row[XDataTable.ID( cardset_ranges )] = cardset_range[XDataTable.ID( cardset_ranges )];
			row[PackTable.PrimaryKey] = pack[PackTable.PrimaryKey];
			row[XDataTable.Name( this )] = ( cardset_range["cardset_range_row"] as DataRow )[XDataTable.Name( cardset_ranges )];
			row["name"] = cardset_info["friendly_name"] + "(" + cardset_range[CurrentCardsetRanges.DisplayName] + ")";
			try
			{
				Rows.Add( row );
				AcceptChanges();
			}
			catch
			{
				// probably the row already existed... and the addition was aborted?
			}
		}



		public DataRow Pack
		{
			set
			{
				if( pack != value )
				{
					filling = true;
					pack = value;
					Clear();
					DataRow[] rows = pack_cardsets.Select( pack_keyname + "=" + pack[pack_keyname] );

					foreach( DataRow row in rows )
					{
						DataRow[] row_cardsets = row.GetParentRows( "cardset_range_in_pack" );

						foreach( DataRow row_test in row_cardsets )
						{
							DataRow cardset = row_test.GetParentRow( "cardset_has_cardset_range" );
							DataRow add_row = NewRow();
							add_row["name"] = cardset["friendly_name"] + "(" + row_test["cardset_range_name"] + ")";
							add_row[pack_keyname] = row[pack_keyname];
							add_row[XDataTable.Name( this )] = row_cardsets[0][XDataTable.Name( cardset_ranges )];
							add_row[cardset_keyname] = row[cardset_keyname];
							Rows.Add( add_row );
							//add_row[XDataTable.ID( packs )] = current_pack[XDataTable.ID( packs )];

						}
					}
					AcceptChanges();

					filling = false;
				}
			}
		}
#endif
	}
}
