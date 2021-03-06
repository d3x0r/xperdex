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
	
	
	public class NxFluidEmitterDesc : DoxyBindObject
	{
		
		internal NxFluidEmitterDesc(IntPtr ptr) : 
				base(ptr)
		{
		}
		
		/// <summary>The emitter's pose relative to the frameShape. </summary>
		public NxMat34 relPose
		{
			get
			{
				NxMat34 value = get_NxFluidEmitterDesc_relPose_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxFluidEmitterDesc_relPose_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>A pointer to the NxShape to which the emitter is attached to. </summary>
		public NxShape frameShape
		{
			get
			{
				return NxShape.GetClass(get_NxFluidEmitterDesc_frameShape_INVOKE(ClassPointer));
			}
			set
			{
				set_NxFluidEmitterDesc_frameShape_INVOKE(ClassPointer, value.ClassPointer);
			}
		}
		
		/// <summary>The emitter's mode of operation. </summary>
		public uint type
		{
			get
			{
				uint value = get_NxFluidEmitterDesc_type_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxFluidEmitterDesc_type_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>The maximum number of particles which are emitted from this emitter. </summary>
		public uint maxParticles
		{
			get
			{
				uint value = get_NxFluidEmitterDesc_maxParticles_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxFluidEmitterDesc_maxParticles_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>The emitter's shape can either be rectangular or elliptical. </summary>
		public uint shape
		{
			get
			{
				uint value = get_NxFluidEmitterDesc_shape_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxFluidEmitterDesc_shape_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>The sizes of the emitter in the directions of the first and the second axis of its orientation frame (relPose). </summary>
		public float dimensionX
		{
			get
			{
				float value = get_NxFluidEmitterDesc_dimensionX_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxFluidEmitterDesc_dimensionX_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary></summary>
		public float dimensionY
		{
			get
			{
				float value = get_NxFluidEmitterDesc_dimensionY_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxFluidEmitterDesc_dimensionY_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>Random vector with values for each axis direction of the emitter orientation. </summary>
		public NxVec3 randomPos
		{
			get
			{
				NxVec3 value = get_NxFluidEmitterDesc_randomPos_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxFluidEmitterDesc_randomPos_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>Random angle deviation from emission direction. </summary>
		public float randomAngle
		{
			get
			{
				float value = get_NxFluidEmitterDesc_randomAngle_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxFluidEmitterDesc_randomAngle_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>The velocity magnitude of the emitted fluid particles. </summary>
		public float fluidVelocityMagnitude
		{
			get
			{
				float value = get_NxFluidEmitterDesc_fluidVelocityMagnitude_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxFluidEmitterDesc_fluidVelocityMagnitude_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>The rate specifies how many particles are emitted per second. </summary>
		public float rate
		{
			get
			{
				float value = get_NxFluidEmitterDesc_rate_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxFluidEmitterDesc_rate_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>This specifies the time in seconds an emitted particle lives. </summary>
		public float particleLifetime
		{
			get
			{
				float value = get_NxFluidEmitterDesc_particleLifetime_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxFluidEmitterDesc_particleLifetime_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>Defines a factor for the impulse transfer from attached emitter to body. </summary>
		public float repulsionCoefficient
		{
			get
			{
				float value = get_NxFluidEmitterDesc_repulsionCoefficient_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxFluidEmitterDesc_repulsionCoefficient_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>A combination of NxFluidEmitterFlags. </summary>
		public uint flags
		{
			get
			{
				uint value = get_NxFluidEmitterDesc_flags_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxFluidEmitterDesc_flags_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>Will be copied to NxShape::userData. </summary>
		public System.IntPtr userData
		{
			get
			{
				System.IntPtr value = get_NxFluidEmitterDesc_userData_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxFluidEmitterDesc_userData_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>Possible debug name. The string is not copied by the SDK, only the pointer is stored. </summary>
		public string name
		{
			get
			{
				string value = get_NxFluidEmitterDesc_name_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxFluidEmitterDesc_name_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>(Re)sets the structure to the default. </summary>
		public void setToDefault()
		{
			NxFluidEmitterDesc_setToDefault_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		/// <summary>Returns true if the current settings are valid. </summary>
		public bool isValid()
		{
			return NxFluidEmitterDesc_isValid_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		/// <summary>Constructor sets to default. </summary>
		public NxFluidEmitterDesc() : 
				base(new_NxFluidEmitterDesc_INVOKE(false))
		{
			GC.ReRegisterForFinalize(this);
		}
		
		#region Imports
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxFluidEmitterDesc_relPose")]
        private extern static void set_NxFluidEmitterDesc_relPose_INVOKE (HandleRef classPointer, NxMat34 newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxFluidEmitterDesc_relPose")]
        private extern static NxMat34 get_NxFluidEmitterDesc_relPose_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxFluidEmitterDesc_frameShape")]
        private extern static void set_NxFluidEmitterDesc_frameShape_INVOKE (HandleRef classPointer, HandleRef newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxFluidEmitterDesc_frameShape")]
        private extern static IntPtr get_NxFluidEmitterDesc_frameShape_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxFluidEmitterDesc_type")]
        private extern static void set_NxFluidEmitterDesc_type_INVOKE (HandleRef classPointer, System.UInt32 newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxFluidEmitterDesc_type")]
        private extern static System.UInt32 get_NxFluidEmitterDesc_type_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxFluidEmitterDesc_maxParticles")]
        private extern static void set_NxFluidEmitterDesc_maxParticles_INVOKE (HandleRef classPointer, System.UInt32 newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxFluidEmitterDesc_maxParticles")]
        private extern static System.UInt32 get_NxFluidEmitterDesc_maxParticles_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxFluidEmitterDesc_shape")]
        private extern static void set_NxFluidEmitterDesc_shape_INVOKE (HandleRef classPointer, System.UInt32 newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxFluidEmitterDesc_shape")]
        private extern static System.UInt32 get_NxFluidEmitterDesc_shape_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxFluidEmitterDesc_dimensionX")]
        private extern static void set_NxFluidEmitterDesc_dimensionX_INVOKE (HandleRef classPointer, System.Single newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxFluidEmitterDesc_dimensionX")]
        private extern static System.Single get_NxFluidEmitterDesc_dimensionX_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxFluidEmitterDesc_dimensionY")]
        private extern static void set_NxFluidEmitterDesc_dimensionY_INVOKE (HandleRef classPointer, System.Single newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxFluidEmitterDesc_dimensionY")]
        private extern static System.Single get_NxFluidEmitterDesc_dimensionY_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxFluidEmitterDesc_randomPos")]
        private extern static void set_NxFluidEmitterDesc_randomPos_INVOKE (HandleRef classPointer, NxVec3 newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxFluidEmitterDesc_randomPos")]
        private extern static NxVec3 get_NxFluidEmitterDesc_randomPos_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxFluidEmitterDesc_randomAngle")]
        private extern static void set_NxFluidEmitterDesc_randomAngle_INVOKE (HandleRef classPointer, System.Single newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxFluidEmitterDesc_randomAngle")]
        private extern static System.Single get_NxFluidEmitterDesc_randomAngle_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxFluidEmitterDesc_fluidVelocityMagnitude")]
        private extern static void set_NxFluidEmitterDesc_fluidVelocityMagnitude_INVOKE (HandleRef classPointer, System.Single newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxFluidEmitterDesc_fluidVelocityMagnitude")]
        private extern static System.Single get_NxFluidEmitterDesc_fluidVelocityMagnitude_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxFluidEmitterDesc_rate")]
        private extern static void set_NxFluidEmitterDesc_rate_INVOKE (HandleRef classPointer, System.Single newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxFluidEmitterDesc_rate")]
        private extern static System.Single get_NxFluidEmitterDesc_rate_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxFluidEmitterDesc_particleLifetime")]
        private extern static void set_NxFluidEmitterDesc_particleLifetime_INVOKE (HandleRef classPointer, System.Single newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxFluidEmitterDesc_particleLifetime")]
        private extern static System.Single get_NxFluidEmitterDesc_particleLifetime_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxFluidEmitterDesc_repulsionCoefficient")]
        private extern static void set_NxFluidEmitterDesc_repulsionCoefficient_INVOKE (HandleRef classPointer, System.Single newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxFluidEmitterDesc_repulsionCoefficient")]
        private extern static System.Single get_NxFluidEmitterDesc_repulsionCoefficient_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxFluidEmitterDesc_flags")]
        private extern static void set_NxFluidEmitterDesc_flags_INVOKE (HandleRef classPointer, System.UInt32 newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxFluidEmitterDesc_flags")]
        private extern static System.UInt32 get_NxFluidEmitterDesc_flags_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxFluidEmitterDesc_userData")]
        private extern static void set_NxFluidEmitterDesc_userData_INVOKE (HandleRef classPointer, System.IntPtr newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxFluidEmitterDesc_userData")]
        private extern static System.IntPtr get_NxFluidEmitterDesc_userData_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxFluidEmitterDesc_name")]
        private extern static void set_NxFluidEmitterDesc_name_INVOKE (HandleRef classPointer, System.String newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxFluidEmitterDesc_name")]
        private extern static System.String get_NxFluidEmitterDesc_name_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxFluidEmitterDesc_setToDefault")]
        private extern static void NxFluidEmitterDesc_setToDefault_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxFluidEmitterDesc_isValid")]
        private extern static System.Boolean NxFluidEmitterDesc_isValid_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="new_NxFluidEmitterDesc")]
        private extern static IntPtr new_NxFluidEmitterDesc_INVOKE (System.Boolean do_override);

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
		
		public static NxFluidEmitterDesc GetClass(IntPtr ptr)
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
					return ((NxFluidEmitterDesc)(obj.Target));
				}
			}
			return new NxFluidEmitterDesc(ptr);
		}
		
		protected override System.Collections.Generic.List<System.IntPtr> CreateFunctionPointers()
		{
			System.Collections.Generic.List<System.IntPtr> list = base.CreateFunctionPointers();
			return list;
		}
	}
}
