using IdlingComplaints.Models.ComplaintForm;
using IdlingComplaints.Tests.ComplaintForm.C10_OverallFunctionality;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumUtilities.BaseSetUp;
using SeleniumUtilities.Utils.TestUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdlingComplaints.Tests.ComplaintForm.P30_EvidenceUpload
{

    internal class Test30_RequiredLabelErrors : FillComplaintForm_Base
    {

        BaseExtent extent;

        public Test30_RequiredLabelErrors()
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
                if (SLEEP_TIMER > 0)
                    Thread.Sleep(SLEEP_TIMER);
                base.ComplaintFormModelTearDown();
            }
        }

        public new readonly int SLEEP_TIMER = 0;
        public new readonly string FILE_IMAGE_PATH = P30_EvidenceUpload.Constants.IDLING_TRUCK;



        [Test, Category("Required Field Fulfilled - Error Label Hidden")] 
        public void ProvidedUpload()
        {
            Filled_ComplaintInfo();

            var successfulSave = Driver.WaitUntilElementFound(SnackBarByControl, 20).FindElement(By.TagName("span"));
            Assert.IsNotNull(successfulSave);
            if (!successfulSave.Text.Contains("saved success")) Assert.That(successfulSave.Text.Trim(), Is.EqualTo("This form has been saved successfully."), "Flagged inconsistency on purpose.");
            Driver.WaitUntilElementIsNoLongerFound(SnackBarByControl, 20); //message says form is saved

            var compliantNumberControl = Driver.WaitUntilElementFound(ComplaintForm_ComplaintNumberByControl, 30);
            Console.WriteLine(compliantNumberControl.Text);

            while (compliantNumberControl.Text.Length <= "Complaint Number: ".Length)
            {
                compliantNumberControl = Driver.WaitUntilElementFound(ComplaintForm_ComplaintNumberByControl, 30);
                Console.WriteLine(compliantNumberControl.Text);

            }

            string openComplaintNumber = compliantNumberControl.Text.Substring("Complaint Number: ".Length);

            string[] inputs = { GetEmail(), GetPassword(), openComplaintNumber, C10_OverallFunctionality.Constants.DRAFT_STATUS };
            submission_tracker.WriteIntoFile(inputs);

            EvidenceUpload_UploadInput = FILE_IMAGE_PATH;
            string fileName = Path.GetFileName(FILE_IMAGE_PATH);
            EvidenceUpload_ClickFilesUploadConfirm();
            Thread.Sleep(SLEEP_TIMER); //The image is uploaded

            var successfulEvidenceUpload = Driver.WaitUntilElementFound(SnackBarByControl, 20);

            string requireContent = Driver.ExtractTextFromXPath("//form/mat-card/mat-card-content/mat-error/text()");
            Assert.That(requireContent, Is.EqualTo(string.Empty));
        }

        [Test, Category("Required Field Missing - Error Label Displayed")]
        public void MissingUpload()
        {
            Filled_ComplaintInfo();

            var successfulSave = Driver.WaitUntilElementFound(SnackBarByControl, 20).FindElement(By.TagName("span"));
            Assert.IsNotNull(successfulSave);
            if (!successfulSave.Text.Contains("saved success")) Assert.That(successfulSave.Text.Trim(), Is.EqualTo("This form has been saved successfully."), "Flagged inconsistency on purpose.");
            Driver.WaitUntilElementIsNoLongerFound(SnackBarByControl, 20); //message says form is saved

            var compliantNumberControl = Driver.WaitUntilElementFound(ComplaintForm_ComplaintNumberByControl, 30);
            Console.WriteLine(compliantNumberControl.Text);

            while (compliantNumberControl.Text.Length <= "Complaint Number: ".Length)
            {
                compliantNumberControl = Driver.WaitUntilElementFound(ComplaintForm_ComplaintNumberByControl, 30);
                Console.WriteLine(compliantNumberControl.Text);

            }

            string openComplaintNumber = compliantNumberControl.Text.Substring("Complaint Number: ".Length);
            string[] inputs = { GetEmail(), GetPassword(), openComplaintNumber, C10_OverallFunctionality.Constants.DRAFT_STATUS };
            submission_tracker.WriteIntoFile(inputs);

            EvidenceUpload_UploadInput = FILE_IMAGE_PATH;
            string fileName = Path.GetFileName(FILE_IMAGE_PATH);
            EvidenceUpload_ClickFilesUploadConfirm();
            Thread.Sleep(SLEEP_TIMER); //The image is uploaded

            var successfulEvidenceUpload = Driver.WaitUntilElementFound(SnackBarByControl, 20);
            Thread.Sleep(SLEEP_TIMER);
            EvidenceUpload_ClickDeleteEvidence();
            EvidenceUpload_ConfirmDelete(); //Image is deleted
            var successfulEvidenceDelete = Driver.WaitUntilElementFound(By.XPath("//form/mat-card/mat-card-content/mat-error"), 20); //Wait for error message

            string requireContent = Driver.ExtractTextFromXPath("//form/mat-card/mat-card-content/mat-error/text()");
            Assert.That(requireContent, Is.EqualTo(Constants.UPLOAD_FILE_REQUIRE), "Flagged for inconsistency on purpose.");

        }

    }
}
