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
	
	
	public class NxSpringAndDamperEffectorDesc : NxEffectorDesc
	{
		
		internal NxSpringAndDamperEffectorDesc(IntPtr ptr) : 
				base(ptr)
		{
		}
		
		/// <summary>First attached body. </summary>
		public NxActor body1
		{
			get
			{
				return NxActor.GetClass(get_NxSpringAndDamperEffectorDesc_body1_INVOKE(ClassPointer));
			}
			set
			{
				set_NxSpringAndDamperEffectorDesc_body1_INVOKE(ClassPointer, value.ClassPointer);
			}
		}
		
		/// <summary>Second attached body. </summary>
		public NxActor body2
		{
			get
			{
				return NxActor.GetClass(get_NxSpringAndDamperEffectorDesc_body2_INVOKE(ClassPointer));
			}
			set
			{
				set_NxSpringAndDamperEffectorDesc_body2_INVOKE(ClassPointer, value.ClassPointer);
			}
		}
		
		/// <summary>First attachment point. </summary>
		public NxVec3 pos1
		{
			get
			{
				NxVec3 value = get_NxSpringAndDamperEffectorDesc_pos1_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxSpringAndDamperEffectorDesc_pos1_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>Second attachment point. </summary>
		public NxVec3 pos2
		{
			get
			{
				NxVec3 value = get_NxSpringAndDamperEffectorDesc_pos2_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxSpringAndDamperEffectorDesc_pos2_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>The distance at which the maximum repulsive force is attained (at shorter distances it remains the same). </summary>
		public float springDistCompressSaturate
		{
			get
			{
				float value = get_NxSpringAndDamperEffectorDesc_springDistCompressSaturate_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxSpringAndDamperEffectorDesc_springDistCompressSaturate_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>The distance at which the spring force is zero. </summary>
		public float springDistRelaxed
		{
			get
			{
				float value = get_NxSpringAndDamperEffectorDesc_springDistRelaxed_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxSpringAndDamperEffectorDesc_springDistRelaxed_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>The distance at which the attractive spring force attains its maximum (farther away it remains the same). </summary>
		public float springDistStretchSaturate
		{
			get
			{
				float value = get_NxSpringAndDamperEffectorDesc_springDistStretchSaturate_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxSpringAndDamperEffectorDesc_springDistStretchSaturate_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>The maximum repulsive spring force, attained at distance springDistCompressSaturate. </summary>
		public float springMaxCompressForce
		{
			get
			{
				float value = get_NxSpringAndDamperEffectorDesc_springMaxCompressForce_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxSpringAndDamperEffectorDesc_springMaxCompressForce_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>The maximum attractive spring force, attained at distance springDistStretchSaturate. </summary>
		public float springMaxStretchForce
		{
			get
			{
				float value = get_NxSpringAndDamperEffectorDesc_springMaxStretchForce_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxSpringAndDamperEffectorDesc_springMaxStretchForce_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>The relative velocity (negative) at which the repulsive damping force attains its maximum. </summary>
		public float damperVelCompressSaturate
		{
			get
			{
				float value = get_NxSpringAndDamperEffectorDesc_damperVelCompressSaturate_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxSpringAndDamperEffectorDesc_damperVelCompressSaturate_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>The relative velocity at which the attractive damping force attains its maximum. </summary>
		public float damperVelStretchSaturate
		{
			get
			{
				float value = get_NxSpringAndDamperEffectorDesc_damperVelStretchSaturate_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxSpringAndDamperEffectorDesc_damperVelStretchSaturate_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>The maximum repulsive damping force, attained at relative velocity damperVelCompressSaturate. </summary>
		public float damperMaxCompressForce
		{
			get
			{
				float value = get_NxSpringAndDamperEffectorDesc_damperMaxCompressForce_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxSpringAndDamperEffectorDesc_damperMaxCompressForce_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>The maximum attractive damping force, attained at relative velocity damperVelStretchSaturate. </summary>
		public float damperMaxStretchForce
		{
			get
			{
				float value = get_NxSpringAndDamperEffectorDesc_damperMaxStretchForce_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxSpringAndDamperEffectorDesc_damperMaxStretchForce_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>Constructor sets to default. </summary>
		public NxSpringAndDamperEffectorDesc() : 
				base(IntPtr.Zero)
		{
			if ((GetType() != typeof(NxSpringAndDamperEffectorDesc)))
			{
				doSetFunctionPointers = true;
				SetPointer(new_NxSpringAndDamperEffectorDesc_INVOKE(doSetFunctionPointers));
				System.IntPtr[] pointers = CreateFunctionPointers().ToArray();
				set_pointers_INVOKE(ClassPointer, pointers, pointers.Length);
			}
			else
			{
				SetPointer(new_NxSpringAndDamperEffectorDesc_INVOKE(doSetFunctionPointers));
			}
			GC.ReRegisterForFinalize(this);
		}
		
		/// <summary>(re)sets the structure to the default. </summary>
		public override void setToDefault()
		{
			NxSpringAndDamperEffectorDesc_setToDefault_INVOKE(ClassPointer, doSetFunctionPointers);
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
			return NxSpringAndDamperEffectorDesc_isValid_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		private bool isValid_virtual()
		{
			return isValid();
		}
		
		delegate bool isValid_1_delegate();
		
		
		
		
		
		
		private isValid_1_delegate isValid_1_delegatefield;
		
		#region Imports
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxSpringAndDamperEffectorDesc_body1")]
        private extern static void set_NxSpringAndDamperEffectorDesc_body1_INVOKE (HandleRef classPointer, HandleRef newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxSpringAndDamperEffectorDesc_body1")]
        private extern static IntPtr get_NxSpringAndDamperEffectorDesc_body1_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxSpringAndDamperEffectorDesc_body2")]
        private extern static void set_NxSpringAndDamperEffectorDesc_body2_INVOKE (HandleRef classPointer, HandleRef newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxSpringAndDamperEffectorDesc_body2")]
        private extern static IntPtr get_NxSpringAndDamperEffectorDesc_body2_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxSpringAndDamperEffectorDesc_pos1")]
        private extern static void set_NxSpringAndDamperEffectorDesc_pos1_INVOKE (HandleRef classPointer, NxVec3 newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxSpringAndDamperEffectorDesc_pos1")]
        private extern static NxVec3 get_NxSpringAndDamperEffectorDesc_pos1_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxSpringAndDamperEffectorDesc_pos2")]
        private extern static void set_NxSpringAndDamperEffectorDesc_pos2_INVOKE (HandleRef classPointer, NxVec3 newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxSpringAndDamperEffectorDesc_pos2")]
        private extern static NxVec3 get_NxSpringAndDamperEffectorDesc_pos2_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxSpringAndDamperEffectorDesc_springDistCompressSaturate")]
        private extern static void set_NxSpringAndDamperEffectorDesc_springDistCompressSaturate_INVOKE (HandleRef classPointer, System.Single newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxSpringAndDamperEffectorDesc_springDistCompressSaturate")]
        private extern static System.Single get_NxSpringAndDamperEffectorDesc_springDistCompressSaturate_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxSpringAndDamperEffectorDesc_springDistRelaxed")]
        private extern static void set_NxSpringAndDamperEffectorDesc_springDistRelaxed_INVOKE (HandleRef classPointer, System.Single newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxSpringAndDamperEffectorDesc_springDistRelaxed")]
        private extern static System.Single get_NxSpringAndDamperEffectorDesc_springDistRelaxed_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxSpringAndDamperEffectorDesc_springDistStretchSaturate")]
        private extern static void set_NxSpringAndDamperEffectorDesc_springDistStretchSaturate_INVOKE (HandleRef classPointer, System.Single newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxSpringAndDamperEffectorDesc_springDistStretchSaturate")]
        private extern static System.Single get_NxSpringAndDamperEffectorDesc_springDistStretchSaturate_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxSpringAndDamperEffectorDesc_springMaxCompressForce")]
        private extern static void set_NxSpringAndDamperEffectorDesc_springMaxCompressForce_INVOKE (HandleRef classPointer, System.Single newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxSpringAndDamperEffectorDesc_springMaxCompressForce")]
        private extern static System.Single get_NxSpringAndDamperEffectorDesc_springMaxCompressForce_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxSpringAndDamperEffectorDesc_springMaxStretchForce")]
        private extern static void set_NxSpringAndDamperEffectorDesc_springMaxStretchForce_INVOKE (HandleRef classPointer, System.Single newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxSpringAndDamperEffectorDesc_springMaxStretchForce")]
        private extern static System.Single get_NxSpringAndDamperEffectorDesc_springMaxStretchForce_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxSpringAndDamperEffectorDesc_damperVelCompressSaturate")]
        private extern static void set_NxSpringAndDamperEffectorDesc_damperVelCompressSaturate_INVOKE (HandleRef classPointer, System.Single newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxSpringAndDamperEffectorDesc_damperVelCompressSaturate")]
        private extern static System.Single get_NxSpringAndDamperEffectorDesc_damperVelCompressSaturate_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxSpringAndDamperEffectorDesc_damperVelStretchSaturate")]
        private extern static void set_NxSpringAndDamperEffectorDesc_damperVelStretchSaturate_INVOKE (HandleRef classPointer, System.Single newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxSpringAndDamperEffectorDesc_damperVelStretchSaturate")]
        private extern static System.Single get_NxSpringAndDamperEffectorDesc_damperVelStretchSaturate_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxSpringAndDamperEffectorDesc_damperMaxCompressForce")]
        private extern static void set_NxSpringAndDamperEffectorDesc_damperMaxCompressForce_INVOKE (HandleRef classPointer, System.Single newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxSpringAndDamperEffectorDesc_damperMaxCompressForce")]
        private extern static System.Single get_NxSpringAndDamperEffectorDesc_damperMaxCompressForce_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxSpringAndDamperEffectorDesc_damperMaxStretchForce")]
        private extern static void set_NxSpringAndDamperEffectorDesc_damperMaxStretchForce_INVOKE (HandleRef classPointer, System.Single newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxSpringAndDamperEffectorDesc_damperMaxStretchForce")]
        private extern static System.Single get_NxSpringAndDamperEffectorDesc_damperMaxStretchForce_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="new_NxSpringAndDamperEffectorDesc")]
        private extern static IntPtr new_NxSpringAndDamperEffectorDesc_INVOKE (System.Boolean do_override);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxSpringAndDamperEffectorDesc_setToDefault")]
        private extern static void NxSpringAndDamperEffectorDesc_setToDefault_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxSpringAndDamperEffectorDesc_isValid")]
        private extern static System.Boolean NxSpringAndDamperEffectorDesc_isValid_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

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
		
		public static NxSpringAndDamperEffectorDesc GetClass(IntPtr ptr)
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
					return ((NxSpringAndDamperEffectorDesc)(obj.Target));
				}
			}
			return new NxSpringAndDamperEffectorDesc(ptr);
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
