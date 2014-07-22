using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Phone.Controls;
using PhoneApp2.Resources;
using Microsoft.Devices;
using Microsoft.Devices.Sensors;
using goniometer.view;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows.Media;
using goniometer.model;

namespace PhoneApp2
{
    public partial class MainPage : PhoneApplicationPage
    {
        private DrawOnCanvas drawOnCanvas;
        bool isCameraDemonstrate = true;

        public MainPage()
        {
            InitializeComponent();
            drawOnCanvas = new DrawOnCanvas(MyCanvas);
            Touch.FrameReported += new TouchFrameEventHandler(Touch_FrameReported);
            viewfinderBrush.SetSource(new PhotoCamera(CameraType.Primary));
        }

        double[] preXArray = new double[10];
        double[] preYArray = new double[10];


        private void Touch_FrameReported(object sender, TouchFrameEventArgs e)
        {
            int pointsNumber = e.GetTouchPoints(MyCanvas).Count;
            TouchPointCollection pointCollection = e.GetTouchPoints(MyCanvas);

            MyCanvas.Children.Clear();

            if (pointsNumber == 1)
            {
                Point point = pointCollection[0].Position;
                drawOnCanvas.touching(point);
                textAngle.Text = AngleCounter.calculateAngle(point, MyCanvas) + "'";
            }
            else
            {
                Point first = pointCollection[0].Position;
                Point second = pointCollection[1].Position;
                Point middle = new Point(MyCanvas.Width / 2, MyCanvas.Height);

                drawOnCanvas.touching(first);
                drawOnCanvas.touching(second);

                textAngle.Text = AngleCounter.calculateAngle(first, middle, second) + "'";
            }
        }

        private void CameraButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isCameraDemonstrate)
                CameraLayout.Visibility = Visibility.Visible;
            else
                CameraLayout.Visibility = Visibility.Collapsed;

            isCameraDemonstrate = !isCameraDemonstrate;

        }

    }
}