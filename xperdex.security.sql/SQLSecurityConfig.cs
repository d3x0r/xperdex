using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using xperdex.classes;
using System.Data.Odbc;

namespace xperdex.security.sql
{
	public partial class SQLSecurityConfig : Form
	{
		//List<String> tokens;
		SQLSecurity.SecurityTracker tracker;
		internal SQLSecurityConfig( SQLSecurity.SecurityTracker tracker )
		{
			//this.tokens = ;
			this.tracker = tracker;
			// save the object we're attempting to configure... might not need it...
			InitializeComponent();
		}

		private void SQLSecurityConfig_Load( object sender, EventArgs e )
		{
			foreach( String token in tracker.tokens )
				listBoxAppliedTokens.Items.Add( token );

			//listBoxAvailableTokens.DataSource = xperdex.dataset.User.users.tokens;
			listBoxAvailableTokens.DisplayMember = "name";
			listBoxAvailableTokens.ValueMember = "name";
		}

		private void listBoxAvailableTokens_DoubleClick( object sender, EventArgs e )
		{
			listBoxAppliedTokens.Items.Add( listBoxAvailableTokens.SelectedItem );
		}

		private void listBoxAppliedTokens_DoubleClick( object sender, EventArgs e )
		{
			listBoxAppliedTokens.Items.Remove( listBoxAppliedTokens.SelectedItem );
		}
	}
}