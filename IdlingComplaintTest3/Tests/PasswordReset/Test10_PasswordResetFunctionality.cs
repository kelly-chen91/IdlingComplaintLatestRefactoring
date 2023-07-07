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
    internal class Test10_PasswordResetFunctionality : PasswordResetModel
    {
        private readonly int SLEEP_TIMER = 2000;


       private readonly string registed_EmailAddress = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Files\\Text\\Registed_EmailAddress.txt";

        Random random = new Random();

        public int lines;
        public int userIndex;

        public Test10_PasswordResetFunctionality()
        {
            this.lines = File.ReadAllLines(registed_EmailAddress).Length;
            this.userIndex = random.Next(0, lines - 1);

        }


        [SetUp]
        public void Setup()
        {
            base.PasswordResetModelSetUp(false);

            string emailAddress = RegistrationUtilities.RetriveRecordValue(registed_EmailAddress, userIndex, 0);
            EmailControl.SendKeysWithDelay(emailAddress, SLEEP_TIMER);
            
            ClickResetButton();
            
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            wait.Until(d => d.FindElement(By.CssSelector("input[formcontrolname = 'securityanswer']")));
            Console.WriteLine("This user's email is " + emailAddress + ". The line index is " + userIndex + ".");
        }
        [TearDown]
        public void TearDown()
        {
            if (SLEEP_TIMER > 0)
                Thread.Sleep(SLEEP_TIMER);
            base.PasswordResetModelTearDown();
        }

        [Test, Category("Valid Reset")]
        public void UpdatePasswordinFile()
        {
            


            string securityAnswer = RegistrationUtilities.RetriveRecordValue(registed_EmailAddress, userIndex, 2);
            SecurityAnswerControl.SendKeysWithDelay(securityAnswer, SLEEP_TIMER);

            string password = RegistrationUtilities.GenerateQulifiedPassword();
            PasswordControl.SendKeysWithDelay(password, SLEEP_TIMER);
            ConfirmPasswordControl.SendKeysWithDelay(password, SLEEP_TIMER);
            
            ClickSubmitButton();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            wait.Until(d =>
            {
                var resetControl = d.FindElement(By.TagName("simple-snack-bar")).FindElement(By.TagName("span"));
                
                return resetControl;
            });
            RegistrationUtilities.ReplaceRecordValue(registed_EmailAddress, userIndex, 1, password);
        }


    //   [Test, Category("Valid Reset")]
    //   public void SuccessfulPasswordReset()
    //   {
    //       SecurityAnswerControl.SendKeysWithDelay("pet", SLEEP_TIMER);
    //       PasswordControl.SendKeysWithDelay("Testing1#", SLEEP_TIMER);
    //       ConfirmPasswordControl.SendKeysWithDelay("Testing1#", SLEEP_TIMER);
    //       ClickSubmitButton();
    //
    //       var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
    //       wait.Until(d =>
    //       {
    //           var resetControl = d.FindElement(By.TagName("simple-snack-bar")).FindElement(By.TagName("span"));
    //
    //           Assert.IsNotNull(resetControl);
    //           Assert.That(resetControl.Text.Trim(), Is.EqualTo("Password has been reset successfully."));
    //
    //           return resetControl;
    //       });
    //   }

        [Test, Category("Invalid Reset")]
        public void FailedPasswordReset()
        {
            SecurityAnswerControl.SendKeysWithDelay("This is not an actual security key", SLEEP_TIMER);
          
            string password = RegistrationUtilities.GenerateQulifiedPassword();
            PasswordControl.SendKeysWithDelay(password, SLEEP_TIMER);
            ConfirmPasswordControl.SendKeysWithDelay(password, SLEEP_TIMER);

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
