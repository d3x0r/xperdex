using System;
using System.Collections.Generic;
using System.Text;
//using BingoSQLTracking;
using xperdex.classes;
using System.Data;
using System.Windows.Forms;
using System.Data.Common;
using xperdex.core;
using System.IO;

namespace ECube.AccrualProcessor
{
	internal static class Local
	{
		//internal static AccrualProcessorDataSet accrual_state;
		//internal static BingoAccruals Accruals;
		internal static DsnConnection dataConnection;
		internal static DsnConnection dataConnection_alt;
		internal static DataSetConnection dataSetConnector;// Handles sorting tables to create with keys in correct order etc...
		internal static bingoDataSet.bingoDataSet BingoDataSet;
		internal static List<DataRow> useSesSlot = new List<DataRow>();
		internal static String session_select_set_string;
		internal static String accrualOutputPath;
		internal static String accrualProgressiveOutputPath;
		internal static bool use_program_relation;
		internal static PostTimer postTimer;
		internal static int postTimerInterval;
		//internal static AccrualProcessorDataSet.accrual_processor_computed_sessionsDataTable accrual_processor_computed_sessions;
		//internal static AccrualProcessorDataSet.accrual_processor_last_sessionDataTable accrual_processor_last_session;
		internal static AccrualGroup.AccrualGroupTable accrual_group_table;
		internal static AccrualGroup.AccrualGroupTable.AccrualGroupInputCategoryTable accrual_group_category_table;
		internal static AccrualGroup.AccrualGroupTable.AccrualGroupInputListPickTable accrual_group_item_table;
		internal static AccrualGroup.AccrualGroupTable.AccrualGroupInputSessionTable accrual_group_session_table;
		internal static AccrualGroup.AccrualGroupTable.AccrualGroupInputProgramTable accrual_group_program_table;
		internal static AccrualGroup.CurrentAccrualGroupInputPrograms current_accrual_group_programs;
		internal static AccrualGroup.CurrentAccrualGroupInputSessions current_accrual_group_sessions;
		internal static AccrualGroup.CurrentAccrualGroupInputCategories current_accrual_group_categories;
		internal static bingoDataSet.bingoDataSet.listpickDataTable item_list;
		internal static AccrualGroup.CurrentItemList current_item_list;
		internal static AccrualGroup.Accrument.AccrumentTable accrument_table;
		internal static AccrualGroup.Accrument.AccrualPayoutTable accrual_payout_table;

		//internal static JackpotLedger the_fed;
		//internal static JackpotLedger upickem_ledger;
		//internal static JackpotLedger kitty;
		//internal static JackpotLedger house;
		//internal static JackpotLedger players;

		//internal static JackpotLedger.JackpotLedgerTable jackpot_table;
		//internal static JackpotLedger.JackpotLedgerTable.JackpotLedgerTransactionTable jackpot_transaction_table;

		//internal static JackpotList known_ledgers = new JackpotList();
		internal static AccrualGroupList known_accrual_groups = new AccrualGroupList();

		internal static Control AccrualGroupStatus;
		internal static CommboBoxSelectSession accrual_details;
		internal static DataRow current_session;
		internal static DataRow current_session_slot;
		internal static DataRow current_program;
		internal static class ConfigureState
		{
			internal static List<ButtonCloseSession> close_session_buttons = new List<ButtonCloseSession>();
			static DataRow _current_accrual_group_row;
			internal static bool use_tertiary;
			internal static bool use_ses_status;
			internal static AccrualGroup _current_accrual_group;
			internal static DataRow current_accrual_group
			{
				set{
					if( _current_accrual_group_row == null 
						|| !_current_accrual_group_row.Equals( value ) )
					{
						_current_accrual_group_row = value;
						if( value != null )
						{
							_current_accrual_group = known_accrual_groups[_current_accrual_group_row[AccrualGroup.AccrualGroupTable.NameColumn].ToString()];
						}
						else
							_current_accrual_group = null;
						if( current_accrual_group_changed != null )
							current_accrual_group_changed();

					}
				}
				get{
					return _current_accrual_group_row;
				}
			}
			internal delegate void simple_event();
			internal static event simple_event current_accrual_group_changed;
			//internal static DataRow current_accrual_group;

			internal static List<xperdex.core.PSI_Button> process_buttons = new List<xperdex.core.PSI_Button>();
			internal static List<xperdex.core.PSI_Button> post_buttons = new List<xperdex.core.PSI_Button>();
			internal static List<xperdex.core.PSI_Button> close_buttons = new List<xperdex.core.PSI_Button>();
			internal static List<ComboBox> select_session_combobox = new List<ComboBox>();
			internal static List<ListBox> Lists = new List<ListBox>();
		}
		//internal static ConfigureState config_state;

		static void FillTestData()
		{
			//DsnSQLUtil.FillDataTable( dataConnection, accrual_processor_last_session );
			//if( accrual_processor_last_session.Rows.Count > 0 )
			//{
			//	DsnSQLUtil.FillDataTable( dataConnection, BingoDataSet.session, "ses_id > " + accrual_processor_last_session[0][0] );
			//}
			//else
			//	DsnSQLUtil.FillDataTable( dataConnection, BingoDataSet.session, "ses_id < 10" );
			//DsnSQLUtil.FillDataTable( dataConnection, BingoDataSet.sesslot );


			List<object> session_keys = new List<object>();
			foreach( DataRow row in BingoDataSet.session.Rows )
				session_keys.Add( row["ses_id"] );

			//accrual_processor_computed_sessions.SyncSessions( BingoDataSet.session );

			DsnSQLUtil.FillDataTable( dataConnection, BingoDataSet.order
				, DsnSQLUtil.MakeSetSelector( "ses_id", session_keys ) );
			List<object> order_keys = new List<object>();
			FillKeys( order_keys, BingoDataSet.order, "ord_id" );

			DsnSQLUtil.FillDataTable( dataConnection, BingoDataSet.orderitm
				, DsnSQLUtil.MakeSetSelector( "ord_id", order_keys ) );

			List<object> itempck_keys = new List<object>();
			FillKeys( itempck_keys, BingoDataSet.orderitm, "lst_id" );

			DsnSQLUtil.FillDataTable( dataConnection, BingoDataSet.itmpick
				, DsnSQLUtil.MakeSetSelector( "lst_id", itempck_keys ) );

			//DsnSQLUtil.CreateDataTable( dataConnection, Accruals );	
		}

