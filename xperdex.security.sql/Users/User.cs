using System;
using System.Collections.Generic;
using System.Text;
using Fortunet.Users;
using xperdex.classes;
using xperdex.dataset.users;
using System.Data;

namespace xperdex.dataset
{
	public class Users
	{
		//Queue<Login> logins2;
		Stack<Login> logins = new Stack<Login>();
		//public DataSet users;

		public Users( DsnConnection dsn )
		{
			users = UserDataSet.BuildDataSet( dsn, new DataSet() );
		}

		public Login Login
		{
			get
			{
				return logins.Peek();
			}
		}

		/// <summary>
		/// check to see if the currently logged in user has the token
		/// If the user does not, prompt for a new user login.
		/// If the user selected on the new login does not have it, close the temp login, and return false;
		/// </summary>
		/// <param name="Token">String that is the token name requested</param>
		/// <returns>True if user has the token</returns>
		bool AquireToken( string Token )
		{
			return false;	
		}

		bool HasToken( string Token )
		{
			return false;
		}

		void DisposeToken( string Token )
		{

		}
	}
}
