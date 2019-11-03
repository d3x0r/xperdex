using System;
using System.Collections.Generic;
using System.Text;
using xperdex.classes;
using xperdex.core;
using System.Windows.Forms;

namespace HotballChooser
{
	class BallSelectButton: IReflectorButton, IReflectorWidget
	{
		PSI_Button MyPC;
		bool selected;
		int myid;
		public BallSelectButton( PSI_Button pc )
		{
			MyPC = pc;
			StaticLocal.BallSelectors.Add( this );
			myid = StaticLocal.BallSelectors.Count;
		}
		internal void Show()
		{
			MyPC.Text = (StaticLocal.selectbase + myid).ToString();
			MyPC.Visible = true;
		}
		internal void Hide()
		{
			MyPC.Visible = false;
		}

		#region IReflectorButton Members

		bool IReflectorButton.OnClick()
		{
			//selected = !selected;
			//MyPC.SetHighlighted( selected );
			StaticLocal.hotballs[StaticLocal.selectbase / 15] = MyPC.Text;
			xperdex.core.variables.Variables.UpdateVariable( "Hotball " + (StaticLocal.selectbase / 15 + 1).ToString() );
			StaticLocal.selecting = false;
			//MessageBox.Show( "Blah" );
			return true;
			//throw new Exception( "The method or operation is not implemented." );
		}

		#endregion

		#region IReflectorWidget Members

		bool IReflectorWidget.CanShow
		{
			get 
			{ 
				return StaticLocal.selecting; 
			}
		}

		void IReflectorWidget.OnPaint( System.Windows.Forms.PaintEventArgs e )
		{
			//throw new Exception( "The method or operation is not implemented." );
		}

		void IReflectorWidget.OnKeyPress( System.Windows.Forms.KeyPressEventArgs e )
		{
			//throw new Exception( "The method or operation is not implemented." );
		}

		#endregion
	}
}
