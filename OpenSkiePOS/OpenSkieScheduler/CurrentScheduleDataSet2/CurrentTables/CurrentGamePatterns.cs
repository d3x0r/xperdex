using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using xperdex.classes;

namespace OpenSkieScheduler3.Relations
{
	public class CurrentGamePatterns : CurrentObjectDataView
	{
		new public static readonly String TableName = CurrentObjectTableView.TableName( GamePatternRelation.TableName );

        public CurrentGamePatterns( )
            : base( null, null )
        {
        }
        public CurrentGamePatterns( DataSet set )
            : base( set, GamePatternRelation.TableName )
        {
        }

	}

}
