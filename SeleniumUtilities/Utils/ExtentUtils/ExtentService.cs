using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumUtilities.Utils.ExtentUtils
{
    public static class ExtentService
    {
        public static ExtentReports extent;
        public static ExtentReports GetExtent()
        {
            if(extent == null)
            {
                extent = new ExtentReports();
                string reportDir = StringUtilities.GetProjectRootDirectory() + "\\..\\IdlingComplaints\\ExtentReports\\";
                //"C:\\Users\\kchen\\source\\repos\\IdlingComplaintLatestRefactoring\\SeleniumUtilities\\Utils\\ExtentUtils\\"
                if(!Directory.Exists(reportDir))
                    Directory.CreateDirectory(reportDir);

                string path = Path.Combine(reportDir, "index.html");
                var reporter = new ExtentHtmlReporter(path);
                reporter.Config.DocumentTitle = "Framework Report";
                reporter.Config.ReportName = "Test Automation Report";
                reporter.Config.Theme = Theme.Standard;
                extent.AttachReporter(reporter);
            }
            return extent;
        }
    }
}
