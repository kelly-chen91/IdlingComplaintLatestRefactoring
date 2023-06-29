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
<<<<<<<< HEAD:IdlingComplaintTest3/Tests/ComplaintForm/Test60_Unqualified_Label.cs
    internal class Test60_Unqualified_Label : ComplaintFormModel
========
    internal class Test50_Unqualified_Label : ComplaintFormModel
>>>>>>>> e818ac622b927c70ddffb813c1daa44051f9ae3f:IdlingComplaintTest3/Tests/ComplaintForm/Test50_Unqualified_Label.cs
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
