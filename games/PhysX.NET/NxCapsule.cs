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
	
	
	public class NxCapsule : NxSegment
	{
		
		internal NxCapsule(IntPtr ptr) : 
				base(ptr)
		{
		}
		
		/// <summary></summary>
		public float radius
		{
			get
			{
				float value = get_NxCapsule_radius_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxCapsule_radius_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>Constructor. </summary>
		public NxCapsule() : 
				base(new_NxCapsule_INVOKE(false))
		{
			GC.ReRegisterForFinalize(this);
		}
		
		/// <summary>Constructor. </summary>
		/// <param name="seg">Line segment to create capsule from. </param>
		/// <param name="_radius">Radius of the capsule. </param>
		public NxCapsule(NxSegment seg, float _radius) : 
				base(new_NxCapsule_1_INVOKE(false, (seg!=null ? seg.ClassPointer : NullRef), _radius))
		{
			GC.ReRegisterForFinalize(this);
		}
		
		#region Imports
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxCapsule_radius")]
        private extern static void set_NxCapsule_radius_INVOKE (HandleRef classPointer, System.Single newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxCapsule_radius")]
        private extern static System.Single get_NxCapsule_radius_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="new_NxCapsule")]
        private extern static IntPtr new_NxCapsule_INVOKE (System.Boolean do_override);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="new_NxCapsule_1")]
        private extern static IntPtr new_NxCapsule_1_INVOKE (System.Boolean do_override, HandleRef seg, System.Single _radius);

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
		
		public static NxCapsule GetClass(IntPtr ptr)
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
					return ((NxCapsule)(obj.Target));
				}
			}
			return new NxCapsule(ptr);
		}
		
		protected override System.Collections.Generic.List<System.IntPtr> CreateFunctionPointers()
		{
			System.Collections.Generic.List<System.IntPtr> list = base.CreateFunctionPointers();
			return list;
		}
	}
}
