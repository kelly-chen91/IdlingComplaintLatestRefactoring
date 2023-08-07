using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdlingComplaints.Tests.ComplaintForm.P10_Associated
{
    internal class Constants
    {
        
        //Ying label: Complainant section
        public static readonly string COMPLAINT_TITLE = "The Person or Company Associated with Your Complaint";
        // label: Complainant section/ input content
        public static readonly string COMPANY_NAME = "Company Name";
        public static readonly string STATE = "State";
        public static readonly string HOUSENUMBER = "House Number";
        public static readonly string STREET_NAME = "Street Name/P. O. Box";
        public static readonly string APT_FLOOR_SUITE_UNIT = "Apt/Floor/Suite/Unit";
        public static readonly string CITY = "City";
        public static readonly string ZIP = "Zip Code";
        //label: Complainant section/ requirement
        public static readonly string COMPANY_NAME_REQUIRE = "Company Name/Last Name is required";
        public static readonly string STATE_REQUIRE = "State is required";
        public static readonly string HOUSENUMBER_REQUIRE = "House Number is required";
        public static readonly string STREET_NAME_REQUIRE = "Street Name/P. O. Box is required";
        public static readonly string CITY_REQUIRE = "City is required";
        public static readonly string ZIP_CODE_REQUIRE = "Zip Code is required";

        //label: Describe the Complaint session
        public static readonly string DESCRIBE_TITLE = "Describe the Complaint";
        public static readonly string DESCRIBE_CONTENT = "Describe the Complaint is required";
        public static readonly string DESCRIBE_COMPLAINT_REQUIRE = "Describe the Complaint is required";
        public static readonly string DESCRIBE_CONTENT_INPUT = "Please describe the complaint in the space here.";


        //label: Describe the Acknowledgement section
        public static readonly string REQUIRED_ACKNOWLEDGEMENT = "Acknowledgement is required";

        //label: Qualifying Criteria section
        public static readonly string BUS_OR_VAN_PASSENGER_CAPACITY = "Is the BUS / VAN capacity 15 passengers or less, including the driver?";
        public static readonly string BUS_OR_VAN_LOADING_PASSENGER = "Was the BUS / VAN loading and unloading passengers during the idling event when not at a terminal point?";
        public static readonly string TRUCK_OR_VAN_ACTIVITY_INVOLVEMENT = "Was the TRUCK / VAN involved in an activity classified as process [i.e. refrigeration trucks, ice cream" +
            " trucks, cement trucks, trucks using lift gates, armored trucks, garbage trucks collecting waste, etc.] during the idling event?";
        public static readonly string PRIVATE_VEHICLE_TYPE = "Is it a PRIVATE VEHICLE?";

    }
}
