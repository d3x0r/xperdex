using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ECube.AccrualProcessor
{
	public partial class XperdexPostButtonForm : Form
	{
		ButtonDoPost this_button;
		internal XperdexPostButtonForm( ButtonDoPost button )
		{
			this.this_button = button;
			InitializeComponent();
		}

		private void XperdexPayButtonForm_Load( object sender, EventArgs e )
		{
			listBoxAccrualGroup.DataSource = Local.accrual_group_table;
			listBoxAccrualGroup.DisplayMember = AccrualGroup.AccrualGroupTable.NameColumn;
			listBoxAccrualGroup.ValueMember = AccrualGroup.AccrualGroupTable.PrimaryKey;
			if( this_button.group != null )
			{
				DataRow[] rows = Local.accrual_group_table.Select( AccrualGroup.AccrualGroupTable.NameColumn + "='" + this_button.group.Name + "'" );
				if( rows.Length > 0 )
					listBoxAccrualGroup.SelectedValue = rows[0][AccrualGroup.AccrualGroupTable.PrimaryKey];
			}
			if( this_button.button == null )
				textBoxButtonText.Visible = false;
			else
				textBoxButtonText.Text = this_button.button.Text;

		}

		private void buttonOk_Click( object sender, EventArgs e )
		{

			this_button.group = Local.known_accrual_groups[( listBoxAccrualGroup.SelectedItem as DataRowView ).Row[AccrualGroup.AccrualGroupTable.NameColumn].ToString()];
			if( this_button.group == null )
			{
				MessageBox.Show( "Bad selection of accrual group" );
				return;
			}
			if( this_button.button != null )
				this_button.button.Text = textBoxButtonText.Text;
			this.Close();
		}

	}
}
