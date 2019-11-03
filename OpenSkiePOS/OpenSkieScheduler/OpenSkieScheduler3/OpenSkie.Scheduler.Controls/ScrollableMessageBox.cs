using System;
using System.Windows.Forms;

namespace OpenSkie.Scheduler.Controls
{
	public partial class ScrollableMessageBox : Form
	{
		public ScrollableMessageBox()
		{
			InitializeComponent();
		}
		public static DialogResult Show( String message )
		{
			ScrollableMessageBox smb = new ScrollableMessageBox();
			smb.buttonPositive.Hide();
			smb.buttonNegative.Text = "Ok";
			smb.buttonNegative.DialogResult = DialogResult.OK;
			smb.richTextBox1.Text = message;
			DialogResult dr = smb.ShowDialog();
			smb.Dispose();
			return dr;
		}
		public static DialogResult Show( String message, String title, MessageBoxButtons buttons )
		{
			ScrollableMessageBox smb = new ScrollableMessageBox();
			if( buttons == MessageBoxButtons.YesNo )
			{
				smb.buttonPositive.Text = "Yes";
				smb.buttonPositive.DialogResult = DialogResult.Yes;
				smb.buttonNegative.Text = "No";
				smb.buttonNegative.DialogResult = DialogResult.No;
				smb.richTextBox1.Text = message;
				smb.Text = title;
			}
			else
			{
				smb.buttonPositive.Text = "????";
				smb.buttonNegative.Text = "????";
			}
			DialogResult dr = smb.ShowDialog();
			smb.Dispose();
			return dr;
		}
	}
}
