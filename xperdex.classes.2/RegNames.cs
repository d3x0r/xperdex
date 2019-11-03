using System;

namespace xperdex.classes
{
	public static class RegNames
	{
		
		public static string user_prefix = "web_usr_";
		public static string items_prefix = "";
		public static string pps_prefix = "web_pps_";
		public static string web_combo_prefix = "web_combo_";

		public static string session_control_prefix = "";
		public static string session_schedule_prefix = "elec_sch";
		
		// can change 'user_prefix' on CTK.ini file. 
		public static void set_user_prefix()
		{

			string path = Environment.CurrentDirectory + "\\CTK.ini";

			try
			{
				IniFile dnsConfig = new IniFile(path);
				string _userSecurity = dnsConfig.IniReadValue("PREFIX", "UserSecurity");
				if (_userSecurity != null && _userSecurity != "")
					user_prefix = _userSecurity;

			}
			catch (Exception exc)
			{
				Console.WriteLine("Problems Loading Users Prefix:" + exc.Message );
			}
		}
	}
}
