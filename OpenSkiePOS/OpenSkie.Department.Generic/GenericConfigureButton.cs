using System;
using System.Windows.Forms;

namespace OpenSkie.Department.Generic
{
	public partial class GenericConfigureButton : Form
	{
		GenericButton button;
		public GenericConfigureButton(GenericButton button)
		{
			this.button = button;
			InitializeComponent();
		}

		private void GenericConfigureButton_Load( object sender, EventArgs e )
		{

		}

		private void button1_Click( object sender, EventArgs e )
		{
			this.Close();
		}

		private void button2_Click( object sender, EventArgs e )
		{
			this.Close();
		}

		private void listBox1_SelectedIndexChanged( object sender, EventArgs e )
		{

		}

		private void button3_Click( object sender, EventArgs e )
		{
			
		}
	}
}
