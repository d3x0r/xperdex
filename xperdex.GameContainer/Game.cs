using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using xperdex.classes;
using xperdex.core.interfaces;

namespace xperdex.GameContainer
{
	public class Game: IReflectorCanvas
	{
		/// <summary>
		/// this is the control that represents me... I'm not a control, but interact with a control...
		/// </summary>
		Control control;
		#region IReflectorCreate Members

		void IReflectorCreate.OnCreate( System.Windows.Forms.Control pc )
		{
			control = pc;
			//throw new Exception( "The method or operation is not implemented." );
		}

		#endregion
	}
}
