using IdlingComplaints.Models.ComplaintForm;
using OpenQA.Selenium;
using SeleniumUtilities.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace IdlingComplaints.Tests.ComplaintForm
{
    internal class Test20_BusinessValidation : Test10_ComplaintFormFunctionality
    {

        private readonly int SLEEPTIMER = 1000;
        private readonly string FILE_IMAGE_PATH = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Files\\Images\\idling_truck.jpeg";
        private Utilities utilities = new Utilities();

        [Test]
        public void FailedFormSubmit_InFrontOf_NoSchool_TimeShorterThan3Minutes()
        {
            /*QUALIFYING CRITERIA*/
            ClickNoButton();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            utilities.Fill_Associated(false, false, SLEEPTIMER);

            /*OCCURRENCE*/
            Occurrence_FromControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2023, 4, 20, 00, true), SLEEPTIMER);
            Occurrence_ToControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2023, 4, 20, 01, true), SLEEPTIMER);

            utilities.Fill_OccurrenceAddress(2, 3, false, SLEEPTIMER);

            Occurrence_SelectVehicleType(2);
            Occurrence_LicensePlateControl.SendKeysWithDelay(StringUtilities.GenerateRandomString(7), SLEEPTIMER);
            Occurrence_SelectLicenseState(1);
            Occurrence_PastOffenseControl.SendKeysWithDelay("Test", SLEEPTIMER);
            Occurrence_SecondPastOffenseControl.SendKeysWithDelay("Test", SLEEPTIMER);

            utilities.Fill_InFrontOfSchool(false, SLEEPTIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEPTIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ClickSubmit();

            var invalidTime = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 10);
            Assert.IsNotNull(invalidTime);
            Assert.That(invalidTime.Text.Trim(), Is.EqualTo("An error occurred while saving form: Idling duration should be more than three minutes.")
                , "Flagged inconsistency on purpose.");
        }


        [Test]
        public void FailedFormSubmit_InFrontOf_NoSchool_TimeShorterThan3Minutes_InvalidOccurrenceAddr()
        {
            /*QUALIFYING CRITERIA*/
            ClickNoButton();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            utilities.Fill_Associated(false, false, SLEEPTIMER);

            /*OCCURRENCE*/
            Occurrence_FromControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2023, 4, 20, 00, true), SLEEPTIMER);
            Occurrence_ToControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2023, 4, 20, 01, true), SLEEPTIMER);

            utilities.Fill_OccurrenceAddress(2, 3, true, SLEEPTIMER);

            Occurrence_SelectVehicleType(2);
            Occurrence_LicensePlateControl.SendKeysWithDelay(StringUtilities.GenerateRandomString(7), SLEEPTIMER);
            Occurrence_SelectLicenseState(1);
            Occurrence_PastOffenseControl.SendKeysWithDelay("Test", SLEEPTIMER);
            Occurrence_SecondPastOffenseControl.SendKeysWithDelay("Test", SLEEPTIMER);

            utilities.Fill_InFrontOfSchool(false, SLEEPTIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEPTIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ClickSubmit();

            var invalidTime = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 10);
            Assert.IsNotNull(invalidTime);
            Assert.That(invalidTime.Text.Trim(), Is.EqualTo("An error occurred while saving form: Idling duration should be more than three minutes. " +
                "The occurrence address is invalid.")
                , "Flagged inconsistency on purpose.");
        }

        [Test]
        public void FailedFormSubmit_InFrontOf_NoSchool_TimeShorterThan3Minutes_InvalidAssociatedAddr()
        {
            /*QUALIFYING CRITERIA*/
            ClickNoButton();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            utilities.Fill_Associated(false, true, SLEEPTIMER);

            /*OCCURRENCE*/
            Occurrence_FromControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2023, 4, 20, 00, true), SLEEPTIMER);
            Occurrence_ToControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2023, 4, 20, 01, true), SLEEPTIMER);

            utilities.Fill_OccurrenceAddress(2, 3, true, SLEEPTIMER);

            Occurrence_SelectVehicleType(2);
            Occurrence_LicensePlateControl.SendKeysWithDelay(StringUtilities.GenerateRandomString(7), SLEEPTIMER);
            Occurrence_SelectLicenseState(1);
            Occurrence_PastOffenseControl.SendKeysWithDelay("Test", SLEEPTIMER);
            Occurrence_SecondPastOffenseControl.SendKeysWithDelay("Test", SLEEPTIMER);

            utilities.Fill_InFrontOfSchool(false, SLEEPTIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEPTIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ClickSubmit();

            var invalidTime = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 10);
            Assert.IsNotNull(invalidTime);
            Assert.That(invalidTime.Text.Trim(), Is.EqualTo("An error occurred while saving form: Idling duration should be more than three minutes. " +
                "The address of the respondent associated with the complaint is invalid.")
                , "Flagged inconsistency on purpose.");
        }

        [Test]
        public void FailedFormSubmit_InFrontOf_NoSchool_TimeShorterThan3Minutes_InvalidOccurrenceAndAssociatedAddr()
        {
            /*QUALIFYING CRITERIA*/
            ClickNoButton();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            utilities.Fill_Associated(false, true, SLEEPTIMER);

            /*OCCURRENCE*/
            Occurrence_FromControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2023, 4, 20, 00, true), SLEEPTIMER);
            Occurrence_ToControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2023, 4, 20, 01, true), SLEEPTIMER);

            utilities.Fill_OccurrenceAddress(2, 3, true, SLEEPTIMER);

            Occurrence_SelectVehicleType(2);
            Occurrence_LicensePlateControl.SendKeysWithDelay(StringUtilities.GenerateRandomString(7), SLEEPTIMER);
            Occurrence_SelectLicenseState(1);
            Occurrence_PastOffenseControl.SendKeysWithDelay("Test", SLEEPTIMER);
            Occurrence_SecondPastOffenseControl.SendKeysWithDelay("Test", SLEEPTIMER);

            utilities.Fill_InFrontOfSchool(false, SLEEPTIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEPTIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ClickSubmit();

            var invalidTime = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 10);
            Assert.IsNotNull(invalidTime);
            Assert.That(invalidTime.Text.Trim(), Is.EqualTo("An error occurred while saving form: Idling duration should be more than three minutes. " +
                "The address of the respondent associated with the complaint is invalid.")
                , "Flagged inconsistency on purpose.");
        }

        [Test]
        public void FailedFormSubmit_InFrontOf_NoSchool_TimeInFutureAndShorterThan3Minutes()
        {
            /*QUALIFYING CRITERIA*/
            ClickNoButton();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            utilities.Fill_Associated(false, false, SLEEPTIMER);

            /*OCCURRENCE*/
            Occurrence_FromControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2053, 4, 20, 00, true), SLEEPTIMER);
            Occurrence_ToControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2053, 4, 20, 01, true), SLEEPTIMER);

            utilities.Fill_OccurrenceAddress(2, 3, false, SLEEPTIMER);

            Occurrence_SelectVehicleType(2);
            Occurrence_LicensePlateControl.SendKeysWithDelay(StringUtilities.GenerateRandomString(7), SLEEPTIMER);
            Occurrence_SelectLicenseState(1);
            Occurrence_PastOffenseControl.SendKeysWithDelay("Test", SLEEPTIMER);
            Occurrence_SecondPastOffenseControl.SendKeysWithDelay("Test", SLEEPTIMER);

            utilities.Fill_InFrontOfSchool(false, SLEEPTIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEPTIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ClickSubmit();

            var invalidTime = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 10);
            Assert.IsNotNull(invalidTime);
            Assert.That(invalidTime.Text.Trim(), Is.EqualTo("An error occurred while saving form: Occurrence Date From and Occurrence Date To " +
                "cannot be later than the current date and time. Idling duration should be more than three minutes."), "Flagged inconsistency on purpose.");
        }

        [Test]
        public void FailedFormSubmit_InFrontOf_NoSchool_TimeInFutureAndShorterThan3Minutes_InvalidOccurrenceAddr()
        {
            /*QUALIFYING CRITERIA*/
            ClickNoButton();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            utilities.Fill_Associated(false, false, SLEEPTIMER);

            /*OCCURRENCE*/
            Occurrence_FromControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2053, 4, 20, 00, true), SLEEPTIMER);
            Occurrence_ToControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2053, 4, 20, 01, true), SLEEPTIMER);

            utilities.Fill_OccurrenceAddress(2, 3, true, SLEEPTIMER);

            Occurrence_SelectVehicleType(2);
            Occurrence_LicensePlateControl.SendKeysWithDelay(StringUtilities.GenerateRandomString(7), SLEEPTIMER);
            Occurrence_SelectLicenseState(1);
            Occurrence_PastOffenseControl.SendKeysWithDelay("Test", SLEEPTIMER);
            Occurrence_SecondPastOffenseControl.SendKeysWithDelay("Test", SLEEPTIMER);

            utilities.Fill_InFrontOfSchool(false, SLEEPTIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEPTIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ClickSubmit();

            var invalidTime = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 10);
            Assert.IsNotNull(invalidTime);
            Assert.That(invalidTime.Text.Trim(), Is.EqualTo("An error occurred while saving form: Occurrence Date From and Occurrence Date To " +
                "cannot be later than the current date and time. Idling duration should be more than three minutes. " +
                "The occurrence address is invalid."), "Flagged inconsistency on purpose.");
        }

        [Test]
        public void FailedFormSubmit_InFrontOf_NoSchool_TimeInFutureAndShorterThan3Minutes_InvalidAssociatedAddr()
        {
            /*QUALIFYING CRITERIA*/
            ClickNoButton();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            utilities.Fill_Associated(false, true, SLEEPTIMER);

            /*OCCURRENCE*/
            Occurrence_FromControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2053, 4, 20, 00, true), SLEEPTIMER);
            Occurrence_ToControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2053, 4, 20, 01, true), SLEEPTIMER);

            utilities.Fill_OccurrenceAddress(2, 3, false, SLEEPTIMER);

            Occurrence_SelectVehicleType(2);
            Occurrence_LicensePlateControl.SendKeysWithDelay(StringUtilities.GenerateRandomString(7), SLEEPTIMER);
            Occurrence_SelectLicenseState(1);
            Occurrence_PastOffenseControl.SendKeysWithDelay("Test", SLEEPTIMER);
            Occurrence_SecondPastOffenseControl.SendKeysWithDelay("Test", SLEEPTIMER);

            utilities.Fill_InFrontOfSchool(false, SLEEPTIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEPTIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ClickSubmit();

            var invalidTime = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 10);
            Assert.IsNotNull(invalidTime);
            Assert.That(invalidTime.Text.Trim(), Is.EqualTo("An error occurred while saving form: Occurrence Date From and Occurrence Date To " +
                "cannot be later than the current date and time. Idling duration should be more than three minutes. " +
                "The address of the respondent associated with the complaint is invalid."), "Flagged inconsistency on purpose.");
        }

        [Test]
        public void FailedFormSubmit_InFrontOf_NoSchool_TimeInFutureAndShorterThan3Minutes_InvalidOccurrenceAndAssociatedAddr()
        {
            /*QUALIFYING CRITERIA*/
            ClickNoButton();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            utilities.Fill_Associated(false, true, SLEEPTIMER);

            /*OCCURRENCE*/
            Occurrence_FromControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2053, 4, 20, 00, true), SLEEPTIMER);
            Occurrence_ToControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2053, 4, 20, 01, true), SLEEPTIMER);

            utilities.Fill_OccurrenceAddress(2, 3, true, SLEEPTIMER);

            Occurrence_SelectVehicleType(2);
            Occurrence_LicensePlateControl.SendKeysWithDelay(StringUtilities.GenerateRandomString(7), SLEEPTIMER);
            Occurrence_SelectLicenseState(1);
            Occurrence_PastOffenseControl.SendKeysWithDelay("Test", SLEEPTIMER);
            Occurrence_SecondPastOffenseControl.SendKeysWithDelay("Test", SLEEPTIMER);

            utilities.Fill_InFrontOfSchool(false, SLEEPTIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEPTIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ClickSubmit();

            var invalidTime = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 10);
            Assert.IsNotNull(invalidTime);
            Assert.That(invalidTime.Text.Trim(), Is.EqualTo("An error occurred while saving form: Occurrence Date From and Occurrence Date To " +
                "cannot be later than the current date and time. Idling duration should be more than three minutes. " +
                "The address of the respondent associated with the complaint is invalid."), "Flagged inconsistency on purpose.");
        }

        [Test]
        public void FailedFormSubmit_InFrontOf_NoSchool_TimeInFuture()
        {
            /*QUALIFYING CRITERIA*/
            ClickNoButton();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            utilities.Fill_Associated(false, false, SLEEPTIMER);

            /*OCCURRENCE*/
            Occurrence_FromControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2053, 4, 20, 00, true), SLEEPTIMER);
            Occurrence_ToControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2053, 4, 23, 01, true), SLEEPTIMER);

            utilities.Fill_OccurrenceAddress(2, 3, false, SLEEPTIMER);

            Occurrence_SelectVehicleType(2);
            Occurrence_LicensePlateControl.SendKeysWithDelay(StringUtilities.GenerateRandomString(7), SLEEPTIMER);
            Occurrence_SelectLicenseState(1);
            Occurrence_PastOffenseControl.SendKeysWithDelay("Test", SLEEPTIMER);
            Occurrence_SecondPastOffenseControl.SendKeysWithDelay("Test", SLEEPTIMER);

            utilities.Fill_InFrontOfSchool(false, SLEEPTIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEPTIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ClickSubmit();

            var invalidTime = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 10);
            Assert.IsNotNull(invalidTime);
            Assert.That(invalidTime.Text.Trim(), Is.EqualTo("An error occurred while saving form: Occurrence Date From and Occurrence Date To " +
                "cannot be later than the current date and time."), "Flagged inconsistency on purpose.");
        }

        [Test]
        public void FailedFormSubmit_InFrontOf_NoSchool_TimeInFuture_InvalidOccurrenceAddr()
        {
            /*QUALIFYING CRITERIA*/
            ClickNoButton();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            utilities.Fill_Associated(false, false, SLEEPTIMER);

            /*OCCURRENCE*/
            Occurrence_FromControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2053, 4, 20, 00, true), SLEEPTIMER);
            Occurrence_ToControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2053, 4, 23, 01, true), SLEEPTIMER);

            utilities.Fill_OccurrenceAddress(2, 3, true, SLEEPTIMER);

            Occurrence_SelectVehicleType(2);
            Occurrence_LicensePlateControl.SendKeysWithDelay(StringUtilities.GenerateRandomString(7), SLEEPTIMER);
            Occurrence_SelectLicenseState(1);
            Occurrence_PastOffenseControl.SendKeysWithDelay("Test", SLEEPTIMER);
            Occurrence_SecondPastOffenseControl.SendKeysWithDelay("Test", SLEEPTIMER);

            utilities.Fill_InFrontOfSchool(false, SLEEPTIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEPTIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ClickSubmit();

            var invalidTime = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 10);
            Assert.IsNotNull(invalidTime);
            Assert.That(invalidTime.Text.Trim(), Is.EqualTo("An error occurred while saving form: Occurrence Date From and Occurrence Date To " +
                "cannot be later than the current date and time. The occurrence address is invalid."), "Flagged inconsistency on purpose.");
        }

        [Test]
        public void FailedFormSubmit_InFrontOf_NoSchool_TimeInFuture_InvalidAssociatedAddr()
        {
            /*QUALIFYING CRITERIA*/
            ClickNoButton();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            utilities.Fill_Associated(false, true, SLEEPTIMER);

            /*OCCURRENCE*/
            Occurrence_FromControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2053, 4, 20, 00, true), SLEEPTIMER);
            Occurrence_ToControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2053, 4, 23, 01, true), SLEEPTIMER);

            utilities.Fill_OccurrenceAddress(2, 3, false, SLEEPTIMER);

            Occurrence_SelectVehicleType(2);
            Occurrence_LicensePlateControl.SendKeysWithDelay(StringUtilities.GenerateRandomString(7), SLEEPTIMER);
            Occurrence_SelectLicenseState(1);
            Occurrence_PastOffenseControl.SendKeysWithDelay("Test", SLEEPTIMER);
            Occurrence_SecondPastOffenseControl.SendKeysWithDelay("Test", SLEEPTIMER);

            utilities.Fill_InFrontOfSchool(false, SLEEPTIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEPTIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ClickSubmit();

            var invalidTime = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 10);
            Assert.IsNotNull(invalidTime);
            Assert.That(invalidTime.Text.Trim(), Is.EqualTo("An error occurred while saving form: Occurrence Date From and Occurrence Date To " +
                "cannot be later than the current date and time. The address of the respondent associated with the complaint is invalid."), "Flagged inconsistency on purpose.");
        }

        [Test]
        public void FailedFormSubmit_InFrontOf_NoSchool_TimeInFuture_InvalidOccurrenceAndAssociatedAddr()
        {
            /*QUALIFYING CRITERIA*/
            ClickNoButton();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            utilities.Fill_Associated(false, true, SLEEPTIMER);

            /*OCCURRENCE*/
            Occurrence_FromControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2053, 4, 20, 00, true), SLEEPTIMER);
            Occurrence_ToControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2053, 4, 23, 01, true), SLEEPTIMER);

            utilities.Fill_OccurrenceAddress(2, 3, true, SLEEPTIMER);

            Occurrence_SelectVehicleType(2);
            Occurrence_LicensePlateControl.SendKeysWithDelay(StringUtilities.GenerateRandomString(7), SLEEPTIMER);
            Occurrence_SelectLicenseState(1);
            Occurrence_PastOffenseControl.SendKeysWithDelay("Test", SLEEPTIMER);
            Occurrence_SecondPastOffenseControl.SendKeysWithDelay("Test", SLEEPTIMER);

            utilities.Fill_InFrontOfSchool(false, SLEEPTIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEPTIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ClickSubmit();

            var invalidTime = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 10);
            Assert.IsNotNull(invalidTime);
            Assert.That(invalidTime.Text.Trim(), Is.EqualTo("An error occurred while saving form: Occurrence Date From and Occurrence Date To " +
                "cannot be later than the current date and time. " +
                "The address of the respondent associated with the complaint is invalid."), "Flagged inconsistency on purpose.");
        }

        [Test]
        public void FailedFormSubmit_InFrontOf_NoSchool_FromTimeMoreThanToTime()
        {
            /*QUALIFYING CRITERIA*/
            ClickNoButton();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            utilities.Fill_Associated(false, false, SLEEPTIMER);

            /*OCCURRENCE*/
            Occurrence_FromControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2023, 4, 23, 00, true), SLEEPTIMER);
            Occurrence_ToControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2023, 4, 20, 00, true), SLEEPTIMER);

            utilities.Fill_OccurrenceAddress(2, 3, false, SLEEPTIMER);

            Occurrence_SelectVehicleType(2);
            Occurrence_LicensePlateControl.SendKeysWithDelay(StringUtilities.GenerateRandomString(7), SLEEPTIMER);
            Occurrence_SelectLicenseState(1);
            Occurrence_PastOffenseControl.SendKeysWithDelay("Test", SLEEPTIMER);
            Occurrence_SecondPastOffenseControl.SendKeysWithDelay("Test", SLEEPTIMER);

            utilities.Fill_InFrontOfSchool(false, SLEEPTIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEPTIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ClickSubmit();

            var invalidTime = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 10);
            Assert.IsNotNull(invalidTime);
            Assert.That(invalidTime.Text.Trim(), Is.EqualTo("An error occurred while saving form: Occurrence Date To should be later " +
                "than the Occurrence Date From. Idling duration should be more than three minutes."), "Flagged inconsistency on purpose.");
        }


        [Test]
        public void FailedFormSubmit_InFrontOf_NoSchool_FromTimeMoreThanToTime_InvalidOccurrenceTime()
        {
            /*QUALIFYING CRITERIA*/
            ClickNoButton();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            utilities.Fill_Associated(false, false, SLEEPTIMER);

            /*OCCURRENCE*/
            Occurrence_FromControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2023, 4, 23, 00, true), SLEEPTIMER);
            Occurrence_ToControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2023, 4, 20, 00, true), SLEEPTIMER);

            utilities.Fill_OccurrenceAddress(2, 3, true, SLEEPTIMER);

            Occurrence_SelectVehicleType(2);
            Occurrence_LicensePlateControl.SendKeysWithDelay(StringUtilities.GenerateRandomString(7), SLEEPTIMER);
            Occurrence_SelectLicenseState(1);
            Occurrence_PastOffenseControl.SendKeysWithDelay("Test", SLEEPTIMER);
            Occurrence_SecondPastOffenseControl.SendKeysWithDelay("Test", SLEEPTIMER);

            utilities.Fill_InFrontOfSchool(false, SLEEPTIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEPTIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ClickSubmit();

            var invalidTime = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 10);
            Assert.IsNotNull(invalidTime);
            Assert.That(invalidTime.Text.Trim(), Is.EqualTo("An error occurred while saving form: Occurrence Date To should be later " +
                "than the Occurrence Date From. Idling duration should be more than three minutes. " +
                "The occurrence address is invalid."), "Flagged inconsistency on purpose.");
        }


        [Test]
        public void FailedFormSubmit_InFrontOf_NoSchool_FromTimeMoreThanToTime_InvalidAssociatedAddress()
        {
            /*QUALIFYING CRITERIA*/
            ClickNoButton();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            utilities.Fill_Associated(false, true, SLEEPTIMER);

            /*OCCURRENCE*/
            Occurrence_FromControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2023, 4, 23, 00, true), SLEEPTIMER);
            Occurrence_ToControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2023, 4, 20, 00, true), SLEEPTIMER);

            utilities.Fill_OccurrenceAddress(2, 3, false, SLEEPTIMER);

            Occurrence_SelectVehicleType(2);
            Occurrence_LicensePlateControl.SendKeysWithDelay(StringUtilities.GenerateRandomString(7), SLEEPTIMER);
            Occurrence_SelectLicenseState(1);
            Occurrence_PastOffenseControl.SendKeysWithDelay("Test", SLEEPTIMER);
            Occurrence_SecondPastOffenseControl.SendKeysWithDelay("Test", SLEEPTIMER);

            utilities.Fill_InFrontOfSchool(false, SLEEPTIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEPTIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ClickSubmit();

            var invalidTime = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 10);
            Assert.IsNotNull(invalidTime);
            Assert.That(invalidTime.Text.Trim(), Is.EqualTo("An error occurred while saving form: Occurrence Date To should be later " +
                "than the Occurrence Date From. Idling duration should be more than three minutes. " +
                "The address of the respondent associated with the complaint is invalid."), "Flagged inconsistency on purpose.");
        }


        [Test]
        public void FailedFormSubmit_InFrontOf_NoSchool_FromTimeMoreThanToTime_InvalidOccurrenceAndAssociatedAddr()
        {
            /*QUALIFYING CRITERIA*/
            ClickNoButton();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            utilities.Fill_Associated(false, true, SLEEPTIMER);

            /*OCCURRENCE*/
            Occurrence_FromControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2023, 4, 23, 00, true), SLEEPTIMER);
            Occurrence_ToControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2023, 4, 20, 00, true), SLEEPTIMER);

            utilities.Fill_OccurrenceAddress(2, 3, true, SLEEPTIMER);

            Occurrence_SelectVehicleType(2);
            Occurrence_LicensePlateControl.SendKeysWithDelay(StringUtilities.GenerateRandomString(7), SLEEPTIMER);
            Occurrence_SelectLicenseState(1);
            Occurrence_PastOffenseControl.SendKeysWithDelay("Test", SLEEPTIMER);
            Occurrence_SecondPastOffenseControl.SendKeysWithDelay("Test", SLEEPTIMER);

            utilities.Fill_InFrontOfSchool(false, SLEEPTIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEPTIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ClickSubmit();

            var invalidTime = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 10);
            Assert.IsNotNull(invalidTime);
            Assert.That(invalidTime.Text.Trim(), Is.EqualTo("An error occurred while saving form: Occurrence Date To should be later " +
                "than the Occurrence Date From. Idling duration should be more than three minutes. " +
                "The address of the respondent associated with the complaint is invalid."), "Flagged inconsistency on purpose.");
        }


    }
}
