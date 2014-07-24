using Microsoft.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PhoneApp2.model
{
    class CameraSingleton
    {
        private static PhotoCamera instance;
        private static bool isCameraDemonstrate = true;

        private CameraSingleton() { }

        public static PhotoCamera getInstance()
        {
            if (instance == null)
                instance = new PhotoCamera(CameraType.Primary);
            return instance;
        }

        public static Visibility getCondition()
        {
            isCameraDemonstrate = !isCameraDemonstrate;
            return !isCameraDemonstrate ? Visibility.Collapsed : Visibility.Visible;
        }
    }
}
