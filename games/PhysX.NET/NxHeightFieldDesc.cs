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
	
	
	public class NxHeightFieldDesc : DoxyBindObject
	{
		
		internal NxHeightFieldDesc(IntPtr ptr) : 
				base(ptr)
		{
		}
		
		/// <summary>Number of sample rows in the height field samples array. </summary>
		public uint nbRows
		{
			get
			{
				uint value = get_NxHeightFieldDesc_nbRows_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxHeightFieldDesc_nbRows_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>Number of sample columns in the height field samples array. </summary>
		public uint nbColumns
		{
			get
			{
				uint value = get_NxHeightFieldDesc_nbColumns_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxHeightFieldDesc_nbColumns_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>Format of the sample data. </summary>
		public NxHeightFieldFormat format
		{
			get
			{
				NxHeightFieldFormat value = get_NxHeightFieldDesc_format_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxHeightFieldDesc_format_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>The offset in bytes between consecutive samples in the samples array. </summary>
		public uint sampleStride
		{
			get
			{
				uint value = get_NxHeightFieldDesc_sampleStride_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxHeightFieldDesc_sampleStride_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>The samples array. </summary>
		public System.IntPtr samples
		{
			get
			{
				System.IntPtr value = get_NxHeightFieldDesc_samples_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxHeightFieldDesc_samples_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>Deprecated: Sets how far 'below ground' the height volume extends. </summary>
		public float verticalExtent
		{
			get
			{
				float value = get_NxHeightFieldDesc_verticalExtent_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxHeightFieldDesc_verticalExtent_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>Sets how thick the heightfield surface is. </summary>
		public float thickness
		{
			get
			{
				float value = get_NxHeightFieldDesc_thickness_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxHeightFieldDesc_thickness_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary></summary>
		public float convexEdgeThreshold
		{
			get
			{
				float value = get_NxHeightFieldDesc_convexEdgeThreshold_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxHeightFieldDesc_convexEdgeThreshold_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>Flags bits, combined from values of the enum NxHeightFieldFlags. </summary>
		public uint flags
		{
			get
			{
				uint value = get_NxHeightFieldDesc_flags_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxHeightFieldDesc_flags_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>Constructor sets to default. </summary>
		public NxHeightFieldDesc() : 
				base(new_NxHeightFieldDesc_INVOKE(false))
		{
			GC.ReRegisterForFinalize(this);
		}
		
		/// <summary>(re)sets the structure to the default. </summary>
		public void setToDefault()
		{
			NxHeightFieldDesc_setToDefault_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		/// <summary>Returns true if the descriptor is valid. </summary>
		public bool isValid()
		{
			return NxHeightFieldDesc_isValid_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		#region Imports
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxHeightFieldDesc_nbRows")]
        private extern static void set_NxHeightFieldDesc_nbRows_INVOKE (HandleRef classPointer, System.UInt32 newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxHeightFieldDesc_nbRows")]
        private extern static System.UInt32 get_NxHeightFieldDesc_nbRows_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxHeightFieldDesc_nbColumns")]
        private extern static void set_NxHeightFieldDesc_nbColumns_INVOKE (HandleRef classPointer, System.UInt32 newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxHeightFieldDesc_nbColumns")]
        private extern static System.UInt32 get_NxHeightFieldDesc_nbColumns_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxHeightFieldDesc_format")]
        private extern static void set_NxHeightFieldDesc_format_INVOKE (HandleRef classPointer, NxHeightFieldFormat newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxHeightFieldDesc_format")]
        private extern static NxHeightFieldFormat get_NxHeightFieldDesc_format_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxHeightFieldDesc_sampleStride")]
        private extern static void set_NxHeightFieldDesc_sampleStride_INVOKE (HandleRef classPointer, System.UInt32 newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxHeightFieldDesc_sampleStride")]
        private extern static System.UInt32 get_NxHeightFieldDesc_sampleStride_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxHeightFieldDesc_samples")]
        private extern static void set_NxHeightFieldDesc_samples_INVOKE (HandleRef classPointer, System.IntPtr newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxHeightFieldDesc_samples")]
        private extern static System.IntPtr get_NxHeightFieldDesc_samples_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxHeightFieldDesc_verticalExtent")]
        private extern static void set_NxHeightFieldDesc_verticalExtent_INVOKE (HandleRef classPointer, System.Single newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxHeightFieldDesc_verticalExtent")]
        private extern static System.Single get_NxHeightFieldDesc_verticalExtent_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxHeightFieldDesc_thickness")]
        private extern static void set_NxHeightFieldDesc_thickness_INVOKE (HandleRef classPointer, System.Single newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxHeightFieldDesc_thickness")]
        private extern static System.Single get_NxHeightFieldDesc_thickness_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxHeightFieldDesc_convexEdgeThreshold")]
        private extern static void set_NxHeightFieldDesc_convexEdgeThreshold_INVOKE (HandleRef classPointer, System.Single newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxHeightFieldDesc_convexEdgeThreshold")]
        private extern static System.Single get_NxHeightFieldDesc_convexEdgeThreshold_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxHeightFieldDesc_flags")]
        private extern static void set_NxHeightFieldDesc_flags_INVOKE (HandleRef classPointer, System.UInt32 newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxHeightFieldDesc_flags")]
        private extern static System.UInt32 get_NxHeightFieldDesc_flags_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="new_NxHeightFieldDesc")]
        private extern static IntPtr new_NxHeightFieldDesc_INVOKE (System.Boolean do_override);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxHeightFieldDesc_setToDefault")]
        private extern static void NxHeightFieldDesc_setToDefault_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxHeightFieldDesc_isValid")]
        private extern static System.Boolean NxHeightFieldDesc_isValid_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

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
		
		public static NxHeightFieldDesc GetClass(IntPtr ptr)
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
					return ((NxHeightFieldDesc)(obj.Target));
				}
			}
			return new NxHeightFieldDesc(ptr);
		}
		
		protected override System.Collections.Generic.List<System.IntPtr> CreateFunctionPointers()
		{
			System.Collections.Generic.List<System.IntPtr> list = base.CreateFunctionPointers();
			return list;
		}
	}
}
