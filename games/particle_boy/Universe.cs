using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;

namespace particle_boy
{
	[ServiceBehavior( InstanceContextMode = InstanceContextMode.Single )]
	public class Universe: IUniverse
	{
		static List<Entity> Residents;

		Universe()
		{
			Residents = new List<Entity>();
		}

		public static bool Register( Entity entity )
		{
			// invoke other things which the entity may require.
			// this is the first thing done by an entity upon manifestation.

			Residents.Add( entity );

			return true;
		}
	
#region IUniverse Members

		bool IUniverse.Register(string name)
		{
			Entity.Manifest( name );
			return true;
		}

#endregion
	}

	[ServiceContract]
	public interface IUniverse
	{
		[OperationContract( IsOneWay = true )]
		bool Register( String name );
	}
}
