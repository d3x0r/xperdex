using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xperdex.core.interfaces;
using xperdex.core;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using xperdex.classes;

namespace ECube.AccrualProcessor
{
	class XperdexInterface : xperdex.core.interfaces.IReflectorPlugin
	{
		void xperdex.core.interfaces.IReflectorPlugin.Preload()
		{
		}

		void xperdex.core.interfaces.IReflectorPlugin.FinishInit()
		{
			//throw new NotImplementedException();
			Local.Init();
		}
	}


	class JackpotValueVariable : xperdex.core.interfaces.IReflectorVariableNamedArray
	{
		#region IReflectorVariable Members

		string xperdex.core.interfaces.IReflectorVariableNamedArray.Name
		{
			get { return "Jackpot_Value"; }
		}
		string[] xperdex.core.interfaces.IReflectorVariableNamedArray.Members
		{
			get
			{
				List<String> strings = new List<string>();
				foreach( AccrualGroup ledger in Local.known_accrual_groups )
				{
					strings.Add( ledger.ToString() );
				}
				return strings.ToArray();
			}
		}

		string xperdex.core.interfaces.IReflectorVariableNamedArray.this[String member]
		{
			get
			{
				AccrualGroup v = Local.known_accrual_groups[member];
				if( v != null )
				{
					/*
					if( v.prior_accrument != null )
					{
						if( v.prior_accrument.posted )
							return v.prior_accrument.primary_end.ToString( "C" );
						if( v.prior_accrument.this_row.RowState != DataRowState.Unchanged )
						{
							if( v.prior_accrument.primary_start != 0 )
								return v.prior_accrument.primary_start.ToString( "C" );
							else
								return ( v.prior_accrument.primary_start + v.prior_accrument.primary_seed ).ToString( "C" );
						}
					}
					s*/
					return v.prior_accrument.primary_start.ToString( "C" );
				}
				return "";
			}
		}

		#endregion
	}

	class JackpotNameVariable : xperdex.core.interfaces.IReflectorVariableNamedArray
	{
		#region IReflectorVariable Members

		string xperdex.core.interfaces.IReflectorVariableNamedArray.Name
		{
			get { return "Jackpot Name"; }
		}
		string[] xperdex.core.interfaces.IReflectorVariableNamedArray.Members
		{
			get
			{
				List<String> strings = new List<string>();
				foreach( AccrualGroup ledger in Local.known_accrual_groups )
				{
					strings.Add( ledger.ToString() );
				}
				return strings.ToArray();
			}
		}

		string xperdex.core.interfaces.IReflectorVariableNamedArray.this[String member]
		{
			get
			{
				AccrualGroup v = Local.known_accrual_groups[member];
				if( v != null )
				{
					return v.Name;
				}
				return "";
			}
		}

		#endregion
	}

	class JackpotPostedValueVariable : xperdex.core.interfaces.IReflectorVariableNamedArray
	{
		#region IReflectorVariable Members

		string xperdex.core.interfaces.IReflectorVariableNamedArray.Name
		{
			get { return "Posted Jackpot Value"; }
		}
		string[] xperdex.core.interfaces.IReflectorVariableNamedArray.Members
		{
			get
			{
				List<String> strings = new List<string>();
				foreach( AccrualGroup ledger in Local.known_accrual_groups )
				{
					strings.Add( ledger.ToString() );
				}
				return strings.ToArray();
			}
		}

		string xperdex.core.interfaces.IReflectorVariableNamedArray.this[String member]
		{
			get
			{
				AccrualGroup v = Local.known_accrual_groups[member];
				if( v != null )
				{
					Decimal a = v.PostedValue;
					Decimal b = v.GetPostedvalue();
					if( a != b )
					{
						xperdex.classes.Log.log( "discrepency on " + v.Name + " is " + a.ToString( "C" ) + " and " + b.ToString( "C" ) );
						return "* " + b.ToString( "C" );
					}
					return a.ToString( "C" );
				}
				return "";
			}
		}

		#endregion
	}

	class BallsPostedValueVariable : xperdex.core.interfaces.IReflectorVariableNamedArray
	{
		#region IReflectorVariable Members

		string xperdex.core.interfaces.IReflectorVariableNamedArray.Name
		{
			get { return "Posted Ball Count"; }
		}
		string[] xperdex.core.interfaces.IReflectorVariableNamedArray.Members
		{
			get
			{
				List<String> strings = new List<string>();
				foreach( AccrualGroup ledger in Local.known_accrual_groups )
				{
					strings.Add( ledger.ToString() );
				}
				return strings.ToArray();
			}
		}

		string xperdex.core.interfaces.IReflectorVariableNamedArray.this[String member]
		{
			get
			{
				AccrualGroup v = Local.known_accrual_groups[member];
				if( v != null )
				{
					//Decimal a = v.PostedValue; 
					if( v.prior_accrument.ball_count_set )
						return v.prior_accrument.ball_end.ToString();  // intelligent search through accrument records
					else
						return v.prior_accrument.ball_start.ToString( );  // intelligent search through accrument records
				}
				return "";
			}
		}

		#endregion
	}

	
	class JackpotUpdatedValueVariable : xperdex.core.interfaces.IReflectorVariableNamedArray
	{
		#region IReflectorVariable Members

		string xperdex.core.interfaces.IReflectorVariableNamedArray.Name
		{
			get { return "Jackpot_Updated_Value"; }
		}
		string[] xperdex.core.interfaces.IReflectorVariableNamedArray.Members
		{
			get
			{
				List<String> strings = new List<string>();
				foreach( AccrualGroup ledger in Local.known_accrual_groups )
				{
					strings.Add( ledger.ToString() );
				}
				return strings.ToArray();
			}
		}

		string xperdex.core.interfaces.IReflectorVariableNamedArray.this[String member]
		{
			get
			{
				AccrualGroup v = Local.known_accrual_groups[member];
				if( v != null )
				{
					
					if( v.prior_accrument != null )
					{
						if( v.prior_accrument.posted )
							return v.prior_accrument.primary_end.ToString( "C" );
						if( v.prior_accrument.this_row.RowState != DataRowState.Unchanged )
						{
							if( v.prior_accrument.primary_start != 0 )
								return v.prior_accrument.primary_start.ToString( "C" );
							else
								return ( v.prior_accrument.primary_start 
									+ v.prior_accrument.primary_seed ).ToString( "C" );
						}
					}
					
					return v.prior_accrument.primary_end.ToString( "C" );
				}
				return "";
			}
		}

