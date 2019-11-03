using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace PlayList_Manager
{
	static internal class Local
	{
		public static DataSet Files;
		public static DataTable CurrentFiles;
		public static DataTable FileSets;
		public static DataTable AllFiles;
		internal static HallSelector selected_button;
		public static DataRow _current_fileset;
		public static DataRow current_fileset
		{
			set
			{
				_current_fileset = value;
				RefreshFiles();
			}
		}

		static void ValidateTester()
		{
			if( !System.IO.Directory.Exists( "vlc32" ) )
			{
				xperdex.tasks.TaskItem task = new xperdex.tasks.TaskItem( "vlc_install.exe" );
				task.Execute();				
			}
		}

		internal static void TestPlaylist()
		{
			if( _current_fileset != null )
			{
				if( !System.IO.File.Exists( _current_fileset["Path"] + "/TestList.m3u" ) )
				{
					MessageBox.Show( "Please Save a playlist first." );
					return;
				}
				String s = Application.ExecutablePath;
				int end1 = s.LastIndexOfAny( new char[] { '/', '\\' } );
				s = s.Substring( 0, end1 );
				xperdex.tasks.TaskItem task = new xperdex.tasks.TaskItem( s + "/vlc32/vlc.exe", _current_fileset["Path"].ToString(), "TestList.m3u" );
				task.Execute();
			}
			else
				MessageBox.Show( "Please select a hall first." );
		}

		static Local()
		{
			DataColumn dc1, dc2, dc3;
			ValidateTester();
			//xperdex.classes.IReflectorCreate
			CurrentFiles = new DataTable( "Current Files" );
			CurrentFiles.Columns.Add( "Name", typeof( String ) );
			CurrentFiles.Columns.Add( "Play", typeof( bool ) );
			CurrentFiles.Columns.Add( "Path", typeof( string ) );
			CurrentFiles.Columns.Add( "Alias Path", typeof( string ) );

			FileSets = new DataTable( "FileSet" );
			FileSets.Columns.Add( "Name", typeof( string ) );
			FileSets.Columns.Add( "Path", typeof( string ) );
			FileSets.Columns.Add( "Alias Path", typeof( string ) );
			dc1 = FileSets.Columns.Add( "ID", typeof( int ) );
			dc1.AutoIncrement = true;

			AllFiles = new DataTable( "AllFiles" );
			AllFiles.Columns.Add( "Name", typeof( String ) );
			AllFiles.Columns.Add( "FileID", typeof( int ) ).AutoIncrement = true;
			dc2 = AllFiles.Columns.Add( "FileSetID", typeof( int ) );



			Files = new DataSet();
			Files.Tables.Add( CurrentFiles );
			Files.Tables.Add( AllFiles );
			Files.Tables.Add( FileSets );
			//Files.Tables.Add( PlayList );

			//ForeignKeyConstraint c = new ForeignKeyConstraint( FileSets.Columns["Path"], CurrentFiles.Columns["Path"] ) ;
			//c.UpdateRule = Rule.Cascade;
			//CurrentFiles.Constraints.Add( c );

			//c = new ForeignKeyConstraint( FileSets.Columns["Alias Path"], CurrentFiles.Columns["Alias Path"] );
			//c.UpdateRule = Rule.Cascade;
			//CurrentFiles.Constraints.Add( c );

			Files.Relations.Add( new DataRelation( "FileSetFiles", dc1, dc2 ) );
			//Files.Relations.Add( new DataRelation( "FileSetFilePlay", dc1, dc3 ) );
			//Files.Relations.Add( new DataRelation( "FilePlay", AllFiles.Columns["FileID"], PlayList.Columns["FileID"] ) );

			for( int i = 1; ; i++ )
			{
				String hallpath = xperdex.classes.INI.File( "Playlist.ini" )["Playlists"]["Hall Path " + i, "" ];
				if( hallpath == null || hallpath.Length == 0 )
					break;
				String hallname = xperdex.classes.INI.File( "Playlist.ini" )["Playlists"]["Hall Name " + i, ""];
				DataRow row = FileSets.NewRow();
				row["Name"] = hallname;
				row["Path"] = hallpath;
				row["Alias Path"] = (String)xperdex.classes.INI.File( "Playlist.ini" )["Playlists"]["Hall Server Root" + i, "/storage/videos"];
				FileSets.Rows.Add( row );
			}
			FileSets.AcceptChanges();

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Filename"></param>
		/// <param name="Path"></param>
		/// <returns>If the file was not written to (is blank)</returns>
		static bool WritePlayList( String Filename, String Path )
		{
			bool blank = false;
			String mypath = _current_fileset["Path"].ToString();
			FileStream fs = new FileStream( mypath + "/" + Filename, FileMode.OpenOrCreate );
			fs.SetLength( 0 );
			StreamWriter sw = new StreamWriter( fs );

			foreach( DataRow row in CurrentFiles.Rows )
			{
				if( row.RowState == DataRowState.Detached || row.RowState == DataRowState.Deleted )
					continue;
				if( Convert.ToBoolean( row["Play"] ) )
					sw.WriteLine( Path + "/" + row["Name"] + "\n" );
			}
			sw.Flush();
			if( fs.Length == 0 )
			{
				blank = true;
			}
			sw.Close();
			fs.Close();
			return blank;
		}

		internal static void WritePlayList()
		{
			if( _current_fileset == null )
			{
				MessageBox.Show( "Please select a hall first." );
				return;
			}
			if( WritePlayList( "PlayList.m3u", _current_fileset["Alias Path"].ToString() ) )
							MessageBox.Show( "Playlist was saved, but there's no content...\nTest will probably fail to load playlist.m3u" );
			WritePlayList( "TestList.m3u", _current_fileset["Path"].ToString() );
			CurrentFiles.WriteXml( _current_fileset["Path"].ToString() + "/PlayList.xml" );						
		}

		static void ReadPlayList()
		{
			String file = _current_fileset["Path"] + "/PlayList.xml";
			CurrentFiles.Clear();
			if( System.IO.File.Exists( file ) )
				CurrentFiles.ReadXml( file );
		}

		static void RefreshFiles( DataRow set )
		{
			DirectoryInfo di = new DirectoryInfo( set["Path"].ToString() );
			if( !di.Exists )
			{
				if( MessageBox.Show( "Do you want me to create [" + di.FullName + "]", "Create?", MessageBoxButtons.YesNo ) == DialogResult.Yes )
				{
					di.Create();
				}
				else
					return;
			}
			{
				FileInfo[] files = di.GetFiles();
				DataRow[] delete = set.GetChildRows( "FileSetFiles" );

				foreach( DataRow row in delete )
					row.Delete();

				foreach( FileInfo file in files )
				{
					if( file.Name.Substring( file.Name.Length - 4, 4 ) == ".m3u" )
						continue;
					if( file.Name.Substring( file.Name.Length - 4, 4 ) == ".xml" )
						continue;
					DataRow newrow = AllFiles.NewRow();
					newrow["Name"] = file.Name;
					newrow["FileSetID"] = set["ID"];
					AllFiles.Rows.Add( newrow );
				}

				AllFiles.AcceptChanges();


				DataRow[] this_set = set.GetChildRows( "FileSetFiles" );
				//CurrentFiles.Clear();
				ReadPlayList();

				List<DataRow> todelete = new List<DataRow>();
				foreach( DataRow row in CurrentFiles.Rows )
				{
					//DataRow[] validate = set.GetChildRows( "FileSetFiles" );
					DataRow[] found = AllFiles.Select( "Name='" + row["Name"] + "' and FileSetID="+set["ID"] );
					if( found.Length == 0 )
					{
						todelete.Add( row );						
					}
				}
				foreach( DataRow row in todelete )
				{
					row.Delete();
				}


				foreach( DataRow row in this_set )
				{
					DataRow[] exists = CurrentFiles.Select( "Name='" + row["Name"] + "'" );
					// the file was added while we weren't looking.
					if( exists.Length == 0 )
					{
						DataRow newrow = CurrentFiles.NewRow();
						newrow["Name"] = row["Name"];
						newrow["Play"] = true;
						newrow["Path"] = set["Path"];
						newrow["Alias Path"] = set["Alias Path"];
						CurrentFiles.Rows.Add( newrow );
					}
				}
				CurrentFiles.AcceptChanges();

			}
		}


		internal static void RefreshFiles()
		{
			RefreshFiles( _current_fileset );
		}
	}
}
