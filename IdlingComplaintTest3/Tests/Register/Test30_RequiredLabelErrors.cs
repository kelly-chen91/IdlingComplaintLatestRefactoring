using SeleniumUtilities.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdlingComplaints.Models.Register;

namespace IdlingComplaints.Tests.Register
{
    //[Parallelizable(ParallelScope.Children)]
    //[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    internal class Test30_RequiredLabelErrors : RegisterModel
    {
        private readonly int SLEEP_TIMER = 0;

        [OneTimeSetUp]
        public void SetUp()
        {
            //Driver.Quit();
            //Driver = CreateStandardDriver("chrome");
            //Driver.Navigate().GoToUrl("https://nycidling-dev.azurewebsites.net/profile");
            //Driver.Manage().Window.Size = new Size(1920, 1200);
            base.RegisterModelSetUp(true);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            if (SLEEP_TIMER > 0)
                Thread.Sleep(SLEEP_TIMER);
            base.RegisterModelTearDown();
        }

        /*Tests for error when first name field is empty*/
        [Test]
        [Category("Correct Label Displayed")]
        public void MissingFirstName()
        {
            FirstNameControl.SendTextDeleteTabWithDelay("xxx", SLEEP_TIMER);

            string error = Driver.ExtractTextFromXPath("//mat-card-content/div[1]/mat-form-field/div/div[3]/div/mat-error/text()");
            Assert.That(error, Is.EqualTo(Constants.REQUIRED));
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void MissingLastName()
        {
            LastNameControl.SendTextDeleteTabWithDelay("xxx", SLEEP_TIMER);

            string error = Driver.ExtractTextFromXPath("//mat-card-content/div[2]/mat-form-field/div/div[3]/div/mat-error/text()");
            Assert.That(error, Is.EqualTo(Constants.REQUIRED));
        }

        /*Tests for error when email field is empty*/
        [Test]
        [Category("Correct Label Displayed")]
        public void MissingEmail()
        {
            EmailControl.SendTextDeleteTabWithDelay("xxx", SLEEP_TIMER);

            string error = Driver.ExtractTextFromXPath("//mat-card-content/div[3]/mat-form-field/div/div[3]/div/mat-error/text()");
            Assert.That(error, Is.EqualTo(Constants.REQUIRED));
        }

        /*Tests for error when password field is empty*/
        [Test]
        [Category("Correct Label Displayed")]
        public void MissingPassword()
        {
            PasswordControl.SendTextDeleteTabWithDelay("xxx", SLEEP_TIMER);

            string error = Driver.ExtractTextFromXPath("//mat-card-content/div[4]/div[1]/div[1]/mat-form-field/div/div[3]/div/mat-error/text()");
            Assert.That(error, Is.EqualTo(Constants.PASSWORD_REQUIRED));
        }

        /*Tests for error when confirm password field is empty*/
        [Test]
        [Category("Correct Label Displayed")]
        public void MissingConfirmPassword()
        {
            ConfirmPasswordControl.SendTextDeleteTabWithDelay("xxx", SLEEP_TIMER);

            string error = Driver.ExtractTextFromXPath("//mat-card-content/div[4]/div[1]/div[2]/mat-form-field/div/div[3]/div/mat-error/text()");
            Assert.That(error, Is.EqualTo(Constants.CONFIRM_PASSWORD_REQUIRED));
        }

        /*Tests for error when security question field is empty*/
        [Test]
        [Category("Correct Label Displayed")]
        public void MissingSecurityQuestion()
        {
            SelectSecurityQuestion(0);
            string error = Driver.ExtractTextFromXPath("//mat-card-content/div[4]/div[2]/mat-form-field/div/div[3]/div/mat-error/text()");
            Assert.That(error, Is.EqualTo(Constants.REQUIRED));
        }

        /*Tests for error when security answer field is empty*/
        [Test]
        [Category("Correct Label Displayed")]
        public void MissingSecurityAnswer()
        {
            SecurityAnswerControl.SendTextDeleteTabWithDelay("xxx", SLEEP_TIMER);

            string error = Driver.ExtractTextFromXPath("//mat-card-content/div[4]/div[3]/mat-form-field/div/div[3]/div/mat-error/text()");
            Assert.That(error, Is.EqualTo(Constants.REQUIRED));
        }

        /*Tests for error when address1 field is empty*/
        [Test]
        [Category("Correct Label Displayed")]
        public void MissingAddress1()
        {
            Address1Control.SendTextDeleteTabWithDelay("xxx", SLEEP_TIMER);

            string error = Driver.ExtractTextFromXPath("//mat-card-content/div[5]/mat-form-field/div/div[3]/div/mat-error/text()");
            Assert.That(error, Is.EqualTo(Constants.REQUIRED));
        }

        /*Tests for error when city field is empty*/
        [Test]
        [Category("Correct Label Displayed")]
        public void MissingCity()
        {
            CityControl.SendTextDeleteTabWithDelay("xxx", SLEEP_TIMER);

            string error = Driver.ExtractTextFromXPath("//mat-card-content/div[7]/mat-form-field/div/div[3]/div/mat-error/text()");
            Assert.That(error, Is.EqualTo(Constants.REQUIRED));
        }

        /*Tests for error when state field is empty*/
        [Test]
        [Category("Correct Label Displayed")]
        public void MissingState()
        {
            SelectState(0);
            string error = Driver.ExtractTextFromXPath("//mat-card-content/div[8]/mat-form-field/div/div[3]/div/mat-error/text()");
            Assert.That(error, Is.EqualTo(Constants.REQUIRED), "Flagged for inconsistency on purpose."); //Supposed to fail for consistency
        }

        /*Tests for error when zip code field is empty*/
        [Test]
        [Category("Correct Label Displayed")]
        public void MissingZipCode()
        {
            ZipCodeControl.SendTextDeleteTabWithDelay("xxx", SLEEP_TIMER);

            string error = Driver.ExtractTextFromXPath("//mat-card-content/div[9]/mat-form-field/div/div[3]/div/mat-error/text()");
            Assert.That(error, Is.EqualTo(Constants.REQUIRED));
        }

        /*Tests for error when telephone field is empty*/
        [Test]
        [Category("Correct Label Displayed")]
        public void MissingTelephone()
        {
            TelephoneControl.SendTextDeleteTabWithDelay("xxx", SLEEP_TIMER);

            string error = Driver.ExtractTextFromXPath("//mat-card-content/div[10]/mat-form-field/div/div[3]/div/mat-error/text()");
            Assert.That(error, Is.EqualTo(Constants.REQUIRED));
        }


        /*Tests for no error when first name field is filled*/
        [Test]
        [Category("Correct Label Displayed")]
        public void ProvidedFirstName()
        {
            FirstNameControl.SendKeysWithDelay("xxx", SLEEP_TIMER);

            string error = Driver.ExtractTextFromXPath("//mat-card-content/div[1]/mat-form-field/div/div[3]/div/mat-error/text()");
            Assert.That(error, Is.EqualTo(string.Empty));
        }

        /*Tests for no error when last name field is filled*/
        [Test]
        [Category("Correct Label Displayed")]
        public void ProvidedLastName()
        {
            LastNameControl.SendKeysWithDelay("xxx", SLEEP_TIMER);

            string error = Driver.ExtractTextFromXPath("//mat-card-content/div[2]/mat-form-field/div/div[3]/div/mat-error/text()");
            Assert.That(error, Is.EqualTo(string.Empty));
        }

        /*Tests for no error when email field is filled*/
        [Test]
        [Category("Correct Label Displayed")]
        public void ProvidedEmail()
        {
            EmailControl.SendKeysWithDelay("xxx", SLEEP_TIMER);

            string error = Driver.ExtractTextFromXPath("//mat-card-content/div[3]/mat-form-field/div/div[3]/div/mat-error/text()");
            Assert.That(error, Is.EqualTo(string.Empty));
        }

        /*Tests for no error when password field is filled*/
        [Test]
        [Category("Correct Label Displayed")]
        public void ProvidedPassword()
        {
            PasswordControl.SendKeysWithDelay("T3sting.222", SLEEP_TIMER);
            ConfirmPasswordControl.SendKeysWithDelay("T3sting.222", SLEEP_TIMER);

            string error = Driver.ExtractTextFromXPath("//mat-card-content/div[4]/div[1]/div[1]/mat-form-field/div/div[3]/div/mat-error/text()");
            Assert.That(error, Is.EqualTo(string.Empty));
            //ConfirmPasswordProvided();
        }

        //Tests for no error when confirm password field is filled
        [Test]
        [Category("Correct Label Displayed")]
        public void ProvidedConfirmPassword()
        {
            PasswordControl.SendKeysWithDelay("T3sting.222", SLEEP_TIMER);
            ConfirmPasswordControl.SendKeysWithDelay("T3sting.222", SLEEP_TIMER);

            string error = Driver.ExtractTextFromXPath("//mat-card-content/div[4]/div[1]/div[2]/mat-form-field/div/div[3]/div/mat-error/text()");
            Assert.That(error, Is.EqualTo(string.Empty));
        }


        /*Tests for no error when security question field is filled*/
        [Test]
        [Category("Correct Label Displayed")]
        public void ProvidedSecurityQuestion()
        {
            SelectSecurityQuestion(1);

            string error = Driver.ExtractTextFromXPath("//mat-card-content/div[4]/div[2]/mat-form-field/div/div[3]/div/mat-error/text()");
            Assert.That(error, Is.EqualTo(string.Empty));
        }

        /*Tests for no error when security answer field is filled*/
        [Test]
        [Category("Correct Label Displayed")]
        public void ProvidedSecurityAnswer()
        {
            SecurityAnswerControl.SendKeysWithDelay("xxx", SLEEP_TIMER);

            string error = Driver.ExtractTextFromXPath("//mat-card-content/div[4]/div[3]/mat-form-field/div/div[3]/div/mat-error/text()");
            Assert.That(error, Is.EqualTo(string.Empty));
        }

        /*Tests for no error when Address 1 field is filled*/
        [Test]
        [Category("Correct Label Displayed")]
        public void ProvidedAddress1()
        {
            Address1Control.SendKeysWithDelay("xxx", SLEEP_TIMER);

            string error = Driver.ExtractTextFromXPath("//mat-card-content/div[5]/mat-form-field/div/div[3]/div/mat-error/text()");
            Assert.That(error, Is.EqualTo(string.Empty));
        }

        /*Tests for no error when city field is filled*/
        [Test]
        [Category("Correct Label Displayed")]
        public void ProvidedCity()
        {
            CityControl.SendKeysWithDelay("xxx", SLEEP_TIMER);

            string error = Driver.ExtractTextFromXPath("//mat-card-content/div[7]/mat-form-field/div/div[3]/div/mat-error/text()");
            Assert.That(error, Is.EqualTo(string.Empty));
        }

        /*Tests for no error when state field is filled*/
        [Test]
        [Category("Required Field Provided - Error Label Hidden")]
        public void ProvidedState()
        {
            SelectState(1);

            string error = Driver.ExtractTextFromXPath("//mat-card-content/div[8]/mat-form-field/div/div[3]/div/mat-error/text()");
            Assert.That(error, Is.EqualTo(string.Empty));
        }

        /*Tests for no error when zip code field is filled*/
        [Test]
        [Category("Required Field Provided - Error Label Hidden")]
        public void ProvidedZipCode()
        {
            ZipCodeControl.SendKeysWithDelay("xxx", SLEEP_TIMER);

            string error = Driver.ExtractTextFromXPath("//mat-card-content/div[9]/mat-form-field/div/div[3]/div/mat-error/text()");
            Assert.That(error, Is.EqualTo(string.Empty));
        }

        /*Tests for no error when telephone field is filled*/
        [Test]
        [Category("Required Field Provided - Error Label Hidden")]
        public void ProvidedTelephone()
        {
            TelephoneControl.SendKeysWithDelay("xxx", SLEEP_TIMER);

            string error = Driver.ExtractTextFromXPath("//mat-card-content/div[10]/mat-form-field/div/div[3]/div/mat-error/text()");
            Assert.That(error, Is.EqualTo(string.Empty));
        }

        public void ValidEmailTest()
        {
            /* The program does not test for valid email addresses */
        }

        public void ValidZipCodeTest()
        {
            /* The program does not test for valid zip code upon entry */
        }

        public void ValidPhoneNumber()
        {
            /* The program does not test for valid phone numbers */
        }
    }
}
