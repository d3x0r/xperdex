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
	
	
	public class NxForceFieldLinearKernel : NxForceFieldKernel
	{
		
		internal NxForceFieldLinearKernel(IntPtr ptr) : 
				base(ptr)
		{
		}
		
		/// <summary></summary>
		protected NxForceFieldLinearKernel() : 
				base(IntPtr.Zero)
		{
			if ((GetType() != typeof(NxForceFieldLinearKernel)))
			{
				doSetFunctionPointers = true;
				SetPointer(new_NxForceFieldLinearKernel_INVOKE(doSetFunctionPointers));
				System.IntPtr[] pointers = CreateFunctionPointers().ToArray();
				set_pointers_INVOKE(ClassPointer, pointers, pointers.Length);
			}
			else
			{
				SetPointer(new_NxForceFieldLinearKernel_INVOKE(doSetFunctionPointers));
			}
			GC.ReRegisterForFinalize(this);
		}
		
		/// <summary>Gets the constant part of force field function. </summary>
		public virtual NxVec3 getConstant()
		{
			if (doSetFunctionPointers)
			{
				throw new System.NotSupportedException("Cannot call abstract base member");
			}
			return NxForceFieldLinearKernel_getConstant_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		private NxVec3 getConstant_virtual()
		{
			return getConstant();
		}
		
		delegate NxVec3 getConstant_0_delegate();
		
		
		
		
		
		
		private getConstant_0_delegate getConstant_0_delegatefield;
		
		/// <summary>Sets the constant part of force field function. </summary>
		public virtual void setConstant(ref NxVec3 unknown11)
		{
			if (doSetFunctionPointers)
			{
				throw new System.NotSupportedException("Cannot call abstract base member");
			}
			NxForceFieldLinearKernel_setConstant_INVOKE(ClassPointer, doSetFunctionPointers, ref unknown11);
		}
		
		private void setConstant_virtual([In()] ref NxVec3 unknown11)
		{
			setConstant(ref unknown11);
		}
		
		delegate void setConstant_1_delegate([In()] ref NxVec3 unknown11);
		
		
		
		
		
		
		private setConstant_1_delegate setConstant_1_delegatefield;
		
		/// <summary>Gets the coefficient of force field function position term. </summary>
		public virtual NxMat33 getPositionMultiplier()
		{
			if (doSetFunctionPointers)
			{
				throw new System.NotSupportedException("Cannot call abstract base member");
			}
			return NxForceFieldLinearKernel_getPositionMultiplier_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		private NxMat33 getPositionMultiplier_virtual()
		{
			return getPositionMultiplier();
		}
		
		delegate NxMat33 getPositionMultiplier_2_delegate();
		
		
		
		
		
		
		private getPositionMultiplier_2_delegate getPositionMultiplier_2_delegatefield;
		
		/// <summary>Sets the coefficient of force field function position term. </summary>
		public virtual void setPositionMultiplier(ref NxMat33 unknown12)
		{
			if (doSetFunctionPointers)
			{
				throw new System.NotSupportedException("Cannot call abstract base member");
			}
			NxForceFieldLinearKernel_setPositionMultiplier_INVOKE(ClassPointer, doSetFunctionPointers, ref unknown12);
		}
		
		private void setPositionMultiplier_virtual([In()] ref NxMat33 unknown12)
		{
			setPositionMultiplier(ref unknown12);
		}
		
		delegate void setPositionMultiplier_3_delegate([In()] ref NxMat33 unknown12);
		
		
		
		
		
		
		private setPositionMultiplier_3_delegate setPositionMultiplier_3_delegatefield;
		
		/// <summary>Gets the coefficient of force field function velocity term. </summary>
		public virtual NxMat33 getVelocityMultiplier()
		{
			if (doSetFunctionPointers)
			{
				throw new System.NotSupportedException("Cannot call abstract base member");
			}
			return NxForceFieldLinearKernel_getVelocityMultiplier_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		private NxMat33 getVelocityMultiplier_virtual()
		{
			return getVelocityMultiplier();
		}
		
		delegate NxMat33 getVelocityMultiplier_4_delegate();
		
		
		
		
		
		
		private getVelocityMultiplier_4_delegate getVelocityMultiplier_4_delegatefield;
		
		/// <summary>Sets the coefficient of force field function velocity term. </summary>
		public virtual void setVelocityMultiplier(ref NxMat33 unknown13)
		{
			if (doSetFunctionPointers)
			{
				throw new System.NotSupportedException("Cannot call abstract base member");
			}
			NxForceFieldLinearKernel_setVelocityMultiplier_INVOKE(ClassPointer, doSetFunctionPointers, ref unknown13);
		}
		
		private void setVelocityMultiplier_virtual([In()] ref NxMat33 unknown13)
		{
			setVelocityMultiplier(ref unknown13);
		}
		
		delegate void setVelocityMultiplier_5_delegate([In()] ref NxMat33 unknown13);
		
		
		
		
		
		
		private setVelocityMultiplier_5_delegate setVelocityMultiplier_5_delegatefield;
		
		/// <summary>Gets the force field position target. </summary>
		public virtual NxVec3 getPositionTarget()
		{
			if (doSetFunctionPointers)
			{
				throw new System.NotSupportedException("Cannot call abstract base member");
			}
			return NxForceFieldLinearKernel_getPositionTarget_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		private NxVec3 getPositionTarget_virtual()
		{
			return getPositionTarget();
		}
		
		delegate NxVec3 getPositionTarget_6_delegate();
		
		
		
		
		
		
		private getPositionTarget_6_delegate getPositionTarget_6_delegatefield;
		
		/// <summary>Sets the force field position target. </summary>
		public virtual void setPositionTarget(ref NxVec3 unknown14)
		{
			if (doSetFunctionPointers)
			{
				throw new System.NotSupportedException("Cannot call abstract base member");
			}
			NxForceFieldLinearKernel_setPositionTarget_INVOKE(ClassPointer, doSetFunctionPointers, ref unknown14);
		}
		
		private void setPositionTarget_virtual([In()] ref NxVec3 unknown14)
		{
			setPositionTarget(ref unknown14);
		}
		
		delegate void setPositionTarget_7_delegate([In()] ref NxVec3 unknown14);
		
		
		
		
		
		
		private setPositionTarget_7_delegate setPositionTarget_7_delegatefield;
		
		/// <summary>Gets the force field velocity target. Platform:. </summary>
		public virtual NxVec3 getVelocityTarget()
		{
			if (doSetFunctionPointers)
			{
				throw new System.NotSupportedException("Cannot call abstract base member");
			}
			return NxForceFieldLinearKernel_getVelocityTarget_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		private NxVec3 getVelocityTarget_virtual()
		{
			return getVelocityTarget();
		}
		
		delegate NxVec3 getVelocityTarget_8_delegate();
		
		
		
		
		
		
		private getVelocityTarget_8_delegate getVelocityTarget_8_delegatefield;
		
		/// <summary>Sets the force field velocity target. Platform:. </summary>
		public virtual void setVelocityTarget(ref NxVec3 unknown15)
		{
			if (doSetFunctionPointers)
			{
				throw new System.NotSupportedException("Cannot call abstract base member");
			}
			NxForceFieldLinearKernel_setVelocityTarget_INVOKE(ClassPointer, doSetFunctionPointers, ref unknown15);
		}
		
		private void setVelocityTarget_virtual([In()] ref NxVec3 unknown15)
		{
			setVelocityTarget(ref unknown15);
		}
		
		delegate void setVelocityTarget_9_delegate([In()] ref NxVec3 unknown15);
		
		
		
		
		
		
		private setVelocityTarget_9_delegate setVelocityTarget_9_delegatefield;
		
		/// <summary>Sets the linear falloff term. Platform:. </summary>
		public virtual NxVec3 getFalloffLinear()
		{
			if (doSetFunctionPointers)
			{
				throw new System.NotSupportedException("Cannot call abstract base member");
			}
			return NxForceFieldLinearKernel_getFalloffLinear_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		private NxVec3 getFalloffLinear_virtual()
		{
			return getFalloffLinear();
		}
		
		delegate NxVec3 getFalloffLinear_10_delegate();
		
		
		
		
		
		
		private getFalloffLinear_10_delegate getFalloffLinear_10_delegatefield;
		
		/// <summary>Sets the linear falloff term. Platform:. </summary>
		public virtual void setFalloffLinear(ref NxVec3 unknown16)
		{
			if (doSetFunctionPointers)
			{
				throw new System.NotSupportedException("Cannot call abstract base member");
			}
			NxForceFieldLinearKernel_setFalloffLinear_INVOKE(ClassPointer, doSetFunctionPointers, ref unknown16);
		}
		
		private void setFalloffLinear_virtual([In()] ref NxVec3 unknown16)
		{
			setFalloffLinear(ref unknown16);
		}
		
		delegate void setFalloffLinear_11_delegate([In()] ref NxVec3 unknown16);
		
		
		
		
		
		
		private setFalloffLinear_11_delegate setFalloffLinear_11_delegatefield;
		
		/// <summary>Sets the quadratic falloff term. Platform:. </summary>
		public virtual NxVec3 getFalloffQuadratic()
		{
			if (doSetFunctionPointers)
			{
				throw new System.NotSupportedException("Cannot call abstract base member");
			}
			return NxForceFieldLinearKernel_getFalloffQuadratic_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		private NxVec3 getFalloffQuadratic_virtual()
		{
			return getFalloffQuadratic();
		}
		
		delegate NxVec3 getFalloffQuadratic_12_delegate();
		
		
		
		
		
		
		private getFalloffQuadratic_12_delegate getFalloffQuadratic_12_delegatefield;
		
		/// <summary>Sets the quadratic falloff term. Platform:. </summary>
		public virtual void setFalloffQuadratic(ref NxVec3 unknown17)
		{
			if (doSetFunctionPointers)
			{
				throw new System.NotSupportedException("Cannot call abstract base member");
			}
			NxForceFieldLinearKernel_setFalloffQuadratic_INVOKE(ClassPointer, doSetFunctionPointers, ref unknown17);
		}
		
		private void setFalloffQuadratic_virtual([In()] ref NxVec3 unknown17)
		{
			setFalloffQuadratic(ref unknown17);
		}
		
		delegate void setFalloffQuadratic_13_delegate([In()] ref NxVec3 unknown17);
		
		
		
		
		
		
		private setFalloffQuadratic_13_delegate setFalloffQuadratic_13_delegatefield;
		
		/// <summary>Gets the force field noise. Platform:. </summary>
		public virtual NxVec3 getNoise()
		{
			if (doSetFunctionPointers)
			{
				throw new System.NotSupportedException("Cannot call abstract base member");
			}
			return NxForceFieldLinearKernel_getNoise_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		private NxVec3 getNoise_virtual()
		{
			return getNoise();
		}
		
		delegate NxVec3 getNoise_14_delegate();
		
		
		
		
		
		
		private getNoise_14_delegate getNoise_14_delegatefield;
		
		/// <summary>Sets the force field noise. Platform:. </summary>
		public virtual void setNoise(ref NxVec3 unknown18)
		{
			if (doSetFunctionPointers)
			{
				throw new System.NotSupportedException("Cannot call abstract base member");
			}
			NxForceFieldLinearKernel_setNoise_INVOKE(ClassPointer, doSetFunctionPointers, ref unknown18);
		}
		
		private void setNoise_virtual([In()] ref NxVec3 unknown18)
		{
			setNoise(ref unknown18);
		}
		
		delegate void setNoise_15_delegate([In()] ref NxVec3 unknown18);
		
		
		
		
		
		
		private setNoise_15_delegate setNoise_15_delegatefield;
		
		/// <summary>ets the toroidal radius. Platform:</summary>
		public virtual float getTorusRadius()
		{
			if (doSetFunctionPointers)
			{
				throw new System.NotSupportedException("Cannot call abstract base member");
			}
			return NxForceFieldLinearKernel_getTorusRadius_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		private float getTorusRadius_virtual()
		{
			return getTorusRadius();
		}
		
		delegate float getTorusRadius_16_delegate();
		
		
		
		
		
		
		private getTorusRadius_16_delegate getTorusRadius_16_delegatefield;
		
		/// <summary>ets the toroidal radius. Platform:</summary>
		public virtual void setTorusRadius(float unknown19)
		{
			if (doSetFunctionPointers)
			{
				throw new System.NotSupportedException("Cannot call abstract base member");
			}
			NxForceFieldLinearKernel_setTorusRadius_INVOKE(ClassPointer, doSetFunctionPointers, unknown19);
		}
		
		private void setTorusRadius_virtual(float unknown19)
		{
			setTorusRadius(unknown19);
		}
		
		delegate void setTorusRadius_17_delegate(float unknown19);
		
		
		
		
		
		
		private setTorusRadius_17_delegate setTorusRadius_17_delegatefield;
		
		/// <summary>Retrieves the scene which this kernel belongs to. </summary>
		public virtual NxScene getScene()
		{
			if (doSetFunctionPointers)
			{
				throw new System.NotSupportedException("Cannot call abstract base member");
			}
			return NxScene.GetClass(NxForceFieldLinearKernel_getScene_INVOKE(ClassPointer, doSetFunctionPointers));
		}
		
		private IntPtr getScene_virtual()
		{
			return getScene().ClassPointer.Handle;
		}
		
		delegate IntPtr getScene_18_delegate();
		
		
		
		
		
		
		private getScene_18_delegate getScene_18_delegatefield;
		
		/// <summary>Writes all of the kernel's attributes to the description, as well as setting the actor connection point. </summary>
		/// <param name="desc">The descriptor used to retrieve the state of the kernel.</param>
		public virtual void saveToDesc(NxForceFieldLinearKernelDesc desc)
		{
			if (doSetFunctionPointers)
			{
				throw new System.NotSupportedException("Cannot call abstract base member");
			}
			NxForceFieldLinearKernel_saveToDesc_INVOKE(ClassPointer, doSetFunctionPointers, (desc!=null ? desc.ClassPointer : NullRef));
		}
		
		private void saveToDesc_virtual(IntPtr desc)
		{
			saveToDesc(NxForceFieldLinearKernelDesc.GetClass(desc));
		}
		
		delegate void saveToDesc_19_delegate(IntPtr desc);
		
		
		
		
		
		
		private saveToDesc_19_delegate saveToDesc_19_delegatefield;
		
		/// <summary>Sets a name string for the object that can be retrieved with getName(). </summary>
		/// <param name="name">String to set the objects name to.</param>
		public virtual void setName(string name)
		{
			if (doSetFunctionPointers)
			{
				throw new System.NotSupportedException("Cannot call abstract base member");
			}
			NxForceFieldLinearKernel_setName_INVOKE(ClassPointer, doSetFunctionPointers, name);
		}
		
		private void setName_virtual(string name)
		{
			setName(name);
		}
		
		delegate void setName_20_delegate(string name);
		
		
		
		
		
		
		private setName_20_delegate setName_20_delegatefield;
		
		/// <summary>Retrieves the name string set with setName(). </summary>
		public virtual string getName()
		{
			if (doSetFunctionPointers)
			{
				throw new System.NotSupportedException("Cannot call abstract base member");
			}
			return NxForceFieldLinearKernel_getName_INVOKE(ClassPointer, doSetFunctionPointers);
		}
		
		private string getName_virtual()
		{
			return getName();
		}
		
		delegate string getName_21_delegate();
		
		
		
		
		
		
		private getName_21_delegate getName_21_delegatefield;
		
		#region Imports
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="new_NxForceFieldLinearKernel")]
        private extern static IntPtr new_NxForceFieldLinearKernel_INVOKE (System.Boolean do_override);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxForceFieldLinearKernel_getConstant")]
        private extern static NxVec3 NxForceFieldLinearKernel_getConstant_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxForceFieldLinearKernel_setConstant")]
        private extern static void NxForceFieldLinearKernel_setConstant_INVOKE (HandleRef classPointer, System.Boolean call_explicit, [In()] ref NxVec3 unknown11);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxForceFieldLinearKernel_getPositionMultiplier")]
        private extern static NxMat33 NxForceFieldLinearKernel_getPositionMultiplier_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxForceFieldLinearKernel_setPositionMultiplier")]
        private extern static void NxForceFieldLinearKernel_setPositionMultiplier_INVOKE (HandleRef classPointer, System.Boolean call_explicit, [In()] ref NxMat33 unknown12);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxForceFieldLinearKernel_getVelocityMultiplier")]
        private extern static NxMat33 NxForceFieldLinearKernel_getVelocityMultiplier_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxForceFieldLinearKernel_setVelocityMultiplier")]
        private extern static void NxForceFieldLinearKernel_setVelocityMultiplier_INVOKE (HandleRef classPointer, System.Boolean call_explicit, [In()] ref NxMat33 unknown13);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxForceFieldLinearKernel_getPositionTarget")]
        private extern static NxVec3 NxForceFieldLinearKernel_getPositionTarget_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxForceFieldLinearKernel_setPositionTarget")]
        private extern static void NxForceFieldLinearKernel_setPositionTarget_INVOKE (HandleRef classPointer, System.Boolean call_explicit, [In()] ref NxVec3 unknown14);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxForceFieldLinearKernel_getVelocityTarget")]
        private extern static NxVec3 NxForceFieldLinearKernel_getVelocityTarget_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxForceFieldLinearKernel_setVelocityTarget")]
        private extern static void NxForceFieldLinearKernel_setVelocityTarget_INVOKE (HandleRef classPointer, System.Boolean call_explicit, [In()] ref NxVec3 unknown15);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxForceFieldLinearKernel_getFalloffLinear")]
        private extern static NxVec3 NxForceFieldLinearKernel_getFalloffLinear_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxForceFieldLinearKernel_setFalloffLinear")]
        private extern static void NxForceFieldLinearKernel_setFalloffLinear_INVOKE (HandleRef classPointer, System.Boolean call_explicit, [In()] ref NxVec3 unknown16);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxForceFieldLinearKernel_getFalloffQuadratic")]
        private extern static NxVec3 NxForceFieldLinearKernel_getFalloffQuadratic_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxForceFieldLinearKernel_setFalloffQuadratic")]
        private extern static void NxForceFieldLinearKernel_setFalloffQuadratic_INVOKE (HandleRef classPointer, System.Boolean call_explicit, [In()] ref NxVec3 unknown17);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxForceFieldLinearKernel_getNoise")]
        private extern static NxVec3 NxForceFieldLinearKernel_getNoise_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxForceFieldLinearKernel_setNoise")]
        private extern static void NxForceFieldLinearKernel_setNoise_INVOKE (HandleRef classPointer, System.Boolean call_explicit, [In()] ref NxVec3 unknown18);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxForceFieldLinearKernel_getTorusRadius")]
        private extern static System.Single NxForceFieldLinearKernel_getTorusRadius_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxForceFieldLinearKernel_setTorusRadius")]
        private extern static void NxForceFieldLinearKernel_setTorusRadius_INVOKE (HandleRef classPointer, System.Boolean call_explicit, System.Single unknown19);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxForceFieldLinearKernel_getScene")]
        private extern static IntPtr NxForceFieldLinearKernel_getScene_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxForceFieldLinearKernel_saveToDesc")]
        private extern static void NxForceFieldLinearKernel_saveToDesc_INVOKE (HandleRef classPointer, System.Boolean call_explicit, HandleRef desc);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxForceFieldLinearKernel_setName")]
        private extern static void NxForceFieldLinearKernel_setName_INVOKE (HandleRef classPointer, System.Boolean call_explicit, System.String name);

		
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [DllImport(NATIVE_LIBRARY, EntryPoint="NxForceFieldLinearKernel_getName")]
        private extern static System.String NxForceFieldLinearKernel_getName_INVOKE (HandleRef classPointer, System.Boolean call_explicit);

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
		
		public static NxForceFieldLinearKernel GetClass(IntPtr ptr)
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
					return ((NxForceFieldLinearKernel)(obj.Target));
				}
			}
			return new NxForceFieldLinearKernel(ptr);
		}
		
		protected override System.Collections.Generic.List<System.IntPtr> CreateFunctionPointers()
		{
			System.Collections.Generic.List<System.IntPtr> list = base.CreateFunctionPointers();
			getConstant_0_delegatefield = new getConstant_0_delegate(this.getConstant_virtual);
			list.Add(Marshal.GetFunctionPointerForDelegate(getConstant_0_delegatefield));
			setConstant_1_delegatefield = new setConstant_1_delegate(this.setConstant_virtual);
			list.Add(Marshal.GetFunctionPointerForDelegate(setConstant_1_delegatefield));
			getPositionMultiplier_2_delegatefield = new getPositionMultiplier_2_delegate(this.getPositionMultiplier_virtual);
			list.Add(Marshal.GetFunctionPointerForDelegate(getPositionMultiplier_2_delegatefield));
			setPositionMultiplier_3_delegatefield = new setPositionMultiplier_3_delegate(this.setPositionMultiplier_virtual);
			list.Add(Marshal.GetFunctionPointerForDelegate(setPositionMultiplier_3_delegatefield));
			getVelocityMultiplier_4_delegatefield = new getVelocityMultiplier_4_delegate(this.getVelocityMultiplier_virtual);
			list.Add(Marshal.GetFunctionPointerForDelegate(getVelocityMultiplier_4_delegatefield));
			setVelocityMultiplier_5_delegatefield = new setVelocityMultiplier_5_delegate(this.setVelocityMultiplier_virtual);
			list.Add(Marshal.GetFunctionPointerForDelegate(setVelocityMultiplier_5_delegatefield));
			getPositionTarget_6_delegatefield = new getPositionTarget_6_delegate(this.getPositionTarget_virtual);
			list.Add(Marshal.GetFunctionPointerForDelegate(getPositionTarget_6_delegatefield));
			setPositionTarget_7_delegatefield = new setPositionTarget_7_delegate(this.setPositionTarget_virtual);
			list.Add(Marshal.GetFunctionPointerForDelegate(setPositionTarget_7_delegatefield));
			getVelocityTarget_8_delegatefield = new getVelocityTarget_8_delegate(this.getVelocityTarget_virtual);
			list.Add(Marshal.GetFunctionPointerForDelegate(getVelocityTarget_8_delegatefield));
			setVelocityTarget_9_delegatefield = new setVelocityTarget_9_delegate(this.setVelocityTarget_virtual);
			list.Add(Marshal.GetFunctionPointerForDelegate(setVelocityTarget_9_delegatefield));
			getFalloffLinear_10_delegatefield = new getFalloffLinear_10_delegate(this.getFalloffLinear_virtual);
			list.Add(Marshal.GetFunctionPointerForDelegate(getFalloffLinear_10_delegatefield));
			setFalloffLinear_11_delegatefield = new setFalloffLinear_11_delegate(this.setFalloffLinear_virtual);
			list.Add(Marshal.GetFunctionPointerForDelegate(setFalloffLinear_11_delegatefield));
			getFalloffQuadratic_12_delegatefield = new getFalloffQuadratic_12_delegate(this.getFalloffQuadratic_virtual);
			list.Add(Marshal.GetFunctionPointerForDelegate(getFalloffQuadratic_12_delegatefield));
			setFalloffQuadratic_13_delegatefield = new setFalloffQuadratic_13_delegate(this.setFalloffQuadratic_virtual);
			list.Add(Marshal.GetFunctionPointerForDelegate(setFalloffQuadratic_13_delegatefield));
			getNoise_14_delegatefield = new getNoise_14_delegate(this.getNoise_virtual);
			list.Add(Marshal.GetFunctionPointerForDelegate(getNoise_14_delegatefield));
			setNoise_15_delegatefield = new setNoise_15_delegate(this.setNoise_virtual);
			list.Add(Marshal.GetFunctionPointerForDelegate(setNoise_15_delegatefield));
			getTorusRadius_16_delegatefield = new getTorusRadius_16_delegate(this.getTorusRadius_virtual);
			list.Add(Marshal.GetFunctionPointerForDelegate(getTorusRadius_16_delegatefield));
			setTorusRadius_17_delegatefield = new setTorusRadius_17_delegate(this.setTorusRadius_virtual);
			list.Add(Marshal.GetFunctionPointerForDelegate(setTorusRadius_17_delegatefield));
			getScene_18_delegatefield = new getScene_18_delegate(this.getScene_virtual);
			list.Add(Marshal.GetFunctionPointerForDelegate(getScene_18_delegatefield));
			saveToDesc_19_delegatefield = new saveToDesc_19_delegate(this.saveToDesc_virtual);
			list.Add(Marshal.GetFunctionPointerForDelegate(saveToDesc_19_delegatefield));
			setName_20_delegatefield = new setName_20_delegate(this.setName_virtual);
			list.Add(Marshal.GetFunctionPointerForDelegate(setName_20_delegatefield));
			getName_21_delegatefield = new getName_21_delegate(this.getName_virtual);
			list.Add(Marshal.GetFunctionPointerForDelegate(getName_21_delegatefield));
			return list;
		}
	}
}
