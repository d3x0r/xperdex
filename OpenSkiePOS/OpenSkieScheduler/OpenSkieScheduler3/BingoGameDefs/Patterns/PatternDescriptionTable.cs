using System;
using System.Data;
using xperdex.classes;

namespace OpenSkieScheduler3
{

	public class PatternFilterTable : XDataTable<DataRow>
	{
		new public static readonly String TableName = "filtered_pattern_descriptions";
		public static readonly String NameColumn = XDataTable.Name( TableName );
		new public static readonly String PrimaryKey = XDataTable.ID( TableName );

	}

	[SchedulePersistantTable]
	public class PatternDescriptionTable : MySQLDataTable
	{
		new public static readonly String TableName = "pattern_description";
		public static readonly String NameColumn = XDataTable.Name( TableName );
		new public static readonly String PrimaryKey = XDataTable.ID( TableName );
		public static String[] DataColumns = { 
			"number", 
			"width", 
			"height", 
			"real_mode",
			"mode_mod", 
			"pattern_board_size", 
			"flags", 
			"match",
			"count",
			"crazy_hardway" };

		public enum match_types
		{
			NoPattern = -1,
			Normal = 0,
			NonOverlayable = 6,
			TwoGroups = 7,
			TwoGroupsPrime = 8,
			TwoGroupsNoOver = 9,
			TwoGroupsPrimeNoOver = 10,
			FourFiveSix = 11,
			FourFiveSixSpread = 12,
			TopMiddleBottom = 13, 
			TopMiddleBottomCrazy = 14,
			CrazyMultiCard = 15,
			CrazyMark = 1, 
			ExternalJavaEngine = 18
		}
		public PatternDescriptionTable()
		{
			base.TableName = "(tmp)" + TableName;
		}

		public PatternDescriptionTable( ScheduleDataSet dataSet )
			: base( Names.schedule_prefix, TableName )
		{
			AddDefaultColumns( true, true, true );
			Columns.Add( "number", typeof( int ) );
			Columns.Add( "width", typeof( int ) );
			Columns.Add( "height", typeof( int ) );
			Columns.Add( "real_mode", typeof( int ) );
			Columns.Add( "mode_mod", typeof( int ) );
			Columns.Add( "pattern_board_size", typeof( int ) );
			Columns.Add( "flags", typeof( int ) );
			Columns.Add( "match", typeof( int ) );
			Columns.Add( "count", typeof( int ) );
			Columns.Add( "crazy_hardway", typeof( bool ) );
			dataSet.Tables.Add( this );
			if( dataSet.snapshot )
				Columns[NameColumn].Unique = false;
			//Columns.Add("number", typeof(int)); // should be 
	        }


		public void Add( string p )
		{
			DataRow row = NewRow();
			row[XDataTable.Name( this )] = p;
			Rows.Add( row );
			CommitChanges();
		}

        public DataRow[] LoadPatternSubs( DataRow dataRow )
        {
            DataRow[] data = dataRow.GetChildRows( "pattern_has_sub_pattern" );
            if( data.Length == 0 )
            {
                ScheduleDataSet dataset = this.DataSet as ScheduleDataSet;
                if( dataset != null )
                {
					DsnSQLUtil.FillDataTable( dataset.schedule_dsn
							, dataset.pattern_sub_pattern
							, "select * from " + dataset.pattern_sub_pattern.FullTableName
								   + " where " + PatternDescriptionTable.PrimaryKey + "=" 
								   + DsnSQLUtil.GetSQLValue( dataset.schedule_dsn, Columns[PatternDescriptionTable.PrimaryKey].DataType, dataRow[PatternDescriptionTable.PrimaryKey] )
								   + " order by " + PatternMultiDataTable.NumberMemberName
							, true );
                }
                data = dataRow.GetChildRows( "pattern_has_sub_pattern" );
            }
            return data;

        }

