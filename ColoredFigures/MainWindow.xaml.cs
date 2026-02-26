using ColoredFigures.Models.Factories;
using ColoredFigures.Models.Shapes;
using System.Windows;
using System.Windows.Controls;

namespace ColoredFigures
{
    public partial class MainWindow : Window
    {
        private IFigureFactory? _figureFactory;
        private List<Figure> _figureHistory = new List<Figure>();

        public MainWindow()
        {
            InitializeComponent();
            colorComboBox.SelectedIndex = 0;
            UpdateFactory();
        }

        private void ColorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateFactory();
            RedrawAllFiguresWithNewColor();
        }

        private void UpdateFactory()
        {
            var selectedItem = colorComboBox.SelectedItem as ComboBoxItem;
            if (selectedItem == null) return;

            string? color = selectedItem.Tag.ToString();

            switch (color)
            {
                case "Red":
                    _figureFactory = new RedFigureFactory();
                    break;
                case "Blue":
                    _figureFactory = new BlueFigureFactory();
                    break;
                case "Green":
                    _figureFactory = new GreenFigureFactory();
                    break;
                default:
                    _figureFactory = null;
                    break;
            }
        }

        private void RedrawAllFiguresWithNewColor()
        {
            if (_figureFactory == null)
            {
                figuresPanel.Children.Clear();
                return;
            }

            figuresPanel.Children.Clear();

            if (_figureHistory.Count == 0) return;

            List<Figure> temp = new List<Figure>();

            foreach (var _ in _figureHistory)
            {
                Figure newFigure = null;

                if (_ is Circle)
                {
                    newFigure = _figureFactory.CreateCircle();
                }
                else if (_ is Square)
                {
                    newFigure = _figureFactory.CreateSquare();
                }
                else if (_ is Triangle)
                {
                    newFigure = _figureFactory.CreateTriangle();
                }

                if (newFigure != null)
                {
                    temp.Add(newFigure);
                    figuresPanel.Children.Add(newFigure.CreateUIElement());
                }
            }

            _figureHistory = temp;
        }

        private void AddCircleButton_Click(object sender, RoutedEventArgs e)
        {
            if (_figureFactory == null) return;

            var circle = _figureFactory.CreateCircle();
            _figureHistory.Add(circle);
            figuresPanel.Children.Add(circle.CreateUIElement());
        }

        private void AddSquareButton_Click(object sender, RoutedEventArgs e)
        {
            if (_figureFactory == null) return;

            var square = _figureFactory.CreateSquare();
            _figureHistory.Add(square);
            figuresPanel.Children.Add(square.CreateUIElement());
        }

        private void AddTriangleButton_Click(object sender, RoutedEventArgs e)
        {
            if (_figureFactory == null) return;

            var triangle = _figureFactory.CreateTriangle();
            _figureHistory.Add(triangle);
            figuresPanel.Children.Add(triangle.CreateUIElement());
        }
    }
}