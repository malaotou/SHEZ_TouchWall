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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SHEZ_TouchWall
{
    /// <summary>
    /// Interaction logic for PhotoTemplate.xaml
    /// </summary>
    public partial class PhotoTemplate : UserControl
    {
        public PhotoTemplate()
        {
            InitializeComponent();

            //DoubleAnimation myDoubleAnimation = new DoubleAnimation();
            //myDoubleAnimation.From = 100;
            //myDoubleAnimation.To = 200;
            //myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(20));
            //Storyboard.SetTargetName(myDoubleAnimation, "imgPic1");
            //Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(Image.WidthProperty));
        }

        private void Image_TouchDown(object sender, TouchEventArgs e)
        {
            ((SHEZ_TouchWall.MainWindow)Application.Current.MainWindow).container.Children.Remove(this);
        }
    }
}
