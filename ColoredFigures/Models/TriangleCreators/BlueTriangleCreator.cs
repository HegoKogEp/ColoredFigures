using ColoredFigures.Models.Shapes;
using System.Windows.Media;

namespace ColoredFigures.Models.TriangleCreators
{
    class BlueTriangleCreator : ITriangleCreator
    {
        public Triangle CreateTriangle()
        {
            return new Triangle { Color = Colors.Blue };
        }
    }
}
