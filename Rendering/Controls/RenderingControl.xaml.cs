using System;
using System.Runtime.InteropServices;
using System.Windows.Controls;
using System.Windows.Interop;

namespace Rendering.Controls
{
    public partial class RenderingControl : UserControl
    {
        internal class WindowHost : HwndHost
        {
            private HwndSource? WindowSource = null;

            public IntPtr Win32Handle => WindowSource!.Handle;

            protected override HandleRef BuildWindowCore(HandleRef hwndParent)
            {
                const int classStyle = 0x0800 | 0x0002 | 0x0020;
                const int style = 0x40000000 | 0x10000000; // Child | Visible
                const int exStyle = 0x00040000; // AppWindow

                WindowSource = new(classStyle, style, exStyle, 0, 0, 1, 1, "Win32WindowControl", hwndParent.Handle, true);

                return new HandleRef(this, WindowSource.Handle);
            }

            protected override void DestroyWindowCore(HandleRef hwnd)
            {
                WindowSource?.Dispose();
            }
        }

        private readonly WindowHost Host = new();

        public IntPtr Handle => Host.Win32Handle;


        public RenderingControl()
        {
            InitializeComponent();
            Content = Host;
        }
    }
}
