﻿using OpenQA.Selenium;
using SeleniumUtilities.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdlingComplaints.Tests.ComplaintForm
{
    internal partial class Test10_ComplaintFormFunctionality
    {
        [Test]
        [Category("Cancel - Form Submission")]
        public void CancelAtComplaintInfoPageFormRedirectsToHome()
        {
            QualifyingCriteria();

            Fill_Associated(false, false, SLEEPTIMER);

            ComplaintInfo_ClickCancel();

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



    }
}
