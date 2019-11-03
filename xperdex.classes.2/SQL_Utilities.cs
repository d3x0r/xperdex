using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using xperdex.classes.Types;

namespace xperdex.classes
{
	public class SQL_Utilities
	{


		//----------------------------------------------------------------------

		static bool TextLike( String s1, String s2 )
		{
			return String.Compare( s1, s2, true ) == 0;
		}

		static bool ValidateCreateTable( ref Types.XStringSeg word )
		{

			if( !TextLike( word, "create" ) )
				return false;

			word = word.Next;

			if( TextLike( word, "temporary" ) )
				word = word.Next;
			else if( TextLike( word, "temp" ) )
				word = word.Next;

			if( !TextLike( word, "table" ) )
				return false;

			word = word.Next;
			if( TextLike( word, "if" ) )
			{
				word = word.Next;
				if( TextLike( word, "not" ) )
				{
					word = word.Next;
					if( TextLike( word, "exists" ) )
						word = word.Next;
					else
						return false;
				}
				else
					return false;
			}
			return true;
		}

		//----------------------------------------------------------------------

		static bool GrabName( ref Types.XStringSeg word, out String result, out bool bQuoted )
		{
			String name = null;
			//PTEXT start = word;
			//printf( "word is %s", GetText( *word ) );
			if( TextLike( word, "`" ) )
			{
				XString phrase = new XString();
				//Types.XStringSeg phrase = null;
				bQuoted = true;
				word = word.Next;
				while( word != null && word.ToString()[0] != '`' )
				{
					phrase.Append( word.Clone() );
					word = word.Next;
				}
				// skip one more - end after the last `
				word = word.Next;
				name = phrase.ToString();
			}
			else
			{
				// don't know...
				String next;
				bQuoted = false;
				next = word.Next;
				if( next != null && next[0] == '.' )
				{
					// database and table name...
					word = word.Next;
					word = word.Next;
					name = (String)word;
					word = word.Next;
				}
				else
				{
					if( word.Text == "(" )
					{
						result = null;
						bQuoted = false;
						return true;
					}
					name = (String)word;
					word = word.Next;
				}
			}
			result = name;
			return (result != null) ? true : false;
		}

		//----------------------------------------------------------------------

		static bool GrabType( ref Types.XStringSeg word, out String result )
		{
			if( word != null )
			{
				//int quote = 0;
				//int escape = 0;
				XString type = new XString();
				XStringSeg first_word;
				type.Append( first_word = word.Clone() );
				first_word.Originate();
				word = word.Next;
				if( word && word[0] == '(' )
				{
					while( word && word[0] != ')' )
					{
						type.Append( word.Clone() );
						word = word.Next;
					}
					type.Append( word.Clone() );
					word = word.Next;
				}
				result = type.ToString();
				return true;
			}
			else
				result = null;
			return false;
		}

		//----------------------------------------------------------------------

		static bool GrabExtra( ref Types.XStringSeg word, out String result )
		{
			if( word != null )
			{
				XString type = new XString();
				{
					while( word && ( ( word[0] != ',' ) && ( word[0] != ')' ) ) )
					{
						if( word[0] == ')' )
							break;
						type.Append( word.Clone() );
						word = word.Next;
					}
				}
				if( type )
				{
					type.Originate();
					result = type.ToString();
				}
				else
					result = null;
			}
			else
				result = null;
			return true;
		}

		static void GrabKeyColumns( ref Types.XStringSeg word, ref List<String> columns )
		{
			if( ( word != null ) && word[0] == '(' )
			{
				do
				{
					String result;
					bool quoted;
					word = word.Next;
					GrabName( ref word, out result, out quoted );
					columns.Add( result );
				}
				while( word && word[0] != ')' );
				word = word.Next;
			}
		}

		//----------------------------------------------------------------------

