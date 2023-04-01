using GraphControl;
using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Rendering.GraphNodes
{
    public class VertexShaderNode : GraphNode
    {
        public override string Name => "Vertex Shader";
        public override SolidColorBrush Color => Brushes.Red;
        public override BitmapImage Icon => throw new NotImplementedException();
    }
}
