using IdlingComplaints.Models.Home;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumUtilities.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdlingComplaints.Tests.Home
{
    internal class Test60_Label : HomeModel
    { 
    
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            base.HomeModelSetUp("kchen@dep.nyc.gov", "T3sting@1234", true);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Thread.Sleep(2000);
            base.HomeModelTearDown();
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedHeading()
        {
            string heading = Driver.FindElement(By.TagName("h3")).Text;
            Assert.That(heading, Is.EqualTo(Constants.HEADING));
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedHome()
        {
            string home = Driver.ExtractTextFromXPath("/html/body/app-root/app-nav-bar/mat-toolbar/mat-toolbar-row/button[1]/span/text()");
            Assert.That(home, Is.EqualTo(Constants.HOME));
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedProfile()
        {
            string profile = Driver.ExtractTextFromXPath("/html/body/app-root/app-nav-bar/mat-toolbar/mat-toolbar-row/button[2]/span/text()");
            Assert.That(profile, Is.EqualTo(Constants.PROFILE));
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedLogout()
        {
            string logout = Driver.ExtractTextFromXPath("/html/body/app-root/app-nav-bar/mat-toolbar/mat-toolbar-row/button[3]/span/text()");
            Assert.That(logout, Is.EqualTo(Constants.LOGOUT));
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedNewComplaint()
        {
            string newComplaint = Driver.ExtractTextFromXPath("/html/body/app-root/div/app-home/div/button/span/text()");
            Assert.That(newComplaint.Trim(), Is.EqualTo(Constants.NEW_COMPLAINT));
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedSortComplaintNumber()
        {
            Assert.That(SortComplaintNumControl.Text, Is.EqualTo(Constants.SORT_COMPLAINT_NUM));
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedSortCompanyName()
        {
            Assert.That(SortCompanyControl.Text, Is.EqualTo(Constants.SORT_COMPANY));
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedSortPlace()
        {
            Assert.That(SortPlaceControl.Text, Is.EqualTo(Constants.SORT_PLACE));
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedSortStatus()
        {
            Assert.That(SortStatusControl.Text, Is.EqualTo(Constants.SORT_STATUS));
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedSortSubmittedDate()
        {
            Assert.That(SortSubmittedDateControl.Text, Is.EqualTo(Constants.SORT_SUBMITTED_DATE));
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedSortSummonsNumber()
        {
            Assert.That(SortSummonsNumControl.Text, Is.EqualTo(Constants.SORT_SUMMONS_NUM));
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedHearingDate()
        {
            Assert.That(SortHearingDateControl.Text, Is.EqualTo(Constants.SORT_HEARING_DATE));
        }

        /*DISPLAYED CREATED YEAR OPTIONS*/
        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedCreatedYearCurrentOption()
        {
            Driver.WaitUntilElementIsNoLongerFound(By.CssSelector("div[dir = 'ltr']"), 20);
            SelectCreatedYear(0);
            Assert.That(selectedCreatedYearControl, Is.EqualTo(Constants.CURRENT_YEAR));

        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedCreatedYearLastOption()
        {
            Driver.WaitUntilElementIsNoLongerFound(By.CssSelector("div[dir = 'ltr']"), 20);
            SelectCreatedYear(1);
            Assert.That(selectedCreatedYearControl, Is.EqualTo(Constants.LAST_YEAR));
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedCreatedYearAllOption()
        {
            Driver.WaitUntilElementIsNoLongerFound(By.CssSelector("div[dir = 'ltr']"), 20);
            SelectCreatedYear(2);
            Assert.That(selectedCreatedYearControl, Is.EqualTo(Constants.ALL));

        }

        /*DISPLAYED ITEMS PER PAGE OPTIONS*/
        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedItemsPerPageFiveOption()
        {
            Driver.WaitUntilElementIsNoLongerFound(By.CssSelector("div[dir = 'ltr']"), 20);
            SelectItemsPerPage(0);
            Assert.That(selectedItemsPerPageControl, Is.EqualTo(Constants.FIVE_ITEMS));
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedItemsPerPageTenOption()
        {
            Driver.WaitUntilElementIsNoLongerFound(By.CssSelector("div[dir = 'ltr']"), 20);
            SelectItemsPerPage(1);
            Assert.That(selectedItemsPerPageControl, Is.EqualTo(Constants.TEN_ITEMS));
        }

        [Test]
        [Category("Correct Label Displayed")]
        public void DisplayedItemsPerPageFifthteenOption()
        {
            Driver.WaitUntilElementIsNoLongerFound(By.CssSelector("div[dir = 'ltr']"), 20);
            SelectItemsPerPage(2);
            Assert.That(selectedItemsPerPageControl, Is.EqualTo(Constants.TWENTY_ITEMS));


        }

        [Test]
        [Category("Placeholder is present.")]
        public void PlaceholderCreatedYear()
        {
            string createdYearPlaceholder = CreatedYearControl.GetAttribute("placeholder");
            Assert.That(createdYearPlaceholder, Is.EqualTo(Constants.CREATE_YEAR));
        }

        [Test]
        [Category("Placeholder is present.")]
        public void PlaceholderItemsPerPage()
        {
            /*Cannot locate element*/
            string itemsPerPagePlaceholder = Driver.ExtractTextFromXPath("/html/body/app-root/div/app-home/app-idling-list/div/mat-paginator/div/div/div[1]/div/text()");
            Assert.That(itemsPerPagePlaceholder, Is.EqualTo(Constants.ITEMS_PER_PAGE), "Flagged for inconsistency on purpose.");
        }

        [Test]
        [Category("Label Displayed - goes to correct link.")]
        public void VerifyHomeLink()
        {
            Assert.That(HomeControl.GetAttribute("routerlink"), Is.EqualTo(Constants.HOME_LINK));
        }

        [Test]
        [Category("Label Displayed - goes to correct link.")]
        public void VerifyProfileLink()
        {
            Assert.That(ProfileControl.GetAttribute("routerlink"), Is.EqualTo(Constants.PROFILE_LINK));
        }

        [Test]
        [Category("Label Displayed - goes to correct link.")]
        public void VerifyNewComplaintLink()
        {
            Assert.That(NewComplaintControl.GetAttribute("routerlink"), Is.EqualTo(Constants.NEW_COMPLAINT_LINK));
        }

        public void DisplayedPageRange()
        {
            /*Page Range is weird with this "1-2 of 2", it should be something like "1 of 2" as it is supposed to tell what page it is*/
        }

    }
}
