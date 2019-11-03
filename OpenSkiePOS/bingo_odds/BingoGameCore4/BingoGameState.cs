using System;
using System.Collections.Generic;
using xperdex.classes;

namespace BingoGameCore4
{

	public class wininfo
	{
		public int card_index;
		public int card_number;
		public int mask;
		public BingoCardState playing_card;
		//public int away;
		public BingoPlayer player;
		public PlayerPack pack;
		public bool starburst;
		public bool starburst_marked;
		public bool hotball;
		public int  hotball_count;
		public int  ball_win_count;
        public bool bingo_match;
        public bool letter_color_match;
        public bool random_color_match;

		/// <summary>
		/// this list is the prize levels that the card qualified for; there may be more than one prize that a card wins.
		/// </summary>
		public List<BingoPrize> prize_levels;

		/// <summary>
		/// This is the computed amount of all prizes split and summed.
		/// </summary>
		public Money amount;

		public wininfo( int card_id, int card_number, int mask, BingoPlayer player, PlayerPack pack, byte[, ,] playing_card, int ball_count )
		{
			this.ball_win_count = ball_count;
			//this.playing_card = playing_card;
			this.card_number = card_number;
			this.card_index = card_id;
			this.mask = mask;
			this.player = player;
			this.pack = pack;
		}
		public wininfo( int card_id, BingoCardState card )
		{
			this.ball_win_count = card.BallCount;
			this.playing_card = card;
			this.card_number = card.unit_card_number;
			this.card_index = card_id;
			this.mask = card.BestMask();
			this.player = card.player;
			this.pack = card.pack;
		}
		public wininfo( int card, int mask, Guid player )
		{
//			this.playing_card = playing_card;
			this.card_number = card;
			this.mask = mask;
			this.player = new BingoPlayer( player );
		}
	}


	/// <summary>
	/// This is the core Bingo Game State.  This contains a session, a session_event, a game, a game_event
	/// a list of players, and lists of all packs that players are playing.  Additional Plugins should
	/// offer to add to these events to get appropriate external notifications.
	/// </summary>
	public class BingoGameState
	{
		public bool valid;
		/// <summary>
		/// If the state is not valid, this may indicate why... the game needs game.playing_balls
		/// </summary>
		public bool game_needs_balls;
		public BingoSessionEvent session_event;
		/// <summary>
		/// all cards of all players and their packs.
		/// </summary>
		public List<BingoCardState> playing_cards;
		public List<PlayerPack> playing_packs;

		//public BingoGame game;
		public BingoGameEvent _game_event; // this game's event.
		public BingoGameEvent game_event
		{
			set
			{
				_game_event = value;
			}
			get
			{
				return _game_event;
			}
		}
		public int game_event_index;
		public BingoGame game
		{
			get
			{
				if( _game_event == null || _game_event.games.Count == 0)
					return null;
				return _game_event.games[game_event_index];
			}
		}

		public int Players
		{
			get
			{
				if( session_event._PlayerList == null )
					return 0;
				return session_event._PlayerList.Count;
			}
		}
		// cards per player in this state.
		public int Cards  // which card ( players and card do not work
		{
			get
			{
				int Cards = 0;
				foreach( BingoPlayer player in session_event._PlayerList )
				{
					foreach( PlayerPack pack in player.played_packs )
					{
						Cards += pack.pack_info.count;
					}
				}
				return Cards;
			}
		}
		public int Packs
		{
			get
			{
				int Packs = 0;
				if( session_event._PlayerList == null )
					return 0;
				foreach( BingoPlayer player in session_event._PlayerList )
				{
					if( player.played_packs.Count > Packs )
						Packs = player.played_packs.Count;
				}
				return Packs;
			}
		}
		//public int PackSize;
		public int starting_balls;
		public int bestwin; // keep count of what the best ball win was... no search.
		public int bestwincount // count of winners at bestwin ball count
		{
			get
			{
				return winning_cards.Count;
			}
		}

		public int bestaway; // best away (so we can skip that many balls ahead.
		public List<wininfo> winning_cards;

		// which of course assumes the prior game completed!

		~BingoGameState()
		{
			//playing_cards.Clear()
			if( winning_cards != null )
				winning_cards.Clear();
		}

		public delegate void AddWinningCard( wininfo card );
		public event AddWinningCard WinningCardAdded;

		public void AddWinner( wininfo card )
		{
			winning_cards.Add( card );
			if( WinningCardAdded != null )
				WinningCardAdded( card );
		}
	}
}