		public static String TrimString( String name )
		{
			int n = name.Length - 1;
			while( n > 0 && name[n] == ' ' )
				n--;
			return name.Substring( 0, n + 1 );
		}

		static Local()
		{
			//Server=71.50.64.45;Database=Hall;user id=boss;password=789456
			//String connection_string = Options.Default["Accrual Processor"]["Connection String", "Server=localhost;Database=Mesquite;user id=Boss;Password=789456"];
			accrualOutputPath = INI.Default["Accrual Processor"]["Accrual output filename", "accruals.txt"];
			accrualProgressiveOutputPath = INI.Default["Accrual Processor"]["Accrual progressive output filename", "progressive.txt"];
			use_program_relation = INI.Default["Accrual Processor"]["Use Program for session lists", 0].Bool;
			postTimerInterval = INI.Default["Accrual Processor"]["Post Timer Interval", 5000].Integer;
			if( INI.Default["Accrual Processor"]["Enable progressive auto update timer", 1].Bool )
				postTimer = new PostTimer();
			String connection_string = INI.Default["Accrual Processor"]["Connection String", "Server=localhost;Database=Mesquite;Integrated Security=True;"];
			try
			{
				dataConnection = new DsnConnection( connection_string );
				dataConnection.disable_logging = !INI.Default["Accrual Processor"]["Log SQL", 0].Bool;
				dataConnection_alt = new DsnConnection( connection_string );
				dataConnection_alt.disable_logging = !INI.Default["Accrual Processor"]["Log SQL", 0].Bool;
			}
			catch( Exception e )
			{
				Log.log( e.Message );
			}
			ConfigureState.use_tertiary = INI.Default["Accrual Processor"]["Use Tertiary", 0].Bool;
			ConfigureState.use_ses_status = INI.Default["Accrual Processor"]["Use Session Status", 0].Bool;
			//house_percent = Options.Default["Accrual Processor"]["House Percent", 30].Integer;
			BingoDataSet = new bingoDataSet.bingoDataSet();

			BingoDataSet.Prefix = "ap_";

			XDataTable.DefaultAutoKeyType = typeof( Guid );
			
			accrual_group_table = new AccrualGroup.AccrualGroupTable( BingoDataSet );

			new AccrualGroup.AccrualPercentageTable( BingoDataSet );

			accrual_group_category_table = new AccrualGroup.AccrualGroupTable.AccrualGroupInputCategoryTable( BingoDataSet );
			accrual_group_session_table  = new AccrualGroup.AccrualGroupTable.AccrualGroupInputSessionTable( BingoDataSet );
			accrual_group_program_table = new AccrualGroup.AccrualGroupTable.AccrualGroupInputProgramTable( BingoDataSet );
			current_accrual_group_sessions = new AccrualGroup.CurrentAccrualGroupInputSessions( BingoDataSet );
			current_accrual_group_programs = new AccrualGroup.CurrentAccrualGroupInputPrograms( BingoDataSet );
			current_accrual_group_categories = new AccrualGroup.CurrentAccrualGroupInputCategories( BingoDataSet );

			item_list = new bingoDataSet.bingoDataSet.listpickDataTable();
	
			foreach( DataColumn c in item_list.Columns )
			{
				c.AutoIncrement = false;
				c.AllowDBNull = true;
			}
			((DataTable)item_list).PrimaryKey = null;
			item_list.Columns["lst_id"].Unique = false;
			item_list.Columns["lst_id"].AutoIncrement = true;
			item_list.Columns["lst_desc"].DataType = typeof( String );
			((DataTable)item_list).TableName += "1";
			BingoDataSet.Tables.Add( item_list );
			accrual_group_item_table = new AccrualGroup.AccrualGroupTable.AccrualGroupInputListPickTable( BingoDataSet, ( (DataTable)item_list ).TableName );
			current_item_list = new AccrualGroup.CurrentItemList( BingoDataSet, ((DataTable)item_list).TableName );

			accrument_table = new AccrualGroup.Accrument.AccrumentTable( BingoDataSet );
			accrual_payout_table = new AccrualGroup.Accrument.AccrualPayoutTable( BingoDataSet );
			//new AccrualGroup.AccrualGroupTable.
			//Log.log( "..." );

			//jackpot_table = new JackpotLedger.JackpotLedgerTable( BingoDataSet );
			//jackpot_transaction_table = new JackpotLedger.JackpotLedgerTable.JackpotLedgerTransactionTable( BingoDataSet );

			dataSetConnector = new DataSetConnection( BingoDataSet );

			bool reinit = false;
			if( reinit )
			{
				dataSetConnector.Drop( dataConnection );
			}

			//Log.log( "..." );
			dataSetConnector.Create( dataConnection );

			DsnSQLUtil.FillDataTable( dataConnection, item_list, "select distinct lst_desc from listpick order by lst_desc", false );
			DsnSQLUtil.FillDataTable( dataConnection, BingoDataSet.sesslot
				/*
					, "select "
					+ BingoDataSet.sesslot.TableColumns
					+ " from " + bingoDataSet.bingoDataSet.sesslotDataTable.TableName
					+ " join " + bingoDataSet.bingoDataSet.programDataTable.TableName
					+ " on " + bingoDataSet.bingoDataSet.sesslotDataTable.TableName + "." + bingoDataSet.bingoDataSet.sesslotDataTable.PrimaryKey
					+ "=" + bingoDataSet.bingoDataSet.programDataTable.TableName + "." + bingoDataSet.bingoDataSet.sesslotDataTable.PrimaryKey
					+ " group by " + BingoDataSet.sesslot.TableColumns
					, false
				 */
					, null, "slt_code" 
				);
			DsnSQLUtil.FillDataTable( dataConnection, BingoDataSet.program, null, "prg_desc" );

			if( use_program_relation )
			{
				foreach( DataRow slot in BingoDataSet.program.Rows )
				{
					if( INI.Default["Accrual Processor"]["program/" + TrimString( slot["prg_desc"].ToString() ), 1].Bool )
					{
						useSesSlot.Add( slot );
					}
				}
			}
			else
			{
				foreach( DataRow slot in BingoDataSet.sesslot.Rows )
				{
					if( INI.Default["Accrual Processor"]["session/" + TrimString( slot["slt_desc"].ToString() ), 1].Bool )
					{
						useSesSlot.Add( slot );
					}
				}
			}
			session_select_set_string = "";
			bool first = true;
			if( use_program_relation )
			{
				foreach( DataRow row in useSesSlot )
				{
					if( !first )
						session_select_set_string += ",";
					first = false;
					session_select_set_string += row["prg_id"];
				}
			}
			else
			{
				foreach( DataRow row in useSesSlot )
				{
					if( !first )
						session_select_set_string += ",";
					first = false;
					session_select_set_string += row["slt_id"];
				}
			}


			DsnSQLUtil.FillDataTable( dataConnection, BingoDataSet.itemtype );
			DsnSQLUtil.FillDataTable( dataConnection, BingoDataSet.category );

			//DsnSQLUtil.FillDataTable( dataConnection, jackpot_table );

			//Log.log( "..." );
			try
			{
				valkey = dataConnection.ExecuteScalar( "select ctg_id from category where ctg_desc='Sun Ball Validation'" );
			}
			catch( Exception e )
			{
				MessageBox.Show( e.Message );
			}
			//Log.log( "..." );
		}

