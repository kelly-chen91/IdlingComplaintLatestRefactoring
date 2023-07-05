using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdlingComplaints.Models.ComplaintForm;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V112.Network;
using SeleniumUtilities.Utils;

namespace IdlingComplaints.Tests.ComplaintForm.Occurrence
{
    internal class Test10_ComplaintFormFunctionality_UploadFile: FillComplaintForm_Base
    {

        private readonly new int SLEEPTIMER = 1000;
        // private readonly string FILE_IMAGE_PATH = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Files\\Images\\idling_truck.jpeg";
        //  private new readonly string ASSOCIATED_PERSON_RECORD_PATH = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Files\\Text\\ComplaintForm_Associated.txt";
        // private readonly string Occurrence_PERSON_RECORD_PATH = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Files\\Text\\ComplaintForm_Occurrence.txt";

        private static string idling_Upload_Text_File = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Files\\Images\\BlankTextFile_ForEvidenceUpload.txt";
        
        [SetUp]
        public void Setup()
        {
            
            base.ComplaintFormModelSetUp(false);
            StepsBeforeEvidenceUpload();

        }
        [TearDown]
        public void Teardown()
        {
            base.ComplaintFormModelTearDown();
        }

        public void StepsBeforeEvidenceUpload()
        {
            ClickNo();
            Driver.WaitUntilElementFound(By.CssSelector("input[placeholder='Company Name']"), 15);
            Filled_ComplaintInfo();

            var successfulSave = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20);
            Assert.IsNotNull(successfulSave);
            if (!successfulSave.Text.Contains("saved success")) Assert.That(successfulSave.Text.Trim(), Is.EqualTo("This form has been saved successfully."), "Flagged inconsistency on purpose.");
            Driver.WaitUntilElementIsNoLongerFound(By.TagName("simple-snack-bar"), 20);


            //  Driver.WaitUntilElementFound(By.XPath("/div/snack-bar-container/simple-snack-bar/span"), 15);
            //var formSaved = Driver.FindElement(By.XPath("/div/snack-bar-container/simple-snack-bar/span"));
            //Assert.That(formSaved.Text.Trim(), Is.EqualTo("This form has been saved successfully"), "TEST");
        }
        [Test, Category("Verify Link address")]
        public void EvidenceUpload_WebLink()
        {
            //StepsBeforeEvidenceUpload();
            string webUrl = EvidenceUpload_WebLinkControl.GetAttribute("href");
            string actualUrl = "https://nycidling-dev.azurewebsites.net/assets/images/Webdoc.pdf";
            Assert.That(actualUrl, Contains.Substring(webUrl));
        }
        [Test, Category("Verify Link address")]
        public void EvidenceUpload_AndroidLink()
        {
           // StepsBeforeEvidenceUpload();
            string androidUrl = EvidenceUpload_AndroidLinkControl.GetAttribute("href");
            string actualUrl = "https://nycidling-dev.azurewebsites.net/assets/images/Androiddoc.pdf";
            Assert.That(actualUrl, Contains.Substring(androidUrl));
        }
        [Test, Category("Verify Link address")]
        public void EvidenceUpload_iOSLink()
        {
            //StepsBeforeEvidenceUpload();
            string iOSUrl = EvidenceUpload_iOSLinkControl.GetAttribute("href");
            string actualUrl = "https://nycidling-dev.azurewebsites.net/assets/images/Iosdoc.pdf";
            Assert.That(actualUrl, Contains.Substring(iOSUrl));
        }
        [Test, Category("Verify Link address")]
        public void Test_snapBar()
        {
            var successfulSave = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20);
            Assert.IsNotNull(successfulSave);
            if (!successfulSave.Text.Contains("saved success")) Assert.That(successfulSave.Text.Trim(), Is.EqualTo("This form has been saved successfully."), "Flagged inconsistency on purpose.");
            Driver.WaitUntilElementIsNoLongerFound(By.TagName("simple-snack-bar"), 20);
        }

        [Test, Category("")]
        public void EvidenceUpload_VerifyChooseFilesButton()
        { 
          Driver.WaitUntilElementFound(By.CssSelector("input[type='file']"), SLEEPTIMER);
          
           string[] filePaths = {idling_Upload_Text_File};
           RegistrationUtilities.UploadFiles(EvidenceUpload_UploadControl, EvidenceUpload_UploadConfirmControl, filePaths);


            var successfulEvidenceUpload = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20); // message says evidence have successfully uploaded
            Assert.IsNotNull(successfulEvidenceUpload);
            if (!successfulEvidenceUpload.Text.Contains("upload")) Assert.That(successfulEvidenceUpload.Text.Trim(), Contains.Substring("Successfully uploaded file named: "), "Flagged inconsistency on purpose.");

        }

    }
}
//   string associated_CompanyName = RegistrationUtilities.RetriveRecordValue(ASSOCIATED_PERSON_RECORD_PATH, 1, 0);
//   Associated_SelectState(1);
//   string associated_HouseNumber = RegistrationUtilities.RetriveRecordValue(ASSOCIATED_PERSON_RECORD_PATH, 1, 1);
//   string associated_StreetName = RegistrationUtilities.RetriveRecordValue(ASSOCIATED_PERSON_RECORD_PATH, 1, 2);
//   string associated_AptFloor = RegistrationUtilities.RetriveRecordValue(ASSOCIATED_PERSON_RECORD_PATH, 1, 3);
//   string associated_City = RegistrationUtilities.RetriveRecordValue(ASSOCIATED_PERSON_RECORD_PATH, 1, 4);
//   string associated_Zip = RegistrationUtilities.RetriveRecordValue(ASSOCIATED_PERSON_RECORD_PATH, 1, 5);
// 
//   Associated_CompanyNameControl.SendKeysWithDelay(associated_CompanyName, SLEEPTIMER);
//   Associated_CompanyNameControl.SendKeysWithDelay(associated_HouseNumber, SLEEPTIMER);
// 
//   Associated_CompanyNameControl.SendKeysWithDelay(associated_StreetName, SLEEPTIMER);
// 
//   Associated_CompanyNameControl.SendKeysWithDelay(associated_AptFloor, SLEEPTIMER);
// 
//   Associated_CompanyNameControl.SendKeysWithDelay(associated_City, SLEEPTIMER);
//   Associated_CompanyNameControl.SendKeysWithDelay(associated_Zip, SLEEPTIMER);

//   EvidenceUpload_UploadInput = LARGE_VIDEO_PATH;
//   string fileName = Path.GetFileName(LARGE_VIDEO_PATH);
//   EvidenceUpload_ClickFilesUploadConfirm();
//   Thread.Sleep(SLEEPTIMER);
//
//
//  var successfulEvidenceUpload = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20); // message says evidence have successfully uploaded
//  Assert.IsNotNull(successfulEvidenceUpload);
//  if (!successfulEvidenceUpload.Text.Contains("upload")) Assert.That(successfulEvidenceUpload.Text.Trim(), Is.EqualTo("Successfully uploaded file named: " + fileName + "."), "Flagged inconsistency on purpose.");
