using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BingoGameCore2;
namespace bingo_odds
{
	public partial class CardBrowsingForm : Form
	{
		CheckBox[,] card = new CheckBox[5, 5];
		Control[] board = new Control[75];
		Control[] board2 = new Control[75];
		Control[] board3 = new Control[75];

		int current_card;
		int current_pattern;
		int best_pattern;
		int best_count;
		bool last_is_worst; // so best pattern is the worst match...

		OddsRunInfo state; 

		public CardBrowsingForm( OddsRunInfo.state s )
		{
			if( s == null )
				throw new Exception( "Ba state passed." );
			state = s;
			InitializeComponent();
		}


		protected override void OnLoad( EventArgs e )
		{
			Control c;
			c = checkBox1;

			for( int col = 0; col < 5; col++ )
				for( int row = 0; row < 5; row++ )
				{
					if( row == 0 && col == 0 )
					{
						card[col, row] = c as CheckBox;
						continue;
					}
					CheckBox c2 = new CheckBox();
					c2.Location = new Point( c.Location.X + 44*col , c.Location.Y + 32 * row );
					c2.Size = c.Size;
					this.Controls.Add( c2 );
					card[col, row] = c2;
				}

			c = label1;
			board[0] = c;
			for( int col = 0; col < 15; col++ )
				for( int row = 0; row < 5; row++ )
				{
					if( row == 0 && col == 0 )
					{
						continue;
					}
					Control c2 = new Label();
					c2.Location = new Point( c.Location.X + 25 * col, c.Location.Y + 18 * row );
					c2.Size = c.Size;
					c2.BackColor = Color.ForestGreen;
					
					this.Controls.Add( c2 );
					board[row * 15 + col] = c2;

				}

			c = label2;
			board2[0] = c;
			for( int col = 0; col < 15; col++ )
				for( int row = 0; row < 5; row++ )
				{
					if( row == 0 && col == 0 )
					{
						continue;
					}
					Control c2 = new Label();
					c2.Location = new Point( c.Location.X + 25 * col, c.Location.Y + 18 * row );
					c2.Size = c.Size;
					c2.BackColor = Color.ForestGreen;

					this.Controls.Add( c2 );
					board2[row * 15 + col] = c2;

				}
			c = label3;
			board3[0] = c;
			for( int col = 0; col < 15; col++ )
				for( int row = 0; row < 5; row++ )
				{
					if( row == 0 && col == 0 )
					{
						continue;
					}
					Control c2 = new Label();
					c2.Location = new Point( c.Location.X + 25 * col, c.Location.Y + 18 * row );
					c2.Size = c.Size;
					c2.BackColor = Color.ForestGreen;

					this.Controls.Add( c2 );
					board3[row * 15 + col] = c2;

				}
			//base.OnLoad( e );
		}

		void UpdateCard()
		{
			bool[] marked = new bool[75];
			int pattern = state.game.pattern_list[current_pattern];

			// cheap place to set this so we don't have it all over... 
			// though get_worst_card needs to re-set this after update.
			last_is_worst = false;

			for( int col = 0; col < 5; col++ )
				for( int row = 0; row < 5; row++ )
				{
					card[col, row].Checked = ( ( pattern & ( 1 << ( col * 5 + row ) ) ) != 0 );
					if( row == 2 && col == 2 )
						continue;
					card[col, row].Text = state.playing_cards[current_card][0, col, row].ToString();
					//if( 
				}

			bool option1 = false;// true;
			for( int ball = 0; ball < 75; ball++ )
			{
				int pos;
				if( option1 )
				{
					for( pos = 0; pos < 75; pos++ )
						if( state.playing_balls[pos] == ( ball + 1 ) )
						{
							board[ball].Text = ( pos + 1 ).ToString();
							break;
						}
				}
				else
					board[ball].Text = ( ball + 1 ).ToString();
				board[ball].BackColor = Color.Gray;
			}
			for( int ball = 0; ball < 75; ball++ )
			{
				board2[ball].Text = state.playing_balls[ball].ToString();
				board2[ball].BackColor = Color.Gray;
			}
			for( int ball = 0; ball < 75; ball++ )
			{
				int pos;
				for( pos = 0; pos < 75; pos++ )
						if( state.playing_balls[pos] == ( ball + 1 ) )
						{
							board3[ball].Text = ( pos + 1 ).ToString();
							break;
						}
				board3[ball].BackColor = Color.Gray;
			}

			listBox1.Items.Clear();
			for( int pat = 0; pat < state.card_winning_pattern.GetLength( 1 ); pat++ )
			{
				listBox1.Items.Add( pat + "  " + (state.card_winning_pattern[current_card, pat] +1));
			}

			int bestwin = 75;
			for( int pat = 0; pat < state.card_winning_pattern.GetLength( 1 ); pat++ )
			{
				if( state.card_winning_pattern[current_card, pat] < bestwin )
				{
					bestwin = state.card_winning_pattern[current_card, pat];
					best_pattern = pat;
				}
			}

			label11.Text = current_card.ToString();
			label10.Text = current_pattern.ToString();
			label9.Text = (bestwin+1).ToString();

			for( int col = 0; col < 5; col++ )
				for( int row = 0; row < 5; row++ )
				{
					if( row == 2 && col == 2 )
						continue;

					if( ( pattern & ( 1 << ( col * 5 + row ) ) ) != 0 )
					{
						int cardnum = state.playing_cards[current_card][0, col, row];
						board[cardnum-1].BackColor = Color.Red;

						for( int ball = 0; ball < 75; ball++ )
							if( state.playing_balls[ball] == cardnum )
								board2[ball].BackColor = Color.Red;
					}

					//if( 
				}

		}

