using System.Windows;
using System.Windows.Controls;

namespace GraphControl
{
    public partial class Node : UserControl
    {
        public static readonly DependencyProperty GraphNodeProperty = DependencyProperty.Register("GraphNode", typeof(GraphNode), typeof(Node), new PropertyMetadata());

        public GraphNode GraphNode
        {
            get { return (GraphNode)GetValue(GraphNodeProperty); }
            set { SetValue(GraphNodeProperty, value); }
        }

        public Node()
        {
            InitializeComponent();
        }
    }
}
