using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace WebInterfaces
{
	[ServiceContract]
	public interface IBarcodeReceiver
	{
        [OperationContract]
        //[OperationContractAttribute( AsyncPattern = true )]
        bool HandleBarcode( String s );
	}

	public class ClientIBarcodeReceiver : ClientBase<IBarcodeReceiver>, IBarcodeReceiver
	{
		public bool HandleBarcode( string s )
		{
			return base.Channel.HandleBarcode( s );
		}
	}
}
