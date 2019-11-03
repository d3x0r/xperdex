using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using xperdex.classes.Types;

namespace OpenSkieScheduler3.Controls.Forms
{
	public partial class ColorEditor : Form
	{
		public ColorEditor()
		{
			InitializeComponent();
		}

		DataRowView prior_selection;

		private void ColorEditor_Load( object sender, EventArgs e )
		{
            listBox1.DataSource = ControlList.schedule.colors;
			listBox1.DisplayMember = ColorInfoTable.NameColumn;
		}

		bool updating;
		private void listBox1_SelectedIndexChanged( object sender, EventArgs e )
		{
			if( updating )
				return;
			updating = true;
			if( prior_selection != null )
			{
				if( String.Compare( prior_selection.Row[ColorInfoTable.NameColumn].ToString(), textBox1.Text ) != 0 )
					prior_selection.Row[ColorInfoTable.NameColumn] = textBox1.Text;

				if( prior_selection.Row["color"] == DBNull.Value )
					prior_selection.Row["color"] = new XColor( colorWell1.color );
				else if( ((XColor)prior_selection.Row["color"]) != colorWell1.color )
					prior_selection.Row["color"] =  new XColor( colorWell1.color );
			}
			DataRowView drv = ( listBox1.SelectedItem as DataRowView );
			textBox1.Text = drv.Row[ColorInfoTable.NameColumn].ToString();
			if( drv.Row["color"] == DBNull.Value )
				colorWell1.color = Color.White;
			else
				colorWell1.color = (XColor)drv.Row["color"] ;
			prior_selection = drv;
			updating = false;
		}
	}
}