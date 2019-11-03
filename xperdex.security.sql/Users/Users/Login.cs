using System;
using System.Collections.Generic;
using System.Text;

namespace Fortunet.Users
{
	public class Login
	{
		DateTime login;
		DateTime logout;
		long login_id;
		long user_id;
		long program_id = GDAL.Environment.ProgramID;
		long system_id = GDAL.Environment.SystemID;
		Login parent;

		public Login( Login parent )
		{
			this.parent = parent;
		}

		public Login()
		{
		}
		//GetOptionINt( "ftnsys/bingo/hall_id" );
		//"ftnsys/bingo/chairty_id"
	}
}
