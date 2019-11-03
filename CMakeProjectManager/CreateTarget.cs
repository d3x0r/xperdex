using System;
using System.Data;
using System.Windows.Forms;

namespace CMakeProjectManager
{
	public partial class CreateTarget : Form
	{
		public CreateTarget()
		{
			InitializeComponent();
		}

		public static DataRow Show( DataRow project )
		{
			CreateTarget ct = new CreateTarget();
			ct.textBox1.Text = project["name"] as String;
			ct.ShowDialog();
			if( ct.DialogResult == DialogResult.OK )
			{
				DataRow newrow = ProjectData.project_data_set.NewTarget( project, ct.textBox1.Text );
				newrow["target_type"] = ct.comboBox1.SelectedItem;
				newrow.Table.AcceptChanges();
				return newrow;
			}
			return null;
		}

		private void CreateTarget_Load( object sender, EventArgs e )
		{
			comboBox1.Items.Add( ProjectDataSet.ProjectTypes.DynamicLibrary );
			comboBox1.Items.Add( ProjectDataSet.ProjectTypes.ConsoleExecutable );
			comboBox1.Items.Add( ProjectDataSet.ProjectTypes.WindowedExecutable );
			comboBox1.Items.Add( ProjectDataSet.ProjectTypes.PluginLibrary );
			comboBox1.Items.Add( ProjectDataSet.ProjectTypes.StaticLibrary );
			comboBox1.SelectedItem = ProjectDataSet.ProjectTypes.ConsoleExecutable;
		}

		private void buttonOk_Click( object sender, EventArgs e )
		{
			DialogResult = System.Windows.Forms.DialogResult.OK;
			Close();
		}

		private void buttonCancel_Click( object sender, EventArgs e )
		{
			DialogResult = System.Windows.Forms.DialogResult.Cancel;
			Close();

		}
	}
}
