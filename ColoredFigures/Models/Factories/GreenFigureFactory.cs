using ColoredFigures.Models.Shapes;
using System.Windows.Media;

namespace ColoredFigures.Models.Factories
{
    public class GreenFigureFactory : IFigureFactory
    {
        public Circle CreateCircle()
        {
            return new Circle { Color = Colors.Green };
        }

        public Square CreateSquare()
        {
            return new Square { Color = Colors.Green };
        }

        public Triangle CreateTriangle()
        {
            return new Triangle { Color = Colors.Green };
        }
    }
}