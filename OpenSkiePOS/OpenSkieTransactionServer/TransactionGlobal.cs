using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebInterfaces;
using System.ServiceModel;
using System.ServiceModel.Description;
using xperdex.classes;
using System.ServiceModel.Channels;

namespace OpenSkieTransactionServer
{
	class TransactionGlobal
	{
		internal static bool init_trigger;
		internal static TransactionDataset transacion_dataset;

		internal static ServiceHost TransactionInterface;

		internal static List<ClientInfo> clients;
		static ClientInfo GetClient( RemoteEndpointMessageProperty endpoint )
		{
			foreach( ClientInfo client in clients )
			{
				if( client.address == endpoint.Address )
					return client;
			}
			ClientInfo new_client;
			new_client = new ClientInfo();
			new_client.address = endpoint.Address;
			new_client.port = endpoint.Port;
			new_client.identifier = clients.Count + 1;
			clients.Add( new_client );
			return new_client;
		}

		static void InitTransactionInterface()
		{
			transacion_dataset = new TransactionDataset();
			transacion_dataset.Initialize();

			if( TransactionGlobal.TransactionInterface == null )
			{
				string baseaddr = "http://0.0.0.0:8080/TransactionService";
				Uri baseAddress = new Uri( baseaddr );

				TransactionGlobal.TransactionInterface = new ServiceHost( typeof( TransactionGlobal.TransactionServer ), baseAddress );

				// Enable metadata publishing. 
				ServiceMetadataBehavior smb;
				smb = TransactionGlobal.TransactionInterface.Description.Behaviors.Find<ServiceMetadataBehavior>();
				if( smb == null )
					smb = new ServiceMetadataBehavior();
				smb.HttpGetEnabled = true;
				smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
				TransactionGlobal.TransactionInterface.Description.Behaviors.Add( smb );

				TransactionGlobal.TransactionInterface.AddServiceEndpoint( typeof( ITransactionServer ), new BasicHttpBinding(), "" );

				try
				{

					//for some reason a default endpoint does not get created here 
					TransactionGlobal.TransactionInterface.Open();
				}
				catch( Exception e2 )
				{
					Log.log( e2.Message );
					TransactionGlobal.TransactionInterface = null;
				}
			}
		}

		static TransactionGlobal()
		{
			InitTransactionInterface();
		}

		public class TransactionServer : ITransactionServer
		{
			int ITransactionServer.Connect( DateTime bingoday )
			{
				OperationContext context = OperationContext.Current;
				MessageProperties messageProperties = context.IncomingMessageProperties;

				RemoteEndpointMessageProperty endpointProperty =
					messageProperties[RemoteEndpointMessageProperty.Name]
					as RemoteEndpointMessageProperty;

				return transacion_dataset.InitializeClient( endpointProperty.Address, endpointProperty.Port, bingoday );
			}

			bool ITransactionServer.OpenTransaction( int connection_token, out int global_transnum, out int local_transnum )
			{
				return transacion_dataset.GetTransactionNumbers( connection_token, out global_transnum, out local_transnum );
			}

			bool ITransactionServer.CloseTransaction( int connection_token )
			{
				return transacion_dataset.CloseTransaction( connection_token );
			}
		}

	}
}
