using System;
using System.Collections;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace SeleniumApiExamples
{
    [TestClass]
    public class ElementTests
    {
        private IWebDriver driver;

        [TestInitialize]
        public void Setup() 
        {
            driver = new ChromeDriver(@"C:\ChromeDriver\");
            driver.Navigate().GoToUrl("http://dl.dropbox.com/u/55228056/DoubleClickDemo.html");
        }

        [TestMethod]
        public void TestElementText()
        {
            //Get the message Element
            //IWebElement message = driver.FindElement(By.Id("message"), 10);

           //Verify message element's text displays "Click on me and my color will change"
            //Assert.AreEqual("Click on me and my color will change", message.Text);

            //Get the area Element
            //IWebElement area = driver.FindElement(By.Id("area"));

            //Verify area element's text displays "Div's Text\nSpan's Text"
            //Assert.AreEqual("Div's Text\r\nSpan's Text", area.Text);
        }

        [TestMethod]
        public void TestElementAttribute()
        {
            IWebElement message = driver.FindElement(By.Id("message"));
            Assert.AreEqual("justify", message.GetAttribute("align"));
        }

        [TestMethod]
	    public void TestElementStyle()
	    {
		    IWebElement message = driver.FindElement(By.Id("message"));
		    String width = message.GetCssValue("width");
		    Assert.AreEqual("150px",width);
	    }

        [TestCleanup]
        public void TearDown() 
        {
            driver.Close();
        }
    }
}
