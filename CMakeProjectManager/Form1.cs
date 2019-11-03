using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using xperdex.classes;

namespace CMakeProjectManager
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button3_Click( object sender, EventArgs e )
		{
			ProjectData.SaveProjects();
		}

		private void button1_Click( object sender, EventArgs e )
		{
			String project = QueryNewName.Show( "Enter new project path" );
			if( project != null && project.Length > 1 )
				ProjectData.project_data_set.NewProjectGroup( project, project );
		}

		private void Form1_Load( object sender, EventArgs e )
		{
			
			listBox1.DataSource = ProjectData.project_data_set.ProjectGroup;
			listBox1.DisplayMember = ProjectData.project_data_set.ProjectGroup.nameColumn.ColumnName;
			listBox1.ValueMember = ProjectData.project_data_set.ProjectGroup.project_group_idColumn.ColumnName;
		}

		private void button2_Click( object sender, EventArgs e )
		{
			ProjectData.project_data_set.current_project_group = ( listBox1.SelectedItem as DataRowView ).Row;

			EditProject epg = new EditProject();
			epg.ShowDialog();
			epg.Dispose();
		}

		private void listBox1_DragDrop( object sender, DragEventArgs e )
		{
			string[] s_array = (string[])e.Data.GetData( DataFormats.FileDrop, false );
			foreach( String s in s_array )
			{
				if( Directory.Exists( s ) )
				{
					int root_dir_start = s.LastIndexOfAny( new char[] { '/', '\\' } );
					if( root_dir_start >= 0 ) 
						ProjectData.project_data_set.NewProjectGroup( s, s.Substring( root_dir_start + 1 ) );
					else
						ProjectData.project_data_set.NewProjectGroup( s, s );
				}
			}
		}

		private void listBox1_DragOver( object sender, DragEventArgs e )
		{
		}

		private void listBox1_DragEnter( object sender, DragEventArgs e )
		{
			e.Effect = DragDropEffects.All;
		}
	}
}
