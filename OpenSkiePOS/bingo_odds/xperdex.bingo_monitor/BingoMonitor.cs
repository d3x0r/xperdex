using System;
using System.Collections.Generic;
using System.Text;
using xperdex.classes;

namespace xperdex.bingo_monitor
{

	class Winners : IReflectorVariable
	{
		#region IReflectorVariable Members

		string IReflectorVariable.Name
		{
			get { return "Winners"; }
		}

		string IReflectorVariable.Text
		{
			get
			{
				return "999";
			}
		}

		#endregion
	}
	class OneAway : IReflectorVariable
	{
		#region IReflectorVariable Members

		string IReflectorVariable.Name
		{
			get { return "1 Away"; }
		}

		string IReflectorVariable.Text
		{
			get
			{
				return "999";
			}
		}

		#endregion
	}
	class TwoAway : IReflectorVariable
	{
		#region IReflectorVariable Members

		string IReflectorVariable.Name
		{
			get { return "2 Away"; }
		}

		string IReflectorVariable.Text
		{
			get
			{
				return "999";
			}
		}

		#endregion
	}
	class ThreeAway : IReflectorVariable
	{
		#region IReflectorVariable Members

		string IReflectorVariable.Name
		{
			get { return "3 Away"; }
		}

		string IReflectorVariable.Text
		{
			get
			{
				return "999";
			}
		}

		#endregion
	}
	class OtherAway : IReflectorVariable
	{
		#region IReflectorVariable Members

		string IReflectorVariable.Name
		{
			get { return "3+ Away"; }
		}

		string IReflectorVariable.Text
		{
			get
			{
				return "999";
			}
		}

		#endregion
	}
	class LoadedUnits : IReflectorVariable
	{
		#region IReflectorVariable Members

		string IReflectorVariable.Name
		{
			get { return "Loaded Units"; }
		}

		string IReflectorVariable.Text
		{
			get
			{
				return "999";
			}
		}

		#endregion
	}
	class PlayingCards : IReflectorVariable
	{
		#region IReflectorVariable Members

		string IReflectorVariable.Name
		{
			get { return "Playing Cards"; }
		}

		string IReflectorVariable.Text
		{
			get
			{
				return "999";
			}
		}

		#endregion
	}


	public class BingoMonitor: IReflectorPlugin, IReflectorPersistance
	{
		#region IReflectorPersistance Members

		bool IReflectorPersistance.Load( System.Xml.XPath.XPathNavigator r )
		{
			//throw new Exception( "The method or operation is not implemented." );
			return false;
		}

		void IReflectorPersistance.Save( System.Xml.XmlWriter w )
		{
			//throw new Exception( "The method or operation is not implemented." );
		}

		void IReflectorPersistance.Properties()
		{	
			//throw new Exception( "The method or operation is not implemented." );
		}

		#endregion

		#region IReflectorPlugin Members

		void IReflectorPlugin.Preload()
		{
			System.Timers.Timer timer = new System.Timers.Timer();
			timer.Elapsed += new System.Timers.ElapsedEventHandler( timer_Elapsed );
			//throw new Exception( "The method or operation is not implemented." );
		}

		void timer_Elapsed( object sender, System.Timers.ElapsedEventArgs e )
		{
			SACK.SQL.SQL.Query( "select count(*) from access_db_sale " +
						"join access_db_packs using (electronic_id) " +
						"where bingoday=now() and session="+ Fortunet.BingoState.GetSessionNumber );


			//throw new Exception( "The method or operation is not implemented." );
		}

		void IReflectorPlugin.FinishInit()
		{
			//throw new Exception( "The method or operation is not implemented." );
		}

		#endregion
	}
}
