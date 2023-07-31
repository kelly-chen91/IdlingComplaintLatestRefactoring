using AventStack.ExtentReports;
using OpenQA.Selenium;
using SeleniumUtilities.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdlingComplaints.Tests.ComplaintForm.C10_OverallFunctionality
{
    
    internal partial class Test10_Functionality
    {
        

        [Test]
        [Category("Cancel - Form Submission")]
        public void CancelAtComplaintInfoPageFormRedirectsToHome()
        {
            QualifyingCriteria();

            Fill_Associated(false, false, SLEEP_TIMER);

            ComplaintInfo_ClickCancel();

            Driver.WaitUntilElementFound(NewComplaintByControl, 10);
        }

        [Test]
        [Category("Cancel - Form Submission")]
        public void CancelAtAppearEvidenceUploadRedirectsToHome()
        {
            Filled_ComplaintInfo();

            var successfulSave = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20).FindElement(By.TagName("span"));
            Assert.IsNotNull(successfulSave);
            if (!successfulSave.Text.Contains("saved success")) Assert.That(successfulSave.Text.Trim(), Is.EqualTo("This form has been saved successfully."), "Flagged inconsistency on purpose.");
            Driver.WaitUntilElementIsNoLongerFound(By.TagName("simple-snack-bar"), 20); //message says form is saved

            var compliantNumberControl = Driver.WaitUntilElementFound(ComplaintForm_ComplaintNumberByControl, 30);

            while (compliantNumberControl.Text.Length <= "Complaint Number: ".Length)
            {
                compliantNumberControl = Driver.WaitUntilElementFound(ComplaintForm_ComplaintNumberByControl, 30);
                Console.WriteLine(compliantNumberControl.Text);

            }

            string openComplaintNumber = compliantNumberControl.Text.Substring("Complaint Number: ".Length);
            EvidenceUpload_UploadInput = FILE_IMAGE_PATH;
            EvidenceUpload_ClickFilesUploadConfirm();
            string[] inputs = { GetEmail(), GetPassword(), openComplaintNumber, Constants.DRAFT_STATUS };
            submission_tracker.WriteIntoFile(inputs);
            EvidenceUpload_ClickCancel();

            var newComplaint = Driver.WaitUntilElementFound(NewComplaintByControl, 10);
            Assert.IsNotNull(newComplaint);
            
        }

        [Test]
        [Category("Cancel - Form Submission")]
        public void CancelAtAppearOATHPageFormRedirectsToHome()
        {
            Filled_ComplaintInfo();
            string openComplaintNumber = Filled_EvidenceUpload();
            string[] inputs = { GetEmail(), GetPassword(), openComplaintNumber, Constants.DRAFT_STATUS };
            submission_tracker.WriteIntoFile(inputs);
            AppearOATH_ClickYes();
            Driver.WaitUntilElementIsNoLongerFound(SpinnerByControl, 60); // loads to next page 

            AppearOATH_ClickCancel();

            Driver.WaitUntilElementFound(NewComplaintByControl, 10);
        }

        [Test]
        [Category("Previous - Form Submission")]
        public void PreviousAtEvidenceUploadRedirectsToComplaintInfo()
        {
            Filled_ComplaintInfo();
            var successfulSave = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20).FindElement(By.TagName("span"));
            Assert.IsNotNull(successfulSave);
            if (!successfulSave.Text.Contains("saved success")) Assert.That(successfulSave.Text.Trim(), Is.EqualTo("This form has been saved successfully."), "Flagged inconsistency on purpose.");
            Driver.WaitUntilElementIsNoLongerFound(By.TagName("simple-snack-bar"), 20); //message says form is saved

            var compliantNumberControl = Driver.WaitUntilElementFound(ComplaintForm_ComplaintNumberByControl, 30);

            while (compliantNumberControl.Text.Length <= "Complaint Number: ".Length)
            {
                compliantNumberControl = Driver.WaitUntilElementFound(ComplaintForm_ComplaintNumberByControl, 30);
                Console.WriteLine(compliantNumberControl.Text);

            }

            string openComplaintNumber = compliantNumberControl.Text.Substring("Complaint Number: ".Length);
            string[] inputs = { GetEmail(), GetPassword(), openComplaintNumber, Constants.DRAFT_STATUS };
            submission_tracker.WriteIntoFile(inputs);

            EvidenceUpload_UploadInput = FILE_IMAGE_PATH;
            EvidenceUpload_ClickFilesUploadCancel();
            EvidenceUpload_ClickPrevious();
            var companyNameField = Driver.WaitUntilElementFound(Associated_CompanyNameByControl, 60);
            Assert.IsNotNull(companyNameField);
        }

        [Test]
        [Category("Previous - Form Submission")]
        public void PreviousAtAppearOathRedirectsToEvidenceUpload()
        {
            Filled_ComplaintInfo();
            string openComplaintNumber = Filled_EvidenceUpload();
            string[] inputs = { GetEmail(), GetPassword(), openComplaintNumber, Constants.DRAFT_STATUS };
            submission_tracker.WriteIntoFile(inputs);
            AppearOATH_ClickYes();
            Driver.WaitUntilElementIsNoLongerFound(SpinnerByControl, 60); // loads to next page 
            AppearOATH_ClickPrevious();
            var header = Driver.WaitUntilElementFound(By.XPath("//app-blob-files-upload/form/mat-card/mat-card-header/div/mat-card-title/h4"), 10);
            Assert.IsNotNull(header);
            Assert.That(header.Text, Is.EqualTo("Files Upload"));
        }

        [Test]
        [Category("Previous - Disabled field kept disabled.")]
        public void PreviousAtEvidenceUploadDisabledState()
        {
            Filled_ComplaintInfo();

            var successfulSave = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20).FindElement(By.TagName("span"));
            Assert.IsNotNull(successfulSave);
            if (!successfulSave.Text.Contains("saved success")) Assert.That(successfulSave.Text.Trim(), Is.EqualTo("This form has been saved successfully."), "Flagged inconsistency on purpose.");
            Driver.WaitUntilElementIsNoLongerFound(By.TagName("simple-snack-bar"), 20); //message says form is saved

            var compliantNumberControl = Driver.WaitUntilElementFound(ComplaintForm_ComplaintNumberByControl, 30);

            while (compliantNumberControl.Text.Length <= "Complaint Number: ".Length)
            {
                compliantNumberControl = Driver.WaitUntilElementFound(ComplaintForm_ComplaintNumberByControl, 30);
                Console.WriteLine(compliantNumberControl.Text);

            }

            string openComplaintNumber = compliantNumberControl.Text.Substring("Complaint Number: ".Length);
            string[] inputs = { GetEmail(), GetPassword(), openComplaintNumber, Constants.DRAFT_STATUS };
            submission_tracker.WriteIntoFile(inputs);

            EvidenceUpload_UploadInput = FILE_IMAGE_PATH;
            EvidenceUpload_ClickFilesUploadCancel();
            EvidenceUpload_ClickPrevious();
            var companyNameField = Driver.WaitUntilElementFound(Associated_CompanyNameByControl, 60);
            Assert.IsNotNull(companyNameField);
            Driver.ScrollTo(Occurrence_StateControl);
            Assert.That(Occurrence_StateControl.GetAttribute("aria-disabled"), Is.EqualTo("true"));
        }

    }
}
