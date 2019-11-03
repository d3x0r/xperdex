using System;
using xperdex.classes;
using System.Data;
using System.Threading;
using System.Text;

namespace BingoSQLTracking {
    
    
    public partial class BingoTracking 
	{
		public static bool disable;
		Timer timer;
		DsnConnection game_event_dsn;
		DsnConnection delay_game_event_dsn;

		bool doing_event_pending;
		DateTime last_event;
		object lock_object = new object();

		public void ConnnectBingoTrackingToDatabase( String dsn )
		{
			game_event_dsn = new DsnConnection( dsn );
			delay_game_event_dsn = new DsnConnection( dsn );
		}

		public void Create()
		{
			DsnSQLUtil.MatchCreate( game_event_dsn, this );
		}

		void CommitTimer( object state )
		{
			if( last_event != DateTime.MinValue )
			{
				lock( lock_object )
				{
					if( doing_event_pending )
						return;
					doing_event_pending = true;
				}
				DateTime compare = DateTime.Now.AddMilliseconds( -500 );
				if( compare > last_event )
				{
					DsnSQLUtil.CommitChanges( delay_game_event_dsn, this );
					this.AcceptChanges();
					last_event = DateTime.MinValue;
				}
				doing_event_pending = false;
			}
		}

		void CheckEvent( DataTable table, String event_name )
		{
			DataRow[] rows = table.Select( "event_name='" + event_name + "'" );
			if ( rows.Length == 0 )
			{
				DataRow newrow = table.NewRow();
				newrow[table.Columns[0]] = DsnConnection.GetGUID( game_event_dsn );
				newrow["event_name"] = event_name;
				table.Rows.Add( newrow );
			}
		}

		void ValidateSessionEvents()
		{
			CheckEvent( session_events, "open" );
			CheckEvent( session_events, "hotball" );
			CheckEvent( session_events, "end hotball" );
			CheckEvent( session_events, "generic" );
			CheckEvent( session_events, "close" );
		}

		void ValidateGameEvents()
		{
			CheckEvent( game_events, "open" );
			CheckEvent( game_events, "generic" );
			CheckEvent( game_events, "close" );
			CheckEvent( game_events, "pull" );
			CheckEvent( game_events, "call" );
			CheckEvent( game_events, "wild" );
			CheckEvent( game_events, "pass" );
			//CheckEvent( game_events, "drop balls" );
			CheckEvent( game_events, "winner found" );
			CheckEvent( game_events, "winner paid" );
			CheckEvent( game_events, "winner discard" );

		}

		bool loaded;
		void LoadEvents( DsnConnection dsn  )
		{
			if( !loaded )
			{
				DsnSQLUtil.FillDataTable( dsn, stream_state_cache );
				if ( stream_state_cache.Rows.Count == 0 )
				{
					DataRow newrow = stream_state_cache.NewRow();
					newrow["game_tracking_id"] = Guid.Empty;
					newrow["session_tracking_id"] = Guid.Empty;
					stream_state_cache.Rows.Add( newrow );
					DsnSQLUtil.CommitChanges( dsn, stream_state_cache );
					stream_state_cache.AcceptChanges();
				}
				DsnSQLUtil.FillDataTable( dsn, session_events );
				DsnSQLUtil.FillDataTable( dsn, game_events );
				ValidateSessionEvents();
				ValidateGameEvents();
				DsnSQLUtil.CommitChanges( dsn, session_events );
				DsnSQLUtil.CommitChanges( dsn, game_events );
				session_events.AcceptChanges();
				game_events.AcceptChanges();
				loaded = true;

				DsnSQLUtil.UpdateSeed( dsn, session_event_log, session_event_log.session_event_orderColumn );
				DsnSQLUtil.UpdateSeed( dsn, game_event_log, game_event_log.game_event_orderColumn );
				//DsnSQLUtil.UpdateSeed( dsn, session_tracking, session_tracking.session_tracking_orderColumn );
				DsnSQLUtil.UpdateSeed( dsn, game_tracking, game_tracking.game_tracking_orderColumn );
			}
		}


		// this type needs to be the Primary key type.
		object NoSessionGame = Guid.Empty;

