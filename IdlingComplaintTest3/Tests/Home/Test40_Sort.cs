using IdlingComplaints.Models.Home;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumUtilities.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace IdlingComplaints.Tests.Home
{
    internal class Test40_Sort : HomeModel
    {
        private readonly int SLEEP_TIMER = 3000;

        public Test40_Sort() { }

        [OneTimeSetUp]
        public new void OneTimeSetUp()
        {
            base.OneTimeSetUp("kchen@dep.nyc.gov", "T3sting@1234");

        }

        [TearDown]
        public void TearDown()
        {
            if (SLEEP_TIMER > 0)
                Thread.Sleep(SLEEP_TIMER);
        }

        [OneTimeTearDown]
        public new void OneTimeTearDown()
        {
            if (SLEEP_TIMER > 0)
                Thread.Sleep(SLEEP_TIMER);
            base.OneTimeTearDown();
        }

        [Test]
        [Category("Labels sort alphabetically or numerically.")]
        public void SortComplaintNumbers()
        {
            var rowList = TableControl.GetDataFromTable();

            List<string> sortedComplaintNumberTextList = rowList.GetSpecificColumnText(By.ClassName("mat-column-idc_name"));
            sortedComplaintNumberTextList.Sort();

            SortComplaintNumControl.Click();

            var sortedRowList = TableControl.GetDataFromTable();
            List<string> newComplaintNumberTextList = sortedRowList.GetSpecificColumnText(By.ClassName("mat-column-idc_name"));
            Boolean successfulSort = sortedComplaintNumberTextList.EqualsTableAfterSorting(newComplaintNumberTextList);

            Assert.IsTrue(successfulSort);
            Assert.That(rowList.Count, Is.EqualTo(2));

        }

        [Test]
        [Category("Labels sort alphabetically or numerically.")]
        public void SortCompanyNames()
        {
            var rowList = TableControl.GetDataFromTable();

            List<string> sortedCompanyNameTextList = rowList.GetSpecificColumnText(By.ClassName("mat-column-idc_associatedlastname"));
            sortedCompanyNameTextList.Sort();

            SortCompanyControl.Click();

            var sortedRowList = TableControl.GetDataFromTable();
            List<string> newCompanyNameTextList = sortedRowList.GetSpecificColumnText(By.ClassName("mat-column-idc_associatedlastname"));
            Boolean successfulSort = sortedCompanyNameTextList.EqualsTableAfterSorting(newCompanyNameTextList);

            Assert.IsTrue(successfulSort);
            Assert.That(rowList.Count, Is.EqualTo(2));

        }

        [Test]
        [Category("Labels sort alphabetically or numerically.")]
        public void SortPlaces()
        {
            var rowList = TableControl.GetDataFromTable();

            List<string> sortedPlacesTextList = rowList.GetSpecificColumnText(By.ClassName("mat-column-idc_occurrenceplace"));
            sortedPlacesTextList.Sort();

            SortPlaceControl.Click();

            var sortedRowList = TableControl.GetDataFromTable();
            List<string> newPlacesTextList = sortedRowList.GetSpecificColumnText(By.ClassName("mat-column-idc_occurrenceplace"));
            Boolean successfulSort = sortedPlacesTextList.EqualsTableAfterSorting(newPlacesTextList);

            Assert.IsTrue(successfulSort);
            Assert.That(rowList.Count, Is.EqualTo(2));
        }

        [Test]
        [Category("Labels sort alphabetically or numerically.")]
        public void SortStatuses()
        {
            var rowList = TableControl.GetDataFromTable();

            List<string> sortedStatusTextList = rowList.GetSpecificColumnText(By.ClassName("mat-column-statuscode"));
            sortedStatusTextList.Sort();

            SortStatusControl.Click();

            var sortedRowList = TableControl.GetDataFromTable();
            List<string> newStatusTextList = sortedRowList.GetSpecificColumnText(By.ClassName("mat-column-statuscode"));
            Boolean successfulSort = sortedStatusTextList.EqualsTableAfterSorting(newStatusTextList);

            Assert.IsTrue(successfulSort);
            Assert.That(rowList.Count, Is.EqualTo(2));
        }

        [Test]
        [Category("Labels sort alphabetically or numerically.")]
        public void SortSubmittedDates()
        {
            var rowList = TableControl.GetDataFromTable();

            List<string> sortedSubmittedDatesTextList = rowList.GetSpecificColumnText(By.ClassName("mat-column-idc_datesubmitted"));
            sortedSubmittedDatesTextList.Sort();

            SortSubmittedDateControl.Click();

            var sortedRowList = TableControl.GetDataFromTable();
            List<string> newSubmittedDatesTextList = sortedRowList.GetSpecificColumnText(By.ClassName("mat-column-idc_datesubmitted"));
            Boolean successfulSort = sortedSubmittedDatesTextList.EqualsTableAfterSorting(newSubmittedDatesTextList);

            Assert.IsTrue(successfulSort);
            Assert.That(rowList.Count, Is.EqualTo(2));
        }

        [Test]
        [Category("Labels sort alphabetically or numerically.")]
        public void SortSummonsNumbers()
        {
            var rowList = TableControl.GetDataFromTable();

            List<string> sortedSummonsNumbersTextList = rowList.GetSpecificColumnText(By.ClassName("mat-column-idc_violationnumber"));
            sortedSummonsNumbersTextList.Sort();

            SortSummonsNumControl.Click();

            var sortedRowList = TableControl.GetDataFromTable();
            List<string> newSummonsNumbersTextList = sortedRowList.GetSpecificColumnText(By.ClassName("mat-column-idc_violationnumber"));
            Boolean successfulSort = sortedSummonsNumbersTextList.EqualsTableAfterSorting(newSummonsNumbersTextList);

            Assert.IsTrue(successfulSort);
            Assert.That(rowList.Count, Is.EqualTo(2));
        }

        [Test]
        [Category("Labels sort alphabetically or numerically.")]
        public void SortHearingDates()
        {
            var rowList = TableControl.GetDataFromTable();

            List<string> sortedHearingDatesTextList = rowList.GetSpecificColumnText(By.ClassName("mat-column-idc_hearingdate"));
            sortedHearingDatesTextList.Sort();

            SortHearingDateControl.Click();

            var sortedRowList = TableControl.GetDataFromTable();
            List<string> newHearingDatesTextList = sortedRowList.GetSpecificColumnText(By.ClassName("mat-column-idc_hearingdate"));
            Boolean successfulSort = sortedHearingDatesTextList.EqualsTableAfterSorting(newHearingDatesTextList);

            Assert.IsTrue(successfulSort);
            Assert.That(rowList.Count, Is.EqualTo(2));
        }

        /*Items Per Range Filter Tests*/

    }
}
