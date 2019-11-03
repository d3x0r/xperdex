using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BingoGameCore4.Networking;
using BingoGameCore4;
using BingoGameCore4.BallData;
using xperdex.classes;
using System.IO;
using BingoGameInterfaces;

namespace PlayerDrawing
{
	public partial class Form1 : Form
	{
		List<int> balls = new List<int>();
		String File_output;
		BallDataInterface bdi;
		BallDataInterface player_shuffler;
		int num_to_draw;
		public class Player
		{
			public int ID;
			public bool picked;
			public string card;
			public string name;
			public Player( int n, String card, string name )
			{
				ID = n;
				this.card = card;
				this.name = name;

			}
			public Player( int n )
			{
				ID = n;
				this.card = n.ToString();
				this.name = n.ToString();
			}
			public override string ToString()
			{
				return ID.ToString();
			}
		}

		List<Player> players;

		List<Player>[] lists;

		BallData_Random75 shuffler;

#if ORIGINAL_CODE_SUBMITTED
        // this code has some addtional comments around it.
        
// class used to choose from a list of players using some called balls.
internal class pick_set
{
	// information flag - indicates that this set has resulted in a single player
	internal bool finished;
	// this is the player tha the chooser resulted with
	internal Player picked;

	// this is an array of buckets which each have a list of players
	List<Player>[] buckets;
	// indicates a bucket has been chosen, and has been used.	This bucket will not
	// be re-filled with players on ReBucket.
	bool[] used_buckets;

	internal pick_set()
	{
		// allocate our buckets
		used_buckets = new bool[75];
		buckets = new List<Player>[75];
		for( int b = 0; b < 75; b++ )
		{
			buckets[b] = new List<Player>();
		}
	}

	// this takes the list of players and puts them in buckets
	// it also clears any existing players leftover in this chooser.
	internal void BucketPlayers( List<Player> players )
	{
		int n;
		finished = false;
		for( n = 0; n < 75; n++ )
		{
			used_buckets[n] = false;
			buckets[n].Clear();
		}

		n = 0;
		foreach( Player p in players )
		{
			buckets[n].Add( p );
			n++;
			if( n == 75 )
			{
				n = 0;
			}
		}
	}

	// this is called with a number indicating which bucket has been selected.
	// players in this bucket will be spread across remaining buckets.
	internal void ReBucketPlayers( int bucket )
	{
		List<Player> old_players;
		int n = 0;
		int m = 1;
		used_buckets[bucket] = true;
		old_players = buckets[bucket];
		if( old_players.Count == 0 )
		{
			// if we had ... 73 per bucket
			// the second pass we could call the last ball, and it would be an empty bucket.
			// at 72, the remainder will get split into last 2 buckets
			// at 71, the remainder will get split into last 3 buckets
			return;
		}
		if( old_players.Count == 1 )
		{
			finished = true;
			picked = old_players[0];
			//label5.Text = picked.ID.ToString();
			return;
		}
		buckets[bucket] = new List<Player>();
		for( n = 0; n < 75; n++ )
		{
			buckets[n].Clear();
		}
		n = 0;
		do
		{
			foreach( Player p in old_players )
			{
				while( used_buckets[n] )
				{
					n++;
					if( n == 75 )
					{
						n = 0;
						m++;
					}
				}
				buckets[n].Add( p );
				n++;
				if( n == 75 )
				{
					m++;
					n = 0;
				}
			}
		} while( m == 1 && ( old_players.Count <= 75 - n ) );
		if( m == 1 )
		{
			int j;
			int p = 0;
			int empty_start = n;
			int c_empty = 0;
			for( ; n < 75; n++ )
			{
				if( used_buckets[n] )
					continue;
				c_empty++;
			}

			if( c_empty > 1 )
			{
				while( p < old_players.Count )
				{
					for( j = empty_start; p < old_players.Count && j < 75; j++ )
					{
						if( used_buckets[j] )
							continue;
						buckets[j].Add( old_players[p] );
						p++;
					}
				}
			}
		}
	}
}


// choosers
pick_set[] sets;

// list of Players - information like name, card number stored in a class called Player (not included)
List<Player>[] lists;

// interface to get ball data - can be direct blower, or perhaps read information from payouts to get balls called.
BallDataInterface bdi;


class use_pick_set
{
	use_pick_set()
	{
		 // setup to choose num_to_draw players
		sets = new sets[num_to_draw];
		// allocate some lists of players...
		lists = new List<Player>[num_to_draw];
	}

	void FillPlayerList()
	{
		// do something to read database or other input for the information of players
		// fill lists of Player with players.
	}