		public void LoadCurrent()
		{
			timer = new Timer( CommitTimer, null, (int)250, (int)250 );
			
			LoadEvents( game_event_dsn );
			DsnSQLUtil.FillDataTable( game_event_dsn, session_tracking, session_tracking.session_tracking_idColumn.ColumnName + "='" + stream_state_cache.Rows[0][stream_state_cache.session_tracking_idColumn] + "'" );
			DsnSQLUtil.FillDataTable( game_event_dsn, session_event_log
				, session_event_log.session_tracking_idColumn.ColumnName + "='" + stream_state_cache.Rows[0][stream_state_cache.session_tracking_idColumn] + "'"
				, session_event_log.session_event_timeColumn.ColumnName + "," + session_event_log.session_tracking_idColumn );

			DsnSQLUtil.FillDataTable( game_event_dsn, game_tracking, game_tracking.game_tracking_idColumn.ColumnName + "='" + stream_state_cache.Rows[0][stream_state_cache.game_tracking_idColumn] + "'" );
			DsnSQLUtil.FillDataTable( game_event_dsn, game_event_log
				, game_event_log.game_tracking_idColumn.ColumnName + "='" + stream_state_cache.Rows[0][stream_state_cache.game_tracking_idColumn] + "'"
				, game_event_log.game_event_timeColumn.ColumnName + "," + game_event_log.game_tracking_idColumn );
		}

		public void OpenSession( DateTime bingoday, int session_number, String session_name )
		{
			if( disable )
				return;
			// there is no constructor that I can have on this
			// and the initialized event, which is available is unaccessable.

			// but - we should be opening a session before anything else.

			LoadEvents( game_event_dsn );

			CloseSession();

			DataRow[] event_id = session_events.Select( "event_name='open'" );

			DsnSQLUtil.FillDataTable( game_event_dsn, session_tracking
				, "bingoday='" + DateTime.Now.ToString()
				+ "' and session_number=" + session_number.ToString() );
			if ( session_tracking.Rows.Count == 0 )
			{
				DataRow tracking = session_tracking.NewRow();
				tracking[session_tracking.session_tracking_idColumn] = DsnConnection.GetGUID( game_event_dsn );
				tracking[session_tracking.session_numberColumn] = session_number;
				tracking[session_tracking.bingodayColumn] = bingoday;
				tracking[session_tracking.session_nameColumn] = session_name;
				tracking[session_tracking.session_createdColumn] = DateTime.Now;
				session_tracking.Rows.Add( tracking );
				DsnSQLUtil.CommitChanges( game_event_dsn, session_tracking );
				session_tracking.AcceptChanges();
			}
			else if ( session_tracking.Rows.Count > 1 )
			{
				Log.log( "session tracking table is in violation, more than one per bingoday-session." );
			}

			{
				DataRow open_event = session_event_log.NewRow();
				open_event[session_event_log.session_event_log_idColumn] = DsnConnection.GetGUID( game_event_dsn );
				open_event[session_event_log.session_tracking_idColumn] = session_tracking.Rows[0][session_tracking.session_tracking_idColumn];
				open_event[session_event_log.session_event_idColumn] = event_id[0][session_events.session_event_idColumn];
				open_event[session_event_log.session_event_timeColumn] = DateTime.Now;
				try
				{
					session_event_log.Rows.Add( open_event );
				}
				catch
				{
				}
				last_event = DateTime.Now;
			}

			stream_state_cache.Rows[0][stream_state_cache.session_tracking_idColumn] 
				= session_tracking.Rows[0][session_tracking.session_tracking_idColumn];
			DsnSQLUtil.CommitChanges( game_event_dsn, stream_state_cache );
			stream_state_cache.AcceptChanges();
		}

		public void CloseSession()
		{
			//LoadEvents( game_event_dsn );

			if( DsnSQLUtil.Compare( stream_state_cache.session_tracking_idColumn.DataType
				, stream_state_cache.Rows[0][stream_state_cache.session_tracking_idColumn], NoSessionGame ) )
				return;

			CloseGame();

			DataRow[] event_id = session_events.Select( game_events.event_nameColumn + "='close'" );

			{
				DataRow close_event = session_event_log.NewRow();
				close_event[session_event_log.session_event_log_idColumn] = DsnConnection.GetGUID( game_event_dsn );				
				close_event[session_event_log.session_tracking_idColumn] = stream_state_cache.Rows[0][stream_state_cache.session_tracking_idColumn];
				close_event[session_event_log.session_event_idColumn] = event_id[0][session_events.session_event_idColumn];
				close_event[session_event_log.session_event_timeColumn] = DateTime.Now;
				session_event_log.Rows.Add( close_event );
				last_event = DateTime.Now;
			}

			stream_state_cache.Rows[0][stream_state_cache.session_tracking_idColumn] = NoSessionGame;
			DsnSQLUtil.CommitChanges( game_event_dsn, stream_state_cache );
			stream_state_cache.AcceptChanges();
		}

