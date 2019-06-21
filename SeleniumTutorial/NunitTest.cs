using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;
using System.Threading;

namespace SeleniumTutorial
{
    class NunitTest
    {
        IWebDriver driver;
        IWebElement element;

        [SetUp]
        public void Initialize()
        {
            driver = new FirefoxDriver();
        }
        [Test, Order(1)]
        public void test1_OpenTestApp()
        {
            //go to page
            driver.Url = "https://www.demoqa.com";

            //get title of page
            string title = driver.Title;
            int titleLength = title.Length;

            //get page url
            string url = driver.Url;
            string pageSource = driver.PageSource;

            //get pagesource word count
            int pageLenght = pageSource.Length;
            Console.WriteLine(title);
            Console.WriteLine(titleLength);
            Console.WriteLine(url);
            //Console.WriteLine(pageSource);
            Console.WriteLine(pageLenght);
        }

        [Test, Order(2)]
        public void test2_CommandDriver2()
        {
            //click element
            driver.Url = "https://www.demoqa.com/frames-and-windows/";
            driver.FindElement(By.XPath(".//*[@id='tabs-1']/div/p/a")).Click();
            //page not exist anymore


        }

        [Test, Order(3)]
        public void test3_BrowserNavigation()
        {
            //go to url
            driver.Navigate().GoToUrl("https://www.demoqa.com");

            //click sortable sidebar
            //*[@id="sidebar"]/aside[1]/ul/li[1]/a
            driver.FindElement(By.XPath("//*[@id='sidebar']/aside[1]/ul/li[1]/a")).Click();

            //back
            driver.Navigate().Back();

            //forward
            driver.Navigate().Forward();

            //refresh
            driver.Navigate().Refresh();

        }

        [Test, Order(4)]
        public void test4_ElementCommands()
        {
            driver.Url = "https://www.google.com/";

            //sendtext and clear
            driver.FindElement(By.XPath("//*[@id='tsf']/div[2]/div/div[1]/div/div[1]/input")).SendKeys("test");
            driver.FindElement(By.XPath("//*[@id='tsf']/div[2]/div/div[1]/div/div[1]/input")).Clear();

            driver.Navigate().GoToUrl("https://www.demoqa.com");

            //click element
            driver.FindElement(By.XPath("//*[@id='sidebar']/aside[1]/ul/li[2]/a")).Click();

            //check if element enabled, display and selected
            element = driver.FindElement(By.XPath("//*[@id='selectable']/li[1]"));
            bool enabled = element.Enabled;
            bool displayed = element.Displayed;
            Assert.That(enabled.Equals(true));
            Assert.That(displayed.Equals(true));

            //check if element selected
            driver.FindElement(By.XPath("//*[@id='sidebar']/aside[2]/ul/li[11]/a")).Click();
            element = driver.FindElement(By.XPath("//*[@id='content']/div[2]/div/fieldset[1]/label[1]/span[1]"));
            element.Click();
            Thread.Sleep(2000);
            bool selected = element.Selected;
            //Assert.That(selected.Equals(true));

            //get tag name
            string tagname = element.TagName;
            Console.WriteLine("Tag name : "+ tagname);

            //get attribute
            string attribute = element.GetAttribute("class");
            Console.WriteLine("attribute name : " + attribute);

            //get css value
            string css = element.GetCssValue("radio-1");
            Console.WriteLine("css : " + css);

            //get type of element
            element.GetType();
            Console.WriteLine("element.GetType(); : " + element.GetType());



        }

        [Test, Order(5)]
        public void test5_findElementsCommands()
        {
            driver.Url = "http://toolsqa.com/automation-practice-form/";

            //partial link text
            driver.FindElement(By.PartialLinkText("Partial")).Click();

            //link text
            driver.FindElement(By.LinkText("Link Test")).Click();
            driver.Navigate().Back();

            //name
            //enter name
            driver.FindElement(By.Name("firstname")).SendKeys("zuzu");

            //id
            driver.FindElement(By.Id("sex-0")).Click();

            //css selector
            //select 1 year exp level
            driver.FindElement(By.CssSelector("input[id='exp-0']")).Click();

            //collect all exp level radio button
            IList<IWebElement> expLevelCheck = driver.FindElements(By.Name("exp"));

            //check if button radio selected
            bool isExpCheck;
            isExpCheck = expLevelCheck.ElementAt(0).Selected;
            
            //check exp year 2
            if (isExpCheck == true)
            {
                driver.FindElement(By.CssSelector("input[id='exp-1']")).Click();
            }

            //classname
            //check automation tester option
            driver.FindElement(By.ClassName("checkbox")).Click();

            //tagname
            //find all button
            String button = driver.FindElements(By.TagName("button")).ToString();
            Console.WriteLine(button);


        }

        [Test, Order(6)]
        public void fidElementForCheckBoxAndRadioButtons()
        {
            //click radio button by id
            driver.FindElement(By.Id("")).Click();

            //if radio button selected by default, and you need to select the other one

            //#1 store all buttons in a a list
            IList<IWebElement> radioElem = driver.FindElements(By.Id(""));

            //#2 default all button unchecked
            bool rButton = false;

            //#3 check if first button selected
            rButton = radioElem.ElementAt(0).Selected;

            if (rButton == true)
            {
                //click second button if first button selected
                radioElem.ElementAt(1).Click();
            }


            //click multiple checkbox with samevalue

            //#1 store all checkbox in list
            IList<IWebElement> checkBoxes = driver.FindElements(By.Name("name"));

            //#2 get total count of checkboxes
            int count = checkBoxes.Count();

            //#3 
        }

        [TearDown]
        public void CloseTestApp()
        {
            //driver.Close();
        }
    }
}
