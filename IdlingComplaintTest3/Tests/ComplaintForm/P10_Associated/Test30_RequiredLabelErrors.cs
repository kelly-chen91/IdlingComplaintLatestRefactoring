using IdlingComplaints.Models.ComplaintForm;
using IdlingComplaints.Tests.ComplaintForm.P10_Associated;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumUtilities.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdlingComplaints.Tests.ComplaintForm.P10_Associated
{
    [Parallelizable(ParallelScope.Fixtures)]
    [FixtureLifeCycle(LifeCycle.SingleInstance)]
    internal class Test30_RequiredLabelErrors : ComplaintFormModel
    {
        BaseExtent extent;

        public Test30_RequiredLabelErrors()
        {
            extent = new BaseExtent();
        }
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            extent.SetUp(false, GetType().Namespace + "." + GetType().Name);;

            base.ComplaintFormModelSetUp(true);
            NewComplaintSetUp();
            ClickNo();
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            wait.Until(d => d.FindElement(By.CssSelector("input[formcontrolname='idc_associatedlastname']")));

        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            extent.TearDown(false, Driver);

            base.ComplaintFormModelTearDown();
        }

        [SetUp]
        public void SetUp()
        {
            //base.ComplaintFormModelSetUp(true);
            //NewComplaintSetUp();
            //ClickNo();
            //var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            //wait.Until(d => d.FindElement(By.CssSelector("input[formcontrolname='idc_associatedlastname']")));

            extent.SetUp(true);
        }

        [TearDown]
        public void TearDown()
        {
            try
            {
                extent.TearDown(true, Driver);
            }
            catch (Exception ex)
            {
                throw new Exception("Exception: " + ex);
            }
            //finally
            //{
            //    base.ComplaintFormModelTearDown();
            //}
        }

        private readonly int SLEEP_TIMER = 0;

        [Test, Category("Required Field Missing - Error Label Displayed")]
        public void MissingHouseNumber()
        {
            Associated_HouseNumberControl.SendTextDeleteTabWithDelay("XX", SLEEP_TIMER);

            Assert.That((Object)" ", Is.EqualTo(Constants.HOUSENUMBER_REQUIRE), "Flagged for inconsistency on purpose.");
        }

        [Test, Category("Required Field Missing - Error Label Displayed")]
        public void MissingCompanyName()
        {
            Associated_CompanyNameControl.SendTextDeleteTabWithDelay("XX", SLEEP_TIMER);
            var text = Driver.ExtractTextFromXPath("//mat-card[2]/mat-card-content/div[1]/mat-form-field[1]/div/div[3]/div/mat-error/text()");

            Assert.That(text, Is.EqualTo(Constants.COMPANY_NAME_REQUIRE), "Flagged for inconsistency on purpose.");
        }

        [Test, Category("Required Field Missing - Error Label Displayed")]
        public void MissingStreet_NoPOBox()
        {
            Associated_StreetNameControl.SendTextDeleteTabWithDelay("XX", SLEEP_TIMER);
            var text = Driver.ExtractTextFromXPath("//mat-card[2]/mat-card-content/div[3]/mat-form-field[2]/div/div[3]/div/mat-error/text()");

            Assert.That(text, Is.EqualTo(Constants.STREET_NAME_REQUIRE), "Flagged for inconsistency on purpose.");
        }

        [Test, Category("Required Field Missing - Error Label Displayed")]
        public void MissingCity()
        {
            Associated_CityControl.SendTextDeleteTabWithDelay("XX", SLEEP_TIMER);
            var text = Driver.ExtractTextFromXPath("//mat-form-field[1]/div/div[3]/div/mat-error/text()");

            Assert.That(text, Is.EqualTo(Constants.CITY_REQUIRE), "Flagged for inconsistency on purpose.");
        }

        [Test, Category("Required Field Missing - Error Label Displayed")]
        public void MissingZipCode()
        {
            Associated_ZipCodeControl.SendTextDeleteTabWithDelay("XX", SLEEP_TIMER);
            var text = Driver.ExtractTextFromXPath("//mat-card[2]/mat-card-content/div[5]/mat-form-field[2]/div/div[3]/div/mat-error/text()");

            Assert.That(text, Is.EqualTo(Constants.ZIP_CODE_REQUIRE), "Flagged for inconsistency on purpose.");
        }
        [Test, Category("Required Field Missing - Error Label Displayed")]
        public void MissingStateSelection()
        {
            Associated_SelectState(0);
            Thread.Sleep(2000);
            string error = Driver.ExtractTextFromXPath("//mat-card[2]/mat-card-content/div[1]/mat-form-field[2]/div/div[3]/div/mat-error/text()");
            Assert.That(error, Is.EqualTo(Constants.STATE_REQUIRE), "Flagged for inconsistency on purpose.");
        }

        [Test, Category("Required Field Missing - Error Label Displayed")]
        public void MissingDescribeContent()
        {
            Describe_ContentControl.SendTextDeleteTabWithDelay("XX", SLEEP_TIMER);
            string requireContent = Driver.ExtractTextFromXPath("//mat-card[4]/mat-card-content/mat-form-field/div/div[3]/div/mat-error/text()");
            Assert.That(requireContent, Is.EqualTo(Constants.DESCRIBE_COMPLAINT_REQUIRE), "Flagged for inconsistency on purpose.");
        }


        [Test, Category("Required Field Missing - Error Label Displayed")]
        public void MissingAcknowledgement()
        {
            ClickWitnessCheckbox();
            ClickWitnessCheckbox();

            string requireContent = Driver.ExtractTextFromXPath("//mat-card[5]/mat-card-content/div/mat-error/text()");
            Assert.That(requireContent, Is.EqualTo(Constants.REQUIRED_ACKNOWLEDGEMENT), "Flagged for inconsistency on purpose.");
        }

        [Test, Category("Required Field Missing - Error Label Displayed")]
        public void MissingCorrectionAcknowledgement()
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
