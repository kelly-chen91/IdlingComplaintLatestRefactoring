using SeleniumUtilities.Base;
using SeleniumUtilities.Utils;
using IdlingComplaints.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdlingComplaints.Models.Login;
using System.Drawing;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System.Reflection.Metadata.Ecma335;

namespace IdlingComplaints.Models.Home
{
    internal class HomeModel : LoginModel
    {
        public HomeModel() { }
        public new void OneTimeSetUp()
        {
            //loginModel = new LoginModel();
            base.OneTimeSetUp();
            EmailControl.SendKeysWithDelay("kchen@dep.nyc.gov", 0);
            PasswordControl.SendKeysWithDelay("T3sting@1234", 0);
            ClickLoginButton();
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.CssSelector("button[routerlink='idlingcomplaint/new']")));
        }

        public new void OneTimeTearDown()
        {
            base.OneTimeTearDown();
        }

        public IWebElement NewComplaintControl => Driver.FindElement(By.CssSelector("button[routerlink='idlingcomplaint/new']"));
        public IWebElement CreatedYearControl => Driver.FindElement(By.CssSelector("mat-select[name = 'createdYear']"));
        public IWebElement HomeControl => Driver.FindElement(By.CssSelector("button[routerlink = '/']"));
        public IWebElement ProfileControl => Driver.FindElement(By.CssSelector("button[routerlink = 'profile']"));
        public IWebElement LogoutControl => Driver.FindElement(RelativeBy.WithLocator(By.TagName("button")).Below(ProfileControl));
        public IWebElement SortComplaintNumControl => Driver.FindElement(By.CssSelector("button[aria-label = 'Change sorting for idc_name']"));
        public IWebElement SortCompanyControl => Driver.FindElement(By.CssSelector("button[aria-label = 'Change sorting for idc_associatedlastname']"));
        public IWebElement SortPlaceControl => Driver.FindElement(By.CssSelector("button[aria-label = 'Change sorting for idc_occurrenceplace']"));
        public IWebElement SortStatusControl => Driver.FindElement(By.CssSelector("button[aria-label = 'Change sorting for statuscode']"));
        public IWebElement SortSubmittedDateControl => Driver.FindElement(By.CssSelector("button[aria-label = 'Change sorting for idc_datesubmitted']"));
        public IWebElement SortSummonsNumControl => Driver.FindElement(By.CssSelector("button[aria-label = 'Change sorting for idc_violationnumber']"));
        public IWebElement SortHearingDateControl => Driver.FindElement(By.CssSelector("button[aria-label = 'Change sorting for idc_hearingdate']"));
        public IWebElement ItemsPerPageControl => Driver.FindElement(By.CssSelector("mat-select[aria-label = 'Items per page:']"));
        public IWebElement TableControl => Driver.FindElement(By.TagName("table"));
        //public IWebElement LaunchComplaint1Control => Driver.FindElement(By.CssSelector("i[tabindex = '0']"));

        public string selectedCreatedYear, selectedItemsPerPage;
        public void ClickNewComplaintButton()
        {
            NewComplaintControl.Click();
        }

        public void ClickHomeButton()
        {
            HomeControl.Click();
        }

        public void ClickProfileButton()
        {
            ProfileControl.Click();
        }

        public void ClickLogoutButton()
        {
            LogoutControl.Click(); 
        }

        public void SortComplaintNumber()
        {
            SortComplaintNumControl.Click();
        }

        public void SortCompanyName()
        {
            SortCompanyControl.Click();
        }

        public void SortPlace()
        {
            SortPlaceControl.Click();
        }

        public void SortStatus()
        {
            SortStatusControl.Click();
        }

        public void SortSubmittedDate()
        {
            SortSubmittedDateControl.Click();
        }

        public void SortSummonsNumber()
        {
            SortSummonsNumControl.Click();
        }

        public void SortHearingDate()
        {
            SortHearingDateControl.Click();
        }

        public void SelectCreatedYear(int yearIndex)
        {
            CreatedYearControl.Click();
            var createdYear = CreatedYearControl.FindElements(By.TagName("span")); //gathers all choices to a list
            List<string> createdYearList = createdYear.ConvertOptionToText();
            if (yearIndex < 0 || yearIndex >= createdYearList.Count) { return; }
            selectedCreatedYear = createdYearList[yearIndex];
            createdYear[yearIndex].Click();
        }

        public void SelectItemsPerPage(int itemsIndex)
        {
            ItemsPerPageControl.Click();
            var itemsPerPage = ItemsPerPageControl.FindElements(By.TagName("span")); //gathers all choices to a list
            List<string> itemsPerPageList = itemsPerPage.ConvertOptionToText();
            if (itemsIndex < 0 || itemsIndex >= itemsPerPageList.Count) { return; }
            selectedCreatedYear = itemsPerPageList[itemsIndex];
            itemsPerPage[itemsIndex].Click();
        }


        
    }
}
