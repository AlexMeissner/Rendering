using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GraphControl
{
    public partial class BezierCurve : UserControl
    {
        public static readonly DependencyProperty StartProperty = DependencyProperty.Register("Start", typeof(GraphNodeProperty), typeof(BezierCurve), new PropertyMetadata());
        public static readonly DependencyProperty EndProperty = DependencyProperty.Register("End", typeof(GraphNodeProperty), typeof(BezierCurve), new PropertyMetadata());

        public GraphNodeProperty Start
        {
            get { return (GraphNodeProperty)GetValue(StartProperty); }
            set { SetValue(StartProperty, value); }
        }

        public GraphNodeProperty End
        {
            get { return (GraphNodeProperty)GetValue(EndProperty); }
            set { SetValue(EndProperty, value); }
        }

        public Point Point0 => new Point(0, 0);//Point(Start?.RenderTransform, 0);
        public Point Point1 => new Point(0, 0);//Point(Start?.RenderTransform, 100);
        public Point Point2 => new Point(0, 0);//Point(End?.RenderTransform, -100);
        public Point Point3 => new Point(0, 0);//ToPoint(End?.RenderTransform, 0);
        public SolidColorBrush Color => Brushes.Transparent;

        public BezierCurve()
        {
            InitializeComponent();
        }

        private static Point ToPoint(Transform? transform, double offsetX)
        {
            if (transform is TranslateTransform translation)
            {
                return new(translation.X + offsetX, translation.Y);
            }

            return new();
        }
    }
}
