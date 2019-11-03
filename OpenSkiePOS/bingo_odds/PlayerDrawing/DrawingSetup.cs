using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using xperdex.classes;

namespace PlayerDrawing
{
    public partial class DrawingSetup : Form
    {
        public DrawingSetup()
        {
            InitializeComponent();
        }

        private void DrawingSetup_Load( object sender, EventArgs e )
        {
            richTextBox1.Text = INI.Default["Player Select"]["SQL Statement","select card from player_track where bingoday=curdate()"].Value;
			textBoxCardColumn.Text = INI.Default["Player Select"]["Card column name", "card"].Value;
			textBoxNameColumn.Text = INI.Default["Player Select"]["Name column name", "name"].Value;
			textBoxDrawCount.Text = INI.Default["Player Select"]["player draw count"].Value;
			if( INI.Default["Ball Select"]["Use Blower", false].Bool )
            {
                radioButtonDirect.Checked = true;
                radioButtonPrizeVal.Checked = false;
            }
			if( INI.Default["Ball Select"]["Use prize validation database", true].Bool )
            {
                radioButtonDirect.Checked = false;
                radioButtonPrizeVal.Checked = true;
            }
			textBoxSessionNumber.Text = INI.Default["Ball Select"]["Session Number", 1].Value;
			textBoxGameNumber.Text = INI.Default["Ball Select"]["Game Number", 1].Value;
        }

        private void buttonOkay_Click( object sender, EventArgs e )
        {
			INI.Default["Player Select"]["SQL Statement"].Value = richTextBox1.Text;
			INI.Default["Player Select"]["Card column name"].Value = textBoxCardColumn.Text;
			INI.Default["Player Select"]["Name column name"].Value = textBoxNameColumn.Text;
            if( radioButtonDirect.Checked )
            {
				INI.Default["Ball Select"]["Use Blower"].Bool = true;
				INI.Default["Ball Select"]["Use prize validation database"].Bool = false;
            }
            if( radioButtonPrizeVal.Checked )
            {
				INI.Default["Ball Select"]["Use Blower"].Bool = false;
				INI.Default["Ball Select"]["Use prize validation database"].Bool = true;
            }
            Options.Default["Ball Select"]["Session Number"].Value = textBoxSessionNumber.Text;
            Options.Default["Ball Select"]["Game Number"].Value = textBoxGameNumber.Text;
			Options.Default["Player Select"]["player draw count"].Value = textBoxDrawCount.Text;
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

		private void radioButtonPrizeVal_CheckedChanged( object sender, EventArgs e )
		{

		}
    }
}
