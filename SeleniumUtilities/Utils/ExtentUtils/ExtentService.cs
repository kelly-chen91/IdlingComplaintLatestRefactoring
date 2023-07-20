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
    public class ExtentService
    {
        public static ExtentReports extent;
        public static ExtentReports GetExtent()
        {
            if(extent == null)
            {
                extent = new ExtentReports();
                string reportDir = StringUtilities.GetProjectRootDirectory() + "\\TestReports\\ExtentReports\\";
                //"C:\\Users\\kchen\\source\\repos\\IdlingComplaintLatestRefactoring\\SeleniumUtilities\\Utils\\ExtentUtils\\"
                if(!Directory.Exists(reportDir))
                    Directory.CreateDirectory(reportDir);
                string path = Path.Combine(reportDir, "index.html");
                //string path = Path.Combine(reportDir, "report.html");
                //Console.WriteLine(path);
                var reporter = new ExtentHtmlReporter(path);
                reporter.Config.DocumentTitle = "Idling Complaints Report";
                reporter.Config.ReportName = "Idling Complaints Testing Report";
                reporter.Config.Theme = Theme.Standard;
                extent.AttachReporter(reporter);
            }
            return extent;
        }
    }
}