		public Guid OpenGame( int game_number, int game_set, string game_name )
		{
			Guid result;
			if( disable )
				return Guid.Empty;
			//LoadEvents( game_event_dsn );
			CloseGame();
			DataRow[] event_id = game_events.Select( "event_name='open'" );
			while( last_event != DateTime.MinValue )
				Thread.SpinWait( 1 );
			foreach( DataRow row in game_tracking.Rows )
			{
				row.Delete();
			}
			this.AcceptChanges();
			//game_tracking.Rows.Clear();
			DsnSQLUtil.FillDataTable( game_event_dsn, game_tracking
				, game_tracking.session_tracking_idColumn.ColumnName 
				   + "='" + stream_state_cache.Rows[0][stream_state_cache.session_tracking_idColumn]
				+ "' and " + game_tracking.game_numberColumn + "=" + game_number.ToString() );
			if ( game_tracking.Rows.Count == 0 )
			{
				DataRow tracking = game_tracking.NewRow();
				tracking[game_tracking.game_tracking_idColumn] = result = DsnConnection.GetGUID( game_event_dsn );
				tracking[game_tracking.game_numberColumn] = game_number;
				tracking[game_tracking.ballsetColumn] = game_set;
				tracking[game_tracking.session_tracking_idColumn] = stream_state_cache.Rows[0][stream_state_cache.session_tracking_idColumn];
				tracking[game_tracking.game_nameColumn] = game_name;
				tracking[game_tracking.game_createdColumn] = DateTime.Now;
				game_tracking.Rows.Add( tracking );
			}
			else if ( game_tracking.Rows.Count > 1 )
			{
				Log.log( "game tracking table is in violation, more than one per bingoday-game." );
			}

			{
				DataRow open_event = game_event_log.NewRow();
				open_event[game_event_log.game_event_log_idColumn] = DsnConnection.GetGUID( game_event_dsn );
				open_event[game_event_log.game_tracking_idColumn] = game_tracking.Rows[0][game_tracking.game_tracking_idColumn];
				result = (Guid)game_tracking.Rows[0][game_tracking.game_tracking_idColumn];
				open_event[game_event_log.game_event_idColumn] = event_id[0][game_events.game_event_idColumn];
				open_event[game_event_log.ballColumn] = 0;
				open_event[game_event_log.game_event_timeColumn] = DateTime.Now;
				game_event_log.Rows.Add( open_event );
				last_event = DateTime.Now;
			}

			stream_state_cache.Rows[0][stream_state_cache.game_tracking_idColumn]
				= game_tracking.Rows[0][game_tracking.game_tracking_idColumn];
			return result;
		}

		public void CloseGame()
		{
			//LoadEvents( game_event_dsn );

			if( DsnSQLUtil.Compare( stream_state_cache.game_tracking_idColumn.DataType
				, stream_state_cache.Rows[0][stream_state_cache.game_tracking_idColumn]
				, NoSessionGame ) )
				return;
			
			DataRow[] event_id = game_events.Select( game_events.event_nameColumn + "='close'" );

			{
				DataRow close_event = game_event_log.NewRow();
				close_event[game_event_log.game_event_log_idColumn] = DsnConnection.GetGUID( game_event_dsn );
				close_event[game_event_log.game_tracking_idColumn] = stream_state_cache.Rows[0][stream_state_cache.game_tracking_idColumn];
				close_event[game_event_log.game_event_idColumn] = event_id[0][game_events.game_event_idColumn];
				close_event[game_event_log.ballColumn] = 0;
				close_event[game_event_log.game_event_timeColumn] = DateTime.Now;
				game_event_log.Rows.Add( close_event );
			}

			stream_state_cache.Rows[0][stream_state_cache.game_tracking_idColumn] = NoSessionGame;

			last_event = DateTime.Now;
		}

		public void PullBall( object sender, BingoGameInterfaces.BingoEvents.BingoSimpleIntEventArgs e )
		{
			int ball = e.arg;
			//LoadEvents( game_event_dsn );
			if( disable )
				return;

			if( DsnSQLUtil.Compare( stream_state_cache.game_tracking_idColumn.DataType
				, stream_state_cache.Rows[0][stream_state_cache.game_tracking_idColumn]
				, NoSessionGame ) )
				return;

			DataRow[] event_id = game_events.Select( game_events.event_nameColumn + "='pull'" );

			{
				DataRow pull_event = game_event_log.NewRow();
				pull_event[game_event_log.game_event_log_idColumn] = DsnConnection.GetGUID( game_event_dsn );
				pull_event[game_event_log.game_tracking_idColumn] = stream_state_cache.Rows[0][stream_state_cache.game_tracking_idColumn];
				pull_event[game_event_log.game_event_idColumn] = event_id[0][game_events.game_event_idColumn];
				pull_event[game_event_log.ballColumn] = ball;
				pull_event[game_event_log.game_event_timeColumn] = DateTime.Now;
				game_event_log.Rows.Add( pull_event );
				last_event = DateTime.Now;
			}

		}

