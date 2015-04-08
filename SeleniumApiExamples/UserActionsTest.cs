using System;
using System.Collections;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Firefox;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SeleniumApiExamples
{
    [TestClass]
    public class UserActionTest
    {
        private IWebDriver driver;

        [TestInitialize]
        public void Setup() 
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://www.compendiumdev.co.uk/selenium/basic_html_form.html");
        }

        [TestMethod]
       
        public void TestUserActions()
        {
            var clickCheckBox1 = driver.FindElement(By.CssSelector("input[value='cb1']"));
            Actions builder = new Actions(driver);

            builder.Click(clickCheckBox1).Build().Perform();
            builder.Click(clickCheckBox1).Build().Perform();
            builder.Click(clickCheckBox1).Build().Perform();
            //builder.Perform();
            //builder.Perform();

            
            //put all elements in variable, send data, verify the applicant logged in.
            

         }

        [TestCleanup]
        public void TearDown() 
        {
            driver.Close();
        }
    }
}
