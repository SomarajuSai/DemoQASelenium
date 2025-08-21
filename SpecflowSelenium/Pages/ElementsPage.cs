using NUnit.Framework;
using OpenQA.Selenium;
using SpecflowSelenium.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowSelenium.Pages
{
    public class ElementsPage
    {
        private IWebDriver driver => DriverClass.driver;


        public void ValidateThePage(string ExpectedResult)
        {

            var actualFunctionName = driver.FindElement(By.XPath($"//div[text()='{ExpectedResult}']")).Text.Trim();
            Assert.AreEqual(ExpectedResult, actualFunctionName,
            $"Expected function name to be '{ExpectedResult}' but found '{actualFunctionName}'");

        }

        public void ClickOnButton(string Page)
        { 
            driver.FindElement(By.Id($"//li[@id='{Page}']")).Click();
            //    By locator = By.XPath($"//ul[@class=\"menu-list\"]//li[@id='{Page}']");
            //    ScrollAndClick(locator);
            //}//ul[@class=\\\"menu-list\\\"]
            //private void ScrollAndClick(By locator)
            //{
            //    IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            //    int maxScrolls = 20;
            //    int scrollStep = 100;

            //    for (int i = 0; i < maxScrolls; i++)
            //    {
            //        try
            //        {
            //            var Page = driver.FindElement(locator);
            //            if (Page.Displayed)
            //            {
            //                js.ExecuteScript("arguments[0].scrollIntoView(true);", Page);
            //                Page.Click();
            //                return;
            //            }
            //        }
            //        catch (NoSuchElementException)
            //        {

            //        }

            //        js.ExecuteScript($"window.scrollBy(0, {scrollStep});");
            //        Thread.Sleep(300);
            //    }

            //    throw new Exception($"Element with locator {locator} not found after scrolling.");

        }

    }
}