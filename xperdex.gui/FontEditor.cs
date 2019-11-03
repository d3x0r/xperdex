using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using xperdex.classes;

namespace xperdex.gui
{
    public partial class FontEditor : Form
    {
		// when this font is updated, all controls should be reposted with this font.
		font_tracker initial;
        public FontEditor()
        {
            InitializeComponent();
        }

		public FontEditor( font_tracker font )
		{
			InitializeComponent();
			initial = font;
		}

		public static List<font_tracker> fonts;

		public delegate void InitFontTracker( font_tracker font_tracker );

		public static font_tracker GetFontTracker( string p, InitFontTracker init_font_tracker )
		{
			if( fonts == null )
				fonts = new List<font_tracker>();

			if( fonts.Count == 0 )
				fonts.Add( new font_tracker( p ) );

			foreach( font_tracker f in fonts )
			{
				if( String.Compare( p, f.Name, true ) == 0 )
					return f;
			}
			font_tracker ft;
			fonts.Add( ft = new font_tracker( p ) );
			if( init_font_tracker != null )
				init_font_tracker( ft );
			return ft;
		}

		public static System.Drawing.Font GetFontTracker( string p, string font_family, int font_size )
		{
			if( fonts.Count == 0 )
				fonts.Add( new font_tracker( "Default" ) );

			foreach( font_tracker f in fonts )
			{
				if( String.Compare( p, f.Name, true ) == 0 )
					return f;
			}
			font_tracker ft;
			fonts.Add( ft = new font_tracker( p, font_family, font_size ) );
			return ft;
		}


		public static font_tracker GetFontTracker( string p )
		{
			return GetFontTracker( p, null );
		}

		public static font_tracker GetFontTracker( Font font )
		{
			if( fonts == null )
				return null;

			foreach( font_tracker check_font_tracker in fonts )
			{
				if( check_font_tracker.f.Equals( font ) )
					return check_font_tracker;
			}
			return null;

		}

        private void LoadFonts(object sender, EventArgs e)
        {
			this.FontList.DataSource = fonts;
			this.FontList.SelectedItem = initial;

        }

        private void EditFont_Click(object sender, EventArgs e)
        {
            font_tracker f =(font_tracker)this.FontList.SelectedItem;
			//pickedFont = null;
            System.Windows.Forms.FontDialog fd = new System.Windows.Forms.FontDialog();
            fd.Font = f.f;
			
            DialogResult result = fd.ShowDialog();

			if( result == System.Windows.Forms.DialogResult.OK )
			{
				f.f = fd.Font;
				f.family = fd.Font.FontFamily.Name;
				f.size = fd.Font.Size;
				f.style = fd.Font.Style;
				f.unit = fd.Font.Unit;
				f.InvokeChanged();
				foreach( Control c in f.Controls )
				{
					c.Font = f.f;
				}
			}
			fd.Dispose();
        }

		public font_tracker GetFontResult()
		{
			font_tracker f = this.FontList.SelectedItem as font_tracker;
			return f;
			//throw new Exception( "The method or operation is not implemented." );
		}

		private void NewFont_Click( object sender, EventArgs e )
		{
			QueryNewName qnn = new QueryNewName( "Enter a name for this font..." );
			qnn.ShowDialog();
			if( qnn.DialogResult == DialogResult.OK )
			{
				font_tracker f = FontEditor.GetFontTracker( qnn.textBox1.Text );
				this.FontList.DataSource = null;
				this.FontList.DataSource = fonts;
			}
			qnn.Dispose();
		}
	}
}