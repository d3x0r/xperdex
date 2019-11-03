using System;
using System.Collections.Generic;
using System.Text;
using xperdex.classes;
using System.Data;
using System.Data.Common;
using OpenSkieScheduler3;
using BingoGameCore4.Database;

namespace BingoGameCore4
{
	public static class RateRank
	{
		//public static int max_rated_cards;
		//public static int max_rated_packs;
		static bool use_bonus_points;
		/// <summary>
		/// this is set externally by raterank2 ... maybe this module is closer to there than bingocore states...
		/// </summary>
		static MySQLDataTable _points;
		static DsnConnection input_db;

		public static BingoGameCore4.Database.RankPointsExtended game_points;

		public static void UpdateRanks()
		{
			if( input_db != null )
			{
				DbDataReader r = input_db.KindExecuteReader( "select min(bingoday),max(bingoday) from called_game_balls" );
				if( r == null )
					return;
				DateTime start = new DateTime();
				DateTime end = new DateTime();
				if( r!= null && r.HasRows )
				{
					if( r.Read() )
					{
						start = r.GetDateTime( 0 );
						end = r.GetDateTime( 1 );
					}
				}
				for( DateTime current = start; current < end; current = current.AddDays( 7 ) )
				{
					UpdateRanks( current, 1 );
				}
				input_db.EndReader( r );
			}
		}

		public static void UpdateRanks( DateTime day_in_week, int session )
		{
			if( input_db != null )
			{
				long week_id = StateWriter.GetWeekID( day_in_week, session );
				input_db.KindExecuteNonQuery( "replace into called_game_player_rank (card,session,bingoday,week_id,pack_set_id,game_count,total_points)"
						+ " SELECT card,session,bingoday,"+week_id+",pack_set_id,count(*) as game_count,sum(total_points) as total_points"
						+ " FROM called_game_player_rank2 where "
					    //+ (true?"pack_set_id=1":"pack_set_id>0")
						+ " card<>'000000000000000000'"
						//+ " and session=" + playing_session.session_number
						+ " and " + String_Utilities.BuildSessionRangeCondition( null, day_in_week, session )
						//+ " and bingoday=" + MySQLDataTable.MakeDateOnly( playing_session.bingoday )
						+ " group by card,pack_set_id,session,bingoday order by bingoday,session,card,pack_set_id"
						);

				if( use_bonus_points )
				{
					MySQLDataTable table = new MySQLDataTable( input_db, "select * from rate_rank_bonus_points" );
					MySQLDataTable totals = new MySQLDataTable( input_db, "select * from called_game_player_rank where bingoday="+DsnSQLUtil.MakeDateOnly( input_db, day_in_week ) +" and session="+session+" order by total_points desc" );
					if( totals != null && ( totals.Rows.Count > 0 ) )
					{
						int place_num;
						foreach( DataRow row in table.Rows )
						{
							place_num = Convert.ToInt32( row["place_in_session"] );
							input_db.KindExecuteNonQuery( "replace into called_game_player_rank_bonus (card,week_id,bonus_points,bingoday,session)values("
								+ input_db.sql_value_quote_open + totals.Rows[place_num - 1]["card"] + input_db.sql_value_quote_close + "," 
								+ week_id + ","
								+ row["bonus_points"].ToString() + ","
								+ DsnSQLUtil.MakeDateOnly( input_db, day_in_week ) + ","
								+ session 
								+ ")" );
						}
					}
				}
				if( use_bonus_points )
				{
					input_db.KindExecuteNonQuery(
						"replace into called_game_player_rank_partial (card,session,bingoday,total_points,week_id)"
	+ "select a.card,a.session,a.bingoday,a.total_points+sum(IF(ISNULL(c.bonus_points),0,c.bonus_points)),a.week_id from called_game_player_rank as a left"
	+ " join called_game_player_rank as b on a.card=b.card and a.week_id=b.week_id and a.total_points<b.total_points"
	+ " left join called_game_player_rank_bonus as c on a.card=c.card "
	+ " where b.card is null and a.week_id=" + week_id
	+ " group by a.card,a.session,a.bingoday,a.total_points,a.week_id"
					);
				}
				else
				{
					input_db.KindExecuteNonQuery(
						"replace into called_game_player_rank_partial (card,session,bingoday,total_points,week_id)"
	+ "select a.card,a.session,a.bingoday,a.total_points,a.week_id from called_game_player_rank as a left"
	+ " join called_game_player_rank as b on a.card=b.card and a.week_id=b.week_id and a.total_points<b.total_points"
	+ " where b.card is null and a.week_id=" + week_id
					);
				}
#if asdfasdf	
					"replace into called_game_player_rank_partial(card,session,bingoday,week_id,total_points)"
								+ " select card,session,bingoday,week_id,max(total_points) as total_points"
								+ " from called_game_player_rank"
								+ " where week_id=" + week_id 
								+ " group by bingoday,session,card"
						);
#endif
			}
		}

