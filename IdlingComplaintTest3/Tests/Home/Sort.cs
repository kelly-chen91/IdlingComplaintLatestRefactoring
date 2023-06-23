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
    internal class Sort : HomeModel
    {
        public Sort() { }

        [OneTimeSetUp]
        public new void OneTimeSetUp() 
        {
            base.OneTimeSetUp();

        }

        [OneTimeTearDown]
        public new void OneTimeTearDown()
        {
            Thread.Sleep(2000);
            base.OneTimeTearDown();
        }

        [Test]
        [Category("Labels sort alphabetically or numerically.")]
        public void SortComplaintNumbers()
        {
            var rowList = TableControl.GetDataFromTable();

            List<string> sortedComplaintNumberTextList = rowList.GetSpecifiedRow("mat-column-idc_name");
            sortedComplaintNumberTextList.Sort();

            SortComplaintNumControl.Click();

            var sortedRowList =TableControl.GetDataFromTable();
            List<string> newComplaintNumberTextList = sortedRowList.GetSpecifiedRow("mat-column-idc_name");
            Boolean successfulSort = sortedComplaintNumberTextList.EqualsTableAfterSorting(newComplaintNumberTextList);

            Assert.IsTrue(successfulSort);
            Assert.That(rowList.Count, Is.EqualTo(2));  
           
        }

        [Test]
        [Category("Labels sort alphabetically or numerically.")]
        public void SortCompanyNames()
        {
            var rowList = TableControl.GetDataFromTable();

            List<string> sortedCompanyNameTextList = rowList.GetSpecifiedRow("mat-column-idc_associatedlastname");
            sortedCompanyNameTextList.Sort();

            SortCompanyControl.Click();

            var sortedRowList = TableControl.GetDataFromTable();
            List<string> newCompanyNameTextList = sortedRowList.GetSpecifiedRow("mat-column-idc_associatedlastname");
            Boolean successfulSort = sortedCompanyNameTextList.EqualsTableAfterSorting(newCompanyNameTextList);

            Assert.IsTrue(successfulSort);
            Assert.That(rowList.Count, Is.EqualTo(2));

        }

        [Test]
        [Category("Labels sort alphabetically or numerically.")]
        public void SortPlaces()
        {
            var rowList = TableControl.GetDataFromTable();

            List<string> sortedPlacesTextList = rowList.GetSpecifiedRow("mat-column-idc_occurrenceplace");
            sortedPlacesTextList.Sort();

            SortPlaceControl.Click();

            var sortedRowList = TableControl.GetDataFromTable();
            List<string> newPlacesTextList = sortedRowList.GetSpecifiedRow("mat-column-idc_occurrenceplace");
            Boolean successfulSort = sortedPlacesTextList.EqualsTableAfterSorting(newPlacesTextList);

            Assert.IsTrue(successfulSort);
            Assert.That(rowList.Count, Is.EqualTo(2));
        }

        [Test]
        [Category("Labels sort alphabetically or numerically.")]
        public void SortStatuses()
        {
            var rowList = TableControl.GetDataFromTable();

            List<string> sortedStatusTextList = rowList.GetSpecifiedRow("mat-column-statuscode");
            sortedStatusTextList.Sort();

            SortStatusControl.Click();

            var sortedRowList = TableControl.GetDataFromTable();
            List<string> newStatusTextList = sortedRowList.GetSpecifiedRow("mat-column-statuscode");
            Boolean successfulSort = sortedStatusTextList.EqualsTableAfterSorting(newStatusTextList);

            Assert.IsTrue(successfulSort);
            Assert.That(rowList.Count, Is.EqualTo(2));
        }

        [Test]
        [Category("Labels sort alphabetically or numerically.")]
        public void SortSubmittedDates()
        {
            var rowList = TableControl.GetDataFromTable();

            List<string> sortedSubmittedDatesTextList = rowList.GetSpecifiedRow("mat-column-idc_datesubmitted");
            sortedSubmittedDatesTextList.Sort();

            SortSubmittedDateControl.Click();

            var sortedRowList = TableControl.GetDataFromTable();
            List<string> newSubmittedDatesTextList = sortedRowList.GetSpecifiedRow("mat-column-idc_datesubmitted");
            Boolean successfulSort = sortedSubmittedDatesTextList.EqualsTableAfterSorting(newSubmittedDatesTextList);

            Assert.IsTrue(successfulSort);
            Assert.That(rowList.Count, Is.EqualTo(2));
        }

        [Test]
        [Category("Labels sort alphabetically or numerically.")]
        public void SortSummonsNumbers()
        {
            var rowList = TableControl.GetDataFromTable();

            List<string> sortedSummonsNumbersTextList = rowList.GetSpecifiedRow("mat-column-idc_violationnumber");
            sortedSummonsNumbersTextList.Sort();

            SortSummonsNumControl.Click();

            var sortedRowList = TableControl.GetDataFromTable();
            List<string> newSummonsNumbersTextList = sortedRowList.GetSpecifiedRow("mat-column-idc_violationnumber");
            Boolean successfulSort = sortedSummonsNumbersTextList.EqualsTableAfterSorting(newSummonsNumbersTextList);

            Assert.IsTrue(successfulSort);
            Assert.That(rowList.Count, Is.EqualTo(2));
        }

        [Test]
        [Category("Labels sort alphabetically or numerically.")]
        public void SortHearingDates()
        {
            var rowList = TableControl.GetDataFromTable();

            List<string> sortedHearingDatesTextList = rowList.GetSpecifiedRow("mat-column-idc_hearingdate");
            sortedHearingDatesTextList.Sort();

            SortHearingDateControl.Click();

            var sortedRowList = TableControl.GetDataFromTable();
            List<string> newHearingDatesTextList = sortedRowList.GetSpecifiedRow("mat-column-idc_hearingdate");
            Boolean successfulSort = sortedHearingDatesTextList.EqualsTableAfterSorting(newHearingDatesTextList);

            Assert.IsTrue(successfulSort);
            Assert.That(rowList.Count, Is.EqualTo(2));
        }
    }
}
