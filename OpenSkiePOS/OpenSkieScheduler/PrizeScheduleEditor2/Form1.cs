using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OpenSkieScheduler3;

namespace PrizeScheduleEditor
{
    public partial class Form1 : Form
    {

		public Form1( ScheduleDataSet schedule )
		{
            OpenSkieScheduler3.Controls.ControlList.schedule = schedule;

			InitializeComponent();

		}

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

		private void button1_Click( object sender, EventArgs e )
		{
			xperdex.classes.OptionEditor oe = new xperdex.classes.OptionEditor();
			oe.ShowDialog();
			oe.Dispose();
		}

    }
}