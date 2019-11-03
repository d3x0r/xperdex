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
	
	
	public class NxContactStreamIterator : DoxyBindObject
	{
		
		internal NxContactStreamIterator(IntPtr ptr) : 
				base(ptr)
		{
		}
		
		/// <summary>Starts the iteration, and returns the number of pairs. </summary>
		/// <param name="stream"></param>
		public NxContactStreamIterator(uint stream) : 
				base(new_NxContactStreamIterator_INVOKE(false, stream))
		{
			GC.ReRegisterForFinalize(this);
		}
		
		/// <summary>Goes on to the next pair, silently skipping invalid pairs. </summary>
		public bool goNextPair()
		{
			return NxContactStreamIterator_goNextPair_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		/// <summary>Goes on to the next patch (contacts with the same normal). </summary>
		public bool goNextPatch()
		{
			return NxContactStreamIterator_goNextPatch_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		/// <summary>Goes on to the next contact point. </summary>
		public bool goNextPoint()
		{
			return NxContactStreamIterator_goNextPoint_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		/// <summary>Returns the number of pairs in the structure. </summary>
		public uint getNumPairs()
		{
			return NxContactStreamIterator_getNumPairs_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		/// <summary>Retrieves the shapes for the current pair. </summary>
		/// <param name="shapeIndex">Used to choose which of the pair of shapes to retrieve(set to 0 or 1). </param>
		public NxShape getShape(uint shapeIndex)
		{
			return NxShape.GetClass(NxContactStreamIterator_getShape_INVOKE(ClassPointer, doSetFunctionPointers, shapeIndex));
		}
		
		/// <summary>Retrieves the shape flags for the current pair. </summary>
		public ushort getShapeFlags()
		{
			return NxContactStreamIterator_getShapeFlags_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		/// <summary>Retrieves the number of patches for the current pair. </summary>
		public uint getNumPatches()
		{
			return NxContactStreamIterator_getNumPatches_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		/// <summary>Retrieves the number of remaining patches. </summary>
		public uint getNumPatchesRemaining()
		{
			return NxContactStreamIterator_getNumPatchesRemaining_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		/// <summary>Retrieves the patch normal. </summary>
		public NxVec3[] getPatchNormal()
		{
			return NxContactStreamIterator_getPatchNormal_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		/// <summary>Retrieves the number of points in the current patch. </summary>
		public uint getNumPoints()
		{
			return NxContactStreamIterator_getNumPoints_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		/// <summary>Retrieves the number of points remaining in the current patch. </summary>
		public uint getNumPointsRemaining()
		{
			return NxContactStreamIterator_getNumPointsRemaining_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		/// <summary>Returns the contact point position. </summary>
		public NxVec3[] getPoint()
		{
			return NxContactStreamIterator_getPoint_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		/// <summary>Return the separation for the contact point. </summary>
		public float getSeparation()
		{
			return NxContactStreamIterator_getSeparation_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		/// <summary>Retrieves the feature index. </summary>
		public uint getFeatureIndex0()
		{
			return NxContactStreamIterator_getFeatureIndex0_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		/// <summary>Retrieves the feature index. </summary>
		public uint getFeatureIndex1()
		{
			return NxContactStreamIterator_getFeatureIndex1_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		/// <summary>Retrieves the point normal force. </summary>
		public float getPointNormalForce()
		{
			return NxContactStreamIterator_getPointNormalForce_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		#region Imports
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="new_NxContactStreamIterator")]
        private extern static IntPtr new_NxContactStreamIterator_INVOKE (System.Boolean do_override, System.UInt32 stream);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxContactStreamIterator_goNextPair")]
        private extern static System.Boolean NxContactStreamIterator_goNextPair_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxContactStreamIterator_goNextPatch")]
        private extern static System.Boolean NxContactStreamIterator_goNextPatch_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxContactStreamIterator_goNextPoint")]
        private extern static System.Boolean NxContactStreamIterator_goNextPoint_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxContactStreamIterator_getNumPairs")]
        private extern static System.UInt32 NxContactStreamIterator_getNumPairs_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxContactStreamIterator_getShape")]
        private extern static IntPtr NxContactStreamIterator_getShape_INVOKE (HandleRef classPointer, System.Boolean call_explicit, System.UInt32 shapeIndex);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxContactStreamIterator_getShapeFlags")]
        private extern static System.UInt16 NxContactStreamIterator_getShapeFlags_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxContactStreamIterator_getNumPatches")]
        private extern static System.UInt32 NxContactStreamIterator_getNumPatches_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxContactStreamIterator_getNumPatchesRemaining")]
        private extern static System.UInt32 NxContactStreamIterator_getNumPatchesRemaining_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxContactStreamIterator_getPatchNormal")]
        private extern static NxVec3[] NxContactStreamIterator_getPatchNormal_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxContactStreamIterator_getNumPoints")]
        private extern static System.UInt32 NxContactStreamIterator_getNumPoints_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxContactStreamIterator_getNumPointsRemaining")]
        private extern static System.UInt32 NxContactStreamIterator_getNumPointsRemaining_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxContactStreamIterator_getPoint")]
        private extern static NxVec3[] NxContactStreamIterator_getPoint_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxContactStreamIterator_getSeparation")]
        private extern static System.Single NxContactStreamIterator_getSeparation_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxContactStreamIterator_getFeatureIndex0")]
        private extern static System.UInt32 NxContactStreamIterator_getFeatureIndex0_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxContactStreamIterator_getFeatureIndex1")]
        private extern static System.UInt32 NxContactStreamIterator_getFeatureIndex1_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxContactStreamIterator_getPointNormalForce")]
        private extern static System.Single NxContactStreamIterator_getPointNormalForce_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

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
		
		public static NxContactStreamIterator GetClass(IntPtr ptr)
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
					return ((NxContactStreamIterator)(obj.Target));
				}
			}
			return new NxContactStreamIterator(ptr);
		}
		
		protected override System.Collections.Generic.List<System.IntPtr> CreateFunctionPointers()
		{
			System.Collections.Generic.List<System.IntPtr> list = base.CreateFunctionPointers();
			return list;
		}
	}
}
