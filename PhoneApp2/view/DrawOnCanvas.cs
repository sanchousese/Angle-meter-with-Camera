using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Windows.UI;

namespace goniometer.view
{
    class DrawOnCanvas
    {

        private static Canvas canvas;
        private const double radiusPoint = 30;


        private DrawOnCanvas(Canvas canvas){}

        public static void setCanvas(Canvas thatCanvas)
        {
            canvas = thatCanvas;
        }

        public static void touching(System.Windows.Point point)
        {
            drawLineTo(point);

            drawPoint(point);
        }

        private static void drawPoint(Point point)
        {
            Ellipse ellipse = new Ellipse();
            ellipse.Fill = new SolidColorBrush(Colors.Red);
            ellipse.Width = radiusPoint;
            ellipse.Height = radiusPoint;
            Canvas.SetLeft(ellipse, point.X - radiusPoint / 2);
            Canvas.SetTop(ellipse, point.Y - radiusPoint / 2);
            canvas.Children.Add(ellipse);
        }

        private static void drawLineTo(Point point)
        {
            point = findThirdPoint(point);
            Line line = new Line();
            line.Stroke = new SolidColorBrush(Colors.Red);
            line.StrokeThickness = 5;
            line.Opacity = 0.5;
            line.X1 = point.X;
            line.Y1 = point.Y;
            line.X2 = canvas.Width / 2;
            line.Y2 = canvas.Height;
            canvas.Children.Add(line);

        }


        private static Point findThirdPoint(Point c)
        {
            double lambda = findRatio(c);
            Point point = new Point();
            point.X = (c.X * (1 + lambda) - canvas.Width / 2) / lambda;
            point.Y = (c.Y * (1 + lambda) - canvas.Height) / lambda;
            return point;
        }

        private static double findRatio(Point c)
        {
            double length = Math.Sqrt(Math.Pow(c.X - canvas.Width / 2, 2) + Math.Pow(c.Y - canvas.Height, 2));
            return length / canvas.Width;
        }

    }
}
