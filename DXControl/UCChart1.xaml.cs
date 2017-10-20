using DevExpress.Xpf.Charts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace DXControl
{
    /// <summary>
    /// Interaction logic for UCChart1.xaml
    /// </summary>
    public partial class UCChart1 : UserControl
    {
        public UCChart1()
        {
            InitializeComponent();
            series.ToolTipPointPattern = "X = {A}\nY = {V}";
            

        }
        //public override ChartControl ActualChart { get { return chart; } }

         
        void ChartsDemoModule_ModuleAppear(object sender, RoutedEventArgs e)
        {
            chart.Animate();
        }
    }
    public class PointCollection : ObservableCollection<Point>
    {
    }
}
