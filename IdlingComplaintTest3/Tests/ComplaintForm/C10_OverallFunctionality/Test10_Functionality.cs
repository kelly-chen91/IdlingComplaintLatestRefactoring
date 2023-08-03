using IdlingComplaints.Models.ComplaintForm;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V112.Input;
using OpenQA.Selenium.Support.UI;
using SeleniumUtilities.BaseSetUp;
using SeleniumUtilities.Utils.TestUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: Parallelizable(ParallelScope.Fixtures)]
[assembly: FixtureLifeCycle(LifeCycle.SingleInstance)]

namespace IdlingComplaints.Tests.ComplaintForm.C10_OverallFunctionality
{
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
            extent.SetUp(false, GetType().Namespace + "." + GetType().Name);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            extent.TearDown(false, Driver);
        }

        [SetUp]
        public void SetUp()
        {
            base.ComplaintFormModelSetUp(true, false);
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

            SubmitAcknowledgementAndProceedToNextPage();

            /*EVIDENCE UPLOAD*/

            string openComplaintNumber = Filled_EvidenceUpload();

            /*OATH AFFIDAVIT*/

            AppearOATH_ClickYes();
            
            Driver.WaitUntilElementIsNoLongerFound(SpinnerByControl, 30);
            
            AppearOATH_ClickSubmit();

            var successfulSubmit = Driver.WaitUntilElementFound(SnackBarByControl, 60).FindElement(By.TagName("span"));
            Assert.IsNotNull(successfulSubmit);
            if (!successfulSubmit.Text.Contains(Constants.PARTIAL_SUCCESSFUL_FORM_SUBMISSION)) Assert.That(successfulSubmit.Text.Trim(), Is.EqualTo(Constants.SUCCESSFUL_FORM_SUBMISSION), "Flagged inconsistency on purpose.");
            else
            {
                string[] inputs = { GetEmail(), GetPassword(), openComplaintNumber, Constants.SUCCESS_STATUS };
                submission_tracker.WriteIntoFile(inputs);
            }
            Driver.WaitUntilElementIsNoLongerFound(SpinnerByControl, 60);
        }

        [Test]
        [Category("Successful Form Submission")]

        public void SuccessfulFormSubmit_InFrontOf_NoSchool_NoSummonAffidavit_NoAffidavitForm()
        {
            /*QUALIFYING CRITERIA*/
            ClickNo();
            Driver.WaitUntilElementFound(Associated_CompanyNameByControl, 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false, false, SLEEP_TIMER);
           

            Occurrence_ValidDate();

            Fill_OccurrenceAddress(2, 3, false, SLEEP_TIMER);

            Occurrence_VehicleInformation();

            Fill_InFrontOfSchool(false, SLEEP_TIMER);

            SubmitAcknowledgementAndProceedToNextPage();

            /*EVIDENCE UPLOAD*/

            string openComplaintNumber = Filled_EvidenceUpload();

            /*OATH AFFIDAVIT*/

            Filled_AppearOATH();

            var successfulSubmit = Driver.WaitUntilElementFound(SnackBarByControl, 60).FindElement(By.TagName("span"));
            Assert.IsNotNull(successfulSubmit);
            if (!successfulSubmit.Text.Contains(Constants.PARTIAL_SUCCESSFUL_FORM_SUBMISSION)) Assert.That(successfulSubmit.Text.Trim(), Is.EqualTo(Constants.SUCCESSFUL_FORM_SUBMISSION), "Flagged inconsistency on purpose.");
            else
            {
                string[] inputs = { GetEmail(), GetPassword(), openComplaintNumber, Constants.SUCCESS_STATUS };
                submission_tracker.WriteIntoFile(inputs);
            }
            Driver.WaitUntilElementIsNoLongerFound(SpinnerByControl, 60);
        }
        
        [Test]
        [Category("Successful Form Submission")]

        public void SuccessfulFormSubmit_InFrontOf_NoSchool_NoSummonAffidavit_YesAffidavitForm()
        {
            /*QUALIFYING CRITERIA*/
            ClickNo();
            Driver.WaitUntilElementFound(Associated_CompanyNameByControl, 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false, false, SLEEP_TIMER);

            Occurrence_ValidDate();

            Fill_OccurrenceAddress(2, 3, false, SLEEP_TIMER);

            Occurrence_VehicleInformation();

            Fill_InFrontOfSchool(false, SLEEP_TIMER);

            SubmitAcknowledgementAndProceedToNextPage();

            /*EVIDENCE UPLOAD*/

            string openComplaintNumber = Filled_EvidenceUpload();

            /*OATH AFFIDAVIT*/

            AppearOATH_ClickNo();

            Driver.WaitUntilElementIsNoLongerFound(SpinnerByControl, 60);
            Driver.WaitUntilElementFound(AppearOATH_UploadByControl, 60);

            AppearOATH_UploadFormInput = FILE_IMAGE_PATH;
            AppearOATH_ClickConfirmUpload();

            var successfulAffidavitUpload = Driver.WaitUntilElementFound(SnackBarByControl, 10).FindElement(By.TagName("span")); // message says evidence have successfully uploaded

            Assert.IsNotNull(successfulAffidavitUpload);
            string fileName = Path.GetFileName(FILE_IMAGE_PATH);

            if (!successfulAffidavitUpload.Text.Contains("upload")) Assert.That(successfulAffidavitUpload.Text.Trim(), Is.EqualTo("Successfully uploaded file named: " + fileName + "."), "Flagged inconsistency on purpose.");
            else
            {
                string[] inputs = { GetEmail(), GetPassword(), openComplaintNumber, Constants.SUCCESS_STATUS };
                submission_tracker.WriteIntoFile(inputs);
            }
            Driver.WaitUntilElementIsNoLongerFound(SnackBarByControl, 15);


            AppearOATH_ClickSubmit();

            var successfulSubmit = Driver.WaitUntilElementFound(SnackBarByControl, 60).FindElement(By.TagName("span"));
            Assert.IsNotNull(successfulSubmit);
            if (!successfulSubmit.Text.Contains(Constants.PARTIAL_SUCCESSFUL_FORM_SUBMISSION)) Assert.That(successfulSubmit.Text.Trim(), Is.EqualTo(Constants.SUCCESSFUL_FORM_SUBMISSION), "Flagged inconsistency on purpose.");

            Driver.WaitUntilElementIsNoLongerFound(SpinnerByControl, 60);
        }

        [Test]
        [Category("Successful Form Submission")]

        public void SuccessfulFormSubmit_InFrontOf_YesSchool_NoSummonAffidavit_NoAffidavitForm()
        {
            /*QUALIFYING CRITERIA*/
            ClickNo();
            Driver.WaitUntilElementFound(Associated_CompanyNameByControl, 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false, false, SLEEP_TIMER);

            Occurrence_ValidDate();

            Fill_OccurrenceAddress(2, 3, false, SLEEP_TIMER);

            Occurrence_VehicleInformation();

            Fill_InFrontOfSchool(true, SLEEP_TIMER);

            SubmitAcknowledgementAndProceedToNextPage();

            /*EVIDENCE UPLOAD*/

            string openComplaintNumber = Filled_EvidenceUpload();
            /*OATH AFFIDAVIT*/

            Filled_AppearOATH();

            var successfulSubmit = Driver.WaitUntilElementFound(SnackBarByControl, 60).FindElement(By.TagName("span"));
            Assert.IsNotNull(successfulSubmit);
            if (!successfulSubmit.Text.Contains(Constants.PARTIAL_SUCCESSFUL_FORM_SUBMISSION)) Assert.That(successfulSubmit.Text.Trim(), Is.EqualTo(Constants.SUCCESSFUL_FORM_SUBMISSION), "Flagged inconsistency on purpose.");
            else
            {
                string[] inputs = { GetEmail(), GetPassword(), openComplaintNumber, Constants.SUCCESS_STATUS };
                submission_tracker.WriteIntoFile(inputs);
            }
            Driver.WaitUntilElementIsNoLongerFound(SpinnerByControl, 60);
        }

        [Test]
        [Category("Successful Form Submission")]

        public void SuccessfulFormSubmit_Between_YesSchool_NoSummonAffidavit_NoAffidavitForm()
        {
            /*QUALIFYING CRITERIA*/
            ClickNo();
            Driver.WaitUntilElementFound(Associated_CompanyNameByControl, 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false, false, SLEEP_TIMER);

            Occurrence_ValidDate();

            Fill_OccurrenceAddress(1, 4, false, SLEEP_TIMER);

            Occurrence_VehicleInformation();

            Fill_InFrontOfSchool(true, SLEEP_TIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            SubmitAcknowledgementAndProceedToNextPage();

            /*EVIDENCE UPLOAD*/

            string openComplaintNumber = Filled_EvidenceUpload();
            /*OATH AFFIDAVIT*/

            Filled_AppearOATH();

            var successfulSubmit = Driver.WaitUntilElementFound(SnackBarByControl, 60).FindElement(By.TagName("span"));
            Assert.IsNotNull(successfulSubmit);
            if (!successfulSubmit.Text.Contains(Constants.PARTIAL_SUCCESSFUL_FORM_SUBMISSION)) Assert.That(successfulSubmit.Text.Trim(), Is.EqualTo(Constants.SUCCESSFUL_FORM_SUBMISSION), "Flagged inconsistency on purpose.");
            else
            {
                string[] inputs = { GetEmail(), GetPassword(), openComplaintNumber, Constants.SUCCESS_STATUS };
                submission_tracker.WriteIntoFile(inputs);
            }
            Driver.WaitUntilElementIsNoLongerFound(SpinnerByControl, 60);
        }

        [Test]
        [Category("Successful Form Submission")]

        public void SuccessfulFormSubmit_Intersection_YesSchool_NoSummonAffidavit_NoAffidavitForm()
        {
            /*QUALIFYING CRITERIA*/
            ClickNo();
            Driver.WaitUntilElementFound(Associated_CompanyNameByControl, 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false, false, SLEEP_TIMER);

            Occurrence_ValidDate();
            Fill_OccurrenceAddress(3, 4, false, SLEEP_TIMER);

            Occurrence_VehicleInformation();

            Fill_InFrontOfSchool(true, SLEEP_TIMER);

            SubmitAcknowledgementAndProceedToNextPage();

            string openComplaintNumber = Filled_EvidenceUpload();

            /*OATH AFFIDAVIT*/

            Filled_AppearOATH();

            var successfulSubmit = Driver.WaitUntilElementFound(SnackBarByControl, 60).FindElement(By.TagName("span"));
            Assert.IsNotNull(successfulSubmit);
            if (!successfulSubmit.Text.Contains(Constants.PARTIAL_SUCCESSFUL_FORM_SUBMISSION)) Assert.That(successfulSubmit.Text.Trim(), Is.EqualTo(Constants.SUCCESSFUL_FORM_SUBMISSION), "Flagged inconsistency on purpose.");
            else
            {
                string[] inputs = { GetEmail(), GetPassword(), openComplaintNumber, Constants.SUCCESS_STATUS };
                submission_tracker.WriteIntoFile(inputs);
            }
            Driver.WaitUntilElementIsNoLongerFound(SpinnerByControl, 60);

           
        }

        


        /*TO-DO: PO Box Checkbox is not working, need to investigate*/
        [Test]
        [Category("Successful Form Submission")]

        public void SuccessfulFormSubmit_YesPOBox_InFrontOf_NoSchool_YesSummonAffidavit()
        {
            /*QUALIFYING CRITERIA*/
            ClickNo();
            Driver.WaitUntilElementFound(Associated_CompanyNameByControl, 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(true, false, SLEEP_TIMER);

            Occurrence_ValidDate();

            Fill_OccurrenceAddress(2, 3, false, SLEEP_TIMER);

            Occurrence_VehicleInformation();

            Fill_InFrontOfSchool(false, SLEEP_TIMER);

            SubmitAcknowledgementAndProceedToNextPage();

            string openComplaintNumber = Filled_EvidenceUpload();
            /*OATH AFFIDAVIT*/

            AppearOATH_ClickYes();

            Driver.WaitUntilElementIsNoLongerFound(SpinnerByControl, 30);

            AppearOATH_ClickSubmit();

            var successfulSubmit = Driver.WaitUntilElementFound(SnackBarByControl, 60).FindElement(By.TagName("span"));
            Assert.IsNotNull(successfulSubmit);
            if (!successfulSubmit.Text.Contains(Constants.PARTIAL_SUCCESSFUL_FORM_SUBMISSION)) Assert.That(successfulSubmit.Text.Trim(), Is.EqualTo(Constants.SUCCESSFUL_FORM_SUBMISSION), "Flagged inconsistency on purpose.");
            else
            {
                string[] inputs = { GetEmail(), GetPassword(), openComplaintNumber, Constants.SUCCESS_STATUS };
                submission_tracker.WriteIntoFile(inputs);
            }
            Driver.WaitUntilElementIsNoLongerFound(SpinnerByControl, 60);

        }

    }
}
