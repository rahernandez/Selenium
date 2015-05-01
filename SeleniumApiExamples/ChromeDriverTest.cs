using System;
using System.Reflection;
using System.IO;
using System.Collections;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SeleniumApiExamples
{
    [TestClass]
    public class ChromeDriverTest
    {
        private IWebDriver chrome;

        [TestInitialize]
        public void Setup()
        {

            chrome = new ChromeDriver(@"C:\webdrivers\chrome"); 

        }

        [TestMethod]
        public void basicChromeUsage()
        {

            //ChromeDriver chrome = new ChromeDriver(@"C:\webdrivers\chrome");

            chrome.Navigate().GoToUrl("http://www.compendiumdev.co.uk/selenium/basic_html_form.html");


            chrome.Quit();
        }
        [TestMethod]
        public void basicChromeDriverOptions()
        {



            ChromeOptions options = new ChromeOptions();


            options.AddArgument("test-type");
            options.AddArgument("disable-plugins");
            options.AddArgument("disable-extensions");
            options.AddArgument("--start-maximized");

            ChromeDriver driver = new ChromeDriver(@"C:\webdrivers\chrome\", options);

            driver.Navigate().GoToUrl("http://www.compendiumdev.co.uk/selenium/basic_html_form.html");


            Assert.AreEqual("HTML Form Elements", driver.Title);

            //chrome.Quit();

        }

    }
}
