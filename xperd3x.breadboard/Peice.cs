using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace xperd3x.breadboard
{
	public abstract class Peice
	{
		public Peice()
		{
			// wow.
		}

		public Board Board;

		//public abstract static Type[] RequiredParents();

		delegate void Save();
		event Save OnSave;
		delegate void Load();
		event Load OnLoad;

		public delegate void Move();
		public event Move OnMove;
		public delegate int Click( Int32 x, Int32 y );
		public event Click OnClick;
		public delegate int RightClick( Int32 x, Int32 y );
		public event RightClick OnRightClick;
		public delegate int DoubleClick( Int32 x, Int32 y );
		public event DoubleClick OnDoubleClick;
		public delegate int ContextClick( Int32 x, Int32 y );
		public event ContextClick OnContextClick;

		//delegate void Update();
		//event Update OnUpdate();

		public delegate void DoDraw( Graphics surface, long x, long y, int s );
		public event DoDraw OnDraw;
		public void Draw( Graphics surface, long x, long y, int s )
		{
			if( OnDraw != null )
				OnDraw( surface, x, y, s );
		}

		public abstract Size Size { get; }


	}
}