		#endregion
	}

	class JackpotBallCountVariable : xperdex.core.interfaces.IReflectorVariableNamedArray
	{
		#region IReflectorVariable Members

		string xperdex.core.interfaces.IReflectorVariableNamedArray.Name
		{
			get { return "Ball Count"; }
		}
		string[] xperdex.core.interfaces.IReflectorVariableNamedArray.Members
		{
			get
			{
				List<String> strings = new List<string>();
				foreach( AccrualGroup ledger in Local.known_accrual_groups )
				{
					strings.Add( ledger.ToString() );
				}
				return strings.ToArray();
			}
		}

		string xperdex.core.interfaces.IReflectorVariableNamedArray.this[String member]
		{
			get
			{
				AccrualGroup v = Local.known_accrual_groups[member];
				if( v != null )
				{
					return v.ball_count.ToString();
				}
				return "";
			}
		}

		#endregion
	}

	class AccrualCurrentPercentVariable : xperdex.core.interfaces.IReflectorVariableNamedArray
	{
		#region IReflectorVariable Members

		string xperdex.core.interfaces.IReflectorVariableNamedArray.Name
		{
			get { return "Current Percent"; }
		}
		string[] xperdex.core.interfaces.IReflectorVariableNamedArray.Members
		{
			get
			{
				List<String> strings = new List<string>();
				foreach( AccrualGroup ledger in Local.known_accrual_groups )
				{
					strings.Add( ledger.ToString() );
				}
				return strings.ToArray();
			}
		}

		string xperdex.core.interfaces.IReflectorVariableNamedArray.this[String member]
		{
			get
			{
				AccrualGroup v = Local.known_accrual_groups[member];
				if( v != null )
				{
					return v.primary_percent(v.GetLastPosted()).ToString();
				}
				return "";
			}
		}

		#endregion
	}

	class JackpotNextValueVariable : xperdex.core.interfaces.IReflectorVariableNamedArray
	{
		#region IReflectorVariable Members

		string xperdex.core.interfaces.IReflectorVariableNamedArray.Name
		{
			get { return "Jackpot New Value"; }
		}
		string[] xperdex.core.interfaces.IReflectorVariableNamedArray.Members
		{
			get
			{
				List<String> strings = new List<string>();
				foreach( AccrualGroup ledger in Local.known_accrual_groups )
				{
					strings.Add( ledger.ToString() );
				}
				return strings.ToArray();
			}
		}

		string xperdex.core.interfaces.IReflectorVariableNamedArray.this[String member]
		{
			get
			{
				AccrualGroup v = Local.known_accrual_groups[member];
				if( v != null )
				{
					//if( v.this_row.RowState != DataRowState.Unchanged
					//	&& v.prior_accrument != null
					//	&& v.prior_accrument.prior_accrument != null )
					//	return v.prior_accrument.primary_start.ToString( "C" );
					return v.prior_accrument.primary_end.ToString( "C" );
				}
				return "";
			}
		}

		#endregion
	}
	class CurrentSessionVariable : xperdex.core.interfaces.IReflectorVariable
	{
		public string Name
		{
			get { return "Current_Session"; }
		}

		public string Text
		{
			get
			{
				bool closed = true;
				foreach( AccrualGroup group in Local.known_accrual_groups )
				{
					if( !group.prior_accrument.closed )
					{
						closed = false;
						break;
					}
				}
				if( Local.current_session_slot != null &&
					!Local.ConfigureState.use_ses_status )
				{
					if( closed )
						return Local.StripSpaces( Local.current_session_slot["slt_desc"].ToString() ) + "(Closed)";
					else
						return Local.StripSpaces( Local.current_session_slot["slt_desc"].ToString() ) + "(Current)";
				}
				else if( Local.current_session_slot != null )
					switch( (int)Local.current_session["ses_status"] )
					{
						case 2:
							return Local.StripSpaces( Local.current_session_slot["slt_desc"].ToString() ) + "(Current)";
						case 4:
						case 3:
							return Local.StripSpaces( Local.current_session_slot["slt_desc"].ToString() ) + "(Closed)";
						default:
							return Local.StripSpaces( Local.current_session_slot["slt_desc"].ToString() ) + "(?)";
					}
				return "No Current Session";
			}
			set
			{
				;
			}
		}
	}

	class CurrentProgramVariable : xperdex.core.interfaces.IReflectorVariable
	{
		public string Name
		{
			get { return "Current_Program"; }
		}

		public string Text
		{
			get
			{
				bool closed = true;
				foreach( AccrualGroup group in Local.known_accrual_groups )
				{
					if( !group.prior_accrument.closed )
					{
						closed = false;
						break;
					}
				}
				if( Local.current_program != null &&
					!Local.ConfigureState.use_ses_status )
				{
					if( closed )
						return Local.StripSpaces( Local.current_program["prg_desc"].ToString() ) + "(Closed)";
					else
						return Local.StripSpaces( Local.current_program["prg_desc"].ToString() ) + "(Current)";
				}
				else if( Local.current_program != null )
				{
					switch( (int)Local.current_session["ses_status"] )
					{
						case 2:
							return Local.StripSpaces( Local.current_program["prg_desc"].ToString() ) + "(Current)";
						case 4:
							return Local.StripSpaces( Local.current_program["prg_desc"].ToString() ) + "(Closed)";
						default:
							return Local.StripSpaces( Local.current_program["prg_desc"].ToString() ) + "(?)";
					}
				}
				return "No Current Session";
			}
			set
			{
				;
			}
		}
	}

	class CurrentSessionDateVariable : xperdex.core.interfaces.IReflectorVariable
	{
		public string Name
		{
			get { return "Current_Date"; }
		}

		public string Text
		{
			get
			{
				if( Local.current_session != null )
				{
					DateTime dt;
					if( DateTime.TryParse( Local.current_session["ses_date"].ToString(), out dt ) )
						return dt.ToString( "d" );
				}
				return "No Current Session";
			}
			set
			{
				
			}
		}
	}
#if asdf
	class JackpotNameVariable : xperdex.core.interfaces.IReflectorVariableNamedArray
	{
		#region IReflectorVariable Members

		string xperdex.core.interfaces.IReflectorVariableNamedArray.Name
		{
			get { return "Jackpot_Name"; }
		}
		string[] xperdex.core.interfaces.IReflectorVariableNamedArray.Members
		{
			get { 
				List<String> strings = new List<string>();
				foreach( AccrualGroup ledger in Local.known_accrual_groups )
				{
					strings.Add( ledger.ToString() );
				}
				return strings.ToArray();
			}
		}