		public void CallBall( object sender, BingoGameInterfaces.BingoEvents.BingoSimpleIntEventArgs e )
		{
			int ball = e.arg;
			if( disable )
				return;
			//LoadEvents( game_event_dsn );

			if( DsnSQLUtil.Compare( stream_state_cache.game_tracking_idColumn.DataType
				, stream_state_cache.Rows[0][stream_state_cache.game_tracking_idColumn]
				, NoSessionGame ) )
				return;

			DataRow[] event_id = game_events.Select( game_events.event_nameColumn + "='call'" );

			{
				DataRow call_event = game_event_log.NewRow();
				call_event[game_event_log.game_event_log_idColumn] = DsnConnection.GetGUID( game_event_dsn );
				call_event[game_event_log.game_tracking_idColumn] = stream_state_cache.Rows[0][stream_state_cache.game_tracking_idColumn];
				call_event[game_event_log.game_event_idColumn] = event_id[0][game_events.game_event_idColumn];
				call_event[game_event_log.ballColumn] = ball;
				call_event[game_event_log.game_event_timeColumn] = DateTime.Now;
				game_event_log.Rows.Add( call_event );
				last_event = DateTime.Now;
			}
		}

		public void UncallBall( object sender, BingoGameInterfaces.BingoEvents.BingoSimpleIntEventArgs e )
		{
			int ball = e.arg;
			if( disable )
				return;
			//LoadEvents( game_event_dsn );

			if( DsnSQLUtil.Compare( stream_state_cache.game_tracking_idColumn.DataType
				, stream_state_cache.Rows[0][stream_state_cache.game_tracking_idColumn]
				, NoSessionGame ) )
				return;

			DataRow[] event_id = game_events.Select( game_events.event_nameColumn + "='uncall'" );

			{
				DataRow call_event = game_event_log.NewRow();
				call_event[game_event_log.game_event_log_idColumn] = DsnConnection.GetGUID( game_event_dsn );
				call_event[game_event_log.game_tracking_idColumn] = stream_state_cache.Rows[0][stream_state_cache.game_tracking_idColumn];
				call_event[game_event_log.game_event_idColumn] = event_id[0][game_events.game_event_idColumn];
				call_event[game_event_log.ballColumn] = ball;
				call_event[game_event_log.game_event_timeColumn] = DateTime.Now;
				game_event_log.Rows.Add( call_event );
				last_event = DateTime.Now;
			}
		}

		public void StoreVerifiedCard( Guid player, object packinfo, int card_number, int win_mask, byte[, ,] card_face )
		{
			if( disable )
				return;
			//LoadEvents( game_event_dsn );

			if( DsnSQLUtil.Compare( stream_state_cache.game_tracking_idColumn.DataType
				, stream_state_cache.Rows[0][stream_state_cache.game_tracking_idColumn]
				, NoSessionGame ) )
				return;

			DataRow[] event_id = game_events.Select( game_events.event_nameColumn + "='winner found'" );

			{
				DataRow card_verified = game_event_log.NewRow();
				card_verified[game_event_log.game_event_log_idColumn] = DsnConnection.GetGUID( game_event_dsn );
				card_verified[game_event_log.game_tracking_idColumn] = stream_state_cache.Rows[0][stream_state_cache.game_tracking_idColumn];
				card_verified[game_event_log.game_event_idColumn] = event_id[0][game_events.game_event_idColumn];
				card_verified[game_event_log.ballColumn] = 0;
				card_verified[game_event_log.game_event_timeColumn] = DateTime.Now;
				game_event_log.Rows.Add( card_verified );
				last_event = DateTime.Now;
			}
		}

		public void HookEvents( BingoGameInterfaces.BingoEventInterface bei )
		{
			bei.BallCalled += this.CallBall;
			bei.BallPulled += this.PullBall;
			//bei.BallUncalled += this.UncallBall;
		}

