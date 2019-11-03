//using System.Linq;
using System.Drawing;
using xperdex.gui;

namespace BingoGameCore4.Controls
{
	public class BingoCard1: PSI_Control
	{
		BingoCardState _Card;

		public BingoCardState Card
		{
			set
			{
				_Card = value;
				Refresh();
			}
		}

		public BingoCard1( BingoCardState card, int x, int y, int width, int height )
		{
			InitializeComponent();
			Location = new Point( x, y );
			Size = new Size( width, height );
			_Card = card;
		}

		public BingoCard1()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// BingoCard1
			// 
			this.Name = "BingoCard1";
			this.Paint += new System.Windows.Forms.PaintEventHandler( this.BingoCard1_Paint );
			this.ResumeLayout( false );

		}

		static Brush blank = Brushes.White; // no marks, not in pattern
		static Brush daubed = Brushes.Pink; // a mark not in the best pattern (very light pink)
		static Brush last = Brushes.LightBlue; // the mark on the card with last ball
		static Brush best_pattern = Brushes.Orchid; // a spot that needs to be marked to be a win (lighter red)
		static Brush best_pattern_daub = Brushes.Red;  // a spot in the best match pattern that is marked (most red)

		static Brush win_blank = Brushes.White;  // no marks, not in pattern
		static Brush win_daubed = Brushes.LightGreen; // a mark not in the winning pattern that was daubbed (very light green)
		static Brush win_last = Brushes.LightSeaGreen; // the lastball marked on the card
		static Brush win_best_pattern = Brushes.DarkGreen; // a spot in the winning pattern that is not marked (never happens)
		static Brush win_best_pattern_daub = Brushes.GreenYellow; // marked winning pattern

		void DrawSingleCard( Graphics g )
		{
			byte[, ,] data = _Card.CardData;
			int row, col;
			int best_pattern_mask = _Card.BestMask();
			int card_mask = _Card.MarkMask();
			bool win = false;
			int lastball = _Card.Lastball;
			g.Transform.Reset();

			g.ScaleTransform( 1, 1 );
			if( _Card.BestAway() == 0 )
				win = true;
			/*
			if( _Card.BestAway == 25 )
			{
				g.FillRectangle( blank, new Rectangle( 0, 0, Width, Height ) );
				g.DrawString( "No", Font, new SolidBrush( this.ForeColor ), new PointF( 2, 2 ) );
				g.DrawString( "Play", Font, new SolidBrush( this.ForeColor ), new PointF( 2, 2 + (Height/5) ) );
			}
			else
			 */
			{
				int rows = _Card.CardData.GetLength( 2 );
				int cols = _Card.CardData.GetLength( 1 );
				for( row = 0; row < rows; row++ )
					for( col = 0; col < cols; col++ )
					{
						int bit = 1 << col * rows + row;
						Brush color = blank;
						if( ( card_mask & best_pattern_mask & ( bit ) ) != 0 )
						{
							///***** SHOULD FIX THIS
							if( data[0, col, row] == lastball )
							{
								if( win )
									color = win_last;
								else
									color = last;
							}
							else
							{
								// marked, and in pattern.
								if( win )
									color = win_best_pattern_daub;
								else
									color = best_pattern_daub;
							}
						}
						else if( ( best_pattern_mask & ( bit ) ) != 0 )
						{
							if( win )
								color = win_best_pattern;
							else
								color = best_pattern;
							// not marked, and in pattern
						}
						else if( ( card_mask & ( bit ) ) != 0 )
						{
							if( win )
								color = win_daubed;
							else
								color = daubed;
						}

						int xx = Width / cols;
						int yy = Height / rows;
						g.FillRectangle( color, new Rectangle( col * xx, row * yy, xx, yy ) );
						Color text = _Card.pack.paper ? Color.DarkBlue : Color.DarkGreen;
						g.DrawString( data[0, col, row].ToString()
							, Font
							, new SolidBrush( text )
							, new PointF( col * xx, row * yy ) );
					}
			}
		}

		void DrawDoubleCard( Graphics g )
		{
			byte[, ,] data = _Card.CardData;
            int row, col;
			int best_pattern_mask = _Card.BestMask();
            int card_mask = _Card.MarkMask();
            bool win = false;
            int lastball = _Card.Lastball;
            g.Transform.Reset();

            g.ScaleTransform( 1, 1 );
			if( _Card.BestAway() == 1 )
                win = true;
            /*
            if( _Card.BestAway == 25 )
            {
                g.FillRectangle( blank, new Rectangle( 0, 0, Width, Height ) );
                g.DrawString( "No", Font, new SolidBrush( this.ForeColor ), new PointF( 2, 2 ) );
                g.DrawString( "Play", Font, new SolidBrush( this.ForeColor ), new PointF( 2, 2 + (Height/5) ) );
            }
            else
             */
            {
                int rows = _Card.CardData.GetLength( 2 );
                int cols = _Card.CardData.GetLength( 1 );
                for( row = 0; row < rows; row++ )
                    for( col = 0; col < cols; col++ )
                    {
                        int bit = 1 << row * cols + col;
                        Brush color = blank;
                        if( ( card_mask & best_pattern_mask & ( bit ) ) != 0 )
                        {
                            for( int face = 0; face < 2; face++ )
                            {
                                ///***** SHOULD FIX THIS
                                if( data[face, col, row] == lastball )
                                {
                                    if( win )
                                        color = win_last;
                                    else
                                        color = last;
                                }
                                else
                                {
                                    // marked, and in pattern.
                                    if( win )
                                        color = win_best_pattern_daub;
                                    else
                                        color = best_pattern_daub;
                                }
                            }
                        }
                        else if( ( best_pattern_mask & ( bit ) ) != 0 )
                        {
                            if( win )
                                color = win_best_pattern;
                            else
                                color = best_pattern;
                            // not marked, and in pattern
                        }
                        else if( ( card_mask & ( bit ) ) != 0 )
                        {
                            if( win )
                                color = win_daubed;
                            else
                                color = daubed;
                        }

                        int xx = Width / cols;
                        int fx = xx / data.GetLength( 0 );
                        int yy = Height / rows;
                        g.FillRectangle( color, new Rectangle( col * xx, row * yy, xx, yy ) );
                        Color text = _Card.pack.paper ? Color.DarkBlue : Color.DarkGreen;

                        for( int face = 0; face < 2; face++ )
                        {
                            g.DrawString( data[face, col, row].ToString()
                                , Font
                                , new SolidBrush( text )
                                , new PointF( (col * xx) + (face * fx), row * yy ) );
                        }
                    }
            }
        }


		private void BingoCard1_Paint( object sender, System.Windows.Forms.PaintEventArgs e )
		{
			if( _Card == null )
				return;
			int faces = _Card.CardData.GetLength(0);
			switch( faces )
			{
			case 1:
				DrawSingleCard( e.Graphics );
				break;
			case 2:
				DrawDoubleCard( e.Graphics );
				break;

			}
		}


	}
}
