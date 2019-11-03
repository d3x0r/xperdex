using System;
using System.Collections.Generic;
using System.Text;

namespace oolite_tracker
{
    public class PriceEntry
    {
        public double value;
        public PriceEntry(double x)
        {
            value = x;
        }
        public override string ToString()
        {
            return value.ToString();
            return base.ToString();
        }

    }
}
