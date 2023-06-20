using OpenQA.Selenium.DevTools.V112.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdlingComplaintTest.Tests.Register
{
    internal class Constants
    {
        public static readonly string PROFILE_HEADING = "Profile";
        public static readonly string FIRST_NAME = "First Name";
        public static readonly string LAST_NAME = "Last Name";
        public static readonly string EMAIL = "Email";
        public static readonly string PASSWORD = "Password";
        public static readonly string CONFIRM_PASSWORD = "Confirm Password";
        public static readonly string SEC_QUESTION = "Security Question";
        public static readonly string DEFAULT_SEC_QUESTION = "--";
        public static readonly string SECURITY_ANSWER = "Security Answer";
        public static readonly string ADDRESS_1 = "Address1";
        public static readonly string ADDRESS_2 = "Address2";
        public static readonly string CITY = "City";
         public static readonly string STATE = "State";
       
         public static readonly string DEFAULT_STATE = "--";
        public static readonly string ZIPCODE = "Zip Code";
        public static readonly string TELEPHONE = "Telephone";
        public static readonly int MAX_NAME_LENGTH = 50;
        public static readonly int MAX_PASSWORD_LENGTH = 50;
        public static readonly int MAX_SECURITY_ANSWER_LENGTH = 50;
        public static readonly int MAX_EMAIL_LENGTH = 62;
        public static readonly int MAX_ADDRESS_LENGTH = 95;
        public static readonly int MAX_CITY_LENGTH = 35;
        public static readonly int MAX_PHONE_NUMBER_LENGTH = 13;
        public static readonly int MAX_ZIPCODE_LENGTH = 10;
        public static readonly string LOGIN_HEADING = "NYC Idling Complaints";
        public static readonly string LOGIN = "Login";
        public static readonly string FORGOT_PASS = "Forgot Password";
        public static readonly string NOT_REGISTERED = "Not registered?";
        public static readonly string CREATE_ACCOUNT = "Create an account";
        public static readonly string PASSWORD_POLICY_1 = "Password policy: password must be at least 8 characters, with at least one upper case letter, lower case letter, number, and special character.";
        //  public static readonly string PASSWORD_POLICY_2 = "Password is invalid. See password policy above.";
        public static readonly string PASSWORD_POLICY_2 = "Remember Security Answer for future password retrieval.";
        public static readonly string REQUIRED = "Required";
        public static readonly string STATE_REQUIRED = "State is required";
        //public static readonly string PASSWORD_REQUIRED = "Password is invalid. Please see the password policy above and try again.";
        public static readonly string PASSWORD_REQUIRED = "Password is invalid. See password policy above.";
        //  public static readonly string CONFIRM_PASSWORD_REQUIRED = "Password does not match. Please try again.";
        public static readonly string CONFIRM_PASSWORD_REQUIRED = "Password does not match.";
    }
}
