using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SeleniumUtilities.Utils;

namespace SeleniumUtilities.Base
{
    public class BaseModel
    {
        protected IWebDriver Driver;
        
        //protected BaseModel(bool isHeadless)
        //{
        //    Driver = CreateHeadlessDriver("chrome");
        //}


        protected IWebDriver CreateStandardDriver(string browserName)
        {
            switch (browserName.ToLowerInvariant())
            {
                case "chrome":
                    var chromeOptions = new ChromeOptions();
                      //chromeOptions.AddArguments(GetBrowserArguments());
                    return new ChromeDriver(chromeOptions);
                case "firefox":
                    var firefoxOptions = new FirefoxOptions();
                    //firefoxOptions.AddArguments(GetBrowserArguments());
                    return new FirefoxDriver(firefoxOptions);
                case "edge":
                    var edgeOptions = new EdgeOptions();
                    //edgeOptions.AddArguments(GetBrowserArguments());
                    return new EdgeDriver(edgeOptions);
                default:
                    throw new Exception("Provided browser is not supported.");
            }
        }

        protected IWebDriver CreateHeadlessDriver(string browserName)
        {
            string headless = "--headless=new";
            switch (browserName.ToLowerInvariant())
            {
                case "chrome":
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArguments(headless);
                    return new ChromeDriver(chromeOptions);
                case "firefox":
                    var firefoxOptions = new FirefoxOptions();
                    firefoxOptions.AddArguments(headless);
                    return new FirefoxDriver(firefoxOptions);
                case "edge":
                    var edgeOptions = new EdgeOptions();
                    edgeOptions.AddArguments(headless);
                    return new EdgeDriver(edgeOptions);
                default:
                    throw new Exception("Provided browser is not supported.");
            }
        }

        //public MediaEntityModelProvider CaptureScreenshot(string name, IWebDriver driver)
        //{
        //    var screenshot = ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;
        //    return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot,name).Build(); 
        //    //var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
        //    //screenshot.SaveAsFile(StringUtilities.GetProjectRootDirectory() + "\\Screenshots\\" + name + ".png", ScreenshotImageFormat.Png);
        //    //return MediaEntityBuilder.CreateScreenCaptureFromPath("\\Screenshots\\" + name + ".png").Build();
        //}


    }
}
