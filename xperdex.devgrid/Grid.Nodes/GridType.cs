using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Grid.Nodes
{
    class GridType : IUsageStats
    {
        public virtual static void Init( object o )
        {

        }

        public enum Classification{         primative, complex        }
        public enum Visibility        {            common, rare        }

        protected List<GridMethod> methods;

        int  IUsageStats.Uses()
        {
 	        throw new NotImplementedException();
        }

    }
}
