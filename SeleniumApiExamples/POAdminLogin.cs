using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SeleniumApiExamples
{
    [TestClass]
    public class POAdminLoginTest
    {
        private IWebDriver driver;
        
        [TestInitialize]
        public void Setup()
        {

            driver = new ChromeDriver(@"C:\ChromeDriver"); 

            

            driver.Navigate().GoToUrl("http://dcswldist/PostOffice-UnitTest/");

            driver.Manage().Window.Maximize();
        }
        [TestMethod]
        public void SearchbyLastNameTest()
        {
        //go to PO UT, login
            AdminLogin();
            //searchbyTracsid();
            SearchByLastName();



       
            
        }

        private void SearchByLastName()
        {
            var lastNameBox = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_discGridApplicantSearch_ctl00_ctl02_ctl03_ddlbLastNameFilterList_Input"));

            lastNameBox.Clear();
            lastNameBox.SendKeys("Ortiz");
            lastNameBox.SendKeys(Keys.Tab);

            driver.Navigate().Refresh();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IWebElement message = wait.Until<IWebElement>((d) =>
            {
                return d.FindElement(By.CssSelector("#ctl00_ContentPlaceHolder1_discGridApplicantSearch_ctl00__0.rgRow td.rgSorted"));
            });
            
            IWebElement rowResults = driver.FindElement(By.CssSelector("#ctl00_ContentPlaceHolder1_discGridApplicantSearch_ctl00__0.rgRow td.rgSorted"));
            

            string text = rowResults.Text;

            Console.WriteLine(text);

            Assert.AreEqual("Ortiz", rowResults.Text);

 
        }
        private void searchbyTracsid()
        {
            var lastNameBox = driver.FindElement(By.Id("ctl00_ContentPlaceHolder1_discGridApplicantSearch_ctl00_ctl02_ctl03_ddlbTracsIDFilterList_Input"));

            lastNameBox.Clear();
            lastNameBox.SendKeys("T21018084Y3");
            lastNameBox.SendKeys(Keys.Tab);

            driver.Navigate().Refresh();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IWebElement message = wait.Until<IWebElement>((d) =>
            {
                return d.FindElement(By.CssSelector("#ctl00_ContentPlaceHolder1_discGridApplicantSearch_ctl00__0.rgRow td.rgSorted"));
            });
            
            IWebElement rowResults = driver.FindElement(By.CssSelector("#ctl00_ContentPlaceHolder1_discGridApplicantSearch_ctl00__0.rgRow td.rgSorted"));
            

            string text = rowResults.Text;

            Console.WriteLine(text);

            Assert.AreEqual("LaRusso", rowResults.Text);
        }
        private void AdminLogin()
        {

            
            var loginID = driver.FindElement(By.Id("Login1_UserName"));
            var pass = driver.FindElement(By.Id("Login1_Password"));
            var logInBtn = driver.FindElement(By.Id("Login1_LoginButton"));

            logInBtn.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IWebElement message = wait.Until<IWebElement>((d) =>
            {
                return d.FindElement(By.ClassName("rmText"));
            });
            var searchLabel = driver.FindElement(By.CssSelector("h1"));

            Assert.AreEqual("Search Applicants", searchLabel.Text);

            Console.WriteLine(searchLabel.Text);

           
        }

        [TestCleanup]
        public void TearDown()
        {
            
            driver.Close();
        }
    }
}
