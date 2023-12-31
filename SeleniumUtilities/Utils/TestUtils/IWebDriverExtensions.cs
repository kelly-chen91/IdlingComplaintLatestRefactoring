﻿using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumUtilities.Utils.TestUtils
{
    public static class IWebDriverExternsions
    {
        public static void ScrollTo(this IWebDriver driver, IWebElement element)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            //Thread.Sleep(2000);
        }

        public static string ExtractTextFromXPath(this IWebDriver driver, string path)
        {
            string script = "var element = document.evaluate(\""
            + path
            + "\", document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue;"
            + "if (element) { return element.nodeValue.trim(); } else return ''; ";
            return (string)((IJavaScriptExecutor)driver).ExecuteScript(script);
        }

        public static void WaitUntilElementIsNoLongerFound(this IWebDriver webDriver, By locator, double timeout)
        {
            var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeout));
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException), typeof(NoSuchElementException));
            wait.Until(driver => webDriver.FindElements(locator).Count == 0);
        }

        public static IWebElement WaitUntilElementFound(this IWebDriver webDriver, By locator, double timeout)
        {
            var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeout));
            return wait.Until(d => d.FindElement(locator));
            //return wait.Until<IWebElement>((d) => { return d.FindElement(locator); });
        }

        public static MediaEntityModelProvider CaptureScreenshot(this IWebDriver driver, string name)
        {
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, name).Build();
        }
    }
}
