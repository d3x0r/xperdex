using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using xperdex.classes;
using OpenSkie.Scheduler.Controls.Controls.Forms;

namespace OpenSkieScheduler.Controls.Buttons
{
	public class ButtonAddCardswipeCalibrate : MyButton
	{

		public ButtonAddCardswipeCalibrate()
		{
			//ControlList.controls.Add(this);
		}


		protected override void OnClick(EventArgs e)
		{
			CardswipeCalibrateAddition cca = new CardswipeCalibrateAddition();

			if (cca.ShowDialog() == DialogResult.OK)
			{
				ControlList.data.cardswipe_calibrate_table.AddCardswipeNumber(cca.value);
			}

			cca.Dispose();	
		} 

	}

	public class ButtonDelCardswipeCalibrate : MyButton
	{
		public ButtonDelCardswipeCalibrate()
		{

		}

		protected override void OnClick(EventArgs e)
		{

			if (MessageBox.Show("Would you like to delete this item?",
				"Delete card number?", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				//We do whatever it is we do.
				ControlList.data.cardswipe_calibrate_table.Delete();
			}

			base.OnClick(e);
		}

	}

}

/*
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using xperdex.classes;


namespace OpenSkieScheduler.Controls.Buttons
{
	class ButtonAddCardswipeCalibrate : MyButton
	{
		public ButtonAddCardswipeCalibrate()
			
		{

		}


		protected override void OnClick(EventArgs e)
		{
			//if (allow_edit)
			//{
			//	ControlList.data.packs.DeletePack();
			//	ControlList.data.packs.AcceptChanges();
			//}
			base.OnClick(e);
		}
	}

	class ButtonDelCardswipeCalibrate : MyButton
	{
		public ButtonDelCardswipeCalibrate()
		{

		}

		protected override void OnClick(EventArgs e)
		{
			base.OnClick(e);
		}
	}
}
*/