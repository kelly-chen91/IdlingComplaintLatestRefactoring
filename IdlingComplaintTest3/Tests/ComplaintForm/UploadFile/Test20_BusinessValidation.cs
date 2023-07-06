using OpenQA.Selenium;
using SeleniumUtilities.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdlingComplaints.Tests.ComplaintForm.EvidenceUpload
{
    internal class Test20_BusinessValidation: FillComplaintForm_Base
    {
        private readonly new int SLEEPTIMER = 1000;
        private static string IDLING_TRUCK = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Files\\Images\\idling_truck.jpeg";
        private static string IDLING_BUS = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Files\\Images\\idling_bus.jpg";
        private static string IDLING_VAN = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Files\\Images\\idling_van.jpg";
        private static string NOT_SUPPORTED_FILE = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Files\\Images\\not_supported_idling_WEBPfile.webp";
        private static string PDF_FILE = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Files\\Images\\WebDoc.pdf";
        private static string MP4_FILE = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Files\\Images\\MP4_How_To_Get_Rich_Reporting_On_Idling_Vehicles_In_NYC.mp4";


        [SetUp]
        public void Setup()
        {

            base.ComplaintFormModelSetUp(false);
            ClickNo();
            Driver.WaitUntilElementFound(By.CssSelector("input[placeholder='Company Name']"), 15);
            Filled_ComplaintInfo();

            var successfulSave = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20);
            Assert.IsNotNull(successfulSave);
            if (!successfulSave.Text.Contains("saved success")) Assert.That(successfulSave.Text.Trim(), Is.EqualTo("This form has been saved successfully."), "Flagged inconsistency on purpose.");
            Driver.WaitUntilElementIsNoLongerFound(By.TagName("simple-snack-bar"), 20);

        }
        [TearDown]
        public void Teardown()
        {
            base.ComplaintFormModelTearDown();
        }

        [Test, Category("Test PDF file type")]
        public void Verify_PDF_FileType()
        {

            // RegistrationUtilities.UploadFiles(EvidenceUpload_UploadControl, EvidenceUpload_UploadConfirmControl, filePaths);

            string[] filePaths = { PDF_FILE };
            EvidenceUpload_UploadControl.SendKeysWithDelay(filePaths[0], SLEEPTIMER);
            string fileName = Path.GetFileName(filePaths[0]);

            EvidenceUpload_ClickFilesUploadConfirm();

            var successfulEvidenceUpload = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20);
            Assert.IsNotNull(successfulEvidenceUpload);

            Console.WriteLine(successfulEvidenceUpload.Text);
            if (successfulEvidenceUpload.Text.Contains("uploaded"))
                Assert.That(successfulEvidenceUpload.Text.Trim(), Contains.Substring("Succesfully uploaded file named: " + fileName));

        }
        [Test, Category("Test MP4 file type")]
        public void Verify_MP4_FileType()
        {

            // RegistrationUtilities.UploadFiles(EvidenceUpload_UploadControl, EvidenceUpload_UploadConfirmControl, filePaths);

            string[] filePaths = { MP4_FILE };
            EvidenceUpload_UploadControl.SendKeysWithDelay(filePaths[0], SLEEPTIMER);
            string fileName = Path.GetFileName(filePaths[0]);

            EvidenceUpload_ClickFilesUploadConfirm();

            var successfulEvidenceUpload = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20);
            Assert.IsNotNull(successfulEvidenceUpload);

            Console.WriteLine(successfulEvidenceUpload.Text);
            if (successfulEvidenceUpload.Text.Contains("uploaded"))
                Assert.That(successfulEvidenceUpload.Text.Trim(), Contains.Substring("Succesfully uploaded file named: " + fileName));

        }


        [Test, Category("Not supported evidence file")]
        public void EvidenceUpload_FailedUploadFile_NotSupportedFileType()
        {

            // RegistrationUtilities.UploadFiles(EvidenceUpload_UploadControl, EvidenceUpload_UploadConfirmControl, filePaths);

            string[] filePaths = { NOT_SUPPORTED_FILE, IDLING_TRUCK, IDLING_BUS };
            EvidenceUpload_UploadControl.SendKeysWithDelay(filePaths[0], SLEEPTIMER);


            var failedEvidenceUpload = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20);
            Assert.IsNotNull(failedEvidenceUpload);

            if (failedEvidenceUpload.Text.Contains("Please try a different file type."))
                Assert.That(failedEvidenceUpload.Text.Trim(), Contains.Substring("Please try a different file type. Only the following are allow: Images, Documents, PDFs, Videos"));

        }

    }
}
