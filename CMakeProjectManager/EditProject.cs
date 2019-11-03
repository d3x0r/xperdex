using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using CMakeProjectManager.TreeviewNodes;
using xperdex.classes;

namespace CMakeProjectManager
{
	public partial class EditProject : Form
	{
		public EditProject()
		{
			InitializeComponent();
		}

		void FillTreeProjectsFrom( TreeNode node, DataRow project_root )
		{
			foreach( DataRow project in project_root.GetChildRows( "ProjectGroupProject" ) )
			{
				TreeNode project_node;
				node.Nodes.Add( project_node = new ProjectNode( project ) );
				foreach( DataRow target in project.GetChildRows( "Projects_Target" ) )
				{
					TreeNode target_node;
					project_node.Nodes.Add( target_node = new TargetNode( target ) );
					foreach( DataRow target_source in target.GetChildRows( "Target_TargetSources" ) )
					{
						target_node.Nodes.Add( new TargetSourceNode( target_source ) );
					}
				}
				foreach( DataRow row in project.GetChildRows( "ProjectsProjectIncludes" ) )
				{
					DataRow project_group = row.GetParentRow( "ProjectIncludesProject" );
					TreeNode sub_project_node;
					sub_project_node = project_node.Nodes.Add( project_group["name"] as String );
					FillTreeProjectsFrom( sub_project_node, project_group );
				}
			}
		}

		void FillTree()
		{
			TreeNode node;
			treeView1.Nodes.Add( "Common Properties" );
			node = treeView1.Nodes.Add( "Projects" );
			DataRow project_root = ProjectData.project_data_set.current_project_group;
			FillTreeProjectsFrom( node, project_root);

		}




		void treeView1_DragDrop( object sender, DragEventArgs e )
		{
			if( e.Data.GetDataPresent( "Filename", false ) )

				//if( e.Data.GetDataPresent( "System.Windows.Forms.TreeNode", false ) )
			{
				TreeNode NewNode;
				Point pt = ( (TreeView)sender ).PointToClient( new Point( e.X, e.Y ) );
				TreeNode DestinationNode = ( (TreeView)sender ).GetNodeAt( pt );
				ProjectNode project = DestinationNode as ProjectNode;
				if( project != null )
				{
					{
						string[] s_array = (string[])e.Data.GetData( DataFormats.FileDrop, false );
						foreach( String s in s_array )
						{
							if( Directory.Exists( s ) )
							{
								DataRow new_project_group_include = ProjectData.project_data_set.NewSubProjectGroup( project.project, s );
								DataRow new_project_group = new_project_group_include.GetParentRow( "ProjectIncludesProject" );
								if( new_project_group != null )
								{
									TreeNode group_node;
									DestinationNode.Nodes.Add( group_node = new TreeNode( new_project_group["name"] as String ) );
									foreach( DataRow sub_project in new_project_group.GetChildRows( "ProjectGroupProject" ) )
									{
										group_node.Nodes.Add( new ProjectNode( sub_project ) );
									}
								}
							}
						}
					}
					
				}
				TargetNode target = DestinationNode as TargetNode;
				if( target != null )
				{
					{
						string[] s_array = (string[])e.Data.GetData( DataFormats.FileDrop, false );
						foreach( String s in s_array )
						{
							if( File.Exists( s ) )
							{
								DataRow new_target_source = ProjectData.project_data_set.NewTargetSource( target.target, s );
								if( new_target_source != null )
									DestinationNode.Nodes.Add( new TargetSourceNode( new_target_source ) );
							}
						}
					}
				}
				/*
				NewNode = (TreeNode)e.Data.GetData( "System.Windows.Forms.TreeNode" );
				if( DestinationNode.TreeView != NewNode.TreeView )
				{
					DestinationNode.Nodes.Add( (TreeNode)NewNode.Clone() );
					DestinationNode.Expand();
					//Remove Original Node
					NewNode.Remove();
				}
				 * */
			}
		}

		void treeView1_DragEnter( object sender, DragEventArgs e )
		{
			e.Effect = DragDropEffects.All;
			//e.
		}

