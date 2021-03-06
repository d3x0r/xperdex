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
	
	
	public class ControllerManagerAllocator : NxUserAllocator
	{
		
		internal ControllerManagerAllocator(IntPtr ptr) : 
				base(ptr)
		{
		}
		
		/// <summary>Allocates size bytes of memory. </summary>
		/// <param name="size">Number of bytes to allocate. </param>
		/// <param name="fileName">File which is allocating the memory. </param>
		/// <param name="line">Line which is allocating the memory. </param>
		public override System.IntPtr mallocDEBUG(System.IntPtr size, string fileName, int line)
		{
			return ControllerManagerAllocator_mallocDEBUG_INVOKE(ClassPointer, doSetFunctionPointers, size, fileName, line);
		}
		
		private System.IntPtr mallocDEBUG_virtual(System.IntPtr size, string fileName, int line)
		{
			return mallocDEBUG(size, fileName, line);
		}
		
		delegate System.IntPtr mallocDEBUG_0_delegate(System.IntPtr size, string fileName, int line);
		
		
		
		
		
		
		private mallocDEBUG_0_delegate mallocDEBUG_0_delegatefield;
		
		/// <summary>Allocates size bytes of memory. </summary>
		/// <param name="size">Number of bytes to allocate. </param>
		public override System.IntPtr malloc(System.IntPtr size)
		{
			return ControllerManagerAllocator_malloc_INVOKE(ClassPointer, doSetFunctionPointers, size);
		}
		
		private System.IntPtr malloc_virtual(System.IntPtr size)
		{
			return malloc(size);
		}
		
		delegate System.IntPtr malloc_1_delegate(System.IntPtr size);
		
		
		
		
		
		
		private malloc_1_delegate malloc_1_delegatefield;
		
		/// <summary>Resizes the memory block previously allocated with malloc() or realloc() to be size() bytes, and returns the possibly moved memory. </summary>
		/// <param name="memory">Memory block to change the size of. </param>
		/// <param name="size">New size for memory block. </param>
		public override System.IntPtr realloc(System.IntPtr memory, System.IntPtr size)
		{
			return ControllerManagerAllocator_realloc_INVOKE(ClassPointer, doSetFunctionPointers, memory, size);
		}
		
		private System.IntPtr realloc_virtual(System.IntPtr memory, System.IntPtr size)
		{
			return realloc(memory, size);
		}
		
		delegate System.IntPtr realloc_2_delegate(System.IntPtr memory, System.IntPtr size);
		
		
		
		
		
		
		private realloc_2_delegate realloc_2_delegatefield;
		
		/// <summary>Frees the memory previously allocated by malloc() or realloc(). </summary>
		/// <param name="memory">Memory to free. </param>
		public override void free(System.IntPtr memory)
		{
			ControllerManagerAllocator_free_INVOKE(ClassPointer, doSetFunctionPointers, memory);
		}
		
		private void free_virtual(System.IntPtr memory)
		{
			free(memory);
		}
		
		delegate void free_3_delegate(System.IntPtr memory);
		
		
		
		
		
		
		private free_3_delegate free_3_delegatefield;
		
		#region Imports
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="ControllerManagerAllocator_mallocDEBUG")]
        private extern static System.IntPtr ControllerManagerAllocator_mallocDEBUG_INVOKE (HandleRef classPointer, System.Boolean call_explicit, System.IntPtr size, System.String fileName, System.Int32 line);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="ControllerManagerAllocator_malloc")]
        private extern static System.IntPtr ControllerManagerAllocator_malloc_INVOKE (HandleRef classPointer, System.Boolean call_explicit, System.IntPtr size);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="ControllerManagerAllocator_realloc")]
        private extern static System.IntPtr ControllerManagerAllocator_realloc_INVOKE (HandleRef classPointer, System.Boolean call_explicit, System.IntPtr memory, System.IntPtr size);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="ControllerManagerAllocator_free")]
        private extern static void ControllerManagerAllocator_free_INVOKE (HandleRef classPointer, System.Boolean call_explicit, System.IntPtr memory);

		#endregion
		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="new_ControllerManagerAllocator")]
        private extern static IntPtr new_ControllerManagerAllocator_INVOKE (bool do_override);

		
		public ControllerManagerAllocator() : 
				base(IntPtr.Zero)
		{
			GC.ReRegisterForFinalize(this);
			if ((GetType() != typeof(ControllerManagerAllocator)))
			{
				doSetFunctionPointers = true;
				SetPointer(new_ControllerManagerAllocator_INVOKE(doSetFunctionPointers));
				System.IntPtr[] pointers = CreateFunctionPointers().ToArray();
				set_pointers_INVOKE(ClassPointer, pointers, pointers.Length);
			}
			else
			{
				SetPointer(new_ControllerManagerAllocator_INVOKE(doSetFunctionPointers));
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
		
		public static ControllerManagerAllocator GetClass(IntPtr ptr)
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
					return ((ControllerManagerAllocator)(obj.Target));
				}
			}
			return new ControllerManagerAllocator(ptr);
		}
		
		protected override System.Collections.Generic.List<System.IntPtr> CreateFunctionPointers()
		{
			System.Collections.Generic.List<System.IntPtr> list = base.CreateFunctionPointers();
			mallocDEBUG_0_delegatefield = new mallocDEBUG_0_delegate(this.mallocDEBUG_virtual);
			list.Add(Marshal.GetFunctionPointerForDelegate(mallocDEBUG_0_delegatefield));
			malloc_1_delegatefield = new malloc_1_delegate(this.malloc_virtual);
			list.Add(Marshal.GetFunctionPointerForDelegate(malloc_1_delegatefield));
			realloc_2_delegatefield = new realloc_2_delegate(this.realloc_virtual);
			list.Add(Marshal.GetFunctionPointerForDelegate(realloc_2_delegatefield));
			free_3_delegatefield = new free_3_delegate(this.free_virtual);
			list.Add(Marshal.GetFunctionPointerForDelegate(free_3_delegatefield));
			return list;
		}
	}
}
