using System;
using System.Collections.Generic;
using System.Text;
using xperdex.classes;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;

namespace particle_boy
{
	[ServiceBehavior( InstanceContextMode = InstanceContextMode.Single )]
	class Context : IContext, IDispatchMessageInspector, IClientMessageInspector
	{

		public Context()
		{
			IContext iSelf;
			iSelf = xperdex.classes.UpdateService.EventAnnouncer.StartReceiving<Context, IContext>( this );

		}

		#region IContext Members

		void IContext.EventTrigger( DateTime event_time, DateTime client_time, object Event, bool digital )
		{
			//throw new Exception( "The method or operation is not implemented." );
		}

		void IContext.EventTrigger( DateTime event_time, DateTime client_time, object Event, double analog )
		{
			//throw new Exception( "The method or operation is not implemented." );
		}

		void IContext.Move( VectorGeometry.Vector v )
		{
			//throw new Exception( "The method or operation is not implemented." );
		}

		#endregion

		#region IDispatchMessageInspector Members

		object IDispatchMessageInspector.AfterReceiveRequest( ref System.ServiceModel.Channels.Message request, IClientChannel channel, InstanceContext instanceContext )
		{
			//throw new Exception( "The method or operation is not implemented." );
			return null;
		}

		void IDispatchMessageInspector.BeforeSendReply( ref System.ServiceModel.Channels.Message reply, object correlationState )
		{
			//throw new Exception( "The method or operation is not implemented." );
		}

		#endregion

		#region IClientMessageInspector Members

		void IClientMessageInspector.AfterReceiveReply( ref System.ServiceModel.Channels.Message reply, object correlationState )
		{
			//throw new Exception( "The method or operation is not implemented." );
		}

		object IClientMessageInspector.BeforeSendRequest( ref System.ServiceModel.Channels.Message request, IClientChannel channel )
		{
			//throw new Exception( "The method or operation is not implemented." );
			return null;
		}

		#endregion
	}

	struct PossibleEvents
	{
		[FlagsAttribute]
		enum OrdinalDirection{
			Left, UpLeft, Up, UpRight, Right, DownRight, Down, DownLeft
		};

		enum  EventType{
			DigitalInput
			, AnalogInput
			, FrameCorrection
		};
	}

	[ServiceContract]
	public interface IContext
	{
		[OperationContract( IsOneWay = true )]
		void EventTrigger( DateTime event_time, DateTime client_time, object Event, bool digital );
		void EventTrigger( DateTime event_time, DateTime client_time, object Event, double analog );
		//void EventTrigger( DateTime event_time, DateTime client_time, object Event, ContextData context );
		void Move( VectorGeometry.Vector v );
	}

}
