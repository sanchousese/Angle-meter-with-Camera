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
using PhoneApp2.model;

namespace PhoneApp2
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();

            DrawOnCanvas.setCanvas(MyCanvas);

            Touch.FrameReported += new TouchFrameEventHandler(Touch_FrameReported);

            viewfinderBrush.SetSource(CameraSingleton.getInstance());
        }

        private void Touch_FrameReported(object sender, TouchFrameEventArgs e)
        {
            int pointsNumber = e.GetTouchPoints(MyCanvas).Count;
            TouchPointCollection pointCollection = e.GetTouchPoints(MyCanvas);

            MyCanvas.Children.Clear();

            if (pointsNumber == 1)
            {
                Point point = pointCollection[0].Position;
                DrawOnCanvas.touching(point);
                textAngle.Text = AngleCounter.calculateAngle(point, MyCanvas) + "'";
            }
            else
            {
                Point first = pointCollection[0].Position;
                Point second = pointCollection[1].Position;

                DrawOnCanvas.touching(first);
                DrawOnCanvas.touching(second);

                textAngle.Text = AngleCounter.calculateAngle(first, second, MyCanvas) + "'";
            }
        }


        private void CameraButton_Click(object sender, RoutedEventArgs e)
        {
            CameraLayout.Visibility = CameraSingleton.getCondition();
        }

    }
}