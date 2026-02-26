using ColoredFigures.Models.Shapes;

namespace ColoredFigures.Models.Factories
{
    internal interface IFigureFactory
    {
        public Circle CreateCircle();
        public Square CreateSquare();
        public Triangle CreateTriangle();
    }
}