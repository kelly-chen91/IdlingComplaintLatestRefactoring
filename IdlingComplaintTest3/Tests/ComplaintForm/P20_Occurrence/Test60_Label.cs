using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdlingComplaints.Models.ComplaintForm;
using IdlingComplaints.Tests.ComplaintForm.P20_Occurrence;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumUtilities.Utils;

namespace IdlingComplaints.Tests.ComplaintForm.P20_Occurrence
{
    [Parallelizable(ParallelScope.Fixtures)]
    [FixtureLifeCycle(LifeCycle.SingleInstance)]
    internal class Test60_Label : FillComplaintForm_Base
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
            Driver.ScrollTo(Occurrence_VehicleTypeControl);
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(d => d.FindElement(Associated_CompanyNameByControl));
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
        [Category("Placeholder is present.")]
        public void PlaceholderLocation()
        {
            string label = Occurrence_LocationControl.GetAttribute("placeholder");
            Assert.That(label, Is.EqualTo(Constants.OCCURRENCE_LOCATION));
        }

        [Test]
        [Category("Placeholder is present.")]
        public void PlaceholderHouseNumberDefault()
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

            int labelFound = Driver.FindElements(Occurrence_HouseNumByControl).Count;
            Assert.That(labelFound, Is.EqualTo(0));
        }

        [Test]
        [Category("Placeholder is present.")]
        public void PlaceholderHouseNumberInFrontOf()
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

            int labelFound = Driver.FindElements(Occurrence_HouseNumByControl).Count;
            Assert.That(labelFound, Is.EqualTo(0));
        }

        [Test]
        [Category("Placeholder is present.")]
        public void PlaceholderStreetNameDefault()
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

            int labelFound = Driver.FindElements(Occurrence_StreetNameByControl).Count;
            Assert.That(labelFound, Is.EqualTo(0));
        }

        [Test]
        [Category("Placeholder is present.")]
        public void PlaceholderStreetNameInFrontOf()
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

            int labelFound = Driver.FindElements(Occurrence_StreetNameByControl).Count;
            Assert.That(labelFound, Is.EqualTo(0));
        }

        [Test]
        [Category("Label Hidden After Option Selection")]
        public void DisplayedOnStreetDefault()
        {
            Occurrence_SelectLocation(0);

            int labelFound = Driver.FindElements(Occurrence_OnStreetByControl).Count;
            Assert.That(labelFound, Is.EqualTo(0));
        }

        [Test]
        [Category("Placeholder is present.")]
        public void PlaceholderOnStreetBetween()
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

            int labelFound = Driver.FindElements(Occurrence_OnStreetByControl).Count;
            Assert.That(labelFound, Is.EqualTo(0));
        }

        [Test]
        [Category("Label Hidden After Option Selection")]
        public void DisplayedOnStreetIntersection()
        {
            Occurrence_SelectLocation(3);

            int labelFound = Driver.FindElements(Occurrence_OnStreetByControl).Count;
            Assert.That(labelFound, Is.EqualTo(0));
        }

        [Test]
        [Category("Label Hidden After Option Selection")]
        public void DisplayedCrossStreet1Default()
        {
            Occurrence_SelectLocation(0);

            int labelFound = Driver.FindElements(Occurrence_CrossStreet1ByControl).Count;
            Assert.That(labelFound, Is.EqualTo(0));
        }

        [Test]
        [Category("Placeholder is present.")]
        public void PlaceholderCrossStreet1Between()
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

            int labelFound = Driver.FindElements(Occurrence_CrossStreet1ByControl).Count;
            Assert.That(labelFound, Is.EqualTo(0));
        }

        [Test]
        [Category("Placeholder is present.")]
        public void PlaceholderCrossStreet1Intersection()
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

            int labelFound = Driver.FindElements(Occurrence_CrossStreet2ByControl).Count;
            Assert.That(labelFound, Is.EqualTo(0));
        }

        [Test]
        [Category("Placeholder is present.")]
        public void PlaceholderCrossStreet2Between()
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

            int labelFound = Driver.FindElements(Occurrence_CrossStreet2ByControl).Count;
            Assert.That(labelFound, Is.EqualTo(0));
        }

        [Test]
        [Category("Placeholder is present.")]
        public void PlaceholderCrossStreet2Intersection()
        {
            Occurrence_SelectLocation(3);

            string label = Occurrence_CrossStreet2Control.GetAttribute("placeholder");

            Assert.That(label, Is.EqualTo(Constants.OCCURRENCE_CROSS_STREET2));
        }

        [Test]
        [Category("Placeholder is present.")]
        public void PlaceholderState()
        {
            string label = Occurrence_StateControl.GetAttribute("placeholder");
            Assert.That(label, Is.EqualTo(Constants.OCCURRENCE_STATE));
        }

        [Test]
        [Category("Placeholder is present.")]
        public void PlaceholderBorough()
        {
            string label = Occurrence_BoroughControl.GetAttribute("placeholder");
            Assert.That(label, Is.EqualTo(Constants.OCCURRENCE_BOROUGH));
        }

        [Test]
        [Category("Placeholder is present.")]
        public void PlaceholderVehicleType()
        {
            string label = Occurrence_VehicleTypeControl.GetAttribute("placeholder");
            Assert.That(label, Is.EqualTo(Constants.OCCURRENCE_VEHICLE_TYPE));
        }

        [Test]
        [Category("Placeholder is present.")]
        public void PlaceholderLicensePlate()
        {
            string label = Occurrence_LicensePlateControl.GetAttribute("placeholder");
            Assert.That(label, Is.EqualTo(Constants.OCCURRENCE_LICENSE_PLATE));
        }

        [Test]
        [Category("Placeholder is present.")]
        public void PlaceholderLicenseState()
        {
            string label = Occurrence_LicenseStateControl.GetAttribute("placeholder");
            Assert.That(label, Is.EqualTo(Constants.OCCURRENCE_LICENSE_STATE));
        }

        [Test]
        [Category("Placeholder is present.")]
        public void PlaceholderPastOffense()
        {
            string label = Occurrence_PastOffenseControl.GetAttribute("placeholder");
            Assert.That(label, Is.EqualTo(Constants.OCCURRENCE_PAST_OFFENSE), "Flagged for inconsistency on purpose.");
        }

        [Test]
        [Category("Placeholder is present.")]
        public void PlaceholderSecondPastOffense()
        {
            string label = Occurrence_SecondPastOffenseControl.GetAttribute("placeholder");
            Assert.That(label, Is.EqualTo(Constants.OCCURRENCE_SECOND_PAST_OFFENSE), "Flagged for inconsistency on purpose.");
        }

        [Test]
        [Category("Placeholder is present.")]
        public void PlaceholderInFrontOfSchool()
        {
            string label = Occurrence_InFrontOfSchoolControl.GetAttribute("placeholder");
            Assert.That(label, Is.EqualTo(Constants.OCCURRENCE_IN_FRONT_OF_SCHOOL), "Flagged for inconsistency on purpose.");
        }
        [Test]
        [Category("Label Hidden After Option Selection")]
        public void DisplayedSchoolNameDefault()
        {
            Occurrence_SelectInFrontOfSchool(0);

            int labelFound = Driver.FindElements(Occurrence_SchoolNameByControl).Count;
            Assert.That(labelFound, Is.EqualTo(0));
        }

        [Test]
        [Category("Placeholder is present.")]
        public void PlaceholderSchoolNameInFrontOfSchool()
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

            int labelFound = Driver.FindElements(Occurrence_SchoolNameByControl).Count;
            Assert.That(labelFound, Is.EqualTo(0));
        }


        [Test]
        [Category("Placeholder is present.")]
        public void PlaceholderAdminCode()
        {
            string label = Occurrence_AdminCodeControl.GetAttribute("placeholder");
            Assert.That(label, Is.EqualTo(Constants.OCCURRENCE_ADMIN_CODE), "Flagged for inconsistency on purpose.");
        }
    }
}
