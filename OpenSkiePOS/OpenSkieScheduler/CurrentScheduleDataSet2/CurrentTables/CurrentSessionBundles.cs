using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace OpenSkieScheduler3.Relations
{

	public class CurrentSessionBundles: CurrentObjectDataView
	{
		new public static readonly String TableName 
			= CurrentObjectTableView.TableName( SessionBundleRelation.TableName );
        public CurrentSessionBundles()
            : base( null, null )
        {
        }
		public CurrentSessionBundles( DataSet set )
			: base( set, SessionBundleRelation.TableName )
		{
		}
	}


	public class CurrentSessionBundlePacks : CurrentObjectDataView
	{
		new public static readonly String TableName 
			= CurrentObjectTableView.TableName( SessionBundlePackRelation.TableName );

		public CurrentSessionBundlePacks()
			: base( null, null )
		{
		}

        public CurrentSessionBundlePacks( DataSet set )
            : base( set, SessionBundlePackRelation.TableName )
        {
        }

	}
}
