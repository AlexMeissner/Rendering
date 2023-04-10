using System;
using System.Windows;
using System.Windows.Controls;

namespace GraphControl
{
    public partial class ConnectionPoint : UserControl
    {
        public static readonly DependencyProperty IsAttachedProperty = DependencyProperty.Register("IsAttached", typeof(bool), typeof(ConnectionPoint), new PropertyMetadata());
        public static readonly DependencyProperty PropertyTypeProperty = DependencyProperty.Register("PropertyType", typeof(Type), typeof(ConnectionPoint), new PropertyMetadata());

        public bool IsAttached
        {
            get { return (bool)GetValue(IsAttachedProperty); }
            set { SetValue(IsAttachedProperty, value); }
        }

        public Type PropertyType
        {
            get { return (Type)GetValue(PropertyTypeProperty); }
            set { SetValue(PropertyTypeProperty, value); }
        }

        public ConnectionPoint()
        {
            InitializeComponent();
        }
    }
}
