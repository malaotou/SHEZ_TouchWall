﻿using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using DevExpress.Xpf.Core;
using System.Diagnostics;
using Newtonsoft;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Runtime.Serialization.Json;
using SHEZ_TouchWall.configuration.modules;
using System.Text;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Threading;

namespace SHEZ_TouchWall
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private System.Timers.Timer timerNotice = null;
        private Stopwatch watcher = new Stopwatch();
        bool isTouched = false;
        public MainWindow()
        {
            InitializeComponent();
            InitCurrentWindow();
            //System.Windows.Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new Action(InitCurrentWindow));
            //Image image3 = new Image();
            //image3.Source = new BitmapImage(new Uri(@"d:\bg.jpg"));
            //image3.IsManipulationEnabled = true;
            ////image3.IsManipulationEnabled 
            //image3.Width = 200;
            //image3.Height = 200;
            //container.Children.Add(image3);

            //demo.Children.Add(image);
        }
        private void initControl()
        {
            //main_canvas.SetValue(Canvas.ZIndexProperty, -100);
            //main_canvas.SetZIndex(-100);
            //h_Main.SetZIndex(100);
        }

        private void h_Main_PreviewMouseMove(object sender, MouseEventArgs e)
        {

        }

        private void h_Main_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            //ScrollViewer scrollViewer = sender as ScrollViewer;

            //if (e.Delta > 0)
            //{
            //    scrollViewer.LineLeft();
            //}
            //else
            //    scrollViewer.LineRight();
            //e.Handled = true;
        }

        private void h_Main_ManipulationBoundaryFeedback(object sender, ManipulationBoundaryFeedbackEventArgs e)
        {
            e.Handled = true;
        }

        private void Window_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {

        }



        private void Window_ManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        {
            var element = e.OriginalSource as UIElement;

            var transformation = element.RenderTransform
                                                 as MatrixTransform;
            var matrix = transformation == null ? Matrix.Identity :
                                           transformation.Matrix;

            matrix.ScaleAt(e.DeltaManipulation.Scale.X,
                           e.DeltaManipulation.Scale.Y,
                           e.ManipulationOrigin.X,
                           e.ManipulationOrigin.Y);

            matrix.RotateAt(e.DeltaManipulation.Rotation,
                            e.ManipulationOrigin.X,
                            e.ManipulationOrigin.Y);

            matrix.Translate(e.DeltaManipulation.Translation.X,
                             e.DeltaManipulation.Translation.Y);

            element.RenderTransform = new MatrixTransform(matrix);
            e.Handled = true;
        }

        private void Canvas_ManipulationStarting(object sender, ManipulationStartingEventArgs e)
        {
            e.ManipulationContainer = container;
            e.Handled = true;
        }

        private void UCBook_TouchDown(object sender, TouchEventArgs e)
        {
            //UCBook book = new SHEZ_TouchWall.UCBook();
            //e.Handled = true;

        }

        private void RootWindow_TouchDown(object sender, TouchEventArgs e)
        {
            e.Handled = true;
            //Image image3 = new Image();
            //image3.Source = new BitmapImage(new Uri(@"d:\bg.jpg"));
            //image3.IsManipulationEnabled = true;
            //image3.Width = 200;
            //image3.Height = 200;
            //container.Children.Add(image3);
            ////if(e.OriginalSource==Image)
            if (e.OriginalSource.GetType() == typeof(Image))
            {
                var image = (Image)e.OriginalSource;
                var image2 = new Image();
                image2.Source = image2.Source;
                image2.SetLeft(image.GetPosition(container).X);
                image2.SetTop(image.GetPosition(container).Y);
                image2.Width = image.Width + 100;
                image2.Height = image.Height + 100;
                image2.SetZIndex(100);
                image2.IsManipulationEnabled = true;
                container.Children.Add(image2);


                //}
            }
        }

        private void RootWindow_TouchDown_1(object sender, TouchEventArgs e)
        {
            isTouched = true;
            watcher.Restart();
        }

        private void RootWindow_TouchLeave(object sender, TouchEventArgs e)
        {
            isTouched = true;
            watcher.Restart();
        }

        private void RootWindow_Loaded(object sender, RoutedEventArgs e)
        {
            timerNotice = new System.Timers.Timer();
            watcher.Start();
            timerNotice.Elapsed += new System.Timers.ElapsedEventHandler((o, eea) =>
            {
                watchConfig();
                // 如果时长超过10 秒
                if (watcher.Elapsed > new TimeSpan(0, 10, 0))
                {
                    InitCurrentWindow();
                    watcher.Restart();
                }
                else
                {
                    isTouched = false;
                }
            });
            timerNotice.Interval = 1000;
            timerNotice.Start();

        }

        //private void BindReinit()
        //{
        //    this.RootWindow.Dispatcher.Invoke(new Action(() =>
        //    {
        //        Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
        //        //1. open a new instance of the main window:
        //        MainWindow newWin = new MainWindow();
        //        newWin.Show();
        //        //2. close the current one

        //        //Application.Current.Shutdown();
        //        this.Close();
        //    }));
        //}
        private void InitCurrentWindow()
        {
            try
            {
                this.Dispatcher.Invoke(new Action(() =>
                {
                    //hStackPanel.Children.Clear();
                    #region not use

                    ////将对象转化成Json字符串
                    //string output = string.Empty;
                    //canvas can = new configuration.modules.canvas();
                    //List<MyControl> controllist = new List<MyControl>();
                    //can.Width = 100;
                    //can.Height = 100;
                    //can.Name = "demo";
                    //MyControl control = new configuration.modules.MyControl();
                    //control.Id = 1;
                    //control.Title = "fdsafsa";
                    //control.Enable = false;
                    //controllist.Add(control);
                    //can.Controls = controllist;
                    //DataContractJsonSerializer ds = new DataContractJsonSerializer(typeof(canvas));
                    //using (MemoryStream ms = new MemoryStream())
                    //{
                    //    ds.WriteObject(ms, can);
                    //    output = Encoding.UTF8.GetString(ms.ToArray());
                    //}
                    #endregion
                    string data = string.Empty;
                    DataContractJsonSerializer outDs = new DataContractJsonSerializer(typeof(canvas));
                    var fileUrl = @"C:\Users\ThinkPad\Desktop\SHEZ_TouchWall\SHEZ_TouchWall\configuration\mainWin.json";
                    FileStream fs = new FileStream(fileUrl, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    StreamReader sr = new StreamReader(fs, System.Text.Encoding.Default);
                    StringBuilder sb = new StringBuilder();
                    while (!sr.EndOfStream)
                    {
                        sb.AppendLine(sr.ReadLine());
                    }

                    //var text = File.ReadAllText(@"C:\Users\ThinkPad\Desktop\SHEZ_TouchWall\SHEZ_TouchWall\configuration\mainWin.json");

                    using (MemoryStream outMs = new MemoryStream(Encoding.UTF8.GetBytes(sb.ToString())))
                    {
                        canvas outcanvas = outDs.ReadObject(outMs) as canvas;
                        AddContentControl(outcanvas, hStackPanel);
                        //foreach (var item in outcanvas.Controls)
                        //{
                        //    if (item.Enable)
                        //    {
                        //        #region addControl
                        //        StackPanel stackpanel = new StackPanel();
                        //        stackpanel.Orientation = Orientation.Vertical;
                        //        stackpanel.Width = outcanvas.Width;


                        //        // 初始化一些属性

                        //        // 孩子
                        //        Label title = new Label();
                        //        title.Content = item.Title;
                        //        title.FontSize = 40;
                        //        //title.FontFamily = null;
                        //        stackpanel.Children.Add(title);

                        //        var content = AddContentControl(item);
                        //        stackpanel.Children.Add(content);



                        //    }
                        //    #endregion
                        //}

                    }
                }));
            }
            catch (Exception ex)
            {

            }
        }
        private Control AddTitleControl(MyControl item)
        {
            Control control = new Control();
            switch (item.Id)
            {
                case 1:
                    control = new UC1();
                    break;
                case 2:
                    control = new UCBook();
                    break;
                case 3:
                    control = new UCChart2();
                    break;
                case 4:
                    control = new UCFlicker();
                    break;
                case 5:
                    control = new UCPhotoGallery2();
                    break;
                case 6:
                    break;
                case 7:
                    break;

            }
            if (item != null && item.Margin != null)
            {
                var marginItems = item.Margin.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                if (marginItems.Length == 4)
                    control.Margin = new Thickness(
                                                double.Parse(marginItems[0]),
                                                double.Parse(marginItems[1]),
                                                double.Parse(marginItems[2]),
                                                double.Parse(marginItems[3]));
            }
            if (item != null && item.Padding != null)
            {
                var paddingItems = item.Padding.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                if (paddingItems.Length == 4)
                    control.Margin = new Thickness(
                                                double.Parse(paddingItems[0]),
                                                double.Parse(paddingItems[1]),
                                                double.Parse(paddingItems[2]),
                                                double.Parse(paddingItems[3]));
            }

            control.Height = item.Height;
            control.Width = item.Width;
            return control;

        }
        private void AddContentControl(canvas outcanvas, StackPanel container)
        {
            // 处理外层StackPanel


            foreach (var item in outcanvas.Controls)
            {
                StackPanel stackpanel = new StackPanel();
                if (item.Enable)
                {

                    stackpanel.Orientation = Orientation.Vertical;
                    stackpanel.Width = outcanvas.Width;
                    #region//Process Titel
                    Label title = new Label();
                    title.Content = item.Title;
                    title.FontSize = 40;
                    if (outcanvas.TitleMargin != null)
                    {
                        title.Margin = processThickness(outcanvas.TitleMargin);
                    }
                    if (outcanvas.TitlePadding != null)
                    {
                        title.Padding = processThickness(outcanvas.TitlePadding);
                    }
                    stackpanel.Children.Add(title);
                    #endregion

                    #region ProcessContent
                    Control control = new Control();
                    switch (item.Id)
                    {
                        case 1:
                            control = new UC1();
                            break;
                        case 2:
                            control = new UCBook();
                            break;
                        case 3:
                            control = new UCChart2();
                            break;
                        case 4:
                            control = new UCFlicker();
                            break;
                        case 5:
                            control = new UCPhotoGallery2();
                            break;
                        case 6:
                            break;
                        case 7:
                            break;

                    }
                    control.Margin = processThickness(item.Margin);
                    control.Padding = processThickness(item.Padding);
                    control.Height = item.Height;
                    control.Width = item.Width;
                    #endregion
                    stackpanel.Children.Add(control);
                }
                container.Children.Add(stackpanel);
            }


        }

        private Thickness processThickness(string arry)
        {
            if (arry != null)
            {
                var paddingItems = arry.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                if (paddingItems.Length == 4)
                    return new Thickness(
                                                double.Parse(paddingItems[0]),
                                                double.Parse(paddingItems[1]),
                                                double.Parse(paddingItems[2]),
                                                double.Parse(paddingItems[3]));
                else return new Thickness(0.0, 0.0, 0.0, 0.0);
            }

            else return new Thickness(0.0, 0.0, 0.0, 0.0);
        }


        private void watchConfig()
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = @"C:\Users\ThinkPad\Desktop\SHEZ_TouchWall\SHEZ_TouchWall\configuration";
            watcher.Filter = "mainWin.json";

            watcher.Changed += new FileSystemEventHandler(OnProcess);

            watcher.EnableRaisingEvents = true;
        }

        private void OnProcess(object sender, FileSystemEventArgs e)
        {
            InitCurrentWindow();
        }
    }
}

