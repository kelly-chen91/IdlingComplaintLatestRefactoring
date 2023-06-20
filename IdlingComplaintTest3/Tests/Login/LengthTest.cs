using IdlingComplaintTest.Pages.Login;
using IdlingComplaintTest.Utils;

namespace IdlingComplaintTest.Tests.Login
{
    //[Parallelizable(ParallelScope.Children)]
    //[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    internal class LengthTest : LoginModel
    {
        private const int MAXLENGTH = 50;

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

        //Length of Email is more than 50 characters.
        //Challenge: Should we test if the user have a valid email address/password? 
        [Test]
        [Category("Invalid Email/Password Length")]
        public void LongEmailInputLength()
        {
            string email = StringUtilities.GenerateRandomEmail(68);
            EmailInput = email;

            Assert.That(EmailInput.Length, Is.LessThanOrEqualTo(MAXLENGTH)); //checks that the email length is <= MAXLENGTH chars
            Assert.That(EmailInput, Is.EqualTo(email)); //checks that the email cuts off to MAXLENGTH chars length
        }

        //Length of Password is more than MAXLENGTH characters. 
        [Test]
        [Category("Invalid Email/Password Length")]
        public void LongPasswordInputLength()
        {
            PasswordInput = "sadjklfsaiwerkladjfskljfdsajkflsdjaklfjdsklfiorjkljklfsdaklsjkldafsd";
            
            Assert.That(PasswordInput.Length, Is.LessThanOrEqualTo(MAXLENGTH)); //checks that the password length is <= MAXLENGTH chars
            Assert.That(PasswordInput, Is.EqualTo("Sadjklfsaiwerkladjfskljfdsajkflsdjaklfjdsklfiorjkl")); //checks that the password cuts off to MAXLENGTH chars length
        }

        //Length of Email is less than MAXLENGTH characters
        [Test]
        [Category("Valid Email/Password Length")]
        public void ValidEmailInputLength()
        {
            EmailInput = "test@gmail.com";
            
            Assert.That(EmailInput.Contains("@"), Is.EqualTo(true)); //checks if the email is valid
            Assert.That(EmailInput.Length, Is.LessThanOrEqualTo(MAXLENGTH)); //checks that the email length is <= MAXLENGTH chars
            Assert.That(EmailInput, Is.EqualTo("test@gmail.com")); //checks that the email cuts off to MAXLENGTH chars if > MAXLENGTH chars
        }

        //Length of Password is less than MAXLENGTH characters
        [Test]
        [Category("Valid Email/Password Length")]
        public void ValidPasswordInputLength()
        {
            PasswordInput = "Test99990";
            
            Assert.That(PasswordInput.Length, Is.LessThanOrEqualTo(MAXLENGTH)); //checks that the password length is <= MAXLENGTH chars
            Assert.That(PasswordInput, Is.EqualTo("Test99990")); //checks that the password cuts off to MAXLENGTH chars if > MAXLENGTH chars
        }

        //Length of Email is equal MAXLENGTH characters
        [Test]
        [Category("Valid Email/Password Length")]
        public void ValidEmailInputAtCutOffLength()
        {
            EmailInput = "Sadjklfsaiwerkladjfskljfdsajkflsdjaklfjd@gmail.com";
            
            Assert.That(EmailInput.Contains("@"), Is.EqualTo(true)); //checks if the email is valid
            Assert.That(EmailInput.Length, Is.LessThanOrEqualTo(MAXLENGTH)); //checks that the email length is <= MAXLENGTH chars
            Assert.That(EmailInput, Is.EqualTo("Sadjklfsaiwerkladjfskljfdsajkflsdjaklfjd@gmail.com")); //checks that the email cuts off to MAXLENGTH chars if > MAXLENGTH chars
        }

        //Length of Password is equal MAXLENGTH characters
        [Test]
        [Category("Valid Email/Password Length")]
        public void ValidPasswordInputAtCutOffLength()
        {
            string password = StringUtilities.GenerateRandomString(50);
            PasswordInput = password;

            Assert.That(PasswordInput.Length, Is.LessThanOrEqualTo(MAXLENGTH)); //checks that the password length is <= MAXLENGTH chars
            Assert.That(PasswordInput, Is.EqualTo(password)); //checks that the password cuts off to MAXLENGTH chars if > MAXLENGTH chars
        }


        //Length of Email is 0, which is invalid
        [Test]
        [Category("Invalid Email/Password Length")]
        public void EmptyEmailInputLength()
        {
            EmailInput = string.Empty;
            
            Assert.That(EmailInput, Is.Empty); //checks that the email is empty
        }

        [Test]
        [Category("Invalid Email/Password Length")]
        public void EmptyPasswordInputLength()
        {
            PasswordInput = string.Empty;
            
            Assert.That(PasswordInput.Length, Is.LessThanOrEqualTo(MAXLENGTH), "The password has exceeded maxlength."); //checks that the password length is <= MAXLENGTH chars

            Assert.That(PasswordInput, Is.Empty, "The password is not empty"); //checks that the password is empty
        }

        [Test]
        public void CheckMaxLengthAttribute()
        {
            int maxLength = EmailControl.MaxLengthAttributeValue();

            Assert.That(maxLength, Is.EqualTo(MAXLENGTH));
        }

        [Test]
        public void RandomStringTest()
        {
            string random = StringUtilities.GenerateRandomString(10);
            Console.WriteLine(random);
            Assert.That(random.Length, Is.EqualTo(10), "Random string length does not equal to 10");
        }
    }
}
