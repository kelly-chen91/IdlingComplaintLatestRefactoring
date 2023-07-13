using IdlingComplaints.Models.ComplaintForm;
using IdlingComplaints.Tests.ComplaintForm.C10_OverallFunctionality;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V112.Database;
using SeleniumUtilities.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace IdlingComplaints.Tests.ComplaintForm.P20_Occurrence
{
    internal class Test20_BusinessValidation : FillComplaintForm_Base
    {
        [SetUp]
        public void SetUp()
        {
            ComplaintFormModelSetUp(false);

        }

        [TearDown]
        public void TearDown()
        {
            if (SLEEP_TIMER > 0) { Thread.Sleep(SLEEP_TIMER); }
            //ComplaintFormModelTearDown();
        }

        [Test]
        [Category("Required Field Provided Valid Input - Error Label Hidden")]
        public void SuccessfulSaveMessage()
        {
            base.Filled_ComplaintInfo();

            var successfulSave = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20).FindElement(By.TagName("span"));
            Assert.IsNotNull(successfulSave);
            Assert.That(successfulSave.Text.Trim(), Is.EqualTo("This form has been saved successfully."), "Flagged inconsistency on purpose.");
        }

        [Test]
        [Category("Required Field Provided Invalid Input - Error Label Displayed")]

        public void FailedSubmission_InFrontOf_NoSchool_InvalidAssociatedAddress()
        {
            /*QUALIFYING CRITERIA*/
            ClickNo();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false, true, SLEEP_TIMER);

            /*OCCURRENCE*/

            Occurrence_FromControl.SendKeysWithDelay(
                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.AddMinutes(-3).Minute, DateTime.Now.Second), SLEEP_TIMER); // Current Time (1 minutes ago)

            Occurrence_ToControl.SendKeysWithDelay(
                                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second), SLEEP_TIMER); // Current Time


            Fill_OccurrenceAddress(2, 3, false, SLEEP_TIMER);

            Occurrence_VehicleInformation();

            Fill_InFrontOfSchool(false, SLEEP_TIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ComplaintInfo_ClickNext();

            var invalidTime = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 10).FindElement(By.TagName("span"));
            Assert.IsNotNull(invalidTime);

            string error = invalidTime.Text.Trim();
            Console.WriteLine(error);

            string errorDetail = error.Substring(ERROR_BASE.Length);
            string[] errorDetailList = errorDetail.Split(". ", StringSplitOptions.None);
            for(int i = 0; i < errorDetailList.Length; i++)
            {
                Console.WriteLine(errorDetailList[i]);
                if (errorDetailList[i].Contains("associated"))
                {
                    if (errorDetailList[i].Contains("."))
                        Assert.That(errorDetailList[i], Is.EqualTo(ERROR_INVALID_ASSOCIATED_ADDRESS + "."),
                        "Expecting [" + ERROR_INVALID_ASSOCIATED_ADDRESS + "." + "], but found [" + errorDetailList[i] + "]");
                    else Assert.That(errorDetailList[i], Is.EqualTo(ERROR_INVALID_ASSOCIATED_ADDRESS),
                        "Expecting [" + ERROR_INVALID_ASSOCIATED_ADDRESS + "], but found [" + errorDetailList[i] + "]");
                }
            }
            if (!error.Contains(ERROR_BASE))
                Assert.That(error.Substring(0, ERROR_BASE.Length), Is.EqualTo(ERROR_BASE),
                    "Expecting [" + ERROR_BASE + "], but found [" + error.Substring(0, ERROR_BASE.Length) + "]");
            
            //if (!error.Contains(ERROR_INVALID_ASSOCIATED_ADDRESS))
            //    Assert.That(error.Substring(0, ERROR_INVALID_ASSOCIATED_ADDRESS.Length), Is.EqualTo(ERROR_INVALID_ASSOCIATED_ADDRESS),
            //        "Expecting [" + ERROR_INVALID_ASSOCIATED_ADDRESS + "], but found [" + error.Substring(0, ERROR_INVALID_ASSOCIATED_ADDRESS.Length) + "]");
        }

        [Test]
        [Category("Required Field Provided Invalid Input - Error Label Displayed")]
        public void FailedSubmission_InFrontOf_NoSchool_InvalidOccurrenceAddress()
        {
            /*QUALIFYING CRITERIA*/
            ClickNo();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false, false, SLEEP_TIMER);

            /*OCCURRENCE*/

            Occurrence_FromControl.SendKeysWithDelay(
                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.AddMinutes(-3).Minute, DateTime.Now.Second), SLEEP_TIMER); // Current Time (1 minutes ago)

            Occurrence_ToControl.SendKeysWithDelay(
                                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second), SLEEP_TIMER); // Current Time


            Fill_OccurrenceAddress(2, 3, true, SLEEP_TIMER);

            Occurrence_VehicleInformation();

            Fill_InFrontOfSchool(false, SLEEP_TIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ComplaintInfo_ClickNext();

            var invalidTime = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 10).FindElement(By.TagName("span"));
            Assert.IsNotNull(invalidTime);

            string error = invalidTime.Text.Trim();
            Console.WriteLine(error);

            string errorDetail = error.Substring(ERROR_BASE.Length);
            string[] errorDetailList = errorDetail.Split(". ", StringSplitOptions.None);
            for(int i = 0; i < errorDetailList.Length; i++)
            {
                Console.WriteLine(errorDetailList[i]);
                if (errorDetailList[i].Contains("occurrence address"))
                {
                    if (errorDetailList[i].Contains("."))
                        Assert.That(errorDetailList[i], Is.EqualTo(ERROR_INVALID_OCCURRENCE_ADDRESS + "."),
                        "Expecting [" + ERROR_INVALID_OCCURRENCE_ADDRESS + "." + "], but found [" + errorDetailList[i] + "]");
                    else Assert.That(errorDetailList[i], Is.EqualTo(ERROR_INVALID_OCCURRENCE_ADDRESS),
                        "Expecting [" + ERROR_INVALID_OCCURRENCE_ADDRESS + "], but found [" + errorDetailList[i] + "]");
                }
            }
            
            if (!error.Contains(ERROR_BASE))
                Assert.That(error.Substring(0, ERROR_BASE.Length), Is.EqualTo(ERROR_BASE),
                    "Expecting [" + ERROR_BASE + "], but found [" + error.Substring(0, ERROR_BASE.Length) + "]");

            //if (!error.Contains(ERROR_INVALID_OCCURRENCE_ADDRESS))
            //    Assert.That(error.Substring(0, ERROR_INVALID_OCCURRENCE_ADDRESS.Length), Is.EqualTo(ERROR_INVALID_OCCURRENCE_ADDRESS),
            //        "Expecting [" + ERROR_INVALID_OCCURRENCE_ADDRESS + "], but found [" + error.Substring(0, ERROR_INVALID_OCCURRENCE_ADDRESS.Length) + "]");
        }

        [Test]
        [Category("Required Field Provided Invalid Input - Error Label Displayed")]
        public void FailedSubmission_InFrontOf_NoSchool_InvalidOccurrenceAndAssociatedAddr()
        {
            /*QUALIFYING CRITERIA*/
            ClickNo();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false, true, SLEEP_TIMER);

            /*OCCURRENCE*/

            Occurrence_FromControl.SendKeysWithDelay(
                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.AddMinutes(-3).Minute, DateTime.Now.Second), SLEEP_TIMER); // Current Time (1 minutes ago)

            Occurrence_ToControl.SendKeysWithDelay(
                                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second), SLEEP_TIMER); // Current Time


            Fill_OccurrenceAddress(2, 3, true, SLEEP_TIMER);

            Occurrence_VehicleInformation();

            Fill_InFrontOfSchool(false, SLEEP_TIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ComplaintInfo_ClickNext();

            var invalidTime = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 10).FindElement(By.TagName("span"));
            Assert.IsNotNull(invalidTime);

            string error = invalidTime.Text.Trim();
            Console.WriteLine(error);

            string errorDetail = error.Substring(ERROR_BASE.Length);
            string[] errorDetailList = errorDetail.Split(". ", StringSplitOptions.None);
            for(int i = 0; i < errorDetailList.Length; i++)
            {
                Console.WriteLine(errorDetailList[i]);
                if (errorDetailList[i].Contains("occurrence address"))
                {
                    if (errorDetailList[i].Contains("."))
                        Assert.That(errorDetailList[i], Is.EqualTo(ERROR_INVALID_OCCURRENCE_ADDRESS + "."),
                        "Expecting [" + ERROR_INVALID_OCCURRENCE_ADDRESS + "." + "], but found [" + errorDetailList[i] + "]");
                    else Assert.That(errorDetailList[i], Is.EqualTo(ERROR_INVALID_OCCURRENCE_ADDRESS),
                        "Expecting [" + ERROR_INVALID_OCCURRENCE_ADDRESS + "], but found [" + errorDetailList[i] + "]");
                }

                else if (errorDetailList[i].Contains("associated"))
                {
                    if (errorDetailList[i].Contains("."))
                        Assert.That(errorDetailList[i], Is.EqualTo(ERROR_INVALID_ASSOCIATED_ADDRESS + "."),
                        "Expecting [" + ERROR_INVALID_ASSOCIATED_ADDRESS + "." + "], but found [" + errorDetailList[i] + "]");
                    else Assert.That(errorDetailList[i], Is.EqualTo(ERROR_INVALID_ASSOCIATED_ADDRESS),
                        "Expecting [" + ERROR_INVALID_ASSOCIATED_ADDRESS + "], but found [" + errorDetailList[i] + "]");
                }
            }

            if (!error.Contains(ERROR_BASE))
                Assert.That(error.Substring(0, ERROR_BASE.Length), Is.EqualTo(ERROR_BASE),
                    "Expecting [" + ERROR_BASE + "], but found [" + error.Substring(0, ERROR_BASE.Length) + "]");

            //if (!error.Contains(ERROR_INVALID_ASSOCIATED_ADDRESS))
            //    Assert.That(error.Substring(0, ERROR_INVALID_ASSOCIATED_ADDRESS.Length), Is.EqualTo(ERROR_INVALID_ASSOCIATED_ADDRESS),
            //        "Expecting [" + ERROR_INVALID_ASSOCIATED_ADDRESS + "], but found [" + error.Substring(0, ERROR_INVALID_ASSOCIATED_ADDRESS.Length) + "]");
            //
            //if (!error.Contains(ERROR_INVALID_OCCURRENCE_ADDRESS))
            //    Assert.That(error.Substring(0, ERROR_INVALID_OCCURRENCE_ADDRESS.Length), Is.EqualTo(ERROR_INVALID_OCCURRENCE_ADDRESS),
            //        "Expecting [" + ERROR_INVALID_OCCURRENCE_ADDRESS + "], but found [" + error.Substring(0, ERROR_INVALID_OCCURRENCE_ADDRESS.Length) + "]");
        }

        [Test]
        [Category("Required Field Provided Invalid Input - Error Label Displayed")]

        public void FailedSubmission_InFrontOf_NoSchool_TimeShorterThan3Minutes()
        {
            /*QUALIFYING CRITERIA*/
            ClickNo();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false, false, SLEEP_TIMER);

            /*OCCURRENCE*/
            
            Occurrence_FromControl.SendKeysWithDelay(
                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.AddMinutes(-1).Minute, DateTime.Now.Second), SLEEP_TIMER); // Current Time (1 minutes ago)

            Occurrence_ToControl.SendKeysWithDelay(
                                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second), SLEEP_TIMER); // Current Time


            Fill_OccurrenceAddress(2, 3, false, SLEEP_TIMER);

            Occurrence_VehicleInformation();

            Fill_InFrontOfSchool(false, SLEEP_TIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ComplaintInfo_ClickNext();

            var invalidTime = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 10).FindElement(By.TagName("span"));
            Assert.IsNotNull(invalidTime);

            string error = invalidTime.Text.Trim();
            Console.WriteLine(error);

            string errorDetail = error.Substring(ERROR_BASE.Length);
            string[] errorDetailList = errorDetail.Split(". ", StringSplitOptions.None);
            for(int i = 0; i < errorDetailList.Length; i++)
            {
                Console.WriteLine(errorDetailList[i]);
                if (errorDetailList[i].Contains("three minutes"))
                {
                    if (errorDetailList[i].Contains("."))
                        Assert.That(errorDetailList[i], Is.EqualTo(ERROR_SHORTER_THAN_3_MINUTES + "."),
                        "Expecting [" + ERROR_SHORTER_THAN_3_MINUTES + "." + "], but found [" + errorDetailList[i] + "]");
                    else Assert.That(errorDetailList[i], Is.EqualTo(ERROR_SHORTER_THAN_3_MINUTES),
                        "Expecting [" + ERROR_SHORTER_THAN_3_MINUTES + "], but found [" + errorDetailList[i] + "]");
                }
                else
                    Assert.True(errorDetailList[i].Contains("three minutes"), "The text does not contain the expected errors.");

            }

            if (!error.Contains(ERROR_BASE))
                Assert.That(error.Substring(0, ERROR_BASE.Length), Is.EqualTo(ERROR_BASE),
                    "Expecting [" + ERROR_BASE + "], but found [" + error.Substring(0, ERROR_BASE.Length) + "]");

            //if (!error.Contains(ERROR_SHORTER_THAN_3_MINUTES))
            //    Assert.That(error.Substring(0, ERROR_SHORTER_THAN_3_MINUTES.Length), Is.EqualTo(ERROR_SHORTER_THAN_3_MINUTES),
            //        "Expecting [" + ERROR_SHORTER_THAN_3_MINUTES + "], but found [" + error.Substring(0, ERROR_SHORTER_THAN_3_MINUTES.Length) + "]");
        }


        [Test]
        [Category("Required Field Provided Invalid Input - Error Label Displayed")]

        public void FailedSubmission_InFrontOf_NoSchool_TimeShorterThan3Minutes_InvalidOccurrenceAddr()
        {
            /*QUALIFYING CRITERIA*/
            ClickNo();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false, false, SLEEP_TIMER);

            /*OCCURRENCE*/

            Occurrence_FromControl.SendKeysWithDelay(
                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.AddMinutes(-1).Minute, DateTime.Now.Second), SLEEP_TIMER); // Current Time (1 minutes ago)

            Occurrence_ToControl.SendKeysWithDelay(
                                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second), SLEEP_TIMER); // Current Time

            Fill_OccurrenceAddress(2, 3, true, SLEEP_TIMER);

            Occurrence_VehicleInformation();


            Fill_InFrontOfSchool(false, SLEEP_TIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ComplaintInfo_ClickNext();

            var invalidTime = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 10).FindElement(By.TagName("span"));
            Assert.IsNotNull(invalidTime);

            string error = invalidTime.Text.Trim();
            Console.WriteLine(error);

            string errorDetail = error.Substring(ERROR_BASE.Length);
            string[] errorDetailList = errorDetail.Split(". ", StringSplitOptions.None);
            for(int i = 0; i < errorDetailList.Length; i++)
            {
                Console.WriteLine(errorDetailList[i]);
                if (errorDetailList[i].Contains("three minutes"))
                {
                    if (errorDetailList[i].Contains("."))
                        Assert.That(errorDetailList[i], Is.EqualTo(ERROR_SHORTER_THAN_3_MINUTES + "."),
                        "Expecting [" + ERROR_SHORTER_THAN_3_MINUTES + "." + "], but found [" + errorDetailList[i] + "]");
                    else Assert.That(errorDetailList[i], Is.EqualTo(ERROR_SHORTER_THAN_3_MINUTES),
                        "Expecting [" + ERROR_SHORTER_THAN_3_MINUTES + "], but found [" + errorDetailList[i] + "]");
                }
                else if (errorDetailList[i].Contains("associated"))
                {
                    if (errorDetailList[i].Contains("."))
                        Assert.That(errorDetailList[i], Is.EqualTo(ERROR_INVALID_ASSOCIATED_ADDRESS + "."),
                        "Expecting [" + ERROR_INVALID_ASSOCIATED_ADDRESS + "." + "], but found [" + errorDetailList[i] + "]");
                    else Assert.That(errorDetailList[i], Is.EqualTo(ERROR_INVALID_ASSOCIATED_ADDRESS),
                        "Expecting [" + ERROR_INVALID_ASSOCIATED_ADDRESS + "], but found [" + errorDetailList[i] + "]");
                }
                else
                    Assert.True(errorDetailList[i].Contains("three minutes") || errorDetailList[i].Contains("associated"), "The text does not contain the expected errors.");

            }
            if (!error.Contains(ERROR_BASE))
                Assert.That(error.Substring(0, ERROR_BASE.Length), Is.EqualTo(ERROR_BASE),
                    "Expecting [" + ERROR_BASE + "], but found [" + error.Substring(0, ERROR_BASE.Length) + "]");

            //if (!error.Contains(ERROR_SHORTER_THAN_3_MINUTES))
            //    Assert.That(error.Substring(0, ERROR_SHORTER_THAN_3_MINUTES.Length), Is.EqualTo(ERROR_SHORTER_THAN_3_MINUTES),
            //        "Expecting [" + ERROR_SHORTER_THAN_3_MINUTES + "], but found [" + error.Substring(0, ERROR_SHORTER_THAN_3_MINUTES.Length) + "]");
            //
            //if (!error.Contains(ERROR_INVALID_OCCURRENCE_ADDRESS))
            //    Assert.That(error.Substring(0, ERROR_INVALID_OCCURRENCE_ADDRESS.Length), Is.EqualTo(ERROR_INVALID_OCCURRENCE_ADDRESS),
            //        "Expecting [" + ERROR_INVALID_OCCURRENCE_ADDRESS + "], but found [" + error.Substring(0, ERROR_INVALID_OCCURRENCE_ADDRESS.Length) + "]");

        }


        [Test]
        [Category("Required Field Provided Invalid Input - Error Label Displayed")]

        public void FailedSubmission_InFrontOf_NoSchool_TimeShorterThan3Minutes_InvalidAssociatedAddr()
        {
            /*QUALIFYING CRITERIA*/
            ClickNo();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false, true, SLEEP_TIMER);

            /*OCCURRENCE*/

            Occurrence_FromControl.SendKeysWithDelay(
                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.AddMinutes(-1).Minute, DateTime.Now.Second), SLEEP_TIMER); // Current Time (3 minutes ago)

            Occurrence_ToControl.SendKeysWithDelay(
                                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second), SLEEP_TIMER); // Current Time

            Fill_OccurrenceAddress(2, 3, true, SLEEP_TIMER);

            Occurrence_VehicleInformation();

            Fill_InFrontOfSchool(false, SLEEP_TIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ComplaintInfo_ClickNext();

            var invalidTime = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 10).FindElement(By.TagName("span"));
            Assert.IsNotNull(invalidTime);

            string error = invalidTime.Text.Trim();
            Console.WriteLine(error);

            string errorDetail = error.Substring(ERROR_BASE.Length);
            string[] errorDetailList = errorDetail.Split(". ", StringSplitOptions.None);
            for(int i = 0; i < errorDetailList.Length; i++)
            {
                Console.WriteLine(errorDetailList[i]);
                if (errorDetailList[i].Contains("three minutes"))
                {
                    if (errorDetailList[i].Contains("."))
                        Assert.That(errorDetailList[i], Is.EqualTo(ERROR_SHORTER_THAN_3_MINUTES + "."),
                        "Expecting [" + ERROR_SHORTER_THAN_3_MINUTES + "." + "], but found [" + errorDetailList[i] + "]");
                    else Assert.That(errorDetailList[i], Is.EqualTo(ERROR_SHORTER_THAN_3_MINUTES),
                        "Expecting [" + ERROR_SHORTER_THAN_3_MINUTES + "], but found [" + errorDetailList[i] + "]");
                }
                else if (errorDetailList[i].Contains("occurrence address"))
                {
                    if (errorDetailList[i].Contains("."))
                        Assert.That(errorDetailList[i], Is.EqualTo(ERROR_INVALID_OCCURRENCE_ADDRESS + "."),
                        "Expecting [" + ERROR_INVALID_OCCURRENCE_ADDRESS + "." + "], but found [" + errorDetailList[i] + "]");
                    else Assert.That(errorDetailList[i], Is.EqualTo(ERROR_INVALID_OCCURRENCE_ADDRESS),
                        "Expecting [" + ERROR_INVALID_OCCURRENCE_ADDRESS + "], but found [" + errorDetailList[i] + "]");
                }
                else
                    Assert.True(errorDetailList[i].Contains("three minutes") || errorDetailList[i].Contains("occurrence address"), "The text does not contain the expected errors.");

            }

            if (!error.Contains(ERROR_BASE))
                Assert.That(error.Substring(0, ERROR_BASE.Length), Is.EqualTo(ERROR_BASE),
                    "Expecting [" + ERROR_BASE + "], but found [" + error.Substring(0, ERROR_BASE.Length) + "]");

            //if (!error.Contains(ERROR_SHORTER_THAN_3_MINUTES))
            //    Assert.That(error.Substring(0, ERROR_SHORTER_THAN_3_MINUTES.Length), Is.EqualTo(ERROR_SHORTER_THAN_3_MINUTES),
            //        "Expecting [" + ERROR_SHORTER_THAN_3_MINUTES + "], but found [" + error.Substring(0, ERROR_SHORTER_THAN_3_MINUTES.Length) + "]");
            //
            //if (!error.Contains(ERROR_INVALID_ASSOCIATED_ADDRESS))
            //    Assert.That(error.Substring(0, ERROR_INVALID_ASSOCIATED_ADDRESS.Length), Is.EqualTo(ERROR_INVALID_ASSOCIATED_ADDRESS),
            //        "Expecting [" + ERROR_INVALID_ASSOCIATED_ADDRESS + "], but found [" + error.Substring(0, ERROR_INVALID_ASSOCIATED_ADDRESS.Length) + "]");


        }

        [Test]
        [Category("Required Field Provided Invalid Input - Error Label Displayed")]

        public void FailedSubmission_InFrontOf_NoSchool_TimeShorterThan3Minutes_InvalidOccurrenceAndAssociatedAddr()
        {
            /*QUALIFYING CRITERIA*/
            ClickNo();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false, true, SLEEP_TIMER);

            /*OCCURRENCE*/

            Occurrence_FromControl.SendKeysWithDelay(
                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.AddMinutes(-1).Minute, DateTime.Now.Second), SLEEP_TIMER); // Current Time (1 minutes ago)

            Occurrence_ToControl.SendKeysWithDelay(
                                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second), SLEEP_TIMER); // Current Time


            Fill_OccurrenceAddress(2, 3, true, SLEEP_TIMER);

            Occurrence_VehicleInformation();

            Fill_InFrontOfSchool(false, SLEEP_TIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ComplaintInfo_ClickNext();

            var invalidTime = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 10).FindElement(By.TagName("span"));
            Assert.IsNotNull(invalidTime);

            string error = invalidTime.Text.Trim();
            Console.WriteLine(error);


            string errorDetail = error.Substring(ERROR_BASE.Length);
            string[] errorDetailList = errorDetail.Split(". ", StringSplitOptions.None);
            for(int i = 0; i < errorDetailList.Length; i++)
            {
                Console.WriteLine(errorDetailList[i]);
                if (errorDetailList[i].Contains("three minutes"))
                {
                    if (errorDetailList[i].Contains("."))
                        Assert.That(errorDetailList[i], Is.EqualTo(ERROR_SHORTER_THAN_3_MINUTES + "."),
                        "Expecting [" + ERROR_SHORTER_THAN_3_MINUTES + "." + "], but found [" + errorDetailList[i] + "]");
                    else Assert.That(errorDetailList[i], Is.EqualTo(ERROR_SHORTER_THAN_3_MINUTES),
                        "Expecting [" + ERROR_SHORTER_THAN_3_MINUTES + "], but found [" + errorDetailList[i] + "]");
                }
                else if (errorDetailList[i].Contains("occurrence address"))
                {
                    if (errorDetailList[i].Contains("."))
                        Assert.That(errorDetailList[i], Is.EqualTo(ERROR_INVALID_OCCURRENCE_ADDRESS + "."),
                        "Expecting [" + ERROR_INVALID_OCCURRENCE_ADDRESS + "." + "], but found [" + errorDetailList[i] + "]");
                    else Assert.That(errorDetailList[i], Is.EqualTo(ERROR_INVALID_OCCURRENCE_ADDRESS),
                        "Expecting [" + ERROR_INVALID_OCCURRENCE_ADDRESS + "], but found [" + errorDetailList[i] + "]");
                }
                else if (errorDetailList[i].Contains("associated"))
                {
                    if (errorDetailList[i].Contains("."))
                        Assert.That(errorDetailList[i], Is.EqualTo(ERROR_INVALID_ASSOCIATED_ADDRESS + "."),
                        "Expecting [" + ERROR_INVALID_ASSOCIATED_ADDRESS + "." + "], but found [" + errorDetailList[i] + "]");
                    else Assert.That(errorDetailList[i], Is.EqualTo(ERROR_INVALID_ASSOCIATED_ADDRESS),
                        "Expecting [" + ERROR_INVALID_ASSOCIATED_ADDRESS + "], but found [" + errorDetailList[i] + "]");
                }
                else
                    Assert.True(errorDetailList[i].Contains("three minutes") || errorDetailList[i].Contains("occurrence address") || errorDetailList[i].Contains("associated"), "The text does not contain the expected errors.");

            }

            if (!error.Contains(ERROR_BASE))
                Assert.That(error.Substring(0, ERROR_BASE.Length), Is.EqualTo(ERROR_BASE),
                    "Expecting [" + ERROR_BASE + "], but found [" + error.Substring(0, ERROR_BASE.Length) + "]");

            //if (!error.Contains(ERROR_SHORTER_THAN_3_MINUTES))
            //    Assert.That(error.Substring(0, ERROR_SHORTER_THAN_3_MINUTES.Length), Is.EqualTo(ERROR_SHORTER_THAN_3_MINUTES),
            //        "Expecting [" + ERROR_SHORTER_THAN_3_MINUTES + "], but found [" + error.Substring(0, ERROR_SHORTER_THAN_3_MINUTES.Length) + "]");
            //
            //if (!error.Contains(ERROR_INVALID_ASSOCIATED_ADDRESS))
            //    Assert.That(error.Substring(0, ERROR_INVALID_ASSOCIATED_ADDRESS.Length), Is.EqualTo(ERROR_INVALID_ASSOCIATED_ADDRESS),
            //        "Expecting [" + ERROR_INVALID_ASSOCIATED_ADDRESS + "], but found [" + error.Substring(0, ERROR_INVALID_ASSOCIATED_ADDRESS.Length) + "]");
            //
            //if (!error.Contains(ERROR_INVALID_OCCURRENCE_ADDRESS))
            //    Assert.That(error.Substring(0, ERROR_INVALID_OCCURRENCE_ADDRESS.Length), Is.EqualTo(ERROR_INVALID_OCCURRENCE_ADDRESS),
            //        "Expecting [" + ERROR_INVALID_OCCURRENCE_ADDRESS + "], but found [" + error.Substring(0, ERROR_INVALID_OCCURRENCE_ADDRESS.Length) + "]");

        }

        [Test]
        [Category("Required Field Provided Invalid Input - Error Label Displayed")]

        public void FailedSubmission_InFrontOf_NoSchool_TimeInFutureAndShorterThan3Minutes()
        {
            /*QUALIFYING CRITERIA*/
            ClickNo();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false, false, SLEEP_TIMER);

            int year = DateTime.Now.Year + 1;

            /*OCCURRENCE*/

            Occurrence_FromControl.SendKeysWithDelay(
                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.AddYears(1).Year, DateTime.Now.Hour, DateTime.Now.AddMinutes(-1).Minute, DateTime.Now.Second), SLEEP_TIMER); //Time in a year (1 minutes ago)

            Occurrence_ToControl.SendKeysWithDelay(
                                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.AddYears(1).Year, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second), SLEEP_TIMER); // Current Time

            Fill_OccurrenceAddress(2, 3, false, SLEEP_TIMER);

            Occurrence_VehicleInformation();

            Fill_InFrontOfSchool(false, SLEEP_TIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ComplaintInfo_ClickNext();

            var invalidTime = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 10).FindElement(By.TagName("span"));
            Assert.IsNotNull(invalidTime);

            string error = invalidTime.Text.Trim();
            Console.WriteLine(error);


            string errorDetail = error.Substring(ERROR_BASE.Length);
            string[] errorDetailList = errorDetail.Split(". ", StringSplitOptions.None);
            for(int i = 0; i < errorDetailList.Length; i++)
            {
                Console.WriteLine(errorDetailList[i]);
                if (errorDetailList[i].Contains("three minutes"))
                {
                    if (errorDetailList[i].Contains("."))
                        Assert.That(errorDetailList[i], Is.EqualTo(ERROR_SHORTER_THAN_3_MINUTES + "."),
                        "Expecting [" + ERROR_SHORTER_THAN_3_MINUTES + "." + "], but found [" + errorDetailList[i] + "]");
                    else Assert.That(errorDetailList[i], Is.EqualTo(ERROR_SHORTER_THAN_3_MINUTES),
                        "Expecting [" + ERROR_SHORTER_THAN_3_MINUTES + "], but found [" + errorDetailList[i] + "]");
                }

                else if (errorDetailList[i].Contains("cannot be later than"))
                {
                    if (errorDetailList[i].Contains("."))
                        Assert.That(errorDetailList[i], Is.EqualTo(ERROR_TO_AND_FROM_IN_FUTURE + "."),
                        "Expecting [" + ERROR_TO_AND_FROM_IN_FUTURE + "." + "], but found [" + errorDetailList[i] + "]");
                    else Assert.That(errorDetailList[i], Is.EqualTo(ERROR_TO_AND_FROM_IN_FUTURE),
                        "Expecting [" + ERROR_TO_AND_FROM_IN_FUTURE + "], but found [" + errorDetailList[i] + "]");
                }
                else
                    Assert.True(errorDetailList[i].Contains("three minutes") || errorDetailList[i].Contains("cannot be later than the current"), "The text does not contain the expected errors.");
            }


            if (!error.Contains(ERROR_BASE))
                Assert.That(error.Substring(0, ERROR_BASE.Length), Is.EqualTo(ERROR_BASE),
                    "Expecting [" + ERROR_BASE + "], but found [" + error.Substring(0, ERROR_BASE.Length) + "]");

            //if (!error.Contains(ERROR_SHORTER_THAN_3_MINUTES))
            //    Assert.That(error.Substring(0, ERROR_SHORTER_THAN_3_MINUTES.Length), Is.EqualTo(ERROR_SHORTER_THAN_3_MINUTES),
            //        "Expecting [" + ERROR_SHORTER_THAN_3_MINUTES + "], but found [" + error.Substring(0, ERROR_SHORTER_THAN_3_MINUTES.Length) + "]");
            //
            //if (!error.Contains(ERROR_TO_AND_FROM_IN_FUTURE))
            //    Assert.That(error.Substring(0, ERROR_TO_AND_FROM_IN_FUTURE.Length), Is.EqualTo(ERROR_TO_AND_FROM_IN_FUTURE),
            //        "Expecting [" + ERROR_TO_AND_FROM_IN_FUTURE + "], but found [" + error.Substring(0, ERROR_TO_AND_FROM_IN_FUTURE.Length) + "]");

        }

        [Test]
        [Category("Required Field Provided Invalid Input - Error Label Displayed")]

        public void FailedSubmission_InFrontOf_NoSchool_TimeInFutureAndShorterThan3Minutes_InvalidOccurrenceAddr()
        {
            /*QUALIFYING CRITERIA*/
            ClickNo();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false, false, SLEEP_TIMER);

            int year = DateTime.Now.Year + 1;

            /*OCCURRENCE*/

            Occurrence_FromControl.SendKeysWithDelay(
                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.AddYears(1).Year, DateTime.Now.Hour, DateTime.Now.AddMinutes(-1).Minute, DateTime.Now.Second), SLEEP_TIMER); //Time in a year (1 minutes ago)

            Occurrence_ToControl.SendKeysWithDelay(
                                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.AddYears(1).Year, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second), SLEEP_TIMER); // Current Time

            Fill_OccurrenceAddress(2, 3, true, SLEEP_TIMER);

            Occurrence_VehicleInformation();

            Fill_InFrontOfSchool(false, SLEEP_TIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ComplaintInfo_ClickNext();

            var invalidTime = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 10).FindElement(By.TagName("span"));
            Assert.IsNotNull(invalidTime);

            string error = invalidTime.Text.Trim();
            Console.WriteLine(error);


            string errorDetail = error.Substring(ERROR_BASE.Length);
            string[] errorDetailList = errorDetail.Split(". ", StringSplitOptions.None);
            for(int i = 0; i < errorDetailList.Length; i++)
            {
                Console.WriteLine(errorDetailList[i]);
                if (errorDetailList[i].Contains("three minutes"))
                {
                    if (errorDetailList[i].Contains("."))
                        Assert.That(errorDetailList[i], Is.EqualTo(ERROR_SHORTER_THAN_3_MINUTES + "."),
                        "Expecting [" + ERROR_SHORTER_THAN_3_MINUTES + "." + "], but found [" + errorDetailList[i] + "]");
                    else Assert.That(errorDetailList[i], Is.EqualTo(ERROR_SHORTER_THAN_3_MINUTES),
                        "Expecting [" + ERROR_SHORTER_THAN_3_MINUTES + "], but found [" + errorDetailList[i] + "]");
                }

                else if (errorDetailList[i].Contains("cannot be later than"))
                {
                    if (errorDetailList[i].Contains("."))
                        Assert.That(errorDetailList[i], Is.EqualTo(ERROR_TO_AND_FROM_IN_FUTURE + "."),
                        "Expecting [" + ERROR_TO_AND_FROM_IN_FUTURE + "." + "], but found [" + errorDetailList[i] + "]");
                    else Assert.That(errorDetailList[i], Is.EqualTo(ERROR_TO_AND_FROM_IN_FUTURE),
                        "Expecting [" + ERROR_TO_AND_FROM_IN_FUTURE + "], but found [" + errorDetailList[i] + "]");
                }

                else if (errorDetailList[i].Contains("occurrence address"))
                {
                    if (errorDetailList[i].Contains("."))
                        Assert.That(errorDetailList[i], Is.EqualTo(ERROR_INVALID_OCCURRENCE_ADDRESS + "."),
                        "Expecting [" + ERROR_INVALID_OCCURRENCE_ADDRESS + "." + "], but found [" + errorDetailList[i] + "]");
                    else Assert.That(errorDetailList[i], Is.EqualTo(ERROR_INVALID_OCCURRENCE_ADDRESS),
                        "Expecting [" + ERROR_INVALID_OCCURRENCE_ADDRESS + "], but found [" + errorDetailList[i] + "]");
                }
                else
                    Assert.True(errorDetailList[i].Contains("three minutes") || errorDetailList[i].Contains("cannot be later than the current") || errorDetailList[i].Contains("occurrence address"), "The text does not contain the expected errors.");

            }

            if (!error.Contains(ERROR_BASE))
                Assert.That(error.Substring(0, ERROR_BASE.Length), Is.EqualTo(ERROR_BASE),
                    "Expecting [" + ERROR_BASE + "], but found [" + error.Substring(0, ERROR_BASE.Length) + "]");

            //if (!error.Contains(ERROR_SHORTER_THAN_3_MINUTES))
            //    Assert.That(error.Substring(0, ERROR_SHORTER_THAN_3_MINUTES.Length), Is.EqualTo(ERROR_SHORTER_THAN_3_MINUTES),
            //        "Expecting [" + ERROR_SHORTER_THAN_3_MINUTES + "], but found [" + error.Substring(0, ERROR_SHORTER_THAN_3_MINUTES.Length) + "]");
            //
            //if (!error.Contains(ERROR_TO_AND_FROM_IN_FUTURE))
            //    Assert.That(error.Substring(0, ERROR_TO_AND_FROM_IN_FUTURE.Length), Is.EqualTo(ERROR_TO_AND_FROM_IN_FUTURE),
            //        "Expecting [" + ERROR_TO_AND_FROM_IN_FUTURE + "], but found [" + error.Substring(0, ERROR_TO_AND_FROM_IN_FUTURE.Length) + "]");
            //
            //if (!error.Contains(ERROR_INVALID_OCCURRENCE_ADDRESS))
            //    Assert.That(error.Substring(0, ERROR_INVALID_OCCURRENCE_ADDRESS.Length), Is.EqualTo(ERROR_INVALID_OCCURRENCE_ADDRESS),
            //        "Expecting [" + ERROR_INVALID_OCCURRENCE_ADDRESS + "], but found [" + error.Substring(0, ERROR_INVALID_OCCURRENCE_ADDRESS.Length) + "]");


        }

        [Test]
        [Category("Required Field Provided Invalid Input - Error Label Displayed")]

        public void FailedSubmission_InFrontOf_NoSchool_TimeInFutureAndShorterThan3Minutes_InvalidAssociatedAddr()
        {
            /*QUALIFYING CRITERIA*/
            ClickNo();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false, true, SLEEP_TIMER);

            int year = DateTime.Now.Year + 1;

            /*OCCURRENCE*/

            Occurrence_FromControl.SendKeysWithDelay(
                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.AddYears(1).Year, DateTime.Now.Hour, DateTime.Now.AddMinutes(-1).Minute, DateTime.Now.Second), SLEEP_TIMER); //Time in a year (1 minutes ago)

            Occurrence_ToControl.SendKeysWithDelay(
                                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.AddYears(1).Year, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second), SLEEP_TIMER); // Current Time


            Fill_OccurrenceAddress(2, 3, false, SLEEP_TIMER);

            Occurrence_VehicleInformation();

            Fill_InFrontOfSchool(false, SLEEP_TIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ComplaintInfo_ClickNext();

            var invalidTime = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 10).FindElement(By.TagName("span"));
            Assert.IsNotNull(invalidTime);

            string error = invalidTime.Text.Trim();
            Console.WriteLine(error);


            string errorDetail = error.Substring(ERROR_BASE.Length);
            string[] errorDetailList = errorDetail.Split(". ", StringSplitOptions.None);
            for(int i = 0; i < errorDetailList.Length; i++)
            {
                Console.WriteLine(errorDetailList[i]);
                if (errorDetailList[i].Contains("three minutes"))
                {
                    if (errorDetailList[i].Contains("."))
                        Assert.That(errorDetailList[i], Is.EqualTo(ERROR_SHORTER_THAN_3_MINUTES + "."),
                        "Expecting [" + ERROR_SHORTER_THAN_3_MINUTES + "." + "], but found [" + errorDetailList[i] + "]");
                    else Assert.That(errorDetailList[i], Is.EqualTo(ERROR_SHORTER_THAN_3_MINUTES),
                        "Expecting [" + ERROR_SHORTER_THAN_3_MINUTES + "], but found [" + errorDetailList[i] + "]");
                }

                else if (errorDetailList[i].Contains("cannot be later than"))
                {
                    if (errorDetailList[i].Contains("."))
                        Assert.That(errorDetailList[i], Is.EqualTo(ERROR_TO_AND_FROM_IN_FUTURE + "."),
                        "Expecting [" + ERROR_TO_AND_FROM_IN_FUTURE + "." + "], but found [" + errorDetailList[i] + "]");
                    else Assert.That(errorDetailList[i], Is.EqualTo(ERROR_TO_AND_FROM_IN_FUTURE),
                        "Expecting [" + ERROR_TO_AND_FROM_IN_FUTURE + "], but found [" + errorDetailList[i] + "]");
                }

                else if (errorDetailList[i].Contains("associated"))
                {
                    if (errorDetailList[i].Contains("."))
                        Assert.That(errorDetailList[i], Is.EqualTo(ERROR_INVALID_ASSOCIATED_ADDRESS + "."),
                        "Expecting [" + ERROR_INVALID_ASSOCIATED_ADDRESS + "." + "], but found [" + errorDetailList[i] + "]");
                    else Assert.That(errorDetailList[i], Is.EqualTo(ERROR_INVALID_ASSOCIATED_ADDRESS),
                        "Expecting [" + ERROR_INVALID_ASSOCIATED_ADDRESS + "], but found [" + errorDetailList[i] + "]");
                }
                else
                    Assert.True(errorDetailList[i].Contains("three minutes") || errorDetailList[i].Contains("cannot be later than the current") || errorDetailList[i].Contains("associated"), "The text does not contain the expected errors.");

            }

            if (!error.Contains(ERROR_BASE))
                Assert.That(error.Substring(0, ERROR_BASE.Length), Is.EqualTo(ERROR_BASE),
                    "Expecting [" + ERROR_BASE + "], but found [" + error.Substring(0, ERROR_BASE.Length) + "]");

            //if (!error.Contains(ERROR_SHORTER_THAN_3_MINUTES))
            //    Assert.That(error.Substring(0, ERROR_SHORTER_THAN_3_MINUTES.Length), Is.EqualTo(ERROR_SHORTER_THAN_3_MINUTES),
            //        "Expecting [" + ERROR_SHORTER_THAN_3_MINUTES + "], but found [" + error.Substring(0, ERROR_SHORTER_THAN_3_MINUTES.Length) + "]");
            //
            //if (!error.Contains(ERROR_TO_AND_FROM_IN_FUTURE))
            //    Assert.That(error.Substring(0, ERROR_TO_AND_FROM_IN_FUTURE.Length), Is.EqualTo(ERROR_TO_AND_FROM_IN_FUTURE),
            //        "Expecting [" + ERROR_TO_AND_FROM_IN_FUTURE + "], but found [" + error.Substring(0, ERROR_TO_AND_FROM_IN_FUTURE.Length) + "]");
            //
            //if (!error.Contains(ERROR_INVALID_ASSOCIATED_ADDRESS))
            //    Assert.That(error.Substring(0, ERROR_INVALID_ASSOCIATED_ADDRESS.Length), Is.EqualTo(ERROR_INVALID_ASSOCIATED_ADDRESS),
            //        "Expecting [" + ERROR_INVALID_ASSOCIATED_ADDRESS + "], but found [" + error.Substring(0, ERROR_INVALID_ASSOCIATED_ADDRESS.Length) + "]");



        }

        [Test]
        [Category("Required Field Provided Invalid Input - Error Label Displayed")]

        public void FailedSubmission_InFrontOf_NoSchool_TimeInFutureAndShorterThan3Minutes_InvalidOccurrenceAndAssociatedAddr()
        {
            /*QUALIFYING CRITERIA*/
            ClickNo();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false, true, SLEEP_TIMER);
            int year = DateTime.Now.Year + 1;
            /*OCCURRENCE*/

            Occurrence_FromControl.SendKeysWithDelay(
                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.AddYears(1).Year, DateTime.Now.Hour, DateTime.Now.AddMinutes(-1).Minute, DateTime.Now.Second), SLEEP_TIMER); //Time in a year (1 minutes ago)

            Occurrence_ToControl.SendKeysWithDelay(
                                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.AddYears(1).Year, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second), SLEEP_TIMER); // Current Time

            Fill_OccurrenceAddress(2, 3, true, SLEEP_TIMER);

            Occurrence_VehicleInformation();

            Fill_InFrontOfSchool(false, SLEEP_TIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ComplaintInfo_ClickNext();

            var invalidTime = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 10).FindElement(By.TagName("span"));
            Assert.IsNotNull(invalidTime);

            string error = invalidTime.Text.Trim();
            Console.WriteLine(error);


            string errorDetail = error.Substring(ERROR_BASE.Length);
            string[] errorDetailList = errorDetail.Split(". ", StringSplitOptions.None);
            for(int i = 0; i < errorDetailList.Length; i++)
            {
                Console.WriteLine(errorDetailList[i]);
                if (errorDetailList[i].Contains("three minutes"))
                {
                    if (errorDetailList[i].Contains("."))
                        Assert.That(errorDetailList[i], Is.EqualTo(ERROR_SHORTER_THAN_3_MINUTES + "."),
                        "Expecting [" + ERROR_SHORTER_THAN_3_MINUTES + "." + "], but found [" + errorDetailList[i] + "]");
                    else Assert.That(errorDetailList[i], Is.EqualTo(ERROR_SHORTER_THAN_3_MINUTES),
                        "Expecting [" + ERROR_SHORTER_THAN_3_MINUTES + "], but found [" + errorDetailList[i] + "]");
                }

                else if (errorDetailList[i].Contains("cannot be later than"))
                {
                    if (errorDetailList[i].Contains("."))
                        Assert.That(errorDetailList[i], Is.EqualTo(ERROR_TO_AND_FROM_IN_FUTURE + "."),
                        "Expecting [" + ERROR_TO_AND_FROM_IN_FUTURE + "." + "], but found [" + errorDetailList[i] + "]");
                    else Assert.That(errorDetailList[i], Is.EqualTo(ERROR_TO_AND_FROM_IN_FUTURE),
                        "Expecting [" + ERROR_TO_AND_FROM_IN_FUTURE + "], but found [" + errorDetailList[i] + "]");
                }

                else if (errorDetailList[i].Contains("occurrence address"))
                {
                    if (errorDetailList[i].Contains("."))
                        Assert.That(errorDetailList[i], Is.EqualTo(ERROR_INVALID_OCCURRENCE_ADDRESS + "."),
                        "Expecting [" + ERROR_INVALID_OCCURRENCE_ADDRESS + "." + "], but found [" + errorDetailList[i] + "]");
                    else Assert.That(errorDetailList[i], Is.EqualTo(ERROR_INVALID_OCCURRENCE_ADDRESS),
                        "Expecting [" + ERROR_INVALID_OCCURRENCE_ADDRESS + "], but found [" + errorDetailList[i] + "]");
                }
                else if (errorDetailList[i].Contains("associated"))
                {
                    if (errorDetailList[i].Contains("."))
                        Assert.That(errorDetailList[i], Is.EqualTo(ERROR_INVALID_ASSOCIATED_ADDRESS + "."),
                        "Expecting [" + ERROR_INVALID_ASSOCIATED_ADDRESS + "." + "], but found [" + errorDetailList[i] + "]");
                    else Assert.That(errorDetailList[i], Is.EqualTo(ERROR_INVALID_ASSOCIATED_ADDRESS),
                        "Expecting [" + ERROR_INVALID_ASSOCIATED_ADDRESS + "], but found [" + errorDetailList[i] + "]");
                }
                else
                    Assert.True(errorDetailList[i].Contains("three minutes") || errorDetailList[i].Contains("cannot be later than the current") || errorDetailList[i].Contains("occurrence address") || errorDetailList[i].Contains("associated"), "The text does not contain the expected errors.");

            }

            if (!error.Contains(ERROR_BASE))
                Assert.That(error.Substring(0, ERROR_BASE.Length), Is.EqualTo(ERROR_BASE),
                    "Expecting [" + ERROR_BASE + "], but found [" + error.Substring(0, ERROR_BASE.Length) + "]");

            //if (!error.Contains(ERROR_SHORTER_THAN_3_MINUTES))
            //    Assert.That(error.Substring(0, ERROR_SHORTER_THAN_3_MINUTES.Length), Is.EqualTo(ERROR_SHORTER_THAN_3_MINUTES),
            //        "Expecting [" + ERROR_SHORTER_THAN_3_MINUTES + "], but found [" + error.Substring(0, ERROR_SHORTER_THAN_3_MINUTES.Length) + "]");
            //
            //if (!error.Contains(ERROR_TO_AND_FROM_IN_FUTURE))
            //    Assert.That(error.Substring(0, ERROR_TO_AND_FROM_IN_FUTURE.Length), Is.EqualTo(ERROR_TO_AND_FROM_IN_FUTURE),
            //        "Expecting [" + ERROR_TO_AND_FROM_IN_FUTURE + "], but found [" + error.Substring(0, ERROR_TO_AND_FROM_IN_FUTURE.Length) + "]");
            //
            //if (!error.Contains(ERROR_INVALID_ASSOCIATED_ADDRESS))
            //    Assert.That(error.Substring(0, ERROR_INVALID_ASSOCIATED_ADDRESS.Length), Is.EqualTo(ERROR_INVALID_ASSOCIATED_ADDRESS),
            //        "Expecting [" + ERROR_INVALID_ASSOCIATED_ADDRESS + "], but found [" + error.Substring(0, ERROR_INVALID_ASSOCIATED_ADDRESS.Length) + "]");
            //
            //if (!error.Contains(ERROR_INVALID_OCCURRENCE_ADDRESS))
            //    Assert.That(error.Substring(0, ERROR_INVALID_OCCURRENCE_ADDRESS.Length), Is.EqualTo(ERROR_INVALID_OCCURRENCE_ADDRESS),
            //        "Expecting [" + ERROR_INVALID_OCCURRENCE_ADDRESS + "], but found [" + error.Substring(0, ERROR_INVALID_OCCURRENCE_ADDRESS.Length) + "]");


        }

        [Test]
        [Category("Required Field Provided Invalid Input - Error Label Displayed")]

        public void FailedSubmission_InFrontOf_NoSchool_TimeInFuture()
        {
            /*QUALIFYING CRITERIA*/
            ClickNo();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false, false, SLEEP_TIMER);

            int year = DateTime.Now.Year + 1;

            /*OCCURRENCE*/

            Occurrence_FromControl.SendKeysWithDelay(
                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.AddYears(1).Year, DateTime.Now.Hour, DateTime.Now.AddMinutes(-3).Minute, DateTime.Now.Second), SLEEP_TIMER); //Time in a year (3 minutes ago)

            Occurrence_ToControl.SendKeysWithDelay(
                                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.AddYears(1).Year, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second), SLEEP_TIMER); // Current Time

            Fill_OccurrenceAddress(2, 3, false, SLEEP_TIMER);

            Occurrence_VehicleInformation();

            Fill_InFrontOfSchool(false, SLEEP_TIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ComplaintInfo_ClickNext();

            var invalidTime = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 10).FindElement(By.TagName("span"));
            Assert.IsNotNull(invalidTime);

            string error = invalidTime.Text.Trim();
            Console.WriteLine(error);

            string errorDetail = error.Substring(ERROR_BASE.Length);
            string[] errorDetailList = errorDetail.Split(". ", StringSplitOptions.None);
            Console.WriteLine(errorDetailList.Length);
            for(int i = 0; i < errorDetailList.Length; i++)
            {
                Console.WriteLine(errorDetailList[i]);
                Console.WriteLine(errorDetailList[i].Contains("cannot be later than the current"));
                if (errorDetailList[i].Contains("cannot be later than the current")) 
                {
                    //if (errorDetailList[i].Contains(".") s += ".";
                    if (errorDetailList[i].Contains("."))
                        Assert.That(errorDetailList[i], Is.EqualTo(ERROR_TO_AND_FROM_IN_FUTURE + "."),
                        "Expecting [" + ERROR_TO_AND_FROM_IN_FUTURE + "." + "], but found [" + errorDetailList[i] + "]");
                    else if (errorDetailList[i].Contains("cannot be later than"))
                    {
                        if (errorDetailList[i].Contains("."))
                            Assert.That(errorDetailList[i], Is.EqualTo(ERROR_TO_AND_FROM_IN_FUTURE + "."),
                            "Expecting [" + ERROR_TO_AND_FROM_IN_FUTURE + "." + "], but found [" + errorDetailList[i] + "]");
                        else Assert.That(errorDetailList[i], Is.EqualTo(ERROR_TO_AND_FROM_IN_FUTURE),
                            "Expecting [" + ERROR_TO_AND_FROM_IN_FUTURE + "], but found [" + errorDetailList[i] + "]");
                    }
                }

                else
                    Assert.True(errorDetailList[i].Contains("cannot be later than the current"), "The text does not contain the expected errors.");

            }

            if (!error.Contains(ERROR_BASE))
                Assert.That(error.Substring(0, ERROR_BASE.Length), Is.EqualTo(ERROR_BASE),
                    "Expecting [" + ERROR_BASE + "], but found [" + error.Substring(0, ERROR_BASE.Length) + "]");

            //if (!error.Contains(ERROR_TO_AND_FROM_IN_FUTURE))
            //    Assert.That(error.Substring(0, ERROR_TO_AND_FROM_IN_FUTURE.Length), Is.EqualTo(ERROR_TO_AND_FROM_IN_FUTURE),
            //        "Expecting [" + ERROR_TO_AND_FROM_IN_FUTURE + "], but found [" + error.Substring(0, ERROR_TO_AND_FROM_IN_FUTURE.Length) + "]");

        }

        [Test]
        [Category("Required Field Provided Invalid Input - Error Label Displayed")]

        public void FailedSubmission_InFrontOf_NoSchool_TimeInFuture_InvalidOccurrenceAddr()
        {
            /*QUALIFYING CRITERIA*/
            ClickNo();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false, false, SLEEP_TIMER);

            int year = DateTime.Now.Year + 1;

            /*OCCURRENCE*/
            Occurrence_FromControl.SendKeysWithDelay(
                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.AddYears(1).Year, DateTime.Now.Hour, DateTime.Now.AddMinutes(-3).Minute, DateTime.Now.Second), SLEEP_TIMER); //Time in a year (3 minutes ago)

            Occurrence_ToControl.SendKeysWithDelay(
                                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.AddYears(1).Year, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second), SLEEP_TIMER); // Current Time

            Fill_OccurrenceAddress(2, 3, true, SLEEP_TIMER);

            Occurrence_VehicleInformation();

            Fill_InFrontOfSchool(false, SLEEP_TIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ComplaintInfo_ClickNext();

            var invalidTime = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 10).FindElement(By.TagName("span"));
            Assert.IsNotNull(invalidTime);

            string error = invalidTime.Text.Trim();
            Console.WriteLine(error);

            string errorDetail = error.Substring(ERROR_BASE.Length);
            string[] errorDetailList = errorDetail.Split(". ", StringSplitOptions.None);
            for(int i = 0; i < errorDetailList.Length; i++)
            {
                Console.WriteLine(errorDetailList[i]);

                if (errorDetailList[i].Contains("cannot be later than the current"))
                {
                    if (errorDetailList[i].Contains("."))
                        Assert.That(errorDetailList[i], Is.EqualTo(ERROR_TO_AND_FROM_IN_FUTURE + "."),
                        "Expecting [" + ERROR_TO_AND_FROM_IN_FUTURE + "." + "], but found [" + errorDetailList[i] + "]");
                    else if (errorDetailList[i].Contains("cannot be later than"))
                    {
                        if (errorDetailList[i].Contains("."))
                            Assert.That(errorDetailList[i], Is.EqualTo(ERROR_TO_AND_FROM_IN_FUTURE + "."),
                            "Expecting [" + ERROR_TO_AND_FROM_IN_FUTURE + "." + "], but found [" + errorDetailList[i] + "]");
                        else Assert.That(errorDetailList[i], Is.EqualTo(ERROR_TO_AND_FROM_IN_FUTURE),
                            "Expecting [" + ERROR_TO_AND_FROM_IN_FUTURE + "], but found [" + errorDetailList[i] + "]");
                    }
                }


                else if (errorDetailList[i].Contains("occurrence address"))
                {
                    if (errorDetailList[i].Contains("."))
                        Assert.That(errorDetailList[i], Is.EqualTo(ERROR_INVALID_OCCURRENCE_ADDRESS + "."),
                        "Expecting [" + ERROR_INVALID_OCCURRENCE_ADDRESS + "." + "], but found [" + errorDetailList[i] + "]");
                    else Assert.That(errorDetailList[i], Is.EqualTo(ERROR_INVALID_OCCURRENCE_ADDRESS),
                        "Expecting [" + ERROR_INVALID_OCCURRENCE_ADDRESS + "], but found [" + errorDetailList[i] + "]");
                }
                    
                else
                    Assert.True(errorDetailList[i].Contains("cannot be later than the current") || errorDetailList[i].Contains("occurrence address"), "The text does not contain the expected errors.");

            }

            if (!error.Contains(ERROR_BASE))
                Assert.That(error.Substring(0, ERROR_BASE.Length), Is.EqualTo(ERROR_BASE),
                    "Expecting [" + ERROR_BASE + "], but found [" + error.Substring(0, ERROR_BASE.Length) + "]");

            //if (!error.Contains(ERROR_TO_AND_FROM_IN_FUTURE))
            //    Assert.That(error.Substring(0, ERROR_TO_AND_FROM_IN_FUTURE.Length), Is.EqualTo(ERROR_TO_AND_FROM_IN_FUTURE),
            //        "Expecting [" + ERROR_TO_AND_FROM_IN_FUTURE + "], but found [" + error.Substring(0, ERROR_TO_AND_FROM_IN_FUTURE.Length) + "]");
            //
            //if (!error.Contains(ERROR_INVALID_OCCURRENCE_ADDRESS))
            //    Assert.That(error.Substring(0, ERROR_INVALID_OCCURRENCE_ADDRESS.Length), Is.EqualTo(ERROR_INVALID_OCCURRENCE_ADDRESS),
            //        "Expecting [" + ERROR_INVALID_OCCURRENCE_ADDRESS + "], but found [" + error.Substring(0, ERROR_INVALID_OCCURRENCE_ADDRESS.Length) + "]");


        }

        [Test]
        [Category("Required Field Provided Invalid Input - Error Label Displayed")]

        public void FailedSubmission_InFrontOf_NoSchool_TimeInFuture_InvalidAssociatedAddr()
        {
            /*QUALIFYING CRITERIA*/
            ClickNo();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false, true, SLEEP_TIMER);

            int year = DateTime.Now.Year + 1;

            /*OCCURRENCE*/

            Occurrence_FromControl.SendKeysWithDelay(
                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.AddYears(1).Year, DateTime.Now.Hour, DateTime.Now.AddMinutes(-3).Minute, DateTime.Now.Second), SLEEP_TIMER); //Time in a year (3 minutes ago)

            Occurrence_ToControl.SendKeysWithDelay(
                                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.AddYears(1).Year, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second), SLEEP_TIMER); // Current Time

            Fill_OccurrenceAddress(2, 3, false, SLEEP_TIMER);

            Occurrence_VehicleInformation();

            Fill_InFrontOfSchool(false, SLEEP_TIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ComplaintInfo_ClickNext();

            var invalidTime = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 10).FindElement(By.TagName("span"));
            Assert.IsNotNull(invalidTime);

            string error = invalidTime.Text.Trim();
            Console.WriteLine(error);


            string errorDetail = error.Substring(ERROR_BASE.Length);
            string[] errorDetailList = errorDetail.Split(". ", StringSplitOptions.None);
            for(int i = 0; i < errorDetailList.Length; i++)
            {
                Console.WriteLine(i + ": " + errorDetailList[i]);

                if (errorDetailList[i].Contains("cannot be later than"))
                {
                    if (errorDetailList[i].Contains("."))
                        Assert.That(errorDetailList[i], Is.EqualTo(ERROR_TO_AND_FROM_IN_FUTURE + "."),
                        "Expecting [" + ERROR_TO_AND_FROM_IN_FUTURE + "." + "], but found [" + errorDetailList[i] + "]");
                    else Assert.That(errorDetailList[i], Is.EqualTo(ERROR_TO_AND_FROM_IN_FUTURE),
                        "Expecting [" + ERROR_TO_AND_FROM_IN_FUTURE + "], but found [" + errorDetailList[i] + "]");
                }

                else if (errorDetailList[i].Contains("associated"))
                {
                    if (errorDetailList[i].Contains("."))
                        Assert.That(errorDetailList[i], Is.EqualTo(ERROR_INVALID_ASSOCIATED_ADDRESS + "."),
                        "Expecting [" + ERROR_INVALID_ASSOCIATED_ADDRESS + "." + "], but found [" + errorDetailList[i] + "]");
                    else Assert.That(errorDetailList[i], Is.EqualTo(ERROR_INVALID_ASSOCIATED_ADDRESS),
                        "Expecting [" + ERROR_INVALID_ASSOCIATED_ADDRESS + "], but found [" + errorDetailList[i] + "]");
                }
                else
                    Assert.True(errorDetailList[i].Contains("cannot be later than the current") || errorDetailList[i].Contains("associated"), "The text does not contain the expected errors.");

            }

            if (!error.Contains(ERROR_BASE))
                Assert.That(error.Substring(0, ERROR_BASE.Length), Is.EqualTo(ERROR_BASE),
                    "Expecting [" + ERROR_BASE + "], but found [" + error.Substring(0, ERROR_BASE.Length) + "]");
            
        }

        [Test]
        [Category("Required Field Provided Invalid Input - Error Label Displayed")]

        public void FailedSubmission_InFrontOf_NoSchool_TimeInFuture_InvalidOccurrenceAndAssociatedAddr()
        {
            /*QUALIFYING CRITERIA*/
            ClickNo();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false, true, SLEEP_TIMER);

            int year = DateTime.Now.Year + 1;

            /*OCCURRENCE*/

            Occurrence_FromControl.SendKeysWithDelay(
                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.AddYears(1).Year, DateTime.Now.Hour, DateTime.Now.AddMinutes(-3).Minute, DateTime.Now.Second), SLEEP_TIMER); //Time in a year (3 minutes ago)

            Occurrence_ToControl.SendKeysWithDelay(
                                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.AddYears(1).Year, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second), SLEEP_TIMER); // Current Time

            Fill_OccurrenceAddress(2, 3, true, SLEEP_TIMER);

            Occurrence_VehicleInformation();

            Fill_InFrontOfSchool(false, SLEEP_TIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ComplaintInfo_ClickNext();

            var invalidTime = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 10).FindElement(By.TagName("span"));
            Assert.IsNotNull(invalidTime);

            string error = invalidTime.Text.Trim();
            Console.WriteLine(error);

            string errorDetail = error.Substring(ERROR_BASE.Length);
            string[] errorDetailList = errorDetail.Split(". ", StringSplitOptions.None);
            for(int i = 0; i < errorDetailList.Length; i++)
            {
                Console.WriteLine(errorDetailList[i]);

                if (errorDetailList[i].Contains("cannot be later than"))
                {
                    if (errorDetailList[i].Contains("."))
                        Assert.That(errorDetailList[i], Is.EqualTo(ERROR_TO_AND_FROM_IN_FUTURE + "."),
                        "Expecting [" + ERROR_TO_AND_FROM_IN_FUTURE + "." + "], but found [" + errorDetailList[i] + "]");
                    else Assert.That(errorDetailList[i], Is.EqualTo(ERROR_TO_AND_FROM_IN_FUTURE),
                        "Expecting [" + ERROR_TO_AND_FROM_IN_FUTURE + "], but found [" + errorDetailList[i] + "]");
                }

                else if (errorDetailList[i].Contains("occurrence address"))
                {
                    if (errorDetailList[i].Contains("."))
                        Assert.That(errorDetailList[i], Is.EqualTo(ERROR_INVALID_OCCURRENCE_ADDRESS + "."),
                        "Expecting [" + ERROR_INVALID_OCCURRENCE_ADDRESS + "." + "], but found [" + errorDetailList[i] + "]");
                    else Assert.That(errorDetailList[i], Is.EqualTo(ERROR_INVALID_OCCURRENCE_ADDRESS),
                        "Expecting [" + ERROR_INVALID_OCCURRENCE_ADDRESS + "], but found [" + errorDetailList[i] + "]");
                }
                else if (errorDetailList[i].Contains("associated"))
                {
                    if (errorDetailList[i].Contains("."))
                        Assert.That(errorDetailList[i], Is.EqualTo(ERROR_INVALID_ASSOCIATED_ADDRESS + "."),
                        "Expecting [" + ERROR_INVALID_ASSOCIATED_ADDRESS + "." + "], but found [" + errorDetailList[i] + "]");
                    else Assert.That(errorDetailList[i], Is.EqualTo(ERROR_INVALID_ASSOCIATED_ADDRESS),
                        "Expecting [" + ERROR_INVALID_ASSOCIATED_ADDRESS + "], but found [" + errorDetailList[i] + "]");
                }
                else
                    Assert.True(errorDetailList[i].Contains("cannot be later than the current") || errorDetailList[i].Contains("occurrence address") || errorDetailList[i].Contains("associated"), "The text does not contain the expected errors.");

            }

            if (!error.Contains(ERROR_BASE))
                Assert.That(error.Substring(0, ERROR_BASE.Length), Is.EqualTo(ERROR_BASE),
                    "Expecting [" + ERROR_BASE + "], but found [" + error.Substring(0, ERROR_BASE.Length) + "]");

        }

        [Test]
        [Category("Required Field Provided Invalid Input - Error Label Displayed")]

        public void FailedSubmission_InFrontOf_NoSchool_FromTimeMoreThanToTime()
        {
            /*QUALIFYING CRITERIA*/
            ClickNo();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false, false, SLEEP_TIMER);


            /*OCCURRENCE*/

            Occurrence_FromControl.SendKeysWithDelay(
                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.AddDays(-1).Day, DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.AddMinutes(3).Minute, DateTime.Now.Second), SLEEP_TIMER); //Current Time (3 minutes over)

            Occurrence_ToControl.SendKeysWithDelay(
                                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.AddDays(-1).Day, DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second), SLEEP_TIMER); // Current Time

            Fill_OccurrenceAddress(2, 3, false, SLEEP_TIMER);

            Occurrence_VehicleInformation();

            Fill_InFrontOfSchool(false, SLEEP_TIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ComplaintInfo_ClickNext();

            var invalidTime = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 10).FindElement(By.TagName("span"));
            Assert.IsNotNull(invalidTime);

            string error = invalidTime.Text.Trim();
            Console.WriteLine(error);


            string errorDetail = error.Substring(ERROR_BASE.Length);
            string[] errorDetailList = errorDetail.Split(". ", StringSplitOptions.None);
            for(int i = 0; i < errorDetailList.Length; i++)
            {
                Console.WriteLine(errorDetailList[i]);

                if (errorDetailList[i].Contains("should be later than"))
                {
                    if (errorDetailList[i].Contains("."))
                        Assert.That(errorDetailList[i], Is.EqualTo(ERROR_TO_IN_FUTURE_THAN_FROM + "."),
                        "Expecting [" + ERROR_TO_IN_FUTURE_THAN_FROM + "." + "], but found [" + errorDetailList[i] + "]");
                    else Assert.That(errorDetailList[i], Is.EqualTo(ERROR_TO_IN_FUTURE_THAN_FROM),
                        "Expecting [" + ERROR_TO_IN_FUTURE_THAN_FROM + "], but found [" + errorDetailList[i] + "]");
                }
                else if (errorDetailList[i].Contains("three minutes"))
                {
                    if (errorDetailList[i].Contains("."))
                        Assert.That(errorDetailList[i], Is.EqualTo(ERROR_SHORTER_THAN_3_MINUTES + "."),
                        "Expecting [" + ERROR_SHORTER_THAN_3_MINUTES + "." + "], but found [" + errorDetailList[i] + "]");
                    else Assert.That(errorDetailList[i], Is.EqualTo(ERROR_SHORTER_THAN_3_MINUTES),
                        "Expecting [" + ERROR_SHORTER_THAN_3_MINUTES + "], but found [" + errorDetailList[i] + "]");
                }

                else if (errorDetailList[i].Contains("occurrence address"))
                {
                    if (errorDetailList[i].Contains("."))
                        Assert.That(errorDetailList[i], Is.EqualTo(ERROR_INVALID_OCCURRENCE_ADDRESS + "."),
                        "Expecting [" + ERROR_INVALID_OCCURRENCE_ADDRESS + "." + "], but found [" + errorDetailList[i] + "]");
                    else Assert.That(errorDetailList[i], Is.EqualTo(ERROR_INVALID_OCCURRENCE_ADDRESS),
                        "Expecting [" + ERROR_INVALID_OCCURRENCE_ADDRESS + "], but found [" + errorDetailList[i] + "]");
                }
                else if (errorDetailList[i].Contains("associated"))
                {
                    if (errorDetailList[i].Contains("."))
                        Assert.That(errorDetailList[i], Is.EqualTo(ERROR_INVALID_ASSOCIATED_ADDRESS + "."),
                        "Expecting [" + ERROR_INVALID_ASSOCIATED_ADDRESS + "." + "], but found [" + errorDetailList[i] + "]");
                    else Assert.That(errorDetailList[i], Is.EqualTo(ERROR_INVALID_ASSOCIATED_ADDRESS),
                        "Expecting [" + ERROR_INVALID_ASSOCIATED_ADDRESS + "], but found [" + errorDetailList[i] + "]");
                }
                else
                    Assert.True(errorDetailList[i].Contains("should be later than") || errorDetailList[i].Contains("three minutes") || errorDetailList[i].Contains("occurrence address")
                        || errorDetailList[i].Contains("associated"), "The text does not contain the expected errors.");

            }

            if (!error.Contains(ERROR_BASE))
                Assert.That(error.Substring(0, ERROR_BASE.Length), Is.EqualTo(ERROR_BASE),
                    "Expecting [" + ERROR_BASE + "], but found [" + error.Substring(0, ERROR_BASE.Length) + "]");

        }

        [Test]
        [Category("Required Field Provided Invalid Input - Error Label Displayed")]

        public void FailedSubmission_InFrontOf_NoSchool_FromTimeMoreThanToTime_InvalidOccurrenceAddr()
        {
            /*QUALIFYING CRITERIA*/
            ClickNo();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false, false, SLEEP_TIMER);

            /*OCCURRENCE*/
           
            Occurrence_FromControl.SendKeysWithDelay(
                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.AddDays(-1).Day, DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.AddMinutes(3).Minute, DateTime.Now.Second), SLEEP_TIMER); //Current Time (3 minutes over)

            Occurrence_ToControl.SendKeysWithDelay(
                                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.AddDays(-1).Day, DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second), SLEEP_TIMER); // Current Time

            Fill_OccurrenceAddress(2, 3, true, SLEEP_TIMER);

            Occurrence_VehicleInformation();

            Fill_InFrontOfSchool(false, SLEEP_TIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ComplaintInfo_ClickNext();

            var invalidTime = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 10).FindElement(By.TagName("span"));
            Assert.IsNotNull(invalidTime);

            string error = invalidTime.Text.Trim();
            Console.WriteLine(error);


            string errorDetail = error.Substring(ERROR_BASE.Length);
            string[] errorDetailList = errorDetail.Split(". ", StringSplitOptions.None);
            for(int i = 0; i < errorDetailList.Length; i++)
            {
                Console.WriteLine(errorDetailList[i]);

                if (errorDetailList[i].Contains("should be later than"))
                {
                    if (errorDetailList[i].Contains("."))
                        Assert.That(errorDetailList[i], Is.EqualTo(ERROR_TO_IN_FUTURE_THAN_FROM + "."),
                        "Expecting [" + ERROR_TO_IN_FUTURE_THAN_FROM + "." + "], but found [" + errorDetailList[i] + "]");
                    else Assert.That(errorDetailList[i], Is.EqualTo(ERROR_TO_IN_FUTURE_THAN_FROM),
                        "Expecting [" + ERROR_TO_IN_FUTURE_THAN_FROM + "], but found [" + errorDetailList[i] + "]");
                }
                else if (errorDetailList[i].Contains("three minutes"))
                {
                    if (errorDetailList[i].Contains("."))
                        Assert.That(errorDetailList[i], Is.EqualTo(ERROR_SHORTER_THAN_3_MINUTES + "."),
                        "Expecting [" + ERROR_SHORTER_THAN_3_MINUTES + "." + "], but found [" + errorDetailList[i] + "]");
                    else Assert.That(errorDetailList[i], Is.EqualTo(ERROR_SHORTER_THAN_3_MINUTES),
                        "Expecting [" + ERROR_SHORTER_THAN_3_MINUTES + "], but found [" + errorDetailList[i] + "]");
                }

                else if (errorDetailList[i].Contains("occurrence address"))
                {
                    if (errorDetailList[i].Contains("."))
                        Assert.That(errorDetailList[i], Is.EqualTo(ERROR_INVALID_OCCURRENCE_ADDRESS + "."),
                        "Expecting [" + ERROR_INVALID_OCCURRENCE_ADDRESS + "." + "], but found [" + errorDetailList[i] + "]");
                    else Assert.That(errorDetailList[i], Is.EqualTo(ERROR_INVALID_OCCURRENCE_ADDRESS),
                        "Expecting [" + ERROR_INVALID_OCCURRENCE_ADDRESS + "], but found [" + errorDetailList[i] + "]");
                }
                else
                    Assert.True(errorDetailList[i].Contains("should be later than") || errorDetailList[i].Contains("three minutes") || errorDetailList[i].Contains("occurrence address")
                        , "The text does not contain the expected errors.");

            }

            if (!error.Contains(ERROR_BASE))
                Assert.That(error.Substring(0, ERROR_BASE.Length), Is.EqualTo(ERROR_BASE),
                    "Expecting [" + ERROR_BASE + "], but found [" + error.Substring(0, ERROR_BASE.Length) + "]");


        }


        [Test]
        [Category("Required Field Provided Invalid Input - Error Label Displayed")]

        public void FailedSubmission_InFrontOf_NoSchool_FromTimeMoreThanToTime_InvalidAssociatedAddress()
        {
            /*QUALIFYING CRITERIA*/
            ClickNo();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false, true, SLEEP_TIMER);

            /*OCCURRENCE*/

            Occurrence_FromControl.SendKeysWithDelay(
                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.AddDays(-1).Day, DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.AddMinutes(3).Minute, DateTime.Now.Second), SLEEP_TIMER); //Current Time (3 minutes over)

            Occurrence_ToControl.SendKeysWithDelay(
                                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.AddDays(-1).Day, DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second), SLEEP_TIMER); // Current Time

            Fill_OccurrenceAddress(2, 3, false, SLEEP_TIMER);

            Occurrence_VehicleInformation();

            Fill_InFrontOfSchool(false, SLEEP_TIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ComplaintInfo_ClickNext();

            var invalidTime = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 10).FindElement(By.TagName("span"));
            Assert.IsNotNull(invalidTime);

            string error = invalidTime.Text.Trim();
            Console.WriteLine(error);


            string errorDetail = error.Substring(ERROR_BASE.Length);
            string[] errorDetailList = errorDetail.Split(". ", StringSplitOptions.None);
            for(int i = 0; i < errorDetailList.Length; i++)
            {
                Console.WriteLine(errorDetailList[i]);

                if (errorDetailList[i].Contains("should be later than"))
                {
                    if (errorDetailList[i].Contains("."))
                        Assert.That(errorDetailList[i], Is.EqualTo(ERROR_TO_IN_FUTURE_THAN_FROM + "."),
                        "Expecting [" + ERROR_TO_IN_FUTURE_THAN_FROM + "." + "], but found [" + errorDetailList[i] + "]");
                    else Assert.That(errorDetailList[i], Is.EqualTo(ERROR_TO_IN_FUTURE_THAN_FROM),
                        "Expecting [" + ERROR_TO_IN_FUTURE_THAN_FROM + "], but found [" + errorDetailList[i] + "]");
                }
                else if (errorDetailList[i].Contains("three minutes"))
                {
                    if (errorDetailList[i].Contains("."))
                        Assert.That(errorDetailList[i], Is.EqualTo(ERROR_SHORTER_THAN_3_MINUTES + "."),
                        "Expecting [" + ERROR_SHORTER_THAN_3_MINUTES + "." + "], but found [" + errorDetailList[i] + "]");
                    else Assert.That(errorDetailList[i], Is.EqualTo(ERROR_SHORTER_THAN_3_MINUTES),
                        "Expecting [" + ERROR_SHORTER_THAN_3_MINUTES + "], but found [" + errorDetailList[i] + "]");
                }

                else if (errorDetailList[i].Contains("associated"))
                {
                    if (errorDetailList[i].Contains("."))
                        Assert.That(errorDetailList[i], Is.EqualTo(ERROR_INVALID_ASSOCIATED_ADDRESS + "."),
                        "Expecting [" + ERROR_INVALID_ASSOCIATED_ADDRESS + "." + "], but found [" + errorDetailList[i] + "]");
                    else Assert.That(errorDetailList[i], Is.EqualTo(ERROR_INVALID_ASSOCIATED_ADDRESS),
                        "Expecting [" + ERROR_INVALID_ASSOCIATED_ADDRESS + "], but found [" + errorDetailList[i] + "]");
                }
                else
                    Assert.True(errorDetailList[i].Contains("should be later than") || errorDetailList[i].Contains("three minutes")
                        || errorDetailList[i].Contains("associated"), "The text does not contain the expected errors.");

            }

            if (!error.Contains(ERROR_BASE))
                Assert.That(error.Substring(0, ERROR_BASE.Length), Is.EqualTo(ERROR_BASE),
                    "Expecting [" + ERROR_BASE + "], but found [" + error.Substring(0, ERROR_BASE.Length) + "]");
            
        }


        [Test]
        [Category("Required Field Provided Invalid Input - Error Label Displayed")]

        public void FailedSubmission_InFrontOf_NoSchool_FromTimeMoreThanToTime_InvalidOccurrenceAndAssociatedAddr()
        {
            /*QUALIFYING CRITERIA*/
            ClickNo();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false, true, SLEEP_TIMER);

            /*OCCURRENCE*/

            Occurrence_FromControl.SendKeysWithDelay(
                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.AddDays(-1).Day, DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.AddMinutes(3).Minute, DateTime.Now.Second), SLEEP_TIMER); //Current Time (3 minutes over)

            Occurrence_ToControl.SendKeysWithDelay(
                                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.AddDays(-1).Day, DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second), SLEEP_TIMER); // Current Time

            Fill_OccurrenceAddress(2, 3, true, SLEEP_TIMER);

            Occurrence_VehicleInformation();

            Fill_InFrontOfSchool(false, SLEEP_TIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ComplaintInfo_ClickNext();

            var invalidTime = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 10).FindElement(By.TagName("span"));
            Assert.IsNotNull(invalidTime);

            string error = invalidTime.Text.Trim();
            Console.WriteLine(error);


            string errorDetail = error.Substring(ERROR_BASE.Length);
            string[] errorDetailList = errorDetail.Split(". ", StringSplitOptions.None);
            for(int i = 0; i < errorDetailList.Length; i++)
            {
                Console.WriteLine(errorDetailList[i]);

                if (errorDetailList[i].Contains("should be later than"))
                {
                    if (errorDetailList[i].Contains("."))
                        Assert.That(errorDetailList[i], Is.EqualTo(ERROR_TO_IN_FUTURE_THAN_FROM + "."),
                        "Expecting [" + ERROR_TO_IN_FUTURE_THAN_FROM + "." + "], but found [" + errorDetailList[i] + "]");
                    else Assert.That(errorDetailList[i], Is.EqualTo(ERROR_TO_IN_FUTURE_THAN_FROM),
                        "Expecting [" + ERROR_TO_IN_FUTURE_THAN_FROM + "], but found [" + errorDetailList[i] + "]");
                }
                else if (errorDetailList[i].Contains("three minutes"))
                {
                    if (errorDetailList[i].Contains("."))
                        Assert.That(errorDetailList[i], Is.EqualTo(ERROR_SHORTER_THAN_3_MINUTES + "."),
                        "Expecting [" + ERROR_SHORTER_THAN_3_MINUTES + "." + "], but found [" + errorDetailList[i] + "]");
                    else Assert.That(errorDetailList[i], Is.EqualTo(ERROR_SHORTER_THAN_3_MINUTES),
                        "Expecting [" + ERROR_SHORTER_THAN_3_MINUTES + "], but found [" + errorDetailList[i] + "]");
                }

                else if (errorDetailList[i].Contains("occurrence address"))
                {
                    if (errorDetailList[i].Contains("."))
                        Assert.That(errorDetailList[i], Is.EqualTo(ERROR_INVALID_OCCURRENCE_ADDRESS + "."),
                        "Expecting [" + ERROR_INVALID_OCCURRENCE_ADDRESS + "." + "], but found [" + errorDetailList[i] + "]");
                    else Assert.That(errorDetailList[i], Is.EqualTo(ERROR_INVALID_OCCURRENCE_ADDRESS),
                        "Expecting [" + ERROR_INVALID_OCCURRENCE_ADDRESS + "], but found [" + errorDetailList[i] + "]");
                }
                else if (errorDetailList[i].Contains("associated"))
                {
                    if (errorDetailList[i].Contains("."))
                        Assert.That(errorDetailList[i], Is.EqualTo(ERROR_INVALID_ASSOCIATED_ADDRESS + "."),
                        "Expecting [" + ERROR_INVALID_ASSOCIATED_ADDRESS + "." + "], but found [" + errorDetailList[i] + "]");
                    else Assert.That(errorDetailList[i], Is.EqualTo(ERROR_INVALID_ASSOCIATED_ADDRESS),
                        "Expecting [" + ERROR_INVALID_ASSOCIATED_ADDRESS + "], but found [" + errorDetailList[i] + "]");
                }
                else
                    Assert.True(errorDetailList[i].Contains("should be later than") || errorDetailList[i].Contains("three minutes") || errorDetailList[i].Contains("occurrence address")
                        || errorDetailList[i].Contains("associated"), "The text does not contain the expected errors.");

            }

            if (!error.Contains(ERROR_BASE))
                Assert.That(error.Substring(0, ERROR_BASE.Length), Is.EqualTo(ERROR_BASE),
                    "Expecting [" + ERROR_BASE + "], but found [" + error.Substring(0, ERROR_BASE.Length) + "]");

        }

        [Test]
        [Category("Required Field Provided Invalid Input - Error Label Displayed")]
        public void FailedSubmission_InFrontOf_NoSchool_FromTimeMoreThanToCurrentTime()
        {
            /*QUALIFYING CRITERIA*/
            ClickNo();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false, false, SLEEP_TIMER);


            /*OCCURRENCE*/

            Occurrence_FromControl.SendKeysWithDelay(
                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.AddMinutes(3).Minute, DateTime.Now.Second), SLEEP_TIMER); //Current Time (3 minutes over)

            Occurrence_ToControl.SendKeysWithDelay(
                                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second), SLEEP_TIMER); // Current Time

            Fill_OccurrenceAddress(2, 3, false, SLEEP_TIMER);

            Occurrence_VehicleInformation();

            Fill_InFrontOfSchool(false, SLEEP_TIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ComplaintInfo_ClickNext();

            var invalidTime = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 10).FindElement(By.TagName("span"));
            Assert.IsNotNull(invalidTime);

            string error = invalidTime.Text.Trim();
            Console.WriteLine(error);

            string errorDetail = error.Substring(ERROR_BASE.Length);
            string[] errorDetailList = errorDetail.Split(". ", StringSplitOptions.None);
            for(int i = 0; i < errorDetailList.Length; i++)
            {
                Console.WriteLine(errorDetailList[i]);

                if (errorDetailList[i].Contains("should be later than"))
                {
                    if (errorDetailList[i].Contains("."))
                        Assert.That(errorDetailList[i], Is.EqualTo(ERROR_TO_IN_FUTURE_THAN_FROM + "."),
                        "Expecting [" + ERROR_TO_IN_FUTURE_THAN_FROM + "." + "], but found [" + errorDetailList[i] + "]");
                    else Assert.That(errorDetailList[i], Is.EqualTo(ERROR_TO_IN_FUTURE_THAN_FROM),
                        "Expecting [" + ERROR_TO_IN_FUTURE_THAN_FROM + "], but found [" + errorDetailList[i] + "]");
                }
                else if (errorDetailList[i].Contains("cannot be later than"))
                {
                    if (errorDetailList[i].Contains("."))
                        Assert.That(errorDetailList[i], Is.EqualTo(ERROR_TO_AND_FROM_IN_FUTURE + "."),
                        "Expecting [" + ERROR_TO_AND_FROM_IN_FUTURE + "." + "], but found [" + errorDetailList[i] + "]");
                    else Assert.That(errorDetailList[i], Is.EqualTo(ERROR_TO_AND_FROM_IN_FUTURE),
                        "Expecting [" + ERROR_TO_AND_FROM_IN_FUTURE + "], but found [" + errorDetailList[i] + "]");
                }
                else if (errorDetailList[i].Contains("three minutes"))
                {
                    if (errorDetailList[i].Contains("."))
                        Assert.That(errorDetailList[i], Is.EqualTo(ERROR_SHORTER_THAN_3_MINUTES + "."),
                        "Expecting [" + ERROR_SHORTER_THAN_3_MINUTES + "." + "], but found [" + errorDetailList[i] + "]");
                    else Assert.That(errorDetailList[i], Is.EqualTo(ERROR_SHORTER_THAN_3_MINUTES),
                        "Expecting [" + ERROR_SHORTER_THAN_3_MINUTES + "], but found [" + errorDetailList[i] + "]");
                }
                else
                    Assert.True(errorDetailList[i].Contains("should be later than") || errorDetailList[i].Contains("cannot be later than") 
                        || errorDetailList[i].Contains("three minutes")
                        , "The text does not contain the expected errors.");

            }

            if (!error.Contains(ERROR_BASE))
                Assert.That(error.Substring(0, ERROR_BASE.Length), Is.EqualTo(ERROR_BASE),
                    "Expecting [" + ERROR_BASE + "], but found [" + error.Substring(0, ERROR_BASE.Length) + "]");
        }

        [Test]
        [Category("Required Field Provided Invalid Input - Error Label Displayed")]
        public void FailedSubmission_InFrontOf_NoSchool_FromTimeMoreThanToCurrentTime_InvalidOccurrenceAddr()
        {
            /*QUALIFYING CRITERIA*/
            ClickNo();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false, false, SLEEP_TIMER);


            /*OCCURRENCE*/

            Occurrence_FromControl.SendKeysWithDelay(
                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.AddMinutes(3).Minute, DateTime.Now.Second), SLEEP_TIMER); //Current Time (3 minutes over)

            Occurrence_ToControl.SendKeysWithDelay(
                                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second), SLEEP_TIMER); // Current Time

            Fill_OccurrenceAddress(2, 3, true, SLEEP_TIMER);

            Occurrence_VehicleInformation();

            Fill_InFrontOfSchool(false, SLEEP_TIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ComplaintInfo_ClickNext();

            var invalidTime = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 10).FindElement(By.TagName("span"));
            Assert.IsNotNull(invalidTime);

            string error = invalidTime.Text.Trim();
            Console.WriteLine(error);

            string errorDetail = error.Substring(ERROR_BASE.Length);
            string[] errorDetailList = errorDetail.Split(". ", StringSplitOptions.None);
            for(int i = 0; i < errorDetailList.Length; i++)
            {
                Console.WriteLine(errorDetailList[i]);

                if (errorDetailList[i].Contains("should be later than"))
                {
                    if (errorDetailList[i].Contains("."))
                        Assert.That(errorDetailList[i], Is.EqualTo(ERROR_TO_IN_FUTURE_THAN_FROM + "."),
                        "Expecting [" + ERROR_TO_IN_FUTURE_THAN_FROM + "." + "], but found [" + errorDetailList[i] + "]");
                    else Assert.That(errorDetailList[i], Is.EqualTo(ERROR_TO_IN_FUTURE_THAN_FROM),
                        "Expecting [" + ERROR_TO_IN_FUTURE_THAN_FROM + "], but found [" + errorDetailList[i] + "]");
                }
                else if (errorDetailList[i].Contains("cannot be later than"))
                {
                    if (errorDetailList[i].Contains("."))
                        Assert.That(errorDetailList[i], Is.EqualTo(ERROR_TO_AND_FROM_IN_FUTURE + "."),
                        "Expecting [" + ERROR_TO_AND_FROM_IN_FUTURE + "." + "], but found [" + errorDetailList[i] + "]");
                    else Assert.That(errorDetailList[i], Is.EqualTo(ERROR_TO_AND_FROM_IN_FUTURE),
                        "Expecting [" + ERROR_TO_AND_FROM_IN_FUTURE + "], but found [" + errorDetailList[i] + "]");
                }
                else if (errorDetailList[i].Contains("three minutes"))
                {
                    if (errorDetailList[i].Contains("."))
                        Assert.That(errorDetailList[i], Is.EqualTo(ERROR_SHORTER_THAN_3_MINUTES + "."),
                        "Expecting [" + ERROR_SHORTER_THAN_3_MINUTES + "." + "], but found [" + errorDetailList[i] + "]");
                    else Assert.That(errorDetailList[i], Is.EqualTo(ERROR_SHORTER_THAN_3_MINUTES),
                        "Expecting [" + ERROR_SHORTER_THAN_3_MINUTES + "], but found [" + errorDetailList[i] + "]");
                }

                else if (errorDetailList[i].Contains("occurrence address"))
                {
                    if (errorDetailList[i].Contains("."))
                        Assert.That(errorDetailList[i], Is.EqualTo(ERROR_INVALID_OCCURRENCE_ADDRESS + "."),
                        "Expecting [" + ERROR_INVALID_OCCURRENCE_ADDRESS + "." + "], but found [" + errorDetailList[i] + "]");
                    else Assert.That(errorDetailList[i], Is.EqualTo(ERROR_INVALID_OCCURRENCE_ADDRESS),
                        "Expecting [" + ERROR_INVALID_OCCURRENCE_ADDRESS + "], but found [" + errorDetailList[i] + "]");
                }

                else
                    Assert.True(errorDetailList[i].Contains("should be later than") || errorDetailList[i].Contains("cannot be later than")
                        || errorDetailList[i].Contains("three minutes") || errorDetailList[i].Contains("occurrence address")
                        , "The text does not contain the expected errors.");

            }

            if (!error.Contains(ERROR_BASE))
                Assert.That(error.Substring(0, ERROR_BASE.Length), Is.EqualTo(ERROR_BASE),
                    "Expecting [" + ERROR_BASE + "], but found [" + error.Substring(0, ERROR_BASE.Length) + "]");

        }

        [Test]
        [Category("Required Field Provided Invalid Input - Error Label Displayed")]
        public void FailedSubmission_InFrontOf_NoSchool_FromTimeMoreThanToCurrentTime_InvalidAssociatedAddress()
        {
            /*QUALIFYING CRITERIA*/
            ClickNo();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false, true, SLEEP_TIMER);


            /*OCCURRENCE*/

            Occurrence_FromControl.SendKeysWithDelay(
                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.AddMinutes(3).Minute, DateTime.Now.Second), SLEEP_TIMER); //Current Time (3 minutes over)

            Occurrence_ToControl.SendKeysWithDelay(
                                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second), SLEEP_TIMER); // Current Time

            Fill_OccurrenceAddress(2, 3, false, SLEEP_TIMER);

            Occurrence_VehicleInformation();

            Fill_InFrontOfSchool(false, SLEEP_TIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ComplaintInfo_ClickNext();

            var invalidTime = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 10).FindElement(By.TagName("span"));
            Assert.IsNotNull(invalidTime);

            string error = invalidTime.Text.Trim();
            Console.WriteLine(error);

            string errorDetail = error.Substring(ERROR_BASE.Length);
            string[] errorDetailList = errorDetail.Split(". ", StringSplitOptions.None);
            for(int i = 0; i < errorDetailList.Length; i++)
            {
                Console.WriteLine(errorDetailList[i]);

                if (errorDetailList[i].Contains("should be later than"))
                {
                    if (errorDetailList[i].Contains("."))
                        Assert.That(errorDetailList[i], Is.EqualTo(ERROR_TO_IN_FUTURE_THAN_FROM + "."),
                        "Expecting [" + ERROR_TO_IN_FUTURE_THAN_FROM + "." + "], but found [" + errorDetailList[i] + "]");
                    else Assert.That(errorDetailList[i], Is.EqualTo(ERROR_TO_IN_FUTURE_THAN_FROM),
                        "Expecting [" + ERROR_TO_IN_FUTURE_THAN_FROM + "], but found [" + errorDetailList[i] + "]");
                }
                else if (errorDetailList[i].Contains("cannot be later than"))
                {
                    if (errorDetailList[i].Contains("."))
                        Assert.That(errorDetailList[i], Is.EqualTo(ERROR_TO_AND_FROM_IN_FUTURE + "."),
                        "Expecting [" + ERROR_TO_AND_FROM_IN_FUTURE + "." + "], but found [" + errorDetailList[i] + "]");
                    else Assert.That(errorDetailList[i], Is.EqualTo(ERROR_TO_AND_FROM_IN_FUTURE),
                        "Expecting [" + ERROR_TO_AND_FROM_IN_FUTURE + "], but found [" + errorDetailList[i] + "]");
                }
                else if (errorDetailList[i].Contains("three minutes"))
                {
                    if (errorDetailList[i].Contains("."))
                        Assert.That(errorDetailList[i], Is.EqualTo(ERROR_SHORTER_THAN_3_MINUTES + "."),
                        "Expecting [" + ERROR_SHORTER_THAN_3_MINUTES + "." + "], but found [" + errorDetailList[i] + "]");
                    else Assert.That(errorDetailList[i], Is.EqualTo(ERROR_SHORTER_THAN_3_MINUTES),
                        "Expecting [" + ERROR_SHORTER_THAN_3_MINUTES + "], but found [" + errorDetailList[i] + "]");
                }
                else if (errorDetailList[i].Contains("associated"))
                {
                    if (errorDetailList[i].Contains("."))
                        Assert.That(errorDetailList[i], Is.EqualTo(ERROR_INVALID_ASSOCIATED_ADDRESS + "."),
                        "Expecting [" + ERROR_INVALID_ASSOCIATED_ADDRESS + "." + "], but found [" + errorDetailList[i] + "]");
                    else Assert.That(errorDetailList[i], Is.EqualTo(ERROR_INVALID_ASSOCIATED_ADDRESS),
                        "Expecting [" + ERROR_INVALID_ASSOCIATED_ADDRESS + "], but found [" + errorDetailList[i] + "]");
                }
                else
                    Assert.True(errorDetailList[i].Contains("should be later than") || errorDetailList[i].Contains("cannot be later than")
                        || errorDetailList[i].Contains("three minutes") || errorDetailList[i].Contains("associated")
                        , "The text does not contain the expected errors.");

            }

            if (!error.Contains(ERROR_BASE))
                Assert.That(error.Substring(0, ERROR_BASE.Length), Is.EqualTo(ERROR_BASE),
                    "Expecting [" + ERROR_BASE + "], but found [" + error.Substring(0, ERROR_BASE.Length) + "]");

        }

        [Test]
        [Category("Required Field Provided Invalid Input - Error Label Displayed")]
        public void FailedSubmission_InFrontOf_NoSchool_FromTimeMoreThanToCurrentTime_InvalidOccurrenceAndAssociatedAddr()
        {
            /*QUALIFYING CRITERIA*/
            ClickNo();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false, true, SLEEP_TIMER);


            /*OCCURRENCE*/

            Occurrence_FromControl.SendKeysWithDelay(
                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.AddMinutes(3).Minute, DateTime.Now.Second), SLEEP_TIMER); //Current Time (3 minutes over)

            Occurrence_ToControl.SendKeysWithDelay(
                                StringUtilities.SelectDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second), SLEEP_TIMER); // Current Time

            Fill_OccurrenceAddress(2, 3, true, SLEEP_TIMER);

            Occurrence_VehicleInformation();

            Fill_InFrontOfSchool(false, SLEEP_TIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ComplaintInfo_ClickNext();

            var invalidTime = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 10).FindElement(By.TagName("span"));
            Assert.IsNotNull(invalidTime);

            string error = invalidTime.Text.Trim();
            Console.WriteLine(error);

            string errorDetail = error.Substring(ERROR_BASE.Length);
            string[] errorDetailList = errorDetail.Split(". ", StringSplitOptions.None);
            for(int i = 0; i < errorDetailList.Length; i++)
            {
                Console.WriteLine(errorDetailList[i]);

                if (errorDetailList[i].Contains("should be later than"))
                {
                    if (errorDetailList[i].Contains("."))
                        Assert.That(errorDetailList[i], Is.EqualTo(ERROR_TO_IN_FUTURE_THAN_FROM + "."),
                        "Expecting [" + ERROR_TO_IN_FUTURE_THAN_FROM + "." + "], but found [" + errorDetailList[i] + "]");
                    else Assert.That(errorDetailList[i], Is.EqualTo(ERROR_TO_IN_FUTURE_THAN_FROM),
                        "Expecting [" + ERROR_TO_IN_FUTURE_THAN_FROM + "], but found [" + errorDetailList[i] + "]");
                }
                else if (errorDetailList[i].Contains("cannot be later than"))
                {
                    if (errorDetailList[i].Contains("."))
                        Assert.That(errorDetailList[i], Is.EqualTo(ERROR_TO_AND_FROM_IN_FUTURE + "."),
                        "Expecting [" + ERROR_TO_AND_FROM_IN_FUTURE + "." + "], but found [" + errorDetailList[i] + "]");
                    else Assert.That(errorDetailList[i], Is.EqualTo(ERROR_TO_AND_FROM_IN_FUTURE),
                        "Expecting [" + ERROR_TO_AND_FROM_IN_FUTURE + "], but found [" + errorDetailList[i] + "]");
                }
                else if (errorDetailList[i].Contains("three minutes"))
                {
                    if (errorDetailList[i].Contains("."))
                        Assert.That(errorDetailList[i], Is.EqualTo(ERROR_SHORTER_THAN_3_MINUTES + "."),
                        "Expecting [" + ERROR_SHORTER_THAN_3_MINUTES + "." + "], but found [" + errorDetailList[i] + "]");
                    else Assert.That(errorDetailList[i], Is.EqualTo(ERROR_SHORTER_THAN_3_MINUTES),
                        "Expecting [" + ERROR_SHORTER_THAN_3_MINUTES + "], but found [" + errorDetailList[i] + "]");
                }

                else if (errorDetailList[i].Contains("occurrence address"))
                {
                    if (errorDetailList[i].Contains("."))
                        Assert.That(errorDetailList[i], Is.EqualTo(ERROR_INVALID_OCCURRENCE_ADDRESS + "."),
                        "Expecting [" + ERROR_INVALID_OCCURRENCE_ADDRESS + "." + "], but found [" + errorDetailList[i] + "]");
                    else Assert.That(errorDetailList[i], Is.EqualTo(ERROR_INVALID_OCCURRENCE_ADDRESS),
                        "Expecting [" + ERROR_INVALID_OCCURRENCE_ADDRESS + "], but found [" + errorDetailList[i] + "]");
                }
                else if (errorDetailList[i].Contains("associated"))
                {
                    if (errorDetailList[i].Contains("."))
                        Assert.That(errorDetailList[i], Is.EqualTo(ERROR_INVALID_ASSOCIATED_ADDRESS + "."),
                        "Expecting [" + ERROR_INVALID_ASSOCIATED_ADDRESS + "." + "], but found [" + errorDetailList[i] + "]");
                    else Assert.That(errorDetailList[i], Is.EqualTo(ERROR_INVALID_ASSOCIATED_ADDRESS),
                        "Expecting [" + ERROR_INVALID_ASSOCIATED_ADDRESS + "], but found [" + errorDetailList[i] + "]");
                }
                else
                    Assert.True(errorDetailList[i].Contains("should be later than") || errorDetailList[i].Contains("cannot be later than")
                        || errorDetailList[i].Contains("three minutes") || errorDetailList[i].Contains("occurrence address") || errorDetailList[i].Contains("associated")
                        , "The text does not contain the expected errors.");

            }


            if (!error.Contains(ERROR_BASE))
                Assert.That(error.Substring(0, ERROR_BASE.Length), Is.EqualTo(ERROR_BASE),
                    "Expecting [" + ERROR_BASE + "], but found [" + error.Substring(0, ERROR_BASE.Length) + "]");
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