		[MySQLPersistantTable]
		public static MySQLDataTable points
		{
			get
			{
				if( _points == null )
				{
					_points = new MySQLDataTable( input_db );
					_points.TableName = "rate_rank_points2";
					DataColumn dc = _points.Columns.Add( "rate_rank_point_id", typeof( int ) );
					_points.ValueMemberName = "rate_rank_point_id";
					dc.AutoIncrement = true;
					dc.AutoIncrementSeed = 1;
					_points.Columns.Add( "away_count", typeof( int ) );
					_points.Columns.Add( "points", typeof( int ) );
					_points.PrimaryKey = new DataColumn[] { _points.Columns[0] };
				}
				return _points;
			}
		}


		public static void Setup( DsnConnection dsn )
		{
			if( input_db == null )
				input_db = dsn;
			use_bonus_points = Options.Default["Rate Rank"]["Use Placment Bonus Points", "1", "Whether to use the external bonus point table definitino (tweaks scores to give some motion"].Integer != 0;
		}

		internal class PlayerBestPackSet
		{
			internal int points;
			internal List<BingoPack> member_packs;

		}
		internal class PlayerBestCard
		{
			internal int card_number;
			internal int pack_number;
			internal BingoPlayer player;
			internal int away_count;
			internal PlayerBestCard( int pack, int card, BingoPlayer player, int away )
			{
				card_number = card;
				pack_number = pack;
				this.player = player;
				away_count = away;
			}
			public override string ToString()
			{
				return "card " + card_number + " away " + away_count;
			}
		};

		static bool GameCounts( BingoGameState s )
		{
			int game_number = s.game.game_number;
			DataRow drSession = s.session_event.session.dataRowSession;

			if( drSession != null )
			{
				DbDataReader r = input_db.KindExecuteReader( "select rate from rate_rank_game_config"
					+ " join elec_sch2_session_game_group_game using(session_game_group_game_id)"
					+ " where game_number=" + game_number + " and session_id=" + drSession[SessionTable.PrimaryKey]
					);
				if( r.HasRows )
				{
					while( r.Read() )
					{
						if( r.GetBoolean( r.GetOrdinal( "rate" ) ) )
							return true;
					}
				}

			}
			else
			{
				DbDataReader r = input_db.KindExecuteReader( "select rate from rate_rank_game_config"
					+ " join elec_sch2_session_game_group_game using(session_game_group_game_id)"
					+ " join elec_sch2_session_macro_session using(session_id)"
					+ " join elec_sch2_session_macro_schedule using(session_macro_id)"
					+ " where game_number=" + game_number 
					+ " and session_number=" + s.session_event.session.session
					+ " and starting_date<=" + DsnSQLUtil.MakeDateOnly( input_db, s.session_event.bingoday )
					+ " order by starting_date desc"
					+ " limit 1"
					);
				if( r != null && r.HasRows )
				{
					while( r.Read() )
					{
						if( r.GetBoolean( r.GetOrdinal( "rate" ) ) )
							return true;
					}
				}

			}
			return false;
		}


