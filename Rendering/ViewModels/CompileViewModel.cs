using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Media;

namespace Rendering.ViewModels
{
    public class CompileViewModel : PropertyChangedNotifier
    {
        public class CompileLog : PropertyChangedNotifier
        {
            public enum LogType
            {
                Trace,
                Info,
                Warning,
                Error,
                Critical
            }

            public string Message { get; set; }
            public LogType Type { get; set; }
            public SolidColorBrush TextColor => ToColor(Type);

            public CompileLog(string message, LogType type)
            {
                Message = message;
                Type = type;
            }

            private static SolidColorBrush ToColor(LogType type) => type switch
            {
                LogType.Trace => Brushes.AliceBlue,
                LogType.Info => Brushes.White,
                LogType.Warning => Brushes.Yellow,
                LogType.Error => Brushes.OrangeRed,
                LogType.Critical => Brushes.Red,
                _ => throw new NotImplementedException(),
            };
        }

        public ObservableCollection<CompileLog> Log { get; set; } = new();

        public void CompileShaders()
        {
            try
            {
                using var process = new Process()
                {
                    StartInfo =
                    {
                        FileName = @"W:/VulkanSDK/1.3.204.1/Bin/glslc.exe",
                        Arguments = "shader.frag -o frag.spv",
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                    }
                };

                process.OutputDataReceived += new DataReceivedEventHandler(OnReceiveOutput);
                process.ErrorDataReceived += new DataReceivedEventHandler(OnReceiveError);

                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                process.WaitForExit();
            }
            catch (Exception exception)
            {
                Log.Add(new(exception.ToString(), CompileLog.LogType.Critical));
            }
        }

        private void OnReceiveOutput(object sender, DataReceivedEventArgs e)
        {
            if (e.Data is string message)
            {
                Log.Add(new(message, CompileLog.LogType.Info));
            }
        }

        private void OnReceiveError(object sender, DataReceivedEventArgs e)
        {
            if (e.Data is string message)
            {
                Log.Add(new(message, CompileLog.LogType.Error));
            }
        }
    }
}
