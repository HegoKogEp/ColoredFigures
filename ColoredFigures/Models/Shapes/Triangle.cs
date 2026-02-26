using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;

namespace ColoredFigures.Models.Shapes
{
    public class Triangle : Figure
    {
        public override UIElement CreateUIElement(double size = 50)
        {
            var triangle = new Polygon
            {
                Fill = new SolidColorBrush(Color),
                Points = new PointCollection
                {
                    new Point(size / 2, 0), // Top vertex
                    new Point(0, size),     // Bottom left vertex
                    new Point(size, size)   // Bottom right vertex
                },
                Width = size,
                Height = size,
                Stretch = Stretch.Fill
            };
            return triangle;
        }
    }
}
