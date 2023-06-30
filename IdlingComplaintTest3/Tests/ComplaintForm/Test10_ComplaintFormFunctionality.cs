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
        private readonly string FILE_IMAGE_PATH = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Files\\Images\\idling_truck.jpeg";
        
        [Test]


        public void SuccessfulFormSubmit_InFrontOf_NoSchool_YesSummonAffidavit()
        {
            /*QUALIFYING CRITERIA*/
            ClickNoButton();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false);

            /*OCCURRENCE*/
            Occurrence_FromControl.SendKeysWithDelay(StringUtilities.SelectDate(6,28,2023, 4, 20, 00, true), SLEEPTIMER);
            Occurrence_ToControl.SendKeysWithDelay(StringUtilities.SelectDate(6,28,2023, 4, 23, 00, true), SLEEPTIMER);

            Fill_OccurrenceAddress(2, 3, false);
            
            Occurrence_SelectVehicleType(2);
            Occurrence_LicensePlateControl.SendKeysWithDelay(StringUtilities.GenerateRandomString(7), SLEEPTIMER);
            Occurrence_SelectLicenseState(1);
            Occurrence_PastOffenseControl.SendKeysWithDelay("Test", SLEEPTIMER);
            Occurrence_SecondPastOffenseControl.SendKeysWithDelay("Test", SLEEPTIMER);

            Fill_InFrontOfSchool(false);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEPTIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ClickSubmit();

            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 60); // loads to next page 
            
            /*EVIDENCE UPLOAD*/

            var successfulSave = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20);
            Assert.IsNotNull(successfulSave);
            if (!successfulSave.Text.Contains("saved success")) Assert.That(successfulSave.Text.Trim(), Is.EqualTo("This form has been saved successfully."), "Flagged inconsistency on purpose.");
            Driver.WaitUntilElementIsNoLongerFound(By.TagName("simple-snack-bar"), 20); //message says form is saved

            EvidenceUpload_UploadInput = FILE_IMAGE_PATH;
            string fileName = Path.GetFileName(FILE_IMAGE_PATH);
            EvidenceUpload_ClickFilesUploadConfirm();
            Thread.Sleep(SLEEPTIMER);

            var successfulEvidenceUpload = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20); // message says evidence have successfully uploaded
            Assert.IsNotNull (successfulEvidenceUpload);
            if (!successfulEvidenceUpload.Text.Contains("upload")) Assert.That(successfulEvidenceUpload.Text.Trim(), Is.EqualTo("Successfully uploaded file named: " + fileName + "."), "Flagged inconsistency on purpose.");

            Thread.Sleep(SLEEPTIMER);
            EvidenceUpload_ClickFilesNext();
            Driver.WaitUntilElementFound(By.CssSelector("mat-radio-button[value='753720001']"), 30); //waits until the oath affidavit appears

            /*OATH AFFIDAVIT*/
            
            AppearOATH_ClickYes();
            
            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 30);
            
            AppearOATH_ClickSubmit();
            
            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 60);

            var successfulSubmit = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20);
            if (successfulSubmit != null && !successfulSubmit.Text.Contains("submitted success")) Assert.That(successfulSubmit.Text.Trim(), Is.EqualTo("Complaint has been submitted successfully."), "Flagged inconsistency on purpose.");

        }

        [Test]

        public void SuccessfulFormSubmit_InFrontOf_NoSchool_NoSummonAffidavit_NoAffidavitForm()
        {
            /*QUALIFYING CRITERIA*/
            ClickNoButton();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false);

            /*OCCURRENCE*/
            Occurrence_FromControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2023, 4, 20, 00, true), SLEEPTIMER);
            Occurrence_ToControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2023, 4, 23, 00, true), SLEEPTIMER);

            Fill_OccurrenceAddress(2, 3, false);

            Occurrence_SelectVehicleType(2);
            Occurrence_LicensePlateControl.SendKeysWithDelay(StringUtilities.GenerateRandomString(7), SLEEPTIMER);
            Occurrence_SelectLicenseState(1);
            Occurrence_PastOffenseControl.SendKeysWithDelay("Test", SLEEPTIMER);
            Occurrence_SecondPastOffenseControl.SendKeysWithDelay("Test", SLEEPTIMER);

            Fill_InFrontOfSchool(false);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEPTIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ClickSubmit();

            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 60); // loads to next page 

            /*EVIDENCE UPLOAD*/

            var successfulSave = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20);
            Assert.IsNotNull(successfulSave);
            if (!successfulSave.Text.Contains("saved success")) Assert.That(successfulSave.Text.Trim(), Is.EqualTo("This form has been saved successfully."), "Flagged inconsistency on purpose.");
            Driver.WaitUntilElementIsNoLongerFound(By.TagName("simple-snack-bar"), 20); //message says form is saved

            EvidenceUpload_UploadInput = FILE_IMAGE_PATH;
            string fileName = Path.GetFileName(FILE_IMAGE_PATH);
            EvidenceUpload_ClickFilesUploadConfirm();
            Thread.Sleep(SLEEPTIMER);

            var successfulEvidenceUpload = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20); // message says evidence have successfully uploaded
            Assert.IsNotNull(successfulEvidenceUpload);
            if (!successfulEvidenceUpload.Text.Contains("upload")) Assert.That(successfulEvidenceUpload.Text.Trim(), Is.EqualTo("Successfully uploaded file named: " + fileName + "."), "Flagged inconsistency on purpose.");

            Thread.Sleep(SLEEPTIMER);
            EvidenceUpload_ClickFilesNext();
            Driver.WaitUntilElementFound(By.CssSelector("mat-radio-button[value='753720001']"), 30); //waits until the oath affidavit appears

            /*OATH AFFIDAVIT*/

            AppearOATH_ClickNo();

            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 60);

            AppearOATH_ClickSubmit();

            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 60);

            var successfulSubmit = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20);
            if (successfulSubmit != null && !successfulSubmit.Text.Contains("submitted success")) Assert.That(successfulSubmit.Text.Trim(), Is.EqualTo("Complaint has been submitted successfully."), "Flagged inconsistency on purpose.");

        }
        
        [Test]

        public void SuccessfulFormSubmit_InFrontOf_NoSchool_NoSummonAffidavit_YesAffidavitForm()
        {
            /*QUALIFYING CRITERIA*/
            ClickNoButton();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false);

            /*OCCURRENCE*/
            Occurrence_FromControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2023, 4, 20, 00, true), SLEEPTIMER);
            Occurrence_ToControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2023, 4, 23, 00, true), SLEEPTIMER);

            Fill_OccurrenceAddress(2, 3, false);

            Occurrence_SelectVehicleType(2);
            Occurrence_LicensePlateControl.SendKeysWithDelay(StringUtilities.GenerateRandomString(7), SLEEPTIMER);
            Occurrence_SelectLicenseState(1);
            Occurrence_PastOffenseControl.SendKeysWithDelay("Test", SLEEPTIMER);
            Occurrence_SecondPastOffenseControl.SendKeysWithDelay("Test", SLEEPTIMER);

            Fill_InFrontOfSchool(false);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEPTIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ClickSubmit();

            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 60); // loads to next page 

            /*EVIDENCE UPLOAD*/

            var successfulSave = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20);
            Assert.IsNotNull(successfulSave);
            if (!successfulSave.Text.Contains("saved success")) Assert.That(successfulSave.Text.Trim(), Is.EqualTo("This form has been saved successfully."), "Flagged inconsistency on purpose.");
            Driver.WaitUntilElementIsNoLongerFound(By.TagName("simple-snack-bar"), 20); //message says form is saved

            EvidenceUpload_UploadInput = FILE_IMAGE_PATH;
            string fileName = Path.GetFileName(FILE_IMAGE_PATH);
            EvidenceUpload_ClickFilesUploadConfirm();
            Thread.Sleep(SLEEPTIMER);

            var successfulEvidenceUpload = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20); // message says evidence have successfully uploaded
            Assert.IsNotNull(successfulEvidenceUpload);
            if (!successfulEvidenceUpload.Text.Contains("upload")) Assert.That(successfulEvidenceUpload.Text.Trim(), Is.EqualTo("Successfully uploaded file named: " + fileName + "."), "Flagged inconsistency on purpose.");

            Thread.Sleep(SLEEPTIMER);
            EvidenceUpload_ClickFilesNext();
            Driver.WaitUntilElementFound(By.CssSelector("mat-radio-button[value='753720001']"), 30); //waits until the oath affidavit appears

            /*OATH AFFIDAVIT*/

            AppearOATH_ClickNo();

            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 60);

            AppearOATH_UploadFormInput = FILE_IMAGE_PATH;
            AppearOATH_ClickConfirmUpload();

            var successfulAffidavitUpload = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20); // message says evidence have successfully uploaded
            Assert.IsNotNull(successfulAffidavitUpload);
            if (!successfulAffidavitUpload.Text.Contains("upload")) Assert.That(successfulAffidavitUpload.Text.Trim(), Is.EqualTo("Successfully uploaded file named: " + fileName + "."), "Flagged inconsistency on purpose.");


            AppearOATH_ClickSubmit();

            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 60);

            var successfulSubmit = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20);
            if (successfulSubmit != null && !successfulSubmit.Text.Contains("submitted success")) Assert.That(successfulSubmit.Text.Trim(), Is.EqualTo("Complaint has been submitted successfully."), "Flagged inconsistency on purpose.");

        }

        [Test]

        public void SuccessfulFormSubmit_InFrontOf_YesSchool_NoSummonAffidavit_NoAffidavitForm()
        {
            /*QUALIFYING CRITERIA*/
            ClickNoButton();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false);

            /*OCCURRENCE*/
            Occurrence_FromControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2023, 4, 20, 00, true), SLEEPTIMER);
            Occurrence_ToControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2023, 4, 23, 00, true), SLEEPTIMER);

            Fill_OccurrenceAddress(2, 3, false);

            Occurrence_SelectVehicleType(2);
            Occurrence_LicensePlateControl.SendKeysWithDelay(StringUtilities.GenerateRandomString(7), SLEEPTIMER);
            Occurrence_SelectLicenseState(1);
            Occurrence_PastOffenseControl.SendKeysWithDelay("Test", SLEEPTIMER);
            Occurrence_SecondPastOffenseControl.SendKeysWithDelay("Test", SLEEPTIMER);

            Fill_InFrontOfSchool(true);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEPTIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ClickSubmit();

            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 60); // loads to next page 

            /*EVIDENCE UPLOAD*/

            var successfulSave = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20);
            Assert.IsNotNull(successfulSave);
            if (!successfulSave.Text.Contains("saved success")) Assert.That(successfulSave.Text.Trim(), Is.EqualTo("This form has been saved successfully."), "Flagged inconsistency on purpose.");
            Driver.WaitUntilElementIsNoLongerFound(By.TagName("simple-snack-bar"), 20); //message says form is saved

            EvidenceUpload_UploadInput = FILE_IMAGE_PATH;
            string fileName = Path.GetFileName(FILE_IMAGE_PATH);
            EvidenceUpload_ClickFilesUploadConfirm();
            Thread.Sleep(SLEEPTIMER);

            var successfulEvidenceUpload = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20); // message says evidence have successfully uploaded
            Assert.IsNotNull(successfulEvidenceUpload);
            if (!successfulEvidenceUpload.Text.Contains("upload")) Assert.That(successfulEvidenceUpload.Text.Trim(), Is.EqualTo("Successfully uploaded file named: " + fileName + "."), "Flagged inconsistency on purpose.");

            Thread.Sleep(SLEEPTIMER);
            EvidenceUpload_ClickFilesNext();
            Driver.WaitUntilElementFound(By.CssSelector("mat-radio-button[value='753720001']"), 30); //waits until the oath affidavit appears

            /*OATH AFFIDAVIT*/

            AppearOATH_ClickNo();

            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 60);

            AppearOATH_ClickSubmit();

            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 60);

            var successfulSubmit = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20);
            if (successfulSubmit != null && !successfulSubmit.Text.Contains("submitted success")) Assert.That(successfulSubmit.Text.Trim(), Is.EqualTo("Complaint has been submitted successfully."), "Flagged inconsistency on purpose.");

        }

        [Test]

        public void SuccessfulFormSubmit_Between_YesSchool_NoSummonAffidavit_NoAffidavitForm()
        {
            /*QUALIFYING CRITERIA*/
            ClickNoButton();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false);

            /*OCCURRENCE*/
            Occurrence_FromControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2023, 4, 20, 00, true), SLEEPTIMER);
            Occurrence_ToControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2023, 4, 23, 00, true), SLEEPTIMER);

            Fill_OccurrenceAddress(1, 4, false);

            Occurrence_SelectVehicleType(2);
            Occurrence_LicensePlateControl.SendKeysWithDelay(StringUtilities.GenerateRandomString(7), SLEEPTIMER);
            Occurrence_SelectLicenseState(1);
            Occurrence_PastOffenseControl.SendKeysWithDelay("Test", SLEEPTIMER);
            Occurrence_SecondPastOffenseControl.SendKeysWithDelay("Test", SLEEPTIMER);

            Fill_InFrontOfSchool(true);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEPTIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ClickSubmit();

            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 60); // loads to next page 

            /*EVIDENCE UPLOAD*/

            var successfulSave = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20);
            Assert.IsNotNull(successfulSave);
            if (!successfulSave.Text.Contains("saved success")) Assert.That(successfulSave.Text.Trim(), Is.EqualTo("This form has been saved successfully."), "Flagged inconsistency on purpose.");
            Driver.WaitUntilElementIsNoLongerFound(By.TagName("simple-snack-bar"), 20); //message says form is saved

            EvidenceUpload_UploadInput = FILE_IMAGE_PATH;
            string fileName = Path.GetFileName(FILE_IMAGE_PATH);
            EvidenceUpload_ClickFilesUploadConfirm();
            Thread.Sleep(SLEEPTIMER);

            var successfulEvidenceUpload = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20); // message says evidence have successfully uploaded
            Assert.IsNotNull(successfulEvidenceUpload);
            if (!successfulEvidenceUpload.Text.Contains("upload")) Assert.That(successfulEvidenceUpload.Text.Trim(), Is.EqualTo("Successfully uploaded file named: " + fileName + "."), "Flagged inconsistency on purpose.");

            Thread.Sleep(SLEEPTIMER);
            EvidenceUpload_ClickFilesNext();
            Driver.WaitUntilElementFound(By.CssSelector("mat-radio-button[value='753720001']"), 30); //waits until the oath affidavit appears

            /*OATH AFFIDAVIT*/

            AppearOATH_ClickNo();

            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 60);

            AppearOATH_ClickSubmit();

            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 60);

            var successfulSubmit = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20);
            if (successfulSubmit != null && !successfulSubmit.Text.Contains("submitted success")) Assert.That(successfulSubmit.Text.Trim(), Is.EqualTo("Complaint has been submitted successfully."), "Flagged inconsistency on purpose.");

        }

        [Test]

        public void SuccessfulFormSubmit_Intersection_YesSchool_NoSummonAffidavit_NoAffidavitForm()
        {
            /*QUALIFYING CRITERIA*/
            ClickNoButton();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false);

            /*OCCURRENCE*/
            Occurrence_FromControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2023, 4, 20, 00, true), SLEEPTIMER);
            Occurrence_ToControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2023, 4, 23, 00, true), SLEEPTIMER);

            Fill_OccurrenceAddress(3, 4, false);

            Occurrence_SelectVehicleType(2);
            Occurrence_LicensePlateControl.SendKeysWithDelay(StringUtilities.GenerateRandomString(7), SLEEPTIMER);
            Occurrence_SelectLicenseState(1);
            Occurrence_PastOffenseControl.SendKeysWithDelay("Test", SLEEPTIMER);
            Occurrence_SecondPastOffenseControl.SendKeysWithDelay("Test", SLEEPTIMER);

            Fill_InFrontOfSchool(true);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEPTIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ClickSubmit();

            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 60); // loads to next page 

            /*EVIDENCE UPLOAD*/

            var successfulSave = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20);
            Assert.IsNotNull(successfulSave);
            if (!successfulSave.Text.Contains("saved success")) Assert.That(successfulSave.Text.Trim(), Is.EqualTo("This form has been saved successfully."), "Flagged inconsistency on purpose.");
            Driver.WaitUntilElementIsNoLongerFound(By.TagName("simple-snack-bar"), 20); //message says form is saved

            EvidenceUpload_UploadInput = FILE_IMAGE_PATH;
            string fileName = Path.GetFileName(FILE_IMAGE_PATH);
            EvidenceUpload_ClickFilesUploadConfirm();
            Thread.Sleep(SLEEPTIMER);

            var successfulEvidenceUpload = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20); // message says evidence have successfully uploaded
            Assert.IsNotNull(successfulEvidenceUpload);
            if (!successfulEvidenceUpload.Text.Contains("upload")) Assert.That(successfulEvidenceUpload.Text.Trim(), Is.EqualTo("Successfully uploaded file named: " + fileName + "."), "Flagged inconsistency on purpose.");

            Thread.Sleep(SLEEPTIMER);
            EvidenceUpload_ClickFilesNext();
            Driver.WaitUntilElementFound(By.CssSelector("mat-radio-button[value='753720001']"), 30); //waits until the oath affidavit appears

            /*OATH AFFIDAVIT*/

            AppearOATH_ClickNo();

            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 60);

            AppearOATH_ClickSubmit();

            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 60);

            var successfulSubmit = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20);
            if (successfulSubmit != null && !successfulSubmit.Text.Contains("submitted success")) Assert.That(successfulSubmit.Text.Trim(), Is.EqualTo("Complaint has been submitted successfully."), "Flagged inconsistency on purpose.");

        }

        [Test]

        public void FailedFormSubmit_InFrontOf_NoSchool_YesSummonAffidavit()
        {
            /*QUALIFYING CRITERIA*/
            ClickNoButton();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false);

            /*OCCURRENCE*/
            Occurrence_FromControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2023, 4, 20, 00, true), SLEEPTIMER);
            Occurrence_ToControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2023, 4, 23, 00, true), SLEEPTIMER);

            Fill_OccurrenceAddress(2, 3, false);

            Occurrence_SelectVehicleType(2);
            Occurrence_LicensePlateControl.SendKeysWithDelay("DEP1234", SLEEPTIMER);
            Occurrence_SelectLicenseState(1);
            Occurrence_PastOffenseControl.SendKeysWithDelay("Test", SLEEPTIMER);
            Occurrence_SecondPastOffenseControl.SendKeysWithDelay("Test", SLEEPTIMER);

            Fill_InFrontOfSchool(false);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEPTIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ClickSubmit();

            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 60); // loads to next page 

            /*EVIDENCE UPLOAD*/

            var successfulSave = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20);
            Assert.IsNotNull(successfulSave);
            if (!successfulSave.Text.Contains("saved success")) Assert.That(successfulSave.Text.Trim(), Is.EqualTo("This form has been saved successfully."), "Flagged inconsistency on purpose.");
            Driver.WaitUntilElementIsNoLongerFound(By.TagName("simple-snack-bar"), 20); //message says form is saved

            EvidenceUpload_UploadInput = FILE_IMAGE_PATH;
            string fileName = Path.GetFileName(FILE_IMAGE_PATH);
            EvidenceUpload_ClickFilesUploadConfirm();
            Thread.Sleep(SLEEPTIMER);

            var successfulEvidenceUpload = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20); // message says evidence have successfully uploaded
            Assert.IsNotNull(successfulEvidenceUpload);
            if (!successfulEvidenceUpload.Text.Contains("upload")) Assert.That(successfulEvidenceUpload.Text.Trim(), Is.EqualTo("Successfully uploaded file named: " + fileName + "."), "Flagged inconsistency on purpose.");

            Thread.Sleep(SLEEPTIMER);
            EvidenceUpload_ClickFilesNext();
            Driver.WaitUntilElementFound(By.CssSelector("mat-radio-button[value='753720001']"), 30); //waits until the oath affidavit appears

            /*OATH AFFIDAVIT*/

            AppearOATH_ClickYes();

            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 30);

            AppearOATH_ClickSubmit();

            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 60);

            var failSubmit = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20);
            if (failSubmit != null && !failSubmit.Text.Contains("submitted before")) Assert.True(failSubmit.Text.Trim().Contains("This Idling Complaint has been submitted before: ")
                , "Flagged inconsistency on purpose.");

        }


        public void Fill_Associated(bool isPOBox)
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

        public void Fill_OccurrenceAddress(int location, int borough, bool invalidAddress)
        {
            Assert.That(location, Is.GreaterThan(0));
            Assert.That(location, Is.LessThan(4));
            Assert.That(borough, Is.GreaterThan(0));
            Assert.That(borough, Is.LessThan(6));
            Occurrence_SelectLocation(location);
            Occurrence_SelectBorough(borough);
            string houseNum = "515", streetName = "6th Street";
            string onStreet = "96th Street", crossStreet1 = "55th Ave", crossStreet2 = "57th Ave";
            string intersectCrossStreet1 = "57th Ave", intersectCrossStreet2 = "Junction Blvd";
            if (invalidAddress)
            {
                streetName = "DoWhatever Street";
                onStreet = "WhyDoYouCare Blvd";
                crossStreet1 = onStreet;
                crossStreet2 = "DoesNotMakeSense Expy";
                intersectCrossStreet1 = crossStreet1;
                intersectCrossStreet2 = crossStreet2;
            }
            switch (location)
            {
                case 1:
                    Occurrence_OnStreetControl.SendKeysWithDelay(onStreet, SLEEPTIMER);
                    Occurrence_CrossStreet1Control.SendKeysWithDelay(crossStreet1, SLEEPTIMER);
                    Occurrence_CrossStreet2Control.SendKeysWithDelay(crossStreet2 , SLEEPTIMER);
                    break;
                case 2:
                    Occurrence_HouseNumControl.SendKeysWithDelay(houseNum, SLEEPTIMER);
                    Occurrence_StreetNameControl.SendKeysWithDelay(streetName, SLEEPTIMER);
                    break;
                case 3:
                    Occurrence_CrossStreet1Control.SendKeysWithDelay(intersectCrossStreet1, SLEEPTIMER);
                    Occurrence_CrossStreet2Control.SendKeysWithDelay(intersectCrossStreet2, SLEEPTIMER);
                    break;
            }
        }

        public void Fill_InFrontOfSchool(bool inFrontOfSchool)
        {
            if (inFrontOfSchool)
            {
                Occurrence_SelectInFrontOfSchool(1);
                Occurrence_SchoolNameControl.SendKeysWithDelay("ABC School", SLEEPTIMER);
            }
            else Occurrence_SelectInFrontOfSchool(2);
        }
        

    }
}
