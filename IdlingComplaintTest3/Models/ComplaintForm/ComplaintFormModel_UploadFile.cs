using IdlingComplaints.Models.Home;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdlingComplaints.Models.ComplaintForm
{
    internal class ComplaintFormModel_UploadFile: HomeModel
    {
        public IWebElement UploadFile_FromControl => Driver.FindElement

    }
}
