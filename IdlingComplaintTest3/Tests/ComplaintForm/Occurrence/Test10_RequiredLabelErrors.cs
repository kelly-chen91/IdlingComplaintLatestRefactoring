﻿using IdlingComplaints.Models.ComplaintForm;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumUtilities.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdlingComplaints.Tests.ComplaintForm.Occurrence
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
        public void Occurrence_RequiredDateFrom()
        {
            Occurrence_FromControl.SendTextDeleteTabWithDelay("xxx", 2000);
            string error = Driver.ExtractTextFromXPath("//mat-card[3]/mat-card-content/div[1]/div[1]/div/text()");
            Assert.That(error, Is.EqualTo(Constants.OCCURRENCE_REQUIRED_FROM), "Flagged for inconsistency on purpose.");
        }

        [Test]
        [Category("Required Field Missing - Error Label Displayed")]
        public void Occurrence_RequiredDateTo()
        {
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
            Occurrence_HouseNumControl.SendTextDeleteTabWithDelay("xxx", 2000);
            Assert.That((Object)"", Is.EqualTo(Constants.OCCURRENCE_REQUIRED_HOUSE_NUM), "Flagged for inconsistency on purpose.");
            //string error = Driver.ExtractTextFromXPath("//div[1]/div[2]/div/text()");
            //Assert.That(error, Is.EqualTo(Constants.OCCURRENCE_REQUIRED_FROM));
        }
        [Test]
        [Category("Required Field Missing - Error Label Displayed")]
        public void Occurrence_RequiredBorough()
        {
            Occurrence_SelectBorough(0);
            Assert.That((Object)"", Is.EqualTo(Constants.OCCURRENCE_REQUIRED_BOROUGH), "Flagged for inconsistency on purpose.");
            //string error = Driver.ExtractTextFromXPath("//div[1]/div[2]/div/text()");
            //Assert.That(error, Is.EqualTo(Constants.OCCURRENCE_REQUIRED_FROM));
        }
        
        [Test]
        [Category("Required Field Missing - Error Label Displayed")]
        public void Occurrence_RequiredStreetName()
        {
            Occurrence_StreetNameControl.SendTextDeleteTabWithDelay("xxx", 2000);
            Assert.That((Object)"", Is.EqualTo(Constants.OCCURRENCE_REQUIRED_STREET_NAME), "Flagged for inconsistency on purpose.");
            //string error = Driver.ExtractTextFromXPath("//div[1]/div[2]/div/text()");
            //Assert.That(error, Is.EqualTo(Constants.OCCURRENCE_REQUIRED_FROM));
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
            Occurrence_ToControl.Clear();
            Occurrence_FromControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 27, 2023, 9, 0, 0, false), SLEEP_TIMER); // 6/27/2023, 9:00:00 AM
            string error = Driver.ExtractTextFromXPath("//mat-card[3]/mat-card-content/div[1]/div[1]/div/text()");
            Assert.That(error, Is.EqualTo(string.Empty));
        }

        [Test]
        [Category("Required Field Provided - Error Label Hidden")]
        public void Occurrence_ProvidedTo()
        {
            Occurrence_ToControl.Clear();
            Occurrence_ToControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 27, 2023, 9, 3, 0, false), SLEEP_TIMER); // 6/27/2023, 9:03:00 AM
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

        //[Test]
        //[Category("Required Field Provided - Error Label Hidden")]
        public void Occurrence_ProvidedHouseNumber()
        {
            Occurrence_HouseNumControl.SendKeysWithDelay("XXX", SLEEP_TIMER);
            /*CANNOT TEST FOR REQUIRED FIELD AS IT IS CURRENTLY AN OPTIONAL FIELD*/
        }

        //[Test]
        //[Category("Required Field Provided - Error Label Hidden")]
        public void Occurrence_ProvidedStreetName()
        {
            Occurrence_StreetNameControl.SendKeysWithDelay("XXX", SLEEP_TIMER);
            /*CANNOT TEST FOR REQUIRED FIELD AS IT IS CURRENTLY AN OPTIONAL FIELD*/
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
            Occurrence_FromControl.Clear();
            Occurrence_FromControl.SendKeysWithDelay("XXX", SLEEP_TIMER);
            string error = Driver.ExtractTextFromXPath("//mat-card[3]/mat-card-content/div[1]/div[1]/div/text()");
            Assert.That(error, Is.EqualTo(Constants.OCCURRENCE_REQUIRED_FROM), "Flagged for inconsistency on purpose.");

        }

        [Test]
        [Category("Invalid Input for Field")]
        public void InvalidOccuranceTo()
        {
            Occurrence_FromControl.Clear();
            Occurrence_ToControl.SendKeysWithDelay("XXX", SLEEP_TIMER);
            string error = Driver.ExtractTextFromXPath("//mat-card[3]/mat-card-content/div[1]/div[1]/div/text()");
            Assert.That(error, Is.EqualTo(Constants.OCCURRENCE_REQUIRED_FROM), "Flagged for inconsistency on purpose.");
        }

        public void InvalidHouseNumber()
        {
            /*Program does not verify if the text in the field is a valid House Number.*/
        }
    }
}
