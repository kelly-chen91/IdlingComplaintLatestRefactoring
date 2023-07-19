using IdlingComplaints.Models.ComplaintForm;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V112.Input;
using OpenQA.Selenium.Support.UI;
using SeleniumUtilities.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdlingComplaints.Tests.ComplaintForm.C10_OverallFunctionality
{
    [Parallelizable(ParallelScope.Self)]
    [FixtureLifeCycle(LifeCycle.SingleInstance)]
    internal partial class Test10_Functionality : FillComplaintForm_Base
    {

        BaseExtent extent;

        public Test10_Functionality()
        {
            extent = new BaseExtent();
        }
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            extent.SetUp(false, GetType().Name);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            extent.TearDown(false, Driver);
        }

        [SetUp]
        public void SetUp()
        {
            base.ComplaintFormModelSetUp(true);
            NewComplaintSetUp();
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
            finally
            {
                if (SLEEP_TIMER > 0) { Thread.Sleep(SLEEP_TIMER); }
                base.ComplaintFormModelTearDown();
            }
        }

        [Test]
        [Category("Successful Form Submission")]
        public void SuccessfulFormSubmit_InFrontOf_NoSchool_YesSummonAffidavit()
        {
            /*QUALIFYING CRITERIA*/
            QualifyingCriteria();

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false, false, SLEEP_TIMER);

            Occurrence_ValidDate();

            Fill_OccurrenceAddress(2, 3, false, SLEEP_TIMER);

            Occurrence_VehicleInformation();

            Fill_InFrontOfSchool(false, SLEEP_TIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ComplaintInfo_ClickNext();

            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 60); // loads to next page 

            /*EVIDENCE UPLOAD*/

            Filled_EvidenceUpload();

            /*OATH AFFIDAVIT*/
            
            AppearOATH_ClickYes();
            
            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 30);
            
            AppearOATH_ClickSubmit();

            var successfulSubmit = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 60).FindElement(By.TagName("span"));
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

            Fill_Associated(false, false, SLEEP_TIMER);
           

            Occurrence_ValidDate();

            Fill_OccurrenceAddress(2, 3, false, SLEEP_TIMER);

            Occurrence_VehicleInformation();

            Fill_InFrontOfSchool(false, SLEEP_TIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ComplaintInfo_ClickNext();

            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 60); // loads to next page 

            /*EVIDENCE UPLOAD*/

            Filled_EvidenceUpload();
            /*OATH AFFIDAVIT*/

            Filled_AppearOATH();

            var successfulSubmit = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 60).FindElement(By.TagName("span"));
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

            Fill_Associated(false, false, SLEEP_TIMER);

            Occurrence_ValidDate();

            Fill_OccurrenceAddress(2, 3, false, SLEEP_TIMER);

            Occurrence_VehicleInformation();

            Fill_InFrontOfSchool(false, SLEEP_TIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ComplaintInfo_ClickNext();

            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 60); // loads to next page 

            /*EVIDENCE UPLOAD*/

            Filled_EvidenceUpload();

            /*OATH AFFIDAVIT*/

            AppearOATH_ClickNo();

            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 60);

            AppearOATH_UploadFormInput = FILE_IMAGE_PATH;
            AppearOATH_ClickConfirmUpload();

            var successfulAffidavitUpload = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 10).FindElement(By.TagName("span")); // message says evidence have successfully uploaded

            Assert.IsNotNull(successfulAffidavitUpload);
            string fileName = Path.GetFileName(FILE_IMAGE_PATH);

            if (!successfulAffidavitUpload.Text.Contains("upload")) Assert.That(successfulAffidavitUpload.Text.Trim(), Is.EqualTo("Successfully uploaded file named: " + fileName + "."), "Flagged inconsistency on purpose.");

            Driver.WaitUntilElementIsNoLongerFound(By.TagName("simple-snack-bar"), 15);


            AppearOATH_ClickSubmit();

            var successfulSubmit = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 60).FindElement(By.TagName("span"));
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

            Fill_Associated(false, false, SLEEP_TIMER);

            Occurrence_ValidDate();

            Fill_OccurrenceAddress(2, 3, false, SLEEP_TIMER);

            Occurrence_VehicleInformation();

            Fill_InFrontOfSchool(true, SLEEP_TIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ComplaintInfo_ClickNext();

            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 60); // loads to next page 

            /*EVIDENCE UPLOAD*/

            Filled_EvidenceUpload();
            /*OATH AFFIDAVIT*/

            Filled_AppearOATH();

            var successfulSubmit = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 60).FindElement(By.TagName("span"));
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

            Fill_Associated(false, false, SLEEP_TIMER);

            Occurrence_ValidDate();

            Fill_OccurrenceAddress(1, 4, false, SLEEP_TIMER);

            Occurrence_VehicleInformation();

            Fill_InFrontOfSchool(true, SLEEP_TIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ComplaintInfo_ClickNext();

            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 60); // loads to next page 

            /*EVIDENCE UPLOAD*/

            Filled_EvidenceUpload();
            /*OATH AFFIDAVIT*/

            Filled_AppearOATH();

            var successfulSubmit = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 60).FindElement(By.TagName("span"));
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

            Fill_Associated(false, false, SLEEP_TIMER);

            Occurrence_ValidDate();
            Fill_OccurrenceAddress(3, 4, false, SLEEP_TIMER);

            Occurrence_VehicleInformation();

            Fill_InFrontOfSchool(true, SLEEP_TIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ComplaintInfo_ClickNext();

            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 60); // loads to next page 

            Filled_EvidenceUpload();

            /*OATH AFFIDAVIT*/

            Filled_AppearOATH();

            var successfulSubmit = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 60).FindElement(By.TagName("span"));
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

            Fill_Associated(false, false, SLEEP_TIMER);

            /*OCCURRENCE*/
            Occurrence_FromControl.SendKeysWithDelay(
                StringUtilities.SelectDate(6, 28, 2023, 16, 20, 0), SLEEP_TIMER); // 6/28/2023, 4:20:00 PM

            Occurrence_ToControl.SendKeysWithDelay(
                                StringUtilities.SelectDate(6, 28, 2023, 16, 23, 0), SLEEP_TIMER); // 6/28/2023, 4:23:00 PM

            Fill_OccurrenceAddress(2, 3, false, SLEEP_TIMER);

            Occurrence_SelectVehicleType(2);
            Occurrence_LicensePlateControl.SendKeysWithDelay("DEP1234", SLEEP_TIMER);
            Occurrence_SelectLicenseState(1);
            Occurrence_PastOffenseControl.SendKeysWithDelay("Test", SLEEP_TIMER);
            Occurrence_SecondPastOffenseControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            Fill_InFrontOfSchool(false, SLEEP_TIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ComplaintInfo_ClickNext();

            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 60); // loads to next page 

            Filled_EvidenceUpload();
            /*OATH AFFIDAVIT*/

            AppearOATH_ClickYes();

            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 30);

            AppearOATH_ClickSubmit();

            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 60);

            var duplicateMessage = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20).FindElement(By.TagName("span"));
            Assert.IsNotNull(duplicateMessage);

            //if (!duplicateMessage.Text.Contains("submitted before")) Assert.True(duplicateMessage.Text.Trim().Contains("This Idling Complaint has been submitted before: ")
            //    , "Flagged inconsistency on purpose.");

            string expected = "This idling complaint has been submitted before: ";
            if (!duplicateMessage.Text.Trim().Contains(expected))
            {
                Assert.That(duplicateMessage.Text.Trim().Substring(0, expected.Length),
                    Is.EqualTo(expected), "Flagged inconsistency on purpose.");
            }

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

            Fill_Associated(true, false, SLEEP_TIMER);

            Occurrence_ValidDate();

            Fill_OccurrenceAddress(2, 3, false, SLEEP_TIMER);

            Occurrence_VehicleInformation();

            Fill_InFrontOfSchool(false, SLEEP_TIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ComplaintInfo_ClickNext();

            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 60); // loads to next page 
            
            Filled_EvidenceUpload();
            /*OATH AFFIDAVIT*/

            AppearOATH_ClickYes();

            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 30);

            AppearOATH_ClickSubmit();

            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 60);

            var successfulSubmit = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20).FindElement(By.TagName("span"));
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
       //     Thread.Sleep(SLEEP_TIMER);
       //     
       // }
    }
}
