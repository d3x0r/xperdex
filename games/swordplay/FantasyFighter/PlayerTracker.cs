using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using FantasyFighterArena;
using System.Threading;

namespace FantasyFighter
{
	internal class PlayerTracker
	{
		internal ClientPort client;

		internal DataTable ArenaTable;
		internal FantasyArena arena;
		internal FighterState player;


		internal PlayerTracker()
		{
			ArenaTable = new DataTable();
			ArenaTable.Columns.Add( "name", typeof( String ) );
		}

		internal void Wait()
		{
			// throw up the timer, so we can timeout this wait.
			lock( this )
			{
				Monitor.Wait( this );
			}
		}

		internal void Wake()
		{
			Monitor.Pulse( this );
		}
	}
}
