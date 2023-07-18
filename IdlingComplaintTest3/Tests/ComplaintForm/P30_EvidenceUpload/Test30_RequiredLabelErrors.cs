using IdlingComplaints.Models.ComplaintForm;
using IdlingComplaints.Tests.ComplaintForm.C10_OverallFunctionality;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumUtilities.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdlingComplaints.Tests.ComplaintForm.P30_EvidenceUpload
{
    internal class Test10_ComplaintFormFunctionality : FillComplaintForm_Base
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

        public readonly int SLEEPTIMER = 0;
        public new readonly string FILE_IMAGE_PATH = P30_EvidenceUpload.Constants.IDLING_TRUCK;



        [Test, Category("Required Field Fulfilled - Error Label Hidden")] 
        public void ProvidedUpload()
        {
            Filled_ComplaintInfo();

            var successfulSave = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20);
            Assert.IsNotNull(successfulSave);
            if (!successfulSave.Text.Contains("saved success")) Assert.That(successfulSave.Text.Trim(), Is.EqualTo("This form has been saved successfully."), "Flagged inconsistency on purpose.");
            Driver.WaitUntilElementIsNoLongerFound(By.TagName("simple-snack-bar"), 20); //message says form is saved

            EvidenceUpload_UploadInput = FILE_IMAGE_PATH;
            string fileName = Path.GetFileName(FILE_IMAGE_PATH);
            EvidenceUpload_ClickFilesUploadConfirm();
            Thread.Sleep(SLEEPTIMER); //The image is uploaded

            var successfulEvidenceUpload = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20);

            string requireContent = Driver.ExtractTextFromXPath("//form/mat-card/mat-card-content/mat-error/text()");
            Assert.That(requireContent, Is.EqualTo(string.Empty));
        }

        [Test, Category("Required Field Missing - Error Label Displayed")]
        public void MissingUpload()
        {
            Filled_ComplaintInfo();

            var successfulSave = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20);
            Assert.IsNotNull(successfulSave);
            if (!successfulSave.Text.Contains("saved success")) Assert.That(successfulSave.Text.Trim(), Is.EqualTo("This form has been saved successfully."), "Flagged inconsistency on purpose.");
            Driver.WaitUntilElementIsNoLongerFound(By.TagName("simple-snack-bar"), 20); //message says form is saved

            EvidenceUpload_UploadInput = FILE_IMAGE_PATH;
            string fileName = Path.GetFileName(FILE_IMAGE_PATH);
            EvidenceUpload_ClickFilesUploadConfirm();
            Thread.Sleep(SLEEPTIMER); //The image is uploaded

            var successfulEvidenceUpload = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20);
            Thread.Sleep(SLEEPTIMER);
            EvidenceUpload_ClickDeleteEvidence();
            EvidenceUpload_ConfirmDelete(); //Image is deleted
            var successfulEvidenceDelete = Driver.WaitUntilElementFound(By.XPath("//form/mat-card/mat-card-content/mat-error"), 20); //Wait for error message

            string requireContent = Driver.ExtractTextFromXPath("//form/mat-card/mat-card-content/mat-error/text()");
            Assert.That(requireContent, Is.EqualTo(Constants.UPLOAD_FILE_REQUIRE), "Flagged for inconsistency on purpose.");

        }

    }
}
