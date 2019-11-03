#define use_p2p_events

#if use_p2p_events
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


/// these are for the peer service itself.
using System.ServiceModel;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.PeerResolvers;
using System.Windows.Forms;

namespace xperdex.classes.UpdateService
{
	//[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
	public class EventAnnouncer
	{
		#region prototype_service

		[ServiceContract]
		public interface IEventNotice
		{
			[OperationContract( IsOneWay = true )]
			void Trigger( String opearation );
		}

		[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
		public class EventHandler : IEventNotice
		{  
			// method to be invoked upon receipt of a message
			public void Trigger(String stream) 
			{
				// get the image
				Log.log( "Recevied notice " + stream );
			}

		}

		#endregion

		//static internal EventAnnouncer myself;
		// host the receiver
		static List<ServiceHost> host = new List<ServiceHost>();
					 
			
		static  EventAnnouncer() 
		{
			//myself = new EventAnnouncer();
			//StartReceiving<EventHandler,IEventNotice>();
		}

		static bool failed;
		public static I StartReceiving<T, I>( object singleton ) where T : new()
		{
			return DoStartReceiving<T, I>( singleton, null );
		}

		static I		DoStartReceiving<T, I>( object singleton, String event_namespace ) where T : new() 
		{
			// define the meshname and set up the peer binding
			// with the PNRP resolver
			if( failed )
				return default( I );
			try
			{
				Uri meshAddress = new Uri( "net.p2p://xperdex.classes.events" + (event_namespace!=null?("."+event_namespace):"") );
				//EndpointAddress mesh = new EndpointAddress( meshAddress );
				NetPeerTcpBinding binding = new NetPeerTcpBinding();
				binding.Resolver.Mode = PeerResolverMode.Pnrp;
				binding.Security.Transport.CredentialType =	PeerTransportCredentialType.Password;
				binding.MaxReceivedMessageSize = 16384L;
				binding.Namespace = "http://xperdex.d3x0r.org";

				int index = 0;
				bool found = false;
				foreach( ServiceHost h in host )
				{
					if( h.SingletonInstance.GetType().Equals( singleton ) )
					{
						index = host.IndexOf( h );
						found = true;
					}
				}
				if( !found )
					host.Insert( 0, new ServiceHost( singleton ) );

				// here this connect is actually done.
				host[index].AddServiceEndpoint( typeof( I ), binding, meshAddress );

				// define the password and get a cert for digsig
				host[index].Credentials.Peer.MeshPassword = "SecureWithThisPassword";
				//host.Credentials.Peer.Certificate = GetCertificate();
				// attempt to join and listen for messages
				host[index].Open();

				// this was part of the classes's data...
				ChannelFactory<I> channelFactory;
				channelFactory = new ChannelFactory<I>( binding, new EndpointAddress( meshAddress ) );
				//channelFactory.
				channelFactory.Credentials.Peer.MeshPassword = "SecureWithPassword";
				//channelFactory.Credentials.Peer.Certificate = GetCertificate();
				I _transmit = channelFactory.CreateChannel();

				return _transmit;
			}
			catch( CommunicationException ce )
			{
				failed = true;
			}
			catch
			{
				failed = true;
				//MessageBox.Show( "Failed to register with WCF P2P services." );
			}
			return default(I);
		}

		public static I StartReceiving<T, I>( object singleton, String event_namespace ) where T : new()
		{
			return DoStartReceiving<T, I>( singleton, event_namespace );
		}
	}					  
}
#endif