		private void button1_Click( object sender, EventArgs e )
		{
			if( current_card > 0 )
				current_card--;
			else
				current_card = 0;
			UpdateCard();
		}

		private void button5_Click( object sender, EventArgs e )
		{
			current_pattern = best_pattern;
			UpdateCard();
		}

		private void button4_Click( object sender, EventArgs e )
		{
			int len = state.card_winning_pattern.GetLength(1);
			if( current_pattern < ( len - 1 ) )
			{
				current_pattern++;
			}
			UpdateCard();
		}

		private void button3_Click( object sender, EventArgs e )
		{
			if( current_card < ( state.playing_cards.Count -1 ))
				current_card++;
			UpdateCard();
		}

		private void button2_Click( object sender, EventArgs e )
		{
			if( current_pattern > 0 )
				current_pattern--;
			else
				current_pattern = 0;
			UpdateCard();
		}

		private void button6_Click( object sender, EventArgs e )
		{
			int patterns = state.card_winning_pattern.GetLength(1);
			int cards = state.playing_cards.Count;
			int card;
			bool restarted = false;
		restart:
			for( card = current_card+1; card < cards; card++ )
			{
				int p;
				for( p = 0; p < patterns; p++ )
				{
					if( state.card_winning_pattern[card, p] == state.bestwin )
						break;
				}
				if( p < patterns )
					break;
			}
			if( card < cards )
				current_card = card;
			else
			{
				if( !restarted )
				{
					restarted = true;
					current_card = -1;
					goto restart;
				}
				else
					current_card = 0;
			}
			UpdateCard();
		}
		

		private void button7_Click( object sender, EventArgs e )
		{
			int patterns = state.card_winning_pattern.GetLength( 1 );
			int cards = state.playing_cards.Count;
			int card;
			int best_pattern_on_worst = 0;
			int worst = 0;
			int worstcard = -1;
			int first;
			if( last_is_worst )
				first = current_card + 1;
			else
				first = 0;

			for( card = first; card < cards; card++ )
			{
				int p;
				int bestwin = 75;
				for( p = 0; p < patterns; p++ )
				{
					if( state.card_winning_pattern[card, p] < bestwin )
					{
						best_pattern_on_worst = p;
						bestwin = state.card_winning_pattern[card, p];
					}
				}
				if( last_is_worst )
				{
					if( bestwin == best_count )
					{
						best_pattern = best_pattern_on_worst;
						worst = bestwin;
						worstcard = card;
						break;
					}
				}
				else
				{
					if( bestwin > worst )
					{
						best_pattern = best_pattern_on_worst;
						worst = bestwin;
						worstcard = card;
					}
				}
			}
			if( worstcard > -1 )
			{
				best_count = worst;
				current_card = worstcard;
				UpdateCard();
				last_is_worst = true;
			}
		}
	}
}