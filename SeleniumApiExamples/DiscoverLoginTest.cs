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
    public class ApplicantLoginTest
    {
        private IWebDriver driver;

        [TestInitialize]
        public void Setup() 
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://www2dev.mdanderson.org/sapp/tracs-discover-utest/");
        }

        [TestMethod]
       
        public void TestApplicantCanLogin()
        {
 		    //put all elements in variable, send data, verify the applicant logged in.
            var tracsID = driver.FindElement(By.Id("Login1_UserName"));
            tracsID.Clear();
            tracsID.SendKeys("T61017865R6");

            var password = driver.FindElement(By.Id("Login1_Password"));
            password.SendKeys("Password01");

            var loginButton = driver.FindElement(By.Id("Login1_LoginButton"));
            loginButton.Click();

            var step1Link = driver.FindElement(By.Id("ctl00_LoginView2_UserMenu1_lnkBtnStep1"));

            Assert.AreEqual("Step 1: Application Form", step1Link.Text);

         }

        [TestCleanup]
        public void TearDown() 
        {
            driver.Close();
        }
    }
}
