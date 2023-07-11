using IdlingComplaints.Models.PasswordReset;
using SeleniumUtilities.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdlingComplaints.Tests.PasswordReset
{
    internal class Test50_MaxLength_BeforeReset : PasswordResetModel
    {
        private const int MAXLENGTH = 50;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            base.PasswordResetModelSetUp(true);
        }
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            base.PasswordResetModelTearDown();
        }

        [Test, Category("Maxlength attribute is present")]
        public void MaxLengthEmail()
        {
            var MaxLength = EmailControl.GetAttribute("maxlength");
            Assert.True(MaxLength != null, "Flagged for inconsistency on purpose.");
        }
    }
}
