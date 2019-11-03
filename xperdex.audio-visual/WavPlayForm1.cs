//Bill Nolde BillCo Systes 2003
//   billnolde@ieee.org

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Runtime.InteropServices;
using System.Threading;
using System.Collections.Generic;


namespace xperdex.audio_visual
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>

	public static class Sound
	{
		[DllImport( "WinMM.dll" )]
		public static extern bool PlaySound( string szSound, IntPtr hMod, int flags );

		//  flag values for SoundFlags  argument on PlaySound
		public static readonly int SND_SYNC = 0x0000;  // play synchronously (default) 
		public static readonly int SND_ASYNC = 0x0001;  // play asynchronously 
		public static readonly int SND_NODEFAULT = 0x0002;  // silence (!default) if sound not found 
		public static readonly int SND_MEMORY = 0x0004;  // pszSound points to a memory file 
		public static readonly int SND_LOOP = 0x0008;  // loop the sound until next sndPlaySound 
		public static readonly int SND_NOSTOP = 0x0010;  // don't stop any currently playing sound 

		public static readonly int SND_NOWAIT = 0x00002000; // don't wait if the driver is busy 
		public static readonly int SND_ALIAS = 0x00010000; // name is a registry alias 
		public static readonly int SND_ALIAS_ID = 0x00110000; // alias is a predefined ID 
		public static readonly int SND_FILENAME = 0x00020000; // name is file name 
		public static readonly int SND_RESOURCE = 0x00040004; // name is resource name or atom 
		public static readonly int SND_PURGE = 0x0040;  // purge non-static events for task 
		public static readonly int SND_APPLICATION = 0x0080;  // look for application specific association 


		//--------------------------------------------------------------------
		static Sound()
		{
		}

		static Queue<String> play = new Queue<string>();

		static void  thread()
		{
			PlaySound( play.Dequeue(), IntPtr.Zero, SND_FILENAME|SND_ASYNC|SND_NODEFAULT );
		}
		//-------------------------------------------------------------------
		public static void Play( string wfname, int SoundFlags )
		{
			play.Enqueue( wfname );
			Thread Thread = new Thread( thread );
			Thread.Start();
			//PlaySound( wfname, IntPtr.Zero, SoundFlags );
		}
		//--------------------------------------------------------------------
		public static void StopPlay()
		{
			PlaySound( null, IntPtr.Zero, SND_PURGE );
		}
		//----------------------------------------------------------------------
	}   //End WAVSounds class
	//----------------------------------------------------------------------

}		//end name space

