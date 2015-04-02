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
using Wpf.Model;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Wpf.View
{
    /// <summary>
    /// Register.xaml 的交互逻辑
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
            this.CommandBindings.Add(new CloseCommandBindingProxy(this));
            User user = new User();
            DataContext = user;
        }

        private void register_Click(object sender, RoutedEventArgs e)
        {
            string sql="select id from [user] where id = '"+id.Text+"' ";
            if (SQLHelper.MySqlQuery(sql,"id") != "")
            {
                MessageBox.Show("用户名"+id.Text+"已被使用!");
                return;
            }
            else if (!Regex.IsMatch(id.Text, "^[A-Za-z0-9\u4e00-\u9fa5]{2,10}$"))
            {
                MessageBox.Show("用户名: "+id.Text+" 不合法,长度2-10，数字或字母或汉字!");
                return;
            }
            else if(password.Password!=passwordConf.Password)
            {
                MessageBox.Show("两次密码不一样!");
                return;
            }
            else if (!Regex.IsMatch(password.Password , "^[0-9a-zA-Z]{6,16}"))
            {
                MessageBox.Show("密码长度6-16，数字或字母!");
                return;
            }
            else
            {
                User user = new User();
                user.Id = id.Text;
                user.Password = password.Password;
                user.Describe = GetText(word);
                sql = "insert into [user] values('" + user.Id + "','" + user.Password + "','" + user.Describe + "','/Resourse/head.jpg')";
                if(SQLHelper.ExecuteSql(sql)==1)
                {
                    MessageBox.Show("注册成功!");
                    cancel_Click(sender,e);
                    return;
                }
            }
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            RegisterGrid.OpacityMask = this.Resources["ClosedBrush"] as LinearGradientBrush;
            Storyboard std = this.Resources["ClosedStoryboard"] as Storyboard;
            std.Completed += delegate { this.Close(); };
            std.Begin();
        }

        private string GetText(RichTextBox richTextBox)
        {
            TextRange textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
            return textRange.Text;
        }
    }
}
