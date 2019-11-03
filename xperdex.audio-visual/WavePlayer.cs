using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xperdex.classes;

namespace xperdex.audio_visual
{
	class WavePlayer : IReflectorButton, IReflectorPersistance
	{

		internal String SoundFile;
		
		#region IReflectorButton Members

		public bool OnClick()
		{
			Sound.Play( SoundFile, Sound.SND_ASYNC|Sound.SND_FILENAME|Sound.SND_NODEFAULT );
			return true;
		}

		#endregion

		#region IReflectorPersistance Members

		public bool Load( System.Xml.XPath.XPathNavigator r )
		{
			if( r.Name == "playsound_file" )
			{
				SoundFile = r.Value;
				return true;
			}
			return false;
		}

		public void Save( System.Xml.XmlWriter w )
		{
			w.WriteElementString( "playsound_file", SoundFile );
		}

		public void Properties()
		{
			//throw new NotImplementedException();
		}

		#endregion

	}
}
