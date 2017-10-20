using DevExpress.Xpf.Carousel;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for UCPhotoGallery2.xaml
    /// </summary>
    public partial class UCPhotoGallery2 : UserControl
    {
        public UCPhotoGallery2()
        {
            InitializeComponent();
            AddItems(@"/CarouselDemo;component/Data/Images/Photos", ItemType.BinaryImage, carousel);
        }

        protected  void AddItems(string path, ItemType it, CarouselPanel carousel)
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

            for(int i = 0; i < 3; i++)
            {
                Image imageitem = new Image();
                string url = string.Format("/images/realEstate/{0}.jpg", i);
                imageitem.Source = new BitmapImage(new Uri(url,UriKind.Relative));
                image.Add(imageitem);
            }
            return image;
           
        }
    }
}
