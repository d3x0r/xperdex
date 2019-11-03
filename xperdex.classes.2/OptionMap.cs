using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace xperdex.classes
{
	public class OptionMap : List<OptionEntry>
	{
		[MySQLPersistantTable]
		public static string Prefix = "option3_";
		internal static string DefaultOptionDatabase = INI.Default[Options.ProgramName + "/Options"]["Default option DSN", Environment.GetFolderPath( Environment.SpecialFolder.CommonApplicationData ) + "/xperdex/option.db"];
		public class OptionValues : MySQLDataTable
		{
			public static new string TableName = "values";

			public OptionValues()
			{
				base.TableName = TableName;
				this.Prefix = OptionMap.Prefix;

				DataColumn dc = this.Columns.Add( "option_id", AutoKeyType );
				dc.AllowDBNull = false;
				this.PrimaryKey = new DataColumn[] { dc };
				this.auto_id = dc;
				this.Columns.Add( "string", typeof( String ) );
			}
		}

		[MySQLPersistantTable]
		public class OptionMapTable : MySQLDataTable
		{
			public static new string TableName = "map";

			public OptionMapTable()
			{
				base.TableName = TableName;
				this.Prefix = OptionMap.Prefix;
				//AddDefaultColumns( false, true, false );
				DataColumn dc = this.Columns.Add( "option_id", AutoKeyType );
				dc.AllowDBNull = false;
				this.PrimaryKey = new DataColumn[] { dc };
				this.auto_id = dc;
				this.Columns.Add( "parent_option_id", AutoKeyType );
				this.Columns.Add( "name_id", AutoKeyType );
				this.Columns.Add( "Description", typeof( String ) );
			}
		}

		static object Lock = new object();
		class OptionNames : MySQLNameTable
		{
			new static readonly string NameColumn = "name";
			public OptionNames()
			{
			}
			public OptionNames( DsnConnection dsn )
				: base( dsn, OptionMap.Prefix, NameColumn, true, true )
			{
			}
		}
		class OptionNamesNoDB : MySQLNameTable
		{
			new static readonly string NameColumn = "name";

			public OptionNamesNoDB()
				: base( null, OptionMap.Prefix, NameColumn, true, false )
			{
			}
		}


		/// <summary>
		/// this is set when the database connection fails, falls back to INI file.
		/// </summary>
		//bool _fallback_ini;

		// To not load option.db settings
		bool _fallback_ini = true;

		internal bool fallback_ini
		{
			get
			{
				return root._fallback_ini;
			}
			set
			{
				root._fallback_ini = value;
			}
		}
		//MySQLNameTable _names;
#if asdfsdf
		/// <summary>
		/// This returns a MySQLNameTable so that it has name lookup functions, but the user need not know this specific type of NameTable.
		/// </summary>
		internal MySQLNameTable names
		{
			get
			{
				if( _names == null )
				{
					if( parent != null )
						return parent.section.names;
					if( fallback_ini )
						_names = new OptionNamesNoDB();
					else
					{
						try
						{
							_names = new OptionNames( db );
						}
						catch
						{
							_names = new OptionNamesNoDB();
							fallback_ini = true;
						}
					}
				}
				return _names;
			}
		}
#endif
		OptionMapDataset4
		//OptionMapDataset
			ds_root;
		internal OptionMapDataset4 ds
		{
			get
			{
				if( this.root.ds_root == null )
				{
					this.root.ds_root = new OptionMapDataset4();
					//this.root.ds_root.Tables["map"].
				}
				return this.root.ds_root;
			}
		}
		


	 void InstanceDataSet()
	{
		//OptionMapDatasetTableAdapters.option2_nameTableAdapter da = new OptionMapDatasetTableAdapters.option2_nameTableAdapter();
		//da.Fill( ds.option2_name );
		// ds.
	}


		DataTable option_map;
		internal Type option_map_key_type;
		//static bool tables_setup;

		// To not load option.db settings
		bool tables_setup = false;

		bool isTableSetup
		{
			get
			{
				if( ( parent != null ) && root.tables_setup )
					return true;
				return tables_setup;
			}
		}

		/// <summary>
		/// return the root option map, contains useful things like the DB dsn, and fallback_ini 
		/// </summary>
		internal OptionMap root
		{
			get
			{
				if( parent != null )
					return parent.section.root;
				return this;
			}
		}

		void SetupTables()
		{
			if( !isTableSetup )
			{
				fallback_ini = root.fallback_ini;
				if( fallback_ini )
				{
					//tables_setup = true;
					return;
				}

				DataSetConnection dsc = new DataSetConnection( ds );
				dsc.Create( db );
				//DsnSQLUtil.MatchCreate( db, ds );
				option_map = ds.map;
				option_map_key_type = option_map.Columns["option_id"].DataType;
				ds.Fill(db);

                foreach( DataRow row in ds.map.Rows )
                {
                    DataRow name = row.GetParentRow( ds.Relations["FK_name_map"] );
                    object ID;
                    OptionEntry opt = new OptionEntry( this
                        , ID = row[ds.map.option_idColumn]
                        , name[ds.name.nameColumn].ToString()
                        , row.GetChildRows( "FK_option_name" ) );
                    opt.m_description = row[ds.map.descriptionColumn].ToString();
                    this.Add( opt );
                }
#if no_dataset
				MySQLDataTable tmp;

				tmp = new OptionValues();
				DsnSQLUtil.MatchCreate( db, tmp );

				option_map = tmp = new OptionMapTable();
				option_map_key_type = option_map.Columns["option_id"].DataType;
				DsnSQLUtil.MatchCreate( db, tmp );
#endif

				DsnConnection use_db = db;
				if( use_db != null )
				{
					if( fallback_ini )
					{
						// is there already a structure to this?  
						// do we have to erase everything and reload?
						// or transpose into the database?
						//Log.log( "do something here?" );
						fallback_ini = false;
					}
					//root._names = new OptionNames( db );
					tables_setup = true;
				}
				else
					fallback_ini = true;
			}
		}

		bool read_branch;  // indicates if we have read the branch
		// Option_id
		internal object ID;
		 DsnConnection _db;
		internal OptionEntry parent;
		internal DsnConnection db
		{
			get
			{
				if( _db == null )
				{
					if( parent != null )
						return root._db;
					try
					{
						// since INI's path is also this same location of CAD/xperdex ... c:/programdata/
						//  this path will exist, and we can avoide checking it.... otherwise
						//  we should get a common way to get even this option, such that it will
						//  exist.
						//string Default = INI.Default[Options.ProgramName+"/Options"]["Default option DSN",Environment.GetFolderPath( Environment.SpecialFolder.CommonApplicationData ) + "/xperdex/option.db"];
						_db = new DsnConnection( DefaultOptionDatabase );// StaticDsnConnection.dsn;
                        _db.disable_logging = false;
					}
					catch
					{
						fallback_ini = true;
						return null;
					}
				}
				return _db;
			}
			set
			{
			}
		}


		internal void ReadBranch()
		{
			// Read Tree....
			SetupTables();
			if( !fallback_ini && !read_branch  && db != null )
			{
				DataRow[] rows = ds.LoadMore( db, this.ID );

				foreach( DataRow row in rows )
				{
					DataRow name = row.GetParentRow( ds.Relations["FK_name_map"] );
					object ID;
					OptionEntry opt = new OptionEntry( this
						, ID = row[ds.map.option_idColumn]
						, name[ds.name.nameColumn].ToString()
						, row.GetChildRows( "FK_option_name" ) );
					opt.m_description = row[ds.map.descriptionColumn].ToString();
					this.Add( opt );
				}
				read_branch = true;
				return;
#if asdfasdf
				DbDataReader r = db.KindExecuteReader( "select name,option_id,description from "+Prefix+"map join "+Prefix+"name on "+Prefix+"map.name_id="+Prefix+"name.name_id where parent_option_id='" + this.ID + "'" );

				if( r != null )
				{
					if( r.HasRows )
					{
						while( r.Read() )
						{
							OptionEntry opt = new OptionEntry( this
								, r.GetString( 0 )
								, new Guid( r.GetString( 1 ) ) );
                            String s = r.GetDataTypeName(2);
                            Object o = r.GetValue( 2 );
                            if( o == DBNull.Value )
                                opt.m_description="";
                            else
							    opt.m_description = r.GetString( 2 );
							this.Add( opt );
						}
					}
				}
				db.EndReader( r );
				read_branch = true;
#endif
			}
		}

		// localize constructors...
		internal OptionMap()
		{
			this.fallback_ini = false;
			SetupTables();
			this.read_branch = true;
			if( root.option_map_key_type == typeof( Guid ) )
				ID = Guid.Empty;
			else
				ID = (int)0;
			ReadBranch();
		}

		/// <summary>
		/// provides the database conneciton also.
		/// </summary>
		/// <param name="db"></param>
		internal OptionMap( DsnConnection db )
		{
			this._db = db;
            if( db!= null )
            db.disable_logging = false;
			this.fallback_ini = false;
			SetupTables();
			this.read_branch = true;
			// don't know the type until we create the table storage
			if( root.option_map_key_type == typeof( Guid ) )
				ID = Guid.Empty;
			else
				ID = (int)0;
			ReadBranch();
		}


		/// <summary>
		/// provides the database conneciton also.
		/// </summary>
		/// <param name="db"></param>
		//internal OptionMap( DsnConnection db, long option_id )
		//{
		//	this.ID = option_id;
		//	this._db = db;
		//	ReadBranch();
		//}

		/// <summary>
		/// provides the database conneciton also.
		/// </summary>
		/// <param name="db"></param>
		internal OptionMap( OptionEntry parent )
		{
			// this isn't rally parent... it's really 'this option'
			if( root.option_map_key_type == typeof( Guid ) )
				ID = Guid.Empty;
			else
				ID = (int)0;
			this.parent = parent;
		}
		/// <summary>
		/// provides the database conneciton also.
		/// </summary>
		/// <param name="db"></param>
		internal OptionMap( OptionEntry parent, object option_id )
		{
			ID = option_id;
			this.parent = parent;
		}

		public OptionEntry this[string sectionName, string DefaultValue, string Description]
		{
			get
			{
				lock( Lock )
				{
					ReadBranch();

					if( OptionEntry.CheckIsPath( sectionName ) )
					{
						String here;
						String there;
						OptionEntry.SplitPath( sectionName, out here, out there );
						foreach( OptionEntry section in this )
							if( String.Compare( section.ToString(), here, true ) == 0 )
								return section[there, DefaultValue, Description];
						OptionEntry new_section = new OptionEntry( this, here, Description );
						if( DefaultValue != null )
							new_section.Value = DefaultValue;
						this.Add( new_section );
						return new_section[there, DefaultValue, Description];
					}
					else
					{

						foreach( OptionEntry section in this )
							if( String.Compare( section.ToString(), sectionName, true ) == 0 )
								return section;
						OptionEntry new_section = new OptionEntry( this, sectionName, Description );

						if( DefaultValue != null )
							new_section.Value = DefaultValue;
						this.Add( new_section );
						return new_section;
					}
				}
			}
		}
		public OptionEntry this[string sectionName, string DefaultValue ]
		{
			get
			{
				return this[sectionName, DefaultValue, null];
			}
		}
		public OptionEntry this[string sectionName, int DefaultValue]
		{
			get
			{
				return this[sectionName, DefaultValue.ToString(), null];
			}
		}
		public OptionEntry this[string sectionName, bool DefaultValue]
		{
			get
			{
				return this[sectionName, DefaultValue.ToString(), null];
			}
		}
		public OptionEntry this[string sectionName]
		{
			get
			{
				return this[sectionName, null, null];
			}
		}

	}
	public class OptionEntry
	{
		/// <summary>
		/// this option's name.
		/// </summary>
		string m_name;
		/// <summary>
		/// this option's String Value (if there is one, can translate to int)
		/// </summary>
		string m_value;

		/// <summary>
		/// this is the long description of the option...
		/// </summary>
		internal string m_description;
		public string Description
		{
			get
			{
				return m_description;
			}
		}

		/// <summary>
		/// This option's child options.
		/// </summary>
		internal OptionMap sub_options;

		/// <summary>
		/// this options's parent option
		/// </summary>
		internal OptionMap section;

		void RecurseName( StringBuilder sb, int level, OptionMap map )
		{
			if( map.parent != null )
			{
				RecurseName( sb, level + 1, map.parent.section );
				sb.Append( map.parent.Name );
				if( level != 0 )
					sb.Append( "/" );
			}

		}

		string INISectionName
		{
			get{
				StringBuilder sb = new StringBuilder();
				RecurseName( sb, 0, this.section );
				return sb.ToString();
			}
		}

		public string Value
		{
			get {
				DsnConnection db = section.db;
				m_value = section.ds.GetValue( db, sub_options.ID );
#if asdfasdf
				if( db == null )
					return "Database Failed.";
				object o = db.ExecuteScalar( "select string from " + OptionMap.Prefix + "values where option_id='" + sub_options.ID + "'" );
				if( o != null )
					m_value = o.ToString();
#endif
				return m_value; 
			}
			set
			{
				if( String.Compare( m_value, value ) != 0 )
				{
					if( !section.fallback_ini )
					{
						section.ds.SetValue( section.db, sub_options.ID, value );
						m_value = value;
						return;
#if no_dataset

						if( section.db.DbFlavor == DsnConnection.ConnectionFlavor.SQLServer )
						{
							if( !section.db.KindExecuteNonQuery( "update " + OptionMap.Prefix + "values set string=" + section.db.sql_value_quote_open
								+ section.db.Escape( value ) + section.db.sql_value_quote_close
								+ "where option_id='" + sub_options.ID + "'" ) )
								section.db.KindExecuteNonQuery( "insert into " + OptionMap.Prefix + "values(option_id,string)values( '" + sub_options.ID + "','" + section.db.Escape( value ) + "')" );
						}
						else
							section.db.KindExecuteNonQuery( "replace into " + OptionMap.Prefix + "values(option_id,string)values( '" + sub_options.ID + "','" + section.db.Escape( value ) + "')" );
#endif
					}
					else
					{
						INI.Default[INISectionName][m_name].Value = value.ToString();
					}
					m_value = value;
				}
			}
		}
		public bool Bool
		{
			get
			{
				object x;
				if( !section.fallback_ini )
				{
					x = section.ds.GetValue( section.db, sub_options.ID );
#if no_dataset
					//x = section.db.ExecuteScalar( "select string from " + OptionMap.Prefix + "values where option_id='" + sub_options.ID +"'" );
#endif
					if( x == null )
					{
						m_value = "0";
						if( !section.fallback_ini )
						{
							section.ds.SetValue( section.db, sub_options.ID, m_value );
#if no_dataset
							section.db.KindExecuteInsert( "replace into " + OptionMap.Prefix + "values(option_id,string)values('" + sub_options.ID + "','" + section.db.Escape( m_value ) + "')" );
#endif
						}

					}
					else
						m_value = x.ToString();
					if( m_value == null || m_value.Length == 0 )
						return false;
					
					// just make sure that sensible conversions are used also...
					if( m_value[0] == 'y' || m_value[0] == 'Y' || m_value[0] == '1' )
						return true;
					if( m_value == "0" )
						return false;
					return Convert.ToBoolean( m_value );
				}
				else
				{
					return INI.Default[INISectionName][m_name].Integer != 0;
				}
			}
            set
            {
				if( !section.fallback_ini )
				{
                    section.ds.SetValue( section.db, sub_options.ID, value?"1":"0" );
#if no_dataset
    				object x;
					//x = section.db.ExecuteScalar( "select string from " + OptionMap.Prefix + "values where option_id='" + sub_options.ID +"'" );
#endif
                }
				else
				{
					INI.Default[INISectionName][m_name].Bool = value;
				}

            }
		}
		public int Integer
		{
			get
			{
				object x;
				if( !section.fallback_ini )
				{
					x = section.ds.GetValue( section.db, sub_options.ID );

					//x = section.db.ExecuteScalar( "select string from " + OptionMap.Prefix + "values where option_id='" + sub_options.ID + "'" );
					if( x == null )
					{
						m_value = "0";
						if( !section.fallback_ini )
						{
							section.ds.SetValue( section.db, sub_options.ID, m_value );
#if no_dataset
							if( section.db.DbFlavor == DsnConnection.ConnectionFlavor.SQLServer )
							{
								if( !section.db.KindExecuteNonQuery( "update "+OptionMap.Prefix+"values set string=" + section.db.sql_value_quote_open
									+ section.db.Escape( m_value ) + section.db.sql_value_quote_close
									+ "where option_id='" + sub_options.ID + "'" ) )
									section.db.KindExecuteInsert( "insert into "+OptionMap.Prefix+"values(option_id,string)values('" + sub_options.ID + "','" + section.db.Escape( m_value ) + "')" );
							}
							else
								section.db.KindExecuteInsert( "replace into "+OptionMap.Prefix+"values(option_id,string)values('" + sub_options.ID + "','" + section.db.Escape( m_value ) + "')" );
#endif
						}

					}
					else
						m_value = x.ToString();
					if( m_value == null || m_value.Length == 0 )
						return 0;
					else
						return Convert.ToInt32( m_value );
				}
				else
				{
					return INI.Default[INISectionName][m_name].Integer;
				}
			}
			set
			{
				string nValue = value.ToString();
				if( String.Compare( m_value, nValue ) != 0 )
				{
					section.ds.SetValue( section.db, sub_options.ID, nValue );
#if no_dataset
					if( !section.fallback_ini )
						section.db.KindExecuteInsert( "replace into "+OptionMap.Prefix+"values(option_id,string)values('" + sub_options.ID + "','" + section.db.Escape( m_value ) + "')" );
					else
						INI.Default[INISectionName][m_name].Value = nValue;
					m_value = nValue;
#endif
				}
			}
		}
		public string Name
		{
			get { return m_name; }
			set { m_name = value; }
		}

		internal OptionEntry( OptionMap section, string s )
		{
			OptionMapDataset4 ds = section.ds;
			object name_id = ds.name.GetNameID( section.db, s );// section.names[s];
			object ID;
			if( section.root.option_map_key_type == typeof( Guid ) )
				ds.CreateOption( section.db, ID = DsnConnection.GetGUID( section.db ), section.ID, name_id );
			else
				ID = ds.CreateOption( section.db, section.ID, name_id );
			sub_options = new OptionMap( this, ID );
			this.section = section;
			m_name = s;
			return;
#if asdfasdf
			object name_id = section.names[s];
			object option_id;
			if( !section.fallback_ini )
			{
				option_id = section.db.KindExecuteInsert( "insert into " + OptionMap.Prefix + "map(parent_option_id,name_id) values('" + section.ID + "','" + name_id + "')" );
			}
			else
				option_id = 1;
			this.section = section;
			sub_options = new OptionMap( this, option_id );
			m_name = s;
#endif
		}


		/// <summary>
		/// creates an option entry with specified name(s) and descriptoin
		/// </summary>
		/// <param name="section">the section that contains this new entry</param>
		/// <param name="s">the name of the entry</param>
		/// <param name="description">the descriptiion of the entry.</param>
		internal OptionEntry( OptionMap section, string s, string description )
		{
			OptionMapDataset4 ds = section.ds;
			object name_id = ds.name.GetNameID( section.db, s );// section.names[s];
			object ID;
			if( section.root.option_map_key_type == typeof( Guid ) )
			{
				DataRow row = ds.CreateOption( section.db, ID = DsnConnection.GetGUID( section.db ), section.ID, name_id );
				if( description != null )
				{
					row["description"] = description;
				}
			}
			else
			{
				DataRow row =	ds.CreateOption( section.db, section.ID, name_id );
				ID = row[ds.map.option_idColumn];
				if( description != null )
				{
					row["description"] = description;
				}
			}
			sub_options = new OptionMap( this, ID );
			this.section = section;
			m_name = s;
		}

		internal OptionEntry( OptionMap section, string s, object option_id )
		{
			this.section = section;
			m_name = s;
			sub_options = new OptionMap( this, option_id );
		}
		internal OptionEntry( OptionMap section, object ID, string name, string value )
		{
			this.section = section;
			sub_options = new OptionMap( this, ID );
			m_name = name;
			m_value = value;
		}

		internal OptionEntry( OptionMap section, object ID, string name, DataRow[] value )
		{
			this.section = section;
			sub_options = new OptionMap( this, ID );
			m_name = name;
			if( value != null && value.Length > 0 )
				m_value = value[0][section.ds.values.stringColumn].ToString();
		}

		public override string ToString()
		{
			return m_name;
		}
		public static implicit operator string( OptionEntry m )
		{
			object x;
			if( !m.section.fallback_ini )
			{
				x = m.section.ds.GetValue( m.section.db, m.sub_options.ID );

				//x = m.section.db.ExecuteScalar( "select string from "+OptionMap.Prefix+"values where option_id='" + m.sub_options.ID + "'" );
			}
			else
				x = m.m_value;
			if( x == null )
				return null;
			return x.ToString();// m.m_value;
		}
		public static implicit operator OptionMap( OptionEntry m )
		{
			return m.sub_options;
		}
		public static implicit operator int( OptionEntry m )
		{
			if( m.m_value == null )
				return 0;
			if( m.m_value.Length == 0 )
				return 0;
			return Convert.ToInt32( m.m_value );
		}

		internal static bool CheckIsPath( String line )
		{
			if( line.IndexOfAny( new char[] { '\\', '/' } ) > 0 )
			{
				return true;
			}
			return false;
		}

		internal static bool SplitPath( String line, out String first, out String remainder )
		{
			int pos;
			if( ( pos = line.IndexOfAny( new char[] { '\\', '/' } ) ) > 0 )
			{
				first = line.Substring( 0, pos );
				remainder = line.Substring( pos + 1 );
				return true;
			}
			first = line;
			remainder = null;
			return false;
		}

		OptionEntry Search( string entryName, string default_val, string description )
		{
			if( CheckIsPath( entryName ) )
			{
				String here;
				String there;
				SplitPath( entryName, out here, out there );
				foreach( OptionEntry entry in sub_options )
					if( String.Compare( entry.ToString(), here, true ) == 0 )
						return entry[there, default_val, description];

				OptionEntry blank;
				if( description == null )
					blank = new OptionEntry( this.sub_options, here );
				else
					blank = new OptionEntry( this.sub_options, here, description );
				if( default_val != null )
				{
					if( section.fallback_ini )
					{
						blank.Value = INI.Default[blank.INISectionName][blank.m_name, default_val];
					}
					else
					{
						if( INIControl.DialogEnable )
						{
							INIForm form = new INIForm( entryName, default_val );
							form.ShowDialog();
							blank.Value = form.ToString();
						}
						else
							blank.Value = default_val;
					}
				}
				sub_options.Add( blank );
				return blank[there, default_val, description];
			}
			else
			{

				foreach( OptionEntry entry in sub_options )
					if( String.Compare( entry.ToString(), entryName, true ) == 0 )
						return entry;
				
				OptionEntry blank = new OptionEntry( sub_options, entryName, description );
				if( default_val != null )
				{
					if( section.fallback_ini )
					{
						blank.Value = INI.Default[blank.INISectionName][blank.m_name, default_val];
					}
					else
					{
						if( INIControl.DialogEnable )
						{
							INIForm form = new INIForm( entryName, default_val );
							form.ShowDialog();
							blank.Value = form.ToString();
						}
						else
						{
							blank.Value = default_val;
						}
					}
				}
				sub_options.Add( blank );
				return blank;
			}
			//return null;
		}

		public OptionEntry this[string entryName]
		{
			get
			{
				sub_options.ReadBranch();

				OptionEntry result = Search( entryName, null, null );
				if( result != null )
					return result;

				OptionEntry blank = new OptionEntry( this.sub_options, entryName );
				sub_options.Add( blank );
				return blank;
			}
		}
		public OptionEntry this[string entryName, string DefaultValue]
		{
			get
			{
				//this.
				sub_options.ReadBranch();

				OptionEntry entry = Search( entryName, DefaultValue, null );
				if( entry != null )
					return entry;

				OptionEntry blank = new OptionEntry( this.sub_options, entryName );
				blank.Value = DefaultValue;
				sub_options.Add( blank );
				return blank;
			}
		}
        public OptionEntry this[string entryName, int DefaultValue]
        {
            get
            {
                //this.
                sub_options.ReadBranch();

                OptionEntry entry = Search( entryName, DefaultValue.ToString(), null );
                if( entry != null )
                    return entry;

                OptionEntry blank = new OptionEntry( this.sub_options, entryName );
                blank.Integer = DefaultValue;
                sub_options.Add( blank );
                return blank;
            }
        }
        public OptionEntry this[string entryName, bool DefaultValue]
        {
            get
            {
                //this.
                sub_options.ReadBranch();

                OptionEntry entry = Search( entryName, DefaultValue.ToString(), null );
                if( entry != null )
                    return entry;

                OptionEntry blank = new OptionEntry( this.sub_options, entryName );
                blank.Bool = DefaultValue;
                sub_options.Add( blank );
                return blank;
            }
        }
        public OptionEntry this[string entryName, string DefaultValue, string Description]
		{
			get
			{
				//this.
				sub_options.ReadBranch();

				OptionEntry entry = Search( entryName, DefaultValue, Description );
				if( entry != null )
					return entry;

				OptionEntry blank = new OptionEntry( this, entryName, Description );
				blank.Value = DefaultValue;
				sub_options.Add( blank );
				return blank;
			}
			//set { } 
		}

		internal void Delete()
		{
			DsnConnection dsn = this.section.db;
			//this.section.ds.map.Delete
/*
			dsn.KindExecuteNonQuery( "delete from " + OptionMap.Prefix + "values where option_id='" + this.sub_options.ID + "'" );
			dsn.KindExecuteNonQuery( "delete from " + OptionMap.Prefix + "blobs where option_id='" + this.sub_options.ID + "'" );
			dsn.KindExecuteNonQuery( "delete from " + OptionMap.Prefix + "map where option_id='" + this.sub_options.ID + "'" );
 */
			this.section.Remove( this );
		}
	}


	public static partial class Options
	{
		public static readonly string ProgramName;

		static Options()
		{
			ProgramName = Application.ExecutablePath.Substring( Application.ExecutablePath.LastIndexOfAny( new char[] { '/', '\\' } ) + 1 );
			int extension = ProgramName.LastIndexOf( '.' );
			// trim the extension only if it is '.EXE' ending.
			if( String.Compare( ProgramName.Substring( extension ), ".exe", true ) == 0 )
				ProgramName = ProgramName.Substring( 0, ProgramName.LastIndexOf( '.' ) );
		}

		//static List<INIFile> files = new List<INIFile>();
		internal static OptionMap options;
		public static OptionMap Default
		{
			get
			{
				// one-time set here.... uhmm... it's for default so yea.
				if( options == null )
				{
                    DsnConnection dsn = null;
                    try
                    {
						dsn = new DsnConnection( OptionMap.DefaultOptionDatabase );// StaticDsnConnection.dsn;
						//dsn = StaticDsnConnection.dsn;
                    }
                    catch (Exception e)
                    {
                        Log.log(e.Message);
                    }
                    options = Database( dsn );
				}
				return options[ProgramName];
			}
		}

		public static OptionMap Database( DsnConnection db )
		{
			OptionMap tmp_options = new OptionMap( db );
			return tmp_options;
		}
		public static OptionMap File( String filename )
		{
			if( options == null )
			{
				options = new OptionMap();
			}
			if( filename == null )
				return options;
			return options[filename];
		}
	}
}
