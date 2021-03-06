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
	
	
	public class NxJointLimitPairDesc : DoxyBindObject
	{
		
		internal NxJointLimitPairDesc(IntPtr ptr) : 
				base(ptr)
		{
		}
		
		/// <summary>The low limit (smaller value). </summary>
		public NxJointLimitDesc low
		{
			get
			{
				return NxJointLimitDesc.GetClass(get_NxJointLimitPairDesc_low_INVOKE(ClassPointer));
			}
			set
			{
				set_NxJointLimitPairDesc_low_INVOKE(ClassPointer, value.ClassPointer);
			}
		}
		
		/// <summary>the high limit (larger value) </summary>
		public NxJointLimitDesc high
		{
			get
			{
				return NxJointLimitDesc.GetClass(get_NxJointLimitPairDesc_high_INVOKE(ClassPointer));
			}
			set
			{
				set_NxJointLimitPairDesc_high_INVOKE(ClassPointer, value.ClassPointer);
			}
		}
		
		/// <summary>Constructor, sets members to default values. </summary>
		public NxJointLimitPairDesc() : 
				base(new_NxJointLimitPairDesc_INVOKE(false))
		{
			GC.ReRegisterForFinalize(this);
		}
		
		/// <summary>Sets members to default values. </summary>
		public void setToDefault()
		{
			NxJointLimitPairDesc_setToDefault_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		/// <summary>Returns true if the descriptor is valid. </summary>
		public bool isValid()
		{
			return NxJointLimitPairDesc_isValid_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		#region Imports
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxJointLimitPairDesc_low")]
        private extern static void set_NxJointLimitPairDesc_low_INVOKE (HandleRef classPointer, HandleRef newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxJointLimitPairDesc_low")]
        private extern static IntPtr get_NxJointLimitPairDesc_low_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxJointLimitPairDesc_high")]
        private extern static void set_NxJointLimitPairDesc_high_INVOKE (HandleRef classPointer, HandleRef newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxJointLimitPairDesc_high")]
        private extern static IntPtr get_NxJointLimitPairDesc_high_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="new_NxJointLimitPairDesc")]
        private extern static IntPtr new_NxJointLimitPairDesc_INVOKE (System.Boolean do_override);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxJointLimitPairDesc_setToDefault")]
        private extern static void NxJointLimitPairDesc_setToDefault_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxJointLimitPairDesc_isValid")]
        private extern static System.Boolean NxJointLimitPairDesc_isValid_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

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
		
		public static NxJointLimitPairDesc GetClass(IntPtr ptr)
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
					return ((NxJointLimitPairDesc)(obj.Target));
				}
			}
			return new NxJointLimitPairDesc(ptr);
		}
		
		protected override System.Collections.Generic.List<System.IntPtr> CreateFunctionPointers()
		{
			System.Collections.Generic.List<System.IntPtr> list = base.CreateFunctionPointers();
			return list;
		}
	}
}
