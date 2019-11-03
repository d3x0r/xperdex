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
	
	
	public class NxPointInPlaneJoint : NxJoint
	{
		
		internal NxPointInPlaneJoint(IntPtr ptr) : 
				base(ptr)
		{
		}
		
		/// <summary>Use this for changing a significant number of joint parameters at once. </summary>
		/// <param name="desc">The descriptor used to set the state of the object.</param>
		public virtual void loadFromDesc(NxPointInPlaneJointDesc desc)
		{
			if (doSetFunctionPointers)
			{
				throw new System.NotSupportedException("Cannot call abstract base member");
			}
			NxPointInPlaneJoint_loadFromDesc_INVOKE(ClassPointer, doSetFunctionPointers, (desc!=null ? desc.ClassPointer : NullRef));
		}
		
		private void loadFromDesc_virtual(IntPtr desc)
		{
			loadFromDesc(NxPointInPlaneJointDesc.GetClass(desc));
		}
		
		delegate void loadFromDesc_0_delegate(IntPtr desc);
		
		
		
		
		
		
		private loadFromDesc_0_delegate loadFromDesc_0_delegatefield;
		
		/// <summary>Writes all of the object's attributes to the desc struct. </summary>
		/// <param name="desc">The descriptor used to retrieve the state of the object.</param>
		public virtual void saveToDesc(NxPointInPlaneJointDesc desc)
		{
			if (doSetFunctionPointers)
			{
				throw new System.NotSupportedException("Cannot call abstract base member");
			}
			NxPointInPlaneJoint_saveToDesc_INVOKE(ClassPointer, doSetFunctionPointers, (desc!=null ? desc.ClassPointer : NullRef));
		}
		
		private void saveToDesc_virtual(IntPtr desc)
		{
			saveToDesc(NxPointInPlaneJointDesc.GetClass(desc));
		}
		
		delegate void saveToDesc_1_delegate(IntPtr desc);
		
		
		
		
		
		
		private saveToDesc_1_delegate saveToDesc_1_delegatefield;
		
		#region Imports
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxPointInPlaneJoint_loadFromDesc")]
        private extern static void NxPointInPlaneJoint_loadFromDesc_INVOKE (HandleRef classPointer, System.Boolean call_explicit, HandleRef desc);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxPointInPlaneJoint_saveToDesc")]
        private extern static void NxPointInPlaneJoint_saveToDesc_INVOKE (HandleRef classPointer, System.Boolean call_explicit, HandleRef desc);

		#endregion
		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="new_NxPointInPlaneJoint")]
        private extern static IntPtr new_NxPointInPlaneJoint_INVOKE (bool do_override);

		
		protected NxPointInPlaneJoint() : 
				base(IntPtr.Zero)
		{
			GC.ReRegisterForFinalize(this);
			if ((GetType() != typeof(NxPointInPlaneJoint)))
			{
				doSetFunctionPointers = true;
				SetPointer(new_NxPointInPlaneJoint_INVOKE(doSetFunctionPointers));
				System.IntPtr[] pointers = CreateFunctionPointers().ToArray();
				set_pointers_INVOKE(ClassPointer, pointers, pointers.Length);
			}
			else
			{
				SetPointer(new_NxPointInPlaneJoint_INVOKE(doSetFunctionPointers));
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
		
		public static NxPointInPlaneJoint GetClass(IntPtr ptr)
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
					return ((NxPointInPlaneJoint)(obj.Target));
				}
			}
			return new NxPointInPlaneJoint(ptr);
		}
		
		protected override System.Collections.Generic.List<System.IntPtr> CreateFunctionPointers()
		{
			System.Collections.Generic.List<System.IntPtr> list = base.CreateFunctionPointers();
			loadFromDesc_0_delegatefield = new loadFromDesc_0_delegate(this.loadFromDesc_virtual);
			list.Add(Marshal.GetFunctionPointerForDelegate(loadFromDesc_0_delegatefield));
			saveToDesc_1_delegatefield = new saveToDesc_1_delegate(this.saveToDesc_virtual);
			list.Add(Marshal.GetFunctionPointerForDelegate(saveToDesc_1_delegatefield));
			return list;
		}
	}
}
