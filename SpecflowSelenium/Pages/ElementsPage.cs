using NUnit.Framework;
using OpenQA.Selenium;
using SpecflowSelenium.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

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

            //driver.FindElement(subBtn).Click();
        }

       public void  ValidateTheDetails(Table table)
       {
            var row = table.Rows[0];

            string expectedName = row["FullName"];
            string expectedEmail = row["Email"];
            string expectedCurrentAddress = row["CurrentAddress"];
            string expectedPermanentAddress = row["PermanentAddress"];

            // Fetch actual output text
            string actualName = driver.FindElement(outputName).Text.Replace("Name:", "").Trim();
            string actualEmail = driver.FindElement(outputEmail).Text.Replace("Email:", "").Trim();
            string actualCurrentAddress = driver.FindElement(outputCurrentAddress).Text.Replace("Current Address :", "").Trim();
            string actualPermanentAddress = driver.FindElement(outputPermanentAddress).Text.Replace("Permananet Address :", "").Trim();

            // Assertions
            Assert.AreEqual(expectedName, actualName, $"❌ FullName mismatch! Expected: {expectedName}, Found: {actualName}");
            Assert.AreEqual(expectedEmail, actualEmail, $"❌ Email mismatch! Expected: {expectedEmail}, Found: {actualEmail}");
            Assert.AreEqual(expectedCurrentAddress, actualCurrentAddress, $"❌ Current Address mismatch! Expected: {expectedCurrentAddress}, Found: {actualCurrentAddress}");
            Assert.AreEqual(expectedPermanentAddress, actualPermanentAddress, $"❌ Permanent Address mismatch! Expected: {expectedPermanentAddress}, Found: {actualPermanentAddress}");

        }

        public void ValidateTheRegistrationFormDetails(Table table)
        {
            var row = table.Rows[0];

            string expectedFirstName = row["First Name"];
            string expectedLastName = row["Last Name"];
            string expectedEmail = row["Email"];
            string expectedAge = row["Age"];
            string expectedSalary = row["Salary"];
            string expectedDepartment = row["Department"];

            // Get actual values from form input fields
            string actualFirstName = driver.FindElement(firstName).GetAttribute("value").Trim();
            string actualLastName = driver.FindElement(lastName).GetAttribute("value").Trim();
            string actualEmail = driver.FindElement(userEmail).GetAttribute("value").Trim();
            string actualAge = driver.FindElement(age).GetAttribute("value").Trim();
            string actualSalary = driver.FindElement(salary).GetAttribute("value").Trim();
            string actualDepartment = driver.FindElement(department).GetAttribute("value").Trim();

            // Assertions
            Assert.AreEqual(expectedFirstName, actualFirstName, $"❌ First Name mismatch! Expected: {expectedFirstName}, Found: {actualFirstName}");
            Assert.AreEqual(expectedLastName, actualLastName, $"❌ Last Name mismatch! Expected: {expectedLastName}, Found: {actualLastName}");
            Assert.AreEqual(expectedEmail, actualEmail, $"❌ Email mismatch! Expected: {expectedEmail}, Found: {actualEmail}");
            Assert.AreEqual(expectedAge, actualAge, $"❌ Age mismatch! Expected: {expectedAge}, Found: {actualAge}");
            Assert.AreEqual(expectedSalary, actualSalary, $"❌ Salary mismatch! Expected: {expectedSalary}, Found: {actualSalary}");
            Assert.AreEqual(expectedDepartment, actualDepartment, $"❌ Department mismatch! Expected: {expectedDepartment}, Found: {actualDepartment}");
            driver.FindElement(subBtn).Click();
        }
    }
    
    
}  
