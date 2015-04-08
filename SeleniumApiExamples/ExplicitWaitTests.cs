using System;
using System.Collections;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ControllingTestFlowExamples
{
   [TestClass]   
    class ExplicitWaitTests
    {
        [TestMethod]
 	    public void TestExplicitWait()
 	    {
 		    IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://dl.dropbox.com/u/55228056/AjaxDemo.html");
 		
            try 
            {
 			    IWebElement page4button = driver.FindElement(By.LinkText("Page 4"));
 			    page4button.Click();

            //Create Wait using WebDriverWait. 
            //This will wait for 5 seconds for timeout before page4 //element is found
            //Element is found in specified time limit test will move to //the text step 
            //instead of waiting for 10 seconds
            //Expected condition is expecting a WebElement to be returned //after findElement finds the 
            //element with specified locator
               WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
               IWebElement message = wait.Until<IWebElement>((d) =>
               {
                    return d.FindElement(By.Id("page4"));
               });

 			    Assert.IsTrue(message.Text.Contains("Nunc nibh tortor"));
 			
 		    } 
            catch (NoSuchElementException e) 
            {
 			    Assert.Fail("Element not found!!");
 		    } finally {
 			    driver.Close();
 		    }
 	    }

       [TestMethod]
	    public void TestExplicitWaitByTitle()
	    {
            //IWebDriver driver = new ChromeDriver(@"C:\ChromeDriver");
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://www.google.com");
		    IWebElement query = driver.FindElement(By.Name("q"));
		    query.SendKeys("selenium");
		    query.Submit();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until((d) => { return d.Title.ToLower().StartsWith("selenium"); });
            Assert.IsTrue(driver.Title.ToLower().StartsWith("selenium"));
            driver.Close();
	    }
    }
}
