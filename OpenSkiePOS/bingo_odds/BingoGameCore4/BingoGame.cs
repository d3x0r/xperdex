using System;
using System.Collections.Generic;
using System.Data;
using OpenSkieScheduler3;
using OpenSkieScheduler3.Relations;
using xperdex.classes;

namespace BingoGameCore4
{

	public class BingoGame
	{
		// events
		public string Name;
		public BingoGameList game_list;
		public BingoGame prior_game;
		public BingoGame prior_group_game;
		//public List<BingoGameGroup> game_groups;
		BingoGameGroup _game_group;
		public BingoGameGroup game_group
		{
			set
			{
				if( _game_group != null )
					throw new Exception( "Game is already in a game group" );
				_game_group = value;
			}
			get{ return _game_group; }
		}
		public bool playing;
		public bool starburst;
		public bool progressive;
		public bool extension; // like progressive, but does not call any further balls.  with progressive, allows hot-pattern specification.
		public bool rate;
		public bool lastBall;
		public bool last_letter_bingo;
		public bool last_random_colors;
		public int number_colored;
		public bool ignore_b_balls;
		public bool ignore_i_balls;
		public bool ignore_n_balls;
		public bool ignore_g_balls;
		public bool ignore_o_balls;

		///deprecated - double action is just a pack characteristic.
		//public bool double_action;
		public bool into; // this game is into the next game
		public bool overlapped; // implies progressive, but starts at same number of balls.
		public int cashballs;
		public object session_game_id; // a unique database identifier for this game in its session
		//public bool hotball;
		//public bool _5cashball; // plays in the cashball game...
		public bool quickshot;
		public bool standalone_play; // even if progressive, ignore prior game's lastball count (skip optimizatin)
		//public DataRow dataRow_game_group_game;
		//public object session_game_group_game_id;  // the specific ID of this game-group-game within a session.  (used for looking up rating bool)
		//public object game_group_id;

		public int game_ID; // for hotball tracking... we use sparse links...
		public Guid ID;
		public int game_number; // number from '1' for a session ll
		public int ballset_number; // which set of balls we are using for this game.
		public int page_skip; // total of skip...
		public List<Pattern> patterns;
		//public int pattern_overall_mask;
		public Pattern.PatternMasks pattern_list;
		//public List<int> pattern_list;
		public List<int> pack_card_counts; // [pack_index] result card count (for this game, each pack is known.
		public List<BingoPrize> prizes;

		public int upick_size;
		//public int bestwin; // the count of balls that best won this game list.
		//public int bestwincount; // all counts of balls that won this game....
		//public int prior_bestwin; // this is what the count of balls starts at (progressive)

		// this is the method to get more balls for this game...
		bool extended_info = true;

		public override string ToString()
		{
			string extra;
			if( extended_info )
				extra = " elec skip(" + ballset_number + ") paper skip[" + page_skip + "]";
			else
				extra = "";

			if( Name != null )
			{
				return Name + extra;
			}
			if( patterns.Count > 0 )
			{
				return patterns[0].ToString() + extra;
			}
			return "No Patterns." + extra;
		}

		void Init()
		{
			//game_groups = new List<BingoGameGroup>();
			prizes = new List<BingoPrize>();
			pack_card_counts = new List<int>();
		}

