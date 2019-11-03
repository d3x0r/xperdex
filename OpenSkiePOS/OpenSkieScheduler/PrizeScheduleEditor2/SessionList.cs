using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using OpenSkieScheduler;

namespace PrizeScheduleEditor
{
    public class SessionList: DataTable
    {
        //public DataTable current_payouts;

        public SessionList()
        {
            this.TableName = "Session List";
            this.Columns.Add( "Name", typeof( string ) );
            this.Columns.Add( "Payouts", typeof( SessionSchedule ) );
            //payouts = new SessionSchedule();
        }
		public void AddSession( SessionInfo session )
        {
			//DataRow[] games = session.Games();
			//foreach( DataRow game in games )
			{
				DataRow dr = this.NewRow();
				dr[0] = (string)session;
				dr[1] = new SessionSchedule( session );
				this.Rows.Add( dr );
				this.AcceptChanges();
			}
        }
    }
}
