using System;
using System.Collections.Generic;
using System.Text;

namespace xperdex.classes
{
    internal class ConfigurationTest
    {
        // this constant list could be a more optimized structure like
        // a tree...
        internal List<ConfigurationElement> pConstElementList;  // list of words which are constant to be checked.
        internal List<ConfigurationElement> pVarElementList;     // list of fields which are variables.
    }
}