		public BingoGame( BingoGameList game_list, DataRow group_game )
		{
			BingoGame _game = ( ( game_list.Count > 0 ) ? game_list[game_list.Count - 1] : null );
			ScheduleDataSet schedule = game_list.schedule;
			Init();

			Name = group_game.ToString();
			game_number = Convert.ToInt32( group_game[SessionGame.NumberColumn] );

			//game_list.
			//dataRow_game_group_game = group_game;
			{
				DataRow[] tmp = group_game.GetChildRows( "session_game_has_session_game_group" );
				int n = 0;
				foreach( DataRow row in tmp )
				{
					BingoGameGroup bgg;
					this.game_group = bgg = game_list.game_group_list.GetGameGroup( row.GetParentRow( "session_game_group_in_session_game" ) );
					bgg.Add( this );
					{
						DataRow session_game_group = row.GetParentRow( "session_game_group_in_session_game" );
						DataRow[] game_prizes = session_game_group.GetChildRows( "game_group_has_pack" );
						//DataRow[] game_prizes = group_packs.
						//DataRow[] game_group_prizes = game_group_row.GetChildRows( "game_group_has_prize_level" );
						foreach( DataRow game_prize in game_prizes )
						{
							DataRow _prize = game_prize.GetParentRow( "prize_level_in_game_group" );
							if( _prize[PrizeLevelNames.PrimaryKey] == null )
							{
								int a = 3;
							}
							prizes.Add( new BingoPrize( _prize[PrizeLevelNames.PrimaryKey], 50 ) );
						}
						// should further check against overrides to get corrected prizes.
					}

				}
			}

			{
				Patterns new_patterns = new Patterns( schedule );

				DataRow[] GamePatterns = schedule.game_patterns.GetPatterns( group_game );
				//Log.log( "Selected " + GamePatterns.Length + " game pattes for " + group["game_info_id"] );
				foreach( DataRow pattern in GamePatterns )
				{
					object pattern_id = pattern[schedule.patterns.PrimaryKeyName];
					Log.log( "Looking up pattern " + pattern_id );

					Pattern GamePattern = new Pattern( pattern, new_patterns );
					new_patterns.Add( GamePattern );
				}
				SetPatterns( new_patterns.ToArray() );
			}

			if( Convert.ToBoolean( group_game["single_hotball"] ) )
				cashballs = 1;

			//double_action = Convert.ToBoolean( group_game["double_action"] );

			// Load all of the packs defined in this session.
			// these are used to validate sales loaded into players....
			// they are also used to collect raw informatino to match by name
			// the pack sales to pack definitions such ad dealer parameters.
			DataRow[] game_group_packs;

			{
				game_group_packs = schedule.session_games.GetGameGroupPacks( group_game );
				BingoPack pack = null;
				if( game_group_packs != null )
				{
					foreach( DataRow info in game_group_packs )
					{
						BingoGameGroup use_group = null;
						bool found = false;
						//foreach( BingoGameGroup game_group in game_groups )
						{
							DataRow real_game_group = info.GetParentRow( "game_group_prize_level_has_pack" );
							if( game_group.ID.Equals( real_game_group[ PackGroupTable.PrimaryKey ] ) )
							{
								use_group = game_group;
								found = true;
								break;
							}
						}
						if( !found )
						{
							game_group = use_group = new BingoGameGroup( info[ PackGroupTable.PrimaryKey ] );
						}

						game_group_packs = schedule.session_games.GetPacks( group_game );
						foreach( DataRow ggp in game_group_packs )
						{
							pack = game_list.pack_list.MakePack( use_group, ggp );
							while( pack_card_counts.Count <= pack.pack_type )
								pack_card_counts.Add( 0 );
						}

						if( pack == null )
						{
						}
						if( pack != null )
							pack_card_counts[ pack.pack_type ] = pack.count;
					}
				}

				prior_group_game = null;
				foreach( BingoGame g in game_list )
				{
					if( g == this )
						continue;
					//foreach( BingoGameGroup gamegroup in g.game_groups )
					{
						//foreach( BingoGameGroup this_group in this.game_groups )
						{
							if( g.game_group.ID.Equals( this.game_group.ID ) )
							{
								prior_group_game = g;
								break;
							}
						}
					}
				}
				if( prior_group_game == null )
				{
					page_skip = 0;
					// this isn't really an into, prior game might be 'normal' progressive, but 
					// that's really into the next part, not this one.
					into = false;
				}
				else
					if( into )
						page_skip = prior_group_game.page_skip;
					else
						page_skip = prior_group_game.page_skip + 1;

				//game_group_id = group_id;
			}
			// setup progressive game, and game skips (by page, and by absolute ball-set)
			{

				progressive = ( Convert.ToInt32( group_game["progressive"] ) != 0 );
				if( _game != null )
				{
					if( _game.progressive )
					{
						ballset_number = _game.ballset_number;
						into = true;
					}
					else
						ballset_number = _game.ballset_number + 1;
				}
				else
				{
					ballset_number = 0;
				}

			}

			// setup page_skip.
			{
				if( prior_group_game == null )
				{
					page_skip = 0;
					// this isn't really an into, prior game might be 'normal' progressive, but 
					// that's really into the next part, not this one.
					into = false;
				}
				else
					if( into )
						page_skip = prior_group_game.page_skip;
					else
						page_skip = prior_group_game.page_skip + 1;
			}
			//game_number = game_number;
			prior_game = _game;

			//_game = game;
		}

		public BingoGame()
		{
			Init();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="game_info">must cntain a column "number"</param>
		/// <param name="patterns"></param>
		public BingoGame( Pattern[] patterns )
		{
			Init();
			// this was to conslidate multiple types...
			SetPatterns( patterns );
		}

		public void SetPatterns( Pattern[] patterns )
		{
			this.patterns = new List<Pattern>();
			foreach( Pattern p in patterns )
				this.patterns.Add( p );
			pattern_list = new Pattern.PatternMasks();
			Pattern.ExpandGamePatterns( this.patterns, pattern_list );
		}

		public void LoadPrizeValidationForBalls( DateTime bingoday, int session )
 		{
		}

		public static bool StepCounters( ref int[] counters, int max, int which )
		{
			int x = which - 1;//; x >= 0; x-- )
			while( true )
			{
				counters[x]++;
				if( x > 0 )
				{
					if( counters[x] < ( max - ( counters.Length - which ) ) )
						return true;
					// need to recurse here ... 
					if( !StepCounters( ref counters, max, x ) )
						return false;
					counters[x] = counters[x - 1];
				}
				else
					break;
			}
			if( counters[0] < ( max - ( counters.Length - which ) ) )
				return true;
			return false;
		}





		internal int GetCardCount( BingoPack bingoPack )
		{
			if( bingoPack.pack_type < pack_card_counts.Count )
				return pack_card_counts[bingoPack.pack_type];
			return 0;
		}

		public BingoGameEvent CreateEvent()
		{
			return new BingoGameEvent( this );
		}

		internal void Extend( BingoGameList bingoGameList, DataRow group_game )
		{
			// patterns should be the same...
			// load all packs into this one also.
			// probably a group-game overlap mode
		}
	}
}
