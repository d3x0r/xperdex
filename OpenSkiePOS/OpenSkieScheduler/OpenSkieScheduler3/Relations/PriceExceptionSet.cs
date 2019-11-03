using System;
using System.Data;
using xperdex.classes;


namespace OpenSkieScheduler3.Relations
{
	[SchedulePersistantTable( DefaultFill="DefaultFill" )]
	public class PriceExceptionSet : MySQLNameTable
	{
		new public static readonly String TableName = "price_exception_set";
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

		public PriceExceptionSet()
		{
			// hooray for GetChanges(); suck.
		}

		public PriceExceptionSet( DataSet dataset )
			: base( Names.schedule_prefix, TableName )
		{
			AddColumns( dataset );
            if( !dataset.Tables.Contains( (this as DataTable).TableName ) )
    			dataset.Tables.Add( this );
		}

		public DataRow NewPriceException( String name )
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

	[SchedulePersistantTable( DefaultFill="DefaultFill" )]
	public class SessionPriceExceptionSet : MySQLRelationTable2<SessionPriceExceptionSet.SessionPriceExceptionSetDataRow, SessionTable, PriceExceptionSet>
	{
		public class SessionPriceExceptionSetDataRow : DataRow
		{
			public SessionPriceExceptionSetDataRow( global::System.Data.DataRowBuilder rb ) : 
                    base(rb) 
			{
            }

			public override string ToString()
			{
				return this.GetParentRow( ( this.Table as IMySQLRelationTableBase ).ParentOfChild )[PriceExceptionSet.NameColumn].ToString();
			}
			public String DisplayMember
			{
				get
				{
					return this.ToString();
				}
			}
		}
		new public static readonly String TableName = MySQLRelationTable2<DataRow,SessionTable, PriceExceptionSet>.RelationName;
		new public static readonly String PrimaryKey = XDataTable.ID( TableName );
		new public static readonly String NumberColumn = XDataTable.Number( PriceExceptionSet.TableName );

		public void DefaultFill( )
		{
			if( this.Rows.Count == 0 )
			{
				ScheduleDataSet schedule = DataSet as ScheduleDataSet;
				DataRow[] default_exception = schedule.price_exception_sets.Select( PriceExceptionSet.NameColumn + "='Default'" );
				foreach( DataRow row in schedule.sessions.Rows )
				{
					AddGroupMember( row, default_exception[0] );
				}
			}
		}

		void AddColumns(  )
		{
		}

		void PriceExceptionSet_RowChanged( object sender, DataRowChangeEventArgs e )
		{

		}

		public SessionPriceExceptionSet()
		{
			// hooray for GetChanges(); suck.
		}

		public SessionPriceExceptionSet(DataSet dataset )
			: base( dataset )
		{
			AddColumns( );
			//dataset.Tables[SessionTable.TableName].TableNewRow += new DataTableNewRowEventHandler( SessionPriceExceptionSet_TableNewRow );
			dataset.Tables[SessionTable.TableName].RowChanged += new DataRowChangeEventHandler( SessionPriceExceptionSet_RowChanged );
		}

		void SessionPriceExceptionSet_RowChanged( object sender, DataRowChangeEventArgs e )
		{

			if( e.Action == DataRowAction.Add )
			{
				if( filling )
					return;
				if( ( DataSet.Tables[SessionTable.TableName] as IXDataTable ).filling )
					return;

				ScheduleDataSet schedule = this.DataSet as ScheduleDataSet;
				// received when session table gets a new row 
				// so every session gets a 'default' price exception set.

				if( schedule != null )
				{
					if( default_price_exception == null )
					{
						schedule.price_exception_sets.DefaultFill();
						DataRow[] default_exception = schedule.price_exception_sets.Select( PriceExceptionSet.NameColumn + "='Default'" );
						if( default_exception.Length > 0 )
							default_price_exception = default_exception[0];
					}
					schedule.session_price_exception_sets.AddGroupMember( e.Row, default_price_exception );
				}
			}
		}

		// keep this cached.
		DataRow default_price_exception;

		void SessionPriceExceptionSet_TableNewRow( object sender, DataTableNewRowEventArgs e )
		{
			if( filling )
				return;
			if( ( DataSet.Tables[SessionTable.TableName] as IXDataTable ).filling )
				return;

			ScheduleDataSet schedule = this.DataSet as ScheduleDataSet;
			// received when session table gets a new row 
			// so every session gets a 'default' price exception set.

			if( schedule != null )
			{
				if( default_price_exception == null )
				{
					schedule.price_exception_sets.DefaultFill();
					DataRow[] default_exception = schedule.price_exception_sets.Select( PriceExceptionSet.NameColumn + "='Default'" );
					if( default_exception.Length > 0 )
						default_price_exception = default_exception[0];
				}
				schedule.session_price_exception_sets.AddGroupMember( e.Row, default_price_exception );
			}
		}

		public DataRow NewPriceException( DataRow session, String name )
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
