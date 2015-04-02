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
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Windows.Media.Animation;

namespace Wpf.View
{
    /// <summary>
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login : Window
    {   
        public Login()
        {
            InitializeComponent();
            this.CommandBindings.Add(new CloseCommandBindingProxy(this));
        }
        private void cancel_click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.IsEnabled = false;
            LoginGrid.OpacityMask = this.Resources["ClosedBrush"] as LinearGradientBrush;
            Storyboard std = this.Resources["ClosedStoryboard"] as Storyboard;
            std.Completed += delegate { this.Close(); };
            std.Begin();
        }
        private void do_register(object sender, System.Windows.RoutedEventArgs e)
        {
            Register register = new Register();
            register.Show();
            return;
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            string path = "/user.xml";
            doc.Load(path);
            XmlElement xe = (XmlElement)doc.SelectSingleNode("user").FirstChild;
            if (remenber.IsChecked != true)
            {
                xe.SetAttribute("id", "");
                doc.Save("/user.xml");
            }
            else
            {
                xe.SetAttribute("id", user.Text);
                doc.Save("/user.xml");
            }
            if (user.Text == "" || password.Password == "")
            {
                MessageBox.Show("用户名密码不能为空");
            }
            else
            {
                    xe.SetAttribute("id", user.Text);
                    string pwd = "";
                    string sql = "select password from [user] where id = '" + user.Text + "'";
                    SqlDataReader dr = SQLHelper.ExecuteReader(sql);
                    if (dr != null)
                    {
                        if (dr.Read())
                        {
                            pwd = dr["password"].ToString().Trim();
                            if (pwd == password.Password)
                            {
                                MainWindow window = new MainWindow();
                                this.Close();
                                window.ShowDialog();
                                return;
                            }
                        }
                    }
                
                MessageBox.Show("用户名或密码错误");
            }
            
        }
    }
}
