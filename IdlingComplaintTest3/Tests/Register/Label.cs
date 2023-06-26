using IdlingComplaints.Tests.Login;
using SeleniumUtilities.Utils;
using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdlingComplaints.Models.Register;

namespace IdlingComplaints.Tests.Register
{

    internal partial class Label : RegisterModel
    {

        [OneTimeSetUp]
        public new void OneTimeSetUp()
        {
            base.OneTimeSetUp();
        }

        [OneTimeTearDown]
        public new void OneTimeTearDown()
        {
            base.OneTimeTearDown();
        }

        [Test]
        [Category("Placeholder is present.")]
        public void PlaceholderFirstName()
        {
            Assert.That(FirstNameControl.GetAttribute("placeholder"), Is.EqualTo(Constants.FIRST_NAME),
                "First name placeholder is supposed to be \"" + Constants.FIRST_NAME + "\".");
        }

        [Test]
        [Category("Placeholder is present.")]
        public void PlaceholderLastName()
        {
            Assert.That(LastNameControl.GetAttribute("placeholder"), Is.EqualTo(Constants.LAST_NAME),
                "Last name placeholder is supposed to be \"" + Constants.LAST_NAME + "\".");
        }

        [Test]
        [Category("Placeholder is present.")]
        public void PlaceholderEmail()
        {
            Assert.That(EmailControl.GetAttribute("placeholder"), Is.EqualTo(Constants.EMAIL),
                "Email placeholder is supposed to be \"" + Constants.EMAIL + "\".");
        }

        [Test]
        [Category("Placeholder is present.")]
        public void PlaceholderPassword()
        {
            Assert.That(PasswordControl.GetAttribute("placeholder"), Is.EqualTo(Constants.PASSWORD),
                "Password placeholder is supposed to be \"" + Constants.PASSWORD + "\".");
        }

        [Test]
        [Category("Placeholder is present.")]
        public void PlaceholderConfirmPassword()
        {
            Assert.That(ConfirmPasswordControl.GetAttribute("placeholder"), Is.EqualTo(Constants.CONFIRM_PASSWORD),
                "Confirm Password placeholder is supposed to be \"" + Constants.CONFIRM_PASSWORD + "\".");
        }

        [Test]
        [Category("Placeholder is present.")]
        public void PlaceholderSecurityQuestion()
        {
            Assert.That(SecurityQuestionControl.GetAttribute("placeholder"), Is.EqualTo(Constants.SEC_QUESTION),
                "Security Question placeholder is supposed to be \"" + Constants.SEC_QUESTION + "\".");
        }

        [Test]
        [Category("Placeholder is present.")]
        public void PlaceholderSecurityAnswer()
        {
            Assert.That(SecurityAnswerControl.GetAttribute("placeholder"), Is.EqualTo(Constants.SECURITY_ANSWER),
                "Security Answer placeholder is supposed to be \"" + Constants.SECURITY_ANSWER + "\".");
        }

        [Test]
        [Category("Placeholder is present.")]
        public void PlaceholderAddress1()
        {
            Assert.That(Address1Control.GetAttribute("placeholder"), Is.EqualTo(Constants.ADDRESS_1),
                "Address1 placeholder is supposed to be \"" + Constants.ADDRESS_1 + "\".");
        }

        [Test]
        [Category("Placeholder is present.")]
        public void PlaceholderAddress2()
        {
            Assert.That(Address2Control.GetAttribute("placeholder"), Is.EqualTo(Constants.ADDRESS_2),
                "Address2 placeholder is supposed to be \"" + Constants.ADDRESS_2 + "\".");
        }

        [Test]
        [Category("Placeholder is present.")]
        public void PlaceholderCity()
        {
            Assert.That(CityControl.GetAttribute("placeholder"), Is.EqualTo(Constants.CITY),
                "City placeholder is supposed to be \"" + Constants.CITY + "\".");
        }

        [Test]
        [Category("Placeholder is present.")]
        public void PlaceholderState()
        {
            Assert.That(StateControl.GetAttribute("placeholder"), Is.EqualTo(Constants.STATE),
                "State placeholder is supposed to be \"" + Constants.STATE + "\".");
        }

        [Test]
        [Category("Placeholder is present.")]
        public void PlaceholderZipCode()
        {
            Assert.That(ZipCodeControl.GetAttribute("placeholder"), Is.EqualTo(Constants.ZIPCODE),
                "Zipcode placeholder is supposed to be \"" + Constants.ZIPCODE + "\".");
        }

        [Test]
        [Category("Placeholder is present.")]
        public void PlaceholderTelephone()
        {
            Assert.That(TelephoneControl.GetAttribute("placeholder"), Is.EqualTo(Constants.TELEPHONE),
                "Telephone placeholder is supposed to be \"" + Constants.TELEPHONE + "\".");
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedHeading()
        {
            Assert.That(TitleControl.Text.Trim(), Is.EqualTo(Constants.PROFILE_HEADING));
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedSubmitButtonLabel()
        {
            string submitButtonText = Driver.ExtractTextFromXPath("/html/body/app-root/div/profile/form/div/button[1]/span/text()");
            Assert.That(submitButtonText.Trim(), Is.EqualTo("Submit"));
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedCancelButtonLabel()
        {
            string cancelButtonText = Driver.ExtractTextFromXPath("/html/body/app-root/div/profile/form/div/button[2]/span/text()");
            Assert.That(cancelButtonText.Trim(), Is.EqualTo("Cancel"));
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedPasswordPolicyPart1Label()
        {
            string passwordPolicyText1 = Driver.ExtractTextFromXPath("/html/body/app-root/div/profile/form/div/div/label/text()[1]");
            Assert.That(passwordPolicyText1, Is.EqualTo(Constants.PASSWORD_POLICY_1));
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedPasswordPolicyPart2Label()
        {
            string passwordPolicyText2 = Driver.ExtractTextFromXPath("/html/body/app-root/div/profile/form/div/div/label/text()[2]");
            Assert.That(passwordPolicyText2, Is.EqualTo(Constants.PASSWORD_POLICY_2));
        }

        /*T0-DO: Check for spelling/grammar errors for the selected options label tests.*/

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedSecurityQuestionDefault()
        {
            SelectSecurityQuestion(0);
            Assert.That(selectedSecurityQuestionControl, Is.EqualTo(Constants.DEFAULT_SEC_QUESTION));
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedSecurityQuestionOne()
        {
            SelectSecurityQuestion(1);
            Assert.That(selectedSecurityQuestionControl, Is.EqualTo(Constants.SEC_QUESTION_1));
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedSecurityQuestionTwo()
        {
            SelectSecurityQuestion(2);
            Assert.That(selectedSecurityQuestionControl, Is.EqualTo(Constants.SEC_QUESTION_2));
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedSecurityQuestionThree()
        {
            SelectSecurityQuestion(3);
            Assert.That(selectedSecurityQuestionControl, Is.EqualTo(Constants.SEC_QUESTION_3));
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedSecurityQuestionFour()
        {
            SelectSecurityQuestion(4);
            Assert.That(selectedSecurityQuestionControl, Is.EqualTo(Constants.SEC_QUESTION_4), "Flagged for inconsistency on purpose.");
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedSecurityQuestionFive()
        {
            SelectSecurityQuestion(5);
            Assert.That(selectedSecurityQuestionControl, Is.EqualTo(Constants.SEC_QUESTION_5));
        }

    }
}
