using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdlingComplaints.Models.ComplaintForm;
using IdlingComplaints.Tests.ComplaintForm.Occurence;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumUtilities.Utils;

namespace IdlingComplaints.Tests.ComplaintForm.Occurance
{
    internal class Label : ComplaintFormModel
    {
        public Label() { }
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
        public void DisplayedOccurenceFrom()
        {
            string label = Driver.FindElement(RelativeBy.WithLocator(By.TagName("label")).Above(OccurenceFromControl)).Text;
            Assert.That(label, Is.EqualTo(Constants.OCCURENCE_FROM));
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedOccurenceTo()
        {
            string label = Driver.FindElement(RelativeBy.WithLocator(By.TagName("label")).Above(OccurenceToControl)).Text;
            Assert.That(label, Is.EqualTo(Constants.OCCURENCE_TO), "Flagged for inconsistency on purpose.");
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedLocation()
        {
            string label = OccurenceLocationControl.GetAttribute("placeholder");
            Assert.That(label, Is.EqualTo(Constants.OCCURENCE_LOCATION));
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedHouseNumber()
        {
            string label = OccurenceHouseNumControl.GetAttribute("placeholder");
            Assert.That(label, Is.EqualTo(Constants.OCCURENCE_HOUSE_NUM));
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedStreetName()
        {
            string label = OccurenceStreetNameControl.GetAttribute("placeholder");
            Assert.That(label, Is.EqualTo(Constants.OCCURENCE_STREET_NAME));
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedState()
        {
            string label = OccurenceStateControl.GetAttribute("placeholder");
            Assert.That(label, Is.EqualTo(Constants.OCCURENCE_STATE));
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedBorough()
        {
            string label = OccurenceBoroughControl.GetAttribute("placeholder");
            Assert.That(label, Is.EqualTo(Constants.OCCURENCE_BOROUGH));
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedVehicleType()
        {
            string label = OccurenceVehicleTypeControl.GetAttribute("placeholder");
            Assert.That(label, Is.EqualTo(Constants.OCCURENCE_VEHICLE_TYPE));
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedLicensePlate()
        {
            string label = OccurenceLicensePlateControl.GetAttribute("placeholder");
            Assert.That(label, Is.EqualTo(Constants.OCCURENCE_LICENSE_PLATE));
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedLicenseState()
        {
            string label = OccurenceLicenseStateControl.GetAttribute("placeholder");
            Assert.That(label, Is.EqualTo(Constants.OCCURENCE_LICENSE_STATE));
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedPastOffense()
        {
            string label = OccurencePastOffenseControl.GetAttribute("placeholder");
            Assert.That(label, Is.EqualTo(Constants.OCCURENCE_PAST_OFFENSE), "Flagged for inconsistency on purpose.");
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedSecondPastOffense()
        {
            string label = OccurenceSecondPastOffenseControl.GetAttribute("placeholder");
            Assert.That(label, Is.EqualTo(Constants.OCCURENCE_SECOND_PAST_OFFENSE), "Flagged for inconsistency on purpose.");
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedInFrontOfSchool()
        {
            string label = OccurenceInFrontOfSchoolControl.GetAttribute("placeholder");
            Assert.That(label, Is.EqualTo(Constants.OCCURENCE_IN_FRONT_OF_SCHOOL), "Flagged for inconsistency on purpose.");
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedAdminCode()
        {
            string label = OccurenceAdminCodeControl.GetAttribute("placeholder");
            Assert.That(label, Is.EqualTo(Constants.OCCURENCE_ADMIN_CODE), "Flagged for inconsistency on purpose.");
        }
    }
}
