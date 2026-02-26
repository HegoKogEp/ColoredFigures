using ColoredFigures.Models.Shapes;
using System.Windows.Media;
namespace ColoredFigures.Models.SquareCreators
{
    public class GreenSquareCreator : ISquareCreator
    {
        public Square CreateSquare()
        {
            return new Square { Color = Colors.Green };
        }
    }
}
