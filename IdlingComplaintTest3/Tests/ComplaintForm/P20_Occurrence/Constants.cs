using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdlingComplaints.Tests.ComplaintForm.P20_Occurrence
{
    internal class Constants
    {
        public static readonly string OCCURRENCE_FROM = "Occurrence Date From"; //Spelling error
        public static readonly string OCCURRENCE_TO = "Occurrence Date To";  
        public static readonly string OCCURRENCE_LOCATION = "Location";
        public static readonly string OCCURRENCE_HOUSE_NUM = "House Number";
        public static readonly string OCCURRENCE_STREET_NAME = "Street Name";

        /*Between location option*/
        public static readonly string OCCURRENCE_ON_STREET = "On Street";

        /*Between & Intersection location option*/
        public static readonly string OCCURRENCE_CROSS_STREET1 = "Cross Street 1";
        public static readonly string OCCURRENCE_CROSS_STREET2 = "Cross Street 2";

        public static readonly string OCCURRENCE_STATE = "State";
        public static readonly string OCCURRENCE_BOROUGH = "Borough";
        public static readonly string OCCURRENCE_VEHICLE_TYPE = "Vehicle Type";
        public static readonly string OCCURRENCE_LICENSE_PLATE = "License Plate";
        public static readonly string OCCURRENCE_LICENSE_STATE = "License State";
        public static readonly string OCCURRENCE_PAST_OFFENSE = "Past Offense"; //Offence is UK spelling instead of US
        public static readonly string OCCURRENCE_SECOND_PAST_OFFENSE = "Second Past Offense"; //Offence is UK spelling instead of US
        public static readonly string OCCURRENCE_IN_FRONT_OF_SCHOOL = "In Front of School"; //Inconsistent with uppercase
        public static readonly string OCCURRENCE_ADMIN_CODE = "Section of the NYC Administrative Code (Prefix: 24-)"; //Inconsistent with uppercase

        public static readonly string OCCURRENCE_REQUIRED_FROM = "Occurrence Date From is required"; //Spelling error
        public static readonly string OCCURRENCE_REQUIRED_TO = "Occurrence Date To is required"; //Spelling error
        public static readonly string OCCURRENCE_REQUIRED_LOCATION = "Location is required";
        public static readonly string OCCURRENCE_REQUIRED_HOUSE_NUM = "House Number is required";
        public static readonly string OCCURRENCE_REQUIRED_STREET_NAME = "Street Name is required";

        /*Between location option*/
        public static readonly string OCCURRENCE_REQUIRED_ON_STREET = "On Street is required";

        /*Between & Intersection location option*/
        public static readonly string OCCURRENCE_REQUIRED_CROSS_STREET1 = "Cross Street 1 is required";
        public static readonly string OCCURRENCE_REQUIRED_CROSS_STREET2 = "Cross Street 2 is required";

        public static readonly string OCCURRENCE_REQUIRED_BOROUGH = "Borough is required";
        public static readonly string OCCURRENCE_REQUIRED_VEHICLE_TYPE = "Vehicle Type is required";
        public static readonly string OCCURRENCE_REQUIRED_LICENSE_PLATE = "License Plate is required";
        public static readonly string OCCURRENCE_REQUIRED_LICENSE_STATE = "License State is required";
        public static readonly string OCCURRENCE_REQUIRED_IN_FRONT_OF_SCHOOL = "In Front of School is required"; //Inconsistent with uppercase

        /*In front of school option*/
        public static readonly string OCCURRENCE_SCHOOL_NAME = "School Name";


        /*Maxlength*/
        public static readonly int OCCURRENCE_HOUSE_NUM_MAXLENGTH = 95;
        public static readonly int OCCURRENCE_STREET_NAME_MAXLENGTH = 95;
        public static readonly int OCCURRENCE_ON_STREET_MAXLENGTH = 95;
        public static readonly int OCCURRENCE_CROSS_STREET1_MAXLENGTH = 95;
        public static readonly int OCCURRENCE_CROSS_STREET2_MAXLENGTH = 95;
        public static readonly int OCCURRENCE_LICENSE_PLATE_MAXLENGTH = 50;
        public static readonly int OCCURRENCE_PAST_OFFENSE_MAXLENGTH = 100;
        public static readonly int OCCURRENCE_SCHOOL_NAME_MAXLENGTH = 100;
    }
}
