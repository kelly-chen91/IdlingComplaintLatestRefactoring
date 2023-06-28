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
    internal class Test50_OpenComplaintFunctionality : HomeModel
    {
        private readonly int SLEEP_TIMER = 2000;

        public Test50_OpenComplaintFunctionality() { }
        [SetUp]
        public void SetUp()
        {
            Driver.Quit();
            Driver = CreateStandardDriver("chrome");
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
            if (SLEEP_TIMER > 0)
                Thread.Sleep(SLEEP_TIMER);

            Driver.Quit();
        }

        [Test]
        [Category("Sucessful Redirect - Complaint Details Displayed")]
        public void SuccessfulOpenComplaints()
        {
            var link = By.TagName("a");
            var complaintNumberRowControl = By.ClassName("mat-column-idc_name");

            var rowList = TableControl.GetDataFromTable();
            var openComplaintList = rowList.GetSpecificColumnElements(link);
            var complaintNumList = rowList.GetSpecificColumnText(complaintNumberRowControl);

            for (int i = 0; i < openComplaintList.Count; i++)
            {
                Driver.WaitUntilElementFound(By.CssSelector("button[routerlink='idlingcomplaint/new']"), 10);
                Driver.WaitUntilElementIsNoLongerFound(By.CssSelector("div[dir='ltr']"), 20);

                rowList = TableControl.GetDataFromTable();
                openComplaintList = rowList.GetSpecificColumnElements(link);
                complaintNumList = rowList.GetSpecificColumnText(complaintNumberRowControl);

                openComplaintList[i].Click();

                var complientNumberControl = Driver.WaitUntilElementFound(By.CssSelector("h4[align='center']"), 15);

                string openComplaintNumber = complientNumberControl.Text;

                Assert.That(openComplaintNumber, Is.EqualTo("Complaint Number: " + complaintNumList[i]));

                if (SLEEP_TIMER > 0)
                    Thread.Sleep(SLEEP_TIMER);

                ClickHomeButton();
            }
        }

    }
}
