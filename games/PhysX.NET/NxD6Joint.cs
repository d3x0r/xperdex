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
	
	
	public class NxD6Joint : NxJoint
	{
		
		internal NxD6Joint(IntPtr ptr) : 
				base(ptr)
		{
		}
		
		/// <summary>Use this for changing a significant number of joint parameters at once. </summary>
		/// <param name="desc">The descriptor used to set the state of the object.</param>
		public virtual void loadFromDesc(NxD6JointDesc desc)
		{
			if (doSetFunctionPointers)
			{
				throw new System.NotSupportedException("Cannot call abstract base member");
			}
			NxD6Joint_loadFromDesc_INVOKE(ClassPointer, doSetFunctionPointers, (desc!=null ? desc.ClassPointer : NullRef));
		}
		
		private void loadFromDesc_virtual(IntPtr desc)
		{
			loadFromDesc(NxD6JointDesc.GetClass(desc));
		}
		
		delegate void loadFromDesc_0_delegate(IntPtr desc);
		
		
		
		
		
		
		private loadFromDesc_0_delegate loadFromDesc_0_delegatefield;
		
		/// <summary>Writes all of the object's attributes to the desc struct. </summary>
		/// <param name="desc">The descriptor used to retrieve the state of the object.</param>
		public virtual void saveToDesc(NxD6JointDesc desc)
		{
			if (doSetFunctionPointers)
			{
				throw new System.NotSupportedException("Cannot call abstract base member");
			}
			NxD6Joint_saveToDesc_INVOKE(ClassPointer, doSetFunctionPointers, (desc!=null ? desc.ClassPointer : NullRef));
		}
		
		private void saveToDesc_virtual(IntPtr desc)
		{
			saveToDesc(NxD6JointDesc.GetClass(desc));
		}
		
		delegate void saveToDesc_1_delegate(IntPtr desc);
		
		
		
		
		
		
		private saveToDesc_1_delegate saveToDesc_1_delegatefield;
		
		/// <summary>Set the drive position goal position when it is being driven. </summary>
		/// <param name="position">The goal position if NX_D6JOINT_DRIVE_POSITION is set for xDrive,yDrive or zDrive. Range: position vector</param>
		public virtual void setDrivePosition(ref NxVec3 position)
		{
			if (doSetFunctionPointers)
			{
				throw new System.NotSupportedException("Cannot call abstract base member");
			}
			NxD6Joint_setDrivePosition_INVOKE(ClassPointer, doSetFunctionPointers, ref position);
		}
		
		private void setDrivePosition_virtual([In()] ref NxVec3 position)
		{
			setDrivePosition(ref position);
		}
		
		delegate void setDrivePosition_2_delegate([In()] ref NxVec3 position);
		
		
		
		
		
		
		private setDrivePosition_2_delegate setDrivePosition_2_delegatefield;
		
		/// <summary>Set the drive goal orientation when it is being driven. </summary>
		/// <param name="orientation">The goal orientation if NX_D6JOINT_DRIVE_POSITION is set for swingDrive or twistDrive. Range: unit quaternion</param>
		public virtual void setDriveOrientation(ref NxQuat orientation)
		{
			if (doSetFunctionPointers)
			{
				throw new System.NotSupportedException("Cannot call abstract base member");
			}
			NxD6Joint_setDriveOrientation_INVOKE(ClassPointer, doSetFunctionPointers, ref orientation);
		}
		
		private void setDriveOrientation_virtual([In()] ref NxQuat orientation)
		{
			setDriveOrientation(ref orientation);
		}
		
		delegate void setDriveOrientation_3_delegate([In()] ref NxQuat orientation);
		
		
		
		
		
		
		private setDriveOrientation_3_delegate setDriveOrientation_3_delegatefield;
		
		/// <summary>Set the drive goal linear velocity when it is being driven. </summary>
		/// <param name="linVel">The goal velocity if NX_D6JOINT_DRIVE_VELOCITY is set for xDrive,yDrive or zDrive. See NxD6JointDesc. Range: velocity vector</param>
		public virtual void setDriveLinearVelocity(ref NxVec3 linVel)
		{
			if (doSetFunctionPointers)
			{
				throw new System.NotSupportedException("Cannot call abstract base member");
			}
			NxD6Joint_setDriveLinearVelocity_INVOKE(ClassPointer, doSetFunctionPointers, ref linVel);
		}
		
		private void setDriveLinearVelocity_virtual([In()] ref NxVec3 linVel)
		{
			setDriveLinearVelocity(ref linVel);
		}
		
		delegate void setDriveLinearVelocity_4_delegate([In()] ref NxVec3 linVel);
		
		
		
		
		
		
		private setDriveLinearVelocity_4_delegate setDriveLinearVelocity_4_delegatefield;
		
		/// <summary>Set the drive angular velocity goal when it is being driven. </summary>
		/// <param name="angVel">The goal angular velocity if NX_D6JOINT_DRIVE_VELOCITY is set for swingDrive or twistDrive. Range: angular velocity vector</param>
		public virtual void setDriveAngularVelocity(ref NxVec3 angVel)
		{
			if (doSetFunctionPointers)
			{
				throw new System.NotSupportedException("Cannot call abstract base member");
			}
			NxD6Joint_setDriveAngularVelocity_INVOKE(ClassPointer, doSetFunctionPointers, ref angVel);
		}
		
		private void setDriveAngularVelocity_virtual([In()] ref NxVec3 angVel)
		{
			setDriveAngularVelocity(ref angVel);
		}
		
		delegate void setDriveAngularVelocity_5_delegate([In()] ref NxVec3 angVel);
		
		
		
		
		
		
		private setDriveAngularVelocity_5_delegate setDriveAngularVelocity_5_delegatefield;
		
		#region Imports
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxD6Joint_loadFromDesc")]
        private extern static void NxD6Joint_loadFromDesc_INVOKE (HandleRef classPointer, System.Boolean call_explicit, HandleRef desc);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxD6Joint_saveToDesc")]
        private extern static void NxD6Joint_saveToDesc_INVOKE (HandleRef classPointer, System.Boolean call_explicit, HandleRef desc);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxD6Joint_setDrivePosition")]
        private extern static void NxD6Joint_setDrivePosition_INVOKE (HandleRef classPointer, System.Boolean call_explicit, [In()] ref NxVec3 position);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxD6Joint_setDriveOrientation")]
        private extern static void NxD6Joint_setDriveOrientation_INVOKE (HandleRef classPointer, System.Boolean call_explicit, [In()] ref NxQuat orientation);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxD6Joint_setDriveLinearVelocity")]
        private extern static void NxD6Joint_setDriveLinearVelocity_INVOKE (HandleRef classPointer, System.Boolean call_explicit, [In()] ref NxVec3 linVel);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxD6Joint_setDriveAngularVelocity")]
        private extern static void NxD6Joint_setDriveAngularVelocity_INVOKE (HandleRef classPointer, System.Boolean call_explicit, [In()] ref NxVec3 angVel);

		#endregion
		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="new_NxD6Joint")]
        private extern static IntPtr new_NxD6Joint_INVOKE (bool do_override);

		
		protected NxD6Joint() : 
				base(IntPtr.Zero)
		{
			GC.ReRegisterForFinalize(this);
			if ((GetType() != typeof(NxD6Joint)))
			{
				doSetFunctionPointers = true;
				SetPointer(new_NxD6Joint_INVOKE(doSetFunctionPointers));
				System.IntPtr[] pointers = CreateFunctionPointers().ToArray();
				set_pointers_INVOKE(ClassPointer, pointers, pointers.Length);
			}
			else
			{
				SetPointer(new_NxD6Joint_INVOKE(doSetFunctionPointers));
			}
		}
		
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
		
		public static NxD6Joint GetClass(IntPtr ptr)
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
					return ((NxD6Joint)(obj.Target));
				}
			}
			return new NxD6Joint(ptr);
		}
		
		protected override System.Collections.Generic.List<System.IntPtr> CreateFunctionPointers()
		{
			System.Collections.Generic.List<System.IntPtr> list = base.CreateFunctionPointers();
			loadFromDesc_0_delegatefield = new loadFromDesc_0_delegate(this.loadFromDesc_virtual);
			list.Add(Marshal.GetFunctionPointerForDelegate(loadFromDesc_0_delegatefield));
			saveToDesc_1_delegatefield = new saveToDesc_1_delegate(this.saveToDesc_virtual);
			list.Add(Marshal.GetFunctionPointerForDelegate(saveToDesc_1_delegatefield));
			setDrivePosition_2_delegatefield = new setDrivePosition_2_delegate(this.setDrivePosition_virtual);
			list.Add(Marshal.GetFunctionPointerForDelegate(setDrivePosition_2_delegatefield));
			setDriveOrientation_3_delegatefield = new setDriveOrientation_3_delegate(this.setDriveOrientation_virtual);
			list.Add(Marshal.GetFunctionPointerForDelegate(setDriveOrientation_3_delegatefield));
			setDriveLinearVelocity_4_delegatefield = new setDriveLinearVelocity_4_delegate(this.setDriveLinearVelocity_virtual);
			list.Add(Marshal.GetFunctionPointerForDelegate(setDriveLinearVelocity_4_delegatefield));
			setDriveAngularVelocity_5_delegatefield = new setDriveAngularVelocity_5_delegate(this.setDriveAngularVelocity_virtual);
			list.Add(Marshal.GetFunctionPointerForDelegate(setDriveAngularVelocity_5_delegatefield));
			return list;
		}
	}
}
