using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumUtilities.Utils;
using IdlingComplaints.Tests.ComplaintForm.C10_OverallFunctionality;

namespace IdlingComplaints.Tests.ComplaintForm.P30_EvidenceUpload
{
    internal class Test60_Label : FillComplaintForm_Base
    {
        private readonly int SLEEPTIMER = 0;
        private new static string FILE_IMAGE_PATH = P30_EvidenceUpload.Constants.IDLING_TRUCK;

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

        [Test, Category("Correct Label Displayed")]
        public void EvidenceUpload_VerifyChooseFilesButton()
        {
            EvidenceUpload_UploadInput = FILE_IMAGE_PATH;
            string fileName = Path.GetFileName(FILE_IMAGE_PATH);
            EvidenceUpload_ClickFilesUploadConfirm();
            Thread.Sleep(SLEEPTIMER);

            // var successfulEvidenceUpload = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20); // message says evidence have successfully uploaded
            var successfulEvidenceUpload = Driver.WaitUntilElementFound(By.XPath("/html/body/div[2]/div/div/snack-bar-container/simple-snack-bar/span"), 20);
            Assert.IsNotNull(successfulEvidenceUpload);

            if (successfulEvidenceUpload.Text.Contains("uploaded")) Assert.That(successfulEvidenceUpload.Text.Trim(),
            Is.EqualTo("Successfully uploaded file named: " + fileName + "."), "Flagged inconsistency on purpose.");
        }

        [Test]
        [Category("Label Displayed - goes to correct link.")]
        public void VerifyWebLink()
        {
            string webUrl = EvidenceUpload_WebLinkControl.GetAttribute("href");
            string actualUrl = "https://nycidling-dev.azurewebsites.net/assets/images/Webdoc.pdf";
            Assert.That(actualUrl, Contains.Substring(webUrl));
        }
        [Test]
        [Category("Label Displayed - goes to correct link.")]
        public void VerifyAndroidLink()
        {
            string androidUrl = EvidenceUpload_AndroidLinkControl.GetAttribute("href");
            string actualUrl = "https://nycidling-dev.azurewebsites.net/assets/images/Androiddoc.pdf";
            Assert.That(actualUrl, Contains.Substring(androidUrl));
        }
        [Test]
        [Category("Label Displayed - goes to correct link.")]
        public void VerifyiOSLink()
        {
            string iOSUrl = EvidenceUpload_iOSLinkControl.GetAttribute("href");
            string actualUrl = "https://nycidling-dev.azurewebsites.net/assets/images/Iosdoc.pdf";
            Assert.That(actualUrl, Contains.Substring(iOSUrl));
        }
    }
}
