using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Text;
using xperdex.classes.Types;

namespace xperdex.classes
{
	public class DsnSQLUtil
	{

		/// <summary>
		/// Invokes a CREATE TABLE on the odbc connection for this table's current schema.
		/// </summary>
		/// <param name="odbc">Database Connection</param>
		/// <param name="extra">Extra columns added 
		/// (these are often additional keys in the MySQL dialect)</param>
		/// <param name="delete">Drop table if it exists and recreate it.</param>
		/// <param name="delete_cols">Drop extra columns that are not part of this</param>
		public static void CreateDataTable( DsnConnection odbc, DataTable dataTable, string extra, bool delete, bool delete_cols )
		{
			IXDataTable xtable = dataTable as IXDataTable;
			
			//exists = true;

			if( odbc != null && odbc.State != ConnectionState.Closed )
			{
				StringBuilder keys = new StringBuilder();
				StringBuilder sb = new StringBuilder();
				//string columns = null;

				if( delete )
				{
					try
					{
						odbc.ExecuteNonQuery( "Drop table if exists "
						+ odbc.sql_quote_open
						+ MySQLDataTable.GetCompleteTableName( dataTable )
						+ odbc.sql_quote_close );
					}
					catch( Exception e )
					{
						Console.WriteLine( e );
					}
				}
				MatchCreate( odbc, dataTable, null, delete_cols );
				if ( xtable != null )
				{
					if ( xtable.auto_id == null )
					{
						foreach ( DataColumn isauto in dataTable.Columns )
							if ( isauto.AutoIncrement )
								xtable.auto_id = isauto;
					}

					if ( xtable.auto_id != null && xtable.auto_id.DataType == typeof( int ) )
					{
						try
						{
							object seed = odbc.ExecuteScalar( "select max(" + xtable.auto_id.ColumnName + ") from " + odbc.sql_quote_open + xtable.FullTableName + odbc.sql_quote_close );
							if( seed.GetType() == typeof( byte[] ) )
							{
								throw new Exception( "Sorry, you have an auto increment int column and it is being filled with GUID" );
							}
							else
								if ( seed != DBNull.Value )
									xtable.auto_id.AutoIncrementSeed = Convert.ToInt64( seed ) + 1;
						}
						catch
						{
						}
					}
				}
			}
		}
		/// <summary>
		/// Alias for ( odbc, extra, delete (recreate), don't delete extra columns )
		/// </summary>
		/// <param name="odbc"></param>
		/// <param name="extra"></param>
		/// <param name="delete"></param>
		static public void CreateDataTable( DsnConnection odbc, DataTable dataTable, string extra, bool delete )
		{
			CreateDataTable( odbc, dataTable, extra, delete, false );

		}
		/// <summary>
		/// Alias for CreateDataTable( odbc, nothing extra, don't delete)
		///   which is alias ( odbc, extra, delete (recreate), don't delete extra columns )
		/// </summary>
		/// <param name="odbc"></param>
		static public void CreateDataTable( DsnConnection odbc, DataTable dataTable )
		{
			CreateDataTable( odbc, dataTable, null, false );
		}
		/// <summary>
		/// Alias for CreateDataTable( odbc, nothing extra, don't delete)
		///   which is alias ( odbc, extra, delete (recreate), don't delete extra columns )
		/// </summary>
		/// <param name="odbc"></param>
		static public void CreateDataTable( DsnConnection odbc, DataSet dataSet )
		{
            if( dataSet != null )
    			foreach( DataTable dataTable in dataSet.Tables )
	    			CreateDataTable( odbc, dataTable, null, false );
		}
		/// <summary>
		/// Creates a DataTable in the database specified.
		/// </summary>
		/// <param name="odbc"></param>
		/// <param name="dataTable"></param>
		/// <param name="delete"></param>
		static public void CreateDataTable( DsnConnection odbc, DataTable dataTable, bool delete )
		{
			CreateDataTable( odbc, dataTable, null, delete );
		}


		/*
			''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		   ' show create table -command for microsoft sql server
		   '
		   ' purpose:
		   '    returns sql to create table
		   '
		   ' usage:
		   '    response.write showcreatetable("mytable",1+2)
		   '
		   ' parametres:
		   '    name = table name
		   '    mode = function return value mode (see below)
		   '       if mode bit 1 is on: sql to create table will be returned
		   '       if mode bit 2 is on: table related sql will be returned (foreign keys etc)
		   '
		   ' Written by Ville Jungman / Varuste.net, http://www.varuste.net
		   ' Gnu public licence. Free to use, modify & copy.
		*/

		static DataTable DataTableFromSchema( DsnConnection connection, DataTable dataTable )
		{
			IXDataTable xtable = dataTable as IXDataTable;
			XDataTable<DataRow> table = new XDataTable<DataRow>();

			//dim query,query2,query3,query4,kentat,sql,unique,sql1,sql2,primarykey
			String FullTableName;
			if ( xtable != null )
				FullTableName = xtable.FullTableName;
			else
				FullTableName = MySQLDataTable.GetCompleteTableName( dataTable );
			DbDataReader r, r2;


			//'''''''''''''''''''''''''''''''''
			//' get sysobjects-id for the table
			if( xtable == null )
				r = connection.ExecuteReader( "select id from sysobjects where xtype='u' and name='" + MySQLDataTable.GetCompleteTableName( dataTable ) + "'" );
			else																				   
			r = connection.ExecuteReader( "select id from sysobjects where xtype='u' and name='" + xtable.FullTableName + "'" );
			if( r.HasRows )
				r.Read();
			else
			{
				//table.Dispose();
				r.Dispose();
				return null;
			}


			//'''''''''''''''''''''''''
			//' loop through all fields

			string ID = r["id"].ToString();
			r.Dispose();
			r2 = connection.ExecuteReader( "select sc.name,st.name as xtype,st.length,st.variable,sc.isnullable from syscolumns as sc,systypes as st where sc.xtype=st.xtype and sc.id="
				+ ID + " order by sc.name" );
			if( r2.HasRows )
				while( r2.Read() )
				{
					DataColumn dc = null;
					String type = r2["xtype"].ToString();
					switch( type )
					{
					case "int":
						dc = table.Columns.Add( r2["name"].ToString(), typeof( int ) );

						break;
					case "varchar":
						dc = table.Columns.Add( r2["name"].ToString(), typeof( String ) );
						dc.MaxLength = Convert.ToInt32( r2["length"] );
						break;
					case "varbinary":
						dc = table.Columns.Add( r2["name"].ToString(), typeof( byte[] ) );
						break;
					case "bigint":
						dc = table.Columns.Add( r2["name"].ToString(), typeof( Int64 ) );
						break;
					case "datetime":
						dc = table.Columns.Add( r2["name"].ToString(), typeof( DateTime ) );
						break;
					case "bit":
						dc = table.Columns.Add( r2["name"].ToString(), typeof( bool ) );

						break;
					case "decimal":
						dc = table.Columns.Add( r2["name"].ToString(), typeof( Decimal ) );
						break;
					case "uniqueidentifier":
					case "UNIQUEIDENTIFIER":
						dc = table.Columns.Add( r2["name"].ToString(), typeof( Guid ) );
						break;
					default:
						Log.log( "Unhandled type: " + type );
						break;
					}
					if( Convert.ToBoolean( r2["isnullable"] ) )
						dc.AllowDBNull = true;
					else
						dc.AllowDBNull = false;
				}
			r2.Dispose();

			//''''''''''''''''''''''''
			//' get primary key -field

			r = connection.ExecuteReader( "select c.name from sysindexes i join sysobjects o ON i.id = o.id join sysobjects pk ON i.name = pk.name AND pk.parent_obj = i.id AND pk.xtype = 'PK' join sysindexkeys ik on i.id = ik.id and i.indid = ik.indid join syscolumns c ON ik.id = c.id AND ik.colid = c.colid where o.name = '" 
				+ FullTableName 
				+ "' order by ik.keyno" );
			if( r.HasRows )
			{
				while( r.Read() )
				{
					DataColumn dc = table.Columns[r["name"].ToString()];

					table.PrimaryKey = new DataColumn[] { dc };
					//ring primarykey = 
					//sql2 = sql2 & "alter table " & name & " add primary key(" & primarykey & ");"
					//table.PrimaryKey = null;
				}
			}
			r.Dispose();


#if asdfasdf
      ''''''
      ' keys

      query2.open "select constid,rkeyid,fkeyid,fkey,rkey from sysforeignkeys where fkeyid=" + query("id"),pageConnection,0,1
      while not query2.EOF


         ''''''''''''''
         ' get key name

         dim constraint,fkey,rkey,table,rtable
         query3.open "select name from sysobjects where id=" & query2("constid"),pageConnection,0,1
         constraint = query3("name")
         query3.close


         ''''''''''''''''''''''''''''
         ' get table name for the key

         query3.open "select name from sysobjects where id=" & query2("rkeyid"),pageConnection,0,1
         rtable = query3("name")
         query3.close


         ''''''''''''''''''''''''''''''''
         ' get the field name for the key

         query3.open "select name from syscolumns where colid=" & query2("rkey") & " and id=" & query2("rkeyid"),pageConnection,0,1
         rkey = query3("name")
         query3.close


         '''''''''''''''''''''''''''''''''''''''
         ' get the field the key references from

         query3.open "select name from syscolumns where colid=" & query2("fkey") & " and id=" & query2("fkeyid"),pageConnection,0,1
         fkey = query3("name")
         query3.close


         '''''''''''''''''''''''
         ' show alter table -sql

         sql2 = sql2 & "alter table " & name & " add constraint " & fkey & "_fk foreign key(" & fkey & ") references " & rtable & " (" & rkey & ");"
         flushaa
         query2.movenext
      wend
      query2.close


      ''''''''''''''''''''''
      ' loop for unique keys

      query2.open "select id,name from sysobjects where xtype='UQ' and parent_obj=" + query("id"),pageConnection,0,1
      while not query2.EOF


         ''''''''''''''''''''''''''''''''''''
         ' loop for fields for the unique key

         sql = _
            " select c.name" & _
            " from sysindexes i,sysobjects pk,sysindexkeys ik,syscolumns c" & _
            " where" & _
            "    i.name = pk.name and" & _
            "    pk.parent_obj = i.id and" & _
            "    pk.xtype = 'UQ' and pk.id=" & query2("id") & " and" & _
            "    i.id = ik.id and " & _
            "    i.indid = ik.indid and" & _
            "    ik.id = c.id and" & _
            "    ik.colid = c.colid"
         unique = ""
         query3.open sql,pageConnection,0,1
         while not query3.EOF
            if exists(unique) then
               unique = unique & ","
            end if
            unique = unique & query3("name")
            query3.movenext
         wend
         query3.close

         sql2 = sql2 & "alter table " & name & " add constraint " & query2("name") & " unique(" & unique & ");"
         query2.movenext
      wend
      query2.close


      ''''''''''''''''''
      ' loop for indices

      query2.open "select name,indid from sysindexes where indid>0 and id=" & query("id"),pageConnection,0,1
      while not query2.EOF


         ''''''''''''''''''''''''''''''''''''''
         ' get table name the key references to

         set query3=server.createObject("ADODB.Recordset")
         query3.open "select name from sysobjects where id=" & query("id"),pageConnection,0,1
         table = query3("name")
         query3.close


         '''''''''''''''''''''''''''''''''''''''''
         ' loop for fields the index references to

         dim cols
         cols = ""
         set query3=server.createObject("ADODB.Recordset")
         query3.open "select colid from sysindexkeys where indid=" & query2("indid") & " and id=" & query("id"),pageConnection,0,1
         while not query3.eof


            ''''''''''''''''''''''''''''''''
            ' get the field name for the key

            query4.open "select name from syscolumns where colid=" & query3("colid") & " and id=" & query("id"),pageConnection,0,1
            if exists(cols) then
               cols = cols & ","
            end if
            cols = cols & query4("name")
            query4.close

            query3.movenext
         wend
         query3.close

         sql2 = sql2 & "create index " & query2("name") & " on " & table & "(" & cols & ");"
         query2.movenext
      wend
      query2.Close
      query.close


      ''''''''''''''''''''''
      ' make createtable-sql

      sql1 = "create table " & name & "(" & kentat & ");"


      ''''''''''''''''''''''''''''''
      ' return sql according to mode

      if cbool(mode and 1) then
         showcreatetable = sql1
      end if
      if cbool(mode and 2) then
         showcreatetable = showcreatetable & sql2
      end if
   end function


   ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
   ' show create database -command for microsoft sql server
   '
   ' purpose:
   '    returns sql to create database
   '
   ' usage:
   '    response.write showcreatedatabase(1+2)
   '
   ' parametres:
   '    mode = function return value mode (see below)
   '       if mode bit 1 is on: sql to create tables will be returned
   '       if mode bit 2 is on: table related sql will be returned (foreign keys etc)

   function showcreatedatabase(mode)
      dim query,sql1,sql2
      set query  = server.createObject("ADODB.Recordset")
      query.open "select name,id from sysobjects where xtype='u' order by name",pageConnection,0,1
      while not query.EOF
         if cbool(mode and 1) then
            sql1 = sql1 & showcreatetable(query("name"),1)
         end if
         if cbool(mode and 2) then
            sql2 = sql2 & showcreatetable(query("name"),2)
         end if
         flushaa
         query.movenext
      wend
      query.close
      showcreatedatabase = sql1 & sql2
   end function

#endif
			return table;
		}



