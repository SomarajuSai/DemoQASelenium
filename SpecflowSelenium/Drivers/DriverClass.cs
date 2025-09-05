using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SpecflowSelenium.Drivers
{
    public class DriverClass
    {
        public static IWebDriver driver;

        public static void driverInitializer()
        {
            // Auto-download the correct ChromeDriver version
            new DriverManager().SetUpDriver(new ChromeConfig());

            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-notifications");

            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }
    }
}