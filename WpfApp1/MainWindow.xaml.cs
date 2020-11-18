using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
using System.Data.Entity;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ApplicationContext db;
        public MainWindow()
        {
            InitializeComponent();
            //logic.create_journal();
            db = new ApplicationContext();
            db.Groups.Load();
            db.Students.Load();
            db.Dates.Load();
            db.Marks.Load();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var i in db.Groups)
            {
                Console.WriteLine(i.ToString());
            }
            Window2 w2 = new Window2(new List<Group_f>(from i in MainWindow.db.Groups.ToList<Group>() select new Group_f(i)));
            w2.Owner = this;
            w2.Show();
        }
    }
}
