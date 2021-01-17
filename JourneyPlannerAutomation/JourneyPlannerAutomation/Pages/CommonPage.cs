using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyPlannerAutomation.Pages
{
   public class CommonPage
    {
        IWebDriver _driver; 

        public CommonPage(IWebDriver driver)
        {
            _driver = driver;
        }


        By acceptedCookiesElement = By.CssSelector(".cb-button.cb-right");
        By acceptCookieDoneButton = By.XPath("//strong[contains(text(), 'Done')]");


        public void AcceptCookiesButton()
        {

            _driver.FindElement(acceptedCookiesElement).Click();
            _driver.FindElement(acceptCookieDoneButton).Click();
        
        }


    }
}
