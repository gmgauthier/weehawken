using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace weehawken
{
    public class BrowserTests
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
            //driver.Quit();
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
        }

        [Test]
        [Ignore("Safari implementation is broken in .Net")]
        public void SafariTest()
        {
            Console.WriteLine("Safari Test");
            driver = BrowserDriver.GetDriver("safari", false); //no headless for safari
            driver.Navigate().GoToUrl(url);
            driver.FindElementByXPath("//input[@id='search_form_input_homepage']")
                .SendKeys("frankenberries" + Keys.Enter);
            RemoteWebElement results =
                (RemoteWebElement)driver.FindElementByPartialLinkText("Monster cereal");
            Assert.NotNull(results);
        }

        [Test]
        [Ignore("Edge Implementation is broken in .Net for MAC")]
        public void EdgeTest()
        {
            Console.WriteLine("Edge Test");
            //driver = BrowserDriver.GetDriver("edge", true);
            driver.Navigate().GoToUrl(url);
            driver.FindElementByXPath("//input[@id='search_form_input_homepage']")
                .SendKeys("frankenberries" + Keys.Enter);
            RemoteWebElement results =
                (RemoteWebElement)driver.FindElementByPartialLinkText("Monster cereal");
            Assert.NotNull(results);
        }
    }
}