		internal static object valkey;

		internal static void DoUpdateButton()
		{
			Local.PollCurrentSession();
			if( Local.current_session != null )
				Local.ProcessSession( Local.current_session );

			bool need_post = false;
			foreach( AccrualGroup group in Local.known_accrual_groups )
			{
				if( !group.prior_accrument.posted )
				{
					need_post = true;
					break;
				}
			}
			if( need_post )
			{
				foreach( PSI_Button button in Local.ConfigureState.process_buttons )
					button.Highlight = false;
				foreach( PSI_Button button in Local.ConfigureState.post_buttons )
					button.Highlight = true;
			}
			foreach( ComboBox cb in Local.ConfigureState.select_session_combobox )
				cb.SelectedItem = null;
			Local.ConfigureState.current_accrual_group = null;
			Local.Refresh();
		}

		internal static bool UpdateSessionStatus()
		{
			if( current_session == null )
			{
				/* reload? */
				foreach( AccrualGroup group in known_accrual_groups )
					if( !group.prior_accrument.closed &&
						!group.IsDailyAccrual )
					{
						DataRow[] session = Local.BingoDataSet.session.Select( "ses_id=" + group.prior_accrument.ses_id );
						if( session.Length > 0 )
						{
							current_session = session[0];
							DataRow[] slot = Local.BingoDataSet.sesslot.Select( "slt_id=" + session[0]["slt_id"] );
							current_session_slot = slot[0];
							slot = Local.BingoDataSet.program.Select( "prg_id=" + session[0]["prg_id"] );
							current_program = slot[0];
							xperdex.core.variables.Variables.UpdateVariable( "Current_Session" );
							xperdex.core.variables.Variables.UpdateVariable( "Current_Date" );
						}
						//MessageBox.Show( "Please post current accruals" );
						return true;
					}
			}
			return false;
		}

		internal static void PostAccrual( AccrualGroup group )
		{
			if( group.prior_accrument != null
				&& !group.prior_accrument.posted
				)
			if( group.IsDailyAccrual )
			{
				LinkedList<AccrualGroup.Accrument> close_these = new LinkedList<AccrualGroup.Accrument>();
				AccrualGroup.Accrument accru = group.prior_accrument;
				while( accru != null && !accru.posted )
				{
					close_these.AddFirst( accru );
					accru = accru.prior_accrument;
				}
				foreach( AccrualGroup.Accrument accrutmp in close_these )
				{
					accru = accrutmp;
					accru.posted = true;
					group.prior_accrument.DoMath();
					//accru = accru.prior_accrument;
				}
				{
					Decimal rounder = accru.primary_end % 1;
					accru.primary_end -= rounder;
					group.PostedValue = accru.primary_end;
				}
			}
			else
			{
				group.prior_accrument.posted = true;
				group.prior_accrument.DoMath();
				group.PostedValue = group.prior_accrument.primary_end;
			}
		}

		internal static void PollCurrentSession()
		{
			//Log.log( "Poll Session 1" );
			if( current_session == null )
			{
				//Log.log( "Poll Session 2" );
				/* reload? */
				if( !UpdateSessionStatus() )
					LoadOneUnprocessedSession();
			}
			else
			{
				// reload the current.
				//Log.log( "Poll Session 3" );
				DbDataReader reader
					= Local.dataConnection.KindExecuteReader( "select * from [dbo].[session] where ses_id=" + current_session["ses_id"].ToString() );
				if( reader.HasRows )
				{
					if( reader.Read() )
					{
						current_session["ses_closedate"] = reader["ses_closedate"];
						current_session["ses_status"] = reader["ses_status"];
						//FillAccurmentRow( reader, accrument );
					}
				}
				Local.dataConnection.EndReader( reader );
			}
		}

