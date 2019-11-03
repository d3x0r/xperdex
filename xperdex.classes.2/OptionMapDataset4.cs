using System;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;

namespace xperdex.classes
{

    public partial class OptionMapDataset4
    {
        [SQLPersistantTable]
        partial class exceptionDataTable
        {
        }

        [SQLPersistantTable]
        partial class blobsDataTable
        {
        }

        [SQLPersistantTable]
        partial class valuesDataTable
        {
            public override void BeginInit()
            {
                this.keys.Add( new XDataTableKey( true, "segkey", new string[] { "segment", "option_id" } ) );
                base.BeginInit();
            }
        }

        [SQLPersistantTable]
        partial class mapDataTable
        {
        }

        [SQLPersistantTable]
        partial class nameDataTable
        {
            public object GetNameID( DsnConnection dsn, String name )
            {
                DataRow[] row = Select( nameColumn.ColumnName + "='" + name + "'" );
                if( row.Length == 0 )
                {
                    OptionMapDataset4 ds = this.DataSet as OptionMapDataset4;
                    DataRow newname = NewRow();
                    newname[name_idColumn] = DsnConnection.GetGUID( dsn );
                    newname[nameColumn] = name;
                    Rows.Add( newname );
                    ds.ScheduleCommit( dsn, this );
                    return newname[name_idColumn];
                }
                return row[0][name_idColumn];
            }
        }

        public void Fill( DsnConnection dsn )
        {
            DsnSQLUtil.FillDataTable( dsn, name );
            DsnSQLUtil.FillDataTable( dsn, map, map.parent_option_idColumn.ColumnName + "=" + DsnSQLUtil.GetSQLValue( dsn, map.option_idColumn, Guid.Empty ) );
            if( map.Rows.Count == 0 )
            {
                DataRow map_root = map.NewRow();
                map_root[map.option_idColumn] = Guid.Empty;
                map_root[map.parent_option_idColumn] = Guid.Empty;
                map_root[map.descriptionColumn] = "Option Map Root";
                map_root[map.name_idColumn] = name.GetNameID( dsn, "." );
                map.Rows.Add( map_root );
                ScheduleCommit( dsn, map );
            }
            //OptionMapDatasetTableAdapters.option2_nameTableAdapter da = new OptionMapDatasetTableAdapters.option2_nameTableAdapter();
            //da.Fill( this.option2_name );
            //this.option2_valuesTableAdapter.Fill( this.option2_map );
            //OptionMapDatasetTableAdapters.option2_valuesTableAdapter da3 = new OptionMapDatasetTableAdapters.option2_valuesTableAdapter();
            //da3.Fill( this.option2_values );
        }
        //OptionMapDatasetTableAdapters.option2_mapTableAdapter map_adapter = new OptionMapDatasetTableAdapters.option2_mapTableAdapter();
        public DataRow[] LoadMore( DsnConnection dsn, object uid )
        {
            DataRow[] rows;
            DsnSQLUtil.FillDataTable( dsn, map, map.parent_option_idColumn.ColumnName + "=" + DsnSQLUtil.GetSQLValue( dsn, map.option_idColumn, uid ) );
            if( DsnSQLUtil.Compare( typeof( Guid ), uid, Guid.Empty ) )
            {
                rows = map.Select( map.option_idColumn.ColumnName + "='" + uid.ToString() + "'" );
                if( rows.Length == 0 )
                {
                    CreateOption( dsn, uid, uid, name.GetNameID( dsn, "." ) );
                }
                rows = map.Select( map.parent_option_idColumn.ColumnName + "='" + uid.ToString() + "'and " + map.option_idColumn.ColumnName + "<>'" + uid.ToString() + "'" );
            }
            else
                rows = map.Select( map.parent_option_idColumn.ColumnName + "='" + uid.ToString() + "'" );
            return rows;

        }

        DsnConnection pending_dsn;
        DateTime target_tick;
        void DelayCommit( object sender, EventArgs e )
        {
            if( DateTime.Now > target_tick )
            {
                if( pending_dsn == null )
                    return;
                pending_dsn.BeginTransaction();
                Log.log( "tick delay" );
                foreach( DataTable table in commit_pending )
                    DsnSQLUtil.CommitChanges( pending_dsn, table );
                pending_dsn.EndTransaction();
                commit_pending.Clear();

                delay_commit.Stop();
                delay_commit.Dispose();
                delay_commit = null;
            }
        }
        Timer delay_commit;
        List<DataTable> commit_pending = new List<DataTable>();

        void ScheduleCommit( DsnConnection dsn, DataTable table )
        {
            if( commit_pending.IndexOf( table ) < 0 )
            {
                pending_dsn = dsn;
                commit_pending.Add( table );
                if( delay_commit == null )
                {
                    delay_commit = new Timer();
                    delay_commit.Tick += DelayCommit;
                    delay_commit.Interval = 250;
                    delay_commit.Start();
                }
            }
            Log.log( "Kicking timer." );
            target_tick = DateTime.Now.AddMilliseconds( 250 );
        }

