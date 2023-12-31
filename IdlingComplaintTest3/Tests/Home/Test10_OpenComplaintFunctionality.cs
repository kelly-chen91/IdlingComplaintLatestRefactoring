﻿using IdlingComplaints.Models.Home;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V112.Debugger;
using OpenQA.Selenium.Support.UI;
using SeleniumUtilities.BaseSetUp;
using SeleniumUtilities.Utils.TestUtils;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdlingComplaints.Tests.Home
{

    internal class Test10_OpenComplaintFunctionality : HomeModel
    {
        private readonly int SLEEP_TIMER = 0;
        private readonly string registered_EmailAddress = StringUtilities.GetProjectRootDirectory() + "\\Files\\Text\\ComplaintForm_AccountTracker.txt";
        private Random random = new Random();

        BaseExtent extent;

        public Test10_OpenComplaintFunctionality()
        {
            extent = new BaseExtent();
        }
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            extent.SetUp(false, GetType().Namespace + "." + GetType().Name);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            extent.TearDown(false, Driver);
        }

        [SetUp]
        public void SetUp()
        {
            string[] lines = File.ReadAllLines(registered_EmailAddress);
            int userRowIndex = random.Next(0, lines.Length - 1);

            string email = FileUtilities.RetrieveRecordValue(registered_EmailAddress, userRowIndex, 0);
            string password = FileUtilities.RetrieveRecordValue(registered_EmailAddress, userRowIndex, 1);
            //base.HomeModelSetUp("ttseng@dep.nyc.gov", "Testing1#", true);
            base.HomeModelSetUp(email, password, true);

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
            finally
            {
                if (SLEEP_TIMER > 0)
                    Thread.Sleep(SLEEP_TIMER);
                base.HomeModelTearDown();
            }
        }

        [Test]
        [Category("Successful Redirect - Complaint Details Displayed")]
        public void SuccessfulOpenComplaints()
        {
            var link = By.TagName("a");
            var complaintNumberRowControl = By.ClassName("mat-column-idc_name");

            var rowList = TableControl.GetDataFromTable();
            var openComplaintList = rowList.GetSpecificColumnElements(link);
            var complaintNumList = rowList.GetSpecificColumnText(complaintNumberRowControl);
            int numComplaints = 0, totalComplaints = openComplaintList.Count;
            if (totalComplaints > 2)
            {
                numComplaints = 2;
            } else if(totalComplaints > 1)
            {
                numComplaints = 1;
            }
            for (int i = 0; i < numComplaints; i++)
            {
                Driver.WaitUntilElementFound(NewComplaintByControl, 10);
                Driver.WaitUntilElementIsNoLongerFound(SpinnerByControl, 30);

                rowList = TableControl.GetDataFromTable();
                openComplaintList = rowList.GetSpecificColumnElements(link);
                complaintNumList = rowList.GetSpecificColumnText(complaintNumberRowControl);

                openComplaintList[i].Click();

                var complientNumberControl = Driver.WaitUntilElementFound(ComplaintForm_ComplaintNumberByControl, 30);

                string openComplaintNumber = complientNumberControl.Text;

                Assert.That(openComplaintNumber, Is.EqualTo("Complaint Number: " + complaintNumList[i]));

                if (SLEEP_TIMER > 0)
                    Thread.Sleep(SLEEP_TIMER);

                ClickHomeButton();
            }
        }


        [Test, Category("Next Arrow Till Last Page + Counter")]
        public void NextArrow_CountPages()
        {
            //Change amount of items per page
            SelectItemsPerPage(1);

            int pageCount = 1;
            
            while (NextPageArrowControl.Enabled) 
            {
                NextPageArrowControl.Click();
                pageCount++;
            }

            string complaintCount = Driver.ExtractTextFromXPath("//mat-paginator/div/div/div[2]/div/text()");
            int index = complaintCount.IndexOf("f") + 2;
            string outOfComplaintAmount = complaintCount.Substring(index);
            int totalComplaintAmount = int.Parse(outOfComplaintAmount); //Taking the listed total amount of complaints and turning into int

            string itemsPerPage = Driver.ExtractTextFromXPath("//div[1]/mat-form-field/div/div[1]/div/mat-select/div/div[1]/span/span/text()");
            int divideItemsPerPage = int.Parse(itemsPerPage); //Taking the items per page and turning into int
            int calculatedPageCount = 0;
            if (totalComplaintAmount > 0)
            {
                calculatedPageCount = totalComplaintAmount % divideItemsPerPage == 0 ? totalComplaintAmount / divideItemsPerPage : (totalComplaintAmount / divideItemsPerPage) + 1;
            } else
            {
                pageCount = 0;
            }

            Assert.That(pageCount, Is.EqualTo(calculatedPageCount));

 
        }

        [Test, Category("Previous Arrow Till First Page + Counter")]
        public void PreviousArrow_CountPages()
        {
            //Change amount of items per page
            SelectItemsPerPage(1);

            ClickLastPage();

            int pageCount = 1;
            while (PreviousPageArrowControl.Enabled)
            {
                PreviousPageArrowControl.Click();
                pageCount++;
            }

            string complaintCount = Driver.ExtractTextFromXPath("//mat-paginator/div/div/div[2]/div/text()");
            int index = complaintCount.IndexOf("f") + 2;
            string outOfComplaintAmount = complaintCount.Substring(index);
            int totalComplaintAmount = int.Parse(outOfComplaintAmount); //Taking the listed total amount of complaints and turning into int

            string itemsPerPage = Driver.ExtractTextFromXPath("//div[1]/mat-form-field/div/div[1]/div/mat-select/div/div[1]/span/span/text()");
            int divideItemsPerPage = int.Parse(itemsPerPage); //Taking the items per page and turning into int

            int calculatedPageCount = 0;
            if (totalComplaintAmount > 0)
            {
                calculatedPageCount = totalComplaintAmount % divideItemsPerPage == 0 ? totalComplaintAmount / divideItemsPerPage : (totalComplaintAmount / divideItemsPerPage) + 1;
            }
            else
            {
                pageCount = 0;
            }

            Assert.That(pageCount, Is.EqualTo(calculatedPageCount));

        }

        [Test, Category("Last Page + Verify Last Complaint Shown")]
        public void LastArrow_VerifyPagination()
        {
            ClickLastPage();

            string complaintCount = Driver.ExtractTextFromXPath("//mat-paginator/div/div/div[2]/div/text()");
            Console.WriteLine(complaintCount); 
            // End Range Number | __ - __
            int index1 = complaintCount.IndexOf("–");
            int index2 = complaintCount.IndexOf("o");
            string complaintRange = "0";
            if (index1 != -1 && index2 != -1)
            {
                complaintRange = complaintCount.Substring(index1 + 2, index2 - index1 - 3);
            }


            // Total Complaint Number | of __
            int indexTotal = complaintCount.IndexOf("f") + 2;
            string totalComplaintAmount = complaintCount.Substring(indexTotal);

            Assert.That(complaintRange, Is.EqualTo(totalComplaintAmount));

        }

        [Test, Category("First Page + Verify Last Complaint Shown")]
        public void FirstArrow_VerifyPagination()
        {
            ClickLastPage();
            ClickFirstPage();

            string complaintCount = Driver.ExtractTextFromXPath("//mat-paginator/div/div/div[2]/div/text()");
            var rowList = TableControl.GetDataFromTable();
            int itemSize = rowList.Count;

            // Start Range Number | __ - __
            string complaintRange = complaintCount.Split('–')[0];
            if(rowList.Count > 0) 
            {
                Assert.That(complaintRange, Is.EqualTo("1 "));
            }

        }

        [Test, Category("Verify Number of Complaints")]
        [Ignore("Test may be duplicate")]
        public void VerifyNumOfComplaint()
        {
            SelectItemsPerPage(0);
            Thread.Sleep(3000);
            string itemPerPage = Driver.ExtractTextFromXPath("//app-home/app-idling-list/div/mat-paginator/div/div/div[1]/mat-form-field/div/div[1]/div/mat-select/div/div[1]/span/span/text()");
          
            var link = By.TagName("a");
            var rowList = TableControl.GetDataFromTable();
            int numOfFile = rowList.GetSpecificColumnElements(link).Count;
          
            Assert.That(int.Parse(itemPerPage), Is.EqualTo(numOfFile));

        }
    }
}
