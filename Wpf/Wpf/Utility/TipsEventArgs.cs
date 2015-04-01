using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf.Utility
{
    public class TipsEventArgs : EventArgs
    {
        public string Tips { get; private set; }

        public TipsEventArgs(string tips)
        {
            this.Tips = tips;
        }
    }
}
