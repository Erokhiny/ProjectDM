using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Group_f
    {
        public string title;
        public List<long> dates;
        public List<Student_f> students;

        public Group_f(string new_title, List<long> new_dates, List<Student_f> new_students)
        {
            this.title = new_title;
            this.dates = new_dates;
            this.students = new_students;
        }
    }
}