		/// <summary>
		/// internal function, used for building the create table statement to the database
		/// </summary>
		/// <param name="first"></param>
		/// <param name="output"></param>
		static void AddTableKeys( DsnConnection connection, DataTable dataTable, ref bool first, StringBuilder output )
		{
			IXDataTable xDataTable = dataTable as IXDataTable;
			if( connection.DbMode == DsnConnection.ConnectionMode.Sqlite )
			{
				// indexes are not used in sqlite.?
				return;
			}
			if( connection.DbFlavor != DsnConnection.ConnectionFlavor.SQLServer && xDataTable != null )
			{
				foreach( XDataTableKey xkey in xDataTable.keys )
				{
					if( connection.DbMode == DsnConnection.ConnectionMode.Sqlite )
						if( xkey.columns.Count > 1 )
						{
							Log.log( "Skipping build of multi-column key for sqlite." );
							continue;
						}

					DataColumn dc_auto_inc = dataTable.Columns[xkey.columns[0]];
					// this key was already added.
					if( dc_auto_inc != null && xkey.primary && dc_auto_inc.AutoIncrement )
						continue;
					output.Append( "\t" );
					if( !first )
						output.Append( "," );
					first = false;
					output.Append( xkey.unique ? "UNIQUE " : "" + "KEY" );
					if( xkey.name != null )
					{
						output.Append( connection.sql_quote_open );
						output.Append( xkey.name );
						output.Append( connection.sql_quote_close );
					}
					output.Append( "(" );
					bool colfirst = true;
					foreach( String s in xkey.columns )
					{
						if( !colfirst )
							output.Append( "," );
						colfirst = false;
						output.Append( connection.sql_quote_open );
						output.Append( s );
						output.Append( connection.sql_quote_close );
					}
					output.Append( ")" );
					output.Append( "\n" );
				}

				foreach( DataColumn dc in dataTable.Columns )
				{
					DataColumn dc_auto_inc = dc;
					object val = dc.ExtendedProperties["Index"];
					bool is_index = val != null ? Convert.ToBoolean( val ) : false; ;
					// this key was already added.
					if( !is_index )
						continue;

					output.Append( "\t" );
					if( !first )
						output.Append( "," );
					first = false;

					output.Append( "KEY" );

					{
						output.Append( connection.sql_quote_open );
						output.Append( dc.ColumnName + "_key" );
						output.Append( connection.sql_quote_close );
					}
					output.Append( "(" );
					bool colfirst = true;

						if( !colfirst )
							output.Append( "," );
						colfirst = false;
						output.Append( connection.sql_quote_open );
						output.Append( dc.ColumnName );
						output.Append( connection.sql_quote_close );

					output.Append( ")" );
					output.Append( "\n" );
				}
			}
			foreach( DataRelation fk in dataTable.ParentRelations )
			//foreach( ForeignKeyConstraint fk in dataTable.ParentRelations )
			{
				bool valid_parent = false;
				// only do constratins for other tables that are stored in the database.
				foreach( Attribute attr in fk.ParentTable.GetType().GetCustomAttributes( false ) )
				{
					if( attr as SQLPersistantTable != null )
					{
						valid_parent = true;
						break;
					}
				}
				if( valid_parent )
				{
					output.Append( "\t" );
					if( !first )
						output.Append( "," );
					first = false;

					output.Append( "CONSTRAINT " + connection.sql_quote_open + dataTable.Prefix + fk.RelationName + connection.sql_quote_close + " FOREIGN KEY " );
					if( connection .DbMode == DsnConnection.ConnectionMode.SQLServer )
						;
					else
						output.Append( ( ( fk.ChildColumns.Length < 1 || fk.ChildColumns[0].ColumnName == null ) ? "" : connection.sql_quote_open + fk.ChildColumns[0].ColumnName + connection.sql_quote_close ) );
					output.Append( "(" );
					bool firstcol = true;
					foreach( DataColumn col in fk.ChildColumns )
					{
						if( !firstcol )
							output.Append( "," );
						firstcol = false;
						output.Append( connection.sql_quote_open + col.ColumnName + connection.sql_quote_close );
					}
					output.Append( ")\n\t\tREFERENCES " );
					output.Append( connection.sql_quote_open + MySQLDataTable.GetCompleteTableName( fk.ParentTable ) + connection.sql_quote_close );
					output.Append( "(" );
					firstcol = true;
					foreach( DataColumn col in fk.ParentColumns )
					{
						if( !firstcol )
							output.Append( "," );
						firstcol = false;
						output.Append( connection.sql_quote_open + col.ColumnName + connection.sql_quote_close );
					}
					output.Append( ")" );
					if( fk.ChildKeyConstraint != null )
					{
						output.Append( "\n\t\t\tON DELETE "
							+ ( ( fk.ChildKeyConstraint.DeleteRule == Rule.Cascade ) ? "CASCADE"
							: ( fk.ChildKeyConstraint.DeleteRule == Rule.None ) ? "NO ACTION"
							: ( fk.ChildKeyConstraint.DeleteRule == Rule.SetDefault ) ? "SET DEFAULT"
							: ( fk.ChildKeyConstraint.DeleteRule == Rule.SetNull ) ? "SET NULL"
								: "RESTRICT" )
						);
						output.Append( "\n\t\t\tON UPDATE "
							+ ( ( fk.ChildKeyConstraint.UpdateRule == Rule.Cascade ) ? "CASCADE"
							: ( fk.ChildKeyConstraint.UpdateRule == Rule.None ) ? "NO ACTION"
							: ( fk.ChildKeyConstraint.UpdateRule == Rule.SetDefault ) ? "SET DEFAULT"
							: ( fk.ChildKeyConstraint.UpdateRule == Rule.SetNull ) ? "SET NULL"
								: "RESTRICT" )
							);
					}
					output.Append( "\n" );
				}
			}
#if asdfsafd
			foreach( XDataTable.XDataTableForeignKey fk in dataTable.foreign )
			{
				if( !first )
					output.Append( "," );
				first = false;
				output.Append( "CONSTRAINT " + connection.sql_quote_open + dataTable.Prefix + fk.keyname + connection.sql_quote_close + " FOREIGN KEY " + ( ( fk.child_indexname == null ) ? "" : connection.sql_quote_open + fk.child_indexname + connection.sql_quote_close ) );
				output.Append( "(" );
				bool firstcol = true;
				foreach( String col in fk.child_columns )
				{
					if( !firstcol )
						output.Append( "," );
					firstcol = false;
					output.Append( connection.sql_quote_open + col + connection.sql_quote_close );
				}
				output.Append( ")REFERENCES " );
				output.Append( connection.sql_quote_open + fk.parent_table + connection.sql_quote_close );
				output.Append( "(" );
				firstcol = true;
				foreach( String col in fk.parent_columns )
				{
					if( !firstcol )
						output.Append( "," );
					firstcol = false;
					output.Append( connection.sql_quote_open + col + connection.sql_quote_close );
				}
				output.Append( ")ON DELETE "
					+ ( ( fk.fk.DeleteRule == Rule.Cascade ) ? "CASCADE"
					: ( fk.fk.DeleteRule == Rule.None ) ? "NO ACTION"
					: ( fk.fk.DeleteRule == Rule.SetDefault ) ? "SET DEFAULT"
					: ( fk.fk.DeleteRule == Rule.SetNull ) ? "SET NULL"
						: "RESTRICT" )
				);
				output.Append( " ON UPDATE "
					+ ( ( fk.fk.UpdateRule == Rule.Cascade ) ? "CASCADE"
					: ( fk.fk.UpdateRule == Rule.None ) ? "NO ACTION"
					: ( fk.fk.UpdateRule == Rule.SetDefault ) ? "SET DEFAULT"
					: ( fk.fk.UpdateRule == Rule.SetNull ) ? "SET NULL"
						: "RESTRICT" )
					);
			}
#endif
		}

