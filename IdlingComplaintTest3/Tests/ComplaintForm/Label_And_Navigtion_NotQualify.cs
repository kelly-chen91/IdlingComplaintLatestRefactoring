using IdlingComplaints.Models.ComplaintForm;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdlingComplaints.Tests.Login;

namespace IdlingComplaints.Tests.ComplaintForm
{
    internal class Label_Navigtion_NotQualify : ComplaintFormModel
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

        [Test, Category("Label Test")]
        public void DisplayNotQualifyMessage()
        {
            ClickYesButton();
            string test = Driver.FindElement(By.CssSelector("label[for='criteriaError']")).Text;
            Assert.That(test, Is.EqualTo(Constants.YES_LABEL));
        }


    }
}
