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

        private Point[] currPoints = new Point[2];
        private bool isEditing = false;
        int index;

        public MainPage()
        {
            InitializeComponent();

            DrawOnCanvas.setCanvas(MyCanvas);

            Touch.FrameReported += new TouchFrameEventHandler(Touch_FrameReported);

            viewfinderBrush.SetSource(CameraSingleton.getInstance());
            CameraLayout.Visibility = CameraSingleton.getCondition();
        }

        private void Touch_FrameReported(object sender, TouchFrameEventArgs e)
        {
           int pointsNumber = e.GetTouchPoints(MyCanvas).Count;
           TouchPointCollection pointCollection = e.GetTouchPoints(MyCanvas);

            MyCanvas.Children.Clear();

            if (pointsNumber == 1)
            {
                Point point = pointCollection[0].Position;

                if (isEditing)
                {
                    currPoints[index] = point;
                    showPoints();
                }


                for (int i = 0; i < 2; i++)
                {
                    if (isIntersect(point, currPoints[i]))
                    {
                        currPoints[i] = point;

                        showPoints();

                        index = i;
                        isEditing = true;

                        return;
                    }

                }

                currPoints = new Point[2];
                showPoint(point);
            }
            else
            {
                currPoints[0] = pointCollection[0].Position;
                currPoints[1] = pointCollection[1].Position;
                showPoints();
            }
        }

        private void showPoint(Point point)
        {
            DrawOnCanvas.touching(point);
            textAngle.Text = AngleCounter.calculateAngle(point, MyCanvas) + "'";
        }

        private void showPoints()
        {
            DrawOnCanvas.touching(currPoints[0]);
            DrawOnCanvas.touching(currPoints[1]);

            textAngle.Text = AngleCounter.calculateAngle(currPoints[0], currPoints[1], MyCanvas) + "'";
        }

        private bool isIntersect(Point first, Point second)
        {
            return Math.Abs(first.X - second.X) <= 30 && Math.Abs(first.Y - second.Y) <= 30;
        }

        private void CameraButton_Click(object sender, RoutedEventArgs e)
        {
            CameraLayout.Visibility = CameraSingleton.getCondition();
        }

        private void MyCanvas_MouseLeave(object sender, MouseEventArgs e)
        {
            isEditing = false;
        }

    }
}