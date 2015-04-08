using System;
using System.Collections;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SeleniumApiExamples
{
    [TestClass]
    public class SelectTests
    {
        private IWebDriver driver;

        [TestInitialize]
        public void Setup() 
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://www.compendiumdev.co.uk/selenium/basic_html_form.html");
        }

        //[TestMethod]
        //public void TestDropdown()
        //{
        //    Get the Dropdown as a Select using it's name attribute
        //    SelectElement dropdown = new SelectElement(driver.FindElement(By.Name("dropdown")));

        //    Verify Dropdown does not support mult iple selection
        //    Assert.IsFalse(dropdown.IsMultiple);
        //    Get all the options

        //    Verify Dropdown has four options for selection
        //    Assert.AreEqual(6, dropdown.Options.Count);


        //    SelectElement multiple = new SelectElement(driver.FindElement(By.Name("multipleselect[]")));

        //    Assert.AreEqual(multiple.AllSelectedOptions);
        //    //We will verify Dropdown has expected values as listed in a array
        //    ArrayList exp_options = new ArrayList(new String [] {"BMW", "Mercedes", "Audi","Honda"});
        //    var act_options = new ArrayList();

        //    //Retrieve the option values from Dropdown using getOptions() method
        //    foreach(IWebElement option in dropdown.Options)
        //         act_options.Add(option.Text);

        //    //Verify expected options array and actual options array match
        //    Assert.AreEqual(exp_options.ToArray(),act_options.ToArray());

        //    //With Select class we can select an option in Dropdown using Visible Text
        //    dropdown.SelectByText("Honda");
        //    Assert.AreEqual("Honda", dropdown.SelectedOption.Text);

        //    //or we can select an option in Dropdown using value attribute
        //    dropdown.SelectByValue("audi");
        //    Assert.AreEqual("Audi", dropdown.SelectedOption.Text);

        //    //or we can select an option in Dropdown using index
        //    dropdown.SelectByIndex(0);
        //    Assert.AreEqual("BMW", dropdown.SelectedOption.Text);
        //}

        [TestMethod]
        public void TestMultipleSelectList()
        {
            //Get the List as a Select using it's name attribute
            SelectElement multiple = new SelectElement(driver.FindElement(By.Name("multipleselect[]")));

            //Verify List support multiple selection
            Assert.IsTrue(multiple.IsMultiple);

            //Verify List has five options for selection
            Assert.AreEqual(4, multiple.Options.Count);

            //Select multiple options in the list using visible text
            multiple.SelectByText("Selection Item 1");
            multiple.SelectByText("Selection Item 2");
            multiple.SelectByText("Selection Item 4");

            //Verify there 3 options selected in the list
            Assert.AreEqual(3, multiple.AllSelectedOptions.Count);

            //We will verify list has multiple options selected as listed in a array
            var exp_sel_options = new ArrayList(new String[] { "Selection Item 1", "Selection Item 2", "Selection Item 4" });
            var act_sel_options = new ArrayList();

            foreach (IWebElement option in multiple.AllSelectedOptions)
                act_sel_options.Add(option.Text);

            //Verify expected array for selected options match with actual options selected
            Assert.AreEqual(exp_sel_options.ToString(), act_sel_options.ToString());

            //Deselect an option using visible text
            multiple.DeselectByText("Selection Item 2");
            //Verify selected options count
            Assert.AreEqual(2, multiple.AllSelectedOptions.Count);

            //Deselect an option using value attribute of the option
            multiple.DeselectByValue("ms4");
            //Verify selected options count
            Assert.AreEqual(1, multiple.AllSelectedOptions.Count);

            //Deselect an option using index of the option
            multiple.DeselectByIndex(0);
            //Verify selected options count
            Assert.AreEqual(0, multiple.AllSelectedOptions.Count);

            //Select all multiple options in the list using visible text
            multiple.SelectByText("Selection Item 1");
            multiple.SelectByText("Selection Item 2");
            multiple.SelectByText("Selection Item 3");
            multiple.SelectByText("Selection Item 4");
            //De-Select all and check none are selected
            multiple.DeselectAll();
            Assert.AreEqual(0, multiple.AllSelectedOptions.Count);
        }

        [TestCleanup]
        public void TearDown() 
        {
            driver.Close();
        }
    }
}
