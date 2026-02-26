using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;

namespace ColoredFigures.Models.Shapes
{
    public class Square : Figure
    {
        public override UIElement CreateUIElement(double size = 50)
        {
            return new Rectangle()
            {
                Width = size,
                Height = size,
                Fill = new SolidColorBrush(Color)
            };
        }
    }
}
