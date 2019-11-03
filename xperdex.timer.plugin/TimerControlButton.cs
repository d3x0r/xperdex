using System;
using System.Collections.Generic;
using System.Text;
using xperdex.core.interfaces;

namespace xperdex.timer.plugin
{
	class TimerControlButton : IReflectorButton, IReflectorPersistance
	{
		internal int seconds;
		internal int minutes;
		internal int hours;
		internal bool add;
		internal bool reset_timer;

		#region IReflectorButton Members

		public bool OnClick()
		{
			if( reset_timer )
			{
				Local.span = TimeSpan.Zero;
				xperdex.core.variables.Variables.UpdateVariable( "Initial Time" );
				return true;
			}

			if( add )
			{
				Local.span += TimeSpan.FromSeconds( seconds );
				Local.span += TimeSpan.FromMinutes( minutes );
				Local.span += TimeSpan.FromHours( hours );
			}
			else
			{
				Local.span -= TimeSpan.FromSeconds( seconds );
				Local.span -= TimeSpan.FromMinutes( minutes );
				Local.span -= TimeSpan.FromHours( hours );
			}
			xperdex.core.variables.Variables.UpdateVariable( "Initial Time" );
			return true;
		}

		#endregion

		#region IReflectorPersistance Members

		public bool Load( System.Xml.XPath.XPathNavigator r )
		{
			//throw new NotImplementedException();
			if( r.Name == "timer" )
			{
				if( r.MoveToFirstAttribute() )
				{
					do
					{
						switch( r.Name )
						{
						case "add":
							if( r.Value == "1" )
								add = true;
							else
								add = false;
							break;
						case "hours":
							hours = r.ValueAsInt;
							break;
						case "minutes":
							minutes = r.ValueAsInt;
							break;
						case "seconds":
							seconds = r.ValueAsInt;
							break;
						}
					}
					while( r.MoveToNextAttribute() );
					r.MoveToParent();
				}
				return true;
			}
			return false;
		}

		public void Save( System.Xml.XmlWriter w )
		{
			w.WriteStartElement( "timer" );
			w.WriteAttributeString( "add", add ? "1" : "0" );
			w.WriteAttributeString( "hours", hours.ToString() );
			w.WriteAttributeString( "minutes", minutes.ToString() );
			w.WriteAttributeString( "seconds", seconds.ToString() );
			w.WriteEndElement();
			//throw new NotImplementedException();
		}

		public void Properties()
		{
			TimerButtonEditor tbe = new TimerButtonEditor( this );
			tbe.ShowDialog();
			tbe.Dispose();
		}

		#endregion
	}
}
