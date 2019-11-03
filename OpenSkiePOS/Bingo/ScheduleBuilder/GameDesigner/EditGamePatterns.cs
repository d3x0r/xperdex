using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ScheduleBuilder.GameDesigner
{
    public partial class EditGamePatterns : Form
    {
        DataRow this_game;
        public EditGamePatterns()
        {
            InitializeComponent();
        }

        private void EditGamePatterns_Load( object sender, EventArgs e )
        {

        }

        public static void Show( DataRow game )
        {
            EditGamePatterns egp = new EditGamePatterns();
            egp.this_game = game;
            egp.ShowDialog();
            egp.Dispose();
        }
    }
}