		string xperdex.core.interfaces.IReflectorVariableNamedArray.this[String member]
		{
			get
			{
				object v = Local.known_ledgers[member];
				if( v != null )
					return v.ToString();
				return "";
			}
		}

		#endregion
	}
#endif
	[ButtonAttribute( Name = "Configure Accruals" )]
	class ButtonConfigureAccruals : IReflectorButton, IReflectorCreate
	{

		#region IReflectorButton Members

		bool IReflectorButton.OnClick()
		{
			ConfigurationForm oe = new ConfigurationForm();
			oe.ShowDialog();
			oe.Dispose();
			return true;
		}

		#endregion

		public void OnCreate( Control pc )
		{
			pc.Text = "Edit_Jackpots";
			PSI_Button button = pc as PSI_Button;
			if( button != null )
			{
				core_common.GetGlareSetAttributes( "Utility Button", DefaultAttributes );
				button.gs = new GlareSet( "Default", "Utility Button" );
			}
		}

		void DefaultAttributes( GlareSetAttributes attrib )
		{
			attrib.SetColor( Color.Red );
			attrib.SetColor2( Color.Black );
			attrib.TextColor = Color.White;
		}
	}

	[ButtonAttribute( Name = "Commit Changes" )]
	class ButtonCommitChanges : IReflectorButton, IReflectorCreate
	{

		#region IReflectorButton Members

		bool IReflectorButton.OnClick()
		{
			Local.CommitSettingChanges();
			return true;
		}

		#endregion

		public void OnCreate( Control pc )
		{
			pc.Text = "Commit_Changes";
			PSI_Button button = pc as PSI_Button;
			if( button != null )
			{
				core_common.GetGlareSetAttributes( "Utility Button", DefaultAttributes );
				button.gs = new GlareSet( "Default", "Utility Button" );
			}
		}

		void DefaultAttributes( GlareSetAttributes attrib )
		{
			attrib.SetColor( Color.Red );
			attrib.SetColor2( Color.Black );
			attrib.TextColor = Color.White;
		}
	}

	[ButtonAttribute( Name = "Process Sessions" )]
	class ButtonProcessSessions : IReflectorButton, IReflectorCreate
	{

		#region IReflectorButton Members

		bool IReflectorButton.OnClick()
		{
			//Local.LoadSomeUnprocessedSessions();
			Local.LoadOneUnprocessedSession();
			return true;
		}

		#endregion

		public void OnCreate( Control pc )
		{
			pc.Text = "Process_Sessions";
			PSI_Button button = pc as PSI_Button;
			if( button != null )
			{
				core_common.GetGlareSetAttributes( "Utility Button", DefaultAttributes );
				button.gs = new GlareSet( "Default", "Utility Button" );
			}
		}

		void DefaultAttributes( GlareSetAttributes attrib )
		{
			attrib.SetColor( Color.Red );
			attrib.SetColor2( Color.Black );
			attrib.TextColor = Color.White;
		}
	}

	[ButtonAttribute( Name = "Update Session" )]
	class ButtonUpdateSession : IReflectorButton, IReflectorCreate
	{

		#region IReflectorButton Members

		bool IReflectorButton.OnClick()
		{
			xperdex.gui.Banner.Show( "Loading Sales...", true );
			Local.DoUpdateButton();
			xperdex.gui.Banner.End();
			return true;
		}

		#endregion

		public void OnCreate( Control pc )
		{
			pc.Text = "Update";
			PSI_Button button = pc as PSI_Button;
			if( button != null )
			{
				Local.ConfigureState.process_buttons.Add( button );
				button.Highlight = true;
				core_common.GetGlareSetAttributes( "Utility Button", DefaultAttributes );
				button.gs = new GlareSet( "Default", "Utility Button" );
			}
		}

		void DefaultAttributes( GlareSetAttributes attrib )
		{
			attrib.SetColor( Color.Red );
			attrib.SetColor2( Color.Black );
			attrib.TextColor = Color.White;
		}
	}

	[ButtonAttribute( Name = "Close Session" )]
	class ButtonCloseSession : IReflectorButton, IReflectorCreate
	{

		#region IReflectorButton Members

		bool IReflectorButton.OnClick()
		{
			bool okay_to_process = true;
			foreach( AccrualGroup group in Local.known_accrual_groups )
			{
				if( !group.prior_accrument.posted && !group.IsDailyAccrual )
					okay_to_process = false;
			}
			if( !okay_to_process )
				if( Local.current_session == null )
				{
					MessageBox.Show( "Please process a session before closing" );
					return true;
				}
				else
				{
					MessageBox.Show( "Please post accruals before closing." );
					return true;
				}

			Local.PollCurrentSession();
			foreach( AccrualGroup group in Local.known_accrual_groups )
			{
				if( group.prior_accrument != null )
				{
					group.prior_accrument.closed = true;
				}
			}

			Local.UpdateSessionStatus();

			//Local.LoadSomeUnprocessedSessions();
			if( Local.current_session == null 
				|| !Local.ConfigureState.use_ses_status
				|| ( (int)Local.current_session["ses_status"] == 4 ) )
			{
				Local.CommitChanges( true );

				Local.current_session = null;
				Local.current_program = null;
				Local.current_session_slot = null;
				Local.Refresh();

				foreach( PSI_Button button in Local.ConfigureState.close_buttons )
					button.Highlight = false;
				foreach( PSI_Button button in Local.ConfigureState.process_buttons )
					button.Highlight = true;
			}
			else
				MessageBox.Show( "Please close the current session" );
			// will not be commited, and show the end value. (before creating next accrument)
			return true;
		}

		#endregion

		public void OnCreate( Control pc )
		{
			Local.ConfigureState.close_session_buttons.Add( this );
			pc.Text = "Close_Session";
			PSI_Button button = pc as PSI_Button;
			Local.ConfigureState.close_buttons.Add( button );
			if( button != null )
			{
				core_common.GetGlareSetAttributes( "Utility Button", DefaultAttributes );
				button.gs = new GlareSet( "Default", "Utility Button" );
			}
		}

		void DefaultAttributes( GlareSetAttributes attrib )
		{
			attrib.SetColor( Color.Red );
			attrib.SetColor2( Color.Black );
			attrib.TextColor = Color.White;
		}
	}

