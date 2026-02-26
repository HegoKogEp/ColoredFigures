using ColoredFigures.Models.Shapes;
using System.Windows.Media;

namespace ColoredFigures.Models.CircleCreators
{
    class BlueCircleCreator : ICircleCreator
    {
        public Circle CreateCircle()
        {
            return new Circle { Color = Colors.Blue };
        }
    }
}
