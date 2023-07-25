using IdlingComplaints.Models.PasswordReset;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdlingComplaints.Tests.PasswordReset
{
    //[Parallelizable(ParallelScope.Fixtures)]
    //[FixtureLifeCycle(LifeCycle.SingleInstance)]
    internal class Test50_MaxLength_ConfirmReset : Test60_Label_ConfirmReset
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

        [SetUp]
        public new void SetUp()
        {
            base.SetUp();
        }

        [TearDown]
        public new void TearDown()
        {
            base.TearDown();
        }
        

        [Test, Category("Maxlength attribute is present")]
        public void MaxLength_SecurityAnswer()
        {
            var MaxLength = SecurityAnswerControl.GetAttribute("maxlength");
            Assert.True(MaxLength != null, "Flagged for inconsistency on purpose.");
        }

        [Test, Category("Maxlength attribute is present")]
        public void MaxLength_Password()
        {
            var MaxLength = PasswordControl.GetAttribute("maxlength");
            Assert.True(MaxLength != null, "Flagged for inconsistency on purpose.");
        }

        [Test, Category("Maxlength attribute is present")]
        public void MaxLength_ConfirmPassword()
        {
            var MaxLength = ConfirmPasswordControl.GetAttribute("maxlength");
            Assert.True(MaxLength != null, "Flagged for inconsistency on purpose.");
        }
    }

}
