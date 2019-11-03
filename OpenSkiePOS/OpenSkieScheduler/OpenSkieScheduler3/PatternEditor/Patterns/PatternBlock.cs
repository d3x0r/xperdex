using System;
using System.Collections.Specialized;
using System.Drawing;
using System.Windows.Forms;
using xperdex.gui;

namespace BingoGameCore4.Controls.Patterns
{
	public partial class PatternBlock : PSI_Control
	{
		public int bits;
		Brush brushBackground = new SolidBrush( Color.White );
		Brush brushMarked = new SolidBrush( Color.Blue );
		Brush brushUnarked = new SolidBrush( Color.Yellow );

	
		bool TESTFLAG( int bits, int bit )
		{
			return ( ( bits & ( 1 << bit ) ) != 0 );
		}
		void SETFLAG( ref int bits, int bit )
		{
			bits |= 1 << bit;
		}
		void RESETFLAG( ref int bits, int bit )
		{
			bits &= ~(1 << bit);
		}

		internal struct Flags
		{
			internal bool bToggleDirection;
		}
		Flags flags;
		
		public PatternBlock()
		{
			InitializeComponent();			
		}

		public PatternBlock( int x, int y, int width, int height )
		{
			InitializeComponent();
			Location = new Point( x, y );
			Size = new Size( width, height );
		}
		public PatternBlock( BitVector32 val, int x, int y, int width, int height )
		{
			InitializeComponent();
			bits = val.Data;
			Location = new Point( x, y );
			Size = new Size( width, height );
		}
		public PatternBlock( int val, int x, int y, int width, int height )
		{
			InitializeComponent();
			bits = val;
			Location = new Point( x, y );
			Size = new Size( width, height );
		}

		public PatternBlock( int x, int y )
			: this( x, y, 25, 25 )
		{
		}

		// 20 = (block_ration+space_ratio)
		// 3/20 OF A PATTERN BLOCK IS the space...
		// or 17/20 of a pattern block is the mark
		// there are 5 blocks
		// there are 7 spaces (left, right, and 4 ? makes 6?
		// +1 as a width parameter...
		
		const int PATTERN_BLOCK_RATIO = 17;
		const int pattern_blocks = 5;
		const int PATTERN_SPACE_RATIO = 3;
		const int pattern_spaces = (6);   //??
		const int total_ratio = pattern_blocks*PATTERN_BLOCK_RATIO + ((pattern_spaces+1)*2)+PATTERN_SPACE_RATIO;


		protected override void OnPaint( PaintEventArgs e )
		{
			int x, y;
			int x2, y2;
			int r, c;

			e.Graphics.FillRectangle( brushBackground, 0, 0, Width,Height );
			for( c = 0; c < 5; c++ )
			{
				x = ( Width * ( PATTERN_SPACE_RATIO * ( c + 1 ) + PATTERN_BLOCK_RATIO * c ) ) / ( total_ratio );
				x2 = ( Width * ( PATTERN_SPACE_RATIO * ( c + 1 ) + PATTERN_BLOCK_RATIO * ( c + 1 ) ) ) / ( total_ratio );
				for( r = 0; r < 5; r++ )
				{
					y = ( Height * ( PATTERN_SPACE_RATIO * ( r + 1 ) + PATTERN_BLOCK_RATIO * r ) ) / ( total_ratio );
					y2 = ( Height * ( PATTERN_SPACE_RATIO * ( r + 1 ) + PATTERN_BLOCK_RATIO * ( r + 1 ) ) ) / ( total_ratio );

					e.Graphics.FillRectangle( TESTFLAG( bits, c * 5 + r )
								 ? brushMarked
								 : brushUnarked
								 , x , y
								 , x2 - x -1/*width conversion*/, y2 - y  -1/*width conversion*/
								);
				}
			}

		}

		public delegate void OnPatternChanged();
		public event OnPatternChanged PatternChanged;

		internal bool editable = true;


		bool prior_left;
		void DoMouse( MouseEventArgs e )
		{
			if( !editable )
				return;
			if( ( Control.ModifierKeys & Keys.Shift ) != 0 )
			{
				PatternBlockGroup pbg = Parent as PatternBlockGroup;
				if( pbg != null )
				{
					if( pbg.pattern.algorithm == OpenSkieScheduler3.PatternDescriptionTable.match_types.TwoGroups
						|| pbg.pattern.algorithm == OpenSkieScheduler3.PatternDescriptionTable.match_types.TwoGroupsNoOver
						|| pbg.pattern.algorithm == OpenSkieScheduler3.PatternDescriptionTable.match_types.TwoGroupsPrime
						|| pbg.pattern.algorithm == OpenSkieScheduler3.PatternDescriptionTable.match_types.TwoGroupsPrimeNoOver )
					{
						pbg.GroupSeparator = pbg.Controls.IndexOf( this );
					}
				}
			}
			else if( ( e.Button & MouseButtons.Left ) == MouseButtons.Left )
			{
				int x = e.X, y = e.Y;
				int x1, y1, x2, y2;
				int r, c;
				for( r = 0; r < 5; r++ )
				{
					y1 = ( Height * ( PATTERN_SPACE_RATIO * ( r + 1 ) + PATTERN_BLOCK_RATIO * r ) ) / ( total_ratio );
					y2 = ( Height * ( PATTERN_SPACE_RATIO * ( r + 1 ) + PATTERN_BLOCK_RATIO * ( r + 1 ) ) ) / ( total_ratio );
					for( c = 0; c < 5; c++ )
					{
						x1 = ( Width * ( PATTERN_SPACE_RATIO * ( c +1 ) + PATTERN_BLOCK_RATIO * c ) ) / ( total_ratio );
						x2 = ( Width * ( PATTERN_SPACE_RATIO * ( c + 1 ) + PATTERN_BLOCK_RATIO * ( c + 1 ) ) ) / ( total_ratio );
						if( x >= x1 && x <= x2 && y >= y1 && y <= y2 )
						{
							if( !prior_left )
							{
								if( TESTFLAG( bits, c * 5 + r ) )
									flags.bToggleDirection = false;
								else
									flags.bToggleDirection = true;
							}

							if( flags.bToggleDirection )
							{
								if( !TESTFLAG( bits, c * 5 + r ) )
								{
									SETFLAG( ref bits, c * 5 + r );
									if( PatternChanged != null )
										PatternChanged();
									Refresh();
								}
							}
							else
							{
								if( TESTFLAG( bits, c * 5 + r ) )
								{
									RESETFLAG( ref bits, c * 5 + r );
									if( PatternChanged != null )
										PatternChanged();
									Refresh();
								}
							}
						}
					}
				}
				prior_left = true;
			}
			else
				prior_left = false;
		}

		protected override void OnMouseMove( MouseEventArgs e )
		{
			DoMouse( e );
		}

		protected override void OnMouseClick( MouseEventArgs e )
		{
			DoMouse( e );
		}

		private void PatternBlock_DoubleClick( object sender, EventArgs e )
		{
			if( !editable )
				return;
			BigPatternBlock bpb = new BigPatternBlock( bits );
			bpb.ShowDialog();
			int newbits = bpb.bits;
			if( bits != newbits )
			{
				bits = newbits;
				Refresh();
			}
		}
	}
}
