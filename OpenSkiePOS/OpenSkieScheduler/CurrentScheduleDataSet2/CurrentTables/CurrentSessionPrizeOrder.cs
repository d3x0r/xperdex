using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using xperdex.classes;

namespace OpenSkieScheduler3.Relations
{
#if asdfasdf
    public class CurrentSessionPrizeOrder : CurrentObjectDataView
    {
        public CurrentSessionPrizeOrder()
            : base( null, SessionPrizeOrder.TableName )
        {
        }
        public CurrentSessionPrizeOrder( DataSet set )
            : base( set, SessionPrizeOrder.TableName )
        {
        }
    }
#endif
}
