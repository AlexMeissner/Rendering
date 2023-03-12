using System.Collections.ObjectModel;

namespace Rendering.ViewModels
{
    public class ScenesViewModel : PropertyChangedNotifier
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public ScenesViewModel(string name, bool isActive)
        {
            Name = name;
            IsActive = isActive;
        }
    }
}
