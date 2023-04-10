using GraphControl;
using Rendering.GraphNodes;
using Rendering.ViewModels;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Timers;
using System.Windows;
using System.Windows.Media;

namespace Rendering
{
    public partial class MainWindow : Window
    {
        private static readonly VertexShaderNode vsn = new()
        {
            X = 10,
            Y = 50,
            Inputs = new ObservableCollection<GraphNodeProperty>() { new() { Color = Brushes.Green, Name = "Input" } },
            Outputs = new ObservableCollection<GraphNodeProperty>() { new() { Color = Brushes.Blue, Name = "Output" } }
        };

        private static readonly RasterizerStateNode rsn = new()
        {
            X = 540,
            Y = 340,
            Inputs = new ObservableCollection<GraphNodeProperty>() { new() { Color = Brushes.Blue, Name = "Input" } },
            Outputs = new ObservableCollection<GraphNodeProperty>() { new() { Color = Brushes.Red, Name = "Output" } }
        };

        public MainViewModel ViewModel { get; set; } = new()
        {
            Scenes = new()
            {
                new("asgsdgasdg", false),
                new("liudfsgb", false),
                new("blöjdfn iub hdpbd", false),
                new("peoiabpu bdrpboidbdf", true),
                new("piuprehgn dr  db", false),
            },

            GraphItems = new()
            {
                vsn,
                rsn,
                new GraphEdge(vsn.Outputs.First())
                {
                    End = rsn.Inputs.First()
                }
            }
        };

        private bool IsRunning = true;
        private readonly Thread RenderThread;

        public MainWindow()
        {
            InitializeComponent();
            RenderThread = new(new ThreadStart(OnRenderFrame));
        }

        private void OnRenderTimer(object? sender, ElapsedEventArgs e)
        {
            VulkanCoreAPI.DrawFrame();
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            VulkanCoreAPI.InitializeVulkan(RenderControl.Handle);
            RenderThread.Start();
        }

        private void OnClosed(object sender, System.EventArgs e)
        {
            IsRunning = false;
            RenderThread.Join();
            VulkanCoreAPI.CleanUp();
        }

        private void OnRenderFrame()
        {
            while (IsRunning)
            {
                VulkanCoreAPI.DrawFrame();
            }
        }


    }
}
