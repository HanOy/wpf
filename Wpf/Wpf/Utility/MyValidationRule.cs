using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Wpf.Utility.MyValidationRule
{
    public class NotNullValidationRule : ValidationRule
    {
            public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
            {
                if (string.IsNullOrEmpty(value as string) || string.IsNullOrWhiteSpace(value as string))
                {
                    return new ValidationResult(false, "不能为空！");
                }
                return new ValidationResult(true, null);
            }
        
    }
    public class PasswordValidationRule : ValidationRule
    {
        private string _password;
        private string _passwordConf;
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public string PasswordConf
        {
            get { return _passwordConf; }
            set { _passwordConf = value; }
        }
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if(value as string != "^[0-9a-zA-Z]{6,16}")
            {
                return new ValidationResult(false, "密码长度6-20，数字或字母");
            }
            return new ValidationResult(true, null);
        }
    }
}
