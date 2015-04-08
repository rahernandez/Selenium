using System;
using System.Collections;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Diagnostics;
using System.Linq;


namespace SeleniumApiExamples
{
    [TestClass]
    public class MakeWaitReadable
    {

        public static IWebDriver driver;
        public static WebDriverWait wait;


        [TestInitialize]
        public void Setup()
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://compendiumdev.co.uk/selenium/basic_ajax.html");
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        }
        //[TestMethod]
        //public void wrapAnonymousClassesInMethods()
        //{
        //    IWebElement categorySelect = driver.FindElement(By.Id("combo1"));
        //    categorySelect.FindElement(By.CssSelector("option[value='3']")).Click();

        //    //wait for a thing, then use it
        //    IWebElement javaOption = wait.Until(optionWithValueDisplayed("23"));
        //    javaOption.Click();

        //    //the 2 above lines can writtes this way too:
        //    //wait.Until(optionWithValueDisplayed("23")).Click();

        //    //submit
        //    IWebElement codeInIt = driver.FindElement(By.Name("submitbutton"));
        //    codeInIt.Click();

        //    IWebElement languageUsed = driver.FindElement(By.Id("_valuelanguage_id"));
        //    Assert.AreEqual("23", languageUsed.Text);

        //}
        ////wrap anonymous classes in a method
        //public static Func<IWebDriver, IWebElement> optionWithValueDisplayed(string value)
        //{
        //    return (driver) =>
        //   {
        //       IWebElement retVal = driver.FindElement(By.CssSelector("option[value='" + value + "']"));
        //       Console.WriteLine(retVal);
        //       return retVal;
               
        //   };
        //}

        [TestMethod]
        public void importExpectedConditionMethodsStatically()
        {
            //public WebDriverExtensions();
            IWebElement categorySelect = driver.FindElement(By.Id("combo1"));
            categorySelect.FindElement(By.CssSelector("option[value='3']")).Click();

            //wait for a thing, then use it
            //static import for the ElementIsVisible method
            IWebElement javaOption = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("option[value='23']")));
            javaOption.Click();

            //the 2 above lines can writtes this way too:
            //wait.Until(optionWithValueDisplayed("23")).Click();

            //submit
            IWebElement codeInIt = driver.FindElement(By.Name("submitbutton"));
            codeInIt.Click();

            IWebElement languageUsed = driver.FindElement(By.Id("_valuelanguage_id"));
            Assert.AreEqual("23", languageUsed.Text);

        }
        ///// <summary>
        ///// An expectation for checking whether an element is visible.
        ///// </summary>
        ///// <param name="locator">The locator used to find the element.</param>
        ///// <returns>The <see cref="IWebElement"/> once it is located, visible and clickable.</returns>
        //public static Func<IWebDriver, IWebElement> ElementIsClickable(By locator)
        //{
        //    return driver =>
        //    {
        //        var element = driver.FindElement(locator);
        //        return (element != null && element.Displayed && element.Enabled) ? element : null;
        //    };
        //}

        //[TestMethod]
        //public void exampleUsingExpectedConditions()
        //{
        //    IWebElement javascript = driver.FindElement(By.Id("javascript_countdown_time"));

        //    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        //    wait.PollingInterval = TimeSpan.FromMilliseconds(100);
        //    wait.IgnoreExceptionTypes(typeof(NoSuchElementException));

        //    wait.Until((d) => d.FindElement(By.Id("javascript_countdown_time")).Text.EndsWith("04"));

        //    Assert.AreEqual("01:01:04", javascript.Text);

                    


        //}
        [TestCleanup]
        public void TearDown()
        {
            driver.Close();
        }


    }

}

