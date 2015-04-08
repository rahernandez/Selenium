using System;
using System.Collections;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.Events;
namespace SeleniumApiExamples
{
    [TestClass]
    public class FrameExcercise
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [TestInitialize]
        public void Setup() 
        {
            driver = new FirefoxDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
           //driver.Navigate().GoToUrl("http://www.compendiumdev.co.uk/selenium/frames");
        }

        [TestMethod]

        public void switchToFrameExampleTest()
        {
            driver.Navigate().GoToUrl("http://www.compendiumdev.co.uk/selenium/frames");

            Assert.AreEqual("Frameset Example Title (Example 6)", driver.Title);

            driver.SwitchTo().Frame("menu");

            driver.FindElement(By.CssSelector("a[href='frames_example_1.html']")).Click();

            string titleForExample1 = "Frameset Example Title (Example 1)";

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            Assert.AreEqual(titleForExample1, driver.Title);

        }

        [TestMethod]

        public void FrameExercise1Test()

        {
            driver.Navigate().GoToUrl("http://www.compendiumdev.co.uk/selenium/frames");

            //load the green page
            driver.SwitchTo().Frame("content");

            driver.FindElement(By.CssSelector("a[href='green.html']")).Click();

            wait.Until((d) => {return d.FindElement(By.CssSelector("h1[id='green']")); });
            
            //click back to original page
            driver.FindElement(By.CssSelector("a[href='content.html']")).Click();

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            IWebElement h1 = driver.FindElement(By.TagName("h1"));

            Assert.AreEqual("Content", h1.Text);

            

            //Assert.AreEqual()
        }

        [TestMethod]
        public void FrameExercise2Test()
        {
            driver.Navigate().GoToUrl("http://www.compendiumdev.co.uk/selenium/frames");

            driver.SwitchTo().Frame("menu");

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            driver.FindElement(By.CssSelector("a[href='iframe.html']")).Click();

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            
            //click on the example 5 iframe
            driver.SwitchTo().Frame(0);

            driver.FindElement(By.CssSelector("a[href='frames_example_5.html']")).Click();

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            driver.SwitchTo().Frame("content");

            driver.FindElement(By.CssSelector("a[href='index.html']")).Click();

            //Explicit Wait
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until((d) => { return d.Title.Equals("Frameset Example Title (Example 6)"); });


            //Assert.AreEqual()
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
