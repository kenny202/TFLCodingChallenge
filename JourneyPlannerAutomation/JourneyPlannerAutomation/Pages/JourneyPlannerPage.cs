using OpenQA.Selenium;
using System.Threading;


namespace JourneyPlannerAutomation.Pages
{
    public class JourneyPlannerPage
    {
        private IWebDriver _driver;

        public JourneyPlannerPage(IWebDriver driver)
        {
            _driver = driver;
        }

        By planAJourneyLink = By.XPath("//*[@id='mainnav']/div[1]/div/div[2]/ul/li[1]/a");
        By fromField = By.Id("InputFrom");
        By toField = By.Id("InputTo");
        By planMyJourneyTab = By.Id("plan-journey-button");
        By viewDetailsLink = By.XPath("//a[@data-show-text='View details']");
        By errorMsg = By.CssSelector(".field-validation-errors");
        By fromFieldErrorMsg = By.Id("InputFrom-error");
        By toFieldErrorMsg = By.Id("InputTo-error");
        By editJourneyBtn = By.CssSelector(".edit-journey");
        By updateJourneyBtn = By.Id("plan-journey-button");
        By recentsLink = By.Id("jp-recent-tab-jp");
        By recentSearchDataText = By.XPath("//a[@class='plain-button journey-item']");
    

        public void ClickPlanAJourneyLink()
        {
            Thread.Sleep(5000);
            _driver.FindElement(planAJourneyLink).Click();
        }

        public void FillFromField(string addressFrom)
        {
            IWebElement fromFieldLocator = _driver.FindElement(fromField);
            fromFieldLocator.Clear();
            fromFieldLocator.SendKeys(addressFrom);
            fromFieldLocator.SendKeys(Keys.Tab);
        }

        public void FillToField(string addressTo)
        {
            IWebElement toFieldLocator = _driver.FindElement(toField);
            toFieldLocator.Clear();
            toFieldLocator.SendKeys(addressTo);
            toFieldLocator.SendKeys(Keys.Tab);
        }

        public void ClickPlanMyJourneyTab()
        {
            _driver.FindElement(planMyJourneyTab).Click();
        }

        public bool VerifyViewDetailsLink()
        {
            Thread.Sleep(5000);
            return _driver.FindElement(viewDetailsLink).Displayed;
        }

        public string ReturnInvalidSearchErrorMessage()
        {
            Thread.Sleep(5000);
            return _driver.FindElement(errorMsg).Text.Trim();
        }

        public string ReturnFromFieldErrorMessage()
        {
            Thread.Sleep(5000);
            return _driver.FindElement(fromFieldErrorMsg).Text.Trim();
        }

        public string ReturnToFieldErrorMessage()
        {
            Thread.Sleep(5000);
            return _driver.FindElement(toFieldErrorMsg).Text.Trim();
        }

        public void ClickOnEditJourneyButton()
        {
            _driver.FindElement(editJourneyBtn).Click();
        }

        public void ClickOnUpdateJourneyButton()
        {
            _driver.FindElement(updateJourneyBtn).Click();
        }

        public void ClickOnRecentsLink()
        {
            Thread.Sleep(5000);
            _driver.Navigate().Back();
            _driver.FindElement(recentsLink).Click();
        }

        public string RecentSearchText() {

         return   _driver.FindElement(recentSearchDataText).Text;
        }
    }
}
