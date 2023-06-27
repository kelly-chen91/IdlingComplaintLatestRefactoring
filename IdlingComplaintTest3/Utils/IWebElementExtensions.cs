using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdlingComplaintTest.Utils
{
    public static class IWebElementExtensions
    {
        public static int MaxLengthAttributeValue(this IWebElement element)
        {
            var attribute = element.GetAttribute("maxlength");
            Assert.IsNotNull(attribute, "The element does not have a maxlength attribute.");
            return int.Parse(attribute);
        }

        public static int MinLengthAttributeValue(this IWebElement element)
        {
            var attribute = element.GetAttribute("minlength");
            Assert.IsNotNull(attribute, "The element does not have a minlength attribute.");
            return int.Parse(attribute);
        }

        public static void SendKeysWithDelay(this IWebElement element, string text, int milliseconds)
        {
            Thread.Sleep(milliseconds);
            element.SendKeys(text);
            Thread.Sleep(milliseconds);
        }

        public static void DeleteText(this IWebElement element, string text)
        {
            for(var i = 0; i < text.Length; i++)
            {
                element.SendKeys(Keys.Backspace);
            }
        }

        public static void SendTextDeleteTabWithDelay(this IWebElement element, string text, int milliseconds)
        {
            Thread.Sleep(milliseconds);
            element.SendKeys(text);
            element.DeleteText(text);
            element.SendKeys(Keys.Tab);
            Thread.Sleep(milliseconds);
        }

    }
}
