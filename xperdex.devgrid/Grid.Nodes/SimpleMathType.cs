using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Grid.Nodes
{
    /// <summary>
    /// Responsible for setting up a GridType which represents simple mathematic variables.
    /// </summary>
    internal class SimpleMathType: GridType
    {

        static bool operator_plus( object[] parameters )
        {

            return false;
        }

        public static override void  Init(  object o )
        {
            SimpleMathType m = o as SimpleMathType;
 	         Init( o );
             m.methods.Add( new GridMethod( "+", operator_plus ) );
        }

    }
}
