﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Ribbon;
using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Layout.Core;
using DevExpress.Xpf.Docking;
using DevExpress.Xpf.NavBar;
using DevExpress.Xpf.Charts;
using DevExpress.XtraRichEdit;
using DevExpress.Xpf.RichEdit;
using DevExpress.Xpf.Gauges;


namespace SHEZ_Management
{
    public partial class MainWindow : DXRibbonWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            ribbonControl1.SelectedPage = pageHome;
        }


    }


}
