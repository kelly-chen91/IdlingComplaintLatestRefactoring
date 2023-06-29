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
    internal class Test60_Label : ComplaintFormModel
    {
        public Test60_Label() { }
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            base.ComplaintFormModelSetUp(true);
            ClickNoButton();
            Driver.ScrollTo(Occurrence_VehicleTypeControl);
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(d => d.FindElement(By.CssSelector("input[formcontrolname='idc_associatedlastname']")));
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            base.ComplaintFormModelTearDown();
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
        public void DisplayedHouseNumberDefault()
        {
            Occurrence_SelectLocation(0);

            string label = Occurrence_HouseNumControl.GetAttribute("placeholder");
            Assert.That(label, Is.EqualTo(Constants.OCCURRENCE_HOUSE_NUM));
        }

        [Test]
        [Category("Label Hidden After Option Selection")]
        public void DisplayedHouseNumberBetween()
        {
            Occurrence_SelectLocation(1);

            //string label = Occurrence_SchoolNameControl.GetAttribute("placeholder");
            int labelFound = Driver.FindElements(By.CssSelector("input[formcontrolname='idc_occurrencehouseno']")).Count;
            Assert.That(labelFound, Is.EqualTo(0));
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedHouseNumberInFrontOf()
        {
            Occurrence_SelectLocation(2);

            string label = Occurrence_HouseNumControl.GetAttribute("placeholder");
            Assert.That(label, Is.EqualTo(Constants.OCCURRENCE_HOUSE_NUM));
        }

        [Test]
        [Category("Label Hidden After Option Selection")]
        public void DisplayedHouseNumberIntersection()
        {
            Occurrence_SelectLocation(3);

            //string label = Occurrence_SchoolNameControl.GetAttribute("placeholder");
            int labelFound = Driver.FindElements(By.CssSelector("input[formcontrolname='idc_occurrencehouseno']")).Count;
            Assert.That(labelFound, Is.EqualTo(0));
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedStreetNameDefault()
        {
            Occurrence_SelectLocation(0);

            string label = Occurrence_StreetNameControl.GetAttribute("placeholder");
            Assert.That(label, Is.EqualTo(Constants.OCCURRENCE_STREET_NAME));
        }

        [Test]
        [Category("Label Hidden After Option Selection")]
        public void DisplayedStreetNameBetween()
        {
            Occurrence_SelectLocation(1);

            //string label = Occurrence_SchoolNameControl.GetAttribute("placeholder");
            int labelFound = Driver.FindElements(By.CssSelector("input[formcontrolname='idc_occurrencestreet']")).Count;
            Assert.That(labelFound, Is.EqualTo(0));
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedStreetNameInFrontOf()
        {
            Occurrence_SelectLocation(2);

            string label = Occurrence_StreetNameControl.GetAttribute("placeholder");
            Assert.That(label, Is.EqualTo(Constants.OCCURRENCE_STREET_NAME));
        }

        [Test]
        [Category("Label Hidden After Option Selection")]
        public void DisplayedStreetNameIntersection()
        {
            Occurrence_SelectLocation(3);

            //string label = Occurrence_SchoolNameControl.GetAttribute("placeholder");
            int labelFound = Driver.FindElements(By.CssSelector("input[formcontrolname='idc_occurrencestreet']")).Count;
            Assert.That(labelFound, Is.EqualTo(0));
        }

        [Test]
        [Category("Label Hidden After Option Selection")]
        public void DisplayedOnStreetDefault()
        {
            Occurrence_SelectLocation(0);

            //string label = Occurrence_SchoolNameControl.GetAttribute("placeholder");
            int labelFound = Driver.FindElements(By.CssSelector("input[formcontrolname='idc_onstreet']")).Count;
            Assert.That(labelFound, Is.EqualTo(0));
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedOnStreetBetween()
        {
            Occurrence_SelectLocation(1);

            string label = Occurrence_OnStreetControl.GetAttribute("placeholder");

            Assert.That(label, Is.EqualTo(Constants.OCCURRENCE_ON_STREET));
        }

        [Test]
        [Category("Label Hidden After Option Selection")]
        public void DisplayedOnStreetInFrontOf()
        {
            Occurrence_SelectLocation(2);

            //string label = Occurrence_SchoolNameControl.GetAttribute("placeholder");
            int labelFound = Driver.FindElements(By.CssSelector("input[formcontrolname='idc_onstreet']")).Count;
            Assert.That(labelFound, Is.EqualTo(0));
        }

        [Test]
        [Category("Label Hidden After Option Selection")]
        public void DisplayedOnStreetIntersection()
        {
            Occurrence_SelectLocation(3);

            //string label = Occurrence_SchoolNameControl.GetAttribute("placeholder");
            int labelFound = Driver.FindElements(By.CssSelector("input[formcontrolname='idc_onstreet']")).Count;
            Assert.That(labelFound, Is.EqualTo(0));
        }

        [Test]
        [Category("Label Hidden After Option Selection")]
        public void DisplayedCrossStreet1Default()
        {
            Occurrence_SelectLocation(0);

            //string label = Occurrence_SchoolNameControl.GetAttribute("placeholder");
            int labelFound = Driver.FindElements(By.CssSelector("input[formcontrolname='idc_crossstreet1']")).Count;
            Assert.That(labelFound, Is.EqualTo(0));
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedCrossStreet1Between()
        {
            Occurrence_SelectLocation(1);

            string label = Occurrence_CrossStreet1Control.GetAttribute("placeholder");

            Assert.That(label, Is.EqualTo(Constants.OCCURRENCE_CROSS_STREET1));
        }

        [Test]
        [Category("Label Hidden After Option Selection")]
        public void DisplayedCrossStreet1InFrontOf()
        {
            Occurrence_SelectLocation(2);

            //string label = Occurrence_SchoolNameControl.GetAttribute("placeholder");
            int labelFound = Driver.FindElements(By.CssSelector("input[formcontrolname='idc_crossstreet1']")).Count;
            Assert.That(labelFound, Is.EqualTo(0));
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedCrossStreet1Intersection()
        {
            Occurrence_SelectLocation(3);

            string label = Occurrence_CrossStreet1Control.GetAttribute("placeholder");

            Assert.That(label, Is.EqualTo(Constants.OCCURRENCE_CROSS_STREET1));
        }

        [Test]
        [Category("Label Hidden After Option Selection")]
        public void DisplayedCrossStreet2Default()
        {
            Occurrence_SelectLocation(0);

            //string label = Occurrence_SchoolNameControl.GetAttribute("placeholder");
            int labelFound = Driver.FindElements(By.CssSelector("input[formcontrolname='idc_crossstreet2']")).Count;
            Assert.That(labelFound, Is.EqualTo(0));
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedCrossStreet2Between()
        {
            Occurrence_SelectLocation(1);

            string label = Occurrence_CrossStreet2Control.GetAttribute("placeholder");

            Assert.That(label, Is.EqualTo(Constants.OCCURRENCE_CROSS_STREET2));
        }

        [Test]
        [Category("Label Hidden After Option Selection")]
        public void DisplayedCrossStreet2InFrontOf()
        {
            Occurrence_SelectLocation(2);

            //string label = Occurrence_SchoolNameControl.GetAttribute("placeholder");
            int labelFound = Driver.FindElements(By.CssSelector("input[formcontrolname='idc_crossstreet2']")).Count;
            Assert.That(labelFound, Is.EqualTo(0));
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedCrossStreet2Intersection()
        {
            Occurrence_SelectLocation(3);

            string label = Occurrence_CrossStreet2Control.GetAttribute("placeholder");

            Assert.That(label, Is.EqualTo(Constants.OCCURRENCE_CROSS_STREET2));
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
        [Category("Label Hidden After Option Selection")]
        public void DisplayedSchoolNameDefault()
        {
            Occurrence_SelectInFrontOfSchool(0);

            //string label = Occurrence_SchoolNameControl.GetAttribute("placeholder");
            int labelFound = Driver.FindElements(By.CssSelector("input[formcontrolname='idc_schoolname']")).Count;
            Assert.That(labelFound, Is.EqualTo(0));
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedSchoolNameInFrontOfSchool()
        {
            Occurrence_SelectInFrontOfSchool(1); //yes

            string label = Occurrence_SchoolNameControl.GetAttribute("placeholder");
            Assert.That(label, Is.EqualTo(Constants.OCCURRENCE_SCHOOL_NAME), "Flagged for inconsistency on purpose.");
        }

        [Test]
        [Category("Label Hidden After Option Selection")]
        public void DisplayedSchoolNameNotInFrontOfSchool()
        {
            Occurrence_SelectInFrontOfSchool(2);

            //string label = Occurrence_SchoolNameControl.GetAttribute("placeholder");
            int labelFound = Driver.FindElements(By.CssSelector("input[formcontrolname='idc_schoolname']")).Count;
            Assert.That(labelFound, Is.EqualTo(0));
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
