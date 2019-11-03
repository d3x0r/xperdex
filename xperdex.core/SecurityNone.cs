using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xperdex.core.interfaces;

namespace xperdex.core
{
	[SecurityAttribute( Name = "None" )]
	class SecurityNone:IReflectorSecurity
	{
		bool IReflectorSecurity.Open()
		{
			return true;
		}

		void IReflectorSecurity.Close()
		{
			
		}

		bool IReflectorSecurity.Test()
		{
			return true;
		}
	}
}
