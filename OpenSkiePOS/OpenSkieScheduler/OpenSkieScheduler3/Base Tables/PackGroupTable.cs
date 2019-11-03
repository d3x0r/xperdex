using System;
using System.Data;
using xperdex.classes;

namespace OpenSkieScheduler3
{
	[SchedulePersistantTable( DefaultFill="DefaultFill") ]
	public class PackGroupTable: MySQLNameTable
	{
		new public static readonly String TableName = "pack_group_info";
		public static readonly String NameColumn = XDataTable.Name( TableName );
		new public static readonly string PrimaryKey = XDataTable.ID( TableName );

		public PackGroupTable(): base( null, Names.schedule_prefix, TableName, true, false, true )
		{
		}

		public PackGroupTable( ScheduleDataSet dataSet )
			: base( Names.schedule_prefix, TableName )
		{
			dataSet.Tables.Add( this );
		}

		public void DefaultFill()
		{
			DataRow nogroup_row = NewRow();
			if( Columns[PrimaryKey].DataType == typeof( Guid ) )
				nogroup_row[PrimaryKey] = Guid.Empty;	
			nogroup_row[NameColumn] = "No Group";
			Rows.Add( nogroup_row );
			RowDeleting += new DataRowChangeEventHandler( GameGroupTable_RowDeleting );
		}

		void GameGroupTable_RowDeleting( object sender, DataRowChangeEventArgs e )
		{
			if( e.Row[PrimaryKey].Equals( Guid.Empty ) || e.Row[NameColumn].Equals( "No Group" ) )
				throw new Exception( "Cannot delete 'No Group' group." );
		}

		public DataRow NewPackGroup( String name )
		{
			return NewSimpleName( name );
		}

		public DataRow GetPackGroup( String name )
		{
			String name_column = XDataTable.Name( this );
			if( name_column != null )
			{
				String safe_name = DsnConnection.Escape( DsnConnection.ConnectionMode.NativeDataTable, DsnConnection.ConnectionFlavor.Unknown, name );
				if( Columns[name_column].Unique )
				{
					DataRow[] rows = Select( name_column + "='" + safe_name + "'" );
					if( rows.Length > 1 )
						throw new ConstraintException( "unique name column has already been violated, while attempting to add [" + name + "]" );
					if( rows.Length == 1 )
						return rows[0];
				}
			}
			return null;
		}

	}
}
