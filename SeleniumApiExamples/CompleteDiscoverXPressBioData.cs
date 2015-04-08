using System;
using System.Data;
using System.Text;
using System.Collections;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SeleniumApiExamples
{
    [TestClass]
    public class CompleteDiscoverXPressBiodata
    {
        private IWebDriver driver;

        [TestInitialize]
        public void Setup() 
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://www2dev.mdanderson.org/sapp/tracs-discover-utest/");
        }

        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestMethod]
        [DeploymentItem("C:\\Users\\rahernandez2\\Documents\\GitHub\\selenium\\selenium2_exercises\\SeleniumApiExamples\\Data\\Rotators.xlsx")]
        [DataSource("System.Data.OleDB",
            @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=C:\Users\rahernandez2\Documents\GitHub\Selenium\selenium2_exercises\SeleniumApiExamples\Data\Rotators.xlsx; Extended Properties='Excel 12.0;HDR=yes';",
            "data$",
            DataAccessMethod.Sequential)]  

        public void applicantCompleteBiodata()
        {
            ApplicantLogin();

            //CompleteSchoolInformation();

            CompleteBioDataForm();
         }

        private void CompleteBioDataForm()
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            var step1Link = driver.FindElement(By.Id("ctl00_LoginView2_UserMenu1_lnkBtnStep1"));
            step1Link.Click();


            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            IWebElement continueButton = driver.FindElement(By.Id("btnContinue"));

            continueButton.Click();


            IWebElement biodataLink = driver.FindElement(By.CssSelector("#applicationViewTOC-left > ol > li:nth-child(1) > a"));

            biodataLink.Click();

            IWebElement SSN1 = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_ctlBioInfo1_txtSocial1"));

            SSN1.SendKeys(TestContext.DataRow["ssn1"].ToString());

            IWebElement SSN2 = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_ctlBioInfo1_txtSocial2"));

            SSN2.SendKeys(TestContext.DataRow["ssn2"].ToString());


            IWebElement SSN3 = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_ctlBioInfo1_txtSocial3"));

            SSN3.SendKeys(TestContext.DataRow["ssn3"].ToString());

            IWebElement addressOne = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_ctlBioInfo1_txtAddress1"));

            addressOne.SendKeys(TestContext.DataRow["address"].ToString());

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            IWebElement city = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_ctlBioInfo1_txtCity"));

            city.SendKeys(TestContext.DataRow["city"].ToString());

            SelectElement country = new SelectElement(driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_ctlBioInfo1_ddlbCountry")));

            country.SelectByText("USA");    


            SelectElement state = new SelectElement(driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_ctlBioInfo1_ddlbState")));

            state.SelectByText("California");


            IWebElement zip = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_ctlBioInfo1_txtZipCode"));

            zip.SendKeys(TestContext.DataRow["zip"].ToString());

            // type | id=ctl00_ContentPlaceHolder1_txtTelephone | 514245362451
            IWebElement phone = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_ctlBioInfo1_txtTelephone"));

            phone.SendKeys(TestContext.DataRow["phone"].ToString());

            new SelectElement(driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_ctlBioInfo1_ddlbCitizenshipCountry"))).SelectByText("USA");
            // click | id=ctl00_ContentPlaceHolder1_rdoNaturalizedCitizenYes | 
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_ctlBioInfo1_rdoNaturalizedCitizenYes")).Click();


            IWebElement felonyNo = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_ctlAddQuestion1_rdoFelonyNo"));
 		
 		    //Check if its already selected? otherwise select the Checkbox
 		    //by calling click() method
 		    if (!felonyNo.Selected)
 			    felonyNo.Click();
 		
            
            IWebElement mdaEmpNo = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_ctlAddQuestion1_rdoEmployMDAndersonNo"));
 		
 		    //Check if its already selected? otherwise select the Checkbox
 		    //by calling click() method
 		    if (!mdaEmpNo.Selected)
 			    mdaEmpNo.Click();
 		
            
            IWebElement utempNo = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_ctlAddQuestion1_rdoEmployAnotherNo"));
 		
 		    //Check if its already selected? otherwise select the Checkbox
 		    //by calling click() method
 		    if (!utempNo.Selected)
 			    utempNo.Click();

            SelectElement selectMonth = new SelectElement(driver.FindElement(By.Name("ctl00$ContentPlaceHolder1$ctlVoluntary1$ddlbBirthMonth")));

            selectMonth.SelectByText("July");


            SelectElement selectDay = new SelectElement(driver.FindElement(By.Name("ctl00$ContentPlaceHolder1$ctlVoluntary1$ddlbBirthDay")));

            selectDay.SelectByText("30");

            SelectElement year = new SelectElement(driver.FindElement(By.Name("ctl00$ContentPlaceHolder1$ctlVoluntary1$ddlbBirthYear")));

            year.SelectByValue("1985");


            IWebElement gender = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_ctlVoluntary1_rdoGenderFemale"));
 		
 		    //Check if its already selected? otherwise select the Checkbox
 		    //by calling click() method
            if (!gender.Selected)
                gender.Click();


            IWebElement placeofBirth = driver.FindElement(By.Name("ctl00$ContentPlaceHolder1$ctlVoluntary1$txtBirthCity"));

            placeofBirth.SendKeys(TestContext.DataRow["place_of_birth"].ToString());


            IWebElement savecontinueButton = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_btnSaveContinue"));


            savecontinueButton.Click();

        }

        private void ApplicantLogin()
        {
            //var tracsID = driver.FindElement(By.Id("Login1_UserName"));
            //tracsID.Clear();
            IWebElement tracsID = driver.FindElement(By.Id("Login1_UserName"));

            tracsID.SendKeys(TestContext.DataRow["id"].ToString());

            //tracsID.SendKeys("T11018000J2");

            var password = driver.FindElement(By.Id("Login1_Password"));
            password.SendKeys("Password01");

            var loginButton = driver.FindElement(By.Id("Login1_LoginButton"));
            loginButton.Click();

            //var step1Link = driver.FindElement(By.Id("ctl00_LoginView2_UserMenu1_lnkBtnStep1"));

            //Assert.AreEqual("Step 1: Application Form", step1Link.Text);
        }

        private void CompleteSchoolInformation()
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            var step1Link = driver.FindElement(By.Id("ctl00_LoginView2_UserMenu1_lnkBtnStep1"));
            step1Link.Click();


            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            IWebElement continueButton = driver.FindElement(By.Id("btnContinue"));

            continueButton.Click();


            var medSchoolSection = driver.FindElement(By.CssSelector("#applicationViewTOC-left > ol > li:nth-child(2) > a"));

            medSchoolSection.Click();

            var schoolCity = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_ctlAcdemicHistory1_txtCollegeCity"));

            
            
            schoolCity.SendKeys("Houston");


            SelectElement schoolCountry = new SelectElement(driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_ctlAcdemicHistory1_ddlbCollegeCountry")));

            schoolCountry.SelectByText("USA");

            SelectElement schoolState = new SelectElement(driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_ctlAcdemicHistory1_lblState")));

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            schoolState.SelectByText("Texas");



            var schoolHome = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_ctlAcdemicHistory1_btnChangeAcadInst"));

            schoolHome.Click();

            //wait for school to be available to select
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IWebElement message = wait.Until<IWebElement>((d) =>
            {
                return d.FindElement(By.CssSelector("option[value='101648']"));
            });

        }
        [TestCleanup]
        public void TearDown() 
        {
            driver.Close();
        }
    }
}
