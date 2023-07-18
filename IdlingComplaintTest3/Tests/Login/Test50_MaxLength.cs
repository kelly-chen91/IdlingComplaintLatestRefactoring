using IdlingComplaints.Models.Login;
using SeleniumUtilities.Utils;

namespace IdlingComplaints.Tests.Login
{
    //[Parallelizable(ParallelScope.Children)]
    //[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    internal class Test50_MaxLength : LoginModel
    {
        private const int MAXLENGTH = 50;

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
            extent.TearDown(false);
        }

        [SetUp]
        public void SetUp()
        {
            base.LoginModelSetUp(true);
            extent.SetUp(true);

        }

        [TearDown]
        public void TearDown()
        {
            try
            {
                extent.TearDown(true);
            }
            catch (Exception ex)
            {
                throw new Exception("Exception: " + ex);
            }
            finally
            {
                base.LoginModelTearDown();
            }
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
