using IdlingComplaints.Models.Login;
using SeleniumUtilities.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdlingComplaints.Tests.Login
{
    internal class Test30_RequiredLabelErrors : LoginModel
    {
        private readonly int SLEEP_TIMER = 1000;

        [SetUp]
        public void SetUp()
        {
            //Driver.Quit();
            //Driver = CreateStandardDriver("chrome");
            //Driver.Navigate().GoToUrl("https://nycidling-dev.azurewebsites.net/login");
            //Driver.Manage().Window.Size = new Size(1920, 1200);
            base.LoginModelSetUp(false);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }

        [TearDown]
        public void TearDown()
        {
            if(SLEEP_TIMER > 0) { Thread.Sleep(SLEEP_TIMER); }
            //Driver.Quit();
            base.LoginModelTearDown();
        }

        [Test]
        [Category("Required Field Missing - Error Label Displayed")]
        public void MissingEmail()
        {
            EmailControl.SendTextDeleteTabWithDelay("xxx", SLEEP_TIMER);
            string error = Driver.ExtractTextFromXPath("//mat-card-content/form/div[1]/mat-form-field/div/div[3]/div/mat-error/text()");
            Assert.That(error, Is.EqualTo("Email is required"));
        }

        [Test]
        [Category("Required Field Missing - Error Label Displayed")]
        public void MissingPassword()
        {
            PasswordControl.SendTextDeleteTabWithDelay("xxx", SLEEP_TIMER);
            string error = Driver.ExtractTextFromXPath("//mat-card-content/form/div[2]/mat-form-field/div/div[3]/div/mat-error/text()");
            Assert.That(error, Is.EqualTo("Password is required"));
        }

        [Test]
        [Category("Required Field Provided - Error Label Hidden")]
        public void ProvidedEmail()
        {
            EmailControl.SendKeysWithDelay("xxx", SLEEP_TIMER);
            string error = Driver.ExtractTextFromXPath("//mat-card-content/form/div[1]/mat-form-field/div/div[3]/div/mat-error/text()");
            Assert.That(error, Is.EqualTo(string.Empty));
        }

        [Test]
        [Category("Required Field Provided - Error Label Hidden")]
        public void ProvidedPassword()
        {
            PasswordControl.SendKeysWithDelay("xxx", SLEEP_TIMER);
            string error = Driver.ExtractTextFromXPath("//mat-card-content/form/div[2]/mat-form-field/div/div[3]/div/mat-error/text()");
            Assert.That(error, Is.EqualTo(string.Empty));
        }

    }
}