		/// <summary>
		/// Matches a DataTable according to a CreateTable statement (TableName, columsn, and column types)
		/// </summary>
		/// <param name="CreateStatement">The create statement which describes the table</param>
		/// <param name="delete_cols">Delete extra columns in DataTable that are not in the create statement</param>
		static public void MatchCreate( DsnConnection connection, DataTable dataTable, String CreateStatement, bool delete_cols )
		{
			XDataTable<DataRow> xtable = dataTable as XDataTable<DataRow>;
			String FullTableName;
			bool created = false;
			if ( connection == null )
			{
				Log.log( "Previously this would default to staticDSN.... aborting table create." );
				return;
			}
			if( connection == null )
				connection = StaticDsnConnection.dsn;

			if( dataTable == null )
				dataTable = SQL_Utilities.CreateTable( CreateStatement );

			if( CreateStatement != null )
			{
				XDataTable<DataRow> xoriginal = SQL_Utilities.CreateTable( CreateStatement );
				dataTable.TableName = xoriginal.TableName;
				dataTable.Prefix = xoriginal.Prefix;
				if( xtable != null )
					xtable.extra = xoriginal.extra;
				foreach( DataColumn dc_orig in xoriginal.Columns )
				{
					bool found = false;
					foreach( DataColumn dc_target in dataTable.Columns )
					{
						if( dc_target.ColumnName == dc_orig.ColumnName )
						{
							found = true;
							break;
						}
					}
					if( !found )
					{
						DataColumn dc;
						dataTable.Columns.Add( dc = new DataColumn( dc_orig.ColumnName, dc_orig.DataType ) );

						foreach( DictionaryEntry property in dc_orig.ExtendedProperties )
						{
							dc.ExtendedProperties.Add( property.Key, property.Value );
						}

						dc.MaxLength = dc_orig.MaxLength;
						dc.Namespace = dc_orig.Namespace;
						dc.AutoIncrement = dc_orig.AutoIncrement;
						dc.AllowDBNull = dc_orig.AllowDBNull;
						dc.AutoIncrementSeed = dc_orig.AutoIncrementSeed;
						dc.Unique = dc_orig.Unique;
					}
				}
				foreach( XDataTableKey dc_orig in xoriginal.keys )
				{
					if ( xtable != null )
					{
						bool found = false;
						foreach( XDataTableKey dc_target in xtable.keys )
						{
							if ( dc_target.name == dc_orig.name )
							{
								found = true;
								break;
							}
						}
						if ( !found )
						{
							xtable.keys.Add( new XDataTableKey( dc_orig ) );
						}
					}
				}
			}
            if( xtable != null )
                FullTableName = xtable.FullTableName;
            else
                FullTableName = MySQLDataTable.GetCompleteTableName( dataTable );

			XDataTable<DataRow> original = null;
			DbDataReader reader = null;
			switch( connection.DbMode )
			{
			case DsnConnection.ConnectionMode.MySqlNative:
			case DsnConnection.ConnectionMode.Odbc:
				if( connection.DbFlavor == DsnConnection.ConnectionFlavor.MySqlNative )
				{
					reader = connection.KindExecuteReader( "show create table " + FullTableName );

					if( reader != null && reader.HasRows )
					{
						//DataTable t = reader.GetSchemaTable();
						if( reader.Read() )
						{
							//object o = reader["Create Table"];
							int cols = reader.FieldCount;
							int ord = reader.GetOrdinal( "Create Table" );
							string s = reader.GetString( 1 );
							original = SQL_Utilities.CreateTable( reader.GetString( ord ) );
							if( xtable != null )
								foreach( XDataTable<DataRow>.XDataTableForeignKey fk in original.foreign )
								{
									bool found = false;
									bool same = true;
									foreach( XDataTable<DataRow>.XDataTableForeignKey fk2 in xtable.foreign )
									{
										if( fk2.keyname == fk.keyname )
										{
											if( fk2.parent_table != fk.parent_table )
											{
												Log.log( "foreign key parent table mismatch" );
												same = false;
											}
											if( fk2.child_columns.Count == fk.child_columns.Count )
											{
												for( int n = 0; n < fk2.child_columns.Count; n++ )
												{
													if( fk2.child_columns[n] != fk.child_columns[n] )
													{
														Log.log( "foreign key child columns do not match" );
														same = false;
														break;
													}
												}
											}
											else
											{
												same = false;
												Log.log( "Foriegn key mismatch on child column count" );
											}

											if( fk2.parent_columns.Count == fk.parent_columns.Count )
											{
												for( int n = 0; n < fk2.parent_columns.Count; n++ )
												{
													if( fk2.parent_columns[n] != fk.parent_columns[n] )
													{
														Log.log( "foreign key parent columns do not match" );
														same = false;
														break;
													}
												}
											}
											else
											{
												same = false;
												Log.log( "Foriegn key mismatch on parent column count" );
											}

											found = true;
										}
									}
									if( !found )
										xtable.foreign.Add( fk );
									else
									{
										if( !same )
										{
											Log.log( "forign key definition does not match." );
											throw new Exception( "Need to generate alter table to fix forieng key definition" );
										}
										//else
										//    Log.log( "Duplicated foriegn key (matched name) - one from database, one in default defniition... didn't check to see if they are exactly the same columns." );
									}
								}
							original.foreign = null;
						}
						connection.EndReader( reader );
					}
				}
				if( connection.DbFlavor == DsnConnection.ConnectionFlavor.SQLServer )
				{
					original = DataTableFromSchema(connection, dataTable) as XDataTable<DataRow>;
				}
				break;
			case DsnConnection.ConnectionMode.SQLServer:
				original = DataTableFromSchema(connection, dataTable) as XDataTable<DataRow>;
				break;
			case DsnConnection.ConnectionMode.Sqlite:
				reader = connection.KindExecuteReader( "select tbl_name,sql from sqlite_master where type='table' and name='" + FullTableName + "'" );
				if( reader != null && reader.HasRows )
				{
					reader.Read();
					original = SQL_Utilities.CreateTable( reader.GetString( 1 ) );
					connection.EndReader( reader );
				}
				break;
			default:
				throw new Exception( "Unhandled mode in MatchCreate" );
			}
			if( original == null )
			{
				String extra = null;
				StringBuilder keys = new StringBuilder();
				StringBuilder sb = new StringBuilder();
				//string columns = null;
				bool first = true;
				bool first_key = true;
				created = true;
				//DataColumn auto = null;
				keys.Length = 0;
				foreach( DataColumn col in dataTable.Columns )
				{
					// the DsnConnection creates a column specifically for the type of database connected to
					// syntax for keys and types changes.
					connection.AddColumnCreate( sb, ref first, keys, ref first_key, col );
				}
				AddTableKeys( connection, dataTable, ref first_key, keys );

				string create = "CREATE TABLE "
					+ connection.sql_quote_open
					+ FullTableName
					+ connection.sql_quote_close
					+ "\n(\n"
					+ sb.ToString()
					+ ( keys.Length > 0 ? "\t," : "\t" )
					+ keys.ToString()
					+ ")"
					+ ( ( connection.DbMode == DsnConnection.ConnectionMode.Sqlite || ( connection.DbFlavor == DsnConnection.ConnectionFlavor.SQLServer ) ) ? ""
						: ( ( extra != null ) ? ( ( first || first_key ) ? "\n\t," : "" ) + extra : "" ) )
					;

				if( ( connection.DbMode == DsnConnection.ConnectionMode.Odbc && connection.DbFlavor == DsnConnection.ConnectionFlavor.MySqlNative )
					|| connection.DbMode == DsnConnection.ConnectionMode.MySqlNative )
				{
					if( extra == null || ( !extra.Contains( "engine=" ) && !extra.Contains( "ENGINE=" ) ) )
						create += " ENGINE=INNODB";
				}
				//Columns[0].ExtendedProperties.
				try
				{
					connection.ExecuteNonQuery( create );
					connection.LogWriteLine();
					//if( dataTable.auto_id != null )
				    //	dataTable.auto_id.AutoIncrementSeed = 1;
				}
				catch( OdbcException oe )
				{
					foreach( OdbcError error in oe.Errors )

						if( error.NativeError == 1005 )
						{
							// probably failed, cause one of it's constraints references a MyISAM table.
							create += " engine=MyISAM";
							connection.ExecuteNonQuery( create );
							connection.LogWriteLine();

						}
				}
				if( connection.DbMode == DsnConnection.ConnectionMode.Sqlite )
				{
					if( xtable != null )
						foreach( XDataTableKey xkey in xtable.keys )
						{
							bool index_first = true;

							if( xkey.primary && xkey.columns.Count == 1 )
								continue;
							
							string index = "CREATE " + ( xkey.unique ? "UNIQUE " : "" ) + "INDEX " + FullTableName + "_" + xkey.name + " ON " + FullTableName + "(";
							foreach( string col in xkey.columns )
							{
								if( !index_first )
									index += ",";
								index += col;
								index_first = false;
							}
							index += ")";
							connection.KindExecuteNonQuery( index );
						}
				}
			}
			else
			{
				foreach( DataColumn dc_target in dataTable.Columns )
				{
					bool found = false;
					foreach( DataColumn dc_orig in original.Columns )
					{
						if( dc_target.ColumnName == dc_orig.ColumnName )
						{
							if( dc_target.DataType != dc_orig.DataType )
							{
								bool okay = false;
								if( dc_target.DataType == typeof( XColor ) )
								{
									if( ( dc_orig.DataType == typeof( Int32 ) )
										|| ( dc_orig.DataType == typeof( Int64 ) )
										|| ( dc_orig.DataType == typeof( System.Drawing.Color ) )
										|| ( dc_orig.DataType == typeof( XColor ) ) )
									{
										okay = true;
									}
								}
								else if( ( dc_target.DataType == typeof( Byte ) )
									   || ( dc_target.DataType == typeof( bool ) ) )
								{
									if( ( dc_orig.DataType == typeof( Int32 ) ) )
										okay = true;
								}
								else if( dc_target.DataType == typeof( Money ) )
								{
									if( ( dc_orig.DataType == typeof( Decimal ) ) )
										okay = true;
								}
								if( !okay )
								{
									String err = "Data Type mismatch on [" + dc_target.ColumnName + "] (database=" + dc_orig.DataType + ") (program defintion=" + dc_target.DataType + ")";
									Log.log( err );
									//throw new Exception( err );
								}
							}
							found = true;
							break;
						}
					}
					if( !found )
					{
						// add this column

						// if it is the auto increment column, make sure to add the primary key at the same time.
						//ALTER TABLE `fortunet`.`bingo_sched3_session_macro_schedule` ADD COLUMN `test` INTEGER AFTER `session_macro_id`,
						//  ADD PRIMARY KEY (`test`);

						if( dc_target.AutoIncrement )
							connection.KindExecuteNonQuery( "ALTER TABLE "
									+ connection.sql_quote_open
									+ FullTableName
									+ connection.sql_quote_close
									+ ( ( connection.DbMode == DsnConnection.ConnectionMode.SQLServer ) ? "\n\tADD " : "\n\tADD COLUMN " )
									+ connection.sql_quote_open
									+ dc_target.ColumnName
									+ connection.sql_quote_close
									+ SQL_Utilities.GetColumnDef( connection.DbMode, connection.DbFlavor, dc_target )
									+ "\n\t,ADD PRIMARY KEY (`" + dc_target.ColumnName + "`)" );
						else
							connection.KindExecuteNonQuery( "ALTER TABLE "
									+ connection.sql_quote_open
									+ FullTableName
									+ connection.sql_quote_close
									+ (( connection.DbMode == DsnConnection.ConnectionMode.SQLServer)?"\n\tADD ":"\n\tADD COLUMN ")
									+ connection.sql_quote_open
									+ dc_target.ColumnName
									+ connection.sql_quote_close
									+ SQL_Utilities.GetColumnDef( connection.DbMode, connection.DbFlavor, dc_target ) );
#if use_p2p_events
						//if( transmit != null )
						//	Trigger( "Alter table add", TableName, dc_target.ColumnName );
#endif
					}
				}
				if( delete_cols )
					foreach( DataColumn dc_orig in original.Columns )
					{
						bool found = false;
						foreach( DataColumn dc_target in dataTable.Columns )
						{
							if( dc_target.ColumnName == dc_orig.ColumnName )
							{
								found = true;
								break;
							}

						}
						if( !found )
						{
							if( connection.DbMode == DsnConnection.ConnectionMode.Sqlite )
								continue;
							// add this column
							connection.ExecuteNonQuery( "ALTER TABLE "
									+ connection.sql_quote_open
									+ FullTableName
									+ connection.sql_quote_close
									+ ( ( connection.DbMode == DsnConnection.ConnectionMode.SQLServer ) ? "\n\tDROP " : "\n\tDROP COLUMN " )
									+ connection.sql_quote_open
									+ dc_orig.ColumnName
									+ connection.sql_quote_close );
#if use_p2p_events
							//if( transmit != null )
							//	Trigger( "Alter table drop", TableName, dc_orig.ColumnName );
#endif
						}
					}
			}
			if( created )
			{
				if( connection.DbMode == DsnConnection.ConnectionMode.SQLServer )
				{
					foreach( DataColumn dc in dataTable.Columns )
					{
						StringBuilder output = new StringBuilder();
						DataColumn dc_auto_inc = dc;
						object val = dc.ExtendedProperties["Index"];
						bool is_index = val != null ? Convert.ToBoolean( val ) : false; ;
						// this key was already added.
						if( !is_index )
							continue;

						output.Append( "CREATE INDEX " );

						{
							output.Append( connection.sql_quote_open );
							output.Append( dc.ColumnName + "_key" );
							output.Append( connection.sql_quote_close );
						}
						output.Append( " ON " );
						bool colfirst = true;
						output.Append( connection.sql_quote_open );
						output.Append( MySQLDataTable.GetCompleteTableName( dataTable ) );
						output.Append( connection.sql_quote_close );

						output.Append( "(" );

						output.Append( connection.sql_quote_open );
						output.Append( dc.ColumnName );
						output.Append( connection.sql_quote_close );

						output.Append( ")" );

						connection.KindExecuteNonQuery( output.ToString() );
						output.Clear();

					}
				}
			}
			//Created = true;
		}