		static void AddIndexKey( XDataTable<DataRow> table, ref Types.XStringSeg word, bool has_name, bool primary, bool unique )
		{
	//table.Columns.
			XDataTableKey key = new XDataTableKey();

			//key.null = null;
			key.primary = primary;
			key.unique = unique;
			bool quoted = false;
			if( has_name )
				GrabName( ref word, out key.name, out quoted  );
			//else
			//	table.keys.key[table.keys.count-1].name = null;
			//table.keys.key[table.keys.count-1].colnames = New( CTEXTSTR );
			//table.keys.key[table.keys.count-1].colnames[0] = null;

			// 5.0 database this occurs before the columns
			if( word == "USING" )
			{
				word = word.Next;
				if( word == "BTREE" )
					word = word.Next;
			}
			GrabKeyColumns( ref word, ref key.columns );
			// 5.5 database this occurs after the columns of index
			if( word == "USING" )
			{
				word = word.Next;
				if( word == "BTREE" )
					word = word.Next;
			}
			table.keys.Add( key );

		}

		//----------------------------------------------------------------------

		static void SetMaxLength( String word, DataColumn dc )
		{
			if( dc.DataType == typeof( String ) )
			{
				if( String.Compare( word, 0, "varchar", 0, 7 ) == 0 )
				{
					int start = word.IndexOf( '(' );
					if( start > 0 )
					{
						start++;
						while( word[start] == ' ' )
							start++;
						int end = word.IndexOf( ')' );
						while( ( end > start ) && ( word[end - 1] == ' ' ) )
							end--;
						if( end > start )
							dc.MaxLength = Convert.ToInt32( word.Substring( start, end - start ) );
					}
				}
			}
		}

		static Type GetType( String word )
		{
			String precision = null;
			if( word.Contains( "(" ) )
			{
				precision = word.Substring( word.IndexOf( "(" ) );
				word = word.Substring( 0, word.IndexOf( "(" ) );
			}

			if( String.Compare( word, 0, "varchar", 0, 7 ) == 0 )
			{
				return typeof( String );
			}
			else if( (String.Compare(word, 0, "text", 0, 4) == 0)
				|| ( String.Compare( word, 0, "tinytext", 0, 8 ) == 0 )
				|| ( String.Compare( word, 0, "mediumtext", 0, 10 ) == 0 ) )
			{
				return typeof( String );
			}
			else if (String.Compare(word, 0, "enum", 0, 4) == 0)
			{
				return typeof(int);
			}
			else if (String.Compare(word, 0, "timestamp", 0, 9) == 0)
			{
				return typeof( DateTime );
			}
			else switch( word )
			{
            case "bigint":
                return typeof( long );
			case "tinyint":
				if( precision == "(1)" )
					return typeof( bool );
				else
					return typeof( byte );
			case "DOUBLE":
			case "Double":
			case "double":
				return typeof( double );
			case "date":
				return typeof( DateTime );
            case "smallint":
				switch( precision )
				{
				case "(6)":
				default:
					return typeof( Int16 );
				}
			case "CHAR":
			case "char":
			case "Char":
				switch( precision )
				{
				case "(36)":
				case "(40)":
					return typeof( Guid );
				default:
					return typeof( string );
				}
			case "binary":
			case "varbinary":
				switch( precision )
				{
				case "(16)":
					return typeof( Guid );
				default:
					return typeof( byte[] );
				}
			case "INTEGER":
			case "integer":
			//case "int":
			case "int":
				switch( precision )
				{
				case "(1)":
					return typeof( bool );
				case "(3)":
				case "(4)":
					return typeof( byte );
				case "int(10)":
					return typeof( UInt32 );
				case "(11)":
				default:
					return typeof( int );
				}
			case "decimal":
				return typeof( decimal );
			case "timestamp":
			case "datetime":
				return typeof( DateTime );
			case "blob":
				return typeof( byte[] );
			default:
				Log.log( "No type found for ["+word+"]" );
				throw new Exception( "No type found for ["+word+"]" );
			}
		}

