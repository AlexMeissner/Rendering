using System;

namespace GraphControl
{
    public class GraphEdge : IGraphItem
    {
        public double X { get => 0; set => throw new NotImplementedException(); }
        public double Y { get => 0; set => throw new NotImplementedException(); }
        public int ZIndex { get; init; } = 0;

        public GraphNodeProperty Start { get; set; }
        public GraphNodeProperty? End { get; set; }

        public GraphEdge(GraphNodeProperty start)
        {
            Start = start;
        }
    }
}
