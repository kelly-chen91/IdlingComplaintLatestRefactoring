using IdlingComplaints.Models.Home;
using OpenQA.Selenium;
using SeleniumUtilities.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdlingComplaints.Models.ComplaintForm
{
    internal partial class ComplaintFormModel : HomeModel
    {
        public IWebElement YesControl => Driver.FindElement(By.CssSelector("mat-radio-button[id='mat-radio-2']"));
        public IWebElement YesLabelControl => Driver.FindElement(By.CssSelector("label[for='criteriaError']"));

        public IWebElement NoControl => Driver.FindElement(By.CssSelector("mat-radio-button[value = 'No']"));

        public IWebElement Describe_ContentControl => Driver.FindElement(By.CssSelector("textarea[formcontrolname='idc_associateddescrip']"));
        public IWebElement WitnessCertCheckboxControl => Driver.FindElement(By.CssSelector("mat-checkbox[formcontrolname='certcheckbox']"));
        public IWebElement SubmitNoCorrectionCheckboxControl => Driver.FindElement(By.CssSelector("mat-checkbox[formcontrolname='certcheckbox2']"));
        public IWebElement ComplaintInfo_CancelControl => Driver.FindElement(By.CssSelector("button[type='reset']"));
        public IWebElement ComplaintInfo_NextControl => Driver.FindElement(By.CssSelector("button[type='submit']"));
        public String DescribeTheComplaintInput
        {
            get
            {
                return Describe_ContentControl.GetAttribute("value");
            }
            set
            {
                Describe_ContentControl.SendKeys(value);
            }
        }

        /*TO-DO: SELECT DATE */
        /*Qualifying Criteria Section*/
        public void ClickYes()
        {
            YesControl.Click();

        }
        public void ClickNo()
        {
            NoControl.Click();
        }


        public void ScrollToZipCode()
        {
            Driver.ScrollTo(Associated_ZipCodeControl);
        }

        /*Acknowledgment*/

        public void ClickWitnessCheckbox()
        {
            WitnessCertCheckboxControl.Click();
        }

        public void ClickSubmitNoCorrectionCheckbox()
        {
            SubmitNoCorrectionCheckboxControl.Click();
        }

        public void ComplaintInfo_ClickNext()
        {
            ComplaintInfo_NextControl.Click();
        }

        public void ComplaintInfo_ClickCancel()
        {
            ComplaintInfo_CancelControl.Click();
        }

    }
}
