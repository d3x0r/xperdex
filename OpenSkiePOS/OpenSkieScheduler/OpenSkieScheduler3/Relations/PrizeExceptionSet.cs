using System;
using System.Data;
using xperdex.classes;


namespace OpenSkieScheduler3.Relations
{
	[SchedulePersistantTable( DefaultFill = "DefaultFill" )]
	public class PrizeExceptionSet : MySQLNameTable
	{
		new public static readonly String TableName = "prize_exception_set";
		new public static readonly String PrimaryKey = XDataTable.ID( TableName );
		new public static readonly String NameColumn = XDataTable.Name( TableName );

		public void DefaultFill()
		{
			DataRow default_row = NewRow();
			default_row[NameColumn] = "Default";
			Rows.Add( default_row );
		}

		void AddColumns( DataSet dataSet )
		{
		}

		public PrizeExceptionSet()
		{
			// hooray for GetChanges(); suck.
		}

		public PrizeExceptionSet( DataSet dataset )
			: base( Names.schedule_prefix, TableName )
		{
			AddColumns( dataset );
            if( !dataset.Tables.Contains( ( this as DataTable ).TableName ) )
                dataset.Tables.Add( this );
		}

		public DataRow NewPrizeException( String name )
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
				DataRow newnamerow = NewRow();
				newnamerow[name_column] = safe_name;
				//newnamerow[SessionTable.PrimaryKey] = session[SessionTable.PrimaryKey];
				Rows.Add( newnamerow );
				return newnamerow;
			}
			return null;
		}

	}

	[SchedulePersistantTable( DefaultFill = "DefaultFill" )]
	public class SessionPrizeExceptionSet : MySQLRelationTable2<SessionPrizeExceptionSet.SessionPrizeExceptionSetDataRow, SessionTable, PrizeExceptionSet>
	{
		public class SessionPrizeExceptionSetDataRow : DataRow
		{
			public SessionPrizeExceptionSetDataRow( global::System.Data.DataRowBuilder rb ) :
				base( rb )
			{
			}

			public override string ToString()
			{
				if( this.RowState == DataRowState.Deleted || this.RowState == DataRowState.Detached )
					return "<deleted>";
				IMySQLRelationTableBase itable = ( this.Table as IMySQLRelationTableBase );
				DataRow parent = this.GetParentRow( itable.ParentOfChild );
				if( parent == null )
					return "-deleted-";
				return this.GetParentRow( itable.ParentOfChild )[PrizeExceptionSet.NameColumn].ToString();
			}
			public String DisplayMember
			{
				get
				{
					return this.ToString();
				}
			}
		}

		new public static readonly String TableName = MySQLRelationTable2<DataRow,SessionTable, PrizeExceptionSet>.RelationName;
		new public static readonly String PrimaryKey = XDataTable.ID( TableName );
		new public static readonly String NumberColumn = XDataTable.Number( PrizeExceptionSet.TableName );
		DataRow default_prize_exception;

		public void DefaultFill()
		{
			if( this.Rows.Count == 0 )
			{
				ScheduleDataSet schedule = DataSet as ScheduleDataSet;
				DataRow[] default_exception = schedule.prize_exception_sets.Select( PrizeExceptionSet.NameColumn + "='Default'" );
				foreach( DataRow row in schedule.sessions.Rows )
				{
					AddGroupMember( row, default_exception[0] );
				}
			}
		}

		void AddColumns()
		{
		}

		void PrizeExceptionSet_RowChanged( object sender, DataRowChangeEventArgs e )
		{

		}

		public SessionPrizeExceptionSet()
		{
			// hooray for GetChanges(); suck.
		}

		public SessionPrizeExceptionSet( DataSet dataset )
			: base( dataset )
		{
			AddColumns();
			dataset.Tables[SessionTable.TableName].RowChanged += new DataRowChangeEventHandler( SessionPrizeExceptionSet_RowChanged );
		}

		void SessionPrizeExceptionSet_RowChanged( object sender, DataRowChangeEventArgs e )
		{
			if( e.Action == DataRowAction.Add )
			{
				if( filling )
					return;
				if( ( DataSet.Tables[SessionTable.TableName] as IXDataTable ).filling )
					return;
				ScheduleDataSet schedule = this.DataSet as ScheduleDataSet;
				// received when session table gets a new row 
				// so every session gets a 'default' prize exception set.

				if( schedule != null )
				{
					if( default_prize_exception == null )
					{
						schedule.prize_exception_sets.DefaultFill();
						DataRow[] default_exception = schedule.prize_exception_sets.Select( PrizeExceptionSet.NameColumn + "='Default'" );
						if( default_exception.Length > 0 )
							default_prize_exception = default_exception[0];
					}
					schedule.session_prize_exception_sets.AddGroupMember( e.Row, default_prize_exception );
				}
			}
		}

		public DataRow NewPrizeException( DataRow session, String name )
		{
			String name_column = XDataTable.Name( this );
			if( name_column != null )
			{
				String safe_name = DsnConnection.Escape( DsnConnection.ConnectionMode.NativeDataTable, DsnConnection.ConnectionFlavor.Unknown, name );
				if( Columns[name_column].Unique )
				{
					DataRow[] rows = Select( SessionTable.PrimaryKey + "='" + session[SessionTable.PrimaryKey] + "' and " + name_column + "='" + safe_name + "'" );
					if( rows.Length > 1 )
						throw new ConstraintException( "unique name column has already been violated, while attempting to add [" + name + "]" );
					if( rows.Length == 1 )
						return rows[0];
				}
				DataRow newnamerow = NewRow();
				newnamerow[name_column] = safe_name;
				newnamerow[SessionTable.PrimaryKey] = session[SessionTable.PrimaryKey];
				Rows.Add( newnamerow );
				return newnamerow;
			}
			return null;
		}

	}
}
