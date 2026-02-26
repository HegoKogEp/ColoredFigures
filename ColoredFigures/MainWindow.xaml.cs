using ColoredFigures.Models.CircleCreators;
using ColoredFigures.Models.SquareCreators;
using ColoredFigures.Models.TriangleCreators;
using System.Windows;
using System.Windows.Controls;

namespace ColoredFigures
{
    public partial class MainWindow : Window
    {
        private ICircleCreator? _circleCreator;
        private ISquareCreator? _squareCreator;
        private ITriangleCreator? _triangleCreator;

        public MainWindow()
        {
            InitializeComponent();
            colorComboBox.SelectedIndex = 0;
            UpdateCreators();
        }

        private void ColorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateCreators();
            figuresPanel.Children.Clear();
        }

        private void UpdateCreators()
        {
            var selectedItem = colorComboBox.SelectedItem as ComboBoxItem;
            if (selectedItem == null) return;

            string? color = selectedItem.Tag.ToString();

            switch (color)
            {
                case "Red":
                    _circleCreator = new RedCircleCreator();
                    _squareCreator = new RedSquareCreator();
                    _triangleCreator = new RedTriangleCreator();
                    break;
                case "Blue":
                    _circleCreator = new BlueCircleCreator();
                    _squareCreator = new BlueSquareCreator();
                    _triangleCreator = new BlueTriangleCreator();
                    break;
                case "Green":
                    _circleCreator = new GreenCircleCreator();
                    _squareCreator = new GreenSquareCreator();
                    _triangleCreator = new GreenTriangleCreator();
                    break;
                default:
                    _circleCreator = null;
                    _squareCreator = null;
                    _triangleCreator = null;
                    break;
            }
        }

        private void AddCircleButton_Click(object sender, RoutedEventArgs e)
        {
            if (_circleCreator == null) return;
            var circle = _circleCreator.CreateCircle();
            figuresPanel.Children.Add(circle.CreateUIElement());
        }

        private void AddSquareButton_Click(object sender, RoutedEventArgs e)
        {
            if (_squareCreator == null) return;
            var square = _squareCreator.CreateSquare();
            figuresPanel.Children.Add(square.CreateUIElement());
        }

        private void AddTriangleButton_Click(object sender, RoutedEventArgs e)
        {
            if (_triangleCreator == null) return;
            var triangle = _triangleCreator.CreateTriangle();
            figuresPanel.Children.Add(triangle.CreateUIElement());
        }
    }
}