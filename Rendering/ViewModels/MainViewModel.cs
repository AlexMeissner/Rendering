using GraphControl;
using System.Collections.ObjectModel;

namespace Rendering.ViewModels
{
    public class MainViewModel : PropertyChangedNotifier
    {
        public ObservableCollection<ScenesViewModel> Scenes { get; set; } = new();
        public ObservableCollection<IGraphItem> GraphItems { get; set; } = new();

        public MainViewModel()
        {

        }
    }
}
