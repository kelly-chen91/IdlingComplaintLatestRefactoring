using OpenQA.Selenium.DevTools.V112.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdlingComplaintTest.Tests.Login
{
    internal class Constants
    {
        public static readonly string LOGIN_HEADING = "NYC Idling Complaints";
        public static readonly string LOGIN = "Login";
        public static readonly string FORGOT_PASS = "Forgot Password";
        public static readonly string NOT_REGISTERED = "Not registered?";
        public static readonly string CREATE_ACCOUNT = "Create an account";


        public static readonly string EMAIL = "Email";
        public static readonly string PASSWORD = "Password";

        public static readonly int MAX_NAME_LENGTH = 50;
        public static readonly int MAX_PASSWORD_LENGTH = 50;
        public static readonly int MAX_EMAIL_LENGTH = 62;
        
        public static readonly string REQUIRED = "Required";
    }
}
