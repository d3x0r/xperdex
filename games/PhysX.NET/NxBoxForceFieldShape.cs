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
	
	
	public class NxBoxForceFieldShape : NxForceFieldShape
	{
		
		internal NxBoxForceFieldShape(IntPtr ptr) : 
				base(ptr)
		{
		}
		
		/// <summary>Sets the box dimensions. </summary>
		/// <param name="vec">The new 'radii' of the box. Range: direction vector</param>
		public virtual void setDimensions(ref NxVec3 vec)
		{
			if (doSetFunctionPointers)
			{
				throw new System.NotSupportedException("Cannot call abstract base member");
			}
			NxBoxForceFieldShape_setDimensions_INVOKE(ClassPointer, doSetFunctionPointers, ref vec);
		}
		
		private void setDimensions_virtual([In()] ref NxVec3 vec)
		{
			setDimensions(ref vec);
		}
		
		delegate void setDimensions_0_delegate([In()] ref NxVec3 vec);
		
		
		
		
		
		
		private setDimensions_0_delegate setDimensions_0_delegatefield;
		
		/// <summary>Retrieves the dimensions of the box. </summary>
		public virtual NxVec3 getDimensions()
		{
			if (doSetFunctionPointers)
			{
				throw new System.NotSupportedException("Cannot call abstract base member");
			}
			return NxBoxForceFieldShape_getDimensions_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		private NxVec3 getDimensions_virtual()
		{
			return getDimensions();
		}
		
		delegate NxVec3 getDimensions_1_delegate();
		
		
		
		
		
		
		private getDimensions_1_delegate getDimensions_1_delegatefield;
		
		/// <summary>Saves the state of the shape object to a descriptor. </summary>
		/// <param name="desc">Descriptor to save to.</param>
		public virtual void saveToDesc(NxBoxForceFieldShapeDesc desc)
		{
			if (doSetFunctionPointers)
			{
				throw new System.NotSupportedException("Cannot call abstract base member");
			}
			NxBoxForceFieldShape_saveToDesc_INVOKE(ClassPointer, doSetFunctionPointers, (desc!=null ? desc.ClassPointer : NullRef));
		}
		
		private void saveToDesc_virtual(IntPtr desc)
		{
			saveToDesc(NxBoxForceFieldShapeDesc.GetClass(desc));
		}
		
		delegate void saveToDesc_2_delegate(IntPtr desc);
		
		
		
		
		
		
		private saveToDesc_2_delegate saveToDesc_2_delegatefield;
		
		#region Imports
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxBoxForceFieldShape_setDimensions")]
        private extern static void NxBoxForceFieldShape_setDimensions_INVOKE (HandleRef classPointer, System.Boolean call_explicit, [In()] ref NxVec3 vec);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxBoxForceFieldShape_getDimensions")]
        private extern static NxVec3 NxBoxForceFieldShape_getDimensions_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxBoxForceFieldShape_saveToDesc")]
        private extern static void NxBoxForceFieldShape_saveToDesc_INVOKE (HandleRef classPointer, System.Boolean call_explicit, HandleRef desc);

		#endregion
		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="new_NxBoxForceFieldShape")]
        private extern static IntPtr new_NxBoxForceFieldShape_INVOKE (bool do_override);

		
		protected NxBoxForceFieldShape() : 
				base(IntPtr.Zero)
		{
			GC.ReRegisterForFinalize(this);
			if ((GetType() != typeof(NxBoxForceFieldShape)))
			{
				doSetFunctionPointers = true;
				SetPointer(new_NxBoxForceFieldShape_INVOKE(doSetFunctionPointers));
				System.IntPtr[] pointers = CreateFunctionPointers().ToArray();
				set_pointers_INVOKE(ClassPointer, pointers, pointers.Length);
			}
			else
			{
				SetPointer(new_NxBoxForceFieldShape_INVOKE(doSetFunctionPointers));
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
		
		public static NxBoxForceFieldShape GetClass(IntPtr ptr)
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
					return ((NxBoxForceFieldShape)(obj.Target));
				}
			}
			return new NxBoxForceFieldShape(ptr);
		}
		
		protected override System.Collections.Generic.List<System.IntPtr> CreateFunctionPointers()
		{
			System.Collections.Generic.List<System.IntPtr> list = base.CreateFunctionPointers();
			setDimensions_0_delegatefield = new setDimensions_0_delegate(this.setDimensions_virtual);
			list.Add(Marshal.GetFunctionPointerForDelegate(setDimensions_0_delegatefield));
			getDimensions_1_delegatefield = new getDimensions_1_delegate(this.getDimensions_virtual);
			list.Add(Marshal.GetFunctionPointerForDelegate(getDimensions_1_delegatefield));
			saveToDesc_2_delegatefield = new saveToDesc_2_delegate(this.saveToDesc_virtual);
			list.Add(Marshal.GetFunctionPointerForDelegate(saveToDesc_2_delegatefield));
			return list;
		}
	}
}
