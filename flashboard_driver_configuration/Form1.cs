using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace flashboard_driver_configuration
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

		class EditableItem
		{
			String name;
			Control page;
			internal EditableItem( String name, Control page )
			{
				this.name = name;
				this.page = page;
			}
			public override string ToString()
			{
				return name;
			}
		}

        private void Form1_Load( object sender, EventArgs e )
        {
            listBox1.Items.Add( new EditableItem( "Prize Board", tabPage1 ) );
			listBox1.Items.Add( new EditableItem( "Network Flashboard", tabPage1 ) );
			listBox1.Items.Add( new EditableItem( "UDP", tabPage1 ) );
			listBox1.Items.Add( new EditableItem( "TCP", tabPage1 ) );

		}
    }
}
