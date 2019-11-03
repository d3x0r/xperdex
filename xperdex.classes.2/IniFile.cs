using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace xperdex.classes
{
	public class INIFile : List<INISection>
	{
		internal static string system_base_file;
		static string system_base_path;
		bool loading;
		string filename;
		internal string file;
		public bool crypt;

		enum read_state
		{
			find_section_entry // this state must find either a section or an entry
			, read_section // aka [ read between ]
		    , read_Value // get the value...
			, find_value // got an '=' so we can skip '=' in the value (aka read_entry)
		};

		internal void Save()
		{
			if( loading )
				return;
			byte[] data;
			FileStream fs = null;
			try
			{
				fs = new FileStream( (filename==null)?system_base_file:filename, FileMode.OpenOrCreate|FileMode.Truncate );
			}
			catch( Exception e )
			{
				Console.WriteLine( e.Message );
				crypt = true;
				return;
			}
			bool first = true;
			StringBuilder output = new StringBuilder();
			foreach( INISection section in this )
			{
				if( !first )
				{
					// add an extra \n before sections... prettyification.
					output.Append( "\r\n" );
				}
				first = false;
				output.Append( "[" + section.ToString() + "]\r\n" );
				foreach( INIEntry entry in section )
				{
					output.Append( entry.Name + "=" + entry.Value + "\r\n" );
				}
			}
			data = new byte[output.Length];
			if( crypt )
				for( int n = 0; n < output.Length; n++ )
					data[n] = Convert.ToByte( Convert.ToByte( output[n] ) + 20 );
			else
				for( int n = 0; n < output.Length; n++ )
					data[n] = Convert.ToByte( output[n] );
			BinaryWriter bw = new BinaryWriter( fs );
			bw.Write( data );
			fs.Close();
			bw.Close();
		}

		internal void OpenFile( string file )
		{
			long file_length;
			//this.file = file;
			if( system_base_file == null )
			{
				if( !System.IO.Directory.Exists( Environment.GetFolderPath( Environment.SpecialFolder.CommonApplicationData ) + "/xperdex" ) )
					System.IO.Directory.CreateDirectory( Environment.GetFolderPath( Environment.SpecialFolder.CommonApplicationData ) + "/xperdex" );
				system_base_file = Environment.GetFolderPath( Environment.SpecialFolder.CommonApplicationData ) + "/xperdex/xperdex.ini";
			}

			if( file == null )
				file = system_base_file;
			this.file = file;

			// if second character is a ":"  ... c:...
			// if first character is a / or \ it's an absolue 
			// path, and should not be used...
			if( ( file[1] != ':' ) &&
				( file[0] != '/' ) &&
				( file[0] != '\\' ) )
			{
				// dont' use the path if it's not set (otherwise get leaing slash filename)
				if( system_base_path != null )
					file = system_base_path + "/" + file;
				this.file = file;
			}

			byte[] data;
			FileStream fs = null;
			try
			{
				if( System.IO.File.Exists( file ) )
					fs = new FileStream( file, FileMode.Open );
				else
				{
					filename = file; // save this so we can write it back out later...
					crypt = false;
					fs = new FileStream( file, FileMode.OpenOrCreate );
				}
			}
			catch( FileNotFoundException )
			{
				filename = file; // save this so we can write it back out later...
				crypt = false;
				fs = new FileStream( file, FileMode.OpenOrCreate );
			}
			catch( Exception e )
			{
				Console.WriteLine( e.Message );
				crypt = true;
				return;
			}
			loading = true;
			filename = file; // save this so we can write it back out later...
			file_length = fs.Length;
			data = new byte[file_length];
			BinaryReader br = new BinaryReader( fs );

			byte[] buffer = new byte[file_length];
			br.Read( buffer, 0, Convert.ToInt32( file_length ) );
			if( buffer.Length > 0 )
			{
				if( buffer[0] != '[' )
				{
					crypt = true;
					for( int i = 0; i < file_length; i++ )
						data[i] = (byte)( ( buffer[i] - 20 ) & 0xFF );
				}
				else
				{
					crypt = false;
					for( int i = 0; i < file_length; i++ )
						data[i] = buffer[i];
				}

				{
					INISection current_section = null;
					INIEntry current_entry = null;
					StringWriter sr = new StringWriter();

					int ofs;
					read_state state = read_state.find_section_entry;
					for( ofs = 0; ofs < data.Length; ofs++ )
					{
						switch( data[ofs] )
						{
						case (byte)'[':
							if( state == read_state.find_section_entry )
							{
								state = read_state.read_section;
							}
							break;
						case (byte)']':
							current_section = new INISection( this, sr.ToString() );
							sr.GetStringBuilder().Length = 0;
							Add( current_section );
							state = read_state.find_section_entry;
							break;
						case (byte)'\r':
							break;
						case (byte)'\n':
							if( state == read_state.find_value )
							{
								state = read_state.find_section_entry;
								sr.GetStringBuilder().Length = 0;
							}
							else if( state == read_state.read_Value )
							{
								current_entry.Value = sr.ToString();
								sr.GetStringBuilder().Length = 0;
								state = read_state.find_section_entry;
							}
							// else we ignore it - cause we're in find_section? or find other?
							break;
						case (byte)'=':
							if( state == read_state.find_value )
							{
								if( current_section != null )
								{
									StringBuilder sb = sr.GetStringBuilder();
									while( sb.ToString().Substring( sb.Length - 1, 1 ) == " " )
										sb.Length--;
									current_entry = new INIEntry( current_section, sr.ToString() );
									sr.GetStringBuilder().Length = 0;
									current_section.Add( current_entry );
									state = read_state.read_Value;
								}
								else
								{
									Console.WriteLine( "= found while not in a section!" );
								}
							}
							else if( state == read_state.read_Value )
								sr.Write( Convert.ToChar( data[ofs] ) );
							break;
						case (byte)' ':
						case (byte)'\t':
							if( state == read_state.find_section_entry )
								continue; // ignore spaces if not collecting something useful.
							sr.Write( Convert.ToChar( data[ofs] ) );
							break;
						default:
							switch( state )
							{
							case read_state.find_value:
							case read_state.read_section:
							case read_state.read_Value:
								sr.Write( Convert.ToChar( data[ofs] ) );
								break;
							case read_state.find_section_entry:
								state = read_state.find_value;
								sr.Write( Convert.ToChar( data[ofs] ) );
								break;
							}
							break;
						}
					}
				}
			}
			fs.Close();
			br.Close();

			if( file == system_base_file && system_base_path == null )
			{
				system_base_path = this["System"]["INI Path"];
				if( system_base_path == null || system_base_path == "" )
				{
					system_base_path = Environment.GetFolderPath( Environment.SpecialFolder.CommonApplicationData ) + "/xperdex";
					this["System"]["INI Path"].Value = system_base_path;
				}
			}
			loading = false;
		}

		// localize constructors...
		internal INIFile()
		{
			//OpenFile( null );
		}
		//static INISection empty_section;

		public INISection this[string sectionName]
		{
			get
			{
				foreach( INISection section in this )
					if( String.Compare( section.ToString(), sectionName, true ) == 0 )
						return section;
				INISection new_section = new INISection( this, sectionName );
				this.Add( new_section );
				return new_section;
			}
			set
			{
				INISection section;
				bool found = false;
				foreach( INISection _section in this )
					if( String.Compare( _section.ToString(), sectionName, true ) == 0 )
					{
						found = true;
						section = _section;
						break;
					}
				if( !found )
				{
					section = new INISection( this, sectionName );
					this.Add( section );
				}

			}
		}

	}
        public class INIEntry
        {
            string m_value;
            string m_name;
			INISection section;
			public string Value
			{
				get { return m_value; }
				set {
					if( String.Compare( m_value, value ) != 0 )
					{
						m_value = value;
						section.ini.Save();
					}
				}
			}
			public bool Bool
			{
				get
				{
					if( m_value == null || m_value.Length == 0 ) return false;
					else if( String.Compare( m_value, "false", true ) == 0 )
						return false;
					else if( String.Compare( m_value, "true", true ) == 0 )
						return true;
					else
						return Convert.ToBoolean( Convert.ToInt32( m_value ) ); 
				}
                set
                {
                    m_value = value.ToString();
                    section.ini.Save();
                }
			}
			public int Integer
			{
				get { 
					if( m_value == null || m_value.Length== 0 ) return 0;
                    else if( String.Compare( m_value, "false", true ) == 0 )
                        return 0;
                    else if( String.Compare( m_value, "true", true ) == 0 )
                        return 1;
                    else
						return Convert.ToInt32(m_value); 
				}
				set {
					string nValue = value.ToString();
					if( String.Compare( m_value, nValue ) != 0 )
					{
						m_value = nValue;
						section.ini.Save();
					}
				}
			}
			public string Name
            {
                get { return m_name; }
                set { m_name = value; }
            }
            internal INIEntry(  INISection section, string s)
            {
				this.section = section;
                m_name = s;
            }
			internal INIEntry( INISection section, string name, string value )
			{
				this.section = section;
				m_name = name;
				m_value = value;
			}

			public override string ToString()
            {
                return m_name;
            }
			public static implicit operator string( INIEntry m )
			{
				return m.m_value;
			}
			public static implicit operator int( INIEntry m )
			{
				if( m.m_value == null )
					return 0;
				if( m.m_value.Length == 0 )
					return 0;
				return Convert.ToInt32( m.m_value );
			}



			public string Description { get; set; }
		}



        public class INISection : List<INIEntry>
        {
			internal INIFile ini;
			string s;
            public INISection(INIFile ini, string s)
            {
				this.ini = ini;
                this.s = s;
            }
            public override string ToString()
            {
                return s;
            }

			public INIEntry this[string entryName, int default_value]
			{
				get
				{
					return this[entryName, default_value.ToString()];
				}
			}
			public INIEntry this[string entryName, bool default_value]
			{
				get
				{
					return this[entryName, default_value.ToString()];
				}
			}
			public INIEntry this[string entryName, string default_value, string description]
			{
				get
				{
					INIEntry result;
					//this.
					foreach( INIEntry entry in this )
						if( String.Compare( entry.ToString(), entryName, true ) == 0 )
						{
							return entry;
						}
					result = new INIEntry( this, entryName, default_value );

					if( INIControl.DialogEnable )
					{
						INIForm form = new INIForm( this.ini.file, this.s, result, default_value, description );
						form.ShowDialog();
						this.Add( result );
						this.ini.Save();
					}
					else
					{
						result.Value = default_value;
						this.Add( result );
						this.ini.Save();
					}
					return result;
				}
				set
				{
					INIEntry entry;
					bool found = false;
					foreach( INIEntry _entry in this )
						if( String.Compare( _entry.ToString(), entryName, true ) == 0 )
						{
							found = true;
							entry = _entry;
							break;
						}
					if( !found )
					{
						entry = new INIEntry( this, entryName );
						this.Add( entry );
					}

				}
			}

			public INIEntry this[string entryName, string default_value]
			{
				get
				{
					return this[entryName, default_value.ToString(), null ];
				}
				set
				{
					this[entryName, default_value.ToString(), null] = value;
				}
				//set { } 
			}

			public INIEntry this[string entryName]
            {
                get
                {
                    //this.
                    foreach (INIEntry entry in this)
                        if (String.Compare(entry.ToString(), entryName, true) == 0) 
							return entry;
                    INIEntry blank = new INIEntry(this, entryName);
					this.Add( blank );
					this.ini.Save();
                    return blank;
                }
				set
				{
					INIEntry entry;
					bool found = false;
					foreach( INIEntry _entry in this )
						if( String.Compare( _entry.ToString(), entryName, true ) == 0 )
						{
							found = true;
							entry = _entry;
							break;
						}
					if( !found )
					{
						entry = new INIEntry( this, entryName );
						this.Add( entry );
					}

				}
				//set { } 
            }
        }
	public static partial class INI
	{
		static List<INIFile> files = new List<INIFile>();
		
		public static INIFile File( String filename )
		{
			bool checknull = false;
			if( filename == INIFile.system_base_file )
				checknull = true;
			foreach( INIFile file in files )
			{
				if( ( checknull && file.file == null ) ||
					( file.file != null 
					&& String.Compare( filename, file.file, true ) == 0 ) )
					return file;
			}
			INIFile result = new INIFile();
			files.Add( result );
			result.OpenFile( filename );
			return result;
		}

		public static INIFile Default
		{
			get
			{
				foreach( INIFile file in files )
				{
					if( file.file == null || file.file == INIFile.system_base_file )
					{
						return file;
					}
				}
				INIFile result = new INIFile();
				files.Add( result );
				result.OpenFile( null );
				return result;
			}
		}


		[DllImport( "kernel32" )]
		private static extern int GetPrivateProfileString( string section,
				 string key, string def, StringBuilder retVal,
			int size, string filePath );

		[DllImport( "KERNEL32.DLL", EntryPoint = "GetPrivateProfileStringA",
					CharSet = CharSet.Ansi )]
		private static extern int XGetProfileString( string section,
				 string key, string def, char[] retVal,
			int size );

		[DllImport( "KERNEL32.DLL", EntryPoint = "GetProfileStringW",
				  SetLastError = true,
				  CharSet = CharSet.Unicode, ExactSpelling = true,
				  CallingConvention = CallingConvention.StdCall )]
		private static extern int GetProfileString(
		  string lpAppName,
		  string lpKeyName,
		  string lpDefault,
		  StringBuilder lpReturnString,
		  int nSize
		  //,string lpFilename 
			);
		static String Legacy_INI_FtnSys;
		static String Legacy_INI_Root;
		public static INIFile Legacy( String filename )
		{
			if( Legacy_INI_Root == null )
			{
				String result_buf = new String( ' ', 256 );
				//char[] result_buf = new char[256];
				StringBuilder INI_Root = new StringBuilder();
				INI_Root.Length = 256;
				GetProfileString( "Fortunet", "System Path", "c:/ftn3000/working/ftnsys.ini", INI_Root, result_buf.Length );
				Legacy_INI_FtnSys = INI_Root.ToString();
				Legacy_INI_Root = INI.File( INI_Root.ToString() )["System"]["INI Path", "c:/ftn3000/working"].Value;
			}
			if( filename == null )
				filename = Legacy_INI_FtnSys;

			if( filename[1] == ':' || filename[0] == '/' || filename[0] == '\\' )
			{
				;
			}
			else
				filename = Legacy_INI_Root + "/" + filename;

			foreach( INIFile file in files )
			{
				if( file.file == filename )
				{
					return file;
				}
			}
			INIFile result = new INIFile();
			result.file = filename;
			files.Add( result );
			result.OpenFile( filename );
			return result;
		}
	}

	public static class INIControl
	{
		internal static bool DialogEnable = false;

		static INIControl()
		{
			DialogEnable = (INI.Default[Options.ProgramName]["Enable INI Dialog Prompting", "0"].Integer != 0);
		}

		/// <summary>
		/// Enable/disable prompting for INI values, otherwise take default value.
		/// </summary>
		public static bool EnableDialog
		{
			set
			{
				DialogEnable = value;
			}
			get
			{
				return DialogEnable;
			}
		}
	}

}

