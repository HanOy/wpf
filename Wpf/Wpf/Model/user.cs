using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using Wpf.Utility;

namespace Wpf.Model
{
    class User : NotificationObject
    {
        private string _id;
        private string _password;
        private string _describe;
        private string _head;
        
        public string Id
        {
            get {return _id;}
            set { _id = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public string Describe
        {
            get { return _describe; }
            set { _describe = value; }
        }
        public string Head
        {
            get { return _head; }
            set { _head = value; }
        }
    }
}
