using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Group
    {
        public string title;
        public List<long> dates;
        public List<Student> students;

        public Group(string new_title, List<long> new_dates, List<Student> new_students) 
        {
            this.title = new_title;
            this.dates = new_dates;
            this.students = new_students;
        }
    }
}
