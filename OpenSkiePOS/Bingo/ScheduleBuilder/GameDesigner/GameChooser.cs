using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OpenSkieScheduler;
using xperdex.classes;

namespace ScheduleBuilder.GameDesigner
{
    public partial class GameChooser : Form
    {
        public GameChooser()
        {
            InitializeComponent();
        }

        private void GameChooser_Load(object sender, EventArgs e)
        {
            listBox1.DataSource = Local.schedule.games;
            listBox1.DisplayMember = GameTable.NameColumn;
            listBox1.ValueMember = GameTable.PrimaryKey;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String value = QueryNewName.Show( "Enter new game name" );
            if( value != null && value.Length > 0 )
            {
                DataRow game = Local.schedule.games.NewGame( value );
                if( game != null )
                {
                    EditGamePatterns.Show( game );
                }
            }
        }

        private void button3_Click( object sender, EventArgs e )
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void button2_Click( object sender, EventArgs e )
        {
            //EditGamePatterns.Show( listBox1.SelectedValue );
        }
    }
}
