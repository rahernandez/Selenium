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
    public class CompleteBiodata
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
        [DeploymentItem("C:\\Users\\rahernandez2\\Documents\\GitHub\\selenium\\selenium2_exercises\\SeleniumApiExamples\\Data\\DataFile.xlsx")]
        [DataSource("System.Data.OleDB",
            @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=C:\Users\rahernandez2\Documents\GitHub\Selenium\selenium2_exercises\SeleniumApiExamples\Data\DataFile.xlsx; Extended Properties='Excel 12.0;HDR=yes';",
            "table1$",
            DataAccessMethod.Sequential)]  

        public void applicantCompleteBiodata()
        {
            ApplicantLogin();

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


            IWebElement continueButton1 = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_btnContinue"));

            continueButton1.Click();


            IWebElement biodataLink = driver.FindElement(By.CssSelector("#applicationViewTOC-left > ol > li:nth-child(1) > a"));

            biodataLink.Click();

            IWebElement SSN1 = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_txtSocial1"));

            SSN1.SendKeys(TestContext.DataRow["ssn1"].ToString());

            IWebElement SSN2 = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_txtSocial2"));

            SSN2.SendKeys(TestContext.DataRow["ssn2"].ToString());


            IWebElement SSN3 = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_txtSocial3"));

            SSN3.SendKeys(TestContext.DataRow["ssn3"].ToString());

            IWebElement addressOne = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_txtAddress1"));

            addressOne.SendKeys(TestContext.DataRow["address1"].ToString());

            IWebElement city = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_txtCity"));

            city.SendKeys(TestContext.DataRow["city"].ToString());

            SelectElement country = new SelectElement(driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_ddlbCountry")));

            country.SelectByText("USA");


            SelectElement state = new SelectElement(driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_ddlbState")));

            state.SelectByText("Texas");


            IWebElement zip = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_txtZipCode"));

            zip.SendKeys(TestContext.DataRow["ZIP"].ToString());

            // type | id=ctl00_ContentPlaceHolder1_txtTelephone | 514245362451
            IWebElement phone = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_txtTelephone"));

            phone.SendKeys(TestContext.DataRow["phone"].ToString());

            //same address checkbox checked
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_chkBxSameAddress")).Click();
            
            IWebElement emergencyContact = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_txtFullNameEmergContact"));

            emergencyContact.SendKeys(TestContext.DataRow["contact"].ToString());


            IWebElement relatioshipContact = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_txtRelationshipEmergContact"));

            relatioshipContact.SendKeys(TestContext.DataRow["relationship"].ToString());

            IWebElement emergencyPhone = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_txtTelephoneEmergContact"));

            emergencyPhone.SendKeys(TestContext.DataRow["emergency_phone"].ToString());
           
            // type | id=ctl00_ContentPlaceHolder1_txtAddress1EmergContact | 2890 Jagerkurkey Avenue
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_txtAddress1EmergContact")).Clear();
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_txtAddress1EmergContact")).SendKeys("2890 Jagerkurkey Avenue");
            // type | id=ctl00_ContentPlaceHolder1_txtAddress2EmergContact | 20-C100
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_txtAddress2EmergContact")).Clear();
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_txtAddress2EmergContact")).SendKeys("20-C100");
            // type | id=ctl00_ContentPlaceHolder1_txtCityEmergContact | Istanbul
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_txtCityEmergContact")).Clear();
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_txtCityEmergContact")).SendKeys("Istanbul");
            // select | id=ctl00_ContentPlaceHolder1_ddlbCountryEmergContact | label=Turkey
            new SelectElement(driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_ddlbCountryEmergContact"))).SelectByText("Turkey");
            // type | id=ctl00_ContentPlaceHolder1_txtZipCodeEmergContact | 478524
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_txtZipCodeEmergContact")).Clear();

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_txtZipCodeEmergContact")).SendKeys("478524");
            // select | id=ctl00_ContentPlaceHolder1_ddlbCitizenshipCountry | label=USA
            new SelectElement(driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_ddlbCitizenshipCountry"))).SelectByText("USA");
            // click | id=ctl00_ContentPlaceHolder1_rdoNaturalizedCitizenYes | 
            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_rdoNaturalizedCitizenYes")).Click();


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

            //IWebElement gpaText = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_ctlAddQuestion1_txtGPA"));

            //gpaText.SendKeys("3.99");

            IWebElement savecontinueButton = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_btnSaveContinue"));

            savecontinueButton.Click();

        }

        private void ApplicantLogin()
        {
            var tracsID = driver.FindElement(By.Id("Login1_UserName"));
            tracsID.Clear();
            tracsID.SendKeys("T01017783B2");

            var password = driver.FindElement(By.Id("Login1_Password"));
            password.SendKeys("Password01");

            var loginButton = driver.FindElement(By.Id("Login1_LoginButton"));
            loginButton.Click();

            //var step1Link = driver.FindElement(By.Id("ctl00_LoginView2_UserMenu1_lnkBtnStep1"));

            //Assert.AreEqual("Step 1: Application Form", step1Link.Text);
        }

        [TestCleanup]
        public void TearDown() 
        {
            driver.Close();
        }
    }
}
