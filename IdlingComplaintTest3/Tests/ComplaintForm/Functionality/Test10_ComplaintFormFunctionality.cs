using IdlingComplaints.Models.ComplaintForm;
using IdlingComplaints.Tests.ComplaintForm.Functionality;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V112.Input;
using OpenQA.Selenium.Support.UI;
using SeleniumUtilities.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdlingComplaints.Tests.ComplaintForm
{
    internal partial class Test10_ComplaintFormFunctionality : FillComplaintForm_Base
    {
        [SetUp]
        public void SetUp()
        {
            base.ComplaintFormModelSetUp(false);

        }

        [TearDown]
        public void TearDown()
        {
            if (SLEEPTIMER > 0) { Thread.Sleep(SLEEPTIMER); }
            base.ComplaintFormModelTearDown();
        }

        [Test]
        [Category("Successful Form Submission")]
        public void SuccessfulFormSubmit_InFrontOf_NoSchool_YesSummonAffidavit()
        {
            /*QUALIFYING CRITERIA*/
            QualifyingCriteria();

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false, false, SLEEPTIMER);

            Occurrence_ValidDate();

            Fill_OccurrenceAddress(2, 3, false, SLEEPTIMER);

            Occurrence_VehicleInformation();

            Fill_InFrontOfSchool(false, SLEEPTIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEPTIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ComplaintInfo_ClickNext();

            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 60); // loads to next page 

            /*EVIDENCE UPLOAD*/

            //var successfulSave = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20);
            //Assert.IsNotNull(successfulSave);
            //if (!successfulSave.Text.Contains("saved success")) Assert.That(successfulSave.Text.Trim(), Is.EqualTo("This form has been saved successfully."), "Flagged inconsistency on purpose.");
            //Driver.WaitUntilElementIsNoLongerFound(By.TagName("simple-snack-bar"), 20); //message says form is saved
            //
            //EvidenceUpload_UploadInput = FILE_IMAGE_PATH;
            //string fileName = Path.GetFileName(FILE_IMAGE_PATH);
            //EvidenceUpload_ClickFilesUploadConfirm();
            //Thread.Sleep(SLEEPTIMER);
            //
            //var successfulEvidenceUpload = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20); // message says evidence have successfully uploaded
            //Assert.IsNotNull (successfulEvidenceUpload);
            //if (!successfulEvidenceUpload.Text.Contains("upload")) Assert.That(successfulEvidenceUpload.Text.Trim(), 
            //    Is.EqualTo("Successfully uploaded file named: " + fileName + "."), "Flagged inconsistency on purpose.");
            //
            //Thread.Sleep(SLEEPTIMER);
            //EvidenceUpload_ClickNext();
            //Driver.WaitUntilElementFound(By.CssSelector("mat-radio-button[value='753720001']"), 30); //waits until the oath affidavit appears

            Filled_EvidenceUpload();
            /*OATH AFFIDAVIT*/
            
            AppearOATH_ClickYes();
            
            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 30);
            
            AppearOATH_ClickSubmit();

            var successfulSubmit = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 60);
            if (successfulSubmit != null && !successfulSubmit.Text.Contains("submitted success")) Assert.That(successfulSubmit.Text.Trim(), Is.EqualTo("Complaint has been submitted successfully."), "Flagged inconsistency on purpose.");

            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 60);
        }

        [Test]
        [Category("Successful Form Submission")]

        public void SuccessfulFormSubmit_InFrontOf_NoSchool_NoSummonAffidavit_NoAffidavitForm()
        {
            /*QUALIFYING CRITERIA*/
            ClickNo();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false, false, SLEEPTIMER);
           

            Occurrence_ValidDate();

            Fill_OccurrenceAddress(2, 3, false, SLEEPTIMER);

            Occurrence_VehicleInformation();

            Fill_InFrontOfSchool(false, SLEEPTIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEPTIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ComplaintInfo_ClickNext();

            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 60); // loads to next page 

            /*EVIDENCE UPLOAD*/

            Filled_EvidenceUpload();
            /*OATH AFFIDAVIT*/

            Filled_AppearOATH();

            var successfulSubmit = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 60);
            if (successfulSubmit != null && !successfulSubmit.Text.Contains("submitted success")) Assert.That(successfulSubmit.Text.Trim(), Is.EqualTo("Complaint has been submitted successfully."), "Flagged inconsistency on purpose.");

            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 60);
        }
        
        [Test]
        [Category("Successful Form Submission")]

        public void SuccessfulFormSubmit_InFrontOf_NoSchool_NoSummonAffidavit_YesAffidavitForm()
        {
            /*QUALIFYING CRITERIA*/
            ClickNo();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false, false, SLEEPTIMER);

            Occurrence_ValidDate();

            Fill_OccurrenceAddress(2, 3, false, SLEEPTIMER);

            Occurrence_VehicleInformation();

            Fill_InFrontOfSchool(false, SLEEPTIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEPTIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ComplaintInfo_ClickNext();

            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 60); // loads to next page 

            /*EVIDENCE UPLOAD*/

            var successfulSave = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20);
            Assert.IsNotNull(successfulSave);
            if (!successfulSave.Text.Contains("saved success")) Assert.That(successfulSave.Text.Trim(), Is.EqualTo("This form has been saved successfully."), "Flagged inconsistency on purpose.");
            Driver.WaitUntilElementIsNoLongerFound(By.TagName("simple-snack-bar"), 20); //message says form is saved

            EvidenceUpload_UploadControl.SendKeysWithDelay(FILE_IMAGE_PATH, 1000);
            string fileName = Path.GetFileName(FILE_IMAGE_PATH);
            EvidenceUpload_ClickFilesUploadConfirm();

            Driver.WaitUntilElementIsNoLongerFound(By.XPath("//app-upload/mat-card/mat-card-content/div/div[2]/div[2]/button[2]"), 10);
            var successfulEvidenceUpload = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20); // message says evidence have successfully uploaded
            Assert.IsNotNull(successfulEvidenceUpload);
            if (!successfulEvidenceUpload.Text.Contains("upload")) Assert.That(successfulEvidenceUpload.Text.Trim(), Is.EqualTo("Successfully uploaded file named: " + fileName + "."), "Flagged inconsistency on purpose.");

            //Thread.Sleep(SLEEPTIMER);
            EvidenceUpload_ClickNext();
            Driver.WaitUntilElementFound(By.CssSelector("mat-radio-button[value='753720001']"), 30); //waits until the oath affidavit appears

            /*OATH AFFIDAVIT*/

            AppearOATH_ClickNo();

            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 60);

            AppearOATH_UploadFormInput = FILE_IMAGE_PATH;
            AppearOATH_ClickConfirmUpload();

            var successfulAffidavitUpload = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 10); // message says evidence have successfully uploaded

            Assert.IsNotNull(successfulAffidavitUpload);
            if (!successfulAffidavitUpload.Text.Contains("upload")) Assert.That(successfulAffidavitUpload.Text.Trim(), Is.EqualTo("Successfully uploaded file named: " + fileName + "."), "Flagged inconsistency on purpose.");

            Driver.WaitUntilElementIsNoLongerFound(By.TagName("simple-snack-bar"), 15);


            AppearOATH_ClickSubmit();

            var successfulSubmit = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 60);
            if (successfulSubmit != null && !successfulSubmit.Text.Contains("submitted success")) Assert.That(successfulSubmit.Text.Trim(), Is.EqualTo("Complaint has been submitted successfully."), "Flagged inconsistency on purpose.");

            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 60);
        }

        [Test]
        [Category("Successful Form Submission")]

        public void SuccessfulFormSubmit_InFrontOf_YesSchool_NoSummonAffidavit_NoAffidavitForm()
        {
            /*QUALIFYING CRITERIA*/
            ClickNo();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false, false, SLEEPTIMER);

            Occurrence_ValidDate();

            Fill_OccurrenceAddress(2, 3, false, SLEEPTIMER);

            Occurrence_VehicleInformation();

            Fill_InFrontOfSchool(true, SLEEPTIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEPTIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ComplaintInfo_ClickNext();

            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 60); // loads to next page 

            /*EVIDENCE UPLOAD*/

            var successfulSave = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20);
            Assert.IsNotNull(successfulSave);
            if (!successfulSave.Text.Contains("saved success")) Assert.That(successfulSave.Text.Trim(), Is.EqualTo("This form has been saved successfully."), "Flagged inconsistency on purpose.");
            Driver.WaitUntilElementIsNoLongerFound(By.TagName("simple-snack-bar"), 20); //message says form is saved

            EvidenceUpload_UploadInput = FILE_IMAGE_PATH;
            string fileName = Path.GetFileName(FILE_IMAGE_PATH);
            EvidenceUpload_ClickFilesUploadConfirm();
            //Thread.Sleep(SLEEPTIMER);

            var successfulEvidenceUpload = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20); // message says evidence have successfully uploaded
            Assert.IsNotNull(successfulEvidenceUpload);
            if (!successfulEvidenceUpload.Text.Contains("upload")) Assert.That(successfulEvidenceUpload.Text.Trim(), Is.EqualTo("Successfully uploaded file named: " + fileName + "."), "Flagged inconsistency on purpose.");

            Driver.WaitUntilElementIsNoLongerFound(By.TagName("simple-snack-bar"), 10);
            EvidenceUpload_ClickNext();
            Driver.WaitUntilElementFound(By.CssSelector("mat-radio-button[value='753720001']"), 30); //waits until the oath affidavit appears

            /*OATH AFFIDAVIT*/

            Filled_AppearOATH();

            var successfulSubmit = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 60);
            if (successfulSubmit != null && !successfulSubmit.Text.Contains("submitted success")) Assert.That(successfulSubmit.Text.Trim(), Is.EqualTo("Complaint has been submitted successfully."), "Flagged inconsistency on purpose.");

            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 60);
        }

        [Test]
        [Category("Successful Form Submission")]

        public void SuccessfulFormSubmit_Between_YesSchool_NoSummonAffidavit_NoAffidavitForm()
        {
            /*QUALIFYING CRITERIA*/
            ClickNo();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false, false, SLEEPTIMER);

            Occurrence_ValidDate();

            Fill_OccurrenceAddress(1, 4, false, SLEEPTIMER);

            Occurrence_VehicleInformation();

            Fill_InFrontOfSchool(true, SLEEPTIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEPTIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ComplaintInfo_ClickNext();

            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 60); // loads to next page 

            /*EVIDENCE UPLOAD*/

            var successfulSave = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20);
            Assert.IsNotNull(successfulSave);
            if (!successfulSave.Text.Contains("saved success")) Assert.That(successfulSave.Text.Trim(), Is.EqualTo("This form has been saved successfully."), "Flagged inconsistency on purpose.");
            Driver.WaitUntilElementIsNoLongerFound(By.TagName("simple-snack-bar"), 20); //message says form is saved

            EvidenceUpload_UploadInput = FILE_IMAGE_PATH;
            string fileName = Path.GetFileName(FILE_IMAGE_PATH);
            EvidenceUpload_ClickFilesUploadConfirm();
            //Thread.Sleep(SLEEPTIMER);

            var successfulEvidenceUpload = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20); // message says evidence have successfully uploaded
            Assert.IsNotNull(successfulEvidenceUpload);
            if (!successfulEvidenceUpload.Text.Contains("upload")) Assert.That(successfulEvidenceUpload.Text.Trim(), Is.EqualTo("Successfully uploaded file named: " + fileName + "."), "Flagged inconsistency on purpose.");
            Driver.WaitUntilElementIsNoLongerFound(By.TagName("simple-snack-bar"), 10);
            //Thread.Sleep(SLEEPTIMER);
            EvidenceUpload_ClickNext();
            Driver.WaitUntilElementFound(By.CssSelector("mat-radio-button[value='753720001']"), 30); //waits until the oath affidavit appears

            /*OATH AFFIDAVIT*/

            Filled_AppearOATH();

            var successfulSubmit = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 60);
            if (successfulSubmit != null && !successfulSubmit.Text.Contains("submitted success")) Assert.That(successfulSubmit.Text.Trim(), Is.EqualTo("Complaint has been submitted successfully."), "Flagged inconsistency on purpose.");

            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 60);
        }

        [Test]
        [Category("Successful Form Submission")]

        public void SuccessfulFormSubmit_Intersection_YesSchool_NoSummonAffidavit_NoAffidavitForm()
        {
            /*QUALIFYING CRITERIA*/
            ClickNo();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false, false, SLEEPTIMER);

            Occurrence_ValidDate();
            Fill_OccurrenceAddress(3, 4, false, SLEEPTIMER);

            Occurrence_VehicleInformation();

            Fill_InFrontOfSchool(true, SLEEPTIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEPTIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ComplaintInfo_ClickNext();

            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 60); // loads to next page 

            Filled_EvidenceUpload();

            /*OATH AFFIDAVIT*/

            Filled_AppearOATH();

            var successfulSubmit = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 60);
            if (successfulSubmit != null && !successfulSubmit.Text.Contains("submitted success")) Assert.That(successfulSubmit.Text.Trim(), Is.EqualTo("Complaint has been submitted successfully."), "Flagged inconsistency on purpose.");

            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 60);

           
        }

        [Test]
        [Category("Failed Form Submission")]

        public void DuplicateFormSubmit_InFrontOf_NoSchool_YesSummonAffidavit()
        {
            /*QUALIFYING CRITERIA*/
            ClickNo();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false, false, SLEEPTIMER);

            Occurrence_ValidDate();

            Fill_OccurrenceAddress(2, 3, false, SLEEPTIMER);

            Occurrence_SelectVehicleType(2);
            Occurrence_LicensePlateControl.SendKeysWithDelay("DEP1234", SLEEPTIMER);
            Occurrence_SelectLicenseState(1);
            Occurrence_PastOffenseControl.SendKeysWithDelay("Test", SLEEPTIMER);
            Occurrence_SecondPastOffenseControl.SendKeysWithDelay("Test", SLEEPTIMER);

            Fill_InFrontOfSchool(false, SLEEPTIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEPTIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ComplaintInfo_ClickNext();

            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 60); // loads to next page 

            /*EVIDENCE UPLOAD*/

            //var successfulSave = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20);
            //Assert.IsNotNull(successfulSave);
            //if (!successfulSave.Text.Contains("saved success")) Assert.That(successfulSave.Text.Trim(), Is.EqualTo("This form has been saved successfully."), "Flagged inconsistency on purpose.");
            //Driver.WaitUntilElementIsNoLongerFound(By.TagName("simple-snack-bar"), 20); //message says form is saved
            //
            //EvidenceUpload_UploadInput = FILE_IMAGE_PATH;
            //string fileName = Path.GetFileName(FILE_IMAGE_PATH);
            //EvidenceUpload_ClickFilesUploadConfirm();
            //Thread.Sleep(SLEEPTIMER);
            //
            //var successfulEvidenceUpload = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20); // message says evidence have successfully uploaded
            //Assert.IsNotNull(successfulEvidenceUpload);
            //if (!successfulEvidenceUpload.Text.Contains("upload")) Assert.That(successfulEvidenceUpload.Text.Trim(), Is.EqualTo("Successfully uploaded file named: " + fileName + "."), "Flagged inconsistency on purpose.");
            //
            //Thread.Sleep(SLEEPTIMER);
            //EvidenceUpload_ClickNext();
            //Driver.WaitUntilElementFound(By.CssSelector("mat-radio-button[value='753720001']"), 30); //waits until the oath affidavit appears
            Filled_EvidenceUpload();
            /*OATH AFFIDAVIT*/

            AppearOATH_ClickYes();

            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 30);

            AppearOATH_ClickSubmit();

            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 60);

            var failSubmit = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20);
            if (failSubmit != null && !failSubmit.Text.Contains("submitted before")) Assert.True(failSubmit.Text.Trim().Contains("This Idling Complaint has been submitted before: ")
                , "Flagged inconsistency on purpose.");

        }


        /*TO-DO: PO Box Checkbox is not working, need to investigate*/
        [Test]
        [Category("Successful Form Submission")]

        public void SuccessfulFormSubmit_YesPOBox_InFrontOf_NoSchool_YesSummonAffidavit()
        {
            /*QUALIFYING CRITERIA*/
            ClickNo();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(true, false, SLEEPTIMER);

            Occurrence_ValidDate();

            Fill_OccurrenceAddress(2, 3, false, SLEEPTIMER);

            Occurrence_VehicleInformation();

            Fill_InFrontOfSchool(false, SLEEPTIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEPTIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ComplaintInfo_ClickNext();

            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 60); // loads to next page 

            /*EVIDENCE UPLOAD*/

            //var successfulSave = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20);
            //Assert.IsNotNull(successfulSave);
            //Console.WriteLine(successfulSave.Text);
            //if (!successfulSave.Text.Contains("saved success")) Assert.That(successfulSave.Text.Trim(), Is.EqualTo("This form has been saved successfully."), "Flagged inconsistency on purpose.");
            //Driver.WaitUntilElementIsNoLongerFound(By.TagName("simple-snack-bar"), 20); //message says form is saved
            //
            //EvidenceUpload_UploadInput = FILE_IMAGE_PATH;
            //string fileName = Path.GetFileName(FILE_IMAGE_PATH);
            //EvidenceUpload_ClickFilesUploadConfirm();
            //Thread.Sleep(SLEEPTIMER);
            //
            //var successfulEvidenceUpload = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20); // message says evidence have successfully uploaded
            //Assert.IsNotNull(successfulEvidenceUpload);
            //if (!successfulEvidenceUpload.Text.Contains("upload")) Assert.That(successfulEvidenceUpload.Text.Trim(),
            //    Is.EqualTo("Successfully uploaded file named: " + fileName + "."), "Flagged inconsistency on purpose.");
            //
            //Thread.Sleep(SLEEPTIMER);
            //EvidenceUpload_ClickNext();
            //Driver.WaitUntilElementFound(By.CssSelector("mat-radio-button[value='753720001']"), 30); //waits until the oath affidavit appears
            Filled_EvidenceUpload();
            /*OATH AFFIDAVIT*/

            AppearOATH_ClickYes();

            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 30);

            AppearOATH_ClickSubmit();

            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 60);

            var successfulSubmit = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20);
            if (successfulSubmit != null && !successfulSubmit.Text.Contains("submitted success")) Assert.That(successfulSubmit.Text.Trim(), Is.EqualTo("Complaint has been submitted successfully."), "Flagged inconsistency on purpose.");

        }


       // [Test]
       // [Category("Successful Form Submission")]
       // public void TestPOBox()
       // {
       //     ClickNo();
       //     Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);
       //
       //     /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
       //     ScrollToZipCode();
       //     Associated_POBoxControl.SendKeysWithDelay(" ", 5000);
       //     Thread.Sleep(SLEEPTIMER);
       //     
       // }
    }
}
