using System;
using System.Data;
using System.Windows.Forms;
using xperdex.classes;

namespace CMakeProjectManager
{
	public partial class EditProjectGroup : Form
	{
		DataRow project_group;
		public EditProjectGroup( DataRow project_group )
		{
			this.project_group = project_group;
			InitializeComponent();
		}

		private void EditProjectGroup_Load( object sender, EventArgs e )
		{
			listBox1.DataSource = ProjectData.project_data_set.Projects;
			listBox1.DisplayMember = ProjectData.project_data_set.Projects.nameColumn.ColumnName;
			listBox1.ValueMember = ProjectData.project_data_set.Projects.project_idColumn.ColumnName;
		}

		private void button1_Click( object sender, EventArgs e )
		{
			String project = QueryNewName.Show( "Enter new project name" );
			if( project != null && project.Length > 1 )
				ProjectData.project_data_set.NewProject( project_group, project );

		}

		private void button2_Click( object sender, EventArgs e )
		{
			EditProject ep = new EditProject();
			ep.ShowDialog();
			ep.Dispose();

		}
	}
}
