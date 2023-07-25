using IdlingComplaints.Models.PasswordReset;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;
using SeleniumUtilities.Base;
using SeleniumUtilities.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace IdlingComplaints.Tests.PasswordReset
{
    //[Parallelizable(ParallelScope.Fixtures)]
    //[FixtureLifeCycle(LifeCycle.SingleInstance)]
    internal class Test10_PasswordResetFunctionality : PasswordResetModel
    {
        public int lines;
        public int userIndex;
        private readonly int SLEEP_TIMER = 0;
        private readonly string registered_EmailAddress = StringUtilities.GetProjectRootDirectory() + "\\Files\\Text\\Registered_EmailAddress.txt";
        Random random = new Random();

        BaseExtent extent;

        public Test10_PasswordResetFunctionality()
        {
            this.lines = File.ReadAllLines(registered_EmailAddress).Length;
            this.userIndex = random.Next(0, lines - 1);
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
        public void Setup()
        {
            base.PasswordResetModelSetUp(true);
            extent.SetUp(true);

            string emailAddress = RegistrationUtilities.RetrieveRecordValue(registered_EmailAddress, userIndex, 0);
            EmailControl.SendKeysWithDelay(emailAddress, SLEEP_TIMER);
            
            ClickResetButton();

            Driver.WaitUntilElementFound(SecurityAnswerByControl, 20);
            
            Console.WriteLine("This user's email is " + emailAddress + ". The line index is " + userIndex + ".");
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
                base.PasswordResetModelTearDown();
            }
        }


        

        

        [Test, Category("Scenario #1: successful password reset")]
        public void UpdatePasswordinFile()
        {
            string securityAnswer = RegistrationUtilities.RetrieveRecordValue(registered_EmailAddress, userIndex, 2);
            Console.WriteLine("The old password is " + RegistrationUtilities.RetrieveRecordValue(registered_EmailAddress, userIndex, 1));
            SecurityAnswerControl.SendKeysWithDelay(securityAnswer, SLEEP_TIMER);

            string password = RegistrationUtilities.GenerateQualifiedPassword();
            PasswordControl.SendKeysWithDelay(password, SLEEP_TIMER);
            Console.WriteLine("The new password is " + password);
            ConfirmPasswordControl.SendKeysWithDelay(password, SLEEP_TIMER);
            
            ClickSubmitButton();

            var resetControl = Driver.WaitUntilElementFound(SnackBarByControl, 60).FindElement(By.TagName("span"));
            Assert.IsNotNull(resetControl);
            RegistrationUtilities.ReplaceRecordValue(registered_EmailAddress, userIndex, 1, password);

            Assert.That(resetControl.Text.Trim(), Is.EqualTo(Constants.SUCCESSFUL_PASSWORD_MESSAGE));
        }


        [Test, Category("Scenario #2: Wrong security key answer")]
        public void FailedPasswordReset()
        {
            SecurityAnswerControl.SendKeysWithDelay("This is not an actual security key", SLEEP_TIMER);

            string password = RegistrationUtilities.GenerateQualifiedPassword();
            PasswordControl.SendKeysWithDelay(password, SLEEP_TIMER);
            ConfirmPasswordControl.SendKeysWithDelay(password, SLEEP_TIMER);

            ClickSubmitButton();

            var resetControl = Driver.WaitUntilElementFound(SnackBarByControl, 30).FindElement(By.TagName("span"));
            Assert.IsNotNull(resetControl);
            Assert.That(resetControl.Text.Trim(), Is.EqualTo(Constants.WRONG_SECURITY_ANSWER));
        }


        [Test, Category("Scenario #3: cancel password update")]
        public void CancelPasswordReset()
        {
            ClickCancelButton();
            var loginControl = Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='password']"), 10);
            Assert.IsNotNull(loginControl);
            Assert.That(loginControl.GetAttribute("placeholder").Trim(), Is.EqualTo("Password"));

        }


        

    }
}
