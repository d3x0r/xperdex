using System;
using System.Data;
using xperdex.classes;

namespace OpenSkieScheduler3
{
	/// <summary>
	/// Prize levels are defined here - for the longest time they were just names.
	/// Prize Levels also define a couple options that can be used to determine how the prize is won
	/// </summary>
	[SchedulePersistantTable( DefaultFill="DefaultFill" )]
	public class PrizeLevelNames : MySQLNameTable
	{
		new public static readonly String TableName = "prize_level";
		new public static readonly String PrimaryKey = XDataTable.ID( TableName );
		public static readonly String NameColumn = XDataTable.Name( TableName );

		void AddColumns()
		{
			DataColumn dc;
			dc = Columns.Add( "lastball_wins", typeof( bool ) );
			dc.AllowDBNull = false;
			dc.DefaultValue = false;
			dc = Columns.Add( "ballcount_wins", typeof( bool ) );
			dc.AllowDBNull = false;
			dc.DefaultValue = false;
			//value added is an indicator that when the pack is bought
			// in order to play for this prize level, an additional cost may be defined.
			// this may determine the whole pack cost
			dc = Columns.Add( "value_added", typeof( bool ) );
			dc.AllowDBNull = false;
			dc.DefaultValue = false;
		}

		public PrizeLevelNames()
		{
			base.TableName = "(tmp)"+TableName;
			AddDefaultColumns( true, true, true );
			AddColumns();
		}

		public PrizeLevelNames( DataSet dataSet )
			: base( Names.schedule_prefix, TableName, true, false )
		{
			Columns.Add( "str_color", typeof( String ) );
			AddColumns();
			if( dataSet != null )
				dataSet.Tables.Add( this );
		}


		public DataRow NewPrize( String name )
		{
			return NewSimpleName( name );
		}

		public void DefaultFill()
		{
			if( Rows.Count == 0 )
			{
				DataRow nogroup_row = NewRow();
				if( Columns[PrimaryKey].DataType == typeof( Guid ) )
					nogroup_row[PrimaryKey] = Guid.Empty;
				nogroup_row[NameColumn] = "No Prize";
				Rows.Add( nogroup_row );
				RowDeleting += new DataRowChangeEventHandler( PrizeLevelNames_RowDeleting );
			}
		}

		void PrizeLevelNames_RowDeleting( object sender, DataRowChangeEventArgs e )
		{
			if( e.Row[PrimaryKey].Equals( Guid.Empty ) || e.Row[NameColumn].Equals( "No Prize" ) )
				throw new Exception( "Cannot delete No Prize." );
		}
	}
}
