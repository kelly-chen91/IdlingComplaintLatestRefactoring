using IdlingComplaints.Models.ComplaintForm;
using OpenQA.Selenium;
using SeleniumUtilities.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdlingComplaints.Tests.ComplaintForm.Functionality
{
    internal class FillComplaintForm_Base : ComplaintFormModel
    {
        //[SetUp]
        //public void SetUp()
        //{
        //    base.ComplaintFormModelSetUp(false);
        //
        //}
        //
        //[TearDown]
        //public void TearDown()
        //{
        //    if (SLEEPTIMER > 0) { Thread.Sleep(SLEEPTIMER); }
        //    base.ComplaintFormModelTearDown();
        //}

        public readonly int SLEEPTIMER = 0;
        public readonly string FILE_IMAGE_PATH = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Files\\Images\\idling_truck.jpeg";
        public readonly string ERROR_BASE = "An error occurred while saving form: ";
        public readonly string ERROR_SHORTER_THAN_3_MINUTES = " Idling duration should be more than three minutes.";
        public readonly string ERROR_TO_IN_FUTURE_THAN_FROM = " Occurrence Date To should be later than Occurrence Date From.";
        public readonly string ERROR_TO_AND_FROM_IN_FUTURE = " Occurrence Date From and Occurrence Date To cannot be later than the current date and time.";
        public readonly string ERROR_INVALID_ASSOCIATED_ADDRESS = " The address of the respondent associated with the complaint is invalid.";
        public readonly string ERROR_INVALID_OCCURRENCE_ADDRESS = " The occurrence address is invalid.";
        public static readonly string YES_LABEL = "We are sorry. Your submission can not be accepted by DEP. This idling complaint " +
            "is not consistent with the requirements listed in Section 24-163 of the New York City Administrative Code. " +
            "Thank you for participating in this effort to improve NYC’s air quality.";


        public void Fill_Associated(bool isPOBox, bool invalidAddress, int timer)
        {
            Associated_CompanyNameControl.SendKeysWithDelay("Test INC", timer);
            Associated_SelectState(1);
            if (!isPOBox)
            {
                Associated_HouseNumberControl.SendKeysWithDelay("98", timer);
                Associated_AptFloorControl.SendKeysWithDelay("4th Fl", timer);
            }
            else Associated_POBoxControl.SendKeysWithDelay(" ", timer);
            string street = "Mott Street";
            if (invalidAddress) street = "WhoCares Street";
            Associated_StreetNameControl.SendKeysWithDelay(street, timer);

            Associated_CityControl.SendKeysWithDelay("New York", timer);
            Associated_ZipCodeControl.SendKeysWithDelay("10013", timer);
        }

        //    public void Fill_Associated(bool isPOBox, bool invalidAddress, int timer)
        //   {
        //        Associated_CompanyNameControl.SendKeysWithDelay("Testing INC", timer);
        //        Associated_SelectState(1);
        //        if (isPOBox)
        //         {
        //          Associated_POBoxControl.SendKeysWithDelay(" ", timer);
        //          }
        //          else
        //          {
        //         Associated_HouseNumberControl.SendKeysWithDelay("123", timer);
        //         Associated_AptFloorControl.SendKeysWithDelay("4th Fl", timer);
        //         }
        //          string street = "Mott Street";
        //          if (invalidAddress) street = "WhoCares Street";
        //          Associated_StreetNameControl.SendKeysWithDelay(street, timer);
        //        Associated_AptFloorControl.SendKeysWithDelay("4th Fl", timer);
        //        Associated_CityControl.SendKeysWithDelay("New York", timer);
        //        Associated_ZipCodeControl.SendKeysWithDelay("10013", timer);
        //    }


        public void Fill_OccurrenceAddress(int location, int borough, bool invalidAddress, int timer)
        {
            Assert.That(location, Is.GreaterThan(0));
            Assert.That(location, Is.LessThan(4));
            Assert.That(borough, Is.GreaterThan(0));
            Assert.That(borough, Is.LessThan(6));
            Occurrence_SelectLocation(location);
            Occurrence_SelectBorough(borough);
            string houseNum = "515", streetName = "6th Street";
            string onStreet = "96th Street", crossStreet1 = "55th Ave", crossStreet2 = "57th Ave";
            string intersectCrossStreet1 = "57th Ave", intersectCrossStreet2 = "Junction Blvd";
            if (invalidAddress)
            {
                streetName = "KLAJDFKLAJDF Street";
                onStreet = "WhyDoYouCare Blvd";
                crossStreet1 = onStreet;
                crossStreet2 = "DoesNotMakeSense Expy";
                intersectCrossStreet1 = crossStreet1;
                intersectCrossStreet2 = crossStreet2;
            }
            switch (location)
            {
                case 1:
                    Occurrence_OnStreetControl.SendKeysWithDelay(onStreet, timer);
                    Occurrence_CrossStreet1Control.SendKeysWithDelay(crossStreet1, timer);
                    Occurrence_CrossStreet2Control.SendKeysWithDelay(crossStreet2, timer);
                    break;
                case 2:
                    Occurrence_HouseNumControl.SendKeysWithDelay(houseNum, timer);
                    Occurrence_StreetNameControl.SendKeysWithDelay(streetName, timer);
                    break;
                case 3:
                    Occurrence_CrossStreet1Control.SendKeysWithDelay(intersectCrossStreet1, timer);
                    Occurrence_CrossStreet2Control.SendKeysWithDelay(intersectCrossStreet2, timer);
                    break;
            }
        }

        public void Fill_InFrontOfSchool(bool inFrontOfSchool, int timer)
        {
            if (inFrontOfSchool)
            {
                Occurrence_SelectInFrontOfSchool(1);
                Occurrence_SchoolNameControl.SendKeysWithDelay("ABC School", timer);
            }
            else Occurrence_SelectInFrontOfSchool(2);
        }

        public void QualifyingCriteria()
        {
            /*QUALIFYING CRITERIA*/
            ClickNo();
            Driver.WaitUntilElementFound(By.CssSelector("input[formcontrolname='idc_associatedlastname']"), 20);
        }

        public void Occurrence_ValidDate()
        {
            /*OCCURRENCE*/
            Occurrence_FromControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2023, 4, 20, 00, true), SLEEPTIMER);
            Occurrence_ToControl.SendKeysWithDelay(StringUtilities.SelectDate(6, 28, 2023, 4, 23, 00, true), SLEEPTIMER);
        }

        public void Occurrence_VehicleInformation()
        {
            Occurrence_SelectVehicleType(2);
            Occurrence_LicensePlateControl.SendKeysWithDelay(StringUtilities.GenerateRandomString(7), SLEEPTIMER);
            Occurrence_SelectLicenseState(1);
            Occurrence_PastOffenseControl.SendKeysWithDelay("Test", SLEEPTIMER);
            Occurrence_SecondPastOffenseControl.SendKeysWithDelay("Test", SLEEPTIMER);
        }

        public void Filled_ComplaintInfo()
        {
            /*QUALIFYING CRITERIA*/
            QualifyingCriteria();

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false, false, SLEEPTIMER);

            Occurrence_ValidDate();

            Fill_OccurrenceAddress(2, 3, false, SLEEPTIMER);

            Occurrence_VehicleInformation();

            Fill_InFrontOfSchool(false, SLEEPTIMER);

            Describe_ContentControl.SendKeysWithDelay("Test", SLEEPTIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ComplaintInfo_ClickNext();

            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 60); // loads to next page 
        }

        public void Filled_EvidenceUpload()
        {
            /*EVIDENCE UPLOAD*/

            var successfulSave = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20).FindElement(By.TagName("span"));
            Assert.IsNotNull(successfulSave);
            if (!successfulSave.Text.Contains("saved success")) Assert.That(successfulSave.Text.Trim(), Is.EqualTo("This form has been saved successfully."), "Flagged inconsistency on purpose.");
            Driver.WaitUntilElementIsNoLongerFound(By.TagName("simple-snack-bar"), 20); //message says form is saved

            EvidenceUpload_UploadInput = FILE_IMAGE_PATH;
            string fileName = Path.GetFileName(FILE_IMAGE_PATH);
            EvidenceUpload_ClickFilesUploadConfirm();
            //Thread.Sleep(SLEEPTIMER);

            var successfulEvidenceUpload = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20).FindElement(By.TagName("span")); // message says evidence have successfully uploaded
            Assert.IsNotNull(successfulEvidenceUpload);
            if (!successfulEvidenceUpload.Text.Contains("upload")) Assert.That(successfulEvidenceUpload.Text.Trim(), Is.EqualTo("Successfully uploaded file named: " + fileName + "."), "Flagged inconsistency on purpose.");

            //Thread.Sleep(SLEEPTIMER);
            Driver.WaitUntilElementIsNoLongerFound(By.TagName("simple-snack-bar"), 15);
            EvidenceUpload_ClickNext();
            Driver.WaitUntilElementFound(By.CssSelector("mat-radio-button[value='753720001']"), 60); //waits until the oath affidavit appears

        }

        public void Filled_AppearOATH()
        {
            AppearOATH_ClickNo();

            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 60);

            AppearOATH_ClickSubmit();

        }


    }
}
