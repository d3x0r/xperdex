using System;
using System.Data;
using OpenSkieScheduler3.Relations;
using xperdex.classes;

namespace OpenSkieScheduler3.BingoGameDefs
{
	[SchedulePersistantTable]
	public class SessionPriceData : MySQLDataTable<DataRow>
	{
		new public static readonly string TableName = "price_info";
		new public static readonly string PrimaryKey = XDataTable.ID( SessionPriceData.TableName );
		public static readonly string ValueColumn = "value";
		void AddColumns()
		{
			Columns.Add( ValueColumn, typeof( Money ) );
			Columns.Add( SessionTable.PrimaryKey, AutoKeyType );
			Columns.Add( SessionBundleRelation.PrimaryKey, AutoKeyType );
			Columns.Add( PrizeLevelNames.PrimaryKey, AutoKeyType );
			Columns.Add( SessionPriceExceptionSet.PrimaryKey, AutoKeyType );
			Columns.Add( PriceExceptionSet.PrimaryKey, AutoKeyType );
		}

		public SessionPriceData()
		{
			base.TableName = "(tmp)" + TableName;	
			//base.Prefix = OpenSkieSchedule.last_created_schedule.Prefix;
			AddColumns();
		}

		public SessionPriceData( DataSet dataSet )
			: base( null, Names.schedule_prefix, TableName, true, false )
		{
			AddColumns();
			dataSet.Tables.Add( this );

			DataRelation data_relation;
			data_relation = new DataRelation( SessionBundleRelation.TableName + "_has_price"
				, dataSet.Tables[SessionBundleRelation.TableName].Columns[SessionBundleRelation.PrimaryKey]
				, Columns[SessionBundleRelation.PrimaryKey] );
			dataSet.Relations.Add( data_relation );
			data_relation = new DataRelation( PrizeLevelNames.TableName + "_has_price"
				, dataSet.Tables[PrizeLevelNames.TableName].Columns[PrizeLevelNames.PrimaryKey]
				, Columns[PrizeLevelNames.PrimaryKey] );
			dataSet.Relations.Add( data_relation );
			data_relation = new DataRelation( PriceExceptionSet.TableName + "_has_price"
				, dataSet.Tables[PriceExceptionSet.TableName].Columns[PriceExceptionSet.PrimaryKey]
				, Columns[PriceExceptionSet.PrimaryKey] );
			dataSet.Relations.Add( data_relation );
			data_relation = new DataRelation( SessionPriceExceptionSet.TableName + "_has_price"
				, dataSet.Tables[SessionPriceExceptionSet.TableName].Columns[SessionPriceExceptionSet.PrimaryKey]
				, Columns[SessionPriceExceptionSet.PrimaryKey] );
			dataSet.Relations.Add( data_relation );
		}

		public void WritePrice( DataRow session_item, DataRow session_exception_set, DataRow prize_level, object price )
		{
			DataRow[] existing_row = Select( SessionBundleRelation.PrimaryKey + "='" + session_item[SessionBundleRelation.PrimaryKey] + "' and " 
				+ PriceExceptionSet.PrimaryKey + "='" + session_exception_set[PriceExceptionSet.PrimaryKey] + "' and "
				+ PrizeLevelNames.PrimaryKey + ( prize_level == null?" is NULL":("='"+prize_level[PrizeLevelNames.PrimaryKey]+"'" ) ) );
			if( existing_row.Length == 0 )
			{
				DataRow new_row = NewRow();
				new_row[SessionTable.PrimaryKey] = session_item[SessionTable.PrimaryKey];
				new_row[SessionBundleRelation.PrimaryKey] = session_item[SessionBundleRelation.PrimaryKey];
				new_row[PriceExceptionSet.PrimaryKey] = session_exception_set[PriceExceptionSet.PrimaryKey];
				new_row[SessionPriceExceptionSet.PrimaryKey] = session_exception_set[SessionPriceExceptionSet.PrimaryKey];
				new_row[PrizeLevelNames.PrimaryKey] = ( prize_level == null ) ? DBNull.Value : prize_level[PrizeLevelNames.PrimaryKey];
				new_row[ValueColumn] = price;
				Rows.Add( new_row );
			}
			else
			{
				if( existing_row.Length > 1 )
				{
					throw new Exception( "price row exists multiple times, data error" );
				}
				existing_row[0][ValueColumn] = price;
			}

		}

