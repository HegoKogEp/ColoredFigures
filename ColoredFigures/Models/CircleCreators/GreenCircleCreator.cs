using ColoredFigures.Models.Shapes;
using System.Windows.Media;

namespace ColoredFigures.Models.CircleCreators
{
    public class GreenCircleCreator : ICircleCreator
    {
        public Circle CreateCircle()
        {
            return new Circle { Color = Colors.Green };
        }
    }
}
