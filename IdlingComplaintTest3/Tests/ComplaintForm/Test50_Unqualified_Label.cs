using IdlingComplaints.Models.ComplaintForm;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdlingComplaints.Tests.ComplaintForm.Complaint;

namespace IdlingComplaints.Tests.ComplaintForm
{
    internal class Test50_Unqualified_Label : ComplaintFormModel
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            base.ComplaintFormModelSetUp(false);
        }
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            base.ComplaintFormModelTearDown();
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
