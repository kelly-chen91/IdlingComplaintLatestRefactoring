using IdlingComplaints.Models.ComplaintForm;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumUtilities.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdlingComplaints.Tests.ComplaintForm.Occurence
{
    internal class Test10_RequiredLabelErrors : ComplaintFormModel
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

        private readonly int SLEEP_TIMER = 2000;
        
        [Test]
        [Category("Required Field Missing - Error Label Displayed")]
        public void Occurance_RequiredDateFrom()
        {
            Occurance_FromControl.SendTextDeleteTabWithDelay("xxx", 2000);
            string error = Driver.ExtractTextFromXPath("//mat-card[3]/mat-card-content/div[1]/div[1]/div/text()");
            Assert.That(error, Is.EqualTo(Constants.OCCURENCE_REQUIRED_FROM));
        }

        [Test]
        [Category("Required Field Missing - Error Label Displayed")]
        public void Occurance_RequiredDateTo()
        {
            Occurance_ToControl.SendTextDeleteTabWithDelay("xxx", 2000);
            string error = Driver.ExtractTextFromXPath("//mat-card[3]/mat-card-content/div[1]/div[2]/div/text()");
            Assert.That(error, Is.EqualTo(Constants.OCCURENCE_REQUIRED_TO));
        }

        [Test]
        [Category("Required Field Missing - Error Label Displayed")]
        public void Occurance_RequiredHouseNumber()
        {
            Occurance_HouseNumControl.SendTextDeleteTabWithDelay("xxx", 2000);
            Assert.That((Object)"", Is.EqualTo(Constants.OCCURENCE_REQUIRED_HOUSE_NUM), "Flagged for inconsistency on purpose.");
            //string error = Driver.ExtractTextFromXPath("//div[1]/div[2]/div/text()");
            //Assert.That(error, Is.EqualTo(Constants.OCCURENCE_REQUIRED_FROM));
        }
        [Test]
        [Category("Required Field Missing - Error Label Displayed")]
        public void Occurance_RequiredBorough()
        {
            Occurance_BoroughControl.SendTextDeleteTabWithDelay("xxx", 2000);
            Assert.That((Object)"", Is.EqualTo(Constants.OCCURENCE_REQUIRED_BOROUGH), "Flagged for inconsistency on purpose.");
            //string error = Driver.ExtractTextFromXPath("//div[1]/div[2]/div/text()");
            //Assert.That(error, Is.EqualTo(Constants.OCCURENCE_REQUIRED_FROM));
        }
        
        [Test]
        [Category("Required Field Missing - Error Label Displayed")]
        public void Occurance_RequiredStreetName()
        {
            Occurance_StreetNameControl.SendTextDeleteTabWithDelay("xxx", 2000);
            Assert.That((Object)"", Is.EqualTo(Constants.OCCURENCE_REQUIRED_STREET_NAME), "Flagged for inconsistency on purpose.");
            //string error = Driver.ExtractTextFromXPath("//div[1]/div[2]/div/text()");
            //Assert.That(error, Is.EqualTo(Constants.OCCURENCE_REQUIRED_FROM));
        }

        [Test]
        [Category("Required Field Missing - Error Label Displayed")]
        public void Occurance_RequiredVehicleType()
        {
            Occurance_VehicleTypeControl.SendTextDeleteTabWithDelay("xxx", 2000);
            string error = Driver.ExtractTextFromXPath("//div[5]/mat-form-field/div/div[3]/div/mat-error/text()");
            Assert.That(error, Is.EqualTo(Constants.OCCURENCE_REQUIRED_VEHICLE_TYPE));
        }

        [Test]
        [Category("Required Field Missing - Error Label Displayed")]
        public void Occurance_RequiredLicensePlate()
        {
            Occurance_LicensePlateControl.SendTextDeleteTabWithDelay("xxx", 2000);
            string error = Driver.ExtractTextFromXPath("//div[6]/mat-form-field[1]/div/div[3]/div/mat-error/text()");
            Assert.That(error, Is.EqualTo(Constants.OCCURENCE_REQUIRED_LICENSE_PLATE));
        }

        [Test]
        [Category("Required Field Missing - Error Label Displayed")]
        public void Occurance_RequiredLicenseState()
        {
            Occurance_LicenseStateControl.SendTextDeleteTabWithDelay("xxx", 2000);
            string error = Driver.ExtractTextFromXPath("//div[6]/mat-form-field[2]/div/div[3]/div/mat-error/text()");
            Assert.That(error, Is.EqualTo(Constants.OCCURENCE_REQUIRED_LICENSE_STATE));
        }

        [Test]
        [Category("Required Field Missing - Error Label Displayed")]
        public void Occurance_RequiredInFrontOfSchool()
        {
            Occurance_InFrontOfSchoolControl.SendTextDeleteTabWithDelay("xxx", 2000);
            string error = Driver.ExtractTextFromXPath("//div[8]/mat-form-field[1]/div/div[3]/div/mat-error/text()");
            Assert.That(error, Is.EqualTo(Constants.OCCURENCE_REQUIRED_IN_FRONT_OF_SCHOOL), "Flagged for inconsistency on purpose.");
        }
    }
}
