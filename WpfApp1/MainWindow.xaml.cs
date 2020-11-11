﻿using System;
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
            logic.create_journal();
            db = new ApplicationContext();
            db.Groups.Load();/*
            this.DataContext = db.Groups.Local.ToBindingList();*/
            db.Students.Load();/*
            this.DataContext = db.Students.Local.ToBindingList();*/
            db.Marks.Load();/*
            this.DataContext = db.Marks.Local.ToBindingList();*/
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Student_f s1 = new Student_f("Иван", "Иванов", "Иванович", new Dictionary<long, int>() { { 10000000000000, 3 }, { 20000000000000, 5 } });
            Student_f s2 = new Student_f("А", "Б", "В", new Dictionary<long, int>() { { 20000000000000, 4 } });

            Student_f s3 = new Student_f("Васян", "Васенов", "Васенович", new Dictionary<long, int>() { { 50000000000000, 4 }, { 60000000000000, 3 } });
            Student_f s4 = new Student_f("Г", "Д", "Е", new Dictionary<long, int>() { { 60000000000000, 3 } });

            Group_f g1 = new Group_f("ИНБО-00-20", new List<long>() { 10000000000000, 20000000000000, 30000000000000 }, new List<Student_f>() { s1, s2 });
            Group_f g2 = new Group_f("ИНБО-000-20", new List<long>() { 30000000000000, 40000000000000, 50000000000000, 60000000000000 }, new List<Student_f>() { s3, s4 });

            Window2 w2 = new Window2(new List<Group_f> { g1, g2 });
            w2.Owner = this;
            w2.Show();
        }
    }
}
