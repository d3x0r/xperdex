using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using xperdex.core.interfaces;

namespace xperdex.core
{
	public partial class VariableChooseMemberForm : Form
	{
		IReflectorVariableNamedArray iNamed;
		string result;

		public VariableChooseMemberForm( IReflectorVariableNamedArray iVar )
		{
			iNamed = iVar;
			InitializeComponent();
		}

		private void VariableChooseMemberForm_Load( object sender, EventArgs e )
		{
			string[] members = iNamed.Members;
			listBox1.DataSource = members;
			listBox1.SelectedValueChanged += new EventHandler( listBox1_DoubleClick );
			listBox1.DoubleClick += new EventHandler( listBox1_DoubleClick );
		}

		void listBox1_DoubleClick( object sender, EventArgs e )
		{
			result = listBox1.SelectedItem as string;
		}

		public string Result
		{
			get
			{
				if( checkBoxByNumber.Checked )
					return listBox1.SelectedIndex.ToString();
				return result;
			}
		}
	}
}
