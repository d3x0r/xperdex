using System;
using System.Windows.Forms;

namespace xperdex.classes
{
    public partial class QueryNewName : Form
    {
        public QueryNewName( String title )
        {
			if( title == null )
				title = "Enter New System Name";
			InitializeComponent();
			Text = title;
		}
		protected override void OnShown( EventArgs e )
		{
			ActiveControl = this.textBox1;
			textBox1.Focus();
			textBox1.Select();
			base.OnShown( e );
		}

		public static String Show( String question )
		{
			QueryNewName qnn = new QueryNewName( question );
			String result = "";
			qnn.ShowDialog();
			if( qnn.DialogResult == DialogResult.OK )
				result = qnn.textBox1.Text;
			qnn.Dispose();
			return result;

		}
		public static String Show( String question, String default_value )
		{
			QueryNewName qnn = new QueryNewName( question );
			String result = default_value;
			qnn.textBox1.Text = default_value;
			qnn.ShowDialog();
			if( qnn.DialogResult == DialogResult.OK )
				result = qnn.textBox1.Text;
			qnn.Dispose();
			return result;

		}

		private void QueryNewName_Load( object sender, EventArgs e )
		{
			textBox1.Focus();
		}
	}
}