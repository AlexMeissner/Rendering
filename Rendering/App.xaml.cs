using System.Windows;

namespace Rendering
{
    public partial class App : Application
    {
        public App() 
        {
            var init = VulkanCoreAPI.Initialize();
        }
    }
}
