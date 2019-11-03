using System;
using System.Diagnostics;
using System.Windows.Forms;
using xperdex.gui;
//using CDAL;

namespace xperdex.core
{
    public partial class XperdexDefaultForm : Form, xperdex.core.interfaces.IReflectorVariable
	{
		Canvas canvas;

		#region IReflectorVariable Members

		string xperdex.core.interfaces.IReflectorVariable.Name
		{
			get { return "Form Title"; }
		}

		string xperdex.core.interfaces.IReflectorVariable.Text
		{
			get
			{
				return canvas.Parent.Text;
			}
			set
			{
				canvas.Parent.Text = value;
			}
		}

		#endregion

		public XperdexDefaultForm(string[] args)
		{
			bool want_title = false;
			bool want_page = false;
			String FirstPage = null;
			Banner.Show( "Initializing...", true );
            //TopMost = true;

			InitializeComponent();
			canvas = new Canvas();
			canvas.Dock = DockStyle.Fill;
			Process me = Process.GetCurrentProcess();

			this.WindowState = FormWindowState.Maximized;

			foreach( string arg in args )
			{
				if( want_page )
				{
					want_page = false;
					FirstPage = arg;
					continue;
				}
				else if( want_title )
				{
					want_title = false;
					Text = arg;
					continue;
				}
				else if( arg.CompareTo( "normal" ) == 0 )
				{
					this.FormBorderStyle = FormBorderStyle.Sizable;
					this.WindowState = System.Windows.Forms.FormWindowState.Normal;
					continue;
				}
				else if( arg.CompareTo( "noicon" ) == 0 )
				{
					ShowInTaskbar = false;
					continue;
				}
				else if( arg.CompareTo( "topmost" ) == 0 )
				{
					this.TopMost = true;
					continue;
				}
				else if( arg.CompareTo( "page" ) == 0 )
				{
					want_page = true;
					continue;
				}
				else if( arg.CompareTo( "title" ) == 0 )
				{
					want_title = true;
					continue;
				}
				core_common.ConfigName = arg;
			}
			this.LocationChanged += new EventHandler( Form1_LocationChanged );

			this.Visible = false;

			this.Controls.Add( canvas );

			// the top level form should load a configuration
			// there are NO pages yet...
			Banner.Show( "Loading...", true );
			canvas.LoadConfig();
			if( FirstPage != null )
				canvas.current_page = canvas.FindPage( FirstPage );
			//Banner.Show( "Loaded...", true );
			this.Visible = true;

			Banner.End();
		}

		void Form1_LocationChanged( object sender, EventArgs e )
		{
			//canvas.Canvas_LocationChanged( sender, e );
		}

#if figure_out_how_to_update_layered_form
		protected override CreateParams CreateParams
		{
			get
			{
				//#define WS_EX_LAYERED 0x80000   /* w2k */
				CreateParams cp = base.CreateParams;
				cp.ExStyle |= 0x00080000; //WS_EX_LAYERED    
				return cp;
			}
		}
		protected override void OnPaint( PaintEventArgs e )
		{
			base.OnPaint( e );
		}

#endif

		protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
        }

		//base.Control
	}
}