		private void EditProject_Load( object sender, EventArgs e )
		{
			treeView1.ImageList = ProjectData.images;
			treeView1.DragEnter += new DragEventHandler( treeView1_DragEnter );
			treeView1.DragDrop += new DragEventHandler( treeView1_DragDrop );

			FillTree();

			comboBoxTargetType.Items.Add( ProjectDataSet.ProjectTypes.DynamicLibrary );
			comboBoxTargetType.Items.Add( ProjectDataSet.ProjectTypes.ConsoleExecutable );
			comboBoxTargetType.Items.Add( ProjectDataSet.ProjectTypes.WindowedExecutable );
			comboBoxTargetType.Items.Add( ProjectDataSet.ProjectTypes.PluginLibrary );
			comboBoxTargetType.Items.Add( ProjectDataSet.ProjectTypes.StaticLibrary );

			if( tabControl1.TabPages.IndexOf( tabPageProjectProperties ) >= 0 )
			{
				tabControl1.TabPages.Remove( tabPageProjectProperties );
				tabControl2.TabPages.Add( tabPageProjectProperties );
			}
			if( tabControl1.TabPages.IndexOf( tabPageTargetProperties ) >= 0 )
			{
				tabControl1.TabPages.Remove( tabPageTargetProperties );
				tabControl2.TabPages.Add( tabPageTargetProperties );
			}

			//listBox1.DataSource = ProjectData.project_data_set.CurrentProjects;
			//listBox1.DisplayMember = ProjectData.project_data_set.CurrentProjects.nameColumn.ColumnName;
			//listBox1.ValueMember = ProjectData.project_data_set.CurrentProjects.project_idColumn.ColumnName;

			dataGridView1.DataSource = ProjectData.project_data_set.ProjectVariables;

			dataGridView1.Columns[ProjectData.project_data_set.ProjectVariables.project_idColumn.ColumnName].Visible = false;


		}

		private void button1_Click( object sender, EventArgs e )
		{
			String project = QueryNewName.Show( "Enter new project path" );
			if( project != null && project.Length > 1 )
				ProjectData.project_data_set.NewProject( ProjectData.project_data_set.current_project_group, project );

		}

		private void listBox2_DragEnter( object sender, DragEventArgs e )
		{
			e.Effect = DragDropEffects.Link;
		}

		private void listBox2_DragDrop( object sender, DragEventArgs e )
		{
			string[] s_array = (string[])e.Data.GetData( DataFormats.FileDrop, false );
			foreach( String s in s_array )
			{
				if( Directory.Exists( s ) )
				{
					MessageBox.Show( "this is broke." );
					//ProjectData.project_data_set.NewSubProjectGroup( null, s );
				}
			}

		}

		TabPage prior_page;
		void SelectActivePage( TabPage page )
		{
			if( prior_page != null )
			{
				tabControl1.TabPages.Remove( prior_page );
				tabControl2.TabPages.Add( prior_page );
			}
			tabControl2.TabPages.Remove( page );
			tabControl1.TabPages.Add( page );
			prior_page = page;
	
		}


		//ProjectGroupNode 
		ProjectNode current_project;
		TargetNode current_target;

		private void treeView1_AfterSelect( object sender, TreeViewEventArgs e )
		{
			ProjectNode project = e.Node as ProjectNode;
			if( project != null )
			{
				current_project = project;
				textBoxProjectName.Text = project.Text;
				//tabControl2.TabPages.Add( tabControl1.
				SelectActivePage( tabPageProjectProperties );
			}
			TargetNode target = e.Node as TargetNode;
			if( target != null )
			{
				SelectActivePage( tabPageTargetProperties );

				comboBoxTargetType.SelectedValue = target.target["target_type"];

				current_target = target;
				//ProjectData.project_data_set.current_target = target.target;
			}
			TargetSourceNode target_source = e.Node as TargetSourceNode;
			if( target_source != null )
			{

			}
		}

		private void button4_Click( object sender, EventArgs e )
		{

		}

		private void button3_Click( object sender, EventArgs e )
		{
			DataRow row = CreateTarget.Show( current_project.project );
			if( row != null )
			{
				current_project.Nodes.Add( new TargetNode( row ) );
			}
		}

		private void button5_Click( object sender, EventArgs e )
		{
			current_project.project["name"] = textBoxProjectName.Text;
		}

		private void buttonApplyTarget_Click( object sender, EventArgs e )
		{
			current_target.target["name"] = textBoxTargetName.Text;
		}



		String GetFullPath( DataRow project_group )
		{
			StringBuilder sb = new StringBuilder();
			//DataRow parent;
			DataRow[] parents = project_group.GetChildRows( "ProjectIncludesProject" );
			foreach(DataRow parent in parents )
			{
				DataRow parent_project = parent.GetParentRow( "ProjectsProjectIncludes" );
				DataRow parent_project_group = parent_project.GetParentRow( "ProjectGroupProject" );
				sb.Insert( 0, parent_project_group["name"] + "/" );
			}
			sb.Append( project_group["name"] );
			return sb.ToString();
		}

