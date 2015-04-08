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
    public class WaitingExercisesTest
    {

        public static IWebDriver driver;

        [TestInitialize]
        public void Setup()
        {

        }
        [TestMethod]
        public void canReturnWebElementInsteadOfBooleanUsingAnonymousClass()
        {
            //using custom wait condition   
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://compendiumdev.co.uk/selenium/basic_ajax.html");

            //select Server from the dropdown list
            IWebElement categorySelect = driver.FindElement(By.Id("combo1"));
            categorySelect.FindElement(By.CssSelector("option[value='3']")).Click();
            //wait for Java to be available to select
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IWebElement message = wait.Until<IWebElement>((d) =>
            {
                return d.FindElement(By.CssSelector("option[value='23']"));
            });
            //select Java
            message.Click();
            Assert.AreEqual("Java", message.Text);

            //submit the form
            IWebElement codeInIt = driver.FindElement(By.Name("submitbutton"));
            codeInIt.Click();

            //assert code is 23
            IWebElement languageUsed = driver.FindElement(By.Id("_valuelanguage_id"));
            Assert.AreEqual("23", languageUsed.Text);
            Console.WriteLine(languageUsed.Text);

            driver.Close();

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
        [TestMethod]
        public void customExpectedConditionForTitleDoesNotContainUsingMethod()
        {
            WebDriverWait wait;
            IWebDriver driver = new FirefoxDriver();

            driver.Navigate().GoToUrl("http://compendiumdev.co.uk/selenium/basic_redirect.html");

            

            //gotobasic
            driver.FindElement(By.Id("delaygotobasic")).Click();
            //wait
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until((d) => { return d.Title.Contains("Web"); });
            string expectedRedirectUrl = "http://compendiumdev.co.uk/selenium/basic_web_page.html";
            //assert
            Assert.AreEqual(driver.Url, expectedRedirectUrl);



        }





        }
        //[TestCleanup]
        //public void TearDown()
        //{
        //    driver.Close();
        //}


       
    }

