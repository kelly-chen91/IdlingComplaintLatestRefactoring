using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdlingComplaintTest.Utils
{
    public static class IWebDriverExternsions
    {
        public static void ScrollTo(this IWebDriver driver, IWebElement element)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            Thread.Sleep(5000);
        }

        public static string ExtractTextFromXPath(this IWebDriver driver, string path)
        {
            string script = "var element = document.evaluate(\""
            + path
            + "\", document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue;"
            + "if (element) { return element.nodeValue.trim(); } else return ''; ";
            return (string)((IJavaScriptExecutor)driver).ExecuteScript(script);
        }
    }
}
