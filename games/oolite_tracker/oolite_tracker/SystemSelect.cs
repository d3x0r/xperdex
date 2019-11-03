using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using xperdex.classes;

namespace oolite_tracker
{
	public partial class SystemSelect : ToolStripComboBox
	{
		public SystemSelect()
		{
			InitializeComponent();
			Items.Add( "<New>" );
			//Items.AddRange(Local.Systems.ToArray());
		}



		protected override void OnPaint( PaintEventArgs pe )
		{
			// TODO: Add custom paint code here

			// Calling the base class OnPaint
			base.OnPaint( pe );
		}

		private void CreateOrFindSystem( object sender, EventArgs e )
		{
			if( String.Compare( SelectedItem.ToString(), "<New>" ) == 0 )
			{
				QueryNewName name = new QueryNewName( "Enter new SyStem Name" );
				name.ShowDialog();
				if( name.DialogResult == DialogResult.OK )
				{
					Oolite_System_Info info = Local.AddSystem( name.textBox1.Text );
					Items.Add( info );
				}
			}
		}
	}
	public partial class CommoditySelect : ToolStripComboBox
	{
		public CommoditySelect()
		{
			this.SelectedIndexChanged += new System.EventHandler( this.CreateOrFindCommodity );

			Items.Add( "<New>" );
			//Items.AddRange(Local.Systems.ToArray());
		}



		protected override void OnPaint( PaintEventArgs pe )
		{
			// TODO: Add custom paint code here

			// Calling the base class OnPaint
			base.OnPaint( pe );
		}

		private void CreateOrFindCommodity( object sender, EventArgs e )
		{
			if( String.Compare( SelectedItem.ToString(), "<New>" ) == 0 )
			{
				QueryNewName name = new QueryNewName( "Enter new Commodity Name" );
			
				name.ShowDialog();
				if( name.DialogResult == DialogResult.OK )
				{
					Commodity info = Local.AddCommodity( name.textBox1.Text );
					Items.Add( info );
				}
			}
		}
	}
}
