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
	
	
	public class NxForceFieldShapeDesc : DoxyBindObject
	{
		
		internal NxForceFieldShapeDesc(IntPtr ptr) : 
				base(ptr)
		{
		}
		
		/// <summary>shape's pose </summary>
		public NxMat34 pose
		{
			get
			{
				NxMat34 value = get_NxForceFieldShapeDesc_pose_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxForceFieldShapeDesc_pose_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>Will be copied to NxForceFieldShape::userData. </summary>
		public System.IntPtr userData
		{
			get
			{
				System.IntPtr value = get_NxForceFieldShapeDesc_userData_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxForceFieldShapeDesc_userData_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>Possible debug name. The string is not copied by the SDK, only the pointer is stored. </summary>
		public string name
		{
			get
			{
				string value = get_NxForceFieldShapeDesc_name_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxForceFieldShapeDesc_name_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>(re)sets the structure to the default. </summary>
		public virtual void setToDefault()
		{
			NxForceFieldShapeDesc_setToDefault_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		private void setToDefault_virtual()
		{
			setToDefault();
		}
		
		delegate void setToDefault_0_delegate();
		
		
		
		
		
		
		private setToDefault_0_delegate setToDefault_0_delegatefield;
		
		/// <summary>Returns true if the descriptor is valid. </summary>
		public virtual bool isValid()
		{
			return NxForceFieldShapeDesc_isValid_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		private bool isValid_virtual()
		{
			return isValid();
		}
		
		delegate bool isValid_1_delegate();
		
		
		
		
		
		
		private isValid_1_delegate isValid_1_delegatefield;
		
		/// <summary>Retrieves the shape type. </summary>
		public NxShapeType getType()
		{
			return NxForceFieldShapeDesc_getType_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		/// <summary>Constructor sets to default. </summary>
		/// <param name="type">shape type </param>
		protected NxForceFieldShapeDesc(NxShapeType type) : 
				base(IntPtr.Zero)
		{
			if ((GetType() != typeof(NxForceFieldShapeDesc)))
			{
				doSetFunctionPointers = true;
				SetPointer(new_NxForceFieldShapeDesc_INVOKE(doSetFunctionPointers, type));
				System.IntPtr[] pointers = CreateFunctionPointers().ToArray();
				set_pointers_INVOKE(ClassPointer, pointers, pointers.Length);
			}
			else
			{
				SetPointer(new_NxForceFieldShapeDesc_INVOKE(doSetFunctionPointers, type));
			}
			GC.ReRegisterForFinalize(this);
		}
		
		#region Imports
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxForceFieldShapeDesc_pose")]
        private extern static void set_NxForceFieldShapeDesc_pose_INVOKE (HandleRef classPointer, NxMat34 newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxForceFieldShapeDesc_pose")]
        private extern static NxMat34 get_NxForceFieldShapeDesc_pose_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxForceFieldShapeDesc_userData")]
        private extern static void set_NxForceFieldShapeDesc_userData_INVOKE (HandleRef classPointer, System.IntPtr newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxForceFieldShapeDesc_userData")]
        private extern static System.IntPtr get_NxForceFieldShapeDesc_userData_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxForceFieldShapeDesc_name")]
        private extern static void set_NxForceFieldShapeDesc_name_INVOKE (HandleRef classPointer, System.String newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxForceFieldShapeDesc_name")]
        private extern static System.String get_NxForceFieldShapeDesc_name_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxForceFieldShapeDesc_setToDefault")]
        private extern static void NxForceFieldShapeDesc_setToDefault_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxForceFieldShapeDesc_isValid")]
        private extern static System.Boolean NxForceFieldShapeDesc_isValid_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxForceFieldShapeDesc_getType")]
        private extern static NxShapeType NxForceFieldShapeDesc_getType_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="new_NxForceFieldShapeDesc")]
        private extern static IntPtr new_NxForceFieldShapeDesc_INVOKE (System.Boolean do_override, NxShapeType type);

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
		
		public static NxForceFieldShapeDesc GetClass(IntPtr ptr)
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
					return ((NxForceFieldShapeDesc)(obj.Target));
				}
			}
			return new NxForceFieldShapeDesc(ptr);
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
