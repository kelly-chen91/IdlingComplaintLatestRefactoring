using OpenQA.Selenium;
using SeleniumUtilities.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdlingComplaints.Tests.ComplaintForm.C10_OverallFunctionality
{
    
    internal partial class Test10_Functionality
    {

        [Test]
        [Category("Cancel - Form Submission")]
        public void CancelAtComplaintInfoPageFormRedirectsToHome()
        {
            QualifyingCriteria();

            Fill_Associated(false, false, SLEEP_TIMER);

            ComplaintInfo_ClickCancel();

            Driver.WaitUntilElementFound(By.CssSelector("button[routerlink = 'idlingcomplaint/new']"), 10);
        }

        [Test]
        [Category("Cancel - Form Submission")]
        public void CancelAtAppearEvidenceUploadRedirectsToHome()
        {
            Filled_ComplaintInfo();
            EvidenceUpload_UploadInput = FILE_IMAGE_PATH;
            EvidenceUpload_ClickFilesUploadConfirm();
            EvidenceUpload_ClickCancel();

            Driver.WaitUntilElementFound(By.CssSelector("button[routerlink = 'idlingcomplaint/new']"), 10);
        }

        [Test]
        [Category("Cancel - Form Submission")]
        public void CancelAtAppearOATHPageFormRedirectsToHome()
        {
            Filled_ComplaintInfo();
            Filled_EvidenceUpload();
            AppearOATH_ClickYes();
            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 60); // loads to next page 
            AppearOATH_ClickCancel();

            Driver.WaitUntilElementFound(By.CssSelector("button[routerlink = 'idlingcomplaint/new']"), 10);
        }

        [Test]
        [Category("Previous - Form Submission")]
        public void PreviousAtEvidenceUploadRedirectsToComplaintInfo()
        {
            Filled_ComplaintInfo();
            EvidenceUpload_UploadInput = FILE_IMAGE_PATH;
            EvidenceUpload_ClickFilesUploadCancel();
            EvidenceUpload_ClickPrevious();
            var companyNameField = Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname = 'idc_associatedlastname']"), 60);
            Assert.IsNotNull(companyNameField);
        }

        [Test]
        [Category("Previous - Form Submission")]
        public void PreviousAtAppearOathRedirectsToEvidenceUpload()
        {
            Filled_ComplaintInfo();
            Filled_EvidenceUpload();
            AppearOATH_ClickYes();
            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 60); // loads to next page 
            AppearOATH_ClickPrevious();
            var header = Driver.WaitUntilElementFound(By.XPath("//app-blob-files-upload/form/mat-card/mat-card-header/div/mat-card-title/h4"), 10);
            Assert.IsNotNull(header);
            Assert.That(header.Text, Is.EqualTo("Files Upload"));
        }

        [Test]
        [Category("Previous - Disabled field kept disabled.")]
        public void PreviousAtEvidenceUploadDisabledState()
        {
            Filled_ComplaintInfo();
            EvidenceUpload_UploadInput = FILE_IMAGE_PATH;
            EvidenceUpload_ClickFilesUploadCancel();
            EvidenceUpload_ClickPrevious();
            var companyNameField = Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname = 'idc_associatedlastname']"), 60);
            Assert.IsNotNull(companyNameField);
            Driver.ScrollTo(Occurrence_StateControl);
            Assert.That(Occurrence_StateControl.GetAttribute("aria-disabled"), Is.EqualTo("true"));
        }

    }
}