		internal static void ProcessAccrualGroupAccrument( AccrualGroup group, AccrualGroup.Accrument accru )
		{
			if( group.CountsSession( accru.slt_id ) )
			{
				object _valtotal;
				Decimal valtotal;


				{
					DbDataReader reader = Local.dataConnection.KindExecuteReader( "select * from [dbo].[ap_accrual_payouts] where "
						+ AccrualGroup.AccrualGroupTable.PrimaryKey + "='" + group.ID + "'"
						+ " and ses_id=" + accru.ses_id.ToString()
						);
					if( reader.HasRows )
					{
						bool do_payout = false;
						decimal payout = 0;
						int pay_count = 0;
						int pay_percent = 100;
						reader.Read();
						DataRow[] rows = accrual_payout_table.Select( AccrualGroup.AccrualGroupTable.PrimaryKey + "='" + group.this_row[AccrualGroup.AccrualGroupTable.PrimaryKey] + "'"
											+ " and ses_id=" + accru.ses_id.ToString() );
						if( rows.Length == 0 )
						{
							DataRow newRow = accrual_payout_table.NewRow();
							do_payout = false;
							//newRow[AccrualGroup.Accrument.AccrualPayoutTable.PrimaryKey] = 
							newRow[AccrualGroup.AccrualGroupTable.PrimaryKey] = group.ID;
							newRow["ses_id"] = accru.ses_id;
							int ord = reader.GetOrdinal( "pay_percent" );
							object o = reader.GetValue( ord );
							if( o == null || o == DBNull.Value )
								newRow["pay_percent"] = accru.pay_percent = pay_percent = 100;
							else
							{
								newRow["pay_percent"] = accru.pay_percent = pay_percent = reader.GetInt32( ord );
							}

							ord = reader.GetOrdinal( "pay_count" );
							newRow["pay_count"] = accru.pay_count = pay_count = reader.GetInt32( ord );

							ord = reader.GetOrdinal( "payout" );
							newRow["payout"] = accru.pay = payout = reader.GetDecimal( ord );

							// if this is a new record available for this payout then do the calculation
							do_payout = true;
							accrual_payout_table.Rows.Add( newRow );
						}
						else
						{
							int ord = reader.GetOrdinal( "pay_percent" );
							object o = reader.GetValue( ord );
							if( o == null || o == DBNull.Value )
								rows[0]["pay_percent"] = accru.pay_percent = pay_percent = 100;
							else
								rows[0]["pay_percent"] = accru.pay_percent = reader.GetInt32( ord );

							ord = reader.GetOrdinal( "pay_count" );
							rows[0]["pay_count"] = accru.pay_count = reader.GetInt32( ord );

							ord = reader.GetOrdinal( "payout" );
							rows[0]["payout"] = accru.pay = reader.GetDecimal( ord );
						}
						if( do_payout )
						{
							dataConnection.EndReader( reader );
							group.Payout( group._prior_accrument, pay_count, pay_percent, payout, false );
							return;
						}
					}
					dataConnection.EndReader( reader );
				}
				if( group.fixedIncrement && !( group.fixedIncrement_RemainderToPrimary || group.fixedIncrement_RemainderToSecondary ) )
				{
					valtotal = 0;
				}
				else if( group.CountsValidations )
				{
					if( valkey == null || valkey.ToString().Length == 0 )
					{

					}
					_valtotal = dataConnection.ExecuteScalar(
						"SELECT     sum(Sold_qty * Sold_Price) "
						+ " FROM         v_APSales "
						+ " WHERE      (ctg_id=" + valkey + ") "
						+ " and (ses_id=" + accru.ses_id.ToString() + ") " );
					Log.log( "result is [" + _valtotal.ToString() + "]" );
					if( _valtotal == DBNull.Value )
						valtotal = 0;
					else
						valtotal = (decimal)_valtotal;
				}
				else
				{
					String set = group.CategorySet;
					String item_clause = group.ItemSet;
					if( ( set == null || set.Length == 0 )
						&& ( item_clause == null || item_clause.Length == 0 ) )
					{
						Log.log( "No items to select" );
						accru.Input = 0;
						accru.posted = true;
						return;
					}
					if( accru == null )
					{
						Log.log( "NO Accrual record set?" );
						return;
					}
					try
					{
						//Log.log( "about to select.. " + accru.ToString() + " " + set != null ? set : "" + " item_clause" );
						//Log.log( "for group " + group );
						_valtotal = dataConnection.ExecuteScalar(
							"SELECT     sum(Sold_qty * " + ( group.PriceOverride ? "cast(" + group.PriceOverrideValue.ToString() + " as decimal)" : "Sold_Price " ) + " ) "
							+ " FROM         v_APSales "
							+ " WHERE     ( "
							+ ( set == null ? "" : ( "(ctg_id in (" + set + ")) " ) )
							+ ( ( ( set != null ) && ( item_clause != null ) ) ? " or " : "" )
							+ ( item_clause != null ? "lst_desc in (" + item_clause + ")" : "" )
							+ " ) and (ses_id=" + accru.ses_id.ToString() + ") " );
					}
					catch( Exception e )
					{
						Log.log( e.ToString() );
						_valtotal = "0.0";
					}
					Log.log( "result is [" + _valtotal.ToString() + "]" );
					if( _valtotal == DBNull.Value )
						valtotal = 0M;
					else
					{
						try
						{
							valtotal = (decimal)_valtotal;
						}
						catch( InvalidCastException e )
						{
							valtotal = (int)_valtotal;
						}
					}
				}

				/*
				string select =
								"select top 1 ses_id,sessaccrument_id,ball_,ball_ from session "
									+ " join ap_accrument on ap_accrument.ses_id=session.ses_id"
									+ " where ap_accrument." + AccrualGroup.AccrualGroupTable.PrimaryKey
										+ "='" + group.this_row[AccrualGroup.AccrualGroupTable.PrimaryKey] + "'"
										+ " and ball_count_set<>0"  
									+ " order by close_date desc"
									;
				 */
				//AccrualGroup.Accrument accru = group.GetAccrument( sessrow );
				accru.Input = valtotal;
				//AccrualGroup.Accrument accru = new AccrualGroup.Accrument( group, sessrow, valtotal );

				//Local.house.Transfer( accru.house, group.input_ledger );
				//group.primary_ledger.Transfer( accru.primary, group.input_ledger );
				//group.secondary_ledger.Transfer( accru.secondary, group.input_ledger );
				//group.tertiary_ledger.Transfer( accru.tertiary, group.input_ledger );
			}
			else
			{
				Log.log( "group is not for this session..." + group.Name );
				if( accru != null )
				{
					accru.Input = 0;
					accru.posted = true;
					group.PostedValue = accru.primary_end;
				}
			}
		}

