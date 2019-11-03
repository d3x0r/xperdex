using System;
using System.Data;
using OpenSkieScheduler3.Relations;
using xperdex.classes;

namespace OpenSkieScheduler3
{
	[SchedulePersistantTable( DefaultFill="DefaultFill" )]
	public class GameTable : MySQLDataTable
    {
		new public static readonly string TableName = "game_info";
		// if only I could move these into the sub class...
		public static readonly String NameColumn = XDataTable.Name( TableName );
		new public static readonly string PrimaryKey = XDataTable.ID( TableName );
		public GameTable()
		{
			base.TableName = "(tmp)"+TableName;
		}
		public GameTable( DataSet dataSet )
            : base()
        {
			Prefix =  Names.schedule_prefix;
			base.TableName = TableName;
			AddDefaultColumns( true, true, true );
	
            //Columns.Add("game_type_id", typeof(int)); // double/special/bonanza
			//DataColumn dc = Columns.Add( ColorInfoTable.PrimaryKey, XDataTable.DefaultAutoKeyType );
			//if( XDataTable.DefaultAutoKeyType == typeof( Guid ) )
			//	dc.DefaultValue = Guid.Empty;
			//else
			//dc.DefaultValue = DBNull.Value;
			//Columns.Add( "special", typeof( bool ) );
			//Columns.Add( "poker", typeof( bool ) );


			dataSet.Tables.Add( this );

/*
			DataTable child;
			String relation_name;
			dataSet.Relations.Add( relation_name = MySQLDataTable.StripPlural( MySQLDataTable.StripInfo( GameTable.TableName ) )
				+ "_is_"
				+ MySQLDataTable.StripPlural( MySQLDataTable.StripInfo( ColorInfoTable.TableName ) )
				, dataSet.Tables[ColorInfoTable.TableName].Columns[ColorInfoTable.PrimaryKey]
				, ( child = dataSet.Tables[GameTable.TableName] ).Columns[ColorInfoTable.PrimaryKey]
				);
			ForeignKeyConstraint fkc;
			fkc = child.Constraints[relation_name] as ForeignKeyConstraint;
			if( fkc != null )
				fkc.DeleteRule = Rule.SetNull;
*/
		}

		public void DefaultFill()
		{
		}

		public DataRow hide_NewGame( String name )
		{
			return NewSimpleName( name );
		}

		public DataRow hide_GetGame( String name )
		{
			DataRow[] prior = Select( NameColumn + "='" + DsnConnection.Escape( DsnConnection.ConnectionMode.NativeDataTable, DsnConnection.ConnectionFlavor.Unknown, name ) + "'" );
			if( prior.Length > 0 )
				return prior[0];
			return hide_NewGame( name );
		}
	}
}
