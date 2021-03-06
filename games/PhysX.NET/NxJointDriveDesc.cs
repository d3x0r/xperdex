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
	
	
	public class NxJointDriveDesc : DoxyBindObject
	{
		
		internal NxJointDriveDesc(IntPtr ptr) : 
				base(ptr)
		{
		}
		
		/// <summary></summary>
		public NxBitField driveType
		{
			get
			{
				return NxBitField.GetClass(get_NxJointDriveDesc_driveType_INVOKE(ClassPointer));
			}
			set
			{
				set_NxJointDriveDesc_driveType_INVOKE(ClassPointer, value.ClassPointer);
			}
		}
		
		/// <summary>spring coefficient </summary>
		public float spring
		{
			get
			{
				float value = get_NxJointDriveDesc_spring_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxJointDriveDesc_spring_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>damper coefficient </summary>
		public float damping
		{
			get
			{
				float value = get_NxJointDriveDesc_damping_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxJointDriveDesc_damping_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>The maximum force (or torque) the drive can exert. </summary>
		public float forceLimit
		{
			get
			{
				float value = get_NxJointDriveDesc_forceLimit_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxJointDriveDesc_forceLimit_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary></summary>
		public NxJointDriveDesc() : 
				base(new_NxJointDriveDesc_INVOKE(false))
		{
			GC.ReRegisterForFinalize(this);
		}
		
		#region Imports
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxJointDriveDesc_driveType")]
        private extern static void set_NxJointDriveDesc_driveType_INVOKE (HandleRef classPointer, HandleRef newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxJointDriveDesc_driveType")]
        private extern static IntPtr get_NxJointDriveDesc_driveType_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxJointDriveDesc_spring")]
        private extern static void set_NxJointDriveDesc_spring_INVOKE (HandleRef classPointer, System.Single newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxJointDriveDesc_spring")]
        private extern static System.Single get_NxJointDriveDesc_spring_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxJointDriveDesc_damping")]
        private extern static void set_NxJointDriveDesc_damping_INVOKE (HandleRef classPointer, System.Single newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxJointDriveDesc_damping")]
        private extern static System.Single get_NxJointDriveDesc_damping_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxJointDriveDesc_forceLimit")]
        private extern static void set_NxJointDriveDesc_forceLimit_INVOKE (HandleRef classPointer, System.Single newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxJointDriveDesc_forceLimit")]
        private extern static System.Single get_NxJointDriveDesc_forceLimit_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="new_NxJointDriveDesc")]
        private extern static IntPtr new_NxJointDriveDesc_INVOKE (System.Boolean do_override);

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
		
		public static NxJointDriveDesc GetClass(IntPtr ptr)
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
					return ((NxJointDriveDesc)(obj.Target));
				}
			}
			return new NxJointDriveDesc(ptr);
		}
		
		protected override System.Collections.Generic.List<System.IntPtr> CreateFunctionPointers()
		{
			System.Collections.Generic.List<System.IntPtr> list = base.CreateFunctionPointers();
			return list;
		}
	}
}
