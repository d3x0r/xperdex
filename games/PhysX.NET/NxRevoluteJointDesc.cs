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
	
	
	public class NxRevoluteJointDesc : NxJointDesc
	{
		
		internal NxRevoluteJointDesc(IntPtr ptr) : 
				base(ptr)
		{
		}
		
		/// <summary>Optional limits for the angular motion of the joint. </summary>
		public NxJointLimitPairDesc limit
		{
			get
			{
				return NxJointLimitPairDesc.GetClass(get_NxRevoluteJointDesc_limit_INVOKE(ClassPointer));
			}
			set
			{
				set_NxRevoluteJointDesc_limit_INVOKE(ClassPointer, value.ClassPointer);
			}
		}
		
		/// <summary>Optional motor. </summary>
		public NxMotorDesc motor
		{
			get
			{
				return NxMotorDesc.GetClass(get_NxRevoluteJointDesc_motor_INVOKE(ClassPointer));
			}
			set
			{
				set_NxRevoluteJointDesc_motor_INVOKE(ClassPointer, value.ClassPointer);
			}
		}
		
		/// <summary>Optional spring. </summary>
		public NxSpringDesc spring
		{
			get
			{
				return NxSpringDesc.GetClass(get_NxRevoluteJointDesc_spring_INVOKE(ClassPointer));
			}
			set
			{
				set_NxRevoluteJointDesc_spring_INVOKE(ClassPointer, value.ClassPointer);
			}
		}
		
		/// <summary>The distance beyond which the joint is projected. </summary>
		public float projectionDistance
		{
			get
			{
				float value = get_NxRevoluteJointDesc_projectionDistance_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxRevoluteJointDesc_projectionDistance_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>The angle beyond which the joint is projected. </summary>
		public float projectionAngle
		{
			get
			{
				float value = get_NxRevoluteJointDesc_projectionAngle_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxRevoluteJointDesc_projectionAngle_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>This is a combination of the bits defined by NxRevoluteJointFlag. </summary>
		public uint flags
		{
			get
			{
				uint value = get_NxRevoluteJointDesc_flags_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxRevoluteJointDesc_flags_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>use this to enable joint projection </summary>
		public NxJointProjectionMode projectionMode
		{
			get
			{
				NxJointProjectionMode value = get_NxRevoluteJointDesc_projectionMode_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxRevoluteJointDesc_projectionMode_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>constructor sets to default. </summary>
		public NxRevoluteJointDesc() : 
				base(IntPtr.Zero)
		{
			if ((GetType() != typeof(NxRevoluteJointDesc)))
			{
				doSetFunctionPointers = true;
				SetPointer(new_NxRevoluteJointDesc_INVOKE(doSetFunctionPointers));
				System.IntPtr[] pointers = CreateFunctionPointers().ToArray();
				set_pointers_INVOKE(ClassPointer, pointers, pointers.Length);
			}
			else
			{
				SetPointer(new_NxRevoluteJointDesc_INVOKE(doSetFunctionPointers));
			}
			GC.ReRegisterForFinalize(this);
		}
		
		/// <summary>(re)sets the structure to the default. </summary>
		/// <param name="fromCtor">Avoid redundant work if called from constructor. </param>
		public void setToDefault(bool fromCtor)
		{
			NxRevoluteJointDesc_setToDefault_INVOKE(ClassPointer, doSetFunctionPointers, fromCtor);
		}
		
		/// <summary>Returns true if the descriptor is valid. </summary>
		public override bool isValid()
		{
			return NxRevoluteJointDesc_isValid_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		private bool isValid_virtual()
		{
			return isValid();
		}
		
		delegate bool isValid_0_delegate();
		
		
		
		
		
		
		private isValid_0_delegate isValid_0_delegatefield;
		
		#region Imports
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxRevoluteJointDesc_limit")]
        private extern static void set_NxRevoluteJointDesc_limit_INVOKE (HandleRef classPointer, HandleRef newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxRevoluteJointDesc_limit")]
        private extern static IntPtr get_NxRevoluteJointDesc_limit_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxRevoluteJointDesc_motor")]
        private extern static void set_NxRevoluteJointDesc_motor_INVOKE (HandleRef classPointer, HandleRef newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxRevoluteJointDesc_motor")]
        private extern static IntPtr get_NxRevoluteJointDesc_motor_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxRevoluteJointDesc_spring")]
        private extern static void set_NxRevoluteJointDesc_spring_INVOKE (HandleRef classPointer, HandleRef newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxRevoluteJointDesc_spring")]
        private extern static IntPtr get_NxRevoluteJointDesc_spring_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxRevoluteJointDesc_projectionDistance")]
        private extern static void set_NxRevoluteJointDesc_projectionDistance_INVOKE (HandleRef classPointer, System.Single newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxRevoluteJointDesc_projectionDistance")]
        private extern static System.Single get_NxRevoluteJointDesc_projectionDistance_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxRevoluteJointDesc_projectionAngle")]
        private extern static void set_NxRevoluteJointDesc_projectionAngle_INVOKE (HandleRef classPointer, System.Single newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxRevoluteJointDesc_projectionAngle")]
        private extern static System.Single get_NxRevoluteJointDesc_projectionAngle_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxRevoluteJointDesc_flags")]
        private extern static void set_NxRevoluteJointDesc_flags_INVOKE (HandleRef classPointer, System.UInt32 newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxRevoluteJointDesc_flags")]
        private extern static System.UInt32 get_NxRevoluteJointDesc_flags_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxRevoluteJointDesc_projectionMode")]
        private extern static void set_NxRevoluteJointDesc_projectionMode_INVOKE (HandleRef classPointer, NxJointProjectionMode newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxRevoluteJointDesc_projectionMode")]
        private extern static NxJointProjectionMode get_NxRevoluteJointDesc_projectionMode_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="new_NxRevoluteJointDesc")]
        private extern static IntPtr new_NxRevoluteJointDesc_INVOKE (System.Boolean do_override);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxRevoluteJointDesc_setToDefault")]
        private extern static void NxRevoluteJointDesc_setToDefault_INVOKE (HandleRef classPointer, System.Boolean call_explicit, System.Boolean fromCtor);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxRevoluteJointDesc_isValid")]
        private extern static System.Boolean NxRevoluteJointDesc_isValid_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

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
		
		public static NxRevoluteJointDesc GetClass(IntPtr ptr)
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
					return ((NxRevoluteJointDesc)(obj.Target));
				}
			}
			return new NxRevoluteJointDesc(ptr);
		}
		
		protected override System.Collections.Generic.List<System.IntPtr> CreateFunctionPointers()
		{
			System.Collections.Generic.List<System.IntPtr> list = base.CreateFunctionPointers();
			isValid_0_delegatefield = new isValid_0_delegate(this.isValid_virtual);
			list.Add(Marshal.GetFunctionPointerForDelegate(isValid_0_delegatefield));
			return list;
		}
	}
}
