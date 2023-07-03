using IdlingComplaints.Models.ComplaintForm;
using IdlingComplaints.Tests.ComplaintForm.Complaint;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumUtilities.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdlingComplaints.Tests.ComplaintForm.Associated
{
    internal class Test30_RequiredLabelErrors : ComplaintFormModel
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            base.ComplaintFormModelSetUp(false);
            ClickNoButton();
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(d => d.FindElement(By.CssSelector("input[formcontrolname='idc_associatedlastname']")));
        }
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            base.ComplaintFormModelTearDown();
        }


        [Test, Category("Required Field Missing - Error Label Displayed")]
        public void AcknowledgementRequire()
        {
            ClickWitnessCheckbox();
            ClickWitnessCheckbox();

            string requireContent = Driver.ExtractTextFromXPath("//mat-card[5]/mat-card-content/div/mat-error/text()");
            Assert.That(requireContent, Is.EqualTo(Constants.REQUIRED_ACKNOWLEDGEMENT), "Flagged for inconsistency on purpose.");
        }

        [Test, Category("Required Field Missing - Error Label Displayed")]
        public void CorrectionAcknowledgementRequire()
        {
            ClickSubmitNoCorrectionCheckbox();
            ClickSubmitNoCorrectionCheckbox();

            string requireContent = Driver.ExtractTextFromXPath("//mat-card[6]/mat-card-content/div/mat-error/text()");
            Assert.That(requireContent, Is.EqualTo(Constants.REQUIRED_ACKNOWLEDGEMENT), "Flagged for inconsistency on purpose.");
        }


        [Test, Category("Required Field Fulfilled - Error Label Hidden")]
        public void ProvidedAcknowledgement()
        {
            ClickWitnessCheckbox();

            string requireContent = Driver.ExtractTextFromXPath("//mat-card[5]/mat-card-content/div/mat-error/text()");
            Assert.That(requireContent, Is.EqualTo(string.Empty));
        }

        [Test, Category("Required Field Fulfilled - Error Label Hidden")]
        public void ProvidedNoCorrectionCheckbox()
        {
            ClickSubmitNoCorrectionCheckbox();

            string requireContent = Driver.ExtractTextFromXPath("//mat-card[6]/mat-card-content/div/mat-error");
            Assert.That(requireContent, Is.EqualTo(string.Empty));
        }

    }
}
