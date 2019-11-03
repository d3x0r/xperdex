using System.Windows.Forms;
using System.Xml.XPath;
using xperdex.core.interfaces;

namespace xperdex.tasks
{
	[ButtonAttribute( Name="Task" )]
	public class Task : IReflectorButton
		, IReflectorPersistance
		, IReflectorCreate
	{
		internal TaskItem task;
		Control control;
		public Task()
		{
			task = new TaskItem();
		}

		#region IReflectorButton Members

		public bool OnClick()
		{
			return task.Execute();
		}

		#endregion

		#region IReflectorPersistance Members

		public bool Load( XPathNavigator r )
		{
			return task.Load( r );
		}

		public void Save( System.Xml.XmlWriter w )
		{
			task.Save( w );
		}

		public void Properties()
		{
			TaskProperties tp = new TaskProperties( task, control );
			//throw new Exception("The method or operation is not implemented.");
			tp.ShowDialog();
			if( tp.DialogResult == DialogResult.OK )
			{
				tp.Apply();
			}
			tp.Dispose();
		}

		#endregion


		#region IReflectorCreate Members

		public void OnCreate( System.Windows.Forms.Control pc )
		{
			control = pc;
		}

		#endregion
	}
}
