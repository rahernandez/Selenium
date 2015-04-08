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

            chrome = new ChromeDriver(@"C:\ChromeDriver\"); 

            

        }

        [TestMethod]
        public void basicChromeUsage()
        {

            

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

            IWebDriver oChrome = new ChromeDriver(options);

            oChrome.Navigate().GoToUrl("http://www.compendiumdev.co.uk/selenium/basic_html_form.html");


            Assert.AreEqual("HTML Form Elements", chrome.Title);

            //chrome.Quit();

        }

    }
}
