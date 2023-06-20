using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdlingComplaintTest.Utils
{
    public static class StringUtilities
    {
        public static string GenerateRandomString(int length)
        {
            const string acceptedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
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
    }
}
