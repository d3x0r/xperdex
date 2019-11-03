using System.Windows.Forms;

namespace xperdex.tasks
{
	public partial class InternalTaskProperties : Form
	{
		public InternalTaskProperties()
		{
			InitializeComponent();
			listBox1.DataSource = Local.tasks;
		}
	}
}