		static bool GetTableColumns( XDataTable<DataRow> table, ref Types.XStringSeg word )
		{
			if( word == null )
				return false;
			//DebugBreak();
			if( word[0] != '(' )
			{
				//PTEXT line;
				Log.log( "Failed to find columns... extra data between table name and columns...." );
				Log.log( "Failed at "+ word );
				return false;
			}
			while( word != null && word[0] != ')' )
			{
				String name = null;
				String type = null;
				String extra = null;
				bool bQuoted;
				word = word.Next;
				while( word.Text.Length == 0 )
					word = word.Next;

				//if( word && GetText( *word )[0] == ',' )
				//	word = NEXTLINE( *word );
				if( !GrabName( ref word, out name, out bQuoted ) )
				{
					Log.log( "Failed column parsing..." );
				}
				else
				{
					if( !bQuoted )
					{
						if( TextLike( name, ")" ) )
						{
							// close of the SQL columns.
							break;
						}
						else if( TextLike( name, "CONSTRAINT" ) )
						{
							XDataTable<DataRow>.XDataTableForeignKey fk = new XDataTable<DataRow>.XDataTableForeignKey();
							bool con_quote;
							if( !TextLike( word, "FOREIGN" ) )
							{
								GrabName( ref word, out fk.keyname, out con_quote );
							}
							if( TextLike( word, "FOREIGN" ) )
							{
								word = word.Next;
								if( TextLike( word, "KEY" ) )
								{
									word = word.Next;
									if( word != "(" )
									{
										bool key_quoted;
										GrabName( ref word, out fk.child_indexname, out key_quoted );
										// no name
									}
									if( word == "(" )
									{
										GrabKeyColumns( ref word, ref fk.child_columns );
									}
									else
										Log.log( "parse failure." );
								}
							}
							if( TextLike( word, "REFERENCES" ) )
							{
								word = word.Next;
								{
									bool key_quoted;
									GrabName( ref word, out fk.parent_table, out key_quoted );
								}
								if( word == "(" )
								{
									GrabKeyColumns( ref word, ref fk.parent_columns );
								}
								else
									Log.log( "parse failure." );
							}
							while( TextLike( word, "ON" ) )
							{
								word = word.Next;
								if( TextLike( word, "DELETE" ) )
								{
									word = word.Next;
									if( String.Compare( word, "CASCADE", true ) == 0 )
									{
										word = word.Next;
										fk.fk_DeleteRule = Rule.Cascade;
									}
									else if( String.Compare( word, "SET", true ) == 0 )
									{
										word = word.Next;
										if( String.Compare( word, "NULL", true ) == 0 )
										{
											word = word.Next;

											fk.fk_DeleteRule = Rule.SetNull;
										}
										if( String.Compare( word, "DEFAULT", true ) == 0 )
										{
											word = word.Next;
											fk.fk_DeleteRule = Rule.SetDefault;
										}
									}
									if( String.Compare( word, "RESTRICT", true ) == 0 )
									{
										word = word.Next;
										//fk.fk.DeleteRule = Rule.Restrict;
									}
									else if( String.Compare( word, "NO", true ) == 0 )
									{
										word = word.Next;
										if( String.Compare( word, "ACTION", true ) == 0 )
										{
											word = word.Next;
											fk.fk_DeleteRule = Rule.None;
										}
									}
								}

								if( TextLike( word, "UPDATE" ) )
								{
									word = word.Next;
									if( String.Compare( word, "CASCADE", true ) == 0 )
									{
										word = word.Next;
										fk.fk_UpdateRule = Rule.Cascade;
									}
									else if( String.Compare( word, "SET", true ) == 0 )
									{
										word = word.Next;
										if( String.Compare( word, "NULL", true ) == 0 )
										{
											word = word.Next;
											fk.fk_UpdateRule = Rule.SetNull;
										}
										if( String.Compare( word, "DEFAULT", true ) == 0 )
										{
											word = word.Next;
											fk.fk_UpdateRule = Rule.SetDefault;
										}
									}
									if( String.Compare( word, "RESTRICT", true ) == 0 )
									{
										word = word.Next;
										//fk.fk.UpdateRule = Rule.Restrict;
									}
									else if( String.Compare( word, "NO", true ) == 0 )
									{
										word = word.Next;
										if( String.Compare( word, "ACTION", true ) == 0 )
										{
											word = word.Next;
											fk.fk_UpdateRule = Rule.None;
										}
									}
								}
							}
							table.foreign.Add( fk );
						}
						else if( TextLike( name, "PRIMARY" ) )
						{
							if( TextLike( (String)word, "KEY" ) )
							{
								word = word.Next;
								if( TextLike( (String)word, "USING" ) )
								{
									word = word.Next;
									if( TextLike( (String)word, "BTREE" ) )
									{
										word = word.Next;
									}
								}
								AddIndexKey( table, ref word, false, true, false );
							}
							else
							{
								Log.log( "PRIMARY keyword without KEY keyword is invalid." );
							}
						}
						else if( TextLike( name, "UNIQUE" ) )
						{
							// these are optional words... so skip them...
							if( ( TextLike( (String)word, "KEY" ) )
								|| ( TextLike( (String)word, "INDEX" ) ) )
							{
								// skip this word.
								word = word.Next;
							}
							AddIndexKey( table, ref word, true, false, true );
						}
						else if( ( TextLike( name, "INDEX" ) )
							|| TextLike( name, "BTREE" )
							|| ( TextLike( name, "KEY" ) ) )
						{
							AddIndexKey( table, ref word, true, false, false );
						}
						else
						{
							GrabType( ref word, out type );
							GrabExtra( ref word, out extra );
							DataColumn dc = table.Columns.Add( name, GetType(type) );
							SetMaxLength( type, dc );
							if( extra != null && extra.Contains( "auto_increment" ) )
							{
								dc.AutoIncrement = true;
								dc.AutoIncrementSeed = 1;
								dc.AllowDBNull = false;
							}

							//table.fields.count++;
							//table.fields.field = Renew( FIELD, table.fields.field, table.fields.count + 1 );
							//table.fields.field[table.fields.count - 1].name = name;
							//table.fields.field[table.fields.count - 1].type = type;
							//table.fields.field[table.fields.count - 1].extra = extra;
							//table.fields.field[table.fields.count - 1].previous_names[0] = null;

						}
					}
					else
					{
						GrabType( ref word, out type );
						GrabExtra( ref word, out extra );
						DataColumn dc = table.Columns.Add( name, GetType( type ) );
						SetMaxLength( name, dc );
						if( extra != null && extra.Contains( "auto_increment" ) )
						{
							dc.AutoIncrement = true;
							dc.AutoIncrementSeed = 1;
							dc.AllowDBNull = false;
						}
						//table.fields.count++;
						//table.fields.field = Renew( FIELD, table.fields.field, table.fields.count + 1 );
						//table.fields.field[table.fields.count - 1].name = name;
						//table.fields.field[table.fields.count - 1].type = type;
						//table.fields.field[table.fields.count - 1].extra = extra;
						//table.fields.field[table.fields.count - 1].previous_names[0] = null;
					}
				}
			}

			return true;
		}

