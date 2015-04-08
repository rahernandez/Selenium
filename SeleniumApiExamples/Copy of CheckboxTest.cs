using System;
using System.Collections;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SeleniumApiExamples
{
    [TestClass]
    public class RadioButtonTest
    {
        private IWebDriver driver;

        [TestInitialize]
        public void Setup() 
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://dl.dropbox.com/u/55228056/Config.html");
        }

        [TestMethod]
       
        public void TestRadioButton()
        {
 		    //Get the Radio Button as WebElement using it's value attribute
 		    IWebElement petrol = driver.FindElement(By.XPath("//input[@value='Petrol']"));
 		
 		    //Check if its already selected? otherwise select the Radio Button 
 		    //by calling click() method 
 		    if (!petrol.Selected)
 			    petrol.Click();
 		
 		    //Verify Radio Button is selected 
 		    Assert.IsTrue(petrol.Selected);
 		
 		    //We can also get all the Radio buttons from a Radio Group in a list
 		    //using findElements() method along with Radio Group identifier
 		    var fuel_type = driver.FindElements(By.Name("fuel_type"));
 		    foreach (IWebElement type in fuel_type)
 		    {
 			    //Search for Diesel Radio Button in the Radio Group and select it
 			    if(type.GetAttribute("value").Equals("Diesel"))
 			    {
                    if (!type.Selected)
                    {
                        type.Click();
                        Assert.IsTrue(type.Selected);
                        break;
                    }
 			    }
 		    }
         }

        [TestCleanup]
        public void TearDown() 
        {
            driver.Close();
        }
    }
}
