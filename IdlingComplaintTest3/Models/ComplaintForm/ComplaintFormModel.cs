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

        public string associated_SelectedStateControl = "--";

        //  Lable from Describe the complaint section
       // public IWebElement Describe_TitleControl => Driver.FindElement(By.Extra("mat-error[id='mat-error-11']"));

        public IWebElement Describe_ContentControl => Driver.FindElement(By.CssSelector("textarea[formcontrolname='idc_associateddescrip']"));



        public string Associated_CompanyNameInput
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
        public string Associated_HouseNumberInput
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
        public string Associated_StreetNameInput
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
        public string Associated_AptFloorInput
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
        public string Associated_CityInput
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
        public string Associated_ZipInput
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


        public void Associated_SelectState(int stateIndex)
        {
            Associated_StateControl.Click();
            var state = Driver.FindElement(By.Id("mat-select-2-panel"));
            var optionElementList = state.FindElements(By.TagName("span"));
            Thread.Sleep(1000);
            List<string> stateList = optionElementList.ConvertOptionToText();
            if (stateIndex >= stateList.Count || stateIndex < 0) return;
            optionElementList[stateIndex].Click();
            associated_SelectedStateControl = stateList[stateIndex];
            Thread.Sleep(1000);
        }








        /*Occurance Section*/
        public IWebElement Occurrence_FromControl => Driver.FindElement(By.CssSelector("input[formcontrolname='idc_occurrencetimefrom']"));
        public IWebElement Occurrence_ToControl => Driver.FindElement(By.CssSelector("input[formcontrolname='idc_occurrencetimeto']"));
        public IWebElement Occurrence_LocationControl => Driver.FindElement(By.CssSelector("mat-select[formcontrolname='idc_occurrencelocation']"));
        public IWebElement Occurrence_HouseNumControl => Driver.FindElement(By.CssSelector("input[formcontrolname='idc_occurrencehouseno']"));
        public IWebElement Occurrence_StreetNameControl => Driver.FindElement(By.CssSelector("input[formcontrolname='idc_occurrencestreet']"));
        public IWebElement Occurrence_OnStreetControl => Driver.FindElement(By.CssSelector("input[formcontrolname='idc_onstreet']"));
        public IWebElement Occurrence_CrossStreet1Control => Driver.FindElement(By.CssSelector("input[formcontrolname='idc_crossstreet1']"));
        public IWebElement Occurrence_CrossStreet2Control => Driver.FindElement(By.CssSelector("input[formcontrolname='idc_crossstreet2']"));

        public IWebElement Occurrence_StateControl => Driver.FindElement(By.CssSelector("mat-select[formcontrolname='idc_occurrencestate']"));
        public IWebElement Occurrence_BoroughControl => Driver.FindElement(By.CssSelector("mat-select[formcontrolname='idc_occurrenceborough']"));
        public IWebElement Occurrence_VehicleTypeControl => Driver.FindElement(By.CssSelector("mat-select[formcontrolname='idc_vehicletype']"));
        public IWebElement Occurrence_LicensePlateControl => Driver.FindElement(By.CssSelector("input[formcontrolname='idc_licenseplate']"));
        public IWebElement Occurrence_LicenseStateControl => Driver.FindElement(By.CssSelector("mat-select[formcontrolname='idc_licensestate']"));
        public IWebElement Occurrence_PastOffenseControl => Driver.FindElement(By.CssSelector("input[formcontrolname='idc_pastoffence']"));
        public IWebElement Occurrence_SecondPastOffenseControl => Driver.FindElement(By.CssSelector("input[formcontrolname='idc_secondpastoffence']"));
        public IWebElement Occurrence_InFrontOfSchoolControl => Driver.FindElement(By.CssSelector("mat-select[formcontrolname='idc_infrontofschool']"));
        public IWebElement Occurrence_SchoolNameControl => Driver.FindElement(By.CssSelector("input[formcontrolname='idc_schoolname']"));
        public IWebElement Occurrence_AdminCodeControl => Driver.FindElement(By.CssSelector("input[formcontrolname='idc_occurrencesectioncode']"));


        public string selectedOccurrenceLocation = "--", selectedOccurrenceBorough = "--", selectedOccurrenceVehicleType = "--", selectedOccurrenceLicenseState = "--";
        public string selectedOccurrenceInFrontOfSchool = "--";

        public String Occurrence_FromInput
        {
            get
            {
                return Occurrence_FromControl.GetAttribute("value");
            }
            set
            {
                Occurrence_FromControl.SendKeys(value);
            }
        }

        public String Occurrence_ToInput
        {
            get
            {
                return Occurrence_ToControl.GetAttribute("value");
            }
            set
            {
                Occurrence_ToControl.SendKeys(value);
            }
        }

        public String Occurrence_HouseNumInput
        {
            get
            {
                return Occurrence_HouseNumControl.GetAttribute("value");
            }
            set
            {
                Occurrence_HouseNumControl.SendKeys(value);
            }
        }

        public String Occurrence_StreetInput
        {
            get
            {
                return Occurrence_StreetNameControl.GetAttribute("value");
            }
            set
            {
                Occurrence_StreetNameControl.SendKeys(value);
            }
        }

        public String Occurrence_LicensePlateInput
        {
            get
            {
                return Occurrence_LicensePlateControl.GetAttribute("value");
            }
            set
            {
                Occurrence_LicensePlateControl.SendKeys(value);
            }
        }

        public String Occurrence_PastOffenceInput
        {
            get
            {
                return Occurrence_PastOffenseControl.GetAttribute("value");
            }
            set
            {
                Occurrence_PastOffenseControl.SendKeys(value);
            }
        }

        public String Occurrence_SecondPastOffenceInput
        {
            get
            {
                return Occurrence_SecondPastOffenseControl.GetAttribute("value");
            }
            set
            {
                Occurrence_SecondPastOffenseControl.SendKeys(value);
            }
        }

        /*DROPDOWN OPTIONS*/
        public void Occurrence_SelectLocation(int locationIndex)
        {
            Occurrence_LocationControl.Click();
            var location = Driver.FindElement(By.Id("mat-select-3-panel"));
            var optionElementList = location.FindElements(By.TagName("span"));

            Thread.Sleep(1000);
            List<string> locationList = optionElementList.ConvertOptionToText();
            optionElementList[locationIndex].Click();
            if (locationIndex < 0 || locationIndex >= locationList.Count) { return; }
            selectedOccurrenceLocation = locationList[locationIndex];
            Thread.Sleep(1000);
        }

        public void Occurrence_SelectBorough(int boroughIndex)
        {
            Occurrence_BoroughControl.Click();
            var borough = Driver.FindElement(By.Id("mat-select-5-panel"));
            var optionElementList = borough.FindElements(By.TagName("span"));

            Thread.Sleep(1000);
            List<string> boroughList = optionElementList.ConvertOptionToText();
            optionElementList[boroughIndex].Click();
            if (boroughIndex < 0 || boroughIndex >= boroughList.Count) { return; }
            selectedOccurrenceBorough = boroughList[boroughIndex];
            Thread.Sleep(1000);
        }

        public void Occurrence_SelectVehicleType(int vehicleIndex)
        {
            Occurrence_VehicleTypeControl.Click();
            var vehicleType = Driver.FindElement(By.Id("mat-select-6-panel"));
            var optionElementList = vehicleType.FindElements(By.TagName("span"));

            Thread.Sleep(1000);
            List<string> vehicleTypeList = optionElementList.ConvertOptionToText();
            optionElementList[vehicleIndex].Click();
            if (vehicleIndex < 0 || vehicleIndex >= vehicleTypeList.Count) { return; }
            selectedOccurrenceVehicleType = vehicleTypeList[vehicleIndex];
            Thread.Sleep(1000);
        }

        public void Occurrence_SelectLicenseState(int licenseStateIndex)
        {
            Occurrence_LicenseStateControl.Click();
            var licenseState = Driver.FindElement(By.Id("mat-select-7-panel"));
            var optionElementList = licenseState.FindElements(By.TagName("span"));

            Thread.Sleep(1000);
            List<string> licenseStateList = optionElementList.ConvertOptionToText();
            optionElementList[licenseStateIndex].Click();
            if (licenseStateIndex < 0 || licenseStateIndex >= licenseStateList.Count) { return; }
            selectedOccurrenceLicenseState = licenseStateList[licenseStateIndex];
            Thread.Sleep(1000);
        }

        public void Occurrence_SelectInFrontOfSchool(int inFrontOfSchoolIndex)
        {
            Occurrence_InFrontOfSchoolControl.Click();
            var inFrontOfSchool = Driver.FindElement(By.Id("mat-select-8-panel"));
            var optionElementList = inFrontOfSchool.FindElements(By.TagName("span"));

            Thread.Sleep(1000);
            List<string> inFrontOfSchoolList = optionElementList.ConvertOptionToText();
            optionElementList[inFrontOfSchoolIndex].Click();
            if (inFrontOfSchoolIndex < 0 || inFrontOfSchoolIndex >= inFrontOfSchoolList.Count) { return; }
            selectedOccurrenceInFrontOfSchool = inFrontOfSchoolList[inFrontOfSchoolIndex];
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
