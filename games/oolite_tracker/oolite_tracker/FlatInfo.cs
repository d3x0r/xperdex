using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace oolite_tracker
{
    public class FlatInfo : DataColumn
    {
        public FlatInfo(string s)
        {
            this.ColumnName = s;
        }
    }
}
