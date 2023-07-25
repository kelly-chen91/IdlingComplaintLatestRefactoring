
using SeleniumUtilities.Utils;
using OpenQA.Selenium;
using System.Drawing;
using OpenQA.Selenium.Support.UI;
using IdlingComplaints.Models.Register;
using SeleniumUtilities.Base;

namespace IdlingComplaints.Tests.Register
{

    //[Parallelizable(ParallelScope.Fixtures)]
    //[FixtureLifeCycle(LifeCycle.SingleInstance)]
    internal class Test10_RegistrationFunctionality : RegisterModel
    {
        private readonly int SLEEP_TIMER = 0;
        private string Registered_EmailAddress = StringUtilities.GetProjectRootDirectory() + "\\Files\\Text\\Registered_EmailAddress.txt";

        BaseExtent extent;

        public Test10_RegistrationFunctionality()
        {
            extent = new BaseExtent();
        }
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            extent.SetUp(false, GetType().Namespace + "." + GetType().Name);;
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            extent.TearDown(false, Driver);
        }

        [SetUp]
        public void SetUp()
        {
            base.RegisterModelSetUp(true);
            Driver.Manage().Window.Maximize();

            extent.SetUp(true);

        }

        [TearDown]
        public void TearDown()
        {
            try
            {
                extent.TearDown(true, Driver);
            }
            catch (Exception ex)
            {
                throw new Exception("Exception: " + ex);
            }
            finally
            {
                if (SLEEP_TIMER > 0)
                    Thread.Sleep(SLEEP_TIMER);
                base.RegisterModelTearDown();
            }
        }


        [Test, Category("Scenario test#1: New user with all random text input")]
        public void RandomtextRegistrtration()
        {
            FirstNameControl.SendKeysWithDelay(RegistrationUtilities.GenerateRandomString(), SLEEP_TIMER);
            LastNameControl.SendKeysWithDelay(RegistrationUtilities.GenerateRandomString(), SLEEP_TIMER);

            string generatedEmail = RegistrationUtilities.GenerateEmail(FirstNameInput, LastNameInput, "dep.nyc.gov");
            EmailControl.SendKeysWithDelay(generatedEmail, SLEEP_TIMER);
            
            string password = RegistrationUtilities.GenerateQualifiedPassword();
            PasswordControl.SendKeysWithDelay(password, SLEEP_TIMER);
            ConfirmPasswordControl.SendKeysWithDelay(password, SLEEP_TIMER);
            
            int securityRandomNumber = RegistrationUtilities.GenerateRandomNumberWithRange(1, 5);
            SelectSecurityQuestion(securityRandomNumber);
            
            string securityAnswer = RegistrationUtilities.GenerateRandomString();
            SecurityAnswerControl.SendKeysWithDelay(securityAnswer, SLEEP_TIMER);
            ScrollToButton();

            Address1Control.SendKeysWithDelay(RegistrationUtilities.GenerateRandomString(), SLEEP_TIMER);
            Address2Control.SendKeysWithDelay(RegistrationUtilities.GenerateRandomString(), SLEEP_TIMER);
            CityControl.SendKeysWithDelay(RegistrationUtilities.GenerateRandomString(), SLEEP_TIMER);
            
            int stateRandomNumber = RegistrationUtilities.GenerateRandomNumberWithRange(1, 49);
            Console.WriteLine("The state number is " + stateRandomNumber + " . And the State selected is " + StateControl);
            SelectState(stateRandomNumber);
            
           
            string zipCodeNumbers = RegistrationUtilities.GenerateRandomString();
            ZipCodeControl.SendKeysWithDelay(zipCodeNumbers, SLEEP_TIMER);
        
          string TelephoneNumbers = RegistrationUtilities.GenerateRandomString();
          TelephoneControl.SendKeysWithDelay(TelephoneNumbers, SLEEP_TIMER);
         
          ClickSubmitButton();
            
            var snackBarError =Driver.WaitUntilElementFound(SnackBarByControl, 61).FindElement(By.TagName("span")); ;

           RegistrationUtilities.WriteIntoFile(Registered_EmailAddress, generatedEmail, password, securityAnswer);
          Console.WriteLine("The new user is "+ generatedEmail);
            Assert.That(snackBarError.Text.Trim(), Contains.Substring("Registration has been completed successfully"), "Flagged for inconsistency on purpose."); //Added period for consistency with other error messaging
        }

        [Test, Category("Scenario test#2: Registration with a exiting account")]
        public void FailedRegistrationDrtupEmail()
        {
            FirstNameControl.SendKeysWithDelay("Registered", SLEEP_TIMER);
            LastNameControl.SendKeysWithDelay("User", SLEEP_TIMER);
            EmailControl.SendKeysWithDelay("TTseng@dep.nyc.gov", SLEEP_TIMER);
            PasswordControl.SendKeysWithDelay("Testing@1234", SLEEP_TIMER);
            ConfirmPasswordControl.SendKeysWithDelay("Testing@1234", SLEEP_TIMER);
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

            var snackBarError = Driver.WaitUntilElementFound(SnackBarByControl,10).FindElement(By.TagName("span"));
            Assert.IsNotNull(snackBarError);
            Assert.That(snackBarError.Text.Trim(), Is.EqualTo("Email " + EmailInput + " has already been registered. Please contact DEP hotline."));

        }

        [Test, Category("Scenario test#3: Cancel register")]
        public void CancelRegistrationRedirectsToLogin()
        {
            ScrollToButton();
            ClickCancelButton();

            Driver.WaitUntilElementFound(By.TagName("h3"), 10);
        }

        [Test, Category("Scenario test#4: Cancel register after fill in all the input fields")]
        public void CancelRegistrationFullFormRedirectsToLogin()
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

            var loginButton = Driver.WaitUntilElementFound(By.XPath("//app-login/mat-card/mat-card-content/form/div[3]/button"),10);
            Assert.IsNotNull(loginButton);

        }


    }
}
