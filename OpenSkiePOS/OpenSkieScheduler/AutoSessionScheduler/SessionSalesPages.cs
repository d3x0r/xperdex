using System;
using System.Collections.Generic;
using System.Text;
using xperdex.classes;
using System.Data;

namespace AutoSessionScheduler
{
	public class SessionSalesPages: MySQLDataTable
	{
		SessionSalesInfo _info;
		bool _IgnoreChange;
		public bool IgnoreChange { get { return _IgnoreChange; } set { _IgnoreChange = value; } }
		public SessionSalesPages(SessionSalesInfo info)
			: base( "session_sales_pages", false )
		{
			_info = info;
			Columns.Add( "page", typeof( int ) );
			Columns.Add( "session_number", typeof( int ) );
			Columns.Add( "page_name", typeof( String ) );
			Create();
			Fill();
			this.RowChanged += new DataRowChangeEventHandler( SessionSalesPages_RowChanged );
		}
		~SessionSalesPages()
		{
			_info = null;
		}

		void SessionSalesPages_RowChanged( object sender, DataRowChangeEventArgs e )
		{
			if( _IgnoreChange )
			{
				_IgnoreChange = false;
				return;
			}
			_info.UpdatePages();
			//throw new Exception( "The method or operation is not implemented." );
		}

		public DataRow AddPage( string name, int number )
		{
			DataRow dr = NewRow();
			dr[1] = name;
			dr[2] = number;
			Rows.Add( dr );
			return dr;
			//AcceptChanges();

		}
	}
}
