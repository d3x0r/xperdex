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
	
	
	public class NxExtendedCapsule : NxExtendedSegment
	{
		
		internal NxExtendedCapsule(IntPtr ptr) : 
				base(ptr)
		{
		}
		
		/// <summary></summary>
		public float radius
		{
			get
			{
				float value = get_NxExtendedCapsule_radius_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxExtendedCapsule_radius_INVOKE(ClassPointer, value);
			}
		}
		
		#region Imports
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxExtendedCapsule_radius")]
        private extern static void set_NxExtendedCapsule_radius_INVOKE (HandleRef classPointer, System.Single newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxExtendedCapsule_radius")]
        private extern static System.Single get_NxExtendedCapsule_radius_INVOKE (HandleRef classPointer);

		#endregion
		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="new_NxExtendedCapsule")]
        private extern static IntPtr new_NxExtendedCapsule_INVOKE (bool do_override);

		
		public NxExtendedCapsule() : 
				base(new_NxExtendedCapsule_INVOKE(false))
		{
			GC.ReRegisterForFinalize(this);
		}
		
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
		
		public static NxExtendedCapsule GetClass(IntPtr ptr)
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
					return ((NxExtendedCapsule)(obj.Target));
				}
			}
			return new NxExtendedCapsule(ptr);
		}
		
		protected override System.Collections.Generic.List<System.IntPtr> CreateFunctionPointers()
		{
			System.Collections.Generic.List<System.IntPtr> list = base.CreateFunctionPointers();
			return list;
		}
	}
}
