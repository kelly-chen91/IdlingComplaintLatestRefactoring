using OpenQA.Selenium;
using SeleniumUtilities.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdlingComplaints.Tests.ComplaintForm.AppearOATH
{
    internal class Test60_Label : FillComplaintForm_Base
    {
        //[SetUp]
        //public new void SetUp()
        //{
        //    Driver.Quit();
        //    ComplaintFormModelSetUp(true);
        //    base.QualifyingCriteria();
        //    base.Filled_ComplaintInfo();
        //    base.Filled_EvidenceUpload();
        //
        //}
        //
        //[TearDown]
        //public new void TearDown()
        //{
        //    if (SLEEPTIMER > 0) { Thread.Sleep(SLEEPTIMER); }
        //   ComplaintFormModelTearDown();
        //}

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedAppearOathHeading()
        {
            base.QualifyingCriteria();
            base.Filled_ComplaintInfo();
            base.Filled_EvidenceUpload();
            string heading = Driver.ExtractTextFromXPath("//affidavit-upload/form/div/mat-card/mat-card-header/div/mat-card-title/h4/text()");
            Assert.That(heading, Is.EqualTo(Constants.APPEAR_OATH_HEADING));
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedAppearOathQuestion()
        {
            base.QualifyingCriteria();
            base.Filled_ComplaintInfo();
            base.Filled_EvidenceUpload();
            string question = Driver.ExtractTextFromXPath("//affidavit-upload/form/div/mat-card/mat-card-content/div[1]/label/text()");
            Assert.That(question, Is.EqualTo(Constants.APPEAR_OATH_QUESTION));
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedAppearOathQuestion_Yes()
        {
            base.QualifyingCriteria();
            base.Filled_ComplaintInfo();
            base.Filled_EvidenceUpload();
            string question_yes = AppearOATH_YesControl.Text.Trim();
            Assert.That(question_yes, Is.EqualTo(Constants.APPEAR_OATH_YES));
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedAppearOathQuestion_No()
        {
            base.QualifyingCriteria();
            base.Filled_ComplaintInfo();
            base.Filled_EvidenceUpload();
            string question_no = AppearOATH_NoControl.Text.Trim();
            Assert.That(question_no, Is.EqualTo(Constants.APPEAR_OATH_NO));
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedAppearOathFileUploadInstruction()
        {
            base.QualifyingCriteria();
            base.Filled_ComplaintInfo();
            base.Filled_EvidenceUpload();
            AppearOATH_ClickNo();
            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 60);
            string fileUploadInstruction = Driver.ExtractTextFromXPath("//affidavit-upload/form/div/mat-card/mat-card-content/div[4]/div[1]/p/label/text()");
            Assert.That(fileUploadInstruction, Is.EqualTo(Constants.APPEAR_OATH_FILE_UPLOAD_EXPLANATION));
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedAppearOathFileUploadSummonsAffadivitLink()
        {
            base.QualifyingCriteria();
            base.Filled_ComplaintInfo();
            base.Filled_EvidenceUpload();
            AppearOATH_ClickNo();
            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 60);
            string summonsAffidavitLink = AppearOATH_AffidavitLinkControl.Text;
            Assert.That(summonsAffidavitLink, Is.EqualTo(Constants.APPEAR_OATH_SUMMONS_AFFDAVIT_FORM));
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedAppearOathFileUploadCitizenAffirmationLink()
        {
            base.QualifyingCriteria();
            base.Filled_ComplaintInfo();
            base.Filled_EvidenceUpload();
            AppearOATH_ClickNo();
            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 60);
            string complaintAffirmationLink = AppearOATH_AffirmationLinkControl.Text;
            Assert.That(complaintAffirmationLink, Is.EqualTo(Constants.APPEAR_OATH_COMPLAINT_AFFIRMATION_FORM));
        }

        [Test]
        [Category("Label Displayed - goes to correct link.")]
        public void VerifyAppearOathFileUploadSummonsAffadivitLink()
        {
            base.QualifyingCriteria();
            base.Filled_ComplaintInfo();
            base.Filled_EvidenceUpload();
            AppearOATH_ClickNo();
            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 60);
            string summonsAffadivitLink = AppearOATH_AffidavitLinkControl.GetAttribute("href");
            Console.WriteLine(summonsAffadivitLink);
            Assert.That(summonsAffadivitLink, Is.EqualTo(Constants.APPEAR_OATH_SUMMONS_AFFADIVIT_LINK));
        }

        [Test]
        [Category("Label Displayed - goes to correct link.")]
        public void VerifyAppearOathFileUploadComplaintAffirmationLink()
        {
            base.QualifyingCriteria();
            base.Filled_ComplaintInfo();
            base.Filled_EvidenceUpload();
            AppearOATH_ClickNo();
            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 60);
            string complaintAffirmationLink = AppearOATH_AffirmationLinkControl.GetAttribute("href");
            Console.WriteLine(complaintAffirmationLink);
            Assert.That(complaintAffirmationLink, Is.EqualTo(Constants.APPEAR_OATH_COMPLAINT_AFFIRMATION_LINK));
        }

    }
}
