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

        private void city_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            string ID = button.Content.ToString();
            string sql = "select * from [city] where provinceId = '"+ID+"'";
            DataTable dt = SQLHelper.ExecuteDt(sql);
            DataContext = dt;
        }
    }
}