		public DataRow[] LoadPatternJavaInfo( DataRow dataRow )
		{
			DataRow[] data = dataRow.GetChildRows( "pattern_has_java_info" );
			if( data.Length == 0 )
			{
				ScheduleDataSet dataset = this.DataSet as ScheduleDataSet;
				if( dataset != null )
				{
					DsnSQLUtil.FillDataTable( dataset.schedule_dsn
							, dataset.pattern_sub_pattern
							, "select * from " + dataset.pattern_java_server.FullTableName
							   + " where " + PatternDescriptionTable.PrimaryKey + "=" + DsnSQLUtil.GetSQLValue( dataset.schedule_dsn, Columns[PatternDescriptionTable.PrimaryKey], dataRow[PatternDescriptionTable.PrimaryKey] )
							, true );
				}
				data = dataRow.GetChildRows( "pattern_has_java_info" );
			}
			return data;

		}

		public DataRow[] LoadPatternData( DataRow dataRow )
		{
			if( dataRow == null )
			{
				ScheduleDataSet dataset = this.DataSet as ScheduleDataSet;
				if( dataset != null )
					return DsnSQLUtil.FillDataTable( dataset.schedule_dsn, dataset.pattern_data ).ToArray();
				return null;
			}
			else
			{
                int mode;
                if (!Int32.TryParse(dataRow["real_mode"].ToString(), out mode) )
                    mode = 0;
				if( mode == (int)match_types.Normal 
					|| mode == (int)match_types.NonOverlayable
					|| mode == (int)match_types.TwoGroups
					|| mode == (int)match_types.TwoGroupsNoOver
					|| mode == (int)match_types.TwoGroupsPrime
					|| mode == (int)match_types.TwoGroupsPrimeNoOver
					)
				{
					DataRow[] data = dataRow.GetChildRows( "pattern_has_bits" );
					if( data.Length == 0 )
					{
						ScheduleDataSet dataset = this.DataSet as ScheduleDataSet;
						if( dataset != null )
						{
							DsnSQLUtil.FillDataTable( dataset.schedule_dsn
								, dataset.pattern_data
								, "select * from " + dataset.pattern_data.FullTableName + " where " + PatternDescriptionTable.PrimaryKey + "="
									+ DsnSQLUtil.GetSQLValue( connection, dataset.pattern_data.AutoKeyType, dataRow[PatternDescriptionTable.PrimaryKey] ) + " order by block"
								, true );
						}
						data = dataRow.GetChildRows( "pattern_has_bits" );
					}
					return data;
				}
				else if( ( mode == (int)match_types.CrazyMultiCard )
					|| ( mode == (int)match_types.TopMiddleBottom ) )
				{
					return LoadPatternSubs( dataRow );
				}
				else if( mode == (int)match_types.ExternalJavaEngine )
				{
					return LoadPatternJavaInfo( dataRow );
				}
				return null;
			}
		}

		public void SetPattern( DataRow row )
		{
			LoadPatternData( row );
		}

		public DataRow GetPattern( String name )
		{
			DataRow[] pattern = Select( NameColumn + "='" + DsnConnection.Escape( DsnConnection.ConnectionMode.NativeDataTable, DsnConnection.ConnectionFlavor.Unknown, name ) + "'" );
			if( pattern.Length > 0 )
			{
				if( pattern.Length > 1 )
					throw new Exception( "Multiple patterns with same name" );
				return pattern[0];
			}
			return null;
		}

		public DataRow NewPattern( String name )
		{
			DataRow row = NewRow();
			row[NameColumn] = name;
			Rows.Add( row );
			return row;
		}
	}

	[SchedulePersistantTable]
	public class PatternMultiDataTable : MySQLDataTable
	{
		new public static readonly string TableName = "pattern_data_multi";
		new public static readonly string PrimaryKey = "pattern_data_multi_id";
		public static string NumberMemberName { get { return "number"; } }
		new public static string ValueMemberName { get { return PrimaryKey; } }

