using System;
using System.Data;
using System.Windows.Forms;
//using Csx.kind_classes;
using xperdex.classes;
using OpenSkieScheduler3.Relations;
using OpenSkieScheduler3.BingoGameDefs;

namespace OpenSkieScheduler3
{
    /// <summary>
    /// A grouping of sessions into a Day-macro
    /// Day macros can then be placed on the calendar.
    /// </summary>
	[SchedulePersistantTable]
	public class SessionMacroTable : MySQLNameTable
    {
		new public static readonly String TableName = "session_macro_info";
		public static readonly String NameColumn = XDataTable.Name( TableName );
		new public static readonly String PrimaryKey = XDataTable.ID( TableName );

		public SessionMacroTable(): base( Names.schedule_prefix, TableName )
		{
			base.TableName = "(tmp)" + TableName;
		}
		public SessionMacroTable( ScheduleDataSet dataSet )
			: base( Names.schedule_prefix, SessionMacroTable.TableName )
        {
			AddColumns();
            if( !dataSet.Tables.Contains( ( this as DataTable ).TableName ) )
                dataSet.Tables.Add( this );
		}

		void AddColumns()
		{
			Columns.Add( PriceExceptionSet.PrimaryKey, XDataTable.DefaultAutoKeyType );
			Columns.Add( PrizeExceptionSet.PrimaryKey, XDataTable.DefaultAutoKeyType );
			Columns.Add( SessionTypeTable.PrimaryKey, XDataTable.DefaultAutoKeyType );
		}

	
		public DataRow[] GetSessions( DataRow entry )
		{
			DataRow[] children = entry.GetChildRows( ChildRelations["session_macro_has_session"] );
			DataRow[] result = new DataRow[children.Length];
			int i = 0;
			foreach( DataRow child in children )
			{
				result[i++] = child.GetParentRow( child.Table.ParentRelations["session_in_session_macro"] );
			}
			return result;
		}
		public DataRow NewSessionGroup( String name )
		{
			DataRow[] found = Select( NameColumn +"="+GetSQLValue( name.GetType(), name ) );
			if( found.Length == 0 )
			{
				DataRow new_row = NewRow();
				new_row[NameColumn] = name;
				Rows.Add( new_row );
				return new_row;
			}
			else
				MessageBox.Show(  "Session Group " + name + " already exists!" );
			return null;
		}

	}
}