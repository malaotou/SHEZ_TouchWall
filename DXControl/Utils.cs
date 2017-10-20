

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Data;
using System.Windows;
using System.Windows.Media;
using DevExpress.Xpf.Carousel;
using System.Windows.Media.Imaging;
using System.Windows.Media.Effects;
using System.Globalization;
using DevExpress.Xpf.LayoutControl;
using DevExpress.Xpf.Core;
using System.Windows.Input;
using System.Xml.Linq;
using System.Windows.Resources;
using DevExpress.Xpf.Charts;

namespace DXControl
{
    public enum ItemType { BinaryImage, DrawingImage }
    public class ImageContainer_bak
    {
        public string Name { get; set; }
        public ImageSource Source { get; set; }
    }
    public class PathContainer
    {
        public string Name { get; set; }
        public PathGeometry Path { get; set; }
    }
    public class FunctionContainer
    {
        public string Name { get; set; }
        public FunctionBase FunctionBase { get; set; }
    }
    public class BitmapEffectContainer
    {
        public string Name { get; set; }
        public BitmapEffect BitmapEffect { get; set; }
    }
    public class LanguageContainer
    {
        public string Name { get; set; }
        public string FlagImageSource { get; set; }
        public string Phrase { get; set; }
    }
    public class PhraseConverter : MarkupExtension, IValueConverter
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var cc = (ContentControl)value;
            if (cc != null)
            {
                var lc = (LanguageContainer)cc.Content;
                return lc.Phrase;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }

