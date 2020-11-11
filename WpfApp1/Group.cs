using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

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

        public Group_f(Group cur_group)
        {
            this.title = cur_group.Name;
            this.students = new List<Student_f>(from i in logic.get_students_by_group(cur_group.Id) select new Student_f(i));
            this.dates = new List<long>();
            foreach (var i in MainWindow.db.Marks.ToList<Mark>())
            {
                bool flag = false;
                foreach (var j in from k in logic.get_students_by_group(cur_group.Id) select k)
                {
                    if (j.Id == i.Student_id)
                    {
                        this.dates.Add(i.Date);
                    }
                }
            }
            this.dates = new List<long>(this.dates.Distinct<long>()); 
            /*
            this.dates = new List<long>(from i in MainWindow.db.Marks.ToList<Mark>() select (long)i.Date);*/
        }
    }
}