		void WriteCmake( DataRow project_group )
		{
			
			FileStream fs = new FileStream( GetFullPath( project_group ) + "/CMakeLists.txt", FileMode.Create );

			StreamWriter sw = new StreamWriter( fs );
			sw.WriteLine( "cmake_minimum_required(VERSION 2.8)\n" );
			sw.WriteLine( "" );
			sw.WriteLine( "" );
			foreach( DataRow project in project_group.GetChildRows( "ProjectGroupProject" ) )
			{
				sw.WriteLine( "PROJECT(\"" + project["name"] + "\")" );
				sw.WriteLine( "" );
				sw.WriteLine( "" );

				foreach( DataRow target in project.GetChildRows( "Projects_Target" ) )
				{
					if( target["target_type"] == DBNull.Value )
					{
						continue;
					}
					switch( (ProjectDataSet.ProjectTypes) target["target_type"] )
					{
					case ProjectDataSet.ProjectTypes.ConsoleExecutable:
						sw.WriteLine( "ADD_EXECUTABLE( " + target["name"] );
						break;
					case ProjectDataSet.ProjectTypes.WindowedExecutable:
						sw.WriteLine( "ADD_EXECUTABLE( " + target["name"] + " WIN32" );
						break;
					case ProjectDataSet.ProjectTypes.StaticLibrary:
						sw.WriteLine( "ADD_LIBRARY( " + target["name"] );
						break;
					case ProjectDataSet.ProjectTypes.DynamicLibrary:
						sw.WriteLine( "ADD_LIBRARY( " + target["name"] + " SHARED " );
						break;
					case ProjectDataSet.ProjectTypes.PluginLibrary:
						sw.WriteLine( "ADD_LIBRARY( " + target["name"] + " SHARED " );
						break;
					}
					if( checkBox1.Checked )
					{
						switch( (ProjectDataSet.ProjectTypes)target["target_type"] )
						{
						case ProjectDataSet.ProjectTypes.ConsoleExecutable:
						case ProjectDataSet.ProjectTypes.WindowedExecutable:
							sw.WriteLine( "   ${GCC_FIRST_PROGRAM_SOURCE}" );
							break;
						case ProjectDataSet.ProjectTypes.PluginLibrary:
						case ProjectDataSet.ProjectTypes.StaticLibrary:
						case ProjectDataSet.ProjectTypes.DynamicLibrary:
							sw.WriteLine( "   ${GCC_FIRST_LIBRARY_SOURCE}" );
							break;
						}
					}
					foreach( DataRow source in target.GetChildRows( "Target_TargetSources" ) )
					{
						sw.WriteLine( "      " + source["name"] );
					}
					if( checkBox1.Checked )
					{
						switch( (ProjectDataSet.ProjectTypes)target["target_type"] )
						{
						case ProjectDataSet.ProjectTypes.ConsoleExecutable:
						case ProjectDataSet.ProjectTypes.WindowedExecutable:
							sw.WriteLine( "   ${GCC_LAST_PROGRAM_SOURCE}" );
							break;
						case ProjectDataSet.ProjectTypes.PluginLibrary:
						case ProjectDataSet.ProjectTypes.StaticLibrary:
						case ProjectDataSet.ProjectTypes.DynamicLibrary:
							sw.WriteLine( "   ${GCC_LAST_LIBRARY_SOURCE}" );
							break;
						}
					}
					sw.WriteLine( ")" );

					if( checkBox1.Checked )
					{
						switch( (ProjectDataSet.ProjectTypes)target["target_type"] )
						{
						case ProjectDataSet.ProjectTypes.ConsoleExecutable:
						case ProjectDataSet.ProjectTypes.WindowedExecutable:
							sw.WriteLine( "string( REPLACE \".\" \"_\" TARGET_LABEL \""+target["name"]+"\" )" );
							sw.WriteLine( "SET_TARGET_PROPERTIES( \"" + target["name"] + "\" PROPERTIES" );
							sw.WriteLine( "                  COMPILE_FLAGS  \"-DTARGET_LABEL=${TARGET_LABEL}\"" );
							sw.WriteLine( ")" );
							break;
						case ProjectDataSet.ProjectTypes.PluginLibrary:
						case ProjectDataSet.ProjectTypes.StaticLibrary:
						case ProjectDataSet.ProjectTypes.DynamicLibrary:
							sw.WriteLine( "string( REPLACE \".\" \"_\" TARGET_LABEL \""+target["name"]+"\" )" );
							sw.WriteLine( "SET_TARGET_PROPERTIES( \"" + target["name"] + "\" PROPERTIES" );
							sw.WriteLine( "                  COMPILE_FLAGS  \"-DTARGET_LABEL=${TARGET_LABEL}\"" );
							sw.WriteLine( ")" );
							break;
						}
					}
				}

				sw.WriteLine( "" );

				foreach( DataRow sub_project in project.GetChildRows( "ProjectsProjectIncludes" ) )
				{
					DataRow sub_project_group = sub_project.GetParentRow( "ProjectIncludesProject" );
					sw.WriteLine( "add_subdirectory( \"" + sub_project_group["name"] + "\" )" );
				}
				sw.WriteLine( "" );
				sw.WriteLine( "" );
			}
			sw.WriteLine( "" );
			sw.WriteLine( "" );
			sw.WriteLine( "" );

			sw.Close();
		//TextWriter tw = new TextWriter();
			//DataRow
		}

		private void buttonWriteCmake_Click( object sender, EventArgs e )
		{
			// limit to what is selected?
			foreach( DataRow project_group in ProjectData.project_data_set.ProjectGroup.Rows )
			{
				WriteCmake( project_group );
			}


		}

		private void buttonDeleteTarget_Click( object sender, EventArgs e )
		{

			current_target.target.Delete();
			current_target.Parent.Nodes.Remove( current_target );
		}
	}
}
