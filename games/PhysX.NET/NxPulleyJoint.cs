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
	
	
	public class NxPulleyJoint : NxJoint
	{
		
		internal NxPulleyJoint(IntPtr ptr) : 
				base(ptr)
		{
		}
		
		/// <summary>Use this for changing a significant number of joint parameters at once. </summary>
		/// <param name="desc">The descriptor used to set the state of the object.</param>
		public virtual void loadFromDesc(NxPulleyJointDesc desc)
		{
			if (doSetFunctionPointers)
			{
				throw new System.NotSupportedException("Cannot call abstract base member");
			}
			NxPulleyJoint_loadFromDesc_INVOKE(ClassPointer, doSetFunctionPointers, (desc!=null ? desc.ClassPointer : NullRef));
		}
		
		private void loadFromDesc_virtual(IntPtr desc)
		{
			loadFromDesc(NxPulleyJointDesc.GetClass(desc));
		}
		
		delegate void loadFromDesc_0_delegate(IntPtr desc);
		
		
		
		
		
		
		private loadFromDesc_0_delegate loadFromDesc_0_delegatefield;
		
		/// <summary>Writes all of the object's attributes to the desc struct. </summary>
		/// <param name="desc">The descriptor used to retrieve the state of the object.</param>
		public virtual void saveToDesc(NxPulleyJointDesc desc)
		{
			if (doSetFunctionPointers)
			{
				throw new System.NotSupportedException("Cannot call abstract base member");
			}
			NxPulleyJoint_saveToDesc_INVOKE(ClassPointer, doSetFunctionPointers, (desc!=null ? desc.ClassPointer : NullRef));
		}
		
		private void saveToDesc_virtual(IntPtr desc)
		{
			saveToDesc(NxPulleyJointDesc.GetClass(desc));
		}
		
		delegate void saveToDesc_1_delegate(IntPtr desc);
		
		
		
		
		
		
		private saveToDesc_1_delegate saveToDesc_1_delegatefield;
		
		/// <summary>Sets motor parameters for the joint. </summary>
		/// <param name="motorDesc">Platform:PC SW: Yes PPU : Yes PS3 : Yes XB360: Yes</param>
		public virtual void setMotor(NxMotorDesc motorDesc)
		{
			if (doSetFunctionPointers)
			{
				throw new System.NotSupportedException("Cannot call abstract base member");
			}
			NxPulleyJoint_setMotor_INVOKE(ClassPointer, doSetFunctionPointers, (motorDesc!=null ? motorDesc.ClassPointer : NullRef));
		}
		
		private void setMotor_virtual(IntPtr motorDesc)
		{
			setMotor(NxMotorDesc.GetClass(motorDesc));
		}
		
		delegate void setMotor_2_delegate(IntPtr motorDesc);
		
		
		
		
		
		
		private setMotor_2_delegate setMotor_2_delegatefield;
		
		/// <summary>Reads back the motor parameters. Returns true if it is enabled. </summary>
		/// <param name="motorDesc">Used to retrieve the settings for this joint. </param>
		public virtual bool getMotor(NxMotorDesc motorDesc)
		{
			if (doSetFunctionPointers)
			{
				throw new System.NotSupportedException("Cannot call abstract base member");
			}
			return NxPulleyJoint_getMotor_INVOKE(ClassPointer, doSetFunctionPointers, (motorDesc!=null ? motorDesc.ClassPointer : NullRef));
		}
		
		private bool getMotor_virtual(IntPtr motorDesc)
		{
			return getMotor(NxMotorDesc.GetClass(motorDesc));
		}
		
		delegate bool getMotor_3_delegate(IntPtr motorDesc);
		
		
		
		
		
		
		private getMotor_3_delegate getMotor_3_delegatefield;
		
		/// <summary>Sets the flags. This is a combination of the NxPulleyJointFlag bits. </summary>
		/// <param name="flags">New set of flags for this joint. See NxPulleyJointFlag</param>
		public virtual void setFlags(uint flags)
		{
			if (doSetFunctionPointers)
			{
				throw new System.NotSupportedException("Cannot call abstract base member");
			}
			NxPulleyJoint_setFlags_INVOKE(ClassPointer, doSetFunctionPointers, flags);
		}
		
		private void setFlags_virtual(uint flags)
		{
			setFlags(flags);
		}
		
		delegate void setFlags_4_delegate(uint flags);
		
		
		
		
		
		
		private setFlags_4_delegate setFlags_4_delegatefield;
		
		/// <summary>returns the current flag settings. see NxPulleyJointFlag</summary>
		public virtual uint getFlags()
		{
			if (doSetFunctionPointers)
			{
				throw new System.NotSupportedException("Cannot call abstract base member");
			}
			return NxPulleyJoint_getFlags_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		private uint getFlags_virtual()
		{
			return getFlags();
		}
		
		delegate uint getFlags_5_delegate();
		
		
		
		
		
		
		private getFlags_5_delegate getFlags_5_delegatefield;
		
		#region Imports
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxPulleyJoint_loadFromDesc")]
        private extern static void NxPulleyJoint_loadFromDesc_INVOKE (HandleRef classPointer, System.Boolean call_explicit, HandleRef desc);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxPulleyJoint_saveToDesc")]
        private extern static void NxPulleyJoint_saveToDesc_INVOKE (HandleRef classPointer, System.Boolean call_explicit, HandleRef desc);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxPulleyJoint_setMotor")]
        private extern static void NxPulleyJoint_setMotor_INVOKE (HandleRef classPointer, System.Boolean call_explicit, HandleRef motorDesc);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxPulleyJoint_getMotor")]
        private extern static System.Boolean NxPulleyJoint_getMotor_INVOKE (HandleRef classPointer, System.Boolean call_explicit, HandleRef motorDesc);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxPulleyJoint_setFlags")]
        private extern static void NxPulleyJoint_setFlags_INVOKE (HandleRef classPointer, System.Boolean call_explicit, System.UInt32 flags);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxPulleyJoint_getFlags")]
        private extern static System.UInt32 NxPulleyJoint_getFlags_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

		#endregion
		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="new_NxPulleyJoint")]
        private extern static IntPtr new_NxPulleyJoint_INVOKE (bool do_override);

		
		protected NxPulleyJoint() : 
				base(IntPtr.Zero)
		{
			GC.ReRegisterForFinalize(this);
			if ((GetType() != typeof(NxPulleyJoint)))
			{
				doSetFunctionPointers = true;
				SetPointer(new_NxPulleyJoint_INVOKE(doSetFunctionPointers));
				System.IntPtr[] pointers = CreateFunctionPointers().ToArray();
				set_pointers_INVOKE(ClassPointer, pointers, pointers.Length);
			}
			else
			{
				SetPointer(new_NxPulleyJoint_INVOKE(doSetFunctionPointers));
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
		
		public static NxPulleyJoint GetClass(IntPtr ptr)
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
					return ((NxPulleyJoint)(obj.Target));
				}
			}
			return new NxPulleyJoint(ptr);
		}
		
		protected override System.Collections.Generic.List<System.IntPtr> CreateFunctionPointers()
		{
			System.Collections.Generic.List<System.IntPtr> list = base.CreateFunctionPointers();
			loadFromDesc_0_delegatefield = new loadFromDesc_0_delegate(this.loadFromDesc_virtual);
			list.Add(Marshal.GetFunctionPointerForDelegate(loadFromDesc_0_delegatefield));
			saveToDesc_1_delegatefield = new saveToDesc_1_delegate(this.saveToDesc_virtual);
			list.Add(Marshal.GetFunctionPointerForDelegate(saveToDesc_1_delegatefield));
			setMotor_2_delegatefield = new setMotor_2_delegate(this.setMotor_virtual);
			list.Add(Marshal.GetFunctionPointerForDelegate(setMotor_2_delegatefield));
			getMotor_3_delegatefield = new getMotor_3_delegate(this.getMotor_virtual);
			list.Add(Marshal.GetFunctionPointerForDelegate(getMotor_3_delegatefield));
			setFlags_4_delegatefield = new setFlags_4_delegate(this.setFlags_virtual);
			list.Add(Marshal.GetFunctionPointerForDelegate(setFlags_4_delegatefield));
			getFlags_5_delegatefield = new getFlags_5_delegate(this.getFlags_virtual);
			list.Add(Marshal.GetFunctionPointerForDelegate(getFlags_5_delegatefield));
			return list;
		}
	}
}
