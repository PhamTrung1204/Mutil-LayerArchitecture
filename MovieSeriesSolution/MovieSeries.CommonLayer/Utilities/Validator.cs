using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSeries.CommonLayer.Utilities
{
    public class Validator
    {
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            // Kiểm tra đơn giản: phải có ký tự '@' và '.'
            return email.Contains("@") && email.Contains(".");
        }
    }
}
