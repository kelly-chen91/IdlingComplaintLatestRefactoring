﻿using IdlingComplaints.Models.Home;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdlingComplaints.Models.ComplaintForm
{
    internal partial class ComplaintFormModel : HomeModel
    {
        IWebElement EvidenceUpload_UploadControl => Driver.FindElement(By.CssSelector("input[type='file']"));
        
        //IWebElement EvidenceUpload_PreviousControl => Driver.FindElement(By.CssSelector("button[type='button']"));
        IWebElement EvidenceUpload_NextControl => Driver.FindElement(By.CssSelector("button[type='submit']"));

        IWebElement EvidenceUpload_UploadConfirmControl => Driver.FindElement(By.XPath("//app-upload/mat-card/mat-card-content/div/div[2]/div[2]/button[1]"));
        /*For Maya to practice: Please add additional elements below.*/






        public string EvidenceUpload_UploadInput
        {
            get
            {
                return EvidenceUpload_UploadControl.GetAttribute("value");
            }
            set
            {
                EvidenceUpload_UploadControl.SendKeys(value);
            }
        }

        public void EvidenceUpload_ClickFilesNext()
        {
            EvidenceUpload_NextControl.Click();
        }

        public void EvidenceUpload_ClickFilesUploadConfirm()
        {
            EvidenceUpload_UploadConfirmControl.Click();
        }
    }
}