using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdlingComplaints.Models.ComplaintForm;
using IdlingComplaints.Tests.ComplaintForm.Occurrence;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumUtilities.Utils;

namespace IdlingComplaints.Tests.ComplaintForm.Occurrence
{
    internal class Test10_Label : ComplaintFormModel
    {
        public Test10_Label() { }
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

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedOccurrenceFrom()
        {
            string label = Driver.FindElement(RelativeBy.WithLocator(By.TagName("label")).Above(Occurrence_FromControl)).Text;
            Assert.That(label, Is.EqualTo(Constants.OCCURRENCE_FROM), "Flagged for inconsistency on purpose.");
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedOccurrenceTo()
        {
            string label = Driver.FindElement(RelativeBy.WithLocator(By.TagName("label")).Above(Occurrence_ToControl)).Text;
            Assert.That(label, Is.EqualTo(Constants.OCCURRENCE_TO));
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedLocation()
        {
            string label = Occurrence_LocationControl.GetAttribute("placeholder");
            Assert.That(label, Is.EqualTo(Constants.OCCURRENCE_LOCATION));
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedHouseNumber()
        {
            string label = Occurrence_HouseNumControl.GetAttribute("placeholder");
            Assert.That(label, Is.EqualTo(Constants.OCCURRENCE_HOUSE_NUM));
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedStreetName()
        {
            string label = Occurrence_StreetNameControl.GetAttribute("placeholder");
            Assert.That(label, Is.EqualTo(Constants.OCCURRENCE_STREET_NAME));
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedState()
        {
            string label = Occurrence_StateControl.GetAttribute("placeholder");
            Assert.That(label, Is.EqualTo(Constants.OCCURRENCE_STATE));
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedBorough()
        {
            string label = Occurrence_BoroughControl.GetAttribute("placeholder");
            Assert.That(label, Is.EqualTo(Constants.OCCURRENCE_BOROUGH));
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedVehicleType()
        {
            string label = Occurrence_VehicleTypeControl.GetAttribute("placeholder");
            Assert.That(label, Is.EqualTo(Constants.OCCURRENCE_VEHICLE_TYPE));
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedLicensePlate()
        {
            string label = Occurrence_LicensePlateControl.GetAttribute("placeholder");
            Assert.That(label, Is.EqualTo(Constants.OCCURRENCE_LICENSE_PLATE));
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedLicenseState()
        {
            string label = Occurrence_LicenseStateControl.GetAttribute("placeholder");
            Assert.That(label, Is.EqualTo(Constants.OCCURRENCE_LICENSE_STATE));
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedPastOffense()
        {
            string label = Occurrence_PastOffenseControl.GetAttribute("placeholder");
            Assert.That(label, Is.EqualTo(Constants.OCCURRENCE_PAST_OFFENSE), "Flagged for inconsistency on purpose.");
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedSecondPastOffense()
        {
            string label = Occurrence_SecondPastOffenseControl.GetAttribute("placeholder");
            Assert.That(label, Is.EqualTo(Constants.OCCURRENCE_SECOND_PAST_OFFENSE), "Flagged for inconsistency on purpose.");
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedInFrontOfSchool()
        {
            string label = Occurrence_InFrontOfSchoolControl.GetAttribute("placeholder");
            Assert.That(label, Is.EqualTo(Constants.OCCURRENCE_IN_FRONT_OF_SCHOOL), "Flagged for inconsistency on purpose.");
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedAdminCode()
        {
            string label = Occurrence_AdminCodeControl.GetAttribute("placeholder");
            Assert.That(label, Is.EqualTo(Constants.OCCURRENCE_ADMIN_CODE), "Flagged for inconsistency on purpose.");
        }
    }
}