		/// <summary>
		/// This matches a DataTable to a string 'Create Table ...' SQL command.
		/// </summary>
		/// <param name="CreateStatement">The create statement which describes this table</param>
		static public void MatchCreate( DsnConnection connection, DataTable dataTable, String CreateStatement )
		{
			MatchCreate( connection, dataTable, CreateStatement, false );
		}

		/// <summary>
		/// This matches a DataTable to a string 'Create Table ...' SQL command.
		/// </summary>
		/// <param name="CreateStatement">The create statement which describes this table</param>
		static public void MatchCreate( DsnConnection connection, DataTable dataTable )
		{
			MatchCreate( connection, dataTable, null, false );
		}

		/// <summary>
		/// Select * from table of same name as data table.
		/// </summary>
		static public List<DataRow> FillDataTable( DsnConnection connection, DataTable dataTable )
		{
			return FillDataTable( connection, dataTable, null );
		}

		/// <summary>
		/// Select * from table of same name as data table.
		/// </summary>
		/// <param name="filter">Condition to limit results to fill with</param>
		static public List<DataRow> FillDataTable( DsnConnection connection, DataTable dataTable, string filter )
		{
			return FillDataTable( connection, dataTable, filter, null );
		}
		/// <summary>
		/// Select * from table of same name as data table.
		/// </summary>
		/// <param name="filter">Condition to limit results to fill with</param>
		static public List<DataRow> FillDataTable( DsnConnection connection, DataTable dataTable, string filter, string order )
		{
			if( connection == null )
				return null;

			if( order == null )
			{
				if( XDataTable.HasNumber( dataTable ) )
					order = XDataTable.Number( dataTable );
				else if( XDataTable.HasName( dataTable ) )
					order = XDataTable.Name( dataTable );
			}

			return  FillDataTable( connection, dataTable, "select * from " + connection.sql_quote_open
				+ MySQLDataTable.GetCompleteTableName( dataTable ) + connection.sql_quote_close
				+ ( ( filter != null ) ? " where " + filter : "" )
				+ ( ( order != null ) ? " order by " + order : "" )
				, true );
		}

		static public void SyncDataTableAutoIncrement( DsnConnection connection, DataTable dataTable )
		{
			int column_index;
			IXDataTable xtable = dataTable as IXDataTable;
			column_index = dataTable.Columns.IndexOf( XDataTable.ID( dataTable ) );
			if( column_index == -1 )
				for( column_index = 0; column_index < dataTable.Columns.Count; column_index++ )
				{
					if( dataTable.Columns[column_index].AutoIncrement )
						break;
				}
			if( column_index >= 0 && column_index < dataTable.Columns.Count )
			{
				if( dataTable.Columns[column_index].DataType == typeof( int ) ||
					dataTable.Columns[column_index].DataType == typeof( long ) )
				{
					object seed = connection.ExecuteScalar( "select max(" + dataTable.Columns[column_index].ColumnName + ") from "
						+ connection.sql_quote_open
						+ MySQLDataTable.GetCompleteTableName( dataTable )
						+ connection.sql_quote_close );
					if( seed != DBNull.Value )
						dataTable.Columns[column_index].AutoIncrementSeed = Convert.ToInt64( seed ) + 1;
					else
						dataTable.Columns[column_index].AutoIncrementSeed = 1;
				}
			}
			else if( xtable != null )
			{
				if( xtable.auto_id == null )
				{
					foreach( DataColumn isauto in dataTable.Columns )
						if( isauto.AutoIncrement )
							xtable.auto_id = isauto;
				}

				if( xtable.auto_id != null )
				{
					if( xtable.AutoKeyType == typeof( int ) ||
						xtable.AutoKeyType == typeof( long )
						)
					{
						try
						{
							object seed = connection.ExecuteScalar( "select max(" + xtable.auto_id.ColumnName + ") from "
								+ connection.sql_quote_open
								+ xtable.FullTableName
								+ connection.sql_quote_close );
							if( seed != DBNull.Value )
								xtable.auto_id.AutoIncrementSeed = Convert.ToInt64( seed ) + 1;
							else
								xtable.auto_id.AutoIncrementSeed = 1;
						}
						catch
						{
						}
					}
				}
			}
		}

		/// <summary>
		/// Select * from table of same name as data table.
		/// </summary>
		/// <param name="filter">Condition to limit results to fill with</param>
		static public List<DataRow> FillDataTable( DsnConnection connection, DataTable dataTable, string full_sql, bool sync_autoincrement )
		{
			List<DataRow> rows = null;
			IXDataTable xtable = dataTable as IXDataTable;
            MySQLDataTable mytable = dataTable as MySQLDataTable;
            DbDataReader odr = null;

            if ( connection == null )
				return null;

			if( xtable != null )
			{
				xtable.filling = true;
			}

            if ( mytable != null )
                mytable.connection = connection;

            if (full_sql != null && (odr = connection.KindExecuteReader(full_sql, 2)) != null)
            {
                int nrow = 0;
				dataTable.BeginLoadData();
				while( odr.Read() )
                {
                    DataRow dr;
                    //Log.log( "ROw " + nrow );
                    nrow++;
					if( xtable != null )
						dr = xtable.NewRow();
					else 
						dr = dataTable.NewRow();
                    for (int i = 0; i < odr.FieldCount; i++)
                    {
                        string s = odr.GetName(i); ;
						try
						{
							object o = odr[i];
							{
								//Log.log( "DOING COLUMN " + s );
								if( dataTable.Columns.IndexOf( s ) < 0 )
								{
									try
									{
										dataTable.Columns.Add( s, odr.GetFieldType( i ) );
									}
									catch
									{
										Log.log( "Column " + s + " is not found, cannot add?" );
									}
								}
							}
							if( o != DBNull.Value )
							{
								Type t = dataTable.Columns[s].DataType;

								if( t == typeof( Guid ) )
								{
									if( connection.DbMode == DsnConnection.ConnectionMode.MySqlNative
										|| ( connection.DbMode == DsnConnection.ConnectionMode.Odbc &&
										 connection.DbFlavor == DsnConnection.ConnectionFlavor.MySqlNative ) )
									{
										if( o.GetType() == typeof( byte[] ) )
											dr[s] = new Guid( o as byte[] );
										else
											dr[s] = new Guid( o.ToString() );
									}
									else
										dr[s] = o;
								}
								if( t == typeof( XGuid ) )
								{
									dr[s] = new XGuid( o.ToString() );
								}
								else if( t == typeof( Money ) )
								{
									dr[s] = new Money( Convert.ToInt64( odr[i] ) );
								}
								else if( t == typeof( decimal ) )
								{
									dr[s] = Convert.ToDecimal( odr[i] );
								}
								else if( t == typeof( Int32 ) && o.ToString().Length == 0 )
								{
									dr[s] = 0;
								}
								else if( t == typeof( System.Drawing.Color ) )
								{
									try
									{
										dr[s] = System.Drawing.Color.FromArgb( Convert.ToInt32( (int)Convert.ToInt64( odr[i] ) ) );
									}
									catch
									{
										Log.log( "failed integer conversion" );
										try
										{
											dr[s] = System.Drawing.Color.FromArgb( (int)Convert.ToInt64( odr[i] ) );
											Log.log( " and... maybe that was ok? " );
										}
										catch( Exception e )
										{
											Log.log( e.Message );
										}
									}
								}
								else
								{
									//Object o2 = odr[i];
									//if( o.GetType() == typeof( byte[] ) )
									//	dr[s] = new Guid( o as byte[] );
									//else
									if( t == typeof( XColor ) )
										dr[s] = new XColor( Convert.ToInt32(o) );
									else
										dr[s] = o;
								}
							}
						}
						catch( FormatException fex )
						{
							object o = odr.GetValue( i );
							{
								//byte[] buffer = new byte[256];
								//odr.GetBytes( i, 0, buffer, 0, 256 );
								//Log.log( "something" );
							}
							Log.log( "Format exception: " + fex.Message + "[" + odr[i].ToString() + "]" );
							continue;
						}
						catch( ArgumentException aex )
						{
							Log.log( "Argument exception: " + aex.Message );
						}
						catch( NullReferenceException nrex )
						{
							Log.log( "null reference in FillDataTable: " + nrex.Message );
						}
						catch( Exception ex )
						{
							dataTable.Columns.Add( s, odr.GetFieldType( i ) );
							dr[s] = odr[i];
							Console.WriteLine( ex.Message );
						}
                    }
                    try
                    {
                        dataTable.Rows.Add(dr);
                        if (rows == null)
                            rows = new List<DataRow>();
                        rows.Add(dr);
                        // this row is now synced with database... (but the table might not be)
                        //dr.AcceptChanges();
                    }
                    catch (Exception ex)
                    {
                        Log.log(ex.Message);

#if fix_by_delete			
						if( ( xtable!=null && xtable.filling ) && live )
						{
							string cmd = "delete from " + FullTableName + " where ";
							bool first = true;
							if( PrimaryKey != null && PrimaryKey.Length > 0 )
							{
								/// use the primary key of the row to delete the conflict.
								//throw new Exception( "Untested." );
								for( int i = 0; i < PrimaryKey.Length; i++ )
								{
									int ord = odr.GetOrdinal( PrimaryKey[i].ColumnName );
									object o = odr[ord];
									if( odr.IsDBNull( i ) )
										continue;
									if( !first )
										cmd += " and ";
									cmd += odr.GetName( ord ) + "=" + GetSQLValue( o.GetType(), o );
									first = false;
								}
							}
							else
							{
								for( int i = 0; i < odr.FieldCount; i++ )
								{
									object o = odr[i];
									if( odr.IsDBNull( i ) )
										continue;
									if( !first )
										cmd += " and ";
									cmd += odr.GetName( i ) + "=" + GetSQLValue( o.GetType(), o );
									first = false;
								}
							}
							connection.KindExecuteNonQuery( cmd );
							Log.log( ex.Message + "{Fixed by Deleting relation.}" );
						}
#else
                        continue;
#endif
                    }
                    //Log.log( "Ended ROw " + nrow );
                }
				if( rows != null )
					foreach( DataRow row in rows )
					{
						row.AcceptChanges();
					}
				try
				{
					dataTable.EndLoadData();
				}
				catch( Exception e )
				{
					if( dataTable.HasErrors )
					{
						Log.log( dataTable.TableName + " is in error..." );
						DataRow[] tmp_rows = dataTable.GetErrors();
						for( int i = 0; i < tmp_rows.Length; i++ )
						{
							for( int j = 0; j < dataTable.Columns.Count; j++ )
							{
								Log.log( "Row" + tmp_rows[i].RowState + "[" + i + "][" + dataTable.Columns[j].ColumnName + "] = " + tmp_rows[i][j] + " : " + tmp_rows[i].RowError );
							}
						}
					}
					else
					{
						if( dataTable.DataSet != null )
							DumpTableErrors( dataTable.DataSet );
					}
				}
				connection.EndReader( odr );
                // this is more of a flush out...
            }
            else
            {
                //CreateDataTable(connection, dataTable.DataSet);
            }

			if( sync_autoincrement )
				SyncDataTableAutoIncrement( connection, dataTable );

			if( xtable != null )
				xtable.filling = false;

			return rows;
		}

