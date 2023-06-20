using IdlingComplaintTest.Pages.Register;
using IdlingComplaintTest.Pages.Login;
using SeleniumUtilities.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using OpenQA.Selenium.Support.UI;

namespace IdlingComplaintTest.Tests.Register
{
    [Parallelizable(ParallelScope.Children)]
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    internal class RegistrationVerification : RegisterModel
    {
        [SetUp]
        public void SetUp()
        {
            Driver.Navigate().GoToUrl("https://nycidling-dev.azurewebsites.net/profile");
            Driver.Manage().Window.Size = new Size(1920, 1200);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }

        [Test]
        [Category("Successful Registration")]
        public void SuccessfulRegistration()
        {

            FirstNameInput ="Jane";
            LastNameInput = "Doe";
            EmailInput = StringUtilities.GenerateRandomEmail();
            PasswordInput = "T3sting@1234";
            ConfirmPasswordInput = "T3sting@1234";
            SelectSecurityQuestion(1);
            SecurityAnswerInput = "Testing";
            Address1Input = "59-17 Junction Blvd";
            Address2Input = "10th Fl";
            CityInput = "Queens";
            SelectState(1);
            ZipCodeInput = "11373";
            PhoneInput = "631-632-9800";
            ScrollToButton();
            ClickSubmitButton();
            Thread.Sleep(10000);
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10)); 
            wait.Until(d => {
                var snackBarError = d.FindElement(By.TagName("simple-snack-bar")).FindElement(By.TagName("span"));
                Assert.IsNotNull(snackBarError);
                Assert.That(snackBarError.Text.Trim(), Is.EqualTo("Registration has been completed successfully.")); //Added period for consistency
                return snackBarError;
            });

        }

        [Test]
        [Category("Failed Registration")]
        public void FailedRegistration()
        {
            FirstNameInput = "Jane";
            LastNameInput = "Doe";
            EmailInput = "kelly.chen@dep.nyc.gov";
            PasswordInput = "T3sting@1234";
            ConfirmPasswordInput = "T3sting@1234";
            SelectSecurityQuestion(1);
            SecurityAnswerInput = "Testing";
            Address1Input = "59-17 Junction Blvd";
            Address2Input = "10th Fl";
            CityInput = "Queens";
            SelectState(1);
            ZipCodeInput = "11373";
            PhoneInput = "631-632-9800";
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
            FirstNameInput = "Jane";
            LastNameInput = "Doe";
            EmailInput = StringUtilities.GenerateRandomEmail();
            PasswordInput = "T3sting@1234";
            ConfirmPasswordInput = "T3sting@1234";
            SelectSecurityQuestion(1);
            SecurityAnswerInput = "Testing";
            Address1Input = "59-17 Junction Blvd";
            Address2Input = "10th Fl";
            CityInput = "Queens";
            SelectState(1);
            ZipCodeInput = "11373";
            PhoneInput = "631-632-9800";
            ScrollToButton();
            ClickCancelButton();

            var loginButton = Driver.FindElement(By.XPath("/html/body/app-root/div/app-login/mat-card/mat-card-content/form/div[3]/button"));
            Assert.IsNotNull(loginButton);
        
        }

        [Test]
        [Category("Cancel Registration Test")]
        public void CancelRedirectsToLogin()
        {
             ScrollToButton();
             ClickCancelButton();
             var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10)); //1 - too short
             wait.Until(d => d.FindElement(By.TagName("h3")));
        }

        
   
    }
}