		internal static void ReloadUnposted()
		{
			foreach( AccrualGroup group in known_accrual_groups )
			{
				//Log.log( "Load group : " + group.Name + " prior " + group.prior_accrument );
				if( group.prior_accrument != null )
				{
					if( group.IsDailyAccrual )
					{
						DateTime start;
						//Log.log( "daily accrual..." );
						if( DateTime.TryParse( group.prior_accrument.session_date, out start ) )
						{
							DateTime testtime;
							LinkedListNode<AccrualGroup.Accrument> test = group.accruments.Last;
							do
							{
								//Log.log( "pull sales for " + test.Value.session_date );
								ProcessAccrualGroupAccrument( group, test.Value );
								if( !DateTime.TryParse( test.Value.session_date, out testtime ) )
									break;
							}
							while( testtime == start );
						}
						// all unposted sessions
					}
					else
					{
						//Log.log( "going to pull sales..." );
						ProcessAccrualGroupAccrument( group, group.prior_accrument );
					}
				}
			}
		}

		internal static void ProcessSession( DataRow sessrow )
		{
			object slt_id = sessrow["slt_id"];
			current_session = sessrow;
			DataRow[] slot = Local.BingoDataSet.sesslot.Select( "slt_id=" + sessrow["slt_id"] );
			if( slot.Length > 0 )
				current_session_slot = slot[0];
			slot = Local.BingoDataSet.program.Select( "prg_id=" + sessrow["prg_id"] );
			if( slot.Length > 0 )
				current_program = slot[0];

			foreach( AccrualGroup group in known_accrual_groups )
			{
				//Log.log( "Process group (get accrument)" + group.Name );
				AccrualGroup.Accrument accru = group.GetAccrument( sessrow, true );
				group.prior_accrument = accru;
				if( !group.IsWeeklyAccrual )
				{
					//Log.log( "Process session " + group.Name );
					try
					{
						ProcessAccrualGroupAccrument( group, accru );
					}
					catch( Exception e )
					{
						Log.log( "PRocess had an exception..." + e.ToString() );
					}
				}
			}
			Refresh();
		}

		internal static void DoNotProcessSession( DataRow sessrow )
		{
			foreach( AccrualGroup group in known_accrual_groups )
			{
				AccrualGroup.Accrument accru = group.GetAccrument( sessrow, false );
				accru.ball_end = accru.ball_start;
				accru.closed = true;
				accru.posted = true;
				group.prior_accrument = accru;
			}
		}

		static internal void Init()
		{
			ReloadAccrualGroups( false );
			DoUpdateButton();
		}

		static void FillKeys( List<object> keys, DataTable table, String keyname )
		{
			foreach( DataRow row in table.Rows )
			{
				object o = row[keyname];
				if( keys.IndexOf( o ) == -1 )
					keys.Add( o );
			}
		}


		static void ProcessUpickem( object sesskey )
		{
		}


		internal static void LoadSomeUnprocessedSessions( )
		{
			BingoDataSet.session.Clear();
			string name = MySQLDataTable.GetCompleteTableName( accrument_table );
			DsnSQLUtil.FillDataTable( dataConnection, BingoDataSet.session
				, "select top 100 * from session left join "
				+ name
				+ " on session.ses_id = " + name + ".ses_id"
				+ " where " + AccrualGroup.Accrument.AccrumentTable.PrimaryKey + " is NULL"
				+ " order by ses_id"
				, true );
			foreach( DataRow row in BingoDataSet.session.Rows )
			{
				ProcessSession( row );
			}
		}

		internal static void LoadOneUnprocessedSession()
		{
			string group_set ="";
			bool first= true;
			foreach( AccrualGroup group in known_accrual_groups )
			{
				if( !first )
					group_set += ",";
				first = false;
				group_set += "'" + group.ID + "'";
			}
		retry: // can use the same dialog since accrument rows will exist that will filter in dialog also.
			BingoDataSet.session.Clear();
			string name = MySQLDataTable.GetCompleteTableName( accrument_table );
			DsnSQLUtil.FillDataTable( dataConnection, BingoDataSet.session
				, "select * from session left join "
				+ name
				+ " on session.ses_id = " + name + ".ses_id and " + name + ".accrual_group_id in (" + group_set + ")"
				+ " where " + AccrualGroup.Accrument.AccrumentTable.PrimaryKey + " is NULL"
				+ " and " + (use_program_relation?"session.prg_id":"session.slt_id") 
				+ " in ( " + session_select_set_string + ")"
				+ " and session.ses_date > '2010-01-01' "
				+ " order by session.ses_id "
				, true );
			if( BingoDataSet.session.Rows.Count > 1 )
			{
				SessionSelectionForm select = new SessionSelectionForm( BingoDataSet.session
					, accrument_table
					, BingoDataSet.sesslot
					, BingoDataSet.program );
				select.ShowDialog();
				// cancel result is given when X button is checked so abort will work OK.

				if( select.DialogResult == DialogResult.Abort )
				{
					DoNotProcessSession( select.SessionRow );
					CommitChanges( true );
					goto retry;
				}
				else if( select.DialogResult == DialogResult.OK )
				{
					ProcessSession( select.SessionRow );
				}
				select.Dispose();
			}
			else foreach( DataRow row in BingoDataSet.session.Rows )
			{
				ProcessSession( row );
			}
		}

