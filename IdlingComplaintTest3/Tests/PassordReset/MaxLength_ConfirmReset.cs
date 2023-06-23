﻿using IdlingComplaints.Models.PasswordReset;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdlingComplaints.Tests.PassordReset
{
    internal class MaxLength_ConfirmReset: Label_ConfirmReset
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

       
        [Test, Category("maxlength attribute is missing")]
        public void SecurityAnswerMaxLength()
        {
            var MaxLength = SecurityAnswerControl.GetAttribute("maxlength");
            Assert.True(MaxLength != null, "Flagged for inconsistency on purpose.");
        }

        [Test, Category("maxlength attribute is missing")]
        public void PasswordMaxLength()
        {
            var MaxLength = PasswordControl.GetAttribute("maxlength");
            Assert.True(MaxLength != null, "Flagged for inconsistency on purpose.");
        }

        [Test, Category("maxlength attribute is missing")]
        public void ConfirmPasswordMaxLength()
        {
            var MaxLength = ConfirmPasswordControl.GetAttribute("maxlength");
            Assert.True(MaxLength != null, "Flagged for inconsistency on purpose.");
        }
    }

}