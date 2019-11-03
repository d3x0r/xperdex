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
	
	
	public class NxControllerDesc : DoxyBindObject
	{
		
		internal NxControllerDesc(IntPtr ptr) : 
				base(ptr)
		{
		}
		
		/// <summary>The position of the character. </summary>
		public NxExtendedVec3 position
		{
			get
			{
				NxExtendedVec3 value = get_NxControllerDesc_position_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxControllerDesc_position_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>Specifies the 'up' direction. </summary>
		public NxHeightFieldAxis upDirection
		{
			get
			{
				NxHeightFieldAxis value = get_NxControllerDesc_upDirection_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxControllerDesc_upDirection_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>The maximum slope which the character can walk up. </summary>
		public float slopeLimit
		{
			get
			{
				float value = get_NxControllerDesc_slopeLimit_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxControllerDesc_slopeLimit_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>The skin width used by the controller. </summary>
		public float skinWidth
		{
			get
			{
				float value = get_NxControllerDesc_skinWidth_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxControllerDesc_skinWidth_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>Defines the maximum height of an obstacle which the character can climb. </summary>
		public float stepOffset
		{
			get
			{
				float value = get_NxControllerDesc_stepOffset_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxControllerDesc_stepOffset_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>Specifies a user callback interface. </summary>
		public NxUserControllerHitReport callback
		{
			get
			{
				return NxUserControllerHitReport.GetClass(get_NxControllerDesc_callback_INVOKE(ClassPointer));
			}
			set
			{
				set_NxControllerDesc_callback_INVOKE(ClassPointer, value.ClassPointer);
			}
		}
		
		/// <summary>The interaction flag controls if a character controller collides with other controllers. </summary>
		public NxCCTInteractionFlag interactionFlag
		{
			get
			{
				NxCCTInteractionFlag value = get_NxControllerDesc_interactionFlag_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxControllerDesc_interactionFlag_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>User specified data associated with the controller. </summary>
		public System.IntPtr userData
		{
			get
			{
				System.IntPtr value = get_NxControllerDesc_userData_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxControllerDesc_userData_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>constructor sets to default. </summary>
		protected NxControllerDesc(NxControllerType unknown5) : 
				base(IntPtr.Zero)
		{
			if ((GetType() != typeof(NxControllerDesc)))
			{
				doSetFunctionPointers = true;
				SetPointer(new_NxControllerDesc_INVOKE(doSetFunctionPointers, unknown5));
				System.IntPtr[] pointers = CreateFunctionPointers().ToArray();
				set_pointers_INVOKE(ClassPointer, pointers, pointers.Length);
			}
			else
			{
				SetPointer(new_NxControllerDesc_INVOKE(doSetFunctionPointers, unknown5));
			}
			GC.ReRegisterForFinalize(this);
		}
		
		/// <summary>(re)sets the structure to the default. </summary>
		public virtual void setToDefault()
		{
			NxControllerDesc_setToDefault_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		private void setToDefault_virtual()
		{
			setToDefault();
		}
		
		delegate void setToDefault_0_delegate();
		
		
		
		
		
		
		private setToDefault_0_delegate setToDefault_0_delegatefield;
		
		/// <summary>returns true if the current settings are valid </summary>
		public virtual bool isValid()
		{
			return NxControllerDesc_isValid_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		private bool isValid_virtual()
		{
			return isValid();
		}
		
		delegate bool isValid_1_delegate();
		
		
		
		
		
		
		private isValid_1_delegate isValid_1_delegatefield;
		
		/// <summary>Not used. </summary>
		public uint getVersion()
		{
			return NxControllerDesc_getVersion_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		/// <summary>Returns the character controller type. </summary>
		public NxControllerType getType()
		{
			return NxControllerDesc_getType_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		#region Imports
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxControllerDesc_position")]
        private extern static void set_NxControllerDesc_position_INVOKE (HandleRef classPointer, NxExtendedVec3 newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxControllerDesc_position")]
        private extern static NxExtendedVec3 get_NxControllerDesc_position_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxControllerDesc_upDirection")]
        private extern static void set_NxControllerDesc_upDirection_INVOKE (HandleRef classPointer, NxHeightFieldAxis newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxControllerDesc_upDirection")]
        private extern static NxHeightFieldAxis get_NxControllerDesc_upDirection_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxControllerDesc_slopeLimit")]
        private extern static void set_NxControllerDesc_slopeLimit_INVOKE (HandleRef classPointer, System.Single newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxControllerDesc_slopeLimit")]
        private extern static System.Single get_NxControllerDesc_slopeLimit_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxControllerDesc_skinWidth")]
        private extern static void set_NxControllerDesc_skinWidth_INVOKE (HandleRef classPointer, System.Single newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxControllerDesc_skinWidth")]
        private extern static System.Single get_NxControllerDesc_skinWidth_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxControllerDesc_stepOffset")]
        private extern static void set_NxControllerDesc_stepOffset_INVOKE (HandleRef classPointer, System.Single newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxControllerDesc_stepOffset")]
        private extern static System.Single get_NxControllerDesc_stepOffset_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxControllerDesc_callback")]
        private extern static void set_NxControllerDesc_callback_INVOKE (HandleRef classPointer, HandleRef newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxControllerDesc_callback")]
        private extern static IntPtr get_NxControllerDesc_callback_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxControllerDesc_interactionFlag")]
        private extern static void set_NxControllerDesc_interactionFlag_INVOKE (HandleRef classPointer, NxCCTInteractionFlag newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxControllerDesc_interactionFlag")]
        private extern static NxCCTInteractionFlag get_NxControllerDesc_interactionFlag_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxControllerDesc_userData")]
        private extern static void set_NxControllerDesc_userData_INVOKE (HandleRef classPointer, System.IntPtr newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxControllerDesc_userData")]
        private extern static System.IntPtr get_NxControllerDesc_userData_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="new_NxControllerDesc")]
        private extern static IntPtr new_NxControllerDesc_INVOKE (System.Boolean do_override, NxControllerType unknown5);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxControllerDesc_setToDefault")]
        private extern static void NxControllerDesc_setToDefault_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxControllerDesc_isValid")]
        private extern static System.Boolean NxControllerDesc_isValid_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxControllerDesc_getVersion")]
        private extern static System.UInt32 NxControllerDesc_getVersion_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxControllerDesc_getType")]
        private extern static NxControllerType NxControllerDesc_getType_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

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
		
		public static NxControllerDesc GetClass(IntPtr ptr)
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
					return ((NxControllerDesc)(obj.Target));
				}
			}
			return new NxControllerDesc(ptr);
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
