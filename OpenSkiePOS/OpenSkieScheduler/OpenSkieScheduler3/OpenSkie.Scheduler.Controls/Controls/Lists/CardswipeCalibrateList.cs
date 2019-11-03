
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using OpenSkieScheduler.Relations;
using System.Data;




namespace OpenSkieScheduler.Controls.Lists
{
	public class CardswipeCalibrateList : MyListBox
	{
		public CardswipeCalibrateList() 
		{
			this.DataSource = ControlList.data.cardswipe_calibrate_table;
			this.DisplayMember = OpenSkieScheduler.Relations.CardswipeCalibrateTable.CardData;

			SetCurrent += new SetCurrentMethod(ControlList.data.SetCurrentCardswipeCalibrate);
		}
	}
}