	void ChoosePlayers()
	{

		int ball = 0;

		// put players in initial buckets.
		for( int p = 0; p < sets.Length; p++ )
			if( lists[p] != null )
				sets[p].BucketPlayers(lists[p]);


		// drop the balls
		bdi.DropBalls();

		while( !finished )
		{
			// tell the ball interface that we would like naother ball
			bdi.DrawBall();
			// some interfaces take time to get the next ball, so wait for it
			bdi.WaitForBall();
			// balls gets the array of all called balls, we're only going to use the last one...
			balls = bdi.GetBalls();
			finished = true;
			for( int p = 0; p < sets.Length; p++ )
			{
				// pass the ball chosen -1 (balls for bingo are 1-75, but we index buckets with 0-74)
				sets[p].ReBucketPlayers( balls[ball] - 1 );

				if( !sets[p].finished )
				{
					// mark taht we are not finished if the ball did not result in 1 player
					finished = false;
				}
			}
			// increment to use next ball.
			ball++;

		}
	}
}

#endif


		internal class pick_set
		{
			internal bool finished;
			internal Player picked;
			List<Player>[] buckets;
			bool[] used_buckets;
			internal pick_set()
			{
				used_buckets = new bool[75];
				buckets = new List<Player>[75];
				for( int b = 0; b < 75; b++ )
				{
					buckets[b] = new List<Player>();
				}
			}
			internal void BucketPlayers( List<Player> players )
			{
				int m = 1;
				int n;
				finished = false;
				//label3.Text = players.Count.ToString();
				//label3.Refresh();
				for( n = 0; n < 75; n++ )
				{
					used_buckets[n] = false;
					buckets[n].Clear();
				}

				n = 0;
				foreach( Player p in players )
				{
					buckets[n].Add( p );
					n++;
					if( n == 75 )
					{
						m++;
						n = 0;
					}
				}
				//label2.Text = n.ToString();
				//label2.Refresh();
				//label4.Text = m.ToString();
				//label4.Refresh();

			}

			internal void ReBucketPlayers( int bucket )
			{
				List<Player> old_players;
				int n = 0;
				int m = 1;
				used_buckets[bucket] = true;
				old_players = buckets[bucket];
				if( old_players.Count == 0 )
				{
					// if we had ... 73 per bucket
					// the second pass we could call the last ball, and it would be an empty bucket.
					// at 72, the remainder will get split into last 2 buckets
					// at 71, the remainder will get split into last 3 buckets
					return;
				}
				if( old_players.Count == 1 )
				{
					finished = true;
					picked = old_players[0];
					//label5.Text = picked.ID.ToString();
					return;
				}
				buckets[bucket] = new List<Player>();
				for( n = 0; n < 75; n++ )
				{
					buckets[n].Clear();
				}
				n = 0;
				do
				{
					foreach( Player p in old_players )
					{
						while( used_buckets[n] )
						{
							n++;
							if( n == 75 )
							{
								n = 0;
								m++;
							}
						}
						buckets[n].Add( p );
						n++;
						if( n == 75 )
						{
							m++;
							n = 0;
						}
					}
				} while( m == 1 && ( old_players.Count <= 75 - n ) );
				if( m == 1 )
				{
					int j;
					int p = 0;
					int empty_start = n;
					int c_empty = 0;
					for( ; n < 75; n++ )
					{
						if( used_buckets[n] )
							continue;
						c_empty++;
					}

					if( c_empty > 1 )
					{
						while( p < old_players.Count )
						{
							for( j = empty_start; p < old_players.Count && j < 75; j++ )
							{
								if( used_buckets[j] )
									continue;
								buckets[j].Add( old_players[p] );
								p++;
							}
						}
					}
				}
				//label2.Text = n.ToString();
				//label2.Refresh();
				//label4.Text = m.ToString();
				//label4.Refresh();
			}
		}

		pick_set[] sets;

		void AbortStatus()
		{
			StreamWriter sw = null;
			{
				sw = new StreamWriter( File_output, false );
				sw.WriteLine( "Not Enough Players,000000000000000000,0" );
				sw.Close();
			}
		}


		public Form1( string[] args )
		{
			InitializeComponent();
			num_to_draw = INI.Default["Player Select"]["player draw count"].Integer;
			sets = new pick_set[num_to_draw];
			for( int p = 0; p < num_to_draw; p++ )
				sets[p] = new pick_set();
			lists = new List<Player>[num_to_draw];
			players = new List<Player>();

			player_shuffler = new BallData_Random75();

			File_output = INI.Default["Output"]["File Path", "c:/players/winners.txt"];

			if( INI.Default["Ball Select"]["Use prize validation database"].Bool )
			{
				bdi = null;
			}
			else if( INI.Default["Ball interface"]["Use random Ball generator", "1"].Bool )
				bdi = new BallData_Random75();

			if( args.Length > 1 )
			{
				if( args[1] == "go" )
				{
					button7_Click( button7, new EventArgs() );
					if( players.Count > 5 )
						button2_Click( button2, new EventArgs() );
					else
						AbortStatus();
					this.Close();
				}
			}
		}

