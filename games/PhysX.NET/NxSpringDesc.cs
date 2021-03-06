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
	
	
	public class NxSpringDesc : DoxyBindObject
	{
		
		internal NxSpringDesc(IntPtr ptr) : 
				base(ptr)
		{
		}
		
		/// <summary>spring coefficient </summary>
		public float spring
		{
			get
			{
				float value = get_NxSpringDesc_spring_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxSpringDesc_spring_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>damper coefficient </summary>
		public float damper
		{
			get
			{
				float value = get_NxSpringDesc_damper_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxSpringDesc_damper_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>target value (angle/position) of spring where the spring force is zero. </summary>
		public float targetValue
		{
			get
			{
				float value = get_NxSpringDesc_targetValue_INVOKE(ClassPointer);
				return value;
			}
			set
			{
				set_NxSpringDesc_targetValue_INVOKE(ClassPointer, value);
			}
		}
		
		/// <summary>Initializes the NxSpringDesc with default parameters. </summary>
		public NxSpringDesc() : 
				base(new_NxSpringDesc_INVOKE(false))
		{
			GC.ReRegisterForFinalize(this);
		}
		
		/// <summary>Initializes a NxSpringDesc with the given parameters. </summary>
		/// <param name="spring">Spring Coefficient. Range: (-inf,inf) </param>
		/// <param name="damper">Damper Coefficient. Range: [0,inf) </param>
		/// <param name="targetValue">Target value (angle/position) of spring where the spring force is zero. Range: Angular: (-PI,PI] Positional: (-inf,inf)</param>
		public NxSpringDesc(float spring, float damper, float targetValue) : 
				base(new_NxSpringDesc_1_INVOKE(false, spring, damper, targetValue))
		{
			GC.ReRegisterForFinalize(this);
		}
		
		/// <summary>Initializes a NxSpringDesc with the given parameters. </summary>
		/// <param name="spring">Spring Coefficient. Range: (-inf,inf) </param>
		/// <param name="damper">Damper Coefficient. Range: [0,inf) </param>
		/// <param name="targetValue">Target value (angle/position) of spring where the spring force is zero. Range: Angular: (-PI,PI] Positional: (-inf,inf)</param>
		public NxSpringDesc(float spring, float damper) : 
				base(new_NxSpringDesc_2_INVOKE(false, spring, damper))
		{
			GC.ReRegisterForFinalize(this);
		}
		
		/// <summary>Initializes a NxSpringDesc with the given parameters. </summary>
		/// <param name="spring">Spring Coefficient. Range: (-inf,inf) </param>
		/// <param name="damper">Damper Coefficient. Range: [0,inf) </param>
		/// <param name="targetValue">Target value (angle/position) of spring where the spring force is zero. Range: Angular: (-PI,PI] Positional: (-inf,inf)</param>
		public NxSpringDesc(float spring) : 
				base(new_NxSpringDesc_3_INVOKE(false, spring))
		{
			GC.ReRegisterForFinalize(this);
		}
		
		/// <summary>(re)sets the structure to the default. </summary>
		public void setToDefault()
		{
			NxSpringDesc_setToDefault_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		/// <summary>Returns true if the descriptor is valid. </summary>
		public bool isValid()
		{
			return NxSpringDesc_isValid_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		#region Imports
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxSpringDesc_spring")]
        private extern static void set_NxSpringDesc_spring_INVOKE (HandleRef classPointer, System.Single newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxSpringDesc_spring")]
        private extern static System.Single get_NxSpringDesc_spring_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxSpringDesc_damper")]
        private extern static void set_NxSpringDesc_damper_INVOKE (HandleRef classPointer, System.Single newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxSpringDesc_damper")]
        private extern static System.Single get_NxSpringDesc_damper_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="set_NxSpringDesc_targetValue")]
        private extern static void set_NxSpringDesc_targetValue_INVOKE (HandleRef classPointer, System.Single newvalue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="get_NxSpringDesc_targetValue")]
        private extern static System.Single get_NxSpringDesc_targetValue_INVOKE (HandleRef classPointer);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="new_NxSpringDesc")]
        private extern static IntPtr new_NxSpringDesc_INVOKE (System.Boolean do_override);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="new_NxSpringDesc_1")]
        private extern static IntPtr new_NxSpringDesc_1_INVOKE (System.Boolean do_override, System.Single spring, System.Single damper, System.Single targetValue);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="new_NxSpringDesc_2")]
        private extern static IntPtr new_NxSpringDesc_2_INVOKE (System.Boolean do_override, System.Single spring, System.Single damper);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="new_NxSpringDesc_3")]
        private extern static IntPtr new_NxSpringDesc_3_INVOKE (System.Boolean do_override, System.Single spring);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxSpringDesc_setToDefault")]
        private extern static void NxSpringDesc_setToDefault_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxSpringDesc_isValid")]
        private extern static System.Boolean NxSpringDesc_isValid_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

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
		
		public static NxSpringDesc GetClass(IntPtr ptr)
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
					return ((NxSpringDesc)(obj.Target));
				}
			}
			return new NxSpringDesc(ptr);
		}
		
		protected override System.Collections.Generic.List<System.IntPtr> CreateFunctionPointers()
		{
			System.Collections.Generic.List<System.IntPtr> list = base.CreateFunctionPointers();
			return list;
		}
	}
}
