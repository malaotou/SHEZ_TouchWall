using DevExpress.Xpf.Carousel;
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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SHEZ_TouchWall
{
    /// <summary>
    /// Interaction logic for UCPhotoGallery2.xaml
    /// </summary>
    public partial class UCPhotoGallery2 : UserControl
    {
        public UCPhotoGallery2()
        {
            InitializeComponent();
            AddItems(@"/CarouselDemo;component/Data/Images/Photos", ItemType.BinaryImage, carousel);
        }

        protected void AddItems(string path, ItemType it, CarouselPanel carousel)
        {
            var items = CreateItems(path, it);
            foreach (var item in items)
            {
                ContentControl control = new ContentControl();
                control.Template = carousel.Resources["itemTemplate"] as ControlTemplate;
                control.Style = carousel.Resources["itemStyle"] as Style;
                control.DataContext = ((Image)item).Source;
                carousel.Children.Add(control);
            }
        }

        private List<Image> CreateItems(string path, ItemType it)
        {
            List<Image> image = new List<Image>();

            //DirectoryInfo diinfo = new DirectoryInfo("");
            //var files=diinfo.EnumerateFiles();

            for (int i = 1; i < 9; i++)
            {
                Image imageitem = new Image();
                string url = string.Format("/images/realEstate/{0}.jpg", i);
                imageitem.Source = new BitmapImage(new Uri(url, UriKind.Relative));
                image.Add(imageitem);
            }
            return image;

        }
        private void Image_TouchDown(object sender, TouchEventArgs e)
        {
            Image image = new Image();
            Image source = (sender as Image);
            image.Source = source.Source;

            

            image.SetValue(Canvas.TopProperty, TransformToScreen(GetMousePosition(),
                ((SHEZ_TouchWall.MainWindow)Application.Current.MainWindow).container).Y);
            image.SetValue(Canvas.LeftProperty, TransformToScreen(GetMousePosition(),
                ((SHEZ_TouchWall.MainWindow)Application.Current.MainWindow).container).X);
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
            //}
        }
        static Point TransformToScreen(Point point, Visual relativeTo)

        {

            HwndSource hwndSource = PresentationSource.FromVisual(relativeTo) as HwndSource;

            Visual root = hwndSource.RootVisual;

            // Translate the point from the visual to the root.

            GeneralTransform transformToRoot = relativeTo.TransformToAncestor(root);

            Point pointRoot = transformToRoot.Transform(point);

            // Transform the point from the root to client coordinates.

            Matrix m = Matrix.Identity;

            Transform transform = VisualTreeHelper.GetTransform(root);



            if (transform != null)

            {

                m = Matrix.Multiply(m, transform.Value);

            }



            Vector offset = VisualTreeHelper.GetOffset(root);

            m.Translate(offset.X, offset.Y);



            Point pointClient = m.Transform(pointRoot);

            // Convert from “device-independent pixels” into pixels.

            pointClient = hwndSource.CompositionTarget.TransformToDevice.Transform(pointClient);



            POINT pointClientPixels = new POINT();

            pointClientPixels.x = (0 < pointClient.X) ? (int)(pointClient.X + 0.5) : (int)(pointClient.X - 0.5);

            pointClientPixels.y = (0 < pointClient.Y) ? (int)(pointClient.Y + 0.5) : (int)(pointClient.Y - 0.5);



            // Transform the point into screen coordinates.

            POINT pointScreenPixels = pointClientPixels;

            ClientToScreen(hwndSource.Handle, pointScreenPixels);



            return new Point(pointScreenPixels.x, pointScreenPixels.y);

        }



        [StructLayout(LayoutKind.Sequential)]

        public class POINT

        {

            public int x = 0;

            public int y = 0;

        }



        [DllImport("User32", EntryPoint = "ClientToScreen", SetLastError = true,
        ExactSpelling = true, CharSet = CharSet.Auto)]

        private static extern int ClientToScreen(IntPtr hWnd, [In, Out] POINT pt);
    }
}
