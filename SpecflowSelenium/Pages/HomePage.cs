using OpenQA.Selenium;
using SpecflowSelenium.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowSelenium.Pages
{
   public class HomePage
   {
        private IWebDriver driver => DriverClass.driver;

        public void OpenDemoQA()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/");
        }

        public void ClickOnMenu(string Page)
        {
            
            By locator = By.XPath($"//div[@class='card-body']//h5[text()='{Page}']");
            ScrollAndClick(locator);
        }
        private void ScrollAndClick(By locator)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            int maxScrolls = 20;
            int scrollStep = 100;

            for (int i = 0; i < maxScrolls; i++)
            {
                try
                {
                    var Page = driver.FindElement(locator);
                    if (Page.Displayed)
                    {
                        js.ExecuteScript("arguments[0].scrollIntoView(true);", Page);
                        Page.Click();
                        return;
                    }
                }
                catch (NoSuchElementException)
                {

                }

                js.ExecuteScript($"window.scrollBy(0, {scrollStep});");
                Thread.Sleep(300);
            }

            throw new Exception($"Element with locator {locator} not found after scrolling.");

        }

   }
}