        #endregion
    }
    public class LanguageContainerConverter : MarkupExtension, IValueConverter
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }


        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class FunctionContainerConverter : MarkupExtension, IValueConverter
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            IList list = (IList)parameter;
            foreach (object item in list)
            {
                FunctionContainer container = item as FunctionContainer;
                if (container != null && container.FunctionBase == value)
                    return container;
            }
            return list[0];
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ((FunctionContainer)value).FunctionBase;
        }

        #endregion
    }
    public class BitmapEffectContainerConverter : MarkupExtension, IValueConverter
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ((IList)parameter)[0];
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ((FunctionContainer)value).FunctionBase;
        }

        #endregion
    }
    public class DoubleToVisibleItemCountConverter : MarkupExtension, IValueConverter
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double doubleValue = (double)value;
            int returnValue = (int)(doubleValue);
            returnValue *= 2;
            return returnValue + 1;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (targetType != typeof(double))
                throw new InvalidOperationException();
            return (double)((((int)value) - 1) / 2);
        }
        #endregion
    }
    public class VisibleItemCountToActiveElementIndexConverter : MarkupExtension, IValueConverter
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (targetType != typeof(int))
                throw new InvalidOperationException();
            return ((((int)value) - 1) / 2);
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
    public class DoubleToIntConverter : MarkupExtension, IValueConverter
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (targetType != typeof(int))
                throw new InvalidOperationException();
            return (int)((double)value);
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
    public class PathSizingModeConverter : MarkupExtension, IValueConverter
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return object.Equals(value, PathSizingMode.Stretch);
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((bool)value)
                return PathSizingMode.Stretch;
            return PathSizingMode.Proportional;
        }
        #endregion
    }
    public class SizeTransformConverter : MarkupExtension, IValueConverter
    {
        public override object ProvideValue(System.IServiceProvider serviceProvider)
        {
            return this;
        }
        object IValueConverter.Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //if ((string)parameter == "Width")
            return 200d * (double)value;
            //else
            //    return 150d * (double)value;
        }
        object IValueConverter.ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }
    }

    public class ScalablePaddingConverter : IValueConverter
    {
        public ScalablePaddingConverter()
        {
            MinPadding = 35;
        }

        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var controlHeight = (double)value;
            double desiredContentHeight = 3 * Tile.LargeHeight + 2 * TileLayoutControl.DefaultItemSpace + 20;
            double paddingY = Math.Floor(Math.Max(0d, controlHeight - desiredContentHeight) / 2d);
            paddingY = Math.Max(MinPadding, Math.Min(paddingY, TileLayoutControl.DefaultPadding.Top));
            double relativePadding = (paddingY - MinPadding) / (TileLayoutControl.DefaultPadding.Top - MinPadding);
            double paddingX = Math.Floor(MinPadding + relativePadding * (TileLayoutControl.DefaultPadding.Left - MinPadding));
            return new Thickness(paddingX, paddingY, paddingX, paddingY);
        }
        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public double MinPadding { get; set; }
    }

    public static class DataLoader
    {
        public static XDocument LoadXmlFromResources(string fileName)
        {
            try
            {
                //fileName = "/ChartsDemo;component" + fileName;
                Uri uri = new Uri(fileName, UriKind.RelativeOrAbsolute);
                StreamResourceInfo info = Application.GetResourceStream(uri);
                return XDocument.Load(info.Stream);
            }
            catch
            {
                return null;
            }
        }
    }

    public class DemoValuesProvider
    {

        public IEnumerable<Bar2DKind> PredefinedBar2DKinds { get { return Bar2DModel.GetPredefinedKinds(); } }
        public IEnumerable<Marker2DKind> PredefinedMarker2DKinds { get { return Marker2DModel.GetPredefinedKinds(); } }
        public IEnumerable<CandleStick2DKind> PredefinedCandleStick2DKinds { get { return CandleStick2DModel.GetPredefinedKinds(); } }
        public IEnumerable<Stock2DKind> PredefinedStock2DKinds { get { return Stock2DModel.GetPredefinedKinds(); } }
        public IEnumerable<Pie2DKind> PredefinedPie2DKinds { get { return Pie2DModel.GetPredefinedKinds(); } }
        public IEnumerable<RangeBar2DKind> PredefinedRangeBar2DKinds { get { return RangeBar2DModel.GetPredefinedKinds(); } }
        //public IEnumerable<ScrollBarAlignment> ScrollBarAlignments { get { return DevExpress.Data.Mask.EnumHelper.GetValues(typeof(ScrollBarAlignment)).Cast<ScrollBarAlignment>(); } }
       
    }
 public class IsCheckedToVisibilityConverter : IValueConverter
        {
            #region IValueConverter Members
            object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if ((bool)value)
                    return Visibility.Visible;
                return Visibility.Collapsed;
            }
            object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return null;
            }
            #endregion
        }
    public class Bar2DKindToBar2DModelConverter : IValueConverter
    {
        #region IValueConverter Members
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Bar2DKind bar2DKind = value as Bar2DKind;
            if (bar2DKind != null)
                return Activator.CreateInstance(bar2DKind.Type);
            return value;
        }
        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
        #endregion
    }
    public class Bar2DKindToTickmarksLengthConverter : IValueConverter
    {
        #region IValueConverter Members
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Bar2DKind bar2DKind = value as Bar2DKind;
            if (bar2DKind != null)
            {
                switch (bar2DKind.Name)
                {
                    case "Glass Cylinder":
                        return 18;
                    case "Quasi-3D Bar":
                        return 9;
                }
            }
            return 5;
        }
        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
        #endregion
    }
    public class ImageControl : Control
    {
        public ImageControl()
        {
        }
        public static readonly DependencyProperty ImageLayoutTransformProperty;
        
        public static readonly DependencyProperty StretchDirectionProperty;
        public static readonly DependencyProperty StretchProperty;

        public static readonly DependencyProperty SourceProperty = DependencyProperty.Register(
            "Source",
            typeof(object),
            typeof(Image),
            new PropertyMetadata("", onItemsPropertyChanged));

        private static void onItemsPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //row new NotImplementedException();
        }

        //public ImageControl();

        public Transform ImageLayoutTransform { get; set; }
        public object Source { get; set; }
        public Stretch Stretch { get; set; }
        public StretchDirection StretchDirection { get; set; }
    }
}
