﻿#pragma checksum "C:\Users\Sania_000\documents\visual studio 2013\Projects\PhoneApp2\PhoneApp2\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "309FA13F4D662E5D9FFC096176744979"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace PhoneApp2 {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Media.RotateTransform rotateTransform;
        
        internal System.Windows.Shapes.Rectangle CameraLayout;
        
        internal System.Windows.Media.VideoBrush viewfinderBrush;
        
        internal System.Windows.Controls.Image TransportirImage;
        
        internal System.Windows.Controls.TextBlock textAngle;
        
        internal System.Windows.Media.CompositeTransform textBlockRotation;
        
        internal System.Windows.Controls.Canvas MyCanvas;
        
        internal System.Windows.Controls.Button CameraButton;
        
        internal System.Windows.Media.CompositeTransform buttonRotation;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/PhoneApp2;component/MainPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.rotateTransform = ((System.Windows.Media.RotateTransform)(this.FindName("rotateTransform")));
            this.CameraLayout = ((System.Windows.Shapes.Rectangle)(this.FindName("CameraLayout")));
            this.viewfinderBrush = ((System.Windows.Media.VideoBrush)(this.FindName("viewfinderBrush")));
            this.TransportirImage = ((System.Windows.Controls.Image)(this.FindName("TransportirImage")));
            this.textAngle = ((System.Windows.Controls.TextBlock)(this.FindName("textAngle")));
            this.textBlockRotation = ((System.Windows.Media.CompositeTransform)(this.FindName("textBlockRotation")));
            this.MyCanvas = ((System.Windows.Controls.Canvas)(this.FindName("MyCanvas")));
            this.CameraButton = ((System.Windows.Controls.Button)(this.FindName("CameraButton")));
            this.buttonRotation = ((System.Windows.Media.CompositeTransform)(this.FindName("buttonRotation")));
        }
    }
}

