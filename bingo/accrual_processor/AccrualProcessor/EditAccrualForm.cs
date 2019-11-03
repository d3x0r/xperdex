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
	internal partial class EditAccrualForm : Form
	{
		AccrualGroup group;
		AccrualGroup.Accrument accrual;

		internal EditAccrualForm( AccrualGroup group, AccrualGroup.Accrument accrual )
		{
			this.group = group;
			this.accrual = accrual;
			InitializeComponent();
		}

		void FillFields( Control not_control = null )
		{
			if( not_control != textBoxSales )
				textBoxSales.Text = accrual.Input.ToString( "C" );
			labelHouse.Text = "House (" + accrual.house_percent.ToString() + "%)";
			textBoxHouse.Text = accrual.house.ToString( "C" );

			textBoxPrimaryStart.Text = accrual.primary_start.ToString( "C" );
			labelPrimarySales.Text = "Sales (" + accrual.primary_percent.ToString() + "%)";
			textBoxPrimarySales.Text = accrual.primary_sales.ToString( "C" );
			textBoxBackupRollover.Text = accrual.primary_rollover.ToString( "C" );
			textBoxPrimarySeed.Text = accrual.primary_seed.ToString( "C" );
			textBoxPrimaryTransfer.Text = accrual.primary_transfer.ToString( "C" );
			textBoxPayout.Text = ( accrual.pay_count * accrual.pay ).ToString( "C" );
			textBoxBallStart.Text = accrual.ball_start.ToString();
			textBoxBallEnd.Text = accrual.ball_end.ToString();
			checkBoxPost.Checked = accrual.posted;
			checkBoxClosed.Checked = accrual.closed;
			if( not_control != textBoxPrimaryEnd )
				textBoxPrimaryEnd.Text = accrual.primary_end.ToString( "C" );

			textBoxPayCount.Text = accrual.pay_count.ToString();
			textBoxPayout.Text = accrual.pay.ToString();

			textBoxSecondaryStart.Text = accrual.secondary_start.ToString( "C" );
			labelSecondarySales.Text = "Sales (" + accrual.secondary_percent.ToString() + "%)";
			textBoxSecondarySales.Text = accrual.secondary_sales.ToString( "C" );
			textBoxTertiaryRollover.Text = accrual.secondary_rollover.ToString( "C" );
			textBoxSecondaryTransfer.Text = accrual.secondary_transfer.ToString( "C" );
			if( not_control != textBoxSecondaryEnd )
				textBoxSecondaryEnd.Text = accrual.secondary_end.ToString( "C" );

			textBoxTertiaryStart.Text = accrual.tertiary_start.ToString( "C" );
			labelTertiarySales.Text = "Sales (" + accrual.secondary_percent.ToString() + "%)";
			textBoxTertiarySales.Text = accrual.tertiary_sales.ToString( "C" );
			textBoxTertiaryTransfer.Text = accrual.tertiary_transfer.ToString( "C" );
			textBoxRemainingSales.Text = ( accrual.input - accrual.house ).ToString( "C" );
			if( not_control != textBoxTertiaryEnd )
				textBoxTertiaryEnd.Text = accrual.tertiary_end.ToString( "C" );
		}

		private void EditAccrualForm_Load( object sender, EventArgs e )
		{
			Text = "Edit Accrual : " + group.Name + " in " + accrual.session_name + " on " + accrual.session_date;
			if( !Local.ConfigureState.use_tertiary )
			{
				groupBox3.Visible = false;
				textBoxTertiaryRollover.Visible = false;
				labelTertiaryRollover.Visible = false;
			}

			FillFields();
		}

		private void buttonOk_Click( object sender, EventArgs e )
		{
			Local.accrument_table.SyncAccrument( accrual );

			Local.Refresh();
			Local.CommitChanges( true );
		}

		private void button2_Click( object sender, EventArgs e )
		{
			filling = true;
			accrual.Process();
			FillFields();
			filling = false;
		}

		private void button1_Click( object sender, EventArgs e )
		{
			PayoutForm payform = new PayoutForm( group, accrual );
			payform.ShowDialog();
			if( payform.DialogResult == System.Windows.Forms.DialogResult.OK )
			{
				group.Payout( accrual, payform.pay_count, payform.percent, payform.payout, false );
				FillFields();
				checkBoxPost.Checked = accrual.posted;
				checkBoxClosed.Checked = accrual.closed;
			}
			payform.Dispose();
		}

		private void buttonClearPayout_Click( object sender, EventArgs e )
		{
			accrual.pay_count = 0;
			accrual.pay = 0M;
			accrual.pay_percent = 0;
			accrual.primary_rollover = 0M;
			accrual.secondary_rollover = 0M;
			accrual.primary_seed = 0;
			accrual.secondary_seed = 0;
			accrual.tertiary_seed = 0;
			accrual.DoMath();
			FillFields( null );
		}

		bool filling;

		private void textBoxPrimaryEnd_TextChanged( object sender, EventArgs e )
		{
			Decimal val;
			if( filling )
				return;
			if( Decimal.TryParse( textBoxPrimaryEnd.Text, System.Globalization.NumberStyles.Currency, null, out val ) )
			{
				accrual.primary_end = val;
				accrual.primary_transfer = val -
					( accrual.primary_start
					+ accrual.primary_seed
					+ accrual.primary_rollover
					+ accrual.primary_fixup
					- ( accrual.pay_count * accrual.pay )
					+ accrual.primary_sales );
				filling = true;
				FillFields( textBoxPrimaryEnd );
				filling = false;
			}
		}

		private void textBoxSecondaryEnd_TextChanged( object sender, EventArgs e )
		{
			Decimal val;
			if( filling )
				return;
			if( Decimal.TryParse( textBoxSecondaryEnd.Text, System.Globalization.NumberStyles.Currency, null, out val ) )
			{
				accrual.SetSecondaryValue( val );
				filling = true;
				FillFields( textBoxSecondaryEnd );
				filling = false;
			}

		}

		private void textBoxTertiaryEnd_TextChanged( object sender, EventArgs e )
		{
			Decimal val;
			if( filling )
				return;
			if( Decimal.TryParse( textBoxTertiaryEnd.Text, System.Globalization.NumberStyles.Currency, null, out val ) )
			{
				accrual.tertiary_end = val;
				accrual.tertiary_transfer = val -
					( accrual.tertiary_start
					+ accrual.tertiary_seed
					- accrual.secondary_rollover
					+ accrual.tertiary_sales );
				filling = true;
				FillFields( textBoxTertiaryEnd );
				filling = false;
			}
		}

		private void checkBoxPost_CheckedChanged( object sender, EventArgs e )
		{
			accrual.posted = checkBoxPost.Checked;
		}

		private void checkBoxCountSet_CheckedChanged( object sender, EventArgs e )
		{
			if( accrual.ball_delta != 0 )
			{
				checkBoxCountSet.Checked = true;
			}
			accrual.ball_count_set = checkBoxCountSet.Checked;
		}

		private void textBox4_TextChanged( object sender, EventArgs e )
		{
			Int32 val;
			if( filling )
				return;
			if( Int32.TryParse( textBoxBallEnd.Text, out val ) )
			{
				accrual.ball_end = val;
				accrual.ball_delta = val - accrual.ball_start;
				if( accrual.ball_delta != 0 )
					checkBoxCountSet.Checked = true;
				else
					checkBoxCountSet.Checked = false;
			}
		}

		private void checkBoxUnlockSales_CheckedChanged( object sender, EventArgs e )
		{
			textBoxSales.ReadOnly = !checkBoxUnlockSales.Checked;
		}

		private void textBoxSales_TextChanged( object sender, EventArgs e )
		{
			Decimal val;
			if( filling )
				return;
			if( Decimal.TryParse( textBoxSales.Text, System.Globalization.NumberStyles.Currency, null, out val ) )
			{
				accrual.input = val;
				accrual.Process();
				filling = true;
				FillFields( textBoxSales );
				filling = false;
			}
		}

		private void checkBoxClosed_CheckedChanged( object sender, EventArgs e )
		{
			accrual.closed = checkBoxClosed.Checked;
		}

		private void buttonReloadSales_Click( object sender, EventArgs e )
		{
			Local.ProcessAccrualGroupAccrument( group, accrual );
			filling = true;
			FillFields();
			filling = false;
		}

	}
}
