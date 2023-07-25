using IdlingComplaints.Models.PasswordReset;
using IdlingComplaints.Tests.PasswordReset;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumUtilities.Base;
using SeleniumUtilities.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdlingComplaints.Tests.PasswordReset
{
    //[Parallelizable(ParallelScope.Fixtures)]
    //[FixtureLifeCycle(LifeCycle.SingleInstance)]
    internal class Test60_Label_BeforeReset : PasswordResetModel 
    { 

        BaseExtent extent;

        public Test60_Label_BeforeReset()
        {
            extent = new BaseExtent();
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            extent.SetUp(false, GetType().Namespace + "." + GetType().Name);;
            base.PasswordResetModelSetUp(true);

        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            extent.TearDown(false, Driver);
            base.PasswordResetModelTearDown();

        }

        [SetUp]
        public void SetUp()
        {
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
        }

        [Test, Category("Correct Label Displayed")]
        public void DisplayedHeading()
        {
            Assert.That(TitleControl.Text, Is.EqualTo(Constants.RESET_PASSWORD_TITLE));
        }

        [Test, Category("Placeholder is present.")]
        public void PlaceholderEmail()
        {
            var placeholder = EmailControl.GetAttribute("placeholder");
            Assert.That(placeholder, Is.EqualTo(Constants.EMAIL));
        }

        [Test, Category("Placeholder is present.")]
        public void PlaceholderReset()
        {
            string text = Driver.ExtractTextFromXPath("//password-reset/form/div/div/mat-card/mat-card-content/mat-dialog-actions/button[1]/span/text()");
            Assert.That(text, Is.EqualTo(Constants.RESET));
        }

        [Test, Category("Placeholder is present.")]
        public void PlaceholderCancel()
        {
            string text = Driver.ExtractTextFromXPath("//password-reset/form/div/div/mat-card/mat-card-content/mat-dialog-actions/button[2]/span/text()");
            Assert.That(text, Is.EqualTo(Constants.CANCEL));
        }

        [Test, Category("Required Field Missing - Error Label Displayed")]
        public void RequiredEmail()
        {
            EmailControl.SendTextDeleteTabWithDelay("abc", 0);
            string text = Driver.ExtractTextFromXPath("//password-reset/form/div/div/mat-card/mat-card-content/mat-form-field/div/div[3]/div/mat-error/text()");
            Assert.That(text, Is.EqualTo(Constants.EMAIL_REQUIRE));
        }

        [Test, Category("Required Field Missing - Error Label Displayed")]
        public void RequiredInvalidEmail()
        {
            EmailControl.SendKeysWithDelay("TTseng", 0);
            ClickResetButton();
            var error = Driver.WaitUntilElementFound(SnackBarByControl, 10).FindElement(By.TagName("span"));
            Assert.That(error.Text, Is.EqualTo(Constants.USER_NOT_FOUND));
        }
    }
}
