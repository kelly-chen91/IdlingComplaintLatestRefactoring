using IdlingComplaints.Models.Home;
using OpenQA.Selenium;
using SeleniumUtilities.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdlingComplaints.Tests.ComplaintForm.P10_Associated;
using NUnit.Framework;

namespace IdlingComplaints.Models.ComplaintForm
{
    internal partial class ComplaintFormModel : HomeModel
    {
        private readonly string registered_EmailAddress = StringUtilities.GetProjectRootDirectory() + "\\Files\\Text\\ComplaintForm_AccountTracker.txt";
        public readonly string submission_tracker = StringUtilities.GetProjectRootDirectory() + "\\Files\\Text\\ComplaintForm_SubmissionTracker.txt";
        private Random random = new Random();
        private string email = "ttseng@dep.nyc.gov";
        private string password = "Testing1#";
        public void ComplaintFormModelSetUp(bool isHeadless, bool isDuplicateTest)
        {
            if (!isDuplicateTest)
            {
                string[] lines = File.ReadAllLines(registered_EmailAddress);
                int userRowIndex = random.Next(0, lines.Length - 1);
                email = FileUtilities.RetrieveRecordValue(registered_EmailAddress, userRowIndex, 0);
                password = FileUtilities.RetrieveRecordValue(registered_EmailAddress, userRowIndex, 1);

            }
            Console.Write("Login Email: " + email + ", Password: " + password);
            base.HomeModelSetUp(email, password, isHeadless);
            Console.Write(", " + "Successful\n");
            //base.HomeModelSetUp("TTseng@dep.nyc.gov", "Testing1#", isHeadless);

        }

        public void NewComplaintSetUp()
        {
            ClickNewComplaintButton();
            Driver.WaitUntilElementFound(By.TagName("mat-radio-button"), 10);
            Driver.WaitUntilElementIsNoLongerFound(SpinnerByControl, 20);
        }
        public void ComplaintFormModelTearDown()
        {
            base.HomeModelTearDown();
        }

        public string GetEmail()
        {
            return email;
        }

        public string GetPassword()
        {
            return password;
        }
    }
}
