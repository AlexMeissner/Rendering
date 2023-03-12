using System.Runtime.InteropServices;

namespace Rendering
{
    public static partial class VulkanCoreAPI
    {
        internal static partial class NativeVulkanCore
        {
            [LibraryImport("VulkanCore.dll")]
            [UnmanagedCallConv(CallConvs = new System.Type[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static partial bool Initialize();
        }

        public static bool Initialize()
        {
            return NativeVulkanCore.Initialize();
        }
    }
}
