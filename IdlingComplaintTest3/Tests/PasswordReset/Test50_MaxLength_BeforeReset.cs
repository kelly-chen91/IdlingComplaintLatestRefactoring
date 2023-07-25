using IdlingComplaints.Models.PasswordReset;
using SeleniumUtilities.Base;
using SeleniumUtilities.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdlingComplaints.Tests.PasswordReset
{
    //[Parallelizable(ParallelScope.Fixtures)]
    //[FixtureLifeCycle(LifeCycle.SingleInstance)]
    internal class Test50_MaxLength_BeforeReset : PasswordResetModel
    {
        private const int MAXLENGTH = 50;

        BaseExtent extent;

        public Test50_MaxLength_BeforeReset()
        {
            extent = new BaseExtent();
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            extent.SetUp(false, GetType().Namespace + "." + GetType().Name);;
            base.PasswordResetModelSetUp(true);

        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            extent.TearDown(false, Driver);
            base.PasswordResetModelTearDown();

        }

        [SetUp]
        public void SetUp()
        {
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

        [Test, Category("Maxlength attribute is present")]
        public void MaxLengthEmail()
        {
            var MaxLength = EmailControl.GetAttribute("maxlength");
            Assert.True(MaxLength != null, "Flagged for inconsistency on purpose.");
        }
    }
}
