using IdlingComplaints.Models.ComplaintForm;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumUtilities.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdlingComplaints.Tests.ComplaintForm.P20_Occurrence
{
    [Parallelizable(ParallelScope.Fixtures)]
    [FixtureLifeCycle(LifeCycle.SingleInstance)]
    internal class Test30_RequiredLabelErrors : ComplaintFormModel
    {

        BaseExtent extent;

        public Test30_RequiredLabelErrors()
        {
            extent = new BaseExtent();
        }
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            extent.SetUp(false, GetType().Name);

            base.ComplaintFormModelSetUp(true);
            NewComplaintSetUp();
            ClickNo();
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(d => d.FindElement(By.CssSelector("input[formcontrolname='idc_associatedlastname']")));
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            extent.TearDown(false, Driver);
            if (SLEEP_TIMER > 0)
                Thread.Sleep(SLEEP_TIMER);
            base.ComplaintFormModelTearDown();
        }

        [SetUp]
        public void SetUp()
        {
            //base.ComplaintFormModelSetUp(true);
            //NewComplaintSetUp();
            //ClickNo();
            //var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            //wait.Until(d => d.FindElement(By.CssSelector("input[formcontrolname='idc_associatedlastname']")));

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
            //finally
            //{
            //    if (SLEEP_TIMER > 0)
            //        Thread.Sleep(SLEEP_TIMER);
            //    base.ComplaintFormModelTearDown();
            //}
        }


        private readonly int SLEEP_TIMER = 0;
        
        [Test]
        [Category("Required Field Missing - Error Label Displayed")]
        public void Occurrence_RequiredDateFrom()
        {
            Occurrence_FromControl.DeleteText(Occurrence_FromInput);
            Occurrence_FromControl.SendTextDeleteTabWithDelay("xxx", 2000);
            string error = Driver.ExtractTextFromXPath("//mat-card[3]/mat-card-content/div[1]/div[1]/div/text()");
            Assert.That(error, Is.EqualTo(Constants.OCCURRENCE_REQUIRED_FROM), "Flagged for inconsistency on purpose.");
        }

        [Test]
        [Category("Required Field Missing - Error Label Displayed")]
        public void Occurrence_RequiredDateTo()
        {
            Occurrence_ToControl.DeleteText(Occurrence_ToInput);

            Occurrence_ToControl.SendTextDeleteTabWithDelay("xxx", 2000);
            string error = Driver.ExtractTextFromXPath("//mat-card[3]/mat-card-content/div[1]/div[2]/div/text()");
            Assert.That(error, Is.EqualTo(Constants.OCCURRENCE_REQUIRED_TO), "Flagged for inconsistency on purpose.");
        }

        [Test]
        [Category("Required Field Missing - Error Label Displayed")]
        public void Occurrence_RequiredLocation()
        {
            Occurrence_SelectLocation(0);
            string error = Driver.ExtractTextFromXPath("//div[2]/mat-form-field/div/div[3]/div/mat-error/text()");
            Assert.That(error, Is.EqualTo(Constants.OCCURRENCE_REQUIRED_LOCATION));
        }


        [Test]
        [Category("Required Field Missing - Error Label Displayed")]
        public void Occurrence_RequiredHouseNumber()
        {
            Occurrence_SelectLocation(2);
            Occurrence_HouseNumControl.SendTextDeleteTabWithDelay("xxx", 2000);
            string error = Driver.ExtractTextFromXPath("//div[3]/mat-form-field[1]/div/div[3]/div/mat-error/text()");
            Assert.That(error, Is.EqualTo(Constants.OCCURRENCE_REQUIRED_HOUSE_NUM));
            
        }
        
        [Test]
        [Category("Required Field Missing - Error Label Displayed")]
        public void Occurrence_RequiredStreetName()
        {
            Occurrence_SelectLocation(2);
            Occurrence_StreetNameControl.DeleteText(Occurrence_StreetInput);
            Occurrence_StreetNameControl.SendTextDeleteTabWithDelay("xxx", 2000);
            string error = Driver.ExtractTextFromXPath("//div[3]/mat-form-field[2]/div/div[3]/div/mat-error/text()");

            Assert.That(error, Is.EqualTo(Constants.OCCURRENCE_REQUIRED_STREET_NAME), "Flagged for inconsistency on purpose.");
            
        }

        [Test]
        [Category("Required Field Missing - Error Label Displayed")]
        public void Occurrence_RequiredOnStreetBetween()
        {
            Occurrence_SelectLocation(1);
            Occurrence_OnStreetControl.SendTextDeleteTabWithDelay("xxx", 2000);
            string error = Driver.ExtractTextFromXPath("//div[2]/mat-form-field[2]/div/div[3]/div/mat-error/text()");
            Assert.That(error, Is.EqualTo(Constants.OCCURRENCE_REQUIRED_ON_STREET));
            //string error = Driver.ExtractTextFromXPath("//div[1]/div[2]/div/text()");
            //Assert.That(error, Is.EqualTo(Constants.OCCURRENCE_REQUIRED_FROM));
        }

        [Test]
        [Category("Required Field Missing - Error Label Displayed")]
        public void Occurrence_RequiredCrossStreet1Between()
        {
            Occurrence_SelectLocation(1);
            Occurrence_CrossStreet1Control.SendTextDeleteTabWithDelay("xxx", 2000);
            string error = Driver.ExtractTextFromXPath("//div[3]/mat-form-field[1]/div/div[3]/div/mat-error/text()");
            Assert.That(error, Is.EqualTo(Constants.OCCURRENCE_REQUIRED_CROSS_STREET1));
            //string error = Driver.ExtractTextFromXPath("//div[1]/div[2]/div/text()");
            //Assert.That(error, Is.EqualTo(Constants.OCCURRENCE_REQUIRED_FROM));
        }

        [Test]
        [Category("Required Field Missing - Error Label Displayed")]
        public void Occurrence_RequiredCrossStreet2Between()
        {
            Occurrence_SelectLocation(1);
            Occurrence_CrossStreet2Control.SendTextDeleteTabWithDelay("xxx", 2000);
            string error = Driver.ExtractTextFromXPath("//div[3]/mat-form-field[2]/div/div[3]/div/mat-error/text()");
            Assert.That(error, Is.EqualTo(Constants.OCCURRENCE_REQUIRED_CROSS_STREET2));
            //string error = Driver.ExtractTextFromXPath("//div[1]/div[2]/div/text()");
            //Assert.That(error, Is.EqualTo(Constants.OCCURRENCE_REQUIRED_FROM));
        }

        [Test]
        [Category("Required Field Missing - Error Label Displayed")]
        public void Occurrence_RequiredCrossStreet1Intersection()
        {
            Occurrence_SelectLocation(3);
            Occurrence_CrossStreet1Control.SendTextDeleteTabWithDelay("xxx", 2000);
            string error = Driver.ExtractTextFromXPath("//div[3]/mat-form-field[1]/div/div[3]/div/mat-error/text()");
            Assert.That(error, Is.EqualTo(Constants.OCCURRENCE_REQUIRED_CROSS_STREET1));
            
            //string error = Driver.ExtractTextFromXPath("//div[1]/div[2]/div/text()");
            //Assert.That(error, Is.EqualTo(Constants.OCCURRENCE_REQUIRED_FROM));
        }

        [Test]
        [Category("Required Field Missing - Error Label Displayed")]
        public void Occurrence_RequiredCrossStreet2Intersection()
        {
            Occurrence_SelectLocation(3);
            Occurrence_CrossStreet2Control.SendTextDeleteTabWithDelay("xxx", 2000);
            string error = Driver.ExtractTextFromXPath("//div[3]/mat-form-field[2]/div/div[3]/div/mat-error/text()");
            Assert.That(error, Is.EqualTo(Constants.OCCURRENCE_REQUIRED_CROSS_STREET2));
            //string error = Driver.ExtractTextFromXPath("//div[1]/div[2]/div/text()");
            //Assert.That(error, Is.EqualTo(Constants.OCCURRENCE_REQUIRED_FROM));
        }

        [Test]
        [Category("Required Field Missing - Error Label Displayed")]
        public void Occurrence_RequiredBorough()
        {
            /*Borough is currently not required*/
            Occurrence_SelectLocation(2);
            Occurrence_SelectBorough(0);
            Assert.That((Object)"", Is.EqualTo(Constants.OCCURRENCE_REQUIRED_BOROUGH), "Flagged for inconsistency on purpose.");
        }

        [Test]
        [Category("Required Field Missing - Error Label Displayed")]
        public void Occurrence_RequiredVehicleType()
        {
            Occurrence_SelectVehicleType(0);
            string error = Driver.ExtractTextFromXPath("//div[5]/mat-form-field/div/div[3]/div/mat-error/text()");
            Assert.That(error, Is.EqualTo(Constants.OCCURRENCE_REQUIRED_VEHICLE_TYPE));
        }

        [Test]
        [Category("Required Field Missing - Error Label Displayed")]
        public void Occurrence_RequiredLicensePlate()
        {
            Occurrence_LicensePlateControl.Clear();
            Occurrence_LicensePlateControl.SendTextDeleteTabWithDelay("xxx", 2000);
            string error = Driver.ExtractTextFromXPath("//div[6]/mat-form-field[1]/div/div[3]/div/mat-error/text()");
            Assert.That(error, Is.EqualTo(Constants.OCCURRENCE_REQUIRED_LICENSE_PLATE));
        }

        [Test]
        [Category("Required Field Missing - Error Label Displayed")]
        public void Occurrence_RequiredLicenseState()
        {
            Occurrence_SelectLicenseState(0);
            string error = Driver.ExtractTextFromXPath("//div[6]/mat-form-field[2]/div/div[3]/div/mat-error/text()");
            Assert.That(error, Is.EqualTo(Constants.OCCURRENCE_REQUIRED_LICENSE_STATE));
        }

        [Test]
        [Category("Required Field Missing - Error Label Displayed")]
        public void Occurrence_RequiredInFrontOfSchool()
        {
            Occurrence_SelectInFrontOfSchool(0);
            string error = Driver.ExtractTextFromXPath("//div[8]/mat-form-field[1]/div/div[3]/div/mat-error/text()");
            Assert.That(error, Is.EqualTo(Constants.OCCURRENCE_REQUIRED_IN_FRONT_OF_SCHOOL), "Flagged for inconsistency on purpose.");
        }

        [Test]
        [Category("Required Field Provided - Error Label Hidden")]
        public void Occurrence_ProvidedFrom()
        {
            Occurrence_FromControl.DeleteText(Occurrence_FromInput);
            
            Occurrence_FromControl.SendKeysWithDelay(
                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.AddMinutes(-3).Minute, DateTime.Now.Second), SLEEP_TIMER); // Current Time (3 minutes ago)
            string error = Driver.ExtractTextFromXPath("//mat-card[3]/mat-card-content/div[1]/div[1]/div/text()");
            Assert.That(error, Is.EqualTo(string.Empty));
        }

        [Test]
        [Category("Required Field Provided - Error Label Hidden")]
        public void Occurrence_ProvidedTo()
        {
            Occurrence_ToControl.DeleteText(Occurrence_FromInput);
            Occurrence_ToControl.SendKeysWithDelay(
                                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second), SLEEP_TIMER); // Current Time

            string error = Driver.ExtractTextFromXPath("//mat-card[3]/mat-card-content/div[1]/div[2]/div/text()");
            Assert.That(error, Is.EqualTo(string.Empty));
        }

        [Test]
        [Category("Required Field Provided - Error Label Hidden")]
        public void Occurrence_ProvidedLocation()
        {
            Occurrence_SelectLocation(1);
            string error = Driver.ExtractTextFromXPath("//div[2]/mat-form-field/div/div[3]/div/mat-error/text()");
            Assert.That(error, Is.EqualTo(string.Empty));
        }

        [Test]
        [Category("Required Field Provided - Error Label Hidden")]
        public void Occurrence_ProvidedHouseNumberInFrontOf()
        {
            Occurrence_SelectLocation(2);
            Occurrence_HouseNumControl.SendKeysWithDelay("XXX", SLEEP_TIMER);
            string error = Driver.ExtractTextFromXPath("//div[3]/mat-form-field[1]/div/div[3]/div/mat-error/text()");
            Assert.That(error, Is.EqualTo(string.Empty));
        }

        [Test]
        [Category("Required Field Provided - Error Label Hidden")]
        public void Occurrence_ProvidedStreetNameInFrontOf()
        {
            Occurrence_SelectLocation(2);
            Occurrence_StreetNameControl.DeleteText(Occurrence_StreetInput);
            Occurrence_StreetNameControl.SendKeysWithDelay("XXX", SLEEP_TIMER);
            string error = Driver.ExtractTextFromXPath("//div[3]/mat-form-field[2]/div/div[3]/div/mat-error/text()");
            Assert.That(error, Is.EqualTo(string.Empty));
        }

        [Test]
        [Category("Required Field Provided - Error Label Hidden")]
        public void Occurrence_ProvidedOnStreetBetween()
        {
            Occurrence_SelectLocation(1);
            Occurrence_OnStreetControl.DeleteText(Occurrence_OnStreetInput);
            Occurrence_OnStreetControl.SendKeysWithDelay("XXX", SLEEP_TIMER);
            string error = Driver.ExtractTextFromXPath("//div[2]/mat-form-field[2]/div/div[3]/div/mat-error/text()");
            Assert.That(error, Is.EqualTo(string.Empty));
        }

        [Test]
        [Category("Required Field Provided - Error Label Hidden")]
        public void Occurrence_ProvidedCrossStreet1Between()
        {
            Occurrence_SelectLocation(1);
            Occurrence_CrossStreet1Control.DeleteText(Occurrence_CrossStreet1Input);
            Occurrence_CrossStreet1Control.SendKeysWithDelay("XXX", SLEEP_TIMER);
            string error = Driver.ExtractTextFromXPath("//div[3]/mat-form-field[1]/div/div[3]/div/mat-error/text()");
            Assert.That(error, Is.EqualTo(string.Empty));
        }

        [Test]
        [Category("Required Field Provided - Error Label Hidden")]
        public void Occurrence_ProvidedCrossStreet2Between()
        {
            Occurrence_SelectLocation(1);
            Occurrence_CrossStreet2Control.DeleteText(Occurrence_CrossStreet2Input);
            Occurrence_CrossStreet2Control.SendKeysWithDelay("XXX", SLEEP_TIMER);
            string error = Driver.ExtractTextFromXPath("//div[3]/mat-form-field[2]/div/div[3]/div/mat-error/text()");
            Assert.That(error, Is.EqualTo(string.Empty));
        }

        [Test]
        [Category("Required Field Provided - Error Label Hidden")]
        public void Occurrence_ProvidedCrossStreet1Intersection()
        {
            Occurrence_SelectLocation(1);
            Occurrence_CrossStreet1Control.DeleteText(Occurrence_CrossStreet1Input);
            Occurrence_CrossStreet1Control.SendKeysWithDelay("XXX", SLEEP_TIMER);
            string error = Driver.ExtractTextFromXPath("//div[3]/mat-form-field[1]/div/div[3]/div/mat-error/text()");
            Assert.That(error, Is.EqualTo(string.Empty));
        }

        [Test]
        [Category("Required Field Provided - Error Label Hidden")]
        public void Occurrence_ProvidedCrossStreet2Intersection()
        {
            Occurrence_SelectLocation(1);
            Occurrence_CrossStreet2Control.DeleteText(Occurrence_CrossStreet2Input);
            Occurrence_CrossStreet2Control.SendKeysWithDelay("XXX", SLEEP_TIMER);
            string error = Driver.ExtractTextFromXPath("//div[3]/mat-form-field[2]/div/div[3]/div/mat-error/text()");
            Assert.That(error, Is.EqualTo(string.Empty));
        }

        //[Test]
        //[Category("Required Field Provided - Error Label Hidden")]
        public void Occurrence_ProvidedBorough()
        {
            Occurrence_SelectBorough(1);
            /*CANNOT TEST FOR REQUIRED FIELD AS IT IS CURRENTLY AN OPTIONAL FIELD*/
        }

        [Test]
        [Category("Required Field Provided - Error Label Hidden")]
        public void Occurrence_ProvidedVehicleType()
        {
            Occurrence_SelectVehicleType(1);
            string error = Driver.ExtractTextFromXPath("//div[5]/mat-form-field/div/div[3]/div/mat-error/text()");
            Assert.That(error, Is.EqualTo(string.Empty));
        }

        [Test]
        [Category("Required Field Provided - Error Label Hidden")]
        public void Occurrence_ProvidedLicensePlate()
        {
            Occurrence_LicensePlateControl.SendKeysWithDelay("XXX", SLEEP_TIMER);
            string error = Driver.ExtractTextFromXPath("//div[6]/mat-form-field[1]/div/div[3]/div/mat-error/text()");
            Assert.That(error, Is.EqualTo(string.Empty));
        }

        [Test]
        [Category("Required Field Provided - Error Label Hidden")]
        public void Occurrence_ProvidedLicenseState()
        {
            Occurrence_SelectLicenseState(1);
            string error = Driver.ExtractTextFromXPath("//div[6]/mat-form-field[2]/div/div[3]/div/mat-error/text()");
            Assert.That(error, Is.EqualTo(string.Empty));
        }

        [Test]
        [Category("Required Field Provided - Error Label Hidden")]
        public void Occurrence_ProvidedInFrontOfSchool()
        {
            Occurrence_SelectInFrontOfSchool(1);
            string error = Driver.ExtractTextFromXPath("//div[8]/mat-form-field[1]/div/div[3]/div/mat-error/text()");
            Assert.That(error, Is.EqualTo(string.Empty));
        }

        [Test]
        [Category("Invalid Input for Field")]
        public void InvalidOccuranceFrom()
        {
            Occurrence_FromControl.DeleteText(Occurrence_FromInput);
            Occurrence_FromControl.SendKeysWithDelay("XXX", SLEEP_TIMER);
            Occurrence_FromControl.SendKeysWithDelay(Keys.Tab, SLEEP_TIMER);
            string error = Driver.ExtractTextFromXPath("//mat-card[3]/mat-card-content/div[1]/div[1]/div/text()");
            Assert.That(error, Is.EqualTo(Constants.OCCURRENCE_REQUIRED_FROM), "Flagged for inconsistency on purpose.");

        }

        [Test]
        [Category("Invalid Input for Field")]
        public void InvalidOccuranceTo()
        {
            Occurrence_ToControl.DeleteText(Occurrence_FromInput);
            Occurrence_ToControl.SendKeysWithDelay("XXX", SLEEP_TIMER);
            Occurrence_FromControl.SendKeysWithDelay(Keys.Tab, SLEEP_TIMER);

            string error = Driver.ExtractTextFromXPath("//mat-card[3]/mat-card-content/div[1]/div[2]/div/text()");
            Assert.That(error, Is.EqualTo(Constants.OCCURRENCE_REQUIRED_TO), "Flagged for inconsistency on purpose.");
        }

        public void InvalidHouseNumber()
        {
            /*Program does not verify if the text in the field is a valid House Number.*/
        }
    }
}
