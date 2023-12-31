﻿using IdlingComplaints.Models.ComplaintForm;
using OpenQA.Selenium;
using SeleniumUtilities.Utils.TestUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdlingComplaints.Tests.ComplaintForm
{
    internal class FillComplaintForm_Base : ComplaintFormModel
    {
        
        public readonly int SLEEP_TIMER = 0;
        public readonly string FILE_IMAGE_PATH = P30_EvidenceUpload.Constants.IDLING_TRUCK;

        


        public void Fill_Associated(bool isPOBox, bool invalidAddress, int timer)
        {
            Associated_CompanyNameControl.SendKeysWithDelay(DateTime.Now.ToShortDateString() + "_Test", timer);
            Associated_SelectState(1);
            if (!isPOBox)
            {
                Associated_HouseNumberControl.SendKeysWithDelay("98", timer);
                Associated_AptFloorControl.SendKeysWithDelay("4th Fl", timer);
            }
            else Associated_POBoxControl.SendKeysWithDelay(" ", timer);
            string street = "Mott Street";
            if (invalidAddress) street = StringUtilities.GenerateRandomString(10);
            Associated_StreetNameControl.SendKeysWithDelay(street, timer);

            Associated_CityControl.SendKeysWithDelay("New York", timer);
            Associated_ZipCodeControl.SendKeysWithDelay("10013", timer);
        }



        public void Fill_OccurrenceAddress(int location, int borough, bool invalidAddress, int timer)
        {
            Driver.WaitUntilElementFound(By.CssSelector("mat-select[aria-disabled = 'true']"), 20);
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
                streetName = StringUtilities.GenerateRandomString(10);
                onStreet = StringUtilities.GenerateRandomString(10);
                crossStreet1 = onStreet;
                crossStreet2 = StringUtilities.GenerateRandomString(10);

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
            Occurrence_FromControl.SendKeysWithDelay(
                StringUtilities.SelectDate(DateTime.Now.AddMinutes(-3)), SLEEP_TIMER); // Current Time (3 minutes ago)

            Occurrence_ToControl.SendKeysWithDelay(
                                StringUtilities.SelectDate(DateTime.Now), SLEEP_TIMER); // Current Time
        }

        public void Occurrence_VehicleInformation()
        {
            Occurrence_SelectVehicleType(2);
            Occurrence_LicensePlateControl.SendKeysWithDelay(StringUtilities.GenerateRandomString(7), SLEEP_TIMER);
            Occurrence_SelectLicenseState(1);
            Occurrence_PastOffenseControl.SendKeysWithDelay("Test", SLEEP_TIMER);
            Occurrence_SecondPastOffenseControl.SendKeysWithDelay("Test", SLEEP_TIMER);
        }

        public void SubmitAcknowledgementAndProceedToNextPage()
        {
            Describe_ContentControl.SendKeysWithDelay("Test", SLEEP_TIMER);

            ClickWitnessCheckbox();
            ClickSubmitNoCorrectionCheckbox();
            ComplaintInfo_ClickNext();

            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 60); // loads to next page 
        }

        public void Filled_ComplaintInfo()
        {
            /*QUALIFYING CRITERIA*/
            QualifyingCriteria();

            /*PERSON OR COMPANY ASSOCIATED TO COMPLAINT*/
            ScrollToZipCode();

            Fill_Associated(false, false, SLEEP_TIMER);

            Occurrence_ValidDate();

            Fill_OccurrenceAddress(2, 3, false, SLEEP_TIMER);

            Occurrence_VehicleInformation();

            Fill_InFrontOfSchool(false, SLEEP_TIMER);

            SubmitAcknowledgementAndProceedToNextPage();


        }

        public string Filled_EvidenceUpload()
        {
            /*EVIDENCE UPLOAD*/

            var successfulSave = Driver.WaitUntilElementFound(SnackBarByControl, 20).FindElement(By.TagName("span"));
            Assert.IsNotNull(successfulSave);
            if (!successfulSave.Text.Contains("saved success")) Assert.That(successfulSave.Text.Trim(), Is.EqualTo("This form has been saved successfully."), "Flagged inconsistency on purpose.");
            Driver.WaitUntilElementIsNoLongerFound(SnackBarByControl, 20); //message says form is saved

            EvidenceUpload_UploadInput = FILE_IMAGE_PATH;
            string fileName = Path.GetFileName(FILE_IMAGE_PATH);
            EvidenceUpload_ClickFilesUploadConfirm();
            //Thread.Sleep(SLEEP_TIMER);
            Driver.WaitUntilElementIsNoLongerFound(EvidenceUpload_UploadCommentByControl, 30);

            var successfulEvidenceUpload = Driver.WaitUntilElementFound(SnackBarByControl, 20).FindElement(By.TagName("span")); // message says evidence have successfully uploaded
            Assert.IsNotNull(successfulEvidenceUpload);
            if (!successfulEvidenceUpload.Text.Contains("upload")) Assert.That(successfulEvidenceUpload.Text.Trim(), Is.EqualTo("Successfully uploaded file named: " + fileName + "."), "Flagged inconsistency on purpose.");

            Driver.WaitUntilElementIsNoLongerFound(SnackBarByControl, 20);
            EvidenceUpload_ClickNext();
            Driver.WaitUntilElementFound(By.CssSelector("mat-radio-button[value='753720001']"), 60); //waits until the oath affidavit appears

            var compliantNumberControl = Driver.WaitUntilElementFound(ComplaintForm_ComplaintNumberByControl, 30);
            Console.WriteLine(compliantNumberControl.Text);
            while (compliantNumberControl.Text.Length <= "Complaint Number: ".Length)
            {
                compliantNumberControl = Driver.WaitUntilElementFound(ComplaintForm_ComplaintNumberByControl, 30);
                Console.WriteLine(compliantNumberControl.Text);

            }

            return compliantNumberControl.Text.Substring("Complaint Number: ".Length);
        }

        public void Filled_AppearOATH()
        {
            AppearOATH_ClickNo();

            Driver.WaitUntilElementIsNoLongerFound(By.TagName("mat-spinner"), 60);

            AppearOATH_ClickSubmit();

        }

        

    }
}