	[ButtonAttribute( Name = "Post Session" )]
	class ButtonPostSession : IReflectorButton, IReflectorCreate
	{

		#region IReflectorButton Members

		bool IReflectorButton.OnClick()
		{
			Local.PostAccruals( true );
			return true;
		}

		#endregion

		public void OnCreate( Control pc )
		{
			//Local.ConfigureState.close_session_buttons.Add( this );
			pc.Text = "Post_Session";
			PSI_Button button = pc as PSI_Button;
			if( button != null )
			{
				Local.ConfigureState.post_buttons.Add( button );
				core_common.GetGlareSetAttributes( "Utility Button", DefaultAttributes );
				button.gs = new GlareSet( "Default", "default" );
			}
		}

		void DefaultAttributes( GlareSetAttributes attrib )
		{
			attrib.SetColor( Color.Red );
			attrib.SetColor2( Color.Black );
			attrib.TextColor = Color.White;
		}
	}

	[ButtonAttribute( Name = "Post Day" )]
	class ButtonPostDaily : IReflectorButton, IReflectorCreate
	{

		#region IReflectorButton Members

		bool IReflectorButton.OnClick()
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
					return true;
				}
			//Local.LoadSomeUnprocessedSessions();
			//if( (int)Local.current_session["ses_status"] == 4 )

			foreach( AccrualGroup group in Local.known_accrual_groups )
			{
				if( group.prior_accrument != null
					&& !group.prior_accrument.posted
					&& group.IsDailyAccrual )
				{
					Local.PostAccrual( group );
				}
			}

			Local.CommitChanges( true );

