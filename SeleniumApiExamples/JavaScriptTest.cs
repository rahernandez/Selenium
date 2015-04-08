using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Interactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SeleniumApiExamples
{
    [TestClass]
    class JavaScriptTest
    {
        [TestMethod]
	    public void TestJavaScript()
	    {
            IWebDriver driver = new ChromeDriver(@"C:\ChromeDriver\");
            driver.Navigate().GoToUrl("http://www.google.com");

            IJavaScriptExecutor js = (IJavaScriptExecutor) driver;

            String title = (String)js.ExecuteScript("return document.title");
            Assert.AreEqual("Google", title);

            long links = (long)js.ExecuteScript("var links = document.getElementsByTagName('A'); return links.length");
            Assert.AreEqual(41, links); //Count of links may change

		    driver.Close();
	    }
    }
}
