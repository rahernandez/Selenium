using System;
using System.Collections;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;


namespace SeleniumApiExamples
{
    [TestClass]
    public class ManageWindowTest
    {
        private IWebDriver driver;


        [TestInitialize]
        public void Setup() 
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://www.compendiumdev.co.uk/selenium/bounce.html");
        }

        [TestMethod]
        public void manageWindowTest()
        {
            //setting position to new window

            IWindow window = driver.Manage().Window;


            Point position = window.Position;

            Point targetPosition = new Point(position.X = 10, position.Y = 20);

            window.Position = targetPosition;

            Point newLocation = window.Position;

            Assert.AreEqual(targetPosition.X, newLocation.X);
            Assert.AreEqual(targetPosition.Y, newLocation.Y);

            //Resizing the browser window
            Size targetSize = new Size(350, 400);
            //using the driver.Manage().    
            Size changeSize = driver.Manage().Window.Size;

            changeSize = new Size(350, 400);


            window.Size = changeSize;

            Size newSize = window.Size;

            Assert.AreEqual(changeSize, newSize);
            Console.WriteLine(changeSize);
            Console.WriteLine(newSize);

        }
        [TestMethod]
        public void maximiseWindowTest()
        {
            //setting window size to new size and assign driver window to the window variable
            Size targetSize = new Size(275, 275);
            IWindow window = driver.Manage().Window; 
            //
            window.Size = targetSize;
            //check size is by printing it
            Console.WriteLine(targetSize);

            window.Maximize();



            Assert.IsTrue(window.Size.Width > targetSize.Width);
            Assert.IsTrue(window.Size.Height > targetSize.Height);
            Console.WriteLine(targetSize.Width);
            Console.WriteLine(targetSize.Height);
            Console.WriteLine(window.Size.Width);
            Console.WriteLine(window.Size.Height);
        }
        [TestMethod]
        public void halfWindowTest()
        {
            //setting position to new window

            IWindow window = driver.Manage().Window;

            Size changeSize = driver.Manage().Window.Size;

            Console.WriteLine(changeSize);

            changeSize = new Size((changeSize.Width/2), (changeSize.Height/2));

            window.Size = changeSize;


            Console.WriteLine(changeSize);




            
        }
        [TestMethod]
        public void moveWindowToCenterTest()
        {
            //setting position to new window
            IWindow window = driver.Manage().Window;

            driver.Manage().Window.Maximize();

            Size fullScreenSize = driver.Manage().Window.Size;

            Point pos = driver.Manage().Window.Position;

            Size changeSize = new Size((fullScreenSize.Width / 2), (fullScreenSize.Height / 2));

            Point newPos = new Point((fullScreenSize.Width / 4), (fullScreenSize.Height / 4));

            window.Size = changeSize;

            window.Position = newPos;

            Console.WriteLine(changeSize);
            Console.WriteLine(newPos);

        }

        [TestCleanup]
        public void TearDown()
        {
            driver.Close();
        }
    }
}
