using System;
using System.Windows.Forms;

namespace OpenSkiePOS
{
	public partial class ConfigureItemButton : Form
	{
		DepartmentInterface dept;
		POSButtonInterface button;
		POS_ItemButton real_button;

		public ConfigureItemButton( POS_ItemButton real_button, DepartmentInterface dept, POSButtonInterface button )
		{
			this.dept = dept;
			this.button = button;
			this.real_button = real_button;
			InitializeComponent();
		}

		private void ConfigureItemButton_Load( object sender, EventArgs e )
		{
			foreach( DepartmentInterface dept in POS.Local.Departments )
			{
				int tmp = listBox1.Items.Add( dept );
				if( dept == this.dept )
					listBox1.SelectedIndex = tmp;
			}
		}

		private void Okay_Click( object sender, EventArgs e )
		{
			DepartmentInterface new_dept = listBox1.SelectedItem as DepartmentInterface;
			POSButtonInterface tmp_button = button;
			if( new_dept != dept )
			{
				tmp_button = new_dept.GetItemForButton( real_button );
			}
			if( tmp_button == null )
				MessageBox.Show( "Failed to get button from department" );
			if( tmp_button.Configure() )
			{
				real_button.department = new_dept;
				real_button.button = tmp_button;

				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			else
			{

			}
		}

		private void button1_Click( object sender, EventArgs e )
		{
			DepartmentInterface new_dept = listBox1.SelectedItem as DepartmentInterface;
			new_dept.Configure();
		}

		private void Cancel_Click( object sender, EventArgs e )
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();

		}

	}
}
