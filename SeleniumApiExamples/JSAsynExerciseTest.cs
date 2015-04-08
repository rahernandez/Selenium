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
    public class JSAsynExerciseTest
    {
        private IWebDriver driver;

        [TestInitialize]
        public void Setup()
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://www.compendiumdev.co.uk/selenium/basic_ajax.html");
            driver.Navigate().Refresh();
        }

        [TestMethod]
        public void AsyncJSExerciseTest()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            driver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(10));

            js.ExecuteScript("window.webdrivercallback = function(){};" +
                //extend the jQuery hide method to call our callback when it hides the gif
                "var _oldhide = $.fn.hide;" +
                "$.fn.hide = function(speed, callback) {" +
                "    var retThis = _oldhide.apply(this,arguments);" +
                "    window.webdrivercallback.apply();" +
                "    return retThis;" +
                "};"
            );



            //select Server
            IWebElement catSelect = driver.FindElement(By.Id("combo1"));
            catSelect.FindElement(By.CssSelector("option[value='3']")).Click();

            //need to wait here, can do it with Asyn JS
            js.ExecuteAsyncScript("window.webdrivercallback = arguments[arguments.length -1 ];");

            //then select Java
            IWebElement langSelect = driver.FindElement(By.Id("combo2"));
            langSelect.FindElement(By.CssSelector("option[value='23']")).Click();

            //submit the form
            IWebElement codeInIt = driver.FindElement(By.Name("submitbutton"));
            codeInIt.Click();

            IWebElement langUsed = driver.FindElement(By.Id("_valuelanguage_id"));
            Assert.AreEqual("23", langUsed.Text);

        }
        [TestMethod]
        public void waitInBrowserForTimeSample()
        {
            driver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(10));
            //NOTE: I am not sure if this the same as Java's currentTimeMillis
            long start = CurrentTimeMillis();
            Console.WriteLine(start);
            ((IJavaScriptExecutor)driver).ExecuteAsyncScript(
                "window.setTimeout(arguments[arguments.length - 1], 500);");

            Console.WriteLine(
                "Elapsed Time: " + (CurrentTimeMillis() - start));

            Assert.IsTrue((CurrentTimeMillis() - start) > 500);
        }
        private static readonly DateTime Jan1st1970 = new DateTime
            (1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        private static long CurrentTimeMillis()
        {
            return (long)(DateTime.UtcNow - Jan1st1970).TotalMilliseconds;
        }
        [TestMethod]
        public void useXMLHttpRequest()
        {
            driver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(10));

            Object response = ((IJavaScriptExecutor)driver).ExecuteAsyncScript(
                "var callback = arguments[arguments.length - 1];" +
                        "var xhr = new XMLHttpRequest();" +
                        "xhr.open('GET', '/selenium/ajaxselect.php?id=2', true);" +
                        "xhr.onreadystatechange = function() {" +
                        "  if (xhr.readyState == 4) {" +
                        "    callback(xhr.responseText);" +
                        "  }" +
                        "};" +
                        "xhr.send();");

            //cast the response to string
            Console.WriteLine((String)response);

            Assert.IsTrue(response.ToString().Contains("{optionValue:10, optionDisplay: 'C++'}"));
            

        //    Assert.IsTrue(response.ToString(("{optionValue:10, optionDisplay: 'C++'}"), );
        }
        [TestCleanup]
        public void TearDown()
        {
            driver.Close();
        }
    }
}