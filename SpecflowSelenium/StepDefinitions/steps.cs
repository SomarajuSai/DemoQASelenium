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
        public void WhenIClickOn(string Page)
        {  
            if (Page == "Elements")
                homePage.ClickOnMenu(Page);

            else if (Page == "Text Box")
                elementsPage.ClickOnButton(Page);
            
        }

        

        [Then(@"I Validate the page '([^']*)'")]
        public void ThenIValidateThePage(string ExpectedResult)
        {

            elementsPage.ValidateThePage(ExpectedResult);
        }


    }
}

