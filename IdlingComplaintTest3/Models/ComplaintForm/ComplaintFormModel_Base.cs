using IdlingComplaints.Models.Home;
using OpenQA.Selenium;
using SeleniumUtilities.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdlingComplaints.Tests.ComplaintForm.Complainant;

namespace IdlingComplaints.Models.ComplaintForm
{
    internal partial class ComplaintFormModel : HomeModel
    {
        //[LoginModelSetUp]
        public void ComplaintFormModelSetUp(bool isHeadless)
        {
            base.HomeModelSetUp("TTseng@dep.nyc.gov", "Testing1#", isHeadless);
            ClickNewComplaintButton();
            Driver.WaitUntilElementFound(By.TagName("mat-radio-button"), 10);
            Driver.WaitUntilElementIsNoLongerFound(By.CssSelector("div[dir = 'ltr']"), 20);
        }
        //[LoginModelTearDown]
        public void ComplaintFormModelTearDown()
        {
            base.HomeModelTearDown();
        }

        }
    }
