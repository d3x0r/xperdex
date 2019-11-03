using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Threading;

namespace xperdex.gui
{
	public class Banner : Form
	{
		bool NoClose;
		private xperdex.classes.Fraction scale_x, scale_y;
		private font_tracker FontTracker;
		private MessageBoxButtons messageBoxButtons;

		delegate void DrawRoutine( Graphics gout, bool offset_text, int Width, int Height, String outputText );

		class YesNoButton : Button
		{
			String _text;
			new internal String Text
			{
				set
				{
					_text = value;
				}
				get
				{
					return _text;
				}
			}
			internal DrawRoutine drawproc;

			internal YesNoButton()
			{
			}

			protected override void OnPaint( PaintEventArgs pevent )
			{
				//String save_text = Text;
				//Text = null;
				base.OnPaint( pevent );
				//ButtonRenderer.DrawButton( pevent.Graphics, ClientRectangle, this.state );
				//Text = save_text;
				//pevent.Graphics.FillRectangle( new SolidBrush( BackColor ), ClientRectangle );
				drawproc( pevent.Graphics, false, Width, Height, _text );
			}
		}

		public Banner()
		{
			InitializeComponent();
			FontTracker = new font_tracker( this.Font );
		}

		public Banner( String content )
		{
			InitializeComponent();
			FontTracker = new font_tracker( this.Font );
			Text = content;
		}

