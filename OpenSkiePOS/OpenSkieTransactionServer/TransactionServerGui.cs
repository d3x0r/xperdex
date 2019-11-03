using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OpenSkieTransactionServer
{
	public class TransactionServerGui : Form
	{
		private void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// TransactionServerGui
			// 
			this.ClientSize = new System.Drawing.Size(284, 262);
			this.Name = "TransactionServerGui";
			this.Text = "Transaction Server GUI";
			this.ResumeLayout(false);

		}
	}
}
