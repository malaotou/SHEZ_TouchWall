using System;
using System.Collections.Generic;
using System.Windows;
using DevExpress.Xpf.LayoutControl;
using DevExpress.Xpf.Core;
using System.Windows.Input;

namespace DXControl
{
    public class ImageContainer : ContentControlBase
    {
        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonUp(e);
            if (Controller.IsMouseLeftButtonDown)
            {
                var layoutControl = Parent as FlowLayoutControl;
                if (layoutControl != null)
                {
                    Controller.IsMouseEntered = false;
                    layoutControl.MaximizedElement = layoutControl.MaximizedElement == this ? null : this;
                }
            }
        }
        protected override void OnSizeChanged(SizeChangedEventArgs e)
        {
            base.OnSizeChanged(e);
            if (!double.IsNaN(Width) && !double.IsNaN(Height))
                if (e.NewSize.Width != e.PreviousSize.Width)
                    Height = double.NaN;
                else
                    Width = double.NaN;
        }
    }
}
