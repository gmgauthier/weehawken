using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;

namespace weehawken
{
    public static class BrowserDriver
    {
        public static RemoteWebDriver GetDriver(string browser, bool headless)
        { 
            switch (browser)
            {
                case "chrome":
                    return GetChrome(headless);
                case "firefox":
                    return GetFirefox(headless);
                case "safari":
                    return getSafari(headless);
                case "edge":
                    return getEdge(headless);
                default:
                    throw new ArgumentException("Invalid browser specified"); 
            }
        }


        private static RemoteWebDriver GetChrome(bool headless)
        {
            ChromeOptions opts = new ChromeOptions();
            if (headless)
            {
                opts.AddArguments("headless");
            }
            opts.AcceptInsecureCertificates = true;
            RemoteWebDriver driver = new ChromeDriver(opts);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            return driver;
        }

        private static RemoteWebDriver GetFirefox(bool headless)
        {
            FirefoxOptions fopts = new FirefoxOptions();
            if (headless)
            {
                fopts.AddArguments("--headless");
            }
            fopts.AcceptInsecureCertificates = true;
            RemoteWebDriver driver = new FirefoxDriver(fopts);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            return driver;
        }

        private static RemoteWebDriver getSafari(bool headless)
        {
            return new SafariDriver();
        }

        private static RemoteWebDriver getEdge(bool headless)
        {
            return new EdgeDriver();
        }
    }
}
