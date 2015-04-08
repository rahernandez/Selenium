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
    class RowSelectionTests
    {
        private IWebDriver driver;

        [TestInitialize]
        public void Setup() 
        {
            driver = new ChromeDriver(@"C:\ChromeDriver\");
            driver.Navigate().GoToUrl("http://component-showcase.icesoft.org/component-showcase/showcase.iface");
            driver.FindElement(By.LinkText("Table")).Click();
            driver.FindElement(By.LinkText("Row Selection")).Click();
            driver.FindElement(By.XPath("//label[contains(text(),'Multiple')]")).Click();
        }

        [TestMethod]
	    public void TestRowSelectionUsingControlKey() {
		
		    var tableRows = driver.FindElements(By.XPath("//table[@class='iceDatTbl']/tbody/tr"));
				
		    //Select second and fourth row from table using Control Key.
		    //Row Index start at 0
		    Actions builder = new Actions(driver);
		    builder.Click(tableRows[1])
				    .KeyDown(Keys.Control)
				    .Click(tableRows[3])
				    .KeyUp(Keys.Control)
				    .Build().Perform();
		
		    //Verify Selected Row table shows two rows selected
		    var rows = driver.FindElements(By.XPath("//div[@class='icePnlGrp exampleBox']/table[@class='iceDatTbl']/tbody/tr"));
		    Assert.AreEqual(2,rows.Count);
	    }
	
	    [TestMethod]
	    public void TestRowSelectionUsingShiftKey() {
		
		    var tableRows = driver.FindElements(By.XPath("//table[@class='iceDatTbl']/tbody/tr"));

		    //Select first row to fourth row from Table using Shift Key
		    //Row Index start at 0
		    Actions builder = new Actions(driver);
		    builder.Click(tableRows[0])
				    .KeyDown(Keys.Shift)
				    .Click(tableRows[1])
				    .Click(tableRows[2])
				    .Click(tableRows[3])
				    .KeyUp(Keys.Shift)
				    .Build().Perform();
		
		    var rows = driver.FindElements(By.XPath("//div[@class='icePnlGrp exampleBox']/table[@class='iceDatTbl']/tbody/tr"));
		    Assert.AreEqual(4,rows.Count);
	    }

        [TestCleanup]
        public void TearDown() 
        {
            driver.Close();
        }
    }
}
