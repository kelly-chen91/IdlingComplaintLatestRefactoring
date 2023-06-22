using IdlingComplaints.Models.Home;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumUtilities.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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
            var rowList = TableControl.GetDataFromTable();
            //Console.WriteLine(rowList.Count);

            List<string> sortedComplaintNumberTextList = rowList.GetSpecifiedRow("mat-column-idc_name");

            sortedComplaintNumberTextList.Sort();
            SortComplaintNumControl.Click();
            //Thread.Sleep(5000);
            var sortedRowList =TableControl.GetDataFromTable();
            List<string> unsortedComplaintNumberTextList = sortedRowList.GetSpecifiedRow("mat-column-idc_name");
            for (int i = 0; i < unsortedComplaintNumberTextList.Count; i++)
            {
                Console.WriteLine("sorted" + sortedComplaintNumberTextList[i]);
                Console.WriteLine("unsorted" + unsortedComplaintNumberTextList[i]);

                Assert.That(sortedComplaintNumberTextList[i], Is.EqualTo(unsortedComplaintNumberTextList[i]));
            } 
       
            Assert.That(rowList.Count, Is.EqualTo(2));  
           
        }
    }
}
