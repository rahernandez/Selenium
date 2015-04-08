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
    class DragDropTest
    {
        [TestMethod]
        public void TestDragDrop()
        {
            IWebDriver driver = new ChromeDriver(@"C:\ChromeDriver\");
            driver.Navigate().GoToUrl("http://dl.dropbox.com/u/55228056/DragDropDemo.html");

            IWebElement source = driver.FindElement(By.Id("draggable"));
            IWebElement target = driver.FindElement(By.Id("droppable"));

            Actions builder = new Actions(driver);
            builder.DragAndDrop(source, target).Perform();
            Assert.AreEqual("Dropped!", target.Text);

            driver.Close();
        }
    }
}
