using DevExpress.Xpf.Charts;
using DevExpress.Xpf.LayoutControl;
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

namespace SHEZ_TouchWall.Helper
{
    public class TitleControlHelper
    {
        public Control GenControlByConfiguration(ScrollViewer container)
        {
            TileLayoutControl layout = new TileLayoutControl();
            // 设置背景色
            layout.Background = Brushes.Transparent;
            layout.AllowAddFlowBreaksDuringItemMoving = false;
            layout.AllowItemMoving = false;
            layout.AllowLayerSizing = false;
            

            // Title
            DevExpress.Xpf.LayoutControl.Tile title = new Tile();
            title.Size = TileSize.Large;
            title.Background = Brushes.Transparent;
            title.Header = "";
            //title.ContentSource
            
            
             

            return new Control();
        }
    }

    public class myTitle
    {
        public string GroupHeader { get; set; }
        public string Header { get; set; }
        public int Size { get; set; }
        public string BackGroundColor { get; set; }

        public string[] images { get; set; }
        public string[] notes { get; set; }
        public int duration { get; set; }

    }
}
