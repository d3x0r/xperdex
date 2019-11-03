using System;
using System.Windows.Forms;

namespace xperdex.core.common
{
	public partial class Keypad_Configurator : Form
	{
		String selected_keypad_type;
		PSI_Keypad keypad;
		public Keypad_Configurator( PSI_Keypad keypad )
		{
			this.keypad = keypad;
			InitializeComponent();
		}

		private void Keypad_Configurator_Load( object sender, EventArgs e )
		{
			listBox1.DataSource = Keypads.KeypadTypes;

		}

		private void listBox1_SelectedIndexChanged( object sender, EventArgs e )
		{
			selected_keypad_type = listBox1.SelectedItem as string;
		}

		private void button1_Click( object sender, EventArgs e )
		{
			keypad.Name = selected_keypad_type;
			DialogResult = System.Windows.Forms.DialogResult.OK;
			this.Close();
		}
		private void button2_Click( object sender, EventArgs e )
		{
			DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Close();
		}

	}
}
