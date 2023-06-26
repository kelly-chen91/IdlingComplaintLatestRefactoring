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


        /*Person or Company Associated to the Complaint*/
        public IWebElement Associated_CompanyNameControl => Driver.FindElement(By.CssSelector("input[formcontrolname='idc_associatedlastname']"));
        public IWebElement Associated_StateControl => Driver.FindElement(By.CssSelector("mat-select[formcontrolname='idc_associatedstate']"));
     

        public IWebElement Associated_HouseNumberControl => Driver.FindElement(By.CssSelector("input[formcontrolname='idc_associatedhouseno']"));
        public IWebElement Associated_StreetNameControl => Driver.FindElement(By.CssSelector("input[formcontrolname='idc_associatedstreet']"));

        public IWebElement Associated_AptFloorControl => Driver.FindElement(By.CssSelector("input[formcontrolname='idc_associatedstreet2']"));
        public IWebElement Associated_CityControl => Driver.FindElement(By.CssSelector("input[formcontrolname='idc_associatedcity']"));
        public IWebElement Associated_ZipCodeControl => Driver.FindElement(By.CssSelector("input[formcontrolname='idc_associatedzip']"));

        public IWebElement Associated_RequireCompanyNameControl => Associated_CompanyNameControl.FindElement(By.TagName("mat-error"));

        public IWebElement Associated_RequireStateControl => Driver.FindElement(By.CssSelector("mat-error[id='mat-error-11']"));

        public IWebElement Associated_RequireHouseNumberControl => Driver.FindElement(By.CssSelector("mat-error[id='mat-error-24']"));
        public IWebElement Associated_RequireStreetNameControl => Driver.FindElement(By.CssSelector("mat-error[id='mat-error-12']"));
     //
     //   public IWebElement? RequireAptFloorControl => null;
     //   public IWebElement RequireCityControl => Driver.FindElement(By.CssSelector("mat-error[id='mat-error-14']"));
     //   public IWebElement RequireZipCodeControl => Driver.FindElement(By.CssSelector("mat-error[id='mat-error-15']"));
        public string associated_SelectedStateControl = "--";
        public string CompanyNameInput
        {
            get
            {
                return Associated_CompanyNameControl.GetAttribute("value");
            }
            set
            {
                Associated_CompanyNameControl.SendKeys(value);
            }
        }
        public string HouseNumberInput
        {
            get
            {
                return Associated_HouseNumberControl.GetAttribute("value");
            }
            set
            {
                Associated_HouseNumberControl.SendKeys(value);
            }
        }
        public string StreetNameInput
        {
            get
            {
                return Associated_StreetNameControl.GetAttribute("value");
            }
            set
            {
                Associated_StreetNameControl.SendKeys(value);
            }
        }
        public string AptFloorInput
        {
            get
            {
                return Associated_AptFloorControl.GetAttribute("value");
            }
            set
            {
                Associated_AptFloorControl.SendKeys(value);
            }
        }
        public string CityInput
        {
            get
            {
                return Associated_CityControl.GetAttribute("value");
            }
            set
            {
                Associated_CityControl.SendKeys(value);
            }
        }
        public string ZipInput
        {
            get
            {
                return Associated_ZipCodeControl.GetAttribute("value");
            }
            set
            {
                Associated_ZipCodeControl.SendKeys(value);
            }
        }


        public void SelectState(int stateIndex)
        {
            Associated_StateControl.Click();
            var optionElementList = Associated_StateControl.FindElements(By.TagName("span"));
            Thread.Sleep(1000);
            List<string> stateList = optionElementList.ConvertOptionToText();
            if (stateIndex >= stateList.Count || stateIndex < 0) return;
            optionElementList[stateIndex].Click();
            associated_SelectedStateControl = stateList[stateIndex];
            Thread.Sleep(1000);
        }








        /*Occurance Section*/
        public IWebElement OccurenceFromControl => Driver.FindElement(By.CssSelector("input[formcontrolname='idc_occurrencetimefrom']"));
        public IWebElement OccurenceToControl => Driver.FindElement(By.CssSelector("input[formcontrolname='idc_occurrencetimeto']"));
        public IWebElement OccurenceLocationControl => Driver.FindElement(By.CssSelector("mat-select[formcontrolname='idc_occurrencelocation']"));
        public IWebElement OccurenceHouseNumControl => Driver.FindElement(By.CssSelector("input[formcontrolname='idc_occurrencehouseno']"));
        public IWebElement OccurenceStreetNameControl => Driver.FindElement(By.CssSelector("input[formcontrolname='idc_occurrencestreet']"));
        public IWebElement OccurenceStateControl => Driver.FindElement(By.CssSelector("mat-select[formcontrolname='idc_occurrencestate']"));
        public IWebElement OccurenceBoroughControl => Driver.FindElement(By.CssSelector("mat-select[formcontrolname='idc_occurrenceborough']"));
        public IWebElement OccurenceVehicleTypeControl => Driver.FindElement(By.CssSelector("mat-select[formcontrolname='idc_vehicletype']"));
        public IWebElement OccurenceLicensePlateControl => Driver.FindElement(By.CssSelector("input[formcontrolname='idc_licenseplate']"));
        public IWebElement OccurenceLicenseStateControl => Driver.FindElement(By.CssSelector("mat-select[formcontrolname='idc_licensestate']"));
        public IWebElement OccurencePastOffenseControl => Driver.FindElement(By.CssSelector("input[formcontrolname='idc_pastoffence']"));
        public IWebElement OccurenceSecondPastOffenseControl => Driver.FindElement(By.CssSelector("input[formcontrolname='idc_secondpastoffence']"));
        public IWebElement OccurenceInFrontOfSchoolControl => Driver.FindElement(By.CssSelector("mat-select[formcontrolname='idc_infrontofschool']"));
        public IWebElement OccurenceAdminCodeControl => Driver.FindElement(By.CssSelector("input[formcontrolname='idc_occurrencesectioncode']"));


        public string selectedOccurenceLocation = "--", selectedOccurenceBorough = "--", selectedOccurenceVehicleType = "--", selectedOccurenceLicenseState = "--";
        public string selectedOccurenceInFrontOfSchool = "--";

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
