using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OpenSkieScheduler;

namespace ScheduleBuilder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load( object sender, EventArgs e )
        {

            Local.schedule = new OpenSkieScheduler.ScheduleDataSet();
            Local.schedule.Fill();
            listBox1.DataSource = Local.schedule.sessions;
            listBox1.DisplayMember = SessionTable.NameColumn;
            listBox1.ValueMember = SessionTable.PrimaryKey;
        }

        private void button1_Click( object sender, EventArgs e )
        {

        }
    }
}
