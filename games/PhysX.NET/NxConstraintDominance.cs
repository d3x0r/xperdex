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
	
	
	public class NxConstraintDominance : DoxyBindObject
	{
		
		internal NxConstraintDominance(IntPtr ptr) : 
				base(ptr)
		{
		}
		
		/// <summary></summary>
		public float dominance0
		{
			get
			{
				float value = get_NxConstraintDominance_dominance0_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxConstraintDominance_dominance0_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary></summary>
		public float dominance1
		{
			get
			{
				float value = get_NxConstraintDominance_dominance1_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxConstraintDominance_dominance1_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary></summary>
		public NxConstraintDominance(float a, float b) : 
				base(new_NxConstraintDominance_INVOKE(false, a, b))
		{
			GC.ReRegisterForFinalize(this);
		}
		
		#region Imports
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxConstraintDominance_dominance0")]
        private extern static void set_NxConstraintDominance_dominance0_INVOKE (HandleRef classPointer, System.Single newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxConstraintDominance_dominance0")]
        private extern static System.Single get_NxConstraintDominance_dominance0_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxConstraintDominance_dominance1")]
        private extern static void set_NxConstraintDominance_dominance1_INVOKE (HandleRef classPointer, System.Single newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxConstraintDominance_dominance1")]
        private extern static System.Single get_NxConstraintDominance_dominance1_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="new_NxConstraintDominance")]
        private extern static IntPtr new_NxConstraintDominance_INVOKE (System.Boolean do_override, System.Single a, System.Single b);

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
		
		public static NxConstraintDominance GetClass(IntPtr ptr)
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
					return ((NxConstraintDominance)(obj.Target));
				}
			}
			return new NxConstraintDominance(ptr);
		}
		
		protected override System.Collections.Generic.List<System.IntPtr> CreateFunctionPointers()
		{
			System.Collections.Generic.List<System.IntPtr> list = base.CreateFunctionPointers();
			return list;
		}
	}
}
