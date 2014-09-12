using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Phone.Controls;
using PhoneApp2.Resources;
using Microsoft.Devices;
using Microsoft.Devices.Sensors;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows.Media;
using PhoneApp2.model;
using goniometer.view;
using goniometer.model;

namespace PhoneApp2
{
    public partial class MainPage : PhoneApplicationPage
    {

        private Point[] currPoints = new Point[2];
        private bool isEditing = false;
        private bool isDrawingAble = true;
        private int indexEdited;
       
        public MainPage()
        {
            InitializeComponent();

            DrawOnCanvas.setCanvas(MyCanvas);

            this.OrientationChanged +=
             new EventHandler<OrientationChangedEventArgs>(OnOrientationChanged);

            Touch.FrameReported += new TouchFrameEventHandler(Touch_FrameReported);

            viewfinderBrush.SetSource(CameraSingleton.getInstance());
            CameraLayout.Visibility = CameraSingleton.getCondition();
        }

        private void OnOrientationChanged(object sender, OrientationChangedEventArgs e)
        {
            if (e.Orientation == PageOrientation.LandscapeRight)
                rotateElements(180);
            else
                rotateElements(0);
        }

        private void rotateElements(byte angle)
        {
            rotateTransform.Angle = angle;
            textBlockRotation.Rotation = angle;
            buttonRotation.Rotation = angle;
        }

        private void Touch_FrameReported(object sender, TouchFrameEventArgs e)
        {
            if (isDrawingAble)
            {
                int pointsNumber = e.GetTouchPoints(MyCanvas).Count;
                TouchPointCollection pointCollection = e.GetTouchPoints(MyCanvas);

                MyCanvas.Children.Clear();

                if (pointsNumber == 1)
                {
                    Point point = pointCollection[0].Position;

                    if (isEditing)
                    {
                        currPoints[indexEdited] = point;
                        showPoints();
                    }

                    if (checkAllPointsForIntersectionWithTouch(point))
                        return;

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
        }

        private void CameraButton_Click(object sender, RoutedEventArgs e)
        {
            CameraLayout.Visibility = CameraSingleton.getCondition();
        }

        private void MyCanvas_MouseLeave(object sender, MouseEventArgs e)
        {
            isEditing = false;
        }

        private void CameraButton_MouseEnter(object sender, MouseEventArgs e)
        {
            isDrawingAble = false;
        }

        private void CameraButton_MouseLeave(object sender, MouseEventArgs e)
        {
            isDrawingAble = true;
        } 

        private bool checkAllPointsForIntersectionWithTouch(Point point)
        {
            for (int i = 0; i < 2; i++)
                if (isIntersect(point, currPoints[i]))
                {
                    currPoints[i] = point;

                    showPoints();

                    indexEdited = i;
                    isEditing = true;

                    return true;
                }
            return false;
        }

        private bool isIntersect(Point first, Point second)
        {
            return (first.X > 30 || first.Y > 30) && Math.Abs(first.X - second.X) <= 30 && Math.Abs(first.Y - second.Y) <= 30;
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
    }
}