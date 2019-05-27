using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;

namespace SeleniumTutorial
{
    class NunitTest
    {
        IWebDriver driver;

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
        [TearDown]
        public void CloseTestApp()
        {
            //driver.Close();
        }
    }
}
