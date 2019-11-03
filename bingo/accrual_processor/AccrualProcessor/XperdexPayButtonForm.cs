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
	public partial class XperdexPayButtonForm : Form
	{
		ButtonDoPayout this_button;
		internal XperdexPayButtonForm( ButtonDoPayout button )
		{
			this.this_button = button;
			InitializeComponent();
		}

		private void XperdexPayButtonForm_Load( object sender, EventArgs e )
		{
			listBoxAccrualGroup.DataSource = Local.accrual_group_table;
			listBoxAccrualGroup.DisplayMember = AccrualGroup.AccrualGroupTable.NameColumn;
			listBoxAccrualGroup.ValueMember = AccrualGroup.AccrualGroupTable.PrimaryKey;
			checkBoxPayKitty.Checked = this_button.pay_from_kitty;

			if( this_button._group_index >= 0 && this_button._group_index < Local.known_accrual_groups.Count ) 
				listBoxAccrualGroup.SelectedIndex = this_button._group_index;
			/*
			if( Local.known_accrual_groups[this_button._group_index] != null )
			{
				DataRow[] rows = Local.accrual_group_table.Select( AccrualGroup.AccrualGroupTable.NameColumn + "='" + Local.known_accrual_groups[this_button._group_index].Name + "'" );
				if( rows.Length > 0 )
					listBoxAccrualGroup.SelectedValue = rows[0][AccrualGroup.AccrualGroupTable.PrimaryKey];
			}
			 */
			if( this_button.button == null )
				textBoxButtonText.Visible = false;
			else
				textBoxButtonText.Text = this_button.button.Text;

			textBoxPayPercent.Text = this_button.percent.ToString();
			textBoxPayAmount.Text = this_button.pay_value.ToString( "C" );
		}

		private void buttonOk_Click( object sender, EventArgs e )
		{
			int num;
			decimal payval;
			this_button.pay_from_kitty = checkBoxPayKitty.Checked;
			{
				if( int.TryParse( textBoxPayPercent.Text, out num ) )
				{
					this_button.percent = num;
				}
				else
				{
					MessageBox.Show( "Bad percent setting" );
					return;
				}
			}
			if( Decimal.TryParse( textBoxPayAmount.Text, System.Globalization.NumberStyles.Currency, null, out payval ) )
			{
				this_button.pay_value = payval;
			}
			else
			{
				MessageBox.Show( "Bad payout value setting" );
				return;
			}
			this_button.group_index = listBoxAccrualGroup.SelectedIndex;
			/*
			this_button.group_name = ( listBoxAccrualGroup.SelectedItem as DataRowView ).Row[AccrualGroup.AccrualGroupTable.NameColumn].ToString();
			if( this_button._group_name == null )
			{
				MessageBox.Show( "Bad selection of accrual group" );
				return;
			}
			 */
			this_button.percent = num;
			if( this_button.button != null )
				this_button.button.Text = textBoxButtonText.Text;
			this.Close();
		}

		private void listBoxAccrualGroup_SelectedIndexChanged( object sender, EventArgs e )
		{

		}


	}
}
