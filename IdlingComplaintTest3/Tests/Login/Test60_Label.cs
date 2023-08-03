using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using IdlingComplaints.Models.Login;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SeleniumUtilities.BaseSetUp;
using SeleniumUtilities.Utils.TestUtils;

/*
 *This is the label test class for testing the labels in the login page
 */

namespace IdlingComplaints.Tests.Login
{


    internal class Test60_Label : LoginModel
    {
        BaseExtent extent;

        public Test60_Label()
        {
            extent = new BaseExtent();
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            extent.SetUp(false, GetType().Namespace + "." + GetType().Name);
            base.LoginModelSetUp(true);

        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            extent.TearDown(false, Driver);
            base.LoginModelTearDown();

        }

        [SetUp]
        public void SetUp()
        {
            //base.LoginModelSetUp(true);
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

        [Test]
        //Tests whether the input name matches with "Email" 
        [Category("Placeholder is present.")]
        public void PlaceholderEmail()
        {
            var placeholder = EmailControl.GetAttribute("placeholder");
            Assert.That(placeholder, Is.EqualTo(Constants.EMAIL));
        }

        [Test]
        //Tests whether the input name matches with "Password" 
        [Category("Placeholder is present.")]
        public void PlaceholderPassword()
        {
            var placeholder = PasswordControl.GetAttribute("placeholder");
            Assert.That(placeholder, Is.EqualTo(Constants.PASSWORD));
        }

        [Test]
        //Tests whether the heading matches with "NYC Idling Complaint"
        [Category("Correct Label Displayed")]
        public void DisplayedHeading()
        {
            Assert.That(TitleControl.Text, Is.EqualTo(Constants.LOGIN_HEADING), "Flagged for inconsistency on purpose.");
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedLogin()
        {
            string text = Driver.ExtractTextFromXPath("//app-login/mat-card/mat-card-header/div/mat-card-title/h4/text()");
            Assert.That(text, Is.EqualTo(Constants.LOGIN), "Flagged for inconsistency on purpose.");
        }

        [Test]
        [Category("Label Displayed - no spelling / grammar errors.")]
        public void DisplayedLoginButton()
        {
            string loginButtonText = Driver.ExtractTextFromXPath("//app-login/mat-card/mat-card-content/form/div[3]/button/span/text()");
            Assert.That(loginButtonText, Is.EqualTo(Constants.LOGIN), "Flagged for inconsistency on purpose.");
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedForgotPassword()
        {
            Assert.That(ForgotPasswordControl.Text, Is.EqualTo(Constants.FORGOT_PASS), "Flagged for inconsistency on purpose.");
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedCreateAnAccount()
        {
            Assert.That(CreateAccountControl.Text, Is.EqualTo(Constants.CREATE_ACCOUNT), "Flagged for inconsistency on purpose.");
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedNotRegistered()
        {
            string notRegisteredText = Driver.ExtractTextFromXPath("//app-login/mat-card/mat-card-content/form/div[4]/p/text()");
            Assert.That(notRegisteredText, Is.EqualTo(Constants.NOT_REGISTERED), "Flagged for inconsistency on purpose.");
        }

        [Test]
        [Category("Label Displayed - goes to correct link.")]
        public void VerifyForgotPasswordLink()
        {
            string forgotPassLink = ForgotPasswordControl.GetAttribute("href");
            Assert.That(forgotPassLink, Is.EqualTo("https://nycidling-dev.azurewebsites.net/password-reset"), "Flagged for inconsistency on purpose.");
        }

        [Test]
        [Category("Label Displayed - goes to correct link.")]
        public void VerifyCreateAccountLink()
        {
            string createAccountLink = CreateAccountControl.GetAttribute("href");
            Assert.That(createAccountLink, Is.EqualTo("https://nycidling-dev.azurewebsites.net/profile"), "Flagged for inconsistency on purpose.");
        }
    }
}
