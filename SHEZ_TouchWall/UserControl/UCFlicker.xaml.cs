using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
            image.SetValue(Canvas.TopProperty, GetMousePosition().Y);
            image.SetValue(Canvas.LeftProperty, GetMousePosition().X);
            image.IsManipulationEnabled = true;
            ((SHEZ_TouchWall.MainWindow)Application.Current.MainWindow).container.Children.Add(image);
        }


        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetCursorPos(ref Win32Point pt);

        [StructLayout(LayoutKind.Sequential)]
        internal struct Win32Point
        {
            public Int32 X;
            public Int32 Y;
        };
        public static Point GetMousePosition()
        {
            Win32Point w32Mouse = new Win32Point();
            GetCursorPos(ref w32Mouse);
            return new Point(w32Mouse.X, w32Mouse.Y);
        }
    }
}
