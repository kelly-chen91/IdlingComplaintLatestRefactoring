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
    
    internal class Test10_OpenComplaintFunctionality : HomeModel
    {
        private readonly int SLEEP_TIMER = 2000;

        public Test10_OpenComplaintFunctionality() { }
        [SetUp]
        public void SetUp()
        {
            base.HomeModelSetUp("ttseng@dep.nyc.gov", "Testing1#", false);
        }

        [TearDown]
        public void TearDown()
        {
            if (SLEEP_TIMER > 0)
                Thread.Sleep(SLEEP_TIMER);

            //Driver.Quit();
            base.HomeModelTearDown();
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

            for (int i = 0; i < 2; i++)
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
