using System;
using System.Collections.Generic;
using System.Text;

using xperdex.classes;
using System.Data;

namespace xperdex.dataset.users
{
	public class User  : MySQLDataTable
	{
		public static readonly String TableName = "user_info";

		public User( DsnConnection odbc, DataSet ds )
			: base()
		{
			this.Prefix = "permission_";
			base.TableName = TableName;
			this.AddDefaultColumns( true, true, false );
			Columns.Add( "first_name", typeof( string ) );
			Columns.Add( "last_name", typeof( string ) );
			Columns.Add( "name", typeof( string ) );
			Columns.Add( "staff_id", typeof( string ) );
			Columns.Add( "PID", typeof( string ) );
			Columns.Add( "password", typeof( string ) );
			Columns.Add( "card", typeof( string ) );
			Columns.Add( "keycode", typeof( string ) );

			Columns.Add( "password_creation_datestamp", typeof( DateTime ) ).Namespace = "date";
			Columns.Add( "terminate", typeof( bool ) );
			Columns.Add( "locale_id", typeof( int ) );
			Columns.Add( "lot_container", typeof( int ) );
			Columns.Add( "room_id", typeof( int ) );
			Create();
			Fill();
			ds.Tables.Add( this );
		}
	}
}
