using IdlingComplaints.Models.Home;
using IdlingComplaints.Models.Login;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumUtilities.Base;
using SeleniumUtilities.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdlingComplaints.Models.ComplaintForm
{
    internal class ComplaintFormModel : HomeModel
    {

        [OneTimeSetUp]
        public new void OneTimeSetUp()
        {
            base.OneTimeSetUp("TTseng@dep.nyc.gov", "Testing1#");
            ClickNewComplaintButton();
            Driver.WaitUntilElementFound(By.TagName("mat-radio-button"), 10);
            Driver.WaitUntilElementIsNoLongerFound(By.CssSelector("div[dir = 'ltr']"), 20);
        }
        [OneTimeTearDown]
        public new void OneTimeTearDown()
        {
            base.OneTimeTearDown();
        }

        public IWebElement YesButtonControl => Driver.FindElement(By.CssSelector("mat-radio-button[id='mat-radio-2']"));
        public IWebElement YesLabelControl =>Driver.FindElement(By.CssSelector("label[for='criteriaError']"));
        
        public IWebElement NoButtonControl => Driver.FindElement(By.CssSelector("mat-radio-button[value = 'No']"));

        public IWebElement CompanyNameControl => Driver.FindElement(By.CssSelector("input[placeholder='Company Name']"));
        public IWebElement StateControl => Driver.FindElement(By.CssSelector("input[placeholder='State']"));

        public IWebElement HouseNumberControl => Driver.FindElement(By.CssSelector("input[placeholder='House Number']"));
        public IWebElement StreetNameControl => Driver.FindElement(By.CssSelector("input[placeholder='Street Name/P. O. Box']"));

        public IWebElement AptFloorControl => Driver.FindElement(By.CssSelector("input[placeholder='Apt/Floor/Suite/Unit']"));
        public IWebElement CityControl => Driver.FindElement(By.CssSelector("input[placeholder='City]"));
        public IWebElement ZipCodeControl => Driver.FindElement(By.CssSelector("input[placeholder='Zip']"));
        //public IWebElement AptFloorControl => Driver.FindElement(By.CssSelector("input[placeholder='Apt/Floor/Suite/Unit']"));



        public void ClickYesButton()
        {
            YesButtonControl.Click();
            
        }
        public void ClickNoButton() 
        {
            //var button = NoButtonControl.FindElement(By.TagName("input"));
            //button.Click();
            NoButtonControl.Click();
        }
    }
}
