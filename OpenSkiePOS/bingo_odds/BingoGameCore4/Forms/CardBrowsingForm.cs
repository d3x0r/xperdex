using System;
using System.Drawing;
using System.Windows.Forms;

namespace BingoGameCore4.Forms
{
	public partial class CardBrowsingForm : Form
	{
		CheckBox[,] card = new CheckBox[5, 5];
		Control[] board = new Control[75];
		Control[] board2 = new Control[75];
		Control[] board3 = new Control[75];

		int current_game;
		int current_card;
		int current_pattern;
		int best_pattern;
		int best_count;
		bool last_is_worst; // so best pattern is the worst match...

		bool pack_browser_enabled;

		BingoSessionEvent session_event;
		BingoGameState state;
		BingoPlayer player;

		public CardBrowsingForm( BingoGameState s )
		{
			if( s == null )
				throw new Exception( "Bad state passed." );
			state = s;
			session_event = s.session_event;
			InitializeComponent();

			pack_browser_enabled = false;
			foreach( Pattern p in s.game.patterns )
				if( p.sub_patterns.Count > 1 )
				{
					pack_browser_enabled = true;
				}

			if( false )

			if( pack_browser_enabled )
			{
				bingoCardGroup1.Hide();
				//bingoPackGroup1.Show();
			}
			else
			{
				bingoCardGroup1.Show();
				//bingoPackGroup1.Hide();
			}
		}


		public CardBrowsingForm( BingoSessionEvent s )
		{
			if( s == null )
				throw new Exception( "Bad state passed." );
			session_event = s;
			if( s.BingoGameEvents.Count > 0 )
				state = s.BingoGameEvents[0];
			else
				state = null;
			// state = s;
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
			if( session_event.PlayerList != null && session_event.PlayerList.Count > 0 )
				player = session_event.PlayerList[0];

			if( player != null )
			{
				UpdateCard();

				bingoCardGroup1.Clear();
				foreach( BingoCardState card in player._played_cards[current_game] )
					bingoCardGroup1.Add( card );

				//bingoPackGroup1.Clear();
				/*
				foreach( PlayerPack pack in player.played_packs )
				{
					if( pack.Cards[current_game].Count > 0 )
						bingoPackGroup1.Add( pack, current_game );
				}
				 */
			}
		}

		void OutputBoard1MarkedWithCalled()
		{
			if( state.game_event.playing_balls != null )
			for( int ball = 0; ball < 75; ball++ )
			{
				int pos;
				for( pos = 0; pos < state.game_event.playing_balls.Length; pos++ )
					if( state.game_event.playing_balls[pos] == ( ball + 1 ) )
					{
						//board[ball].Text = ( pos + 1 ).ToString();
						board[ball].BackColor = Color.Red;
						board[ball].ForeColor = Color.White;
						break;
					}

				if( pos < state.game_event.playing_balls.Length )
					;
				else
					board[ball].BackColor = Color.Gray;
				board[ball].Text = ( ball + 1 ).ToString();
			}

		}

