using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace PhysX.NET
{
    public static class PhysXLoader
    {
        public const uint NX_PHYSICS_SDK_VERSION = ((2 << 24) + (8 << 16) + (1 << 8) + 0);

        public static NxPhysicsSDK NxCreatePhysicsSDK(uint sdkversion, NxPhysicsSDKDesc sdkdesc, ref NxSDKCreateError errorcode)
        {
            return NxPhysicsSDK.GetClass(NxCreatePhysicsSDK_INVOKE(sdkversion, IntPtr.Zero, IntPtr.Zero, sdkdesc.ClassPointer, ref errorcode));
        }

        public static void NxReleasePhysicsSDK(NxPhysicsSDK sdk)
        {
            NxReleasePhysicsSDK_INVOKE(sdk.ClassPointer);
        }

        public static NxFoundationSDK NxGetFoundationSDK()
        {
            return NxFoundationSDK.GetClass(NxGetFoundationSDK_INVOKE());
        }

        public static NxPhysicsSDK NxGetPhysicsSDK()
        {
            return NxPhysicsSDK.GetClass(NxGetPhysicsSDK_INVOKE());
        }

        public static NxUtilLib NxGetUtilLib()
        {
            return NxUtilLib.GetClass(NxGetUtilLib_INVOKE());
        }

        public static NxCookingInterface NxGetCookingLib(uint sdk_version)
        {
            return NxCookingInterface.GetClass(NxGetCookingLib_INVOKE(sdk_version));
        }

        [DllImport("PhysXLoader.dll", EntryPoint = "NxCreatePhysicsSDK")]
        private static extern System.IntPtr NxCreatePhysicsSDK_INVOKE(uint sdkversion, System.IntPtr allocator, System.IntPtr outputstream, HandleRef sdkdesc, ref NxSDKCreateError errorcode);

        [DllImport("PhysXLoader.dll", EntryPoint = "NxReleasePhysicsSDK")]
        private static extern void NxReleasePhysicsSDK_INVOKE(HandleRef sdk);

        [DllImport("PhysXLoader.dll", EntryPoint = "NxGetFoundationSDK")]
        private static extern System.IntPtr NxGetFoundationSDK_INVOKE();

        [DllImport("PhysXLoader.dll", EntryPoint = "NxGetPhysicsSDK")]
        private static extern System.IntPtr NxGetPhysicsSDK_INVOKE();

        [DllImport("PhysXLoader.dll", EntryPoint = "NxGetUtilLib")]
        private static extern System.IntPtr NxGetUtilLib_INVOKE();

        [DllImport("PhysXLoader.dll", EntryPoint = "NxGetCookingLib")]
        private static extern System.IntPtr NxGetCookingLib_INVOKE(uint sdk_version);
    }

    public class NxArray<T> : DoxyBindObject
    {

        internal NxArray(IntPtr classPointer) : base(classPointer)
        {
        }

        public static NxArray<T> GetClass(IntPtr ptr)
        {
            WeakReference obj;
            if (database.TryGetValue(ptr, out obj))
            {
                if(obj.IsAlive)
                    return ((NxArray<T>)(obj.Target));
            }
            return new NxArray<T>(ptr);
        }

        protected static Dictionary<IntPtr, WeakReference> database = new Dictionary<IntPtr, WeakReference>();

        protected override void SetPointer(IntPtr ptr)
        {
            base.SetPointer(ptr);
            database[ptr] = new WeakReference(this);
        }
    }

    public class NxArray_NxShapeDesc : NxArray<NxShapeDesc>
    {
        public NxArray_NxShapeDesc(IntPtr classPointer)
            : base(classPointer)
        { }

        public NxArray_NxShapeDesc(NxArray<NxShapeDesc> baseC)
            : base(baseC.ClassPointer.Handle)
        { }

        public void pushBack(NxShapeDesc item)
        {
            NxArray_NxShapeDesc_NxAllocatorDefault_pushBack_INVOKE(ClassPointer, item.ClassPointer);
        }

        public NxShapeDesc getItem1(int index)
        {
            return new NxShapeDesc(NxArray_NxShapeDesc_NxAllocatorDefault_getItem_INVOKE(ClassPointer, index));
        }

        public static NxArray_NxShapeDesc GetClass(IntPtr ptr)
        {
            WeakReference obj;
            if (database.TryGetValue(ptr, out obj))
            {
                if(obj.IsAlive)
                    return ((NxArray_NxShapeDesc)(obj.Target));
            }
            return new NxArray_NxShapeDesc(ptr);
        }
        
        [System.Security.SuppressUnmanagedCodeSecurity()]
        [System.Runtime.InteropServices.DllImport("PhysX.dll", EntryPoint = "NxArray_NxShapeDesc_NxAllocatorDefault_pushBack")]
        private extern static void NxArray_NxShapeDesc_NxAllocatorDefault_pushBack_INVOKE(HandleRef classPointer, HandleRef item);

        [System.Security.SuppressUnmanagedCodeSecurity()]
        [System.Runtime.InteropServices.DllImport("PhysX.dll", EntryPoint = "NxArray_NxShapeDesc_NxAllocatorDefault_getItem")]
        private extern static IntPtr NxArray_NxShapeDesc_NxAllocatorDefault_getItem_INVOKE(HandleRef classPointer, int index);
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NxVec3
    {
        public float x, y, z;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NxMat33
    {
        public float _11, _12, _13;
        public float _21, _22, _23;
        public float _31, _32, _33;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NxMat34
    {
        public NxMat33 M;
        public NxVec3 t;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NxExtendedVec3
    {
        public double x, y, z;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct NxQuat
    {
        public float x, y, z, w;
    }
}
