using IdlingComplaints.Models.PasswordReset;
using IdlingComplaints.Tests.PassordReset;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumUtilities.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdlingComplaints.Tests.PassordReset
{
    // [Parallelizable(ParallelScope.Children)]
    // [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    internal class Test60_Label_BeforeReset : PasswordResetModel 
    { 

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            base.PasswordResetModelSetUp(true);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            base.PasswordResetModelTearDown();
        }

        [Test, Category("Correct Label Displayed")]
        public void DisplayedHeading()
        {
            Assert.That(TitleControl.Text, Is.EqualTo(Constants.RESET_PASSWORD_TITLE));
        }

        [Test, Category("Placeholder is present.")]
        public void DisplayedEmail()
        {
            var placeholder = EmailControl.GetAttribute("placeholder");
            Assert.That(placeholder, Is.EqualTo(Constants.EMAIL));
        }

        [Test, Category("Placeholder is present.")]
        public void DisplayedReset()
        {
            string text = Driver.ExtractTextFromXPath("/html/body/app-root/div/password-reset/form/div/div/mat-card/mat-card-content/mat-dialog-actions/button[1]/span/text()");
            Assert.That(text, Is.EqualTo(Constants.RESET));
        }

        [Test, Category("Placeholder is present.")]
        public void DisplayedCancel()
        {
            string text = Driver.ExtractTextFromXPath("/html/body/app-root/div/password-reset/form/div/div/mat-card/mat-card-content/mat-dialog-actions/button[2]/span/text()");
            Assert.That(text, Is.EqualTo(Constants.CANCEL));
        }

        [Test, Category("Require message is present.")]
        public void RequiredEmail()
        {
            EmailControl.SendTextDeleteTabWithDelay("abc", 0);
            string text = Driver.ExtractTextFromXPath("/html/body/app-root/div/password-reset/form/div/div/mat-card/mat-card-content/mat-form-field/div/div[3]/div/mat-error/text()");
            Assert.That(text, Is.EqualTo(Constants.EMAIL_REQUIRE));
        }

        [Test, Category("Require message is present.")]
        public void RequiredInvalidEmail()
        {
            EmailControl.SendKeysWithDelay("TTseng", 0);
            ClickResetButton();
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.TagName("simple-snack-bar")));

            string text = Driver.ExtractTextFromXPath("/html/body/div[2]/div/div/snack-bar-container/simple-snack-bar/span/text()");
            Assert.That(text, Is.EqualTo(Constants.USER_NOT_FOUND));
        }
    }
}
