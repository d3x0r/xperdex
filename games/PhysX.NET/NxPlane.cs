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
	
	
	public class NxPlane : DoxyBindObject
	{
		
		internal NxPlane(IntPtr ptr) : 
				base(ptr)
		{
		}
		
		/// <summary>The normal to the plane. </summary>
		public NxVec3 normal
		{
			get
			{
				NxVec3 value = get_NxPlane_normal_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxPlane_normal_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>The distance from the origin. </summary>
		public float d
		{
			get
			{
				float value = get_NxPlane_d_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxPlane_d_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>Constructor. </summary>
		public NxPlane() : 
				base(new_NxPlane_INVOKE(false))
		{
			GC.ReRegisterForFinalize(this);
		}
		
		/// <summary>Constructor from a normal and a distance. </summary>
		public NxPlane(float nx, float ny, float nz, float _d) : 
				base(new_NxPlane_1_INVOKE(false, nx, ny, nz, _d))
		{
			GC.ReRegisterForFinalize(this);
		}
		
		/// <summary>Constructor from a point on the plane and a normal. </summary>
		public NxPlane(ref NxVec3 p, ref NxVec3 n) : 
				base(new_NxPlane_2_INVOKE(false, p, n))
		{
			GC.ReRegisterForFinalize(this);
		}
		
		/// <summary>Constructor from three points. </summary>
		public NxPlane(ref NxVec3 p0, ref NxVec3 p1, ref NxVec3 p2) : 
				base(new_NxPlane_3_INVOKE(false, p0, p1, p2))
		{
			GC.ReRegisterForFinalize(this);
		}
		
		/// <summary>Constructor from a normal and a distance. </summary>
		public NxPlane(ref NxVec3 _n, float _d) : 
				base(new_NxPlane_4_INVOKE(false, _n, _d))
		{
			GC.ReRegisterForFinalize(this);
		}
		
		/// <summary>Copy constructor. </summary>
		public NxPlane(NxPlane plane) : 
				base(new_NxPlane_5_INVOKE(false, (plane!=null ? plane.ClassPointer : NullRef)))
		{
			GC.ReRegisterForFinalize(this);
		}
		
		/// <summary>Sets plane to zero. </summary>
		public NxPlane zero()
		{
			return NxPlane.GetClass(NxPlane_zero_INVOKE(ClassPointer, doSetFunctionPointers));
		}
		
		/// <summary></summary>
		public NxPlane set(float nx, float ny, float nz, float _d)
		{
			return NxPlane.GetClass(NxPlane_set_INVOKE(ClassPointer, doSetFunctionPointers, nx, ny, nz, _d));
		}
		
		/// <summary></summary>
		public NxPlane set(ref NxVec3 _normal, float _d)
		{
			return NxPlane.GetClass(NxPlane_set_1_INVOKE(ClassPointer, doSetFunctionPointers, ref _normal, _d));
		}
		
		/// <summary></summary>
		public NxPlane set(ref NxVec3 p, ref NxVec3 _n)
		{
			return NxPlane.GetClass(NxPlane_set_2_INVOKE(ClassPointer, doSetFunctionPointers, ref p, ref _n));
		}
		
		/// <summary>Computes the plane equation from 3 points. </summary>
		public NxPlane set(ref NxVec3 p0, ref NxVec3 p1, ref NxVec3 p2)
		{
			return NxPlane.GetClass(NxPlane_set_3_INVOKE(ClassPointer, doSetFunctionPointers, ref p0, ref p1, ref p2));
		}
		
		/// <summary></summary>
		public float distance(ref NxVec3 p)
		{
			return NxPlane_distance_INVOKE(ClassPointer, doSetFunctionPointers, ref p);
		}
		
		/// <summary></summary>
		public bool belongs(ref NxVec3 p)
		{
			return NxPlane_belongs_INVOKE(ClassPointer, doSetFunctionPointers, ref p);
		}
		
		/// <summary>projects p into the plane </summary>
		public NxVec3 project(ref NxVec3 p)
		{
			return NxPlane_project_INVOKE(ClassPointer, doSetFunctionPointers, ref p);
		}
		
		/// <summary>find an arbitrary point in the plane </summary>
		public NxVec3 pointInPlane()
		{
			return NxPlane_pointInPlane_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		/// <summary></summary>
		public void normalize()
		{
			NxPlane_normalize_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		/// <summary></summary>
		public void transform(ref NxMat34 transform, NxPlane transformed)
		{
			NxPlane_transform_INVOKE(ClassPointer, doSetFunctionPointers, ref transform, (transformed!=null ? transformed.ClassPointer : NullRef));
		}
		
		/// <summary></summary>
		public void inverseTransform(ref NxMat34 transform, NxPlane transformed)
		{
			NxPlane_inverseTransform_INVOKE(ClassPointer, doSetFunctionPointers, ref transform, (transformed!=null ? transformed.ClassPointer : NullRef));
		}
		
		#region Imports
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxPlane_normal")]
        private extern static void set_NxPlane_normal_INVOKE (HandleRef classPointer, NxVec3 newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxPlane_normal")]
        private extern static NxVec3 get_NxPlane_normal_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxPlane_d")]
        private extern static void set_NxPlane_d_INVOKE (HandleRef classPointer, System.Single newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxPlane_d")]
        private extern static System.Single get_NxPlane_d_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="new_NxPlane")]
        private extern static IntPtr new_NxPlane_INVOKE (System.Boolean do_override);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="new_NxPlane_1")]
        private extern static IntPtr new_NxPlane_1_INVOKE (System.Boolean do_override, System.Single nx, System.Single ny, System.Single nz, System.Single _d);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="new_NxPlane_2")]
        private extern static IntPtr new_NxPlane_2_INVOKE (System.Boolean do_override, NxVec3 p, NxVec3 n);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="new_NxPlane_3")]
        private extern static IntPtr new_NxPlane_3_INVOKE (System.Boolean do_override, NxVec3 p0, NxVec3 p1, NxVec3 p2);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="new_NxPlane_4")]
        private extern static IntPtr new_NxPlane_4_INVOKE (System.Boolean do_override, NxVec3 _n, System.Single _d);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="new_NxPlane_5")]
        private extern static IntPtr new_NxPlane_5_INVOKE (System.Boolean do_override, HandleRef plane);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxPlane_zero")]
        private extern static IntPtr NxPlane_zero_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxPlane_set")]
        private extern static IntPtr NxPlane_set_INVOKE (HandleRef classPointer, System.Boolean call_explicit, System.Single nx, System.Single ny, System.Single nz, System.Single _d);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxPlane_set_1")]
        private extern static IntPtr NxPlane_set_1_INVOKE (HandleRef classPointer, System.Boolean call_explicit, [In()] ref NxVec3 _normal, System.Single _d);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxPlane_set_2")]
        private extern static IntPtr NxPlane_set_2_INVOKE (HandleRef classPointer, System.Boolean call_explicit, [In()] ref NxVec3 p, [In()] ref NxVec3 _n);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxPlane_set_3")]
        private extern static IntPtr NxPlane_set_3_INVOKE (HandleRef classPointer, System.Boolean call_explicit, [In()] ref NxVec3 p0, [In()] ref NxVec3 p1, [In()] ref NxVec3 p2);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxPlane_distance")]
        private extern static System.Single NxPlane_distance_INVOKE (HandleRef classPointer, System.Boolean call_explicit, [In()] ref NxVec3 p);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxPlane_belongs")]
        private extern static System.Boolean NxPlane_belongs_INVOKE (HandleRef classPointer, System.Boolean call_explicit, [In()] ref NxVec3 p);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxPlane_project")]
        private extern static NxVec3 NxPlane_project_INVOKE (HandleRef classPointer, System.Boolean call_explicit, [In()] ref NxVec3 p);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxPlane_pointInPlane")]
        private extern static NxVec3 NxPlane_pointInPlane_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxPlane_normalize")]
        private extern static void NxPlane_normalize_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxPlane_transform")]
        private extern static void NxPlane_transform_INVOKE (HandleRef classPointer, System.Boolean call_explicit, [In()] ref NxMat34 transform, HandleRef transformed);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxPlane_inverseTransform")]
        private extern static void NxPlane_inverseTransform_INVOKE (HandleRef classPointer, System.Boolean call_explicit, [In()] ref NxMat34 transform, HandleRef transformed);

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
		
		public static NxPlane GetClass(IntPtr ptr)
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
					return ((NxPlane)(obj.Target));
				}
			}
			return new NxPlane(ptr);
		}
		
		protected override System.Collections.Generic.List<System.IntPtr> CreateFunctionPointers()
		{
			System.Collections.Generic.List<System.IntPtr> list = base.CreateFunctionPointers();
			return list;
		}
	}
}
