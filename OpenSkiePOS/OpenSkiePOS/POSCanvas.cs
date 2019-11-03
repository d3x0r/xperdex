using System;
using System.Windows.Forms;
using WebInterfaces;

namespace OpenSkiePOS
{
    public partial class POSCanvas : Form
    {

        public POSCanvas()
        {
			// opens a single instance of sale interface no matter how many forms.
			SaleInterface.OpenSaleInterface();
			canvas1.TargetSize = Size;
			InitializeComponent();
        }

		private void Form1_Load( object sender, EventArgs e )
		{
			canvas1.LoadConfig();
		}


    }
}