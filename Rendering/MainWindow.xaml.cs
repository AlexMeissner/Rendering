using Rendering.ViewModels;
using System.Windows;

namespace Rendering
{
    public partial class MainWindow : Window
    {
        public MainViewModel ViewModel { get; set; } = new()
        {
            Scenes = new()
            {
                new("asgsdgasdg", false),
                new("liudfsgb", false),
                new("blöjdfn iub hdpbd", false),
                new("peoiabpu bdrpboidbdf", true),
                new("piuprehgn dr  db", false),
            }
        };

        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
