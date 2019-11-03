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
	
	
	public class NxFluidPacketData : DoxyBindObject
	{
		
		internal NxFluidPacketData(IntPtr ptr) : 
				base(ptr)
		{
		}
		
		/// <summary>The pointer to the user-allocated buffer for fluid packets. </summary>
		public NxFluidPacket bufferFluidPackets
		{
			get
			{
				return NxFluidPacket.GetClass(get_NxFluidPacketData_bufferFluidPackets_INVOKE(ClassPointer));
			}
			set
			{
				set_NxFluidPacketData_bufferFluidPackets_INVOKE(ClassPointer, value.ClassPointer);
			}
		}
		
		/// <summary>Points to the user-allocated memory holding the number of packets stored in the buffers. </summary>
		public uint[] numFluidPacketsPtr
		{
			get
			{
				uint[] value = get_NxFluidPacketData_numFluidPacketsPtr_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxFluidPacketData_numFluidPacketsPtr_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>(Re)sets the structure to the default. </summary>
		public void setToDefault()
		{
			NxFluidPacketData_setToDefault_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		/// <summary>Returns true if the current settings are valid. </summary>
		public bool isValid()
		{
			return NxFluidPacketData_isValid_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		/// <summary>Constructor sets to default. </summary>
		public NxFluidPacketData() : 
				base(new_NxFluidPacketData_INVOKE(false))
		{
			GC.ReRegisterForFinalize(this);
		}
		
		#region Imports
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxFluidPacketData_bufferFluidPackets")]
        private extern static void set_NxFluidPacketData_bufferFluidPackets_INVOKE (HandleRef classPointer, HandleRef newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxFluidPacketData_bufferFluidPackets")]
        private extern static IntPtr get_NxFluidPacketData_bufferFluidPackets_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxFluidPacketData_numFluidPacketsPtr")]
        private extern static void set_NxFluidPacketData_numFluidPacketsPtr_INVOKE (HandleRef classPointer, System.UInt32[] newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxFluidPacketData_numFluidPacketsPtr")]
        private extern static System.UInt32[] get_NxFluidPacketData_numFluidPacketsPtr_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxFluidPacketData_setToDefault")]
        private extern static void NxFluidPacketData_setToDefault_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxFluidPacketData_isValid")]
        private extern static System.Boolean NxFluidPacketData_isValid_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="new_NxFluidPacketData")]
        private extern static IntPtr new_NxFluidPacketData_INVOKE (System.Boolean do_override);

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
		
		public static NxFluidPacketData GetClass(IntPtr ptr)
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
					return ((NxFluidPacketData)(obj.Target));
				}
			}
			return new NxFluidPacketData(ptr);
		}
		
		protected override System.Collections.Generic.List<System.IntPtr> CreateFunctionPointers()
		{
			System.Collections.Generic.List<System.IntPtr> list = base.CreateFunctionPointers();
			return list;
		}
	}
}
