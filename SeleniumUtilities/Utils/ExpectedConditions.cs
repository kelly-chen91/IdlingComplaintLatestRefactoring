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
        public static Func<IWebDriver, bool> ElementIsVisible(IWebElement element)
        {
            return (driver) =>
            {
                try
                {
                    return element.Displayed;
                }
                catch(Exception)
                {
                    return false;
                }
            };
        }

        public static Func<IWebDriver, bool> ElementIsNotVisible(IWebElement element)
        {
            return (driver) =>
            {
                try
                {
                    return !element.Displayed;
                }
                catch(NoSuchElementException)
                {
                    return true;
                }
                catch (Exception)
                {
                    return true;
                }
            };
        }

        public static Func<IWebDriver, IWebElement> GetVisibleElement(IWebElement element)
        {
            return (driver) =>
            {
                try
                {
                    if (element.Displayed) 
                        return element;
                }
                catch (Exception)
                {
                }

                return null;
            };
        }
    }
}
