using IdlingComplaints.Models.PasswordReset;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;
using SeleniumUtilities.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace IdlingComplaints.Tests.PassordReset
{
    internal class Test50_PasswordResetFunctionality : PasswordResetModel
    {
        private readonly int SLEEP_TIMER = 2000;

        [SetUp]
        public void Setup()
        {
            Driver.Quit();
            Driver = CreateDriver("chrome");
            Driver.Navigate().GoToUrl("https://nycidling-dev.azurewebsites.net/password-reset");
            EmailControl.SendKeysWithDelay("TTseng@dep.nyc.gov", SLEEP_TIMER);
            ClickResetButton();
            Driver.Manage().Window.Size = new Size(1920, 1200);
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.CssSelector("input[formcontrolname = 'securityanswer']")));

        }
        [TearDown]
        public void TearDown()
        {
            if (SLEEP_TIMER > 0)
                Thread.Sleep(SLEEP_TIMER);
            Driver.Quit();
        }

        [Test, Category("Valid Reset")]
        public void SuccessfulPasswordReset()
        {
            SecurityAnswerControl.SendKeysWithDelay("pet", SLEEP_TIMER);
            PasswordControl.SendKeysWithDelay("Testing1#", SLEEP_TIMER);
            ConfirmPasswordControl.SendKeysWithDelay("Testing1#", SLEEP_TIMER);
            ClickSubmitButton();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            wait.Until(d =>
            {
                var resetControl = d.FindElement(By.TagName("simple-snack-bar")).FindElement(By.TagName("span"));

                Assert.IsNotNull(resetControl);
                Assert.That(resetControl.Text.Trim(), Is.EqualTo("Password has been reset successfully."));

                return resetControl;
            });
        }

        [Test, Category("Invalid Reset")]
        public void FailedPasswordReset()
        {
            SecurityAnswerControl.SendKeysWithDelay("XX", SLEEP_TIMER);
            PasswordControl.SendKeysWithDelay("Testing1#", SLEEP_TIMER);
            ConfirmPasswordControl.SendKeysWithDelay("Testing1#", SLEEP_TIMER);
            ClickSubmitButton();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            wait.Until(d =>
            {
                var resetControl = d.FindElement(By.TagName("simple-snack-bar")).FindElement(By.TagName("span"));

                Assert.IsNotNull(resetControl);
                Assert.That(resetControl.Text.Trim(), Is.EqualTo("Security answer is not correct."));

                return resetControl;
            });
        }

        [Test, Category("Cancel Reset")]
        public void CancelPasswordReset()
        {
            ClickCancelButton();
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(d =>
            {
                var TitleControl = d.FindElement(By.TagName("h3"));

                Assert.IsNotNull(TitleControl);
                Assert.That(TitleControl.Text.Trim(), Is.EqualTo("NYC Idling Complaint"));

                return TitleControl;
            });
        }
    }
}
