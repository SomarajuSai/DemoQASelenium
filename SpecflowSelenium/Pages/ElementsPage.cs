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

        private By fullName = By.Id("userName");
        private By email = By.Id("userEmail");
        private By currentAddress = By.Id("currentAddress");
        private By permanentAddress = By.Id("permanentAddress");
        private By submitBtn = By.Id("submit");


        private By outputName = By.Id("name");
        private By outputEmail = By.Id("email");
        private By outputCurrentAddress = By.CssSelector("p#currentAddress");
        private By outputPermanentAddress = By.CssSelector("p#permanentAddress");

        // Web Tables Registration Form Locators
        private By addButton = By.Id("addNewRecordButton");
        private By firstName = By.Id("firstName"); 
        private By lastName = By.Id("lastName");
        private By userEmail = By.Id("userEmail");
        private By age = By.Id("age");
        private By salary = By.Id("salary");
        private By department = By.Id("department");
        private By subBtn = By.Id("submit");

        private string expName, expEmail, expCurrAddr, expPermAddr, exsubmitBtn;
        public void ValidateThePage(string ExpectedResult)
        {

            var actualFunctionName = driver.FindElement(By.XPath("//div[@class=\"header-text\"]")).Text;
            Assert.AreEqual(ExpectedResult, actualFunctionName,
            $"Expected function name to be '{ExpectedResult}' but found '{actualFunctionName}'");

        }

        public void ClickOnButton(string Page)

        { 
            
            driver.FindElement(By.XPath($"//span[text()='{Page}']")).Click();

        }

        public void ValidateTheTextBoxPage(string ExpectedResult)
        {


            var actualElement = driver.FindElement(By.XPath("//h1[@class=\"text-center\"]"));
            var actualFunctionName = actualElement.Text.Trim();

            Assert.AreEqual(ExpectedResult, actualFunctionName,
                $"❌ Expected function name to be '{ExpectedResult}' but found '{actualFunctionName}'");

        }


        public void EnterTheTableDetails(Table TableDetails)
        {

            var row = TableDetails.Rows[0];

            expName = row["FullName"];
            expEmail = row["Email"];
            expCurrAddr = row["CurrentAddress"];
            expPermAddr = row["PermanentAddress"];

            driver.FindElement(fullName).SendKeys(expName);
            driver.FindElement(email).SendKeys(expEmail);
            driver.FindElement(currentAddress).SendKeys(expCurrAddr);
            driver.FindElement(permanentAddress).SendKeys(expPermAddr);
            IWebElement submit = driver.FindElement(submitBtn);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", submit);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", submit);
        }

        public void ValidateTheDetails()
        {

            string actualName = driver.FindElement(outputName).Text.Replace("Name:", "").Trim();
            string actualEmail = driver.FindElement(outputEmail).Text.Replace("Email:", "").Trim();
            string actualCurrAddr = driver.FindElement(outputCurrentAddress).Text.Replace("Current Address :", "").Trim();
            string actualPermAddr = driver.FindElement(outputPermanentAddress).Text.Replace("Permananet Address :", "").Trim();

            Assert.AreEqual(expName, actualName, "Name does not match!");
            Assert.AreEqual(expEmail, actualEmail, "Email does not match!");
            Assert.AreEqual(expCurrAddr, actualCurrAddr, "Current Address does not match!");
            Assert.AreEqual(expPermAddr, actualPermAddr, "Permanent Address does not match!");

        }


        public void ValidateTheWebTablePage(string ExpectedResult)
        {
            var actualFunctionName = driver.FindElement(By.XPath("//h1[@class='text-center']")).Text;
            Assert.AreEqual(ExpectedResult, actualFunctionName,
            $"Expected function name to be '{ExpectedResult}' but found '{actualFunctionName}'");

        }
        public void  ClickOnAddButton(string Page)
        {

            driver.FindElement(By.XPath("//button[@id=\"addNewRecordButton\"]")).Click();
        }

        public void EnterTheWebTableDetails(Table Details)
        {
            var data = Details.Rows[0];
            
            driver.FindElement(firstName).SendKeys(data["First Name"]);
            driver.FindElement(lastName).SendKeys(data["Last Name"]);
            driver.FindElement(userEmail).SendKeys(data["Email"]);
            driver.FindElement(age).SendKeys(data["Age"]);
            driver.FindElement(salary).SendKeys(data["Salary"]);
            driver.FindElement(department).SendKeys(data["Department"]);

            driver.FindElement(subBtn).Click();
        }

       public void ValidateTheRegestrationFormDetails()
       {


       }

    }
    
}  
