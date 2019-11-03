using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenSkieScheduler3;
using xperdex.classes;
using System.Data;
using xperdex.core;
using OpenSkie.Scheduler;
using xperdex.gui;
using xperdex.core.variables;
using OpenSkieScheduler3.Relations;
using OpenSkieSessionState;
using System.Windows.Forms;

namespace SessionManager
{
    class SessionManagementState : 
        xperdex.core.interfaces.IReflectorPlugin
        , xperdex.core.interfaces.IReflectorPersistance
	{
		static int session;

		internal static ScheduleDataSet schedule;
		internal static ScheduleCurrents schedule_currents;
		internal static SessionStateDataset session_state;
		internal static DataView active_sessions;

		internal static DataRow current_session
		{
			set
			{
				schedule_currents.SetCurrentSession( value );
			}
			get
			{
				return schedule_currents.current_session;
			}
		}
		internal static DataRow current_price_set;
		internal static DataRow current_prize_set;

		internal static List<PSI_Button> open_issue_buttons;
		internal static List<PSI_Button> open_sales_buttons;
		internal static List<PSI_Button> open_play_buttons;
		internal static List<PSI_Button> close_issue_buttons;
		internal static List<PSI_Button> close_sales_buttons;
		internal static List<PSI_Button> close_play_buttons;

		static SessionManagementState()
		{
			open_issue_buttons = new List<PSI_Button>();
			open_play_buttons = new List<PSI_Button>();
			open_sales_buttons = new List<PSI_Button>();
			close_issue_buttons = new List<PSI_Button>();
			close_sales_buttons = new List<PSI_Button>();
			close_play_buttons = new List<PSI_Button>();

			schedule = new ScheduleDataSet( StaticDsnConnection.dsn );
			schedule_currents = new ScheduleCurrents( schedule );
			schedule.Create();
			schedule.Fill();

			session_state = new SessionStateDataset();
			DsnSQLUtil.MatchCreate( StaticDsnConnection.dsn, session_state );
            session_state.Fill( StaticDsnConnection.dsn );
			//DsnSQLUtil.FillDataSet( StaticDsnConnection.dsn, session_state,  );

			active_sessions = new DataView( session_state.session_day_sessions
				, "active_flag<>0"
				+ " or open_for_sales_flag<>0"
				+ " or open_for_issue_flag<>0"
				+ " or open_for_play_flag<>0"
				, "bingoday,session_order", DataViewRowState.CurrentRows );
            if( active_sessions.Count > 0 )
                SessionManagementState.current_session = active_sessions[0].Row;
		}

		public static void Init()
		{

		}
		public static void AddNewSession( DateTime date, DataRow current_session )
		{
			if( current_price_set == null )
			{
				Banner.Show( "Need to select a price set" );
				return;
			}
			if( current_prize_set == null )
			{
				Banner.Show( "Need to select a prize set" );
				return;
			}
			if( current_session != null )
			{
				DataRow row = session_state.session_day_sessions.NewRow();
				DataRow session_pc_row;
				DataRow pc_row;
				DataRow session_pz_row;
				DataRow pz_row;
				DataRow[] tmp_rows;

				session_pc_row = current_price_set;//.GetParentRow( "session_price_exception_set" );
				pc_row = session_pc_row.GetParentRow( "price_exception_set_in_session" );
				session_pz_row = current_prize_set;//.GetParentRow( "session_prize_exception_set" );
				pz_row = session_pz_row.GetParentRow( "prize_exception_set_in_session" );

				row[SessionTable.PrimaryKey] = current_session[SessionTable.PrimaryKey];
				row["session_number"] = current_session[SessionTable.PrimaryKey];
				row["session_name"] = current_session["session_name"];
				tmp_rows = current_session.GetChildRows( "session_has_price_exception_set" );
				row[PriceExceptionSet.PrimaryKey] = tmp_rows[0][PriceExceptionSet.PrimaryKey];
				tmp_rows = current_session.GetChildRows( "session_has_prize_exception_set" );
				row[PrizeExceptionSet.PrimaryKey] = tmp_rows[0][PrizeExceptionSet.PrimaryKey];
				DateTime tmp_time = date;
				row["bingoday"] = tmp_time - tmp_time.TimeOfDay;
				row["active_flag"] = 1;

				session_state.session_day_sessions.Rows.Add( row );

				DsnSQLUtil.CommitChanges( StaticDsnConnection.dsn, session_state );
				session_state.AcceptChanges();
				_current_open_session = row;
			}
		}

		public static void AddNewSession()
		{
			if( current_price_set == null )
			{
				Banner.Show( "Need to select a price set" );
				return;
			}
			if( current_prize_set == null )
			{
				Banner.Show( "Need to select a prize set" );
				return;
			}
			if( current_session != null )
			{
				DataRow row = session_state.session_day_sessions.NewRow();
				DataRow session_pc_row;
				DataRow pc_row;
				DataRow session_pz_row;
				DataRow pz_row;
				DataRow[] tmp_rows;

				session_pc_row = current_price_set;//.GetParentRow( "session_price_exception_set" );
				pc_row = session_pc_row.GetParentRow( "price_exception_set_in_session" );
				session_pz_row = current_prize_set;//.GetParentRow( "session_prize_exception_set" );
				pz_row = session_pz_row.GetParentRow( "prize_exception_set_in_session" );

				row[SessionTable.PrimaryKey] = current_session[SessionTable.PrimaryKey];
				row["session_number"] = current_session[SessionTable.PrimaryKey];
				row["session_name"] = current_session["session_name"];
				tmp_rows = current_session.GetChildRows( "session_has_price_exception_set" );
				row[PriceExceptionSet.PrimaryKey] = tmp_rows[0][PriceExceptionSet.PrimaryKey];
				tmp_rows = current_session.GetChildRows( "session_has_prize_exception_set" );
				row[PrizeExceptionSet.PrimaryKey] = tmp_rows[0][PrizeExceptionSet.PrimaryKey];
				DateTime tmp_time = DateTime.Now;
				row["bingoday"] = tmp_time - tmp_time.TimeOfDay;
				row["active_flag"] = 1;

				session_state.session_day_sessions.Rows.Add( row );

				DsnSQLUtil.CommitChanges( StaticDsnConnection.dsn, session_state );
				session_state.AcceptChanges();
			}
		}

		public static void OpenNewSession()
		{
			if( !opened_for_issue && !opened_for_play && !opened_for_sales )
			{
				int tmpval;
				if( !Int32.TryParse( _current_open_session[PriceExceptionSet.PrimaryKey].ToString(), out tmpval ) || tmpval == 0 )
				{
					Banner.Show( "Session not opened correctly,\nprice exception set not picked", false );
					return;
				}
				if( !Int32.TryParse( _current_open_session[PrizeExceptionSet.PrimaryKey].ToString(), out tmpval ) || tmpval == 0 )
				{
					Banner.Show( "Session not opened correctly,\nprize exception set not picked", false );
					return;
				}

				Banner.Show( "Creating schedule snapshot...\nFor" + (DateTime)_current_open_session["bingoday"] + " session " + (int)_current_open_session["session_order"] + ") " + _current_open_session["session_name"], true );
				Application.DoEvents();

				DataRow row = _current_open_session;
				DataRow session_pc_row;
				DataRow[] pc_rows = schedule.price_exception_sets.Select( PriceExceptionSet.PrimaryKey + "='" + _current_open_session[PriceExceptionSet.PrimaryKey] + "'" );
				DataRow[] pz_rows = schedule.prize_exception_sets.Select( PrizeExceptionSet.PrimaryKey + "='" + _current_open_session[PrizeExceptionSet.PrimaryKey] + "'" );
				DataRow pc_row = pc_rows[0];
				DataRow session_pz_row;
				DataRow pz_row = pz_rows[0];
				DataRow[] current_sessions = schedule.sessions.Select( SessionTable.PrimaryKey + "='" + _current_open_session[SessionTable.PrimaryKey] + "'" );
				DataRow current_session = current_sessions[0];

				DataRow snapshot_current_session;
				ScheduleDataSet schedule_instance = new ScheduleDataSet( StaticDsnConnection.dsn
					, schedule
					, (DateTime)_current_open_session["bingoday"]
					, Convert.ToInt32( row["session_order"] )
					, current_session
					, pc_row
					, pz_row
					, out snapshot_current_session
					);
				//schedule_instance.Drop();
				//schedule_instance.Create();
				row["snapshot_session_id"] = snapshot_current_session[SessionTable.PrimaryKey];
				schedule_instance.Dispose();
				DsnSQLUtil.CommitChanges( StaticDsnConnection.dsn, session_state );
				session_state.AcceptChanges();
				Banner.End();

			}
		}

		internal static bool open_for_issue;
		internal static bool open_for_sales;
		internal static bool open_for_play;
		internal static bool opened_for_issue;
		internal static bool opened_for_sales;
		internal static bool opened_for_play;

		static void UpdateButtons()
		{
			foreach( PSI_Button button in open_sales_buttons )
				button.Highlight = open_for_sales;

			foreach( PSI_Button button in open_issue_buttons )
				button.Highlight = open_for_issue;

			foreach( PSI_Button button in open_play_buttons )
				button.Highlight = open_for_play;

			Variables.UpdateVariable( "<Session Play State>" );
			Variables.UpdateVariable( "<Session Issue State>" );
			Variables.UpdateVariable( "<Session Sales State>" );
			Variables.UpdateVariable( "<Session Play Command>" );
			Variables.UpdateVariable( "<Session Issue Command>" );
			Variables.UpdateVariable( "<Session Sales Command>" );
		}

		static void UpdateStates()
		{
			if( _current_open_session != null )
			{
				if( Convert.ToInt32( _current_open_session["opened_for_issue"] ) == 0 )
					opened_for_issue = false;
				else
					opened_for_issue = true;
				if( Convert.ToInt32( _current_open_session["opened_for_sales"] ) == 0 )
					opened_for_sales = false;
				else
					opened_for_sales = true;
				if( Convert.ToInt32( _current_open_session["opened_for_play"] ) == 0 )
					opened_for_play = false;
				else
					opened_for_play = true;

				if( Convert.ToInt32( _current_open_session["open_for_sales_flag"] ) == 0 )
				{
					open_for_sales = false;
				}
				else
				{
					open_for_sales = true;
				}
				if( Convert.ToInt32( _current_open_session["open_for_issue_flag"] ) == 0 )
				{
					open_for_issue = false;
				}
				else
				{
					open_for_issue = true;
				}
				if( Convert.ToInt32( _current_open_session["open_for_play_flag"] ) == 0 )
				{
					open_for_play = false;
				}
				else
				{
					open_for_play = true;
				}

				if( !open_for_issue && !open_for_sales && !open_for_play
					&& opened_for_issue && opened_for_sales && opened_for_play )
				{
					_current_open_session["active_flag"] = 0;
				}
			}
		}

		static DataRow _current_open_session;
		public static DataRow current_open_session
		{
			get
			{
				return _current_open_session;
			}
			set
			{
				if( _current_open_session != value )
				{
					_current_open_session = value;
					UpdateStates();
					UpdateButtons();
				}
			}
		}

		internal static List<ActiveSessionList> active_session_lists;
		internal static void OpenSessionIssue()
		{
			DataRow[] prior_open = session_state.session_day_sessions.Select( "open_for_issue_flag=1" );
			if( prior_open.Length > 0 )
			{
				foreach( DataRow prior in prior_open )
					prior["open_for_issue_flag"] = 0;
			}
			OpenNewSession();
			_current_open_session["open_for_issue_flag"] = 1;
			_current_open_session["opened_for_issue"] = 1;
			DsnSQLUtil.CommitChanges( StaticDsnConnection.dsn, session_state );
			foreach( ActiveSessionList list in active_session_lists )
				list.hold_changes = true;
			session_state.AcceptChanges();
			foreach( ActiveSessionList list in active_session_lists )
				list.hold_changes = false;
			UpdateStates();
			UpdateButtons();
		}
		internal static void OpenSessionSales()
		{
			DataRow[] prior_open = session_state.session_day_sessions.Select( "open_for_sales_flag=1" );
			if( prior_open.Length > 0 )
			{
				foreach( DataRow prior in prior_open )
					prior["open_for_sales_flag"] = 0;
			}
			OpenNewSession();
			_current_open_session["open_for_sales_flag"] = 1;
			_current_open_session["opened_for_sales"] = 1;
			DsnSQLUtil.CommitChanges( StaticDsnConnection.dsn, session_state );
			foreach( ActiveSessionList list in active_session_lists )
				list.hold_changes = true;
			session_state.AcceptChanges();
			foreach( ActiveSessionList list in active_session_lists )
				list.hold_changes = false;
			UpdateStates();
			UpdateButtons();
		}
		internal static void OpenSessionPlay()
		{
			DataRow[] prior_open = session_state.session_day_sessions.Select( "open_for_play_flag=1" );
			if( prior_open.Length > 0 )
			{
				foreach( DataRow prior in prior_open )
					prior["open_for_play_flag"] = 0;
			}
			OpenNewSession();
			_current_open_session["open_for_play_flag"] = 1;
			_current_open_session["opened_for_play"] = 1;
			DsnSQLUtil.CommitChanges( StaticDsnConnection.dsn, session_state );
			foreach( ActiveSessionList list in active_session_lists )
				list.hold_changes = true;
			session_state.AcceptChanges();
			foreach( ActiveSessionList list in active_session_lists )
				list.hold_changes = false;
			UpdateStates();
			UpdateButtons();
		}
		internal static void CloseSessionIssue()
		{
			_current_open_session["open_for_issue_flag"] = 0;
			UpdateStates();
			DsnSQLUtil.CommitChanges( StaticDsnConnection.dsn, session_state );
			foreach( ActiveSessionList list in active_session_lists )
				list.hold_changes = true;
			session_state.AcceptChanges();
			foreach( ActiveSessionList list in active_session_lists )
				list.hold_changes = false;
			UpdateButtons();
		}
		internal static void CloseSessionSales()
		{
			_current_open_session["open_for_sales_flag"] = 0;
			UpdateStates();
			DsnSQLUtil.CommitChanges( StaticDsnConnection.dsn, session_state );
			foreach( ActiveSessionList list in active_session_lists )
				list.hold_changes = true;
			session_state.AcceptChanges();
			foreach( ActiveSessionList list in active_session_lists )
				list.hold_changes = false;
			UpdateButtons();
		}
		internal static void CloseSessionPlay()
		{
			_current_open_session["open_for_play_flag"] = 0;
			UpdateStates();
			DsnSQLUtil.CommitChanges( StaticDsnConnection.dsn, session_state );
			foreach( ActiveSessionList list in active_session_lists )
				list.hold_changes = true;
			session_state.AcceptChanges();
			foreach( ActiveSessionList list in active_session_lists )
				list.hold_changes = false;
			UpdateButtons();
		}

        void xperdex.core.interfaces.IReflectorPlugin.Preload()
        {
            // no action
        }

        void xperdex.core.interfaces.IReflectorPlugin.FinishInit()
        {
            UpdateButtons();
        }

        bool xperdex.core.interfaces.IReflectorPersistance.Load( System.Xml.XPath.XPathNavigator r )
        {
            // no action; just need persistance to trigger finishinit
            return false;
        }

        void xperdex.core.interfaces.IReflectorPersistance.Save( System.Xml.XmlWriter w )
        {
            // no action; just need persistance to trigger finishinit
        }

        void xperdex.core.interfaces.IReflectorPersistance.Properties()
        {
            // no action; just need persistance to trigger finishinit
        }

        public static void SetActiveSession()
        {
            DataRow update_row;
            if( session_state.operational_configuration.Rows.Count < 1 )
            {
                update_row = session_state.operational_configuration.NewRow();
                update_row["ID"] = 1;
                session_state.operational_configuration.Rows.Add( update_row );
            }
            else
                update_row = session_state.operational_configuration.Rows[0];
            update_row["current_session_day_sessions_id"] = _current_open_session["ID"];
            update_row["current_bingoday"] = _current_open_session["bingoday"];
            update_row["current_session_id"] = _current_open_session["session_order"];
            DsnSQLUtil.CommitChanges( StaticDsnConnection.dsn, session_state.operational_configuration );
        }
    }


}
