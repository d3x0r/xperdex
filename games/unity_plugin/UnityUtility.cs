using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace org.d3x0r.xperdex.games.unity_plugin
{
	class UnityUtility
	{
		static void SetLayerRecursively( GameObject obj, int newLayer )
		{
			if( null == obj )
			{
				return;
			}

			obj.layer = newLayer;

			foreach( Transform child in obj.transform )
			{
				if( null == child )
				{
					continue;
				}
				SetLayerRecursively( child.gameObject, newLayer );
			}
		}
	}
}
