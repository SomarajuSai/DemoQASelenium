using OpenQA.Selenium;
using SpecflowSelenium.Drivers;
using TechTalk.SpecFlow;

namespace SpecflowSelenium.Hooks
{
    [Binding]
    public class Hooks : DriverClass
    {
        [BeforeScenario]
        public void BeforeScenario()
        {
            driverInitializer(); // Test commit
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver?.Quit();
        }
    }
}