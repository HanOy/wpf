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
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            return new ValidationResult(true, null);
        }
    }
}
