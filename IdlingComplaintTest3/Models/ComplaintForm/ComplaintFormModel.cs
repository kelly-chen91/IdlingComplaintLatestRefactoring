using IdlingComplaints.Models.Home;
using IdlingComplaints.Models.Login;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumUtilities.Base;
using SeleniumUtilities.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdlingComplaints.Models.ComplaintForm
{
    internal class ComplaintFormModel : HomeModel
    {

        [OneTimeSetUp]
        public new void OneTimeSetUp()
        {
            base.OneTimeSetUp("TTseng@dep.nyc.gov", "Testing1#");
            ClickNewComplaintButton();
            Driver.WaitUntilElementFound(By.TagName("mat-radio-button"), 10);
            Driver.WaitUntilElementIsNoLongerFound(By.CssSelector("div[dir = 'ltr']"), 20);
        }
        [OneTimeTearDown]
        public new void OneTimeTearDown()
        {
            base.OneTimeTearDown();
        }

        public IWebElement YesButtonControl => Driver.FindElement(By.CssSelector("mat-radio-button[id='mat-radio-2']"));
        public IWebElement YesLabelControl =>Driver.FindElement(By.CssSelector("label[for='criteriaError']"));
        
        public IWebElement NoButtonControl => Driver.FindElement(By.CssSelector("mat-radio-button[value = 'No']"));

        /*Occurance Section*/
        public IWebElement OccuranceFromControl => Driver.FindElement(By.CssSelector("input[formcontrolname='idc_occurrencetimefrom']"));
        public IWebElement OccuranceToControl => Driver.FindElement(By.CssSelector("input[formcontrolname='idc_occurrencetimeto']"));
        public IWebElement OccuranceLocationControl => Driver.FindElement(By.CssSelector("mat-select[formcontrolname='idc_occurrencelocation']"));
        public IWebElement OccuranceHouseNumControl => Driver.FindElement(By.CssSelector("input[formcontrolname='idc_occurrencehouseno']"));
        public IWebElement OccuranceStreetNameControl => Driver.FindElement(By.CssSelector("input[formcontrolname='idc_occurrencestreet']"));
        public IWebElement OccuranceBoroughControl => Driver.FindElement(By.CssSelector("mat-select[formcontrolname='idc_occurrenceborough']"));
        public IWebElement OccuranceVehicleTypeControl => Driver.FindElement(By.CssSelector("mat-select[formcontrolname='idc_vehicletype']"));
        public IWebElement OccuranceLicensePlateControl => Driver.FindElement(By.CssSelector("input[formcontrolname='idc_licenseplate']"));
        public IWebElement OccuranceLicenseStateControl => Driver.FindElement(By.CssSelector("mat-select[formcontrolname='idc_licensestate']"));
        public IWebElement OccurancePastOffenseControl => Driver.FindElement(By.CssSelector("input[formcontrolname='idc_pastoffence']"));
        public IWebElement OccuranceSecondPastOffenseControl => Driver.FindElement(By.CssSelector("input[formcontrolname='idc_secondpastoffence']"));
        public IWebElement OccuranceInFrontOfSchoolControl => Driver.FindElement(By.CssSelector("mat-select[formcontrolname='idc_infrontofschool']"));



        public void ClickYesButton()
        {
            YesButtonControl.Click();
            
        }
        public void ClickNoButton() 
        {
            //var button = NoButtonControl.FindElement(By.TagName("input"));
            //button.Click();
            NoButtonControl.Click();
        }
    }
}
