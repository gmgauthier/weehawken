using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace weehawken
{
    public class Tests
    {
        private String url;
        private RemoteWebDriver driver;

        [SetUp]
        public void Setup()
        {
            Console.WriteLine("Beginning Test");
            url = "https://duckduckgo.com/";
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            Console.WriteLine("End Test");

        }

        [Test]
        public void ChromeTest()
        {
            Console.WriteLine("Chrome Test");
            driver = BrowserDriver.GetDriver("chrome", true);
            driver.Navigate().GoToUrl(url);
            RemoteWebElement searchBox =
                (RemoteWebElement)driver.FindElementByXPath("//input[@id='search_form_input_homepage']");
            searchBox.SendKeys("frankenberries");
            searchBox.SendKeys(Keys.Enter);
            RemoteWebElement results =
                (RemoteWebElement)driver.FindElementByPartialLinkText("Monster cereal");
            Assert.NotNull(results);
        }

        [Test]
        public void FirefoxTest()
        {
            Console.WriteLine("Firefox Test");
            driver = BrowserDriver.GetDriver("firefox", true);
            driver.Navigate().GoToUrl(url);
            driver.FindElementByXPath("//input[@id='search_form_input_homepage']")
                .SendKeys("frankenberries" + Keys.Enter);
            RemoteWebElement results =
                (RemoteWebElement)driver.FindElementByPartialLinkText("Monster cereal");
            Assert.NotNull(results);
            driver.Quit();
        }
    }
}