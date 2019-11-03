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
	
	
	public class NxPrismaticJointDesc : NxJointDesc
	{
		
		internal NxPrismaticJointDesc(IntPtr ptr) : 
				base(ptr)
		{
		}
		
		/// <summary>Constructor sets to default. </summary>
		public NxPrismaticJointDesc() : 
				base(IntPtr.Zero)
		{
			if ((GetType() != typeof(NxPrismaticJointDesc)))
			{
				doSetFunctionPointers = true;
				SetPointer(new_NxPrismaticJointDesc_INVOKE(doSetFunctionPointers));
				System.IntPtr[] pointers = CreateFunctionPointers().ToArray();
				set_pointers_INVOKE(ClassPointer, pointers, pointers.Length);
			}
			else
			{
				SetPointer(new_NxPrismaticJointDesc_INVOKE(doSetFunctionPointers));
			}
			GC.ReRegisterForFinalize(this);
		}
		
		/// <summary>(re)sets the structure to the default. </summary>
		public override void setToDefault()
		{
			NxPrismaticJointDesc_setToDefault_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		private void setToDefault_virtual()
		{
			setToDefault();
		}
		
		delegate void setToDefault_0_delegate();
		
		
		
		
		
		
		private setToDefault_0_delegate setToDefault_0_delegatefield;
		
		/// <summary>Returns true if the descriptor is valid. </summary>
		public override bool isValid()
		{
			return NxPrismaticJointDesc_isValid_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		private bool isValid_virtual()
		{
			return isValid();
		}
		
		delegate bool isValid_1_delegate();
		
		
		
		
		
		
		private isValid_1_delegate isValid_1_delegatefield;
		
		#region Imports
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="new_NxPrismaticJointDesc")]
        private extern static IntPtr new_NxPrismaticJointDesc_INVOKE (System.Boolean do_override);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxPrismaticJointDesc_setToDefault")]
        private extern static void NxPrismaticJointDesc_setToDefault_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxPrismaticJointDesc_isValid")]
        private extern static System.Boolean NxPrismaticJointDesc_isValid_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

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
		
		public static NxPrismaticJointDesc GetClass(IntPtr ptr)
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
					return ((NxPrismaticJointDesc)(obj.Target));
				}
			}
			return new NxPrismaticJointDesc(ptr);
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
