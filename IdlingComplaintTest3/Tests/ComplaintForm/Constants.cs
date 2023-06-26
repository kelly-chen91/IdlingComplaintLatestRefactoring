using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdlingComplaints.Tests.ComplaintForm
{
    internal class Constants
    {
        //label: not qulify for the complaint form  
        public static readonly string YES_LABEL ="We are sorry. Your submission can not be accepted by DEP. This idling complaint is not consistent with the requirements listed in Section 24-163 of the New York City Administrative Code.Thank you for participating in this effort to improve NYC’s air quality.";

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

        //Kelly label: Occurrence Promption section
    }
}
