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
using Wpf.Utility;
using System.Windows.Media.Animation;
using System.Data;

namespace Wpf.View
{
    /// <summary>
    /// Choose.xaml 的交互逻辑
    /// </summary>
    public partial class Choose : Window
    {
        public Choose()
        {
            InitializeComponent();
            this.CommandBindings.Add(new CloseCommandBindingProxy(this));
        }

        private void X_click(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            ChooseGrid.OpacityMask = this.Resources["ClosedBrush"] as LinearGradientBrush;
            Storyboard std = this.Resources["ClosedStoryboard"] as Storyboard;
            std.Completed += delegate { this.Close(); };
            std.Begin();
        }

        private void picture_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            string ID = button.Content.ToString();
            if (provName.Text == "" || provName.Text == null)
            {
                string sql = "select cityId as Id,city,provinceId,picture,point,province as provinceName from (select * from [city] where provinceId = '" + ID + "') t1, (select province from province where provinceId='" + ID + "') t2";
                DataTable dt = SQLHelper.ExecuteDt(sql);
                DataContext = dt;
            }
            else
            {
                string sql = "insert into footprint values ('" + ID + "','" + provId.Text + "','','" + ((App)System.Windows.Application.Current).userSession + "')";
                if (SQLHelper.ExecuteSql(sql) == 0)
                    MessageBox.Show("增加失败");
                MessageBox.Show("增加成功");
            }
        }

        private void return_Click(object sender, RoutedEventArgs e)
        {
            string sql = "select provinceId as Id,province,picture from [province]";
            DataTable dt = SQLHelper.ExecuteDt(sql);
            DataContext = dt;
        }
    }
}
