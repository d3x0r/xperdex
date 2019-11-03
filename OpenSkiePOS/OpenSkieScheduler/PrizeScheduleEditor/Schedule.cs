using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using OpenSkieScheduler;
using xperdex.classes;

namespace PrizeScheduleEditor
{
	// this is a data table which has data tables embedded in it
	// or at least a view into those tables

    public class SessionSchedule: DataTable
    {
		PrizeLevelNames prize_names;
		DataRow[] prizes;
		DataRow[] games;
		public SessionSchedule( SessionInfo session )
        {
			prize_names = new PrizeLevelNames();
            this.TableName = "Prize Grid";

			this.Columns.Add( "Game", typeof( string ) );

			// cols passed in is the current prize type names....
			prizes = session.Prizes();
			games = session.Games();

			foreach( DataRow col in prizes )
			{
				DataRow row = prize_names[Convert.ToInt64(col["prize_level_id"])];

				this.Columns.Add( new DataColumn((string)row["prize_level_name"], typeof( Money ) ) );
			}
			// games is session_games in session
			foreach( DataRow game in games )
			{
				DataRow dr = this.NewRow();
				dr[0] = (string)game["game_name"];
				//dr[1] = (Money)"1234";
				this.Rows.Add( dr );
			}
            //this.Rows.
            this.AcceptChanges();
            //this.
            //this.Rows[0] = "default";
            //this.Columns.
            //this.Columns.Add("Game 1", typeof(Money));
        }
        public void AddGame( string name )
        {
        }
        public void AddLevel( string name )
        {
        }
        public void SetPayout( string game, string level )
        {
        }
    }
}
