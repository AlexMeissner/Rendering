using System;
using System.Windows.Media;

namespace GraphControl
{
    public class GraphNodeProperty
    {
        public string Name { get; set; }
        public Type Type { get; set; } = typeof(GraphNode);
        public SolidColorBrush Color { get; set; }
    }
}
