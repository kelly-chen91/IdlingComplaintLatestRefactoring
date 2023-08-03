using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SeleniumUtilities.Utils.TestUtils
{
    public static class StringUtilities
    {
        public static readonly Random random = new Random();

        public static string GenerateRandomString(int length)
        {
            const string acceptedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            //var random = new Random(Guid.NewGuid().GetHashCode());
            string str = string.Empty;
            for (int i = 0; i < length; i++)
            {
                str += acceptedChars[random.Next(0, acceptedChars.Length)];
            }
            return str;
        }

        //This method will generate random string without giving specific length
        public static string GenerateRandomString()
        {
            const string acceptedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            //var random = new Random(Guid.NewGuid().GetHashCode());
            string str = string.Empty;
            int length = random.Next(1, 20);
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

        //This method will generate random Email address
        public static string GenerateCustomEmail(string firstName, string lastName, string domain)
        {
            string email = $"{firstName.ToLower()}.{lastName.ToLower()}@{domain}";
            return email;
        }

        /*Generates a random email with a specified length*/
        public static string GenerateRandomEmail(int length)
        {
            if (length <= 12)
                length = 12; //GenerateRandomEmail(1) => a@dep.nyc.gov

            return GenerateRandomString(length - 12) + "@dep.nyc.gov";
        }

        //This method will generate legitimate password
        public static string GenerateQualifiedPassword()
        {
            const string uppercaseLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string lowercaseLetters = "abcdefghijklmnopqrstuvwxyz";
            const string numbers = "0123456789";
            const string specialCharacters = "!@#$%^&*()";

            string allCharacters = uppercaseLetters + lowercaseLetters + numbers + specialCharacters;
            var random = new Random();
            int Passwordlength = random.Next(8, 20);
            char[] password = new char[Passwordlength];
            password[0] = uppercaseLetters[random.Next(uppercaseLetters.Length)];
            password[1] = lowercaseLetters[random.Next(lowercaseLetters.Length)];
            password[2] = numbers[random.Next(numbers.Length)];
            password[3] = specialCharacters[random.Next(specialCharacters.Length)];

            for (int i = 4; i < password.Length; i++)
            {
                password[i] = allCharacters[random.Next(allCharacters.Length)];
            }

            password = password.OrderBy(x => random.Next()).ToArray();
            return new string(password);
        }

        //This method will generate a random number within the specified range
        public static int GenerateRandomNumberWithRange(this int minValue, int maxValue)
        {
            Random random = new Random();
            return random.Next(minValue, maxValue + 1);
        }

        //This method will generate a series of random numbers
        public static string GenerateSeriesNumbers()
        {
            int length = random.Next(1, 20);

            string seriesRandomNumbers = "";

            for (int i = 0; i < length; i++)
            {
                int pickedNumber = random.Next(0, 9);
                seriesRandomNumbers += pickedNumber.ToString();
            }

            return seriesRandomNumbers;
        }

        /* The following methods checking for validation of the fields: Email, Phone #, ZipCode, password */
        public static bool IsValidEmail(this string email)
        {
            var regexPattern = @"^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";
            var regex = new Regex(regexPattern);
            return regex.IsMatch(email);
        }

        public static string FormatPhoneNumber(this string phone)
        {
            Regex regex = new Regex(@"[^\d]");
            phone = regex.Replace(phone.Trim(), "");
            phone = Regex.Replace(phone, @"(\d{3})(\d{3})(\d{4})", "$1-$2-$3");
            return phone;
        }
        public static bool IsValidPhoneNumber(this string phoneNumber)
        {
            Console.WriteLine("original: " + phoneNumber);
            phoneNumber = phoneNumber.FormatPhoneNumber();
            Console.WriteLine("new: " + phoneNumber);
            if (string.IsNullOrEmpty(phoneNumber))
            {
                return false;
            }
            string validPhoneRegex = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";
            return Regex.IsMatch(phoneNumber, validPhoneRegex);
        }

        public static string SelectDate(DateTime date)
        {
            return date.ToShortDateString() + ", " + date.ToLongTimeString();

        }

        public static void ValidateErrorDetail(this
            string error, string errorBase, string[] containErrorList, Dictionary<string, string> dictionary)
        {
            //string errorDetail = error.Substring(errorBase.Length);
            string errorDetail = error.Split(":", StringSplitOptions.None)[1];
            string[] errorDetailList = errorDetail.Split(". ", StringSplitOptions.None);
            int isExpectedErrorCount = 0;
            Console.WriteLine("error detail list length: " + errorDetailList.Length);
            for (int i = 0; i < errorDetailList.Length; i++)
            {
                Console.WriteLine(errorDetailList[i]);
                for (int j = 0; j < containErrorList.Length; j++)
                {
                    Console.WriteLine("expected error: " + errorDetailList[i].Contains(containErrorList[j]));

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
