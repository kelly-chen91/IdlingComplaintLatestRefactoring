using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumUtilities.Utils
{
    public static class RegistrationUtilities
    {
        //This method will generate random Email address
        public static string GenerateEmail(this string firstName, string lastName, string domain)
        {
            string email = $"{firstName.ToLower()}.{lastName.ToLower()}@{domain}";
            return email;
        }

        //This method will generate random string without giving specific length
        public static string GenerateRandomString()
        {
            const string acceptedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random(Guid.NewGuid().GetHashCode());
            string str = string.Empty;
            int length = random.Next(1, 20);
            for (int i = 0; i < length; i++)
            {
                str += acceptedChars[random.Next(0, acceptedChars.Length)];
            }
            return str;
        }

        //This method will generate a random number within the specified range
        public static int GenerateRandomNumberWithRange(this int minValue, int maxValue)
        {
            Random random = new Random();
            return random.Next(minValue, maxValue + 1);
        }

        //This method will generate a serise random numbers
        public static string GenerateSeriseNumbers()
        {
            Random random = new Random();
            int length = random.Next(1, 20);

            string seriseRandomnumbers="";

            for (int i = 0; i < length; i++)
            {
                int pickedNumber = random.Next(0,9);
                seriseRandomnumbers+=pickedNumber.ToString();
            }

            return seriseRandomnumbers;
        }

        //This method will read the last record from the Text_SuccessfulEmailRegistration.txt
        public static string ReadTheLatestRegistrationRecord(string filePath, int emailOrPassword)
        {
            string lastRow = File.ReadLines(filePath).LastOrDefault();

            if (!string.IsNullOrEmpty(lastRow))
            {
                string[] words = lastRow.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (words.Length >= 2)
                {
                    return words[emailOrPassword];
                }
            }

            return "";
        }
    }
}
