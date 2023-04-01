using System;
using System.Runtime.InteropServices;

namespace Rendering
{
    public static partial class VulkanCoreAPI
    {
        internal static partial class NativeVulkanCore
        {
            [LibraryImport("VulkanCore.dll")]
            [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static partial bool InitializeVulkan(IntPtr hwnd, IntPtr hInstance);

            [LibraryImport("VulkanCore.dll")]
            [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
            public static partial void DrawFrame();

            [LibraryImport("VulkanCore.dll")]
            [UnmanagedCallConv(CallConvs = new Type[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
            public static partial void CleanUp();
        }

        public static bool InitializeVulkan(IntPtr hwnd)
        {
            var hInstance = Marshal.GetHINSTANCE(typeof(App).Module);
            return NativeVulkanCore.InitializeVulkan(hwnd, hInstance);
        }

        public static void DrawFrame()
        {
            NativeVulkanCore.DrawFrame();
        }

        public static void CleanUp()
        {
            NativeVulkanCore.CleanUp();
        }
    }
}
