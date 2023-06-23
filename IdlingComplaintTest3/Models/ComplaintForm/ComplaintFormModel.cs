using IdlingComplaints.Models.Login;
using OpenQA.Selenium.Support.UI;
using SeleniumUtilities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdlingComplaints.Models.ComplaintForm
{
    internal class ComplaintFormModel:LoginModel
    { 
        public new void OneTimeSetUp()
        {
            //loginModel = new LoginModel();
            base.OneTimeSetUp();
            EmailControl.SendKeysWithDelay("kchen@dep.nyc.gov", 0);
            PasswordControl.SendKeysWithDelay("T3sting@1234", 0);
            ClickLoginButton();
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.CssSelector("button[routerlink='idlingcomplaint/new']")));
        }

        public new void OneTimeTearDown()
        {
            base.OneTimeTearDown();
        }
    }
}
