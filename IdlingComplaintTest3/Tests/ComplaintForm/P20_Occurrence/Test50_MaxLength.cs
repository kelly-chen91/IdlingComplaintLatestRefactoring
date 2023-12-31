﻿using IdlingComplaints.Models.ComplaintForm;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumUtilities.BaseSetUp;
using SeleniumUtilities.Utils.TestUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdlingComplaints.Tests.ComplaintForm.P20_Occurrence
{

    internal class Test50_MaxLength : ComplaintFormModel
    {

        BaseExtent extent;

        public Test50_MaxLength()
        {
            extent = new BaseExtent();
        }
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            extent.SetUp(false, GetType().Namespace + "." + GetType().Name);
            base.ComplaintFormModelSetUp(true, false);
            NewComplaintSetUp();
            ClickNo();
            Driver.ScrollTo(Occurrence_VehicleTypeControl);
            Driver.WaitUntilElementFound(Associated_CompanyNameByControl, 15);

        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            extent.TearDown(false, Driver);
            base.ComplaintFormModelTearDown();

        }

        [SetUp]
        public void SetUp()
        {
            extent.SetUp(true);
        }

        [TearDown]
        public void TearDown()
        {
            try
            {
                extent.TearDown(true, Driver);
            }
            catch (Exception ex)
            {
                throw new Exception("Exception: " + ex);
            }
            
        }

        [Test]
        [Category("Maxlength Attribute is present.")]
        public void MaxlengthHouseNumberDefault()
        {
            Occurrence_SelectLocation(0);
            int maxlength = Occurrence_HouseNumControl.MaxLengthAttributeValue();

            Assert.That(maxlength, Is.EqualTo(Constants.OCCURRENCE_HOUSE_NUM_MAXLENGTH));
        }

        [Test]
        [Category("Maxlength Attribute is present.")]
        public void MaxlengthHouseNumberInFrontOf()
        {
            Occurrence_SelectLocation(2);

            int maxlength = Occurrence_HouseNumControl.MaxLengthAttributeValue();

            Assert.That(maxlength, Is.EqualTo(Constants.OCCURRENCE_HOUSE_NUM_MAXLENGTH));
        }

        [Test]
        [Category("Maxlength Attribute is present.")]
        public void MaxlengthStreetNameDefault()
        {
            Occurrence_SelectLocation(0);

            int maxlength = Occurrence_StreetNameControl.MaxLengthAttributeValue();

            Assert.That(maxlength, Is.EqualTo(Constants.OCCURRENCE_STREET_NAME_MAXLENGTH));
        }


        [Test]
        [Category("Maxlength Attribute is present.")]
        public void MaxlengthStreetNameInFrontOf()
        {
            Occurrence_SelectLocation(2);

            int maxlength = Occurrence_StreetNameControl.MaxLengthAttributeValue();

            Assert.That(maxlength, Is.EqualTo(Constants.OCCURRENCE_STREET_NAME_MAXLENGTH));
        }

        [Test]
        [Category("Maxlength Attribute is present.")]
        public void MaxlengthOnStreetBetween()
        {
            Occurrence_SelectLocation(1);

            int maxlength = Occurrence_OnStreetControl.MaxLengthAttributeValue();

            Assert.That(maxlength, Is.EqualTo(Constants.OCCURRENCE_ON_STREET_MAXLENGTH));
        }



        [Test]
        [Category("Maxlength Attribute is present.")]
        public void MaxlengthCrossStreet1Between()
        {
            Occurrence_SelectLocation(1);

            int maxlength = Occurrence_CrossStreet1Control.MaxLengthAttributeValue();

            Assert.That(maxlength, Is.EqualTo(Constants.OCCURRENCE_CROSS_STREET1_MAXLENGTH));
        }

        

        [Test]
        [Category("Maxlength Attribute is present.")]
        public void MaxlengthCrossStreet1Intersection()
        {
            Occurrence_SelectLocation(3);

            int maxlength = Occurrence_CrossStreet1Control.MaxLengthAttributeValue();

            Assert.That(maxlength, Is.EqualTo(Constants.OCCURRENCE_CROSS_STREET1_MAXLENGTH));
        }

        [Test]
        [Category("Maxlength Attribute is present.")]
        public void MaxlengthCrossStreet2Between()
        {
            Occurrence_SelectLocation(1);

            int maxlength = Occurrence_CrossStreet2Control.MaxLengthAttributeValue();

            Assert.That(maxlength, Is.EqualTo(Constants.OCCURRENCE_CROSS_STREET2_MAXLENGTH));
        }

        [Test]
        [Category("Maxlength Attribute is present.")]
        public void MaxlengthCrossStreet2Intersection()
        {
            Occurrence_SelectLocation(3);

            int maxlength = Occurrence_CrossStreet2Control.MaxLengthAttributeValue();

            Assert.That(maxlength, Is.EqualTo(Constants.OCCURRENCE_CROSS_STREET2_MAXLENGTH));
        }


        [Test]
        [Category("Maxlength Attribute is present.")]
        public void MaxlengthLicensePlate()
        {
            int maxlength = Occurrence_LicensePlateControl.MaxLengthAttributeValue();

            Assert.That(maxlength, Is.EqualTo(Constants.OCCURRENCE_LICENSE_PLATE_MAXLENGTH));

        }

        [Test]
        [Category("Maxlength Attribute is present.")]
        public void MaxlengthPastOffense()
        {
            int maxlength = Occurrence_PastOffenseControl.MaxLengthAttributeValue();

            Assert.That(maxlength, Is.EqualTo(Constants.OCCURRENCE_PAST_OFFENSE_MAXLENGTH));
        }

        [Test]
        [Category("Maxlength Attribute is present.")]
        public void MaxlengthSecondPastOffense()
        {
            int maxlength = Occurrence_SecondPastOffenseControl.MaxLengthAttributeValue();

            Assert.That(maxlength, Is.EqualTo(Constants.OCCURRENCE_PAST_OFFENSE_MAXLENGTH));
        }

        [Test]
        [Category("Maxlength Attribute is present.")]
        public void MaxlengthSchoolNameInFrontOfSchool()
        {
            Occurrence_SelectInFrontOfSchool(1); //yes

            int maxlength = Occurrence_SchoolNameControl.MaxLengthAttributeValue();

            Assert.That(maxlength, Is.EqualTo(Constants.OCCURRENCE_SCHOOL_NAME_MAXLENGTH));
        }
        
    }
}
