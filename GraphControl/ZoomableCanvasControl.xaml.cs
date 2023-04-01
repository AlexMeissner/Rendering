using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace GraphControl
{
    public partial class ZoomableCanvasControl : Canvas
    {
        private readonly MatrixTransform Transformation = new();
        private Point InitialMousePosition;
        private readonly float ZoomFactor = 1.1f;

        public ZoomableCanvasControl()
        {
            InitializeComponent();
        }

        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Right)
            {
                InitialMousePosition = Transformation.Inverse.Transform(e.GetPosition(this));
            }
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.RightButton == MouseButtonState.Pressed)
            {
                var mousePosition = Transformation.Inverse.Transform(e.GetPosition(this));
                var delta = Point.Subtract(mousePosition, InitialMousePosition);
                var translate = new TranslateTransform(delta.X, delta.Y);
                Transformation.Matrix = translate.Value * Transformation.Matrix;

                foreach (UIElement child in Children)
                {
                    child.RenderTransform = Transformation;
                }
            }
        }

        private void OnMouseWheel(object sender, MouseWheelEventArgs e)
        {
            var scaleFactor = (e.Delta < 0) ? 1.0f / ZoomFactor : ZoomFactor;

            var mousePostion = e.GetPosition(this);

            var scaleMatrix = Transformation.Matrix;
            scaleMatrix.ScaleAt(scaleFactor, scaleFactor, mousePostion.X, mousePostion.Y);
            Transformation.Matrix = scaleMatrix;

            foreach (UIElement child in Children)
            {
                double sx = GetLeft(child) * scaleFactor;
                double sy = GetTop(child) * scaleFactor;

                SetLeft(child, sx);
                SetTop(child, sy);

                child.RenderTransform = Transformation;
            }
        }
    }
}
