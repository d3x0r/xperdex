using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace OpenSkieScheduler3.Relations
{
	/// <summary>
	/// This is used with games_in_sessions options and 
	/// </summary>
    public class CurrentSessionGames2 : CurrentObjectDataView
    {
        //new public static readonly String TableName = CurrentObjectTableView.TableName( SessionGame.TableName );
        //new public static readonly String NameColumn = Name( TableName );

        public CurrentSessionGames2(): base( null, SessionGame.TableName )
        {
        }
        public CurrentSessionGames2( DataSet set )
            : base( set, SessionGame.TableName )
        {
           
        }
    }

}