			//foreach( PSI_Button button in Local.ConfigureState.post_buttons )
			//	button.Highlight = false;
			//foreach( PSI_Button button in Local.ConfigureState.close_buttons )
			//	button.Highlight = true;
			//else
			//	MessageBox.Show( "Please close the current session" );
			// will not be commited, and show the end value. (before creating next accrument)
			//Local.current_session = null;
			//Local.current_session_slot = null;
			Local.Refresh();
			return true;
		}

		#endregion

		public void OnCreate( Control pc )
		{
			//Local.ConfigureState.close_session_buttons.Add( this );
			pc.Text = "Post_Dailies";
			PSI_Button button = pc as PSI_Button;
			if( button != null )
			{
				Local.ConfigureState.post_buttons.Add( button );
				core_common.GetGlareSetAttributes( "Utility Button", DefaultAttributes );
				button.gs = new GlareSet( "Default", "default" );
			}
		}

		void DefaultAttributes( GlareSetAttributes attrib )
		{
			attrib.SetColor( Color.Red );
			attrib.SetColor2( Color.Black );
			attrib.TextColor = Color.White;
		}
	}

	[ButtonAttribute( Name = "Unpost Session" )]
	class ButtonUnpostSession : IReflectorButton, IReflectorCreate
	{

		#region IReflectorButton Members

		void UnpostDay( AccrualGroup group )
		{
			DateTime start;
			if( DateTime.TryParse( group.prior_accrument.session_date, out start ) )
			{
				DateTime testtime;
				LinkedListNode<AccrualGroup.Accrument> test = group.accruments.Last;
				if( !DateTime.TryParse( test.Value.session_date, out testtime ) )
					return;
				while( test != null && testtime == start )
				{
					test.Value.posted = false;
					test.Value.DoMath();
					test = test.Previous;
					if( test != null )
					{
						group.PostedValue = test.Value.primary_end;
						if( !DateTime.TryParse( test.Value.session_date, out testtime ) )
							break;
					}
				}
			}
		}

		bool IReflectorButton.OnClick()
		{
			bool okay_to_process = false;
			foreach( AccrualGroup group in Local.known_accrual_groups )
			{
				if( group.prior_accrument.posted )
					okay_to_process = true;
			}
			if( !okay_to_process )
				if( Local.current_session == null )
				{
					MessageBox.Show( "Already Unposted" );
					return true;
				}
			//Local.LoadSomeUnprocessedSessions();
			//if( (int)Local.current_session["ses_status"] == 4 )
			foreach( AccrualGroup group in Local.known_accrual_groups )
			{
				if( group.prior_accrument != null
					&& ( group.prior_accrument.posted )

					&& ( group.prior_accrument.Input > 0 ) )
				{
					if( group.IsDailyAccrual )
						UnpostDay( group );
					else
					{
						group.prior_accrument.posted = false;
						group.PostedValue = group.prior_accrument.primary_end;
						group.prior_accrument.DoMath();
					}
				}
			}
			//Local.CommitChanges();

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
			return true;
		}

		#endregion

		public void OnCreate( Control pc )
		{
			//Local.ConfigureState.close_session_buttons.Add( this );
			pc.Text = "Unpost_Session";
			PSI_Button button = pc as PSI_Button;
			if( button != null )
			{
				Local.ConfigureState.post_buttons.Add( button );
				core_common.GetGlareSetAttributes( "Utility Button", DefaultAttributes );
				button.gs = new GlareSet( "Default", "default" );
			}
		}

		void DefaultAttributes( GlareSetAttributes attrib )
		{
			attrib.SetColor( Color.Red );
			attrib.SetColor2( Color.Black );
			attrib.TextColor = Color.White;
		}
	}

	[ButtonAttribute( Name = "Reload Prior Accruals")]
	class ButtonReloadPriorAccruals : IReflectorButton, IReflectorCreate
	{

		#region IReflectorButton Members

		bool IReflectorButton.OnClick()
		{

			foreach( AccrualGroup group in Local.known_accrual_groups )
			{
				group.LoadPriorAccruals();
			}
			Local.accrual_details.ConfigureState_current_accrual_group_changed();
			//else
			//	MessageBox.Show( "Please close the current session" );
			// will not be commited, and show the end value. (before creating next accrument)
			//Local.current_session = null;
			//Local.current_session_slot = null;
			Local.Refresh();
			return true;
		}

		#endregion

		public void OnCreate( Control pc )
		{
			//Local.ConfigureState.close_session_buttons.Add( this );
			pc.Text = "Reload_Accruals";
			PSI_Button button = pc as PSI_Button;
			if( button != null )
			{
				core_common.GetGlareSetAttributes( "Utility Button", DefaultAttributes );
				button.gs = new GlareSet( "Default", "default" );
			}
		}

		void DefaultAttributes( GlareSetAttributes attrib )
		{
			attrib.SetColor( Color.Red );
			attrib.SetColor2( Color.Black );
			attrib.TextColor = Color.White;
		}
	}

	[ButtonAttribute( Name = "Reload Accruals" )]
	class ButtonReloadAccruals : IReflectorButton, IReflectorCreate
	{

		#region IReflectorButton Members

		bool IReflectorButton.OnClick()
		{
			xperdex.gui.Banner.Show( "Reloading...", true );
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
			Local.ReloadAccrualGroups( false );
			foreach( xperdex.core.PSI_Button b in Local.ConfigureState.post_buttons )
				b.Highlight = false;
			foreach( xperdex.core.PSI_Button b in Local.ConfigureState.close_buttons )
				b.Highlight = false;
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
			Local.DoUpdateButton();
			xperdex.gui.Banner.End();
			//Local.Refresh();
			return true;
		}

		#endregion

		public void OnCreate( Control pc )
		{
			//Local.ConfigureState.close_session_buttons.Add( this );
			pc.Text = "Reload_Accruals";
			PSI_Button button = pc as PSI_Button;
			if( button != null )
			{
				core_common.GetGlareSetAttributes( "Utility Button", DefaultAttributes );
				button.gs = new GlareSet( "Default", "default" );
			}
		}

		void DefaultAttributes( GlareSetAttributes attrib )
		{
			attrib.SetColor( Color.Red );
			attrib.SetColor2( Color.Black );
			attrib.TextColor = Color.White;
		}
	}


	[ButtonAttribute( Name = "Do Payout" )]
	class ButtonDoPayout : IReflectorButton, IReflectorCreate, IReflectorPersistance
	{

		#region IReflectorButton Members
		internal PSI_Button button;
		//internal AccrualGroup group;
		internal int percent;
		internal bool pay_from_kitty;
		internal Decimal pay_value;
		internal int _group_index;
		internal int group_index
		{
			set { _group_index = value; }
		}
		/*
		internal string _group_name;
		internal string group_name
		{
			set
			{
				_group_name = value;
				//group = Local.known_accrual_groups[value];
			}
		}
		*/
		bool IReflectorButton.OnClick()
		{
			if( _group_index < 0 || _group_index >= Local.known_accrual_groups.Count )
				return false;
			AccrualGroup group = Local.known_accrual_groups[_group_index];

			if( Local.current_session_slot == null )
			{
				MessageBox.Show( "Please Update accruals for current session" );
				return false;
			}
			Local.PollCurrentSession();
			if( Local.ConfigureState.use_ses_status && (int)Local.current_session["ses_status"] != 2 )
			{
				MessageBox.Show( "Please update to the current session to do payout" );
				return false;
			}
			//Local.LoadSomeUnprocessedSessions();
			if( group != null )
			{
				if( group.AnySession || group.CountsSession( Local.current_session_slot["slt_id"] ) )
				{
					PayoutForm payform = new PayoutForm( group, percent, pay_value, pay_from_kitty );
					if( payform.ShowDialog() == DialogResult.OK )
					{
						group.Payout( group._prior_accrument
									, payform.pay_count
									, payform.percent
									, payform.payout
									, pay_from_kitty );
						Local.Refresh();
					}
					payform.Dispose();
				}
				else
					MessageBox.Show( "Cannot pay this in current session" );
			}
			else
				MessageBox.Show( "Button not configured to an accrual group" );
			return true;
		}

		#endregion

		public void OnCreate( Control pc )
		{
			pc.Text = "Pay";
			percent = 100;
			button = pc as PSI_Button;
			if( button != null )
			{
				core_common.GetGlareSetAttributes( "Utility Button", DefaultAttributes );
				button.gs = new GlareSet( "Default", "Utility Button" );
			}
		}

		void DefaultAttributes( GlareSetAttributes attrib )
		{
			attrib.SetColor( Color.Red );
			attrib.SetColor2( Color.Black );
			attrib.TextColor = Color.White;
		}

		static bool version_error = false;

		public bool Load( System.Xml.XPath.XPathNavigator r )
		{
			bool ok;
			bool everok = false;
			if( String.Compare( r.Name, "paybutton" ) == 0 )
			{
				for( ok = r.MoveToFirstAttribute(); ok; ok = r.MoveToNextAttribute() )
				{
					everok = true;
					if( r.Name == "group" )
					{
						if( !version_error )
						{
							MessageBox.Show( "Group name on payout button is not allowed anymore.\nPlease edit Payout buttons." );
							version_error = true;
						}
						//group_name = r.Value;
						//group = Local.known_accrual_groups[r.Value];
					}
					else if( r.Name == "group_index" )
					{
						group_index = r.ValueAsInt;
						//group = Local.known_accrual_groups[r.Value];
					}
					else if( r.Name == "percent" )
					{
						percent = r.ValueAsInt;
					}
					else if( r.Name == "payval" )
					{
						double p = r.ValueAsDouble;
						pay_value = (Decimal)p;
					}
					else if( r.Name == "pay_kitty" )
					{
						pay_from_kitty = r.ValueAsBoolean;
					}
				}
				if( everok )
					r.MoveToParent();
				return true;
			}
			return false;
		}

		public void Save( System.Xml.XmlWriter w )
		{
			w.WriteStartElement( "paybutton" );
			//if( _group_name != null )
			//	w.WriteAttributeString( "group", _group_name );
			w.WriteAttributeString( "group_index", _group_index.ToString() );
			w.WriteAttributeString( "percent", percent.ToString() );
			w.WriteAttributeString( "payval", pay_value.ToString() );
			w.WriteAttributeString( "pay_kitty", pay_from_kitty?"1":"0" );
			w.WriteEndElement();
		}

		public void Properties()
		{
			XperdexPayButtonForm xpbf = new XperdexPayButtonForm( this );
			xpbf.ShowDialog();
			xpbf.Dispose();
		}
	}

	[ButtonAttribute( Name = "Do Post" )]
	class ButtonDoPost : IReflectorButton, IReflectorCreate, IReflectorPersistance
	{

		#region IReflectorButton Members
		internal PSI_Button button;
		internal AccrualGroup group;

		bool IReflectorButton.OnClick()
		{
			if( Local.current_session_slot == null )
			{
				MessageBox.Show( "Please Update accruals for current session" );
				return false;
			}
			//Local.LoadSomeUnprocessedSessions();
			if( group != null )
			{
				if( group.IsWeeklyAccrual )
				{
					group.prior_accrument.primary_sales = group.primaryIncrement;
					group.prior_accrument.secondary_sales = group.secondaryIncrement;
					group.prior_accrument.tertiary_sales = group.tertiaryIncrement;
					if( group.prior_accrument.ball_delta < group.ball_count_max )
						group.prior_accrument.ball_delta = group.ball_count;
				}
				Local.PostAccrual( group );
				Local.Refresh();
			}
			else
				MessageBox.Show( "Button not configured to an accrual group" );
			return true;
		}

		#endregion

		public void OnCreate( Control pc )
		{
			pc.Text = "Post";
			button = pc as PSI_Button;
			if( button != null )
			{
				core_common.GetGlareSetAttributes( "Utility Button", DefaultAttributes );
				button.gs = new GlareSet( "Default", "Utility Button" );
			}
		}

		void DefaultAttributes( GlareSetAttributes attrib )
		{
			attrib.SetColor( Color.Red );
			attrib.SetColor2( Color.Black );
			attrib.TextColor = Color.White;
		}

		public bool Load( System.Xml.XPath.XPathNavigator r )
		{
			bool ok;
			bool everok = false;
			if( String.Compare( r.Name, "postbutton" ) == 0 )
			{
				for( ok = r.MoveToFirstAttribute(); ok; ok = r.MoveToNextAttribute() )
				{
					everok = true;
					if( r.Name == "group" )
					{
						group = Local.known_accrual_groups[r.Value];
					}
				}
				if( everok )
					r.MoveToParent();
				return true;
			}
			return false;
		}

		public void Save( System.Xml.XmlWriter w )
		{
			w.WriteStartElement( "postbutton" );
			if( group != null )
				w.WriteAttributeString( "group", group.Name );
			w.WriteEndElement();
		}

		public void Properties()
		{
			XperdexPostButtonForm xpbf = new XperdexPostButtonForm( this );
			xpbf.ShowDialog();
			xpbf.Dispose();
		}
	}

	[ButtonAttribute( Name = "Rollback Accruals" )]
	class ButtonDoRollback: IReflectorButton, IReflectorCreate
	{

		#region IReflectorButton Members
		internal PSI_Button button;
		//internal AccrualGroup group;

		bool IReflectorButton.OnClick()
		{
			xperdex.gui.Banner.Show( "Rolling back accruals", true );
			foreach( AccrualGroup group in Local.known_accrual_groups )
			{
				if( group._prior_accrument.prior_accrument == null )
					group.LoadPriorAccruals();
				else if( group._prior_accrument.prior_accrument.prior_accrument == null )
					group.LoadPriorAccruals();
				else if( group._prior_accrument.prior_accrument == null 
					|| group._prior_accrument.prior_accrument.prior_accrument == null
					
					)
				{
					MessageBox.Show( "Unable to rollback, no prior sessions" );
					xperdex.gui.Banner.End();
					return true;
				}
			}
			List<Guid> lasts = new List<Guid>();
			bool posted = false;
			foreach( AccrualGroup group in Local.known_accrual_groups )
			{
				if( group._prior_accrument.posted 
					&& group._prior_accrument.input != 0 
					&& group._prior_accrument.this_row.RowState != DataRowState.Added
					) // zero input is auto posted... so it doesn't count.
					posted = true;
			}

			if( Local.current_session != null && !posted )
			{
				foreach( AccrualGroup group in Local.known_accrual_groups )
				{
					if( group._prior_accrument.prior_accrument != null )
					{
						lasts.Add( group._prior_accrument.ID );
						lasts.Add( group._prior_accrument.prior_accrument.ID );
						Local.dataConnection.ExecuteNonQuery( "update ap_accrual_group set last_accrument='"
							+ group._prior_accrument.prior_accrument.prior_accrument.ID + "'" + " where accrual_group_id='" + group.ID + "'" );
					}
				}
			}
			else
			{
				foreach( AccrualGroup group in Local.known_accrual_groups )
				{
					lasts.Add( group._prior_accrument.ID );
					if( group._prior_accrument.prior_accrument == null )
						Local.dataConnection.ExecuteNonQuery( "update ap_accrual_group set last_accrument=NULL "
								+ " where accrual_group_id='" + group.ID + "'" );
					else
						Local.dataConnection.ExecuteNonQuery( "update ap_accrual_group set last_accrument='"
						+ group._prior_accrument.prior_accrument.ID + "'" + " where accrual_group_id='" + group.ID + "'" );
				}
			}
			StringBuilder sb = new StringBuilder();
			//String delete_set = "";
			bool first = true;
			foreach( Guid g in lasts )
			{
				if( !first )
					sb.Append( "," );
				first = false;
				sb.Append( "'" + g + "'" );
			}
			Local.dataConnection.ExecuteNonQuery( "delete from ap_accrument where accrument_id in (" + sb.ToString() + ")" );
			Local.ClearAndReloadAccruals();
			Local.Refresh();
			xperdex.gui.Banner.End();
			return true;
		}

		#endregion

		public void OnCreate( Control pc )
		{
			pc.Text = "Rollback_Accruals";
			button = pc as PSI_Button;
			if( button != null )
			{
				core_common.GetGlareSetAttributes( "Utility Button", DefaultAttributes );
				button.gs = new GlareSet( "Default", "Utility Button" );
			}
		}

		void DefaultAttributes( GlareSetAttributes attrib )
		{
			attrib.SetColor( Color.Green );
			attrib.SetColor2( Color.Black );
			attrib.TextColor = Color.White;
		}
	}



	[ControlAttribute( Name = "Show Group Details" )]
	class GridAccrualDetails : IReflectorCreate
	{
		public GridAccrualDetails()
		{
		}

		public void OnCreate( Control pc )
		{
			//throw new NotImplementedException();
			Local.AccrualGroupStatus = pc;
		}
	}


	[ControlAttribute( Name = "Accrual Group Select" )]
	class CommboBoxSelectAccrualGroup : ComboBox, IReflectorCreate, IReflectorScale
	{
		xperdex.gui.font_tracker font;
		xperdex.classes.Fraction last_scale = new xperdex.classes.Fraction(1, 1);


		public CommboBoxSelectAccrualGroup( Control pc )
		{
			// default constructor through xperdex?
			font = xperdex.gui.FontEditor.GetFontTracker( "Accrual Group Selector" );
			this.Font = font.font;
			font.OnFontChange += new xperdex.gui.font_tracker.FontChanged( font_OnFontChange );
			//xperdex.classes.Log.log( "something 2" );
		}

		void font_OnFontChange()
		{
			Font = new Font( font.family, font.size * last_scale.ToFloat(), font.style, font.unit );
			
		}

		public void OnCreate( Control pc )
		{
			// will this ahppen?
			//throw new NotImplementedException();
			//xperdex.classes.Log.log( "something" );
			//Local.AccrualGroupStatus = pc;
			Local.ConfigureState.select_session_combobox.Add( pc as ComboBox );
			DataSource = Local.accrual_group_table;
			DisplayMember = AccrualGroup.AccrualGroupTable.NameColumn;
			this.SelectedValueChanged += new EventHandler( CommboBoxSelectSession_SelectedValueChanged );
			this.VisibleChanged += new EventHandler( CommboBoxSelectAccrualGroup_VisibleChanged );
			SelectedItem = null;
		}

		void CommboBoxSelectAccrualGroup_VisibleChanged( object sender, EventArgs e )
		{
			//if( SelectedValueChanged != null )
			//	SelectedValueChanged();
			if( this.SelectedValue != null )
				Local.ConfigureState.current_accrual_group = ( this.SelectedValue as DataRowView ).Row;
			else
				Local.ConfigureState.current_accrual_group = null;
		}

		void CommboBoxSelectSession_SelectedValueChanged( object sender, EventArgs e )
		{
			//e as 
			//e.
			if( this.SelectedValue != null )
				Local.ConfigureState.current_accrual_group = ( this.SelectedValue as DataRowView ).Row;
			else
				Local.ConfigureState.current_accrual_group = null;
		}

		public void SetScale( xperdex.classes.Fraction scale_x, xperdex.classes.Fraction scale_y )
		{
			last_scale = scale_x;
			Font = new Font( font.family, font.size * scale_x.ToFloat(), font.style, font.unit );
		}
	}


	[ControlAttribute( Name = "Accrual Group Details" )]
	class CommboBoxSelectSession : DataGridView, IReflectorScale
	{
		xperdex.gui.font_tracker font;
		xperdex.classes.Fraction last_scale = new xperdex.classes.Fraction( 1, 1 );
		int accrual_row;

		public CommboBoxSelectSession( Control pc )
		{
			// default constructor through xperdex?
			Local.accrual_details = this;
			font = xperdex.gui.FontEditor.GetFontTracker( "Accrual Group Details" );
			this.Font = font.font;
			font.OnFontChange += new xperdex.gui.font_tracker.FontChanged( font_OnFontChange );

			//DataSource = Local.accrual_group_table;
			Local.ConfigureState.current_accrual_group_changed += new Local.ConfigureState.simple_event( ConfigureState_current_accrual_group_changed );
			//xperdex.classes.Log.log( "something 2" );

			Columns.Add( "session", "Session" );
			Columns[0].Width = 110;
			Columns.Add( "primary", "Primary Start" );
			Columns[1].Width = 60;
			Columns.Add( "secondary", "Secondary Start" );
			Columns[2].Width = 60;
			Columns.Add( "sales", "Sales" );
			Columns.Add( "house", "House" );
			Columns.Add( "primary_add", "+ Primary" );
			Columns.Add( "secondary_add", "+ Secondary" );
			Columns.Add( "primary_end", "Primary End" );
			Columns.Add( "secondary_end", "Secondary End" );
			Columns.Add( "payout", "Payout" );
			Columns.Add( "kitty", "Kitty" );
			Columns.Add( "ball_end", "Balls" );
			Columns.Add( "ball_delta", "Balls" );
			for( int n = 1; n < 11; n++ )
			{
				Columns[n].ReadOnly = true;
				Columns[n].DefaultCellStyle.Format = "C";
			}

			ColumnHeadersHeight = ( ColumnHeadersHeight - 8 ) * 2 + 8;
			RowHeadersVisible = false;
			AllowUserToAddRows = false;
			AllowUserToDeleteRows = false;
			MouseClick += new MouseEventHandler( CommboBoxSelectSession_MouseClick );
			
		}

		void CommboBoxSelectSession_MouseClick( object sender, MouseEventArgs e )
		{
			if( e.Button == MouseButtons.Right )
			{
				//if( Local.ConfigureState._current_accrual_group != null )
				{
					accrual_row = HitTest( e.X, e.Y ).RowIndex;
					if( accrual_row >= 0 )
					{
						ContextMenu m = new ContextMenu();
						m.MenuItems.Add( new MenuItem( "Edit Accrual", EditEvent ) );
						//m.MenuItems.Add( new MenuItem( "Copy" ) );
						//m.MenuItems.Add( new MenuItem( "Paste" ) );


						//if( currentMouseOverRow >= 0 )
						//{
						//m.MenuItems.Add( new MenuItem( string.Format( "Do something to row {0}", currentMouseOverRow.ToString() ) ) );
						//}

						m.Show( this, new Point( e.X, e.Y ) );
					}
				}
			}
		}

		void EditEvent( object o, EventArgs e )
		{
			int n;
			if( Local.ConfigureState._current_accrual_group != null )
			{
				LinkedListNode<AccrualGroup.Accrument> a = Local.ConfigureState._current_accrual_group.accruments.First;
				for( n = 0; n < accrual_row; n++ )
				{
					a = a.Next;
				}
				if( a != null )
				{
					EditAccrualForm edit = new EditAccrualForm( Local.ConfigureState._current_accrual_group
						, a.Value );
					edit.ShowDialog();
					edit.Dispose();
				}
			}
			else
			{
				EditAccrualForm edit = new EditAccrualForm( Local.known_accrual_groups[accrual_row]
					, Local.known_accrual_groups[accrual_row].accruments.Last.Value );
				edit.ShowDialog();
				edit.Dispose();
			}
		}

		void font_OnFontChange()
		{
			Font = new Font( font.family, font.size * last_scale.ToFloat(), font.style, font.unit );
			ColumnHeadersHeight *= Font.Height * 2 + 8;

		}

		public void OnCreate( Control pc )
		{
			//DisplayMember = AccrualGroup.AccrualGroupTable.NameColumn;
			//this.SelectedValueChanged += new EventHandler( CommboBoxSelectSession_SelectedValueChanged );
		}

		internal void ConfigureState_current_accrual_group_changed()
		{
			if( Columns.Count == 0 )
				return;
			this.Rows.Clear();
			object[] row = new object[13];
			//this.Columns.Clear();
			if( Local.ConfigureState._current_accrual_group != null )
			{
				foreach( AccrualGroup.Accrument accru in Local.ConfigureState._current_accrual_group.accruments )
				{
					if( accru.ses_id > 0 )
					{
						if( accru.session_name == null )
							row[0] = "Last Session";
						else
							row[0] = accru.session_date + " " + accru.session_name;
						//row[0] = accru.ses_id;
					}
					else
						row[0] = "Last Session";
					row[1] = accru.primary_start;
					row[2] = accru.secondary_start;
					row[3] = accru.input;
					row[4] = accru.house.ToString( "C" ) + "(" + accru.house_percent.ToString() + "%)";
					row[5] = ( //accru.primary
						+ accru.primary_sales
						+ accru.primary_rollover
						+ accru.primary_seed
						+ accru.primary_fixup
						- ( accru.pay * accru.pay_count )
						).ToString( "C" ) + "(" + accru.primary_percent.ToString() + "%)"
						+ ( accru.primary_transfer > 0 ? " + " + accru.primary_transfer.ToString( "C" ) : "" )
						+ ( accru.primary_transfer < 0 ? " - " + (-accru.primary_transfer).ToString( "C" ) : "" )
						;
					row[6] = ( //accru.secondary
						+ accru.secondary_sales
						+ accru.secondary_rollover
						+ accru.secondary_transfer
						+ accru.secondary_seed
						- accru.primary_rollover
						+ accru.secondary_fixup
						).ToString( "C" ) + "(" + accru.secondary_percent.ToString() + "%)"
						+ ( accru.secondary_transfer > 0 ? " + " + accru.secondary_transfer.ToString( "C" ) : "" )
						+ ( accru.secondary_transfer < 0 ? " - " + ( -accru.secondary_transfer ).ToString( "C" ) : "" )
						;
					row[7] = accru.primary_end;
					row[8] = accru.secondary_end;
					row[9] = accru.pay * accru.pay_count;
					row[10] = accru.kitty;
					row[11] = accru.ball_delta;
					row[12] = accru.ball_end;
					int row_id;
					Rows[row_id = Rows.Add( row )].Height = Font.Height + 8;
					if( accru.posted )
						Rows[row_id].DefaultCellStyle.BackColor = Color.LightGreen;
					else
						Rows[row_id].DefaultCellStyle.BackColor = Color.LightPink;
				}
			}
			else
			{
				foreach( AccrualGroup group in Local.known_accrual_groups )
				{
					AccrualGroup.Accrument accru = group.prior_accrument;
					while( accru.prior_accrument != null && accru.input == 0 )
						accru = accru.prior_accrument;
					row[0] = group.Name;
					row[1] = accru.primary_start;
					row[2] = accru.secondary_start;
					row[3] = accru.input;
					row[4] = accru.house.ToString( "C" ) + "(" + accru.house_percent.ToString() + "%)";
					row[5] = ( //accru.primary
						+ accru.primary_sales
						+ accru.primary_rollover
						+ accru.primary_seed
						+ accru.primary_fixup
						- ( accru.pay * accru.pay_count )
						).ToString( "C" ) + "(" + accru.primary_percent.ToString() + "%)"
						+ ( accru.primary_transfer > 0 ? " + " + accru.primary_transfer.ToString( "C" ) : "" )
						+ ( accru.primary_transfer < 0 ? " - " + ( -accru.primary_transfer ).ToString( "C" ) : "" )
						;
					row[6] = ( //accru.secondary
						+ accru.secondary_sales
						+ accru.secondary_rollover
						+ accru.secondary_seed
						- accru.primary_rollover
						+ accru.secondary_fixup
						).ToString( "C" ) + "(" + accru.secondary_percent.ToString() + "%)"
						+ ( accru.secondary_transfer > 0 ? " + " + accru.secondary_transfer.ToString( "C" ) : "" )
						+ ( accru.secondary_transfer < 0 ? " - " + ( -accru.secondary_transfer ).ToString( "C" ) : "" )
						;
					row[7] = accru.primary_end;
					row[8] = accru.secondary_end;
					row[9] = accru.pay * accru.pay_count;
					row[10] = accru.input - ( accru.house + accru.primary_sales + accru.secondary_sales + accru.tertiary_sales )
						 - accru.primary_transfer;
					row[11] = accru.ball_delta;
					row[12] = accru.ball_end;
					int row_id;
					Rows[row_id = Rows.Add( row )].Height = Font.Height + 8;
					if( accru.posted )
						Rows[row_id].DefaultCellStyle.BackColor = Color.LightGreen;
					else
						Rows[row_id].DefaultCellStyle.BackColor = Color.LightPink;
				}
			}
		}

		public void SetScale( xperdex.classes.Fraction scale_x, xperdex.classes.Fraction scale_y )
		{
			last_scale = scale_x;
			Font = new Font( font.family, font.size * scale_x.ToFloat(), font.style, font.unit );
			int h = Font.Height;
			ColumnHeadersHeight = h * 2 + 8;
			foreach( DataGridViewRow row in Rows )
			{
				row.Height = h + 8;
			}
			foreach( DataGridViewColumn col in Columns )
			{
				switch( col.Index )
				{
				case 0:
					col.Width = h * 160 / 15;
					break;
				default:
					col.Width = h * 90 / 15;
					break;
				case 1:
				case 2:
					col.Width = h * 80 / 15;
					break;
				case 3:
					col.Width = h * 70 / 15;
					break;
				case 4:
					col.Width = h * 85 / 15;
					break;
				case 5:
				case 6:
					col.Width = h * 100 / 15;
					break;
				}
			}
		}
	}


	[SecurityAttribute( Name="eCube Security" )]
	public class AccrualSecurity : IReflectorSecurity, IReflectorPersistance
	{
		internal class  AccrualSecurityLogin
		{

		}

		//Stack<AccrualSecurityLogin> logins;

		public AccrualSecurity()
		{

		}

		bool IReflectorSecurity.Open()
		{
			return false;	
		}

		void IReflectorSecurity.Close()
		{
			
		}

		bool IReflectorSecurity.Test()
		{
			return false;
		}

		public bool Load( System.Xml.XPath.XPathNavigator r )
		{
			return false;
		}

		public void Save( System.Xml.XmlWriter w )
		{
			
		}

		public void Properties()
		{
			MessageBox.Show( "Prioerties?" );	
		}
	}

}
