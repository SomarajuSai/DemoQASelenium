using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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

            var actualFunctionName = driver.FindElement(By.XPath("//div[@class='header-text']")).Text;
            Assert.AreEqual(ExpectedResult, actualFunctionName,
            $"Expected function name to be '{ExpectedResult}' but found '{actualFunctionName}'");

        }

        public void ClickOnButton(string Page)

        {

            driver.FindElement(By.XPath($"//span[text()='{Page}']")).Click();

        }

        public void ValidateTheTextBoxPage(string ExpectedResult)
        {


            var actualElement = driver.FindElement(By.XPath("//h1[@class='text-center']"));
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


        public void EnterTheWebTableDetails(Table Details)
        {

            foreach (var row in Details.Rows)
            {

                driver.FindElement(addButton).Click();

                driver.FindElement(firstName).SendKeys(row["First Name"]);
                driver.FindElement(lastName).SendKeys(row["Last Name"]);
                driver.FindElement(userEmail).SendKeys(row["Email"]);
                driver.FindElement(age).SendKeys(row["Age"]);
                driver.FindElement(salary).SendKeys(row["Salary"]);
                driver.FindElement(department).SendKeys(row["Department"]);

                driver.FindElement(subBtn).Click();
            }

        }

        public void ValidateTheDetails(Table table)
        {
            var row = table.Rows[0];

            string expectedName = row["FullName"];
            string expectedEmail = row["Email"];
            string expectedCurrentAddress = row["CurrentAddress"];
            string expectedPermanentAddress = row["PermanentAddress"];


            string actualName = driver.FindElement(outputName).Text.Replace("Name:", "").Trim();
            string actualEmail = driver.FindElement(outputEmail).Text.Replace("Email:", "").Trim();
            string actualCurrentAddress = driver.FindElement(outputCurrentAddress).Text.Replace("Current Address :", "").Trim();
            string actualPermanentAddress = driver.FindElement(outputPermanentAddress).Text.Replace("Permananet Address :", "").Trim();


            Assert.AreEqual(expectedName, actualName, $"❌ FullName mismatch! Expected: {expectedName}, Found: {actualName}");
            Assert.AreEqual(expectedEmail, actualEmail, $"❌ Email mismatch! Expected: {expectedEmail}, Found: {actualEmail}");
            Assert.AreEqual(expectedCurrentAddress, actualCurrentAddress, $"❌ Current Address mismatch! Expected: {expectedCurrentAddress}, Found: {actualCurrentAddress}");
            Assert.AreEqual(expectedPermanentAddress, actualPermanentAddress, $"❌ Permanent Address mismatch! Expected: {expectedPermanentAddress}, Found: {actualPermanentAddress}");

        }

       

        public void ValidateTheWebTableDetails(Table table)
        {
            
            var webTableRows = driver.FindElements(By.XPath("//div[@class='rt-tbody']//div[@class='rt-tr-group']"));

            int offset = 3;

            for (int i = 0; i < table.Rows.Count; i++)
            {
                var expectedRow = table.Rows[i];
                var webRow = webTableRows[i + offset];

                
                var columns = webRow.FindElements(By.XPath(".//div[@class='rt-td']"));

                string actualFirstName = columns[0].Text.Trim();
                string actualLastName = columns[1].Text.Trim();
                string actualAge = columns[2].Text.Trim();
                string actualEmail = columns[3].Text.Trim();
                string actualSalary = columns[4].Text.Trim();
                string actualDepartment = columns[5].Text.Trim();

                Assert.AreEqual(expectedRow["First Name"], actualFirstName, $"❌ First Name mismatch at row {i + 1}");
                Assert.AreEqual(expectedRow["Last Name"], actualLastName, $"❌ Last Name mismatch at row {i + 1}");
                Assert.AreEqual(expectedRow["Age"], actualAge, $"❌ Age mismatch at row {i + 1}");
                Assert.AreEqual(expectedRow["Email"], actualEmail, $"❌ Email mismatch at row {i + 1}");
                Assert.AreEqual(expectedRow["Salary"], actualSalary, $"❌ Salary mismatch at row {i + 1}");
                Assert.AreEqual(expectedRow["Department"], actualDepartment, $"❌ Department mismatch at row {i + 1}");
            }
        }
        private By searchBox = By.Id("searchBox");

        public void SearchWebTable(string keyword)
        {
            var box = driver.FindElement(searchBox);
            
            box.SendKeys(keyword);
            Thread.Sleep(1000);
            box.Clear();
         
        }

        public void ValidateTheFirstName(string FirstName)
        {

            var actualElement = driver.FindElement(By.XPath("//div[@class='rt-td' and @role='gridcell']"));
            var actualFunctionName = actualElement.Text.Trim();

            Assert.AreEqual(FirstName, actualFunctionName,
                $"❌ Expected function name to be '{FirstName}' but found '{actualFunctionName}'");
        }

        public void ValidateTheButtonsPage(string ExpectedResult)
        {
            var actualFunctionName = driver.FindElement(By.XPath("//h1[@class='text-center']")).Text;
            Assert.AreEqual(ExpectedResult, actualFunctionName,
            $"Expected function name to be '{ExpectedResult}' but found '{actualFunctionName}'");
        }

        public void DoubleClickButton(string Action)
        {
            Actions actions = new Actions(driver);
            IWebElement doubleClickBtn = driver.FindElement(By.XPath("//button[text()='Double Click Me']"));
            actions.DoubleClick(doubleClickBtn).Perform();

        }

        public void RightClickButton(string Action)
        {
            Actions actions = new Actions(driver);
            IWebElement rightClickBtn = driver.FindElement(By.XPath("//button[text()='Right Click Me']"));
            actions.ContextClick(rightClickBtn).Perform();
        }

        public void ClickButton(string Action)
        {

            driver.FindElement(By.XPath("//button[text()='Click Me']")).Click();

        }

        public void ValidateTheDoubleClickText(string ExpectedText)
        {
            string actualText = driver.FindElement(By.XPath("//p[text()='You have done a double click']")).Text.Trim();
            Assert.AreEqual(ExpectedText, actualText, $"❌ Expected text '{ExpectedText}', but found '{actualText}'");

        }

        public void ValidateRightClickText(string ExpectedText)
        {
            string actualText = driver.FindElement(By.XPath("//p[text()='You have done a right click']")).Text.Trim();
            Assert.AreEqual(ExpectedText, actualText, $"❌ Expected text '{ExpectedText}', but found '{actualText}'");
        }

        public void ValidateTheClickText(String ExpectedText)
        {
            string actualText = driver.FindElement(By.XPath("//p[text()='You have done a dynamic click']")).Text.Trim();
            Assert.AreEqual(ExpectedText, actualText, $"❌ Expected text '{ExpectedText}', but found '{actualText}'");
        }
    }
} 
