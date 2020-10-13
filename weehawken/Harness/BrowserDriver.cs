using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

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
                    return GetSafari(false); //headless not supported
                case "edge":
                    return GetEdge(headless); //headless only available in Selenium 4
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

        private static RemoteWebDriver GetEdge(bool headless)
        {
            //new DriverManager().SetUpDriver(new EdgeConfig());
            EdgeOptions opts = new EdgeOptions();
            if (headless)
            {
                opts.AddArguments("headless");
            }
            opts.AcceptInsecureCertificates = true;
            RemoteWebDriver driver = new EdgeDriver(opts);
            return driver;
        }

        private static RemoteWebDriver GetSafari(bool headless)
        {
            String os = Environment.OSVersion.ToString();
            if (os.Contains("Win")){
                throw new NotSupportedException("Safari is not supported on Windows");
            }
            //SafariOptions opts = new SafariOptions();
            if (headless)
            {
                throw new NotSupportedException("Safari does not support headless operation");
            }
            //opts.AcceptInsecureCertificates = true;
            RemoteWebDriver driver = new SafariDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            return driver;
        }
    }
}
