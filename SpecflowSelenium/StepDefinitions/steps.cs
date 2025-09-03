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

                else if (Page =="Add")
                    elementsPage.ClickOnAddButton(Page);

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
        }


        [When(@"I Enter the following details")]
        public void WhenIEnterTheFollowingDetails(Table TableDetails)
        {
            elementsPage.EnterTheTableDetails(TableDetails);
        }

        [Then(@"I Validate the all details")]
        public void ThenIValidateTheAllDetails()
        {
            elementsPage.ValidateTheDetails();
        }

        [When(@"I add the details in Web Tables")]
        public void WhenIAddTheDetailsInWebTables(Table Details)
        {
            elementsPage.EnterTheWebTableDetails(Details);
        }


        [Then(@"I Validate the Regestration Form details")]
        public void ThenIValidateTheRegestrationFormDetails()
        {
            elementsPage.ValidateTheRegestrationFormDetails();
        }

    }
}


