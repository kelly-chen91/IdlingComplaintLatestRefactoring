using IdlingComplaintTest.Pages.Register;
using IdlingComplaintTest.Tests.Login;
using SeleniumUtilities.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdlingComplaintTest.Tests.Register
{
    internal class InputLengthTest : RegisterModel
    {
       // private readonly RegisterModel registerModel;


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
        [Category("Failed Test: Did not contain Maxlength Attribute")]
        public void NameMaxLengthAttribute()
        {
           int FirstNameMaxLengthAttribute = FirstNameControl.MaxLengthAttributeValue();
            int LastNameMaxLengthAttribute = FirstNameControl.MaxLengthAttributeValue();
  
            Assert.That(FirstNameMaxLengthAttribute, Is.EqualTo(Constants.MAX_NAME_LENGTH), "The maxlength attribute for name is supposed to be: " + Constants.MAX_NAME_LENGTH);
            Assert.That(LastNameMaxLengthAttribute, Is.EqualTo(Constants.MAX_NAME_LENGTH), "The maxlength attribute for name is supposed to be: " + Constants.MAX_NAME_LENGTH); //group with above
        }

        [Test]
        [Category("Failed Test: Did not contain Maxlength Attribute")]
        public void EmailMaxLengthAttribute()
       {
            int EmailMaxLengthAttribute = EmailControl.MaxLengthAttributeValue();
            Assert.That(EmailMaxLengthAttribute, Is.EqualTo(Constants.MAX_EMAIL_LENGTH), "The maxlength attribute for email is supposed to be: " + Constants.MAX_EMAIL_LENGTH);
        }
 
        [Test]
        [Category("Failed Test: Did not contain Maxlength Attribute")]
        public void PasswordMaxLengthAttribute()
        {
            int SecurityAnswerMaxlengthAttribute = SecurityAnswerControl.MaxLengthAttributeValue();
            int ConfirmSecurityAnswerMaxlengthAttribute = ConfirmPasswordControl.MaxLengthAttributeValue();
            Assert.That(SecurityAnswerMaxlengthAttribute, Is.EqualTo(Constants.MAX_PASSWORD_LENGTH), "The maxlength attribute for password is supposed to be: " + Constants.MAX_PASSWORD_LENGTH);
            Assert.That(ConfirmSecurityAnswerMaxlengthAttribute, Is.EqualTo(Constants.MAX_PASSWORD_LENGTH), "The maxlength attribute for email is supposed to be: " + Constants.MAX_PASSWORD_LENGTH);//group with above
 
        }
    
        [Test]
        [Category("Failed Test: Did not contain Maxlength Attribute")]
        public void SecurityAnswerMaxLengthAttribute()
        {
            int SecurityAnswerMaxLengthAttribute =  SecurityAnswerControl.MaxLengthAttributeValue();
            Assert.That(SecurityAnswerMaxLengthAttribute, Is.EqualTo(Constants.MAX_SECURITY_ANSWER_LENGTH), "The maxlength attribute for email is supposed to be: " + Constants.MAX_SECURITY_ANSWER_LENGTH);
    
        }
    
        [Test]
        [Category("Failed Test: Did not contain Maxlength Attribute")]
        public void AddressMaxLengthAttribute()
        {
            int Address1MaxLengthAttribute = Address1Control.MaxLengthAttributeValue();
            int Address2MaxLengthAttribute = Address2Control.MaxLengthAttributeValue();
            Assert.That(Address1MaxLengthAttribute, Is.EqualTo(Constants.MAX_ADDRESS_LENGTH), "The maxlength attribute for email is supposed to be: " + Constants.MAX_ADDRESS_LENGTH);
            Assert.That(Address1MaxLengthAttribute, Is.EqualTo(Constants.MAX_ADDRESS_LENGTH), "The maxlength attribute for email is supposed to be: " + Constants.MAX_ADDRESS_LENGTH);
        }
    
        [Test]
        [Category("Failed Test: Did not contain Maxlength Attribute")]
        public void CityMaxLengthAttribute()
        {
            int CityMaxLengthAttribute = CityControl.MaxLengthAttributeValue();
            Assert.That(CityMaxLengthAttribute, Is.EqualTo(Constants.MAX_CITY_LENGTH), "The maxlength attribute for email is supposed to be: " + Constants.MAX_CITY_LENGTH);
    
        }
    
        [Test]
        [Category("Failed Test: Did not contain Maxlength Attribute")]
        public void ZipCodeMaxLengthAttribute()
        {
            int ZipCodeMaxLengthAttribute = ZipCodeControl.MaxLengthAttributeValue();
            Assert.That(ZipCodeMaxLengthAttribute, Is.EqualTo(Constants.MAX_ZIPCODE_LENGTH), "The maxlength attribute for email is supposed to be: " + Constants.MAX_ZIPCODE_LENGTH);
    
        }
    
        [Test]
        [Category("Failed Test: Did not contain Maxlength Attribute")]
        public void TelephoneMaxLengthAttribute()
        {
            int TelephoneMaxLengthAtribute = TelephoneControl.MaxLengthAttributeValue();
            Assert.That(TelephoneMaxLengthAtribute, Is.EqualTo(Constants.MAX_PHONE_NUMBER_LENGTH), "The maxlength attribute for email is supposed to be: " + Constants.MAX_PHONE_NUMBER_LENGTH);
    
        }
    
    }
}
