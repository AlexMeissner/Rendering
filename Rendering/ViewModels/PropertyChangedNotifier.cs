using PropertyChanged;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Rendering.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class PropertyChangedNotifier : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged = (sender, e) => { };

        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
