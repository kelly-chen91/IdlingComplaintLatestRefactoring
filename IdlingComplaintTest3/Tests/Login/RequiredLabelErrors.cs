using IdlingComplaintTest.Pages.Login;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdlingComplaintTest2.Tests.Login
{
    internal class RequiredLabelErrors : LoginModel
    {
        private readonly int SLEEP_TIMER = 0;

        [SetUp]
        public void SetUp()
        {
            Driver.Quit();
            Driver = CreateDriver("chrome");
            Driver.Navigate().GoToUrl("https://nycidling-dev.azurewebsites.net/profile");
            Driver.Manage().Window.Size = new Size(1920, 1200);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }


    }
}
