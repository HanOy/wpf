using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf.Model
{
    class Province
    {
        private int _id;
        private string _province;
        private string _picture;
        
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string ProvinceName
        {
            get { return _province; }
            set { _province = value; }
        }
        public string Picture
        {
            get { return _picture; }
            set { _picture = value; }
        }
    }
}