		public static void FillDataSet( DsnConnection dsn, DataSet dataSet )
		{
			foreach( DataTable dataTable in dataSet.Tables )
				FillDataTable( dsn, dataTable );
		}

		
		public static string FullTableName(DataTable table)
		{
			return MySQLDataTable.GetCompleteTableName( table );
		}

		static public void UpdateSeed( DsnConnection connection, DataTable xtable, DataColumn auto_increment )
		{

			object seed = connection.ExecuteScalar( "select max(" + auto_increment.ColumnName + ") from "
					+ connection.sql_quote_open
					+ FullTableName( xtable )
					+ connection.sql_quote_close );
			if( seed != DBNull.Value )
				auto_increment.AutoIncrementSeed = Convert.ToInt64( seed ) + 1;
			else
				auto_increment.AutoIncrementSeed = 1;

		}

		public static void MatchCreate( DsnConnection dsnConnection, DataSet dataSet )
		{

			foreach( DataTable table in dataSet.Tables )
			{
				MatchCreate( dsnConnection, table );
			}
		}

        /// <summary>
        /// returns a properly formatted sql value string.  (includes quotes if it's a string and escapes characters as required
        /// </summary>
        /// <param name="connection">parameters are really connection specific</param>
        /// <param name="t">type of the column</param>
        /// <param name="o">object of the column - potentially different type than type of column</param>
        /// <returns>the properly formatted sql string</returns>
		public static String GetSQLValue( DsnConnection connection, Type t, object o )
		{
			if( t == typeof( Guid ) )
			{
				Type ot = o.GetType();
				object guid;
				if( ot == typeof( System.Int32 ) )
				{
					if( Convert.ToInt32( o ) == 0 )
						guid = Guid.Empty;
					else
						throw new Exception( "Invalid integer passed as GUID" );
				}
				else
					guid = o;
                if ( guid == DBNull.Value )
                    return "NULL";
				if( connection == null )
					return "'" + guid.ToString() + "'";

				if( connection.DbMode == DsnConnection.ConnectionMode.MySqlNative ||
					( connection.DbMode == DsnConnection.ConnectionMode.Odbc &&
					connection.DbFlavor == DsnConnection.ConnectionFlavor.MySqlNative ) )
				{
					return connection.sql_value_quote_open + guid.ToString() + connection.sql_value_quote_close;
					/*
					byte[] bytes = guid.ToByteArray();
					String value = "0x";
					for( int n = 0; n < 16; n++ )
						value += bytes[n].ToString( "x2" );
					return value;// "0x" + guid.ToString( "N" );
					 */
				}
				else
				{
					return connection.sql_value_quote_open + connection.Escape( guid.ToString() ) + connection.sql_value_quote_close;
				}
			}
			if( t == typeof( string ) )
				if( connection == null )
					return "'" + DsnConnection.Escape( DsnConnection.ConnectionMode.NativeDataTable, DsnConnection.ConnectionFlavor.Unknown, o.ToString() ) + "'";
				else
					return connection.sql_value_quote_open + connection.Escape( o.ToString() ) + connection.sql_value_quote_close;
			if( t == typeof( int ) || t == typeof( Int64 ) )
			{
				if( o.ToString().Length == 0 )
					return "0";
				return o.ToString();
			}
			if( t == typeof( DateTime ) )
				return MakeDate( connection, Convert.ToDateTime( o ) ).ToString();
			if( t == typeof( bool ) )
				return ( ( ( o.GetType() != typeof( DBNull ) ) && (bool)o ) ? "1" : "0" );
			if( t == typeof( Money ) )
			{
				long MoneyAux = (Money)o;
				return MoneyAux.ToString();
			}
			if( t == typeof( XColor ) )
			{
				System.Drawing.Color c = ( o as XColor );
				return c.ToArgb().ToString();
			}
			if( t == typeof( System.Drawing.Color ) )
			{
				return ( (System.Drawing.Color)o ).ToArgb().ToString();
			}
			return o.ToString();
		}

		public static long MakeDate( DsnConnection dsn, DateTime dt )
		{
			// should check dsn for beavior NULL dsn being internal datatable seelctable value
			return ( dt.Year * 10000000000 + dt.Month * 100000000 + dt.Day * 1000000 + dt.Hour * 10000 + dt.Minute * 100 + dt.Second );
		}
		public static String MakeDateOnly( DsnConnection.ConnectionMode mode, DsnConnection.ConnectionFlavor dbFlavor, DateTime dt )
		{
			if( ( mode == DsnConnection.ConnectionMode.Odbc ) && ( dbFlavor == DsnConnection.ConnectionFlavor.MySqlNative ) )
				return ( dt.Year * 10000 + dt.Month * 100 + dt.Day * 1 ).ToString();
			if( ( mode == DsnConnection.ConnectionMode.NativeDataTable ) || ( mode == DsnConnection.ConnectionMode.AccessMDB ) )
				return "#" + dt.ToString( "yyyy-MM-dd" ) + "#" ;
			return "'" + dt.ToString( "yyyy-MM-dd" ) + "'";
		}
        public static String MakeDateOnly( DateTime dt )
        {
            return "'" + dt.ToString( "yyyy-MM-dd" ) + "'";
        }
		public static String MakeDateOnly( DsnConnection dsn, DateTime dt )
		{
            if( dsn == null )
			    return MakeDateOnly( dt );
            else
                return MakeDateOnly( dsn.DbMode, dsn.DbFlavor, dt );

		}
		public static long MakeTimeOnly( DsnConnection dsn, DateTime dt )
		{
			return ( dt.Hour * 10000 + dt.Minute * 100 + dt.Second * 1 );
		}

		public static String GetSQLValue( DsnConnection connection, DataColumn dc, object o )
		{
			if( dc.DataType == typeof( DateTime ) )
			{
				object o_type = dc.ExtendedProperties["Extra Type"];
				string extra_type_info = ( o_type == null ? "" : o_type.ToString() );
				if( extra_type_info != "" )
				{
					if( extra_type_info == "date" )
						return MakeDateOnly( connection, Convert.ToDateTime( o ) ).ToString();
					else
						if( extra_type_info == "time" )
							return MakeTimeOnly( connection, Convert.ToDateTime( o ) ).ToString();
						else
							if( extra_type_info == "createstamp" )
								return "should have already skipped this.";
							else
								return MakeDate( connection, Convert.ToDateTime( o ) ).ToString();
				}
				else
				{
					if( dc.Namespace == "date" )
						return MakeDateOnly( connection, Convert.ToDateTime( o ) ).ToString();
					else
						if( dc.Namespace == "time" )
							return MakeTimeOnly( connection, Convert.ToDateTime( o ) ).ToString();
						else
							if( dc.Namespace == "createstamp" )
								return "should have already skipped this.";
							else
								return MakeDate( connection, Convert.ToDateTime( o ) ).ToString();
				}
			}
			else
				return GetSQLValue( connection, dc.DataType, o );
		}



		static void Delete( DsnConnection connection, DataTable table, DataRow row )
		{
			string cmd = "delete from " + MySQLDataTable.GetCompleteTableName( table ) + " where ";
			bool first = true;
			if( row.HasVersion( DataRowVersion.Original ) )
			{
				int cols = row.Table.Columns.Count;
				for( int i = 0; i < cols; i++ )
				{
					if( row[i, DataRowVersion.Original] == null || row[i, DataRowVersion.Original].GetType() == typeof( DBNull ) )
						continue;
					if( !first )
						cmd += " and ";
					first = false;
					cmd += row.Table.Columns[i].ColumnName + "=" + GetSQLValue( connection, row[i, DataRowVersion.Original].GetType(), row[i, DataRowVersion.Original] );
				}
			}
			else
			{
				for( int i = 0; i < row.ItemArray.Length; i++ )
				{
					if( row[i] == null || row[i].GetType() == typeof( DBNull ) )
						continue;
					if( !first )
						cmd += " and ";
					first = false;
					cmd += table.Columns[i].ColumnName + "=" + GetSQLValue( connection, row[i].GetType(), row[i] );
				}
			}
			connection.KindExecuteNonQuery( cmd );
		}

		public static void DoDelete( DsnConnection connection, DataTable table, DataRow dataRow )
		{
			// should be clever about this...
			if( table.PrimaryKey != null && table.PrimaryKey.Length > 0 )
			{
				if( connection == null )
					return;
				//String primarykey = ID( this );
				if( dataRow.HasVersion( DataRowVersion.Original ) )
					connection.KindExecuteNonQuery( "delete from " + MySQLDataTable.GetCompleteTableName( table ) + " where " + table.PrimaryKey[0].ColumnName + "=" + connection.sql_value_quote_open + dataRow[table.PrimaryKey[0].Ordinal, DataRowVersion.Original] + connection.sql_value_quote_close );
				else
					connection.KindExecuteNonQuery( "delete from " + MySQLDataTable.GetCompleteTableName( table ) + " where " + table.PrimaryKey[0].ColumnName + "=" + connection.sql_value_quote_open + dataRow[table.PrimaryKey[0].Ordinal] + connection.sql_value_quote_close );
			}
			else
			{
				Delete( connection, table, dataRow );
			}
		}


