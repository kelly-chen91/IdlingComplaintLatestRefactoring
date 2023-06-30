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
        IWebElement AppearOATH_YesControl => Driver.FindElement(By.CssSelector("mat-radio-button[value='753720001']"));
        IWebElement AppearOATH_NoControl => Driver.FindElement(By.CssSelector("mat-radio-button[value='753720000']"));
        IWebElement AppearOATH_PreviousControl => Driver.FindElement(RelativeBy.WithLocator(By.CssSelector("button[color='primary']")).Above(AppearOATH_SubmitControl));
        IWebElement AppearOATH_SubmitControl => Driver.FindElement(By.CssSelector("button[type='submit']"));
        IWebElement AppearOATH_CancelControl => Driver.FindElement(By.CssSelector("button[type='reset']"));
        IWebElement AppearOATH_UploadFormControl => Driver.FindElement(By.CssSelector("input[type='file']"));
        //IWebElement AppearOATH_ConfirmUploadFormControl => Driver.FindElement(By.CssSelector(""));

        public string AppearOATH_UploadFormInput
        {
            get
            {
                return AppearOATH_UploadFormControl.GetAttribute("value");
            }
            set
            {
                AppearOATH_UploadFormControl.SendKeys(value);
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
