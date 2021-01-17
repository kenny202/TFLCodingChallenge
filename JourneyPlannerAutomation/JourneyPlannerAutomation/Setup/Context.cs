using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;


namespace JourneyPlannerAutomation.Setup
{
    public class Context
    {
        private IObjectContainer _objectContainer;
        private IWebDriver _driver;
        string baseUrl = "https://tfl.gov.uk/";

        public Context(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
            _driver = new ChromeDriver();
            _objectContainer.RegisterInstanceAs<IWebDriver>(_driver);
        }

        public void LoadApplicationUnderTest()
        {           
            
            _driver.Navigate().GoToUrl(baseUrl);
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
          
        }

        public void ShutDownApplicationUnderTest()
        {
            _driver.Quit();
        }

        public void AcceptCookies() { 
        
        
        
        }



    }
}
