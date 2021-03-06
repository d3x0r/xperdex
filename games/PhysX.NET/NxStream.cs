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
	
	
	public class NxStream : DoxyBindObject
	{
		
		internal NxStream(IntPtr ptr) : 
				base(ptr)
		{
		}
		
		/// <summary>Empty constructor. </summary>
		public NxStream() : 
				base(IntPtr.Zero)
		{
			if ((GetType() != typeof(NxStream)))
			{
				doSetFunctionPointers = true;
				SetPointer(new_NxStream_INVOKE(doSetFunctionPointers));
				System.IntPtr[] pointers = CreateFunctionPointers().ToArray();
				set_pointers_INVOKE(ClassPointer, pointers, pointers.Length);
			}
			else
			{
				SetPointer(new_NxStream_INVOKE(doSetFunctionPointers));
			}
			GC.ReRegisterForFinalize(this);
		}
		
		/// <summary>Called to read a single unsigned byte(8 bits). </summary>
		public virtual byte readByte()
		{
			if (doSetFunctionPointers)
			{
				throw new System.NotSupportedException("Cannot call abstract base member");
			}
			return NxStream_readByte_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		private byte readByte_virtual()
		{
			return readByte();
		}
		
		delegate byte readByte_0_delegate();
		
		
		
		
		
		
		private readByte_0_delegate readByte_0_delegatefield;
		
		/// <summary>Called to read a single unsigned word(16 bits). </summary>
		public virtual ushort readWord()
		{
			if (doSetFunctionPointers)
			{
				throw new System.NotSupportedException("Cannot call abstract base member");
			}
			return NxStream_readWord_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		private ushort readWord_virtual()
		{
			return readWord();
		}
		
		delegate ushort readWord_1_delegate();
		
		
		
		
		
		
		private readWord_1_delegate readWord_1_delegatefield;
		
		/// <summary>Called to read a single unsigned dword(32 bits). </summary>
		public virtual uint readDword()
		{
			if (doSetFunctionPointers)
			{
				throw new System.NotSupportedException("Cannot call abstract base member");
			}
			return NxStream_readDword_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		private uint readDword_virtual()
		{
			return readDword();
		}
		
		delegate uint readDword_2_delegate();
		
		
		
		
		
		
		private readDword_2_delegate readDword_2_delegatefield;
		
		/// <summary>Called to read a single precision floating point value(32 bits). </summary>
		public virtual float readFloat()
		{
			if (doSetFunctionPointers)
			{
				throw new System.NotSupportedException("Cannot call abstract base member");
			}
			return NxStream_readFloat_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		private float readFloat_virtual()
		{
			return readFloat();
		}
		
		delegate float readFloat_3_delegate();
		
		
		
		
		
		
		private readFloat_3_delegate readFloat_3_delegatefield;
		
		/// <summary>Called to read a double precision floating point value(64 bits). </summary>
		public virtual double readDouble()
		{
			if (doSetFunctionPointers)
			{
				throw new System.NotSupportedException("Cannot call abstract base member");
			}
			return NxStream_readDouble_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		private double readDouble_virtual()
		{
			return readDouble();
		}
		
		delegate double readDouble_4_delegate();
		
		
		
		
		
		
		private readDouble_4_delegate readDouble_4_delegatefield;
		
		/// <summary>Called to read a number of bytes. </summary>
		/// <param name="buffer">Buffer to read bytes into, must be at least size bytes in size. </param>
		/// <param name="size">The size of the buffer in bytes. </param>
		public virtual void readBuffer(System.IntPtr buffer, uint size)
		{
			if (doSetFunctionPointers)
			{
				throw new System.NotSupportedException("Cannot call abstract base member");
			}
			NxStream_readBuffer_INVOKE(ClassPointer, doSetFunctionPointers, buffer, size);
		}
		
		private void readBuffer_virtual(System.IntPtr buffer, uint size)
		{
			readBuffer(buffer, size);
		}
		
		delegate void readBuffer_5_delegate(System.IntPtr buffer, uint size);
		
		
		
		
		
		
		private readBuffer_5_delegate readBuffer_5_delegatefield;
		
		/// <summary>Called to write a single unsigned byte to the stream(8 bits). </summary>
		/// <param name="b">Byte to store. </param>
		public virtual NxStream storeByte(byte b)
		{
			if (doSetFunctionPointers)
			{
				throw new System.NotSupportedException("Cannot call abstract base member");
			}
			return NxStream.GetClass(NxStream_storeByte_INVOKE(ClassPointer, doSetFunctionPointers, b));
		}
		
		private IntPtr storeByte_virtual(byte b)
		{
			return storeByte(b).ClassPointer.Handle;
		}
		
		delegate IntPtr storeByte_6_delegate(byte b);
		
		
		
		
		
		
		private storeByte_6_delegate storeByte_6_delegatefield;
		
		/// <summary>Called to write a single unsigned word to the stream(16 bits). </summary>
		/// <param name="w">World to store. </param>
		public virtual NxStream storeWord(ushort w)
		{
			if (doSetFunctionPointers)
			{
				throw new System.NotSupportedException("Cannot call abstract base member");
			}
			return NxStream.GetClass(NxStream_storeWord_INVOKE(ClassPointer, doSetFunctionPointers, w));
		}
		
		private IntPtr storeWord_virtual(ushort w)
		{
			return storeWord(w).ClassPointer.Handle;
		}
		
		delegate IntPtr storeWord_7_delegate(ushort w);
		
		
		
		
		
		
		private storeWord_7_delegate storeWord_7_delegatefield;
		
		/// <summary>Called to write a single unsigned dword to the stream(32 bits). </summary>
		/// <param name="d">DWord to store. </param>
		public virtual NxStream storeDword(uint d)
		{
			if (doSetFunctionPointers)
			{
				throw new System.NotSupportedException("Cannot call abstract base member");
			}
			return NxStream.GetClass(NxStream_storeDword_INVOKE(ClassPointer, doSetFunctionPointers, d));
		}
		
		private IntPtr storeDword_virtual(uint d)
		{
			return storeDword(d).ClassPointer.Handle;
		}
		
		delegate IntPtr storeDword_8_delegate(uint d);
		
		
		
		
		
		
		private storeDword_8_delegate storeDword_8_delegatefield;
		
		/// <summary>Called to write a single precision floating point value to the stream(32 bits). </summary>
		/// <param name="f">floating point value to store. </param>
		public virtual NxStream storeFloat(float f)
		{
			if (doSetFunctionPointers)
			{
				throw new System.NotSupportedException("Cannot call abstract base member");
			}
			return NxStream.GetClass(NxStream_storeFloat_INVOKE(ClassPointer, doSetFunctionPointers, f));
		}
		
		private IntPtr storeFloat_virtual(float f)
		{
			return storeFloat(f).ClassPointer.Handle;
		}
		
		delegate IntPtr storeFloat_9_delegate(float f);
		
		
		
		
		
		
		private storeFloat_9_delegate storeFloat_9_delegatefield;
		
		/// <summary>Called to write a double precision floating point value to the stream(64 bits). </summary>
		/// <param name="f">floating point value to store. </param>
		public virtual NxStream storeDouble(double f)
		{
			if (doSetFunctionPointers)
			{
				throw new System.NotSupportedException("Cannot call abstract base member");
			}
			return NxStream.GetClass(NxStream_storeDouble_INVOKE(ClassPointer, doSetFunctionPointers, f));
		}
		
		private IntPtr storeDouble_virtual(double f)
		{
			return storeDouble(f).ClassPointer.Handle;
		}
		
		delegate IntPtr storeDouble_10_delegate(double f);
		
		
		
		
		
		
		private storeDouble_10_delegate storeDouble_10_delegatefield;
		
		/// <summary>Called to write an array of bytes to the stream. </summary>
		/// <param name="buffer">Array of bytes, size bytes in size. </param>
		/// <param name="size">Size, in bytes of buffer. </param>
		public virtual NxStream storeBuffer(System.IntPtr buffer, uint size)
		{
			if (doSetFunctionPointers)
			{
				throw new System.NotSupportedException("Cannot call abstract base member");
			}
			return NxStream.GetClass(NxStream_storeBuffer_INVOKE(ClassPointer, doSetFunctionPointers, buffer, size));
		}
		
		private IntPtr storeBuffer_virtual(System.IntPtr buffer, uint size)
		{
			return storeBuffer(buffer, size).ClassPointer.Handle;
		}
		
		delegate IntPtr storeBuffer_11_delegate(System.IntPtr buffer, uint size);
		
		
		
		
		
		
		private storeBuffer_11_delegate storeBuffer_11_delegatefield;
		
		/// <summary>Store a signed byte(wrapper for the unsigned version). </summary>
		/// <param name="b">Byte to store. </param>
		public NxStream storeByte(sbyte b)
		{
			return NxStream.GetClass(NxStream_storeByte_1_INVOKE(ClassPointer, doSetFunctionPointers, b));
		}
		
		/// <summary>Store a signed word(wrapper for the unsigned version). </summary>
		/// <param name="w">Word to store. </param>
		public NxStream storeWord(short w)
		{
			return NxStream.GetClass(NxStream_storeWord_1_INVOKE(ClassPointer, doSetFunctionPointers, w));
		}
		
		/// <summary>Store a signed dword(wrapper for the unsigned version). </summary>
		/// <param name="d">DWord to store. </param>
		public NxStream storeDword(int d)
		{
			return NxStream.GetClass(NxStream_storeDword_1_INVOKE(ClassPointer, doSetFunctionPointers, d));
		}
		
		#region Imports
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="new_NxStream")]
        private extern static IntPtr new_NxStream_INVOKE (System.Boolean do_override);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxStream_readByte")]
        private extern static System.Byte NxStream_readByte_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxStream_readWord")]
        private extern static System.UInt16 NxStream_readWord_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxStream_readDword")]
        private extern static System.UInt32 NxStream_readDword_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxStream_readFloat")]
        private extern static System.Single NxStream_readFloat_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxStream_readDouble")]
        private extern static System.Double NxStream_readDouble_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxStream_readBuffer")]
        private extern static void NxStream_readBuffer_INVOKE (HandleRef classPointer, System.Boolean call_explicit, System.IntPtr buffer, System.UInt32 size);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxStream_storeByte")]
        private extern static IntPtr NxStream_storeByte_INVOKE (HandleRef classPointer, System.Boolean call_explicit, System.Byte b);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxStream_storeWord")]
        private extern static IntPtr NxStream_storeWord_INVOKE (HandleRef classPointer, System.Boolean call_explicit, System.UInt16 w);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxStream_storeDword")]
        private extern static IntPtr NxStream_storeDword_INVOKE (HandleRef classPointer, System.Boolean call_explicit, System.UInt32 d);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxStream_storeFloat")]
        private extern static IntPtr NxStream_storeFloat_INVOKE (HandleRef classPointer, System.Boolean call_explicit, System.Single f);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxStream_storeDouble")]
        private extern static IntPtr NxStream_storeDouble_INVOKE (HandleRef classPointer, System.Boolean call_explicit, System.Double f);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxStream_storeBuffer")]
        private extern static IntPtr NxStream_storeBuffer_INVOKE (HandleRef classPointer, System.Boolean call_explicit, System.IntPtr buffer, System.UInt32 size);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxStream_storeByte_1")]
        private extern static IntPtr NxStream_storeByte_1_INVOKE (HandleRef classPointer, System.Boolean call_explicit, System.SByte b);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxStream_storeWord_1")]
        private extern static IntPtr NxStream_storeWord_1_INVOKE (HandleRef classPointer, System.Boolean call_explicit, System.Int16 w);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxStream_storeDword_1")]
        private extern static IntPtr NxStream_storeDword_1_INVOKE (HandleRef classPointer, System.Boolean call_explicit, System.Int32 d);

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
		
		public static NxStream GetClass(IntPtr ptr)
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
					return ((NxStream)(obj.Target));
				}
			}
			return new NxStream(ptr);
		}
		
		protected override System.Collections.Generic.List<System.IntPtr> CreateFunctionPointers()
		{
			System.Collections.Generic.List<System.IntPtr> list = base.CreateFunctionPointers();
			readByte_0_delegatefield = new readByte_0_delegate(this.readByte_virtual);
			list.Add(Marshal.GetFunctionPointerForDelegate(readByte_0_delegatefield));
			readWord_1_delegatefield = new readWord_1_delegate(this.readWord_virtual);
			list.Add(Marshal.GetFunctionPointerForDelegate(readWord_1_delegatefield));
			readDword_2_delegatefield = new readDword_2_delegate(this.readDword_virtual);
			list.Add(Marshal.GetFunctionPointerForDelegate(readDword_2_delegatefield));
			readFloat_3_delegatefield = new readFloat_3_delegate(this.readFloat_virtual);
			list.Add(Marshal.GetFunctionPointerForDelegate(readFloat_3_delegatefield));
			readDouble_4_delegatefield = new readDouble_4_delegate(this.readDouble_virtual);
			list.Add(Marshal.GetFunctionPointerForDelegate(readDouble_4_delegatefield));
			readBuffer_5_delegatefield = new readBuffer_5_delegate(this.readBuffer_virtual);
			list.Add(Marshal.GetFunctionPointerForDelegate(readBuffer_5_delegatefield));
			storeByte_6_delegatefield = new storeByte_6_delegate(this.storeByte_virtual);
			list.Add(Marshal.GetFunctionPointerForDelegate(storeByte_6_delegatefield));
			storeWord_7_delegatefield = new storeWord_7_delegate(this.storeWord_virtual);
			list.Add(Marshal.GetFunctionPointerForDelegate(storeWord_7_delegatefield));
			storeDword_8_delegatefield = new storeDword_8_delegate(this.storeDword_virtual);
			list.Add(Marshal.GetFunctionPointerForDelegate(storeDword_8_delegatefield));
			storeFloat_9_delegatefield = new storeFloat_9_delegate(this.storeFloat_virtual);
			list.Add(Marshal.GetFunctionPointerForDelegate(storeFloat_9_delegatefield));
			storeDouble_10_delegatefield = new storeDouble_10_delegate(this.storeDouble_virtual);
			list.Add(Marshal.GetFunctionPointerForDelegate(storeDouble_10_delegatefield));
			storeBuffer_11_delegatefield = new storeBuffer_11_delegate(this.storeBuffer_virtual);
			list.Add(Marshal.GetFunctionPointerForDelegate(storeBuffer_11_delegatefield));
			return list;
		}
	}
}
