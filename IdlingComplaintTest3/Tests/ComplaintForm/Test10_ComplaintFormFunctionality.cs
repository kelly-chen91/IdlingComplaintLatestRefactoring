using IdlingComplaints.Models.ComplaintForm;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumUtilities.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdlingComplaints.Tests.ComplaintForm
{
    internal class ComplaintFormFunctionality : ComplaintFormModel
    {

        [SetUp]
        public void SetUp()
        {
            base.ComplaintFormModelSetUp(false);

        }

        [TearDown]
        public void TearDown()
        {
            if(SLEEPTIMER > 0) { Thread.Sleep(SLEEPTIMER); }
            base.ComplaintFormModelTearDown();
        }

        private readonly int SLEEPTIMER = 1000;

        [Test]
        public void SuccessfulDirectToNextPageNotInFrontOfSchool()
        {
            ClickNoButton();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);
            ScrollToZipCode();
            Associated_CompanyNameControl.SendKeysWithDelay("Test INC", SLEEPTIMER);
            Associated_SelectState(1);
            Associated_HouseNumberControl.SendKeysWithDelay("98", SLEEPTIMER);
            Associated_StreetNameControl.SendKeysWithDelay("Mott Street", SLEEPTIMER);
            Associated_AptFloorControl.SendKeysWithDelay("4th Fl", SLEEPTIMER);
            Associated_CityControl.SendKeysWithDelay("New York", SLEEPTIMER);
            Associated_ZipCodeControl.SendKeysWithDelay("10013", SLEEPTIMER);

            Occurrence_FromControl.SendKeysWithDelay(StringUtilities.SelectDate(6,28,2023, 4, 20, 00, true), SLEEPTIMER);
            Occurrence_ToControl.SendKeysWithDelay(StringUtilities.SelectDate(6,28,2023, 4, 23, 00, true), SLEEPTIMER);
            Occurrence_SelectLocation(2); //In front of
            Occurrence_HouseNumControl.SendKeysWithDelay("515", SLEEPTIMER);
            Occurrence_StreetNameControl.SendKeysWithDelay("6th Street", SLEEPTIMER);
            Occurrence_SelectBorough(2);
            Occurrence_SelectVehicleType(2);
            Occurrence_LicensePlateControl.SendKeysWithDelay("DEP1234", SLEEPTIMER);
            Occurrence_SelectLicenseState(1);
            Occurrence_PastOffenseControl.SendKeysWithDelay("Test", SLEEPTIMER);
            Occurrence_SecondPastOffenseControl.SendKeysWithDelay("Test", SLEEPTIMER);
            Occurrence_SelectInFrontOfSchool(2);
            DescribeTheComplaintControl.SendKeysWithDelay("Test", SLEEPTIMER);
            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ClickNext();
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10)); //1 - too short
            wait.Until(d =>
            {
                var resultControl = d.FindElement(By.TagName("simple-snack-bar")).FindElement(By.TagName("span"));

                Assert.IsNotNull(resultControl);
                Assert.That(resultControl.Text.Trim(), Is.EqualTo("Form has been saved successfully."));

                return resultControl;
            });
            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 20);

            
        }

    }
}
