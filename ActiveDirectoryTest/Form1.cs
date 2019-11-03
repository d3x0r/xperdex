using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.DirectoryServices.ActiveDirectory;
using System.DirectoryServices;

namespace ActiveDirectoryTest
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}



		/// <summary>
		/// Method used to create an entry to the AD.
		/// Replace the path, username, and password.
		/// </summary>
		/// <returns>DirectoryEntry</returns>
		public static DirectoryEntry GetDirectoryEntry()
{
DirectoryEntry de = new DirectoryEntry();
de.Path = "LDAP://172.20.2.133/CN=Users;DC=FTNCORP";
de.Username = "FTNCORP\\Cashier1";
de.Password = "password123";
return de;
}

/// <summary>
/// Method used to create an entry to the AD using a secure connection.
/// Replace the path.
/// </summary>
/// <returns>DirectoryEntry</returns>
public static DirectoryEntry GetDirectoryEntrySec()
{
DirectoryEntry de = new DirectoryEntry();
de.Path = "LDAP://192.168.1.1/CN=Users;DC=Yourdomain";
de.AuthenticationType = AuthenticationTypes.Secure;
return de;
}


/// <summary>
/// Method to validate if a user exists in the AD.
/// </summary>
/// <param name="UserName"></param>
/// <returns></returns>
public bool UserExists( DirectoryEntry de, string UserName )
{
	//DirectoryEntry de = ADHelper.GetDirectoryEntry();
	DirectorySearcher deSearch = new DirectorySearcher();
	deSearch.SearchRoot = de;
	deSearch.Filter = "(&(objectClass=user) (cn=" + UserName + "))";
	SearchResultCollection results = deSearch.FindAll();
	if( results.Count == 0 )
	{
		return false;
	}
	else
	{
		return true;
	}
}

		private void button1_Click( object sender, EventArgs e )
		{
			String p2 = "LDAP://172.20.2.133/DC=fortunet;DC=net";
			DirectoryEntry de2 = new DirectoryEntry( p2, "FtnCorp\\cashier1", "password123" );

		DirectorySearcher search = new DirectorySearcher(de2);
		search.Filter = "(objectClass=User)";
  search.PropertiesToLoad.Add("Name");
  search.PropertiesToLoad.Add("displayName");
  //SearchResult result = search.FindOne();
  foreach( SearchResult result in search.FindAll() )
  {
	  DirectoryEntry dirEntry = result.GetDirectoryEntry();
	 foreach( string key in dirEntry.Properties.PropertyNames )
	  {
		  // Each property contains a collection of its own
		  // that may contain multiple values
		  //Console.WriteLine( "DN = " + dirEntry.Properties["distinguishedName"].Value );
		  foreach( object propVal in dirEntry.Properties[key] )
		  {
			  Console.WriteLine( key + " = " + propVal );
		  }
	  }
	  Console.WriteLine( "---------------" );
  }

			//DirectoryEntry de = GetDirectoryEntry();
			//UserExists( de, "whatever" );
			//de.Co
		} 
	}
}