		//----------------------------------------------------------------------

		static bool GetTableExtra( XDataTable<DataRow> table, ref Types.XStringSeg word )
		{
			// prior code ended us on the ')'

			word = word.Next;
			if( word != null )
			{
				table.extra = word.ToString();
				return true;
			}
			return false;
		}

		static void log( DataTable table )
		{
			{
#if adsfasdf
				if( table != null )
				{
					int n;
					Log.log( "" );
					Log.log( "//--------------------------------------------------------------------------" );
					Log.log( "//"+ table.TableName +"");
					Log.log( "// Total number of fields = " + table.Columns.Count + "" );
					//Log.log( "// Total number of keys = %d\n", table.keys.count );
					Log.log( "//--------------------------------------------------------------------------" );
					Log.log( "" );
#if asdasdf
					Log.log( "FIELD %s_fields[] = {\n", table.name );
					for( n = 0; n < table.fields.count; n++ )
						Log.log( "\t%s{%s%s%s, %s%s%s, %s%s%s }\n"
							, n ? ", " : ""
							, table.fields.field[n].name ? "\"" : ""
							, table.fields.field[n].name ? table.fields.field[n].name : "null"
							, table.fields.field[n].name ? "\"" : ""
							, table.fields.field[n].type ? "\"" : ""
							, table.fields.field[n].type ? table.fields.field[n].type : "null"
							, table.fields.field[n].type ? "\"" : ""
							, table.fields.field[n].extra ? "\"" : ""
							, table.fields.field[n].extra ? table.fields.field[n].extra : "null"
							, table.fields.field[n].extra ? "\"" : ""
						);
					Log.log( "};\n" );
					Log.log( "\n" );
					if( table.keys.count )
					{
						Log.log( "DB_KEY_DEF %s_keys[] = { \n", table.name );
						for( n = 0; n < table.keys.count; n++ )
						{
							int m;
							Log.log( "#ifdef __cplusplus\n" );
							Log.log( "\t%srequired_key_def( %d, %d, %s%s%s, \"%s\" )\n"
									 , n ? ", " : ""
									 , table.keys.key[n].flags.bPrimary
									 , table.keys.key[n].flags.bUnique
									 , table.keys.key[n].name ? "\"" : ""
									 , table.keys.key[n].name ? table.keys.key[n].name : "null"
									 , table.keys.key[n].name ? "\"" : ""
									 , table.keys.key[n].colnames[0] );
							if( table.keys.key[n].colnames[1] )
								Log.log( ", ... columns are short this is an error.\n" );
							Log.log( "#else\n" );
							Log.log( "\t%s{ {%d,%d}, %s%s%s, { "
									 , n ? ", " : ""
									 , table.keys.key[n].flags.bPrimary
									 , table.keys.key[n].flags.bUnique
									 , table.keys.key[n].name ? "\"" : ""
									 , table.keys.key[n].name ? table.keys.key[n].name : "null"
									 , table.keys.key[n].name ? "\"" : ""
									 );
							for( m = 0; table.keys.key[n].colnames[m]; m++ )
								Log.log( "%s\"%s\""
										 , m ? ", " : ""
										 , table.keys.key[n].colnames[m] );
							Log.log( " } }\n" );
							Log.log( "#endif\n" );
						}
						Log.log( "};\n" );
						Log.log( "\n" );
					}
					Log.log( "\n" );
					Log.log( "TABLE %s = { \"%s\" \n", table.name, table.name );
					Log.log( "	 , FIELDS( %s_fields )\n", table.name );
					if( table.keys.count )
						Log.log( "	 , TABLE_KEYS( %s_keys )\n", table.name );
					else
						Log.log( "	 , { 0, null }\n" );
					Log.log( "	, { 0 }\n" );
					Log.log( "	, null\n" );
					Log.log( "	, null\n" );
					Log.log( "	,null\n" );
					Log.log( "};\n" );
					Log.log( "\n" );
#endif
				}
				else
				{
					Log.log( "//--------------------------------------------------------------------------\n" );
					Log.log( "// No Table\n" );
					Log.log( "//--------------------------------------------------------------------------\n" );
				}
#endif
			}
		}

