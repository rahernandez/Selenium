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
    public class CookieDemoTest
    {
        private IWebDriver driver;

        [TestInitialize]
        public void Setup()
        {
            driver = new FirefoxDriver();
            
        }
        
        
        [TestMethod]
	    public void CookieTest()
	    {
            

            driver.Navigate().GoToUrl("http://compendiumdev.co.uk/selenium/search.php");

            driver.Manage().Cookies.DeleteAllCookies();

            driver.Navigate().Refresh();

            Cookie aCookie = driver.Manage().Cookies.GetCookieNamed("SeleniumSimplifiedLastSearch");

            Assert.AreEqual(null, aCookie);


	    }

        [TestMethod]
        public void SearchNumberOfVisitTest()
        {

            driver.Navigate().GoToUrl("http://compendiumdev.co.uk/selenium/search.php");

            driver.Manage().Cookies.DeleteAllCookies();

            driver.Navigate().Refresh();

            Cookie aCookie = driver.Manage().Cookies.GetCookieNamed("seleniumSimplifiedSearchNumVisits");

            Assert.AreEqual(1, Convert.ToInt16(aCookie.Value));

            Console.WriteLine(aCookie.Value);
        }

        [TestMethod]
        public void SetNumberOfVis()
        {

            driver.Navigate().GoToUrl("http://compendiumdev.co.uk/selenium/search.php");

            driver.Manage().Cookies.DeleteAllCookies();

            driver.Navigate().Refresh();

            Cookie aCookie = driver.Manage().Cookies.GetCookieNamed("seleniumSimplifiedSearchNumVisits");

            Cookie anewCookie = new Cookie(aCookie.Name, "42");

            driver.Manage().Cookies.DeleteCookie(aCookie);
            driver.Manage().Cookies.AddCookie(anewCookie);

            Console.WriteLine(anewCookie.Value);
            //Assert.AreEqual(1, Convert.ToInt16(aCookie.Value));

        }



        [TestCleanup]
        public void TearDown()
        {

            driver.Close();
        }
    }
}
