using System.Data;
using System;
using System.Collections.Generic;
namespace xperdex.classes
{

    public partial class OptionMapDataset
    {
        partial class mapDataTable
        {
        }

        partial class nameDataTable
        {
            public object GetNameID( DsnConnection dsn, String name )
            {
                DataRow[] row = Select( nameColumn.ColumnName + "='" + name + "'" );
                if( row.Length == 0 )
                {
                    DataRow newname = NewRow();
                    //newname[name_idColumn] = 0; // auto fill
                    newname[nameColumn] = name;
                    Rows.Add( newname );
                    DsnSQLUtil.CommitChanges( dsn, this );
                    return newname[name_idColumn];
                }
                return row[0][name_idColumn];
            }
        }

        public void Fill( DsnConnection dsn )
        {
            DsnSQLUtil.FillDataTable( dsn, name );
            //DsnSQLUtil.FillDataTable( dsn, map, map.option_idColumn.ColumnName + "=" + MySQLDataTable.GetSQLValue( dsn, map.option_idColumn, Guid.Empty ) );
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
            if( DsnSQLUtil.Compare( typeof( int ), uid, 0 ) )
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

        public DataRow CreateOption( DsnConnection dsn, object option_id, object parent_option_id, object name_id )
        {
            DataRow row = map.NewRow();
            row[map.option_idColumn] = option_id;
            row[map.parent_option_idColumn] = parent_option_id;
            row[map.name_idColumn] = name_id;
            map.Rows.Add( row );
            DsnSQLUtil.CommitChanges( dsn, map );
            return row;
        }
        public DataRow CreateOption( DsnConnection dsn, object parent_option_id, object name_id )
        {
            DataRow row = map.NewRow();
            //row[map.option_idColumn] = option_id;
            row[map.parent_option_idColumn] = parent_option_id;
            row[map.name_idColumn] = name_id;
            map.Rows.Add( row );
            DsnSQLUtil.CommitChanges( dsn, map );
            return row;
        }
        public void CreateOption( DsnConnection dsn, object option_id, object parent_option_id, object name_id, String description )
        {
            DataRow row = map.NewRow();
            row[map.option_idColumn] = option_id;
            row[map.parent_option_idColumn] = parent_option_id;
            row[map.name_idColumn] = name_id;
            row[map.descriptionColumn] = description;
            map.Rows.Add( row );
            DsnSQLUtil.CommitChanges( dsn, map );
        }

        public void SetValue( DsnConnection dsn, object option_id, String value )
        {
            DataRow[] row = values.Select( values.option_idColumn.ColumnName + "='" + option_id.ToString() + "'" );
            if( row.Length == 0 )
            {
                List<DataRow> rows = DsnSQLUtil.FillDataTable( dsn, values, values.option_idColumn.ColumnName + "=" + DsnSQLUtil.GetSQLValue( dsn, values.option_idColumn, option_id ) );
                if( rows == null || rows.Count == 0 )
                {
                    DataRow newval = values.NewRow();
                    newval[values.option_idColumn] = option_id;
                    newval[values.stringColumn] = value;
                    values.Rows.Add( newval );
                    DsnSQLUtil.CommitChanges( dsn, values );
                }
                else
                {
                    rows[0][values.stringColumn] = value;
                }
            }
            else
                row[0][values.stringColumn] = value;
            DsnSQLUtil.CommitChanges( dsn, values );
        }

        public String GetValue( DsnConnection dsn, object option_id )
        {
            DataRow[] row = values.Select( values.option_idColumn.ColumnName + "='" + option_id.ToString() + "'" );
            if( row.Length == 0 )
            {
                List<DataRow> rows = DsnSQLUtil.FillDataTable( dsn, values, values.option_idColumn.ColumnName + "=" + DsnSQLUtil.GetSQLValue( dsn, values.option_idColumn, option_id ) );
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
                    return rows[0][values.stringColumn].ToString();
                }
            }
            else
                return row[0][values.stringColumn].ToString();
        }
    }

}
