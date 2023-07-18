using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SeleniumUtilities.Utils
{
    public static class ExpectedConditions
    {
            public static Func<IWebDriver, IWebElement> ElementIsVisible(IWebElement element)
            {
                return (driver) =>
                {
                    if (element.Displayed) return element;
                    return null;
                };
            }
    }
}