		static internal void ReloadAccrualGroups( bool all_groups )
		{
			if( accrual_group_table.Rows.Count != 0 )
			{
				accrual_group_category_table.Rows.Clear();
				accrual_group_session_table.Rows.Clear();
				accrual_group_program_table.Rows.Clear();
				accrual_group_item_table.Rows.Clear();
				accrual_group_table.Rows.Clear();
				//Local.known_accrual_groups.Clear();

			}
			foreach( ComboBox c in Local.ConfigureState.select_session_combobox )
			{
				c.DataSource = null;
			}
			foreach( ListBox c in Local.ConfigureState.Lists )
			{
				c.DataSource = null;
			}

			if( use_program_relation )
			{
				String ses_clause = all_groups 
					? "" 
					: " where (prg_id in (" + session_select_set_string + "))"
						+ " or (any_session=1)";
				DsnSQLUtil.FillDataTable( dataConnection, accrual_group_table
					, "select "
					+ accrual_group_table.TableColumns
					+ " from " + accrual_group_table.FullTableName
					+ " left join " + accrual_group_program_table.FullTableName
					+ " on " + accrual_group_table.FullTableName + "." + AccrualGroup.AccrualGroupTable.PrimaryKey
					+ "=" + accrual_group_program_table.FullTableName + "." + AccrualGroup.AccrualGroupTable.PrimaryKey
					+ ses_clause
					+ " group by " + accrual_group_table.TableColumns
					+ " order by " + AccrualGroup.AccrualGroupTable.Number + "," + AccrualGroup.AccrualGroupTable.NameColumn
					, false );
			}
			else
			{
				String ses_clause = all_groups 
					? "" 
					: " where (slt_id in (" + session_select_set_string + "))"
						+ " or (any_session=1)";
				DsnSQLUtil.FillDataTable( dataConnection, accrual_group_table
					, "select "
					+ accrual_group_table.TableColumns
					+ " from " + accrual_group_table.FullTableName
					+ " left join " + accrual_group_session_table.FullTableName
					+ " on " + accrual_group_table.FullTableName + "." + AccrualGroup.AccrualGroupTable.PrimaryKey
					+ "=" + accrual_group_session_table.FullTableName + "." + AccrualGroup.AccrualGroupTable.PrimaryKey
					+ ses_clause
					+ " group by " + accrual_group_table.TableColumns
					+ " order by " + AccrualGroup.AccrualGroupTable.Number + "," + AccrualGroup.AccrualGroupTable.NameColumn
					, false );
			}
			//, null
				//, AccrualGroup.AccrualGroupTable.NameColumn );
			String accrual_id = "";
			bool first = true;
			foreach( DataRow group in accrual_group_table.Rows )
			{
				if( !first )
					accrual_id += ',';
				first = false;
				accrual_id += "'" + group[AccrualGroup.AccrualGroupTable.PrimaryKey] + "'";
			}
			
			//dataConnection.ExecuteScalar( @"DROP VIEW [dbo].[v_APSales]" );
		/*	
			dataConnection.ExecuteScalar( @"CREATE VIEW [dbo].[v_APSales]
AS
select 
	 ses_date, 
	prg_desc			as program, 
	ctg_desc			as product_type,
	itmpick.itm_qty		as Key_qty,
	itmpick.itm_uprice	as Key_Price,
	itmpick.itm_type	as Prod_Type,
	itmpick.itm_uprice	as prod_Price,
	oi.itm_qty			as Sold_Qty,
	oi.ret_qty			as Sold_Returns,
	oi.itm_uprice		as Sold_Price,
	'Non-Electronic'	as Sales_Location,
	Category.ctg_id,
	listpick.lst_desc,
	session.ses_id
from Session
join program on session.prg_id = program.prg_id
join listpick on session.ses_id = listpick.ses_id
join itmpick on listpick.lst_id = itmpick.lst_id
join category on itmpick.ctg_id = category.ctg_id
join orderitm oi on listpick.lst_id = oi.lst_id
where itm_type not in('5','6') --and ord_id = 2
UNION ALL
select ses_date, 
	prg_desc			as program, 
	ctg_desc			as product_type,
	itmpick.itm_qty		as Key_qty,
	itmpick.itm_uprice	as Key_Price,
	itmpick.itm_type	as Prod_Type,
	itmpick.itm_uprice	as prod_Price,
	o3.itm_qty			as Sold_Qty,
	o3.ret_qty			as Sold_Returns,
	o3.itm_uprice		as Sold_Price,
	'Electronic'		as Sales_Location,
	Category.ctg_id,
	listpick.lst_desc,
	session.ses_id
from Session
join program on session.prg_id = program.prg_id
join ordersp1 o1 on o1.ses_id = session.ses_id
join OrderSp3 o3 on o1.ord_child = o3.ord_child
join itmpick on o3.lst_id = itmpick.lst_id
join listpick on itmpick.lst_id = listpick.lst_id
join category on itmpick.ctg_id = category.ctg_id
--order by 1,2
" );*/
			
			DsnSQLUtil.FillDataTable( dataConnection, accrual_group_category_table, "accrual_group_id in (" + accrual_id + ")", null );
			DsnSQLUtil.FillDataTable( dataConnection, accrual_group_session_table, "accrual_group_id in (" + accrual_id + ")", null );
			DsnSQLUtil.FillDataTable( dataConnection, accrual_group_program_table, "accrual_group_id in (" + accrual_id + ")", null );
			DsnSQLUtil.FillDataTable( dataConnection, accrual_group_item_table, "accrual_group_id in (" + accrual_id + ")", null );
			foreach( DataRow group in accrual_group_table.Rows )
			{
				
				AccrualGroup newgroup = CreateAccrual( group[AccrualGroup.AccrualGroupTable.NameColumn].ToString() );
				newgroup.this_row = group;
			}
			foreach( ComboBox c in Local.ConfigureState.select_session_combobox )
			{
				c.DataSource = accrual_group_table;
				c.DisplayMember = AccrualGroup.AccrualGroupTable.NameColumn;
				c.Refresh();
			}
			foreach( ListBox c in Local.ConfigureState.Lists )
			{
				c.DataSource = accrual_group_table;
				c.DisplayMember = AccrualGroup.AccrualGroupTable.NameColumn;
				c.Refresh();
			}

			foreach( AccrualGroup group in known_accrual_groups )
			{
				if( group.prior_accrument != null && 
					( !group.IsDailyAccrual && !group.IsWeeklyAccrual &&
					group.prior_accrument.posted ) )
				{
					foreach( xperdex.core.PSI_Button b in Local.ConfigureState.post_buttons )
						b.Highlight = false;
					foreach( xperdex.core.PSI_Button b in Local.ConfigureState.close_buttons )
						b.Highlight = true;
					break;
				}
			}
			Refresh();
		}

