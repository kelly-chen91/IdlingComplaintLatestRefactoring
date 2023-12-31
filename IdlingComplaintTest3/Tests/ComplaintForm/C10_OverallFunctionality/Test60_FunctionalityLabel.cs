﻿using OpenQA.Selenium;
using SeleniumUtilities.BaseSetUp;
using SeleniumUtilities.Utils.TestUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IdlingComplaints.Tests.ComplaintForm.C10_OverallFunctionality
{
    internal class Test60_FunctionalityLabel : FillComplaintForm_Base
    {

        BaseExtent extent;

        public Test60_FunctionalityLabel()
        {
            extent = new BaseExtent();
        }
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            extent.SetUp(false, GetType().Namespace + "." + GetType().Name);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            extent.TearDown(false, Driver);
        }

        [SetUp]
        public void SetUp()
        {
            base.ComplaintFormModelSetUp(true, false);
            NewComplaintSetUp();
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
            finally
            {
                base.ComplaintFormModelTearDown();
            }
        }


        [Test]
        [Category("Correct Label Displayed")]
        public void SuccessfulSubmissionMessage()
        {
            base.Filled_ComplaintInfo();
            string openComplaintNumber = base.Filled_EvidenceUpload();
            base.Filled_AppearOATH();

            string successMessage = Driver.WaitUntilElementFound(SnackBarByControl,60).FindElement(By.TagName("span")).Text;
            string status = Constants.SUCCESS_STATUS;
            if (!successMessage.Contains(Constants.PARTIAL_SUCCESSFUL_FORM_SUBMISSION))
            {
                status = Constants.DRAFT_STATUS;
            }
            string[] inputs = { GetEmail(), GetPassword(), openComplaintNumber, status };
            submission_tracker.WriteIntoFile(inputs);
            
            
            Assert.That(successMessage, Is.EqualTo(Constants.SUCCESSFUL_FORM_SUBMISSION), "Flagged inconsistency on purpose.");
        }

        //[Test]
        //[Category("Correct Label Displayed")]
        //public void DuplicateSubmissionMessage()
        //{
        //    /*QUALIFYING CRITERIA*/
        //    QualifyingCriteria();
//
        //    /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
        //    ScrollToZipCode();
//
        //    Fill_Associated(false, false, SLEEP_TIMER);
//
        //    /*OCCURRENCE*/
        //    DateTime date = new DateTime(2023, 06, 28, 16, 20, 00);
//
        //    Occurrence_FromControl.SendKeysWithDelay(
        //        StringUtilities.SelectDate(date), SLEEP_TIMER); // Current Time (3 minutes ago)
//
        //    Occurrence_ToControl.SendKeysWithDelay(
        //                        StringUtilities.SelectDate(date.AddMinutes(3)), SLEEP_TIMER); // Current Time
//
        //    Fill_OccurrenceAddress(2, 3, false, SLEEP_TIMER);
//
        //    Occurrence_SelectVehicleType(2);
        //    Occurrence_LicensePlateControl.SendKeysWithDelay("DEP1234", SLEEP_TIMER);
        //    Occurrence_SelectLicenseState(1);
        //    Occurrence_PastOffenseControl.SendKeysWithDelay("Test", SLEEP_TIMER);
        //    Occurrence_SecondPastOffenseControl.SendKeysWithDelay("Test", SLEEP_TIMER);
//
        //    Fill_InFrontOfSchool(false, SLEEP_TIMER);
//
        //    Describe_ContentControl.SendKeysWithDelay("Test", SLEEP_TIMER);
//
        //    ClickWitnessCheckbox();
        //    ClickSubmitNoCorrectionCheckbox();
        //    ComplaintInfo_ClickNext();
//
        //    Driver.WaitUntilElementIsNoLongerFound(SpinnerByControl, 60); // loads to next page 
//
        //    base.Filled_EvidenceUpload();
        //    base.Filled_AppearOATH();
//
        //    string duplicateMessage = Driver.WaitUntilElementFound(SnackBarByControl, 60).FindElement(By.TagName("span")).Text;
        //    Console.WriteLine(duplicateMessage);
//
        //    string expected = Constants.DUPLICATE_FORM_SUBMISSION;
        //    if (!duplicateMessage.Trim().Contains(expected))
        //    {
        //        Assert.That(duplicateMessage.Trim().Substring(0, expected.Length),
        //            Is.EqualTo(expected), "Flagged inconsistency on purpose.");
        //    }
        //}
    }
}
