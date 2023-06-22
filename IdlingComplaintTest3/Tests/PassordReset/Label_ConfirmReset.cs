﻿using IdlingComplaints.Models.PasswordReset;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumUtilities.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IdlingComplaints.Tests.PassordReset
{
    internal class Label_ConfirmReset : PasswordResetModel
    {
        private readonly int SLEEP_TIMER = 1;

        [OneTimeSetUp]
       public new void OneTimeSetUp()
       {
    
           base.OneTimeSetUp();
           EmailInput = "TTseng@dep.nyc.gov";
           ClickResetButton();
           var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
           wait.Until(d => d.FindElement(By.CssSelector("input[formcontrolname = 'securityanswer']")));
       }
       [OneTimeTearDown]
       public new void OneTimeTearDown()
       {
           base.OneTimeTearDown();
       }


        [Test, Category("Placeholder is present.")]
        public void SecurityAnswerLabel()
        {
            var placeholder = SecurityAnswerControl.GetAttribute("placeholder");
            Assert.That(placeholder, Is.EqualTo(Constants.SECURITY_ANSWER));
        }

        [Test, Category("Placeholder is present.")]
        public void PasswordLabel()
        {

            var placeholder = PasswordControl.GetAttribute("placeholder");
            Assert.That(placeholder, Is.EqualTo(Constants.PASSWORD));
        }

        [Test, Category("Placeholder is present.")]
        public void ConfirmPasswordlLabel()
        {
             var placeholder = ConfirmPasswordControl.GetAttribute("placeholder");
             Assert.That(placeholder, Is.EqualTo(Constants.COMFIRM_PASSWORD));
        }

        [Test, Category("Require message is present.")]
        public void SecurityAnswerRequiredText()
        {
            SecurityAnswerControl.SendTextDeleteTabWithDelay("XX", SLEEP_TIMER);
            String text = Driver.ExtractTextFromXPath("/html/body/app-root/div/password-reset/form/form/div/mat-card/mat-card-content/div[2]/div[1]/mat-form-field/div/div[3]/div/mat-error/text()");
            Assert.That(text, Is.EqualTo(Constants.SECURITY_ANSWER_REQUIRED));
    
        }

       [Test, Category("Require message is present.")]
       public void PasswordRequiredText()
       {
            PasswordControl.SendTextDeleteTabWithDelay("XX", SLEEP_TIMER);
            string text =  Driver.ExtractTextFromXPath("/html/body/app-root/div/password-reset/form/form/div/mat-card/mat-card-content/div[2]/div[2]/mat-form-field/div/div[3]/div/mat-error/text()");
            Assert.That(text, Is.EqualTo(Constants.PASSWORD_REQUIRED));
        }

        [Test, Category("Require message is present.")]
        public void ConfirmPasswordRequiredText()
        {
            ConfirmPasswordControl.SendTextDeleteTabWithDelay("XX", SLEEP_TIMER);
            string text = Driver.ExtractTextFromXPath("/html/body/app-root/div/password-reset/form/form/div/mat-card/mat-card-content/div[2]/div[3]/mat-form-field/div/div[3]/div/mat-error/text()");
            Assert.That(text, Is.EqualTo(Constants.CONFIRM_PASSWORD_REQUIRED));
        }


    }
}
