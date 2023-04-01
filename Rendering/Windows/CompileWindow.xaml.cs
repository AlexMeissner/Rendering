using Rendering.ViewModels;
using System.Diagnostics;
using System.Windows;

namespace Rendering.Windows
{
    public partial class CompileWindow : Window
    {
        public CompileViewModel ViewModel { get; set; } = new();

        public CompileWindow()
        {
            InitializeComponent();
        }

        private void OnOk(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