		void UpdateCard()
		{
			bool[] marked = new bool[75];
			int pattern = 0;
			if( player == null )
				return;
			if( current_game < player._played_cards.Count &&
				current_card < player._played_cards[current_game].Count )
				label11.Text = player._played_cards[current_game][current_card].unit_card_number.ToString();

			labelCardIndex.Text = current_card.ToString();
			labelGameNumber.Text = current_game.ToString();
			if( state.game == null )
				return;
			if( state.game.pattern_list != null )
			{
				if( current_pattern >= state.game.pattern_list.pattern_bitmask_list.Count )
					current_pattern = 0;

				if( state.game.pattern_list.pattern_bitmask_list.Count > 0 )
					pattern = state.game.pattern_list.pattern_bitmask_list[current_pattern];
				else
					pattern = 0x1ffffff;

				// cheap place to set this so we don't have it all over... 
				// though get_worst_card needs to re-set this after update.
				last_is_worst = false;

				//bingoCard11.Card = state.playing_cards[current_card];
				if( current_card < player._played_cards[current_game].Count )
				{
					pattern = player._played_cards[current_game][current_card].BestMask();
					for( int col = 0; col < 5; col++ )
						for( int row = 0; row < 5; row++ )
						{
							card[col, row].Checked = ( ( pattern & ( 1 << ( col * 5 + row ) ) ) != 0 );
							if( row == 2 && col == 2 )
								continue;
							byte[, ,] card_data = player._played_cards[current_game][current_card].CardData;
							card[col, row].Text = card_data[0, col, row].ToString();
							//if( 
						}
				}
			}
			bool option1 = false;// true;

			OutputBoard1MarkedWithCalled();
			if( state.game_event.playing_balls != null )
			{
				int ball ;
				for( ball = 0; ball < state.game_event.playing_balls.Length; ball++ )
				{
					if( ball >= board2.Length )
						break;
					board2[ball].Text = state.game_event.playing_balls[ball].ToString();
					board2[ball].BackColor = Color.Gray;
				}
				for( ; ball < 75; ball++ )
				{
					board2[ball].Text = "";
					board2[ball].BackColor = Color.Gray;
				}
			}
			if( state.game_event.playing_balls != null )
				for( int ball = 0; ball < 75; ball++ )
				{
					if( ball >= board3.Length )
						break;

					int pos;
					board3[ball].BackColor = Color.Gray;
					board[ball].ForeColor = Color.Black;
					board3[ball].Text = "";
					for( pos = 0; pos < state.game_event.playing_balls.Length; pos++ )
						if( state.game_event.playing_balls[pos] == ( ball + 1 ) )
						{
							board3[ball].Text = ( pos + 1 ).ToString();
							board3[ball].BackColor = Color.Green;
							board[ball].ForeColor = Color.White;
							break;
						}

				}


			//listBox1.Items.Clear();
			listBox1.DataSource = session_event._PlayerList;
			listBox1.SelectedIndexChanged += new EventHandler( listBox1_SelectedIndexChanged );
			//for( int pat = 0; pat < state.game.pattern_list.Count; pat++ )
			{
				//	listBox1.Items.Add( pat + "  ??" );
			}

			int bestwin = 75;

			foreach( BingoCardState card in state.playing_cards )
			{
				if( card.BestAway() == 0 )
				{
					bestwin = card.BallCount;
					best_pattern = 1;
				}
			}
#if asdfsadf
			for( int pat = 0; pat < state.game.pattern_list.Count; pat++ )
			{
				if( state.card_winning_pattern[current_card, pat] < bestwin )
				{
					bestwin = state.card_winning_pattern[current_card, pat];
					best_pattern = pat;
				}
			}
#endif
			label10.Text = current_pattern.ToString();
			if( current_card >= 0 && current_card < player._played_cards[current_game].Count )
			{
				labelCardIndex.Text = current_card.ToString();
				//label9.Text = state.card_winning_pattern[current_card, current_pattern].ToString();

				for( int col = 0; col < 5; col++ )
					for( int row = 0; row < 5; row++ )
					{
						if( row == 2 && col == 2 )
							continue;

						if( ( pattern & ( 1 << ( col * 5 + row ) ) ) != 0 )
						{
							byte[, ,] card_data = player._played_cards[current_game][current_card].CardData;
							int cardnum = card_data[0, col, row];

							board[cardnum - 1].BackColor = Color.Green;
							if( state.game_event.playing_balls != null )

								for( int ball = 0; ball < state.game_event.playing_balls.Length; ball++ )
								{
									if( ball >= board2.Length )
										break;
									if( state.game_event.playing_balls[ball] == cardnum )
										board2[ball].BackColor = Color.Yellow;
								}
						}

						//if( 
					}
			}
			else
			{
				labelCardIndex.Text = "Bad Index";
				label11.Text = "No Cards In Play";
			}

		}

