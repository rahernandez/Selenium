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
    class DoubleClickTest
    {
        [TestMethod]
	    public void TestDoubleClick()
	    {
            IWebDriver driver = new ChromeDriver(@"C:\ChromeDriver\");
            driver.Navigate().GoToUrl("http://dl.dropbox.com/u/55228056/DoubleClickDemo.html");
		    
		    IWebElement message = driver.FindElement(By.Id("message"));
			
		    //Verify color is Blue
		    Assert.AreEqual("rgba(0, 0, 255, 1)",message.GetCssValue("background-color").ToString());
		
		    Actions builder = new Actions(driver);
		    builder.DoubleClick(message).Build().Perform();
		
		    //Verify Color is Yellow
		    Assert.AreEqual("rgba(255, 255, 0, 1)",message.GetCssValue("background-color").ToString());
		
		    driver.Close();
	    }
    }
}
