using System;
using System.Collections.Generic;
using System.Text;
using xperdex.classes;
//using System.Data.Odbc;
using System.Data.Common;

namespace xperdex.security.sql
{
	public class SQLSecurity : IReflectorSecurity, IReflectorPersistance
	{

		internal class SecurityTracker
		{
			// heh - inherit 'object' and this is the thing being secured LOL
			internal object secure_this;

			internal List<String> tokens;
			public SecurityTracker( Object o )
			{
				secure_this = o;
				tokens = new List<string>();

			}
		}

		List<String> tokens;
		SecurityTracker tracker;

		public SQLSecurity()
		{
			tracker = new SecurityTracker( null );
			//trackers = new List<SecurityTracker>();
			tokens = new List<string>();
			DbDataReader reader = StaticDsnConnection.KindExecuteReader( "select * from permission_tokens" );
			if( reader != null && reader.HasRows )
			{
				while( reader.Read() )
				{
					tokens.Add( (string)reader["name"] );
				}
			}

		}

		public override string ToString()
		{
			return "SQL Security";
			//return base.ToString();
		}

		#region IReflectorSecurity Members


		bool IReflectorSecurity.Open( )
		{
			// if opened, return true.
			return false;
			//throw new Exception( "The method or operation is not implemented." );
		}

		void IReflectorSecurity.Close( )
		{
			//throw new Exception( "The method or operation is not implemented." );
		}

		bool IReflectorSecurity.Test( )
		{
			return true;
			//throw new Exception( "The method or operation is not implemented." );
		}

		SecurityTracker GetSecurityTracker(Object o, bool create)
		{
			return tracker;
		}

		#endregion

		#region IReflectorPersistance Members

		void IReflectorPersistance.Properties( )
		{
			SQLSecurityConfig config = new SQLSecurityConfig( tracker );
			config.ShowDialog();
			if( config.DialogResult == System.Windows.Forms.DialogResult.OK )
			{
				object[] items = new object[config.listBoxAppliedTokens.Items.Count];
				//System.Windows.Forms.ListBox.ObjectCollection x =
				config.listBoxAppliedTokens.Items.CopyTo( items, 0 );
				tracker.tokens.Clear();
				foreach( object obj in items )
					tracker.tokens.Add( obj as string );
			}
			config.Dispose();
		}

		bool IReflectorPersistance.Load( System.Xml.XPath.XPathNavigator r )
		{
			if( tracker == null )
				return false;
			switch( r.Name )
			{
			case "SQL_Security":
				bool everokay = false;
				bool okay;
				for( okay = r.MoveToFirstChild(); okay; okay = r.MoveToNext() )
				{
					everokay = true;
					r.MoveToFirstChild();
					tracker.tokens.Add( r.Value as String );
					r.MoveToParent();
					//r.Get
				}
				if( everokay )
					r.MoveToParent();
				return true;
			}
			//throw new Exception( "The method or operation is not implemented." );
			return false;
		}

		void IReflectorPersistance.Save( System.Xml.XmlWriter w )
		{
			if( tracker == null )
				return;
			w.WriteStartElement( "SQL_Security" );
			foreach( string s in tracker.tokens )
			{
				w.WriteElementString( "Token", s );
			}
			w.WriteEndElement();
			//throw new Exception( "The method or operation is not implemented." );
		}

		#endregion
	}
}
