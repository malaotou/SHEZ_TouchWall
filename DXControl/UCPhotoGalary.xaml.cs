using DevExpress.Xpf.Bars;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Emit;
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
using System.Xml.Linq;

namespace DXControl
{
    /// <summary>
    /// Interaction logic for UCPhotoGalary.xaml
    /// </summary>
    public partial class UCPhotoGalary : UserControl
    {
        CitiesViewModel ViewModel { get { return LayoutRoot.DataContext as CitiesViewModel; } }

        public UCPhotoGalary()
        {
            InitializeComponent();
            //CitiesViewModel viewModel = ViewModelSource.Create(() => new CitiesViewModel(map));
            //LayoutRoot.DataContext = viewModel;
           // placePointer.Content = viewModel;
        }
        void GalleryItemClick(object sender, RoutedEventArgs e)
        {
            PhotoGalleryItemControl item = sender as PhotoGalleryItemControl;
            if (item != null)
                ViewModel.SelectedPlace = item.DataContext as PlaceInfo;
        }
        void OnGalleryClose(object sender, RoutedEventArgs e)
        {
            ViewModel.SelectedCity = null;
        }
        void OnBackClick(object sender, RoutedEventArgs e)
        {
            ViewModel.SelectedCity = null;
        }
        void photoGallery_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ViewModel.SelectedCity = null;
        }
       
    }
    public enum ViewType
    {
        Map,
        Gallery,
        Detail
    }


    public class CitiesViewModel 
    {
        const int InitialZoomLevel = 5;
        const int MaxZoomLevelInWorldView = 7;
        const int MinZoomLevelInWorldView = 5;
        const int MinZoomLevelInCityView = 15;
        const int MaxZoomLevelInCityView = 18;

        public virtual ObservableCollection<CityInfo> Cities { get; set; }
        public virtual ObservableCollection<CityInfo> CitiesMini { get; set; }
        public virtual CityInfo SelectedCity { get; set; }
        protected void OnSelectedCityChanged()
        {
            SelectedPlace = null;
            UpdateViewType();
        }
        public virtual PlaceInfo SelectedPlace { get; set; }
        protected void OnSelectedPlaceChanged()
        {
            UpdateViewType();
        }
        public virtual ViewType ViewType { get; set; }
        public virtual Point CityPoint { get; set; }
        public virtual double ZoomLevel { get; set; }
        public virtual int MinZoomLevel { get; set; }
        public virtual int MaxZoomLevel { get; set; }
        
        
         
        void UpdateViewType()
        {
            if (SelectedCity != null)
                ViewType = SelectedPlace != null ? ViewType.Detail : ViewType.Gallery;
            else
                ViewType = ViewType.Map;
        }
       
    }

    public class PlaceInfo
    {
        readonly string name;
        readonly string cityName;
        readonly string description;
        readonly BitmapImage imageSource;

        public string Name { get { return name; } }
        public string CityName { get { return cityName; } }
        public string Description { get { return description; } }
        public BitmapImage ImageSource { get { return imageSource; } }

        public PlaceInfo(string name, string cityName, string description, BitmapImage imageSource)
        {
            this.name = name;
            this.cityName = cityName;
           
            this.description = description;
            this.imageSource = imageSource;
        }
    }

    public class CityInfo
    {
        readonly string name;
     
        readonly List<PlaceInfo> places = new List<PlaceInfo>();

        public string Name { get { return name; } }
       
        public List<PlaceInfo> Places { get { return places; } }

        public CityInfo(string name)
        {
            this.name = name;
           
        }
    }
}