		void UpdateStatus()
		{
			StreamWriter sw = null;
			int written = 0;
			try
			{
				sw = new StreamWriter( File_output, false );
			}
			catch( DirectoryNotFoundException )
			{
				MessageBox.Show( "Path does not exist for file [" + File_output + "]" + "\n Will not write file output, sorry." );
				return;
			}

			catch( FileNotFoundException )
			{
				MessageBox.Show( "Path does not exist for file [" + File_output + "]" );
				return;
			}
			listBox1.Items.Clear();
			restart:
			for( int p = 0; p < num_to_draw; p++ )
			{
				if( sets[p].picked != null )
				{
					for( int p2 = p + 1; p2 < num_to_draw; p2++ )
					{
						if( sets[p].picked.card == sets[p2].picked.card )
						{
							List<Player> shuffled = new List<Player>();
							{
								BallDataInterface bdi = shuffler;
								int[] order = player_shuffler.CallBalls( players.Count );
								for( int p3 = 0; p3 < players.Count; p3++ )
								{
									shuffled.Add( players[order[p3] - 1] );
								}
							}
							sets[p2].BucketPlayers( shuffled );
							for( int n = 0; n < this.balls.Count; n++ )
							{
								sets[p2].ReBucketPlayers( balls[n] );
								if( sets[p2].finished )
									break;
							}
							goto restart;
						}
					}
				}
			}
			for( int p = 0; p < num_to_draw; p++ )
			{
				if( sets[p].finished )
				{
					sw.WriteLine( sets[p].picked.name + "," + sets[p].picked.card + '@' + players.Count );
					written++;
					listBox1.Items.Add( sets[p].picked.name );
				}
			}
			if( written == 0 )
				sw.WriteLine( "No Player,000000000000000000,0" );
			sw.Close();
		}

		void ReShufflePlayers( int list )
		{

		}

		private void button2_Click(object sender, EventArgs e)
		{
			int[] balls;
			bool finished = false;

            listBox1.Items.Clear();
			this.balls.Clear();

			if( bdi == null )
	
			ballImage1.Ball = 0;
			ballImage2.Ball = 0;
			ballImage3.Ball = 0;
			ballImage4.Ball = 0;
			ballImage5.Ball = 0;
			label5.Text = "";
			for( int p = 0; p < num_to_draw; p++ )
				if( lists[p] != null )
					sets[p].BucketPlayers(lists[p]);

			if( bdi != null )
			{
				bdi.DropBalls();
				bdi.DrawBall();
				bdi.WaitForBall();
				balls = bdi.GetBalls();
			}
			else
			{
				{
					object result = StaticDsnConnection.dsn.ExecuteScalar( "select ball_list from prize_validations where bingoday=curdate() and session_id=" + INI.Default["Ball Select"]["Session Number"].Value + " and game_id=" + INI.Default["Ball Select"]["Game Number"].Value );
					string called_balls = result.ToString();
					String[] sep_balls = called_balls.Split( new char[] { ' ' } );
					int n_ball = 0;
					balls = new int[75];
					foreach( String s in sep_balls )
					{
						balls[n_ball++] = Convert.ToInt32( s );
					}

				}
			}

			ballImage1.Ball = balls[0];

			finished = true;
			this.balls.Add( balls[0] );
			for( int p = 0; p < num_to_draw; p++ )
				if( !sets[p].finished )
				{
					finished = false;
					sets[p].ReBucketPlayers( balls[0] - 1 );
				}
			if( finished )
			{
				UpdateStatus();
				return;
			}
			if( bdi != null )
			{
				bdi.DrawBall();
				bdi.WaitForBall();
				balls = bdi.GetBalls();
			}
			ballImage2.Ball = balls[1];
			this.balls.Add( balls[1] );

			finished = true;
			for( int p = 0; p < num_to_draw; p++ )
				if( !sets[p].finished )
				{
					finished = false;
					sets[p].ReBucketPlayers( balls[1] - 1 );
				}
			if( finished )
			{
				UpdateStatus();
				return;
			}

			if( bdi != null )
			{
				bdi.DrawBall();
				bdi.WaitForBall();
				balls = bdi.GetBalls();
				while( balls.Length < 2 )
				{
					bdi.WaitForBall();
				}
			}
            ballImage3.Ball = balls[2];
            this.balls.Add( balls[2] );

            finished = true;
			for( int p = 0; p < num_to_draw; p++ )
				if( !sets[p].finished )
				{
					finished = false;
					sets[p].ReBucketPlayers( balls[2] - 1 );
				}
			if( finished )
			{
				UpdateStatus();
				return;
			}

			if( bdi != null )
			{
				bdi.DrawBall();
				bdi.WaitForBall();
				balls = bdi.GetBalls();
			}
			ballImage4.Ball = balls[3];
			this.balls.Add( balls[3] );

			finished = true;
			for( int p = 0; p < num_to_draw; p++ )
				if( !sets[p].finished )
				{
					finished = false;
					sets[p].ReBucketPlayers( balls[3] - 1 );
				}
			if( finished )
			{
				UpdateStatus();
				return;
			}

			if( bdi != null )
			{
				bdi.DrawBall();
				bdi.WaitForBall();
				balls = bdi.GetBalls();
			}
			ballImage5.Ball = balls[4];
			this.balls.Add( balls[4] );

			finished = true;
			for( int p = 0; p < num_to_draw; p++ )
				if( !sets[p].finished )
				{
					finished = false;
					sets[p].ReBucketPlayers( balls[4] - 1 );
				}
			UpdateStatus();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Random r = new Random();
			int n;
			BallDataInterface bdi;
			//for( n = 0; n < 5550; n++ )
				for( n = 0; n < 5325; n++ )
					players.Add( new Player( r.Next( 1000000000 ) ) );

				bdi = shuffler = new BallData_Random75( players.Count );
				for( n = 0; n < num_to_draw; n++ )
				{
					int[] order;
					lists[n] = new List<Player>();
					order = bdi.CallBalls( players.Count );
					for( int p = 0; p < players.Count; p++ )
					{
						lists[n].Add( players[order[p]-1] );
					}
				}
				label3.Text = players.Count.ToString();
		}

