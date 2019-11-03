using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using xperdex.classes;
using System.Data.Common;
using BingoGameCore4;

namespace TestBonanza
{
	public partial class Form1 : Form
	{
		OpenSkieScheduler3.ScheduleDataSet schedule;
		List<int[]> calls;

		public Form1()
		{
			schedule = new OpenSkieScheduler3.ScheduleDataSet();
			calls = new List<int[]>();
			InitializeComponent();
		}

		private void button1_Click( object sender, EventArgs e )
		{
			// Load cardset

		}

		private void button2_Click( object sender, EventArgs e )
		{
			// Load balls
			int[] ball_calls;
			int n;
			String command = "select ";
			for( n = 0; n < 45; n++ )
			{
				if( n > 0 )
					command += ",";
				command += "call_" + n.ToString( "00" );
			}
			command += " from ball_calls_aways";
			DsnConnection dsn;
			dsn = new DsnConnection( "ballcalls.db" );
			DbDataReader reader = dsn.ExecuteReader( command );
			if( reader.HasRows )
			{
				while( reader.Read() )
				{
					int[] ballset = new int[45];
					int ball;
					for( ball = 0; ball < 45; ball++ )
					{
						ballset[ball] = Convert.ToInt32( reader[ball] );
					}
					calls.Add( ballset );
				}
			}
		}

		private void button3_Click( object sender, EventArgs e )
		{
			// play cards vs db...

			BingoSession session = new BingoSession();
			Pattern p = new Pattern();
			p.algorithm = OpenSkieScheduler3.PatternDescriptionTable.match_types.CrazyMark;
			p.repeat_count = 24;
			p.crazy_hardway = true;

			BingoGame game;
			session.GameList.Add( game = new BingoGame( new BingoGameCore4.Pattern[] { p } ) );

			BingoGameGroup game_group = new BingoGameGroup( Guid.Empty );
			game_group.Add( game );

			BingoPacks packs = new BingoPacks( session.GameList, schedule, null );

			
			BingoGameCore4.CardMaster.CardReader card_file 
				= new BingoGameCore4.CardMaster.CardReader( "c:\\ftn3000\\data\\cards\\Random 360k (50s300w)(81_Full).20110225.dat" );

			BingoDealer dealer = BingoDealers.GetDealer( card_file, 1, 1 );

			packs.CreatePack( dealer, "Test Pack" );
			BingoPack pack = packs.MakePack( "Test Pack", card_file.Length );

			BingoSessionEvent session_evnet = new BingoSessionEvent( session, true );
			BingoPlayer player;
			player = new BingoPlayer();
		
			PlayerTransaction transaction;
			player.transactions.Add( transaction = new PlayerTransaction( player, 12345689 ) );
			player.PlayPack( transaction, pack );

			session_evnet.PlayerList.Add( player );
			BallDataExternal bde = new BallDataExternal();
			session_evnet.ball_data = bde;

			BingoGameState game_state = session_evnet.StepTo( 0 );
			bde.Balls = calls[0];
			session_evnet.Play( game_state );

		}
	}
}
