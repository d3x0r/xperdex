using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xperdex.core.interfaces;
using xperdex.core;
using System.Data;
using System.Windows.Forms;

namespace SessionManager
{
	[ButtonAttribute( Name = "Open/Close Session For Issue" )]
	class OpenSessionForIssue: PSI_Button
	{
		public OpenSessionForIssue()
		{
			Text = "%<Session Issue Command> For_Issue";
			SessionManagementState.open_issue_buttons.Add( this );
			this.Click += ClickHandler;
			//button.T
		}

		public void ClickHandler( object sender, ReflectorButtonEventArgs e )
		{
			if( SessionManagementState.open_for_issue )
				SessionManagementState.CloseSessionIssue();
			else
				SessionManagementState.OpenSessionIssue();
			e.handled = true;
		}
	}

    [ButtonAttribute( Name = "Open/Close Session For Sales" )]
    class OpenSessionForSales : PSI_Button
    {
        public OpenSessionForSales()
        {
            Text = "%<Session Sales Command> For_Sales";
            SessionManagementState.open_sales_buttons.Add( this );
            this.Click += ClickHandler;
            //button.T
        }

        public void ClickHandler( object sender, ReflectorButtonEventArgs e )
        {
            if( SessionManagementState.open_for_sales )
                SessionManagementState.CloseSessionSales();
            else
                SessionManagementState.OpenSessionSales();
            e.handled = true;
        }
    }

    [ButtonAttribute( Name = "Set Active Session" )]
    class SetActiveSession : PSI_Button
	{
        public SetActiveSession()
		{
			Text = "Activate_Session";
			this.Click += ClickHandler;
		}

		public void ClickHandler( object sender, ReflectorButtonEventArgs e )
		{
			SessionManagementState.SetActiveSession();
			e.handled = true;
		}
	}

	[ButtonAttribute( Name = "Open/Close Session For Play" )]
	class OpenSessionForPlay : PSI_Button
	{
		public OpenSessionForPlay()
		{
			Text = "%<Session Play Command> For_Play";
			SessionManagementState.open_play_buttons.Add( this );
			this.Click += ClickHandler;
		}

		public void ClickHandler( object sender, ReflectorButtonEventArgs e )
		{
			if( SessionManagementState.open_for_play )
				SessionManagementState.CloseSessionPlay();
			else
				SessionManagementState.OpenSessionPlay();
			e.handled = true;
		}
	}

	[ButtonAttribute( Name = "Add Session" )]
	class AddNewSession : PSI_Button
	{
		public AddNewSession()
		{
			Text = "Add Session";
			//SessionManagementState.close_play_buttons.Add( this );
			this.Click += ClickHandler;
		}

		public void ClickHandler( object sender, ReflectorButtonEventArgs e )
		{
			SessionManagementState.AddNewSession();
			e.handled = true;

		}
	}


	[ButtonAttribute( Name = "Add All Sessions" )]
	class AddAllSession : PSI_Button
	{
		public AddAllSession()
		{
			Text = "Add All Sessions";
			//SessionManagementState.close_play_buttons.Add( this );
			this.Click += ClickHandler;
		}

		public void ClickHandler( object sender, ReflectorButtonEventArgs e )
		{
			DateTime end = new DateTime( 2013,12,31 );
			for( DateTime day = new DateTime( 2013, 01, 01 ); day <= end; day = day.AddDays( 1 ) )
			{
				int n = 0;
				foreach( DataRow session in SessionManagementState.schedule.sessions.Rows )
				{
					n++;
					SessionManagementState.AddNewSession( day, session );
					Application.DoEvents();
					SessionManagementState.OpenNewSession();
					Application.DoEvents();
				}
			}
			e.handled = true;

		}
	}
}
