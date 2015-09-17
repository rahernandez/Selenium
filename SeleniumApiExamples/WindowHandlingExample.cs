using System;
using System.Collections;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SeleniumApiExamples
{
    [TestClass]
    public class WindowHandlingExample
    {
        private IWebDriver driver;

        [TestInitialize]
        public void Setup() 
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://www.compendiumdev.co.uk/selenium/frames");
        }

        [TestMethod]
        public void WindowHandlingTestExample()
        {
            
            //Java = getWindowHandle() | C# = CurrentWindowandle
            string framesWindowHandle = driver.CurrentWindowHandle;

            Assert.AreEqual(1, driver.WindowHandles.Count);

            driver.SwitchTo().Frame("content");

            driver.FindElement(By.CssSelector("a[href='http://www.seleniumsimplified.com']")).Click();

            Assert.AreEqual(2, driver.WindowHandles.Count);

            Console.Write(driver.WindowHandles.Count);

            //string myWindows = driver.CurrentWindowHandle;

            string newWindowHandle = "";

            foreach (string aHandle in (driver.WindowHandles))
            {
                if (framesWindowHandle != aHandle)
                {
                    newWindowHandle = aHandle;
                }
            }

            driver.SwitchTo().Window(newWindowHandle);

            Assert.AreEqual("Selenium Simplified » Automated Browser Testing with Selenium 2 WebDriver – Made Simple", driver.Title);

            Console.Write(driver.Title);
        }

        [TestMethod]
        public void WindowHandlingTestExercise1()
        {

            //Java = getWindowHandle() | C# = CurrentWindowandle
            var framesWindowHandle = driver.CurrentWindowHandle;
            //Assert.AreEqual(1, driver.WindowHandles.Count);

            driver.SwitchTo().Frame("content");

            driver.FindElement(By.CssSelector("a[href='http://www.seleniumsimplified.com']")).Click();

            var newWindowHandle = framesWindowHandle;

            IEnumerator<string> aHandle = driver.WindowHandles.GetEnumerator();
            // trying to find the handle for the new window
            
            while (newWindowHandle.Equals(framesWindowHandle) && aHandle.MoveNext())
            {
                newWindowHandle = aHandle.Current;
            }

            driver.SwitchTo().Window(newWindowHandle);

            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.TitleContains("Selenium Simplified"));

            //Assert is true does not work. Error: cannot convert string to boolean
            ///Assert.IsTrue("Expected Selenium Simplified Site", driver.Title.Contains("Selenium Simplified"));

            Assert.AreEqual("Selenium Simplified » Automated Browser Testing with Selenium 2 WebDriver – Made Simple", driver.Title);

            driver.SwitchTo().Window(framesWindowHandle);

            Assert.AreEqual("Frameset Example Title (Example 6)", driver.Title);

            driver.SwitchTo().Window(framesWindowHandle);



        }

        [TestMethod]
        public void WindowHandlingTestExercise2()
        {

            //Java = getWindowHandle() | C# = CurrentWindowandle
            var framesWindowHandle = driver.CurrentWindowHandle;
            //Assert.AreEqual(1, driver.WindowHandles.Count);   

            driver.SwitchTo().Frame("content");

            driver.FindElement(By.CssSelector("a[id='goevil']")).Click();

            driver.FindElement(By.CssSelector("a[target='compdev']")).Click();

            driver.SwitchTo().Window("compdev");

            Assert.AreEqual("Software Testing Essays, Book Reviews and Information", driver.Title);

            driver.SwitchTo().Window("evil");

            Assert.AreEqual("Home | EvilTester.com", driver.Title);

            driver.SwitchTo().Window(framesWindowHandle);

            Assert.AreEqual("Frameset Example Title (Example 6)", driver.Title);

            driver.SwitchTo().Window("compdev");

            driver.Close();

            Assert.AreEqual(2, driver.WindowHandles.Count);

            driver.SwitchTo().Window("evil");

            driver.Close();

            Assert.AreEqual(1, driver.WindowHandles.Count);


        }
        //[TestCleanup]
        //public void TearDown() 
        //{
        //    driver.Close();
        //}
    }
}