		public static bool DoInsertRow( DsnConnection connection, DataTable table, DataRow row )
		{
			bool generated_update = false;
			if( connection != null )
			{
				try
				{
					IXDataTable xtable = table as IXDataTable;

					StringBuilder sb = new StringBuilder();
					//changes = this.GetChanges( DataRowState.Added );
					//string cmd_prefix = "insert into " + CompleteTableName + "(";
					bool first = true;
					sb.Append( "insert into " );
					sb.Append( connection.sql_quote_open );
					{
						if( xtable != null )
							sb.Append( xtable.FullTableName );
						else
							sb.Append( MySQLDataTable.GetCompleteTableName( table ) );
					}
					sb.Append( connection.sql_quote_close );
					sb.Append( "(" );
					DataColumn auto_count = null;
					bool auto_count_null = true;
					//row.AcceptChanges();
					generated_update = true;
					DataColumnCollection Columns = row.Table.Columns;
					foreach( DataColumn column in row.Table.Columns )
					{
						// skip columns that have NULL in them..
						if( column.AutoIncrement )
						{
							auto_count = column;
						}
						if( row[column.Ordinal] == null || ( row[column.Ordinal] as DBNull ) != null )
							continue;
						if( !first )
							sb.Append( "," );
						first = false;
						sb.Append( connection.sql_quote_open );
						sb.Append( column.ColumnName );
						sb.Append( connection.sql_quote_close );
					}
					if( first )
					{
						Log.log( "NULL database row.  Or no data." );
						return generated_update;
					}
					sb.Append( ")values(" );
					//foreach( DataRow row in changes.Rows )
					{
						List<object> parameters = new List<object>();
						int n;
						int val = 0;
						for( n = 0; n < Columns.Count; n++ )
						{
							object o = Columns[n].ExtendedProperties["Extra Type"];
							String exra_type_info = ( o == null ? "" : o.ToString() );
							// skip the auto increment column
							//if( Columns[n].AutoIncrement )
							//	continue;
							// only if it's null ...
							if( Columns[n].DataType == typeof( DateTime ) && exra_type_info == "createstamp" )
								// skip timestamp column output - the database should be filling this value in.
								continue;
							if( Columns[n].DataType == typeof( DateTime ) && Columns[n].Namespace == "createstamp" )
								// skip timestamp column output - the database should be filling this value in.
								continue;
							if( row[n] == null || ( row[n] as DBNull ) != null )
								continue;

							if( Columns[n] == auto_count )
								auto_count_null = false;

							if( row[n].GetType() == typeof( byte[] ) )
							{
								parameters.Add( row[n] );
								sb.Append( ( ( val > 0 ) ? ",?" : "?" ) );
							}
							else
							{
								sb.Append( ( ( val > 0 ) ? "," : "" ) );
								sb.Append( DsnSQLUtil.GetSQLValue( connection, Columns[n], row[n] ) );
							}
							val++;
						}
						sb.Append( ")" );
						bool recover_auto_id = true;
						if( xtable == null )
						{
							if( ( table.PrimaryKey != null ) && ( table.PrimaryKey.Length > 0 ) && ( table.PrimaryKey[0].DataType == typeof( Guid ) ) )
								recover_auto_id = false;
						}
						else
						{
							if( xtable.AutoKeyType == typeof( Guid ) )
								recover_auto_id = false;
						}

						if( recover_auto_id )
						{
							long id = connection.KindExecuteInsert( sb.ToString(), parameters.ToArray() );
							if( id > 0 && auto_count_null )
							{
								// the id result from the insert will be 0 if it was set.
								//filling = true;
								// this is an update to get the auto-increment to sync.
								if( auto_count != null )
									if( !Compare( row[auto_count.Ordinal].GetType(), row[auto_count.Ordinal], id ) )
										row[auto_count.Ordinal] = id;
								//filling = false;
							}
						}
						else
							connection.KindExecuteNonQuery( sb.ToString(), parameters.ToArray() );
					}
				}
				catch( Exception e )
				{
					Log.log( e.Message );
				}
			}
			return generated_update;
		}

		public static bool DoDeleteRow(DsnConnection connection, DataTable table, DataRow row)
		{
			bool generated_update = false;
			if (connection != null)
			{
				try
				{
					XDataTable<DataRow> xtable = table as XDataTable<DataRow>;

					StringBuilder sb = new StringBuilder();
					//changes = this.GetChanges( DataRowState.Added );
					//string cmd_prefix = "insert into " + CompleteTableName + "(";
					bool first = true;
					sb.Append("DELETE FROM ");
					sb.Append(connection.sql_quote_open);
					{
						if (xtable != null)
							sb.Append(xtable.FullTableName);
						else
							sb.Append(MySQLDataTable.GetCompleteTableName(table));
					}
					sb.Append(connection.sql_quote_close);
					sb.Append(" WHERE ");
					DataColumn auto_count = null;
					DataColumnCollection Columns = row.Table.Columns;
					List<object> parameters = new List<object>();
					int val = 0;
					foreach (DataColumn column in row.Table.Columns)
					{
						// skip columns that have NULL in them..
						if (column.AutoIncrement)
						{
							auto_count = column;
						}
						if (row[column.Ordinal] == null || (row[column.Ordinal] as DBNull) != null)
							continue;
						if (!first)
							sb.Append(" AND ");
						first = false;
						sb.Append(connection.sql_quote_open);
						sb.Append(column.ColumnName);
						sb.Append(connection.sql_quote_close);
						sb.Append(" = ");
						if (row[column.Ordinal].GetType() == typeof(byte[]))
						{
							parameters.Add(row[column.Ordinal]);
							sb.Append(((val > 0) ? ",?" : "?"));
							//sb.Append(((val > 0) ? ",?" : "?"));
						}
						else
						{
							//sb.Append(((val > 0) ? "," : ""));
							sb.Append(DsnSQLUtil.GetSQLValue(connection, column, row[column.Ordinal]));
						}
						val++;						
					}
					if (first)
					{
						Log.log("NULL database row.  Or no data.");
						return generated_update;
					}
					long id = connection.ExecuteNonQuery(sb.ToString(), parameters.ToArray());
					if (id >= 0)
						generated_update = true;
				}
				catch (Exception e)
				{
					Log.log(e.Message);
					generated_update = false;
				}
			}
			return generated_update;
		}
		
		
		public static bool DoInsertRow(DsnConnection connection, DataTable table, DataRow row, int LocationId)
		{
			bool generated_update = false;
			if (connection != null)
			{
				try
				{
					XDataTable<DataRow> xtable = table as XDataTable<DataRow>;

					StringBuilder sb = new StringBuilder();
					//changes = this.GetChanges( DataRowState.Added );
					//string cmd_prefix = "insert into " + CompleteTableName + "(";
					bool first = true;
					sb.Append("INSERT INTO ");
					sb.Append(connection.sql_quote_open);
					{
						if (xtable != null)
							sb.Append(xtable.FullTableName);
						else
							sb.Append(MySQLDataTable.GetCompleteTableName(table));
					}
					sb.Append(connection.sql_quote_close);
					sb.Append("(");
					DataColumn auto_count = null;
					bool auto_count_null = true;
					//generated_update = true;
					DataColumnCollection Columns = row.Table.Columns;
					foreach (DataColumn column in row.Table.Columns)
					{
						// skip columns that have NULL in them..
						if (column.AutoIncrement)
						{
							auto_count = column;
						}
						if (row[column.Ordinal] == null || (row[column.Ordinal] as DBNull) != null)
							continue;
						if (!first)
							sb.Append(",");
						first = false;
						sb.Append(connection.sql_quote_open);
						sb.Append(column.ColumnName);
						sb.Append(connection.sql_quote_close);
					}
					if (first)
					{
						Log.log("NULL database row.  Or no data.");
						return generated_update;
					}
					if (LocationId != 0)
						sb.Append(", location_id");
					
					sb.Append(")values(");
					//foreach( DataRow row in changes.Rows )
					{
						List<object> parameters = new List<object>();
						int n;
						int val = 0;
						for (n = 0; n < Columns.Count; n++)
						{
							object o = Columns[n].ExtendedProperties["Extra Type"];
							String exra_type_info = (o == null ? "" : o.ToString());
							// skip the auto increment column
							//if( Columns[n].AutoIncrement )
							//	continue;
							// only if it's null ...
							if (Columns[n].DataType == typeof(DateTime) && exra_type_info == "createstamp")
								// skip timestamp column output - the database should be filling this value in.
								continue;
							if (Columns[n].DataType == typeof(DateTime) && Columns[n].Namespace == "createstamp")
								// skip timestamp column output - the database should be filling this value in.
								continue;
							if (row[n] == null || (row[n] as DBNull) != null)
								continue;

							if (Columns[n] == auto_count)
								auto_count_null = false;

							if (row[n].GetType() == typeof(byte[]))
							{
								parameters.Add(row[n]);
								sb.Append(((val > 0) ? ",?" : "?"));
							}
							else
							{
								sb.Append(((val > 0) ? "," : ""));
								sb.Append(DsnSQLUtil.GetSQLValue(connection, Columns[n], row[n]));
							}
							val++;
						}
						if (LocationId != 0)
							sb.Append(", " + LocationId.ToString());
						sb.Append(")");
						bool recover_auto_id = true;
						if (xtable == null)
						{
							if ((table.PrimaryKey != null) && (table.PrimaryKey.Length > 0) && (table.PrimaryKey[0].DataType == typeof(Guid)))
								recover_auto_id = false;
						}
						else
						{
							if (xtable.AutoKeyType == typeof(Guid))
								recover_auto_id = false;
						}

						if (recover_auto_id)
						{
							long id = connection.KindExecuteInsert(sb.ToString(), parameters.ToArray());
							if (id > 0 && auto_count_null)
							{
								// the id result from the insert will be 0 if it was set.
								//filling = true;
								// this is an update to get the auto-increment to sync.
								if (auto_count != null)
									if (!Compare(row[auto_count.Ordinal].GetType(), row[auto_count.Ordinal], id))
										row[auto_count.Ordinal] = id;
								//filling = false;
							}
							if (id >= 0 )
							{
								generated_update = true;
							}
						}
						else
							connection.KindExecuteNonQuery(sb.ToString(), parameters.ToArray());
					}
				}
				catch (Exception e)
				{
					Log.log(e.Message);
					generated_update = false;
				}
			}
			return generated_update;
		}

		public static void InsertAllRows( DsnConnection connection, DataTable table )
		{
			connection.BeginTransaction();

			foreach( DataRow row in table.Rows )
				DsnSQLUtil.DoInsertRow( connection, table, row );

			connection.EndTransaction();
		}

