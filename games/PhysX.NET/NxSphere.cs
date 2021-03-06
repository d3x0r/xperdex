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
	
	
	public class NxSphere : DoxyBindObject
	{
		
		internal NxSphere(IntPtr ptr) : 
				base(ptr)
		{
		}
		
		/// <summary>Sphere's center. </summary>
		public NxVec3 center
		{
			get
			{
				NxVec3 value = get_NxSphere_center_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxSphere_center_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>Sphere's radius. </summary>
		public float radius
		{
			get
			{
				float value = get_NxSphere_radius_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxSphere_radius_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>Constructor. </summary>
		public NxSphere() : 
				base(new_NxSphere_INVOKE(false))
		{
			GC.ReRegisterForFinalize(this);
		}
		
		/// <summary>Constructor. </summary>
		public NxSphere(ref NxVec3 _center, float _radius) : 
				base(new_NxSphere_1_INVOKE(false, _center, _radius))
		{
			GC.ReRegisterForFinalize(this);
		}
		
		/// <summary>Copy constructor. </summary>
		public NxSphere(NxSphere sphere) : 
				base(new_NxSphere_2_INVOKE(false, (sphere!=null ? sphere.ClassPointer : NullRef)))
		{
			GC.ReRegisterForFinalize(this);
		}
		
		/// <summary>Checks the sphere is valid. </summary>
		public bool IsValid()
		{
			return NxSphere_IsValid_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		/// <summary>Tests if a point is contained within the sphere. </summary>
		/// <param name="p">the point to test </param>
		public bool Contains(ref NxVec3 p)
		{
			return NxSphere_Contains_INVOKE(ClassPointer, doSetFunctionPointers, ref p);
		}
		
		/// <summary>Tests if a sphere is contained within the sphere. </summary>
		/// <param name="sphere">[in] the sphere to test </param>
		public bool Contains(NxSphere sphere)
		{
			return NxSphere_Contains_1_INVOKE(ClassPointer, doSetFunctionPointers, (sphere!=null ? sphere.ClassPointer : NullRef));
		}
		
		/// <summary>Tests if a box is contained within the sphere. </summary>
		/// <param name="min">[in] min value of the box </param>
		/// <param name="max">[in] max value of the box </param>
		public bool Contains(ref NxVec3 min, ref NxVec3 max)
		{
			return NxSphere_Contains_2_INVOKE(ClassPointer, doSetFunctionPointers, ref min, ref max);
		}
		
		/// <summary>Tests if the sphere intersects another sphere. </summary>
		/// <param name="sphere">[in] the other sphere </param>
		public bool Intersect(NxSphere sphere)
		{
			return NxSphere_Intersect_INVOKE(ClassPointer, doSetFunctionPointers, (sphere!=null ? sphere.ClassPointer : NullRef));
		}
		
		#region Imports
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxSphere_center")]
        private extern static void set_NxSphere_center_INVOKE (HandleRef classPointer, NxVec3 newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxSphere_center")]
        private extern static NxVec3 get_NxSphere_center_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxSphere_radius")]
        private extern static void set_NxSphere_radius_INVOKE (HandleRef classPointer, System.Single newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxSphere_radius")]
        private extern static System.Single get_NxSphere_radius_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="new_NxSphere")]
        private extern static IntPtr new_NxSphere_INVOKE (System.Boolean do_override);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="new_NxSphere_1")]
        private extern static IntPtr new_NxSphere_1_INVOKE (System.Boolean do_override, NxVec3 _center, System.Single _radius);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="new_NxSphere_2")]
        private extern static IntPtr new_NxSphere_2_INVOKE (System.Boolean do_override, HandleRef sphere);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxSphere_IsValid")]
        private extern static System.Boolean NxSphere_IsValid_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxSphere_Contains")]
        private extern static System.Boolean NxSphere_Contains_INVOKE (HandleRef classPointer, System.Boolean call_explicit, [In()] ref NxVec3 p);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxSphere_Contains_1")]
        private extern static System.Boolean NxSphere_Contains_1_INVOKE (HandleRef classPointer, System.Boolean call_explicit, HandleRef sphere);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxSphere_Contains_2")]
        private extern static System.Boolean NxSphere_Contains_2_INVOKE (HandleRef classPointer, System.Boolean call_explicit, [In()] ref NxVec3 min, [In()] ref NxVec3 max);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxSphere_Intersect")]
        private extern static System.Boolean NxSphere_Intersect_INVOKE (HandleRef classPointer, System.Boolean call_explicit, HandleRef sphere);

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
		
		public static NxSphere GetClass(IntPtr ptr)
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
					return ((NxSphere)(obj.Target));
				}
			}
			return new NxSphere(ptr);
		}
		
		protected override System.Collections.Generic.List<System.IntPtr> CreateFunctionPointers()
		{
			System.Collections.Generic.List<System.IntPtr> list = base.CreateFunctionPointers();
			return list;
		}
	}
}
