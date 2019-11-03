using System;
using System.Data;
using OpenSkieScheduler3.Relations;
using xperdex.classes;

namespace OpenSkieScheduler3.BingoGameDefs
{
	[SchedulePersistantTable]
	public class SessionPrizeData : MySQLDataTable
	{
		new public static readonly string TableName = "prize_info";
		new public static readonly string PrimaryKey = XDataTable.ID( SessionPrizeData.TableName );
		public static readonly string ValueColumn = "payout";

		void AddColumns()
		{
			Columns.Add( ValueColumn, typeof( Money ) );
			Columns.Add( SessionTable.PrimaryKey, AutoKeyType );
			Columns.Add( SessionGame.PrimaryKey, AutoKeyType );
			Columns.Add( PrizeLevelNames.PrimaryKey, AutoKeyType );
			Columns.Add( PrizeExceptionSet.PrimaryKey, AutoKeyType );
			Columns.Add( SessionPrizeExceptionSet.PrimaryKey, AutoKeyType );
		}

		public SessionPrizeData()
		{
			base.TableName = "(tmp)" + TableName;
			//base.Prefix = OpenSkieSchedule.last_created_schedule.Prefix;
			AddColumns();
		}

		public SessionPrizeData( DataSet dataSet )
			: base( Names.schedule_prefix, TableName, true, false )
		{
			AddColumns();
			dataSet.Tables.Add( this );

			DataRelation data_relation;
			data_relation = new DataRelation( SessionGame.TableName + "_has_prize", dataSet.Tables[SessionGame.TableName].Columns[SessionGame.PrimaryKey], Columns[SessionGame.PrimaryKey] );
			dataSet.Relations.Add( data_relation );
			data_relation = new DataRelation( PrizeLevelNames.TableName + "_has_prize", dataSet.Tables[PrizeLevelNames.TableName].Columns[PrizeLevelNames.PrimaryKey], Columns[PrizeLevelNames.PrimaryKey] );
			dataSet.Relations.Add( data_relation );
			data_relation = new DataRelation( PrizeExceptionSet.TableName + "_has_prize", dataSet.Tables[PrizeExceptionSet.TableName].Columns[PrizeExceptionSet.PrimaryKey], Columns[PrizeExceptionSet.PrimaryKey] );
			dataSet.Relations.Add( data_relation );
			data_relation = new DataRelation( SessionPrizeExceptionSet.TableName + "_has_prize", dataSet.Tables[SessionPrizeExceptionSet.TableName].Columns[SessionPrizeExceptionSet.PrimaryKey], Columns[SessionPrizeExceptionSet.PrimaryKey] );
			dataSet.Relations.Add( data_relation );
		}

		public void DuplicatePrize( DataRow prize, DataRow new_set )
		{
			DataRow newrow = NewRow();
			newrow[SessionPrizeData.ValueColumn] = prize[SessionPrizeData.ValueColumn];
			newrow[SessionTable.PrimaryKey] = prize[SessionTable.PrimaryKey];
			newrow[SessionGame.PrimaryKey] = prize[SessionGame.PrimaryKey];
			newrow[PrizeLevelNames.PrimaryKey] = prize[PrizeLevelNames.PrimaryKey];
			newrow[PrizeExceptionSet.PrimaryKey] = new_set[PrizeExceptionSet.PrimaryKey];
			Rows.Add( newrow );

		}

		public void WritePrize( DataRow session_game, DataRow session_exception_set, DataRow prize_level, Money prize, bool newargs )
		{
			// don't write zero prizes
			if( prize == 0 )
				return;

			DataRow[] existing_row = Select( SessionGame.PrimaryKey + "='" + session_game[SessionGame.PrimaryKey] + "' and "
				+ PrizeExceptionSet.PrimaryKey + "='" + session_exception_set[PrizeExceptionSet.PrimaryKey] + "' and "
				+ PrizeLevelNames.PrimaryKey + ( prize_level == null ? " is NULL" : ( "='" + prize_level[PrizeLevelNames.PrimaryKey] + "'" ) ) );
			if( existing_row.Length == 0 )
			{
				DataRow new_row = NewRow();
				new_row[SessionTable.PrimaryKey] = session_game[SessionTable.PrimaryKey];
				new_row[SessionGame.PrimaryKey] = session_game[SessionGame.PrimaryKey];
				new_row[SessionPrizeExceptionSet.PrimaryKey] = session_exception_set[SessionPrizeExceptionSet.PrimaryKey];
				new_row[PrizeExceptionSet.PrimaryKey] = session_exception_set[PrizeExceptionSet.PrimaryKey];
				new_row[PrizeLevelNames.PrimaryKey] = ( prize_level == null ) ? DBNull.Value : prize_level[PrizeLevelNames.PrimaryKey];
				new_row[ValueColumn] = prize;
				Rows.Add( new_row );
			}
			else
			{
				if( existing_row.Length > 1 )
				{
					throw new Exception( "prize row exists multiple times, data error" );
				}
				if( !existing_row[0][ValueColumn].Equals( prize ) )
					existing_row[0][ValueColumn] = prize;
			}

		}

		public Money GetPrize( DataRow session_game, DataRow session_exception_set, DataRow prize_level )
		{
			DataRow[] rows;
			if( prize_level != null )
				rows = Select( PrizeLevelNames.PrimaryKey + "='" + prize_level[PrizeLevelNames.PrimaryKey]
					+ "' and " + SessionGame.PrimaryKey + "='" + session_game[SessionGame.PrimaryKey] + "'"
					+ " and " + PrizeExceptionSet.PrimaryKey + "='" + session_exception_set[PrizeExceptionSet.PrimaryKey] + "'"
				);
			else
				rows = Select( PrizeLevelNames.PrimaryKey + " is NULL and " + SessionGame.PrimaryKey + "='" + session_game[SessionGame.PrimaryKey] + "'"
					+ " and " + PrizeExceptionSet.PrimaryKey + "='" + session_exception_set[PrizeExceptionSet.PrimaryKey] + "'"
				);
			if( rows.Length > 0 )
			{
				if( rows.Length > 1 )
					Log.log( "damnit." );
				return rows[0][SessionPrizeData.ValueColumn] as Money;
			}
			return new Money( 0 );
		}

		public DataRow AddClonedRow( DataRow session_prize_exception, DataRow session_game, DataRow cloned_prize_level, DataRow original )
		{
			DataRow row = NewRow();
			foreach( DataColumn dc in Columns )
			{
				try
				{
					// leave this NULL and auto-increment
					if( dc.AutoIncrement )
						continue;
					if( dc.ColumnName == PrizeExceptionSet.PrimaryKey )
						row[dc.ColumnName] = session_prize_exception[PrizeExceptionSet.PrimaryKey];
					else if( dc.ColumnName == SessionPrizeExceptionSet.PrimaryKey )
						row[dc.ColumnName] = session_prize_exception[SessionPrizeExceptionSet.PrimaryKey];
					else if( dc.ColumnName == SessionTable.PrimaryKey )
						row[dc.ColumnName] = session_prize_exception[SessionTable.PrimaryKey];
					else if( dc.ColumnName == PrizeLevelNames.PrimaryKey )
						row[dc.ColumnName] = cloned_prize_level[PrizeLevelNames.PrimaryKey];
					else if( dc.ColumnName == SessionGame.PrimaryKey )
						row[dc.ColumnName] = session_game[SessionGame.PrimaryKey];
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