		static internal void ClearAndReloadAccruals()
		{
			Local.BingoDataSet.Tables["accrument"].Clear();
			Local.BingoDataSet.Tables["accrument"].AcceptChanges();
			Local.BingoDataSet.Tables["accrual_group_input_categories"].Clear();
			Local.BingoDataSet.Tables["accrual_group_input_categories"].AcceptChanges();
			Local.BingoDataSet.Tables["accrual_group_input_sessions"].Clear();
			Local.BingoDataSet.Tables["accrual_group_input_sessions"].AcceptChanges();
			Local.BingoDataSet.Tables["accrual_group_input_list_pick"].Clear();
			Local.BingoDataSet.Tables["accrual_group_input_list_pick"].AcceptChanges();
			Local.BingoDataSet.Tables["accrual_group_input_programs"].Clear();
			Local.BingoDataSet.Tables["accrual_group_input_programs"].AcceptChanges();

			Local.BingoDataSet.Tables["accrual_group"].Clear();
			Local.BingoDataSet.Tables["accrual_group"].AcceptChanges();
			Local.BingoDataSet.Tables[AccrualGroup.AccrualPercentageTable.TableName].Clear();
			Local.BingoDataSet.Tables[AccrualGroup.AccrualPercentageTable.TableName].AcceptChanges();
			foreach( ComboBox cb in Local.ConfigureState.select_session_combobox )
			{
				cb.SelectedItem = null;
				cb.DataSource = null;
			}
			foreach( AccrualGroup group in Local.known_accrual_groups )
			{
				group.accruments.Clear();
			}
			Local.known_accrual_groups.Clear();
			foreach( xperdex.core.PSI_Button b in Local.ConfigureState.post_buttons )
				b.Highlight = false;
			foreach( xperdex.core.PSI_Button b in Local.ConfigureState.close_buttons )
				b.Highlight = false;
			Local.ReloadAccrualGroups( false );
			foreach( xperdex.core.PSI_Button b in Local.ConfigureState.process_buttons )
				b.Highlight = true;
			foreach( ComboBox cb in Local.ConfigureState.select_session_combobox )
			{
				cb.DataSource = Local.accrual_group_table;
				cb.SelectedItem = null;
			}
			Local.current_session = null;
			Local.current_program = null;
			Local.current_session_slot = null;
			//Local.DoUpdateButton();
		}

		static internal AccrualGroup CreateAccrual( String s )
		{
			try
			{
				foreach( AccrualGroup g in known_accrual_groups )
					if( String.Compare( g.Name, s ) == 0 )
						return g;
				//Log.log( "Create group " + s );
				AccrualGroup a = new AccrualGroup( s );
				//Log.log( "Created group " + s );
				//a.input_ledger = Local.CreateAccount( s + " input" );
				//a.primary_ledger = Local.CreateAccount( s + " primary" );
				//a.secondary_ledger = Local.CreateAccount( s + " secondary" );
				//a.tertiary_ledger = Local.CreateAccount( s + " tertiary" );
				//a.pay_ledger = Local.CreateAccount( s + " payout" );
				known_accrual_groups.Add( a );
				return a;
			}
			catch( Exception e )
			{
				MessageBox.Show( e.Message );
			}
			return null;
		}

		static internal String StripSpaces( String a )
		{
			int last_non_space = a.Length - 1;
			while( a[last_non_space] == ' ' )
				last_non_space--;
			return a.Substring( 0, last_non_space + 1 );
		}

		static internal void CommitSettingChanges()
		{
			List<AccrualGroup> fixed_groups = new List<AccrualGroup>();
			List<object> prior_value = new List<object>();
			foreach( AccrualGroup group in Local.known_accrual_groups )
			{
				bool curval, origval;
				try
				{
					if( group.prior_accrument!= null
						&& group.prior_accrument.this_row != null
						&& group.prior_accrument.this_row.RowState == DataRowState.Modified
						&& group.prior_accrument.this_row.HasVersion( DataRowVersion.Original ) )
						if( bool.TryParse( group.prior_accrument.this_row["posted", DataRowVersion.Current].ToString(), out curval )
							&& bool.TryParse( group.prior_accrument.this_row["posted", DataRowVersion.Original].ToString(), out origval )
							)
						{
							prior_value.Add( group.prior_accrument.this_row["posted"] );
							fixed_groups.Add( group );

							group.prior_accrument.this_row["posted"] = group.prior_accrument.this_row["posted", DataRowVersion.Original];
						}
				}
				catch( Exception e )
				{
					MessageBox.Show( "Error caught setting posted for : ", group.Name );
				}
			}
			try
			{
				Local.CommitChanges( true );
			}
			catch( Exception e )
			{
				MessageBox.Show( "Error saving changes : " + e.Message );
				DsnSQLUtil.DumpTableErrors( BingoDataSet );
			}
			try
			{
				int n = 0;
				foreach( AccrualGroup group in fixed_groups )
				{
					group.prior_accrument.this_row["posted"] = prior_value[n++];
				}
			}
			catch( Exception e )
			{
				MessageBox.Show( "error setting last posted value to prior state : " + e.Message );
			}
		}

		static internal void CommitChanges( bool userEvent )
		{
			
			if( BingoDataSet.HasChanges() )
			{
				if( userEvent )
					xperdex.gui.Banner.Show( "Saving Changes...", true );

				dataSetConnector.Commit( dataConnection );

				xperdex.gui.Banner.End();
			}
		}

