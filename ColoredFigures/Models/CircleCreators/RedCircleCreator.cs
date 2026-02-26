using ColoredFigures.Models.Shapes;
using System.Windows.Media;

namespace ColoredFigures.Models.CircleCreators
{
    public class RedCircleCreator : ICircleCreator
    {
        public Circle CreateCircle()
        {
            return new Circle { Color = Colors.Red };
        }
    }
}
