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
using IdlingComplaints.Tests.ComplaintForm.Complaint;
using static System.Net.Mime.MediaTypeNames;

namespace IdlingComplaints.Tests.ComplaintForm.Complainant
{
    internal class Test60_Label : ComplaintFormModel
    { 

        private readonly int SLEEP_TIMER = 2000;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
           base.ComplaintFormModelSetUp(true);
           
           ClickNo();
           var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(d => d.FindElement(By.CssSelector("input[formcontrolname='idc_associatedlastname']")));
           

        }
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            base.ComplaintFormModelTearDown();
        }


        [Test, Category("Correct Label Displayed")]
        public void DisplayedHeading()
        {
            string text = Driver.ExtractTextFromXPath("/html/body/app-root/div/idling-complaint/form/div/mat-card[2]/mat-card-header/div/mat-card-title/h4/text()");
                                                        
            Assert.That(text, Is.EqualTo(Constants.COMPLAINT_TITLE));
        }

        [Test, Category("Correct Label Displayed")]
        public void DisplayedCompanyName()
        {
            var text = Associated_CompanyNameControl.GetAttribute("placeholder");

            Assert.That(text, Is.EqualTo(Constants.COMPANY_NAME));
        }

        [Test, Category("Correct Label Displayed")]
        public void DisplayedState()
        {
            var text = Associated_StateControl.GetAttribute("placeholder");

            Assert.That(text, Is.EqualTo(Constants.STATE));
        }
        [Test, Category("Correct Label Displayed")]
        public void DisplayedHouseNumber()
        {
            var text = Associated_HouseNumberControl.GetAttribute("placeholder");

            Assert.That(text, Is.EqualTo(Constants.HOUSENUMBER));
        }

        [Test, Category("Correct Label Displayed")]
        public void DisplayedStreet()
        {
            var text = Associated_StreetNameControl.GetAttribute("placeholder");

            Assert.That(text, Is.EqualTo(Constants.STREET_NAME));
        }

        [Test, Category("Correct Label Displayed")]
        public void DisplayedCity()
        {

            var text = Associated_CityControl.GetAttribute("placeholder");

            Assert.That(text, Is.EqualTo(Constants.CITY));
        }

        [Test, Category("Incorrect Label Displayed")]
        public void DisplayedZipCode()
        {
            //  ScrollToZipCode();
            //ZipCodeControl.SendTextDeleteTabWithDelay("XX", SLEEP_TIMER);
            var text = Associated_ZipCodeControl.GetAttribute("placeholder");

            Assert.That(text, Is.EqualTo(Constants.ZIP), "Flagged for inconsistency on purpose.");
        }

        [Test, Category("Incorrect Label Displayed")]
        public void RequiredHouseNumber()
        {
            Associated_HouseNumberControl.SendTextDeleteTabWithDelay("XX", SLEEP_TIMER);

            Assert.That((Object)" ",Is.EqualTo(Constants.HOUSENUMBER_REQUIRE), "Flagged for inconsistency on purpose.");
        }

        [Test, Category("Correct Label Displayed")]
        public void RequiredCompanyName()
        {
            Associated_CompanyNameControl.SendTextDeleteTabWithDelay("XX", SLEEP_TIMER);
            var text = Driver.ExtractTextFromXPath("/html/body/app-root/div/idling-complaint/form/div/mat-card[2]/mat-card-content/div[1]/mat-form-field[1]/div/div[3]/div/mat-error/text()");

            Assert.That(text, Is.EqualTo(Constants.COMPANY_NAME_REQUIRE), "Flagged for inconsistency on purpose.");
        }

        [Test, Category("Correct Label Displayed")]
        public void RequiredState()
        {
            Associated_StateControl.SendTextDeleteTabWithDelay("XX", SLEEP_TIMER);
            var text = Driver.ExtractTextFromXPath("/html/body/app-root/div/idling-complaint/form/div/mat-card[2]/mat-card-content/div[1]/mat-form-field[2]/div/div[3]/div/mat-error/text()");
            Assert.That(text, Is.EqualTo(Constants.STATE_REQUIRE), "Flagged for inconsistency on purpose.");
        }

        [Test, Category("Correct Label Displayed")]
        public void RequiredStreet()
        {
            Associated_StreetNameControl.SendTextDeleteTabWithDelay("XX", SLEEP_TIMER);
            var text = Driver.ExtractTextFromXPath("/html/body/app-root/div/idling-complaint/form/div/mat-card[2]/mat-card-content/div[3]/mat-form-field[2]/div/div[3]/div/mat-error/text()");

            Assert.That(text, Is.EqualTo(Constants.STREET_NAME_REQUIRE), "Flagged for inconsistency on purpose.");
        }

        [Test, Category("Correct Label Displayed")]
        public void RequiredCity()
        {
            Associated_CityControl.SendTextDeleteTabWithDelay("XX", SLEEP_TIMER);
            var text = Driver.ExtractTextFromXPath("//mat-form-field[1]/div/div[3]/div/mat-error/text()");

            Assert.That(text, Is.EqualTo(Constants.CITY_REQUIRE), "Flagged for inconsistency on purpose.");
        }

        [Test, Category("Incorrect Label Displayed")]
        public void RequiredZipCode()
        {
            Associated_ZipCodeControl.SendTextDeleteTabWithDelay("XX", SLEEP_TIMER);
            var text = Driver.ExtractTextFromXPath("/html/body/app-root/div/idling-complaint/form/div/mat-card[2]/mat-card-content/div[5]/mat-form-field[2]/div/div[3]/div/mat-error/text()");

            Assert.That(text, Is.EqualTo(Constants.ZIP_CODE_REQUIRE), "Flagged for inconsistency on purpose.");
        }
        [Test, Category("Correct Label Displayed")]
        public void RequiredStateSelection()
        {
            Associated_SelectState(0);
            Thread.Sleep(2000);
            string error = Driver.ExtractTextFromXPath("//mat-form-field[2]/div/div[3]/div/mat-error/text()");
            Assert.That(error, Is.EqualTo(Constants.STATE_REQUIRE), "Flagged for inconsistency on purpose.");
        }

        [Test, Category("Correct Label Displayed")]
        public void DisplayedDescribeTitle()
        {

            string title = Driver.ExtractTextFromXPath("/html/body/app-root/div/idling-complaint/form/div/mat-card[4]/mat-card-header/div/mat-card-title/h4/text()");
            Assert.That(title, Is.EqualTo(Constants.DESCRIBE_TITLE), "Flagged for inconsistency on purpose.");
        }

        [Test, Category("Correct Label Displayed")]
        public void DisplayedDescribeContent()
        {
            string describeContent = Driver.ExtractTextFromXPath("/html/body/app-root/div/idling-complaint/form/div/mat-card[4]/mat-card-content/mat-form-field/div/div[1]/div/span/label/span/text()");
            Assert.That(describeContent, Is.EqualTo(Constants.DESCRIBE_CONTENT_INPUT), "Flagged for inconsistency on purpose.");
        }

        [Test, Category("Correct Label Displayed")]
        public void RequireDescribeContent()
        {
            Describe_ContentControl.SendTextDeleteTabWithDelay("XX", SLEEP_TIMER);
            string requireContent = Driver.ExtractTextFromXPath("/html/body/app-root/div/idling-complaint/form/div/mat-card[4]/mat-card-content/mat-form-field/div/div[3]/div/mat-error/text()");
            Assert.That(requireContent, Is.EqualTo(Constants.DESCRIBE_COMPLAINT_REQUIRE), "Flagged for inconsistency on purpose.");
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