		//----------------------------------------------------------------------

		static XDataTable<DataRow> GetFieldsInSQLEx( String cmd, bool writestate )
		{
			StringBuilder tmp;
			XStringSeg pWord;
			XDataTable<DataRow> DataTable = new XDataTable<DataRow>();

			//Datatable.fields.field = New( FIELD );
			DataTable.dynamic = true;
			//Datatable.keys.key = New( DB_KEY_DEF );
			//tmp = SegCreateFromText( cmd );
			// tmp will become parsed... the first segment is
			// not released, it is merely truncated.
			tmp = new StringBuilder( cmd );
			{
				// but first, go through, and remove carriage returns... which even
				// if a delimieter need to be considered more like spaces...
				int n, m;
				//TEXTCHAR* str = GetText( tmp );
				for( n = 0, m = tmp.Length; n < m; n++ )
					if( tmp[n] == '\n' )
						tmp[n] = ' ';
			}
			XString x = new XString( tmp.ToString(), "\'\"\\({[<>]}):@%/,;!?=*&$^~#`", " \t\n\r", true, true );

			if( x.Count > 0 )
			{
				pWord = x[0];

				if( ValidateCreateTable( ref pWord ) )
				{
					String name;
					bool quoted;
					if( !GrabName( ref pWord, out name, out quoted ) )
					{
						DataTable = null;
					}
					else
					{
						DataTable.TableName = name;
						if( !GetTableColumns( DataTable, ref pWord ) )
						{
							DataTable = null;
						}
						GetTableExtra( DataTable, ref pWord );
					}
				}
				else
				{
					DataTable = null;
				}
			}
			//if( writestate )
				log( DataTable );
			return DataTable;
		}


