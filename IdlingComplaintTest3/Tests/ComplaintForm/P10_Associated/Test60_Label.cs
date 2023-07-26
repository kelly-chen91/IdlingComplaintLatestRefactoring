using IdlingComplaints.Models.ComplaintForm;
using OpenQA.Selenium.Support.UI;

using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V112.Audits;
using SeleniumUtilities.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdlingComplaints.Tests.ComplaintForm.P10_Associated;
using static System.Net.Mime.MediaTypeNames;
using SeleniumUtilities.Base;

namespace IdlingComplaints.Tests.ComplaintForm.P10_Associated
{

    internal class Test60_Label : ComplaintFormModel
    { 


        BaseExtent extent;

        public Test60_Label()
        {
            extent = new BaseExtent();
        }
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            extent.SetUp(false, GetType().Namespace + "." + GetType().Name);;

            base.ComplaintFormModelSetUp(true);
            NewComplaintSetUp();
            ClickNo();
            
            Driver.WaitUntilElementFound(Associated_CompanyNameByControl, 15);

        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            extent.TearDown(false, Driver);
            base.ComplaintFormModelTearDown();

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


        [Test, Category("Correct Label Displayed")]
        public void DisplayedHeading()
        {
            string text = Driver.ExtractTextFromXPath("//mat-card[2]/mat-card-header/div/mat-card-title/h4/text()");
                                                        
            Assert.That(text, Is.EqualTo(Constants.COMPLAINT_TITLE));
        }

        [Test, Category("Placeholder is present.")]
        public void PlaceholderCompanyName()
        {
            var text = Associated_CompanyNameControl.GetAttribute("placeholder");

            Assert.That(text, Is.EqualTo(Constants.COMPANY_NAME));
        }

        [Test, Category("Placeholder is present.")]
        public void PlaceholderState()
        {
            var text = Associated_StateControl.GetAttribute("placeholder");

            Assert.That(text, Is.EqualTo(Constants.STATE));
        }
        [Test, Category("Placeholder is present.")]
        public void PlaceholderHouseNumber()
        {
            var text = Associated_HouseNumberControl.GetAttribute("placeholder");

            Assert.That(text, Is.EqualTo(Constants.HOUSENUMBER));
        }

        [Test, Category("Placeholder is present.")]
        public void PlaceholderStreet()
        {
            var text = Associated_StreetNameControl.GetAttribute("placeholder");

            Assert.That(text, Is.EqualTo(Constants.STREET_NAME));
        }

        [Test, Category("Placeholder is present.")]
        public void PlaceholderCity()
        {

            var text = Associated_CityControl.GetAttribute("placeholder");

            Assert.That(text, Is.EqualTo(Constants.CITY));
        }

        [Test, Category("Placeholder is present.")]
        public void PlaceholderZipCode()
        {
            //  ScrollToZipCode();
            //ZipCodeControl.SendTextDeleteTabWithDelay("XX", SLEEP_TIMER);
            var text = Associated_ZipCodeControl.GetAttribute("placeholder");

            Assert.That(text, Is.EqualTo(Constants.ZIP), "Flagged for inconsistency on purpose.");
        }

       

        [Test, Category("Correct Label Displayed")]
        public void DisplayedDescribeTitle()
        {

            string title = Driver.ExtractTextFromXPath("//mat-card[4]/mat-card-header/div/mat-card-title/h4/text()");
            Assert.That(title, Is.EqualTo(Constants.DESCRIBE_TITLE), "Flagged for inconsistency on purpose.");
        }

        [Test, Category("Placeholder is present.")]
        public void PlaceholderDescribeContent()
        {
            string describeContent = Describe_ContentControl.GetAttribute("placeholder");
            Assert.That(describeContent, Is.EqualTo(Constants.DESCRIBE_CONTENT_INPUT), "Flagged for inconsistency on purpose.");
        }

        
        [Test, Category("Correct Label Displayed")]
        public void DisplayedDescribeTheComplaintTitle()
        {
            string describeTheComplaintTitle = "Describe the Complaint";
            string requireContent = Driver.ExtractTextFromXPath("//mat-card[4]/mat-card-header/div/mat-card-title/h4/text()");
            Assert.That(requireContent, Is.EqualTo(describeTheComplaintTitle), "Flagged for inconsistency on purpose.");
        }


    }
}
