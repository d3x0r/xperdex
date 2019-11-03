using System;
using System.Collections.Generic;
using System.Text;
using xperdex.classes;
using xperdex.core.interfaces;

namespace PlayList_Manager
{
	class SavePlaylist : IReflectorButton
	{

		#region IReflectorButton Members

		public bool OnClick()
		{
			Local.WritePlayList();
			return true;
		}

		#endregion
	}
	class TestPlaylist : IReflectorButton
	{

		#region IReflectorButton Members

		public bool OnClick()
		{
			Local.TestPlaylist();
			return true;
		}

		#endregion
	}
}