		public PatternMultiDataTable()
		{
			base.TableName = "(tmp)" + TableName;
		}
		void initPatternMultiData(  DataSet dataSet )
		{
			base.Prefix = Names.schedule_prefix;
			base.TableName = TableName;
            AddDefaultColumns( true, true, false );

			Columns.Add( PatternDescriptionTable.PrimaryKey, XDataTable.DefaultAutoKeyType );
			Columns.Add( "member_pattern_id", xperdex.classes.XDataTable.DefaultAutoKeyType );
            Columns.Add( NumberMemberName, typeof( int ) );

			if( dataSet != null )
            {
                dataSet.Tables.Add( this );
                dataSet.Relations.Add( "pattern_has_sub_pattern"
                    , dataSet.Tables[PatternDescriptionTable.TableName].Columns[PatternDescriptionTable.PrimaryKey]
                    , Columns[PatternDescriptionTable.PrimaryKey] );
				dataSet.Relations.Add( "sub_pattern_is_pattern"
					, dataSet.Tables[PatternDescriptionTable.TableName].Columns[PatternDescriptionTable.PrimaryKey]
					, Columns["member_pattern_id"] );
			}

        }
		public PatternMultiDataTable( DataSet dataSet )
		{
			initPatternMultiData( dataSet );
		}

		public DataRow AddClonedRow( DataRow pattern_data, DataRow pattern )
		{
			if( pattern_data.Table.TableName == PatternDataTable.TableName )
			{
				PatternDataTable real_table = pattern_data.Table as PatternDataTable;
				real_table.DoAddClonedRow( pattern_data, pattern );
			}
			else if( pattern_data.Table.TableName == PatternJavaDataTable.TableName )
			{
				PatternJavaDataTable real_table = pattern_data.Table as PatternJavaDataTable;
				real_table.DoAddClonedRow( pattern_data, pattern );
			}
			else if( pattern_data.Table.TableName == PatternMultiDataTable.TableName )
			{
				PatternMultiDataTable real_table = pattern_data.Table as PatternMultiDataTable;
				real_table.DoAddClonedRow( pattern_data, pattern );
			}
			return null;
		}

