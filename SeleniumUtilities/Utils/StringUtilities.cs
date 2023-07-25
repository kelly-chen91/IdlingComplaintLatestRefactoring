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

        public static string SelectDate(int month, int day, int year, int hour, int minutes, int seconds)
        {
            DateTime date = new DateTime(year, month, day, hour, minutes, seconds);
            return date.ToShortDateString() + ", " + date.ToLongTimeString();

        }

        public static void ValidateErrorDetail(this 
            string error, string errorBase, string[] containErrorList, Dictionary<string, string> dictionary)
        {
            //string errorDetail = error.Substring(errorBase.Length);
            string errorDetail = error.Split(":", StringSplitOptions.None)[1];
            string[] errorDetailList = errorDetail.Split(". ", StringSplitOptions.None);
            int isExpectedErrorCount = 0;
            Console.WriteLine("error detail list length: " +  errorDetailList.Length);
            for (int i = 0; i < errorDetailList.Length; i++)
            {
                Console.WriteLine(errorDetailList[i]);
                for (int j = 0; j < containErrorList.Length; j++)
                {
                    Console.WriteLine("expected error: "+errorDetailList[i].Contains(containErrorList[j]));

                    if (errorDetailList[i].Contains(containErrorList[j]))
                    {
                        if (dictionary.ContainsKey(containErrorList[j]))
                        {
                            string compare = dictionary[containErrorList[j]]; //gets the expected text
                            if (errorDetailList[i].Contains("."))
                                Assert.That(errorDetailList[i], Is.EqualTo(compare + "."),
                               "Expecting [" + compare + "." + "], but found [" + errorDetailList[i] + "]");
                            else Assert.That(errorDetailList[i], Is.EqualTo(compare),
                                "Expecting [" + compare + "], but found [" + errorDetailList[i] + "]");
                        }
                        isExpectedErrorCount++;
                    }
                }
            }
            Assert.That(errorDetailList.Length, Is.EqualTo(isExpectedErrorCount), "The text does not contain the expected errors.");

            if (!error.Contains(errorBase))
                Assert.That(error.Substring(0, errorBase.Length), Is.EqualTo(errorBase),
                    "Expecting [" + errorBase + "], but found [" + error.Substring(0, errorBase.Length) + "]");
        }

        public static string GetProjectRootDirectory()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            return currentDirectory.Split("bin")[0];
        }
    }
}
