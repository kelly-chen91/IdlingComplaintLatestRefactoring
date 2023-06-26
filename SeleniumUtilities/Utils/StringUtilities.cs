using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SeleniumUtilities.Utils
{
    public static class StringUtilities
    {
        public static string GenerateRandomString(int length)
        {
            const string acceptedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random(Guid.NewGuid().GetHashCode());
            string str = string.Empty;
            for (int i = 0; i < length; i++)
            {
                str += acceptedChars[random.Next(0, acceptedChars.Length)];
            }
            return str;
        }
        
        /*Generates a random email with a varied length*/
        public static string GenerateRandomEmail()
        {
            var random = new Random();
            int length = random.Next(1, 20);
            return GenerateRandomString(length) + "@dep.nyc.gov";
        }

        /*Generates a random email with a specified length*/
        public static string GenerateRandomEmail(int length)
        {
            if (length <= 12)
                length = 12; //GenerateRandomEmail(1) => a@dep.nyc.gov

            return GenerateRandomString(length - 12) + "@dep.nyc.gov";
        }

        /* The following methods checking for validation of the fields: Email, Phone #, ZipCode, password */
        public static Boolean IsValidEmail(this string email)
        {
            var regexPattern = @"^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";
            var regex = new Regex(regexPattern);
            return regex.IsMatch(email);
        }

        public static String FormatPhoneNumber(this string phone)
        {
            Regex regex = new Regex(@"[^\d]");
            phone = regex.Replace(phone.Trim(), "");
            phone = Regex.Replace(phone, @"(\d{3})(\d{3})(\d{4})", "$1-$2-$3");
            return phone;
        }
        public static Boolean IsValidPhoneNumber(this string phoneNumber)
        {
            Console.WriteLine("original: " + phoneNumber);
            phoneNumber = FormatPhoneNumber(phoneNumber);
            Console.WriteLine("new: " + phoneNumber);
            if (string.IsNullOrEmpty(phoneNumber))
            {
                return false;
            }
            string validPhoneRegex = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";
            return Regex.IsMatch(phoneNumber, validPhoneRegex);
        }

        public static string SelectDate(int month, int day, int year, int hour, int minutes, int seconds, bool isPM)
        {
            if (month <= 0 || month > 12 || day <= 0 || day > 31 || year.ToString().Length != 4 || hour <= 0 || hour > 12 || minutes <= 0 || minutes > 60
                || seconds <= 0 || seconds > 60) { throw new ArgumentException("Invalid Date and Time"); }

            if (IsLeapYear(year) && month == 2 && day > 29) throw new ArgumentException("There are no more than 29 days for February in a leap year.");
            if (!IsLeapYear(year) && month == 2 && day > 28) throw new ArgumentException("There are no more than 28 days for February in a nonleap year.");
            if ((month == 4 || month == 6 || month == 9 || month == 11) && day > 30) throw new ArgumentException("Invalid day for the specified month " + month.ToString());

           
            string morningOrAfternoon = " AM";
            if (isPM) morningOrAfternoon = " PM";
            return month.ToString() + "/" + day.ToString() + "/" + year.ToString() + ", " + hour + ":" + minutes + ":" + seconds + morningOrAfternoon;
        }

        public static Boolean IsLeapYear(int year)
        {
            return ((year % 4 == 0) && (year % 100 != 0)) || (year % 400 == 0);
        }
    }
}
