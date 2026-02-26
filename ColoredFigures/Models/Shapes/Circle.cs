using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ColoredFigures.Models.Shapes
{
    public class Circle : Figure
    {
        public override UIElement CreateUIElement(double size = 50)
        {
            return new Ellipse
            {
                Width = size,
                Height = size,
                Fill = new SolidColorBrush(Color)
            };
        }
    }
}
