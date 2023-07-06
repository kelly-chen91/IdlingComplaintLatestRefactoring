using IdlingComplaints.Models.Login;
using SeleniumUtilities.Utils;

namespace IdlingComplaints.Tests.Login
{
    //[Parallelizable(ParallelScope.Children)]
    //[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    internal class Test50_MaxLength : LoginModel
    {
        private const int MAXLENGTH = 50;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            base.LoginModelSetUp(true);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            base.LoginModelTearDown();
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
