using IdlingComplaints.Models.ComplaintForm;
using IdlingComplaints.Tests.ComplaintForm.Complaint;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumUtilities.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdlingComplaints.Tests.ComplaintForm.Complainant
{
    internal class Label : ComplaintFormModel
    {
        [OneTimeSetUp]
        public new void OneTimeSetUp()
        {
            base.OneTimeSetUp();
            
            ClickNoButton();
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(d => d.FindElement(By.CssSelector("input[formcontrolname='idc_associatedlastname']")));
        }
        [OneTimeTearDown]
        public new void OneTimeTearDown()
        {
            base.OneTimeTearDown();
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
            var text = CompanyNameControl.GetAttribute("placeholder");

            Assert.That(text, Is.EqualTo(Constants.COMPANY_NAME));
        }
        [Test, Category("Correct Label Displayed")]
        public void DisplayedState()
        {
            var text = StateControl.GetAttribute("placeholder");

            Assert.That(text, Is.EqualTo(Constants.STATE));
        }
        [Test, Category("Correct Label Displayed")]
        public void DisplayedHouseNumber()
        {
            var text = HouseNumberControl.GetAttribute("placeholder");

            Assert.That(text, Is.EqualTo(Constants.HOUSENUMBER));
        }
        [Test, Category("Correct Label Displayed")]
        public void DisplayedStreet()
        {
            var text = StreetNameControl.GetAttribute("placeholder");

            Assert.That(text, Is.EqualTo(Constants.STREET_NAME));
        }
        [Test, Category("Correct Label Displayed")]
        public void DisplayedCity()
        {
            var text = CityControl.GetAttribute("placeholder");

            Assert.That(text, Is.EqualTo(Constants.CITY));
        }
        [Test, Category("Correct Label Displayed")]
        public void DisplayedZipCode()
        {
            var text = ZipCodeControl.GetAttribute("placeholder");

            Assert.That(text, Is.EqualTo(Constants.ZIP), "Flagged for inconsistency on purpose. It should be Zip Code");
        }
    }
}
