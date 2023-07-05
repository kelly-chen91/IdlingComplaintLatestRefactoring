using IdlingComplaints.Models.ComplaintForm;
using IdlingComplaints.Tests.ComplaintForm.EvidenceAndAffidavit;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumUtilities.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdlingComplaints.Tests.ComplaintForm.UploadFile
{
    internal class Test10_ComplaintFormFunctionality : FillComplaintForm_Base
    {
        //For some reason opening two chrome tests with the setup?
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            base.ComplaintFormModelSetUp(false);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            if (SLEEPTIMER > 0) { Thread.Sleep(SLEEPTIMER); }
            base.ComplaintFormModelTearDown();
        }


        public readonly int SLEEPTIMER = 0;
        public readonly string FILE_IMAGE_PATH = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Files\\Images\\idling_truck.jpeg";



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
