using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Data.Entity;
using System.Data.SQLite;
using System.IO;
using System.Drawing;
using System.Diagnostics;
using System.Data;

namespace WpfApp1
{
    public class Group : INotifyPropertyChanged
    {
        private string name;

        public int Id { get; set; }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

    public class Student : INotifyPropertyChanged
    {
        private string firstname;
        private string secondname;
        private string patronymic;
        private int group_id;

        public int Id { get; set; }

        public string Firstname
        {
            get { return firstname; }
            set
            {
                firstname = value;
                OnPropertyChanged("Firstname");
            }
        }

        public string Secondname
        {
            get { return secondname; }
            set
            {
                secondname = value;
                OnPropertyChanged("Secondname");
            }
        }

        public string Patronymic
        {
            get { return patronymic; }
            set
            {
                patronymic = value;
                OnPropertyChanged("Patronymic");
            }
        }

        public int Group_id
        {
            get { return group_id; }
            set
            {
                group_id = value;
                OnPropertyChanged("Group_id");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

    public class Mark : INotifyPropertyChanged
    {
        private int number;
        private int date;
        private DateTime date_in_str = new DateTime();
        private int student_id;
        //private static DateTime zero = new DateTime();

        public int Id { get; set; }

        public int Number
        {
            get { return number; }
            set
            {
                number = value;
                OnPropertyChanged("Number");
            }
        }

        public int Date
        {
            get { return date; }
            set
            {
                date = value;
                //TimeSpan interval = date_in_str - DateTime.MinValue;
                //date = long.Parse(interval.TotalSeconds.ToString());
                //date = Convert.ToInt64(interval.TotalSeconds);
                OnPropertyChanged("Date");
            }
        }

        public int Student_id
        {
            get { return student_id; }
            set
            {
                student_id = value;
                OnPropertyChanged("Student_id");
            }
        }
        
        public void date_reload()
        {
            TimeSpan interval = new TimeSpan(0, 0, (int)date);
            date_in_str = DateTime.MinValue + interval;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("DefaultConnection")
        {
        }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Mark> Marks { get; set; }
    }
    public static class logic
    {
        public static void create_journal()
        {
            SQLiteConnection.CreateFile(@".\journal.db");
            SQLiteConnection Connect = new SQLiteConnection(@"Data Source=.\journal.db");
            string commandText = "CREATE TABLE IF NOT EXISTS [Groups] ( [Id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, [Name] TEXT)";
            SQLiteCommand Command = new SQLiteCommand(commandText, Connect);
            Connect.Open();
            Command.ExecuteNonQuery();
            Connect.Close();
            commandText = "CREATE TABLE IF NOT EXISTS [Students] ( [Id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, [Firstname] TEXT, [Secondname] TEXT, [Patronymic] TEXT, [Group_id] INTEGER,FOREIGN KEY([Group_id]) REFERENCES [Groups]([Id]))";
            Command = new SQLiteCommand(commandText, Connect);
            Connect.Open();
            Command.ExecuteNonQuery();
            Connect.Close();
            commandText = "CREATE TABLE IF NOT EXISTS [Marks] ( [Id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, [Number]	INTEGER, [Date]  INTEGER, [Student_id]    INTEGER, FOREIGN KEY([Student_id]) REFERENCES [Student]([Id]))";
            Command = new SQLiteCommand(commandText, Connect);
            Connect.Open();
            Command.ExecuteNonQuery();
            Connect.Close();
        }
        
        public static List<Student> get_students_by_group(int id)
        {
            List<Student> p = MainWindow.db.Students.ToList<Student>();
            List<Student> SelectedStudents = new List<Student>(from i in p where i.Group_id == id select i);
            return SelectedStudents;
            //сортировочка я устал
        }

        public static List<Mark> get_marks_by_student(int id)
        {
            List<Mark> p = MainWindow.db.Marks.ToList<Mark>();
            List<Mark> SelectedMarks = new List<Mark>(from i in p where i.Student_id == id select i);
            return SelectedMarks;
            //сортировочка я устал
        }
    }
}
