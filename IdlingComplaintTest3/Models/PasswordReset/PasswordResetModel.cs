using IdlingComplaints.Tests;
using OpenQA.Selenium;
using SeleniumUtilities.BaseSetUp;
using SeleniumUtilities.Utils.TestUtils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdlingComplaints.Models.PasswordReset
{
    internal class PasswordResetModel : BaseModel
    {
        
        public void PasswordResetModelSetUp(bool isHeadless)
        {
            if (isHeadless) Driver = CreateHeadlessDriver("chrome");
            else Driver = CreateStandardDriver("chrome");

            Driver.Navigate().GoToUrl("https://nycidling-dev.azurewebsites.net/password-reset");
            //Driver.Manage().Window.Size = new Size(1920, 1200);
            Driver.Manage().Window.Maximize();

        }

        public void PasswordResetModelTearDown()
        {
            Driver.Quit();
        }

        public By SpinnerByControl => By.TagName("mat-spinner");
        public By SnackBarByControl => By.TagName("simple-snack-bar");
        public By SecurityAnswerByControl => By.CssSelector("input[formcontrolname = 'securityanswer']");

        public IWebElement TitleControl => Driver.FindElement(By.XPath("//password-reset/form/div/div/mat-card/mat-card-header/div/mat-card-title/h4"));
        public IWebElement EmailControl => Driver.FindElement(By.Name("email"));
        public IWebElement ResetButtonControl => Driver.FindElement(By.CssSelector("button[color='primary']"));                                
        public IWebElement CancelButtonControl => Driver.FindElement(By.CssSelector("button[type='reset']"));
        public IWebElement EmailRequiredContorl => Driver.FindElement(By.Id("mat-error-0"));
        

        public IWebElement SecurityAnswerControl => Driver.FindElement(By.CssSelector("input[formcontrolname='securityanswer']"));
        public IWebElement PasswordControl => Driver.FindElement(By.CssSelector("input[formcontrolname='idc_password']"));
        public IWebElement ConfirmPasswordControl => Driver.FindElement(By.CssSelector("input[formcontrolname='confirmPassword']"));

        public string InvalidEmailControl => Driver.ExtractTextFromXPath("/html/body/div[2]/div/div/snack-bar-container/simple-snack-bar/span/text()");

        public IWebElement PasswordRequiredControl => Driver.FindElement(By.Id("mat-error-3"));
        public IWebElement ConfirmPasswordRequriedControl => Driver.FindElement(By.Id("mat-error-1"));
  

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
        public string SecurityAnswerInput
        {
            get
            {
                return SecurityAnswerControl.GetAttribute("value");
            }
            set
            {
                SecurityAnswerControl.SendKeys(value);
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
        public string ConfirmPasswordInput
        {
            get
            {
                return ConfirmPasswordControl.GetAttribute("value");
            }
            set
            {
                ConfirmPasswordControl.SendKeys(value);
            }
        }
        public void ClickResetButton()
        {
            ResetButtonControl.Click();
        }
        public void ClickSubmitButton()
        {
            ResetButtonControl.Click();
        }
        public void ClickCancelButton()
        {
            CancelButtonControl.Click();
        }
        public void ScrollToTheLoginButton()
        {
            Driver.ScrollTo(ResetButtonControl);
        }
    }
}
