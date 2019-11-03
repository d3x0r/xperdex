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
	
	
	public class NxBoxControllerDesc : NxControllerDesc
	{
		
		internal NxBoxControllerDesc(IntPtr ptr) : 
				base(ptr)
		{
		}
		
		/// <summary>The extents of the box controller. </summary>
		public NxVec3 extents
		{
			get
			{
				NxVec3 value = get_NxBoxControllerDesc_extents_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxBoxControllerDesc_extents_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>constructor sets to default. </summary>
		public NxBoxControllerDesc() : 
				base(IntPtr.Zero)
		{
			if ((GetType() != typeof(NxBoxControllerDesc)))
			{
				doSetFunctionPointers = true;
				SetPointer(new_NxBoxControllerDesc_INVOKE(doSetFunctionPointers));
				System.IntPtr[] pointers = CreateFunctionPointers().ToArray();
				set_pointers_INVOKE(ClassPointer, pointers, pointers.Length);
			}
			else
			{
				SetPointer(new_NxBoxControllerDesc_INVOKE(doSetFunctionPointers));
			}
			GC.ReRegisterForFinalize(this);
		}
		
		/// <summary>(re)sets the structure to the default. </summary>
		public override void setToDefault()
		{
			NxBoxControllerDesc_setToDefault_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		private void setToDefault_virtual()
		{
			setToDefault();
		}
		
		delegate void setToDefault_0_delegate();
		
		
		
		
		
		
		private setToDefault_0_delegate setToDefault_0_delegatefield;
		
		/// <summary>returns true if the current settings are valid </summary>
		public override bool isValid()
		{
			return NxBoxControllerDesc_isValid_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		private bool isValid_virtual()
		{
			return isValid();
		}
		
		delegate bool isValid_1_delegate();
		
		
		
		
		
		
		private isValid_1_delegate isValid_1_delegatefield;
		
		#region Imports
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxBoxControllerDesc_extents")]
        private extern static void set_NxBoxControllerDesc_extents_INVOKE (HandleRef classPointer, NxVec3 newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxBoxControllerDesc_extents")]
        private extern static NxVec3 get_NxBoxControllerDesc_extents_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="new_NxBoxControllerDesc")]
        private extern static IntPtr new_NxBoxControllerDesc_INVOKE (System.Boolean do_override);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxBoxControllerDesc_setToDefault")]
        private extern static void NxBoxControllerDesc_setToDefault_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxBoxControllerDesc_isValid")]
        private extern static System.Boolean NxBoxControllerDesc_isValid_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

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
		
		public static NxBoxControllerDesc GetClass(IntPtr ptr)
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
					return ((NxBoxControllerDesc)(obj.Target));
				}
			}
			return new NxBoxControllerDesc(ptr);
		}
		
		protected override System.Collections.Generic.List<System.IntPtr> CreateFunctionPointers()
		{
			System.Collections.Generic.List<System.IntPtr> list = base.CreateFunctionPointers();
			setToDefault_0_delegatefield = new setToDefault_0_delegate(this.setToDefault_virtual);
			list.Add(Marshal.GetFunctionPointerForDelegate(setToDefault_0_delegatefield));
			isValid_1_delegatefield = new isValid_1_delegate(this.isValid_virtual);
			list.Add(Marshal.GetFunctionPointerForDelegate(isValid_1_delegatefield));
			return list;
		}
	}
}
