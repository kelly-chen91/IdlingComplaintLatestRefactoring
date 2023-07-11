using IdlingComplaints.Models.Home;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdlingComplaints.Models.ComplaintForm
{
    internal partial class ComplaintFormModel : HomeModel
    {
        public IWebElement EvidenceUpload_UploadControl => Driver.FindElement(By.CssSelector("input[type='file']"));

        public IWebElement EvidenceUpload_PreviousControl => Driver.FindElement(By.XPath("//app-blob-files-upload/form/div/button[1]"));
        public IWebElement EvidenceUpload_NextControl => Driver.FindElement(By.CssSelector("button[type='submit']"));
        public IWebElement EvidenceUpload_CancelControl => Driver.FindElement(By.CssSelector("button[type='reset']"));
        public IWebElement EvidenceUpload_UploadConfirmControl => Driver.FindElement(By.XPath("//app-upload/mat-card/mat-card-content/div/div[2]/div[2]/button[1]"));

        public IWebElement EvidenceUpload_WebLinkControl => Driver.FindElement(By.PartialLinkText("Web"));
        public IWebElement EvidenceUpload_AndroidLinkControl => Driver.FindElement(By.PartialLinkText("Android"));
        public IWebElement EvidenceUpload_iOSLinkControl => Driver.FindElement(By.PartialLinkText("iOS"));
        public IWebElement EvidenceUpload_UploadErrorControl => Driver.FindElement(By.TagName("mat-error"));
        public IWebElement EvidenceUpload_UploadCommentControl => Driver.FindElement(By.TagName("textarea"));

        public IWebElement EvidenceUpload_UploadCancelControl => Driver.FindElement(By.XPath("//app-upload/mat-card/mat-card-content/div/div[2]/div[2]/button[2]"));
       
        public IWebElement EvidenceUpload_DeleteEvidenceControl => Driver.FindElement(By.XPath("//mat-row/mat-cell[5]/mat-icon[2]"));
        
        public IWebElement EvidenceUpload_DeleteConfirmControl => Driver.FindElement(By.XPath("//app-confirm-dialog/div[2]/button[2]/span"));
        
        
        //public IWebElement EvidenceUpload_DeleteCancel => Driver.FindElement(By.XPath("//app-confirm-dialog/div[2]/button[1]/span"));
        
        public IWebElement EvidenceUpload_TableControl => Driver.FindElement(By.TagName("mat-table"));
        public IWebElement EvidenceUpload_RefreshControl => EvidenceUpload_TableControl.FindElement(By.CssSelector("button[mattooltip='Click to download']"));

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

        public string EvidenceUpload_CommentInput
        {
            get
            {
                return EvidenceUpload_UploadCommentControl.GetAttribute("value");
            }
            set
            {
                EvidenceUpload_UploadCommentControl.SendKeys(value);
            }
        }



        public void EvidenceUpload_ClickPrevious()
        {
            EvidenceUpload_PreviousControl.Click();
        }

        public void EvidenceUpload_ClickNext()
        {
            EvidenceUpload_NextControl.Click();
        }

        public void EvidenceUpload_ClickCancel()
        {
            EvidenceUpload_CancelControl.Click();
        }

        public void EvidenceUpload_ClickFilesUploadConfirm()
        {
            EvidenceUpload_UploadConfirmControl.Click();
        }

        public void EvidenceUpload_ClickFilesUploadCancel()
        {
            EvidenceUpload_UploadCancelControl.Click();
        }
        public void EvidenceUpload_ClickWebLink()
        {
            EvidenceUpload_WebLinkControl.Click();
        }
        public void EvidenceUpload_ClickAndroidLink()
        {
            EvidenceUpload_AndroidLinkControl.Click();
        }
        public void EvidenceUpload_ClickIOSLink()
        {
            EvidenceUpload_iOSLinkControl.Click();
        }

        public void EvidenceUpload_ClickDeleteEvidence()
        {
            EvidenceUpload_DeleteEvidenceControl.Click();
        }

        public void EvidenceUpload_ConfirmDelete()
        {
            EvidenceUpload_DeleteConfirmControl.Click();
        }

        public void EvidenceUpload_ClickRefresh()
        {
            EvidenceUpload_RefreshControl.Click();
        }
      
    }
}
