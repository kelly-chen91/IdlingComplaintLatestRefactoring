using IdlingComplaints.Models.ComplaintForm;
using IdlingComplaints.Tests.ComplaintForm.Functionality;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V112.Database;
using SeleniumUtilities.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace IdlingComplaints.Tests.ComplaintForm
{
    internal class Test20_BusinessValidation : FillComplaintForm_Base
    {
        [SetUp]
        public void SetUp()
        {
            base.ComplaintFormModelSetUp(false);

        }

        [TearDown]
        public void TearDown()
        {
            if (SLEEP_TIMER > 0) { Thread.Sleep(SLEEP_TIMER); }
            base.ComplaintFormModelTearDown();
        }

        [Test]
        [Category("Required Field Provided Invalid Input - Error Label Displayed")]

        public void FailedFormSubmit_InFrontOf_NoSchool_TimeShorterThan3Minutes()
        {
            /*QUALIFYING CRITERIA*/
            ClickNo();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false, false, SLEEP_TIMER);

            /*OCCURRENCE*/
            //Occurrence_FromControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2023, 4, 20, 00, true), SLEEP_TIMER);
            //Occurrence_ToControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2023, 4, 20, 01, true), SLEEP_TIMER);

            Occurrence_FromControl.SendKeysWithDelay(
                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.AddMinutes(-1).Minute, DateTime.Now.Second), SLEEP_TIMER); // Current Time (1 minutes ago)

            Occurrence_ToControl.SendKeysWithDelay(
                                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second), SLEEP_TIMER); // Current Time


            Fill_OccurrenceAddress(2, 3, false, SLEEP_TIMER);

            Occurrence_SelectVehicleType(2);
            Occurrence_LicensePlateControl.SendKeysWithDelay(StringUtilities.GenerateRandomString(7), SLEEP_TIMER);
            Occurrence_SelectLicenseState(1);
            Occurrence_PastOffenseControl.SendKeysWithDelay("Test", SLEEP_TIMER);
            Occurrence_SecondPastOffenseControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            Fill_InFrontOfSchool(false, SLEEP_TIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ComplaintInfo_ClickNext();

            var invalidTime = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 10);
            Assert.IsNotNull(invalidTime);

            string error = invalidTime.Text.Trim();
            Console.WriteLine(error);

            bool isSatisfiedErrorList = error.Contains(ERROR_BASE) && error.Contains(ERROR_SHORTER_THAN_3_MINUTES); 
            Assert.True(isSatisfiedErrorList, "Flagged inconsistency on purpose.");
        }


        [Test]
        [Category("Required Field Provided Invalid Input - Error Label Displayed")]

        public void FailedFormSubmit_InFrontOf_NoSchool_TimeShorterThan3Minutes_InvalidOccurrenceAddr()
        {
            /*QUALIFYING CRITERIA*/
            ClickNo();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false, false, SLEEP_TIMER);

            /*OCCURRENCE*/
            //Occurrence_FromControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2023, 4, 20, 00, true), SLEEP_TIMER);
            //Occurrence_ToControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2023, 4, 20, 01, true), SLEEP_TIMER);
            Occurrence_FromControl.SendKeysWithDelay(
                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.AddMinutes(-1).Minute, DateTime.Now.Second), SLEEP_TIMER); // Current Time (1 minutes ago)

            Occurrence_ToControl.SendKeysWithDelay(
                                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second), SLEEP_TIMER); // Current Time

            Fill_OccurrenceAddress(2, 3, true, SLEEP_TIMER);

            Occurrence_SelectVehicleType(2);
            Occurrence_LicensePlateControl.SendKeysWithDelay(StringUtilities.GenerateRandomString(7), SLEEP_TIMER);
            Occurrence_SelectLicenseState(1);
            Occurrence_PastOffenseControl.SendKeysWithDelay("Test", SLEEP_TIMER);
            Occurrence_SecondPastOffenseControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            Fill_InFrontOfSchool(false, SLEEP_TIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ComplaintInfo_ClickNext();

            var invalidTime = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 10);
            Assert.IsNotNull(invalidTime);

            string error = invalidTime.Text.Trim();
            Console.WriteLine(error);

            bool isSatisfiedErrorList = error.Contains(ERROR_BASE) && error.Contains(ERROR_SHORTER_THAN_3_MINUTES) && error.Contains(ERROR_INVALID_OCCURRENCE_ADDRESS);
            Assert.True(isSatisfiedErrorList, "Flagged inconsistency on purpose.");

           
        }


        [Test]
        [Category("Required Field Provided Invalid Input - Error Label Displayed")]

        public void FailedFormSubmit_InFrontOf_NoSchool_TimeShorterThan3Minutes_InvalidAssociatedAddr()
        {
            /*QUALIFYING CRITERIA*/
            ClickNo();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false, true, SLEEP_TIMER);

            /*OCCURRENCE*/
            //Occurrence_FromControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2023, 4, 20, 00, true), SLEEP_TIMER);
            //Occurrence_ToControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2023, 4, 20, 01, true), SLEEP_TIMER);
            Occurrence_FromControl.SendKeysWithDelay(
                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.AddMinutes(-1).Minute, DateTime.Now.Second), SLEEP_TIMER); // Current Time (3 minutes ago)

            Occurrence_ToControl.SendKeysWithDelay(
                                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second), SLEEP_TIMER); // Current Time

            Fill_OccurrenceAddress(2, 3, true, SLEEP_TIMER);

            Occurrence_SelectVehicleType(2);
            Occurrence_LicensePlateControl.SendKeysWithDelay(StringUtilities.GenerateRandomString(7), SLEEP_TIMER);
            Occurrence_SelectLicenseState(1);
            Occurrence_PastOffenseControl.SendKeysWithDelay("Test", SLEEP_TIMER);
            Occurrence_SecondPastOffenseControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            Fill_InFrontOfSchool(false, SLEEP_TIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ComplaintInfo_ClickNext();

            var invalidTime = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 10);
            Assert.IsNotNull(invalidTime);

            string error = invalidTime.Text.Trim();
            Console.WriteLine(error);

            bool isSatisfiedErrorList = error.Contains(ERROR_BASE) && error.Contains(ERROR_SHORTER_THAN_3_MINUTES) && error.Contains(ERROR_INVALID_ASSOCIATED_ADDRESS);
            Assert.True(isSatisfiedErrorList, "Flagged inconsistency on purpose.");

            
        }

        [Test]
        [Category("Required Field Provided Invalid Input - Error Label Displayed")]

        public void FailedFormSubmit_InFrontOf_NoSchool_TimeShorterThan3Minutes_InvalidOccurrenceAndAssociatedAddr()
        {
            /*QUALIFYING CRITERIA*/
            ClickNo();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false, true, SLEEP_TIMER);

            /*OCCURRENCE*/
            //Occurrence_FromControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2023, 4, 20, 00, true), SLEEP_TIMER);
            //Occurrence_ToControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2023, 4, 20, 01, true), SLEEP_TIMER);
            Occurrence_FromControl.SendKeysWithDelay(
                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.AddMinutes(-1).Minute, DateTime.Now.Second), SLEEP_TIMER); // Current Time (1 minutes ago)

            Occurrence_ToControl.SendKeysWithDelay(
                                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second), SLEEP_TIMER); // Current Time


            Fill_OccurrenceAddress(2, 3, true, SLEEP_TIMER);

            Occurrence_SelectVehicleType(2);
            Occurrence_LicensePlateControl.SendKeysWithDelay(StringUtilities.GenerateRandomString(7), SLEEP_TIMER);
            Occurrence_SelectLicenseState(1);
            Occurrence_PastOffenseControl.SendKeysWithDelay("Test", SLEEP_TIMER);
            Occurrence_SecondPastOffenseControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            Fill_InFrontOfSchool(false, SLEEP_TIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ComplaintInfo_ClickNext();

            var invalidTime = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 10);
            Assert.IsNotNull(invalidTime);

            string error = invalidTime.Text.Trim();
            Console.WriteLine(error);

            bool isSatisfiedErrorList = error.Contains(ERROR_BASE) && error.Contains(ERROR_SHORTER_THAN_3_MINUTES) && error.Contains(ERROR_INVALID_OCCURRENCE_ADDRESS)
                && error.Contains(ERROR_INVALID_ASSOCIATED_ADDRESS);
            Assert.True(isSatisfiedErrorList, "Flagged inconsistency on purpose.");


        }

        [Test]
        [Category("Required Field Provided Invalid Input - Error Label Displayed")]

        public void FailedFormSubmit_InFrontOf_NoSchool_TimeInFutureAndShorterThan3Minutes()
        {
            /*QUALIFYING CRITERIA*/
            ClickNo();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false, false, SLEEP_TIMER);

            int year = DateTime.Now.Year + 1;

            /*OCCURRENCE*/
            //Occurrence_FromControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, year, 4, 20, 00, true), SLEEP_TIMER);
            //Occurrence_ToControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, year, 4, 20, 01, true), SLEEP_TIMER);
            Occurrence_FromControl.SendKeysWithDelay(
                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.AddYears(1).Year, DateTime.Now.Hour, DateTime.Now.AddMinutes(-1).Minute, DateTime.Now.Second), SLEEP_TIMER); //Time in a year (1 minutes ago)

            Occurrence_ToControl.SendKeysWithDelay(
                                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.AddYears(1).Year, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second), SLEEP_TIMER); // Current Time

            Fill_OccurrenceAddress(2, 3, false, SLEEP_TIMER);

            Occurrence_SelectVehicleType(2);
            Occurrence_LicensePlateControl.SendKeysWithDelay(StringUtilities.GenerateRandomString(7), SLEEP_TIMER);
            Occurrence_SelectLicenseState(1);
            Occurrence_PastOffenseControl.SendKeysWithDelay("Test", SLEEP_TIMER);
            Occurrence_SecondPastOffenseControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            Fill_InFrontOfSchool(false, SLEEP_TIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ComplaintInfo_ClickNext();

            var invalidTime = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 10);
            Assert.IsNotNull(invalidTime);

            string error = invalidTime.Text.Trim();
            Console.WriteLine(error);

            bool isSatisfiedErrorList = error.Contains(ERROR_BASE) && error.Contains(ERROR_SHORTER_THAN_3_MINUTES) && error.Contains(ERROR_TO_AND_FROM_IN_FUTURE);
            Assert.True(isSatisfiedErrorList, "Flagged inconsistency on purpose.");

        }

        [Test]
        [Category("Required Field Provided Invalid Input - Error Label Displayed")]

        public void FailedFormSubmit_InFrontOf_NoSchool_TimeInFutureAndShorterThan3Minutes_InvalidOccurrenceAddr()
        {
            /*QUALIFYING CRITERIA*/
            ClickNo();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false, false, SLEEP_TIMER);

            int year = DateTime.Now.Year + 1;

            /*OCCURRENCE*/
            //Occurrence_FromControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, year, 4, 20, 00, true), SLEEP_TIMER);
            //Occurrence_ToControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, year, 4, 20, 01, true), SLEEP_TIMER);


            Occurrence_FromControl.SendKeysWithDelay(
                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.AddYears(1).Year, DateTime.Now.Hour, DateTime.Now.AddMinutes(-1).Minute, DateTime.Now.Second), SLEEP_TIMER); //Time in a year (1 minutes ago)

            Occurrence_ToControl.SendKeysWithDelay(
                                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.AddYears(1).Year, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second), SLEEP_TIMER); // Current Time

            Fill_OccurrenceAddress(2, 3, true, SLEEP_TIMER);

            Occurrence_SelectVehicleType(2);
            Occurrence_LicensePlateControl.SendKeysWithDelay(StringUtilities.GenerateRandomString(7), SLEEP_TIMER);
            Occurrence_SelectLicenseState(1);
            Occurrence_PastOffenseControl.SendKeysWithDelay("Test", SLEEP_TIMER);
            Occurrence_SecondPastOffenseControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            Fill_InFrontOfSchool(false, SLEEP_TIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ComplaintInfo_ClickNext();

            var invalidTime = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 10);
            Assert.IsNotNull(invalidTime);

            string error = invalidTime.Text.Trim();
            Console.WriteLine(error);

            bool isSatisfiedErrorList = error.Contains(ERROR_BASE) && error.Contains(ERROR_SHORTER_THAN_3_MINUTES) && error.Contains(ERROR_TO_AND_FROM_IN_FUTURE)
                && error.Contains(ERROR_INVALID_OCCURRENCE_ADDRESS);
            Assert.True(isSatisfiedErrorList, "Flagged inconsistency on purpose.");

        }

        [Test]
        [Category("Required Field Provided Invalid Input - Error Label Displayed")]

        public void FailedFormSubmit_InFrontOf_NoSchool_TimeInFutureAndShorterThan3Minutes_InvalidAssociatedAddr()
        {
            /*QUALIFYING CRITERIA*/
            ClickNo();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false, true, SLEEP_TIMER);

            int year = DateTime.Now.Year + 1;

            /*OCCURRENCE*/
            //Occurrence_FromControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, year, 4, 20, 00, true), SLEEP_TIMER);
            //Occurrence_ToControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, year, 4, 20, 01, true), SLEEP_TIMER);

            Occurrence_FromControl.SendKeysWithDelay(
                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.AddYears(1).Year, DateTime.Now.Hour, DateTime.Now.AddMinutes(-1).Minute, DateTime.Now.Second), SLEEP_TIMER); //Time in a year (1 minutes ago)

            Occurrence_ToControl.SendKeysWithDelay(
                                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.AddYears(1).Year, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second), SLEEP_TIMER); // Current Time


            Fill_OccurrenceAddress(2, 3, false, SLEEP_TIMER);

            Occurrence_SelectVehicleType(2);
            Occurrence_LicensePlateControl.SendKeysWithDelay(StringUtilities.GenerateRandomString(7), SLEEP_TIMER);
            Occurrence_SelectLicenseState(1);
            Occurrence_PastOffenseControl.SendKeysWithDelay("Test", SLEEP_TIMER);
            Occurrence_SecondPastOffenseControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            Fill_InFrontOfSchool(false, SLEEP_TIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ComplaintInfo_ClickNext();

            var invalidTime = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 10);
            Assert.IsNotNull(invalidTime);

            string error = invalidTime.Text.Trim();
            Console.WriteLine(error);

            bool isSatisfiedErrorList = error.Contains(ERROR_BASE) && error.Contains(ERROR_SHORTER_THAN_3_MINUTES) && error.Contains(ERROR_TO_AND_FROM_IN_FUTURE)
                && error.Contains(ERROR_INVALID_ASSOCIATED_ADDRESS);
            Assert.True(isSatisfiedErrorList, "Flagged inconsistency on purpose.");

        }

        [Test]
        [Category("Required Field Provided Invalid Input - Error Label Displayed")]

        public void FailedFormSubmit_InFrontOf_NoSchool_TimeInFutureAndShorterThan3Minutes_InvalidOccurrenceAndAssociatedAddr()
        {
            /*QUALIFYING CRITERIA*/
            ClickNo();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false, true, SLEEP_TIMER);
            int year = DateTime.Now.Year + 1;
            /*OCCURRENCE*/
            //Occurrence_FromControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, year, 4, 20, 00, true), SLEEP_TIMER);
            //Occurrence_ToControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, year, 4, 20, 01, true), SLEEP_TIMER);

            Occurrence_FromControl.SendKeysWithDelay(
                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.AddYears(1).Year, DateTime.Now.Hour, DateTime.Now.AddMinutes(-1).Minute, DateTime.Now.Second), SLEEP_TIMER); //Time in a year (1 minutes ago)

            Occurrence_ToControl.SendKeysWithDelay(
                                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.AddYears(1).Year, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second), SLEEP_TIMER); // Current Time

            Fill_OccurrenceAddress(2, 3, true, SLEEP_TIMER);

            Occurrence_SelectVehicleType(2);
            Occurrence_LicensePlateControl.SendKeysWithDelay(StringUtilities.GenerateRandomString(7), SLEEP_TIMER);
            Occurrence_SelectLicenseState(1);
            Occurrence_PastOffenseControl.SendKeysWithDelay("Test", SLEEP_TIMER);
            Occurrence_SecondPastOffenseControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            Fill_InFrontOfSchool(false, SLEEP_TIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ComplaintInfo_ClickNext();

            var invalidTime = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 10);
            Assert.IsNotNull(invalidTime);

            string error = invalidTime.Text.Trim();
            Console.WriteLine(error);

            bool isSatisfiedErrorList = error.Contains(ERROR_BASE) && error.Contains(ERROR_SHORTER_THAN_3_MINUTES) && error.Contains(ERROR_TO_AND_FROM_IN_FUTURE)
                && error.Contains(ERROR_INVALID_ASSOCIATED_ADDRESS) && error.Contains(ERROR_INVALID_OCCURRENCE_ADDRESS);
            Assert.True(isSatisfiedErrorList, "Flagged inconsistency on purpose.");

        }

        [Test]
        [Category("Required Field Provided Invalid Input - Error Label Displayed")]

        public void FailedFormSubmit_InFrontOf_NoSchool_TimeInFuture()
        {
            /*QUALIFYING CRITERIA*/
            ClickNo();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false, false, SLEEP_TIMER);

            int year = DateTime.Now.Year + 1;

            /*OCCURRENCE*/
            //Occurrence_FromControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, year, 4, 20, 00, true), SLEEP_TIMER);
            //Occurrence_ToControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, year, 4, 23, 01, true), SLEEP_TIMER);

            Occurrence_FromControl.SendKeysWithDelay(
                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.AddYears(1).Year, DateTime.Now.Hour, DateTime.Now.AddMinutes(-3).Minute, DateTime.Now.Second), SLEEP_TIMER); //Time in a year (3 minutes ago)

            Occurrence_ToControl.SendKeysWithDelay(
                                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.AddYears(1).Year, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second), SLEEP_TIMER); // Current Time

            Fill_OccurrenceAddress(2, 3, false, SLEEP_TIMER);

            Occurrence_SelectVehicleType(2);
            Occurrence_LicensePlateControl.SendKeysWithDelay(StringUtilities.GenerateRandomString(7), SLEEP_TIMER);
            Occurrence_SelectLicenseState(1);
            Occurrence_PastOffenseControl.SendKeysWithDelay("Test", SLEEP_TIMER);
            Occurrence_SecondPastOffenseControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            Fill_InFrontOfSchool(false, SLEEP_TIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ComplaintInfo_ClickNext();

            var invalidTime = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 10);
            Assert.IsNotNull(invalidTime);

            string error = invalidTime.Text.Trim();
            Console.WriteLine(error);

            bool isSatisfiedErrorList = error.Contains(ERROR_BASE) && error.Contains(ERROR_TO_AND_FROM_IN_FUTURE);
            Assert.True(isSatisfiedErrorList, "Flagged inconsistency on purpose.");
        }

        [Test]
        [Category("Required Field Provided Invalid Input - Error Label Displayed")]

        public void FailedFormSubmit_InFrontOf_NoSchool_TimeInFuture_InvalidOccurrenceAddr()
        {
            /*QUALIFYING CRITERIA*/
            ClickNo();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false, false, SLEEP_TIMER);

            int year = DateTime.Now.Year + 1;

            /*OCCURRENCE*/
            //Occurrence_FromControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, year, 4, 20, 00, true), SLEEP_TIMER);
            //Occurrence_ToControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, year, 4, 23, 01, true), SLEEP_TIMER);
            Occurrence_FromControl.SendKeysWithDelay(
                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.AddYears(1).Year, DateTime.Now.Hour, DateTime.Now.AddMinutes(-3).Minute, DateTime.Now.Second), SLEEP_TIMER); //Time in a year (3 minutes ago)

            Occurrence_ToControl.SendKeysWithDelay(
                                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.AddYears(1).Year, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second), SLEEP_TIMER); // Current Time

            Fill_OccurrenceAddress(2, 3, true, SLEEP_TIMER);

            Occurrence_SelectVehicleType(2);
            Occurrence_LicensePlateControl.SendKeysWithDelay(StringUtilities.GenerateRandomString(7), SLEEP_TIMER);
            Occurrence_SelectLicenseState(1);
            Occurrence_PastOffenseControl.SendKeysWithDelay("Test", SLEEP_TIMER);
            Occurrence_SecondPastOffenseControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            Fill_InFrontOfSchool(false, SLEEP_TIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ComplaintInfo_ClickNext();

            var invalidTime = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 10);
            Assert.IsNotNull(invalidTime);

            string error = invalidTime.Text.Trim();
            Console.WriteLine(error);

            bool isSatisfiedErrorList = error.Contains(ERROR_BASE) && error.Contains(ERROR_TO_AND_FROM_IN_FUTURE)
                && error.Contains(ERROR_INVALID_OCCURRENCE_ADDRESS);
            Assert.True(isSatisfiedErrorList, "Flagged inconsistency on purpose.");

        }

        [Test]
        [Category("Required Field Provided Invalid Input - Error Label Displayed")]

        public void FailedFormSubmit_InFrontOf_NoSchool_TimeInFuture_InvalidAssociatedAddr()
        {
            /*QUALIFYING CRITERIA*/
            ClickNo();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false, true, SLEEP_TIMER);

            int year = DateTime.Now.Year + 1;

            /*OCCURRENCE*/
            //Occurrence_FromControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, year, 4, 20, 00, true), SLEEP_TIMER);
            //Occurrence_ToControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, year, 4, 23, 01, true), SLEEP_TIMER);

            Occurrence_FromControl.SendKeysWithDelay(
                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.AddYears(1).Year, DateTime.Now.Hour, DateTime.Now.AddMinutes(-3).Minute, DateTime.Now.Second), SLEEP_TIMER); //Time in a year (3 minutes ago)

            Occurrence_ToControl.SendKeysWithDelay(
                                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.AddYears(1).Year, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second), SLEEP_TIMER); // Current Time

            Fill_OccurrenceAddress(2, 3, false, SLEEP_TIMER);

            Occurrence_SelectVehicleType(2);
            Occurrence_LicensePlateControl.SendKeysWithDelay(StringUtilities.GenerateRandomString(7), SLEEP_TIMER);
            Occurrence_SelectLicenseState(1);
            Occurrence_PastOffenseControl.SendKeysWithDelay("Test", SLEEP_TIMER);
            Occurrence_SecondPastOffenseControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            Fill_InFrontOfSchool(false, SLEEP_TIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ComplaintInfo_ClickNext();

            var invalidTime = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 10);
            Assert.IsNotNull(invalidTime);

            string error = invalidTime.Text.Trim();
            Console.WriteLine(error);

            bool isSatisfiedErrorList = error.Contains(ERROR_BASE) && error.Contains(ERROR_TO_AND_FROM_IN_FUTURE)
                && error.Contains(ERROR_INVALID_ASSOCIATED_ADDRESS);
            Assert.True(isSatisfiedErrorList, "Flagged inconsistency on purpose.");

        }

        [Test]
        [Category("Required Field Provided Invalid Input - Error Label Displayed")]

        public void FailedFormSubmit_InFrontOf_NoSchool_TimeInFuture_InvalidOccurrenceAndAssociatedAddr()
        {
            /*QUALIFYING CRITERIA*/
            ClickNo();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false, true, SLEEP_TIMER);

            int year = DateTime.Now.Year + 1;

            /*OCCURRENCE*/
            //Occurrence_FromControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, year, 4, 20, 00, true), SLEEP_TIMER);
            //Occurrence_ToControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, year, 4, 23, 01, true), SLEEP_TIMER);

            Occurrence_FromControl.SendKeysWithDelay(
                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.AddYears(1).Year, DateTime.Now.Hour, DateTime.Now.AddMinutes(-3).Minute, DateTime.Now.Second), SLEEP_TIMER); //Time in a year (3 minutes ago)

            Occurrence_ToControl.SendKeysWithDelay(
                                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.AddYears(1).Year, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second), SLEEP_TIMER); // Current Time

            Fill_OccurrenceAddress(2, 3, true, SLEEP_TIMER);

            Occurrence_SelectVehicleType(2);
            Occurrence_LicensePlateControl.SendKeysWithDelay(StringUtilities.GenerateRandomString(7), SLEEP_TIMER);
            Occurrence_SelectLicenseState(1);
            Occurrence_PastOffenseControl.SendKeysWithDelay("Test", SLEEP_TIMER);
            Occurrence_SecondPastOffenseControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            Fill_InFrontOfSchool(false, SLEEP_TIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ComplaintInfo_ClickNext();

            var invalidTime = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 10);
            Assert.IsNotNull(invalidTime);

            string error = invalidTime.Text.Trim();
            Console.WriteLine(error);

            bool isSatisfiedErrorList = error.Contains(ERROR_BASE) && error.Contains(ERROR_TO_AND_FROM_IN_FUTURE)
                && error.Contains(ERROR_INVALID_ASSOCIATED_ADDRESS) && error.Contains(ERROR_INVALID_OCCURRENCE_ADDRESS);
            Assert.True(isSatisfiedErrorList, "Flagged inconsistency on purpose.");

                    
        }

        [Test]
        [Category("Required Field Provided Invalid Input - Error Label Displayed")]

        public void FailedFormSubmit_InFrontOf_NoSchool_FromTimeMoreThanToTime()
        {
            /*QUALIFYING CRITERIA*/
            ClickNo();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false, false, SLEEP_TIMER);


            /*OCCURRENCE*/
            //Occurrence_FromControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2023, 4, 23, 00, true), SLEEP_TIMER);
            //Occurrence_ToControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2023, 4, 20, 00, true), SLEEP_TIMER);

            Occurrence_FromControl.SendKeysWithDelay(
                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.AddDays(-1).Day, DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.AddMinutes(3).Minute, DateTime.Now.Second), SLEEP_TIMER); //Current Time (3 minutes over)

            Occurrence_ToControl.SendKeysWithDelay(
                                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.AddDays(-1).Day, DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second), SLEEP_TIMER); // Current Time

            Fill_OccurrenceAddress(2, 3, false, SLEEP_TIMER);

            Occurrence_SelectVehicleType(2);
            Occurrence_LicensePlateControl.SendKeysWithDelay(StringUtilities.GenerateRandomString(7), SLEEP_TIMER);
            Occurrence_SelectLicenseState(1);
            Occurrence_PastOffenseControl.SendKeysWithDelay("Test", SLEEP_TIMER);
            Occurrence_SecondPastOffenseControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            Fill_InFrontOfSchool(false, SLEEP_TIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ComplaintInfo_ClickNext();

            var invalidTime = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 10);
            Assert.IsNotNull(invalidTime);

            string error = invalidTime.Text.Trim();
            Console.WriteLine(error);

            bool isSatisfiedErrorList = error.Contains(ERROR_BASE) && error.Contains(ERROR_TO_IN_FUTURE_THAN_FROM) && error.Contains(ERROR_SHORTER_THAN_3_MINUTES);
            Assert.True(isSatisfiedErrorList, "Flagged inconsistency on purpose.");

        }

        [Test]
        [Category("Required Field Provided Invalid Input - Error Label Displayed")]

        public void FailedFormSubmit_InFrontOf_NoSchool_FromTimeMoreThanToTime_InvalidOccurrenceAddr()
        {
            /*QUALIFYING CRITERIA*/
            ClickNo();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false, false, SLEEP_TIMER);

            /*OCCURRENCE*/
            //Occurrence_FromControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2023, 4, 23, 00, true), SLEEP_TIMER);
            //Occurrence_ToControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2023, 4, 20, 00, true), SLEEP_TIMER);

            Occurrence_FromControl.SendKeysWithDelay(
                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.AddDays(-1).Day, DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.AddMinutes(3).Minute, DateTime.Now.Second), SLEEP_TIMER); //Current Time (3 minutes over)

            Occurrence_ToControl.SendKeysWithDelay(
                                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.AddDays(-1).Day, DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second), SLEEP_TIMER); // Current Time

            Fill_OccurrenceAddress(2, 3, true, SLEEP_TIMER);

            Occurrence_SelectVehicleType(2);
            Occurrence_LicensePlateControl.SendKeysWithDelay(StringUtilities.GenerateRandomString(7), SLEEP_TIMER);
            Occurrence_SelectLicenseState(1);
            Occurrence_PastOffenseControl.SendKeysWithDelay("Test", SLEEP_TIMER);
            Occurrence_SecondPastOffenseControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            Fill_InFrontOfSchool(false, SLEEP_TIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ComplaintInfo_ClickNext();

            var invalidTime = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 10);
            Assert.IsNotNull(invalidTime);

            string error = invalidTime.Text.Trim();
            Console.WriteLine(error);

            bool isSatisfiedErrorList = error.Contains(ERROR_BASE) && error.Contains(ERROR_TO_IN_FUTURE_THAN_FROM) && error.Contains(ERROR_SHORTER_THAN_3_MINUTES)
                && error.Contains(ERROR_INVALID_OCCURRENCE_ADDRESS);
            Assert.True(isSatisfiedErrorList, "Flagged inconsistency on purpose.");

        }


        [Test]
        [Category("Required Field Provided Invalid Input - Error Label Displayed")]

        public void FailedFormSubmit_InFrontOf_NoSchool_FromTimeMoreThanToTime_InvalidAssociatedAddress()
        {
            /*QUALIFYING CRITERIA*/
            ClickNo();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false, true, SLEEP_TIMER);

            /*OCCURRENCE*/
            //Occurrence_FromControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2023, 4, 23, 00, true), SLEEP_TIMER);
            //Occurrence_ToControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2023, 4, 20, 00, true), SLEEP_TIMER);

            Occurrence_FromControl.SendKeysWithDelay(
                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.AddDays(-1).Day, DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.AddMinutes(3).Minute, DateTime.Now.Second), SLEEP_TIMER); //Current Time (3 minutes over)

            Occurrence_ToControl.SendKeysWithDelay(
                                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.AddDays(-1).Day, DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second), SLEEP_TIMER); // Current Time

            Fill_OccurrenceAddress(2, 3, false, SLEEP_TIMER);

            Occurrence_SelectVehicleType(2);
            Occurrence_LicensePlateControl.SendKeysWithDelay(StringUtilities.GenerateRandomString(7), SLEEP_TIMER);
            Occurrence_SelectLicenseState(1);
            Occurrence_PastOffenseControl.SendKeysWithDelay("Test", SLEEP_TIMER);
            Occurrence_SecondPastOffenseControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            Fill_InFrontOfSchool(false, SLEEP_TIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ComplaintInfo_ClickNext();

            var invalidTime = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 10);
            Assert.IsNotNull(invalidTime);

            string error = invalidTime.Text.Trim();
            Console.WriteLine(error);

            bool isSatisfiedErrorList = error.Contains(ERROR_BASE) && error.Contains(ERROR_TO_IN_FUTURE_THAN_FROM) && error.Contains(ERROR_SHORTER_THAN_3_MINUTES)
                && error.Contains(ERROR_INVALID_ASSOCIATED_ADDRESS);
            Assert.True(isSatisfiedErrorList, "Flagged inconsistency on purpose.");
        }


        [Test]
        [Category("Required Field Provided Invalid Input - Error Label Displayed")]

        public void FailedFormSubmit_InFrontOf_NoSchool_FromTimeMoreThanToTime_InvalidOccurrenceAndAssociatedAddr()
        {
            /*QUALIFYING CRITERIA*/
            ClickNo();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false, true, SLEEP_TIMER);

            /*OCCURRENCE*/
            //Occurrence_FromControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2023, 4, 23, 00, true), SLEEP_TIMER);
            //Occurrence_ToControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2023, 4, 20, 00, true), SLEEP_TIMER);

            Occurrence_FromControl.SendKeysWithDelay(
                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.AddDays(-1).Day, DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.AddMinutes(3).Minute, DateTime.Now.Second), SLEEP_TIMER); //Current Time (3 minutes over)

            Occurrence_ToControl.SendKeysWithDelay(
                                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.AddDays(-1).Day, DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second), SLEEP_TIMER); // Current Time

            Fill_OccurrenceAddress(2, 3, true, SLEEP_TIMER);

            Occurrence_SelectVehicleType(2);
            Occurrence_LicensePlateControl.SendKeysWithDelay(StringUtilities.GenerateRandomString(7), SLEEP_TIMER);
            Occurrence_SelectLicenseState(1);
            Occurrence_PastOffenseControl.SendKeysWithDelay("Test", SLEEP_TIMER);
            Occurrence_SecondPastOffenseControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            Fill_InFrontOfSchool(false, SLEEP_TIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ComplaintInfo_ClickNext();

            var invalidTime = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 10);
            Assert.IsNotNull(invalidTime);

            string error = invalidTime.Text.Trim();
            Console.WriteLine(error);

            bool isSatisfiedErrorList = error.Contains(ERROR_BASE) && error.Contains(ERROR_TO_IN_FUTURE_THAN_FROM) && error.Contains(ERROR_SHORTER_THAN_3_MINUTES)
                && error.Contains(ERROR_INVALID_ASSOCIATED_ADDRESS) && error.Contains(ERROR_INVALID_OCCURRENCE_ADDRESS);
            Assert.True(isSatisfiedErrorList, "Flagged inconsistency on purpose.");
        }

        [Test]
        [Category("Required Field Provided Invalid Input - Error Label Displayed")]
        public void FailedFormSubmit_InFrontOf_NoSchool_FromTimeMoreThanToCurrentTime()
        {
            /*QUALIFYING CRITERIA*/
            ClickNo();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false, false, SLEEP_TIMER);


            /*OCCURRENCE*/
            //Occurrence_FromControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2023, 4, 23, 00, true), SLEEP_TIMER);
            //Occurrence_ToControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2023, 4, 20, 00, true), SLEEP_TIMER);

            Occurrence_FromControl.SendKeysWithDelay(
                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.AddMinutes(3).Minute, DateTime.Now.Second), SLEEP_TIMER); //Current Time (3 minutes over)

            Occurrence_ToControl.SendKeysWithDelay(
                                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second), SLEEP_TIMER); // Current Time

            Fill_OccurrenceAddress(2, 3, false, SLEEP_TIMER);

            Occurrence_SelectVehicleType(2);
            Occurrence_LicensePlateControl.SendKeysWithDelay(StringUtilities.GenerateRandomString(7), SLEEP_TIMER);
            Occurrence_SelectLicenseState(1);
            Occurrence_PastOffenseControl.SendKeysWithDelay("Test", SLEEP_TIMER);
            Occurrence_SecondPastOffenseControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            Fill_InFrontOfSchool(false, SLEEP_TIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ComplaintInfo_ClickNext();

            var invalidTime = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 10);
            Assert.IsNotNull(invalidTime);

            string error = invalidTime.Text.Trim();
            Console.WriteLine(error);

            bool isSatisfiedErrorList = error.Contains(ERROR_BASE) && error.Contains(ERROR_TO_IN_FUTURE_THAN_FROM)
                && error.Contains(ERROR_TO_AND_FROM_IN_FUTURE) && error.Contains(ERROR_SHORTER_THAN_3_MINUTES);
            Assert.True(isSatisfiedErrorList, "Flagged inconsistency on purpose.");

        }

        [Test]
        [Category("Required Field Provided Invalid Input - Error Label Displayed")]
        public void FailedFormSubmit_InFrontOf_NoSchool_FromTimeMoreThanToCurrentTime_InvalidOccurrenceAddr()
        {
            /*QUALIFYING CRITERIA*/
            ClickNo();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false, false, SLEEP_TIMER);


            /*OCCURRENCE*/
            //Occurrence_FromControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2023, 4, 23, 00, true), SLEEP_TIMER);
            //Occurrence_ToControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2023, 4, 20, 00, true), SLEEP_TIMER);

            Occurrence_FromControl.SendKeysWithDelay(
                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.AddMinutes(3).Minute, DateTime.Now.Second), SLEEP_TIMER); //Current Time (3 minutes over)

            Occurrence_ToControl.SendKeysWithDelay(
                                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second), SLEEP_TIMER); // Current Time

            Fill_OccurrenceAddress(2, 3, true, SLEEP_TIMER);

            Occurrence_SelectVehicleType(2);
            Occurrence_LicensePlateControl.SendKeysWithDelay(StringUtilities.GenerateRandomString(7), SLEEP_TIMER);
            Occurrence_SelectLicenseState(1);
            Occurrence_PastOffenseControl.SendKeysWithDelay("Test", SLEEP_TIMER);
            Occurrence_SecondPastOffenseControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            Fill_InFrontOfSchool(false, SLEEP_TIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ComplaintInfo_ClickNext();

            var invalidTime = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 10);
            Assert.IsNotNull(invalidTime);

            string error = invalidTime.Text.Trim();
            Console.WriteLine(error);

            bool isSatisfiedErrorList = error.Contains(ERROR_BASE) && error.Contains(ERROR_TO_IN_FUTURE_THAN_FROM)
                && error.Contains(ERROR_TO_AND_FROM_IN_FUTURE) && error.Contains(ERROR_SHORTER_THAN_3_MINUTES) && error.Contains(ERROR_INVALID_OCCURRENCE_ADDRESS);
            Assert.True(isSatisfiedErrorList, "Flagged inconsistency on purpose.");

        }

        [Test]
        [Category("Required Field Provided Invalid Input - Error Label Displayed")]
        public void FailedFormSubmit_InFrontOf_NoSchool_FromTimeMoreThanToCurrentTime_InvalidAssociatedAddress()
        {
            /*QUALIFYING CRITERIA*/
            ClickNo();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false, true, SLEEP_TIMER);


            /*OCCURRENCE*/
            //Occurrence_FromControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2023, 4, 23, 00, true), SLEEP_TIMER);
            //Occurrence_ToControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2023, 4, 20, 00, true), SLEEP_TIMER);

            Occurrence_FromControl.SendKeysWithDelay(
                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.AddMinutes(3).Minute, DateTime.Now.Second), SLEEP_TIMER); //Current Time (3 minutes over)

            Occurrence_ToControl.SendKeysWithDelay(
                                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second), SLEEP_TIMER); // Current Time

            Fill_OccurrenceAddress(2, 3, false, SLEEP_TIMER);

            Occurrence_SelectVehicleType(2);
            Occurrence_LicensePlateControl.SendKeysWithDelay(StringUtilities.GenerateRandomString(7), SLEEP_TIMER);
            Occurrence_SelectLicenseState(1);
            Occurrence_PastOffenseControl.SendKeysWithDelay("Test", SLEEP_TIMER);
            Occurrence_SecondPastOffenseControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            Fill_InFrontOfSchool(false, SLEEP_TIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ComplaintInfo_ClickNext();

            var invalidTime = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 10);
            Assert.IsNotNull(invalidTime);

            string error = invalidTime.Text.Trim();
            Console.WriteLine(error);

            bool isSatisfiedErrorList = error.Contains(ERROR_BASE) && error.Contains(ERROR_TO_IN_FUTURE_THAN_FROM)
                && error.Contains(ERROR_TO_AND_FROM_IN_FUTURE) && error.Contains(ERROR_SHORTER_THAN_3_MINUTES) && error.Contains(ERROR_INVALID_ASSOCIATED_ADDRESS);
            Assert.True(isSatisfiedErrorList, "Flagged inconsistency on purpose.");

        }

        [Test]
        [Category("Required Field Provided Invalid Input - Error Label Displayed")]
        public void FailedFormSubmit_InFrontOf_NoSchool_FromTimeMoreThanToCurrentTime_InvalidOccurrenceAndAssociatedAddr()
        {
            /*QUALIFYING CRITERIA*/
            ClickNo();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false, true, SLEEP_TIMER);


            /*OCCURRENCE*/
            //Occurrence_FromControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2023, 4, 23, 00, true), SLEEP_TIMER);
            //Occurrence_ToControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2023, 4, 20, 00, true), SLEEP_TIMER);

            Occurrence_FromControl.SendKeysWithDelay(
                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.AddMinutes(3).Minute, DateTime.Now.Second), SLEEP_TIMER); //Current Time (3 minutes over)

            Occurrence_ToControl.SendKeysWithDelay(
                                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second), SLEEP_TIMER); // Current Time

            Fill_OccurrenceAddress(2, 3, true, SLEEP_TIMER);

            Occurrence_SelectVehicleType(2);
            Occurrence_LicensePlateControl.SendKeysWithDelay(StringUtilities.GenerateRandomString(7), SLEEP_TIMER);
            Occurrence_SelectLicenseState(1);
            Occurrence_PastOffenseControl.SendKeysWithDelay("Test", SLEEP_TIMER);
            Occurrence_SecondPastOffenseControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            Fill_InFrontOfSchool(false, SLEEP_TIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ComplaintInfo_ClickNext();

            var invalidTime = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 10);
            Assert.IsNotNull(invalidTime);

            string error = invalidTime.Text.Trim();
            Console.WriteLine(error);

            bool isSatisfiedErrorList = error.Contains(ERROR_BASE) && error.Contains(ERROR_TO_IN_FUTURE_THAN_FROM)
                && error.Contains(ERROR_TO_AND_FROM_IN_FUTURE) && error.Contains(ERROR_SHORTER_THAN_3_MINUTES) && error.Contains(ERROR_INVALID_OCCURRENCE_ADDRESS)
                && error.Contains(ERROR_INVALID_ASSOCIATED_ADDRESS);
            Assert.True(isSatisfiedErrorList, "Flagged inconsistency on purpose.");

        }

        [Test]
        [Category("Required Field Provided Invalid Input - Error Label Displayed")]

        public void FailedForm_NotQualified()
        {
            /*QUALIFYING CRITERIA*/
            ClickYes();

            string criteriaError = Driver.FindElement(By.CssSelector("label[for='criteriaError']")).Text;
            Assert.That(criteriaError, Is.EqualTo(YES_LABEL), "Flagged for inconsistency on purpose");
        }
    }
}
