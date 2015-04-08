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
    public class UserInteractionExerciseTest
    {
        private IWebDriver driver;

        [TestInitialize]
        public void Setup()
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://compendiumdev.co.uk/selenium/gui_user_interactions.html");

        }
    
        [TestMethod]
        public void TestUserInteractionExercise()
        {

            var draggable = driver.FindElement(By.Id("draggable1"));
            var droppable = driver.FindElement(By.Id("droppable1"));

            //Select second and fourth row from table using Control Key.
            //Row Index start at 0
            Actions builder = new Actions(driver);
            builder.DragAndDrop(draggable, droppable).Perform();

            Assert.AreEqual("Dropped!", droppable.Text);
        }

        [TestMethod]
        public void TestUserInteractionExercise2()
        {

            var draggable = driver.FindElement(By.Id("draggable2"));
            var droppable = driver.FindElement(By.Id("droppable1"));

            //Select second and fourth row from table using Control Key.
            //Row Index start at 0
            Actions builder = new Actions(driver);
            builder.DragAndDrop(draggable, droppable).Perform();

            Assert.AreEqual("Get Off Me!", droppable.Text);
        }

        [TestMethod]
        public void TestUserInteractionExercise3()
        {

            var draggable = driver.FindElement(By.Id("draggable1"));
            var droppable = driver.FindElement(By.Id("droppable1"));

            //Select second and fourth row from table using Control Key.
            //Row Index start at 0
            draggable.Click();
            Actions builder = new Actions(driver);
            builder.KeyDown(Keys.Control).SendKeys("B").KeyUp(Keys.Control).Perform();

            Assert.AreEqual("Bwa! Ha! Ha!", draggable.Text);
        }

        [TestMethod]
        public void TestUserInteractionExercise4()
        {

            var draggable = driver.FindElement(By.Id("draggable1"));
            var droppable = driver.FindElement(By.Id("droppable1"));

            //Select second and fourth row from table using Control Key.
            //Row Index start at 0
            draggable.Click();
            Actions builder = new Actions(driver);
            builder.Click(draggable).KeyDown(Keys.Control).SendKeys(" u'\ue00d'").KeyDown(Keys.Control).Perform();

            Assert.AreEqual("Let GO!", droppable.Text);
        }

        [TestMethod]
        public void TestRowSelectionUsingShiftKey()
        {

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
            Assert.AreEqual(4, rows.Count);

           
        }

        [TestCleanup]
        public void TearDown()
        {
            driver.Close();
        }
    }
}
