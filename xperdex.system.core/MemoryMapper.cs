using System;
using System.Collections.Generic;
using System.Text;

namespace xperdex.system.core
{
	class MemoryMapper
	{
		IntPtr i;

		class MemoryInterface
		{
			public const string KERNEL_DLL = "kernel32";			[DllImport( KERNEL_DLL, EntryPoint = "MapViewOfFile" )]


			[DllImport("kernel32.dll", SetLastError = true)]
			static extern IntPtr MapViewOfFile(IntPtr hFileMappingObject,
				   uint dwDesiredAccess, uint dwFileOffsetHigh, uint dwFileOffsetLow,
					IntPtr dwNumberOfBytesToMap);

			[DllImport( "kernel32.dll", SetLastError = true )]
			static extern IntPtr CreateFileMapping( IntPtr hFile,
			   IntPtr lpFileMappingAttributes, PageProtection flProtect, uint dwMaximumSizeHigh,
			   uint dwMaximumSizeLow, string lpName );


			const UInt32 STANDARD_RIGHTS_REQUIRED = 0x000F0000;
			const UInt32 SECTION_QUERY = 0x0001;
			const UInt32 SECTION_MAP_WRITE = 0x0002;
			const UInt32 SECTION_MAP_READ = 0x0004;
			const UInt32 SECTION_MAP_EXECUTE = 0x0008;
			const UInt32 SECTION_EXTEND_SIZE = 0x0010;
			const UInt32 SECTION_ALL_ACCESS = ( STANDARD_RIGHTS_REQUIRED | SECTION_QUERY |
				SECTION_MAP_WRITE |
				SECTION_MAP_READ |
				SECTION_MAP_EXECUTE |
				SECTION_EXTEND_SIZE );
			const UInt32 FILE_MAP_ALL_ACCESS = SECTION_ALL_ACCESS;
			 IntPtr INVALID_HANDLE_VALUE = (IntPtr)-1;
			private IntPtr hHandle;
			private IntPtr pBuffer;

			[Flags]
			enum PageProtection : uint
			{
				NoAccess = 0x01,
				Readonly = 0x02,
				ReadWrite = 0x04,
				WriteCopy = 0x08,
				Execute = 0x10,
				ExecuteRead = 0x20,
				ExecuteReadWrite = 0x40,
				ExecuteWriteCopy = 0x80,
				Guard = 0x100,
				NoCache = 0x200,
				WriteCombine = 0x400,
			}

			[DllImport( "kernel32.dll", SetLastError = true )]
			static extern IntPtr OpenFileMapping( uint dwDesiredAccess, bool bInheritHandle,
			   string lpName );


			unsafe public void Something( string region )
			{
				UInt32 size;
				IntPtr hMem = CreateFileMapping( INVALID_HANDLE_VALUE, 0, PageProtection.ReadWrite, 0, &size );
			}

			unsafe public void Attach( string SharedMemoryName, UInt32 NumBytes )
			{
				if( IntPtr.Zero != hHandle ) return;
				hHandle = OpenFileMapping( FILE_MAP_ALL_ACCESS, false, SharedMemoryName );
				if( IntPtr.Zero == hHandle ) return;
				pBuffer = MapViewOfFile( hHandle, FILE_MAP_ALL_ACCESS, 0, 0, &NumBytes );
			}

			public void Detach()
			{
				if( IntPtr.Zero != hHandle )
				{
					CloseHandle( hHandle ); //fair to leak if can't close
					hHandle = IntPtr.Zero;
				}
				pBuffer = IntPtr.Zero;
				lBufferSize = 0;
			}


		}
	}
}
