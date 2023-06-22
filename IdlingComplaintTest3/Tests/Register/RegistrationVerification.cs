
using SeleniumUtilities.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using OpenQA.Selenium.Support.UI;
using IdlingComplaints.Models.Register;

namespace IdlingComplaints.Tests.Register
{
    //[Parallelizable(ParallelScope.Children)]
    //[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    internal class RegistrationVerification : RegisterModel
    {
        [SetUp]
        public void SetUp()
        {
            Driver.Quit();
            Driver = CreateDriver("chrome");
            Driver.Navigate().GoToUrl("https://nycidling-dev.azurewebsites.net/profile");
            Driver.Manage().Window.Size = new Size(1920, 1200);
        }

        [TearDown]
        public void TearDown()
        {
            Thread.Sleep(SLEEP_TIMER);
            Driver.Quit();
        }

        private readonly int SLEEP_TIMER = 2000;

        [Test]
        [Category("Successful Registration")]
        public void SuccessfulRegistration()
        {
            FirstNameControl.SendKeysWithDelay("Jane", SLEEP_TIMER);
            LastNameControl.SendKeysWithDelay("Doe", SLEEP_TIMER);
            EmailControl.SendKeysWithDelay(StringUtilities.GenerateRandomEmail(), SLEEP_TIMER);
            PasswordControl.SendKeysWithDelay("T3sting@1234", SLEEP_TIMER);
            ConfirmPasswordControl.SendKeysWithDelay("T3sting@1234", SLEEP_TIMER);
            SelectSecurityQuestion(1);
            SecurityAnswerControl.SendKeysWithDelay("Testing", SLEEP_TIMER);
            Address1Control.SendKeysWithDelay("59-17 Junction Blvd", SLEEP_TIMER);
            Address2Control.SendKeysWithDelay("10th Fl", SLEEP_TIMER);
            CityControl.SendKeysWithDelay("Queens", SLEEP_TIMER);
            SelectState(1);
            ZipCodeControl.SendKeysWithDelay("11373", SLEEP_TIMER);
            TelephoneControl.SendKeysWithDelay("631-632-9800", SLEEP_TIMER);
            ScrollToButton();
            ClickSubmitButton();
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(d =>
            {
                var snackBarError = d.FindElement(By.TagName("simple-snack-bar")).FindElement(By.TagName("span"));
                Assert.IsNotNull(snackBarError);
                Assert.That(snackBarError.Text.Trim(), Is.EqualTo("Registration has been completed successfully."), "Flagged for inconsistency on purpose."); //Added period for consistency with other error messaging
                return snackBarError;
            });
        }

        [Test]
        [Category("Failed Registration")]
        public void FailedRegistration()
        {
            FirstNameControl.SendKeysWithDelay("Jane", SLEEP_TIMER);
            LastNameControl.SendKeysWithDelay("Doe", SLEEP_TIMER);
            EmailControl.SendKeysWithDelay("kchen@dep.nyc.gov", SLEEP_TIMER);
            PasswordControl.SendKeysWithDelay("T3sting@1234", SLEEP_TIMER);
            ConfirmPasswordControl.SendKeysWithDelay("T3sting@1234", SLEEP_TIMER);
            SelectSecurityQuestion(1);
            SecurityAnswerControl.SendKeysWithDelay("Testing", SLEEP_TIMER);
            Address1Control.SendKeysWithDelay("59-17 Junction Blvd", SLEEP_TIMER);
            Address2Control.SendKeysWithDelay("10th Fl", SLEEP_TIMER);
            CityControl.SendKeysWithDelay("Queens", SLEEP_TIMER);
            SelectState(1);
            ZipCodeControl.SendKeysWithDelay("11373", SLEEP_TIMER);
            TelephoneControl.SendKeysWithDelay("631-632-9800", SLEEP_TIMER);
            ScrollToButton();
            ClickSubmitButton();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(d =>
            {
                var snackBarError = d.FindElement(By.TagName("simple-snack-bar")).FindElement(By.TagName("span"));
                Assert.IsNotNull(snackBarError);
                Assert.That(snackBarError.Text.Trim(), Is.EqualTo("Email " + EmailInput + " has already been registered. Please contact DEP hotline."));
                return snackBarError;
            });

            //Thread.Sleep(10000);
            //Email kelly.chen@dep.nyc.gov has already been registered. Please contact DEP hotline.
        }



        [Test]
        [Category("Cancelled Registration")]
        public void CancelRegistration()
        {
            FirstNameControl.SendKeysWithDelay("Jane", SLEEP_TIMER);
            LastNameControl.SendKeysWithDelay("Doe", SLEEP_TIMER);
            EmailControl.SendKeysWithDelay("kchen@dep.nyc.gov", SLEEP_TIMER);
            PasswordControl.SendKeysWithDelay("T3sting@1234", SLEEP_TIMER);
            ConfirmPasswordControl.SendKeysWithDelay("T3sting@1234", SLEEP_TIMER);
            SelectSecurityQuestion(1);
            SecurityAnswerControl.SendKeysWithDelay("Testing", SLEEP_TIMER);
            Address1Control.SendKeysWithDelay("59-17 Junction Blvd", SLEEP_TIMER);
            Address2Control.SendKeysWithDelay("10th Fl", SLEEP_TIMER);
            CityControl.SendKeysWithDelay("Queens", SLEEP_TIMER);
            SelectState(1);
            ZipCodeControl.SendKeysWithDelay("11373", SLEEP_TIMER);
            TelephoneControl.SendKeysWithDelay("631-632-9800", SLEEP_TIMER);
            ScrollToButton();
            ClickCancelButton();

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            var loginButton = Driver.FindElement(By.XPath("/html/body/app-root/div/app-login/mat-card/mat-card-content/form/div[3]/button"));
            Assert.IsNotNull(loginButton);

        }

        [Test]
        [Category("Cancelled Registration")]
        public void CancelRedirectsToLogin()
        {
            ScrollToButton();
            ClickCancelButton();
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10)); //1 - too short
            wait.Until(d => d.FindElement(By.TagName("h3")));
        }



    }
}
