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
	
	
	public class NxFluidUserNotify : DoxyBindObject
	{
		
		internal NxFluidUserNotify(IntPtr ptr) : 
				base(ptr)
		{
		}
		
		/// <summary>This is called during NxScene::fetchResults with fluid emitters that have events. </summary>
		/// <param name="emitter">- The emitter which had the event. </param>
		/// <param name="eventType">- The event type. </param>
		public virtual bool onEmitterEvent(NxFluidEmitter emitter, NxFluidEmitterEventType eventType)
		{
			if (doSetFunctionPointers)
			{
				throw new System.NotSupportedException("Cannot call abstract base member");
			}
			return NxFluidUserNotify_onEmitterEvent_INVOKE(ClassPointer, doSetFunctionPointers, (emitter!=null ? emitter.ClassPointer : NullRef), eventType);
		}
		
		private bool onEmitterEvent_virtual(IntPtr emitter, NxFluidEmitterEventType eventType)
		{
			return onEmitterEvent(NxFluidEmitter.GetClass(emitter), eventType);
		}
		
		delegate bool onEmitterEvent_0_delegate(IntPtr emitter, NxFluidEmitterEventType eventType);
		
		
		
		
		
		
		private onEmitterEvent_0_delegate onEmitterEvent_0_delegatefield;
		
		/// <summary>This is called during NxScene::fetchResults with fluids that have events. </summary>
		/// <param name="fluid">- The fluid which had the event. </param>
		/// <param name="eventType">- The event type. </param>
		public virtual bool onEvent(NxFluid fluid, NxFluidEventType eventType)
		{
			if (doSetFunctionPointers)
			{
				throw new System.NotSupportedException("Cannot call abstract base member");
			}
			return NxFluidUserNotify_onEvent_INVOKE(ClassPointer, doSetFunctionPointers, (fluid!=null ? fluid.ClassPointer : NullRef), eventType);
		}
		
		private bool onEvent_virtual(IntPtr fluid, NxFluidEventType eventType)
		{
			return onEvent(NxFluid.GetClass(fluid), eventType);
		}
		
		delegate bool onEvent_1_delegate(IntPtr fluid, NxFluidEventType eventType);
		
		
		
		
		
		
		private onEvent_1_delegate onEvent_1_delegatefield;
		
		#region Imports
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxFluidUserNotify_onEmitterEvent")]
        private extern static System.Boolean NxFluidUserNotify_onEmitterEvent_INVOKE (HandleRef classPointer, System.Boolean call_explicit, HandleRef emitter, NxFluidEmitterEventType eventType);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxFluidUserNotify_onEvent")]
        private extern static System.Boolean NxFluidUserNotify_onEvent_INVOKE (HandleRef classPointer, System.Boolean call_explicit, HandleRef fluid, NxFluidEventType eventType);

		#endregion
		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="new_NxFluidUserNotify")]
        private extern static IntPtr new_NxFluidUserNotify_INVOKE (bool do_override);

		
		protected NxFluidUserNotify() : 
				base(IntPtr.Zero)
		{
			GC.ReRegisterForFinalize(this);
			if ((GetType() != typeof(NxFluidUserNotify)))
			{
				doSetFunctionPointers = true;
				SetPointer(new_NxFluidUserNotify_INVOKE(doSetFunctionPointers));
				System.IntPtr[] pointers = CreateFunctionPointers().ToArray();
				set_pointers_INVOKE(ClassPointer, pointers, pointers.Length);
			}
			else
			{
				SetPointer(new_NxFluidUserNotify_INVOKE(doSetFunctionPointers));
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
		
		public static NxFluidUserNotify GetClass(IntPtr ptr)
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
					return ((NxFluidUserNotify)(obj.Target));
				}
			}
			return new NxFluidUserNotify(ptr);
		}
		
		protected override System.Collections.Generic.List<System.IntPtr> CreateFunctionPointers()
		{
			System.Collections.Generic.List<System.IntPtr> list = base.CreateFunctionPointers();
			onEmitterEvent_0_delegatefield = new onEmitterEvent_0_delegate(this.onEmitterEvent_virtual);
			list.Add(Marshal.GetFunctionPointerForDelegate(onEmitterEvent_0_delegatefield));
			onEvent_1_delegatefield = new onEvent_1_delegate(this.onEvent_virtual);
			list.Add(Marshal.GetFunctionPointerForDelegate(onEvent_1_delegatefield));
			return list;
		}
	}
}
