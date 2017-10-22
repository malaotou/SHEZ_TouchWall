using SHEZ_TouchWall.Modules;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Media.Animation;
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
            initImages();
        }

        private void initImages()
        {
            //throw new NotImplementedException();
            Flickers flicker = new Modules.Flickers();
            List<BitmapImage> imgList = new List<BitmapImage>();
            
           
            string[] filePaths = Directory.GetFiles(@"D:\resources\");
            for(int i = 0; i < filePaths.Length; i++)
            {
                imgList.Add(new BitmapImage(new Uri(filePaths[i])));
            }
            flicker.images = imgList;
            this.DataContext = flicker;
        }

        private void Image_TouchDown(object sender, TouchEventArgs e)
        {
            var source = (sender as Image);
            PhotoTemplate pt = new PhotoTemplate();
            pt.DataContext = new Modules.ImageInfo
            {
                ImgSource = source.Source
            };

            //Image image = new Image();

            //image.Source = source.Source;
            //pt.SetValue(Canvas.TopProperty, GetMousePosition().Y);
            //pt.SetValue(Canvas.LeftProperty, GetMousePosition().X);
            //pt.IsManipulationEnabled = true;
            //var matrx = new MatrixTransform();
            //Matrix toMatrix = matrx.Matrix;
            //toMatrix.M11 = 1.3;
            //toMatrix.M12 = 0.1;
            //toMatrix.M22 = 1.2;
            //toMatrix.OffsetX = 1.3;
            //toMatrix.M11 = 1.3;

            //var scaler = this.LayoutTransform as ScaleTransform;
            //if (scaler == null)
            //{
            //    scaler = new ScaleTransform(1.0, 1.0);
            //    this.LayoutTransform = scaler;
            //}
            //DoubleAnimation animator = new DoubleAnimation()
            //{
            //    Duration = new Duration(TimeSpan.FromMilliseconds(600)),
            //};
            //if (scaler.ScaleX == 1.0)
            //{
            //    animator.To = 1.5;
            //}
            //else
            //{
            //    animator.To = 1.0;
            //}
            //scaler.BeginAnimation(ScaleTransform.CenterXProperty, animator);
            //scaler.BeginAnimation(ScaleTransform.CenterYProperty, animator);
            //DoubleAnimation da = new DoubleAnimation();
            //da.From =0;
            //da.To =400;
            //da.Duration = new Duration(TimeSpan.FromSeconds(1));





            //this.BeginAnimation(Window.TopProperty, da);
            POINT point;
            GetCursorPos(out point); 
            Canvas.SetTop(pt, point.Y - pt.Height);
            Canvas.SetLeft(pt, point.X - pt.Width);
            ((SHEZ_TouchWall.MainWindow)Application.Current.MainWindow).container.Children.Add(pt);
           
        }



        [StructLayout(LayoutKind.Sequential)]
        public struct POINT

        {
            public int X;

            public int Y;
            public POINT(int x, int y)

            {
                this.X = x;

                this.Y = y;
            }
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetCursorPos(out POINT pt);


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

        private void Image_TouchDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
