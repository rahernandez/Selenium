using System;
using System.Collections;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using System.Threading.Tasks;



namespace SeleniumApiExamples
{
    [TestClass]
    public class SynchronizationExerciseTestOne
    {
        IWebDriver driver;
        //private WebDriverWait wait;
        private WebDriverWait wait;

        [TestInitialize]
        public void Setup()
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://www.compendiumdev.co.uk/selenium/basic_ajax.html");
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [TestMethod]
        public void SyncTestExerciseOne()
        {
            
            //my answer using SelectElement
            SelectElement firsCombo = new SelectElement(driver.FindElement(By.Id("combo1")));
            
            firsCombo.SelectByText("Server");

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("combo2")));
           
            SelectElement secondCombo = new SelectElement(driver.FindElement(By.Id("combo2")));

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            secondCombo.SelectByText("Java");

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            var codeButton = driver.FindElement(By.Name("submitbutton"));

            codeButton.Click();

            var languageText = driver.FindElement(By.Id("_valuelanguage_id"));

            Console.WriteLine(languageText.Text);

            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(10));

            Assert.AreEqual("23", languageText.Text);


        }
        [TestMethod]
        public void SyncTestExerciseAnswerOne()
        {
            //AR answer using methods, webdriverwait and expected conditions 
            //call method to select value 3 "Server"
            startBrowserAndSelectServer();

            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists(
                By.CssSelector("option[value='23']")));

            //then select Java
            selectJavaSubmitFormAndCheckResult();




        }

        private void selectJavaSubmitFormAndCheckResult()
        {
            IWebElement languageSelect = driver.FindElement(By.Id("combo2"));
            languageSelect.FindElement(By.CssSelector("option[value='23']")).Click();

            //submit form
            IWebElement codeInIt = driver.FindElement(By.Name("submitbutton"));

            codeInIt.Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.TitleIs("Processed Form Details"));
            IWebElement languageWeUsed = driver.FindElement(By.Id("_valuelanguage_id"));
            Assert.AreEqual("23", languageWeUsed.Text);
        }

        private void startBrowserAndSelectServer()
        {
            IWebElement categorySelect = driver.FindElement(By.Id("combo1"));
            categorySelect.FindElement(By.CssSelector("option[value='3']")).Click();
        }

        [TestCleanup]
        public void TearDown()
        {
            driver.Close();
        }
    }
}
