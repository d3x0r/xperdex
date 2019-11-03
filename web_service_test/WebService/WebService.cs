using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using WebInterface;

namespace WebService
{
	public class HelloWorldService : IHelloWorldService
	{
		public string SayHello( string name )
		{
			return string.Format( "Hello, {0}", name );
		}
	} 
 
}
