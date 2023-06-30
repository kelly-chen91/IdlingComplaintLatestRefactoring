
using SeleniumUtilities.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using OpenQA.Selenium.Support.UI;
using IdlingComplaints.Models.Register;
using System.IO;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using log4net.Repository;
using log4net;
using System.CodeDom.Compiler;

namespace IdlingComplaints.Tests.Register
{
    //[Parallelizable(ParallelScope.Children)]
    //[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    internal class Test10_RegistrationFunctionality : RegisterModel
    {
        [SetUp]
        public void SetUp()
        {
            //Driver.Quit();
            //Driver = CreateStandardDriver("chrome");
            //Driver.Navigate().GoToUrl("https://nycidling-dev.azurewebsites.net/profile");
            
            base.RegisterModelSetUp(false);
            Driver.Manage().Window.Size = new Size(1920, 1080);
        }

        [TearDown]
        public void TearDown()
        {
            Thread.Sleep(SLEEP_TIMER);
            Thread.Sleep(SLEEP_TIMER);
            Thread.Sleep(SLEEP_TIMER);
            base.RegisterModelTearDown();
        }

        private readonly int SLEEP_TIMER = 1000;
        // private readonly string successfulEmailFile = ".\\Text_SuccessfulEmailRegistration.txt";
        private readonly string successfulEmailFile = "C:\\Users\\Yyang\\Desktop\\Project\\IdlingComplaintTest3\\Tests\\Register\\Text_SuccessfulEmailRegistration.txt";
       // private readonly string successfulEmailFile = ".//Text_SuccessfulEmailRegistration.txt";

        [Test]
        [Category("Random text input Registration")]
        public void RandomtextRegistration()
        {
            FirstNameControl.SendKeysWithDelay(RegistrationUtilities.GenerateRandomString(), SLEEP_TIMER);
            LastNameControl.SendKeysWithDelay(RegistrationUtilities.GenerateRandomString(), SLEEP_TIMER);
           
            string generatedEmail = RegistrationUtilities.GenerateEmail(RegistrationUtilities.GenerateRandomString(), RegistrationUtilities.GenerateRandomString(), RegistrationUtilities.GenerateRandomString());
            EmailControl.SendKeysWithDelay(generatedEmail, SLEEP_TIMER);

            //string password = RegistrationUtilities.GenerateRandomString();
            string password = RegistrationUtilities.GeneratePassword();
            PasswordControl.SendKeysWithDelay(password, SLEEP_TIMER);
            ConfirmPasswordControl.SendKeysWithDelay(password, SLEEP_TIMER);

            int securityRandomNumber = RegistrationUtilities.GenerateRandomNumberWithRange(1, 5);
            SelectSecurityQuestion(securityRandomNumber);

            string securityAnswer = RegistrationUtilities.GenerateRandomString();
            SecurityAnswerControl.SendKeysWithDelay(securityAnswer, SLEEP_TIMER);

            Address1Control.SendKeysWithDelay(RegistrationUtilities.GenerateRandomString(), SLEEP_TIMER);
            Address2Control.SendKeysWithDelay(RegistrationUtilities.GenerateRandomString(), SLEEP_TIMER);
            CityControl.SendKeysWithDelay(RegistrationUtilities.GenerateRandomString(), SLEEP_TIMER);

            int stateRandomNumber = RegistrationUtilities.GenerateRandomNumberWithRange(1, 49);
            Console.WriteLine("The state number is " + stateRandomNumber + " . And the State selected is " + StateControl);
            SelectState(stateRandomNumber);

            ScrollToButton();
            string zipCodeNumbers = RegistrationUtilities.GenerateSeriseNumbers();
            ZipCodeControl.SendKeysWithDelay(zipCodeNumbers, SLEEP_TIMER);

            string TelephoneNumbers = RegistrationUtilities.GenerateSeriseNumbers();
            TelephoneControl.SendKeysWithDelay(TelephoneNumbers, SLEEP_TIMER);
           
            ClickSubmitButton();
          

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            wait.Until(d =>
            {
                var snackBarError = d.FindElement(By.TagName("simple-snack-bar")).FindElement(By.TagName("span"));
                Assert.IsNotNull(snackBarError);
                if (snackBarError.Text.Trim().Contains("successful"))
                {
                    using (StreamWriter sw = File.AppendText(successfulEmailFile))
                    {
                        try
                        {
                            sw.WriteLine(generatedEmail+" " +password+" "+securityAnswer);
                            Console.WriteLine("Accessed the file");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Cannot Write into File");
                            Console.WriteLine(ex.ToString());
                        }
                    }
                }
                Assert.That(snackBarError.Text.Trim(), Is.EqualTo("Registration has been completed successfully"), "Flagged for inconsistency on purpose."); //Added period for consistency with other error messaging
                return snackBarError;
            });
        }

        [Test]
        [Category("Successful Registration")]
        public void SuccessfulRegistration()
        {
            FirstNameControl.SendKeysWithDelay("Jane", SLEEP_TIMER);
            LastNameControl.SendKeysWithDelay("Doe", SLEEP_TIMER);
            string generatedEmail = StringUtilities.GenerateRandomEmail();
            EmailControl.SendKeysWithDelay(generatedEmail, SLEEP_TIMER);
            PasswordControl.SendKeysWithDelay("T3sting@1234", SLEEP_TIMER);
            ConfirmPasswordControl.SendKeysWithDelay("T3sting@1234", SLEEP_TIMER);
            SelectSecurityQuestion(1);
            SecurityAnswerControl.SendKeysWithDelay("Testing", SLEEP_TIMER);
            Address1Control.SendKeysWithDelay("59-17 Junction Blvd", SLEEP_TIMER);
            Address2Control.SendKeysWithDelay("10th Fl", SLEEP_TIMER);
            CityControl.SendKeysWithDelay("Queens", SLEEP_TIMER);
            SelectState(1);
            ZipCodeControl.SendKeysWithDelay("11373", SLEEP_TIMER);
            TelephoneControl.SendKeysWithDelay("631-632-9800", SLEEP_TIMER);
            ScrollToButton();
            ClickSubmitButton();
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            wait.Until(d =>
            {
                var snackBarError = d.FindElement(By.TagName("simple-snack-bar")).FindElement(By.TagName("span"));
                Assert.IsNotNull(snackBarError);
                if (snackBarError.Text.Trim().Contains("successful"))
                {
                    using (StreamWriter sw = File.AppendText(successfulEmailFile))
                    {
                        try
                        {
                            sw.WriteLine(generatedEmail);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Cannot Write into File");
                            Console.WriteLine(ex.ToString());
                        }
                    }
                } 
                Assert.That(snackBarError.Text.Trim(), Is.EqualTo("Registration has been completed successfully."), "Flagged for inconsistency on purpose."); //Added period for consistency with other error messaging
                return snackBarError;
            });
        }

        [Test]
        [Category("Failed Registration")]
        public void FailedRegistrationDupEmail()
        {
            FirstNameControl.SendKeysWithDelay("Jane", SLEEP_TIMER);
            LastNameControl.SendKeysWithDelay("Doe", SLEEP_TIMER);
            // EmailControl.SendKeysWithDelay(StringUtilities.GenerateEmail(StringUtilities.GenerateRandomString(5), StringUtilities.GenerateRandomString(5), StringUtilities.GenerateRandomString(5)), SLEEP_TIMER);
            EmailControl.SendKeysWithDelay("TTseng@dep.nyc.gov", SLEEP_TIMER);
            PasswordControl.SendKeysWithDelay("T3sting@1234", SLEEP_TIMER);
            ConfirmPasswordControl.SendKeysWithDelay("T3sting@1234", SLEEP_TIMER);
            SelectSecurityQuestion(1);
            SecurityAnswerControl.SendKeysWithDelay("Testing", SLEEP_TIMER);
            Address1Control.SendKeysWithDelay("59-17 Junction Blvd", SLEEP_TIMER);
            Address2Control.SendKeysWithDelay("10th Fl", SLEEP_TIMER);
            CityControl.SendKeysWithDelay("Queens", SLEEP_TIMER);
            SelectState(1);
            ZipCodeControl.SendKeysWithDelay("11373", SLEEP_TIMER);
            TelephoneControl.SendKeysWithDelay("631-632-9800", SLEEP_TIMER);
            ScrollToButton();
            ClickSubmitButton();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(d =>
            {
                var snackBarError = d.FindElement(By.TagName("simple-snack-bar")).FindElement(By.TagName("span"));
                Assert.IsNotNull(snackBarError);
                Assert.That(snackBarError.Text.Trim(), Is.EqualTo("Email " + EmailInput + " has already been registered. Please contact DEP hotline."));
                return snackBarError;
            });

            //Thread.Sleep(10000);
            //Email kelly.chen@dep.nyc.gov has already been registered. Please contact DEP hotline.
        }



        [Test]
        [Category("Cancelled Registration")]
        public void CancelRegistrationFullFormRedirectsToLogin()
        {
            FirstNameControl.SendKeysWithDelay("Jane", SLEEP_TIMER);
            LastNameControl.SendKeysWithDelay("Doe", SLEEP_TIMER);
            EmailControl.SendKeysWithDelay("kchen@dep.nyc.gov", SLEEP_TIMER);
            PasswordControl.SendKeysWithDelay("T3sting@1234", SLEEP_TIMER);
            ConfirmPasswordControl.SendKeysWithDelay("T3sting@1234", SLEEP_TIMER);
            SelectSecurityQuestion(1);
            SecurityAnswerControl.SendKeysWithDelay("Testing", SLEEP_TIMER);
            Address1Control.SendKeysWithDelay("59-17 Junction Blvd", SLEEP_TIMER);
            Address2Control.SendKeysWithDelay("10th Fl", SLEEP_TIMER);
            CityControl.SendKeysWithDelay("Queens", SLEEP_TIMER);
            SelectState(1);
            ZipCodeControl.SendKeysWithDelay("11373", SLEEP_TIMER);
            TelephoneControl.SendKeysWithDelay("631-632-9800", SLEEP_TIMER);
            ScrollToButton();
            ClickCancelButton();

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            var loginButton = Driver.FindElement(By.XPath("/html/body/app-root/div/app-login/mat-card/mat-card-content/form/div[3]/button"));
            Assert.IsNotNull(loginButton);

        }

        [Test]
        [Category("Cancelled Registration")]
        public void CancelRegistrationRedirectsToLogin()
        {
            ScrollToButton();
            ClickCancelButton();
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10)); //1 - too short
            wait.Until(d => d.FindElement(By.TagName("h3")));
        }


        [Test]
        [Category("Successful Registration")]
        public void ReadFileRegistration()
        {
            //  ILoggerRepository logRepository = LogManager.GetRepository(System.Reflection.Assembly.GetEntryAssembly());
            //  log4net.Config.XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

            int localTimer = 0;
            try
            {
                using (StreamReader reader = new StreamReader("C:\\Users\\Yyang\\Desktop\\SeleniumProject - Copy\\IdlingComplaintTest3\\Tests\\Register\\UserDataFile.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Driver.Navigate().GoToUrl("https://nycidling-dev.azurewebsites.net/profile");

                        Console.WriteLine(line);

                        string[] parts = line.Split(',');
                        string firstName = parts[0];
                        string lastname = parts[1];
                        string email = StringUtilities.GenerateRandomEmail();
                        string password = parts[3];
                        string confirmPassword = parts[4];
                        string securityAnswer = parts[5];
                        string address1 = parts[6];
                        string address2 = parts[7];
                        string city = parts[8];
                        string zipCode = parts[9];
                        string telephone = parts[10];

                        //   // Create a separate logger for each combination of username and password
                        //   ILog logger = LogManager.GetLogger($"{email}_{password}");
                        //
                        //   Console.WriteLine("logger created");
                        //
                        //   // Create a new log file name based on the username and password
                        //   string logFileName = $"C:\\Users\\Yyang\\Desktop\\SeleniumProject - Copy\\IdlingComplaintTest3\\Tests\\Register\\logs\\{email}_{password}_log.txt";
                        //   // Configure the appender for the logger to use the new log file
                        //   var fileAppender = (log4net.Appender.FileAppender)((log4net.Repository.Hierarchy.Logger)logger.Logger).GetAppender("FileAppender");
                        //   Console.WriteLine("logger file name");

                        //   fileAppender.File = logFileName;
                        //
                        //   fileAppender.ActivateOptions();
                        //
                        //   Console.WriteLine("log file created");

                        FirstNameControl.SendKeysWithDelay(firstName, localTimer);
                        LastNameControl.SendKeysWithDelay(lastname, localTimer);
                        EmailControl.SendKeysWithDelay(email, localTimer);
                        PasswordControl.SendKeysWithDelay(password, localTimer);
                        ConfirmPasswordControl.SendKeysWithDelay(confirmPassword, localTimer);
                        SelectSecurityQuestion(1);
                        SecurityAnswerControl.SendKeysWithDelay(securityAnswer, localTimer);
                        Address1Control.SendKeysWithDelay(address1, localTimer);
                        Address2Control.SendKeysWithDelay(address2, localTimer);
                        CityControl.SendKeysWithDelay(city, localTimer);
                        SelectState(1);
                        ZipCodeControl.SendKeysWithDelay(zipCode, localTimer);
                        TelephoneControl.SendKeysWithDelay(telephone, localTimer);

                        ScrollToButton();
                        ClickSubmitButton();
                        var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
                        wait.Until(d =>
                        {
                            var snackBarError = d.FindElement(By.TagName("simple-snack-bar")).FindElement(By.TagName("span"));
                            Assert.IsNotNull(snackBarError);
                            //Assert.That(snackBarError.Text.Trim(), Is.EqualTo("Registration has been completed successfully."), "Flagged for inconsistency on purpose."); //Added period for consistency with other error messaging
                            return snackBarError;
                        });
                    }
                    reader.Close();

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("File cannot be read.");
                Console.WriteLine(ex.Message);
            }


        }


    }
}
