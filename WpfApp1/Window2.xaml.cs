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
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public List<Group_f> groups;

        public Window2(List<Group_f> cur_groups)
        {
            InitializeComponent();

            groups = cur_groups;

            for (int i = 0; i < groups.Count(); i++)
            {
                TextBlock new_g = new TextBlock();
                new_g.Text = groups[i].title;
                this.group_list.Items.Add(new_g);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int cur_index = this.group_list.SelectedIndex;

            Window1 w1 = new Window1(this.groups[cur_index]);
            w1.Owner = this;
            w1.Show();
        }
    }
}
