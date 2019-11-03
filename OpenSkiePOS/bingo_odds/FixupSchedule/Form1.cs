using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OpenSkieScheduler;
using OpenSkieScheduler.BingoGameDefs;
using System.Data;
using System.Data.Common;
using xperdex.classes;

namespace FixupSchedule
{
	public partial class Form1 : Form
	{
		ScheduleDataSet schedule = new ScheduleDataSet( StaticDsnConnection.dsn );
		public Form1()
		{
			InitializeComponent();
		}

		int[,] regular_cards = { {3,2},{3,2},{3,2},{3,2}
									,{3,2},{3,2},{3,2},{3,2}
									,{3,1},{3,1},{3,1},{3,1}
									,{3,1},{3,1},{3,1},{3,1}
								};


		static string[] regular_packs = { "Level 1", "Level 2", "Level 3", "Level 4"
							 , "Level 1 Val", "Level 2 Val", "LEvel 3 Val", "Level 4 Val"
							 , "Lev 1 RB", "Lev 2 RB", "Lev 3 RB", "Lev 4 RB"
							 , "Lev 1 RB Val", "Lev 2 RB Val", "Lev 3 RB Val", "Lev 4 RB Val"
						 };

		int[,] jumbo_cards = { { 2, 1 }, { 2, 12 } };
		static string[] jumbo_packs = { "Jumbo"
								   , "12Pk Jumbo"
						 };
		int[,] countdown_cards = { { 2, 1 }, { 2, 12 } };
		static string[] countdown_packs = { "Countdown CA"
									   , "12Pk Countdown"
						 };
		int[,] big3_cards = { { 1, 1 }, { 1, 4 }, { 1, 24 } };
		static string[] big3_packs = { "Big 3"
								   , "Big 3 4 Pack"
								   , "Big 3 24 Pack"
						 };

		string[] packs_game_group = { "Normal", "Jumbo", "Countdown Coverall", "Big 3" };
		string[][] all_packs = { regular_packs, jumbo_packs, countdown_packs, big3_packs };

