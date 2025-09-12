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
    public class FormsPage
    {
        public IWebDriver driver => DriverClass.driver;

        public void ClickOnButton(string Page)
        {
           driver.FindElement(By.XPath($"//span[text()='{Page}']")).Click();
        }
         
        public void ValidateThePracticeFormPage(string ExpectedResult)
        {
            var actualFunctionName = driver.FindElement(By.XPath("//h1[@class='text-center']")).Text;
            Assert.AreEqual(ExpectedResult, actualFunctionName,
            $"Expected function name to be '{ExpectedResult}' but found '{actualFunctionName}'");
        }

        public void EnterTheDetailsInPracticeForm(Table deatails)
        {

        }

    }
    
}
