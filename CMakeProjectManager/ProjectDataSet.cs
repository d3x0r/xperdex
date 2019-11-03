using System.Data;
using xperdex.classes;
using xperdex.classes.Types;
using System.IO;
using System;
using System.Text;
using System.Windows.Forms;
namespace CMakeProjectManager {
    
    
    public partial class ProjectDataSet {
	
		internal enum ProjectTypes
		{
			StaticLibrary
			, DynamicLibrary
			, ConsoleExecutable
			, WindowedExecutable
			, PluginLibrary
		}

		public class Projects_IncludedProjects : DataView
		{
			public Projects_IncludedProjects(): base( )//Project
			{
				//this.Table = 
			}
		}


		DataRow _current_target;
			public DataRow current_target
			{
				set {
					_current_target = value;
				}
				get
				{
					return _current_target;
				}
			}


		DataRow _current_project_group;
		public DataRow current_project_group
		{
			set
			{
				CurrentProjects.Rows.Clear();
				foreach( DataRow row in value.GetChildRows( "ProjectGroupProject" ) )
				{
					CurrentProjects.Rows.Add( new object[] { row["name"], row["project_id"] } );
				}
				CurrentProjects.AcceptChanges();

				_current_project_group = value;
			}
			get
			{
				return _current_project_group;
			}
		}



		DataRow _current_project;
		public DataRow current_project
		{
			set 
			{
				CurrentProjectsIncludes.Rows.Clear();
				foreach( DataRow row in value.GetChildRows( "ProjectsProjectIncludes" ) )
				{
					DataRow sub_project = row.GetParentRow( "ProjectIncludesProject" );
					CurrentProjectsIncludes.Rows.Add( new object[]{ sub_project["name"], sub_project["project_group_id"] } );
				}
				CurrentProjectsIncludes.AcceptChanges();
				_current_project = value;
			}
		}


		void ParseCMake( XString xs )
		{
			bool line_start = true;
			int skip_count = 0;
			foreach( XStringSeg seg in xs )
			{
				if( skip_count > 0 )
				{
					skip_count--;
					continue;
				}

				if( ((String)seg).Length == 0 )
				{
					// end of line
					line_start = true;
				}

				if( line_start )
				{
					if( String.Compare( (String)seg, "CMAKE_MINIMUM_REQUIRED", true ) == 0 )
					{

					}
					else if( String.Compare( (String)seg, "PROJECT", true ) == 0 )
					{
					}
					else if( String.Compare( (String)seg, "SET", true ) == 0 )
					{
					}
					else if( String.Compare( (String)seg, "ADD_EXECTUABLE", true ) == 0 )
					{
					}
					else if( String.Compare( (String)seg, "ADD_LIBRARY", true ) == 0 )
					{
					}
				}

				if( String.Compare( (String)seg, "$" ) == 0 )
				{
					StringBuilder var = new StringBuilder();
					XStringSeg tmp = seg;
					// consume the next couple segments...
					if( String.Compare( (String)seg.Next, "{" ) == 0 )
					{
						skip_count = 1;
						tmp = seg.Next.Next;
						while( String.Compare( (String)tmp, "}" ) != 0 )
						{
							tmp.Expand( var );
							tmp = tmp.Next;
							skip_count++;
						}
						skip_count++;
					}
				}


				line_start = false;
			}
		}

		void LoadCMakeLists( string root_path )
		{
			try {
				FileStream fs = new FileStream( root_path + "/CMakeLists.txt", FileMode.Open );
				byte[] buffer = new byte[fs.Length];
				int bytes = fs.Read( buffer, 0, (int)fs.Length );
				String s = System.Text.Encoding.GetEncoding( "utf-8" ).GetString( buffer ); 
				XString xs = new XString( s );
				ParseCMake( xs );

			}
			catch
			{
			}
		}


		internal void Save()
		{
			WriteXml( Application.CommonAppDataPath + "CmakeManagerProjects.xml" );
		}

		internal DataRow NewProjectGroup( string project,string default_project )
		{
			DataRow newrow = ProjectGroup.NewRow();
			newrow[ProjectGroup.project_group_idColumn] = DsnConnection.GetGUID( null );
			newrow[ProjectGroup.nameColumn] = project;
			ProjectGroup.Rows.Add( newrow );
			NewProject( newrow, default_project );
			AcceptChanges();
			LoadCMakeLists( project );
			return newrow;
		}
		internal DataRow NewProject( DataRow parent, string project )
		{
			DataRow newrow = Projects.NewRow();
			newrow[Projects.project_idColumn] = DsnConnection.GetGUID( null );
			newrow[Projects.project_group_idColumn] = parent["project_group_id"];
			newrow[Projects.nameColumn] = project;
			newrow[Projects.project_group_idColumn] = parent[ProjectGroup.project_group_idColumn];
			Projects.Rows.Add( newrow );
			Projects.AcceptChanges();
			return newrow;
		}

		internal DataRow NewSubProjectGroup( DataRow parent, string path )
		{
			DataRow parent_group = parent.GetParentRow( "ProjectGroupProject" );
			String parent_path = parent_group["name"] as String;

			int pathstart;
			String splitname = path;
			if( ( pathstart = splitname.IndexOf( parent_path ) ) >= 0 )
			{
				splitname = splitname.Substring( pathstart + parent_path.Length + 1 );
				if( splitname.IndexOfAny( new char[] { '/', '\\' } ) >= 0 )
				{
					MessageBox.Show( "Should this be added to a sub-project instead?", "Target Contains extra path", MessageBoxButtons.OKCancel );

				}
			}
			else
			{
				MessageBox.Show( "Sorry, file was not within the project" );
				return null;
			}

			DataRow current = parent;

			DataRow row = NewProjectGroup( splitname, splitname );
			DataRow relation = ProjectIncludes.NewRow();
			relation["sub_project_group_id"] = row["project_group_id"];
			relation["project_id"] = current["project_id"];
			ProjectIncludes.Rows.Add( relation );
			ProjectIncludes.AcceptChanges();

			current_project = current;
			return relation;
		}

		internal DataRow NewTarget( DataRow dataRow, string target )
		{
			DataRow newrow = Target.NewRow();
			newrow["target_id"] = DsnConnection.GetGUID( null );
			newrow["project_id"] = dataRow["project_id"];
			newrow["name"] = target;
			Target.Rows.Add( newrow );

			Target.AcceptChanges();
			return newrow;
		}

		internal DataRow NewTargetSource( DataRow dataRow, string target_source )	
		{
			DataRow newrow = TargetSources.NewRow();
			//DataRow target = dataRow.GetParentRow( "Target_TargetSources" );
			DataRow project = dataRow.GetParentRow( "Projects_Target" );
			DataRow project_group = project.GetParentRow( "ProjectGroupProject" );
			String path = project_group["name"] as String;
			int pathstart;
			String splitname = target_source;
			if( ( pathstart = splitname.IndexOf( path ) ) >= 0 )
			{
				splitname = splitname.Substring( pathstart + path.Length + 1 );
				if( splitname.IndexOfAny( new char[] { '/', '\\' } ) >= 0 )
				{
					MessageBox.Show( "Should this be added to a sub-project instead?", "Target Contains extra path", MessageBoxButtons.OKCancel );

				}
			}
			else
			{
				MessageBox.Show( "Sorry, file was not within the project" );
				return null;
			}
			//newrow["target_source_id"] = DsnConnection.GetGUID( null );
			newrow["target_id"] = dataRow["target_id"];
			newrow["name"] = splitname;
			TargetSources.Rows.Add( newrow );

			TargetSources.AcceptChanges();
			return newrow;
		}


	}
}					
