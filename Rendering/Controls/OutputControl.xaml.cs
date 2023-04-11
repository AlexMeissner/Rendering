using System;
using System.IO.Pipes;
using System.Runtime.InteropServices;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Rendering.Controls
{
    public partial class OutputControl : UserControl
    {
        internal class PipeState
        {
            public byte[] Buffer = new byte[4096];
            public NamedPipeServerStream Pipe;
            public TextBox Output;
            public Dispatcher Dispatcher;

            public PipeState(NamedPipeServerStream pipe, TextBox output, Dispatcher dispatcher)
            {
                Pipe = pipe;
                Output = output;
                Dispatcher = dispatcher;
            }
        }

        public OutputControl()
        {
            InitializeComponent();

            RedirectOutput();

            Console.WriteLine("Test");
        }

        private void RedirectOutput()
        {
            try
            {
                var processId = Environment.ProcessId;
                var pipeName = $"ConsoleRedirect{processId}";
                var serverPipe = new NamedPipeServerStream(pipeName, PipeDirection.In, 1);
                var clientPipe = new NamedPipeClientStream(".", pipeName, PipeDirection.Out, PipeOptions.WriteThrough);
                clientPipe.Connect();
                var handleRef = new HandleRef(clientPipe, clientPipe.SafePipeHandle.DangerousGetHandle());
                var success = SetStdHandle(-11, handleRef.Handle);
                serverPipe.WaitForConnection();

                var state = new PipeState(serverPipe, Output, Dispatcher);
                serverPipe.BeginRead(state.Buffer, 0, state.Buffer.Length, ReadCallback, state);
            }
            catch (Exception exception)
            {
                Output.Text = exception.ToString();
            }
        }

        private static void ReadCallback(IAsyncResult ar)
        {
            if (ar.AsyncState is PipeState state)
            {
                var bytesRead = state.Pipe.EndRead(ar);

                if (bytesRead > 0)
                {
                    var message = System.Text.Encoding.Default.GetString(state.Buffer);
                    state.Dispatcher.Invoke(new Action(() => { state.Output.Text += $"{message}\n"; }));
                }

                state.Pipe.BeginRead(state.Buffer, 0, state.Buffer.Length, ReadCallback, state);
            }
        }

        [LibraryImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static partial bool SetStdHandle(int nStdHandle, IntPtr hHandle);
    }
}
