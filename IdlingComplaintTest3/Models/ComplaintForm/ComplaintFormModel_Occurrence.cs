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

        public String Occurrence_OnStreetInput
        {
            get
            {
                return Occurrence_OnStreetControl.GetAttribute("value");
            }
            set
            {
                Occurrence_OnStreetControl.SendKeys(value);
            }
        }

        public String Occurrence_CrossStreet1Input
        {
            get
            {
                return Occurrence_CrossStreet1Control.GetAttribute("value");
            }
            set
            {
                Occurrence_CrossStreet1Control.SendKeys(value);
            }
        }

        public String Occurrence_CrossStreet2Input
        {
            get
            {
                return Occurrence_CrossStreet2Control.GetAttribute("value");
            }
            set
            {
                Occurrence_CrossStreet2Control.SendKeys(value);
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

        public void ScrollToLicensePlate()
        {
            Driver.ScrollTo(Occurrence_LicensePlateControl);
        }
    }
}
