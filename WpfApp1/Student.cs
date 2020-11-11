using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Student_f
    {
        // ФИО
        public string firstName;
        public string secondName;
        public string lastName;

        // массив оценок
        public Dictionary<long, int> marks;

        public Student_f(string fn, string sn, string ln, Dictionary<long, int> new_marks) 
        {
            this.firstName = fn;
            this.secondName = sn;
            this.lastName = ln;
            this.marks = new_marks;
        }

        public Student_f(Student cur_student)
        {
            this.firstName = cur_student.Firstname;
            this.secondName = cur_student.Secondname;
            this.lastName = cur_student.Patronymic;

            this.marks = new Dictionary<long, int>();
            foreach (var i in MainWindow.db.Marks)
            {
                if (i.Student_id == cur_student.Id)
                {
                    this.marks.Add((long)i.Date, i.Number);
                }
            }
        }
    }
}
