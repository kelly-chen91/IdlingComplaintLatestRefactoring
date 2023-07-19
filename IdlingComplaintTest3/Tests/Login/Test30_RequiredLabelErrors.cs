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

        BaseExtent extent;

        public Test30_RequiredLabelErrors()
        {
            extent = new BaseExtent();
        }
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            extent.SetUp(false, GetType().Name);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            extent.TearDown(false, Driver);
        }

        [SetUp]
        public void SetUp()
        {
            base.LoginModelSetUp(false);
            extent.SetUp(true);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

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
                base.LoginModelTearDown();
            }
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
