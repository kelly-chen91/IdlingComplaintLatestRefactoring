using IdlingComplaints.Models.Login;
using SeleniumUtilities.Utils;

namespace IdlingComplaints.Tests.Login
{
    //[Parallelizable(ParallelScope.Children)]
    //[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    internal class MaxLength : LoginModel
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

        [Test]
        [Category("Maxlength attribute is present")]
        public void MaxlengthEmail()
        {
            int emailMaxlength = EmailControl.MaxLengthAttributeValue();
            Assert.That(emailMaxlength, Is.EqualTo(Constants.MAX_EMAIL_LENGTH));
        }

        [Test]
        [Category("Maxlength attribute is present")]
        public void MaxlengthPassword()
        {
            int passwordMaxlength = PasswordControl.MaxLengthAttributeValue();
            Assert.That(passwordMaxlength, Is.EqualTo(Constants.MAX_PASSWORD_LENGTH));
        }

    }
}
