using System;
using System.Drawing;
using System.Collections;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace SeleniumApiExamples
{
    [TestClass]
    public class JavaScriptExercises
    {
        private IWebDriver driver;

        [TestInitialize]
        public void Setup()
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://www.compendiumdev.co.uk/selenium/canvas_basic.html");
            driver.Navigate().Refresh();
        }

        [TestMethod]
        public void JavaScriptExerciseTest()
        {
            //why use javascript when creating tests?  
            //custom sync, workarounds, make app testable (i.e. adjust hidden fields, amend value), simulate 
            //hard to reach condition, test flash and HTML5

            //Cast driver to JavaScriptExecutor to access the JS methods
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            int actionsCount = driver.FindElements(By.CssSelector("#commandlist li")).Count;

            //Execute the draw Function in the Page
            js.ExecuteScript("draw(1, 150,150,40, '#FF1CA0A');");  //execute the js that is on the page
            actionsCount = driver.FindElements(By.CssSelector("#commandlist li")).Count;

            Assert.AreEqual(3, actionsCount);
        }

        [TestMethod]
        public void DrawFunctionJSTest()
        {


            //Cast driver to JavaScriptExecutor to access the JS methods
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;



            int actionsCount = driver.FindElements(By.CssSelector("#commandlist li")).Count;

            Assert.AreEqual(2, actionsCount);

            //Execute the draw Function in the Page
            for (int testLoop = 0; testLoop < 10; testLoop++)
            {
                js.ExecuteScript("draw(0, arguments[0], arguments[1], 20, arguments[2]);",
                        testLoop * 20,
                        testLoop * 20,
                        "#" + testLoop + testLoop + "0000");

            }
            actionsCount = driver.FindElements(By.CssSelector("#commandlist li")).Count;

            Assert.AreEqual(12, actionsCount);
            Console.WriteLine(actionsCount);
        }

        [TestMethod]
        public void returnValuesFromJS()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            Assert.AreEqual(40L, js.ExecuteScript("return (arguments[0]+arguments[1]);",
                                20, 20));
        }

        [TestMethod]
        public void returnHardCodedValuesFromJS()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            Assert.AreEqual(10L, js.ExecuteScript("return 10;"));
        }


        [TestMethod]
        public void changeTitleUsingJS()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            Assert.AreEqual("Javascript Canvas Example", driver.Title);
            js.ExecuteScript("document.title=arguments[0]", "bob");

            Assert.AreEqual("bob", driver.Title);
            Console.WriteLine(driver.Title);


        }
        [TestMethod]
        public void useJQueryToHideBodyWithNoParams()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            Assert.IsTrue(driver.FindElement(By.CssSelector("#commands")).Displayed);

            js.ExecuteScript("$('body').hide();");

            Assert.IsFalse(driver.FindElement(By.CssSelector("#commands")).Displayed);

        }

        [TestMethod]
        public void hideWebElementAsParam()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            Assert.IsTrue(driver.FindElement(By.CssSelector("#commands")).Displayed);


            //Opera throws internal error for this particualr JS
            js.ExecuteScript("$(arguments[0]).hide();", driver.FindElement(By.CssSelector("#commands")));
            Assert.IsFalse(driver.FindElement(By.CssSelector("#commands")).Displayed);

        }
        [TestMethod]
        public void jsRunAsAnAnonymousFunctionButWeCanLeaveSomeBethind()
        {
        //only FF handles alerts; IE blocks; Chrome throws exception; Opera hates alerts
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            //this code runs as an anonymous function with no trace left
            js.ExecuteScript("alert('alert triggered by webdriver');");

            var alertText = driver.SwitchTo().Alert().Text;

            Assert.AreEqual("alert triggered by webdriver", alertText);
            driver.SwitchTo().Alert().Accept();

            //this code creates a function that will persist as we added it to the global window
            js.ExecuteScript("window.webdriveralert = function(){alert('stored alert triggered by webdriver');};" +
                    "window.webdriveralert.call();");

            var secondAlert = driver.SwitchTo().Alert().Text;

            Assert.AreEqual("stored alert triggered by webdriver", secondAlert);
            driver.SwitchTo().Alert().Accept();
            //this can only work if we managed to leave js lying around
            js.ExecuteScript("window.webdriveralert.call();");
            var thirdAlert = driver.SwitchTo().Alert().Text;

            Assert.AreEqual("stored alert triggered by webdriver", thirdAlert);
            driver.SwitchTo().Alert().Accept();
        }
        [TestMethod]
        public void jsRunsAsAnAnonymousFuntionButWeCanLeaveSomeBehindOtherBrowsers()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            //this example does not use alerts, using title instead
            //this code runs as an anonymous function with no trace left
            js.ExecuteScript("document.title='title changed by webdriver';");

            Assert.AreEqual("title changed by webdriver", driver.Title);

            //this code creates a function that will persist as we have added it to the global window
            js.ExecuteScript("window.webdrivertitlechange = function(){document.title='stored title changed by webdriver';};" +
                "window.webdrivertitlechange.call();");

            Assert.AreEqual("stored title changed by webdriver", driver.Title);

            //this can only work if we managed to leave hs lying around
            js.ExecuteScript("document.title='title changed by webdriver';");
            js.ExecuteScript("window.webdrivertitlechange.call();");

            Assert.AreEqual("stored title changed by webdriver", driver.Title);
        }

        [TestMethod]
        public void openNewTabwithJSTest()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            //this example does not use alerts, using title instead
            //this code runs as an anonymous function with no trace left
            js.ExecuteScript("window.opennewtab  = function openwindow(url){window.open(url, 'blank');window.focus();};" +
                "window.opennewtab.call();");
        }
        [TestCleanup]
        public void TearDown()
        {
            driver.Close();
        }
    }
}