		internal DataRow DoAddClonedRow( DataRow pattern_data, DataRow pattern )
		{
			if( pattern_data.Table.TableName == PatternDataTable.TableName )
			{
			}
			DataRow row = NewRow();
			foreach( DataColumn dc in Columns )
			{
				try
				{
					// leave this NULL and auto-increment
					if( dc.AutoIncrement )
						continue;
					if( dc.ColumnName == PatternDescriptionTable.PrimaryKey )
						row[dc.ColumnName] = pattern[PatternDescriptionTable.PrimaryKey];
					else
						row[dc.ColumnName] = pattern_data[dc.ColumnName];
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

	[SchedulePersistantTable( FillMethod="None" )]
	public class PatternDataTable : MySQLDataTable
	{

		new public static readonly string TableName = "pattern_data";
		new public static string PrimaryKey = XDataTable.ID( TableName );
		public static string NumberMemberName { get { return "block"; } }
		new public static string ValueMemberName { get { return PrimaryKey; } }
		new public static readonly string NumberColumn = "block";

		public static string[] DataColumns = { "bits_int", "block" };

		public PatternDataTable()
		{
			base.TableName = "(tmp)" + TableName;
		}


		void initPatternData( DataSet dataSet )
		{
            ScheduleDataSet schedule = dataSet as ScheduleDataSet;
            if( schedule != null )
            {
                PrimaryKey = "ID";
            }
			base.Prefix = Names.schedule_prefix;
			base.TableName = TableName;
			AddDefaultColumns( true, true, false );


			Columns.Add( PatternDescriptionTable.PrimaryKey, XDataTable.DefaultAutoKeyType );
			Columns.Add( "bits_int", typeof( int ) );
			Columns.Add( "block", typeof( int ) );

			dataSet.Tables.Add( this );
			dataSet.Relations.Add( new DataRelation( "pattern_has_bits"
					, dataSet.Tables[PatternDescriptionTable.TableName].Columns[PatternDescriptionTable.PrimaryKey]
					, dataSet.Tables[PatternDataTable.TableName].Columns[PatternDescriptionTable.PrimaryKey] ) );
				
		}

		public PatternDataTable(  DataSet dataSet )
		{
			initPatternData(dataSet );
		}

		public DataRow AddClonedRow( DataRow pattern_data, DataRow pattern )
		{
			if( pattern_data.Table.TableName == PatternDataTable.TableName )
			{
				PatternDataTable real_table = pattern_data.Table as PatternDataTable;
				real_table.DoAddClonedRow( pattern_data, pattern );
			}
			else if( pattern_data.Table.TableName == PatternJavaDataTable.TableName )
			{
				PatternJavaDataTable real_table = pattern_data.Table as PatternJavaDataTable;
				real_table.DoAddClonedRow( pattern_data, pattern );
			}
			else if( pattern_data.Table.TableName == PatternMultiDataTable.TableName )
			{
				PatternMultiDataTable real_table = pattern_data.Table as PatternMultiDataTable;
				real_table.DoAddClonedRow( pattern_data, pattern );
			}
			return null;
		}

		internal DataRow DoAddClonedRow( DataRow pattern_data, DataRow pattern )
		{
			if( pattern_data.Table.TableName == PatternDataTable.TableName )
			{
			}
			DataRow row = NewRow();
			foreach( DataColumn dc in Columns )
			{
				try
				{
					// leave this NULL and auto-increment
					if( dc.AutoIncrement )
						continue;
					if( dc.ColumnName == PatternDescriptionTable.PrimaryKey )
						row[dc.ColumnName] = pattern[PatternDescriptionTable.PrimaryKey];
					else
						row[dc.ColumnName] = pattern_data[dc.ColumnName];
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

    [SchedulePersistantTable(FillMethod = "None")]
    public class PatternJavaDataTable : MySQLDataTable
    {
        new public static readonly String TableName = "pattern_java_data";
        new public static string PrimaryKey = XDataTable.ID(TableName);        
        public static string NumberMemberName { get { return "number"; } }
        new public static string ValueMemberName { get { return PrimaryKey; } }

        public static string[] DataColumns = { "match_server_string" };

        public PatternJavaDataTable()
        {
            base.TableName = "(tmp)" + TableName;
        }

        void initJavaPatternData( DataSet dataSet)
        {
            ScheduleDataSet schedule = dataSet as ScheduleDataSet;
			base.Prefix = Names.schedule_prefix;
            base.TableName = TableName;
            AddDefaultColumns(true, true, false);

            Columns.Add(PatternDescriptionTable.PrimaryKey, XDataTable.DefaultAutoKeyType);
            Columns.Add("match_server_string", typeof(string));

            dataSet.Tables.Add(this);
            dataSet.Relations.Add(new DataRelation("pattern_has_java_info"
                    , dataSet.Tables[PatternDescriptionTable.TableName].Columns[PatternDescriptionTable.PrimaryKey]
                    , dataSet.Tables[PatternJavaDataTable.TableName].Columns[PatternDescriptionTable.PrimaryKey]));
        }

		public PatternJavaDataTable( DataSet dataSet )
        {
            initJavaPatternData( dataSet);
        }

		public DataRow AddClonedRow( DataRow pattern_data, DataRow pattern )
		{
			if( pattern_data.Table.TableName == PatternDataTable.TableName )
			{
				PatternDataTable real_table = pattern_data.Table as PatternDataTable;
				real_table.DoAddClonedRow( pattern_data, pattern );
			}
			else if( pattern_data.Table.TableName == PatternJavaDataTable.TableName )
			{
				PatternJavaDataTable real_table = pattern_data.Table as PatternJavaDataTable;
				real_table.DoAddClonedRow( pattern_data, pattern );
			}
			else if( pattern_data.Table.TableName == PatternMultiDataTable.TableName )
			{
				PatternMultiDataTable real_table = pattern_data.Table as PatternMultiDataTable;
				real_table.DoAddClonedRow( pattern_data, pattern );
			}
			return null;
		}

		internal DataRow DoAddClonedRow( DataRow pattern_data, DataRow pattern )
		{
			DataRow row = NewRow();
			foreach( DataColumn dc in Columns )
			{
				try
				{
					// leave this NULL and auto-increment
					if( dc.AutoIncrement )
						continue;
					if( dc.ColumnName == PatternDescriptionTable.PrimaryKey )
						row[dc.ColumnName] = pattern[PatternDescriptionTable.PrimaryKey];
					else
						row[dc.ColumnName] = pattern_data[dc.ColumnName];
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
