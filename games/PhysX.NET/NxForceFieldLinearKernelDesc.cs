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
	
	
	public class NxForceFieldLinearKernelDesc : DoxyBindObject
	{
		
		internal NxForceFieldLinearKernelDesc(IntPtr ptr) : 
				base(ptr)
		{
		}
		
		/// <summary>Constant part of force field function. </summary>
		public NxVec3 constant
		{
			get
			{
				NxVec3 value = get_NxForceFieldLinearKernelDesc_constant_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxForceFieldLinearKernelDesc_constant_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>Coefficient of force field function position term. </summary>
		public NxMat33 positionMultiplier
		{
			get
			{
				NxMat33 value = get_NxForceFieldLinearKernelDesc_positionMultiplier_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxForceFieldLinearKernelDesc_positionMultiplier_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>Force field position target. </summary>
		public NxVec3 positionTarget
		{
			get
			{
				NxVec3 value = get_NxForceFieldLinearKernelDesc_positionTarget_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxForceFieldLinearKernelDesc_positionTarget_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>Coefficient of force field function velocity term. </summary>
		public NxMat33 velocityMultiplier
		{
			get
			{
				NxMat33 value = get_NxForceFieldLinearKernelDesc_velocityMultiplier_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxForceFieldLinearKernelDesc_velocityMultiplier_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>Force field velocity target. </summary>
		public NxVec3 velocityTarget
		{
			get
			{
				NxVec3 value = get_NxForceFieldLinearKernelDesc_velocityTarget_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxForceFieldLinearKernelDesc_velocityTarget_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>Radius for NX_FFC_TOROIDAL type coordinates. </summary>
		public float torusRadius
		{
			get
			{
				float value = get_NxForceFieldLinearKernelDesc_torusRadius_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxForceFieldLinearKernelDesc_torusRadius_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>Linear term in magnitude falloff factor. Range (each component): [0, inf). </summary>
		public NxVec3 falloffLinear
		{
			get
			{
				NxVec3 value = get_NxForceFieldLinearKernelDesc_falloffLinear_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxForceFieldLinearKernelDesc_falloffLinear_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>Quadratic term in magnitude falloff factor. Range (each component): [0, inf). </summary>
		public NxVec3 falloffQuadratic
		{
			get
			{
				NxVec3 value = get_NxForceFieldLinearKernelDesc_falloffQuadratic_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxForceFieldLinearKernelDesc_falloffQuadratic_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>Noise scaling. </summary>
		public NxVec3 noise
		{
			get
			{
				NxVec3 value = get_NxForceFieldLinearKernelDesc_noise_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxForceFieldLinearKernelDesc_noise_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>Possible debug name. The string is not copied by the SDK, only the pointer is stored. </summary>
		public string name
		{
			get
			{
				string value = get_NxForceFieldLinearKernelDesc_name_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxForceFieldLinearKernelDesc_name_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>Will be copied to NxForceField::userData. </summary>
		public System.IntPtr userData
		{
			get
			{
				System.IntPtr value = get_NxForceFieldLinearKernelDesc_userData_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxForceFieldLinearKernelDesc_userData_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>Constructor sets to default. </summary>
		public NxForceFieldLinearKernelDesc() : 
				base(new_NxForceFieldLinearKernelDesc_INVOKE(false))
		{
			GC.ReRegisterForFinalize(this);
		}
		
		/// <summary>(re)sets the structure to the default. </summary>
		public void setToDefault()
		{
			NxForceFieldLinearKernelDesc_setToDefault_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		/// <summary>Returns true if the descriptor is valid. </summary>
		public bool isValid()
		{
			return NxForceFieldLinearKernelDesc_isValid_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		#region Imports
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxForceFieldLinearKernelDesc_constant")]
        private extern static void set_NxForceFieldLinearKernelDesc_constant_INVOKE (HandleRef classPointer, NxVec3 newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxForceFieldLinearKernelDesc_constant")]
        private extern static NxVec3 get_NxForceFieldLinearKernelDesc_constant_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxForceFieldLinearKernelDesc_positionMultiplier")]
        private extern static void set_NxForceFieldLinearKernelDesc_positionMultiplier_INVOKE (HandleRef classPointer, NxMat33 newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxForceFieldLinearKernelDesc_positionMultiplier")]
        private extern static NxMat33 get_NxForceFieldLinearKernelDesc_positionMultiplier_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxForceFieldLinearKernelDesc_positionTarget")]
        private extern static void set_NxForceFieldLinearKernelDesc_positionTarget_INVOKE (HandleRef classPointer, NxVec3 newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxForceFieldLinearKernelDesc_positionTarget")]
        private extern static NxVec3 get_NxForceFieldLinearKernelDesc_positionTarget_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxForceFieldLinearKernelDesc_velocityMultiplier")]
        private extern static void set_NxForceFieldLinearKernelDesc_velocityMultiplier_INVOKE (HandleRef classPointer, NxMat33 newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxForceFieldLinearKernelDesc_velocityMultiplier")]
        private extern static NxMat33 get_NxForceFieldLinearKernelDesc_velocityMultiplier_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxForceFieldLinearKernelDesc_velocityTarget")]
        private extern static void set_NxForceFieldLinearKernelDesc_velocityTarget_INVOKE (HandleRef classPointer, NxVec3 newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxForceFieldLinearKernelDesc_velocityTarget")]
        private extern static NxVec3 get_NxForceFieldLinearKernelDesc_velocityTarget_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxForceFieldLinearKernelDesc_torusRadius")]
        private extern static void set_NxForceFieldLinearKernelDesc_torusRadius_INVOKE (HandleRef classPointer, System.Single newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxForceFieldLinearKernelDesc_torusRadius")]
        private extern static System.Single get_NxForceFieldLinearKernelDesc_torusRadius_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxForceFieldLinearKernelDesc_falloffLinear")]
        private extern static void set_NxForceFieldLinearKernelDesc_falloffLinear_INVOKE (HandleRef classPointer, NxVec3 newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxForceFieldLinearKernelDesc_falloffLinear")]
        private extern static NxVec3 get_NxForceFieldLinearKernelDesc_falloffLinear_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxForceFieldLinearKernelDesc_falloffQuadratic")]
        private extern static void set_NxForceFieldLinearKernelDesc_falloffQuadratic_INVOKE (HandleRef classPointer, NxVec3 newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxForceFieldLinearKernelDesc_falloffQuadratic")]
        private extern static NxVec3 get_NxForceFieldLinearKernelDesc_falloffQuadratic_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxForceFieldLinearKernelDesc_noise")]
        private extern static void set_NxForceFieldLinearKernelDesc_noise_INVOKE (HandleRef classPointer, NxVec3 newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxForceFieldLinearKernelDesc_noise")]
        private extern static NxVec3 get_NxForceFieldLinearKernelDesc_noise_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxForceFieldLinearKernelDesc_name")]
        private extern static void set_NxForceFieldLinearKernelDesc_name_INVOKE (HandleRef classPointer, System.String newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxForceFieldLinearKernelDesc_name")]
        private extern static System.String get_NxForceFieldLinearKernelDesc_name_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxForceFieldLinearKernelDesc_userData")]
        private extern static void set_NxForceFieldLinearKernelDesc_userData_INVOKE (HandleRef classPointer, System.IntPtr newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxForceFieldLinearKernelDesc_userData")]
        private extern static System.IntPtr get_NxForceFieldLinearKernelDesc_userData_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="new_NxForceFieldLinearKernelDesc")]
        private extern static IntPtr new_NxForceFieldLinearKernelDesc_INVOKE (System.Boolean do_override);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxForceFieldLinearKernelDesc_setToDefault")]
        private extern static void NxForceFieldLinearKernelDesc_setToDefault_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxForceFieldLinearKernelDesc_isValid")]
        private extern static System.Boolean NxForceFieldLinearKernelDesc_isValid_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

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
		
		public static NxForceFieldLinearKernelDesc GetClass(IntPtr ptr)
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
					return ((NxForceFieldLinearKernelDesc)(obj.Target));
				}
			}
			return new NxForceFieldLinearKernelDesc(ptr);
		}
		
		protected override System.Collections.Generic.List<System.IntPtr> CreateFunctionPointers()
		{
			System.Collections.Generic.List<System.IntPtr> list = base.CreateFunctionPointers();
			return list;
		}
	}
}