		private void button3_Click( object sender, EventArgs e )
		{
			players.Clear();
			PlayerLoader pl = new PlayerLoader( players );
			pl.ShowDialog();
			pl.Dispose();


			int n;
			BallDataInterface bdi;
			bdi = shuffler = new BallData_Random75( players.Count );
			for( n = 0; n < num_to_draw; n++ )
			{
				int[] order;
				lists[n] = new List<Player>();
				order = bdi.CallBalls( players.Count );
				for( int p = 0; p < players.Count; p++ )
				{
					lists[n].Add( players[order[p] - 1] );
				}
			}
			label3.Text = players.Count.ToString();
		}

		private void button4_Click( object sender, EventArgs e )
		{
			OptionEditor oe = new OptionEditor();
			oe.ShowDialog();
			oe.Dispose();
		}

		private void button5_Click( object sender, EventArgs e )
		{
			UpdateStatus();
		}

        private void button6_Click( object sender, EventArgs e )
        {
            DrawingSetup ds = new DrawingSetup();
            ds.ShowDialog();
            ds.Dispose();
        }

        private void button7_Click( object sender, EventArgs e )
        {
            DataTable tmp = new DataTable();
			String sql_script = INI.Default["Player Select"]["SQL Statement"].Value;
			String[] sql_commands = sql_script.Split( new char[] { ';' } );
			int n_command = 0;
			string card_column = INI.Default["Player Select"]["Card column name"].Value;
			string name_column = INI.Default["Player Select"]["Name column name"].Value;
			players.Clear();

			for( n_command = 0; n_command < (sql_commands.Length-1); n_command++ )
			{
				StaticDsnConnection.dsn.ExecuteNonQuery( sql_commands[n_command] );
			}
            if( DsnSQLUtil.FillDataTable( StaticDsnConnection.dsn, tmp, sql_commands[n_command], true ) != null )
            {
                // uhmm...
            }
            else
                tmp = null;
            if( tmp == null )
            {
                MessageBox.Show( StaticDsnConnection.dsn.Error, "SQL Error or No Data" );
                return;
            }

            foreach( DataRow row in tmp.Rows )
            {
                players.Add( new Player( 0, row[card_column].ToString(), row[name_column].ToString() ) );
            }
			int n;
			player_shuffler = shuffler = new BallData_Random75( players.Count );
			for( n = 0; n < num_to_draw; n++ )
			{
				int[] order;
				lists[n] = new List<Player>();
				
				order = player_shuffler.CallBalls( players.Count );
				for( int p = 0; p < players.Count; p++ )
				{
					lists[n].Add( players[order[p] - 1] );
				}
			}
			label3.Text = players.Count.ToString();
		}
	}
}
