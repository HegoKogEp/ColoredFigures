using ColoredFigures.Models.Shapes;
using System.Windows.Media;

namespace ColoredFigures.Models.Factories
{
    public class RedFigureFactory : IFigureFactory
    {
        public Circle CreateCircle()
        {
            return new Circle { Color = Colors.Red };
        }

        public Square CreateSquare()
        {
            return new Square { Color = Colors.Red };
        }

        public Triangle CreateTriangle()
        {
            return new Triangle { Color = Colors.Red };
        }
    }
}