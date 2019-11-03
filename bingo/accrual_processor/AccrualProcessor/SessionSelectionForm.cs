using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ECube.AccrualProcessor
{
	public partial class SessionSelectionForm : Form
	{
		internal DataRow SessionRow;
		List<DataRow> sessions = new List<DataRow>();
		bingoDataSet.bingoDataSet.sessionDataTable sessionTable;
		AccrualGroup.Accrument.AccrumentTable accruments;
		bingoDataSet.bingoDataSet.sesslotDataTable sesSlotTable;
		bingoDataSet.bingoDataSet.programDataTable programTable;
		internal SessionSelectionForm( bingoDataSet.bingoDataSet.sessionDataTable sessionTable 
			, AccrualGroup.Accrument.AccrumentTable accruments
			, bingoDataSet.bingoDataSet.sesslotDataTable sesSlotTable
			, bingoDataSet.bingoDataSet.programDataTable programTable
			)
		{
			this.programTable = programTable;
			this.sesSlotTable = sesSlotTable;
			this.sessionTable = sessionTable;
			this.accruments = accruments;
			InitializeComponent();
		}

		private void SessionSelectionForm_Load( object sender, EventArgs e )
		{
			listBoxSessions.UseTabStops = true;
			listBoxSessions.UseCustomTabOffsets = true;
			listBoxSessions.CustomTabOffsets.Add( 50 );
			listBoxSessions.CustomTabOffsets.Add( 100 );
			foreach( DataRow row in sessionTable.Rows )
			{
				DataRow[] has_accruments = accruments.Select( "ses_id=" + row["ses_id"] );
				if( has_accruments.Length == 0 )
				{
					DataRow[] sesSlotRows = sesSlotTable.Select( "slt_id=" + row["slt_id"] );
					DataRow[] programRows = programTable.Select( "prg_id=" + row["prg_id"] );
					int item = listBoxSessions.Items.Add(
								( (DateTime)row["ses_date"] ).ToString( "d" ) + "\t" 
								+ Local.StripSpaces( sesSlotRows[0]["slt_desc"].ToString() ) + "\t" 
								+ Local.StripSpaces( programRows[0]["prg_desc"].ToString() ) );
					sessions.Add( row );
					//listBoxSessions.
					//row.GetChildRows( "session_has_accrument" );
				}
			}
			if( listBoxSessions.Items.Count > 0 )
				listBoxSessions.SelectedIndex = 0;
		}

		/// <summary>
		/// Load Session
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button1_Click( object sender, EventArgs e )
		{
			int selected = listBoxSessions.SelectedIndex;
			if( selected >= 0 )
			{
				DialogResult = System.Windows.Forms.DialogResult.OK;
				SessionRow = sessions[selected];
				this.Close();
			}
			else
				MessageBox.Show( "Please select a session first" );
		}

		/// <summary>
		/// Close Session
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button2_Click( object sender, EventArgs e )
		{
			int selected = listBoxSessions.SelectedIndex;
			if( selected >= 0 )
			{
				DialogResult = System.Windows.Forms.DialogResult.Abort;
				SessionRow = sessions[selected];
				listBoxSessions.Items.Clear();
				this.Close();
			}
			else
				MessageBox.Show( "Please select a session to close" );

		}


	}
}
