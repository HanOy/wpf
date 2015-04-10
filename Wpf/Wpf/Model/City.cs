using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf.Model
{
    class City
    {
        private int _id;
        private string _city;
        private int _provinceId;
        private string _picture;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string CityName
        {
            get { return _city; }
            set { _city = value; }
        }
        public int ProvinceId
        {
            get { return _provinceId; }
            set { _provinceId = value; }
        }
        public string Picture
        {
            get { return _picture; }
            set { _picture = value; }
        }
    }
}
