
using System;
using System.Collections.Generic;

namespace xperdex.core.common
{
	static class Keypads
	{
		static List<String> keypad_types = new List<string>();
		static List<PSI_Keypad> keypads = new List<PSI_Keypad>();

		public static PSI_Keypad GetKeypad( String name )
		{
			foreach( PSI_Keypad keypad in keypads )
			{
				if( keypad.Name == name )
					return keypad;
			}
			return null;
		}

		public static void RegisterKeypadType( String name )
		{

		}
		public static List<String> KeypadTypes
		{
			get
			{
				return keypad_types;
			}
		}
	}
}
