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
	
	
	public class NxRaycastHit : DoxyBindObject
	{
		
		internal NxRaycastHit(IntPtr ptr) : 
				base(ptr)
		{
		}
		
		/// <summary></summary>
		public NxShape shape
		{
			get
			{
				return NxShape.GetClass(get_NxRaycastHit_shape_INVOKE(ClassPointer));
			}
			set
			{
				set_NxRaycastHit_shape_INVOKE(ClassPointer, value.ClassPointer);
			}
		}
		
		/// <summary></summary>
		public NxVec3 worldImpact
		{
			get
			{
				NxVec3 value = get_NxRaycastHit_worldImpact_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxRaycastHit_worldImpact_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary></summary>
		public NxVec3 worldNormal
		{
			get
			{
				NxVec3 value = get_NxRaycastHit_worldNormal_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxRaycastHit_worldNormal_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary></summary>
		public uint faceID
		{
			get
			{
				uint value = get_NxRaycastHit_faceID_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxRaycastHit_faceID_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary></summary>
		public uint internalFaceID
		{
			get
			{
				uint value = get_NxRaycastHit_internalFaceID_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxRaycastHit_internalFaceID_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary></summary>
		public float distance
		{
			get
			{
				float value = get_NxRaycastHit_distance_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxRaycastHit_distance_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary></summary>
		public float u
		{
			get
			{
				float value = get_NxRaycastHit_u_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxRaycastHit_u_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary></summary>
		public float v
		{
			get
			{
				float value = get_NxRaycastHit_v_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxRaycastHit_v_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary></summary>
		public ushort materialIndex
		{
			get
			{
				ushort value = get_NxRaycastHit_materialIndex_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxRaycastHit_materialIndex_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary></summary>
		public uint flags
		{
			get
			{
				uint value = get_NxRaycastHit_flags_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxRaycastHit_flags_INVOKE(ClassPointer, value);
			}
		}
		
		#region Imports
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxRaycastHit_shape")]
        private extern static void set_NxRaycastHit_shape_INVOKE (HandleRef classPointer, HandleRef newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxRaycastHit_shape")]
        private extern static IntPtr get_NxRaycastHit_shape_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxRaycastHit_worldImpact")]
        private extern static void set_NxRaycastHit_worldImpact_INVOKE (HandleRef classPointer, NxVec3 newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxRaycastHit_worldImpact")]
        private extern static NxVec3 get_NxRaycastHit_worldImpact_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxRaycastHit_worldNormal")]
        private extern static void set_NxRaycastHit_worldNormal_INVOKE (HandleRef classPointer, NxVec3 newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxRaycastHit_worldNormal")]
        private extern static NxVec3 get_NxRaycastHit_worldNormal_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxRaycastHit_faceID")]
        private extern static void set_NxRaycastHit_faceID_INVOKE (HandleRef classPointer, System.UInt32 newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxRaycastHit_faceID")]
        private extern static System.UInt32 get_NxRaycastHit_faceID_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxRaycastHit_internalFaceID")]
        private extern static void set_NxRaycastHit_internalFaceID_INVOKE (HandleRef classPointer, System.UInt32 newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxRaycastHit_internalFaceID")]
        private extern static System.UInt32 get_NxRaycastHit_internalFaceID_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxRaycastHit_distance")]
        private extern static void set_NxRaycastHit_distance_INVOKE (HandleRef classPointer, System.Single newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxRaycastHit_distance")]
        private extern static System.Single get_NxRaycastHit_distance_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxRaycastHit_u")]
        private extern static void set_NxRaycastHit_u_INVOKE (HandleRef classPointer, System.Single newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxRaycastHit_u")]
        private extern static System.Single get_NxRaycastHit_u_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxRaycastHit_v")]
        private extern static void set_NxRaycastHit_v_INVOKE (HandleRef classPointer, System.Single newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxRaycastHit_v")]
        private extern static System.Single get_NxRaycastHit_v_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxRaycastHit_materialIndex")]
        private extern static void set_NxRaycastHit_materialIndex_INVOKE (HandleRef classPointer, System.UInt16 newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxRaycastHit_materialIndex")]
        private extern static System.UInt16 get_NxRaycastHit_materialIndex_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxRaycastHit_flags")]
        private extern static void set_NxRaycastHit_flags_INVOKE (HandleRef classPointer, System.UInt32 newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxRaycastHit_flags")]
        private extern static System.UInt32 get_NxRaycastHit_flags_INVOKE (HandleRef classPointer);

		#endregion
		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="new_NxRaycastHit")]
        private extern static IntPtr new_NxRaycastHit_INVOKE (bool do_override);

		
		public NxRaycastHit() : 
				base(new_NxRaycastHit_INVOKE(false))
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
		
		public static NxRaycastHit GetClass(IntPtr ptr)
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
					return ((NxRaycastHit)(obj.Target));
				}
			}
			return new NxRaycastHit(ptr);
		}
		
		protected override System.Collections.Generic.List<System.IntPtr> CreateFunctionPointers()
		{
			System.Collections.Generic.List<System.IntPtr> list = base.CreateFunctionPointers();
			return list;
		}
	}
}
