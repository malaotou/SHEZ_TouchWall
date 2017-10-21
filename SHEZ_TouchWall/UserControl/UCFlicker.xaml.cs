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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SHEZ_TouchWall
{
    /// <summary>
    /// Interaction logic for UCFlicker.xaml
    /// </summary>
    public partial class UCFlicker : UserControl
    {
        public UCFlicker()
        {
            InitializeComponent();
        }

        private void Image_TouchDown(object sender, TouchEventArgs e)
        {
            Image image = new Image();
            var source = (sender as Image);
            image.Source = source.Source;
            image.SetValue(Canvas.TopProperty, source.GetValue(Canvas.TopProperty));
            image.SetValue(Canvas.LeftProperty, source.GetValue(Canvas.LeftProperty));
            image.IsManipulationEnabled = true;
            ((SHEZ_TouchWall.MainWindow)Application.Current.MainWindow).container.Children.Add(image);
        }
    }
}
