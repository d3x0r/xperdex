using System;
using System.Collections.Generic;
using System.Text;
using xperdex.classes;
using xperdex.core;
using sack.sql;
namespace HotballChooser
{
	internal class StaticLocal: IReflectorPlugin
	{
		static sack.sql.SQL sql;
		internal static String[] hotballs;
		internal static List<BallSelectButton> BallSelectors;
		internal static List<RowSelectButton> RowSelectors;
		static bool _selecting;
		internal static bool selecting
		{
			set
			{
				_selecting = value;
				if( value )
				{
					foreach( BallSelectButton bs in BallSelectors )
					{
						bs.Show();
					}
				}
				else
				{
					foreach( BallSelectButton bs in BallSelectors )
					{
						bs.Hide();
					}
					foreach( RowSelectButton bs in RowSelectors )
					{
						bs.Hide();
					}
					{
						bool first = true;
						StringBuilder sb = new StringBuilder();
						//Fortunet.BingoState.ClearHotballs();
						sb.Append( "delete from current_hotballs" );
						sql.command( sb.ToString() );
						sb.Length = 0;
						sb.Append( "insert into current_hotballs (b,i,n,g,o) values (" );
						foreach( String s in hotballs )
						{
							if( !first )
								sb.Append( "," );
							sb.Append( s );
							first = false;
							//Fortunet.BingoState.AddHotball( Convert.ToInt32( s ) );
						}
						sb.Append( ")" );
						sql.command( sb.ToString() );
					}

				}
			}
			get
			{
				return _selecting;
			}
		}
		internal static int selectbase; // base number to select number from... 1, 16, 31, etc...
		static StaticLocal()
		{
			BallSelectors = new List<BallSelectButton>();
			RowSelectors = new List<RowSelectButton>();

			hotballs = new string[5];
		}

		public override string ToString()
		{
			return "Hotball Chooser";
		}

		#region IReflectorPlugin Members

		void IReflectorPlugin.Preload()
		{
			xperdex.core.variables.Variables.AddVariableInterface( "Hotball 1", new HotballVariable( 0 ) );
			xperdex.core.variables.Variables.AddVariableInterface( "Hotball 2", new HotballVariable( 1 ) );
			xperdex.core.variables.Variables.AddVariableInterface( "Hotball 3", new HotballVariable( 2 ) );
			xperdex.core.variables.Variables.AddVariableInterface( "Hotball 4", new HotballVariable( 3 ) );
			xperdex.core.variables.Variables.AddVariableInterface( "Hotball 5", new HotballVariable( 4 ) );
			sql = new SQL( "5line.db" );

			String[] results = sql.query( "select b,i,n,g,o from current_hotballs" );
			if( results.Length == 0 )
			{
				results = new string[5];
				results[0] = "12";
				results[1] = "21";
				results[2] = "41";
				results[3] = "53";
				results[4] = "73";
				hotballs = results;
				selecting = false; // commit current hotball values...
			}
			else
				hotballs = results;
			sql.end_query();			
			//throw new Exception( "The method or operation is not implemented." );
		}

		void IReflectorPlugin.FinishInit()
		{
			//throw new Exception( "The method or operation is not implemented." );
		}

		#endregion
	}
	class HotballVariable : IReflectorVariable
	{
		int ID;

		internal HotballVariable( int ID )
		{
			this.ID = ID;
		}
		#region IReflectorVariable Members

		string IReflectorVariable.Name
		{
			get { return "Hotball " + (ID+1); }
		}

		string IReflectorVariable.Text
		{
			get { return StaticLocal.hotballs[ID]; }
		}

		#endregion
	}
}
