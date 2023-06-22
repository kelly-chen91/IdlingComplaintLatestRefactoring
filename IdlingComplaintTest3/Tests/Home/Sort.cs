using IdlingComplaints.Models.Home;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdlingComplaints.Tests.Home
{
    internal class Sort : HomeModel
    {
        public Sort() { }

        [OneTimeSetUp]
        public new void OneTimeSetUp() 
        {
            base.OneTimeSetUp();

        }

        [OneTimeTearDown]
        public new void OneTimeTearDown()
        {
            Thread.Sleep(2000);
            base.OneTimeTearDown();
        }

        [Test]
        [Category("Labels sort alphabetically or numerically.")]
        public void SortComplaintNumbers()
        {
            var body = TableControl.FindElement(By.TagName("tbody"));
            var rowList = body.FindElements(By.TagName("tr"));
            Thread.Sleep(2000);
            Console.WriteLine(rowList.Count);
            Assert.That(rowList.Count, Is.EqualTo(2));  
           
        }

    }
}
