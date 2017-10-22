using DevExpress.Xpf.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace SHEZ_TouchWall
{
    /// <summary>
    /// Interaction logic for UCBook.xaml
    /// </summary>
    public partial class UCBook : UserControl
    {
        private Timer _updatetimer = new Timer(new TimerCallback(UpdateTimer), null, 1000, 1000);
        static ObservableCollection<Employee> employees = new ObservableCollection<Employee>();

        private static void UpdateTimer(object state)
        {
            EventHandler onTick = OnTick;
            if (onTick != null)
                onTick(null, EventArgs.Empty);
        }

        private static void OnTick(object sender, EventArgs e)
        {
            
           
        }

        public UCBook()
        {
            InitializeComponent();
            //Image image3 = new Image();
            //image3.Source = new BitmapImage(new Uri(@"d:\bg.jpg"));
            //image3.Width = 100;
            //image3.Height = 100;
            //image3.SetValue(Panel.ZIndexProperty, 1);
            //image3.IsManipulationEnabled = true;
            //((SHEZ_TouchWall.MainWindow)Application.Current.MainWindow).container.Children.Add(image3);

            employees.Add(new Employee
            {
                Photo = "./images/left.jpg",

                PageContent = "上海市第二中学是上海市实验性示范性高中",
                PageHeader = "上海市第二中学简介",
                Notes = @"上海市第二中学是上海市实验性示范性高中。她的前身是务本女塾，创办于1902年，是中国最早的由国人创办的女子学校之一。 学校办学112年，经过历任校长的不懈努力，数以百计的教职员工辛勤耕耘，在继承优良传统的基础上形成了勤奋、刻苦、主动、创造的学风和严谨、活泼、求实、进取的校风，把促进学生德、智、体、美、劳五育和谐发展，兴趣、爱好、个性、特长得到培养作为学校的办学目标。",
                EmployeeID = 1
            });
            employees.Add(new Employee
            {
                Photo = "",
                Notes = "managed to get matrixtransform working by setting rendersource and using beginanimationsomething like this",
                EmployeeID = 1,
                PageContent = "",
                PageHeader = "学校沿革"
            });
            employees.Add(new Employee
            {
                Photo = "",
                Notes = "managed to get matrixtransform working by setting rendersource and using beginanimationsomething like this",
                EmployeeID = 1
            });
            employees.Add(new Employee
            {
                Photo = "",
                Notes = "managed to get matrixtransform working by setting rendersource and using beginanimationsomething like this",
                EmployeeID = 1
            });
            book.DataSource = employees;
            book.FirstPage = PageType.Odd;

        }
    }
}
