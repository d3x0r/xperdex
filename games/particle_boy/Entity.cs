using System;
using System.Collections.Generic;
using System.Text;

namespace particle_boy
{
	public class Entity
	{
		String Name;


		//-----------------------------

		public override string ToString()
		{
			return Name;
		}

		//-----------------------------


		Entity( String name )
		{
			Name = name;
		}

		public static Entity Manifest( String name )
		{
			Entity entity;
			
			/* validate trust of name */

			entity = new Entity( name );

			Universe.Register( entity );
			/* Notify Universe of intent to manifest. */

			return entity;
		}
	}
}
