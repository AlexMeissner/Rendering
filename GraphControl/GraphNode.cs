using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GraphControl
{
    public abstract class GraphNode : IGraphItem
    {
        public double X { get; set; } = 0;
        public double Y { get; set; } = 0;
        public int ZIndex { get; init; } = 1;

        public abstract string Name { get; }
        public abstract SolidColorBrush Color { get; }
        public abstract BitmapImage Icon { get; }

        public ICollection<GraphNodeProperty> Inputs { get; set; }
        public ICollection<GraphNodeProperty> Outputs { get; set; }
    }
}
