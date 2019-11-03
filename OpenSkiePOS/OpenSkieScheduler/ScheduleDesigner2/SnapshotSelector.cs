using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenSkieScheduler3;
using OpenSkie.Scheduler;
using xperdex.classes;

namespace ScheduleDesigner
{
	public partial class SnapshotSelector : Form
	{
		ScheduleDataSet schedule;
		ScheduleCurrents currents;
		DataView snapshot_sessions;
		internal DataRow result_session;

		public SnapshotSelector( ScheduleCurrents currents )
		{
			this.currents = currents;
			this.schedule = currents.Schedule;

			schedule.Clear();
			this.schedule.snapshot = true;

			try
			{
				DataTable tmp = new SessionTable();
				tmp.Prefix = ( (DataTable)this.schedule.sessions ).Prefix;
				tmp.TableName = ( (DataTable)this.schedule.sessions ).TableName;
				tmp.Columns[SessionTable.NameColumn].Unique = false;
				DsnSQLUtil.FillDataTable( schedule.schedule_dsn, tmp, null, null );
				snapshot_sessions = new DataView( tmp, null, SessionTable.PrimaryKey, DataViewRowState.CurrentRows );

				InitializeComponent();
			}
			catch
			{
				this.schedule.snapshot = false;
			}
		}

		private void SnapshotSelector_Load( object sender, EventArgs e )
		{
			listBox1.DataSource = snapshot_sessions;
		}

		private void buttonCancel_Click( object sender, EventArgs e )
		{
			schedule.snapshot = false;
		}

		private void buttonOk_Click( object sender, EventArgs e )
		{
			DataRowView drv = listBox1.SelectedItem as DataRowView;
			if( drv != null )
				result_session = drv.Row;
		
		}
	}
}
