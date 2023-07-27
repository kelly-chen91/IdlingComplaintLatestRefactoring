using IdlingComplaints.Tests.ComplaintForm.C10_OverallFunctionality;
using OpenQA.Selenium;
using SeleniumUtilities.Base;
using SeleniumUtilities.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdlingComplaints.Tests.ComplaintForm.P30_EvidenceUpload
{

    internal class Test20_BusinessValidation: FillComplaintForm_Base
    {
        private new readonly int SLEEP_TIMER = 0;


        BaseExtent extent;

        public Test20_BusinessValidation()
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
            ClickNo();
            Driver.WaitUntilElementFound(Associated_CompanyNameByControl, 15);
            Filled_ComplaintInfo();
            var successfulSave = Driver.WaitUntilElementFound(SnackBarByControl, 20);
            Assert.IsNotNull(successfulSave);
            if (!successfulSave.Text.Contains("saved success")) Assert.That(successfulSave.Text.Trim(), Is.EqualTo("This form has been saved successfully."), "Flagged inconsistency on purpose.");
            Driver.WaitUntilElementIsNoLongerFound(SnackBarByControl, 20);

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

        [Test, Category("Testing PDF file type")]
        public void EvidenceUpload_Verify_PDF_FileType()
        {

            // RegistrationUtilities.UploadFiles(EvidenceUpload_UploadControl, EvidenceUpload_UploadConfirmControl, filePaths);

            string[] filePaths = { Constants.PDF_FILE };
            EvidenceUpload_UploadControl.SendKeysWithDelay(filePaths[0], SLEEP_TIMER);
            string fileName = Path.GetFileName(filePaths[0]);

            EvidenceUpload_ClickFilesUploadConfirm();

            var successfulEvidenceUpload = Driver.WaitUntilElementFound(SnackBarByControl, 20).FindElement(By.TagName("span"));

            Console.WriteLine(successfulEvidenceUpload.Text);
            if (successfulEvidenceUpload.Text.Contains("uploaded"))
                Assert.That(successfulEvidenceUpload.Text.Trim(), Is.EqualTo("Successfully uploaded file named: " + fileName));

        }
        [Test, Category("Testing video file type")]
        public void EvidenceUpload_Verify_MP4_FileType()
        {

            // RegistrationUtilities.UploadFiles(EvidenceUpload_UploadControl, EvidenceUpload_UploadConfirmControl, filePaths);

            string[] filePaths = { Constants.MP4_FILE };
            EvidenceUpload_UploadControl.SendKeysWithDelay(filePaths[0], SLEEP_TIMER);
            string fileName = Path.GetFileName(filePaths[0]);

            EvidenceUpload_ClickFilesUploadConfirm();

            var successfulEvidenceUpload = Driver.WaitUntilElementFound(SnackBarByControl, 20).FindElement(By.TagName("span"));
            Assert.IsNotNull(successfulEvidenceUpload);

            Console.WriteLine(successfulEvidenceUpload.Text);
            if (successfulEvidenceUpload.Text.Contains("uploaded"))
                Assert.That(successfulEvidenceUpload.Text.Trim(), Is.EqualTo("Succesfully uploaded file named: " + fileName));

        }


        [Test, Category("Testing the non suppported file type")]
        public void EvidenceUpload_NotSupportedFileType()
        {
            string[] filePaths = { Constants.NOT_SUPPORTED_FILE, Constants.IDLING_TRUCK, Constants.IDLING_BUS };
            EvidenceUpload_UploadControl.SendKeysWithDelay(filePaths[0], SLEEP_TIMER);

            var failedEvidenceUpload = Driver.WaitUntilElementFound(SnackBarByControl, 20).FindElement(By.TagName("span"));
            Assert.IsNotNull(failedEvidenceUpload);

            if (failedEvidenceUpload.Text.Contains("Please try a different file type."))
                Assert.That(failedEvidenceUpload.Text.Trim(), Is.EqualTo("Please try a different file type. Only the following are allowed: Images, Documents, PDFs, Videos."));

        }

    }
}
