using ColoredFigures.Models.Shapes;
using System.Windows.Media;

namespace ColoredFigures.Models.TriangleCreators
{
    class RedTriangleCreator : ITriangleCreator
    {
        public Triangle CreateTriangle()
        {
            return new Triangle { Color = Colors.Red };
        }
    }
}