		void listBox1_SelectedIndexChanged( object sender, EventArgs e )
		{
			BingoPlayer tmp_player = listBox1.SelectedItem as BingoPlayer;
			if( tmp_player != null )
			{
				if( player != tmp_player )
				{
					player = tmp_player;

					current_card = 0;

					bingoCardGroup1.Clear();
					foreach( BingoCardState card in player._played_cards[state.game.game_ID] )
						bingoCardGroup1.Add( card );

					/*
					bingoPackGroup1.Clear();
					foreach( PlayerPack pack in player.played_packs )
					{
						// was not matched as a pack.
						if( pack.state == null )
							continue;
						if( pack.Cards.Count > current_game )
							if( pack.Cards[current_game].Count > 0 )
								bingoPackGroup1.Add( pack, current_game );
					}
					*/
					UpdateCard();
				}
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

		void InitPlayer()
		{
			if( session_event._PlayerList.Count > 0 )
			{
				player = session_event._PlayerList[0];
				current_game = 0;
				current_card = 0;
				state = session_event.BingoGameEvents[current_game];
			}
		}

		private void button5_Click( object sender, EventArgs e )
		{
			int pattern;
			SetBestPattern();
			UpdateCard();
		}

		private void button4_Click( object sender, EventArgs e )
		{
			int len = state.game.pattern_list.pattern_bitmask_list.Count;
			if( current_pattern < ( len - 1 ) )
			{
				current_pattern++;
			}
			UpdateCard();
		}

		private void button3_Click( object sender, EventArgs e )
		{
			if( player != null )
			{
				if( current_card < ( player._played_cards[current_game].Count - 1 ) )
				{
					current_card++;
				}
			}
			else
			{
				InitPlayer();
			}
			SetBestPattern();
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

		private void SetBestPattern()
		{
			/*
			int p;
			int best_pat = 0;
			int patterns = state.game.pattern_list.Count;
			int bestwin = 75;
			for( p = 0; p < patterns; p++ )
			{
				foreach( wininfo win in state.winning_cards )
				{

					if( win.mask == state.game.pattern_list[pattern )
					{
						best_pat = p;
						//	bestwin = state.card_winning_pattern[current_card, p];
					}
				}
			}
			current_pattern = best_pat;
			*/
		}


		private void button6_Click( object sender, EventArgs e )
		{
			int patterns = state.game.pattern_list.pattern_bitmask_list.Count;
			int cards = state.playing_cards.Count;
			int card;
			int best = 75;
			int bestcard = current_card;
			bool restarted = false;
		restart:
			for( card = current_card+1; card < cards; card++ )
			{
				int p;
				int tmp;
				if( state.playing_cards[card].BestAway() == 0 )
				{
					break;
				}
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
				{
					current_card = 0;
					current_card = bestcard;
				}
			}
			SetBestPattern();
			UpdateCard();
		}
		

		private void button7_Click( object sender, EventArgs e )
		{
			int patterns = 0;// state.card_winning_pattern.GetLength( 1 );
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
					//if( state.card_winning_pattern[card, p] < bestwin )
					{
						best_pattern_on_worst = p;
					//	bestwin = state.card_winning_pattern[card, p];
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
			UpdateCard();
		}

		private void buttonPriorPack_Click( object sender, EventArgs e )
		{
			if( player != null )
			{
				if( current_game > 0 )
				{
					current_game--;
					current_card = 0;
					state = session_event.BingoGameEvents[current_game];
				}
			}
			else
			{
				InitPlayer();
			}
			UpdateCard();
		}

		private void buttonNextPack_Click( object sender, EventArgs e )
		{
			if( player != null )
			{
				if( current_game < ( session_event.BingoGameEvents.Count - 1 ) )
				{
					current_game++;
					current_card = 0;
					state = session_event.BingoGameEvents[current_game];
				}
				UpdateCard();
			}
			else
			{
				InitPlayer();
			}
		}

		private void CardBrowsingForm_Load( object sender, EventArgs e )
		{

		}

	}
}