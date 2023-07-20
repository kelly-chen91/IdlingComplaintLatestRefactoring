using IdlingComplaints.Models.Home;
using OpenQA.Selenium;
using SeleniumUtilities.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdlingComplaints.Tests.Home
{
    [Parallelizable(ParallelScope.Fixtures)]
    [FixtureLifeCycle(LifeCycle.SingleInstance)]
    internal class Test40_Filter : HomeModel
    {
        private readonly int SLEEP_TIMER = 0;

        BaseExtent extent;

        public Test40_Filter()
        {
            extent = new BaseExtent();
        }
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            extent.SetUp(false, GetType().Namespace + "." + GetType().Name);;
            base.HomeModelSetUp("ttseng@dep.nyc.gov", "Testing1#", true);

        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            extent.TearDown(false, Driver);
            if (SLEEP_TIMER > 0)
                Thread.Sleep(SLEEP_TIMER);
            base.HomeModelTearDown();
        }

        [SetUp]
        public void SetUp()
        {
            extent.SetUp(true);

        }

        [TearDown]
        public void TearDown()
        {
            try
            {
                extent.TearDown(true, Driver);
            }
            catch (Exception ex)
            {
                throw new Exception("Exception: " + ex);
            }
        }

        [Test]
        [Category("Number of Complaints on Table compliant to specified Items Per Page option.")]
        public void FilterItemsPerPageFive()
        {
            SelectItemsPerPage(0);
            var rowList = TableControl.GetDataFromTable();
            Assert.That(rowList.Count, Is.LessThanOrEqualTo(5));
        }

        [Test]
        [Category("Number of Complaints on Table compliant to specified Items Per Page option.")]
        public void FilterItemsPerPageTen()
        {
            SelectItemsPerPage(1);
            var rowList = TableControl.GetDataFromTable();
            Assert.That(rowList.Count, Is.LessThanOrEqualTo(10));
        }

        [Test]
        [Category("Number of Complaints on Table compliant to specified Items Per Page option.")]
        public void FilterItemsPerPageTwenty()
        {
            SelectItemsPerPage(2);
            var rowList = TableControl.GetDataFromTable();
            Assert.That(rowList.Count, Is.LessThanOrEqualTo(20));
        }

        [Test]
        [Category("Number of Complaints on Table compliant to specified Created Year option.")]
        public void FilterCurrentYear()
        {
            SelectCreatedYear(0);
            Driver.WaitUntilElementIsNoLongerFound(By.CssSelector("div[dir = 'ltr']"), 20);
            SortStatus();
            SortStatus();
            var rowList = TableControl.GetDataFromTable();
            var dateSubmittedList = rowList.GetSpecificColumnText(By.ClassName("mat-column-idc_datesubmitted"));
            string currentYear = (DateTime.Now.Year).ToString();
            foreach (var dateSubmitted in dateSubmittedList)
            {
                if (dateSubmitted.Length == 0) continue;
                Assert.That(currentYear, Is.EqualTo(dateSubmitted.Substring(6)));
            }
        }

        [Test]
        [Category("Number of Complaints on Table compliant to specified Created Year option.")]
        public void FilterLastYear()
        {
            SelectCreatedYear(1);
            Driver.WaitUntilElementIsNoLongerFound(By.CssSelector("div[dir = 'ltr']"), 20);
            var rowList = TableControl.GetDataFromTable();
            var dateSubmittedList = rowList.GetSpecificColumnText(By.ClassName("mat-column-idc_datesubmitted"));
            string lastYear = (DateTime.Now.Year - 1).ToString();
            foreach (var dateSubmitted in dateSubmittedList)
            {
                Assert.That(lastYear, Is.EqualTo(dateSubmitted.Substring(6)));
            }
            /*Date Submitted are System Generated, so there will not be any last year's complaints*/
        }

        [Test]
        [Category("Number of Complaints on Table compliant to specified Created Year option.")]
        public void FilterAllYear()
        {
            SelectCreatedYear(0);
            Driver.WaitUntilElementIsNoLongerFound(By.CssSelector("div[dir = 'ltr']"), 20);
            var rowList = TableControl.GetDataFromTable();
            var currentYearList = rowList.GetSpecificColumnText(By.ClassName("mat-column-idc_datesubmitted"));
            SelectCreatedYear(1);
            Driver.WaitUntilElementIsNoLongerFound(By.CssSelector("div[dir = 'ltr']"), 20);
            rowList = TableControl.GetDataFromTable();
            var lastYearList = rowList.GetSpecificColumnText(By.ClassName("mat-column-idc_datesubmitted"));
            SelectCreatedYear(2);
            Driver.WaitUntilElementIsNoLongerFound(By.CssSelector("div[dir = 'ltr']"), 20);
            rowList = TableControl.GetDataFromTable();
            var allList = rowList.GetSpecificColumnText(By.ClassName("mat-column-idc_datesubmitted"));

            Assert.That(allList.Count, Is.GreaterThanOrEqualTo(currentYearList.Count + lastYearList.Count));
        }
    }
}