        public DataRow CreateOption( DsnConnection dsn, object option_id, object parent_option_id, object name_id )
        {
            DataRow row = map.NewRow();
            row[map.option_idColumn] = option_id;
            row[map.parent_option_idColumn] = parent_option_id;
            row[map.name_idColumn] = name_id;
            map.Rows.Add( row );
            ScheduleCommit( dsn, map );
            return row;
        }
        public DataRow CreateOption( DsnConnection dsn, object parent_option_id, object name_id )
        {
            DataRow row = map.NewRow();
            //row[map.option_idColumn] = option_id;
            row[map.parent_option_idColumn] = parent_option_id;
            row[map.name_idColumn] = name_id;
            map.Rows.Add( row );
            ScheduleCommit( dsn, map );
            return row;
        }
        public DataRow CreateOption( DsnConnection dsn, object option_id, object parent_option_id, object name_id, String description )
        {
            DataRow row = map.NewRow();
            row[map.option_idColumn] = option_id;
            row[map.parent_option_idColumn] = parent_option_id;
            row[map.name_idColumn] = name_id;
            row[map.descriptionColumn] = description;
            map.Rows.Add( row );
            ScheduleCommit( dsn, map );
            return row;
        }

        public void SetValue( DsnConnection dsn, object option_id, String value )
        {
            int segment = 0;
            DataRow[] row = values.Select( values.option_idColumn.ColumnName + "='" + option_id.ToString() + "'" );
            if( row.Length == 0 )
            {
                List<DataRow> rows = DsnSQLUtil.FillDataTable( dsn, values, values.option_idColumn.ColumnName + "=" + DsnSQLUtil.GetSQLValue( dsn, values.option_idColumn, option_id ), "segment" );
                if( rows == null || rows.Count == 0 )
                {
                    if( value.Length > 99 )
                    {
                        String tmp = value;
                        while( tmp.Length > 99 )
                        {
                            DataRow newval = values.NewRow();
                            newval[values.option_idColumn] = option_id;
                            newval[values.stringColumn] = tmp.Substring( 0, 99 );
                            tmp = tmp.Substring( 99 );
                            newval[values.segmentColumn] = segment++;
                            values.Rows.Add( newval );
                        }
                        value = tmp;
                    }
                    if( value.Length > 0 )
                    {
                        DataRow newval = values.NewRow();
                        newval[values.option_idColumn] = option_id;
                        newval[values.stringColumn] = value;
                        newval[values.segmentColumn] = segment++;
                        values.Rows.Add( newval );
                    }
                }
                else
                {
                    while( value.Length > 99 )
                    {
                        if( segment < rows.Count )
                        {
                            rows[segment++][values.stringColumn] = value.Substring( 0, 99 );
                        }
                        else
                        {
                            DataRow newval = values.NewRow();
                            newval[values.option_idColumn] = option_id;
                            newval[values.stringColumn] = value.Substring( 0, 99 );
                            newval[values.segmentColumn] = segment++;
                            values.Rows.Add( newval );
                        }
                        value = value.Substring( 99 );
                    }
                    if( segment < rows.Count )
                    {
                        rows[segment++][values.stringColumn] = value;
                    }
                    else
                    {
                        DataRow newval = values.NewRow();
                        newval[values.option_idColumn] = option_id;
                        newval[values.stringColumn] = value.Substring( 0, 99 );
                        newval[values.segmentColumn] = segment++;
                        values.Rows.Add( newval );
                    }
                    while( segment < rows.Count )
                    {
                        rows[segment++].Delete();
                    }
                }
            }
            else
            {
                while( value.Length > 99 )
                {
                    if( segment < row.Length )
                    {
                        row[segment++][values.stringColumn] = value.Substring( 0, 99 );
                    }
                    else
                    {
                        DataRow newval = values.NewRow();
                        newval[values.option_idColumn] = option_id;
                        newval[values.stringColumn] = value.Substring( 0, 99 );
                        newval[values.segmentColumn] = segment++;
                        values.Rows.Add( newval );
                    }
                    value = value.Substring( 99 );
                }
                if( segment < row.Length )
                {
                    row[segment++][values.stringColumn] = value;
                }
                else
                {
                    DataRow newval = values.NewRow();
                    newval[values.option_idColumn] = option_id;
                    newval[values.stringColumn] = value;
                    newval[values.segmentColumn] = segment++;
                    values.Rows.Add( newval );
                }
                while( segment < row.Length )
                {
                    row[segment++].Delete();
                }
            }
            ScheduleCommit( dsn, values );
        }

        public String GetValue( DsnConnection dsn, object option_id )
        {
            DataRow[] row = values.Select( values.option_idColumn.ColumnName + "='" + option_id.ToString() + "'" );
            if( row.Length == 0 )
            {
                List<DataRow> rows = DsnSQLUtil.FillDataTable( dsn, values, values.option_idColumn.ColumnName + "=" + DsnSQLUtil.GetSQLValue( dsn, values.option_idColumn, option_id ), "segment" );
                if( rows == null || rows.Count == 0 )
                {
#if asdfasdf
					DataRow newval = values.NewRow();
					newval[values.option_idColumn] = option_id;
					newval[values.stringColumn] = default_value;
					values.Rows.Add( newval );
					MySQLDataTable.CommitChanges( dsn, values );
					return default_value;
#endif
                    //throw new Exception( "soemthign bad" );
                    return null;
                }
                else
                {
                    String tmp = null;
                    foreach( DataRow row_add in rows )
                    {
                        tmp += row_add[values.stringColumn].ToString();
                    }
                    return tmp;
                }
            }
            else
            {
                String tmp = null;
                foreach( DataRow row_add in row )
                {
                    tmp += row_add[values.stringColumn].ToString();
                }
                return tmp;
            }
        }
    }

}
