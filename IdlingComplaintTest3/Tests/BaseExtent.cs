using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using SeleniumUtilities.Base;
using SeleniumUtilities.Utils.ExtentUtils;

namespace IdlingComplaints.Tests
{
    public class BaseExtent : BaseModel
    {
        public void SetUp(bool isSetUp, string className = null)
        {
            if (!isSetUp) ExtentTestManager.CreateParentTest(className);
            else
            {
                ExtentTestManager.CreateTest(TestContext.CurrentContext.Test.Name);
            }
        }

        public void TearDown(bool isSetUp)
        {
            if (!isSetUp) ExtentService.GetExtent().Flush();
            else
            {
                var status = TestContext.CurrentContext.Result.Outcome.Status;
                var errorMessage = string.IsNullOrEmpty(TestContext.CurrentContext.Result.Message)
                    ? "" 
                    : string.Format("<pre>{0}</pre>", TestContext.CurrentContext.Result.Message);
                var stackTrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                    ? ""
                    : string.Format("<pre>{0}</pre>", TestContext.CurrentContext.Result.StackTrace);

                switch (status)
                {
                    case TestStatus.Failed:
                        ReportLog.Fail("Test Failed");
                        ReportLog.Fail(errorMessage);
                        ReportLog.Fail(stackTrace);
                        //ReportLog.Fail("Screenshot", CaptureScreenshot(TestContext.CurrentContext.Test.Name));
                        break;
                    case TestStatus.Skipped:
                        ReportLog.Skip("Test Skipped");
                        break;
                    case TestStatus.Passed:
                        ReportLog.Pass("Test Passed");
                        break;
                    default:
                        break;
                }
            }
        }

        
    }
}
