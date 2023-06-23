using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdlingComplaints.Tests.Home
{
    internal class Constants
    {
        public static readonly string HEADING = "NYC Idling Complaints";
        public static readonly string NEW_COMPLAINT = "New Idling Complaint";
        public static readonly string CREATE_YEAR = "Select Created Year";
        public static readonly string ITEMS_PER_PAGE = "Items Per Page:"; //Capitalized for consistancy purposes
        public static readonly string HOME = "Home";
        public static readonly string PROFILE = "Profile";
        public static readonly string LOGOUT = "Logout";
        public static readonly string SORT_COMPLAINT_NUM = "Complaint Number";
        public static readonly string SORT_COMPANY = "Company Name";
        public static readonly string SORT_PLACE = "Place of Occurrence";
        public static readonly string SORT_STATUS = "Status";
        public static readonly string SORT_SUBMITTED_DATE = "Date Submitted";
        public static readonly string SORT_SUMMONS_NUM = "Summons Number";
        public static readonly string SORT_HEARING_DATE = "Hearing Date";

        public static readonly string HOME_LINK = "/";
        public static readonly string PROFILE_LINK = "profile";
        public static readonly string NEW_COMPLAINT_LINK = "idlingcomplaint/new";

        /*CREATED YEAR DROPDOWN OPTIONS*/
        public static readonly string CURRENT_YEAR = "Current Year";
        public static readonly string LAST_YEAR = "Last Year";
        public static readonly string ALL = "All";
        /*ITEMS PER PAGE DROPDOWN OPTIONS*/
        public static readonly string FIVE_ITEMS = "5";
        public static readonly string TEN_ITEMS = "10";
        public static readonly string TWENTY_ITEMS = "20";
    }
}
