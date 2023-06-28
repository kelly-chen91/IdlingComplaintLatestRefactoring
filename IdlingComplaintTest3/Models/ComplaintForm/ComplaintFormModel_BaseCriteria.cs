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
        public IWebElement YesButtonControl => Driver.FindElement(By.CssSelector("mat-radio-button[id='mat-radio-2']"));
        public IWebElement YesLabelControl => Driver.FindElement(By.CssSelector("label[for='criteriaError']"));

        public IWebElement NoButtonControl => Driver.FindElement(By.CssSelector("mat-radio-button[value = 'No']"));

        /*TO-DO: SELECT DATE */
        public void ClickYesButton()
        {
            YesButtonControl.Click();

        }
        public void ClickNoButton()
        {
            NoButtonControl.Click();
        }

        public void ClickNPOBoxButton()
        {

            NoButtonControl.Click();
        }
        public void ScrollToZipCode()
        {
            Driver.ScrollTo(Associated_ZipCodeControl);
        }

    }
}
