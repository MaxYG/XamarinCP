using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinCP.Service
{
    public class LoginService
    {
        public static bool Login(string username,string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return false;
            }
            return username.Equals("test") && password.Equals("test");
        }
    }
}
