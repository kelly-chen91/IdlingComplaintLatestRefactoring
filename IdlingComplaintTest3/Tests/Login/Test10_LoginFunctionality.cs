using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System.Drawing;
using SeleniumUtilities.Utils;
using IdlingComplaints.Models.Login;

namespace IdlingComplaints.Tests.Login;

//[Parallelizable(ParallelScope.Children)]
//[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]

/*This is user login verification test*/

internal class Test10_LoginFunctionality : LoginModel
{
   Random random = new Random();
   
    [SetUp]
    public void SetUp()
    {
        //Driver.Quit();
        //Driver = CreateStandardDriver("chrome");
        //Driver.Navigate().GoToUrl("https://nycidling-dev.azurewebsites.net/login");
        //Driver.Manage().Window.Size = new Size(1920, 1200);
        base.LoginModelSetUp(false);
    }

    [TearDown]
    public void TearDown()
    {
        if (SLEEP_TIMER > 0)
            Thread.Sleep(SLEEP_TIMER);
        base.LoginModelTearDown();
    }

    private readonly int SLEEP_TIMER = 2000;
    private readonly string registered_EmailAddress = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Files\\Text\\Registered_EmailAddress.txt";


    [Test, Category("Scenario login functionality test1: login with valid email and password")]
    
    public void RetriveFileDataVerification()
    {

        string[] lines = File.ReadAllLines(registered_EmailAddress);
        int userIndex = random.Next(0, lines.Length - 1);

        string email = RegistrationUtilities.RetriveRecordValue(registered_EmailAddress, userIndex, 0);
        string password = RegistrationUtilities.RetriveRecordValue(registered_EmailAddress, userIndex, 1);

        EmailControl.SendKeysWithDelay(email, SLEEP_TIMER);
        PasswordControl.SendKeysWithDelay(password, SLEEP_TIMER);
        ClickLoginButton();

        Driver.WaitUntilElementFound(By.CssSelector("button[routerlink='idlingcomplaint/new']"), 20);
      
        Driver.WaitUntilElementIsNoLongerFound(By.CssSelector("div[dir = 'ltr']"), 20);
    }


    [Test, Category("Scenario login functionality test2: login with valid email, but wrong password")]
    public void LoginValidEmailAndPassword()
    {
        //locate login field
        EmailControl.SendKeysWithDelay("ttseng@dep.nyc.gov", SLEEP_TIMER);
        PasswordControl.SendKeysWithDelay(RegistrationUtilities.GenerateRandomString(), SLEEP_TIMER);
        ClickLoginButton();

        Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20);
        var resultControl = Driver.FindElement(By.TagName("simple-snack-bar")).FindElement(By.TagName("span"));
        Assert.That(resultControl.Text.Trim(), Is.EqualTo("Email and password do not match."));
        Driver.WaitUntilElementIsNoLongerFound(By.CssSelector("div[dir = 'ltr']"), 20);
    }




    [Test, Category("Scenario login functionality test3: login with unregistered email address")]
    public void LoginInvalidPassword()
    {
        //locate login field
        EmailControl.SendKeysWithDelay(RegistrationUtilities.GenerateEmail("unregistered", "emailAddress", "dep.nyc.gov"), SLEEP_TIMER);
        PasswordControl.SendKeysWithDelay("Testing1", SLEEP_TIMER);
        ClickLoginButton();

        var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10)); 
        wait.Until(d =>
        {
            var resultControl = d.FindElement(By.TagName("simple-snack-bar")).FindElement(By.TagName("span"));
      
            Assert.IsNotNull(resultControl);
            Assert.That(resultControl.Text.Trim(), Is.EqualTo("User is not found"));
      
            return resultControl;
        }
        );
    }

    [Test, Category("Scenario login functionality test4: login with unregistered email address, but a qulified password")]
    public void LoginEmailNotFound()
    {
        //locate login field
        EmailControl.SendKeysWithDelay(RegistrationUtilities.GenerateEmail("unregistered", "emailAddress", "dep.nyc.gov"), SLEEP_TIMER);
        PasswordControl.SendKeysWithDelay(RegistrationUtilities.GenerateQulifiedPassword(), SLEEP_TIMER);
        ClickLoginButton();
        var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10)); //1 - too short
        wait.Until(d =>
        {
            var resultControl = d.FindElement(By.TagName("simple-snack-bar")).FindElement(By.TagName("span"));

            Assert.IsNotNull(resultControl);
            Assert.That(resultControl.Text.Trim(), Is.EqualTo("User is not found")); //Added a period for consistency in error messaging

            return resultControl;
        }
        );
    }
}
