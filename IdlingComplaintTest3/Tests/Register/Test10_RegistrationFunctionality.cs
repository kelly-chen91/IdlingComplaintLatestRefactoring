using OpenQA.Selenium;
using System.Drawing;
using OpenQA.Selenium.Support.UI;
using IdlingComplaints.Models.Register;
using SeleniumUtilities.BaseSetUp;
using RazorEngine.Compilation.ImpromptuInterface.Dynamic;
using IdlingComplaints.Tests.Register;
using SeleniumUtilities.Utils.TestUtils;

namespace IdlingComplaints.Tests.Register
{

    internal class Test10_RegistrationFunctionality : RegisterModel
    {
        private readonly int SLEEP_TIMER = 0;
        private string Registered_EmailAddress_PasswordReset = StringUtilities.GetProjectRootDirectory() + "\\Files\\Text\\Registered_EmailAddress_PasswordReset.txt";
        private string Registered_AccountTracker = StringUtilities.GetProjectRootDirectory() + "\\Files\\Text\\ComplaintForm_AccountTracker.txt";
        
        BaseExtent extent;

        public Test10_RegistrationFunctionality()
        {
            extent = new BaseExtent();
        }
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            extent.SetUp(false, GetType().Namespace + "." + GetType().Name);
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


        [Test, Category("Successful User Registration for Complaint Form Submissions")]
        public void RegistrationForAccountTracker()
        {
            RandomTextRegistration(Registered_AccountTracker);
        }

        [Test, Category("Successful User Registration for Password Reset")]
        public void RegistrationForPasswordReset()
        {
            RandomTextRegistration(Registered_EmailAddress_PasswordReset);
        }

        [Test, Category("Scenario test#2: Registration with a exiting account")]
        public void FailedRegistrationDuplicateEmail()
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

            var snackBarError = Driver.WaitUntilElementFound(SnackBarByControl,20).FindElement(By.TagName("span"));
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

        public void RandomTextRegistration(string fileName)
        {
            FirstNameControl.SendKeysWithDelay(StringUtilities.GenerateRandomString(), SLEEP_TIMER);
            LastNameControl.SendKeysWithDelay(StringUtilities.GenerateRandomString(), SLEEP_TIMER);

            string generatedEmail = StringUtilities.GenerateCustomEmail(FirstNameInput, LastNameInput, "dep.nyc.gov");
            EmailControl.SendKeysWithDelay(generatedEmail, SLEEP_TIMER);

            string password = StringUtilities.GenerateQualifiedPassword();
            PasswordControl.SendKeysWithDelay(password, SLEEP_TIMER);
            ConfirmPasswordControl.SendKeysWithDelay(password, SLEEP_TIMER);

            int securityRandomNumber = StringUtilities.GenerateRandomNumberWithRange(1, 5);
            SelectSecurityQuestion(securityRandomNumber);

            string securityAnswer = StringUtilities.GenerateRandomString();
            SecurityAnswerControl.SendKeysWithDelay(securityAnswer, SLEEP_TIMER);
            ScrollToButton();

            Address1Control.SendKeysWithDelay(StringUtilities.GenerateRandomString(), SLEEP_TIMER);
            Address2Control.SendKeysWithDelay(StringUtilities.GenerateRandomString(), SLEEP_TIMER);
            CityControl.SendKeysWithDelay(StringUtilities.GenerateRandomString(), SLEEP_TIMER);

            int stateRandomNumber = StringUtilities.GenerateRandomNumberWithRange(1, 49);
            Console.WriteLine("The state number is " + stateRandomNumber + " . And the State selected is " + StateControl);
            SelectState(stateRandomNumber);


            string zipCodeNumbers = StringUtilities.GenerateRandomString();
            ZipCodeControl.SendKeysWithDelay(zipCodeNumbers, SLEEP_TIMER);

            string TelephoneNumbers = StringUtilities.GenerateRandomString();
            TelephoneControl.SendKeysWithDelay(TelephoneNumbers, SLEEP_TIMER);

            ClickSubmitButton();

            var snackBarError = Driver.WaitUntilElementFound(SnackBarByControl, 61).FindElement(By.TagName("span")); ;
            string[] inputs = { generatedEmail, password, securityAnswer };
            fileName.WriteIntoFile(inputs);
            Console.WriteLine("The new user is " + generatedEmail);
            Assert.That(snackBarError.Text.Trim(), Contains.Substring("Registration has been completed successfully"), "Flagged for inconsistency on purpose."); //Added period for consistency with other error messaging
        }
    }
}
