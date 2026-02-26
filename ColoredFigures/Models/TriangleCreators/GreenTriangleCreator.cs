using ColoredFigures.Models.Shapes;
using System.Windows.Media;

namespace ColoredFigures.Models.TriangleCreators
{
    class GreenTriangleCreator : ITriangleCreator
    {
        public Triangle CreateTriangle()
        {
            return new Triangle { Color = Colors.Green };
        }
    }
}
