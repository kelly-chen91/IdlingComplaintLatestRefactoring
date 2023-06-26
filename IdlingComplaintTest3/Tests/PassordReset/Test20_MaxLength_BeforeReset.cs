using IdlingComplaints.Models.PasswordReset;
using SeleniumUtilities.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdlingComplaints.Tests.PassordReset
{
    internal class Test20_MaxLength_BeforeReset : PasswordResetModel
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

        [Test, Category("Maxlength attribute is missing")]
        public void MaxLengthEmail()
        {
            var MaxLength = EmailControl.GetAttribute("maxlength");
            Assert.True(MaxLength != null, "Flagged for inconsistency on purpose.");
        }
    }
}
