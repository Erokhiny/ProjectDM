using System;
using System.Collections.Generic;
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
            logic.create_journal();
            db = new ApplicationContext();
            db.Groups.Load();/*
            this.DataContext = db.Groups.Local.ToBindingList();*/
            db.Students.Load();/*
            this.DataContext = db.Students.Local.ToBindingList();*/
            db.Marks.Load();/*
            this.DataContext = db.Marks.Local.ToBindingList();*/
        }
    }
}
