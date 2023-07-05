using IdlingComplaints.Models.Home;
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

        IWebElement EvidenceUpload_UploadCancelControl => Driver.FindElement(By.XPath("//mat-card-content/div/div[2]/div[2]/button[2]/span"));

        IWebElement EvidenceUpload_DeleteEvidence => Driver.FindElement(By.XPath("//mat-row/mat-cell[5]/mat-icon[2]"));

        IWebElement EvidenceUpload_DeleteConfirm => Driver.FindElement(By.XPath("//app-confirm-dialog/div[2]/button[2]/span"));

        IWebElement EvidenceUpload_DeleteCancel => Driver.FindElement(By.XPath("//app-confirm-dialog/div[2]/button[1]/span"));




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

        public void EvidenceUpload_ClickDeleteEvidence()
        {
            EvidenceUpload_DeleteEvidence.Click();
        }

        public void EvidenceUpload_ConfirmDelete()
        {
            EvidenceUpload_DeleteConfirm.Click();
        }
    }
}
