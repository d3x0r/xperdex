using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using xperdex.classes;

namespace OptionMapTester
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load( object sender, EventArgs e )
		{
			string option = Options.Default[Application.ExecutablePath]["default"]["SubOption", "value"];
			string option2 = Options.Default[Application.ExecutablePath]["ftnsys"]["default"]["SubOption", "value"];
			string option3 = Options.Default[Application.ExecutablePath]["xyxxx"]["default"]["SubOption", "value - test 5161"];
			string option4 = Options.Default[Application.ExecutablePath]["default"]["SubOption", "value"];
			string option5 = Options.Default[Application.ExecutablePath]["default"]["SubOption", "value"];
			string option12 = Options.Default[Application.ExecutablePath]["ftnsys/default\\SubOption3", "value1223", "Description may apply here"];
			string option22 = Options.Default[Application.ExecutablePath]["ftnsys/default2\\SubOption4", "value"];
			string option32 = Options.Default[Application.ExecutablePath]["ftnsys/default3\\SubOption5", "value"];

		}
	}
}