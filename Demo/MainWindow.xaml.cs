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

namespace Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //demos.ScrollToHorizontalOffset(909);
        }
        private void h_Main_ManipulationStarting(object sender, ManipulationStartingEventArgs e)
        {
            e.ManipulationContainer = h_Main1;
            e.Mode = ManipulationModes.All;
        }

        private void h_Main_ManipulationDelta(object sender, ManipulationDeltaEventArgs e)
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

        private void h_Main_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)e.Source;
            element.Opacity = 1;

        }
    }
}
