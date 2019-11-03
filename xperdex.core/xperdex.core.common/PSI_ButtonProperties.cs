using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using xperdex.core.interfaces;
using xperdex.gui;
using System.Data;

namespace xperdex.core
{
	public partial class PSI_ButtonProperties: Form
	{
		private PSI_Button that;
		private Canvas canvas;

		public PSI_ButtonProperties( PSI_Button _that, Canvas _canvas )
		{
			that = _that;
			canvas = _canvas;
			InitializeComponent();
		}

		public void Apply()
		{
			that.gs.images = this.ButtonStyle.SelectedItem as GlareSetData;
			that.security_tags.Clear();

			//that.security_tags.Add( 
			//that.gs.attrib.Primary = this.Background1.color;
			//that.gs.attrib.Secondary = this.Background2.color;
			//that.gs.attrib.PrimaryHighlight = this.Highlight1.color;
			//that.gs.attrib.SecondaryHighlight = this.Highlight2.color;
			//that.gs.attrib.DecalScale = this.trackBarDecalScale.Value;
			//that.gs.attrib.TextColor = this.TextColor.color;
			that.DecalScale = trackBarDecalScale.Value;
			that.SetDecalName( textBox2.Text );
			that.Text = this.textBox1.Text;
			that.gs.attrib = listBoxButtonAttributes.SelectedItem as GlareSetAttributes;
			if( this.GotoPage.Checked )
			{
				DataRowView drv = this.Pages.SelectedItem as DataRowView;
				if( drv != null )
					that.NextPage = drv.Row["page_name"].ToString();
			}
			else
				that.NextPage = null;
			that.AllowShowUsers.Clear();
			foreach( object o in listBox1.Items )
			{
				that.AllowShowUsers.Add( o as string );
			}
			that.CheckAllowedShow();
		}

		~PSI_ButtonProperties()
		{
		}

		private void button6_Click( object sender, EventArgs e )
		{

		}

		private void listBox1_SelectedIndexChanged( object sender, EventArgs e )
		{

		}

		private void PSI_ButtonProperties_Load( object sender, EventArgs e )
		{
			this.SuspendLayout();
			this.ButtonStyle.DataSource = core_common.glaresets;

			DataTable page_table = new DataTable();
			page_table.Columns.Add( "page_name", typeof( String ) );
			page_table.Columns.Add( "page", typeof( page ) );
			DataRow row;
			int selected_index = -1;
			int idx;

			row = page_table.NewRow();
			row["page_name"] = "<First>";
			page_table.Rows.Add( row );
			if( that.NextPage != null && String.Compare( that.NextPage, "<First>" ) == 0 )
				selected_index = 0;

			row = page_table.NewRow();
			row["page_name"] = "<Previous>";
			page_table.Rows.Add( row );
			if( that.NextPage != null && String.Compare( that.NextPage, "<Previous>" ) == 0 )
				selected_index = 1;

			row = page_table.NewRow();
			row["page_name"] = "<Next>";
			page_table.Rows.Add( row );
			if( that.NextPage != null && String.Compare( that.NextPage, "<Next>" ) == 0 )
				selected_index = 2;

			row = page_table.NewRow();
			row["page_name"] = "<Prior>";
			page_table.Rows.Add( row );
			if( that.NextPage != null && String.Compare( that.NextPage, "<Prior>" ) == 0 )
				selected_index = 3;

			idx = 4;
			foreach( page page in canvas.pages )
			{
				row = page_table.NewRow();
				row["page_name"] = page.Name;
				row["page"] = page;
				page_table.Rows.Add( row );
				if( that.NextPage != null && String.Compare( that.NextPage, page.Name ) == 0 )
					selected_index = idx;
				idx++;
			}
			this.Pages.DataSource = page_table;
			this.Pages.DisplayMember = "page_name";
			this.Pages.SelectedIndex = selected_index;

			this.Security.DataSource = core_common.security_modules;
			if( core_common.security_modules.Count > 0 )
			{
				//this.Security.DisplayMember = "Name";
				//this.Security.SelectedItem = that.security_tags[0].
			}
			this.Allow.DataSource = that.AllowShow;
			this.Disallow.DataSource = that.DisallowShow;
			this.Systems.DataSource = core_common.systems;
			this.textBox1.Text = that.Text;
			this.textBox2.Text = that.decal_name;
			this.ButtonStyle.SelectedItem = that.gs.images;
			this.ResumeLayout();
			this.trackBarDecalScale.Minimum = 20;
			this.trackBarDecalScale.Maximum = 100;
			if( that.DecalScale < 20 )
				that.DecalScale = 100;
			else if( that.DecalScale > 100 )
				that.DecalScale = 100;
			this.trackBarDecalScale.Value = that.DecalScale;

			this.listBoxButtonAttributes.DataSource = core_common.glare_attribs;
			listBoxButtonAttributes.SelectedItem = that.gs.attrib;

			if( that.NextPage != null )
				this.GotoPage.Checked = true;

			foreach( String user in that.AllowShowUsers )
			{
				listBox1.Items.Add( user );
			}
		}

