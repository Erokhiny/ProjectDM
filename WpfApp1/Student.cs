using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Student
    {
        // ФИО
        public string firstName;
        public string secondName;
        public string lastName;

        // массив оценок
        public Dictionary<long, int> marks;

        public Student(string fn, string sn, string ln, Dictionary<long, int> new_marks) 
        {
            this.firstName = fn;
            this.secondName = sn;
            this.lastName = ln;
            this.marks = new_marks;
        }
    }
}
