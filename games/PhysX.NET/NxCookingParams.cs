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
	
	
	public class NxCookingParams : DoxyBindObject
	{
		
		internal NxCookingParams(IntPtr ptr) : 
				base(ptr)
		{
		}
		
		/// <summary>Target platform. </summary>
		public NxPlatform targetPlatform
		{
			get
			{
				NxPlatform value = get_NxCookingParams_targetPlatform_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxCookingParams_targetPlatform_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>Skin width for convexes. </summary>
		public float skinWidth
		{
			get
			{
				float value = get_NxCookingParams_skinWidth_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxCookingParams_skinWidth_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>Hint to choose speed or less memory for collision structures. </summary>
		public bool hintCollisionSpeed
		{
			get
			{
				bool value = get_NxCookingParams_hintCollisionSpeed_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxCookingParams_hintCollisionSpeed_INVOKE(ClassPointer, value);
			}
		}
		
		#region Imports
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxCookingParams_targetPlatform")]
        private extern static void set_NxCookingParams_targetPlatform_INVOKE (HandleRef classPointer, NxPlatform newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxCookingParams_targetPlatform")]
        private extern static NxPlatform get_NxCookingParams_targetPlatform_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxCookingParams_skinWidth")]
        private extern static void set_NxCookingParams_skinWidth_INVOKE (HandleRef classPointer, System.Single newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxCookingParams_skinWidth")]
        private extern static System.Single get_NxCookingParams_skinWidth_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxCookingParams_hintCollisionSpeed")]
        private extern static void set_NxCookingParams_hintCollisionSpeed_INVOKE (HandleRef classPointer, System.Boolean newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxCookingParams_hintCollisionSpeed")]
        private extern static System.Boolean get_NxCookingParams_hintCollisionSpeed_INVOKE (HandleRef classPointer);

		#endregion
		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="new_NxCookingParams")]
        private extern static IntPtr new_NxCookingParams_INVOKE (bool do_override);

		
		public NxCookingParams() : 
				base(new_NxCookingParams_INVOKE(false))
		{
			GC.ReRegisterForFinalize(this);
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
		
		public static NxCookingParams GetClass(IntPtr ptr)
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
					return ((NxCookingParams)(obj.Target));
				}
			}
			return new NxCookingParams(ptr);
		}
		
		protected override System.Collections.Generic.List<System.IntPtr> CreateFunctionPointers()
		{
			System.Collections.Generic.List<System.IntPtr> list = base.CreateFunctionPointers();
			return list;
		}
	}
}
