//using Fortunet.FUT;

namespace xperdex.classes
{
	/// <summary>
	/// Create a New INI file to store or load data
	/// </summary>
	public class IniFile
	{
		public string path;

		/// <summary>
		/// INIFile Constructor.
		/// </summary>
		/// <param name="INIPath"></param>
		public IniFile(string INIPath)
		{
			path = INIPath;
		}
		/// <summary>
		/// Write Data to the INI File
		/// </summary>
		/// <param name="Section"></param>
		/// Section name
		/// <param name="Key"></param>
		/// Key Name
		/// <param name="Value"></param>
		/// Value Name
		public void IniWriteValue(string Section,string Key,string Value)
		{
			INI.File( path )[Section][Key].Value = Value;
		}
		
		/// <summary>
		/// Read Data Value From the Ini File
		/// </summary>
		/// <param name="Section"></param>
		/// <param name="Key"></param>
		/// <param name="Path"></param>
		/// <returns></returns>
		public string IniReadValue(string Section,string Key)
		{
			return INI.File( path )[Section][Key];
		}

		/// <summary>
		/// Write Data to the INI Encripted File
		/// </summary>
		/// <param name="Section"></param>
		/// Section name
		/// <param name="Key"></param>
		/// Key Name
		/// <param name="Value"></param>
		/// Value Name
		public void IniWriteEncValue(string Section, string Key, string Value)
		{
			INI.File( path )[Section][Key].Value = Value;			
		}

		/// <summary>
		/// Read Data Value From the Ini Encripted File
		/// </summary>
		/// <param name="Section"></param>
		/// <param name="Key"></param>
		/// <param name="Path"></param>
		/// <returns></returns>
		public string IniReadEncValue(string Section, string Key, string Default)
		{
			return INI.File( path )[Section][Key, Default];
		}
	}
}