		public static bool Calculate( BingoGameState s )
		{
			//return false;
			if( !s.game.rate )
				return false;
			//if( !GameCounts( s ) )
			//   return false;
            int electronic_one_away;
            int paper_one_away;
            if( s.session_event.session.schedule != null )
            {
                {
                    //DataRow[] e = game_points.Select( "type=1 and " + OpenSkieScheduler.Relations.SessionGameGroupGameOrder.PrimaryKey + "=" + s.game.session_game_group_game_id );
                    //electronic_one_away = e.Length > 0 ? Convert.ToInt32( e[0]["points"] ) : 0;
                    //DataRow[] p = game_points.Select( "type=2 and " + OpenSkieScheduler.Relations.SessionGameGroupGameOrder.PrimaryKey + "=" + s.game.session_game_group_game_id );
                    //paper_one_away = p.Length > 0 ? Convert.ToInt32( p[0]["points"] ) : 0;
                }
            }
			//if( s.bestwin < max_balls )
			{
				int[] totals = new int[26];
				//int[, ,] player_totals = new int[s.Players, s.Packs, 26];
				//int[] limited_totals = new int[26];
				//int[, ,] limited_player_totals = new int[s.Players, s.Packs, 26];
				List<PlayerBestCard>[] all_bests = new List<PlayerBestCard>[s.Players];
				//List<PlayerBestPackSet>[] all_pack_bests = new List<PlayerBestPackSet>[s.Packs];
				if( s.session_event._PlayerList != null )
				{
					int count = 0;

					int game_index = s.game.game_ID;

					//Log.log( "calculating for game " + game_index );

					foreach( PlayerPack pack in s.playing_packs )
//					foreach( BingoCardState card in s.playing_cards )
					//foreach( BingoPlayer player in s.session_event._PlayerList )
					{
						BingoPlayer player = pack.player;
						//PlayerPack pack = card.pack;
						int max_set = 0;
						int min_set = s.Packs;

						while( pack.card_away_count.Count <= game_index )
						{
							pack.card_away_count.Add( new List<CardPoints>() );
							//player.card_away_count.
						}

						{
							int set = pack.pack_set;
							if( set > 0 )
							{
								//while( set > best_packs.Count )
								//	best_packs.Add( new PlayerBestPackSet() );
								//best_packs[set - 1].member_packs.Add( pack.pack_info );
								//best_packs[set - 1].points = 0;
								if( set > max_set )
									max_set = set;
								if( set < min_set )
									min_set = set;
							}
							int this_count = s.game.GetCardCount( pack.pack_info );

							//Log.log( "Processing pack " + pack );

							foreach( BingoCardState card in pack.Cards[s.game.game_group.game_group_ID] )
							//lock( pack.card_away_count )
							{
								while( pack.card_away_count[game_index].Count <= card.pack_card_index )
								{
									// expand for number of cards in this game that this pack is...
									pack.card_away_count[game_index].Add( new CardPoints() );
								}

								int pack_points = 0;
								//for( int card = 0; card < count; card++ )

								{
									int away_count = card.BestAway();
									//Log.log( "Card away is " + away_count );
									pack.card_away_count[game_index][card.pack_card_index].away = away_count;
									if( away_count == 1 )
									{
										//if( pack.paper )
										//	pack.card_away_count[game_index][card.pack_card_index].points = paper_one_away;
										//else
										//	pack.card_away_count[game_index][card.pack_card_index].points = electronic_one_away;
									}
									else
										pack.card_away_count[game_index][card.pack_card_index].points = 0;

#if old_scoring_system
									DataRow[] value = points.Select( "away_count=" + away_count );
									if( value.Length > 0 )
										//best_packs[set - 1].points += Convert.ToInt32( value[0]["points"] );
										pack.card_away_count[game_index][card.pack_card_index].points = Convert.ToInt32( value[0]["points"] );

									pack.card_away_count[game_index][card.pack_card_index].away = away_count;
									//if( away_count > 0 )
									//player_totals[player.ID, pack_number, away_count]++;
									totals[away_count]++;
									//player_totals[player.ID, set, away_count]++;
#endif
#if using_absolute_best_cards
									if( max_rated_cards == 0 ||
											bests.Count < max_rated_cards )
									{
										//Log.log( "less than 84... adding " + away_count );
										bests.Add( new PlayerBestCard( pack_number, card_id, player, away_count ) );
									}
									else
									{
										int worst_away = 0;
										foreach( PlayerBestCard a in bests )
										{
											if( a.away_count > worst_away )
												worst_away = a.away_count;
										}
										//Log.log( "worst is " + worst_away + " this is " + away_count );
										if( worst_away > away_count )
										{
											// okay there is a card worse than this somewhere... get it and replace it.
											int swapout = bests.FindIndex( delegate( PlayerBestCard a ) { return ( a.away_count == worst_away ); } );
											if( swapout >= 0 )
											{
												//Log.log( "swapping " + swapout );
												bests[swapout] = new PlayerBestCard( pack_number, card_id, player, away_count );
											}
										}
									}
#endif
								}
							}
							count += s.game.GetCardCount( pack.pack_info );
						}

					}
				}
				else
				{
#if asdfasdf
					for( int player = 0; player < ( s.Players ); player++ )
					{
						for( int _card = 0; _card < ( s.Cards ); _card++ )
						{
							int card = player * s.Cards + _card;
							//Console.WriteLine( card+"=="+ s.playing_card_away[card, s.bestwin] );
							totals[s.playing_card_away[card, s.bestwin - 1]]++;
							player_totals[player, _card / s.PackSize, s.playing_card_away[card, s.bestwin - 1]]++;
						}
					}
#endif
				}
				//s.playing_card_away_totals = totals;
				//s.playing_card_away_pack_player_totals = player_totals;
				//s.playing_card_away_totals_limited = limited_totals;
				//s.playing_card_away_pack_player_totals_limited = limited_player_totals;
			}
			return true;
		}


	}
}
