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
    public class AdvisorLoginTest
    {
        private IWebDriver driver;

        [TestInitialize]
        public void Setup() 
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://dctwlfsaatlas/");
        }

        [TestMethod]
       
        public void AdvisorLogTestSuccessTest()
        {
 		    //put all elements in variable, send data, verify the applicant logged in.
            var tracsID = driver.FindElement(By.Id("UserName"));
            tracsID.Clear();
            tracsID.SendKeys("rahernandez2");

            var password = driver.FindElement(By.Id("Password"));
          

            var loginButton = driver.FindElement(By.ClassName("pushbuttonwide"));
            loginButton.Click();

            var recNavItem = driver.FindElement(By.CssSelector("img[src='images/rnavigatorbtn.gif']"));

            Assert.IsTrue(recNavItem.Displayed);


         }

        [TestCleanup]
        public void TearDown() 
        {
            driver.Close();
        }
    }
}
