﻿using SeleniumUtilities.BaseSetUp;
using OpenQA.Selenium;
using System.Drawing;
using IdlingComplaints.Tests;
using SeleniumUtilities.Utils.TestUtils;

namespace IdlingComplaints.Models.Login
{
    internal class LoginModel : BaseModel
    {
        public void LoginModelSetUp(bool isHeadless)
        {
            if (isHeadless) Driver = CreateHeadlessDriver("chrome");
            else Driver = CreateStandardDriver("chrome");
            Driver.Navigate().GoToUrl("https://nycidling-dev.azurewebsites.net/login");
            Driver.Manage().Window.Maximize();
        }

         public void LoginModelTearDown()
         {
            Driver.Quit();
            
         }

        public By SpinnerByControl => By.TagName("mat-spinner");
        public By SnackBarByControl => By.TagName("simple-snack-bar");
        public By NewComplaintByControl => By.CssSelector("button[routerlink='idlingcomplaint/new']");
        public By ForgotPasswordByControl => By.PartialLinkText("Forgot");

        public IWebElement TitleControl => Driver.FindElement(By.TagName("h3"));
        public IWebElement EmailControl => Driver.FindElement(By.Name("email"));
        public IWebElement PasswordControl => Driver.FindElement(By.Name("password"));
        public IWebElement LoginControl => Driver.FindElement(By.ClassName("mat-button-wrapper"));
        public IWebElement ForgotPasswordControl => Driver.FindElement(ForgotPasswordByControl);
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

        public IWebElement tablecontrol => Driver.FindElement(By.TagName("table"));
    }
}
