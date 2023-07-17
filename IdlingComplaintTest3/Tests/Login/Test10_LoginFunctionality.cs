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
        base.LoginModelSetUp(false);
    }

    [TearDown]
    public void TearDown()
    {
        if (SLEEP_TIMER > 0)
            Thread.Sleep(SLEEP_TIMER);
        base.LoginModelTearDown();
    }

    private readonly int SLEEP_TIMER = 0;
    private readonly string registered_EmailAddress = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Files\\Text\\Registered_EmailAddress.txt";

    
    [Test, Category("Successful Login - Error Label Hidden")]
    public void LoginValidEmailAndPassword()
    {
        string[] lines = File.ReadAllLines(registered_EmailAddress);
        int userRowIndex = random.Next(0, lines.Length - 1);

        string email = RegistrationUtilities.RetrieveRecordValue(registered_EmailAddress, userRowIndex, 0);
        string password = RegistrationUtilities.RetrieveRecordValue(registered_EmailAddress, userRowIndex, 1);

        EmailControl.SendKeysWithDelay(email, SLEEP_TIMER);
        PasswordControl.SendKeysWithDelay(password, SLEEP_TIMER);
        ClickLoginButton();

        Driver.WaitUntilElementFound(By.CssSelector("button[routerlink='idlingcomplaint/new']"), 20);
      
        Driver.WaitUntilElementIsNoLongerFound(By.CssSelector("div[dir = 'ltr']"), 20);
    }


    [Test, Category("Failed Login - Error Label Displayed")]
    public void LoginValidEmailAndInvalidPassword()
    {
        //locate login field
        EmailControl.SendKeysWithDelay("ttseng@dep.nyc.gov", SLEEP_TIMER);
        PasswordControl.SendKeysWithDelay(RegistrationUtilities.GenerateRandomString(), SLEEP_TIMER);
        ClickLoginButton();

        Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 20);
        var resultControl = Driver.FindElement(By.TagName("simple-snack-bar")).FindElement(By.TagName("span"));
        Assert.That(resultControl.Text.Trim(), Is.EqualTo(Constants.INVALID_PASSWORD));
        Driver.WaitUntilElementIsNoLongerFound(By.CssSelector("div[dir = 'ltr']"), 20);
    }


    [Test, Category("Failed Login - Error Label Displayed")]
    public void LoginInvalidEmailAndPassword()
    {
        EmailControl.SendKeysWithDelay(RegistrationUtilities.GenerateEmail("unregistered", "emailAddress", "dep.nyc.gov"), SLEEP_TIMER);
        PasswordControl.SendKeysWithDelay("Testing1", SLEEP_TIMER);
        ClickLoginButton();
        var resultControl = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 10).FindElement(By.TagName("span"));
        Assert.IsNotNull(resultControl);
        Assert.That(resultControl.Text.Trim(), Is.EqualTo(Constants.USER_NOT_FOUND), "Flagged for inconsistency on purpose."); 
    }

    [Test, Category("Failed Login - Error Label Displayed")]
    public void LoginInvalidEmailAndValidPassword()
    {
        //locate login field
        EmailControl.SendKeysWithDelay(RegistrationUtilities.GenerateEmail("unregistered", "emailAddress", "dep.nyc.gov"), SLEEP_TIMER);
        PasswordControl.SendKeysWithDelay(RegistrationUtilities.GenerateQualifiedPassword(), SLEEP_TIMER);
        ClickLoginButton();
        var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10)); //1 - too short
        var resultControl = Driver.WaitUntilElementFound(By.TagName("simple-snack-bar"), 10).FindElement(By.TagName("span"));
        Assert.IsNotNull(resultControl);
        Assert.That(resultControl.Text.Trim(), Is.EqualTo(Constants.USER_NOT_FOUND), "Flagged for inconsistency on purpose.");
    }
}
