using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ScheduleBuilder.GameDesigner
{
    public partial class GameBuilder : Form
    {
        List<OpenSkie.Scheduler.Controls.Controls.Forms.GameDesigner.GameData> games;

        public GameBuilder( DataRow session )
        {
            games = new List<OpenSkie.Scheduler.Controls.Controls.Forms.GameDesigner.GameData>();

            InitializeComponent();
        }

        private void button1_Click( object sender, EventArgs e )
        {
            GameChooser pick_game = new GameChooser();
            pick_game.ShowDialog();
            if( pick_game.DialogResult == System.Windows.Forms.DialogResult.OK )
            {

            }
        }

        private void button2_Click( object sender, EventArgs e )
        {

        }

        private void GameBuilder_Load( object sender, EventArgs e )
        {

        }
    }
}
