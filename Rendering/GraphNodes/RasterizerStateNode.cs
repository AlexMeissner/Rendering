using GraphControl;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Rendering.GraphNodes
{
    public class RasterizerStateNode : GraphNode
    {
        public override string Name => "Rasterizer State";
        public override SolidColorBrush Color => Brushes.Green;
        public override BitmapImage Icon => throw new System.NotImplementedException();
    }
}
