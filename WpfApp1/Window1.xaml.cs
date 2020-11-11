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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1(Group_f cur_group)
        {
            InitializeComponent();

            string cur_group_title = cur_group.title;
            List<long> cur_group_dates = cur_group.dates;
            List<Student_f> cur_group_students = cur_group.students;

            this.group_title.Text = cur_group_title;

            ListBox main_list_box = new ListBox();

            StackPanel header_stack_panel = new StackPanel();
            header_stack_panel.Orientation = Orientation.Horizontal;

            TextBlock fio = new TextBlock();
            fio.Text = "ФИО";
            //fio.Margin = new Thickness(10, 5, 10, 5);
            fio.Width = 200;
            header_stack_panel.Children.Add(fio);

            for (int i = 0; i < cur_group_dates.Count(); i++) 
            {
                TextBlock current_date = new TextBlock();
                DateTime current_date_normal = new DateTime(cur_group_dates[i]);
                current_date.Text = current_date_normal.ToShortDateString();
                //current_date.Margin = new Thickness(10, 5, 10, 5);
                current_date.Width = 70;
                current_date.TextAlignment = TextAlignment.Center;

                header_stack_panel.Children.Add(current_date);
            }

            main_list_box.Items.Add(header_stack_panel);

            for (int j = 0; j < cur_group_students.Count(); j++) 
            {
                StackPanel cur_stack_panel = new StackPanel();
                cur_stack_panel.Orientation = Orientation.Horizontal;

                TextBlock cur_fio = new TextBlock();
                cur_fio.Text = cur_group_students[j].firstName + " " + cur_group_students[j].secondName + " " + cur_group_students[j].lastName;
                //fio.Margin = new Thickness(10, 5, 10, 5);
                cur_fio.Width = 200;
                cur_stack_panel.Children.Add(cur_fio);

                for (int i = 0; i < cur_group_dates.Count(); i++)
                {
                    if (cur_group_students[j].marks.ContainsKey(cur_group_dates[i]))
                    {
                        TextBlock current_mark = new TextBlock();
                        current_mark.Text = cur_group_students[j].marks[cur_group_dates[i]].ToString();
                        //current_date.Margin = new Thickness(10, 5, 10, 5);
                        current_mark.Width = 70;
                        current_mark.TextAlignment = TextAlignment.Center;

                        cur_stack_panel.Children.Add(current_mark);
                    }
                    else 
                    {
                        TextBlock current_mark_span = new TextBlock();
                        current_mark_span.Text = "н";
                        //current_date.Margin = new Thickness(10, 5, 10, 5);
                        current_mark_span.Width = 70;
                        current_mark_span.TextAlignment = TextAlignment.Center;

                        cur_stack_panel.Children.Add(current_mark_span);
                    }
                }

                main_list_box.Items.Add(cur_stack_panel);
            }

            this.main_container.Children.Add(main_list_box);
        }
    }
}