		/// <summary>
		/// Update the price of a pack
		/// </summary>
		/// <param name="session_item">session item to set price on</param>
		/// <param name="exception_set_name">name of price exception set to update the price of (Default is default prices)</param>
		/// <param name="prize_level">set the price of a specific prize level (value added prize like validation)</param>
		/// <param name="price">the price to set.</param>
		public void WritePrice( DataRow session_item, String exception_set_name, DataRow prize_level, object price )
		{
			DataTable price_excepts = DataSet.Tables[PriceExceptionSet.TableName];
			DataRow[] exception_set = price_excepts.Select( PriceExceptionSet.NameColumn 
				+ "='"
				+ DsnConnection.Escape( DsnConnection.ConnectionMode.NativeDataTable, DsnConnection.ConnectionFlavor.Unknown, exception_set_name ) 
				+ "'" );
			if( exception_set.Length > 0 )
			{
				DataTable session_price_excepts = DataSet.Tables[SessionPriceExceptionSet.TableName];
				DataRow[] __session_exception_set = session_price_excepts.Select( SessionTable.PrimaryKey + "='" + session_item[SessionTable.PrimaryKey] + "' and " + PriceExceptionSet.PrimaryKey + "='" + exception_set[0][PriceExceptionSet.PrimaryKey] + "'" );
				if( __session_exception_set.Length > 0 )
					WritePrice( session_item, __session_exception_set[0], prize_level, price );
				else
				{
					int a = 3;
				}
			}
			else
			{
				int a = 3;
			}
		}

		public Money GetPrice( DataRow session_item, DataRow exception_set, DataRow prize_level )
		{
			DataRow[] rows;
			if( prize_level != null )
				rows = Select( PrizeLevelNames.PrimaryKey + "='" + prize_level[PrizeLevelNames.PrimaryKey]
					+ "' and " + SessionBundleRelation.PrimaryKey + "='" + session_item[SessionBundleRelation.PrimaryKey] + "'"
					+ " and " + PriceExceptionSet.PrimaryKey + "='" + exception_set[PriceExceptionSet.PrimaryKey] + "'"
				);
			else
				rows = Select( PrizeLevelNames.PrimaryKey + " is NULL and " + SessionBundleRelation.PrimaryKey + "='" + session_item[SessionBundleRelation.PrimaryKey] + "'"
					+ " and " + PriceExceptionSet.PrimaryKey + "='" + exception_set[PriceExceptionSet.PrimaryKey] + "'"
				);
			if( rows.Length > 0 )
			{
				if( rows.Length > 1 )
					Log.log( "damnit." );
				return rows[0][SessionPriceData.ValueColumn] as Money;
			}
			return new Money( 0 );

		}

		public Money GetPrice( DataRow session_item, String exception_set_name, DataRow prize_level )
		{
			DataTable price_excepts = DataSet.Tables[PriceExceptionSet.TableName];
			DataRow[] exception_set = price_excepts.Select( PriceExceptionSet.NameColumn
				+ "='"
				+ DsnConnection.Escape( DsnConnection.ConnectionMode.NativeDataTable, DsnConnection.ConnectionFlavor.Unknown, exception_set_name )
				+ "'" );
			if( exception_set.Length > 0 )
			{
				DataTable session_price_excepts = DataSet.Tables[SessionPriceExceptionSet.TableName];
				DataRow[] __session_exception_set = session_price_excepts.Select( SessionTable.PrimaryKey + "='" + session_item[SessionTable.PrimaryKey] + "' and " + PriceExceptionSet.PrimaryKey + "='" + exception_set[0][PriceExceptionSet.PrimaryKey] + "'" );
				if( __session_exception_set.Length > 0 )
					return GetPrice( session_item, __session_exception_set[0], prize_level );
				else
				{
					int a = 3;
				}
			}
			else
			{
				int a = 3;
			}
			return null;
		}

		public DataRow AddClonedRow( DataRow session_price_exception, DataRow session_bundle, DataRow cloned_prize_level, DataRow original )
		{
			DataRow row = NewRow();
			foreach( DataColumn dc in Columns )
			{
				try
				{
					// leave this NULL and auto-increment
					if( dc.AutoIncrement )
						continue;
					if( dc.ColumnName == PriceExceptionSet.PrimaryKey )
						row[dc.ColumnName] = session_price_exception[PriceExceptionSet.PrimaryKey];
					else if( dc.ColumnName == SessionPriceExceptionSet.PrimaryKey )
						row[dc.ColumnName] = session_price_exception[SessionPriceExceptionSet.PrimaryKey];
					else if( dc.ColumnName == SessionTable.PrimaryKey )
						row[dc.ColumnName] = session_price_exception[SessionTable.PrimaryKey];
					else if( cloned_prize_level != null && dc.ColumnName == PrizeLevelNames.PrimaryKey )
						row[dc.ColumnName] = cloned_prize_level[PrizeLevelNames.PrimaryKey];
					else if( dc.ColumnName == SessionBundleRelation.PrimaryKey )
						row[dc.ColumnName] = session_bundle[SessionBundleRelation.PrimaryKey];
					else
						row[dc.ColumnName] = original[dc.ColumnName];
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
