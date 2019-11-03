using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using xperdex.gui;
using xperdex.core.interfaces;

namespace xperdex.core
{
    public partial class PageProperties : Form
    {
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		page that;

        public PageProperties( page edit_page )
        {
			that = edit_page;
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

		private void pickfile_MouseClick( object sender, EventArgs e )
        {
			if( this.openFileDialog1 == null )
				this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.openFileDialog1.InitialDirectory = Environment.CurrentDirectory;
			this.openFileDialog1.FileName = this.textBox3.Text;
			if( this.textBox3.Text.IndexOfAny( new char[]{ '/', '\\' } ) > 0 )
			{
				int file_index;
				string subpath = this.textBox3.Text.Substring( 0, file_index = this.textBox3.Text.LastIndexOfAny( new char[]{'/','\\'} ) );
				this.openFileDialog1.InitialDirectory += "/" + subpath;
				this.openFileDialog1.FileName = this.textBox3.Text.Substring( file_index + 1 );
			}
            this.openFileDialog1.ShowDialog( this );
			String result = this.openFileDialog1.FileName;
			if (result != null)
            {
				if( result.Contains( Environment.CurrentDirectory ) )
					result = result.Substring( Environment.CurrentDirectory.Length + 1 );            
                this.textBox3.Text = result;
            }
        }

		private void PageProperties_Load( object sender, EventArgs e )
		{
			this.listBoxSecurity.DataSource = core_common.security_modules;
			//this.listBoxSecurity.DisplayMember = "Name";
			this.textBoxPageTitle.Text = that.Name;
			textBox1.Text = Convert.ToString( that.partsX );
			textBox2.Text = Convert.ToString( that.partsY );
			textBox3.Text = that.background_name;
			colorWell1.color = that.background_color;
		}

		private void buttonConfigureSecurity_Click( object sender, EventArgs e )
		{
			bool found = false;
			if( listBoxSecurity.SelectedItem == null )
			{
				MessageBox.Show( "Must Select a security module to configure..." );
				return;
			}
			Type t = ( listBoxSecurity.SelectedItem as TypeName ).Type;
			foreach( object s in that.security_tags )
			{
				if( s.GetType() == t )
				{
					// already have that tag created, so edit it.
					IReflectorPersistance persis = s as IReflectorPersistance;
					if( persis != null )
					{
						// maybe mark this security module as using this ?
						persis.Properties();
					}
					found = true;
				}
			}
			if( !found )
			{
				// didn't have that tag associated with the page yet, so create one
				object o = Activator.CreateInstance( t );
				that.security_tags.Add( o as IReflectorSecurity );
				IReflectorPersistance persis = o as IReflectorPersistance;
				if( persis != null )
				{
					// and configure its properties
					persis.Properties();
				}
			}

		}

		private void Okay_Click( object sender, EventArgs e )
		{
			that.Name = this.textBoxPageTitle.Text;
		}


    }
}