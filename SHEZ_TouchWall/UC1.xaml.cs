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
    /// Interaction logic for UC1.xaml
    /// </summary>
    public partial class UC1 : UserControl
    {
        public UC1()
        {
            InitializeComponent();
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
    }
}