		public static XDataTable<DataRow> CreateTable( String create_statement )
		{
			//DataTable result = new DataTable();
			//xperdex.classes.Types.XString statement = new xperdex.classes.Types.XString( create_statement );
			return GetFieldsInSQLEx( create_statement, false );
		}

		static String GetVarChar( DataColumn col )
		{
			if( col.MaxLength > 0 )
			{
				return "varchar(" + col.MaxLength + ") default ''";
			}
			else
				return "varchar(100) default ''";
		}

		public static String GetColumnDef( DsnConnection.ConnectionMode mode, DsnConnection.ConnectionFlavor flavor, DataColumn col )
		{
            object o = col.ExtendedProperties["Extra Type"];
            String extra_type_info = ( o == null ? "" : o.ToString() );
			string ColTypeString;
			string default_val = ( col.DefaultValue == DBNull.Value ) ? null : col.DefaultValue.ToString();
			bool timecol = false;
			switch( mode )
			{
			case DsnConnection.ConnectionMode.MySqlNative:
			case DsnConnection.ConnectionMode.Odbc:
				if( ( col.DataType == typeof( DateTime ) && extra_type_info == "createstamp" )
					|| ( col.DataType == typeof( DateTime ) && col.Namespace == "createstamp" ) )
				{
					timecol = true;
					default_val = "CURRENT_TIMESTAMP";
				}
				ColTypeString = ( ( col.DataType == typeof( string ) && extra_type_info == "text" )
					? "text"
					: ( col.DataType == typeof( string ) && col.Namespace == "text" )
					? "text"
					: ( col.DataType == typeof( Guid ) )
					? "char(36)"
					: ( col.DataType == typeof( Money ) )
					? "decimal(18,2)"
					: ( col.DataType == typeof( decimal ) )
					? "decimal"
					: ( col.DataType == typeof( string ) )
					? GetVarChar( col )
					: ( col.DataType == typeof( Color ) )
					? "bigint"
					: ( col.DataType == typeof( long ) )
					? "bigint"
					: ( col.DataType == typeof( bool ) )
					? ( ( flavor == DsnConnection.ConnectionFlavor.SQLServer ) ? "bit" : "tinyint(1)" )
					: ( col.DataType == typeof( decimal ) )
					? "decimal(11,2)"
					: ( col.DataType == typeof( double ) )
					? "double"
					: ( col.DataType == typeof( TimeSpan ) )
					? ( ( flavor == DsnConnection.ConnectionFlavor.SQLServer ) ? "datetime" : "time default," )
					: ( col.DataType == typeof( DateTime ) && extra_type_info == "time" )
					? "timestamp"
					: ( col.DataType == typeof( DateTime ) && col.Namespace == "time" )
					? "timestamp"
					: ( col.DataType == typeof( DateTime ) && extra_type_info == "date" )
					? ( ( flavor == DsnConnection.ConnectionFlavor.SQLServer ) ? "datetime" : "date" )
					: ( col.DataType == typeof( DateTime ) && col.Namespace == "date" )
					? ( ( flavor == DsnConnection.ConnectionFlavor.SQLServer ) ? "datetime" : "date" )
					: ( col.DataType == typeof( DateTime ) && extra_type_info == "createstamp" )
					? "timestamp default CURRENT_TIMESTAMP"
					: ( col.DataType == typeof( DateTime ) && col.Namespace == "createstamp" )
					? "timestamp default CURRENT_TIMESTAMP"
					: ( col.DataType == typeof( DateTime ) )
					? "datetime"
					: ( col.DataType == typeof( byte[] ) )
					? ( ( flavor == DsnConnection.ConnectionFlavor.SQLServer ) ? "varbinary(max) default" : "blob default NULL" )
					: ( col.AutoIncrement
					? ( ( flavor == DsnConnection.ConnectionFlavor.SQLServer ) ? "int IDENTITY PRIMARY KEY" : "int(11) auto_increment" )
					: ( col.ColumnName.EndsWith( "_id" )
					? ( ( flavor == DsnConnection.ConnectionFlavor.SQLServer ) ? "int" : "int(11)" )
					: ( ( flavor == DsnConnection.ConnectionFlavor.SQLServer ) ? "int" : "int(11)" ) ) ) )
					;

				if( default_val == null )
				{
					ColTypeString += (col.AllowDBNull)?" NULL":" NOT NULL";
                    return ColTypeString;
				}
                else
                {
					if( !timecol )
						if( col.DataType == typeof( bool ) )
							return ColTypeString + " default '" + Convert.ToInt32( col.DefaultValue ).ToString() + "'";
						else
							return ColTypeString + " default '" + default_val + "'";
					return ColTypeString;
                }
			case DsnConnection.ConnectionMode.SQLServer:
				if( ( col.DataType == typeof( DateTime ) && extra_type_info == "createstamp" )
					|| ( col.DataType == typeof( DateTime ) && col.Namespace == "createstamp" ) )
				{
					timecol = true;
					default_val = "CURRENT_TIMESTAMP";
				}
				ColTypeString = ( ( col.DataType == typeof( string ) && extra_type_info == "text" )
					? "text"
					: ( col.DataType == typeof( string ) && col.Namespace == "text" )
					? "text"
					: ( col.DataType == typeof( Guid ) )
					? "UNIQUEIDENTIFIER"
					: ( col.DataType == typeof( Money ) )
					? "decimal(18,2)"
					: ( col.DataType == typeof( decimal ) )
					? "decimal(18,4)"
					: ( col.DataType == typeof( string ) )
					? GetVarChar( col )
					: ( col.DataType == typeof( Color ) )
					? "bigint"
					: ( col.DataType == typeof( long ) )
					? "bigint"
					: ( col.DataType == typeof( bool ) )
					? ( ( flavor == DsnConnection.ConnectionFlavor.SQLServer ) ? "bit" : "tinyint(1)" )
					: ( col.DataType == typeof( decimal ) )
					? "decimal(11,2)"
					: ( col.DataType == typeof( double ) )
					? "double"
					: ( col.DataType == typeof( TimeSpan ) )
					? ( ( flavor == DsnConnection.ConnectionFlavor.SQLServer ) ? "datetime" : "time default," )
					: ( col.DataType == typeof( DateTime ) && extra_type_info == "time" )
					? "timestamp"
					: ( col.DataType == typeof( DateTime ) && col.Namespace == "time" )
					? "timestamp"
					: ( col.DataType == typeof( DateTime ) && extra_type_info == "date" )
					? ( ( flavor == DsnConnection.ConnectionFlavor.SQLServer ) ? "datetime" : "date" )
					: ( col.DataType == typeof( DateTime ) && col.Namespace == "date" )
					? ( ( flavor == DsnConnection.ConnectionFlavor.SQLServer ) ? "datetime" : "date" )
					: ( col.DataType == typeof( DateTime ) && extra_type_info == "createstamp" )
					? "timestamp default CURRENT_TIMESTAMP"
					: ( col.DataType == typeof( DateTime ) && col.Namespace == "createstamp" )
					? "timestamp default CURRENT_TIMESTAMP"
					: ( col.DataType == typeof( DateTime ) )
					? "datetime"
					: ( col.DataType == typeof( byte[] ) )
					? ( ( flavor == DsnConnection.ConnectionFlavor.SQLServer ) ? "varbinary(max) default" : "blob default NULL" )
					: ( col.AutoIncrement
					? ( ( flavor == DsnConnection.ConnectionFlavor.SQLServer ) ? "int IDENTITY PRIMARY KEY" : "int(11) auto_increment" )
					: ( col.ColumnName.EndsWith( "_id" )
					? ( ( flavor == DsnConnection.ConnectionFlavor.SQLServer ) ? "int" : "int(11)" )
					: ( ( flavor == DsnConnection.ConnectionFlavor.SQLServer ) ? "int" : "int(11)" ) ) ) )
					;

				if( default_val == null )
				{
					ColTypeString += ( col.AllowDBNull ) ? " NULL" : " NOT NULL";
					return ColTypeString;
				}
				else
				{
					if( !timecol )
						if( col.DataType == typeof( bool ) )
							return ColTypeString + " default '" + Convert.ToInt32( col.DefaultValue ).ToString() + "'";
						else
							return ColTypeString + " default '" + default_val + "'";
					return ColTypeString;
				}

			case DsnConnection.ConnectionMode.Sqlite:
				return
                    ( ( col.DataType == typeof( string ) && extra_type_info == "text" )
                    ? "text NOT NULL default ''"
					: ( col.DataType == typeof( string ) && col.Namespace == "text" )
					? "text NOT NULL default ''"
					: ( col.DataType == typeof( Guid ) )
					? "char(36)"
					: ( col.DataType == typeof( Money ) )
					? "decimal(18,2)"
					: ( col.DataType == typeof( string ) )
					? GetVarChar( col )
					: ( col.DataType == typeof( bool ) )
					? "tinyint(1) NOT NULL default 0"
					: ( col.DataType == typeof( decimal ) )
					? "decimal(18,4) default 0.00"
					: ( col.DataType == typeof( double ) )
					? "double not NULL default 0.0"
					: ( col.DataType == typeof( TimeSpan ) )
					? "time default NULL,"
                    : ( col.DataType == typeof( DateTime ) && extra_type_info == "time" )
                    ? "timestamp default '00-00-00 00:00:00'"
                    : ( col.DataType == typeof( DateTime ) && extra_type_info == "date" )
                    ? "date default '0000-00-00'"
                    : ( col.DataType == typeof( DateTime ) && extra_type_info == "createstamp" )
                    ? "timestamp NOT NULL default CURRENT_TIMESTAMP"
                    : ( col.DataType == typeof( DateTime ) && col.Namespace == "time" )
					? "timestamp default '00-00-00 00:00:00'"
					: ( col.DataType == typeof( DateTime ) && col.Namespace == "date" )
					? "date default '0000-00-00'"
					: ( col.DataType == typeof( DateTime ) && col.Namespace == "createstamp" )
					? "timestamp NOT NULL default CURRENT_TIMESTAMP"
					: ( col.DataType == typeof( DateTime ) )
					? "datetime default '00-00-00 00:00:00'"
					: ( col.DataType == typeof( byte[] ) )
					? "blob default NULL"
					: ( col.AutoIncrement
					? "int(11) auto_increment"
					: ( col.ColumnName.EndsWith( "_id" )
					? "int(11)"
					: "int(11) NOT NULL default '0'" ) ) );
			default:
				throw new Exception( "unsupported get column def" );
				//return null;
			}
		}
	}
}
