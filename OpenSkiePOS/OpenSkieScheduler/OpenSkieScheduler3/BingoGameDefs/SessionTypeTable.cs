using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xperdex.classes;
using System.Data;

namespace OpenSkieScheduler3.BingoGameDefs
{
	[SchedulePersistantTable]
	public class SessionTypeTable : MySQLNameTable
	{
		new public static readonly string TableName = "session_type_names";
		new public static readonly string PrimaryKey = XDataTable.ID( SessionTypeTable.TableName );
		new public static readonly string NameColumn = XDataTable.Name( SessionTypeTable.TableName );

		public SessionTypeTable()
		{
			base.TableName = "(tmp)" + SessionTypeTable.TableName;
		}

		public SessionTypeTable( DataSet dataSet )
			: base( Names.schedule_prefix, TableName )
		{
            if( !dataSet.Tables.Contains( (this as DataTable).TableName ) )
    			dataSet.Tables.Add( this );
		}

		void AddColumns()
		{
		}

		public DataRow NewSessionType( String type )
		{
			DataRow newrow;
			newrow = NewRow();
			newrow[XDataTable.Name( this )] = type;
			Rows.Add( newrow );
			return newrow;
		}
	}
}
