using OpenQA.Selenium;
using SeleniumUtilities.Base;
using SeleniumUtilities.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdlingComplaints.Tests.ComplaintForm.C10_OverallFunctionality
{
    internal class Test10_DuplicateSubmissionFunctionality : FillComplaintForm_Base
    {
        BaseExtent extent;

        public Test10_DuplicateSubmissionFunctionality()
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
            base.ComplaintFormModelSetUp(true, true);
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
                if (SLEEP_TIMER > 0) { Thread.Sleep(SLEEP_TIMER); }
                base.ComplaintFormModelTearDown();
            }
        }


        [Test]
        [Category("Failed Form Submission")]

        public void DuplicateFormSubmit_InFrontOf_NoSchool_YesSummonAffidavit()
        {
            /*QUALIFYING CRITERIA*/
            ClickNo();
            Driver.WaitUntilElementFound(Associated_CompanyNameByControl, 20);

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false, false, SLEEP_TIMER);
            DateTime date = new DateTime(2023, 06, 28, 16, 20, 00);
            /*OCCURRENCE*/
            Occurrence_FromControl.SendKeysWithDelay(
                StringUtilities.SelectDate(date), SLEEP_TIMER); // 6/28/2023, 4:20:00 PM

            Occurrence_ToControl.SendKeysWithDelay(
                                StringUtilities.SelectDate(date.AddMinutes(3)), SLEEP_TIMER); // 6/28/2023, 4:23:00 PM

            Fill_OccurrenceAddress(2, 3, false, SLEEP_TIMER);

            Occurrence_SelectVehicleType(2);
            Occurrence_LicensePlateControl.SendKeysWithDelay("DEP1234", SLEEP_TIMER);
            Occurrence_SelectLicenseState(1);
            Occurrence_PastOffenseControl.SendKeysWithDelay("Test", SLEEP_TIMER);
            Occurrence_SecondPastOffenseControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            Fill_InFrontOfSchool(false, SLEEP_TIMER);

            SubmitAcknowledgementAndProceedToNextPage();

            string openComplaintNumber = Filled_EvidenceUpload();

            /*OATH AFFIDAVIT*/

            AppearOATH_ClickYes();

            Driver.WaitUntilElementIsNoLongerFound(SpinnerByControl, 30);

            AppearOATH_ClickSubmit();

            Driver.WaitUntilElementIsNoLongerFound(SpinnerByControl, 60);

            var duplicateMessage = Driver.WaitUntilElementFound(SnackBarByControl, 20).FindElement(By.TagName("span"));
            Assert.IsNotNull(duplicateMessage);


            string expected = Constants.DUPLICATE_FORM_SUBMISSION;
            if(duplicateMessage.Text.Trim().Contains("submitted before"))
            {
                string[] inputs = { GetEmail(), GetPassword(), openComplaintNumber, Constants.DRAFT_STATUS };
                submission_tracker.WriteIntoFile(inputs);
            }
            if (!duplicateMessage.Text.Trim().Contains(expected))
            {
                Assert.That(duplicateMessage.Text.Trim().Substring(0, expected.Length),
                    Is.EqualTo(expected), "Flagged inconsistency on purpose.");
            }

        }
    }
}