		private void button1_Click( object sender, EventArgs e )
		{
			//OpenSkieScheduler.ScheduleDataSet schedule = OpenSkieScheduler.OpenSkieSchedule.data;
			DataRow[] rows;


			DataRow[] dealer_row = schedule.dealer.Select( Dealer.NameColumn + "='Big3'" );
			if( dealer_row.Length == 0 )
			{
				DataRow row = schedule.dealer.NewRow();
				row[Dealer.NameColumn] = "Big3";
				row["card_skip"] = 1;
				row["page_skip"] = 1;
				row["row_skip"] = 0;
				row["column_skip"] = 0;
				schedule.dealer.Rows.Add( row );
				schedule.dealer.CommitChanges();
				dealer_row = new DataRow[1];
				dealer_row[0] = row;
				listBox1.Items.Add( "Added Big3 Dealer..." );
			}

			DataRow cardset_row = schedule.cardset_info.NewCardset( "Big3 Electronic" );
			if( cardset_row != null )
			{
				listBox1.Items.Add( "Added Big3 Electronic Cardset" );
				cardset_row["name"] = "f:/ftn3000/data/cards/ftnbonus.dat";
				DataRow range = schedule.cardset_ranges.NewCardsetRange( "Big3 E" );
				if( range != null )
				{
					range["start"] = 1;
					range["end"] = 63000;
					range[Dealer.PrimaryKey] = dealer_row[0][Dealer.PrimaryKey];
					range[CardsetInfo.PrimaryKey] = cardset_row[CardsetInfo.PrimaryKey];
					listBox1.Items.Add( "Added Big3 E Cardset Range" );
				}

			}

			cardset_row = schedule.cardset_info.NewCardset( "Big3 Paper" );
			if( cardset_row != null )
			{
				listBox1.Items.Add( "Added Big3 Paner Cardset" );
				cardset_row["name"] = "f:/ftn3000/data/cards/bkbonus.dat";
				DataRow range = schedule.cardset_ranges.NewCardsetRange( "Big3 P" );
				if( range != null )
				{
					range["start"] = 1;
					range["end"] = 63000;
					range[Dealer.PrimaryKey] = dealer_row[0][Dealer.PrimaryKey];
					range[CardsetInfo.PrimaryKey] = cardset_row[CardsetInfo.PrimaryKey];
					listBox1.Items.Add( "Added Big3 P Cardset Range" );

				}
			}
			schedule.cardset_info.CommitChanges();
			schedule.cardset_ranges.CommitChanges();

			//BingoGameCore3.Database.RankPointsExtended points = new BingoGameCore3.Database.RankPointsExtended( schedule );

			{
				DataRow[] session = schedule.sessions.Select( SessionTable.NameColumn + "='Regular'" );
				if( session.Length > 0 )
					schedule.session_game_group_game_order.Select( "session_id=" + session[0][SessionTable.PrimaryKey] );

			}

			for( int n = 0; n < regular_packs.Length; n++ )
			{
				rows = schedule.packs.Select( PackTable.NameColumn + "='" + regular_packs[n] + "'" );
				if( rows.Length == 0 )
				{
					DataRow pack = schedule.packs.NewPack( regular_packs[n], regular_cards[n, 0], regular_cards[n, 1] );
					listBox1.Items.Add( "Added " + regular_packs[n] );
				}
			}

			for( int n = 0; n < jumbo_packs.Length; n++ )
			{
				rows = schedule.packs.Select( PackTable.NameColumn + "='" + jumbo_packs[n] + "'" );
				if( rows.Length == 0 )
				{
					DataRow pack = schedule.packs.NewPack( jumbo_packs[n], jumbo_cards[n, 0], jumbo_cards[n, 1] );
					listBox1.Items.Add( "Added " + jumbo_packs[n] );
				}
			}
			for( int n = 0; n < big3_packs.Length; n++ )
			{
				rows = schedule.packs.Select( PackTable.NameColumn + "='" + big3_packs[n] + "'" );
				if( rows.Length == 0 )
				{
					DataRow pack = schedule.packs.NewPack( big3_packs[n], big3_cards[n, 0], big3_cards[n, 1] );
					pack["_3_number"] = true;
					listBox1.Items.Add( "Added " + big3_packs[n] );
				}
			}

			for( int n = 0; n < countdown_packs.Length; n++ )
			{
				rows = schedule.packs.Select( PackTable.NameColumn + "='" + countdown_packs[n] + "'" );
				if( rows.Length == 0 )
				{
					DataRow pack = schedule.packs.NewPack( countdown_packs[n], countdown_cards[n, 0], countdown_cards[n, 1] );
					listBox1.Items.Add( "Added " + countdown_packs[n] );
				}
			}




			int[] want = { 1, 2, 3, 4, 5, 6 };
			bool[] have = new bool[8];
			for( int a = 0; a < all_packs.Length; a++ )
			{
				for( int n = 0; n < all_packs[a].Length; n++ )
				{
					for( int m = 0; m < 6; m++ )
						have[m] = false;
					rows = schedule.packs.Select( PackTable.NameColumn + "='" + all_packs[a][n] + "'" );
					DataRow[] ranges = rows[0].GetChildRows( "pack_has_cardset_range" );
					foreach( DataRow range in ranges )
					{
						DataRow real_range = range.GetParentRow( "cardset_range_in_pack" );
						string name = real_range[OpenSkieScheduler.BingoGameDefs.CardsetRange.NameColumn] as String;
						if( name == "POS 1" )
							have[0] = true;
						if( name == "POS 2" )
							have[1] = true;
						if( name == "POS 3" )
							have[2] = true;
						if( name == "POS 4" )
							have[3] = true;
						if( name == "POS 5" )
							have[4] = true;
						if( name == "POS 6" )
							have[5] = true;
						if( name == "Big3 E" )
							have[6] = true;
						if( name == "Big3 P" )
							have[7] = true;

					}
					if( Convert.ToBoolean( rows[0]["_3_number"] ) )
					{
						if( !have[6] )
						{
							listBox1.Items.Add( "Fixed Big3 E Range on " + rows[0][PackTable.NameColumn] );
							DataRow[] range = schedule.cardset_ranges.Select( CardsetRange.NameColumn + "='Big3 E'" );
							DataRow relate = schedule.pack_cardset_ranges.NewRow();
							relate[CardsetRange.PrimaryKey] = range[0][CardsetRange.PrimaryKey];
							relate[PackTable.PrimaryKey] = rows[0][PackTable.PrimaryKey];
							schedule.pack_cardset_ranges.Rows.Add( relate );
						}
						if( !have[7] )
						{
							listBox1.Items.Add( "Fixed Big3 P Range on " + rows[0][PackTable.NameColumn] );
							DataRow[] range = schedule.cardset_ranges.Select( CardsetRange.NameColumn + "='Big3 P'" );
							DataRow relate = schedule.pack_cardset_ranges.NewRow();
							relate[CardsetRange.PrimaryKey] = range[0][CardsetRange.PrimaryKey];
							relate[PackTable.PrimaryKey] = rows[0][PackTable.PrimaryKey];
							schedule.pack_cardset_ranges.Rows.Add( relate );
						}

					}
					for( int m = 0; m < 6; m++ )
					{
						if( !have[m] )
						{
							DataRow[] range = schedule.cardset_ranges.Select( CardsetRange.NameColumn + "='POS " + ( m + 1 ) + "'" );
							DataRow relate = schedule.pack_cardset_ranges.NewRow();
							relate[CardsetRange.PrimaryKey] = range[0][CardsetRange.PrimaryKey];
							relate[PackTable.PrimaryKey] = rows[0][PackTable.PrimaryKey];
							schedule.pack_cardset_ranges.Rows.Add( relate );
						}
					}
					DataRow[] game_group = rows[0].GetChildRows( "pack_in_game_group" );
					if( game_group.Length == 0 )
					{
						DataRow[] real_game_group = schedule.game_groups.Select( GameGroupTable.NameColumn + "='" + packs_game_group[a] + "'" );
						if( real_game_group.Length > 0 )
						{
							listBox1.Items.Add( "Added pack " + all_packs[a][n] + " to game " + packs_game_group[a] );
							DataRow relation = schedule.game_group_packs.NewRow();
							relation[GameGroupTable.PrimaryKey] = real_game_group[0][GameGroupTable.PrimaryKey];
							relation[PackTable.PrimaryKey] = rows[0][PackTable.PrimaryKey];
							schedule.game_group_packs.Rows.Add( relation );
						}
					}
				}
			}


			schedule.packs.CommitChanges();
			schedule.pack_cardset_ranges.CommitChanges();
			schedule.game_group_packs.CommitChanges();
			listBox1.Items.Add( "Completed additions." );
		}