		internal static void Refresh()
		{
			xperdex.core.variables.Variables.UpdateVariable( "Current_Session" );
			xperdex.core.variables.Variables.UpdateVariable( "Current_Program" );
			xperdex.core.variables.Variables.UpdateVariable( "Current_Date" );
			xperdex.core.variables.Variables.UpdateVariable( "Current Percent" );
			xperdex.core.variables.Variables.UpdateVariable( "Jackpot New Value" );
			xperdex.core.variables.Variables.UpdateVariable( "Jackpot Name" );

			xperdex.core.variables.Variables.UpdateVariable( "Jackpot_Value" );
			xperdex.core.variables.Variables.UpdateVariable( "Jackpot_Updated_Value" );

			xperdex.core.variables.Variables.UpdateVariable( "Posted Jackpot Value" );
			xperdex.core.variables.Variables.UpdateVariable( "Posted Ball Count" );

			xperdex.core.variables.Variables.UpdateVariable( "Jackpot New Value_I" );
			xperdex.core.variables.Variables.UpdateVariable( "Jackpot Name_I" );

			xperdex.core.variables.Variables.UpdateVariable( "Jackpot_Value_I" );
			xperdex.core.variables.Variables.UpdateVariable( "Jackpot_Updated_Value_I" );

			xperdex.core.variables.Variables.UpdateVariable( "Posted Jackpot Value_I" );
			xperdex.core.variables.Variables.UpdateVariable( "Posted Ball Count_I" );
			
			if( Local.accrual_details != null )
				Local.accrual_details.ConfigureState_current_accrual_group_changed();

                	OutputProgressive();
			Local.OutputAccruals();
		}

		internal static void ProcessBallAccruals( AccrualGroup group )
		{
			bool changed = false;
			//foreach( AccrualGroup group in known_accrual_groups )
			{
				if( //group.prior_accrument.posted && 
					group.ball_count_increment_days > 0 )
				{
					String select = "select top 1 ses_date from session join ap_accrument on ap_accrument.ses_id=session.ses_id"
						+ " where accrual_group_id='" + group.this_row[AccrualGroup.AccrualGroupTable.PrimaryKey] + "' and ap_accrument.ball_count_set<>0"
						+ " order by session.ses_date desc";
					//Log.log( "select for ball accrual is:" + select );
					DbDataReader reader = dataConnection.KindExecuteReader( select );
					object result;
					DateTime curDate = Convert.ToDateTime( group.prior_accrument.session_date );
					if( reader != null && reader.HasRows )
					{
						reader.Read();
						result = reader["ses_date"];
						//Log.log( "Converting to dt : " + result + " " + ( DateTime.Today - (DateTime)result ) );
						DateTime dt = (DateTime)result;

						if( ( curDate - dt )
							>= TimeSpan.FromDays( group.ball_count_increment_days ) )
						{
							//Log.log( "days has elapsed..." );
							if( group.prior_accrument.ball_start < group.ball_count_max )
							{
								//Log.log( "ball count is less than max... set, increment..." );
								changed = true;
								group.prior_accrument.ball_delta = 1;
								group.prior_accrument.ball_end = group.prior_accrument.ball_start + group.prior_accrument.ball_delta;
								group.prior_accrument.ball_count_set = true;
							}
						}
					}
					if( changed ) 
						xperdex.core.variables.Variables.UpdateVariable( "Posted Ball Count" );
					dataConnection.EndReader( reader );
				}
			}
		}

		internal static void OutputAccruals( ) {
			try
			{
				FileStream fs = new FileStream( accrualOutputPath, FileMode.Create );
				StreamWriter sw = new StreamWriter( fs );
				foreach( AccrualGroup group in known_accrual_groups )
				{
					sw.WriteLine( group.Name );
					sw.WriteLine( group.GetPostedvalue().ToString( "C0" ) );
					sw.WriteLine( group.GetPostedBalls().ToString() );
				}
				sw.Close();
				fs.Close();
				sw.Dispose();
				fs.Dispose();
			}
			catch( Exception e )
			{
				MessageBox.Show( e.Message, "File Output Exception" );
			}
		}

		internal static void OutputProgressive()
		{
			try
			{
				FileStream fs = new FileStream( accrualProgressiveOutputPath, FileMode.Create );
				StreamWriter sw = new StreamWriter( fs );
				foreach( AccrualGroup group in known_accrual_groups )
				{
					sw.WriteLine( group.Name );
					sw.WriteLine( group.prior_accrument.primary_end.ToString( "C0" ) );
					sw.WriteLine( group.GetPostedBalls().ToString() );
				}
				sw.Close();
				fs.Close();
				sw.Dispose();
				fs.Dispose();
			}
			catch( Exception e )
			{
				MessageBox.Show( e.Message, "File Output Exception" );
			}
		}

		internal static void PostAccruals( bool userEvent )
		{
			bool okay_to_process = false;
			foreach( AccrualGroup group in Local.known_accrual_groups )
			{
				if( !group.prior_accrument.posted )
					okay_to_process = true;
			}
			if( !okay_to_process )
				if( Local.current_session == null )
				{
					MessageBox.Show( "Please process a session before posting" );
					return;
				}
			//Local.LoadSomeUnprocessedSessions();
			//if( (int)Local.current_session["ses_status"] == 4 )
			foreach( AccrualGroup group in Local.known_accrual_groups )
			{
				if( group.prior_accrument != null
					&& !group.prior_accrument.posted
					&& !group.IsDailyAccrual )
				{
					group.prior_accrument.posted = true;
					group.prior_accrument.DoMath();
					group.PostedValue = group.prior_accrument.primary_end;
				}
				if( group.prior_accrument != null
					&& group.IsDailyAccrual
					&& group.prior_accrument.pay_count > 0 )
				{
					group.prior_accrument.posted = true;
					group.prior_accrument.DoMath();
					group.PostedValue = group.prior_accrument.primary_end;
				}
			}

			Local.CommitChanges( userEvent );

			foreach( PSI_Button button in Local.ConfigureState.post_buttons )
				button.Highlight = false;
			foreach( PSI_Button button in Local.ConfigureState.close_buttons )
				button.Highlight = true;
			//else
			//	MessageBox.Show( "Please close the current session" );
			// will not be commited, and show the end value. (before creating next accrument)
			//Local.current_session = null;
			//Local.current_session_slot = null;
			Local.Refresh();
		}
	}


}
