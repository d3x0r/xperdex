using System;
using System.Drawing;
using System.Windows.Forms;
using xperdex.classes;
using xperdex.core;
using xperdex.core.common.Text_Layout;

namespace OpenSkiePOS
{
	public class ButtonWithLabelAreas: PSI_Button
	{
		public TextLayoutInstance layout;

		public ButtonWithLabelAreas()
		{
			layout = TextLayoutInstance.AttachInstance( this as Control, "Default Layout" );
		}

		public ButtonWithLabelAreas( String layoutname )
		{
			layout = TextLayoutInstance.AttachInstance( this as Control, layoutname );
			this.SizeChanged += new EventHandler( ButtonWithLabelAreas_SizeChanged );
		}

		void ButtonWithLabelAreas_SizeChanged( object sender, EventArgs e )
		{
			layout.Resize( this );
		}

		public override bool RenderText( Control c, Graphics g )
		{
			Canvas canvas = this.Parent as Canvas;
			if( canvas != null )
				layout.Render( c, g, canvas.font_scale_x, canvas.font_scale_y );
			else
				layout.Render( c, g, new Fraction(), new Fraction() );
			return true; // success drawn...
		}

	}
}
