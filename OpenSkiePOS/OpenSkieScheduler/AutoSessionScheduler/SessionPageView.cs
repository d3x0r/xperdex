using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace AutoSessionScheduler
{
	public class SessionPageView: DataTable
	{
		public SessionPageView()
		{
			TableName = "Session page boolean";
			DataColumn dc;
			Columns.Add( "Session", typeof( string ) );
			Columns.Add( "Page", typeof( string ) );
			dc = Columns.Add( "Page Number", typeof( string ) );
			dc = Columns.Add( "Session Number", typeof( string ) );
			dc = Columns.Add( "In Session", typeof( bool ) );
			Columns.Add( "page_row", typeof( DataRow ) );

			this.ColumnChanging += new DataColumnChangeEventHandler( SessionPageView_ColumnChanged );
			this.RowChanged += new DataRowChangeEventHandler( SessionPageView_RowChanged );
			
			//Columns.Add( "info", typeof( DataRow ) );
		}

		bool filling;
		void SessionPageView_ColumnChanged( object sender, DataColumnChangeEventArgs e )
		{
			if( filling )
				return;
			if( e.Row.RowState == DataRowState.Detached )
				return; // ignore this.
			if( e.Row[4] == DBNull.Value )
			{

				if( ( e.Row[2] != DBNull.Value ) || ( e.Row[1] != DBNull.Value ) )
				{
					Local.session_info.pages.IgnoreChange = true;
					e.Row[4] = Local.session_info.pages.AddPage( ( e.Row[1] == DBNull.Value ? (string)e.Row[1] : "Page Name" )
						, ( e.Row[2] != DBNull.Value ? (int)e.Row[2] : 0 ) );
				}
				return;
			}
			else
			{
				if( e.Column.Ordinal == 0 )
					e.ProposedValue = e.Row[0];
				if( e.Column.Ordinal == 1 || e.Column.Ordinal == 3 )
				{
					( (DataRow)e.Row[5] )[e.Column.Ordinal] = e.ProposedValue;
				}
				if( e.Column.Ordinal == 2 )
				{
					Local.session_info.pages.IgnoreChange = true;
					( (DataRow)e.Row[5] )[2] = e.ProposedValue;
				}
				else if( e.Column.Ordinal == 4 )
				{
					Console.WriteLine( "change thing..." );
					bool value = (bool)e.ProposedValue;
					//e.Row[3] = value;
					if( value )
						Local.session_info.AddPage( (DataRow)e.Row[5] );
					else
						Local.session_info.RemovePage( (DataRow)e.Row[5] );
				}
			}
			//throw new Exception( "The method or operation is not implemented." );
		}

		void SessionPageView_RowChanged( object sender, DataRowChangeEventArgs e )
		{
			//throw new Exception( "The method or operation is not implemented." );
		}	

		public void UpdateTable( SessionSalesPages pages, SessionSalesInfo sessions, DataRow current )
		{
			this.Clear();
			filling = true;
			if( current != null )
			{
				DataRow[] pagerows = pages.Select( null, "Page" );
				foreach( DataRow page in pagerows )
				{
					bool found = false;
					DataRow[] rows = page.GetChildRows( pages.ChildRelations[0] );
					DataRow myrow = NewRow();
					myrow[0] = current[1];
					myrow[1] = page[1];
					myrow[2] = page[2];
					myrow[3] = page[3];
					foreach( DataRow row in rows )
					{
						DataRow session = row.GetParentRow( sessions.ChildRelations[0] );
						// compare session ID with stuff.
						if( Convert.ToInt32(session[0]) == Convert.ToInt32(current[0]) )
						{
							found = true;
							break;
						}
					}
					myrow[4] = found;
					myrow[5] = page;
					Rows.Add( myrow );
				}
			}
			filling = false;
			AcceptChanges();
		}		
	}
}
