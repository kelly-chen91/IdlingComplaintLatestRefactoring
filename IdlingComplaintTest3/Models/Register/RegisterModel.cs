using SeleniumUtilities.Base;
using SeleniumUtilities.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Text.RegularExpressions;

namespace IdlingComplaints.Models.Register
{
    internal class RegisterModel : BaseModel
    {
        public RegisterModel()
        {
        }
        //[LoginModelSetUp]
        public void RegisterModelSetUp(bool isHeadless)
        {
            if (isHeadless) Driver = CreateHeadlessDriver("chrome");
            else Driver = CreateStandardDriver("chrome");
            Driver.Navigate().GoToUrl("https://nycidling-dev.azurewebsites.net/profile");
            Driver.Manage().Window.Size = new Size(1920, 1200);
        }
        //[LoginModelTearDown]
        public void RegisterModelTearDown()
        {
            Driver.Quit();
        }


        public IWebElement TitleControl => Driver.FindElement(By.TagName("h4"));                                                                       //Title
        public IWebElement FirstNameControl => Driver.FindElement(By.CssSelector("input[formcontrolname = 'firstname']"));                            //First Name
        public IWebElement LastNameControl => Driver.FindElement(By.CssSelector("input[formcontrolname = 'lastname']"));                              //Last Name
        public IWebElement EmailControl => Driver.FindElement(By.CssSelector("input[formcontrolname = 'emailaddress1']"));                            //Email
        public IWebElement PasswordControl => Driver.FindElement(By.CssSelector("input[formcontrolname = 'idc_password']"));                          //Password
        public IWebElement ConfirmPasswordControl => Driver.FindElement(By.CssSelector("input[formcontrolname = 'confirmPassword']"));                 //Confirm Password
        public IWebElement SecurityQuestionControl => Driver.FindElement(By.CssSelector("mat-select[formcontrolname = '_idc_securityquestion_value']"));    //Security Question                                                                                                     
        public IWebElement SecurityAnswerControl => Driver.FindElement(By.CssSelector("input[formcontrolname = 'idc_securityanswer']"));              //Security Answer
        public IWebElement Address1Control => Driver.FindElement(By.CssSelector("input[formcontrolname = 'address1_line1']"));                        //Address1
        public IWebElement Address2Control => Driver.FindElement(By.CssSelector("input[formcontrolname = 'address1_line2']"));                        //Address2
        public IWebElement CityControl => Driver.FindElement(By.CssSelector("input[formcontrolname = 'address1_city']"));                             //City
        public IWebElement StateControl => Driver.FindElement(By.CssSelector("mat-select[formcontrolname = 'address1_stateorprovince']"));                 //State                                                                                                 
        public IWebElement StateOptionsControl => Driver.FindElement(By.Id("mat-select-0-panel"));
        public IWebElement ZipCodeControl => Driver.FindElement(By.CssSelector("input[formcontrolname = 'address1_postalcode']"));                    //Zip Code
        public IWebElement TelephoneControl => Driver.FindElement(By.CssSelector("input[formcontrolname = 'address1_telephone1']"));                  //Telephone
        public IWebElement SubmitButtonControl => Driver.FindElement(By.CssSelector("button[color = 'primary']"));                                    //Submit Button
        public IWebElement CancelButtonControl => Driver.FindElement(By.CssSelector("button[type = 'reset']"));                                       //Cancel Button

        public string selectedSecurityQuestionControl = "--";
        public string selectedStateControl = "--";

   //  public List<string> securityQuestionList;
   //  public List<IWebElement> securityQuestionElementList;
   //
   //  public List<string> stateOptionList;
   //  public List<IWebElement> stateOptionElementList;


        public string FirstNameInput
        {
            get
            {
                return FirstNameControl.GetAttribute("value");
            }
            set
            {
                FirstNameControl.SendKeys(value);
            }
        }

        public string LastNameInput
        {
            get
            {
                return LastNameControl.GetAttribute("value");
            }
            set
            {
                LastNameControl.SendKeys(value);
            }
        }

        public string EmailInput
        {
            get
            {
                return EmailControl.GetAttribute("value");
            }
            set
            {
                EmailControl.SendKeys(value);
            }
        }

        public string PasswordInput
        {
            get
            {
                return PasswordControl.GetAttribute("value");
            }
            set
            {
                PasswordControl.SendKeys(value);
            }
        }

        public string ConfirmPasswordInput
        {
            get
            {
                return ConfirmPasswordControl.GetAttribute("value");
            }
            set
            {
                ConfirmPasswordControl.SendKeys(value);
            }
        }

        public string SecurityAnswerInput
        {
            get
            {
                return SecurityAnswerControl.GetAttribute("value");
            }
            set
            {
                SecurityAnswerControl.SendKeys(value);
            }
        }

        public string Address1Input
        {
            get
            {
                return Address1Control.GetAttribute("value");
            }
            set
            {
                Address1Control.SendKeys(value);
            }
        }

        public string Address2Input
        {
            get
            {
                return Address2Control.GetAttribute("value");
            }
            set
            {
                Address2Control.SendKeys(value);
            }
        }

        public string CityInput
        {
            get
            {
                return CityControl.GetAttribute("value");
            }
            set
            {
                CityControl.SendKeys(value);
            }
        }

        public string ZipCodeInput
        {
            get
            {
                return ZipCodeControl.GetAttribute("value");
            }
            set
            {
                ZipCodeControl.SendKeys(value);
            }
        }

        public string PhoneInput
        {
            get
            {
                return TelephoneControl.GetAttribute("value");
            }
            set
            {
                TelephoneControl.SendKeys(value);
            }
        }



        public void SelectSecurityQuestion(int questionIndex)
        {
            SecurityQuestionControl.Click();
            var security = Driver.FindElement(By.Id("mat-select-1-panel"));
            var optionElementList = security.FindElements(By.TagName("span"));
            Thread.Sleep(1000);
            List<string> questionList = optionElementList.ConvertOptionToText();
            if (questionIndex >= questionList.Count || questionIndex < 0) return;
            optionElementList[questionIndex].Click();
            selectedSecurityQuestionControl = questionList[questionIndex];
            Thread.Sleep(1000);
        }


        public void SelectState(int stateIndex)
        {
            StateControl.Click();
            var optionElementList = StateOptionsControl.FindElements(By.TagName("span"));
            Thread.Sleep(1000);
            List<string> stateList = optionElementList.ConvertOptionToText();
            if (stateIndex >= stateList.Count || stateIndex < 0) return;
            optionElementList[stateIndex].Click();
            selectedStateControl = stateList[stateIndex];
            Thread.Sleep(1000);
        }


        /*Buttons*/
        public void ClickSubmitButton()
        {
            SubmitButtonControl.Click();
        }

        public void ClickCancelButton()
        {
            CancelButtonControl.Click();
        }

        public void ScrollToButton()
        {
            Driver.ScrollTo(SubmitButtonControl);
        }
    }
}
