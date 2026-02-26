# ColoredFigures - Документация по проекту

## Содержание
1. [App.xaml](#appxaml)
2. [App.xaml.cs](#appxamlcs)
3. [AssemblyInfo.cs](#assemblyinfocs)
4. [ColoredFigures.csproj](#coloredfigurescsproj)
5. [MainWindow.xaml](#mainwindowxaml)
6. [MainWindow.xaml.cs](#mainwindowxamlcs)
7. [Models/Circlecreators](#models-circlecreators)
   1. [BlueCircleCreator.cs](#bluecirclecreatorcs)
   2. [CircleCreator.cs](#circlecreatorcs)
   3. [GreenCircleCreator.cs](#greencirclecreatorcs)
   4. [RedCircleCreator.cs](#redcirclecreatorcs)
8. [Models/Shapes](#models-shapes)
   1. [Circle.cs](#circlecs)
   2. [Figure.cs](#figurecs)
   3. [Square.cs](#squarecs)
   4. [Triangle.cs](#trianglecs)
9. [Models/Squarecreators](#models-squarecreators)
   1. [BlueSquareCreator.cs](#bluesquarecreatorcs)
   2. [GreenSquareCreator.cs](#greensquarecreatorcs)
   3. [RedSquareCreator.cs](#redsquarecreatorcs)
   4. [SquareCreator.cs](#squarecreatorcs)
10. [Models/Trianglecreators](#models-trianglecreators)
   1. [BlueTriangleCreator.cs](#bluetrianglecreatorcs)
   2. [GreenTriangleCreator.cs](#greentrianglecreatorcs)
   3. [RedTriangleCreator.cs](#redtrianglecreatorcs)
   4. [TriangleCreator.cs](#trianglecreatorcs)

## FILE 1: App.xaml

<a id='appxaml'></a>

```xml
﻿<Application x:Class="ColoredFigures.App"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:local="clr-namespace:ColoredFigures"
             StartupUri="MainWindow.xaml">
    <Application.Resources>
         
    </Application.Resources>
</Application>
```

---

## FILE 2: App.xaml.cs

<a id='appxamlcs'></a>

```csharp
﻿using System.Configuration;
using System.Data;
using System.Windows;

namespace ColoredFigures
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
    }

}
```

---

## FILE 3: AssemblyInfo.cs

<a id='assemblyinfocs'></a>

```csharp
using System.Windows;

[assembly: ThemeInfo(
    ResourceDictionaryLocation.None,            //where theme specific resource dictionaries are located
                                                //(used if a resource is not found in the page,
                                                // or application resource dictionaries)
    ResourceDictionaryLocation.SourceAssembly   //where the generic resource dictionary is located
                                                //(used if a resource is not found in the page,
                                                // app, or any theme specific resource dictionaries)
)]
```

---

## FILE 4: ColoredFigures.csproj

<a id='coloredfigurescsproj'></a>

```xml
﻿<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>WinExe</OutputType>
    <TargetFramework>net10.0-windows</TargetFramework>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
    <UseWPF>true</UseWPF>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="CommunityToolkit.Mvvm" Version="8.4.0" />
  </ItemGroup>

</Project>
```

---

## FILE 5: MainWindow.xaml

<a id='mainwindowxaml'></a>

```xml
﻿<Window x:Class="ColoredFigures.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:ColoredFigures"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800">
    <Grid Margin="10">
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="*"/>
        </Grid.RowDefinitions>

        <StackPanel Grid.Row="0" Orientation="Horizontal" Margin="0,0,0,10">
            <TextBlock Text="Цвет:" VerticalAlignment="Center" Margin="5"/>
            <ComboBox x:Name="colorComboBox" Width="120" Margin="5" SelectionChanged="ColorComboBox_SelectionChanged">
                <ComboBoxItem Content="Красный" Tag="Red"/>
                <ComboBoxItem Content="Синий" Tag="Blue"/>
                <ComboBoxItem Content="Зелёный" Tag="Green"/>
            </ComboBox>
            <Button x:Name="addCircleButton" Content="Круг" Width="80" Margin="5" Click="AddCircleButton_Click"/>
            <Button x:Name="addSquareButton" Content="Квадрат" Width="80" Margin="5" Click="AddSquareButton_Click"/>
            <Button x:Name="addTriangleButton" Content="Треугольник" Width="80" Margin="5" Click="AddTriangleButton_Click"/>
        </StackPanel>

        <ScrollViewer Grid.Row="1" VerticalScrollBarVisibility="Auto" HorizontalScrollBarVisibility="Auto">
            <WrapPanel x:Name="figuresPanel" Orientation="Horizontal" />
        </ScrollViewer>
    </Grid>
</Window>
```

---

## FILE 6: MainWindow.xaml.cs

<a id='mainwindowxamlcs'></a>

```csharp
﻿using ColoredFigures.Models.CircleCreators;
using ColoredFigures.Models.SquareCreators;
using ColoredFigures.Models.TriangleCreators;
using System.Windows;
using System.Windows.Controls;

namespace ColoredFigures
{
    public partial class MainWindow : Window
    {
        private CircleCreator? _circleCreator;
        private SquareCreator? _squareCreator;
        private TriangleCreator? _triangleCreator;

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
```

---

## FILE 7: BlueCircleCreator.cs

<a id='bluecirclecreatorcs'></a>

```csharp
﻿using ColoredFigures.Models.Shapes;
using System.Windows.Media;

namespace ColoredFigures.Models.CircleCreators
{
    class BlueCircleCreator : CircleCreator
    {
        public Circle CreateCircle()
        {
            return new Circle { Color = Colors.Blue };
        }
    }
}
```

---

## FILE 8: CircleCreator.cs

<a id='circlecreatorcs'></a>

```csharp
﻿
using ColoredFigures.Models.Shapes;

namespace ColoredFigures.Models.CircleCreators
{
    public interface CircleCreator
    {
        public Circle CreateCircle();
    }
}
```

---

## FILE 9: GreenCircleCreator.cs

<a id='greencirclecreatorcs'></a>

```csharp
﻿using ColoredFigures.Models.Shapes;
using System.Windows.Media;

namespace ColoredFigures.Models.CircleCreators
{
    public class GreenCircleCreator : CircleCreator
    {
        public Circle CreateCircle()
        {
            return new Circle { Color = Colors.Green };
        }
    }
}
```

---

## FILE 10: RedCircleCreator.cs

<a id='redcirclecreatorcs'></a>

```csharp
﻿using ColoredFigures.Models.Shapes;
using System.Windows.Media;

namespace ColoredFigures.Models.CircleCreators
{
    public class RedCircleCreator : CircleCreator
    {
        public Circle CreateCircle()
        {
            return new Circle { Color = Colors.Red };
        }
    }
}
```

---

## FILE 11: Circle.cs

<a id='circlecs'></a>

```csharp
﻿using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ColoredFigures.Models.Shapes
{
    public class Circle : Figure
    {
        public override UIElement CreateUIElement(double size = 50)
        {
            return new Ellipse
            {
                Width = size,
                Height = size,
                Fill = new SolidColorBrush(Color)
            };
        }
    }
}
```

---

## FILE 12: Figure.cs

<a id='figurecs'></a>

```csharp
﻿using System;
using System.Windows;
using System.Windows.Media;

namespace ColoredFigures.Models.Shapes
{
    public abstract class Figure
    {
        public Color Color { get; set; }
        public abstract UIElement CreateUIElement(double size = 50);
    }
}
```

---

## FILE 13: Square.cs

<a id='squarecs'></a>

```csharp
﻿using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;

namespace ColoredFigures.Models.Shapes
{
    public class Square : Figure
    {
        public override UIElement CreateUIElement(double size = 50)
        {
            return new Rectangle()
            {
                Width = size,
                Height = size,
                Fill = new SolidColorBrush(Color)
            };
        }
    }
}
```

---

## FILE 14: Triangle.cs

<a id='trianglecs'></a>

```csharp
﻿using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;

namespace ColoredFigures.Models.Shapes
{
    public class Triangle : Figure
    {
        public override UIElement CreateUIElement(double size = 50)
        {
            var triangle = new Polygon
            {
                Fill = new SolidColorBrush(Color),
                Points = new PointCollection
                {
                    new Point(size / 2, 0), // Top vertex
                    new Point(0, size),     // Bottom left vertex
                    new Point(size, size)   // Bottom right vertex
                },
                Width = size,
                Height = size,
                Stretch = Stretch.Fill
            };
            return triangle;
        }
    }
}
```

---

## FILE 15: BlueSquareCreator.cs

<a id='bluesquarecreatorcs'></a>

```csharp
﻿using ColoredFigures.Models.Shapes;
using System.Windows.Media;
namespace ColoredFigures.Models.SquareCreators
{
    public class BlueSquareCreator : SquareCreator
    {
        public Square CreateSquare()
        {
            return new Square { Color = Colors.Blue };
        }
    }
}
```

---

## FILE 16: GreenSquareCreator.cs

<a id='greensquarecreatorcs'></a>

```csharp
﻿using ColoredFigures.Models.Shapes;
using System.Windows.Media;
namespace ColoredFigures.Models.SquareCreators
{
    public class GreenSquareCreator : SquareCreator
    {
        public Square CreateSquare()
        {
            return new Square { Color = Colors.Green };
        }
    }
}
```

---

## FILE 17: RedSquareCreator.cs

<a id='redsquarecreatorcs'></a>

```csharp
﻿using ColoredFigures.Models.Shapes;
using System.Windows.Media;

namespace ColoredFigures.Models.SquareCreators
{
    public class RedSquareCreator : SquareCreator
    {
        public Square CreateSquare()
        {
            return new Square { Color = Colors.Red };
        }
    }
}
```

---

## FILE 18: SquareCreator.cs

<a id='squarecreatorcs'></a>

```csharp
﻿using ColoredFigures.Models.Shapes;

namespace ColoredFigures.Models.SquareCreators
{
    public interface SquareCreator
    {
        public Square CreateSquare();
    }
}
```

---

## FILE 19: BlueTriangleCreator.cs

<a id='bluetrianglecreatorcs'></a>

```csharp
﻿using ColoredFigures.Models.Shapes;
using System.Windows.Media;

namespace ColoredFigures.Models.TriangleCreators
{
    class BlueTriangleCreator : TriangleCreator
    {
        public Triangle CreateTriangle()
        {
            return new Triangle { Color = Colors.Blue };
        }
    }
}
```

---

## FILE 20: GreenTriangleCreator.cs

<a id='greentrianglecreatorcs'></a>

```csharp
﻿using ColoredFigures.Models.Shapes;
using System.Windows.Media;

namespace ColoredFigures.Models.TriangleCreators
{
    class GreenTriangleCreator : TriangleCreator
    {
        public Triangle CreateTriangle()
        {
            return new Triangle { Color = Colors.Green };
        }
    }
}
```

---

## FILE 21: RedTriangleCreator.cs

<a id='redtrianglecreatorcs'></a>

```csharp
﻿using ColoredFigures.Models.Shapes;
using System.Windows.Media;

namespace ColoredFigures.Models.TriangleCreators
{
    class RedTriangleCreator : TriangleCreator
    {
        public Triangle CreateTriangle()
        {
            return new Triangle { Color = Colors.Red };
        }
    }
}
```

---

## FILE 22: TriangleCreator.cs

<a id='trianglecreatorcs'></a>

```csharp
﻿using ColoredFigures.Models.Shapes;

namespace ColoredFigures.Models.TriangleCreators
{
    public interface TriangleCreator
    {
        public Triangle CreateTriangle();
    }
}
```

---

