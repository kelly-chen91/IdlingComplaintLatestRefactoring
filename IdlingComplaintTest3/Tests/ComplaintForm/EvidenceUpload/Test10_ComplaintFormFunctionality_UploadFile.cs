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
        string[] filePaths = { IDLING_TRUCK, IDLING_BUS, IDLING_VAN };

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

        [Test, Category("Upload Files")]
        public void EvidenceUpload_UploadOneFile()
        {
            string fileName = Path.GetFileName(filePaths[0]);

            EvidenceUpload_UploadControl.SendKeysWithDelay(filePaths[0], SLEEPTIMER);

            EvidenceUpload_ClickFilesUploadConfirm();

            var successfulEvidenceUpload = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20);
            Assert.IsNotNull(successfulEvidenceUpload);

            Console.WriteLine(successfulEvidenceUpload.Text);
            if (successfulEvidenceUpload.Text.Contains("uploaded"))
                Assert.That(successfulEvidenceUpload.Text.Trim(), Contains.Substring("Succesfully uploaded file named: " + fileName));

        }

        [Test, Category("Upload Files")]
        public void EvidenceUpload_UploadMultipleFiles()
        {
          
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
        public void EvidenceUpload_CheckTableAppearance()
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

        [Test, Category("Delete Files")]
        public void EvidenceUpload_VerifyDeleteButton()
        {
            EvidenceUpload_UploadOneFile();

            var deleteControl = By.CssSelector("mat-icon[aria-label='Delete']"); //get delete locator

            EvidenceUpload_ClickDeleteEvidence();

            Driver.WaitUntilElementFound(By.TagName("mat-dialog-container"), 20);
            EvidenceUpload_ConfirmDelete();
            Driver.WaitUntilElementFound(By.TagName("mat-error"), 10);
            Assert.IsNotNull(EvidenceUpload_UploadErrorControl);
        }


        [Test, Category("Delete Files")]
        //[Ignore("Debugging, Under Construction")]
        public void EvidenceUpload_VerifyMultipleDeleteButton()
        {
            EvidenceUpload_MultipleFileUpload();

            Thread.Sleep(1000);
            var fileList = EvidenceUpload_TableControl.GetDataFromMatTable();
            Console.WriteLine("start" + fileList.Count);

            List<IWebElement> deleteFileList = fileList.GetSpecificColumnElements(By.CssSelector("mat-icon[aria-label='Delete']")); //Gets the Delete button for each row
            while(fileList.Count > 1)
            {
                fileList = EvidenceUpload_TableControl.GetDataFromMatTable();           //Divide into rows from table
                Console.WriteLine(fileList.Count);
                deleteFileList = fileList.GetSpecificColumnElements(By.CssSelector("mat-icon[aria-label='Delete']")); //Gets the Delete button for each row
                deleteFileList[0].Click();
                Driver.WaitUntilElementFound(By.TagName("mat-dialog-container"), 20);
                EvidenceUpload_ConfirmDelete();
                Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-dialog-container"), 20);
                Thread.Sleep(1000);
            }
            Driver.WaitUntilElementFound(By.TagName("mat-error"), 10);
            Assert.IsNotNull(EvidenceUpload_UploadErrorControl);

        }


        [Test, Category("Verify the comment text box")]
        public void EvidenceUpload_Comment()
        {
            foreach (var file in filePaths)
            {
                EvidenceUpload_UploadControl.SendKeysWithDelay(file, SLEEPTIMER);
            }
            
            string commentTest = "Testing the comment box";
            EvidenceUpload_UploadCommentControl.SendKeysWithDelay(commentTest, SLEEPTIMER);
            EvidenceUpload_ClickFilesUploadConfirm();

            Driver.WaitUntilElementFound(By.XPath("//mat-card/mat-card-content/div/mat-table/mat-row[1]/mat-cell[3]"), SLEEPTIMER);
            string commentUploadedFiles = Driver.FindElement(By.XPath("//mat-card/mat-card-content/div/mat-table/mat-row[1]/mat-cell[3]")).Text;

            Assert.That(commentTest, Is.EqualTo(commentUploadedFiles));
        }

        [Test, Category("Verify the Cancel file upload button")]
        public void EvidenceUpload_CancelFileUploadButton()
        {
            foreach (var file in filePaths)
            {
                EvidenceUpload_UploadControl.SendKeysWithDelay(file, SLEEPTIMER);
            }
            string commentTest = "Testing the comment box";
            EvidenceUpload_UploadCommentControl.SendKeysWithDelay(commentTest, SLEEPTIMER);
            
            EvidenceUpload_UploadCancelControl.Click();

            Driver.WaitUntilElementFound(By.TagName("mat-header-cell"), SLEEPTIMER);
            Assert.IsNotNull(EvidenceUpload_UploadErrorControl);
        }

    }
}
