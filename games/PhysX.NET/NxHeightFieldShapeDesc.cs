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
	
	
	public class NxHeightFieldShapeDesc : NxShapeDesc
	{
		
		internal NxHeightFieldShapeDesc(IntPtr ptr) : 
				base(ptr)
		{
		}
		
		/// <summary>References the height field that we want to instance. </summary>
		public NxHeightField heightField
		{
			get
			{
				return NxHeightField.GetClass(get_NxHeightFieldShapeDesc_heightField_INVOKE(ClassPointer));
			}
			set
			{
				set_NxHeightFieldShapeDesc_heightField_INVOKE(ClassPointer, value.ClassPointer);
			}
		}
		
		/// <summary>Multiplier to transform sample height values to shape space y coordinates. </summary>
		public float heightScale
		{
			get
			{
				float value = get_NxHeightFieldShapeDesc_heightScale_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxHeightFieldShapeDesc_heightScale_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>Multiplier to transform height field rows to shape space x coordinates. </summary>
		public float rowScale
		{
			get
			{
				float value = get_NxHeightFieldShapeDesc_rowScale_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxHeightFieldShapeDesc_rowScale_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>Multiplier to transform height field columns to shape space z coordinates. </summary>
		public float columnScale
		{
			get
			{
				float value = get_NxHeightFieldShapeDesc_columnScale_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxHeightFieldShapeDesc_columnScale_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>The high 9 bits of this number are used to complete the material indices in the samples. </summary>
		public ushort materialIndexHighBits
		{
			get
			{
				ushort value = get_NxHeightFieldShapeDesc_materialIndexHighBits_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxHeightFieldShapeDesc_materialIndexHighBits_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>The the material index that designates holes in the height field. </summary>
		public ushort holeMaterial
		{
			get
			{
				ushort value = get_NxHeightFieldShapeDesc_holeMaterial_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxHeightFieldShapeDesc_holeMaterial_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>Combination of NxMeshShapeFlag. So far the only value permitted here is 0 or NX_MESH_SMOOTH_SPHERE_COLLISIONS. </summary>
		public uint meshFlags
		{
			get
			{
				uint value = get_NxHeightFieldShapeDesc_meshFlags_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxHeightFieldShapeDesc_meshFlags_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>Constructor sets to default. </summary>
		public NxHeightFieldShapeDesc() : 
				base(IntPtr.Zero)
		{
			if ((GetType() != typeof(NxHeightFieldShapeDesc)))
			{
				doSetFunctionPointers = true;
				SetPointer(new_NxHeightFieldShapeDesc_INVOKE(doSetFunctionPointers));
				System.IntPtr[] pointers = CreateFunctionPointers().ToArray();
				set_pointers_INVOKE(ClassPointer, pointers, pointers.Length);
			}
			else
			{
				SetPointer(new_NxHeightFieldShapeDesc_INVOKE(doSetFunctionPointers));
			}
			GC.ReRegisterForFinalize(this);
		}
		
		/// <summary>(re)sets the structure to the default. </summary>
		public override void setToDefault()
		{
			NxHeightFieldShapeDesc_setToDefault_INVOKE(ClassPointer, doSetFunctionPointers);
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
			return NxHeightFieldShapeDesc_isValid_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		private bool isValid_virtual()
		{
			return isValid();
		}
		
		delegate bool isValid_1_delegate();
		
		
		
		
		
		
		private isValid_1_delegate isValid_1_delegatefield;
		
		#region Imports
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxHeightFieldShapeDesc_heightField")]
        private extern static void set_NxHeightFieldShapeDesc_heightField_INVOKE (HandleRef classPointer, HandleRef newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxHeightFieldShapeDesc_heightField")]
        private extern static IntPtr get_NxHeightFieldShapeDesc_heightField_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxHeightFieldShapeDesc_heightScale")]
        private extern static void set_NxHeightFieldShapeDesc_heightScale_INVOKE (HandleRef classPointer, System.Single newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxHeightFieldShapeDesc_heightScale")]
        private extern static System.Single get_NxHeightFieldShapeDesc_heightScale_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxHeightFieldShapeDesc_rowScale")]
        private extern static void set_NxHeightFieldShapeDesc_rowScale_INVOKE (HandleRef classPointer, System.Single newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxHeightFieldShapeDesc_rowScale")]
        private extern static System.Single get_NxHeightFieldShapeDesc_rowScale_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxHeightFieldShapeDesc_columnScale")]
        private extern static void set_NxHeightFieldShapeDesc_columnScale_INVOKE (HandleRef classPointer, System.Single newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxHeightFieldShapeDesc_columnScale")]
        private extern static System.Single get_NxHeightFieldShapeDesc_columnScale_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxHeightFieldShapeDesc_materialIndexHighBits")]
        private extern static void set_NxHeightFieldShapeDesc_materialIndexHighBits_INVOKE (HandleRef classPointer, System.UInt16 newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxHeightFieldShapeDesc_materialIndexHighBits")]
        private extern static System.UInt16 get_NxHeightFieldShapeDesc_materialIndexHighBits_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxHeightFieldShapeDesc_holeMaterial")]
        private extern static void set_NxHeightFieldShapeDesc_holeMaterial_INVOKE (HandleRef classPointer, System.UInt16 newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxHeightFieldShapeDesc_holeMaterial")]
        private extern static System.UInt16 get_NxHeightFieldShapeDesc_holeMaterial_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxHeightFieldShapeDesc_meshFlags")]
        private extern static void set_NxHeightFieldShapeDesc_meshFlags_INVOKE (HandleRef classPointer, System.UInt32 newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxHeightFieldShapeDesc_meshFlags")]
        private extern static System.UInt32 get_NxHeightFieldShapeDesc_meshFlags_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="new_NxHeightFieldShapeDesc")]
        private extern static IntPtr new_NxHeightFieldShapeDesc_INVOKE (System.Boolean do_override);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxHeightFieldShapeDesc_setToDefault")]
        private extern static void NxHeightFieldShapeDesc_setToDefault_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxHeightFieldShapeDesc_isValid")]
        private extern static System.Boolean NxHeightFieldShapeDesc_isValid_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

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
		
		public static NxHeightFieldShapeDesc GetClass(IntPtr ptr)
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
					return ((NxHeightFieldShapeDesc)(obj.Target));
				}
			}
			return new NxHeightFieldShapeDesc(ptr);
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
