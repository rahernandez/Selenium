using System;
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
    public class ApplicantCanCreateAccountTes
    {
        private IWebDriver driver;

        [TestInitialize]
        public void Setup() 
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://www2dev.mdanderson.org/sapp/tracs-discover-utest/");
        }

        [TestMethod]
       
        public void applicantCreateAccountTest()
        {
 		    //put all elements in variable, send data, verify the applicant logged in.
            var applyLink = driver.FindElement(By.Id("Login1_lnkBtnHowDoIApply"));

            applyLink.Click();

            var otherPrograms = driver.FindElement(By.CssSelector("a[href='CreateAccount/SummerScienceSchedule.aspx?area=Other Programs']"));

            otherPrograms.Click();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            wait.Until((d) => d.FindElement(By.Id("ctl00_ContentPlaceHolder1_discoverRadGrid_ctl00_ctl08_btnProcessLink")));

            var apply = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_discoverRadGrid_ctl00_ctl08_btnProcessLink"));

            apply.Click();

            

            var agreeButton = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_btnAgree"));

            agreeButton.Click();

            var firstName = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_txtFName"));

            firstName.SendKeys("John");

            var lastName = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_txtLName"));

            lastName.SendKeys("Carmack");

            var email = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_txtEmail"));
            email.SendKeys("discovertester1@gmail.com");

            var confirmEmail = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_txtConfirmEmail"));
            confirmEmail.SendKeys("discovertester1@gmail.com");
            

            var password = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_txtPW"));
            var passwordConfirm = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_txtConfirmPW"));
            
            password.SendKeys("Password01");
            passwordConfirm.SendKeys("Password01");

            var midInitial = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_txtMiddleInitial"));

            midInitial.SendKeys("Y");

            SelectElement selectMonth = new SelectElement(driver.FindElement(By.Name("ctl00$ContentPlaceHolder1$lstMonth")));

            selectMonth.SelectByText("June");


            SelectElement selectDay = new SelectElement(driver.FindElement(By.Name("ctl00$ContentPlaceHolder1$lstDay")));

            selectDay.SelectByText("5");

            var city = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_txtBirthCity"));

            city.SendKeys("New York");


            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_btnConfirm")).Click();

            driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_btnSubmitConfirm")).Click();


            var p = driver.FindElement(By.CssSelector("#ctl00_ContentPlaceHolder1_divCreateAccountSuccess>p"));

            Assert.AreEqual("You have successfully registered a new account in DISCOVER System ™, the on-line recruitment system for educational opportunities at The University of Texas M. D. Anderson Cancer Center. Your DISCOVER ID will be required to access this account throughout the application process. Only one DISCOVER ID is created per account. If you wish to apply to multiple programs, you will need to create a new account for each application.", p.Text);

            Console.WriteLine(p);
         }

        [TestCleanup]
        public void TearDown() 
        {
            driver.Close();
        }
    }
}
