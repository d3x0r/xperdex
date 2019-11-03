using System;
using System.Collections.Generic;
using System.Text;
using xperdex.classes;
using System.Data.Common;
using xperdex.classes.Types;

namespace xperdex.RateRankStatus
{
	internal static class RateRankState
	{
		internal static DateTime last_date = DateTime.Now;
		internal static int last_session;
		internal static int player_count;
		internal static int pack_count;
		internal static int low_score;
		internal static int high_score;

		internal static void Refresh()
		{
			DbDataReader r;
			r = StaticDsnConnection.KindExecuteReader( "select bingoday,session from called_game_player_rank order by called_game_player_rank_id desc limit 1" );
			if( r != null && r.HasRows )
			{
				int col;
				r.Read();
				last_date = r.GetDateTime( 0 );
				last_session = r.GetInt32( 1 );
			}

			r = StaticDsnConnection.KindExecuteReader( "select count(*),count(distinct card) from called_game_player_rank where bingoday=" + MySQLDataTable.MakeDateOnly( last_date ) + " and session=" + last_session + " and pack_set_id>0" );
			if( r != null && r.HasRows )
			{
				r.Read();
				pack_count = r.GetInt32( 0 );
				player_count = r.GetInt32( 1 );
			}

			r = StaticDsnConnection.KindExecuteReader( "select min(total_points),max(total_points) from called_game_player_rank where bingoday=" + MySQLDataTable.MakeDateOnly( last_date ) + " and session=" + last_session
				);
			if( r != null && r.HasRows )
			{
				r.Read();
				try
				{
					if( r.IsDBNull( 0 ) )
						low_score = 0;
					else
						low_score = r.GetInt32( 0 );
				}
				catch
				{
					low_score = 0;
				}
				try
				{
					if( r.IsDBNull( 1 ) )
						high_score = 0;
					else
						high_score = r.GetInt32( 1 );
				}
				catch
				{
					high_score = 0;
				}
			}
		}

		static RateRankState()
		{
			Refresh();

		}
	}

	public class RateRankStatus:IReflectorPlugin
	{

		#region IReflectorPlugin Members

		public void Preload()
		{

		}

		public void FinishInit()
		{
		}

		#endregion
	}

	public class ShowPlayers : IReflectorVariable
	{
		#region IReflectorVariable Members

		string IReflectorVariable.Name
		{
			get { return "<Ranked Players>"; }
		}

		string IReflectorVariable.Text
		{
			get { return RateRankState.player_count.ToString(); }
		}

		#endregion
	}

	public class ShowPacks : IReflectorVariable
	{
		#region IReflectorVariable Members

		string IReflectorVariable.Name
		{
			get { return "<Ranked Pack Count>"; }
		}

		string IReflectorVariable.Text
		{
			get { return RateRankState.pack_count.ToString(); }
		}

		#endregion
	}

	public class ShowMinimum : IReflectorVariable
	{
		#region IReflectorVariable Members

		string IReflectorVariable.Name
		{
			get { return "<Bottom Score>"; }
		}

		string IReflectorVariable.Text
		{
			get { return RateRankState.low_score.ToString(); }
		}

		#endregion
	}

	public class ShowMaximum : IReflectorVariable
	{
		#region IReflectorVariable Members

		string IReflectorVariable.Name
		{
			get { return "<Top score>"; }
		}

		string IReflectorVariable.Text
		{
			get { return RateRankState.high_score.ToString(); }
		}

		#endregion
	}

	public class ShowSession : IReflectorVariable
	{
		#region IReflectorVariable Members

		string IReflectorVariable.Name
		{
			get { return "<Last Ranked Session>"; }
		}

		string IReflectorVariable.Text
		{
			get { return RateRankState.last_session.ToString(); }
		}

		#endregion
	}

	public class ShowDate : IReflectorVariable
	{
		#region IReflectorVariable Members

		string IReflectorVariable.Name
		{
			get { return "<Last Ranked Day>"; }
		}

		string IReflectorVariable.Text
		{
			get { return RateRankState.last_date.ToString( "MM/dd/yyyy" ); }
		}

		#endregion
	}

	public class RefreshRankStatus: IReflectorButton
	{
		#region IReflectorButton Members

		bool IReflectorButton.OnClick()
		{
			RateRankState.Refresh();
			return true;
		}

		#endregion
	}
}
