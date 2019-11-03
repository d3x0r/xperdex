using System;
using System.Collections.Generic;
using System.Text;
using System.Media;
using xperdex.core.interfaces;

namespace xperdex.timer.plugin
{
	internal class Timer : IReflectorPlugin, IReflectorPersistance
	{
		internal static string sound_file = "c:\\windows\\media\\ding.wav";
		internal String name;
		internal DateTime Target;
		internal TimeSpan length;
		internal DateTime start;
		bool alarmed;

		public Timer()
		{
			// paremterless constructor for plugin handle.
		}

		internal String Remaining
		{
			get
			{
				if( Target > DateTime.Now )
				{
					TimeSpan result = ( Target - DateTime.Now );
					if( !alarmed )
						if( result.TotalSeconds < 45 )
						{
							alarmed = true;
							SoundPlayer player = new SoundPlayer( sound_file );
							player.Play();
						}
					result -= TimeSpan.FromMilliseconds( result.Milliseconds );
					return result.ToString();
				}
				else
					return "DONE";
			}
		}

		internal Timer( TimeSpan span )
		{
			start = DateTime.Now;
			length = span;
			Target = start + span;
		}

		static System.Windows.Forms.Timer tick;
		static Timer()
		{
			tick = new System.Windows.Forms.Timer();
			tick.Interval = 1000;
			tick.Tick += new EventHandler( tick_Tick );
			tick.Start();
		}

		static void tick_Tick( object sender, EventArgs e )
		{
			xperdex.core.variables.Variables.UpdateVariable( "Time Remaining" );
		}

		#region IReflectorPlugin Members

		public void Preload()
		{
			
		}

		public void FinishInit()
		{
			
		}

		#endregion

		#region IReflectorPersistance Members

		public bool Load( System.Xml.XPath.XPathNavigator r )
		{
			if( r.Name == "TimerProperties" )
			{
				sound_file = r.Value;
				return true;
			}
			return false;
		}

		public void Save( System.Xml.XmlWriter w )
		{
			w.WriteElementString( "TimerProperties", sound_file );
		}

		public void Properties()
		{
			ConfigureSound cs = new ConfigureSound();
			cs.ShowDialog();
			cs.Dispose();
		}

		#endregion
	}
}
