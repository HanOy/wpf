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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf.Model;
using Wpf.Utility;
using Wpf.View;
using System.Data;

namespace Wpf
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            User user = new User();
            user.Id = ((App)System.Windows.Application.Current).userSession;
            string sql = "select head from [user] where id = '" + user.Id + "'";
            user.Head = SQLHelper.MySqlQuery(sql, "head");
            string sql2 = "select describe from [user] where id = '" + user.Id + "'";
            user.Describe = SQLHelper.MySqlQuery(sql2, "describe");
            if (user.Describe == "")
            {
                user.Describe = "不能太懒，赶紧写一个自我介绍";
            }
            DataContext = user;
        }

        private void X_click(object sender, System.Windows.RoutedEventArgs e)
        {
            Application.Current.Shutdown();
            base.OnClosed(e);
        }

        private void BackGround_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void BackGround_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
                return;
            }
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
            }

        }

        private void Min_click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void SelectPicButton_Click(object sender, RoutedEventArgs e)
        {
            string filetype = "图片文件(*.jpg,*.png)|*.jpg;*.png";
            string imgpath = OpenFileDialog(filetype);
            if (!string.IsNullOrEmpty(imgpath))
            {
                string sql = "update [user] set head = '" + imgpath + "' where id='" + ((App)System.Windows.Application.Current).userSession + "'";
                SQLHelper.ExecuteSql(sql);
                MessageBox.Show("修改头像成功!");
            }
        }
        public string OpenFileDialog(string _filetype)
        {
            Microsoft.Win32.OpenFileDialog op = new Microsoft.Win32.OpenFileDialog();
            //op.InitialDirectory = _dir;你可以指定文件夹
            op.RestoreDirectory = true;
            op.Filter = _filetype;
            op.ShowDialog();
            return op.FileName;
        }

        private void province_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var buttonName = button.Name;
            Choose choose = new Choose();
            string sql = "";
            DataTable dt;
            if (buttonName == "addFoot")
            {
                sql = "select * from [province]";
                dt = SQLHelper.ExecuteDt(sql);
            }
            else
            {
                sql = "select * from [city] where provinceId = (select provinceId from [province] where province = '" + buttonName + "')";
                dt = SQLHelper.ExecuteDt(sql);
            }
            choose.DataContext = dt;
            choose.lv.Items.Clear();
            choose.Show();
        }

    }
}
