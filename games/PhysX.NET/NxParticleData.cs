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
	
	
	public class NxParticleData : DoxyBindObject
	{
		
		internal NxParticleData(IntPtr ptr) : 
				base(ptr)
		{
		}
		
		/// <summary>Points to the user-allocated memory holding the number of elements stored in the buffers. </summary>
		public uint[] numParticlesPtr
		{
			get
			{
				uint[] value = get_NxParticleData_numParticlesPtr_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxParticleData_numParticlesPtr_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>The pointer to the user-allocated buffer for particle positions. </summary>
		public float[] bufferPos
		{
			get
			{
				float[] value = get_NxParticleData_bufferPos_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxParticleData_bufferPos_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>The pointer to the user-allocated buffer for particle velocities. </summary>
		public float[] bufferVel
		{
			get
			{
				float[] value = get_NxParticleData_bufferVel_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxParticleData_bufferVel_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>The pointer to the user-allocated buffer for particle lifetimes. </summary>
		public float[] bufferLife
		{
			get
			{
				float[] value = get_NxParticleData_bufferLife_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxParticleData_bufferLife_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>The pointer to the user-allocated buffer for particle densities. </summary>
		public float[] bufferDensity
		{
			get
			{
				float[] value = get_NxParticleData_bufferDensity_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxParticleData_bufferDensity_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>The pointer to the user-allocated buffer for particle IDs. </summary>
		public uint[] bufferId
		{
			get
			{
				uint[] value = get_NxParticleData_bufferId_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxParticleData_bufferId_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>The pointer to the user-allocated buffer for particle flags. </summary>
		public uint[] bufferFlag
		{
			get
			{
				uint[] value = get_NxParticleData_bufferFlag_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxParticleData_bufferFlag_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>The pointer to the user-allocated buffer for particle collision normals. </summary>
		public float[] bufferCollisionNormal
		{
			get
			{
				float[] value = get_NxParticleData_bufferCollisionNormal_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxParticleData_bufferCollisionNormal_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>The separation (in bytes) between consecutive particle positions. </summary>
		public uint bufferPosByteStride
		{
			get
			{
				uint value = get_NxParticleData_bufferPosByteStride_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxParticleData_bufferPosByteStride_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>The separation (in bytes) between consecutive particle velocities. </summary>
		public uint bufferVelByteStride
		{
			get
			{
				uint value = get_NxParticleData_bufferVelByteStride_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxParticleData_bufferVelByteStride_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>The separation (in bytes) between consecutive particle lifetimes. </summary>
		public uint bufferLifeByteStride
		{
			get
			{
				uint value = get_NxParticleData_bufferLifeByteStride_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxParticleData_bufferLifeByteStride_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>The separation (in bytes) between consecutive particle densities. </summary>
		public uint bufferDensityByteStride
		{
			get
			{
				uint value = get_NxParticleData_bufferDensityByteStride_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxParticleData_bufferDensityByteStride_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>The separation (in bytes) between consecutive particle IDs. </summary>
		public uint bufferIdByteStride
		{
			get
			{
				uint value = get_NxParticleData_bufferIdByteStride_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxParticleData_bufferIdByteStride_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>The separation (in bytes) between consecutive particle flags. </summary>
		public uint bufferFlagByteStride
		{
			get
			{
				uint value = get_NxParticleData_bufferFlagByteStride_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxParticleData_bufferFlagByteStride_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>The separation (in bytes) between consecutive particle collision normals. </summary>
		public uint bufferCollisionNormalByteStride
		{
			get
			{
				uint value = get_NxParticleData_bufferCollisionNormalByteStride_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxParticleData_bufferCollisionNormalByteStride_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>Possible debug name. The string is not copied by the SDK, only the pointer is stored. </summary>
		public string name
		{
			get
			{
				string value = get_NxParticleData_name_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxParticleData_name_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>(Re)sets the structure to the default. </summary>
		public void setToDefault()
		{
			NxParticleData_setToDefault_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		/// <summary>Returns true if the current settings are valid. </summary>
		public bool isValid()
		{
			return NxParticleData_isValid_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		/// <summary>Constructor sets to default. </summary>
		public NxParticleData() : 
				base(new_NxParticleData_INVOKE(false))
		{
			GC.ReRegisterForFinalize(this);
		}
		
		#region Imports
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxParticleData_numParticlesPtr")]
        private extern static void set_NxParticleData_numParticlesPtr_INVOKE (HandleRef classPointer, System.UInt32[] newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxParticleData_numParticlesPtr")]
        private extern static System.UInt32[] get_NxParticleData_numParticlesPtr_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxParticleData_bufferPos")]
        private extern static void set_NxParticleData_bufferPos_INVOKE (HandleRef classPointer, System.Single[] newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxParticleData_bufferPos")]
        private extern static System.Single[] get_NxParticleData_bufferPos_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxParticleData_bufferVel")]
        private extern static void set_NxParticleData_bufferVel_INVOKE (HandleRef classPointer, System.Single[] newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxParticleData_bufferVel")]
        private extern static System.Single[] get_NxParticleData_bufferVel_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxParticleData_bufferLife")]
        private extern static void set_NxParticleData_bufferLife_INVOKE (HandleRef classPointer, System.Single[] newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxParticleData_bufferLife")]
        private extern static System.Single[] get_NxParticleData_bufferLife_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxParticleData_bufferDensity")]
        private extern static void set_NxParticleData_bufferDensity_INVOKE (HandleRef classPointer, System.Single[] newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxParticleData_bufferDensity")]
        private extern static System.Single[] get_NxParticleData_bufferDensity_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxParticleData_bufferId")]
        private extern static void set_NxParticleData_bufferId_INVOKE (HandleRef classPointer, System.UInt32[] newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxParticleData_bufferId")]
        private extern static System.UInt32[] get_NxParticleData_bufferId_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxParticleData_bufferFlag")]
        private extern static void set_NxParticleData_bufferFlag_INVOKE (HandleRef classPointer, System.UInt32[] newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxParticleData_bufferFlag")]
        private extern static System.UInt32[] get_NxParticleData_bufferFlag_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxParticleData_bufferCollisionNormal")]
        private extern static void set_NxParticleData_bufferCollisionNormal_INVOKE (HandleRef classPointer, System.Single[] newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxParticleData_bufferCollisionNormal")]
        private extern static System.Single[] get_NxParticleData_bufferCollisionNormal_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxParticleData_bufferPosByteStride")]
        private extern static void set_NxParticleData_bufferPosByteStride_INVOKE (HandleRef classPointer, System.UInt32 newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxParticleData_bufferPosByteStride")]
        private extern static System.UInt32 get_NxParticleData_bufferPosByteStride_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxParticleData_bufferVelByteStride")]
        private extern static void set_NxParticleData_bufferVelByteStride_INVOKE (HandleRef classPointer, System.UInt32 newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxParticleData_bufferVelByteStride")]
        private extern static System.UInt32 get_NxParticleData_bufferVelByteStride_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxParticleData_bufferLifeByteStride")]
        private extern static void set_NxParticleData_bufferLifeByteStride_INVOKE (HandleRef classPointer, System.UInt32 newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxParticleData_bufferLifeByteStride")]
        private extern static System.UInt32 get_NxParticleData_bufferLifeByteStride_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxParticleData_bufferDensityByteStride")]
        private extern static void set_NxParticleData_bufferDensityByteStride_INVOKE (HandleRef classPointer, System.UInt32 newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxParticleData_bufferDensityByteStride")]
        private extern static System.UInt32 get_NxParticleData_bufferDensityByteStride_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxParticleData_bufferIdByteStride")]
        private extern static void set_NxParticleData_bufferIdByteStride_INVOKE (HandleRef classPointer, System.UInt32 newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxParticleData_bufferIdByteStride")]
        private extern static System.UInt32 get_NxParticleData_bufferIdByteStride_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxParticleData_bufferFlagByteStride")]
        private extern static void set_NxParticleData_bufferFlagByteStride_INVOKE (HandleRef classPointer, System.UInt32 newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxParticleData_bufferFlagByteStride")]
        private extern static System.UInt32 get_NxParticleData_bufferFlagByteStride_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxParticleData_bufferCollisionNormalByteStride")]
        private extern static void set_NxParticleData_bufferCollisionNormalByteStride_INVOKE (HandleRef classPointer, System.UInt32 newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxParticleData_bufferCollisionNormalByteStride")]
        private extern static System.UInt32 get_NxParticleData_bufferCollisionNormalByteStride_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxParticleData_name")]
        private extern static void set_NxParticleData_name_INVOKE (HandleRef classPointer, System.String newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxParticleData_name")]
        private extern static System.String get_NxParticleData_name_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxParticleData_setToDefault")]
        private extern static void NxParticleData_setToDefault_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxParticleData_isValid")]
        private extern static System.Boolean NxParticleData_isValid_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="new_NxParticleData")]
        private extern static IntPtr new_NxParticleData_INVOKE (System.Boolean do_override);

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
		
		public static NxParticleData GetClass(IntPtr ptr)
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
					return ((NxParticleData)(obj.Target));
				}
			}
			return new NxParticleData(ptr);
		}
		
		protected override System.Collections.Generic.List<System.IntPtr> CreateFunctionPointers()
		{
			System.Collections.Generic.List<System.IntPtr> list = base.CreateFunctionPointers();
			return list;
		}
	}
}
