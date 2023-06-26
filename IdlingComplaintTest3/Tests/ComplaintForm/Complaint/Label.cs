using IdlingComplaints.Models.ComplaintForm;
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


        [Test, Category("Label Displayed - no spelling/grammar errors.")]
        public void DisplayedHeading()
        {
            string text = Driver.ExtractTextFromXPath("/html/body/app-root/div/idling-complaint/form/div/mat-card[2]/mat-card-header/div/mat-card-title/h4/text()");
                                                        
            Assert.That(text, Is.EqualTo(Constants.COMPLAINT_TITLE));
        }
        [Test, Category("Label Displayed - no spelling/grammar errors.")]
        public void DisplayedCompanyName()
        {
            var text = CompanyNameControl.GetAttribute("placeholder");

            Assert.That(text, Is.EqualTo(Constants.COMPANY_NAME));
        }
        [Test, Category("Label Displayed - no spelling/grammar errors.")]
        public void DisplayedState()
        {
            var text = StateControl.GetAttribute("placeholder");

            Assert.That(text, Is.EqualTo(Constants.STATE));
        }
        [Test, Category("Label Displayed - no spelling/grammar errors.")]
        public void DisplayedHouseNumber()
        {
            var text = HouseNumberControl.GetAttribute("placeholder");

            Assert.That(text, Is.EqualTo(Constants.HOUSENUMBER));
        }
        [Test, Category("Label Displayed - no spelling/grammar errors.")]
        public void DisplayedStreet()
        {
            var text = StreetNameControl.GetAttribute("placeholder");

            Assert.That(text, Is.EqualTo(Constants.STREET_NAME));
        }
        [Test, Category("Label Displayed - no spelling/grammar errors.")]
        public void DisplayedCity()
        {
            var text = CityControl.GetAttribute("placeholder");

            Assert.That(text, Is.EqualTo(Constants.CITY));
        }
        [Test, Category("Label Displayed - no spelling/grammar errors.")]
        public void DisplayedZipCode()
        {
            var text = ZipCodeControl.GetAttribute("placeholder");

            Assert.That(text, Is.EqualTo(Constants.ZIP), "Flagged for inconsistency on purpose. It should be Zip Code");
        }
    }
}
