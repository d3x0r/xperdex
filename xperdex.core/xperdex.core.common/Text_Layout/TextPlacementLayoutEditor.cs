using System;
using System.Collections.Generic;
//using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using xperdex.core.common.Text_Layout;

namespace xperdex.core.common
{
	public partial class TextPlacementLayoutEditor : UserControl
	{
		//TextLayoutInstance tli;
		TextLayout EditLayout;
		public TextPlacementLayoutEditor()
		{
			InitializeComponent();
			this.Paint += new PaintEventHandler( TextPlacementLayoutEditor_Paint );
			this.SizeChanged += new EventHandler( TextPlacementLayoutEditor_SizeChanged );
		}


		void TextPlacementLayoutEditor_SizeChanged( object sender, EventArgs e )
		{
			if( EditLayout != null )
				foreach( TextLabel label in EditLayout.placements )
				{
					label.updated = true;
				}
		}

		public void UpdateEditingLayout( TextLayout layout )
		{
			EditLayout = layout;
		}

		void TextPlacementLayoutEditor_Paint( object sender, PaintEventArgs e )
		{
			e.Graphics.Clear( Color.Bisque );
			if( EditLayout != null )
			{
				foreach( TextLabel label in EditLayout.placements )
				{
					// render the label name (passing null as text)
					label.Render( this, e.Graphics, true, Color.DarkGray, null, new classes.Fraction(1,1), new classes.Fraction(1,1) );
				}
			}
		}

		TextLabel FindLabelUnderMouse( Point p)
		{
			if( EditLayout != null && EditLayout.placements != null )
			foreach( TextLabel label in EditLayout.placements )
			{
				if( label.HasPoint( p ) )
				{
					return label;
				}
			}
			return null;
		}


		TextLabel lock_label;
		bool locked;
		Point label_p; // point the label started at...
		int lock_x, lock_y;

		void DoMouse( MouseEventArgs e )
		{
			if( ( e.Button & MouseButtons.Left ) != 0 )
			{
				if( !locked )
				{
					TextLabel label = FindLabelUnderMouse( e.Location );
					if( label != null )
					{
						label_p = label.GetVisiblePoint();
						locked = true;
						lock_label = label;
						lock_x = e.X;
						lock_y = e.Y;
					}
				}
				else
				{
					lock_label.MoveLabelRelative( label_p, lock_x, e.X, lock_y, e.Y );
					//lock_x = e.X;
					//lock_y = e.Y;
					Refresh();
				}
			}
			else
			{
				lock_label = null;
				locked = false;
			}
		}

		protected override void OnMouseClick( MouseEventArgs e )
		{
			DoMouse( e );
		}
		protected override void OnMouseMove( MouseEventArgs e )
		{
			DoMouse( e );
		}
	}
}
