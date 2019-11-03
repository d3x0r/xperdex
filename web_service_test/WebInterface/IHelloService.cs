using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace WebInterface
{
	[ServiceContract]
	public interface IHelloWorldService
	{
		[OperationContract]
		string SayHello( string name );
	}

	public class ClientIHelloService : ClientBase<IHelloWorldService>, IHelloWorldService
	{
		public string SayHello( string param )
		{
			return base.Channel.SayHello( param );
		}
	}
}
