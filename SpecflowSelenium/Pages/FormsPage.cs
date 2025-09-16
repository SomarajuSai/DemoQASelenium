using NUnit.Framework;
using OpenQA.Selenium;
using SpecflowSelenium.Drivers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using System.IO;

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

        public void EnterTheDetailsInPracticeForm(Table details)
        {
            var data = details.Rows[0];


            driver.FindElement(By.Id("firstName")).SendKeys(data["FirstName"]);


            driver.FindElement(By.Id("lastName")).SendKeys(data["LastName"]);


            driver.FindElement(By.Id("userEmail")).SendKeys(data["Email"]);


            string[] genders = data["Gender"].Split(',');
            foreach (var gender in genders)
            {
                driver.FindElement(By.XPath($"//label[text()='{gender.Trim()}']")).Click();
                Thread.Sleep(5000);
            }

            driver.FindElement(By.Id("userNumber")).SendKeys(data["Mobile"]);
            Thread.Sleep(5000);

            SelectDateOfBirth(data["DOB"]);


            string[] subjects = data["Subjects"].Split(',');
            var subjectsInput = driver.FindElement(By.Id("subjectsInput"));
            foreach (var subject in subjects)
            {
                subjectsInput.SendKeys(subject.Trim());
                subjectsInput.SendKeys(Keys.Enter);
            }

            // Hobbies (checkbox)
            string[] hobbies = data["Hobbies"].Split(',');
            foreach (var hobby in hobbies)
            {
                driver.FindElement(By.XPath($"//label[text()='{hobby.Trim()}']")).Click();
            }

            // Upload picture
            string picturePath = Path.Combine(Directory.GetCurrentDirectory(), data["Picture"]);
            driver.FindElement(By.Id("uploadPicture")).SendKeys(picturePath);

            // Current Address
            driver.FindElement(By.Id("currentAddress")).SendKeys(data["Address"]);

            // Select State
            driver.FindElement(By.Id("state")).Click();
            driver.FindElement(By.XPath($"//div[text()='{data["State"]}']")).Click();

            // Select City
            driver.FindElement(By.Id("city")).Click();
            driver.FindElement(By.XPath($"//div[text()='{data["City"]}']")).Click();

            // Submit
            driver.FindElement(By.Id("submit")).Click();



        }

        private void SelectDateOfBirth(string dob)
        {
            // Parse the date from feature file: "09 Jul 1998"
            DateTime targetDate = DateTime.ParseExact(dob, "dd MMM yyyy", CultureInfo.InvariantCulture);
            string targetYear = targetDate.Year.ToString();
            string targetMonth = targetDate.ToString("MMMM", CultureInfo.InvariantCulture); // Full month name
            string targetDay = targetDate.Day.ToString();

            // Open date picker
            driver.FindElement(By.XPath("//input[@id='dateOfBirthInput']")).Click();
            Thread.Sleep(5000);

            // --- Select Year ---
            var yearDropdown = driver.FindElement(By.CssSelector(".react-datepicker__year-select"));
            var selectYear = new SelectElement(yearDropdown);
            selectYear.SelectByText(targetYear); // Will scroll automatically to find the year

            // --- Select Month ---
            var monthDropdown = driver.FindElement(By.CssSelector(".react-datepicker__month-select"));
            var selectMonth = new SelectElement(monthDropdown);
            selectMonth.SelectByText(targetMonth);

            // --- Select Day ---
            // Build XPath dynamically, avoid disabled dates
            var dayElement = driver.FindElements(By.XPath($"//div[contains(@class,'react-datepicker__day') and text()='{targetDay}']"))
                                   .FirstOrDefault(el => el.Displayed && el.Enabled);

            if (dayElement == null)
                throw new NoSuchElementException($"Could not find day: {targetDay} in the calendar");

            dayElement.Click();
        }
    }
}
    