		public Guid AddPlayer()
		{
			Guid guid;
			DataRow player_row = this.player.NewRow();
			player_row[player.player_idColumn] = guid = DsnConnection.GetGUID( game_event_dsn );
			player_row[player.session_tracking_idColumn] = stream_state_cache.Rows[0][stream_state_cache.session_tracking_idColumn];
			player.Rows.Add( player_row );
			last_event = DateTime.Now;
			return guid;
		}

		public Guid AddTransaction( Guid player_id, int transnum )
		{
			DataRow trans_row = this.player_pack_transaction.NewRow();
			Guid trans_id;
			trans_row[player_pack_transaction.player_idColumn] = player_id;
			trans_row[player_pack_transaction.transaction_idColumn] = trans_id = DsnConnection.GetGUID( game_event_dsn );
			trans_row[player_pack_transaction.transnumColumn] = transnum;
			trans_row[player_pack_transaction.session_tracking_idColumn] = stream_state_cache.Rows[0][stream_state_cache.session_tracking_idColumn];

			player_pack_transaction.Rows.Add( trans_row );
			last_event = DateTime.Now;
			return trans_id;
		}

		public Guid AddPackSetToGame( Guid pack_set )
		{
			DataRow game_pack = game_packs.NewRow();
			Guid guid;
			game_pack[game_packs.game_pack_set_idColumn] = guid = DsnConnection.GetGUID( game_event_dsn );
			game_pack[game_packs.game_tracking_idColumn] = stream_state_cache.Rows[0][stream_state_cache.game_tracking_idColumn];
			game_pack[game_packs.pack_set_idColumn] = pack_set;
			game_packs.Rows.Add( game_pack );
			last_event = DateTime.Now;
			return guid;
		}

		public Guid DefinePackSet()
		{
			DataRow pack_set_z = pack_set.NewRow();
			Guid guid;
			pack_set_z[pack_set.pack_set_idColumn] = guid = DsnConnection.GetGUID( game_event_dsn );
			pack_set.Rows.Add( pack_set_z );
			last_event = DateTime.Now;
			return guid;
		}
		

		public Guid AddPack( Guid pack_set_id, Guid trans_id )
		{
			DataRow pack_row = this.pack.NewRow();
			Guid guid;
			pack_row[pack.pack_idColumn] = guid = DsnConnection.GetGUID( game_event_dsn );
			pack_row[pack.pack_set_idColumn] = pack_set_id;
			pack_row[pack.transaction_idColumn] = trans_id;
			pack.Rows.Add( pack_row );
			last_event = DateTime.Now;
			return guid;
		}


		public Guid AddCard( object game_pack_set_id, Guid pack_id, int ballset, int card_number, byte[, ,] card_data )
		{
			StringBuilder sb = new StringBuilder();
			int f, r, c;
			for( f = 0; f < card_data.GetLength(0 ); f++ )
				for( c = 0; c < card_data.GetLength(1 ); c++ )
					for( r = 0; r < card_data.GetLength( 2 ); r++ )
					{
						if( f != 0 || r != 0 || c != 0 )
							sb.Append( "," );
						sb.Append( card_data[f, c, r].ToString() );
					}
			DataRow card_row = card.NewRow();
			card_row[card.game_pack_set_idColumn] = game_pack_set_id;
			card_row[card.ballsetColumn] = ballset;
			card_row[card.card_dataColumn] = sb.ToString();
			card_row[card.pack_idColumn] = pack_id;
			card_row[card.card_numberColumn] = card_number;
			Guid result;
			card_row[card.card_idColumn] = result = DsnConnection.GetGUID( game_event_dsn );
			card.Rows.Add( card_row );
			last_event = DateTime.Now;
			return result;
		}
		//public void AddPack( 

		public void AddWinner( Guid card_guid, int win_mask, Decimal prize )
		{
			DataRow winner_row = winner_info.NewRow();
			winner_row[winner_info.card_idColumn] = card_guid;
			winner_row[winner_info.game_tracking_idColumn] = stream_state_cache.Rows[0][stream_state_cache.game_tracking_idColumn];
			winner_row[winner_info.session_tracking_idColumn] = stream_state_cache.Rows[0][stream_state_cache.session_tracking_idColumn];
			winner_row[winner_info.winning_maskColumn] = win_mask;
			winner_row[winner_info.winner_idColumn] = DsnConnection.GetGUID( game_event_dsn );
			winner_row[winner_info.amountColumn] = prize;
			winner_info.Rows.Add( winner_row );
			last_event = DateTime.Now;
		}

	}
}
