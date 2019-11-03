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
	public partial class PayoutForm : Form
	{
		bool allow_percentage_edit;
		private AccrualGroup group;
		internal int percent;
		private decimal total_prize;
		private decimal total_start;
		private int winners;
		private decimal split_prize;
		internal decimal payout;
		internal int pay_count;
		bool using_kitty;
		internal Decimal initial_payout;
		private AccrualGroup.Accrument accrual;

		public PayoutForm()
		{
			InitializeComponent();
		}

		void ComputePayout(  )
		{
			if( using_kitty )
			{
				object _val = Local.dataConnection.ExecuteScalar( "select sum(kitty) from ap_accrument" );
				Decimal val = (Decimal)_val;
				total_start = val;
			}
			else
			{
				if( initial_payout > 0 )
					total_start = initial_payout;
				else
					total_start = accrual == null ? 0M
						: group.this_row.RowState == DataRowState.Unchanged
						   ? accrual.primary_end
						   : accrual.primary_start == 0
								? accrual.primary_start + accrual.primary_seed
								: accrual.primary_start;
			}
			total_prize = ( total_start * percent ) / 100;
			decimal rounder = total_prize % 1;
			if( rounder > 0 )
				total_prize -= rounder;
		}

		internal PayoutForm( AccrualGroup group, int percent, Decimal initial_split, bool use_kitty = false )
		{
			// TODO: Complete member initialization
			this.group = group;
			this.percent = percent;
			this.accrual = group.prior_accrument;
			this.accrual.pay_percent = percent;
			this.initial_payout = initial_split;
			allow_percentage_edit = false;
			winners = 1;
			using_kitty = use_kitty;
			ComputePayout( );
			InitializeComponent();
		}

		internal PayoutForm( AccrualGroup group, AccrualGroup.Accrument accrual )
		{
			// TODO: Complete member initialization
			this.group = group;
			this.accrual = accrual;
			this.percent = this.accrual.pay_percent;
			if( this.percent == 0 )
				this.percent = 100;
			if( accrual.pay_count > 0 )
				winners = accrual.pay_count;
			else
				winners = 1;
			total_start = group.GetPostedvalue();
			initial_payout = group.GetPostedvalue();
			total_prize = accrual.pay;
			allow_percentage_edit = true;
			ComputePayout();
			InitializeComponent();
		}

		void FillFields()
		{
			textBoxPrizeAmount.Text = total_start.ToString( "C" );
			textBoxWinners.Text = winners.ToString();
			textBoxPrizePercent.Text = percent.ToString();
			textBoxBasePay.Text = total_prize.ToString( "C" );
			labelAccrualName.Text = group.Name;
		}

		private void PayoutForm_Load( object sender, EventArgs e )
		{
			FillFields();
			if( allow_percentage_edit )
				textBoxPrizePercent.ReadOnly = false;
		}

		private void textBoxPrizeAmount_TextChanged( object sender, EventArgs e )
		{
			decimal value;
			if( decimal.TryParse( textBoxPrizeAmount.Text, out value ) )
			{
				DialogResult msgresult = MessageBox.Show( "Change winner payout to " + value.ToString( "C" ) + " from " + split_prize.ToString( "C" ), "Confirm", MessageBoxButtons.YesNo );
				if( msgresult == System.Windows.Forms.DialogResult.Yes )
				{
					split_prize = value;
					textBoxSplitAmount.Text = split_prize.ToString( "C" );
					labelTotalPay.Text = ( winners * split_prize ).ToString( "C" );
				}
			}
		}

		private void UpdatePrizeTotal()
		{
			if( checkBoxSplitWin.Checked )
			{
				split_prize = total_prize;
			}
			else
			{
				Decimal rounder;
				split_prize = total_prize / winners;
				rounder = split_prize % 1;
				if( rounder > 0 )
					split_prize += 1 - rounder;
			}
			textBoxSplitAmount.Text = split_prize.ToString( "C" );
			labelTotalPay.Text = ( winners * split_prize ).ToString( "C" );
		}

		private void checkBoxSplitWin_CheckedChanged( object sender, EventArgs e )
		{
			UpdatePrizeTotal();
		}

		private void textBoxWinners_TextChanged( object sender, EventArgs e )
		{
			int tmp;
			String tmpwinners = textBoxWinners.Text;
			if( tmpwinners.Length > 0 )
				if( Int32.TryParse( textBoxWinners.Text, out tmp ) )
				{
					if( tmp > 0 )
					{
						winners = tmp;
						UpdatePrizeTotal();
					}
					else
					{
						MessageBox.Show( "Invalid winner count entered" );
						textBoxWinners.Text = winners.ToString();
					}
				}
				else
					MessageBox.Show( "Format error in winner text box; not a number" );
		}

		private void buttonCancel_Click( object sender, EventArgs e )
		{
			this.DialogResult = buttonCancel.DialogResult;
			this.Close();
		}

		private void buttonPay_Click( object sender, EventArgs e )
		{
			if( Int32.TryParse( textBoxWinners.Text, out pay_count )
				&& Decimal.TryParse( textBoxSplitAmount.Text, System.Globalization.NumberStyles.Currency, null, out payout ) )
			{
				this.DialogResult = buttonPay.DialogResult;
				this.Close();
			}
		}

		private void textBoxSplitAmount_TextChanged( object sender, EventArgs e )
		{
			if( Decimal.TryParse( textBoxSplitAmount.Text, System.Globalization.NumberStyles.Currency, null, out payout ) )
			{
				this.split_prize = payout;
				//textBoxSplitAmount.Text = split_prize.ToString( "C" );
				labelTotalPay.Text = ( winners * split_prize ).ToString( "C" );
			}

		}

		private void textBoxPrizePercent_TextChanged( object sender, EventArgs e )
		{
			int newval;
			if( Int32.TryParse( textBoxPrizePercent.Text, System.Globalization.NumberStyles.Currency, null, out newval ) )
			{
				this.percent = newval;
				ComputePayout();
				FillFields();
				UpdatePrizeTotal();
			}
		}
	}
}
