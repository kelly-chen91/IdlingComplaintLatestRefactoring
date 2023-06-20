using IdlingComplaintTest.Pages.Register;
using IdlingComplaintTest.Pages.Login;
using IdlingComplaintTest.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using OpenQA.Selenium.Support.UI;

namespace IdlingComplaintTest.Tests.Register
{
    [Parallelizable(ParallelScope.Children)]
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    internal class SuccessTest : RegisterModel
    {
        [SetUp]
        public void SetUp()
        {
            Driver.Navigate().GoToUrl("https://nycidling-dev.azurewebsites.net/profile");
            Driver.Manage().Window.Size = new Size(1920, 1200);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }

        [Test]
        [Category("Successful Registration Test")]
        public void ImplicitWaitSuccessfulRegistrationTest()
        {

            FirstNameInput ="Jane";
            LastNameInput = "Doe";
            EmailInput = StringUtilities.GenerateRandomEmail();
            PasswordInput = "T3sting@1234";
            ConfirmPasswordInput = "T3sting@1234";
            SelectSecurityQuestion(1);
            SecurityAnswerInput = "Testing";
            Address1Input = "59-17 Junction Blvd";
            Address2Input = "10th Fl";
            CityInput = "Queens";
            SelectState(1);
            ZipCodeInput = "11373";
            PhoneInput = "631-632-9800";
            ScrollToButton();
            ClickSubmitButton();
        
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10)); 
            wait.Until(d => d.FindElement(By.TagName("simple-snack-bar")));

        }
  
      [Test]
      [Category("Cancel Registration Test")]
      public void ImplicitWaitCancelRegistrationTest()
      {
            FirstNameInput = "Jane";
            LastNameInput = "Doe";
            EmailInput = StringUtilities.GenerateRandomEmail();
            PasswordInput = "T3sting@1234";
            ConfirmPasswordInput = "T3sting@1234";
            SelectSecurityQuestion(1);
            SecurityAnswerInput = "Testing";
            Address1Input = "59-17 Junction Blvd";
            Address2Input = "10th Fl";
            CityInput = "Queens";
            SelectState(1);
            ZipCodeInput = "11373";
            PhoneInput = "631-632-9800";
            ScrollToButton();
            ClickCancelButton();

            var loginButton = Driver.FindElement(By.XPath("/html/body/app-root/div/app-login/mat-card/mat-card-content/form/div[3]/button"));
            Assert.IsNotNull(loginButton);
      
        }
  
       [Test]
       [Category("Cancel Registration Test")]
       public void ClearPageAfterCancelTest()
       {
            ScrollToButton();
            ClickCancelButton();
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10)); //1 - too short
            wait.Until(d => d.FindElement(By.TagName("h3")));
        }
   
       [Test]
       public void RandomEmailTest()
       {
           Console.WriteLine(StringUtilities.GenerateRandomEmail());
       }
   
    }
}
