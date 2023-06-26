using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System.Drawing;
using SeleniumUtilities.Utils;
using IdlingComplaints.Models.Login;

namespace IdlingComplaints.Tests.Login;

//[Parallelizable(ParallelScope.Children)]
//[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]

/*This is user login verification test*/

internal class Test50_Functionality : LoginModel
{
    [SetUp]
    public void SetUp()
    {
        Driver.Quit();
        Driver = CreateDriver("chrome");
        Driver.Navigate().GoToUrl("https://nycidling-dev.azurewebsites.net/login");
        Driver.Manage().Window.Size = new Size(1920, 1200);
    }

    [TearDown]
    public void TearDown()
    {
        Thread.Sleep(SLEEP_TIMER);
        Driver.Quit();
    }

    private readonly int SLEEP_TIMER = 2000;

    //Explicit wait to test user login 
    [Test]
    [Category("Valid Login Loads New Page")]
    public void LoginValidEmailAndPassword()
    {
        //locate login field
        EmailControl.SendKeysWithDelay("ttseng@dep.nyc.gov", SLEEP_TIMER);
        PasswordControl.SendKeysWithDelay("Testing1#", SLEEP_TIMER);
        ClickLoginButton();

        var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10)); //1 - too short
        wait.Until(d => d.FindElement(By.CssSelector("button[routerlink='idlingcomplaint/new']")));
    }

    //Explicit wait to test user login 
    [Test]
    [Category("Invalid Login - Error Displayed")]
    public void LoginInvalidPassword()
    {
        //locate login field
        EmailControl.SendKeysWithDelay("ttseng@dep.nyc.gov", SLEEP_TIMER);
        PasswordControl.SendKeysWithDelay("Testing1", SLEEP_TIMER);
        ClickLoginButton();
        var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10)); //1 - too short
        wait.Until(d =>
            {
                var resultControl = d.FindElement(By.TagName("simple-snack-bar")).FindElement(By.TagName("span"));

                Assert.IsNotNull(resultControl);
                Assert.That(resultControl.Text.Trim(), Is.EqualTo("Email and password do not match."));

                return resultControl;
            }
        );
    }

    [Test]
    [Category("Invalid Login - Error Displayed")]
    public void LoginEmailNotFound()
    {
        //locate login field
        EmailControl.SendKeysWithDelay("d@gmail.com", SLEEP_TIMER);
        PasswordControl.SendKeysWithDelay("Testing1", SLEEP_TIMER);
        ClickLoginButton();
        var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10)); //1 - too short
        wait.Until(d =>
            {
                var resultControl = d.FindElement(By.TagName("simple-snack-bar")).FindElement(By.TagName("span"));

                Assert.IsNotNull(resultControl);
                Assert.That(resultControl.Text.Trim(), Is.EqualTo("User is not found."), "Flagged for inconsistency on purpose."); //Added a period for consistency in error messaging

                return resultControl;
            }
        );
    }
}
