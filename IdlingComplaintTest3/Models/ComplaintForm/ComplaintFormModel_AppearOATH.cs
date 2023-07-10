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
        
        public IWebElement AppearOATH_YesControl => Driver.FindElement(By.CssSelector("mat-radio-button[value='753720001']"));
        public IWebElement AppearOATH_NoControl => Driver.FindElement(By.CssSelector("mat-radio-button[value='753720000']"));

        public IWebElement AppearOATH_AffidavitLinkControl => Driver.FindElement(By.PartialLinkText("Download Summons Affidavit"));
        public IWebElement AppearOATH_AffirmationLinkControl => Driver.FindElement(By.PartialLinkText("Download Citizen Complaint"));

        public IWebElement AppearOATH_PreviousControl => Driver.FindElement(By.XPath("//affidavit-upload/form/div/div/button[1]"));
        public IWebElement AppearOATH_SubmitControl => Driver.FindElement(By.CssSelector("button[type='submit']"));
        public IWebElement AppearOATH_CancelControl => Driver.FindElement(By.CssSelector("button[type='reset']"));
        public IWebElement AppearOATH_UploadControl => Driver.FindElement(By.CssSelector("input[type='file']"));
        public IWebElement AppearOATH_ConfirmUploadControl => Driver.FindElement(By.XPath("//div[2]/button[1]"));
        public IWebElement AppearOATH_CancelUploadControl => Driver.FindElement(By.XPath("//div[2]/button[2]"));

        public string AppearOATH_UploadFormInput
        {
            get
            {
                return AppearOATH_UploadControl.GetAttribute("value");
            }
            set
            {
                AppearOATH_UploadControl.SendKeys(value);
            }
        }
        

        public void AppearOATH_ClickYes()
        {
            AppearOATH_YesControl.Click();
        }

        public void AppearOATH_ClickNo()
        {
            AppearOATH_NoControl.Click();
        }

        public void AppearOATH_ClickConfirmUpload()
        {
            AppearOATH_ConfirmUploadControl.Click();
        }

        public void AppearOATH_ClickCancelUpload()
        {
            AppearOATH_CancelUploadControl.Click();
        }

        public void AppearOATH_ClickPrevious()
        {
            AppearOATH_PreviousControl.Click();
        }

        public void AppearOATH_ClickSubmit()
        {
            AppearOATH_SubmitControl.Click();
        }

        public void AppearOATH_ClickCancel()
        {
            AppearOATH_CancelControl.Click();
        }
    }
}
