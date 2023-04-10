using System.Windows;
using System;
using System.Windows.Controls;

namespace GraphControl
{
    public partial class NodeProperty : UserControl
    {
        public static readonly DependencyProperty IsInputProperty = DependencyProperty.Register("IsInput", typeof(bool), typeof(NodeProperty), new PropertyMetadata());
        public static readonly DependencyProperty PropertyTypeProperty = DependencyProperty.Register("PropertyType", typeof(Type), typeof(NodeProperty), new PropertyMetadata());
        public static readonly DependencyProperty PropertyNameProperty = DependencyProperty.Register("PropertyName", typeof(string), typeof(NodeProperty), new PropertyMetadata());

        public bool IsInput
        {
            get { return (bool)GetValue(IsInputProperty); }
            set { SetValue(IsInputProperty, value); }
        }

        public Type PropertyType
        {
            get { return (Type)GetValue(PropertyTypeProperty); }
            set { SetValue(PropertyTypeProperty, value); }
        }

        public string PropertyName
        {
            get { return (string)GetValue(PropertyNameProperty); }
            set { SetValue(PropertyNameProperty, value); }
        }

        public NodeProperty()
        {
            InitializeComponent();
        }
    }
}
