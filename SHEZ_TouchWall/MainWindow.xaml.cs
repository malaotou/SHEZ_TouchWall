﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevExpress.Xpf.Core;
using System.Windows.Threading;

namespace SHEZ_TouchWall
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : DXWindow
    {
        private DispatcherTimer timer = null;
        public MainWindow()
        {
            InitializeComponent();
            Image image3 = new Image();
            image3.Source = new BitmapImage(new Uri(@"d:\bg.jpg"));
            image3.IsManipulationEnabled = true;
            //image3.IsManipulationEnabled 
            image3.Width = 200;
            image3.Height = 200;
            container.Children.Add(image3);

            //demo.Children.Add(image);
        }
        private void initControl()
        {
            //main_canvas.SetValue(Canvas.ZIndexProperty, -100);
            //main_canvas.SetZIndex(-100);
            //h_Main.SetZIndex(100);
        }

        private void h_Main_PreviewMouseMove(object sender, MouseEventArgs e)
        {

        }

        private void h_Main_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            //ScrollViewer scrollViewer = sender as ScrollViewer;

            //if (e.Delta > 0)
            //{
            //    scrollViewer.LineLeft();
            //}
            //else
            //    scrollViewer.LineRight();
            //e.Handled = true;
        }

        private void h_Main_ManipulationBoundaryFeedback(object sender, ManipulationBoundaryFeedbackEventArgs e)
        {
            e.Handled = true;
        }

        private void h_Main_ManipulationStarting(object sender, ManipulationStartingEventArgs e)
        {
            e.ManipulationContainer = container;
            e.Mode = ManipulationModes.All;
        }

        private void h_Main_ManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        {
            try
            {
                FrameworkElement element = (FrameworkElement)e.Source;
                element.Opacity = 0.5;
                Matrix matrix = ((MatrixTransform)element.RenderTransform).Matrix;
                var deltaManipulation = e.DeltaManipulation;
                Point center = new Point(element.ActualWidth / 2, element.ActualHeight / 2);
                center = matrix.Transform(center);
                matrix.ScaleAt(deltaManipulation.Scale.X, deltaManipulation.Scale.Y, center.X, center.Y);
                matrix.RotateAt(e.DeltaManipulation.Rotation, center.X, center.Y);
                matrix.Translate(e.DeltaManipulation.Translation.X, e.DeltaManipulation.Translation.Y);
                ((MatrixTransform)element.RenderTransform).Matrix = matrix;
            }
            catch(Exception ex)
            {

            }
              
        }

        private void h_Main_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)e.Source;
            element.Opacity = 1;

        }

        private void UCBook_TouchDown(object sender, TouchEventArgs e)
        {
            UCBook book = new SHEZ_TouchWall.UCBook();
            e.Handled = true;
           
        }

        private void RootWindow_TouchDown(object sender, TouchEventArgs e)
        {
            e.Handled = true;
            //Image image3 = new Image();
            //image3.Source = new BitmapImage(new Uri(@"d:\bg.jpg"));
            //image3.IsManipulationEnabled = true;
            //image3.Width = 200;
            //image3.Height = 200;
            //container.Children.Add(image3);
            ////if(e.OriginalSource==Image)
            //if (e.OriginalSource.GetType() == typeof(Image))
            //{
            //    var image = (Image)e.OriginalSource;
            //    var image2 = new Image();
            //    image2.Source = image2.Source;
            //    image2.SetLeft(image.GetPosition(container).X);
            //    image2.SetTop(image.GetPosition(container).Y);
            //    image2.Width =image.Width+100;
            //    image2.Height = image.Height + 100;
            //    image2.IsManipulationEnabled = true;
            //    container.Children.Add(image2);


            //}
        }
    }
}
