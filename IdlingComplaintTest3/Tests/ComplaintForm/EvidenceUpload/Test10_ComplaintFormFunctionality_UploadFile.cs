using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdlingComplaints.Models.ComplaintForm;
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
                Assert.That(successfulEvidenceUpload.Text.Trim(), Contains.Substring("Succesfully uploaded file named: "+ fileName));

        }
        [Test, Category("Verify the delete button")]
        public void EvidenceUpload_VerifyDeleteButton()
        {
            Console.WriteLine("Test1");
            EvidenceUpload_MultipleFileUpload();
            Console.WriteLine("Test2");
            string[] filePaths = { IDLING_TRUCK, IDLING_BUS, IDLING_VAN };
            string fileName = Path.GetFileName(filePaths[0]);

            var rows = Driver.FindElements(By.CssSelector("mat-card-content[class='mat-card-content']"));
            IWebElement DeleteButtonControl = Driver.FindElement(By.CssSelector("mat-icon[aria-label='Delete']"));
           
            foreach (var row in rows)
            {
                var rowData = row.FindElement(By.XPath("/html/body/app-root/div/app-blob-files-upload/form/mat-card/mat-card-content/app-blobupload/mat-card/mat-card-content/div/mat-table/mat-row[1]/mat-cell[1]/test()"));
                if (rowData.Equals(fileName))
                {
                    DeleteButtonControl.Click();
                   
                    IAlert alert = 
                        Driver.SwitchTo().Alert;
                    alert.Accept();
                }
            }

        }
    }
}
