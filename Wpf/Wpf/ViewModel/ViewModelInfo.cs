using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf.ViewModel
{
    public class ViewModelInfo
    {
        public string Name { get; set; }
        public Lazy<ViewModelBase> ViewModel { get; set; }
    }
}
