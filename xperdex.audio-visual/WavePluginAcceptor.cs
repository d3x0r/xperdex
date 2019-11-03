using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xperdex.classes;
using xperdex.core;
using System.Drawing;

namespace xperdex.audio_visual
{
	public class DropAcceptor : IReflectorPluginDropFileTarget
	{

		#region IReflectorPluginDropFileTarget Members

		public bool Drop( object sender, string filename, int X, int Y )
		{
			if( ( filename.IndexOf( ".wav",StringComparison.CurrentCultureIgnoreCase ) == filename.Length - 4 )
				)
			{
				if( local.current_mouse_page == null )
				{

					return false;
				}
				Rectangle r = new Rectangle(
				 local.partX - ( ( local.current_mouse_page.partsX / 10 ) - 1 ) / 2
				, local.partY - ( ( local.current_mouse_page.partsY / 10 ) - 1 ) / 2
				, local.current_mouse_page.partsX / 10
				, local.current_mouse_page.partsY / 10 );
				ControlTracker tracker = local.current_mouse_page.MakeControl( typeof( WavePlayer )
					, typeof( IReflectorButton )
					, r );
				WavePlayer player = tracker.o as WavePlayer;
				player.SoundFile = filename;
				PSI_Button button = tracker.c as PSI_Button;
				button.Text = filename;
				//IReflectorCanvas c = sender as IReflectorCanvas;
				//c.MakeControl( typeof( Task ) );
				return true;
			}
			return false;
		}

		#endregion
	}
}
