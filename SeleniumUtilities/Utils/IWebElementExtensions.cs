using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumUtilities.Utils
{
    public static class IWebElementExtensions
    {
        public static int MaxLengthAttributeValue(this IWebElement element)
        {
            var attribute = element.GetAttribute("maxlength");
            Assert.IsNotNull(attribute, "Flagged for inconsistency on purpose.");
            return int.Parse(attribute);
        }

        public static int MinLengthAttributeValue(this IWebElement element)
        {
            var attribute = element.GetAttribute("minlength");
            Assert.IsNotNull(attribute, "Flagged for inconsistency on purpose.");
            return int.Parse(attribute);
        }

        public static void SendKeysWithDelay(this IWebElement element, string text, int milliseconds)
        {
            if (milliseconds > 0) Thread.Sleep(milliseconds);
            element.SendKeys(text);
            if (milliseconds > 0) Thread.Sleep(milliseconds);
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
            if(milliseconds > 0) Thread.Sleep(milliseconds);
            element.SendKeys(text);
            element.DeleteText(text);
            element.SendKeys(Keys.Tab);
            if (milliseconds > 0) Thread.Sleep(milliseconds);
        }

        public static List<string> ConvertOptionToText(this ReadOnlyCollection<IWebElement> elements)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < elements.Count; i++)
            {
                list.Add(elements[i].Text);
            }
            return list;
        }

        public static List<string> GetSpecificColumnText(this ReadOnlyCollection<IWebElement> rowList, By locator)
        {
            List<string> classTextList = new List<string>();
            for (int i = 0; i < rowList.Count; i++)
            {
                var classText = rowList[i].FindElement(locator);

                classTextList.Add(classText.Text);
            }
            return classTextList;
        }

        public static List<IWebElement> GetSpecificColumnElements(this ReadOnlyCollection<IWebElement> rowList, By locator)
        {
            List<IWebElement> classElementList = new List<IWebElement>();
            for (int i = 0; i < rowList.Count; i++)
            {
                var classElement = rowList[i].FindElement(locator);

                classElementList.Add(classElement);
            }
            return classElementList;
        }

        public static ReadOnlyCollection<IWebElement> GetDataFromTable(this IWebElement table)
        {
            var body = table.FindElement(By.TagName("tbody"));
            //var rowList = body.FindElements(By.TagName("tr"));
            return body.FindElements(By.TagName("tr"));
        }

        public static ReadOnlyCollection<IWebElement> GetDataFromMatTable(this IWebElement table)
        {
            //var body = table.FindElement(By.TagName("mat-table"));
            //var rowList = body.FindElements(By.TagName("mat-row"));
            return table.FindElements(By.TagName("mat-row"));
        }

        public static Boolean EqualsTableAfterSorting(this List<string> sorted, List<string> unsorted)
        {
            for (int i = 0; i < sorted.Count; i++)
            {
                Console.WriteLine("sorted: " + sorted[i]);
                Console.WriteLine("unsorted: " + unsorted[i]);

                if (!sorted[i].Equals(unsorted[i])) return false;
            }
            return true;
        }
    }

}
