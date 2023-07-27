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
        private readonly string registered_EmailAddress = StringUtilities.GetProjectRootDirectory() + "\\Files\\Text\\Registered_EmailAddress.txt";
        private Random random = new Random();
        public void ComplaintFormModelSetUp(bool isHeadless, bool isDuplicateTest)
        {
            string email = "ttseng@dep.nyc.gov";
            string password = "Testing1#";
            if (!isDuplicateTest)
            {
                string[] lines = File.ReadAllLines(registered_EmailAddress);
                int userRowIndex = random.Next(0, lines.Length - 1);

                email = RegistrationUtilities.RetrieveRecordValue(registered_EmailAddress, userRowIndex, 0);
                password = RegistrationUtilities.RetrieveRecordValue(registered_EmailAddress, userRowIndex, 1);
                base.HomeModelSetUp(email, password, isHeadless);

                //base.HomeModelSetUp("TTseng@dep.nyc.gov", "Testing1#", isHeadless);
            }
        }

        public void NewComplaintSetUp()
        {
            ClickNewComplaintButton();
            Driver.WaitUntilElementFound(By.TagName("mat-radio-button"), 10);
            Driver.WaitUntilElementIsNoLongerFound(By.CssSelector("div[dir = 'ltr']"), 20);
        }
        public void ComplaintFormModelTearDown()
        {
            base.HomeModelTearDown();
        }

        }
    }
