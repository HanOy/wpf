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
            string sql = "select * from (select id,head,describe from [user] where id = '" + ((App)System.Windows.Application.Current).userSession + "') t1,(select count(distinct provinceId) as countProvince from footprint) t2,(select count(distinct provinceId) as countCity from (select distinct cityId,provinceId from footprint) as t4) t3,(select count(distinct viewspotId) as countViewspot from footprint) t4";
            DataTable dt = SQLHelper.ExecuteDt(sql);
            DataContext = dt;
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
                sql = "select provinceId as Id,province,picture from [province]";
                dt = SQLHelper.ExecuteDt(sql);
            }
            else
            {
                sql = "select cityId as Id,city,provinceId,picture,point,province as provinceName from (select * from [city] where provinceId = (select provinceId from [province] where province = '" + buttonName + "')) t1,(select province from province where provinceId=(select provinceId from [province] where province = '" + buttonName + "')) t2";
                dt = SQLHelper.ExecuteDt(sql);
            }
            choose.DataContext = dt;
            choose.lv.Items.Clear();
            choose.Show();
        }

    }
}
