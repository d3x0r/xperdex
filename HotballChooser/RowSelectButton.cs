using System;
using System.Collections.Generic;
using System.Text;
using xperdex.classes;
using System.Windows.Forms;
using xperdex.core;

namespace HotballChooser
{
	class RowSelectButton: IReflectorButton
	{
		PSI_Button MyPC;
		bool selected;
		int rowid;
		public RowSelectButton( PSI_Button pc )
		{
			MyPC = pc;
			StaticLocal.RowSelectors.Add( this );
			rowid = StaticLocal.RowSelectors.Count;
		}

		internal void Show()
		{
			MyPC.Visible = true;
		}
		internal void Hide()
		{
			//MyPC.Visible = false;
			selected = false;
			MyPC.SetHighlighted( selected );
		}

		#region IReflectorButton Members

		bool IReflectorButton.OnClick()
		{
			StaticLocal.selectbase = 15 * (rowid -1);
			StaticLocal.selecting = true;
			selected = !selected;
			MyPC.SetHighlighted( selected );
			//MessageBox.Show( "Blah" );
			return true;
			//throw new Exception( "The method or operation is not implemented." );
		}


		#endregion

	}
}
