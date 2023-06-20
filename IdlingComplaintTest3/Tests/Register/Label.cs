using IdlingComplaintTest.Pages.Register;
using IdlingComplaintTest.Tests.Login;
using SeleniumUtilities.Utils;
using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdlingComplaintTest.Tests.Register
{

    internal partial class Label : RegisterModel
    {
        //  private RegisterModel createAnAccountModel;

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
        [Category("Passing Test: Label Checked")]
        public void HeadingTest()
        {
            Assert.That(TitleControl.Text.Trim(), Is.EqualTo(Constants.PROFILE_HEADING));
        }

        [Test]
        [Category("Passing Test: Label Checked")]
        public void PlaceholderFirstNameTest()
        {
            Assert.That(FirstNameControl.GetAttribute("placeholder"), Is.EqualTo(Constants.FIRST_NAME),
                "First name placeholder is supposed to be \"" + Constants.FIRST_NAME + "\".");
            //Assert.That(registerModel.SelectSecurityQuestionValue(), Is.EqualTo(DEFAULT_SEC_QUESTION));
            //Assert.That(registerModel.GetStateValue(), Is.EqualTo(DEFAULT_STATE));
        }

        [Test]
        [Category("Passing Test: Label Checked")]
        public void PlaceholderLastNameTest()
        {
            Assert.That(LastNameControl.GetAttribute("placeholder"), Is.EqualTo(Constants.LAST_NAME),
                "Last name placeholder is supposed to be \"" + Constants.LAST_NAME + "\".");
        }

        [Test]
        [Category("Passing Test: Label Checked")]
        public void PlaceholderEmailTest()
        {
            Assert.That(EmailControl.GetAttribute("placeholder"), Is.EqualTo(Constants.EMAIL),
                "Email placeholder is supposed to be \"" + Constants.EMAIL + "\".");
        }

        [Test]
        [Category("Passing Test: Label Checked")]
        public void PlaceholderPasswordTest()
        {
            Assert.That(PasswordControl.GetAttribute("placeholder"), Is.EqualTo(Constants.PASSWORD),
                "Password placeholder is supposed to be \"" + Constants.PASSWORD + "\".");
        }

        [Test]
        [Category("Passing Test: Label Checked")]
        public void PlaceholderConfirmPasswordTest()
        {
            Assert.That(ConfirmPasswordControl.GetAttribute("placeholder"), Is.EqualTo(Constants.CONFIRM_PASSWORD),
                "Confirm Password placeholder is supposed to be \"" + Constants.CONFIRM_PASSWORD + "\".");
        }

        [Test]
        [Category("Passing Test: Label Checked")]
        public void PlaceholderSecurityQuestionTest()
        {
            Assert.That(SecurityQuestionControl.GetAttribute("placeholder"), Is.EqualTo(Constants.SEC_QUESTION),
                "Security Question placeholder is supposed to be \"" + Constants.SEC_QUESTION + "\".");
        }

        [Test]
        [Category("Passing Test: Label Checked")]
        public void PlaceholderSecurityAnswerTest()
        {
            Assert.That(SecurityAnswerControl.GetAttribute("placeholder"), Is.EqualTo(Constants.SECURITY_ANSWER),
                "Security Answer placeholder is supposed to be \"" + Constants.SECURITY_ANSWER + "\".");
        }

        [Test]
        [Category("Passing Test: Label Checked")]
        public void PlaceholderAddress1Test()
        {
            Assert.That(Address1Control.GetAttribute("placeholder"), Is.EqualTo(Constants.ADDRESS_1),
                "Address1 placeholder is supposed to be \"" + Constants.ADDRESS_1 + "\".");
        }

        [Test]
        [Category("Passing Test: Label Checked")]
        public void PlaceholderAddress2Test()
        {
            Assert.That(Address2Control.GetAttribute("placeholder"), Is.EqualTo(Constants.ADDRESS_2),
                "Address2 placeholder is supposed to be \"" + Constants.ADDRESS_2 + "\".");
        }

        [Test]
        [Category("Passing Test: Label Checked")]
        public void PlaceholderCityTest()
        {
            Assert.That(CityControl.GetAttribute("placeholder"), Is.EqualTo(Constants.CITY),
                "City placeholder is supposed to be \"" + Constants.CITY + "\".");
        }

        [Test]
        [Category("Passing Test: Label Checked")]
        public void PlaceholderStateTest()
        {
            Assert.That(StateControl.GetAttribute("placeholder"), Is.EqualTo(Constants.STATE),
                "State placeholder is supposed to be \"" + Constants.STATE + "\".");
        }

        [Test]
        [Category("Passing Test: Label Checked")]
        public void PlaceholderZipCodeTest()
        {
            Assert.That(ZipCodeControl.GetAttribute("placeholder"), Is.EqualTo(Constants.ZIPCODE),
                "Zipcode placeholder is supposed to be \"" + Constants.ZIPCODE + "\".");
        }

        [Test]
        [Category("Passing Test: Label Checked")]
        public void PlaceholderTelephoneTest()
        {
            Assert.That(TelephoneControl.GetAttribute("placeholder"), Is.EqualTo(Constants.TELEPHONE),
                "Telephone placeholder is supposed to be \"" + Constants.TELEPHONE + "\".");
        }


        [Test]
        [Category("Passing Test: Label Checked")]
        public void SubmitButtonLabelTest()
        {
            string submitButtonText = Driver.ExtractTextFromXPath("/html/body/app-root/div/profile/form/div/button[1]/span/text()");
            Assert.That(submitButtonText.Trim(), Is.EqualTo("Submit"));
        }

        [Test]
        [Category("Passing Test: Label Checked")]
        public void CancelButtonLabelTest()
        {
            string cancelButtonText = Driver.ExtractTextFromXPath("/html/body/app-root/div/profile/form/div/button[2]/span/text()");
            Assert.That(cancelButtonText.Trim(), Is.EqualTo("Cancel"));
        }

        [Test]
        [Category("Passing Test: Label Checked")]
        public void PasswordPolicyLabelTest()
        {
            string passwordPolicyText1 = Driver.ExtractTextFromXPath("/html/body/app-root/div/profile/form/div/div/label/text()[1]");
            string passwordPolicyText2 = Driver.ExtractTextFromXPath("/html/body/app-root/div/profile/form/div/div/label/text()[2]");
            Assert.That(passwordPolicyText1, Is.EqualTo(Constants.PASSWORD_POLICY_1));
            Assert.That(passwordPolicyText2, Is.EqualTo(Constants.PASSWORD_POLICY_2));
        }

        /*T0-DO: Check for spelling/grammar errors for the selected options label tests.*/

    }
}
