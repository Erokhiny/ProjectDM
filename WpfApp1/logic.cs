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
        private string _name;

        public int id { get; set; }

        public string name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public List<Student> students { get; set; }

        public List<Date> dates { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

    public class Student : INotifyPropertyChanged
    {
        private string _firstname;
        private string _secondname;
        private string _patronymic;

        public int id { get; set; }

        public string firstname
        {
            get { return _firstname; }
            set
            {
                _firstname = value;
                OnPropertyChanged("Firstname");
            }
        }

        public string secondname
        {
            get { return _secondname; }
            set
            {
                _secondname = value;
                OnPropertyChanged("Secondname");
            }
        }

        public string patronymic
        {
            get { return _patronymic; }
            set
            {
                _patronymic = value;
                OnPropertyChanged("Patronymic");
            }
        }

        public Group group { get; set; }

        public List<Mark> marks { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

    public class Mark : INotifyPropertyChanged
    {
        private int _number;

        public int id { get; set; }

        public int number
        {
            get { return _number; }
            set
            {
                _number = value;
                OnPropertyChanged("Number");
            }
        }
*/
        public Student student { get; set; }

        public Date date { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

    public class Date : INotifyPropertyChanged
    {
        private int _date;

        public int Id { get; set; }

        public int date
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged("Date");
            }
        }

        public Group group { get; set; }

        public List<Mark> marks { get; set; }

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
        public DbSet<Date> Dates { get; set; }
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
            commandText = "CREATE TABLE IF NOT EXISTS [Dates] ( [Id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, [Date]	INTEGER, [Group_id]    INTEGER, FOREIGN KEY([Group_id]) REFERENCES [Groups]([Id]))";
            Command = new SQLiteCommand(commandText, Connect);
            Connect.Open();
            Command.ExecuteNonQuery();
            Connect.Close();
            commandText = "CREATE TABLE IF NOT EXISTS [Marks] ( [Id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, [Number]	INTEGER, [Student_id]    INTEGER, [Date_id]    INTEGER, FOREIGN KEY([Date_id]) REFERENCES [Dates]([Id]), FOREIGN KEY([Student_id]) REFERENCES [Students]([Id]))";
            Command = new SQLiteCommand(commandText, Connect);
            Connect.Open();
            Command.ExecuteNonQuery();
            Connect.Close();
        }
    }
}
