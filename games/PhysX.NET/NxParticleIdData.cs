//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3053
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Copyright (c) 2007-2008
// Available under the terms of the
// Eclipse Public License with GPL exception
// See enclosed license file for more information
namespace PhysX.NET
{
	using System;
	using System.Runtime.InteropServices;
	
	
	public class NxParticleIdData : DoxyBindObject
	{
		
		internal NxParticleIdData(IntPtr ptr) : 
				base(ptr)
		{
		}
		
		/// <summary>Points to the user-allocated memory holding the number of IDs stored in the buffer. </summary>
		public uint[] numIdsPtr
		{
			get
			{
				uint[] value = get_NxParticleIdData_numIdsPtr_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxParticleIdData_numIdsPtr_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>The pointer to the user-allocated buffer for particle IDs. </summary>
		public uint[] bufferId
		{
			get
			{
				uint[] value = get_NxParticleIdData_bufferId_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxParticleIdData_bufferId_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>The separation (in bytes) between consecutive particle IDs. </summary>
		public uint bufferIdByteStride
		{
			get
			{
				uint value = get_NxParticleIdData_bufferIdByteStride_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxParticleIdData_bufferIdByteStride_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>Possible debug name. The string is not copied by the SDK, only the pointer is stored. </summary>
		public string name
		{
			get
			{
				string value = get_NxParticleIdData_name_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxParticleIdData_name_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>(Re)sets the structure to the default. </summary>
		public void setToDefault()
		{
			NxParticleIdData_setToDefault_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		/// <summary>Returns true if the current settings are valid. </summary>
		public bool isValid()
		{
			return NxParticleIdData_isValid_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		/// <summary>Constructor sets to default. </summary>
		public NxParticleIdData() : 
				base(new_NxParticleIdData_INVOKE(false))
		{
			GC.ReRegisterForFinalize(this);
		}
		
		#region Imports
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxParticleIdData_numIdsPtr")]
        private extern static void set_NxParticleIdData_numIdsPtr_INVOKE (HandleRef classPointer, System.UInt32[] newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxParticleIdData_numIdsPtr")]
        private extern static System.UInt32[] get_NxParticleIdData_numIdsPtr_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxParticleIdData_bufferId")]
        private extern static void set_NxParticleIdData_bufferId_INVOKE (HandleRef classPointer, System.UInt32[] newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxParticleIdData_bufferId")]
        private extern static System.UInt32[] get_NxParticleIdData_bufferId_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxParticleIdData_bufferIdByteStride")]
        private extern static void set_NxParticleIdData_bufferIdByteStride_INVOKE (HandleRef classPointer, System.UInt32 newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxParticleIdData_bufferIdByteStride")]
        private extern static System.UInt32 get_NxParticleIdData_bufferIdByteStride_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxParticleIdData_name")]
        private extern static void set_NxParticleIdData_name_INVOKE (HandleRef classPointer, System.String newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxParticleIdData_name")]
        private extern static System.String get_NxParticleIdData_name_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxParticleIdData_setToDefault")]
        private extern static void NxParticleIdData_setToDefault_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxParticleIdData_isValid")]
        private extern static System.Boolean NxParticleIdData_isValid_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="new_NxParticleIdData")]
        private extern static IntPtr new_NxParticleIdData_INVOKE (System.Boolean do_override);

		#endregion
		
		private static System.Collections.Generic.Dictionary<System.IntPtr, System.WeakReference> database = new System.Collections.Generic.Dictionary<System.IntPtr, System.WeakReference>();
		
		protected override void SetPointer(IntPtr ptr)
		{
			base.SetPointer(ptr);
			database[ptr] = new WeakReference(this);
		}
		
		public override void Dispose()
		{
			database.Remove(ClassPointer.Handle);
			base.Dispose();
		}
		
		public static NxParticleIdData GetClass(IntPtr ptr)
		{
			if ((ptr == IntPtr.Zero))
			{
				return null;
			}
			System.WeakReference obj;
			if (database.TryGetValue(ptr, out obj))
			{
				if (obj.IsAlive)
				{
					return ((NxParticleIdData)(obj.Target));
				}
			}
			return new NxParticleIdData(ptr);
		}
		
		protected override System.Collections.Generic.List<System.IntPtr> CreateFunctionPointers()
		{
			System.Collections.Generic.List<System.IntPtr> list = base.CreateFunctionPointers();
			return list;
		}
	}
}
