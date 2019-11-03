using System;
using System.Collections.Generic;
using System.Text;
using xperdex.classes;
using System.Data;

namespace AutoSessionScheduler
{
	public class SessionSalesInfo: MySQLDataTable
	{
		SessionSalesPages _pages;
		MySQLRelationTable2<SessionSalesInfo, SessionSalesPages> _pages_in_session;
		SessionPageView _page_view;
		DataSet infoset;
		SessionImageTable _images;
		MySQLRelationTable _images_in_session;
		bool initializing;

		public SessionImageTable images { get {return _images; } }

		public class SessionImageTable : MySQLDataTable
		{
			public SessionImageTable( SessionSalesInfo parent )
				: base( "session_sales_images", false )
			{
				Columns.Add( "FileName", typeof( string ) );
				Columns.Add( "FileData", typeof( byte[] ) );
				Columns.Add( parent.Columns[0].ColumnName, typeof( int ) );
				Create(null,"UNIQUE KEY image_label('" + Columns[1].ColumnName + "')");
				Fill();
			}

		}

		public SessionSalesInfo(  )
			: base( "session_sales_info", false, true )
		{
			initializing = true;
			AddDefaultColumns( true, false, true );
			infoset = new DataSet();
			_pages = new SessionSalesPages(this);
			infoset.Tables.Add( this );
			infoset.Tables.Add( _pages );
			_page_view = new SessionPageView();
			Create();
			Fill();
			// have to fill this before creating the relation...
			_pages_in_session = new MySQLRelationTable2<SessionSalesInfo,SessionSalesPages>( this, _pages );
			this.RowChanged += new DataRowChangeEventHandler( SessionSalesInfo_RowChanged );

			_images = new SessionImageTable( this );
			//_images_in_session = new MySQLRelationTable( this, _images );

			initializing = false;
		}

		void SessionSalesInfo_RowChanged( object sender, DataRowChangeEventArgs e )
		{
			Update();
			//throw new Exception( "The method or operation is not implemented." );
		}
		void LoadSessions()
		{
			this.Clear();
			pages.Clear();
		
		}

		public void AddSession( string s )
		{
			DataRow dr = NewRow();
			dr[1] = s;
			Rows.Add( dr ); // generates an update to table changes...
			//AcceptChanges();
		}

		public void UpdatePages()
		{
			_page_view.UpdateTable( _pages, this, Local.current_session );
		}

		public void AddPage( DataRow page )
		{
			DataRow newrow = _pages_in_session.NewRow();
			newrow[1] = Local.add_to_session[0];
			newrow[2] = page[0];
			newrow[3] = page[2];
			_pages_in_session.Rows.Add( newrow );
		}

		public void RemovePage( DataRow page )
		{
			DataRow[] rows = _pages_in_session.Select( "session_sales_pages_id=" + page[0].ToString() + " and session_sales_info_id="+Local.current_session[0] );
			foreach( DataRow row in rows )
			{
				_pages_in_session.Delete( row );
			}
		}

		public SessionSalesPages pages { get { return _pages; } }
		public SessionPageView page_view { get { return _page_view; } }
		public DataTable pages_in_session { get { return _pages_in_session; } }
	}
}
