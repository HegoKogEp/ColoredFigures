using ColoredFigures.Models.Shapes;
using System.Windows.Media;

namespace ColoredFigures.Models.Factories
{
    public class BlueFigureFactory : IFigureFactory
    {
        public Circle CreateCircle()
        {
            return new Circle { Color = Colors.Blue };
        }

        public Square CreateSquare()
        {
            return new Square { Color = Colors.Blue };
        }

        public Triangle CreateTriangle()
        {
            return new Triangle { Color = Colors.Blue };
        }
    }
}