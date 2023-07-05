using SeleniumUtilities.Base;
using SeleniumUtilities.Utils;
using OpenQA.Selenium;
using System.Drawing;

namespace IdlingComplaints.Models.Login
{
    internal class LoginModel : BaseModel
    {
        public void LoginModelSetUp(bool isHeadless)
        {
            if (isHeadless) Driver = CreateHeadlessDriver("chrome");
            else Driver = CreateStandardDriver("chrome");
            Driver.Navigate().GoToUrl("https://nycidling-dev.azurewebsites.net/login");
            // Driver.Manage().Window.Size = new Size(1920, 1200);
            Driver.Manage().Window.Maximize();
        }

        
         public void LoginModelTearDown()
         {
             Driver.Quit();
         }


        public IWebElement TitleControl => Driver.FindElement(By.TagName("h3"));
        public IWebElement EmailControl => Driver.FindElement(By.Name("email"));
        public IWebElement PasswordControl => Driver.FindElement(By.Name("password"));
        public IWebElement LoginControl => Driver.FindElement(By.ClassName("mat-button-wrapper"));
        public IWebElement ForgotPasswordControl => Driver.FindElement(By.PartialLinkText("Forgot"));
        public IWebElement CreateAccountControl => Driver.FindElement(By.PartialLinkText("Create"));

        public string EmailInput
        {
            get
            {
                return EmailControl.GetAttribute("value");
            }
            set
            {
                EmailControl.SendKeys(value);
            }
        }

        public string PasswordInput
        {
            get
            {
                return PasswordControl.GetAttribute("value");
            }
            set
            {
                PasswordControl.SendKeys(value);
            }
        }

        public void ClickLoginButton()
        {
            LoginControl.Click();
        }

        public void ScrollToTheLoginButton()
        {
            Driver.ScrollTo(LoginControl);
        }


    }
}