		public static bool Compare( Type type, object a, object b )
		{
			if( ( a.GetType() == typeof( DBNull ) ) && ( b.GetType() == typeof( DBNull ) ) )
				return true;
			if( type == typeof( int ) )
			{
				if( b.GetType() == typeof( DBNull ) )
					return false;
				if( a.GetType() == typeof( DBNull ) )
					return false;
				if( Convert.ToInt32( a ) == Convert.ToInt32( b ) )
					return true;
				return false;
			}
			if( type == typeof( Int16 ) )
			{
				if( b.GetType() == typeof( DBNull ) )
					return false;
				if( a.GetType() == typeof( DBNull ) )
					return false;
				if( Convert.ToInt16( a ) == Convert.ToInt16( b ) )
					return true;
				return false;
			}
			if( type == typeof( string ) || type == typeof( Money ) || type == typeof( DateTime ) )
			{
				if( String.Compare( a.ToString(), b.ToString() ) == 0 )
					return true;
				return false;
			}
			if( type == typeof( bool ) )
			{
				if( a.GetType() == typeof( DBNull ) )
					return false;
				if( b.GetType() == typeof( DBNull ) )
					return false;
				if( Convert.ToBoolean( a ) == Convert.ToBoolean( b ) )
					return true;
				return false;
			}
			if( type == typeof( Guid ) )
			{
				Guid ga = ( a == DBNull.Value ) ? Guid.Empty : new Guid( a.ToString() );
				Guid gb = ( b == DBNull.Value ) ? Guid.Empty :
					new Guid( b.ToString() );
				if( ga == gb )
					return true;
				return false;
			}
			if( type == typeof( System.Drawing.Color ) )
			{
				System.Drawing.Color ca = ( a == DBNull.Value ) ? System.Drawing.Color.Empty : (System.Drawing.Color)a;
				System.Drawing.Color cb = ( b == DBNull.Value ) ? System.Drawing.Color.Empty : (System.Drawing.Color)b;
				if( ca.Equals( cb ) )
					return true;
				return false;
			}
			if( type == typeof( xperdex.classes.Types.XColor ) )
			{
				xperdex.classes.Types.XColor ca = ( a == DBNull.Value ) ? new XColor( System.Drawing.Color.Empty ): (xperdex.classes.Types.XColor)a;
				xperdex.classes.Types.XColor cb = ( b == DBNull.Value ) ? new XColor( System.Drawing.Color.Empty ): (xperdex.classes.Types.XColor)b;
				if( ca.Equals( cb ) )
					return true;
				return false;
			}
			if( type == typeof( Double ) )
			{
				if( a.GetType() == typeof( DBNull ) )
					return false;
				if( b.GetType() == typeof( DBNull ) )
					return false;
				if( Convert.ToDouble( a ) == Convert.ToDouble( b ) )
					return true;
				return false;
			}
			if( type == typeof( Decimal ) )
			{
				if( a.GetType() == typeof( DBNull ) )
					return false;
				if( b.GetType() == typeof( DBNull ) )
					return false;
				if( a.Equals( b ) )
					return true;
				return false;
			}
			if( a.Equals( b ) )
				return true;
			throw new Exception( "Possibly unchecked comparison..." );
		}

        /// <summary>
        /// In this flavor of insert command, we were swapped, so the current row 'Row' and the original data in RowBefore are the true deltas
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="table"></param>
        /// <param name="Row"></param>
        /// <param name="RowBefore"></param>
        /// <returns></returns>
		static bool DoUpdateCommand( DsnConnection connection, DataTable table, DataRow Row, DataRow RowBefore )
		{
			if( connection == null )
				return true;
			object keyval = null;
			List<DataColumn> modified_columns = new List<DataColumn>();

			string updateComm = "UPDATE " + MySQLDataTable.GetCompleteTableName( table ) + " SET ";
            if( RowBefore.HasVersion( DataRowVersion.Original ) && Row.HasVersion( DataRowVersion.Current ) )
			{
				bool first = true;
				//DataColumn auto = null;
				foreach( DataColumn col in table.Columns )
				{
					object a, b;
                    // we'll just end up setting the same value back on primary key columns.
                    try
					{
						a = RowBefore[col.ColumnName, DataRowVersion.Original];
						b = Row[col.ColumnName, DataRowVersion.Current];
					}
					catch( Exception e )
					{
						Log.log( e.Message );
						continue;

					}
					if( !Compare( col.DataType, a, b ) )
					{
                        // this was to get the PrimaryKey definition... it's better now.
						if( col.AutoIncrement )
							keyval = a;
						//	auto = col;
						//else
						{
							if( !col.ReadOnly )
							{
								if( Row[col.Ordinal].GetType() == typeof( DBNull ) )
								{
									if( !first )
										updateComm += ",";
									first = false;
									modified_columns.Add( col );
									updateComm += col.ColumnName + "=NULL";
								}
								else if( ( Row[col.Ordinal].ToString() == "" && ( col.DataType == typeof( string ) || col.DataType == typeof( DateTime ) ) )
									|| Row[col.Ordinal].ToString() != ""
									|| col.DefaultValue.ToString() != "" )
								{
									if( !first )
										updateComm += ",";
									first = false;
									modified_columns.Add( col );
									updateComm += col.ColumnName + "=";
									updateComm += DsnSQLUtil.GetSQLValue( connection, col.DataType, Row[col.Ordinal] );// RegSQLDataTable.GetRowValue( col, Row );
								}
							}
						}
					}
				}
			}
			else
			{
				bool first = true;
				DataColumn auto = null;
				foreach( DataColumn col in table.Columns )
				{
					if( col.AutoIncrement )
						auto = col;
					else
					{
						if( !col.ReadOnly )
						{
							updateComm += ( !first ) ? "," : "";
							first = false;
							modified_columns.Add( col );
							updateComm += connection.sql_quote_open + col.ColumnName + connection.sql_quote_close + "=";
							updateComm += DsnSQLUtil.GetSQLValue( connection, col.DataType, Row[col.Ordinal] );
						}
					}
				}
			}
			if( modified_columns.Count > 0 )
			{
				if( table.PrimaryKey.Length > 0 )
				{
					bool first = true;
					updateComm += " WHERE ";
					foreach( DataColumn keycol in table.PrimaryKey )
					{
						if( !first )
							updateComm += " and ";
						if( Row[keycol.Ordinal].GetType() != typeof( DBNull )

							)
						{
							first = false;
							updateComm += connection.sql_quote_open + keycol.ColumnName + connection.sql_quote_close + "="
								+ DsnSQLUtil.GetSQLValue( connection, keycol.DataType, ( keyval == null ) ? Row[keycol.Ordinal] : keyval );
						}
					}
					connection.KindExecuteNonQuery( updateComm, 2, null );
				}
				else
				{
					bool first = true;
					updateComm += " WHERE ";
					for( int i = 0; i < Row.ItemArray.Length; i++ )
					{
						if( Row[i] == null || Row[i, DataRowVersion.Original].GetType() == typeof( DBNull ) )
							continue;
						//if( Row[i].GetType() != typeof( DBNull ) )
						{
							if( !first )
								updateComm += " and ";
							first = false;
							updateComm += connection.sql_quote_open + Row.Table.Columns[i].ColumnName + connection.sql_quote_close + "="
								+ DsnSQLUtil.GetSQLValue( connection, Row[i].GetType(), Row[i, DataRowVersion.Original] );
						}
					}
					connection.KindExecuteNonQuery( updateComm, 2, null );
				}
				return true;
			}
			return false;
		}


		public static bool DoUpdateCommand( DsnConnection connection, DataTable table, DataRow Row )
		{
			if( connection == null )
				return true;
			object keyval = null;
			List<DataColumn> modified_columns = new List<DataColumn>();

			string updateComm = "UPDATE " + MySQLDataTable.GetCompleteTableName( table ) + " SET ";
			if( Row.HasVersion( DataRowVersion.Original ) && Row.HasVersion( DataRowVersion.Current ) )
			{
				bool first = true;
				//DataColumn auto = null;
				foreach( DataColumn col in table.Columns )
				{
					object a, b;
                    // we'll just end up setting the same value back on primary key columns.
                    try
					{
						a = Row[col.ColumnName, DataRowVersion.Original];
						b = Row[col.ColumnName, DataRowVersion.Current];
					}
					catch( Exception e )
					{
						Log.log( e.Message );
						continue;

					}
					if( !Compare( col.DataType, a, b ) )
					{
#if asdfasdf
                        if( !primary_key_changed )
                        {
                            // if the prmiary key changed; it was probably a swap, so 
                            // I still exist somewhere else... and really need to compare myself versus that one
                            foreach( DataColumn keycol in table.PrimaryKey )
                            {
                                if( col == keycol )
                                {
                                    primary_key_changed = true;
                                    keyval = a;
                                    break;
                                }
                            }
                            if( primary_key_changed )
                            {
                                foreach( DataRow row in table.Rows )
                                {
                                    if( row.HasVersion( DataRowVersion.Original ) )
                                    {
                                        if( row[col.Ordinal, DataRowVersion.Original].Equals( b ) )
                                            return DoUpdateCommand( connection, table, Row, row );
                                    }
                                }
                                // if this row doesn't exist before, it's a new row.
                                // somehow the datarow that used to be should have been deleted...
                                // so really I think this is still an exception that somewhere
                                // there was an acceptChanges that was bad.
                                // return DoInsertRow( connection, table, Row );

                                // okay then this update won't hurt... and later we'll get an insert of our row with the old data
                                // that was swapped in...
                            }
                        }
#endif
                        // this was to get the PrimaryKey definition... it's better now.
						if( col.AutoIncrement )
							keyval = a;
						//	auto = col;
						//else
						{
							if( !col.ReadOnly )
							{
								if( Row[col.Ordinal].GetType() == typeof( DBNull ) )
								{
									if( !first )
										updateComm += ",";
									first = false;
									modified_columns.Add( col );
									updateComm += col.ColumnName + "=NULL";
								}
								else if( ( Row[col.Ordinal].ToString() == "" && ( col.DataType == typeof( string ) || col.DataType == typeof( DateTime ) ) )
									|| Row[col.Ordinal].ToString() != ""
									|| col.DefaultValue.ToString() != "" )
								{
									if( !first )
										updateComm += ",";
									first = false;
									modified_columns.Add( col );
									updateComm += col.ColumnName + "=";
                                    updateComm += DsnSQLUtil.GetSQLValue( connection, col.DataType, Row[col.Ordinal] );// RegSQLDataTable.GetRowValue( col, Row );
								}
							}
						}
					}
				}
			}
			else
			{
				bool first = true;
				DataColumn auto = null;
				foreach( DataColumn col in table.Columns )
				{
					if( col.AutoIncrement )
						auto = col;
					else
					{
						if( !col.ReadOnly )
						{
							updateComm += ( !first ) ? "," : "";
							first = false;
							modified_columns.Add( col );
							updateComm += connection.sql_quote_open + col.ColumnName + connection.sql_quote_close + "=";
							updateComm += DsnSQLUtil.GetSQLValue( connection, col.DataType, Row[col.Ordinal] );
						}
					}
				}
			}
			if( modified_columns.Count > 0 )
			{
				if( table.PrimaryKey.Length > 0 )
				{
					bool first = true;
					updateComm += " WHERE ";
					foreach( DataColumn keycol in table.PrimaryKey )
					{
						if( !first )
							updateComm += " and ";
						if( Row[keycol.Ordinal].GetType() != typeof( DBNull )

							)
						{
							first = false;
							updateComm += connection.sql_quote_open + keycol.ColumnName + connection.sql_quote_close + "="
								+ DsnSQLUtil.GetSQLValue( connection, keycol.DataType, ( keyval == null ) ? Row[keycol.Ordinal] : keyval );
						}
					}
					connection.KindExecuteNonQuery( updateComm, 2, null );
				}
				else
				{
					bool first = true;
					updateComm += " WHERE ";
					for( int i = 0; i < Row.ItemArray.Length; i++ )
					{
						if( Row[i] == null || Row[i, DataRowVersion.Original].GetType() == typeof( DBNull ) )
							continue;
						//if( Row[i].GetType() != typeof( DBNull ) )
						{
							if( !first )
								updateComm += " and ";
							first = false;
							updateComm += connection.sql_quote_open + Row.Table.Columns[i].ColumnName + connection.sql_quote_close + "="
								+ DsnSQLUtil.GetSQLValue( connection, Row[i].GetType(), Row[i,DataRowVersion.Original] );
						}
					}
					connection.KindExecuteNonQuery( updateComm, 2, null );
				}
				return true;
			}
			return false;
		}


