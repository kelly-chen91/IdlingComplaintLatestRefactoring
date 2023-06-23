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
        public void OpenFirstComplaint()
        {
            var rowList = TableControl.GetDataFromTable();
            //var openComplaintList = rowList.GetSpecificColumnElements(By.TagName("a"));
            //var complaintNumList = rowList.GetSpecificColumnText(By.ClassName("mat-column-idc_name"));
            //
            //for(int i = 0; i < openComplaintList.Count; i++)
            //{
            //
            //    Driver.WaitUntilElementFound(By.CssSelector("button[routerlink = 'idlingcomplaint/new']"), 10);
            //    Driver.WaitUntilElementIsNoLongerFound(By.CssSelector("div[dir = 'ltr']"), 20);
            //    Thread.Sleep(1000);
            //    openComplaintList[i].Click();
            //    
            //    Driver.WaitUntilElementFound(By.CssSelector("h4[align = 'center']"), 15);
            //    string openComplaintNumber = Driver.FindElement(By.CssSelector("h4[align = 'center']")).Text;
            //   
            //    Console.WriteLine(openComplaintNumber);
            //    Assert.That(openComplaintNumber, Is.EqualTo("Complaint Number: " + complaintNumList[i]));
            //    ClickHomeButton();
            //}


            IWebElement open = rowList[0].FindElement(By.TagName("a"));
            string currComplaintNum = rowList[0].FindElement(By.ClassName("mat-column-idc_name")).Text;
            open.Click();
            Driver.WaitUntilElementFound(By.CssSelector("h4[align = 'center']"), 15);
            string openComplaintNumber = Driver.FindElement(By.CssSelector("h4[align = 'center']")).Text;
            Assert.That(openComplaintNumber, Is.EqualTo("Complaint Number: " + currComplaintNum));

        }

        [Test]
        public void OpenSecondComplaint()
        {
            var rowList = TableControl.GetDataFromTable();
            var openComplaintList = rowList.GetSpecificColumnElements(By.TagName("a"));
            var complaintNumList = rowList.GetSpecificColumnText(By.ClassName("mat-column-idc_name"));
            
            //for(int i = 0; i < openComplaintList.Count; i++)
            //{
            //
            //    Driver.WaitUntilElementFound(By.CssSelector("button[routerlink = 'idlingcomplaint/new']"), 20);
            //    //Driver.WaitUntilElementIsNoLongerFound(By.CssSelector("div[dir = 'ltr']"), 20);
            //    Thread.Sleep(1000);
            //    openComplaintList[i].Click();
            //    
            //    Driver.WaitUntilElementFound(By.CssSelector("h4[align = 'center']"), 15);
            //    string openComplaintNumber = Driver.FindElement(By.CssSelector("h4[align = 'center']")).Text;
            //   
            //    Console.WriteLine(openComplaintNumber);
            //    Assert.That(openComplaintNumber, Is.EqualTo("Complaint Number: " + complaintNumList[i]));
            //    ClickHomeButton();
            //}


           IWebElement open = rowList[1].FindElement(By.TagName("a"));
           string currComplaintNum = rowList[1].FindElement(By.ClassName("mat-column-idc_name")).Text;
           open.Click();
           Driver.WaitUntilElementFound(By.CssSelector("h4[align = 'center']"), 15);
           string openComplaintNumber = Driver.FindElement(By.CssSelector("h4[align = 'center']")).Text;
           Assert.That(openComplaintNumber, Is.EqualTo("Complaint Number: " + currComplaintNum));

        }
    }
}
