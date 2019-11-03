using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using xperdex.classes;

namespace OpenSkie.Scheduler.Controls.Controls.Forms
{
	public partial class CardswipeCalibrateAddition : Form
	{

		private UInt64 vals;  


		public UInt64 value
		{
			get
			{
				return vals; 
			}
			set
			{
				vals = value;
				textBoxValue.Text = value.ToString();
			}

		}

		public CardswipeCalibrateAddition()
		{
			InitializeComponent();
			value = 0;
		}

		public CardswipeCalibrateAddition(UInt64 initialvalue)
			: this()
		{
			value = initialvalue;
		}


		private void ButtonOk_Click(object sender, EventArgs e)
		{
			try
			{
				vals = System.Convert.ToUInt32(textBoxValue.Text.ToString());
			}
			catch (Exception cardswipe_calibrate_exception)
			{
				Log.log("Value conversion fail in calibrate adder dialog");
			}

			//this.Close();
		}


	}
}