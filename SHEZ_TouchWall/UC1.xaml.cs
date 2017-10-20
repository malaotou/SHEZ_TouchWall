using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SHEZ_TouchWall
{
    /// <summary>
    /// Interaction logic for UC1.xaml
    /// </summary>
    public partial class UC1 : UserControl
    {
        public UC1()
        {
            InitializeComponent();
            animate();


        }
        private void animate()
        {
            //Storyboard sb = (Storyboard)this.image.FindResource("spin");
            //sb.Begin();
            //sb.SetSpeedRatio(100);//sample data
            //DoubleAnimation doubleAnimation = new DoubleAnimation();
            //doubleAnimation.From = 100;
            //doubleAnimation.To = 20;
            //doubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(3));
            //doubleAnimation.AutoReverse = true;
            //doubleAnimation.RepeatBehavior = RepeatBehavior.Forever;

            //Storyboard storyboard = new Storyboard();
            //storyboard.Children.Add(doubleAnimation);
            //Storyboard.SetTarget(doubleAnimation, image);
            //Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath(Image.HeightProperty));//
            //storyboard.Begin();
             

        }
        private void h_Main_PreviewMouseMove(object sender, MouseEventArgs e)
        {

        }

        private void h_Main_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scrollViewer = sender as ScrollViewer;

            if (e.Delta > 0)
            {
                scrollViewer.LineLeft();
            }
            else
                scrollViewer.LineRight();
            e.Handled = true;
        }

        private void image_TouchEnter(object sender, TouchEventArgs e)
        {

        }

        private void h_Main_ManipulationStarting(object sender, ManipulationStartingEventArgs e)
        {

        }

        private void h_Main_ManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        {

        }
    }
}
