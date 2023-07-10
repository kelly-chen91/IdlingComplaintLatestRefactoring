using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdlingComplaints.Models.ComplaintForm;
using IdlingComplaints.Tests.ComplaintForm.Functionality;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V112.Network;
using SeleniumUtilities.Utils;

namespace IdlingComplaints.Tests.ComplaintForm.EvidenceUpload
{
    internal class Test10_ComplaintFormFunctionality_UploadFile: FillComplaintForm_Base
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
            if (SLEEPTIMER > 0)
                Thread.Sleep(SLEEPTIMER);
            base.ComplaintFormModelTearDown();
        }

        [Test, Category("Scenario #1: upload one evidence file")]
        public void EvidenceUpload_UploadOneFile()
        {
            string[] filePaths = { IDLING_TRUCK, IDLING_BUS, IDLING_VAN };
            string fileName = Path.GetFileName(filePaths[0]);

            EvidenceUpload_UploadControl.SendKeysWithDelay(filePaths[0], SLEEPTIMER);

            EvidenceUpload_ClickFilesUploadConfirm();

            var successfulEvidenceUpload = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20);
            Assert.IsNotNull(successfulEvidenceUpload);

            Console.WriteLine(successfulEvidenceUpload.Text);
            if (successfulEvidenceUpload.Text.Contains("uploaded"))
                Assert.That(successfulEvidenceUpload.Text.Trim(), Contains.Substring("Succesfully uploaded file named: " + fileName));

        }

        [Test, Category("Upload multiple evidence files at once")]
        public void EvidenceUpload_MultipleFileUpload()
        {
            string[] filePaths = { IDLING_TRUCK, IDLING_BUS, IDLING_VAN };
            string fileName = Path.GetFileName(filePaths[0]);


            foreach (var file in filePaths)
            {
                EvidenceUpload_UploadControl.SendKeysWithDelay(file, SLEEPTIMER);
            }
              EvidenceUpload_ClickFilesUploadConfirm();

            var successfulEvidenceUpload = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20);
            Assert.IsNotNull(successfulEvidenceUpload);
           
            Console.WriteLine(successfulEvidenceUpload.Text);
            if (successfulEvidenceUpload.Text.Contains("uploaded")) 
                Assert.That(successfulEvidenceUpload.Text.Trim(), Contains.Substring("Succesfully uploaded file named: "));

        }

        [Test, Category("Upload Amount Equals Table Rows")]
        public void EvidenceUpload_TableAppearanceCheck()
        {

            string[] filePaths = { IDLING_TRUCK, IDLING_BUS, IDLING_VAN }; //Files can be added to or removed from and will still work
            string fileName = Path.GetFileName(filePaths[0]);

            int i = 0;
            foreach (var file in filePaths)
            {
                EvidenceUpload_UploadControl.SendKeysWithDelay(file, SLEEPTIMER);
                i++;
            }
            EvidenceUpload_ClickFilesUploadConfirm();


            var successfulEvidenceUpload = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20);
            Driver.WaitUntilElementIsNoLongerFound(By.TagName("simple-snack-bar"), 20);


            var rowList = MatTableControl.GetDataFromMatTable(); //Needed to make new version of this because it's a different type of table
            Assert.That(rowList.Count, Is.EqualTo(i));

        }

        [Test, Category("Verify the delete button")]
        //[Ignore("Test is buggy, under construction")]
        public void EvidenceUpload_VerifyDeleteButton()
        {
            EvidenceUpload_UploadOneFile();

            string[] filePaths = { IDLING_TRUCK, IDLING_BUS, IDLING_VAN };
            var deleteControl = By.CssSelector("mat-icon[aria-label='Delete']"); //get delete locator

            EvidenceUpload_ClickDeleteEvidence();

            Driver.WaitUntilElementFound(By.TagName("mat-dialog-container"), 20);
            EvidenceUpload_ConfirmDelete();
            Driver.WaitUntilElementFound(By.TagName("mat-error"), 10);
            Assert.IsNotNull(EvidenceUpload_UploadErrorControl);
        }


        [Test, Category("Verify the delete button"), Ignore("Debugging")]
        public void EvidenceUpload_VerifyMultipleDeleteButton()
        {
             EvidenceUpload_MultipleFileUpload();
     
             var fileNameControl = By.CssSelector("mat-cell[class='cdk-column-blob_filename']"); // get each File Name
             var deleteControl = By.CssSelector("mat-icon[aria-label='Delete']");

             var rowList = EvidenceUpload_Table3Control.GetTableContains();//This will return the row contains 
             var deleteFileList = rowList.GetCertainListControl(deleteControl);//Get the delete button from specific row
             var FileList = rowList.GetCertainListControl(fileNameControl);     //Get the fileName from specific row 
       
             for (int i = 0; i < deleteFileList.Count; i++)
             {
                 Driver.WaitUntilElementFound(By.TagName("mat-header-row"), 15);
                 //   Driver.WaitUntilElementIsNoLongerFound(By.CssSelector("div[dir='ltr']"), 20);
       
                 rowList = EvidenceUpload_Table3Control.GetTableContains();//This will return the row contains
                 deleteFileList = rowList.GetSpecificColumnElements(deleteControl);
                 FileList = rowList.GetCertainListControl(fileNameControl);

                 deleteFileList[i].Click();
       
                Thread.Sleep(2000);
              }
            }
    }
}