		public Banner( string Message, MessageBoxButtons messageBoxButtons )
		{
			this.messageBoxButtons = messageBoxButtons;
			InitializeComponent();
			FontTracker = new font_tracker( this.Font );
			// TODO: Complete member initialization
			Text = Message;

		}

		
		private void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// Banner
			// 
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(104)))), ((int)(((byte)(81)))));
			this.ClientSize = new System.Drawing.Size(704, 360);
			this.Font = new System.Drawing.Font("Rod", 25.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ForeColor = System.Drawing.Color.White;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "Banner";
			this.Text = "What if there is text";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Banner_Paint);
			this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Banner_MouseClick);
			this.Resize += new System.EventHandler(this.Banner_Resize);
			this.ResumeLayout(false);

			YesNoButton button;

			switch( messageBoxButtons )
			{
			case MessageBoxButtons.YesNo:
				button = new YesNoButton();
				button.BackColor = Color.Red;
				button.ForeColor = Color.White;
				button.Text = "No";
				button.Name = "NoButton";
				button.DialogResult = System.Windows.Forms.DialogResult.No;
				button.Click += new EventHandler( button_Click );
				button.drawproc = DrawText;
				this.CancelButton = button;
				Controls.Add( button );

				button = new YesNoButton();
				button.BackColor = Color.Green;
				button.ForeColor = Color.White;
				button.Text = "Yes";
				button.Name = "YesButton";
				button.DialogResult = System.Windows.Forms.DialogResult.Yes;
				button.Click += new EventHandler( button_Click );
				button.drawproc = DrawText;
				this.AcceptButton = button;
				Controls.Add( button );
				break;
			}
		}

		void button_Click( object sender, EventArgs e )
		{
			if( !banner.NoClose )
			{
				Button button = sender as Button;
				DialogResult = button.DialogResult;
				Close();
			}
		}

		void Banner_Paint( object sender, PaintEventArgs e )
		{
			DrawText( e.Graphics, messageBoxButtons== MessageBoxButtons.OK?false:true, Width, Height, Text );
		}

		void DrawText( Graphics gout, bool offset_text, int Width, int Height, String outputText )
		{
			{
				int offset = 0;
				String realtext = outputText;

				List<SizeF> output_size;
				List<string> output;
				output = new List<string>();
				output_size = new List<SizeF>();
				int idx;
				do
				{
					int idx_a = realtext.IndexOf( '\n', offset );
					int idx_b = realtext.IndexOf( '_', offset );
					if( idx_a >= 0 )
						if( idx_b >= 0 )
							if( idx_a < idx_b )
								idx = idx_a;
							else
								idx = idx_b;
						else
							idx = idx_a;
					else
						idx = idx_b;
					//idx = realtext.IndexOf( '_', offset );

					if( idx >= 0 )
					{
						output.Add( realtext.Substring( offset, idx - offset ) );
						offset = idx + 1;
					}
					else
						output.Add( realtext.Substring( offset, realtext.Length - offset ) );

				} while( idx >= 0 );
				int height = 0;
				int lineheight = 0;
				foreach( string s in output )
				{
					SizeF size;
					output_size.Add( size = FontTracker.MeasureString( gout, s, scale_x, scale_y ) );
					//output_size.Add( size = new SizeF( gout.MeasureString( s, c.FontTracker ) ) );
					height += (int)( ( lineheight = (int)size.Height ) + ( height > 0 ? 0 : 0 ) );
				}

				Point _point = new Point( Width, Height );
				Point point = new Point();

				if( !offset_text )
				{
					//SizeF size = new SizeF(gout.MeasureString(realtext, c.Font));
					_point.X /= 2;
					_point.Y /= 2;
					_point.Y -= (int)( ( height - lineheight ) / 2 );
				}
				else
				{
					_point.X /= 2;
					_point.Y /= 3;
					_point.Y -= (int)( ( height - lineheight ) / 2 );
				}

				point.Y = _point.Y;
				int n = 0;
				foreach( string s in output )
				{
					point.X = _point.X /*- (int)(output_size[n].Width / 2)*/;
					FontTracker.DrawString( gout, s, new SolidBrush( ForeColor ), point, scale_x, scale_y );
					//gout.DrawString( s
					//	 , c.FontTracker
					//	 , attrib.text_output
					//		 , point );
					point.Y += (int)( output_size[n].Height ) + ( ( n > 0 ) ? 2 : 0 );
					n++;
				}
			}
		}

		private void Banner_Resize( object sender, EventArgs e )
		{
			scale_x.Set( Width, 1024 );
			scale_y.Set( Height, 768 );

			switch( messageBoxButtons )
			{
			case MessageBoxButtons.YesNo :
				Button tmp = Controls["NoButton"] as Button;
				tmp.Location = new Point( 5, ( Height - 5 ) - ( Height / 3 ) );
				tmp.Size = new Size( ( ( Width - 15 ) / 2 ), ( Height - 10 ) / 3 );

				tmp = Controls["YesButton"] as Button;
				tmp.Location = new Point( 10 + ( ( Width - 15 )/ 2 ), ( Height - 5 ) - ( Height / 3 ) );
				tmp.Size = new Size( ( ( Width - 15 ) / 2 ), ( Height - 10 ) / 3 );

				break;
			}
			//label1.Location = new System.Drawing.Point( this.Width / 2 - label1.Width / 2, this.Height / 2 - label1.Height / 2 );
		}

		private void Banner_MouseClick( object sender, MouseEventArgs e )
		{
			if( !banner.NoClose )
			{
				Close();
			}
		}

		private void label1_Click( object sender, EventArgs e )
		{
			if( !banner.NoClose )
			{
				Close();
			}
		}

		static Banner banner;


		public static void Show( String text )
		{
			if( banner == null )
				banner = new Banner();
			banner.NoClose = false;
			banner.Text = text;
			banner.ShowDialog();

			banner = null;
		}

		public static void Show( String text, bool bContinue )
		{
			if( banner == null )
				banner = new Banner();
			try
			{
				banner.Text = text;
			}
			catch( ObjectDisposedException ode )
			{
				banner = new Banner();
				banner.Text = text;
			}
			if( banner.Visible )
				banner.Refresh();
			else
				if( bContinue )
				{
					//banner.TopMost = true;
					banner.Visible = true;
					banner.NoClose = true;
					banner.Refresh();
				}
				else
				{
					banner.ShowDialog();
					banner = null;
				}
		}

		public static void End()
		{
			if( banner != null )
			{
				banner.Visible = false;
				banner.Close();
				banner = null;
			}
		}

		public static System.Windows.Forms.DialogResult Show( string Message, MessageBoxButtons messageBoxButtons )
		{
			Banner banner = new Banner( Message, messageBoxButtons );
			return banner.ShowDialog();
		}
	}
}
