using IdlingComplaints.Models.PasswordReset;
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
<<<<<<<< HEAD:IdlingComplaintTest3/Tests/PasswordReset/Test60_Label_ConfirmReset.cs
    internal class Test60_Label_ConfirmReset : PasswordResetModel
========
    internal class Test50_Label_ConfirmReset : PasswordResetModel
>>>>>>>> e818ac622b927c70ddffb813c1daa44051f9ae3f:IdlingComplaintTest3/Tests/PasswordReset/Test50_Label_ConfirmReset.cs
    {
        private readonly int SLEEP_TIMER = 2;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {

            base.PasswordResetModelSetUp(true);

            Driver.Manage().Window.Position = new Point(-2000, 0);
            EmailInput = "TTseng@dep.nyc.gov";
            ClickResetButton();
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.CssSelector("input[formcontrolname = 'securityanswer']")));
        }
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            base.PasswordResetModelTearDown();
        }


        [Test, Category("Placeholder is present.")]
        public void DisplaySecurityAnswer()
        {
            var placeholder = SecurityAnswerControl.GetAttribute("placeholder");
            Assert.That(placeholder, Is.EqualTo(Constants.SECURITY_ANSWER));
        }

        [Test, Category("Placeholder is present.")]
        public void DisplayPassword()
        {

            var placeholder = PasswordControl.GetAttribute("placeholder");
            Assert.That(placeholder, Is.EqualTo(Constants.PASSWORD));
        }

        [Test, Category("Placeholder is present.")]
        public void DisplayConfirmPassword()
        {
            var placeholder = ConfirmPasswordControl.GetAttribute("placeholder");
            Assert.That(placeholder, Is.EqualTo(Constants.COMFIRM_PASSWORD));
        }

        [Test, Category("Require message is present.")]
        public void RequiredSecurityAnswer()
        {
            SecurityAnswerControl.SendTextDeleteTabWithDelay("XX", SLEEP_TIMER);
            String text = Driver.ExtractTextFromXPath("/html/body/app-root/div/password-reset/form/form/div/mat-card/mat-card-content/div[2]/div[1]/mat-form-field/div/div[3]/div/mat-error/text()");
            Assert.That(text, Is.EqualTo(Constants.SECURITY_ANSWER_REQUIRED));

        }

        [Test, Category("Require message is present.")]
        public void RequirePassword()
        {
            PasswordControl.SendTextDeleteTabWithDelay("XX", SLEEP_TIMER);
            string text = Driver.ExtractTextFromXPath("/html/body/app-root/div/password-reset/form/form/div/mat-card/mat-card-content/div[2]/div[2]/mat-form-field/div/div[3]/div/mat-error/text()");
            Assert.That(text, Is.EqualTo(Constants.PASSWORD_REQUIRED));
        }

        [Test, Category("Require message is present.")]
        public void RequiredConfirmPassword()
        {
            ConfirmPasswordControl.SendTextDeleteTabWithDelay("XX", SLEEP_TIMER);
            string text = Driver.ExtractTextFromXPath("/html/body/app-root/div/password-reset/form/form/div/mat-card/mat-card-content/div[2]/div[3]/mat-form-field/div/div[3]/div/mat-error/text()");
            Assert.That(text, Is.EqualTo(Constants.CONFIRM_PASSWORD_REQUIRED));
        }


    }
}
