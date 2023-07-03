using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdlingComplaints.Models.ComplaintForm;
using OpenQA.Selenium;
using SeleniumUtilities.Utils;

namespace IdlingComplaints.Tests.ComplaintForm.Occurrence
{
    internal class Test10_ComplaintFormFunctionality_UploadFile: FillComplaintForm_Base
    {

        private new readonly int SLEEPTIMER = 1000;
        private readonly string FILE_IMAGE_PATH = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Files\\Images\\idling_truck.jpeg";
        private readonly string ASSOCIATED_PERSON_RECORD_PATH = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Files\\Text\\ComplaintForm_Associated.txt";
        private readonly string Occurrence_PERSON_RECORD_PATH = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Files\\Text\\ComplaintForm_Occurrence.txt";

        [SetUp]
        public void Setup()
        {
            
            base.ComplaintFormModelSetUp(false);
            ClickNoButton();
            Driver.WaitUntilElementFound(By.CssSelector("input[placeholder='Company Name']"), 15);
                 //Driver.WaitUntilElementIsNoLongerFound(By.CssSelector("div[dir = 'ltr']"), 20);
            MoveTo_ComplaintForm_SecondPage();
        }
        [TearDown]
        public void Teardown()
        {
            base.ComplaintFormModelTearDown();
        }
        [Test]
        public void MoveTo_ComplaintForm_SecondPage()
        {
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

        }

    }
}
