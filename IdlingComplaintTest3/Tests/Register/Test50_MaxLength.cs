using IdlingComplaints.Models.Register;
using IdlingComplaints.Tests.Login;
using SeleniumUtilities.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdlingComplaints.Tests.Register
{
    internal class Test50_MaxLength : RegisterModel
    {
        // private readonly RegisterModel registerModel;

        BaseExtent extent;

        public Test50_MaxLength()
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
            base.RegisterModelSetUp(true);
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
            finally
            {
                base.RegisterModelTearDown();
            }
        }

        [Test]
        [Category("Maxlength attribute is present")]
        public void MaxlengthFirstName()
        {
            int firstNameMaxlength = FirstNameControl.MaxLengthAttributeValue();

            Assert.That(firstNameMaxlength, Is.EqualTo(Constants.MAX_NAME_LENGTH), "The maxlength attribute for first name is supposed to be: " + Constants.MAX_NAME_LENGTH);
        }

        public void MaxlengthLastName()
        {
            int lastNameMaxlength = LastNameControl.MaxLengthAttributeValue();

            Assert.That(lastNameMaxlength, Is.EqualTo(Constants.MAX_NAME_LENGTH), "The maxlength attribute for last name is supposed to be: " + Constants.MAX_NAME_LENGTH); //group with above
        }

        [Test]
        [Category("Maxlength attribute is present")]
        public void MaxlengthEmail()
        {
            int emailMaxlength = EmailControl.MaxLengthAttributeValue();
            Assert.That(emailMaxlength, Is.EqualTo(Constants.MAX_EMAIL_LENGTH), "The maxlength attribute for email is supposed to be: " + Constants.MAX_EMAIL_LENGTH);
        }

        [Test]
        [Category("Maxlength attribute is present")]
        public void MaxlengthPassword()
        {
            int passwordMaxlength = PasswordControl.MaxLengthAttributeValue();
            Assert.That(passwordMaxlength, Is.EqualTo(Constants.MAX_PASSWORD_LENGTH), "The maxlength attribute for password is supposed to be: " + Constants.MAX_PASSWORD_LENGTH);
        }

        [Test]
        [Category("Maxlength attribute is present")]
        public void MaxlengthConfirmPassword()
        {
            int confirmPasswordMaxlength = ConfirmPasswordControl.MaxLengthAttributeValue();
            Assert.That(confirmPasswordMaxlength, Is.EqualTo(Constants.MAX_PASSWORD_LENGTH), "The maxlength attribute for confirm password is supposed to be: " + Constants.MAX_PASSWORD_LENGTH);//group with above

        }

        [Test]
        [Category("Maxlength attribute is present")]
        public void MaxlengthSecurityAnswer()
        {
            int securityAnswerMaxlength = SecurityAnswerControl.MaxLengthAttributeValue();
            Assert.That(securityAnswerMaxlength, Is.EqualTo(Constants.MAX_SECURITY_ANSWER_LENGTH), "The maxlength attribute for security answer is supposed to be: " + Constants.MAX_SECURITY_ANSWER_LENGTH);

        }

        [Test]
        [Category("Maxlength attribute is present")]
        public void MaxlengthAddress1()
        {
            int address1MaxLength = Address1Control.MaxLengthAttributeValue();
            Assert.That(address1MaxLength, Is.EqualTo(Constants.MAX_ADDRESS_LENGTH), "The maxlength attribute for address1 is supposed to be: " + Constants.MAX_ADDRESS_LENGTH);
        }

        [Test]
        [Category("Maxlength attribute is present")]
        public void MaxlengthAddress2()
        {
            int address2MaxLength = Address2Control.MaxLengthAttributeValue();
            Assert.That(address2MaxLength, Is.EqualTo(Constants.MAX_ADDRESS_LENGTH), "The maxlength attribute for address2 is supposed to be: " + Constants.MAX_ADDRESS_LENGTH);
        }

        [Test]
        [Category("Maxlength attribute is present")]
        public void MaxlengthCity()
        {
            int cityMaxLength = CityControl.MaxLengthAttributeValue();
            Assert.That(cityMaxLength, Is.EqualTo(Constants.MAX_CITY_LENGTH), "The maxlength attribute for city is supposed to be: " + Constants.MAX_CITY_LENGTH);

        }

        [Test]
        [Category("Maxlength attribute is present")]
        public void MaxlengthZipCode()
        {
            int zipcodeMaxLength = ZipCodeControl.MaxLengthAttributeValue();
            Assert.That(zipcodeMaxLength, Is.EqualTo(Constants.MAX_ZIPCODE_LENGTH), "The maxlength attribute for zip code is supposed to be: " + Constants.MAX_ZIPCODE_LENGTH);

        }

        [Test]
        [Category("Maxlength attribute is present")]
        public void MaxlengthTelephone()
        {
            int telephoneMaxLength = TelephoneControl.MaxLengthAttributeValue();
            Assert.That(telephoneMaxLength, Is.EqualTo(Constants.MAX_PHONE_NUMBER_LENGTH), "The maxlength attribute for telephone is supposed to be: " + Constants.MAX_PHONE_NUMBER_LENGTH);

        }

    }
}
