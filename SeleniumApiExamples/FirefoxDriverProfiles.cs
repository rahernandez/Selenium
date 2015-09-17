using System;
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
    public class FirefoxDriverProfile
    {
        
        [TestMethod]
        public void firefoxDriverWithCapabilitiesForProxy()
        {
            var firefoxProfile = new FirefoxProfile();

            var proxy = new Proxy();

            proxy.HttpProxy = "localhost:8888";

            firefoxProfile.SetProxyPreferences(proxy);

            var driver = new FirefoxDriver(firefoxProfile);

            driver.Navigate().GoToUrl("http://www.compendiumdev.co.uk/selenium/basic_html_form.html");

            Assert.AreEqual("HTML Form Elements", driver.Title);

            driver.Quit();

        }
        [TestMethod]
        public void firefoxUseExtensions()
        {
            FirefoxProfile profile = new FirefoxProfile();

            profile.AddExtension(@"C:\firebug\firebug@software.joehewitt.com.xpi");
            profile.SetPreference("extensions.firebug.currentVersion", "2.0.8");

            IWebDriver firefox = new FirefoxDriver(profile);

            firefox.Navigate().GoToUrl("http://www.compendiumdev.co.uk/selenium/basic_html_form.html");

            Assert.AreEqual("HTML Form Elements", firefox.Title);

            //firefox.Quit();
 
        }

        [TestMethod]
        public void phantomJSTest()
        {


            const string PhantomDir = @"C:\Users\robertoh\Source\Repos\Selenium\packages\PhantomJS.2.0.0\tools\phantomjs\";
            IWebDriver driver = new PhantomJSDriver(PhantomDir);

            driver.Navigate().GoToUrl("http://www.google.com");

            IWebElement element = driver.FindElement(By.Name("q"));
            string stringToSearchFor = "BDDfy";
            element.SendKeys(stringToSearchFor);
            element.Submit();

            Assert.IsTrue(driver.Title.Contains("BDDfy"));

            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(@"C:\webdriver\screenshot\google.png", System.Drawing.Imaging.ImageFormat.Png);
        }


    }
}
