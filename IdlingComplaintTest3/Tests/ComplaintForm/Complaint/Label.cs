using IdlingComplaints.Models.ComplaintForm;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumUtilities.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdlingComplaints.Tests.ComplaintForm.Complainant
{
    internal class Label : ComplaintFormModel
    {
        [OneTimeSetUp]
        public new void OneTimeSetUp()
        {
            base.OneTimeSetUp();
            
            ClickNoButton();
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(d => d.FindElement(By.CssSelector("input[formcontrolname='idc_associatedlastname']")));
        }
        [OneTimeTearDown]
        public new void OneTimeTearDown()
        {
            base.OneTimeTearDown();
        }


        [Test, Category("Correct Label Displayed")]
        public void Heading()
        {
            string text = Driver.ExtractTextFromXPath("/html/body/app-root/div/idling-complaint/form/div/mat-card[2]/mat-card-header/div/mat-card-title/h4/text()");
                                                        
            Assert.That(text, Is.EqualTo(Constants.COMPLAINT_TITLE));
        }

    }
}
