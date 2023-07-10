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

        [Test, Category("Upload multiple evidence files")]
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
        [Ignore("Test is buggy, under construction")]
        public void EvidenceUpload_VerifyDeleteButton()
        {
            EvidenceUpload_MultipleFileUpload();

            string[] filePaths = { IDLING_TRUCK, IDLING_BUS, IDLING_VAN };
            string fileName = Path.GetFileName(filePaths[2]);



           // var rows = Driver.FindElement(By.TagName("mat-row"));
            var rows = EvidenceUpload_TableControl.GetDataFromMatTable();
            //rows.GetSpecificColumnElements()
            var garbegeBinControl = Driver.FindElement(By.XPath("/html/body/app-root/div/app-blob-files-upload/form/mat-card/mat-card-content/app-blobupload/mat-card/mat-card-content/div/mat-table/mat-row[1]/mat-cell[5]/mat-icon[2]"));
          
            var fileNameControl = Driver.FindElement(By.XPath("/html/body/app-root/div/app-blob-files-upload/form/mat-card/mat-card-content/app-blobupload/mat-card/mat-card-content/div/mat-table/mat-row[1]/mat-cell[1]"));

            Console.WriteLine("1111111111111111");
            Driver.WaitUntilElementFound(By.CssSelector("mat-icon[arial-lable='Delete']"), 30);
            garbegeBinControl.Click();

            Console.WriteLine("222222222222222222222");

            // Switch focus to the alert dialog
            //IAlert alertDialog = Driver.SwitchTo().Alert;

            // Get the text of the alert dialog
            //string alertText = alertDialog.Text;

            // Print the alert text (optional)
            //Console.WriteLine("Alert Text: " + alertText);

            // Click the confirm delete button in the alert dialog
            //alertDialog.Accept();

            // Switch back to the main window
            Driver.SwitchTo().DefaultContent();


         //   string mainWindowHandle = Driver.CurrentWindowHandle;
         //   ReadOnlyCollection<string> allWindowHandles = Driver.WindowHandles;

            Driver.WaitUntilElementFound(By.CssSelector("mat-dialog-container[role='dialog']"), 20);
       //    foreach (string windowHandle in allWindowHandles)
       //    {
       //        if (windowHandle != mainWindowHandle)
       //        {
       //            Driver.SwitchTo().Window(windowHandle);
       //            var yesButtonControl = Driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/mat-dialog-container/app-confirm-dialog/div[2]/button[2]/span"));
       //            yesButtonControl.Click();
       //            Driver.SwitchTo().Window(mainWindowHandle);
       //            break;
       //        }
       //    }
       //    Driver.WaitUntilElementFound(By.CssSelector("input[type='file']"), 18);

            string newFileNameOnTheList = fileNameControl.Text;
            Console.WriteLine(newFileNameOnTheList);
           
            Assert.That(fileName, !Is.EqualTo(newFileNameOnTheList), "File was not deleted successfully.");
        }
    }
}
