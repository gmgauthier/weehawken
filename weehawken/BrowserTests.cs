using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace weehawken
{
    public class Tests
    {
        ChromeDriver chromeDriver;
        FirefoxDriver firefoxDriver;
        String url = "https://duckduckgo.com/";

        [SetUp]
        public void Setup()
        {
            Console.WriteLine("Beginning Test");
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("End Test");
        }

        [Test]
        public void ChromeTest()
        {
            Console.WriteLine("Chrome Test");
            ChromeOptions copts = new ChromeOptions();
            copts.AddArguments("headless");
            chromeDriver = new ChromeDriver(copts);
            chromeDriver.Navigate().GoToUrl(url);
            RemoteWebElement searchBox =
                (RemoteWebElement)chromeDriver.FindElementByXPath("//input[@id='search_form_input_homepage']");
            searchBox.SendKeys("frankenberries");
            searchBox.SendKeys(Keys.Enter);
            RemoteWebElement results =
                (RemoteWebElement)chromeDriver.FindElementByPartialLinkText("Monster cereal");
            Assert.NotNull(results);
            chromeDriver.Quit();
        }

        [Test]
        public void FirefoxTest()
        {
            Console.WriteLine("Firefox Test");
            FirefoxOptions fopts = new FirefoxOptions();
            fopts.AddArguments("--headless");
            firefoxDriver = new FirefoxDriver(fopts);
            firefoxDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            firefoxDriver.Navigate().GoToUrl(url);
            firefoxDriver.FindElementByXPath("//input[@id='search_form_input_homepage']")
                .SendKeys("frankenberries" + Keys.Enter);

            RemoteWebElement results =
                (RemoteWebElement)firefoxDriver.FindElementByPartialLinkText("Monster cereal");
            Assert.NotNull(results);
            firefoxDriver.Quit();
        }
    }
}