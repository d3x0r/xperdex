using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CUIC.ReceiptBrowser
{
	public partial class ReceiptBrowserForm : Form
	{
		public ReceiptBrowserForm()
		{
			InitializeComponent();
		}

		private void ReceiptBrowserForm_Load(object sender, EventArgs e)
		{

		}

		public void LoadReceipt(string html)
		{
			if (html != null)
			{
				code_txt.Text = html;
				htmlEditor2.LoadHtml(html);
			}
			else
			{
				MessageBox.Show("html code " + html + " Not found!");
			}
		}

		private void buttonStart_Click(object sender, EventArgs e)
		{

		}

		private void buttonEpson_Click(object sender, EventArgs e)
		{
			
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}
	}
}