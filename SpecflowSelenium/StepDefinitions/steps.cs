using NUnit.Framework;
using OpenQA.Selenium;
using SpecflowSelenium.Drivers;
using SpecflowSelenium.Pages;
using TechTalk.SpecFlow;

namespace SpecflowSelenium.StepDefinitions
{
    [Binding]
    public class steps 
    {
        
        private readonly HomePage homePage = new HomePage();
        private readonly ElementsPage elementsPage = new ElementsPage();
        private readonly FormsPage formsPage = new FormsPage();

      
        [Given(@"Open DEMOQA Website")]
        public void GivenOpenDEMOQAWebsite()
        {
            homePage.OpenDemoQA();
            
        }

        [When(@"I Click On '([^']*)'")]
        public void WhenOpenDemoQAWebsite(string Page)
        {


            {
                if (Page == "Elements")
                    homePage.ClickOnMenu(Page);

                else if (Page == "Text Box")
                    elementsPage.ClickOnButton(Page);

                else if (Page == "Web Tables")
                    elementsPage.ClickOnButton(Page);

                else if (Page == "Buttons")
                    elementsPage.ClickOnButton(Page);

                else if (Page =="Forms")
                    homePage.ClickOnMenu(Page);

                else if (Page == "Practice Form")
                    formsPage.ClickOnButton(Page);
               
               
            }

        } 

        [Then(@"I Validate the page '([^']*)'")]
        public void ThenIValidateThePage(string ExpectedResult)
        {
            if ( ExpectedResult == "Elements")
            elementsPage.ValidateThePage(ExpectedResult);

            else if (ExpectedResult =="Text Box")
                elementsPage.ValidateTheTextBoxPage(ExpectedResult);

            else if ( ExpectedResult == "Web Tables")
                elementsPage.ValidateTheWebTablePage(ExpectedResult);

            else if (ExpectedResult =="Buttons")
                elementsPage.ValidateTheButtonsPage(ExpectedResult); 

            else if (ExpectedResult == "Practice Form")
                formsPage.ValidateThePracticeFormPage(ExpectedResult);
        }


        [When(@"I Enter the following details")]
        public void WhenIEnterTheFollowingDetails(Table TableDetails)
        {
            elementsPage.EnterTheTableDetails(TableDetails);
        }

        [Then(@"I Validate the all details")]
        public void ThenIValidateTheAllDetails(Table TableDetails)
        {
            elementsPage.ValidateTheDetails(TableDetails);
        }

        [When(@"I add the details in Web Tables")]
        public void WhenIAddTheDetailsInWebTables(Table Details)
        {
            elementsPage.EnterTheWebTableDetails(Details);
        }

        [Then(@"I Validate the entered details")]
        public void ThenIValidateTheEnteredDetails(Table table)
        {
            elementsPage.ValidateTheDetails(table);
        }

       
        [Then(@"I Validate the Web Table details")]
        public void ThenIValidateTheWebTableDetails(Table table)
        {
            elementsPage.ValidateTheWebTableDetails(table);
        }

        [When(@"I Search for ""([^""]*)""")]
        public void WhenISearchFor(string keyword)
        {
            elementsPage.SearchWebTable(keyword);
        }

        [Then(@"I Validate the First Name '([^']*)'")]
        public void ThenIValidateTheFirstName(string FirstName)
        {
            elementsPage.ValidateTheFirstName(FirstName);
        }

        [When(@"I Click '([^']*)'")]
        public void WhenIClick(string Action)
        {
            if (Action == "Double Click Me")
                elementsPage.DoubleClickButton(Action);

            else if (Action == "Right Click Me")
                elementsPage.RightClickButton(Action);

            else if (Action == "Click Me")
                elementsPage.ClickButton(Action);

        }

        [Then(@"I Validate the text '([^']*)'")]
        public void ThenIValidateTheText(string ExpectedText)
        {
            if (ExpectedText == "You have done a double click")
            elementsPage.ValidateTheDoubleClickText(ExpectedText);

            else if (ExpectedText == "You have done a right click")
                elementsPage.ValidateRightClickText(ExpectedText);

            else if (ExpectedText == "You have done a dynamic click")
                elementsPage.ValidateTheClickText(ExpectedText);
        }

        [When(@"I eneter the details in Practice Form")]
        public void WhenIEneterTheDetailsInPracticeForm(Table details)
        {
            formsPage.EnterTheDetailsInPracticeForm(details);
        }

    }
}


