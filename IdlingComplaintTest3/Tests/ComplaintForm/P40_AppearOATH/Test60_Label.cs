using IdlingComplaints.Tests.ComplaintForm.C10_OverallFunctionality;
using OpenQA.Selenium;
using SeleniumUtilities.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdlingComplaints.Tests.ComplaintForm.P40_AppearOATH
{
    [Parallelizable(ParallelScope.Fixtures)]
    [FixtureLifeCycle(LifeCycle.SingleInstance)]
    internal class Test60_Label : FillComplaintForm_Base
    {
        BaseExtent extent;

        public Test60_Label()
        {
            extent = new BaseExtent();
        }
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            extent.SetUp(false, GetType().Namespace + "." + GetType().Name);;
            base.ComplaintFormModelSetUp(true);
            AppearOATHSetUp();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            extent.TearDown(false, Driver);
            base.ComplaintFormModelTearDown();
        }

        [SetUp]
        public void SetUp()
        {
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
        }

        public void AppearOATHSetUp()
        {
            NewComplaintSetUp();
            base.Filled_ComplaintInfo();
            base.Filled_EvidenceUpload();
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void VerifySuccessfulUploadDocumentMessage()
        {

            AppearOATH_ClickNo();
            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 30);
            AppearOATH_UploadFormInput = FILE_IMAGE_PATH;
            string fileName = Path.GetFileName(FILE_IMAGE_PATH);
            AppearOATH_ClickConfirmUpload();


            var successfulDocumentUpload = Driver.WaitUntilElementFound(SnackBarByControl, 20).FindElement(By.TagName("span")); // message says evidence have successfully uploaded
            Assert.IsNotNull(successfulDocumentUpload);
            Assert.That(successfulDocumentUpload.Text.Trim(), Is.EqualTo("Successfully uploaded file named: " + fileName + "."), "Flagged inconsistency on purpose.");
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedAppearOathHeading()
        {
            string heading = Driver.ExtractTextFromXPath("//affidavit-upload/form/div/mat-card/mat-card-header/div/mat-card-title/h4/text()");
            Assert.That(heading, Is.EqualTo(Constants.APPEAR_OATH_HEADING));
        }

        

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedAppearOathQuestion()
        { 
            string question = Driver.ExtractTextFromXPath("//affidavit-upload/form/div/mat-card/mat-card-content/div[1]/label/text()");
            Assert.That(question, Is.EqualTo(Constants.APPEAR_OATH_QUESTION)); 
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedAppearOathQuestion_Yes()
        {
            string question_yes = AppearOATH_YesControl.Text.Trim();
            Assert.That(question_yes, Is.EqualTo(Constants.APPEAR_OATH_YES));
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedAppearOathQuestion_No()
        {
            string question_no = AppearOATH_NoControl.Text.Trim();
            Assert.That(question_no, Is.EqualTo(Constants.APPEAR_OATH_NO));
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedAppearOathFileUploadInstruction()
        {
            AppearOATH_ClickNo();
            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 60);
            Driver.WaitUntilElementFound(By.CssSelector("div[style='border: 1px solid silver; background: ivory; padding-left: 0.25cm; padding-top: 0.25cm; padding-right: 0.25cm;']"), 10);

            string fileUploadInstruction = AppearOATH_FileInstructionControl.FindElement(By.TagName("label")).Text;
            Assert.That(fileUploadInstruction, Is.EqualTo(Constants.APPEAR_OATH_FILE_UPLOAD_EXPLANATION));
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedAppearOathFileUploadSummonsAffadivitLink()
        {
            AppearOATH_ClickNo();
            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 120);
            Driver.WaitUntilElementFound(By.CssSelector("div[style='border: 1px solid silver; background: ivory; padding-left: 0.25cm; padding-top: 0.25cm; padding-right: 0.25cm;']"), 10);
           string summonsAffidavitLink = AppearOATH_AffidavitLinkControl.Text;
            //  string summonsAffidavitLink = Driver.ExtractTextFromXPath("//affidavit-upload/form/div/mat-card/mat-card-content/div[4]/div[1]/p/a[1]/u/text()");
            
            Assert.That(summonsAffidavitLink, Is.EqualTo(Constants.APPEAR_OATH_SUMMONS_AFFDAVIT_FORM));
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedAppearOathFileUploadCitizenAffirmationLink()
        {
            AppearOATH_ClickNo();
            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 120);
            Driver.WaitUntilElementFound(By.CssSelector("div[style='border: 1px solid silver; background: ivory; padding-left: 0.25cm; padding-top: 0.25cm; padding-right: 0.25cm;']"), 10);

            string complaintAffirmationLink = AppearOATH_AffirmationLinkControl.Text;
            Assert.That(complaintAffirmationLink, Is.EqualTo(Constants.APPEAR_OATH_COMPLAINT_AFFIRMATION_FORM));
        }

        [Test]
        [Category("Label Displayed - goes to correct link.")]
        public void VerifyAppearOathFileUploadSummonsAffadivitLink()
        {
            AppearOATH_ClickNo();
            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 120);
            Driver.WaitUntilElementFound(By.CssSelector("div[style='border: 1px solid silver; background: ivory; padding-left: 0.25cm; padding-top: 0.25cm; padding-right: 0.25cm;']"), 10);

            string summonsAffadivitLink = AppearOATH_AffidavitLinkControl.GetAttribute("href");
            Console.WriteLine(summonsAffadivitLink);
            Assert.That(summonsAffadivitLink, Is.EqualTo(Constants.APPEAR_OATH_SUMMONS_AFFADIVIT_LINK));
        }

        [Test]
        [Category("Label Displayed - goes to correct link.")]
        public void VerifyAppearOathFileUploadComplaintAffirmationLink()
        {
            AppearOATH_ClickNo();
            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 120);
            Driver.WaitUntilElementFound(By.CssSelector("div[style='border: 1px solid silver; background: ivory; padding-left: 0.25cm; padding-top: 0.25cm; padding-right: 0.25cm;']"), 10);

            string complaintAffirmationLink = AppearOATH_AffirmationLinkControl.GetAttribute("href");
            Console.WriteLine(complaintAffirmationLink);
            Assert.That(complaintAffirmationLink, Is.EqualTo(Constants.APPEAR_OATH_COMPLAINT_AFFIRMATION_LINK));
        }

    }
}
