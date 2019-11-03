using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using xperdex.classes;

namespace OpenSkieScheduler3.Relations
{
    public class CurrentSessionPackOrder : CurrentObjectDataView
    {
		new public static readonly String TableName = CurrentObjectTableView.TableName( SessionPack.TableName );

        public CurrentSessionPackOrder()
			: base( null, SessionPack.TableName )
        {
        }
        public CurrentSessionPackOrder( DataSet set )
			: base( set, SessionPack.TableName, true )
        {
        }
	}
}
