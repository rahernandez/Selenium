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
    public class AlertExcercise
    {
        private IWebDriver driver;

        [TestInitialize]
        public void Setup() 
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://compendiumdev.co.uk/selenium/alerts.html");
        }

        [TestMethod]

        public void TestGetTextFromAlert()
        {
            IWebElement alertButton = driver.FindElement(By.Id("alertexamples"));

            alertButton.Click();

            string alertMessage = "I am an alert box!";

            Assert.AreEqual(alertMessage, driver.SwitchTo().Alert().Text);

            driver.SwitchTo().Alert().Accept();

        }

        [TestMethod]

        public void TestDimissAlert()
        {
            IWebElement alertButton = driver.FindElement(By.Id("alertexamples"));

            alertButton.Click();

            string alertMessage = "I am an alert box!";

            Assert.AreEqual(alertMessage, driver.SwitchTo().Alert().Text);

            driver.SwitchTo().Alert().Dismiss();


        }

        [TestMethod]

        public void TestConfirmHandling()
        {
            IWebElement confirmButton;
            IWebElement confirmResult;

            confirmButton = driver.FindElement(By.Id("confirmexample"));
            confirmResult = driver.FindElement(By.Id("confirmreturn"));

            Assert.AreEqual("cret", confirmResult.Text);
            
            confirmButton.Click();

            string alertMessage = "I am a confirm alert";

            IAlert confirmAlert = driver.SwitchTo().Alert();

            Assert.AreEqual(alertMessage, confirmAlert.Text);

            confirmAlert.Accept();

            Assert.AreEqual("true", confirmResult.Text);


        }


        [TestCleanup]
        public void TearDown() 
        {
            driver.Close();
        }
    }
}
