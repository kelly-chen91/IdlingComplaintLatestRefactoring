using IdlingComplaints.Models.ComplaintForm;
using SeleniumUtilities.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdlingComplaints.Tests.ComplaintForm
{
    internal class Utilities : ComplaintFormModel
    {
        public void Fill_Associated(bool isPOBox, bool invalidAddress, int timer)
        {
            Associated_CompanyNameControl.SendKeysWithDelay("Test INC", timer);
            Associated_SelectState(1);
            if (!isPOBox) Associated_HouseNumberControl.SendKeysWithDelay("98", timer);
            else Associated_ClickPOBox();
            string street = "Mott Street";
            if (invalidAddress) street = "WhoCares Street";
            Associated_StreetNameControl.SendKeysWithDelay(street, timer);
            Associated_AptFloorControl.SendKeysWithDelay("4th Fl", timer);
            Associated_CityControl.SendKeysWithDelay("New York", timer);
            Associated_ZipCodeControl.SendKeysWithDelay("10013", timer);
        }

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
                streetName = "DoWhatever Street";
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
    }
}
