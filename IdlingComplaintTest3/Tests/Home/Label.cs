﻿using IdlingComplaints.Models.Home;
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
    internal class Label : HomeModel
    {
        [OneTimeSetUp]
        public new void OneTimeSetUp()
        {
            base.OneTimeSetUp();
        }

        [OneTimeTearDown]
        public new void OneTimeTearDown()
        {
            Thread.Sleep(2000);
            base.OneTimeTearDown();
        }

        [Test]
        [Category("Label Displayed - no spelling/grammar errors.")]
        public void DisplayedHeading()
        {
            string heading = Driver.FindElement(By.TagName("h3")).Text;
            Assert.That(heading, Is.EqualTo(Constants.HEADING));
        }

        [Test]
        [Category("Label Displayed - no spelling/grammar errors.")]
        public void DisplayedHome()
        {
            string home = Driver.ExtractTextFromXPath("/html/body/app-root/app-nav-bar/mat-toolbar/mat-toolbar-row/button[1]/span/text()");
            Assert.That(home, Is.EqualTo(Constants.HOME));
        }

        [Test]
        [Category("Label Displayed - no spelling/grammar errors.")]
        public void DisplayedProfile()
        {
            string profile = Driver.ExtractTextFromXPath("/html/body/app-root/app-nav-bar/mat-toolbar/mat-toolbar-row/button[2]/span/text()");
            Assert.That(profile, Is.EqualTo(Constants.PROFILE));
        }

        [Test]
        [Category("Label Displayed - no spelling/grammar errors.")]
        public void DisplayedLogout()
        {
            string logout = Driver.ExtractTextFromXPath("/html/body/app-root/app-nav-bar/mat-toolbar/mat-toolbar-row/button[3]/span/text()");
            Assert.That(logout, Is.EqualTo(Constants.LOGOUT));
        }

        [Test]
        [Category("Label Displayed - no spelling/grammar errors.")]
        public void DisplayedNewComplaint()
        {
            string newComplaint = Driver.ExtractTextFromXPath("/html/body/app-root/div/app-home/div/button/span/text()");
            Assert.That(newComplaint.Trim(), Is.EqualTo(Constants.NEW_COMPLAINT));
        }

        [Test]
        [Category("Label Displayed - no spelling/grammar errors.")]
        public void DisplayedSortComplaintNumber()
        {
            Assert.That(SortComplaintNumControl.Text, Is.EqualTo(Constants.SORT_COMPLAINT_NUM));
        }

        [Test]
        [Category("Label Displayed - no spelling/grammar errors.")]
        public void DisplayedSortCompanyName()
        {
            Assert.That(SortCompanyControl.Text, Is.EqualTo(Constants.SORT_COMPANY));
        }

        [Test]
        [Category("Label Displayed - no spelling/grammar errors.")]
        public void DisplayedSortPlace()
        {
            Assert.That(SortPlaceControl.Text, Is.EqualTo(Constants.SORT_PLACE));
        }

        [Test]
        [Category("Label Displayed - no spelling/grammar errors.")]
        public void DisplayedSortStatus()
        {
            Assert.That(SortStatusControl.Text, Is.EqualTo(Constants.SORT_STATUS));
        }

        [Test]
        [Category("Label Displayed - no spelling/grammar errors.")]
        public void DisplayedSortSubmittedDate()
        {
            Assert.That(SortSubmittedDateControl.Text, Is.EqualTo(Constants.SORT_SUBMITTED_DATE));
        }

        [Test]
        [Category("Label Displayed - no spelling/grammar errors.")]
        public void DisplayedSortSummonsNumber()
        {
            Assert.That(SortSummonsNumControl.Text, Is.EqualTo(Constants.SORT_SUMMONS_NUM));
        }

        [Test]
        [Category("Label Displayed - no spelling/grammar errors.")]
        public void DisplayedHearingDate()
        {
            Assert.That(SortHearingDateControl.Text, Is.EqualTo(Constants.SORT_HEARING_DATE));
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

    }
}