		public static int CommitChanges( DsnConnection connection, DataTable table )
		{
			DataTable updates = table.GetChanges();
			if( updates != null )
			{
				if( updates.Prefix == "" )
					updates.Prefix = table.Prefix;
				if( updates.Prefix == "" && table.DataSet != null )
					updates.Prefix = table.DataSet.Prefix;
				int result = CommitChanges( connection, updates, false );
				updates.Dispose();
				return result;
			}
			return 0;
		}
		/// <summary>
		/// Override of base method, Syncronizes tables to database.
		/// </summary>
		private static int CommitChanges( DsnConnection connection, DataTable table, bool signature_change )
		{
            int change_count = 0;
            if ( connection != null )
			{
				IXDataTable xtable = table as IXDataTable;
				if( xtable == null || !xtable.filling )
				{
					if( table != null )
					{
						foreach( DataRow Row in table.Rows )
						{
                            change_count++;
							switch( Row.RowState )
							{
                                case DataRowState.Added:
                                    {
                                        if( table.PrimaryKey.Length == 1 )
                                        {
                                            bool handled = false;
                                            DataColumn keycol = table.PrimaryKey[0];
                                            object b = Row[keycol.ColumnName, DataRowVersion.Current];
                                            //if( !Compare( keycol.DataType, a, b ) )
                                            {
												if( Row.RowState == DataRowState.Modified )
													foreach( DataRow original_row in table.Rows )
													{
														if( original_row.HasVersion( DataRowVersion.Original ) )
															if( original_row[keycol.ColumnName, DataRowVersion.Original].Equals( b ) )
															{
																handled = true;
																DsnSQLUtil.DoUpdateCommand( connection, table, Row, original_row );
																break;
															}
													}
                                                if( !handled )
                                                {
                                                    DsnSQLUtil.DoInsertRow( connection, table, Row );
                                                    break;
                                                }
                                                else
                                                    break;
                                            }
                                        }
                                        else
                                            DsnSQLUtil.DoInsertRow( connection, table, Row );
                                    }
                                    break;
                                case DataRowState.Modified:
                                    {
                                        if( table.PrimaryKey.Length == 1 )
                                        {
                                            bool handled = false;
                                            DataColumn keycol = table.PrimaryKey[0];
                                            object a = Row[keycol.ColumnName, DataRowVersion.Original];
                                            object b = Row[keycol.ColumnName, DataRowVersion.Current];
                                            if( !Compare( keycol.DataType, a, b ) )
                                            {
												foreach( DataRow original_row in table.Rows )
                                                {
                                                    if( original_row.HasVersion( DataRowVersion.Original ) )
                                                        if( original_row[keycol.ColumnName, DataRowVersion.Original].Equals( b ) )
                                                        {
                                                            handled = true;
                                                            DsnSQLUtil.DoUpdateCommand( connection, table, Row, original_row );
                                                            break;
                                                        }
                                                }
                                                if( !handled )
                                                {
                                                    handled = true;
                                                    DsnSQLUtil.DoInsertRow( connection, table, Row );
                                                    break;
                                                }
                                            }
                                            if( !handled )
                                                DsnSQLUtil.DoUpdateCommand( connection, table, Row );
                                        }
                                        else
                                            DsnSQLUtil.DoUpdateCommand( connection, table, Row );
                                    }
                                    break;
								case DataRowState.Deleted:
									DsnSQLUtil.DoDelete( connection, table, Row );
									break;
							}
						}
					}
					else
					{
						// probably the updatechanges method FAILED
						//   because there was no default() constructor
						// big whoop.
						foreach( DataRow row in table.Rows )
						{
							switch( row.RowState )
							{
								case DataRowState.Added:
                                    change_count++;
									DsnSQLUtil.DoInsertRow( connection, table, row );
									break;
								case DataRowState.Modified:
                                    change_count++;
									DsnSQLUtil.DoUpdateCommand( connection, table, row );
									break;
								case DataRowState.Deleted:
                                    change_count++;
									DsnSQLUtil.DoDelete( connection, table, row );
									break;
							}
						}
					}
				}
			}
			table.AcceptChanges();
#if use_p2p_events
            if ( change_count > 0 )
            {
                MySQLDataTable mytable = table as MySQLDataTable;
                if ( mytable != null )
                    mytable.GenerateTrigger( "Table Updated" );
            }
#endif
            return change_count;
		}

		public static void CommitChanges( DsnConnection connection, DataSet set )
		{
			connection.BeginTransaction();
			DataSet changes = set.GetChanges();
			foreach( DataTable table in changes.Tables )
			{
				bool valid_commit = false; ;
				foreach( Attribute attr in table.GetType().GetCustomAttributes( false ) )
				{
					if( attr as SQLPersistantTable != null )
					{
						valid_commit = true;
						break;
					}
				}
				if( valid_commit )
					if( table.Rows.Count > 0 )
						CommitChanges( connection, table, true );
			}
			connection.EndTransaction();
		}

		public static void AppendToDatabase( DsnConnection connection, DataSet set )
		{
			connection.BeginTransaction();

			foreach( DataTable table in set.Tables )
			{
				foreach( DataRow row in table.Rows )
					DsnSQLUtil.DoInsertRow( connection, table, row );
			}

			connection.EndTransaction();
		}

		public static void DumpTableErrors( DataSet dataSet )
		{
			foreach( DataTable table in dataSet.Tables )
			{
				if( table.HasErrors )
				{
					Log.log( table.TableName + " is in error..." );
					DataRow[] rows = table.GetErrors();
					for( int i = 0; i < rows.Length; i++ )
					{
						for( int j = 0; j < table.Columns.Count; j++ )
						{
							Log.log( "Row" + rows[i].RowState + "[" + i + "][" + table.Columns[j].ColumnName + "] = " + rows[i][j] + " : " + rows[i].RowError );
						}
					}
				}
			}
		}

        public static void ReloadTable( DsnConnection connection, DataTable table )
        {
            Log.log( "Handle Reloading the table... the database changed, and we have notice that we might want to reload." );
            table.BeginLoadData();
            table.Clear();
            FillDataTable( connection, table, null, null );
			try
			{
				table.EndLoadData();
			}
			catch( Exception e )
			{
				Log.log( "Failed enabling constraints : " + e.Message );
				DumpTableErrors( table.DataSet );
			}
        }


        /// <summary>
        /// Handles string for appropriate sql value quoting assuming "'"
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string EscapeString( string s )
        {
            int n = 0;
            int targetlen = 0;
            while ( n < s.Length )
            {
                if ( s[n] == '\'' )
                    targetlen++;

                n++;
            }
            char[] output = new char[n + targetlen];
            n = 0;

            //result = tmpnamebuf = (TEXTSTR)AllocateEx( targetlen + bloblen + 1 DBG_RELAY );

            int offset = 0;
            while ( n < s.Length )
            {
                if ( s[n] == '\'' )
                    output[offset++] = '\'';

                output[offset++] = s[n];
                n++;
            }
            return new string( output );
        }

        public static bool IsValidString( String s )
        {
            if ( s.Contains( "'" ) )
                return false;
            return true;
        }

		public static String MakeSetSelector( String keyname, List<object> keys )
		{
			String condition = keyname + " in(";
			bool first = true;
			foreach( object o in keys )
			{
				if( !first )
					condition += ",";
				condition += "'" + o.ToString() + "'";
				first = false;
			};
			if( !first )
			{
				condition += ")";
				return condition;
			}
			return null;
		}

		public static String MakeSetSelector( String keyname, List<object> keys, String keyname2, List<object> keys2 )
		{
			String condition = keyname + " in(";
			bool first = true;
			foreach( object o in keys )
			{
				if( !first )
					condition += ",";
				condition += "'" + o.ToString() + "'";
				first = false;
			};
			condition += ")and " + keyname2 + " in(";
			first = true;
			foreach( object o in keys2 )
			{
				if( !first )
					condition += ",";
				condition += "'" + o.ToString() + "'";
				first = false;
			};
			condition += ")";
			return condition;
		}
		public static String MakeSetSelector( String keyname, List<object> keys, String keyname2, List<object> keys2, String keyname3, List<object> keys3 )
		{
			String condition = keyname + " in(";
			bool first = true;
			foreach( object o in keys )
			{
				if( !first )
					condition += ",";
				condition += "'" + o.ToString() + "'";
				first = false;
			};
			condition += ")and " + keyname2 + " in(";
			first = true;
			foreach( object o in keys2 )
			{
				if( !first )
					condition += ",";
				condition += "'" + o.ToString() + "'";
				first = false;
			};
			condition += ")and " + keyname3 + " in(";
			first = true;
			foreach( object o in keys3 )
			{
				if( !first )
					condition += ",";
				condition += "'" + o.ToString() + "'";
				first = false;
			};
			condition += ")";
			return condition;
		}

		public static void DropTable( DsnConnection schedule_dsn, DataTable xDataTable )
		{
			IXDataTable real_table = xDataTable as IXDataTable;
			String name;
				if( real_table != null )
					name = real_table.FullTableName;
				else
					name = xDataTable.Prefix + xDataTable.TableName;
			if( schedule_dsn.DbMode == DsnConnection.ConnectionMode.SQLServer )
			{
				schedule_dsn.KindExecuteNonQuery( "if exists (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME = '"
					+ name + "') drop table " + name + ";" );
			}
			else
			{
				if( real_table != null )
					schedule_dsn.KindExecuteNonQuery( "drop table " + real_table.FullTableName );
				else
					schedule_dsn.KindExecuteNonQuery( "drop table " + xDataTable.Prefix + xDataTable.TableName );
			}
		}
	}
}
