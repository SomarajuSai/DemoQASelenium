using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace SpecflowSelenium.Drivers
{
    public class DriverClass
    {
        public static IWebDriver driver;

        public static void driverInitializer()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }
    }
}