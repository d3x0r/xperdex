using System;
using System.Drawing;
using System.Windows.Forms;

namespace xperdex.gui
{
    public partial class PSI_Control : UserControl
    {
        public PSI_Control()
        {
            InitializeComponent();
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.Opaque, false);  // no background
            SetStyle(ControlStyles.UserPaint, true); // generate paint
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // skip paintbackground
            SetStyle(ControlStyles.DoubleBuffer, true);
			this.MouseMove += new MouseEventHandler(PSI_Control_MouseMove);
            this.SetStyle(ControlStyles.Opaque, false);
            this.BackColor = Color.Transparent;
            this.DoubleBuffered = true;
        }
#if use_old_school_way
		protected override void OnPaintBackground( PaintEventArgs pevent )
		{
			//do not allow the background to be painted  
		}

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;
				cp.ExStyle |= 0x00000020; //WS_EX_TRANSPARENT 
				return cp;
			}
		} 
#endif

        public virtual void Properties()
        {
            // launch a custom control dialog for your class.
        }

        bool grabbed;
        int _x, _y;
		bool bMovable;
		public bool UseMouse;
		public bool Movable
		{
			set
			{
				bMovable = value;
			}
			get
			{
				return bMovable;
			}
		}

		void  PSI_Control_MouseMove(Object sender, MouseEventArgs e)
		{
        //private void MoveBase(object sender, MouseEventArgs e)
        //{
			if( !UseMouse )
				return;
            if (grabbed)
            {
                if (e.Button == MouseButtons.Left)
                {
                    Control parent;
					if( bMovable )
					{
						Point del = new Point( e.X - _x, e.Y - _y );
						del.X += this.Location.X;
						del.Y += this.Location.Y;
						this.Location = del;
					}
					else
					{
						for( parent = this; parent != null && parent.Parent != null; parent = parent.Parent ) ;
						if( parent != null )
						{
							Point del = new Point( e.X - _x, e.Y - _y );
							del.X += parent.Location.X;
							del.Y += parent.Location.Y;
							parent.Location = del;
						}
					}
                }
                grabbed = false;
            }
            else
            {
                _x = e.X;
                _y = e.Y;
                grabbed = true;
            }
        }

    }
}