		private void AddSystem_Click( object sender, EventArgs e )
		{
			string system = NewName.Text;

			foreach( String s in core_common.systems )
			{
				if( string.Compare( system, s, true ) == 0 )
				{
					system = null;
					break;
				}
			}
			if( system != null )
			{
				Systems.DataSource = null;
				core_common.systems.Add( system );

				Systems.DataSource = core_common.systems;
			}
		}

		private void AddAllow_Click( object sender, EventArgs e )
		{
			String system = (string)Systems.SelectedItem;
			foreach( String s in that.AllowShow )
			{
				if( string.Compare( system, s, true ) == 0 )
				{
					system = null;
					break;
				}
			}
			if( system != null )
			{
				Allow.DataSource = null;
				that.AllowShow.Add( system );
				that.AllowShow.Sort( new CaseInsensitiveComparer() as IComparer<string> );
				Allow.DataSource = that.AllowShow;
			}

		}

		private void AddDisallow_Click( object sender, EventArgs e )
		{
			String system = (string)Systems.SelectedItem;
			foreach( String s in that.DisallowShow )
			{
				if( string.Compare( system, s, true ) == 0 )
				{
					system = null;
					break;
				}
			}
			if( system != null )
			{
				Disallow.DataSource = null;
				that.DisallowShow.Add( system );
				that.DisallowShow.Sort( new CaseInsensitiveComparer() as IComparer<string> );
				Disallow.DataSource = that.DisallowShow;
			}
		}

		private void RemoveAllow_Click( object sender, EventArgs e )
		{
			int s = that.AllowShow.BinarySearch( (string)Allow.SelectedItem
				, new CaseInsensitiveComparer() as IComparer<string> );
			if( s >= 0 )
			{
				Allow.DataSource = null;
				that.AllowShow.RemoveAt( s );
				Allow.DataSource = that.AllowShow;
			}
		}

		private void RemoveDisallow_Click( object sender, EventArgs e )
		{
			int s = that.DisallowShow.BinarySearch( (string)Disallow.SelectedItem
				, new CaseInsensitiveComparer() as IComparer<string> );
			if( s >= 0 )
			{
				Disallow.DataSource = null;
				that.DisallowShow.RemoveAt( s );
				Disallow.DataSource = that.DisallowShow;
			}
		}

		private void EditSecurity_Click( object sender, EventArgs e )
		{
			bool found = false;
			if( Security.SelectedItem == null )
			{
				MessageBox.Show( "Must Select a security module to configure..." );
				return;
			}
			Type t = ( Security.SelectedItem as TypeName ).Type;
			foreach( object s in that.security_tags )
			{
				if( s.GetType() == t )
				{
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
				object o = Activator.CreateInstance( t );
				that.security_tags.Add( o );
				IReflectorPersistance persis = o as IReflectorPersistance;
				if( persis != null )
				{
					persis.Properties();
				}
			}
		}

		private void PickFont_Click( object sender, EventArgs e )
		{
			FontEditor fe = new FontEditor( that.FontTracker );
			fe.ShowDialog();
			if( fe.DialogResult == DialogResult.OK )
			{
				that.FontTracker = fe.GetFontResult();
			}
			fe.Dispose();
		}

		private void Systems_SelectedIndexChanged( object sender, EventArgs e )
		{

		}

		private void button2_Click( object sender, EventArgs e )
		{
			String s = xperdex.classes.QueryNewName.Show( "Enter User allowed to see this control" );
			if( s != null && s.Length > 0 )
			{
				listBox1.Items.Add( s );
			}
		}

		private void button1_Click( object sender, EventArgs e )
		{
			int selected = listBox1.SelectedIndex;
			if( selected >= 0 )
				listBox1.Items.RemoveAt( selected );
		}
	}
}