		private void button2_Click( object sender, EventArgs e )
		{

			//schedule = OpenSkieScheduler.OpenSkieSchedule.data;
			{
				// this data should be represented as a ball data...
				MySQLDataTable win_table = new MySQLDataTable( schedule.schedule_dsn
					, "select bingoday,session_id,game_id,ball_list,balls from prize_validations"
					+ " where bingoday = 20091130 and session_id=3 and game_id=2"
					+ " group by ball_list,balls"
					+ " order by ID desc"
					);

				if( win_table != null && win_table.Rows.Count > 0 )
				{
					byte[] playing_balls = new byte[80];
					int nRow;
					for( nRow = 0; nRow < win_table.Rows.Count; nRow++ )
					{
						if( Convert.ToInt32( win_table.Rows[nRow]["balls"] ) >= 75 )
							continue;
						DataRow win = win_table.Rows[nRow];
						String string_numbers = win["ball_list"].ToString();
						int count = Convert.ToInt32( win["balls"] );
						String[] numbers = string_numbers.Split();

						for( int n = 0; n < count; n++ )
						{
							if( numbers[n].Length > 0 )
								playing_balls[n] = Convert.ToByte( numbers[n] );
						}

						DbDataReader r = schedule.schedule_dsn.KindExecuteReader( "select bingo_game_id from bingo_game where bingoday='" 
							+ win_table.Rows[nRow]["bingoday"] 
							+ "' and session="+ win_table.Rows[nRow]["session_id"]
							+ " and game="+ win_table.Rows[nRow]["game_id"]
							);
						int game_id = 0;
						if( r != null && r.HasRows )
						{
							r.Read();
							game_id = r.GetInt32( 0 );
							schedule.schedule_dsn.EndReader( r );
							schedule.schedule_dsn.KindExecuteNonQuery( "delete from bingo_game_balls where bingo_game_id="+game_id );

						}
						if( game_id == 0 )
						{
							schedule.schedule_dsn.KindExecuteNonQuery( "insert into bingo_game (created,bingoday,session,game)values(now(),cast( '"+MySQLDataTable.MakeDateOnly( Convert.ToDateTime( win_table.Rows[nRow]["bingoday"]) )+"' as date),"
							+win_table.Rows[nRow]["session_id"]+","
							+win_table.Rows[nRow]["game_id"]+")" );
							game_id = (int)schedule.schedule_dsn.GetLastInsertID();

						}
						for( int n = 0; n < count; n++ )
						{
							schedule.schedule_dsn.KindExecuteInsert( "insert into bingo_game_balls(called_at,bingo_game_id,ball)values(now()," + game_id + "," + playing_balls[n] + ")" );
						}
					}
				}

			}

		}
	}
}
