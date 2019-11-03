using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace particle_boy
{
	class Program
	{
		static void Main( string[] args )
		{
			Form f = new Form();

			ParticleBoy.BodyViewer c = new ParticleBoy.BodyViewer();
			c.Visible = true;
			c.Dock = DockStyle.Fill;
			f.Controls.Add( c );

			f.ShowDialog();
			//Application.Run( f );
			while( true ) ;

			
		}
	}
}
