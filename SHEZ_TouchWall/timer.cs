using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;



namespace SunCreate.CombatPlatform.Client
{
    public partial class MainPage : UserControl
    {
        private System.Timers.Timer timerNotice = null;

        public MainPage()
        {
            //InitializeComponent();
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            #region 通知公告
            if (timerNotice == null)
            {
                BindNotice();

                timerNotice = new System.Timers.Timer();
                timerNotice.Elapsed += new System.Timers.ElapsedEventHandler((o, eea) =>
                {
                    BindNotice();
                });
                timerNotice.Interval = 60 * 1000;
                timerNotice.Start();
            }
            #endregion
        }

        private void MainPage_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }

        #region 绑定通知公告
        private void BindNotice()
        {
            System.Threading.Tasks.Task.Factory.StartNew(() =>
            {
                try
                {
                    //int total = 0;
                    //TES_NOTICE info = new TES_NOTICE();
                    //IList<TES_NOTICE> list = new List<TES_NOTICE>();

                    //list = HI.Get<INoticeService>().GetListPage(null, DateTime.MinValue, DateTime.MinValue, 1, 50, ref total);

                    //Dispatcher.Invoke(new Action(() =>
                    //{
                    //    noticeListView.ItemsSource = list;
                    //}));
                }
                catch
                {

                }
            });
        }
        #endregion

    }
}