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
        public void HomeModelSetUp(string email, string password, bool isHeadless)
        {
            base.LoginModelSetUp(isHeadless); 
            Login(email, password);
        }

        public void Login(string email, string password)
        {
            EmailControl.SendKeysWithDelay(email, 0);
            PasswordControl.SendKeysWithDelay(password, 0);
            ClickLoginButton();

            Driver.WaitUntilElementFound(NewComplaintByControl, 60);
            Driver.WaitUntilElementIsNoLongerFound(SpinnerByControl, 60);
        }

        public void HomeModelTearDown()
        {
            base.LoginModelTearDown();
        }


        //public By NewComplaintByControl => By.CssSelector("button[routerlink='idlingcomplaint/new']");
        public By Profile_FirstNameByControl => By.CssSelector("input[formcontrolname='firstname']");
        public By HomeByControl => By.CssSelector("button[routerlink = '/']");
        public By DateSubmittedByControl => By.ClassName("mat-column-idc_datesubmitted");
        public By ComplaintForm_ComplaintNumberByControl => By.CssSelector("h4[align='center']");
        public IWebElement NewComplaintControl => Driver.FindElement(NewComplaintByControl);
        
        public IWebElement CreatedYearControl => Driver.FindElement(By.CssSelector("mat-select[name = 'createdYear']"));
        public IWebElement HomeControl => Driver.FindElement(HomeByControl);
        public IWebElement ProfileControl => Driver.FindElement(By.CssSelector("button[routerlink = 'profile']"));
        public IWebElement LogoutControl => Driver.FindElement(By.XPath("//mat-toolbar-row/button[3]"));
        public IWebElement SortComplaintNumControl => Driver.FindElement(By.CssSelector("button[aria-label = 'Change sorting for idc_name']"));
        public IWebElement SortCompanyControl => Driver.FindElement(By.CssSelector("button[aria-label = 'Change sorting for idc_associatedlastname']"));
        public IWebElement SortPlaceControl => Driver.FindElement(By.CssSelector("button[aria-label = 'Change sorting for idc_occurrenceplace']"));
        public IWebElement SortStatusControl => Driver.FindElement(By.CssSelector("button[aria-label = 'Change sorting for statuscode']"));
        public IWebElement SortSubmittedDateControl => Driver.FindElement(By.CssSelector("button[aria-label = 'Change sorting for idc_datesubmitted']"));
        public IWebElement SortSummonsNumControl => Driver.FindElement(By.CssSelector("button[aria-label = 'Change sorting for idc_violationnumber']"));
        public IWebElement SortHearingDateControl => Driver.FindElement(By.CssSelector("button[aria-label = 'Change sorting for idc_hearingdate']"));
        public IWebElement ItemsPerPageControl => Driver.FindElement(By.CssSelector("mat-select[aria-label = 'Items per page:']"));
        public IWebElement TableControl => Driver.FindElement(By.TagName("table"));
        public IWebElement MatTableControl => Driver.FindElement(By.TagName("mat-card"));
        public IWebElement FirstPageArrowControl => Driver.FindElement(By.CssSelector("button[aria-label = 'First page']"));
        public IWebElement PreviousPageArrowControl => Driver.FindElement(By.CssSelector("button[aria-label = 'Previous page']"));
        public IWebElement NextPageArrowControl => Driver.FindElement(By.CssSelector("button[aria-label = 'Next page']"));
        public IWebElement LastPageArrowControl => Driver.FindElement(By.CssSelector("button[aria-label = 'Last page']"));



        public string selectedCreatedYearControl = "Current Year", selectedItemsPerPageControl = "5";
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

        public void ClickFirstPage()
        {
            if(FirstPageArrowControl.Enabled) FirstPageArrowControl.Click();
        }

        public void ClickPreviousPage()
        {
            if (PreviousPageArrowControl.Enabled) PreviousPageArrowControl.Click();

        }

        public void ClickNextPage()
        {
            if (NextPageArrowControl.Enabled) NextPageArrowControl.Click();

        }

        public void ClickLastPage()
        {
            if (LastPageArrowControl.Enabled) LastPageArrowControl.Click();
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
            Thread.Sleep(1000);

            CreatedYearControl.Click();
            var createdYear = Driver.FindElement(By.Id("mat-select-0-panel"));
            var optionElementList = createdYear.FindElements(By.TagName("span")); //gathers all choices to a list
            Thread.Sleep(1000);
            List<string> createdYearList = optionElementList.ConvertOptionToText();
            if (yearIndex < 0 || yearIndex >= createdYearList.Count) { return; }
            selectedCreatedYearControl = createdYearList[yearIndex];
            optionElementList[yearIndex].Click();

        }

        public void SelectItemsPerPage(int itemsIndex)
        {
            ItemsPerPageControl.Click();
            var itemsPerPage = Driver.FindElement(By.Id("mat-select-1-panel"));
            var optionElementList = itemsPerPage.FindElements(By.TagName("span")); //gathers all choices to a list
            Thread.Sleep(1000);
            List<string> itemsPerPageList = optionElementList.ConvertOptionToText();
            if (itemsIndex < 0 || itemsIndex >= itemsPerPageList.Count) { return; }
            selectedItemsPerPageControl = itemsPerPageList[itemsIndex];
            optionElementList[itemsIndex].Click();
            Thread.Sleep(1000);

        }
    }
}
