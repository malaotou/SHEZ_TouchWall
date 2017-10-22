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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SHEZ_TouchWall
{
    /// <summary>
    /// Interaction logic for UCTitle.xaml
    /// </summary>
    public partial class UCTitle : UserControl
    {
        public UCTitle()
        {
            InitializeComponent();
//            ag1.DataContext = Agents;
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

        private void Tile_MouseDown(object sender, MouseButtonEventArgs e)
        {

            var source = (sender as Image);
            PhotoTemplate pt = new PhotoTemplate();
            pt.DataContext = new Modules.ImageInfo
            {
                ImgSource = source.Source
            };
            var point = new Point();
            var container = ((SHEZ_TouchWall.MainWindow)Application.Current.MainWindow).container;
            //point.X=source.TranslatePoint
            //Canvas.SetTop(pt, point.Y - pt.Height);
            //Canvas.SetLeft(pt, point.X - pt.Width);
            //pt.SetValue(Canvas.TopProperty, source.TranslatePoint();
            //pt.SetValue(Canvas.LeftProperty, TransformToScreen(new Point(), ((SHEZ_TouchWall.MainWindow)Application.Current.MainWindow).container).X);
            //((SHEZ_TouchWall.MainWindow)Application.Current.MainWindow).container.Children.Add(pt);
        }
        public List<Agent> Agents
        {
            get { return Agentss.DataSource; }

        }
        public string Size
        {
            get { return "Large"; }
        }
        public class Agent
        {
            public string AgentName { get; set; }
            public string Phone { get; set; }
            public string Photo { get; set; }
            public string size { get; set; }
            public ImageSource PhotoSource
            {
                get
                {
                    return string.IsNullOrEmpty(Photo) ? null : new BitmapImage(new Uri(Photo, UriKind.Relative));
                }
            }
        }

        public static class Agentss
        {
            public static readonly List<Agent> DataSource =
                new List<Agent> {
                new Agent { AgentName = "Anthony Peterson", Phone = "(555) 444-0782", Photo = "/Images/Agents/1.jpg" },
                new Agent { AgentName = "Rachel Scott", Phone = "(555) 249-1614", Photo = "/Images/Agents/2.jpg" },
                new Agent { AgentName = "Albert Walker", Phone = "(555) 232-2303", Photo = "/Images/Agents/3.jpg" }
                };
        }
    }
}
