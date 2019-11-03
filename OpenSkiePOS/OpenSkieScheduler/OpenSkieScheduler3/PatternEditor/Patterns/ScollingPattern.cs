using System;
using System.Windows.Forms;

namespace BingoGameCore4.Controls.Patterns
{
	public class ScollingPattern : PatternBlock
	{
		int rate = 250;
		public int Rate
		{
			get
			{
				return rate;
			}
			set
			{
				if( value == 0 )
					return;
				if( rate != value )
				{
					if( timer != null )
						timer.Interval = value;
					if( value == 0 )
						timer = null;
					else
					{
						if( timer == null )
						{
							timer = new Timer();
							timer.Interval = value;
							timer.Tick += new EventHandler( timer_Tick );
							timer.Start();
						}
					}
					rate = value;
				}
			}
		}

		bool composite;
		public bool Composite
		{
			set
			{
				composite = value;
			}
			get
			{
				return composite;
			}
		}

		Pattern pattern;
		public Pattern Pattern
		{
			set
			{
				pattern = value;
			}
			get
			{
				return pattern;
			}
		}

		Timer timer;
		public ScollingPattern()
		{
			editable = false;
			timer = new Timer();
			timer.Interval = 500;
			timer.Tick += new EventHandler( timer_Tick );
			timer.Start();
		}

		int step;
		void timer_Tick( object sender, EventArgs e )
		{
			if( pattern == null )
				return;
			if( pattern.composite_masks.Count == 0 )
			{
				this.bits = 0;
				return;
			}
			step++;
			if( step >= pattern.composite_masks.Count )
			{
				step = 0;
			}
			this.bits = pattern.composite_masks[step];
			Refresh();
		}

		private void InitializeComponent()
		{
            this.SuspendLayout();
            // 
            // ScollingPattern
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "ScollingPattern";
            this.Load += new System.EventHandler(this.ScollingPattern_Load);
            this.ResumeLayout(false);

		}

        private void ScollingPattern_Load(object sender, EventArgs e)
        {

        }
	}
}
