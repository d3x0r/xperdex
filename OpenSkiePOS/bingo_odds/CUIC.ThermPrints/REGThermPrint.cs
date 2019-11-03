using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CUIC.ThermPrints
{
	public class REGThermPrint
	{
		const uint GENERIC_READ = 0x80000000;
		const uint GENERIC_WRITE = 0x40000000;
		const uint CREATE_ALWAYS = 2;
		const uint OPEN_EXISTING = 3;
		const uint FILE_SHARE_READ = 0x00000001;
		const uint FILE_FLAG_BACKUP_SEMANTICS = 0x02000000;
		//static IntPtr INVALID_HANDLE = new IntPtr(-1);
		const uint ERROR_SHARING_VIOLATION = 32;
		const uint ERROR_ACCESS_DENIED = 5;

		[System.Runtime.InteropServices.DllImport("kernel32", SetLastError = true)]
		static extern Microsoft.Win32.SafeHandles.SafeFileHandle CreateFile
		(
			string FileName,          // file name
			uint DesiredAccess,       // access mode
			uint ShareMode,           // share mode
			uint SecurityAttributes,  // Security Attributes
			uint CreationDisposition, // how to create
			uint FlagsAndAttributes,  // file attributes
			int hTemplateFile         // handle to template file
		);

		private Microsoft.Win32.SafeHandles.SafeFileHandle LPT_Handle;

		//private CORE.Internal.Config aConfig = CORE.Internal.Config.GetConfig();
		private string _port = "lpt1";

		public string Port
		{
			get { return _port; }
			set { _port = value; }
		}
		public void PrintString(string FinalString)
		{
			//Get the file handle for the printer port

			//LPT_Handle = CreateFile(aConfig.Hardware_Settings.LPT_Port, GENERIC_WRITE, 0, 0, OPEN_EXISTING, 0, 0);
			LPT_Handle = CreateFile(_port, GENERIC_WRITE, 0, 0, OPEN_EXISTING, 0, 0);

			FileStream fs = new FileStream(LPT_Handle, FileAccess.Write);
			StreamWriter sw = new StreamWriter(fs);

			sw.WriteLine(FinalString);

			sw.Close();
			fs.Close(); //If error occurs during high speed print remove me
			LPT_Handle.Close(); //If error occurs during high speed print remove me
		}


		public string GetStringFile(string p_file)
		{
			StreamReader re = File.OpenText(p_file);
			string text = null;
			string input = null;
			while ((input = re.ReadLine()) != null)
			{
				text = text + input;
			}
			re.Close();
			return text;
		}

		public void PrintFile(string p_file)
		{
			PrintString(GetStringFile(p_file));
			//Print("1b;61;6;1b;64;0");
		}
	}
}