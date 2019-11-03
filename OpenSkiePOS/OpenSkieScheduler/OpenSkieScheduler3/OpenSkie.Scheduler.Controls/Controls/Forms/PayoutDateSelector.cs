using System;
using System.Windows.Forms;

namespace OpenSkieScheduler3.Controls.Forms
{
	public partial class PayoutDateSelector : Form
	{
		public PayoutDateSelector()
		{
			InitializeComponent();
		}

		private void button1_Click( object sender, EventArgs e )
		{
			this.DialogResult = DialogResult.OK;
		}

		internal static DateTime SelectDate()
		{
			PayoutDateSelector pds = new PayoutDateSelector();
			pds.ShowDialog();
			if( pds.DialogResult == DialogResult.OK )
			{
				if( pds.monthCalendar1.SelectedDates.Count > 0 )
					return pds.monthCalendar1.SelectedDates[0];	
			}
			return DateTime.MinValue;
		}
	}
}