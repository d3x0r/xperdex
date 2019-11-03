using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Odbc;

namespace xperdex.classes
{
	/// <summary>
	/// A simple table that provides a dictionary; Create an ID or a name.  
	/// Auto fields are [table_name]_id and [table_name]_name
	/// </summary>
	public class MySQLNameTable<T> : MySQLDataTable<T>
		where T:DataRow
	{

		protected MySQLNameTable()
		{
			return;
		}
		public MySQLNameTable( string prefix, string name )
			: base( null, prefix, name, true, true )
		{
			DataColumn dc = this.Columns.Add( NameColumn, typeof( string ) );
			dc.Unique = true;
		}

		public MySQLNameTable( bool auto_fill, string prefix, string name )
			: base( null, prefix, name, true, true )
		{
			DataColumn dc = this.Columns.Add( NameColumn, typeof( string ) );
			dc.Unique = true;
			if( auto_fill )
			{
				DsnSQLUtil.CreateDataTable( connection, this );
				Fill();
			}
		}

		public MySQLNameTable( string prefix, string name, bool trim_info, bool simple_name )
			: base( null, prefix, name, true, true )
		{
			DataColumn dc = this.Columns.Add( simple_name ? "name" : XDataTable.Name( this ), typeof( string ) );
			dc.Unique = true;

			DsnSQLUtil.CreateDataTable( connection, this );
			Fill();
		}

		public MySQLNameTable( string prefix, string name, bool trim_info )
			: base( null, prefix, name, true, true )
		{
			DataColumn dc = this.Columns.Add( XDataTable.Name( this ), typeof( string ) );
			dc.Unique = true;

			DsnSQLUtil.CreateDataTable( connection, this );
			Fill();
		}

		public MySQLNameTable( DsnConnection dsn, string prefix, string name, bool trim_info, bool auto_fill, bool simple_name )
			: base( dsn, prefix, name, true, trim_info, false )
		{
			// otherwise non-simple will be added by base initilalizer.
			if( simple_name )
			{
				DataColumn dc = this.Columns.Add( simple_name ? "name" : XDataTable.Name( this ), typeof( string ) );
				dc.Unique = true;
			}
			if( auto_fill )
			{
				DsnSQLUtil.CreateDataTable( connection, this );
				Fill();
			}

		}
		public MySQLNameTable( DsnConnection dsn, string prefix, string name, bool trim_info, bool auto_fill )
			: base( dsn, prefix, name, true, trim_info, auto_fill, true )
		{
		}

		public MySQLNameTable( string prefix, string name, DsnConnection dsn )
			: base( dsn, prefix, name )
		{
			DataColumn dc = this.Columns.Add( XDataTable.Name( this ), typeof( string ) );
			dc.Unique = true;

			DsnSQLUtil.CreateDataTable( connection, this );
			Fill();
		}

		public object this[string name]
		{
			get
			{
				DataRow[] row = this.Select( NameColumn + "='" + name + "'" );
				if( row.Length > 0 )
				{
					return row[0][XDataTable.ID( this )];
				}
				DataRow dr;
				dr = NewRow();
				dr[NameColumn] = name;
				Rows.Add( dr );
				CommitChanges();
				return dr[XDataTable.ID( this )];
			}

		}
		public DataRow this[Guid name_id]
		{
			get
			{
				DataRow[] row = this.Select( XDataTable.ID( this ) + "='" + name_id + "'" );
				if( row.Length > 0 )
					return row[0];
				return null;
			}
		}
	}

	public class MySQLNameTable : MySQLNameTable<DataRow>
	{
		protected MySQLNameTable()
			: base()
		{
		}
		public MySQLNameTable( string prefix, string name )
			: base( prefix, name )
		{
		}

		public MySQLNameTable( bool auto_fill, string prefix, string name )
			: base( auto_fill, prefix, name )
		{
		}

		public MySQLNameTable( string prefix, string name, bool trim_info, bool simple_name )
			: base( prefix, name, trim_info, simple_name )
		{
		}

		public MySQLNameTable( string prefix, string name, bool trim_info )
			: base( prefix, name, trim_info )
		{
		}

		public MySQLNameTable( DsnConnection dsn, string prefix, string name, bool trim_info, bool auto_fill, bool simple_name )
			: base( dsn, prefix, name, trim_info, auto_fill, simple_name )
		{
		}
		public MySQLNameTable( DsnConnection dsn, string prefix, string name, bool trim_info, bool auto_fill )
			: base( dsn, prefix, name, trim_info, auto_fill )
		{
		}

		public MySQLNameTable( string prefix, string name, DsnConnection dsn )
			: base( prefix, name, dsn )
		{
		}
	}

}
