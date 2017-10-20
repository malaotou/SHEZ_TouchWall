using System;
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

namespace SHEZ_TouchWall
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : DXWindow
    {
        public MainWindow()
        {
            InitializeComponent();
             
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
            e.ManipulationContainer = h_Main1;
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
    }
}
