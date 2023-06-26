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
        public IWebElement YesLabelControl => Driver.FindElement(By.CssSelector("label[for='criteriaError']"));

        public IWebElement NoButtonControl => Driver.FindElement(By.CssSelector("mat-radio-button[value = 'No']"));

        /*Person or Company Associated to the Complaint Section*/
        public IWebElement CompanyNameControl => Driver.FindElement(By.CssSelector("input[placeholder='Company Name']"));
        public IWebElement StateControl => Driver.FindElement(By.CssSelector("input[placeholder='State']"));

        public IWebElement HouseNumberControl => Driver.FindElement(By.CssSelector("input[placeholder='House Number']"));
        public IWebElement StreetNameControl => Driver.FindElement(By.CssSelector("input[placeholder='Street Name/P. O. Box']"));

        public IWebElement AptFloorControl => Driver.FindElement(By.CssSelector("input[placeholder='Apt/Floor/Suite/Unit']"));
        public IWebElement CityControl => Driver.FindElement(By.CssSelector("input[placeholder='City]"));
        public IWebElement ZipCodeControl => Driver.FindElement(By.CssSelector("input[placeholder='Zip']"));
        //public IWebElement AptFloorControl => Driver.FindElement(By.CssSelector("input[placeholder='Apt/Floor/Suite/Unit']"));

        /*Occurance Section*/
        public IWebElement OccurenceFromControl => Driver.FindElement(By.CssSelector("input[formcontrolname='idc_occurrencetimefrom']"));
        public IWebElement OccurenceToControl => Driver.FindElement(By.CssSelector("input[formcontrolname='idc_occurrencetimeto']"));
        public IWebElement OccurenceLocationControl => Driver.FindElement(By.CssSelector("mat-select[formcontrolname='idc_occurrencelocation']"));
        public IWebElement OccurenceHouseNumControl => Driver.FindElement(By.CssSelector("input[formcontrolname='idc_occurrencehouseno']"));
        public IWebElement OccurenceStreetNameControl => Driver.FindElement(By.CssSelector("input[formcontrolname='idc_occurrencestreet']"));
        public IWebElement OccurenceBoroughControl => Driver.FindElement(By.CssSelector("mat-select[formcontrolname='idc_occurrenceborough']"));
        public IWebElement OccurenceVehicleTypeControl => Driver.FindElement(By.CssSelector("mat-select[formcontrolname='idc_vehicletype']"));
        public IWebElement OccurenceLicensePlateControl => Driver.FindElement(By.CssSelector("input[formcontrolname='idc_licenseplate']"));
        public IWebElement OccurenceLicenseStateControl => Driver.FindElement(By.CssSelector("mat-select[formcontrolname='idc_licensestate']"));
        public IWebElement OccurencePastOffenseControl => Driver.FindElement(By.CssSelector("input[formcontrolname='idc_pastoffence']"));
        public IWebElement OccurenceSecondPastOffenseControl => Driver.FindElement(By.CssSelector("input[formcontrolname='idc_secondpastoffence']"));
        public IWebElement OccurenceInFrontOfSchoolControl => Driver.FindElement(By.CssSelector("mat-select[formcontrolname='idc_infrontofschool']"));

        public string selectedOccurenceLocation = "--", selectedOccurenceBorough = "--", selectedOccurenceVehicleType = "--", selectedOccurenceLicenseState = "--";
        public string selectedOccurenceInFrontOfSchool = "--";




        public void ClickYesButton()
        {
            YesButtonControl.Click();

        }
        public void ClickNoButton()
        {
            NoButtonControl.Click();
        }

        public String OccurenceFromInput
        {
            get
            {
                return OccurenceFromControl.GetAttribute("value");
            }
            set
            {
                OccurenceFromControl.SendKeys(value);
            }
        }

        public String OccurenceToInput
        {
            get
            {
                return OccurenceToControl.GetAttribute("value");
            }
            set
            {
                OccurenceToControl.SendKeys(value);
            }
        }

        public String OccurenceHouseNumInput
        {
            get
            {
                return OccurenceHouseNumControl.GetAttribute("value");
            }
            set
            {
                OccurenceHouseNumControl.SendKeys(value);
            }
        }

        public String OccurenceStreetInput
        {
            get
            {
                return OccurenceStreetNameControl.GetAttribute("value");
            }
            set
            {
                OccurenceStreetNameControl.SendKeys(value);
            }
        }

        public String OccurenceLicensePlateInput
        {
            get
            {
                return OccurenceLicensePlateControl.GetAttribute("value");
            }
            set
            {
                OccurenceLicensePlateControl.SendKeys(value);
            }
        }

        public String OccurencePastOffenceInput
        {
            get
            {
                return OccurencePastOffenseControl.GetAttribute("value");
            }
            set
            {
                OccurencePastOffenseControl.SendKeys(value);
            }
        }

        public String OccurenceSecondPastOffenceInput
        {
            get
            {
                return OccurenceSecondPastOffenseControl.GetAttribute("value");
            }
            set
            {
                OccurenceSecondPastOffenseControl.SendKeys(value);
            }
        }

        /*DROPDOWN OPTIONS*/
        public void SelectOccurenceLocation(int locationIndex)
        {
            OccurenceLocationControl.Click();
            var location = OccurenceLocationControl.FindElement(By.Id("mat-select-3-panel"));
            var optionElementList = location.FindElements(By.TagName("span"));

            Thread.Sleep(1000);
            List<string> locationList = optionElementList.ConvertOptionToText();
            optionElementList[locationIndex].Click();
            if (locationIndex < 0 || locationIndex >= locationList.Count) { return; }
            selectedOccurenceLocation = locationList[locationIndex];
            Thread.Sleep(1000);
        }

        public void SelectOccurenceBorough(int boroughIndex)
        {
            OccurenceBoroughControl.Click();
            var borough = OccurenceBoroughControl.FindElement(By.Id("mat-select-5-panel"));
            var optionElementList = borough.FindElements(By.TagName("span"));

            Thread.Sleep(1000);
            List<string> boroughList = optionElementList.ConvertOptionToText();
            optionElementList[boroughIndex].Click();
            if (boroughIndex < 0 || boroughIndex >= boroughList.Count) { return; }
            selectedOccurenceBorough = boroughList[boroughIndex];
            Thread.Sleep(1000);
        }

        public void SelectOccurenceVehicleType(int vehicleIndex)
        {
            OccurenceVehicleTypeControl.Click();
            var vehicleType = OccurenceVehicleTypeControl.FindElement(By.Id("mat-select-6-panel"));
            var optionElementList = vehicleType.FindElements(By.TagName("span"));

            Thread.Sleep(1000);
            List<string> vehicleTypeList = optionElementList.ConvertOptionToText();
            optionElementList[vehicleIndex].Click();
            if (vehicleIndex < 0 || vehicleIndex >= vehicleTypeList.Count) { return; }
            selectedOccurenceVehicleType = vehicleTypeList[vehicleIndex];
            Thread.Sleep(1000);
        }

        public void SelectOccurenceLicenseState(int licenseStateIndex)
        {
            OccurenceLicenseStateControl.Click();
            var licenseState = OccurenceLicenseStateControl.FindElement(By.Id("mat-select-7-panel"));
            var optionElementList = licenseState.FindElements(By.TagName("span"));

            Thread.Sleep(1000);
            List<string> licenseStateList = optionElementList.ConvertOptionToText();
            optionElementList[licenseStateIndex].Click();
            if (licenseStateIndex < 0 || licenseStateIndex >= licenseStateList.Count) { return; }
            selectedOccurenceLicenseState = licenseStateList[licenseStateIndex];
            Thread.Sleep(1000);
        }

        public void SelectOccurenceInFrontOfSchool(int inFrontOfSchoolIndex)
        {
            OccurenceInFrontOfSchoolControl.Click();
            var inFrontOfSchool = OccurenceInFrontOfSchoolControl.FindElement(By.Id("mat-select-8-panel"));
            var optionElementList = inFrontOfSchool.FindElements(By.TagName("span"));

            Thread.Sleep(1000);
            List<string> inFrontOfSchoolList = optionElementList.ConvertOptionToText();
            optionElementList[inFrontOfSchoolIndex].Click();
            if (inFrontOfSchoolIndex < 0 || inFrontOfSchoolIndex >= inFrontOfSchoolList.Count) { return; }
            selectedOccurenceInFrontOfSchool = inFrontOfSchoolList[inFrontOfSchoolIndex];
            Thread.Sleep(1000);
        }



        /*TO-DO: SELECT DATE */

        
    }
}
