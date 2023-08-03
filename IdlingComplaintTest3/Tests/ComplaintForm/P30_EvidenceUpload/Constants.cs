using SeleniumUtilities.Utils.TestUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdlingComplaints.Tests.ComplaintForm.P30_EvidenceUpload
{
    internal class Constants
    {
        
        public static readonly string FORM_SAVE = "This form has been saved successfully.";
        public static readonly string SUCCESSFUL_UPLOAD= "Succesfully uploaded file";

        //label: Evidence section/ title
        public static readonly string EVIDENCE_TITLE = "Files Upload";

        //label: Evidence section/ requirement
        public static readonly string UPLOAD_FILE_REQUIRE = "Please Upload at least one image or video";

        public static string IDLING_TRUCK = StringUtilities.GetProjectRootDirectory() + "\\Files\\Images\\idling_truck.jpeg";
        public static string IDLING_BUS = StringUtilities.GetProjectRootDirectory() + "\\Files\\Images\\idling_bus.jpg";
        public static string IDLING_VAN = StringUtilities.GetProjectRootDirectory() + "\\Files\\Images\\idling_van.jpg";
        public static string NOT_SUPPORTED_FILE = StringUtilities.GetProjectRootDirectory() + "\\Files\\Images\\not_supported_idling_WEBPfile.webp";
        public static string PDF_FILE = StringUtilities.GetProjectRootDirectory() + "\\Files\\Images\\WebDoc.pdf";
        public static string MP4_FILE = StringUtilities.GetProjectRootDirectory() + "\\Files\\Images\\MP4_How_To_Get_Rich_Reporting_On_Idling_Vehicles_In_NYC.mp4";
    }
}
