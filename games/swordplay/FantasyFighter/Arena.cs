using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FantasyFighter
{
	public partial class Arena : Form
	{
				ClientPort client;

		public Arena(		ClientPort client )
		{
			this.client = client;
			InitializeComponent();
		}

		private void Arena_Load( object sender, EventArgs e )
		{

		}
	}
}
