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
    internal class Test10_ComplaintFormFunctionality : ComplaintFormModel
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
        private readonly string FILE_IMAGE_PATH = "C:\\Users\\kchen\\Pictures\\idling_truck.jpeg";
        [Test]
        public void SuccessfulDirectToNextPageInFrontOfNoSchoolAndSummonAFfidavit()
        {
            ClickNoButton();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);
            ScrollToZipCode();

            FillAssociatedSection(false);

            Occurrence_FromControl.SendKeysWithDelay(StringUtilities.SelectDate(6,28,2023, 4, 20, 00, true), SLEEPTIMER);
            Occurrence_ToControl.SendKeysWithDelay(StringUtilities.SelectDate(6,28,2023, 4, 23, 00, true), SLEEPTIMER);
            Occurrence_SelectLocation(2); //In front of
            Occurrence_HouseNumControl.SendKeysWithDelay("515", SLEEPTIMER);
            Occurrence_StreetNameControl.SendKeysWithDelay("6th Street", SLEEPTIMER);
            Occurrence_SelectBorough(2);
            Occurrence_SelectVehicleType(2);
            Occurrence_LicensePlateControl.SendKeysWithDelay(StringUtilities.GenerateRandomString(7), SLEEPTIMER);
            Occurrence_SelectLicenseState(1);
            Occurrence_PastOffenseControl.SendKeysWithDelay("Test", SLEEPTIMER);
            Occurrence_SecondPastOffenseControl.SendKeysWithDelay("Test", SLEEPTIMER);
            Occurrence_SelectInFrontOfSchool(2);
            Describe_ContentControl.SendKeysWithDelay("Test", SLEEPTIMER);
            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ClickSubmit();

            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 60);
            
            var successfulSave = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20);
            if (successfulSave != null && !successfulSave.Text.Contains("saved success")) Assert.That(successfulSave.Text.Trim(), Is.EqualTo("This form has been saved successfully."), "Flagged inconsistency on purpose.");
            Driver.WaitUntilElementIsNoLongerFound(By.TagName("simple-snack-bar"), 20);
            EvidenceUpload_UploadInput = FILE_IMAGE_PATH;
            string fileName = Path.GetFileName(FILE_IMAGE_PATH);
            EvidenceUpload_ClickFilesUploadConfirm();
            Thread.Sleep(SLEEPTIMER);

            var successfulEvidenceUpload = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20);
            if (successfulEvidenceUpload != null && !successfulEvidenceUpload.Text.Contains("upload")) Assert.That(successfulEvidenceUpload.Text.Trim(), Is.EqualTo("Successfully uploaded file named: " + fileName + "."), "Flagged inconsistency on purpose.");

            Thread.Sleep(SLEEPTIMER);
            EvidenceUpload_ClickFilesNext();
            Driver.WaitUntilElementFound(By.CssSelector("mat-radio-button[value='753720001']"), 30);
            
            AppearOATH_ClickYes();
            
            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 30);
            
            AppearOATH_ClickSubmit();
            
            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 60);

            var successfulSubmit = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20);
            if (successfulSubmit != null && !successfulSubmit.Text.Contains("submitted success")) Assert.That(successfulSubmit.Text.Trim(), Is.EqualTo("Complaint has been submitted successfully."), "Flagged inconsistency on purpose.");

        }

        public void FillAssociatedSection(bool isPOBox)
        {
            Associated_CompanyNameControl.SendKeysWithDelay("Test INC", SLEEPTIMER);
            Associated_SelectState(1);
            if (!isPOBox) Associated_HouseNumberControl.SendKeysWithDelay("98", SLEEPTIMER);
            else Associated_ClickPOBox();
            Associated_StreetNameControl.SendKeysWithDelay("Mott Street", SLEEPTIMER);
            Associated_AptFloorControl.SendKeysWithDelay("4th Fl", SLEEPTIMER);
            Associated_CityControl.SendKeysWithDelay("New York", SLEEPTIMER);
            Associated_ZipCodeControl.SendKeysWithDelay("10013", SLEEPTIMER);
        }

        

    }
}
