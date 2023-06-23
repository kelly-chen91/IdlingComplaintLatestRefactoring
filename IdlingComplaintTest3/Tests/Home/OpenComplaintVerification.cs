using IdlingComplaints.Models.Home;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumUtilities.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdlingComplaints.Tests.Home
{
    internal class OpenComplaintVerification : HomeModel
    {
        public OpenComplaintVerification() { }
        [SetUp]
        public void SetUp()
        {
            Driver.Quit();
            Driver = CreateDriver("chrome");
            Driver.Navigate().GoToUrl("https://nycidling-dev.azurewebsites.net/login");
            Driver.Manage().Window.Size = new Size(1920, 1200);
            EmailControl.SendKeysWithDelay("kchen@dep.nyc.gov", 0);
            PasswordControl.SendKeysWithDelay("T3sting@1234", 0);
            ClickLoginButton();

            Driver.WaitUntilElementFound(By.CssSelector("button[routerlink = 'idlingcomplaint/new']"), 20);
            Driver.WaitUntilElementIsNoLongerFound(By.CssSelector("div[dir = 'ltr']"), 20);
        }

        [TearDown]
        public void TearDown()
        {
            Thread.Sleep(SLEEP_TIMER);
            Driver.Quit();
        }
        private readonly int SLEEP_TIMER = 2000;

        [Test]
        public void OpenComplaints()
        {
            var rowList = TableControl.GetDataFromTable();
            var openComplaintList = rowList.GetSpecificColumnElements(By.TagName("a"));
            var complaintNumList = rowList.GetSpecificColumnText(By.ClassName("mat-column-idc_name"));

            for (int i = 0; i < openComplaintList.Count; i++)
            {
                Driver.WaitUntilElementFound(By.CssSelector("button[routerlink='idlingcomplaint/new']"), 10);
                Driver.WaitUntilElementIsNoLongerFound(By.CssSelector("div[dir='ltr']"), 20);
                
                rowList = TableControl.GetDataFromTable();
                openComplaintList = rowList.GetSpecificColumnElements(By.TagName("a"));
                complaintNumList = rowList.GetSpecificColumnText(By.ClassName("mat-column-idc_name"));

                openComplaintList[i].Click();

                var complientNumberControl = Driver.WaitUntilElementFound(By.CssSelector("h4[align='center']"), 15);

                string openComplaintNumber = complientNumberControl.Text;

                Assert.That(openComplaintNumber, Is.EqualTo("Complaint Number: " + complaintNumList[i]));
                ClickHomeButton();
            }
        }

    }
}
