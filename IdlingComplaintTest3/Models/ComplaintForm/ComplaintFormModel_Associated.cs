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
    internal partial class ComplaintFormModel : HomeModel
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








        


        


        
    }
}
