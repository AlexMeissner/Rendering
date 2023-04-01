using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace GraphControl
{
    public partial class NodeGraphControl : UserControl
    {
        public static readonly DependencyProperty GraphItemsProperty = DependencyProperty.Register("GraphItems", typeof(ICollection<IGraphItem>), typeof(NodeGraphControl));

        public ICollection<IGraphItem> GraphItems
        {
            get => (ICollection<IGraphItem>)GetValue(GraphItemsProperty);
            set => SetValue(GraphItemsProperty, value);
        }

        public NodeGraphControl()
        {
            InitializeComponent();
        }
    }
}
