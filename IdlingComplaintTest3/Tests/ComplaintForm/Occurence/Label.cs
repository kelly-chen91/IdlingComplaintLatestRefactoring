using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdlingComplaints.Models.ComplaintForm;

namespace IdlingComplaints.Tests.ComplaintForm.Occurance
{
    internal class Label : ComplaintFormModel
    {
        public Label() { }
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

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedOccurenceFrom()
        {
            //Assert.That(OccurenceFromControl.GetAttribute(""))
        }
    }
}
